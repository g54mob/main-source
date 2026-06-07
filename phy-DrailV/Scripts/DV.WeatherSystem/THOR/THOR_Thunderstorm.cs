using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;

namespace THOR
{
	public class THOR_Thunderstorm : MonoBehaviour
	{
		public static THOR_Thunderstorm instance;

		public Camera cam;

		public Transform camT;

		public Light light;

		private bool followCamera = true;

		private bool followCameraVertically;

		[Range(0f, 1f)]
		public float probability;

		[Range(0f, 1f)]
		public float flickerProbability = 0.5f;

		[Range(0f, 1f)]
		public float preferCameraView = 0.6f;

		public float minDuration = 0.4f;

		public float maxDuration = 0.8f;

		[ColorUsage(false)]
		public Color colorLightningCore;

		[ColorUsage(false)]
		public Color colorLightningGlow;

		[ColorUsage(false)]
		public Color colorCloudCore;

		[ColorUsage(false)]
		public Color colorCloudGlow;

		public float minDistance = 300f;

		public float maxDistance = 4000f;

		public float spawnHeight = 600f;

		public float scaleMulti = 1.5f;

		public bool enableDepthBlending;

		public float depthBlend = 1000f;

		public AnimationCurve distanceToMultiBolts = new AnimationCurve(new Keyframe(0f, 1f), new Keyframe(4000f, 0.1f));

		public AnimationCurve distanceToMultiClouds = new AnimationCurve(new Keyframe(0f, 1f), new Keyframe(4000f, 0.1f));

		public AnimationCurve flickerBolts = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(0.05f, 1f), new Keyframe(0.1f, 0f), new Keyframe(0.15f, 1f), new Keyframe(0.2f, 0f), new Keyframe(0.25f, 1f), new Keyframe(0.3f, 0f));

		public AnimationCurve flickerClouds = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(0.05f, 1f), new Keyframe(0.1f, 0f), new Keyframe(0.15f, 1f), new Keyframe(0.2f, 0f), new Keyframe(0.25f, 1f), new Keyframe(0.3f, 0f));

		public bool useLight = true;

		public float lightIntensityMulti = 1f;

		public Gradient lightColor = new Gradient();

		public float maxLightDistance = 2000f;

		public AnimationCurve lightIntensityCurve = new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(0.3f, 4f), new Keyframe(1f, 0f));

		public AnimationCurve lightDistanceCurve = new AnimationCurve(new Keyframe(0f, 1f), new Keyframe(2000f, 0f, -0.0015f, 0f));

		public float lightRange = 2500f;

		[Range(1f, 179f)]
		public float lightAngle = 15f;

		public Texture lightCookie;

		public LightShadows lightShadows = LightShadows.Soft;

		public LightShadowResolution shadowResolution = LightShadowResolution.VeryHigh;

		[Range(0f, 1f)]
		public float shadowStrength = 1f;

		[Range(0f, 2f)]
		public float shadowBias = 0.01f;

		[Range(0f, 3f)]
		public float shadowNormalBias = 0.4f;

		[Range(0.1f, 10f)]
		public float shadowNearPlane = 10f;

		public AudioClip thunderLoop;

		public AnimationCurve thunderLoopVolume = new AnimationCurve(new Keyframe(0f, 0.4f), new Keyframe(1f, 1f));

		public AudioClip[] thunderClipsVeryClose;

		public float thunderVeryCloseDistance = 600f;

		public AudioClip[] thunderClipsClose;

		public float thunderCloseDistance = 900f;

		public AudioClip[] thunderClipsMedium;

		public float thunderMediumDistance = 1200f;

		public AudioClip[] thunderClipsFar;

		public float thunderFarDistance = 3000f;

		public AnimationCurve distanceToVolume = new AnimationCurve(new Keyframe(500f, 1f), new Keyframe(600f, 0.65f, -0.0002f, -0.0002f), new Keyframe(1500f, 0.4f, -0.0003f, -0.0003f));

		public AnimationCurve audioFade = new AnimationCurve(new Keyframe(0f, 1f), new Keyframe(2f, 0f));

		public AnimationCurve panMulti = new AnimationCurve(new Keyframe(0f, 1f), new Keyframe(0.5f, 0f));

		public float SpeedOfSound = 680f;

		public float lerpSpeedUp = 1f;

		public float lerpSpeedDown = 8f;

		public AudioMixerGroup audioMixerGroup;

		public GameObject R_LightningPrefab;

		public int poolSize = 20;

		public List<GameObject> poolUnused = new List<GameObject>();

		public List<GameObject> poolUsed = new List<GameObject>();

		public GameObject R_SheetLightningPrefab;

		public int poolSizeSheetLightning = 5;

		public List<GameObject> poolSheetLightningUnused = new List<GameObject>();

		public List<GameObject> poolSheetLightningUsed = new List<GameObject>();

		public int layer;

		public Mesh[] lightningBoltMeshes;

		public Vector2 lightningDelayMin = new Vector2(3f, 0.05f);

		public Vector2 lightningDelayMax = new Vector2(10f, 0.4f);

		[HideInInspector]
		public bool lightIsActive;

		private Vector3 spawnPos;

		private Vector3 camPos;

		private float nextLightningIn;

		private float nextSheetLightningIn;

		private float timeSinceLastLightning;

		private float timeSinceLastSheetLightning;

		private AudioSource aS;

		private float loopVol;

		public IEnumerator fadeUp;

		private IEnumerator fadeDown;

		public IEnumerator ctrlThunderstorm;

		private THOR_Thunderstorm()
		{
			instance = this;
			if (instance.ctrlThunderstorm != null)
			{
				instance.StopCoroutine(instance.ctrlThunderstorm);
				instance.ctrlThunderstorm = null;
			}
			if (fadeDown != null)
			{
				StopCoroutine(fadeDown);
				fadeDown = null;
			}
			if (fadeUp != null)
			{
				StopCoroutine(fadeUp);
				fadeUp = null;
			}
		}

		private void Awake()
		{
			if (instance != null && instance != this)
			{
				Object.Destroy(instance);
			}
			instance = this;
		}

		private void Start()
		{
			aS = base.gameObject.AddComponent<AudioSource>();
			aS.hideFlags = HideFlags.HideInInspector;
			aS.clip = thunderLoop;
			aS.loop = true;
			aS.playOnAwake = false;
			aS.volume = 0f;
			aS.spatialBlend = 0f;
			aS.enabled = false;
			aS.outputAudioMixerGroup = audioMixerGroup;
			poolUsed.Clear();
			poolUnused.Clear();
			poolSheetLightningUsed.Clear();
			poolSheetLightningUnused.Clear();
			if (!light)
			{
				useLight = false;
			}
			for (int i = 0; i < poolSize; i++)
			{
				GameObject gameObject = Object.Instantiate(R_LightningPrefab);
				gameObject.layer = layer;
				Transform obj = gameObject.transform;
				obj.parent = base.transform;
				obj.localScale = new Vector3(spawnHeight, spawnHeight, spawnHeight) * scaleMulti;
				poolUnused.Add(gameObject);
				if ((bool)light)
				{
					gameObject.GetComponent<THOR_Lightning>().spotLight = light;
					gameObject.GetComponent<THOR_Lightning>().spotLightT = light.transform;
				}
				GameObject gameObject2 = obj.Find("Spotlight").gameObject;
				if (!useLight)
				{
					Object.Destroy(gameObject2);
					continue;
				}
				Light component = gameObject2.GetComponent<Light>();
				component.color = lightColor.Evaluate(0f);
				component.range = lightRange;
				component.spotAngle = lightAngle;
				component.cookie = lightCookie;
				component.shadows = lightShadows;
				if (lightShadows != LightShadows.None)
				{
					component.shadowResolution = shadowResolution;
					component.shadowStrength = shadowStrength;
					component.shadowBias = shadowBias;
					component.shadowNormalBias = shadowNormalBias;
					component.shadowNearPlane = shadowNearPlane;
				}
			}
			for (int j = 0; j < poolSizeSheetLightning; j++)
			{
				GameObject gameObject3 = Object.Instantiate(R_SheetLightningPrefab);
				gameObject3.layer = layer;
				gameObject3.transform.parent = base.transform;
				gameObject3.transform.localScale = new Vector3(spawnHeight, spawnHeight, spawnHeight) * scaleMulti * 1.5f;
				poolSheetLightningUnused.Add(gameObject3);
			}
		}

		private void OnDestroy()
		{
			instance = null;
		}

		private float EvaluateDelay(float probability)
		{
			float min = Mathf.Lerp(lightningDelayMin.x, lightningDelayMin.y, probability);
			float max = Mathf.Lerp(lightningDelayMax.x, lightningDelayMax.y, probability);
			return Random.Range(min, max);
		}

		private void LateUpdate()
		{
			if (cam == null)
			{
				cam = Camera.main;
			}
			if (cam == null)
			{
				return;
			}
			camT = cam.transform;
			if (probability == 0f)
			{
				if (aS.enabled)
				{
					aS.Stop();
					aS.enabled = false;
					StopAllCoroutines();
					fadeUp = null;
					fadeDown = null;
				}
				return;
			}
			if (!aS.enabled)
			{
				aS.enabled = true;
				aS.Play();
			}
			aS.volume = loopVol * thunderLoopVolume.Evaluate(probability);
			aS.pitch = ((0.9f + probability * 0.2f) * (loopVol * 0.5f) + 0.75f) * Time.timeScale;
			if (Time.time - timeSinceLastSheetLightning > nextSheetLightningIn && poolSheetLightningUnused.Count > 0)
			{
				SheetLightning();
			}
			if (!(Time.time - timeSinceLastLightning < nextLightningIn) && !lightIsActive && poolUnused.Count != 0)
			{
				Lightning();
			}
		}

		private void Lightning()
		{
			camPos = camT.position;
			if (Random.Range(0f, 1f) <= preferCameraView)
			{
				CameraLightning();
			}
			else
			{
				RandomPosLightning();
			}
			timeSinceLastLightning = Time.time;
			nextLightningIn = EvaluateDelay(probability);
		}

		private void CameraLightning()
		{
			Vector3 vector = cam.ViewportToWorldPoint(new Vector3(Random.Range(0f, 1f), 0.5f, 100f));
			vector.y = camPos.y;
			spawnPos = (vector - camPos).normalized * Random.Range(minDistance, maxDistance);
			spawnPos.y = spawnHeight;
			ActivateLightning();
		}

		private void RandomPosLightning()
		{
			Vector2 vector = Random.insideUnitCircle * maxDistance;
			spawnPos = new Vector3(vector.x, spawnHeight, vector.y);
			camPos.y = spawnHeight;
			if ((spawnPos - camPos).magnitude < minDistance)
			{
				RandomPosLightning();
			}
			else
			{
				ActivateLightning();
			}
		}

		private void ActivateLightning()
		{
			GameObject gameObject = poolUnused[poolUnused.Count - 1];
			poolUnused.RemoveAt(poolUnused.Count - 1);
			poolUsed.Add(gameObject);
			if (!followCameraVertically)
			{
				camPos.y = 0f;
			}
			if (followCamera)
			{
				gameObject.transform.localPosition = camPos + spawnPos;
			}
			else
			{
				gameObject.transform.localPosition = spawnPos;
			}
			gameObject.SetActive(value: true);
		}

		private void SheetLightning()
		{
			timeSinceLastSheetLightning = Time.time;
			nextSheetLightningIn = EvaluateDelay(probability);
			Vector3 vector = cam.ViewportToWorldPoint(new Vector3(Random.Range(0f, 1f), 0.5f, 100f));
			vector.y = camPos.y;
			Vector3 vector2 = (vector - camPos).normalized * Random.Range(minDistance, maxDistance);
			vector2.y = spawnHeight;
			GameObject gameObject = poolSheetLightningUnused[poolSheetLightningUnused.Count - 1];
			poolSheetLightningUnused.RemoveAt(poolSheetLightningUnused.Count - 1);
			poolSheetLightningUsed.Add(gameObject);
			if (!followCameraVertically)
			{
				camPos.y = 0f;
			}
			if (followCamera)
			{
				gameObject.transform.localPosition = camPos + vector2;
			}
			else
			{
				gameObject.transform.localPosition = vector2;
			}
			gameObject.SetActive(value: true);
		}

		public IEnumerator FadeUp()
		{
			if (fadeDown != null)
			{
				StopCoroutine(fadeDown);
				fadeDown = null;
			}
			float startVal = loopVol;
			float tStamp = Time.time;
			while (Time.time - tStamp < lerpSpeedUp)
			{
				loopVol = Mathf.SmoothStep(startVal, 1f, (Time.time - tStamp) / lerpSpeedUp);
				yield return null;
			}
			if (fadeUp != null)
			{
				StopCoroutine(fadeUp);
				fadeUp = null;
			}
			fadeDown = FadeDown();
			if (base.gameObject.activeInHierarchy)
			{
				StartCoroutine(fadeDown);
			}
		}

		private IEnumerator FadeDown()
		{
			float startVal = loopVol;
			float tStamp = Time.time;
			while (Time.time - tStamp < lerpSpeedDown)
			{
				loopVol = Mathf.SmoothStep(startVal, 0f, (Time.time - tStamp) / lerpSpeedDown);
				yield return null;
			}
			if (fadeDown != null)
			{
				StopCoroutine(fadeDown);
				fadeDown = null;
			}
		}

		public void BackToPool(GameObject go)
		{
			poolUsed.Remove(go);
			poolUnused.Add(go);
		}

		public void BackToPoolSheetLightning(GameObject go)
		{
			poolSheetLightningUsed.Remove(go);
			poolSheetLightningUnused.Add(go);
		}

		public static void ControlThunderstorm(float targetIntensity = 1f, float transitionDuration = 20f)
		{
			if (instance == null)
			{
				Debug.LogError("The R_Thunderstorm API Call 'R_Thunderstorm.ControlThunderStorm(float targetIntensity = 1, float transitionDuration = 20)' requires an instance of R_Thunderstorm in the scene.");
				return;
			}
			if (instance.ctrlThunderstorm != null)
			{
				instance.StopCoroutine(instance.ctrlThunderstorm);
				instance.ctrlThunderstorm = null;
			}
			instance.ctrlThunderstorm = instance.CtrlThunderstorm(targetIntensity, transitionDuration);
			if (instance.gameObject.activeInHierarchy)
			{
				instance.StartCoroutine(instance.ctrlThunderstorm);
			}
		}

		public IEnumerator CtrlThunderstorm(float targetIntensity, float transitionDuration)
		{
			float startIntensity = probability;
			float tStamp = Time.time;
			while (probability != targetIntensity)
			{
				float t = (Time.time - tStamp) / transitionDuration;
				probability = Mathf.SmoothStep(startIntensity, targetIntensity, t);
				yield return null;
			}
			StopCoroutine(ctrlThunderstorm);
			ctrlThunderstorm = null;
		}

		public static void SetProbability(float value)
		{
			instance.probability = value;
		}
	}
}
