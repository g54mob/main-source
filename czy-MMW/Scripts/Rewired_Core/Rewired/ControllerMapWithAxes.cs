using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

namespace Rewired
{
	public abstract class ControllerMapWithAxes : ControllerMap
	{
		private sealed class kdLRwNXINhTutvQCBFAiEEzuMdfC : IEnumerable<ActionElementMap>, IEnumerable, IEnumerator<ActionElementMap>, IEnumerator, IDisposable
		{
			private int SMNsDOEfmGcMgIwLviyITcDkIowT;

			private ActionElementMap znDCLmaRBvbxzOcYQoFMyhjuAwWTA;

			private int yoVaRPOxAAvajODTKsTeirfkfrJdA;

			public ControllerMapWithAxes znaGTXraZwVqExUNzaymKeloykKH;

			private int MqjNVGYpAHHAudjKZHUovqclskJEA;

			public int bTSBdkeMztjcKDgCBdvoewWQoohy;

			private bool mqQfECTNKKDwnzaQgPaNuRXYJSLR;

			public bool pFwUkUREtwMJuxyIeglHJuVqsgnp;

			private IEnumerator<ActionElementMap> KrieqWKVxIlssTyvcozQapmXfPnu;

			ActionElementMap IEnumerator<ActionElementMap>.Current
			{
				[DebuggerHidden]
				get
				{
					return znDCLmaRBvbxzOcYQoFMyhjuAwWTA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return znDCLmaRBvbxzOcYQoFMyhjuAwWTA;
				}
			}

			[DebuggerHidden]
			public kdLRwNXINhTutvQCBFAiEEzuMdfC(int P_0)
			{
				SMNsDOEfmGcMgIwLviyITcDkIowT = P_0;
				yoVaRPOxAAvajODTKsTeirfkfrJdA = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int sMNsDOEfmGcMgIwLviyITcDkIowT = SMNsDOEfmGcMgIwLviyITcDkIowT;
				if (sMNsDOEfmGcMgIwLviyITcDkIowT == -3 || sMNsDOEfmGcMgIwLviyITcDkIowT == 1)
				{
					try
					{
					}
					finally
					{
						yGFVMjnBgAToCXNccDTEIigFJwxf();
					}
				}
			}

			private bool MoveNext()
			{
				try
				{
					int sMNsDOEfmGcMgIwLviyITcDkIowT = SMNsDOEfmGcMgIwLviyITcDkIowT;
					ControllerMapWithAxes controllerMapWithAxes = znaGTXraZwVqExUNzaymKeloykKH;
					switch (sMNsDOEfmGcMgIwLviyITcDkIowT)
					{
					default:
						return false;
					case 0:
						SMNsDOEfmGcMgIwLviyITcDkIowT = -1;
						if (ReInput._id != controllerMapWithAxes.sIwyLhKUWykANTFJFXecFgCmwcwn)
						{
							ReInput.CheckInitialized(controllerMapWithAxes.sIwyLhKUWykANTFJFXecFgCmwcwn);
							return false;
						}
						if (MqjNVGYpAHHAudjKZHUovqclskJEA < 0)
						{
							return false;
						}
						KrieqWKVxIlssTyvcozQapmXfPnu = controllerMapWithAxes.AxisMaps.GetEnumerator();
						SMNsDOEfmGcMgIwLviyITcDkIowT = -3;
						break;
					case 1:
						SMNsDOEfmGcMgIwLviyITcDkIowT = -3;
						break;
					}
					while (KrieqWKVxIlssTyvcozQapmXfPnu.MoveNext())
					{
						ActionElementMap current = KrieqWKVxIlssTyvcozQapmXfPnu.Current;
						if (current._actionId == MqjNVGYpAHHAudjKZHUovqclskJEA && (!mqQfECTNKKDwnzaQgPaNuRXYJSLR || current.dQASdaEFVJzbOgxgKEdsYSDArFzi))
						{
							znDCLmaRBvbxzOcYQoFMyhjuAwWTA = current;
							SMNsDOEfmGcMgIwLviyITcDkIowT = 1;
							return true;
						}
					}
					yGFVMjnBgAToCXNccDTEIigFJwxf();
					KrieqWKVxIlssTyvcozQapmXfPnu = null;
					return false;
				}
				catch
				{
					//try-fault
					((IDisposable)this).Dispose();
					throw;
				}
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			private void yGFVMjnBgAToCXNccDTEIigFJwxf()
			{
				SMNsDOEfmGcMgIwLviyITcDkIowT = -1;
				if (KrieqWKVxIlssTyvcozQapmXfPnu != null)
				{
					KrieqWKVxIlssTyvcozQapmXfPnu.Dispose();
				}
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}

			[DebuggerHidden]
			IEnumerator<ActionElementMap> IEnumerable<ActionElementMap>.GetEnumerator()
			{
				kdLRwNXINhTutvQCBFAiEEzuMdfC kdLRwNXINhTutvQCBFAiEEzuMdfC2;
				if (SMNsDOEfmGcMgIwLviyITcDkIowT == -2 && yoVaRPOxAAvajODTKsTeirfkfrJdA == Environment.CurrentManagedThreadId)
				{
					SMNsDOEfmGcMgIwLviyITcDkIowT = 0;
					kdLRwNXINhTutvQCBFAiEEzuMdfC2 = this;
				}
				else
				{
					kdLRwNXINhTutvQCBFAiEEzuMdfC2 = new kdLRwNXINhTutvQCBFAiEEzuMdfC(0);
					kdLRwNXINhTutvQCBFAiEEzuMdfC2.znaGTXraZwVqExUNzaymKeloykKH = znaGTXraZwVqExUNzaymKeloykKH;
				}
				kdLRwNXINhTutvQCBFAiEEzuMdfC2.MqjNVGYpAHHAudjKZHUovqclskJEA = bTSBdkeMztjcKDgCBdvoewWQoohy;
				kdLRwNXINhTutvQCBFAiEEzuMdfC2.mqQfECTNKKDwnzaQgPaNuRXYJSLR = pFwUkUREtwMJuxyIeglHJuVqsgnp;
				return kdLRwNXINhTutvQCBFAiEEzuMdfC2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
			}
		}

		private sealed class qtAxUFdaJcdudxhnYYuwEnkpHfYL : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
		{
			private int uvqXNYEhUBPtLWhIJQKMKonwVvHJ;

			private ElementAssignmentConflictInfo DzUeriCUZTUROsAphRDtVRYOXiby;

			private int vqkXucLECIXNInUFhexALErcGKEn;

			public ControllerMapWithAxes oEYIaSuHsFycKSDdAARnqUrRJRpU;

			private ControllerMap WkocunFRUvUoUPtnBpvKPgoJHqll;

			public ControllerMap bgwwqrDcZlyMLJiqBdvScPrKXraNA;

			private bool oQlQqPKPDyyTvmACHdAhAeXGMeIqA;

			public bool LDmGKtbVyWdOSMtPzRKnrLFJqPtU;

			private IList<ActionElementMap> lHdFAUkVfTMSCbShHzHWzUuMuQJO;

			private int mEBnSWCgdMsKKcEPuHLhFWKytPDz;

			private IEnumerator<ElementAssignmentConflictInfo> oLxEeHjqdMsKWKOYbCcyBSXIJqAwB;

			private int VpciMLSkToIUQcWdOuqHjIsXeZyT;

			private ActionElementMap RwuySyngEhIMeGxXpoXoqcIaWFMsA;

			private int zlrqiCvOohJSepNFLEVfAsQqAlbK;

			ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return DzUeriCUZTUROsAphRDtVRYOXiby;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return DzUeriCUZTUROsAphRDtVRYOXiby;
				}
			}

			[DebuggerHidden]
			public qtAxUFdaJcdudxhnYYuwEnkpHfYL(int P_0)
			{
				uvqXNYEhUBPtLWhIJQKMKonwVvHJ = P_0;
				vqkXucLECIXNInUFhexALErcGKEn = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int num = uvqXNYEhUBPtLWhIJQKMKonwVvHJ;
				if (num == -3 || num == 1)
				{
					try
					{
					}
					finally
					{
						dcmCgOamNrBHHEkdRbwpdojyazwP();
					}
				}
			}

			private bool MoveNext()
			{
				try
				{
					int num = uvqXNYEhUBPtLWhIJQKMKonwVvHJ;
					ControllerMapWithAxes controllerMapWithAxes = oEYIaSuHsFycKSDdAARnqUrRJRpU;
					switch (num)
					{
					default:
						return false;
					case 0:
						uvqXNYEhUBPtLWhIJQKMKonwVvHJ = -1;
						if (ReInput._id != controllerMapWithAxes.sIwyLhKUWykANTFJFXecFgCmwcwn)
						{
							ReInput.CheckInitialized(controllerMapWithAxes.sIwyLhKUWykANTFJFXecFgCmwcwn);
							return false;
						}
						if (WkocunFRUvUoUPtnBpvKPgoJHqll == null)
						{
							return false;
						}
						oLxEeHjqdMsKWKOYbCcyBSXIJqAwB = ((ControllerMap)controllerMapWithAxes).ElementAssignmentConflicts(WkocunFRUvUoUPtnBpvKPgoJHqll, oQlQqPKPDyyTvmACHdAhAeXGMeIqA).GetEnumerator();
						uvqXNYEhUBPtLWhIJQKMKonwVvHJ = -3;
						goto IL_00af;
					case 1:
						uvqXNYEhUBPtLWhIJQKMKonwVvHJ = -3;
						goto IL_00af;
					case 2:
						{
							uvqXNYEhUBPtLWhIJQKMKonwVvHJ = -1;
							goto IL_0232;
						}
						IL_0244:
						if (zlrqiCvOohJSepNFLEVfAsQqAlbK < mEBnSWCgdMsKKcEPuHLhFWKytPDz)
						{
							ActionElementMap actionElementMap = lHdFAUkVfTMSCbShHzHWzUuMuQJO[zlrqiCvOohJSepNFLEVfAsQqAlbK];
							if ((!oQlQqPKPDyyTvmACHdAhAeXGMeIqA || actionElementMap.dQASdaEFVJzbOgxgKEdsYSDArFzi) && RwuySyngEhIMeGxXpoXoqcIaWFMsA.CheckForAssignmentConflict(actionElementMap))
							{
								DzUeriCUZTUROsAphRDtVRYOXiby = new ElementAssignmentConflictInfo(true, ReInput.mapping.GetMapCategory(controllerMapWithAxes._categoryId).userAssignable, -1, controllerMapWithAxes._controllerType, controllerMapWithAxes._controllerId, controllerMapWithAxes._id, RwuySyngEhIMeGxXpoXoqcIaWFMsA.oFUAyzlkDBdPoonWGgEIgJYWTzJOA, RwuySyngEhIMeGxXpoXoqcIaWFMsA._actionId, RwuySyngEhIMeGxXpoXoqcIaWFMsA._elementType, RwuySyngEhIMeGxXpoXoqcIaWFMsA._elementIdentifierId, RwuySyngEhIMeGxXpoXoqcIaWFMsA.keyCode, RwuySyngEhIMeGxXpoXoqcIaWFMsA.modifierKeyFlags);
								uvqXNYEhUBPtLWhIJQKMKonwVvHJ = 2;
								return true;
							}
							goto IL_0232;
						}
						RwuySyngEhIMeGxXpoXoqcIaWFMsA = null;
						goto IL_025c;
						IL_0232:
						zlrqiCvOohJSepNFLEVfAsQqAlbK++;
						goto IL_0244;
						IL_026e:
						if (VpciMLSkToIUQcWdOuqHjIsXeZyT < controllerMapWithAxes.UUHETvjEpNhDHXYwlfeLsKyNvXhAA.Count)
						{
							RwuySyngEhIMeGxXpoXoqcIaWFMsA = controllerMapWithAxes.UUHETvjEpNhDHXYwlfeLsKyNvXhAA[VpciMLSkToIUQcWdOuqHjIsXeZyT];
							if (!oQlQqPKPDyyTvmACHdAhAeXGMeIqA || RwuySyngEhIMeGxXpoXoqcIaWFMsA.dQASdaEFVJzbOgxgKEdsYSDArFzi)
							{
								zlrqiCvOohJSepNFLEVfAsQqAlbK = 0;
								goto IL_0244;
							}
							goto IL_025c;
						}
						return false;
						IL_00af:
						if (oLxEeHjqdMsKWKOYbCcyBSXIJqAwB.MoveNext())
						{
							ElementAssignmentConflictInfo current = oLxEeHjqdMsKWKOYbCcyBSXIJqAwB.Current;
							DzUeriCUZTUROsAphRDtVRYOXiby = current;
							uvqXNYEhUBPtLWhIJQKMKonwVvHJ = 1;
							return true;
						}
						dcmCgOamNrBHHEkdRbwpdojyazwP();
						oLxEeHjqdMsKWKOYbCcyBSXIJqAwB = null;
						if (!(WkocunFRUvUoUPtnBpvKPgoJHqll is ControllerMapWithAxes controllerMapWithAxes2))
						{
							return false;
						}
						if (oQlQqPKPDyyTvmACHdAhAeXGMeIqA && (!controllerMapWithAxes._enabled || !controllerMapWithAxes2._enabled))
						{
							return false;
						}
						lHdFAUkVfTMSCbShHzHWzUuMuQJO = controllerMapWithAxes2.AxisMaps;
						if (lHdFAUkVfTMSCbShHzHWzUuMuQJO == null)
						{
							return false;
						}
						mEBnSWCgdMsKKcEPuHLhFWKytPDz = lHdFAUkVfTMSCbShHzHWzUuMuQJO.Count;
						VpciMLSkToIUQcWdOuqHjIsXeZyT = 0;
						goto IL_026e;
						IL_025c:
						VpciMLSkToIUQcWdOuqHjIsXeZyT++;
						goto IL_026e;
					}
				}
				catch
				{
					//try-fault
					((IDisposable)this).Dispose();
					throw;
				}
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			private void dcmCgOamNrBHHEkdRbwpdojyazwP()
			{
				uvqXNYEhUBPtLWhIJQKMKonwVvHJ = -1;
				if (oLxEeHjqdMsKWKOYbCcyBSXIJqAwB != null)
				{
					oLxEeHjqdMsKWKOYbCcyBSXIJqAwB.Dispose();
				}
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}

			[DebuggerHidden]
			IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
			{
				qtAxUFdaJcdudxhnYYuwEnkpHfYL qtAxUFdaJcdudxhnYYuwEnkpHfYL2;
				if (uvqXNYEhUBPtLWhIJQKMKonwVvHJ == -2 && vqkXucLECIXNInUFhexALErcGKEn == Environment.CurrentManagedThreadId)
				{
					uvqXNYEhUBPtLWhIJQKMKonwVvHJ = 0;
					qtAxUFdaJcdudxhnYYuwEnkpHfYL2 = this;
				}
				else
				{
					qtAxUFdaJcdudxhnYYuwEnkpHfYL2 = new qtAxUFdaJcdudxhnYYuwEnkpHfYL(0);
					qtAxUFdaJcdudxhnYYuwEnkpHfYL2.oEYIaSuHsFycKSDdAARnqUrRJRpU = oEYIaSuHsFycKSDdAARnqUrRJRpU;
				}
				qtAxUFdaJcdudxhnYYuwEnkpHfYL2.WkocunFRUvUoUPtnBpvKPgoJHqll = bgwwqrDcZlyMLJiqBdvScPrKXraNA;
				qtAxUFdaJcdudxhnYYuwEnkpHfYL2.oQlQqPKPDyyTvmACHdAhAeXGMeIqA = LDmGKtbVyWdOSMtPzRKnrLFJqPtU;
				return qtAxUFdaJcdudxhnYYuwEnkpHfYL2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
			}
		}

		private sealed class xeDoawbHnvkUINIIzVvtWOhboEvp : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
		{
			private int GuQUyvEEHwtqdMbFGxJmTIfrAbPfA;

			private ElementAssignmentConflictInfo sNrfunDCJtLeoHPJtVkVLgzUzCsy;

			private int nufAtLiLYcOmYXdNiavxYSyrwNchA;

			public ControllerMapWithAxes JURIZkJpPGdRrznUGFdpBLwDBVcP;

			private ActionElementMap lCQVrZAAkdnAPcfxlKMtKVJNVwLP;

			public ActionElementMap XDCxDgmOgeNmyNJuqSjyEPDTlwGi;

			private bool IilebBYPjbMGsNPsGAvQDkKCXvcN;

			public bool OUoIaPvcxyrJJbRGeGyCEBoXsTYm;

			private IEnumerator<ElementAssignmentConflictInfo> pYZQTwAjdJPUvBXrAOvNOjdMVCyI;

			private int UEdwknnwNKPnJTLSKZbumWfwHszJ;

			ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return sNrfunDCJtLeoHPJtVkVLgzUzCsy;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return sNrfunDCJtLeoHPJtVkVLgzUzCsy;
				}
			}

			[DebuggerHidden]
			public xeDoawbHnvkUINIIzVvtWOhboEvp(int P_0)
			{
				GuQUyvEEHwtqdMbFGxJmTIfrAbPfA = P_0;
				nufAtLiLYcOmYXdNiavxYSyrwNchA = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int guQUyvEEHwtqdMbFGxJmTIfrAbPfA = GuQUyvEEHwtqdMbFGxJmTIfrAbPfA;
				if (guQUyvEEHwtqdMbFGxJmTIfrAbPfA == -3 || guQUyvEEHwtqdMbFGxJmTIfrAbPfA == 1)
				{
					try
					{
					}
					finally
					{
						ziasICNXARjUsUQEEDFhVXRlvNCw();
					}
				}
			}

			private bool MoveNext()
			{
				try
				{
					int guQUyvEEHwtqdMbFGxJmTIfrAbPfA = GuQUyvEEHwtqdMbFGxJmTIfrAbPfA;
					ControllerMapWithAxes jURIZkJpPGdRrznUGFdpBLwDBVcP = JURIZkJpPGdRrznUGFdpBLwDBVcP;
					switch (guQUyvEEHwtqdMbFGxJmTIfrAbPfA)
					{
					default:
						return false;
					case 0:
						GuQUyvEEHwtqdMbFGxJmTIfrAbPfA = -1;
						if (ReInput._id != jURIZkJpPGdRrznUGFdpBLwDBVcP.sIwyLhKUWykANTFJFXecFgCmwcwn)
						{
							ReInput.CheckInitialized(jURIZkJpPGdRrznUGFdpBLwDBVcP.sIwyLhKUWykANTFJFXecFgCmwcwn);
							return false;
						}
						if (lCQVrZAAkdnAPcfxlKMtKVJNVwLP == null)
						{
							return false;
						}
						pYZQTwAjdJPUvBXrAOvNOjdMVCyI = ((ControllerMap)jURIZkJpPGdRrznUGFdpBLwDBVcP).ElementAssignmentConflicts(lCQVrZAAkdnAPcfxlKMtKVJNVwLP, IilebBYPjbMGsNPsGAvQDkKCXvcN).GetEnumerator();
						GuQUyvEEHwtqdMbFGxJmTIfrAbPfA = -3;
						goto IL_00ad;
					case 1:
						GuQUyvEEHwtqdMbFGxJmTIfrAbPfA = -3;
						goto IL_00ad;
					case 2:
						{
							GuQUyvEEHwtqdMbFGxJmTIfrAbPfA = -1;
							goto IL_01a9;
						}
						IL_00ad:
						if (pYZQTwAjdJPUvBXrAOvNOjdMVCyI.MoveNext())
						{
							ElementAssignmentConflictInfo current = pYZQTwAjdJPUvBXrAOvNOjdMVCyI.Current;
							sNrfunDCJtLeoHPJtVkVLgzUzCsy = current;
							GuQUyvEEHwtqdMbFGxJmTIfrAbPfA = 1;
							return true;
						}
						ziasICNXARjUsUQEEDFhVXRlvNCw();
						pYZQTwAjdJPUvBXrAOvNOjdMVCyI = null;
						if (IilebBYPjbMGsNPsGAvQDkKCXvcN && (!jURIZkJpPGdRrznUGFdpBLwDBVcP._enabled || !lCQVrZAAkdnAPcfxlKMtKVJNVwLP.dQASdaEFVJzbOgxgKEdsYSDArFzi))
						{
							return false;
						}
						if (jURIZkJpPGdRrznUGFdpBLwDBVcP.UUHETvjEpNhDHXYwlfeLsKyNvXhAA == null)
						{
							return false;
						}
						UEdwknnwNKPnJTLSKZbumWfwHszJ = 0;
						goto IL_01bb;
						IL_01bb:
						if (UEdwknnwNKPnJTLSKZbumWfwHszJ < jURIZkJpPGdRrznUGFdpBLwDBVcP.UUHETvjEpNhDHXYwlfeLsKyNvXhAA.Count)
						{
							ActionElementMap actionElementMap = jURIZkJpPGdRrznUGFdpBLwDBVcP.UUHETvjEpNhDHXYwlfeLsKyNvXhAA[UEdwknnwNKPnJTLSKZbumWfwHszJ];
							if ((!IilebBYPjbMGsNPsGAvQDkKCXvcN || actionElementMap.dQASdaEFVJzbOgxgKEdsYSDArFzi) && actionElementMap.CheckForAssignmentConflict(lCQVrZAAkdnAPcfxlKMtKVJNVwLP))
							{
								sNrfunDCJtLeoHPJtVkVLgzUzCsy = new ElementAssignmentConflictInfo(true, ReInput.mapping.GetMapCategory(jURIZkJpPGdRrznUGFdpBLwDBVcP._categoryId).userAssignable, -1, jURIZkJpPGdRrznUGFdpBLwDBVcP._controllerType, jURIZkJpPGdRrznUGFdpBLwDBVcP._controllerId, jURIZkJpPGdRrznUGFdpBLwDBVcP._id, actionElementMap.oFUAyzlkDBdPoonWGgEIgJYWTzJOA, actionElementMap._actionId, actionElementMap._elementType, actionElementMap._elementIdentifierId, actionElementMap.keyCode, actionElementMap.modifierKeyFlags);
								GuQUyvEEHwtqdMbFGxJmTIfrAbPfA = 2;
								return true;
							}
							goto IL_01a9;
						}
						return false;
						IL_01a9:
						UEdwknnwNKPnJTLSKZbumWfwHszJ++;
						goto IL_01bb;
					}
				}
				catch
				{
					//try-fault
					((IDisposable)this).Dispose();
					throw;
				}
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			private void ziasICNXARjUsUQEEDFhVXRlvNCw()
			{
				GuQUyvEEHwtqdMbFGxJmTIfrAbPfA = -1;
				if (pYZQTwAjdJPUvBXrAOvNOjdMVCyI != null)
				{
					pYZQTwAjdJPUvBXrAOvNOjdMVCyI.Dispose();
				}
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}

			[DebuggerHidden]
			IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
			{
				xeDoawbHnvkUINIIzVvtWOhboEvp xeDoawbHnvkUINIIzVvtWOhboEvp2;
				if (GuQUyvEEHwtqdMbFGxJmTIfrAbPfA == -2 && nufAtLiLYcOmYXdNiavxYSyrwNchA == Environment.CurrentManagedThreadId)
				{
					GuQUyvEEHwtqdMbFGxJmTIfrAbPfA = 0;
					xeDoawbHnvkUINIIzVvtWOhboEvp2 = this;
				}
				else
				{
					xeDoawbHnvkUINIIzVvtWOhboEvp2 = new xeDoawbHnvkUINIIzVvtWOhboEvp(0);
					xeDoawbHnvkUINIIzVvtWOhboEvp2.JURIZkJpPGdRrznUGFdpBLwDBVcP = JURIZkJpPGdRrznUGFdpBLwDBVcP;
				}
				xeDoawbHnvkUINIIzVvtWOhboEvp2.lCQVrZAAkdnAPcfxlKMtKVJNVwLP = XDCxDgmOgeNmyNJuqSjyEPDTlwGi;
				xeDoawbHnvkUINIIzVvtWOhboEvp2.IilebBYPjbMGsNPsGAvQDkKCXvcN = OUoIaPvcxyrJJbRGeGyCEBoXsTYm;
				return xeDoawbHnvkUINIIzVvtWOhboEvp2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
			}
		}

		private sealed class BAeWboZbOUNRsjJkZBxOyBaVDueq : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
		{
			private int ZIQyYrqtMtcLZnDfUTIFKFEwGfHcA;

			private ElementAssignmentConflictInfo KkhTTXMGPXNgtYnWhWGYQsIhvlLo;

			private int LfEqxbIJVwCkEOzcEkCVwgHRrbbc;

			public ControllerMapWithAxes cOWBFKhIcNMOzwQhjeXroBiLqTbm;

			private ElementAssignmentConflictCheck GXUCinEYQWggtQVoRkeIeelFqWLsA;

			public ElementAssignmentConflictCheck EMMOJXscppyBiAWLmGLkZTiFcuPu;

			private bool obsucJsuvmOHndSpYsbqisHeCXZv;

			public bool oqKqJOqGNOpVBVMMkaCyjHaWKDbL;

			private ElementAssignment GipbCXSrtAHHIPLoinEqTAkuhwUw;

			private IEnumerator<ElementAssignmentConflictInfo> YDjeXCooBqOemTcweHlJVTNMCjYK;

			private int ILYhszOJzXtkxFPhYKCXlptOeEtQ;

			ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return KkhTTXMGPXNgtYnWhWGYQsIhvlLo;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return KkhTTXMGPXNgtYnWhWGYQsIhvlLo;
				}
			}

			[DebuggerHidden]
			public BAeWboZbOUNRsjJkZBxOyBaVDueq(int P_0)
			{
				ZIQyYrqtMtcLZnDfUTIFKFEwGfHcA = P_0;
				LfEqxbIJVwCkEOzcEkCVwgHRrbbc = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int zIQyYrqtMtcLZnDfUTIFKFEwGfHcA = ZIQyYrqtMtcLZnDfUTIFKFEwGfHcA;
				if (zIQyYrqtMtcLZnDfUTIFKFEwGfHcA == -3 || zIQyYrqtMtcLZnDfUTIFKFEwGfHcA == 1)
				{
					try
					{
					}
					finally
					{
						DSyKYAkVKXFWJGLlBsToQHZurYtF();
					}
				}
			}

			private bool MoveNext()
			{
				try
				{
					int zIQyYrqtMtcLZnDfUTIFKFEwGfHcA = ZIQyYrqtMtcLZnDfUTIFKFEwGfHcA;
					ControllerMapWithAxes controllerMapWithAxes = cOWBFKhIcNMOzwQhjeXroBiLqTbm;
					switch (zIQyYrqtMtcLZnDfUTIFKFEwGfHcA)
					{
					default:
						return false;
					case 0:
						ZIQyYrqtMtcLZnDfUTIFKFEwGfHcA = -1;
						if (ReInput._id != controllerMapWithAxes.sIwyLhKUWykANTFJFXecFgCmwcwn)
						{
							ReInput.CheckInitialized(controllerMapWithAxes.sIwyLhKUWykANTFJFXecFgCmwcwn);
							return false;
						}
						YDjeXCooBqOemTcweHlJVTNMCjYK = ((ControllerMap)controllerMapWithAxes).ElementAssignmentConflicts(GXUCinEYQWggtQVoRkeIeelFqWLsA, obsucJsuvmOHndSpYsbqisHeCXZv).GetEnumerator();
						ZIQyYrqtMtcLZnDfUTIFKFEwGfHcA = -3;
						goto IL_009e;
					case 1:
						ZIQyYrqtMtcLZnDfUTIFKFEwGfHcA = -3;
						goto IL_009e;
					case 2:
						{
							ZIQyYrqtMtcLZnDfUTIFKFEwGfHcA = -1;
							goto IL_01b5;
						}
						IL_01c7:
						if (ILYhszOJzXtkxFPhYKCXlptOeEtQ < controllerMapWithAxes.UUHETvjEpNhDHXYwlfeLsKyNvXhAA.Count)
						{
							ActionElementMap actionElementMap = controllerMapWithAxes.UUHETvjEpNhDHXYwlfeLsKyNvXhAA[ILYhszOJzXtkxFPhYKCXlptOeEtQ];
							if ((!obsucJsuvmOHndSpYsbqisHeCXZv || actionElementMap.dQASdaEFVJzbOgxgKEdsYSDArFzi) && actionElementMap.oFUAyzlkDBdPoonWGgEIgJYWTzJOA != GXUCinEYQWggtQVoRkeIeelFqWLsA.elementMapId && actionElementMap.CheckForAssignmentConflict(GipbCXSrtAHHIPLoinEqTAkuhwUw))
							{
								KkhTTXMGPXNgtYnWhWGYQsIhvlLo = new ElementAssignmentConflictInfo(true, ReInput.mapping.GetMapCategory(controllerMapWithAxes._categoryId).userAssignable, -1, controllerMapWithAxes._controllerType, controllerMapWithAxes._controllerId, controllerMapWithAxes._id, actionElementMap.oFUAyzlkDBdPoonWGgEIgJYWTzJOA, actionElementMap._actionId, actionElementMap._elementType, actionElementMap._elementIdentifierId, actionElementMap.keyCode, actionElementMap.modifierKeyFlags);
								ZIQyYrqtMtcLZnDfUTIFKFEwGfHcA = 2;
								return true;
							}
							goto IL_01b5;
						}
						return false;
						IL_009e:
						if (YDjeXCooBqOemTcweHlJVTNMCjYK.MoveNext())
						{
							ElementAssignmentConflictInfo current = YDjeXCooBqOemTcweHlJVTNMCjYK.Current;
							KkhTTXMGPXNgtYnWhWGYQsIhvlLo = current;
							ZIQyYrqtMtcLZnDfUTIFKFEwGfHcA = 1;
							return true;
						}
						DSyKYAkVKXFWJGLlBsToQHZurYtF();
						YDjeXCooBqOemTcweHlJVTNMCjYK = null;
						if (obsucJsuvmOHndSpYsbqisHeCXZv && !controllerMapWithAxes._enabled)
						{
							return false;
						}
						if (controllerMapWithAxes.UUHETvjEpNhDHXYwlfeLsKyNvXhAA == null)
						{
							return false;
						}
						GipbCXSrtAHHIPLoinEqTAkuhwUw = GXUCinEYQWggtQVoRkeIeelFqWLsA.ToElementAssignment();
						ILYhszOJzXtkxFPhYKCXlptOeEtQ = 0;
						goto IL_01c7;
						IL_01b5:
						ILYhszOJzXtkxFPhYKCXlptOeEtQ++;
						goto IL_01c7;
					}
				}
				catch
				{
					//try-fault
					((IDisposable)this).Dispose();
					throw;
				}
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			private void DSyKYAkVKXFWJGLlBsToQHZurYtF()
			{
				ZIQyYrqtMtcLZnDfUTIFKFEwGfHcA = -1;
				if (YDjeXCooBqOemTcweHlJVTNMCjYK != null)
				{
					YDjeXCooBqOemTcweHlJVTNMCjYK.Dispose();
				}
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}

			[DebuggerHidden]
			IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
			{
				BAeWboZbOUNRsjJkZBxOyBaVDueq bAeWboZbOUNRsjJkZBxOyBaVDueq;
				if (ZIQyYrqtMtcLZnDfUTIFKFEwGfHcA == -2 && LfEqxbIJVwCkEOzcEkCVwgHRrbbc == Environment.CurrentManagedThreadId)
				{
					ZIQyYrqtMtcLZnDfUTIFKFEwGfHcA = 0;
					bAeWboZbOUNRsjJkZBxOyBaVDueq = this;
				}
				else
				{
					bAeWboZbOUNRsjJkZBxOyBaVDueq = new BAeWboZbOUNRsjJkZBxOyBaVDueq(0);
					bAeWboZbOUNRsjJkZBxOyBaVDueq.cOWBFKhIcNMOzwQhjeXroBiLqTbm = cOWBFKhIcNMOzwQhjeXroBiLqTbm;
				}
				bAeWboZbOUNRsjJkZBxOyBaVDueq.GXUCinEYQWggtQVoRkeIeelFqWLsA = EMMOJXscppyBiAWLmGLkZTiFcuPu;
				bAeWboZbOUNRsjJkZBxOyBaVDueq.obsucJsuvmOHndSpYsbqisHeCXZv = oqKqJOqGNOpVBVMMkaCyjHaWKDbL;
				return bAeWboZbOUNRsjJkZBxOyBaVDueq;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
			}
		}

		private readonly IList<ActionElementMap> UUHETvjEpNhDHXYwlfeLsKyNvXhAA;

		private readonly ReadOnlyCollection<ActionElementMap> obXTfAsqYoETRwEJoFcgEsdFnXGmA;

		public int axisMapCount
		{
			get
			{
				if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
				{
					ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
					return 0;
				}
				if (UUHETvjEpNhDHXYwlfeLsKyNvXhAA == null)
				{
					return 0;
				}
				return UUHETvjEpNhDHXYwlfeLsKyNvXhAA.Count;
			}
		}

		public IList<ActionElementMap> AxisMaps
		{
			get
			{
				if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
				{
					ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
					return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
				}
				return obXTfAsqYoETRwEJoFcgEsdFnXGmA;
			}
		}

		internal AList<ActionElementMap> gnACjIDiJtzVNBgxjZoHVTGsGgGKA => (AList<ActionElementMap>)UUHETvjEpNhDHXYwlfeLsKyNvXhAA;

		public ControllerMapWithAxes()
		{
			UUHETvjEpNhDHXYwlfeLsKyNvXhAA = new AList<ActionElementMap>();
			obXTfAsqYoETRwEJoFcgEsdFnXGmA = new ReadOnlyCollection<ActionElementMap>(UUHETvjEpNhDHXYwlfeLsKyNvXhAA);
		}

		public ControllerMapWithAxes(ControllerMapWithAxes P_0)
			: base(P_0)
		{
			UUHETvjEpNhDHXYwlfeLsKyNvXhAA = new AList<ActionElementMap>();
			obXTfAsqYoETRwEJoFcgEsdFnXGmA = new ReadOnlyCollection<ActionElementMap>(UUHETvjEpNhDHXYwlfeLsKyNvXhAA);
			if (P_0.UUHETvjEpNhDHXYwlfeLsKyNvXhAA != null)
			{
				int count = P_0.UUHETvjEpNhDHXYwlfeLsKyNvXhAA.Count;
				for (int i = 0; i < count; i++)
				{
					GJbeSVeWLxbsvqziWKnBEkoWQAGx(new ActionElementMap(P_0.UUHETvjEpNhDHXYwlfeLsKyNvXhAA[i]));
				}
			}
		}

		public override bool ContainsAction(int actionId)
		{
			if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
			{
				ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
				return false;
			}
			if (base.ContainsAction(actionId))
			{
				return true;
			}
			if (UUHETvjEpNhDHXYwlfeLsKyNvXhAA == null)
			{
				return false;
			}
			int count = UUHETvjEpNhDHXYwlfeLsKyNvXhAA.Count;
			for (int i = 0; i < count; i++)
			{
				if (UUHETvjEpNhDHXYwlfeLsKyNvXhAA[i]._actionId == actionId)
				{
					return true;
				}
			}
			return false;
		}

		public override bool CreateElementMap(int actionId, Pole axisContribution, int elementIdentifierId, ControllerElementType elementType, AxisRange axisRange, bool invert, out ActionElementMap result)
		{
			if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
			{
				ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
				result = null;
				return false;
			}
			if (base.CreateElementMap(actionId, axisContribution, elementIdentifierId, elementType, axisRange, invert, out result))
			{
				return true;
			}
			if (!ZCLDIeeEtllVdAmNJjijFCYWVDGlb(elementType))
			{
				return false;
			}
			ActionElementMap actionElementMap = new ActionElementMap(actionId, elementType, elementIdentifierId, axisContribution, axisRange, invert);
			BakeElementMap(actionElementMap);
			GJbeSVeWLxbsvqziWKnBEkoWQAGx(actionElementMap);
			result = actionElementMap;
			return true;
		}

		public override bool ReplaceElementMap(int elementMapId, int actionId, Pole axisContribution, int elementIdentifierId, ControllerElementType elementType, AxisRange axisRange, bool invert, out ActionElementMap result)
		{
			if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
			{
				ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
				result = null;
				return false;
			}
			if (base.ReplaceElementMap(elementMapId, actionId, axisContribution, elementIdentifierId, elementType, axisRange, invert, out result))
			{
				return true;
			}
			if (!ZCLDIeeEtllVdAmNJjijFCYWVDGlb(elementType))
			{
				return false;
			}
			ActionElementMap elementMap = GetElementMap(elementMapId);
			if (elementMap == null)
			{
				return false;
			}
			if (!ZCLDIeeEtllVdAmNJjijFCYWVDGlb(elementMap._elementType))
			{
				DeleteElementMap(elementMapId);
				elementMap._elementType = ControllerElementType.Axis;
				GJbeSVeWLxbsvqziWKnBEkoWQAGx(elementMap);
			}
			if (PeZstnRltpbseXYEoxzgcgjSaFfm(elementMapId) < 0)
			{
				return false;
			}
			ControllerMap.OAEjdeCzQqxOtbOqaiobZETGzJNH(elementMap, actionId, axisContribution, elementIdentifierId, elementType, axisRange, invert);
			BakeElementMap(elementMap);
			result = elementMap;
			return true;
		}

		public override bool DeleteElementMap(int elementMapId)
		{
			if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
			{
				ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
				return false;
			}
			if (base.DeleteElementMap(elementMapId))
			{
				return true;
			}
			int num = PeZstnRltpbseXYEoxzgcgjSaFfm(elementMapId);
			if (num < 0)
			{
				return false;
			}
			ywJKNgBowWIXlhORKwHtDXBinDyJ(elementMapId, num);
			return true;
		}

		public override bool DeleteElementMapsWithAction(string actionName)
		{
			if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
			{
				ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
				return false;
			}
			return DeleteElementMapsWithAction(ReInput.xKokvIxOzcvermvcSUcNKZIGamDS.rnRgZqWgdruGSKkLVaIxIODNYhyJA(actionName));
		}

		public override bool DeleteElementMapsWithAction(int actionId)
		{
			if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
			{
				ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
				return false;
			}
			return base.DeleteElementMapsWithAction(actionId) | DeleteAxisMapsWithAction(actionId);
		}

		public override ActionElementMap GetElementMap(int elementMapId)
		{
			if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
			{
				ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
				return null;
			}
			ActionElementMap elementMap = base.GetElementMap(elementMapId);
			if (elementMap != null)
			{
				return elementMap;
			}
			if (UUHETvjEpNhDHXYwlfeLsKyNvXhAA == null)
			{
				return null;
			}
			int count = UUHETvjEpNhDHXYwlfeLsKyNvXhAA.Count;
			for (int i = 0; i < count; i++)
			{
				if (UUHETvjEpNhDHXYwlfeLsKyNvXhAA[i].oFUAyzlkDBdPoonWGgEIgJYWTzJOA == elementMapId)
				{
					return UUHETvjEpNhDHXYwlfeLsKyNvXhAA[i];
				}
			}
			return null;
		}

		public override ActionElementMap GetFirstElementMapWithAction(int actionId)
		{
			return GetFirstElementMapWithAction(actionId, skipDisabledMaps: false);
		}

		public override ActionElementMap GetFirstElementMapWithAction(int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
			{
				ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
				return null;
			}
			if (actionId < 0)
			{
				return null;
			}
			ActionElementMap firstElementMapWithAction = base.GetFirstElementMapWithAction(actionId, skipDisabledMaps);
			if (firstElementMapWithAction != null)
			{
				return firstElementMapWithAction;
			}
			int count = UUHETvjEpNhDHXYwlfeLsKyNvXhAA.Count;
			for (int i = 0; i < count; i++)
			{
				ActionElementMap actionElementMap = UUHETvjEpNhDHXYwlfeLsKyNvXhAA[i];
				if (actionElementMap._actionId == actionId && (!skipDisabledMaps || actionElementMap.dQASdaEFVJzbOgxgKEdsYSDArFzi))
				{
					return actionElementMap;
				}
			}
			return null;
		}

		internal virtual ActionElementMap RedFcscCMENMbhZACbSujgNtLwNYA(Predicate<ActionElementMap> P_0, bool P_1)
		{
			ActionElementMap actionElementMap = base.qAPFJyhkBScmgnBBqlDdXpxMklPt(P_0, P_1);
			if (actionElementMap != null)
			{
				return actionElementMap;
			}
			return jSvEqBbykSBkDqaCuhNWoeNoxmxpA(P_0, P_1);
		}

		internal virtual int QOLUcCfzuQlrufoXwenXucoUKhzF(Predicate<ActionElementMap> P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			return base.cFulEPyEyuvDaKDZVGFiRtAbJTCy(P_0, P_1, P_2, P_3) + mrUqpQMFwygGEfOtSDGaKAgDrbSt(P_0, P_1, P_2, true);
		}

		public override void ClearElementMaps()
		{
			if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
			{
				ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
				return;
			}
			base.ClearElementMaps();
			UUHETvjEpNhDHXYwlfeLsKyNvXhAA.Clear();
		}

		public ActionElementMap GetAxisMap(int index)
		{
			if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
			{
				ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
				return null;
			}
			if (UUHETvjEpNhDHXYwlfeLsKyNvXhAA == null || index < 0 || index >= UUHETvjEpNhDHXYwlfeLsKyNvXhAA.Count)
			{
				return null;
			}
			return UUHETvjEpNhDHXYwlfeLsKyNvXhAA[index];
		}

		public ActionElementMap[] GetAxisMaps()
		{
			if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
			{
				ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
				return EmptyObjects<ActionElementMap>.array;
			}
			return GetAxisMaps(skipDisabledMaps: false);
		}

		public ActionElementMap[] GetAxisMaps(bool skipDisabledMaps)
		{
			if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
			{
				ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
				return EmptyObjects<ActionElementMap>.array;
			}
			if (!skipDisabledMaps)
			{
				return ListTools.ToArray(UUHETvjEpNhDHXYwlfeLsKyNvXhAA);
			}
			int num = axisMapCount;
			List<ActionElementMap> list = new List<ActionElementMap>(num);
			for (int i = 0; i < num; i++)
			{
				ActionElementMap actionElementMap = UUHETvjEpNhDHXYwlfeLsKyNvXhAA[i];
				if (actionElementMap.dQASdaEFVJzbOgxgKEdsYSDArFzi)
				{
					list.Add(actionElementMap);
				}
			}
			return list.ToArray();
		}

		public int GetAxisMaps(bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
			{
				ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
				return 0;
			}
			return hAgoMPNtxizBUFOmLfFgbgUmjJRi(skipDisabledMaps, results, false);
		}

		public ActionElementMap[] GetAxisMapsWithAction(string actionName)
		{
			if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
			{
				ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
				return EmptyObjects<ActionElementMap>.array;
			}
			InputAction inputAction = ReInput.xKokvIxOzcvermvcSUcNKZIGamDS.QKCYqwFmItpkITKiPWYYxsvfwMVD(actionName, true);
			if (inputAction == null)
			{
				return EmptyObjects<ActionElementMap>.array;
			}
			return GetAxisMapsWithAction(inputAction.id);
		}

		public ActionElementMap[] GetAxisMapsWithAction(int actionId)
		{
			return GetAxisMapsWithAction(actionId, skipDisabledMaps: false);
		}

		public ActionElementMap[] GetAxisMapsWithAction(string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
			{
				ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
				return EmptyObjects<ActionElementMap>.array;
			}
			InputAction inputAction = ReInput.xKokvIxOzcvermvcSUcNKZIGamDS.QKCYqwFmItpkITKiPWYYxsvfwMVD(actionName, true);
			if (inputAction == null)
			{
				return EmptyObjects<ActionElementMap>.array;
			}
			return GetAxisMapsWithAction(inputAction.id, skipDisabledMaps);
		}

		public ActionElementMap[] GetAxisMapsWithAction(int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
			{
				ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
				return EmptyObjects<ActionElementMap>.array;
			}
			if (actionId < 0)
			{
				return EmptyObjects<ActionElementMap>.array;
			}
			int num = axisMapCount;
			if (num == 0)
			{
				return EmptyObjects<ActionElementMap>.array;
			}
			int num2 = 0;
			for (int i = 0; i < num; i++)
			{
				ActionElementMap actionElementMap = UUHETvjEpNhDHXYwlfeLsKyNvXhAA[i];
				if (actionElementMap._actionId == actionId && (!skipDisabledMaps || actionElementMap.dQASdaEFVJzbOgxgKEdsYSDArFzi))
				{
					num2++;
				}
			}
			if (num2 == 0)
			{
				return EmptyObjects<ActionElementMap>.array;
			}
			ActionElementMap[] array = new ActionElementMap[num2];
			int num3 = 0;
			for (int j = 0; j < num; j++)
			{
				ActionElementMap actionElementMap2 = UUHETvjEpNhDHXYwlfeLsKyNvXhAA[j];
				if (actionElementMap2._actionId == actionId && (!skipDisabledMaps || actionElementMap2.dQASdaEFVJzbOgxgKEdsYSDArFzi))
				{
					array[num3] = actionElementMap2;
					num3++;
				}
			}
			return array;
		}

		public int GetAxisMapsWithAction(string actionName, List<ActionElementMap> results)
		{
			if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
			{
				ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
				return 0;
			}
			InputAction inputAction = ReInput.xKokvIxOzcvermvcSUcNKZIGamDS.QKCYqwFmItpkITKiPWYYxsvfwMVD(actionName, true);
			if (inputAction == null)
			{
				ListTools.TryClear(results);
				return 0;
			}
			return GetAxisMapsWithAction(inputAction.id, results);
		}

		public int GetAxisMapsWithAction(int actionId, List<ActionElementMap> results)
		{
			return GetAxisMapsWithAction(actionId, skipDisabledMaps: false, results);
		}

		public int GetAxisMapsWithAction(string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
			{
				ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
				return 0;
			}
			InputAction inputAction = ReInput.xKokvIxOzcvermvcSUcNKZIGamDS.QKCYqwFmItpkITKiPWYYxsvfwMVD(actionName, true);
			if (inputAction == null)
			{
				ListTools.TryClear(results);
				return 0;
			}
			return GetAxisMapsWithAction(inputAction.id, skipDisabledMaps, results);
		}

		public int GetAxisMapsWithAction(int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
			{
				ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
				return 0;
			}
			return UPErmvGxbaexRBBoUJNfdGoesNwy(actionId, skipDisabledMaps, results, false);
		}

		public IEnumerable<ActionElementMap> AxisMapsWithAction(string actionName)
		{
			if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
			{
				ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			int actionId = ReInput.xKokvIxOzcvermvcSUcNKZIGamDS.rnRgZqWgdruGSKkLVaIxIODNYhyJA(actionName);
			return AxisMapsWithAction(actionId);
		}

		public IEnumerable<ActionElementMap> AxisMapsWithAction(int actionId)
		{
			return AxisMapsWithAction(actionId, skipDisabledMaps: false);
		}

		public IEnumerable<ActionElementMap> AxisMapsWithAction(string actionName, bool skipDisabledMaps)
		{
			int actionId = ReInput.xKokvIxOzcvermvcSUcNKZIGamDS.rnRgZqWgdruGSKkLVaIxIODNYhyJA(actionName);
			return AxisMapsWithAction(actionId, skipDisabledMaps);
		}

		[IteratorStateMachine(typeof(kdLRwNXINhTutvQCBFAiEEzuMdfC))]
		public IEnumerable<ActionElementMap> AxisMapsWithAction(int actionId, bool skipDisabledMaps)
		{
			return new kdLRwNXINhTutvQCBFAiEEzuMdfC(-2)
			{
				znaGTXraZwVqExUNzaymKeloykKH = this,
				bTSBdkeMztjcKDgCBdvoewWQoohy = actionId,
				pFwUkUREtwMJuxyIeglHJuVqsgnp = skipDisabledMaps
			};
		}

		public ActionElementMap GetFirstAxisMapWithAction(int actionId)
		{
			if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
			{
				ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
				return null;
			}
			return GetFirstAxisMapWithAction(actionId, skipDisabledMaps: false);
		}

		public ActionElementMap GetFirstAxisMapWithAction(string actionName)
		{
			if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
			{
				ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
				return null;
			}
			int actionId = ReInput.xKokvIxOzcvermvcSUcNKZIGamDS.rnRgZqWgdruGSKkLVaIxIODNYhyJA(actionName);
			return GetFirstAxisMapWithAction(actionId);
		}

		public ActionElementMap GetFirstAxisMapWithAction(int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
			{
				ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
				return null;
			}
			if (actionId < 0)
			{
				return null;
			}
			IList<ActionElementMap> axisMaps = AxisMaps;
			int count = axisMaps.Count;
			for (int i = 0; i < count; i++)
			{
				ActionElementMap actionElementMap = axisMaps[i];
				if (actionElementMap._actionId == actionId && (!skipDisabledMaps || actionElementMap.dQASdaEFVJzbOgxgKEdsYSDArFzi))
				{
					return actionElementMap;
				}
			}
			return null;
		}

		public ActionElementMap GetFirstAxisMapWithAction(string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
			{
				ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
				return null;
			}
			int actionId = ReInput.xKokvIxOzcvermvcSUcNKZIGamDS.rnRgZqWgdruGSKkLVaIxIODNYhyJA(actionName);
			return GetFirstAxisMapWithAction(actionId, skipDisabledMaps);
		}

		public ActionElementMap GetFirstAxisMapMatch(Predicate<ActionElementMap> predicate)
		{
			if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
			{
				ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
				return null;
			}
			return jSvEqBbykSBkDqaCuhNWoeNoxmxpA(predicate, false);
		}

		internal ActionElementMap jSvEqBbykSBkDqaCuhNWoeNoxmxpA(Predicate<ActionElementMap> P_0, bool P_1)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("predicate");
			}
			IList<ActionElementMap> axisMaps = AxisMaps;
			int num = axisMapCount;
			try
			{
				for (int i = 0; i < num; i++)
				{
					ActionElementMap actionElementMap = axisMaps[i];
					if ((!P_1 || actionElementMap.enabled) && P_0(actionElementMap))
					{
						return actionElementMap;
					}
				}
			}
			catch (Exception exception)
			{
				ReInput.HandleCallbackException("ControllerMap.GetFirstAxisMapMatch", exception);
			}
			return null;
		}

		public int GetAxisMapMatches(Predicate<ActionElementMap> predicate, List<ActionElementMap> results)
		{
			if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
			{
				ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
				return 0;
			}
			return mrUqpQMFwygGEfOtSDGaKAgDrbSt(predicate, false, results, false);
		}

		internal int mrUqpQMFwygGEfOtSDGaKAgDrbSt(Predicate<ActionElementMap> P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("predicate");
			}
			if (P_2 == null)
			{
				throw new ArgumentNullException("results");
			}
			int num = 0;
			if (!P_3)
			{
				P_2.Clear();
			}
			else
			{
				num = P_2.Count;
			}
			IList<ActionElementMap> axisMaps = AxisMaps;
			int num2 = axisMapCount;
			try
			{
				for (int i = 0; i < num2; i++)
				{
					ActionElementMap actionElementMap = axisMaps[i];
					if ((!P_1 || actionElementMap.enabled) && P_0(actionElementMap))
					{
						P_2.Add(actionElementMap);
					}
				}
			}
			catch (Exception exception)
			{
				ReInput.HandleCallbackException("ControllerMap.GetAxisMapMatches", exception);
			}
			return P_2.Count - num;
		}

		public void ForEachAxisMapMatch(Predicate<ActionElementMap> predicate, Action<ActionElementMap> actionToPerform)
		{
			if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
			{
				ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
				return;
			}
			if (predicate == null)
			{
				throw new ArgumentNullException("predicate");
			}
			if (actionToPerform == null)
			{
				throw new ArgumentNullException("actionToPerform");
			}
			int count = UUHETvjEpNhDHXYwlfeLsKyNvXhAA.Count;
			try
			{
				for (int i = 0; i < count; i++)
				{
					ActionElementMap obj = UUHETvjEpNhDHXYwlfeLsKyNvXhAA[i];
					if (predicate(obj))
					{
						actionToPerform(obj);
					}
				}
			}
			catch (Exception exception)
			{
				ReInput.HandleCallbackException("ControllerMap.ForEachAxisMapMatch", exception);
			}
		}

		public bool DeleteAxisMapsWithAction(string actionName)
		{
			return DeleteAxisMapsWithAction(ReInput.xKokvIxOzcvermvcSUcNKZIGamDS.rnRgZqWgdruGSKkLVaIxIODNYhyJA(actionName));
		}

		public bool DeleteAxisMapsWithAction(int actionId)
		{
			if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
			{
				ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
				return false;
			}
			if (actionId < 0)
			{
				return false;
			}
			int num = axisMapCount;
			if (num == 0)
			{
				return false;
			}
			bool result = false;
			for (int num2 = num - 1; num2 >= 0; num2--)
			{
				if (UUHETvjEpNhDHXYwlfeLsKyNvXhAA[num2] != null && UUHETvjEpNhDHXYwlfeLsKyNvXhAA[num2]._actionId == actionId)
				{
					ywJKNgBowWIXlhORKwHtDXBinDyJ(UUHETvjEpNhDHXYwlfeLsKyNvXhAA[num2].oFUAyzlkDBdPoonWGgEIgJYWTzJOA, num2);
					result = true;
				}
			}
			return result;
		}

		public int SetAllAxisMapsEnabled(bool state)
		{
			if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
			{
				ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
				return 0;
			}
			int num = 0;
			int count = UUHETvjEpNhDHXYwlfeLsKyNvXhAA.Count;
			for (int i = 0; i < count; i++)
			{
				ActionElementMap actionElementMap = UUHETvjEpNhDHXYwlfeLsKyNvXhAA[i];
				if (actionElementMap.dQASdaEFVJzbOgxgKEdsYSDArFzi != state)
				{
					actionElementMap.dQASdaEFVJzbOgxgKEdsYSDArFzi = state;
					num++;
				}
			}
			return num;
		}

		public override bool DoesElementAssignmentConflict(ControllerMap controllerMap, bool skipDisabledMaps)
		{
			if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
			{
				ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
				return false;
			}
			if (controllerMap == null)
			{
				return false;
			}
			if (base.DoesElementAssignmentConflict(controllerMap, skipDisabledMaps))
			{
				return true;
			}
			if (!(controllerMap is ControllerMapWithAxes controllerMapWithAxes))
			{
				return false;
			}
			if (skipDisabledMaps && (!_enabled || !controllerMapWithAxes._enabled))
			{
				return false;
			}
			if (UUHETvjEpNhDHXYwlfeLsKyNvXhAA == null)
			{
				return false;
			}
			IList<ActionElementMap> axisMaps = controllerMapWithAxes.AxisMaps;
			if (axisMaps == null)
			{
				return false;
			}
			int count = UUHETvjEpNhDHXYwlfeLsKyNvXhAA.Count;
			int count2 = axisMaps.Count;
			for (int i = 0; i < count; i++)
			{
				ActionElementMap actionElementMap = UUHETvjEpNhDHXYwlfeLsKyNvXhAA[i];
				if (skipDisabledMaps && !actionElementMap.dQASdaEFVJzbOgxgKEdsYSDArFzi)
				{
					continue;
				}
				for (int j = 0; j < count2; j++)
				{
					ActionElementMap actionElementMap2 = axisMaps[j];
					if ((!skipDisabledMaps || actionElementMap2.dQASdaEFVJzbOgxgKEdsYSDArFzi) && actionElementMap.CheckForAssignmentConflict(actionElementMap2))
					{
						return true;
					}
				}
			}
			return false;
		}

		public override bool DoesElementAssignmentConflict(ActionElementMap actionElementMap, bool skipDisabledMaps)
		{
			if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
			{
				ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
				return false;
			}
			if (actionElementMap == null)
			{
				return false;
			}
			if (base.DoesElementAssignmentConflict(actionElementMap, skipDisabledMaps))
			{
				return true;
			}
			if (skipDisabledMaps && (!_enabled || !actionElementMap.dQASdaEFVJzbOgxgKEdsYSDArFzi))
			{
				return false;
			}
			if (UUHETvjEpNhDHXYwlfeLsKyNvXhAA == null)
			{
				return false;
			}
			for (int i = 0; i < UUHETvjEpNhDHXYwlfeLsKyNvXhAA.Count; i++)
			{
				ActionElementMap actionElementMap2 = UUHETvjEpNhDHXYwlfeLsKyNvXhAA[i];
				if ((!skipDisabledMaps || actionElementMap2.dQASdaEFVJzbOgxgKEdsYSDArFzi) && actionElementMap2.CheckForAssignmentConflict(actionElementMap))
				{
					return true;
				}
			}
			return false;
		}

		public override bool DoesElementAssignmentConflict(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
		{
			if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
			{
				ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
				return false;
			}
			if (base.DoesElementAssignmentConflict(conflictCheck, skipDisabledMaps))
			{
				return true;
			}
			if (skipDisabledMaps && !_enabled)
			{
				return false;
			}
			if (conflictCheck.elementAssignmentType != ElementAssignmentType.FullAxis && conflictCheck.elementAssignmentType != ElementAssignmentType.SplitAxis)
			{
				return false;
			}
			if (UUHETvjEpNhDHXYwlfeLsKyNvXhAA == null)
			{
				return false;
			}
			ElementAssignment elementAssignment = conflictCheck.ToElementAssignment();
			for (int i = 0; i < UUHETvjEpNhDHXYwlfeLsKyNvXhAA.Count; i++)
			{
				ActionElementMap actionElementMap = UUHETvjEpNhDHXYwlfeLsKyNvXhAA[i];
				if ((!skipDisabledMaps || actionElementMap.dQASdaEFVJzbOgxgKEdsYSDArFzi) && actionElementMap.oFUAyzlkDBdPoonWGgEIgJYWTzJOA != conflictCheck.elementMapId && actionElementMap.CheckForAssignmentConflict(elementAssignment))
				{
					return true;
				}
			}
			return false;
		}

		[IteratorStateMachine(typeof(qtAxUFdaJcdudxhnYYuwEnkpHfYL))]
		public override IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ControllerMap controllerMap, bool skipDisabledMaps)
		{
			return new qtAxUFdaJcdudxhnYYuwEnkpHfYL(-2)
			{
				oEYIaSuHsFycKSDdAARnqUrRJRpU = this,
				bgwwqrDcZlyMLJiqBdvScPrKXraNA = controllerMap,
				LDmGKtbVyWdOSMtPzRKnrLFJqPtU = skipDisabledMaps
			};
		}

		[IteratorStateMachine(typeof(xeDoawbHnvkUINIIzVvtWOhboEvp))]
		public override IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ActionElementMap actionElementMap, bool skipDisabledMaps)
		{
			return new xeDoawbHnvkUINIIzVvtWOhboEvp(-2)
			{
				JURIZkJpPGdRrznUGFdpBLwDBVcP = this,
				XDCxDgmOgeNmyNJuqSjyEPDTlwGi = actionElementMap,
				OUoIaPvcxyrJJbRGeGyCEBoXsTYm = skipDisabledMaps
			};
		}

		[IteratorStateMachine(typeof(BAeWboZbOUNRsjJkZBxOyBaVDueq))]
		public override IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
		{
			return new BAeWboZbOUNRsjJkZBxOyBaVDueq(-2)
			{
				cOWBFKhIcNMOzwQhjeXroBiLqTbm = this,
				EMMOJXscppyBiAWLmGLkZTiFcuPu = conflictCheck,
				oqKqJOqGNOpVBVMMkaCyjHaWKDbL = skipDisabledMaps
			};
		}

		public override int RemoveElementAssignmentConflicts(ControllerMap controllerMap, bool skipDisabledMaps)
		{
			if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
			{
				ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
				return 0;
			}
			if (controllerMap == null)
			{
				return 0;
			}
			int num = base.RemoveElementAssignmentConflicts(controllerMap, skipDisabledMaps);
			if (!(controllerMap is ControllerMapWithAxes controllerMapWithAxes))
			{
				return num;
			}
			if (skipDisabledMaps && (!_enabled || !controllerMapWithAxes._enabled))
			{
				return num;
			}
			if (UUHETvjEpNhDHXYwlfeLsKyNvXhAA == null)
			{
				return num;
			}
			IList<ActionElementMap> axisMaps = controllerMapWithAxes.AxisMaps;
			if (axisMaps == null)
			{
				return num;
			}
			InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(_categoryId);
			if (mapCategory != null && !mapCategory.userAssignable)
			{
				return num;
			}
			_ = UUHETvjEpNhDHXYwlfeLsKyNvXhAA.Count;
			int count = axisMaps.Count;
			for (int num2 = UUHETvjEpNhDHXYwlfeLsKyNvXhAA.Count - 1; num2 >= 0; num2--)
			{
				ActionElementMap actionElementMap = UUHETvjEpNhDHXYwlfeLsKyNvXhAA[num2];
				if (!skipDisabledMaps || actionElementMap.dQASdaEFVJzbOgxgKEdsYSDArFzi)
				{
					for (int i = 0; i < count; i++)
					{
						ActionElementMap actionElementMap2 = axisMaps[i];
						if ((!skipDisabledMaps || actionElementMap2.dQASdaEFVJzbOgxgKEdsYSDArFzi) && actionElementMap.CheckForAssignmentConflict(actionElementMap2))
						{
							ywJKNgBowWIXlhORKwHtDXBinDyJ(actionElementMap.oFUAyzlkDBdPoonWGgEIgJYWTzJOA, num2);
							num++;
							break;
						}
					}
				}
			}
			return num;
		}

		public override int RemoveElementAssignmentConflicts(ActionElementMap actionElementMap, bool skipDisabledMaps)
		{
			if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
			{
				ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
				return 0;
			}
			if (actionElementMap == null)
			{
				return 0;
			}
			int num = base.RemoveElementAssignmentConflicts(actionElementMap, skipDisabledMaps);
			if (skipDisabledMaps && (!_enabled || !actionElementMap.dQASdaEFVJzbOgxgKEdsYSDArFzi))
			{
				return num;
			}
			InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(_categoryId);
			if (mapCategory == null)
			{
				return num;
			}
			if (!mapCategory.userAssignable)
			{
				return num;
			}
			if (UUHETvjEpNhDHXYwlfeLsKyNvXhAA == null)
			{
				return num;
			}
			for (int num2 = UUHETvjEpNhDHXYwlfeLsKyNvXhAA.Count - 1; num2 >= 0; num2--)
			{
				ActionElementMap actionElementMap2 = UUHETvjEpNhDHXYwlfeLsKyNvXhAA[num2];
				if ((!skipDisabledMaps || actionElementMap2.dQASdaEFVJzbOgxgKEdsYSDArFzi) && actionElementMap2.CheckForAssignmentConflict(actionElementMap))
				{
					ywJKNgBowWIXlhORKwHtDXBinDyJ(actionElementMap2.oFUAyzlkDBdPoonWGgEIgJYWTzJOA, num2);
					num++;
				}
			}
			return num;
		}

		public override int RemoveElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
		{
			if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
			{
				ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
				return 0;
			}
			int num = base.RemoveElementAssignmentConflicts(conflictCheck, skipDisabledMaps);
			if (skipDisabledMaps && !_enabled)
			{
				return num;
			}
			if (UUHETvjEpNhDHXYwlfeLsKyNvXhAA == null)
			{
				return num;
			}
			if (conflictCheck.elementAssignmentType != ElementAssignmentType.FullAxis && conflictCheck.elementAssignmentType != ElementAssignmentType.SplitAxis)
			{
				return num;
			}
			InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(_categoryId);
			if (mapCategory == null)
			{
				return num;
			}
			if (!mapCategory.userAssignable)
			{
				return num;
			}
			ElementAssignment elementAssignment = conflictCheck.ToElementAssignment();
			for (int num2 = UUHETvjEpNhDHXYwlfeLsKyNvXhAA.Count - 1; num2 >= 0; num2--)
			{
				ActionElementMap actionElementMap = UUHETvjEpNhDHXYwlfeLsKyNvXhAA[num2];
				if ((!skipDisabledMaps || actionElementMap.dQASdaEFVJzbOgxgKEdsYSDArFzi) && actionElementMap.oFUAyzlkDBdPoonWGgEIgJYWTzJOA != conflictCheck.elementMapId && actionElementMap.CheckForAssignmentConflict(elementAssignment))
				{
					ywJKNgBowWIXlhORKwHtDXBinDyJ(actionElementMap.oFUAyzlkDBdPoonWGgEIgJYWTzJOA, num2);
					num++;
				}
			}
			return num;
		}

		internal virtual int SUWzfRnimJxJbOUpRCcREowdAYMc(ControllerMap P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			int num = base.vktnuWxNzkftrdKLECoAFlKxxZVR(P_0, P_1, P_2, P_3);
			if (!(P_0 is ControllerMapWithAxes controllerMapWithAxes))
			{
				return num;
			}
			if (P_1 && (!_enabled || !controllerMapWithAxes._enabled))
			{
				return num;
			}
			if (UUHETvjEpNhDHXYwlfeLsKyNvXhAA == null)
			{
				return num;
			}
			IList<ActionElementMap> axisMaps = controllerMapWithAxes.AxisMaps;
			if (axisMaps == null)
			{
				return num;
			}
			InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(_categoryId);
			if (mapCategory != null && !mapCategory.userAssignable)
			{
				return num;
			}
			int count = UUHETvjEpNhDHXYwlfeLsKyNvXhAA.Count;
			int count2 = axisMaps.Count;
			for (int i = 0; i < count; i++)
			{
				ActionElementMap actionElementMap = UUHETvjEpNhDHXYwlfeLsKyNvXhAA[i];
				if (!actionElementMap.dQASdaEFVJzbOgxgKEdsYSDArFzi)
				{
					continue;
				}
				for (int j = 0; j < count2; j++)
				{
					ActionElementMap actionElementMap2 = axisMaps[j];
					if ((!P_1 || actionElementMap2.dQASdaEFVJzbOgxgKEdsYSDArFzi) && actionElementMap.CheckForAssignmentConflict(actionElementMap2))
					{
						actionElementMap.enabled = false;
						P_2?.Add(actionElementMap);
						num++;
						break;
					}
				}
			}
			return num;
		}

		internal virtual int uhAxBAwFPyCpEpMUwSiKWIlPqpJW(ActionElementMap P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			int num = base.zFYfwFdloxCUWaLFFnIoYLdVvyPiB(P_0, P_1, P_2, P_3);
			if (P_0 == null)
			{
				return num;
			}
			if (P_1 && (!_enabled || !P_0.dQASdaEFVJzbOgxgKEdsYSDArFzi))
			{
				return num;
			}
			if (P_0.elementIdentifierId < 0)
			{
				return num;
			}
			InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(_categoryId);
			if (mapCategory == null)
			{
				return num;
			}
			if (!mapCategory.userAssignable)
			{
				return num;
			}
			int num2 = axisMapCount;
			for (int i = 0; i < num2; i++)
			{
				ActionElementMap actionElementMap = UUHETvjEpNhDHXYwlfeLsKyNvXhAA[i];
				if (actionElementMap.dQASdaEFVJzbOgxgKEdsYSDArFzi && P_0.CheckForAssignmentConflict(actionElementMap))
				{
					actionElementMap.enabled = false;
					P_2?.Add(actionElementMap);
					num++;
				}
			}
			return num;
		}

		internal virtual int BhyuTUKCXamihvKjVsZWfrrkLIDT(ElementAssignmentConflictCheck P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			int num = base.RXiaSbGxTjBngXQARUXBmIjqPtfzA(P_0, P_1, P_2, P_3);
			if (P_1 && !_enabled)
			{
				return num;
			}
			if (UUHETvjEpNhDHXYwlfeLsKyNvXhAA == null)
			{
				return num;
			}
			if (P_0.elementAssignmentType != ElementAssignmentType.FullAxis && P_0.elementAssignmentType != ElementAssignmentType.SplitAxis)
			{
				return num;
			}
			InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(_categoryId);
			if (mapCategory == null)
			{
				return num;
			}
			if (!mapCategory.userAssignable)
			{
				return num;
			}
			ElementAssignment elementAssignment = P_0.ToElementAssignment();
			int count = UUHETvjEpNhDHXYwlfeLsKyNvXhAA.Count;
			for (int i = 0; i < count; i++)
			{
				ActionElementMap actionElementMap = UUHETvjEpNhDHXYwlfeLsKyNvXhAA[i];
				if (actionElementMap.dQASdaEFVJzbOgxgKEdsYSDArFzi && actionElementMap.oFUAyzlkDBdPoonWGgEIgJYWTzJOA != P_0.elementMapId && actionElementMap.CheckForAssignmentConflict(elementAssignment))
				{
					actionElementMap.enabled = false;
					P_2?.Add(actionElementMap);
					num++;
				}
			}
			return num;
		}

		public string[] GetAxisNames()
		{
			if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
			{
				ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
				return EmptyObjects<string>.array;
			}
			int num = axisMapCount;
			if (num == 0)
			{
				return null;
			}
			string[] array = new string[num];
			for (int i = 0; i < num; i++)
			{
				array[i] = UUHETvjEpNhDHXYwlfeLsKyNvXhAA[i].elementIdentifierName;
			}
			return array;
		}

		internal virtual bool ycxtmBydSSfaMByISZQAdfGvoJbz(ActionElementMap P_0)
		{
			if (base.HPOsNbYEHzjGQhSFgJFXiksNXGln(P_0))
			{
				return true;
			}
			ControllerElementType elementType = P_0._elementType;
			if (!ZCLDIeeEtllVdAmNJjijFCYWVDGlb(elementType))
			{
				return false;
			}
			GJbeSVeWLxbsvqziWKnBEkoWQAGx(P_0);
			return true;
		}

		internal virtual int KAtbjZRbqaATFnyCPcFOFbthbcIkA(List<ActionElementMap> P_0, bool P_1)
		{
			base.hdOLzuxCVTtDRXVQrCeluNkEWcfA(P_0, P_1);
			int count = P_0.Count;
			int count2 = UUHETvjEpNhDHXYwlfeLsKyNvXhAA.Count;
			for (int i = 0; i < count2; i++)
			{
				if (!P_1 || UUHETvjEpNhDHXYwlfeLsKyNvXhAA[i].dQASdaEFVJzbOgxgKEdsYSDArFzi)
				{
					P_0.Add(UUHETvjEpNhDHXYwlfeLsKyNvXhAA[i]);
				}
			}
			return P_0.Count - count;
		}

		internal virtual ActionElementMap cHzcElhAftMlkanxZMYbfjpbhUoec(int P_0, int P_1, ControllerElementType P_2)
		{
			ActionElementMap actionElementMap = base.IRBhJExjUCxVZbNMTKSCVUkomLBm(P_0, P_1, P_2);
			if (actionElementMap != null)
			{
				return actionElementMap;
			}
			if (!ZCLDIeeEtllVdAmNJjijFCYWVDGlb(P_2))
			{
				return null;
			}
			int num = cEVIvIwIzyJBJgfmfYiJPzCVAFuN(P_0, P_1, P_2);
			if (num < 0)
			{
				return null;
			}
			if (P_2 == ControllerElementType.Axis)
			{
				return UUHETvjEpNhDHXYwlfeLsKyNvXhAA[num];
			}
			throw new NotImplementedException();
		}

		internal virtual int oHRKqasSZKuVgBkUJFGkDikhTFPmA(int P_0, List<ActionElementMap> P_1, bool P_2)
		{
			if (P_1 == null)
			{
				throw new ArgumentNullException("results");
			}
			int num = (P_2 ? P_1.Count : 0);
			base.lUysouhoBRkkoKfsdAFzIiZKzOMNA(P_0, P_1, P_2);
			if (UUHETvjEpNhDHXYwlfeLsKyNvXhAA == null)
			{
				return P_1.Count - num;
			}
			int count = UUHETvjEpNhDHXYwlfeLsKyNvXhAA.Count;
			for (int i = 0; i < count; i++)
			{
				if (UUHETvjEpNhDHXYwlfeLsKyNvXhAA[i]._elementIdentifierId == P_0)
				{
					P_1.Add(UUHETvjEpNhDHXYwlfeLsKyNvXhAA[i]);
				}
			}
			return P_1.Count - num;
		}

		internal virtual bool mIoFumWsAzWYMMjgvMDgQacUtfvu(int P_0, int P_1, ControllerElementType P_2)
		{
			if (base.cDsituIeqCPBekdiLDEdgQKOpNFwA(P_0, P_1, P_2))
			{
				return true;
			}
			if (!ZCLDIeeEtllVdAmNJjijFCYWVDGlb(P_2))
			{
				return false;
			}
			if (P_2 == ControllerElementType.Axis)
			{
				int count = UUHETvjEpNhDHXYwlfeLsKyNvXhAA.Count;
				for (int i = 0; i < count; i++)
				{
					if (UUHETvjEpNhDHXYwlfeLsKyNvXhAA[i]._elementIdentifierId == P_0 && UUHETvjEpNhDHXYwlfeLsKyNvXhAA[i]._actionId == P_1)
					{
						return true;
					}
				}
				return false;
			}
			throw new NotImplementedException();
		}

		internal virtual int qfgrMdpelXyZsdOqvpPTGCmanOJW(int P_0, int P_1, ControllerElementType P_2)
		{
			int num = base.cEVIvIwIzyJBJgfmfYiJPzCVAFuN(P_0, P_1, P_2);
			if (num >= 0)
			{
				return num;
			}
			if (!ZCLDIeeEtllVdAmNJjijFCYWVDGlb(P_2))
			{
				return -1;
			}
			if (UUHETvjEpNhDHXYwlfeLsKyNvXhAA == null)
			{
				return -1;
			}
			if (P_2 == ControllerElementType.Axis)
			{
				int count = UUHETvjEpNhDHXYwlfeLsKyNvXhAA.Count;
				for (int i = 0; i < count; i++)
				{
					if (UUHETvjEpNhDHXYwlfeLsKyNvXhAA[i]._elementIdentifierId == P_0 && UUHETvjEpNhDHXYwlfeLsKyNvXhAA[i]._actionId == P_1)
					{
						return i;
					}
				}
				return -1;
			}
			throw new NotImplementedException();
		}

		internal int PeZstnRltpbseXYEoxzgcgjSaFfm(int P_0)
		{
			if (UUHETvjEpNhDHXYwlfeLsKyNvXhAA == null)
			{
				return -1;
			}
			int count = UUHETvjEpNhDHXYwlfeLsKyNvXhAA.Count;
			for (int i = 0; i < count; i++)
			{
				if (UUHETvjEpNhDHXYwlfeLsKyNvXhAA[i].oFUAyzlkDBdPoonWGgEIgJYWTzJOA == P_0)
				{
					return i;
				}
			}
			return -1;
		}

		internal int hAgoMPNtxizBUFOmLfFgbgUmjJRi(bool P_0, List<ActionElementMap> P_1, bool P_2)
		{
			if (P_1 == null)
			{
				throw new ArgumentNullException("results");
			}
			if (!P_2)
			{
				P_1.Clear();
			}
			int num = axisMapCount;
			int num2 = 0;
			for (int i = 0; i < num; i++)
			{
				ActionElementMap actionElementMap = UUHETvjEpNhDHXYwlfeLsKyNvXhAA[i];
				if (!P_0 || actionElementMap.dQASdaEFVJzbOgxgKEdsYSDArFzi)
				{
					P_1.Add(actionElementMap);
					num2++;
				}
			}
			return num2;
		}

		internal int UPErmvGxbaexRBBoUJNfdGoesNwy(int P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			if (P_2 == null)
			{
				throw new ArgumentNullException("results");
			}
			if (!P_3)
			{
				P_2.Clear();
			}
			if (P_0 < 0)
			{
				return 0;
			}
			int num = axisMapCount;
			int num2 = 0;
			for (int i = 0; i < num; i++)
			{
				ActionElementMap actionElementMap = UUHETvjEpNhDHXYwlfeLsKyNvXhAA[i];
				if (actionElementMap._actionId == P_0 && (!P_1 || actionElementMap.dQASdaEFVJzbOgxgKEdsYSDArFzi))
				{
					P_2.Add(actionElementMap);
					num2++;
				}
			}
			return num2;
		}

		internal virtual int BryAPvafYNhPyNpmuJERhSEjnztMb(int P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			int num = base.TPGoRsOaoYnEGuXZQSOypYbEQESv(P_0, P_1, P_2, P_3);
			if (P_0 < 0)
			{
				return num;
			}
			int num2 = axisMapCount;
			for (int i = 0; i < num2; i++)
			{
				ActionElementMap actionElementMap = UUHETvjEpNhDHXYwlfeLsKyNvXhAA[i];
				if (actionElementMap._actionId == P_0 && (!P_1 || actionElementMap.dQASdaEFVJzbOgxgKEdsYSDArFzi))
				{
					P_2.Add(actionElementMap);
					num++;
				}
			}
			return num;
		}

		internal virtual ActionElementMap igXrNXLCStdpdpgiuYBFRJEoOJtG(IControllerElementTarget P_0, bool P_1, int P_2, bool P_3, out bool P_4)
		{
			ActionElementMap actionElementMap = base.ULkNEiizKoMslClQddTEvQaQhqGD(P_0, P_1, P_2, P_3, out P_4);
			if (actionElementMap != null)
			{
				return actionElementMap;
			}
			if (P_4)
			{
				return null;
			}
			if (!ZCLDIeeEtllVdAmNJjijFCYWVDGlb(P_0.elementType))
			{
				return null;
			}
			int num = axisMapCount;
			_ = P_0.elementIdentifierId;
			for (int i = 0; i < num; i++)
			{
				if ((!P_1 || UUHETvjEpNhDHXYwlfeLsKyNvXhAA[i]._actionId == P_2) && (!P_3 || UUHETvjEpNhDHXYwlfeLsKyNvXhAA[i].dQASdaEFVJzbOgxgKEdsYSDArFzi) && UUHETvjEpNhDHXYwlfeLsKyNvXhAA[i].IsTarget(P_0))
				{
					return UUHETvjEpNhDHXYwlfeLsKyNvXhAA[i];
				}
			}
			return null;
		}

		internal virtual int eQKtKuzADGghJEvVweHeWHAYGxab(IControllerElementTarget P_0, bool P_1, int P_2, bool P_3, List<ActionElementMap> P_4, bool P_5, out bool P_6)
		{
			int num = base.xbMqqhNCHHsGgJNjWdODBOazhjtNA(P_0, P_1, P_2, P_3, P_4, P_5, out P_6);
			if (P_6)
			{
				return num;
			}
			if (!ZCLDIeeEtllVdAmNJjijFCYWVDGlb(P_0.elementType))
			{
				return num;
			}
			int num2 = axisMapCount;
			_ = P_0.elementIdentifierId;
			for (int i = 0; i < num2; i++)
			{
				if ((!P_1 || UUHETvjEpNhDHXYwlfeLsKyNvXhAA[i]._actionId == P_2) && (!P_3 || UUHETvjEpNhDHXYwlfeLsKyNvXhAA[i].dQASdaEFVJzbOgxgKEdsYSDArFzi) && UUHETvjEpNhDHXYwlfeLsKyNvXhAA[i].IsTarget(P_0))
				{
					P_4.Add(UUHETvjEpNhDHXYwlfeLsKyNvXhAA[i]);
					num++;
				}
			}
			return num;
		}

		internal virtual bool xbexiRcusXoaUABbUgVfqPMyymrr(ActionElementMap P_0)
		{
			if (base.MRgDnrLSsvZtSdyIMEPGVhhYDIyZ(P_0))
			{
				return true;
			}
			if (P_0 == null)
			{
				return false;
			}
			if (!ZCLDIeeEtllVdAmNJjijFCYWVDGlb(P_0._elementType))
			{
				return false;
			}
			UUHETvjEpNhDHXYwlfeLsKyNvXhAA.Add(P_0);
			AZJmYkVvuBcWQvrqeQVQVECJigTK(P_0);
			return true;
		}

		private bool ZCLDIeeEtllVdAmNJjijFCYWVDGlb(ControllerElementType P_0)
		{
			if (P_0 != ControllerElementType.Axis)
			{
				return false;
			}
			return true;
		}

		private void ywJKNgBowWIXlhORKwHtDXBinDyJ(int P_0, int P_1)
		{
			QmTnGtJygnAyBDShSvBhjrWUUuhL(P_0);
			if (P_1 >= 0 && P_1 < axisMapCount)
			{
				UUHETvjEpNhDHXYwlfeLsKyNvXhAA.RemoveAt(P_1);
			}
		}

		private void GJbeSVeWLxbsvqziWKnBEkoWQAGx(ActionElementMap P_0)
		{
			if (P_0 != null)
			{
				UUHETvjEpNhDHXYwlfeLsKyNvXhAA.Add(P_0);
				AZJmYkVvuBcWQvrqeQVQVECJigTK(P_0);
			}
		}

		private void OvSIEIDSdGufUZaHTKoOVJwEwaGW(ActionElementMap P_0, int P_1)
		{
			if (P_0 != null && P_1 >= 0 && P_1 < axisMapCount)
			{
				ohNdGVIsDsFYFQeUlMqKVvYfEWrc(UUHETvjEpNhDHXYwlfeLsKyNvXhAA[P_1].oFUAyzlkDBdPoonWGgEIgJYWTzJOA, P_0);
				UUHETvjEpNhDHXYwlfeLsKyNvXhAA[P_1] = P_0;
			}
		}

		internal virtual void FTJvvyHpjsNmiFlIvQSzxczEduNdA(SerializedObject P_0)
		{
			base.iZDJwKoaMpHLdcAEEKFbgptHoIabB(P_0);
			int num = axisMapCount;
			List<object> list = new List<object>();
			P_0.Add("axisMaps", list);
			for (int i = 0; i < num; i++)
			{
				if (UUHETvjEpNhDHXYwlfeLsKyNvXhAA[i] != null)
				{
					list.Add(UUHETvjEpNhDHXYwlfeLsKyNvXhAA[i].cSOgtQGQhdPyjGwILCVsTHtTgUFxA());
				}
			}
		}

		internal virtual bool NYJNdOwMBrjJkBMKURUsaLVKugjQA(SerializedObject P_0)
		{
			bool flag = base.HPOExOlytDPUDxqQzZbvKbzhZnyr(P_0);
			if (!flag)
			{
				ClearElementMaps();
				flag = true;
			}
			SerializedObject value = null;
			if (P_0.TryGetDeserializedValueByRef("axisMaps", ref value) && value != null)
			{
				for (int i = 0; i < value.count; i++)
				{
					if (value.TryGetDeserializedValue<SerializedObject>(i, out var value2) || value2 == null)
					{
						ActionElementMap actionElementMap = new ActionElementMap();
						actionElementMap.gzRmpiyWMaJwdTlfQTwJfqBAzPKK(value2);
						if (ActionElementMap.cKGcyYGyQDfPHsLIvwcztnLQaKGd(actionElementMap))
						{
							GJbeSVeWLxbsvqziWKnBEkoWQAGx(actionElementMap);
						}
					}
				}
			}
			return flag;
		}

		[DebuggerHidden]
		[CompilerGenerated]
		private IEnumerable<ElementAssignmentConflictInfo> mnVKsFeQuWYaLPDmLhgwpWDTCihKA(ControllerMap P_0, bool P_1)
		{
			return base.ElementAssignmentConflicts(P_0, P_1);
		}

		[CompilerGenerated]
		[DebuggerHidden]
		private IEnumerable<ElementAssignmentConflictInfo> ReCYHnXcqnWBXaIcpLgizUyJPzvv(ActionElementMap P_0, bool P_1)
		{
			return base.ElementAssignmentConflicts(P_0, P_1);
		}

		[CompilerGenerated]
		[DebuggerHidden]
		private IEnumerable<ElementAssignmentConflictInfo> XJNAJgaONJWUcOIlgpipriaTLyhZA(ElementAssignmentConflictCheck P_0, bool P_1)
		{
			return base.ElementAssignmentConflicts(P_0, P_1);
		}
	}
}
