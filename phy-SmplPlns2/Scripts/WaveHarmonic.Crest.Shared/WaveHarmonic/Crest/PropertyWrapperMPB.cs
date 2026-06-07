using UnityEngine;

namespace WaveHarmonic.Crest
{
	internal readonly struct PropertyWrapperMPB : IPropertyWrapper
	{
		public MaterialPropertyBlock MaterialPropertyBlock { get; }

		public PropertyWrapperMPB(MaterialPropertyBlock mpb)
		{
			MaterialPropertyBlock = mpb;
		}

		public void SetFloat(int param, float value)
		{
			MaterialPropertyBlock.SetFloat(param, value);
		}

		public void SetFloatArray(int param, float[] value)
		{
			MaterialPropertyBlock.SetFloatArray(param, value);
		}

		public void SetTexture(int param, Texture value)
		{
			MaterialPropertyBlock.SetTexture(param, value);
		}

		public void SetVector(int param, Vector4 value)
		{
			MaterialPropertyBlock.SetVector(param, value);
		}

		public void SetVectorArray(int param, Vector4[] value)
		{
			MaterialPropertyBlock.SetVectorArray(param, value);
		}

		public void SetMatrix(int param, Matrix4x4 value)
		{
			MaterialPropertyBlock.SetMatrix(param, value);
		}

		public void SetInteger(int param, int value)
		{
			MaterialPropertyBlock.SetInteger(param, value);
		}

		public void SetBoolean(int param, bool value)
		{
			MaterialPropertyBlock.SetFloat(param, value ? 1f : 0f);
		}

		public void GetBlock()
		{
		}

		public void SetBlock()
		{
		}
	}
}
