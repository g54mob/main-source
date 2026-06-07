using System.Collections;
using UnityEngine;

namespace THOR
{
	public class THOR_SheetLightning : MonoBehaviour
	{
		public Material lightningCloudMaterial;

		public MeshRenderer lightningCloudMR;

		private float distance;

		private THOR_Thunderstorm rt;

		private void Awake()
		{
			rt = THOR_Thunderstorm.instance;
			lightningCloudMR.material = lightningCloudMaterial;
			lightningCloudMaterial = lightningCloudMR.material;
			lightningCloudMaterial.SetColor("_ColorCore", rt.colorCloudCore);
			lightningCloudMaterial.SetColor("_ColorGlow", rt.colorCloudGlow);
		}

		private void OnEnable()
		{
			Transform camT = rt.camT;
			Vector3 forward = base.transform.position - camT.position;
			distance = forward.magnitude;
			forward.y = 0f;
			base.transform.forward = forward;
			StartCoroutine(LerpEvolution());
		}

		private IEnumerator LerpEvolution()
		{
			bool flicker = false;
			if (Random.Range(0f, 1f) < rt.flickerProbability)
			{
				flicker = true;
			}
			float distToMultiClouds = rt.distanceToMultiClouds.Evaluate(distance) * 1f;
			lightningCloudMaterial.SetFloat("_Evolution", 0f);
			lightningCloudMaterial.SetFloat("_Angle", Random.Range(0f, 360f));
			lightningCloudMaterial.SetFloat("_Multi", Random.Range(0.05f, 0.2f) * distToMultiClouds);
			base.gameObject.SetActive(value: true);
			float duration = Random.Range(rt.minDuration, rt.maxDuration);
			float tStamp = Time.time;
			while (Time.time - tStamp < duration)
			{
				float value = Mathf.Lerp(0f, 1f, (Time.time - tStamp) / duration);
				lightningCloudMaterial.SetFloat("_Evolution", value);
				if (flicker)
				{
					float value2 = rt.flickerClouds.Evaluate(Time.time + ((Time.timeScale == 0f) ? 0f : Random.Range(0f, 7f))) * distToMultiClouds;
					lightningCloudMaterial.SetFloat("_Multi", value2);
				}
				yield return null;
			}
			base.gameObject.SetActive(value: false);
			rt.BackToPoolSheetLightning(base.gameObject);
		}
	}
}
