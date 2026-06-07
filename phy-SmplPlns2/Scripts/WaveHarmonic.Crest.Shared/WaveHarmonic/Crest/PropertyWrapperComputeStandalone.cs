using UnityEngine;
using UnityEngine.Rendering;

namespace WaveHarmonic.Crest
{
	internal readonly struct PropertyWrapperComputeStandalone : IPropertyWrapperVariants, IPropertyWrapper
	{
		private readonly ComputeShader _Shader;

		private readonly int _Kernel;

		public PropertyWrapperComputeStandalone(ComputeShader shader, int kernel)
		{
			_Shader = shader;
			_Kernel = kernel;
		}

		public void SetFloat(int param, float value)
		{
			_Shader.SetFloat(param, value);
		}

		public void SetFloatArray(int param, float[] value)
		{
			_Shader.SetFloats(param, value);
		}

		public void SetInteger(int param, int value)
		{
			_Shader.SetInt(param, value);
		}

		public void SetBoolean(int param, bool value)
		{
			_Shader.SetFloat(param, value ? 1f : 0f);
		}

		public void SetTexture(int param, Texture value)
		{
			_Shader.SetTexture(_Kernel, param, value);
		}

		public void SetBuffer(int param, ComputeBuffer value)
		{
			_Shader.SetBuffer(_Kernel, param, value);
		}

		public void SetConstantBuffer(int param, ComputeBuffer value)
		{
			_Shader.SetConstantBuffer(param, value, 0, value.stride);
		}

		public void SetVector(int param, Vector4 value)
		{
			_Shader.SetVector(param, value);
		}

		public void SetVectorArray(int param, Vector4[] value)
		{
			_Shader.SetVectorArray(param, value);
		}

		public void SetMatrix(int param, Matrix4x4 value)
		{
			_Shader.SetMatrix(param, value);
		}

		public void GetBlock()
		{
		}

		public void SetBlock()
		{
		}

		public void SetKeyword(in LocalKeyword keyword, bool value)
		{
			_Shader.SetKeyword(in keyword, value);
		}

		public void Dispatch(int x, int y, int z)
		{
			_Shader.Dispatch(_Kernel, x, y, z);
		}

		void IPropertyWrapperVariants.SetKeyword(in LocalKeyword keyword, bool value)
		{
			SetKeyword(in keyword, value);
		}
	}
}
