using System.Collections.Generic;
using Data.Operator;
using NaughtyAttributes;
using UnityEngine;

namespace Data.FactoryFloor
{
	[CreateAssetMenu(menuName = "Factory/DecorationsObjectDatabase", fileName = "DecorationsObjectDatabase", order = 0)]
	public class DecorationsObjectDatabase : ScriptableObject
	{
		public List<FactoryObjectData> DecorationDatas;

		[Button(null, EButtonEnableMode.Always)]
		private void UpdateRelativePositions()
		{
			foreach (FactoryObjectData decorationData in DecorationDatas)
			{
				decorationData.UpdateRelativePositions();
			}
		}

		public void AddFactoryObject(FactoryObjectData factoryObjectData)
		{
			DecorationDatas.Add(factoryObjectData);
			factoryObjectData.UpdateRelativePositions();
			factoryObjectData.UpdateIndex();
		}

		public bool Contains(FactoryObjectData factoryObjectData)
		{
			return DecorationDatas.Contains(factoryObjectData);
		}
	}
}
