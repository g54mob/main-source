using UnityEngine;

namespace Assets.Nimbatus.GUI.MissionControl.Scripts.GalaxyMap
{
	public class ZoomDependentScale : MonoBehaviour
	{
		public AnimationCurve ZoomToScaleRadio;

		private Camera _camera;

		private void Start()
		{
			_camera = Camera.main;
		}

		private void Update()
		{
			float num = ZoomToScaleRadio.Evaluate(_camera.orthographicSize);
			base.transform.localScale = new Vector3(num, num, 1f);
		}
	}
}
