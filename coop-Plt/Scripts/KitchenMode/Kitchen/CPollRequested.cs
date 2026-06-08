using System;
using Unity.Entities;

namespace Kitchen
{
	[Serializable]
	public struct CPollRequested : IComponentData
	{
		public int Index;

		public int Votes;

		public bool IsComplete;

		public bool IsForced;

		public float PollProgress;
	}
}
