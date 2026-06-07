using System;
using UnityEngine;

namespace Simulator
{
	[Serializable]
	public struct CursorState
	{
		public Texture2D texture;

		public Vector2 hotspot;

		public CursorMode mode;
	}
}
