#define ENABLE_DEBUG_WARNINGS
using System.Collections.Generic;
using Data.Operator;
using UnityEngine;
using Utils;

namespace Data.FactoryFloor
{
	[CreateAssetMenu(menuName = "Factory/FactoryObject Blocked In DemoDatabase", fileName = "FactoryObjectBlockedInDemoDatabase", order = 0)]
	public class FactoryObjectBlockedInDemoDatabase : ScriptableObject
	{
		public List<FactoryObjectData> FactoryObjectsData = new List<FactoryObjectData>();

		public bool IsFactoryObjectDataBlockedInDemo(FactoryObjectData factoryObjectData)
		{
			bool num = FactoryObjectsData.Contains(factoryObjectData);
			if (num && Application.isPlaying)
			{
				this.LogWarning($"The operator {factoryObjectData} is locked in the demo, index: {FactoryObjectsData.IndexOf(factoryObjectData)}!", "IsFactoryObjectDataBlockedInDemo", 17);
			}
			return num;
		}
	}
}
