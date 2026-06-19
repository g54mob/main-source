using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using Rewired.Config;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Utils;
using UnityEngine;

namespace Rewired
{
	public abstract class Controller
	{
		public abstract class Element
		{
			internal abstract class uChYTFWdojhBzLsucHKJRfnLBtf
			{
				public abstract class MmHLUqeSDEgIZjRQyQoUfaLifRp
				{
					public abstract void QjNHfjHnCmaQyvCGKbwODraSxUWC();
				}

				protected readonly int IJXPjJqczQbfRHOonFXCgrruhoz;

				protected readonly int[] GHpaksAgBLPWigDCHcBIJDZSGbTX;

				protected MmHLUqeSDEgIZjRQyQoUfaLifRp[] cXZAhDQESebRdBDchpsjrHPyUmL;

				public MmHLUqeSDEgIZjRQyQoUfaLifRp bAihUPOaQoqOwOHZvtGkVuGzqqW;

				private int FMfGoswTmMzBNBPokzjvUBjQbHe;

				public int RFSYGBGRLVeGSLPVJdbBAFXGYxhL = -1;

				protected ReadOnlyCollection<MmHLUqeSDEgIZjRQyQoUfaLifRp> UeWlWdqVhAjRfHntGMLyHCcgrFA;

				public IList<MmHLUqeSDEgIZjRQyQoUfaLifRp> Data => UeWlWdqVhAjRfHntGMLyHCcgrFA;

				public UpdateLoopType updateLoop
				{
					set
					{
						if (RFSYGBGRLVeGSLPVJdbBAFXGYxhL != (int)value)
						{
							RFSYGBGRLVeGSLPVJdbBAFXGYxhL = (int)value;
							FMfGoswTmMzBNBPokzjvUBjQbHe = GHpaksAgBLPWigDCHcBIJDZSGbTX[(int)value];
							bAihUPOaQoqOwOHZvtGkVuGzqqW = cXZAhDQESebRdBDchpsjrHPyUmL[FMfGoswTmMzBNBPokzjvUBjQbHe];
						}
					}
				}

				public uChYTFWdojhBzLsucHKJRfnLBtf(UpdateLoopSetting updateLoopSetting)
				{
					GHpaksAgBLPWigDCHcBIJDZSGbTX = new int[3];
					IJXPjJqczQbfRHOonFXCgrruhoz = 0;
					using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
					{
						List<UpdateLoopType> list = tList.list;
						EnumConverter.ToUpdateLoopTypes(updateLoopSetting, list);
						for (int i = 0; i < list.Count; i++)
						{
							GHpaksAgBLPWigDCHcBIJDZSGbTX[(int)list[i]] = IJXPjJqczQbfRHOonFXCgrruhoz;
							IJXPjJqczQbfRHOonFXCgrruhoz++;
						}
					}
					cXZAhDQESebRdBDchpsjrHPyUmL = new MmHLUqeSDEgIZjRQyQoUfaLifRp[IJXPjJqczQbfRHOonFXCgrruhoz];
					UeWlWdqVhAjRfHntGMLyHCcgrFA = new ReadOnlyCollection<MmHLUqeSDEgIZjRQyQoUfaLifRp>(cXZAhDQESebRdBDchpsjrHPyUmL);
				}

				public void QjNHfjHnCmaQyvCGKbwODraSxUWC()
				{
					for (int i = 0; i < IJXPjJqczQbfRHOonFXCgrruhoz; i++)
					{
						cXZAhDQESebRdBDchpsjrHPyUmL[i].QjNHfjHnCmaQyvCGKbwODraSxUWC();
					}
				}
			}

			public readonly int id;

			public readonly string name;

			public readonly ControllerElementType type;

			internal uChYTFWdojhBzLsucHKJRfnLBtf ZAPQkWVEmwDgOQKLYoulafZuVkx;

			internal int sPOjvMiFvLbtQoywtTuWbVDsRcs;

			internal Controller BheccrWcwXwuvsNLWjWrFwcrgAqE;

			internal readonly int fhCkCLBQpxfjvFtQcQZeUtCOKFGZ;

			public ControllerElementIdentifier elementIdentifier
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return null;
					}
					ControllerElementIdentifier elementIdentifierById = BheccrWcwXwuvsNLWjWrFwcrgAqE.GetElementIdentifierById(id);
					if (elementIdentifierById == null)
					{
						return ControllerElementIdentifier.BlankReadOnly;
					}
					return elementIdentifierById;
				}
			}

			public bool isMemberElement
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return false;
					}
					return sPOjvMiFvLbtQoywtTuWbVDsRcs > 0;
				}
			}

			internal Element(Controller controller, int elementIdentifierId, string name, ControllerElementType type)
			{
				BheccrWcwXwuvsNLWjWrFwcrgAqE = controller;
				id = elementIdentifierId;
				this.name = name;
				this.type = type;
				fhCkCLBQpxfjvFtQcQZeUtCOKFGZ = ReInput.id;
			}

			public void Reset()
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				}
				else if (ZAPQkWVEmwDgOQKLYoulafZuVkx != null)
				{
					ZAPQkWVEmwDgOQKLYoulafZuVkx.QjNHfjHnCmaQyvCGKbwODraSxUWC();
				}
			}

			internal void HHlnCaixtxycOSnQWPcibJZAgGu()
			{
				if (sPOjvMiFvLbtQoywtTuWbVDsRcs > 0)
				{
					Logger.LogWarning("This element is already a member of a compound element! This is not supported. Resulting values may be unpredictable.");
				}
				sPOjvMiFvLbtQoywtTuWbVDsRcs++;
			}

			internal void mQHbMjFcIVWPTgPoFvAtoUImfOdU()
			{
				if (sPOjvMiFvLbtQoywtTuWbVDsRcs == 0)
				{
					Logger.LogWarning("This element is not a member of a compound element!");
					sPOjvMiFvLbtQoywtTuWbVDsRcs = 0;
				}
				else
				{
					sPOjvMiFvLbtQoywtTuWbVDsRcs--;
				}
			}
		}

		public sealed class Axis : Element
		{
			internal class xibLXYMpVvFGjLHUWrkiYNMpHGA : uChYTFWdojhBzLsucHKJRfnLBtf
			{
				public class XDLFthbJwyIhxjCikCNIdGndnqF : MmHLUqeSDEgIZjRQyQoUfaLifRp
				{
					private const float CbJcLZiXbzDNEBiYUpqrOapkGXKk = 0.001f;

					public float HpxePuhaScltgSCBmgsrsCpjliL;

					public float HOvXaNwnmQCcMhIaRYShmBvuyty;

					public float TFDorkdSRBmYDOnqjTspMgpQCRe;

					public float ajGHegfpCsfBRcvxEbsSWkjxUVpB;

					public float uGaKLypcQkWuxCduNbgkivkDRPjQ;

					public float FuBnoKHWOtNzoxBARsmoKFCWcxo;

					public double ytGwRxwrIXPvPjxTyfBkznYxwNS;

					public double KpRgtPYBdZGJaaPgBnDrQPAtcfl;

					public double VifeyGyWJSTjZMtvLBESolJdGaGE;

					public double LKkpWYXhJmSGeEtAmflRIJStrxO;

					public double ymuNdLUqIqoHEjXgumaRRMkVYEs;

					public double uUcbXlCnZVqypWYGKCYsykCEIGuw;

					public double timeActive
					{
						get
						{
							if ((double)HpxePuhaScltgSCBmgsrsCpjliL == 0.0)
							{
								return 0.0;
							}
							return ReInput.unscaledTime - VifeyGyWJSTjZMtvLBESolJdGaGE;
						}
					}

					public double timeActiveRaw
					{
						get
						{
							if ((double)TFDorkdSRBmYDOnqjTspMgpQCRe == 0.0)
							{
								return 0.0;
							}
							return ReInput.unscaledTime - LKkpWYXhJmSGeEtAmflRIJStrxO;
						}
					}

					public double timeInactive
					{
						get
						{
							if (HpxePuhaScltgSCBmgsrsCpjliL != 0f)
							{
								return 0.0;
							}
							return ReInput.unscaledTime - ytGwRxwrIXPvPjxTyfBkznYxwNS;
						}
					}

					public double timeInactiveRaw
					{
						get
						{
							if ((double)TFDorkdSRBmYDOnqjTspMgpQCRe != 0.0)
							{
								return 0.0;
							}
							return ReInput.unscaledTime - KpRgtPYBdZGJaaPgBnDrQPAtcfl;
						}
					}

					public void QTPiZFmnRsxmyQYmMuIoBQkOtfg(bool P_0)
					{
						double unscaledTime = ReInput.unscaledTime;
						if (P_0)
						{
							if (!MathTools.Approximately(uGaKLypcQkWuxCduNbgkivkDRPjQ, 0f))
							{
								ytGwRxwrIXPvPjxTyfBkznYxwNS = unscaledTime;
							}
							else
							{
								VifeyGyWJSTjZMtvLBESolJdGaGE = unscaledTime;
							}
							if (!MathTools.IsNear(uGaKLypcQkWuxCduNbgkivkDRPjQ, FuBnoKHWOtNzoxBARsmoKFCWcxo, 0.001f))
							{
								ymuNdLUqIqoHEjXgumaRRMkVYEs = unscaledTime;
							}
						}
						else
						{
							if (!MathTools.Approximately(HpxePuhaScltgSCBmgsrsCpjliL, 0f))
							{
								ytGwRxwrIXPvPjxTyfBkznYxwNS = unscaledTime;
							}
							else
							{
								VifeyGyWJSTjZMtvLBESolJdGaGE = unscaledTime;
							}
							if (!MathTools.IsNear(HpxePuhaScltgSCBmgsrsCpjliL, HOvXaNwnmQCcMhIaRYShmBvuyty, 0.001f))
							{
								ymuNdLUqIqoHEjXgumaRRMkVYEs = unscaledTime;
							}
						}
						if (!MathTools.Approximately(TFDorkdSRBmYDOnqjTspMgpQCRe, 0f))
						{
							KpRgtPYBdZGJaaPgBnDrQPAtcfl = unscaledTime;
						}
						else
						{
							LKkpWYXhJmSGeEtAmflRIJStrxO = unscaledTime;
						}
						if (!MathTools.IsNear(TFDorkdSRBmYDOnqjTspMgpQCRe, ajGHegfpCsfBRcvxEbsSWkjxUVpB, 0.001f))
						{
							uUcbXlCnZVqypWYGKCYsykCEIGuw = unscaledTime;
						}
					}

					public void aEjIzWyQQfkSqlePSTYFfyflfig(float P_0)
					{
						if (ajGHegfpCsfBRcvxEbsSWkjxUVpB != TFDorkdSRBmYDOnqjTspMgpQCRe)
						{
							ajGHegfpCsfBRcvxEbsSWkjxUVpB = TFDorkdSRBmYDOnqjTspMgpQCRe;
						}
						if (TFDorkdSRBmYDOnqjTspMgpQCRe != P_0)
						{
							TFDorkdSRBmYDOnqjTspMgpQCRe = P_0;
						}
					}

					public override void QjNHfjHnCmaQyvCGKbwODraSxUWC()
					{
						HpxePuhaScltgSCBmgsrsCpjliL = 0f;
						HOvXaNwnmQCcMhIaRYShmBvuyty = 0f;
						TFDorkdSRBmYDOnqjTspMgpQCRe = 0f;
						ajGHegfpCsfBRcvxEbsSWkjxUVpB = 0f;
						ytGwRxwrIXPvPjxTyfBkznYxwNS = 0.0;
						KpRgtPYBdZGJaaPgBnDrQPAtcfl = 0.0;
						VifeyGyWJSTjZMtvLBESolJdGaGE = 0.0;
						LKkpWYXhJmSGeEtAmflRIJStrxO = 0.0;
						ymuNdLUqIqoHEjXgumaRRMkVYEs = 0.0;
						uUcbXlCnZVqypWYGKCYsykCEIGuw = 0.0;
					}
				}

				public xibLXYMpVvFGjLHUWrkiYNMpHGA(UpdateLoopSetting updateCycle)
					: base(updateCycle)
				{
					for (int i = 0; i < IJXPjJqczQbfRHOonFXCgrruhoz; i++)
					{
						cXZAhDQESebRdBDchpsjrHPyUmL[i] = new XDLFthbJwyIhxjCikCNIdGndnqF();
					}
					bAihUPOaQoqOwOHZvtGkVuGzqqW = cXZAhDQESebRdBDchpsjrHPyUmL[0];
				}
			}

			internal readonly AxisRange WfewspXAKnvsnmgSxqeFcmHqfXE;

			internal readonly HardwareAxisInfo tfkhmJMDJkUYFJkJuabHOpbuotU;

			public float value
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return 0f;
					}
					if (base.isMemberElement)
					{
						return ((xibLXYMpVvFGjLHUWrkiYNMpHGA.XDLFthbJwyIhxjCikCNIdGndnqF)ZAPQkWVEmwDgOQKLYoulafZuVkx.bAihUPOaQoqOwOHZvtGkVuGzqqW).uGaKLypcQkWuxCduNbgkivkDRPjQ;
					}
					return ((xibLXYMpVvFGjLHUWrkiYNMpHGA.XDLFthbJwyIhxjCikCNIdGndnqF)ZAPQkWVEmwDgOQKLYoulafZuVkx.bAihUPOaQoqOwOHZvtGkVuGzqqW).HpxePuhaScltgSCBmgsrsCpjliL;
				}
			}

			public float valuePrev
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return 0f;
					}
					if (base.isMemberElement)
					{
						return ((xibLXYMpVvFGjLHUWrkiYNMpHGA.XDLFthbJwyIhxjCikCNIdGndnqF)ZAPQkWVEmwDgOQKLYoulafZuVkx.bAihUPOaQoqOwOHZvtGkVuGzqqW).FuBnoKHWOtNzoxBARsmoKFCWcxo;
					}
					return ((xibLXYMpVvFGjLHUWrkiYNMpHGA.XDLFthbJwyIhxjCikCNIdGndnqF)ZAPQkWVEmwDgOQKLYoulafZuVkx.bAihUPOaQoqOwOHZvtGkVuGzqqW).HOvXaNwnmQCcMhIaRYShmBvuyty;
				}
			}

			public float valueRaw
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return 0f;
					}
					return ((xibLXYMpVvFGjLHUWrkiYNMpHGA.XDLFthbJwyIhxjCikCNIdGndnqF)ZAPQkWVEmwDgOQKLYoulafZuVkx.bAihUPOaQoqOwOHZvtGkVuGzqqW).TFDorkdSRBmYDOnqjTspMgpQCRe;
				}
				internal set
				{
					((xibLXYMpVvFGjLHUWrkiYNMpHGA.XDLFthbJwyIhxjCikCNIdGndnqF)ZAPQkWVEmwDgOQKLYoulafZuVkx.bAihUPOaQoqOwOHZvtGkVuGzqqW).aEjIzWyQQfkSqlePSTYFfyflfig(value);
				}
			}

			public float valueRawPrev
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return 0f;
					}
					return ((xibLXYMpVvFGjLHUWrkiYNMpHGA.XDLFthbJwyIhxjCikCNIdGndnqF)ZAPQkWVEmwDgOQKLYoulafZuVkx.bAihUPOaQoqOwOHZvtGkVuGzqqW).ajGHegfpCsfBRcvxEbsSWkjxUVpB;
				}
			}

			public float valueDelta
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return 0f;
					}
					return value - valuePrev;
				}
			}

			public float valueDeltaRaw
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return 0f;
					}
					return ((xibLXYMpVvFGjLHUWrkiYNMpHGA.XDLFthbJwyIhxjCikCNIdGndnqF)ZAPQkWVEmwDgOQKLYoulafZuVkx.bAihUPOaQoqOwOHZvtGkVuGzqqW).TFDorkdSRBmYDOnqjTspMgpQCRe - ((xibLXYMpVvFGjLHUWrkiYNMpHGA.XDLFthbJwyIhxjCikCNIdGndnqF)ZAPQkWVEmwDgOQKLYoulafZuVkx.bAihUPOaQoqOwOHZvtGkVuGzqqW).ajGHegfpCsfBRcvxEbsSWkjxUVpB;
				}
			}

			public double lastTimeActive
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return 0.0;
					}
					return ((xibLXYMpVvFGjLHUWrkiYNMpHGA.XDLFthbJwyIhxjCikCNIdGndnqF)ZAPQkWVEmwDgOQKLYoulafZuVkx.bAihUPOaQoqOwOHZvtGkVuGzqqW).ytGwRxwrIXPvPjxTyfBkznYxwNS;
				}
			}

			public double lastTimeActiveRaw
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return 0.0;
					}
					return ((xibLXYMpVvFGjLHUWrkiYNMpHGA.XDLFthbJwyIhxjCikCNIdGndnqF)ZAPQkWVEmwDgOQKLYoulafZuVkx.bAihUPOaQoqOwOHZvtGkVuGzqqW).KpRgtPYBdZGJaaPgBnDrQPAtcfl;
				}
			}

			public double lastTimeInactive
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return 0.0;
					}
					return ((xibLXYMpVvFGjLHUWrkiYNMpHGA.XDLFthbJwyIhxjCikCNIdGndnqF)ZAPQkWVEmwDgOQKLYoulafZuVkx.bAihUPOaQoqOwOHZvtGkVuGzqqW).VifeyGyWJSTjZMtvLBESolJdGaGE;
				}
			}

			public double lastTimeInactiveRaw
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return 0.0;
					}
					return ((xibLXYMpVvFGjLHUWrkiYNMpHGA.XDLFthbJwyIhxjCikCNIdGndnqF)ZAPQkWVEmwDgOQKLYoulafZuVkx.bAihUPOaQoqOwOHZvtGkVuGzqqW).LKkpWYXhJmSGeEtAmflRIJStrxO;
				}
			}

			public double lastTimeValueChanged
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return 0.0;
					}
					return ((xibLXYMpVvFGjLHUWrkiYNMpHGA.XDLFthbJwyIhxjCikCNIdGndnqF)ZAPQkWVEmwDgOQKLYoulafZuVkx.bAihUPOaQoqOwOHZvtGkVuGzqqW).ymuNdLUqIqoHEjXgumaRRMkVYEs;
				}
			}

			public double lastTimeValueChangedRaw
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return 0.0;
					}
					return ((xibLXYMpVvFGjLHUWrkiYNMpHGA.XDLFthbJwyIhxjCikCNIdGndnqF)ZAPQkWVEmwDgOQKLYoulafZuVkx.bAihUPOaQoqOwOHZvtGkVuGzqqW).uUcbXlCnZVqypWYGKCYsykCEIGuw;
				}
			}

			public double timeActive
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return 0.0;
					}
					return ((xibLXYMpVvFGjLHUWrkiYNMpHGA.XDLFthbJwyIhxjCikCNIdGndnqF)ZAPQkWVEmwDgOQKLYoulafZuVkx.bAihUPOaQoqOwOHZvtGkVuGzqqW).timeActive;
				}
			}

			public double timeActiveRaw
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return 0.0;
					}
					return ((xibLXYMpVvFGjLHUWrkiYNMpHGA.XDLFthbJwyIhxjCikCNIdGndnqF)ZAPQkWVEmwDgOQKLYoulafZuVkx.bAihUPOaQoqOwOHZvtGkVuGzqqW).timeActive;
				}
			}

			public double timeInactive
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return 0.0;
					}
					return ((xibLXYMpVvFGjLHUWrkiYNMpHGA.XDLFthbJwyIhxjCikCNIdGndnqF)ZAPQkWVEmwDgOQKLYoulafZuVkx.bAihUPOaQoqOwOHZvtGkVuGzqqW).timeInactive;
				}
			}

			public double timeInactiveRaw
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return 0.0;
					}
					return ((xibLXYMpVvFGjLHUWrkiYNMpHGA.XDLFthbJwyIhxjCikCNIdGndnqF)ZAPQkWVEmwDgOQKLYoulafZuVkx.bAihUPOaQoqOwOHZvtGkVuGzqqW).timeInactiveRaw;
				}
			}

			public float pollingDeadZone
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return 0f;
					}
					if (tfkhmJMDJkUYFJkJuabHOpbuotU == null)
					{
						return -1f;
					}
					return tfkhmJMDJkUYFJkJuabHOpbuotU._pollingDeadZone;
				}
				set
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return;
					}
					if (value < 0f)
					{
						value = -1f;
					}
					if (tfkhmJMDJkUYFJkJuabHOpbuotU != null)
					{
						tfkhmJMDJkUYFJkJuabHOpbuotU._pollingDeadZone = value;
					}
				}
			}

			internal float selfValue => ((xibLXYMpVvFGjLHUWrkiYNMpHGA.XDLFthbJwyIhxjCikCNIdGndnqF)ZAPQkWVEmwDgOQKLYoulafZuVkx.bAihUPOaQoqOwOHZvtGkVuGzqqW).HpxePuhaScltgSCBmgsrsCpjliL;

			internal float selfValuePrev => ((xibLXYMpVvFGjLHUWrkiYNMpHGA.XDLFthbJwyIhxjCikCNIdGndnqF)ZAPQkWVEmwDgOQKLYoulafZuVkx.bAihUPOaQoqOwOHZvtGkVuGzqqW).HOvXaNwnmQCcMhIaRYShmBvuyty;

			internal float effectivePollingDeadZone
			{
				get
				{
					if (tfkhmJMDJkUYFJkJuabHOpbuotU == null)
					{
						return ReInput.configuration.defaultAbsoluteAxisPollingDeadZone;
					}
					if (tfkhmJMDJkUYFJkJuabHOpbuotU._pollingDeadZone >= 0f)
					{
						return tfkhmJMDJkUYFJkJuabHOpbuotU._pollingDeadZone;
					}
					return tfkhmJMDJkUYFJkJuabHOpbuotU._dataFormat switch
					{
						AxisCoordinateMode.Absolute => ReInput.configuration.defaultAbsoluteAxisPollingDeadZone, 
						AxisCoordinateMode.Relative => ReInput.configuration.defaultRelativeAxisPollingDeadZone, 
						_ => throw new NotImplementedException(), 
					};
				}
			}

			internal void GFVWASNTrRrMopkjJDjjUNcydlRk(float P_0)
			{
				xibLXYMpVvFGjLHUWrkiYNMpHGA.XDLFthbJwyIhxjCikCNIdGndnqF xDLFthbJwyIhxjCikCNIdGndnqF = (xibLXYMpVvFGjLHUWrkiYNMpHGA.XDLFthbJwyIhxjCikCNIdGndnqF)ZAPQkWVEmwDgOQKLYoulafZuVkx.bAihUPOaQoqOwOHZvtGkVuGzqqW;
				xDLFthbJwyIhxjCikCNIdGndnqF.FuBnoKHWOtNzoxBARsmoKFCWcxo = xDLFthbJwyIhxjCikCNIdGndnqF.uGaKLypcQkWuxCduNbgkivkDRPjQ;
				xDLFthbJwyIhxjCikCNIdGndnqF.uGaKLypcQkWuxCduNbgkivkDRPjQ = P_0;
			}

			internal Axis(Controller controller, int elementIdentifierId, string name, AxisRange axisRange, HardwareAxisInfo axisInfo)
				: base(controller, elementIdentifierId, name, ControllerElementType.Axis)
			{
				ZAPQkWVEmwDgOQKLYoulafZuVkx = new xibLXYMpVvFGjLHUWrkiYNMpHGA(ReInput.configVars.updateLoop);
				WfewspXAKnvsnmgSxqeFcmHqfXE = axisRange;
				tfkhmJMDJkUYFJkJuabHOpbuotU = axisInfo;
			}

			internal void pGQZJmpiRkCWlzaFUJGfZbpqbMe(UpdateLoopType P_0)
			{
				if (ZAPQkWVEmwDgOQKLYoulafZuVkx != null && ZAPQkWVEmwDgOQKLYoulafZuVkx.RFSYGBGRLVeGSLPVJdbBAFXGYxhL != (int)P_0)
				{
					ZAPQkWVEmwDgOQKLYoulafZuVkx.updateLoop = P_0;
				}
			}

			internal void SYbNxlddkXMZgPoboCCPZovlGCrc(AxisCalibration P_0)
			{
				xibLXYMpVvFGjLHUWrkiYNMpHGA.XDLFthbJwyIhxjCikCNIdGndnqF xDLFthbJwyIhxjCikCNIdGndnqF = (xibLXYMpVvFGjLHUWrkiYNMpHGA.XDLFthbJwyIhxjCikCNIdGndnqF)ZAPQkWVEmwDgOQKLYoulafZuVkx.bAihUPOaQoqOwOHZvtGkVuGzqqW;
				xDLFthbJwyIhxjCikCNIdGndnqF.HOvXaNwnmQCcMhIaRYShmBvuyty = xDLFthbJwyIhxjCikCNIdGndnqF.HpxePuhaScltgSCBmgsrsCpjliL;
				float hpxePuhaScltgSCBmgsrsCpjliL = P_0.GetCalibratedValue(xDLFthbJwyIhxjCikCNIdGndnqF.TFDorkdSRBmYDOnqjTspMgpQCRe, WfewspXAKnvsnmgSxqeFcmHqfXE);
				if (P_0.applyRangeCalibration)
				{
					hpxePuhaScltgSCBmgsrsCpjliL = MathTools.Clamp(hpxePuhaScltgSCBmgsrsCpjliL, -1f, 1f);
				}
				xDLFthbJwyIhxjCikCNIdGndnqF.HpxePuhaScltgSCBmgsrsCpjliL = hpxePuhaScltgSCBmgsrsCpjliL;
			}

			internal void SYbNxlddkXMZgPoboCCPZovlGCrc()
			{
				xibLXYMpVvFGjLHUWrkiYNMpHGA.XDLFthbJwyIhxjCikCNIdGndnqF xDLFthbJwyIhxjCikCNIdGndnqF = (xibLXYMpVvFGjLHUWrkiYNMpHGA.XDLFthbJwyIhxjCikCNIdGndnqF)ZAPQkWVEmwDgOQKLYoulafZuVkx.bAihUPOaQoqOwOHZvtGkVuGzqqW;
				xDLFthbJwyIhxjCikCNIdGndnqF.HOvXaNwnmQCcMhIaRYShmBvuyty = xDLFthbJwyIhxjCikCNIdGndnqF.HpxePuhaScltgSCBmgsrsCpjliL;
				xDLFthbJwyIhxjCikCNIdGndnqF.HpxePuhaScltgSCBmgsrsCpjliL = xDLFthbJwyIhxjCikCNIdGndnqF.TFDorkdSRBmYDOnqjTspMgpQCRe;
			}

			internal void bKiWnSvYpRHosHAsrGxZSmPPriW()
			{
				xibLXYMpVvFGjLHUWrkiYNMpHGA.XDLFthbJwyIhxjCikCNIdGndnqF xDLFthbJwyIhxjCikCNIdGndnqF = (xibLXYMpVvFGjLHUWrkiYNMpHGA.XDLFthbJwyIhxjCikCNIdGndnqF)ZAPQkWVEmwDgOQKLYoulafZuVkx.bAihUPOaQoqOwOHZvtGkVuGzqqW;
				xDLFthbJwyIhxjCikCNIdGndnqF.HOvXaNwnmQCcMhIaRYShmBvuyty = xDLFthbJwyIhxjCikCNIdGndnqF.HpxePuhaScltgSCBmgsrsCpjliL;
				xDLFthbJwyIhxjCikCNIdGndnqF.HpxePuhaScltgSCBmgsrsCpjliL = 0f;
			}

			internal void joYkqpNLolDFqeVuoISINtayeWJ()
			{
				xibLXYMpVvFGjLHUWrkiYNMpHGA.XDLFthbJwyIhxjCikCNIdGndnqF xDLFthbJwyIhxjCikCNIdGndnqF = (xibLXYMpVvFGjLHUWrkiYNMpHGA.XDLFthbJwyIhxjCikCNIdGndnqF)ZAPQkWVEmwDgOQKLYoulafZuVkx.bAihUPOaQoqOwOHZvtGkVuGzqqW;
				xDLFthbJwyIhxjCikCNIdGndnqF.QTPiZFmnRsxmyQYmMuIoBQkOtfg(base.isMemberElement);
			}

			internal void TsejxaWGAcwtDkPdXGyKOksvDAX(float P_0)
			{
				for (int i = 0; i < ZAPQkWVEmwDgOQKLYoulafZuVkx.Data.Count; i++)
				{
					if (ZAPQkWVEmwDgOQKLYoulafZuVkx.Data[i] is xibLXYMpVvFGjLHUWrkiYNMpHGA.XDLFthbJwyIhxjCikCNIdGndnqF xDLFthbJwyIhxjCikCNIdGndnqF)
					{
						xDLFthbJwyIhxjCikCNIdGndnqF.aEjIzWyQQfkSqlePSTYFfyflfig(P_0);
						xDLFthbJwyIhxjCikCNIdGndnqF.HOvXaNwnmQCcMhIaRYShmBvuyty = xDLFthbJwyIhxjCikCNIdGndnqF.HpxePuhaScltgSCBmgsrsCpjliL;
						xDLFthbJwyIhxjCikCNIdGndnqF.HpxePuhaScltgSCBmgsrsCpjliL = 0f;
						xDLFthbJwyIhxjCikCNIdGndnqF.QTPiZFmnRsxmyQYmMuIoBQkOtfg(base.isMemberElement);
					}
				}
			}

			internal float CPMWbfylhDSGhCfNRrDSmWgKhLh(UpdateLoopType P_0, AxisCalibration P_1)
			{
				xibLXYMpVvFGjLHUWrkiYNMpHGA.XDLFthbJwyIhxjCikCNIdGndnqF xDLFthbJwyIhxjCikCNIdGndnqF = (xibLXYMpVvFGjLHUWrkiYNMpHGA.XDLFthbJwyIhxjCikCNIdGndnqF)ZAPQkWVEmwDgOQKLYoulafZuVkx.Data[(int)P_0];
				float result = P_1.GetCalibratedValue(xDLFthbJwyIhxjCikCNIdGndnqF.TFDorkdSRBmYDOnqjTspMgpQCRe, WfewspXAKnvsnmgSxqeFcmHqfXE, P_1.deadZone, applySensitivity: false, applyInversion: true);
				if (P_1.applyRangeCalibration)
				{
					result = MathTools.Clamp(result, -1f, 1f);
				}
				return result;
			}
		}

		public sealed class Button : Element
		{
			internal class gkohMGoFlhEXAizPmXnSCKEqwfW : uChYTFWdojhBzLsucHKJRfnLBtf
			{
				public class WpHifyRafcJRtGzBgppzAiTzAIvH : MmHLUqeSDEgIZjRQyQoUfaLifRp
				{
					public bool HpxePuhaScltgSCBmgsrsCpjliL;

					public bool HOvXaNwnmQCcMhIaRYShmBvuyty;

					public ButtonStateRecorder FwtMCCbqxKOOhcFzFFaPTmzHZbB;

					public fJGmvZCQxKbsxKEBuDSxfzWxZRc QmxqACvFvXBcCjDezGzSxdIPFsNT;

					public WpHifyRafcJRtGzBgppzAiTzAIvH()
					{
						FwtMCCbqxKOOhcFzFFaPTmzHZbB = new ButtonStateRecorder();
						QmxqACvFvXBcCjDezGzSxdIPFsNT = new fJGmvZCQxKbsxKEBuDSxfzWxZRc(0.3f);
					}

					public void GcIuKOHgXujXqCTdAuwBBVguUoX(bool P_0)
					{
						if (HOvXaNwnmQCcMhIaRYShmBvuyty != HpxePuhaScltgSCBmgsrsCpjliL)
						{
							HOvXaNwnmQCcMhIaRYShmBvuyty = HpxePuhaScltgSCBmgsrsCpjliL;
						}
						if (HpxePuhaScltgSCBmgsrsCpjliL != P_0)
						{
							HpxePuhaScltgSCBmgsrsCpjliL = P_0;
						}
						FwtMCCbqxKOOhcFzFFaPTmzHZbB.QTPiZFmnRsxmyQYmMuIoBQkOtfg(P_0 && !HOvXaNwnmQCcMhIaRYShmBvuyty, P_0, ReInput.unscaledTime);
						QmxqACvFvXBcCjDezGzSxdIPFsNT.QTPiZFmnRsxmyQYmMuIoBQkOtfg(0.3f, P_0 && !HOvXaNwnmQCcMhIaRYShmBvuyty, P_0);
					}

					public override void QjNHfjHnCmaQyvCGKbwODraSxUWC()
					{
						HpxePuhaScltgSCBmgsrsCpjliL = false;
						HOvXaNwnmQCcMhIaRYShmBvuyty = false;
						FwtMCCbqxKOOhcFzFFaPTmzHZbB.QjNHfjHnCmaQyvCGKbwODraSxUWC();
						QmxqACvFvXBcCjDezGzSxdIPFsNT.QjNHfjHnCmaQyvCGKbwODraSxUWC();
					}
				}

				public class cgzCYNhLzXTrxKZUyAHmZnIyHvHm : WpHifyRafcJRtGzBgppzAiTzAIvH
				{
					public float oVHtZVawbKLeqGIKMfpkCOPCvomN;

					public float ZxGVdiHBtyIeGlrkVkUGFPPZCNC;

					public void GcIuKOHgXujXqCTdAuwBBVguUoX(float P_0)
					{
						if (ZxGVdiHBtyIeGlrkVkUGFPPZCNC != oVHtZVawbKLeqGIKMfpkCOPCvomN)
						{
							ZxGVdiHBtyIeGlrkVkUGFPPZCNC = oVHtZVawbKLeqGIKMfpkCOPCvomN;
						}
						if (oVHtZVawbKLeqGIKMfpkCOPCvomN != P_0)
						{
							oVHtZVawbKLeqGIKMfpkCOPCvomN = ((P_0 > 0.001f) ? P_0 : 0f);
						}
						GcIuKOHgXujXqCTdAuwBBVguUoX((oVHtZVawbKLeqGIKMfpkCOPCvomN > 0f) ? true : false);
					}

					public override void QjNHfjHnCmaQyvCGKbwODraSxUWC()
					{
						base.QjNHfjHnCmaQyvCGKbwODraSxUWC();
						oVHtZVawbKLeqGIKMfpkCOPCvomN = 0f;
						ZxGVdiHBtyIeGlrkVkUGFPPZCNC = 0f;
					}
				}

				public gkohMGoFlhEXAizPmXnSCKEqwfW(UpdateLoopSetting updateCycle, bool isPressureSensitive)
					: base(updateCycle)
				{
					for (int i = 0; i < IJXPjJqczQbfRHOonFXCgrruhoz; i++)
					{
						if (isPressureSensitive)
						{
							cXZAhDQESebRdBDchpsjrHPyUmL[i] = new cgzCYNhLzXTrxKZUyAHmZnIyHvHm();
						}
						else
						{
							cXZAhDQESebRdBDchpsjrHPyUmL[i] = new WpHifyRafcJRtGzBgppzAiTzAIvH();
						}
					}
					bAihUPOaQoqOwOHZvtGkVuGzqqW = cXZAhDQESebRdBDchpsjrHPyUmL[0];
				}

				public void qLDuLSNGNxjNXFFqddHcqsethyF(float P_0)
				{
					for (int i = 0; i < cXZAhDQESebRdBDchpsjrHPyUmL.Length; i++)
					{
						((WpHifyRafcJRtGzBgppzAiTzAIvH)cXZAhDQESebRdBDchpsjrHPyUmL[i]).QmxqACvFvXBcCjDezGzSxdIPFsNT.jzVpePliHKDUCFsxHIbpdhfBvnj(P_0);
					}
				}

				public void EvCXfwzatGBsNKMAollerVSlZJY()
				{
					for (int i = 0; i < cXZAhDQESebRdBDchpsjrHPyUmL.Length; i++)
					{
						((WpHifyRafcJRtGzBgppzAiTzAIvH)cXZAhDQESebRdBDchpsjrHPyUmL[i]).QmxqACvFvXBcCjDezGzSxdIPFsNT.jzVpePliHKDUCFsxHIbpdhfBvnj(0.3f);
					}
				}
			}

			internal readonly bool OhDzXyWCrRBpocUlcUasDrzXpRhM;

			internal readonly HardwareButtonInfo LqDQGfXnOKATlGdCocbmqgYwvAAv;

			public bool valuePrev
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return false;
					}
					return ((gkohMGoFlhEXAizPmXnSCKEqwfW.WpHifyRafcJRtGzBgppzAiTzAIvH)ZAPQkWVEmwDgOQKLYoulafZuVkx.bAihUPOaQoqOwOHZvtGkVuGzqqW).HOvXaNwnmQCcMhIaRYShmBvuyty;
				}
			}

			public bool value
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return false;
					}
					return ((gkohMGoFlhEXAizPmXnSCKEqwfW.WpHifyRafcJRtGzBgppzAiTzAIvH)ZAPQkWVEmwDgOQKLYoulafZuVkx.bAihUPOaQoqOwOHZvtGkVuGzqqW).HpxePuhaScltgSCBmgsrsCpjliL;
				}
			}

			public float pressure
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return 0f;
					}
					if (!OhDzXyWCrRBpocUlcUasDrzXpRhM)
					{
						if (!((gkohMGoFlhEXAizPmXnSCKEqwfW.WpHifyRafcJRtGzBgppzAiTzAIvH)ZAPQkWVEmwDgOQKLYoulafZuVkx.bAihUPOaQoqOwOHZvtGkVuGzqqW).HpxePuhaScltgSCBmgsrsCpjliL)
						{
							return 0f;
						}
						return 1f;
					}
					return ((gkohMGoFlhEXAizPmXnSCKEqwfW.cgzCYNhLzXTrxKZUyAHmZnIyHvHm)ZAPQkWVEmwDgOQKLYoulafZuVkx.bAihUPOaQoqOwOHZvtGkVuGzqqW).oVHtZVawbKLeqGIKMfpkCOPCvomN;
				}
			}

			public float pressurePrev
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return 0f;
					}
					if (!OhDzXyWCrRBpocUlcUasDrzXpRhM)
					{
						if (!((gkohMGoFlhEXAizPmXnSCKEqwfW.WpHifyRafcJRtGzBgppzAiTzAIvH)ZAPQkWVEmwDgOQKLYoulafZuVkx.bAihUPOaQoqOwOHZvtGkVuGzqqW).HOvXaNwnmQCcMhIaRYShmBvuyty)
						{
							return 0f;
						}
						return 1f;
					}
					return ((gkohMGoFlhEXAizPmXnSCKEqwfW.cgzCYNhLzXTrxKZUyAHmZnIyHvHm)ZAPQkWVEmwDgOQKLYoulafZuVkx.bAihUPOaQoqOwOHZvtGkVuGzqqW).ZxGVdiHBtyIeGlrkVkUGFPPZCNC;
				}
			}

			public bool isPressureSensitive
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return false;
					}
					return OhDzXyWCrRBpocUlcUasDrzXpRhM;
				}
			}

			public bool justPressed
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return false;
					}
					if (!((gkohMGoFlhEXAizPmXnSCKEqwfW.WpHifyRafcJRtGzBgppzAiTzAIvH)ZAPQkWVEmwDgOQKLYoulafZuVkx.bAihUPOaQoqOwOHZvtGkVuGzqqW).HOvXaNwnmQCcMhIaRYShmBvuyty && ((gkohMGoFlhEXAizPmXnSCKEqwfW.WpHifyRafcJRtGzBgppzAiTzAIvH)ZAPQkWVEmwDgOQKLYoulafZuVkx.bAihUPOaQoqOwOHZvtGkVuGzqqW).HpxePuhaScltgSCBmgsrsCpjliL)
					{
						return true;
					}
					return false;
				}
			}

			public bool justReleased
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return false;
					}
					if (((gkohMGoFlhEXAizPmXnSCKEqwfW.WpHifyRafcJRtGzBgppzAiTzAIvH)ZAPQkWVEmwDgOQKLYoulafZuVkx.bAihUPOaQoqOwOHZvtGkVuGzqqW).HOvXaNwnmQCcMhIaRYShmBvuyty && !((gkohMGoFlhEXAizPmXnSCKEqwfW.WpHifyRafcJRtGzBgppzAiTzAIvH)ZAPQkWVEmwDgOQKLYoulafZuVkx.bAihUPOaQoqOwOHZvtGkVuGzqqW).HpxePuhaScltgSCBmgsrsCpjliL)
					{
						return true;
					}
					return false;
				}
			}

			public bool justChangedState
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return false;
					}
					if (((gkohMGoFlhEXAizPmXnSCKEqwfW.WpHifyRafcJRtGzBgppzAiTzAIvH)ZAPQkWVEmwDgOQKLYoulafZuVkx.bAihUPOaQoqOwOHZvtGkVuGzqqW).HOvXaNwnmQCcMhIaRYShmBvuyty != ((gkohMGoFlhEXAizPmXnSCKEqwfW.WpHifyRafcJRtGzBgppzAiTzAIvH)ZAPQkWVEmwDgOQKLYoulafZuVkx.bAihUPOaQoqOwOHZvtGkVuGzqqW).HpxePuhaScltgSCBmgsrsCpjliL)
					{
						return true;
					}
					return false;
				}
			}

			public bool doublePressedAndHeld
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return false;
					}
					return ((gkohMGoFlhEXAizPmXnSCKEqwfW.WpHifyRafcJRtGzBgppzAiTzAIvH)ZAPQkWVEmwDgOQKLYoulafZuVkx.bAihUPOaQoqOwOHZvtGkVuGzqqW).QmxqACvFvXBcCjDezGzSxdIPFsNT.doublePressHold;
				}
			}

			public bool justDoublePressed
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return false;
					}
					if (!justPressed)
					{
						return false;
					}
					return ((gkohMGoFlhEXAizPmXnSCKEqwfW.WpHifyRafcJRtGzBgppzAiTzAIvH)ZAPQkWVEmwDgOQKLYoulafZuVkx.bAihUPOaQoqOwOHZvtGkVuGzqqW).QmxqACvFvXBcCjDezGzSxdIPFsNT.doublePressHold;
				}
			}

			public double timePressed
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return 0.0;
					}
					return ((gkohMGoFlhEXAizPmXnSCKEqwfW.WpHifyRafcJRtGzBgppzAiTzAIvH)ZAPQkWVEmwDgOQKLYoulafZuVkx.bAihUPOaQoqOwOHZvtGkVuGzqqW).FwtMCCbqxKOOhcFzFFaPTmzHZbB.timePressed;
				}
			}

			public double timeUnpressed
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return 0.0;
					}
					return ((gkohMGoFlhEXAizPmXnSCKEqwfW.WpHifyRafcJRtGzBgppzAiTzAIvH)ZAPQkWVEmwDgOQKLYoulafZuVkx.bAihUPOaQoqOwOHZvtGkVuGzqqW).FwtMCCbqxKOOhcFzFFaPTmzHZbB.timeUnpressed;
				}
			}

			public double lastTimePressed
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return 0.0;
					}
					return ((gkohMGoFlhEXAizPmXnSCKEqwfW.WpHifyRafcJRtGzBgppzAiTzAIvH)ZAPQkWVEmwDgOQKLYoulafZuVkx.bAihUPOaQoqOwOHZvtGkVuGzqqW).FwtMCCbqxKOOhcFzFFaPTmzHZbB.lastTimePressed;
				}
			}

			public double lastTimeUnpressed
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return 0.0;
					}
					return ((gkohMGoFlhEXAizPmXnSCKEqwfW.WpHifyRafcJRtGzBgppzAiTzAIvH)ZAPQkWVEmwDgOQKLYoulafZuVkx.bAihUPOaQoqOwOHZvtGkVuGzqqW).FwtMCCbqxKOOhcFzFFaPTmzHZbB.lastTimeUnpressed;
				}
			}

			public double lastTimeStateChanged
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return 0.0;
					}
					return ((gkohMGoFlhEXAizPmXnSCKEqwfW.WpHifyRafcJRtGzBgppzAiTzAIvH)ZAPQkWVEmwDgOQKLYoulafZuVkx.bAihUPOaQoqOwOHZvtGkVuGzqqW).FwtMCCbqxKOOhcFzFFaPTmzHZbB.lastTimeStateChanged;
				}
			}

			internal ButtonStateFlags state
			{
				get
				{
					gkohMGoFlhEXAizPmXnSCKEqwfW.WpHifyRafcJRtGzBgppzAiTzAIvH wpHifyRafcJRtGzBgppzAiTzAIvH = (gkohMGoFlhEXAizPmXnSCKEqwfW.WpHifyRafcJRtGzBgppzAiTzAIvH)ZAPQkWVEmwDgOQKLYoulafZuVkx.bAihUPOaQoqOwOHZvtGkVuGzqqW;
					ButtonStateFlags buttonStateFlags = ButtonStateFlags.vzRTPkAxQouGEgDZGevsgfcpaRF;
					if (wpHifyRafcJRtGzBgppzAiTzAIvH.HpxePuhaScltgSCBmgsrsCpjliL)
					{
						buttonStateFlags |= ButtonStateFlags.azLWpLIAMvIpDxdUTFgLLfAIMtW;
						if (!wpHifyRafcJRtGzBgppzAiTzAIvH.HOvXaNwnmQCcMhIaRYShmBvuyty)
						{
							buttonStateFlags |= ButtonStateFlags.LfybIEklEROOdKJuLlqxsSSaTPg;
						}
					}
					else if (wpHifyRafcJRtGzBgppzAiTzAIvH.HOvXaNwnmQCcMhIaRYShmBvuyty)
					{
						buttonStateFlags |= ButtonStateFlags.mDmdRkBMTphUlCvlBpKbpVxeKuBu;
					}
					return buttonStateFlags;
				}
			}

			internal Button(Controller controller, int elementIdentifierId, string name, HardwareButtonInfo buttonInfo)
				: base(controller, elementIdentifierId, name, ControllerElementType.Button)
			{
				LqDQGfXnOKATlGdCocbmqgYwvAAv = buttonInfo;
				ZAPQkWVEmwDgOQKLYoulafZuVkx = new gkohMGoFlhEXAizPmXnSCKEqwfW(ReInput.configVars.updateLoop, isPressureSensitive: false);
			}

			internal Button(Controller controller, int elementIdentifierId, string name, bool isPressureSensitive, HardwareButtonInfo buttonInfo)
				: base(controller, elementIdentifierId, name, ControllerElementType.Button)
			{
				LqDQGfXnOKATlGdCocbmqgYwvAAv = buttonInfo;
				OhDzXyWCrRBpocUlcUasDrzXpRhM = isPressureSensitive;
				ZAPQkWVEmwDgOQKLYoulafZuVkx = new gkohMGoFlhEXAizPmXnSCKEqwfW(ReInput.configVars.updateLoop, isPressureSensitive);
			}

			public bool DoublePressedAndHeld(float speed)
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return false;
				}
				if (speed <= 0f)
				{
					return ((gkohMGoFlhEXAizPmXnSCKEqwfW.WpHifyRafcJRtGzBgppzAiTzAIvH)ZAPQkWVEmwDgOQKLYoulafZuVkx.bAihUPOaQoqOwOHZvtGkVuGzqqW).QmxqACvFvXBcCjDezGzSxdIPFsNT.doublePressHold;
				}
				return ((gkohMGoFlhEXAizPmXnSCKEqwfW.WpHifyRafcJRtGzBgppzAiTzAIvH)ZAPQkWVEmwDgOQKLYoulafZuVkx.bAihUPOaQoqOwOHZvtGkVuGzqqW).FwtMCCbqxKOOhcFzFFaPTmzHZbB.EeMlJALivDnMblIcfunCQenlWlE(speed);
			}

			public bool JustDoublePressed(float speed)
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return false;
				}
				if (!justPressed)
				{
					return false;
				}
				if (speed <= 0f)
				{
					return ((gkohMGoFlhEXAizPmXnSCKEqwfW.WpHifyRafcJRtGzBgppzAiTzAIvH)ZAPQkWVEmwDgOQKLYoulafZuVkx.bAihUPOaQoqOwOHZvtGkVuGzqqW).QmxqACvFvXBcCjDezGzSxdIPFsNT.doublePressHold;
				}
				return ((gkohMGoFlhEXAizPmXnSCKEqwfW.WpHifyRafcJRtGzBgppzAiTzAIvH)ZAPQkWVEmwDgOQKLYoulafZuVkx.bAihUPOaQoqOwOHZvtGkVuGzqqW).FwtMCCbqxKOOhcFzFFaPTmzHZbB.EeMlJALivDnMblIcfunCQenlWlE(speed);
			}

			internal void GcIuKOHgXujXqCTdAuwBBVguUoX(UpdateLoopType P_0, int P_1, ControllerDataUpdater P_2)
			{
				if (ZAPQkWVEmwDgOQKLYoulafZuVkx != null && ZAPQkWVEmwDgOQKLYoulafZuVkx.RFSYGBGRLVeGSLPVJdbBAFXGYxhL != (int)P_0)
				{
					ZAPQkWVEmwDgOQKLYoulafZuVkx.updateLoop = P_0;
				}
				if (OhDzXyWCrRBpocUlcUasDrzXpRhM)
				{
					((gkohMGoFlhEXAizPmXnSCKEqwfW.cgzCYNhLzXTrxKZUyAHmZnIyHvHm)ZAPQkWVEmwDgOQKLYoulafZuVkx.bAihUPOaQoqOwOHZvtGkVuGzqqW).GcIuKOHgXujXqCTdAuwBBVguUoX(P_2.buttonPressureValues[P_1]);
				}
				else
				{
					((gkohMGoFlhEXAizPmXnSCKEqwfW.WpHifyRafcJRtGzBgppzAiTzAIvH)ZAPQkWVEmwDgOQKLYoulafZuVkx.bAihUPOaQoqOwOHZvtGkVuGzqqW).GcIuKOHgXujXqCTdAuwBBVguUoX(P_2.buttonValues[P_1]);
				}
			}

			internal void XyqdukdphRBRoFeJdPHmDkadYpXZ(UpdateLoopType P_0)
			{
				if (ZAPQkWVEmwDgOQKLYoulafZuVkx != null && ZAPQkWVEmwDgOQKLYoulafZuVkx.RFSYGBGRLVeGSLPVJdbBAFXGYxhL != (int)P_0)
				{
					ZAPQkWVEmwDgOQKLYoulafZuVkx.updateLoop = P_0;
				}
				if (OhDzXyWCrRBpocUlcUasDrzXpRhM)
				{
					((gkohMGoFlhEXAizPmXnSCKEqwfW.cgzCYNhLzXTrxKZUyAHmZnIyHvHm)ZAPQkWVEmwDgOQKLYoulafZuVkx.bAihUPOaQoqOwOHZvtGkVuGzqqW).GcIuKOHgXujXqCTdAuwBBVguUoX(0f);
				}
				else
				{
					((gkohMGoFlhEXAizPmXnSCKEqwfW.WpHifyRafcJRtGzBgppzAiTzAIvH)ZAPQkWVEmwDgOQKLYoulafZuVkx.bAihUPOaQoqOwOHZvtGkVuGzqqW).GcIuKOHgXujXqCTdAuwBBVguUoX(false);
				}
			}

			internal void TsejxaWGAcwtDkPdXGyKOksvDAX()
			{
				for (int i = 0; i < ZAPQkWVEmwDgOQKLYoulafZuVkx.Data.Count; i++)
				{
					uChYTFWdojhBzLsucHKJRfnLBtf.MmHLUqeSDEgIZjRQyQoUfaLifRp mmHLUqeSDEgIZjRQyQoUfaLifRp = ZAPQkWVEmwDgOQKLYoulafZuVkx.Data[i];
					if (mmHLUqeSDEgIZjRQyQoUfaLifRp != null)
					{
						if (OhDzXyWCrRBpocUlcUasDrzXpRhM)
						{
							((gkohMGoFlhEXAizPmXnSCKEqwfW.cgzCYNhLzXTrxKZUyAHmZnIyHvHm)mmHLUqeSDEgIZjRQyQoUfaLifRp).GcIuKOHgXujXqCTdAuwBBVguUoX(0f);
						}
						else
						{
							((gkohMGoFlhEXAizPmXnSCKEqwfW.WpHifyRafcJRtGzBgppzAiTzAIvH)mmHLUqeSDEgIZjRQyQoUfaLifRp).GcIuKOHgXujXqCTdAuwBBVguUoX(false);
						}
					}
				}
			}
		}

		public abstract class CompoundElement
		{
			private class fmDItGvUgMtyVIXgUavJTAVTdiSe
			{
				public readonly Element pEsVixgorzFkhlKMiSFTVBzHAOS;

				public readonly int UloOtbULeVUrORAYJCJnAyyehmkS;

				public fmDItGvUgMtyVIXgUavJTAVTdiSe(Element element, int elementIndex)
				{
					pEsVixgorzFkhlKMiSFTVBzHAOS = element;
					UloOtbULeVUrORAYJCJnAyyehmkS = elementIndex;
				}
			}

			private int aKTKfMYcYdTWZLyYfpZoZfzZGQT;

			private string YckvCvRVVkCnFoBTmVxvWZVKnMr;

			private CompoundControllerElementType wZYPyxmKgRSHjYJwEjuLiELShEK;

			private int AsQmycNkDaREuDCwWmhZMiVAlod;

			private fmDItGvUgMtyVIXgUavJTAVTdiSe[] JBeGhlFgiFxdOJckDGTWreONSQo;

			private Controller BheccrWcwXwuvsNLWjWrFwcrgAqE;

			internal readonly int fhCkCLBQpxfjvFtQcQZeUtCOKFGZ;

			public int id
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return -1;
					}
					return aKTKfMYcYdTWZLyYfpZoZfzZGQT;
				}
			}

			public string name
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return string.Empty;
					}
					return YckvCvRVVkCnFoBTmVxvWZVKnMr;
				}
			}

			public CompoundControllerElementType type
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return CompoundControllerElementType.Axis2D;
					}
					return wZYPyxmKgRSHjYJwEjuLiELShEK;
				}
			}

			public bool hasElements
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return false;
					}
					return AsQmycNkDaREuDCwWmhZMiVAlod > 0;
				}
			}

			public int elementCount
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return 0;
					}
					return AsQmycNkDaREuDCwWmhZMiVAlod;
				}
			}

			public abstract int elementCapacity { get; }

			public ControllerElementIdentifier elementIdentifier
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return null;
					}
					ControllerElementIdentifier elementIdentifierById = BheccrWcwXwuvsNLWjWrFwcrgAqE.GetElementIdentifierById(aKTKfMYcYdTWZLyYfpZoZfzZGQT);
					if (elementIdentifierById == null)
					{
						return ControllerElementIdentifier.BlankReadOnly;
					}
					return elementIdentifierById;
				}
			}

			internal CompoundElement(Controller controller, int elementIdentifierId, string name, CompoundControllerElementType type)
			{
				BheccrWcwXwuvsNLWjWrFwcrgAqE = controller;
				aKTKfMYcYdTWZLyYfpZoZfzZGQT = elementIdentifierId;
				YckvCvRVVkCnFoBTmVxvWZVKnMr = name;
				wZYPyxmKgRSHjYJwEjuLiELShEK = type;
				JBeGhlFgiFxdOJckDGTWreONSQo = new fmDItGvUgMtyVIXgUavJTAVTdiSe[elementCapacity];
				fhCkCLBQpxfjvFtQcQZeUtCOKFGZ = ReInput.id;
			}

			internal Element WChpoUjfxVomSqiESmHoqccMwdg(int P_0)
			{
				if (P_0 < 0 || P_0 >= JBeGhlFgiFxdOJckDGTWreONSQo.Length)
				{
					return null;
				}
				if (JBeGhlFgiFxdOJckDGTWreONSQo[P_0] == null)
				{
					return null;
				}
				return JBeGhlFgiFxdOJckDGTWreONSQo[P_0].pEsVixgorzFkhlKMiSFTVBzHAOS;
			}

			internal T WChpoUjfxVomSqiESmHoqccMwdg<T>(int P_0) where T : Element
			{
				if (P_0 < 0 || P_0 >= JBeGhlFgiFxdOJckDGTWreONSQo.Length)
				{
					return null;
				}
				if (JBeGhlFgiFxdOJckDGTWreONSQo[P_0] == null)
				{
					return null;
				}
				return JBeGhlFgiFxdOJckDGTWreONSQo[P_0].pEsVixgorzFkhlKMiSFTVBzHAOS as T;
			}

			internal T KVvFWnqTVBtDEvDWLeUZNFaVxad<T>(int P_0, out int P_1) where T : Element
			{
				P_1 = -1;
				if (P_0 < 0 || P_0 >= JBeGhlFgiFxdOJckDGTWreONSQo.Length)
				{
					return null;
				}
				if (JBeGhlFgiFxdOJckDGTWreONSQo[P_0] == null)
				{
					return null;
				}
				P_1 = JBeGhlFgiFxdOJckDGTWreONSQo[P_0].UloOtbULeVUrORAYJCJnAyyehmkS;
				return JBeGhlFgiFxdOJckDGTWreONSQo[P_0].pEsVixgorzFkhlKMiSFTVBzHAOS as T;
			}

			internal bool sPDBUryojEPTZhjXiDvYbSylxsi(Element P_0, int P_1)
			{
				if (P_0 == null)
				{
					return false;
				}
				if (AsQmycNkDaREuDCwWmhZMiVAlod >= elementCapacity)
				{
					Logger.LogWarning("Cannot add element! This Compound Element already contains the maximum number of elements.");
					return false;
				}
				if (P_0.isMemberElement)
				{
					Logger.LogWarning("Cannot add element! The element you are trying to add is already a member of another compound element.");
					return false;
				}
				if (VjDsToGPZzGexAMmMdPilgfgVeBC(P_0) >= 0)
				{
					Logger.LogWarning("Cannot add element! This Compound Element already contains the element you are trying to add.");
					return false;
				}
				int num = dpVfBocSAWpFmhEAyYgwmIvrKqs();
				if (num < 0)
				{
					Logger.LogWarning("Cannot add element! This Compound Element already contains the maximum number of elements.");
					return false;
				}
				return XtyqjvdnXKDBDamMUTqSgyTdlRj(P_0, P_1, num);
			}

			internal bool YrXdpHBGMHxNQbNjRQKHYwOjjAR(Element P_0)
			{
				if (P_0 == null)
				{
					return false;
				}
				if (AsQmycNkDaREuDCwWmhZMiVAlod == 0)
				{
					Logger.LogWarning("Cannot remove element! This Compound Element has no elements.");
					return false;
				}
				int num = VjDsToGPZzGexAMmMdPilgfgVeBC(P_0);
				if (num < 0)
				{
					Logger.LogWarning("Cannot remove element! This Compound Element does not contain the element you are trying to remove.");
					return false;
				}
				return gaEyEkYsviVimJHMyaBqkohWSAP(num);
			}

			internal void MROOEGSbwfbDbRBKFXOvJsmWntn()
			{
				for (int i = 0; i < JBeGhlFgiFxdOJckDGTWreONSQo.Length; i++)
				{
					gaEyEkYsviVimJHMyaBqkohWSAP(i);
				}
				AsQmycNkDaREuDCwWmhZMiVAlod = 0;
			}

			private int VjDsToGPZzGexAMmMdPilgfgVeBC(Element P_0)
			{
				if (P_0 == null)
				{
					return -1;
				}
				for (int i = 0; i < JBeGhlFgiFxdOJckDGTWreONSQo.Length; i++)
				{
					if (JBeGhlFgiFxdOJckDGTWreONSQo[i] != null && JBeGhlFgiFxdOJckDGTWreONSQo[i].pEsVixgorzFkhlKMiSFTVBzHAOS == P_0)
					{
						return i;
					}
				}
				return -1;
			}

			private bool XtyqjvdnXKDBDamMUTqSgyTdlRj(Element P_0, int P_1, int P_2)
			{
				if (P_2 < 0 || P_2 >= JBeGhlFgiFxdOJckDGTWreONSQo.Length)
				{
					return false;
				}
				if (JBeGhlFgiFxdOJckDGTWreONSQo[P_2] != null)
				{
					return false;
				}
				JBeGhlFgiFxdOJckDGTWreONSQo[P_2] = new fmDItGvUgMtyVIXgUavJTAVTdiSe(P_0, P_1);
				P_0.HHlnCaixtxycOSnQWPcibJZAgGu();
				AsQmycNkDaREuDCwWmhZMiVAlod++;
				return true;
			}

			private bool gaEyEkYsviVimJHMyaBqkohWSAP(int P_0)
			{
				if (P_0 < 0 || P_0 >= JBeGhlFgiFxdOJckDGTWreONSQo.Length)
				{
					return false;
				}
				if (JBeGhlFgiFxdOJckDGTWreONSQo[P_0] == null)
				{
					return false;
				}
				if (JBeGhlFgiFxdOJckDGTWreONSQo[P_0].pEsVixgorzFkhlKMiSFTVBzHAOS != null)
				{
					JBeGhlFgiFxdOJckDGTWreONSQo[P_0].pEsVixgorzFkhlKMiSFTVBzHAOS.mQHbMjFcIVWPTgPoFvAtoUImfOdU();
				}
				JBeGhlFgiFxdOJckDGTWreONSQo[P_0] = null;
				AsQmycNkDaREuDCwWmhZMiVAlod--;
				return true;
			}

			private int dpVfBocSAWpFmhEAyYgwmIvrKqs()
			{
				for (int i = 0; i < JBeGhlFgiFxdOJckDGTWreONSQo.Length; i++)
				{
					if (JBeGhlFgiFxdOJckDGTWreONSQo[i] == null)
					{
						return i;
					}
				}
				return -1;
			}
		}

		public sealed class Axis2D : CompoundElement
		{
			private const int SNjcTxJycVLGliQTdtEepTVgnoA = 2;

			private CalibrationMap lDVDybdAPXDTLKtMkRjPlUwRjcze;

			public override int elementCapacity => 2;

			public Axis xAxis
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return null;
					}
					return WChpoUjfxVomSqiESmHoqccMwdg<Axis>(0);
				}
			}

			public Axis yAxis
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return null;
					}
					return WChpoUjfxVomSqiESmHoqccMwdg<Axis>(1);
				}
			}

			public Vector2 value
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return Vector2.zero;
					}
					return gxgayNWlwExoOyqeeskMKmUxxet();
				}
			}

			public Vector2 valuePrev
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return Vector2.zero;
					}
					return kSXiQkIvseetwAEgvGZyzazvTLS();
				}
			}

			public Vector2 valueRaw
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return Vector2.zero;
					}
					return new Vector2((xAxis != null) ? xAxis.valueRaw : 0f, (yAxis != null) ? yAxis.valueRaw : 0f);
				}
			}

			public Vector2 valueRawPrev
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return Vector2.zero;
					}
					return new Vector2((xAxis != null) ? xAxis.valueRawPrev : 0f, (yAxis != null) ? yAxis.valueRawPrev : 0f);
				}
			}

			internal Axis2D(Controller controller, int elementIdentifierId, string name, Axis xAxis, Axis yAxis, int xAxisIndex, int yAxisIndex, CalibrationMap calibratonMap)
				: base(controller, elementIdentifierId, name, CompoundControllerElementType.Axis2D)
			{
				sPDBUryojEPTZhjXiDvYbSylxsi(xAxis, xAxisIndex);
				sPDBUryojEPTZhjXiDvYbSylxsi(yAxis, yAxisIndex);
				lDVDybdAPXDTLKtMkRjPlUwRjcze = calibratonMap;
			}

			internal void zAgCsBucdziQVBRjAkuDNPybKpO()
			{
				Vector2 vector = value;
				if (xAxis != null)
				{
					xAxis.GFVWASNTrRrMopkjJDjjUNcydlRk(vector.x);
				}
				if (yAxis != null)
				{
					yAxis.GFVWASNTrRrMopkjJDjjUNcydlRk(vector.y);
				}
			}

			private Vector2 gxgayNWlwExoOyqeeskMKmUxxet()
			{
				if (lDVDybdAPXDTLKtMkRjPlUwRjcze == null)
				{
					return default(Vector2);
				}
				int xAxisIndex;
				Axis axis = KVvFWnqTVBtDEvDWLeUZNFaVxad<Axis>(0, out xAxisIndex);
				int yAxisIndex;
				Axis axis2 = KVvFWnqTVBtDEvDWLeUZNFaVxad<Axis>(1, out yAxisIndex);
				DeadZone2DType defaultJoystickAxis2DDeadZoneType = ReInput.configVars.defaultJoystickAxis2DDeadZoneType;
				AxisSensitivity2DType defaultJoystickAxis2DSensitivityType = ReInput.configVars.defaultJoystickAxis2DSensitivityType;
				float valueRawX = axis?.valueRaw ?? 0f;
				float valueRawY = axis2?.valueRaw ?? 0f;
				return lDVDybdAPXDTLKtMkRjPlUwRjcze.GetCalibrated2DValue(xAxisIndex, yAxisIndex, valueRawX, valueRawY, defaultJoystickAxis2DDeadZoneType, defaultJoystickAxis2DSensitivityType);
			}

			private Vector2 kSXiQkIvseetwAEgvGZyzazvTLS()
			{
				if (lDVDybdAPXDTLKtMkRjPlUwRjcze == null)
				{
					return default(Vector2);
				}
				int xAxisIndex;
				Axis axis = KVvFWnqTVBtDEvDWLeUZNFaVxad<Axis>(0, out xAxisIndex);
				int yAxisIndex;
				Axis axis2 = KVvFWnqTVBtDEvDWLeUZNFaVxad<Axis>(1, out yAxisIndex);
				DeadZone2DType defaultJoystickAxis2DDeadZoneType = ReInput.configVars.defaultJoystickAxis2DDeadZoneType;
				AxisSensitivity2DType defaultJoystickAxis2DSensitivityType = ReInput.configVars.defaultJoystickAxis2DSensitivityType;
				float valueRawX = axis?.valueRawPrev ?? 0f;
				float valueRawY = axis2?.valueRawPrev ?? 0f;
				return lDVDybdAPXDTLKtMkRjPlUwRjcze.GetCalibrated2DValue(xAxisIndex, yAxisIndex, valueRawX, valueRawY, defaultJoystickAxis2DDeadZoneType, defaultJoystickAxis2DSensitivityType);
			}
		}

		public sealed class Hat : CompoundElement
		{
			private const int SNjcTxJycVLGliQTdtEepTVgnoA = 8;

			private const int vOlwERrsTUYAjErmiKfHDRRtsbN = 0;

			private const int SxzWXlQhuaTkDYoFGYOceJYDWFW = 1;

			private const int rFkhlEygHnKvKegtujxjVgIWFOW = 2;

			private const int CgksTrkkSPJCUvlIoESZxcYebHyd = 3;

			private const int hFCVvxMdDcklNPgcgqNFvAMlnIy = 4;

			private const int vfOYpEkQyHDsXtNmNIqCBQwmxVY = 5;

			private const int xSsQZzujyLayhBpIEVPAGivOCVo = 6;

			private const int IyYGOLlWQfrffpkvnDLtPptFttE = 7;

			private readonly int rVYednFAWMyyCdseuzQUGHWBwloT;

			private readonly Button[] fMHXJPWJIudshUOjLfHOLECkvEl;

			private readonly ReadOnlyCollection<Button> IWHWbTNnljzAcXcGmaXZwdGhMOJ;

			private readonly int[] XDkftdIpbyVkgZTHLTYTudABLjf;

			private bool nbpbEkWaggexJfBdFqdUwYXOBdYg;

			public override int elementCapacity => 8;

			public bool force4Way
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return false;
					}
					return nbpbEkWaggexJfBdFqdUwYXOBdYg;
				}
				set
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					}
					else
					{
						nbpbEkWaggexJfBdFqdUwYXOBdYg = value;
					}
				}
			}

			public int directionCount
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return 0;
					}
					return rVYednFAWMyyCdseuzQUGHWBwloT;
				}
			}

			public IList<Button> Buttons
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return EmptyObjects<Button>.EmptyReadOnlyIListT;
					}
					return IWHWbTNnljzAcXcGmaXZwdGhMOJ;
				}
			}

			public Button buttonUp
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return null;
					}
					return WChpoUjfxVomSqiESmHoqccMwdg<Button>(0);
				}
			}

			public Button buttonRight
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return null;
					}
					return WChpoUjfxVomSqiESmHoqccMwdg<Button>(2);
				}
			}

			public Button buttonDown
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return null;
					}
					return WChpoUjfxVomSqiESmHoqccMwdg<Button>(4);
				}
			}

			public Button buttonLeft
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return null;
					}
					return WChpoUjfxVomSqiESmHoqccMwdg<Button>(6);
				}
			}

			public Button buttonUpRight
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return null;
					}
					return WChpoUjfxVomSqiESmHoqccMwdg<Button>(1);
				}
			}

			public Button buttonDownRight
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return null;
					}
					return WChpoUjfxVomSqiESmHoqccMwdg<Button>(3);
				}
			}

			public Button buttonDownLeft
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return null;
					}
					return WChpoUjfxVomSqiESmHoqccMwdg<Button>(5);
				}
			}

			public Button buttonUpLeft
			{
				get
				{
					if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						return null;
					}
					return WChpoUjfxVomSqiESmHoqccMwdg<Button>(7);
				}
			}

			internal Hat(Controller controller, int elementIdentifierId, string name, Button[] buttons, int[] buttonIndices)
				: base(controller, elementIdentifierId, name, CompoundControllerElementType.Hat)
			{
				int num = ((buttons != null) ? buttons.Length : 0);
				if (num != ((buttonIndices != null) ? buttonIndices.Length : 0))
				{
					throw new ArgumentException("button.Length must equal buttonIndices.Length!");
				}
				if (num != 0 && num != 4 && num != 8)
				{
					throw new ArgumentException("button.Length must be 0, 4, or 8! Length: " + num);
				}
				for (int i = 0; i < num; i++)
				{
					sPDBUryojEPTZhjXiDvYbSylxsi(buttons[i], buttonIndices[i]);
				}
				fMHXJPWJIudshUOjLfHOLECkvEl = buttons;
				XDkftdIpbyVkgZTHLTYTudABLjf = buttonIndices;
				rVYednFAWMyyCdseuzQUGHWBwloT = num;
				IWHWbTNnljzAcXcGmaXZwdGhMOJ = new ReadOnlyCollection<Button>(buttons);
			}

			internal void zAgCsBucdziQVBRjAkuDNPybKpO(UpdateLoopType P_0, ControllerDataUpdater P_1)
			{
				if (rVYednFAWMyyCdseuzQUGHWBwloT == 0)
				{
					return;
				}
				if (rVYednFAWMyyCdseuzQUGHWBwloT == 8 && (nbpbEkWaggexJfBdFqdUwYXOBdYg || ReInput.configVars.force4WayHats))
				{
					IjTrucnWyUZUjxiUdnrpaVsdEy(fMHXJPWJIudshUOjLfHOLECkvEl[0], XDkftdIpbyVkgZTHLTYTudABLjf[0], XDkftdIpbyVkgZTHLTYTudABLjf[7], XDkftdIpbyVkgZTHLTYTudABLjf[1], P_0, P_1);
					IjTrucnWyUZUjxiUdnrpaVsdEy(fMHXJPWJIudshUOjLfHOLECkvEl[2], XDkftdIpbyVkgZTHLTYTudABLjf[2], XDkftdIpbyVkgZTHLTYTudABLjf[1], XDkftdIpbyVkgZTHLTYTudABLjf[3], P_0, P_1);
					IjTrucnWyUZUjxiUdnrpaVsdEy(fMHXJPWJIudshUOjLfHOLECkvEl[4], XDkftdIpbyVkgZTHLTYTudABLjf[4], XDkftdIpbyVkgZTHLTYTudABLjf[5], XDkftdIpbyVkgZTHLTYTudABLjf[3], P_0, P_1);
					IjTrucnWyUZUjxiUdnrpaVsdEy(fMHXJPWJIudshUOjLfHOLECkvEl[6], XDkftdIpbyVkgZTHLTYTudABLjf[6], XDkftdIpbyVkgZTHLTYTudABLjf[5], XDkftdIpbyVkgZTHLTYTudABLjf[7], P_0, P_1);
					VxnkrisuCPUMJTjKmvXRlwiERoP(fMHXJPWJIudshUOjLfHOLECkvEl[1], XDkftdIpbyVkgZTHLTYTudABLjf[1], P_0, P_1);
					VxnkrisuCPUMJTjKmvXRlwiERoP(fMHXJPWJIudshUOjLfHOLECkvEl[3], XDkftdIpbyVkgZTHLTYTudABLjf[3], P_0, P_1);
					VxnkrisuCPUMJTjKmvXRlwiERoP(fMHXJPWJIudshUOjLfHOLECkvEl[5], XDkftdIpbyVkgZTHLTYTudABLjf[5], P_0, P_1);
					VxnkrisuCPUMJTjKmvXRlwiERoP(fMHXJPWJIudshUOjLfHOLECkvEl[7], XDkftdIpbyVkgZTHLTYTudABLjf[7], P_0, P_1);
					return;
				}
				for (int i = 0; i < fMHXJPWJIudshUOjLfHOLECkvEl.Length; i++)
				{
					if (fMHXJPWJIudshUOjLfHOLECkvEl[i] != null)
					{
						fMHXJPWJIudshUOjLfHOLECkvEl[i].GcIuKOHgXujXqCTdAuwBBVguUoX(P_0, XDkftdIpbyVkgZTHLTYTudABLjf[i], P_1);
					}
				}
			}

			private void IjTrucnWyUZUjxiUdnrpaVsdEy(Button P_0, int P_1, int P_2, int P_3, UpdateLoopType P_4, ControllerDataUpdater P_5)
			{
				if (P_0 == null || P_1 < 0 || P_1 >= P_5.buttonCount)
				{
					return;
				}
				if (!P_0.isPressureSensitive)
				{
					if (P_2 >= 0 && P_2 < P_5.buttonCount)
					{
						ref bool reference = ref P_5.buttonValues[P_1];
						reference |= P_5.buttonValues[P_2];
					}
					if (P_3 >= 0 && P_3 < P_5.buttonCount)
					{
						ref bool reference2 = ref P_5.buttonValues[P_1];
						reference2 |= P_5.buttonValues[P_3];
					}
				}
				else
				{
					P_5.buttonPressureValues[P_1] = MathTools.MaxMagnitude(P_5.buttonPressureValues[P_1], MathTools.MaxMagnitude((P_2 >= 0 && P_2 < P_5.buttonCount) ? P_5.buttonPressureValues[P_2] : 0f, (P_3 >= 0 && P_3 < P_5.buttonCount) ? P_5.buttonPressureValues[P_3] : 0f));
				}
				P_0.GcIuKOHgXujXqCTdAuwBBVguUoX(P_4, P_1, P_5);
			}

			private void VxnkrisuCPUMJTjKmvXRlwiERoP(Button P_0, int P_1, UpdateLoopType P_2, ControllerDataUpdater P_3)
			{
				if (P_0 != null && P_1 >= 0 && P_1 < P_3.buttonCount)
				{
					if (!P_0.isPressureSensitive)
					{
						P_3.buttonValues[P_1] = false;
					}
					else
					{
						P_3.buttonPressureValues[P_1] = 0f;
					}
					P_0.GcIuKOHgXujXqCTdAuwBBVguUoX(P_2, P_1, P_3);
				}
			}
		}

		[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
		public abstract class Extension
		{
			private Controller BheccrWcwXwuvsNLWjWrFwcrgAqE;

			private IControllerExtensionSource NsRIQHseimotuEJGoIuiBqmlsEN;

			internal readonly int _reInputId;

			internal bool isJoystickConnected
			{
				get
				{
					if (BheccrWcwXwuvsNLWjWrFwcrgAqE == null)
					{
						return false;
					}
					return BheccrWcwXwuvsNLWjWrFwcrgAqE._isConnected;
				}
			}

			internal bool enabled
			{
				get
				{
					if (BheccrWcwXwuvsNLWjWrFwcrgAqE == null)
					{
						return false;
					}
					return BheccrWcwXwuvsNLWjWrFwcrgAqE.enabled;
				}
			}

			internal Controller controller => BheccrWcwXwuvsNLWjWrFwcrgAqE;

			internal Extension(IControllerExtensionSource source)
			{
				_reInputId = ReInput.id;
				xynrxTlpTRKtBqstJVBUhORYvbu(source);
			}

			internal Extension(Extension source)
				: this(source.NsRIQHseimotuEJGoIuiBqmlsEN)
			{
				BheccrWcwXwuvsNLWjWrFwcrgAqE = source.BheccrWcwXwuvsNLWjWrFwcrgAqE;
			}

			internal T GetController<T>() where T : Controller
			{
				if (BheccrWcwXwuvsNLWjWrFwcrgAqE == null)
				{
					return null;
				}
				return BheccrWcwXwuvsNLWjWrFwcrgAqE as T;
			}

			internal void SetController(Controller controller)
			{
				BheccrWcwXwuvsNLWjWrFwcrgAqE = controller;
			}

			[CustomObfuscation(rename = false)]
			internal IControllerExtensionSource GetSource()
			{
				return NsRIQHseimotuEJGoIuiBqmlsEN;
			}

			internal void SetSource(Extension extension)
			{
				if (extension == null)
				{
					xynrxTlpTRKtBqstJVBUhORYvbu(null);
				}
				else
				{
					xynrxTlpTRKtBqstJVBUhORYvbu(extension.NsRIQHseimotuEJGoIuiBqmlsEN);
				}
			}

			private void xynrxTlpTRKtBqstJVBUhORYvbu(IControllerExtensionSource P_0)
			{
				NsRIQHseimotuEJGoIuiBqmlsEN = P_0;
				SourceUpdated(NsRIQHseimotuEJGoIuiBqmlsEN);
			}

			internal virtual void Clear()
			{
			}

			internal abstract void SourceUpdated(IControllerExtensionSource source);

			internal abstract void UpdateData(UpdateLoopType updateLoop);

			internal abstract Extension Clone();
		}

		private sealed class gESnsnwyqyFQmwRzqlTqAvcKeYQ : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
		{
			private ControllerPollingInfo ajbaQItphrIyqhowgmMTfPkCBvcN;

			private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

			private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

			public Controller kdBZqupjvsCsVkwJiOeEQzkEDVO;

			public int ZnnmNXXfsicGEHWXbWxdFbttOhz;

			public int KtfZSqhhDUnMPCGxPsDtZNKojDc;

			ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return ajbaQItphrIyqhowgmMTfPkCBvcN;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return ajbaQItphrIyqhowgmMTfPkCBvcN;
				}
			}

			[DebuggerHidden]
			IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
			{
				gESnsnwyqyFQmwRzqlTqAvcKeYQ gESnsnwyqyFQmwRzqlTqAvcKeYQ2;
				if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
				{
					uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
					gESnsnwyqyFQmwRzqlTqAvcKeYQ2 = this;
				}
				else
				{
					gESnsnwyqyFQmwRzqlTqAvcKeYQ2 = new gESnsnwyqyFQmwRzqlTqAvcKeYQ(0);
					gESnsnwyqyFQmwRzqlTqAvcKeYQ2.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
				}
				return gESnsnwyqyFQmwRzqlTqAvcKeYQ2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
				{
				case 0:
					uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
					if (ReInput._id != kdBZqupjvsCsVkwJiOeEQzkEDVO.fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(kdBZqupjvsCsVkwJiOeEQzkEDVO.fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						break;
					}
					kdBZqupjvsCsVkwJiOeEQzkEDVO.UpdatePollingFrameTracking();
					ZnnmNXXfsicGEHWXbWxdFbttOhz = 0;
					goto IL_00ea;
				case 1:
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						goto IL_00dc;
					}
					IL_00ea:
					if (ZnnmNXXfsicGEHWXbWxdFbttOhz >= kdBZqupjvsCsVkwJiOeEQzkEDVO._buttonCount)
					{
						break;
					}
					if (kdBZqupjvsCsVkwJiOeEQzkEDVO.TJIHVuiSWGCCgzVSkGExaxVqdWE(ZnnmNXXfsicGEHWXbWxdFbttOhz, out KtfZSqhhDUnMPCGxPsDtZNKojDc))
					{
						ajbaQItphrIyqhowgmMTfPkCBvcN = new ControllerPollingInfo(success: true, -1, kdBZqupjvsCsVkwJiOeEQzkEDVO.id, kdBZqupjvsCsVkwJiOeEQzkEDVO._name, kdBZqupjvsCsVkwJiOeEQzkEDVO._type, ControllerElementType.Button, ZnnmNXXfsicGEHWXbWxdFbttOhz, Pole.Positive, kdBZqupjvsCsVkwJiOeEQzkEDVO.ZBMEOTEbHBcUeYYftsfiohhXNEse.GetElementIdentifierName(KtfZSqhhDUnMPCGxPsDtZNKojDc), KtfZSqhhDUnMPCGxPsDtZNKojDc, KeyCode.None);
						uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
						return true;
					}
					goto IL_00dc;
					IL_00dc:
					ZnnmNXXfsicGEHWXbWxdFbttOhz++;
					goto IL_00ea;
				}
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}

			void IDisposable.Dispose()
			{
			}

			[DebuggerHidden]
			public gESnsnwyqyFQmwRzqlTqAvcKeYQ(int _003C_003E1__state)
			{
				uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
				LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
			}
		}

		private sealed class pBCPZBukyUDvjacwRAlQgcGSVwGu : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
		{
			private ControllerPollingInfo ajbaQItphrIyqhowgmMTfPkCBvcN;

			private int uoxvBdjXZPeiUprcFCMcTbYvPLr;

			private int LSoEqnQKxzyRdmCBoARNFJYLcLQi;

			public Controller kdBZqupjvsCsVkwJiOeEQzkEDVO;

			public int HjiVedlpIqAotwpUUcNbvxHrQrA;

			public int tbVTJDmVIHkmwDQRDavtkUOpVde;

			ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return ajbaQItphrIyqhowgmMTfPkCBvcN;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return ajbaQItphrIyqhowgmMTfPkCBvcN;
				}
			}

			[DebuggerHidden]
			IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
			{
				pBCPZBukyUDvjacwRAlQgcGSVwGu pBCPZBukyUDvjacwRAlQgcGSVwGu2;
				if (Thread.CurrentThread.ManagedThreadId == LSoEqnQKxzyRdmCBoARNFJYLcLQi && uoxvBdjXZPeiUprcFCMcTbYvPLr == -2)
				{
					uoxvBdjXZPeiUprcFCMcTbYvPLr = 0;
					pBCPZBukyUDvjacwRAlQgcGSVwGu2 = this;
				}
				else
				{
					pBCPZBukyUDvjacwRAlQgcGSVwGu2 = new pBCPZBukyUDvjacwRAlQgcGSVwGu(0);
					pBCPZBukyUDvjacwRAlQgcGSVwGu2.kdBZqupjvsCsVkwJiOeEQzkEDVO = kdBZqupjvsCsVkwJiOeEQzkEDVO;
				}
				return pBCPZBukyUDvjacwRAlQgcGSVwGu2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				switch (uoxvBdjXZPeiUprcFCMcTbYvPLr)
				{
				case 0:
					uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
					if (ReInput._id != kdBZqupjvsCsVkwJiOeEQzkEDVO.fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
					{
						ReInput.CheckInitialized(kdBZqupjvsCsVkwJiOeEQzkEDVO.fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
						break;
					}
					kdBZqupjvsCsVkwJiOeEQzkEDVO.UpdatePollingFrameTracking();
					HjiVedlpIqAotwpUUcNbvxHrQrA = 0;
					goto IL_00ea;
				case 1:
					{
						uoxvBdjXZPeiUprcFCMcTbYvPLr = -1;
						goto IL_00dc;
					}
					IL_00ea:
					if (HjiVedlpIqAotwpUUcNbvxHrQrA >= kdBZqupjvsCsVkwJiOeEQzkEDVO._buttonCount)
					{
						break;
					}
					if (kdBZqupjvsCsVkwJiOeEQzkEDVO.VjLeavtYrLEePWKOOZMXvFYdrJw(HjiVedlpIqAotwpUUcNbvxHrQrA, out tbVTJDmVIHkmwDQRDavtkUOpVde))
					{
						ajbaQItphrIyqhowgmMTfPkCBvcN = new ControllerPollingInfo(success: true, -1, kdBZqupjvsCsVkwJiOeEQzkEDVO.id, kdBZqupjvsCsVkwJiOeEQzkEDVO._name, kdBZqupjvsCsVkwJiOeEQzkEDVO._type, ControllerElementType.Button, HjiVedlpIqAotwpUUcNbvxHrQrA, Pole.Positive, kdBZqupjvsCsVkwJiOeEQzkEDVO.ZBMEOTEbHBcUeYYftsfiohhXNEse.GetElementIdentifierName(tbVTJDmVIHkmwDQRDavtkUOpVde), tbVTJDmVIHkmwDQRDavtkUOpVde, KeyCode.None);
						uoxvBdjXZPeiUprcFCMcTbYvPLr = 1;
						return true;
					}
					goto IL_00dc;
					IL_00dc:
					HjiVedlpIqAotwpUUcNbvxHrQrA++;
					goto IL_00ea;
				}
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}

			void IDisposable.Dispose()
			{
			}

			[DebuggerHidden]
			public pBCPZBukyUDvjacwRAlQgcGSVwGu(int _003C_003E1__state)
			{
				uoxvBdjXZPeiUprcFCMcTbYvPLr = _003C_003E1__state;
				LSoEqnQKxzyRdmCBoARNFJYLcLQi = Thread.CurrentThread.ManagedThreadId;
			}
		}

		public readonly int id;

		protected string _tag;

		protected string _name;

		protected string _hardwareName;

		protected readonly ControllerType _type;

		internal readonly Guid EAIQLWgbsQDNGcJuOWaoPBaXKTl;

		protected string _hardwareIdentifier;

		protected bool _isConnected;

		private Extension DLgfvsKWtDDcFdLxaaSpMucpiDtb;

		private bool TAiAzEAcNOkrpYWJEmhYYqnFvpF;

		private ControllerIdentifier grdJPQXAFFpLyEQaNIOhJYbVNVp;

		internal int fhCkCLBQpxfjvFtQcQZeUtCOKFGZ;

		protected readonly int _buttonCount;

		protected readonly Button[] buttons;

		protected readonly ReadOnlyCollection<Button> buttons_readOnly;

		private readonly IList<Element> KFQlRixtegtOhokPEQnlitLaJDS;

		private readonly ReadOnlyCollection<Element> izLDyzKhaPvNHKsTLMyAkmTgGsf;

		internal readonly InputSource MHWfeAIIxgGWGdDJknvdMLOmOzQM;

		internal readonly ControllerDataUpdater ebxBmtwxyRprAbJBnnRdvbVCKbL;

		internal readonly HardwareControllerMap_Game ZBMEOTEbHBcUeYYftsfiohhXNEse;

		internal uint LCEchZHKMBGDvROfPCrYfJUjifo;

		private uint JCWhIahNeULkUpYumzlNmWGVuaiU;

		private uint UCWXyoxLQqSOtAKzNNsdjUzQILu;

		private Action<bool> DXFSAUKlttPxoWkMUSsJgyyzmdk;

		private IControllerTemplate[] clsGNqAuUlIdwpKcFFXYNYtQlYl;

		private ReadOnlyCollection<IControllerTemplate> esGjphCAJaseoJRUYwIuHAuktSn;

		private static Func<Controller, Guid, bool> BhDCQbURZMQTijLYafWWoJZDVeb;

		private static Func<Controller, Type, bool> MNpohOXmOtJOOPyWOOEAhydJilA;

		[CompilerGenerated]
		private static Func<Controller, Guid, bool> CuxsraehqcBBnFzwaUhfNpVJmUD;

		[CompilerGenerated]
		private static Func<Controller, Type, bool> VbWBeYhyXOxlSVXrgfsxXKbeIWM;

		internal bool wasPollingPrev => JCWhIahNeULkUpYumzlNmWGVuaiU == ReInput.previousFrame;

		public bool enabled
		{
			get
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return false;
				}
				return TAiAzEAcNOkrpYWJEmhYYqnFvpF;
			}
			set
			{
				aUkrKZZmuugskAJZrmbqBXhTEuO(value);
			}
		}

		public string name
		{
			get
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return string.Empty;
				}
				return _name;
			}
			internal set
			{
				_name = value;
			}
		}

		public string tag
		{
			get
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return string.Empty;
				}
				return _tag;
			}
			set
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				}
				else
				{
					_tag = value;
				}
			}
		}

		public string hardwareName
		{
			get
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return string.Empty;
				}
				return _hardwareName;
			}
		}

		public ControllerType type
		{
			get
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return ControllerType.Keyboard;
				}
				return _type;
			}
		}

		public Guid hardwareTypeGuid
		{
			get
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return Guid.Empty;
				}
				return EAIQLWgbsQDNGcJuOWaoPBaXKTl;
			}
		}

		public abstract Guid deviceInstanceGuid { get; }

		public ControllerIdentifier identifier => grdJPQXAFFpLyEQaNIOhJYbVNVp;

		public bool isConnected
		{
			get
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return false;
				}
				return _isConnected;
			}
			internal set
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				}
				else if (!value)
				{
					Disconnected();
				}
				else
				{
					Connected();
				}
			}
		}

		public string hardwareIdentifier
		{
			get
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return string.Empty;
				}
				return _hardwareIdentifier;
			}
		}

		public string mapTypeString => _type.ToString() + "Map";

		public int elementCount
		{
			get
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return 0;
				}
				return KFQlRixtegtOhokPEQnlitLaJDS.Count;
			}
		}

		public int buttonCount
		{
			get
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return 0;
				}
				return _buttonCount;
			}
		}

		public IList<Element> Elements
		{
			get
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return EmptyObjects<Element>.EmptyReadOnlyIListT;
				}
				return izLDyzKhaPvNHKsTLMyAkmTgGsf;
			}
		}

		public IList<Button> Buttons
		{
			get
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return EmptyObjects<Button>.EmptyReadOnlyIListT;
				}
				return buttons_readOnly;
			}
		}

		public Extension extension
		{
			get
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return null;
				}
				return DLgfvsKWtDDcFdLxaaSpMucpiDtb;
			}
		}

		public IList<ControllerElementIdentifier> ElementIdentifiers
		{
			get
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return EmptyObjects<ControllerElementIdentifier>.EmptyReadOnlyIListT;
				}
				return ZBMEOTEbHBcUeYYftsfiohhXNEse.elementIdentifiers_readOnly;
			}
		}

		public IList<ControllerElementIdentifier> ButtonElementIdentifiers
		{
			get
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return EmptyObjects<ControllerElementIdentifier>.EmptyReadOnlyIListT;
				}
				return ZBMEOTEbHBcUeYYftsfiohhXNEse.buttonElementIdentifiers_readOnly;
			}
		}

		public IList<IControllerTemplate> Templates
		{
			get
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return EmptyObjects<IControllerTemplate>.EmptyReadOnlyIListT;
				}
				return esGjphCAJaseoJRUYwIuHAuktSn;
			}
		}

		public int templateCount
		{
			get
			{
				if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
				{
					ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
					return 0;
				}
				return clsGNqAuUlIdwpKcFFXYNYtQlYl.Length;
			}
		}

		internal static Func<Controller, Guid, bool> implementsTemplateDelegate_Guid => (Controller P_0, Guid P_1) => P_0.ImplementsTemplate(P_1);

		internal static Func<Controller, Type, bool> implementsTemplateDelegate_Type => (Controller P_0, Type P_1) => P_0.ImplementsTemplate(P_1);

		internal event Action<bool> EnabledStateChangedEvent
		{
			add
			{
				DXFSAUKlttPxoWkMUSsJgyyzmdk = (Action<bool>)Delegate.Combine(DXFSAUKlttPxoWkMUSsJgyyzmdk, value);
			}
			remove
			{
				DXFSAUKlttPxoWkMUSsJgyyzmdk = (Action<bool>)Delegate.Remove(DXFSAUKlttPxoWkMUSsJgyyzmdk, value);
			}
		}

		internal Controller(int controllerId, InputSource inputSource, string name, string hardwareName, string hardwareIdentifier, ControllerType type, Guid hardwareTypeGuid, int buttonCount, bool[] isButtonPressureSensitive, HardwareButtonInfo[] hwButtonInfo, HardwareControllerMap_Game hardwareMap, Extension extension, ControllerDataUpdater dataUpdater)
		{
			id = controllerId;
			MHWfeAIIxgGWGdDJknvdMLOmOzQM = inputSource;
			_type = type;
			EAIQLWgbsQDNGcJuOWaoPBaXKTl = hardwareTypeGuid;
			_buttonCount = buttonCount;
			_name = name;
			_hardwareName = hardwareName;
			_hardwareIdentifier = hardwareIdentifier;
			ebxBmtwxyRprAbJBnnRdvbVCKbL = dataUpdater;
			ZBMEOTEbHBcUeYYftsfiohhXNEse = hardwareMap;
			TAiAzEAcNOkrpYWJEmhYYqnFvpF = true;
			fhCkCLBQpxfjvFtQcQZeUtCOKFGZ = ReInput.id;
			yWNmUHhwhnWFmbWqRkbfWBhSgQq(extension);
			KFQlRixtegtOhokPEQnlitLaJDS = new List<Element>(buttonCount);
			izLDyzKhaPvNHKsTLMyAkmTgGsf = new ReadOnlyCollection<Element>(KFQlRixtegtOhokPEQnlitLaJDS);
			buttons = new Button[buttonCount];
			if (isButtonPressureSensitive == null || isButtonPressureSensitive.Length < buttonCount)
			{
				for (int i = 0; i < buttonCount; i++)
				{
					buttons[i] = new Button(this, hardwareMap.buttonElementIdentifierIds[i], "Button " + i, isPressureSensitive: false, (hwButtonInfo != null) ? hwButtonInfo[i] : new HardwareButtonInfo());
					sPDBUryojEPTZhjXiDvYbSylxsi(buttons[i]);
				}
			}
			else
			{
				for (int j = 0; j < buttonCount; j++)
				{
					buttons[j] = new Button(this, hardwareMap.buttonElementIdentifierIds[j], "Button " + j, isButtonPressureSensitive[j], (hwButtonInfo != null) ? hwButtonInfo[j] : new HardwareButtonInfo());
					sPDBUryojEPTZhjXiDvYbSylxsi(buttons[j]);
				}
			}
			buttons_readOnly = new ReadOnlyCollection<Button>(buttons);
			clsGNqAuUlIdwpKcFFXYNYtQlYl = EmptyObjects<IControllerTemplate>.array;
			esGjphCAJaseoJRUYwIuHAuktSn = new ReadOnlyCollection<IControllerTemplate>(clsGNqAuUlIdwpKcFFXYNYtQlYl);
			Connected();
		}

		internal virtual void guKElsGLCmgnAbWmxWZxRdTPwg()
		{
			grdJPQXAFFpLyEQaNIOhJYbVNVp = new ControllerIdentifier(this);
		}

		public virtual Element GetElementById(int elementIdentifierId)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return null;
			}
			if (ZBMEOTEbHBcUeYYftsfiohhXNEse == null)
			{
				return null;
			}
			int buttonIndex = ZBMEOTEbHBcUeYYftsfiohhXNEse.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0)
			{
				return null;
			}
			return buttons[buttonIndex];
		}

		public int GetButtonIndexById(int elementIdentifierId)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return -1;
			}
			return ZBMEOTEbHBcUeYYftsfiohhXNEse.GetButtonIndex(elementIdentifierId);
		}

		public ControllerElementIdentifier GetElementIdentifierById(int elementIdentifierId)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return null;
			}
			return ZBMEOTEbHBcUeYYftsfiohhXNEse.GetElementIdentifierById(elementIdentifierId);
		}

		public virtual bool GetButton(int index)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			if (index < 0 || index >= _buttonCount)
			{
				return false;
			}
			return buttons[index].value;
		}

		public virtual bool GetButtonDown(int index)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			if (index < 0 || index >= _buttonCount)
			{
				return false;
			}
			return buttons[index].justPressed;
		}

		public virtual bool GetButtonUp(int index)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			if (index < 0 || index >= _buttonCount)
			{
				return false;
			}
			return buttons[index].justReleased;
		}

		public virtual bool GetButtonChanged(int index)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			if (index < 0 || index >= _buttonCount)
			{
				return false;
			}
			return buttons[index].value != buttons[index].valuePrev;
		}

		public virtual bool GetButtonPrev(int index)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			if (index < 0 || index >= _buttonCount)
			{
				return false;
			}
			return buttons[index].valuePrev;
		}

		public virtual bool GetButtonDoublePressHold(int index)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			return GetButtonDoublePressHold(index, 0f);
		}

		public virtual bool GetButtonDoublePressHold(int index, float speed)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			if (index < 0 || index >= _buttonCount)
			{
				return false;
			}
			return buttons[index].DoublePressedAndHeld(speed);
		}

		public virtual bool GetButtonDoublePressDown(int index)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			return GetButtonDoublePressDown(index, 0f);
		}

		public virtual bool GetButtonDoublePressDown(int index, float speed)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			if (index < 0 || index >= _buttonCount)
			{
				return false;
			}
			return buttons[index].JustDoublePressed(speed);
		}

		public virtual double GetButtonTimePressed(int index)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return 0.0;
			}
			if (index < 0 || index >= _buttonCount)
			{
				return 0.0;
			}
			return buttons[index].timePressed;
		}

		public virtual double GetButtonTimeUnpressed(int index)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return 0.0;
			}
			if (index < 0 || index >= _buttonCount)
			{
				return 0.0;
			}
			return buttons[index].timeUnpressed;
		}

		public virtual double GetButtonLastTimePressed(int index)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return 0.0;
			}
			if (index < 0 || index >= _buttonCount)
			{
				return 0.0;
			}
			return buttons[index].lastTimePressed;
		}

		public virtual double GetButtonLastTimeUnpressed(int index)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return 0.0;
			}
			if (index < 0 || index >= _buttonCount)
			{
				return 0.0;
			}
			return buttons[index].lastTimeUnpressed;
		}

		public virtual bool GetAnyButton()
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			for (int i = 0; i < _buttonCount; i++)
			{
				if (buttons[i].value)
				{
					return true;
				}
			}
			return false;
		}

		public virtual bool GetAnyButtonDown()
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			for (int i = 0; i < _buttonCount; i++)
			{
				if (buttons[i].justPressed)
				{
					return true;
				}
			}
			return false;
		}

		public virtual bool GetAnyButtonUp()
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			for (int i = 0; i < _buttonCount; i++)
			{
				if (buttons[i].justReleased)
				{
					return true;
				}
			}
			return false;
		}

		public virtual bool GetAnyButtonPrev()
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			for (int i = 0; i < _buttonCount; i++)
			{
				if (buttons[i].valuePrev)
				{
					return true;
				}
			}
			return false;
		}

		public virtual bool GetAnyButtonChanged()
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			for (int i = 0; i < _buttonCount; i++)
			{
				if (buttons[i].justChangedState)
				{
					return true;
				}
			}
			return false;
		}

		public virtual bool GetButtonById(int elementIdentifierId)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			int buttonIndex = ZBMEOTEbHBcUeYYftsfiohhXNEse.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				return false;
			}
			return buttons[buttonIndex].value;
		}

		public virtual bool GetButtonDownById(int elementIdentifierId)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			int buttonIndex = ZBMEOTEbHBcUeYYftsfiohhXNEse.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				return false;
			}
			return buttons[buttonIndex].justPressed;
		}

		public virtual bool GetButtonUpById(int elementIdentifierId)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			int buttonIndex = ZBMEOTEbHBcUeYYftsfiohhXNEse.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				return false;
			}
			return buttons[buttonIndex].justReleased;
		}

		public virtual bool GetButtonDoublePressHoldById(int elementIdentifierId, float speed)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			int buttonIndex = ZBMEOTEbHBcUeYYftsfiohhXNEse.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				return false;
			}
			return buttons[buttonIndex].DoublePressedAndHeld(speed);
		}

		public virtual bool GetButtonDoublePressDownById(int elementIdentifierId, float speed)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			int buttonIndex = ZBMEOTEbHBcUeYYftsfiohhXNEse.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				return false;
			}
			return buttons[buttonIndex].JustDoublePressed(speed);
		}

		public virtual bool GetButtonDoublePressHoldById(int elementIdentifierId)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			int buttonIndex = ZBMEOTEbHBcUeYYftsfiohhXNEse.GetButtonIndex(elementIdentifierId);
			return GetButtonDoublePressHold(buttonIndex, 0f);
		}

		public virtual bool GetButtonDoublePressDownById(int elementIdentifierId)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			int buttonIndex = ZBMEOTEbHBcUeYYftsfiohhXNEse.GetButtonIndex(elementIdentifierId);
			return GetButtonDoublePressDown(buttonIndex, 0f);
		}

		public virtual bool GetButtonPrevById(int elementIdentifierId)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			int buttonIndex = ZBMEOTEbHBcUeYYftsfiohhXNEse.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				return false;
			}
			return buttons[buttonIndex].valuePrev;
		}

		public virtual double GetButtonTimePressedById(int elementIdentifierId)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return 0.0;
			}
			int buttonIndex = ZBMEOTEbHBcUeYYftsfiohhXNEse.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				return 0.0;
			}
			return buttons[buttonIndex].timePressed;
		}

		public virtual double GetButtonTimeUnpressedById(int elementIdentifierId)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return 0.0;
			}
			int buttonIndex = ZBMEOTEbHBcUeYYftsfiohhXNEse.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				return 0.0;
			}
			return buttons[buttonIndex].timeUnpressed;
		}

		public virtual double GetButtonLastTimePressedById(int elementIdentifierId)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return 0.0;
			}
			int buttonIndex = ZBMEOTEbHBcUeYYftsfiohhXNEse.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				return 0.0;
			}
			return buttons[buttonIndex].lastTimePressed;
		}

		public virtual double GetButtonLastTimeUnpressedById(int elementIdentifierId)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return 0.0;
			}
			int buttonIndex = ZBMEOTEbHBcUeYYftsfiohhXNEse.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				return 0.0;
			}
			return buttons[buttonIndex].lastTimeUnpressed;
		}

		public virtual ControllerPollingInfo PollForFirstElement()
		{
			return PollForFirstButton();
		}

		public virtual ControllerPollingInfo PollForFirstElementDown()
		{
			return PollForFirstButtonDown();
		}

		public virtual ControllerPollingInfo PollForFirstButton()
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return ControllerPollingInfo.gpfCsRFuwmhJyfJraYsxIMhInTuX();
			}
			UpdatePollingFrameTracking();
			for (int i = 0; i < _buttonCount; i++)
			{
				if (TJIHVuiSWGCCgzVSkGExaxVqdWE(i, out var elementIdentifierId))
				{
					return new ControllerPollingInfo(success: true, -1, id, _name, _type, ControllerElementType.Button, i, Pole.Positive, ZBMEOTEbHBcUeYYftsfiohhXNEse.GetElementIdentifierName(elementIdentifierId), elementIdentifierId, KeyCode.None);
				}
			}
			return ControllerPollingInfo.gpfCsRFuwmhJyfJraYsxIMhInTuX();
		}

		public virtual ControllerPollingInfo PollForFirstButtonDown()
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return ControllerPollingInfo.gpfCsRFuwmhJyfJraYsxIMhInTuX();
			}
			UpdatePollingFrameTracking();
			for (int i = 0; i < _buttonCount; i++)
			{
				if (VjLeavtYrLEePWKOOZMXvFYdrJw(i, out var elementIdentifierId))
				{
					return new ControllerPollingInfo(success: true, -1, id, _name, _type, ControllerElementType.Button, i, Pole.Positive, ZBMEOTEbHBcUeYYftsfiohhXNEse.GetElementIdentifierName(elementIdentifierId), elementIdentifierId, KeyCode.None);
				}
			}
			return ControllerPollingInfo.gpfCsRFuwmhJyfJraYsxIMhInTuX();
		}

		public virtual IEnumerable<ControllerPollingInfo> PollForAllElements()
		{
			return PollForAllButtons();
		}

		public virtual IEnumerable<ControllerPollingInfo> PollForAllElementsDown()
		{
			return PollForAllButtonsDown();
		}

		public virtual IEnumerable<ControllerPollingInfo> PollForAllButtons()
		{
			gESnsnwyqyFQmwRzqlTqAvcKeYQ gESnsnwyqyFQmwRzqlTqAvcKeYQ2 = new gESnsnwyqyFQmwRzqlTqAvcKeYQ(-2);
			gESnsnwyqyFQmwRzqlTqAvcKeYQ2.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
			return gESnsnwyqyFQmwRzqlTqAvcKeYQ2;
		}

		public virtual IEnumerable<ControllerPollingInfo> PollForAllButtonsDown()
		{
			pBCPZBukyUDvjacwRAlQgcGSVwGu pBCPZBukyUDvjacwRAlQgcGSVwGu2 = new pBCPZBukyUDvjacwRAlQgcGSVwGu(-2);
			pBCPZBukyUDvjacwRAlQgcGSVwGu2.kdBZqupjvsCsVkwJiOeEQzkEDVO = this;
			return pBCPZBukyUDvjacwRAlQgcGSVwGu2;
		}

		private bool TJIHVuiSWGCCgzVSkGExaxVqdWE(int P_0, out int P_1)
		{
			P_1 = -1;
			if (!buttons[P_0].value || buttons[P_0].LqDQGfXnOKATlGdCocbmqgYwvAAv._excludeFromPolling)
			{
				return false;
			}
			P_1 = ZBMEOTEbHBcUeYYftsfiohhXNEse.buttonElementIdentifierIds[P_0];
			if (P_1 < 0)
			{
				return false;
			}
			return true;
		}

		private bool VjLeavtYrLEePWKOOZMXvFYdrJw(int P_0, out int P_1)
		{
			P_1 = -1;
			if (!buttons[P_0].justPressed || buttons[P_0].LqDQGfXnOKATlGdCocbmqgYwvAAv._excludeFromPolling)
			{
				return false;
			}
			P_1 = ZBMEOTEbHBcUeYYftsfiohhXNEse.buttonElementIdentifierIds[P_0];
			if (P_1 < 0)
			{
				return false;
			}
			return true;
		}

		protected void UpdatePollingFrameTracking()
		{
			if (UCWXyoxLQqSOtAKzNNsdjUzQILu == ReInput.currentFrame)
			{
				return;
			}
			JCWhIahNeULkUpYumzlNmWGVuaiU = UCWXyoxLQqSOtAKzNNsdjUzQILu;
			UCWXyoxLQqSOtAKzNNsdjUzQILu = ReInput.currentFrame;
			if (!wasPollingPrev)
			{
				if (LCEchZHKMBGDvROfPCrYfJUjifo == uint.MaxValue)
				{
					LCEchZHKMBGDvROfPCrYfJUjifo = 0u;
				}
				else
				{
					LCEchZHKMBGDvROfPCrYfJUjifo++;
				}
			}
		}

		public virtual double GetLastTimeActive()
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return 0.0;
			}
			return GetLastTimeActive(useRawValues: false);
		}

		public virtual double GetLastTimeActive(bool useRawValues)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return 0.0;
			}
			return GetLastTimeAnyButtonPressed();
		}

		public virtual double GetLastTimeAnyElementChanged()
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return 0.0;
			}
			return GetLastTimeAnyElementChanged(useRawValues: false);
		}

		public virtual double GetLastTimeAnyElementChanged(bool useRawValues)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return 0.0;
			}
			return GetLastTimeAnyButtonChanged();
		}

		public double GetLastTimeAnyButtonPressed()
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return 0.0;
			}
			if (buttons == null)
			{
				return 0.0;
			}
			double num = 0.0;
			for (int i = 0; i < buttons.Length; i++)
			{
				double lastTimePressed = buttons[i].lastTimePressed;
				if (lastTimePressed > num)
				{
					num = lastTimePressed;
				}
			}
			return num;
		}

		public double GetLastTimeAnyButtonChanged()
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return 0.0;
			}
			if (buttons == null)
			{
				return 0.0;
			}
			double num = 0.0;
			for (int i = 0; i < buttons.Length; i++)
			{
				double lastTimeStateChanged = buttons[i].lastTimeStateChanged;
				if (lastTimeStateChanged > num)
				{
					num = lastTimeStateChanged;
				}
			}
			return num;
		}

		public T GetExtension<T>() where T : class
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return null;
			}
			return DLgfvsKWtDDcFdLxaaSpMucpiDtb as T;
		}

		public IControllerTemplate GetTemplate(Guid typeGuid)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return null;
			}
			for (int i = 0; i < clsGNqAuUlIdwpKcFFXYNYtQlYl.Length; i++)
			{
				if (clsGNqAuUlIdwpKcFFXYNYtQlYl[i].typeGuid == typeGuid)
				{
					return clsGNqAuUlIdwpKcFFXYNYtQlYl[i];
				}
			}
			return null;
		}

		public IControllerTemplate GetTemplate(Type type)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return null;
			}
			for (int i = 0; i < clsGNqAuUlIdwpKcFFXYNYtQlYl.Length; i++)
			{
				if (ReflectionTools.DoesTypeImplement(clsGNqAuUlIdwpKcFFXYNYtQlYl[i].GetType(), type))
				{
					return clsGNqAuUlIdwpKcFFXYNYtQlYl[i];
				}
			}
			return null;
		}

		public T GetTemplate<T>() where T : class
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return null;
			}
			for (int i = 0; i < clsGNqAuUlIdwpKcFFXYNYtQlYl.Length; i++)
			{
				if (clsGNqAuUlIdwpKcFFXYNYtQlYl[i] as T != null)
				{
					return clsGNqAuUlIdwpKcFFXYNYtQlYl[i] as T;
				}
			}
			return null;
		}

		public bool ImplementsTemplate(Guid typeGuid)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			for (int i = 0; i < clsGNqAuUlIdwpKcFFXYNYtQlYl.Length; i++)
			{
				if (clsGNqAuUlIdwpKcFFXYNYtQlYl[i].typeGuid == typeGuid)
				{
					return true;
				}
			}
			return false;
		}

		public bool ImplementsTemplate(Type type)
		{
			if (ReInput._id != fhCkCLBQpxfjvFtQcQZeUtCOKFGZ)
			{
				ReInput.CheckInitialized(fhCkCLBQpxfjvFtQcQZeUtCOKFGZ);
				return false;
			}
			if ((object)type == null)
			{
				throw new ArgumentNullException("type");
			}
			for (int i = 0; i < clsGNqAuUlIdwpKcFFXYNYtQlYl.Length; i++)
			{
				if (ReflectionTools.DoesTypeImplement(clsGNqAuUlIdwpKcFFXYNYtQlYl[i].GetType(), type))
				{
					return true;
				}
			}
			return false;
		}

		public bool ImplementsTemplate<T>() where T : class
		{
			return ImplementsTemplate(typeof(T));
		}

		internal void vSYvCCxGYdVIvgTuHTKLFuJCAuN(IControllerTemplate[] P_0)
		{
			if (P_0 != null)
			{
				clsGNqAuUlIdwpKcFFXYNYtQlYl = P_0;
				esGjphCAJaseoJRUYwIuHAuktSn = new ReadOnlyCollection<IControllerTemplate>(clsGNqAuUlIdwpKcFFXYNYtQlYl);
			}
		}

		internal virtual void qLvftnPJXcUYQsqiHkMAPRekFwO(UpdateLoopType P_0)
		{
			bool flag = ReInput.IsInputAllowed(_type);
			int num = _buttonCount;
			if (flag)
			{
				for (int i = 0; i < num; i++)
				{
					if (buttons[i].sPOjvMiFvLbtQoywtTuWbVDsRcs <= 0)
					{
						buttons[i].GcIuKOHgXujXqCTdAuwBBVguUoX(P_0, i, ebxBmtwxyRprAbJBnnRdvbVCKbL);
					}
				}
			}
			else
			{
				for (int j = 0; j < num; j++)
				{
					if (buttons[j].sPOjvMiFvLbtQoywtTuWbVDsRcs <= 0)
					{
						buttons[j].XyqdukdphRBRoFeJdPHmDkadYpXZ(P_0);
					}
				}
			}
			if (DLgfvsKWtDDcFdLxaaSpMucpiDtb != null)
			{
				DLgfvsKWtDDcFdLxaaSpMucpiDtb.UpdateData(P_0);
			}
		}

		internal virtual ButtonStateFlags sJNRUDgBlgpVRmEmTGLlTIjHjJJ(int P_0)
		{
			if (P_0 < 0 || P_0 >= _buttonCount)
			{
				return ButtonStateFlags.vzRTPkAxQouGEgDZGevsgfcpaRF;
			}
			return buttons[P_0].state;
		}

		internal void yWNmUHhwhnWFmbWqRkbfWBhSgQq(Extension P_0)
		{
			if (P_0 == null)
			{
				DLgfvsKWtDDcFdLxaaSpMucpiDtb = null;
				return;
			}
			if (DLgfvsKWtDDcFdLxaaSpMucpiDtb != null)
			{
				cTKkQwFScGrhoczGzTiQqMASUOy(P_0);
				return;
			}
			P_0.SetController(this);
			DLgfvsKWtDDcFdLxaaSpMucpiDtb = P_0.Clone();
		}

		internal void cTKkQwFScGrhoczGzTiQqMASUOy(Extension P_0)
		{
			if (DLgfvsKWtDDcFdLxaaSpMucpiDtb != null)
			{
				DLgfvsKWtDDcFdLxaaSpMucpiDtb.SetSource(P_0);
				DLgfvsKWtDDcFdLxaaSpMucpiDtb.SetController(this);
				P_0?.SetController(this);
			}
			else
			{
				yWNmUHhwhnWFmbWqRkbfWBhSgQq(P_0);
			}
		}

		internal virtual void dLvQQBBPNcDLyfQfBHFGJrYJbsBD()
		{
			for (int i = 0; i < _buttonCount; i++)
			{
				if (buttons[i] != null)
				{
					buttons[i].Reset();
				}
			}
			if (ebxBmtwxyRprAbJBnnRdvbVCKbL != null)
			{
				ebxBmtwxyRprAbJBnnRdvbVCKbL.ClearData();
			}
			if (DLgfvsKWtDDcFdLxaaSpMucpiDtb != null)
			{
				DLgfvsKWtDDcFdLxaaSpMucpiDtb.Clear();
			}
		}

		internal virtual bool aUkrKZZmuugskAJZrmbqBXhTEuO(bool P_0)
		{
			if (TAiAzEAcNOkrpYWJEmhYYqnFvpF == P_0)
			{
				return false;
			}
			if (!P_0)
			{
				dLvQQBBPNcDLyfQfBHFGJrYJbsBD();
			}
			TAiAzEAcNOkrpYWJEmhYYqnFvpF = P_0;
			if (DXFSAUKlttPxoWkMUSsJgyyzmdk != null)
			{
				DXFSAUKlttPxoWkMUSsJgyyzmdk(P_0);
			}
			return true;
		}

		internal virtual void UqhYnihUfIHBqSaeTWbwiJVKQLu(ControllerMap P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			P_0.controllerId = id;
			P_0.controllerType = _type;
			IList<ActionElementMap> buttonMaps = P_0.ButtonMaps;
			for (int i = 0; i < buttonMaps.Count; i++)
			{
				sSQYMATtZixpYjjUsqaWsAupijI(P_0, buttonMaps[i]);
			}
			for (int num = buttonMaps.Count - 1; num >= 0; num--)
			{
				if (buttonMaps[num].elementIndex < 0)
				{
					P_0.DeleteElementMap(buttonMaps[num].fOjavGziuUSawAgvwyVARpyRBVx);
				}
			}
		}

		internal virtual void sSQYMATtZixpYjjUsqaWsAupijI(ControllerMap P_0, ActionElementMap P_1)
		{
			if (P_1 != null && P_1._elementType == ControllerElementType.Button)
			{
				P_1.WydnbjhvuRfUebKtXVYHLAcSJCu(P_0);
			}
		}

		internal bool nwifnFGXeLkkrTVqcjGTJytMfiJP(ActionElementMap P_0, int P_1, out float P_2, out bool P_3)
		{
			P_3 = false;
			P_2 = 0f;
			if (P_1 != P_0._actionId)
			{
				return false;
			}
			int ofrrxjPHuwNabkrGucUvSPRIAGB = P_0.ofrrxjPHuwNabkrGucUvSPRIAGB;
			if (ofrrxjPHuwNabkrGucUvSPRIAGB < 0 || ofrrxjPHuwNabkrGucUvSPRIAGB >= _buttonCount)
			{
				return false;
			}
			P_3 = buttons[ofrrxjPHuwNabkrGucUvSPRIAGB].OhDzXyWCrRBpocUlcUasDrzXpRhM;
			float num = ((!P_3) ? (buttons[ofrrxjPHuwNabkrGucUvSPRIAGB].value ? 1f : 0f) : buttons[ofrrxjPHuwNabkrGucUvSPRIAGB].pressure);
			if (num > 0f)
			{
				if (P_0._elementType == ControllerElementType.Button)
				{
					if (P_0._axisContribution == Pole.Negative)
					{
						num *= -1f;
					}
				}
				else if (P_0._elementType == ControllerElementType.Axis)
				{
					if (P_0._axisRange == AxisRange.Full)
					{
						if (P_0._invert)
						{
							num *= -1f;
						}
					}
					else if (P_0._axisContribution == Pole.Negative)
					{
						num *= -1f;
					}
				}
			}
			P_2 = num;
			return true;
		}

		internal bool nwifnFGXeLkkrTVqcjGTJytMfiJP(ActionElementMap P_0, int P_1, bool P_2, out float P_3)
		{
			P_3 = 0f;
			if (P_1 != P_0._actionId)
			{
				return false;
			}
			float num = (P_2 ? 1f : 0f);
			if (num > 0f)
			{
				if (P_0._elementType == ControllerElementType.Button)
				{
					if (P_0._axisContribution == Pole.Negative)
					{
						num *= -1f;
					}
				}
				else if (P_0._elementType == ControllerElementType.Axis)
				{
					if (P_0._axisRange == AxisRange.Full)
					{
						if (P_0._invert)
						{
							num *= -1f;
						}
					}
					else if (P_0._axisContribution == Pole.Negative)
					{
						num *= -1f;
					}
				}
			}
			P_3 = num;
			return true;
		}

		internal void sPDBUryojEPTZhjXiDvYbSylxsi(Element P_0)
		{
			if (P_0 != null)
			{
				ListTools.AddIfUnique(KFQlRixtegtOhokPEQnlitLaJDS, P_0);
			}
		}

		internal virtual Guid KtsreYmDlFKBWKDXFHOwGDzSFoKj()
		{
			return Guid.Empty;
		}

		protected virtual void Connected()
		{
			_isConnected = true;
		}

		protected virtual void Disconnected()
		{
			_isConnected = false;
			if (ebxBmtwxyRprAbJBnnRdvbVCKbL != null)
			{
				ebxBmtwxyRprAbJBnnRdvbVCKbL.ClearData();
			}
		}

		[CompilerGenerated]
		private static bool paJFVCvzTHwErnPZIjNaQkmloXV(Controller P_0, Guid P_1)
		{
			return P_0.ImplementsTemplate(P_1);
		}

		[CompilerGenerated]
		private static bool BzhlWjPXvflDVcnxTTmyvPwvfYdf(Controller P_0, Type P_1)
		{
			return P_0.ImplementsTemplate(P_1);
		}
	}
}
