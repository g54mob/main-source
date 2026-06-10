using System;
using NSMedieval.Model;
using UnityEngine;

namespace NSMedieval.Goap
{
	[Serializable]
	public class ScheduleDataSettings
	{
		[SerializeField]
		private ScheduleDataSettingsType type;

		[SerializeField]
		private string value;

		[SerializeField]
		private StringStringPair[] parameters;

		public ScheduleDataSettingsType Type => type;

		public string Value => value;

		public StringStringPair[] Parameters => parameters;
	}
}
