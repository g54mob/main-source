using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

namespace Rewired.Utils.Classes.Utility
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal class ThreadHelper : IDisposable
	{
		private const uint hciHJncIuiNkMwcjayxHbAEpOOl = 750u;

		private readonly Stopwatch HZnDfeGkEodGvEXfoLZXMHFjjhXu;

		private Thread fqsCBjdBBAqwxHGTJtzpEGieeHqQ;

		private ManualResetEvent BxbXjaVFHljySXwntdTjhOppJzV;

		private ManualResetEvent WrBVgfwOgtjzAUFUicXMNNetumu;

		private AutoResetEvent LBChorAfyRiRxuXleCRBWiTAIVg;

		private bool rvbvyZWaKzIASnmICLNQCPhhhle;

		private bool gTyLLvDyPFrZEpsrKvookvvbBvf;

		private int KUiKrMQUtquTzRwygsfvPeUtxxo;

		private bool qKZfTzIPgCLbJhhhqpqgKsBZWgMD;

		private int zvIKbUfRJRjjLqRCcEsqYhKSfkfK;

		private long YtkoYfcDuGlxIxodZsHxPMOlblKc;

		private bool wQFfiGgvsLemeoAcxVTjDEGcmeME;

		private int hxyIJbmmhtACeuSeKcyTgLOCicJ;

		private long wQEhuPHwsCXnOFAkeFOPlLZyaWad;

		private uint EZNcyZdjNOHcGHeDUIpgjlUJNfk;

		private readonly object BwAojkLXSGMwNHhuGbgBbjYKXab;

		private Queue<Action> RDMgHZZIVgJZnUoCKOXrbeOjTGf;

		private Queue<Action> cgYTdqVkrrFaEdlBrbUVZIcRlSND;

		private bool YBucbEHZTmKrsPiyPObasHCWiDIE;

		private Action zsOlDCLdystlIwSNknGGXALRAyi;

		private Action MRskNWDpJuTcdgwwSKszWnFdtKq;

		private Action IsDNMKwrsoFVCPmlzHkPnZtWPzi;

		private bool xRygqjRmTtURDPiwlgMmFcdNBrr;

		public bool isRunning => gTyLLvDyPFrZEpsrKvookvvbBvf;

		public bool isStopped
		{
			get
			{
				if (!gTyLLvDyPFrZEpsrKvookvvbBvf)
				{
					if (fqsCBjdBBAqwxHGTJtzpEGieeHqQ == null)
					{
						return true;
					}
					return !fqsCBjdBBAqwxHGTJtzpEGieeHqQ.IsAlive;
				}
				return false;
			}
		}

		public bool useHighPrecitionTimer
		{
			get
			{
				if (!qKZfTzIPgCLbJhhhqpqgKsBZWgMD)
				{
					return (long)zvIKbUfRJRjjLqRCcEsqYhKSfkfK >= 750L;
				}
				return true;
			}
			set
			{
				if (value == qKZfTzIPgCLbJhhhqpqgKsBZWgMD)
				{
					goto IL_0009;
				}
				goto IL_0033;
				IL_0009:
				int num = 211770914;
				goto IL_000e;
				IL_000e:
				switch (num ^ 0xC9F5E20)
				{
				case 3:
					break;
				default:
					return;
				case 2:
					return;
				case 1:
					goto IL_0033;
				case 0:
					return;
				}
				goto IL_0009;
				IL_0033:
				qKZfTzIPgCLbJhhhqpqgKsBZWgMD = value;
				jCeuwTLVRiVBdiqGVZARKjLRGVNh();
				num = 211770912;
				goto IL_000e;
			}
		}

		public bool useFixedTimeStep => wQFfiGgvsLemeoAcxVTjDEGcmeME;

		public int fixedTimeStepFPS
		{
			get
			{
				return zvIKbUfRJRjjLqRCcEsqYhKSfkfK;
			}
			set
			{
				zvIKbUfRJRjjLqRCcEsqYhKSfkfK = ((value > 0) ? value : 0);
				jCeuwTLVRiVBdiqGVZARKjLRGVNh();
			}
		}

		public int timeoutMS
		{
			get
			{
				return hxyIJbmmhtACeuSeKcyTgLOCicJ;
			}
			set
			{
				hxyIJbmmhtACeuSeKcyTgLOCicJ = ((value > 0) ? value : 0);
				jCeuwTLVRiVBdiqGVZARKjLRGVNh();
			}
		}

		public uint tick => EZNcyZdjNOHcGHeDUIpgjlUJNfk;

		public event Action ThreadUpdateEvent
		{
			add
			{
				zsOlDCLdystlIwSNknGGXALRAyi = (Action)Delegate.Combine(zsOlDCLdystlIwSNknGGXALRAyi, value);
			}
			remove
			{
				zsOlDCLdystlIwSNknGGXALRAyi = (Action)Delegate.Remove(zsOlDCLdystlIwSNknGGXALRAyi, value);
			}
		}

		private event Action _ThreadStartedEvent
		{
			add
			{
				Action action = MRskNWDpJuTcdgwwSKszWnFdtKq;
				Action action2;
				do
				{
					action2 = action;
					Action value2 = (Action)Delegate.Combine(action2, value);
					action = Interlocked.CompareExchange(ref MRskNWDpJuTcdgwwSKszWnFdtKq, value2, action2);
				}
				while ((object)action != action2);
			}
			remove
			{
				Action action = MRskNWDpJuTcdgwwSKszWnFdtKq;
				while (true)
				{
					int num = 439140867;
					while (true)
					{
						switch (num ^ 0x1A2CC202)
						{
						case 2:
							break;
						default:
							return;
						case 1:
						{
							Action action2 = action;
							Action value2 = (Action)Delegate.Remove(action2, value);
							action = Interlocked.CompareExchange(ref MRskNWDpJuTcdgwwSKszWnFdtKq, value2, action2);
							int num2;
							if ((object)action == action2)
							{
								num = 439140866;
								num2 = num;
							}
							else
							{
								num = 439140867;
								num2 = num;
							}
							continue;
						}
						case 0:
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
				Action action = IsDNMKwrsoFVCPmlzHkPnZtWPzi;
				Action action2 = default(Action);
				Action value2 = default(Action);
				while (true)
				{
					int num = -15134362;
					while (true)
					{
						switch (num ^ -15134361)
						{
						case 2:
							break;
						default:
							return;
						case 1:
							action2 = action;
							num = -15134361;
							continue;
						case 3:
						{
							action = Interlocked.CompareExchange(ref IsDNMKwrsoFVCPmlzHkPnZtWPzi, value2, action2);
							int num2;
							if ((object)action == action2)
							{
								num = -15134365;
								num2 = num;
							}
							else
							{
								num = -15134362;
								num2 = num;
							}
							continue;
						}
						case 0:
							value2 = (Action)Delegate.Combine(action2, value);
							num = -15134364;
							continue;
						case 4:
							return;
						}
						break;
					}
				}
			}
			remove
			{
				Action action = IsDNMKwrsoFVCPmlzHkPnZtWPzi;
				Action action2 = default(Action);
				Action value2 = default(Action);
				while (true)
				{
					int num = -1981645047;
					while (true)
					{
						switch (num ^ -1981645048)
						{
						case 4:
							break;
						default:
							return;
						case 1:
							action2 = action;
							num = -1981645048;
							continue;
						case 0:
							value2 = (Action)Delegate.Remove(action2, value);
							num = -1981645045;
							continue;
						case 3:
						{
							action = Interlocked.CompareExchange(ref IsDNMKwrsoFVCPmlzHkPnZtWPzi, value2, action2);
							int num2;
							if ((object)action == action2)
							{
								num = -1981645046;
								num2 = num;
							}
							else
							{
								num = -1981645047;
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
			ThreadHelper result;
			if (fixedTimeStep)
			{
				result = new ThreadHelper(fixedTimeStepFPS, useHighPrecisionTimer, timeoutMS);
			}
			else
			{
				while (true)
				{
					result = new ThreadHelper(timeoutMS);
					int num = 24833399;
					while (true)
					{
						switch (num ^ 0x17AED76)
						{
						case 0:
							num = 24833396;
							continue;
						case 2:
							break;
						default:
							goto end_IL_002c;
						}
						break;
					}
					continue;
					end_IL_002c:
					break;
				}
			}
			return result;
		}

		public static ThreadHelper CreateFixedTimeStep(int timeStepFPS, int timeoutMS = 0)
		{
			return CreateFixedTimeStep(timeStepFPS, useHighPrecisionTimer: false, timeoutMS);
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
			: this(0, useHighPrecisionTimer: false, timeoutMS)
		{
		}

		private ThreadHelper(int fixedTimeStepFPS, bool useHighPrecisionTimer, int timeoutMS)
		{
			while (true)
			{
				int num = -534856516;
				while (true)
				{
					switch (num ^ -534856520)
					{
					case 5:
						break;
					case 4:
						HZnDfeGkEodGvEXfoLZXMHFjjhXu = Stopwatch.Global;
						if (fixedTimeStepFPS < 0)
						{
							fixedTimeStepFPS = 0;
							num = -534856520;
							continue;
						}
						goto case 0;
					case 6:
						BwAojkLXSGMwNHhuGbgBbjYKXab = new object();
						RDMgHZZIVgJZnUoCKOXrbeOjTGf = new Queue<Action>();
						num = -534856519;
						continue;
					case 0:
					{
						int num2;
						if (timeoutMS < 0)
						{
							num = -534856513;
							num2 = num;
						}
						else
						{
							num = -534856517;
							num2 = num;
						}
						continue;
					}
					case 2:
						BxbXjaVFHljySXwntdTjhOppJzV = new ManualResetEvent(initialState: false);
						WrBVgfwOgtjzAUFUicXMNNetumu = new ManualResetEvent(initialState: false);
						LBChorAfyRiRxuXleCRBWiTAIVg = new AutoResetEvent(initialState: false);
						num = -534856514;
						continue;
					case 7:
						timeoutMS = 0;
						num = -534856517;
						continue;
					case 3:
						hxyIJbmmhtACeuSeKcyTgLOCicJ = timeoutMS;
						zvIKbUfRJRjjLqRCcEsqYhKSfkfK = fixedTimeStepFPS;
						qKZfTzIPgCLbJhhhqpqgKsBZWgMD = useHighPrecisionTimer;
						jCeuwTLVRiVBdiqGVZARKjLRGVNh();
						num = -534856518;
						continue;
					default:
						cgYTdqVkrrFaEdlBrbUVZIcRlSND = new Queue<Action>();
						return;
					}
					break;
				}
			}
		}

		public bool Start(bool wait)
		{
			if (gTyLLvDyPFrZEpsrKvookvvbBvf)
			{
				return false;
			}
			bool result = default(bool);
			try
			{
				BxbXjaVFHljySXwntdTjhOppJzV.Reset();
				while (true)
				{
					IL_0016:
					int num = 2117660261;
					while (true)
					{
						switch (num ^ 0x7E38EE64)
						{
						case 2:
							break;
						case 1:
							LBChorAfyRiRxuXleCRBWiTAIVg.Reset();
							fqsCBjdBBAqwxHGTJtzpEGieeHqQ = new Thread(eSLEpoXIydPZSbtAuObdzcshgEJ);
							fqsCBjdBBAqwxHGTJtzpEGieeHqQ.Start();
							num = 2117660263;
							continue;
						case 3:
							if (wait)
							{
								BxbXjaVFHljySXwntdTjhOppJzV.WaitOne();
								num = 2117660260;
								continue;
							}
							goto default;
						default:
							result = true;
							goto end_IL_001b;
						}
						goto IL_0016;
						continue;
						end_IL_001b:
						break;
					}
					break;
				}
			}
			catch (Exception)
			{
				while (true)
				{
					IL_0088:
					int num2 = 2117660261;
					while (true)
					{
						switch (num2 ^ 0x7E38EE64)
						{
						case 2:
							break;
						default:
							goto end_IL_008d;
						case 1:
							goto IL_00a6;
						case 0:
							goto end_IL_008d;
						}
						goto IL_0088;
						IL_00a6:
						result = false;
						num2 = 2117660260;
						continue;
						end_IL_008d:
						break;
					}
					break;
				}
			}
			return result;
		}

		public void Stop(bool wait)
		{
			if (fqsCBjdBBAqwxHGTJtzpEGieeHqQ == null)
			{
				return;
			}
			while (gTyLLvDyPFrZEpsrKvookvvbBvf)
			{
				while (true)
				{
					int num;
					int num2;
					if (!rvbvyZWaKzIASnmICLNQCPhhhle)
					{
						num = 443149458;
						num2 = num;
					}
					else
					{
						num = 443149457;
						num2 = num;
					}
					while (true)
					{
						switch (num ^ 0x1A69EC97)
						{
						case 4:
							num = 443149462;
							continue;
						case 3:
							BxbXjaVFHljySXwntdTjhOppJzV.WaitOne();
							num = 443149461;
							continue;
						case 6:
							break;
						case 0:
							goto end_IL_0011;
						case 5:
							return;
						case 1:
							goto end_IL_0083;
						default:
							wGXBINGyfkkYSWBIVpoJcwYKKPQ();
							return;
						}
						BxbXjaVFHljySXwntdTjhOppJzV.Reset();
						rvbvyZWaKzIASnmICLNQCPhhhle = false;
						LBChorAfyRiRxuXleCRBWiTAIVg.Set();
						int num3;
						if (!wait)
						{
							num = 443149461;
							num3 = num;
						}
						else
						{
							num = 443149460;
							num3 = num;
						}
						continue;
						end_IL_0011:
						break;
					}
					continue;
					end_IL_0083:
					break;
				}
			}
		}

		public bool EnqueueAction(Action action)
		{
			if (action == null)
			{
				return false;
			}
			if (!gTyLLvDyPFrZEpsrKvookvvbBvf)
			{
				return false;
			}
			if (!rvbvyZWaKzIASnmICLNQCPhhhle)
			{
				return false;
			}
			ResetTimeout();
			lock (BwAojkLXSGMwNHhuGbgBbjYKXab)
			{
				RDMgHZZIVgJZnUoCKOXrbeOjTGf.Enqueue(action);
				YBucbEHZTmKrsPiyPObasHCWiDIE = true;
				LBChorAfyRiRxuXleCRBWiTAIVg.Set();
			}
			return true;
		}

		public bool InvokeActionSync(Action action)
		{
			if (!gTyLLvDyPFrZEpsrKvookvvbBvf)
			{
				return false;
			}
			if (!rvbvyZWaKzIASnmICLNQCPhhhle)
			{
				return false;
			}
			EnqueueAction(action);
			WaitForActionQueueToFinish();
			return true;
		}

		public void WaitForActionQueueToFinish()
		{
			if (!gTyLLvDyPFrZEpsrKvookvvbBvf)
			{
				while (true)
				{
					switch (0x33FF278E ^ 0x33FF278C)
					{
					case 3:
						break;
					case 2:
						return;
					case 1:
						goto end_IL_0008;
					default:
						goto IL_0042;
					}
					continue;
					end_IL_0008:
					break;
				}
			}
			if (!rvbvyZWaKzIASnmICLNQCPhhhle)
			{
				return;
			}
			goto IL_0042;
			IL_0042:
			ResetTimeout();
			lock (BwAojkLXSGMwNHhuGbgBbjYKXab)
			{
				WrBVgfwOgtjzAUFUicXMNNetumu.Reset();
				KUiKrMQUtquTzRwygsfvPeUtxxo++;
			}
			LBChorAfyRiRxuXleCRBWiTAIVg.Set();
			while (true)
			{
				int num = 872359821;
				while (true)
				{
					switch (num ^ 0x33FF278C)
					{
					case 2:
						break;
					case 1:
						goto IL_00a2;
					default:
						lock (BwAojkLXSGMwNHhuGbgBbjYKXab)
						{
							KUiKrMQUtquTzRwygsfvPeUtxxo--;
							return;
						}
					}
					break;
					IL_00a2:
					WrBVgfwOgtjzAUFUicXMNNetumu.WaitOne();
					num = 872359820;
				}
			}
		}

		public void ResetTimeout()
		{
			wQEhuPHwsCXnOFAkeFOPlLZyaWad = ((hxyIJbmmhtACeuSeKcyTgLOCicJ > 0) ? (HZnDfeGkEodGvEXfoLZXMHFjjhXu.elapsedMillisecondsRaw + hxyIJbmmhtACeuSeKcyTgLOCicJ) : 0);
		}

		private void eSLEpoXIydPZSbtAuObdzcshgEJ()
		{
			ResetTimeout();
			gTyLLvDyPFrZEpsrKvookvvbBvf = true;
			rvbvyZWaKzIASnmICLNQCPhhhle = true;
			BxbXjaVFHljySXwntdTjhOppJzV.Set();
			if (MRskNWDpJuTcdgwwSKszWnFdtKq != null)
			{
				lock (MRskNWDpJuTcdgwwSKszWnFdtKq)
				{
					try
					{
						MRskNWDpJuTcdgwwSKszWnFdtKq();
					}
					catch (Exception ex)
					{
						Logger.LogError("Caught exception in thread start event callback.\n" + ex, requiredThreadSafety: true);
					}
				}
			}
			long num2 = default(long);
			long num5 = default(long);
			while (rvbvyZWaKzIASnmICLNQCPhhhle)
			{
				long elapsedTicksRaw = HZnDfeGkEodGvEXfoLZXMHFjjhXu.elapsedTicksRaw;
				while (true)
				{
					int num = 139872541;
					while (true)
					{
						switch (num ^ 0x856491C)
						{
						case 2:
							break;
						case 1:
							num2 = elapsedTicksRaw + YtkoYfcDuGlxIxodZsHxPMOlblKc;
							GPEImpkeeaYMPMnRlFPemMbCtGu();
							num = 139872540;
							continue;
						default:
							goto end_IL_0073;
						}
						break;
					}
					continue;
					end_IL_0073:
					break;
				}
				lock (BwAojkLXSGMwNHhuGbgBbjYKXab)
				{
					if (!YBucbEHZTmKrsPiyPObasHCWiDIE)
					{
						while (true)
						{
							IL_00bd:
							int num3 = 139872541;
							while (true)
							{
								switch (num3 ^ 0x856491C)
								{
								case 0:
									break;
								default:
									goto end_IL_00c2;
								case 1:
									if (KUiKrMQUtquTzRwygsfvPeUtxxo > 0)
									{
										goto IL_00e4;
									}
									goto end_IL_00c2;
								case 2:
									goto end_IL_00c2;
								}
								goto IL_00bd;
								IL_00e4:
								WrBVgfwOgtjzAUFUicXMNNetumu.Set();
								num3 = 139872542;
								continue;
								end_IL_00c2:
								break;
							}
							break;
						}
					}
				}
				if (zsOlDCLdystlIwSNknGGXALRAyi != null)
				{
					try
					{
						zsOlDCLdystlIwSNknGGXALRAyi();
					}
					catch (Exception ex2)
					{
						Logger.LogError("Exception occurred in a Thread Update Event callback.\n" + ex2, requiredThreadSafety: true);
					}
				}
				if (wQFfiGgvsLemeoAcxVTjDEGcmeME)
				{
					if (!qKZfTzIPgCLbJhhhqpqgKsBZWgMD)
					{
						goto IL_0140;
					}
					goto IL_01c4;
				}
				goto IL_0205;
				IL_0140:
				int num4 = 139872541;
				goto IL_0145;
				IL_01c4:
				while (HZnDfeGkEodGvEXfoLZXMHFjjhXu.elapsedTicksRaw < num2)
				{
				}
				num4 = 139872543;
				goto IL_0145;
				IL_0145:
				while (true)
				{
					switch (num4 ^ 0x856491C)
					{
					case 7:
						break;
					case 6:
						if (hxyIJbmmhtACeuSeKcyTgLOCicJ > 0 && HZnDfeGkEodGvEXfoLZXMHFjjhXu.elapsedMillisecondsRaw >= wQEhuPHwsCXnOFAkeFOPlLZyaWad)
						{
							rvbvyZWaKzIASnmICLNQCPhhhle = false;
							num4 = 139872542;
							continue;
						}
						goto IL_024c;
					case 0:
						LBChorAfyRiRxuXleCRBWiTAIVg.WaitOne(TimeSpan.FromTicks(Stopwatch.ConvertTo100NSTicks(num5)));
						num4 = 139872543;
						continue;
					case 5:
						goto IL_01c4;
					case 4:
						goto IL_01dc;
					case 3:
						goto IL_0205;
					case 1:
						goto IL_0229;
					default:
						goto IL_024c;
					}
					break;
					IL_0229:
					int num6;
					if ((long)zvIKbUfRJRjjLqRCcEsqYhKSfkfK < 750L)
					{
						num4 = 139872536;
						num6 = num4;
					}
					else
					{
						num4 = 139872537;
						num6 = num4;
					}
					continue;
					IL_01dc:
					num5 = num2 - HZnDfeGkEodGvEXfoLZXMHFjjhXu.elapsedTicksRaw;
					int num7;
					if (num5 <= 0)
					{
						num4 = 139872543;
						num7 = num4;
					}
					else
					{
						num4 = 139872540;
						num7 = num4;
					}
				}
				goto IL_0140;
				IL_0205:
				EZNcyZdjNOHcGHeDUIpgjlUJNfk = ((EZNcyZdjNOHcGHeDUIpgjlUJNfk != uint.MaxValue) ? (EZNcyZdjNOHcGHeDUIpgjlUJNfk + 1) : 0u);
				num4 = 139872538;
				goto IL_0145;
				IL_024c:;
			}
			if (IsDNMKwrsoFVCPmlzHkPnZtWPzi != null)
			{
				lock (IsDNMKwrsoFVCPmlzHkPnZtWPzi)
				{
					try
					{
						IsDNMKwrsoFVCPmlzHkPnZtWPzi();
					}
					catch (Exception ex3)
					{
						Logger.LogError("Caught exception in thread pre-stop event event callback.\n" + ex3, requiredThreadSafety: true);
					}
				}
			}
			gTyLLvDyPFrZEpsrKvookvvbBvf = false;
			while (true)
			{
				int num8 = 139872541;
				while (true)
				{
					switch (num8 ^ 0x856491C)
					{
					case 0:
						break;
					default:
						return;
					case 1:
						goto IL_02bf;
					case 2:
						return;
					}
					break;
					IL_02bf:
					BxbXjaVFHljySXwntdTjhOppJzV.Set();
					num8 = 139872542;
				}
			}
		}

		private void GPEImpkeeaYMPMnRlFPemMbCtGu()
		{
			if (!YBucbEHZTmKrsPiyPObasHCWiDIE)
			{
				return;
			}
			lock (BwAojkLXSGMwNHhuGbgBbjYKXab)
			{
				MiscTools.Swap(ref RDMgHZZIVgJZnUoCKOXrbeOjTGf, ref cgYTdqVkrrFaEdlBrbUVZIcRlSND);
				YBucbEHZTmKrsPiyPObasHCWiDIE = false;
			}
			while (cgYTdqVkrrFaEdlBrbUVZIcRlSND.Count > 0)
			{
				Action action = cgYTdqVkrrFaEdlBrbUVZIcRlSND.Dequeue();
				try
				{
					action();
				}
				catch (Exception ex)
				{
					Logger.LogError("Exception occurred while processing thread Action queue.\n" + ex, requiredThreadSafety: true);
				}
			}
		}

		private void jCeuwTLVRiVBdiqGVZARKjLRGVNh()
		{
			if (zvIKbUfRJRjjLqRCcEsqYhKSfkfK <= 0)
			{
				wQFfiGgvsLemeoAcxVTjDEGcmeME = false;
			}
			else
			{
				while (true)
				{
					wQFfiGgvsLemeoAcxVTjDEGcmeME = true;
					int num = -113194825;
					while (true)
					{
						switch (num ^ -113194827)
						{
						case 3:
							num = -113194828;
							continue;
						case 1:
							break;
						case 2:
							YtkoYfcDuGlxIxodZsHxPMOlblKc = Stopwatch.frequency / zvIKbUfRJRjjLqRCcEsqYhKSfkfK;
							num = -113194827;
							continue;
						default:
							goto end_IL_0034;
						}
						break;
					}
					continue;
					end_IL_0034:
					break;
				}
			}
			ResetTimeout();
		}

		private void wGXBINGyfkkYSWBIVpoJcwYKKPQ()
		{
			fqsCBjdBBAqwxHGTJtzpEGieeHqQ = null;
			gTyLLvDyPFrZEpsrKvookvvbBvf = false;
			rvbvyZWaKzIASnmICLNQCPhhhle = false;
			RDMgHZZIVgJZnUoCKOXrbeOjTGf.Clear();
			cgYTdqVkrrFaEdlBrbUVZIcRlSND.Clear();
			while (true)
			{
				int num = -1329798636;
				while (true)
				{
					switch (num ^ -1329798634)
					{
					case 0:
						break;
					case 3:
						BxbXjaVFHljySXwntdTjhOppJzV.Reset();
						num = -1329798633;
						continue;
					case 1:
						WrBVgfwOgtjzAUFUicXMNNetumu.Reset();
						wQEhuPHwsCXnOFAkeFOPlLZyaWad = 0L;
						num = -1329798638;
						continue;
					case 2:
						YBucbEHZTmKrsPiyPObasHCWiDIE = false;
						num = -1329798637;
						continue;
					case 5:
						KUiKrMQUtquTzRwygsfvPeUtxxo = 0;
						num = -1329798635;
						continue;
					default:
						EZNcyZdjNOHcGHeDUIpgjlUJNfk = 0u;
						return;
					}
					break;
				}
			}
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		~ThreadHelper()
		{
			Dispose(disposing: false);
		}

		protected void Dispose(bool disposing)
		{
			if (xRygqjRmTtURDPiwlgMmFcdNBrr)
			{
				goto IL_0008;
			}
			goto IL_0044;
			IL_0008:
			int num = 551956976;
			goto IL_000d;
			IL_000d:
			switch (num ^ 0x20E631F2)
			{
			case 3:
				break;
			case 2:
				return;
			case 4:
				goto IL_0036;
			case 1:
				goto IL_0044;
			default:
				xRygqjRmTtURDPiwlgMmFcdNBrr = true;
				return;
			}
			goto IL_0008;
			IL_0044:
			if (disposing)
			{
				Stop(wait: true);
				num = 551956978;
				goto IL_000d;
			}
			goto IL_0036;
			IL_0036:
			rvbvyZWaKzIASnmICLNQCPhhhle = false;
			num = 551956978;
			goto IL_000d;
		}

		[Conditional("DEBUG_THREAD_HELPER")]
		private static void jjvCPjrZKQLgEnaskVvjXCBaaqwh(object P_0)
		{
			if (P_0 != null)
			{
				Logger.Log(P_0, requiredThreadSafety: true);
			}
		}
	}
}
