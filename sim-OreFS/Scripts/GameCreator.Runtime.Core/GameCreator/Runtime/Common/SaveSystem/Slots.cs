using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;

namespace GameCreator.Runtime.Common.SaveSystem
{
	[Serializable]
	public class Slots : TSerializableDictionary<int, Slots.Data>, IGameSave
	{
		[Serializable]
		public struct Data
		{
			public string date;

			public string[] keys;
		}

		public int LatestSlot
		{
			get
			{
				int result = -1;
				DateTime t = DateTime.MinValue;
				using Dictionary<int, Data>.Enumerator enumerator = GetEnumerator();
				while (enumerator.MoveNext())
				{
					KeyValuePair<int, Data> current = enumerator.Current;
					if (DateTime.TryParse(current.Value.date, out var result2) && DateTime.Compare(t, result2) <= 0)
					{
						result = current.Key;
						t = result2;
					}
				}
				return result;
			}
		}

		public string SaveID => "slots";

		public bool IsShared => true;

		public LoadMode LoadMode => LoadMode.Greedy;

		public Type SaveType => typeof(Slots);

		public void Update(int slot, string[] keys)
		{
			base[slot] = new Data
			{
				date = DateTime.Now.ToString(CultureInfo.InvariantCulture),
				keys = keys
			};
		}

		public object GetSaveData(bool includeNonSavable)
		{
			return this;
		}

		public Task OnLoad(object value)
		{
			m_Dictionary = (value as Slots)?.m_Dictionary ?? new Dictionary<int, Data>();
			return Task.FromResult(result: true);
		}
	}
}
