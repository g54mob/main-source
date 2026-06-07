using PlaceholderSoftware.WetStuff;
using UnityEngine;

namespace DV.Rain
{
	public class CabinDryVolume : MonoBehaviour
	{
		public WetDecal[] subVolumes;

		public float distance;

		public float edgeFadeOffInside = 0.05f;

		public float edgeFadeOffOutside = 1f;

		private WetDecal decal;

		private void Start()
		{
			decal = GetComponent<WetDecal>();
			if (!decal)
			{
				Debug.Log("Missing WetDecal Component!");
				Object.Destroy(this);
			}
		}

		private void LateUpdate()
		{
			Camera activeCamera = PlayerManager.ActiveCamera;
			if ((bool)activeCamera)
			{
				Vector3 vector = base.transform.InverseTransformPoint(activeCamera.transform.position);
				float value = Mathf.Max(Mathf.Max(Mathf.Abs(vector.x), Mathf.Abs(vector.y)), Mathf.Abs(vector.z));
				float num = Mathf.InverseLerp(0.5f, 0.5f - distance, value);
				decal.Settings.EdgeFadeoff = Mathf.Lerp(edgeFadeOffOutside, edgeFadeOffInside, num);
				WetDecal[] array = subVolumes;
				for (int i = 0; i < array.Length; i++)
				{
					array[i].Settings.Saturation = num;
				}
			}
		}
	}
}
