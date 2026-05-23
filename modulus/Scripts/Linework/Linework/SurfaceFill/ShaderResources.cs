using System;
using UnityEngine;

namespace Linework.SurfaceFill
{
	[Serializable]
	public sealed class ShaderResources
	{
		public Shader mask;

		public Shader fill;

		public ShaderResources Load()
		{
			mask = Shader.Find("Hidden/Outlines/Surface Fill/Mask");
			fill = Shader.Find("Hidden/Outlines/Fill");
			return this;
		}
	}
}
