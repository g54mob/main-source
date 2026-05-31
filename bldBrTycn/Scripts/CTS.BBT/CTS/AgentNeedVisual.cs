using System;
using CTS.BBT.AI;
using CTS.Core;
using CTS.Core.StatisticsSystem;
using CTS.Core.Utilities;
using CTS.Emotes;
using CTS.UI;
using UnityEngine;

namespace CTS
{
	public class AgentNeedVisual : CTSBehaviour
	{
		[SerializeField]
		[Inject(false)]
		private Agent _agent;

		[SerializeField]
		private Material _material;

		[SerializeField]
		private PaletteData _contentColor;

		[SerializeField]
		private PaletteData _workerColor;

		[SerializeField]
		private PaletteData _vampireColor;

		[SerializeField]
		private PaletteData _customerColor;

		private PaletteData _paletteData;

		[SerializeField]
		private Sprite _funIcon;

		[SerializeField]
		private Sprite _hungerIcon;

		[SerializeField]
		private Sprite _toiletIcon;

		private Material _funMaterial;

		private Material _hungerMaterial;

		private Material _toiletMaterial;

		private NumericStatistic _funNeed;

		private NumericStatistic _hungerNeed;

		private NumericStatistic _toiletNeed;

		private EmoteBBT _funEmote;

		private EmoteBBT _hungerEmote;

		private EmoteBBT _toiletEmote;

		private static readonly int SHFillAmount = Shader.PropertyToID("_FillAmount");

		protected override void OnAwake()
		{
			base.OnAwake();
			_funMaterial = UnityEngine.Object.Instantiate(_material);
			_hungerMaterial = UnityEngine.Object.Instantiate(_material);
			_toiletMaterial = UnityEngine.Object.Instantiate(_material);
			_agent.Spawned += OnAgentSpawned;
			_agent.Despawned += OnAgentDespawned;
			OnAgentSpawned();
		}

		private void Start()
		{
			StopAllEmotes();
			Refresh();
		}

		private void OnDestroy()
		{
			_agent.Spawned -= OnAgentSpawned;
			_agent.Despawned -= OnAgentDespawned;
		}

		private void StopAllEmotes()
		{
			KillEmote(ref _hungerEmote);
			KillEmote(ref _funEmote);
			KillEmote(ref _toiletEmote);
		}

		private void OnAgentDespawned(Agent obj)
		{
			StopAllEmotes();
		}

		protected override void OnEnabled()
		{
			base.OnEnabled();
			_agent.Statistics.StatisticUpdated += OnStatisticsUpdated;
			_agent.ContextualFSM.StateChanged += OnStateChanged;
			AgentNeedVisualsDisplay.DisplayChanged += OnGlobalDisplayChanged;
			OnStatisticsUpdated();
			OnStateChanged(_agent.ContextualFSM.CurrentState);
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			_agent.Statistics.StatisticUpdated -= OnStatisticsUpdated;
			AgentNeedVisualsDisplay.DisplayChanged -= OnGlobalDisplayChanged;
			Unregister();
		}

		private void OnGlobalDisplayChanged()
		{
			Refresh();
		}

		private void OnStateChanged(State<Agent> obj)
		{
			if (!(obj is ContextualStateNormal) || !_agent.isActiveAndEnabled)
			{
				StopAllEmotes();
			}
			else
			{
				Refresh();
			}
		}

		private void Refresh()
		{
			if (_hungerNeed != null)
			{
				OnHungerNeedChanged(_hungerNeed.UnitInterval);
			}
			if (_funNeed != null)
			{
				OnFunNeedChanged(_funNeed.UnitInterval);
			}
			if (_toiletNeed != null)
			{
				OnToiletNeedChanged(_toiletNeed.UnitInterval);
			}
		}

		private void OnAgentSpawned()
		{
			if (_agent is Worker)
			{
				_paletteData = _workerColor;
				return;
			}
			Customer customer = (Customer)_agent;
			if ((object)customer.SpawnParameters == null)
			{
				_paletteData = _customerColor;
				return;
			}
			if (customer.IsVampire)
			{
				_paletteData = _vampireColor;
			}
			else
			{
				_paletteData = _customerColor;
			}
			StopAllEmotes();
			Refresh();
		}

		private void Unregister()
		{
			if (_funNeed != null)
			{
				_funNeed.UnitIntervalChanged -= OnFunNeedChanged;
			}
			if (_hungerNeed != null)
			{
				_hungerNeed.UnitIntervalChanged -= OnHungerNeedChanged;
			}
			if (_toiletNeed != null)
			{
				_toiletNeed.UnitIntervalChanged -= OnToiletNeedChanged;
			}
		}

		private void OnStatisticsUpdated()
		{
			Unregister();
			if (_agent.Statistics.TryGetNumericStatistic(EAgentStatistics.Fun, out _funNeed))
			{
				_funNeed.UnitIntervalChanged += OnFunNeedChanged;
			}
			if (_agent.Statistics.TryGetNumericStatistic(EAgentStatistics.Hunger, out _hungerNeed))
			{
				_hungerNeed.UnitIntervalChanged += OnHungerNeedChanged;
			}
			if (_agent.Statistics.TryGetNumericStatistic(EAgentStatistics.Bladder, out _toiletNeed))
			{
				_toiletNeed.UnitIntervalChanged += OnToiletNeedChanged;
			}
		}

		private void OnFunNeedChanged(float unitInterval)
		{
			NumericStatistic numericStatistic;
			if (!CTSSingleton<AgentNeedVisualsDisplay>.Instance.ShowFun)
			{
				KillEmote(ref _funEmote);
			}
			else if (_agent.ContextualFSM.CurrentState is ContextualStateNormal && _agent.Statistics.TryGetNumericStatistic(EAgentStatistics.NeedsThresholds, out numericStatistic))
			{
				float num = numericStatistic.InitializationRange.x + 0.2f;
				if (unitInterval > num)
				{
					KillEmote(ref _funEmote);
					return;
				}
				GetOrCreateEmote(ref _funEmote, _funIcon, _funMaterial);
				float value = unitInterval.Remap(numericStatistic.InitializationRange.x, num, 0f, 1f);
				_funMaterial.SetFloat(SHFillAmount, Math.Clamp(value, 0f, 1f));
			}
		}

		private void OnHungerNeedChanged(float unitInterval)
		{
			float statisticValue;
			if (!CTSSingleton<AgentNeedVisualsDisplay>.Instance.ShowHunger)
			{
				KillEmote(ref _hungerEmote);
			}
			else if (_agent.ContextualFSM.CurrentState is ContextualStateNormal && _agent.Statistics.TryGetStatisticUnitInterval(EAgentStatistics.HungerAttackThreshold, out statisticValue))
			{
				float num = statisticValue + 0.2f;
				if (unitInterval > num)
				{
					KillEmote(ref _hungerEmote);
					return;
				}
				GetOrCreateEmote(ref _hungerEmote, _hungerIcon, _hungerMaterial);
				float value = unitInterval.Remap(statisticValue, num, 0f, 1f);
				_hungerMaterial.SetFloat(SHFillAmount, Math.Clamp(value, 0f, 1f));
			}
		}

		private void OnToiletNeedChanged(float unitInterval)
		{
			float statisticValue;
			if (!CTSSingleton<AgentNeedVisualsDisplay>.Instance.ShowToilet)
			{
				KillEmote(ref _toiletEmote);
			}
			else if (_agent.ContextualFSM.CurrentState is ContextualStateNormal && _agent.Statistics.TryGetStatisticUnitInterval(EAgentStatistics.ToiletBladderPeeDanceThreshold, out statisticValue))
			{
				float num = statisticValue + 0.2f;
				if (unitInterval > num)
				{
					KillEmote(ref _toiletEmote);
					return;
				}
				GetOrCreateEmote(ref _toiletEmote, _toiletIcon, _toiletMaterial);
				float value = unitInterval.Remap(statisticValue, num, 0f, 1f);
				_toiletMaterial.SetFloat(SHFillAmount, Math.Clamp(value, 0f, 1f));
			}
		}

		private void GetOrCreateEmote(ref EmoteBBT emoteBBT, Sprite sprite, Material emoteMat)
		{
			if (emoteBBT == null)
			{
				emoteBBT = EmotePool.GetEmoteBBT();
				EmoteManagerBBT.Play(_agent, sprite, emoteBBT);
				emoteBBT.SetBackgroundMaterial(emoteMat);
				emoteBBT.SetStayDuration(-1f);
				emoteBBT.SetBackgroundColor(_paletteData);
				emoteBBT.SetContentColor(_contentColor);
				emoteBBT.SetContentSize(45f);
				emoteBBT.SetPadding(2f);
			}
		}

		private void KillEmote(ref EmoteBBT emoteBBT)
		{
			if (emoteBBT != null)
			{
				emoteBBT.Kill();
				EmotePool.PushEmote(emoteBBT);
				emoteBBT = null;
			}
		}
	}
}
