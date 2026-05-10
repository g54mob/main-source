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
			return null;
		}
	}
}
