using System;
using UnityEngine;

namespace Linework.WideOutline
{
	[Serializable]
	public sealed class ShaderResources
	{
		public Shader mask;

		public Shader silhouette;

		public Shader silhouetteInstanced;

		public Shader outline;

		public ShaderResources Load()
		{
			mask = Shader.Find("Hidden/Outlines/Wide Outline/Mask");
			silhouette = Shader.Find("Hidden/Outlines/Wide Outline/Silhouette");
			silhouetteInstanced = Shader.Find("Hidden/Outlines/Wide Outline/Silhouette Instanced");
			outline = Shader.Find("Hidden/Outlines/Wide Outline/Outline");
			return this;
		}
	}
}
