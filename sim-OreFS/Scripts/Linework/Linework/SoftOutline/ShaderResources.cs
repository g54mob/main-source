using System;
using UnityEngine;

namespace Linework.SoftOutline
{
	[Serializable]
	public sealed class ShaderResources
	{
		public Shader mask;

		public Shader silhouette;

		public Shader silhouetteInstanced;

		public Shader boxBlur;

		public Shader gaussianBlur;

		public Shader kawaseBlur;

		public Shader dilate;

		public Shader outline;

		public ShaderResources Load()
		{
			mask = Shader.Find("Hidden/Outlines/Soft Outline/Mask");
			silhouette = Shader.Find("Hidden/Outlines/Soft Outline/Silhouette");
			silhouetteInstanced = Shader.Find("Hidden/Outlines/Soft Outline/Silhouette Instanced");
			boxBlur = Shader.Find("Hidden/Outlines/Soft Outline/Box Blur");
			gaussianBlur = Shader.Find("Hidden/Outlines/Soft Outline/Gaussian Blur");
			kawaseBlur = Shader.Find("Hidden/Outlines/Soft Outline/Kawase Blur");
			dilate = Shader.Find("Hidden/Outlines/Soft Outline/Dilate");
			outline = Shader.Find("Hidden/Outlines/Soft Outline/Outline");
			return this;
		}
	}
}
