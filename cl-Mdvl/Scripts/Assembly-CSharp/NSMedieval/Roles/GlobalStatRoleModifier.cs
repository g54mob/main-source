using System;
using UnityEngine;

namespace NSMedieval.Roles
{
	[Serializable]
	public class GlobalStatRoleModifier
	{
		[SerializeField]
		private string globalStatId;

		[SerializeField]
		private float valueCap;

		[SerializeField]
		private float dailyAddValue;

		public string GlobalStatId => globalStatId;

		public float ValueCap => valueCap;

		public float DailyAddValue => dailyAddValue;
	}
}
