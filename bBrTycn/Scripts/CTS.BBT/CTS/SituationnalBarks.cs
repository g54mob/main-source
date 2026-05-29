using System;
using CTS.BBT.AI;
using CTS.Core;
using CTS.Emotes;
using UnityEngine;
using UnityEngine.Localization;

namespace CTS
{
	public class SituationnalBarks : MonoBehaviour
	{
		[SerializeField]
		private SituationlBarkSO _darts;

		[SerializeField]
		private SituationlBarkSO _flipper;

		[SerializeField]
		private SituationlBarkSO _enterInBar;

		private int _barkTime = 8;

		public static event Action ActiveCD;

		public virtual void Darts()
		{
			CalLSO(_darts);
		}

		public virtual void Flipper()
		{
			CalLSO(_flipper);
		}

		public virtual void EnterBar()
		{
			CalLSO(_enterInBar);
		}

		protected virtual void CalLSO(SituationlBarkSO situationlBarkSO)
		{
			if (!MonoSingleton<SituationalBarkManager>.Instance.IsCDActive())
			{
				LocalizedString localizedString = situationlBarkSO.GiveaLocalizedString();
				if (localizedString != null)
				{
					Agent component = GetComponent<Agent>();
					string localizedString2 = localizedString.GetLocalizedString();
					SituationnalBarks.ActiveCD?.Invoke();
					EmoteManagerBBT.Play(component, localizedString2).SetStayDuration(_barkTime);
				}
			}
		}
	}
}
