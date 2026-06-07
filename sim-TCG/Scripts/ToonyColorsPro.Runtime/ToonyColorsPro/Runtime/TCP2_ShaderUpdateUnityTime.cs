using UnityEngine;

namespace ToonyColorsPro.Runtime
{
	public class TCP2_ShaderUpdateUnityTime : MonoBehaviour
	{
		private static readonly int UnityTime = Shader.PropertyToID("unityTime");

		private static readonly int CustomTime = Shader.PropertyToID("_CustomTime");

		private void LateUpdate()
		{
			Shader.SetGlobalFloat(UnityTime, Time.time);
			Shader.SetGlobalVector(CustomTime, new Vector4(Time.time / 20f, Time.time, Time.time * 2f, Time.time * 3f));
		}
	}
}
