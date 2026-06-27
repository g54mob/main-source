using System.Collections;
using UnityEngine;

namespace Utilities
{
	public class VerticalAligmentDetector : MonoBehaviour
	{
		public enum Aligment
		{
			Under = -1,
			Same = 0,
			Above = 1
		}

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
		private float allowedEpsilon = 2f;

		private Coroutine detectionCoroutine;

		public Aligment CurrentAligment { get; private set; }

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
			detectionCoroutine = StartCoroutine(DistanceDetectionRoutine());
		}

		public void StopRoutine()
		{
			if (detectionCoroutine != null)
			{
				StopCoroutine(detectionCoroutine);
				detectionCoroutine = null;
			}
		}

		private IEnumerator DistanceDetectionRoutine()
		{
			WaitForSeconds delay = new WaitForSeconds(detectionPeriod);
			while ((bool)TargetTransform)
			{
				float f = TargetTransform.position.y - base.transform.position.y;
				if (Mathf.Abs(f) <= allowedEpsilon)
				{
					CurrentAligment = Aligment.Same;
				}
				else
				{
					CurrentAligment = ((Mathf.Sign(f) > 0f) ? Aligment.Above : Aligment.Under);
				}
				yield return delay;
			}
			detectionCoroutine = null;
		}
	}
}
