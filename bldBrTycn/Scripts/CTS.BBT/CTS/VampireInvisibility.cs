using System;
using CTS.BBT;
using CTS.BBT.AI;
using CTS.Core;

namespace CTS
{
	public class VampireInvisibility : CTSBehaviour
	{
		[Inject(false)]
		private Worker _agent;

		private Item _currentItem;

		protected override void OnEnabled()
		{
			base.OnEnabled();
			_agent.ObjectHolding.OnItemGrab += OnItemGrabbed;
			Worker agent = _agent;
			agent.WasSeen = (Action)Delegate.Combine(agent.WasSeen, new Action(OnAgentSeen));
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			_agent.ObjectHolding.OnItemGrab -= OnItemGrabbed;
			Worker agent = _agent;
			agent.WasSeen = (Action)Delegate.Remove(agent.WasSeen, new Action(OnAgentSeen));
		}

		private void Start()
		{
			_currentItem = _agent.ObjectHolding.CurrentHeld;
			if (_agent.Cooldowns.IsOnCooldown(BBTAgentTags.CD_InvisibilityDuration))
			{
				_agent.SetVisible(value: false);
				if ((bool)_currentItem)
				{
					_currentItem.SetVisible(isVisible: false);
				}
			}
		}

		private void Update()
		{
			if (!_agent.IsVisible && !_agent.Cooldowns.IsOnCooldown(BBTAgentTags.CD_InvisibilityDuration))
			{
				_agent.SetVisible(value: true);
				if ((bool)_currentItem)
				{
					_currentItem.SetVisible(isVisible: true);
				}
			}
		}

		private void OnAgentSeen()
		{
			if (_agent.IsVisible && _agent.PowerFeatures.HavePower(WorkerPowerFeature.e_PowerFeatures.Invisibility) && !_agent.Cooldowns.IsOnCooldown(BBTAgentTags.CD_Invisibility) && _agent.Statistics.TryGetStatisticValue(EAgentStatistics.InvisibilityDuration, out var statisticValue))
			{
				if (_agent.Statistics.TryGetStatisticValue(EAgentStatistics.InvisibilityDurationLeveling, out var statisticValue2))
				{
					statisticValue += (float)(_agent.Level.CurrentLevel - 1) * statisticValue2;
				}
				_agent.SetVisible(value: false);
				_agent.Animator.Events.TriggerVFX("Invisibility");
				if ((bool)_currentItem)
				{
					_currentItem.SetVisible(isVisible: false);
				}
				_agent.Cooldowns.StartCooldown(BBTAgentTags.CD_Invisibility);
				_agent.Cooldowns.StartCooldown(BBTAgentTags.CD_InvisibilityDuration, statisticValue);
			}
		}

		private void OnItemGrabbed(Item item)
		{
			if (_currentItem == item)
			{
				return;
			}
			if ((object)item == null)
			{
				if ((bool)_currentItem)
				{
					_currentItem.SetVisible(isVisible: true);
					Item currentItem = _currentItem;
					currentItem.WasSeen = (Action)Delegate.Remove(currentItem.WasSeen, new Action(OnAgentSeen));
				}
			}
			else
			{
				if (!_agent.IsVisible)
				{
					item.SetVisible(isVisible: false);
				}
				item.WasSeen = (Action)Delegate.Combine(item.WasSeen, new Action(OnAgentSeen));
			}
			_currentItem = item;
		}
	}
}
