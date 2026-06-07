using System;
using ManagementScripts;
using SimulationScripts.BibiteScripts;
using TMPro;
using UIScripts.InfoHandles;
using UnityEngine;

namespace UIScripts.UIReferences
{
	public class SpeciesInfoHandle : MonoBehaviour
	{
		[NonSerialized]
		public Species species;

		[SerializeField]
		private TextMeshProUGUI speciesIndex;

		[SerializeField]
		private TextMeshProUGUI speciesName;

		[SerializeField]
		private FloatValueTextHandle speciesCount;

		[SerializeField]
		private FloatValueTextHandle speciesEnergy;

		public int count => species.count;

		public float energy => species.energy;

		public void InitElement(Species speciesRef)
		{
			species = speciesRef;
			speciesName.text = species.name;
			UpdateInfo();
		}

		public void UpdateInfo()
		{
			speciesCount.UpdateValue(species.count);
			speciesEnergy.UpdateValue(species.energy);
		}

		public void UpdateIndex(int i)
		{
			speciesIndex.text = $"{i}.";
		}

		public void OnClick()
		{
			UserControl.Instance.SelectRandomBibiteOfSpecies(species);
		}
	}
}
