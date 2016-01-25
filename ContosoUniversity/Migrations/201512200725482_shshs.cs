namespace ContosoUniversity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class shshs : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EnrollmentCourse", "Enrollment_EnrollmentId", "dbo.Enrollment");
            DropForeignKey("dbo.EnrollmentCourse", "Course_CourseId", "dbo.Course");
            DropForeignKey("dbo.StudentEnrollment", "Student_Id", "dbo.Student");
            DropForeignKey("dbo.StudentEnrollment", "Enrollment_EnrollmentId", "dbo.Enrollment");
            DropIndex("dbo.EnrollmentCourse", new[] { "Enrollment_EnrollmentId" });
            DropIndex("dbo.EnrollmentCourse", new[] { "Course_CourseId" });
            DropIndex("dbo.StudentEnrollment", new[] { "Student_Id" });
            DropIndex("dbo.StudentEnrollment", new[] { "Enrollment_EnrollmentId" });
            CreateIndex("dbo.Enrollment", "CourseId");
            CreateIndex("dbo.Enrollment", "StudentId");
            AddForeignKey("dbo.Enrollment", "CourseId", "dbo.Course", "CourseId", cascadeDelete: true);
            AddForeignKey("dbo.Enrollment", "StudentId", "dbo.Student", "Id", cascadeDelete: true);
            DropTable("dbo.EnrollmentCourse");
            DropTable("dbo.StudentEnrollment");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.StudentEnrollment",
                c => new
                    {
                        Student_Id = c.Int(nullable: false),
                        Enrollment_EnrollmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Student_Id, t.Enrollment_EnrollmentId });
            
            CreateTable(
                "dbo.EnrollmentCourse",
                c => new
                    {
                        Enrollment_EnrollmentId = c.Int(nullable: false),
                        Course_CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Enrollment_EnrollmentId, t.Course_CourseId });
            
            DropForeignKey("dbo.Enrollment", "StudentId", "dbo.Student");
            DropForeignKey("dbo.Enrollment", "CourseId", "dbo.Course");
            DropIndex("dbo.Enrollment", new[] { "StudentId" });
            DropIndex("dbo.Enrollment", new[] { "CourseId" });
            CreateIndex("dbo.StudentEnrollment", "Enrollment_EnrollmentId");
            CreateIndex("dbo.StudentEnrollment", "Student_Id");
            CreateIndex("dbo.EnrollmentCourse", "Course_CourseId");
            CreateIndex("dbo.EnrollmentCourse", "Enrollment_EnrollmentId");
            AddForeignKey("dbo.StudentEnrollment", "Enrollment_EnrollmentId", "dbo.Enrollment", "EnrollmentId", cascadeDelete: true);
            AddForeignKey("dbo.StudentEnrollment", "Student_Id", "dbo.Student", "Id", cascadeDelete: true);
            AddForeignKey("dbo.EnrollmentCourse", "Course_CourseId", "dbo.Course", "CourseId", cascadeDelete: true);
            AddForeignKey("dbo.EnrollmentCourse", "Enrollment_EnrollmentId", "dbo.Enrollment", "EnrollmentId", cascadeDelete: true);
        }
    }
}
