using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
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
			internal abstract class uTPXnhzPFmVKSTMzVUovlNlEexSG
			{
				public abstract class rkEPALCYcPglLssmPSDxTzNayWVk
				{
					public abstract void FdiBiKAImmpnEpuxsfGHIKWOntJW();
				}

				protected readonly int DlDUsLlpBvqNHmrStIlRMmcqIGTm;

				protected readonly int[] UHKLSpoLzelQYPHaetCSVUuEETYy;

				protected rkEPALCYcPglLssmPSDxTzNayWVk[] HExjRFoOrVAZDUFDtywRFfyHIPxD;

				public rkEPALCYcPglLssmPSDxTzNayWVk DYjVvqYGLxBHEKxbyyUEufqtMyAgA;

				private int jcqoxLplRZebcmdMFKpecIeBUcvc;

				public int wOwyuiEMsKezEhHOIZpuEOhSgQQM = -1;

				protected ReadOnlyCollection<rkEPALCYcPglLssmPSDxTzNayWVk> itreeEEQfHDwvXdRVBQHprsoIjyO;

				public IList<rkEPALCYcPglLssmPSDxTzNayWVk> tZJgshAButFylhErZuuacnMNUztq => itreeEEQfHDwvXdRVBQHprsoIjyO;

				public UpdateLoopType wfDkfLFAWLtbXKlXNZBzJXcqLlKP
				{
					set
					{
						if (wOwyuiEMsKezEhHOIZpuEOhSgQQM != (int)updateLoopType)
						{
							wOwyuiEMsKezEhHOIZpuEOhSgQQM = (int)updateLoopType;
							jcqoxLplRZebcmdMFKpecIeBUcvc = UHKLSpoLzelQYPHaetCSVUuEETYy[(int)updateLoopType];
							DYjVvqYGLxBHEKxbyyUEufqtMyAgA = HExjRFoOrVAZDUFDtywRFfyHIPxD[jcqoxLplRZebcmdMFKpecIeBUcvc];
						}
					}
				}

				public uTPXnhzPFmVKSTMzVUovlNlEexSG(UpdateLoopSetting P_0)
				{
					UHKLSpoLzelQYPHaetCSVUuEETYy = new int[3];
					DlDUsLlpBvqNHmrStIlRMmcqIGTm = 0;
					using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
					{
						List<UpdateLoopType> list = tList.list;
						EnumConverter.ToUpdateLoopTypes(P_0, list);
						for (int i = 0; i < list.Count; i++)
						{
							UHKLSpoLzelQYPHaetCSVUuEETYy[(int)list[i]] = DlDUsLlpBvqNHmrStIlRMmcqIGTm;
							DlDUsLlpBvqNHmrStIlRMmcqIGTm++;
						}
					}
					HExjRFoOrVAZDUFDtywRFfyHIPxD = new rkEPALCYcPglLssmPSDxTzNayWVk[DlDUsLlpBvqNHmrStIlRMmcqIGTm];
					itreeEEQfHDwvXdRVBQHprsoIjyO = new ReadOnlyCollection<rkEPALCYcPglLssmPSDxTzNayWVk>(HExjRFoOrVAZDUFDtywRFfyHIPxD);
				}

				public void PrxGgLrRYEcmSfUJTqwabKUyzHlnA()
				{
					for (int i = 0; i < DlDUsLlpBvqNHmrStIlRMmcqIGTm; i++)
					{
						HExjRFoOrVAZDUFDtywRFfyHIPxD[i].FdiBiKAImmpnEpuxsfGHIKWOntJW();
					}
				}

				public rkEPALCYcPglLssmPSDxTzNayWVk CbxgLeznoAtzKUUJaKriAUftCjfL(UpdateLoopType P_0)
				{
					return HExjRFoOrVAZDUFDtywRFfyHIPxD[UHKLSpoLzelQYPHaetCSVUuEETYy[(int)P_0]];
				}
			}

			public readonly int id;

			public readonly string name;

			public readonly ControllerElementType type;

			internal uTPXnhzPFmVKSTMzVUovlNlEexSG cNkpWHSOMkaWzLCPxJsenANMAyLe;

			internal int syoyrWlrQxnXHlRCagQSbdPqHsHn;

			internal Controller WiYiRLTehfcPjuHpvomznsiiIAfK;

			internal readonly int puKSwsOuudnInZOLmdUEibtEaSIAb;

			private CompoundElement QyzGNEaokbNNngHmBffLCinzwrkf;

			private bool kyCcJBKiiDSGLxXupSCTUzfkpnTZ;

			public ControllerElementIdentifier elementIdentifier
			{
				get
				{
					if (ReInput._id != puKSwsOuudnInZOLmdUEibtEaSIAb)
					{
						ReInput.CheckInitialized(puKSwsOuudnInZOLmdUEibtEaSIAb);
						return null;
					}
					ControllerElementIdentifier elementIdentifierById = WiYiRLTehfcPjuHpvomznsiiIAfK.GetElementIdentifierById(id);
					if (elementIdentifierById == null)
					{
						return ControllerElementIdentifier.BlankReadOnly;
					}
					return elementIdentifierById;
				}
			}

			public virtual bool excludeFromPolling
			{
				get
				{
					if (ReInput._id != puKSwsOuudnInZOLmdUEibtEaSIAb)
					{
						ReInput.CheckInitialized(puKSwsOuudnInZOLmdUEibtEaSIAb);
						return false;
					}
					return kyCcJBKiiDSGLxXupSCTUzfkpnTZ;
				}
				set
				{
					if (ReInput._id != puKSwsOuudnInZOLmdUEibtEaSIAb)
					{
						ReInput.CheckInitialized(puKSwsOuudnInZOLmdUEibtEaSIAb);
					}
					else
					{
						kyCcJBKiiDSGLxXupSCTUzfkpnTZ = value;
					}
				}
			}

			public bool isMemberElement
			{
				get
				{
					if (ReInput._id != puKSwsOuudnInZOLmdUEibtEaSIAb)
					{
						ReInput.CheckInitialized(puKSwsOuudnInZOLmdUEibtEaSIAb);
						return false;
					}
					return syoyrWlrQxnXHlRCagQSbdPqHsHn > 0;
				}
			}

			public CompoundElement compoundElement => QyzGNEaokbNNngHmBffLCinzwrkf;

			internal Element(Controller P_0, int P_1, string P_2, ControllerElementType P_3)
			{
				WiYiRLTehfcPjuHpvomznsiiIAfK = P_0;
				id = P_1;
				name = P_2;
				type = P_3;
				puKSwsOuudnInZOLmdUEibtEaSIAb = ReInput.id;
			}

			public void Reset()
			{
				if (ReInput._id != puKSwsOuudnInZOLmdUEibtEaSIAb)
				{
					ReInput.CheckInitialized(puKSwsOuudnInZOLmdUEibtEaSIAb);
				}
				else if (cNkpWHSOMkaWzLCPxJsenANMAyLe != null)
				{
					cNkpWHSOMkaWzLCPxJsenANMAyLe.PrxGgLrRYEcmSfUJTqwabKUyzHlnA();
				}
			}

			internal void bHQRtxzlQgmEUepQsFxfNPLULeWK(CompoundElement P_0)
			{
				if (syoyrWlrQxnXHlRCagQSbdPqHsHn > 0)
				{
					Logger.LogWarning("This element is already a member of a compound element! This is not supported. Resulting values may be unpredictable.");
				}
				syoyrWlrQxnXHlRCagQSbdPqHsHn++;
				if (QyzGNEaokbNNngHmBffLCinzwrkf == null)
				{
					QyzGNEaokbNNngHmBffLCinzwrkf = P_0;
				}
			}

			internal void oOtXDFzkHcwXBHJGMkNUSpuBWTHO(CompoundElement P_0)
			{
				if (syoyrWlrQxnXHlRCagQSbdPqHsHn == 0)
				{
					Logger.LogWarning("This element is not a member of a compound element!");
					syoyrWlrQxnXHlRCagQSbdPqHsHn = 0;
					return;
				}
				syoyrWlrQxnXHlRCagQSbdPqHsHn--;
				if (QyzGNEaokbNNngHmBffLCinzwrkf == P_0)
				{
					QyzGNEaokbNNngHmBffLCinzwrkf = null;
				}
			}
		}

		public sealed class Axis : Element
		{
			internal class zATCIkrUCixHKRxCfeuSyMFsWOvI : uTPXnhzPFmVKSTMzVUovlNlEexSG
			{
				public class sjPCBGwOGMFbVGFEgvpjEYzOjNrT : rkEPALCYcPglLssmPSDxTzNayWVk
				{
					private const float yTSXliPBJBVSmapiUIiIFXLLZprIA = 0.001f;

					public float cadYmvYpCIgLbFELYaDzepegGrYT;

					public float EMJawJQbddEjHbaBjAfagoRWkGnuA;

					public float tqcdYMvozudGXUcgObMTDUgPdFqzA;

					public float MHYCefbrfogquLkcRllSAqRMrKYCb;

					public float TTrUPXLLsGguReTxklxBblCDRemYA;

					public float oDmRAMxKYQqgSkSDTKsAFBmFhlio;

					public double QRTdDozkDdHffpdUwglXNcTCcYbW;

					public double gganNVVSvsrcpZllGQPzrIdqpPEc;

					public double vCnnKTYhjUHhQGTmGMDHMIAEJfOA;

					public double JDKtADQGPFJyLDPKOyWqxYWZKgHd;

					public double XtLKgvfvqjunyWYxwlTysXdyhtne;

					public double ikYhsRINDnbdCglbzkbJXmgeXOuD;

					public double TEvVsearhJOsahcqBTIoUFScMxfA
					{
						get
						{
							if ((double)cadYmvYpCIgLbFELYaDzepegGrYT == 0.0)
							{
								return 0.0;
							}
							return ReInput.unscaledTime - vCnnKTYhjUHhQGTmGMDHMIAEJfOA;
						}
					}

					public double EEIhwMUxiYaeQFAdrUFilJVWBEaW
					{
						get
						{
							if ((double)tqcdYMvozudGXUcgObMTDUgPdFqzA == 0.0)
							{
								return 0.0;
							}
							return ReInput.unscaledTime - JDKtADQGPFJyLDPKOyWqxYWZKgHd;
						}
					}

					public double xWXbyoXBwrtvIGBMdHfNwQpYBlwFA
					{
						get
						{
							if (cadYmvYpCIgLbFELYaDzepegGrYT != 0f)
							{
								return 0.0;
							}
							return ReInput.unscaledTime - QRTdDozkDdHffpdUwglXNcTCcYbW;
						}
					}

					public double HeDyhKxmdxsFwlgdPAbxggvhOUuZ
					{
						get
						{
							if ((double)tqcdYMvozudGXUcgObMTDUgPdFqzA != 0.0)
							{
								return 0.0;
							}
							return ReInput.unscaledTime - gganNVVSvsrcpZllGQPzrIdqpPEc;
						}
					}

					public void JFSCRahIDYUEqXJMiRtICfjttFBK(bool P_0)
					{
						double unscaledTime = ReInput.unscaledTime;
						if (P_0)
						{
							if (!MathTools.Approximately(TTrUPXLLsGguReTxklxBblCDRemYA, 0f))
							{
								QRTdDozkDdHffpdUwglXNcTCcYbW = unscaledTime;
							}
							else
							{
								vCnnKTYhjUHhQGTmGMDHMIAEJfOA = unscaledTime;
							}
							if (!MathTools.IsNear(TTrUPXLLsGguReTxklxBblCDRemYA, oDmRAMxKYQqgSkSDTKsAFBmFhlio, 0.001f))
							{
								XtLKgvfvqjunyWYxwlTysXdyhtne = unscaledTime;
							}
						}
						else
						{
							if (!MathTools.Approximately(cadYmvYpCIgLbFELYaDzepegGrYT, 0f))
							{
								QRTdDozkDdHffpdUwglXNcTCcYbW = unscaledTime;
							}
							else
							{
								vCnnKTYhjUHhQGTmGMDHMIAEJfOA = unscaledTime;
							}
							if (!MathTools.IsNear(cadYmvYpCIgLbFELYaDzepegGrYT, EMJawJQbddEjHbaBjAfagoRWkGnuA, 0.001f))
							{
								XtLKgvfvqjunyWYxwlTysXdyhtne = unscaledTime;
							}
						}
						if (!MathTools.Approximately(tqcdYMvozudGXUcgObMTDUgPdFqzA, 0f))
						{
							gganNVVSvsrcpZllGQPzrIdqpPEc = unscaledTime;
						}
						else
						{
							JDKtADQGPFJyLDPKOyWqxYWZKgHd = unscaledTime;
						}
						if (!MathTools.IsNear(tqcdYMvozudGXUcgObMTDUgPdFqzA, MHYCefbrfogquLkcRllSAqRMrKYCb, 0.001f))
						{
							ikYhsRINDnbdCglbzkbJXmgeXOuD = unscaledTime;
						}
					}

					public void fBApErmlCtlRDhGMFxqkOQxNSFOu(float P_0)
					{
						if (MHYCefbrfogquLkcRllSAqRMrKYCb != tqcdYMvozudGXUcgObMTDUgPdFqzA)
						{
							MHYCefbrfogquLkcRllSAqRMrKYCb = tqcdYMvozudGXUcgObMTDUgPdFqzA;
						}
						if (tqcdYMvozudGXUcgObMTDUgPdFqzA != P_0)
						{
							tqcdYMvozudGXUcgObMTDUgPdFqzA = P_0;
						}
					}

					public virtual void iHQqhsIeQufJDAPmznMGteBgSfMGb()
					{
						cadYmvYpCIgLbFELYaDzepegGrYT = 0f;
						EMJawJQbddEjHbaBjAfagoRWkGnuA = 0f;
						tqcdYMvozudGXUcgObMTDUgPdFqzA = 0f;
						MHYCefbrfogquLkcRllSAqRMrKYCb = 0f;
						QRTdDozkDdHffpdUwglXNcTCcYbW = 0.0;
						gganNVVSvsrcpZllGQPzrIdqpPEc = 0.0;
						vCnnKTYhjUHhQGTmGMDHMIAEJfOA = 0.0;
						JDKtADQGPFJyLDPKOyWqxYWZKgHd = 0.0;
						XtLKgvfvqjunyWYxwlTysXdyhtne = 0.0;
						ikYhsRINDnbdCglbzkbJXmgeXOuD = 0.0;
					}
				}

				public zATCIkrUCixHKRxCfeuSyMFsWOvI(UpdateLoopSetting P_0)
					: base(P_0)
				{
					for (int i = 0; i < DlDUsLlpBvqNHmrStIlRMmcqIGTm; i++)
					{
						HExjRFoOrVAZDUFDtywRFfyHIPxD[i] = new sjPCBGwOGMFbVGFEgvpjEYzOjNrT();
					}
					DYjVvqYGLxBHEKxbyyUEufqtMyAgA = HExjRFoOrVAZDUFDtywRFfyHIPxD[0];
				}
			}

			internal readonly AxisRange vuBQOVlhBAgZDdssxAcPtlCrEcSy;

			internal readonly HardwareAxisInfo aWgdabdFXKHTbUDLyoVfrwOlgFah;

			public float value
			{
				get
				{
					if (ReInput._id != puKSwsOuudnInZOLmdUEibtEaSIAb)
					{
						ReInput.CheckInitialized(puKSwsOuudnInZOLmdUEibtEaSIAb);
						return 0f;
					}
					if (base.isMemberElement)
					{
						return ((zATCIkrUCixHKRxCfeuSyMFsWOvI.sjPCBGwOGMFbVGFEgvpjEYzOjNrT)cNkpWHSOMkaWzLCPxJsenANMAyLe.DYjVvqYGLxBHEKxbyyUEufqtMyAgA).TTrUPXLLsGguReTxklxBblCDRemYA;
					}
					return ((zATCIkrUCixHKRxCfeuSyMFsWOvI.sjPCBGwOGMFbVGFEgvpjEYzOjNrT)cNkpWHSOMkaWzLCPxJsenANMAyLe.DYjVvqYGLxBHEKxbyyUEufqtMyAgA).cadYmvYpCIgLbFELYaDzepegGrYT;
				}
			}

			public float valuePrev
			{
				get
				{
					if (ReInput._id != puKSwsOuudnInZOLmdUEibtEaSIAb)
					{
						ReInput.CheckInitialized(puKSwsOuudnInZOLmdUEibtEaSIAb);
						return 0f;
					}
					if (base.isMemberElement)
					{
						return ((zATCIkrUCixHKRxCfeuSyMFsWOvI.sjPCBGwOGMFbVGFEgvpjEYzOjNrT)cNkpWHSOMkaWzLCPxJsenANMAyLe.DYjVvqYGLxBHEKxbyyUEufqtMyAgA).oDmRAMxKYQqgSkSDTKsAFBmFhlio;
					}
					return ((zATCIkrUCixHKRxCfeuSyMFsWOvI.sjPCBGwOGMFbVGFEgvpjEYzOjNrT)cNkpWHSOMkaWzLCPxJsenANMAyLe.DYjVvqYGLxBHEKxbyyUEufqtMyAgA).EMJawJQbddEjHbaBjAfagoRWkGnuA;
				}
			}

			public float valueRaw
			{
				get
				{
					if (ReInput._id != puKSwsOuudnInZOLmdUEibtEaSIAb)
					{
						ReInput.CheckInitialized(puKSwsOuudnInZOLmdUEibtEaSIAb);
						return 0f;
					}
					return ((zATCIkrUCixHKRxCfeuSyMFsWOvI.sjPCBGwOGMFbVGFEgvpjEYzOjNrT)cNkpWHSOMkaWzLCPxJsenANMAyLe.DYjVvqYGLxBHEKxbyyUEufqtMyAgA).tqcdYMvozudGXUcgObMTDUgPdFqzA;
				}
				internal set
				{
					((zATCIkrUCixHKRxCfeuSyMFsWOvI.sjPCBGwOGMFbVGFEgvpjEYzOjNrT)cNkpWHSOMkaWzLCPxJsenANMAyLe.DYjVvqYGLxBHEKxbyyUEufqtMyAgA).fBApErmlCtlRDhGMFxqkOQxNSFOu(num);
				}
			}

			public float valueRawPrev
			{
				get
				{
					if (ReInput._id != puKSwsOuudnInZOLmdUEibtEaSIAb)
					{
						ReInput.CheckInitialized(puKSwsOuudnInZOLmdUEibtEaSIAb);
						return 0f;
					}
					return ((zATCIkrUCixHKRxCfeuSyMFsWOvI.sjPCBGwOGMFbVGFEgvpjEYzOjNrT)cNkpWHSOMkaWzLCPxJsenANMAyLe.DYjVvqYGLxBHEKxbyyUEufqtMyAgA).MHYCefbrfogquLkcRllSAqRMrKYCb;
				}
			}

			public float valueDelta
			{
				get
				{
					if (ReInput._id != puKSwsOuudnInZOLmdUEibtEaSIAb)
					{
						ReInput.CheckInitialized(puKSwsOuudnInZOLmdUEibtEaSIAb);
						return 0f;
					}
					return value - valuePrev;
				}
			}

			public float valueDeltaRaw
			{
				get
				{
					if (ReInput._id != puKSwsOuudnInZOLmdUEibtEaSIAb)
					{
						ReInput.CheckInitialized(puKSwsOuudnInZOLmdUEibtEaSIAb);
						return 0f;
					}
					return ((zATCIkrUCixHKRxCfeuSyMFsWOvI.sjPCBGwOGMFbVGFEgvpjEYzOjNrT)cNkpWHSOMkaWzLCPxJsenANMAyLe.DYjVvqYGLxBHEKxbyyUEufqtMyAgA).tqcdYMvozudGXUcgObMTDUgPdFqzA - ((zATCIkrUCixHKRxCfeuSyMFsWOvI.sjPCBGwOGMFbVGFEgvpjEYzOjNrT)cNkpWHSOMkaWzLCPxJsenANMAyLe.DYjVvqYGLxBHEKxbyyUEufqtMyAgA).MHYCefbrfogquLkcRllSAqRMrKYCb;
				}
			}

			public double lastTimeActive
			{
				get
				{
					if (ReInput._id != puKSwsOuudnInZOLmdUEibtEaSIAb)
					{
						ReInput.CheckInitialized(puKSwsOuudnInZOLmdUEibtEaSIAb);
						return 0.0;
					}
					return ((zATCIkrUCixHKRxCfeuSyMFsWOvI.sjPCBGwOGMFbVGFEgvpjEYzOjNrT)cNkpWHSOMkaWzLCPxJsenANMAyLe.DYjVvqYGLxBHEKxbyyUEufqtMyAgA).QRTdDozkDdHffpdUwglXNcTCcYbW;
				}
			}

			public double lastTimeActiveRaw
			{
				get
				{
					if (ReInput._id != puKSwsOuudnInZOLmdUEibtEaSIAb)
					{
						ReInput.CheckInitialized(puKSwsOuudnInZOLmdUEibtEaSIAb);
						return 0.0;
					}
					return ((zATCIkrUCixHKRxCfeuSyMFsWOvI.sjPCBGwOGMFbVGFEgvpjEYzOjNrT)cNkpWHSOMkaWzLCPxJsenANMAyLe.DYjVvqYGLxBHEKxbyyUEufqtMyAgA).gganNVVSvsrcpZllGQPzrIdqpPEc;
				}
			}

			public double lastTimeInactive
			{
				get
				{
					if (ReInput._id != puKSwsOuudnInZOLmdUEibtEaSIAb)
					{
						ReInput.CheckInitialized(puKSwsOuudnInZOLmdUEibtEaSIAb);
						return 0.0;
					}
					return ((zATCIkrUCixHKRxCfeuSyMFsWOvI.sjPCBGwOGMFbVGFEgvpjEYzOjNrT)cNkpWHSOMkaWzLCPxJsenANMAyLe.DYjVvqYGLxBHEKxbyyUEufqtMyAgA).vCnnKTYhjUHhQGTmGMDHMIAEJfOA;
				}
			}

			public double lastTimeInactiveRaw
			{
				get
				{
					if (ReInput._id != puKSwsOuudnInZOLmdUEibtEaSIAb)
					{
						ReInput.CheckInitialized(puKSwsOuudnInZOLmdUEibtEaSIAb);
						return 0.0;
					}
					return ((zATCIkrUCixHKRxCfeuSyMFsWOvI.sjPCBGwOGMFbVGFEgvpjEYzOjNrT)cNkpWHSOMkaWzLCPxJsenANMAyLe.DYjVvqYGLxBHEKxbyyUEufqtMyAgA).JDKtADQGPFJyLDPKOyWqxYWZKgHd;
				}
			}

			public double lastTimeValueChanged
			{
				get
				{
					if (ReInput._id != puKSwsOuudnInZOLmdUEibtEaSIAb)
					{
						ReInput.CheckInitialized(puKSwsOuudnInZOLmdUEibtEaSIAb);
						return 0.0;
					}
					return ((zATCIkrUCixHKRxCfeuSyMFsWOvI.sjPCBGwOGMFbVGFEgvpjEYzOjNrT)cNkpWHSOMkaWzLCPxJsenANMAyLe.DYjVvqYGLxBHEKxbyyUEufqtMyAgA).XtLKgvfvqjunyWYxwlTysXdyhtne;
				}
			}

			public double lastTimeValueChangedRaw
			{
				get
				{
					if (ReInput._id != puKSwsOuudnInZOLmdUEibtEaSIAb)
					{
						ReInput.CheckInitialized(puKSwsOuudnInZOLmdUEibtEaSIAb);
						return 0.0;
					}
					return ((zATCIkrUCixHKRxCfeuSyMFsWOvI.sjPCBGwOGMFbVGFEgvpjEYzOjNrT)cNkpWHSOMkaWzLCPxJsenANMAyLe.DYjVvqYGLxBHEKxbyyUEufqtMyAgA).ikYhsRINDnbdCglbzkbJXmgeXOuD;
				}
			}

			public double timeActive
			{
				get
				{
					if (ReInput._id != puKSwsOuudnInZOLmdUEibtEaSIAb)
					{
						ReInput.CheckInitialized(puKSwsOuudnInZOLmdUEibtEaSIAb);
						return 0.0;
					}
					return ((zATCIkrUCixHKRxCfeuSyMFsWOvI.sjPCBGwOGMFbVGFEgvpjEYzOjNrT)cNkpWHSOMkaWzLCPxJsenANMAyLe.DYjVvqYGLxBHEKxbyyUEufqtMyAgA).TEvVsearhJOsahcqBTIoUFScMxfA;
				}
			}

			public double timeActiveRaw
			{
				get
				{
					if (ReInput._id != puKSwsOuudnInZOLmdUEibtEaSIAb)
					{
						ReInput.CheckInitialized(puKSwsOuudnInZOLmdUEibtEaSIAb);
						return 0.0;
					}
					return ((zATCIkrUCixHKRxCfeuSyMFsWOvI.sjPCBGwOGMFbVGFEgvpjEYzOjNrT)cNkpWHSOMkaWzLCPxJsenANMAyLe.DYjVvqYGLxBHEKxbyyUEufqtMyAgA).TEvVsearhJOsahcqBTIoUFScMxfA;
				}
			}

			public double timeInactive
			{
				get
				{
					if (ReInput._id != puKSwsOuudnInZOLmdUEibtEaSIAb)
					{
						ReInput.CheckInitialized(puKSwsOuudnInZOLmdUEibtEaSIAb);
						return 0.0;
					}
					return ((zATCIkrUCixHKRxCfeuSyMFsWOvI.sjPCBGwOGMFbVGFEgvpjEYzOjNrT)cNkpWHSOMkaWzLCPxJsenANMAyLe.DYjVvqYGLxBHEKxbyyUEufqtMyAgA).xWXbyoXBwrtvIGBMdHfNwQpYBlwFA;
				}
			}

			public double timeInactiveRaw
			{
				get
				{
					if (ReInput._id != puKSwsOuudnInZOLmdUEibtEaSIAb)
					{
						ReInput.CheckInitialized(puKSwsOuudnInZOLmdUEibtEaSIAb);
						return 0.0;
					}
					return ((zATCIkrUCixHKRxCfeuSyMFsWOvI.sjPCBGwOGMFbVGFEgvpjEYzOjNrT)cNkpWHSOMkaWzLCPxJsenANMAyLe.DYjVvqYGLxBHEKxbyyUEufqtMyAgA).HeDyhKxmdxsFwlgdPAbxggvhOUuZ;
				}
			}

			public float pollingDeadZone
			{
				get
				{
					if (ReInput._id != puKSwsOuudnInZOLmdUEibtEaSIAb)
					{
						ReInput.CheckInitialized(puKSwsOuudnInZOLmdUEibtEaSIAb);
						return 0f;
					}
					if (aWgdabdFXKHTbUDLyoVfrwOlgFah == null)
					{
						return -1f;
					}
					return aWgdabdFXKHTbUDLyoVfrwOlgFah._pollingDeadZone;
				}
				set
				{
					if (ReInput._id != puKSwsOuudnInZOLmdUEibtEaSIAb)
					{
						ReInput.CheckInitialized(puKSwsOuudnInZOLmdUEibtEaSIAb);
						return;
					}
					if (value < 0f)
					{
						value = -1f;
					}
					if (aWgdabdFXKHTbUDLyoVfrwOlgFah != null)
					{
						aWgdabdFXKHTbUDLyoVfrwOlgFah._pollingDeadZone = value;
					}
				}
			}

			public AxisCoordinateMode axisCoordinateMode
			{
				get
				{
					if (ReInput._id != puKSwsOuudnInZOLmdUEibtEaSIAb)
					{
						ReInput.CheckInitialized(puKSwsOuudnInZOLmdUEibtEaSIAb);
						return AxisCoordinateMode.Absolute;
					}
					if (aWgdabdFXKHTbUDLyoVfrwOlgFah == null)
					{
						return AxisCoordinateMode.Absolute;
					}
					return aWgdabdFXKHTbUDLyoVfrwOlgFah.dataFormat;
				}
			}

			bool Element.excludeFromPolling
			{
				get
				{
					if (ReInput._id != puKSwsOuudnInZOLmdUEibtEaSIAb)
					{
						ReInput.CheckInitialized(puKSwsOuudnInZOLmdUEibtEaSIAb);
						return false;
					}
					if (aWgdabdFXKHTbUDLyoVfrwOlgFah == null)
					{
						return base.excludeFromPolling;
					}
					return aWgdabdFXKHTbUDLyoVfrwOlgFah._excludeFromPolling;
				}
				set
				{
					if (ReInput._id != puKSwsOuudnInZOLmdUEibtEaSIAb)
					{
						ReInput.CheckInitialized(puKSwsOuudnInZOLmdUEibtEaSIAb);
						return;
					}
					if (aWgdabdFXKHTbUDLyoVfrwOlgFah != null)
					{
						aWgdabdFXKHTbUDLyoVfrwOlgFah._excludeFromPolling = value;
					}
					base.excludeFromPolling = value;
				}
			}

			internal float EHBoAENyGtULNCvgQjEEesAmAhYe => ((zATCIkrUCixHKRxCfeuSyMFsWOvI.sjPCBGwOGMFbVGFEgvpjEYzOjNrT)cNkpWHSOMkaWzLCPxJsenANMAyLe.DYjVvqYGLxBHEKxbyyUEufqtMyAgA).cadYmvYpCIgLbFELYaDzepegGrYT;

			internal float ZRXMrVQdfKgYGtRmIckPIwUcEpGv => ((zATCIkrUCixHKRxCfeuSyMFsWOvI.sjPCBGwOGMFbVGFEgvpjEYzOjNrT)cNkpWHSOMkaWzLCPxJsenANMAyLe.DYjVvqYGLxBHEKxbyyUEufqtMyAgA).EMJawJQbddEjHbaBjAfagoRWkGnuA;

			internal float QotXiKTAnzsOoreyziOokgBIJBeF
			{
				get
				{
					if (aWgdabdFXKHTbUDLyoVfrwOlgFah == null)
					{
						return ReInput.configuration.defaultAbsoluteAxisPollingDeadZone;
					}
					if (aWgdabdFXKHTbUDLyoVfrwOlgFah._pollingDeadZone >= 0f)
					{
						return aWgdabdFXKHTbUDLyoVfrwOlgFah._pollingDeadZone;
					}
					return aWgdabdFXKHTbUDLyoVfrwOlgFah._dataFormat switch
					{
						AxisCoordinateMode.Absolute => ReInput.configuration.defaultAbsoluteAxisPollingDeadZone, 
						AxisCoordinateMode.Relative => ReInput.configuration.defaultRelativeAxisPollingDeadZone, 
						_ => throw new NotImplementedException(), 
					};
				}
			}

			internal void BijOSRoSJXEvImPPWzVAwTJJyaXB(float P_0)
			{
				zATCIkrUCixHKRxCfeuSyMFsWOvI.sjPCBGwOGMFbVGFEgvpjEYzOjNrT obj = (zATCIkrUCixHKRxCfeuSyMFsWOvI.sjPCBGwOGMFbVGFEgvpjEYzOjNrT)cNkpWHSOMkaWzLCPxJsenANMAyLe.DYjVvqYGLxBHEKxbyyUEufqtMyAgA;
				obj.oDmRAMxKYQqgSkSDTKsAFBmFhlio = obj.TTrUPXLLsGguReTxklxBblCDRemYA;
				obj.TTrUPXLLsGguReTxklxBblCDRemYA = P_0;
			}

			internal Axis(Controller P_0, int P_1, string P_2, AxisRange P_3, HardwareAxisInfo P_4)
				: base(P_0, P_1, P_2, ControllerElementType.Axis)
			{
				cNkpWHSOMkaWzLCPxJsenANMAyLe = new zATCIkrUCixHKRxCfeuSyMFsWOvI(ReInput.configVars.updateLoop);
				vuBQOVlhBAgZDdssxAcPtlCrEcSy = P_3;
				aWgdabdFXKHTbUDLyoVfrwOlgFah = P_4;
				if (P_4 != null)
				{
					base.excludeFromPolling = P_4._excludeFromPolling;
				}
			}

			internal void uKozSjffJSMUqoeBPTBIbwXJDMNe(UpdateLoopType P_0)
			{
				if (cNkpWHSOMkaWzLCPxJsenANMAyLe != null && cNkpWHSOMkaWzLCPxJsenANMAyLe.wOwyuiEMsKezEhHOIZpuEOhSgQQM != (int)P_0)
				{
					cNkpWHSOMkaWzLCPxJsenANMAyLe.wfDkfLFAWLtbXKlXNZBzJXcqLlKP = P_0;
				}
			}

			internal void SGmUTImrEvbkPFCKoIgqtGTFGFMM(AxisCalibration P_0)
			{
				zATCIkrUCixHKRxCfeuSyMFsWOvI.sjPCBGwOGMFbVGFEgvpjEYzOjNrT sjPCBGwOGMFbVGFEgvpjEYzOjNrT = (zATCIkrUCixHKRxCfeuSyMFsWOvI.sjPCBGwOGMFbVGFEgvpjEYzOjNrT)cNkpWHSOMkaWzLCPxJsenANMAyLe.DYjVvqYGLxBHEKxbyyUEufqtMyAgA;
				sjPCBGwOGMFbVGFEgvpjEYzOjNrT.EMJawJQbddEjHbaBjAfagoRWkGnuA = sjPCBGwOGMFbVGFEgvpjEYzOjNrT.cadYmvYpCIgLbFELYaDzepegGrYT;
				float cadYmvYpCIgLbFELYaDzepegGrYT = P_0.GetCalibratedValue(sjPCBGwOGMFbVGFEgvpjEYzOjNrT.tqcdYMvozudGXUcgObMTDUgPdFqzA, vuBQOVlhBAgZDdssxAcPtlCrEcSy);
				if (P_0.applyRangeCalibration)
				{
					cadYmvYpCIgLbFELYaDzepegGrYT = MathTools.Clamp(cadYmvYpCIgLbFELYaDzepegGrYT, -1f, 1f);
				}
				sjPCBGwOGMFbVGFEgvpjEYzOjNrT.cadYmvYpCIgLbFELYaDzepegGrYT = cadYmvYpCIgLbFELYaDzepegGrYT;
			}

			internal void NeUtFMgSnYOIHiMKZShvFqWxHoxM()
			{
				zATCIkrUCixHKRxCfeuSyMFsWOvI.sjPCBGwOGMFbVGFEgvpjEYzOjNrT obj = (zATCIkrUCixHKRxCfeuSyMFsWOvI.sjPCBGwOGMFbVGFEgvpjEYzOjNrT)cNkpWHSOMkaWzLCPxJsenANMAyLe.DYjVvqYGLxBHEKxbyyUEufqtMyAgA;
				obj.EMJawJQbddEjHbaBjAfagoRWkGnuA = obj.cadYmvYpCIgLbFELYaDzepegGrYT;
				obj.cadYmvYpCIgLbFELYaDzepegGrYT = obj.tqcdYMvozudGXUcgObMTDUgPdFqzA;
			}

			internal void PWtyzGPEepWdjXEVSMOmzepnuCw()
			{
				zATCIkrUCixHKRxCfeuSyMFsWOvI.sjPCBGwOGMFbVGFEgvpjEYzOjNrT obj = (zATCIkrUCixHKRxCfeuSyMFsWOvI.sjPCBGwOGMFbVGFEgvpjEYzOjNrT)cNkpWHSOMkaWzLCPxJsenANMAyLe.DYjVvqYGLxBHEKxbyyUEufqtMyAgA;
				obj.EMJawJQbddEjHbaBjAfagoRWkGnuA = obj.cadYmvYpCIgLbFELYaDzepegGrYT;
				obj.cadYmvYpCIgLbFELYaDzepegGrYT = 0f;
			}

			internal void gtsugbZJetLrCzcjtTrQgdlvlQZH()
			{
				((zATCIkrUCixHKRxCfeuSyMFsWOvI.sjPCBGwOGMFbVGFEgvpjEYzOjNrT)cNkpWHSOMkaWzLCPxJsenANMAyLe.DYjVvqYGLxBHEKxbyyUEufqtMyAgA).JFSCRahIDYUEqXJMiRtICfjttFBK(base.isMemberElement);
			}

			internal void ZbtFKPBnqqxeQxRZUenQmAOaxEUc(float P_0)
			{
				for (int i = 0; i < cNkpWHSOMkaWzLCPxJsenANMAyLe.tZJgshAButFylhErZuuacnMNUztq.Count; i++)
				{
					if (cNkpWHSOMkaWzLCPxJsenANMAyLe.tZJgshAButFylhErZuuacnMNUztq[i] is zATCIkrUCixHKRxCfeuSyMFsWOvI.sjPCBGwOGMFbVGFEgvpjEYzOjNrT sjPCBGwOGMFbVGFEgvpjEYzOjNrT)
					{
						sjPCBGwOGMFbVGFEgvpjEYzOjNrT.fBApErmlCtlRDhGMFxqkOQxNSFOu(P_0);
						sjPCBGwOGMFbVGFEgvpjEYzOjNrT.EMJawJQbddEjHbaBjAfagoRWkGnuA = sjPCBGwOGMFbVGFEgvpjEYzOjNrT.cadYmvYpCIgLbFELYaDzepegGrYT;
						sjPCBGwOGMFbVGFEgvpjEYzOjNrT.cadYmvYpCIgLbFELYaDzepegGrYT = 0f;
						sjPCBGwOGMFbVGFEgvpjEYzOjNrT.JFSCRahIDYUEqXJMiRtICfjttFBK(base.isMemberElement);
					}
				}
			}

			internal float VpriZzyhDbOFiLGOsLVDsauJsqFY(UpdateLoopType P_0, AxisCalibration P_1)
			{
				zATCIkrUCixHKRxCfeuSyMFsWOvI.sjPCBGwOGMFbVGFEgvpjEYzOjNrT sjPCBGwOGMFbVGFEgvpjEYzOjNrT = (zATCIkrUCixHKRxCfeuSyMFsWOvI.sjPCBGwOGMFbVGFEgvpjEYzOjNrT)cNkpWHSOMkaWzLCPxJsenANMAyLe.CbxgLeznoAtzKUUJaKriAUftCjfL(P_0);
				float result = P_1.GetCalibratedValue(sjPCBGwOGMFbVGFEgvpjEYzOjNrT.tqcdYMvozudGXUcgObMTDUgPdFqzA, vuBQOVlhBAgZDdssxAcPtlCrEcSy, P_1.deadZone, P_1.upperDeadZone, applySensitivity: false, applyInversion: true);
				if (P_1.applyRangeCalibration)
				{
					result = MathTools.Clamp(result, -1f, 1f);
				}
				return result;
			}
		}

		public sealed class Button : Element
		{
			internal class wfKeZeeVWgFrbQdALauorsItTitTA : uTPXnhzPFmVKSTMzVUovlNlEexSG
			{
				public class IYgsSFmvIEiONYgvkvAFIRxusbjX : rkEPALCYcPglLssmPSDxTzNayWVk
				{
					public bool tQAYGnVyqmDxOcySvEqpRRRCYQPJ;

					public bool wECTHwhDljvwdgThFSJnBTPktARJ;

					public ButtonStateRecorder RmMREtocbrksQCoXwNsEPAWzigkQ;

					public fSmSyrrmGXABUOhSZBWNiFWkyILxA mrWufZEXDjDwuvVUZrViOCdYcAxY;

					public IYgsSFmvIEiONYgvkvAFIRxusbjX()
					{
						RmMREtocbrksQCoXwNsEPAWzigkQ = new ButtonStateRecorder();
						mrWufZEXDjDwuvVUZrViOCdYcAxY = new fSmSyrrmGXABUOhSZBWNiFWkyILxA(0.3f);
					}

					public void SwdSYMGZdvdpcijUYhBrWOLJBpHIA(bool P_0)
					{
						if (wECTHwhDljvwdgThFSJnBTPktARJ != tQAYGnVyqmDxOcySvEqpRRRCYQPJ)
						{
							wECTHwhDljvwdgThFSJnBTPktARJ = tQAYGnVyqmDxOcySvEqpRRRCYQPJ;
						}
						if (tQAYGnVyqmDxOcySvEqpRRRCYQPJ != P_0)
						{
							tQAYGnVyqmDxOcySvEqpRRRCYQPJ = P_0;
						}
						RmMREtocbrksQCoXwNsEPAWzigkQ.XqFAJKgfJJJYPBiYaIzGxMqFSGPDb(P_0 && !wECTHwhDljvwdgThFSJnBTPktARJ, P_0, ReInput.unscaledTime);
						mrWufZEXDjDwuvVUZrViOCdYcAxY.pPclsWppnxgEcowLOKgJhdxlDvKb(0.3f, P_0 && !wECTHwhDljvwdgThFSJnBTPktARJ, P_0);
					}

					public virtual void BZBrWBSCstPugGHzoujjNNhZKRWs()
					{
						tQAYGnVyqmDxOcySvEqpRRRCYQPJ = false;
						wECTHwhDljvwdgThFSJnBTPktARJ = false;
						RmMREtocbrksQCoXwNsEPAWzigkQ.tTnwtZXsmlRDknxdEZHazJkurNfH();
						mrWufZEXDjDwuvVUZrViOCdYcAxY.GouIlXJGzHteJoMUdxkdTEiiMxDg();
					}
				}

				public class LYpFDfwtLcsoCQQCVXAcRZTlGqMO : IYgsSFmvIEiONYgvkvAFIRxusbjX
				{
					public float TIeqdkxXDVEkGauUZTShQwVpEFlR;

					public float hvVIhchBeSEfUqrRylnEhNsgDxLDA;

					public void NLVuCoRpJhmndRfQlkkAPiCOBPM(float P_0)
					{
						if (hvVIhchBeSEfUqrRylnEhNsgDxLDA != TIeqdkxXDVEkGauUZTShQwVpEFlR)
						{
							hvVIhchBeSEfUqrRylnEhNsgDxLDA = TIeqdkxXDVEkGauUZTShQwVpEFlR;
						}
						if (TIeqdkxXDVEkGauUZTShQwVpEFlR != P_0)
						{
							TIeqdkxXDVEkGauUZTShQwVpEFlR = ((P_0 > 0.001f) ? P_0 : 0f);
						}
						SwdSYMGZdvdpcijUYhBrWOLJBpHIA(TIeqdkxXDVEkGauUZTShQwVpEFlR > 0f);
					}

					public virtual void VCzeFmyUjUbkRKDhEjVdJSjJEwjhA()
					{
						BZBrWBSCstPugGHzoujjNNhZKRWs();
						TIeqdkxXDVEkGauUZTShQwVpEFlR = 0f;
						hvVIhchBeSEfUqrRylnEhNsgDxLDA = 0f;
					}
				}

				public wfKeZeeVWgFrbQdALauorsItTitTA(UpdateLoopSetting P_0, bool P_1)
					: base(P_0)
				{
					for (int i = 0; i < DlDUsLlpBvqNHmrStIlRMmcqIGTm; i++)
					{
						if (P_1)
						{
							HExjRFoOrVAZDUFDtywRFfyHIPxD[i] = new LYpFDfwtLcsoCQQCVXAcRZTlGqMO();
						}
						else
						{
							HExjRFoOrVAZDUFDtywRFfyHIPxD[i] = new IYgsSFmvIEiONYgvkvAFIRxusbjX();
						}
					}
					DYjVvqYGLxBHEKxbyyUEufqtMyAgA = HExjRFoOrVAZDUFDtywRFfyHIPxD[0];
				}

				public void YexdcnyWxyVGbJbanhnpjhAGZSNd(float P_0)
				{
					for (int i = 0; i < HExjRFoOrVAZDUFDtywRFfyHIPxD.Length; i++)
					{
						((IYgsSFmvIEiONYgvkvAFIRxusbjX)HExjRFoOrVAZDUFDtywRFfyHIPxD[i]).mrWufZEXDjDwuvVUZrViOCdYcAxY.PyUCDEIJkJcocMHWZltiJKdpBxdr(P_0);
					}
				}

				public void bVRBmSWAMSrlnkFgpLlvBnecHxncA()
				{
					for (int i = 0; i < HExjRFoOrVAZDUFDtywRFfyHIPxD.Length; i++)
					{
						((IYgsSFmvIEiONYgvkvAFIRxusbjX)HExjRFoOrVAZDUFDtywRFfyHIPxD[i]).mrWufZEXDjDwuvVUZrViOCdYcAxY.PyUCDEIJkJcocMHWZltiJKdpBxdr(0.3f);
					}
				}
			}

			internal readonly bool zYxZhfuNukCUtEBdnavNRBTVDXGu;

			internal readonly HardwareButtonInfo yXQYsGwaSnjXTPasjpRTXxIzcDLW;

			public bool valuePrev
			{
				get
				{
					if (ReInput._id != puKSwsOuudnInZOLmdUEibtEaSIAb)
					{
						ReInput.CheckInitialized(puKSwsOuudnInZOLmdUEibtEaSIAb);
						return false;
					}
					return ((wfKeZeeVWgFrbQdALauorsItTitTA.IYgsSFmvIEiONYgvkvAFIRxusbjX)cNkpWHSOMkaWzLCPxJsenANMAyLe.DYjVvqYGLxBHEKxbyyUEufqtMyAgA).wECTHwhDljvwdgThFSJnBTPktARJ;
				}
			}

			public bool value
			{
				get
				{
					if (ReInput._id != puKSwsOuudnInZOLmdUEibtEaSIAb)
					{
						ReInput.CheckInitialized(puKSwsOuudnInZOLmdUEibtEaSIAb);
						return false;
					}
					return ((wfKeZeeVWgFrbQdALauorsItTitTA.IYgsSFmvIEiONYgvkvAFIRxusbjX)cNkpWHSOMkaWzLCPxJsenANMAyLe.DYjVvqYGLxBHEKxbyyUEufqtMyAgA).tQAYGnVyqmDxOcySvEqpRRRCYQPJ;
				}
			}

			public float pressure
			{
				get
				{
					if (ReInput._id != puKSwsOuudnInZOLmdUEibtEaSIAb)
					{
						ReInput.CheckInitialized(puKSwsOuudnInZOLmdUEibtEaSIAb);
						return 0f;
					}
					if (!zYxZhfuNukCUtEBdnavNRBTVDXGu)
					{
						if (!((wfKeZeeVWgFrbQdALauorsItTitTA.IYgsSFmvIEiONYgvkvAFIRxusbjX)cNkpWHSOMkaWzLCPxJsenANMAyLe.DYjVvqYGLxBHEKxbyyUEufqtMyAgA).tQAYGnVyqmDxOcySvEqpRRRCYQPJ)
						{
							return 0f;
						}
						return 1f;
					}
					return ((wfKeZeeVWgFrbQdALauorsItTitTA.LYpFDfwtLcsoCQQCVXAcRZTlGqMO)cNkpWHSOMkaWzLCPxJsenANMAyLe.DYjVvqYGLxBHEKxbyyUEufqtMyAgA).TIeqdkxXDVEkGauUZTShQwVpEFlR;
				}
			}

			public float pressurePrev
			{
				get
				{
					if (ReInput._id != puKSwsOuudnInZOLmdUEibtEaSIAb)
					{
						ReInput.CheckInitialized(puKSwsOuudnInZOLmdUEibtEaSIAb);
						return 0f;
					}
					if (!zYxZhfuNukCUtEBdnavNRBTVDXGu)
					{
						if (!((wfKeZeeVWgFrbQdALauorsItTitTA.IYgsSFmvIEiONYgvkvAFIRxusbjX)cNkpWHSOMkaWzLCPxJsenANMAyLe.DYjVvqYGLxBHEKxbyyUEufqtMyAgA).wECTHwhDljvwdgThFSJnBTPktARJ)
						{
							return 0f;
						}
						return 1f;
					}
					return ((wfKeZeeVWgFrbQdALauorsItTitTA.LYpFDfwtLcsoCQQCVXAcRZTlGqMO)cNkpWHSOMkaWzLCPxJsenANMAyLe.DYjVvqYGLxBHEKxbyyUEufqtMyAgA).hvVIhchBeSEfUqrRylnEhNsgDxLDA;
				}
			}

			public bool isPressureSensitive
			{
				get
				{
					if (ReInput._id != puKSwsOuudnInZOLmdUEibtEaSIAb)
					{
						ReInput.CheckInitialized(puKSwsOuudnInZOLmdUEibtEaSIAb);
						return false;
					}
					return zYxZhfuNukCUtEBdnavNRBTVDXGu;
				}
			}

			public bool justPressed
			{
				get
				{
					if (ReInput._id != puKSwsOuudnInZOLmdUEibtEaSIAb)
					{
						ReInput.CheckInitialized(puKSwsOuudnInZOLmdUEibtEaSIAb);
						return false;
					}
					if (!((wfKeZeeVWgFrbQdALauorsItTitTA.IYgsSFmvIEiONYgvkvAFIRxusbjX)cNkpWHSOMkaWzLCPxJsenANMAyLe.DYjVvqYGLxBHEKxbyyUEufqtMyAgA).wECTHwhDljvwdgThFSJnBTPktARJ && ((wfKeZeeVWgFrbQdALauorsItTitTA.IYgsSFmvIEiONYgvkvAFIRxusbjX)cNkpWHSOMkaWzLCPxJsenANMAyLe.DYjVvqYGLxBHEKxbyyUEufqtMyAgA).tQAYGnVyqmDxOcySvEqpRRRCYQPJ)
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
					if (ReInput._id != puKSwsOuudnInZOLmdUEibtEaSIAb)
					{
						ReInput.CheckInitialized(puKSwsOuudnInZOLmdUEibtEaSIAb);
						return false;
					}
					if (((wfKeZeeVWgFrbQdALauorsItTitTA.IYgsSFmvIEiONYgvkvAFIRxusbjX)cNkpWHSOMkaWzLCPxJsenANMAyLe.DYjVvqYGLxBHEKxbyyUEufqtMyAgA).wECTHwhDljvwdgThFSJnBTPktARJ && !((wfKeZeeVWgFrbQdALauorsItTitTA.IYgsSFmvIEiONYgvkvAFIRxusbjX)cNkpWHSOMkaWzLCPxJsenANMAyLe.DYjVvqYGLxBHEKxbyyUEufqtMyAgA).tQAYGnVyqmDxOcySvEqpRRRCYQPJ)
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
					if (ReInput._id != puKSwsOuudnInZOLmdUEibtEaSIAb)
					{
						ReInput.CheckInitialized(puKSwsOuudnInZOLmdUEibtEaSIAb);
						return false;
					}
					if (((wfKeZeeVWgFrbQdALauorsItTitTA.IYgsSFmvIEiONYgvkvAFIRxusbjX)cNkpWHSOMkaWzLCPxJsenANMAyLe.DYjVvqYGLxBHEKxbyyUEufqtMyAgA).wECTHwhDljvwdgThFSJnBTPktARJ != ((wfKeZeeVWgFrbQdALauorsItTitTA.IYgsSFmvIEiONYgvkvAFIRxusbjX)cNkpWHSOMkaWzLCPxJsenANMAyLe.DYjVvqYGLxBHEKxbyyUEufqtMyAgA).tQAYGnVyqmDxOcySvEqpRRRCYQPJ)
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
					if (ReInput._id != puKSwsOuudnInZOLmdUEibtEaSIAb)
					{
						ReInput.CheckInitialized(puKSwsOuudnInZOLmdUEibtEaSIAb);
						return false;
					}
					return ((wfKeZeeVWgFrbQdALauorsItTitTA.IYgsSFmvIEiONYgvkvAFIRxusbjX)cNkpWHSOMkaWzLCPxJsenANMAyLe.DYjVvqYGLxBHEKxbyyUEufqtMyAgA).mrWufZEXDjDwuvVUZrViOCdYcAxY.uPNZLfUKuQIqNDQyZGTVXTClGoeD;
				}
			}

			public bool justDoublePressed
			{
				get
				{
					if (ReInput._id != puKSwsOuudnInZOLmdUEibtEaSIAb)
					{
						ReInput.CheckInitialized(puKSwsOuudnInZOLmdUEibtEaSIAb);
						return false;
					}
					if (!justPressed)
					{
						return false;
					}
					return ((wfKeZeeVWgFrbQdALauorsItTitTA.IYgsSFmvIEiONYgvkvAFIRxusbjX)cNkpWHSOMkaWzLCPxJsenANMAyLe.DYjVvqYGLxBHEKxbyyUEufqtMyAgA).mrWufZEXDjDwuvVUZrViOCdYcAxY.uPNZLfUKuQIqNDQyZGTVXTClGoeD;
				}
			}

			public double timePressed
			{
				get
				{
					if (ReInput._id != puKSwsOuudnInZOLmdUEibtEaSIAb)
					{
						ReInput.CheckInitialized(puKSwsOuudnInZOLmdUEibtEaSIAb);
						return 0.0;
					}
					return ((wfKeZeeVWgFrbQdALauorsItTitTA.IYgsSFmvIEiONYgvkvAFIRxusbjX)cNkpWHSOMkaWzLCPxJsenANMAyLe.DYjVvqYGLxBHEKxbyyUEufqtMyAgA).RmMREtocbrksQCoXwNsEPAWzigkQ.xAPUFiODnOIrnBJfTaxdkidFbPax;
				}
			}

			public double timeUnpressed
			{
				get
				{
					if (ReInput._id != puKSwsOuudnInZOLmdUEibtEaSIAb)
					{
						ReInput.CheckInitialized(puKSwsOuudnInZOLmdUEibtEaSIAb);
						return 0.0;
					}
					return ((wfKeZeeVWgFrbQdALauorsItTitTA.IYgsSFmvIEiONYgvkvAFIRxusbjX)cNkpWHSOMkaWzLCPxJsenANMAyLe.DYjVvqYGLxBHEKxbyyUEufqtMyAgA).RmMREtocbrksQCoXwNsEPAWzigkQ.BPLieXJiEKCEeDSuukctyGyIgxPgA;
				}
			}

			public double lastTimePressed
			{
				get
				{
					if (ReInput._id != puKSwsOuudnInZOLmdUEibtEaSIAb)
					{
						ReInput.CheckInitialized(puKSwsOuudnInZOLmdUEibtEaSIAb);
						return 0.0;
					}
					return ((wfKeZeeVWgFrbQdALauorsItTitTA.IYgsSFmvIEiONYgvkvAFIRxusbjX)cNkpWHSOMkaWzLCPxJsenANMAyLe.DYjVvqYGLxBHEKxbyyUEufqtMyAgA).RmMREtocbrksQCoXwNsEPAWzigkQ.RYhhdotbAfodBooOotKhIfChYYHh;
				}
			}

			public double lastTimeUnpressed
			{
				get
				{
					if (ReInput._id != puKSwsOuudnInZOLmdUEibtEaSIAb)
					{
						ReInput.CheckInitialized(puKSwsOuudnInZOLmdUEibtEaSIAb);
						return 0.0;
					}
					return ((wfKeZeeVWgFrbQdALauorsItTitTA.IYgsSFmvIEiONYgvkvAFIRxusbjX)cNkpWHSOMkaWzLCPxJsenANMAyLe.DYjVvqYGLxBHEKxbyyUEufqtMyAgA).RmMREtocbrksQCoXwNsEPAWzigkQ.ZfijfERTYsbMwqVNeqtqOgAVjgQIA;
				}
			}

			public double lastTimeStateChanged
			{
				get
				{
					if (ReInput._id != puKSwsOuudnInZOLmdUEibtEaSIAb)
					{
						ReInput.CheckInitialized(puKSwsOuudnInZOLmdUEibtEaSIAb);
						return 0.0;
					}
					return ((wfKeZeeVWgFrbQdALauorsItTitTA.IYgsSFmvIEiONYgvkvAFIRxusbjX)cNkpWHSOMkaWzLCPxJsenANMAyLe.DYjVvqYGLxBHEKxbyyUEufqtMyAgA).RmMREtocbrksQCoXwNsEPAWzigkQ.ZIvJPqwrkPIqbCqECMAAXvkntlqL;
				}
			}

			internal ButtonStateFlags IXreFOQOBUrsjjTLIqFKHRslRBcw
			{
				get
				{
					wfKeZeeVWgFrbQdALauorsItTitTA.IYgsSFmvIEiONYgvkvAFIRxusbjX ygsSFmvIEiONYgvkvAFIRxusbjX = (wfKeZeeVWgFrbQdALauorsItTitTA.IYgsSFmvIEiONYgvkvAFIRxusbjX)cNkpWHSOMkaWzLCPxJsenANMAyLe.DYjVvqYGLxBHEKxbyyUEufqtMyAgA;
					ButtonStateFlags buttonStateFlags = ButtonStateFlags.Off;
					if (ygsSFmvIEiONYgvkvAFIRxusbjX.tQAYGnVyqmDxOcySvEqpRRRCYQPJ)
					{
						buttonStateFlags |= ButtonStateFlags.On;
						if (!ygsSFmvIEiONYgvkvAFIRxusbjX.wECTHwhDljvwdgThFSJnBTPktARJ)
						{
							buttonStateFlags |= ButtonStateFlags.Down;
						}
					}
					else if (ygsSFmvIEiONYgvkvAFIRxusbjX.wECTHwhDljvwdgThFSJnBTPktARJ)
					{
						buttonStateFlags |= ButtonStateFlags.Up;
					}
					return buttonStateFlags;
				}
			}

			internal Button(Controller P_0, int P_1, string P_2, HardwareButtonInfo P_3)
				: base(P_0, P_1, P_2, ControllerElementType.Button)
			{
				yXQYsGwaSnjXTPasjpRTXxIzcDLW = P_3;
				cNkpWHSOMkaWzLCPxJsenANMAyLe = new wfKeZeeVWgFrbQdALauorsItTitTA(ReInput.configVars.updateLoop, false);
			}

			internal Button(Controller P_0, int P_1, string P_2, bool P_3, HardwareButtonInfo P_4)
				: base(P_0, P_1, P_2, ControllerElementType.Button)
			{
				yXQYsGwaSnjXTPasjpRTXxIzcDLW = P_4;
				zYxZhfuNukCUtEBdnavNRBTVDXGu = P_3;
				cNkpWHSOMkaWzLCPxJsenANMAyLe = new wfKeZeeVWgFrbQdALauorsItTitTA(ReInput.configVars.updateLoop, P_3);
			}

			public bool DoublePressedAndHeld(float speed)
			{
				if (ReInput._id != puKSwsOuudnInZOLmdUEibtEaSIAb)
				{
					ReInput.CheckInitialized(puKSwsOuudnInZOLmdUEibtEaSIAb);
					return false;
				}
				if (speed <= 0f)
				{
					return ((wfKeZeeVWgFrbQdALauorsItTitTA.IYgsSFmvIEiONYgvkvAFIRxusbjX)cNkpWHSOMkaWzLCPxJsenANMAyLe.DYjVvqYGLxBHEKxbyyUEufqtMyAgA).mrWufZEXDjDwuvVUZrViOCdYcAxY.uPNZLfUKuQIqNDQyZGTVXTClGoeD;
				}
				return ((wfKeZeeVWgFrbQdALauorsItTitTA.IYgsSFmvIEiONYgvkvAFIRxusbjX)cNkpWHSOMkaWzLCPxJsenANMAyLe.DYjVvqYGLxBHEKxbyyUEufqtMyAgA).RmMREtocbrksQCoXwNsEPAWzigkQ.iRPqIcIyucvLmbKsccANuaxbxfh(speed);
			}

			public bool JustDoublePressed(float speed)
			{
				if (ReInput._id != puKSwsOuudnInZOLmdUEibtEaSIAb)
				{
					ReInput.CheckInitialized(puKSwsOuudnInZOLmdUEibtEaSIAb);
					return false;
				}
				if (!justPressed)
				{
					return false;
				}
				if (speed <= 0f)
				{
					return ((wfKeZeeVWgFrbQdALauorsItTitTA.IYgsSFmvIEiONYgvkvAFIRxusbjX)cNkpWHSOMkaWzLCPxJsenANMAyLe.DYjVvqYGLxBHEKxbyyUEufqtMyAgA).mrWufZEXDjDwuvVUZrViOCdYcAxY.uPNZLfUKuQIqNDQyZGTVXTClGoeD;
				}
				return ((wfKeZeeVWgFrbQdALauorsItTitTA.IYgsSFmvIEiONYgvkvAFIRxusbjX)cNkpWHSOMkaWzLCPxJsenANMAyLe.DYjVvqYGLxBHEKxbyyUEufqtMyAgA).RmMREtocbrksQCoXwNsEPAWzigkQ.iRPqIcIyucvLmbKsccANuaxbxfh(speed);
			}

			internal void viHgNbCUcsmRhvdKxmIOtUmKcUWBA(UpdateLoopType P_0, int P_1, ControllerDataUpdater P_2)
			{
				if (cNkpWHSOMkaWzLCPxJsenANMAyLe != null && cNkpWHSOMkaWzLCPxJsenANMAyLe.wOwyuiEMsKezEhHOIZpuEOhSgQQM != (int)P_0)
				{
					cNkpWHSOMkaWzLCPxJsenANMAyLe.wfDkfLFAWLtbXKlXNZBzJXcqLlKP = P_0;
				}
				if (zYxZhfuNukCUtEBdnavNRBTVDXGu)
				{
					((wfKeZeeVWgFrbQdALauorsItTitTA.LYpFDfwtLcsoCQQCVXAcRZTlGqMO)cNkpWHSOMkaWzLCPxJsenANMAyLe.DYjVvqYGLxBHEKxbyyUEufqtMyAgA).NLVuCoRpJhmndRfQlkkAPiCOBPM(P_2.buttonPressureValues[P_1]);
				}
				else
				{
					((wfKeZeeVWgFrbQdALauorsItTitTA.IYgsSFmvIEiONYgvkvAFIRxusbjX)cNkpWHSOMkaWzLCPxJsenANMAyLe.DYjVvqYGLxBHEKxbyyUEufqtMyAgA).SwdSYMGZdvdpcijUYhBrWOLJBpHIA(P_2.buttonValues[P_1]);
				}
			}

			internal void XoVbBNIkEuPXOHSzYNQbjSUFdDzK(UpdateLoopType P_0)
			{
				if (cNkpWHSOMkaWzLCPxJsenANMAyLe != null && cNkpWHSOMkaWzLCPxJsenANMAyLe.wOwyuiEMsKezEhHOIZpuEOhSgQQM != (int)P_0)
				{
					cNkpWHSOMkaWzLCPxJsenANMAyLe.wfDkfLFAWLtbXKlXNZBzJXcqLlKP = P_0;
				}
				if (zYxZhfuNukCUtEBdnavNRBTVDXGu)
				{
					((wfKeZeeVWgFrbQdALauorsItTitTA.LYpFDfwtLcsoCQQCVXAcRZTlGqMO)cNkpWHSOMkaWzLCPxJsenANMAyLe.DYjVvqYGLxBHEKxbyyUEufqtMyAgA).NLVuCoRpJhmndRfQlkkAPiCOBPM(0f);
				}
				else
				{
					((wfKeZeeVWgFrbQdALauorsItTitTA.IYgsSFmvIEiONYgvkvAFIRxusbjX)cNkpWHSOMkaWzLCPxJsenANMAyLe.DYjVvqYGLxBHEKxbyyUEufqtMyAgA).SwdSYMGZdvdpcijUYhBrWOLJBpHIA(false);
				}
			}

			internal void ZEKWTSCeZSfpgIZnmlGUJNvZNcNh()
			{
				for (int i = 0; i < cNkpWHSOMkaWzLCPxJsenANMAyLe.tZJgshAButFylhErZuuacnMNUztq.Count; i++)
				{
					uTPXnhzPFmVKSTMzVUovlNlEexSG.rkEPALCYcPglLssmPSDxTzNayWVk rkEPALCYcPglLssmPSDxTzNayWVk = cNkpWHSOMkaWzLCPxJsenANMAyLe.tZJgshAButFylhErZuuacnMNUztq[i];
					if (rkEPALCYcPglLssmPSDxTzNayWVk != null)
					{
						if (zYxZhfuNukCUtEBdnavNRBTVDXGu)
						{
							((wfKeZeeVWgFrbQdALauorsItTitTA.LYpFDfwtLcsoCQQCVXAcRZTlGqMO)rkEPALCYcPglLssmPSDxTzNayWVk).NLVuCoRpJhmndRfQlkkAPiCOBPM(0f);
						}
						else
						{
							((wfKeZeeVWgFrbQdALauorsItTitTA.IYgsSFmvIEiONYgvkvAFIRxusbjX)rkEPALCYcPglLssmPSDxTzNayWVk).SwdSYMGZdvdpcijUYhBrWOLJBpHIA(false);
						}
					}
				}
			}
		}

		public abstract class CompoundElement
		{
			private class jexHckKAFJnOozKtrludtpXYLnxDb
			{
				public readonly Element laAvZoocMGNyUZPPYfJsSXVjxEbi;

				public readonly int EYenaDAzMntADRliVntKQAlFgdwu;

				public jexHckKAFJnOozKtrludtpXYLnxDb(Element P_0, int P_1)
				{
					laAvZoocMGNyUZPPYfJsSXVjxEbi = P_0;
					EYenaDAzMntADRliVntKQAlFgdwu = P_1;
				}
			}

			private int dlCktVTeISEGTTUDhFRpQovjfNzY;

			private string vKFcEAAFPRNQHeqgeDoKqVJVHOvNB;

			private CompoundControllerElementType zxouRloJTYgXnAFSFwLXwTqVzyOKA;

			private int ehmTSFIzFbaYfmeczxjswehGMxAw;

			private jexHckKAFJnOozKtrludtpXYLnxDb[] OOIOYdMmfLQSbcFsXxGZFoxKvaxQ;

			private Controller UnSJMVIEySCMWbolOUTGqXUMtJZLA;

			internal readonly int yWWUGsZGAXKoLvBAyZSWdUEPICnn;

			public int id
			{
				get
				{
					if (ReInput._id != yWWUGsZGAXKoLvBAyZSWdUEPICnn)
					{
						ReInput.CheckInitialized(yWWUGsZGAXKoLvBAyZSWdUEPICnn);
						return -1;
					}
					return dlCktVTeISEGTTUDhFRpQovjfNzY;
				}
			}

			public string name
			{
				get
				{
					if (ReInput._id != yWWUGsZGAXKoLvBAyZSWdUEPICnn)
					{
						ReInput.CheckInitialized(yWWUGsZGAXKoLvBAyZSWdUEPICnn);
						return string.Empty;
					}
					return vKFcEAAFPRNQHeqgeDoKqVJVHOvNB;
				}
			}

			public CompoundControllerElementType type
			{
				get
				{
					if (ReInput._id != yWWUGsZGAXKoLvBAyZSWdUEPICnn)
					{
						ReInput.CheckInitialized(yWWUGsZGAXKoLvBAyZSWdUEPICnn);
						return CompoundControllerElementType.Axis2D;
					}
					return zxouRloJTYgXnAFSFwLXwTqVzyOKA;
				}
			}

			public bool hasElements
			{
				get
				{
					if (ReInput._id != yWWUGsZGAXKoLvBAyZSWdUEPICnn)
					{
						ReInput.CheckInitialized(yWWUGsZGAXKoLvBAyZSWdUEPICnn);
						return false;
					}
					return ehmTSFIzFbaYfmeczxjswehGMxAw > 0;
				}
			}

			public int elementCount
			{
				get
				{
					if (ReInput._id != yWWUGsZGAXKoLvBAyZSWdUEPICnn)
					{
						ReInput.CheckInitialized(yWWUGsZGAXKoLvBAyZSWdUEPICnn);
						return 0;
					}
					return ehmTSFIzFbaYfmeczxjswehGMxAw;
				}
			}

			public abstract int elementCapacity { get; }

			public ControllerElementIdentifier elementIdentifier
			{
				get
				{
					if (ReInput._id != yWWUGsZGAXKoLvBAyZSWdUEPICnn)
					{
						ReInput.CheckInitialized(yWWUGsZGAXKoLvBAyZSWdUEPICnn);
						return null;
					}
					ControllerElementIdentifier elementIdentifierById = UnSJMVIEySCMWbolOUTGqXUMtJZLA.GetElementIdentifierById(dlCktVTeISEGTTUDhFRpQovjfNzY);
					if (elementIdentifierById == null)
					{
						return ControllerElementIdentifier.BlankReadOnly;
					}
					return elementIdentifierById;
				}
			}

			internal CompoundElement(Controller P_0, int P_1, string P_2, CompoundControllerElementType P_3)
			{
				UnSJMVIEySCMWbolOUTGqXUMtJZLA = P_0;
				dlCktVTeISEGTTUDhFRpQovjfNzY = P_1;
				vKFcEAAFPRNQHeqgeDoKqVJVHOvNB = P_2;
				zxouRloJTYgXnAFSFwLXwTqVzyOKA = P_3;
				OOIOYdMmfLQSbcFsXxGZFoxKvaxQ = new jexHckKAFJnOozKtrludtpXYLnxDb[elementCapacity];
				yWWUGsZGAXKoLvBAyZSWdUEPICnn = ReInput.id;
			}

			internal Element mlTKMEvlKTvytXyaOMKGrURRqqIB(int P_0)
			{
				if (P_0 < 0 || P_0 >= OOIOYdMmfLQSbcFsXxGZFoxKvaxQ.Length)
				{
					return null;
				}
				if (OOIOYdMmfLQSbcFsXxGZFoxKvaxQ[P_0] == null)
				{
					return null;
				}
				return OOIOYdMmfLQSbcFsXxGZFoxKvaxQ[P_0].laAvZoocMGNyUZPPYfJsSXVjxEbi;
			}

			internal _0001 mlTKMEvlKTvytXyaOMKGrURRqqIB<_0001>(int P_0) where _0001 : Element
			{
				if (P_0 < 0 || P_0 >= OOIOYdMmfLQSbcFsXxGZFoxKvaxQ.Length)
				{
					return null;
				}
				if (OOIOYdMmfLQSbcFsXxGZFoxKvaxQ[P_0] == null)
				{
					return null;
				}
				return OOIOYdMmfLQSbcFsXxGZFoxKvaxQ[P_0].laAvZoocMGNyUZPPYfJsSXVjxEbi as _0001;
			}

			internal _0001 pZsukaPGvsSmNFDcHZVWmWvvkygv<_0001>(int P_0, out int P_1) where _0001 : Element
			{
				P_1 = -1;
				if (P_0 < 0 || P_0 >= OOIOYdMmfLQSbcFsXxGZFoxKvaxQ.Length)
				{
					return null;
				}
				if (OOIOYdMmfLQSbcFsXxGZFoxKvaxQ[P_0] == null)
				{
					return null;
				}
				P_1 = OOIOYdMmfLQSbcFsXxGZFoxKvaxQ[P_0].EYenaDAzMntADRliVntKQAlFgdwu;
				return OOIOYdMmfLQSbcFsXxGZFoxKvaxQ[P_0].laAvZoocMGNyUZPPYfJsSXVjxEbi as _0001;
			}

			internal bool DyPdfxcMVBiGUoeJEAnNsJENyigM(Element P_0, int P_1)
			{
				if (P_0 == null)
				{
					return false;
				}
				if (ehmTSFIzFbaYfmeczxjswehGMxAw >= elementCapacity)
				{
					Logger.LogWarning("Cannot add element! This Compound Element already contains the maximum number of elements.");
					return false;
				}
				if (P_0.isMemberElement)
				{
					Logger.LogWarning("Cannot add element! The element you are trying to add is already a member of another compound element.");
					return false;
				}
				if (hTzuAlxOeGzqXTptwuJubNIqDBpk(P_0) >= 0)
				{
					Logger.LogWarning("Cannot add element! This Compound Element already contains the element you are trying to add.");
					return false;
				}
				int num = RGIfiwIOIgqAXcEIPOWJInNsQKRY();
				if (num < 0)
				{
					Logger.LogWarning("Cannot add element! This Compound Element already contains the maximum number of elements.");
					return false;
				}
				return eVpjuImuYodzXlIgXtPuXAeaZylr(P_0, P_1, num);
			}

			internal bool PRmjhHGKRpWjtaxkfAqvcYBOICRf(Element P_0)
			{
				if (P_0 == null)
				{
					return false;
				}
				if (ehmTSFIzFbaYfmeczxjswehGMxAw == 0)
				{
					Logger.LogWarning("Cannot remove element! This Compound Element has no elements.");
					return false;
				}
				int num = hTzuAlxOeGzqXTptwuJubNIqDBpk(P_0);
				if (num < 0)
				{
					Logger.LogWarning("Cannot remove element! This Compound Element does not contain the element you are trying to remove.");
					return false;
				}
				return OshVYwtPwNBhwEyIPaDeXIXYJTEq(num);
			}

			internal void uMHItIoQANWRkCYfNdGOEolXBWqi()
			{
				for (int i = 0; i < OOIOYdMmfLQSbcFsXxGZFoxKvaxQ.Length; i++)
				{
					OshVYwtPwNBhwEyIPaDeXIXYJTEq(i);
				}
				ehmTSFIzFbaYfmeczxjswehGMxAw = 0;
			}

			private int hTzuAlxOeGzqXTptwuJubNIqDBpk(Element P_0)
			{
				if (P_0 == null)
				{
					return -1;
				}
				for (int i = 0; i < OOIOYdMmfLQSbcFsXxGZFoxKvaxQ.Length; i++)
				{
					if (OOIOYdMmfLQSbcFsXxGZFoxKvaxQ[i] != null && OOIOYdMmfLQSbcFsXxGZFoxKvaxQ[i].laAvZoocMGNyUZPPYfJsSXVjxEbi == P_0)
					{
						return i;
					}
				}
				return -1;
			}

			private bool eVpjuImuYodzXlIgXtPuXAeaZylr(Element P_0, int P_1, int P_2)
			{
				if (P_2 < 0 || P_2 >= OOIOYdMmfLQSbcFsXxGZFoxKvaxQ.Length)
				{
					return false;
				}
				if (OOIOYdMmfLQSbcFsXxGZFoxKvaxQ[P_2] != null)
				{
					return false;
				}
				OOIOYdMmfLQSbcFsXxGZFoxKvaxQ[P_2] = new jexHckKAFJnOozKtrludtpXYLnxDb(P_0, P_1);
				P_0.bHQRtxzlQgmEUepQsFxfNPLULeWK(this);
				ehmTSFIzFbaYfmeczxjswehGMxAw++;
				return true;
			}

			private bool OshVYwtPwNBhwEyIPaDeXIXYJTEq(int P_0)
			{
				if (P_0 < 0 || P_0 >= OOIOYdMmfLQSbcFsXxGZFoxKvaxQ.Length)
				{
					return false;
				}
				if (OOIOYdMmfLQSbcFsXxGZFoxKvaxQ[P_0] == null)
				{
					return false;
				}
				if (OOIOYdMmfLQSbcFsXxGZFoxKvaxQ[P_0].laAvZoocMGNyUZPPYfJsSXVjxEbi != null)
				{
					OOIOYdMmfLQSbcFsXxGZFoxKvaxQ[P_0].laAvZoocMGNyUZPPYfJsSXVjxEbi.oOtXDFzkHcwXBHJGMkNUSpuBWTHO(this);
				}
				OOIOYdMmfLQSbcFsXxGZFoxKvaxQ[P_0] = null;
				ehmTSFIzFbaYfmeczxjswehGMxAw--;
				return true;
			}

			private int RGIfiwIOIgqAXcEIPOWJInNsQKRY()
			{
				for (int i = 0; i < OOIOYdMmfLQSbcFsXxGZFoxKvaxQ.Length; i++)
				{
					if (OOIOYdMmfLQSbcFsXxGZFoxKvaxQ[i] == null)
					{
						return i;
					}
				}
				return -1;
			}
		}

		public sealed class Axis2D : CompoundElement
		{
			private const int oeqEBJoeYUydRJCEQGIGsdpvbeIz = 2;

			private CalibrationMap pYwFbBsfJLFzICLEqQwzorxIdOtg;

			private readonly int VhldxMxpybdQkhjypAFfvmgyFRDTA;

			int CompoundElement.elementCapacity => 2;

			public Axis xAxis
			{
				get
				{
					if (ReInput._id != yWWUGsZGAXKoLvBAyZSWdUEPICnn)
					{
						ReInput.CheckInitialized(yWWUGsZGAXKoLvBAyZSWdUEPICnn);
						return null;
					}
					return mlTKMEvlKTvytXyaOMKGrURRqqIB<Axis>(0);
				}
			}

			public Axis yAxis
			{
				get
				{
					if (ReInput._id != yWWUGsZGAXKoLvBAyZSWdUEPICnn)
					{
						ReInput.CheckInitialized(yWWUGsZGAXKoLvBAyZSWdUEPICnn);
						return null;
					}
					return mlTKMEvlKTvytXyaOMKGrURRqqIB<Axis>(1);
				}
			}

			public Vector2 value
			{
				get
				{
					if (ReInput._id != yWWUGsZGAXKoLvBAyZSWdUEPICnn)
					{
						ReInput.CheckInitialized(yWWUGsZGAXKoLvBAyZSWdUEPICnn);
						return Vector2.zero;
					}
					return rtHGGhuURfweKjXRuScqBUuGQvjK();
				}
			}

			public Vector2 valuePrev
			{
				get
				{
					if (ReInput._id != yWWUGsZGAXKoLvBAyZSWdUEPICnn)
					{
						ReInput.CheckInitialized(yWWUGsZGAXKoLvBAyZSWdUEPICnn);
						return Vector2.zero;
					}
					return GSllSVOYZzjSSGFUwQBXoZSATZDI();
				}
			}

			public Vector2 valueRaw
			{
				get
				{
					if (ReInput._id != yWWUGsZGAXKoLvBAyZSWdUEPICnn)
					{
						ReInput.CheckInitialized(yWWUGsZGAXKoLvBAyZSWdUEPICnn);
						return Vector2.zero;
					}
					return new Vector2((xAxis != null) ? xAxis.valueRaw : 0f, (yAxis != null) ? yAxis.valueRaw : 0f);
				}
			}

			public Vector2 valueRawPrev
			{
				get
				{
					if (ReInput._id != yWWUGsZGAXKoLvBAyZSWdUEPICnn)
					{
						ReInput.CheckInitialized(yWWUGsZGAXKoLvBAyZSWdUEPICnn);
						return Vector2.zero;
					}
					return new Vector2((xAxis != null) ? xAxis.valueRawPrev : 0f, (yAxis != null) ? yAxis.valueRawPrev : 0f);
				}
			}

			internal Axis2D(Controller P_0, int P_1, string P_2, Axis P_3, Axis P_4, int P_5, int P_6, int P_7, CalibrationMap P_8)
				: base(P_0, P_1, P_2, CompoundControllerElementType.Axis2D)
			{
				DyPdfxcMVBiGUoeJEAnNsJENyigM(P_3, P_5);
				DyPdfxcMVBiGUoeJEAnNsJENyigM(P_4, P_6);
				VhldxMxpybdQkhjypAFfvmgyFRDTA = P_7;
				pYwFbBsfJLFzICLEqQwzorxIdOtg = P_8;
			}

			internal void sYWepCAjnCfeVrpxTWwPwvkvmWnm()
			{
				Vector2 vector = value;
				if (xAxis != null)
				{
					xAxis.BijOSRoSJXEvImPPWzVAwTJJyaXB(vector.x);
				}
				if (yAxis != null)
				{
					yAxis.BijOSRoSJXEvImPPWzVAwTJJyaXB(vector.y);
				}
			}

			private Vector2 rtHGGhuURfweKjXRuScqBUuGQvjK()
			{
				if (pYwFbBsfJLFzICLEqQwzorxIdOtg == null)
				{
					return default(Vector2);
				}
				int index;
				Axis axis = pZsukaPGvsSmNFDcHZVWmWvvkygv<Axis>(0, out index);
				int index2;
				Axis axis2 = pZsukaPGvsSmNFDcHZVWmWvvkygv<Axis>(1, out index2);
				float valueRawX = axis?.valueRaw ?? 0f;
				float valueRawY = axis2?.valueRaw ?? 0f;
				return Axis2DCalibration.GetCalibratedValue(pYwFbBsfJLFzICLEqQwzorxIdOtg.GetAxis2D(VhldxMxpybdQkhjypAFfvmgyFRDTA), pYwFbBsfJLFzICLEqQwzorxIdOtg.GetAxis(index), pYwFbBsfJLFzICLEqQwzorxIdOtg.GetAxis(index2), valueRawX, valueRawY);
			}

			private Vector2 GSllSVOYZzjSSGFUwQBXoZSATZDI()
			{
				if (pYwFbBsfJLFzICLEqQwzorxIdOtg == null)
				{
					return default(Vector2);
				}
				int index;
				Axis axis = pZsukaPGvsSmNFDcHZVWmWvvkygv<Axis>(0, out index);
				int index2;
				Axis axis2 = pZsukaPGvsSmNFDcHZVWmWvvkygv<Axis>(1, out index2);
				float valueRawX = axis?.valueRawPrev ?? 0f;
				float valueRawY = axis2?.valueRawPrev ?? 0f;
				return Axis2DCalibration.GetCalibratedValue(pYwFbBsfJLFzICLEqQwzorxIdOtg.GetAxis2D(VhldxMxpybdQkhjypAFfvmgyFRDTA), pYwFbBsfJLFzICLEqQwzorxIdOtg.GetAxis(index), pYwFbBsfJLFzICLEqQwzorxIdOtg.GetAxis(index2), valueRawX, valueRawY);
			}
		}

		public sealed class Hat : CompoundElement
		{
			private const int FMpkeWdLjVHmapSVrWZnxBleLKQW = 8;

			private const int GogLPjxuLnHbUIXmYiSrAgVuyddw = 0;

			private const int pvJVLCNWQwKwZvFyxlNQJqRmZhyy = 1;

			private const int BhLjpNUefEIZSrxOCOHrLruBuzvD = 2;

			private const int nvNEWmOBTVjbEalKLbihJKBnMmOo = 3;

			private const int SLrtMAKSPzukfhVNKQLWnJjBkclt = 4;

			private const int QovTUhMwZxqUwHUaDKFpXPLEkXUG = 5;

			private const int TGAyNxMjrVtPumKBptbYYhArerdaA = 6;

			private const int zGmUKiPCfunlPwlhdUaRVycxRjRM = 7;

			private readonly int OoIwOMkOvWWPVxFWJtAWZZbRcQhN;

			private readonly Button[] yRyrdRwUjmAdCRWEpFAofnMMtpDp;

			private readonly ReadOnlyCollection<Button> FpFuRdtHabhgpkdkHlfzTQjVrrnR;

			private readonly int[] XbQEOwEbrJFVmCxMcoZoaSKvbSZec;

			private bool TDMBTlBjZWLovxMkOmMyoneGRSlLA;

			int CompoundElement.elementCapacity => 8;

			public bool force4Way
			{
				get
				{
					if (ReInput._id != yWWUGsZGAXKoLvBAyZSWdUEPICnn)
					{
						ReInput.CheckInitialized(yWWUGsZGAXKoLvBAyZSWdUEPICnn);
						return false;
					}
					return TDMBTlBjZWLovxMkOmMyoneGRSlLA;
				}
				set
				{
					if (ReInput._id != yWWUGsZGAXKoLvBAyZSWdUEPICnn)
					{
						ReInput.CheckInitialized(yWWUGsZGAXKoLvBAyZSWdUEPICnn);
					}
					else
					{
						TDMBTlBjZWLovxMkOmMyoneGRSlLA = value;
					}
				}
			}

			public int directionCount
			{
				get
				{
					if (ReInput._id != yWWUGsZGAXKoLvBAyZSWdUEPICnn)
					{
						ReInput.CheckInitialized(yWWUGsZGAXKoLvBAyZSWdUEPICnn);
						return 0;
					}
					return OoIwOMkOvWWPVxFWJtAWZZbRcQhN;
				}
			}

			public IList<Button> Buttons
			{
				get
				{
					if (ReInput._id != yWWUGsZGAXKoLvBAyZSWdUEPICnn)
					{
						ReInput.CheckInitialized(yWWUGsZGAXKoLvBAyZSWdUEPICnn);
						return EmptyObjects<Button>.EmptyReadOnlyIListT;
					}
					return FpFuRdtHabhgpkdkHlfzTQjVrrnR;
				}
			}

			public Button buttonUp
			{
				get
				{
					if (ReInput._id != yWWUGsZGAXKoLvBAyZSWdUEPICnn)
					{
						ReInput.CheckInitialized(yWWUGsZGAXKoLvBAyZSWdUEPICnn);
						return null;
					}
					return mlTKMEvlKTvytXyaOMKGrURRqqIB<Button>(0);
				}
			}

			public Button buttonRight
			{
				get
				{
					if (ReInput._id != yWWUGsZGAXKoLvBAyZSWdUEPICnn)
					{
						ReInput.CheckInitialized(yWWUGsZGAXKoLvBAyZSWdUEPICnn);
						return null;
					}
					return mlTKMEvlKTvytXyaOMKGrURRqqIB<Button>(2);
				}
			}

			public Button buttonDown
			{
				get
				{
					if (ReInput._id != yWWUGsZGAXKoLvBAyZSWdUEPICnn)
					{
						ReInput.CheckInitialized(yWWUGsZGAXKoLvBAyZSWdUEPICnn);
						return null;
					}
					return mlTKMEvlKTvytXyaOMKGrURRqqIB<Button>(4);
				}
			}

			public Button buttonLeft
			{
				get
				{
					if (ReInput._id != yWWUGsZGAXKoLvBAyZSWdUEPICnn)
					{
						ReInput.CheckInitialized(yWWUGsZGAXKoLvBAyZSWdUEPICnn);
						return null;
					}
					return mlTKMEvlKTvytXyaOMKGrURRqqIB<Button>(6);
				}
			}

			public Button buttonUpRight
			{
				get
				{
					if (ReInput._id != yWWUGsZGAXKoLvBAyZSWdUEPICnn)
					{
						ReInput.CheckInitialized(yWWUGsZGAXKoLvBAyZSWdUEPICnn);
						return null;
					}
					return mlTKMEvlKTvytXyaOMKGrURRqqIB<Button>(1);
				}
			}

			public Button buttonDownRight
			{
				get
				{
					if (ReInput._id != yWWUGsZGAXKoLvBAyZSWdUEPICnn)
					{
						ReInput.CheckInitialized(yWWUGsZGAXKoLvBAyZSWdUEPICnn);
						return null;
					}
					return mlTKMEvlKTvytXyaOMKGrURRqqIB<Button>(3);
				}
			}

			public Button buttonDownLeft
			{
				get
				{
					if (ReInput._id != yWWUGsZGAXKoLvBAyZSWdUEPICnn)
					{
						ReInput.CheckInitialized(yWWUGsZGAXKoLvBAyZSWdUEPICnn);
						return null;
					}
					return mlTKMEvlKTvytXyaOMKGrURRqqIB<Button>(5);
				}
			}

			public Button buttonUpLeft
			{
				get
				{
					if (ReInput._id != yWWUGsZGAXKoLvBAyZSWdUEPICnn)
					{
						ReInput.CheckInitialized(yWWUGsZGAXKoLvBAyZSWdUEPICnn);
						return null;
					}
					return mlTKMEvlKTvytXyaOMKGrURRqqIB<Button>(7);
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
					DyPdfxcMVBiGUoeJEAnNsJENyigM(P_3[i], P_4[i]);
				}
				yRyrdRwUjmAdCRWEpFAofnMMtpDp = P_3;
				XbQEOwEbrJFVmCxMcoZoaSKvbSZec = P_4;
				OoIwOMkOvWWPVxFWJtAWZZbRcQhN = num;
				FpFuRdtHabhgpkdkHlfzTQjVrrnR = new ReadOnlyCollection<Button>(P_3);
			}

			internal void EArMTJqRkSEfGTyRdEqhcnqYDJcIA(UpdateLoopType P_0, ControllerDataUpdater P_1)
			{
				if (OoIwOMkOvWWPVxFWJtAWZZbRcQhN == 0)
				{
					return;
				}
				if (OoIwOMkOvWWPVxFWJtAWZZbRcQhN == 8 && (TDMBTlBjZWLovxMkOmMyoneGRSlLA || ReInput.configVars.force4WayHats))
				{
					IjnpHkRTYWarNUCgiSoqWnPBciIFA(yRyrdRwUjmAdCRWEpFAofnMMtpDp[0], XbQEOwEbrJFVmCxMcoZoaSKvbSZec[0], XbQEOwEbrJFVmCxMcoZoaSKvbSZec[7], XbQEOwEbrJFVmCxMcoZoaSKvbSZec[1], P_0, P_1);
					IjnpHkRTYWarNUCgiSoqWnPBciIFA(yRyrdRwUjmAdCRWEpFAofnMMtpDp[2], XbQEOwEbrJFVmCxMcoZoaSKvbSZec[2], XbQEOwEbrJFVmCxMcoZoaSKvbSZec[1], XbQEOwEbrJFVmCxMcoZoaSKvbSZec[3], P_0, P_1);
					IjnpHkRTYWarNUCgiSoqWnPBciIFA(yRyrdRwUjmAdCRWEpFAofnMMtpDp[4], XbQEOwEbrJFVmCxMcoZoaSKvbSZec[4], XbQEOwEbrJFVmCxMcoZoaSKvbSZec[5], XbQEOwEbrJFVmCxMcoZoaSKvbSZec[3], P_0, P_1);
					IjnpHkRTYWarNUCgiSoqWnPBciIFA(yRyrdRwUjmAdCRWEpFAofnMMtpDp[6], XbQEOwEbrJFVmCxMcoZoaSKvbSZec[6], XbQEOwEbrJFVmCxMcoZoaSKvbSZec[5], XbQEOwEbrJFVmCxMcoZoaSKvbSZec[7], P_0, P_1);
					dvgTHmStEefHIyspusDJzUuRjqlG(yRyrdRwUjmAdCRWEpFAofnMMtpDp[1], XbQEOwEbrJFVmCxMcoZoaSKvbSZec[1], P_0, P_1);
					dvgTHmStEefHIyspusDJzUuRjqlG(yRyrdRwUjmAdCRWEpFAofnMMtpDp[3], XbQEOwEbrJFVmCxMcoZoaSKvbSZec[3], P_0, P_1);
					dvgTHmStEefHIyspusDJzUuRjqlG(yRyrdRwUjmAdCRWEpFAofnMMtpDp[5], XbQEOwEbrJFVmCxMcoZoaSKvbSZec[5], P_0, P_1);
					dvgTHmStEefHIyspusDJzUuRjqlG(yRyrdRwUjmAdCRWEpFAofnMMtpDp[7], XbQEOwEbrJFVmCxMcoZoaSKvbSZec[7], P_0, P_1);
					return;
				}
				for (int i = 0; i < yRyrdRwUjmAdCRWEpFAofnMMtpDp.Length; i++)
				{
					if (yRyrdRwUjmAdCRWEpFAofnMMtpDp[i] != null)
					{
						yRyrdRwUjmAdCRWEpFAofnMMtpDp[i].viHgNbCUcsmRhvdKxmIOtUmKcUWBA(P_0, XbQEOwEbrJFVmCxMcoZoaSKvbSZec[i], P_1);
					}
				}
			}

			private void IjnpHkRTYWarNUCgiSoqWnPBciIFA(Button P_0, int P_1, int P_2, int P_3, UpdateLoopType P_4, ControllerDataUpdater P_5)
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
				P_0.viHgNbCUcsmRhvdKxmIOtUmKcUWBA(P_4, P_1, P_5);
			}

			private void dvgTHmStEefHIyspusDJzUuRjqlG(Button P_0, int P_1, UpdateLoopType P_2, ControllerDataUpdater P_3)
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
					P_0.viHgNbCUcsmRhvdKxmIOtUmKcUWBA(P_2, P_1, P_3);
				}
			}
		}

		public sealed class DirectionalPad : CompoundElement
		{
			private const int qbOyRtbGiCcNhgkWyDWQHpzbBibr = 4;

			private const int GPLYFxBvggXgigrZcSyBwCOySApl = 0;

			private const int ZrNZGTyJnIVbMvDLIvVEtjnDAbYU = 1;

			private const int fglhPwHJEdGlHVyVjdhqjmrkfJJm = 2;

			private const int MICZkujTlQTIOEkQvRmLkRpoRRvX = 3;

			private readonly int yzBTyUHBFISBmyHbWdPgDLEvogCL;

			private readonly Button[] QZimcVDALmpCxyGcQDLeJRpvDUeFA;

			private readonly ReadOnlyCollection<Button> aqdtpmqXRaVMACCqOBPRsJeBaTKcA;

			private readonly int[] TjzAAhBpfenCzykNJIDHfAKqcAry;

			int CompoundElement.elementCapacity => 4;

			public IList<Button> Buttons
			{
				get
				{
					if (ReInput._id != yWWUGsZGAXKoLvBAyZSWdUEPICnn)
					{
						ReInput.CheckInitialized(yWWUGsZGAXKoLvBAyZSWdUEPICnn);
						return EmptyObjects<Button>.EmptyReadOnlyIListT;
					}
					return aqdtpmqXRaVMACCqOBPRsJeBaTKcA;
				}
			}

			public Button buttonUp
			{
				get
				{
					if (ReInput._id != yWWUGsZGAXKoLvBAyZSWdUEPICnn)
					{
						ReInput.CheckInitialized(yWWUGsZGAXKoLvBAyZSWdUEPICnn);
						return null;
					}
					return mlTKMEvlKTvytXyaOMKGrURRqqIB<Button>(0);
				}
			}

			public Button buttonRight
			{
				get
				{
					if (ReInput._id != yWWUGsZGAXKoLvBAyZSWdUEPICnn)
					{
						ReInput.CheckInitialized(yWWUGsZGAXKoLvBAyZSWdUEPICnn);
						return null;
					}
					return mlTKMEvlKTvytXyaOMKGrURRqqIB<Button>(1);
				}
			}

			public Button buttonDown
			{
				get
				{
					if (ReInput._id != yWWUGsZGAXKoLvBAyZSWdUEPICnn)
					{
						ReInput.CheckInitialized(yWWUGsZGAXKoLvBAyZSWdUEPICnn);
						return null;
					}
					return mlTKMEvlKTvytXyaOMKGrURRqqIB<Button>(2);
				}
			}

			public Button buttonLeft
			{
				get
				{
					if (ReInput._id != yWWUGsZGAXKoLvBAyZSWdUEPICnn)
					{
						ReInput.CheckInitialized(yWWUGsZGAXKoLvBAyZSWdUEPICnn);
						return null;
					}
					return mlTKMEvlKTvytXyaOMKGrURRqqIB<Button>(3);
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
					DyPdfxcMVBiGUoeJEAnNsJENyigM(P_3[i], P_4[i]);
				}
				QZimcVDALmpCxyGcQDLeJRpvDUeFA = P_3;
				TjzAAhBpfenCzykNJIDHfAKqcAry = P_4;
				yzBTyUHBFISBmyHbWdPgDLEvogCL = num;
				aqdtpmqXRaVMACCqOBPRsJeBaTKcA = new ReadOnlyCollection<Button>(P_3);
			}

			internal void aWLpFkurNuwdzlIdEjapKEcEzIWm(UpdateLoopType P_0, ControllerDataUpdater P_1)
			{
				if (yzBTyUHBFISBmyHbWdPgDLEvogCL == 0)
				{
					return;
				}
				for (int i = 0; i < QZimcVDALmpCxyGcQDLeJRpvDUeFA.Length; i++)
				{
					if (QZimcVDALmpCxyGcQDLeJRpvDUeFA[i] != null)
					{
						QZimcVDALmpCxyGcQDLeJRpvDUeFA[i].viHgNbCUcsmRhvdKxmIOtUmKcUWBA(P_0, TjzAAhBpfenCzykNJIDHfAKqcAry[i], P_1);
					}
				}
			}
		}

		[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
		public abstract class Extension
		{
			private Controller lMZdQWnUAwHRXEoIeFsPogfiJCvE;

			private IControllerExtensionSource bMuvMaawxhtcTlsPPFrcrApanwVH;

			internal readonly int _reInputId;

			internal bool isJoystickConnected
			{
				get
				{
					if (lMZdQWnUAwHRXEoIeFsPogfiJCvE == null)
					{
						return false;
					}
					return lMZdQWnUAwHRXEoIeFsPogfiJCvE._isConnected;
				}
			}

			internal bool enabled
			{
				get
				{
					if (lMZdQWnUAwHRXEoIeFsPogfiJCvE == null)
					{
						return false;
					}
					return lMZdQWnUAwHRXEoIeFsPogfiJCvE.enabled;
				}
			}

			public Controller controller => lMZdQWnUAwHRXEoIeFsPogfiJCvE;

			internal Extension(IControllerExtensionSource P_0)
			{
				_reInputId = ReInput.id;
				VsdTEEQQclFaxcKmvoTOoqhYVENU(P_0);
			}

			internal Extension(Extension P_0)
				: this(P_0.bMuvMaawxhtcTlsPPFrcrApanwVH)
			{
				lMZdQWnUAwHRXEoIeFsPogfiJCvE = P_0.lMZdQWnUAwHRXEoIeFsPogfiJCvE;
			}

			internal T GetController<T>() where T : Controller
			{
				if (lMZdQWnUAwHRXEoIeFsPogfiJCvE == null)
				{
					return null;
				}
				return lMZdQWnUAwHRXEoIeFsPogfiJCvE as T;
			}

			internal void SetController(Controller controller)
			{
				lMZdQWnUAwHRXEoIeFsPogfiJCvE = controller;
			}

			[CustomObfuscation(rename = false)]
			internal IControllerExtensionSource GetSource()
			{
				return bMuvMaawxhtcTlsPPFrcrApanwVH;
			}

			internal void SetSource(Extension extension)
			{
				if (extension == null)
				{
					VsdTEEQQclFaxcKmvoTOoqhYVENU(null);
				}
				else
				{
					VsdTEEQQclFaxcKmvoTOoqhYVENU(extension.bMuvMaawxhtcTlsPPFrcrApanwVH);
				}
			}

			private void VsdTEEQQclFaxcKmvoTOoqhYVENU(IControllerExtensionSource P_0)
			{
				bMuvMaawxhtcTlsPPFrcrApanwVH = P_0;
				SourceUpdated(bMuvMaawxhtcTlsPPFrcrApanwVH);
			}

			internal virtual void Clear()
			{
			}

			internal abstract void SourceUpdated(IControllerExtensionSource source);

			internal abstract void UpdateData(UpdateLoopType updateLoop);

			internal abstract Extension Clone();
		}

		[Serializable]
		private sealed class GSsxfRGIdEgmMrUHdBaVnxCUZKPW
		{
			public static readonly GSsxfRGIdEgmMrUHdBaVnxCUZKPW _003C_003E9 = new GSsxfRGIdEgmMrUHdBaVnxCUZKPW();

			public static Func<Controller, Guid, bool> _003C_003E9__166_0;

			public static Func<Controller, Type, bool> _003C_003E9__169_0;

			internal bool HsAbWnrHaPyYhvDfHeOEbBmrjejT(Controller P_0, Guid P_1)
			{
				return P_0.ImplementsTemplate(P_1);
			}

			internal bool wbeEpDzTUCnRKzfuLantkFwapVbb(Controller P_0, Type P_1)
			{
				return P_0.ImplementsTemplate(P_1);
			}
		}

		private sealed class BBVlrWcsckIbBObQkfWXvbPQEkHm : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
		{
			private int MLuFSDwrMsaffyXtrwgUlhzufrDN;

			private ControllerPollingInfo CfiNsCkFbrdHsOdgNrUaGuQbxKCY;

			private int YmBiHKocwvAQbGjpERyYIvmXrLng;

			public Controller GtNdxZZexNqzvuIegksTdOmMsnrO;

			private int aDkcXGECoisZggqETXJopHPeOqBr;

			ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return CfiNsCkFbrdHsOdgNrUaGuQbxKCY;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return CfiNsCkFbrdHsOdgNrUaGuQbxKCY;
				}
			}

			[DebuggerHidden]
			public BBVlrWcsckIbBObQkfWXvbPQEkHm(int P_0)
			{
				MLuFSDwrMsaffyXtrwgUlhzufrDN = P_0;
				YmBiHKocwvAQbGjpERyYIvmXrLng = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				MLuFSDwrMsaffyXtrwgUlhzufrDN = -2;
			}

			private bool MoveNext()
			{
				int mLuFSDwrMsaffyXtrwgUlhzufrDN = MLuFSDwrMsaffyXtrwgUlhzufrDN;
				Controller gtNdxZZexNqzvuIegksTdOmMsnrO = GtNdxZZexNqzvuIegksTdOmMsnrO;
				if (mLuFSDwrMsaffyXtrwgUlhzufrDN != 0)
				{
					if (mLuFSDwrMsaffyXtrwgUlhzufrDN != 1)
					{
						return false;
					}
					MLuFSDwrMsaffyXtrwgUlhzufrDN = -1;
					goto IL_00a0;
				}
				MLuFSDwrMsaffyXtrwgUlhzufrDN = -1;
				if (ReInput._id != gtNdxZZexNqzvuIegksTdOmMsnrO.BLBdTaBAlamAEELtUyjiaIPfgySPA)
				{
					ReInput.CheckInitialized(gtNdxZZexNqzvuIegksTdOmMsnrO.BLBdTaBAlamAEELtUyjiaIPfgySPA);
					return false;
				}
				gtNdxZZexNqzvuIegksTdOmMsnrO.UpdatePollingFrameTracking();
				aDkcXGECoisZggqETXJopHPeOqBr = 0;
				goto IL_00b0;
				IL_00b0:
				if (aDkcXGECoisZggqETXJopHPeOqBr < gtNdxZZexNqzvuIegksTdOmMsnrO._buttonCount)
				{
					if (gtNdxZZexNqzvuIegksTdOmMsnrO.kEnHaJFcZsntMHCfSAIlbcFCCprac(aDkcXGECoisZggqETXJopHPeOqBr, out var num))
					{
						CfiNsCkFbrdHsOdgNrUaGuQbxKCY = new ControllerPollingInfo(true, -1, gtNdxZZexNqzvuIegksTdOmMsnrO.id, gtNdxZZexNqzvuIegksTdOmMsnrO._name, gtNdxZZexNqzvuIegksTdOmMsnrO._type, ControllerElementType.Button, aDkcXGECoisZggqETXJopHPeOqBr, Pole.Positive, gtNdxZZexNqzvuIegksTdOmMsnrO.JEexZOPzSUUjNTHjvxywblgJdFqE.GetElementIdentifierName(num), num, KeyCode.None);
						MLuFSDwrMsaffyXtrwgUlhzufrDN = 1;
						return true;
					}
					goto IL_00a0;
				}
				return false;
				IL_00a0:
				aDkcXGECoisZggqETXJopHPeOqBr++;
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
				BBVlrWcsckIbBObQkfWXvbPQEkHm bBVlrWcsckIbBObQkfWXvbPQEkHm;
				if (MLuFSDwrMsaffyXtrwgUlhzufrDN == -2 && YmBiHKocwvAQbGjpERyYIvmXrLng == Environment.CurrentManagedThreadId)
				{
					MLuFSDwrMsaffyXtrwgUlhzufrDN = 0;
					bBVlrWcsckIbBObQkfWXvbPQEkHm = this;
				}
				else
				{
					bBVlrWcsckIbBObQkfWXvbPQEkHm = new BBVlrWcsckIbBObQkfWXvbPQEkHm(0);
					bBVlrWcsckIbBObQkfWXvbPQEkHm.GtNdxZZexNqzvuIegksTdOmMsnrO = GtNdxZZexNqzvuIegksTdOmMsnrO;
				}
				return bBVlrWcsckIbBObQkfWXvbPQEkHm;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
			}
		}

		private sealed class ZrguzloefVGjvzUHaKAyBgOugHqfA : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
		{
			private int UIIgIbcbWbAeAAHveoHJdcxmtMZb;

			private ControllerPollingInfo PTvXLZVGkCyNpymnlPDbZTsMoOLQ;

			private int NWsaQwBitVFbVzTzWZUSTJgLqEKEA;

			public Controller PdthMrUIhvQiRiEZKcdQsFazdRQfA;

			private int tHkMTjCCrboJjBDFHIGKVcWUpwYD;

			ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return PTvXLZVGkCyNpymnlPDbZTsMoOLQ;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return PTvXLZVGkCyNpymnlPDbZTsMoOLQ;
				}
			}

			[DebuggerHidden]
			public ZrguzloefVGjvzUHaKAyBgOugHqfA(int P_0)
			{
				UIIgIbcbWbAeAAHveoHJdcxmtMZb = P_0;
				NWsaQwBitVFbVzTzWZUSTJgLqEKEA = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				UIIgIbcbWbAeAAHveoHJdcxmtMZb = -2;
			}

			private bool MoveNext()
			{
				int uIIgIbcbWbAeAAHveoHJdcxmtMZb = UIIgIbcbWbAeAAHveoHJdcxmtMZb;
				Controller pdthMrUIhvQiRiEZKcdQsFazdRQfA = PdthMrUIhvQiRiEZKcdQsFazdRQfA;
				if (uIIgIbcbWbAeAAHveoHJdcxmtMZb != 0)
				{
					if (uIIgIbcbWbAeAAHveoHJdcxmtMZb != 1)
					{
						return false;
					}
					UIIgIbcbWbAeAAHveoHJdcxmtMZb = -1;
					goto IL_00a0;
				}
				UIIgIbcbWbAeAAHveoHJdcxmtMZb = -1;
				if (ReInput._id != pdthMrUIhvQiRiEZKcdQsFazdRQfA.BLBdTaBAlamAEELtUyjiaIPfgySPA)
				{
					ReInput.CheckInitialized(pdthMrUIhvQiRiEZKcdQsFazdRQfA.BLBdTaBAlamAEELtUyjiaIPfgySPA);
					return false;
				}
				pdthMrUIhvQiRiEZKcdQsFazdRQfA.UpdatePollingFrameTracking();
				tHkMTjCCrboJjBDFHIGKVcWUpwYD = 0;
				goto IL_00b0;
				IL_00b0:
				if (tHkMTjCCrboJjBDFHIGKVcWUpwYD < pdthMrUIhvQiRiEZKcdQsFazdRQfA._buttonCount)
				{
					if (pdthMrUIhvQiRiEZKcdQsFazdRQfA.AWWGizyTWKcZZyfBznvbAhpxlJKo(tHkMTjCCrboJjBDFHIGKVcWUpwYD, out var num))
					{
						PTvXLZVGkCyNpymnlPDbZTsMoOLQ = new ControllerPollingInfo(true, -1, pdthMrUIhvQiRiEZKcdQsFazdRQfA.id, pdthMrUIhvQiRiEZKcdQsFazdRQfA._name, pdthMrUIhvQiRiEZKcdQsFazdRQfA._type, ControllerElementType.Button, tHkMTjCCrboJjBDFHIGKVcWUpwYD, Pole.Positive, pdthMrUIhvQiRiEZKcdQsFazdRQfA.JEexZOPzSUUjNTHjvxywblgJdFqE.GetElementIdentifierName(num), num, KeyCode.None);
						UIIgIbcbWbAeAAHveoHJdcxmtMZb = 1;
						return true;
					}
					goto IL_00a0;
				}
				return false;
				IL_00a0:
				tHkMTjCCrboJjBDFHIGKVcWUpwYD++;
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
				ZrguzloefVGjvzUHaKAyBgOugHqfA zrguzloefVGjvzUHaKAyBgOugHqfA;
				if (UIIgIbcbWbAeAAHveoHJdcxmtMZb == -2 && NWsaQwBitVFbVzTzWZUSTJgLqEKEA == Environment.CurrentManagedThreadId)
				{
					UIIgIbcbWbAeAAHveoHJdcxmtMZb = 0;
					zrguzloefVGjvzUHaKAyBgOugHqfA = this;
				}
				else
				{
					zrguzloefVGjvzUHaKAyBgOugHqfA = new ZrguzloefVGjvzUHaKAyBgOugHqfA(0);
					zrguzloefVGjvzUHaKAyBgOugHqfA.PdthMrUIhvQiRiEZKcdQsFazdRQfA = PdthMrUIhvQiRiEZKcdQsFazdRQfA;
				}
				return zrguzloefVGjvzUHaKAyBgOugHqfA;
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

		private readonly DeviceLocalizationInfo tIUrwoGTepIHaWkvXhpVlOsZVHaS;

		protected string _hardwareName;

		protected readonly ControllerType _type;

		internal readonly Guid qapLJarKYePKdgQROGMwYujqCcvB;

		protected string _hardwareIdentifier;

		protected bool _isConnected;

		private Extension tDLZnJhZxzBcxAwAepUGzMiSgFeFA;

		private bool FAWKxzOqRWJcbgGLYZRmKqCKfTobA;

		private ControllerIdentifier nQypOoeVpjEFyTjjFwJtTKSBPlui;

		internal int BLBdTaBAlamAEELtUyjiaIPfgySPA;

		protected readonly int _buttonCount;

		protected readonly Button[] buttons;

		protected readonly ReadOnlyCollection<Button> buttons_readOnly;

		private readonly IList<Element> lbzVvAzZERIOIbUTgRYFkMFluuXR;

		private readonly ReadOnlyCollection<Element> vuuZtqqaUnVBcnRgdJXxLSqQKrTd;

		private readonly IList<CompoundElement> WCvmyVCIkjuRlyyQYsMxfDxlBLVIA;

		private readonly ReadOnlyCollection<CompoundElement> ytMnlQbQcUEgwzJDBcxjbhgBPeUy;

		[CustomObfuscation(rename = false)]
		internal readonly InputSource inputSource;

		internal readonly ControllerDataUpdater vAJlxjrsCepUBGzroHjWcArmXQkU;

		internal readonly HardwareControllerMap_Game JEexZOPzSUUjNTHjvxywblgJdFqE;

		internal uint FaPBxQSiRTtxQtkYJdpDejVMuMGR;

		private uint enHdbHWaRnjaecfcaOkwdpshcrbE;

		private uint MFUgLuHUzgdQXOciLNIYArujRfQtA;

		private ITryGetLocalizedName PSSAUDnRNfgmRLsvItwPAlWxwXRi;

		private readonly LocalizedString hGMbUBmXvpdINuGbyjJgilLAMrPdb;

		private readonly oEKjTOxtumqnvVGrvGQjjCekBlgfb VBmfjEfeBMzrtsikQnQeCRsbxfIL;

		private Action<bool> PyoBPXhavXXcCJVNnMGTXrHHqaRyA;

		private IControllerTemplate[] CKdAMvPKdmtIpLqfiNYomXZpVQoD;

		private ReadOnlyCollection<IControllerTemplate> cQTgjnLcsoqODqaLjlCYQibFOkQN;

		private static Func<Controller, Guid, bool> HRlpeWRNxlIqKSxCaQkmgkzRuhrw;

		private static Func<Controller, Type, bool> hEuyyAwkWuWQMsDsdXrJLDIkYVOD;

		internal bool UhQxMfDOXfcvqFYGXMIEcuWrixEo => enHdbHWaRnjaecfcaOkwdpshcrbE == ReInput.previousFrame;

		public bool enabled
		{
			get
			{
				if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
				{
					ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
					return false;
				}
				return FAWKxzOqRWJcbgGLYZRmKqCKfTobA;
			}
			set
			{
				JErfaHktCKVFtNnhTKDJdWzTRcaq(value);
			}
		}

		public string name
		{
			get
			{
				if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
				{
					ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
					return string.Empty;
				}
				if (!LocalizationManager.isEnabled)
				{
					return _name;
				}
				if (NMAKxWWmUpwqQNWynrlTLJrvKLcF != null && NMAKxWWmUpwqQNWynrlTLJrvKLcF.TryGetLocalizedName(out var value))
				{
					return value;
				}
				if (_type == ControllerType.Joystick && qapLJarKYePKdgQROGMwYujqCcvB == Consts.joystickGuid_unknownController)
				{
					return _name;
				}
				if (tIUrwoGTepIHaWkvXhpVlOsZVHaS == null || tIUrwoGTepIHaWkvXhpVlOsZVHaS.parentKeys == null)
				{
					return _name;
				}
				LocalizationManager.GetAndUpdateLocalizedString(hGMbUBmXvpdINuGbyjJgilLAMrPdb, (tIUrwoGTepIHaWkvXhpVlOsZVHaS != null) ? tIUrwoGTepIHaWkvXhpVlOsZVHaS.parentKeys : null, kgoenjfnufElmhiZmbMkzRwPiuvy.MiVAqWFimDZLnAOHmPIGgAKiNsPBb(_type), _name, out value);
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
				if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
				{
					ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
					return string.Empty;
				}
				return _tag;
			}
			set
			{
				if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
				{
					ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
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
				if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
				{
					ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
					return string.Empty;
				}
				return _hardwareName;
			}
		}

		public ControllerType type
		{
			get
			{
				if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
				{
					ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
					return ControllerType.Keyboard;
				}
				return _type;
			}
		}

		public Guid hardwareTypeGuid
		{
			get
			{
				if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
				{
					ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
					return Guid.Empty;
				}
				return qapLJarKYePKdgQROGMwYujqCcvB;
			}
		}

		public abstract Guid deviceInstanceGuid { get; }

		public ControllerIdentifier identifier => nQypOoeVpjEFyTjjFwJtTKSBPlui;

		public bool isConnected
		{
			get
			{
				if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
				{
					ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
					return false;
				}
				return _isConnected;
			}
			internal set
			{
				if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
				{
					ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
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
				if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
				{
					ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
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
				if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
				{
					ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
					return 0;
				}
				return lbzVvAzZERIOIbUTgRYFkMFluuXR.Count;
			}
		}

		public int buttonCount
		{
			get
			{
				if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
				{
					ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
					return 0;
				}
				return _buttonCount;
			}
		}

		public IList<Element> Elements
		{
			get
			{
				if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
				{
					ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
					return EmptyObjects<Element>.EmptyReadOnlyIListT;
				}
				return vuuZtqqaUnVBcnRgdJXxLSqQKrTd;
			}
		}

		public IList<CompoundElement> CompoundElements
		{
			get
			{
				if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
				{
					ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
					return EmptyObjects<CompoundElement>.EmptyReadOnlyIListT;
				}
				return ytMnlQbQcUEgwzJDBcxjbhgBPeUy;
			}
		}

		public IList<Button> Buttons
		{
			get
			{
				if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
				{
					ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
					return EmptyObjects<Button>.EmptyReadOnlyIListT;
				}
				return buttons_readOnly;
			}
		}

		public Extension extension
		{
			get
			{
				if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
				{
					ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
					return null;
				}
				return tDLZnJhZxzBcxAwAepUGzMiSgFeFA;
			}
		}

		public IList<ControllerElementIdentifier> ElementIdentifiers
		{
			get
			{
				if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
				{
					ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
					return EmptyObjects<ControllerElementIdentifier>.EmptyReadOnlyIListT;
				}
				return JEexZOPzSUUjNTHjvxywblgJdFqE.elementIdentifiers_readOnly;
			}
		}

		public IList<ControllerElementIdentifier> ButtonElementIdentifiers
		{
			get
			{
				if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
				{
					ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
					return EmptyObjects<ControllerElementIdentifier>.EmptyReadOnlyIListT;
				}
				return JEexZOPzSUUjNTHjvxywblgJdFqE.buttonElementIdentifiers_readOnly;
			}
		}

		internal ITryGetLocalizedName NMAKxWWmUpwqQNWynrlTLJrvKLcF
		{
			get
			{
				return PSSAUDnRNfgmRLsvItwPAlWxwXRi;
			}
			set
			{
				PSSAUDnRNfgmRLsvItwPAlWxwXRi = pSSAUDnRNfgmRLsvItwPAlWxwXRi;
			}
		}

		public IList<IControllerTemplate> Templates
		{
			get
			{
				if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
				{
					ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
					return EmptyObjects<IControllerTemplate>.EmptyReadOnlyIListT;
				}
				return cQTgjnLcsoqODqaLjlCYQibFOkQN;
			}
		}

		public int templateCount
		{
			get
			{
				if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
				{
					ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
					return 0;
				}
				return CKdAMvPKdmtIpLqfiNYomXZpVQoD.Length;
			}
		}

		internal static Func<Controller, Guid, bool> AlbEsUMpPCJhgQLDiFsMaiuPkGoQA => GSsxfRGIdEgmMrUHdBaVnxCUZKPW._003C_003E9.HsAbWnrHaPyYhvDfHeOEbBmrjejT;

		internal static Func<Controller, Type, bool> tglgkFHnvyFSgFaKTCTizAkQHrFx => GSsxfRGIdEgmMrUHdBaVnxCUZKPW._003C_003E9.wbeEpDzTUCnRKzfuLantkFwapVbb;

		internal event Action<bool> BaxIjLbHPaxcPYIMCfZOBTYdQVZab
		{
			add
			{
				PyoBPXhavXXcCJVNnMGTXrHHqaRyA = (Action<bool>)Delegate.Combine(PyoBPXhavXXcCJVNnMGTXrHHqaRyA, b);
			}
			remove
			{
				PyoBPXhavXXcCJVNnMGTXrHHqaRyA = (Action<bool>)Delegate.Remove(PyoBPXhavXXcCJVNnMGTXrHHqaRyA, value2);
			}
		}

		internal Controller(int P_0, InputSource P_1, string P_2, string P_3, string P_4, ControllerType P_5, Guid P_6, int P_7, bool[] P_8, HardwareButtonInfo[] P_9, HardwareControllerMap_Game P_10, Extension P_11, ControllerDataUpdater P_12)
		{
			id = P_0;
			inputSource = P_1;
			_type = P_5;
			qapLJarKYePKdgQROGMwYujqCcvB = P_6;
			_buttonCount = P_7;
			_name = P_2;
			_hardwareName = P_3;
			_hardwareIdentifier = P_4;
			vAJlxjrsCepUBGzroHjWcArmXQkU = P_12;
			JEexZOPzSUUjNTHjvxywblgJdFqE = P_10;
			tIUrwoGTepIHaWkvXhpVlOsZVHaS = P_10.deviceLocalizationInfo;
			FAWKxzOqRWJcbgGLYZRmKqCKfTobA = true;
			BLBdTaBAlamAEELtUyjiaIPfgySPA = ReInput.id;
			hGMbUBmXvpdINuGbyjJgilLAMrPdb = new LocalizedString();
			VBmfjEfeBMzrtsikQnQeCRsbxfIL = new oEKjTOxtumqnvVGrvGQjjCekBlgfb(delegate
			{
				_ = name;
			});
			PzkesJfKCipiagKoQdaqklIjBMVzA(P_11);
			lbzVvAzZERIOIbUTgRYFkMFluuXR = new List<Element>(P_7);
			vuuZtqqaUnVBcnRgdJXxLSqQKrTd = new ReadOnlyCollection<Element>(lbzVvAzZERIOIbUTgRYFkMFluuXR);
			WCvmyVCIkjuRlyyQYsMxfDxlBLVIA = new List<CompoundElement>();
			ytMnlQbQcUEgwzJDBcxjbhgBPeUy = new ReadOnlyCollection<CompoundElement>(WCvmyVCIkjuRlyyQYsMxfDxlBLVIA);
			buttons = new Button[P_7];
			if (P_8 == null || P_8.Length < P_7)
			{
				for (int num = 0; num < P_7; num++)
				{
					buttons[num] = new Button(this, P_10.buttonElementIdentifierIds[num], "Button " + num, false, (P_9 != null) ? P_9[num] : new HardwareButtonInfo());
					CnmKJzJNbScNsKxtssYAwlinIlxw(buttons[num]);
				}
			}
			else
			{
				for (int num2 = 0; num2 < P_7; num2++)
				{
					buttons[num2] = new Button(this, P_10.buttonElementIdentifierIds[num2], "Button " + num2, P_8[num2], (P_9 != null) ? P_9[num2] : new HardwareButtonInfo());
					CnmKJzJNbScNsKxtssYAwlinIlxw(buttons[num2]);
				}
			}
			buttons_readOnly = new ReadOnlyCollection<Button>(buttons);
			CKdAMvPKdmtIpLqfiNYomXZpVQoD = EmptyObjects<IControllerTemplate>.array;
			cQTgjnLcsoqODqaLjlCYQibFOkQN = new ReadOnlyCollection<IControllerTemplate>(CKdAMvPKdmtIpLqfiNYomXZpVQoD);
			if (LocalizationManager.isEnabled && LocalizationManager.autoPrefetch)
			{
				((fuTAbCyJgOZBWWgBXmUSttFWWuoi)VBmfjEfeBMzrtsikQnQeCRsbxfIL).Localize();
			}
			Connected();
		}

		internal virtual void jcuaGkxKxwRQhPfLTgjWpYLcOGCK()
		{
			nQypOoeVpjEFyTjjFwJtTKSBPlui = new ControllerIdentifier(this);
		}

		public virtual Element GetElementById(int elementIdentifierId)
		{
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
				return null;
			}
			if (JEexZOPzSUUjNTHjvxywblgJdFqE == null)
			{
				return null;
			}
			int buttonIndex = JEexZOPzSUUjNTHjvxywblgJdFqE.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0)
			{
				return null;
			}
			return buttons[buttonIndex];
		}

		public virtual CompoundElement GetCompoundElementById(int elementIdentifierId)
		{
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
				return null;
			}
			int count = WCvmyVCIkjuRlyyQYsMxfDxlBLVIA.Count;
			for (int i = 0; i < count; i++)
			{
				if (WCvmyVCIkjuRlyyQYsMxfDxlBLVIA[i] != null && WCvmyVCIkjuRlyyQYsMxfDxlBLVIA[i].id == elementIdentifierId)
				{
					return WCvmyVCIkjuRlyyQYsMxfDxlBLVIA[i];
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
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
				return -1;
			}
			return JEexZOPzSUUjNTHjvxywblgJdFqE.GetButtonIndex(elementIdentifierId);
		}

		public ControllerElementIdentifier GetElementIdentifierById(int elementIdentifierId)
		{
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
				return null;
			}
			return JEexZOPzSUUjNTHjvxywblgJdFqE.GetElementIdentifierById(elementIdentifierId);
		}

		public virtual bool GetButton(int index)
		{
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
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
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
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
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
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
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
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
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
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
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
				return false;
			}
			return GetButtonDoublePressHold(index, 0f);
		}

		public virtual bool GetButtonDoublePressHold(int index, float speed)
		{
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
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
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
				return false;
			}
			return GetButtonDoublePressDown(index, 0f);
		}

		public virtual bool GetButtonDoublePressDown(int index, float speed)
		{
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
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
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
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
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
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
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
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
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
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
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
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
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
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
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
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
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
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
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
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
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
				return false;
			}
			int buttonIndex = JEexZOPzSUUjNTHjvxywblgJdFqE.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				return false;
			}
			return buttons[buttonIndex].value;
		}

		public virtual bool GetButtonDownById(int elementIdentifierId)
		{
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
				return false;
			}
			int buttonIndex = JEexZOPzSUUjNTHjvxywblgJdFqE.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				return false;
			}
			return buttons[buttonIndex].justPressed;
		}

		public virtual bool GetButtonUpById(int elementIdentifierId)
		{
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
				return false;
			}
			int buttonIndex = JEexZOPzSUUjNTHjvxywblgJdFqE.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				return false;
			}
			return buttons[buttonIndex].justReleased;
		}

		public virtual bool GetButtonDoublePressHoldById(int elementIdentifierId, float speed)
		{
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
				return false;
			}
			int buttonIndex = JEexZOPzSUUjNTHjvxywblgJdFqE.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				return false;
			}
			return buttons[buttonIndex].DoublePressedAndHeld(speed);
		}

		public virtual bool GetButtonDoublePressDownById(int elementIdentifierId, float speed)
		{
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
				return false;
			}
			int buttonIndex = JEexZOPzSUUjNTHjvxywblgJdFqE.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				return false;
			}
			return buttons[buttonIndex].JustDoublePressed(speed);
		}

		public virtual bool GetButtonDoublePressHoldById(int elementIdentifierId)
		{
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
				return false;
			}
			int buttonIndex = JEexZOPzSUUjNTHjvxywblgJdFqE.GetButtonIndex(elementIdentifierId);
			return GetButtonDoublePressHold(buttonIndex, 0f);
		}

		public virtual bool GetButtonDoublePressDownById(int elementIdentifierId)
		{
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
				return false;
			}
			int buttonIndex = JEexZOPzSUUjNTHjvxywblgJdFqE.GetButtonIndex(elementIdentifierId);
			return GetButtonDoublePressDown(buttonIndex, 0f);
		}

		public virtual bool GetButtonPrevById(int elementIdentifierId)
		{
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
				return false;
			}
			int buttonIndex = JEexZOPzSUUjNTHjvxywblgJdFqE.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				return false;
			}
			return buttons[buttonIndex].valuePrev;
		}

		public virtual double GetButtonTimePressedById(int elementIdentifierId)
		{
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
				return 0.0;
			}
			int buttonIndex = JEexZOPzSUUjNTHjvxywblgJdFqE.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				return 0.0;
			}
			return buttons[buttonIndex].timePressed;
		}

		public virtual double GetButtonTimeUnpressedById(int elementIdentifierId)
		{
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
				return 0.0;
			}
			int buttonIndex = JEexZOPzSUUjNTHjvxywblgJdFqE.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				return 0.0;
			}
			return buttons[buttonIndex].timeUnpressed;
		}

		public virtual double GetButtonLastTimePressedById(int elementIdentifierId)
		{
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
				return 0.0;
			}
			int buttonIndex = JEexZOPzSUUjNTHjvxywblgJdFqE.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				return 0.0;
			}
			return buttons[buttonIndex].lastTimePressed;
		}

		public virtual double GetButtonLastTimeUnpressedById(int elementIdentifierId)
		{
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
				return 0.0;
			}
			int buttonIndex = JEexZOPzSUUjNTHjvxywblgJdFqE.GetButtonIndex(elementIdentifierId);
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
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
				return ControllerPollingInfo.ZwUAppCOgCTgGUtaDtNagYmPnIimA();
			}
			UpdatePollingFrameTracking();
			for (int i = 0; i < _buttonCount; i++)
			{
				if (kEnHaJFcZsntMHCfSAIlbcFCCprac(i, out var num))
				{
					return new ControllerPollingInfo(true, -1, id, _name, _type, ControllerElementType.Button, i, Pole.Positive, JEexZOPzSUUjNTHjvxywblgJdFqE.GetElementIdentifierName(num), num, KeyCode.None);
				}
			}
			return ControllerPollingInfo.ZwUAppCOgCTgGUtaDtNagYmPnIimA();
		}

		public virtual ControllerPollingInfo PollForFirstButtonDown()
		{
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
				return ControllerPollingInfo.ZwUAppCOgCTgGUtaDtNagYmPnIimA();
			}
			UpdatePollingFrameTracking();
			for (int i = 0; i < _buttonCount; i++)
			{
				if (AWWGizyTWKcZZyfBznvbAhpxlJKo(i, out var num))
				{
					return new ControllerPollingInfo(true, -1, id, _name, _type, ControllerElementType.Button, i, Pole.Positive, JEexZOPzSUUjNTHjvxywblgJdFqE.GetElementIdentifierName(num), num, KeyCode.None);
				}
			}
			return ControllerPollingInfo.ZwUAppCOgCTgGUtaDtNagYmPnIimA();
		}

		public virtual IEnumerable<ControllerPollingInfo> PollForAllElements()
		{
			return PollForAllButtons();
		}

		public virtual IEnumerable<ControllerPollingInfo> PollForAllElementsDown()
		{
			return PollForAllButtonsDown();
		}

		[IteratorStateMachine(typeof(BBVlrWcsckIbBObQkfWXvbPQEkHm))]
		public virtual IEnumerable<ControllerPollingInfo> PollForAllButtons()
		{
			return new BBVlrWcsckIbBObQkfWXvbPQEkHm(-2)
			{
				GtNdxZZexNqzvuIegksTdOmMsnrO = this
			};
		}

		[IteratorStateMachine(typeof(ZrguzloefVGjvzUHaKAyBgOugHqfA))]
		public virtual IEnumerable<ControllerPollingInfo> PollForAllButtonsDown()
		{
			return new ZrguzloefVGjvzUHaKAyBgOugHqfA(-2)
			{
				PdthMrUIhvQiRiEZKcdQsFazdRQfA = this
			};
		}

		private bool kEnHaJFcZsntMHCfSAIlbcFCCprac(int P_0, out int P_1)
		{
			P_1 = -1;
			if (!buttons[P_0].value || buttons[P_0].yXQYsGwaSnjXTPasjpRTXxIzcDLW._excludeFromPolling)
			{
				return false;
			}
			P_1 = JEexZOPzSUUjNTHjvxywblgJdFqE.buttonElementIdentifierIds[P_0];
			if (P_1 < 0)
			{
				return false;
			}
			return true;
		}

		private bool AWWGizyTWKcZZyfBznvbAhpxlJKo(int P_0, out int P_1)
		{
			P_1 = -1;
			if (!buttons[P_0].justPressed || buttons[P_0].yXQYsGwaSnjXTPasjpRTXxIzcDLW._excludeFromPolling)
			{
				return false;
			}
			P_1 = JEexZOPzSUUjNTHjvxywblgJdFqE.buttonElementIdentifierIds[P_0];
			if (P_1 < 0)
			{
				return false;
			}
			return true;
		}

		protected void UpdatePollingFrameTracking()
		{
			if (MFUgLuHUzgdQXOciLNIYArujRfQtA == ReInput.currentFrame)
			{
				return;
			}
			enHdbHWaRnjaecfcaOkwdpshcrbE = MFUgLuHUzgdQXOciLNIYArujRfQtA;
			MFUgLuHUzgdQXOciLNIYArujRfQtA = ReInput.currentFrame;
			if (!UhQxMfDOXfcvqFYGXMIEcuWrixEo)
			{
				if (FaPBxQSiRTtxQtkYJdpDejVMuMGR == uint.MaxValue)
				{
					FaPBxQSiRTtxQtkYJdpDejVMuMGR = 0u;
				}
				else
				{
					FaPBxQSiRTtxQtkYJdpDejVMuMGR++;
				}
			}
		}

		public virtual double GetLastTimeActive()
		{
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
				return 0.0;
			}
			return GetLastTimeActive(useRawValues: false);
		}

		public virtual double GetLastTimeActive(bool useRawValues)
		{
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
				return 0.0;
			}
			return GetLastTimeAnyButtonPressed();
		}

		public virtual double GetLastTimeAnyElementChanged()
		{
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
				return 0.0;
			}
			return GetLastTimeAnyElementChanged(useRawValues: false);
		}

		public virtual double GetLastTimeAnyElementChanged(bool useRawValues)
		{
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
				return 0.0;
			}
			return GetLastTimeAnyButtonChanged();
		}

		public double GetLastTimeAnyButtonPressed()
		{
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
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
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
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
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
				return null;
			}
			return tDLZnJhZxzBcxAwAepUGzMiSgFeFA as T;
		}

		public IControllerTemplate GetTemplate(Guid typeGuid)
		{
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
				return null;
			}
			for (int i = 0; i < CKdAMvPKdmtIpLqfiNYomXZpVQoD.Length; i++)
			{
				if (CKdAMvPKdmtIpLqfiNYomXZpVQoD[i].typeGuid == typeGuid)
				{
					return CKdAMvPKdmtIpLqfiNYomXZpVQoD[i];
				}
			}
			return null;
		}

		public IControllerTemplate GetTemplate(Type type)
		{
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
				return null;
			}
			for (int i = 0; i < CKdAMvPKdmtIpLqfiNYomXZpVQoD.Length; i++)
			{
				if (ReflectionTools.DoesTypeImplement(CKdAMvPKdmtIpLqfiNYomXZpVQoD[i].GetType(), type))
				{
					return CKdAMvPKdmtIpLqfiNYomXZpVQoD[i];
				}
			}
			return null;
		}

		public T GetTemplate<T>() where T : class
		{
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
				return null;
			}
			for (int i = 0; i < CKdAMvPKdmtIpLqfiNYomXZpVQoD.Length; i++)
			{
				if (CKdAMvPKdmtIpLqfiNYomXZpVQoD[i] as T != null)
				{
					return CKdAMvPKdmtIpLqfiNYomXZpVQoD[i] as T;
				}
			}
			return null;
		}

		public bool ImplementsTemplate(Guid typeGuid)
		{
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
				return false;
			}
			for (int i = 0; i < CKdAMvPKdmtIpLqfiNYomXZpVQoD.Length; i++)
			{
				if (CKdAMvPKdmtIpLqfiNYomXZpVQoD[i].typeGuid == typeGuid)
				{
					return true;
				}
			}
			return false;
		}

		public bool ImplementsTemplate(Type type)
		{
			if (ReInput._id != BLBdTaBAlamAEELtUyjiaIPfgySPA)
			{
				ReInput.CheckInitialized(BLBdTaBAlamAEELtUyjiaIPfgySPA);
				return false;
			}
			if (type == null)
			{
				throw new ArgumentNullException("type");
			}
			for (int i = 0; i < CKdAMvPKdmtIpLqfiNYomXZpVQoD.Length; i++)
			{
				if (ReflectionTools.DoesTypeImplement(CKdAMvPKdmtIpLqfiNYomXZpVQoD[i].GetType(), type))
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

		internal void LfRezRHKhdxGDWbeNAqeGxEcxqvWb(IControllerTemplate[] P_0)
		{
			if (P_0 != null)
			{
				CKdAMvPKdmtIpLqfiNYomXZpVQoD = P_0;
				cQTgjnLcsoqODqaLjlCYQibFOkQN = new ReadOnlyCollection<IControllerTemplate>(CKdAMvPKdmtIpLqfiNYomXZpVQoD);
			}
		}

		internal virtual void SSAuafxQNvPbHvrzmnbTGwbAWFNW(UpdateLoopType P_0)
		{
			bool num = ReInput.IsInputAllowed(_type);
			int num2 = _buttonCount;
			if (num)
			{
				for (int i = 0; i < num2; i++)
				{
					if (buttons[i].syoyrWlrQxnXHlRCagQSbdPqHsHn <= 0)
					{
						buttons[i].viHgNbCUcsmRhvdKxmIOtUmKcUWBA(P_0, i, vAJlxjrsCepUBGzroHjWcArmXQkU);
					}
				}
			}
			else
			{
				for (int j = 0; j < num2; j++)
				{
					if (buttons[j].syoyrWlrQxnXHlRCagQSbdPqHsHn <= 0)
					{
						buttons[j].XoVbBNIkEuPXOHSzYNQbjSUFdDzK(P_0);
					}
				}
			}
			if (tDLZnJhZxzBcxAwAepUGzMiSgFeFA != null)
			{
				tDLZnJhZxzBcxAwAepUGzMiSgFeFA.UpdateData(P_0);
			}
		}

		internal virtual ButtonStateFlags yzzkYDFOMvoraCJYdYbiyAQxmSiO(int P_0)
		{
			if (P_0 < 0 || P_0 >= _buttonCount)
			{
				return ButtonStateFlags.Off;
			}
			return buttons[P_0].IXreFOQOBUrsjjTLIqFKHRslRBcw;
		}

		internal void PzkesJfKCipiagKoQdaqklIjBMVzA(Extension P_0)
		{
			if (P_0 == null)
			{
				tDLZnJhZxzBcxAwAepUGzMiSgFeFA = null;
				return;
			}
			if (tDLZnJhZxzBcxAwAepUGzMiSgFeFA != null)
			{
				HTixuhiCTdJkvvseJKLoHkvavBYs(P_0);
				return;
			}
			P_0.SetController(this);
			tDLZnJhZxzBcxAwAepUGzMiSgFeFA = P_0.Clone();
		}

		internal void HTixuhiCTdJkvvseJKLoHkvavBYs(Extension P_0)
		{
			if (tDLZnJhZxzBcxAwAepUGzMiSgFeFA != null)
			{
				tDLZnJhZxzBcxAwAepUGzMiSgFeFA.SetSource(P_0);
				tDLZnJhZxzBcxAwAepUGzMiSgFeFA.SetController(this);
				P_0?.SetController(this);
			}
			else
			{
				PzkesJfKCipiagKoQdaqklIjBMVzA(P_0);
			}
		}

		internal virtual void ufAgwGoHxawiKAxEmPcnTrGkJWTF()
		{
			for (int i = 0; i < _buttonCount; i++)
			{
				if (buttons[i] != null)
				{
					buttons[i].Reset();
				}
			}
			if (vAJlxjrsCepUBGzroHjWcArmXQkU != null)
			{
				vAJlxjrsCepUBGzroHjWcArmXQkU.ClearData();
			}
			if (tDLZnJhZxzBcxAwAepUGzMiSgFeFA != null)
			{
				tDLZnJhZxzBcxAwAepUGzMiSgFeFA.Clear();
			}
		}

		internal virtual bool JErfaHktCKVFtNnhTKDJdWzTRcaq(bool P_0)
		{
			if (FAWKxzOqRWJcbgGLYZRmKqCKfTobA == P_0)
			{
				return false;
			}
			if (!P_0)
			{
				ufAgwGoHxawiKAxEmPcnTrGkJWTF();
			}
			FAWKxzOqRWJcbgGLYZRmKqCKfTobA = P_0;
			if (PyoBPXhavXXcCJVNnMGTXrHHqaRyA != null)
			{
				PyoBPXhavXXcCJVNnMGTXrHHqaRyA(P_0);
			}
			return true;
		}

		internal virtual void CfhpsvHyWfICgEKNRdHQTCKBrgig(ControllerMap P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			try
			{
				ControllerMap.SgBcrvnOtECGyjPXXClnObWapWwBb();
				P_0.controllerId = id;
				IList<ActionElementMap> buttonMaps = P_0.ButtonMaps;
				for (int i = 0; i < buttonMaps.Count; i++)
				{
					EfvdQpyXFryBbeksYVlLvkBmPQQC(P_0, buttonMaps[i]);
				}
				for (int num = buttonMaps.Count - 1; num >= 0; num--)
				{
					if (buttonMaps[num].elementIndex < 0)
					{
						P_0.DeleteElementMap(buttonMaps[num].gjHUlVyQSQsjZEOHtHfmeehEQpiIA);
					}
				}
			}
			finally
			{
				ControllerMap.tvbsaMCIOZDkpfIxmIGWXRPXoybbA();
			}
		}

		internal virtual void EfvdQpyXFryBbeksYVlLvkBmPQQC(ControllerMap P_0, ActionElementMap P_1)
		{
			if (P_1 != null && P_1._elementType == ControllerElementType.Button)
			{
				P_1.FNqTNkOozAgwnWePEBwoFWAPyUfy(P_0);
			}
		}

		internal bool OoMHmAdcRmxeTmnlxkbcciLNKMWV(ActionElementMap P_0, int P_1, out float P_2, out bool P_3)
		{
			P_3 = false;
			P_2 = 0f;
			if (P_1 != P_0._actionId)
			{
				return false;
			}
			int fpLTJzOTpoUWkyThKhrqRzXDquMW = P_0.fpLTJzOTpoUWkyThKhrqRzXDquMW;
			if (fpLTJzOTpoUWkyThKhrqRzXDquMW < 0 || fpLTJzOTpoUWkyThKhrqRzXDquMW >= _buttonCount)
			{
				return false;
			}
			P_3 = buttons[fpLTJzOTpoUWkyThKhrqRzXDquMW].zYxZhfuNukCUtEBdnavNRBTVDXGu;
			float num = ((!P_3) ? (buttons[fpLTJzOTpoUWkyThKhrqRzXDquMW].value ? 1f : 0f) : buttons[fpLTJzOTpoUWkyThKhrqRzXDquMW].pressure);
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

		internal bool kyuOdCuxIzFBaEiPRoQDIZEzdwqc(ActionElementMap P_0, int P_1, bool P_2, out float P_3)
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

		internal void CnmKJzJNbScNsKxtssYAwlinIlxw(Element P_0)
		{
			if (P_0 != null)
			{
				ListTools.AddIfUnique(lbzVvAzZERIOIbUTgRYFkMFluuXR, P_0);
			}
		}

		internal void zSHDKCuszCZlCImNllcKJkiMDDjp(CompoundElement P_0)
		{
			if (P_0 != null)
			{
				ListTools.AddIfUnique(WCvmyVCIkjuRlyyQYsMxfDxlBLVIA, P_0);
			}
		}

		internal virtual Guid zxLgUmCDdQNPaiaGRlhtsqNspjlZA()
		{
			return Guid.Empty;
		}

		internal virtual void ynvWXRFBEHELOcvmGFbfaRmNjJwMA(bool P_0)
		{
			if (!P_0 && !ReInput.IsInputAllowed(_type) && tDLZnJhZxzBcxAwAepUGzMiSgFeFA != null)
			{
				tDLZnJhZxzBcxAwAepUGzMiSgFeFA.Clear();
			}
		}

		protected virtual void Connected()
		{
			_isConnected = true;
		}

		protected virtual void Disconnected()
		{
			_isConnected = false;
			if (vAJlxjrsCepUBGzroHjWcArmXQkU != null)
			{
				vAJlxjrsCepUBGzroHjWcArmXQkU.ClearData();
			}
		}

		[CompilerGenerated]
		private void AmgDCJiHfsWAUZYMmUhixnFblFhw()
		{
			_ = name;
		}
	}
}
