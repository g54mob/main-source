using System;
using I2.Loc;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[Serializable]
	[UsedImplicitly(ImplicitUseTargetFlags.Members)]
	public class RoomModifierDiagnosis : RoomModifier
	{
		[SerializeField]
		private float _percentage;

		[SerializeField]
		private bool _roomWide = true;

		public bool RoomWide => _roomWide;

		public float Percentage => _percentage;

		public void Apply(RoomItem roomItem, FloorPlan floorPlan)
		{
			if (_roomWide && floorPlan.OwningRoom != null)
			{
				floorPlan.OwningRoom.DiagnosisMultiplier += _percentage / 100f;
			}
		}

		public void Remove(RoomItem roomItem, FloorPlan floorPlan)
		{
			if (_roomWide && floorPlan.OwningRoom != null)
			{
				floorPlan.OwningRoom.DiagnosisMultiplier -= _percentage / 100f;
			}
		}

		public string Description()
		{
			return ScriptLocalization.Room_Modifiers.Diagnosis_Description_CS.Replace("{[AMOUNT]}", StringUtils.FormatPercentageValue(Percentage / 100f, prefixPlus: true));
		}

		public RoomModifierCondition GetModifierCondition()
		{
			return RoomModifierCondition.None;
		}
	}
}
