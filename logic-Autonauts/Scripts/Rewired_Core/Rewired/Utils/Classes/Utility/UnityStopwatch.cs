using System;
using UnityEngine;

namespace Rewired.Utils.Classes.Utility
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal sealed class UnityStopwatch : StopwatchBase
	{
		private class hPiGfmOoSMousyhBRqRiRwGFnUz
		{
			public const long axGcSIHwysjhBWRIGTTOdMKXmDz = 10000000L;

			private float UMOhudqUqWkGRVCVNloYfJHKYct;

			private bool VVkAmkClXTBeDRWXVEYxkqDaqQCG;

			private float CuMiuhtgxwNbJoXmMXScBDWycGb;

			private double BSrlWZNNWtQtzIMEqogBJxJjAht;

			public bool IsRunning
			{
				get
				{
					return VVkAmkClXTBeDRWXVEYxkqDaqQCG;
				}
			}

			public double ElapsedSeconds
			{
				get
				{
					if (!VVkAmkClXTBeDRWXVEYxkqDaqQCG)
					{
						return BSrlWZNNWtQtzIMEqogBJxJjAht;
					}
					return Time.realtimeSinceStartup - CuMiuhtgxwNbJoXmMXScBDWycGb;
				}
			}

			public void rdEJYvExbWYUXSDuseVgzyXPBhA()
			{
				UMOhudqUqWkGRVCVNloYfJHKYct = Time.realtimeSinceStartup;
			}

			public void gvigjQaykylkiDxmhkUQKBzXkGmr()
			{
				if (VVkAmkClXTBeDRWXVEYxkqDaqQCG)
				{
					return;
				}
				while (true)
				{
					VVkAmkClXTBeDRWXVEYxkqDaqQCG = true;
					int num = 741578285;
					while (true)
					{
						switch (num ^ 0x2C33962C)
						{
						case 0:
							goto IL_0009;
						case 2:
							break;
						default:
							CuMiuhtgxwNbJoXmMXScBDWycGb = UMOhudqUqWkGRVCVNloYfJHKYct;
							return;
						}
						break;
						IL_0009:
						num = 741578286;
					}
				}
			}

			public void huLDbFcfCNXRtuaevwhVfiLuQmy()
			{
				if (!VVkAmkClXTBeDRWXVEYxkqDaqQCG)
				{
					goto IL_0008;
				}
				goto IL_0036;
				IL_0008:
				int num = -1311503864;
				goto IL_000d;
				IL_000d:
				while (true)
				{
					switch (num ^ -1311503863)
					{
					case 4:
						break;
					default:
						return;
					case 1:
						return;
					case 0:
						goto IL_0036;
					case 2:
						BSrlWZNNWtQtzIMEqogBJxJjAht += UMOhudqUqWkGRVCVNloYfJHKYct - CuMiuhtgxwNbJoXmMXScBDWycGb;
						num = -1311503862;
						continue;
					case 3:
						return;
					}
					break;
				}
				goto IL_0008;
				IL_0036:
				VVkAmkClXTBeDRWXVEYxkqDaqQCG = false;
				num = -1311503861;
				goto IL_000d;
			}

			public void xaGVjRxEvIdELjjBskoGFDUNmrm()
			{
				CuMiuhtgxwNbJoXmMXScBDWycGb = 0f;
				BSrlWZNNWtQtzIMEqogBJxJjAht = 0.0;
				bool vVkAmkClXTBeDRWXVEYxkqDaqQCG = VVkAmkClXTBeDRWXVEYxkqDaqQCG;
				VVkAmkClXTBeDRWXVEYxkqDaqQCG = false;
				if (!vVkAmkClXTBeDRWXVEYxkqDaqQCG)
				{
					return;
				}
				while (true)
				{
					int num = 1065630911;
					while (true)
					{
						switch (num ^ 0x3F843CBE)
						{
						case 0:
							break;
						default:
							return;
						case 1:
							goto IL_0049;
						case 2:
							return;
						}
						break;
						IL_0049:
						gvigjQaykylkiDxmhkUQKBzXkGmr();
						num = 1065630908;
					}
				}
			}
		}

		private const long hYTshpHoTFEhrWGvsfFUkVqSQEpB = 10000000L;

		private static UnityStopwatch wQfvAPDLOIPnhXPVGnIhOfoVUVS;

		private readonly hPiGfmOoSMousyhBRqRiRwGFnUz mVvWXxiAtwPieoNAdspYRflscLk;

		private readonly bool rrcBiqhKTNTyRCkKCGLHgNhdbQkf;

		private double YWucqlgcRzgvmpITfYRZleTuasVp;

		public static UnityStopwatch Global
		{
			get
			{
				return wQfvAPDLOIPnhXPVGnIhOfoVUVS ?? (wQfvAPDLOIPnhXPVGnIhOfoVUVS = new UnityStopwatch(true));
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
				return YWucqlgcRzgvmpITfYRZleTuasVp;
			}
			set
			{
				YWucqlgcRzgvmpITfYRZleTuasVp = value;
			}
		}

		public override long offsetTicks
		{
			get
			{
				return (long)(YWucqlgcRzgvmpITfYRZleTuasVp * 10000000.0);
			}
			set
			{
				YWucqlgcRzgvmpITfYRZleTuasVp = (double)value / 10000000.0;
			}
		}

		public override double elapsedSeconds
		{
			get
			{
				return mVvWXxiAtwPieoNAdspYRflscLk.ElapsedSeconds + offsetSeconds;
			}
		}

		public override double elapsedSecondsRaw
		{
			get
			{
				return mVvWXxiAtwPieoNAdspYRflscLk.ElapsedSeconds;
			}
		}

		public override long elapsedMilliseconds
		{
			get
			{
				return (long)((mVvWXxiAtwPieoNAdspYRflscLk.ElapsedSeconds + YWucqlgcRzgvmpITfYRZleTuasVp) * 1000.0);
			}
		}

		public override long elapsedMillisecondsRaw
		{
			get
			{
				return (long)(mVvWXxiAtwPieoNAdspYRflscLk.ElapsedSeconds * 1000.0);
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
				return mVvWXxiAtwPieoNAdspYRflscLk.IsRunning;
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
			mVvWXxiAtwPieoNAdspYRflscLk = new hPiGfmOoSMousyhBRqRiRwGFnUz();
			VlirbQOEZItErcbCloLmcotJGaCi();
			if (isGlobal)
			{
				Start();
			}
			rrcBiqhKTNTyRCkKCGLHgNhdbQkf = isGlobal;
		}

		~UnityStopwatch()
		{
			FNZCyVfOdZzoEduyaxjfnvEmlnK();
		}

		public override void Stop()
		{
			if (rrcBiqhKTNTyRCkKCGLHgNhdbQkf)
			{
				throw new Exception("The Global Stopwatch cannot be stopped.");
			}
			while (true)
			{
				mVvWXxiAtwPieoNAdspYRflscLk.huLDbFcfCNXRtuaevwhVfiLuQmy();
				int num = 705058551;
				while (true)
				{
					switch (num ^ 0x2A0656F5)
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
					num = 705058548;
				}
			}
		}

		public override void Start()
		{
			if (!rrcBiqhKTNTyRCkKCGLHgNhdbQkf)
			{
				mVvWXxiAtwPieoNAdspYRflscLk.gvigjQaykylkiDxmhkUQKBzXkGmr();
			}
		}

		public override void Reset()
		{
			if (rrcBiqhKTNTyRCkKCGLHgNhdbQkf)
			{
				throw new Exception("The Global Stopwatch cannot be reset.");
			}
			mVvWXxiAtwPieoNAdspYRflscLk.xaGVjRxEvIdELjjBskoGFDUNmrm();
		}

		private void VlirbQOEZItErcbCloLmcotJGaCi()
		{
			FNZCyVfOdZzoEduyaxjfnvEmlnK();
			ReInput.BeforeTimeManagerUpdateEvent += VtisaHZOBdibbEhmThwWADtaHEQt;
		}

		private void FNZCyVfOdZzoEduyaxjfnvEmlnK()
		{
			ReInput.BeforeTimeManagerUpdateEvent -= VtisaHZOBdibbEhmThwWADtaHEQt;
		}

		private void VtisaHZOBdibbEhmThwWADtaHEQt(UpdateLoopType P_0)
		{
			mVvWXxiAtwPieoNAdspYRflscLk.rdEJYvExbWYUXSDuseVgzyXPBhA();
		}
	}
}
