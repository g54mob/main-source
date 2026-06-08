using System;
using Unity.Entities;

namespace Kitchen
{
	[Serializable]
	public struct CCaptureInput : IComponentData
	{
		public int UserID;

		public bool AllUsers;
	}
}
