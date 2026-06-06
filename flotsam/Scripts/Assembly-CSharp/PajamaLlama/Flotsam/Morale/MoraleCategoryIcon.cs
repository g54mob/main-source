using UnityEngine;
using UnityEngine.UI;

namespace PajamaLlama.Flotsam.Morale
{
	public class MoraleCategoryIcon : AgentReferenceUIElement
	{
		[SerializeField]
		private Image _image;

		protected override void Subscribe(Agent agent)
		{
			agent.Morale.UpdatedEvent.AddListener(UpdateMoraleState);
			agent.Attributes.LevelIncreasedEvent.AddListener(UpdateMoraleState);
			UpdateMoraleState();
		}

		protected override void Unsubscribe(Agent agent)
		{
			agent.Morale.UpdatedEvent.RemoveListener(UpdateMoraleState);
			agent.Attributes.LevelIncreasedEvent.RemoveListener(UpdateMoraleState);
		}

		private void UpdateMoraleState()
		{
			if (_agent.Morale.TryReturnCurrentCategory(out var category))
			{
				_image.sprite = category.Icon;
			}
		}
	}
}
