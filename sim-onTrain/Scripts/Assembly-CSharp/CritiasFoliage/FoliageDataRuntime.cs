using System;
using System.Collections.Generic;
using UnityEngine;

namespace CritiasFoliage
{
	public class FoliageDataRuntime
	{
		public Dictionary<int, FoliageCellDataRuntime> m_FoliageData = new Dictionary<int, FoliageCellDataRuntime>();

		public void RemoveFoliageInstance(Guid guid)
		{
			foreach (FoliageCellDataRuntime value in m_FoliageData.Values)
			{
				RemoveFoliageInstanceCell(0, guid, value, ignoreDifferentHash: false);
			}
		}

		public void RemoveFoliageInstance(int typeHash, Guid guid)
		{
			foreach (FoliageCellDataRuntime value in m_FoliageData.Values)
			{
				RemoveFoliageInstanceCell(typeHash, guid, value);
			}
		}

		public void RemoveFoliageInstance(int typeHash, Guid guid, Vector3 position)
		{
			if (m_FoliageData.TryGetValue(FoliageCell.MakeHash(position), out var value))
			{
				RemoveFoliageInstanceCell(typeHash, guid, value);
			}
		}

		public void AddFoliageInstance(int typeHash, FoliageInstance instance)
		{
			int keyHash = FoliageCell.MakeHash(instance.m_Position);
			FoliageCellDataRuntime foliageCellDataRuntime;
			if (!m_FoliageData.ContainsKey(keyHash))
			{
				foliageCellDataRuntime = new FoliageCellDataRuntime();
				FoliageCell position = new FoliageCell(instance.m_Position, subdivided: false);
				foliageCellDataRuntime.m_Bounds = position.GetBounds();
				foliageCellDataRuntime.m_Position = position;
				foliageCellDataRuntime.m_FoliageDataSubdivided = new FoliageKeyValuePair<int, FoliageCellSubdividedDataRuntime>[0];
				foliageCellDataRuntime.m_TypeHashLocationsRuntime = new FoliageKeyValuePair<int, FoliageTuple<FoliageInstance[]>>[0];
				m_FoliageData.Add(keyHash, foliageCellDataRuntime);
			}
			foliageCellDataRuntime = m_FoliageData[keyHash];
			int num = Array.FindIndex(foliageCellDataRuntime.m_TypeHashLocationsRuntime, (FoliageKeyValuePair<int, FoliageTuple<FoliageInstance[]>> x) => x.Key == keyHash);
			if (num < 0)
			{
				Array.Resize(ref foliageCellDataRuntime.m_TypeHashLocationsRuntime, foliageCellDataRuntime.m_TypeHashLocationsRuntime.Length + 1);
				num = foliageCellDataRuntime.m_TypeHashLocationsRuntime.Length - 1;
				foliageCellDataRuntime.m_TypeHashLocationsRuntime[num] = new FoliageKeyValuePair<int, FoliageTuple<FoliageInstance[]>>(typeHash, new FoliageTuple<FoliageInstance[]>(new FoliageInstance[0]));
			}
			Array.Resize(ref foliageCellDataRuntime.m_TypeHashLocationsRuntime[num].Value.m_EditTime, foliageCellDataRuntime.m_TypeHashLocationsRuntime[num].Value.m_EditTime.Length + 1);
			foliageCellDataRuntime.m_TypeHashLocationsRuntime[num].Value.m_EditTime[foliageCellDataRuntime.m_TypeHashLocationsRuntime[num].Value.m_EditTime.Length - 1] = instance;
		}

		private void RemoveFoliageInstanceCell(int typeHash, Guid guid, FoliageCellDataRuntime data, bool ignoreDifferentHash = true)
		{
			for (int i = 0; i < data.m_TypeHashLocationsRuntime.Length; i++)
			{
				if (ignoreDifferentHash && data.m_TypeHashLocationsRuntime[i].Key != typeHash)
				{
					continue;
				}
				FoliageTuple<FoliageInstance[]> value = data.m_TypeHashLocationsRuntime[i].Value;
				FoliageInstance[] editTime = null;
				FoliageInstance[] runtimeAppended = null;
				if (value.m_EditTime != null)
				{
					editTime = Array.FindAll(value.m_EditTime, (FoliageInstance x) => x.m_UniqueId != guid);
				}
				if (value.m_RuntimeAppended != null)
				{
					runtimeAppended = Array.FindAll(value.m_RuntimeAppended, (FoliageInstance x) => x.m_UniqueId != guid);
				}
				data.m_TypeHashLocationsRuntime[i].Value.m_EditTime = editTime;
				data.m_TypeHashLocationsRuntime[i].Value.m_RuntimeAppended = runtimeAppended;
			}
		}
	}
}
