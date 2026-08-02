namespace CritiasFoliage
{
	public struct FoliageTuple<T>
	{
		public T m_EditTime;

		public T m_RuntimeAppended;

		public FoliageTuple(T editTime)
		{
			m_EditTime = editTime;
			m_RuntimeAppended = default(T);
		}

		public FoliageTuple(T editTime, T runtime)
		{
			m_EditTime = editTime;
			m_RuntimeAppended = runtime;
		}
	}
}
