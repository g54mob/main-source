using System.Text.RegularExpressions;
using CTS.BBT;
using CTS.BBT.TechTree;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;

namespace CTS
{
	[DefaultExecutionOrder(100)]
	public class LocalizationSO : MonoBehaviour
	{
		[SerializeField]
		private bool _debugMode;

		private string _itemID;

		private LocalizedString _tmpSOName;

		private LocalizedString _tmpSODesc;

		private bool _tmpStateUpdated;

		private AbsBuyableItemSO[] _absItemsSO;

		private TechTreeTechnologySO[] _technologyItemSO;

		private void OnEnable()
		{
			LocalizationSettings.SelectedLocaleChanged += OverrideData;
		}

		private void Awake()
		{
			_absItemsSO = Resources.LoadAll<AbsBuyableItemSO>("Scriptables");
			OverrideData();
		}

		private void OnDisable()
		{
			LocalizationSettings.SelectedLocaleChanged -= OverrideData;
		}

		private void OverrideData(Locale locale = null)
		{
			AbsBuyableItemSO[] absItemsSO = _absItemsSO;
			foreach (AbsBuyableItemSO abs in absItemsSO)
			{
				ProcessAbsItem(abs);
			}
			LocalizationItemSOEvent.Go();
		}

		private void ProcessAbsItem(AbsBuyableItemSO abs)
		{
			string text = ConvertIDForTranslationSystem(abs);
			if ((abs.LocalizationItemSONameKey.IsEmpty || abs.LocalizationItemSODescKey.IsEmpty) && !string.IsNullOrEmpty(text))
			{
				SetLocalizedString(abs, text, "ItemsSO");
			}
			else
			{
				abs.Name = abs.LocalizationItemSONameKey.GetLocalizedString();
				abs.Description = abs.LocalizationItemSODescKey.GetLocalizedString();
			}
			if (abs.Name == "No translation found for '" + text + ".name' in ItemsSO" || abs.Name.Contains("_") || string.IsNullOrEmpty(text))
			{
				SetCustomErrorValue(abs);
			}
		}

		private void SetLocalizedString(AbsBuyableItemSO item, string itemID, string tableName)
		{
			_tmpSOName = new LocalizedString(tableName, itemID + ".name");
			_tmpSODesc = new LocalizedString(tableName, itemID + ".description");
			item.LocalizationItemSONameKey = _tmpSOName;
			item.LocalizationItemSODescKey = _tmpSODesc;
			item.Name = _tmpSOName.GetLocalizedString();
			item.Description = _tmpSODesc.GetLocalizedString();
		}

		private void SetCustomErrorValue(AbsBuyableItemSO item)
		{
			if (_debugMode)
			{
				Debug.LogWarning($"<color=#00C6E5>[Translation System]</color> - The following furniture doesn't have a name or a description defined : {item.name} - {item.LocalizationItemSONameKey}");
			}
			LocalizedString localizedString;
			LocalizedString localizedString2;
			if (!(item is FurnitureSO))
			{
				if (!(item is BuildableElementSO))
				{
					if (item is StockItemSO)
					{
						localizedString = new LocalizedString("ItemsSO", "itemsso.stocks.missingvalue.name");
						localizedString2 = new LocalizedString("ItemsSO", "itemsso.stocks.missingvalue.description");
					}
					else
					{
						localizedString = new LocalizedString("ItemsSO", "itemsso.missingvalue.name");
						localizedString2 = new LocalizedString("ItemsSO", "itemsso.missingvalue.description");
					}
				}
				else
				{
					localizedString = new LocalizedString("ItemsSO", "itemsso.buildables.missingvalue.name");
					localizedString2 = new LocalizedString("ItemsSO", "itemsso.buildables.missingvalue.description");
				}
			}
			else
			{
				localizedString = new LocalizedString("ItemsSO", "itemsso.furnitures.missingvalue.name");
				localizedString2 = new LocalizedString("ItemsSO", "itemsso.furnitures.missingvalue.description");
			}
			item.LocalizationItemSONameKey = localizedString;
			item.LocalizationItemSODescKey = localizedString2;
			item.Name = localizedString.GetLocalizedString();
			item.Description = localizedString2.GetLocalizedString();
		}

		private string ConvertIDForTranslationSystem(AbsBuyableItemSO item)
		{
			string[] value = Regex.Split(item.name, "[_\\s]+");
			if (!(item is FurnitureSO))
			{
				if (!(item is BuildableElementSO))
				{
					if (!(item is SurfaceData))
					{
						if (item is StockItemSO)
						{
							return "itemsso.stocks." + string.Join(".", value).ToLower();
						}
						return string.Empty;
					}
					return "itemsso.surfacedata." + string.Join(".", value).ToLower();
				}
				return "itemsso.buildables." + string.Join(".", value).ToLower();
			}
			return "itemsso.furnitures." + string.Join(".", value).ToLower();
		}
	}
}
