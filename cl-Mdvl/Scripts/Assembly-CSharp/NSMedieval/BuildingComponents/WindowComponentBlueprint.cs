using System;
using System.Collections.Generic;
using System.Linq;
using NSEipix.Base;
using NSEipix.Repository;
using NSMedieval.Construction;
using NSMedieval.Enums;
using UnityEngine;

namespace NSMedieval.BuildingComponents
{
	[Serializable]
	public class WindowComponentBlueprint : NSEipix.Base.Model
	{
		private readonly BuildingType componentType = BuildingType.Window;

		[SerializeField]
		private string id;

		[SerializeField]
		private List<LockStateData> lockStates;

		[SerializeField]
		private string thermalModelID;

		[SerializeField]
		private float coverClosed;

		[NonSerialized]
		private ThermalModel thermalModel;

		public BuildingType ComponentType => componentType;

		public List<LockStateData> LockStates => lockStates;

		public float CoverClosed => coverClosed;

		public LockState DefaultLockState
		{
			get
			{
				if (lockStates == null || !lockStates.Any())
				{
					return LockState.Locked;
				}
				return lockStates.First((LockStateData x) => x.DefaultLockState).LockState;
			}
		}

		public ThermalModel ThermalModel
		{
			get
			{
				if (thermalModelID == null)
				{
					return null;
				}
				if (thermalModel == null)
				{
					thermalModel = Repository<ThermalModelRepository, ThermalModel>.Instance.GetByID(thermalModelID);
				}
				return thermalModel;
			}
		}

		public override string GetID()
		{
			return id;
		}
	}
}
