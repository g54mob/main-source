using UnityEngine;
using UnityEngine.Rendering;

namespace WaveHarmonic.Crest
{
	internal readonly struct PropertyWrapperBuffer : IPropertyWrapper
	{
		public CommandBuffer Buffer { get; }

		public PropertyWrapperBuffer(CommandBuffer mpb)
		{
			Buffer = mpb;
		}

		public void SetFloat(int param, float value)
		{
			Buffer.SetGlobalFloat(param, value);
		}

		public void SetFloatArray(int param, float[] value)
		{
			Buffer.SetGlobalFloatArray(param, value);
		}

		public void SetTexture(int param, Texture value)
		{
			Buffer.SetGlobalTexture(param, value);
		}

		public void SetVector(int param, Vector4 value)
		{
			Buffer.SetGlobalVector(param, value);
		}

		public void SetVectorArray(int param, Vector4[] value)
		{
			Buffer.SetGlobalVectorArray(param, value);
		}

		public void SetMatrix(int param, Matrix4x4 value)
		{
			Buffer.SetGlobalMatrix(param, value);
		}

		public void SetInteger(int param, int value)
		{
			Buffer.SetGlobalInteger(param, value);
		}

		public void SetBoolean(int param, bool value)
		{
			Buffer.SetGlobalFloat(param, value ? 1f : 0f);
		}

		public void GetBlock()
		{
		}

		public void SetBlock()
		{
		}
	}
}
