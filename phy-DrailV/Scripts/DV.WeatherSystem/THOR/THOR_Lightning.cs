using System.Collections;
using UnityEngine;

namespace THOR
{
	public class THOR_Lightning : MonoBehaviour
	{
		public Transform lightningBoltT;

		public Transform lightningCloudT;

		public Transform spotLightT;

		public MeshFilter lightningBoltMF;

		public MeshRenderer lightningBoltMR;

		public MeshRenderer lightningCloudMR;

		public Material lightningBoltMaterial;

		public Material lightningCloudMaterial;

		public AudioSource audioSource;

		public Light spotLight;

		private THOR_Thunderstorm rt;

		private Transform t;

		private Vector3 initScale;

		private float lightdist;

		private float duration = 1f;

		private float distance;

		private float distanceFlat;

		private float pan;

		private bool noSound;

		private Coroutine coro;

		private void Awake()
		{
			rt = THOR_Thunderstorm.instance;
			t = base.transform;
			initScale = t.localScale;
			lightningCloudMR.material = lightningCloudMaterial;
			lightningCloudMaterial = lightningCloudMR.material;
			lightningBoltMR.material = lightningBoltMaterial;
			lightningBoltMaterial = lightningBoltMR.material;
			lightningBoltT.gameObject.SetActive(value: false);
			lightningCloudT.gameObject.SetActive(value: false);
			audioSource.outputAudioMixerGroup = rt.audioMixerGroup;
			lightningCloudMaterial.SetColor("_ColorCore", rt.colorCloudCore);
			lightningCloudMaterial.SetColor("_ColorGlow", rt.colorCloudGlow);
			lightningBoltMaterial.SetColor("_ColorCore", rt.colorLightningCore);
			lightningBoltMaterial.SetColor("_ColorGlow", rt.colorLightningGlow);
			if (rt.enableDepthBlending)
			{
				lightningBoltMaterial.SetFloat("_EnableDepthBlend", 1f);
			}
			else
			{
				lightningBoltMaterial.SetFloat("_EnableDepthBlend", 0f);
			}
			lightningBoltMaterial.SetFloat("_DepthBlend", rt.depthBlend);
		}

		private void OnEnable()
		{
			Transform camT = rt.camT;
			Vector3 vector = camT.position - t.position;
			Vector3 vector2 = new Vector3(vector.x, 0f, vector.z);
			distance = vector.magnitude;
			distanceFlat = Vector3.Distance(camT.position, new Vector3(t.position.x, camT.position.y, t.position.z));
			pan = Vector3.Dot((-camT.right).normalized, vector.normalized);
			lightningCloudT.forward = -vector2;
			lightningBoltT.forward = -((vector + vector2) * 0.5f);
			if (rt.useLight)
			{
				spotLightT.forward = vector;
			}
			if (distance > rt.spawnHeight)
			{
				lightningBoltT.localEulerAngles = new Vector3(lightningBoltT.localEulerAngles.x, lightningBoltT.localEulerAngles.y, Random.Range(-60, 60));
			}
			if (Random.Range(0f, 1f) > 0.5f)
			{
				lightningBoltT.localScale = new Vector3(0f - lightningBoltT.localScale.x, lightningBoltT.localScale.y, lightningBoltT.localScale.z);
			}
			t.localScale = initScale * Random.Range(0.75f, 1.25f);
			lightningBoltMF.mesh = rt.lightningBoltMeshes[Random.Range(0, rt.lightningBoltMeshes.Length - 1)];
			coro = StartCoroutine(LerpEvolution());
			if (distanceFlat > rt.thunderFarDistance)
			{
				noSound = true;
				return;
			}
			noSound = false;
			StartCoroutine(LerpAudio());
		}

		private IEnumerator LerpEvolution()
		{
			float distToMultiClouds = rt.distanceToMultiClouds.Evaluate(distanceFlat);
			float distToMultiBolts = rt.distanceToMultiBolts.Evaluate(distanceFlat);
			bool flicker = false;
			if (Random.Range(0f, 1f) < rt.flickerProbability)
			{
				flicker = true;
			}
			lightningCloudMaterial.SetFloat("_Evolution", 0f);
			lightningCloudMaterial.SetFloat("_Angle", Random.Range(0f, 360f));
			lightningCloudMaterial.SetFloat("_Multi", distToMultiClouds);
			lightningBoltMaterial.SetFloat("_Evolution", 0f);
			lightningBoltMaterial.SetFloat("_Multi", distToMultiBolts);
			lightningBoltT.gameObject.SetActive(value: true);
			lightningCloudT.gameObject.SetActive(value: true);
			if (rt.useLight && distance < rt.maxLightDistance)
			{
				spotLight.intensity = 0f;
				rt.lightIsActive = true;
			}
			duration = Random.Range(rt.minDuration, rt.maxDuration);
			lightdist = rt.lightDistanceCurve.Evaluate(distanceFlat);
			float tStamp = Time.time;
			while (Time.time - tStamp < duration)
			{
				float num = Mathf.Lerp(0f, 1f, (Time.time - tStamp) / duration);
				lightningCloudMaterial.SetFloat("_Evolution", num);
				lightningBoltMaterial.SetFloat("_Evolution", num);
				if (rt.useLight)
				{
					spotLight.color = rt.lightColor.Evaluate(num);
					spotLight.intensity = rt.lightIntensityCurve.Evaluate(num) * lightdist * rt.lightIntensityMulti;
				}
				if (flicker)
				{
					float value = rt.flickerClouds.Evaluate(Time.time + ((Time.timeScale == 0f) ? 0f : Random.Range(0f, 7f))) * distToMultiClouds;
					float value2 = rt.flickerBolts.Evaluate(Time.time + ((Time.timeScale == 0f) ? 0f : Random.Range(0f, 7f))) * distToMultiBolts;
					lightningCloudMaterial.SetFloat("_Multi", value);
					lightningBoltMaterial.SetFloat("_Multi", value2);
					if (rt.useLight)
					{
						spotLight.intensity *= Mathf.Clamp01(value2);
					}
				}
				yield return null;
			}
			lightningBoltT.gameObject.SetActive(value: false);
			lightningCloudT.gameObject.SetActive(value: false);
			rt.lightIsActive = false;
			spotLight.intensity = 0f;
			if (noSound)
			{
				base.gameObject.SetActive(value: false);
				rt.BackToPool(base.gameObject);
			}
			coro = null;
		}

		private IEnumerator LerpAudio()
		{
			if (distanceFlat < rt.thunderVeryCloseDistance)
			{
				audioSource.clip = rt.thunderClipsVeryClose[Random.Range(0, rt.thunderClipsVeryClose.Length - 1)];
			}
			else if (distanceFlat < rt.thunderCloseDistance)
			{
				audioSource.clip = rt.thunderClipsClose[Random.Range(0, rt.thunderClipsClose.Length - 1)];
			}
			else if (distanceFlat < rt.thunderMediumDistance)
			{
				audioSource.clip = rt.thunderClipsMedium[Random.Range(0, rt.thunderClipsMedium.Length - 1)];
			}
			else
			{
				audioSource.clip = rt.thunderClipsFar[Random.Range(0, rt.thunderClipsFar.Length - 1)];
			}
			float volumeDistanceMulti = rt.distanceToVolume.Evaluate(distanceFlat);
			float randomPitch = Random.Range(0.9f, 1.1f);
			audioSource.panStereo = pan;
			yield return new WaitForSeconds(distanceFlat * 0.5f / rt.SpeedOfSound);
			if (rt.fadeUp == null)
			{
				rt.fadeUp = rt.FadeUp();
				if (rt.gameObject.activeInHierarchy)
				{
					StartCoroutine(rt.fadeUp);
				}
			}
			audioSource.enabled = true;
			audioSource.volume = volumeDistanceMulti * rt.audioFade.Evaluate(0f);
			audioSource.Play();
			float tStamp = Time.time;
			while (audioSource.volume > 0f && audioSource.isPlaying)
			{
				audioSource.volume = volumeDistanceMulti * rt.audioFade.Evaluate((Time.time - tStamp) * (1f + rt.probability));
				audioSource.panStereo = pan * rt.panMulti.Evaluate(Time.time - tStamp);
				audioSource.pitch = randomPitch * Time.timeScale;
				yield return null;
			}
			while (coro != null)
			{
				yield return null;
			}
			BackToPool();
		}

		private void BackToPool()
		{
			audioSource.Stop();
			audioSource.enabled = false;
			base.gameObject.SetActive(value: false);
			rt.BackToPool(base.gameObject);
		}
	}
}
