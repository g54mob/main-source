using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using UnityEngine;

namespace Rewired
{
	public abstract class ControllerTemplate : IControllerTemplate
	{
		internal abstract class gwBXOpXdcaPCdFtopfeMjzVrGimI : IControllerTemplateElement, IControllerTemplateElement_Internal
		{
			private readonly IControllerTemplate rBdHDCfDobOjBUqyNbBnmEluxEvZ;

			private readonly int HZrDwOTOuvYGJkZRWDMDnUPlFNTs;

			private readonly string gbaFwplwRPDIuUufIuWmknaoIHDK;

			private readonly ControllerTemplateElementType OkGTKhIUqsJqQkbQwDsMbAsaAzwbb;

			protected readonly int TcEXPUvjqSTMTFutCAtGRnMeNwub;

			public int id
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return -1;
					}
					return HZrDwOTOuvYGJkZRWDMDnUPlFNTs;
				}
			}

			public string descriptiveName
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return null;
					}
					return gbaFwplwRPDIuUufIuWmknaoIHDK;
				}
			}

			public ControllerTemplateElementType type
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return ControllerTemplateElementType.Axis;
					}
					return OkGTKhIUqsJqQkbQwDsMbAsaAzwbb;
				}
			}

			public IControllerTemplate parent => rBdHDCfDobOjBUqyNbBnmEluxEvZ;

			public abstract int elementCount { get; }

			public abstract IControllerTemplateElementSource source { get; }

			public abstract bool exists { get; }

			protected gwBXOpXdcaPCdFtopfeMjzVrGimI(IControllerTemplate P_0, int P_1, string P_2, ControllerTemplateElementType P_3)
			{
				if (P_0 == null)
				{
					throw new ArgumentNullException("parent");
				}
				rBdHDCfDobOjBUqyNbBnmEluxEvZ = P_0;
				HZrDwOTOuvYGJkZRWDMDnUPlFNTs = P_1;
				gbaFwplwRPDIuUufIuWmknaoIHDK = P_2;
				OkGTKhIUqsJqQkbQwDsMbAsaAzwbb = P_3;
				TcEXPUvjqSTMTFutCAtGRnMeNwub = ReInput.id;
			}

			public abstract IControllerTemplateElement GetElement(int index);

			public abstract int GetElementTargets(ControllerElementTarget find, ref IList<ControllerTemplateElementTarget> list);
		}

		internal abstract class gZQbaqXWBHQndqPaoQZUBUoAmoxT : gwBXOpXdcaPCdFtopfeMjzVrGimI
		{
			protected readonly int taSVMYSBmrCPVFcLRxCMvdtobAfp;

			protected readonly PbLhtDmFPsNazvYLFQBoFqNdAtlL[] pKVjEFfzRXWJtssGHjQAMvVcQJso;

			bool gwBXOpXdcaPCdFtopfeMjzVrGimI.exists
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return false;
					}
					if (pKVjEFfzRXWJtssGHjQAMvVcQJso == null)
					{
						return false;
					}
					for (int i = 0; i < pKVjEFfzRXWJtssGHjQAMvVcQJso.Length; i++)
					{
						if (pKVjEFfzRXWJtssGHjQAMvVcQJso[i].BCuHApOmoSObQBcmCUJCdFCnCAsFA != null)
						{
							return true;
						}
					}
					return false;
				}
			}

			protected gZQbaqXWBHQndqPaoQZUBUoAmoxT(IControllerTemplate P_0, int P_1, string P_2, ControllerTemplateElementType P_3, IList<PbLhtDmFPsNazvYLFQBoFqNdAtlL> P_4)
				: base(P_0, P_1, P_2, P_3)
			{
				pKVjEFfzRXWJtssGHjQAMvVcQJso = ((P_4 != null) ? ListTools.ToArray(P_4) : null);
				taSVMYSBmrCPVFcLRxCMvdtobAfp = ((pKVjEFfzRXWJtssGHjQAMvVcQJso != null) ? pKVjEFfzRXWJtssGHjQAMvVcQJso.Length : 0);
			}
		}

		internal abstract class sNACywUzLRIlnfbDvzRcJlkFTFTb : gZQbaqXWBHQndqPaoQZUBUoAmoxT, IControllerTemplateElement, IControllerTemplateButton, IControllerTemplateAxis
		{
			private KpZHreySesbtLKuRdoZrwgpLSyTA BzUaLEMAzIdLahimlKbygLBhWDUxA;

			private string rEqjlYclMBTuGfiSdYagSTFLfkRH;

			private string fhiGKycLeSGfBCPbjipFXJOZQGAXA;

			public float esvdQDSeoVapiVBnSLWqsHImVLWA
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return 0f;
					}
					if (taSVMYSBmrCPVFcLRxCMvdtobAfp == 1)
					{
						return pKVjEFfzRXWJtssGHjQAMvVcQJso[0].esvdQDSeoVapiVBnSLWqsHImVLWA;
					}
					if (taSVMYSBmrCPVFcLRxCMvdtobAfp == 2)
					{
						float num = pKVjEFfzRXWJtssGHjQAMvVcQJso[0].esvdQDSeoVapiVBnSLWqsHImVLWA;
						float num2 = pKVjEFfzRXWJtssGHjQAMvVcQJso[1].esvdQDSeoVapiVBnSLWqsHImVLWA;
						return MathTools.Clamp(num + num2, -1f, 1f);
					}
					return 0f;
				}
			}

			public float sLALWRKTLxJotpSszSIhCrXmtbUF
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return 0f;
					}
					if (taSVMYSBmrCPVFcLRxCMvdtobAfp == 1)
					{
						return pKVjEFfzRXWJtssGHjQAMvVcQJso[0].sLALWRKTLxJotpSszSIhCrXmtbUF;
					}
					if (taSVMYSBmrCPVFcLRxCMvdtobAfp == 2)
					{
						float num = pKVjEFfzRXWJtssGHjQAMvVcQJso[0].sLALWRKTLxJotpSszSIhCrXmtbUF;
						float num2 = pKVjEFfzRXWJtssGHjQAMvVcQJso[1].sLALWRKTLxJotpSszSIhCrXmtbUF;
						return MathTools.Clamp(num + num2, -1f, 1f);
					}
					return 0f;
				}
			}

			public bool oWEdkgpANxjhVOIcAcKXObeBlSuU
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return false;
					}
					if (taSVMYSBmrCPVFcLRxCMvdtobAfp == 1)
					{
						return pKVjEFfzRXWJtssGHjQAMvVcQJso[0].oWEdkgpANxjhVOIcAcKXObeBlSuU;
					}
					if (taSVMYSBmrCPVFcLRxCMvdtobAfp == 2)
					{
						if (!pKVjEFfzRXWJtssGHjQAMvVcQJso[0].oWEdkgpANxjhVOIcAcKXObeBlSuU)
						{
							return pKVjEFfzRXWJtssGHjQAMvVcQJso[1].oWEdkgpANxjhVOIcAcKXObeBlSuU;
						}
						return true;
					}
					return false;
				}
			}

			public bool mjwdDosldubIUAhRxvRGpnamBQgm
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return false;
					}
					if (taSVMYSBmrCPVFcLRxCMvdtobAfp == 1)
					{
						return pKVjEFfzRXWJtssGHjQAMvVcQJso[0].mjwdDosldubIUAhRxvRGpnamBQgm;
					}
					if (taSVMYSBmrCPVFcLRxCMvdtobAfp == 2)
					{
						if (!pKVjEFfzRXWJtssGHjQAMvVcQJso[0].mjwdDosldubIUAhRxvRGpnamBQgm)
						{
							return pKVjEFfzRXWJtssGHjQAMvVcQJso[1].mjwdDosldubIUAhRxvRGpnamBQgm;
						}
						return true;
					}
					return false;
				}
			}

			string IControllerTemplateAxis.positiveDescriptiveName
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return null;
					}
					return rEqjlYclMBTuGfiSdYagSTFLfkRH;
				}
			}

			string IControllerTemplateAxis.negativeDescriptiveName
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return null;
					}
					return fhiGKycLeSGfBCPbjipFXJOZQGAXA;
				}
			}

			float IControllerTemplateAxis.value
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return 0f;
					}
					return esvdQDSeoVapiVBnSLWqsHImVLWA;
				}
			}

			float IControllerTemplateAxis.valuePrev
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return 0f;
					}
					return sLALWRKTLxJotpSszSIhCrXmtbUF;
				}
			}

			IControllerTemplateAxisSource IControllerTemplateAxis.source
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return null;
					}
					return BzUaLEMAzIdLahimlKbygLBhWDUxA;
				}
			}

			bool IControllerTemplateButton.value
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return false;
					}
					return oWEdkgpANxjhVOIcAcKXObeBlSuU;
				}
			}

			bool IControllerTemplateButton.valuePrev
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return false;
					}
					return mjwdDosldubIUAhRxvRGpnamBQgm;
				}
			}

			bool IControllerTemplateButton.justPressed
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return false;
					}
					if (taSVMYSBmrCPVFcLRxCMvdtobAfp == 1)
					{
						return pKVjEFfzRXWJtssGHjQAMvVcQJso[0].yjBXVGcweMRmHAeJWtlsivXQHOYK;
					}
					if (taSVMYSBmrCPVFcLRxCMvdtobAfp == 2)
					{
						if (!pKVjEFfzRXWJtssGHjQAMvVcQJso[0].yjBXVGcweMRmHAeJWtlsivXQHOYK || pKVjEFfzRXWJtssGHjQAMvVcQJso[1].mjwdDosldubIUAhRxvRGpnamBQgm)
						{
							if (pKVjEFfzRXWJtssGHjQAMvVcQJso[1].yjBXVGcweMRmHAeJWtlsivXQHOYK)
							{
								return !pKVjEFfzRXWJtssGHjQAMvVcQJso[0].mjwdDosldubIUAhRxvRGpnamBQgm;
							}
							return false;
						}
						return true;
					}
					return false;
				}
			}

			bool IControllerTemplateButton.justReleased
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return false;
					}
					if (taSVMYSBmrCPVFcLRxCMvdtobAfp == 1)
					{
						return pKVjEFfzRXWJtssGHjQAMvVcQJso[0].pmvZevAaExDOXoNPFOwXhCJOdDQl;
					}
					if (taSVMYSBmrCPVFcLRxCMvdtobAfp == 2)
					{
						if (!pKVjEFfzRXWJtssGHjQAMvVcQJso[0].pmvZevAaExDOXoNPFOwXhCJOdDQl || pKVjEFfzRXWJtssGHjQAMvVcQJso[1].oWEdkgpANxjhVOIcAcKXObeBlSuU)
						{
							if (pKVjEFfzRXWJtssGHjQAMvVcQJso[1].pmvZevAaExDOXoNPFOwXhCJOdDQl)
							{
								return !pKVjEFfzRXWJtssGHjQAMvVcQJso[0].oWEdkgpANxjhVOIcAcKXObeBlSuU;
							}
							return false;
						}
						return true;
					}
					return false;
				}
			}

			bool IControllerTemplateButton.justChangedState
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return false;
					}
					return oWEdkgpANxjhVOIcAcKXObeBlSuU != mjwdDosldubIUAhRxvRGpnamBQgm;
				}
			}

			float IControllerTemplateButton.pressure
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return 0f;
					}
					return esvdQDSeoVapiVBnSLWqsHImVLWA;
				}
			}

			float IControllerTemplateButton.pressurePrev
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return 0f;
					}
					return sLALWRKTLxJotpSszSIhCrXmtbUF;
				}
			}

			IControllerTemplateButtonSource IControllerTemplateButton.source
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return null;
					}
					return BzUaLEMAzIdLahimlKbygLBhWDUxA;
				}
			}

			public override IControllerTemplateElementSource source
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return null;
					}
					return BzUaLEMAzIdLahimlKbygLBhWDUxA;
				}
			}

			public override int elementCount => 0;

			public IControllerTemplateAxis AsAxis
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return null;
					}
					return this;
				}
			}

			public IControllerTemplateButton AsButton
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return null;
					}
					return this;
				}
			}

			protected sNACywUzLRIlnfbDvzRcJlkFTFTb(IControllerTemplate P_0, int P_1, string P_2, string P_3, string P_4, ControllerTemplateElementType P_5, KpZHreySesbtLKuRdoZrwgpLSyTA P_6, IList<PbLhtDmFPsNazvYLFQBoFqNdAtlL> P_7)
				: base(P_0, P_1, P_2, P_5, P_7)
			{
				if (P_7 != null && P_7.Count > 2)
				{
					throw new ArgumentOutOfRangeException("sourceElements.Count must be <= 2.");
				}
				if (P_6 == null)
				{
					throw new ArgumentNullException("target");
				}
				BzUaLEMAzIdLahimlKbygLBhWDUxA = P_6;
				rEqjlYclMBTuGfiSdYagSTFLfkRH = P_3;
				fhiGKycLeSGfBCPbjipFXJOZQGAXA = P_4;
			}

			string IControllerTemplateAxis.GetDescriptiveName(AxisRange axisRange)
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					return null;
				}
				return axisRange switch
				{
					AxisRange.Full => base.descriptiveName, 
					AxisRange.Positive => rEqjlYclMBTuGfiSdYagSTFLfkRH, 
					AxisRange.Negative => fhiGKycLeSGfBCPbjipFXJOZQGAXA, 
					_ => throw new NotImplementedException(), 
				};
			}

			public override IControllerTemplateElement GetElement(int index)
			{
				return null;
			}

			public override int GetElementTargets(ControllerElementTarget find, ref IList<ControllerTemplateElementTarget> list)
			{
				if (find.elementIdentifierId < 0)
				{
					return 0;
				}
				int num = 0;
				switch (base.type)
				{
				case ControllerTemplateElementType.Axis:
				{
					IControllerTemplateAxisSource bzUaLEMAzIdLahimlKbygLBhWDUxA = BzUaLEMAzIdLahimlKbygLBhWDUxA;
					if (bzUaLEMAzIdLahimlKbygLBhWDUxA.splitAxis)
					{
						if (UcxGIJfLBVbsDJsSkLTzUiQTJiEVA(find, bzUaLEMAzIdLahimlKbygLBhWDUxA.positiveTarget))
						{
							ListTools.AddAndCreateList(ref list, new ControllerTemplateElementTarget(this, AxisRange.Positive));
							num++;
						}
						if (UcxGIJfLBVbsDJsSkLTzUiQTJiEVA(find, bzUaLEMAzIdLahimlKbygLBhWDUxA.negativeTarget))
						{
							ListTools.AddAndCreateList(ref list, new ControllerTemplateElementTarget(this, AxisRange.Negative));
							num++;
						}
					}
					else if (UcxGIJfLBVbsDJsSkLTzUiQTJiEVA(find, bzUaLEMAzIdLahimlKbygLBhWDUxA.fullTarget))
					{
						ListTools.AddAndCreateList(ref list, new ControllerTemplateElementTarget(this, find.axisRange));
						num++;
					}
					break;
				}
				case ControllerTemplateElementType.Button:
					if (UcxGIJfLBVbsDJsSkLTzUiQTJiEVA(find, ((IControllerTemplateButtonSource)BzUaLEMAzIdLahimlKbygLBhWDUxA).target))
					{
						ListTools.AddAndCreateList(ref list, new ControllerTemplateElementTarget(this, AxisRange.Full));
						num++;
					}
					break;
				default:
					throw new NotImplementedException();
				}
				return num;
			}

			private static bool UcxGIJfLBVbsDJsSkLTzUiQTJiEVA(ControllerElementTarget P_0, IControllerElementTarget P_1)
			{
				if (P_1.elementIdentifierId != P_0.elementIdentifierId)
				{
					return false;
				}
				switch (P_1.elementType)
				{
				case ControllerElementType.Axis:
				{
					AxisRange axisRange = P_1.axisRange;
					if (axisRange == AxisRange.Full)
					{
						return true;
					}
					if (axisRange == P_0.axisRange)
					{
						return true;
					}
					return false;
				}
				case ControllerElementType.Button:
					return true;
				default:
					throw new NotImplementedException();
				}
			}
		}

		internal sealed class ZLOgUXjjWrIpfPEbmgeGsxJWJjEy : sNACywUzLRIlnfbDvzRcJlkFTFTb
		{
			public ZLOgUXjjWrIpfPEbmgeGsxJWJjEy(IControllerTemplate P_0, int P_1, string P_2, string P_3, string P_4, KpZHreySesbtLKuRdoZrwgpLSyTA P_5, IList<PbLhtDmFPsNazvYLFQBoFqNdAtlL> P_6)
				: base(P_0, P_1, P_2, P_3, P_4, ControllerTemplateElementType.Axis, P_5, P_6)
			{
				if (P_6 != null && P_6.Count > 2)
				{
					throw new ArgumentOutOfRangeException("sourceElements.Count must be <= 2.");
				}
			}

			internal static ZLOgUXjjWrIpfPEbmgeGsxJWJjEy ckrUQVcMUnHdCWgDQIywBRRTSKOn(IControllerTemplate P_0)
			{
				return new ZLOgUXjjWrIpfPEbmgeGsxJWJjEy(P_0, -1, string.Empty, string.Empty, string.Empty, KpZHreySesbtLKuRdoZrwgpLSyTA.ckrUQVcMUnHdCWgDQIywBRRTSKOn(ControllerTemplateElementType.Axis), null);
			}
		}

		internal sealed class yzeaXMAenzWpurIfbwmsEFPXmIPUA : sNACywUzLRIlnfbDvzRcJlkFTFTb
		{
			public yzeaXMAenzWpurIfbwmsEFPXmIPUA(IControllerTemplate P_0, int P_1, string P_2, string P_3, string P_4, KpZHreySesbtLKuRdoZrwgpLSyTA P_5, IList<PbLhtDmFPsNazvYLFQBoFqNdAtlL> P_6)
				: base(P_0, P_1, P_2, P_3, P_4, ControllerTemplateElementType.Button, P_5, P_6)
			{
				if (P_6 != null && P_6.Count > 1)
				{
					throw new ArgumentOutOfRangeException("sourceElements.Count must be <= 1.");
				}
			}

			internal static yzeaXMAenzWpurIfbwmsEFPXmIPUA ckrUQVcMUnHdCWgDQIywBRRTSKOn(IControllerTemplate P_0)
			{
				return new yzeaXMAenzWpurIfbwmsEFPXmIPUA(P_0, -1, string.Empty, string.Empty, string.Empty, KpZHreySesbtLKuRdoZrwgpLSyTA.ckrUQVcMUnHdCWgDQIywBRRTSKOn(ControllerTemplateElementType.Button), null);
			}
		}

		internal abstract class iqvTAvaOEKbSYfnUTtlbTFLCZR : gwBXOpXdcaPCdFtopfeMjzVrGimI
		{
			protected readonly int kiYHfahFeDPjHhkmohjSmWVgsjLv;

			protected readonly gwBXOpXdcaPCdFtopfeMjzVrGimI[] aUQWeyXieBvNOUAjqzTkUKmMbRkq;

			bool gwBXOpXdcaPCdFtopfeMjzVrGimI.exists
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return false;
					}
					for (int i = 0; i < kiYHfahFeDPjHhkmohjSmWVgsjLv; i++)
					{
						if (aUQWeyXieBvNOUAjqzTkUKmMbRkq[i].exists)
						{
							return true;
						}
					}
					return false;
				}
			}

			IControllerTemplateElementSource gwBXOpXdcaPCdFtopfeMjzVrGimI.source
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return null;
					}
					return null;
				}
			}

			int gwBXOpXdcaPCdFtopfeMjzVrGimI.elementCount => kiYHfahFeDPjHhkmohjSmWVgsjLv;

			protected iqvTAvaOEKbSYfnUTtlbTFLCZR(IControllerTemplate P_0, int P_1, string P_2, ControllerTemplateElementType P_3, gwBXOpXdcaPCdFtopfeMjzVrGimI[] P_4)
				: base(P_0, P_1, P_2, P_3)
			{
				if (P_4 == null)
				{
					throw new ArgumentNullException("elements");
				}
				if (P_4.Length == 0)
				{
					throw new ArgumentException("elements.Length is zero.");
				}
				for (int i = 0; i < P_4.Length; i++)
				{
					if (P_4[i] == null)
					{
						throw new ArgumentNullException("elements contains a null entry.");
					}
				}
				aUQWeyXieBvNOUAjqzTkUKmMbRkq = P_4;
				kiYHfahFeDPjHhkmohjSmWVgsjLv = P_4.Length;
			}

			public virtual IControllerTemplateElement eFnogOZmzyuQdEpygQflSqDcOeKp(int P_0)
			{
				return aUQWeyXieBvNOUAjqzTkUKmMbRkq[P_0];
			}

			public virtual int oGlNETPqOagBCKIXOEZFbnAgvWBIA(ControllerElementTarget P_0, ref IList<ControllerTemplateElementTarget> P_1)
			{
				int num = 0;
				for (int i = 0; i < aUQWeyXieBvNOUAjqzTkUKmMbRkq.Length; i++)
				{
					num += aUQWeyXieBvNOUAjqzTkUKmMbRkq[i].GetElementTargets(P_0, ref P_1);
				}
				return num;
			}
		}

		internal abstract class esTNGvLAqbTZOoFAXRFbFhJiHsnI : iqvTAvaOEKbSYfnUTtlbTFLCZR, IControllerTemplateElement, IControllerTemplateAxis2D
		{
			protected const int KvzFBvQNWpBwtfGBziXAIZsXdPqpA = 0;

			protected const int beoJeCBfCSvBoiqEuUIgxEmrofGJ = 1;

			protected const int YWRtWKbIgqRwyNetoDlDhiZglSfoA = 2;

			public Vector2 value
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return Vector2.zero;
					}
					return new Vector2((kiYHfahFeDPjHhkmohjSmWVgsjLv > 0) ? ((sNACywUzLRIlnfbDvzRcJlkFTFTb)aUQWeyXieBvNOUAjqzTkUKmMbRkq[0]).esvdQDSeoVapiVBnSLWqsHImVLWA : 0f, (kiYHfahFeDPjHhkmohjSmWVgsjLv > 1) ? ((sNACywUzLRIlnfbDvzRcJlkFTFTb)aUQWeyXieBvNOUAjqzTkUKmMbRkq[1]).esvdQDSeoVapiVBnSLWqsHImVLWA : 0f);
				}
			}

			public Vector2 valuePrev
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return Vector2.zero;
					}
					return new Vector2((kiYHfahFeDPjHhkmohjSmWVgsjLv > 0) ? ((sNACywUzLRIlnfbDvzRcJlkFTFTb)aUQWeyXieBvNOUAjqzTkUKmMbRkq[0]).sLALWRKTLxJotpSszSIhCrXmtbUF : 0f, (kiYHfahFeDPjHhkmohjSmWVgsjLv > 1) ? ((sNACywUzLRIlnfbDvzRcJlkFTFTb)aUQWeyXieBvNOUAjqzTkUKmMbRkq[1]).sLALWRKTLxJotpSszSIhCrXmtbUF : 0f);
				}
			}

			public IControllerTemplateAxis horizontal
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return null;
					}
					return (IControllerTemplateAxis)aUQWeyXieBvNOUAjqzTkUKmMbRkq[0];
				}
			}

			public IControllerTemplateAxis vertical
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return null;
					}
					return (IControllerTemplateAxis)aUQWeyXieBvNOUAjqzTkUKmMbRkq[1];
				}
			}

			protected esTNGvLAqbTZOoFAXRFbFhJiHsnI(IControllerTemplate P_0, int P_1, string P_2, ControllerTemplateElementType P_3, gwBXOpXdcaPCdFtopfeMjzVrGimI[] P_4)
				: base(P_0, P_1, P_2, P_3, P_4)
			{
			}
		}

		internal abstract class eATkOCxXlFfCfRgULMWYXmjrksKk : iqvTAvaOEKbSYfnUTtlbTFLCZR, IControllerTemplateElement, IControllerTemplateAxis3D
		{
			protected const int KvzFBvQNWpBwtfGBziXAIZsXdPqpA = 0;

			protected const int beoJeCBfCSvBoiqEuUIgxEmrofGJ = 1;

			protected const int tjNXwmbOqxVbNpOFzkVhvDJofaUfA = 2;

			protected const int YWRtWKbIgqRwyNetoDlDhiZglSfoA = 3;

			public Vector3 value
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return Vector3.zero;
					}
					return new Vector3((kiYHfahFeDPjHhkmohjSmWVgsjLv > 0) ? ((sNACywUzLRIlnfbDvzRcJlkFTFTb)aUQWeyXieBvNOUAjqzTkUKmMbRkq[0]).esvdQDSeoVapiVBnSLWqsHImVLWA : 0f, (kiYHfahFeDPjHhkmohjSmWVgsjLv > 1) ? ((sNACywUzLRIlnfbDvzRcJlkFTFTb)aUQWeyXieBvNOUAjqzTkUKmMbRkq[1]).esvdQDSeoVapiVBnSLWqsHImVLWA : 0f, (kiYHfahFeDPjHhkmohjSmWVgsjLv > 2) ? ((sNACywUzLRIlnfbDvzRcJlkFTFTb)aUQWeyXieBvNOUAjqzTkUKmMbRkq[2]).esvdQDSeoVapiVBnSLWqsHImVLWA : 0f);
				}
			}

			public Vector3 valuePrev
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return Vector3.zero;
					}
					return new Vector3((kiYHfahFeDPjHhkmohjSmWVgsjLv > 0) ? ((sNACywUzLRIlnfbDvzRcJlkFTFTb)aUQWeyXieBvNOUAjqzTkUKmMbRkq[0]).sLALWRKTLxJotpSszSIhCrXmtbUF : 0f, (kiYHfahFeDPjHhkmohjSmWVgsjLv > 1) ? ((sNACywUzLRIlnfbDvzRcJlkFTFTb)aUQWeyXieBvNOUAjqzTkUKmMbRkq[1]).sLALWRKTLxJotpSszSIhCrXmtbUF : 0f, (kiYHfahFeDPjHhkmohjSmWVgsjLv > 2) ? ((sNACywUzLRIlnfbDvzRcJlkFTFTb)aUQWeyXieBvNOUAjqzTkUKmMbRkq[2]).sLALWRKTLxJotpSszSIhCrXmtbUF : 0f);
				}
			}

			public IControllerTemplateAxis horizontal
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return null;
					}
					return (IControllerTemplateAxis)aUQWeyXieBvNOUAjqzTkUKmMbRkq[0];
				}
			}

			public IControllerTemplateAxis vertical
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return null;
					}
					return (IControllerTemplateAxis)aUQWeyXieBvNOUAjqzTkUKmMbRkq[1];
				}
			}

			public IControllerTemplateAxis depth
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return null;
					}
					return (IControllerTemplateAxis)aUQWeyXieBvNOUAjqzTkUKmMbRkq[2];
				}
			}

			protected eATkOCxXlFfCfRgULMWYXmjrksKk(IControllerTemplate P_0, int P_1, string P_2, ControllerTemplateElementType P_3, gwBXOpXdcaPCdFtopfeMjzVrGimI[] P_4)
				: base(P_0, P_1, P_2, P_3, P_4)
			{
			}
		}

		internal abstract class OitTJKMbgxCqxEiMofopDYqFnPOK : iqvTAvaOEKbSYfnUTtlbTFLCZR, IControllerTemplateElement, IControllerTemplateAxis6D
		{
			protected const int yvXbqGKCSGLKdyEsScwEgEquZFUrA = 0;

			protected const int nzKcfYrDpmfCUHKocQixVxLLNpOG = 1;

			protected const int SdaeRGvFwlbvUabvyJCNTJmYCcoY = 2;

			protected const int nWeatfAXyAuBsPsShlpAAHVeCCCMb = 3;

			protected const int ILPWrOCcbcIBeYSAhuocterTQVtb = 4;

			protected const int UnoERIzJrPfETHzxfAuFBdQGUCUic = 5;

			protected const int YWRtWKbIgqRwyNetoDlDhiZglSfoA = 6;

			public Vector3 position
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return Vector3.zero;
					}
					return new Vector3((kiYHfahFeDPjHhkmohjSmWVgsjLv > 0) ? ((sNACywUzLRIlnfbDvzRcJlkFTFTb)aUQWeyXieBvNOUAjqzTkUKmMbRkq[0]).esvdQDSeoVapiVBnSLWqsHImVLWA : 0f, (kiYHfahFeDPjHhkmohjSmWVgsjLv > 1) ? ((sNACywUzLRIlnfbDvzRcJlkFTFTb)aUQWeyXieBvNOUAjqzTkUKmMbRkq[1]).esvdQDSeoVapiVBnSLWqsHImVLWA : 0f, (kiYHfahFeDPjHhkmohjSmWVgsjLv > 2) ? ((sNACywUzLRIlnfbDvzRcJlkFTFTb)aUQWeyXieBvNOUAjqzTkUKmMbRkq[2]).esvdQDSeoVapiVBnSLWqsHImVLWA : 0f);
				}
			}

			public Vector3 positionPrev
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return Vector3.zero;
					}
					return new Vector3((kiYHfahFeDPjHhkmohjSmWVgsjLv > 0) ? ((sNACywUzLRIlnfbDvzRcJlkFTFTb)aUQWeyXieBvNOUAjqzTkUKmMbRkq[0]).sLALWRKTLxJotpSszSIhCrXmtbUF : 0f, (kiYHfahFeDPjHhkmohjSmWVgsjLv > 1) ? ((sNACywUzLRIlnfbDvzRcJlkFTFTb)aUQWeyXieBvNOUAjqzTkUKmMbRkq[1]).sLALWRKTLxJotpSszSIhCrXmtbUF : 0f, (kiYHfahFeDPjHhkmohjSmWVgsjLv > 2) ? ((sNACywUzLRIlnfbDvzRcJlkFTFTb)aUQWeyXieBvNOUAjqzTkUKmMbRkq[2]).sLALWRKTLxJotpSszSIhCrXmtbUF : 0f);
				}
			}

			public Vector3 rotation
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return Vector3.zero;
					}
					return new Vector3((kiYHfahFeDPjHhkmohjSmWVgsjLv > 3) ? ((sNACywUzLRIlnfbDvzRcJlkFTFTb)aUQWeyXieBvNOUAjqzTkUKmMbRkq[3]).esvdQDSeoVapiVBnSLWqsHImVLWA : 0f, (kiYHfahFeDPjHhkmohjSmWVgsjLv > 4) ? ((sNACywUzLRIlnfbDvzRcJlkFTFTb)aUQWeyXieBvNOUAjqzTkUKmMbRkq[4]).esvdQDSeoVapiVBnSLWqsHImVLWA : 0f, (kiYHfahFeDPjHhkmohjSmWVgsjLv > 5) ? ((sNACywUzLRIlnfbDvzRcJlkFTFTb)aUQWeyXieBvNOUAjqzTkUKmMbRkq[5]).esvdQDSeoVapiVBnSLWqsHImVLWA : 0f);
				}
			}

			public Vector3 rotationPrev
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return Vector3.zero;
					}
					return new Vector3((kiYHfahFeDPjHhkmohjSmWVgsjLv > 3) ? ((sNACywUzLRIlnfbDvzRcJlkFTFTb)aUQWeyXieBvNOUAjqzTkUKmMbRkq[3]).sLALWRKTLxJotpSszSIhCrXmtbUF : 0f, (kiYHfahFeDPjHhkmohjSmWVgsjLv > 4) ? ((sNACywUzLRIlnfbDvzRcJlkFTFTb)aUQWeyXieBvNOUAjqzTkUKmMbRkq[4]).sLALWRKTLxJotpSszSIhCrXmtbUF : 0f, (kiYHfahFeDPjHhkmohjSmWVgsjLv > 5) ? ((sNACywUzLRIlnfbDvzRcJlkFTFTb)aUQWeyXieBvNOUAjqzTkUKmMbRkq[5]).sLALWRKTLxJotpSszSIhCrXmtbUF : 0f);
				}
			}

			public IControllerTemplateAxis positionX
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return null;
					}
					return (IControllerTemplateAxis)aUQWeyXieBvNOUAjqzTkUKmMbRkq[0];
				}
			}

			public IControllerTemplateAxis positionY
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return null;
					}
					return (IControllerTemplateAxis)aUQWeyXieBvNOUAjqzTkUKmMbRkq[1];
				}
			}

			public IControllerTemplateAxis positionZ
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return null;
					}
					return (IControllerTemplateAxis)aUQWeyXieBvNOUAjqzTkUKmMbRkq[2];
				}
			}

			public IControllerTemplateAxis rotationX
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return null;
					}
					return (IControllerTemplateAxis)aUQWeyXieBvNOUAjqzTkUKmMbRkq[3];
				}
			}

			public IControllerTemplateAxis rotationY
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return null;
					}
					return (IControllerTemplateAxis)aUQWeyXieBvNOUAjqzTkUKmMbRkq[4];
				}
			}

			public IControllerTemplateAxis rotationZ
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return null;
					}
					return (IControllerTemplateAxis)aUQWeyXieBvNOUAjqzTkUKmMbRkq[5];
				}
			}

			protected OitTJKMbgxCqxEiMofopDYqFnPOK(IControllerTemplate P_0, int P_1, string P_2, ControllerTemplateElementType P_3, gwBXOpXdcaPCdFtopfeMjzVrGimI[] P_4)
				: base(P_0, P_1, P_2, P_3, P_4)
			{
			}
		}

		internal sealed class WUbLoAAsDTcFlixjKBKxiuRFEKFKB : eATkOCxXlFfCfRgULMWYXmjrksKk, IControllerTemplateElement, IControllerTemplateStick
		{
			private new const int YWRtWKbIgqRwyNetoDlDhiZglSfoA = 3;

			public IControllerTemplateAxis rotation
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return null;
					}
					return (IControllerTemplateAxis)aUQWeyXieBvNOUAjqzTkUKmMbRkq[2];
				}
			}

			private WUbLoAAsDTcFlixjKBKxiuRFEKFKB(IControllerTemplate P_0, int P_1, string P_2, gwBXOpXdcaPCdFtopfeMjzVrGimI[] P_3)
				: base(P_0, P_1, P_2, ControllerTemplateElementType.Stick, P_3)
			{
				if (P_3.Length != 3)
				{
					throw new ArgumentException("elements.Length must be " + 3);
				}
			}

			public WUbLoAAsDTcFlixjKBKxiuRFEKFKB(IControllerTemplate P_0, int P_1, string P_2, sNACywUzLRIlnfbDvzRcJlkFTFTb P_3, sNACywUzLRIlnfbDvzRcJlkFTFTb P_4, sNACywUzLRIlnfbDvzRcJlkFTFTb P_5)
				: this(P_0, P_1, P_2, new gwBXOpXdcaPCdFtopfeMjzVrGimI[3] { P_3, P_4, P_5 })
			{
			}
		}

		internal sealed class HiGXBsqDccjqVGuItfKobymTTZqJ : esTNGvLAqbTZOoFAXRFbFhJiHsnI, IControllerTemplateElement, IControllerTemplateThumbStick
		{
			private const int IKmfvOBITGILPenJBKoBxYDRBmLc = 2;

			private new const int YWRtWKbIgqRwyNetoDlDhiZglSfoA = 3;

			public IControllerTemplateButton press
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return null;
					}
					return (IControllerTemplateButton)aUQWeyXieBvNOUAjqzTkUKmMbRkq[2];
				}
			}

			private HiGXBsqDccjqVGuItfKobymTTZqJ(IControllerTemplate P_0, int P_1, string P_2, gwBXOpXdcaPCdFtopfeMjzVrGimI[] P_3)
				: base(P_0, P_1, P_2, ControllerTemplateElementType.ThumbStick, P_3)
			{
				if (P_3.Length != 3)
				{
					throw new ArgumentException("elements.Length must be " + 3);
				}
			}

			internal HiGXBsqDccjqVGuItfKobymTTZqJ(IControllerTemplate P_0, int P_1, string P_2, sNACywUzLRIlnfbDvzRcJlkFTFTb P_3, sNACywUzLRIlnfbDvzRcJlkFTFTb P_4, sNACywUzLRIlnfbDvzRcJlkFTFTb P_5)
				: this(P_0, P_1, P_2, new gwBXOpXdcaPCdFtopfeMjzVrGimI[3] { P_3, P_4, P_5 })
			{
			}
		}

		internal sealed class dbNLfLVNvcXaUpSDKahiFuenWaf : iqvTAvaOEKbSYfnUTtlbTFLCZR, IControllerTemplateElement, IControllerTemplateDPad
		{
			private const int ORYfOycqcJWkBthpFFuEOJrZziIh = 0;

			private const int PGUaUqHMOmajPApKidHCJNhDfwpac = 1;

			private const int hbWwcKoFZfzdEpQbhTkKYJSWmmCH = 2;

			private const int VYmonlrhYpdcMdJxrWruqlZUaXgr = 3;

			private const int lLFdQstqcvCZIpCGqiSNVTBOyZgu = 4;

			private const int YWRtWKbIgqRwyNetoDlDhiZglSfoA = 5;

			public Vector2 value
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return Vector2.zero;
					}
					return new Vector2(MathTools.Clamp(((sNACywUzLRIlnfbDvzRcJlkFTFTb)aUQWeyXieBvNOUAjqzTkUKmMbRkq[0]).esvdQDSeoVapiVBnSLWqsHImVLWA + ((sNACywUzLRIlnfbDvzRcJlkFTFTb)aUQWeyXieBvNOUAjqzTkUKmMbRkq[2]).esvdQDSeoVapiVBnSLWqsHImVLWA * -1f, -1f, 1f), MathTools.Clamp(((sNACywUzLRIlnfbDvzRcJlkFTFTb)aUQWeyXieBvNOUAjqzTkUKmMbRkq[3]).esvdQDSeoVapiVBnSLWqsHImVLWA * -1f + ((sNACywUzLRIlnfbDvzRcJlkFTFTb)aUQWeyXieBvNOUAjqzTkUKmMbRkq[1]).esvdQDSeoVapiVBnSLWqsHImVLWA, -1f, 1f));
				}
			}

			public Vector2 valuePrev
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return Vector2.zero;
					}
					return new Vector2(MathTools.Clamp(((sNACywUzLRIlnfbDvzRcJlkFTFTb)aUQWeyXieBvNOUAjqzTkUKmMbRkq[0]).sLALWRKTLxJotpSszSIhCrXmtbUF + ((sNACywUzLRIlnfbDvzRcJlkFTFTb)aUQWeyXieBvNOUAjqzTkUKmMbRkq[2]).sLALWRKTLxJotpSszSIhCrXmtbUF * -1f, -1f, 1f), MathTools.Clamp(((sNACywUzLRIlnfbDvzRcJlkFTFTb)aUQWeyXieBvNOUAjqzTkUKmMbRkq[3]).sLALWRKTLxJotpSszSIhCrXmtbUF * -1f + ((sNACywUzLRIlnfbDvzRcJlkFTFTb)aUQWeyXieBvNOUAjqzTkUKmMbRkq[1]).sLALWRKTLxJotpSszSIhCrXmtbUF, -1f, 1f));
				}
			}

			public IControllerTemplateButton up
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return null;
					}
					return (IControllerTemplateButton)aUQWeyXieBvNOUAjqzTkUKmMbRkq[0];
				}
			}

			public IControllerTemplateButton right
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return null;
					}
					return (IControllerTemplateButton)aUQWeyXieBvNOUAjqzTkUKmMbRkq[1];
				}
			}

			public IControllerTemplateButton down
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return null;
					}
					return (IControllerTemplateButton)aUQWeyXieBvNOUAjqzTkUKmMbRkq[2];
				}
			}

			public IControllerTemplateButton left
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return null;
					}
					return (IControllerTemplateButton)aUQWeyXieBvNOUAjqzTkUKmMbRkq[3];
				}
			}

			public IControllerTemplateButton press
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return null;
					}
					return (IControllerTemplateButton)aUQWeyXieBvNOUAjqzTkUKmMbRkq[4];
				}
			}

			private dbNLfLVNvcXaUpSDKahiFuenWaf(IControllerTemplate P_0, int P_1, string P_2, gwBXOpXdcaPCdFtopfeMjzVrGimI[] P_3)
				: base(P_0, P_1, P_2, ControllerTemplateElementType.DPad, P_3)
			{
				if (P_3.Length != 5)
				{
					throw new ArgumentException("elements.Length must be " + 5);
				}
			}

			internal dbNLfLVNvcXaUpSDKahiFuenWaf(IControllerTemplate P_0, int P_1, string P_2, sNACywUzLRIlnfbDvzRcJlkFTFTb P_3, sNACywUzLRIlnfbDvzRcJlkFTFTb P_4, sNACywUzLRIlnfbDvzRcJlkFTFTb P_5, sNACywUzLRIlnfbDvzRcJlkFTFTb P_6, sNACywUzLRIlnfbDvzRcJlkFTFTb P_7)
				: this(P_0, P_1, P_2, new gwBXOpXdcaPCdFtopfeMjzVrGimI[5] { P_3, P_4, P_5, P_6, P_7 })
			{
			}
		}

		internal sealed class mBBKIVYdbjBDNmrZzdwurUheBAABA : iqvTAvaOEKbSYfnUTtlbTFLCZR, IControllerTemplateElement, IControllerTemplateThrottle
		{
			private const int tPycErcAGxMDCuYgNSYetEEfgmmEb = 0;

			private const int qHzpcWedrHyeEkwxUHjaKZmDVeAb = 1;

			private const int YWRtWKbIgqRwyNetoDlDhiZglSfoA = 2;

			public float value
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return 0f;
					}
					return ((sNACywUzLRIlnfbDvzRcJlkFTFTb)aUQWeyXieBvNOUAjqzTkUKmMbRkq[0]).esvdQDSeoVapiVBnSLWqsHImVLWA;
				}
			}

			public float valuePrev
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return 0f;
					}
					return ((sNACywUzLRIlnfbDvzRcJlkFTFTb)aUQWeyXieBvNOUAjqzTkUKmMbRkq[0]).sLALWRKTLxJotpSszSIhCrXmtbUF;
				}
			}

			public IControllerTemplateAxis throttle
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return null;
					}
					return (IControllerTemplateAxis)aUQWeyXieBvNOUAjqzTkUKmMbRkq[0];
				}
			}

			public IControllerTemplateButton minDetent
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return null;
					}
					return (IControllerTemplateButton)aUQWeyXieBvNOUAjqzTkUKmMbRkq[1];
				}
			}

			private mBBKIVYdbjBDNmrZzdwurUheBAABA(IControllerTemplate P_0, int P_1, string P_2, gwBXOpXdcaPCdFtopfeMjzVrGimI[] P_3)
				: base(P_0, P_1, P_2, ControllerTemplateElementType.Throttle, P_3)
			{
				if (P_3.Length != 2)
				{
					throw new ArgumentException("elements.Length must be " + 2);
				}
			}

			internal mBBKIVYdbjBDNmrZzdwurUheBAABA(IControllerTemplate P_0, int P_1, string P_2, sNACywUzLRIlnfbDvzRcJlkFTFTb P_3, sNACywUzLRIlnfbDvzRcJlkFTFTb P_4)
				: this(P_0, P_1, P_2, new gwBXOpXdcaPCdFtopfeMjzVrGimI[2] { P_3, P_4 })
			{
			}
		}

		internal sealed class NjraWBtqrDdAEhZrgZTFLTbrQseR : iqvTAvaOEKbSYfnUTtlbTFLCZR, IControllerTemplateElement, IControllerTemplateHat
		{
			private const int ORYfOycqcJWkBthpFFuEOJrZziIh = 0;

			private const int uDyODBymzzhyopbbBFuCCcLNrrNOA = 1;

			private const int PGUaUqHMOmajPApKidHCJNhDfwpac = 2;

			private const int PTgvpyfwKvqIbWyzeNzjCVyxTAAJ = 3;

			private const int hbWwcKoFZfzdEpQbhTkKYJSWmmCH = 4;

			private const int LWwOearHbPQhpuBmdIYnbSXsjnQEb = 5;

			private const int VYmonlrhYpdcMdJxrWruqlZUaXgr = 6;

			private const int kaHSlCtWVQHJeFyFpToJDBQUKeSK = 7;

			private const int YWRtWKbIgqRwyNetoDlDhiZglSfoA = 8;

			public Vector2 value
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return Vector2.zero;
					}
					Vector2 result = default(Vector2);
					result.y += ((sNACywUzLRIlnfbDvzRcJlkFTFTb)aUQWeyXieBvNOUAjqzTkUKmMbRkq[0]).esvdQDSeoVapiVBnSLWqsHImVLWA;
					result.x += ((sNACywUzLRIlnfbDvzRcJlkFTFTb)aUQWeyXieBvNOUAjqzTkUKmMbRkq[2]).esvdQDSeoVapiVBnSLWqsHImVLWA;
					result.y -= ((sNACywUzLRIlnfbDvzRcJlkFTFTb)aUQWeyXieBvNOUAjqzTkUKmMbRkq[4]).esvdQDSeoVapiVBnSLWqsHImVLWA;
					result.x -= ((sNACywUzLRIlnfbDvzRcJlkFTFTb)aUQWeyXieBvNOUAjqzTkUKmMbRkq[6]).esvdQDSeoVapiVBnSLWqsHImVLWA;
					float num = ((sNACywUzLRIlnfbDvzRcJlkFTFTb)aUQWeyXieBvNOUAjqzTkUKmMbRkq[1]).esvdQDSeoVapiVBnSLWqsHImVLWA;
					float num2 = ((sNACywUzLRIlnfbDvzRcJlkFTFTb)aUQWeyXieBvNOUAjqzTkUKmMbRkq[3]).esvdQDSeoVapiVBnSLWqsHImVLWA;
					float num3 = ((sNACywUzLRIlnfbDvzRcJlkFTFTb)aUQWeyXieBvNOUAjqzTkUKmMbRkq[5]).esvdQDSeoVapiVBnSLWqsHImVLWA;
					float num4 = ((sNACywUzLRIlnfbDvzRcJlkFTFTb)aUQWeyXieBvNOUAjqzTkUKmMbRkq[7]).esvdQDSeoVapiVBnSLWqsHImVLWA;
					result.x += num + num2 - num3 - num4;
					result.y += num + num4 - num2 - num3;
					result.x = MathTools.Clamp(result.x, -1f, 1f);
					result.y = MathTools.Clamp(result.y, -1f, 1f);
					return result;
				}
			}

			public Vector2 valuePrev
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return Vector2.zero;
					}
					Vector2 result = default(Vector2);
					result.y += ((sNACywUzLRIlnfbDvzRcJlkFTFTb)aUQWeyXieBvNOUAjqzTkUKmMbRkq[0]).sLALWRKTLxJotpSszSIhCrXmtbUF;
					result.x += ((sNACywUzLRIlnfbDvzRcJlkFTFTb)aUQWeyXieBvNOUAjqzTkUKmMbRkq[2]).sLALWRKTLxJotpSszSIhCrXmtbUF;
					result.y -= ((sNACywUzLRIlnfbDvzRcJlkFTFTb)aUQWeyXieBvNOUAjqzTkUKmMbRkq[4]).sLALWRKTLxJotpSszSIhCrXmtbUF;
					result.x -= ((sNACywUzLRIlnfbDvzRcJlkFTFTb)aUQWeyXieBvNOUAjqzTkUKmMbRkq[6]).sLALWRKTLxJotpSszSIhCrXmtbUF;
					float num = ((sNACywUzLRIlnfbDvzRcJlkFTFTb)aUQWeyXieBvNOUAjqzTkUKmMbRkq[1]).sLALWRKTLxJotpSszSIhCrXmtbUF;
					float num2 = ((sNACywUzLRIlnfbDvzRcJlkFTFTb)aUQWeyXieBvNOUAjqzTkUKmMbRkq[3]).sLALWRKTLxJotpSszSIhCrXmtbUF;
					float num3 = ((sNACywUzLRIlnfbDvzRcJlkFTFTb)aUQWeyXieBvNOUAjqzTkUKmMbRkq[5]).sLALWRKTLxJotpSszSIhCrXmtbUF;
					float num4 = ((sNACywUzLRIlnfbDvzRcJlkFTFTb)aUQWeyXieBvNOUAjqzTkUKmMbRkq[7]).sLALWRKTLxJotpSszSIhCrXmtbUF;
					result.x += num + num2 - num3 - num4;
					result.y += num + num4 - num2 - num3;
					result.x = MathTools.Clamp(result.x, -1f, 1f);
					result.y = MathTools.Clamp(result.y, -1f, 1f);
					return result;
				}
			}

			public IControllerTemplateButton up
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return null;
					}
					return (IControllerTemplateButton)aUQWeyXieBvNOUAjqzTkUKmMbRkq[0];
				}
			}

			public IControllerTemplateButton upRight
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return null;
					}
					return (IControllerTemplateButton)aUQWeyXieBvNOUAjqzTkUKmMbRkq[1];
				}
			}

			public IControllerTemplateButton right
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return null;
					}
					return (IControllerTemplateButton)aUQWeyXieBvNOUAjqzTkUKmMbRkq[2];
				}
			}

			public IControllerTemplateButton downRight
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return null;
					}
					return (IControllerTemplateButton)aUQWeyXieBvNOUAjqzTkUKmMbRkq[3];
				}
			}

			public IControllerTemplateButton down
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return null;
					}
					return (IControllerTemplateButton)aUQWeyXieBvNOUAjqzTkUKmMbRkq[4];
				}
			}

			public IControllerTemplateButton downLeft
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return null;
					}
					return (IControllerTemplateButton)aUQWeyXieBvNOUAjqzTkUKmMbRkq[5];
				}
			}

			public IControllerTemplateButton left
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return null;
					}
					return (IControllerTemplateButton)aUQWeyXieBvNOUAjqzTkUKmMbRkq[6];
				}
			}

			public IControllerTemplateButton upLeft
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return null;
					}
					return (IControllerTemplateButton)aUQWeyXieBvNOUAjqzTkUKmMbRkq[7];
				}
			}

			private NjraWBtqrDdAEhZrgZTFLTbrQseR(IControllerTemplate P_0, int P_1, string P_2, gwBXOpXdcaPCdFtopfeMjzVrGimI[] P_3)
				: base(P_0, P_1, P_2, ControllerTemplateElementType.Hat, P_3)
			{
				if (P_3.Length != 8)
				{
					throw new ArgumentException("elements.Length must be " + 8);
				}
			}

			internal NjraWBtqrDdAEhZrgZTFLTbrQseR(IControllerTemplate P_0, int P_1, string P_2, sNACywUzLRIlnfbDvzRcJlkFTFTb P_3, sNACywUzLRIlnfbDvzRcJlkFTFTb P_4, sNACywUzLRIlnfbDvzRcJlkFTFTb P_5, sNACywUzLRIlnfbDvzRcJlkFTFTb P_6, sNACywUzLRIlnfbDvzRcJlkFTFTb P_7, sNACywUzLRIlnfbDvzRcJlkFTFTb P_8, sNACywUzLRIlnfbDvzRcJlkFTFTb P_9, sNACywUzLRIlnfbDvzRcJlkFTFTb P_10)
				: this(P_0, P_1, P_2, new gwBXOpXdcaPCdFtopfeMjzVrGimI[8] { P_3, P_4, P_5, P_6, P_7, P_8, P_9, P_10 })
			{
			}
		}

		internal sealed class JOmCJevqEYwTFrKxZaIBpAwbkmNk : esTNGvLAqbTZOoFAXRFbFhJiHsnI, IControllerTemplateElement, IControllerTemplateYoke
		{
			private new const int YWRtWKbIgqRwyNetoDlDhiZglSfoA = 2;

			public IControllerTemplateAxis rotation
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return null;
					}
					return (IControllerTemplateAxis)aUQWeyXieBvNOUAjqzTkUKmMbRkq[0];
				}
			}

			public IControllerTemplateAxis pushPull
			{
				get
				{
					if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
					{
						ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
						return null;
					}
					return (IControllerTemplateAxis)aUQWeyXieBvNOUAjqzTkUKmMbRkq[1];
				}
			}

			private JOmCJevqEYwTFrKxZaIBpAwbkmNk(IControllerTemplate P_0, int P_1, string P_2, gwBXOpXdcaPCdFtopfeMjzVrGimI[] P_3)
				: base(P_0, P_1, P_2, ControllerTemplateElementType.Yoke, P_3)
			{
			}

			internal JOmCJevqEYwTFrKxZaIBpAwbkmNk(IControllerTemplate P_0, int P_1, string P_2, sNACywUzLRIlnfbDvzRcJlkFTFTb P_3, sNACywUzLRIlnfbDvzRcJlkFTFTb P_4)
				: base(P_0, P_1, P_2, ControllerTemplateElementType.Yoke, new gwBXOpXdcaPCdFtopfeMjzVrGimI[2] { P_3, P_4 })
			{
			}
		}

		internal sealed class pndTnlNuLfTmFyGQJCrSrXYBCXKy : OitTJKMbgxCqxEiMofopDYqFnPOK, IControllerTemplateElement, IControllerTemplateStick6D
		{
			private new const int YWRtWKbIgqRwyNetoDlDhiZglSfoA = 6;

			private pndTnlNuLfTmFyGQJCrSrXYBCXKy(IControllerTemplate P_0, int P_1, string P_2, gwBXOpXdcaPCdFtopfeMjzVrGimI[] P_3)
				: base(P_0, P_1, P_2, ControllerTemplateElementType.Stick6D, P_3)
			{
			}

			internal pndTnlNuLfTmFyGQJCrSrXYBCXKy(IControllerTemplate P_0, int P_1, string P_2, sNACywUzLRIlnfbDvzRcJlkFTFTb P_3, sNACywUzLRIlnfbDvzRcJlkFTFTb P_4, sNACywUzLRIlnfbDvzRcJlkFTFTb P_5, sNACywUzLRIlnfbDvzRcJlkFTFTb P_6, sNACywUzLRIlnfbDvzRcJlkFTFTb P_7, sNACywUzLRIlnfbDvzRcJlkFTFTb P_8)
				: base(P_0, P_1, P_2, ControllerTemplateElementType.Stick6D, new gwBXOpXdcaPCdFtopfeMjzVrGimI[6] { P_3, P_4, P_5, P_6, P_7, P_8 })
			{
			}
		}

		internal class PbLhtDmFPsNazvYLFQBoFqNdAtlL
		{
			public readonly Controller.Element BCuHApOmoSObQBcmCUJCdFCnCAsFA;

			public readonly IControllerElementTarget LNFmGxqdskDZYydfYKbBBRoonLzv;

			public bool oWEdkgpANxjhVOIcAcKXObeBlSuU
			{
				get
				{
					if (BCuHApOmoSObQBcmCUJCdFCnCAsFA == null)
					{
						return false;
					}
					switch (BCuHApOmoSObQBcmCUJCdFCnCAsFA.type)
					{
					case ControllerElementType.Button:
						return (BCuHApOmoSObQBcmCUJCdFCnCAsFA as Controller.Button).value;
					case ControllerElementType.Axis:
					{
						float value = (BCuHApOmoSObQBcmCUJCdFCnCAsFA as Controller.Axis).value;
						switch (LNFmGxqdskDZYydfYKbBBRoonLzv.axisRange)
						{
						case AxisRange.Full:
							if (value > 0.01f)
							{
								return true;
							}
							if (value < -0.01f)
							{
								return true;
							}
							break;
						case AxisRange.Positive:
							if (value > 0.01f)
							{
								return true;
							}
							break;
						case AxisRange.Negative:
							if (value < -0.01f)
							{
								return true;
							}
							break;
						}
						break;
					}
					}
					return false;
				}
			}

			public bool mjwdDosldubIUAhRxvRGpnamBQgm
			{
				get
				{
					if (BCuHApOmoSObQBcmCUJCdFCnCAsFA == null)
					{
						return false;
					}
					switch (BCuHApOmoSObQBcmCUJCdFCnCAsFA.type)
					{
					case ControllerElementType.Button:
						return (BCuHApOmoSObQBcmCUJCdFCnCAsFA as Controller.Button).valuePrev;
					case ControllerElementType.Axis:
					{
						float valuePrev = (BCuHApOmoSObQBcmCUJCdFCnCAsFA as Controller.Axis).valuePrev;
						switch (LNFmGxqdskDZYydfYKbBBRoonLzv.axisRange)
						{
						case AxisRange.Full:
							if (valuePrev > 0.01f)
							{
								return true;
							}
							if (valuePrev < -0.01f)
							{
								return true;
							}
							break;
						case AxisRange.Positive:
							if (valuePrev > 0.01f)
							{
								return true;
							}
							break;
						case AxisRange.Negative:
							if (valuePrev < -0.01f)
							{
								return true;
							}
							break;
						}
						break;
					}
					}
					return false;
				}
			}

			public bool yjBXVGcweMRmHAeJWtlsivXQHOYK
			{
				get
				{
					if (BCuHApOmoSObQBcmCUJCdFCnCAsFA == null)
					{
						return false;
					}
					switch (BCuHApOmoSObQBcmCUJCdFCnCAsFA.type)
					{
					case ControllerElementType.Button:
						return (BCuHApOmoSObQBcmCUJCdFCnCAsFA as Controller.Button).justPressed;
					case ControllerElementType.Axis:
						if (MathTools.Abs(esvdQDSeoVapiVBnSLWqsHImVLWA) > 0.01f && MathTools.Abs(sLALWRKTLxJotpSszSIhCrXmtbUF) <= 0.01f)
						{
							return true;
						}
						break;
					}
					return false;
				}
			}

			public bool pmvZevAaExDOXoNPFOwXhCJOdDQl
			{
				get
				{
					if (BCuHApOmoSObQBcmCUJCdFCnCAsFA == null)
					{
						return false;
					}
					switch (BCuHApOmoSObQBcmCUJCdFCnCAsFA.type)
					{
					case ControllerElementType.Button:
						return (BCuHApOmoSObQBcmCUJCdFCnCAsFA as Controller.Button).justReleased;
					case ControllerElementType.Axis:
						if (MathTools.Abs(esvdQDSeoVapiVBnSLWqsHImVLWA) <= 0.01f && MathTools.Abs(sLALWRKTLxJotpSszSIhCrXmtbUF) > 0.01f)
						{
							return true;
						}
						break;
					}
					return false;
				}
			}

			public float esvdQDSeoVapiVBnSLWqsHImVLWA
			{
				get
				{
					if (BCuHApOmoSObQBcmCUJCdFCnCAsFA == null)
					{
						return 0f;
					}
					switch (BCuHApOmoSObQBcmCUJCdFCnCAsFA.type)
					{
					case ControllerElementType.Button:
						if (!(BCuHApOmoSObQBcmCUJCdFCnCAsFA as Controller.Button).value)
						{
							return 0f;
						}
						return 1f;
					case ControllerElementType.Axis:
					{
						float value = (BCuHApOmoSObQBcmCUJCdFCnCAsFA as Controller.Axis).value;
						switch (LNFmGxqdskDZYydfYKbBBRoonLzv.axisRange)
						{
						case AxisRange.Full:
							return value;
						case AxisRange.Positive:
							if (value > 0f)
							{
								return value;
							}
							break;
						case AxisRange.Negative:
							if (value < 0f)
							{
								return value;
							}
							break;
						}
						break;
					}
					}
					return 0f;
				}
			}

			public float sLALWRKTLxJotpSszSIhCrXmtbUF
			{
				get
				{
					if (BCuHApOmoSObQBcmCUJCdFCnCAsFA == null)
					{
						return 0f;
					}
					switch (BCuHApOmoSObQBcmCUJCdFCnCAsFA.type)
					{
					case ControllerElementType.Button:
						if (!(BCuHApOmoSObQBcmCUJCdFCnCAsFA as Controller.Button).valuePrev)
						{
							return 0f;
						}
						return 1f;
					case ControllerElementType.Axis:
					{
						float valuePrev = (BCuHApOmoSObQBcmCUJCdFCnCAsFA as Controller.Axis).valuePrev;
						switch (LNFmGxqdskDZYydfYKbBBRoonLzv.axisRange)
						{
						case AxisRange.Full:
							return valuePrev;
						case AxisRange.Positive:
							if (valuePrev > 0f)
							{
								return valuePrev;
							}
							break;
						case AxisRange.Negative:
							if (valuePrev < 0f)
							{
								return valuePrev;
							}
							break;
						}
						break;
					}
					}
					return 0f;
				}
			}

			public PbLhtDmFPsNazvYLFQBoFqNdAtlL(IControllerElementTarget P_0, Controller.Element P_1)
			{
				BCuHApOmoSObQBcmCUJCdFCnCAsFA = P_1;
				LNFmGxqdskDZYydfYKbBBRoonLzv = P_0;
			}

			public static PbLhtDmFPsNazvYLFQBoFqNdAtlL ckrUQVcMUnHdCWgDQIywBRRTSKOn()
			{
				return new PbLhtDmFPsNazvYLFQBoFqNdAtlL(xExZPlwOYSQiIkFqHDDyWovrVnsK.ckrUQVcMUnHdCWgDQIywBRRTSKOn(), null);
			}
		}

		internal class feVKXHBPShqNDdopDgaTXfGJMrbc
		{
			public readonly Controller NlFnBAIUQPMwtvacPcDKoOszCbeW;

			public readonly IHardwareControllerTemplateMap_Internal OGphAamvxmKlIbmrRdwRIFGnAPCkA;

			public feVKXHBPShqNDdopDgaTXfGJMrbc(Controller P_0, IHardwareControllerTemplateMap_Internal P_1)
			{
				if (P_0 == null)
				{
					throw new ArgumentNullException("controller");
				}
				if (P_1 == null)
				{
					throw new ArgumentNullException("templateMap");
				}
				NlFnBAIUQPMwtvacPcDKoOszCbeW = P_0;
				OGphAamvxmKlIbmrRdwRIFGnAPCkA = P_1;
			}
		}

		private readonly string gbaFwplwRPDIuUufIuWmknaoIHDK;

		private readonly Guid JPtXFrKJjRdQNJgDXtEmYtxqxYhM;

		private readonly Controller nEgdvbuTaiHYWdQfyyXkKnXDhOQcb;

		private readonly ADictionary<int, IControllerTemplateElement> KxaTofjYlqbwmMmKZdhwovhZxdzA;

		private readonly ADictionary<string, IControllerTemplateElement> uPRcmVWopBMlISMMaNrxnCcSgfSs;

		private IControllerTemplateElement[] aUQWeyXieBvNOUAjqzTkUKmMbRkq;

		private ReadOnlyCollection<IControllerTemplateElement> ABLlvSkeHalgmkxVjrUFAcOGcjTf;

		private readonly int TcEXPUvjqSTMTFutCAtGRnMeNwub;

		Controller IControllerTemplate.controller
		{
			get
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					return null;
				}
				return nEgdvbuTaiHYWdQfyyXkKnXDhOQcb;
			}
		}

		string IControllerTemplate.name
		{
			get
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					return null;
				}
				return gbaFwplwRPDIuUufIuWmknaoIHDK;
			}
		}

		Guid IControllerTemplate.typeGuid
		{
			get
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					return Guid.Empty;
				}
				return JPtXFrKJjRdQNJgDXtEmYtxqxYhM;
			}
		}

		IList<IControllerTemplateElement> IControllerTemplate.elements
		{
			get
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					return null;
				}
				return ABLlvSkeHalgmkxVjrUFAcOGcjTf;
			}
		}

		int IControllerTemplate.elementCount
		{
			get
			{
				if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
				{
					ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
					return 0;
				}
				return aUQWeyXieBvNOUAjqzTkUKmMbRkq.Length;
			}
		}

		protected ControllerTemplate(object P_0)
			: this((feVKXHBPShqNDdopDgaTXfGJMrbc)P_0)
		{
		}

		private ControllerTemplate(feVKXHBPShqNDdopDgaTXfGJMrbc P_0)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("initializer");
			}
			if (P_0.NlFnBAIUQPMwtvacPcDKoOszCbeW == null)
			{
				throw new ArgumentNullException("initializer.controller");
			}
			if (P_0.OGphAamvxmKlIbmrRdwRIFGnAPCkA == null)
			{
				throw new ArgumentNullException("initializer.templateMap");
			}
			TcEXPUvjqSTMTFutCAtGRnMeNwub = ReInput.id;
			nEgdvbuTaiHYWdQfyyXkKnXDhOQcb = P_0.NlFnBAIUQPMwtvacPcDKoOszCbeW;
			IHardwareControllerTemplateMap_Internal oGphAamvxmKlIbmrRdwRIFGnAPCkA = P_0.OGphAamvxmKlIbmrRdwRIFGnAPCkA;
			gbaFwplwRPDIuUufIuWmknaoIHDK = oGphAamvxmKlIbmrRdwRIFGnAPCkA.name;
			JPtXFrKJjRdQNJgDXtEmYtxqxYhM = oGphAamvxmKlIbmrRdwRIFGnAPCkA.typeGuid;
			int elementIdentifierCount = oGphAamvxmKlIbmrRdwRIFGnAPCkA.GetElementIdentifierCount();
			ADictionary<int, IControllerTemplateElement> aDictionary = new ADictionary<int, IControllerTemplateElement>();
			List<IControllerTemplateElement> list = new List<IControllerTemplateElement>();
			List<IControllerTemplateAxis> list2 = new List<IControllerTemplateAxis>();
			List<IControllerTemplateButton> list3 = new List<IControllerTemplateButton>();
			List<IControllerTemplateElement> list4 = new List<IControllerTemplateElement>();
			for (int i = 0; i < elementIdentifierCount; i++)
			{
				IControllerTemplateElementIdentifier templateElementIdentifier = oGphAamvxmKlIbmrRdwRIFGnAPCkA.GetTemplateElementIdentifier(i);
				if (templateElementIdentifier != null && InputTools.IsMappableType(templateElementIdentifier.elementType))
				{
					switch (templateElementIdentifier.elementType)
					{
					case ControllerTemplateElementType.Axis:
					{
						KpZHreySesbtLKuRdoZrwgpLSyTA kpZHreySesbtLKuRdoZrwgpLSyTA2 = oGphAamvxmKlIbmrRdwRIFGnAPCkA.GetAxisTarget(nEgdvbuTaiHYWdQfyyXkKnXDhOQcb, templateElementIdentifier.id) ?? KpZHreySesbtLKuRdoZrwgpLSyTA.ckrUQVcMUnHdCWgDQIywBRRTSKOn(ControllerTemplateElementType.Axis);
						ZLOgUXjjWrIpfPEbmgeGsxJWJjEy item2 = new ZLOgUXjjWrIpfPEbmgeGsxJWJjEy(this, templateElementIdentifier.id, templateElementIdentifier.name, (!string.IsNullOrEmpty(templateElementIdentifier.positiveName)) ? templateElementIdentifier.positiveName : (templateElementIdentifier.name + " +"), (!string.IsNullOrEmpty(templateElementIdentifier.negativeName)) ? templateElementIdentifier.negativeName : (templateElementIdentifier.name + " -"), kpZHreySesbtLKuRdoZrwgpLSyTA2, LnItojlMnxazbiMQNlegHahpuXhxA(nEgdvbuTaiHYWdQfyyXkKnXDhOQcb, (IControllerTemplateAxisSource)kpZHreySesbtLKuRdoZrwgpLSyTA2));
						list2.Add(item2);
						break;
					}
					case ControllerTemplateElementType.Button:
					{
						KpZHreySesbtLKuRdoZrwgpLSyTA kpZHreySesbtLKuRdoZrwgpLSyTA = oGphAamvxmKlIbmrRdwRIFGnAPCkA.GetButtonTarget(nEgdvbuTaiHYWdQfyyXkKnXDhOQcb, templateElementIdentifier.id) ?? KpZHreySesbtLKuRdoZrwgpLSyTA.ckrUQVcMUnHdCWgDQIywBRRTSKOn(ControllerTemplateElementType.Button);
						yzeaXMAenzWpurIfbwmsEFPXmIPUA item = new yzeaXMAenzWpurIfbwmsEFPXmIPUA(this, templateElementIdentifier.id, templateElementIdentifier.name, templateElementIdentifier.name, templateElementIdentifier.name + " -", kpZHreySesbtLKuRdoZrwgpLSyTA, LnItojlMnxazbiMQNlegHahpuXhxA(nEgdvbuTaiHYWdQfyyXkKnXDhOQcb, (IControllerTemplateButtonSource)kpZHreySesbtLKuRdoZrwgpLSyTA));
						list3.Add(item);
						break;
					}
					default:
						throw new NotImplementedException();
					}
				}
			}
			for (int j = 0; j < list2.Count; j++)
			{
				list.Add(list2[j]);
			}
			for (int k = 0; k < list3.Count; k++)
			{
				list.Add(list3[k]);
			}
			for (int l = 0; l < list.Count; l++)
			{
				aDictionary.Add(list[l].id, list[l]);
			}
			for (int m = 0; m < elementIdentifierCount; m++)
			{
				IControllerTemplateElementIdentifier templateElementIdentifier2 = oGphAamvxmKlIbmrRdwRIFGnAPCkA.GetTemplateElementIdentifier(m);
				if (templateElementIdentifier2 == null || InputTools.IsMappableType(templateElementIdentifier2.elementType))
				{
					continue;
				}
				IControllerTemplateMapSpecialElement_Internal specialTemplateElementByElementIdentifierId = oGphAamvxmKlIbmrRdwRIFGnAPCkA.GetSpecialTemplateElementByElementIdentifierId(templateElementIdentifier2.id);
				gwBXOpXdcaPCdFtopfeMjzVrGimI gwBXOpXdcaPCdFtopfeMjzVrGimI2;
				switch (templateElementIdentifier2.elementType)
				{
				case ControllerTemplateElementType.ThumbStick:
				{
					if (specialTemplateElementByElementIdentifierId == null)
					{
						Logger.LogError(templateElementIdentifier2.elementType.ToString() + " element missing for Element Identifier Id " + templateElementIdentifier2.id);
					}
					ControllerTemplateThumbStickMapping mapping5 = specialTemplateElementByElementIdentifierId.GetMapping<ControllerTemplateThumbStickMapping>();
					gwBXOpXdcaPCdFtopfeMjzVrGimI2 = new HiGXBsqDccjqVGuItfKobymTTZqJ(this, templateElementIdentifier2.id, templateElementIdentifier2.name, (mapping5 != null) ? IdaaQBJQnEYKOoXGgCRtlIWpoEQAA(this, aDictionary, mapping5.eid_axisX) : ZLOgUXjjWrIpfPEbmgeGsxJWJjEy.ckrUQVcMUnHdCWgDQIywBRRTSKOn(this), (mapping5 != null) ? IdaaQBJQnEYKOoXGgCRtlIWpoEQAA(this, aDictionary, mapping5.eid_axisY) : ZLOgUXjjWrIpfPEbmgeGsxJWJjEy.ckrUQVcMUnHdCWgDQIywBRRTSKOn(this), (mapping5 != null) ? jodeWACReFvZpoQyUvqnhZRwyafZ(this, aDictionary, mapping5.eid_button) : yzeaXMAenzWpurIfbwmsEFPXmIPUA.ckrUQVcMUnHdCWgDQIywBRRTSKOn(this));
					break;
				}
				case ControllerTemplateElementType.DPad:
				{
					if (specialTemplateElementByElementIdentifierId == null)
					{
						Logger.LogError(templateElementIdentifier2.elementType.ToString() + " element missing for Element Identifier Id " + templateElementIdentifier2.id);
					}
					ControllerTemplateDPadMapping mapping3 = specialTemplateElementByElementIdentifierId.GetMapping<ControllerTemplateDPadMapping>();
					gwBXOpXdcaPCdFtopfeMjzVrGimI2 = new dbNLfLVNvcXaUpSDKahiFuenWaf(this, templateElementIdentifier2.id, templateElementIdentifier2.name, (mapping3 != null) ? jodeWACReFvZpoQyUvqnhZRwyafZ(this, aDictionary, mapping3.eid_up) : yzeaXMAenzWpurIfbwmsEFPXmIPUA.ckrUQVcMUnHdCWgDQIywBRRTSKOn(this), (mapping3 != null) ? jodeWACReFvZpoQyUvqnhZRwyafZ(this, aDictionary, mapping3.eid_right) : yzeaXMAenzWpurIfbwmsEFPXmIPUA.ckrUQVcMUnHdCWgDQIywBRRTSKOn(this), (mapping3 != null) ? jodeWACReFvZpoQyUvqnhZRwyafZ(this, aDictionary, mapping3.eid_down) : yzeaXMAenzWpurIfbwmsEFPXmIPUA.ckrUQVcMUnHdCWgDQIywBRRTSKOn(this), (mapping3 != null) ? jodeWACReFvZpoQyUvqnhZRwyafZ(this, aDictionary, mapping3.eid_left) : yzeaXMAenzWpurIfbwmsEFPXmIPUA.ckrUQVcMUnHdCWgDQIywBRRTSKOn(this), (mapping3 != null) ? jodeWACReFvZpoQyUvqnhZRwyafZ(this, aDictionary, mapping3.eid_press) : yzeaXMAenzWpurIfbwmsEFPXmIPUA.ckrUQVcMUnHdCWgDQIywBRRTSKOn(this));
					break;
				}
				case ControllerTemplateElementType.Stick:
				{
					if (specialTemplateElementByElementIdentifierId == null)
					{
						Logger.LogError(templateElementIdentifier2.elementType.ToString() + " element missing for Element Identifier Id " + templateElementIdentifier2.id);
					}
					ControllerTemplateStickMapping mapping2 = specialTemplateElementByElementIdentifierId.GetMapping<ControllerTemplateStickMapping>();
					gwBXOpXdcaPCdFtopfeMjzVrGimI2 = new WUbLoAAsDTcFlixjKBKxiuRFEKFKB(this, templateElementIdentifier2.id, templateElementIdentifier2.name, (mapping2 != null) ? IdaaQBJQnEYKOoXGgCRtlIWpoEQAA(this, aDictionary, mapping2.eid_axisX) : ZLOgUXjjWrIpfPEbmgeGsxJWJjEy.ckrUQVcMUnHdCWgDQIywBRRTSKOn(this), (mapping2 != null) ? IdaaQBJQnEYKOoXGgCRtlIWpoEQAA(this, aDictionary, mapping2.eid_axisY) : ZLOgUXjjWrIpfPEbmgeGsxJWJjEy.ckrUQVcMUnHdCWgDQIywBRRTSKOn(this), (mapping2 != null) ? IdaaQBJQnEYKOoXGgCRtlIWpoEQAA(this, aDictionary, mapping2.eid_axisZ) : ZLOgUXjjWrIpfPEbmgeGsxJWJjEy.ckrUQVcMUnHdCWgDQIywBRRTSKOn(this));
					break;
				}
				case ControllerTemplateElementType.Throttle:
				{
					if (specialTemplateElementByElementIdentifierId == null)
					{
						Logger.LogError(templateElementIdentifier2.elementType.ToString() + " element missing for Element Identifier Id " + templateElementIdentifier2.id);
					}
					ControllerTemplateThrottleMapping mapping6 = specialTemplateElementByElementIdentifierId.GetMapping<ControllerTemplateThrottleMapping>();
					gwBXOpXdcaPCdFtopfeMjzVrGimI2 = new mBBKIVYdbjBDNmrZzdwurUheBAABA(this, templateElementIdentifier2.id, templateElementIdentifier2.name, (mapping6 != null) ? IdaaQBJQnEYKOoXGgCRtlIWpoEQAA(this, aDictionary, mapping6.eid_axis) : ZLOgUXjjWrIpfPEbmgeGsxJWJjEy.ckrUQVcMUnHdCWgDQIywBRRTSKOn(this), (mapping6 != null) ? jodeWACReFvZpoQyUvqnhZRwyafZ(this, aDictionary, mapping6.eid_minDetent) : yzeaXMAenzWpurIfbwmsEFPXmIPUA.ckrUQVcMUnHdCWgDQIywBRRTSKOn(this));
					break;
				}
				case ControllerTemplateElementType.Hat:
				{
					if (specialTemplateElementByElementIdentifierId == null)
					{
						Logger.LogError(templateElementIdentifier2.elementType.ToString() + " element missing for Element Identifier Id " + templateElementIdentifier2.id);
					}
					ControllerTemplateHatMapping mapping7 = specialTemplateElementByElementIdentifierId.GetMapping<ControllerTemplateHatMapping>();
					gwBXOpXdcaPCdFtopfeMjzVrGimI2 = new NjraWBtqrDdAEhZrgZTFLTbrQseR(this, templateElementIdentifier2.id, templateElementIdentifier2.name, (mapping7 != null) ? jodeWACReFvZpoQyUvqnhZRwyafZ(this, aDictionary, mapping7.eid_up) : yzeaXMAenzWpurIfbwmsEFPXmIPUA.ckrUQVcMUnHdCWgDQIywBRRTSKOn(this), (mapping7 != null) ? jodeWACReFvZpoQyUvqnhZRwyafZ(this, aDictionary, mapping7.eid_upRight) : yzeaXMAenzWpurIfbwmsEFPXmIPUA.ckrUQVcMUnHdCWgDQIywBRRTSKOn(this), (mapping7 != null) ? jodeWACReFvZpoQyUvqnhZRwyafZ(this, aDictionary, mapping7.eid_right) : yzeaXMAenzWpurIfbwmsEFPXmIPUA.ckrUQVcMUnHdCWgDQIywBRRTSKOn(this), (mapping7 != null) ? jodeWACReFvZpoQyUvqnhZRwyafZ(this, aDictionary, mapping7.eid_downRight) : yzeaXMAenzWpurIfbwmsEFPXmIPUA.ckrUQVcMUnHdCWgDQIywBRRTSKOn(this), (mapping7 != null) ? jodeWACReFvZpoQyUvqnhZRwyafZ(this, aDictionary, mapping7.eid_down) : yzeaXMAenzWpurIfbwmsEFPXmIPUA.ckrUQVcMUnHdCWgDQIywBRRTSKOn(this), (mapping7 != null) ? jodeWACReFvZpoQyUvqnhZRwyafZ(this, aDictionary, mapping7.eid_downLeft) : yzeaXMAenzWpurIfbwmsEFPXmIPUA.ckrUQVcMUnHdCWgDQIywBRRTSKOn(this), (mapping7 != null) ? jodeWACReFvZpoQyUvqnhZRwyafZ(this, aDictionary, mapping7.eid_left) : yzeaXMAenzWpurIfbwmsEFPXmIPUA.ckrUQVcMUnHdCWgDQIywBRRTSKOn(this), (mapping7 != null) ? jodeWACReFvZpoQyUvqnhZRwyafZ(this, aDictionary, mapping7.eid_upLeft) : yzeaXMAenzWpurIfbwmsEFPXmIPUA.ckrUQVcMUnHdCWgDQIywBRRTSKOn(this));
					break;
				}
				case ControllerTemplateElementType.Yoke:
				{
					if (specialTemplateElementByElementIdentifierId == null)
					{
						Logger.LogError(templateElementIdentifier2.elementType.ToString() + " element missing for Element Identifier Id " + templateElementIdentifier2.id);
					}
					ControllerTemplateYokeMapping mapping4 = specialTemplateElementByElementIdentifierId.GetMapping<ControllerTemplateYokeMapping>();
					gwBXOpXdcaPCdFtopfeMjzVrGimI2 = new JOmCJevqEYwTFrKxZaIBpAwbkmNk(this, templateElementIdentifier2.id, templateElementIdentifier2.name, (mapping4 != null) ? IdaaQBJQnEYKOoXGgCRtlIWpoEQAA(this, aDictionary, mapping4.eid_axisX) : ZLOgUXjjWrIpfPEbmgeGsxJWJjEy.ckrUQVcMUnHdCWgDQIywBRRTSKOn(this), (mapping4 != null) ? IdaaQBJQnEYKOoXGgCRtlIWpoEQAA(this, aDictionary, mapping4.eid_axisZ) : ZLOgUXjjWrIpfPEbmgeGsxJWJjEy.ckrUQVcMUnHdCWgDQIywBRRTSKOn(this));
					break;
				}
				case ControllerTemplateElementType.Stick6D:
				{
					if (specialTemplateElementByElementIdentifierId == null)
					{
						Logger.LogError(templateElementIdentifier2.elementType.ToString() + " element missing for Element Identifier Id " + templateElementIdentifier2.id);
					}
					ControllerTemplateStick6DMapping mapping = specialTemplateElementByElementIdentifierId.GetMapping<ControllerTemplateStick6DMapping>();
					gwBXOpXdcaPCdFtopfeMjzVrGimI2 = new pndTnlNuLfTmFyGQJCrSrXYBCXKy(this, templateElementIdentifier2.id, templateElementIdentifier2.name, (mapping != null) ? IdaaQBJQnEYKOoXGgCRtlIWpoEQAA(this, aDictionary, mapping.eid_positionX) : ZLOgUXjjWrIpfPEbmgeGsxJWJjEy.ckrUQVcMUnHdCWgDQIywBRRTSKOn(this), (mapping != null) ? IdaaQBJQnEYKOoXGgCRtlIWpoEQAA(this, aDictionary, mapping.eid_positionY) : ZLOgUXjjWrIpfPEbmgeGsxJWJjEy.ckrUQVcMUnHdCWgDQIywBRRTSKOn(this), (mapping != null) ? IdaaQBJQnEYKOoXGgCRtlIWpoEQAA(this, aDictionary, mapping.eid_positionZ) : ZLOgUXjjWrIpfPEbmgeGsxJWJjEy.ckrUQVcMUnHdCWgDQIywBRRTSKOn(this), (mapping != null) ? IdaaQBJQnEYKOoXGgCRtlIWpoEQAA(this, aDictionary, mapping.eid_rotationX) : ZLOgUXjjWrIpfPEbmgeGsxJWJjEy.ckrUQVcMUnHdCWgDQIywBRRTSKOn(this), (mapping != null) ? IdaaQBJQnEYKOoXGgCRtlIWpoEQAA(this, aDictionary, mapping.eid_rotationY) : ZLOgUXjjWrIpfPEbmgeGsxJWJjEy.ckrUQVcMUnHdCWgDQIywBRRTSKOn(this), (mapping != null) ? IdaaQBJQnEYKOoXGgCRtlIWpoEQAA(this, aDictionary, mapping.eid_rotationZ) : ZLOgUXjjWrIpfPEbmgeGsxJWJjEy.ckrUQVcMUnHdCWgDQIywBRRTSKOn(this));
					break;
				}
				default:
					throw new NotImplementedException();
				}
				if (gwBXOpXdcaPCdFtopfeMjzVrGimI2 != null)
				{
					list4.Add(gwBXOpXdcaPCdFtopfeMjzVrGimI2);
				}
			}
			for (int n = 0; n < list4.Count; n++)
			{
				list.Add(list4[n]);
				aDictionary.Add(list4[n].id, list4[n]);
			}
			aUQWeyXieBvNOUAjqzTkUKmMbRkq = list.ToArray();
			KxaTofjYlqbwmMmKZdhwovhZxdzA = aDictionary;
			uPRcmVWopBMlISMMaNrxnCcSgfSs = new ADictionary<string, IControllerTemplateElement>();
			for (int num = 0; num < aUQWeyXieBvNOUAjqzTkUKmMbRkq.Length; num++)
			{
				if (!(oGphAamvxmKlIbmrRdwRIFGnAPCkA.GetTemplateElementIdentifierById(aUQWeyXieBvNOUAjqzTkUKmMbRkq[num].id) is IControllerTemplateElementIdentifier_Editor controllerTemplateElementIdentifier_Editor))
				{
					continue;
				}
				for (int num2 = 0; num2 < 2; num2++)
				{
					string text = ((num2 != 0) ? controllerTemplateElementIdentifier_Editor.alternateScriptingName : controllerTemplateElementIdentifier_Editor.scriptingName);
					if (!string.IsNullOrEmpty(text))
					{
						try
						{
							uPRcmVWopBMlISMMaNrxnCcSgfSs.Add(text, aUQWeyXieBvNOUAjqzTkUKmMbRkq[num]);
						}
						catch
						{
							Logger.LogError("A duplicate Controller Template element scripting name (" + text + ") was found in template " + gbaFwplwRPDIuUufIuWmknaoIHDK + ". This element should be renamed to a unique name.");
						}
					}
				}
			}
			ABLlvSkeHalgmkxVjrUFAcOGcjTf = new ReadOnlyCollection<IControllerTemplateElement>(aUQWeyXieBvNOUAjqzTkUKmMbRkq);
		}

		protected IControllerTemplateElement GetElement(int id)
		{
			if (!KxaTofjYlqbwmMmKZdhwovhZxdzA.TryGetValue(id, out var value))
			{
				Logger.LogWarning("There is no element with the id \"" + id + "\" in the " + GetType().ToString() + ".");
			}
			return value;
		}

		protected T GetElement<T>(int id) where T : class, IControllerTemplateElement
		{
			return GetElement(id) as T;
		}

		IControllerTemplateElement IControllerTemplate.GetElement(int id)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return null;
			}
			return GetElement(id);
		}

		T IControllerTemplate.GetElement<T>(int id)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return null;
			}
			return GetElement<T>(id);
		}

		int IControllerTemplate.GetElementTargets(ControllerElementTarget find, IList<ControllerTemplateElementTarget> results)
		{
			if (ReInput._id != TcEXPUvjqSTMTFutCAtGRnMeNwub)
			{
				ReInput.CheckInitialized(TcEXPUvjqSTMTFutCAtGRnMeNwub);
				return 0;
			}
			if (results == null)
			{
				throw new ArgumentNullException("results");
			}
			return GetElementTargets(find, ref results);
		}

		private int GetElementTargets(ControllerElementTarget find, ref IList<ControllerTemplateElementTarget> results)
		{
			if (results != null)
			{
				results.Clear();
			}
			int num = 0;
			for (int i = 0; i < aUQWeyXieBvNOUAjqzTkUKmMbRkq.Length; i++)
			{
				if (InputTools.IsMappableType(aUQWeyXieBvNOUAjqzTkUKmMbRkq[i].type))
				{
					num += (aUQWeyXieBvNOUAjqzTkUKmMbRkq[i] as IControllerTemplateElement_Internal).GetElementTargets(find, ref results);
				}
			}
			return num;
		}

		[CustomObfuscation(rename = false)]
		internal static Type GetInterfaceType(ControllerTemplateElementType elementType)
		{
			return elementType switch
			{
				ControllerTemplateElementType.Axis => typeof(IControllerTemplateAxis), 
				ControllerTemplateElementType.Button => typeof(IControllerTemplateButton), 
				ControllerTemplateElementType.ThumbStick => typeof(IControllerTemplateThumbStick), 
				ControllerTemplateElementType.DPad => typeof(IControllerTemplateDPad), 
				ControllerTemplateElementType.Stick => typeof(IControllerTemplateStick), 
				ControllerTemplateElementType.Throttle => typeof(IControllerTemplateThrottle), 
				ControllerTemplateElementType.Hat => typeof(IControllerTemplateHat), 
				ControllerTemplateElementType.Yoke => typeof(IControllerTemplateYoke), 
				ControllerTemplateElementType.Stick6D => typeof(IControllerTemplateStick6D), 
				_ => throw new NotImplementedException(), 
			};
		}

		private static IList<PbLhtDmFPsNazvYLFQBoFqNdAtlL> LnItojlMnxazbiMQNlegHahpuXhxA(Controller P_0, IControllerTemplateAxisSource P_1)
		{
			if (P_1 == null)
			{
				return null;
			}
			if (P_1.splitAxis)
			{
				IList<PbLhtDmFPsNazvYLFQBoFqNdAtlL> list = null;
				bool flag = false;
				if (P_1.positiveTarget != null)
				{
					Controller.Element elementById = P_0.GetElementById(P_1.positiveTarget.elementIdentifierId);
					if (elementById != null)
					{
						ListTools.AddAndCreateList(ref list, new PbLhtDmFPsNazvYLFQBoFqNdAtlL(P_1.positiveTarget, elementById));
						flag = true;
					}
				}
				if (!flag)
				{
					ListTools.AddAndCreateList(ref list, PbLhtDmFPsNazvYLFQBoFqNdAtlL.ckrUQVcMUnHdCWgDQIywBRRTSKOn());
				}
				flag = false;
				if (P_1.negativeTarget != null)
				{
					Controller.Element elementById2 = P_0.GetElementById(P_1.negativeTarget.elementIdentifierId);
					if (elementById2 != null)
					{
						ListTools.AddAndCreateList(ref list, new PbLhtDmFPsNazvYLFQBoFqNdAtlL(P_1.negativeTarget, elementById2));
						flag = true;
					}
				}
				if (!flag)
				{
					ListTools.AddAndCreateList(ref list, PbLhtDmFPsNazvYLFQBoFqNdAtlL.ckrUQVcMUnHdCWgDQIywBRRTSKOn());
				}
				return list;
			}
			return LnItojlMnxazbiMQNlegHahpuXhxA(P_0, P_1.fullTarget);
		}

		private static IList<PbLhtDmFPsNazvYLFQBoFqNdAtlL> LnItojlMnxazbiMQNlegHahpuXhxA(Controller P_0, IControllerTemplateButtonSource P_1)
		{
			if (P_1 == null)
			{
				return null;
			}
			return LnItojlMnxazbiMQNlegHahpuXhxA(P_0, P_1.target);
		}

		private static IList<PbLhtDmFPsNazvYLFQBoFqNdAtlL> LnItojlMnxazbiMQNlegHahpuXhxA(Controller P_0, IControllerElementTarget P_1)
		{
			if (P_1 == null)
			{
				return null;
			}
			Controller.Element elementById = P_0.GetElementById(P_1.elementIdentifierId);
			if (elementById == null)
			{
				return null;
			}
			return new List<PbLhtDmFPsNazvYLFQBoFqNdAtlL>
			{
				new PbLhtDmFPsNazvYLFQBoFqNdAtlL(P_1, elementById)
			};
		}

		private static IControllerTemplateElement nZHQVsgVTUQcIoUXkGNrGIPCwOzc(List<IControllerTemplateElement> P_0, int P_1)
		{
			int count = P_0.Count;
			for (int i = 0; i < count; i++)
			{
				if (P_0[i].id == P_1)
				{
					return P_0[i];
				}
			}
			return null;
		}

		private static sNACywUzLRIlnfbDvzRcJlkFTFTb IdaaQBJQnEYKOoXGgCRtlIWpoEQAA(IControllerTemplate P_0, ADictionary<int, IControllerTemplateElement> P_1, int P_2)
		{
			if (!(P_1.GetValueSafe(P_2) is sNACywUzLRIlnfbDvzRcJlkFTFTb result))
			{
				return ZLOgUXjjWrIpfPEbmgeGsxJWJjEy.ckrUQVcMUnHdCWgDQIywBRRTSKOn(P_0);
			}
			return result;
		}

		private static sNACywUzLRIlnfbDvzRcJlkFTFTb jodeWACReFvZpoQyUvqnhZRwyafZ(IControllerTemplate P_0, ADictionary<int, IControllerTemplateElement> P_1, int P_2)
		{
			if (!(P_1.GetValueSafe(P_2) is sNACywUzLRIlnfbDvzRcJlkFTFTb result))
			{
				return yzeaXMAenzWpurIfbwmsEFPXmIPUA.ckrUQVcMUnHdCWgDQIywBRRTSKOn(P_0);
			}
			return result;
		}
	}
}
