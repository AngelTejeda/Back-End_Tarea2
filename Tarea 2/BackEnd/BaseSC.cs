using Tarea_2.DataAccess;

namespace Tarea_2.BackEnd
{
    class BaseSC
    {
        protected NorthwindContext dbContext = new NorthwindContext();
    }
}