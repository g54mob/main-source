using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace Rewired.Utils.Classes.Utility
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal class ThreadHelper : IDisposable
	{
		private const uint EdgitqWOHcdkDPmItGnOplmaDmK = 750u;

		private readonly Stopwatch mVvWXxiAtwPieoNAdspYRflscLk;

		private Thread CogoXqfgoUvretoPEYaoWIkbAAZ;

		private ManualResetEvent uDdbsrctslUcNLyBiCEuJfqurKg;

		private ManualResetEvent dKLBcLKTivsRzxjvumTjLMDuzLV;

		private AutoResetEvent cjSZIkuCUBpxeTYynJzKWDWHWPZ;

		private bool WzpDESaMrlBNFCSlBmoZUhFmcgZ;

		private bool VVkAmkClXTBeDRWXVEYxkqDaqQCG;

		private int nVuKZBeSCujYsigTvPwiRJakoMT;

		private bool HDXyjslCXEwvMCHAlJnniDnAhfr;

		private int KwUUzNRRsHkkSDxtlXPxWaWHnaM;

		private long bUgjReKIPAqvHOaMKKkiNrocTmx;

		private bool RJPLNPRdVDrxnjrFecieGqcrpWz;

		private int QtgexiQmAtFshNELJPpGqbwLrec;

		private long VUCHCQnLFMIQFHmNfOnMepbilFTE;

		private uint tYBEHWBhYAFORfqcBLpvLtPSFOBD;

		private readonly object yRQSrbtCbUBBSeXZDbLCbleLvfY;

		private Queue<Action> agQDBGcbfsJOmEpTZXpuBpQabKKd;

		private Queue<Action> PGGurnnEpbHDOxagvGQMBMEHFu;

		private bool lFyRCPvtkykuxclPMyKbgYaPOAv;

		private Action QZQzIHdVUkbsFXVndGOJVxdWLDD;

		private Action hNegADnHcyhbqXoLLZPcSqdayXL;

		private Action lrBgcPEOVgEYLmOEkFaMbtHXyKBn;

		private bool QQqHByfwytAJSuMZiCPjJlZYHKG;

		public bool isRunning
		{
			get
			{
				return VVkAmkClXTBeDRWXVEYxkqDaqQCG;
			}
		}

		public bool isStopped
		{
			get
			{
				if (!VVkAmkClXTBeDRWXVEYxkqDaqQCG)
				{
					if (CogoXqfgoUvretoPEYaoWIkbAAZ == null)
					{
						return true;
					}
					return !CogoXqfgoUvretoPEYaoWIkbAAZ.IsAlive;
				}
				return false;
			}
		}

		public bool useHighPrecitionTimer
		{
			get
			{
				if (!HDXyjslCXEwvMCHAlJnniDnAhfr)
				{
					return (long)KwUUzNRRsHkkSDxtlXPxWaWHnaM >= 750L;
				}
				return true;
			}
			set
			{
				if (value != HDXyjslCXEwvMCHAlJnniDnAhfr)
				{
					HDXyjslCXEwvMCHAlJnniDnAhfr = value;
					CYsdVSfsikVCkXSbKnlKCvtOPKy();
				}
			}
		}

		public bool useFixedTimeStep
		{
			get
			{
				return RJPLNPRdVDrxnjrFecieGqcrpWz;
			}
		}

		public int fixedTimeStepFPS
		{
			get
			{
				return KwUUzNRRsHkkSDxtlXPxWaWHnaM;
			}
			set
			{
				KwUUzNRRsHkkSDxtlXPxWaWHnaM = ((value > 0) ? value : 0);
				CYsdVSfsikVCkXSbKnlKCvtOPKy();
			}
		}

		public int timeoutMS
		{
			get
			{
				return QtgexiQmAtFshNELJPpGqbwLrec;
			}
			set
			{
				QtgexiQmAtFshNELJPpGqbwLrec = ((value > 0) ? value : 0);
				CYsdVSfsikVCkXSbKnlKCvtOPKy();
			}
		}

		public uint tick
		{
			get
			{
				return tYBEHWBhYAFORfqcBLpvLtPSFOBD;
			}
		}

		public event Action ThreadUpdateEvent
		{
			add
			{
				QZQzIHdVUkbsFXVndGOJVxdWLDD = (Action)Delegate.Combine(QZQzIHdVUkbsFXVndGOJVxdWLDD, value);
			}
			remove
			{
				QZQzIHdVUkbsFXVndGOJVxdWLDD = (Action)Delegate.Remove(QZQzIHdVUkbsFXVndGOJVxdWLDD, value);
			}
		}

		private event Action _ThreadStartedEvent
		{
			add
			{
				Action action = hNegADnHcyhbqXoLLZPcSqdayXL;
				Action action2 = default(Action);
				while (true)
				{
					int num = 789903874;
					while (true)
					{
						switch (num ^ 0x2F14FA00)
						{
						case 0:
							break;
						case 2:
							goto IL_0025;
						default:
							if ((object)action != action2)
							{
								goto IL_0025;
							}
							return;
						}
						break;
						IL_0025:
						action2 = action;
						Action value2 = (Action)Delegate.Combine(action2, b);
						action = Interlocked.CompareExchange(ref hNegADnHcyhbqXoLLZPcSqdayXL, value2, action2);
						num = 789903873;
					}
				}
			}
			remove
			{
				Action action = hNegADnHcyhbqXoLLZPcSqdayXL;
				Action action2 = default(Action);
				while (true)
				{
					int num = 1864409637;
					while (true)
					{
						switch (num ^ 0x6F20A226)
						{
						case 0:
							break;
						default:
							return;
						case 3:
							action2 = action;
							num = 1864409639;
							continue;
						case 1:
						{
							Action value2 = (Action)Delegate.Remove(action2, value3);
							action = Interlocked.CompareExchange(ref hNegADnHcyhbqXoLLZPcSqdayXL, value2, action2);
							int num2;
							if ((object)action != action2)
							{
								num = 1864409637;
								num2 = num;
							}
							else
							{
								num = 1864409636;
								num2 = num;
							}
							continue;
						}
						case 2:
							return;
						}
						break;
					}
				}
			}
		}

		public event Action ThreadStartedEvent
		{
			add
			{
				_ThreadStartedEvent += value;
			}
			remove
			{
				_ThreadStartedEvent -= value;
			}
		}

		private event Action _ThreadPreStopEvent
		{
			add
			{
				Action action = lrBgcPEOVgEYLmOEkFaMbtHXyKBn;
				Action action2 = default(Action);
				Action value2 = default(Action);
				while (true)
				{
					int num = -1840979049;
					while (true)
					{
						switch (num ^ -1840979051)
						{
						case 0:
							break;
						default:
							return;
						case 2:
							action2 = action;
							value2 = (Action)Delegate.Combine(action2, b);
							num = -1840979050;
							continue;
						case 3:
						{
							action = Interlocked.CompareExchange(ref lrBgcPEOVgEYLmOEkFaMbtHXyKBn, value2, action2);
							int num2;
							if ((object)action != action2)
							{
								num = -1840979049;
								num2 = num;
							}
							else
							{
								num = -1840979052;
								num2 = num;
							}
							continue;
						}
						case 1:
							return;
						}
						break;
					}
				}
			}
			remove
			{
				Action action = lrBgcPEOVgEYLmOEkFaMbtHXyKBn;
				Action action2 = default(Action);
				while (true)
				{
					int num = 1979981038;
					while (true)
					{
						switch (num ^ 0x76041CED)
						{
						case 2:
							break;
						case 3:
							action2 = action;
							num = 1979981037;
							continue;
						case 0:
						{
							Action value2 = (Action)Delegate.Remove(action2, value3);
							action = Interlocked.CompareExchange(ref lrBgcPEOVgEYLmOEkFaMbtHXyKBn, value2, action2);
							num = 1979981036;
							continue;
						}
						default:
							if ((object)action == action2)
							{
								return;
							}
							goto case 3;
						}
						break;
					}
				}
			}
		}

		public event Action ThreadPreStopEvent
		{
			add
			{
				_ThreadPreStopEvent += value;
			}
			remove
			{
				_ThreadPreStopEvent -= value;
			}
		}

		public static ThreadHelper Create(bool fixedTimeStep = false, int fixedTimeStepFPS = 100, bool useHighPrecisionTimer = false, int timeoutMS = 0)
		{
			if (fixedTimeStep)
			{
				goto IL_0003;
			}
			goto IL_0035;
			IL_0003:
			int num = 68751697;
			goto IL_0008;
			IL_0008:
			ThreadHelper result = default(ThreadHelper);
			while (true)
			{
				switch (num ^ 0x4191150)
				{
				case 0:
					break;
				case 1:
					result = new ThreadHelper(fixedTimeStepFPS, useHighPrecisionTimer, timeoutMS);
					num = 68751699;
					continue;
				case 2:
					goto IL_0035;
				default:
					return result;
				}
				break;
			}
			goto IL_0003;
			IL_0035:
			result = new ThreadHelper(timeoutMS);
			num = 68751699;
			goto IL_0008;
		}

		public static ThreadHelper CreateFixedTimeStep(int timeStepFPS, int timeoutMS = 0)
		{
			return CreateFixedTimeStep(timeStepFPS, false, timeoutMS);
		}

		public static ThreadHelper CreateFixedTimeStep(int timeStepFPS, bool useHighPrecisionTimer = false, int timeoutMS = 0)
		{
			return new ThreadHelper(timeStepFPS, useHighPrecisionTimer, timeoutMS);
		}

		private ThreadHelper()
			: this(0)
		{
		}

		private ThreadHelper(int timeoutMS)
			: this(0, false, timeoutMS)
		{
		}

		private ThreadHelper(int fixedTimeStepFPS, bool useHighPrecisionTimer, int timeoutMS)
		{
			while (true)
			{
				int num = 1531319720;
				while (true)
				{
					switch (num ^ 0x5B4615AC)
					{
					case 2:
						break;
					case 3:
						if (timeoutMS < 0)
						{
							timeoutMS = 0;
							num = 1531319721;
							continue;
						}
						goto case 5;
					case 0:
						if (fixedTimeStepFPS < 0)
						{
							fixedTimeStepFPS = 0;
							num = 1531319727;
							continue;
						}
						goto case 3;
					case 5:
						QtgexiQmAtFshNELJPpGqbwLrec = timeoutMS;
						KwUUzNRRsHkkSDxtlXPxWaWHnaM = fixedTimeStepFPS;
						HDXyjslCXEwvMCHAlJnniDnAhfr = useHighPrecisionTimer;
						num = 1531319725;
						continue;
					case 4:
						mVvWXxiAtwPieoNAdspYRflscLk = Stopwatch.Global;
						num = 1531319724;
						continue;
					default:
						CYsdVSfsikVCkXSbKnlKCvtOPKy();
						uDdbsrctslUcNLyBiCEuJfqurKg = new ManualResetEvent(false);
						dKLBcLKTivsRzxjvumTjLMDuzLV = new ManualResetEvent(false);
						cjSZIkuCUBpxeTYynJzKWDWHWPZ = new AutoResetEvent(false);
						yRQSrbtCbUBBSeXZDbLCbleLvfY = new object();
						agQDBGcbfsJOmEpTZXpuBpQabKKd = new Queue<Action>();
						PGGurnnEpbHDOxagvGQMBMEHFu = new Queue<Action>();
						return;
					}
					break;
				}
			}
		}

		public bool Start(bool wait)
		{
			if (VVkAmkClXTBeDRWXVEYxkqDaqQCG)
			{
				return false;
			}
			try
			{
				uDdbsrctslUcNLyBiCEuJfqurKg.Reset();
				cjSZIkuCUBpxeTYynJzKWDWHWPZ.Reset();
				CogoXqfgoUvretoPEYaoWIkbAAZ = new Thread(VzBGfhCnThtCTPAIjEpoSnIqHdsN);
				CogoXqfgoUvretoPEYaoWIkbAAZ.Start();
				while (true)
				{
					int num = -1989626092;
					while (true)
					{
						switch (num ^ -1989626091)
						{
						case 2:
							break;
						case 1:
						{
							int num2;
							if (wait)
							{
								num = -1989626091;
								num2 = num;
							}
							else
							{
								num = -1989626090;
								num2 = num;
							}
							continue;
						}
						case 0:
							uDdbsrctslUcNLyBiCEuJfqurKg.WaitOne();
							num = -1989626090;
							continue;
						default:
							return true;
						}
						break;
					}
				}
			}
			catch (Exception)
			{
				return false;
			}
		}

		public void Stop(bool wait)
		{
			if (CogoXqfgoUvretoPEYaoWIkbAAZ == null)
			{
				goto IL_000b;
			}
			goto IL_008b;
			IL_000b:
			int num = 813097572;
			goto IL_0010;
			IL_0010:
			switch (num ^ 0x3076E267)
			{
			case 0:
				break;
			default:
				return;
			case 1:
				goto IL_0039;
			case 6:
				goto IL_0046;
			case 4:
				goto IL_0056;
			case 2:
				goto IL_008b;
			case 3:
				return;
			case 5:
				return;
			}
			goto IL_000b;
			IL_008b:
			if (!VVkAmkClXTBeDRWXVEYxkqDaqQCG)
			{
				return;
			}
			goto IL_0046;
			IL_0046:
			if (!WzpDESaMrlBNFCSlBmoZUhFmcgZ)
			{
				return;
			}
			goto IL_0056;
			IL_0056:
			uDdbsrctslUcNLyBiCEuJfqurKg.Reset();
			WzpDESaMrlBNFCSlBmoZUhFmcgZ = false;
			cjSZIkuCUBpxeTYynJzKWDWHWPZ.Set();
			if (wait)
			{
				uDdbsrctslUcNLyBiCEuJfqurKg.WaitOne();
				num = 813097574;
				goto IL_0010;
			}
			goto IL_0039;
			IL_0039:
			PgZPlMozMoJLNxNdALvYkygDCFr();
			num = 813097570;
			goto IL_0010;
		}

		public bool EnqueueAction(Action action)
		{
			if (action == null)
			{
				return false;
			}
			if (!VVkAmkClXTBeDRWXVEYxkqDaqQCG)
			{
				return false;
			}
			if (!WzpDESaMrlBNFCSlBmoZUhFmcgZ)
			{
				return false;
			}
			ResetTimeout();
			lock (yRQSrbtCbUBBSeXZDbLCbleLvfY)
			{
				agQDBGcbfsJOmEpTZXpuBpQabKKd.Enqueue(action);
				while (true)
				{
					IL_0038:
					int num = -1123906024;
					while (true)
					{
						switch (num ^ -1123906023)
						{
						case 2:
							break;
						case 1:
							goto IL_0056;
						default:
							cjSZIkuCUBpxeTYynJzKWDWHWPZ.Set();
							goto end_IL_003d;
						}
						goto IL_0038;
						IL_0056:
						lFyRCPvtkykuxclPMyKbgYaPOAv = true;
						num = -1123906023;
						continue;
						end_IL_003d:
						break;
					}
					break;
				}
			}
			return true;
		}

		public bool InvokeActionSync(Action action)
		{
			if (!VVkAmkClXTBeDRWXVEYxkqDaqQCG)
			{
				return false;
			}
			if (!WzpDESaMrlBNFCSlBmoZUhFmcgZ)
			{
				return false;
			}
			EnqueueAction(action);
			WaitForActionQueueToFinish();
			return true;
		}

		public void WaitForActionQueueToFinish()
		{
			if (!VVkAmkClXTBeDRWXVEYxkqDaqQCG)
			{
				return;
			}
			while (WzpDESaMrlBNFCSlBmoZUhFmcgZ)
			{
				while (true)
				{
					IL_003b:
					ResetTimeout();
					int num = -2018254510;
					while (true)
					{
						switch (num ^ -2018254512)
						{
						case 0:
							num = -2018254511;
							continue;
						case 1:
							break;
						case 3:
							goto IL_003b;
						default:
							lock (yRQSrbtCbUBBSeXZDbLCbleLvfY)
							{
								dKLBcLKTivsRzxjvumTjLMDuzLV.Reset();
								nVuKZBeSCujYsigTvPwiRJakoMT++;
							}
							cjSZIkuCUBpxeTYynJzKWDWHWPZ.Set();
							dKLBcLKTivsRzxjvumTjLMDuzLV.WaitOne();
							lock (yRQSrbtCbUBBSeXZDbLCbleLvfY)
							{
								nVuKZBeSCujYsigTvPwiRJakoMT--;
								return;
							}
						}
						break;
					}
					break;
				}
			}
		}

		public void ResetTimeout()
		{
			VUCHCQnLFMIQFHmNfOnMepbilFTE = ((QtgexiQmAtFshNELJPpGqbwLrec > 0) ? (mVvWXxiAtwPieoNAdspYRflscLk.elapsedMillisecondsRaw + QtgexiQmAtFshNELJPpGqbwLrec) : 0);
		}

		private void VzBGfhCnThtCTPAIjEpoSnIqHdsN()
		{
			ResetTimeout();
			VVkAmkClXTBeDRWXVEYxkqDaqQCG = true;
			WzpDESaMrlBNFCSlBmoZUhFmcgZ = true;
			uDdbsrctslUcNLyBiCEuJfqurKg.Set();
			if (hNegADnHcyhbqXoLLZPcSqdayXL != null)
			{
				lock (hNegADnHcyhbqXoLLZPcSqdayXL)
				{
					try
					{
						hNegADnHcyhbqXoLLZPcSqdayXL();
					}
					catch (Exception ex)
					{
						Logger.LogError("Caught exception in thread start event callback.\n" + ex, true);
					}
				}
			}
			long num = default(long);
			long num3 = default(long);
			while (true)
			{
				IL_022a:
				if (WzpDESaMrlBNFCSlBmoZUhFmcgZ)
				{
					long elapsedTicksRaw = mVvWXxiAtwPieoNAdspYRflscLk.elapsedTicksRaw;
					num = elapsedTicksRaw + bUgjReKIPAqvHOaMKKkiNrocTmx;
					vRIEhkAWJyXJGsfomDstoiRHlaBW();
					lock (yRQSrbtCbUBBSeXZDbLCbleLvfY)
					{
						if (!lFyRCPvtkykuxclPMyKbgYaPOAv && nVuKZBeSCujYsigTvPwiRJakoMT > 0)
						{
							dKLBcLKTivsRzxjvumTjLMDuzLV.Set();
						}
					}
					if (QZQzIHdVUkbsFXVndGOJVxdWLDD != null)
					{
						try
						{
							QZQzIHdVUkbsFXVndGOJVxdWLDD();
						}
						catch (Exception ex2)
						{
							Logger.LogError("Exception occurred in a Thread Update Event callback.\n" + ex2, true);
						}
					}
					if (!RJPLNPRdVDrxnjrFecieGqcrpWz)
					{
						goto IL_0146;
					}
					if (HDXyjslCXEwvMCHAlJnniDnAhfr)
					{
						goto IL_0179;
					}
					if ((long)KwUUzNRRsHkkSDxtlXPxWaWHnaM >= 750L)
					{
						goto IL_0105;
					}
					goto IL_01bf;
				}
				int num2 = -372735766;
				goto IL_010a;
				IL_01bf:
				num3 = num - mVvWXxiAtwPieoNAdspYRflscLk.elapsedTicksRaw;
				num2 = -372735772;
				goto IL_010a;
				IL_010a:
				while (true)
				{
					switch (num2 ^ -372735776)
					{
					case 2:
						break;
					case 8:
						goto IL_0146;
					case 10:
						if (lrBgcPEOVgEYLmOEkFaMbtHXyKBn != null)
						{
							num2 = -372735771;
							continue;
						}
						goto IL_027a;
					case 6:
						goto IL_0179;
					case 0:
						goto IL_0191;
					case 3:
						WzpDESaMrlBNFCSlBmoZUhFmcgZ = false;
						num2 = -372735775;
						continue;
					case 9:
						goto IL_01bf;
					case 4:
						if (num3 > 0)
						{
							cjSZIkuCUBpxeTYynJzKWDWHWPZ.WaitOne(TimeSpan.FromTicks(Stopwatch.ConvertTo100NSTicks(num3)));
							num2 = -372735768;
							continue;
						}
						goto IL_0146;
					case 7:
						goto IL_0203;
					case 1:
						goto IL_022a;
					default:
						{
							lock (lrBgcPEOVgEYLmOEkFaMbtHXyKBn)
							{
								try
								{
									lrBgcPEOVgEYLmOEkFaMbtHXyKBn();
								}
								catch (Exception ex3)
								{
									Logger.LogError("Caught exception in thread pre-stop event event callback.\n" + ex3, true);
								}
							}
							goto IL_027a;
						}
						IL_027a:
						VVkAmkClXTBeDRWXVEYxkqDaqQCG = false;
						uDdbsrctslUcNLyBiCEuJfqurKg.Set();
						return;
					}
					break;
					IL_0203:
					int num4;
					if (mVvWXxiAtwPieoNAdspYRflscLk.elapsedMillisecondsRaw >= VUCHCQnLFMIQFHmNfOnMepbilFTE)
					{
						num2 = -372735773;
						num4 = num2;
					}
					else
					{
						num2 = -372735775;
						num4 = num2;
					}
					continue;
					IL_0191:
					int num5;
					if (QtgexiQmAtFshNELJPpGqbwLrec > 0)
					{
						num2 = -372735769;
						num5 = num2;
					}
					else
					{
						num2 = -372735775;
						num5 = num2;
					}
				}
				goto IL_0105;
				IL_0146:
				tYBEHWBhYAFORfqcBLpvLtPSFOBD = ((tYBEHWBhYAFORfqcBLpvLtPSFOBD != uint.MaxValue) ? (tYBEHWBhYAFORfqcBLpvLtPSFOBD + 1) : 0u);
				num2 = -372735776;
				goto IL_010a;
				IL_0105:
				num2 = -372735770;
				goto IL_010a;
				IL_0179:
				while (mVvWXxiAtwPieoNAdspYRflscLk.elapsedTicksRaw < num)
				{
				}
				num2 = -372735768;
				goto IL_010a;
			}
		}

		private void vRIEhkAWJyXJGsfomDstoiRHlaBW()
		{
			if (!lFyRCPvtkykuxclPMyKbgYaPOAv)
			{
				return;
			}
			lock (yRQSrbtCbUBBSeXZDbLCbleLvfY)
			{
				MiscTools.Swap(ref agQDBGcbfsJOmEpTZXpuBpQabKKd, ref PGGurnnEpbHDOxagvGQMBMEHFu);
				while (true)
				{
					IL_0027:
					int num = 588961352;
					while (true)
					{
						switch (num ^ 0x231AD649)
						{
						case 0:
							break;
						default:
							goto end_IL_002c;
						case 1:
							goto IL_0045;
						case 2:
							goto end_IL_002c;
						}
						goto IL_0027;
						IL_0045:
						lFyRCPvtkykuxclPMyKbgYaPOAv = false;
						num = 588961355;
						continue;
						end_IL_002c:
						break;
					}
					break;
				}
			}
			while (PGGurnnEpbHDOxagvGQMBMEHFu.Count > 0)
			{
				Action action = PGGurnnEpbHDOxagvGQMBMEHFu.Dequeue();
				try
				{
					action();
				}
				catch (Exception ex)
				{
					Logger.LogError("Exception occurred while processing thread Action queue.\n" + ex, true);
				}
			}
		}

		private void CYsdVSfsikVCkXSbKnlKCvtOPKy()
		{
			if (KwUUzNRRsHkkSDxtlXPxWaWHnaM <= 0)
			{
				goto IL_0009;
			}
			goto IL_0049;
			IL_0009:
			int num = 918179383;
			goto IL_000e;
			IL_000e:
			while (true)
			{
				switch (num ^ 0x36BA4E34)
				{
				case 2:
					break;
				case 4:
					bUgjReKIPAqvHOaMKKkiNrocTmx = Stopwatch.frequency / KwUUzNRRsHkkSDxtlXPxWaWHnaM;
					num = 918179381;
					continue;
				case 0:
					goto IL_0049;
				case 3:
					RJPLNPRdVDrxnjrFecieGqcrpWz = false;
					num = 918179381;
					continue;
				default:
					ResetTimeout();
					return;
				}
				break;
			}
			goto IL_0009;
			IL_0049:
			RJPLNPRdVDrxnjrFecieGqcrpWz = true;
			num = 918179376;
			goto IL_000e;
		}

		private void PgZPlMozMoJLNxNdALvYkygDCFr()
		{
			CogoXqfgoUvretoPEYaoWIkbAAZ = null;
			VVkAmkClXTBeDRWXVEYxkqDaqQCG = false;
			while (true)
			{
				int num = 510874507;
				while (true)
				{
					switch (num ^ 0x1E73538F)
					{
					case 0:
						break;
					default:
						return;
					case 4:
						WzpDESaMrlBNFCSlBmoZUhFmcgZ = false;
						agQDBGcbfsJOmEpTZXpuBpQabKKd.Clear();
						PGGurnnEpbHDOxagvGQMBMEHFu.Clear();
						num = 510874509;
						continue;
					case 2:
						lFyRCPvtkykuxclPMyKbgYaPOAv = false;
						nVuKZBeSCujYsigTvPwiRJakoMT = 0;
						uDdbsrctslUcNLyBiCEuJfqurKg.Reset();
						num = 510874508;
						continue;
					case 3:
						dKLBcLKTivsRzxjvumTjLMDuzLV.Reset();
						VUCHCQnLFMIQFHmNfOnMepbilFTE = 0L;
						tYBEHWBhYAFORfqcBLpvLtPSFOBD = 0u;
						num = 510874510;
						continue;
					case 1:
						return;
					}
					break;
				}
			}
		}

		public void Dispose()
		{
			Dispose(true);
			GC.SuppressFinalize(this);
		}

		~ThreadHelper()
		{
			Dispose(false);
		}

		protected void Dispose(bool disposing)
		{
			if (QQqHByfwytAJSuMZiCPjJlZYHKG)
			{
				goto IL_0008;
			}
			goto IL_003a;
			IL_0008:
			int num = 1899131189;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num ^ 0x71327136)
				{
				case 2:
					break;
				default:
					return;
				case 3:
					return;
				case 4:
					goto IL_003a;
				case 0:
					QQqHByfwytAJSuMZiCPjJlZYHKG = true;
					num = 1899131187;
					continue;
				case 1:
					goto IL_0059;
				case 5:
					return;
				}
				break;
			}
			goto IL_0008;
			IL_0059:
			WzpDESaMrlBNFCSlBmoZUhFmcgZ = false;
			num = 1899131190;
			goto IL_000d;
			IL_003a:
			if (disposing)
			{
				Stop(true);
				num = 1899131190;
				goto IL_000d;
			}
			goto IL_0059;
		}

		[Conditional("DEBUG_THREAD_HELPER")]
		private static void SifsmiXdrIyfZAjNjbCqHJtxcbFZ(object P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			while (true)
			{
				Logger.Log(P_0, true);
				int num = 1759028484;
				while (true)
				{
					switch (num ^ 0x68D8A504)
					{
					case 2:
						goto IL_0004;
					default:
						return;
					case 1:
						break;
					case 0:
						return;
					}
					break;
					IL_0004:
					num = 1759028485;
				}
			}
		}
	}
}
