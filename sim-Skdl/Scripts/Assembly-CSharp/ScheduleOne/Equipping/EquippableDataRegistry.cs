using System;
using System.Collections.Generic;
using ScheduleOne.Core.Equipping.Framework;
using ScheduleOne.DevUtilities;
using UnityEngine;

namespace ScheduleOne.Equipping
{
	public class EquippableDataRegistry : PersistentSingleton<EquippableDataRegistry>
	{
		[SerializeField]
		[ReadOnly]
		private List<EquippableData> _equippableDataList;

		public EquippableData GetEquippableData(Guid guid)
		{
			return null;
		}

		private void RegisterEquippableData(EquippableData data)
		{
		}
	}
}
