using System;
using UnityEngine;

namespace TMPEffects.Components.Animator
{
	[RequireComponent(typeof(TMPAnimator))]
	public class TMPAnimatorUpdater : MonoBehaviour
	{
		[SerializeField]
		private uint maxUpdatesPerSecond = 144u;

		[SerializeField]
		private float additionalTimeScaling = 1f;

		[NonSerialized]
		private AnimationUpdater animUpdater;

		public uint MaxUpdatesPerSecond => maxUpdatesPerSecond;

		public float AdditionalTimeScaling => additionalTimeScaling;

		public void SetMaxUpdatesPerSecond(uint maxUpdatesPerSecond)
		{
			animUpdater.SetMaxUpdatesPerSecond(maxUpdatesPerSecond);
		}

		public void SetAdditionalTimeScaling(float timeScaling)
		{
			animUpdater.AdditionalTimeScaling = timeScaling;
		}

		private void OnEnable()
		{
			TMPAnimator component = GetComponent<TMPAnimator>();
			component.SetUpdateFrom(UpdateFrom.Script);
			animUpdater = new AnimationUpdater(component.UpdateAnimations, maxUpdatesPerSecond, additionalTimeScaling);
		}

		private void Update()
		{
			animUpdater.Update(Time.deltaTime);
		}
	}
}
