using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Rewired.Data.Mapping;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using UnityEngine;

namespace Rewired
{
	public abstract class ControllerMap
	{
		private class TYowNWGMfpmroNLgMCxyexiayMUAA : IComparer<ActionElementMap>
		{
			public static TYowNWGMfpmroNLgMCxyexiayMUAA AEihtaOVkydsBfsiWkmAzTgHhTRuA;

			public static TYowNWGMfpmroNLgMCxyexiayMUAA BqPbMMEPcMgjwvohmdDHEhQbIBpmc => AEihtaOVkydsBfsiWkmAzTgHhTRuA ?? (AEihtaOVkydsBfsiWkmAzTgHhTRuA = new TYowNWGMfpmroNLgMCxyexiayMUAA());

			public int Compare(ActionElementMap x, ActionElementMap y)
			{
				if (x == null)
				{
					if (y == null)
					{
						return 0;
					}
					return -1;
				}
				if (y == null)
				{
					return 1;
				}
				if (x._elementType == y._elementType)
				{
					return x.id.CompareTo(y.id);
				}
				if (x._elementType switch
				{
					ControllerElementType.Button => 0, 
					ControllerElementType.Axis => 1, 
					ControllerElementType.CompoundElement => 2, 
					_ => throw new NotImplementedException(), 
				} <= y._elementType switch
				{
					ControllerElementType.Button => 0, 
					ControllerElementType.Axis => 1, 
					ControllerElementType.CompoundElement => 2, 
					_ => throw new NotImplementedException(), 
				})
				{
					return -1;
				}
				return 1;
			}

			int IComparer<ActionElementMap>.Compare(ActionElementMap x, ActionElementMap y)
			{
				//ILSpy generated this explicit interface implementation from .override directive in Compare
				return this.Compare(x, y);
			}
		}

		private sealed class vYcQAQeAjWMDlqWvkbqqbSlKuVNe : IEnumerable<ActionElementMap>, IEnumerable, IEnumerator<ActionElementMap>, IEnumerator, IDisposable
		{
			private int ttNQZNChibEkheJngAHkafuevLpWA;

			private ActionElementMap iWIbstDzTVhOBiVVtGLLiXLJXVWi;

			private int OYpAgWcpMIqnrCjigyNKWkgkdDyI;

			public ControllerMap kRiZUDMLmzCdCBKZQihTUBUgAIINA;

			private int ZvKDVPCGFPKDKdEtaHdFmWeVkoTXB;

			public int jsUQoAtUrPDxXiHJceTNIUlJBDxu;

			private bool pHmBKAsDQlQVGwzLTMgfKREhuEVp;

			public bool rXPMIbUYBWbqKRpxmILasOyCKVzX;

			private IList<ActionElementMap> RTaamtYSTfmDGkujbGppyajjtesJ;

			private int XBNYEvLcTgwGsDeIrDJHXefQYCHU;

			private int vNKFpBFAxJUsQdFdZDlVjRoxjpEgA;

			ActionElementMap IEnumerator<ActionElementMap>.Current
			{
				[DebuggerHidden]
				get
				{
					return iWIbstDzTVhOBiVVtGLLiXLJXVWi;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return iWIbstDzTVhOBiVVtGLLiXLJXVWi;
				}
			}

			[DebuggerHidden]
			public vYcQAQeAjWMDlqWvkbqqbSlKuVNe(int P_0)
			{
				ttNQZNChibEkheJngAHkafuevLpWA = P_0;
				OYpAgWcpMIqnrCjigyNKWkgkdDyI = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int num = ttNQZNChibEkheJngAHkafuevLpWA;
				ControllerMap controllerMap = kRiZUDMLmzCdCBKZQihTUBUgAIINA;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					ttNQZNChibEkheJngAHkafuevLpWA = -1;
					goto IL_00af;
				}
				ttNQZNChibEkheJngAHkafuevLpWA = -1;
				if (ReInput._id != controllerMap.sIwyLhKUWykANTFJFXecFgCmwcwn)
				{
					ReInput.CheckInitialized(controllerMap.sIwyLhKUWykANTFJFXecFgCmwcwn);
					return false;
				}
				if (ZvKDVPCGFPKDKdEtaHdFmWeVkoTXB < 0)
				{
					return false;
				}
				RTaamtYSTfmDGkujbGppyajjtesJ = controllerMap.ButtonMaps;
				XBNYEvLcTgwGsDeIrDJHXefQYCHU = controllerMap.buttonMapCount;
				vNKFpBFAxJUsQdFdZDlVjRoxjpEgA = 0;
				goto IL_00bf;
				IL_00bf:
				if (vNKFpBFAxJUsQdFdZDlVjRoxjpEgA < XBNYEvLcTgwGsDeIrDJHXefQYCHU)
				{
					ActionElementMap actionElementMap = RTaamtYSTfmDGkujbGppyajjtesJ[vNKFpBFAxJUsQdFdZDlVjRoxjpEgA];
					if (actionElementMap._actionId == ZvKDVPCGFPKDKdEtaHdFmWeVkoTXB && (!pHmBKAsDQlQVGwzLTMgfKREhuEVp || actionElementMap.dQASdaEFVJzbOgxgKEdsYSDArFzi))
					{
						iWIbstDzTVhOBiVVtGLLiXLJXVWi = actionElementMap;
						ttNQZNChibEkheJngAHkafuevLpWA = 1;
						return true;
					}
					goto IL_00af;
				}
				return false;
				IL_00af:
				vNKFpBFAxJUsQdFdZDlVjRoxjpEgA++;
				goto IL_00bf;
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
			IEnumerator<ActionElementMap> IEnumerable<ActionElementMap>.GetEnumerator()
			{
				vYcQAQeAjWMDlqWvkbqqbSlKuVNe vYcQAQeAjWMDlqWvkbqqbSlKuVNe2;
				if (ttNQZNChibEkheJngAHkafuevLpWA == -2 && OYpAgWcpMIqnrCjigyNKWkgkdDyI == Environment.CurrentManagedThreadId)
				{
					ttNQZNChibEkheJngAHkafuevLpWA = 0;
					vYcQAQeAjWMDlqWvkbqqbSlKuVNe2 = this;
				}
				else
				{
					vYcQAQeAjWMDlqWvkbqqbSlKuVNe2 = new vYcQAQeAjWMDlqWvkbqqbSlKuVNe(0);
					vYcQAQeAjWMDlqWvkbqqbSlKuVNe2.kRiZUDMLmzCdCBKZQihTUBUgAIINA = kRiZUDMLmzCdCBKZQihTUBUgAIINA;
				}
				vYcQAQeAjWMDlqWvkbqqbSlKuVNe2.ZvKDVPCGFPKDKdEtaHdFmWeVkoTXB = jsUQoAtUrPDxXiHJceTNIUlJBDxu;
				vYcQAQeAjWMDlqWvkbqqbSlKuVNe2.pHmBKAsDQlQVGwzLTMgfKREhuEVp = rXPMIbUYBWbqKRpxmILasOyCKVzX;
				return vYcQAQeAjWMDlqWvkbqqbSlKuVNe2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
			}
		}

		private sealed class YRmGBRBggivRmVnEXjKheLgnRtLi : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
		{
			private int qxOQcquOHrqRUoWUJMMdYSnzCcTJA;

			private ElementAssignmentConflictInfo NbifAsJmmqvWMDTUsVGfENJYAkKnA;

			private int ZBMftmhYzpeEuQYkdjXfTSAwpspW;

			public ControllerMap ckfSiviPNLYtTRBefGwcpqjEAEVR;

			private ControllerMap VUZrzztqpwGndOYRGaldmoaKHSVu;

			public ControllerMap tPCNhRpuvXaQbKondDaoCnEbDoaOA;

			private bool QOoooykooNgwCMoQpySSpdAdoSXg;

			public bool rWcEtiqnkmPKLgSGUeFRQIkycsJN;

			private IList<ActionElementMap> WVgVCemDPpgFUjJTdEzVXsRCUxrb;

			private int zHWfwuutiptqIxBXrWuNpWtPoGSs;

			private int vIXyVsqLMYWNSNkjEqTmPlXytfWW;

			private ActionElementMap sYNpVsKezPyeISJeBWffVKBRcHwY;

			private int HGQlCwOOTYJGmBcLVYRANnzEItX;

			ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return NbifAsJmmqvWMDTUsVGfENJYAkKnA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return NbifAsJmmqvWMDTUsVGfENJYAkKnA;
				}
			}

			[DebuggerHidden]
			public YRmGBRBggivRmVnEXjKheLgnRtLi(int P_0)
			{
				qxOQcquOHrqRUoWUJMMdYSnzCcTJA = P_0;
				ZBMftmhYzpeEuQYkdjXfTSAwpspW = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int num = qxOQcquOHrqRUoWUJMMdYSnzCcTJA;
				ControllerMap controllerMap = ckfSiviPNLYtTRBefGwcpqjEAEVR;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					qxOQcquOHrqRUoWUJMMdYSnzCcTJA = -1;
					goto IL_019c;
				}
				qxOQcquOHrqRUoWUJMMdYSnzCcTJA = -1;
				if (ReInput._id != controllerMap.sIwyLhKUWykANTFJFXecFgCmwcwn)
				{
					ReInput.CheckInitialized(controllerMap.sIwyLhKUWykANTFJFXecFgCmwcwn);
					return false;
				}
				if (VUZrzztqpwGndOYRGaldmoaKHSVu == null || controllerMap.OLBjOXTjrODnCfjjQFNcEHntujcMA == null)
				{
					return false;
				}
				if (QOoooykooNgwCMoQpySSpdAdoSXg && (!controllerMap._enabled || !VUZrzztqpwGndOYRGaldmoaKHSVu._enabled))
				{
					return false;
				}
				WVgVCemDPpgFUjJTdEzVXsRCUxrb = VUZrzztqpwGndOYRGaldmoaKHSVu.ButtonMaps;
				if (WVgVCemDPpgFUjJTdEzVXsRCUxrb == null)
				{
					return false;
				}
				zHWfwuutiptqIxBXrWuNpWtPoGSs = WVgVCemDPpgFUjJTdEzVXsRCUxrb.Count;
				vIXyVsqLMYWNSNkjEqTmPlXytfWW = 0;
				goto IL_01d4;
				IL_01d4:
				if (vIXyVsqLMYWNSNkjEqTmPlXytfWW < controllerMap.OLBjOXTjrODnCfjjQFNcEHntujcMA.Count)
				{
					sYNpVsKezPyeISJeBWffVKBRcHwY = controllerMap.OLBjOXTjrODnCfjjQFNcEHntujcMA[vIXyVsqLMYWNSNkjEqTmPlXytfWW];
					if (!QOoooykooNgwCMoQpySSpdAdoSXg || sYNpVsKezPyeISJeBWffVKBRcHwY.dQASdaEFVJzbOgxgKEdsYSDArFzi)
					{
						HGQlCwOOTYJGmBcLVYRANnzEItX = 0;
						goto IL_01ac;
					}
					goto IL_01c4;
				}
				return false;
				IL_01ac:
				if (HGQlCwOOTYJGmBcLVYRANnzEItX < zHWfwuutiptqIxBXrWuNpWtPoGSs)
				{
					ActionElementMap actionElementMap = WVgVCemDPpgFUjJTdEzVXsRCUxrb[HGQlCwOOTYJGmBcLVYRANnzEItX];
					if ((!QOoooykooNgwCMoQpySSpdAdoSXg || actionElementMap.dQASdaEFVJzbOgxgKEdsYSDArFzi) && sYNpVsKezPyeISJeBWffVKBRcHwY.CheckForAssignmentConflict(actionElementMap))
					{
						NbifAsJmmqvWMDTUsVGfENJYAkKnA = new ElementAssignmentConflictInfo(true, ReInput.mapping.GetMapCategory(controllerMap._categoryId).userAssignable, -1, controllerMap._controllerType, controllerMap._controllerId, controllerMap._id, sYNpVsKezPyeISJeBWffVKBRcHwY.oFUAyzlkDBdPoonWGgEIgJYWTzJOA, sYNpVsKezPyeISJeBWffVKBRcHwY._actionId, sYNpVsKezPyeISJeBWffVKBRcHwY._elementType, sYNpVsKezPyeISJeBWffVKBRcHwY._elementIdentifierId, sYNpVsKezPyeISJeBWffVKBRcHwY.keyCode, sYNpVsKezPyeISJeBWffVKBRcHwY.modifierKeyFlags);
						qxOQcquOHrqRUoWUJMMdYSnzCcTJA = 1;
						return true;
					}
					goto IL_019c;
				}
				sYNpVsKezPyeISJeBWffVKBRcHwY = null;
				goto IL_01c4;
				IL_01c4:
				vIXyVsqLMYWNSNkjEqTmPlXytfWW++;
				goto IL_01d4;
				IL_019c:
				HGQlCwOOTYJGmBcLVYRANnzEItX++;
				goto IL_01ac;
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
			IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
			{
				YRmGBRBggivRmVnEXjKheLgnRtLi yRmGBRBggivRmVnEXjKheLgnRtLi;
				if (qxOQcquOHrqRUoWUJMMdYSnzCcTJA == -2 && ZBMftmhYzpeEuQYkdjXfTSAwpspW == Environment.CurrentManagedThreadId)
				{
					qxOQcquOHrqRUoWUJMMdYSnzCcTJA = 0;
					yRmGBRBggivRmVnEXjKheLgnRtLi = this;
				}
				else
				{
					yRmGBRBggivRmVnEXjKheLgnRtLi = new YRmGBRBggivRmVnEXjKheLgnRtLi(0);
					yRmGBRBggivRmVnEXjKheLgnRtLi.ckfSiviPNLYtTRBefGwcpqjEAEVR = ckfSiviPNLYtTRBefGwcpqjEAEVR;
				}
				yRmGBRBggivRmVnEXjKheLgnRtLi.VUZrzztqpwGndOYRGaldmoaKHSVu = tPCNhRpuvXaQbKondDaoCnEbDoaOA;
				yRmGBRBggivRmVnEXjKheLgnRtLi.QOoooykooNgwCMoQpySSpdAdoSXg = rWcEtiqnkmPKLgSGUeFRQIkycsJN;
				return yRmGBRBggivRmVnEXjKheLgnRtLi;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
			}
		}

		private sealed class tkTyGJYEOsCeXVDMNlzCXHYjLnjB : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
		{
			private int ffTeTUfVErFDDPuXkoovuSbhhyOdA;

			private ElementAssignmentConflictInfo UrZAUeaeVXsWGqEvFLRRpncIHNPWA;

			private int dhFWqvPNZohRYRmWvotqnFKLBjdT;

			public ControllerMap YdNQUDSqAxFvnKmWccDKCNAROIjqA;

			private ActionElementMap eGnCnlajnAIdbTquvyeeePmJZOREA;

			public ActionElementMap bOUwnqrjLrPsvFutzjgHOeTbnEef;

			private bool bBTnARCcliYomJsVPdGniOOcgRFt;

			public bool wbvOANHGPJXYyXoxPUFZyeUmqWDD;

			private int bsDupYjcGPNPLOQTgEmfgIWBzDpi;

			ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return UrZAUeaeVXsWGqEvFLRRpncIHNPWA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return UrZAUeaeVXsWGqEvFLRRpncIHNPWA;
				}
			}

			[DebuggerHidden]
			public tkTyGJYEOsCeXVDMNlzCXHYjLnjB(int P_0)
			{
				ffTeTUfVErFDDPuXkoovuSbhhyOdA = P_0;
				dhFWqvPNZohRYRmWvotqnFKLBjdT = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int num = ffTeTUfVErFDDPuXkoovuSbhhyOdA;
				ControllerMap ydNQUDSqAxFvnKmWccDKCNAROIjqA = YdNQUDSqAxFvnKmWccDKCNAROIjqA;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					ffTeTUfVErFDDPuXkoovuSbhhyOdA = -1;
					goto IL_0111;
				}
				ffTeTUfVErFDDPuXkoovuSbhhyOdA = -1;
				if (ReInput._id != ydNQUDSqAxFvnKmWccDKCNAROIjqA.sIwyLhKUWykANTFJFXecFgCmwcwn)
				{
					ReInput.CheckInitialized(ydNQUDSqAxFvnKmWccDKCNAROIjqA.sIwyLhKUWykANTFJFXecFgCmwcwn);
					return false;
				}
				if (eGnCnlajnAIdbTquvyeeePmJZOREA == null || ydNQUDSqAxFvnKmWccDKCNAROIjqA.OLBjOXTjrODnCfjjQFNcEHntujcMA == null)
				{
					return false;
				}
				if (bBTnARCcliYomJsVPdGniOOcgRFt && (!ydNQUDSqAxFvnKmWccDKCNAROIjqA._enabled || !eGnCnlajnAIdbTquvyeeePmJZOREA.dQASdaEFVJzbOgxgKEdsYSDArFzi))
				{
					return false;
				}
				bsDupYjcGPNPLOQTgEmfgIWBzDpi = 0;
				goto IL_0121;
				IL_0111:
				bsDupYjcGPNPLOQTgEmfgIWBzDpi++;
				goto IL_0121;
				IL_0121:
				if (bsDupYjcGPNPLOQTgEmfgIWBzDpi < ydNQUDSqAxFvnKmWccDKCNAROIjqA.OLBjOXTjrODnCfjjQFNcEHntujcMA.Count)
				{
					ActionElementMap actionElementMap = ydNQUDSqAxFvnKmWccDKCNAROIjqA.OLBjOXTjrODnCfjjQFNcEHntujcMA[bsDupYjcGPNPLOQTgEmfgIWBzDpi];
					if ((!bBTnARCcliYomJsVPdGniOOcgRFt || actionElementMap.dQASdaEFVJzbOgxgKEdsYSDArFzi) && actionElementMap.CheckForAssignmentConflict(eGnCnlajnAIdbTquvyeeePmJZOREA))
					{
						UrZAUeaeVXsWGqEvFLRRpncIHNPWA = new ElementAssignmentConflictInfo(true, ReInput.mapping.GetMapCategory(ydNQUDSqAxFvnKmWccDKCNAROIjqA._categoryId).userAssignable, -1, ydNQUDSqAxFvnKmWccDKCNAROIjqA._controllerType, ydNQUDSqAxFvnKmWccDKCNAROIjqA._controllerId, ydNQUDSqAxFvnKmWccDKCNAROIjqA._id, actionElementMap.oFUAyzlkDBdPoonWGgEIgJYWTzJOA, actionElementMap._actionId, actionElementMap._elementType, actionElementMap._elementIdentifierId, actionElementMap.keyCode, actionElementMap.modifierKeyFlags);
						ffTeTUfVErFDDPuXkoovuSbhhyOdA = 1;
						return true;
					}
					goto IL_0111;
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

			[DebuggerHidden]
			IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
			{
				tkTyGJYEOsCeXVDMNlzCXHYjLnjB tkTyGJYEOsCeXVDMNlzCXHYjLnjB2;
				if (ffTeTUfVErFDDPuXkoovuSbhhyOdA == -2 && dhFWqvPNZohRYRmWvotqnFKLBjdT == Environment.CurrentManagedThreadId)
				{
					ffTeTUfVErFDDPuXkoovuSbhhyOdA = 0;
					tkTyGJYEOsCeXVDMNlzCXHYjLnjB2 = this;
				}
				else
				{
					tkTyGJYEOsCeXVDMNlzCXHYjLnjB2 = new tkTyGJYEOsCeXVDMNlzCXHYjLnjB(0);
					tkTyGJYEOsCeXVDMNlzCXHYjLnjB2.YdNQUDSqAxFvnKmWccDKCNAROIjqA = YdNQUDSqAxFvnKmWccDKCNAROIjqA;
				}
				tkTyGJYEOsCeXVDMNlzCXHYjLnjB2.eGnCnlajnAIdbTquvyeeePmJZOREA = bOUwnqrjLrPsvFutzjgHOeTbnEef;
				tkTyGJYEOsCeXVDMNlzCXHYjLnjB2.bBTnARCcliYomJsVPdGniOOcgRFt = wbvOANHGPJXYyXoxPUFZyeUmqWDD;
				return tkTyGJYEOsCeXVDMNlzCXHYjLnjB2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
			}
		}

		private sealed class RYroKRhCnrdpCnYDnuJisqBFGDQf : IEnumerable<ElementAssignmentConflictInfo>, IEnumerable, IEnumerator<ElementAssignmentConflictInfo>, IEnumerator, IDisposable
		{
			private int cURGlgDSeIiNnGYAilUpWtDKLLbZ;

			private ElementAssignmentConflictInfo iwvoLeYvGCFDNiIyyxghYnaYfekh;

			private int oQSXqCUzemNDlhabYaZVMyyYCdYw;

			public ControllerMap kvHAmtivTOzbDxhPkWjLxVSaAzGGA;

			private bool hmWpeoufBwryVFJaKRCCOjqwLcqq;

			public bool wBakxjGxhutoqVCFiSRajOVGwDpX;

			private ElementAssignmentConflictCheck hnhazICeZdDrbJJkTJndGwLWndOlA;

			public ElementAssignmentConflictCheck kLPAggVDvmtnwgsWLVXsTvEfzhjF;

			private ElementAssignment GTWwEAjWEVJJsqQgpmxfIYvYsrqC;

			private int GOfUFaIquVsWmelvntFWiTpUUPGG;

			ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return iwvoLeYvGCFDNiIyyxghYnaYfekh;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return iwvoLeYvGCFDNiIyyxghYnaYfekh;
				}
			}

			[DebuggerHidden]
			public RYroKRhCnrdpCnYDnuJisqBFGDQf(int P_0)
			{
				cURGlgDSeIiNnGYAilUpWtDKLLbZ = P_0;
				oQSXqCUzemNDlhabYaZVMyyYCdYw = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int num = cURGlgDSeIiNnGYAilUpWtDKLLbZ;
				ControllerMap controllerMap = kvHAmtivTOzbDxhPkWjLxVSaAzGGA;
				if (num != 0)
				{
					if (num != 1)
					{
						return false;
					}
					cURGlgDSeIiNnGYAilUpWtDKLLbZ = -1;
					goto IL_0123;
				}
				cURGlgDSeIiNnGYAilUpWtDKLLbZ = -1;
				if (ReInput._id != controllerMap.sIwyLhKUWykANTFJFXecFgCmwcwn)
				{
					ReInput.CheckInitialized(controllerMap.sIwyLhKUWykANTFJFXecFgCmwcwn);
					return false;
				}
				if (hmWpeoufBwryVFJaKRCCOjqwLcqq && !controllerMap._enabled)
				{
					return false;
				}
				if (controllerMap.OLBjOXTjrODnCfjjQFNcEHntujcMA == null)
				{
					return false;
				}
				GTWwEAjWEVJJsqQgpmxfIYvYsrqC = hnhazICeZdDrbJJkTJndGwLWndOlA.ToElementAssignment();
				GOfUFaIquVsWmelvntFWiTpUUPGG = 0;
				goto IL_0133;
				IL_0133:
				if (GOfUFaIquVsWmelvntFWiTpUUPGG < controllerMap.OLBjOXTjrODnCfjjQFNcEHntujcMA.Count)
				{
					ActionElementMap actionElementMap = controllerMap.OLBjOXTjrODnCfjjQFNcEHntujcMA[GOfUFaIquVsWmelvntFWiTpUUPGG];
					if ((!hmWpeoufBwryVFJaKRCCOjqwLcqq || actionElementMap.dQASdaEFVJzbOgxgKEdsYSDArFzi) && actionElementMap.oFUAyzlkDBdPoonWGgEIgJYWTzJOA != hnhazICeZdDrbJJkTJndGwLWndOlA.elementMapId && actionElementMap.CheckForAssignmentConflict(GTWwEAjWEVJJsqQgpmxfIYvYsrqC))
					{
						iwvoLeYvGCFDNiIyyxghYnaYfekh = new ElementAssignmentConflictInfo(true, ReInput.mapping.GetMapCategory(controllerMap._categoryId).userAssignable, -1, controllerMap._controllerType, controllerMap._controllerId, controllerMap._id, actionElementMap.oFUAyzlkDBdPoonWGgEIgJYWTzJOA, actionElementMap._actionId, actionElementMap._elementType, actionElementMap._elementIdentifierId, actionElementMap.keyCode, actionElementMap.modifierKeyFlags);
						cURGlgDSeIiNnGYAilUpWtDKLLbZ = 1;
						return true;
					}
					goto IL_0123;
				}
				return false;
				IL_0123:
				GOfUFaIquVsWmelvntFWiTpUUPGG++;
				goto IL_0133;
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
			IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
			{
				RYroKRhCnrdpCnYDnuJisqBFGDQf rYroKRhCnrdpCnYDnuJisqBFGDQf;
				if (cURGlgDSeIiNnGYAilUpWtDKLLbZ == -2 && oQSXqCUzemNDlhabYaZVMyyYCdYw == Environment.CurrentManagedThreadId)
				{
					cURGlgDSeIiNnGYAilUpWtDKLLbZ = 0;
					rYroKRhCnrdpCnYDnuJisqBFGDQf = this;
				}
				else
				{
					rYroKRhCnrdpCnYDnuJisqBFGDQf = new RYroKRhCnrdpCnYDnuJisqBFGDQf(0);
					rYroKRhCnrdpCnYDnuJisqBFGDQf.kvHAmtivTOzbDxhPkWjLxVSaAzGGA = kvHAmtivTOzbDxhPkWjLxVSaAzGGA;
				}
				rYroKRhCnrdpCnYDnuJisqBFGDQf.hnhazICeZdDrbJJkTJndGwLWndOlA = kLPAggVDvmtnwgsWLVXsTvEfzhjF;
				rYroKRhCnrdpCnYDnuJisqBFGDQf.hmWpeoufBwryVFJaKRCCOjqwLcqq = wBakxjGxhutoqVCFiSRajOVGwDpX;
				return rYroKRhCnrdpCnYDnuJisqBFGDQf;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
			}
		}

		private sealed class XgnElpmNADboXfqEhYgUcnESUSfMA : IEnumerable<ActionElementMap>, IEnumerable, IEnumerator<ActionElementMap>, IEnumerator, IDisposable
		{
			private int qMIfKHJgXdSPothfTgpsWMCWhTLqA;

			private ActionElementMap EFTnGYQWAWQsaXSeXadidQipEtmwA;

			private int IQgrKUyCcIcgjGdWcdKECAxRStSd;

			public ControllerMap QnsnhXfQYueQnAxreSRUlVUjJoOs;

			private int YVIonSNeJuqvUcLahGNYWHvfAIZn;

			public int LRBISmCkeHwLKeCMcjEEBxsRQMbe;

			private bool xbkfCmNdpCBacLaafPJLLGbIwjhU;

			public bool WhdfGAyXuWIWAGqhZOQausLxFeLhA;

			private IEnumerator<ActionElementMap> qLNZeLCrPvVPqBPyUHAbBBgFndPo;

			ActionElementMap IEnumerator<ActionElementMap>.Current
			{
				[DebuggerHidden]
				get
				{
					return EFTnGYQWAWQsaXSeXadidQipEtmwA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return EFTnGYQWAWQsaXSeXadidQipEtmwA;
				}
			}

			[DebuggerHidden]
			public XgnElpmNADboXfqEhYgUcnESUSfMA(int P_0)
			{
				qMIfKHJgXdSPothfTgpsWMCWhTLqA = P_0;
				IQgrKUyCcIcgjGdWcdKECAxRStSd = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int num = qMIfKHJgXdSPothfTgpsWMCWhTLqA;
				if (num == -3 || num == 1)
				{
					try
					{
					}
					finally
					{
						jEEhWdLNANEPHipHbYgiuTyilIPwA();
					}
				}
			}

			private bool MoveNext()
			{
				try
				{
					int num = qMIfKHJgXdSPothfTgpsWMCWhTLqA;
					ControllerMap qnsnhXfQYueQnAxreSRUlVUjJoOs = QnsnhXfQYueQnAxreSRUlVUjJoOs;
					switch (num)
					{
					default:
						return false;
					case 0:
						qMIfKHJgXdSPothfTgpsWMCWhTLqA = -1;
						if (ReInput._id != qnsnhXfQYueQnAxreSRUlVUjJoOs.sIwyLhKUWykANTFJFXecFgCmwcwn)
						{
							ReInput.CheckInitialized(qnsnhXfQYueQnAxreSRUlVUjJoOs.sIwyLhKUWykANTFJFXecFgCmwcwn);
							return false;
						}
						qLNZeLCrPvVPqBPyUHAbBBgFndPo = qnsnhXfQYueQnAxreSRUlVUjJoOs.AllMaps.GetEnumerator();
						qMIfKHJgXdSPothfTgpsWMCWhTLqA = -3;
						break;
					case 1:
						qMIfKHJgXdSPothfTgpsWMCWhTLqA = -3;
						break;
					}
					while (qLNZeLCrPvVPqBPyUHAbBBgFndPo.MoveNext())
					{
						ActionElementMap current = qLNZeLCrPvVPqBPyUHAbBBgFndPo.Current;
						if (current._actionId == YVIonSNeJuqvUcLahGNYWHvfAIZn && (!xbkfCmNdpCBacLaafPJLLGbIwjhU || current.dQASdaEFVJzbOgxgKEdsYSDArFzi))
						{
							EFTnGYQWAWQsaXSeXadidQipEtmwA = current;
							qMIfKHJgXdSPothfTgpsWMCWhTLqA = 1;
							return true;
						}
					}
					jEEhWdLNANEPHipHbYgiuTyilIPwA();
					qLNZeLCrPvVPqBPyUHAbBBgFndPo = null;
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

			private void jEEhWdLNANEPHipHbYgiuTyilIPwA()
			{
				qMIfKHJgXdSPothfTgpsWMCWhTLqA = -1;
				if (qLNZeLCrPvVPqBPyUHAbBBgFndPo != null)
				{
					qLNZeLCrPvVPqBPyUHAbBBgFndPo.Dispose();
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
				XgnElpmNADboXfqEhYgUcnESUSfMA xgnElpmNADboXfqEhYgUcnESUSfMA;
				if (qMIfKHJgXdSPothfTgpsWMCWhTLqA == -2 && IQgrKUyCcIcgjGdWcdKECAxRStSd == Environment.CurrentManagedThreadId)
				{
					qMIfKHJgXdSPothfTgpsWMCWhTLqA = 0;
					xgnElpmNADboXfqEhYgUcnESUSfMA = this;
				}
				else
				{
					xgnElpmNADboXfqEhYgUcnESUSfMA = new XgnElpmNADboXfqEhYgUcnESUSfMA(0);
					xgnElpmNADboXfqEhYgUcnESUSfMA.QnsnhXfQYueQnAxreSRUlVUjJoOs = QnsnhXfQYueQnAxreSRUlVUjJoOs;
				}
				xgnElpmNADboXfqEhYgUcnESUSfMA.YVIonSNeJuqvUcLahGNYWHvfAIZn = LRBISmCkeHwLKeCMcjEEBxsRQMbe;
				xgnElpmNADboXfqEhYgUcnESUSfMA.xbkfCmNdpCBacLaafPJLLGbIwjhU = WhdfGAyXuWIWAGqhZOQausLxFeLhA;
				return xgnElpmNADboXfqEhYgUcnESUSfMA;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
			}
		}

		private sealed class dtuDyaDTqppQBTkXpKVyJjBIuDLX : IEnumerable<ActionElementMap>, IEnumerable, IEnumerator<ActionElementMap>, IEnumerator, IDisposable
		{
			private int yFosRtCPYiyRMIHdJaYHcFAICntf;

			private ActionElementMap HKqyHjYFlfdbQNjvphcMNiMDDBmT;

			private int OtoRLzxMOxZXjkopxmxyBeoGqoNy;

			public ControllerMap cusCyMLRWzxzrBfuWnxFuFihXokc;

			private IControllerElementTarget fhdWoZgadsRtXcNQfiQgROKcZlwu;

			public IControllerElementTarget MCXxLzKanBfWQDGCBaAcinGXTFVHA;

			private bool wlyufLyjOnbbhPuDedfaVSEwBpPX;

			public bool TGOhJIGAEjhQDRgbwygrrSuzLazG;

			private TempListPool.TList<ActionElementMap> UTnijAzqQrbSuhoeMrTLYMSoJoUAb;

			private List<ActionElementMap>.Enumerator hmkehDFpFlkgduqKQYMXGmihTFuJA;

			ActionElementMap IEnumerator<ActionElementMap>.Current
			{
				[DebuggerHidden]
				get
				{
					return HKqyHjYFlfdbQNjvphcMNiMDDBmT;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return HKqyHjYFlfdbQNjvphcMNiMDDBmT;
				}
			}

			[DebuggerHidden]
			public dtuDyaDTqppQBTkXpKVyJjBIuDLX(int P_0)
			{
				yFosRtCPYiyRMIHdJaYHcFAICntf = P_0;
				OtoRLzxMOxZXjkopxmxyBeoGqoNy = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int num = yFosRtCPYiyRMIHdJaYHcFAICntf;
				if ((uint)(num - -4) > 1u && num != 1)
				{
					return;
				}
				try
				{
					if (num != -4 && num != 1)
					{
						return;
					}
					try
					{
					}
					finally
					{
						yjipYZkcZaVWzZKRvWTHPLGjXOaF();
					}
				}
				finally
				{
					DMgratBXOCrSMsHnTuVdafKqkzQK();
				}
			}

			private bool MoveNext()
			{
				try
				{
					int num = yFosRtCPYiyRMIHdJaYHcFAICntf;
					ControllerMap controllerMap = cusCyMLRWzxzrBfuWnxFuFihXokc;
					switch (num)
					{
					default:
						return false;
					case 0:
					{
						yFosRtCPYiyRMIHdJaYHcFAICntf = -1;
						if (ReInput._id != controllerMap.sIwyLhKUWykANTFJFXecFgCmwcwn)
						{
							ReInput.CheckInitialized(controllerMap.sIwyLhKUWykANTFJFXecFgCmwcwn);
							return false;
						}
						UTnijAzqQrbSuhoeMrTLYMSoJoUAb = TempListPool.GetTList<ActionElementMap>();
						yFosRtCPYiyRMIHdJaYHcFAICntf = -3;
						List<ActionElementMap> list = UTnijAzqQrbSuhoeMrTLYMSoJoUAb.list;
						controllerMap.xbMqqhNCHHsGgJNjWdODBOazhjtNA(fhdWoZgadsRtXcNQfiQgROKcZlwu, false, -1, wlyufLyjOnbbhPuDedfaVSEwBpPX, list, false, out var _);
						hmkehDFpFlkgduqKQYMXGmihTFuJA = list.GetEnumerator();
						yFosRtCPYiyRMIHdJaYHcFAICntf = -4;
						break;
					}
					case 1:
						yFosRtCPYiyRMIHdJaYHcFAICntf = -4;
						break;
					}
					if (hmkehDFpFlkgduqKQYMXGmihTFuJA.MoveNext())
					{
						ActionElementMap current = hmkehDFpFlkgduqKQYMXGmihTFuJA.Current;
						HKqyHjYFlfdbQNjvphcMNiMDDBmT = current;
						yFosRtCPYiyRMIHdJaYHcFAICntf = 1;
						return true;
					}
					yjipYZkcZaVWzZKRvWTHPLGjXOaF();
					hmkehDFpFlkgduqKQYMXGmihTFuJA = default(List<ActionElementMap>.Enumerator);
					DMgratBXOCrSMsHnTuVdafKqkzQK();
					UTnijAzqQrbSuhoeMrTLYMSoJoUAb = null;
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

			private void DMgratBXOCrSMsHnTuVdafKqkzQK()
			{
				yFosRtCPYiyRMIHdJaYHcFAICntf = -1;
				if (UTnijAzqQrbSuhoeMrTLYMSoJoUAb != null)
				{
					((IDisposable)UTnijAzqQrbSuhoeMrTLYMSoJoUAb).Dispose();
				}
			}

			private void yjipYZkcZaVWzZKRvWTHPLGjXOaF()
			{
				yFosRtCPYiyRMIHdJaYHcFAICntf = -3;
				((IDisposable)hmkehDFpFlkgduqKQYMXGmihTFuJA/*cast due to .constrained prefix*/).Dispose();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}

			[DebuggerHidden]
			IEnumerator<ActionElementMap> IEnumerable<ActionElementMap>.GetEnumerator()
			{
				dtuDyaDTqppQBTkXpKVyJjBIuDLX dtuDyaDTqppQBTkXpKVyJjBIuDLX2;
				if (yFosRtCPYiyRMIHdJaYHcFAICntf == -2 && OtoRLzxMOxZXjkopxmxyBeoGqoNy == Environment.CurrentManagedThreadId)
				{
					yFosRtCPYiyRMIHdJaYHcFAICntf = 0;
					dtuDyaDTqppQBTkXpKVyJjBIuDLX2 = this;
				}
				else
				{
					dtuDyaDTqppQBTkXpKVyJjBIuDLX2 = new dtuDyaDTqppQBTkXpKVyJjBIuDLX(0);
					dtuDyaDTqppQBTkXpKVyJjBIuDLX2.cusCyMLRWzxzrBfuWnxFuFihXokc = cusCyMLRWzxzrBfuWnxFuFihXokc;
				}
				dtuDyaDTqppQBTkXpKVyJjBIuDLX2.fhdWoZgadsRtXcNQfiQgROKcZlwu = MCXxLzKanBfWQDGCBaAcinGXTFVHA;
				dtuDyaDTqppQBTkXpKVyJjBIuDLX2.wlyufLyjOnbbhPuDedfaVSEwBpPX = TGOhJIGAEjhQDRgbwygrrSuzLazG;
				return dtuDyaDTqppQBTkXpKVyJjBIuDLX2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
			}
		}

		private sealed class pXOfCvqRdoVOPRwphslQNdmsLduk : IEnumerable<ActionElementMap>, IEnumerable, IEnumerator<ActionElementMap>, IEnumerator, IDisposable
		{
			private int pSpgetMDfVGypLjijgShJTXHdbAvA;

			private ActionElementMap KLuTCMaUtsbeDUZmIOkdUTlHdkht;

			private int hLqzVOJHKKpwlsuAvqSLTdcREGIX;

			public ControllerMap DfNSUgFMHCDtdZFeCDuqIFrPegdV;

			private IControllerElementTarget OgYAhrIETzrZkHMFtvDjNGMqBtJt;

			public IControllerElementTarget fLFqtbIPxgKZCKxGoUUSTmEUHifk;

			private int KMKBrXauAHHtufyCELtiGjljlJpkc;

			public int nxoGlODMxbHSPXfjRcOYtHoVFXdL;

			private bool MAjaOnbQyhpPgbbDRZktArAgjrQjA;

			public bool MBtgYWdVceMhyQhLzHftboFuJrWh;

			private TempListPool.TList<ActionElementMap> fGFYcLJhbsojrDDRAufefEutfPmy;

			private List<ActionElementMap>.Enumerator KeTUxXeBLbUVHfYpvdEVOlMjfvHN;

			ActionElementMap IEnumerator<ActionElementMap>.Current
			{
				[DebuggerHidden]
				get
				{
					return KLuTCMaUtsbeDUZmIOkdUTlHdkht;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return KLuTCMaUtsbeDUZmIOkdUTlHdkht;
				}
			}

			[DebuggerHidden]
			public pXOfCvqRdoVOPRwphslQNdmsLduk(int P_0)
			{
				pSpgetMDfVGypLjijgShJTXHdbAvA = P_0;
				hLqzVOJHKKpwlsuAvqSLTdcREGIX = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				int num = pSpgetMDfVGypLjijgShJTXHdbAvA;
				if ((uint)(num - -4) > 1u && num != 1)
				{
					return;
				}
				try
				{
					if (num != -4 && num != 1)
					{
						return;
					}
					try
					{
					}
					finally
					{
						mYzFErFHEnqozbnnReaYVXyaXTQcA();
					}
				}
				finally
				{
					lPjfbKERzBeFIARVbmVYNGBZvQOUb();
				}
			}

			private bool MoveNext()
			{
				try
				{
					int num = pSpgetMDfVGypLjijgShJTXHdbAvA;
					ControllerMap dfNSUgFMHCDtdZFeCDuqIFrPegdV = DfNSUgFMHCDtdZFeCDuqIFrPegdV;
					switch (num)
					{
					default:
						return false;
					case 0:
					{
						pSpgetMDfVGypLjijgShJTXHdbAvA = -1;
						if (ReInput._id != dfNSUgFMHCDtdZFeCDuqIFrPegdV.sIwyLhKUWykANTFJFXecFgCmwcwn)
						{
							ReInput.CheckInitialized(dfNSUgFMHCDtdZFeCDuqIFrPegdV.sIwyLhKUWykANTFJFXecFgCmwcwn);
							return false;
						}
						fGFYcLJhbsojrDDRAufefEutfPmy = TempListPool.GetTList<ActionElementMap>();
						pSpgetMDfVGypLjijgShJTXHdbAvA = -3;
						List<ActionElementMap> list = fGFYcLJhbsojrDDRAufefEutfPmy.list;
						dfNSUgFMHCDtdZFeCDuqIFrPegdV.xbMqqhNCHHsGgJNjWdODBOazhjtNA(OgYAhrIETzrZkHMFtvDjNGMqBtJt, true, KMKBrXauAHHtufyCELtiGjljlJpkc, MAjaOnbQyhpPgbbDRZktArAgjrQjA, list, false, out var _);
						KeTUxXeBLbUVHfYpvdEVOlMjfvHN = list.GetEnumerator();
						pSpgetMDfVGypLjijgShJTXHdbAvA = -4;
						break;
					}
					case 1:
						pSpgetMDfVGypLjijgShJTXHdbAvA = -4;
						break;
					}
					if (KeTUxXeBLbUVHfYpvdEVOlMjfvHN.MoveNext())
					{
						ActionElementMap current = KeTUxXeBLbUVHfYpvdEVOlMjfvHN.Current;
						KLuTCMaUtsbeDUZmIOkdUTlHdkht = current;
						pSpgetMDfVGypLjijgShJTXHdbAvA = 1;
						return true;
					}
					mYzFErFHEnqozbnnReaYVXyaXTQcA();
					KeTUxXeBLbUVHfYpvdEVOlMjfvHN = default(List<ActionElementMap>.Enumerator);
					lPjfbKERzBeFIARVbmVYNGBZvQOUb();
					fGFYcLJhbsojrDDRAufefEutfPmy = null;
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

			private void lPjfbKERzBeFIARVbmVYNGBZvQOUb()
			{
				pSpgetMDfVGypLjijgShJTXHdbAvA = -1;
				if (fGFYcLJhbsojrDDRAufefEutfPmy != null)
				{
					((IDisposable)fGFYcLJhbsojrDDRAufefEutfPmy).Dispose();
				}
			}

			private void mYzFErFHEnqozbnnReaYVXyaXTQcA()
			{
				pSpgetMDfVGypLjijgShJTXHdbAvA = -3;
				((IDisposable)KeTUxXeBLbUVHfYpvdEVOlMjfvHN/*cast due to .constrained prefix*/).Dispose();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}

			[DebuggerHidden]
			IEnumerator<ActionElementMap> IEnumerable<ActionElementMap>.GetEnumerator()
			{
				pXOfCvqRdoVOPRwphslQNdmsLduk pXOfCvqRdoVOPRwphslQNdmsLduk2;
				if (pSpgetMDfVGypLjijgShJTXHdbAvA == -2 && hLqzVOJHKKpwlsuAvqSLTdcREGIX == Environment.CurrentManagedThreadId)
				{
					pSpgetMDfVGypLjijgShJTXHdbAvA = 0;
					pXOfCvqRdoVOPRwphslQNdmsLduk2 = this;
				}
				else
				{
					pXOfCvqRdoVOPRwphslQNdmsLduk2 = new pXOfCvqRdoVOPRwphslQNdmsLduk(0);
					pXOfCvqRdoVOPRwphslQNdmsLduk2.DfNSUgFMHCDtdZFeCDuqIFrPegdV = DfNSUgFMHCDtdZFeCDuqIFrPegdV;
				}
				pXOfCvqRdoVOPRwphslQNdmsLduk2.OgYAhrIETzrZkHMFtvDjNGMqBtJt = fLFqtbIPxgKZCKxGoUUSTmEUHifk;
				pXOfCvqRdoVOPRwphslQNdmsLduk2.KMKBrXauAHHtufyCELtiGjljlJpkc = nxoGlODMxbHSPXfjRcOYtHoVFXdL;
				pXOfCvqRdoVOPRwphslQNdmsLduk2.MAjaOnbQyhpPgbbDRZktArAgjrQjA = MBtgYWdVceMhyQhLzHftboFuJrWh;
				return pXOfCvqRdoVOPRwphslQNdmsLduk2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
			}
		}

		protected int _id;

		protected int _sourceMapId;

		protected int _categoryId;

		protected int _layoutId;

		protected string _name;

		protected Guid _hardwareGuid;

		protected bool _enabled;

		internal readonly int sIwyLhKUWykANTFJFXecFgCmwcwn;

		private readonly AList<ActionElementMap> OLBjOXTjrODnCfjjQFNcEHntujcMA;

		private readonly ReadOnlyCollection<ActionElementMap> ZBaVFCNNHEkoIRkqtePufDFLeAMYA;

		private readonly AList<ActionElementMap> nqwDWFCbTZWaSogAWTqZBPRCjgJwA;

		private readonly ReadOnlyCollection<ActionElementMap> sbArExeIICnTjJxRhbwIvzQXrNwl;

		protected int _playerId = -1;

		protected int _controllerId = -1;

		protected ControllerType _controllerType;

		private static int AAgEjGYFztnKqIesVQNqHWVnnod;

		private static int ZELQnVEUjNPVfwrlKIxGipBHVFxY
		{
			get
			{
				int aAgEjGYFztnKqIesVQNqHWVnnod = AAgEjGYFztnKqIesVQNqHWVnnod;
				if (AAgEjGYFztnKqIesVQNqHWVnnod == int.MaxValue)
				{
					AAgEjGYFztnKqIesVQNqHWVnnod = 0;
					return aAgEjGYFztnKqIesVQNqHWVnnod;
				}
				AAgEjGYFztnKqIesVQNqHWVnnod++;
				return aAgEjGYFztnKqIesVQNqHWVnnod;
			}
		}

		public int id
		{
			get
			{
				if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
				{
					ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
					return -1;
				}
				return _id;
			}
		}

		public int sourceMapId
		{
			get
			{
				if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
				{
					ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
					return -1;
				}
				return _sourceMapId;
			}
			internal set
			{
				_sourceMapId = num;
			}
		}

		public int categoryId
		{
			get
			{
				if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
				{
					ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
					return -1;
				}
				return _categoryId;
			}
			internal set
			{
				_categoryId = num;
			}
		}

		public int layoutId
		{
			get
			{
				if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
				{
					ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
					return -1;
				}
				return _layoutId;
			}
			internal set
			{
				_layoutId = num;
			}
		}

		public string name
		{
			get
			{
				if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
				{
					ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
					return string.Empty;
				}
				return _name;
			}
			internal set
			{
				_name = text;
			}
		}

		public Guid hardwareGuid
		{
			get
			{
				if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
				{
					ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
					return Guid.Empty;
				}
				return _hardwareGuid;
			}
			internal set
			{
				_hardwareGuid = guid;
			}
		}

		public bool enabled
		{
			get
			{
				if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
				{
					ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
					return false;
				}
				return _enabled;
			}
			set
			{
				_enabled = value;
			}
		}

		public int playerId
		{
			get
			{
				if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
				{
					ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
					return -1;
				}
				return _playerId;
			}
			internal set
			{
				_playerId = num;
			}
		}

		public int controllerId
		{
			get
			{
				if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
				{
					ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
					return -1;
				}
				return _controllerId;
			}
			internal set
			{
				_controllerId = num;
			}
		}

		public Controller controller
		{
			get
			{
				if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
				{
					ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
					return null;
				}
				return ReInput.controllers.GetController(_controllerType, _controllerId);
			}
		}

		public ControllerType controllerType
		{
			get
			{
				if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
				{
					ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
					return ControllerType.Keyboard;
				}
				return _controllerType;
			}
		}

		public Player player
		{
			get
			{
				if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
				{
					ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
					return null;
				}
				return ReInput.players.GetPlayer(_playerId);
			}
		}

		public int elementMapCount
		{
			get
			{
				if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
				{
					ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
					return 0;
				}
				return nqwDWFCbTZWaSogAWTqZBPRCjgJwA.Count;
			}
		}

		public int buttonMapCount
		{
			get
			{
				if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
				{
					ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
					return 0;
				}
				return OLBjOXTjrODnCfjjQFNcEHntujcMA.Count;
			}
		}

		public IList<ActionElementMap> AllMaps
		{
			get
			{
				if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
				{
					ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
					return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
				}
				return sbArExeIICnTjJxRhbwIvzQXrNwl;
			}
		}

		public IList<ActionElementMap> ButtonMaps
		{
			get
			{
				if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
				{
					ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
					return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
				}
				return ZBaVFCNNHEkoIRkqtePufDFLeAMYA;
			}
		}

		internal AList<ActionElementMap> OEydHsjiiTRjhFtrBfeqPfyluIMc => OLBjOXTjrODnCfjjQFNcEHntujcMA;

		public ControllerMap()
		{
			_id = ZELQnVEUjNPVfwrlKIxGipBHVFxY;
			_sourceMapId = -1;
			OLBjOXTjrODnCfjjQFNcEHntujcMA = new AList<ActionElementMap>();
			ZBaVFCNNHEkoIRkqtePufDFLeAMYA = new ReadOnlyCollection<ActionElementMap>(OLBjOXTjrODnCfjjQFNcEHntujcMA);
			nqwDWFCbTZWaSogAWTqZBPRCjgJwA = new AList<ActionElementMap>();
			sbArExeIICnTjJxRhbwIvzQXrNwl = new ReadOnlyCollection<ActionElementMap>(nqwDWFCbTZWaSogAWTqZBPRCjgJwA);
			sIwyLhKUWykANTFJFXecFgCmwcwn = ReInput.id;
		}

		public ControllerMap(ControllerMap P_0)
			: this()
		{
			_id = ZELQnVEUjNPVfwrlKIxGipBHVFxY;
			_sourceMapId = P_0._sourceMapId;
			_categoryId = P_0._categoryId;
			_layoutId = P_0._layoutId;
			_name = P_0._name;
			_hardwareGuid = P_0._hardwareGuid;
			_enabled = P_0._enabled;
			_playerId = P_0._playerId;
			_controllerId = P_0._controllerId;
			_controllerType = P_0._controllerType;
			if (P_0.OLBjOXTjrODnCfjjQFNcEHntujcMA != null)
			{
				int count = P_0.OLBjOXTjrODnCfjjQFNcEHntujcMA.Count;
				for (int i = 0; i < count; i++)
				{
					UjFPpMLIGPNFXMBKzeSemCEngJih(new ActionElementMap(P_0.OLBjOXTjrODnCfjjQFNcEHntujcMA[i]));
				}
			}
		}

		public bool ContainsAction(string actionName)
		{
			if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
			{
				ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
				return false;
			}
			InputAction inputAction = ReInput.xKokvIxOzcvermvcSUcNKZIGamDS.QKCYqwFmItpkITKiPWYYxsvfwMVD(actionName, true);
			if (inputAction == null)
			{
				return false;
			}
			return ContainsAction(inputAction.id);
		}

		public virtual bool ContainsAction(int actionId)
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
			int num = buttonMapCount;
			for (int i = 0; i < num; i++)
			{
				if (OLBjOXTjrODnCfjjQFNcEHntujcMA[i]._actionId == actionId)
				{
					return true;
				}
			}
			return false;
		}

		public bool ContainsElementIdentifier(int elementIdentifierId)
		{
			if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
			{
				ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
				return false;
			}
			AList<ActionElementMap> aList = nqwDWFCbTZWaSogAWTqZBPRCjgJwA;
			for (int i = 0; i < aList.Count; i++)
			{
				if (nqwDWFCbTZWaSogAWTqZBPRCjgJwA[i].elementIdentifierId == elementIdentifierId)
				{
					return true;
				}
			}
			return false;
		}

		public bool ContainsKeyboardKey(KeyCode keyCode, ModifierKeyFlags modifierKeys)
		{
			if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
			{
				ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
				return false;
			}
			AList<ActionElementMap> aList = nqwDWFCbTZWaSogAWTqZBPRCjgJwA;
			for (int i = 0; i < aList.Count; i++)
			{
				if (nqwDWFCbTZWaSogAWTqZBPRCjgJwA[i].keyCode == keyCode && nqwDWFCbTZWaSogAWTqZBPRCjgJwA[i].modifierKeyFlags == modifierKeys)
				{
					return true;
				}
			}
			return false;
		}

		public bool ContainsElementMap(ActionElementMap elementMap)
		{
			if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
			{
				ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
				return false;
			}
			if (elementMap == null)
			{
				return false;
			}
			AList<ActionElementMap> aList = nqwDWFCbTZWaSogAWTqZBPRCjgJwA;
			for (int i = 0; i < aList.Count; i++)
			{
				if (nqwDWFCbTZWaSogAWTqZBPRCjgJwA[i].oFUAyzlkDBdPoonWGgEIgJYWTzJOA == elementMap.id)
				{
					return true;
				}
			}
			return false;
		}

		public bool ContainsElementMap(int elementMapId)
		{
			if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
			{
				ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
				return false;
			}
			AList<ActionElementMap> aList = nqwDWFCbTZWaSogAWTqZBPRCjgJwA;
			for (int i = 0; i < aList.Count; i++)
			{
				if (nqwDWFCbTZWaSogAWTqZBPRCjgJwA[i].oFUAyzlkDBdPoonWGgEIgJYWTzJOA == elementMapId)
				{
					return true;
				}
			}
			return false;
		}

		public bool ReplaceOrCreateElementMap(ElementAssignment elementAssignment)
		{
			if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
			{
				ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
				return false;
			}
			ActionElementMap result;
			return ReplaceOrCreateElementMap(elementAssignment, out result);
		}

		public bool ReplaceOrCreateElementMap(ElementAssignment elementAssignment, out ActionElementMap result)
		{
			if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
			{
				ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
				result = null;
				return false;
			}
			if (GetElementMap(elementAssignment.elementMapId) == null)
			{
				return CreateElementMap(elementAssignment, out result);
			}
			return ReplaceElementMap(elementAssignment, out result);
		}

		public bool CreateElementMap(ElementAssignment elementAssignment)
		{
			if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
			{
				ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
				return false;
			}
			ActionElementMap result;
			return CreateElementMap(elementAssignment, out result);
		}

		public bool CreateElementMap(ElementAssignment elementAssignment, out ActionElementMap result)
		{
			if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
			{
				ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
				result = null;
				return false;
			}
			if (_controllerType == ControllerType.Keyboard)
			{
				return CreateElementMap(elementAssignment.actionId, elementAssignment.axisContribution, elementAssignment.keyboardKey, elementAssignment.modifierKeyFlags, out result);
			}
			if (_controllerType == ControllerType.Joystick || _controllerType == ControllerType.Mouse || _controllerType == ControllerType.Custom)
			{
				return CreateElementMap(elementAssignment.actionId, elementAssignment.axisContribution, elementAssignment.elementIdentifierId, pMvvECjJycyKibKKCAXEnFbBPTVk.xNeYpGuJHefJZlyNqQjEMgcfdnoC(elementAssignment.type), elementAssignment.axisRange, elementAssignment.invert, out result);
			}
			throw new NotImplementedException();
		}

		public bool CreateElementMap(int actionId, Pole axisContribution, KeyCode keyCode, ModifierKey modifierKey1, ModifierKey modifierKey2, ModifierKey modifierKey3)
		{
			ActionElementMap result;
			return CreateElementMap(actionId, axisContribution, keyCode, modifierKey1, modifierKey2, modifierKey3, out result);
		}

		public bool CreateElementMap(int actionId, Pole axisContribution, KeyCode keyCode, ModifierKey modifierKey1, ModifierKey modifierKey2, ModifierKey modifierKey3, out ActionElementMap result)
		{
			if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
			{
				ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
				result = null;
				return false;
			}
			ActionElementMap actionElementMap = new ActionElementMap(actionId, ControllerElementType.Button, axisContribution, (KeyboardKeyCode)keyCode, modifierKey1, modifierKey2, modifierKey3);
			ReInput.controllers.Keyboard.YTencsjPWuJIOCxnxAitAELcIHlkA(this, actionElementMap);
			UjFPpMLIGPNFXMBKzeSemCEngJih(actionElementMap);
			result = actionElementMap;
			return true;
		}

		public bool CreateElementMap(int actionId, Pole axisContribution, KeyCode keyCode, ModifierKeyFlags modifierKeyFlags)
		{
			ActionElementMap result;
			return CreateElementMap(actionId, axisContribution, keyCode, modifierKeyFlags, out result);
		}

		public bool CreateElementMap(int actionId, Pole axisContribution, KeyCode keyCode, ModifierKeyFlags modifierKeyFlags, out ActionElementMap result)
		{
			if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
			{
				ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
				result = null;
				return false;
			}
			ZPVsRLOVehcYHdMMyiljMkYjJpbm zPVsRLOVehcYHdMMyiljMkYjJpbm = ZPVsRLOVehcYHdMMyiljMkYjJpbm.KDMWJSOVpaZWZcfXiUQIwKOlqqAd(modifierKeyFlags);
			return CreateElementMap(actionId, axisContribution, keyCode, zPVsRLOVehcYHdMMyiljMkYjJpbm.UqWZutphnsHnpZcIfXAFuWTpIwas, zPVsRLOVehcYHdMMyiljMkYjJpbm.xsbhpMhZfeHdYEdcPMBfEqdcpqioB, zPVsRLOVehcYHdMMyiljMkYjJpbm.WswJlGEkhOTxSYCPsunHajaDUyBl, out result);
		}

		public bool CreateElementMap(int actionId, Pole axisContribution, int elementIdentifierId, ControllerElementType elementType, AxisRange axisRange, bool invert)
		{
			ActionElementMap result;
			return CreateElementMap(actionId, axisContribution, elementIdentifierId, elementType, axisRange, invert, out result);
		}

		public virtual bool CreateElementMap(int actionId, Pole axisContribution, int elementIdentifierId, ControllerElementType elementType, AxisRange axisRange, bool invert, out ActionElementMap result)
		{
			if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
			{
				ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
				result = null;
				return false;
			}
			if (!VBrjUaVMXeCqeEfUtJcanLXwEzSy(elementType))
			{
				result = null;
				return false;
			}
			ActionElementMap actionElementMap = new ActionElementMap(actionId, elementType, elementIdentifierId, axisContribution, axisRange);
			BakeElementMap(actionElementMap);
			UjFPpMLIGPNFXMBKzeSemCEngJih(actionElementMap);
			result = actionElementMap;
			return true;
		}

		public bool ReplaceElementMap(ElementAssignment elementAssignment)
		{
			ActionElementMap result;
			return ReplaceElementMap(elementAssignment, out result);
		}

		public bool ReplaceElementMap(ElementAssignment elementAssignment, out ActionElementMap result)
		{
			if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
			{
				ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
				result = null;
				return false;
			}
			if (_controllerType == ControllerType.Keyboard)
			{
				return ReplaceElementMap(elementAssignment.elementMapId, elementAssignment.actionId, elementAssignment.axisContribution, elementAssignment.keyboardKey, elementAssignment.modifierKeyFlags, out result);
			}
			if (_controllerType == ControllerType.Joystick || _controllerType == ControllerType.Mouse || _controllerType == ControllerType.Custom)
			{
				return ReplaceElementMap(elementAssignment.elementMapId, elementAssignment.actionId, elementAssignment.axisContribution, elementAssignment.elementIdentifierId, pMvvECjJycyKibKKCAXEnFbBPTVk.xNeYpGuJHefJZlyNqQjEMgcfdnoC(elementAssignment.type), elementAssignment.axisRange, elementAssignment.invert, out result);
			}
			throw new NotImplementedException();
		}

		public bool ReplaceElementMap(int elementMapId, int actionId, Pole axisContribution, KeyCode keyCode, ModifierKey modifierKey1, ModifierKey modifierKey2, ModifierKey modifierKey3)
		{
			ActionElementMap result;
			return ReplaceElementMap(elementMapId, actionId, axisContribution, keyCode, modifierKey1, modifierKey2, modifierKey3, out result);
		}

		public bool ReplaceElementMap(int elementMapId, int actionId, Pole axisContribution, KeyCode keyCode, ModifierKey modifierKey1, ModifierKey modifierKey2, ModifierKey modifierKey3, out ActionElementMap result)
		{
			if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
			{
				ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
				result = null;
				return false;
			}
			ActionElementMap elementMap = GetElementMap(elementMapId);
			if (elementMap == null)
			{
				result = null;
				return false;
			}
			if (PHzoxgTXPEKhZsgoASpWqpVluZvV(elementMapId) < 0)
			{
				DeleteElementMap(elementMapId);
				elementMap._elementType = ControllerElementType.Button;
				UjFPpMLIGPNFXMBKzeSemCEngJih(elementMap);
			}
			if (PHzoxgTXPEKhZsgoASpWqpVluZvV(elementMapId) < 0)
			{
				result = null;
				return false;
			}
			elementMap.qiOiajljPpDlMenubKTEdMYtXaRGA();
			elementMap._actionId = actionId;
			elementMap._elementType = ControllerElementType.Button;
			elementMap._axisContribution = axisContribution;
			elementMap._keyboardKeyCode = (KeyboardKeyCode)keyCode;
			elementMap._modifierKey1 = modifierKey1;
			elementMap._modifierKey2 = modifierKey2;
			elementMap._modifierKey3 = modifierKey3;
			ReInput.controllers.Keyboard.YTencsjPWuJIOCxnxAitAELcIHlkA(this, elementMap);
			result = elementMap;
			return true;
		}

		public bool ReplaceElementMap(int elementMapId, int actionId, Pole axisContribution, KeyCode keyCode, ModifierKeyFlags modifierKeyFlags)
		{
			ActionElementMap result;
			return ReplaceElementMap(elementMapId, actionId, axisContribution, keyCode, modifierKeyFlags, out result);
		}

		public bool ReplaceElementMap(int elementMapId, int actionId, Pole axisContribution, KeyCode keyCode, ModifierKeyFlags modifierKeyFlags, out ActionElementMap result)
		{
			ZPVsRLOVehcYHdMMyiljMkYjJpbm zPVsRLOVehcYHdMMyiljMkYjJpbm = ZPVsRLOVehcYHdMMyiljMkYjJpbm.KDMWJSOVpaZWZcfXiUQIwKOlqqAd(modifierKeyFlags);
			return ReplaceElementMap(elementMapId, actionId, axisContribution, keyCode, zPVsRLOVehcYHdMMyiljMkYjJpbm.UqWZutphnsHnpZcIfXAFuWTpIwas, zPVsRLOVehcYHdMMyiljMkYjJpbm.xsbhpMhZfeHdYEdcPMBfEqdcpqioB, zPVsRLOVehcYHdMMyiljMkYjJpbm.WswJlGEkhOTxSYCPsunHajaDUyBl, out result);
		}

		public bool ReplaceElementMap(int elementMapId, int actionId, Pole axisContribution, int elementIdentifierId, ControllerElementType elementType, AxisRange axisRange, bool invert)
		{
			ActionElementMap result;
			return ReplaceElementMap(elementMapId, actionId, axisContribution, elementIdentifierId, elementType, axisRange, invert, out result);
		}

		public virtual bool ReplaceElementMap(int elementMapId, int actionId, Pole axisContribution, int elementIdentifierId, ControllerElementType elementType, AxisRange axisRange, bool invert, out ActionElementMap result)
		{
			if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
			{
				ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
				result = null;
				return false;
			}
			if (!VBrjUaVMXeCqeEfUtJcanLXwEzSy(elementType))
			{
				result = null;
				return false;
			}
			ActionElementMap elementMap = GetElementMap(elementMapId);
			if (elementMap == null)
			{
				result = null;
				return false;
			}
			if (!VBrjUaVMXeCqeEfUtJcanLXwEzSy(elementMap._elementType))
			{
				DeleteElementMap(elementMapId);
				elementMap._elementType = ControllerElementType.Button;
				UjFPpMLIGPNFXMBKzeSemCEngJih(elementMap);
			}
			if (PHzoxgTXPEKhZsgoASpWqpVluZvV(elementMapId) < 0)
			{
				result = null;
				return false;
			}
			OAEjdeCzQqxOtbOqaiobZETGzJNH(elementMap, actionId, axisContribution, elementIdentifierId, elementType, axisRange, invert);
			BakeElementMap(elementMap);
			result = elementMap;
			return true;
		}

		public virtual bool DeleteElementMap(int elementMapId)
		{
			if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
			{
				ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
				return false;
			}
			int num = PHzoxgTXPEKhZsgoASpWqpVluZvV(elementMapId);
			if (num < 0)
			{
				return false;
			}
			YdhMeMhAlyxceGmINjjMNWOOSnwI(elementMapId, num);
			return true;
		}

		public virtual bool DeleteElementMapsWithAction(string actionName)
		{
			return DeleteElementMapsWithAction(ReInput.xKokvIxOzcvermvcSUcNKZIGamDS.rnRgZqWgdruGSKkLVaIxIODNYhyJA(actionName));
		}

		public virtual bool DeleteElementMapsWithAction(int actionId)
		{
			return DeleteButtonMapsWithAction(actionId);
		}

		public virtual ActionElementMap GetElementMap(int elementMapId)
		{
			if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
			{
				ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
				return null;
			}
			if (elementMapId < 0)
			{
				return null;
			}
			int num = buttonMapCount;
			for (int i = 0; i < num; i++)
			{
				if (OLBjOXTjrODnCfjjQFNcEHntujcMA[i].oFUAyzlkDBdPoonWGgEIgJYWTzJOA == elementMapId)
				{
					return OLBjOXTjrODnCfjjQFNcEHntujcMA[i];
				}
			}
			return null;
		}

		public ActionElementMap[] GetElementMaps()
		{
			return GetElementMaps(skipDisabledMaps: false);
		}

		public ActionElementMap[] GetElementMaps(bool skipDisabledMaps)
		{
			if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
			{
				ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
				return EmptyObjects<ActionElementMap>.array;
			}
			int num = elementMapCount;
			if (num == 0)
			{
				return EmptyObjects<ActionElementMap>.array;
			}
			List<ActionElementMap> list = new List<ActionElementMap>(num);
			foreach (ActionElementMap allMap in AllMaps)
			{
				if (!skipDisabledMaps || allMap.dQASdaEFVJzbOgxgKEdsYSDArFzi)
				{
					list.Add(allMap);
				}
			}
			return list.ToArray();
		}

		public int GetElementMaps(List<ActionElementMap> results)
		{
			return GetElementMaps(skipDisabledMaps: false, results);
		}

		public int GetElementMaps(bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
			{
				ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
				return 0;
			}
			if (results == null)
			{
				throw new ArgumentNullException("results");
			}
			results.Clear();
			return hdOLzuxCVTtDRXVQrCeluNkEWcfA(results, skipDisabledMaps);
		}

		public ActionElementMap[] GetElementMapsWithAction(string actionName)
		{
			if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
			{
				ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
				return EmptyObjects<ActionElementMap>.array;
			}
			int actionId = ReInput.xKokvIxOzcvermvcSUcNKZIGamDS.rnRgZqWgdruGSKkLVaIxIODNYhyJA(actionName);
			return GetElementMapsWithAction(actionId);
		}

		public ActionElementMap[] GetElementMapsWithAction(int actionId)
		{
			return GetElementMapsWithAction(actionId, skipDisabledMaps: false);
		}

		public ActionElementMap[] GetElementMapsWithAction(string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
			{
				ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
				return EmptyObjects<ActionElementMap>.array;
			}
			int actionId = ReInput.xKokvIxOzcvermvcSUcNKZIGamDS.rnRgZqWgdruGSKkLVaIxIODNYhyJA(actionName);
			return GetElementMapsWithAction(actionId, skipDisabledMaps);
		}

		public ActionElementMap[] GetElementMapsWithAction(int actionId, bool skipDisabledMaps)
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
			if (elementMapCount == 0)
			{
				return EmptyObjects<ActionElementMap>.array;
			}
			int num = 0;
			foreach (ActionElementMap allMap in AllMaps)
			{
				if (allMap._actionId == actionId && (!skipDisabledMaps || allMap.dQASdaEFVJzbOgxgKEdsYSDArFzi))
				{
					num++;
				}
			}
			if (num == 0)
			{
				return EmptyObjects<ActionElementMap>.array;
			}
			ActionElementMap[] array = new ActionElementMap[num];
			int num2 = 0;
			foreach (ActionElementMap allMap2 in AllMaps)
			{
				if (allMap2._actionId == actionId && (!skipDisabledMaps || allMap2.dQASdaEFVJzbOgxgKEdsYSDArFzi))
				{
					array[num2] = allMap2;
					num2++;
				}
			}
			return array;
		}

		public int GetElementMapsWithAction(string actionName, List<ActionElementMap> results)
		{
			if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
			{
				ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
				return 0;
			}
			int actionId = ReInput.xKokvIxOzcvermvcSUcNKZIGamDS.rnRgZqWgdruGSKkLVaIxIODNYhyJA(actionName);
			return GetElementMapsWithAction(actionId, results);
		}

		public int GetElementMapsWithAction(int actionId, List<ActionElementMap> results)
		{
			return GetElementMapsWithAction(actionId, skipDisabledMaps: false, results);
		}

		public int GetElementMapsWithAction(string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
			{
				ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
				return 0;
			}
			int actionId = ReInput.xKokvIxOzcvermvcSUcNKZIGamDS.rnRgZqWgdruGSKkLVaIxIODNYhyJA(actionName);
			return GetElementMapsWithAction(actionId, skipDisabledMaps, results);
		}

		public int GetElementMapsWithAction(int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			return TPGoRsOaoYnEGuXZQSOypYbEQESv(actionId, skipDisabledMaps, results, false);
		}

		public IEnumerable<ActionElementMap> ElementMapsWithAction(string actionName)
		{
			if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
			{
				ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			int actionId = ReInput.xKokvIxOzcvermvcSUcNKZIGamDS.rnRgZqWgdruGSKkLVaIxIODNYhyJA(actionName);
			return ElementMapsWithAction(actionId);
		}

		public IEnumerable<ActionElementMap> ElementMapsWithAction(int actionId)
		{
			return ElementMapsWithAction(actionId, skipDisabledMaps: false);
		}

		public IEnumerable<ActionElementMap> ElementMapsWithAction(string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
			{
				ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			int actionId = ReInput.xKokvIxOzcvermvcSUcNKZIGamDS.rnRgZqWgdruGSKkLVaIxIODNYhyJA(actionName);
			return ElementMapsWithAction(actionId, skipDisabledMaps);
		}

		[IteratorStateMachine(typeof(XgnElpmNADboXfqEhYgUcnESUSfMA))]
		public IEnumerable<ActionElementMap> ElementMapsWithAction(int actionId, bool skipDisabledMaps)
		{
			return new XgnElpmNADboXfqEhYgUcnESUSfMA(-2)
			{
				QnsnhXfQYueQnAxreSRUlVUjJoOs = this,
				LRBISmCkeHwLKeCMcjEEBxsRQMbe = actionId,
				WhdfGAyXuWIWAGqhZOQausLxFeLhA = skipDisabledMaps
			};
		}

		public virtual ActionElementMap GetFirstElementMapWithAction(int actionId)
		{
			return GetFirstElementMapWithAction(actionId, skipDisabledMaps: false);
		}

		public virtual ActionElementMap GetFirstElementMapWithAction(string actionName)
		{
			if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
			{
				ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
				return null;
			}
			int actionId = ReInput.xKokvIxOzcvermvcSUcNKZIGamDS.rnRgZqWgdruGSKkLVaIxIODNYhyJA(actionName);
			return GetFirstElementMapWithAction(actionId);
		}

		public virtual ActionElementMap GetFirstElementMapWithAction(int actionId, bool skipDisabledMaps)
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
			int num = buttonMapCount;
			for (int i = 0; i < num; i++)
			{
				if (OLBjOXTjrODnCfjjQFNcEHntujcMA[i]._actionId == actionId && (!skipDisabledMaps || OLBjOXTjrODnCfjjQFNcEHntujcMA[i].dQASdaEFVJzbOgxgKEdsYSDArFzi))
				{
					return OLBjOXTjrODnCfjjQFNcEHntujcMA[i];
				}
			}
			return null;
		}

		public ActionElementMap GetFirstElementMapWithAction(string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
			{
				ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
				return null;
			}
			int actionId = ReInput.xKokvIxOzcvermvcSUcNKZIGamDS.rnRgZqWgdruGSKkLVaIxIODNYhyJA(actionName);
			return GetFirstElementMapWithAction(actionId, skipDisabledMaps);
		}

		public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(ControllerElementTarget elementTarget, bool skipDisabledMaps)
		{
			if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
			{
				ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			VpAKgrswCxoCdmGxzoexhctSYmGI vpAKgrswCxoCdmGxzoexhctSYmGI = VpAKgrswCxoCdmGxzoexhctSYmGI.xDAKHQNoHKFqiySCGMtHCjfpzmMo(elementTarget);
			IEnumerable<ActionElementMap> result = ElementMapsWithElementTarget(vpAKgrswCxoCdmGxzoexhctSYmGI, skipDisabledMaps);
			VpAKgrswCxoCdmGxzoexhctSYmGI.wzXUUXuVeUiCeyrUltjgkXWqnwcc(vpAKgrswCxoCdmGxzoexhctSYmGI);
			return result;
		}

		[IteratorStateMachine(typeof(dtuDyaDTqppQBTkXpKVyJjBIuDLX))]
		public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(IControllerElementTarget elementTarget, bool skipDisabledMaps)
		{
			return new dtuDyaDTqppQBTkXpKVyJjBIuDLX(-2)
			{
				cusCyMLRWzxzrBfuWnxFuFihXokc = this,
				MCXxLzKanBfWQDGCBaAcinGXTFVHA = elementTarget,
				TGOhJIGAEjhQDRgbwygrrSuzLazG = skipDisabledMaps
			};
		}

		public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(ControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
			{
				ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			VpAKgrswCxoCdmGxzoexhctSYmGI vpAKgrswCxoCdmGxzoexhctSYmGI = VpAKgrswCxoCdmGxzoexhctSYmGI.xDAKHQNoHKFqiySCGMtHCjfpzmMo(elementTarget);
			IEnumerable<ActionElementMap> result = ElementMapsWithElementTarget(vpAKgrswCxoCdmGxzoexhctSYmGI, actionId, skipDisabledMaps);
			VpAKgrswCxoCdmGxzoexhctSYmGI.wzXUUXuVeUiCeyrUltjgkXWqnwcc(vpAKgrswCxoCdmGxzoexhctSYmGI);
			return result;
		}

		public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(ControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
			{
				ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			int actionId = ReInput.xKokvIxOzcvermvcSUcNKZIGamDS.rnRgZqWgdruGSKkLVaIxIODNYhyJA(actionName);
			return ElementMapsWithElementTarget(elementTarget, actionId, skipDisabledMaps);
		}

		[IteratorStateMachine(typeof(pXOfCvqRdoVOPRwphslQNdmsLduk))]
		public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(IControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps)
		{
			return new pXOfCvqRdoVOPRwphslQNdmsLduk(-2)
			{
				DfNSUgFMHCDtdZFeCDuqIFrPegdV = this,
				fLFqtbIPxgKZCKxGoUUSTmEUHifk = elementTarget,
				nxoGlODMxbHSPXfjRcOYtHoVFXdL = actionId,
				MBtgYWdVceMhyQhLzHftboFuJrWh = skipDisabledMaps
			};
		}

		public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(IControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
			{
				ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			int actionId = ReInput.xKokvIxOzcvermvcSUcNKZIGamDS.rnRgZqWgdruGSKkLVaIxIODNYhyJA(actionName);
			return ElementMapsWithElementTarget(elementTarget, actionId, skipDisabledMaps);
		}

		public ActionElementMap GetFirstElementMapWithElementTarget(ControllerElementTarget elementTarget, bool skipDisabledMaps)
		{
			if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
			{
				ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
				return null;
			}
			VpAKgrswCxoCdmGxzoexhctSYmGI vpAKgrswCxoCdmGxzoexhctSYmGI = VpAKgrswCxoCdmGxzoexhctSYmGI.xDAKHQNoHKFqiySCGMtHCjfpzmMo(elementTarget);
			ActionElementMap firstElementMapWithElementTarget = GetFirstElementMapWithElementTarget(vpAKgrswCxoCdmGxzoexhctSYmGI, skipDisabledMaps);
			VpAKgrswCxoCdmGxzoexhctSYmGI.wzXUUXuVeUiCeyrUltjgkXWqnwcc(vpAKgrswCxoCdmGxzoexhctSYmGI);
			return firstElementMapWithElementTarget;
		}

		public ActionElementMap GetFirstElementMapWithElementTarget(IControllerElementTarget elementTarget, bool skipDisabledMaps)
		{
			if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
			{
				ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
				return null;
			}
			bool flag;
			return ULkNEiizKoMslClQddTEvQaQhqGD(elementTarget, false, -1, skipDisabledMaps, out flag);
		}

		public ActionElementMap GetFirstElementMapWithElementTarget(ControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
			{
				ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
				return null;
			}
			VpAKgrswCxoCdmGxzoexhctSYmGI vpAKgrswCxoCdmGxzoexhctSYmGI = VpAKgrswCxoCdmGxzoexhctSYmGI.xDAKHQNoHKFqiySCGMtHCjfpzmMo(elementTarget);
			ActionElementMap firstElementMapWithElementTarget = GetFirstElementMapWithElementTarget(vpAKgrswCxoCdmGxzoexhctSYmGI, actionId, skipDisabledMaps);
			VpAKgrswCxoCdmGxzoexhctSYmGI.wzXUUXuVeUiCeyrUltjgkXWqnwcc(vpAKgrswCxoCdmGxzoexhctSYmGI);
			return firstElementMapWithElementTarget;
		}

		public ActionElementMap GetFirstElementMapWithElementTarget(ControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
			{
				ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
				return null;
			}
			int actionId = ReInput.xKokvIxOzcvermvcSUcNKZIGamDS.rnRgZqWgdruGSKkLVaIxIODNYhyJA(actionName);
			return GetFirstElementMapWithElementTarget(elementTarget, actionId, skipDisabledMaps);
		}

		public ActionElementMap GetFirstElementMapWithElementTarget(IControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
			{
				ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
				return null;
			}
			bool flag;
			return ULkNEiizKoMslClQddTEvQaQhqGD(elementTarget, true, actionId, skipDisabledMaps, out flag);
		}

		public ActionElementMap GetFirstElementMapWithElementTarget(IControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
			{
				ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
				return null;
			}
			int actionId = ReInput.xKokvIxOzcvermvcSUcNKZIGamDS.rnRgZqWgdruGSKkLVaIxIODNYhyJA(actionName);
			return GetFirstElementMapWithElementTarget(elementTarget, actionId, skipDisabledMaps);
		}

		public int GetElementMapsWithElementTarget(ControllerElementTarget elementTarget, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
			{
				ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
				return 0;
			}
			VpAKgrswCxoCdmGxzoexhctSYmGI vpAKgrswCxoCdmGxzoexhctSYmGI = VpAKgrswCxoCdmGxzoexhctSYmGI.xDAKHQNoHKFqiySCGMtHCjfpzmMo(elementTarget);
			int elementMapsWithElementTarget = GetElementMapsWithElementTarget(vpAKgrswCxoCdmGxzoexhctSYmGI, skipDisabledMaps, results);
			VpAKgrswCxoCdmGxzoexhctSYmGI.wzXUUXuVeUiCeyrUltjgkXWqnwcc(vpAKgrswCxoCdmGxzoexhctSYmGI);
			return elementMapsWithElementTarget;
		}

		public int GetElementMapsWithElementTarget(IControllerElementTarget elementTarget, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
			{
				ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
				return 0;
			}
			bool flag;
			return xbMqqhNCHHsGgJNjWdODBOazhjtNA(elementTarget, false, -1, skipDisabledMaps, results, false, out flag);
		}

		public int GetElementMapsWithElementTarget(ControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
			{
				ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
				return 0;
			}
			VpAKgrswCxoCdmGxzoexhctSYmGI vpAKgrswCxoCdmGxzoexhctSYmGI = VpAKgrswCxoCdmGxzoexhctSYmGI.xDAKHQNoHKFqiySCGMtHCjfpzmMo(elementTarget);
			int elementMapsWithElementTarget = GetElementMapsWithElementTarget(vpAKgrswCxoCdmGxzoexhctSYmGI, actionId, skipDisabledMaps, results);
			VpAKgrswCxoCdmGxzoexhctSYmGI.wzXUUXuVeUiCeyrUltjgkXWqnwcc(vpAKgrswCxoCdmGxzoexhctSYmGI);
			return elementMapsWithElementTarget;
		}

		public int GetElementMapsWithElementTarget(ControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
			{
				ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
				return 0;
			}
			int actionId = ReInput.xKokvIxOzcvermvcSUcNKZIGamDS.rnRgZqWgdruGSKkLVaIxIODNYhyJA(actionName);
			return GetElementMapsWithElementTarget(elementTarget, actionId, skipDisabledMaps, results);
		}

		public int GetElementMapsWithElementTarget(IControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
			{
				ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
				return 0;
			}
			bool flag;
			return xbMqqhNCHHsGgJNjWdODBOazhjtNA(elementTarget, true, actionId, skipDisabledMaps, results, false, out flag);
		}

		public int GetElementMapsWithElementTarget(IControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
			{
				ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
				return 0;
			}
			int actionId = ReInput.xKokvIxOzcvermvcSUcNKZIGamDS.rnRgZqWgdruGSKkLVaIxIODNYhyJA(actionName);
			return GetElementMapsWithElementTarget(elementTarget, actionId, skipDisabledMaps, results);
		}

		public ActionElementMap GetFirstElementMapMatch(Predicate<ActionElementMap> predicate)
		{
			if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
			{
				ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
				return null;
			}
			return qAPFJyhkBScmgnBBqlDdXpxMklPt(predicate, false);
		}

		internal virtual ActionElementMap qAPFJyhkBScmgnBBqlDdXpxMklPt(Predicate<ActionElementMap> P_0, bool P_1)
		{
			return QtnEqzVBvAmVtpoZREcYgpHeKwRU(P_0, P_1);
		}

		public int GetElementMapMatches(Predicate<ActionElementMap> predicate, List<ActionElementMap> results)
		{
			if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
			{
				ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
				return 0;
			}
			return cFulEPyEyuvDaKDZVGFiRtAbJTCy(predicate, false, results, false);
		}

		internal virtual int cFulEPyEyuvDaKDZVGFiRtAbJTCy(Predicate<ActionElementMap> P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			return JkkoEqKhDGvTJYbjIrWqXRDCJNtE(P_0, P_1, P_2, P_3);
		}

		public void ForEachElementMapMatch(Predicate<ActionElementMap> predicate, Action<ActionElementMap> actionToPerform)
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
			int count = nqwDWFCbTZWaSogAWTqZBPRCjgJwA.Count;
			try
			{
				for (int i = 0; i < count; i++)
				{
					ActionElementMap obj = nqwDWFCbTZWaSogAWTqZBPRCjgJwA[i];
					if (predicate(obj))
					{
						actionToPerform(obj);
					}
				}
			}
			catch (Exception exception)
			{
				ReInput.HandleCallbackException("ControllerMap.ForEachElementMapMatch", exception);
			}
		}

		public virtual void ClearElementMaps()
		{
			if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
			{
				ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
				return;
			}
			OLBjOXTjrODnCfjjQFNcEHntujcMA.Clear();
			nqwDWFCbTZWaSogAWTqZBPRCjgJwA.Clear();
		}

		public int SetAllElementMapsEnabled(bool state)
		{
			if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
			{
				ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
				return 0;
			}
			int num = 0;
			int count = nqwDWFCbTZWaSogAWTqZBPRCjgJwA.Count;
			for (int i = 0; i < count; i++)
			{
				ActionElementMap actionElementMap = nqwDWFCbTZWaSogAWTqZBPRCjgJwA[i];
				if (actionElementMap.dQASdaEFVJzbOgxgKEdsYSDArFzi != state)
				{
					actionElementMap.dQASdaEFVJzbOgxgKEdsYSDArFzi = state;
					num++;
				}
			}
			return num;
		}

		public ActionElementMap GetButtonMap(int index)
		{
			if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
			{
				ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
				return null;
			}
			if (OLBjOXTjrODnCfjjQFNcEHntujcMA == null || index < 0 || index >= OLBjOXTjrODnCfjjQFNcEHntujcMA.Count)
			{
				return null;
			}
			return OLBjOXTjrODnCfjjQFNcEHntujcMA[index];
		}

		public ActionElementMap[] GetButtonMaps()
		{
			if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
			{
				ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
				return EmptyObjects<ActionElementMap>.array;
			}
			return ListTools.ToArray(OLBjOXTjrODnCfjjQFNcEHntujcMA);
		}

		public ActionElementMap[] GetButtonMaps(bool skipDisabledMaps)
		{
			if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
			{
				ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
				return EmptyObjects<ActionElementMap>.array;
			}
			int count = OLBjOXTjrODnCfjjQFNcEHntujcMA.Count;
			List<ActionElementMap> list = new List<ActionElementMap>(count);
			for (int i = 0; i < count; i++)
			{
				ActionElementMap actionElementMap = OLBjOXTjrODnCfjjQFNcEHntujcMA[i];
				if (!skipDisabledMaps || actionElementMap.dQASdaEFVJzbOgxgKEdsYSDArFzi)
				{
					list.Add(actionElementMap);
				}
			}
			return list.ToArray();
		}

		public int GetButtonMaps(bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
			{
				ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
				return 0;
			}
			return lbQyezPhNMHiUnRQKhigUytwLgSB(skipDisabledMaps, results, false);
		}

		public ActionElementMap[] GetButtonMapsWithAction(string actionName)
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
			return GetButtonMapsWithAction(inputAction.id);
		}

		public ActionElementMap[] GetButtonMapsWithAction(int actionId)
		{
			return GetButtonMapsWithAction(actionId, skipDisabledMaps: false);
		}

		public ActionElementMap[] GetButtonMapsWithAction(string actionName, bool skipDisabledMaps)
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
			return GetButtonMapsWithAction(inputAction.id, skipDisabledMaps);
		}

		public ActionElementMap[] GetButtonMapsWithAction(int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
			{
				ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
				return EmptyObjects<ActionElementMap>.array;
			}
			int num = buttonMapCount;
			if (num == 0)
			{
				return EmptyObjects<ActionElementMap>.array;
			}
			int num2 = 0;
			for (int i = 0; i < num; i++)
			{
				ActionElementMap actionElementMap = OLBjOXTjrODnCfjjQFNcEHntujcMA[i];
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
				ActionElementMap actionElementMap2 = OLBjOXTjrODnCfjjQFNcEHntujcMA[j];
				if (actionElementMap2._actionId == actionId && (!skipDisabledMaps || actionElementMap2.dQASdaEFVJzbOgxgKEdsYSDArFzi))
				{
					array[num3] = actionElementMap2;
					num3++;
				}
			}
			return array;
		}

		public int GetButtonMapsWithAction(string actionName, List<ActionElementMap> results)
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
			return GetButtonMapsWithAction(inputAction.id, results);
		}

		public int GetButtonMapsWithAction(int actionId, List<ActionElementMap> results)
		{
			return GetButtonMapsWithAction(actionId, skipDisabledMaps: false, results);
		}

		public int GetButtonMapsWithAction(string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
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
			return GetButtonMapsWithAction(inputAction.id, skipDisabledMaps, results);
		}

		public int GetButtonMapsWithAction(int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
			{
				ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
				return 0;
			}
			return zxIHNhwcNoificncticNOWSTUgFvA(actionId, skipDisabledMaps, results, false);
		}

		public IEnumerable<ActionElementMap> ButtonMapsWithAction(int actionId)
		{
			return ButtonMapsWithAction(actionId, skipDisabledMaps: false);
		}

		public IEnumerable<ActionElementMap> ButtonMapsWithAction(string actionName)
		{
			if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
			{
				ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			int actionId = ReInput.xKokvIxOzcvermvcSUcNKZIGamDS.rnRgZqWgdruGSKkLVaIxIODNYhyJA(actionName);
			return ButtonMapsWithAction(actionId);
		}

		[IteratorStateMachine(typeof(vYcQAQeAjWMDlqWvkbqqbSlKuVNe))]
		public IEnumerable<ActionElementMap> ButtonMapsWithAction(int actionId, bool skipDisabledMaps)
		{
			return new vYcQAQeAjWMDlqWvkbqqbSlKuVNe(-2)
			{
				kRiZUDMLmzCdCBKZQihTUBUgAIINA = this,
				jsUQoAtUrPDxXiHJceTNIUlJBDxu = actionId,
				rXPMIbUYBWbqKRpxmILasOyCKVzX = skipDisabledMaps
			};
		}

		public IEnumerable<ActionElementMap> ButtonMapsWithAction(string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
			{
				ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			int actionId = ReInput.xKokvIxOzcvermvcSUcNKZIGamDS.rnRgZqWgdruGSKkLVaIxIODNYhyJA(actionName);
			return ButtonMapsWithAction(actionId, skipDisabledMaps);
		}

		public ActionElementMap GetFirstButtonMapWithAction(int actionId)
		{
			return GetFirstButtonMapWithAction(actionId, skipDisabledMaps: false);
		}

		public ActionElementMap GetFirstButtonMapWithAction(string actionName)
		{
			if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
			{
				ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
				return null;
			}
			int actionId = ReInput.xKokvIxOzcvermvcSUcNKZIGamDS.rnRgZqWgdruGSKkLVaIxIODNYhyJA(actionName);
			return GetFirstButtonMapWithAction(actionId);
		}

		public ActionElementMap GetFirstButtonMapWithAction(int actionId, bool skipDisabledMaps)
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
			IList<ActionElementMap> buttonMaps = ButtonMaps;
			int num = buttonMapCount;
			for (int i = 0; i < num; i++)
			{
				ActionElementMap actionElementMap = buttonMaps[i];
				if (actionElementMap._actionId == actionId && (!skipDisabledMaps || actionElementMap.enabled))
				{
					return actionElementMap;
				}
			}
			return null;
		}

		public ActionElementMap GetFirstButtonMapWithAction(string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
			{
				ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
				return null;
			}
			int actionId = ReInput.xKokvIxOzcvermvcSUcNKZIGamDS.rnRgZqWgdruGSKkLVaIxIODNYhyJA(actionName);
			return GetFirstButtonMapWithAction(actionId, skipDisabledMaps);
		}

		public ActionElementMap GetFirstButtonMapMatch(Predicate<ActionElementMap> predicate)
		{
			if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
			{
				ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
				return null;
			}
			return QtnEqzVBvAmVtpoZREcYgpHeKwRU(predicate, false);
		}

		internal ActionElementMap QtnEqzVBvAmVtpoZREcYgpHeKwRU(Predicate<ActionElementMap> P_0, bool P_1)
		{
			if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
			{
				ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
				return null;
			}
			if (P_0 == null)
			{
				throw new ArgumentNullException("predicate");
			}
			IList<ActionElementMap> buttonMaps = ButtonMaps;
			int num = buttonMapCount;
			try
			{
				for (int i = 0; i < num; i++)
				{
					ActionElementMap actionElementMap = buttonMaps[i];
					if ((!P_1 || actionElementMap.enabled) && P_0(actionElementMap))
					{
						return actionElementMap;
					}
				}
			}
			catch (Exception exception)
			{
				ReInput.HandleCallbackException("ControllerMap.GetFirstButtonMapMatch", exception);
			}
			return null;
		}

		public int GetButtonMapMatches(Predicate<ActionElementMap> predicate, List<ActionElementMap> results)
		{
			if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
			{
				ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
				return 0;
			}
			return JkkoEqKhDGvTJYbjIrWqXRDCJNtE(predicate, false, results, false);
		}

		internal int JkkoEqKhDGvTJYbjIrWqXRDCJNtE(Predicate<ActionElementMap> P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
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
			IList<ActionElementMap> buttonMaps = ButtonMaps;
			int num2 = buttonMapCount;
			try
			{
				for (int i = 0; i < num2; i++)
				{
					ActionElementMap actionElementMap = buttonMaps[i];
					if ((!P_1 || actionElementMap.enabled) && P_0(actionElementMap))
					{
						P_2.Add(actionElementMap);
					}
				}
			}
			catch (Exception exception)
			{
				ReInput.HandleCallbackException("ControllerMap.GetButtonMapMatches", exception);
			}
			return P_2.Count - num;
		}

		public void ForEachButtonMapMatch(Predicate<ActionElementMap> predicate, Action<ActionElementMap> actionToPerform)
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
			int count = OLBjOXTjrODnCfjjQFNcEHntujcMA.Count;
			try
			{
				for (int i = 0; i < count; i++)
				{
					ActionElementMap obj = OLBjOXTjrODnCfjjQFNcEHntujcMA[i];
					if (predicate(obj))
					{
						actionToPerform(obj);
					}
				}
			}
			catch (Exception exception)
			{
				ReInput.HandleCallbackException("ControllerMap.GetButtonMapMatches", exception);
			}
		}

		public bool DeleteButtonMapsWithAction(string actionName)
		{
			return DeleteButtonMapsWithAction(ReInput.xKokvIxOzcvermvcSUcNKZIGamDS.rnRgZqWgdruGSKkLVaIxIODNYhyJA(actionName));
		}

		public bool DeleteButtonMapsWithAction(int actionId)
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
			int num = buttonMapCount;
			if (num == 0)
			{
				return false;
			}
			bool result = false;
			for (int num2 = num - 1; num2 >= 0; num2--)
			{
				ActionElementMap actionElementMap = OLBjOXTjrODnCfjjQFNcEHntujcMA[num2];
				if (actionElementMap != null && actionElementMap._actionId == actionId)
				{
					YdhMeMhAlyxceGmINjjMNWOOSnwI(actionElementMap.oFUAyzlkDBdPoonWGgEIgJYWTzJOA, num2);
					result = true;
				}
			}
			return result;
		}

		public int SetAllButtonMapsEnabled(bool state)
		{
			if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
			{
				ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
				return 0;
			}
			int num = 0;
			int count = OLBjOXTjrODnCfjjQFNcEHntujcMA.Count;
			for (int i = 0; i < count; i++)
			{
				ActionElementMap actionElementMap = OLBjOXTjrODnCfjjQFNcEHntujcMA[i];
				if (actionElementMap.dQASdaEFVJzbOgxgKEdsYSDArFzi != state)
				{
					actionElementMap.dQASdaEFVJzbOgxgKEdsYSDArFzi = state;
					num++;
				}
			}
			return num;
		}

		public bool DoesElementAssignmentConflict(ControllerMap controllerMap)
		{
			return DoesElementAssignmentConflict(controllerMap, skipDisabledMaps: false);
		}

		public bool DoesElementAssignmentConflict(ActionElementMap actionElementMap)
		{
			return DoesElementAssignmentConflict(actionElementMap, skipDisabledMaps: false);
		}

		public bool DoesElementAssignmentConflict(ElementAssignmentConflictCheck conflictCheck)
		{
			return DoesElementAssignmentConflict(conflictCheck, skipDisabledMaps: false);
		}

		public virtual bool DoesElementAssignmentConflict(ControllerMap controllerMap, bool skipDisabledMaps)
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
			if (skipDisabledMaps && (!_enabled || !controllerMap._enabled))
			{
				return false;
			}
			if (OLBjOXTjrODnCfjjQFNcEHntujcMA == null)
			{
				return false;
			}
			IList<ActionElementMap> buttonMaps = controllerMap.ButtonMaps;
			if (buttonMaps == null)
			{
				return false;
			}
			int num = buttonMapCount;
			int count = buttonMaps.Count;
			for (int i = 0; i < num; i++)
			{
				ActionElementMap actionElementMap = OLBjOXTjrODnCfjjQFNcEHntujcMA[i];
				if (skipDisabledMaps && !actionElementMap.dQASdaEFVJzbOgxgKEdsYSDArFzi)
				{
					continue;
				}
				for (int j = 0; j < count; j++)
				{
					ActionElementMap actionElementMap2 = buttonMaps[j];
					if ((!skipDisabledMaps || actionElementMap2.dQASdaEFVJzbOgxgKEdsYSDArFzi) && actionElementMap != actionElementMap2 && actionElementMap.CheckForAssignmentConflict(actionElementMap2))
					{
						return true;
					}
				}
			}
			return false;
		}

		public virtual bool DoesElementAssignmentConflict(ActionElementMap actionElementMap, bool skipDisabledMaps)
		{
			if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
			{
				ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
				return false;
			}
			if (actionElementMap == null || OLBjOXTjrODnCfjjQFNcEHntujcMA == null)
			{
				return false;
			}
			if (skipDisabledMaps && (!_enabled || !actionElementMap.dQASdaEFVJzbOgxgKEdsYSDArFzi))
			{
				return false;
			}
			for (int i = 0; i < OLBjOXTjrODnCfjjQFNcEHntujcMA.Count; i++)
			{
				ActionElementMap actionElementMap2 = OLBjOXTjrODnCfjjQFNcEHntujcMA[i];
				if ((!skipDisabledMaps || actionElementMap2.dQASdaEFVJzbOgxgKEdsYSDArFzi) && actionElementMap2 != actionElementMap && actionElementMap2.CheckForAssignmentConflict(actionElementMap))
				{
					return true;
				}
			}
			return false;
		}

		public virtual bool DoesElementAssignmentConflict(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
		{
			if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
			{
				ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
				return false;
			}
			if (OLBjOXTjrODnCfjjQFNcEHntujcMA == null)
			{
				return false;
			}
			if (skipDisabledMaps && !_enabled)
			{
				return false;
			}
			if (conflictCheck.elementAssignmentType != ElementAssignmentType.Button && conflictCheck.elementAssignmentType != ElementAssignmentType.KeyboardKey)
			{
				return false;
			}
			ElementAssignment elementAssignment = conflictCheck.ToElementAssignment();
			for (int i = 0; i < OLBjOXTjrODnCfjjQFNcEHntujcMA.Count; i++)
			{
				ActionElementMap actionElementMap = OLBjOXTjrODnCfjjQFNcEHntujcMA[i];
				if ((!skipDisabledMaps || actionElementMap.dQASdaEFVJzbOgxgKEdsYSDArFzi) && actionElementMap.oFUAyzlkDBdPoonWGgEIgJYWTzJOA != conflictCheck.elementMapId && actionElementMap.CheckForAssignmentConflict(elementAssignment))
				{
					return true;
				}
			}
			return false;
		}

		public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ControllerMap controllerMap)
		{
			return ElementAssignmentConflicts(controllerMap, skipDisabledMaps: false);
		}

		public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ActionElementMap actionElementMap)
		{
			return ElementAssignmentConflicts(actionElementMap, skipDisabledMaps: false);
		}

		public IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck)
		{
			return ElementAssignmentConflicts(conflictCheck, skipDisabledMaps: false);
		}

		[IteratorStateMachine(typeof(YRmGBRBggivRmVnEXjKheLgnRtLi))]
		public virtual IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ControllerMap controllerMap, bool skipDisabledMaps)
		{
			return new YRmGBRBggivRmVnEXjKheLgnRtLi(-2)
			{
				ckfSiviPNLYtTRBefGwcpqjEAEVR = this,
				tPCNhRpuvXaQbKondDaoCnEbDoaOA = controllerMap,
				rWcEtiqnkmPKLgSGUeFRQIkycsJN = skipDisabledMaps
			};
		}

		[IteratorStateMachine(typeof(tkTyGJYEOsCeXVDMNlzCXHYjLnjB))]
		public virtual IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ActionElementMap actionElementMap, bool skipDisabledMaps)
		{
			return new tkTyGJYEOsCeXVDMNlzCXHYjLnjB(-2)
			{
				YdNQUDSqAxFvnKmWccDKCNAROIjqA = this,
				bOUwnqrjLrPsvFutzjgHOeTbnEef = actionElementMap,
				wbvOANHGPJXYyXoxPUFZyeUmqWDD = skipDisabledMaps
			};
		}

		[IteratorStateMachine(typeof(RYroKRhCnrdpCnYDnuJisqBFGDQf))]
		public virtual IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
		{
			return new RYroKRhCnrdpCnYDnuJisqBFGDQf(-2)
			{
				kvHAmtivTOzbDxhPkWjLxVSaAzGGA = this,
				kLPAggVDvmtnwgsWLVXsTvEfzhjF = conflictCheck,
				wBakxjGxhutoqVCFiSRajOVGwDpX = skipDisabledMaps
			};
		}

		public int RemoveElementAssignmentConflicts(ControllerMap controllerMap)
		{
			return RemoveElementAssignmentConflicts(controllerMap, skipDisabledMaps: false);
		}

		public int RemoveElementAssignmentConflicts(ActionElementMap actionElementMap)
		{
			return RemoveElementAssignmentConflicts(actionElementMap, skipDisabledMaps: false);
		}

		public int RemoveElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck)
		{
			return RemoveElementAssignmentConflicts(conflictCheck, skipDisabledMaps: false);
		}

		public virtual int RemoveElementAssignmentConflicts(ControllerMap controllerMap, bool skipDisabledMaps)
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
			if (skipDisabledMaps && (!_enabled || !controllerMap._enabled))
			{
				return 0;
			}
			int num = 0;
			if (OLBjOXTjrODnCfjjQFNcEHntujcMA == null)
			{
				return num;
			}
			IList<ActionElementMap> oLBjOXTjrODnCfjjQFNcEHntujcMA = controllerMap.OLBjOXTjrODnCfjjQFNcEHntujcMA;
			if (oLBjOXTjrODnCfjjQFNcEHntujcMA == null)
			{
				return num;
			}
			InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(_categoryId);
			if (mapCategory != null && !mapCategory.userAssignable)
			{
				return num;
			}
			_ = buttonMapCount;
			int count = oLBjOXTjrODnCfjjQFNcEHntujcMA.Count;
			for (int num2 = OLBjOXTjrODnCfjjQFNcEHntujcMA.Count - 1; num2 >= 0; num2--)
			{
				ActionElementMap actionElementMap = OLBjOXTjrODnCfjjQFNcEHntujcMA[num2];
				if (!skipDisabledMaps || actionElementMap.dQASdaEFVJzbOgxgKEdsYSDArFzi)
				{
					for (int i = 0; i < count; i++)
					{
						if ((!skipDisabledMaps || oLBjOXTjrODnCfjjQFNcEHntujcMA[i].dQASdaEFVJzbOgxgKEdsYSDArFzi) && actionElementMap.CheckForAssignmentConflict(oLBjOXTjrODnCfjjQFNcEHntujcMA[i]))
						{
							YdhMeMhAlyxceGmINjjMNWOOSnwI(actionElementMap.oFUAyzlkDBdPoonWGgEIgJYWTzJOA, num2);
							num++;
							break;
						}
					}
				}
			}
			return num;
		}

		public virtual int RemoveElementAssignmentConflicts(ActionElementMap actionElementMap, bool skipDisabledMaps)
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
			if (skipDisabledMaps && (!_enabled || !actionElementMap.dQASdaEFVJzbOgxgKEdsYSDArFzi))
			{
				return 0;
			}
			int num = 0;
			InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(_categoryId);
			if (mapCategory == null)
			{
				return num;
			}
			if (!mapCategory.userAssignable)
			{
				return num;
			}
			if (OLBjOXTjrODnCfjjQFNcEHntujcMA == null)
			{
				return num;
			}
			for (int num2 = OLBjOXTjrODnCfjjQFNcEHntujcMA.Count - 1; num2 >= 0; num2--)
			{
				ActionElementMap actionElementMap2 = OLBjOXTjrODnCfjjQFNcEHntujcMA[num2];
				if ((!skipDisabledMaps || actionElementMap2.dQASdaEFVJzbOgxgKEdsYSDArFzi) && actionElementMap2.CheckForAssignmentConflict(actionElementMap))
				{
					YdhMeMhAlyxceGmINjjMNWOOSnwI(actionElementMap2.oFUAyzlkDBdPoonWGgEIgJYWTzJOA, num2);
					num++;
				}
			}
			return num;
		}

		public virtual int RemoveElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
		{
			if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
			{
				ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
				return 0;
			}
			if (skipDisabledMaps && !_enabled)
			{
				return 0;
			}
			if (OLBjOXTjrODnCfjjQFNcEHntujcMA == null)
			{
				return 0;
			}
			if (conflictCheck.elementAssignmentType != ElementAssignmentType.Button && conflictCheck.elementAssignmentType != ElementAssignmentType.KeyboardKey)
			{
				return 0;
			}
			InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(_categoryId);
			if (mapCategory == null)
			{
				return 0;
			}
			if (!mapCategory.userAssignable)
			{
				return 0;
			}
			ElementAssignment elementAssignment = conflictCheck.ToElementAssignment();
			int num = 0;
			for (int num2 = OLBjOXTjrODnCfjjQFNcEHntujcMA.Count - 1; num2 >= 0; num2--)
			{
				ActionElementMap actionElementMap = OLBjOXTjrODnCfjjQFNcEHntujcMA[num2];
				if ((!skipDisabledMaps || actionElementMap.dQASdaEFVJzbOgxgKEdsYSDArFzi) && actionElementMap.oFUAyzlkDBdPoonWGgEIgJYWTzJOA != conflictCheck.elementMapId && actionElementMap.CheckForAssignmentConflict(elementAssignment))
				{
					YdhMeMhAlyxceGmINjjMNWOOSnwI(actionElementMap.oFUAyzlkDBdPoonWGgEIgJYWTzJOA, num2);
					num++;
				}
			}
			return num;
		}

		public int DisableElementAssignmentConflicts(ControllerMap controllerMap)
		{
			if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
			{
				ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
				return 0;
			}
			return vktnuWxNzkftrdKLECoAFlKxxZVR(controllerMap, false, null, false);
		}

		public int DisableElementAssignmentConflicts(ActionElementMap actionElementMap)
		{
			if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
			{
				ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
				return 0;
			}
			return zFYfwFdloxCUWaLFFnIoYLdVvyPiB(actionElementMap, false, null, false);
		}

		public int DisableElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck)
		{
			if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
			{
				ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
				return 0;
			}
			return RXiaSbGxTjBngXQARUXBmIjqPtfzA(conflictCheck, false, null, false);
		}

		public int DisableElementAssignmentConflicts(ControllerMap controllerMap, bool skipDisabledMaps)
		{
			if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
			{
				ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
				return 0;
			}
			return vktnuWxNzkftrdKLECoAFlKxxZVR(controllerMap, skipDisabledMaps, null, false);
		}

		public int DisableElementAssignmentConflicts(ActionElementMap actionElementMap, bool skipDisabledMaps)
		{
			if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
			{
				ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
				return 0;
			}
			return zFYfwFdloxCUWaLFFnIoYLdVvyPiB(actionElementMap, skipDisabledMaps, null, false);
		}

		public int DisableElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
		{
			if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
			{
				ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
				return 0;
			}
			return RXiaSbGxTjBngXQARUXBmIjqPtfzA(conflictCheck, skipDisabledMaps, null, false);
		}

		internal virtual int vktnuWxNzkftrdKLECoAFlKxxZVR(ControllerMap P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			if (P_2 != null && !P_3)
			{
				P_2.Clear();
			}
			if (P_0 == null)
			{
				return 0;
			}
			if (P_1 && (!_enabled || !P_0._enabled))
			{
				return 0;
			}
			int num = 0;
			if (OLBjOXTjrODnCfjjQFNcEHntujcMA == null)
			{
				return num;
			}
			IList<ActionElementMap> oLBjOXTjrODnCfjjQFNcEHntujcMA = P_0.OLBjOXTjrODnCfjjQFNcEHntujcMA;
			if (oLBjOXTjrODnCfjjQFNcEHntujcMA == null)
			{
				return num;
			}
			InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(_categoryId);
			if (mapCategory != null && !mapCategory.userAssignable)
			{
				return num;
			}
			int num2 = buttonMapCount;
			int count = oLBjOXTjrODnCfjjQFNcEHntujcMA.Count;
			for (int i = 0; i < num2; i++)
			{
				ActionElementMap actionElementMap = OLBjOXTjrODnCfjjQFNcEHntujcMA[i];
				if (!actionElementMap.dQASdaEFVJzbOgxgKEdsYSDArFzi)
				{
					continue;
				}
				for (int j = 0; j < count; j++)
				{
					ActionElementMap actionElementMap2 = oLBjOXTjrODnCfjjQFNcEHntujcMA[j];
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

		internal virtual int zFYfwFdloxCUWaLFFnIoYLdVvyPiB(ActionElementMap P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			if (P_2 != null && !P_3)
			{
				P_2.Clear();
			}
			if (P_0 == null)
			{
				return 0;
			}
			if (P_1 && (!_enabled || !P_0.dQASdaEFVJzbOgxgKEdsYSDArFzi))
			{
				return 0;
			}
			int num = 0;
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
			int num2 = buttonMapCount;
			for (int i = 0; i < num2; i++)
			{
				ActionElementMap actionElementMap = OLBjOXTjrODnCfjjQFNcEHntujcMA[i];
				if (actionElementMap.dQASdaEFVJzbOgxgKEdsYSDArFzi && P_0.CheckForAssignmentConflict(actionElementMap))
				{
					actionElementMap.enabled = false;
					P_2?.Add(actionElementMap);
					num++;
				}
			}
			return num;
		}

		internal virtual int RXiaSbGxTjBngXQARUXBmIjqPtfzA(ElementAssignmentConflictCheck P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			if (P_2 != null && !P_3)
			{
				P_2.Clear();
			}
			if (P_1 && !_enabled)
			{
				return 0;
			}
			if (OLBjOXTjrODnCfjjQFNcEHntujcMA == null)
			{
				return 0;
			}
			if (P_0.elementAssignmentType != ElementAssignmentType.Button && P_0.elementAssignmentType != ElementAssignmentType.KeyboardKey)
			{
				return 0;
			}
			InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(_categoryId);
			if (mapCategory == null)
			{
				return 0;
			}
			if (!mapCategory.userAssignable)
			{
				return 0;
			}
			ElementAssignment elementAssignment = P_0.ToElementAssignment();
			int num = 0;
			int num2 = buttonMapCount;
			for (int i = 0; i < num2; i++)
			{
				ActionElementMap actionElementMap = OLBjOXTjrODnCfjjQFNcEHntujcMA[i];
				if (actionElementMap.dQASdaEFVJzbOgxgKEdsYSDArFzi && actionElementMap.oFUAyzlkDBdPoonWGgEIgJYWTzJOA != P_0.elementMapId && actionElementMap.CheckForAssignmentConflict(elementAssignment))
				{
					actionElementMap.enabled = false;
					P_2?.Add(actionElementMap);
					num++;
				}
			}
			return num;
		}

		public int ForEachElementAssignmentConflict(ControllerMap controllerMap, Action<ActionElementMap> actionToPerform)
		{
			return ForEachElementAssignmentConflict(controllerMap, actionToPerform, skipDisabledMaps: false);
		}

		public int ForEachElementAssignmentConflict(ActionElementMap actionElementMap, Action<ActionElementMap> actionToPerform)
		{
			return ForEachElementAssignmentConflict(actionElementMap, actionToPerform, skipDisabledMaps: false);
		}

		public int ForEachElementAssignmentConflict(ElementAssignmentConflictCheck conflictCheck, Action<ActionElementMap> actionToPerform)
		{
			return ForEachElementAssignmentConflict(conflictCheck, actionToPerform, skipDisabledMaps: false);
		}

		public int ForEachElementAssignmentConflict(ControllerMap controllerMap, Action<ActionElementMap> actionToPerform, bool skipDisabledMaps)
		{
			if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
			{
				ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
				return 0;
			}
			if (actionToPerform == null)
			{
				throw new ArgumentNullException("actionToPerform");
			}
			if (controllerMap == null)
			{
				return 0;
			}
			if (skipDisabledMaps && (!_enabled || !controllerMap._enabled))
			{
				return 0;
			}
			int num = 0;
			if (nqwDWFCbTZWaSogAWTqZBPRCjgJwA == null)
			{
				return num;
			}
			IList<ActionElementMap> list = controllerMap.nqwDWFCbTZWaSogAWTqZBPRCjgJwA;
			if (list == null)
			{
				return num;
			}
			InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(_categoryId);
			if (mapCategory != null && !mapCategory.userAssignable)
			{
				return num;
			}
			int count = list.Count;
			for (int num2 = nqwDWFCbTZWaSogAWTqZBPRCjgJwA.Count - 1; num2 >= 0; num2--)
			{
				ActionElementMap actionElementMap = nqwDWFCbTZWaSogAWTqZBPRCjgJwA[num2];
				if (!skipDisabledMaps || actionElementMap.dQASdaEFVJzbOgxgKEdsYSDArFzi)
				{
					for (int i = 0; i < count; i++)
					{
						if ((!skipDisabledMaps || list[i].dQASdaEFVJzbOgxgKEdsYSDArFzi) && actionElementMap.CheckForAssignmentConflict(list[i]))
						{
							try
							{
								actionToPerform(actionElementMap);
							}
							catch (Exception exception)
							{
								ReInput.HandleCallbackException("ControllerMap.ForEachElementAssignmentConflict", exception);
								return num;
							}
							num++;
							break;
						}
					}
				}
			}
			return num;
		}

		public int ForEachElementAssignmentConflict(ActionElementMap actionElementMap, Action<ActionElementMap> actionToPerform, bool skipDisabledMaps)
		{
			if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
			{
				ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
				return 0;
			}
			if (actionToPerform == null)
			{
				throw new ArgumentNullException("actionToPerform");
			}
			if (actionElementMap == null)
			{
				return 0;
			}
			if (skipDisabledMaps && (!_enabled || !actionElementMap.dQASdaEFVJzbOgxgKEdsYSDArFzi))
			{
				return 0;
			}
			int num = 0;
			InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(_categoryId);
			if (mapCategory == null)
			{
				return num;
			}
			if (!mapCategory.userAssignable)
			{
				return num;
			}
			if (nqwDWFCbTZWaSogAWTqZBPRCjgJwA == null)
			{
				return num;
			}
			for (int num2 = nqwDWFCbTZWaSogAWTqZBPRCjgJwA.Count - 1; num2 >= 0; num2--)
			{
				ActionElementMap actionElementMap2 = nqwDWFCbTZWaSogAWTqZBPRCjgJwA[num2];
				if ((!skipDisabledMaps || actionElementMap2.dQASdaEFVJzbOgxgKEdsYSDArFzi) && actionElementMap2.CheckForAssignmentConflict(actionElementMap))
				{
					try
					{
						actionToPerform(actionElementMap2);
					}
					catch (Exception exception)
					{
						ReInput.HandleCallbackException("ControllerMap.ForEachElementAssignmentConflict", exception);
						return num;
					}
					num++;
				}
			}
			return num;
		}

		public int ForEachElementAssignmentConflict(ElementAssignmentConflictCheck conflictCheck, Action<ActionElementMap> actionToPerform, bool skipDisabledMaps)
		{
			if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
			{
				ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
				return 0;
			}
			if (actionToPerform == null)
			{
				throw new ArgumentNullException("actionToPerform");
			}
			if (skipDisabledMaps && !_enabled)
			{
				return 0;
			}
			if (nqwDWFCbTZWaSogAWTqZBPRCjgJwA == null)
			{
				return 0;
			}
			if (conflictCheck.elementAssignmentType != ElementAssignmentType.Button && conflictCheck.elementAssignmentType != ElementAssignmentType.KeyboardKey)
			{
				return 0;
			}
			InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(_categoryId);
			if (mapCategory == null)
			{
				return 0;
			}
			if (!mapCategory.userAssignable)
			{
				return 0;
			}
			ElementAssignment elementAssignment = conflictCheck.ToElementAssignment();
			int num = 0;
			for (int num2 = nqwDWFCbTZWaSogAWTqZBPRCjgJwA.Count - 1; num2 >= 0; num2--)
			{
				ActionElementMap actionElementMap = nqwDWFCbTZWaSogAWTqZBPRCjgJwA[num2];
				if ((!skipDisabledMaps || actionElementMap.dQASdaEFVJzbOgxgKEdsYSDArFzi) && actionElementMap.oFUAyzlkDBdPoonWGgEIgJYWTzJOA != conflictCheck.elementMapId && actionElementMap.CheckForAssignmentConflict(elementAssignment))
				{
					try
					{
						actionToPerform(actionElementMap);
					}
					catch (Exception exception)
					{
						ReInput.HandleCallbackException("ControllerMap.ForEachElementAssignmentConflict", exception);
						return num;
					}
					num++;
				}
			}
			return num;
		}

		public string[] GetButtonNames()
		{
			if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
			{
				ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
				return EmptyObjects<string>.array;
			}
			int num = buttonMapCount;
			if (num == 0)
			{
				return new string[0];
			}
			string[] array = new string[num];
			for (int i = 0; i < num; i++)
			{
				array[i] = OLBjOXTjrODnCfjjQFNcEHntujcMA[i].elementIdentifierName;
			}
			return array;
		}

		public string ToXmlString()
		{
			if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
			{
				ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
				return string.Empty;
			}
			try
			{
				return aExqoCzXzmfJluoOYhvwnHhZHXnP().ToXmlString(writeDocumentTag: true);
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error writing " + GetType().Name + " to XML. " + ex.Message);
				return string.Empty;
			}
		}

		public string ToJsonString()
		{
			if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
			{
				ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
				return string.Empty;
			}
			try
			{
				return aExqoCzXzmfJluoOYhvwnHhZHXnP().ToJsonString();
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error writing " + GetType().Name + " to JSON. " + ex.Message);
				return string.Empty;
			}
		}

		public ControllerTemplateMap ToControllerTemplateMap(Guid templateTypeGuid)
		{
			if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
			{
				ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
				return null;
			}
			if (controller == null)
			{
				Logger.LogError("The Controller Map is not associated with a Controller. This method can only be used with a Controller Map that is associated with a Controller.", requiredThreadSafety: true);
				return null;
			}
			IControllerTemplate controllerTemplate = controller.GetTemplate(templateTypeGuid) ?? (controller.GetTemplate(templateTypeGuid) as ControllerTemplate);
			if (controllerTemplate == null)
			{
				HardwareJoystickTemplateMap hardwareJoystickTemplateMap = ReInput.RErcwJFraWnCUyvOExbBHYmECOoxA(templateTypeGuid);
				string text = ((hardwareJoystickTemplateMap != null) ? hardwareJoystickTemplateMap.ClassName : templateTypeGuid.ToString());
				Logger.LogError("The Controller does not implement " + text + ".", requiredThreadSafety: true);
				return null;
			}
			return ControllerTemplateMap.xuhSpLWtSnoqyFUMujzteHLCSvXI(controllerTemplate, this);
		}

		public ControllerTemplateMap ToControllerTemplateMap<T>() where T : class
		{
			return ToControllerTemplateMap(typeof(T));
		}

		public ControllerTemplateMap ToControllerTemplateMap(Type templateInterfaceType)
		{
			if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
			{
				ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
				return null;
			}
			if (templateInterfaceType == null)
			{
				throw new ArgumentNullException("templateInterfaceType");
			}
			if (controller == null)
			{
				Logger.LogError("The Controller Map is not associated with a Controller. This method can only be used with a Controller Map that is associated with a Controller.", requiredThreadSafety: true);
				return null;
			}
			IControllerTemplate controllerTemplate = controller.GetTemplate(templateInterfaceType) ?? (controller.GetTemplate(templateInterfaceType) as ControllerTemplate);
			if (controllerTemplate == null)
			{
				Logger.LogError("The Controller does not implement " + templateInterfaceType.Name + ".", requiredThreadSafety: true);
				return null;
			}
			return ControllerTemplateMap.xuhSpLWtSnoqyFUMujzteHLCSvXI(controllerTemplate, this);
		}

		private ControllerTemplateMap YcliLpFqIcxVCSQjzShLqrkqLYrO(IControllerTemplate P_0)
		{
			if (ReInput._id != sIwyLhKUWykANTFJFXecFgCmwcwn)
			{
				ReInput.CheckInitialized(sIwyLhKUWykANTFJFXecFgCmwcwn);
				return null;
			}
			if (P_0 == null)
			{
				throw new ArgumentNullException("controllerTemplate");
			}
			return ControllerTemplateMap.xuhSpLWtSnoqyFUMujzteHLCSvXI(P_0, this);
		}

		internal virtual bool HPOsNbYEHzjGQhSFgJFXiksNXGln(ActionElementMap P_0)
		{
			if (!VBrjUaVMXeCqeEfUtJcanLXwEzSy(P_0._elementType))
			{
				return false;
			}
			UjFPpMLIGPNFXMBKzeSemCEngJih(P_0);
			return true;
		}

		internal virtual int hdOLzuxCVTtDRXVQrCeluNkEWcfA(List<ActionElementMap> P_0, bool P_1)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("results");
			}
			int count = P_0.Count;
			int count2 = OLBjOXTjrODnCfjjQFNcEHntujcMA.Count;
			for (int i = 0; i < count2; i++)
			{
				if (!P_1 || OLBjOXTjrODnCfjjQFNcEHntujcMA[i].dQASdaEFVJzbOgxgKEdsYSDArFzi)
				{
					P_0.Add(OLBjOXTjrODnCfjjQFNcEHntujcMA[i]);
				}
			}
			return P_0.Count - count;
		}

		internal virtual ActionElementMap IRBhJExjUCxVZbNMTKSCVUkomLBm(int P_0, int P_1, ControllerElementType P_2)
		{
			if (!VBrjUaVMXeCqeEfUtJcanLXwEzSy(P_2))
			{
				return null;
			}
			int num = cEVIvIwIzyJBJgfmfYiJPzCVAFuN(P_0, P_1, P_2);
			if (num < 0)
			{
				return null;
			}
			return OLBjOXTjrODnCfjjQFNcEHntujcMA[num];
		}

		internal virtual int lUysouhoBRkkoKfsdAFzIiZKzOMNA(int P_0, List<ActionElementMap> P_1, bool P_2)
		{
			if (P_1 == null)
			{
				throw new ArgumentNullException("results");
			}
			int num = 0;
			if (!P_2)
			{
				P_1.Clear();
			}
			else
			{
				num = P_1.Count;
			}
			if (OLBjOXTjrODnCfjjQFNcEHntujcMA == null)
			{
				return 0;
			}
			int num2 = buttonMapCount;
			for (int i = 0; i < num2; i++)
			{
				if (OLBjOXTjrODnCfjjQFNcEHntujcMA[i]._elementIdentifierId == P_0)
				{
					P_1.Add(OLBjOXTjrODnCfjjQFNcEHntujcMA[i]);
				}
			}
			return P_1.Count - num;
		}

		internal virtual bool cDsituIeqCPBekdiLDEdgQKOpNFwA(int P_0, int P_1, ControllerElementType P_2)
		{
			if (!VBrjUaVMXeCqeEfUtJcanLXwEzSy(P_2))
			{
				return false;
			}
			int num = buttonMapCount;
			for (int i = 0; i < num; i++)
			{
				if (OLBjOXTjrODnCfjjQFNcEHntujcMA[i]._elementIdentifierId == P_0 && OLBjOXTjrODnCfjjQFNcEHntujcMA[i]._actionId == P_1)
				{
					return true;
				}
			}
			return false;
		}

		internal virtual int cEVIvIwIzyJBJgfmfYiJPzCVAFuN(int P_0, int P_1, ControllerElementType P_2)
		{
			if (!VBrjUaVMXeCqeEfUtJcanLXwEzSy(P_2))
			{
				return -1;
			}
			if (OLBjOXTjrODnCfjjQFNcEHntujcMA == null)
			{
				return -1;
			}
			int num = buttonMapCount;
			for (int i = 0; i < num; i++)
			{
				if (OLBjOXTjrODnCfjjQFNcEHntujcMA[i]._elementIdentifierId == P_0 && OLBjOXTjrODnCfjjQFNcEHntujcMA[i]._actionId == P_1)
				{
					return i;
				}
			}
			return -1;
		}

		internal int PHzoxgTXPEKhZsgoASpWqpVluZvV(int P_0)
		{
			if (OLBjOXTjrODnCfjjQFNcEHntujcMA == null)
			{
				return -1;
			}
			int num = buttonMapCount;
			for (int i = 0; i < num; i++)
			{
				if (OLBjOXTjrODnCfjjQFNcEHntujcMA[i].oFUAyzlkDBdPoonWGgEIgJYWTzJOA == P_0)
				{
					return i;
				}
			}
			return -1;
		}

		internal int lbQyezPhNMHiUnRQKhigUytwLgSB(bool P_0, List<ActionElementMap> P_1, bool P_2)
		{
			if (P_1 == null)
			{
				throw new ArgumentNullException("results");
			}
			if (!P_2)
			{
				P_1.Clear();
			}
			int num = buttonMapCount;
			int num2 = 0;
			for (int i = 0; i < num; i++)
			{
				ActionElementMap actionElementMap = OLBjOXTjrODnCfjjQFNcEHntujcMA[i];
				if (!P_0 || actionElementMap.dQASdaEFVJzbOgxgKEdsYSDArFzi)
				{
					P_1.Add(actionElementMap);
					num2++;
				}
			}
			return num2;
		}

		internal int zxIHNhwcNoificncticNOWSTUgFvA(int P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			if (P_2 == null)
			{
				throw new ArgumentNullException("results");
			}
			if (!P_3)
			{
				P_2.Clear();
			}
			int num = buttonMapCount;
			if (num == 0)
			{
				return 0;
			}
			int num2 = 0;
			for (int i = 0; i < num; i++)
			{
				ActionElementMap actionElementMap = OLBjOXTjrODnCfjjQFNcEHntujcMA[i];
				if (actionElementMap._actionId == P_0 && (!P_1 || actionElementMap.dQASdaEFVJzbOgxgKEdsYSDArFzi))
				{
					P_2.Add(actionElementMap);
					num2++;
				}
			}
			return num2;
		}

		internal virtual int TPGoRsOaoYnEGuXZQSOypYbEQESv(int P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
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
			int num = 0;
			int num2 = buttonMapCount;
			for (int i = 0; i < num2; i++)
			{
				ActionElementMap actionElementMap = OLBjOXTjrODnCfjjQFNcEHntujcMA[i];
				if (actionElementMap._actionId == P_0 && (!P_1 || actionElementMap.dQASdaEFVJzbOgxgKEdsYSDArFzi))
				{
					P_2.Add(actionElementMap);
					num++;
				}
			}
			return num;
		}

		internal virtual ActionElementMap ULkNEiizKoMslClQddTEvQaQhqGD(IControllerElementTarget P_0, bool P_1, int P_2, bool P_3, out bool P_4)
		{
			P_4 = false;
			if (P_1 && P_2 < 0)
			{
				P_4 = true;
				return null;
			}
			if (!PWgAQKWYNfGHhERCwHtdaqRiFyUn(P_0))
			{
				P_4 = true;
				return null;
			}
			if (!VBrjUaVMXeCqeEfUtJcanLXwEzSy(P_0.elementType))
			{
				return null;
			}
			int num = buttonMapCount;
			_ = P_0.elementIdentifierId;
			for (int i = 0; i < num; i++)
			{
				if ((!P_1 || OLBjOXTjrODnCfjjQFNcEHntujcMA[i]._actionId == P_2) && (!P_3 || OLBjOXTjrODnCfjjQFNcEHntujcMA[i].dQASdaEFVJzbOgxgKEdsYSDArFzi) && OLBjOXTjrODnCfjjQFNcEHntujcMA[i].IsTarget(P_0))
				{
					return OLBjOXTjrODnCfjjQFNcEHntujcMA[i];
				}
			}
			return null;
		}

		internal virtual int xbMqqhNCHHsGgJNjWdODBOazhjtNA(IControllerElementTarget P_0, bool P_1, int P_2, bool P_3, List<ActionElementMap> P_4, bool P_5, out bool P_6)
		{
			if (P_4 == null)
			{
				throw new ArgumentNullException("results");
			}
			int num = 0;
			if (!P_5)
			{
				P_4.Clear();
			}
			P_6 = false;
			if (P_1 && P_2 < 0)
			{
				P_6 = true;
				return num;
			}
			if (!PWgAQKWYNfGHhERCwHtdaqRiFyUn(P_0))
			{
				P_6 = true;
				return num;
			}
			if (!VBrjUaVMXeCqeEfUtJcanLXwEzSy(P_0.elementType))
			{
				return num;
			}
			int num2 = buttonMapCount;
			_ = P_0.elementIdentifierId;
			for (int i = 0; i < num2; i++)
			{
				if ((!P_1 || OLBjOXTjrODnCfjjQFNcEHntujcMA[i]._actionId == P_2) && (!P_3 || OLBjOXTjrODnCfjjQFNcEHntujcMA[i].dQASdaEFVJzbOgxgKEdsYSDArFzi) && OLBjOXTjrODnCfjjQFNcEHntujcMA[i].IsTarget(P_0))
				{
					P_4.Add(OLBjOXTjrODnCfjjQFNcEHntujcMA[i]);
					num++;
				}
			}
			return num;
		}

		internal void AirUPgEHNKSrqFnVWAYcisLSfUQNA(int P_0, ControllerElementType P_1)
		{
			ActionElementMap elementMap = GetElementMap(P_0);
			if (elementMap != null && elementMap._elementType != P_1)
			{
				elementMap._elementType = P_1;
				if (P_1 == ControllerElementType.Button)
				{
					elementMap._axisRange = AxisRange.Full;
					elementMap._invert = false;
				}
				DeleteElementMap(P_0);
				MRgDnrLSsvZtSdyIMEPGVhhYDIyZ(elementMap);
			}
		}

		internal virtual bool MRgDnrLSsvZtSdyIMEPGVhhYDIyZ(ActionElementMap P_0)
		{
			if (P_0 == null)
			{
				return false;
			}
			if (!VBrjUaVMXeCqeEfUtJcanLXwEzSy(P_0._elementType))
			{
				return false;
			}
			OLBjOXTjrODnCfjjQFNcEHntujcMA.Add(P_0);
			AZJmYkVvuBcWQvrqeQVQVECJigTK(P_0);
			return true;
		}

		internal bool PWgAQKWYNfGHhERCwHtdaqRiFyUn(IControllerElementTarget P_0)
		{
			if (P_0 == null)
			{
				return false;
			}
			Controller controller = P_0.controller;
			if (controller == null || controller.type != _controllerType || controller.id != _controllerId)
			{
				return false;
			}
			return true;
		}

		internal bool VRbbXiDzmMpStCRmIpyxpYvZIHmN(string P_0)
		{
			try
			{
				HPOExOlytDPUDxqQzZbvKbzhZnyr(SerializedObject.FromXml(GetType(), P_0));
				return true;
			}
			catch (Exception ex)
			{
				Logger.LogError("Error creating  " + GetType().Name + "  from XML. " + ex.Message);
				return false;
			}
		}

		internal bool aCgJOqCmItyUDepKiDUWdUcxtvms(string P_0)
		{
			try
			{
				HPOExOlytDPUDxqQzZbvKbzhZnyr(SerializedObject.FromJson(GetType(), P_0));
				return true;
			}
			catch (Exception ex)
			{
				Logger.LogError("Error creating  " + GetType().Name + "  from JSON. " + ex.Message);
				return false;
			}
		}

		internal void AZJmYkVvuBcWQvrqeQVQVECJigTK(ActionElementMap P_0)
		{
			if (P_0 != null)
			{
				nqwDWFCbTZWaSogAWTqZBPRCjgJwA.Add(P_0);
				nqwDWFCbTZWaSogAWTqZBPRCjgJwA.Sort(TYowNWGMfpmroNLgMCxyexiayMUAA.BqPbMMEPcMgjwvohmdDHEhQbIBpmc);
			}
		}

		internal void QmTnGtJygnAyBDShSvBhjrWUUuhL(int P_0)
		{
			int num = TIWLdxYeeWcQTTQSpMCSLwmJdXVp(P_0);
			if (num >= 0)
			{
				nqwDWFCbTZWaSogAWTqZBPRCjgJwA.RemoveAt(num);
			}
		}

		internal void ohNdGVIsDsFYFQeUlMqKVvYfEWrc(int P_0, ActionElementMap P_1)
		{
			if (P_1 != null)
			{
				int num = TIWLdxYeeWcQTTQSpMCSLwmJdXVp(P_0);
				if (num >= 0)
				{
					nqwDWFCbTZWaSogAWTqZBPRCjgJwA[num] = P_1;
					nqwDWFCbTZWaSogAWTqZBPRCjgJwA.Sort(TYowNWGMfpmroNLgMCxyexiayMUAA.BqPbMMEPcMgjwvohmdDHEhQbIBpmc);
				}
			}
		}

		internal static void OAEjdeCzQqxOtbOqaiobZETGzJNH(ActionElementMap P_0, int P_1, Pole P_2, int P_3, ControllerElementType P_4, AxisRange P_5, bool P_6)
		{
			P_0.qiOiajljPpDlMenubKTEdMYtXaRGA();
			P_0._actionId = P_1;
			P_0._elementType = P_4;
			P_0._elementIdentifierId = P_3;
			P_0._axisContribution = P_2;
			P_0._axisRange = P_5;
			if (P_4 == ControllerElementType.Axis)
			{
				P_0._invert = P_6;
			}
		}

		protected void BakeElementMap(ActionElementMap map)
		{
			if (map != null)
			{
				ReInput.controllers.GetController(_controllerType, _controllerId)?.YTencsjPWuJIOCxnxAitAELcIHlkA(this, map);
			}
		}

		internal virtual bool HPOExOlytDPUDxqQzZbvKbzhZnyr(SerializedObject P_0)
		{
			bool flag = false;
			_sourceMapId = -1;
			_categoryId = -1;
			_layoutId = -1;
			_name = string.Empty;
			_hardwareGuid = Guid.Empty;
			_enabled = true;
			P_0.TryGetDeserializedValueByRef("sourceMapId", ref _sourceMapId);
			P_0.TryGetDeserializedValueByRef("categoryId", ref _categoryId);
			P_0.TryGetDeserializedValueByRef("layoutId", ref _layoutId);
			P_0.TryGetDeserializedValueByRef("name", ref _name);
			P_0.TryGetDeserializedValueByRef("hardwareGuid", ref _hardwareGuid);
			P_0.TryGetDeserializedValueByRef("enabled", ref _enabled);
			if (!flag)
			{
				ClearElementMaps();
				flag = true;
			}
			SerializedObject value = null;
			if (P_0.TryGetDeserializedValueByRef("buttonMaps", ref value) && value != null)
			{
				for (int i = 0; i < value.count; i++)
				{
					if (value.TryGetDeserializedValue<SerializedObject>(i, out var value2) || value2 == null)
					{
						ActionElementMap actionElementMap = new ActionElementMap();
						actionElementMap.gzRmpiyWMaJwdTlfQTwJfqBAzPKK(value2);
						if (ActionElementMap.cKGcyYGyQDfPHsLIvwcztnLQaKGd(actionElementMap))
						{
							UjFPpMLIGPNFXMBKzeSemCEngJih(actionElementMap);
						}
					}
				}
			}
			return flag;
		}

		internal virtual void iZDJwKoaMpHLdcAEEKFbgptHoIabB(SerializedObject P_0)
		{
			if (P_0.xmlInfo == null)
			{
				P_0.xmlInfo = new SerializedObject.XmlInfo();
			}
			P_0.Add("dataVersion", 2, SerializedObject.FieldOptions.ExculdeFromXml);
			P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.EqkbSPJHEHHtJoXsspdzqAzVcAQUA
			{
				rzFSJcZEFOpFlXqzyhdFdwpOrpaJ = "dataVersion",
				sMgGiLjHAAIlXTFOzVTKBeTzOPUX = 2.ToString()
			});
			if ((object)GetType() == typeof(JoystickMap))
			{
				Joystick joystick = ReInput.controllers.GetJoystick(_controllerId);
				Guid guid = joystick?.hardwareTypeGuid ?? Guid.Empty;
				string sMgGiLjHAAIlXTFOzVTKBeTzOPUX = ((joystick != null) ? SerializationTools.CleanInvalidXmlChars(joystick.hardwareName) : "Unknown");
				P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.EqkbSPJHEHHtJoXsspdzqAzVcAQUA
				{
					rzFSJcZEFOpFlXqzyhdFdwpOrpaJ = "hardwareGuid",
					sMgGiLjHAAIlXTFOzVTKBeTzOPUX = guid.ToString()
				});
				P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.EqkbSPJHEHHtJoXsspdzqAzVcAQUA
				{
					rzFSJcZEFOpFlXqzyhdFdwpOrpaJ = "hardwareName",
					sMgGiLjHAAIlXTFOzVTKBeTzOPUX = sMgGiLjHAAIlXTFOzVTKBeTzOPUX
				});
			}
			P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.EqkbSPJHEHHtJoXsspdzqAzVcAQUA
			{
				OehazIAPEcSENVTqpypPfkRtzKCK = "xmlns",
				rzFSJcZEFOpFlXqzyhdFdwpOrpaJ = "xsi",
				FqpwTkyfXldoEdOuFQPgNddSWNnN = null,
				sMgGiLjHAAIlXTFOzVTKBeTzOPUX = "http://www.w3.org/2001/XMLSchema-instance"
			});
			P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.EqkbSPJHEHHtJoXsspdzqAzVcAQUA
			{
				OehazIAPEcSENVTqpypPfkRtzKCK = "xsi",
				rzFSJcZEFOpFlXqzyhdFdwpOrpaJ = "schemaLocation",
				FqpwTkyfXldoEdOuFQPgNddSWNnN = null,
				sMgGiLjHAAIlXTFOzVTKBeTzOPUX = string.Format("{0} {1}{2}{3}{4}{5}", "http://guavaman.com/rewired", "http://guavaman.com/schemas/rewired/", "1.1", "/", GetType().Name, ".xsd")
			});
			P_0.Add("sourceMapId", _sourceMapId);
			P_0.Add("categoryId", _categoryId);
			P_0.Add("layoutId", _layoutId);
			P_0.Add("name", _name);
			P_0.Add("hardwareGuid", _hardwareGuid);
			P_0.Add("enabled", _enabled);
			int num = buttonMapCount;
			List<object> list = new List<object>();
			P_0.Add("buttonMaps", list);
			for (int i = 0; i < num; i++)
			{
				if (OLBjOXTjrODnCfjjQFNcEHntujcMA[i] != null)
				{
					list.Add(OLBjOXTjrODnCfjjQFNcEHntujcMA[i].cSOgtQGQhdPyjGwILCVsTHtTgUFxA());
				}
			}
		}

		private bool VBrjUaVMXeCqeEfUtJcanLXwEzSy(ControllerElementType P_0)
		{
			if (P_0 != ControllerElementType.Button)
			{
				return false;
			}
			return true;
		}

		private void YdhMeMhAlyxceGmINjjMNWOOSnwI(int P_0, int P_1)
		{
			QmTnGtJygnAyBDShSvBhjrWUUuhL(P_0);
			if (P_1 >= 0 && P_1 < buttonMapCount)
			{
				OLBjOXTjrODnCfjjQFNcEHntujcMA.RemoveAt(P_1);
			}
		}

		private void UjFPpMLIGPNFXMBKzeSemCEngJih(ActionElementMap P_0)
		{
			if (P_0 != null)
			{
				OLBjOXTjrODnCfjjQFNcEHntujcMA.Add(P_0);
				AZJmYkVvuBcWQvrqeQVQVECJigTK(P_0);
			}
		}

		private void hYHLvIZZIZkxPOSJmiCsCOQHblAh(ActionElementMap P_0, int P_1)
		{
			if (P_0 != null && P_1 >= 0 && P_1 < buttonMapCount)
			{
				ohNdGVIsDsFYFQeUlMqKVvYfEWrc(OLBjOXTjrODnCfjjQFNcEHntujcMA[P_1].oFUAyzlkDBdPoonWGgEIgJYWTzJOA, P_0);
				OLBjOXTjrODnCfjjQFNcEHntujcMA[P_1] = P_0;
			}
		}

		private int TIWLdxYeeWcQTTQSpMCSLwmJdXVp(int P_0)
		{
			if (nqwDWFCbTZWaSogAWTqZBPRCjgJwA == null)
			{
				return -1;
			}
			int count = nqwDWFCbTZWaSogAWTqZBPRCjgJwA.Count;
			for (int i = 0; i < count; i++)
			{
				if (nqwDWFCbTZWaSogAWTqZBPRCjgJwA[i].oFUAyzlkDBdPoonWGgEIgJYWTzJOA == P_0)
				{
					return i;
				}
			}
			return -1;
		}

		private SerializedObject aExqoCzXzmfJluoOYhvwnHhZHXnP()
		{
			SerializedObject serializedObject = new SerializedObject(GetType(), SerializedObject.ObjectType.Object);
			iZDJwKoaMpHLdcAEEKFbgptHoIabB(serializedObject);
			return serializedObject;
		}

		internal static ControllerMap ctcJORaseVdEGWTaltoRzKkQCnen(ControllerType P_0)
		{
			return P_0 switch
			{
				ControllerType.Keyboard => new KeyboardMap(), 
				ControllerType.Mouse => new MouseMap(), 
				ControllerType.Joystick => new JoystickMap(), 
				ControllerType.Custom => new CustomControllerMap(), 
				_ => throw new NotImplementedException(), 
			};
		}

		internal static ControllerMap LUNDdDBVsDcbaPNGFVLvOAKUDshGA(Controller P_0, int P_1, int P_2)
		{
			if (P_0 == null)
			{
				return null;
			}
			return P_0.type switch
			{
				ControllerType.Keyboard => KeyboardMap.ICeymztTrSHKrrJarQRDqboVGMGg(P_0.hardwareTypeGuid, P_1, P_2), 
				ControllerType.Mouse => MouseMap.IQssTQzcyoYodTRrMBCEQDqQSQxV(P_0.hardwareTypeGuid, P_1, P_2), 
				ControllerType.Joystick => JoystickMap.GTZCgEvpgmnzPgaEIBMstvYoxmHS(P_0.hardwareTypeGuid, P_1, P_2), 
				ControllerType.Custom => CustomControllerMap.RBnXPiSJXmxvELLXKDyMJPsNzbOR(P_0.hardwareTypeGuid, ((CustomController)P_0).sourceControllerId, P_1, P_2), 
				_ => throw new NotImplementedException(), 
			};
		}

		public static ControllerMap CreateFromXml(ControllerType controllerType, string xmlString)
		{
			if (string.IsNullOrEmpty(xmlString))
			{
				return null;
			}
			ControllerMap controllerMap = ctcJORaseVdEGWTaltoRzKkQCnen(controllerType);
			try
			{
				controllerMap.VRbbXiDzmMpStCRmIpyxpYvZIHmN(xmlString);
				return controllerMap;
			}
			catch
			{
				return null;
			}
		}

		public static ControllerMap CreateFromJson(ControllerType controllerType, string jsonString)
		{
			if (string.IsNullOrEmpty(jsonString))
			{
				return null;
			}
			ControllerMap controllerMap = ctcJORaseVdEGWTaltoRzKkQCnen(controllerType);
			try
			{
				controllerMap.aCgJOqCmItyUDepKiDUWdUcxtvms(jsonString);
				return controllerMap;
			}
			catch
			{
				return null;
			}
		}
	}
}
