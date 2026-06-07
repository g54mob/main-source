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
		private string m_Name = "";

		[SerializeField]
		private ShaderPropertyType m_Type = ShaderPropertyType.Vector;

		public int id { get; private set; }

		public ShaderPropertyType type => m_Type;

		void ISerializationCallbackReceiver.OnBeforeSerialize()
		{
		}

		void ISerializationCallbackReceiver.OnAfterDeserialize()
		{
			id = Shader.PropertyToID(m_Name);
		}

		public void UpdateMaterialProperties(Material material, MaterialPropertyBlock mpb)
		{
			if (!material.HasProperty(id))
			{
				return;
			}
			switch (type)
			{
			case ShaderPropertyType.Color:
			{
				Color color = mpb.GetColor(id);
				if (color != default(Color))
				{
					material.SetColor(id, color);
				}
				break;
			}
			case ShaderPropertyType.Vector:
			{
				Vector4 vector = mpb.GetVector(id);
				if (vector != default(Vector4))
				{
					material.SetVector(id, vector);
				}
				break;
			}
			case ShaderPropertyType.Float:
			case ShaderPropertyType.Range:
			{
				float num = mpb.GetFloat(id);
				if (!Mathf.Approximately(num, 0f))
				{
					material.SetFloat(id, num);
				}
				break;
			}
			case ShaderPropertyType.Texture:
			{
				Texture texture = mpb.GetTexture(id);
				if (texture != null)
				{
					material.SetTexture(id, texture);
				}
				break;
			}
			}
		}
	}
}
