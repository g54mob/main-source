using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
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
			internal abstract class wqDQTLzJJBJSuEzjMNYQEqgZWANgA
			{
				public abstract class xNUEVpUeugcpnEiaKNJSMDItEvIh
				{
					public abstract void JxaKaqQCyXfsqeBdbYIepJBJmBYWA();
				}

				protected readonly int ZATaVfnVpCMTzYIfufsuPxbbceAE;

				protected readonly int[] KzCYDHuqnZZWylqaxSifYWpLvIJk;

				protected xNUEVpUeugcpnEiaKNJSMDItEvIh[] PBlarzFmGuEThNkVmmuyDQyQhskGA;

				public xNUEVpUeugcpnEiaKNJSMDItEvIh JodnrCQGFSOkoJarrfSzuHtuUOJy;

				private int zniAgZGztuWvDjClWKMMhzXEMyzZA;

				public int gRoycAQDkxuKqHfKTnoDRAaDJyDm = -1;

				protected ReadOnlyCollection<xNUEVpUeugcpnEiaKNJSMDItEvIh> ymvaykWyrosOZjtTEQEeuMtjEBht;

				public IList<xNUEVpUeugcpnEiaKNJSMDItEvIh> nuNKeFIFiULhPPkzIxoBhdZODJkcA => ymvaykWyrosOZjtTEQEeuMtjEBht;

				public UpdateLoopType eYRBzfNOIqpsrqwJOgPMGldxPZZq
				{
					set
					{
						if (gRoycAQDkxuKqHfKTnoDRAaDJyDm != (int)updateLoopType)
						{
							gRoycAQDkxuKqHfKTnoDRAaDJyDm = (int)updateLoopType;
							zniAgZGztuWvDjClWKMMhzXEMyzZA = KzCYDHuqnZZWylqaxSifYWpLvIJk[(int)updateLoopType];
							JodnrCQGFSOkoJarrfSzuHtuUOJy = PBlarzFmGuEThNkVmmuyDQyQhskGA[zniAgZGztuWvDjClWKMMhzXEMyzZA];
						}
					}
				}

				public wqDQTLzJJBJSuEzjMNYQEqgZWANgA(UpdateLoopSetting P_0)
				{
					KzCYDHuqnZZWylqaxSifYWpLvIJk = new int[3];
					ZATaVfnVpCMTzYIfufsuPxbbceAE = 0;
					using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
					{
						List<UpdateLoopType> list = tList.list;
						EnumConverter.ToUpdateLoopTypes(P_0, list);
						for (int i = 0; i < list.Count; i++)
						{
							KzCYDHuqnZZWylqaxSifYWpLvIJk[(int)list[i]] = ZATaVfnVpCMTzYIfufsuPxbbceAE;
							ZATaVfnVpCMTzYIfufsuPxbbceAE++;
						}
					}
					PBlarzFmGuEThNkVmmuyDQyQhskGA = new xNUEVpUeugcpnEiaKNJSMDItEvIh[ZATaVfnVpCMTzYIfufsuPxbbceAE];
					ymvaykWyrosOZjtTEQEeuMtjEBht = new ReadOnlyCollection<xNUEVpUeugcpnEiaKNJSMDItEvIh>(PBlarzFmGuEThNkVmmuyDQyQhskGA);
				}

				public void RRlmhtbUdbnkFuBtEwBERLGrjBcd()
				{
					for (int i = 0; i < ZATaVfnVpCMTzYIfufsuPxbbceAE; i++)
					{
						PBlarzFmGuEThNkVmmuyDQyQhskGA[i].JxaKaqQCyXfsqeBdbYIepJBJmBYWA();
					}
				}
			}

			public readonly int id;

			public readonly string name;

			public readonly ControllerElementType type;

			internal wqDQTLzJJBJSuEzjMNYQEqgZWANgA kKavfnYOUDcdFrwQoHDHuIVRFcAEA;

			internal int eUwqiczNEObenThGbZsvqmCniEEN;

			internal Controller CsSUsnRKrAqtNSEfgAkMekrbRwsrA;

			internal readonly int lkKoESGkiUBVTbpJpAAvansZmSHj;

			private CompoundElement KIpTSioakMBEPGWBWhhmLHqiYCvMA;

			public ControllerElementIdentifier elementIdentifier
			{
				get
				{
					if (ReInput._id != lkKoESGkiUBVTbpJpAAvansZmSHj)
					{
						ReInput.CheckInitialized(lkKoESGkiUBVTbpJpAAvansZmSHj);
						return null;
					}
					ControllerElementIdentifier elementIdentifierById = CsSUsnRKrAqtNSEfgAkMekrbRwsrA.GetElementIdentifierById(id);
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
					if (ReInput._id != lkKoESGkiUBVTbpJpAAvansZmSHj)
					{
						ReInput.CheckInitialized(lkKoESGkiUBVTbpJpAAvansZmSHj);
						return false;
					}
					return eUwqiczNEObenThGbZsvqmCniEEN > 0;
				}
			}

			public CompoundElement compoundElement => KIpTSioakMBEPGWBWhhmLHqiYCvMA;

			internal Element(Controller P_0, int P_1, string P_2, ControllerElementType P_3)
			{
				CsSUsnRKrAqtNSEfgAkMekrbRwsrA = P_0;
				id = P_1;
				name = P_2;
				type = P_3;
				lkKoESGkiUBVTbpJpAAvansZmSHj = ReInput.id;
			}

			public void Reset()
			{
				if (ReInput._id != lkKoESGkiUBVTbpJpAAvansZmSHj)
				{
					ReInput.CheckInitialized(lkKoESGkiUBVTbpJpAAvansZmSHj);
				}
				else if (kKavfnYOUDcdFrwQoHDHuIVRFcAEA != null)
				{
					kKavfnYOUDcdFrwQoHDHuIVRFcAEA.RRlmhtbUdbnkFuBtEwBERLGrjBcd();
				}
			}

			internal void vDAUPRveAFVjsIRYfPJWADCJkzNv(CompoundElement P_0)
			{
				if (eUwqiczNEObenThGbZsvqmCniEEN > 0)
				{
					Logger.LogWarning("This element is already a member of a compound element! This is not supported. Resulting values may be unpredictable.");
				}
				eUwqiczNEObenThGbZsvqmCniEEN++;
				if (KIpTSioakMBEPGWBWhhmLHqiYCvMA != null)
				{
					KIpTSioakMBEPGWBWhhmLHqiYCvMA = P_0;
				}
			}

			internal void oRzRDtlHBVYhbjUOTTqzLtfAlhMf(CompoundElement P_0)
			{
				if (eUwqiczNEObenThGbZsvqmCniEEN == 0)
				{
					Logger.LogWarning("This element is not a member of a compound element!");
					eUwqiczNEObenThGbZsvqmCniEEN = 0;
					return;
				}
				eUwqiczNEObenThGbZsvqmCniEEN--;
				if (KIpTSioakMBEPGWBWhhmLHqiYCvMA == P_0)
				{
					KIpTSioakMBEPGWBWhhmLHqiYCvMA = null;
				}
			}
		}

		public sealed class Axis : Element
		{
			internal class rJDMQWzEMNbmwJrUyNiljfOgvsuOc : wqDQTLzJJBJSuEzjMNYQEqgZWANgA
			{
				public class odPLDgqkMjigxGaGhktSEBeNjtoeb : xNUEVpUeugcpnEiaKNJSMDItEvIh
				{
					private const float aWYdDGXDZsReSYOyVeqvUKQMHGoh = 0.001f;

					public float oinMMFWPQbDdHdPZVuPWfkrlgJHy;

					public float GtREmxWNjAJybVUFsdlRFpYDImucb;

					public float jXsgKaznfDiPxyUoZDYaFJnMbxrxA;

					public float KGuwBnsbZrdOCcqAebzEnYBYcPhA;

					public float NkfRTnLBotdTlbKnztneqmTMMIhi;

					public float mvgIwipQOvxPwMBVKStbGubAThbk;

					public double QOTylAnxNCIXXDYCrdlyWOGVycoh;

					public double ofmjdviHCPdqAmrpNCAaboRabFGWB;

					public double fGICvscPlEjUNOsTlgOuCRPaZreYB;

					public double RCWjxhGUGeYKnviVPGuNHcDExuCaA;

					public double JFVfSJhltWrlUQiIzTjFTbUpyZuoA;

					public double yvQBtWcQFQZuPnGdcymqmAbvKjbQA;

					public double LeADrMJyzEADKsIafNVrWvWZcaqEb
					{
						get
						{
							if ((double)oinMMFWPQbDdHdPZVuPWfkrlgJHy == 0.0)
							{
								return 0.0;
							}
							return ReInput.unscaledTime - fGICvscPlEjUNOsTlgOuCRPaZreYB;
						}
					}

					public double UJCynyOGwtevkbclaXRNwRCNatlm
					{
						get
						{
							if ((double)jXsgKaznfDiPxyUoZDYaFJnMbxrxA == 0.0)
							{
								return 0.0;
							}
							return ReInput.unscaledTime - RCWjxhGUGeYKnviVPGuNHcDExuCaA;
						}
					}

					public double dEXkkOZxiQPegcwAybbwfeyNkBfu
					{
						get
						{
							if (oinMMFWPQbDdHdPZVuPWfkrlgJHy != 0f)
							{
								return 0.0;
							}
							return ReInput.unscaledTime - QOTylAnxNCIXXDYCrdlyWOGVycoh;
						}
					}

					public double NTHbSmzFtOOpYFerMzLMrtwsiUli
					{
						get
						{
							if ((double)jXsgKaznfDiPxyUoZDYaFJnMbxrxA != 0.0)
							{
								return 0.0;
							}
							return ReInput.unscaledTime - ofmjdviHCPdqAmrpNCAaboRabFGWB;
						}
					}

					public void JCSVAYzjWhLVUhjYvuZnHzmyqNIS(bool P_0)
					{
						double unscaledTime = ReInput.unscaledTime;
						if (P_0)
						{
							if (!MathTools.Approximately(NkfRTnLBotdTlbKnztneqmTMMIhi, 0f))
							{
								QOTylAnxNCIXXDYCrdlyWOGVycoh = unscaledTime;
							}
							else
							{
								fGICvscPlEjUNOsTlgOuCRPaZreYB = unscaledTime;
							}
							if (!MathTools.IsNear(NkfRTnLBotdTlbKnztneqmTMMIhi, mvgIwipQOvxPwMBVKStbGubAThbk, 0.001f))
							{
								JFVfSJhltWrlUQiIzTjFTbUpyZuoA = unscaledTime;
							}
						}
						else
						{
							if (!MathTools.Approximately(oinMMFWPQbDdHdPZVuPWfkrlgJHy, 0f))
							{
								QOTylAnxNCIXXDYCrdlyWOGVycoh = unscaledTime;
							}
							else
							{
								fGICvscPlEjUNOsTlgOuCRPaZreYB = unscaledTime;
							}
							if (!MathTools.IsNear(oinMMFWPQbDdHdPZVuPWfkrlgJHy, GtREmxWNjAJybVUFsdlRFpYDImucb, 0.001f))
							{
								JFVfSJhltWrlUQiIzTjFTbUpyZuoA = unscaledTime;
							}
						}
						if (!MathTools.Approximately(jXsgKaznfDiPxyUoZDYaFJnMbxrxA, 0f))
						{
							ofmjdviHCPdqAmrpNCAaboRabFGWB = unscaledTime;
						}
						else
						{
							RCWjxhGUGeYKnviVPGuNHcDExuCaA = unscaledTime;
						}
						if (!MathTools.IsNear(jXsgKaznfDiPxyUoZDYaFJnMbxrxA, KGuwBnsbZrdOCcqAebzEnYBYcPhA, 0.001f))
						{
							yvQBtWcQFQZuPnGdcymqmAbvKjbQA = unscaledTime;
						}
					}

					public void bFUYxXcDUACRjVOWCyUNBboSpyJJ(float P_0)
					{
						if (KGuwBnsbZrdOCcqAebzEnYBYcPhA != jXsgKaznfDiPxyUoZDYaFJnMbxrxA)
						{
							KGuwBnsbZrdOCcqAebzEnYBYcPhA = jXsgKaznfDiPxyUoZDYaFJnMbxrxA;
						}
						if (jXsgKaznfDiPxyUoZDYaFJnMbxrxA != P_0)
						{
							jXsgKaznfDiPxyUoZDYaFJnMbxrxA = P_0;
						}
					}

					public virtual void qYOxCYYwIJGEbzQqmEylfHYbZoBH()
					{
						oinMMFWPQbDdHdPZVuPWfkrlgJHy = 0f;
						GtREmxWNjAJybVUFsdlRFpYDImucb = 0f;
						jXsgKaznfDiPxyUoZDYaFJnMbxrxA = 0f;
						KGuwBnsbZrdOCcqAebzEnYBYcPhA = 0f;
						QOTylAnxNCIXXDYCrdlyWOGVycoh = 0.0;
						ofmjdviHCPdqAmrpNCAaboRabFGWB = 0.0;
						fGICvscPlEjUNOsTlgOuCRPaZreYB = 0.0;
						RCWjxhGUGeYKnviVPGuNHcDExuCaA = 0.0;
						JFVfSJhltWrlUQiIzTjFTbUpyZuoA = 0.0;
						yvQBtWcQFQZuPnGdcymqmAbvKjbQA = 0.0;
					}
				}

				public rJDMQWzEMNbmwJrUyNiljfOgvsuOc(UpdateLoopSetting P_0)
					: base(P_0)
				{
					for (int i = 0; i < ZATaVfnVpCMTzYIfufsuPxbbceAE; i++)
					{
						PBlarzFmGuEThNkVmmuyDQyQhskGA[i] = new odPLDgqkMjigxGaGhktSEBeNjtoeb();
					}
					JodnrCQGFSOkoJarrfSzuHtuUOJy = PBlarzFmGuEThNkVmmuyDQyQhskGA[0];
				}
			}

			internal readonly AxisRange zyVAPfbVPnOqbXoXeuhcskNqStXf;

			internal readonly HardwareAxisInfo mIchhRBlJrrWJwkTxxeMqxzcaKtO;

			public float value
			{
				get
				{
					if (ReInput._id != lkKoESGkiUBVTbpJpAAvansZmSHj)
					{
						ReInput.CheckInitialized(lkKoESGkiUBVTbpJpAAvansZmSHj);
						return 0f;
					}
					if (base.isMemberElement)
					{
						return ((rJDMQWzEMNbmwJrUyNiljfOgvsuOc.odPLDgqkMjigxGaGhktSEBeNjtoeb)kKavfnYOUDcdFrwQoHDHuIVRFcAEA.JodnrCQGFSOkoJarrfSzuHtuUOJy).NkfRTnLBotdTlbKnztneqmTMMIhi;
					}
					return ((rJDMQWzEMNbmwJrUyNiljfOgvsuOc.odPLDgqkMjigxGaGhktSEBeNjtoeb)kKavfnYOUDcdFrwQoHDHuIVRFcAEA.JodnrCQGFSOkoJarrfSzuHtuUOJy).oinMMFWPQbDdHdPZVuPWfkrlgJHy;
				}
			}

			public float valuePrev
			{
				get
				{
					if (ReInput._id != lkKoESGkiUBVTbpJpAAvansZmSHj)
					{
						ReInput.CheckInitialized(lkKoESGkiUBVTbpJpAAvansZmSHj);
						return 0f;
					}
					if (base.isMemberElement)
					{
						return ((rJDMQWzEMNbmwJrUyNiljfOgvsuOc.odPLDgqkMjigxGaGhktSEBeNjtoeb)kKavfnYOUDcdFrwQoHDHuIVRFcAEA.JodnrCQGFSOkoJarrfSzuHtuUOJy).mvgIwipQOvxPwMBVKStbGubAThbk;
					}
					return ((rJDMQWzEMNbmwJrUyNiljfOgvsuOc.odPLDgqkMjigxGaGhktSEBeNjtoeb)kKavfnYOUDcdFrwQoHDHuIVRFcAEA.JodnrCQGFSOkoJarrfSzuHtuUOJy).GtREmxWNjAJybVUFsdlRFpYDImucb;
				}
			}

			public float valueRaw
			{
				get
				{
					if (ReInput._id != lkKoESGkiUBVTbpJpAAvansZmSHj)
					{
						ReInput.CheckInitialized(lkKoESGkiUBVTbpJpAAvansZmSHj);
						return 0f;
					}
					return ((rJDMQWzEMNbmwJrUyNiljfOgvsuOc.odPLDgqkMjigxGaGhktSEBeNjtoeb)kKavfnYOUDcdFrwQoHDHuIVRFcAEA.JodnrCQGFSOkoJarrfSzuHtuUOJy).jXsgKaznfDiPxyUoZDYaFJnMbxrxA;
				}
				internal set
				{
					((rJDMQWzEMNbmwJrUyNiljfOgvsuOc.odPLDgqkMjigxGaGhktSEBeNjtoeb)kKavfnYOUDcdFrwQoHDHuIVRFcAEA.JodnrCQGFSOkoJarrfSzuHtuUOJy).bFUYxXcDUACRjVOWCyUNBboSpyJJ(num);
				}
			}

			public float valueRawPrev
			{
				get
				{
					if (ReInput._id != lkKoESGkiUBVTbpJpAAvansZmSHj)
					{
						ReInput.CheckInitialized(lkKoESGkiUBVTbpJpAAvansZmSHj);
						return 0f;
					}
					return ((rJDMQWzEMNbmwJrUyNiljfOgvsuOc.odPLDgqkMjigxGaGhktSEBeNjtoeb)kKavfnYOUDcdFrwQoHDHuIVRFcAEA.JodnrCQGFSOkoJarrfSzuHtuUOJy).KGuwBnsbZrdOCcqAebzEnYBYcPhA;
				}
			}

			public float valueDelta
			{
				get
				{
					if (ReInput._id != lkKoESGkiUBVTbpJpAAvansZmSHj)
					{
						ReInput.CheckInitialized(lkKoESGkiUBVTbpJpAAvansZmSHj);
						return 0f;
					}
					return value - valuePrev;
				}
			}

			public float valueDeltaRaw
			{
				get
				{
					if (ReInput._id != lkKoESGkiUBVTbpJpAAvansZmSHj)
					{
						ReInput.CheckInitialized(lkKoESGkiUBVTbpJpAAvansZmSHj);
						return 0f;
					}
					return ((rJDMQWzEMNbmwJrUyNiljfOgvsuOc.odPLDgqkMjigxGaGhktSEBeNjtoeb)kKavfnYOUDcdFrwQoHDHuIVRFcAEA.JodnrCQGFSOkoJarrfSzuHtuUOJy).jXsgKaznfDiPxyUoZDYaFJnMbxrxA - ((rJDMQWzEMNbmwJrUyNiljfOgvsuOc.odPLDgqkMjigxGaGhktSEBeNjtoeb)kKavfnYOUDcdFrwQoHDHuIVRFcAEA.JodnrCQGFSOkoJarrfSzuHtuUOJy).KGuwBnsbZrdOCcqAebzEnYBYcPhA;
				}
			}

			public double lastTimeActive
			{
				get
				{
					if (ReInput._id != lkKoESGkiUBVTbpJpAAvansZmSHj)
					{
						ReInput.CheckInitialized(lkKoESGkiUBVTbpJpAAvansZmSHj);
						return 0.0;
					}
					return ((rJDMQWzEMNbmwJrUyNiljfOgvsuOc.odPLDgqkMjigxGaGhktSEBeNjtoeb)kKavfnYOUDcdFrwQoHDHuIVRFcAEA.JodnrCQGFSOkoJarrfSzuHtuUOJy).QOTylAnxNCIXXDYCrdlyWOGVycoh;
				}
			}

			public double lastTimeActiveRaw
			{
				get
				{
					if (ReInput._id != lkKoESGkiUBVTbpJpAAvansZmSHj)
					{
						ReInput.CheckInitialized(lkKoESGkiUBVTbpJpAAvansZmSHj);
						return 0.0;
					}
					return ((rJDMQWzEMNbmwJrUyNiljfOgvsuOc.odPLDgqkMjigxGaGhktSEBeNjtoeb)kKavfnYOUDcdFrwQoHDHuIVRFcAEA.JodnrCQGFSOkoJarrfSzuHtuUOJy).ofmjdviHCPdqAmrpNCAaboRabFGWB;
				}
			}

			public double lastTimeInactive
			{
				get
				{
					if (ReInput._id != lkKoESGkiUBVTbpJpAAvansZmSHj)
					{
						ReInput.CheckInitialized(lkKoESGkiUBVTbpJpAAvansZmSHj);
						return 0.0;
					}
					return ((rJDMQWzEMNbmwJrUyNiljfOgvsuOc.odPLDgqkMjigxGaGhktSEBeNjtoeb)kKavfnYOUDcdFrwQoHDHuIVRFcAEA.JodnrCQGFSOkoJarrfSzuHtuUOJy).fGICvscPlEjUNOsTlgOuCRPaZreYB;
				}
			}

			public double lastTimeInactiveRaw
			{
				get
				{
					if (ReInput._id != lkKoESGkiUBVTbpJpAAvansZmSHj)
					{
						ReInput.CheckInitialized(lkKoESGkiUBVTbpJpAAvansZmSHj);
						return 0.0;
					}
					return ((rJDMQWzEMNbmwJrUyNiljfOgvsuOc.odPLDgqkMjigxGaGhktSEBeNjtoeb)kKavfnYOUDcdFrwQoHDHuIVRFcAEA.JodnrCQGFSOkoJarrfSzuHtuUOJy).RCWjxhGUGeYKnviVPGuNHcDExuCaA;
				}
			}

			public double lastTimeValueChanged
			{
				get
				{
					if (ReInput._id != lkKoESGkiUBVTbpJpAAvansZmSHj)
					{
						ReInput.CheckInitialized(lkKoESGkiUBVTbpJpAAvansZmSHj);
						return 0.0;
					}
					return ((rJDMQWzEMNbmwJrUyNiljfOgvsuOc.odPLDgqkMjigxGaGhktSEBeNjtoeb)kKavfnYOUDcdFrwQoHDHuIVRFcAEA.JodnrCQGFSOkoJarrfSzuHtuUOJy).JFVfSJhltWrlUQiIzTjFTbUpyZuoA;
				}
			}

			public double lastTimeValueChangedRaw
			{
				get
				{
					if (ReInput._id != lkKoESGkiUBVTbpJpAAvansZmSHj)
					{
						ReInput.CheckInitialized(lkKoESGkiUBVTbpJpAAvansZmSHj);
						return 0.0;
					}
					return ((rJDMQWzEMNbmwJrUyNiljfOgvsuOc.odPLDgqkMjigxGaGhktSEBeNjtoeb)kKavfnYOUDcdFrwQoHDHuIVRFcAEA.JodnrCQGFSOkoJarrfSzuHtuUOJy).yvQBtWcQFQZuPnGdcymqmAbvKjbQA;
				}
			}

			public double timeActive
			{
				get
				{
					if (ReInput._id != lkKoESGkiUBVTbpJpAAvansZmSHj)
					{
						ReInput.CheckInitialized(lkKoESGkiUBVTbpJpAAvansZmSHj);
						return 0.0;
					}
					return ((rJDMQWzEMNbmwJrUyNiljfOgvsuOc.odPLDgqkMjigxGaGhktSEBeNjtoeb)kKavfnYOUDcdFrwQoHDHuIVRFcAEA.JodnrCQGFSOkoJarrfSzuHtuUOJy).LeADrMJyzEADKsIafNVrWvWZcaqEb;
				}
			}

			public double timeActiveRaw
			{
				get
				{
					if (ReInput._id != lkKoESGkiUBVTbpJpAAvansZmSHj)
					{
						ReInput.CheckInitialized(lkKoESGkiUBVTbpJpAAvansZmSHj);
						return 0.0;
					}
					return ((rJDMQWzEMNbmwJrUyNiljfOgvsuOc.odPLDgqkMjigxGaGhktSEBeNjtoeb)kKavfnYOUDcdFrwQoHDHuIVRFcAEA.JodnrCQGFSOkoJarrfSzuHtuUOJy).LeADrMJyzEADKsIafNVrWvWZcaqEb;
				}
			}

			public double timeInactive
			{
				get
				{
					if (ReInput._id != lkKoESGkiUBVTbpJpAAvansZmSHj)
					{
						ReInput.CheckInitialized(lkKoESGkiUBVTbpJpAAvansZmSHj);
						return 0.0;
					}
					return ((rJDMQWzEMNbmwJrUyNiljfOgvsuOc.odPLDgqkMjigxGaGhktSEBeNjtoeb)kKavfnYOUDcdFrwQoHDHuIVRFcAEA.JodnrCQGFSOkoJarrfSzuHtuUOJy).dEXkkOZxiQPegcwAybbwfeyNkBfu;
				}
			}

			public double timeInactiveRaw
			{
				get
				{
					if (ReInput._id != lkKoESGkiUBVTbpJpAAvansZmSHj)
					{
						ReInput.CheckInitialized(lkKoESGkiUBVTbpJpAAvansZmSHj);
						return 0.0;
					}
					return ((rJDMQWzEMNbmwJrUyNiljfOgvsuOc.odPLDgqkMjigxGaGhktSEBeNjtoeb)kKavfnYOUDcdFrwQoHDHuIVRFcAEA.JodnrCQGFSOkoJarrfSzuHtuUOJy).NTHbSmzFtOOpYFerMzLMrtwsiUli;
				}
			}

			public float pollingDeadZone
			{
				get
				{
					if (ReInput._id != lkKoESGkiUBVTbpJpAAvansZmSHj)
					{
						ReInput.CheckInitialized(lkKoESGkiUBVTbpJpAAvansZmSHj);
						return 0f;
					}
					if (mIchhRBlJrrWJwkTxxeMqxzcaKtO == null)
					{
						return -1f;
					}
					return mIchhRBlJrrWJwkTxxeMqxzcaKtO._pollingDeadZone;
				}
				set
				{
					if (ReInput._id != lkKoESGkiUBVTbpJpAAvansZmSHj)
					{
						ReInput.CheckInitialized(lkKoESGkiUBVTbpJpAAvansZmSHj);
						return;
					}
					if (value < 0f)
					{
						value = -1f;
					}
					if (mIchhRBlJrrWJwkTxxeMqxzcaKtO != null)
					{
						mIchhRBlJrrWJwkTxxeMqxzcaKtO._pollingDeadZone = value;
					}
				}
			}

			internal float AhLZiaPyeOkTpgfhTjrxAzzrjiFbA => ((rJDMQWzEMNbmwJrUyNiljfOgvsuOc.odPLDgqkMjigxGaGhktSEBeNjtoeb)kKavfnYOUDcdFrwQoHDHuIVRFcAEA.JodnrCQGFSOkoJarrfSzuHtuUOJy).oinMMFWPQbDdHdPZVuPWfkrlgJHy;

			internal float LmVkYzKIpjmPkBToTQwsFeLtvXVR => ((rJDMQWzEMNbmwJrUyNiljfOgvsuOc.odPLDgqkMjigxGaGhktSEBeNjtoeb)kKavfnYOUDcdFrwQoHDHuIVRFcAEA.JodnrCQGFSOkoJarrfSzuHtuUOJy).GtREmxWNjAJybVUFsdlRFpYDImucb;

			internal float GZzcNiDwCSefGXRigFePGjvNjfbIb
			{
				get
				{
					if (mIchhRBlJrrWJwkTxxeMqxzcaKtO == null)
					{
						return ReInput.configuration.defaultAbsoluteAxisPollingDeadZone;
					}
					if (mIchhRBlJrrWJwkTxxeMqxzcaKtO._pollingDeadZone >= 0f)
					{
						return mIchhRBlJrrWJwkTxxeMqxzcaKtO._pollingDeadZone;
					}
					return mIchhRBlJrrWJwkTxxeMqxzcaKtO._dataFormat switch
					{
						AxisCoordinateMode.Absolute => ReInput.configuration.defaultAbsoluteAxisPollingDeadZone, 
						AxisCoordinateMode.Relative => ReInput.configuration.defaultRelativeAxisPollingDeadZone, 
						_ => throw new NotImplementedException(), 
					};
				}
			}

			internal void XThcEyoxCsxHBUFXXyxunQOYWAzV(float P_0)
			{
				rJDMQWzEMNbmwJrUyNiljfOgvsuOc.odPLDgqkMjigxGaGhktSEBeNjtoeb obj = (rJDMQWzEMNbmwJrUyNiljfOgvsuOc.odPLDgqkMjigxGaGhktSEBeNjtoeb)kKavfnYOUDcdFrwQoHDHuIVRFcAEA.JodnrCQGFSOkoJarrfSzuHtuUOJy;
				obj.mvgIwipQOvxPwMBVKStbGubAThbk = obj.NkfRTnLBotdTlbKnztneqmTMMIhi;
				obj.NkfRTnLBotdTlbKnztneqmTMMIhi = P_0;
			}

			internal Axis(Controller P_0, int P_1, string P_2, AxisRange P_3, HardwareAxisInfo P_4)
				: base(P_0, P_1, P_2, ControllerElementType.Axis)
			{
				kKavfnYOUDcdFrwQoHDHuIVRFcAEA = new rJDMQWzEMNbmwJrUyNiljfOgvsuOc(ReInput.configVars.updateLoop);
				zyVAPfbVPnOqbXoXeuhcskNqStXf = P_3;
				mIchhRBlJrrWJwkTxxeMqxzcaKtO = P_4;
			}

			internal void cwgBvagbbtfHaAWcDEXlzshQrlIdb(UpdateLoopType P_0)
			{
				if (kKavfnYOUDcdFrwQoHDHuIVRFcAEA != null && kKavfnYOUDcdFrwQoHDHuIVRFcAEA.gRoycAQDkxuKqHfKTnoDRAaDJyDm != (int)P_0)
				{
					kKavfnYOUDcdFrwQoHDHuIVRFcAEA.eYRBzfNOIqpsrqwJOgPMGldxPZZq = P_0;
				}
			}

			internal void MdeUKqaoMIfmvpCOxxKZkFUIdrDbA(AxisCalibration P_0)
			{
				rJDMQWzEMNbmwJrUyNiljfOgvsuOc.odPLDgqkMjigxGaGhktSEBeNjtoeb odPLDgqkMjigxGaGhktSEBeNjtoeb = (rJDMQWzEMNbmwJrUyNiljfOgvsuOc.odPLDgqkMjigxGaGhktSEBeNjtoeb)kKavfnYOUDcdFrwQoHDHuIVRFcAEA.JodnrCQGFSOkoJarrfSzuHtuUOJy;
				odPLDgqkMjigxGaGhktSEBeNjtoeb.GtREmxWNjAJybVUFsdlRFpYDImucb = odPLDgqkMjigxGaGhktSEBeNjtoeb.oinMMFWPQbDdHdPZVuPWfkrlgJHy;
				float oinMMFWPQbDdHdPZVuPWfkrlgJHy = P_0.GetCalibratedValue(odPLDgqkMjigxGaGhktSEBeNjtoeb.jXsgKaznfDiPxyUoZDYaFJnMbxrxA, zyVAPfbVPnOqbXoXeuhcskNqStXf);
				if (P_0.applyRangeCalibration)
				{
					oinMMFWPQbDdHdPZVuPWfkrlgJHy = MathTools.Clamp(oinMMFWPQbDdHdPZVuPWfkrlgJHy, -1f, 1f);
				}
				odPLDgqkMjigxGaGhktSEBeNjtoeb.oinMMFWPQbDdHdPZVuPWfkrlgJHy = oinMMFWPQbDdHdPZVuPWfkrlgJHy;
			}

			internal void RiIBAeehdxIRrCOACdzQEvHggYcX()
			{
				rJDMQWzEMNbmwJrUyNiljfOgvsuOc.odPLDgqkMjigxGaGhktSEBeNjtoeb obj = (rJDMQWzEMNbmwJrUyNiljfOgvsuOc.odPLDgqkMjigxGaGhktSEBeNjtoeb)kKavfnYOUDcdFrwQoHDHuIVRFcAEA.JodnrCQGFSOkoJarrfSzuHtuUOJy;
				obj.GtREmxWNjAJybVUFsdlRFpYDImucb = obj.oinMMFWPQbDdHdPZVuPWfkrlgJHy;
				obj.oinMMFWPQbDdHdPZVuPWfkrlgJHy = obj.jXsgKaznfDiPxyUoZDYaFJnMbxrxA;
			}

			internal void VIIDcHbIMFDDFPJQOxOtrpximIHvA()
			{
				rJDMQWzEMNbmwJrUyNiljfOgvsuOc.odPLDgqkMjigxGaGhktSEBeNjtoeb obj = (rJDMQWzEMNbmwJrUyNiljfOgvsuOc.odPLDgqkMjigxGaGhktSEBeNjtoeb)kKavfnYOUDcdFrwQoHDHuIVRFcAEA.JodnrCQGFSOkoJarrfSzuHtuUOJy;
				obj.GtREmxWNjAJybVUFsdlRFpYDImucb = obj.oinMMFWPQbDdHdPZVuPWfkrlgJHy;
				obj.oinMMFWPQbDdHdPZVuPWfkrlgJHy = 0f;
			}

			internal void kroXwPZXmIeUiDtvouBbfSikkTCr()
			{
				((rJDMQWzEMNbmwJrUyNiljfOgvsuOc.odPLDgqkMjigxGaGhktSEBeNjtoeb)kKavfnYOUDcdFrwQoHDHuIVRFcAEA.JodnrCQGFSOkoJarrfSzuHtuUOJy).JCSVAYzjWhLVUhjYvuZnHzmyqNIS(base.isMemberElement);
			}

			internal void BaphXhNOxPxasXJFBHsxHnLhkXXab(float P_0)
			{
				for (int i = 0; i < kKavfnYOUDcdFrwQoHDHuIVRFcAEA.nuNKeFIFiULhPPkzIxoBhdZODJkcA.Count; i++)
				{
					if (kKavfnYOUDcdFrwQoHDHuIVRFcAEA.nuNKeFIFiULhPPkzIxoBhdZODJkcA[i] is rJDMQWzEMNbmwJrUyNiljfOgvsuOc.odPLDgqkMjigxGaGhktSEBeNjtoeb odPLDgqkMjigxGaGhktSEBeNjtoeb)
					{
						odPLDgqkMjigxGaGhktSEBeNjtoeb.bFUYxXcDUACRjVOWCyUNBboSpyJJ(P_0);
						odPLDgqkMjigxGaGhktSEBeNjtoeb.GtREmxWNjAJybVUFsdlRFpYDImucb = odPLDgqkMjigxGaGhktSEBeNjtoeb.oinMMFWPQbDdHdPZVuPWfkrlgJHy;
						odPLDgqkMjigxGaGhktSEBeNjtoeb.oinMMFWPQbDdHdPZVuPWfkrlgJHy = 0f;
						odPLDgqkMjigxGaGhktSEBeNjtoeb.JCSVAYzjWhLVUhjYvuZnHzmyqNIS(base.isMemberElement);
					}
				}
			}

			internal float JvvXELyjPIiUSvVIxVJevEnSwYGu(UpdateLoopType P_0, AxisCalibration P_1)
			{
				rJDMQWzEMNbmwJrUyNiljfOgvsuOc.odPLDgqkMjigxGaGhktSEBeNjtoeb odPLDgqkMjigxGaGhktSEBeNjtoeb = (rJDMQWzEMNbmwJrUyNiljfOgvsuOc.odPLDgqkMjigxGaGhktSEBeNjtoeb)kKavfnYOUDcdFrwQoHDHuIVRFcAEA.nuNKeFIFiULhPPkzIxoBhdZODJkcA[(int)P_0];
				float result = P_1.GetCalibratedValue(odPLDgqkMjigxGaGhktSEBeNjtoeb.jXsgKaznfDiPxyUoZDYaFJnMbxrxA, zyVAPfbVPnOqbXoXeuhcskNqStXf, P_1.deadZone, applySensitivity: false, applyInversion: true);
				if (P_1.applyRangeCalibration)
				{
					result = MathTools.Clamp(result, -1f, 1f);
				}
				return result;
			}
		}

		public sealed class Button : Element
		{
			internal class eEGJOTPSXomLNvMIFkTjzRorYqs : wqDQTLzJJBJSuEzjMNYQEqgZWANgA
			{
				public class UCmSuvkJWdJnjogrlGvqBMofNzgi : xNUEVpUeugcpnEiaKNJSMDItEvIh
				{
					public bool vtUIbNNegTCcmODMydGAKqGLKiEu;

					public bool gPWsRQrltAMeXAUnEGWIKiYpMVMM;

					public ButtonStateRecorder BhIiLNyJnAAjsesZzccbEGPwlQhNA;

					public limsGLzeSkALkkWGCKGuOWLjeqOk ahSnYdCHGQrCOZjQYXCLJliXwmmh;

					public UCmSuvkJWdJnjogrlGvqBMofNzgi()
					{
						BhIiLNyJnAAjsesZzccbEGPwlQhNA = new ButtonStateRecorder();
						ahSnYdCHGQrCOZjQYXCLJliXwmmh = new limsGLzeSkALkkWGCKGuOWLjeqOk(0.3f);
					}

					public void QLjKjqOHtYsaMMNCDVQCBCTQJeOG(bool P_0)
					{
						if (gPWsRQrltAMeXAUnEGWIKiYpMVMM != vtUIbNNegTCcmODMydGAKqGLKiEu)
						{
							gPWsRQrltAMeXAUnEGWIKiYpMVMM = vtUIbNNegTCcmODMydGAKqGLKiEu;
						}
						if (vtUIbNNegTCcmODMydGAKqGLKiEu != P_0)
						{
							vtUIbNNegTCcmODMydGAKqGLKiEu = P_0;
						}
						BhIiLNyJnAAjsesZzccbEGPwlQhNA.LeLLqzvHsmHpfCGhLbczHbZUefGD(P_0 && !gPWsRQrltAMeXAUnEGWIKiYpMVMM, P_0, ReInput.unscaledTime);
						ahSnYdCHGQrCOZjQYXCLJliXwmmh.rosfjIIztGAxyIAqFnETysaqNzqLA(0.3f, P_0 && !gPWsRQrltAMeXAUnEGWIKiYpMVMM, P_0);
					}

					public virtual void PdFIbvIbkCalSohhpzpWUYaQefTv()
					{
						vtUIbNNegTCcmODMydGAKqGLKiEu = false;
						gPWsRQrltAMeXAUnEGWIKiYpMVMM = false;
						BhIiLNyJnAAjsesZzccbEGPwlQhNA.xRjvepTcuQcSGDTnRoDDeivdQTeBb();
						ahSnYdCHGQrCOZjQYXCLJliXwmmh.IYqWErLijeVulOmEehdAfOzbFeKgb();
					}
				}

				public class HEjZFFozFVjneqdYEExLAUAyAsRH : UCmSuvkJWdJnjogrlGvqBMofNzgi
				{
					public float BayrqKfgNkIdyYJGSaEINqKqWnwQ;

					public float bPFHQMbnothssjGBbgpztidpgHYgb;

					public void XiZdmqjkzqLdJZVtFfcHhNpFIlEnA(float P_0)
					{
						if (bPFHQMbnothssjGBbgpztidpgHYgb != BayrqKfgNkIdyYJGSaEINqKqWnwQ)
						{
							bPFHQMbnothssjGBbgpztidpgHYgb = BayrqKfgNkIdyYJGSaEINqKqWnwQ;
						}
						if (BayrqKfgNkIdyYJGSaEINqKqWnwQ != P_0)
						{
							BayrqKfgNkIdyYJGSaEINqKqWnwQ = ((P_0 > 0.001f) ? P_0 : 0f);
						}
						QLjKjqOHtYsaMMNCDVQCBCTQJeOG(BayrqKfgNkIdyYJGSaEINqKqWnwQ > 0f);
					}

					public virtual void PzdlsCsktpbcbiHjFyBSYFuUfOekA()
					{
						PdFIbvIbkCalSohhpzpWUYaQefTv();
						BayrqKfgNkIdyYJGSaEINqKqWnwQ = 0f;
						bPFHQMbnothssjGBbgpztidpgHYgb = 0f;
					}
				}

				public eEGJOTPSXomLNvMIFkTjzRorYqs(UpdateLoopSetting P_0, bool P_1)
					: base(P_0)
				{
					for (int i = 0; i < ZATaVfnVpCMTzYIfufsuPxbbceAE; i++)
					{
						if (P_1)
						{
							PBlarzFmGuEThNkVmmuyDQyQhskGA[i] = new HEjZFFozFVjneqdYEExLAUAyAsRH();
						}
						else
						{
							PBlarzFmGuEThNkVmmuyDQyQhskGA[i] = new UCmSuvkJWdJnjogrlGvqBMofNzgi();
						}
					}
					JodnrCQGFSOkoJarrfSzuHtuUOJy = PBlarzFmGuEThNkVmmuyDQyQhskGA[0];
				}

				public void IdrilRHcGJkYPhbraXtEuqoHQtQcA(float P_0)
				{
					for (int i = 0; i < PBlarzFmGuEThNkVmmuyDQyQhskGA.Length; i++)
					{
						((UCmSuvkJWdJnjogrlGvqBMofNzgi)PBlarzFmGuEThNkVmmuyDQyQhskGA[i]).ahSnYdCHGQrCOZjQYXCLJliXwmmh.NFOjByUOuqGdMjsMKTxFOomaXFsp(P_0);
					}
				}

				public void tcDkqwWIYdIcHStcejrCMzhrQLuq()
				{
					for (int i = 0; i < PBlarzFmGuEThNkVmmuyDQyQhskGA.Length; i++)
					{
						((UCmSuvkJWdJnjogrlGvqBMofNzgi)PBlarzFmGuEThNkVmmuyDQyQhskGA[i]).ahSnYdCHGQrCOZjQYXCLJliXwmmh.NFOjByUOuqGdMjsMKTxFOomaXFsp(0.3f);
					}
				}
			}

			internal readonly bool vMphZPguDDJgBklIksBgEHUMzlPm;

			internal readonly HardwareButtonInfo aSUKMgcrEWfMhhOukDBcFEBiIpQjb;

			public bool valuePrev
			{
				get
				{
					if (ReInput._id != lkKoESGkiUBVTbpJpAAvansZmSHj)
					{
						ReInput.CheckInitialized(lkKoESGkiUBVTbpJpAAvansZmSHj);
						return false;
					}
					return ((eEGJOTPSXomLNvMIFkTjzRorYqs.UCmSuvkJWdJnjogrlGvqBMofNzgi)kKavfnYOUDcdFrwQoHDHuIVRFcAEA.JodnrCQGFSOkoJarrfSzuHtuUOJy).gPWsRQrltAMeXAUnEGWIKiYpMVMM;
				}
			}

			public bool value
			{
				get
				{
					if (ReInput._id != lkKoESGkiUBVTbpJpAAvansZmSHj)
					{
						ReInput.CheckInitialized(lkKoESGkiUBVTbpJpAAvansZmSHj);
						return false;
					}
					return ((eEGJOTPSXomLNvMIFkTjzRorYqs.UCmSuvkJWdJnjogrlGvqBMofNzgi)kKavfnYOUDcdFrwQoHDHuIVRFcAEA.JodnrCQGFSOkoJarrfSzuHtuUOJy).vtUIbNNegTCcmODMydGAKqGLKiEu;
				}
			}

			public float pressure
			{
				get
				{
					if (ReInput._id != lkKoESGkiUBVTbpJpAAvansZmSHj)
					{
						ReInput.CheckInitialized(lkKoESGkiUBVTbpJpAAvansZmSHj);
						return 0f;
					}
					if (!vMphZPguDDJgBklIksBgEHUMzlPm)
					{
						if (!((eEGJOTPSXomLNvMIFkTjzRorYqs.UCmSuvkJWdJnjogrlGvqBMofNzgi)kKavfnYOUDcdFrwQoHDHuIVRFcAEA.JodnrCQGFSOkoJarrfSzuHtuUOJy).vtUIbNNegTCcmODMydGAKqGLKiEu)
						{
							return 0f;
						}
						return 1f;
					}
					return ((eEGJOTPSXomLNvMIFkTjzRorYqs.HEjZFFozFVjneqdYEExLAUAyAsRH)kKavfnYOUDcdFrwQoHDHuIVRFcAEA.JodnrCQGFSOkoJarrfSzuHtuUOJy).BayrqKfgNkIdyYJGSaEINqKqWnwQ;
				}
			}

			public float pressurePrev
			{
				get
				{
					if (ReInput._id != lkKoESGkiUBVTbpJpAAvansZmSHj)
					{
						ReInput.CheckInitialized(lkKoESGkiUBVTbpJpAAvansZmSHj);
						return 0f;
					}
					if (!vMphZPguDDJgBklIksBgEHUMzlPm)
					{
						if (!((eEGJOTPSXomLNvMIFkTjzRorYqs.UCmSuvkJWdJnjogrlGvqBMofNzgi)kKavfnYOUDcdFrwQoHDHuIVRFcAEA.JodnrCQGFSOkoJarrfSzuHtuUOJy).gPWsRQrltAMeXAUnEGWIKiYpMVMM)
						{
							return 0f;
						}
						return 1f;
					}
					return ((eEGJOTPSXomLNvMIFkTjzRorYqs.HEjZFFozFVjneqdYEExLAUAyAsRH)kKavfnYOUDcdFrwQoHDHuIVRFcAEA.JodnrCQGFSOkoJarrfSzuHtuUOJy).bPFHQMbnothssjGBbgpztidpgHYgb;
				}
			}

			public bool isPressureSensitive
			{
				get
				{
					if (ReInput._id != lkKoESGkiUBVTbpJpAAvansZmSHj)
					{
						ReInput.CheckInitialized(lkKoESGkiUBVTbpJpAAvansZmSHj);
						return false;
					}
					return vMphZPguDDJgBklIksBgEHUMzlPm;
				}
			}

			public bool justPressed
			{
				get
				{
					if (ReInput._id != lkKoESGkiUBVTbpJpAAvansZmSHj)
					{
						ReInput.CheckInitialized(lkKoESGkiUBVTbpJpAAvansZmSHj);
						return false;
					}
					if (!((eEGJOTPSXomLNvMIFkTjzRorYqs.UCmSuvkJWdJnjogrlGvqBMofNzgi)kKavfnYOUDcdFrwQoHDHuIVRFcAEA.JodnrCQGFSOkoJarrfSzuHtuUOJy).gPWsRQrltAMeXAUnEGWIKiYpMVMM && ((eEGJOTPSXomLNvMIFkTjzRorYqs.UCmSuvkJWdJnjogrlGvqBMofNzgi)kKavfnYOUDcdFrwQoHDHuIVRFcAEA.JodnrCQGFSOkoJarrfSzuHtuUOJy).vtUIbNNegTCcmODMydGAKqGLKiEu)
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
					if (ReInput._id != lkKoESGkiUBVTbpJpAAvansZmSHj)
					{
						ReInput.CheckInitialized(lkKoESGkiUBVTbpJpAAvansZmSHj);
						return false;
					}
					if (((eEGJOTPSXomLNvMIFkTjzRorYqs.UCmSuvkJWdJnjogrlGvqBMofNzgi)kKavfnYOUDcdFrwQoHDHuIVRFcAEA.JodnrCQGFSOkoJarrfSzuHtuUOJy).gPWsRQrltAMeXAUnEGWIKiYpMVMM && !((eEGJOTPSXomLNvMIFkTjzRorYqs.UCmSuvkJWdJnjogrlGvqBMofNzgi)kKavfnYOUDcdFrwQoHDHuIVRFcAEA.JodnrCQGFSOkoJarrfSzuHtuUOJy).vtUIbNNegTCcmODMydGAKqGLKiEu)
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
					if (ReInput._id != lkKoESGkiUBVTbpJpAAvansZmSHj)
					{
						ReInput.CheckInitialized(lkKoESGkiUBVTbpJpAAvansZmSHj);
						return false;
					}
					if (((eEGJOTPSXomLNvMIFkTjzRorYqs.UCmSuvkJWdJnjogrlGvqBMofNzgi)kKavfnYOUDcdFrwQoHDHuIVRFcAEA.JodnrCQGFSOkoJarrfSzuHtuUOJy).gPWsRQrltAMeXAUnEGWIKiYpMVMM != ((eEGJOTPSXomLNvMIFkTjzRorYqs.UCmSuvkJWdJnjogrlGvqBMofNzgi)kKavfnYOUDcdFrwQoHDHuIVRFcAEA.JodnrCQGFSOkoJarrfSzuHtuUOJy).vtUIbNNegTCcmODMydGAKqGLKiEu)
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
					if (ReInput._id != lkKoESGkiUBVTbpJpAAvansZmSHj)
					{
						ReInput.CheckInitialized(lkKoESGkiUBVTbpJpAAvansZmSHj);
						return false;
					}
					return ((eEGJOTPSXomLNvMIFkTjzRorYqs.UCmSuvkJWdJnjogrlGvqBMofNzgi)kKavfnYOUDcdFrwQoHDHuIVRFcAEA.JodnrCQGFSOkoJarrfSzuHtuUOJy).ahSnYdCHGQrCOZjQYXCLJliXwmmh.snNWJTOvQvnFnfTKMpAcWbCgEwjCA;
				}
			}

			public bool justDoublePressed
			{
				get
				{
					if (ReInput._id != lkKoESGkiUBVTbpJpAAvansZmSHj)
					{
						ReInput.CheckInitialized(lkKoESGkiUBVTbpJpAAvansZmSHj);
						return false;
					}
					if (!justPressed)
					{
						return false;
					}
					return ((eEGJOTPSXomLNvMIFkTjzRorYqs.UCmSuvkJWdJnjogrlGvqBMofNzgi)kKavfnYOUDcdFrwQoHDHuIVRFcAEA.JodnrCQGFSOkoJarrfSzuHtuUOJy).ahSnYdCHGQrCOZjQYXCLJliXwmmh.snNWJTOvQvnFnfTKMpAcWbCgEwjCA;
				}
			}

			public double timePressed
			{
				get
				{
					if (ReInput._id != lkKoESGkiUBVTbpJpAAvansZmSHj)
					{
						ReInput.CheckInitialized(lkKoESGkiUBVTbpJpAAvansZmSHj);
						return 0.0;
					}
					return ((eEGJOTPSXomLNvMIFkTjzRorYqs.UCmSuvkJWdJnjogrlGvqBMofNzgi)kKavfnYOUDcdFrwQoHDHuIVRFcAEA.JodnrCQGFSOkoJarrfSzuHtuUOJy).BhIiLNyJnAAjsesZzccbEGPwlQhNA.jjDsGKSMzhrJTzuxOTiOhsoMLbzx;
				}
			}

			public double timeUnpressed
			{
				get
				{
					if (ReInput._id != lkKoESGkiUBVTbpJpAAvansZmSHj)
					{
						ReInput.CheckInitialized(lkKoESGkiUBVTbpJpAAvansZmSHj);
						return 0.0;
					}
					return ((eEGJOTPSXomLNvMIFkTjzRorYqs.UCmSuvkJWdJnjogrlGvqBMofNzgi)kKavfnYOUDcdFrwQoHDHuIVRFcAEA.JodnrCQGFSOkoJarrfSzuHtuUOJy).BhIiLNyJnAAjsesZzccbEGPwlQhNA.HvPqgbDHOfGVSjImhGmCkbzXpNMWA;
				}
			}

			public double lastTimePressed
			{
				get
				{
					if (ReInput._id != lkKoESGkiUBVTbpJpAAvansZmSHj)
					{
						ReInput.CheckInitialized(lkKoESGkiUBVTbpJpAAvansZmSHj);
						return 0.0;
					}
					return ((eEGJOTPSXomLNvMIFkTjzRorYqs.UCmSuvkJWdJnjogrlGvqBMofNzgi)kKavfnYOUDcdFrwQoHDHuIVRFcAEA.JodnrCQGFSOkoJarrfSzuHtuUOJy).BhIiLNyJnAAjsesZzccbEGPwlQhNA.FWpynWpaIAfpzFAUncvCDXRGemAMb;
				}
			}

			public double lastTimeUnpressed
			{
				get
				{
					if (ReInput._id != lkKoESGkiUBVTbpJpAAvansZmSHj)
					{
						ReInput.CheckInitialized(lkKoESGkiUBVTbpJpAAvansZmSHj);
						return 0.0;
					}
					return ((eEGJOTPSXomLNvMIFkTjzRorYqs.UCmSuvkJWdJnjogrlGvqBMofNzgi)kKavfnYOUDcdFrwQoHDHuIVRFcAEA.JodnrCQGFSOkoJarrfSzuHtuUOJy).BhIiLNyJnAAjsesZzccbEGPwlQhNA.ZygCzkDtGFwXGYuHfbzHDgJMDOTiA;
				}
			}

			public double lastTimeStateChanged
			{
				get
				{
					if (ReInput._id != lkKoESGkiUBVTbpJpAAvansZmSHj)
					{
						ReInput.CheckInitialized(lkKoESGkiUBVTbpJpAAvansZmSHj);
						return 0.0;
					}
					return ((eEGJOTPSXomLNvMIFkTjzRorYqs.UCmSuvkJWdJnjogrlGvqBMofNzgi)kKavfnYOUDcdFrwQoHDHuIVRFcAEA.JodnrCQGFSOkoJarrfSzuHtuUOJy).BhIiLNyJnAAjsesZzccbEGPwlQhNA.RRblZSgzwejVHeeGTCYzgCbgbPdvA;
				}
			}

			internal ButtonStateFlags OdxRneCcNzIlXRkJHBTfUxnuJnfR
			{
				get
				{
					eEGJOTPSXomLNvMIFkTjzRorYqs.UCmSuvkJWdJnjogrlGvqBMofNzgi uCmSuvkJWdJnjogrlGvqBMofNzgi = (eEGJOTPSXomLNvMIFkTjzRorYqs.UCmSuvkJWdJnjogrlGvqBMofNzgi)kKavfnYOUDcdFrwQoHDHuIVRFcAEA.JodnrCQGFSOkoJarrfSzuHtuUOJy;
					ButtonStateFlags buttonStateFlags = ButtonStateFlags.Off;
					if (uCmSuvkJWdJnjogrlGvqBMofNzgi.vtUIbNNegTCcmODMydGAKqGLKiEu)
					{
						buttonStateFlags |= ButtonStateFlags.On;
						if (!uCmSuvkJWdJnjogrlGvqBMofNzgi.gPWsRQrltAMeXAUnEGWIKiYpMVMM)
						{
							buttonStateFlags |= ButtonStateFlags.Down;
						}
					}
					else if (uCmSuvkJWdJnjogrlGvqBMofNzgi.gPWsRQrltAMeXAUnEGWIKiYpMVMM)
					{
						buttonStateFlags |= ButtonStateFlags.Up;
					}
					return buttonStateFlags;
				}
			}

			internal Button(Controller P_0, int P_1, string P_2, HardwareButtonInfo P_3)
				: base(P_0, P_1, P_2, ControllerElementType.Button)
			{
				aSUKMgcrEWfMhhOukDBcFEBiIpQjb = P_3;
				kKavfnYOUDcdFrwQoHDHuIVRFcAEA = new eEGJOTPSXomLNvMIFkTjzRorYqs(ReInput.configVars.updateLoop, false);
			}

			internal Button(Controller P_0, int P_1, string P_2, bool P_3, HardwareButtonInfo P_4)
				: base(P_0, P_1, P_2, ControllerElementType.Button)
			{
				aSUKMgcrEWfMhhOukDBcFEBiIpQjb = P_4;
				vMphZPguDDJgBklIksBgEHUMzlPm = P_3;
				kKavfnYOUDcdFrwQoHDHuIVRFcAEA = new eEGJOTPSXomLNvMIFkTjzRorYqs(ReInput.configVars.updateLoop, P_3);
			}

			public bool DoublePressedAndHeld(float speed)
			{
				if (ReInput._id != lkKoESGkiUBVTbpJpAAvansZmSHj)
				{
					ReInput.CheckInitialized(lkKoESGkiUBVTbpJpAAvansZmSHj);
					return false;
				}
				if (speed <= 0f)
				{
					return ((eEGJOTPSXomLNvMIFkTjzRorYqs.UCmSuvkJWdJnjogrlGvqBMofNzgi)kKavfnYOUDcdFrwQoHDHuIVRFcAEA.JodnrCQGFSOkoJarrfSzuHtuUOJy).ahSnYdCHGQrCOZjQYXCLJliXwmmh.snNWJTOvQvnFnfTKMpAcWbCgEwjCA;
				}
				return ((eEGJOTPSXomLNvMIFkTjzRorYqs.UCmSuvkJWdJnjogrlGvqBMofNzgi)kKavfnYOUDcdFrwQoHDHuIVRFcAEA.JodnrCQGFSOkoJarrfSzuHtuUOJy).BhIiLNyJnAAjsesZzccbEGPwlQhNA.yBPdTgbicJhnlnMYdlapfGpGgLymb(speed);
			}

			public bool JustDoublePressed(float speed)
			{
				if (ReInput._id != lkKoESGkiUBVTbpJpAAvansZmSHj)
				{
					ReInput.CheckInitialized(lkKoESGkiUBVTbpJpAAvansZmSHj);
					return false;
				}
				if (!justPressed)
				{
					return false;
				}
				if (speed <= 0f)
				{
					return ((eEGJOTPSXomLNvMIFkTjzRorYqs.UCmSuvkJWdJnjogrlGvqBMofNzgi)kKavfnYOUDcdFrwQoHDHuIVRFcAEA.JodnrCQGFSOkoJarrfSzuHtuUOJy).ahSnYdCHGQrCOZjQYXCLJliXwmmh.snNWJTOvQvnFnfTKMpAcWbCgEwjCA;
				}
				return ((eEGJOTPSXomLNvMIFkTjzRorYqs.UCmSuvkJWdJnjogrlGvqBMofNzgi)kKavfnYOUDcdFrwQoHDHuIVRFcAEA.JodnrCQGFSOkoJarrfSzuHtuUOJy).BhIiLNyJnAAjsesZzccbEGPwlQhNA.yBPdTgbicJhnlnMYdlapfGpGgLymb(speed);
			}

			internal void pWDTEHOcRLCmXFYtuUlfcneHqaNg(UpdateLoopType P_0, int P_1, ControllerDataUpdater P_2)
			{
				if (kKavfnYOUDcdFrwQoHDHuIVRFcAEA != null && kKavfnYOUDcdFrwQoHDHuIVRFcAEA.gRoycAQDkxuKqHfKTnoDRAaDJyDm != (int)P_0)
				{
					kKavfnYOUDcdFrwQoHDHuIVRFcAEA.eYRBzfNOIqpsrqwJOgPMGldxPZZq = P_0;
				}
				if (vMphZPguDDJgBklIksBgEHUMzlPm)
				{
					((eEGJOTPSXomLNvMIFkTjzRorYqs.HEjZFFozFVjneqdYEExLAUAyAsRH)kKavfnYOUDcdFrwQoHDHuIVRFcAEA.JodnrCQGFSOkoJarrfSzuHtuUOJy).XiZdmqjkzqLdJZVtFfcHhNpFIlEnA(P_2.buttonPressureValues[P_1]);
				}
				else
				{
					((eEGJOTPSXomLNvMIFkTjzRorYqs.UCmSuvkJWdJnjogrlGvqBMofNzgi)kKavfnYOUDcdFrwQoHDHuIVRFcAEA.JodnrCQGFSOkoJarrfSzuHtuUOJy).QLjKjqOHtYsaMMNCDVQCBCTQJeOG(P_2.buttonValues[P_1]);
				}
			}

			internal void DmBYvdIySTAYsdznLPPWmWZWEVqS(UpdateLoopType P_0)
			{
				if (kKavfnYOUDcdFrwQoHDHuIVRFcAEA != null && kKavfnYOUDcdFrwQoHDHuIVRFcAEA.gRoycAQDkxuKqHfKTnoDRAaDJyDm != (int)P_0)
				{
					kKavfnYOUDcdFrwQoHDHuIVRFcAEA.eYRBzfNOIqpsrqwJOgPMGldxPZZq = P_0;
				}
				if (vMphZPguDDJgBklIksBgEHUMzlPm)
				{
					((eEGJOTPSXomLNvMIFkTjzRorYqs.HEjZFFozFVjneqdYEExLAUAyAsRH)kKavfnYOUDcdFrwQoHDHuIVRFcAEA.JodnrCQGFSOkoJarrfSzuHtuUOJy).XiZdmqjkzqLdJZVtFfcHhNpFIlEnA(0f);
				}
				else
				{
					((eEGJOTPSXomLNvMIFkTjzRorYqs.UCmSuvkJWdJnjogrlGvqBMofNzgi)kKavfnYOUDcdFrwQoHDHuIVRFcAEA.JodnrCQGFSOkoJarrfSzuHtuUOJy).QLjKjqOHtYsaMMNCDVQCBCTQJeOG(false);
				}
			}

			internal void HcEVEgGkojsaImzHjFppOOIEEtWY()
			{
				for (int i = 0; i < kKavfnYOUDcdFrwQoHDHuIVRFcAEA.nuNKeFIFiULhPPkzIxoBhdZODJkcA.Count; i++)
				{
					wqDQTLzJJBJSuEzjMNYQEqgZWANgA.xNUEVpUeugcpnEiaKNJSMDItEvIh xNUEVpUeugcpnEiaKNJSMDItEvIh = kKavfnYOUDcdFrwQoHDHuIVRFcAEA.nuNKeFIFiULhPPkzIxoBhdZODJkcA[i];
					if (xNUEVpUeugcpnEiaKNJSMDItEvIh != null)
					{
						if (vMphZPguDDJgBklIksBgEHUMzlPm)
						{
							((eEGJOTPSXomLNvMIFkTjzRorYqs.HEjZFFozFVjneqdYEExLAUAyAsRH)xNUEVpUeugcpnEiaKNJSMDItEvIh).XiZdmqjkzqLdJZVtFfcHhNpFIlEnA(0f);
						}
						else
						{
							((eEGJOTPSXomLNvMIFkTjzRorYqs.UCmSuvkJWdJnjogrlGvqBMofNzgi)xNUEVpUeugcpnEiaKNJSMDItEvIh).QLjKjqOHtYsaMMNCDVQCBCTQJeOG(false);
						}
					}
				}
			}
		}

		public abstract class CompoundElement
		{
			private class lEhagAMHOcLaYybaioPAaUbDXbwF
			{
				public readonly Element zJQYhYiNYpnYidZZLfOBBjCkVPqg;

				public readonly int ScseUjYhGGDhzbQeSrhfNEwUGLnS;

				public lEhagAMHOcLaYybaioPAaUbDXbwF(Element P_0, int P_1)
				{
					zJQYhYiNYpnYidZZLfOBBjCkVPqg = P_0;
					ScseUjYhGGDhzbQeSrhfNEwUGLnS = P_1;
				}
			}

			private int lsWfyxDwWnIXxtaDygDWIZeoexqKA;

			private string jPQQafXZDiXzuYydQctECICSuqWc;

			private CompoundControllerElementType fnkHXLuXllKpVfCZGFieEffKQNPC;

			private int yxeErnWXtWRjHOkHuvjZtiiHLKPC;

			private lEhagAMHOcLaYybaioPAaUbDXbwF[] QtQWYLMitgVOFUAmEIUyKVqDOMoM;

			private Controller ItOAwlCisnAFgQmjHHHriKVZYxMMA;

			internal readonly int snKYUETkOifNxPPKpQGroUPSclej;

			public int id
			{
				get
				{
					if (ReInput._id != snKYUETkOifNxPPKpQGroUPSclej)
					{
						ReInput.CheckInitialized(snKYUETkOifNxPPKpQGroUPSclej);
						return -1;
					}
					return lsWfyxDwWnIXxtaDygDWIZeoexqKA;
				}
			}

			public string name
			{
				get
				{
					if (ReInput._id != snKYUETkOifNxPPKpQGroUPSclej)
					{
						ReInput.CheckInitialized(snKYUETkOifNxPPKpQGroUPSclej);
						return string.Empty;
					}
					return jPQQafXZDiXzuYydQctECICSuqWc;
				}
			}

			public CompoundControllerElementType type
			{
				get
				{
					if (ReInput._id != snKYUETkOifNxPPKpQGroUPSclej)
					{
						ReInput.CheckInitialized(snKYUETkOifNxPPKpQGroUPSclej);
						return CompoundControllerElementType.Axis2D;
					}
					return fnkHXLuXllKpVfCZGFieEffKQNPC;
				}
			}

			public bool hasElements
			{
				get
				{
					if (ReInput._id != snKYUETkOifNxPPKpQGroUPSclej)
					{
						ReInput.CheckInitialized(snKYUETkOifNxPPKpQGroUPSclej);
						return false;
					}
					return yxeErnWXtWRjHOkHuvjZtiiHLKPC > 0;
				}
			}

			public int elementCount
			{
				get
				{
					if (ReInput._id != snKYUETkOifNxPPKpQGroUPSclej)
					{
						ReInput.CheckInitialized(snKYUETkOifNxPPKpQGroUPSclej);
						return 0;
					}
					return yxeErnWXtWRjHOkHuvjZtiiHLKPC;
				}
			}

			public abstract int elementCapacity { get; }

			public ControllerElementIdentifier elementIdentifier
			{
				get
				{
					if (ReInput._id != snKYUETkOifNxPPKpQGroUPSclej)
					{
						ReInput.CheckInitialized(snKYUETkOifNxPPKpQGroUPSclej);
						return null;
					}
					ControllerElementIdentifier elementIdentifierById = ItOAwlCisnAFgQmjHHHriKVZYxMMA.GetElementIdentifierById(lsWfyxDwWnIXxtaDygDWIZeoexqKA);
					if (elementIdentifierById == null)
					{
						return ControllerElementIdentifier.BlankReadOnly;
					}
					return elementIdentifierById;
				}
			}

			internal CompoundElement(Controller P_0, int P_1, string P_2, CompoundControllerElementType P_3)
			{
				ItOAwlCisnAFgQmjHHHriKVZYxMMA = P_0;
				lsWfyxDwWnIXxtaDygDWIZeoexqKA = P_1;
				jPQQafXZDiXzuYydQctECICSuqWc = P_2;
				fnkHXLuXllKpVfCZGFieEffKQNPC = P_3;
				QtQWYLMitgVOFUAmEIUyKVqDOMoM = new lEhagAMHOcLaYybaioPAaUbDXbwF[elementCapacity];
				snKYUETkOifNxPPKpQGroUPSclej = ReInput.id;
			}

			internal Element sWXbGkjwvgBkOfvmVtOlmmZONEjYA(int P_0)
			{
				if (P_0 < 0 || P_0 >= QtQWYLMitgVOFUAmEIUyKVqDOMoM.Length)
				{
					return null;
				}
				if (QtQWYLMitgVOFUAmEIUyKVqDOMoM[P_0] == null)
				{
					return null;
				}
				return QtQWYLMitgVOFUAmEIUyKVqDOMoM[P_0].zJQYhYiNYpnYidZZLfOBBjCkVPqg;
			}

			internal _0001 sWXbGkjwvgBkOfvmVtOlmmZONEjYA<_0001>(int P_0) where _0001 : Element
			{
				if (P_0 < 0 || P_0 >= QtQWYLMitgVOFUAmEIUyKVqDOMoM.Length)
				{
					return null;
				}
				if (QtQWYLMitgVOFUAmEIUyKVqDOMoM[P_0] == null)
				{
					return null;
				}
				return QtQWYLMitgVOFUAmEIUyKVqDOMoM[P_0].zJQYhYiNYpnYidZZLfOBBjCkVPqg as _0001;
			}

			internal _0001 rcyqmAPtkFzgzzsXEHKbhuasAEfF<_0001>(int P_0, out int P_1) where _0001 : Element
			{
				P_1 = -1;
				if (P_0 < 0 || P_0 >= QtQWYLMitgVOFUAmEIUyKVqDOMoM.Length)
				{
					return null;
				}
				if (QtQWYLMitgVOFUAmEIUyKVqDOMoM[P_0] == null)
				{
					return null;
				}
				P_1 = QtQWYLMitgVOFUAmEIUyKVqDOMoM[P_0].ScseUjYhGGDhzbQeSrhfNEwUGLnS;
				return QtQWYLMitgVOFUAmEIUyKVqDOMoM[P_0].zJQYhYiNYpnYidZZLfOBBjCkVPqg as _0001;
			}

			internal bool FGZlvRyfHsojaYiBRWtkxZZYNWhO(Element P_0, int P_1)
			{
				if (P_0 == null)
				{
					return false;
				}
				if (yxeErnWXtWRjHOkHuvjZtiiHLKPC >= elementCapacity)
				{
					Logger.LogWarning("Cannot add element! This Compound Element already contains the maximum number of elements.");
					return false;
				}
				if (P_0.isMemberElement)
				{
					Logger.LogWarning("Cannot add element! The element you are trying to add is already a member of another compound element.");
					return false;
				}
				if (lPnoyZdBitHizkxhpMwREeRzRpmUA(P_0) >= 0)
				{
					Logger.LogWarning("Cannot add element! This Compound Element already contains the element you are trying to add.");
					return false;
				}
				int num = NUWaGEEQjVZYxgMpCWgsgILbifQG();
				if (num < 0)
				{
					Logger.LogWarning("Cannot add element! This Compound Element already contains the maximum number of elements.");
					return false;
				}
				return cbvCoucEEJigzAToYXRNQCnblEgab(P_0, P_1, num);
			}

			internal bool DDwfbxiUKEpHBHEtIwQKwlZGRsUuB(Element P_0)
			{
				if (P_0 == null)
				{
					return false;
				}
				if (yxeErnWXtWRjHOkHuvjZtiiHLKPC == 0)
				{
					Logger.LogWarning("Cannot remove element! This Compound Element has no elements.");
					return false;
				}
				int num = lPnoyZdBitHizkxhpMwREeRzRpmUA(P_0);
				if (num < 0)
				{
					Logger.LogWarning("Cannot remove element! This Compound Element does not contain the element you are trying to remove.");
					return false;
				}
				return KibItEfdmigqMohCKkRLGDWRphFs(num);
			}

			internal void aSBbrewKKgDXGqMdSEbnfXwIrnjkA()
			{
				for (int i = 0; i < QtQWYLMitgVOFUAmEIUyKVqDOMoM.Length; i++)
				{
					KibItEfdmigqMohCKkRLGDWRphFs(i);
				}
				yxeErnWXtWRjHOkHuvjZtiiHLKPC = 0;
			}

			private int lPnoyZdBitHizkxhpMwREeRzRpmUA(Element P_0)
			{
				if (P_0 == null)
				{
					return -1;
				}
				for (int i = 0; i < QtQWYLMitgVOFUAmEIUyKVqDOMoM.Length; i++)
				{
					if (QtQWYLMitgVOFUAmEIUyKVqDOMoM[i] != null && QtQWYLMitgVOFUAmEIUyKVqDOMoM[i].zJQYhYiNYpnYidZZLfOBBjCkVPqg == P_0)
					{
						return i;
					}
				}
				return -1;
			}

			private bool cbvCoucEEJigzAToYXRNQCnblEgab(Element P_0, int P_1, int P_2)
			{
				if (P_2 < 0 || P_2 >= QtQWYLMitgVOFUAmEIUyKVqDOMoM.Length)
				{
					return false;
				}
				if (QtQWYLMitgVOFUAmEIUyKVqDOMoM[P_2] != null)
				{
					return false;
				}
				QtQWYLMitgVOFUAmEIUyKVqDOMoM[P_2] = new lEhagAMHOcLaYybaioPAaUbDXbwF(P_0, P_1);
				P_0.vDAUPRveAFVjsIRYfPJWADCJkzNv(this);
				yxeErnWXtWRjHOkHuvjZtiiHLKPC++;
				return true;
			}

			private bool KibItEfdmigqMohCKkRLGDWRphFs(int P_0)
			{
				if (P_0 < 0 || P_0 >= QtQWYLMitgVOFUAmEIUyKVqDOMoM.Length)
				{
					return false;
				}
				if (QtQWYLMitgVOFUAmEIUyKVqDOMoM[P_0] == null)
				{
					return false;
				}
				if (QtQWYLMitgVOFUAmEIUyKVqDOMoM[P_0].zJQYhYiNYpnYidZZLfOBBjCkVPqg != null)
				{
					QtQWYLMitgVOFUAmEIUyKVqDOMoM[P_0].zJQYhYiNYpnYidZZLfOBBjCkVPqg.oRzRDtlHBVYhbjUOTTqzLtfAlhMf(this);
				}
				QtQWYLMitgVOFUAmEIUyKVqDOMoM[P_0] = null;
				yxeErnWXtWRjHOkHuvjZtiiHLKPC--;
				return true;
			}

			private int NUWaGEEQjVZYxgMpCWgsgILbifQG()
			{
				for (int i = 0; i < QtQWYLMitgVOFUAmEIUyKVqDOMoM.Length; i++)
				{
					if (QtQWYLMitgVOFUAmEIUyKVqDOMoM[i] == null)
					{
						return i;
					}
				}
				return -1;
			}
		}

		public sealed class Axis2D : CompoundElement
		{
			private const int uNiTKtgmMjcpjzlWRBWftkyiKYDO = 2;

			private CalibrationMap dWkYLpkdVsnYqeCWnoKSdjkPBToz;

			int CompoundElement.elementCapacity => 2;

			public Axis xAxis
			{
				get
				{
					if (ReInput._id != snKYUETkOifNxPPKpQGroUPSclej)
					{
						ReInput.CheckInitialized(snKYUETkOifNxPPKpQGroUPSclej);
						return null;
					}
					return sWXbGkjwvgBkOfvmVtOlmmZONEjYA<Axis>(0);
				}
			}

			public Axis yAxis
			{
				get
				{
					if (ReInput._id != snKYUETkOifNxPPKpQGroUPSclej)
					{
						ReInput.CheckInitialized(snKYUETkOifNxPPKpQGroUPSclej);
						return null;
					}
					return sWXbGkjwvgBkOfvmVtOlmmZONEjYA<Axis>(1);
				}
			}

			public Vector2 value
			{
				get
				{
					if (ReInput._id != snKYUETkOifNxPPKpQGroUPSclej)
					{
						ReInput.CheckInitialized(snKYUETkOifNxPPKpQGroUPSclej);
						return Vector2.zero;
					}
					return bmLCCFeQDGqpsHSDzqQFKhpBcwyU();
				}
			}

			public Vector2 valuePrev
			{
				get
				{
					if (ReInput._id != snKYUETkOifNxPPKpQGroUPSclej)
					{
						ReInput.CheckInitialized(snKYUETkOifNxPPKpQGroUPSclej);
						return Vector2.zero;
					}
					return KMhKbtEtHGhcikwCpaAipMBNGhMaA();
				}
			}

			public Vector2 valueRaw
			{
				get
				{
					if (ReInput._id != snKYUETkOifNxPPKpQGroUPSclej)
					{
						ReInput.CheckInitialized(snKYUETkOifNxPPKpQGroUPSclej);
						return Vector2.zero;
					}
					return new Vector2((xAxis != null) ? xAxis.valueRaw : 0f, (yAxis != null) ? yAxis.valueRaw : 0f);
				}
			}

			public Vector2 valueRawPrev
			{
				get
				{
					if (ReInput._id != snKYUETkOifNxPPKpQGroUPSclej)
					{
						ReInput.CheckInitialized(snKYUETkOifNxPPKpQGroUPSclej);
						return Vector2.zero;
					}
					return new Vector2((xAxis != null) ? xAxis.valueRawPrev : 0f, (yAxis != null) ? yAxis.valueRawPrev : 0f);
				}
			}

			internal Axis2D(Controller P_0, int P_1, string P_2, Axis P_3, Axis P_4, int P_5, int P_6, CalibrationMap P_7)
				: base(P_0, P_1, P_2, CompoundControllerElementType.Axis2D)
			{
				FGZlvRyfHsojaYiBRWtkxZZYNWhO(P_3, P_5);
				FGZlvRyfHsojaYiBRWtkxZZYNWhO(P_4, P_6);
				dWkYLpkdVsnYqeCWnoKSdjkPBToz = P_7;
			}

			internal void kFEDooQtbblpfFZvSHkcthbsRQip()
			{
				Vector2 vector = value;
				if (xAxis != null)
				{
					xAxis.XThcEyoxCsxHBUFXXyxunQOYWAzV(vector.x);
				}
				if (yAxis != null)
				{
					yAxis.XThcEyoxCsxHBUFXXyxunQOYWAzV(vector.y);
				}
			}

			private Vector2 bmLCCFeQDGqpsHSDzqQFKhpBcwyU()
			{
				if (dWkYLpkdVsnYqeCWnoKSdjkPBToz == null)
				{
					return default(Vector2);
				}
				int xAxisIndex;
				Axis axis = rcyqmAPtkFzgzzsXEHKbhuasAEfF<Axis>(0, out xAxisIndex);
				int yAxisIndex;
				Axis axis2 = rcyqmAPtkFzgzzsXEHKbhuasAEfF<Axis>(1, out yAxisIndex);
				DeadZone2DType defaultJoystickAxis2DDeadZoneType = ReInput.configVars.defaultJoystickAxis2DDeadZoneType;
				AxisSensitivity2DType defaultJoystickAxis2DSensitivityType = ReInput.configVars.defaultJoystickAxis2DSensitivityType;
				float valueRawX = axis?.valueRaw ?? 0f;
				float valueRawY = axis2?.valueRaw ?? 0f;
				return dWkYLpkdVsnYqeCWnoKSdjkPBToz.GetCalibrated2DValue(xAxisIndex, yAxisIndex, valueRawX, valueRawY, defaultJoystickAxis2DDeadZoneType, defaultJoystickAxis2DSensitivityType);
			}

			private Vector2 KMhKbtEtHGhcikwCpaAipMBNGhMaA()
			{
				if (dWkYLpkdVsnYqeCWnoKSdjkPBToz == null)
				{
					return default(Vector2);
				}
				int xAxisIndex;
				Axis axis = rcyqmAPtkFzgzzsXEHKbhuasAEfF<Axis>(0, out xAxisIndex);
				int yAxisIndex;
				Axis axis2 = rcyqmAPtkFzgzzsXEHKbhuasAEfF<Axis>(1, out yAxisIndex);
				DeadZone2DType defaultJoystickAxis2DDeadZoneType = ReInput.configVars.defaultJoystickAxis2DDeadZoneType;
				AxisSensitivity2DType defaultJoystickAxis2DSensitivityType = ReInput.configVars.defaultJoystickAxis2DSensitivityType;
				float valueRawX = axis?.valueRawPrev ?? 0f;
				float valueRawY = axis2?.valueRawPrev ?? 0f;
				return dWkYLpkdVsnYqeCWnoKSdjkPBToz.GetCalibrated2DValue(xAxisIndex, yAxisIndex, valueRawX, valueRawY, defaultJoystickAxis2DDeadZoneType, defaultJoystickAxis2DSensitivityType);
			}
		}

		public sealed class Hat : CompoundElement
		{
			private const int FRxevabgvuduCZZRiZcYkZixsvTg = 8;

			private const int OfoBPHtlDEcXsejyDCLSVkMlFxof = 0;

			private const int tlDXRsJHEHdZzFsseJIzUwEfVNnf = 1;

			private const int XEFWxpMuythFuXirPsUIUDgWvSsu = 2;

			private const int nqZJIUSABaEoefWKYAkEpIKsMWLlA = 3;

			private const int QbfAdwMXEYpaTREJVRwfchkEQSiH = 4;

			private const int IxxORLUgJOBfAhfmMVQQGWKTyIXw = 5;

			private const int FxEPRBYglyMdOGUBwdnjPSHcDreF = 6;

			private const int xweQmIHdpRwPzQzaiuiuKFhiXOGh = 7;

			private readonly int KqCOqyynndCDhVAcYUxvOsqWqsqd;

			private readonly Button[] cwsrkhwWzXuJwrrOaYEFsADBGDKt;

			private readonly ReadOnlyCollection<Button> JjLgqTdTmCbxBYueUUtQKVkQKFuV;

			private readonly int[] PqSMjIjbOgQlKJUOzNrJTFXgqqQe;

			private bool NgUTlFfHBhtcDytaXYaTeEdThicN;

			int CompoundElement.elementCapacity => 8;

			public bool force4Way
			{
				get
				{
					if (ReInput._id != snKYUETkOifNxPPKpQGroUPSclej)
					{
						ReInput.CheckInitialized(snKYUETkOifNxPPKpQGroUPSclej);
						return false;
					}
					return NgUTlFfHBhtcDytaXYaTeEdThicN;
				}
				set
				{
					if (ReInput._id != snKYUETkOifNxPPKpQGroUPSclej)
					{
						ReInput.CheckInitialized(snKYUETkOifNxPPKpQGroUPSclej);
					}
					else
					{
						NgUTlFfHBhtcDytaXYaTeEdThicN = value;
					}
				}
			}

			public int directionCount
			{
				get
				{
					if (ReInput._id != snKYUETkOifNxPPKpQGroUPSclej)
					{
						ReInput.CheckInitialized(snKYUETkOifNxPPKpQGroUPSclej);
						return 0;
					}
					return KqCOqyynndCDhVAcYUxvOsqWqsqd;
				}
			}

			public IList<Button> Buttons
			{
				get
				{
					if (ReInput._id != snKYUETkOifNxPPKpQGroUPSclej)
					{
						ReInput.CheckInitialized(snKYUETkOifNxPPKpQGroUPSclej);
						return EmptyObjects<Button>.EmptyReadOnlyIListT;
					}
					return JjLgqTdTmCbxBYueUUtQKVkQKFuV;
				}
			}

			public Button buttonUp
			{
				get
				{
					if (ReInput._id != snKYUETkOifNxPPKpQGroUPSclej)
					{
						ReInput.CheckInitialized(snKYUETkOifNxPPKpQGroUPSclej);
						return null;
					}
					return sWXbGkjwvgBkOfvmVtOlmmZONEjYA<Button>(0);
				}
			}

			public Button buttonRight
			{
				get
				{
					if (ReInput._id != snKYUETkOifNxPPKpQGroUPSclej)
					{
						ReInput.CheckInitialized(snKYUETkOifNxPPKpQGroUPSclej);
						return null;
					}
					return sWXbGkjwvgBkOfvmVtOlmmZONEjYA<Button>(2);
				}
			}

			public Button buttonDown
			{
				get
				{
					if (ReInput._id != snKYUETkOifNxPPKpQGroUPSclej)
					{
						ReInput.CheckInitialized(snKYUETkOifNxPPKpQGroUPSclej);
						return null;
					}
					return sWXbGkjwvgBkOfvmVtOlmmZONEjYA<Button>(4);
				}
			}

			public Button buttonLeft
			{
				get
				{
					if (ReInput._id != snKYUETkOifNxPPKpQGroUPSclej)
					{
						ReInput.CheckInitialized(snKYUETkOifNxPPKpQGroUPSclej);
						return null;
					}
					return sWXbGkjwvgBkOfvmVtOlmmZONEjYA<Button>(6);
				}
			}

			public Button buttonUpRight
			{
				get
				{
					if (ReInput._id != snKYUETkOifNxPPKpQGroUPSclej)
					{
						ReInput.CheckInitialized(snKYUETkOifNxPPKpQGroUPSclej);
						return null;
					}
					return sWXbGkjwvgBkOfvmVtOlmmZONEjYA<Button>(1);
				}
			}

			public Button buttonDownRight
			{
				get
				{
					if (ReInput._id != snKYUETkOifNxPPKpQGroUPSclej)
					{
						ReInput.CheckInitialized(snKYUETkOifNxPPKpQGroUPSclej);
						return null;
					}
					return sWXbGkjwvgBkOfvmVtOlmmZONEjYA<Button>(3);
				}
			}

			public Button buttonDownLeft
			{
				get
				{
					if (ReInput._id != snKYUETkOifNxPPKpQGroUPSclej)
					{
						ReInput.CheckInitialized(snKYUETkOifNxPPKpQGroUPSclej);
						return null;
					}
					return sWXbGkjwvgBkOfvmVtOlmmZONEjYA<Button>(5);
				}
			}

			public Button buttonUpLeft
			{
				get
				{
					if (ReInput._id != snKYUETkOifNxPPKpQGroUPSclej)
					{
						ReInput.CheckInitialized(snKYUETkOifNxPPKpQGroUPSclej);
						return null;
					}
					return sWXbGkjwvgBkOfvmVtOlmmZONEjYA<Button>(7);
				}
			}

			internal Hat(Controller P_0, int P_1, string P_2, Button[] P_3, int[] P_4)
				: base(P_0, P_1, P_2, CompoundControllerElementType.Hat)
			{
				int num = ((P_3 != null) ? P_3.Length : 0);
				if (num != ((P_4 != null) ? P_4.Length : 0))
				{
					throw new ArgumentException("button.Length must equal buttonIndices.Length!");
				}
				if (num != 0 && num != 4 && num != 8)
				{
					throw new ArgumentException("button.Length must be 0, 4, or 8! Length: " + num);
				}
				for (int i = 0; i < num; i++)
				{
					FGZlvRyfHsojaYiBRWtkxZZYNWhO(P_3[i], P_4[i]);
				}
				cwsrkhwWzXuJwrrOaYEFsADBGDKt = P_3;
				PqSMjIjbOgQlKJUOzNrJTFXgqqQe = P_4;
				KqCOqyynndCDhVAcYUxvOsqWqsqd = num;
				JjLgqTdTmCbxBYueUUtQKVkQKFuV = new ReadOnlyCollection<Button>(P_3);
			}

			internal void UFbBRfchsdvuuneJoAcEJrzVqrlGb(UpdateLoopType P_0, ControllerDataUpdater P_1)
			{
				if (KqCOqyynndCDhVAcYUxvOsqWqsqd == 0)
				{
					return;
				}
				if (KqCOqyynndCDhVAcYUxvOsqWqsqd == 8 && (NgUTlFfHBhtcDytaXYaTeEdThicN || ReInput.configVars.force4WayHats))
				{
					GMjRXGJSxnmzrggKbidFNQdYWrFC(cwsrkhwWzXuJwrrOaYEFsADBGDKt[0], PqSMjIjbOgQlKJUOzNrJTFXgqqQe[0], PqSMjIjbOgQlKJUOzNrJTFXgqqQe[7], PqSMjIjbOgQlKJUOzNrJTFXgqqQe[1], P_0, P_1);
					GMjRXGJSxnmzrggKbidFNQdYWrFC(cwsrkhwWzXuJwrrOaYEFsADBGDKt[2], PqSMjIjbOgQlKJUOzNrJTFXgqqQe[2], PqSMjIjbOgQlKJUOzNrJTFXgqqQe[1], PqSMjIjbOgQlKJUOzNrJTFXgqqQe[3], P_0, P_1);
					GMjRXGJSxnmzrggKbidFNQdYWrFC(cwsrkhwWzXuJwrrOaYEFsADBGDKt[4], PqSMjIjbOgQlKJUOzNrJTFXgqqQe[4], PqSMjIjbOgQlKJUOzNrJTFXgqqQe[5], PqSMjIjbOgQlKJUOzNrJTFXgqqQe[3], P_0, P_1);
					GMjRXGJSxnmzrggKbidFNQdYWrFC(cwsrkhwWzXuJwrrOaYEFsADBGDKt[6], PqSMjIjbOgQlKJUOzNrJTFXgqqQe[6], PqSMjIjbOgQlKJUOzNrJTFXgqqQe[5], PqSMjIjbOgQlKJUOzNrJTFXgqqQe[7], P_0, P_1);
					rQiNDKOwQZGkqIVrxfyowufAdVms(cwsrkhwWzXuJwrrOaYEFsADBGDKt[1], PqSMjIjbOgQlKJUOzNrJTFXgqqQe[1], P_0, P_1);
					rQiNDKOwQZGkqIVrxfyowufAdVms(cwsrkhwWzXuJwrrOaYEFsADBGDKt[3], PqSMjIjbOgQlKJUOzNrJTFXgqqQe[3], P_0, P_1);
					rQiNDKOwQZGkqIVrxfyowufAdVms(cwsrkhwWzXuJwrrOaYEFsADBGDKt[5], PqSMjIjbOgQlKJUOzNrJTFXgqqQe[5], P_0, P_1);
					rQiNDKOwQZGkqIVrxfyowufAdVms(cwsrkhwWzXuJwrrOaYEFsADBGDKt[7], PqSMjIjbOgQlKJUOzNrJTFXgqqQe[7], P_0, P_1);
					return;
				}
				for (int i = 0; i < cwsrkhwWzXuJwrrOaYEFsADBGDKt.Length; i++)
				{
					if (cwsrkhwWzXuJwrrOaYEFsADBGDKt[i] != null)
					{
						cwsrkhwWzXuJwrrOaYEFsADBGDKt[i].pWDTEHOcRLCmXFYtuUlfcneHqaNg(P_0, PqSMjIjbOgQlKJUOzNrJTFXgqqQe[i], P_1);
					}
				}
			}

			private void GMjRXGJSxnmzrggKbidFNQdYWrFC(Button P_0, int P_1, int P_2, int P_3, UpdateLoopType P_4, ControllerDataUpdater P_5)
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
				P_0.pWDTEHOcRLCmXFYtuUlfcneHqaNg(P_4, P_1, P_5);
			}

			private void rQiNDKOwQZGkqIVrxfyowufAdVms(Button P_0, int P_1, UpdateLoopType P_2, ControllerDataUpdater P_3)
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
					P_0.pWDTEHOcRLCmXFYtuUlfcneHqaNg(P_2, P_1, P_3);
				}
			}
		}

		[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
		public abstract class Extension
		{
			private Controller tXXApqhvOHACvtmapvFTjjfjxhoqA;

			private IControllerExtensionSource jVqmxOulfKIujHJHAKBXmEwxtZWt;

			internal readonly int _reInputId;

			internal bool isJoystickConnected
			{
				get
				{
					if (tXXApqhvOHACvtmapvFTjjfjxhoqA == null)
					{
						return false;
					}
					return tXXApqhvOHACvtmapvFTjjfjxhoqA._isConnected;
				}
			}

			internal bool enabled
			{
				get
				{
					if (tXXApqhvOHACvtmapvFTjjfjxhoqA == null)
					{
						return false;
					}
					return tXXApqhvOHACvtmapvFTjjfjxhoqA.enabled;
				}
			}

			internal Controller controller => tXXApqhvOHACvtmapvFTjjfjxhoqA;

			internal Extension(IControllerExtensionSource P_0)
			{
				_reInputId = ReInput.id;
				RitKBwQCoOxlLGhwgENnzUgNqqCt(P_0);
			}

			internal Extension(Extension P_0)
				: this(P_0.jVqmxOulfKIujHJHAKBXmEwxtZWt)
			{
				tXXApqhvOHACvtmapvFTjjfjxhoqA = P_0.tXXApqhvOHACvtmapvFTjjfjxhoqA;
			}

			internal T GetController<T>() where T : Controller
			{
				if (tXXApqhvOHACvtmapvFTjjfjxhoqA == null)
				{
					return null;
				}
				return tXXApqhvOHACvtmapvFTjjfjxhoqA as T;
			}

			internal void SetController(Controller controller)
			{
				tXXApqhvOHACvtmapvFTjjfjxhoqA = controller;
			}

			[CustomObfuscation(rename = false)]
			internal IControllerExtensionSource GetSource()
			{
				return jVqmxOulfKIujHJHAKBXmEwxtZWt;
			}

			internal void SetSource(Extension extension)
			{
				if (extension == null)
				{
					RitKBwQCoOxlLGhwgENnzUgNqqCt(null);
				}
				else
				{
					RitKBwQCoOxlLGhwgENnzUgNqqCt(extension.jVqmxOulfKIujHJHAKBXmEwxtZWt);
				}
			}

			private void RitKBwQCoOxlLGhwgENnzUgNqqCt(IControllerExtensionSource P_0)
			{
				jVqmxOulfKIujHJHAKBXmEwxtZWt = P_0;
				SourceUpdated(jVqmxOulfKIujHJHAKBXmEwxtZWt);
			}

			internal virtual void Clear()
			{
			}

			internal abstract void SourceUpdated(IControllerExtensionSource source);

			internal abstract void UpdateData(UpdateLoopType updateLoop);

			internal abstract Extension Clone();
		}

		[Serializable]
		private sealed class QvcfhdMhzxlIsJjVqsPuqpPXaLQg
		{
			public static readonly QvcfhdMhzxlIsJjVqsPuqpPXaLQg _003C_003E9 = new QvcfhdMhzxlIsJjVqsPuqpPXaLQg();

			public static Func<Controller, Guid, bool> _003C_003E9__158_0;

			public static Func<Controller, Type, bool> _003C_003E9__161_0;

			internal bool pIzMuvYPhpkXOsYPxPCduTkUTWlB(Controller P_0, Guid P_1)
			{
				return P_0.ImplementsTemplate(P_1);
			}

			internal bool LqfvgwLFojIzsFmDSfOuSjhWqkC(Controller P_0, Type P_1)
			{
				return P_0.ImplementsTemplate(P_1);
			}
		}

		private sealed class EUnTxpQPkZbQSzHcAJKXhuDiMDhh : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
		{
			private int ThcbIjdlfTDDDJrvoPHUesjRBsomA;

			private ControllerPollingInfo WHAkGNslexJJROyQyThKkWkqRuPg;

			private int rhbUnOrOiJlDoeUZapBzIcNsSRhQ;

			public Controller XFQttWnfypbwydASJsCQNdMnzrJJA;

			private int VWnBgKguHDbokMcuZaoXuIEOQnnJ;

			ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return WHAkGNslexJJROyQyThKkWkqRuPg;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return WHAkGNslexJJROyQyThKkWkqRuPg;
				}
			}

			[DebuggerHidden]
			public EUnTxpQPkZbQSzHcAJKXhuDiMDhh(int P_0)
			{
				ThcbIjdlfTDDDJrvoPHUesjRBsomA = P_0;
				rhbUnOrOiJlDoeUZapBzIcNsSRhQ = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int thcbIjdlfTDDDJrvoPHUesjRBsomA = ThcbIjdlfTDDDJrvoPHUesjRBsomA;
				Controller xFQttWnfypbwydASJsCQNdMnzrJJA = XFQttWnfypbwydASJsCQNdMnzrJJA;
				if (thcbIjdlfTDDDJrvoPHUesjRBsomA != 0)
				{
					if (thcbIjdlfTDDDJrvoPHUesjRBsomA != 1)
					{
						return false;
					}
					ThcbIjdlfTDDDJrvoPHUesjRBsomA = -1;
					goto IL_00a0;
				}
				ThcbIjdlfTDDDJrvoPHUesjRBsomA = -1;
				if (ReInput._id != xFQttWnfypbwydASJsCQNdMnzrJJA.RNlNSHGtJEPoWjxDZtJLBSknIDFA)
				{
					ReInput.CheckInitialized(xFQttWnfypbwydASJsCQNdMnzrJJA.RNlNSHGtJEPoWjxDZtJLBSknIDFA);
					return false;
				}
				xFQttWnfypbwydASJsCQNdMnzrJJA.UpdatePollingFrameTracking();
				VWnBgKguHDbokMcuZaoXuIEOQnnJ = 0;
				goto IL_00b0;
				IL_00b0:
				if (VWnBgKguHDbokMcuZaoXuIEOQnnJ < xFQttWnfypbwydASJsCQNdMnzrJJA._buttonCount)
				{
					if (xFQttWnfypbwydASJsCQNdMnzrJJA.uffiHxaXoJmitkbAJMECpAKLBwie(VWnBgKguHDbokMcuZaoXuIEOQnnJ, out var num))
					{
						WHAkGNslexJJROyQyThKkWkqRuPg = new ControllerPollingInfo(true, -1, xFQttWnfypbwydASJsCQNdMnzrJJA.id, xFQttWnfypbwydASJsCQNdMnzrJJA._name, xFQttWnfypbwydASJsCQNdMnzrJJA._type, ControllerElementType.Button, VWnBgKguHDbokMcuZaoXuIEOQnnJ, Pole.Positive, xFQttWnfypbwydASJsCQNdMnzrJJA.NOuTtyJvdlwLlfoBgXbDwbqIGPrIA.GetElementIdentifierName(num), num, KeyCode.None);
						ThcbIjdlfTDDDJrvoPHUesjRBsomA = 1;
						return true;
					}
					goto IL_00a0;
				}
				return false;
				IL_00a0:
				VWnBgKguHDbokMcuZaoXuIEOQnnJ++;
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
				EUnTxpQPkZbQSzHcAJKXhuDiMDhh eUnTxpQPkZbQSzHcAJKXhuDiMDhh;
				if (ThcbIjdlfTDDDJrvoPHUesjRBsomA == -2 && rhbUnOrOiJlDoeUZapBzIcNsSRhQ == Environment.CurrentManagedThreadId)
				{
					ThcbIjdlfTDDDJrvoPHUesjRBsomA = 0;
					eUnTxpQPkZbQSzHcAJKXhuDiMDhh = this;
				}
				else
				{
					eUnTxpQPkZbQSzHcAJKXhuDiMDhh = new EUnTxpQPkZbQSzHcAJKXhuDiMDhh(0);
					eUnTxpQPkZbQSzHcAJKXhuDiMDhh.XFQttWnfypbwydASJsCQNdMnzrJJA = XFQttWnfypbwydASJsCQNdMnzrJJA;
				}
				return eUnTxpQPkZbQSzHcAJKXhuDiMDhh;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
			}
		}

		private sealed class AHtDbROmeegQKeuKyVuOuUqDOWTsA : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
		{
			private int xrCEZCbMTAFDRwWadudzSAMqAQGK;

			private ControllerPollingInfo yFtBkZAMQziFLXJvDWPaOnrSZnLnA;

			private int EDRBJQNCZMocMPNQuWYbzYDaSuko;

			public Controller uJgecpOgzylGrcMawbaiLiyxqlZy;

			private int yrxHhHmsjwMzNNNsZaHWNvWcDGRI;

			ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return yFtBkZAMQziFLXJvDWPaOnrSZnLnA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return yFtBkZAMQziFLXJvDWPaOnrSZnLnA;
				}
			}

			[DebuggerHidden]
			public AHtDbROmeegQKeuKyVuOuUqDOWTsA(int P_0)
			{
				xrCEZCbMTAFDRwWadudzSAMqAQGK = P_0;
				EDRBJQNCZMocMPNQuWYbzYDaSuko = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int num = xrCEZCbMTAFDRwWadudzSAMqAQGK;
				Controller controller = uJgecpOgzylGrcMawbaiLiyxqlZy;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					xrCEZCbMTAFDRwWadudzSAMqAQGK = -1;
					goto IL_00a0;
				}
				xrCEZCbMTAFDRwWadudzSAMqAQGK = -1;
				if (ReInput._id != controller.RNlNSHGtJEPoWjxDZtJLBSknIDFA)
				{
					ReInput.CheckInitialized(controller.RNlNSHGtJEPoWjxDZtJLBSknIDFA);
					return false;
				}
				controller.UpdatePollingFrameTracking();
				yrxHhHmsjwMzNNNsZaHWNvWcDGRI = 0;
				goto IL_00b0;
				IL_00b0:
				if (yrxHhHmsjwMzNNNsZaHWNvWcDGRI < controller._buttonCount)
				{
					if (controller.CpUcuHktIxWGbWjHqchGbPokHrXxA(yrxHhHmsjwMzNNNsZaHWNvWcDGRI, out var num2))
					{
						yFtBkZAMQziFLXJvDWPaOnrSZnLnA = new ControllerPollingInfo(true, -1, controller.id, controller._name, controller._type, ControllerElementType.Button, yrxHhHmsjwMzNNNsZaHWNvWcDGRI, Pole.Positive, controller.NOuTtyJvdlwLlfoBgXbDwbqIGPrIA.GetElementIdentifierName(num2), num2, KeyCode.None);
						xrCEZCbMTAFDRwWadudzSAMqAQGK = 1;
						return true;
					}
					goto IL_00a0;
				}
				return false;
				IL_00a0:
				yrxHhHmsjwMzNNNsZaHWNvWcDGRI++;
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
				AHtDbROmeegQKeuKyVuOuUqDOWTsA aHtDbROmeegQKeuKyVuOuUqDOWTsA;
				if (xrCEZCbMTAFDRwWadudzSAMqAQGK == -2 && EDRBJQNCZMocMPNQuWYbzYDaSuko == Environment.CurrentManagedThreadId)
				{
					xrCEZCbMTAFDRwWadudzSAMqAQGK = 0;
					aHtDbROmeegQKeuKyVuOuUqDOWTsA = this;
				}
				else
				{
					aHtDbROmeegQKeuKyVuOuUqDOWTsA = new AHtDbROmeegQKeuKyVuOuUqDOWTsA(0);
					aHtDbROmeegQKeuKyVuOuUqDOWTsA.uJgecpOgzylGrcMawbaiLiyxqlZy = uJgecpOgzylGrcMawbaiLiyxqlZy;
				}
				return aHtDbROmeegQKeuKyVuOuUqDOWTsA;
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

		protected string _hardwareName;

		protected readonly ControllerType _type;

		internal readonly Guid gLbADvCdALkEcLIQPhWpjDrhhunKA;

		protected string _hardwareIdentifier;

		protected bool _isConnected;

		private Extension ngDnUhxHnEfOJyHKjfApiLvPGrhbA;

		private bool VFQdnPKjDpctTKtTLcDZIHPTCbfBb;

		private ControllerIdentifier lmmQbWuFvEtJYhOvSsyAYyTKnfhL;

		internal int RNlNSHGtJEPoWjxDZtJLBSknIDFA;

		protected readonly int _buttonCount;

		protected readonly Button[] buttons;

		protected readonly ReadOnlyCollection<Button> buttons_readOnly;

		private readonly IList<Element> xdrjRazQCcHfoXFTrACgtTCcUnQl;

		private readonly ReadOnlyCollection<Element> vrqvDWcaiWICWjRTweVUVKPRwaITA;

		private readonly IList<CompoundElement> UijcevOBwMLIRGeABlSOiHgkmvGw;

		private readonly ReadOnlyCollection<CompoundElement> wKYfHyrOovpFOFjLKElYkVpWWXVk;

		[CustomObfuscation(rename = false)]
		internal readonly InputSource inputSource;

		internal readonly ControllerDataUpdater rGVdhXruOTgLzoPtrwxfhKmroixX;

		internal readonly HardwareControllerMap_Game NOuTtyJvdlwLlfoBgXbDwbqIGPrIA;

		internal uint BuBkhoCeHoPmaBbYAezaFlEXsyXFA;

		private uint kYTbvVMvmIXgICazpMUTwLauRQqO;

		private uint EUKDcSGdkTRdnIuUCYglilUmZENe;

		private Action<bool> TmwFlKexfkfoavVjeMqJmWrWMKJB;

		private IControllerTemplate[] AwteOeIBUHpuVCrgkbBBezEtsvrvB;

		private ReadOnlyCollection<IControllerTemplate> sJDdvTJMiLMFxEODehOhCZiMwARBA;

		private static Func<Controller, Guid, bool> PIbcYoBNlEpNwquOfcYZduiYRYmj;

		private static Func<Controller, Type, bool> lOqusawyyJbTkEGLcFPwEIUxxoXBA;

		internal bool OXYOSXPBNEmrOvfCUkCpzTLeHJRn => kYTbvVMvmIXgICazpMUTwLauRQqO == ReInput.previousFrame;

		public bool enabled
		{
			get
			{
				if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
				{
					ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
					return false;
				}
				return VFQdnPKjDpctTKtTLcDZIHPTCbfBb;
			}
			set
			{
				BXxyidqXWhYGVbTpYPscakwYIxji(value);
			}
		}

		public string name
		{
			get
			{
				if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
				{
					ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
					return string.Empty;
				}
				return _name;
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
				if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
				{
					ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
					return string.Empty;
				}
				return _tag;
			}
			set
			{
				if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
				{
					ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
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
				if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
				{
					ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
					return string.Empty;
				}
				return _hardwareName;
			}
		}

		public ControllerType type
		{
			get
			{
				if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
				{
					ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
					return ControllerType.Keyboard;
				}
				return _type;
			}
		}

		public Guid hardwareTypeGuid
		{
			get
			{
				if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
				{
					ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
					return Guid.Empty;
				}
				return gLbADvCdALkEcLIQPhWpjDrhhunKA;
			}
		}

		public abstract Guid deviceInstanceGuid { get; }

		public ControllerIdentifier identifier => lmmQbWuFvEtJYhOvSsyAYyTKnfhL;

		public bool isConnected
		{
			get
			{
				if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
				{
					ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
					return false;
				}
				return _isConnected;
			}
			internal set
			{
				if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
				{
					ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
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
				if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
				{
					ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
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
				if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
				{
					ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
					return 0;
				}
				return xdrjRazQCcHfoXFTrACgtTCcUnQl.Count;
			}
		}

		public int buttonCount
		{
			get
			{
				if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
				{
					ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
					return 0;
				}
				return _buttonCount;
			}
		}

		public IList<Element> Elements
		{
			get
			{
				if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
				{
					ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
					return EmptyObjects<Element>.EmptyReadOnlyIListT;
				}
				return vrqvDWcaiWICWjRTweVUVKPRwaITA;
			}
		}

		public IList<CompoundElement> CompoundElements
		{
			get
			{
				if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
				{
					ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
					return EmptyObjects<CompoundElement>.EmptyReadOnlyIListT;
				}
				return wKYfHyrOovpFOFjLKElYkVpWWXVk;
			}
		}

		public IList<Button> Buttons
		{
			get
			{
				if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
				{
					ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
					return EmptyObjects<Button>.EmptyReadOnlyIListT;
				}
				return buttons_readOnly;
			}
		}

		public Extension extension
		{
			get
			{
				if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
				{
					ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
					return null;
				}
				return ngDnUhxHnEfOJyHKjfApiLvPGrhbA;
			}
		}

		public IList<ControllerElementIdentifier> ElementIdentifiers
		{
			get
			{
				if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
				{
					ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
					return EmptyObjects<ControllerElementIdentifier>.EmptyReadOnlyIListT;
				}
				return NOuTtyJvdlwLlfoBgXbDwbqIGPrIA.elementIdentifiers_readOnly;
			}
		}

		public IList<ControllerElementIdentifier> ButtonElementIdentifiers
		{
			get
			{
				if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
				{
					ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
					return EmptyObjects<ControllerElementIdentifier>.EmptyReadOnlyIListT;
				}
				return NOuTtyJvdlwLlfoBgXbDwbqIGPrIA.buttonElementIdentifiers_readOnly;
			}
		}

		public IList<IControllerTemplate> Templates
		{
			get
			{
				if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
				{
					ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
					return EmptyObjects<IControllerTemplate>.EmptyReadOnlyIListT;
				}
				return sJDdvTJMiLMFxEODehOhCZiMwARBA;
			}
		}

		public int templateCount
		{
			get
			{
				if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
				{
					ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
					return 0;
				}
				return AwteOeIBUHpuVCrgkbBBezEtsvrvB.Length;
			}
		}

		internal static Func<Controller, Guid, bool> UdzuXcSZDxcQMmnFtiKdxnvGcqhG => QvcfhdMhzxlIsJjVqsPuqpPXaLQg._003C_003E9.pIzMuvYPhpkXOsYPxPCduTkUTWlB;

		internal static Func<Controller, Type, bool> rLfaSjHfjLHGCnHYGtKFstxNiZUv => QvcfhdMhzxlIsJjVqsPuqpPXaLQg._003C_003E9.LqfvgwLFojIzsFmDSfOuSjhWqkC;

		internal event Action<bool> TSjdvvhiFDrnlwFUZIHtAcTaRjAq
		{
			add
			{
				TmwFlKexfkfoavVjeMqJmWrWMKJB = (Action<bool>)Delegate.Combine(TmwFlKexfkfoavVjeMqJmWrWMKJB, b);
			}
			remove
			{
				TmwFlKexfkfoavVjeMqJmWrWMKJB = (Action<bool>)Delegate.Remove(TmwFlKexfkfoavVjeMqJmWrWMKJB, value2);
			}
		}

		internal Controller(int P_0, InputSource P_1, string P_2, string P_3, string P_4, ControllerType P_5, Guid P_6, int P_7, bool[] P_8, HardwareButtonInfo[] P_9, HardwareControllerMap_Game P_10, Extension P_11, ControllerDataUpdater P_12)
		{
			id = P_0;
			inputSource = P_1;
			_type = P_5;
			gLbADvCdALkEcLIQPhWpjDrhhunKA = P_6;
			_buttonCount = P_7;
			_name = P_2;
			_hardwareName = P_3;
			_hardwareIdentifier = P_4;
			rGVdhXruOTgLzoPtrwxfhKmroixX = P_12;
			NOuTtyJvdlwLlfoBgXbDwbqIGPrIA = P_10;
			VFQdnPKjDpctTKtTLcDZIHPTCbfBb = true;
			RNlNSHGtJEPoWjxDZtJLBSknIDFA = ReInput.id;
			TfqwmlxgOXgbWEQiRooFmIJsIcEz(P_11);
			xdrjRazQCcHfoXFTrACgtTCcUnQl = new List<Element>(P_7);
			vrqvDWcaiWICWjRTweVUVKPRwaITA = new ReadOnlyCollection<Element>(xdrjRazQCcHfoXFTrACgtTCcUnQl);
			UijcevOBwMLIRGeABlSOiHgkmvGw = new List<CompoundElement>();
			wKYfHyrOovpFOFjLKElYkVpWWXVk = new ReadOnlyCollection<CompoundElement>(UijcevOBwMLIRGeABlSOiHgkmvGw);
			buttons = new Button[P_7];
			if (P_8 == null || P_8.Length < P_7)
			{
				for (int i = 0; i < P_7; i++)
				{
					buttons[i] = new Button(this, P_10.buttonElementIdentifierIds[i], "Button " + i, false, (P_9 != null) ? P_9[i] : new HardwareButtonInfo());
					SsiDSPXeljgWKetbvUQnvIjmeXiV(buttons[i]);
				}
			}
			else
			{
				for (int j = 0; j < P_7; j++)
				{
					buttons[j] = new Button(this, P_10.buttonElementIdentifierIds[j], "Button " + j, P_8[j], (P_9 != null) ? P_9[j] : new HardwareButtonInfo());
					SsiDSPXeljgWKetbvUQnvIjmeXiV(buttons[j]);
				}
			}
			buttons_readOnly = new ReadOnlyCollection<Button>(buttons);
			AwteOeIBUHpuVCrgkbBBezEtsvrvB = EmptyObjects<IControllerTemplate>.array;
			sJDdvTJMiLMFxEODehOhCZiMwARBA = new ReadOnlyCollection<IControllerTemplate>(AwteOeIBUHpuVCrgkbBBezEtsvrvB);
			Connected();
		}

		internal virtual void blqnoKjqhVSIFnqRKLejmqEtdoFaA()
		{
			lmmQbWuFvEtJYhOvSsyAYyTKnfhL = new ControllerIdentifier(this);
		}

		public virtual Element GetElementById(int elementIdentifierId)
		{
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
				return null;
			}
			if (NOuTtyJvdlwLlfoBgXbDwbqIGPrIA == null)
			{
				return null;
			}
			int buttonIndex = NOuTtyJvdlwLlfoBgXbDwbqIGPrIA.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0)
			{
				return null;
			}
			return buttons[buttonIndex];
		}

		public virtual CompoundElement GetCompundElementById(int elementIdentifierId)
		{
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
				return null;
			}
			int count = UijcevOBwMLIRGeABlSOiHgkmvGw.Count;
			for (int i = 0; i < count; i++)
			{
				if (UijcevOBwMLIRGeABlSOiHgkmvGw[i] != null && UijcevOBwMLIRGeABlSOiHgkmvGw[i].id == elementIdentifierId)
				{
					return UijcevOBwMLIRGeABlSOiHgkmvGw[i];
				}
			}
			return null;
		}

		public int GetButtonIndexById(int elementIdentifierId)
		{
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
				return -1;
			}
			return NOuTtyJvdlwLlfoBgXbDwbqIGPrIA.GetButtonIndex(elementIdentifierId);
		}

		public ControllerElementIdentifier GetElementIdentifierById(int elementIdentifierId)
		{
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
				return null;
			}
			return NOuTtyJvdlwLlfoBgXbDwbqIGPrIA.GetElementIdentifierById(elementIdentifierId);
		}

		public virtual bool GetButton(int index)
		{
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
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
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
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
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
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
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
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
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
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
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
				return false;
			}
			return GetButtonDoublePressHold(index, 0f);
		}

		public virtual bool GetButtonDoublePressHold(int index, float speed)
		{
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
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
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
				return false;
			}
			return GetButtonDoublePressDown(index, 0f);
		}

		public virtual bool GetButtonDoublePressDown(int index, float speed)
		{
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
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
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
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
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
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
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
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
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
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
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
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
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
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
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
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
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
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
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
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
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
				return false;
			}
			int buttonIndex = NOuTtyJvdlwLlfoBgXbDwbqIGPrIA.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				return false;
			}
			return buttons[buttonIndex].value;
		}

		public virtual bool GetButtonDownById(int elementIdentifierId)
		{
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
				return false;
			}
			int buttonIndex = NOuTtyJvdlwLlfoBgXbDwbqIGPrIA.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				return false;
			}
			return buttons[buttonIndex].justPressed;
		}

		public virtual bool GetButtonUpById(int elementIdentifierId)
		{
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
				return false;
			}
			int buttonIndex = NOuTtyJvdlwLlfoBgXbDwbqIGPrIA.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				return false;
			}
			return buttons[buttonIndex].justReleased;
		}

		public virtual bool GetButtonDoublePressHoldById(int elementIdentifierId, float speed)
		{
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
				return false;
			}
			int buttonIndex = NOuTtyJvdlwLlfoBgXbDwbqIGPrIA.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				return false;
			}
			return buttons[buttonIndex].DoublePressedAndHeld(speed);
		}

		public virtual bool GetButtonDoublePressDownById(int elementIdentifierId, float speed)
		{
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
				return false;
			}
			int buttonIndex = NOuTtyJvdlwLlfoBgXbDwbqIGPrIA.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				return false;
			}
			return buttons[buttonIndex].JustDoublePressed(speed);
		}

		public virtual bool GetButtonDoublePressHoldById(int elementIdentifierId)
		{
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
				return false;
			}
			int buttonIndex = NOuTtyJvdlwLlfoBgXbDwbqIGPrIA.GetButtonIndex(elementIdentifierId);
			return GetButtonDoublePressHold(buttonIndex, 0f);
		}

		public virtual bool GetButtonDoublePressDownById(int elementIdentifierId)
		{
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
				return false;
			}
			int buttonIndex = NOuTtyJvdlwLlfoBgXbDwbqIGPrIA.GetButtonIndex(elementIdentifierId);
			return GetButtonDoublePressDown(buttonIndex, 0f);
		}

		public virtual bool GetButtonPrevById(int elementIdentifierId)
		{
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
				return false;
			}
			int buttonIndex = NOuTtyJvdlwLlfoBgXbDwbqIGPrIA.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				return false;
			}
			return buttons[buttonIndex].valuePrev;
		}

		public virtual double GetButtonTimePressedById(int elementIdentifierId)
		{
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
				return 0.0;
			}
			int buttonIndex = NOuTtyJvdlwLlfoBgXbDwbqIGPrIA.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				return 0.0;
			}
			return buttons[buttonIndex].timePressed;
		}

		public virtual double GetButtonTimeUnpressedById(int elementIdentifierId)
		{
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
				return 0.0;
			}
			int buttonIndex = NOuTtyJvdlwLlfoBgXbDwbqIGPrIA.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				return 0.0;
			}
			return buttons[buttonIndex].timeUnpressed;
		}

		public virtual double GetButtonLastTimePressedById(int elementIdentifierId)
		{
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
				return 0.0;
			}
			int buttonIndex = NOuTtyJvdlwLlfoBgXbDwbqIGPrIA.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				return 0.0;
			}
			return buttons[buttonIndex].lastTimePressed;
		}

		public virtual double GetButtonLastTimeUnpressedById(int elementIdentifierId)
		{
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
				return 0.0;
			}
			int buttonIndex = NOuTtyJvdlwLlfoBgXbDwbqIGPrIA.GetButtonIndex(elementIdentifierId);
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
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
				return ControllerPollingInfo.VkUbZNQaTzvokZghSHJBDxjCgBnd();
			}
			UpdatePollingFrameTracking();
			for (int i = 0; i < _buttonCount; i++)
			{
				if (uffiHxaXoJmitkbAJMECpAKLBwie(i, out var num))
				{
					return new ControllerPollingInfo(true, -1, id, _name, _type, ControllerElementType.Button, i, Pole.Positive, NOuTtyJvdlwLlfoBgXbDwbqIGPrIA.GetElementIdentifierName(num), num, KeyCode.None);
				}
			}
			return ControllerPollingInfo.VkUbZNQaTzvokZghSHJBDxjCgBnd();
		}

		public virtual ControllerPollingInfo PollForFirstButtonDown()
		{
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
				return ControllerPollingInfo.VkUbZNQaTzvokZghSHJBDxjCgBnd();
			}
			UpdatePollingFrameTracking();
			for (int i = 0; i < _buttonCount; i++)
			{
				if (CpUcuHktIxWGbWjHqchGbPokHrXxA(i, out var num))
				{
					return new ControllerPollingInfo(true, -1, id, _name, _type, ControllerElementType.Button, i, Pole.Positive, NOuTtyJvdlwLlfoBgXbDwbqIGPrIA.GetElementIdentifierName(num), num, KeyCode.None);
				}
			}
			return ControllerPollingInfo.VkUbZNQaTzvokZghSHJBDxjCgBnd();
		}

		public virtual IEnumerable<ControllerPollingInfo> PollForAllElements()
		{
			return PollForAllButtons();
		}

		public virtual IEnumerable<ControllerPollingInfo> PollForAllElementsDown()
		{
			return PollForAllButtonsDown();
		}

		[IteratorStateMachine(typeof(EUnTxpQPkZbQSzHcAJKXhuDiMDhh))]
		public virtual IEnumerable<ControllerPollingInfo> PollForAllButtons()
		{
			return new EUnTxpQPkZbQSzHcAJKXhuDiMDhh(-2)
			{
				XFQttWnfypbwydASJsCQNdMnzrJJA = this
			};
		}

		[IteratorStateMachine(typeof(AHtDbROmeegQKeuKyVuOuUqDOWTsA))]
		public virtual IEnumerable<ControllerPollingInfo> PollForAllButtonsDown()
		{
			return new AHtDbROmeegQKeuKyVuOuUqDOWTsA(-2)
			{
				uJgecpOgzylGrcMawbaiLiyxqlZy = this
			};
		}

		private bool uffiHxaXoJmitkbAJMECpAKLBwie(int P_0, out int P_1)
		{
			P_1 = -1;
			if (!buttons[P_0].value || buttons[P_0].aSUKMgcrEWfMhhOukDBcFEBiIpQjb._excludeFromPolling)
			{
				return false;
			}
			P_1 = NOuTtyJvdlwLlfoBgXbDwbqIGPrIA.buttonElementIdentifierIds[P_0];
			if (P_1 < 0)
			{
				return false;
			}
			return true;
		}

		private bool CpUcuHktIxWGbWjHqchGbPokHrXxA(int P_0, out int P_1)
		{
			P_1 = -1;
			if (!buttons[P_0].justPressed || buttons[P_0].aSUKMgcrEWfMhhOukDBcFEBiIpQjb._excludeFromPolling)
			{
				return false;
			}
			P_1 = NOuTtyJvdlwLlfoBgXbDwbqIGPrIA.buttonElementIdentifierIds[P_0];
			if (P_1 < 0)
			{
				return false;
			}
			return true;
		}

		protected void UpdatePollingFrameTracking()
		{
			if (EUKDcSGdkTRdnIuUCYglilUmZENe == ReInput.currentFrame)
			{
				return;
			}
			kYTbvVMvmIXgICazpMUTwLauRQqO = EUKDcSGdkTRdnIuUCYglilUmZENe;
			EUKDcSGdkTRdnIuUCYglilUmZENe = ReInput.currentFrame;
			if (!OXYOSXPBNEmrOvfCUkCpzTLeHJRn)
			{
				if (BuBkhoCeHoPmaBbYAezaFlEXsyXFA == uint.MaxValue)
				{
					BuBkhoCeHoPmaBbYAezaFlEXsyXFA = 0u;
				}
				else
				{
					BuBkhoCeHoPmaBbYAezaFlEXsyXFA++;
				}
			}
		}

		public virtual double GetLastTimeActive()
		{
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
				return 0.0;
			}
			return GetLastTimeActive(useRawValues: false);
		}

		public virtual double GetLastTimeActive(bool useRawValues)
		{
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
				return 0.0;
			}
			return GetLastTimeAnyButtonPressed();
		}

		public virtual double GetLastTimeAnyElementChanged()
		{
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
				return 0.0;
			}
			return GetLastTimeAnyElementChanged(useRawValues: false);
		}

		public virtual double GetLastTimeAnyElementChanged(bool useRawValues)
		{
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
				return 0.0;
			}
			return GetLastTimeAnyButtonChanged();
		}

		public double GetLastTimeAnyButtonPressed()
		{
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
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
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
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
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
				return null;
			}
			return ngDnUhxHnEfOJyHKjfApiLvPGrhbA as T;
		}

		public IControllerTemplate GetTemplate(Guid typeGuid)
		{
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
				return null;
			}
			for (int i = 0; i < AwteOeIBUHpuVCrgkbBBezEtsvrvB.Length; i++)
			{
				if (AwteOeIBUHpuVCrgkbBBezEtsvrvB[i].typeGuid == typeGuid)
				{
					return AwteOeIBUHpuVCrgkbBBezEtsvrvB[i];
				}
			}
			return null;
		}

		public IControllerTemplate GetTemplate(Type type)
		{
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
				return null;
			}
			for (int i = 0; i < AwteOeIBUHpuVCrgkbBBezEtsvrvB.Length; i++)
			{
				if (ReflectionTools.DoesTypeImplement(AwteOeIBUHpuVCrgkbBBezEtsvrvB[i].GetType(), type))
				{
					return AwteOeIBUHpuVCrgkbBBezEtsvrvB[i];
				}
			}
			return null;
		}

		public T GetTemplate<T>() where T : class
		{
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
				return null;
			}
			for (int i = 0; i < AwteOeIBUHpuVCrgkbBBezEtsvrvB.Length; i++)
			{
				if (AwteOeIBUHpuVCrgkbBBezEtsvrvB[i] as T != null)
				{
					return AwteOeIBUHpuVCrgkbBBezEtsvrvB[i] as T;
				}
			}
			return null;
		}

		public bool ImplementsTemplate(Guid typeGuid)
		{
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
				return false;
			}
			for (int i = 0; i < AwteOeIBUHpuVCrgkbBBezEtsvrvB.Length; i++)
			{
				if (AwteOeIBUHpuVCrgkbBBezEtsvrvB[i].typeGuid == typeGuid)
				{
					return true;
				}
			}
			return false;
		}

		public bool ImplementsTemplate(Type type)
		{
			if (ReInput._id != RNlNSHGtJEPoWjxDZtJLBSknIDFA)
			{
				ReInput.CheckInitialized(RNlNSHGtJEPoWjxDZtJLBSknIDFA);
				return false;
			}
			if (type == null)
			{
				throw new ArgumentNullException("type");
			}
			for (int i = 0; i < AwteOeIBUHpuVCrgkbBBezEtsvrvB.Length; i++)
			{
				if (ReflectionTools.DoesTypeImplement(AwteOeIBUHpuVCrgkbBBezEtsvrvB[i].GetType(), type))
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

		internal void FJbdfSohWJVrPumACiZyeTmvMgo(IControllerTemplate[] P_0)
		{
			if (P_0 != null)
			{
				AwteOeIBUHpuVCrgkbBBezEtsvrvB = P_0;
				sJDdvTJMiLMFxEODehOhCZiMwARBA = new ReadOnlyCollection<IControllerTemplate>(AwteOeIBUHpuVCrgkbBBezEtsvrvB);
			}
		}

		internal virtual void EjKubThADKiQfHetvzpyLeiJitWy(UpdateLoopType P_0)
		{
			bool num = ReInput.IsInputAllowed(_type);
			int num2 = _buttonCount;
			if (num)
			{
				for (int i = 0; i < num2; i++)
				{
					if (buttons[i].eUwqiczNEObenThGbZsvqmCniEEN <= 0)
					{
						buttons[i].pWDTEHOcRLCmXFYtuUlfcneHqaNg(P_0, i, rGVdhXruOTgLzoPtrwxfhKmroixX);
					}
				}
			}
			else
			{
				for (int j = 0; j < num2; j++)
				{
					if (buttons[j].eUwqiczNEObenThGbZsvqmCniEEN <= 0)
					{
						buttons[j].DmBYvdIySTAYsdznLPPWmWZWEVqS(P_0);
					}
				}
			}
			if (ngDnUhxHnEfOJyHKjfApiLvPGrhbA != null)
			{
				ngDnUhxHnEfOJyHKjfApiLvPGrhbA.UpdateData(P_0);
			}
		}

		internal virtual ButtonStateFlags yehBEnXaAKxiWiRImrhBbPFadejM(int P_0)
		{
			if (P_0 < 0 || P_0 >= _buttonCount)
			{
				return ButtonStateFlags.Off;
			}
			return buttons[P_0].OdxRneCcNzIlXRkJHBTfUxnuJnfR;
		}

		internal void TfqwmlxgOXgbWEQiRooFmIJsIcEz(Extension P_0)
		{
			if (P_0 == null)
			{
				ngDnUhxHnEfOJyHKjfApiLvPGrhbA = null;
				return;
			}
			if (ngDnUhxHnEfOJyHKjfApiLvPGrhbA != null)
			{
				JoyknPwzFMFtLFLmSnRJMZwhojDP(P_0);
				return;
			}
			P_0.SetController(this);
			ngDnUhxHnEfOJyHKjfApiLvPGrhbA = P_0.Clone();
		}

		internal void JoyknPwzFMFtLFLmSnRJMZwhojDP(Extension P_0)
		{
			if (ngDnUhxHnEfOJyHKjfApiLvPGrhbA != null)
			{
				ngDnUhxHnEfOJyHKjfApiLvPGrhbA.SetSource(P_0);
				ngDnUhxHnEfOJyHKjfApiLvPGrhbA.SetController(this);
				P_0?.SetController(this);
			}
			else
			{
				TfqwmlxgOXgbWEQiRooFmIJsIcEz(P_0);
			}
		}

		internal virtual void gBKPqeqzjNmvysiIfrLGGzRfmdWS()
		{
			for (int i = 0; i < _buttonCount; i++)
			{
				if (buttons[i] != null)
				{
					buttons[i].Reset();
				}
			}
			if (rGVdhXruOTgLzoPtrwxfhKmroixX != null)
			{
				rGVdhXruOTgLzoPtrwxfhKmroixX.ClearData();
			}
			if (ngDnUhxHnEfOJyHKjfApiLvPGrhbA != null)
			{
				ngDnUhxHnEfOJyHKjfApiLvPGrhbA.Clear();
			}
		}

		internal virtual bool BXxyidqXWhYGVbTpYPscakwYIxji(bool P_0)
		{
			if (VFQdnPKjDpctTKtTLcDZIHPTCbfBb == P_0)
			{
				return false;
			}
			if (!P_0)
			{
				gBKPqeqzjNmvysiIfrLGGzRfmdWS();
			}
			VFQdnPKjDpctTKtTLcDZIHPTCbfBb = P_0;
			if (TmwFlKexfkfoavVjeMqJmWrWMKJB != null)
			{
				TmwFlKexfkfoavVjeMqJmWrWMKJB(P_0);
			}
			return true;
		}

		internal virtual void CcpVpJXpmYkVYgqCIFpzMFDIxVbs(ControllerMap P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			P_0.controllerId = id;
			IList<ActionElementMap> buttonMaps = P_0.ButtonMaps;
			for (int i = 0; i < buttonMaps.Count; i++)
			{
				KQvZlmyPDCAbJMosZEJiaypfudNPA(P_0, buttonMaps[i]);
			}
			for (int num = buttonMaps.Count - 1; num >= 0; num--)
			{
				if (buttonMaps[num].elementIndex < 0)
				{
					P_0.DeleteElementMap(buttonMaps[num].kzHrLfsGRteEloHDejoDrezLTRte);
				}
			}
		}

		internal virtual void KQvZlmyPDCAbJMosZEJiaypfudNPA(ControllerMap P_0, ActionElementMap P_1)
		{
			if (P_1 != null && P_1._elementType == ControllerElementType.Button)
			{
				P_1.TdyJaYSxTvfwLaVFZuETMDHOmkgH(P_0);
			}
		}

		internal bool AYEwZklcZZforJEviNsHDnEMqwFeA(ActionElementMap P_0, int P_1, out float P_2, out bool P_3)
		{
			P_3 = false;
			P_2 = 0f;
			if (P_1 != P_0._actionId)
			{
				return false;
			}
			int zfBLdNSKjJTOCMpfLtMTErUQCWJJ = P_0.zfBLdNSKjJTOCMpfLtMTErUQCWJJ;
			if (zfBLdNSKjJTOCMpfLtMTErUQCWJJ < 0 || zfBLdNSKjJTOCMpfLtMTErUQCWJJ >= _buttonCount)
			{
				return false;
			}
			P_3 = buttons[zfBLdNSKjJTOCMpfLtMTErUQCWJJ].vMphZPguDDJgBklIksBgEHUMzlPm;
			float num = ((!P_3) ? (buttons[zfBLdNSKjJTOCMpfLtMTErUQCWJJ].value ? 1f : 0f) : buttons[zfBLdNSKjJTOCMpfLtMTErUQCWJJ].pressure);
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

		internal bool kxwFCVBebIFAvUkeCWkfvTWmvDtvA(ActionElementMap P_0, int P_1, bool P_2, out float P_3)
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

		internal void SsiDSPXeljgWKetbvUQnvIjmeXiV(Element P_0)
		{
			if (P_0 != null)
			{
				ListTools.AddIfUnique(xdrjRazQCcHfoXFTrACgtTCcUnQl, P_0);
			}
		}

		internal void bLPAYawLrzGccouFaIolYrjFjlkO(CompoundElement P_0)
		{
			if (P_0 != null)
			{
				ListTools.AddIfUnique(UijcevOBwMLIRGeABlSOiHgkmvGw, P_0);
			}
		}

		internal virtual Guid tXLCSDFrptACnQAfMpAdnCRtVaob()
		{
			return Guid.Empty;
		}

		internal virtual void kPvFlhTMbqOrsGoGXbaCUFtGvwxE(bool P_0)
		{
			if (!P_0 && !ReInput.IsInputAllowed(_type) && ngDnUhxHnEfOJyHKjfApiLvPGrhbA != null)
			{
				ngDnUhxHnEfOJyHKjfApiLvPGrhbA.Clear();
			}
		}

		protected virtual void Connected()
		{
			_isConnected = true;
		}

		protected virtual void Disconnected()
		{
			_isConnected = false;
			if (rGVdhXruOTgLzoPtrwxfhKmroixX != null)
			{
				rGVdhXruOTgLzoPtrwxfhKmroixX.ClearData();
			}
		}
	}
}
