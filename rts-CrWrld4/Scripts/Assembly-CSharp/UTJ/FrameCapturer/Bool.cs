using System;
using UnityEngine;

namespace UTJ.FrameCapturer
{
	[Serializable]
	public struct Bool
	{
		[SerializeField]
		private byte v;

		public static Bool True => default(Bool);

		public static implicit operator bool(Bool v)
		{
			return false;
		}

		public static implicit operator Bool(bool v)
		{
			return default(Bool);
		}
	}
}
