using UnityEngine;

namespace Assets.Scripts.Flight.Cameras
{
	public class CameraScript : MonoBehaviour
	{
		protected virtual void OnPostRender()
		{
			Shader.SetGlobalFloat("_ShadowFadeStrength", 0f);
		}

		protected virtual void OnPreRender()
		{
			Shader.SetGlobalFloat("_ShadowFadeStrength", 1f);
		}
	}
}
