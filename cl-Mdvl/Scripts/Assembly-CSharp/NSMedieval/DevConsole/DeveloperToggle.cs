using I2.Loc;
using NSEipix.Base;
using NSEipix.View.UI;
using NSMedieval.Controllers;
using NSMedieval.UI;
using UnityEngine;

namespace NSMedieval.DevConsole
{
	[RequireComponent(typeof(DeveloperToggleHelper))]
	public class DeveloperToggle : SoundButton
	{
		private DeveloperToggleHelper developerToggleHelper;

		protected override void Start()
		{
			if ((object)developerToggleHelper == null)
			{
				developerToggleHelper = GetComponent<DeveloperToggleHelper>();
			}
			base.onClick.AddListener(delegate
			{
				ToggleImage(!developerToggleHelper.Toggle);
			});
		}

		public void SetupButton(string name, string tooltip = "")
		{
			if ((object)developerToggleHelper == null)
			{
				developerToggleHelper = GetComponent<DeveloperToggleHelper>();
			}
			GetComponentInChildren<Localize>().SetTerm(name);
			GetComponent<TooltipViewNew>().SetSingleLineTooltip(MonoSingleton<LocalizationController>.Instance.GetText(tooltip));
		}

		public void ToggleImage(bool value)
		{
			developerToggleHelper.ToggleImage(value);
		}

		public void SetActive(bool active)
		{
			base.gameObject.SetActive(active);
		}

		public void ResetButton()
		{
			SetActive(active: false);
			base.interactable = true;
			base.onClick.RemoveAllListeners();
			if ((object)developerToggleHelper == null)
			{
				developerToggleHelper = GetComponent<DeveloperToggleHelper>();
			}
			base.onClick.AddListener(delegate
			{
				ToggleImage(!developerToggleHelper.Toggle);
			});
			GetComponentInChildren<Localize>().SetTerm(string.Empty);
			GetComponent<TooltipViewNew>().ClearLines();
		}
	}
}
