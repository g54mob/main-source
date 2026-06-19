using FullInspector.Generated.SharedInstance;
using I2.Loc;
using TH20.Analytics;
using TH20.UI;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	public class DLCBuyButton : MonoBehaviour
	{
		[SerializeField]
		private SharedInstance_TH20TH20_DLCItemDefinition _dlcDefinition;

		[SerializeField]
		private DynamicButton _button;

		[SerializeField]
		private Image _dlcImage;

		[SerializeField]
		private TooltipSpawner _tooltipSpawner;

		private AnalyticsManager _analyticsManager;

		private MessageBox _messageBox;

		private bool _isInstalled;

		public void Setup(AnalyticsManager analyticsManager, MessageBox messageBox)
		{
			_analyticsManager = analyticsManager;
			_messageBox = messageBox;
			_isInstalled = DLCUtils.IsDLCInstalled(_dlcDefinition.Instance);
			_button.enabled = !_isInstalled;
			_dlcImage.overrideSprite = (_isInstalled ? _dlcDefinition.Instance.Icon : _dlcDefinition.Instance.NotOwnedIcon);
		}

		private void OnEnable()
		{
			_button.onPrimaryDown.AddListener(OnButtonPressed);
			if (_tooltipSpawner != null)
			{
				if (_dlcDefinition.Instance.Name.IsNull())
				{
					_tooltipSpawner.SetDataProvider(null);
				}
				else
				{
					_tooltipSpawner.SetDataProvider(OnTooltip);
				}
			}
		}

		private void OnDisable()
		{
			_button.onPrimaryDown.RemoveListener(OnButtonPressed);
			if (_tooltipSpawner != null)
			{
				_tooltipSpawner.SetDataProvider(null);
			}
		}

		private void OnButtonPressed()
		{
			if (!_dlcDefinition.IsNull())
			{
				ExtraContentMenu.ShowBrowser(_dlcDefinition.Instance, _analyticsManager, _messageBox);
			}
		}

		private void OnTooltip(Tooltip tooltip)
		{
			if (_isInstalled)
			{
				tooltip.Text = string.Format("<size=125%>{0}</size>\n{1}\n<line-height=50%>\n</line-height><color=#159c21><smallcaps><size=115%>{2}</size></smallcaps></color>\n<line-height=50%>\n</line-height>{3}", _dlcDefinition.Instance.Name.Translation, _dlcDefinition.Instance.InstalledDescription.Translation, LocalizationManager.GetTranslation("Misc/Installed"), (!_dlcDefinition.Instance.HowToFindText.IsNull()) ? _dlcDefinition.Instance.HowToFindText.Translation : string.Empty);
			}
			else
			{
				tooltip.Text = $"<size=125%>{_dlcDefinition.Instance.Name.Translation}</size>\n{_dlcDefinition.Instance.Description.Translation}";
			}
		}
	}
}
