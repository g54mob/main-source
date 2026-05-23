using System;
using System.Collections.Generic;
using UnityEngine;

public class ControlLegends : MonoBehaviour
{
	[Serializable]
	public class Row
	{
		public string actionId;

		public string staticStringId;
	}

	public List<Row> rows;
}
