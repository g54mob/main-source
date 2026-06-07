using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Factory.FieldData
{
	[Serializable]
	public class StructureInventory
	{
		public enum eCostMode
		{
			CostMode1 = 0,
			CostMode2 = 1,
			Infinity = 2
		}

		[SerializeField]
		private eMachine machineID;

		private MstMachineDataEntities _mstMachineDataEntities;

		[SerializeField]
		private int _specifiedCost1;

		[SerializeField]
		private int _cost1Revision;

		[SerializeField]
		private float _cost1RatioRevision;

		private int _cost2Revision;

		public eCostMode CostMode;

		[SerializeField]
		private double count;

		[SerializeField]
		[FormerlySerializedAs("max")]
		private double num;

		private int _machineRepurchaseCountWave;

		private Stack<int> _machineRepurchase;

		public eMachine MachineID
		{
			get
			{
				return default(eMachine);
			}
			set
			{
			}
		}

		private MstMachineDataEntities MstMachineDataEntities => null;

		public int BaseCost => 0;

		public int Cost => 0;

		public bool CostOk => false;

		public string CostStr => null;

		private double TrueRemain => 0.0;

		public double Remain => 0.0;

		public string TrueRemainStr => null;

		private int MachineRepurchaseCount => 0;

		public void CostSpecification(int newValue)
		{
		}

		public void CostSpecificationByRate(double rate)
		{
		}

		public void Cost1Revision(int revision)
		{
		}

		public void Cost1RatioRevision(float ratio)
		{
		}

		public void Cost2Revision(int revision)
		{
		}

		public double GetTrueRemain()
		{
			return 0.0;
		}

		private void CheckMachineRepurchaseCountWave()
		{
		}

		private void PushMachineRepurchase(int cost)
		{
		}

		private int PopMachineRepurchase()
		{
			return 0;
		}

		public static StructureInventory Create(eMachine mid, int num)
		{
			return null;
		}

		public static StructureInventory Duplicate(StructureInventory old, eMachine newMid)
		{
			return null;
		}

		private float RepurchaseManaRate()
		{
			return 0f;
		}

		public void CountUp(double add)
		{
		}

		private void ConsumeCostOrCountUp(int add, int cost)
		{
		}

		public override string ToString()
		{
			return null;
		}

		private string DoubleToString(double from)
		{
			return null;
		}

		public StructureInventory Clone()
		{
			return null;
		}
	}
}
