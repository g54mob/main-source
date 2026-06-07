using System;
using System.Runtime.CompilerServices;
using LitJson;

namespace Gh.Tk
{
	public class StaffData : ActorData
	{
		private bool _isFired;

		[JsonIgnore]
		public bool IsFired
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public int HiringCost { get; set; }

		public int Salary { get; set; }

		public int Tier { get; set; }

		public static event EventHandler<EventArgs> IsFiredChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}
	}
}
