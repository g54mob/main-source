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
			return null;
		}
	}
}
