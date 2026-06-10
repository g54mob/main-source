using System;
using NSMedieval.BuildingComponents;
using NSMedieval.Model;
using NSMedieval.UI.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace NSMedieval.UI
{
	public class AnimalPenListEntry : MonoBehaviour
	{
		[SerializeField]
		private Image image;

		[SerializeField]
		private Image backgroundImage;

		[SerializeField]
		private Button toggleButton;

		[SerializeField]
		private Graphic toggleGraphicCheckmark;

		[SerializeField]
		private TMP_Text text;

		[NonSerialized]
		private Animal animal;

		[NonSerialized]
		private PenMarkerComponentInstance penMarkerInstance;

		private bool listenerInitialized;

		public Button Toggle => toggleButton;

		public void Init(Animal animal, PenMarkerComponentInstance penMarkerInstance)
		{
			this.penMarkerInstance = penMarkerInstance;
			this.animal = animal;
			text.SetText(AnimalUtils.GetLocalizedName(animal));
			CheckInitListener();
			RefreshCheckbox();
		}

		private void OnDestroy()
		{
			penMarkerInstance = null;
			animal = null;
		}

		private void CheckInitListener()
		{
			if (listenerInitialized)
			{
				return;
			}
			listenerInitialized = true;
			toggleButton.onClick.AddListener(delegate
			{
				AnimalPenInstance animalPen = penMarkerInstance.GetAnimalPen();
				if (animalPen != null)
				{
					bool allowed = !penMarkerInstance.IsAnimalAllowed(animal);
					foreach (PenMarkerComponentInstance penMarker in animalPen.PenMarkers)
					{
						penMarker.SetAnimalAllowed(animal, allowed);
					}
					animalPen.OnAnimalsChanged();
					RefreshCheckbox();
				}
			});
		}

		private void RefreshCheckbox()
		{
			bool active = penMarkerInstance.IsAnimalAllowed(animal);
			toggleGraphicCheckmark.gameObject.SetActive(active);
		}
	}
}
