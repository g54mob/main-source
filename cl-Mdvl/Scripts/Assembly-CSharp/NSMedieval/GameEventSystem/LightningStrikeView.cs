using NSEipix.Base;
using NSMedieval.GameEventSystem.Events;
using NSMedieval.WorldMap;
using UnityEngine;

namespace NSMedieval.GameEventSystem
{
	public class LightningStrikeView : MonoBehaviour
	{
		private ThunderstormPhase callbackTarget;

		public void Setup(ThunderstormPhase callbackTarget)
		{
			this.callbackTarget = callbackTarget;
		}

		private void Strike()
		{
			callbackTarget?.OnStrikeCallback(base.transform.position);
		}

		private void EndAnimation()
		{
			if (MonoSingleton<NSMedieval.WorldMap.WorldMap>.IsInstantiated())
			{
				GetComponentInChildren<Animator>().StopPlayback();
				Object.Destroy(base.gameObject);
			}
		}
	}
}
