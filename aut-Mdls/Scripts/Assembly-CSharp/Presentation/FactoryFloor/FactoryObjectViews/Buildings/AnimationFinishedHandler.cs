using System;
using UnityEngine;

namespace Presentation.FactoryFloor.FactoryObjectViews.Buildings
{
	public class AnimationFinishedHandler : MonoBehaviour
	{
		public event Action OnAnimationStartedEvent = delegate
		{
		};

		public event Action OnAnimationFinishedEvent = delegate
		{
		};

		public event Action OnFadeCreditEvent = delegate
		{
		};

		public void OnAnimationStarted()
		{
			this.OnAnimationStartedEvent();
		}

		public void OnAnimationFinished()
		{
			this.OnAnimationFinishedEvent();
		}

		public void OnFadeCredit()
		{
			this.OnFadeCreditEvent();
		}
	}
}
