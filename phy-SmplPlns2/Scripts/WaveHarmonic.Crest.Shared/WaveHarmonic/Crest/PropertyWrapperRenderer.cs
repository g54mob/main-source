using UnityEngine;

namespace WaveHarmonic.Crest
{
	internal readonly struct PropertyWrapperRenderer : IPropertyWrapper
	{
		public MaterialPropertyBlock PropertyBlock { get; }

		public Renderer Renderer { get; }

		public PropertyWrapperRenderer(Renderer renderer, MaterialPropertyBlock block)
		{
			Renderer = renderer;
			PropertyBlock = block;
		}

		public void SetFloat(int param, float value)
		{
			PropertyBlock.SetFloat(param, value);
		}

		public void SetFloatArray(int param, float[] value)
		{
			PropertyBlock.SetFloatArray(param, value);
		}

		public void SetTexture(int param, Texture value)
		{
			PropertyBlock.SetTexture(param, value);
		}

		public void SetBuffer(int param, ComputeBuffer value)
		{
			PropertyBlock.SetBuffer(param, value);
		}

		public void SetVector(int param, Vector4 value)
		{
			PropertyBlock.SetVector(param, value);
		}

		public void SetVectorArray(int param, Vector4[] value)
		{
			PropertyBlock.SetVectorArray(param, value);
		}

		public void SetMatrix(int param, Matrix4x4 value)
		{
			PropertyBlock.SetMatrix(param, value);
		}

		public void SetInteger(int param, int value)
		{
			PropertyBlock.SetInteger(param, value);
		}

		public void SetBoolean(int param, bool value)
		{
			PropertyBlock.SetFloat(param, value ? 1f : 0f);
		}

		public void GetBlock()
		{
			Renderer.GetPropertyBlock(PropertyBlock);
		}

		public void SetBlock()
		{
			Renderer.SetPropertyBlock(PropertyBlock);
		}
	}
}
