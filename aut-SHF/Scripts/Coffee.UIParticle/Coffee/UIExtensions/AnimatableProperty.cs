using System;
using UnityEngine;

namespace Coffee.UIExtensions
{
	[Serializable]
	public class AnimatableProperty : ISerializationCallbackReceiver
	{
		public enum ShaderPropertyType
		{
			Color = 0,
			Vector = 1,
			Float = 2,
			Range = 3,
			Texture = 4
		}

		[SerializeField]
		private string m_Name;

		[SerializeField]
		private ShaderPropertyType m_Type;

		public int id { get; private set; }

		public ShaderPropertyType type => default(ShaderPropertyType);

		public void UpdateMaterialProperties(Material material, MaterialPropertyBlock mpb)
		{
		}

		public void OnBeforeSerialize()
		{
		}

		public void OnAfterDeserialize()
		{
		}
	}
}
