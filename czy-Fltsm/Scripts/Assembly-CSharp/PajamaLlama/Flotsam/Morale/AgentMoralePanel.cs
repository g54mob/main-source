using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace PajamaLlama.Flotsam.Morale
{
	public class AgentMoralePanel : MonoBehaviour
	{
		[SerializeField]
		private Transform _entryParent;

		[SerializeField]
		private AgentMoraleModifierEntry _entryPrefab;

		[SerializeField]
		private TMP_Text _workSpeed;

		[SerializeField]
		private TMP_Text _expertiseGain;

		private Agent _agent;

		private List<AgentMoraleModifierEntry> _entries = new List<AgentMoraleModifierEntry>();

		private bool _update;

		private void LateUpdate()
		{
			if (_update)
			{
				UpdateMorale();
			}
		}

		private void OnDisable()
		{
			if ((bool)_agent)
			{
				_agent.Morale.UpdatedEvent.RemoveListener(OnMoraleUpdated);
			}
		}

		public void Initialize(Agent agent)
		{
			OnDisable();
			_agent = agent;
			_agent.Morale.UpdatedEvent.AddListener(OnMoraleUpdated);
			UpdateMorale();
		}

		private void OnMoraleUpdated()
		{
			_update = true;
		}

		private void UpdateMorale()
		{
			if (_agent.Morale.TryReturnCurrentCategory(out var category))
			{
				_workSpeed.text = $"{category.SpeedMultiplier:0%}";
				_workSpeed.color = category.Color;
				_expertiseGain.text = $"{category.ExperienceMultiplier:0%}";
				_expertiseGain.color = category.Color;
			}
			foreach (AgentMoraleModifierEntry entry in _entries)
			{
				entry.gameObject.SetActive(value: false);
			}
			List<MoraleEffect> list = ListPool<MoraleEffect>.Get(_agent.Morale.MoraleEffects);
			Sorting.SlowSort(list);
			foreach (MoraleEffect item in list)
			{
				if (item.IsActive())
				{
					ReturnEntry().Initialize(item);
				}
			}
			LayoutUpdater.ForceRebuild(_entryParent);
			list.Dispose();
			_update = false;
		}

		private AgentMoraleModifierEntry ReturnEntry()
		{
			foreach (AgentMoraleModifierEntry entry in _entries)
			{
				if (!entry.gameObject.activeSelf)
				{
					return entry;
				}
			}
			AgentMoraleModifierEntry agentMoraleModifierEntry = Object.Instantiate(_entryPrefab, _entryParent);
			_entries.Add(agentMoraleModifierEntry);
			return agentMoraleModifierEntry;
		}
	}
}
