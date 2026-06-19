#define LOG_LEVEL_VERBOSE
using System;
using I2.Loc;
using TH20.UI;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

namespace TH20
{
	public class FoundationStatusMenu : AnimatedMenuBase
	{
		[SerializeField]
		private TMP_Text _goldText;

		[SerializeField]
		private TMP_Text _silverText;

		[SerializeField]
		private TMP_Text _remixBadgeText;

		[SerializeField]
		private TMP_Text _foundationValueText;

		[SerializeField]
		private TMP_Text _foundationShareValueText;

		[SerializeField]
		private TMP_Text _organisationNameText;

		[FormerlySerializedAs("_steamAvatarGameObject")]
		[SerializeField]
		private GameObject _playerAvatarGameObject;

		[SerializeField]
		private PlayerAvatar _playerAvatar;

		[SerializeField]
		private DynamicButton _renameFoundationButton;

		[SerializeField]
		private TooltipSpawner _tooltip;

		[SerializeField]
		private TooltipSpawner _shareTooltip;

		private Metagame _metagame;

		private HUD _hud;

		private FoundationRenameMenu _foundationRenameMenu;

		public void Setup(Metagame metagame, HUD hud)
		{
			_metagame = metagame;
			_hud = hud;
			_renameFoundationButton.onPrimaryDown.AddListener(RenameFoundationButtonClicked);
			_tooltip.SetDataProvider(OnTooltip);
			_shareTooltip.SetDataProvider(OnTooltip);
		}

		private void OnTooltip(Tooltip tooltip)
		{
			string organisationValueDetail_CS = ScriptLocalization.Menu_Metagame_Tooltips.OrganisationValueDetail_CS;
			organisationValueDetail_CS = organisationValueDetail_CS.Replace("{[VALUE]}", StringUtils.FormatCurrency(_metagame.TotalFoundationValue()));
			organisationValueDetail_CS = organisationValueDetail_CS.Replace("{[NUMSHARES]}", StringUtils.FormatNumber(_metagame.GetNumShares()));
			organisationValueDetail_CS = organisationValueDetail_CS.Replace("{[SHAREPRICE]}", StringUtils.FormatSharePrice(_metagame.GetShareValue()));
			tooltip.Text = organisationValueDetail_CS;
		}

		public override void OpenMenu()
		{
			base.OpenMenu();
			Refresh();
			Logging.Info(LogChannels.GUI, "OpenMenu (FoundationStatusMenu)");
		}

		public override void CloseMenu()
		{
			if (_foundationRenameMenu != null)
			{
				_hud.DestroyMenu(_foundationRenameMenu);
			}
			base.CloseMenu();
			Logging.Info(LogChannels.GUI, "CloseMenu (FoundationStatusMenu)");
		}

		public override bool AreTooltipsEnabled()
		{
			if (base.AreTooltipsEnabled())
			{
				return !_hud.IsOptionsMenuOpen;
			}
			return false;
		}

		public void Refresh()
		{
			_goldText.text = StringUtils.FormatNumber(_metagame.TotalStars());
			_silverText.text = StringUtils.FormatNumber(_metagame.TotalSilver());
			_remixBadgeText.text = StringUtils.FormatNumber(_metagame.TotalRemixBadges());
			int num = _metagame.TotalFoundationValue();
			float shareValue = _metagame.GetShareValue();
			_foundationValueText.text = $"{StringUtils.FormatCurrencyWithoutSymbol(num)}";
			_foundationShareValueText.text = $"{StringUtils.FormatShareValueWithoutSymbol(shareValue)}";
			_organisationNameText.text = _metagame.OrganisationName;
			if (OnlineManager.IsInitializedAndLoggedOn())
			{
				GameObjectUtils.SetActive(_playerAvatarGameObject, isActive: true);
				_playerAvatar.PlayerID = OnlineManager.GetLocalPlayerID();
			}
			else
			{
				GameObjectUtils.SetActive(_playerAvatarGameObject, isActive: false);
			}
		}

		private void RenameFoundationButtonClicked()
		{
			if (_hud != null && !_hud.IsFullscreenMenuOpen() && !_hud.IsOptionsMenuOpen)
			{
				_foundationRenameMenu = _hud.CreateMenu<FoundationRenameMenu>();
				_foundationRenameMenu.Setup(_metagame);
				FoundationRenameMenu foundationRenameMenu = _foundationRenameMenu;
				foundationRenameMenu.OnClosed = (Action)Delegate.Combine(foundationRenameMenu.OnClosed, (Action)delegate
				{
					_foundationRenameMenu = null;
					Refresh();
				});
			}
		}
	}
}
