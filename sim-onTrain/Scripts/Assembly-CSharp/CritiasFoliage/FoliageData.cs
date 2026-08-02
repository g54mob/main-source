using System;
using System.Collections.Generic;
using UnityEngine;

namespace CritiasFoliage
{
	public class FoliageData
	{
		public Dictionary<int, FoliageCellData> m_FoliageData = new Dictionary<int, FoliageCellData>();

		public void RemoveType(int typeHash)
		{
			bool flag = false;
			int num = 0;
			foreach (FoliageCellData value in m_FoliageData.Values)
			{
				if (value.m_TypeHashLocationsEditor.Remove(typeHash))
				{
					flag = true;
					num++;
				}
				foreach (FoliageCellSubdividedData value2 in value.m_FoliageDataSubdivided.Values)
				{
					if (value2.m_TypeHashLocationsEditor.Remove(typeHash))
					{
						flag = true;
						num++;
					}
				}
			}
			if (flag)
			{
				RemoveEmptyData();
				RecalculateBoundsAfterRemove();
			}
		}

		public void RebuildType(int typeHash, bool subdivided)
		{
			Dictionary<string, List<FoliageInstance>> dictionary = new Dictionary<string, List<FoliageInstance>>();
			foreach (FoliageCellData value2 in m_FoliageData.Values)
			{
				if (value2.m_TypeHashLocationsEditor.ContainsKey(typeHash))
				{
					foreach (KeyValuePair<string, List<FoliageInstance>> item in value2.m_TypeHashLocationsEditor[typeHash])
					{
						string key = item.Key;
						if (!dictionary.ContainsKey(key))
						{
							dictionary.Add(key, new List<FoliageInstance>());
						}
						dictionary[key].AddRange(item.Value);
					}
				}
				foreach (FoliageCellSubdividedData value3 in value2.m_FoliageDataSubdivided.Values)
				{
					if (!value3.m_TypeHashLocationsEditor.ContainsKey(typeHash))
					{
						continue;
					}
					foreach (KeyValuePair<string, List<FoliageInstance>> item2 in value3.m_TypeHashLocationsEditor[typeHash])
					{
						string key2 = item2.Key;
						if (!dictionary.ContainsKey(key2))
						{
							dictionary.Add(key2, new List<FoliageInstance>());
						}
						dictionary[key2].AddRange(item2.Value);
					}
				}
			}
			if (dictionary.Count <= 0)
			{
				return;
			}
			RemoveType(typeHash);
			int num = 0;
			foreach (KeyValuePair<string, List<FoliageInstance>> item3 in dictionary)
			{
				string key3 = item3.Key;
				List<FoliageInstance> value = item3.Value;
				num += value.Count;
				AddInstances(typeHash, value, subdivided, key3);
			}
		}

		public void RemoveInstanceGuid(int typeHash, Vector3 position, Guid guid)
		{
			if (!m_FoliageData.TryGetValue(FoliageCell.MakeHash(position), out var value))
			{
				return;
			}
			bool flag = false;
			if (value.m_TypeHashLocationsEditor.ContainsKey(typeHash))
			{
				foreach (List<FoliageInstance> value2 in value.m_TypeHashLocationsEditor[typeHash].Values)
				{
					for (int i = 0; i < value2.Count; i++)
					{
						if (value2[i].m_UniqueId == guid)
						{
							value2.RemoveAt(i);
							flag = true;
							goto end_IL_007d;
						}
					}
					continue;
					end_IL_007d:
					break;
				}
			}
			RemoveEmptyTypeDataCell(value);
			if (IsCellEmpty(value))
			{
				m_FoliageData.Remove(value.GetHashCode());
			}
			if (flag)
			{
				RecalculateBoundsAfterRemove();
			}
		}

		public bool RemoveInstances(int typeHash, Vector3 position, float radius = 0.3f)
		{
			Vector3 min = position - new Vector3(radius, radius, radius);
			Vector3 max = position + new Vector3(radius, radius, radius);
			bool anyRemoved = false;
			bool anyGrassRemoved = false;
			float distanceDelta = radius * radius;
			float x;
			float y;
			float z;
			FoliageCell.IterateMinMax(min, max, subdivided: false, delegate(int hash)
			{
				if (m_FoliageData.ContainsKey(hash))
				{
					FoliageCellData cell = m_FoliageData[hash];
					if (cell.m_TypeHashLocationsEditor.ContainsKey(typeHash))
					{
						foreach (List<FoliageInstance> value2 in cell.m_TypeHashLocationsEditor[typeHash].Values)
						{
							for (int num = value2.Count - 1; num >= 0; num--)
							{
								x = value2[num].m_Position.x - position.x;
								y = value2[num].m_Position.y - position.y;
								z = value2[num].m_Position.z - position.z;
								if (x * x + y * y + z * z < distanceDelta)
								{
									value2.RemoveAt(num);
									anyRemoved = true;
								}
							}
						}
					}
					Vector3 localInCell = GetLocalInCell(min, cell);
					Vector3 localInCell2 = GetLocalInCell(max, cell);
					FoliageCell.IterateMinMax(localInCell, localInCell2, subdivided: true, delegate(int hashLocal)
					{
						if (cell.m_FoliageDataSubdivided.TryGetValue(hashLocal, out var value))
						{
							if (value.m_TypeHashLocationsEditor.ContainsKey(typeHash))
							{
								foreach (List<FoliageInstance> value3 in value.m_TypeHashLocationsEditor[typeHash].Values)
								{
									for (int num2 = value3.Count - 1; num2 >= 0; num2--)
									{
										x = value3[num2].m_Position.x - position.x;
										y = value3[num2].m_Position.y - position.y;
										z = value3[num2].m_Position.z - position.z;
										if (x * x + y * y + z * z < distanceDelta)
										{
											value3.RemoveAt(num2);
											anyGrassRemoved = true;
										}
									}
								}
							}
							RemoveEmptyTypeDataCellSubdivided(value);
							if (IsSubCellEmpty(value))
							{
								cell.m_FoliageDataSubdivided.Remove(hashLocal);
							}
						}
					});
					RemoveEmptyTypeDataCell(cell);
					if (IsCellEmpty(cell))
					{
						m_FoliageData.Remove(hash);
					}
				}
			});
			if (anyRemoved)
			{
				RecalculateBoundsAfterRemove();
			}
			return anyRemoved || anyGrassRemoved;
		}

		public Dictionary<int, List<FoliageInstance>> CollectLabeledInstances(string label)
		{
			Dictionary<int, List<FoliageInstance>> dictionary = new Dictionary<int, List<FoliageInstance>>();
			foreach (FoliageCellData value3 in m_FoliageData.Values)
			{
				foreach (KeyValuePair<int, Dictionary<string, List<FoliageInstance>>> item in value3.m_TypeHashLocationsEditor)
				{
					if (item.Value.TryGetValue(label, out var value) && value.Count > 0)
					{
						if (!dictionary.ContainsKey(item.Key))
						{
							dictionary.Add(item.Key, new List<FoliageInstance>());
						}
						dictionary[item.Key].AddRange(value);
					}
				}
				foreach (FoliageCellSubdividedData value4 in value3.m_FoliageDataSubdivided.Values)
				{
					foreach (KeyValuePair<int, Dictionary<string, List<FoliageInstance>>> item2 in value4.m_TypeHashLocationsEditor)
					{
						if (item2.Value.TryGetValue(label, out var value2) && value2.Count > 0)
						{
							if (!dictionary.ContainsKey(item2.Key))
							{
								dictionary.Add(item2.Key, new List<FoliageInstance>());
							}
							dictionary[item2.Key].AddRange(value2);
						}
					}
				}
			}
			return dictionary;
		}

		public void RemoveInstancesLabeled(string label)
		{
			bool flag = false;
			foreach (FoliageCellData value in m_FoliageData.Values)
			{
				foreach (Dictionary<string, List<FoliageInstance>> value2 in value.m_TypeHashLocationsEditor.Values)
				{
					if (value2.Remove(label))
					{
						flag = true;
					}
				}
				foreach (FoliageCellSubdividedData value3 in value.m_FoliageDataSubdivided.Values)
				{
					foreach (Dictionary<string, List<FoliageInstance>> value4 in value3.m_TypeHashLocationsEditor.Values)
					{
						if (value4.Remove(label))
						{
							flag = true;
						}
					}
				}
			}
			if (flag)
			{
				RemoveEmptyData();
				RecalculateBoundsAfterRemove();
			}
		}

		public void AddInstance(int typeHash, FoliageInstance instance, bool subdivision, string label = "Hand Painted")
		{
			int key = FoliageCell.MakeHash(instance.m_Position);
			if (!m_FoliageData.ContainsKey(key))
			{
				FoliageCellData foliageCellData = new FoliageCellData();
				foliageCellData.m_Position = default(FoliageCell);
				foliageCellData.m_Position.Set(instance.m_Position);
				foliageCellData.m_Bounds = foliageCellData.m_Position.GetBounds();
				foliageCellData.m_BoundsExtended = foliageCellData.m_Bounds;
				m_FoliageData.Add(key, foliageCellData);
			}
			FoliageCellData foliageCellData2 = m_FoliageData[key];
			if (!subdivision)
			{
				if (!foliageCellData2.m_TypeHashLocationsEditor.ContainsKey(typeHash))
				{
					foliageCellData2.m_TypeHashLocationsEditor.Add(typeHash, new Dictionary<string, List<FoliageInstance>>());
				}
				Dictionary<string, List<FoliageInstance>> dictionary = foliageCellData2.m_TypeHashLocationsEditor[typeHash];
				if (!dictionary.ContainsKey(label))
				{
					dictionary.Add(label, new List<FoliageInstance>());
				}
				dictionary[label].Add(instance);
				m_FoliageData[key].m_BoundsExtended.Encapsulate(instance.m_Bounds);
				return;
			}
			Dictionary<int, FoliageCellSubdividedData> foliageDataSubdivided = foliageCellData2.m_FoliageDataSubdivided;
			Vector3 localInCell = GetLocalInCell(instance.m_Position, foliageCellData2);
			int key2 = FoliageCell.MakeHashSubdivided(localInCell);
			if (!foliageDataSubdivided.ContainsKey(key2))
			{
				FoliageCellSubdividedData foliageCellSubdividedData = new FoliageCellSubdividedData();
				foliageCellSubdividedData.m_Position = default(FoliageCell);
				foliageCellSubdividedData.m_Position.SetSubdivided(localInCell);
				foliageCellSubdividedData.m_Bounds = foliageCellSubdividedData.m_Position.GetBoundsSubdivided();
				foliageCellSubdividedData.m_Bounds.center = GetWorldInCell(foliageCellSubdividedData.m_Bounds.center, foliageCellData2);
				foliageDataSubdivided.Add(key2, foliageCellSubdividedData);
			}
			FoliageCellSubdividedData foliageCellSubdividedData2 = foliageDataSubdivided[key2];
			if (!foliageCellSubdividedData2.m_TypeHashLocationsEditor.ContainsKey(typeHash))
			{
				foliageCellSubdividedData2.m_TypeHashLocationsEditor.Add(typeHash, new Dictionary<string, List<FoliageInstance>>());
			}
			Dictionary<string, List<FoliageInstance>> dictionary2 = foliageCellSubdividedData2.m_TypeHashLocationsEditor[typeHash];
			if (!dictionary2.ContainsKey(label))
			{
				dictionary2.Add(label, new List<FoliageInstance>());
			}
			dictionary2[label].Add(instance);
		}

		public void AddInstances(int typeHash, List<FoliageInstance> instances, bool subdivision, string label = "Hand Painted")
		{
			for (int i = 0; i < instances.Count; i++)
			{
				AddInstance(typeHash, instances[i], subdivision, label);
			}
		}

		public void RemoveEmptyData()
		{
			HashSet<int> hashSet = null;
			HashSet<int> hashSet2 = null;
			foreach (KeyValuePair<int, FoliageCellData> foliageDatum in m_FoliageData)
			{
				RemoveEmptyTypeDataCell(foliageDatum.Value);
				if (IsCellEmpty(foliageDatum.Value))
				{
					if (hashSet == null)
					{
						hashSet = new HashSet<int>();
					}
					hashSet.Add(foliageDatum.Key);
				}
				hashSet2?.Clear();
				foreach (KeyValuePair<int, FoliageCellSubdividedData> item in foliageDatum.Value.m_FoliageDataSubdivided)
				{
					RemoveEmptyTypeDataCellSubdivided(item.Value);
					if (IsSubCellEmpty(item.Value))
					{
						if (hashSet2 == null)
						{
							hashSet2 = new HashSet<int>();
						}
						hashSet2.Add(item.Key);
					}
				}
				if (hashSet2 == null || hashSet2.Count <= 0)
				{
					continue;
				}
				foreach (int item2 in hashSet2)
				{
					foliageDatum.Value.m_FoliageDataSubdivided.Remove(item2);
				}
			}
			if (hashSet == null)
			{
				return;
			}
			foreach (int item3 in hashSet)
			{
				m_FoliageData.Remove(item3);
			}
		}

		public int GetInstanceCountLocation(Vector3 position, float radius, bool subdivision)
		{
			int count = 0;
			Vector3 min = position - new Vector3(radius, radius, radius);
			Vector3 max = position + new Vector3(radius, radius, radius);
			float distanceDelta = radius * radius;
			float x;
			float y;
			float z;
			FoliageCell.IterateMinMax(min, max, subdivided: false, delegate(int hash)
			{
				if (m_FoliageData.TryGetValue(hash, out var cell))
				{
					if (!subdivision)
					{
						foreach (Dictionary<string, List<FoliageInstance>> value2 in cell.m_TypeHashLocationsEditor.Values)
						{
							foreach (List<FoliageInstance> value3 in value2.Values)
							{
								for (int i = 0; i < value3.Count; i++)
								{
									x = value3[i].m_Position.x - position.x;
									y = value3[i].m_Position.y - position.y;
									z = value3[i].m_Position.z - position.z;
									if (x * x + y * y + z * z < distanceDelta)
									{
										count++;
									}
								}
							}
						}
						return;
					}
					Vector3 localInCell = GetLocalInCell(min, cell);
					Vector3 localInCell2 = GetLocalInCell(max, cell);
					FoliageCell.IterateMinMax(localInCell, localInCell2, subdivided: true, delegate(int hashLocal)
					{
						if (!cell.m_FoliageDataSubdivided.TryGetValue(hashLocal, out var value))
						{
							return;
						}
						foreach (Dictionary<string, List<FoliageInstance>> value4 in value.m_TypeHashLocationsEditor.Values)
						{
							foreach (List<FoliageInstance> value5 in value4.Values)
							{
								for (int j = 0; j < value5.Count; j++)
								{
									x = value5[j].m_Position.x - position.x;
									y = value5[j].m_Position.y - position.y;
									z = value5[j].m_Position.z - position.z;
									if (x * x + y * y + z * z < distanceDelta)
									{
										int num = count;
										count = num + 1;
									}
								}
							}
						}
					});
				}
			});
			return count;
		}

		public int GetInstanceCount()
		{
			int num = 0;
			foreach (FoliageCellData value in m_FoliageData.Values)
			{
				foreach (int key in value.m_TypeHashLocationsEditor.Keys)
				{
					foreach (List<FoliageInstance> value2 in value.m_TypeHashLocationsEditor[key].Values)
					{
						num += value2.Count;
					}
				}
				foreach (FoliageCellSubdividedData value3 in value.m_FoliageDataSubdivided.Values)
				{
					foreach (int key2 in value3.m_TypeHashLocationsEditor.Keys)
					{
						foreach (List<FoliageInstance> value4 in value3.m_TypeHashLocationsEditor[key2].Values)
						{
							num += value4.Count;
						}
					}
				}
			}
			return num;
		}

		public int GetInstanceCount(int typeHash)
		{
			int num = 0;
			foreach (FoliageCellData value in m_FoliageData.Values)
			{
				if (value.m_TypeHashLocationsEditor.ContainsKey(typeHash))
				{
					foreach (List<FoliageInstance> value2 in value.m_TypeHashLocationsEditor[typeHash].Values)
					{
						num += value2.Count;
					}
				}
				foreach (FoliageCellSubdividedData value3 in value.m_FoliageDataSubdivided.Values)
				{
					if (!value3.m_TypeHashLocationsEditor.ContainsKey(typeHash))
					{
						continue;
					}
					foreach (List<FoliageInstance> value4 in value3.m_TypeHashLocationsEditor[typeHash].Values)
					{
						num += value4.Count;
					}
				}
			}
			return num;
		}

		public HashSet<int> GetFoliageHashes()
		{
			HashSet<int> hashSet = null;
			if (m_FoliageData.Count > 0)
			{
				foreach (FoliageCellData value in m_FoliageData.Values)
				{
					if (value.m_TypeHashLocationsEditor.Count > 0)
					{
						if (hashSet == null)
						{
							hashSet = new HashSet<int>();
						}
						hashSet.UnionWith(value.m_TypeHashLocationsEditor.Keys);
					}
					foreach (FoliageCellSubdividedData value2 in value.m_FoliageDataSubdivided.Values)
					{
						if (value2.m_TypeHashLocationsEditor.Count > 0)
						{
							if (hashSet == null)
							{
								hashSet = new HashSet<int>();
							}
							hashSet.UnionWith(value2.m_TypeHashLocationsEditor.Keys);
						}
					}
				}
			}
			return hashSet;
		}

		public HashSet<string> GetFoliageLabels()
		{
			HashSet<string> hashSet = null;
			foreach (FoliageCellData value in m_FoliageData.Values)
			{
				foreach (Dictionary<string, List<FoliageInstance>> value2 in value.m_TypeHashLocationsEditor.Values)
				{
					if (hashSet == null)
					{
						hashSet = new HashSet<string>();
					}
					hashSet.UnionWith(value2.Keys);
				}
				foreach (FoliageCellSubdividedData value3 in value.m_FoliageDataSubdivided.Values)
				{
					foreach (Dictionary<string, List<FoliageInstance>> value4 in value3.m_TypeHashLocationsEditor.Values)
					{
						if (hashSet == null)
						{
							hashSet = new HashSet<string>();
						}
						hashSet.UnionWith(value4.Keys);
					}
				}
			}
			return hashSet;
		}

		private void RemoveEmptyTypeDataCell(FoliageCellData data)
		{
			if (data.m_TypeHashLocationsEditor.Count <= 0)
			{
				return;
			}
			HashSet<int> hashSet = null;
			foreach (KeyValuePair<int, Dictionary<string, List<FoliageInstance>>> item in data.m_TypeHashLocationsEditor)
			{
				Dictionary<string, List<FoliageInstance>> value = item.Value;
				HashSet<string> hashSet2 = null;
				foreach (KeyValuePair<string, List<FoliageInstance>> item2 in value)
				{
					if (item2.Value.Count <= 0)
					{
						if (hashSet2 == null)
						{
							hashSet2 = new HashSet<string>();
						}
						hashSet2.Add(item2.Key);
					}
				}
				if (hashSet2 != null)
				{
					foreach (string item3 in hashSet2)
					{
						value.Remove(item3);
					}
				}
				if (value.Count <= 0)
				{
					if (hashSet == null)
					{
						hashSet = new HashSet<int>();
					}
					hashSet.Add(item.Key);
				}
			}
			if (hashSet == null)
			{
				return;
			}
			foreach (int item4 in hashSet)
			{
				data.m_TypeHashLocationsEditor.Remove(item4);
			}
		}

		private void RemoveEmptyTypeDataCellSubdivided(FoliageCellSubdividedData data)
		{
			if (data.m_TypeHashLocationsEditor.Count <= 0)
			{
				return;
			}
			HashSet<int> hashSet = null;
			foreach (KeyValuePair<int, Dictionary<string, List<FoliageInstance>>> item in data.m_TypeHashLocationsEditor)
			{
				Dictionary<string, List<FoliageInstance>> value = item.Value;
				HashSet<string> hashSet2 = null;
				foreach (KeyValuePair<string, List<FoliageInstance>> item2 in value)
				{
					if (item2.Value.Count <= 0)
					{
						if (hashSet2 == null)
						{
							hashSet2 = new HashSet<string>();
						}
						hashSet2.Add(item2.Key);
					}
				}
				if (hashSet2 != null)
				{
					foreach (string item3 in hashSet2)
					{
						value.Remove(item3);
					}
				}
				if (value.Count <= 0)
				{
					if (hashSet == null)
					{
						hashSet = new HashSet<int>();
					}
					hashSet.Add(item.Key);
				}
			}
			if (hashSet == null)
			{
				return;
			}
			foreach (int item4 in hashSet)
			{
				data.m_TypeHashLocationsEditor.Remove(item4);
			}
		}

		private bool IsSubCellEmpty(FoliageCellSubdividedData cell)
		{
			foreach (Dictionary<string, List<FoliageInstance>> value in cell.m_TypeHashLocationsEditor.Values)
			{
				foreach (List<FoliageInstance> value2 in value.Values)
				{
					if (value2.Count > 0)
					{
						return false;
					}
				}
			}
			return true;
		}

		private bool IsCellEmpty(FoliageCellData cell)
		{
			foreach (FoliageCellSubdividedData value in cell.m_FoliageDataSubdivided.Values)
			{
				if (!IsSubCellEmpty(value))
				{
					return false;
				}
			}
			foreach (Dictionary<string, List<FoliageInstance>> value2 in cell.m_TypeHashLocationsEditor.Values)
			{
				foreach (List<FoliageInstance> value3 in value2.Values)
				{
					if (value3.Count > 0)
					{
						return false;
					}
				}
			}
			return true;
		}

		private void RecalculateBoundsAfterRemove()
		{
			foreach (FoliageCellData value in m_FoliageData.Values)
			{
				value.m_BoundsExtended = value.m_Bounds;
				foreach (Dictionary<string, List<FoliageInstance>> value2 in value.m_TypeHashLocationsEditor.Values)
				{
					foreach (List<FoliageInstance> value3 in value2.Values)
					{
						for (int i = 0; i < value3.Count; i++)
						{
							value.m_BoundsExtended.Encapsulate(value3[i].m_Bounds);
						}
					}
				}
			}
		}

		private Vector3 GetLocalInCell(Vector3 worldPosition, FoliageCellData cell)
		{
			return worldPosition - cell.m_Bounds.min;
		}

		private Vector3 GetWorldInCell(Vector3 localPosition, FoliageCellData cell)
		{
			return localPosition + cell.m_Bounds.min;
		}
	}
}
