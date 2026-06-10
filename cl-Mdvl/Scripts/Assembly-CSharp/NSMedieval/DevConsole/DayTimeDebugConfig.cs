using System;
using NSEipix.Base;
using UnityEngine;

namespace NSMedieval.DevConsole
{
	[Serializable]
	public class DayTimeDebugConfig : NSEipix.Base.Model
	{
		[SerializeField]
		private string name;

		[SerializeField]
		private float percent;

		public float Percent => percent;

		public override string GetID()
		{
			return name;
		}
	}
}
