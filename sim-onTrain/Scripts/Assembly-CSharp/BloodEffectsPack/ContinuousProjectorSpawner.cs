using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BloodEffectsPack
{
	public class ContinuousProjectorSpawner : MonoBehaviour
	{
		[Serializable]
		public class SpawnOption
		{
			[HideInInspector]
			public GameObject currentPrefab;

			[Header("Delay")]
			public float delay_min;

			public float delay_max;

			[Header("Lifetime")]
			[HideInInspector]
			public float lifetimeCounter;
		}

		[HideInInspector]
		public int ignoreLayerMask;

		[Header("Loop")]
		public bool isLoop;

		public float loopingLifetime = float.PositiveInfinity;

		private float loopingLifetimeCounter;

		public GameObject sourcePrefab;

		[HideInInspector]
		public Material originalMat;

		[Header("Lifetime")]
		public float lifetime_min = 1f;

		public float lifetime_max = 1f;

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

		private List<Coroutine> spawnCoroutines = new List<Coroutine>();

		[Header("Spawn Options")]
		public List<SpawnOption> spawnOptions = new List<SpawnOption>();

		private void OnEnable()
		{
			StopAllCoroutines();
			spawnCoroutines.Clear();
			foreach (SpawnOption spawnOption in spawnOptions)
			{
				Coroutine item = StartCoroutine(Spawn(spawnOption));
				spawnCoroutines.Add(item);
				spawnOption.lifetimeCounter = 0f;
				if (spawnOption.currentPrefab != null)
				{
					UnityEngine.Object.Destroy(spawnOption.currentPrefab);
				}
			}
		}

		private void Update()
		{
			loopingLifetimeCounter += Time.deltaTime;
			if (loopingLifetimeCounter >= loopingLifetime)
			{
				Debug.Log("Destroyed");
				UnityEngine.Object.Destroy(base.gameObject);
			}
		}

		private IEnumerator Spawn(SpawnOption option)
		{
			float seconds = UnityEngine.Random.Range(option.delay_min, option.delay_max);
			float lifetime = UnityEngine.Random.Range(lifetime_min, lifetime_max);
			float startProjectorSize = UnityEngine.Random.Range(startSize_min, startSize_max);
			float startRotation = UnityEngine.Random.Range(startRotation_min, startRotation_max);
			yield return new WaitForSeconds(seconds);
			option.currentPrefab = UnityEngine.Object.Instantiate(sourcePrefab);
			Projector currentProjector = option.currentPrefab.GetComponent<Projector>();
			currentProjector.enabled = false;
			currentProjector.enabled = true;
			currentProjector.material = UnityEngine.Object.Instantiate(currentProjector.material);
			currentProjector.ignoreLayers = ignoreLayerMask;
			option.currentPrefab.transform.SetParent(base.transform);
			option.currentPrefab.transform.localPosition = startPosOffset;
			option.currentPrefab.transform.localScale = Vector3.one;
			option.currentPrefab.transform.localEulerAngles = new Vector3(90f, 0f, 0f);
			option.currentPrefab.transform.RotateAround(base.transform.position, Vector3.up, startRotation);
			while (option.lifetimeCounter <= lifetime && loopingLifetimeCounter <= loopingLifetime)
			{
				option.lifetimeCounter += Time.deltaTime;
				float time = Mathf.Clamp01(option.lifetimeCounter / lifetime);
				float num = scaleCurve.Evaluate(time);
				int num2 = Mathf.FloorToInt(frameCurve.Evaluate(time));
				float value = opacityCurve.Evaluate(time);
				currentProjector.material.SetFloat("_Opacity", value);
				currentProjector.material.SetFloat("_Frame", num2);
				currentProjector.orthographicSize = num * startProjectorSize;
				if (isLoop && option.lifetimeCounter > lifetime)
				{
					option.lifetimeCounter -= lifetime;
					option.currentPrefab.transform.localPosition = startPosOffset;
					startRotation = UnityEngine.Random.Range(startRotation_min, startRotation_max);
					option.currentPrefab.transform.localEulerAngles = new Vector3(90f, 0f, 0f);
					option.currentPrefab.transform.RotateAround(base.transform.position, Vector3.up, startRotation);
					currentProjector.enabled = false;
					currentProjector.enabled = true;
				}
				yield return null;
			}
		}

		private void OnDestroy()
		{
			StopAllCoroutines();
		}
	}
}
