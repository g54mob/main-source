using System.Runtime.InteropServices;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public readonly struct RotationNone : IRotation
	{
		public bool HasRotation(GameObject source)
		{
			return false;
		}

		public Quaternion GetRotation(GameObject source)
		{
			return default(Quaternion);
		}
	}
}
