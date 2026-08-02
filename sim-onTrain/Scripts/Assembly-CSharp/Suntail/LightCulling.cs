using UnityEngine;

namespace Suntail
{
	public class LightCulling : MonoBehaviour
	{
		[SerializeField]
		private GameObject playerCamera;

		[SerializeField]
		private float shadowCullingDistance = 15f;

		[SerializeField]
		private float lightCullingDistance = 30f;

		private Light _light;

		public bool enableShadows;

		private void Awake()
		{
			_light = GetComponent<Light>();
		}

		private void Update()
		{
			float num = Vector3.Distance(playerCamera.transform.position, base.gameObject.transform.position);
			if (num <= shadowCullingDistance && enableShadows)
			{
				_light.shadows = LightShadows.Soft;
			}
			else
			{
				_light.shadows = LightShadows.None;
			}
			if (num <= lightCullingDistance)
			{
				_light.enabled = true;
			}
			else
			{
				_light.enabled = false;
			}
		}
	}
}
