using Unity.Entities;

namespace Kitchen
{
	public static class QueryHelperExtensions
	{
		public static QueryHelper Query(this SystemBase system)
		{
			return new QueryHelper();
		}
	}
}
