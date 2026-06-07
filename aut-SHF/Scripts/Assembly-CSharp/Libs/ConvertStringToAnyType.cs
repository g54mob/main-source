using System.Collections.Generic;

namespace Libs
{
	public class ConvertStringToAnyType
	{
		public static Z ToAnyType<Z>(string arg) where Z : struct
		{
			return default(Z);
		}

		public static List<(T, string)> GetGeneralTupleList<T>(List<string> param) where T : struct
		{
			return null;
		}

		public static List<(T, U)> GetGeneralTupleList<T, U>(List<string> param) where T : struct where U : struct
		{
			return null;
		}
	}
}
