using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using AwesomeTechnologies.Utility;
using UnityEngine;

namespace AwesomeTechnologies.Vegetation.PersistentStorage
{
	[Serializable]
	[PreferBinarySerialization]
	public class PersistentVegetationStoragePackage : ScriptableObject
	{
		public List<PersistentVegetationCell> PersistentVegetationCellList = new List<PersistentVegetationCell>();

		public List<PersistentVegetationInstanceInfo> PersistentVegetationInstanceInfoList = new List<PersistentVegetationInstanceInfo>();

		public List<byte> PersistentVegetationInstanceSourceList = new List<byte>();

		[SerializeField]
		private bool _instanceInfoDirty;

		public bool Initialized => PersistentVegetationCellList.Count > 0;

		public void Dispose()
		{
			for (int i = 0; i <= PersistentVegetationCellList.Count - 1; i++)
			{
				PersistentVegetationCellList[i].Dispose();
			}
		}

		public void ExportToFile(string filename)
		{
			ExportData graph = new ExportData
			{
				PersistentVegetationCellList = PersistentVegetationCellList,
				PersistentVegetationInstanceInfoList = PersistentVegetationInstanceInfoList,
				PersistentVegetationInstanceSourceList = PersistentVegetationInstanceSourceList
			};
			BinaryFormatter binaryFormatter = SerializationSurrogateUtil.GetBinaryFormatter();
			FileStream fileStream = File.Create(filename);
			binaryFormatter.Serialize(fileStream, graph);
			fileStream.Close();
		}

		public void ExportToStream(Stream outputStream)
		{
			ExportData graph = new ExportData
			{
				PersistentVegetationCellList = PersistentVegetationCellList,
				PersistentVegetationInstanceInfoList = PersistentVegetationInstanceInfoList,
				PersistentVegetationInstanceSourceList = PersistentVegetationInstanceSourceList
			};
			SerializationSurrogateUtil.GetBinaryFormatter().Serialize(outputStream, graph);
			outputStream.Position = 0L;
		}

		public void ImportFromStream(Stream inputStream)
		{
			ExportData exportData = (ExportData)SerializationSurrogateUtil.GetBinaryFormatter().Deserialize(inputStream);
			PersistentVegetationCellList = exportData.PersistentVegetationCellList;
			PersistentVegetationInstanceInfoList = exportData.PersistentVegetationInstanceInfoList;
			PersistentVegetationInstanceSourceList = exportData.PersistentVegetationInstanceSourceList;
			inputStream.Position = 0L;
		}

		public void ImportFromFile(string filename)
		{
			BinaryFormatter binaryFormatter = SerializationSurrogateUtil.GetBinaryFormatter();
			FileStream fileStream = File.Open(filename, FileMode.Open);
			ExportData exportData = (ExportData)binaryFormatter.Deserialize(fileStream);
			PersistentVegetationCellList = exportData.PersistentVegetationCellList;
			PersistentVegetationInstanceInfoList = exportData.PersistentVegetationInstanceInfoList;
			PersistentVegetationInstanceSourceList = exportData.PersistentVegetationInstanceSourceList;
			fileStream.Close();
		}

		public void ClearPersistentVegetationCells()
		{
			PersistentVegetationCellList.Clear();
		}

		public void SetInstanceInfoDirty()
		{
			_instanceInfoDirty = true;
		}

		public void RemoveVegetationItemInstances(string vegetationItemID)
		{
			for (int i = 0; i <= PersistentVegetationCellList.Count - 1; i++)
			{
				PersistentVegetationCellList[i].RemoveVegetationItemInstances(vegetationItemID);
			}
			_instanceInfoDirty = true;
		}

		public void RemoveVegetationItemInstances(string vegetationItemID, byte vegetationSourceID)
		{
			for (int i = 0; i <= PersistentVegetationCellList.Count - 1; i++)
			{
				PersistentVegetationCellList[i].RemoveVegetationItemInstances(vegetationItemID, vegetationSourceID);
			}
			_instanceInfoDirty = true;
		}

		public void AddVegetationCell()
		{
			PersistentVegetationCell item = new PersistentVegetationCell();
			PersistentVegetationCellList.Add(item);
			_instanceInfoDirty = true;
		}

		public void AddVegetationItemInstance(int cellIndex, string vegetationItemID, Vector3 position, Vector3 scale, Quaternion rotation, byte vegetationSourceID, float distanceFalloff)
		{
			if (PersistentVegetationCellList.Count > cellIndex)
			{
				PersistentVegetationCellList[cellIndex].AddVegetationItemInstance(vegetationItemID, position, scale, rotation, vegetationSourceID, distanceFalloff);
			}
			_instanceInfoDirty = true;
		}

		public void AddVegetationItemInstanceEx(int cellIndex, string vegetationItemID, Vector3 position, Vector3 scale, Quaternion rotation, byte vegetationSourceID, float minimumDistance, float distanceFalloff)
		{
			if (PersistentVegetationCellList.Count > cellIndex)
			{
				PersistentVegetationCellList[cellIndex].AddVegetationItemInstanceEx(vegetationItemID, position, scale, rotation, vegetationSourceID, minimumDistance, distanceFalloff);
			}
			_instanceInfoDirty = true;
		}

		public void RemoveVegetationItemInstance(int cellIndex, string vegetationItemID, Vector3 position, float minimumDistance)
		{
			if (PersistentVegetationCellList.Count > cellIndex)
			{
				PersistentVegetationCellList[cellIndex].RemoveVegetationItemInstance(vegetationItemID, position, minimumDistance);
			}
			_instanceInfoDirty = true;
		}

		public void RemoveVegetationItemInstance2D(int cellIndex, string vegetationItemID, Vector3 position, float minimumDistance)
		{
			if (PersistentVegetationCellList.Count > cellIndex)
			{
				PersistentVegetationCellList[cellIndex].RemoveVegetationItemInstance2D(vegetationItemID, position, minimumDistance);
			}
			_instanceInfoDirty = true;
		}

		public List<PersistentVegetationInstanceInfo> GetPersistentVegetationInstanceInfoList()
		{
			if (_instanceInfoDirty)
			{
				UpdatePersistentVegetationInstanceInfo();
				_instanceInfoDirty = false;
			}
			return PersistentVegetationInstanceInfoList;
		}

		private void UpdatePersistentVegetationInstanceInfo()
		{
			PersistentVegetationInstanceInfoList.Clear();
			for (int i = 0; i <= PersistentVegetationCellList.Count - 1; i++)
			{
				PersistentVegetationCell persistentVegetationCell = PersistentVegetationCellList[i];
				for (int j = 0; j <= persistentVegetationCell.PersistentVegetationInfoList.Count - 1; j++)
				{
					PersistentVegetationInstanceInfo persistentVegetationInstanceInfo = GetPersistentVegetationInstanceInfo(persistentVegetationCell.PersistentVegetationInfoList[j].VegetationItemID);
					if (persistentVegetationInstanceInfo == null)
					{
						persistentVegetationInstanceInfo = new PersistentVegetationInstanceInfo
						{
							VegetationItemID = persistentVegetationCell.PersistentVegetationInfoList[j].VegetationItemID
						};
						PersistentVegetationInstanceInfoList.Add(persistentVegetationInstanceInfo);
					}
					persistentVegetationInstanceInfo.Count += persistentVegetationCell.PersistentVegetationInfoList[j].VegetationItemList.Count;
					persistentVegetationInstanceInfo.AddSourceCountList(persistentVegetationCell.PersistentVegetationInfoList[j].SourceCountList);
				}
			}
		}

		private PersistentVegetationInstanceInfo GetPersistentVegetationInstanceInfo(string vegetationItemID)
		{
			for (int i = 0; i <= PersistentVegetationInstanceInfoList.Count - 1; i++)
			{
				if (PersistentVegetationInstanceInfoList[i].VegetationItemID == vegetationItemID)
				{
					return PersistentVegetationInstanceInfoList[i];
				}
			}
			return null;
		}
	}
}
