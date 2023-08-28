using ANK13Identity.Areas.Identity.Data;

namespace ANK13Identity.Entities
{
    public class StudentLesson
    {
        public int Id { get; set; }

        public Lesson Lesson { get; set; }

        public int LessonId { get; set; }

        public ANK13IdentityUser User { get; set; }

        public string ANK13IdentityUserId { get; set; }


    }
}
