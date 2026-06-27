using System;
using System.Collections.Generic;
using System.Text;
using Mandragora.Utils;
using Restory.Data.Devices;
using Restory.Data.Elements;
using Restory.Data.SaveLoad;
using Restory.Data.SaveLoad.Containers;
using Restory.Data.SaveLoad.DataMigration;
using Restory.Gameplay.SaveLoad.Exceptions;
using UnityEngine;
using UnityEngine.Pool;

namespace Restory.Gameplay.Shops.Devices
{
	public class DeviceShopRandomElementsBoxesUniqueTextsService : MonoBehaviour, ISaveableComponent, ISaveableComponentReader, ISaveableComponentWriter, IPostRestoreComponent
	{
		[SerializeField]
		private DeviceShopElementsBoxLotsUniqueTextsCollection textsCollection;

		[SerializeField]
		[BoolButton(25, 0, Red = false)]
		private bool isInDebugMode;

		private readonly Dictionary<string, List<string>> remainingElementsBoxesTexts = new Dictionary<string, List<string>>();

		private DeviceShopRandomElementsBoxesUniqueTextsServiceSaveData restoredState;

		public bool TryGetRemainingLocalizationKeyForElementsBox(ElementsBoxInfo elementsBox, out string textLocalizationKey)
		{
			if (!elementsBox || !remainingElementsBoxesTexts.TryGetValue(elementsBox.ID, out var value) || value.Count == 0)
			{
				if (isInDebugMode)
				{
					Debug.Log("[DeviceShopRandomElementsBoxesUniqueTextsService] tried to find a localization key for elements box with ID '" + elementsBox.ID + "', but there are no unused keys left for that elements box.");
				}
				textLocalizationKey = string.Empty;
				return false;
			}
			int index = UnityEngine.Random.Range(0, value.Count);
			textLocalizationKey = value[index];
			value.RemoveAt(index);
			if (isInDebugMode)
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.AppendLine("[DeviceShopRandomElementsBoxesUniqueTextsService] found localization key '" + textLocalizationKey + "' for elements box with ID '" + elementsBox.ID + "', " + $"keys for that elements box remaining (total count - {value.Count}):");
				foreach (string item in value)
				{
					stringBuilder.AppendLine(item);
				}
				Debug.Log(stringBuilder.ToString());
			}
			return true;
		}

		public object CaptureState()
		{
			try
			{
				List<string> value;
				using (CollectionPool<List<string>, string>.Get(out value))
				{
					foreach (DeviceShopElementsBoxLotsUniqueTexts uniqueText in textsCollection.UniqueTexts)
					{
						if (!uniqueText.ElementsBox || !remainingElementsBoxesTexts.TryGetValue(uniqueText.ElementsBox.ID, out var value2))
						{
							continue;
						}
						foreach (string localizationKey in uniqueText.LocalizationKeys)
						{
							if (!IsKeyInCollection(localizationKey, value2))
							{
								value.Add(localizationKey);
							}
						}
					}
					return new DeviceShopRandomElementsBoxesUniqueTextsServiceSaveData
					{
						UsedKeys = value.ToArray()
					};
				}
			}
			catch (Exception innerException)
			{
				Debug.LogException(new CaptureProgressException(base.gameObject, innerException));
				return null;
			}
		}

		public void RestoreState(object state)
		{
			try
			{
				restoredState = DataMigrationWizard.Migrate<DeviceShopRandomElementsBoxesUniqueTextsServiceSaveData>(state, base.gameObject);
			}
			catch (Exception innerException)
			{
				Debug.LogException(new RestoreProgressException(base.gameObject, state, innerException));
			}
		}

		public void PostRestore()
		{
			if (restoredState != null)
			{
				remainingElementsBoxesTexts.Clear();
				{
					foreach (DeviceShopElementsBoxLotsUniqueTexts uniqueText in textsCollection.UniqueTexts)
					{
						if (!uniqueText.ElementsBox)
						{
							continue;
						}
						if (!remainingElementsBoxesTexts.TryGetValue(uniqueText.ElementsBox.ID, out var value))
						{
							value = new List<string>();
							remainingElementsBoxesTexts[uniqueText.ElementsBox.ID] = value;
						}
						foreach (string localizationKey in uniqueText.LocalizationKeys)
						{
							if (!IsKeyInCollection(localizationKey, restoredState.UsedKeys))
							{
								value.Add(localizationKey);
							}
						}
					}
					return;
				}
			}
			foreach (DeviceShopElementsBoxLotsUniqueTexts uniqueText2 in textsCollection.UniqueTexts)
			{
				List<string> value2 = new List<string>(uniqueText2.LocalizationKeys);
				remainingElementsBoxesTexts.Add(uniqueText2.ElementsBox.ID, value2);
			}
		}

		private static bool IsKeyInCollection(string localizationKey, IEnumerable<string> keysCollection)
		{
			foreach (string item in keysCollection)
			{
				if (localizationKey == item)
				{
					return true;
				}
			}
			return false;
		}
	}
}
