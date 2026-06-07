using System.Collections;
using UnityEngine;

namespace CodeStage.AdvancedFPSCounter.CountersData
{
	public abstract class UpdatableCounterData : BaseCounterData
	{
		protected Coroutine updateCoroutine;

		[Tooltip("Update interval in seconds.")]
		[Range(0.1f, 10f)]
		[SerializeField]
		protected float updateInterval;

		public float UpdateInterval
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		protected override void PerformInitActions()
		{
		}

		protected override void PerformDeActivationActions()
		{
		}

		protected abstract IEnumerator UpdateCounter();

		private void StartUpdateCoroutine()
		{
		}

		private void StopUpdateCoroutine()
		{
		}
	}
}
