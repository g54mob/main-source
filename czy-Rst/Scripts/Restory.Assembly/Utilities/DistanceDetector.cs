using System.Collections;
using Helpers.Events;
using UnityEngine;
using UnityEngine.Events;

namespace Utilities
{
	public class DistanceDetector : MonoBehaviour
	{
		public readonly UnityEvent<bool> OnCloseEnoughStatusChanged = new UnityEventBool();

		[Header("General settings")]
		[SerializeField]
		private bool startOnEnable = true;

		[Header("Detection settings")]
		[SerializeField]
		private Transform targetTrasform;

		[SerializeField]
		[Tooltip("Time period to check distance to Character")]
		private float detectionPeriod = 0.02f;

		[SerializeField]
		private float detectionDistance = 12.5f;

		private Coroutine detectionCoroutine;

		private bool isCloseEnough;

		private bool initialisationPassed;

		public Transform TargetTransform
		{
			get
			{
				return targetTrasform;
			}
			set
			{
				targetTrasform = value;
				StartRoutine();
			}
		}

		public float DetectionDistance => detectionDistance;

		public bool IsCloseEnough
		{
			get
			{
				return isCloseEnough;
			}
			private set
			{
				if (!initialisationPassed || value != isCloseEnough)
				{
					isCloseEnough = value;
					OnCloseEnoughStatusChanged.Invoke(value);
					if (!initialisationPassed)
					{
						initialisationPassed = true;
					}
				}
			}
		}

		private void OnEnable()
		{
			if (startOnEnable)
			{
				StartRoutine();
			}
		}

		private void OnDisable()
		{
			StopRoutine();
		}

		public void StartRoutine()
		{
			StopRoutine();
			if (base.gameObject.activeSelf)
			{
				detectionCoroutine = StartCoroutine(DistanceDetectionRoutine());
			}
		}

		public void StopRoutine()
		{
			if (detectionCoroutine != null)
			{
				StopCoroutine(detectionCoroutine);
				detectionCoroutine = null;
			}
			initialisationPassed = false;
		}

		private IEnumerator DistanceDetectionRoutine()
		{
			WaitForSeconds delay = new WaitForSeconds(detectionPeriod);
			while ((bool)TargetTransform)
			{
				IsCloseEnough = Vector3.Distance(TargetTransform.position, base.transform.position) <= detectionDistance;
				yield return delay;
			}
			detectionCoroutine = null;
		}
	}
}
