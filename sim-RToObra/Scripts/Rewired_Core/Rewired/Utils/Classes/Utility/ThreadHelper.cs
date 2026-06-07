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
		private const uint fCsppbmxNsIFivoTNIJGAKeyOlT = 750u;

		private readonly Stopwatch XJdPlaQAlkHyVCjLHboQazhehtx;

		private Thread xgExdbVyAKUPeHviEQuSfAnlZIs;

		private ManualResetEvent RdbgzudXqzaPglIEYiEwHSgKyFnV;

		private ManualResetEvent WpXKIbwHutDQsRyRDwAPwSmucHE;

		private AutoResetEvent BeUUHzWeAJoQXnEnLZdWlEUHzGS;

		private bool rjzKZHIYfbsrgwuefusBpWFwpME;

		private bool emuVrtBFJJrHewGGlSYtRURcNOX;

		private int GFmCVUMSGyQVJAEABARimKqachS;

		private bool suFzAhVRhGVAvqBiLHYtRjZYwBk;

		private int fgMCFMxuwBHTvxVgNDThjtkLouV;

		private long GPywStwPFQXSekADmmywejqwtka;

		private bool wWHCWPfDPBSYTXENEikTjuUdimc;

		private int diocntymSdkTWlYKtPuKPFoNyen;

		private long asIRBPNPLWftiKCIFqvMDWzhRIYB;

		private uint ENFmMZfgKIIjuiYpzvnnaCVGlVMc;

		private readonly object TROHSyLKjYyohQeAvXLSWRaDciH;

		private Queue<Action> BJAuWFHlxkAlPJwUnonmABSaRJL;

		private Queue<Action> yACFjqTBQxQMisBjOfbWrOOEfIx;

		private bool UAoMXUDNqugTEKCAweMzhFsNZLmd;

		private Action xIAGJSJwEccVacnuZPENgorgACOL;

		private Action ASyvWOTeiyeMLfoYdwTmbElcyYI;

		private Action MtHqbQcnPyjbaCCRAQsSzYFZnXWg;

		private bool vsurYtRlepcrpAzAENwjqjJEZPT;

		public bool isRunning
		{
			get
			{
				return emuVrtBFJJrHewGGlSYtRURcNOX;
			}
		}

		public bool isStopped
		{
			get
			{
				if (!emuVrtBFJJrHewGGlSYtRURcNOX)
				{
					while (true)
					{
						int num = -1028356491;
						while (true)
						{
							switch (num ^ -1028356489)
							{
							case 0:
								break;
							case 2:
								if (xgExdbVyAKUPeHviEQuSfAnlZIs == null)
								{
									goto IL_002e;
								}
								return !xgExdbVyAKUPeHviEQuSfAnlZIs.IsAlive;
							default:
								return true;
							}
							break;
							IL_002e:
							num = -1028356490;
						}
					}
				}
				return false;
			}
		}

		public bool useHighPrecitionTimer
		{
			get
			{
				if (!suFzAhVRhGVAvqBiLHYtRjZYwBk)
				{
					return (long)fgMCFMxuwBHTvxVgNDThjtkLouV >= 750L;
				}
				return true;
			}
			set
			{
				if (value != suFzAhVRhGVAvqBiLHYtRjZYwBk)
				{
					suFzAhVRhGVAvqBiLHYtRjZYwBk = value;
					pbaKgPRbqyhzTxjmuopEpgjGcJjI();
				}
			}
		}

		public bool useFixedTimeStep
		{
			get
			{
				return wWHCWPfDPBSYTXENEikTjuUdimc;
			}
		}

		public int fixedTimeStepFPS
		{
			get
			{
				return fgMCFMxuwBHTvxVgNDThjtkLouV;
			}
			set
			{
				fgMCFMxuwBHTvxVgNDThjtkLouV = ((value > 0) ? value : 0);
				pbaKgPRbqyhzTxjmuopEpgjGcJjI();
			}
		}

		public int timeoutMS
		{
			get
			{
				return diocntymSdkTWlYKtPuKPFoNyen;
			}
			set
			{
				diocntymSdkTWlYKtPuKPFoNyen = ((value > 0) ? value : 0);
				pbaKgPRbqyhzTxjmuopEpgjGcJjI();
			}
		}

		public uint tick
		{
			get
			{
				return ENFmMZfgKIIjuiYpzvnnaCVGlVMc;
			}
		}

		public event Action ThreadUpdateEvent
		{
			add
			{
				xIAGJSJwEccVacnuZPENgorgACOL = (Action)Delegate.Combine(xIAGJSJwEccVacnuZPENgorgACOL, value);
			}
			remove
			{
				xIAGJSJwEccVacnuZPENgorgACOL = (Action)Delegate.Remove(xIAGJSJwEccVacnuZPENgorgACOL, value);
			}
		}

		private event Action _ThreadStartedEvent
		{
			add
			{
				Action action = ASyvWOTeiyeMLfoYdwTmbElcyYI;
				Action value2 = default(Action);
				Action action2 = default(Action);
				while (true)
				{
					int num = 69062372;
					while (true)
					{
						switch (num ^ 0x41DCEE6)
						{
						case 0:
							break;
						case 2:
							goto IL_0025;
						default:
							action = Interlocked.CompareExchange(ref ASyvWOTeiyeMLfoYdwTmbElcyYI, value2, action2);
							if ((object)action != action2)
							{
								goto IL_0025;
							}
							return;
						}
						break;
						IL_0025:
						action2 = action;
						value2 = (Action)Delegate.Combine(action2, b);
						num = 69062375;
					}
				}
			}
			remove
			{
				Action action = ASyvWOTeiyeMLfoYdwTmbElcyYI;
				Action value2 = default(Action);
				Action action2 = default(Action);
				while (true)
				{
					int num = 1050366207;
					while (true)
					{
						switch (num ^ 0x3E9B50FD)
						{
						case 0:
							break;
						case 2:
							goto IL_0025;
						default:
							action = Interlocked.CompareExchange(ref ASyvWOTeiyeMLfoYdwTmbElcyYI, value2, action2);
							if ((object)action != action2)
							{
								goto IL_0025;
							}
							return;
						}
						break;
						IL_0025:
						action2 = action;
						value2 = (Action)Delegate.Remove(action2, value3);
						num = 1050366204;
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
				Action action = MtHqbQcnPyjbaCCRAQsSzYFZnXWg;
				while (true)
				{
					int num = -1497004537;
					while (true)
					{
						switch (num ^ -1497004538)
						{
						case 0:
							break;
						default:
							return;
						case 1:
						{
							Action action2 = action;
							Action value2 = (Action)Delegate.Combine(action2, b);
							action = Interlocked.CompareExchange(ref MtHqbQcnPyjbaCCRAQsSzYFZnXWg, value2, action2);
							int num2;
							if ((object)action == action2)
							{
								num = -1497004540;
								num2 = num;
							}
							else
							{
								num = -1497004537;
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
			remove
			{
				Action action = MtHqbQcnPyjbaCCRAQsSzYFZnXWg;
				Action value2 = default(Action);
				Action action2 = default(Action);
				while (true)
				{
					int num = 522584427;
					while (true)
					{
						switch (num ^ 0x1F26016A)
						{
						case 2:
							break;
						case 1:
							goto IL_0025;
						default:
							action = Interlocked.CompareExchange(ref MtHqbQcnPyjbaCCRAQsSzYFZnXWg, value2, action2);
							if ((object)action != action2)
							{
								goto IL_0025;
							}
							return;
						}
						break;
						IL_0025:
						action2 = action;
						value2 = (Action)Delegate.Remove(action2, value3);
						num = 522584426;
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
					int num = 1358164648;
					while (true)
					{
						switch (num ^ 0x50F3F2A8)
						{
						case 2:
							num = 1358164649;
							continue;
						case 1:
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
				int num = -357375759;
				while (true)
				{
					switch (num ^ -357375760)
					{
					case 6:
						break;
					case 2:
						BeUUHzWeAJoQXnEnLZdWlEUHzGS = new AutoResetEvent(false);
						num = -357375752;
						continue;
					case 5:
						diocntymSdkTWlYKtPuKPFoNyen = timeoutMS;
						fgMCFMxuwBHTvxVgNDThjtkLouV = fixedTimeStepFPS;
						num = -357375753;
						continue;
					case 0:
						fixedTimeStepFPS = 0;
						num = -357375757;
						continue;
					case 7:
						suFzAhVRhGVAvqBiLHYtRjZYwBk = useHighPrecisionTimer;
						pbaKgPRbqyhzTxjmuopEpgjGcJjI();
						num = -357375756;
						continue;
					case 3:
						if (timeoutMS < 0)
						{
							timeoutMS = 0;
							num = -357375755;
							continue;
						}
						goto case 5;
					case 1:
					{
						XJdPlaQAlkHyVCjLHboQazhehtx = Stopwatch.Global;
						int num2;
						if (fixedTimeStepFPS < 0)
						{
							num = -357375760;
							num2 = num;
						}
						else
						{
							num = -357375757;
							num2 = num;
						}
						continue;
					}
					case 4:
						RdbgzudXqzaPglIEYiEwHSgKyFnV = new ManualResetEvent(false);
						WpXKIbwHutDQsRyRDwAPwSmucHE = new ManualResetEvent(false);
						num = -357375758;
						continue;
					default:
						TROHSyLKjYyohQeAvXLSWRaDciH = new object();
						BJAuWFHlxkAlPJwUnonmABSaRJL = new Queue<Action>();
						yACFjqTBQxQMisBjOfbWrOOEfIx = new Queue<Action>();
						return;
					}
					break;
				}
			}
		}

		public bool Start(bool wait)
		{
			if (emuVrtBFJJrHewGGlSYtRURcNOX)
			{
				return false;
			}
			bool result = default(bool);
			try
			{
				RdbgzudXqzaPglIEYiEwHSgKyFnV.Reset();
				BeUUHzWeAJoQXnEnLZdWlEUHzGS.Reset();
				while (true)
				{
					IL_0022:
					int num = 1176515048;
					while (true)
					{
						switch (num ^ 0x462031E9)
						{
						case 2:
							break;
						case 1:
							xgExdbVyAKUPeHviEQuSfAnlZIs = new Thread(qHRzioZdXpmfuyXRLDxgSFOkGivH);
							xgExdbVyAKUPeHviEQuSfAnlZIs.Start();
							if (wait)
							{
								goto IL_0065;
							}
							goto default;
						default:
							result = true;
							goto end_IL_0027;
						}
						goto IL_0022;
						IL_0065:
						RdbgzudXqzaPglIEYiEwHSgKyFnV.WaitOne();
						num = 1176515049;
						continue;
						end_IL_0027:
						break;
					}
					break;
				}
			}
			catch (Exception)
			{
				while (true)
				{
					IL_007d:
					int num2 = 1176515048;
					while (true)
					{
						switch (num2 ^ 0x462031E9)
						{
						case 2:
							break;
						default:
							goto end_IL_0082;
						case 1:
							goto IL_009b;
						case 0:
							goto end_IL_0082;
						}
						goto IL_007d;
						IL_009b:
						result = false;
						num2 = 1176515049;
						continue;
						end_IL_0082:
						break;
					}
					break;
				}
			}
			return result;
		}

		public void Stop(bool wait)
		{
			if (xgExdbVyAKUPeHviEQuSfAnlZIs == null)
			{
				goto IL_0008;
			}
			goto IL_0079;
			IL_0008:
			int num = -961966855;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num ^ -961966850)
				{
				case 0:
					break;
				case 7:
					return;
				case 4:
					goto IL_0042;
				case 2:
					goto IL_0052;
				case 5:
					RdbgzudXqzaPglIEYiEwHSgKyFnV.WaitOne();
					num = -961966856;
					continue;
				case 1:
					goto IL_0079;
				case 3:
					goto IL_0089;
				default:
					wWHIeZOvAcJogZJomCBAHnsZeBwE();
					return;
				}
				break;
				IL_0052:
				int num2;
				if (!wait)
				{
					num = -961966856;
					num2 = num;
				}
				else
				{
					num = -961966853;
					num2 = num;
				}
			}
			goto IL_0008;
			IL_0079:
			if (!emuVrtBFJJrHewGGlSYtRURcNOX)
			{
				return;
			}
			goto IL_0042;
			IL_0089:
			RdbgzudXqzaPglIEYiEwHSgKyFnV.Reset();
			rjzKZHIYfbsrgwuefusBpWFwpME = false;
			BeUUHzWeAJoQXnEnLZdWlEUHzGS.Set();
			num = -961966852;
			goto IL_000d;
			IL_0042:
			if (!rjzKZHIYfbsrgwuefusBpWFwpME)
			{
				return;
			}
			goto IL_0089;
		}

		public bool EnqueueAction(Action action)
		{
			if (action == null)
			{
				return false;
			}
			if (!emuVrtBFJJrHewGGlSYtRURcNOX)
			{
				return false;
			}
			if (!rjzKZHIYfbsrgwuefusBpWFwpME)
			{
				return false;
			}
			ResetTimeout();
			lock (TROHSyLKjYyohQeAvXLSWRaDciH)
			{
				BJAuWFHlxkAlPJwUnonmABSaRJL.Enqueue(action);
				UAoMXUDNqugTEKCAweMzhFsNZLmd = true;
				BeUUHzWeAJoQXnEnLZdWlEUHzGS.Set();
			}
			return true;
		}

		public bool InvokeActionSync(Action action)
		{
			if (!emuVrtBFJJrHewGGlSYtRURcNOX)
			{
				return false;
			}
			if (!rjzKZHIYfbsrgwuefusBpWFwpME)
			{
				return false;
			}
			EnqueueAction(action);
			WaitForActionQueueToFinish();
			return true;
		}

		public void WaitForActionQueueToFinish()
		{
			if (!emuVrtBFJJrHewGGlSYtRURcNOX)
			{
				while (true)
				{
					switch (-2091878139 ^ -2091878137)
					{
					case 0:
						break;
					case 2:
						return;
					case 3:
						goto end_IL_0008;
					default:
						goto IL_0042;
					}
					continue;
					end_IL_0008:
					break;
				}
			}
			if (!rjzKZHIYfbsrgwuefusBpWFwpME)
			{
				return;
			}
			goto IL_0042;
			IL_0042:
			ResetTimeout();
			lock (TROHSyLKjYyohQeAvXLSWRaDciH)
			{
				WpXKIbwHutDQsRyRDwAPwSmucHE.Reset();
				GFmCVUMSGyQVJAEABARimKqachS++;
			}
			BeUUHzWeAJoQXnEnLZdWlEUHzGS.Set();
			WpXKIbwHutDQsRyRDwAPwSmucHE.WaitOne();
			lock (TROHSyLKjYyohQeAvXLSWRaDciH)
			{
				GFmCVUMSGyQVJAEABARimKqachS--;
			}
		}

		public void ResetTimeout()
		{
			asIRBPNPLWftiKCIFqvMDWzhRIYB = ((diocntymSdkTWlYKtPuKPFoNyen > 0) ? (XJdPlaQAlkHyVCjLHboQazhehtx.elapsedMillisecondsRaw + diocntymSdkTWlYKtPuKPFoNyen) : 0);
		}

		private void qHRzioZdXpmfuyXRLDxgSFOkGivH()
		{
			ResetTimeout();
			emuVrtBFJJrHewGGlSYtRURcNOX = true;
			while (true)
			{
				int num = 1361912606;
				while (true)
				{
					switch (num ^ 0x512D231F)
					{
					case 3:
						break;
					case 1:
						rjzKZHIYfbsrgwuefusBpWFwpME = true;
						num = 1361912607;
						continue;
					case 0:
						RdbgzudXqzaPglIEYiEwHSgKyFnV.Set();
						if (ASyvWOTeiyeMLfoYdwTmbElcyYI != null)
						{
							num = 1361912605;
							continue;
						}
						goto IL_0228;
					default:
						{
							lock (ASyvWOTeiyeMLfoYdwTmbElcyYI)
							{
								try
								{
									ASyvWOTeiyeMLfoYdwTmbElcyYI();
								}
								catch (Exception ex)
								{
									Logger.LogError("Caught exception in thread start event callback.\n" + ex, true);
								}
							}
							goto IL_0228;
						}
						IL_0228:
						while (rjzKZHIYfbsrgwuefusBpWFwpME)
						{
							long elapsedTicksRaw = XJdPlaQAlkHyVCjLHboQazhehtx.elapsedTicksRaw;
							long num2 = elapsedTicksRaw + GPywStwPFQXSekADmmywejqwtka;
							KUAvkxaPJaCotZAhSDylCRTHIrCL();
							lock (TROHSyLKjYyohQeAvXLSWRaDciH)
							{
								if (!UAoMXUDNqugTEKCAweMzhFsNZLmd && GFmCVUMSGyQVJAEABARimKqachS > 0)
								{
									while (true)
									{
										IL_00d1:
										int num3 = 1361912606;
										while (true)
										{
											switch (num3 ^ 0x512D231F)
											{
											case 2:
												break;
											default:
												goto end_IL_00d6;
											case 1:
												goto IL_00ef;
											case 0:
												goto end_IL_00d6;
											}
											goto IL_00d1;
											IL_00ef:
											WpXKIbwHutDQsRyRDwAPwSmucHE.Set();
											num3 = 1361912607;
											continue;
											end_IL_00d6:
											break;
										}
										break;
									}
								}
							}
							if (xIAGJSJwEccVacnuZPENgorgACOL != null)
							{
								try
								{
									xIAGJSJwEccVacnuZPENgorgACOL();
								}
								catch (Exception ex2)
								{
									Logger.LogError("Exception occurred in a Thread Update Event callback.\n" + ex2, true);
								}
							}
							if (wWHCWPfDPBSYTXENEikTjuUdimc)
							{
								if (!suFzAhVRhGVAvqBiLHYtRjZYwBk)
								{
									goto IL_0148;
								}
								goto IL_01a9;
							}
							goto IL_01e1;
							IL_01a9:
							while (XJdPlaQAlkHyVCjLHboQazhehtx.elapsedTicksRaw < num2)
							{
							}
							int num4 = 1361912605;
							goto IL_014d;
							IL_01e1:
							ENFmMZfgKIIjuiYpzvnnaCVGlVMc = ((ENFmMZfgKIIjuiYpzvnnaCVGlVMc != uint.MaxValue) ? (ENFmMZfgKIIjuiYpzvnnaCVGlVMc + 1) : 0u);
							if (diocntymSdkTWlYKtPuKPFoNyen <= 0 || XJdPlaQAlkHyVCjLHboQazhehtx.elapsedMillisecondsRaw < asIRBPNPLWftiKCIFqvMDWzhRIYB)
							{
								continue;
							}
							rjzKZHIYfbsrgwuefusBpWFwpME = false;
							num4 = 1361912604;
							goto IL_014d;
							IL_014d:
							while (true)
							{
								switch (num4 ^ 0x512D231F)
								{
								case 0:
									break;
								case 5:
								{
									long num5 = num2 - XJdPlaQAlkHyVCjLHboQazhehtx.elapsedTicksRaw;
									if (num5 > 0)
									{
										BeUUHzWeAJoQXnEnLZdWlEUHzGS.WaitOne(TimeSpan.FromTicks(Stopwatch.ConvertTo100NSTicks(num5)));
										num4 = 1361912605;
										continue;
									}
									goto IL_01e1;
								}
								case 4:
									goto IL_01a9;
								case 1:
									goto IL_01be;
								case 2:
									goto IL_01e1;
								default:
									goto IL_0228_2;
								}
								break;
								IL_01be:
								int num6;
								if ((long)fgMCFMxuwBHTvxVgNDThjtkLouV < 750L)
								{
									num4 = 1361912602;
									num6 = num4;
								}
								else
								{
									num4 = 1361912603;
									num6 = num4;
								}
							}
							goto IL_0148;
							IL_0148:
							num4 = 1361912606;
							goto IL_014d;
							IL_0228_2:;
						}
						if (MtHqbQcnPyjbaCCRAQsSzYFZnXWg != null)
						{
							lock (MtHqbQcnPyjbaCCRAQsSzYFZnXWg)
							{
								try
								{
									MtHqbQcnPyjbaCCRAQsSzYFZnXWg();
								}
								catch (Exception ex3)
								{
									Logger.LogError("Caught exception in thread pre-stop event event callback.\n" + ex3, true);
								}
							}
						}
						emuVrtBFJJrHewGGlSYtRURcNOX = false;
						RdbgzudXqzaPglIEYiEwHSgKyFnV.Set();
						return;
					}
					break;
				}
			}
		}

		private void KUAvkxaPJaCotZAhSDylCRTHIrCL()
		{
			if (!UAoMXUDNqugTEKCAweMzhFsNZLmd)
			{
				return;
			}
			lock (TROHSyLKjYyohQeAvXLSWRaDciH)
			{
				MiscTools.Swap(ref BJAuWFHlxkAlPJwUnonmABSaRJL, ref yACFjqTBQxQMisBjOfbWrOOEfIx);
				UAoMXUDNqugTEKCAweMzhFsNZLmd = false;
			}
			while (yACFjqTBQxQMisBjOfbWrOOEfIx.Count > 0)
			{
				Action action = yACFjqTBQxQMisBjOfbWrOOEfIx.Dequeue();
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

		private void pbaKgPRbqyhzTxjmuopEpgjGcJjI()
		{
			if (fgMCFMxuwBHTvxVgNDThjtkLouV > 0)
			{
				goto IL_0034;
			}
			wWHCWPfDPBSYTXENEikTjuUdimc = false;
			goto IL_0055;
			IL_0034:
			wWHCWPfDPBSYTXENEikTjuUdimc = true;
			GPywStwPFQXSekADmmywejqwtka = Stopwatch.frequency / fgMCFMxuwBHTvxVgNDThjtkLouV;
			int num = 858469589;
			goto IL_0017;
			IL_0055:
			ResetTimeout();
			num = 858469588;
			goto IL_0017;
			IL_0017:
			while (true)
			{
				switch (num ^ 0x332B34D5)
				{
				case 2:
					num = 858469590;
					continue;
				default:
					return;
				case 3:
					break;
				case 0:
					goto IL_0055;
				case 1:
					return;
				}
				break;
			}
			goto IL_0034;
		}

		private void wWHIeZOvAcJogZJomCBAHnsZeBwE()
		{
			xgExdbVyAKUPeHviEQuSfAnlZIs = null;
			emuVrtBFJJrHewGGlSYtRURcNOX = false;
			rjzKZHIYfbsrgwuefusBpWFwpME = false;
			BJAuWFHlxkAlPJwUnonmABSaRJL.Clear();
			yACFjqTBQxQMisBjOfbWrOOEfIx.Clear();
			UAoMXUDNqugTEKCAweMzhFsNZLmd = false;
			GFmCVUMSGyQVJAEABARimKqachS = 0;
			RdbgzudXqzaPglIEYiEwHSgKyFnV.Reset();
			WpXKIbwHutDQsRyRDwAPwSmucHE.Reset();
			asIRBPNPLWftiKCIFqvMDWzhRIYB = 0L;
			ENFmMZfgKIIjuiYpzvnnaCVGlVMc = 0u;
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
			if (vsurYtRlepcrpAzAENwjqjJEZPT)
			{
				return;
			}
			while (true)
			{
				int num;
				if (disposing)
				{
					Stop(true);
					num = 564438303;
					goto IL_000e;
				}
				goto IL_003c;
				IL_000e:
				while (true)
				{
					switch (num ^ 0x21A4A51D)
					{
					case 0:
						num = 564438300;
						continue;
					case 1:
						break;
					case 3:
						goto IL_003c;
					default:
						vsurYtRlepcrpAzAENwjqjJEZPT = true;
						return;
					}
					break;
				}
				continue;
				IL_003c:
				rjzKZHIYfbsrgwuefusBpWFwpME = false;
				num = 564438303;
				goto IL_000e;
			}
		}

		[Conditional("DEBUG_THREAD_HELPER")]
		private static void dYrKlbvBfKYIsweWDvAocXvtSgI(object P_0)
		{
			if (P_0 != null)
			{
				Logger.Log(P_0, true);
			}
		}
	}
}
