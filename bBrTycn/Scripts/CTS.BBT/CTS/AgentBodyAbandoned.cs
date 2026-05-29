using System;
using CTS.BBT.AI;
using CTS.Core;
using CTS.Utilities;
using NaughtyAttributes;
using UnityEngine;

namespace CTS
{
	public class AgentBodyAbandoned : MonoBehaviour
	{
		[SerializeField]
		[BoxGroup("Base Settings")]
		private float _vfxHeight;

		[SerializeField]
		[BoxGroup("Base Settings")]
		private GameObject _vfxFly;

		private float _flyOverTheCorpseXDays = 5f;

		private float _flyDayPassed;

		private Agent _agentRef;

		private bool _isBaged;

		private int _daysCounter;

		private float _abandonedAfterXDays;

		private float _vigilancePerDay;

		private bool _flyAreSpawned;

		private GameObject _fly;

		private static Addressable<PrestigeUIStatsSO> _rottingCorpsesStat = new Addressable<PrestigeUIStatsSO>("Assets/Scriptables/Prestige/StatPrestige/Stats/RottingCorpses.asset");

		public static event Action FeedbackCorpse;

		private void Awake()
		{
			_agentRef = GetComponent<Agent>();
		}

		private void OnEnable()
		{
			CalendarHandlers.NewDay += NewDay;
			AgentActionPickUpBody.WrappingInBodyBag += WrappingInBodyBag;
			_agentRef.Statistics.TryGetStatisticValue(EAgentStatistics.AbandonedAfterXDays, out _abandonedAfterXDays);
			_agentRef.Statistics.TryGetStatisticValue(EAgentStatistics.AbandonedVigilance, out _vigilancePerDay);
			_isBaged = false;
			_daysCounter = 0;
			_flyAreSpawned = false;
		}

		private void OnDisable()
		{
			CalendarHandlers.NewDay -= NewDay;
			AgentActionPickUpBody.WrappingInBodyBag -= WrappingInBodyBag;
		}

		private void NewDay()
		{
			if (!base.isActiveAndEnabled || !_agentRef.IsDead || _isBaged)
			{
				return;
			}
			if ((float)_daysCounter >= _abandonedAfterXDays)
			{
				MonoSingleton<VigilanceHandlers>.Instance.ChangeVigilanceBy((int)_vigilancePerDay, _agentRef, EBone.Hip);
				_rottingCorpsesStat.Value.AddToCurrentValue((int)_vigilancePerDay);
				_flyDayPassed += 1f;
				if (_flyDayPassed >= _flyOverTheCorpseXDays)
				{
					AgentBodyAbandoned.FeedbackCorpse?.Invoke();
				}
				if (!_flyAreSpawned)
				{
					_flyAreSpawned = true;
					_fly = UnityEngine.Object.Instantiate(_vfxFly.gameObject, base.transform.position + new Vector3(0f, _vfxHeight, 0f), base.transform.rotation);
				}
			}
			else
			{
				_daysCounter++;
			}
		}

		private void WrappingInBodyBag(Agent value)
		{
			if (value == _agentRef)
			{
				_isBaged = true;
				if (_fly != null)
				{
					_fly.GetComponent<VFXFlyDeadBody>().InitDestroy();
				}
			}
		}
	}
}
