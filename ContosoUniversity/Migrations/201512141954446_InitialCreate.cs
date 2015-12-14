namespace ContosoUniversity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Course",
                c => new
                    {
                        CourseId = c.Int(nullable: false),
                        Title = c.String(),
                        Credits = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CourseId);
            
            CreateTable(
                "dbo.Enrollment",
                c => new
                    {
                        EnrollmentId = c.Int(nullable: false, identity: true),
                        CourseId = c.Int(nullable: false),
                        StudentId = c.Int(nullable: false),
                        Grade = c.Int(),
                    })
                .PrimaryKey(t => t.EnrollmentId);
            
            CreateTable(
                "dbo.Student",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LastName = c.String(),
                        FirstMidName = c.String(),
                        EnrollmentDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EnrollmentCourse",
                c => new
                    {
                        Enrollment_EnrollmentId = c.Int(nullable: false),
                        Course_CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Enrollment_EnrollmentId, t.Course_CourseId })
                .ForeignKey("dbo.Enrollment", t => t.Enrollment_EnrollmentId, cascadeDelete: true)
                .ForeignKey("dbo.Course", t => t.Course_CourseId, cascadeDelete: true)
                .Index(t => t.Enrollment_EnrollmentId)
                .Index(t => t.Course_CourseId);
            
            CreateTable(
                "dbo.StudentEnrollment",
                c => new
                    {
                        Student_Id = c.Int(nullable: false),
                        Enrollment_EnrollmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Student_Id, t.Enrollment_EnrollmentId })
                .ForeignKey("dbo.Student", t => t.Student_Id, cascadeDelete: true)
                .ForeignKey("dbo.Enrollment", t => t.Enrollment_EnrollmentId, cascadeDelete: true)
                .Index(t => t.Student_Id)
                .Index(t => t.Enrollment_EnrollmentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StudentEnrollment", "Enrollment_EnrollmentId", "dbo.Enrollment");
            DropForeignKey("dbo.StudentEnrollment", "Student_Id", "dbo.Student");
            DropForeignKey("dbo.EnrollmentCourse", "Course_CourseId", "dbo.Course");
            DropForeignKey("dbo.EnrollmentCourse", "Enrollment_EnrollmentId", "dbo.Enrollment");
            DropIndex("dbo.StudentEnrollment", new[] { "Enrollment_EnrollmentId" });
            DropIndex("dbo.StudentEnrollment", new[] { "Student_Id" });
            DropIndex("dbo.EnrollmentCourse", new[] { "Course_CourseId" });
            DropIndex("dbo.EnrollmentCourse", new[] { "Enrollment_EnrollmentId" });
            DropTable("dbo.StudentEnrollment");
            DropTable("dbo.EnrollmentCourse");
            DropTable("dbo.Student");
            DropTable("dbo.Enrollment");
            DropTable("dbo.Course");
        }
    }
}
