using System;
using System.Collections.Generic;
using UnityEngine;

namespace Coffee.UIEffectInternal
{
	[Serializable]
	public sealed class ShaderVariantRegistry
	{
		[Serializable]
		internal class StringPair : IEquatable<StringPair>
		{
			public string key;

			public string value;

			public bool Equals(StringPair other)
			{
				return false;
			}

			public override bool Equals(object obj)
			{
				return false;
			}

			public override int GetHashCode()
			{
				return 0;
			}
		}

		private Dictionary<int, string> _cachedOptionalShaders;

		[SerializeField]
		private List<StringPair> m_OptionalShaders;

		[SerializeField]
		internal ShaderVariantCollection m_Asset;

		public Func<string, bool> onShaderRequested;

		public ShaderVariantCollection shaderVariantCollection => null;

		public Shader FindOptionalShader(Shader shader, string requiredName, string format, string defaultOptionalShaderName)
		{
			return null;
		}
	}
}
