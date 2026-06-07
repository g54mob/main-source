using System;

namespace Borodar.FarlandSkies.Core.DotParams
{
	[Serializable]
	public abstract class SortedParamsList<T> where T : DotParam
	{
		public T[] Params;

		protected DotParamsList<T> SortedParams;

		public void Init()
		{
		}

		public void Update()
		{
		}
	}
}
