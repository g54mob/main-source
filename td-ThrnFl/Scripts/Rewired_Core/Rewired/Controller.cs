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
			internal abstract class RxzeFFlTCoMdFwHqjGqGjxOuTuFM
			{
				public abstract class MKurlxCibRDyKALjzbzOANkCCkCjc
				{
					public abstract void uOOLxsCWpqamVUMsAuxkYNjonXCJ();
				}

				protected readonly int qmvYFvvbYjrSKRmZLRNkGYNGCOKV;

				protected readonly int[] ztcqfJaAiqwZLqfnMkenPhDinPHp;

				protected MKurlxCibRDyKALjzbzOANkCCkCjc[] sfRIDnyZWJFdGjEMVCQoFFMvkEaP;

				public MKurlxCibRDyKALjzbzOANkCCkCjc wzDSUWQnMveYROucQcUdhfFFKgPt;

				private int ARUBHDzwUDlifFwGdcCQqhHlEEjf;

				public int TnSSVYQqjCcoFWTBcqZXObWymOVt = -1;

				protected ReadOnlyCollection<MKurlxCibRDyKALjzbzOANkCCkCjc> RUJIFuQmkLGKihiSvIyqCnXENhrkA;

				public IList<MKurlxCibRDyKALjzbzOANkCCkCjc> KnnRTPAahlBjqQemncCRjsvhVputA => RUJIFuQmkLGKihiSvIyqCnXENhrkA;

				public UpdateLoopType DIjiSbLLXNKqIlzQvAlARMRMefLkA
				{
					set
					{
						if (TnSSVYQqjCcoFWTBcqZXObWymOVt != (int)updateLoopType)
						{
							TnSSVYQqjCcoFWTBcqZXObWymOVt = (int)updateLoopType;
							ARUBHDzwUDlifFwGdcCQqhHlEEjf = ztcqfJaAiqwZLqfnMkenPhDinPHp[(int)updateLoopType];
							wzDSUWQnMveYROucQcUdhfFFKgPt = sfRIDnyZWJFdGjEMVCQoFFMvkEaP[ARUBHDzwUDlifFwGdcCQqhHlEEjf];
						}
					}
				}

				public RxzeFFlTCoMdFwHqjGqGjxOuTuFM(UpdateLoopSetting P_0)
				{
					ztcqfJaAiqwZLqfnMkenPhDinPHp = new int[3];
					qmvYFvvbYjrSKRmZLRNkGYNGCOKV = 0;
					using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
					{
						List<UpdateLoopType> list = tList.list;
						EnumConverter.ToUpdateLoopTypes(P_0, list);
						for (int i = 0; i < list.Count; i++)
						{
							ztcqfJaAiqwZLqfnMkenPhDinPHp[(int)list[i]] = qmvYFvvbYjrSKRmZLRNkGYNGCOKV;
							qmvYFvvbYjrSKRmZLRNkGYNGCOKV++;
						}
					}
					sfRIDnyZWJFdGjEMVCQoFFMvkEaP = new MKurlxCibRDyKALjzbzOANkCCkCjc[qmvYFvvbYjrSKRmZLRNkGYNGCOKV];
					RUJIFuQmkLGKihiSvIyqCnXENhrkA = new ReadOnlyCollection<MKurlxCibRDyKALjzbzOANkCCkCjc>(sfRIDnyZWJFdGjEMVCQoFFMvkEaP);
				}

				public void inXbRdGhNUmvNVpMpcCZeOfeQZgNB()
				{
					for (int i = 0; i < qmvYFvvbYjrSKRmZLRNkGYNGCOKV; i++)
					{
						sfRIDnyZWJFdGjEMVCQoFFMvkEaP[i].uOOLxsCWpqamVUMsAuxkYNjonXCJ();
					}
				}

				public MKurlxCibRDyKALjzbzOANkCCkCjc jqPXJCprbWgQPxmQEkoHGiONSDqi(UpdateLoopType P_0)
				{
					return sfRIDnyZWJFdGjEMVCQoFFMvkEaP[ztcqfJaAiqwZLqfnMkenPhDinPHp[(int)P_0]];
				}
			}

			public readonly int id;

			public readonly string name;

			public readonly ControllerElementType type;

			internal RxzeFFlTCoMdFwHqjGqGjxOuTuFM TbAMdfGPXwfkeyBRZhXZbHzyUQSF;

			internal int PXIBbobqHpgLOSBLASIrpQiQgxIg;

			internal Controller tHyTrlHkDtjZaDgMPCsGdVcGGXwD;

			internal readonly int OWoyNGGKhbJZoovYYhmnbrMuMSVv;

			private CompoundElement pwTjzgavAlUwyVKifNciYOdRibtG;

			public ControllerElementIdentifier elementIdentifier
			{
				get
				{
					if (ReInput._id != OWoyNGGKhbJZoovYYhmnbrMuMSVv)
					{
						ReInput.CheckInitialized(OWoyNGGKhbJZoovYYhmnbrMuMSVv);
						return null;
					}
					ControllerElementIdentifier elementIdentifierById = tHyTrlHkDtjZaDgMPCsGdVcGGXwD.GetElementIdentifierById(id);
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
					if (ReInput._id != OWoyNGGKhbJZoovYYhmnbrMuMSVv)
					{
						ReInput.CheckInitialized(OWoyNGGKhbJZoovYYhmnbrMuMSVv);
						return false;
					}
					return PXIBbobqHpgLOSBLASIrpQiQgxIg > 0;
				}
			}

			public CompoundElement compoundElement => pwTjzgavAlUwyVKifNciYOdRibtG;

			internal Element(Controller P_0, int P_1, string P_2, ControllerElementType P_3)
			{
				tHyTrlHkDtjZaDgMPCsGdVcGGXwD = P_0;
				id = P_1;
				name = P_2;
				type = P_3;
				OWoyNGGKhbJZoovYYhmnbrMuMSVv = ReInput.id;
			}

			public void Reset()
			{
				if (ReInput._id != OWoyNGGKhbJZoovYYhmnbrMuMSVv)
				{
					ReInput.CheckInitialized(OWoyNGGKhbJZoovYYhmnbrMuMSVv);
				}
				else if (TbAMdfGPXwfkeyBRZhXZbHzyUQSF != null)
				{
					TbAMdfGPXwfkeyBRZhXZbHzyUQSF.inXbRdGhNUmvNVpMpcCZeOfeQZgNB();
				}
			}

			internal void QiwajZdkPqpKFHSXGxNATpckJzBG(CompoundElement P_0)
			{
				if (PXIBbobqHpgLOSBLASIrpQiQgxIg > 0)
				{
					Logger.LogWarning("This element is already a member of a compound element! This is not supported. Resulting values may be unpredictable.");
				}
				PXIBbobqHpgLOSBLASIrpQiQgxIg++;
				if (pwTjzgavAlUwyVKifNciYOdRibtG == null)
				{
					pwTjzgavAlUwyVKifNciYOdRibtG = P_0;
				}
			}

			internal void BNTsavdtWwlOIqdJufbjiGHnbJKqA(CompoundElement P_0)
			{
				if (PXIBbobqHpgLOSBLASIrpQiQgxIg == 0)
				{
					Logger.LogWarning("This element is not a member of a compound element!");
					PXIBbobqHpgLOSBLASIrpQiQgxIg = 0;
					return;
				}
				PXIBbobqHpgLOSBLASIrpQiQgxIg--;
				if (pwTjzgavAlUwyVKifNciYOdRibtG == P_0)
				{
					pwTjzgavAlUwyVKifNciYOdRibtG = null;
				}
			}
		}

		public sealed class Axis : Element
		{
			internal class MqpfiMpTDeqQTwJTFWKzuAuEQHcK : RxzeFFlTCoMdFwHqjGqGjxOuTuFM
			{
				public class HIzAawsnBWfiCgzFKfNQVUYgMFanA : MKurlxCibRDyKALjzbzOANkCCkCjc
				{
					private const float RissYOXpYTnFnHHbgtUnNCephpudA = 0.001f;

					public float LWVtFNCoDUdsyeEGizwAihRKzRTG;

					public float zazbHhMJwneaQBYYTtFTUiwuaEaXA;

					public float UcYxlgjAmgGPOjlbswUmCZFxHvdf;

					public float fwqcTBetaqVxjRHpjgDbmgqsqMTZ;

					public float aDVvohZPxEzGIwDiOPuifjbnFkvu;

					public float JQGOpcnYBErzTFgKlPmvLjTfZlvT;

					public double vdxMfQnGEvMkmEPVGZRcXUgmSKim;

					public double HGKShbTHsoknJeiGgcaVtjoCpOpB;

					public double OLuCEqFozfGckfAnSeZeKjXuVKee;

					public double ieqQfyGNeFYKCmQfeOaNznAjIpSD;

					public double qzRpVTtexCnxPhNEMBVjgiEMngib;

					public double PycOUlIQMdowKPuHNUojRHMWRhSB;

					public double ujmYAQagDrBTtDnnUvLxgcOqUDgC
					{
						get
						{
							if ((double)LWVtFNCoDUdsyeEGizwAihRKzRTG == 0.0)
							{
								return 0.0;
							}
							return ReInput.unscaledTime - OLuCEqFozfGckfAnSeZeKjXuVKee;
						}
					}

					public double nveGLkESrUtxXeAgVGfBBteaVAtFA
					{
						get
						{
							if ((double)UcYxlgjAmgGPOjlbswUmCZFxHvdf == 0.0)
							{
								return 0.0;
							}
							return ReInput.unscaledTime - ieqQfyGNeFYKCmQfeOaNznAjIpSD;
						}
					}

					public double WufBlARGznqOZvyBPLCuavKihJpk
					{
						get
						{
							if (LWVtFNCoDUdsyeEGizwAihRKzRTG != 0f)
							{
								return 0.0;
							}
							return ReInput.unscaledTime - vdxMfQnGEvMkmEPVGZRcXUgmSKim;
						}
					}

					public double cNxUEanxejRMjCecvmNAihOJYYbs
					{
						get
						{
							if ((double)UcYxlgjAmgGPOjlbswUmCZFxHvdf != 0.0)
							{
								return 0.0;
							}
							return ReInput.unscaledTime - HGKShbTHsoknJeiGgcaVtjoCpOpB;
						}
					}

					public void cPwtRQteBOBmlalHIdXnGfAHlnOI(bool P_0)
					{
						double unscaledTime = ReInput.unscaledTime;
						if (P_0)
						{
							if (!MathTools.Approximately(aDVvohZPxEzGIwDiOPuifjbnFkvu, 0f))
							{
								vdxMfQnGEvMkmEPVGZRcXUgmSKim = unscaledTime;
							}
							else
							{
								OLuCEqFozfGckfAnSeZeKjXuVKee = unscaledTime;
							}
							if (!MathTools.IsNear(aDVvohZPxEzGIwDiOPuifjbnFkvu, JQGOpcnYBErzTFgKlPmvLjTfZlvT, 0.001f))
							{
								qzRpVTtexCnxPhNEMBVjgiEMngib = unscaledTime;
							}
						}
						else
						{
							if (!MathTools.Approximately(LWVtFNCoDUdsyeEGizwAihRKzRTG, 0f))
							{
								vdxMfQnGEvMkmEPVGZRcXUgmSKim = unscaledTime;
							}
							else
							{
								OLuCEqFozfGckfAnSeZeKjXuVKee = unscaledTime;
							}
							if (!MathTools.IsNear(LWVtFNCoDUdsyeEGizwAihRKzRTG, zazbHhMJwneaQBYYTtFTUiwuaEaXA, 0.001f))
							{
								qzRpVTtexCnxPhNEMBVjgiEMngib = unscaledTime;
							}
						}
						if (!MathTools.Approximately(UcYxlgjAmgGPOjlbswUmCZFxHvdf, 0f))
						{
							HGKShbTHsoknJeiGgcaVtjoCpOpB = unscaledTime;
						}
						else
						{
							ieqQfyGNeFYKCmQfeOaNznAjIpSD = unscaledTime;
						}
						if (!MathTools.IsNear(UcYxlgjAmgGPOjlbswUmCZFxHvdf, fwqcTBetaqVxjRHpjgDbmgqsqMTZ, 0.001f))
						{
							PycOUlIQMdowKPuHNUojRHMWRhSB = unscaledTime;
						}
					}

					public void OZiPdReWNrTAIEjBtEQVHMEdYXLKA(float P_0)
					{
						if (fwqcTBetaqVxjRHpjgDbmgqsqMTZ != UcYxlgjAmgGPOjlbswUmCZFxHvdf)
						{
							fwqcTBetaqVxjRHpjgDbmgqsqMTZ = UcYxlgjAmgGPOjlbswUmCZFxHvdf;
						}
						if (UcYxlgjAmgGPOjlbswUmCZFxHvdf != P_0)
						{
							UcYxlgjAmgGPOjlbswUmCZFxHvdf = P_0;
						}
					}

					public virtual void ZiaOIMEQJenUUwFpJuohqMeIQlVm()
					{
						LWVtFNCoDUdsyeEGizwAihRKzRTG = 0f;
						zazbHhMJwneaQBYYTtFTUiwuaEaXA = 0f;
						UcYxlgjAmgGPOjlbswUmCZFxHvdf = 0f;
						fwqcTBetaqVxjRHpjgDbmgqsqMTZ = 0f;
						vdxMfQnGEvMkmEPVGZRcXUgmSKim = 0.0;
						HGKShbTHsoknJeiGgcaVtjoCpOpB = 0.0;
						OLuCEqFozfGckfAnSeZeKjXuVKee = 0.0;
						ieqQfyGNeFYKCmQfeOaNznAjIpSD = 0.0;
						qzRpVTtexCnxPhNEMBVjgiEMngib = 0.0;
						PycOUlIQMdowKPuHNUojRHMWRhSB = 0.0;
					}
				}

				public MqpfiMpTDeqQTwJTFWKzuAuEQHcK(UpdateLoopSetting P_0)
					: base(P_0)
				{
					for (int i = 0; i < qmvYFvvbYjrSKRmZLRNkGYNGCOKV; i++)
					{
						sfRIDnyZWJFdGjEMVCQoFFMvkEaP[i] = new HIzAawsnBWfiCgzFKfNQVUYgMFanA();
					}
					wzDSUWQnMveYROucQcUdhfFFKgPt = sfRIDnyZWJFdGjEMVCQoFFMvkEaP[0];
				}
			}

			internal readonly AxisRange SgxKpljiYUbKChIpZjYoXnjBsaRqA;

			internal readonly HardwareAxisInfo RWCEZctGAZWeIhWIQMIAdNROmnEb;

			public float value
			{
				get
				{
					if (ReInput._id != OWoyNGGKhbJZoovYYhmnbrMuMSVv)
					{
						ReInput.CheckInitialized(OWoyNGGKhbJZoovYYhmnbrMuMSVv);
						return 0f;
					}
					if (base.isMemberElement)
					{
						return ((MqpfiMpTDeqQTwJTFWKzuAuEQHcK.HIzAawsnBWfiCgzFKfNQVUYgMFanA)TbAMdfGPXwfkeyBRZhXZbHzyUQSF.wzDSUWQnMveYROucQcUdhfFFKgPt).aDVvohZPxEzGIwDiOPuifjbnFkvu;
					}
					return ((MqpfiMpTDeqQTwJTFWKzuAuEQHcK.HIzAawsnBWfiCgzFKfNQVUYgMFanA)TbAMdfGPXwfkeyBRZhXZbHzyUQSF.wzDSUWQnMveYROucQcUdhfFFKgPt).LWVtFNCoDUdsyeEGizwAihRKzRTG;
				}
			}

			public float valuePrev
			{
				get
				{
					if (ReInput._id != OWoyNGGKhbJZoovYYhmnbrMuMSVv)
					{
						ReInput.CheckInitialized(OWoyNGGKhbJZoovYYhmnbrMuMSVv);
						return 0f;
					}
					if (base.isMemberElement)
					{
						return ((MqpfiMpTDeqQTwJTFWKzuAuEQHcK.HIzAawsnBWfiCgzFKfNQVUYgMFanA)TbAMdfGPXwfkeyBRZhXZbHzyUQSF.wzDSUWQnMveYROucQcUdhfFFKgPt).JQGOpcnYBErzTFgKlPmvLjTfZlvT;
					}
					return ((MqpfiMpTDeqQTwJTFWKzuAuEQHcK.HIzAawsnBWfiCgzFKfNQVUYgMFanA)TbAMdfGPXwfkeyBRZhXZbHzyUQSF.wzDSUWQnMveYROucQcUdhfFFKgPt).zazbHhMJwneaQBYYTtFTUiwuaEaXA;
				}
			}

			public float valueRaw
			{
				get
				{
					if (ReInput._id != OWoyNGGKhbJZoovYYhmnbrMuMSVv)
					{
						ReInput.CheckInitialized(OWoyNGGKhbJZoovYYhmnbrMuMSVv);
						return 0f;
					}
					return ((MqpfiMpTDeqQTwJTFWKzuAuEQHcK.HIzAawsnBWfiCgzFKfNQVUYgMFanA)TbAMdfGPXwfkeyBRZhXZbHzyUQSF.wzDSUWQnMveYROucQcUdhfFFKgPt).UcYxlgjAmgGPOjlbswUmCZFxHvdf;
				}
				internal set
				{
					((MqpfiMpTDeqQTwJTFWKzuAuEQHcK.HIzAawsnBWfiCgzFKfNQVUYgMFanA)TbAMdfGPXwfkeyBRZhXZbHzyUQSF.wzDSUWQnMveYROucQcUdhfFFKgPt).OZiPdReWNrTAIEjBtEQVHMEdYXLKA(num);
				}
			}

			public float valueRawPrev
			{
				get
				{
					if (ReInput._id != OWoyNGGKhbJZoovYYhmnbrMuMSVv)
					{
						ReInput.CheckInitialized(OWoyNGGKhbJZoovYYhmnbrMuMSVv);
						return 0f;
					}
					return ((MqpfiMpTDeqQTwJTFWKzuAuEQHcK.HIzAawsnBWfiCgzFKfNQVUYgMFanA)TbAMdfGPXwfkeyBRZhXZbHzyUQSF.wzDSUWQnMveYROucQcUdhfFFKgPt).fwqcTBetaqVxjRHpjgDbmgqsqMTZ;
				}
			}

			public float valueDelta
			{
				get
				{
					if (ReInput._id != OWoyNGGKhbJZoovYYhmnbrMuMSVv)
					{
						ReInput.CheckInitialized(OWoyNGGKhbJZoovYYhmnbrMuMSVv);
						return 0f;
					}
					return value - valuePrev;
				}
			}

			public float valueDeltaRaw
			{
				get
				{
					if (ReInput._id != OWoyNGGKhbJZoovYYhmnbrMuMSVv)
					{
						ReInput.CheckInitialized(OWoyNGGKhbJZoovYYhmnbrMuMSVv);
						return 0f;
					}
					return ((MqpfiMpTDeqQTwJTFWKzuAuEQHcK.HIzAawsnBWfiCgzFKfNQVUYgMFanA)TbAMdfGPXwfkeyBRZhXZbHzyUQSF.wzDSUWQnMveYROucQcUdhfFFKgPt).UcYxlgjAmgGPOjlbswUmCZFxHvdf - ((MqpfiMpTDeqQTwJTFWKzuAuEQHcK.HIzAawsnBWfiCgzFKfNQVUYgMFanA)TbAMdfGPXwfkeyBRZhXZbHzyUQSF.wzDSUWQnMveYROucQcUdhfFFKgPt).fwqcTBetaqVxjRHpjgDbmgqsqMTZ;
				}
			}

			public double lastTimeActive
			{
				get
				{
					if (ReInput._id != OWoyNGGKhbJZoovYYhmnbrMuMSVv)
					{
						ReInput.CheckInitialized(OWoyNGGKhbJZoovYYhmnbrMuMSVv);
						return 0.0;
					}
					return ((MqpfiMpTDeqQTwJTFWKzuAuEQHcK.HIzAawsnBWfiCgzFKfNQVUYgMFanA)TbAMdfGPXwfkeyBRZhXZbHzyUQSF.wzDSUWQnMveYROucQcUdhfFFKgPt).vdxMfQnGEvMkmEPVGZRcXUgmSKim;
				}
			}

			public double lastTimeActiveRaw
			{
				get
				{
					if (ReInput._id != OWoyNGGKhbJZoovYYhmnbrMuMSVv)
					{
						ReInput.CheckInitialized(OWoyNGGKhbJZoovYYhmnbrMuMSVv);
						return 0.0;
					}
					return ((MqpfiMpTDeqQTwJTFWKzuAuEQHcK.HIzAawsnBWfiCgzFKfNQVUYgMFanA)TbAMdfGPXwfkeyBRZhXZbHzyUQSF.wzDSUWQnMveYROucQcUdhfFFKgPt).HGKShbTHsoknJeiGgcaVtjoCpOpB;
				}
			}

			public double lastTimeInactive
			{
				get
				{
					if (ReInput._id != OWoyNGGKhbJZoovYYhmnbrMuMSVv)
					{
						ReInput.CheckInitialized(OWoyNGGKhbJZoovYYhmnbrMuMSVv);
						return 0.0;
					}
					return ((MqpfiMpTDeqQTwJTFWKzuAuEQHcK.HIzAawsnBWfiCgzFKfNQVUYgMFanA)TbAMdfGPXwfkeyBRZhXZbHzyUQSF.wzDSUWQnMveYROucQcUdhfFFKgPt).OLuCEqFozfGckfAnSeZeKjXuVKee;
				}
			}

			public double lastTimeInactiveRaw
			{
				get
				{
					if (ReInput._id != OWoyNGGKhbJZoovYYhmnbrMuMSVv)
					{
						ReInput.CheckInitialized(OWoyNGGKhbJZoovYYhmnbrMuMSVv);
						return 0.0;
					}
					return ((MqpfiMpTDeqQTwJTFWKzuAuEQHcK.HIzAawsnBWfiCgzFKfNQVUYgMFanA)TbAMdfGPXwfkeyBRZhXZbHzyUQSF.wzDSUWQnMveYROucQcUdhfFFKgPt).ieqQfyGNeFYKCmQfeOaNznAjIpSD;
				}
			}

			public double lastTimeValueChanged
			{
				get
				{
					if (ReInput._id != OWoyNGGKhbJZoovYYhmnbrMuMSVv)
					{
						ReInput.CheckInitialized(OWoyNGGKhbJZoovYYhmnbrMuMSVv);
						return 0.0;
					}
					return ((MqpfiMpTDeqQTwJTFWKzuAuEQHcK.HIzAawsnBWfiCgzFKfNQVUYgMFanA)TbAMdfGPXwfkeyBRZhXZbHzyUQSF.wzDSUWQnMveYROucQcUdhfFFKgPt).qzRpVTtexCnxPhNEMBVjgiEMngib;
				}
			}

			public double lastTimeValueChangedRaw
			{
				get
				{
					if (ReInput._id != OWoyNGGKhbJZoovYYhmnbrMuMSVv)
					{
						ReInput.CheckInitialized(OWoyNGGKhbJZoovYYhmnbrMuMSVv);
						return 0.0;
					}
					return ((MqpfiMpTDeqQTwJTFWKzuAuEQHcK.HIzAawsnBWfiCgzFKfNQVUYgMFanA)TbAMdfGPXwfkeyBRZhXZbHzyUQSF.wzDSUWQnMveYROucQcUdhfFFKgPt).PycOUlIQMdowKPuHNUojRHMWRhSB;
				}
			}

			public double timeActive
			{
				get
				{
					if (ReInput._id != OWoyNGGKhbJZoovYYhmnbrMuMSVv)
					{
						ReInput.CheckInitialized(OWoyNGGKhbJZoovYYhmnbrMuMSVv);
						return 0.0;
					}
					return ((MqpfiMpTDeqQTwJTFWKzuAuEQHcK.HIzAawsnBWfiCgzFKfNQVUYgMFanA)TbAMdfGPXwfkeyBRZhXZbHzyUQSF.wzDSUWQnMveYROucQcUdhfFFKgPt).ujmYAQagDrBTtDnnUvLxgcOqUDgC;
				}
			}

			public double timeActiveRaw
			{
				get
				{
					if (ReInput._id != OWoyNGGKhbJZoovYYhmnbrMuMSVv)
					{
						ReInput.CheckInitialized(OWoyNGGKhbJZoovYYhmnbrMuMSVv);
						return 0.0;
					}
					return ((MqpfiMpTDeqQTwJTFWKzuAuEQHcK.HIzAawsnBWfiCgzFKfNQVUYgMFanA)TbAMdfGPXwfkeyBRZhXZbHzyUQSF.wzDSUWQnMveYROucQcUdhfFFKgPt).ujmYAQagDrBTtDnnUvLxgcOqUDgC;
				}
			}

			public double timeInactive
			{
				get
				{
					if (ReInput._id != OWoyNGGKhbJZoovYYhmnbrMuMSVv)
					{
						ReInput.CheckInitialized(OWoyNGGKhbJZoovYYhmnbrMuMSVv);
						return 0.0;
					}
					return ((MqpfiMpTDeqQTwJTFWKzuAuEQHcK.HIzAawsnBWfiCgzFKfNQVUYgMFanA)TbAMdfGPXwfkeyBRZhXZbHzyUQSF.wzDSUWQnMveYROucQcUdhfFFKgPt).WufBlARGznqOZvyBPLCuavKihJpk;
				}
			}

			public double timeInactiveRaw
			{
				get
				{
					if (ReInput._id != OWoyNGGKhbJZoovYYhmnbrMuMSVv)
					{
						ReInput.CheckInitialized(OWoyNGGKhbJZoovYYhmnbrMuMSVv);
						return 0.0;
					}
					return ((MqpfiMpTDeqQTwJTFWKzuAuEQHcK.HIzAawsnBWfiCgzFKfNQVUYgMFanA)TbAMdfGPXwfkeyBRZhXZbHzyUQSF.wzDSUWQnMveYROucQcUdhfFFKgPt).cNxUEanxejRMjCecvmNAihOJYYbs;
				}
			}

			public float pollingDeadZone
			{
				get
				{
					if (ReInput._id != OWoyNGGKhbJZoovYYhmnbrMuMSVv)
					{
						ReInput.CheckInitialized(OWoyNGGKhbJZoovYYhmnbrMuMSVv);
						return 0f;
					}
					if (RWCEZctGAZWeIhWIQMIAdNROmnEb == null)
					{
						return -1f;
					}
					return RWCEZctGAZWeIhWIQMIAdNROmnEb._pollingDeadZone;
				}
				set
				{
					if (ReInput._id != OWoyNGGKhbJZoovYYhmnbrMuMSVv)
					{
						ReInput.CheckInitialized(OWoyNGGKhbJZoovYYhmnbrMuMSVv);
						return;
					}
					if (value < 0f)
					{
						value = -1f;
					}
					if (RWCEZctGAZWeIhWIQMIAdNROmnEb != null)
					{
						RWCEZctGAZWeIhWIQMIAdNROmnEb._pollingDeadZone = value;
					}
				}
			}

			internal float dthTswLjMxJAtxammBlmcTFAIPdB => ((MqpfiMpTDeqQTwJTFWKzuAuEQHcK.HIzAawsnBWfiCgzFKfNQVUYgMFanA)TbAMdfGPXwfkeyBRZhXZbHzyUQSF.wzDSUWQnMveYROucQcUdhfFFKgPt).LWVtFNCoDUdsyeEGizwAihRKzRTG;

			internal float ubfxWnSegGfNJMzbumAuOJfUAhXM => ((MqpfiMpTDeqQTwJTFWKzuAuEQHcK.HIzAawsnBWfiCgzFKfNQVUYgMFanA)TbAMdfGPXwfkeyBRZhXZbHzyUQSF.wzDSUWQnMveYROucQcUdhfFFKgPt).zazbHhMJwneaQBYYTtFTUiwuaEaXA;

			internal float FKowYLDhIdlyIzPFQTgaXGyHryB
			{
				get
				{
					if (RWCEZctGAZWeIhWIQMIAdNROmnEb == null)
					{
						return ReInput.configuration.defaultAbsoluteAxisPollingDeadZone;
					}
					if (RWCEZctGAZWeIhWIQMIAdNROmnEb._pollingDeadZone >= 0f)
					{
						return RWCEZctGAZWeIhWIQMIAdNROmnEb._pollingDeadZone;
					}
					return RWCEZctGAZWeIhWIQMIAdNROmnEb._dataFormat switch
					{
						AxisCoordinateMode.Absolute => ReInput.configuration.defaultAbsoluteAxisPollingDeadZone, 
						AxisCoordinateMode.Relative => ReInput.configuration.defaultRelativeAxisPollingDeadZone, 
						_ => throw new NotImplementedException(), 
					};
				}
			}

			internal void mELtbmoXYRNauJErmNsauoJxarvc(float P_0)
			{
				MqpfiMpTDeqQTwJTFWKzuAuEQHcK.HIzAawsnBWfiCgzFKfNQVUYgMFanA obj = (MqpfiMpTDeqQTwJTFWKzuAuEQHcK.HIzAawsnBWfiCgzFKfNQVUYgMFanA)TbAMdfGPXwfkeyBRZhXZbHzyUQSF.wzDSUWQnMveYROucQcUdhfFFKgPt;
				obj.JQGOpcnYBErzTFgKlPmvLjTfZlvT = obj.aDVvohZPxEzGIwDiOPuifjbnFkvu;
				obj.aDVvohZPxEzGIwDiOPuifjbnFkvu = P_0;
			}

			internal Axis(Controller P_0, int P_1, string P_2, AxisRange P_3, HardwareAxisInfo P_4)
				: base(P_0, P_1, P_2, ControllerElementType.Axis)
			{
				TbAMdfGPXwfkeyBRZhXZbHzyUQSF = new MqpfiMpTDeqQTwJTFWKzuAuEQHcK(ReInput.configVars.updateLoop);
				SgxKpljiYUbKChIpZjYoXnjBsaRqA = P_3;
				RWCEZctGAZWeIhWIQMIAdNROmnEb = P_4;
			}

			internal void DXWGsffwrIFPYNzJjxpTxDPxPMGB(UpdateLoopType P_0)
			{
				if (TbAMdfGPXwfkeyBRZhXZbHzyUQSF != null && TbAMdfGPXwfkeyBRZhXZbHzyUQSF.TnSSVYQqjCcoFWTBcqZXObWymOVt != (int)P_0)
				{
					TbAMdfGPXwfkeyBRZhXZbHzyUQSF.DIjiSbLLXNKqIlzQvAlARMRMefLkA = P_0;
				}
			}

			internal void zIStigwsFbaNEocHKioHdRajpBFw(AxisCalibration P_0)
			{
				MqpfiMpTDeqQTwJTFWKzuAuEQHcK.HIzAawsnBWfiCgzFKfNQVUYgMFanA hIzAawsnBWfiCgzFKfNQVUYgMFanA = (MqpfiMpTDeqQTwJTFWKzuAuEQHcK.HIzAawsnBWfiCgzFKfNQVUYgMFanA)TbAMdfGPXwfkeyBRZhXZbHzyUQSF.wzDSUWQnMveYROucQcUdhfFFKgPt;
				hIzAawsnBWfiCgzFKfNQVUYgMFanA.zazbHhMJwneaQBYYTtFTUiwuaEaXA = hIzAawsnBWfiCgzFKfNQVUYgMFanA.LWVtFNCoDUdsyeEGizwAihRKzRTG;
				float lWVtFNCoDUdsyeEGizwAihRKzRTG = P_0.GetCalibratedValue(hIzAawsnBWfiCgzFKfNQVUYgMFanA.UcYxlgjAmgGPOjlbswUmCZFxHvdf, SgxKpljiYUbKChIpZjYoXnjBsaRqA);
				if (P_0.applyRangeCalibration)
				{
					lWVtFNCoDUdsyeEGizwAihRKzRTG = MathTools.Clamp(lWVtFNCoDUdsyeEGizwAihRKzRTG, -1f, 1f);
				}
				hIzAawsnBWfiCgzFKfNQVUYgMFanA.LWVtFNCoDUdsyeEGizwAihRKzRTG = lWVtFNCoDUdsyeEGizwAihRKzRTG;
			}

			internal void kqwlgmokkCqPWVJDnIPMCTfTlmorA()
			{
				MqpfiMpTDeqQTwJTFWKzuAuEQHcK.HIzAawsnBWfiCgzFKfNQVUYgMFanA obj = (MqpfiMpTDeqQTwJTFWKzuAuEQHcK.HIzAawsnBWfiCgzFKfNQVUYgMFanA)TbAMdfGPXwfkeyBRZhXZbHzyUQSF.wzDSUWQnMveYROucQcUdhfFFKgPt;
				obj.zazbHhMJwneaQBYYTtFTUiwuaEaXA = obj.LWVtFNCoDUdsyeEGizwAihRKzRTG;
				obj.LWVtFNCoDUdsyeEGizwAihRKzRTG = obj.UcYxlgjAmgGPOjlbswUmCZFxHvdf;
			}

			internal void oJuTJvOHDwPaiYTGzqihiDrZsoPC()
			{
				MqpfiMpTDeqQTwJTFWKzuAuEQHcK.HIzAawsnBWfiCgzFKfNQVUYgMFanA obj = (MqpfiMpTDeqQTwJTFWKzuAuEQHcK.HIzAawsnBWfiCgzFKfNQVUYgMFanA)TbAMdfGPXwfkeyBRZhXZbHzyUQSF.wzDSUWQnMveYROucQcUdhfFFKgPt;
				obj.zazbHhMJwneaQBYYTtFTUiwuaEaXA = obj.LWVtFNCoDUdsyeEGizwAihRKzRTG;
				obj.LWVtFNCoDUdsyeEGizwAihRKzRTG = 0f;
			}

			internal void DWQTQLJxgrEbVCDkTrWnsdCPdoIh()
			{
				((MqpfiMpTDeqQTwJTFWKzuAuEQHcK.HIzAawsnBWfiCgzFKfNQVUYgMFanA)TbAMdfGPXwfkeyBRZhXZbHzyUQSF.wzDSUWQnMveYROucQcUdhfFFKgPt).cPwtRQteBOBmlalHIdXnGfAHlnOI(base.isMemberElement);
			}

			internal void uLNqjsDoVoqJrOMiXYfCethQhLSB(float P_0)
			{
				for (int i = 0; i < TbAMdfGPXwfkeyBRZhXZbHzyUQSF.KnnRTPAahlBjqQemncCRjsvhVputA.Count; i++)
				{
					if (TbAMdfGPXwfkeyBRZhXZbHzyUQSF.KnnRTPAahlBjqQemncCRjsvhVputA[i] is MqpfiMpTDeqQTwJTFWKzuAuEQHcK.HIzAawsnBWfiCgzFKfNQVUYgMFanA hIzAawsnBWfiCgzFKfNQVUYgMFanA)
					{
						hIzAawsnBWfiCgzFKfNQVUYgMFanA.OZiPdReWNrTAIEjBtEQVHMEdYXLKA(P_0);
						hIzAawsnBWfiCgzFKfNQVUYgMFanA.zazbHhMJwneaQBYYTtFTUiwuaEaXA = hIzAawsnBWfiCgzFKfNQVUYgMFanA.LWVtFNCoDUdsyeEGizwAihRKzRTG;
						hIzAawsnBWfiCgzFKfNQVUYgMFanA.LWVtFNCoDUdsyeEGizwAihRKzRTG = 0f;
						hIzAawsnBWfiCgzFKfNQVUYgMFanA.cPwtRQteBOBmlalHIdXnGfAHlnOI(base.isMemberElement);
					}
				}
			}

			internal float aDLkkJkwSxfWbsWZKOtiooHnuwMk(UpdateLoopType P_0, AxisCalibration P_1)
			{
				MqpfiMpTDeqQTwJTFWKzuAuEQHcK.HIzAawsnBWfiCgzFKfNQVUYgMFanA hIzAawsnBWfiCgzFKfNQVUYgMFanA = (MqpfiMpTDeqQTwJTFWKzuAuEQHcK.HIzAawsnBWfiCgzFKfNQVUYgMFanA)TbAMdfGPXwfkeyBRZhXZbHzyUQSF.jqPXJCprbWgQPxmQEkoHGiONSDqi(P_0);
				float result = P_1.GetCalibratedValue(hIzAawsnBWfiCgzFKfNQVUYgMFanA.UcYxlgjAmgGPOjlbswUmCZFxHvdf, SgxKpljiYUbKChIpZjYoXnjBsaRqA, P_1.deadZone, applySensitivity: false, applyInversion: true);
				if (P_1.applyRangeCalibration)
				{
					result = MathTools.Clamp(result, -1f, 1f);
				}
				return result;
			}
		}

		public sealed class Button : Element
		{
			internal class ZtcDaGDVHyhemYGVxsWRTerFXecmA : RxzeFFlTCoMdFwHqjGqGjxOuTuFM
			{
				public class pVCMtpcpRKAHCFdgAMmsMICEKbsCb : MKurlxCibRDyKALjzbzOANkCCkCjc
				{
					public bool AGiuvDDmpiWGJPvTFgcKXpwajAKp;

					public bool XeskPExhwbwbaFqopqtSJGeQvFMk;

					public ButtonStateRecorder gaoeiRenwtVnBrQWGAIdBppREkxw;

					public AeKAHRjpFZcKHbbZgbogQRhDYYGXA TfibQlESUpqdzcALdRjXfQGohYksA;

					public pVCMtpcpRKAHCFdgAMmsMICEKbsCb()
					{
						gaoeiRenwtVnBrQWGAIdBppREkxw = new ButtonStateRecorder();
						TfibQlESUpqdzcALdRjXfQGohYksA = new AeKAHRjpFZcKHbbZgbogQRhDYYGXA(0.3f);
					}

					public void naFAxmgWsnuwfGJLsBvEsYoxDnOpA(bool P_0)
					{
						if (XeskPExhwbwbaFqopqtSJGeQvFMk != AGiuvDDmpiWGJPvTFgcKXpwajAKp)
						{
							XeskPExhwbwbaFqopqtSJGeQvFMk = AGiuvDDmpiWGJPvTFgcKXpwajAKp;
						}
						if (AGiuvDDmpiWGJPvTFgcKXpwajAKp != P_0)
						{
							AGiuvDDmpiWGJPvTFgcKXpwajAKp = P_0;
						}
						gaoeiRenwtVnBrQWGAIdBppREkxw.oCrhuwbfCNEPOUPLgOVrJKRjpQQZ(P_0 && !XeskPExhwbwbaFqopqtSJGeQvFMk, P_0, ReInput.unscaledTime);
						TfibQlESUpqdzcALdRjXfQGohYksA.YOSCAjjsgbjFfHffsmcTnAQVFRqd(0.3f, P_0 && !XeskPExhwbwbaFqopqtSJGeQvFMk, P_0);
					}

					public virtual void cVbLlvCadvblvIraGbVWmJGroLDMA()
					{
						AGiuvDDmpiWGJPvTFgcKXpwajAKp = false;
						XeskPExhwbwbaFqopqtSJGeQvFMk = false;
						gaoeiRenwtVnBrQWGAIdBppREkxw.WuFDqzVbQtGYbUeKujIZpZzOfnqe();
						TfibQlESUpqdzcALdRjXfQGohYksA.dBCbrhNwPXecQPGFDLsEDRRSYZWI();
					}
				}

				public class eVJHaFwBKaAhTDnZrJyNoDqXwkNqA : pVCMtpcpRKAHCFdgAMmsMICEKbsCb
				{
					public float kmOoMWzEWNCdXNrJrCgCItaPxDsy;

					public float SWjbtQdkzKCqBjTWAoBbHpTEErGzA;

					public void wJpDbmgkPRvscWokoWHTGHRqVwIE(float P_0)
					{
						if (SWjbtQdkzKCqBjTWAoBbHpTEErGzA != kmOoMWzEWNCdXNrJrCgCItaPxDsy)
						{
							SWjbtQdkzKCqBjTWAoBbHpTEErGzA = kmOoMWzEWNCdXNrJrCgCItaPxDsy;
						}
						if (kmOoMWzEWNCdXNrJrCgCItaPxDsy != P_0)
						{
							kmOoMWzEWNCdXNrJrCgCItaPxDsy = ((P_0 > 0.001f) ? P_0 : 0f);
						}
						naFAxmgWsnuwfGJLsBvEsYoxDnOpA(kmOoMWzEWNCdXNrJrCgCItaPxDsy > 0f);
					}

					public virtual void qoNNZOgTyOiLCdBoqhbITjWtmWaL()
					{
						cVbLlvCadvblvIraGbVWmJGroLDMA();
						kmOoMWzEWNCdXNrJrCgCItaPxDsy = 0f;
						SWjbtQdkzKCqBjTWAoBbHpTEErGzA = 0f;
					}
				}

				public ZtcDaGDVHyhemYGVxsWRTerFXecmA(UpdateLoopSetting P_0, bool P_1)
					: base(P_0)
				{
					for (int i = 0; i < qmvYFvvbYjrSKRmZLRNkGYNGCOKV; i++)
					{
						if (P_1)
						{
							sfRIDnyZWJFdGjEMVCQoFFMvkEaP[i] = new eVJHaFwBKaAhTDnZrJyNoDqXwkNqA();
						}
						else
						{
							sfRIDnyZWJFdGjEMVCQoFFMvkEaP[i] = new pVCMtpcpRKAHCFdgAMmsMICEKbsCb();
						}
					}
					wzDSUWQnMveYROucQcUdhfFFKgPt = sfRIDnyZWJFdGjEMVCQoFFMvkEaP[0];
				}

				public void zDVCTRyHhwOufscUXTOarSAuTAMD(float P_0)
				{
					for (int i = 0; i < sfRIDnyZWJFdGjEMVCQoFFMvkEaP.Length; i++)
					{
						((pVCMtpcpRKAHCFdgAMmsMICEKbsCb)sfRIDnyZWJFdGjEMVCQoFFMvkEaP[i]).TfibQlESUpqdzcALdRjXfQGohYksA.iockSoGYlFhRvfLVpJeRJLUJpDuk(P_0);
					}
				}

				public void CRnDFoADRABeuRsdPCBADDPWbriHA()
				{
					for (int i = 0; i < sfRIDnyZWJFdGjEMVCQoFFMvkEaP.Length; i++)
					{
						((pVCMtpcpRKAHCFdgAMmsMICEKbsCb)sfRIDnyZWJFdGjEMVCQoFFMvkEaP[i]).TfibQlESUpqdzcALdRjXfQGohYksA.iockSoGYlFhRvfLVpJeRJLUJpDuk(0.3f);
					}
				}
			}

			internal readonly bool IzBFOXGqxeEFgMpeXZIseJwtFPFcb;

			internal readonly HardwareButtonInfo LZwxGokBTpAKOeMxByhqDlrLgFAT;

			public bool valuePrev
			{
				get
				{
					if (ReInput._id != OWoyNGGKhbJZoovYYhmnbrMuMSVv)
					{
						ReInput.CheckInitialized(OWoyNGGKhbJZoovYYhmnbrMuMSVv);
						return false;
					}
					return ((ZtcDaGDVHyhemYGVxsWRTerFXecmA.pVCMtpcpRKAHCFdgAMmsMICEKbsCb)TbAMdfGPXwfkeyBRZhXZbHzyUQSF.wzDSUWQnMveYROucQcUdhfFFKgPt).XeskPExhwbwbaFqopqtSJGeQvFMk;
				}
			}

			public bool value
			{
				get
				{
					if (ReInput._id != OWoyNGGKhbJZoovYYhmnbrMuMSVv)
					{
						ReInput.CheckInitialized(OWoyNGGKhbJZoovYYhmnbrMuMSVv);
						return false;
					}
					return ((ZtcDaGDVHyhemYGVxsWRTerFXecmA.pVCMtpcpRKAHCFdgAMmsMICEKbsCb)TbAMdfGPXwfkeyBRZhXZbHzyUQSF.wzDSUWQnMveYROucQcUdhfFFKgPt).AGiuvDDmpiWGJPvTFgcKXpwajAKp;
				}
			}

			public float pressure
			{
				get
				{
					if (ReInput._id != OWoyNGGKhbJZoovYYhmnbrMuMSVv)
					{
						ReInput.CheckInitialized(OWoyNGGKhbJZoovYYhmnbrMuMSVv);
						return 0f;
					}
					if (!IzBFOXGqxeEFgMpeXZIseJwtFPFcb)
					{
						if (!((ZtcDaGDVHyhemYGVxsWRTerFXecmA.pVCMtpcpRKAHCFdgAMmsMICEKbsCb)TbAMdfGPXwfkeyBRZhXZbHzyUQSF.wzDSUWQnMveYROucQcUdhfFFKgPt).AGiuvDDmpiWGJPvTFgcKXpwajAKp)
						{
							return 0f;
						}
						return 1f;
					}
					return ((ZtcDaGDVHyhemYGVxsWRTerFXecmA.eVJHaFwBKaAhTDnZrJyNoDqXwkNqA)TbAMdfGPXwfkeyBRZhXZbHzyUQSF.wzDSUWQnMveYROucQcUdhfFFKgPt).kmOoMWzEWNCdXNrJrCgCItaPxDsy;
				}
			}

			public float pressurePrev
			{
				get
				{
					if (ReInput._id != OWoyNGGKhbJZoovYYhmnbrMuMSVv)
					{
						ReInput.CheckInitialized(OWoyNGGKhbJZoovYYhmnbrMuMSVv);
						return 0f;
					}
					if (!IzBFOXGqxeEFgMpeXZIseJwtFPFcb)
					{
						if (!((ZtcDaGDVHyhemYGVxsWRTerFXecmA.pVCMtpcpRKAHCFdgAMmsMICEKbsCb)TbAMdfGPXwfkeyBRZhXZbHzyUQSF.wzDSUWQnMveYROucQcUdhfFFKgPt).XeskPExhwbwbaFqopqtSJGeQvFMk)
						{
							return 0f;
						}
						return 1f;
					}
					return ((ZtcDaGDVHyhemYGVxsWRTerFXecmA.eVJHaFwBKaAhTDnZrJyNoDqXwkNqA)TbAMdfGPXwfkeyBRZhXZbHzyUQSF.wzDSUWQnMveYROucQcUdhfFFKgPt).SWjbtQdkzKCqBjTWAoBbHpTEErGzA;
				}
			}

			public bool isPressureSensitive
			{
				get
				{
					if (ReInput._id != OWoyNGGKhbJZoovYYhmnbrMuMSVv)
					{
						ReInput.CheckInitialized(OWoyNGGKhbJZoovYYhmnbrMuMSVv);
						return false;
					}
					return IzBFOXGqxeEFgMpeXZIseJwtFPFcb;
				}
			}

			public bool justPressed
			{
				get
				{
					if (ReInput._id != OWoyNGGKhbJZoovYYhmnbrMuMSVv)
					{
						ReInput.CheckInitialized(OWoyNGGKhbJZoovYYhmnbrMuMSVv);
						return false;
					}
					if (!((ZtcDaGDVHyhemYGVxsWRTerFXecmA.pVCMtpcpRKAHCFdgAMmsMICEKbsCb)TbAMdfGPXwfkeyBRZhXZbHzyUQSF.wzDSUWQnMveYROucQcUdhfFFKgPt).XeskPExhwbwbaFqopqtSJGeQvFMk && ((ZtcDaGDVHyhemYGVxsWRTerFXecmA.pVCMtpcpRKAHCFdgAMmsMICEKbsCb)TbAMdfGPXwfkeyBRZhXZbHzyUQSF.wzDSUWQnMveYROucQcUdhfFFKgPt).AGiuvDDmpiWGJPvTFgcKXpwajAKp)
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
					if (ReInput._id != OWoyNGGKhbJZoovYYhmnbrMuMSVv)
					{
						ReInput.CheckInitialized(OWoyNGGKhbJZoovYYhmnbrMuMSVv);
						return false;
					}
					if (((ZtcDaGDVHyhemYGVxsWRTerFXecmA.pVCMtpcpRKAHCFdgAMmsMICEKbsCb)TbAMdfGPXwfkeyBRZhXZbHzyUQSF.wzDSUWQnMveYROucQcUdhfFFKgPt).XeskPExhwbwbaFqopqtSJGeQvFMk && !((ZtcDaGDVHyhemYGVxsWRTerFXecmA.pVCMtpcpRKAHCFdgAMmsMICEKbsCb)TbAMdfGPXwfkeyBRZhXZbHzyUQSF.wzDSUWQnMveYROucQcUdhfFFKgPt).AGiuvDDmpiWGJPvTFgcKXpwajAKp)
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
					if (ReInput._id != OWoyNGGKhbJZoovYYhmnbrMuMSVv)
					{
						ReInput.CheckInitialized(OWoyNGGKhbJZoovYYhmnbrMuMSVv);
						return false;
					}
					if (((ZtcDaGDVHyhemYGVxsWRTerFXecmA.pVCMtpcpRKAHCFdgAMmsMICEKbsCb)TbAMdfGPXwfkeyBRZhXZbHzyUQSF.wzDSUWQnMveYROucQcUdhfFFKgPt).XeskPExhwbwbaFqopqtSJGeQvFMk != ((ZtcDaGDVHyhemYGVxsWRTerFXecmA.pVCMtpcpRKAHCFdgAMmsMICEKbsCb)TbAMdfGPXwfkeyBRZhXZbHzyUQSF.wzDSUWQnMveYROucQcUdhfFFKgPt).AGiuvDDmpiWGJPvTFgcKXpwajAKp)
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
					if (ReInput._id != OWoyNGGKhbJZoovYYhmnbrMuMSVv)
					{
						ReInput.CheckInitialized(OWoyNGGKhbJZoovYYhmnbrMuMSVv);
						return false;
					}
					return ((ZtcDaGDVHyhemYGVxsWRTerFXecmA.pVCMtpcpRKAHCFdgAMmsMICEKbsCb)TbAMdfGPXwfkeyBRZhXZbHzyUQSF.wzDSUWQnMveYROucQcUdhfFFKgPt).TfibQlESUpqdzcALdRjXfQGohYksA.FunqNVSEZILlSadVjqwuROmPUfxI;
				}
			}

			public bool justDoublePressed
			{
				get
				{
					if (ReInput._id != OWoyNGGKhbJZoovYYhmnbrMuMSVv)
					{
						ReInput.CheckInitialized(OWoyNGGKhbJZoovYYhmnbrMuMSVv);
						return false;
					}
					if (!justPressed)
					{
						return false;
					}
					return ((ZtcDaGDVHyhemYGVxsWRTerFXecmA.pVCMtpcpRKAHCFdgAMmsMICEKbsCb)TbAMdfGPXwfkeyBRZhXZbHzyUQSF.wzDSUWQnMveYROucQcUdhfFFKgPt).TfibQlESUpqdzcALdRjXfQGohYksA.FunqNVSEZILlSadVjqwuROmPUfxI;
				}
			}

			public double timePressed
			{
				get
				{
					if (ReInput._id != OWoyNGGKhbJZoovYYhmnbrMuMSVv)
					{
						ReInput.CheckInitialized(OWoyNGGKhbJZoovYYhmnbrMuMSVv);
						return 0.0;
					}
					return ((ZtcDaGDVHyhemYGVxsWRTerFXecmA.pVCMtpcpRKAHCFdgAMmsMICEKbsCb)TbAMdfGPXwfkeyBRZhXZbHzyUQSF.wzDSUWQnMveYROucQcUdhfFFKgPt).gaoeiRenwtVnBrQWGAIdBppREkxw.APzzWKAGoKXnioyipQaIaVUzRXnI;
				}
			}

			public double timeUnpressed
			{
				get
				{
					if (ReInput._id != OWoyNGGKhbJZoovYYhmnbrMuMSVv)
					{
						ReInput.CheckInitialized(OWoyNGGKhbJZoovYYhmnbrMuMSVv);
						return 0.0;
					}
					return ((ZtcDaGDVHyhemYGVxsWRTerFXecmA.pVCMtpcpRKAHCFdgAMmsMICEKbsCb)TbAMdfGPXwfkeyBRZhXZbHzyUQSF.wzDSUWQnMveYROucQcUdhfFFKgPt).gaoeiRenwtVnBrQWGAIdBppREkxw.udbkFnDjPUcRvIedMxOYquHsmhYfA;
				}
			}

			public double lastTimePressed
			{
				get
				{
					if (ReInput._id != OWoyNGGKhbJZoovYYhmnbrMuMSVv)
					{
						ReInput.CheckInitialized(OWoyNGGKhbJZoovYYhmnbrMuMSVv);
						return 0.0;
					}
					return ((ZtcDaGDVHyhemYGVxsWRTerFXecmA.pVCMtpcpRKAHCFdgAMmsMICEKbsCb)TbAMdfGPXwfkeyBRZhXZbHzyUQSF.wzDSUWQnMveYROucQcUdhfFFKgPt).gaoeiRenwtVnBrQWGAIdBppREkxw.cKLSgWrcLphFQHeFGFRQQyhXuKGW;
				}
			}

			public double lastTimeUnpressed
			{
				get
				{
					if (ReInput._id != OWoyNGGKhbJZoovYYhmnbrMuMSVv)
					{
						ReInput.CheckInitialized(OWoyNGGKhbJZoovYYhmnbrMuMSVv);
						return 0.0;
					}
					return ((ZtcDaGDVHyhemYGVxsWRTerFXecmA.pVCMtpcpRKAHCFdgAMmsMICEKbsCb)TbAMdfGPXwfkeyBRZhXZbHzyUQSF.wzDSUWQnMveYROucQcUdhfFFKgPt).gaoeiRenwtVnBrQWGAIdBppREkxw.aIGgEoTPJogXdaNSMtHNgQjtkcBcb;
				}
			}

			public double lastTimeStateChanged
			{
				get
				{
					if (ReInput._id != OWoyNGGKhbJZoovYYhmnbrMuMSVv)
					{
						ReInput.CheckInitialized(OWoyNGGKhbJZoovYYhmnbrMuMSVv);
						return 0.0;
					}
					return ((ZtcDaGDVHyhemYGVxsWRTerFXecmA.pVCMtpcpRKAHCFdgAMmsMICEKbsCb)TbAMdfGPXwfkeyBRZhXZbHzyUQSF.wzDSUWQnMveYROucQcUdhfFFKgPt).gaoeiRenwtVnBrQWGAIdBppREkxw.sGPaBWkClDcXsjAFazknDdPDcbpDA;
				}
			}

			internal ButtonStateFlags hWLgceOZYAqniGkWwHdjVfDFLFhM
			{
				get
				{
					ZtcDaGDVHyhemYGVxsWRTerFXecmA.pVCMtpcpRKAHCFdgAMmsMICEKbsCb pVCMtpcpRKAHCFdgAMmsMICEKbsCb = (ZtcDaGDVHyhemYGVxsWRTerFXecmA.pVCMtpcpRKAHCFdgAMmsMICEKbsCb)TbAMdfGPXwfkeyBRZhXZbHzyUQSF.wzDSUWQnMveYROucQcUdhfFFKgPt;
					ButtonStateFlags buttonStateFlags = ButtonStateFlags.Off;
					if (pVCMtpcpRKAHCFdgAMmsMICEKbsCb.AGiuvDDmpiWGJPvTFgcKXpwajAKp)
					{
						buttonStateFlags |= ButtonStateFlags.On;
						if (!pVCMtpcpRKAHCFdgAMmsMICEKbsCb.XeskPExhwbwbaFqopqtSJGeQvFMk)
						{
							buttonStateFlags |= ButtonStateFlags.Down;
						}
					}
					else if (pVCMtpcpRKAHCFdgAMmsMICEKbsCb.XeskPExhwbwbaFqopqtSJGeQvFMk)
					{
						buttonStateFlags |= ButtonStateFlags.Up;
					}
					return buttonStateFlags;
				}
			}

			internal Button(Controller P_0, int P_1, string P_2, HardwareButtonInfo P_3)
				: base(P_0, P_1, P_2, ControllerElementType.Button)
			{
				LZwxGokBTpAKOeMxByhqDlrLgFAT = P_3;
				TbAMdfGPXwfkeyBRZhXZbHzyUQSF = new ZtcDaGDVHyhemYGVxsWRTerFXecmA(ReInput.configVars.updateLoop, false);
			}

			internal Button(Controller P_0, int P_1, string P_2, bool P_3, HardwareButtonInfo P_4)
				: base(P_0, P_1, P_2, ControllerElementType.Button)
			{
				LZwxGokBTpAKOeMxByhqDlrLgFAT = P_4;
				IzBFOXGqxeEFgMpeXZIseJwtFPFcb = P_3;
				TbAMdfGPXwfkeyBRZhXZbHzyUQSF = new ZtcDaGDVHyhemYGVxsWRTerFXecmA(ReInput.configVars.updateLoop, P_3);
			}

			public bool DoublePressedAndHeld(float speed)
			{
				if (ReInput._id != OWoyNGGKhbJZoovYYhmnbrMuMSVv)
				{
					ReInput.CheckInitialized(OWoyNGGKhbJZoovYYhmnbrMuMSVv);
					return false;
				}
				if (speed <= 0f)
				{
					return ((ZtcDaGDVHyhemYGVxsWRTerFXecmA.pVCMtpcpRKAHCFdgAMmsMICEKbsCb)TbAMdfGPXwfkeyBRZhXZbHzyUQSF.wzDSUWQnMveYROucQcUdhfFFKgPt).TfibQlESUpqdzcALdRjXfQGohYksA.FunqNVSEZILlSadVjqwuROmPUfxI;
				}
				return ((ZtcDaGDVHyhemYGVxsWRTerFXecmA.pVCMtpcpRKAHCFdgAMmsMICEKbsCb)TbAMdfGPXwfkeyBRZhXZbHzyUQSF.wzDSUWQnMveYROucQcUdhfFFKgPt).gaoeiRenwtVnBrQWGAIdBppREkxw.VqbaJceznixEMPEJCYNzTFJDvDsk(speed);
			}

			public bool JustDoublePressed(float speed)
			{
				if (ReInput._id != OWoyNGGKhbJZoovYYhmnbrMuMSVv)
				{
					ReInput.CheckInitialized(OWoyNGGKhbJZoovYYhmnbrMuMSVv);
					return false;
				}
				if (!justPressed)
				{
					return false;
				}
				if (speed <= 0f)
				{
					return ((ZtcDaGDVHyhemYGVxsWRTerFXecmA.pVCMtpcpRKAHCFdgAMmsMICEKbsCb)TbAMdfGPXwfkeyBRZhXZbHzyUQSF.wzDSUWQnMveYROucQcUdhfFFKgPt).TfibQlESUpqdzcALdRjXfQGohYksA.FunqNVSEZILlSadVjqwuROmPUfxI;
				}
				return ((ZtcDaGDVHyhemYGVxsWRTerFXecmA.pVCMtpcpRKAHCFdgAMmsMICEKbsCb)TbAMdfGPXwfkeyBRZhXZbHzyUQSF.wzDSUWQnMveYROucQcUdhfFFKgPt).gaoeiRenwtVnBrQWGAIdBppREkxw.VqbaJceznixEMPEJCYNzTFJDvDsk(speed);
			}

			internal void KknekHfCfaOAyFWPFHiholZwGQJTA(UpdateLoopType P_0, int P_1, ControllerDataUpdater P_2)
			{
				if (TbAMdfGPXwfkeyBRZhXZbHzyUQSF != null && TbAMdfGPXwfkeyBRZhXZbHzyUQSF.TnSSVYQqjCcoFWTBcqZXObWymOVt != (int)P_0)
				{
					TbAMdfGPXwfkeyBRZhXZbHzyUQSF.DIjiSbLLXNKqIlzQvAlARMRMefLkA = P_0;
				}
				if (IzBFOXGqxeEFgMpeXZIseJwtFPFcb)
				{
					((ZtcDaGDVHyhemYGVxsWRTerFXecmA.eVJHaFwBKaAhTDnZrJyNoDqXwkNqA)TbAMdfGPXwfkeyBRZhXZbHzyUQSF.wzDSUWQnMveYROucQcUdhfFFKgPt).wJpDbmgkPRvscWokoWHTGHRqVwIE(P_2.buttonPressureValues[P_1]);
				}
				else
				{
					((ZtcDaGDVHyhemYGVxsWRTerFXecmA.pVCMtpcpRKAHCFdgAMmsMICEKbsCb)TbAMdfGPXwfkeyBRZhXZbHzyUQSF.wzDSUWQnMveYROucQcUdhfFFKgPt).naFAxmgWsnuwfGJLsBvEsYoxDnOpA(P_2.buttonValues[P_1]);
				}
			}

			internal void mbnOyrGHVsSuNaqSwjQihtXfduxb(UpdateLoopType P_0)
			{
				if (TbAMdfGPXwfkeyBRZhXZbHzyUQSF != null && TbAMdfGPXwfkeyBRZhXZbHzyUQSF.TnSSVYQqjCcoFWTBcqZXObWymOVt != (int)P_0)
				{
					TbAMdfGPXwfkeyBRZhXZbHzyUQSF.DIjiSbLLXNKqIlzQvAlARMRMefLkA = P_0;
				}
				if (IzBFOXGqxeEFgMpeXZIseJwtFPFcb)
				{
					((ZtcDaGDVHyhemYGVxsWRTerFXecmA.eVJHaFwBKaAhTDnZrJyNoDqXwkNqA)TbAMdfGPXwfkeyBRZhXZbHzyUQSF.wzDSUWQnMveYROucQcUdhfFFKgPt).wJpDbmgkPRvscWokoWHTGHRqVwIE(0f);
				}
				else
				{
					((ZtcDaGDVHyhemYGVxsWRTerFXecmA.pVCMtpcpRKAHCFdgAMmsMICEKbsCb)TbAMdfGPXwfkeyBRZhXZbHzyUQSF.wzDSUWQnMveYROucQcUdhfFFKgPt).naFAxmgWsnuwfGJLsBvEsYoxDnOpA(false);
				}
			}

			internal void mqkdUoGItMwcvtxGEJivNxylXxOf()
			{
				for (int i = 0; i < TbAMdfGPXwfkeyBRZhXZbHzyUQSF.KnnRTPAahlBjqQemncCRjsvhVputA.Count; i++)
				{
					RxzeFFlTCoMdFwHqjGqGjxOuTuFM.MKurlxCibRDyKALjzbzOANkCCkCjc mKurlxCibRDyKALjzbzOANkCCkCjc = TbAMdfGPXwfkeyBRZhXZbHzyUQSF.KnnRTPAahlBjqQemncCRjsvhVputA[i];
					if (mKurlxCibRDyKALjzbzOANkCCkCjc != null)
					{
						if (IzBFOXGqxeEFgMpeXZIseJwtFPFcb)
						{
							((ZtcDaGDVHyhemYGVxsWRTerFXecmA.eVJHaFwBKaAhTDnZrJyNoDqXwkNqA)mKurlxCibRDyKALjzbzOANkCCkCjc).wJpDbmgkPRvscWokoWHTGHRqVwIE(0f);
						}
						else
						{
							((ZtcDaGDVHyhemYGVxsWRTerFXecmA.pVCMtpcpRKAHCFdgAMmsMICEKbsCb)mKurlxCibRDyKALjzbzOANkCCkCjc).naFAxmgWsnuwfGJLsBvEsYoxDnOpA(false);
						}
					}
				}
			}
		}

		public abstract class CompoundElement
		{
			private class YTZZFUGREZbBrjsqZmWUfksumdqP
			{
				public readonly Element KOyEJYwNeUSsHoUcqXoDWcABjNuD;

				public readonly int tXYODnOlDxMPEwPbjpRdCzUzhVrl;

				public YTZZFUGREZbBrjsqZmWUfksumdqP(Element P_0, int P_1)
				{
					KOyEJYwNeUSsHoUcqXoDWcABjNuD = P_0;
					tXYODnOlDxMPEwPbjpRdCzUzhVrl = P_1;
				}
			}

			private int UbecFdTMHMaTAicMBknCiSKRNPsFA;

			private string GOxgpsiFWTzHQHQrjaSjFDqjFAimA;

			private CompoundControllerElementType GzCYqLeNWMAluqvNxrlaXiPfcqPf;

			private int LvMzrlAMMhSTcTWjVdZTofQcevHp;

			private YTZZFUGREZbBrjsqZmWUfksumdqP[] jFkRlNQYeNiJiBwzbDewNbEoDsceA;

			private Controller rLeFdjGXfWFDFDrugBxlgRjmLDUgb;

			internal readonly int VaeVfOLUBZwxUAILYAidjkxjCCwv;

			public int id
			{
				get
				{
					if (ReInput._id != VaeVfOLUBZwxUAILYAidjkxjCCwv)
					{
						ReInput.CheckInitialized(VaeVfOLUBZwxUAILYAidjkxjCCwv);
						return -1;
					}
					return UbecFdTMHMaTAicMBknCiSKRNPsFA;
				}
			}

			public string name
			{
				get
				{
					if (ReInput._id != VaeVfOLUBZwxUAILYAidjkxjCCwv)
					{
						ReInput.CheckInitialized(VaeVfOLUBZwxUAILYAidjkxjCCwv);
						return string.Empty;
					}
					return GOxgpsiFWTzHQHQrjaSjFDqjFAimA;
				}
			}

			public CompoundControllerElementType type
			{
				get
				{
					if (ReInput._id != VaeVfOLUBZwxUAILYAidjkxjCCwv)
					{
						ReInput.CheckInitialized(VaeVfOLUBZwxUAILYAidjkxjCCwv);
						return CompoundControllerElementType.Axis2D;
					}
					return GzCYqLeNWMAluqvNxrlaXiPfcqPf;
				}
			}

			public bool hasElements
			{
				get
				{
					if (ReInput._id != VaeVfOLUBZwxUAILYAidjkxjCCwv)
					{
						ReInput.CheckInitialized(VaeVfOLUBZwxUAILYAidjkxjCCwv);
						return false;
					}
					return LvMzrlAMMhSTcTWjVdZTofQcevHp > 0;
				}
			}

			public int elementCount
			{
				get
				{
					if (ReInput._id != VaeVfOLUBZwxUAILYAidjkxjCCwv)
					{
						ReInput.CheckInitialized(VaeVfOLUBZwxUAILYAidjkxjCCwv);
						return 0;
					}
					return LvMzrlAMMhSTcTWjVdZTofQcevHp;
				}
			}

			public abstract int elementCapacity { get; }

			public ControllerElementIdentifier elementIdentifier
			{
				get
				{
					if (ReInput._id != VaeVfOLUBZwxUAILYAidjkxjCCwv)
					{
						ReInput.CheckInitialized(VaeVfOLUBZwxUAILYAidjkxjCCwv);
						return null;
					}
					ControllerElementIdentifier elementIdentifierById = rLeFdjGXfWFDFDrugBxlgRjmLDUgb.GetElementIdentifierById(UbecFdTMHMaTAicMBknCiSKRNPsFA);
					if (elementIdentifierById == null)
					{
						return ControllerElementIdentifier.BlankReadOnly;
					}
					return elementIdentifierById;
				}
			}

			internal CompoundElement(Controller P_0, int P_1, string P_2, CompoundControllerElementType P_3)
			{
				rLeFdjGXfWFDFDrugBxlgRjmLDUgb = P_0;
				UbecFdTMHMaTAicMBknCiSKRNPsFA = P_1;
				GOxgpsiFWTzHQHQrjaSjFDqjFAimA = P_2;
				GzCYqLeNWMAluqvNxrlaXiPfcqPf = P_3;
				jFkRlNQYeNiJiBwzbDewNbEoDsceA = new YTZZFUGREZbBrjsqZmWUfksumdqP[elementCapacity];
				VaeVfOLUBZwxUAILYAidjkxjCCwv = ReInput.id;
			}

			internal Element HcjtostkCLkJzotAouatnCttoUrg(int P_0)
			{
				if (P_0 < 0 || P_0 >= jFkRlNQYeNiJiBwzbDewNbEoDsceA.Length)
				{
					return null;
				}
				if (jFkRlNQYeNiJiBwzbDewNbEoDsceA[P_0] == null)
				{
					return null;
				}
				return jFkRlNQYeNiJiBwzbDewNbEoDsceA[P_0].KOyEJYwNeUSsHoUcqXoDWcABjNuD;
			}

			internal _0001 HcjtostkCLkJzotAouatnCttoUrg<_0001>(int P_0) where _0001 : Element
			{
				if (P_0 < 0 || P_0 >= jFkRlNQYeNiJiBwzbDewNbEoDsceA.Length)
				{
					return null;
				}
				if (jFkRlNQYeNiJiBwzbDewNbEoDsceA[P_0] == null)
				{
					return null;
				}
				return jFkRlNQYeNiJiBwzbDewNbEoDsceA[P_0].KOyEJYwNeUSsHoUcqXoDWcABjNuD as _0001;
			}

			internal _0001 EXIwZQRRuoJzWwhjnblvkkKFQitR<_0001>(int P_0, out int P_1) where _0001 : Element
			{
				P_1 = -1;
				if (P_0 < 0 || P_0 >= jFkRlNQYeNiJiBwzbDewNbEoDsceA.Length)
				{
					return null;
				}
				if (jFkRlNQYeNiJiBwzbDewNbEoDsceA[P_0] == null)
				{
					return null;
				}
				P_1 = jFkRlNQYeNiJiBwzbDewNbEoDsceA[P_0].tXYODnOlDxMPEwPbjpRdCzUzhVrl;
				return jFkRlNQYeNiJiBwzbDewNbEoDsceA[P_0].KOyEJYwNeUSsHoUcqXoDWcABjNuD as _0001;
			}

			internal bool kYjGoZyIKXlKFPeEgXxekEtboTnJ(Element P_0, int P_1)
			{
				if (P_0 == null)
				{
					return false;
				}
				if (LvMzrlAMMhSTcTWjVdZTofQcevHp >= elementCapacity)
				{
					Logger.LogWarning("Cannot add element! This Compound Element already contains the maximum number of elements.");
					return false;
				}
				if (P_0.isMemberElement)
				{
					Logger.LogWarning("Cannot add element! The element you are trying to add is already a member of another compound element.");
					return false;
				}
				if (KwDXgRpabGhmUeMoIgSVjztYJJydA(P_0) >= 0)
				{
					Logger.LogWarning("Cannot add element! This Compound Element already contains the element you are trying to add.");
					return false;
				}
				int num = qrsdZGWsNyZJAhzTjtkclwkQMxKL();
				if (num < 0)
				{
					Logger.LogWarning("Cannot add element! This Compound Element already contains the maximum number of elements.");
					return false;
				}
				return BtLDVccqJwfeAaEztdlTIVXEYigDB(P_0, P_1, num);
			}

			internal bool cIdAhSODhpJijRyBOmMpsxujQEEb(Element P_0)
			{
				if (P_0 == null)
				{
					return false;
				}
				if (LvMzrlAMMhSTcTWjVdZTofQcevHp == 0)
				{
					Logger.LogWarning("Cannot remove element! This Compound Element has no elements.");
					return false;
				}
				int num = KwDXgRpabGhmUeMoIgSVjztYJJydA(P_0);
				if (num < 0)
				{
					Logger.LogWarning("Cannot remove element! This Compound Element does not contain the element you are trying to remove.");
					return false;
				}
				return ffDvjGrLhZGsbHhTrIxTlZgabLJVA(num);
			}

			internal void RmteSymMXXgZftQozzHhEnAbdHzS()
			{
				for (int i = 0; i < jFkRlNQYeNiJiBwzbDewNbEoDsceA.Length; i++)
				{
					ffDvjGrLhZGsbHhTrIxTlZgabLJVA(i);
				}
				LvMzrlAMMhSTcTWjVdZTofQcevHp = 0;
			}

			private int KwDXgRpabGhmUeMoIgSVjztYJJydA(Element P_0)
			{
				if (P_0 == null)
				{
					return -1;
				}
				for (int i = 0; i < jFkRlNQYeNiJiBwzbDewNbEoDsceA.Length; i++)
				{
					if (jFkRlNQYeNiJiBwzbDewNbEoDsceA[i] != null && jFkRlNQYeNiJiBwzbDewNbEoDsceA[i].KOyEJYwNeUSsHoUcqXoDWcABjNuD == P_0)
					{
						return i;
					}
				}
				return -1;
			}

			private bool BtLDVccqJwfeAaEztdlTIVXEYigDB(Element P_0, int P_1, int P_2)
			{
				if (P_2 < 0 || P_2 >= jFkRlNQYeNiJiBwzbDewNbEoDsceA.Length)
				{
					return false;
				}
				if (jFkRlNQYeNiJiBwzbDewNbEoDsceA[P_2] != null)
				{
					return false;
				}
				jFkRlNQYeNiJiBwzbDewNbEoDsceA[P_2] = new YTZZFUGREZbBrjsqZmWUfksumdqP(P_0, P_1);
				P_0.QiwajZdkPqpKFHSXGxNATpckJzBG(this);
				LvMzrlAMMhSTcTWjVdZTofQcevHp++;
				return true;
			}

			private bool ffDvjGrLhZGsbHhTrIxTlZgabLJVA(int P_0)
			{
				if (P_0 < 0 || P_0 >= jFkRlNQYeNiJiBwzbDewNbEoDsceA.Length)
				{
					return false;
				}
				if (jFkRlNQYeNiJiBwzbDewNbEoDsceA[P_0] == null)
				{
					return false;
				}
				if (jFkRlNQYeNiJiBwzbDewNbEoDsceA[P_0].KOyEJYwNeUSsHoUcqXoDWcABjNuD != null)
				{
					jFkRlNQYeNiJiBwzbDewNbEoDsceA[P_0].KOyEJYwNeUSsHoUcqXoDWcABjNuD.BNTsavdtWwlOIqdJufbjiGHnbJKqA(this);
				}
				jFkRlNQYeNiJiBwzbDewNbEoDsceA[P_0] = null;
				LvMzrlAMMhSTcTWjVdZTofQcevHp--;
				return true;
			}

			private int qrsdZGWsNyZJAhzTjtkclwkQMxKL()
			{
				for (int i = 0; i < jFkRlNQYeNiJiBwzbDewNbEoDsceA.Length; i++)
				{
					if (jFkRlNQYeNiJiBwzbDewNbEoDsceA[i] == null)
					{
						return i;
					}
				}
				return -1;
			}
		}

		public sealed class Axis2D : CompoundElement
		{
			private const int XQIxxjkTBIdaCiCRyeolkgIZIoZV = 2;

			private CalibrationMap EKSsXfeOWBAJTlJeYydEiHMofTai;

			int CompoundElement.elementCapacity => 2;

			public Axis xAxis
			{
				get
				{
					if (ReInput._id != VaeVfOLUBZwxUAILYAidjkxjCCwv)
					{
						ReInput.CheckInitialized(VaeVfOLUBZwxUAILYAidjkxjCCwv);
						return null;
					}
					return HcjtostkCLkJzotAouatnCttoUrg<Axis>(0);
				}
			}

			public Axis yAxis
			{
				get
				{
					if (ReInput._id != VaeVfOLUBZwxUAILYAidjkxjCCwv)
					{
						ReInput.CheckInitialized(VaeVfOLUBZwxUAILYAidjkxjCCwv);
						return null;
					}
					return HcjtostkCLkJzotAouatnCttoUrg<Axis>(1);
				}
			}

			public Vector2 value
			{
				get
				{
					if (ReInput._id != VaeVfOLUBZwxUAILYAidjkxjCCwv)
					{
						ReInput.CheckInitialized(VaeVfOLUBZwxUAILYAidjkxjCCwv);
						return Vector2.zero;
					}
					return AGdgjBsJQzlrBCtQEFETXgJauGaq();
				}
			}

			public Vector2 valuePrev
			{
				get
				{
					if (ReInput._id != VaeVfOLUBZwxUAILYAidjkxjCCwv)
					{
						ReInput.CheckInitialized(VaeVfOLUBZwxUAILYAidjkxjCCwv);
						return Vector2.zero;
					}
					return jFTItxSvIxqhFvaRWeksuxhaNZUS();
				}
			}

			public Vector2 valueRaw
			{
				get
				{
					if (ReInput._id != VaeVfOLUBZwxUAILYAidjkxjCCwv)
					{
						ReInput.CheckInitialized(VaeVfOLUBZwxUAILYAidjkxjCCwv);
						return Vector2.zero;
					}
					return new Vector2((xAxis != null) ? xAxis.valueRaw : 0f, (yAxis != null) ? yAxis.valueRaw : 0f);
				}
			}

			public Vector2 valueRawPrev
			{
				get
				{
					if (ReInput._id != VaeVfOLUBZwxUAILYAidjkxjCCwv)
					{
						ReInput.CheckInitialized(VaeVfOLUBZwxUAILYAidjkxjCCwv);
						return Vector2.zero;
					}
					return new Vector2((xAxis != null) ? xAxis.valueRawPrev : 0f, (yAxis != null) ? yAxis.valueRawPrev : 0f);
				}
			}

			internal Axis2D(Controller P_0, int P_1, string P_2, Axis P_3, Axis P_4, int P_5, int P_6, CalibrationMap P_7)
				: base(P_0, P_1, P_2, CompoundControllerElementType.Axis2D)
			{
				kYjGoZyIKXlKFPeEgXxekEtboTnJ(P_3, P_5);
				kYjGoZyIKXlKFPeEgXxekEtboTnJ(P_4, P_6);
				EKSsXfeOWBAJTlJeYydEiHMofTai = P_7;
			}

			internal void XzmaJmICkGalCBKwnhOqxmFLLscfb()
			{
				Vector2 vector = value;
				if (xAxis != null)
				{
					xAxis.mELtbmoXYRNauJErmNsauoJxarvc(vector.x);
				}
				if (yAxis != null)
				{
					yAxis.mELtbmoXYRNauJErmNsauoJxarvc(vector.y);
				}
			}

			private Vector2 AGdgjBsJQzlrBCtQEFETXgJauGaq()
			{
				if (EKSsXfeOWBAJTlJeYydEiHMofTai == null)
				{
					return default(Vector2);
				}
				int xAxisIndex;
				Axis axis = EXIwZQRRuoJzWwhjnblvkkKFQitR<Axis>(0, out xAxisIndex);
				int yAxisIndex;
				Axis axis2 = EXIwZQRRuoJzWwhjnblvkkKFQitR<Axis>(1, out yAxisIndex);
				DeadZone2DType defaultJoystickAxis2DDeadZoneType = ReInput.configVars.defaultJoystickAxis2DDeadZoneType;
				AxisSensitivity2DType defaultJoystickAxis2DSensitivityType = ReInput.configVars.defaultJoystickAxis2DSensitivityType;
				float valueRawX = axis?.valueRaw ?? 0f;
				float valueRawY = axis2?.valueRaw ?? 0f;
				return EKSsXfeOWBAJTlJeYydEiHMofTai.GetCalibrated2DValue(xAxisIndex, yAxisIndex, valueRawX, valueRawY, defaultJoystickAxis2DDeadZoneType, defaultJoystickAxis2DSensitivityType);
			}

			private Vector2 jFTItxSvIxqhFvaRWeksuxhaNZUS()
			{
				if (EKSsXfeOWBAJTlJeYydEiHMofTai == null)
				{
					return default(Vector2);
				}
				int xAxisIndex;
				Axis axis = EXIwZQRRuoJzWwhjnblvkkKFQitR<Axis>(0, out xAxisIndex);
				int yAxisIndex;
				Axis axis2 = EXIwZQRRuoJzWwhjnblvkkKFQitR<Axis>(1, out yAxisIndex);
				DeadZone2DType defaultJoystickAxis2DDeadZoneType = ReInput.configVars.defaultJoystickAxis2DDeadZoneType;
				AxisSensitivity2DType defaultJoystickAxis2DSensitivityType = ReInput.configVars.defaultJoystickAxis2DSensitivityType;
				float valueRawX = axis?.valueRawPrev ?? 0f;
				float valueRawY = axis2?.valueRawPrev ?? 0f;
				return EKSsXfeOWBAJTlJeYydEiHMofTai.GetCalibrated2DValue(xAxisIndex, yAxisIndex, valueRawX, valueRawY, defaultJoystickAxis2DDeadZoneType, defaultJoystickAxis2DSensitivityType);
			}
		}

		public sealed class Hat : CompoundElement
		{
			private const int qiXFFmzJqRAtbBCGLllQmfUGCCPOA = 8;

			private const int bcWsoDzqSnZkJrZbcUiWQteMUdgM = 0;

			private const int AhbvwyZuTikjIKsvLddxFegQijxbA = 1;

			private const int iIzEidMJlSJoLAmcwehMJKQpuCcF = 2;

			private const int AXhfIUSaSHAoHHPZjKYGFMkFeiXT = 3;

			private const int hmJXpuOfElLbeWHWaunzpwSxbeuw = 4;

			private const int vCVoVBAIYplIdczwvyvWLckyuQLC = 5;

			private const int kkyUoXEAgPMAtZPMRJZhKLlNVnsR = 6;

			private const int ArAzzORNscReCRSkZiKsPKJZHlIiA = 7;

			private readonly int vdozpcyUyOGAMMsPnfcrDmGtsOgs;

			private readonly Button[] TDKnMjshoiFgVHqZRekTYbzcyrUkA;

			private readonly ReadOnlyCollection<Button> uCrfPRlfbxRvsBVdpsDWXEAplpyo;

			private readonly int[] ucwCrGCjgRDQhnSZGfjVHYlaNCGfB;

			private bool mSkTiPfyWApbgdcxuXgZrNHyBYaS;

			int CompoundElement.elementCapacity => 8;

			public bool force4Way
			{
				get
				{
					if (ReInput._id != VaeVfOLUBZwxUAILYAidjkxjCCwv)
					{
						ReInput.CheckInitialized(VaeVfOLUBZwxUAILYAidjkxjCCwv);
						return false;
					}
					return mSkTiPfyWApbgdcxuXgZrNHyBYaS;
				}
				set
				{
					if (ReInput._id != VaeVfOLUBZwxUAILYAidjkxjCCwv)
					{
						ReInput.CheckInitialized(VaeVfOLUBZwxUAILYAidjkxjCCwv);
					}
					else
					{
						mSkTiPfyWApbgdcxuXgZrNHyBYaS = value;
					}
				}
			}

			public int directionCount
			{
				get
				{
					if (ReInput._id != VaeVfOLUBZwxUAILYAidjkxjCCwv)
					{
						ReInput.CheckInitialized(VaeVfOLUBZwxUAILYAidjkxjCCwv);
						return 0;
					}
					return vdozpcyUyOGAMMsPnfcrDmGtsOgs;
				}
			}

			public IList<Button> Buttons
			{
				get
				{
					if (ReInput._id != VaeVfOLUBZwxUAILYAidjkxjCCwv)
					{
						ReInput.CheckInitialized(VaeVfOLUBZwxUAILYAidjkxjCCwv);
						return EmptyObjects<Button>.EmptyReadOnlyIListT;
					}
					return uCrfPRlfbxRvsBVdpsDWXEAplpyo;
				}
			}

			public Button buttonUp
			{
				get
				{
					if (ReInput._id != VaeVfOLUBZwxUAILYAidjkxjCCwv)
					{
						ReInput.CheckInitialized(VaeVfOLUBZwxUAILYAidjkxjCCwv);
						return null;
					}
					return HcjtostkCLkJzotAouatnCttoUrg<Button>(0);
				}
			}

			public Button buttonRight
			{
				get
				{
					if (ReInput._id != VaeVfOLUBZwxUAILYAidjkxjCCwv)
					{
						ReInput.CheckInitialized(VaeVfOLUBZwxUAILYAidjkxjCCwv);
						return null;
					}
					return HcjtostkCLkJzotAouatnCttoUrg<Button>(2);
				}
			}

			public Button buttonDown
			{
				get
				{
					if (ReInput._id != VaeVfOLUBZwxUAILYAidjkxjCCwv)
					{
						ReInput.CheckInitialized(VaeVfOLUBZwxUAILYAidjkxjCCwv);
						return null;
					}
					return HcjtostkCLkJzotAouatnCttoUrg<Button>(4);
				}
			}

			public Button buttonLeft
			{
				get
				{
					if (ReInput._id != VaeVfOLUBZwxUAILYAidjkxjCCwv)
					{
						ReInput.CheckInitialized(VaeVfOLUBZwxUAILYAidjkxjCCwv);
						return null;
					}
					return HcjtostkCLkJzotAouatnCttoUrg<Button>(6);
				}
			}

			public Button buttonUpRight
			{
				get
				{
					if (ReInput._id != VaeVfOLUBZwxUAILYAidjkxjCCwv)
					{
						ReInput.CheckInitialized(VaeVfOLUBZwxUAILYAidjkxjCCwv);
						return null;
					}
					return HcjtostkCLkJzotAouatnCttoUrg<Button>(1);
				}
			}

			public Button buttonDownRight
			{
				get
				{
					if (ReInput._id != VaeVfOLUBZwxUAILYAidjkxjCCwv)
					{
						ReInput.CheckInitialized(VaeVfOLUBZwxUAILYAidjkxjCCwv);
						return null;
					}
					return HcjtostkCLkJzotAouatnCttoUrg<Button>(3);
				}
			}

			public Button buttonDownLeft
			{
				get
				{
					if (ReInput._id != VaeVfOLUBZwxUAILYAidjkxjCCwv)
					{
						ReInput.CheckInitialized(VaeVfOLUBZwxUAILYAidjkxjCCwv);
						return null;
					}
					return HcjtostkCLkJzotAouatnCttoUrg<Button>(5);
				}
			}

			public Button buttonUpLeft
			{
				get
				{
					if (ReInput._id != VaeVfOLUBZwxUAILYAidjkxjCCwv)
					{
						ReInput.CheckInitialized(VaeVfOLUBZwxUAILYAidjkxjCCwv);
						return null;
					}
					return HcjtostkCLkJzotAouatnCttoUrg<Button>(7);
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
					kYjGoZyIKXlKFPeEgXxekEtboTnJ(P_3[i], P_4[i]);
				}
				TDKnMjshoiFgVHqZRekTYbzcyrUkA = P_3;
				ucwCrGCjgRDQhnSZGfjVHYlaNCGfB = P_4;
				vdozpcyUyOGAMMsPnfcrDmGtsOgs = num;
				uCrfPRlfbxRvsBVdpsDWXEAplpyo = new ReadOnlyCollection<Button>(P_3);
			}

			internal void boPEszaqjMauNhuIPQKKTkTcSDbPA(UpdateLoopType P_0, ControllerDataUpdater P_1)
			{
				if (vdozpcyUyOGAMMsPnfcrDmGtsOgs == 0)
				{
					return;
				}
				if (vdozpcyUyOGAMMsPnfcrDmGtsOgs == 8 && (mSkTiPfyWApbgdcxuXgZrNHyBYaS || ReInput.configVars.force4WayHats))
				{
					zGHrqGDDFKhyGGldIHIVTQyjQqBlA(TDKnMjshoiFgVHqZRekTYbzcyrUkA[0], ucwCrGCjgRDQhnSZGfjVHYlaNCGfB[0], ucwCrGCjgRDQhnSZGfjVHYlaNCGfB[7], ucwCrGCjgRDQhnSZGfjVHYlaNCGfB[1], P_0, P_1);
					zGHrqGDDFKhyGGldIHIVTQyjQqBlA(TDKnMjshoiFgVHqZRekTYbzcyrUkA[2], ucwCrGCjgRDQhnSZGfjVHYlaNCGfB[2], ucwCrGCjgRDQhnSZGfjVHYlaNCGfB[1], ucwCrGCjgRDQhnSZGfjVHYlaNCGfB[3], P_0, P_1);
					zGHrqGDDFKhyGGldIHIVTQyjQqBlA(TDKnMjshoiFgVHqZRekTYbzcyrUkA[4], ucwCrGCjgRDQhnSZGfjVHYlaNCGfB[4], ucwCrGCjgRDQhnSZGfjVHYlaNCGfB[5], ucwCrGCjgRDQhnSZGfjVHYlaNCGfB[3], P_0, P_1);
					zGHrqGDDFKhyGGldIHIVTQyjQqBlA(TDKnMjshoiFgVHqZRekTYbzcyrUkA[6], ucwCrGCjgRDQhnSZGfjVHYlaNCGfB[6], ucwCrGCjgRDQhnSZGfjVHYlaNCGfB[5], ucwCrGCjgRDQhnSZGfjVHYlaNCGfB[7], P_0, P_1);
					UvUsZKExTssIRHOeQGJgvIDxpswi(TDKnMjshoiFgVHqZRekTYbzcyrUkA[1], ucwCrGCjgRDQhnSZGfjVHYlaNCGfB[1], P_0, P_1);
					UvUsZKExTssIRHOeQGJgvIDxpswi(TDKnMjshoiFgVHqZRekTYbzcyrUkA[3], ucwCrGCjgRDQhnSZGfjVHYlaNCGfB[3], P_0, P_1);
					UvUsZKExTssIRHOeQGJgvIDxpswi(TDKnMjshoiFgVHqZRekTYbzcyrUkA[5], ucwCrGCjgRDQhnSZGfjVHYlaNCGfB[5], P_0, P_1);
					UvUsZKExTssIRHOeQGJgvIDxpswi(TDKnMjshoiFgVHqZRekTYbzcyrUkA[7], ucwCrGCjgRDQhnSZGfjVHYlaNCGfB[7], P_0, P_1);
					return;
				}
				for (int i = 0; i < TDKnMjshoiFgVHqZRekTYbzcyrUkA.Length; i++)
				{
					if (TDKnMjshoiFgVHqZRekTYbzcyrUkA[i] != null)
					{
						TDKnMjshoiFgVHqZRekTYbzcyrUkA[i].KknekHfCfaOAyFWPFHiholZwGQJTA(P_0, ucwCrGCjgRDQhnSZGfjVHYlaNCGfB[i], P_1);
					}
				}
			}

			private void zGHrqGDDFKhyGGldIHIVTQyjQqBlA(Button P_0, int P_1, int P_2, int P_3, UpdateLoopType P_4, ControllerDataUpdater P_5)
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
				P_0.KknekHfCfaOAyFWPFHiholZwGQJTA(P_4, P_1, P_5);
			}

			private void UvUsZKExTssIRHOeQGJgvIDxpswi(Button P_0, int P_1, UpdateLoopType P_2, ControllerDataUpdater P_3)
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
					P_0.KknekHfCfaOAyFWPFHiholZwGQJTA(P_2, P_1, P_3);
				}
			}
		}

		public sealed class DirectionalPad : CompoundElement
		{
			private const int DswZTBxHxEFSgJTPKugjPoEVwimW = 4;

			private const int tcjejPXjraQQfHxSKMkomyxKETyk = 0;

			private const int gdfaCvagyIMWHWbGcRBdrWExfUJi = 1;

			private const int WfBYbSXzFfFuQmiAXPvPvaIYtQMH = 2;

			private const int riaWXGrwyABPRbpRLfUuHcUCfLgAb = 3;

			private readonly int VJjobqVjGUVCrFAwmRrBVypPkBTi;

			private readonly Button[] jkQLGxZMHqyBwHjJkhIPPjMPCkxE;

			private readonly ReadOnlyCollection<Button> TbPEGWcTMaLOLznvqwnoeyPvTXNv;

			private readonly int[] unNzUFTqsooIuXSGbgjkjAbAIGmR;

			int CompoundElement.elementCapacity => 4;

			public IList<Button> Buttons
			{
				get
				{
					if (ReInput._id != VaeVfOLUBZwxUAILYAidjkxjCCwv)
					{
						ReInput.CheckInitialized(VaeVfOLUBZwxUAILYAidjkxjCCwv);
						return EmptyObjects<Button>.EmptyReadOnlyIListT;
					}
					return TbPEGWcTMaLOLznvqwnoeyPvTXNv;
				}
			}

			public Button buttonUp
			{
				get
				{
					if (ReInput._id != VaeVfOLUBZwxUAILYAidjkxjCCwv)
					{
						ReInput.CheckInitialized(VaeVfOLUBZwxUAILYAidjkxjCCwv);
						return null;
					}
					return HcjtostkCLkJzotAouatnCttoUrg<Button>(0);
				}
			}

			public Button buttonRight
			{
				get
				{
					if (ReInput._id != VaeVfOLUBZwxUAILYAidjkxjCCwv)
					{
						ReInput.CheckInitialized(VaeVfOLUBZwxUAILYAidjkxjCCwv);
						return null;
					}
					return HcjtostkCLkJzotAouatnCttoUrg<Button>(1);
				}
			}

			public Button buttonDown
			{
				get
				{
					if (ReInput._id != VaeVfOLUBZwxUAILYAidjkxjCCwv)
					{
						ReInput.CheckInitialized(VaeVfOLUBZwxUAILYAidjkxjCCwv);
						return null;
					}
					return HcjtostkCLkJzotAouatnCttoUrg<Button>(2);
				}
			}

			public Button buttonLeft
			{
				get
				{
					if (ReInput._id != VaeVfOLUBZwxUAILYAidjkxjCCwv)
					{
						ReInput.CheckInitialized(VaeVfOLUBZwxUAILYAidjkxjCCwv);
						return null;
					}
					return HcjtostkCLkJzotAouatnCttoUrg<Button>(3);
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
					kYjGoZyIKXlKFPeEgXxekEtboTnJ(P_3[i], P_4[i]);
				}
				jkQLGxZMHqyBwHjJkhIPPjMPCkxE = P_3;
				unNzUFTqsooIuXSGbgjkjAbAIGmR = P_4;
				VJjobqVjGUVCrFAwmRrBVypPkBTi = num;
				TbPEGWcTMaLOLznvqwnoeyPvTXNv = new ReadOnlyCollection<Button>(P_3);
			}

			internal void XZrncGkfKyxmiEqiyrYOSFVaQMPV(UpdateLoopType P_0, ControllerDataUpdater P_1)
			{
				if (VJjobqVjGUVCrFAwmRrBVypPkBTi == 0)
				{
					return;
				}
				for (int i = 0; i < jkQLGxZMHqyBwHjJkhIPPjMPCkxE.Length; i++)
				{
					if (jkQLGxZMHqyBwHjJkhIPPjMPCkxE[i] != null)
					{
						jkQLGxZMHqyBwHjJkhIPPjMPCkxE[i].KknekHfCfaOAyFWPFHiholZwGQJTA(P_0, unNzUFTqsooIuXSGbgjkjAbAIGmR[i], P_1);
					}
				}
			}
		}

		[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
		public abstract class Extension
		{
			private Controller IAtEAofRDwWTIvjnWtRxiVISFgsC;

			private IControllerExtensionSource QdOCvIcvkpsUASoGfbjXfKYUjOEh;

			internal readonly int _reInputId;

			internal bool isJoystickConnected
			{
				get
				{
					if (IAtEAofRDwWTIvjnWtRxiVISFgsC == null)
					{
						return false;
					}
					return IAtEAofRDwWTIvjnWtRxiVISFgsC._isConnected;
				}
			}

			internal bool enabled
			{
				get
				{
					if (IAtEAofRDwWTIvjnWtRxiVISFgsC == null)
					{
						return false;
					}
					return IAtEAofRDwWTIvjnWtRxiVISFgsC.enabled;
				}
			}

			public Controller controller => IAtEAofRDwWTIvjnWtRxiVISFgsC;

			internal Extension(IControllerExtensionSource P_0)
			{
				_reInputId = ReInput.id;
				eDFBdkkYtdBdiwZpHUbfKeIanWMkA(P_0);
			}

			internal Extension(Extension P_0)
				: this(P_0.QdOCvIcvkpsUASoGfbjXfKYUjOEh)
			{
				IAtEAofRDwWTIvjnWtRxiVISFgsC = P_0.IAtEAofRDwWTIvjnWtRxiVISFgsC;
			}

			internal T GetController<T>() where T : Controller
			{
				if (IAtEAofRDwWTIvjnWtRxiVISFgsC == null)
				{
					return null;
				}
				return IAtEAofRDwWTIvjnWtRxiVISFgsC as T;
			}

			internal void SetController(Controller controller)
			{
				IAtEAofRDwWTIvjnWtRxiVISFgsC = controller;
			}

			[CustomObfuscation(rename = false)]
			internal IControllerExtensionSource GetSource()
			{
				return QdOCvIcvkpsUASoGfbjXfKYUjOEh;
			}

			internal void SetSource(Extension extension)
			{
				if (extension == null)
				{
					eDFBdkkYtdBdiwZpHUbfKeIanWMkA(null);
				}
				else
				{
					eDFBdkkYtdBdiwZpHUbfKeIanWMkA(extension.QdOCvIcvkpsUASoGfbjXfKYUjOEh);
				}
			}

			private void eDFBdkkYtdBdiwZpHUbfKeIanWMkA(IControllerExtensionSource P_0)
			{
				QdOCvIcvkpsUASoGfbjXfKYUjOEh = P_0;
				SourceUpdated(QdOCvIcvkpsUASoGfbjXfKYUjOEh);
			}

			internal virtual void Clear()
			{
			}

			internal abstract void SourceUpdated(IControllerExtensionSource source);

			internal abstract void UpdateData(UpdateLoopType updateLoop);

			internal abstract Extension Clone();
		}

		[Serializable]
		private sealed class nEAtExUMsYbhJMZYTIEgfcnkTGKq
		{
			public static readonly nEAtExUMsYbhJMZYTIEgfcnkTGKq _003C_003E9 = new nEAtExUMsYbhJMZYTIEgfcnkTGKq();

			public static Func<Controller, Guid, bool> _003C_003E9__166_0;

			public static Func<Controller, Type, bool> _003C_003E9__169_0;

			internal bool uteSyNjqlNfqwUDkvDWxhxFJFccW(Controller P_0, Guid P_1)
			{
				return P_0.ImplementsTemplate(P_1);
			}

			internal bool BxLjfTrKpSiJUWehYMdYgabGnWWd(Controller P_0, Type P_1)
			{
				return P_0.ImplementsTemplate(P_1);
			}
		}

		private sealed class iovQRssjjuToCtiXCLooxZgiSuWH : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
		{
			private int znIktnsSPuFycFQmFoQpvTQOvuIK;

			private ControllerPollingInfo ntMmuewekrjUlxtzzteTSqzNAEBBA;

			private int fAzeRcwQfjVZmzGsuGIrCTTxffiP;

			public Controller jfnWnvVEaBfmkPchOfAakbNktroWA;

			private int RaMfikBUbgIKdqTVzxxNpSuAhoCjA;

			ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return ntMmuewekrjUlxtzzteTSqzNAEBBA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return ntMmuewekrjUlxtzzteTSqzNAEBBA;
				}
			}

			[DebuggerHidden]
			public iovQRssjjuToCtiXCLooxZgiSuWH(int P_0)
			{
				znIktnsSPuFycFQmFoQpvTQOvuIK = P_0;
				fAzeRcwQfjVZmzGsuGIrCTTxffiP = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int num = znIktnsSPuFycFQmFoQpvTQOvuIK;
				Controller controller = jfnWnvVEaBfmkPchOfAakbNktroWA;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					znIktnsSPuFycFQmFoQpvTQOvuIK = -1;
					goto IL_00a0;
				}
				znIktnsSPuFycFQmFoQpvTQOvuIK = -1;
				if (ReInput._id != controller.amvEgOgWeoORBWecwIHRbEwcHoDuB)
				{
					ReInput.CheckInitialized(controller.amvEgOgWeoORBWecwIHRbEwcHoDuB);
					return false;
				}
				controller.UpdatePollingFrameTracking();
				RaMfikBUbgIKdqTVzxxNpSuAhoCjA = 0;
				goto IL_00b0;
				IL_00b0:
				if (RaMfikBUbgIKdqTVzxxNpSuAhoCjA < controller._buttonCount)
				{
					if (controller.XtLZBzodYmCeHczmaskCagwagzkkA(RaMfikBUbgIKdqTVzxxNpSuAhoCjA, out var num2))
					{
						ntMmuewekrjUlxtzzteTSqzNAEBBA = new ControllerPollingInfo(true, -1, controller.id, controller._name, controller._type, ControllerElementType.Button, RaMfikBUbgIKdqTVzxxNpSuAhoCjA, Pole.Positive, controller.qfUAjoZEkUJBMcgOHFRLtyQzKjdR.GetElementIdentifierName(num2), num2, KeyCode.None);
						znIktnsSPuFycFQmFoQpvTQOvuIK = 1;
						return true;
					}
					goto IL_00a0;
				}
				return false;
				IL_00a0:
				RaMfikBUbgIKdqTVzxxNpSuAhoCjA++;
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
				iovQRssjjuToCtiXCLooxZgiSuWH iovQRssjjuToCtiXCLooxZgiSuWH2;
				if (znIktnsSPuFycFQmFoQpvTQOvuIK == -2 && fAzeRcwQfjVZmzGsuGIrCTTxffiP == Environment.CurrentManagedThreadId)
				{
					znIktnsSPuFycFQmFoQpvTQOvuIK = 0;
					iovQRssjjuToCtiXCLooxZgiSuWH2 = this;
				}
				else
				{
					iovQRssjjuToCtiXCLooxZgiSuWH2 = new iovQRssjjuToCtiXCLooxZgiSuWH(0);
					iovQRssjjuToCtiXCLooxZgiSuWH2.jfnWnvVEaBfmkPchOfAakbNktroWA = jfnWnvVEaBfmkPchOfAakbNktroWA;
				}
				return iovQRssjjuToCtiXCLooxZgiSuWH2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
			}
		}

		private sealed class gfEcWRHeyFAosuYGARwXDPtMIVttA : IEnumerable<ControllerPollingInfo>, IEnumerable, IEnumerator<ControllerPollingInfo>, IEnumerator, IDisposable
		{
			private int dZeLmmgaEpFdqhEOYQamzPtApPOc;

			private ControllerPollingInfo aIRsanLZpIKCcLRwVtECXjLeKSWw;

			private int oAEhpCEggNPuUqowmfszrVRdHYJHA;

			public Controller kGNGYVUsZrLvINYOwXEloPQDLHuc;

			private int WiKduPALvtnZykUajuOjHFtibeJd;

			ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return aIRsanLZpIKCcLRwVtECXjLeKSWw;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return aIRsanLZpIKCcLRwVtECXjLeKSWw;
				}
			}

			[DebuggerHidden]
			public gfEcWRHeyFAosuYGARwXDPtMIVttA(int P_0)
			{
				dZeLmmgaEpFdqhEOYQamzPtApPOc = P_0;
				oAEhpCEggNPuUqowmfszrVRdHYJHA = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int num = dZeLmmgaEpFdqhEOYQamzPtApPOc;
				Controller controller = kGNGYVUsZrLvINYOwXEloPQDLHuc;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					dZeLmmgaEpFdqhEOYQamzPtApPOc = -1;
					goto IL_00a0;
				}
				dZeLmmgaEpFdqhEOYQamzPtApPOc = -1;
				if (ReInput._id != controller.amvEgOgWeoORBWecwIHRbEwcHoDuB)
				{
					ReInput.CheckInitialized(controller.amvEgOgWeoORBWecwIHRbEwcHoDuB);
					return false;
				}
				controller.UpdatePollingFrameTracking();
				WiKduPALvtnZykUajuOjHFtibeJd = 0;
				goto IL_00b0;
				IL_00b0:
				if (WiKduPALvtnZykUajuOjHFtibeJd < controller._buttonCount)
				{
					if (controller.vyuDXFkJJKuIMXHEVzTYGSYNfNTT(WiKduPALvtnZykUajuOjHFtibeJd, out var num2))
					{
						aIRsanLZpIKCcLRwVtECXjLeKSWw = new ControllerPollingInfo(true, -1, controller.id, controller._name, controller._type, ControllerElementType.Button, WiKduPALvtnZykUajuOjHFtibeJd, Pole.Positive, controller.qfUAjoZEkUJBMcgOHFRLtyQzKjdR.GetElementIdentifierName(num2), num2, KeyCode.None);
						dZeLmmgaEpFdqhEOYQamzPtApPOc = 1;
						return true;
					}
					goto IL_00a0;
				}
				return false;
				IL_00a0:
				WiKduPALvtnZykUajuOjHFtibeJd++;
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
				gfEcWRHeyFAosuYGARwXDPtMIVttA gfEcWRHeyFAosuYGARwXDPtMIVttA2;
				if (dZeLmmgaEpFdqhEOYQamzPtApPOc == -2 && oAEhpCEggNPuUqowmfszrVRdHYJHA == Environment.CurrentManagedThreadId)
				{
					dZeLmmgaEpFdqhEOYQamzPtApPOc = 0;
					gfEcWRHeyFAosuYGARwXDPtMIVttA2 = this;
				}
				else
				{
					gfEcWRHeyFAosuYGARwXDPtMIVttA2 = new gfEcWRHeyFAosuYGARwXDPtMIVttA(0);
					gfEcWRHeyFAosuYGARwXDPtMIVttA2.kGNGYVUsZrLvINYOwXEloPQDLHuc = kGNGYVUsZrLvINYOwXEloPQDLHuc;
				}
				return gfEcWRHeyFAosuYGARwXDPtMIVttA2;
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

		private readonly DeviceLocalizationInfo KmePLIMVtrmYlbRqdrNstBJdEZpGA;

		protected string _hardwareName;

		protected readonly ControllerType _type;

		internal readonly Guid XoTulHbRfmGIRZBImccjILWCKOlE;

		protected string _hardwareIdentifier;

		protected bool _isConnected;

		private Extension MSzSKprKifUtmxOJYqUnzDXeHvtJ;

		private bool aokeGJAmMGXtkZkWaxsTUGzuaXdV;

		private ControllerIdentifier EbCWSQmumtPLvoukhGGMHWltJtnG;

		internal int amvEgOgWeoORBWecwIHRbEwcHoDuB;

		protected readonly int _buttonCount;

		protected readonly Button[] buttons;

		protected readonly ReadOnlyCollection<Button> buttons_readOnly;

		private readonly IList<Element> KBPXIuvxTTmXDQUOOGawwIuTXaOq;

		private readonly ReadOnlyCollection<Element> AUMeqWcCdvWDtMwOJzSOLsfqGEIl;

		private readonly IList<CompoundElement> fQJFLvCaxzoKyNbPmsoQbPMVHDYdA;

		private readonly ReadOnlyCollection<CompoundElement> DweRUsfaxMCxbfOWrtRMnjFlCwPab;

		[CustomObfuscation(rename = false)]
		internal readonly InputSource inputSource;

		internal readonly ControllerDataUpdater EnxeINdfRsPNEfNsWCRpkeCWEWlpA;

		internal readonly HardwareControllerMap_Game qfUAjoZEkUJBMcgOHFRLtyQzKjdR;

		internal uint yMnQryEwKXmSLSkZpVlqywTeEaTh;

		private uint PaxMHiWxydwfkBakWiPUtWhBqwQb;

		private uint pReEwWdUeuJHMiVdDrcnAhRtRdJXb;

		private ITryGetLocalizedName mSoxvhxBObtFGsosqVQkUlhRovIG;

		private readonly LocalizedString WgwpUneykbXXEPwmSxuXrusqxrYg;

		private readonly HoegishJjcCukocqVPiQYVHCmbvt kSIGEgjCAQyKaLydgPhZAbJLcdJx;

		private Action<bool> sZGgelaceVahRbyADNcqltySjeQEB;

		private IControllerTemplate[] hBttiNoJmfaugulEkxDuwwPnNltA;

		private ReadOnlyCollection<IControllerTemplate> NDxGWTJnfuODYTJAZeypYtObhiLGA;

		private static Func<Controller, Guid, bool> qEPPDwXYwxTlZfCLEMUPqWIloliQ;

		private static Func<Controller, Type, bool> SfANpqcFbkPyTRcSJddaXPaQWYPi;

		internal bool jJaVxXRAGlGenCcVvwqpdifNLvVQA => PaxMHiWxydwfkBakWiPUtWhBqwQb == ReInput.previousFrame;

		public bool enabled
		{
			get
			{
				if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
				{
					ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
					return false;
				}
				return aokeGJAmMGXtkZkWaxsTUGzuaXdV;
			}
			set
			{
				mqVKPhaeRMzKymnkzsnkxIOdysds(value);
			}
		}

		public string name
		{
			get
			{
				if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
				{
					ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
					return string.Empty;
				}
				if (!LocalizationManager.isEnabled)
				{
					return _name;
				}
				if (akwtvaGPrrlBPafWNXGoNkGZGapl != null && akwtvaGPrrlBPafWNXGoNkGZGapl.TryGetLocalizedName(out var value))
				{
					return value;
				}
				if (_type == ControllerType.Joystick && XoTulHbRfmGIRZBImccjILWCKOlE == Consts.joystickGuid_unknownController)
				{
					return _name;
				}
				if (KmePLIMVtrmYlbRqdrNstBJdEZpGA == null || KmePLIMVtrmYlbRqdrNstBJdEZpGA.parentKeys == null)
				{
					return _name;
				}
				LocalizationManager.GetAndUpdateLocalizedString(WgwpUneykbXXEPwmSxuXrusqxrYg, (KmePLIMVtrmYlbRqdrNstBJdEZpGA != null) ? KmePLIMVtrmYlbRqdrNstBJdEZpGA.parentKeys : null, RfUTDPxyvrJRnCbYKkuVrGRpezaF.lwjfDadavJmMkchAiAidsIjvIiSdB(_type), _name, out value);
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
				if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
				{
					ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
					return string.Empty;
				}
				return _tag;
			}
			set
			{
				if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
				{
					ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
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
				if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
				{
					ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
					return string.Empty;
				}
				return _hardwareName;
			}
		}

		public ControllerType type
		{
			get
			{
				if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
				{
					ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
					return ControllerType.Keyboard;
				}
				return _type;
			}
		}

		public Guid hardwareTypeGuid
		{
			get
			{
				if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
				{
					ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
					return Guid.Empty;
				}
				return XoTulHbRfmGIRZBImccjILWCKOlE;
			}
		}

		public abstract Guid deviceInstanceGuid { get; }

		public ControllerIdentifier identifier => EbCWSQmumtPLvoukhGGMHWltJtnG;

		public bool isConnected
		{
			get
			{
				if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
				{
					ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
					return false;
				}
				return _isConnected;
			}
			internal set
			{
				if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
				{
					ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
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
				if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
				{
					ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
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
				if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
				{
					ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
					return 0;
				}
				return KBPXIuvxTTmXDQUOOGawwIuTXaOq.Count;
			}
		}

		public int buttonCount
		{
			get
			{
				if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
				{
					ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
					return 0;
				}
				return _buttonCount;
			}
		}

		public IList<Element> Elements
		{
			get
			{
				if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
				{
					ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
					return EmptyObjects<Element>.EmptyReadOnlyIListT;
				}
				return AUMeqWcCdvWDtMwOJzSOLsfqGEIl;
			}
		}

		public IList<CompoundElement> CompoundElements
		{
			get
			{
				if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
				{
					ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
					return EmptyObjects<CompoundElement>.EmptyReadOnlyIListT;
				}
				return DweRUsfaxMCxbfOWrtRMnjFlCwPab;
			}
		}

		public IList<Button> Buttons
		{
			get
			{
				if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
				{
					ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
					return EmptyObjects<Button>.EmptyReadOnlyIListT;
				}
				return buttons_readOnly;
			}
		}

		public Extension extension
		{
			get
			{
				if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
				{
					ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
					return null;
				}
				return MSzSKprKifUtmxOJYqUnzDXeHvtJ;
			}
		}

		public IList<ControllerElementIdentifier> ElementIdentifiers
		{
			get
			{
				if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
				{
					ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
					return EmptyObjects<ControllerElementIdentifier>.EmptyReadOnlyIListT;
				}
				return qfUAjoZEkUJBMcgOHFRLtyQzKjdR.elementIdentifiers_readOnly;
			}
		}

		public IList<ControllerElementIdentifier> ButtonElementIdentifiers
		{
			get
			{
				if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
				{
					ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
					return EmptyObjects<ControllerElementIdentifier>.EmptyReadOnlyIListT;
				}
				return qfUAjoZEkUJBMcgOHFRLtyQzKjdR.buttonElementIdentifiers_readOnly;
			}
		}

		internal ITryGetLocalizedName akwtvaGPrrlBPafWNXGoNkGZGapl
		{
			get
			{
				return mSoxvhxBObtFGsosqVQkUlhRovIG;
			}
			set
			{
				mSoxvhxBObtFGsosqVQkUlhRovIG = tryGetLocalizedName;
			}
		}

		public IList<IControllerTemplate> Templates
		{
			get
			{
				if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
				{
					ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
					return EmptyObjects<IControllerTemplate>.EmptyReadOnlyIListT;
				}
				return NDxGWTJnfuODYTJAZeypYtObhiLGA;
			}
		}

		public int templateCount
		{
			get
			{
				if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
				{
					ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
					return 0;
				}
				return hBttiNoJmfaugulEkxDuwwPnNltA.Length;
			}
		}

		internal static Func<Controller, Guid, bool> rOPITeINKEzatjJGCwWrwbTjtUdo => nEAtExUMsYbhJMZYTIEgfcnkTGKq._003C_003E9.uteSyNjqlNfqwUDkvDWxhxFJFccW;

		internal static Func<Controller, Type, bool> YtPGVhJzckwEfcCDzOgHxmTylrAQ => nEAtExUMsYbhJMZYTIEgfcnkTGKq._003C_003E9.BxLjfTrKpSiJUWehYMdYgabGnWWd;

		internal event Action<bool> qZJEWltPOoLpMvBVmRrxVlfNERYU
		{
			add
			{
				sZGgelaceVahRbyADNcqltySjeQEB = (Action<bool>)Delegate.Combine(sZGgelaceVahRbyADNcqltySjeQEB, b);
			}
			remove
			{
				sZGgelaceVahRbyADNcqltySjeQEB = (Action<bool>)Delegate.Remove(sZGgelaceVahRbyADNcqltySjeQEB, value2);
			}
		}

		internal Controller(int P_0, InputSource P_1, string P_2, string P_3, string P_4, ControllerType P_5, Guid P_6, int P_7, bool[] P_8, HardwareButtonInfo[] P_9, HardwareControllerMap_Game P_10, Extension P_11, ControllerDataUpdater P_12)
		{
			id = P_0;
			inputSource = P_1;
			_type = P_5;
			XoTulHbRfmGIRZBImccjILWCKOlE = P_6;
			_buttonCount = P_7;
			_name = P_2;
			_hardwareName = P_3;
			_hardwareIdentifier = P_4;
			EnxeINdfRsPNEfNsWCRpkeCWEWlpA = P_12;
			qfUAjoZEkUJBMcgOHFRLtyQzKjdR = P_10;
			KmePLIMVtrmYlbRqdrNstBJdEZpGA = P_10.deviceLocalizationInfo;
			aokeGJAmMGXtkZkWaxsTUGzuaXdV = true;
			amvEgOgWeoORBWecwIHRbEwcHoDuB = ReInput.id;
			WgwpUneykbXXEPwmSxuXrusqxrYg = new LocalizedString();
			kSIGEgjCAQyKaLydgPhZAbJLcdJx = new HoegishJjcCukocqVPiQYVHCmbvt(delegate
			{
				_ = name;
			});
			wZAgFdpWTgDzbPAtkTSJvQdXLMMR(P_11);
			KBPXIuvxTTmXDQUOOGawwIuTXaOq = new List<Element>(P_7);
			AUMeqWcCdvWDtMwOJzSOLsfqGEIl = new ReadOnlyCollection<Element>(KBPXIuvxTTmXDQUOOGawwIuTXaOq);
			fQJFLvCaxzoKyNbPmsoQbPMVHDYdA = new List<CompoundElement>();
			DweRUsfaxMCxbfOWrtRMnjFlCwPab = new ReadOnlyCollection<CompoundElement>(fQJFLvCaxzoKyNbPmsoQbPMVHDYdA);
			buttons = new Button[P_7];
			if (P_8 == null || P_8.Length < P_7)
			{
				for (int num = 0; num < P_7; num++)
				{
					buttons[num] = new Button(this, P_10.buttonElementIdentifierIds[num], "Button " + num, false, (P_9 != null) ? P_9[num] : new HardwareButtonInfo());
					pMIfsVXUiOvYtrPsQFibeKRTOhkQ(buttons[num]);
				}
			}
			else
			{
				for (int num2 = 0; num2 < P_7; num2++)
				{
					buttons[num2] = new Button(this, P_10.buttonElementIdentifierIds[num2], "Button " + num2, P_8[num2], (P_9 != null) ? P_9[num2] : new HardwareButtonInfo());
					pMIfsVXUiOvYtrPsQFibeKRTOhkQ(buttons[num2]);
				}
			}
			buttons_readOnly = new ReadOnlyCollection<Button>(buttons);
			hBttiNoJmfaugulEkxDuwwPnNltA = EmptyObjects<IControllerTemplate>.array;
			NDxGWTJnfuODYTJAZeypYtObhiLGA = new ReadOnlyCollection<IControllerTemplate>(hBttiNoJmfaugulEkxDuwwPnNltA);
			if (LocalizationManager.isEnabled && LocalizationManager.autoPrefetch)
			{
				((IfopinoSAuQZnpEvFIfBnubyAxLB)kSIGEgjCAQyKaLydgPhZAbJLcdJx).Localize();
			}
			Connected();
		}

		internal virtual void CpCVLCxmguYfwaCGdHOlxVqCpGLv()
		{
			EbCWSQmumtPLvoukhGGMHWltJtnG = new ControllerIdentifier(this);
		}

		public virtual Element GetElementById(int elementIdentifierId)
		{
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
				return null;
			}
			if (qfUAjoZEkUJBMcgOHFRLtyQzKjdR == null)
			{
				return null;
			}
			int buttonIndex = qfUAjoZEkUJBMcgOHFRLtyQzKjdR.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0)
			{
				return null;
			}
			return buttons[buttonIndex];
		}

		public virtual CompoundElement GetCompoundElementById(int elementIdentifierId)
		{
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
				return null;
			}
			int count = fQJFLvCaxzoKyNbPmsoQbPMVHDYdA.Count;
			for (int i = 0; i < count; i++)
			{
				if (fQJFLvCaxzoKyNbPmsoQbPMVHDYdA[i] != null && fQJFLvCaxzoKyNbPmsoQbPMVHDYdA[i].id == elementIdentifierId)
				{
					return fQJFLvCaxzoKyNbPmsoQbPMVHDYdA[i];
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
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
				return -1;
			}
			return qfUAjoZEkUJBMcgOHFRLtyQzKjdR.GetButtonIndex(elementIdentifierId);
		}

		public ControllerElementIdentifier GetElementIdentifierById(int elementIdentifierId)
		{
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
				return null;
			}
			return qfUAjoZEkUJBMcgOHFRLtyQzKjdR.GetElementIdentifierById(elementIdentifierId);
		}

		public virtual bool GetButton(int index)
		{
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
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
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
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
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
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
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
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
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
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
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
				return false;
			}
			return GetButtonDoublePressHold(index, 0f);
		}

		public virtual bool GetButtonDoublePressHold(int index, float speed)
		{
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
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
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
				return false;
			}
			return GetButtonDoublePressDown(index, 0f);
		}

		public virtual bool GetButtonDoublePressDown(int index, float speed)
		{
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
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
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
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
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
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
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
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
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
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
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
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
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
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
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
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
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
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
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
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
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
				return false;
			}
			int buttonIndex = qfUAjoZEkUJBMcgOHFRLtyQzKjdR.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				return false;
			}
			return buttons[buttonIndex].value;
		}

		public virtual bool GetButtonDownById(int elementIdentifierId)
		{
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
				return false;
			}
			int buttonIndex = qfUAjoZEkUJBMcgOHFRLtyQzKjdR.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				return false;
			}
			return buttons[buttonIndex].justPressed;
		}

		public virtual bool GetButtonUpById(int elementIdentifierId)
		{
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
				return false;
			}
			int buttonIndex = qfUAjoZEkUJBMcgOHFRLtyQzKjdR.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				return false;
			}
			return buttons[buttonIndex].justReleased;
		}

		public virtual bool GetButtonDoublePressHoldById(int elementIdentifierId, float speed)
		{
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
				return false;
			}
			int buttonIndex = qfUAjoZEkUJBMcgOHFRLtyQzKjdR.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				return false;
			}
			return buttons[buttonIndex].DoublePressedAndHeld(speed);
		}

		public virtual bool GetButtonDoublePressDownById(int elementIdentifierId, float speed)
		{
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
				return false;
			}
			int buttonIndex = qfUAjoZEkUJBMcgOHFRLtyQzKjdR.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				return false;
			}
			return buttons[buttonIndex].JustDoublePressed(speed);
		}

		public virtual bool GetButtonDoublePressHoldById(int elementIdentifierId)
		{
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
				return false;
			}
			int buttonIndex = qfUAjoZEkUJBMcgOHFRLtyQzKjdR.GetButtonIndex(elementIdentifierId);
			return GetButtonDoublePressHold(buttonIndex, 0f);
		}

		public virtual bool GetButtonDoublePressDownById(int elementIdentifierId)
		{
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
				return false;
			}
			int buttonIndex = qfUAjoZEkUJBMcgOHFRLtyQzKjdR.GetButtonIndex(elementIdentifierId);
			return GetButtonDoublePressDown(buttonIndex, 0f);
		}

		public virtual bool GetButtonPrevById(int elementIdentifierId)
		{
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
				return false;
			}
			int buttonIndex = qfUAjoZEkUJBMcgOHFRLtyQzKjdR.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				return false;
			}
			return buttons[buttonIndex].valuePrev;
		}

		public virtual double GetButtonTimePressedById(int elementIdentifierId)
		{
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
				return 0.0;
			}
			int buttonIndex = qfUAjoZEkUJBMcgOHFRLtyQzKjdR.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				return 0.0;
			}
			return buttons[buttonIndex].timePressed;
		}

		public virtual double GetButtonTimeUnpressedById(int elementIdentifierId)
		{
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
				return 0.0;
			}
			int buttonIndex = qfUAjoZEkUJBMcgOHFRLtyQzKjdR.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				return 0.0;
			}
			return buttons[buttonIndex].timeUnpressed;
		}

		public virtual double GetButtonLastTimePressedById(int elementIdentifierId)
		{
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
				return 0.0;
			}
			int buttonIndex = qfUAjoZEkUJBMcgOHFRLtyQzKjdR.GetButtonIndex(elementIdentifierId);
			if (buttonIndex < 0 || buttonIndex >= _buttonCount)
			{
				return 0.0;
			}
			return buttons[buttonIndex].lastTimePressed;
		}

		public virtual double GetButtonLastTimeUnpressedById(int elementIdentifierId)
		{
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
				return 0.0;
			}
			int buttonIndex = qfUAjoZEkUJBMcgOHFRLtyQzKjdR.GetButtonIndex(elementIdentifierId);
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
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
				return ControllerPollingInfo.mWifMPEIlKJzBSUffHpDICVvtEhtA();
			}
			UpdatePollingFrameTracking();
			for (int i = 0; i < _buttonCount; i++)
			{
				if (XtLZBzodYmCeHczmaskCagwagzkkA(i, out var num))
				{
					return new ControllerPollingInfo(true, -1, id, _name, _type, ControllerElementType.Button, i, Pole.Positive, qfUAjoZEkUJBMcgOHFRLtyQzKjdR.GetElementIdentifierName(num), num, KeyCode.None);
				}
			}
			return ControllerPollingInfo.mWifMPEIlKJzBSUffHpDICVvtEhtA();
		}

		public virtual ControllerPollingInfo PollForFirstButtonDown()
		{
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
				return ControllerPollingInfo.mWifMPEIlKJzBSUffHpDICVvtEhtA();
			}
			UpdatePollingFrameTracking();
			for (int i = 0; i < _buttonCount; i++)
			{
				if (vyuDXFkJJKuIMXHEVzTYGSYNfNTT(i, out var num))
				{
					return new ControllerPollingInfo(true, -1, id, _name, _type, ControllerElementType.Button, i, Pole.Positive, qfUAjoZEkUJBMcgOHFRLtyQzKjdR.GetElementIdentifierName(num), num, KeyCode.None);
				}
			}
			return ControllerPollingInfo.mWifMPEIlKJzBSUffHpDICVvtEhtA();
		}

		public virtual IEnumerable<ControllerPollingInfo> PollForAllElements()
		{
			return PollForAllButtons();
		}

		public virtual IEnumerable<ControllerPollingInfo> PollForAllElementsDown()
		{
			return PollForAllButtonsDown();
		}

		[IteratorStateMachine(typeof(iovQRssjjuToCtiXCLooxZgiSuWH))]
		public virtual IEnumerable<ControllerPollingInfo> PollForAllButtons()
		{
			return new iovQRssjjuToCtiXCLooxZgiSuWH(-2)
			{
				jfnWnvVEaBfmkPchOfAakbNktroWA = this
			};
		}

		[IteratorStateMachine(typeof(gfEcWRHeyFAosuYGARwXDPtMIVttA))]
		public virtual IEnumerable<ControllerPollingInfo> PollForAllButtonsDown()
		{
			return new gfEcWRHeyFAosuYGARwXDPtMIVttA(-2)
			{
				kGNGYVUsZrLvINYOwXEloPQDLHuc = this
			};
		}

		private bool XtLZBzodYmCeHczmaskCagwagzkkA(int P_0, out int P_1)
		{
			P_1 = -1;
			if (!buttons[P_0].value || buttons[P_0].LZwxGokBTpAKOeMxByhqDlrLgFAT._excludeFromPolling)
			{
				return false;
			}
			P_1 = qfUAjoZEkUJBMcgOHFRLtyQzKjdR.buttonElementIdentifierIds[P_0];
			if (P_1 < 0)
			{
				return false;
			}
			return true;
		}

		private bool vyuDXFkJJKuIMXHEVzTYGSYNfNTT(int P_0, out int P_1)
		{
			P_1 = -1;
			if (!buttons[P_0].justPressed || buttons[P_0].LZwxGokBTpAKOeMxByhqDlrLgFAT._excludeFromPolling)
			{
				return false;
			}
			P_1 = qfUAjoZEkUJBMcgOHFRLtyQzKjdR.buttonElementIdentifierIds[P_0];
			if (P_1 < 0)
			{
				return false;
			}
			return true;
		}

		protected void UpdatePollingFrameTracking()
		{
			if (pReEwWdUeuJHMiVdDrcnAhRtRdJXb == ReInput.currentFrame)
			{
				return;
			}
			PaxMHiWxydwfkBakWiPUtWhBqwQb = pReEwWdUeuJHMiVdDrcnAhRtRdJXb;
			pReEwWdUeuJHMiVdDrcnAhRtRdJXb = ReInput.currentFrame;
			if (!jJaVxXRAGlGenCcVvwqpdifNLvVQA)
			{
				if (yMnQryEwKXmSLSkZpVlqywTeEaTh == uint.MaxValue)
				{
					yMnQryEwKXmSLSkZpVlqywTeEaTh = 0u;
				}
				else
				{
					yMnQryEwKXmSLSkZpVlqywTeEaTh++;
				}
			}
		}

		public virtual double GetLastTimeActive()
		{
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
				return 0.0;
			}
			return GetLastTimeActive(useRawValues: false);
		}

		public virtual double GetLastTimeActive(bool useRawValues)
		{
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
				return 0.0;
			}
			return GetLastTimeAnyButtonPressed();
		}

		public virtual double GetLastTimeAnyElementChanged()
		{
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
				return 0.0;
			}
			return GetLastTimeAnyElementChanged(useRawValues: false);
		}

		public virtual double GetLastTimeAnyElementChanged(bool useRawValues)
		{
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
				return 0.0;
			}
			return GetLastTimeAnyButtonChanged();
		}

		public double GetLastTimeAnyButtonPressed()
		{
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
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
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
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
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
				return null;
			}
			return MSzSKprKifUtmxOJYqUnzDXeHvtJ as T;
		}

		public IControllerTemplate GetTemplate(Guid typeGuid)
		{
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
				return null;
			}
			for (int i = 0; i < hBttiNoJmfaugulEkxDuwwPnNltA.Length; i++)
			{
				if (hBttiNoJmfaugulEkxDuwwPnNltA[i].typeGuid == typeGuid)
				{
					return hBttiNoJmfaugulEkxDuwwPnNltA[i];
				}
			}
			return null;
		}

		public IControllerTemplate GetTemplate(Type type)
		{
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
				return null;
			}
			for (int i = 0; i < hBttiNoJmfaugulEkxDuwwPnNltA.Length; i++)
			{
				if (ReflectionTools.DoesTypeImplement(hBttiNoJmfaugulEkxDuwwPnNltA[i].GetType(), type))
				{
					return hBttiNoJmfaugulEkxDuwwPnNltA[i];
				}
			}
			return null;
		}

		public T GetTemplate<T>() where T : class
		{
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
				return null;
			}
			for (int i = 0; i < hBttiNoJmfaugulEkxDuwwPnNltA.Length; i++)
			{
				if (hBttiNoJmfaugulEkxDuwwPnNltA[i] as T != null)
				{
					return hBttiNoJmfaugulEkxDuwwPnNltA[i] as T;
				}
			}
			return null;
		}

		public bool ImplementsTemplate(Guid typeGuid)
		{
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
				return false;
			}
			for (int i = 0; i < hBttiNoJmfaugulEkxDuwwPnNltA.Length; i++)
			{
				if (hBttiNoJmfaugulEkxDuwwPnNltA[i].typeGuid == typeGuid)
				{
					return true;
				}
			}
			return false;
		}

		public bool ImplementsTemplate(Type type)
		{
			if (ReInput._id != amvEgOgWeoORBWecwIHRbEwcHoDuB)
			{
				ReInput.CheckInitialized(amvEgOgWeoORBWecwIHRbEwcHoDuB);
				return false;
			}
			if (type == null)
			{
				throw new ArgumentNullException("type");
			}
			for (int i = 0; i < hBttiNoJmfaugulEkxDuwwPnNltA.Length; i++)
			{
				if (ReflectionTools.DoesTypeImplement(hBttiNoJmfaugulEkxDuwwPnNltA[i].GetType(), type))
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

		internal void qunDYbEmcxgVAcWnvRKXfnxVfqgRA(IControllerTemplate[] P_0)
		{
			if (P_0 != null)
			{
				hBttiNoJmfaugulEkxDuwwPnNltA = P_0;
				NDxGWTJnfuODYTJAZeypYtObhiLGA = new ReadOnlyCollection<IControllerTemplate>(hBttiNoJmfaugulEkxDuwwPnNltA);
			}
		}

		internal virtual void hdccNRifKnNeMIMmCYJkjUCelZGPA(UpdateLoopType P_0)
		{
			bool num = ReInput.IsInputAllowed(_type);
			int num2 = _buttonCount;
			if (num)
			{
				for (int i = 0; i < num2; i++)
				{
					if (buttons[i].PXIBbobqHpgLOSBLASIrpQiQgxIg <= 0)
					{
						buttons[i].KknekHfCfaOAyFWPFHiholZwGQJTA(P_0, i, EnxeINdfRsPNEfNsWCRpkeCWEWlpA);
					}
				}
			}
			else
			{
				for (int j = 0; j < num2; j++)
				{
					if (buttons[j].PXIBbobqHpgLOSBLASIrpQiQgxIg <= 0)
					{
						buttons[j].mbnOyrGHVsSuNaqSwjQihtXfduxb(P_0);
					}
				}
			}
			if (MSzSKprKifUtmxOJYqUnzDXeHvtJ != null)
			{
				MSzSKprKifUtmxOJYqUnzDXeHvtJ.UpdateData(P_0);
			}
		}

		internal virtual ButtonStateFlags HpZEldNdLxRgzrmHTLDLaNzFqMdR(int P_0)
		{
			if (P_0 < 0 || P_0 >= _buttonCount)
			{
				return ButtonStateFlags.Off;
			}
			return buttons[P_0].hWLgceOZYAqniGkWwHdjVfDFLFhM;
		}

		internal void wZAgFdpWTgDzbPAtkTSJvQdXLMMR(Extension P_0)
		{
			if (P_0 == null)
			{
				MSzSKprKifUtmxOJYqUnzDXeHvtJ = null;
				return;
			}
			if (MSzSKprKifUtmxOJYqUnzDXeHvtJ != null)
			{
				ceQWwFmgSzavmOFjxsbVVXMSrRBU(P_0);
				return;
			}
			P_0.SetController(this);
			MSzSKprKifUtmxOJYqUnzDXeHvtJ = P_0.Clone();
		}

		internal void ceQWwFmgSzavmOFjxsbVVXMSrRBU(Extension P_0)
		{
			if (MSzSKprKifUtmxOJYqUnzDXeHvtJ != null)
			{
				MSzSKprKifUtmxOJYqUnzDXeHvtJ.SetSource(P_0);
				MSzSKprKifUtmxOJYqUnzDXeHvtJ.SetController(this);
				P_0?.SetController(this);
			}
			else
			{
				wZAgFdpWTgDzbPAtkTSJvQdXLMMR(P_0);
			}
		}

		internal virtual void NQeVYgkqiwjcPfmLUdoKHfxQPBEL()
		{
			for (int i = 0; i < _buttonCount; i++)
			{
				if (buttons[i] != null)
				{
					buttons[i].Reset();
				}
			}
			if (EnxeINdfRsPNEfNsWCRpkeCWEWlpA != null)
			{
				EnxeINdfRsPNEfNsWCRpkeCWEWlpA.ClearData();
			}
			if (MSzSKprKifUtmxOJYqUnzDXeHvtJ != null)
			{
				MSzSKprKifUtmxOJYqUnzDXeHvtJ.Clear();
			}
		}

		internal virtual bool mqVKPhaeRMzKymnkzsnkxIOdysds(bool P_0)
		{
			if (aokeGJAmMGXtkZkWaxsTUGzuaXdV == P_0)
			{
				return false;
			}
			if (!P_0)
			{
				NQeVYgkqiwjcPfmLUdoKHfxQPBEL();
			}
			aokeGJAmMGXtkZkWaxsTUGzuaXdV = P_0;
			if (sZGgelaceVahRbyADNcqltySjeQEB != null)
			{
				sZGgelaceVahRbyADNcqltySjeQEB(P_0);
			}
			return true;
		}

		internal virtual void jqLSrLTCddLEpzgJvILfPrtjvnhn(ControllerMap P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			P_0.controllerId = id;
			IList<ActionElementMap> buttonMaps = P_0.ButtonMaps;
			for (int i = 0; i < buttonMaps.Count; i++)
			{
				tdLKgiuKWlzkkJjXwztgjBdYXkPE(P_0, buttonMaps[i]);
			}
			for (int num = buttonMaps.Count - 1; num >= 0; num--)
			{
				if (buttonMaps[num].elementIndex < 0)
				{
					P_0.DeleteElementMap(buttonMaps[num].JtzYMpqdJGMyIjXIPHXXckWafklL);
				}
			}
		}

		internal virtual void tdLKgiuKWlzkkJjXwztgjBdYXkPE(ControllerMap P_0, ActionElementMap P_1)
		{
			if (P_1 != null && P_1._elementType == ControllerElementType.Button)
			{
				P_1.qpQzcYGEaMlrmdrWslIRXltfsMcp(P_0);
			}
		}

		internal bool vbmcnelKUgsFKFaLNCcLsjwpAYBF(ActionElementMap P_0, int P_1, out float P_2, out bool P_3)
		{
			P_3 = false;
			P_2 = 0f;
			if (P_1 != P_0._actionId)
			{
				return false;
			}
			int yBnBsBBQkmlNrgHwodJTdPugtaTMB = P_0.YBnBsBBQkmlNrgHwodJTdPugtaTMB;
			if (yBnBsBBQkmlNrgHwodJTdPugtaTMB < 0 || yBnBsBBQkmlNrgHwodJTdPugtaTMB >= _buttonCount)
			{
				return false;
			}
			P_3 = buttons[yBnBsBBQkmlNrgHwodJTdPugtaTMB].IzBFOXGqxeEFgMpeXZIseJwtFPFcb;
			float num = ((!P_3) ? (buttons[yBnBsBBQkmlNrgHwodJTdPugtaTMB].value ? 1f : 0f) : buttons[yBnBsBBQkmlNrgHwodJTdPugtaTMB].pressure);
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

		internal bool NkQdRnwkFdMIpxtgrAatYeYHtQbd(ActionElementMap P_0, int P_1, bool P_2, out float P_3)
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

		internal void pMIfsVXUiOvYtrPsQFibeKRTOhkQ(Element P_0)
		{
			if (P_0 != null)
			{
				ListTools.AddIfUnique(KBPXIuvxTTmXDQUOOGawwIuTXaOq, P_0);
			}
		}

		internal void GVljbkeDoYqeJxOGVFEfBxBaaTiT(CompoundElement P_0)
		{
			if (P_0 != null)
			{
				ListTools.AddIfUnique(fQJFLvCaxzoKyNbPmsoQbPMVHDYdA, P_0);
			}
		}

		internal virtual Guid MVtBjAHVmKnGznVLtFPKhuoGSdiSc()
		{
			return Guid.Empty;
		}

		internal virtual void LeLYmpHPVPCSNZNverFIBCLjUJnT(bool P_0)
		{
			if (!P_0 && !ReInput.IsInputAllowed(_type) && MSzSKprKifUtmxOJYqUnzDXeHvtJ != null)
			{
				MSzSKprKifUtmxOJYqUnzDXeHvtJ.Clear();
			}
		}

		protected virtual void Connected()
		{
			_isConnected = true;
		}

		protected virtual void Disconnected()
		{
			_isConnected = false;
			if (EnxeINdfRsPNEfNsWCRpkeCWEWlpA != null)
			{
				EnxeINdfRsPNEfNsWCRpkeCWEWlpA.ClearData();
			}
		}

		[CompilerGenerated]
		private void rNKjnfwOsmyVVgpVMDXRnOwVEBkM()
		{
			_ = name;
		}
	}
}
