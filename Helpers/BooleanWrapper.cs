using ASP.NET_CORE_Course.Models;

namespace ASP.NET_CORE_Course.Helpers
{
    public static class BooleanWrapper
    {
        public static bool IsNull(this ItemModel item)
        {
            return item == null;
        }
    }
}
