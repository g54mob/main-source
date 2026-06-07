using System;
using UnityEngine;

namespace Rewired.Utils.Classes.Utility
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal sealed class UnityStopwatch : StopwatchBase
	{
		private class JAnowTkQIZWIInbkqyXJIrClITrO
		{
			public const long WbDqWrCUObJKxAANzFyfNKunJhbV = 10000000L;

			private double utLImOMFGBmgtCpIiTdvwlfmAxhg;

			private bool favUaRLffWEtzVZYwbKYfPxMiLIi;

			private double ifXlCJHKGvCjZlWElkmbQXhEkKOw;

			private double tCqIRuvmhwBgBAXPNxDoVGXVFmtoA;

			public bool rfOecfPgPQHHOceOfJhmDfUBbwphB => favUaRLffWEtzVZYwbKYfPxMiLIi;

			public double HbZYBTBoNHAxDcFmzFkBcnsKRpfUb
			{
				get
				{
					if (!favUaRLffWEtzVZYwbKYfPxMiLIi)
					{
						return tCqIRuvmhwBgBAXPNxDoVGXVFmtoA;
					}
					return (double)Time.realtimeSinceStartup - ifXlCJHKGvCjZlWElkmbQXhEkKOw;
				}
			}

			public void DsDuSUaDcVanpNAhDLIRqjKndMGi()
			{
				utLImOMFGBmgtCpIiTdvwlfmAxhg = Time.realtimeSinceStartup;
			}

			public void YzxJYzIGUbUuQcUjIpyhOcHzsJaf()
			{
				if (!favUaRLffWEtzVZYwbKYfPxMiLIi)
				{
					favUaRLffWEtzVZYwbKYfPxMiLIi = true;
					ifXlCJHKGvCjZlWElkmbQXhEkKOw = utLImOMFGBmgtCpIiTdvwlfmAxhg;
				}
			}

			public void JiWRycLAiMzKBxXtUYeevPxAIymj()
			{
				if (favUaRLffWEtzVZYwbKYfPxMiLIi)
				{
					favUaRLffWEtzVZYwbKYfPxMiLIi = false;
					tCqIRuvmhwBgBAXPNxDoVGXVFmtoA += utLImOMFGBmgtCpIiTdvwlfmAxhg - ifXlCJHKGvCjZlWElkmbQXhEkKOw;
				}
			}

			public void XKZIxwRUwDpNhkICJrLjGrsjhGsn()
			{
				ifXlCJHKGvCjZlWElkmbQXhEkKOw = 0.0;
				tCqIRuvmhwBgBAXPNxDoVGXVFmtoA = 0.0;
				bool num = favUaRLffWEtzVZYwbKYfPxMiLIi;
				favUaRLffWEtzVZYwbKYfPxMiLIi = false;
				if (num)
				{
					YzxJYzIGUbUuQcUjIpyhOcHzsJaf();
				}
			}
		}

		private const long FOKdVQnIrQFUFFdcHHmxEMOoGijy = 10000000L;

		private static UnityStopwatch YLeMTlfNvPMdHSGExmUbBHDjykFV;

		private readonly JAnowTkQIZWIInbkqyXJIrClITrO YreggMjCHbVzMOrXOzZrDERYDKyEb;

		private readonly bool VFxQtJsvlKItlJSPhgveWTVNctyI;

		private double mkhGFYUnlqHxWRkAAaokrevUUNHF;

		public static UnityStopwatch Global => YLeMTlfNvPMdHSGExmUbBHDjykFV ?? (YLeMTlfNvPMdHSGExmUbBHDjykFV = new UnityStopwatch(true));

		public static long frequency => 10000000L;

		public override double offsetSeconds
		{
			get
			{
				return mkhGFYUnlqHxWRkAAaokrevUUNHF;
			}
			set
			{
				mkhGFYUnlqHxWRkAAaokrevUUNHF = value;
			}
		}

		public override long offsetTicks
		{
			get
			{
				return (long)(mkhGFYUnlqHxWRkAAaokrevUUNHF * 10000000.0);
			}
			set
			{
				mkhGFYUnlqHxWRkAAaokrevUUNHF = (double)value / 10000000.0;
			}
		}

		public override double elapsedSeconds => YreggMjCHbVzMOrXOzZrDERYDKyEb.HbZYBTBoNHAxDcFmzFkBcnsKRpfUb + offsetSeconds;

		public override double elapsedSecondsRaw => YreggMjCHbVzMOrXOzZrDERYDKyEb.HbZYBTBoNHAxDcFmzFkBcnsKRpfUb;

		public override long elapsedMilliseconds => (long)((YreggMjCHbVzMOrXOzZrDERYDKyEb.HbZYBTBoNHAxDcFmzFkBcnsKRpfUb + mkhGFYUnlqHxWRkAAaokrevUUNHF) * 1000.0);

		public override long elapsedMillisecondsRaw => (long)(YreggMjCHbVzMOrXOzZrDERYDKyEb.HbZYBTBoNHAxDcFmzFkBcnsKRpfUb * 1000.0);

		public override long elapsedTicks => (long)(elapsedSeconds * 10000000.0);

		public override long elapsedTicksRaw => (long)(elapsedSecondsRaw * 10000000.0);

		public override bool isRunning => YreggMjCHbVzMOrXOzZrDERYDKyEb.rfOecfPgPQHHOceOfJhmDfUBbwphB;

		public static UnityStopwatch StartNew()
		{
			UnityStopwatch unityStopwatch = new UnityStopwatch(false);
			unityStopwatch.Start();
			return unityStopwatch;
		}

		public static long ConvertTo100NSTicks(long ticks)
		{
			return ticks;
		}

		public UnityStopwatch()
			: this(false)
		{
		}

		private UnityStopwatch(bool P_0)
		{
			YreggMjCHbVzMOrXOzZrDERYDKyEb = new JAnowTkQIZWIInbkqyXJIrClITrO();
			nvrVzwyjHyyVLbPSJeJljBvMUAVA();
			if (P_0)
			{
				Start();
			}
			VFxQtJsvlKItlJSPhgveWTVNctyI = P_0;
		}

		~UnityStopwatch()
		{
			xBAKnwaCLSjQguFzBNKKubeKOLYN();
		}

		public override void Stop()
		{
			if (VFxQtJsvlKItlJSPhgveWTVNctyI)
			{
				throw new Exception("The Global Stopwatch cannot be stopped.");
			}
			YreggMjCHbVzMOrXOzZrDERYDKyEb.JiWRycLAiMzKBxXtUYeevPxAIymj();
		}

		public override void Start()
		{
			if (!VFxQtJsvlKItlJSPhgveWTVNctyI)
			{
				YreggMjCHbVzMOrXOzZrDERYDKyEb.YzxJYzIGUbUuQcUjIpyhOcHzsJaf();
			}
		}

		public override void Reset()
		{
			if (VFxQtJsvlKItlJSPhgveWTVNctyI)
			{
				throw new Exception("The Global Stopwatch cannot be reset.");
			}
			YreggMjCHbVzMOrXOzZrDERYDKyEb.XKZIxwRUwDpNhkICJrLjGrsjhGsn();
		}

		private void nvrVzwyjHyyVLbPSJeJljBvMUAVA()
		{
			xBAKnwaCLSjQguFzBNKKubeKOLYN();
			ReInput.BeforeTimeManagerUpdateEvent += vjhEkIpbiwZRwstmkNxqMDjviCZ;
		}

		private void xBAKnwaCLSjQguFzBNKKubeKOLYN()
		{
			ReInput.BeforeTimeManagerUpdateEvent -= vjhEkIpbiwZRwstmkNxqMDjviCZ;
		}

		private void vjhEkIpbiwZRwstmkNxqMDjviCZ(UpdateLoopType P_0)
		{
			YreggMjCHbVzMOrXOzZrDERYDKyEb.DsDuSUaDcVanpNAhDLIRqjKndMGi();
		}
	}
}
