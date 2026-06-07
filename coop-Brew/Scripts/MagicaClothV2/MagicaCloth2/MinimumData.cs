namespace MagicaCloth2
{
	public class MinimumData<T1, T2> where T1 : struct where T2 : struct
	{
		private T1 minDist;

		private T2 minData;

		private bool isValid;

		public bool IsValid => false;

		public T1 MinDistance => default(T1);

		public T2 MinData => default(T2);

		public void Add(T1 distance, T2 data)
		{
		}

		public void Clear()
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
