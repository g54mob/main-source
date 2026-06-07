using System.Collections;
using UnityEngine;

namespace Assets.Nimbatus.Scripts.Behaviours.EventReactions.Events
{
	public class OnCoroutine : NimbatusEvent
	{
		public float Interval = 1f;

		private bool _shouldRun;

		protected override void Subscribe()
		{
			_shouldRun = true;
			OwnWorldObject.StartCoroutine(OwnWorldObject_OnCoroutine());
		}

		public IEnumerator OwnWorldObject_OnCoroutine()
		{
			yield return true;
			while (_shouldRun)
			{
				yield return new WaitForSeconds(Interval);
				if (Behaviour != null && Behaviour.IsInitialized())
				{
					RaiseEvent();
				}
			}
		}

		protected override void Unsubscribe()
		{
			_shouldRun = false;
		}
	}
}
