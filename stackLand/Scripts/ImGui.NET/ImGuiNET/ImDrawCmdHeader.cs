using System;
using UnityEngine;

namespace ImGuiNET
{
	public struct ImDrawCmdHeader
	{
		public Vector4 ClipRect;

		public IntPtr TextureId;

		public uint VtxOffset;
	}
}
