using UnityEngine;
using UnityEngine.Rendering;

namespace WaveHarmonic.Crest
{
	internal readonly struct PropertyWrapperCompute : IPropertyWrapperVariants, IPropertyWrapper
	{
		private readonly CommandBuffer _Buffer;

		private readonly ComputeShader _Shader;

		private readonly int _Kernel;

		public PropertyWrapperCompute(CommandBuffer buffer, ComputeShader shader, int kernel)
		{
			_Buffer = buffer;
			_Shader = shader;
			_Kernel = kernel;
		}

		public void SetFloat(int param, float value)
		{
			_Buffer.SetComputeFloatParam(_Shader, param, value);
		}

		public void SetFloatArray(int param, float[] value)
		{
			_Buffer.SetGlobalFloatArray(param, value);
		}

		public void SetInteger(int param, int value)
		{
			_Buffer.SetComputeIntParam(_Shader, param, value);
		}

		public void SetIntegers(int param, params int[] value)
		{
			_Buffer.SetComputeIntParams(_Shader, param, value);
		}

		public void SetBoolean(int param, bool value)
		{
			_Buffer.SetComputeFloatParam(_Shader, param, value ? 1f : 0f);
		}

		public void SetTexture(int param, Texture value)
		{
			_Buffer.SetComputeTextureParam(_Shader, _Kernel, param, value);
		}

		public void SetTexture(int param, RenderTargetIdentifier value)
		{
			_Buffer.SetComputeTextureParam(_Shader, _Kernel, param, value);
		}

		public void SetBuffer(int param, ComputeBuffer value)
		{
			_Buffer.SetComputeBufferParam(_Shader, _Kernel, param, value);
		}

		public void SetVector(int param, Vector4 value)
		{
			_Buffer.SetComputeVectorParam(_Shader, param, value);
		}

		public void SetVectorArray(int param, Vector4[] value)
		{
			_Buffer.SetComputeVectorArrayParam(_Shader, param, value);
		}

		public void SetMatrix(int param, Matrix4x4 value)
		{
			_Buffer.SetComputeMatrixParam(_Shader, param, value);
		}

		public void GetBlock()
		{
		}

		public void SetBlock()
		{
		}

		public void SetKeyword(in LocalKeyword keyword, bool value)
		{
			_Buffer.SetKeyword(_Shader, in keyword, value);
		}

		public void Dispatch(int x, int y, int z)
		{
			_Buffer.DispatchCompute(_Shader, _Kernel, x, y, z);
		}

		void IPropertyWrapperVariants.SetKeyword(in LocalKeyword keyword, bool value)
		{
			SetKeyword(in keyword, value);
		}
	}
}
