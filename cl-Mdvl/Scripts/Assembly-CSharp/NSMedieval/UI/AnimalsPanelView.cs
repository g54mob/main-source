using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.State;
using NSMedieval.UI.Utils;

namespace NSMedieval.UI
{
	public abstract class AnimalsPanelView : OverviewPanelView
	{
		protected string GetAnimalLocalized(AnimalInstance animalInstance)
		{
			return UiUtils.Localize.GetText(LocKeyUtils.GetName(animalInstance.Blueprint.LocKeys)) + " (" + AnimalUtils.GetLocalizedGender(animalInstance) + ")";
		}

		private void OnEnable()
		{
			MonoSingleton<AnimalController>.Instance.AnimalNameChangedEvent += OnNameChange;
			MonoSingleton<AnimalController>.Instance.RemovedAnimalEvent += OnAnimalChange;
			MonoSingleton<AnimalController>.Instance.SpawnAnimalEvent += OnAnimalChange;
		}

		private void OnDisable()
		{
			if (MonoSingleton<AnimalController>.IsInstantiated())
			{
				MonoSingleton<AnimalController>.Instance.AnimalNameChangedEvent -= OnNameChange;
				MonoSingleton<AnimalController>.Instance.RemovedAnimalEvent -= OnAnimalChange;
				MonoSingleton<AnimalController>.Instance.SpawnAnimalEvent -= OnAnimalChange;
			}
		}

		private void OnAnimalChange(AnimalInstance animalInstance)
		{
			Show();
			SortEntries();
		}

		private void OnNameChange(AnimalInstance animalInstance)
		{
			Show();
			SortEntries();
		}
	}
}
