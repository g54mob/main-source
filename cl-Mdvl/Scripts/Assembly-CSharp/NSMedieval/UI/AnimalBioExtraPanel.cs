using System.Collections.Generic;
using System.Text;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.Manager;
using NSMedieval.UI.Utils;
using TMPro;
using TwitchIntegration;
using UnityEngine;

namespace NSMedieval.UI
{
	public class AnimalBioExtraPanel : SelectionExtraPanelBase
	{
		[SerializeField]
		private TMP_InputField animalName;

		[SerializeField]
		private ButtonLayoutItemView twitchNameButton;

		[SerializeField]
		private TMP_Text infoText;

		[SerializeField]
		private FillBarLayoutItemView animalIdLayoutItemView;

		private readonly List<string> tooltipLines = new List<string>();

		private void Start()
		{
			animalName.onDeselect.AddListener(OnNameDeselect);
			animalName.onValueChanged.AddListener(delegate(string value)
			{
				OnNameValueChange(value, inputLocked: true);
			});
			animalName.onEndEdit.AddListener(delegate(string value)
			{
				OnNameValueChange(value, inputLocked: false);
			});
			animalName.onEndEdit.AddListener(OnNameEndEdit);
		}

		private void OnEnable()
		{
			UpdateName();
			if (TwitchManager.IsInitialized && TwitchManager.IsAuthenticated && MonoSingleton<GlobalSaveController>.Instance.GlobalSettings.TwitchNameCommandEnabled)
			{
				twitchNameButton.gameObject.SetActive(value: true);
				twitchNameButton.Button.AddCleanListener(OnTwitchNameButtonClick);
			}
			else
			{
				twitchNameButton.gameObject.SetActive(value: false);
			}
		}

		private void OnDisable()
		{
			if (TwitchManager.IsInitialized)
			{
				twitchNameButton.Button.RemoveAllListeners();
			}
		}

		protected override void SetupTabPanel()
		{
			if (base.Animal != null && !base.Animal.HasDisposed)
			{
				UpdateName();
				UpdateTabPanel();
			}
		}

		protected override void UpdateTabPanel()
		{
			if (base.Animal != null && !base.Animal.HasDisposed && !(base.Animal.Blueprint == null))
			{
				animalIdLayoutItemView.SetText(AnimalUtils.GetLocalizedName(base.Animal.Blueprint));
				tooltipLines.Clear();
				tooltipLines.Add(AnimalUtils.GetLocalizedInfo(base.Animal.Blueprint));
				animalIdLayoutItemView.SetTooltipLines(tooltipLines);
				CreateInfos();
			}
		}

		private void CreateInfos()
		{
			infoText.SetText(string.Empty);
			List<string> modifiers = AnimalUtils.GetModifiers(base.Animal);
			StringBuilder stringBuilder = new StringBuilder();
			foreach (string item in modifiers)
			{
				stringBuilder.AppendLine(item);
			}
			infoText.SetText(stringBuilder.ToString());
		}

		private void UpdateName()
		{
			if (base.Animal != null)
			{
				animalName.text = base.Animal.GetFullName();
			}
		}

		private void OnNameDeselect(string value)
		{
			string strB = value.Trim();
			if (string.CompareOrdinal(base.Animal.GetFullName(), strB) != 0)
			{
				base.Animal.SetName(strB);
				CreateInfos();
				MonoSingleton<AnimalController>.Instance.AnimalNameChanged(base.Animal);
			}
		}

		private void OnNameEndEdit(string nameEntered)
		{
			if (!base.Animal.HasDisposed && !base.Animal.HasDied)
			{
				string strB = nameEntered.Trim();
				if (string.CompareOrdinal(base.Animal.GetFullName(), strB) != 0)
				{
					base.Animal.SetName(strB);
					CreateInfos();
					MonoSingleton<AnimalController>.Instance.AnimalNameChanged(base.Animal);
				}
			}
		}

		private void OnNameValueChange(string nameEntered, bool inputLocked)
		{
			if (!(!animalName.isFocused && inputLocked))
			{
				if (nameEntered.StartsWith(" "))
				{
					animalName.text = nameEntered.TrimStart();
				}
				MonoSingleton<InputManager>.Instance.SetInputEnabled(!inputLocked);
			}
		}

		private void OnTwitchNameButtonClick()
		{
			MonoSingleton<TwitchController>.Instance.ClearUsedTwitchName(base.Animal);
			string twitchName = MonoSingleton<TwitchController>.Instance.GetTwitchName();
			base.Animal.SetName(twitchName);
		}
	}
}
