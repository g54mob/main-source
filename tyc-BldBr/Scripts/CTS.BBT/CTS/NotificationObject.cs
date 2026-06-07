using CTS.Core;
using CTS.UI;
using UnityEngine;
using UnityEngine.UI;

namespace CTS
{
	public class NotificationObject : CTSBehaviour
	{
		[InjectScope(EGetScope.Children)]
		[SerializeField]
		[Inject(false)]
		private CTSButton _button;

		[SerializeField]
		[Inject(false)]
		private ToolTipsShower _toolTipsShower;

		[SerializeField]
		private GameObject _tooltipsTarget;

		[SerializeField]
		private Image _iconImage;

		public float NextAvailable { get; private set; }

		public bool IsRemovable { get; private set; }

		public NotificationData Data { get; private set; }

		protected override void OnEnabled()
		{
			base.OnEnabled();
			_button.onClick.AddListener(OnButtonClick);
		}

		protected override void OnDisabled()
		{
			base.OnDisabled();
			_button.onClick.RemoveListener(OnButtonClick);
		}

		public void Setup(NotificationData data, bool removable)
		{
			Data = data;
			IsRemovable = removable;
			NextAvailable = Time.time + data.Cooldown;
			_iconImage.overrideSprite = data.Icon;
			_toolTipsShower.SetTootipsInfo(data.TooltipTitle, data.TooltipDescription, _tooltipsTarget);
		}

		private void OnButtonClick()
		{
			if (IsRemovable)
			{
				Object.Destroy(base.gameObject);
			}
		}
	}
}
