using System;
using UnityEngine;

namespace Gley.UrbanSystem.Internal
{
	[Serializable]
	public class RowData
	{
		[SerializeField]
		private CellData[] _row;

		public CellData[] Row
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public RowData(CellData[] row)
		{
		}
	}
}
