using System;

namespace Coherence
{
	[Serializable]
	public struct Field
	{
		public enum Type
		{
			Axis2D = 0,
			Button = 1,
			Axis = 2,
			String = 3,
			Axis3D = 4,
			Rotation = 5,
			Integer = 6
		}

		public string name;

		public Type type;
	}
}
