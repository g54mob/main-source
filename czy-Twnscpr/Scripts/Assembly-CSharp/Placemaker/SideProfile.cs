using System;

namespace Placemaker
{
	[Serializable]
	public struct SideProfile
	{
		public ushort v00;

		public ushort v01;

		public ushort v10;

		public ushort v11;

		public ushort v20;

		public ushort v21;

		public ushort v30;

		public ushort v31;

		public ushort v4;

		public ushort v5;

		public void Set(int index, ushort value0, ushort value1)
		{
		}

		public void Add(SideProfile s)
		{
		}

		public ushort Get0(int index)
		{
			return 0;
		}

		public ushort Get1(int index)
		{
			return 0;
		}

		public bool IsEmtpy()
		{
			return false;
		}

		public override string ToString()
		{
			return null;
		}

		public override int GetHashCode()
		{
			return 0;
		}
	}
}
