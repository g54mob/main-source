using System;
using UnityEngine;

namespace Linework.EdgeDetection
{
	[Serializable]
	public sealed class ShaderResources
	{
		public Shader section;

		public Shader outline;

		public ShaderResources Load()
		{
			section = Shader.Find("Hidden/Outlines/Edge Detection/Section");
			outline = Shader.Find("Hidden/Outlines/Edge Detection/Outline");
			return this;
		}
	}
}
