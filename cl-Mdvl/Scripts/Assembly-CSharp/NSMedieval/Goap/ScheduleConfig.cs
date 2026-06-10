using System;
using NSEipix.Base;
using UnityEngine;

namespace NSMedieval.Goap
{
	[Serializable]
	public class ScheduleConfig : NSEipix.Base.Model
	{
		[SerializeField]
		private string id;

		[SerializeField]
		private int[] config;

		public int[] Config => config;

		public override string GetID()
		{
			return id;
		}
	}
}
