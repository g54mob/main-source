using System;
using NSEipix.Base;
using UnityEngine;

namespace NSMedieval.Roles
{
	[Serializable]
	public class WardenRoleSettings : NSEipix.Base.Model
	{
		[SerializeField]
		private int[] labourerLimitPerLevel;

		[SerializeField]
		private string[] onLabourerProximityEnterEffectors;

		[SerializeField]
		private string[] onPrisonerProximityEnterEffectors;

		public int[] LabourerLimitPerLevel => labourerLimitPerLevel;

		public string[] LabourerProximityInteractEffectors => onLabourerProximityEnterEffectors;

		public string[] PrisonerProximityInteractEffectors => onPrisonerProximityEnterEffectors;

		public override string GetID()
		{
			return "WardenRoleSettings";
		}
	}
}
