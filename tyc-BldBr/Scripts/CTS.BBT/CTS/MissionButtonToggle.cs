using CTS.Core;
using CTS.UI;
using UnityEngine;

namespace CTS
{
	public class MissionButtonToggle : CTSBehaviour
	{
		[SerializeField]
		[Inject(false)]
		private CTSToggle _toggle;

		[SerializeField]
		private CTSToggle _buttonToToggleOnEnd;

		[SerializeField]
		private StringKey _basketKey;

		private MissionBasket _basket;

		private LockToggle _lockToggle;

		protected override void OnAwake()
		{
			base.OnAwake();
			_basket = CTSSingleton<StoreBaskets>.Instance.GetMissionBasket(_basketKey);
			_lockToggle = new LockToggle(_toggle);
		}

		protected override void OnEnabled()
		{
			base.OnEnabled();
			MissionBasket.MissionStarted += OnMissionStarted;
			MissionBasket.MissionEnded += OnMissionEnded;
			_lockToggle.SetLock(!_basket.HasMission());
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			MissionBasket.MissionStarted -= OnMissionStarted;
			MissionBasket.MissionEnded -= OnMissionEnded;
		}

		private void OnMissionStarted(MissionBasket basket)
		{
			if (!(basket != _basket))
			{
				_lockToggle.Unlock();
			}
		}

		private void OnMissionEnded(MissionBasket basket, MissionBasket.MissionResult missionResult)
		{
			if (!(basket != _basket))
			{
				_lockToggle.Lock();
				if (_toggle.isOn)
				{
					_buttonToToggleOnEnd.isOn = true;
				}
			}
		}
	}
}
