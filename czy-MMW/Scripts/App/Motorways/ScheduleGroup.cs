using System;
using UnityEngine;

namespace Motorways
{
	[Serializable]
	public struct ScheduleGroup
	{
		public int index;

		public AnimationCurve minimumNumSuburbs;

		public AnimationCurve maximumNumSuburbs;
	}
}
