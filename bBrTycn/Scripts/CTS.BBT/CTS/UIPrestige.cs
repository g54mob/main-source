using CTS.Core;
using TMPro;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.UI;

namespace CTS
{
	public class UIPrestige : CTSBehaviour
	{
		[SerializeField]
		private TMP_Text _levelText;

		[SerializeField]
		private Image _fillImage;

		[SerializeField]
		private LocalizedString _levelString;

		[InjectScope(EGetScope.Singleton)]
		[SerializeField]
		[Inject(false)]
		private Prestige _prestige;

		protected override void OnAwake()
		{
			Prestige.PrestigeChanged += Prestige_PrestigeChanged;
			Prestige.PrestigeLevelChanged += Prestige_PrestigeLevelChanged;
		}

		private void Start()
		{
			_levelString.StringChanged += OnLocaleChanged;
			Prestige_PrestigeChanged(_prestige.CurrentPrestigeLevel, _prestige.CurrentPrestige);
			Prestige_PrestigeLevelChanged(_prestige.CurrentPrestigeLevel);
		}

		private void OnLocaleChanged(string value)
		{
			_levelText.text = value + " " + _prestige.CurrentPrestigeLevel.Level;
		}

		private void OnDestroy()
		{
			Prestige.PrestigeChanged -= Prestige_PrestigeChanged;
			Prestige.PrestigeLevelChanged -= Prestige_PrestigeLevelChanged;
			_levelString.StringChanged -= OnLocaleChanged;
		}

		private void Prestige_PrestigeChanged(PrestigeLevelData currentPrestige, float current)
		{
			_fillImage.fillAmount = Mathf.InverseLerp(currentPrestige.PrestigeRequired, _prestige.GetNextStepPrestige(), current);
		}

		private void Prestige_PrestigeLevelChanged(PrestigeLevelData newPrestige)
		{
			_levelText.text = _levelString.GetLocalizedString() + " " + newPrestige.Level;
		}
	}
}
