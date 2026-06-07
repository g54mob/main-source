using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VampireSurvivors.Data;
using VampireSurvivors.Data.Weapons;

namespace VampireSurvivors.UI
{
	public class WeaponSelectionItemUI : SelectableUI
	{
		[SerializeField]
		private TextMeshProUGUI _Name;

		[SerializeField]
		private Image _Icon;

		[SerializeField]
		private Image _BanishedIcon;

		[SerializeField]
		private Image _BackgroundImage;

		private WeaponType _type;

		private WeaponData _data;

		private BaseWeaponSelectionPage _page;

		private Button _button;

		public void SetData(BaseWeaponSelectionPage page, WeaponType t, WeaponData d)
		{
		}

		protected override void OnSelected()
		{
		}

		public WeaponType GetWeaponType()
		{
			return default(WeaponType);
		}

		public void DisableButton()
		{
		}

		private void SelectButton()
		{
		}

		private void SetIconSize()
		{
		}
	}
}
