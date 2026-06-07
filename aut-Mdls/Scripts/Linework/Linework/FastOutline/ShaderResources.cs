using System;
using UnityEngine;

namespace Linework.FastOutline
{
	[Serializable]
	public sealed class ShaderResources
	{
		public Shader mask;

		public Shader outline;

		public Shader outlineInstanced;

		public Shader clear;

		public ShaderResources Load()
		{
			mask = Shader.Find("Hidden/Outlines/Fast Outline/Mask");
			outline = Shader.Find("Hidden/Outlines/Fast Outline/Outline");
			outlineInstanced = Shader.Find("Hidden/Outlines/Fast Outline/Outline Instanced");
			clear = Shader.Find("Hidden/Clear Stencil");
			return this;
		}
	}
}
