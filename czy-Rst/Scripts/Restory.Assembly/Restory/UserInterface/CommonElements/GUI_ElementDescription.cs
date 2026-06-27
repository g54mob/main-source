using System;
using Restory.Data.Localization;
using UnityEngine;
using Zenject;

namespace Restory.UserInterface.CommonElements
{
	public class GUI_ElementDescription : MonoBehaviour, IGuiElementDescription
	{
		[SerializeField]
		private string descriptionKey = string.Empty;

		private LocalizationSystem localizationSystem;

		public string Description
		{
			get
			{
				string translation = descriptionKey;
				if (localizationSystem != null)
				{
					translation = localizationSystem.GetTranslation(descriptionKey);
				}
				else
				{
					Debug.LogError("localizationSystem is null. Return localization key as result", base.gameObject);
				}
				return translation;
			}
			set
			{
				descriptionKey = value;
				this.OnDescriptionChange?.Invoke();
			}
		}

		public event Action OnDescriptionChange;

		[Inject]
		private void Construct(LocalizationSystem localizationSystem)
		{
			this.localizationSystem = localizationSystem;
		}
	}
}
