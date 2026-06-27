using Restory.Data.Elements.Condition;
using Restory.ObjectPools;
using UnityEngine;
using UnityEngine.UI;

namespace Restory.Gameplay.Tooltips
{
	public class ElementConditionMarker : MonoBehaviour, ICleanableComponent
	{
		[SerializeField]
		private CanvasGroup canvasGroup;

		[SerializeField]
		private Image markerImage;

		public CanvasGroup CanvasGroup => canvasGroup;

		public void Init(ElementConditionBase elementCondition)
		{
			markerImage.sprite = elementCondition.Icon;
		}

		public void Clean()
		{
			canvasGroup.alpha = 0f;
		}
	}
}
