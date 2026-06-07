using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace PajamaLlama.Flotsam.Morale
{
	public class MoraleThresholdBarEntry : UIBehaviour
	{
		[SerializeField]
		private Image _backgroundImage;

		[SerializeField]
		private MoraleCategoryTooltip _tooltip;

		public void Initialize(MoraleCategory category, Agent agent)
		{
			_backgroundImage.color = category.Color;
			_tooltip.Initialize(category, agent);
		}
	}
}
