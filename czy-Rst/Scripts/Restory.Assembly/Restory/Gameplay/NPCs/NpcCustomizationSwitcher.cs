using System;
using Restory.Data.Microstories;
using UnityEngine;

namespace Restory.Gameplay.NPCs
{
	public class NpcCustomizationSwitcher : MonoBehaviour
	{
		[Serializable]
		private class CustomizationElement
		{
			public NpcCustomizationOptions CustomizationOption;

			public GameObject[] CustomizationObjects;

			private static NpcCustomizationOptions[] customizationOptions = new NpcCustomizationOptions[6]
			{
				NpcCustomizationOptions.Glasses,
				NpcCustomizationOptions.Hat,
				NpcCustomizationOptions.Necktie,
				NpcCustomizationOptions.BowTie,
				NpcCustomizationOptions.StuddedCollar,
				NpcCustomizationOptions.Choker
			};
		}

		[SerializeField]
		private CustomizationElement[] customizationElements = new CustomizationElement[0];

		public void SetCustomization(NpcCustomizationOptions customizationOptions)
		{
			CustomizationElement[] array = customizationElements;
			foreach (CustomizationElement customizationElement in array)
			{
				bool active = customizationOptions.HasFlag(customizationElement.CustomizationOption);
				GameObject[] customizationObjects = customizationElement.CustomizationObjects;
				foreach (GameObject gameObject in customizationObjects)
				{
					if ((bool)gameObject)
					{
						gameObject.SetActive(active);
					}
				}
			}
		}

		public void Clean()
		{
			TurnOffAllCustomizationObjects();
		}

		private void TurnOffAllCustomizationObjects()
		{
			CustomizationElement[] array = customizationElements;
			for (int i = 0; i < array.Length; i++)
			{
				GameObject[] customizationObjects = array[i].CustomizationObjects;
				foreach (GameObject gameObject in customizationObjects)
				{
					if ((bool)gameObject)
					{
						gameObject.SetActive(value: false);
					}
				}
			}
		}
	}
}
