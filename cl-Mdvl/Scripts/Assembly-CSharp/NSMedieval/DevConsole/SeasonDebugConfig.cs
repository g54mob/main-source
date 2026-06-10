using System;
using NSEipix.Base;
using UnityEngine;

namespace NSMedieval.DevConsole
{
	[Serializable]
	public class SeasonDebugConfig : NSEipix.Base.Model
	{
		[SerializeField]
		private string name;

		[SerializeField]
		private int index;

		[SerializeField]
		private float daysInPercent;

		public int Index => index;

		public float DaysInPercent => daysInPercent;

		public override string GetID()
		{
			return name;
		}
	}
}
