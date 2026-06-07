using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace EasyRoads3Dv3
{
	public class ERPoint
	{
		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private double ussst;

		[CompilerGenerated]
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		private double vssss;

		public double x
		{
			[CompilerGenerated]
			get
			{
				return ussst;
			}
			[CompilerGenerated]
			set
			{
				ussst = value;
			}
		}

		public double y
		{
			[CompilerGenerated]
			get
			{
				return vssss;
			}
			[CompilerGenerated]
			set
			{
				vssss = value;
			}
		}

		public ERPoint(double x, double y)
		{
			this.x = x;
			this.y = y;
		}
	}
}
