using System.Collections.Generic;

namespace Battle
{
	public class FourParamData<T, U, V, W> where T : struct where U : struct where V : struct where W : struct
	{
		public T Item1 { get; set; }

		public U Item2 { get; set; }

		public V Item3 { get; set; }

		public W Item4 { get; set; }

		public FourParamData(List<string> args)
		{
		}

		public FourParamData(List<string> args, int offset)
		{
		}
	}
}
