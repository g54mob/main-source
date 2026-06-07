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
using Rewired.Internal.Localization;
using Rewired.Utils;
using UnityEngine;

namespace Rewired
{
	public abstract class Controller
	{
		public abstract class Element
		{
			internal abstract class bCzQPMSObQgquQqCfeNwqjUaliPD
			{
				public abstract class KwiLuaWUkeSzUUtwvSxftRjlPBLx
				{
					public abstract void XKZIxwRUwDpNhkICJrLjGrsjhGsn();
				}

				protected readonly int JIHbTKaaZdviGYYaqiknPXfDmoRQ;

				protected readonly int[] HGxgcvKinyAThdSOJxmxbcLwjfrXb;

				protected KwiLuaWUkeSzUUtwvSxftRjlPBLx[] xXHdCMSmsRUMaIpygCDYKFNDZyfr;

				public KwiLuaWUkeSzUUtwvSxftRjlPBLx yVsKAUWymJvXlLdJcirLAkYCwgyuA;

				private int KorITzkUWrapWSEcrMKEngxzFXIp;

				public int IGKSYOGZfiVDBQWLCrQaskJlolZQ = -1;

				protected ReadOnlyCollection<KwiLuaWUkeSzUUtwvSxftRjlPBLx> XIMhDmsvLhuswKHzTjyLyyCFzzyc;

				public IList<KwiLuaWUkeSzUUtwvSxftRjlPBLx> vloZNCJrXgwGQjBcoFURMWIeizrF => XIMhDmsvLhuswKHzTjyLyyCFzzyc;

				public UpdateLoopType duvdeoIMbviHBoTTDYZbkoEpbLKZA
				{
					set
					{
						if (IGKSYOGZfiVDBQWLCrQaskJlolZQ != (int)updateLoopType)
						{
							IGKSYOGZfiVDBQWLCrQaskJlolZQ = (int)updateLoopType;
							KorITzkUWrapWSEcrMKEngxzFXIp = HGxgcvKinyAThdSOJxmxbcLwjfrXb[(int)updateLoopType];
							yVsKAUWymJvXlLdJcirLAkYCwgyuA = xXHdCMSmsRUMaIpygCDYKFNDZyfr[KorITzkUWrapWSEcrMKEngxzFXIp];
						}
					}
				}

				public bCzQPMSObQgquQqCfeNwqjUaliPD(UpdateLoopSetting P_0)
				{
					HGxgcvKinyAThdSOJxmxbcLwjfrXb = new int[3];
					JIHbTKaaZdviGYYaqiknPXfDmoRQ = 0;
					using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
					{
						List<UpdateLoopType> list = tList.list;
						EnumConverter.ToUpdateLoopTypes(P_0, list);
						for (int i = 0; i < list.Count; i++)
						{
							HGxgcvKinyAThdSOJxmxbcLwjfrXb[(int)list[i]] = JIHbTKaaZdviGYYaqiknPXfDmoRQ;
							JIHbTKaaZdviGYYaqiknPXfDmoRQ++;
						}
					}
					xXHdCMSmsRUMaIpygCDYKFNDZyfr = new KwiLuaWUkeSzUUtwvSxftRjlPBLx[JIHbTKaaZdviGYYaqiknPXfDmoRQ];
					XIMhDmsvLhuswKHzTjyLyyCFzzyc = new ReadOnlyCollection<KwiLuaWUkeSzUUtwvSxftRjlPBLx>(xXHdCMSmsRUMaIpygCDYKFNDZyfr);
				}

				public void XKZIxwRUwDpNhkICJrLjGrsjhGsn()
				{
					for (int i = 0; i < JIHbTKaaZdviGYYaqiknPXfDmoRQ; i++)
					{
						xXHdCMSmsRUMaIpygCDYKFNDZyfr[i].XKZIxwRUwDpNhkICJrLjGrsjhGsn();
					}
				}

				public KwiLuaWUkeSzUUtwvSxftRjlPBLx JscfZFutegiJlCAnblqEbxNhLhuWB(UpdateLoopType P_0)
				{
					return xXHdCMSmsRUMaIpygCDYKFNDZyfr[HGxgcvKinyAThdSOJxmxbcLwjfrXb[(int)P_0]];
				}
			}

			public readonly int id;

			public readonly string name;

			public readonly ControllerElementType type;

			internal bCzQPMSObQgquQqCfeNwqjUaliPD MAFKTTDtKFthZPCHBEHSFPBJwyXr;

			internal int zpCvoTkfZmcEPlIkyettGEDFDHMq;

			internal Controller SHugpoIFWkCnojYBXWjOaAoAAYCW;

			internal readonly int oLUDKIBSDOGsiswKzVsPEXOleBcs;

			private CompoundElement LyYMIsOEwqZtZNOYrWdmejcUBjDz;

			public ControllerElementIdentifier elementIdentifier
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return null;
					}
					ControllerElementIdentifier elementIdentifierById = SHugpoIFWkCnojYBXWjOaAoAAYCW.GetElementIdentifierById(id);
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
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return false;
					}
					return zpCvoTkfZmcEPlIkyettGEDFDHMq > 0;
				}
			}

			public CompoundElement compoundElement => LyYMIsOEwqZtZNOYrWdmejcUBjDz;

			internal Element(Controller P_0, int P_1, string P_2, ControllerElementType P_3)
			{
				SHugpoIFWkCnojYBXWjOaAoAAYCW = P_0;
				id = P_1;
				name = P_2;
				type = P_3;
				oLUDKIBSDOGsiswKzVsPEXOleBcs = ReInput.id;
			}

			public void Reset()
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				}
				else if (MAFKTTDtKFthZPCHBEHSFPBJwyXr != null)
				{
					MAFKTTDtKFthZPCHBEHSFPBJwyXr.XKZIxwRUwDpNhkICJrLjGrsjhGsn();
				}
			}

			internal void AixbJlgLwUhdFLjrBmsVWHQdaYGD(CompoundElement P_0)
			{
				if (zpCvoTkfZmcEPlIkyettGEDFDHMq > 0)
				{
					Logger.LogWarning("This element is already a member of a compound element! This is not supported. Resulting values may be unpredictable.");
				}
				zpCvoTkfZmcEPlIkyettGEDFDHMq++;
				if (LyYMIsOEwqZtZNOYrWdmejcUBjDz == null)
				{
					LyYMIsOEwqZtZNOYrWdmejcUBjDz = P_0;
				}
			}

			internal void pxTcGadawijIAsKsGfnWgtQHrCPfb(CompoundElement P_0)
			{
				if (zpCvoTkfZmcEPlIkyettGEDFDHMq == 0)
				{
					Logger.LogWarning("This element is not a member of a compound element!");
					zpCvoTkfZmcEPlIkyettGEDFDHMq = 0;
					return;
				}
				zpCvoTkfZmcEPlIkyettGEDFDHMq--;
				if (LyYMIsOEwqZtZNOYrWdmejcUBjDz == P_0)
				{
					LyYMIsOEwqZtZNOYrWdmejcUBjDz = null;
				}
			}
		}

		public sealed class Axis : Element
		{
			internal class cklPQNOaXIKQaOQBXCuBvdPGDwaJ : bCzQPMSObQgquQqCfeNwqjUaliPD
			{
				public class dxMCrjXRuiWpmTVWOLwLPfcRAaVA : KwiLuaWUkeSzUUtwvSxftRjlPBLx
				{
					private const float DaRiDWJqZYhCNntQJQHKjPtPsBoDA = 0.001f;

					public float ANnyYrpgRHgHrBXsbJxMFrsUzupD;

					public float QjjWsQqYUhMzHwtwGMfAFahPwrGs;

					public float EaLuzdnyluVzMDFyakXGblUlRCOE;

					public float roSImvvrwLGGUiJvXrNnBGnELHBO;

					public float jMseRrdpuRRriDIcGpZVGLkgPvNm;

					public float CTRjvHTJyWSmxiDUWDNBrXSnvmYh;

					public double lrnyFMqJOhGdqypSCULgMvObqwlD;

					public double FPBdsQMYRmtAvzxuEAsQbyCQixVQ;

					public double GInkgXqMbdkmGXxjUBrtNcXQNawo;

					public double AgsxALBGlJLrzNZUtUJmfWuWvGoh;

					public double luwPdoYMAhnuKuRcpLEDuEKHMlaK;

					public double lamEDqHpfiBduZNUPqpZTXAngSKcb;

					public double lcftwkkktEQTVpDOnKHlhrphhtSf
					{
						get
						{
							if ((double)ANnyYrpgRHgHrBXsbJxMFrsUzupD == 0.0)
							{
								return 0.0;
							}
							return ReInput.unscaledTime - GInkgXqMbdkmGXxjUBrtNcXQNawo;
						}
					}

					public double oklIBqrNAjEBNmNcbfYZBIxnwhNqA
					{
						get
						{
							if ((double)EaLuzdnyluVzMDFyakXGblUlRCOE == 0.0)
							{
								return 0.0;
							}
							return ReInput.unscaledTime - AgsxALBGlJLrzNZUtUJmfWuWvGoh;
						}
					}

					public double rxNqrmTpgxDQHQremAuWFIRkPOzjb
					{
						get
						{
							if (ANnyYrpgRHgHrBXsbJxMFrsUzupD != 0f)
							{
								return 0.0;
							}
							return ReInput.unscaledTime - lrnyFMqJOhGdqypSCULgMvObqwlD;
						}
					}

					public double TMuDRVtzlxLmukDUzihXdSVxCQAe
					{
						get
						{
							if ((double)EaLuzdnyluVzMDFyakXGblUlRCOE != 0.0)
							{
								return 0.0;
							}
							return ReInput.unscaledTime - FPBdsQMYRmtAvzxuEAsQbyCQixVQ;
						}
					}

					public void DsDuSUaDcVanpNAhDLIRqjKndMGi(bool P_0)
					{
						double unscaledTime = ReInput.unscaledTime;
						if (P_0)
						{
							if (!MathTools.Approximately(jMseRrdpuRRriDIcGpZVGLkgPvNm, 0f))
							{
								lrnyFMqJOhGdqypSCULgMvObqwlD = unscaledTime;
							}
							else
							{
								GInkgXqMbdkmGXxjUBrtNcXQNawo = unscaledTime;
							}
							if (!MathTools.IsNear(jMseRrdpuRRriDIcGpZVGLkgPvNm, CTRjvHTJyWSmxiDUWDNBrXSnvmYh, 0.001f))
							{
								luwPdoYMAhnuKuRcpLEDuEKHMlaK = unscaledTime;
							}
						}
						else
						{
							if (!MathTools.Approximately(ANnyYrpgRHgHrBXsbJxMFrsUzupD, 0f))
							{
								lrnyFMqJOhGdqypSCULgMvObqwlD = unscaledTime;
							}
							else
							{
								GInkgXqMbdkmGXxjUBrtNcXQNawo = unscaledTime;
							}
							if (!MathTools.IsNear(ANnyYrpgRHgHrBXsbJxMFrsUzupD, QjjWsQqYUhMzHwtwGMfAFahPwrGs, 0.001f))
							{
								luwPdoYMAhnuKuRcpLEDuEKHMlaK = unscaledTime;
							}
						}
						if (!MathTools.Approximately(EaLuzdnyluVzMDFyakXGblUlRCOE, 0f))
						{
							FPBdsQMYRmtAvzxuEAsQbyCQixVQ = unscaledTime;
						}
						else
						{
							AgsxALBGlJLrzNZUtUJmfWuWvGoh = unscaledTime;
						}
						if (!MathTools.IsNear(EaLuzdnyluVzMDFyakXGblUlRCOE, roSImvvrwLGGUiJvXrNnBGnELHBO, 0.001f))
						{
							lamEDqHpfiBduZNUPqpZTXAngSKcb = unscaledTime;
						}
					}

					public void zJvKagiwtAtETmiHJiwfGqtOdpYc(float P_0)
					{
						if (roSImvvrwLGGUiJvXrNnBGnELHBO != EaLuzdnyluVzMDFyakXGblUlRCOE)
						{
							roSImvvrwLGGUiJvXrNnBGnELHBO = EaLuzdnyluVzMDFyakXGblUlRCOE;
						}
						if (EaLuzdnyluVzMDFyakXGblUlRCOE != P_0)
						{
							EaLuzdnyluVzMDFyakXGblUlRCOE = P_0;
						}
					}

					public override void XKZIxwRUwDpNhkICJrLjGrsjhGsn()
					{
						ANnyYrpgRHgHrBXsbJxMFrsUzupD = 0f;
						QjjWsQqYUhMzHwtwGMfAFahPwrGs = 0f;
						EaLuzdnyluVzMDFyakXGblUlRCOE = 0f;
						roSImvvrwLGGUiJvXrNnBGnELHBO = 0f;
						lrnyFMqJOhGdqypSCULgMvObqwlD = 0.0;
						FPBdsQMYRmtAvzxuEAsQbyCQixVQ = 0.0;
						GInkgXqMbdkmGXxjUBrtNcXQNawo = 0.0;
						AgsxALBGlJLrzNZUtUJmfWuWvGoh = 0.0;
						luwPdoYMAhnuKuRcpLEDuEKHMlaK = 0.0;
						lamEDqHpfiBduZNUPqpZTXAngSKcb = 0.0;
					}
				}

				public cklPQNOaXIKQaOQBXCuBvdPGDwaJ(UpdateLoopSetting P_0)
					: base(P_0)
				{
					for (int i = 0; i < JIHbTKaaZdviGYYaqiknPXfDmoRQ; i++)
					{
						xXHdCMSmsRUMaIpygCDYKFNDZyfr[i] = new dxMCrjXRuiWpmTVWOLwLPfcRAaVA();
					}
					yVsKAUWymJvXlLdJcirLAkYCwgyuA = xXHdCMSmsRUMaIpygCDYKFNDZyfr[0];
				}
			}

			internal readonly AxisRange FEoZycLNoSqbclpCafPqBZPZZDeCA;

			internal readonly HardwareAxisInfo wzuKsMAQzNUDQMPTfMKsvinBDhokA;

			public float value
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return 0f;
					}
					if (base.isMemberElement)
					{
						return ((cklPQNOaXIKQaOQBXCuBvdPGDwaJ.dxMCrjXRuiWpmTVWOLwLPfcRAaVA)MAFKTTDtKFthZPCHBEHSFPBJwyXr.yVsKAUWymJvXlLdJcirLAkYCwgyuA).jMseRrdpuRRriDIcGpZVGLkgPvNm;
					}
					return ((cklPQNOaXIKQaOQBXCuBvdPGDwaJ.dxMCrjXRuiWpmTVWOLwLPfcRAaVA)MAFKTTDtKFthZPCHBEHSFPBJwyXr.yVsKAUWymJvXlLdJcirLAkYCwgyuA).ANnyYrpgRHgHrBXsbJxMFrsUzupD;
				}
			}

			public float valuePrev
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return 0f;
					}
					if (base.isMemberElement)
					{
						return ((cklPQNOaXIKQaOQBXCuBvdPGDwaJ.dxMCrjXRuiWpmTVWOLwLPfcRAaVA)MAFKTTDtKFthZPCHBEHSFPBJwyXr.yVsKAUWymJvXlLdJcirLAkYCwgyuA).CTRjvHTJyWSmxiDUWDNBrXSnvmYh;
					}
					return ((cklPQNOaXIKQaOQBXCuBvdPGDwaJ.dxMCrjXRuiWpmTVWOLwLPfcRAaVA)MAFKTTDtKFthZPCHBEHSFPBJwyXr.yVsKAUWymJvXlLdJcirLAkYCwgyuA).QjjWsQqYUhMzHwtwGMfAFahPwrGs;
				}
			}

			public float valueRaw
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return 0f;
					}
					return ((cklPQNOaXIKQaOQBXCuBvdPGDwaJ.dxMCrjXRuiWpmTVWOLwLPfcRAaVA)MAFKTTDtKFthZPCHBEHSFPBJwyXr.yVsKAUWymJvXlLdJcirLAkYCwgyuA).EaLuzdnyluVzMDFyakXGblUlRCOE;
				}
				internal set
				{
					((cklPQNOaXIKQaOQBXCuBvdPGDwaJ.dxMCrjXRuiWpmTVWOLwLPfcRAaVA)MAFKTTDtKFthZPCHBEHSFPBJwyXr.yVsKAUWymJvXlLdJcirLAkYCwgyuA).zJvKagiwtAtETmiHJiwfGqtOdpYc(num);
				}
			}

			public float valueRawPrev
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return 0f;
					}
					return ((cklPQNOaXIKQaOQBXCuBvdPGDwaJ.dxMCrjXRuiWpmTVWOLwLPfcRAaVA)MAFKTTDtKFthZPCHBEHSFPBJwyXr.yVsKAUWymJvXlLdJcirLAkYCwgyuA).roSImvvrwLGGUiJvXrNnBGnELHBO;
				}
			}

			public float valueDelta
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return 0f;
					}
					return value - valuePrev;
				}
			}

			public float valueDeltaRaw
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return 0f;
					}
					return ((cklPQNOaXIKQaOQBXCuBvdPGDwaJ.dxMCrjXRuiWpmTVWOLwLPfcRAaVA)MAFKTTDtKFthZPCHBEHSFPBJwyXr.yVsKAUWymJvXlLdJcirLAkYCwgyuA).EaLuzdnyluVzMDFyakXGblUlRCOE - ((cklPQNOaXIKQaOQBXCuBvdPGDwaJ.dxMCrjXRuiWpmTVWOLwLPfcRAaVA)MAFKTTDtKFthZPCHBEHSFPBJwyXr.yVsKAUWymJvXlLdJcirLAkYCwgyuA).roSImvvrwLGGUiJvXrNnBGnELHBO;
				}
			}

			public double lastTimeActive
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return 0.0;
					}
					return ((cklPQNOaXIKQaOQBXCuBvdPGDwaJ.dxMCrjXRuiWpmTVWOLwLPfcRAaVA)MAFKTTDtKFthZPCHBEHSFPBJwyXr.yVsKAUWymJvXlLdJcirLAkYCwgyuA).lrnyFMqJOhGdqypSCULgMvObqwlD;
				}
			}

			public double lastTimeActiveRaw
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return 0.0;
					}
					return ((cklPQNOaXIKQaOQBXCuBvdPGDwaJ.dxMCrjXRuiWpmTVWOLwLPfcRAaVA)MAFKTTDtKFthZPCHBEHSFPBJwyXr.yVsKAUWymJvXlLdJcirLAkYCwgyuA).FPBdsQMYRmtAvzxuEAsQbyCQixVQ;
				}
			}

			public double lastTimeInactive
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return 0.0;
					}
					return ((cklPQNOaXIKQaOQBXCuBvdPGDwaJ.dxMCrjXRuiWpmTVWOLwLPfcRAaVA)MAFKTTDtKFthZPCHBEHSFPBJwyXr.yVsKAUWymJvXlLdJcirLAkYCwgyuA).GInkgXqMbdkmGXxjUBrtNcXQNawo;
				}
			}

			public double lastTimeInactiveRaw
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return 0.0;
					}
					return ((cklPQNOaXIKQaOQBXCuBvdPGDwaJ.dxMCrjXRuiWpmTVWOLwLPfcRAaVA)MAFKTTDtKFthZPCHBEHSFPBJwyXr.yVsKAUWymJvXlLdJcirLAkYCwgyuA).AgsxALBGlJLrzNZUtUJmfWuWvGoh;
				}
			}

			public double lastTimeValueChanged
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return 0.0;
					}
					return ((cklPQNOaXIKQaOQBXCuBvdPGDwaJ.dxMCrjXRuiWpmTVWOLwLPfcRAaVA)MAFKTTDtKFthZPCHBEHSFPBJwyXr.yVsKAUWymJvXlLdJcirLAkYCwgyuA).luwPdoYMAhnuKuRcpLEDuEKHMlaK;
				}
			}

			public double lastTimeValueChangedRaw
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return 0.0;
					}
					return ((cklPQNOaXIKQaOQBXCuBvdPGDwaJ.dxMCrjXRuiWpmTVWOLwLPfcRAaVA)MAFKTTDtKFthZPCHBEHSFPBJwyXr.yVsKAUWymJvXlLdJcirLAkYCwgyuA).lamEDqHpfiBduZNUPqpZTXAngSKcb;
				}
			}

			public double timeActive
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return 0.0;
					}
					return ((cklPQNOaXIKQaOQBXCuBvdPGDwaJ.dxMCrjXRuiWpmTVWOLwLPfcRAaVA)MAFKTTDtKFthZPCHBEHSFPBJwyXr.yVsKAUWymJvXlLdJcirLAkYCwgyuA).lcftwkkktEQTVpDOnKHlhrphhtSf;
				}
			}

			public double timeActiveRaw
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return 0.0;
					}
					return ((cklPQNOaXIKQaOQBXCuBvdPGDwaJ.dxMCrjXRuiWpmTVWOLwLPfcRAaVA)MAFKTTDtKFthZPCHBEHSFPBJwyXr.yVsKAUWymJvXlLdJcirLAkYCwgyuA).lcftwkkktEQTVpDOnKHlhrphhtSf;
				}
			}

			public double timeInactive
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return 0.0;
					}
					return ((cklPQNOaXIKQaOQBXCuBvdPGDwaJ.dxMCrjXRuiWpmTVWOLwLPfcRAaVA)MAFKTTDtKFthZPCHBEHSFPBJwyXr.yVsKAUWymJvXlLdJcirLAkYCwgyuA).rxNqrmTpgxDQHQremAuWFIRkPOzjb;
				}
			}

			public double timeInactiveRaw
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return 0.0;
					}
					return ((cklPQNOaXIKQaOQBXCuBvdPGDwaJ.dxMCrjXRuiWpmTVWOLwLPfcRAaVA)MAFKTTDtKFthZPCHBEHSFPBJwyXr.yVsKAUWymJvXlLdJcirLAkYCwgyuA).TMuDRVtzlxLmukDUzihXdSVxCQAe;
				}
			}

			public float pollingDeadZone
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return 0f;
					}
					if (wzuKsMAQzNUDQMPTfMKsvinBDhokA == null)
					{
						return -1f;
					}
					return wzuKsMAQzNUDQMPTfMKsvinBDhokA._pollingDeadZone;
				}
				set
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return;
					}
					if (value < 0f)
					{
						value = -1f;
					}
					if (wzuKsMAQzNUDQMPTfMKsvinBDhokA != null)
					{
						wzuKsMAQzNUDQMPTfMKsvinBDhokA._pollingDeadZone = value;
					}
				}
			}

			internal float CrDUdzDHuvzEiLncSTvnRIjixoVB => ((cklPQNOaXIKQaOQBXCuBvdPGDwaJ.dxMCrjXRuiWpmTVWOLwLPfcRAaVA)MAFKTTDtKFthZPCHBEHSFPBJwyXr.yVsKAUWymJvXlLdJcirLAkYCwgyuA).ANnyYrpgRHgHrBXsbJxMFrsUzupD;

			internal float ucsajTesUUjRtHFDHEulqVkSNpZF => ((cklPQNOaXIKQaOQBXCuBvdPGDwaJ.dxMCrjXRuiWpmTVWOLwLPfcRAaVA)MAFKTTDtKFthZPCHBEHSFPBJwyXr.yVsKAUWymJvXlLdJcirLAkYCwgyuA).QjjWsQqYUhMzHwtwGMfAFahPwrGs;

			internal float ZgDzvulGLNTUslBWphultbDIfPTbA
			{
				get
				{
					if (wzuKsMAQzNUDQMPTfMKsvinBDhokA == null)
					{
						return ReInput.configuration.defaultAbsoluteAxisPollingDeadZone;
					}
					if (wzuKsMAQzNUDQMPTfMKsvinBDhokA._pollingDeadZone >= 0f)
					{
						return wzuKsMAQzNUDQMPTfMKsvinBDhokA._pollingDeadZone;
					}
					switch (wzuKsMAQzNUDQMPTfMKsvinBDhokA._dataFormat)
					{
					case AxisCoordinateMode.Absolute:
						return ReInput.configuration.defaultAbsoluteAxisPollingDeadZone;
					case AxisCoordinateMode.Relative:
						return ReInput.configuration.defaultRelativeAxisPollingDeadZone;
					default:
						throw new NotImplementedException();
					}
				}
			}

			internal void HEFASHbJBgsLdcinaKMIMdiHBlhoB(float P_0)
			{
				cklPQNOaXIKQaOQBXCuBvdPGDwaJ.dxMCrjXRuiWpmTVWOLwLPfcRAaVA obj = (cklPQNOaXIKQaOQBXCuBvdPGDwaJ.dxMCrjXRuiWpmTVWOLwLPfcRAaVA)MAFKTTDtKFthZPCHBEHSFPBJwyXr.yVsKAUWymJvXlLdJcirLAkYCwgyuA;
				obj.CTRjvHTJyWSmxiDUWDNBrXSnvmYh = obj.jMseRrdpuRRriDIcGpZVGLkgPvNm;
				obj.jMseRrdpuRRriDIcGpZVGLkgPvNm = P_0;
			}

			internal Axis(Controller P_0, int P_1, string P_2, AxisRange P_3, HardwareAxisInfo P_4)
				: base(P_0, P_1, P_2, ControllerElementType.Axis)
			{
				MAFKTTDtKFthZPCHBEHSFPBJwyXr = new cklPQNOaXIKQaOQBXCuBvdPGDwaJ(ReInput.configVars.updateLoop);
				FEoZycLNoSqbclpCafPqBZPZZDeCA = P_3;
				wzuKsMAQzNUDQMPTfMKsvinBDhokA = P_4;
			}

			internal void qhCNQUlMGLLIPgePBqkGedEPhGYg(UpdateLoopType P_0)
			{
				if (MAFKTTDtKFthZPCHBEHSFPBJwyXr != null && MAFKTTDtKFthZPCHBEHSFPBJwyXr.IGKSYOGZfiVDBQWLCrQaskJlolZQ != (int)P_0)
				{
					MAFKTTDtKFthZPCHBEHSFPBJwyXr.duvdeoIMbviHBoTTDYZbkoEpbLKZA = P_0;
				}
			}

			internal void VtpmdwnYAwpChSOfbMtqwuzMOhPk(AxisCalibration P_0)
			{
				cklPQNOaXIKQaOQBXCuBvdPGDwaJ.dxMCrjXRuiWpmTVWOLwLPfcRAaVA dxMCrjXRuiWpmTVWOLwLPfcRAaVA = (cklPQNOaXIKQaOQBXCuBvdPGDwaJ.dxMCrjXRuiWpmTVWOLwLPfcRAaVA)MAFKTTDtKFthZPCHBEHSFPBJwyXr.yVsKAUWymJvXlLdJcirLAkYCwgyuA;
				dxMCrjXRuiWpmTVWOLwLPfcRAaVA.QjjWsQqYUhMzHwtwGMfAFahPwrGs = dxMCrjXRuiWpmTVWOLwLPfcRAaVA.ANnyYrpgRHgHrBXsbJxMFrsUzupD;
				float aNnyYrpgRHgHrBXsbJxMFrsUzupD = P_0.GetCalibratedValue(dxMCrjXRuiWpmTVWOLwLPfcRAaVA.EaLuzdnyluVzMDFyakXGblUlRCOE, FEoZycLNoSqbclpCafPqBZPZZDeCA);
				if (P_0.applyRangeCalibration)
				{
					aNnyYrpgRHgHrBXsbJxMFrsUzupD = MathTools.Clamp(aNnyYrpgRHgHrBXsbJxMFrsUzupD, -1f, 1f);
				}
				dxMCrjXRuiWpmTVWOLwLPfcRAaVA.ANnyYrpgRHgHrBXsbJxMFrsUzupD = aNnyYrpgRHgHrBXsbJxMFrsUzupD;
			}

			internal void VtpmdwnYAwpChSOfbMtqwuzMOhPk()
			{
				cklPQNOaXIKQaOQBXCuBvdPGDwaJ.dxMCrjXRuiWpmTVWOLwLPfcRAaVA obj = (cklPQNOaXIKQaOQBXCuBvdPGDwaJ.dxMCrjXRuiWpmTVWOLwLPfcRAaVA)MAFKTTDtKFthZPCHBEHSFPBJwyXr.yVsKAUWymJvXlLdJcirLAkYCwgyuA;
				obj.QjjWsQqYUhMzHwtwGMfAFahPwrGs = obj.ANnyYrpgRHgHrBXsbJxMFrsUzupD;
				obj.ANnyYrpgRHgHrBXsbJxMFrsUzupD = obj.EaLuzdnyluVzMDFyakXGblUlRCOE;
			}

			internal void mEsbEDfKPyrMtUZcuvMivoDicsiT()
			{
				cklPQNOaXIKQaOQBXCuBvdPGDwaJ.dxMCrjXRuiWpmTVWOLwLPfcRAaVA obj = (cklPQNOaXIKQaOQBXCuBvdPGDwaJ.dxMCrjXRuiWpmTVWOLwLPfcRAaVA)MAFKTTDtKFthZPCHBEHSFPBJwyXr.yVsKAUWymJvXlLdJcirLAkYCwgyuA;
				obj.QjjWsQqYUhMzHwtwGMfAFahPwrGs = obj.ANnyYrpgRHgHrBXsbJxMFrsUzupD;
				obj.ANnyYrpgRHgHrBXsbJxMFrsUzupD = 0f;
			}

			internal void sIOGygNROCkClWBkbMftmCyTcClfA()
			{
				((cklPQNOaXIKQaOQBXCuBvdPGDwaJ.dxMCrjXRuiWpmTVWOLwLPfcRAaVA)MAFKTTDtKFthZPCHBEHSFPBJwyXr.yVsKAUWymJvXlLdJcirLAkYCwgyuA).DsDuSUaDcVanpNAhDLIRqjKndMGi(base.isMemberElement);
			}

			internal void QXopNfOSeJvvIhfjEbnxxAqGFObj(float P_0)
			{
				for (int i = 0; i < MAFKTTDtKFthZPCHBEHSFPBJwyXr.vloZNCJrXgwGQjBcoFURMWIeizrF.Count; i++)
				{
					if (MAFKTTDtKFthZPCHBEHSFPBJwyXr.vloZNCJrXgwGQjBcoFURMWIeizrF[i] is cklPQNOaXIKQaOQBXCuBvdPGDwaJ.dxMCrjXRuiWpmTVWOLwLPfcRAaVA dxMCrjXRuiWpmTVWOLwLPfcRAaVA)
					{
						dxMCrjXRuiWpmTVWOLwLPfcRAaVA.zJvKagiwtAtETmiHJiwfGqtOdpYc(P_0);
						dxMCrjXRuiWpmTVWOLwLPfcRAaVA.QjjWsQqYUhMzHwtwGMfAFahPwrGs = dxMCrjXRuiWpmTVWOLwLPfcRAaVA.ANnyYrpgRHgHrBXsbJxMFrsUzupD;
						dxMCrjXRuiWpmTVWOLwLPfcRAaVA.ANnyYrpgRHgHrBXsbJxMFrsUzupD = 0f;
						dxMCrjXRuiWpmTVWOLwLPfcRAaVA.DsDuSUaDcVanpNAhDLIRqjKndMGi(base.isMemberElement);
					}
				}
			}

			internal float BjASuoyPygZcuHpmMKpNHUOtpLWB(UpdateLoopType P_0, AxisCalibration P_1)
			{
				cklPQNOaXIKQaOQBXCuBvdPGDwaJ.dxMCrjXRuiWpmTVWOLwLPfcRAaVA dxMCrjXRuiWpmTVWOLwLPfcRAaVA = (cklPQNOaXIKQaOQBXCuBvdPGDwaJ.dxMCrjXRuiWpmTVWOLwLPfcRAaVA)MAFKTTDtKFthZPCHBEHSFPBJwyXr.JscfZFutegiJlCAnblqEbxNhLhuWB(P_0);
				float result = P_1.GetCalibratedValue(dxMCrjXRuiWpmTVWOLwLPfcRAaVA.EaLuzdnyluVzMDFyakXGblUlRCOE, FEoZycLNoSqbclpCafPqBZPZZDeCA, P_1.deadZone, applySensitivity: false, applyInversion: true);
				if (P_1.applyRangeCalibration)
				{
					result = MathTools.Clamp(result, -1f, 1f);
				}
				return result;
			}
		}

		public sealed class Button : Element
		{
			internal class bKaIGZyrXUPUXaGXpIYrvDWPlvam : bCzQPMSObQgquQqCfeNwqjUaliPD
			{
				public class VPSvPmPHLwhnrjPyEkkMWTxIFcmGb : KwiLuaWUkeSzUUtwvSxftRjlPBLx
				{
					public bool ANnyYrpgRHgHrBXsbJxMFrsUzupD;

					public bool QjjWsQqYUhMzHwtwGMfAFahPwrGs;

					public ButtonStateRecorder YwfoUHlBPlBZsnJjAeLicclmOztgA;

					public mIOsnWAnJrZawLfJrxkYEEEUnPCt XLlpUXfFBknxHStwyiSnWCMaZmnu;

					public VPSvPmPHLwhnrjPyEkkMWTxIFcmGb()
					{
						YwfoUHlBPlBZsnJjAeLicclmOztgA = new ButtonStateRecorder();
						XLlpUXfFBknxHStwyiSnWCMaZmnu = new mIOsnWAnJrZawLfJrxkYEEEUnPCt(0.3f);
					}

					public void ZCYeQXTQlBeczBTsRNSgmJnLWcxf(bool P_0)
					{
						if (QjjWsQqYUhMzHwtwGMfAFahPwrGs != ANnyYrpgRHgHrBXsbJxMFrsUzupD)
						{
							QjjWsQqYUhMzHwtwGMfAFahPwrGs = ANnyYrpgRHgHrBXsbJxMFrsUzupD;
						}
						if (ANnyYrpgRHgHrBXsbJxMFrsUzupD != P_0)
						{
							ANnyYrpgRHgHrBXsbJxMFrsUzupD = P_0;
						}
						YwfoUHlBPlBZsnJjAeLicclmOztgA.DsDuSUaDcVanpNAhDLIRqjKndMGi(P_0 && !QjjWsQqYUhMzHwtwGMfAFahPwrGs, P_0, ReInput.unscaledTime);
						XLlpUXfFBknxHStwyiSnWCMaZmnu.DsDuSUaDcVanpNAhDLIRqjKndMGi(0.3f, P_0 && !QjjWsQqYUhMzHwtwGMfAFahPwrGs, P_0);
					}

					public override void XKZIxwRUwDpNhkICJrLjGrsjhGsn()
					{
						ANnyYrpgRHgHrBXsbJxMFrsUzupD = false;
						QjjWsQqYUhMzHwtwGMfAFahPwrGs = false;
						YwfoUHlBPlBZsnJjAeLicclmOztgA.XKZIxwRUwDpNhkICJrLjGrsjhGsn();
						XLlpUXfFBknxHStwyiSnWCMaZmnu.XKZIxwRUwDpNhkICJrLjGrsjhGsn();
					}
				}

				public class CSJfCSgDKYdLuwJHjmynQMLZTbLpA : VPSvPmPHLwhnrjPyEkkMWTxIFcmGb
				{
					public float fbPzHKqoZvBxzDmGFVENdLHjjqWZ;

					public float MdWFjbTOZLtIDcQsQzdhmaNsDXqR;

					public void ZCYeQXTQlBeczBTsRNSgmJnLWcxf(float P_0)
					{
						if (MdWFjbTOZLtIDcQsQzdhmaNsDXqR != fbPzHKqoZvBxzDmGFVENdLHjjqWZ)
						{
							MdWFjbTOZLtIDcQsQzdhmaNsDXqR = fbPzHKqoZvBxzDmGFVENdLHjjqWZ;
						}
						if (fbPzHKqoZvBxzDmGFVENdLHjjqWZ != P_0)
						{
							fbPzHKqoZvBxzDmGFVENdLHjjqWZ = ((P_0 > 0.001f) ? P_0 : 0f);
						}
						ZCYeQXTQlBeczBTsRNSgmJnLWcxf((fbPzHKqoZvBxzDmGFVENdLHjjqWZ > 0f) ? true : false);
					}

					public override void XKZIxwRUwDpNhkICJrLjGrsjhGsn()
					{
						base.XKZIxwRUwDpNhkICJrLjGrsjhGsn();
						fbPzHKqoZvBxzDmGFVENdLHjjqWZ = 0f;
						MdWFjbTOZLtIDcQsQzdhmaNsDXqR = 0f;
					}
				}

				public bKaIGZyrXUPUXaGXpIYrvDWPlvam(UpdateLoopSetting P_0, bool P_1)
					: base(P_0)
				{
					for (int i = 0; i < JIHbTKaaZdviGYYaqiknPXfDmoRQ; i++)
					{
						if (P_1)
						{
							xXHdCMSmsRUMaIpygCDYKFNDZyfr[i] = new CSJfCSgDKYdLuwJHjmynQMLZTbLpA();
						}
						else
						{
							xXHdCMSmsRUMaIpygCDYKFNDZyfr[i] = new VPSvPmPHLwhnrjPyEkkMWTxIFcmGb();
						}
					}
					yVsKAUWymJvXlLdJcirLAkYCwgyuA = xXHdCMSmsRUMaIpygCDYKFNDZyfr[0];
				}

				public void tgRiCDNIrCsQIUleqaQLTnaIoGxH(float P_0)
				{
					for (int i = 0; i < xXHdCMSmsRUMaIpygCDYKFNDZyfr.Length; i++)
					{
						((VPSvPmPHLwhnrjPyEkkMWTxIFcmGb)xXHdCMSmsRUMaIpygCDYKFNDZyfr[i]).XLlpUXfFBknxHStwyiSnWCMaZmnu.kDLllAvpMpIHTYguUxiGMlfqvNBm(P_0);
					}
				}

				public void DOQwzrfbZxknEJvYzmWDQqIAUDyM()
				{
					for (int i = 0; i < xXHdCMSmsRUMaIpygCDYKFNDZyfr.Length; i++)
					{
						((VPSvPmPHLwhnrjPyEkkMWTxIFcmGb)xXHdCMSmsRUMaIpygCDYKFNDZyfr[i]).XLlpUXfFBknxHStwyiSnWCMaZmnu.kDLllAvpMpIHTYguUxiGMlfqvNBm(0.3f);
					}
				}
			}

			internal readonly bool LnVSFlKTZmwohPFxdhRDYsrsZRDp;

			internal readonly HardwareButtonInfo QPRpOcJQwlEKkidErhOZRqEVdCmHA;

			public bool valuePrev
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return false;
					}
					return ((bKaIGZyrXUPUXaGXpIYrvDWPlvam.VPSvPmPHLwhnrjPyEkkMWTxIFcmGb)MAFKTTDtKFthZPCHBEHSFPBJwyXr.yVsKAUWymJvXlLdJcirLAkYCwgyuA).QjjWsQqYUhMzHwtwGMfAFahPwrGs;
				}
			}

			public bool value
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return false;
					}
					return ((bKaIGZyrXUPUXaGXpIYrvDWPlvam.VPSvPmPHLwhnrjPyEkkMWTxIFcmGb)MAFKTTDtKFthZPCHBEHSFPBJwyXr.yVsKAUWymJvXlLdJcirLAkYCwgyuA).ANnyYrpgRHgHrBXsbJxMFrsUzupD;
				}
			}

			public float pressure
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return 0f;
					}
					if (!LnVSFlKTZmwohPFxdhRDYsrsZRDp)
					{
						if (!((bKaIGZyrXUPUXaGXpIYrvDWPlvam.VPSvPmPHLwhnrjPyEkkMWTxIFcmGb)MAFKTTDtKFthZPCHBEHSFPBJwyXr.yVsKAUWymJvXlLdJcirLAkYCwgyuA).ANnyYrpgRHgHrBXsbJxMFrsUzupD)
						{
							return 0f;
						}
						return 1f;
					}
					return ((bKaIGZyrXUPUXaGXpIYrvDWPlvam.CSJfCSgDKYdLuwJHjmynQMLZTbLpA)MAFKTTDtKFthZPCHBEHSFPBJwyXr.yVsKAUWymJvXlLdJcirLAkYCwgyuA).fbPzHKqoZvBxzDmGFVENdLHjjqWZ;
				}
			}

			public float pressurePrev
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return 0f;
					}
					if (!LnVSFlKTZmwohPFxdhRDYsrsZRDp)
					{
						if (!((bKaIGZyrXUPUXaGXpIYrvDWPlvam.VPSvPmPHLwhnrjPyEkkMWTxIFcmGb)MAFKTTDtKFthZPCHBEHSFPBJwyXr.yVsKAUWymJvXlLdJcirLAkYCwgyuA).QjjWsQqYUhMzHwtwGMfAFahPwrGs)
						{
							return 0f;
						}
						return 1f;
					}
					return ((bKaIGZyrXUPUXaGXpIYrvDWPlvam.CSJfCSgDKYdLuwJHjmynQMLZTbLpA)MAFKTTDtKFthZPCHBEHSFPBJwyXr.yVsKAUWymJvXlLdJcirLAkYCwgyuA).MdWFjbTOZLtIDcQsQzdhmaNsDXqR;
				}
			}

			public bool isPressureSensitive
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return false;
					}
					return LnVSFlKTZmwohPFxdhRDYsrsZRDp;
				}
			}

			public bool justPressed
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return false;
					}
					if (!((bKaIGZyrXUPUXaGXpIYrvDWPlvam.VPSvPmPHLwhnrjPyEkkMWTxIFcmGb)MAFKTTDtKFthZPCHBEHSFPBJwyXr.yVsKAUWymJvXlLdJcirLAkYCwgyuA).QjjWsQqYUhMzHwtwGMfAFahPwrGs && ((bKaIGZyrXUPUXaGXpIYrvDWPlvam.VPSvPmPHLwhnrjPyEkkMWTxIFcmGb)MAFKTTDtKFthZPCHBEHSFPBJwyXr.yVsKAUWymJvXlLdJcirLAkYCwgyuA).ANnyYrpgRHgHrBXsbJxMFrsUzupD)
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
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return false;
					}
					if (((bKaIGZyrXUPUXaGXpIYrvDWPlvam.VPSvPmPHLwhnrjPyEkkMWTxIFcmGb)MAFKTTDtKFthZPCHBEHSFPBJwyXr.yVsKAUWymJvXlLdJcirLAkYCwgyuA).QjjWsQqYUhMzHwtwGMfAFahPwrGs && !((bKaIGZyrXUPUXaGXpIYrvDWPlvam.VPSvPmPHLwhnrjPyEkkMWTxIFcmGb)MAFKTTDtKFthZPCHBEHSFPBJwyXr.yVsKAUWymJvXlLdJcirLAkYCwgyuA).ANnyYrpgRHgHrBXsbJxMFrsUzupD)
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
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return false;
					}
					if (((bKaIGZyrXUPUXaGXpIYrvDWPlvam.VPSvPmPHLwhnrjPyEkkMWTxIFcmGb)MAFKTTDtKFthZPCHBEHSFPBJwyXr.yVsKAUWymJvXlLdJcirLAkYCwgyuA).QjjWsQqYUhMzHwtwGMfAFahPwrGs != ((bKaIGZyrXUPUXaGXpIYrvDWPlvam.VPSvPmPHLwhnrjPyEkkMWTxIFcmGb)MAFKTTDtKFthZPCHBEHSFPBJwyXr.yVsKAUWymJvXlLdJcirLAkYCwgyuA).ANnyYrpgRHgHrBXsbJxMFrsUzupD)
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
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return false;
					}
					return ((bKaIGZyrXUPUXaGXpIYrvDWPlvam.VPSvPmPHLwhnrjPyEkkMWTxIFcmGb)MAFKTTDtKFthZPCHBEHSFPBJwyXr.yVsKAUWymJvXlLdJcirLAkYCwgyuA).XLlpUXfFBknxHStwyiSnWCMaZmnu.VgpDWAJSavuBKMplIldajrchcasq;
				}
			}

			public bool justDoublePressed
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return false;
					}
					if (!justPressed)
					{
						return false;
					}
					return ((bKaIGZyrXUPUXaGXpIYrvDWPlvam.VPSvPmPHLwhnrjPyEkkMWTxIFcmGb)MAFKTTDtKFthZPCHBEHSFPBJwyXr.yVsKAUWymJvXlLdJcirLAkYCwgyuA).XLlpUXfFBknxHStwyiSnWCMaZmnu.VgpDWAJSavuBKMplIldajrchcasq;
				}
			}

			public double timePressed
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return 0.0;
					}
					return ((bKaIGZyrXUPUXaGXpIYrvDWPlvam.VPSvPmPHLwhnrjPyEkkMWTxIFcmGb)MAFKTTDtKFthZPCHBEHSFPBJwyXr.yVsKAUWymJvXlLdJcirLAkYCwgyuA).YwfoUHlBPlBZsnJjAeLicclmOztgA.GCStnPPBfYdkYEBgCVzpQfZMTMfmA;
				}
			}

			public double timeUnpressed
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return 0.0;
					}
					return ((bKaIGZyrXUPUXaGXpIYrvDWPlvam.VPSvPmPHLwhnrjPyEkkMWTxIFcmGb)MAFKTTDtKFthZPCHBEHSFPBJwyXr.yVsKAUWymJvXlLdJcirLAkYCwgyuA).YwfoUHlBPlBZsnJjAeLicclmOztgA.NcgLLvnBadcIfJgnSOAHLmpKYCOuA;
				}
			}

			public double lastTimePressed
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return 0.0;
					}
					return ((bKaIGZyrXUPUXaGXpIYrvDWPlvam.VPSvPmPHLwhnrjPyEkkMWTxIFcmGb)MAFKTTDtKFthZPCHBEHSFPBJwyXr.yVsKAUWymJvXlLdJcirLAkYCwgyuA).YwfoUHlBPlBZsnJjAeLicclmOztgA.jfWySEQRRhhsQNDOQvwEwceTEaED;
				}
			}

			public double lastTimeUnpressed
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return 0.0;
					}
					return ((bKaIGZyrXUPUXaGXpIYrvDWPlvam.VPSvPmPHLwhnrjPyEkkMWTxIFcmGb)MAFKTTDtKFthZPCHBEHSFPBJwyXr.yVsKAUWymJvXlLdJcirLAkYCwgyuA).YwfoUHlBPlBZsnJjAeLicclmOztgA.qwHnWwHVyuXWxNWIdhDoojGqsmv;
				}
			}

			public double lastTimeStateChanged
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return 0.0;
					}
					return ((bKaIGZyrXUPUXaGXpIYrvDWPlvam.VPSvPmPHLwhnrjPyEkkMWTxIFcmGb)MAFKTTDtKFthZPCHBEHSFPBJwyXr.yVsKAUWymJvXlLdJcirLAkYCwgyuA).YwfoUHlBPlBZsnJjAeLicclmOztgA.JsiWkhbzsoFamqDZOSOsqWDfmzcq;
				}
			}

			internal ButtonStateFlags eGnbpQDpxoxswhwDnqEOiknSUIYy
			{
				get
				{
					bKaIGZyrXUPUXaGXpIYrvDWPlvam.VPSvPmPHLwhnrjPyEkkMWTxIFcmGb vPSvPmPHLwhnrjPyEkkMWTxIFcmGb = (bKaIGZyrXUPUXaGXpIYrvDWPlvam.VPSvPmPHLwhnrjPyEkkMWTxIFcmGb)MAFKTTDtKFthZPCHBEHSFPBJwyXr.yVsKAUWymJvXlLdJcirLAkYCwgyuA;
					ButtonStateFlags buttonStateFlags = ButtonStateFlags.Off;
					if (vPSvPmPHLwhnrjPyEkkMWTxIFcmGb.ANnyYrpgRHgHrBXsbJxMFrsUzupD)
					{
						buttonStateFlags |= ButtonStateFlags.On;
						if (!vPSvPmPHLwhnrjPyEkkMWTxIFcmGb.QjjWsQqYUhMzHwtwGMfAFahPwrGs)
						{
							buttonStateFlags |= ButtonStateFlags.Down;
						}
					}
					else if (vPSvPmPHLwhnrjPyEkkMWTxIFcmGb.QjjWsQqYUhMzHwtwGMfAFahPwrGs)
					{
						buttonStateFlags |= ButtonStateFlags.Up;
					}
					return buttonStateFlags;
				}
			}

			internal Button(Controller P_0, int P_1, string P_2, HardwareButtonInfo P_3)
				: base(P_0, P_1, P_2, ControllerElementType.Button)
			{
				QPRpOcJQwlEKkidErhOZRqEVdCmHA = P_3;
				MAFKTTDtKFthZPCHBEHSFPBJwyXr = new bKaIGZyrXUPUXaGXpIYrvDWPlvam(ReInput.configVars.updateLoop, false);
			}

			internal Button(Controller P_0, int P_1, string P_2, bool P_3, HardwareButtonInfo P_4)
				: base(P_0, P_1, P_2, ControllerElementType.Button)
			{
				QPRpOcJQwlEKkidErhOZRqEVdCmHA = P_4;
				LnVSFlKTZmwohPFxdhRDYsrsZRDp = P_3;
				MAFKTTDtKFthZPCHBEHSFPBJwyXr = new bKaIGZyrXUPUXaGXpIYrvDWPlvam(ReInput.configVars.updateLoop, P_3);
			}

			public bool DoublePressedAndHeld(float speed)
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return false;
				}
				if (speed <= 0f)
				{
					return ((bKaIGZyrXUPUXaGXpIYrvDWPlvam.VPSvPmPHLwhnrjPyEkkMWTxIFcmGb)MAFKTTDtKFthZPCHBEHSFPBJwyXr.yVsKAUWymJvXlLdJcirLAkYCwgyuA).XLlpUXfFBknxHStwyiSnWCMaZmnu.VgpDWAJSavuBKMplIldajrchcasq;
				}
				return ((bKaIGZyrXUPUXaGXpIYrvDWPlvam.VPSvPmPHLwhnrjPyEkkMWTxIFcmGb)MAFKTTDtKFthZPCHBEHSFPBJwyXr.yVsKAUWymJvXlLdJcirLAkYCwgyuA).YwfoUHlBPlBZsnJjAeLicclmOztgA.HICruJXHacoZmcqmePbhzrSGIqmC(speed);
			}

			public bool JustDoublePressed(float speed)
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return false;
				}
				if (!justPressed)
				{
					return false;
				}
				if (speed <= 0f)
				{
					return ((bKaIGZyrXUPUXaGXpIYrvDWPlvam.VPSvPmPHLwhnrjPyEkkMWTxIFcmGb)MAFKTTDtKFthZPCHBEHSFPBJwyXr.yVsKAUWymJvXlLdJcirLAkYCwgyuA).XLlpUXfFBknxHStwyiSnWCMaZmnu.VgpDWAJSavuBKMplIldajrchcasq;
				}
				return ((bKaIGZyrXUPUXaGXpIYrvDWPlvam.VPSvPmPHLwhnrjPyEkkMWTxIFcmGb)MAFKTTDtKFthZPCHBEHSFPBJwyXr.yVsKAUWymJvXlLdJcirLAkYCwgyuA).YwfoUHlBPlBZsnJjAeLicclmOztgA.HICruJXHacoZmcqmePbhzrSGIqmC(speed);
			}

			internal void ZCYeQXTQlBeczBTsRNSgmJnLWcxf(UpdateLoopType P_0, int P_1, ControllerDataUpdater P_2)
			{
				if (MAFKTTDtKFthZPCHBEHSFPBJwyXr != null && MAFKTTDtKFthZPCHBEHSFPBJwyXr.IGKSYOGZfiVDBQWLCrQaskJlolZQ != (int)P_0)
				{
					MAFKTTDtKFthZPCHBEHSFPBJwyXr.duvdeoIMbviHBoTTDYZbkoEpbLKZA = P_0;
				}
				if (LnVSFlKTZmwohPFxdhRDYsrsZRDp)
				{
					((bKaIGZyrXUPUXaGXpIYrvDWPlvam.CSJfCSgDKYdLuwJHjmynQMLZTbLpA)MAFKTTDtKFthZPCHBEHSFPBJwyXr.yVsKAUWymJvXlLdJcirLAkYCwgyuA).ZCYeQXTQlBeczBTsRNSgmJnLWcxf(P_2.buttonPressureValues[P_1]);
				}
				else
				{
					((bKaIGZyrXUPUXaGXpIYrvDWPlvam.VPSvPmPHLwhnrjPyEkkMWTxIFcmGb)MAFKTTDtKFthZPCHBEHSFPBJwyXr.yVsKAUWymJvXlLdJcirLAkYCwgyuA).ZCYeQXTQlBeczBTsRNSgmJnLWcxf(P_2.buttonValues[P_1]);
				}
			}

			internal void KeggwlnEVkAAffiNsiwTBJexzjdo(UpdateLoopType P_0)
			{
				if (MAFKTTDtKFthZPCHBEHSFPBJwyXr != null && MAFKTTDtKFthZPCHBEHSFPBJwyXr.IGKSYOGZfiVDBQWLCrQaskJlolZQ != (int)P_0)
				{
					MAFKTTDtKFthZPCHBEHSFPBJwyXr.duvdeoIMbviHBoTTDYZbkoEpbLKZA = P_0;
				}
				if (LnVSFlKTZmwohPFxdhRDYsrsZRDp)
				{
					((bKaIGZyrXUPUXaGXpIYrvDWPlvam.CSJfCSgDKYdLuwJHjmynQMLZTbLpA)MAFKTTDtKFthZPCHBEHSFPBJwyXr.yVsKAUWymJvXlLdJcirLAkYCwgyuA).ZCYeQXTQlBeczBTsRNSgmJnLWcxf(0f);
				}
				else
				{
					((bKaIGZyrXUPUXaGXpIYrvDWPlvam.VPSvPmPHLwhnrjPyEkkMWTxIFcmGb)MAFKTTDtKFthZPCHBEHSFPBJwyXr.yVsKAUWymJvXlLdJcirLAkYCwgyuA).ZCYeQXTQlBeczBTsRNSgmJnLWcxf(false);
				}
			}

			internal void QXopNfOSeJvvIhfjEbnxxAqGFObj()
			{
				for (int i = 0; i < MAFKTTDtKFthZPCHBEHSFPBJwyXr.vloZNCJrXgwGQjBcoFURMWIeizrF.Count; i++)
				{
					bCzQPMSObQgquQqCfeNwqjUaliPD.KwiLuaWUkeSzUUtwvSxftRjlPBLx kwiLuaWUkeSzUUtwvSxftRjlPBLx = MAFKTTDtKFthZPCHBEHSFPBJwyXr.vloZNCJrXgwGQjBcoFURMWIeizrF[i];
					if (kwiLuaWUkeSzUUtwvSxftRjlPBLx != null)
					{
						if (LnVSFlKTZmwohPFxdhRDYsrsZRDp)
						{
							((bKaIGZyrXUPUXaGXpIYrvDWPlvam.CSJfCSgDKYdLuwJHjmynQMLZTbLpA)kwiLuaWUkeSzUUtwvSxftRjlPBLx).ZCYeQXTQlBeczBTsRNSgmJnLWcxf(0f);
						}
						else
						{
							((bKaIGZyrXUPUXaGXpIYrvDWPlvam.VPSvPmPHLwhnrjPyEkkMWTxIFcmGb)kwiLuaWUkeSzUUtwvSxftRjlPBLx).ZCYeQXTQlBeczBTsRNSgmJnLWcxf(false);
						}
					}
				}
			}
		}

		public abstract class CompoundElement
		{
			private class qkRhbTnKYzGvELQaNCKuuXBafqcY
			{
				public readonly Element ooBBgkcWWsMagjYtYbeirjkcGey;

				public readonly int JnaqnwUXKgDmJYmGIqyOLHqXtkYU;

				public qkRhbTnKYzGvELQaNCKuuXBafqcY(Element P_0, int P_1)
				{
					ooBBgkcWWsMagjYtYbeirjkcGey = P_0;
					JnaqnwUXKgDmJYmGIqyOLHqXtkYU = P_1;
				}
			}

			private int hkJhlFMpiETPSIkMyOmVuFxkJKlT;

			private string XXuYUuZFvXwuYxiNryIOxzHdIWPU;

			private CompoundControllerElementType pAOXgcmMCoVFqTMkLWvqHBZrtkmI;

			private int ZOCgxXUKNFOfHISNXZmxfalgnLaA;

			private qkRhbTnKYzGvELQaNCKuuXBafqcY[] YWqICyZAZaepLWeAIxsfAwguINSd;

			private Controller SHugpoIFWkCnojYBXWjOaAoAAYCW;

			internal readonly int oLUDKIBSDOGsiswKzVsPEXOleBcs;

			public int id
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return -1;
					}
					return hkJhlFMpiETPSIkMyOmVuFxkJKlT;
				}
			}

			public string name
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return string.Empty;
					}
					return XXuYUuZFvXwuYxiNryIOxzHdIWPU;
				}
			}

			public CompoundControllerElementType type
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return CompoundControllerElementType.Axis2D;
					}
					return pAOXgcmMCoVFqTMkLWvqHBZrtkmI;
				}
			}

			public bool hasElements
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return false;
					}
					return ZOCgxXUKNFOfHISNXZmxfalgnLaA > 0;
				}
			}

			public int elementCount
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return 0;
					}
					return ZOCgxXUKNFOfHISNXZmxfalgnLaA;
				}
			}

			public abstract int elementCapacity { get; }

			public ControllerElementIdentifier elementIdentifier
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return null;
					}
					ControllerElementIdentifier elementIdentifierById = SHugpoIFWkCnojYBXWjOaAoAAYCW.GetElementIdentifierById(hkJhlFMpiETPSIkMyOmVuFxkJKlT);
					if (elementIdentifierById == null)
					{
						return ControllerElementIdentifier.BlankReadOnly;
					}
					return elementIdentifierById;
				}
			}

			internal CompoundElement(Controller P_0, int P_1, string P_2, CompoundControllerElementType P_3)
			{
				SHugpoIFWkCnojYBXWjOaAoAAYCW = P_0;
				hkJhlFMpiETPSIkMyOmVuFxkJKlT = P_1;
				XXuYUuZFvXwuYxiNryIOxzHdIWPU = P_2;
				pAOXgcmMCoVFqTMkLWvqHBZrtkmI = P_3;
				YWqICyZAZaepLWeAIxsfAwguINSd = new qkRhbTnKYzGvELQaNCKuuXBafqcY[elementCapacity];
				oLUDKIBSDOGsiswKzVsPEXOleBcs = ReInput.id;
			}

			internal Element TIxnSRhPSalQFvQOFZaLLiQtwMIC(int P_0)
			{
				if (P_0 < 0 || P_0 >= YWqICyZAZaepLWeAIxsfAwguINSd.Length)
				{
					return null;
				}
				if (YWqICyZAZaepLWeAIxsfAwguINSd[P_0] == null)
				{
					return null;
				}
				return YWqICyZAZaepLWeAIxsfAwguINSd[P_0].ooBBgkcWWsMagjYtYbeirjkcGey;
			}

			internal _0001 TIxnSRhPSalQFvQOFZaLLiQtwMIC<_0001>(int P_0) where _0001 : Element
			{
				if (P_0 < 0 || P_0 >= YWqICyZAZaepLWeAIxsfAwguINSd.Length)
				{
					return null;
				}
				if (YWqICyZAZaepLWeAIxsfAwguINSd[P_0] == null)
				{
					return null;
				}
				return YWqICyZAZaepLWeAIxsfAwguINSd[P_0].ooBBgkcWWsMagjYtYbeirjkcGey as _0001;
			}

			internal _0001 FwdLdsiXfyiALutKEPVeifcctKJH<_0001>(int P_0, out int P_1) where _0001 : Element
			{
				P_1 = -1;
				if (P_0 < 0 || P_0 >= YWqICyZAZaepLWeAIxsfAwguINSd.Length)
				{
					return null;
				}
				if (YWqICyZAZaepLWeAIxsfAwguINSd[P_0] == null)
				{
					return null;
				}
				P_1 = YWqICyZAZaepLWeAIxsfAwguINSd[P_0].JnaqnwUXKgDmJYmGIqyOLHqXtkYU;
				return YWqICyZAZaepLWeAIxsfAwguINSd[P_0].ooBBgkcWWsMagjYtYbeirjkcGey as _0001;
			}

			internal bool noRZOaiqNhQVUigJbcItGViYdGAm(Element P_0, int P_1)
			{
				if (P_0 == null)
				{
					return false;
				}
				if (ZOCgxXUKNFOfHISNXZmxfalgnLaA >= elementCapacity)
				{
					Logger.LogWarning("Cannot add element! This Compound Element already contains the maximum number of elements.");
					return false;
				}
				if (P_0.isMemberElement)
				{
					Logger.LogWarning("Cannot add element! The element you are trying to add is already a member of another compound element.");
					return false;
				}
				if (IjVLBlIflGUpoVVgJIgDNCxTxwtM(P_0) >= 0)
				{
					Logger.LogWarning("Cannot add element! This Compound Element already contains the element you are trying to add.");
					return false;
				}
				int num = suHGVdsWmhAWliQWzmVDPMtOEiQfA();
				if (num < 0)
				{
					Logger.LogWarning("Cannot add element! This Compound Element already contains the maximum number of elements.");
					return false;
				}
				return UMmpbgrJpphQAatWDDBnbVPAKXFic(P_0, P_1, num);
			}

			internal bool PKNjZCJgzqgqDcnXSpOwnWuGtFzD(Element P_0)
			{
				if (P_0 == null)
				{
					return false;
				}
				if (ZOCgxXUKNFOfHISNXZmxfalgnLaA == 0)
				{
					Logger.LogWarning("Cannot remove element! This Compound Element has no elements.");
					return false;
				}
				int num = IjVLBlIflGUpoVVgJIgDNCxTxwtM(P_0);
				if (num < 0)
				{
					Logger.LogWarning("Cannot remove element! This Compound Element does not contain the element you are trying to remove.");
					return false;
				}
				return nZYcmfQZVTKndOUyzmiJPhjzEQxC(num);
			}

			internal void LxYSXBGcAIOSeQbCEhTQaFmlFjHX()
			{
				for (int i = 0; i < YWqICyZAZaepLWeAIxsfAwguINSd.Length; i++)
				{
					nZYcmfQZVTKndOUyzmiJPhjzEQxC(i);
				}
				ZOCgxXUKNFOfHISNXZmxfalgnLaA = 0;
			}

			private int IjVLBlIflGUpoVVgJIgDNCxTxwtM(Element P_0)
			{
				if (P_0 == null)
				{
					return -1;
				}
				for (int i = 0; i < YWqICyZAZaepLWeAIxsfAwguINSd.Length; i++)
				{
					if (YWqICyZAZaepLWeAIxsfAwguINSd[i] != null && YWqICyZAZaepLWeAIxsfAwguINSd[i].ooBBgkcWWsMagjYtYbeirjkcGey == P_0)
					{
						return i;
					}
				}
				return -1;
			}

			private bool UMmpbgrJpphQAatWDDBnbVPAKXFic(Element P_0, int P_1, int P_2)
			{
				if (P_2 < 0 || P_2 >= YWqICyZAZaepLWeAIxsfAwguINSd.Length)
				{
					return false;
				}
				if (YWqICyZAZaepLWeAIxsfAwguINSd[P_2] != null)
				{
					return false;
				}
				YWqICyZAZaepLWeAIxsfAwguINSd[P_2] = new qkRhbTnKYzGvELQaNCKuuXBafqcY(P_0, P_1);
				P_0.AixbJlgLwUhdFLjrBmsVWHQdaYGD(this);
				ZOCgxXUKNFOfHISNXZmxfalgnLaA++;
				return true;
			}

			private bool nZYcmfQZVTKndOUyzmiJPhjzEQxC(int P_0)
			{
				if (P_0 < 0 || P_0 >= YWqICyZAZaepLWeAIxsfAwguINSd.Length)
				{
					return false;
				}
				if (YWqICyZAZaepLWeAIxsfAwguINSd[P_0] == null)
				{
					return false;
				}
				if (YWqICyZAZaepLWeAIxsfAwguINSd[P_0].ooBBgkcWWsMagjYtYbeirjkcGey != null)
				{
					YWqICyZAZaepLWeAIxsfAwguINSd[P_0].ooBBgkcWWsMagjYtYbeirjkcGey.pxTcGadawijIAsKsGfnWgtQHrCPfb(this);
				}
				YWqICyZAZaepLWeAIxsfAwguINSd[P_0] = null;
				ZOCgxXUKNFOfHISNXZmxfalgnLaA--;
				return true;
			}

			private int suHGVdsWmhAWliQWzmVDPMtOEiQfA()
			{
				for (int i = 0; i < YWqICyZAZaepLWeAIxsfAwguINSd.Length; i++)
				{
					if (YWqICyZAZaepLWeAIxsfAwguINSd[i] == null)
					{
						return i;
					}
				}
				return -1;
			}
		}

		public sealed class Axis2D : CompoundElement
		{
			private const int VotCocNhAwxUcbmDkfURCoTBpuuL = 2;

			private CalibrationMap sCDkgqtOpokMGswOhxWixSauUyRL;

			public override int elementCapacity => 2;

			public Axis xAxis
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return null;
					}
					return TIxnSRhPSalQFvQOFZaLLiQtwMIC<Axis>(0);
				}
			}

			public Axis yAxis
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return null;
					}
					return TIxnSRhPSalQFvQOFZaLLiQtwMIC<Axis>(1);
				}
			}

			public Vector2 value
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return Vector2.zero;
					}
					return vYqDqYGKKpztZszgxoZpchYSRaBtA();
				}
			}

			public Vector2 valuePrev
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return Vector2.zero;
					}
					return xQNEIxUqELafbcBieagJIEfgEHoHB();
				}
			}

			public Vector2 valueRaw
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return Vector2.zero;
					}
					return new Vector2((xAxis != null) ? xAxis.valueRaw : 0f, (yAxis != null) ? yAxis.valueRaw : 0f);
				}
			}

			public Vector2 valueRawPrev
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return Vector2.zero;
					}
					return new Vector2((xAxis != null) ? xAxis.valueRawPrev : 0f, (yAxis != null) ? yAxis.valueRawPrev : 0f);
				}
			}

			internal Axis2D(Controller P_0, int P_1, string P_2, Axis P_3, Axis P_4, int P_5, int P_6, CalibrationMap P_7)
				: base(P_0, P_1, P_2, CompoundControllerElementType.Axis2D)
			{
				noRZOaiqNhQVUigJbcItGViYdGAm(P_3, P_5);
				noRZOaiqNhQVUigJbcItGViYdGAm(P_4, P_6);
				sCDkgqtOpokMGswOhxWixSauUyRL = P_7;
			}

			internal void sboEOQazNCgVCSWpNHHosMaWIvev()
			{
				Vector2 vector = value;
				if (xAxis != null)
				{
					xAxis.HEFASHbJBgsLdcinaKMIMdiHBlhoB(vector.x);
				}
				if (yAxis != null)
				{
					yAxis.HEFASHbJBgsLdcinaKMIMdiHBlhoB(vector.y);
				}
			}

			private Vector2 vYqDqYGKKpztZszgxoZpchYSRaBtA()
			{
				if (sCDkgqtOpokMGswOhxWixSauUyRL == null)
				{
					return default(Vector2);
				}
				int xAxisIndex;
				Axis axis = FwdLdsiXfyiALutKEPVeifcctKJH<Axis>(0, out xAxisIndex);
				int yAxisIndex;
				Axis axis2 = FwdLdsiXfyiALutKEPVeifcctKJH<Axis>(1, out yAxisIndex);
				DeadZone2DType defaultJoystickAxis2DDeadZoneType = ReInput.configVars.defaultJoystickAxis2DDeadZoneType;
				AxisSensitivity2DType defaultJoystickAxis2DSensitivityType = ReInput.configVars.defaultJoystickAxis2DSensitivityType;
				float valueRawX = axis?.valueRaw ?? 0f;
				float valueRawY = axis2?.valueRaw ?? 0f;
				return sCDkgqtOpokMGswOhxWixSauUyRL.GetCalibrated2DValue(xAxisIndex, yAxisIndex, valueRawX, valueRawY, defaultJoystickAxis2DDeadZoneType, defaultJoystickAxis2DSensitivityType);
			}

			private Vector2 xQNEIxUqELafbcBieagJIEfgEHoHB()
			{
				if (sCDkgqtOpokMGswOhxWixSauUyRL == null)
				{
					return default(Vector2);
				}
				int xAxisIndex;
				Axis axis = FwdLdsiXfyiALutKEPVeifcctKJH<Axis>(0, out xAxisIndex);
				int yAxisIndex;
				Axis axis2 = FwdLdsiXfyiALutKEPVeifcctKJH<Axis>(1, out yAxisIndex);
				DeadZone2DType defaultJoystickAxis2DDeadZoneType = ReInput.configVars.defaultJoystickAxis2DDeadZoneType;
				AxisSensitivity2DType defaultJoystickAxis2DSensitivityType = ReInput.configVars.defaultJoystickAxis2DSensitivityType;
				float valueRawX = axis?.valueRawPrev ?? 0f;
				float valueRawY = axis2?.valueRawPrev ?? 0f;
				return sCDkgqtOpokMGswOhxWixSauUyRL.GetCalibrated2DValue(xAxisIndex, yAxisIndex, valueRawX, valueRawY, defaultJoystickAxis2DDeadZoneType, defaultJoystickAxis2DSensitivityType);
			}
		}

		public sealed class Hat : CompoundElement
		{
			private const int VotCocNhAwxUcbmDkfURCoTBpuuL = 8;

			private const int sxQoZaxExQZZJFdhedGqyFIKcLJA = 0;

			private const int RWptDwMeCPFfAgFLXjbHrZUgeBwWA = 1;

			private const int uZuAbTsPdKeXPjHxtJUOsoKtbMgR = 2;

			private const int ZLcmLyaEsaDJZduSbObuNCQLoZMLA = 3;

			private const int wKMNhkOPCZbveSsgxNOeQSkGxZuC = 4;

			private const int ifGShDynKmEzOCuqGPXlQwwXQpwOA = 5;

			private const int sYkGykeAuixxoUzvVgOhjemjOlSd = 6;

			private const int TSMFICxJmCwisydfqsaUgNlsajaY = 7;

			private readonly int sqOAjqiYgpyrLlQchddtcgIsmpGfb;

			private readonly Button[] cmXHQZIxDUukeRCdGAxvuSrRrVmb;

			private readonly ReadOnlyCollection<Button> DxROtMZmBIsNhQfAvCgmHHOWfMxdA;

			private readonly int[] WCuInoEcLZttpWVVGrniLfYkGbZdA;

			private bool ihfKMjMCGVkcKOJpECUjczLvKpstA;

			public override int elementCapacity => 8;

			public bool force4Way
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return false;
					}
					return ihfKMjMCGVkcKOJpECUjczLvKpstA;
				}
				set
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					}
					else
					{
						ihfKMjMCGVkcKOJpECUjczLvKpstA = value;
					}
				}
			}

			public int directionCount
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return 0;
					}
					return sqOAjqiYgpyrLlQchddtcgIsmpGfb;
				}
			}

			public IList<Button> Buttons
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return EmptyObjects<Button>.EmptyReadOnlyIListT;
					}
					return DxROtMZmBIsNhQfAvCgmHHOWfMxdA;
				}
			}

			public Button buttonUp
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return null;
					}
					return TIxnSRhPSalQFvQOFZaLLiQtwMIC<Button>(0);
				}
			}

			public Button buttonRight
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return null;
					}
					return TIxnSRhPSalQFvQOFZaLLiQtwMIC<Button>(2);
				}
			}

			public Button buttonDown
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return null;
					}
					return TIxnSRhPSalQFvQOFZaLLiQtwMIC<Button>(4);
				}
			}

			public Button buttonLeft
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return null;
					}
					return TIxnSRhPSalQFvQOFZaLLiQtwMIC<Button>(6);
				}
			}

			public Button buttonUpRight
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return null;
					}
					return TIxnSRhPSalQFvQOFZaLLiQtwMIC<Button>(1);
				}
			}

			public Button buttonDownRight
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return null;
					}
					return TIxnSRhPSalQFvQOFZaLLiQtwMIC<Button>(3);
				}
			}

			public Button buttonDownLeft
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return null;
					}
					return TIxnSRhPSalQFvQOFZaLLiQtwMIC<Button>(5);
				}
			}

			public Button buttonUpLeft
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return null;
					}
					return TIxnSRhPSalQFvQOFZaLLiQtwMIC<Button>(7);
				}
			}

			internal Hat(Controller P_0, int P_1, string P_2, Button[] P_3, int[] P_4)
				: base(P_0, P_1, P_2, CompoundControllerElementType.Hat)
			{
				int num = ((P_3 != null) ? P_3.Length : 0);
				if (num != ((P_4 != null) ? P_4.Length : 0))
				{
					throw new ArgumentException("buttons.Length must equal buttonIndices.Length!");
				}
				if (num != 0 && num != 4 && num != 8)
				{
					throw new ArgumentException("buttons.Length must be 0, 4, or 8! Length: " + num);
				}
				for (int i = 0; i < num; i++)
				{
					noRZOaiqNhQVUigJbcItGViYdGAm(P_3[i], P_4[i]);
				}
				cmXHQZIxDUukeRCdGAxvuSrRrVmb = P_3;
				WCuInoEcLZttpWVVGrniLfYkGbZdA = P_4;
				sqOAjqiYgpyrLlQchddtcgIsmpGfb = num;
				DxROtMZmBIsNhQfAvCgmHHOWfMxdA = new ReadOnlyCollection<Button>(P_3);
			}

			internal void sboEOQazNCgVCSWpNHHosMaWIvev(UpdateLoopType P_0, ControllerDataUpdater P_1)
			{
				if (sqOAjqiYgpyrLlQchddtcgIsmpGfb == 0)
				{
					return;
				}
				if (sqOAjqiYgpyrLlQchddtcgIsmpGfb == 8 && (ihfKMjMCGVkcKOJpECUjczLvKpstA || ReInput.configVars.force4WayHats))
				{
					ZedhhUygFFOXUakfVQdOMmEBbDCf(cmXHQZIxDUukeRCdGAxvuSrRrVmb[0], WCuInoEcLZttpWVVGrniLfYkGbZdA[0], WCuInoEcLZttpWVVGrniLfYkGbZdA[7], WCuInoEcLZttpWVVGrniLfYkGbZdA[1], P_0, P_1);
					ZedhhUygFFOXUakfVQdOMmEBbDCf(cmXHQZIxDUukeRCdGAxvuSrRrVmb[2], WCuInoEcLZttpWVVGrniLfYkGbZdA[2], WCuInoEcLZttpWVVGrniLfYkGbZdA[1], WCuInoEcLZttpWVVGrniLfYkGbZdA[3], P_0, P_1);
					ZedhhUygFFOXUakfVQdOMmEBbDCf(cmXHQZIxDUukeRCdGAxvuSrRrVmb[4], WCuInoEcLZttpWVVGrniLfYkGbZdA[4], WCuInoEcLZttpWVVGrniLfYkGbZdA[5], WCuInoEcLZttpWVVGrniLfYkGbZdA[3], P_0, P_1);
					ZedhhUygFFOXUakfVQdOMmEBbDCf(cmXHQZIxDUukeRCdGAxvuSrRrVmb[6], WCuInoEcLZttpWVVGrniLfYkGbZdA[6], WCuInoEcLZttpWVVGrniLfYkGbZdA[5], WCuInoEcLZttpWVVGrniLfYkGbZdA[7], P_0, P_1);
					SQdszfohykDYSKGsbQeoKAglPzvi(cmXHQZIxDUukeRCdGAxvuSrRrVmb[1], WCuInoEcLZttpWVVGrniLfYkGbZdA[1], P_0, P_1);
					SQdszfohykDYSKGsbQeoKAglPzvi(cmXHQZIxDUukeRCdGAxvuSrRrVmb[3], WCuInoEcLZttpWVVGrniLfYkGbZdA[3], P_0, P_1);
					SQdszfohykDYSKGsbQeoKAglPzvi(cmXHQZIxDUukeRCdGAxvuSrRrVmb[5], WCuInoEcLZttpWVVGrniLfYkGbZdA[5], P_0, P_1);
					SQdszfohykDYSKGsbQeoKAglPzvi(cmXHQZIxDUukeRCdGAxvuSrRrVmb[7], WCuInoEcLZttpWVVGrniLfYkGbZdA[7], P_0, P_1);
					return;
				}
				for (int i = 0; i < cmXHQZIxDUukeRCdGAxvuSrRrVmb.Length; i++)
				{
					if (cmXHQZIxDUukeRCdGAxvuSrRrVmb[i] != null)
					{
						cmXHQZIxDUukeRCdGAxvuSrRrVmb[i].ZCYeQXTQlBeczBTsRNSgmJnLWcxf(P_0, WCuInoEcLZttpWVVGrniLfYkGbZdA[i], P_1);
					}
				}
			}

			private void ZedhhUygFFOXUakfVQdOMmEBbDCf(Button P_0, int P_1, int P_2, int P_3, UpdateLoopType P_4, ControllerDataUpdater P_5)
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
				P_0.ZCYeQXTQlBeczBTsRNSgmJnLWcxf(P_4, P_1, P_5);
			}

			private void SQdszfohykDYSKGsbQeoKAglPzvi(Button P_0, int P_1, UpdateLoopType P_2, ControllerDataUpdater P_3)
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
					P_0.ZCYeQXTQlBeczBTsRNSgmJnLWcxf(P_2, P_1, P_3);
				}
			}
		}

		public sealed class DirectionalPad : CompoundElement
		{
			private const int VotCocNhAwxUcbmDkfURCoTBpuuL = 4;

			private const int sxQoZaxExQZZJFdhedGqyFIKcLJA = 0;

			private const int uZuAbTsPdKeXPjHxtJUOsoKtbMgR = 1;

			private const int wKMNhkOPCZbveSsgxNOeQSkGxZuC = 2;

			private const int sYkGykeAuixxoUzvVgOhjemjOlSd = 3;

			private readonly int sqOAjqiYgpyrLlQchddtcgIsmpGfb;

			private readonly Button[] cmXHQZIxDUukeRCdGAxvuSrRrVmb;

			private readonly ReadOnlyCollection<Button> DxROtMZmBIsNhQfAvCgmHHOWfMxdA;

			private readonly int[] WCuInoEcLZttpWVVGrniLfYkGbZdA;

			public override int elementCapacity => 4;

			public IList<Button> Buttons
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return EmptyObjects<Button>.EmptyReadOnlyIListT;
					}
					return DxROtMZmBIsNhQfAvCgmHHOWfMxdA;
				}
			}

			public Button buttonUp
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return null;
					}
					return TIxnSRhPSalQFvQOFZaLLiQtwMIC<Button>(0);
				}
			}

			public Button buttonRight
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return null;
					}
					return TIxnSRhPSalQFvQOFZaLLiQtwMIC<Button>(1);
				}
			}

			public Button buttonDown
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return null;
					}
					return TIxnSRhPSalQFvQOFZaLLiQtwMIC<Button>(2);
				}
			}

			public Button buttonLeft
			{
				get
				{
					if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
					{
						ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
						return null;
					}
					return TIxnSRhPSalQFvQOFZaLLiQtwMIC<Button>(3);
				}
			}

			internal DirectionalPad(Controller P_0, int P_1, string P_2, Button[] P_3, int[] P_4)
				: base(P_0, P_1, P_2, CompoundControllerElementType.DPad)
			{
				int num = ((P_3 != null) ? P_3.Length : 0);
				if (num != ((P_4 != null) ? P_4.Length : 0))
				{
					throw new ArgumentException("buttons.Length must equal buttonIndices.Length!");
				}
				if (num != 0 && num != 4)
				{
					throw new ArgumentException("buttons.Length must be 0 or 4! Length: " + num);
				}
				for (int i = 0; i < num; i++)
				{
					noRZOaiqNhQVUigJbcItGViYdGAm(P_3[i], P_4[i]);
				}
				cmXHQZIxDUukeRCdGAxvuSrRrVmb = P_3;
				WCuInoEcLZttpWVVGrniLfYkGbZdA = P_4;
				sqOAjqiYgpyrLlQchddtcgIsmpGfb = num;
				DxROtMZmBIsNhQfAvCgmHHOWfMxdA = new ReadOnlyCollection<Button>(P_3);
			}

			internal void sboEOQazNCgVCSWpNHHosMaWIvev(UpdateLoopType P_0, ControllerDataUpdater P_1)
			{
				if (sqOAjqiYgpyrLlQchddtcgIsmpGfb == 0)
				{
					return;
				}
				for (int i = 0; i < cmXHQZIxDUukeRCdGAxvuSrRrVmb.Length; i++)
				{
					if (cmXHQZIxDUukeRCdGAxvuSrRrVmb[i] != null)
					{
						cmXHQZIxDUukeRCdGAxvuSrRrVmb[i].ZCYeQXTQlBeczBTsRNSgmJnLWcxf(P_0, WCuInoEcLZttpWVVGrniLfYkGbZdA[i], P_1);
					}
				}
			}
		}

		[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
		public abstract class Extension
		{
			private Controller SHugpoIFWkCnojYBXWjOaAoAAYCW;

			private IControllerExtensionSource CLFHWOuPSRLahPSSrSHZoiqMbYrk;

			internal readonly int _reInputId;

			internal bool isJoystickConnected
			{
				get
				{
					if (SHugpoIFWkCnojYBXWjOaAoAAYCW == null)
					{
						return false;
					}
					return SHugpoIFWkCnojYBXWjOaAoAAYCW._isConnected;
				}
			}

			internal bool enabled
			{
				get
				{
					if (SHugpoIFWkCnojYBXWjOaAoAAYCW == null)
					{
						return false;
					}
					return SHugpoIFWkCnojYBXWjOaAoAAYCW.enabled;
				}
			}

			public Controller controller => SHugpoIFWkCnojYBXWjOaAoAAYCW;

			internal Extension(IControllerExtensionSource P_0)
			{
				_reInputId = ReInput.id;
				yCbnuYjPdoDSWlofAupfOuHlfNOG(P_0);
			}

			internal Extension(Extension P_0)
				: this(P_0.CLFHWOuPSRLahPSSrSHZoiqMbYrk)
			{
				SHugpoIFWkCnojYBXWjOaAoAAYCW = P_0.SHugpoIFWkCnojYBXWjOaAoAAYCW;
			}

			internal T GetController<T>() where T : Controller
			{
				if (SHugpoIFWkCnojYBXWjOaAoAAYCW == null)
				{
					return null;
				}
				return SHugpoIFWkCnojYBXWjOaAoAAYCW as T;
			}

			internal void SetController(Controller controller)
			{
				SHugpoIFWkCnojYBXWjOaAoAAYCW = controller;
			}

			[CustomObfuscation(rename = false)]
			internal IControllerExtensionSource GetSource()
			{
				return CLFHWOuPSRLahPSSrSHZoiqMbYrk;
			}

			internal void SetSource(Extension extension)
			{
				if (extension == null)
				{
					yCbnuYjPdoDSWlofAupfOuHlfNOG(null);
				}
				else
				{
					yCbnuYjPdoDSWlofAupfOuHlfNOG(extension.CLFHWOuPSRLahPSSrSHZoiqMbYrk);
				}
			}

			private void yCbnuYjPdoDSWlofAupfOuHlfNOG(IControllerExtensionSource P_0)
			{
				CLFHWOuPSRLahPSSrSHZoiqMbYrk = P_0;
				SourceUpdated(CLFHWOuPSRLahPSSrSHZoiqMbYrk);
			}

			internal virtual void Clear()
			{
			}

			internal abstract void SourceUpdated(IControllerExtensionSource source);

			internal abstract void UpdateData(UpdateLoopType updateLoop);

			internal abstract Extension Clone();
		}

		[Serializable]
		private sealed class ZyCnamzpmwjPykjIZCsIeDIwERMr
		{
			public static readonly ZyCnamzpmwjPykjIZCsIeDIwERMr _003C_003E9 = new ZyCnamzpmwjPykjIZCsIeDIwERMr();

			public static Func<Controller, Guid, bool> _003C_003E9__166_0;

			public static Func<Controller, Type, bool> _003C_003E9__169_0;

			internal bool WDVJmhlzLiAcNaviUPEnyigOqofL(Controller P_0, Guid P_1)
			{
				return P_0.ImplementsTemplate(P_1);
			}

			internal bool kELGlMdWLwJhqKQpByikHLShdbMX(Controller P_0, Type P_1)
			{
				return P_0.ImplementsTemplate(P_1);
			}
		}

		private sealed class OwzyIjXLfQdOxFOHMXSUgbBkPgCj : IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IDisposable, IEnumerable, IEnumerator
		{
			private int hMnbMujJvihgLcBmOvURwCGCKZDT;

			private ControllerPollingInfo vjnbYLtrPMftzpjohNfommerCnGo;

			private int AyagikQIJAatoHzFlyaifyWyaTktA;

			public Controller zITtixdgVFWlEnpDnrTdnZsdTFkt;

			private int XFqmAWzGaybkkIOLbVBNhzaWDOgGA;

			ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return vjnbYLtrPMftzpjohNfommerCnGo;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return vjnbYLtrPMftzpjohNfommerCnGo;
				}
			}

			[DebuggerHidden]
			public OwzyIjXLfQdOxFOHMXSUgbBkPgCj(int P_0)
			{
				hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
				AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
				Controller controller = zITtixdgVFWlEnpDnrTdnZsdTFkt;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
					goto IL_00a0;
				}
				hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
				if (ReInput._id != controller.oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(controller.oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return false;
				}
				controller.UpdatePollingFrameTracking();
				XFqmAWzGaybkkIOLbVBNhzaWDOgGA = 0;
				goto IL_00b0;
				IL_00b0:
				if (XFqmAWzGaybkkIOLbVBNhzaWDOgGA < controller._buttonCount)
				{
					if (controller.CQSBjMyynzTYHaVLvtetVhfBrDgk(XFqmAWzGaybkkIOLbVBNhzaWDOgGA, out var num2))
					{
						vjnbYLtrPMftzpjohNfommerCnGo = new ControllerPollingInfo(true, -1, controller.id, controller._name, controller._type, ControllerElementType.Button, XFqmAWzGaybkkIOLbVBNhzaWDOgGA, Pole.Positive, controller.AWCbIECppuLDtCThiwONsElGeIEub.GetElementIdentifierName(num2), num2, KeyCode.None);
						hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
						return true;
					}
					goto IL_00a0;
				}
				return false;
				IL_00a0:
				XFqmAWzGaybkkIOLbVBNhzaWDOgGA++;
				goto IL_00b0;
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

			[DebuggerHidden]
			IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
			{
				OwzyIjXLfQdOxFOHMXSUgbBkPgCj owzyIjXLfQdOxFOHMXSUgbBkPgCj;
				if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
				{
					hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
					owzyIjXLfQdOxFOHMXSUgbBkPgCj = this;
				}
				else
				{
					owzyIjXLfQdOxFOHMXSUgbBkPgCj = new OwzyIjXLfQdOxFOHMXSUgbBkPgCj(0);
					owzyIjXLfQdOxFOHMXSUgbBkPgCj.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
				}
				return owzyIjXLfQdOxFOHMXSUgbBkPgCj;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
			}
		}

		private sealed class OJUQcCTkghIGZBwSSZerNUMOgGrnA : IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IDisposable, IEnumerable, IEnumerator
		{
			private int hMnbMujJvihgLcBmOvURwCGCKZDT;

			private ControllerPollingInfo vjnbYLtrPMftzpjohNfommerCnGo;

			private int AyagikQIJAatoHzFlyaifyWyaTktA;

			public Controller zITtixdgVFWlEnpDnrTdnZsdTFkt;

			private int XFqmAWzGaybkkIOLbVBNhzaWDOgGA;

			ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return vjnbYLtrPMftzpjohNfommerCnGo;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return vjnbYLtrPMftzpjohNfommerCnGo;
				}
			}

			[DebuggerHidden]
			public OJUQcCTkghIGZBwSSZerNUMOgGrnA(int P_0)
			{
				hMnbMujJvihgLcBmOvURwCGCKZDT = P_0;
				AyagikQIJAatoHzFlyaifyWyaTktA = Thread.CurrentThread.ManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int num = hMnbMujJvihgLcBmOvURwCGCKZDT;
				Controller controller = zITtixdgVFWlEnpDnrTdnZsdTFkt;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
					goto IL_00a0;
				}
				hMnbMujJvihgLcBmOvURwCGCKZDT = -1;
				if (ReInput._id != controller.oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(controller.oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return false;
				}
				controller.UpdatePollingFrameTracking();
				XFqmAWzGaybkkIOLbVBNhzaWDOgGA = 0;
				goto IL_00b0;
				IL_00b0:
				if (XFqmAWzGaybkkIOLbVBNhzaWDOgGA < controller._buttonCount)
				{
					if (controller.OJTksenkJoivMfJSDhtmWQUOZBGdA(XFqmAWzGaybkkIOLbVBNhzaWDOgGA, out var num2))
					{
						vjnbYLtrPMftzpjohNfommerCnGo = new ControllerPollingInfo(true, -1, controller.id, controller._name, controller._type, ControllerElementType.Button, XFqmAWzGaybkkIOLbVBNhzaWDOgGA, Pole.Positive, controller.AWCbIECppuLDtCThiwONsElGeIEub.GetElementIdentifierName(num2), num2, KeyCode.None);
						hMnbMujJvihgLcBmOvURwCGCKZDT = 1;
						return true;
					}
					goto IL_00a0;
				}
				return false;
				IL_00a0:
				XFqmAWzGaybkkIOLbVBNhzaWDOgGA++;
				goto IL_00b0;
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

			[DebuggerHidden]
			IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
			{
				OJUQcCTkghIGZBwSSZerNUMOgGrnA oJUQcCTkghIGZBwSSZerNUMOgGrnA;
				if (hMnbMujJvihgLcBmOvURwCGCKZDT == -2 && AyagikQIJAatoHzFlyaifyWyaTktA == Thread.CurrentThread.ManagedThreadId)
				{
					hMnbMujJvihgLcBmOvURwCGCKZDT = 0;
					oJUQcCTkghIGZBwSSZerNUMOgGrnA = this;
				}
				else
				{
					oJUQcCTkghIGZBwSSZerNUMOgGrnA = new OJUQcCTkghIGZBwSSZerNUMOgGrnA(0);
					oJUQcCTkghIGZBwSSZerNUMOgGrnA.zITtixdgVFWlEnpDnrTdnZsdTFkt = zITtixdgVFWlEnpDnrTdnZsdTFkt;
				}
				return oJUQcCTkghIGZBwSSZerNUMOgGrnA;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
			}
		}

		public readonly int id;

		protected string _tag;

		protected string _name;

		private readonly DeviceLocalizationInfo cMOhIWyaBnCynMJwNfakJfQfUpqVA;

		protected string _hardwareName;

		protected readonly ControllerType _type;

		internal readonly Guid FZUSYXsTFrKCEfDGTdZDqHMyUGhC;

		protected string _hardwareIdentifier;

		protected bool _isConnected;

		private Extension OFqIbfCUNqUzQiOnvNfKvZuUmZBo;

		private bool KByWFLCBjjvqwXYVZFDfzPdklyjf;

		private ControllerIdentifier bPriVZLNpiMSpHZmCIbCgFpsRPRs;

		internal int oLUDKIBSDOGsiswKzVsPEXOleBcs;

		protected readonly int _buttonCount;

		protected readonly Button[] buttons;

		protected readonly ReadOnlyCollection<Button> buttons_readOnly;

		private readonly IList<Element> JlCnxdjSAFgokjnBJvAQVZXHNacj;

		private readonly ReadOnlyCollection<Element> jyTJsuSvMygQOFvHEMJfNaFRYsZO;

		private readonly IList<CompoundElement> kqMuSUujiYTwxxSZERSWoQmIPtWK;

		private readonly ReadOnlyCollection<CompoundElement> EDfWYZcTjxQLsFGRhmaXWtaXAiLG;

		[CustomObfuscation(rename = false)]
		internal readonly InputSource inputSource;

		internal readonly ControllerDataUpdater fcpRkkeLOqieJylVwWSUEEJhOXpJ;

		internal readonly HardwareControllerMap_Game AWCbIECppuLDtCThiwONsElGeIEub;

		internal uint KBOiXIHMwaZReSHtGzdvSSUAqTYf;

		private uint EIMDCnEBKbibXxNcrMYgQbCchyYfb;

		private uint XhMusxvaaPSXyZynSNHIUwxrTOSr;

		private ITryGetLocalizedName tEIVzpQRVkPnnUCQxYdItGFNDTyh;

		private readonly LocalizedString pBHGSdiKqWIcVIxiLTzkoXwKRJelA;

		private readonly dXkbKlACvOfIDvWcTAscoLeMLyzQA tMhYYBuCMsmrVGvixosjKPNUbykf;

		private Action<bool> QzPwGNYXPQUefVsEZhDuCXeCuzIW;

		private IControllerTemplate[] xlcKHzWGqINkdqCoMpijgAdnWEFs;

		private ReadOnlyCollection<IControllerTemplate> psyvkZYaBsbrVEJVDXbhsKzFzqkb;

		private static Func<Controller, Guid, bool> QmPEwqIOjlVuzcSSjGHzBGXqBFVL;

		private static Func<Controller, Type, bool> XuzRzPHyqOrTVONAZArtHAtyWniSA;

		internal bool XTqqBJEaiWOlrUBUlidcGVurdywL => EIMDCnEBKbibXxNcrMYgQbCchyYfb == ReInput.previousFrame;

		public bool enabled
		{
			get
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return false;
				}
				return KByWFLCBjjvqwXYVZFDfzPdklyjf;
			}
			set
			{
				vSypfONnKVpDpZlTyTmFsHtqFCqP(value);
			}
		}

		public string name
		{
			get
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return string.Empty;
				}
				if (!LocalizationManager.isEnabled)
				{
					return _name;
				}
				if (sVSDTFomzlOsrCOaJQrEEeONMSjt != null && sVSDTFomzlOsrCOaJQrEEeONMSjt.TryGetLocalizedName(out var value))
				{
					return value;
				}
				if (_type == ControllerType.Joystick && FZUSYXsTFrKCEfDGTdZDqHMyUGhC == Consts.joystickGuid_unknownController)
				{
					return _name;
				}
				if (cMOhIWyaBnCynMJwNfakJfQfUpqVA == null || cMOhIWyaBnCynMJwNfakJfQfUpqVA.parentKeys == null)
				{
					return _name;
				}
				LocalizationManager.GetAndUpdateLocalizedString(pBHGSdiKqWIcVIxiLTzkoXwKRJelA, (cMOhIWyaBnCynMJwNfakJfQfUpqVA != null) ? cMOhIWyaBnCynMJwNfakJfQfUpqVA.parentKeys : null, bYUfoUKGpLnbYkcOYAkjmqgxLxsS.JCFGlogpCHkdrSooohIxKLMgQkvOA(_type), _name, out value);
				return value;
			}
			internal set
			{
				_name = text;
			}
		}

		public string tag
		{
			get
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return string.Empty;
				}
				return _tag;
			}
			set
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
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
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return string.Empty;
				}
				return _hardwareName;
			}
		}

		public ControllerType type
		{
			get
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return ControllerType.Keyboard;
				}
				return _type;
			}
		}

		public Guid hardwareTypeGuid
		{
			get
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return Guid.Empty;
				}
				return FZUSYXsTFrKCEfDGTdZDqHMyUGhC;
			}
		}

		public abstract Guid deviceInstanceGuid { get; }

		public ControllerIdentifier identifier => bPriVZLNpiMSpHZmCIbCgFpsRPRs;

		public bool isConnected
		{
			get
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return false;
				}
				return _isConnected;
			}
			internal set
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				}
				else if (!flag)
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
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
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
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return 0;
				}
				return JlCnxdjSAFgokjnBJvAQVZXHNacj.Count;
			}
		}

		public int buttonCount
		{
			get
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return 0;
				}
				return _buttonCount;
			}
		}

		public IList<Element> Elements
		{
			get
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return EmptyObjects<Element>.EmptyReadOnlyIListT;
				}
				return jyTJsuSvMygQOFvHEMJfNaFRYsZO;
			}
		}

		public IList<CompoundElement> CompoundElements
		{
			get
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return EmptyObjects<CompoundElement>.EmptyReadOnlyIListT;
				}
				return EDfWYZcTjxQLsFGRhmaXWtaXAiLG;
			}
		}

		public IList<Button> Buttons
		{
			get
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return EmptyObjects<Button>.EmptyReadOnlyIListT;
				}
				return buttons_readOnly;
			}
		}

		public Extension extension
		{
			get
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return null;
				}
				return OFqIbfCUNqUzQiOnvNfKvZuUmZBo;
			}
		}

		public IList<ControllerElementIdentifier> ElementIdentifiers
		{
			get
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return EmptyObjects<ControllerElementIdentifier>.EmptyReadOnlyIListT;
				}
				return AWCbIECppuLDtCThiwONsElGeIEub.elementIdentifiers_readOnly;
			}
		}

		public IList<ControllerElementIdentifier> ButtonElementIdentifiers
		{
			get
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return EmptyObjects<ControllerElementIdentifier>.EmptyReadOnlyIListT;
				}
				return AWCbIECppuLDtCThiwONsElGeIEub.buttonElementIdentifiers_readOnly;
			}
		}

		internal ITryGetLocalizedName sVSDTFomzlOsrCOaJQrEEeONMSjt
		{
			get
			{
				return tEIVzpQRVkPnnUCQxYdItGFNDTyh;
			}
			set
			{
				tEIVzpQRVkPnnUCQxYdItGFNDTyh = tryGetLocalizedName;
			}
		}

		public IList<IControllerTemplate> Templates
		{
			get
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return EmptyObjects<IControllerTemplate>.EmptyReadOnlyIListT;
				}
				return psyvkZYaBsbrVEJVDXbhsKzFzqkb;
			}
		}

		public int templateCount
		{
			get
			{
				if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
				{
					ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
					return 0;
				}
				return xlcKHzWGqINkdqCoMpijgAdnWEFs.Length;
			}
		}

		internal static Func<Controller, Guid, bool> WcqwKmwpCxmvXgoRwtTsSsgNfarO => ZyCnamzpmwjPykjIZCsIeDIwERMr._003C_003E9.WDVJmhlzLiAcNaviUPEnyigOqofL;

		internal static Func<Controller, Type, bool> mOJFQgdpynnJgyTCLVelnuyaORMv => ZyCnamzpmwjPykjIZCsIeDIwERMr._003C_003E9.kELGlMdWLwJhqKQpByikHLShdbMX;

		internal event Action<bool> dnIMGTNXLhdyZHTiJNpLPCYsUwfp
		{
			add
			{
				QzPwGNYXPQUefVsEZhDuCXeCuzIW = (Action<bool>)Delegate.Combine(QzPwGNYXPQUefVsEZhDuCXeCuzIW, b);
			}
			remove
			{
				QzPwGNYXPQUefVsEZhDuCXeCuzIW = (Action<bool>)Delegate.Remove(QzPwGNYXPQUefVsEZhDuCXeCuzIW, value2);
			}
		}

		internal Controller(int P_0, InputSource P_1, string P_2, string P_3, string P_4, ControllerType P_5, Guid P_6, int P_7, bool[] P_8, HardwareButtonInfo[] P_9, HardwareControllerMap_Game P_10, Extension P_11, ControllerDataUpdater P_12)
		{
			id = P_0;
			inputSource = P_1;
			_type = P_5;
			FZUSYXsTFrKCEfDGTdZDqHMyUGhC = P_6;
			_buttonCount = P_7;
			_name = P_2;
			_hardwareName = P_3;
			_hardwareIdentifier = P_4;
			fcpRkkeLOqieJylVwWSUEEJhOXpJ = P_12;
			AWCbIECppuLDtCThiwONsElGeIEub = P_10;
			cMOhIWyaBnCynMJwNfakJfQfUpqVA = P_10.deviceLocalizationInfo;
			KByWFLCBjjvqwXYVZFDfzPdklyjf = true;
			oLUDKIBSDOGsiswKzVsPEXOleBcs = ReInput.id;
			pBHGSdiKqWIcVIxiLTzkoXwKRJelA = new LocalizedString();
			tMhYYBuCMsmrVGvixosjKPNUbykf = new dXkbKlACvOfIDvWcTAscoLeMLyzQA(delegate
			{
				_ = name;
			});
			nWDsfQvWLSZHvoAkYNmOnDtxCKYR(P_11);
			JlCnxdjSAFgokjnBJvAQVZXHNacj = new List<Element>(P_7);
			jyTJsuSvMygQOFvHEMJfNaFRYsZO = new ReadOnlyCollection<Element>(JlCnxdjSAFgokjnBJvAQVZXHNacj);
			kqMuSUujiYTwxxSZERSWoQmIPtWK = new List<CompoundElement>();
			EDfWYZcTjxQLsFGRhmaXWtaXAiLG = new ReadOnlyCollection<CompoundElement>(kqMuSUujiYTwxxSZERSWoQmIPtWK);
			buttons = new Button[P_7];
			if (P_8 == null || P_8.Length < P_7)
			{
				for (int num = 0; num < P_7; num++)
				{
					buttons[num] = new Button(this, P_10.buttonElementIdentifierIds[num], "Button " + num, false, (P_9 != null) ? P_9[num] : new HardwareButtonInfo());
					noRZOaiqNhQVUigJbcItGViYdGAm(buttons[num]);
				}
			}
			else
			{
				for (int num2 = 0; num2 < P_7; num2++)
				{
					buttons[num2] = new Button(this, P_10.buttonElementIdentifierIds[num2], "Button " + num2, P_8[num2], (P_9 != null) ? P_9[num2] : new HardwareButtonInfo());
					noRZOaiqNhQVUigJbcItGViYdGAm(buttons[num2]);
				}
			}
			buttons_readOnly = new ReadOnlyCollection<Button>(buttons);
			xlcKHzWGqINkdqCoMpijgAdnWEFs = EmptyObjects<IControllerTemplate>.array;
			psyvkZYaBsbrVEJVDXbhsKzFzqkb = new ReadOnlyCollection<IControllerTemplate>(xlcKHzWGqINkdqCoMpijgAdnWEFs);
			if (LocalizationManager.isEnabled && LocalizationManager.autoPrefetch)
			{
				((gPdbPvViIcfmuVJElIIVfiLqZVrDA)tMhYYBuCMsmrVGvixosjKPNUbykf).Localize();
			}
			Connected();
		}

		internal virtual void pggOEkcvhxxBuBDIbrJuSafugeIK()
		{
			bPriVZLNpiMSpHZmCIbCgFpsRPRs = new ControllerIdentifier(this);
		}

		public virtual Element GetElementById(int elementIdentifierId)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return null;
			}
			if (AWCbIECppuLDtCThiwONsElGeIEub == null)
			{
				return null;
			}
			int buttonIndex = AWCbIECppuLDtCThiwONsElGeIEub.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0)
			{
				return null;
			}
			return buttons[buttonIndex];
		}

		public virtual CompoundElement GetCompoundElementById(int elementIdentifierId)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return null;
			}
			int count = kqMuSUujiYTwxxSZERSWoQmIPtWK.Count;
			for (int i = 0; i < count; i++)
			{
				if (kqMuSUujiYTwxxSZERSWoQmIPtWK[i] != null && kqMuSUujiYTwxxSZERSWoQmIPtWK[i].id == elementIdentifierId)
				{
					return kqMuSUujiYTwxxSZERSWoQmIPtWK[i];
				}
			}
			return null;
		}

		[Obsolete("This method is deprecated. Use GetCompoundElementById instead.", false)]
		public virtual CompoundElement GetCompundElementById(int elementIdentifierId)
		{
			return GetCompoundElementById(elementIdentifierId);
		}

		public int GetButtonIndexById(int elementIdentifierId)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return -1;
			}
			return AWCbIECppuLDtCThiwONsElGeIEub.GetButtonIndex(elementIdentifierId);
		}

		public ControllerElementIdentifier GetElementIdentifierById(int elementIdentifierId)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return null;
			}
			return AWCbIECppuLDtCThiwONsElGeIEub.GetElementIdentifierById(elementIdentifierId);
		}

		public virtual bool GetButton(int index)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
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
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
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
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
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
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
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
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
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
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			return GetButtonDoublePressHold(index, 0f);
		}

		public virtual bool GetButtonDoublePressHold(int index, float speed)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
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
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			return GetButtonDoublePressDown(index, 0f);
		}

		public virtual bool GetButtonDoublePressDown(int index, float speed)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
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
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
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
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
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
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
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
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
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
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
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
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
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
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
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
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
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
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
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
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			int buttonIndex = AWCbIECppuLDtCThiwONsElGeIEub.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				return false;
			}
			return buttons[buttonIndex].value;
		}

		public virtual bool GetButtonDownById(int elementIdentifierId)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			int buttonIndex = AWCbIECppuLDtCThiwONsElGeIEub.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				return false;
			}
			return buttons[buttonIndex].justPressed;
		}

		public virtual bool GetButtonUpById(int elementIdentifierId)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			int buttonIndex = AWCbIECppuLDtCThiwONsElGeIEub.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				return false;
			}
			return buttons[buttonIndex].justReleased;
		}

		public virtual bool GetButtonDoublePressHoldById(int elementIdentifierId, float speed)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			int buttonIndex = AWCbIECppuLDtCThiwONsElGeIEub.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				return false;
			}
			return buttons[buttonIndex].DoublePressedAndHeld(speed);
		}

		public virtual bool GetButtonDoublePressDownById(int elementIdentifierId, float speed)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			int buttonIndex = AWCbIECppuLDtCThiwONsElGeIEub.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				return false;
			}
			return buttons[buttonIndex].JustDoublePressed(speed);
		}

		public virtual bool GetButtonDoublePressHoldById(int elementIdentifierId)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			int buttonIndex = AWCbIECppuLDtCThiwONsElGeIEub.GetButtonIndex(elementIdentifierId);
			return GetButtonDoublePressHold(buttonIndex, 0f);
		}

		public virtual bool GetButtonDoublePressDownById(int elementIdentifierId)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			int buttonIndex = AWCbIECppuLDtCThiwONsElGeIEub.GetButtonIndex(elementIdentifierId);
			return GetButtonDoublePressDown(buttonIndex, 0f);
		}

		public virtual bool GetButtonPrevById(int elementIdentifierId)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			int buttonIndex = AWCbIECppuLDtCThiwONsElGeIEub.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				return false;
			}
			return buttons[buttonIndex].valuePrev;
		}

		public virtual double GetButtonTimePressedById(int elementIdentifierId)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return 0.0;
			}
			int buttonIndex = AWCbIECppuLDtCThiwONsElGeIEub.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				return 0.0;
			}
			return buttons[buttonIndex].timePressed;
		}

		public virtual double GetButtonTimeUnpressedById(int elementIdentifierId)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return 0.0;
			}
			int buttonIndex = AWCbIECppuLDtCThiwONsElGeIEub.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				return 0.0;
			}
			return buttons[buttonIndex].timeUnpressed;
		}

		public virtual double GetButtonLastTimePressedById(int elementIdentifierId)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return 0.0;
			}
			int buttonIndex = AWCbIECppuLDtCThiwONsElGeIEub.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				return 0.0;
			}
			return buttons[buttonIndex].lastTimePressed;
		}

		public virtual double GetButtonLastTimeUnpressedById(int elementIdentifierId)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return 0.0;
			}
			int buttonIndex = AWCbIECppuLDtCThiwONsElGeIEub.GetButtonIndex(elementIdentifierId);
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
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return ControllerPollingInfo.rVpgmYdiORKOxsMzdJFOFbvjVBGPA();
			}
			UpdatePollingFrameTracking();
			for (int i = 0; i < _buttonCount; i++)
			{
				if (CQSBjMyynzTYHaVLvtetVhfBrDgk(i, out var num))
				{
					return new ControllerPollingInfo(true, -1, id, _name, _type, ControllerElementType.Button, i, Pole.Positive, AWCbIECppuLDtCThiwONsElGeIEub.GetElementIdentifierName(num), num, KeyCode.None);
				}
			}
			return ControllerPollingInfo.rVpgmYdiORKOxsMzdJFOFbvjVBGPA();
		}

		public virtual ControllerPollingInfo PollForFirstButtonDown()
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return ControllerPollingInfo.rVpgmYdiORKOxsMzdJFOFbvjVBGPA();
			}
			UpdatePollingFrameTracking();
			for (int i = 0; i < _buttonCount; i++)
			{
				if (OJTksenkJoivMfJSDhtmWQUOZBGdA(i, out var num))
				{
					return new ControllerPollingInfo(true, -1, id, _name, _type, ControllerElementType.Button, i, Pole.Positive, AWCbIECppuLDtCThiwONsElGeIEub.GetElementIdentifierName(num), num, KeyCode.None);
				}
			}
			return ControllerPollingInfo.rVpgmYdiORKOxsMzdJFOFbvjVBGPA();
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
			return new OwzyIjXLfQdOxFOHMXSUgbBkPgCj(-2)
			{
				zITtixdgVFWlEnpDnrTdnZsdTFkt = this
			};
		}

		public virtual IEnumerable<ControllerPollingInfo> PollForAllButtonsDown()
		{
			return new OJUQcCTkghIGZBwSSZerNUMOgGrnA(-2)
			{
				zITtixdgVFWlEnpDnrTdnZsdTFkt = this
			};
		}

		private bool CQSBjMyynzTYHaVLvtetVhfBrDgk(int P_0, out int P_1)
		{
			P_1 = -1;
			if (!buttons[P_0].value || buttons[P_0].QPRpOcJQwlEKkidErhOZRqEVdCmHA._excludeFromPolling)
			{
				return false;
			}
			P_1 = AWCbIECppuLDtCThiwONsElGeIEub.buttonElementIdentifierIds[P_0];
			if (P_1 < 0)
			{
				return false;
			}
			return true;
		}

		private bool OJTksenkJoivMfJSDhtmWQUOZBGdA(int P_0, out int P_1)
		{
			P_1 = -1;
			if (!buttons[P_0].justPressed || buttons[P_0].QPRpOcJQwlEKkidErhOZRqEVdCmHA._excludeFromPolling)
			{
				return false;
			}
			P_1 = AWCbIECppuLDtCThiwONsElGeIEub.buttonElementIdentifierIds[P_0];
			if (P_1 < 0)
			{
				return false;
			}
			return true;
		}

		protected void UpdatePollingFrameTracking()
		{
			if (XhMusxvaaPSXyZynSNHIUwxrTOSr == ReInput.currentFrame)
			{
				return;
			}
			EIMDCnEBKbibXxNcrMYgQbCchyYfb = XhMusxvaaPSXyZynSNHIUwxrTOSr;
			XhMusxvaaPSXyZynSNHIUwxrTOSr = ReInput.currentFrame;
			if (!XTqqBJEaiWOlrUBUlidcGVurdywL)
			{
				if (KBOiXIHMwaZReSHtGzdvSSUAqTYf == uint.MaxValue)
				{
					KBOiXIHMwaZReSHtGzdvSSUAqTYf = 0u;
				}
				else
				{
					KBOiXIHMwaZReSHtGzdvSSUAqTYf++;
				}
			}
		}

		public virtual double GetLastTimeActive()
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return 0.0;
			}
			return GetLastTimeActive(useRawValues: false);
		}

		public virtual double GetLastTimeActive(bool useRawValues)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return 0.0;
			}
			return GetLastTimeAnyButtonPressed();
		}

		public virtual double GetLastTimeAnyElementChanged()
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return 0.0;
			}
			return GetLastTimeAnyElementChanged(useRawValues: false);
		}

		public virtual double GetLastTimeAnyElementChanged(bool useRawValues)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return 0.0;
			}
			return GetLastTimeAnyButtonChanged();
		}

		public double GetLastTimeAnyButtonPressed()
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
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
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
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
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return null;
			}
			return OFqIbfCUNqUzQiOnvNfKvZuUmZBo as T;
		}

		public IControllerTemplate GetTemplate(Guid typeGuid)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return null;
			}
			for (int i = 0; i < xlcKHzWGqINkdqCoMpijgAdnWEFs.Length; i++)
			{
				if (xlcKHzWGqINkdqCoMpijgAdnWEFs[i].typeGuid == typeGuid)
				{
					return xlcKHzWGqINkdqCoMpijgAdnWEFs[i];
				}
			}
			return null;
		}

		public IControllerTemplate GetTemplate(Type type)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return null;
			}
			for (int i = 0; i < xlcKHzWGqINkdqCoMpijgAdnWEFs.Length; i++)
			{
				if (ReflectionTools.DoesTypeImplement(xlcKHzWGqINkdqCoMpijgAdnWEFs[i].GetType(), type))
				{
					return xlcKHzWGqINkdqCoMpijgAdnWEFs[i];
				}
			}
			return null;
		}

		public T GetTemplate<T>() where T : class
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return null;
			}
			for (int i = 0; i < xlcKHzWGqINkdqCoMpijgAdnWEFs.Length; i++)
			{
				if (xlcKHzWGqINkdqCoMpijgAdnWEFs[i] as T != null)
				{
					return xlcKHzWGqINkdqCoMpijgAdnWEFs[i] as T;
				}
			}
			return null;
		}

		public bool ImplementsTemplate(Guid typeGuid)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			for (int i = 0; i < xlcKHzWGqINkdqCoMpijgAdnWEFs.Length; i++)
			{
				if (xlcKHzWGqINkdqCoMpijgAdnWEFs[i].typeGuid == typeGuid)
				{
					return true;
				}
			}
			return false;
		}

		public bool ImplementsTemplate(Type type)
		{
			if (ReInput._id != oLUDKIBSDOGsiswKzVsPEXOleBcs)
			{
				ReInput.CheckInitialized(oLUDKIBSDOGsiswKzVsPEXOleBcs);
				return false;
			}
			if ((object)type == null)
			{
				throw new ArgumentNullException("type");
			}
			for (int i = 0; i < xlcKHzWGqINkdqCoMpijgAdnWEFs.Length; i++)
			{
				if (ReflectionTools.DoesTypeImplement(xlcKHzWGqINkdqCoMpijgAdnWEFs[i].GetType(), type))
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

		internal void wALdDCrmIvSwBbNGOseksiAhYCjC(IControllerTemplate[] P_0)
		{
			if (P_0 != null)
			{
				xlcKHzWGqINkdqCoMpijgAdnWEFs = P_0;
				psyvkZYaBsbrVEJVDXbhsKzFzqkb = new ReadOnlyCollection<IControllerTemplate>(xlcKHzWGqINkdqCoMpijgAdnWEFs);
			}
		}

		internal virtual void tglbagDKhFNyJrooYNWfohsJFQmi(UpdateLoopType P_0)
		{
			bool num = ReInput.IsInputAllowed(_type);
			int num2 = _buttonCount;
			if (num)
			{
				for (int i = 0; i < num2; i++)
				{
					if (buttons[i].zpCvoTkfZmcEPlIkyettGEDFDHMq <= 0)
					{
						buttons[i].ZCYeQXTQlBeczBTsRNSgmJnLWcxf(P_0, i, fcpRkkeLOqieJylVwWSUEEJhOXpJ);
					}
				}
			}
			else
			{
				for (int j = 0; j < num2; j++)
				{
					if (buttons[j].zpCvoTkfZmcEPlIkyettGEDFDHMq <= 0)
					{
						buttons[j].KeggwlnEVkAAffiNsiwTBJexzjdo(P_0);
					}
				}
			}
			if (OFqIbfCUNqUzQiOnvNfKvZuUmZBo != null)
			{
				OFqIbfCUNqUzQiOnvNfKvZuUmZBo.UpdateData(P_0);
			}
		}

		internal virtual ButtonStateFlags dQXLgNytWHwEWvOMAjCewCOwnIlD(int P_0)
		{
			if (P_0 < 0 || P_0 >= _buttonCount)
			{
				return ButtonStateFlags.Off;
			}
			return buttons[P_0].eGnbpQDpxoxswhwDnqEOiknSUIYy;
		}

		internal void nWDsfQvWLSZHvoAkYNmOnDtxCKYR(Extension P_0)
		{
			if (P_0 == null)
			{
				OFqIbfCUNqUzQiOnvNfKvZuUmZBo = null;
				return;
			}
			if (OFqIbfCUNqUzQiOnvNfKvZuUmZBo != null)
			{
				bnAGYzRVKdkQjrhYaXRbXTEfQVEh(P_0);
				return;
			}
			P_0.SetController(this);
			OFqIbfCUNqUzQiOnvNfKvZuUmZBo = P_0.Clone();
		}

		internal void bnAGYzRVKdkQjrhYaXRbXTEfQVEh(Extension P_0)
		{
			if (OFqIbfCUNqUzQiOnvNfKvZuUmZBo != null)
			{
				OFqIbfCUNqUzQiOnvNfKvZuUmZBo.SetSource(P_0);
				OFqIbfCUNqUzQiOnvNfKvZuUmZBo.SetController(this);
				P_0?.SetController(this);
			}
			else
			{
				nWDsfQvWLSZHvoAkYNmOnDtxCKYR(P_0);
			}
		}

		internal virtual void wJjPIIRJfHhEbGedUconecGfiwzgB()
		{
			for (int i = 0; i < _buttonCount; i++)
			{
				if (buttons[i] != null)
				{
					buttons[i].Reset();
				}
			}
			if (fcpRkkeLOqieJylVwWSUEEJhOXpJ != null)
			{
				fcpRkkeLOqieJylVwWSUEEJhOXpJ.ClearData();
			}
			if (OFqIbfCUNqUzQiOnvNfKvZuUmZBo != null)
			{
				OFqIbfCUNqUzQiOnvNfKvZuUmZBo.Clear();
			}
		}

		internal virtual bool vSypfONnKVpDpZlTyTmFsHtqFCqP(bool P_0)
		{
			if (KByWFLCBjjvqwXYVZFDfzPdklyjf == P_0)
			{
				return false;
			}
			if (!P_0)
			{
				wJjPIIRJfHhEbGedUconecGfiwzgB();
			}
			KByWFLCBjjvqwXYVZFDfzPdklyjf = P_0;
			if (QzPwGNYXPQUefVsEZhDuCXeCuzIW != null)
			{
				QzPwGNYXPQUefVsEZhDuCXeCuzIW(P_0);
			}
			return true;
		}

		internal virtual void LJxUfrjqRngGjfLkARGJwZXpwXAOA(ControllerMap P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			P_0.controllerId = id;
			IList<ActionElementMap> buttonMaps = P_0.ButtonMaps;
			for (int i = 0; i < buttonMaps.Count; i++)
			{
				vnEKgLVSpFebRqVrxBMjTwuUqPef(P_0, buttonMaps[i]);
			}
			for (int num = buttonMaps.Count - 1; num >= 0; num--)
			{
				if (buttonMaps[num].elementIndex < 0)
				{
					P_0.DeleteElementMap(buttonMaps[num].kqvbpTxWGdGtrNRdxLepeZkwTJDn);
				}
			}
		}

		internal virtual void vnEKgLVSpFebRqVrxBMjTwuUqPef(ControllerMap P_0, ActionElementMap P_1)
		{
			if (P_1 != null && P_1._elementType == ControllerElementType.Button)
			{
				P_1.XxnQtsdeMuILfHyfAVjirqwliWOgA(P_0);
			}
		}

		internal bool cPwDhWDVSywpgVGgnkreoRvfHonz(ActionElementMap P_0, int P_1, out float P_2, out bool P_3)
		{
			P_3 = false;
			P_2 = 0f;
			if (P_1 != P_0._actionId)
			{
				return false;
			}
			int nAznauVeWTEKclGKxeRUvILhqOtm = P_0.nAznauVeWTEKclGKxeRUvILhqOtm;
			if (nAznauVeWTEKclGKxeRUvILhqOtm < 0 || nAznauVeWTEKclGKxeRUvILhqOtm >= _buttonCount)
			{
				return false;
			}
			P_3 = buttons[nAznauVeWTEKclGKxeRUvILhqOtm].LnVSFlKTZmwohPFxdhRDYsrsZRDp;
			float num = ((!P_3) ? (buttons[nAznauVeWTEKclGKxeRUvILhqOtm].value ? 1f : 0f) : buttons[nAznauVeWTEKclGKxeRUvILhqOtm].pressure);
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

		internal bool cPwDhWDVSywpgVGgnkreoRvfHonz(ActionElementMap P_0, int P_1, bool P_2, out float P_3)
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

		internal void noRZOaiqNhQVUigJbcItGViYdGAm(Element P_0)
		{
			if (P_0 != null)
			{
				ListTools.AddIfUnique(JlCnxdjSAFgokjnBJvAQVZXHNacj, P_0);
			}
		}

		internal void YyaDpuFfMbbFmjWsPsiaQKFYXYeIA(CompoundElement P_0)
		{
			if (P_0 != null)
			{
				ListTools.AddIfUnique(kqMuSUujiYTwxxSZERSWoQmIPtWK, P_0);
			}
		}

		internal virtual Guid JSinlLsBWqFRVHFiEtSXjbTvqcgE()
		{
			return Guid.Empty;
		}

		internal virtual void LkQTpFBeyUXMAddalyNJQqSBAfDB(bool P_0)
		{
			if (!P_0 && !ReInput.IsInputAllowed(_type) && OFqIbfCUNqUzQiOnvNfKvZuUmZBo != null)
			{
				OFqIbfCUNqUzQiOnvNfKvZuUmZBo.Clear();
			}
		}

		protected virtual void Connected()
		{
			_isConnected = true;
		}

		protected virtual void Disconnected()
		{
			_isConnected = false;
			if (fcpRkkeLOqieJylVwWSUEEJhOXpJ != null)
			{
				fcpRkkeLOqieJylVwWSUEEJhOXpJ.ClearData();
			}
		}

		[CompilerGenerated]
		private void hAmodBcApppmDkpCHpSeMmXJURFT()
		{
			_ = name;
		}
	}
}
