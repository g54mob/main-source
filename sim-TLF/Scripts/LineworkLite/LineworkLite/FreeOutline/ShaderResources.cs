using System;
using UnityEngine;

namespace LineworkLite.FreeOutline
{
	[Serializable]
	public sealed class ShaderResources
	{
		public Shader mask;

		public Shader outline;

		public Shader clear;

		public ShaderResources Load()
		{
			mask = Shader.Find("Hidden/Outlines/Free Outline/Mask");
			outline = Shader.Find("Hidden/Outlines/Free Outline/Outline");
			clear = Shader.Find("Hidden/Clear Stencil");
			return this;
		}
	}
}
