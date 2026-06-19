using System;
using UnityEngine;

namespace TMPEffects.Components.Animator
{
	[RequireComponent(typeof(TMPAnimator))]
	public class TMPAnimatorUpdater : MonoBehaviour
	{
		[SerializeField]
		private uint maxUpdatesPerSecond;

		[SerializeField]
		private float additionalTimeScaling;

		[NonSerialized]
		private AnimationUpdater animUpdater;

		public uint MaxUpdatesPerSecond => 0u;

		public float AdditionalTimeScaling => 0f;

		public void SetMaxUpdatesPerSecond(uint maxUpdatesPerSecond)
		{
		}

		public void SetAdditionalTimeScaling(float timeScaling)
		{
		}

		private void OnEnable()
		{
		}

		private void Update()
		{
		}
	}
}
