using System;
using UnityEngine;

namespace Rewired.Utils.Classes.Utility
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal sealed class UnityStopwatch : StopwatchBase
	{
		private class uRRgZqBKDnfgLknSsYyrkjjeMDhu
		{
			public const long npaVWojZVQpuGUtfRBTGyFaepxn = 10000000L;

			private double FptarhviHjLAwKkegmyRRkSjKOh;

			private bool GTSnoVqwoWkmoBesRSutKEZJuEs;

			private double DCnGtoEqXXFJULpgdrXRbfCHyGIM;

			private double CUOuyXGvcSKTERItFacIbJyAechi;

			public bool IsRunning => GTSnoVqwoWkmoBesRSutKEZJuEs;

			public double ElapsedSeconds
			{
				get
				{
					if (!GTSnoVqwoWkmoBesRSutKEZJuEs)
					{
						return CUOuyXGvcSKTERItFacIbJyAechi;
					}
					return (double)Time.realtimeSinceStartup - DCnGtoEqXXFJULpgdrXRbfCHyGIM;
				}
			}

			public void iAnBBfDdWbgOiFHwNWqxFDtiXzYA()
			{
				FptarhviHjLAwKkegmyRRkSjKOh = Time.realtimeSinceStartup;
			}

			public void xNRqfCbZrFcpJcVLMCeHrbgeubc()
			{
				if (!GTSnoVqwoWkmoBesRSutKEZJuEs)
				{
					GTSnoVqwoWkmoBesRSutKEZJuEs = true;
					DCnGtoEqXXFJULpgdrXRbfCHyGIM = FptarhviHjLAwKkegmyRRkSjKOh;
				}
			}

			public void kRsmLOmlMaRMOrNxWdWeQYoLQoL()
			{
				if (GTSnoVqwoWkmoBesRSutKEZJuEs)
				{
					GTSnoVqwoWkmoBesRSutKEZJuEs = false;
					CUOuyXGvcSKTERItFacIbJyAechi += FptarhviHjLAwKkegmyRRkSjKOh - DCnGtoEqXXFJULpgdrXRbfCHyGIM;
				}
			}

			public void agvWMBoHtblzmgSmVloJbsDkfGk()
			{
				DCnGtoEqXXFJULpgdrXRbfCHyGIM = 0.0;
				CUOuyXGvcSKTERItFacIbJyAechi = 0.0;
				bool gTSnoVqwoWkmoBesRSutKEZJuEs = GTSnoVqwoWkmoBesRSutKEZJuEs;
				GTSnoVqwoWkmoBesRSutKEZJuEs = false;
				if (gTSnoVqwoWkmoBesRSutKEZJuEs)
				{
					xNRqfCbZrFcpJcVLMCeHrbgeubc();
				}
			}
		}

		private const long yXugMdYeVilWGXSuDPlFfrLjcqz = 10000000L;

		private static UnityStopwatch ttQCcKAvsjAXIdYcdarTgswkqePc;

		private readonly uRRgZqBKDnfgLknSsYyrkjjeMDhu jbYoHftSYRpRTpOpMAwBhkqZnWq;

		private readonly bool mPQhqXUeiIsaaTxjEFCRxqWYugq;

		private double PPTpdotkKYrTUJitOVWpSGYDKPW;

		public static UnityStopwatch Global => ttQCcKAvsjAXIdYcdarTgswkqePc ?? (ttQCcKAvsjAXIdYcdarTgswkqePc = new UnityStopwatch(isGlobal: true));

		public static long frequency => 10000000L;

		public override double offsetSeconds
		{
			get
			{
				return PPTpdotkKYrTUJitOVWpSGYDKPW;
			}
			set
			{
				PPTpdotkKYrTUJitOVWpSGYDKPW = value;
			}
		}

		public override long offsetTicks
		{
			get
			{
				return (long)(PPTpdotkKYrTUJitOVWpSGYDKPW * 10000000.0);
			}
			set
			{
				PPTpdotkKYrTUJitOVWpSGYDKPW = (double)value / 10000000.0;
			}
		}

		public override double elapsedSeconds => jbYoHftSYRpRTpOpMAwBhkqZnWq.ElapsedSeconds + offsetSeconds;

		public override double elapsedSecondsRaw => jbYoHftSYRpRTpOpMAwBhkqZnWq.ElapsedSeconds;

		public override long elapsedMilliseconds => (long)((jbYoHftSYRpRTpOpMAwBhkqZnWq.ElapsedSeconds + PPTpdotkKYrTUJitOVWpSGYDKPW) * 1000.0);

		public override long elapsedMillisecondsRaw => (long)(jbYoHftSYRpRTpOpMAwBhkqZnWq.ElapsedSeconds * 1000.0);

		public override long elapsedTicks => (long)(elapsedSeconds * 10000000.0);

		public override long elapsedTicksRaw => (long)(elapsedSecondsRaw * 10000000.0);

		public override bool isRunning => jbYoHftSYRpRTpOpMAwBhkqZnWq.IsRunning;

		public static UnityStopwatch StartNew()
		{
			UnityStopwatch unityStopwatch = new UnityStopwatch(isGlobal: false);
			unityStopwatch.Start();
			return unityStopwatch;
		}

		public static long ConvertTo100NSTicks(long ticks)
		{
			return ticks;
		}

		public UnityStopwatch()
			: this(isGlobal: false)
		{
		}

		private UnityStopwatch(bool isGlobal)
		{
			jbYoHftSYRpRTpOpMAwBhkqZnWq = new uRRgZqBKDnfgLknSsYyrkjjeMDhu();
			OmZsACJXatMeEfNxSRTjSawyAEO();
			if (isGlobal)
			{
				Start();
			}
			mPQhqXUeiIsaaTxjEFCRxqWYugq = isGlobal;
		}

		~UnityStopwatch()
		{
			IfwpVtBIksovguHaJhhuFBKPHPI();
		}

		public override void Stop()
		{
			if (mPQhqXUeiIsaaTxjEFCRxqWYugq)
			{
				throw new Exception("The Global Stopwatch cannot be stopped.");
			}
			jbYoHftSYRpRTpOpMAwBhkqZnWq.kRsmLOmlMaRMOrNxWdWeQYoLQoL();
		}

		public override void Start()
		{
			if (!mPQhqXUeiIsaaTxjEFCRxqWYugq)
			{
				jbYoHftSYRpRTpOpMAwBhkqZnWq.xNRqfCbZrFcpJcVLMCeHrbgeubc();
			}
		}

		public override void Reset()
		{
			if (mPQhqXUeiIsaaTxjEFCRxqWYugq)
			{
				throw new Exception("The Global Stopwatch cannot be reset.");
			}
			jbYoHftSYRpRTpOpMAwBhkqZnWq.agvWMBoHtblzmgSmVloJbsDkfGk();
		}

		private void OmZsACJXatMeEfNxSRTjSawyAEO()
		{
			IfwpVtBIksovguHaJhhuFBKPHPI();
			ReInput.BeforeTimeManagerUpdateEvent += GoDzCZSWyCxHOoFNmmNBncoqcAY;
		}

		private void IfwpVtBIksovguHaJhhuFBKPHPI()
		{
			ReInput.BeforeTimeManagerUpdateEvent -= GoDzCZSWyCxHOoFNmmNBncoqcAY;
		}

		private void GoDzCZSWyCxHOoFNmmNBncoqcAY(UpdateLoopType P_0)
		{
			jbYoHftSYRpRTpOpMAwBhkqZnWq.iAnBBfDdWbgOiFHwNWqxFDtiXzYA();
		}
	}
}
