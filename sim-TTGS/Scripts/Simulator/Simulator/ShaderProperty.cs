using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Rendering;

namespace Simulator
{
	[Serializable]
	public struct ShaderProperty
	{
		[SerializeField]
		private MeshRenderer m_meshRenderer;

		[SerializeField]
		private int m_materialIndex;

		[SerializeField]
		private string m_name;

		[SerializeField]
		private ShaderPropertyType m_type;

		private Material m_material;

		private int m_id;

		public Material Material => GetMaterial();

		public ShaderPropertyType Type => m_type;

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private int GetId()
		{
			if (!IsIdValid())
			{
				m_id = Shader.PropertyToID(m_name);
			}
			return m_id;
		}

		private bool IsIdValid()
		{
			return m_id != 0;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private Material GetMaterial()
		{
			if (!IsMaterialValid())
			{
				m_material = m_meshRenderer.materials[m_materialIndex];
			}
			return m_material;
		}

		private bool IsMaterialValid()
		{
			return m_material != null;
		}

		public void SetFloat(float value)
		{
			GetMaterial().SetFloat(GetId(), value);
		}

		public void SetInteger(int value)
		{
			GetMaterial().SetInteger(GetId(), value);
		}

		public void SetColor(Color value)
		{
			GetMaterial().SetColor(GetId(), value);
		}

		public void SetVector(Vector4 value)
		{
			GetMaterial().SetVector(GetId(), value);
		}

		public void SetMatrix(Matrix4x4 value)
		{
			GetMaterial().SetMatrix(GetId(), value);
		}

		public void SetTexture(Texture value)
		{
			GetMaterial().SetTexture(GetId(), value);
		}
	}
}
