using System;
using UnityEngine;

namespace Rewired.Utils.Classes.Utility
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal sealed class UnityStopwatch : StopwatchBase
	{
		private class ERozbzedZIZpjVzWAJHrXTMEMsM
		{
			public const long DqApuTQLfykYCilODoUVSwRSAnG = 10000000L;

			private double tNMXPkESLYJOQmAwIdTHlujFTfE;

			private bool gTyLLvDyPFrZEpsrKvookvvbBvf;

			private double bbAzXbTKHckGyRxoHHwNHchbXzf;

			private double cUrbUOhjghGFgzfffMHGfFZudPMY;

			public bool IsRunning => gTyLLvDyPFrZEpsrKvookvvbBvf;

			public double ElapsedSeconds
			{
				get
				{
					if (!gTyLLvDyPFrZEpsrKvookvvbBvf)
					{
						return cUrbUOhjghGFgzfffMHGfFZudPMY;
					}
					return (double)Time.realtimeSinceStartup - bbAzXbTKHckGyRxoHHwNHchbXzf;
				}
			}

			public void GzCliicOSMFLMvKajLgvnmGSSrh()
			{
				tNMXPkESLYJOQmAwIdTHlujFTfE = Time.realtimeSinceStartup;
			}

			public void NoiITHOkBgdirKSZopWLLfLYZOJ()
			{
				if (!gTyLLvDyPFrZEpsrKvookvvbBvf)
				{
					gTyLLvDyPFrZEpsrKvookvvbBvf = true;
					bbAzXbTKHckGyRxoHHwNHchbXzf = tNMXPkESLYJOQmAwIdTHlujFTfE;
				}
			}

			public void AsLGHAVbjPEacNmJeQPEsuzzptZ()
			{
				if (!gTyLLvDyPFrZEpsrKvookvvbBvf)
				{
					goto IL_0008;
				}
				goto IL_0057;
				IL_0008:
				int num = 1236078229;
				goto IL_000d;
				IL_000d:
				while (true)
				{
					switch (num ^ 0x49AD0E91)
					{
					case 0:
						break;
					default:
						return;
					case 4:
						return;
					case 3:
						cUrbUOhjghGFgzfffMHGfFZudPMY += tNMXPkESLYJOQmAwIdTHlujFTfE - bbAzXbTKHckGyRxoHHwNHchbXzf;
						num = 1236078224;
						continue;
					case 2:
						goto IL_0057;
					case 1:
						return;
					}
					break;
				}
				goto IL_0008;
				IL_0057:
				gTyLLvDyPFrZEpsrKvookvvbBvf = false;
				num = 1236078226;
				goto IL_000d;
			}

			public void CHWDoIJFbUPiCCQqjvBLnPoSWjTy()
			{
				bbAzXbTKHckGyRxoHHwNHchbXzf = 0.0;
				cUrbUOhjghGFgzfffMHGfFZudPMY = 0.0;
				bool flag = default(bool);
				while (true)
				{
					int num = -1810883832;
					while (true)
					{
						switch (num ^ -1810883831)
						{
						case 2:
							break;
						default:
							return;
						case 1:
							flag = gTyLLvDyPFrZEpsrKvookvvbBvf;
							gTyLLvDyPFrZEpsrKvookvvbBvf = false;
							num = -1810883830;
							continue;
						case 3:
						{
							int num2;
							if (flag)
							{
								num = -1810883831;
								num2 = num;
							}
							else
							{
								num = -1810883827;
								num2 = num;
							}
							continue;
						}
						case 0:
							NoiITHOkBgdirKSZopWLLfLYZOJ();
							num = -1810883827;
							continue;
						case 4:
							return;
						}
						break;
					}
				}
			}
		}

		private const long MDHCkXpcDBoerbAhbeXDLAjJDEm = 10000000L;

		private static UnityStopwatch DtfvERtbqMeUyAmkLVQHPYBCuNuS;

		private readonly ERozbzedZIZpjVzWAJHrXTMEMsM HZnDfeGkEodGvEXfoLZXMHFjjhXu;

		private readonly bool YOqDRfcuoFtyOvtdRqzIVFleDST;

		private double pPeDBcYdktmmzjiEiwaGqcbdtPc;

		public static UnityStopwatch Global => DtfvERtbqMeUyAmkLVQHPYBCuNuS ?? (DtfvERtbqMeUyAmkLVQHPYBCuNuS = new UnityStopwatch(isGlobal: true));

		public static long frequency => 10000000L;

		public override double offsetSeconds
		{
			get
			{
				return pPeDBcYdktmmzjiEiwaGqcbdtPc;
			}
			set
			{
				pPeDBcYdktmmzjiEiwaGqcbdtPc = value;
			}
		}

		public override long offsetTicks
		{
			get
			{
				return (long)(pPeDBcYdktmmzjiEiwaGqcbdtPc * 10000000.0);
			}
			set
			{
				pPeDBcYdktmmzjiEiwaGqcbdtPc = (double)value / 10000000.0;
			}
		}

		public override double elapsedSeconds => HZnDfeGkEodGvEXfoLZXMHFjjhXu.ElapsedSeconds + offsetSeconds;

		public override double elapsedSecondsRaw => HZnDfeGkEodGvEXfoLZXMHFjjhXu.ElapsedSeconds;

		public override long elapsedMilliseconds => (long)((HZnDfeGkEodGvEXfoLZXMHFjjhXu.ElapsedSeconds + pPeDBcYdktmmzjiEiwaGqcbdtPc) * 1000.0);

		public override long elapsedMillisecondsRaw => (long)(HZnDfeGkEodGvEXfoLZXMHFjjhXu.ElapsedSeconds * 1000.0);

		public override long elapsedTicks => (long)(elapsedSeconds * 10000000.0);

		public override long elapsedTicksRaw => (long)(elapsedSecondsRaw * 10000000.0);

		public override bool isRunning => HZnDfeGkEodGvEXfoLZXMHFjjhXu.IsRunning;

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
			HZnDfeGkEodGvEXfoLZXMHFjjhXu = new ERozbzedZIZpjVzWAJHrXTMEMsM();
			omkdCBibqOtXoJNjoaopcqBORdz();
			if (isGlobal)
			{
				Start();
			}
			YOqDRfcuoFtyOvtdRqzIVFleDST = isGlobal;
		}

		~UnityStopwatch()
		{
			kGTTwUsIqDloRKXObMzqjyczyLp();
		}

		public override void Stop()
		{
			if (YOqDRfcuoFtyOvtdRqzIVFleDST)
			{
				throw new Exception("The Global Stopwatch cannot be stopped.");
			}
			HZnDfeGkEodGvEXfoLZXMHFjjhXu.AsLGHAVbjPEacNmJeQPEsuzzptZ();
		}

		public override void Start()
		{
			if (YOqDRfcuoFtyOvtdRqzIVFleDST)
			{
				return;
			}
			while (true)
			{
				HZnDfeGkEodGvEXfoLZXMHFjjhXu.NoiITHOkBgdirKSZopWLLfLYZOJ();
				int num = -78375638;
				while (true)
				{
					switch (num ^ -78375637)
					{
					case 0:
						goto IL_0009;
					default:
						return;
					case 2:
						break;
					case 1:
						return;
					}
					break;
					IL_0009:
					num = -78375639;
				}
			}
		}

		public override void Reset()
		{
			if (YOqDRfcuoFtyOvtdRqzIVFleDST)
			{
				throw new Exception("The Global Stopwatch cannot be reset.");
			}
			HZnDfeGkEodGvEXfoLZXMHFjjhXu.CHWDoIJFbUPiCCQqjvBLnPoSWjTy();
		}

		private void omkdCBibqOtXoJNjoaopcqBORdz()
		{
			kGTTwUsIqDloRKXObMzqjyczyLp();
			ReInput.BeforeTimeManagerUpdateEvent += spiCZIbBixHwkYmPEBFXAXTGsXtO;
		}

		private void kGTTwUsIqDloRKXObMzqjyczyLp()
		{
			ReInput.BeforeTimeManagerUpdateEvent -= spiCZIbBixHwkYmPEBFXAXTGsXtO;
		}

		private void spiCZIbBixHwkYmPEBFXAXTGsXtO(UpdateLoopType P_0)
		{
			HZnDfeGkEodGvEXfoLZXMHFjjhXu.GzCliicOSMFLMvKajLgvnmGSSrh();
		}
	}
}
