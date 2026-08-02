using System.Collections;
using UnityEngine;

namespace BloodEffectsPack
{
	public class ProjectorSpawner : MonoBehaviour
	{
		[HideInInspector]
		public int ignoreLayerMask;

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
			ignoreLayerMask = value;
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
			Projector currentProjector = currentPrefab.GetComponent<Projector>();
			currentProjector.enabled = false;
			currentProjector.enabled = true;
			currentProjector.material = Object.Instantiate(currentProjector.material);
			currentProjector.ignoreLayers = ignoreLayerMask;
			currentPrefab.transform.SetParent(base.transform);
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
				int num2 = Mathf.FloorToInt(frameCurve.Evaluate(time));
				float value = opacityCurve.Evaluate(time);
				currentProjector.material.SetFloat("_Frame", num2);
				currentProjector.material.SetFloat("_Opacity", value);
				currentProjector.orthographicSize = num * startProjectorSize;
				if (isLoop && lifetimeCounter > lifetime)
				{
					lifetimeCounter -= lifetime;
					currentPrefab.transform.localPosition = startPosOffset;
					startRotation = Random.Range(startRotation_min, startRotation_max);
					currentPrefab.transform.localEulerAngles = new Vector3(90f, 0f, 0f);
					currentPrefab.transform.RotateAround(base.transform.position, Vector3.up, startRotation);
					currentProjector.enabled = false;
					currentProjector.enabled = true;
				}
				yield return null;
			}
			if (destroyAfter)
			{
				Object.Destroy(base.gameObject);
			}
		}

		private int LayerMaskToLayer(LayerMask mask)
		{
			int value = mask.value;
			for (int i = 0; i < 32; i++)
			{
				if ((value & (1 << i)) != 0)
				{
					return i;
				}
			}
			return 0;
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
