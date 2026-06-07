using System;
using Models;
using UnityEngine;

namespace Factory.FieldData
{
	[Serializable]
	public class SerializableLuggage
	{
		public string luggageId;

		public string objectName;

		[SerializeField]
		private Vector2Int addr;

		public double luggageRate;

		public bool visible;

		public int luggageCount;

		public int luggageOmakeCount;

		public double loadingTime;

		public int flag;

		public int coatingLevel;

		public string coatingColor;

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

		public SerializableLuggage(ILuggageCarrier str)
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
