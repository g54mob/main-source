using UnityEngine;

namespace WaveHarmonic.Crest
{
	internal interface IPropertyWrapper
	{
		void SetFloat(int param, float value);

		void SetFloatArray(int param, float[] value);

		void SetVector(int param, Vector4 value);

		void SetVectorArray(int param, Vector4[] value);

		void SetTexture(int param, Texture value);

		void SetMatrix(int param, Matrix4x4 matrix);

		void SetInteger(int param, int value);

		void SetBoolean(int param, bool value);

		void GetBlock();

		void SetBlock();
	}
}
