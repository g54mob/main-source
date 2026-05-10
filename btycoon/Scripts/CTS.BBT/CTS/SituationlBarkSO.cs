using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Tables;

namespace CTS
{
	[CreateAssetMenu(menuName = "BBT/Bark/SituationnalBarks", fileName = "NeedTheNameSituationFirst")]
	public class SituationlBarkSO : ScriptableObject
	{
		[SerializeField]
		private float _chanceToPop;

		[SerializeField]
		private List<LocalizedString> _barkLocalizedString;

		[SerializeField]
		[Foldout("Setup")]
		private LocalizedStringTable localizedStringTable;

		[SerializeField]
		[Foldout("Setup")]
		private StringTable StringTableByDefault;

		[SerializeField]
		[Foldout("Setup")]
		private string _keyforTable;

		public LocalizedString GiveaLocalizedString()
		{
			float num = Random.Range(0f, 100f);
			if (num >= _chanceToPop)
			{
				Debug.LogWarning("You didn't pass :  " + num + " Is not under : " + _chanceToPop);
				return null;
			}
			int index = Random.Range(0, _barkLocalizedString.Count);
			return _barkLocalizedString[index];
		}

		[Button(null, EButtonEnableMode.Always)]
		public void PopulateBarkList()
		{
			if (StringTableByDefault == null)
			{
				Debug.LogError("Table de localisation non définie !");
				return;
			}
			_barkLocalizedString.Clear();
			UpdateInEditor(StringTableByDefault);
		}

		private void UpdateInEditor(StringTable table)
		{
			foreach (KeyValuePair<long, StringTableEntry> item2 in table)
			{
				long key = item2.Key;
				SharedTableData.SharedTableEntry entry = table.SharedData.GetEntry(key);
				if (entry != null && entry.Metadata != null && (string.IsNullOrEmpty(_keyforTable) || entry.Key.ToString().ToLowerInvariant().Contains(_keyforTable.ToLowerInvariant())))
				{
					LocalizedString item = new LocalizedString
					{
						TableReference = table.TableCollectionName,
						TableEntryReference = key
					};
					if (!_barkLocalizedString.Contains(item))
					{
						_barkLocalizedString.Add(item);
					}
				}
			}
		}
	}
}
