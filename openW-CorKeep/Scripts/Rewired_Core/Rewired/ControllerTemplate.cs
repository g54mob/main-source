using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Internal.Localization;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using UnityEngine;

namespace Rewired
{
	public abstract class ControllerTemplate : IControllerTemplate, IControllerTemplate_Internal, gDrCmzJNXwFvGTMAYKGQspUqeYD
	{
		internal abstract class YYjpTGeypKuHJYOzvnyAyPmfPEfn : IControllerTemplateElement, IControllerTemplateElement_Internal
		{
			private readonly IControllerTemplate xoSKWyOmGVNSnjJyGWfcYAFBMmFE;

			private readonly int ownGHACqwvxNwHvAuLOwFmUBjdkJA;

			private readonly ControllerTemplateElementType moCjHoajcfWZtooEZBDATqbrDsLK;

			protected readonly int hIYycpNuKVkvtikiONVlQOlOKoCf;

			protected readonly OoMOZEqfXndBIZKQcgmHDZDrhUwEA sEMyzuaAuQpccCtjGjlGOvSmQHOc;

			int IControllerTemplateElement.id
			{
				get
				{
					if (ReInput._id != hIYycpNuKVkvtikiONVlQOlOKoCf)
					{
						ReInput.CheckInitialized(hIYycpNuKVkvtikiONVlQOlOKoCf);
						return -1;
					}
					return ownGHACqwvxNwHvAuLOwFmUBjdkJA;
				}
			}

			string IControllerTemplateElement.descriptiveName
			{
				get
				{
					if (ReInput._id != hIYycpNuKVkvtikiONVlQOlOKoCf)
					{
						ReInput.CheckInitialized(hIYycpNuKVkvtikiONVlQOlOKoCf);
						return null;
					}
					return sEMyzuaAuQpccCtjGjlGOvSmQHOc.aVVdhXOnPqdAnZNJpkXLKIdxbTax;
				}
			}

			internal string kzwCANoFYBabwkDtKjaBIldKJbFt => sEMyzuaAuQpccCtjGjlGOvSmQHOc.nonLocalizedDescriptiveName;

			ControllerTemplateElementType IControllerTemplateElement.type
			{
				get
				{
					if (ReInput._id != hIYycpNuKVkvtikiONVlQOlOKoCf)
					{
						ReInput.CheckInitialized(hIYycpNuKVkvtikiONVlQOlOKoCf);
						return ControllerTemplateElementType.Axis;
					}
					return moCjHoajcfWZtooEZBDATqbrDsLK;
				}
			}

			IControllerTemplate IControllerTemplateElement_Internal.parent => xoSKWyOmGVNSnjJyGWfcYAFBMmFE;

			public abstract int elementCount { get; }

			public abstract IControllerTemplateElementSource source { get; }

			public abstract bool exists { get; }

			protected YYjpTGeypKuHJYOzvnyAyPmfPEfn(IControllerTemplate P_0, int P_1, ControllerTemplateElementType P_2, OoMOZEqfXndBIZKQcgmHDZDrhUwEA P_3)
			{
				if (P_0 == null)
				{
					throw new ArgumentNullException("parent");
				}
				if (P_3 == null)
				{
					throw new ArgumentNullException("localizedElement");
				}
				xoSKWyOmGVNSnjJyGWfcYAFBMmFE = P_0;
				ownGHACqwvxNwHvAuLOwFmUBjdkJA = P_1;
				moCjHoajcfWZtooEZBDATqbrDsLK = P_2;
				hIYycpNuKVkvtikiONVlQOlOKoCf = ReInput.id;
				sEMyzuaAuQpccCtjGjlGOvSmQHOc = P_3;
			}

			public abstract IControllerTemplateElement GetElement(int index);

			public abstract int GetElementTargets(ControllerElementTarget find, ref IList<ControllerTemplateElementTarget> list);

			protected static OoMOZEqfXndBIZKQcgmHDZDrhUwEA exOEPwnVAxgSUKBEuruZmkNQdAsYA(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3)
			{
				return ovuqbdJtztpjNNJlEglfEcWUcsC.OBPUvPZMoEiEURFsAXgmYYvnPZDt(new OoMOZEqfXndBIZKQcgmHDZDrhUwEA(sEXlAUCbXLgJeCGXnnfQvwGpFueGb.fmKrciPUOJBclJDgIwDlOQglnhbn(hhwQItrOtauBvPHQAFLgRDRQAhcP.ControllerTemplate, AomZkhATSIadYOOLVfcgOnNtMQBs.fyQKArxdnRgBFXnCTGFifmqgwogRA.Unknown, AomZkhATSIadYOOLVfcgOnNtMQBs.OUxgQpuZIuwKyJEylNPLslOwBwNAA.None, P_1, P_0.deviceLocalizationInfo), "controller/template", string.Empty, P_2, P_3));
			}
		}

		internal abstract class SToemRBqEpnrLmpbqrYWRGTIPeeBb : YYjpTGeypKuHJYOzvnyAyPmfPEfn
		{
			protected readonly int dPyyaYjKmzpTwmEREVFnsctPStqR;

			protected readonly hutPhcBnEQdPRoJEXCJgCtixxCeM[] UOQeuUVYPsJuDFKtpgRxFdrqspnd;

			bool YYjpTGeypKuHJYOzvnyAyPmfPEfn.exists
			{
				get
				{
					if (ReInput._id != hIYycpNuKVkvtikiONVlQOlOKoCf)
					{
						ReInput.CheckInitialized(hIYycpNuKVkvtikiONVlQOlOKoCf);
						return false;
					}
					if (UOQeuUVYPsJuDFKtpgRxFdrqspnd == null)
					{
						return false;
					}
					for (int i = 0; i < UOQeuUVYPsJuDFKtpgRxFdrqspnd.Length; i++)
					{
						if (UOQeuUVYPsJuDFKtpgRxFdrqspnd[i].qvamzwhoWxtDxCBmROcRJoqSsdpc != null)
						{
							return true;
						}
					}
					return false;
				}
			}

			protected SToemRBqEpnrLmpbqrYWRGTIPeeBb(IControllerTemplate P_0, int P_1, ControllerTemplateElementType P_2, IList<hutPhcBnEQdPRoJEXCJgCtixxCeM> P_3, OoMOZEqfXndBIZKQcgmHDZDrhUwEA P_4)
				: base(P_0, P_1, P_2, P_4)
			{
				UOQeuUVYPsJuDFKtpgRxFdrqspnd = ((P_3 != null) ? ListTools.ToArray(P_3) : null);
				dPyyaYjKmzpTwmEREVFnsctPStqR = ((UOQeuUVYPsJuDFKtpgRxFdrqspnd != null) ? UOQeuUVYPsJuDFKtpgRxFdrqspnd.Length : 0);
			}
		}

		internal abstract class AbuLYXhDofdMHjmwNPaBwEYJNRUkA : SToemRBqEpnrLmpbqrYWRGTIPeeBb, IControllerTemplateAxis, IControllerTemplateElement, IControllerTemplateButton
		{
			private eyXePMBLHAVdDBzdXMjLzHNfDAjcA WosvwaRCMdNAgEBVTnTXalbPrCUx;

			public float YFxIVraKdXlHlZAlXSoEOkhepJMx
			{
				get
				{
					if (ReInput._id != hIYycpNuKVkvtikiONVlQOlOKoCf)
					{
						ReInput.CheckInitialized(hIYycpNuKVkvtikiONVlQOlOKoCf);
						return 0f;
					}
					if (dPyyaYjKmzpTwmEREVFnsctPStqR == 1)
					{
						return UOQeuUVYPsJuDFKtpgRxFdrqspnd[0].tCcIrTkDIrtEqIhdHwhlUEYwljHAb;
					}
					if (dPyyaYjKmzpTwmEREVFnsctPStqR == 2)
					{
						float num = UOQeuUVYPsJuDFKtpgRxFdrqspnd[0].tCcIrTkDIrtEqIhdHwhlUEYwljHAb;
						float num2 = UOQeuUVYPsJuDFKtpgRxFdrqspnd[1].tCcIrTkDIrtEqIhdHwhlUEYwljHAb;
						return MathTools.Clamp(num + num2, -1f, 1f);
					}
					return 0f;
				}
			}

			public float IItEwoimcLCNkHpdpTYxCbYZcKbGb
			{
				get
				{
					if (ReInput._id != hIYycpNuKVkvtikiONVlQOlOKoCf)
					{
						ReInput.CheckInitialized(hIYycpNuKVkvtikiONVlQOlOKoCf);
						return 0f;
					}
					if (dPyyaYjKmzpTwmEREVFnsctPStqR == 1)
					{
						return UOQeuUVYPsJuDFKtpgRxFdrqspnd[0].FfsbKslVKHQpWWvuQfRgEYvtxRrg;
					}
					if (dPyyaYjKmzpTwmEREVFnsctPStqR == 2)
					{
						float num = UOQeuUVYPsJuDFKtpgRxFdrqspnd[0].FfsbKslVKHQpWWvuQfRgEYvtxRrg;
						float num2 = UOQeuUVYPsJuDFKtpgRxFdrqspnd[1].FfsbKslVKHQpWWvuQfRgEYvtxRrg;
						return MathTools.Clamp(num + num2, -1f, 1f);
					}
					return 0f;
				}
			}

			public bool uCirRUroEYvltGQwDzoHWrrBJvGI
			{
				get
				{
					if (ReInput._id != hIYycpNuKVkvtikiONVlQOlOKoCf)
					{
						ReInput.CheckInitialized(hIYycpNuKVkvtikiONVlQOlOKoCf);
						return false;
					}
					if (dPyyaYjKmzpTwmEREVFnsctPStqR == 1)
					{
						return UOQeuUVYPsJuDFKtpgRxFdrqspnd[0].tWWBIKWnxksDofQfZDGTIQDaEXjCb;
					}
					if (dPyyaYjKmzpTwmEREVFnsctPStqR == 2)
					{
						if (!UOQeuUVYPsJuDFKtpgRxFdrqspnd[0].tWWBIKWnxksDofQfZDGTIQDaEXjCb)
						{
							return UOQeuUVYPsJuDFKtpgRxFdrqspnd[1].tWWBIKWnxksDofQfZDGTIQDaEXjCb;
						}
						return true;
					}
					return false;
				}
			}

			public bool NuLsFEmTiFQynVloIxkZjHaKODav
			{
				get
				{
					if (ReInput._id != hIYycpNuKVkvtikiONVlQOlOKoCf)
					{
						ReInput.CheckInitialized(hIYycpNuKVkvtikiONVlQOlOKoCf);
						return false;
					}
					if (dPyyaYjKmzpTwmEREVFnsctPStqR == 1)
					{
						return UOQeuUVYPsJuDFKtpgRxFdrqspnd[0].nthTXFeOzKIoOMYVpOYjIEWKUOtP;
					}
					if (dPyyaYjKmzpTwmEREVFnsctPStqR == 2)
					{
						if (!UOQeuUVYPsJuDFKtpgRxFdrqspnd[0].nthTXFeOzKIoOMYVpOYjIEWKUOtP)
						{
							return UOQeuUVYPsJuDFKtpgRxFdrqspnd[1].nthTXFeOzKIoOMYVpOYjIEWKUOtP;
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
					if (ReInput._id != hIYycpNuKVkvtikiONVlQOlOKoCf)
					{
						ReInput.CheckInitialized(hIYycpNuKVkvtikiONVlQOlOKoCf);
						return null;
					}
					return qqxtFcWsOBtBfVnzRoTCqGJSFrTf.OdGxUGfUovSGJgnkYjYnNipuvQmF;
				}
			}

			string IControllerTemplateAxis.negativeDescriptiveName
			{
				get
				{
					if (ReInput._id != hIYycpNuKVkvtikiONVlQOlOKoCf)
					{
						ReInput.CheckInitialized(hIYycpNuKVkvtikiONVlQOlOKoCf);
						return null;
					}
					return qqxtFcWsOBtBfVnzRoTCqGJSFrTf.uoYKpdrZkiNlwjlxwtiJnvtEgahA;
				}
			}

			float IControllerTemplateAxis.value
			{
				get
				{
					if (ReInput._id != hIYycpNuKVkvtikiONVlQOlOKoCf)
					{
						ReInput.CheckInitialized(hIYycpNuKVkvtikiONVlQOlOKoCf);
						return 0f;
					}
					return YFxIVraKdXlHlZAlXSoEOkhepJMx;
				}
			}

			float IControllerTemplateAxis.valuePrev
			{
				get
				{
					if (ReInput._id != hIYycpNuKVkvtikiONVlQOlOKoCf)
					{
						ReInput.CheckInitialized(hIYycpNuKVkvtikiONVlQOlOKoCf);
						return 0f;
					}
					return IItEwoimcLCNkHpdpTYxCbYZcKbGb;
				}
			}

			IControllerTemplateAxisSource IControllerTemplateAxis.source
			{
				get
				{
					if (ReInput._id != hIYycpNuKVkvtikiONVlQOlOKoCf)
					{
						ReInput.CheckInitialized(hIYycpNuKVkvtikiONVlQOlOKoCf);
						return null;
					}
					return WosvwaRCMdNAgEBVTnTXalbPrCUx;
				}
			}

			bool IControllerTemplateButton.value
			{
				get
				{
					if (ReInput._id != hIYycpNuKVkvtikiONVlQOlOKoCf)
					{
						ReInput.CheckInitialized(hIYycpNuKVkvtikiONVlQOlOKoCf);
						return false;
					}
					return uCirRUroEYvltGQwDzoHWrrBJvGI;
				}
			}

			bool IControllerTemplateButton.valuePrev
			{
				get
				{
					if (ReInput._id != hIYycpNuKVkvtikiONVlQOlOKoCf)
					{
						ReInput.CheckInitialized(hIYycpNuKVkvtikiONVlQOlOKoCf);
						return false;
					}
					return NuLsFEmTiFQynVloIxkZjHaKODav;
				}
			}

			bool IControllerTemplateButton.justPressed
			{
				get
				{
					if (ReInput._id != hIYycpNuKVkvtikiONVlQOlOKoCf)
					{
						ReInput.CheckInitialized(hIYycpNuKVkvtikiONVlQOlOKoCf);
						return false;
					}
					if (dPyyaYjKmzpTwmEREVFnsctPStqR == 1)
					{
						return UOQeuUVYPsJuDFKtpgRxFdrqspnd[0].IQKyhEaErJtbbCCBYSrGzpWvnNfF;
					}
					if (dPyyaYjKmzpTwmEREVFnsctPStqR == 2)
					{
						if (!UOQeuUVYPsJuDFKtpgRxFdrqspnd[0].IQKyhEaErJtbbCCBYSrGzpWvnNfF || UOQeuUVYPsJuDFKtpgRxFdrqspnd[1].nthTXFeOzKIoOMYVpOYjIEWKUOtP)
						{
							if (UOQeuUVYPsJuDFKtpgRxFdrqspnd[1].IQKyhEaErJtbbCCBYSrGzpWvnNfF)
							{
								return !UOQeuUVYPsJuDFKtpgRxFdrqspnd[0].nthTXFeOzKIoOMYVpOYjIEWKUOtP;
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
					if (ReInput._id != hIYycpNuKVkvtikiONVlQOlOKoCf)
					{
						ReInput.CheckInitialized(hIYycpNuKVkvtikiONVlQOlOKoCf);
						return false;
					}
					if (dPyyaYjKmzpTwmEREVFnsctPStqR == 1)
					{
						return UOQeuUVYPsJuDFKtpgRxFdrqspnd[0].dFNtsWKDbuZolWNvThlfOoDpOdUx;
					}
					if (dPyyaYjKmzpTwmEREVFnsctPStqR == 2)
					{
						if (!UOQeuUVYPsJuDFKtpgRxFdrqspnd[0].dFNtsWKDbuZolWNvThlfOoDpOdUx || UOQeuUVYPsJuDFKtpgRxFdrqspnd[1].tWWBIKWnxksDofQfZDGTIQDaEXjCb)
						{
							if (UOQeuUVYPsJuDFKtpgRxFdrqspnd[1].dFNtsWKDbuZolWNvThlfOoDpOdUx)
							{
								return !UOQeuUVYPsJuDFKtpgRxFdrqspnd[0].tWWBIKWnxksDofQfZDGTIQDaEXjCb;
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
					if (ReInput._id != hIYycpNuKVkvtikiONVlQOlOKoCf)
					{
						ReInput.CheckInitialized(hIYycpNuKVkvtikiONVlQOlOKoCf);
						return false;
					}
					return uCirRUroEYvltGQwDzoHWrrBJvGI != NuLsFEmTiFQynVloIxkZjHaKODav;
				}
			}

			float IControllerTemplateButton.pressure
			{
				get
				{
					if (ReInput._id != hIYycpNuKVkvtikiONVlQOlOKoCf)
					{
						ReInput.CheckInitialized(hIYycpNuKVkvtikiONVlQOlOKoCf);
						return 0f;
					}
					return YFxIVraKdXlHlZAlXSoEOkhepJMx;
				}
			}

			float IControllerTemplateButton.pressurePrev
			{
				get
				{
					if (ReInput._id != hIYycpNuKVkvtikiONVlQOlOKoCf)
					{
						ReInput.CheckInitialized(hIYycpNuKVkvtikiONVlQOlOKoCf);
						return 0f;
					}
					return IItEwoimcLCNkHpdpTYxCbYZcKbGb;
				}
			}

			IControllerTemplateButtonSource IControllerTemplateButton.source
			{
				get
				{
					if (ReInput._id != hIYycpNuKVkvtikiONVlQOlOKoCf)
					{
						ReInput.CheckInitialized(hIYycpNuKVkvtikiONVlQOlOKoCf);
						return null;
					}
					return WosvwaRCMdNAgEBVTnTXalbPrCUx;
				}
			}

			IControllerTemplateElementSource YYjpTGeypKuHJYOzvnyAyPmfPEfn.source
			{
				get
				{
					if (ReInput._id != hIYycpNuKVkvtikiONVlQOlOKoCf)
					{
						ReInput.CheckInitialized(hIYycpNuKVkvtikiONVlQOlOKoCf);
						return null;
					}
					return WosvwaRCMdNAgEBVTnTXalbPrCUx;
				}
			}

			int YYjpTGeypKuHJYOzvnyAyPmfPEfn.elementCount => 0;

			IControllerTemplateAxis IControllerTemplateButton.AsAxis
			{
				get
				{
					if (ReInput._id != hIYycpNuKVkvtikiONVlQOlOKoCf)
					{
						ReInput.CheckInitialized(hIYycpNuKVkvtikiONVlQOlOKoCf);
						return null;
					}
					return this;
				}
			}

			IControllerTemplateButton IControllerTemplateAxis.AsButton
			{
				get
				{
					if (ReInput._id != hIYycpNuKVkvtikiONVlQOlOKoCf)
					{
						ReInput.CheckInitialized(hIYycpNuKVkvtikiONVlQOlOKoCf);
						return null;
					}
					return this;
				}
			}

			protected OiaFmiQUHWOGZzaOlpbuggwRuWBd qqxtFcWsOBtBfVnzRoTCqGJSFrTf => (OiaFmiQUHWOGZzaOlpbuggwRuWBd)sEMyzuaAuQpccCtjGjlGOvSmQHOc;

			protected AbuLYXhDofdMHjmwNPaBwEYJNRUkA(IControllerTemplate P_0, int P_1, ControllerTemplateElementType P_2, eyXePMBLHAVdDBzdXMjLzHNfDAjcA P_3, IList<hutPhcBnEQdPRoJEXCJgCtixxCeM> P_4, OiaFmiQUHWOGZzaOlpbuggwRuWBd P_5)
				: base(P_0, P_1, P_2, P_4, P_5)
			{
				if (P_4 != null && P_4.Count > 2)
				{
					throw new ArgumentOutOfRangeException("sourceElements.Count must be <= 2.");
				}
				if (P_3 == null)
				{
					throw new ArgumentNullException("target");
				}
				WosvwaRCMdNAgEBVTnTXalbPrCUx = P_3;
			}

			string IControllerTemplateAxis.GetDescriptiveName(AxisRange axisRange)
			{
				if (ReInput._id != hIYycpNuKVkvtikiONVlQOlOKoCf)
				{
					ReInput.CheckInitialized(hIYycpNuKVkvtikiONVlQOlOKoCf);
					return null;
				}
				return axisRange switch
				{
					AxisRange.Full => base.Rewired_002EIControllerTemplateElement_002EdescriptiveName, 
					AxisRange.Positive => ((IControllerTemplateAxis)this).positiveDescriptiveName, 
					AxisRange.Negative => ((IControllerTemplateAxis)this).negativeDescriptiveName, 
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
				switch (base.Rewired_002EIControllerTemplateElement_002Etype)
				{
				case ControllerTemplateElementType.Axis:
				{
					IControllerTemplateAxisSource wosvwaRCMdNAgEBVTnTXalbPrCUx = WosvwaRCMdNAgEBVTnTXalbPrCUx;
					if (wosvwaRCMdNAgEBVTnTXalbPrCUx.splitAxis)
					{
						if (LipwXryGIZJdcIszNBiHVMUZFvPDA(find, wosvwaRCMdNAgEBVTnTXalbPrCUx.positiveTarget))
						{
							ListTools.AddAndCreateList(ref list, new ControllerTemplateElementTarget(this, AxisRange.Positive));
							num++;
						}
						if (LipwXryGIZJdcIszNBiHVMUZFvPDA(find, wosvwaRCMdNAgEBVTnTXalbPrCUx.negativeTarget))
						{
							ListTools.AddAndCreateList(ref list, new ControllerTemplateElementTarget(this, AxisRange.Negative));
							num++;
						}
					}
					else if (LipwXryGIZJdcIszNBiHVMUZFvPDA(find, wosvwaRCMdNAgEBVTnTXalbPrCUx.fullTarget))
					{
						ListTools.AddAndCreateList(ref list, new ControllerTemplateElementTarget(this, find.axisRange));
						num++;
					}
					break;
				}
				case ControllerTemplateElementType.Button:
					if (LipwXryGIZJdcIszNBiHVMUZFvPDA(find, ((IControllerTemplateButtonSource)WosvwaRCMdNAgEBVTnTXalbPrCUx).target))
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

			private static bool LipwXryGIZJdcIszNBiHVMUZFvPDA(ControllerElementTarget P_0, IControllerElementTarget P_1)
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

		internal sealed class vyUuyGVoBSHRAeomrSKtoxAdqJC : AbuLYXhDofdMHjmwNPaBwEYJNRUkA
		{
			public vyUuyGVoBSHRAeomrSKtoxAdqJC(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, string P_4, string P_5, string P_6, string P_7, eyXePMBLHAVdDBzdXMjLzHNfDAjcA P_8, IList<hutPhcBnEQdPRoJEXCJgCtixxCeM> P_9)
				: base(P_0, P_1, ControllerTemplateElementType.Axis, P_8, P_9, (OiaFmiQUHWOGZzaOlpbuggwRuWBd)ovuqbdJtztpjNNJlEglfEcWUcsC.OBPUvPZMoEiEURFsAXgmYYvnPZDt(new OiaFmiQUHWOGZzaOlpbuggwRuWBd(mbAaHTOiYxhnyoaJRfjMoaCGrCBj.PHAhhRPLzHDfseWMDCrNMEkhakyR(hhwQItrOtauBvPHQAFLgRDRQAhcP.ControllerTemplate, AomZkhATSIadYOOLVfcgOnNtMQBs.fyQKArxdnRgBFXnCTGFifmqgwogRA.Axis, AomZkhATSIadYOOLVfcgOnNtMQBs.OUxgQpuZIuwKyJEylNPLslOwBwNAA.None, P_1, P_0.deviceLocalizationInfo), "controller/template", string.Empty, P_2, P_3, P_4, P_5, P_6, P_7)))
			{
				if (P_9 != null && P_9.Count > 2)
				{
					throw new ArgumentOutOfRangeException("sourceElements.Count must be <= 2.");
				}
			}

			internal static vyUuyGVoBSHRAeomrSKtoxAdqJC kBqrzRiVlVLxekJwbdIPmLPZtUDA(IControllerTemplate_Internal P_0)
			{
				return new vyUuyGVoBSHRAeomrSKtoxAdqJC(P_0, -1, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, eyXePMBLHAVdDBzdXMjLzHNfDAjcA.fycPWQxAWErCODAuTpxKKuGkZEgl(ControllerTemplateElementType.Axis), null);
			}
		}

		internal sealed class WSWBqdXhsJebMVCilWvuKFuXCKMAA : AbuLYXhDofdMHjmwNPaBwEYJNRUkA
		{
			public WSWBqdXhsJebMVCilWvuKFuXCKMAA(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, string P_4, string P_5, string P_6, string P_7, eyXePMBLHAVdDBzdXMjLzHNfDAjcA P_8, IList<hutPhcBnEQdPRoJEXCJgCtixxCeM> P_9)
				: base(P_0, P_1, ControllerTemplateElementType.Button, P_8, P_9, (OiaFmiQUHWOGZzaOlpbuggwRuWBd)ovuqbdJtztpjNNJlEglfEcWUcsC.OBPUvPZMoEiEURFsAXgmYYvnPZDt(new OiaFmiQUHWOGZzaOlpbuggwRuWBd(mbAaHTOiYxhnyoaJRfjMoaCGrCBj.PHAhhRPLzHDfseWMDCrNMEkhakyR(hhwQItrOtauBvPHQAFLgRDRQAhcP.ControllerTemplate, AomZkhATSIadYOOLVfcgOnNtMQBs.fyQKArxdnRgBFXnCTGFifmqgwogRA.Button, AomZkhATSIadYOOLVfcgOnNtMQBs.OUxgQpuZIuwKyJEylNPLslOwBwNAA.None, P_1, P_0.deviceLocalizationInfo), "controller/template", string.Empty, P_2, P_3, P_4, P_5, P_6, P_7)))
			{
				if (P_9 != null && P_9.Count > 1)
				{
					throw new ArgumentOutOfRangeException("sourceElements.Count must be <= 1.");
				}
			}

			internal static WSWBqdXhsJebMVCilWvuKFuXCKMAA JezrnTUUJQotMkMMdixlBvVtesvo(IControllerTemplate_Internal P_0)
			{
				return new WSWBqdXhsJebMVCilWvuKFuXCKMAA(P_0, -1, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, eyXePMBLHAVdDBzdXMjLzHNfDAjcA.fycPWQxAWErCODAuTpxKKuGkZEgl(ControllerTemplateElementType.Button), null);
			}
		}

		internal abstract class wNKivkbIlmRMTVMgvDSrylsFkKGS : YYjpTGeypKuHJYOzvnyAyPmfPEfn
		{
			protected readonly int LceoRiCDpblCcFhvCVlSwEvtAhOiA;

			protected readonly YYjpTGeypKuHJYOzvnyAyPmfPEfn[] JcpwrGaoIHLqoZNdwXdGWaSfvilM;

			bool YYjpTGeypKuHJYOzvnyAyPmfPEfn.exists
			{
				get
				{
					if (ReInput._id != hIYycpNuKVkvtikiONVlQOlOKoCf)
					{
						ReInput.CheckInitialized(hIYycpNuKVkvtikiONVlQOlOKoCf);
						return false;
					}
					for (int i = 0; i < LceoRiCDpblCcFhvCVlSwEvtAhOiA; i++)
					{
						if (JcpwrGaoIHLqoZNdwXdGWaSfvilM[i].exists)
						{
							return true;
						}
					}
					return false;
				}
			}

			IControllerTemplateElementSource YYjpTGeypKuHJYOzvnyAyPmfPEfn.source
			{
				get
				{
					if (ReInput._id != hIYycpNuKVkvtikiONVlQOlOKoCf)
					{
						ReInput.CheckInitialized(hIYycpNuKVkvtikiONVlQOlOKoCf);
						return null;
					}
					return null;
				}
			}

			int YYjpTGeypKuHJYOzvnyAyPmfPEfn.elementCount => LceoRiCDpblCcFhvCVlSwEvtAhOiA;

			protected wNKivkbIlmRMTVMgvDSrylsFkKGS(IControllerTemplate P_0, int P_1, ControllerTemplateElementType P_2, YYjpTGeypKuHJYOzvnyAyPmfPEfn[] P_3, OoMOZEqfXndBIZKQcgmHDZDrhUwEA P_4)
				: base(P_0, P_1, P_2, P_4)
			{
				if (P_3 == null)
				{
					throw new ArgumentNullException("elements");
				}
				if (P_3.Length == 0)
				{
					throw new ArgumentException("elements.Length is zero.");
				}
				for (int i = 0; i < P_3.Length; i++)
				{
					if (P_3[i] == null)
					{
						throw new ArgumentNullException("elements contains a null entry.");
					}
				}
				JcpwrGaoIHLqoZNdwXdGWaSfvilM = P_3;
				LceoRiCDpblCcFhvCVlSwEvtAhOiA = P_3.Length;
			}

			public virtual IControllerTemplateElement BlQtRryaFlaYtUXPSxphNbZZeZebA(int P_0)
			{
				return JcpwrGaoIHLqoZNdwXdGWaSfvilM[P_0];
			}

			public virtual int lBRdIjCxyEdVimCdGqCYeakqPRpeb(ControllerElementTarget P_0, ref IList<ControllerTemplateElementTarget> P_1)
			{
				int num = 0;
				for (int i = 0; i < JcpwrGaoIHLqoZNdwXdGWaSfvilM.Length; i++)
				{
					num += JcpwrGaoIHLqoZNdwXdGWaSfvilM[i].GetElementTargets(P_0, ref P_1);
				}
				return num;
			}
		}

		internal abstract class OWhgNEkCVNxNyvxERsCrYKgigVwW : wNKivkbIlmRMTVMgvDSrylsFkKGS, IControllerTemplateAxis2D, IControllerTemplateElement
		{
			protected const int YohiGVESxyTYIzkYvKOAriEKnfgr = 0;

			protected const int nRDdKJGzBSuGNAjDibhKIfDijhCSb = 1;

			protected const int UaEXJZgSCIIitoCARVLmRZyYiVGJ = 2;

			Vector2 IControllerTemplateAxis2D.value
			{
				get
				{
					if (ReInput._id != hIYycpNuKVkvtikiONVlQOlOKoCf)
					{
						ReInput.CheckInitialized(hIYycpNuKVkvtikiONVlQOlOKoCf);
						return Vector2.zero;
					}
					return new Vector2((LceoRiCDpblCcFhvCVlSwEvtAhOiA > 0) ? ((AbuLYXhDofdMHjmwNPaBwEYJNRUkA)JcpwrGaoIHLqoZNdwXdGWaSfvilM[0]).YFxIVraKdXlHlZAlXSoEOkhepJMx : 0f, (LceoRiCDpblCcFhvCVlSwEvtAhOiA > 1) ? ((AbuLYXhDofdMHjmwNPaBwEYJNRUkA)JcpwrGaoIHLqoZNdwXdGWaSfvilM[1]).YFxIVraKdXlHlZAlXSoEOkhepJMx : 0f);
				}
			}

			Vector2 IControllerTemplateAxis2D.valuePrev
			{
				get
				{
					if (ReInput._id != hIYycpNuKVkvtikiONVlQOlOKoCf)
					{
						ReInput.CheckInitialized(hIYycpNuKVkvtikiONVlQOlOKoCf);
						return Vector2.zero;
					}
					return new Vector2((LceoRiCDpblCcFhvCVlSwEvtAhOiA > 0) ? ((AbuLYXhDofdMHjmwNPaBwEYJNRUkA)JcpwrGaoIHLqoZNdwXdGWaSfvilM[0]).IItEwoimcLCNkHpdpTYxCbYZcKbGb : 0f, (LceoRiCDpblCcFhvCVlSwEvtAhOiA > 1) ? ((AbuLYXhDofdMHjmwNPaBwEYJNRUkA)JcpwrGaoIHLqoZNdwXdGWaSfvilM[1]).IItEwoimcLCNkHpdpTYxCbYZcKbGb : 0f);
				}
			}

			IControllerTemplateAxis IControllerTemplateAxis2D.horizontal
			{
				get
				{
					if (ReInput._id != hIYycpNuKVkvtikiONVlQOlOKoCf)
					{
						ReInput.CheckInitialized(hIYycpNuKVkvtikiONVlQOlOKoCf);
						return null;
					}
					return (IControllerTemplateAxis)JcpwrGaoIHLqoZNdwXdGWaSfvilM[0];
				}
			}

			IControllerTemplateAxis IControllerTemplateAxis2D.vertical
			{
				get
				{
					if (ReInput._id != hIYycpNuKVkvtikiONVlQOlOKoCf)
					{
						ReInput.CheckInitialized(hIYycpNuKVkvtikiONVlQOlOKoCf);
						return null;
					}
					return (IControllerTemplateAxis)JcpwrGaoIHLqoZNdwXdGWaSfvilM[1];
				}
			}

			protected OWhgNEkCVNxNyvxERsCrYKgigVwW(IControllerTemplate P_0, int P_1, ControllerTemplateElementType P_2, YYjpTGeypKuHJYOzvnyAyPmfPEfn[] P_3, OoMOZEqfXndBIZKQcgmHDZDrhUwEA P_4)
				: base(P_0, P_1, P_2, P_3, P_4)
			{
			}
		}

		internal abstract class SoxKdmIuAhUJVMNePTaIUkAdwrNm : wNKivkbIlmRMTVMgvDSrylsFkKGS, IControllerTemplateAxis3D, IControllerTemplateElement
		{
			protected const int VEqHlmcBzXGasazBzUWigllhKxmrB = 0;

			protected const int xMMPyKAOkJnTGYVjPFxuMLSQdtDP = 1;

			protected const int TJybHcSzQiJbHxfDMrrhMmSBFEmB = 2;

			protected const int GnEVxFarQSSSdoWffcTMbBmZmEjt = 3;

			Vector3 IControllerTemplateAxis3D.value
			{
				get
				{
					if (ReInput._id != hIYycpNuKVkvtikiONVlQOlOKoCf)
					{
						ReInput.CheckInitialized(hIYycpNuKVkvtikiONVlQOlOKoCf);
						return Vector3.zero;
					}
					return new Vector3((LceoRiCDpblCcFhvCVlSwEvtAhOiA > 0) ? ((AbuLYXhDofdMHjmwNPaBwEYJNRUkA)JcpwrGaoIHLqoZNdwXdGWaSfvilM[0]).YFxIVraKdXlHlZAlXSoEOkhepJMx : 0f, (LceoRiCDpblCcFhvCVlSwEvtAhOiA > 1) ? ((AbuLYXhDofdMHjmwNPaBwEYJNRUkA)JcpwrGaoIHLqoZNdwXdGWaSfvilM[1]).YFxIVraKdXlHlZAlXSoEOkhepJMx : 0f, (LceoRiCDpblCcFhvCVlSwEvtAhOiA > 2) ? ((AbuLYXhDofdMHjmwNPaBwEYJNRUkA)JcpwrGaoIHLqoZNdwXdGWaSfvilM[2]).YFxIVraKdXlHlZAlXSoEOkhepJMx : 0f);
				}
			}

			Vector3 IControllerTemplateAxis3D.valuePrev
			{
				get
				{
					if (ReInput._id != hIYycpNuKVkvtikiONVlQOlOKoCf)
					{
						ReInput.CheckInitialized(hIYycpNuKVkvtikiONVlQOlOKoCf);
						return Vector3.zero;
					}
					return new Vector3((LceoRiCDpblCcFhvCVlSwEvtAhOiA > 0) ? ((AbuLYXhDofdMHjmwNPaBwEYJNRUkA)JcpwrGaoIHLqoZNdwXdGWaSfvilM[0]).IItEwoimcLCNkHpdpTYxCbYZcKbGb : 0f, (LceoRiCDpblCcFhvCVlSwEvtAhOiA > 1) ? ((AbuLYXhDofdMHjmwNPaBwEYJNRUkA)JcpwrGaoIHLqoZNdwXdGWaSfvilM[1]).IItEwoimcLCNkHpdpTYxCbYZcKbGb : 0f, (LceoRiCDpblCcFhvCVlSwEvtAhOiA > 2) ? ((AbuLYXhDofdMHjmwNPaBwEYJNRUkA)JcpwrGaoIHLqoZNdwXdGWaSfvilM[2]).IItEwoimcLCNkHpdpTYxCbYZcKbGb : 0f);
				}
			}

			IControllerTemplateAxis IControllerTemplateAxis3D.horizontal
			{
				get
				{
					if (ReInput._id != hIYycpNuKVkvtikiONVlQOlOKoCf)
					{
						ReInput.CheckInitialized(hIYycpNuKVkvtikiONVlQOlOKoCf);
						return null;
					}
					return (IControllerTemplateAxis)JcpwrGaoIHLqoZNdwXdGWaSfvilM[0];
				}
			}

			IControllerTemplateAxis IControllerTemplateAxis3D.vertical
			{
				get
				{
					if (ReInput._id != hIYycpNuKVkvtikiONVlQOlOKoCf)
					{
						ReInput.CheckInitialized(hIYycpNuKVkvtikiONVlQOlOKoCf);
						return null;
					}
					return (IControllerTemplateAxis)JcpwrGaoIHLqoZNdwXdGWaSfvilM[1];
				}
			}

			IControllerTemplateAxis IControllerTemplateAxis3D.depth
			{
				get
				{
					if (ReInput._id != hIYycpNuKVkvtikiONVlQOlOKoCf)
					{
						ReInput.CheckInitialized(hIYycpNuKVkvtikiONVlQOlOKoCf);
						return null;
					}
					return (IControllerTemplateAxis)JcpwrGaoIHLqoZNdwXdGWaSfvilM[2];
				}
			}

			protected SoxKdmIuAhUJVMNePTaIUkAdwrNm(IControllerTemplate_Internal P_0, int P_1, ControllerTemplateElementType P_2, YYjpTGeypKuHJYOzvnyAyPmfPEfn[] P_3, OoMOZEqfXndBIZKQcgmHDZDrhUwEA P_4)
				: base(P_0, P_1, P_2, P_3, P_4)
			{
			}
		}

		internal abstract class uHPsBjnKfTjCTALFwWotfAPBIlLpA : wNKivkbIlmRMTVMgvDSrylsFkKGS, IControllerTemplateAxis6D, IControllerTemplateElement
		{
			protected const int juKcYJbhhdIDTrhraqDBxhkFmqCz = 0;

			protected const int IFCCTeHooeJLuQaQdBlSQtEavMlH = 1;

			protected const int uBDxZizeaJUlvYqsEBFDwgaYtoN = 2;

			protected const int BrHakFyvSDNVjsNMafxJBSFlRWqT = 3;

			protected const int KwZgLwhZYYQslUQJXYhnoVjjLMDVA = 4;

			protected const int DAuyokEiDrlXIZjAtUxtdoitckvg = 5;

			protected const int rRLrqLHUCDWeDDwLtzzaxOJRfHCF = 6;

			Vector3 IControllerTemplateAxis6D.position
			{
				get
				{
					if (ReInput._id != hIYycpNuKVkvtikiONVlQOlOKoCf)
					{
						ReInput.CheckInitialized(hIYycpNuKVkvtikiONVlQOlOKoCf);
						return Vector3.zero;
					}
					return new Vector3((LceoRiCDpblCcFhvCVlSwEvtAhOiA > 0) ? ((AbuLYXhDofdMHjmwNPaBwEYJNRUkA)JcpwrGaoIHLqoZNdwXdGWaSfvilM[0]).YFxIVraKdXlHlZAlXSoEOkhepJMx : 0f, (LceoRiCDpblCcFhvCVlSwEvtAhOiA > 1) ? ((AbuLYXhDofdMHjmwNPaBwEYJNRUkA)JcpwrGaoIHLqoZNdwXdGWaSfvilM[1]).YFxIVraKdXlHlZAlXSoEOkhepJMx : 0f, (LceoRiCDpblCcFhvCVlSwEvtAhOiA > 2) ? ((AbuLYXhDofdMHjmwNPaBwEYJNRUkA)JcpwrGaoIHLqoZNdwXdGWaSfvilM[2]).YFxIVraKdXlHlZAlXSoEOkhepJMx : 0f);
				}
			}

			Vector3 IControllerTemplateAxis6D.positionPrev
			{
				get
				{
					if (ReInput._id != hIYycpNuKVkvtikiONVlQOlOKoCf)
					{
						ReInput.CheckInitialized(hIYycpNuKVkvtikiONVlQOlOKoCf);
						return Vector3.zero;
					}
					return new Vector3((LceoRiCDpblCcFhvCVlSwEvtAhOiA > 0) ? ((AbuLYXhDofdMHjmwNPaBwEYJNRUkA)JcpwrGaoIHLqoZNdwXdGWaSfvilM[0]).IItEwoimcLCNkHpdpTYxCbYZcKbGb : 0f, (LceoRiCDpblCcFhvCVlSwEvtAhOiA > 1) ? ((AbuLYXhDofdMHjmwNPaBwEYJNRUkA)JcpwrGaoIHLqoZNdwXdGWaSfvilM[1]).IItEwoimcLCNkHpdpTYxCbYZcKbGb : 0f, (LceoRiCDpblCcFhvCVlSwEvtAhOiA > 2) ? ((AbuLYXhDofdMHjmwNPaBwEYJNRUkA)JcpwrGaoIHLqoZNdwXdGWaSfvilM[2]).IItEwoimcLCNkHpdpTYxCbYZcKbGb : 0f);
				}
			}

			Vector3 IControllerTemplateAxis6D.rotation
			{
				get
				{
					if (ReInput._id != hIYycpNuKVkvtikiONVlQOlOKoCf)
					{
						ReInput.CheckInitialized(hIYycpNuKVkvtikiONVlQOlOKoCf);
						return Vector3.zero;
					}
					return new Vector3((LceoRiCDpblCcFhvCVlSwEvtAhOiA > 3) ? ((AbuLYXhDofdMHjmwNPaBwEYJNRUkA)JcpwrGaoIHLqoZNdwXdGWaSfvilM[3]).YFxIVraKdXlHlZAlXSoEOkhepJMx : 0f, (LceoRiCDpblCcFhvCVlSwEvtAhOiA > 4) ? ((AbuLYXhDofdMHjmwNPaBwEYJNRUkA)JcpwrGaoIHLqoZNdwXdGWaSfvilM[4]).YFxIVraKdXlHlZAlXSoEOkhepJMx : 0f, (LceoRiCDpblCcFhvCVlSwEvtAhOiA > 5) ? ((AbuLYXhDofdMHjmwNPaBwEYJNRUkA)JcpwrGaoIHLqoZNdwXdGWaSfvilM[5]).YFxIVraKdXlHlZAlXSoEOkhepJMx : 0f);
				}
			}

			Vector3 IControllerTemplateAxis6D.rotationPrev
			{
				get
				{
					if (ReInput._id != hIYycpNuKVkvtikiONVlQOlOKoCf)
					{
						ReInput.CheckInitialized(hIYycpNuKVkvtikiONVlQOlOKoCf);
						return Vector3.zero;
					}
					return new Vector3((LceoRiCDpblCcFhvCVlSwEvtAhOiA > 3) ? ((AbuLYXhDofdMHjmwNPaBwEYJNRUkA)JcpwrGaoIHLqoZNdwXdGWaSfvilM[3]).IItEwoimcLCNkHpdpTYxCbYZcKbGb : 0f, (LceoRiCDpblCcFhvCVlSwEvtAhOiA > 4) ? ((AbuLYXhDofdMHjmwNPaBwEYJNRUkA)JcpwrGaoIHLqoZNdwXdGWaSfvilM[4]).IItEwoimcLCNkHpdpTYxCbYZcKbGb : 0f, (LceoRiCDpblCcFhvCVlSwEvtAhOiA > 5) ? ((AbuLYXhDofdMHjmwNPaBwEYJNRUkA)JcpwrGaoIHLqoZNdwXdGWaSfvilM[5]).IItEwoimcLCNkHpdpTYxCbYZcKbGb : 0f);
				}
			}

			IControllerTemplateAxis IControllerTemplateAxis6D.positionX
			{
				get
				{
					if (ReInput._id != hIYycpNuKVkvtikiONVlQOlOKoCf)
					{
						ReInput.CheckInitialized(hIYycpNuKVkvtikiONVlQOlOKoCf);
						return null;
					}
					return (IControllerTemplateAxis)JcpwrGaoIHLqoZNdwXdGWaSfvilM[0];
				}
			}

			IControllerTemplateAxis IControllerTemplateAxis6D.positionY
			{
				get
				{
					if (ReInput._id != hIYycpNuKVkvtikiONVlQOlOKoCf)
					{
						ReInput.CheckInitialized(hIYycpNuKVkvtikiONVlQOlOKoCf);
						return null;
					}
					return (IControllerTemplateAxis)JcpwrGaoIHLqoZNdwXdGWaSfvilM[1];
				}
			}

			IControllerTemplateAxis IControllerTemplateAxis6D.positionZ
			{
				get
				{
					if (ReInput._id != hIYycpNuKVkvtikiONVlQOlOKoCf)
					{
						ReInput.CheckInitialized(hIYycpNuKVkvtikiONVlQOlOKoCf);
						return null;
					}
					return (IControllerTemplateAxis)JcpwrGaoIHLqoZNdwXdGWaSfvilM[2];
				}
			}

			IControllerTemplateAxis IControllerTemplateAxis6D.rotationX
			{
				get
				{
					if (ReInput._id != hIYycpNuKVkvtikiONVlQOlOKoCf)
					{
						ReInput.CheckInitialized(hIYycpNuKVkvtikiONVlQOlOKoCf);
						return null;
					}
					return (IControllerTemplateAxis)JcpwrGaoIHLqoZNdwXdGWaSfvilM[3];
				}
			}

			IControllerTemplateAxis IControllerTemplateAxis6D.rotationY
			{
				get
				{
					if (ReInput._id != hIYycpNuKVkvtikiONVlQOlOKoCf)
					{
						ReInput.CheckInitialized(hIYycpNuKVkvtikiONVlQOlOKoCf);
						return null;
					}
					return (IControllerTemplateAxis)JcpwrGaoIHLqoZNdwXdGWaSfvilM[4];
				}
			}

			IControllerTemplateAxis IControllerTemplateAxis6D.rotationZ
			{
				get
				{
					if (ReInput._id != hIYycpNuKVkvtikiONVlQOlOKoCf)
					{
						ReInput.CheckInitialized(hIYycpNuKVkvtikiONVlQOlOKoCf);
						return null;
					}
					return (IControllerTemplateAxis)JcpwrGaoIHLqoZNdwXdGWaSfvilM[5];
				}
			}

			protected uHPsBjnKfTjCTALFwWotfAPBIlLpA(IControllerTemplate P_0, int P_1, ControllerTemplateElementType P_2, YYjpTGeypKuHJYOzvnyAyPmfPEfn[] P_3, OoMOZEqfXndBIZKQcgmHDZDrhUwEA P_4)
				: base(P_0, P_1, P_2, P_3, P_4)
			{
			}
		}

		internal sealed class kUPqUxzOtjXnFackMZynboOUUfOC : SoxKdmIuAhUJVMNePTaIUkAdwrNm, IControllerTemplateStick, IControllerTemplateElement
		{
			private const int VwEHvCtDYOzoAmarHDJXjftJuXJe = 3;

			IControllerTemplateAxis IControllerTemplateStick.rotation
			{
				get
				{
					if (ReInput._id != hIYycpNuKVkvtikiONVlQOlOKoCf)
					{
						ReInput.CheckInitialized(hIYycpNuKVkvtikiONVlQOlOKoCf);
						return null;
					}
					return (IControllerTemplateAxis)JcpwrGaoIHLqoZNdwXdGWaSfvilM[2];
				}
			}

			private kUPqUxzOtjXnFackMZynboOUUfOC(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, YYjpTGeypKuHJYOzvnyAyPmfPEfn[] P_4)
				: base(P_0, P_1, ControllerTemplateElementType.Stick, P_4, YYjpTGeypKuHJYOzvnyAyPmfPEfn.exOEPwnVAxgSUKBEuruZmkNQdAsYA(P_0, P_1, P_2, P_3))
			{
				if (P_4.Length != 3)
				{
					throw new ArgumentException("elements.Length must be " + 3);
				}
			}

			public kUPqUxzOtjXnFackMZynboOUUfOC(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, AbuLYXhDofdMHjmwNPaBwEYJNRUkA P_4, AbuLYXhDofdMHjmwNPaBwEYJNRUkA P_5, AbuLYXhDofdMHjmwNPaBwEYJNRUkA P_6)
				: this(P_0, P_1, P_2, P_3, new YYjpTGeypKuHJYOzvnyAyPmfPEfn[3] { P_4, P_5, P_6 })
			{
			}
		}

		internal sealed class lmsmNZTPnWFlvDONrYsywnZRaPrgA : OWhgNEkCVNxNyvxERsCrYKgigVwW, IControllerTemplateThumbStick, IControllerTemplateElement
		{
			private const int CiFKOFKFhoZaWevHyBeAnmqqhxVg = 2;

			private const int WKxPISgOukknuiCWfmApcktXQYvJ = 3;

			IControllerTemplateButton IControllerTemplateThumbStick.press
			{
				get
				{
					if (ReInput._id != hIYycpNuKVkvtikiONVlQOlOKoCf)
					{
						ReInput.CheckInitialized(hIYycpNuKVkvtikiONVlQOlOKoCf);
						return null;
					}
					return (IControllerTemplateButton)JcpwrGaoIHLqoZNdwXdGWaSfvilM[2];
				}
			}

			private lmsmNZTPnWFlvDONrYsywnZRaPrgA(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, YYjpTGeypKuHJYOzvnyAyPmfPEfn[] P_4)
				: base(P_0, P_1, ControllerTemplateElementType.ThumbStick, P_4, YYjpTGeypKuHJYOzvnyAyPmfPEfn.exOEPwnVAxgSUKBEuruZmkNQdAsYA(P_0, P_1, P_2, P_3))
			{
				if (P_4.Length != 3)
				{
					throw new ArgumentException("elements.Length must be " + 3);
				}
			}

			internal lmsmNZTPnWFlvDONrYsywnZRaPrgA(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, AbuLYXhDofdMHjmwNPaBwEYJNRUkA P_4, AbuLYXhDofdMHjmwNPaBwEYJNRUkA P_5, AbuLYXhDofdMHjmwNPaBwEYJNRUkA P_6)
				: this(P_0, P_1, P_2, P_3, new YYjpTGeypKuHJYOzvnyAyPmfPEfn[3] { P_4, P_5, P_6 })
			{
			}
		}

		internal sealed class ZpXhLSqRATskOTKsBaFdngDouhnV : wNKivkbIlmRMTVMgvDSrylsFkKGS, IControllerTemplateDPad, IControllerTemplateElement
		{
			private const int yBllZYuPkFdErDbIXEDfLQDqmFdH = 0;

			private const int kXGyQekfuiXovxBqVVRDlByrLIQm = 1;

			private const int YuQvZmzdruXdagVFyrSjcogXrPsO = 2;

			private const int TMndgPRQEMFlcjldDIgXSstayBGNA = 3;

			private const int ghgjUCzqJjGXNbeEdzlrUqSadFqcA = 4;

			private const int hgOWNUiQHwjiHQYljbttEJWvMTlA = 5;

			Vector2 IControllerTemplateDPad.value
			{
				get
				{
					if (ReInput._id != hIYycpNuKVkvtikiONVlQOlOKoCf)
					{
						ReInput.CheckInitialized(hIYycpNuKVkvtikiONVlQOlOKoCf);
						return Vector2.zero;
					}
					return new Vector2(MathTools.Clamp(((AbuLYXhDofdMHjmwNPaBwEYJNRUkA)JcpwrGaoIHLqoZNdwXdGWaSfvilM[0]).YFxIVraKdXlHlZAlXSoEOkhepJMx + ((AbuLYXhDofdMHjmwNPaBwEYJNRUkA)JcpwrGaoIHLqoZNdwXdGWaSfvilM[2]).YFxIVraKdXlHlZAlXSoEOkhepJMx * -1f, -1f, 1f), MathTools.Clamp(((AbuLYXhDofdMHjmwNPaBwEYJNRUkA)JcpwrGaoIHLqoZNdwXdGWaSfvilM[3]).YFxIVraKdXlHlZAlXSoEOkhepJMx * -1f + ((AbuLYXhDofdMHjmwNPaBwEYJNRUkA)JcpwrGaoIHLqoZNdwXdGWaSfvilM[1]).YFxIVraKdXlHlZAlXSoEOkhepJMx, -1f, 1f));
				}
			}

			Vector2 IControllerTemplateDPad.valuePrev
			{
				get
				{
					if (ReInput._id != hIYycpNuKVkvtikiONVlQOlOKoCf)
					{
						ReInput.CheckInitialized(hIYycpNuKVkvtikiONVlQOlOKoCf);
						return Vector2.zero;
					}
					return new Vector2(MathTools.Clamp(((AbuLYXhDofdMHjmwNPaBwEYJNRUkA)JcpwrGaoIHLqoZNdwXdGWaSfvilM[0]).IItEwoimcLCNkHpdpTYxCbYZcKbGb + ((AbuLYXhDofdMHjmwNPaBwEYJNRUkA)JcpwrGaoIHLqoZNdwXdGWaSfvilM[2]).IItEwoimcLCNkHpdpTYxCbYZcKbGb * -1f, -1f, 1f), MathTools.Clamp(((AbuLYXhDofdMHjmwNPaBwEYJNRUkA)JcpwrGaoIHLqoZNdwXdGWaSfvilM[3]).IItEwoimcLCNkHpdpTYxCbYZcKbGb * -1f + ((AbuLYXhDofdMHjmwNPaBwEYJNRUkA)JcpwrGaoIHLqoZNdwXdGWaSfvilM[1]).IItEwoimcLCNkHpdpTYxCbYZcKbGb, -1f, 1f));
				}
			}

			IControllerTemplateButton IControllerTemplateDPad.up
			{
				get
				{
					if (ReInput._id != hIYycpNuKVkvtikiONVlQOlOKoCf)
					{
						ReInput.CheckInitialized(hIYycpNuKVkvtikiONVlQOlOKoCf);
						return null;
					}
					return (IControllerTemplateButton)JcpwrGaoIHLqoZNdwXdGWaSfvilM[0];
				}
			}

			IControllerTemplateButton IControllerTemplateDPad.right
			{
				get
				{
					if (ReInput._id != hIYycpNuKVkvtikiONVlQOlOKoCf)
					{
						ReInput.CheckInitialized(hIYycpNuKVkvtikiONVlQOlOKoCf);
						return null;
					}
					return (IControllerTemplateButton)JcpwrGaoIHLqoZNdwXdGWaSfvilM[1];
				}
			}

			IControllerTemplateButton IControllerTemplateDPad.down
			{
				get
				{
					if (ReInput._id != hIYycpNuKVkvtikiONVlQOlOKoCf)
					{
						ReInput.CheckInitialized(hIYycpNuKVkvtikiONVlQOlOKoCf);
						return null;
					}
					return (IControllerTemplateButton)JcpwrGaoIHLqoZNdwXdGWaSfvilM[2];
				}
			}

			IControllerTemplateButton IControllerTemplateDPad.left
			{
				get
				{
					if (ReInput._id != hIYycpNuKVkvtikiONVlQOlOKoCf)
					{
						ReInput.CheckInitialized(hIYycpNuKVkvtikiONVlQOlOKoCf);
						return null;
					}
					return (IControllerTemplateButton)JcpwrGaoIHLqoZNdwXdGWaSfvilM[3];
				}
			}

			IControllerTemplateButton IControllerTemplateDPad.press
			{
				get
				{
					if (ReInput._id != hIYycpNuKVkvtikiONVlQOlOKoCf)
					{
						ReInput.CheckInitialized(hIYycpNuKVkvtikiONVlQOlOKoCf);
						return null;
					}
					return (IControllerTemplateButton)JcpwrGaoIHLqoZNdwXdGWaSfvilM[4];
				}
			}

			private ZpXhLSqRATskOTKsBaFdngDouhnV(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, YYjpTGeypKuHJYOzvnyAyPmfPEfn[] P_4)
				: base(P_0, P_1, ControllerTemplateElementType.DPad, P_4, YYjpTGeypKuHJYOzvnyAyPmfPEfn.exOEPwnVAxgSUKBEuruZmkNQdAsYA(P_0, P_1, P_2, P_3))
			{
				if (P_4.Length != 5)
				{
					throw new ArgumentException("elements.Length must be " + 5);
				}
			}

			internal ZpXhLSqRATskOTKsBaFdngDouhnV(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, AbuLYXhDofdMHjmwNPaBwEYJNRUkA P_4, AbuLYXhDofdMHjmwNPaBwEYJNRUkA P_5, AbuLYXhDofdMHjmwNPaBwEYJNRUkA P_6, AbuLYXhDofdMHjmwNPaBwEYJNRUkA P_7, AbuLYXhDofdMHjmwNPaBwEYJNRUkA P_8)
				: this(P_0, P_1, P_2, P_3, new YYjpTGeypKuHJYOzvnyAyPmfPEfn[5] { P_4, P_5, P_6, P_7, P_8 })
			{
			}
		}

		internal sealed class KnfOkvlczPRfNxOtnvkXkECsONtb : wNKivkbIlmRMTVMgvDSrylsFkKGS, IControllerTemplateThrottle, IControllerTemplateElement
		{
			private const int iGerMrroqREjtmGgmRyXxcgoTFjp = 0;

			private const int scNdIJkGEKEdSdxwaaXsYoSSTYyob = 1;

			private const int mQXynccjpxZRAwoOQytGVkIdHPsHA = 2;

			float IControllerTemplateThrottle.value
			{
				get
				{
					if (ReInput._id != hIYycpNuKVkvtikiONVlQOlOKoCf)
					{
						ReInput.CheckInitialized(hIYycpNuKVkvtikiONVlQOlOKoCf);
						return 0f;
					}
					return ((AbuLYXhDofdMHjmwNPaBwEYJNRUkA)JcpwrGaoIHLqoZNdwXdGWaSfvilM[0]).YFxIVraKdXlHlZAlXSoEOkhepJMx;
				}
			}

			float IControllerTemplateThrottle.valuePrev
			{
				get
				{
					if (ReInput._id != hIYycpNuKVkvtikiONVlQOlOKoCf)
					{
						ReInput.CheckInitialized(hIYycpNuKVkvtikiONVlQOlOKoCf);
						return 0f;
					}
					return ((AbuLYXhDofdMHjmwNPaBwEYJNRUkA)JcpwrGaoIHLqoZNdwXdGWaSfvilM[0]).IItEwoimcLCNkHpdpTYxCbYZcKbGb;
				}
			}

			IControllerTemplateAxis IControllerTemplateThrottle.throttle
			{
				get
				{
					if (ReInput._id != hIYycpNuKVkvtikiONVlQOlOKoCf)
					{
						ReInput.CheckInitialized(hIYycpNuKVkvtikiONVlQOlOKoCf);
						return null;
					}
					return (IControllerTemplateAxis)JcpwrGaoIHLqoZNdwXdGWaSfvilM[0];
				}
			}

			IControllerTemplateButton IControllerTemplateThrottle.minDetent
			{
				get
				{
					if (ReInput._id != hIYycpNuKVkvtikiONVlQOlOKoCf)
					{
						ReInput.CheckInitialized(hIYycpNuKVkvtikiONVlQOlOKoCf);
						return null;
					}
					return (IControllerTemplateButton)JcpwrGaoIHLqoZNdwXdGWaSfvilM[1];
				}
			}

			private KnfOkvlczPRfNxOtnvkXkECsONtb(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, YYjpTGeypKuHJYOzvnyAyPmfPEfn[] P_4)
				: base(P_0, P_1, ControllerTemplateElementType.Throttle, P_4, YYjpTGeypKuHJYOzvnyAyPmfPEfn.exOEPwnVAxgSUKBEuruZmkNQdAsYA(P_0, P_1, P_2, P_3))
			{
				if (P_4.Length != 2)
				{
					throw new ArgumentException("elements.Length must be " + 2);
				}
			}

			internal KnfOkvlczPRfNxOtnvkXkECsONtb(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, AbuLYXhDofdMHjmwNPaBwEYJNRUkA P_4, AbuLYXhDofdMHjmwNPaBwEYJNRUkA P_5)
				: this(P_0, P_1, P_2, P_3, new YYjpTGeypKuHJYOzvnyAyPmfPEfn[2] { P_4, P_5 })
			{
			}
		}

		internal sealed class voVUXmEisrbEaWnsoIIHCkGxFszdA : wNKivkbIlmRMTVMgvDSrylsFkKGS, IControllerTemplateHat, IControllerTemplateElement
		{
			private const int bWsVNmhKBZzAkfmdpDLjbdbUtuJz = 0;

			private const int TDTBhpgWxqCOlCLpSiECxicuYRbKA = 1;

			private const int XeRzBtyLRGOATXUNLDgQswbesdqu = 2;

			private const int MZlDmBCBfyeTwfLxMWjXTURNXEby = 3;

			private const int gawpnuZdWxVgJfWzsrLQuQosCmDW = 4;

			private const int YpbeaUftLGEhTBrXdCwFNlMoFLprB = 5;

			private const int KRSWzbWaPSveKynBsubvqVDqFwsT = 6;

			private const int bYilYDcqdMvXjlBarCLLEAqpkJSzA = 7;

			private const int QpksGsTDQCcwNnGHAeIaGLekMpjV = 8;

			Vector2 IControllerTemplateHat.value
			{
				get
				{
					if (ReInput._id != hIYycpNuKVkvtikiONVlQOlOKoCf)
					{
						ReInput.CheckInitialized(hIYycpNuKVkvtikiONVlQOlOKoCf);
						return Vector2.zero;
					}
					Vector2 result = default(Vector2);
					result.y += ((AbuLYXhDofdMHjmwNPaBwEYJNRUkA)JcpwrGaoIHLqoZNdwXdGWaSfvilM[0]).YFxIVraKdXlHlZAlXSoEOkhepJMx;
					result.x += ((AbuLYXhDofdMHjmwNPaBwEYJNRUkA)JcpwrGaoIHLqoZNdwXdGWaSfvilM[2]).YFxIVraKdXlHlZAlXSoEOkhepJMx;
					result.y -= ((AbuLYXhDofdMHjmwNPaBwEYJNRUkA)JcpwrGaoIHLqoZNdwXdGWaSfvilM[4]).YFxIVraKdXlHlZAlXSoEOkhepJMx;
					result.x -= ((AbuLYXhDofdMHjmwNPaBwEYJNRUkA)JcpwrGaoIHLqoZNdwXdGWaSfvilM[6]).YFxIVraKdXlHlZAlXSoEOkhepJMx;
					float num = ((AbuLYXhDofdMHjmwNPaBwEYJNRUkA)JcpwrGaoIHLqoZNdwXdGWaSfvilM[1]).YFxIVraKdXlHlZAlXSoEOkhepJMx;
					float num2 = ((AbuLYXhDofdMHjmwNPaBwEYJNRUkA)JcpwrGaoIHLqoZNdwXdGWaSfvilM[3]).YFxIVraKdXlHlZAlXSoEOkhepJMx;
					float num3 = ((AbuLYXhDofdMHjmwNPaBwEYJNRUkA)JcpwrGaoIHLqoZNdwXdGWaSfvilM[5]).YFxIVraKdXlHlZAlXSoEOkhepJMx;
					float num4 = ((AbuLYXhDofdMHjmwNPaBwEYJNRUkA)JcpwrGaoIHLqoZNdwXdGWaSfvilM[7]).YFxIVraKdXlHlZAlXSoEOkhepJMx;
					result.x += num + num2 - num3 - num4;
					result.y += num + num4 - num2 - num3;
					result.x = MathTools.Clamp(result.x, -1f, 1f);
					result.y = MathTools.Clamp(result.y, -1f, 1f);
					return result;
				}
			}

			Vector2 IControllerTemplateHat.valuePrev
			{
				get
				{
					if (ReInput._id != hIYycpNuKVkvtikiONVlQOlOKoCf)
					{
						ReInput.CheckInitialized(hIYycpNuKVkvtikiONVlQOlOKoCf);
						return Vector2.zero;
					}
					Vector2 result = default(Vector2);
					result.y += ((AbuLYXhDofdMHjmwNPaBwEYJNRUkA)JcpwrGaoIHLqoZNdwXdGWaSfvilM[0]).IItEwoimcLCNkHpdpTYxCbYZcKbGb;
					result.x += ((AbuLYXhDofdMHjmwNPaBwEYJNRUkA)JcpwrGaoIHLqoZNdwXdGWaSfvilM[2]).IItEwoimcLCNkHpdpTYxCbYZcKbGb;
					result.y -= ((AbuLYXhDofdMHjmwNPaBwEYJNRUkA)JcpwrGaoIHLqoZNdwXdGWaSfvilM[4]).IItEwoimcLCNkHpdpTYxCbYZcKbGb;
					result.x -= ((AbuLYXhDofdMHjmwNPaBwEYJNRUkA)JcpwrGaoIHLqoZNdwXdGWaSfvilM[6]).IItEwoimcLCNkHpdpTYxCbYZcKbGb;
					float num = ((AbuLYXhDofdMHjmwNPaBwEYJNRUkA)JcpwrGaoIHLqoZNdwXdGWaSfvilM[1]).IItEwoimcLCNkHpdpTYxCbYZcKbGb;
					float num2 = ((AbuLYXhDofdMHjmwNPaBwEYJNRUkA)JcpwrGaoIHLqoZNdwXdGWaSfvilM[3]).IItEwoimcLCNkHpdpTYxCbYZcKbGb;
					float num3 = ((AbuLYXhDofdMHjmwNPaBwEYJNRUkA)JcpwrGaoIHLqoZNdwXdGWaSfvilM[5]).IItEwoimcLCNkHpdpTYxCbYZcKbGb;
					float num4 = ((AbuLYXhDofdMHjmwNPaBwEYJNRUkA)JcpwrGaoIHLqoZNdwXdGWaSfvilM[7]).IItEwoimcLCNkHpdpTYxCbYZcKbGb;
					result.x += num + num2 - num3 - num4;
					result.y += num + num4 - num2 - num3;
					result.x = MathTools.Clamp(result.x, -1f, 1f);
					result.y = MathTools.Clamp(result.y, -1f, 1f);
					return result;
				}
			}

			IControllerTemplateButton IControllerTemplateHat.up
			{
				get
				{
					if (ReInput._id != hIYycpNuKVkvtikiONVlQOlOKoCf)
					{
						ReInput.CheckInitialized(hIYycpNuKVkvtikiONVlQOlOKoCf);
						return null;
					}
					return (IControllerTemplateButton)JcpwrGaoIHLqoZNdwXdGWaSfvilM[0];
				}
			}

			IControllerTemplateButton IControllerTemplateHat.upRight
			{
				get
				{
					if (ReInput._id != hIYycpNuKVkvtikiONVlQOlOKoCf)
					{
						ReInput.CheckInitialized(hIYycpNuKVkvtikiONVlQOlOKoCf);
						return null;
					}
					return (IControllerTemplateButton)JcpwrGaoIHLqoZNdwXdGWaSfvilM[1];
				}
			}

			IControllerTemplateButton IControllerTemplateHat.right
			{
				get
				{
					if (ReInput._id != hIYycpNuKVkvtikiONVlQOlOKoCf)
					{
						ReInput.CheckInitialized(hIYycpNuKVkvtikiONVlQOlOKoCf);
						return null;
					}
					return (IControllerTemplateButton)JcpwrGaoIHLqoZNdwXdGWaSfvilM[2];
				}
			}

			IControllerTemplateButton IControllerTemplateHat.downRight
			{
				get
				{
					if (ReInput._id != hIYycpNuKVkvtikiONVlQOlOKoCf)
					{
						ReInput.CheckInitialized(hIYycpNuKVkvtikiONVlQOlOKoCf);
						return null;
					}
					return (IControllerTemplateButton)JcpwrGaoIHLqoZNdwXdGWaSfvilM[3];
				}
			}

			IControllerTemplateButton IControllerTemplateHat.down
			{
				get
				{
					if (ReInput._id != hIYycpNuKVkvtikiONVlQOlOKoCf)
					{
						ReInput.CheckInitialized(hIYycpNuKVkvtikiONVlQOlOKoCf);
						return null;
					}
					return (IControllerTemplateButton)JcpwrGaoIHLqoZNdwXdGWaSfvilM[4];
				}
			}

			IControllerTemplateButton IControllerTemplateHat.downLeft
			{
				get
				{
					if (ReInput._id != hIYycpNuKVkvtikiONVlQOlOKoCf)
					{
						ReInput.CheckInitialized(hIYycpNuKVkvtikiONVlQOlOKoCf);
						return null;
					}
					return (IControllerTemplateButton)JcpwrGaoIHLqoZNdwXdGWaSfvilM[5];
				}
			}

			IControllerTemplateButton IControllerTemplateHat.left
			{
				get
				{
					if (ReInput._id != hIYycpNuKVkvtikiONVlQOlOKoCf)
					{
						ReInput.CheckInitialized(hIYycpNuKVkvtikiONVlQOlOKoCf);
						return null;
					}
					return (IControllerTemplateButton)JcpwrGaoIHLqoZNdwXdGWaSfvilM[6];
				}
			}

			IControllerTemplateButton IControllerTemplateHat.upLeft
			{
				get
				{
					if (ReInput._id != hIYycpNuKVkvtikiONVlQOlOKoCf)
					{
						ReInput.CheckInitialized(hIYycpNuKVkvtikiONVlQOlOKoCf);
						return null;
					}
					return (IControllerTemplateButton)JcpwrGaoIHLqoZNdwXdGWaSfvilM[7];
				}
			}

			private voVUXmEisrbEaWnsoIIHCkGxFszdA(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, YYjpTGeypKuHJYOzvnyAyPmfPEfn[] P_4)
				: base(P_0, P_1, ControllerTemplateElementType.Hat, P_4, YYjpTGeypKuHJYOzvnyAyPmfPEfn.exOEPwnVAxgSUKBEuruZmkNQdAsYA(P_0, P_1, P_2, P_3))
			{
				if (P_4.Length != 8)
				{
					throw new ArgumentException("elements.Length must be " + 8);
				}
			}

			internal voVUXmEisrbEaWnsoIIHCkGxFszdA(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, AbuLYXhDofdMHjmwNPaBwEYJNRUkA P_4, AbuLYXhDofdMHjmwNPaBwEYJNRUkA P_5, AbuLYXhDofdMHjmwNPaBwEYJNRUkA P_6, AbuLYXhDofdMHjmwNPaBwEYJNRUkA P_7, AbuLYXhDofdMHjmwNPaBwEYJNRUkA P_8, AbuLYXhDofdMHjmwNPaBwEYJNRUkA P_9, AbuLYXhDofdMHjmwNPaBwEYJNRUkA P_10, AbuLYXhDofdMHjmwNPaBwEYJNRUkA P_11)
				: this(P_0, P_1, P_2, P_3, new YYjpTGeypKuHJYOzvnyAyPmfPEfn[8] { P_4, P_5, P_6, P_7, P_8, P_9, P_10, P_11 })
			{
			}
		}

		internal sealed class fEGFNXFAXiGFbCeeARfFRqRRviEFB : OWhgNEkCVNxNyvxERsCrYKgigVwW, IControllerTemplateYoke, IControllerTemplateElement
		{
			private const int mATnqsKebKcySgSAmhJScojfTxIbb = 2;

			IControllerTemplateAxis IControllerTemplateYoke.rotation
			{
				get
				{
					if (ReInput._id != hIYycpNuKVkvtikiONVlQOlOKoCf)
					{
						ReInput.CheckInitialized(hIYycpNuKVkvtikiONVlQOlOKoCf);
						return null;
					}
					return (IControllerTemplateAxis)JcpwrGaoIHLqoZNdwXdGWaSfvilM[0];
				}
			}

			IControllerTemplateAxis IControllerTemplateYoke.pushPull
			{
				get
				{
					if (ReInput._id != hIYycpNuKVkvtikiONVlQOlOKoCf)
					{
						ReInput.CheckInitialized(hIYycpNuKVkvtikiONVlQOlOKoCf);
						return null;
					}
					return (IControllerTemplateAxis)JcpwrGaoIHLqoZNdwXdGWaSfvilM[1];
				}
			}

			private fEGFNXFAXiGFbCeeARfFRqRRviEFB(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, YYjpTGeypKuHJYOzvnyAyPmfPEfn[] P_4)
				: base(P_0, P_1, ControllerTemplateElementType.Yoke, P_4, YYjpTGeypKuHJYOzvnyAyPmfPEfn.exOEPwnVAxgSUKBEuruZmkNQdAsYA(P_0, P_1, P_2, P_3))
			{
			}

			internal fEGFNXFAXiGFbCeeARfFRqRRviEFB(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, AbuLYXhDofdMHjmwNPaBwEYJNRUkA P_4, AbuLYXhDofdMHjmwNPaBwEYJNRUkA P_5)
				: this(P_0, P_1, P_2, P_3, new YYjpTGeypKuHJYOzvnyAyPmfPEfn[2] { P_4, P_5 })
			{
			}
		}

		internal sealed class FIVvIWuLGHuDfjmPDeGCalxLDFZh : uHPsBjnKfTjCTALFwWotfAPBIlLpA, IControllerTemplateStick6D, IControllerTemplateElement
		{
			private const int ACpgSWnGERuCYseLjidTfPzLqxhL = 6;

			private FIVvIWuLGHuDfjmPDeGCalxLDFZh(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, YYjpTGeypKuHJYOzvnyAyPmfPEfn[] P_4)
				: base(P_0, P_1, ControllerTemplateElementType.Stick6D, P_4, YYjpTGeypKuHJYOzvnyAyPmfPEfn.exOEPwnVAxgSUKBEuruZmkNQdAsYA(P_0, P_1, P_2, P_3))
			{
			}

			internal FIVvIWuLGHuDfjmPDeGCalxLDFZh(IControllerTemplate_Internal P_0, int P_1, string P_2, string P_3, AbuLYXhDofdMHjmwNPaBwEYJNRUkA P_4, AbuLYXhDofdMHjmwNPaBwEYJNRUkA P_5, AbuLYXhDofdMHjmwNPaBwEYJNRUkA P_6, AbuLYXhDofdMHjmwNPaBwEYJNRUkA P_7, AbuLYXhDofdMHjmwNPaBwEYJNRUkA P_8, AbuLYXhDofdMHjmwNPaBwEYJNRUkA P_9)
				: this(P_0, P_1, P_2, P_3, new YYjpTGeypKuHJYOzvnyAyPmfPEfn[6] { P_4, P_5, P_6, P_7, P_8, P_9 })
			{
			}
		}

		internal class hutPhcBnEQdPRoJEXCJgCtixxCeM
		{
			public readonly Controller.Element qvamzwhoWxtDxCBmROcRJoqSsdpc;

			public readonly IControllerElementTarget hERAAbAwSLlkzwNuDGeKwOhDkNebb;

			public bool tWWBIKWnxksDofQfZDGTIQDaEXjCb
			{
				get
				{
					if (qvamzwhoWxtDxCBmROcRJoqSsdpc == null)
					{
						return false;
					}
					switch (qvamzwhoWxtDxCBmROcRJoqSsdpc.type)
					{
					case ControllerElementType.Button:
						return (qvamzwhoWxtDxCBmROcRJoqSsdpc as Controller.Button).value;
					case ControllerElementType.Axis:
					{
						float value = (qvamzwhoWxtDxCBmROcRJoqSsdpc as Controller.Axis).value;
						switch (hERAAbAwSLlkzwNuDGeKwOhDkNebb.axisRange)
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

			public bool nthTXFeOzKIoOMYVpOYjIEWKUOtP
			{
				get
				{
					if (qvamzwhoWxtDxCBmROcRJoqSsdpc == null)
					{
						return false;
					}
					switch (qvamzwhoWxtDxCBmROcRJoqSsdpc.type)
					{
					case ControllerElementType.Button:
						return (qvamzwhoWxtDxCBmROcRJoqSsdpc as Controller.Button).valuePrev;
					case ControllerElementType.Axis:
					{
						float valuePrev = (qvamzwhoWxtDxCBmROcRJoqSsdpc as Controller.Axis).valuePrev;
						switch (hERAAbAwSLlkzwNuDGeKwOhDkNebb.axisRange)
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

			public bool IQKyhEaErJtbbCCBYSrGzpWvnNfF
			{
				get
				{
					if (qvamzwhoWxtDxCBmROcRJoqSsdpc == null)
					{
						return false;
					}
					switch (qvamzwhoWxtDxCBmROcRJoqSsdpc.type)
					{
					case ControllerElementType.Button:
						return (qvamzwhoWxtDxCBmROcRJoqSsdpc as Controller.Button).justPressed;
					case ControllerElementType.Axis:
						if (MathTools.Abs(tCcIrTkDIrtEqIhdHwhlUEYwljHAb) > 0.01f && MathTools.Abs(FfsbKslVKHQpWWvuQfRgEYvtxRrg) <= 0.01f)
						{
							return true;
						}
						break;
					}
					return false;
				}
			}

			public bool dFNtsWKDbuZolWNvThlfOoDpOdUx
			{
				get
				{
					if (qvamzwhoWxtDxCBmROcRJoqSsdpc == null)
					{
						return false;
					}
					switch (qvamzwhoWxtDxCBmROcRJoqSsdpc.type)
					{
					case ControllerElementType.Button:
						return (qvamzwhoWxtDxCBmROcRJoqSsdpc as Controller.Button).justReleased;
					case ControllerElementType.Axis:
						if (MathTools.Abs(tCcIrTkDIrtEqIhdHwhlUEYwljHAb) <= 0.01f && MathTools.Abs(FfsbKslVKHQpWWvuQfRgEYvtxRrg) > 0.01f)
						{
							return true;
						}
						break;
					}
					return false;
				}
			}

			public float tCcIrTkDIrtEqIhdHwhlUEYwljHAb
			{
				get
				{
					if (qvamzwhoWxtDxCBmROcRJoqSsdpc == null)
					{
						return 0f;
					}
					switch (qvamzwhoWxtDxCBmROcRJoqSsdpc.type)
					{
					case ControllerElementType.Button:
						if (!(qvamzwhoWxtDxCBmROcRJoqSsdpc as Controller.Button).value)
						{
							return 0f;
						}
						return 1f;
					case ControllerElementType.Axis:
					{
						float value = (qvamzwhoWxtDxCBmROcRJoqSsdpc as Controller.Axis).value;
						switch (hERAAbAwSLlkzwNuDGeKwOhDkNebb.axisRange)
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

			public float FfsbKslVKHQpWWvuQfRgEYvtxRrg
			{
				get
				{
					if (qvamzwhoWxtDxCBmROcRJoqSsdpc == null)
					{
						return 0f;
					}
					switch (qvamzwhoWxtDxCBmROcRJoqSsdpc.type)
					{
					case ControllerElementType.Button:
						if (!(qvamzwhoWxtDxCBmROcRJoqSsdpc as Controller.Button).valuePrev)
						{
							return 0f;
						}
						return 1f;
					case ControllerElementType.Axis:
					{
						float valuePrev = (qvamzwhoWxtDxCBmROcRJoqSsdpc as Controller.Axis).valuePrev;
						switch (hERAAbAwSLlkzwNuDGeKwOhDkNebb.axisRange)
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

			public hutPhcBnEQdPRoJEXCJgCtixxCeM(IControllerElementTarget P_0, Controller.Element P_1)
			{
				qvamzwhoWxtDxCBmROcRJoqSsdpc = P_1;
				hERAAbAwSLlkzwNuDGeKwOhDkNebb = P_0;
			}

			public static hutPhcBnEQdPRoJEXCJgCtixxCeM QmKEQTghVEFKPhcUiKOuSqSYZBvuA()
			{
				return new hutPhcBnEQdPRoJEXCJgCtixxCeM(JrHSDKJJRmfQuafjRnKcPPKpIBhpA.HgjmLTdDFHYuwPSDLFOPmOvQPEnb(), null);
			}
		}

		internal class BkhfCqorSBgitkHzZknmENKJVMyO
		{
			public readonly Controller RbVpLWZwRaQJcKqzqNdBQcUszuSR;

			public readonly IHardwareControllerTemplateMap_Internal iOcFxMKRTzzQhmvuuuNEXBDDbUON;

			public BkhfCqorSBgitkHzZknmENKJVMyO(Controller P_0, IHardwareControllerTemplateMap_Internal P_1)
			{
				if (P_0 == null)
				{
					throw new ArgumentNullException("controller");
				}
				if (P_1 == null)
				{
					throw new ArgumentNullException("templateMap");
				}
				RbVpLWZwRaQJcKqzqNdBQcUszuSR = P_0;
				iOcFxMKRTzzQhmvuuuNEXBDDbUON = P_1;
			}
		}

		private sealed class ovuqbdJtztpjNNJlEglfEcWUcsC
		{
			[Serializable]
			private sealed class uORBWTDZluVJcZFPCsyJOkpBdzYU
			{
				public static readonly uORBWTDZluVJcZFPCsyJOkpBdzYU _003C_003E9 = new uORBWTDZluVJcZFPCsyJOkpBdzYU();

				public static Func<OoMOZEqfXndBIZKQcgmHDZDrhUwEA, OoMOZEqfXndBIZKQcgmHDZDrhUwEA, bool> _003C_003E9__4_0;

				internal bool SqUIRkvIkIxjawMsCUbtrmpRerpv(OoMOZEqfXndBIZKQcgmHDZDrhUwEA P_0, OoMOZEqfXndBIZKQcgmHDZDrhUwEA P_1)
				{
					if (P_0 == null || P_1 == null)
					{
						return false;
					}
					return P_0.ONNbteXxuydDDSwvcgYKyVMQOdPh(P_1, false);
				}
			}

			private static ovuqbdJtztpjNNJlEglfEcWUcsC sEAIFPgUtMxEYhQUfzWSHRqJDUmK;

			private readonly global::CWEsnVafmhdWXWfXjHVMLtdvyjyd<OoMOZEqfXndBIZKQcgmHDZDrhUwEA> vAvTHoWTGNNbChNZFZwvAMNKDObk;

			private static ovuqbdJtztpjNNJlEglfEcWUcsC yKShfRLGMoeNRNWbIhabjTGgDtfYA
			{
				get
				{
					if (sEAIFPgUtMxEYhQUfzWSHRqJDUmK != null)
					{
						return sEAIFPgUtMxEYhQUfzWSHRqJDUmK;
					}
					sEAIFPgUtMxEYhQUfzWSHRqJDUmK = new ovuqbdJtztpjNNJlEglfEcWUcsC();
					sEAIFPgUtMxEYhQUfzWSHRqJDUmK.ZDutBEcLTRhcJNEPOBzgbhHFaHHu();
					return sEAIFPgUtMxEYhQUfzWSHRqJDUmK;
				}
			}

			private ovuqbdJtztpjNNJlEglfEcWUcsC()
			{
				vAvTHoWTGNNbChNZFZwvAMNKDObk = new global::CWEsnVafmhdWXWfXjHVMLtdvyjyd<OoMOZEqfXndBIZKQcgmHDZDrhUwEA>(uORBWTDZluVJcZFPCsyJOkpBdzYU._003C_003E9.SqUIRkvIkIxjawMsCUbtrmpRerpv);
			}

			private void ZDutBEcLTRhcJNEPOBzgbhHFaHHu()
			{
				ReInput.ShutDownEvent += sEAIFPgUtMxEYhQUfzWSHRqJDUmK.kybubairgZIunMxUchhtCoUVvvtuA;
			}

			private void kybubairgZIunMxUchhtCoUVvvtuA()
			{
				if (sEAIFPgUtMxEYhQUfzWSHRqJDUmK == this)
				{
					sEAIFPgUtMxEYhQUfzWSHRqJDUmK = null;
				}
				ReInput.ShutDownEvent -= kybubairgZIunMxUchhtCoUVvvtuA;
			}

			public static OoMOZEqfXndBIZKQcgmHDZDrhUwEA OBPUvPZMoEiEURFsAXgmYYvnPZDt(OoMOZEqfXndBIZKQcgmHDZDrhUwEA P_0)
			{
				Bytes20 bytes = ((P_0.JLFYlpbldhaAwtjOCdSYZmwoESgjA is dwlFsOGQiNjyUmmpGChGeYMHRJMh dwlFsOGQiNjyUmmpGChGeYMHRJMh2) ? dwlFsOGQiNjyUmmpGChGeYMHRJMh2.OugWsWZGTthCBvUMgYijtHxjXjOC.hash : default(Bytes20));
				return yKShfRLGMoeNRNWbIhabjTGgDtfYA.vAvTHoWTGNNbChNZFZwvAMNKDObk.zIxKqErNejIXOzgHuQwaUJUUfHkH(bytes, P_0);
			}

			public static bool SIFxLOzNekFaeINNwvOjMBTiAduD(OoMOZEqfXndBIZKQcgmHDZDrhUwEA P_0, out OoMOZEqfXndBIZKQcgmHDZDrhUwEA P_1)
			{
				Bytes20 bytes = ((P_0.JLFYlpbldhaAwtjOCdSYZmwoESgjA is dwlFsOGQiNjyUmmpGChGeYMHRJMh dwlFsOGQiNjyUmmpGChGeYMHRJMh2) ? dwlFsOGQiNjyUmmpGChGeYMHRJMh2.OugWsWZGTthCBvUMgYijtHxjXjOC.hash : default(Bytes20));
				return yKShfRLGMoeNRNWbIhabjTGgDtfYA.vAvTHoWTGNNbChNZFZwvAMNKDObk.XFaGTtCzTwdlJVAzMnkTTCEPSjPB(bytes, P_0, out P_1);
			}

			public static void eyJlrKOYbRfenEFGQBGjDyreaaFoA(OoMOZEqfXndBIZKQcgmHDZDrhUwEA P_0)
			{
				Bytes20 bytes = ((P_0.JLFYlpbldhaAwtjOCdSYZmwoESgjA is dwlFsOGQiNjyUmmpGChGeYMHRJMh dwlFsOGQiNjyUmmpGChGeYMHRJMh2) ? dwlFsOGQiNjyUmmpGChGeYMHRJMh2.OugWsWZGTthCBvUMgYijtHxjXjOC.hash : default(Bytes20));
				yKShfRLGMoeNRNWbIhabjTGgDtfYA.vAvTHoWTGNNbChNZFZwvAMNKDObk.gjcCongZfDTPVoqTsiJgeVhLREbdb(bytes, P_0);
			}
		}

		private const string pKhNHsBrPEuTGkoURdHsNDcvyVcP = "controller/template";

		private string LdbzREMxGWdWuUmWlZxMUjsafXrE;

		private string BnUkwagPHIbGpuwqZmQySadKMPYK;

		private int ueaYLYYcddJVtaIFpfYBwJSZNGZP;

		private readonly Guid vzWLkqlUqFueQAdIxcieKDcaZqdiA;

		private readonly DeviceLocalizationInfo qwxPWQjoyVFTcNqlHvneUUpRFSiU;

		private readonly Controller bZAKwebGxGaRHhghQDaBNzKkIbEe;

		private readonly ADictionary<int, IControllerTemplateElement> TJzEJIeBVLSRtDSFMHNFmRtGTBKS;

		private readonly ADictionary<string, IControllerTemplateElement> acAAgIfkBzZaehkbDWDkUqaXDalo;

		private IControllerTemplateElement[] rbKnwFUuPijnSUlTJRLndGRZhENB;

		private ReadOnlyCollection<IControllerTemplateElement> HIYHBWpOgZNgrvdojAgGZzHJgZJS;

		private readonly zepspERRxafWKJaGpLXDAMQMfvgE HiooMURUXusXWrCAbtDGtszwpOpK;

		private readonly int UgWhYoisePaOdKLfjQrWSGozPQst;

		internal DeviceLocalizationInfo IGrBRytIswzcwcZGkfDKptkiOAXb => qwxPWQjoyVFTcNqlHvneUUpRFSiU;

		DeviceLocalizationInfo IControllerTemplate_Internal.deviceLocalizationInfo => qwxPWQjoyVFTcNqlHvneUUpRFSiU;

		Controller IControllerTemplate.controller
		{
			get
			{
				if (ReInput._id != UgWhYoisePaOdKLfjQrWSGozPQst)
				{
					ReInput.CheckInitialized(UgWhYoisePaOdKLfjQrWSGozPQst);
					return null;
				}
				return bZAKwebGxGaRHhghQDaBNzKkIbEe;
			}
		}

		string IControllerTemplate.name
		{
			get
			{
				if (ReInput._id != UgWhYoisePaOdKLfjQrWSGozPQst)
				{
					ReInput.CheckInitialized(UgWhYoisePaOdKLfjQrWSGozPQst);
					return null;
				}
				if (!LocalizationManager.isEnabled)
				{
					return LdbzREMxGWdWuUmWlZxMUjsafXrE;
				}
				return HiooMURUXusXWrCAbtDGtszwpOpK.LoGZqdROKyuYHJXdnhuxPciDQjeL;
			}
		}

		Guid IControllerTemplate.typeGuid
		{
			get
			{
				if (ReInput._id != UgWhYoisePaOdKLfjQrWSGozPQst)
				{
					ReInput.CheckInitialized(UgWhYoisePaOdKLfjQrWSGozPQst);
					return Guid.Empty;
				}
				return vzWLkqlUqFueQAdIxcieKDcaZqdiA;
			}
		}

		IList<IControllerTemplateElement> IControllerTemplate.elements
		{
			get
			{
				if (ReInput._id != UgWhYoisePaOdKLfjQrWSGozPQst)
				{
					ReInput.CheckInitialized(UgWhYoisePaOdKLfjQrWSGozPQst);
					return null;
				}
				return HIYHBWpOgZNgrvdojAgGZzHJgZJS;
			}
		}

		int IControllerTemplate.elementCount
		{
			get
			{
				if (ReInput._id != UgWhYoisePaOdKLfjQrWSGozPQst)
				{
					ReInput.CheckInitialized(UgWhYoisePaOdKLfjQrWSGozPQst);
					return 0;
				}
				return rbKnwFUuPijnSUlTJRLndGRZhENB.Length;
			}
		}

		string gDrCmzJNXwFvGTMAYKGQspUqeYD.keyCategory => "controller/template";

		string gDrCmzJNXwFvGTMAYKGQspUqeYD.scriptingName => string.Empty;

		string gDrCmzJNXwFvGTMAYKGQspUqeYD.nonLocalizedDescriptiveName
		{
			get
			{
				return LdbzREMxGWdWuUmWlZxMUjsafXrE;
			}
			set
			{
				LdbzREMxGWdWuUmWlZxMUjsafXrE = value;
			}
		}

		string gDrCmzJNXwFvGTMAYKGQspUqeYD.key => BnUkwagPHIbGpuwqZmQySadKMPYK;

		int gDrCmzJNXwFvGTMAYKGQspUqeYD.autoGeneratedValueFlags
		{
			get
			{
				return ueaYLYYcddJVtaIFpfYBwJSZNGZP;
			}
			set
			{
				ueaYLYYcddJVtaIFpfYBwJSZNGZP = value;
			}
		}

		protected ControllerTemplate(object P_0)
			: this((BkhfCqorSBgitkHzZknmENKJVMyO)P_0)
		{
		}

		private ControllerTemplate(BkhfCqorSBgitkHzZknmENKJVMyO P_0)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("initializer");
			}
			if (P_0.RbVpLWZwRaQJcKqzqNdBQcUszuSR == null)
			{
				throw new ArgumentNullException("initializer.controller");
			}
			if (P_0.iOcFxMKRTzzQhmvuuuNEXBDDbUON == null)
			{
				throw new ArgumentNullException("initializer.templateMap");
			}
			UgWhYoisePaOdKLfjQrWSGozPQst = ReInput.id;
			bZAKwebGxGaRHhghQDaBNzKkIbEe = P_0.RbVpLWZwRaQJcKqzqNdBQcUszuSR;
			IHardwareControllerTemplateMap_Internal iOcFxMKRTzzQhmvuuuNEXBDDbUON = P_0.iOcFxMKRTzzQhmvuuuNEXBDDbUON;
			LdbzREMxGWdWuUmWlZxMUjsafXrE = iOcFxMKRTzzQhmvuuuNEXBDDbUON.name;
			BnUkwagPHIbGpuwqZmQySadKMPYK = iOcFxMKRTzzQhmvuuuNEXBDDbUON.typeKey;
			vzWLkqlUqFueQAdIxcieKDcaZqdiA = iOcFxMKRTzzQhmvuuuNEXBDDbUON.typeGuid;
			qwxPWQjoyVFTcNqlHvneUUpRFSiU = new DeviceLocalizationInfo(bZAKwebGxGaRHhghQDaBNzKkIbEe.type, true, vzWLkqlUqFueQAdIxcieKDcaZqdiA, new List<string> { iOcFxMKRTzzQhmvuuuNEXBDDbUON.typeKey }, null);
			qwxPWQjoyVFTcNqlHvneUUpRFSiU.FinishRuntimeSetup();
			HiooMURUXusXWrCAbtDGtszwpOpK = zepspERRxafWKJaGpLXDAMQMfvgE.HKzbZMduZchtOBhLaihmPtNUHVVO(this);
			int elementIdentifierCount = iOcFxMKRTzzQhmvuuuNEXBDDbUON.GetElementIdentifierCount();
			ADictionary<int, IControllerTemplateElement> aDictionary = new ADictionary<int, IControllerTemplateElement>();
			List<IControllerTemplateElement> list = new List<IControllerTemplateElement>();
			List<IControllerTemplateAxis> list2 = new List<IControllerTemplateAxis>();
			List<IControllerTemplateButton> list3 = new List<IControllerTemplateButton>();
			List<IControllerTemplateElement> list4 = new List<IControllerTemplateElement>();
			for (int i = 0; i < elementIdentifierCount; i++)
			{
				IControllerTemplateElementIdentifier templateElementIdentifier = iOcFxMKRTzzQhmvuuuNEXBDDbUON.GetTemplateElementIdentifier(i);
				if (templateElementIdentifier != null && InputTools.IsMappableType(templateElementIdentifier.elementType))
				{
					switch (templateElementIdentifier.elementType)
					{
					case ControllerTemplateElementType.Axis:
					{
						eyXePMBLHAVdDBzdXMjLzHNfDAjcA eyXePMBLHAVdDBzdXMjLzHNfDAjcA3 = iOcFxMKRTzzQhmvuuuNEXBDDbUON.GetAxisTarget(bZAKwebGxGaRHhghQDaBNzKkIbEe, templateElementIdentifier.id) ?? eyXePMBLHAVdDBzdXMjLzHNfDAjcA.fycPWQxAWErCODAuTpxKKuGkZEgl(ControllerTemplateElementType.Axis);
						vyUuyGVoBSHRAeomrSKtoxAdqJC item2 = new vyUuyGVoBSHRAeomrSKtoxAdqJC(this, templateElementIdentifier.id, templateElementIdentifier.nonLocalizedName, (!templateElementIdentifier.isNonLocalizedPositiveNameAutoGenerated) ? templateElementIdentifier.nonLocalizedPositiveName : string.Empty, (!templateElementIdentifier.isNonLocalizedNegativeNameAutoGenerated) ? templateElementIdentifier.nonLocalizedNegativeName : string.Empty, templateElementIdentifier.key, (!templateElementIdentifier.isPositiveKeyAutoGenerated) ? templateElementIdentifier.positiveKey : string.Empty, (!templateElementIdentifier.isNegativeKeyAutoGenerated) ? templateElementIdentifier.negativeKey : string.Empty, eyXePMBLHAVdDBzdXMjLzHNfDAjcA3, ZHtyJRqXejMduXZcwblElSRqsAPl(bZAKwebGxGaRHhghQDaBNzKkIbEe, eyXePMBLHAVdDBzdXMjLzHNfDAjcA3));
						list2.Add(item2);
						break;
					}
					case ControllerTemplateElementType.Button:
					{
						eyXePMBLHAVdDBzdXMjLzHNfDAjcA eyXePMBLHAVdDBzdXMjLzHNfDAjcA2 = iOcFxMKRTzzQhmvuuuNEXBDDbUON.GetButtonTarget(bZAKwebGxGaRHhghQDaBNzKkIbEe, templateElementIdentifier.id) ?? eyXePMBLHAVdDBzdXMjLzHNfDAjcA.fycPWQxAWErCODAuTpxKKuGkZEgl(ControllerTemplateElementType.Button);
						WSWBqdXhsJebMVCilWvuKFuXCKMAA item = new WSWBqdXhsJebMVCilWvuKFuXCKMAA(this, templateElementIdentifier.id, templateElementIdentifier.nonLocalizedName, (!templateElementIdentifier.isNonLocalizedPositiveNameAutoGenerated) ? templateElementIdentifier.nonLocalizedPositiveName : string.Empty, (!templateElementIdentifier.isNonLocalizedNegativeNameAutoGenerated) ? templateElementIdentifier.nonLocalizedNegativeName : string.Empty, templateElementIdentifier.key, (!templateElementIdentifier.isPositiveKeyAutoGenerated) ? templateElementIdentifier.positiveKey : string.Empty, (!templateElementIdentifier.isNegativeKeyAutoGenerated) ? templateElementIdentifier.negativeKey : string.Empty, eyXePMBLHAVdDBzdXMjLzHNfDAjcA2, UvrfogArdwitUXSxZOfZgydHEXhA(bZAKwebGxGaRHhghQDaBNzKkIbEe, eyXePMBLHAVdDBzdXMjLzHNfDAjcA2));
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
				IControllerTemplateElementIdentifier templateElementIdentifier2 = iOcFxMKRTzzQhmvuuuNEXBDDbUON.GetTemplateElementIdentifier(m);
				if (templateElementIdentifier2 == null || InputTools.IsMappableType(templateElementIdentifier2.elementType))
				{
					continue;
				}
				IControllerTemplateMapSpecialElement_Internal specialTemplateElementByElementIdentifierId = iOcFxMKRTzzQhmvuuuNEXBDDbUON.GetSpecialTemplateElementByElementIdentifierId(templateElementIdentifier2.id);
				YYjpTGeypKuHJYOzvnyAyPmfPEfn yYjpTGeypKuHJYOzvnyAyPmfPEfn;
				switch (templateElementIdentifier2.elementType)
				{
				case ControllerTemplateElementType.ThumbStick:
				{
					if (specialTemplateElementByElementIdentifierId == null)
					{
						Logger.LogError(templateElementIdentifier2.elementType.ToString() + " element missing for Element Identifier Id " + templateElementIdentifier2.id);
					}
					ControllerTemplateThumbStickMapping mapping5 = specialTemplateElementByElementIdentifierId.GetMapping<ControllerTemplateThumbStickMapping>();
					yYjpTGeypKuHJYOzvnyAyPmfPEfn = new lmsmNZTPnWFlvDONrYsywnZRaPrgA(this, templateElementIdentifier2.id, templateElementIdentifier2.nonLocalizedName, templateElementIdentifier2.key, (mapping5 != null) ? yRFXhPIOMmcVkkkpRCyUSQEEEtjh(this, aDictionary, mapping5.eid_axisX) : vyUuyGVoBSHRAeomrSKtoxAdqJC.kBqrzRiVlVLxekJwbdIPmLPZtUDA(this), (mapping5 != null) ? yRFXhPIOMmcVkkkpRCyUSQEEEtjh(this, aDictionary, mapping5.eid_axisY) : vyUuyGVoBSHRAeomrSKtoxAdqJC.kBqrzRiVlVLxekJwbdIPmLPZtUDA(this), (mapping5 != null) ? OSdDCvuYcKqvcgWpDprvEmdyFbGCA(this, aDictionary, mapping5.eid_button) : WSWBqdXhsJebMVCilWvuKFuXCKMAA.JezrnTUUJQotMkMMdixlBvVtesvo(this));
					break;
				}
				case ControllerTemplateElementType.DPad:
				{
					if (specialTemplateElementByElementIdentifierId == null)
					{
						Logger.LogError(templateElementIdentifier2.elementType.ToString() + " element missing for Element Identifier Id " + templateElementIdentifier2.id);
					}
					ControllerTemplateDPadMapping mapping3 = specialTemplateElementByElementIdentifierId.GetMapping<ControllerTemplateDPadMapping>();
					yYjpTGeypKuHJYOzvnyAyPmfPEfn = new ZpXhLSqRATskOTKsBaFdngDouhnV(this, templateElementIdentifier2.id, templateElementIdentifier2.nonLocalizedName, templateElementIdentifier2.key, (mapping3 != null) ? OSdDCvuYcKqvcgWpDprvEmdyFbGCA(this, aDictionary, mapping3.eid_up) : WSWBqdXhsJebMVCilWvuKFuXCKMAA.JezrnTUUJQotMkMMdixlBvVtesvo(this), (mapping3 != null) ? OSdDCvuYcKqvcgWpDprvEmdyFbGCA(this, aDictionary, mapping3.eid_right) : WSWBqdXhsJebMVCilWvuKFuXCKMAA.JezrnTUUJQotMkMMdixlBvVtesvo(this), (mapping3 != null) ? OSdDCvuYcKqvcgWpDprvEmdyFbGCA(this, aDictionary, mapping3.eid_down) : WSWBqdXhsJebMVCilWvuKFuXCKMAA.JezrnTUUJQotMkMMdixlBvVtesvo(this), (mapping3 != null) ? OSdDCvuYcKqvcgWpDprvEmdyFbGCA(this, aDictionary, mapping3.eid_left) : WSWBqdXhsJebMVCilWvuKFuXCKMAA.JezrnTUUJQotMkMMdixlBvVtesvo(this), (mapping3 != null) ? OSdDCvuYcKqvcgWpDprvEmdyFbGCA(this, aDictionary, mapping3.eid_press) : WSWBqdXhsJebMVCilWvuKFuXCKMAA.JezrnTUUJQotMkMMdixlBvVtesvo(this));
					break;
				}
				case ControllerTemplateElementType.Stick:
				{
					if (specialTemplateElementByElementIdentifierId == null)
					{
						Logger.LogError(templateElementIdentifier2.elementType.ToString() + " element missing for Element Identifier Id " + templateElementIdentifier2.id);
					}
					ControllerTemplateStickMapping mapping2 = specialTemplateElementByElementIdentifierId.GetMapping<ControllerTemplateStickMapping>();
					yYjpTGeypKuHJYOzvnyAyPmfPEfn = new kUPqUxzOtjXnFackMZynboOUUfOC(this, templateElementIdentifier2.id, templateElementIdentifier2.nonLocalizedName, templateElementIdentifier2.key, (mapping2 != null) ? yRFXhPIOMmcVkkkpRCyUSQEEEtjh(this, aDictionary, mapping2.eid_axisX) : vyUuyGVoBSHRAeomrSKtoxAdqJC.kBqrzRiVlVLxekJwbdIPmLPZtUDA(this), (mapping2 != null) ? yRFXhPIOMmcVkkkpRCyUSQEEEtjh(this, aDictionary, mapping2.eid_axisY) : vyUuyGVoBSHRAeomrSKtoxAdqJC.kBqrzRiVlVLxekJwbdIPmLPZtUDA(this), (mapping2 != null) ? yRFXhPIOMmcVkkkpRCyUSQEEEtjh(this, aDictionary, mapping2.eid_axisZ) : vyUuyGVoBSHRAeomrSKtoxAdqJC.kBqrzRiVlVLxekJwbdIPmLPZtUDA(this));
					break;
				}
				case ControllerTemplateElementType.Throttle:
				{
					if (specialTemplateElementByElementIdentifierId == null)
					{
						Logger.LogError(templateElementIdentifier2.elementType.ToString() + " element missing for Element Identifier Id " + templateElementIdentifier2.id);
					}
					ControllerTemplateThrottleMapping mapping6 = specialTemplateElementByElementIdentifierId.GetMapping<ControllerTemplateThrottleMapping>();
					yYjpTGeypKuHJYOzvnyAyPmfPEfn = new KnfOkvlczPRfNxOtnvkXkECsONtb(this, templateElementIdentifier2.id, templateElementIdentifier2.nonLocalizedName, templateElementIdentifier2.key, (mapping6 != null) ? yRFXhPIOMmcVkkkpRCyUSQEEEtjh(this, aDictionary, mapping6.eid_axis) : vyUuyGVoBSHRAeomrSKtoxAdqJC.kBqrzRiVlVLxekJwbdIPmLPZtUDA(this), (mapping6 != null) ? OSdDCvuYcKqvcgWpDprvEmdyFbGCA(this, aDictionary, mapping6.eid_minDetent) : WSWBqdXhsJebMVCilWvuKFuXCKMAA.JezrnTUUJQotMkMMdixlBvVtesvo(this));
					break;
				}
				case ControllerTemplateElementType.Hat:
				{
					if (specialTemplateElementByElementIdentifierId == null)
					{
						Logger.LogError(templateElementIdentifier2.elementType.ToString() + " element missing for Element Identifier Id " + templateElementIdentifier2.id);
					}
					ControllerTemplateHatMapping mapping7 = specialTemplateElementByElementIdentifierId.GetMapping<ControllerTemplateHatMapping>();
					yYjpTGeypKuHJYOzvnyAyPmfPEfn = new voVUXmEisrbEaWnsoIIHCkGxFszdA(this, templateElementIdentifier2.id, templateElementIdentifier2.nonLocalizedName, templateElementIdentifier2.key, (mapping7 != null) ? OSdDCvuYcKqvcgWpDprvEmdyFbGCA(this, aDictionary, mapping7.eid_up) : WSWBqdXhsJebMVCilWvuKFuXCKMAA.JezrnTUUJQotMkMMdixlBvVtesvo(this), (mapping7 != null) ? OSdDCvuYcKqvcgWpDprvEmdyFbGCA(this, aDictionary, mapping7.eid_upRight) : WSWBqdXhsJebMVCilWvuKFuXCKMAA.JezrnTUUJQotMkMMdixlBvVtesvo(this), (mapping7 != null) ? OSdDCvuYcKqvcgWpDprvEmdyFbGCA(this, aDictionary, mapping7.eid_right) : WSWBqdXhsJebMVCilWvuKFuXCKMAA.JezrnTUUJQotMkMMdixlBvVtesvo(this), (mapping7 != null) ? OSdDCvuYcKqvcgWpDprvEmdyFbGCA(this, aDictionary, mapping7.eid_downRight) : WSWBqdXhsJebMVCilWvuKFuXCKMAA.JezrnTUUJQotMkMMdixlBvVtesvo(this), (mapping7 != null) ? OSdDCvuYcKqvcgWpDprvEmdyFbGCA(this, aDictionary, mapping7.eid_down) : WSWBqdXhsJebMVCilWvuKFuXCKMAA.JezrnTUUJQotMkMMdixlBvVtesvo(this), (mapping7 != null) ? OSdDCvuYcKqvcgWpDprvEmdyFbGCA(this, aDictionary, mapping7.eid_downLeft) : WSWBqdXhsJebMVCilWvuKFuXCKMAA.JezrnTUUJQotMkMMdixlBvVtesvo(this), (mapping7 != null) ? OSdDCvuYcKqvcgWpDprvEmdyFbGCA(this, aDictionary, mapping7.eid_left) : WSWBqdXhsJebMVCilWvuKFuXCKMAA.JezrnTUUJQotMkMMdixlBvVtesvo(this), (mapping7 != null) ? OSdDCvuYcKqvcgWpDprvEmdyFbGCA(this, aDictionary, mapping7.eid_upLeft) : WSWBqdXhsJebMVCilWvuKFuXCKMAA.JezrnTUUJQotMkMMdixlBvVtesvo(this));
					break;
				}
				case ControllerTemplateElementType.Yoke:
				{
					if (specialTemplateElementByElementIdentifierId == null)
					{
						Logger.LogError(templateElementIdentifier2.elementType.ToString() + " element missing for Element Identifier Id " + templateElementIdentifier2.id);
					}
					ControllerTemplateYokeMapping mapping4 = specialTemplateElementByElementIdentifierId.GetMapping<ControllerTemplateYokeMapping>();
					yYjpTGeypKuHJYOzvnyAyPmfPEfn = new fEGFNXFAXiGFbCeeARfFRqRRviEFB(this, templateElementIdentifier2.id, templateElementIdentifier2.nonLocalizedName, templateElementIdentifier2.key, (mapping4 != null) ? yRFXhPIOMmcVkkkpRCyUSQEEEtjh(this, aDictionary, mapping4.eid_axisX) : vyUuyGVoBSHRAeomrSKtoxAdqJC.kBqrzRiVlVLxekJwbdIPmLPZtUDA(this), (mapping4 != null) ? yRFXhPIOMmcVkkkpRCyUSQEEEtjh(this, aDictionary, mapping4.eid_axisZ) : vyUuyGVoBSHRAeomrSKtoxAdqJC.kBqrzRiVlVLxekJwbdIPmLPZtUDA(this));
					break;
				}
				case ControllerTemplateElementType.Stick6D:
				{
					if (specialTemplateElementByElementIdentifierId == null)
					{
						Logger.LogError(templateElementIdentifier2.elementType.ToString() + " element missing for Element Identifier Id " + templateElementIdentifier2.id);
					}
					ControllerTemplateStick6DMapping mapping = specialTemplateElementByElementIdentifierId.GetMapping<ControllerTemplateStick6DMapping>();
					yYjpTGeypKuHJYOzvnyAyPmfPEfn = new FIVvIWuLGHuDfjmPDeGCalxLDFZh(this, templateElementIdentifier2.id, templateElementIdentifier2.nonLocalizedName, templateElementIdentifier2.key, (mapping != null) ? yRFXhPIOMmcVkkkpRCyUSQEEEtjh(this, aDictionary, mapping.eid_positionX) : vyUuyGVoBSHRAeomrSKtoxAdqJC.kBqrzRiVlVLxekJwbdIPmLPZtUDA(this), (mapping != null) ? yRFXhPIOMmcVkkkpRCyUSQEEEtjh(this, aDictionary, mapping.eid_positionY) : vyUuyGVoBSHRAeomrSKtoxAdqJC.kBqrzRiVlVLxekJwbdIPmLPZtUDA(this), (mapping != null) ? yRFXhPIOMmcVkkkpRCyUSQEEEtjh(this, aDictionary, mapping.eid_positionZ) : vyUuyGVoBSHRAeomrSKtoxAdqJC.kBqrzRiVlVLxekJwbdIPmLPZtUDA(this), (mapping != null) ? yRFXhPIOMmcVkkkpRCyUSQEEEtjh(this, aDictionary, mapping.eid_rotationX) : vyUuyGVoBSHRAeomrSKtoxAdqJC.kBqrzRiVlVLxekJwbdIPmLPZtUDA(this), (mapping != null) ? yRFXhPIOMmcVkkkpRCyUSQEEEtjh(this, aDictionary, mapping.eid_rotationY) : vyUuyGVoBSHRAeomrSKtoxAdqJC.kBqrzRiVlVLxekJwbdIPmLPZtUDA(this), (mapping != null) ? yRFXhPIOMmcVkkkpRCyUSQEEEtjh(this, aDictionary, mapping.eid_rotationZ) : vyUuyGVoBSHRAeomrSKtoxAdqJC.kBqrzRiVlVLxekJwbdIPmLPZtUDA(this));
					break;
				}
				default:
					throw new NotImplementedException();
				}
				if (yYjpTGeypKuHJYOzvnyAyPmfPEfn != null)
				{
					list4.Add(yYjpTGeypKuHJYOzvnyAyPmfPEfn);
				}
			}
			for (int n = 0; n < list4.Count; n++)
			{
				list.Add(list4[n]);
				aDictionary.Add(list4[n].id, list4[n]);
			}
			rbKnwFUuPijnSUlTJRLndGRZhENB = list.ToArray();
			TJzEJIeBVLSRtDSFMHNFmRtGTBKS = aDictionary;
			acAAgIfkBzZaehkbDWDkUqaXDalo = new ADictionary<string, IControllerTemplateElement>();
			for (int num = 0; num < rbKnwFUuPijnSUlTJRLndGRZhENB.Length; num++)
			{
				if (!(iOcFxMKRTzzQhmvuuuNEXBDDbUON.GetTemplateElementIdentifierById(rbKnwFUuPijnSUlTJRLndGRZhENB[num].id) is IControllerTemplateElementIdentifier_Editor controllerTemplateElementIdentifier_Editor))
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
							acAAgIfkBzZaehkbDWDkUqaXDalo.Add(text, rbKnwFUuPijnSUlTJRLndGRZhENB[num]);
						}
						catch
						{
							Logger.LogError("A duplicate Controller Template element scripting name (" + text + ") was found in template " + LdbzREMxGWdWuUmWlZxMUjsafXrE + ". This element should be renamed to a unique name.");
						}
					}
				}
			}
			HIYHBWpOgZNgrvdojAgGZzHJgZJS = new ReadOnlyCollection<IControllerTemplateElement>(rbKnwFUuPijnSUlTJRLndGRZhENB);
		}

		protected IControllerTemplateElement GetElement(int id)
		{
			if (!TJzEJIeBVLSRtDSFMHNFmRtGTBKS.TryGetValue(id, out var value))
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
			if (ReInput._id != UgWhYoisePaOdKLfjQrWSGozPQst)
			{
				ReInput.CheckInitialized(UgWhYoisePaOdKLfjQrWSGozPQst);
				return null;
			}
			return GetElement(id);
		}

		T IControllerTemplate.GetElement<T>(int id)
		{
			if (ReInput._id != UgWhYoisePaOdKLfjQrWSGozPQst)
			{
				ReInput.CheckInitialized(UgWhYoisePaOdKLfjQrWSGozPQst);
				return null;
			}
			return GetElement<T>(id);
		}

		int IControllerTemplate.GetElementTargets(ControllerElementTarget find, IList<ControllerTemplateElementTarget> results)
		{
			if (ReInput._id != UgWhYoisePaOdKLfjQrWSGozPQst)
			{
				ReInput.CheckInitialized(UgWhYoisePaOdKLfjQrWSGozPQst);
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
			for (int i = 0; i < rbKnwFUuPijnSUlTJRLndGRZhENB.Length; i++)
			{
				if (InputTools.IsMappableType(rbKnwFUuPijnSUlTJRLndGRZhENB[i].type))
				{
					num += (rbKnwFUuPijnSUlTJRLndGRZhENB[i] as IControllerTemplateElement_Internal).GetElementTargets(find, ref results);
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

		private static IList<hutPhcBnEQdPRoJEXCJgCtixxCeM> ZHtyJRqXejMduXZcwblElSRqsAPl(Controller P_0, IControllerTemplateAxisSource P_1)
		{
			if (P_1 == null)
			{
				return null;
			}
			if (P_1.splitAxis)
			{
				IList<hutPhcBnEQdPRoJEXCJgCtixxCeM> list = null;
				bool flag = false;
				if (P_1.positiveTarget != null)
				{
					Controller.Element elementById = P_0.GetElementById(P_1.positiveTarget.elementIdentifierId);
					if (elementById != null)
					{
						ListTools.AddAndCreateList(ref list, new hutPhcBnEQdPRoJEXCJgCtixxCeM(P_1.positiveTarget, elementById));
						flag = true;
					}
				}
				if (!flag)
				{
					ListTools.AddAndCreateList(ref list, hutPhcBnEQdPRoJEXCJgCtixxCeM.QmKEQTghVEFKPhcUiKOuSqSYZBvuA());
				}
				flag = false;
				if (P_1.negativeTarget != null)
				{
					Controller.Element elementById2 = P_0.GetElementById(P_1.negativeTarget.elementIdentifierId);
					if (elementById2 != null)
					{
						ListTools.AddAndCreateList(ref list, new hutPhcBnEQdPRoJEXCJgCtixxCeM(P_1.negativeTarget, elementById2));
						flag = true;
					}
				}
				if (!flag)
				{
					ListTools.AddAndCreateList(ref list, hutPhcBnEQdPRoJEXCJgCtixxCeM.QmKEQTghVEFKPhcUiKOuSqSYZBvuA());
				}
				return list;
			}
			return hqIsULBeeCaBfZOUVbFEHBTrbUkhA(P_0, P_1.fullTarget);
		}

		private static IList<hutPhcBnEQdPRoJEXCJgCtixxCeM> UvrfogArdwitUXSxZOfZgydHEXhA(Controller P_0, IControllerTemplateButtonSource P_1)
		{
			if (P_1 == null)
			{
				return null;
			}
			return hqIsULBeeCaBfZOUVbFEHBTrbUkhA(P_0, P_1.target);
		}

		private static IList<hutPhcBnEQdPRoJEXCJgCtixxCeM> hqIsULBeeCaBfZOUVbFEHBTrbUkhA(Controller P_0, IControllerElementTarget P_1)
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
			return new List<hutPhcBnEQdPRoJEXCJgCtixxCeM>
			{
				new hutPhcBnEQdPRoJEXCJgCtixxCeM(P_1, elementById)
			};
		}

		private static IControllerTemplateElement EpxxYqToLEaAydMbTIIMDKOupnFzA(List<IControllerTemplateElement> P_0, int P_1)
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

		private static AbuLYXhDofdMHjmwNPaBwEYJNRUkA yRFXhPIOMmcVkkkpRCyUSQEEEtjh(IControllerTemplate_Internal P_0, ADictionary<int, IControllerTemplateElement> P_1, int P_2)
		{
			if (!(P_1.GetValueSafe(P_2) is AbuLYXhDofdMHjmwNPaBwEYJNRUkA result))
			{
				return vyUuyGVoBSHRAeomrSKtoxAdqJC.kBqrzRiVlVLxekJwbdIPmLPZtUDA(P_0);
			}
			return result;
		}

		private static AbuLYXhDofdMHjmwNPaBwEYJNRUkA OSdDCvuYcKqvcgWpDprvEmdyFbGCA(IControllerTemplate_Internal P_0, ADictionary<int, IControllerTemplateElement> P_1, int P_2)
		{
			if (!(P_1.GetValueSafe(P_2) is AbuLYXhDofdMHjmwNPaBwEYJNRUkA result))
			{
				return WSWBqdXhsJebMVCilWvuKFuXCKMAA.JezrnTUUJQotMkMMdixlBvVtesvo(P_0);
			}
			return result;
		}
	}
}
