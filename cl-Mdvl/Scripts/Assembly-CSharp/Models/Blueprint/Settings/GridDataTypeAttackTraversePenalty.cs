using System;
using NSEipix.Base;
using NSMedieval.Types;
using UnityEngine;

namespace Models.Blueprint.Settings
{
	[Serializable]
	public class GridDataTypeAttackTraversePenalty : Model
	{
		[Serializable]
		public struct Data
		{
			[SerializeField]
			private GridDataType gridDataType;

			[SerializeField]
			private float penalty;

			public GridDataType DataType => gridDataType;

			public float Penalty => penalty;
		}

		[SerializeField]
		private Data[] penalties;

		public Data[] Penalties => penalties;

		public override string GetID()
		{
			return "GridDataTypeAttackTraversePenalty";
		}
	}
}
