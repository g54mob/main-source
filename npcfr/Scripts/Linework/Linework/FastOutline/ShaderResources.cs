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
			return null;
		}
	}
}
