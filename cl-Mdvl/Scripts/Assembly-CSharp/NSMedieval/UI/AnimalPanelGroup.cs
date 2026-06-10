using System;
using NSEipix;
using NSEipix.Base;
using NSEipix.View.UI;
using NSMedieval.Controllers;
using NSMedieval.Manager;
using NSMedieval.State;
using NSMedieval.UI.Utils;
using NSMedieval.View;
using NSMedieval.View.Animals;
using NSMedieval.WorldMap;
using TMPro;
using UnityEngine;

namespace NSMedieval.UI
{
	public abstract class AnimalPanelGroup : LayoutGroupItemView
	{
		[SerializeField]
		private SoundButton selectTargetButton;

		[SerializeField]
		private TMP_Text animalKind;

		[SerializeField]
		private TMP_Text animalName;

		[SerializeField]
		private TMP_Text animalAge;

		[NonSerialized]
		private AnimalInstance animal;

		public AnimalInstance Animal => animal;

		public string AnimalKind => animalKind.text;

		public string AnimalName => animalName.text;

		public int AnimalAge => Animal.AgeInDays;

		public void SetAnimal(AnimalInstance animalInstance)
		{
			animal = animalInstance;
			UpdateData();
		}

		private void OnEnable()
		{
			MonoSingleton<AnimalController>.Instance.OrderGivenFromAnimalUIEvent += OnOrderGivenFromAnimalUI;
			MonoSingleton<AnimalController>.Instance.PetOwnerChangedEvent += OnPetOwnerChanged;
		}

		private void OnDisable()
		{
			if (MonoSingleton<AnimalController>.IsInstantiated())
			{
				MonoSingleton<AnimalController>.Instance.OrderGivenFromAnimalUIEvent -= OnOrderGivenFromAnimalUI;
				MonoSingleton<AnimalController>.Instance.PetOwnerChangedEvent -= OnPetOwnerChanged;
			}
		}

		protected virtual void Start()
		{
			selectTargetButton.AddCleanListener(OnSelectTargetClick);
		}

		protected override void OnDestroy()
		{
			animal = null;
			base.OnDestroy();
		}

		private void OnSelectTargetClick()
		{
			AnimalInstance byUniqueId = MonoSingleton<AnimalManager>.Instance.GetByUniqueId(Animal.UniqueId);
			if (byUniqueId == null)
			{
				foreach (CaravanInstance caravan in MonoSingleton<NSMedieval.WorldMap.WorldMap>.Instance.Data.Caravans)
				{
					foreach (CreatureBase creature in caravan.Creatures)
					{
						if (creature.UniqueId == Animal.UniqueId)
						{
							MonoSingleton<TaskController>.Instance.WaitForNextFrameUnscaled().Then(delegate
							{
								MonoSingleton<CaravanController>.Instance.SelectedCaravan(caravan);
							});
							MonoSingleton<UIController>.Instance.LinkClicked(string.Empty);
							return;
						}
					}
				}
				return;
			}
			AnimalView agentView = byUniqueId.GetAgentView<AnimalView>();
			if (!(agentView == null))
			{
				SelectTarget(agentView);
			}
		}

		private void SelectTarget(SelectableObject selectableObject)
		{
			MonoSingleton<UIController>.Instance.OverviewPanelManager.Close();
			MonoSingleton<UIPanelManager>.Instance.CloseAllOpened();
			MonoSingleton<RtsCamera>.Instance.JumpToAndFollow(selectableObject.transform);
			MonoSingleton<SelectableObjectManager>.Instance.SelectObject(selectableObject);
		}

		protected virtual void UpdateData()
		{
			string localizedAlmanacLink = UiUtils.GetLocalizedAlmanacLink(LocKeyUtils.GetName(Animal.Blueprint.LocKeys));
			animalKind.SetText(localizedAlmanacLink + " (" + AnimalUtils.GetLocalizedGender(Animal) + ")");
			string text = MonoSingleton<LocalizationController>.Instance.GetText(LocKeyUtils.GetName(Animal.LifePhase.LocKeys));
			animalAge.SetText(UiUtils.GetTimeFormatByDays(Animal.AgeInDays) + " (" + text + ")");
			animalName.SetText(Animal.GetFullName());
		}

		protected abstract void OnPetOwnerChanged(AnimalInstance arg1, CreatureBase arg2);

		protected abstract void OnOrderGivenFromAnimalUI(AnimalInstance animalInstance);
	}
}
