using System.Collections.Generic;
using System.Linq;
using Data.Variables;
using UnityEngine;

namespace Data.SaveData.PersistentSOs
{
	[CreateAssetMenu(menuName = "PersistentSOs/Unlocked Menus", fileName = "UnlockedMenusPersistentSO", order = 0)]
	public class UnlockedMenusPersistentSO : AbstractPersistentSO
	{
		[SerializeField]
		private List<BoolVariableSO> _unlockedMenus;

		public IReadOnlyList<BoolVariableSO> UnlockedMenusVariables => _unlockedMenus;

		protected override void ApplyLoadedSaveData(AbstractSaveData saveData)
		{
			UnlockedMenusSaveData unlockedMenusSaveData = saveData as UnlockedMenusSaveData;
			for (int i = 0; i < Mathf.Min(unlockedMenusSaveData.UnlockedMenus.Count, _unlockedMenus.Count); i++)
			{
				_unlockedMenus[i].SetValue(unlockedMenusSaveData.UnlockedMenus[i]);
			}
		}

		public override void ResetToDefaults()
		{
			foreach (BoolVariableSO unlockedMenu in _unlockedMenus)
			{
				if (!(unlockedMenu == null))
				{
					unlockedMenu.SetValue(unlockedMenu.DefaultValue);
				}
			}
		}

		public override AbstractSaveData GetSaveData()
		{
			return new UnlockedMenusSaveData(_unlockedMenus.Select((BoolVariableSO so) => so != null && so.Value).ToList());
		}

		public override bool TryLoadSaveData(string fullPath)
		{
			return TryLoadSaveDataInternal<UnlockedMenusSaveData>(fullPath);
		}
	}
}
