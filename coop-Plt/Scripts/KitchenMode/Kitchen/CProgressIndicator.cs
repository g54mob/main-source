using System;
using Unity.Entities;

namespace Kitchen
{
	[Serializable]
	public struct CProgressIndicator : IComponentData
	{
		public float Progress;

		public bool IsBad;

		public int Process;

		public bool IsUnknownLength;

		public float CurrentChange;
	}
}
