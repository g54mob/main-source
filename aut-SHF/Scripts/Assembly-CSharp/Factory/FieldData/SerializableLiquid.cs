using System;
using Models;
using UnityEngine;

namespace Factory.FieldData
{
	[Serializable]
	public class SerializableLiquid
	{
		public string liquidId;

		[SerializeField]
		private Vector2Int addr;

		[SerializeField]
		private Vector2Int mechAddr;

		[SerializeField]
		private int streamLayer;

		public double measure;

		public double liquidCapacity;

		public double liquidCreateTime;

		public StructureAddr Addr
		{
			get
			{
				return default(StructureAddr);
			}
			set
			{
			}
		}

		public StructureAddr? MechAddr
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public int? StreamLayer
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public SerializableLiquid(ILiquidCarrier str)
		{
		}

		public void Restore(FactoryMap factoryMap, eLuggage _liquidId)
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
