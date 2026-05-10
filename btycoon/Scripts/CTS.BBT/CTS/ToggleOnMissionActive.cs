using CTS.Core;
using UnityEngine;
using UnityEngine.Events;

namespace CTS
{
	public class ToggleOnMissionActive : MonoBehaviour
	{
		[SerializeField]
		private UnityEvent _missionStartedEvent;

		[SerializeField]
		private UnityEvent _missionEndedEvent;

		[SerializeField]
		private UnityEvent<bool> _missionActiveEvent;

		[SerializeField]
		private StringKey _basketKey;

		private MissionBasket _basket;

		private void Awake()
		{
			_basket = CTSSingleton<StoreBaskets>.Instance.GetMissionBasket(_basketKey);
			MissionBasket.MissionStarted += OnMissionStarted;
			MissionBasket.MissionEnded += OnMissionEnded;
			if (_basket.HasMission())
			{
				OnMissionStarted(_basket);
			}
			else
			{
				OnMissionEnded(_basket, default(MissionBasket.MissionResult));
			}
		}

		private void OnDestroy()
		{
			MissionBasket.MissionStarted -= OnMissionStarted;
			MissionBasket.MissionEnded -= OnMissionEnded;
		}

		private void OnMissionStarted(MissionBasket basket)
		{
			if (!(basket != _basket))
			{
				_missionStartedEvent.Invoke();
				_missionActiveEvent.Invoke(arg0: true);
			}
		}

		private void OnMissionEnded(MissionBasket basket, MissionBasket.MissionResult missionResult)
		{
			if (!(basket != _basket))
			{
				_missionEndedEvent.Invoke();
				_missionActiveEvent.Invoke(arg0: false);
			}
		}
	}
}
