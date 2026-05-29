using System;
using UnityEngine;

namespace CTS
{
	[Serializable]
	public struct CameraMovementStruct
	{
		public bool IsNeedToMove;

		public float speed;

		public Bounds Bounds;
	}
}
