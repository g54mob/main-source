using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Restory.Gameplay.TextureMasks;
using UnityEngine;
using UnityEngine.Pool;

namespace Restory.Data.Elements.ElementTypes
{
	[CreateAssetMenu(menuName = "Restory/Elements/ElementTypes/DirtTypesMaskPresetsTable", fileName = "DirtTypesMaskPresetsTable")]
	public class DirtTypesMaskPresetsTable : ScriptableObject
	{
		[Serializable]
		private class Entry
		{
			public DirtType[] DirtTypes = new DirtType[0];

			public MaskPresetInfoBase MaskPreset;
		}

		[SerializeField]
		private Entry[] entries = new Entry[0];

		public bool TryGetMaskPresetByDirtTypes(ICollection<DirtType> dirtTypes, out MaskPresetInfoBase maskCreatorPreset)
		{
			if (dirtTypes.Count == 0)
			{
				maskCreatorPreset = null;
				return false;
			}
			List<Entry> list = CollectionPool<List<Entry>, Entry>.Get();
			Entry[] array = entries;
			foreach (Entry entry in array)
			{
				if (entry != null)
				{
					list.Add(entry);
				}
			}
			for (int num = list.Count - 1; num >= 0; num--)
			{
				Entry entry2 = list[num];
				if (entry2.DirtTypes.Length < dirtTypes.Count)
				{
					list.Remove(entry2);
				}
				else
				{
					DirtType[] dirtTypes2 = entry2.DirtTypes;
					foreach (DirtType dirtType in dirtTypes2)
					{
						if ((bool)dirtType && !dirtTypes.Contains(dirtType))
						{
							list.Remove(entry2);
							break;
						}
					}
				}
			}
			if (list.Count == 0)
			{
				StringBuilder stringBuilder = new StringBuilder();
				foreach (DirtType dirtType2 in dirtTypes)
				{
					stringBuilder.Append(" '" + dirtType2.name + "' ");
				}
				Debug.LogError(string.Format("[{0}] tried to get mask by dirt types {1}, ", "DirtTypesMaskPresetsTable", stringBuilder) + "but this configuration of dirt types does not correspond to any mask preset!");
				CollectionPool<List<Entry>, Entry>.Release(list);
				maskCreatorPreset = null;
				return false;
			}
			if (list.Count > 1)
			{
				StringBuilder stringBuilder2 = new StringBuilder();
				foreach (DirtType dirtType3 in dirtTypes)
				{
					stringBuilder2.Append(" '" + dirtType3.name + "' ");
				}
				StringBuilder stringBuilder3 = new StringBuilder();
				foreach (Entry item in list)
				{
					stringBuilder3.Append(" '" + item.MaskPreset.name + "' ");
				}
				Debug.LogError(string.Format("[{0}] tried to get mask by dirt types {1}, ", "DirtTypesMaskPresetsTable", stringBuilder2) + $"but this configuration of dirt types corresponds to more than one presets: {stringBuilder3} !");
				CollectionPool<List<Entry>, Entry>.Release(list);
				maskCreatorPreset = null;
				return false;
			}
			maskCreatorPreset = list[0].MaskPreset;
			CollectionPool<List<Entry>, Entry>.Release(list);
			return true;
		}

		public List<MaskPresetInfoBase> GetPresetsWithAllowedDirtTypes(IEnumerable<DirtType> allowedDirtTypes)
		{
			return (from entry in entries ?? Array.Empty<Entry>()
				where (entry?.DirtTypes ?? Array.Empty<DirtType>()).All(allowedDirtTypes.Contains<DirtType>)
				select entry.MaskPreset).Reverse().ToList();
		}

		public IReadOnlyCollection<DirtType> GetDirtTypesInMaskPreset(MaskPresetInfoBase preset)
		{
			if (!preset)
			{
				return Array.Empty<DirtType>();
			}
			Entry[] array = entries;
			foreach (Entry entry in array)
			{
				if (entry != null && entry.MaskPreset.ID == preset.ID)
				{
					return entry.DirtTypes;
				}
			}
			return Array.Empty<DirtType>();
		}
	}
}
