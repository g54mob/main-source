using UnityEngine;
using UnityEngine.Rendering;

namespace Placemaker
{
	public class ShadowBakerCamera : MonoBehaviour
	{
		[SerializeField]
		private Camera cam;

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void AfterCameraRender(ScriptableRenderContext context, Camera camera)
		{
		}
	}
}
