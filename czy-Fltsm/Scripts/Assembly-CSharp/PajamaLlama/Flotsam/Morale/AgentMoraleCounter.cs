using TMPro;
using UnityEngine;

namespace PajamaLlama.Flotsam.Morale
{
	public class AgentMoraleCounter : AgentReferenceUIElement
	{
		[SerializeField]
		private TMP_Text _counter;

		private int _mood;

		protected override void Subscribe(Agent agent)
		{
			agent.Morale.UpdatedEvent.AddListener(UpdateMorale);
			UpdateMorale();
		}

		protected override void Unsubscribe(Agent agent)
		{
			agent.Morale.UpdatedEvent.RemoveListener(UpdateMorale);
		}

		private void UpdateMorale()
		{
			if (_mood != _agent.Morale.CurrentMood && _agent.Morale.TryReturnCategory(out var category, _agent.Morale.CurrentMood))
			{
				_mood = _agent.Morale.CurrentMood;
				_counter.text = $"{_mood}%";
				_counter.color = category.Color;
			}
		}
	}
}
