using UnityEngine;
using UnityEngine.Rendering;

namespace WaveHarmonic.Crest
{
	internal readonly struct PropertyWrapperMaterial : IPropertyWrapperVariants, IPropertyWrapper
	{
		public Material Material { get; }

		public PropertyWrapperMaterial(Material material)
		{
			Material = material;
		}

		public PropertyWrapperMaterial(Shader shader)
		{
			Material = new Material(shader);
		}

		public PropertyWrapperMaterial(string shaderPath)
		{
			Shader shader = Shader.Find(shaderPath);
			Material = new Material(shader);
		}

		public void SetFloat(int param, float value)
		{
			Material.SetFloat(param, value);
		}

		public void SetFloatArray(int param, float[] value)
		{
			Material.SetFloatArray(param, value);
		}

		public void SetTexture(int param, Texture value)
		{
			Material.SetTexture(param, value);
		}

		public void SetBuffer(int param, ComputeBuffer value)
		{
			Material.SetBuffer(param, value);
		}

		public void SetVector(int param, Vector4 value)
		{
			Material.SetVector(param, value);
		}

		public void SetVectorArray(int param, Vector4[] value)
		{
			Material.SetVectorArray(param, value);
		}

		public void SetMatrix(int param, Matrix4x4 value)
		{
			Material.SetMatrix(param, value);
		}

		public void SetInteger(int param, int value)
		{
			Material.SetInteger(param, value);
		}

		public void SetBoolean(int param, bool value)
		{
			Material.SetFloat(param, value ? 1f : 0f);
		}

		public void GetBlock()
		{
		}

		public void SetBlock()
		{
		}

		public void SetKeyword(in LocalKeyword keyword, bool value)
		{
			Material.SetKeyword(in keyword, value);
		}

		void IPropertyWrapperVariants.SetKeyword(in LocalKeyword keyword, bool value)
		{
			SetKeyword(in keyword, value);
		}
	}
}
