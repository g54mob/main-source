using System;
using System.Collections.Generic;
using UnityEngine;

public class Restaurant : NoktaSingleton<Restaurant>
{
	[Serializable]
	public class Table
	{
		[Serializable]
		public class Chair
		{
			public Transform ChairPosition;

			public bool IsOccupied;
		}

		public Transform TargetPoint;

		public Chair Chair1;

		public Chair Chair2;

		public Chair GetChair()
		{
			return null;
		}
	}

	public List<Table> Tables;

	public Table GetAvailableTable()
	{
		return null;
	}

	public bool IsAnyAvailableTable()
	{
		return false;
	}
}
