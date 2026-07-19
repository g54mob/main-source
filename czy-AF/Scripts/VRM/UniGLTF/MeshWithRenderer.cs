using System;
using UnityEngine;

namespace UniGLTF
{
	public struct MeshWithRenderer
	{
		public Mesh Mesh;

		public Renderer Renderer;

		[Obsolete("Use Renderer")]
		public Renderer Rendererer
		{
			get
			{
				return Renderer;
			}
			set
			{
				Renderer = value;
			}
		}
	}
}
