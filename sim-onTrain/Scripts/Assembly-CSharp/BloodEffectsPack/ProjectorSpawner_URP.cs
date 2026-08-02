using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace BloodEffectsPack
{
	public class ProjectorSpawner_URP : MonoBehaviour
	{
		[HideInInspector]
		public int renderingLayerMask = 1;

		public bool destroyAfter = true;

		public GameObject sourcePrefab;

		private GameObject currentPrefab;

		private Coroutine currentCoroutine;

		[Header("Loop")]
		public bool isLoop;

		public float loopingLifetime = float.PositiveInfinity;

		private float loopingLifetimeCounter;

		[Header("Delay")]
		public float delay_min;

		public float delay_max;

		[Header("Lifetime")]
		public float lifetime_min = 1f;

		public float lifetime_max = 1f;

		private float lifetimeCounter;

		[Header("StartPos")]
		public Vector3 startPosOffset = Vector3.zero;

		[Header("Size")]
		public float startSize_min = 1f;

		public float startSize_max = 1f;

		[Header("Rotation")]
		public float startRotation_min;

		public float startRotation_max;

		[Header("CurveControl")]
		public AnimationCurve frameCurve;

		public AnimationCurve scaleCurve;

		public AnimationCurve opacityCurve;

		private Material originalMat;

		private void OnEnable()
		{
			if (currentCoroutine != null)
			{
				StopCoroutine(currentCoroutine);
			}
			lifetimeCounter = 0f;
			loopingLifetimeCounter = 0f;
			if (currentPrefab != null)
			{
				Object.Destroy(currentPrefab.gameObject);
			}
			currentCoroutine = StartCoroutine(Spawn());
		}

		public void ResetAndInitialize(int value)
		{
			if (currentCoroutine != null)
			{
				StopCoroutine(currentCoroutine);
			}
			lifetimeCounter = 0f;
			loopingLifetimeCounter = 0f;
			if (currentPrefab != null)
			{
				Object.Destroy(currentPrefab.gameObject);
			}
			renderingLayerMask = value;
			currentCoroutine = StartCoroutine(Spawn());
		}

		private void Update()
		{
		}

		private IEnumerator Spawn()
		{
			float seconds = Random.Range(delay_min, delay_max);
			float lifetime = Random.Range(lifetime_min, lifetime_max);
			float startProjectorSize = Random.Range(startSize_min, startSize_max);
			float startRotation = Random.Range(startRotation_min, startRotation_max);
			yield return new WaitForSeconds(seconds);
			currentPrefab = Object.Instantiate(sourcePrefab);
			DecalProjector currentProjector = currentPrefab.GetComponent<DecalProjector>();
			originalMat = currentProjector.material;
			currentProjector.material = null;
			currentProjector.material = Object.Instantiate(originalMat);
			currentProjector.renderingLayerMask = (uint)renderingLayerMask;
			currentPrefab.transform.SetParent(base.transform);
			currentPrefab.GetComponent<ProjectorPrioritySetter_URP>().SetPriority();
			currentPrefab.transform.localPosition = startPosOffset;
			currentPrefab.transform.localScale = Vector3.one;
			currentPrefab.transform.localEulerAngles = new Vector3(90f, 0f, 0f);
			currentPrefab.transform.RotateAround(base.transform.position, Vector3.up, startRotation);
			while (lifetimeCounter <= lifetime && loopingLifetimeCounter <= loopingLifetime)
			{
				lifetimeCounter += Time.deltaTime;
				loopingLifetimeCounter += Time.deltaTime;
				float time = Mathf.Clamp01(lifetimeCounter / lifetime);
				float num = scaleCurve.Evaluate(time);
				int frameIndex = Mathf.FloorToInt(frameCurve.Evaluate(time));
				float fadeFactor = opacityCurve.Evaluate(time);
				currentProjector.GetComponent<ProjectorSpriteController_URP>().SetFrameIndex(frameIndex);
				currentProjector.fadeFactor = fadeFactor;
				currentProjector.size = new Vector3(num * startProjectorSize, num * startProjectorSize, 10f);
				currentProjector.pivot = new Vector3(0f, 0f, 5f);
				if (isLoop && lifetimeCounter > lifetime)
				{
					lifetimeCounter -= lifetime;
					currentPrefab.transform.localPosition = startPosOffset;
					startRotation = Random.Range(startRotation_min, startRotation_max);
					currentPrefab.transform.localEulerAngles = new Vector3(90f, 0f, 0f);
					currentPrefab.transform.RotateAround(base.transform.position, Vector3.up, startRotation);
					currentPrefab.GetComponent<ProjectorPrioritySetter_URP>().SetPriority();
				}
				yield return null;
			}
			if (destroyAfter)
			{
				Object.Destroy(base.gameObject);
			}
		}

		private void OnDestroy()
		{
			if (currentCoroutine != null)
			{
				StopCoroutine(currentCoroutine);
			}
		}
	}
}
