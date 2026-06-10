using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

namespace NSMedieval
{
	public class CameraPostProcessInit : MonoBehaviour
	{
		public PostProcessResources postProcessResources;

		private void Start()
		{
			PostProcessLayer component = Camera.main.gameObject.GetComponent<PostProcessLayer>();
			if (component != null)
			{
				component.Init(postProcessResources);
			}
		}
	}
}
