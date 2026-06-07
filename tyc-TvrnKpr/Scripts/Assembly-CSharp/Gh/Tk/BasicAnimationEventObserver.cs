using System;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Gh.Tk
{
	public class BasicAnimationEventObserver : MonoBehaviour
	{
		public event EventHandler<AnimationEventArgs> AnimEvent
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public virtual void Enable(string transformName)
		{
		}

		public void EnableWithAnimatorUpdate(string transformName)
		{
		}

		public virtual void Disable(string transformName)
		{
		}

		protected void OnAnimEvent(object sender, AnimationEventArgs e)
		{
		}

		public virtual void FireAnimEvent(string name)
		{
		}

		public virtual void PlaySoundEvent(string eventName)
		{
		}

		public void PlayGlobalSoundEvent(string eventName)
		{
		}

		public void PlayParticles(string transformName)
		{
		}

		public void StopParticles(string transformName)
		{
		}

		public virtual void SetBool(string param)
		{
		}

		public void SetRandomTrigger(string value)
		{
		}
	}
}
