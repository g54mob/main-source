using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using ToolBuddy.Pooling.Collections;

namespace FluffyUnderware.Curvy.Generator
{
	[CGDataInfo(0.96f, 0.96f, 0.96f, 1f)]
	public class CGSpots : CGData
	{
		private SubArray<CGSpot> spots;

		public SubArray<CGSpot> Spots
		{
			get
			{
				return default(SubArray<CGSpot>);
			}
			set
			{
			}
		}

		[UsedImplicitly]
		[Obsolete("Use Spots instead")]
		public CGSpot[] Points
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public override int Count => 0;

		public CGSpots()
		{
		}

		public CGSpots(params CGSpot[] points)
		{
		}

		public CGSpots(SubArray<CGSpot> spots)
		{
		}

		public CGSpots(List<CGSpot> spots)
		{
		}

		public CGSpots(params List<CGSpot>[] spots)
		{
		}

		public CGSpots(CGSpots source)
		{
		}

		protected override bool Dispose(bool disposing)
		{
			return false;
		}

		public override T Clone<T>()
		{
			return null;
		}
	}
}
