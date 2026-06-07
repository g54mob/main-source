using PajamaLlama.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace PajamaLlama.Flotsam.Morale
{
	public class MoraleBar : AgentReferenceUIElement
	{
		[SerializeField]
		private MoraleThresholdBar _thresholdBar;

		[SerializeField]
		private Slider _moraleSlider;

		[SerializeField]
		private Slider _moodSlider;

		private bool _updateMoodIsMoraleTarget;

		private void Update()
		{
			UpdateSlider(_moraleSlider, _agent.Morale.CurrentMoraleFloat, _agent.Morale.Properties.MoraleRange);
			UpdateSlider(_moodSlider, _agent.Morale.CurrentMood, _agent.Morale.Properties.MoraleRange);
		}

		protected override void Subscribe(Agent agent)
		{
			agent.Attributes.LevelIncreasedEvent.AddListener(UpdateBar);
			UpdateBar();
			_moodSlider.gameObject.SetActive(agent.Morale.Properties.Style == MoraleStyle.MoodIsMoraleTarget);
		}

		protected override void Unsubscribe(Agent agent)
		{
			agent.Attributes.LevelIncreasedEvent.RemoveListener(UpdateBar);
		}

		private void UpdateBar()
		{
			_thresholdBar.Clear();
			MoraleCategory[] categories = _agent.Morale.Properties.Categories;
			foreach (MoraleCategory moraleCategory in categories)
			{
				if (moraleCategory.IsAvailable(_agent.Attributes.Level))
				{
					_thresholdBar.Add(moraleCategory.ReturnRelativeSize(_agent.Attributes.Level, _agent.Attributes.MaximumDrifterLevel, _agent.Morale.Properties.Categories, _agent.Morale.Properties.MoraleRange)).Initialize(moraleCategory, _agent);
				}
			}
		}

		private void UpdateSlider(Slider slider, float value, RangedInt range)
		{
			slider.minValue = range.Minimum;
			slider.maxValue = range.Maximum;
			slider.value = value;
		}
	}
}
