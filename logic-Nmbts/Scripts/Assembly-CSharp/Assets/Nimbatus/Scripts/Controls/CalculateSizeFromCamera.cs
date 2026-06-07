using UnityEngine;

namespace Assets.Nimbatus.Scripts.Controls
{
	public class CalculateSizeFromCamera : MonoBehaviour
	{
		public Camera Camera;

		public bool HasDistanceProperty = true;

		private Renderer _renderer;

		public void Start()
		{
			if (HasDistanceProperty)
			{
				_renderer = GetComponent<Renderer>();
			}
		}

		public void LateUpdate()
		{
			base.transform.localScale = new Vector3(Camera.orthographicSize * 2f, Camera.orthographicSize * 2f, 0f);
			if (HasDistanceProperty)
			{
				_renderer.material.SetFloat("_Distance", StarmapCamera.Instance.ZoomLevel);
			}
		}
	}
}
