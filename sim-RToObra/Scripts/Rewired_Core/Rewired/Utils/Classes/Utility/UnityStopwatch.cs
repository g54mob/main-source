using System;
using UnityEngine;

namespace Rewired.Utils.Classes.Utility
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal sealed class UnityStopwatch : StopwatchBase
	{
		private class YOsPDtgHgOBKJMLezyIguiiXaZu
		{
			public const long LiWWTRUcqyAWsirNuATEalAJTMuv = 10000000L;

			private float lRUmpoYOwAGjufqQzOsQQIPMYty;

			private bool emuVrtBFJJrHewGGlSYtRURcNOX;

			private float pLGxTvJaeesjQEGSciDKsxLuPnH;

			private double oDhcKPrDexvKTkDACobLohPlFgc;

			public bool IsRunning
			{
				get
				{
					return emuVrtBFJJrHewGGlSYtRURcNOX;
				}
			}

			public double ElapsedSeconds
			{
				get
				{
					if (!emuVrtBFJJrHewGGlSYtRURcNOX)
					{
						return oDhcKPrDexvKTkDACobLohPlFgc;
					}
					return Time.realtimeSinceStartup - pLGxTvJaeesjQEGSciDKsxLuPnH;
				}
			}

			public void UZSQFwoMfSAzsmmSKmseCCiJWWD()
			{
				lRUmpoYOwAGjufqQzOsQQIPMYty = Time.realtimeSinceStartup;
			}

			public void HTeWiJSswgFIFVAtPBCSclhPFDl()
			{
				if (emuVrtBFJJrHewGGlSYtRURcNOX)
				{
					while (true)
					{
						switch (0x25B48E66 ^ 0x25B48E64)
						{
						case 0:
							continue;
						case 2:
							return;
						}
						break;
					}
				}
				emuVrtBFJJrHewGGlSYtRURcNOX = true;
				pLGxTvJaeesjQEGSciDKsxLuPnH = lRUmpoYOwAGjufqQzOsQQIPMYty;
			}

			public void GUDzwCHJALfoEQNzBBdJDJLeotpg()
			{
				if (emuVrtBFJJrHewGGlSYtRURcNOX)
				{
					emuVrtBFJJrHewGGlSYtRURcNOX = false;
					oDhcKPrDexvKTkDACobLohPlFgc += lRUmpoYOwAGjufqQzOsQQIPMYty - pLGxTvJaeesjQEGSciDKsxLuPnH;
				}
			}

			public void EEGiMNPSMElaPgKQdmScoWLedfb()
			{
				pLGxTvJaeesjQEGSciDKsxLuPnH = 0f;
				bool flag = default(bool);
				while (true)
				{
					int num = -455789251;
					while (true)
					{
						switch (num ^ -455789255)
						{
						case 3:
							break;
						default:
							return;
						case 2:
							HTeWiJSswgFIFVAtPBCSclhPFDl();
							num = -455789256;
							continue;
						case 0:
						{
							int num2;
							if (!flag)
							{
								num = -455789256;
								num2 = num;
							}
							else
							{
								num = -455789253;
								num2 = num;
							}
							continue;
						}
						case 4:
							oDhcKPrDexvKTkDACobLohPlFgc = 0.0;
							flag = emuVrtBFJJrHewGGlSYtRURcNOX;
							emuVrtBFJJrHewGGlSYtRURcNOX = false;
							num = -455789255;
							continue;
						case 1:
							return;
						}
						break;
					}
				}
			}
		}

		private const long UMXZmanKNXhCKiGeEeJAIeqGoFwg = 10000000L;

		private static UnityStopwatch JNrcNPnFBYitYjPCkpFKdphLNRA;

		private readonly YOsPDtgHgOBKJMLezyIguiiXaZu XJdPlaQAlkHyVCjLHboQazhehtx;

		private readonly bool URuWnfeGJTzDqcXToeJDcCxpDBbd;

		private double fsoxviWYLdMMBeBQRlRJFvDkdvE;

		public static UnityStopwatch Global
		{
			get
			{
				return JNrcNPnFBYitYjPCkpFKdphLNRA ?? (JNrcNPnFBYitYjPCkpFKdphLNRA = new UnityStopwatch(true));
			}
		}

		public static long frequency
		{
			get
			{
				return 10000000L;
			}
		}

		public override double offsetSeconds
		{
			get
			{
				return fsoxviWYLdMMBeBQRlRJFvDkdvE;
			}
			set
			{
				fsoxviWYLdMMBeBQRlRJFvDkdvE = value;
			}
		}

		public override long offsetTicks
		{
			get
			{
				return (long)(fsoxviWYLdMMBeBQRlRJFvDkdvE * 10000000.0);
			}
			set
			{
				fsoxviWYLdMMBeBQRlRJFvDkdvE = (double)value / 10000000.0;
			}
		}

		public override double elapsedSeconds
		{
			get
			{
				return XJdPlaQAlkHyVCjLHboQazhehtx.ElapsedSeconds + offsetSeconds;
			}
		}

		public override double elapsedSecondsRaw
		{
			get
			{
				return XJdPlaQAlkHyVCjLHboQazhehtx.ElapsedSeconds;
			}
		}

		public override long elapsedMilliseconds
		{
			get
			{
				return (long)((XJdPlaQAlkHyVCjLHboQazhehtx.ElapsedSeconds + fsoxviWYLdMMBeBQRlRJFvDkdvE) * 1000.0);
			}
		}

		public override long elapsedMillisecondsRaw
		{
			get
			{
				return (long)(XJdPlaQAlkHyVCjLHboQazhehtx.ElapsedSeconds * 1000.0);
			}
		}

		public override long elapsedTicks
		{
			get
			{
				return (long)(elapsedSeconds * 10000000.0);
			}
		}

		public override long elapsedTicksRaw
		{
			get
			{
				return (long)(elapsedSecondsRaw * 10000000.0);
			}
		}

		public override bool isRunning
		{
			get
			{
				return XJdPlaQAlkHyVCjLHboQazhehtx.IsRunning;
			}
		}

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

		private UnityStopwatch(bool isGlobal)
		{
			XJdPlaQAlkHyVCjLHboQazhehtx = new YOsPDtgHgOBKJMLezyIguiiXaZu();
			gywhyVyoNAkhUWRDXMHiPjbFjnVb();
			if (isGlobal)
			{
				Start();
			}
			URuWnfeGJTzDqcXToeJDcCxpDBbd = isGlobal;
		}

		~UnityStopwatch()
		{
			qvBthUmBbVdLlPWlMAlliACqUeNp();
		}

		public override void Stop()
		{
			if (URuWnfeGJTzDqcXToeJDcCxpDBbd)
			{
				throw new Exception("The Global Stopwatch cannot be stopped.");
			}
			XJdPlaQAlkHyVCjLHboQazhehtx.GUDzwCHJALfoEQNzBBdJDJLeotpg();
		}

		public override void Start()
		{
			if (URuWnfeGJTzDqcXToeJDcCxpDBbd)
			{
				while (true)
				{
					switch (-1032047190 ^ -1032047192)
					{
					case 0:
						continue;
					case 2:
						return;
					}
					break;
				}
			}
			XJdPlaQAlkHyVCjLHboQazhehtx.HTeWiJSswgFIFVAtPBCSclhPFDl();
		}

		public override void Reset()
		{
			if (URuWnfeGJTzDqcXToeJDcCxpDBbd)
			{
				throw new Exception("The Global Stopwatch cannot be reset.");
			}
			while (true)
			{
				XJdPlaQAlkHyVCjLHboQazhehtx.EEGiMNPSMElaPgKQdmScoWLedfb();
				int num = 2144189953;
				while (true)
				{
					switch (num ^ 0x7FCDBE03)
					{
					case 0:
						goto IL_0013;
					default:
						return;
					case 1:
						break;
					case 2:
						return;
					}
					break;
					IL_0013:
					num = 2144189954;
				}
			}
		}

		private void gywhyVyoNAkhUWRDXMHiPjbFjnVb()
		{
			qvBthUmBbVdLlPWlMAlliACqUeNp();
			ReInput.BeforeTimeManagerUpdateEvent += sroidYdoPhgGWbBrpNeOeuxXjDRZ;
		}

		private void qvBthUmBbVdLlPWlMAlliACqUeNp()
		{
			ReInput.BeforeTimeManagerUpdateEvent -= sroidYdoPhgGWbBrpNeOeuxXjDRZ;
		}

		private void sroidYdoPhgGWbBrpNeOeuxXjDRZ(UpdateLoopType P_0)
		{
			XJdPlaQAlkHyVCjLHboQazhehtx.UZSQFwoMfSAzsmmSKmseCCiJWWD();
		}
	}
}
