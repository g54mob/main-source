using System;
using UnityEngine;

namespace Assets.Scripts.Misc.SimpleBehaviours
{
	public class NotifyOnDestroyScript : MonoBehaviour
	{
		public event EventHandler<EventArgs> OnDestroyed;

		protected virtual void OnDestroy()
		{
			this.OnDestroyed?.Invoke(this, EventArgs.Empty);
		}
	}
}
