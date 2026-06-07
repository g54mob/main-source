using System.Runtime.InteropServices;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public readonly struct PositionNone : IPosition
	{
		public bool HasPosition(GameObject user)
		{
			return false;
		}

		public Vector3 GetPosition(GameObject source)
		{
			return default(Vector3);
		}
	}
}
