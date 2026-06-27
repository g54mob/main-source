using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Restory.UserInterface.Tooltips
{
	public abstract class GUI_SingleTooltipBase : GUI_SingleObjectModalBase
	{
		[Header("Tooltip settings")]
		[SerializeField]
		protected Text description;

		[SerializeField]
		protected TextMeshProUGUI descriptionTextMeshPro;

		[SerializeField]
		protected Image directionArrow;

		[Header("Background settings")]
		[SerializeField]
		protected Image background;

		[SerializeField]
		protected Color activatableColor;

		[SerializeField]
		protected Color nonActivatableColor;

		protected override void Awake()
		{
			base.Awake();
			base.WindowRectTransform.localScale = Vector3.zero;
		}

		protected virtual void InitializeDescriptionOnly(string message, bool isActivatable)
		{
			if (string.IsNullOrEmpty(message))
			{
				Debug.LogWarning("[" + base.name + "] can't display empty message!");
			}
			if ((bool)description)
			{
				description.text = message;
			}
			if ((bool)descriptionTextMeshPro)
			{
				descriptionTextMeshPro.text = message;
			}
			if ((bool)background)
			{
				background.color = (isActivatable ? activatableColor : nonActivatableColor);
			}
			if ((bool)directionArrow)
			{
				directionArrow.color = (isActivatable ? activatableColor : nonActivatableColor);
			}
		}

		public override void Clean()
		{
			if (TryGetComponent<GUI_ScreenObjectModelFollower>(out var component))
			{
				component.AdditionalOffsetPosition = Vector3.zero;
			}
			if ((bool)description)
			{
				description.text = string.Empty;
			}
			if ((bool)descriptionTextMeshPro)
			{
				descriptionTextMeshPro.text = string.Empty;
			}
			if ((bool)background)
			{
				background.color = activatableColor;
			}
			if ((bool)directionArrow)
			{
				directionArrow.color = activatableColor;
			}
		}
	}
}
