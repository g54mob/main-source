using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading;
using Rewired.Data.Mapping;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;
using UnityEngine;

namespace Rewired
{
	public abstract class ControllerMap
	{
		private class xlzaAaXfkqDKcuAWRDLzIwiHrTkm : IComparer<ActionElementMap>
		{
			public static xlzaAaXfkqDKcuAWRDLzIwiHrTkm pEcSNMNyRjNgkciRzMRMgPmMISw;

			public static xlzaAaXfkqDKcuAWRDLzIwiHrTkm Default => pEcSNMNyRjNgkciRzMRMgPmMISw ?? (pEcSNMNyRjNgkciRzMRMgPmMISw = new xlzaAaXfkqDKcuAWRDLzIwiHrTkm());

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
		}

		private sealed class NetMLoMnSlwOuClzkcybOaNnjEdh : IDisposable, IEnumerator, IEnumerable, IEnumerable<ActionElementMap>, IEnumerator<ActionElementMap>
		{
			private ActionElementMap WCNlIsEdYuVTqbNYvICUPcTebLU;

			private int SRJUeDWyyYFsEaMQQCwxNbjBZLJ;

			private int dFCUHNznYmJZjnnffQJUVAprSDy;

			public ControllerMap GxphHAMqMhNBLjnlhXuBQmXaALiE;

			public int aCGiPaCCkBbVoaUFLfEYHFYRMYCM;

			public int gmlZVSBTtPIWuYPylEQcoNUGUio;

			public bool IftNYOsoyZKKlecDyJEriHNLMeG;

			public bool TGDalxAGxtEWicADkzmraNyMfPny;

			public ActionElementMap WycJzDLiPpnjjTwPTiblgfYHqVh;

			public IEnumerator<ActionElementMap> oOiJQmAZYlkNpzlhWqZoTNEPwmU;

			ActionElementMap IEnumerator<ActionElementMap>.Current
			{
				[DebuggerHidden]
				get
				{
					return WCNlIsEdYuVTqbNYvICUPcTebLU;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return WCNlIsEdYuVTqbNYvICUPcTebLU;
				}
			}

			[DebuggerHidden]
			IEnumerator<ActionElementMap> IEnumerable<ActionElementMap>.GetEnumerator()
			{
				NetMLoMnSlwOuClzkcybOaNnjEdh netMLoMnSlwOuClzkcybOaNnjEdh;
				if (Thread.CurrentThread.ManagedThreadId == dFCUHNznYmJZjnnffQJUVAprSDy && SRJUeDWyyYFsEaMQQCwxNbjBZLJ == -2)
				{
					SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 0;
					netMLoMnSlwOuClzkcybOaNnjEdh = this;
				}
				else
				{
					netMLoMnSlwOuClzkcybOaNnjEdh = new NetMLoMnSlwOuClzkcybOaNnjEdh(0);
					netMLoMnSlwOuClzkcybOaNnjEdh.GxphHAMqMhNBLjnlhXuBQmXaALiE = GxphHAMqMhNBLjnlhXuBQmXaALiE;
				}
				netMLoMnSlwOuClzkcybOaNnjEdh.aCGiPaCCkBbVoaUFLfEYHFYRMYCM = gmlZVSBTtPIWuYPylEQcoNUGUio;
				netMLoMnSlwOuClzkcybOaNnjEdh.IftNYOsoyZKKlecDyJEriHNLMeG = TGDalxAGxtEWicADkzmraNyMfPny;
				return netMLoMnSlwOuClzkcybOaNnjEdh;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				try
				{
					switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
					{
					case 0:
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
						if (ReInput._id != GxphHAMqMhNBLjnlhXuBQmXaALiE.VumWnlylMgxSbyJcluXptXvaaZa)
						{
							ReInput.CheckInitialized(GxphHAMqMhNBLjnlhXuBQmXaALiE.VumWnlylMgxSbyJcluXptXvaaZa);
							break;
						}
						oOiJQmAZYlkNpzlhWqZoTNEPwmU = GxphHAMqMhNBLjnlhXuBQmXaALiE.AllMaps.GetEnumerator();
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
						goto IL_00c3;
					case 2:
						{
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
							goto IL_00c3;
						}
						IL_00c3:
						while (oOiJQmAZYlkNpzlhWqZoTNEPwmU.MoveNext())
						{
							WycJzDLiPpnjjTwPTiblgfYHqVh = oOiJQmAZYlkNpzlhWqZoTNEPwmU.Current;
							if (WycJzDLiPpnjjTwPTiblgfYHqVh._actionId == aCGiPaCCkBbVoaUFLfEYHFYRMYCM && (!IftNYOsoyZKKlecDyJEriHNLMeG || WycJzDLiPpnjjTwPTiblgfYHqVh.fnEBjitvkHhPtXTzRLmBYpIxFbt))
							{
								WCNlIsEdYuVTqbNYvICUPcTebLU = WycJzDLiPpnjjTwPTiblgfYHqVh;
								SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 2;
								return true;
							}
						}
						chVanVroUjkfSDecEZVwJLCZdvCD();
						break;
					}
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

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}

			void IDisposable.Dispose()
			{
				switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
				{
				case 1:
				case 2:
					try
					{
						break;
					}
					finally
					{
						chVanVroUjkfSDecEZVwJLCZdvCD();
					}
				}
			}

			[DebuggerHidden]
			public NetMLoMnSlwOuClzkcybOaNnjEdh(int _003C_003E1__state)
			{
				SRJUeDWyyYFsEaMQQCwxNbjBZLJ = _003C_003E1__state;
				dFCUHNznYmJZjnnffQJUVAprSDy = Thread.CurrentThread.ManagedThreadId;
			}

			private void chVanVroUjkfSDecEZVwJLCZdvCD()
			{
				SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
				if (oOiJQmAZYlkNpzlhWqZoTNEPwmU != null)
				{
					oOiJQmAZYlkNpzlhWqZoTNEPwmU.Dispose();
				}
			}
		}

		private sealed class HITDgpgebzfDlvRHRsvlZUKhvUU : IDisposable, IEnumerator, IEnumerable, IEnumerable<ActionElementMap>, IEnumerator<ActionElementMap>
		{
			private ActionElementMap WCNlIsEdYuVTqbNYvICUPcTebLU;

			private int SRJUeDWyyYFsEaMQQCwxNbjBZLJ;

			private int dFCUHNznYmJZjnnffQJUVAprSDy;

			public ControllerMap GxphHAMqMhNBLjnlhXuBQmXaALiE;

			public IControllerElementTarget hUCShNLWPPluAIqgccGiIeEsIkNe;

			public IControllerElementTarget JpiXZhoXgCfPNJtJyBDKpaqTCLOI;

			public bool IftNYOsoyZKKlecDyJEriHNLMeG;

			public bool TGDalxAGxtEWicADkzmraNyMfPny;

			public TempListPool.TList<ActionElementMap> OSIdlIfRejvLsQBLNIcGFfLiRnGS;

			public List<ActionElementMap> dADlnSqnLXKZoIUEdgJvOUsMoCG;

			public bool ylcHLKydvziECQtEqovGFqxUKEZ;

			public ActionElementMap sLQBETdlkpDQREsnVCkhPVRSfbU;

			public List<ActionElementMap>.Enumerator KDjRlccXzkHWSXxXKHWPNjlXTmm;

			ActionElementMap IEnumerator<ActionElementMap>.Current
			{
				[DebuggerHidden]
				get
				{
					return WCNlIsEdYuVTqbNYvICUPcTebLU;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return WCNlIsEdYuVTqbNYvICUPcTebLU;
				}
			}

			[DebuggerHidden]
			IEnumerator<ActionElementMap> IEnumerable<ActionElementMap>.GetEnumerator()
			{
				HITDgpgebzfDlvRHRsvlZUKhvUU hITDgpgebzfDlvRHRsvlZUKhvUU;
				if (Thread.CurrentThread.ManagedThreadId == dFCUHNznYmJZjnnffQJUVAprSDy && SRJUeDWyyYFsEaMQQCwxNbjBZLJ == -2)
				{
					SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 0;
					hITDgpgebzfDlvRHRsvlZUKhvUU = this;
				}
				else
				{
					hITDgpgebzfDlvRHRsvlZUKhvUU = new HITDgpgebzfDlvRHRsvlZUKhvUU(0);
					hITDgpgebzfDlvRHRsvlZUKhvUU.GxphHAMqMhNBLjnlhXuBQmXaALiE = GxphHAMqMhNBLjnlhXuBQmXaALiE;
				}
				hITDgpgebzfDlvRHRsvlZUKhvUU.hUCShNLWPPluAIqgccGiIeEsIkNe = JpiXZhoXgCfPNJtJyBDKpaqTCLOI;
				hITDgpgebzfDlvRHRsvlZUKhvUU.IftNYOsoyZKKlecDyJEriHNLMeG = TGDalxAGxtEWicADkzmraNyMfPny;
				return hITDgpgebzfDlvRHRsvlZUKhvUU;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				try
				{
					int sRJUeDWyyYFsEaMQQCwxNbjBZLJ = SRJUeDWyyYFsEaMQQCwxNbjBZLJ;
					if (sRJUeDWyyYFsEaMQQCwxNbjBZLJ != 0)
					{
						if (sRJUeDWyyYFsEaMQQCwxNbjBZLJ == 3)
						{
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 2;
							goto IL_00d9;
						}
					}
					else
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
						if (ReInput._id == GxphHAMqMhNBLjnlhXuBQmXaALiE.VumWnlylMgxSbyJcluXptXvaaZa)
						{
							OSIdlIfRejvLsQBLNIcGFfLiRnGS = TempListPool.GetTList<ActionElementMap>();
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
							dADlnSqnLXKZoIUEdgJvOUsMoCG = OSIdlIfRejvLsQBLNIcGFfLiRnGS.list;
							GxphHAMqMhNBLjnlhXuBQmXaALiE.VOIVoTgEPzUDZzgXkQydAIFJfLn(hUCShNLWPPluAIqgccGiIeEsIkNe, false, -1, IftNYOsoyZKKlecDyJEriHNLMeG, dADlnSqnLXKZoIUEdgJvOUsMoCG, false, out ylcHLKydvziECQtEqovGFqxUKEZ);
							KDjRlccXzkHWSXxXKHWPNjlXTmm = dADlnSqnLXKZoIUEdgJvOUsMoCG.GetEnumerator();
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 2;
							goto IL_00d9;
						}
						ReInput.CheckInitialized(GxphHAMqMhNBLjnlhXuBQmXaALiE.VumWnlylMgxSbyJcluXptXvaaZa);
					}
					goto IL_00f2;
					IL_00d9:
					if (KDjRlccXzkHWSXxXKHWPNjlXTmm.MoveNext())
					{
						sLQBETdlkpDQREsnVCkhPVRSfbU = KDjRlccXzkHWSXxXKHWPNjlXTmm.Current;
						WCNlIsEdYuVTqbNYvICUPcTebLU = sLQBETdlkpDQREsnVCkhPVRSfbU;
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 3;
						return true;
					}
					EfVpkaLKGNYbSCfBGLSdxCmBshR();
					zvEqGiEjzkXgajKhrFpufuTMQD();
					goto IL_00f2;
					IL_00f2:
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

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}

			void IDisposable.Dispose()
			{
				switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
				{
				case 1:
				case 2:
				case 3:
					try
					{
						switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
						{
						case 2:
						case 3:
							try
							{
								break;
							}
							finally
							{
								EfVpkaLKGNYbSCfBGLSdxCmBshR();
							}
						}
						break;
					}
					finally
					{
						zvEqGiEjzkXgajKhrFpufuTMQD();
					}
				}
			}

			[DebuggerHidden]
			public HITDgpgebzfDlvRHRsvlZUKhvUU(int _003C_003E1__state)
			{
				SRJUeDWyyYFsEaMQQCwxNbjBZLJ = _003C_003E1__state;
				dFCUHNznYmJZjnnffQJUVAprSDy = Thread.CurrentThread.ManagedThreadId;
			}

			private void zvEqGiEjzkXgajKhrFpufuTMQD()
			{
				SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
				if (OSIdlIfRejvLsQBLNIcGFfLiRnGS != null)
				{
					((IDisposable)OSIdlIfRejvLsQBLNIcGFfLiRnGS).Dispose();
				}
			}

			private void EfVpkaLKGNYbSCfBGLSdxCmBshR()
			{
				SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
				((IDisposable)KDjRlccXzkHWSXxXKHWPNjlXTmm/*cast due to .constrained prefix*/).Dispose();
			}
		}

		private sealed class HGorjtFuunRZHUlEjWkzzCNVePY : IDisposable, IEnumerator, IEnumerable, IEnumerable<ActionElementMap>, IEnumerator<ActionElementMap>
		{
			private ActionElementMap WCNlIsEdYuVTqbNYvICUPcTebLU;

			private int SRJUeDWyyYFsEaMQQCwxNbjBZLJ;

			private int dFCUHNznYmJZjnnffQJUVAprSDy;

			public ControllerMap GxphHAMqMhNBLjnlhXuBQmXaALiE;

			public IControllerElementTarget hUCShNLWPPluAIqgccGiIeEsIkNe;

			public IControllerElementTarget JpiXZhoXgCfPNJtJyBDKpaqTCLOI;

			public int aCGiPaCCkBbVoaUFLfEYHFYRMYCM;

			public int gmlZVSBTtPIWuYPylEQcoNUGUio;

			public bool IftNYOsoyZKKlecDyJEriHNLMeG;

			public bool TGDalxAGxtEWicADkzmraNyMfPny;

			public TempListPool.TList<ActionElementMap> LuNUGgKksdNOuCsvXCIHCVaJUVT;

			public List<ActionElementMap> uOAUTtqUtBpTJbvTLhsGxJRdAva;

			public bool oNQSnVrxrRJllnNsNhWpPHOwNmd;

			public ActionElementMap SQduJudIBnGBNkLFcJhVjODJvBDa;

			public List<ActionElementMap>.Enumerator HKHJgysZlOVLDgXaFmEPimwQxhr;

			ActionElementMap IEnumerator<ActionElementMap>.Current
			{
				[DebuggerHidden]
				get
				{
					return WCNlIsEdYuVTqbNYvICUPcTebLU;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return WCNlIsEdYuVTqbNYvICUPcTebLU;
				}
			}

			[DebuggerHidden]
			IEnumerator<ActionElementMap> IEnumerable<ActionElementMap>.GetEnumerator()
			{
				HGorjtFuunRZHUlEjWkzzCNVePY hGorjtFuunRZHUlEjWkzzCNVePY;
				if (Thread.CurrentThread.ManagedThreadId == dFCUHNznYmJZjnnffQJUVAprSDy && SRJUeDWyyYFsEaMQQCwxNbjBZLJ == -2)
				{
					SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 0;
					hGorjtFuunRZHUlEjWkzzCNVePY = this;
				}
				else
				{
					hGorjtFuunRZHUlEjWkzzCNVePY = new HGorjtFuunRZHUlEjWkzzCNVePY(0);
					hGorjtFuunRZHUlEjWkzzCNVePY.GxphHAMqMhNBLjnlhXuBQmXaALiE = GxphHAMqMhNBLjnlhXuBQmXaALiE;
				}
				hGorjtFuunRZHUlEjWkzzCNVePY.hUCShNLWPPluAIqgccGiIeEsIkNe = JpiXZhoXgCfPNJtJyBDKpaqTCLOI;
				hGorjtFuunRZHUlEjWkzzCNVePY.aCGiPaCCkBbVoaUFLfEYHFYRMYCM = gmlZVSBTtPIWuYPylEQcoNUGUio;
				hGorjtFuunRZHUlEjWkzzCNVePY.IftNYOsoyZKKlecDyJEriHNLMeG = TGDalxAGxtEWicADkzmraNyMfPny;
				return hGorjtFuunRZHUlEjWkzzCNVePY;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				try
				{
					int sRJUeDWyyYFsEaMQQCwxNbjBZLJ = SRJUeDWyyYFsEaMQQCwxNbjBZLJ;
					if (sRJUeDWyyYFsEaMQQCwxNbjBZLJ != 0)
					{
						if (sRJUeDWyyYFsEaMQQCwxNbjBZLJ == 3)
						{
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 2;
							goto IL_00de;
						}
					}
					else
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
						if (ReInput._id == GxphHAMqMhNBLjnlhXuBQmXaALiE.VumWnlylMgxSbyJcluXptXvaaZa)
						{
							LuNUGgKksdNOuCsvXCIHCVaJUVT = TempListPool.GetTList<ActionElementMap>();
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
							uOAUTtqUtBpTJbvTLhsGxJRdAva = LuNUGgKksdNOuCsvXCIHCVaJUVT.list;
							GxphHAMqMhNBLjnlhXuBQmXaALiE.VOIVoTgEPzUDZzgXkQydAIFJfLn(hUCShNLWPPluAIqgccGiIeEsIkNe, true, aCGiPaCCkBbVoaUFLfEYHFYRMYCM, IftNYOsoyZKKlecDyJEriHNLMeG, uOAUTtqUtBpTJbvTLhsGxJRdAva, false, out oNQSnVrxrRJllnNsNhWpPHOwNmd);
							HKHJgysZlOVLDgXaFmEPimwQxhr = uOAUTtqUtBpTJbvTLhsGxJRdAva.GetEnumerator();
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 2;
							goto IL_00de;
						}
						ReInput.CheckInitialized(GxphHAMqMhNBLjnlhXuBQmXaALiE.VumWnlylMgxSbyJcluXptXvaaZa);
					}
					goto IL_00f7;
					IL_00de:
					if (HKHJgysZlOVLDgXaFmEPimwQxhr.MoveNext())
					{
						SQduJudIBnGBNkLFcJhVjODJvBDa = HKHJgysZlOVLDgXaFmEPimwQxhr.Current;
						WCNlIsEdYuVTqbNYvICUPcTebLU = SQduJudIBnGBNkLFcJhVjODJvBDa;
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 3;
						return true;
					}
					RScGGuCyniyiPAJMeJiubmQDYqXZ();
					oisJlngpZCarXCgfuAqrDzRJzsTR();
					goto IL_00f7;
					IL_00f7:
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

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
				throw new NotSupportedException();
			}

			void IDisposable.Dispose()
			{
				switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
				{
				case 1:
				case 2:
				case 3:
					try
					{
						switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
						{
						case 2:
						case 3:
							try
							{
								break;
							}
							finally
							{
								RScGGuCyniyiPAJMeJiubmQDYqXZ();
							}
						}
						break;
					}
					finally
					{
						oisJlngpZCarXCgfuAqrDzRJzsTR();
					}
				}
			}

			[DebuggerHidden]
			public HGorjtFuunRZHUlEjWkzzCNVePY(int _003C_003E1__state)
			{
				SRJUeDWyyYFsEaMQQCwxNbjBZLJ = _003C_003E1__state;
				dFCUHNznYmJZjnnffQJUVAprSDy = Thread.CurrentThread.ManagedThreadId;
			}

			private void oisJlngpZCarXCgfuAqrDzRJzsTR()
			{
				SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
				if (LuNUGgKksdNOuCsvXCIHCVaJUVT != null)
				{
					((IDisposable)LuNUGgKksdNOuCsvXCIHCVaJUVT).Dispose();
				}
			}

			private void RScGGuCyniyiPAJMeJiubmQDYqXZ()
			{
				SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
				((IDisposable)HKHJgysZlOVLDgXaFmEPimwQxhr/*cast due to .constrained prefix*/).Dispose();
			}
		}

		private sealed class FCeXouPBLBfiMcrLbcHFKnNxaIF : IDisposable, IEnumerator, IEnumerable, IEnumerable<ActionElementMap>, IEnumerator<ActionElementMap>
		{
			private ActionElementMap WCNlIsEdYuVTqbNYvICUPcTebLU;

			private int SRJUeDWyyYFsEaMQQCwxNbjBZLJ;

			private int dFCUHNznYmJZjnnffQJUVAprSDy;

			public ControllerMap GxphHAMqMhNBLjnlhXuBQmXaALiE;

			public int aCGiPaCCkBbVoaUFLfEYHFYRMYCM;

			public int gmlZVSBTtPIWuYPylEQcoNUGUio;

			public bool IftNYOsoyZKKlecDyJEriHNLMeG;

			public bool TGDalxAGxtEWicADkzmraNyMfPny;

			public IList<ActionElementMap> IJToBtEbFlQtomPxiXihTLcRBHZ;

			public int IWYMzhwBdWgrSFFQcUXujXuluuO;

			public int yOfhqtugJMCDOcTZgGtMDEjELzco;

			public ActionElementMap spvjoYekEYpwfwUUzFZulddoZuJ;

			ActionElementMap IEnumerator<ActionElementMap>.Current
			{
				[DebuggerHidden]
				get
				{
					return WCNlIsEdYuVTqbNYvICUPcTebLU;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return WCNlIsEdYuVTqbNYvICUPcTebLU;
				}
			}

			[DebuggerHidden]
			IEnumerator<ActionElementMap> IEnumerable<ActionElementMap>.GetEnumerator()
			{
				FCeXouPBLBfiMcrLbcHFKnNxaIF fCeXouPBLBfiMcrLbcHFKnNxaIF;
				if (Thread.CurrentThread.ManagedThreadId == dFCUHNznYmJZjnnffQJUVAprSDy && SRJUeDWyyYFsEaMQQCwxNbjBZLJ == -2)
				{
					SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 0;
					fCeXouPBLBfiMcrLbcHFKnNxaIF = this;
				}
				else
				{
					fCeXouPBLBfiMcrLbcHFKnNxaIF = new FCeXouPBLBfiMcrLbcHFKnNxaIF(0);
					fCeXouPBLBfiMcrLbcHFKnNxaIF.GxphHAMqMhNBLjnlhXuBQmXaALiE = GxphHAMqMhNBLjnlhXuBQmXaALiE;
				}
				fCeXouPBLBfiMcrLbcHFKnNxaIF.aCGiPaCCkBbVoaUFLfEYHFYRMYCM = gmlZVSBTtPIWuYPylEQcoNUGUio;
				fCeXouPBLBfiMcrLbcHFKnNxaIF.IftNYOsoyZKKlecDyJEriHNLMeG = TGDalxAGxtEWicADkzmraNyMfPny;
				return fCeXouPBLBfiMcrLbcHFKnNxaIF;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
				{
				case 0:
					SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
					if (ReInput._id != GxphHAMqMhNBLjnlhXuBQmXaALiE.VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(GxphHAMqMhNBLjnlhXuBQmXaALiE.VumWnlylMgxSbyJcluXptXvaaZa);
						break;
					}
					if (aCGiPaCCkBbVoaUFLfEYHFYRMYCM < 0)
					{
						break;
					}
					IJToBtEbFlQtomPxiXihTLcRBHZ = GxphHAMqMhNBLjnlhXuBQmXaALiE.ButtonMaps;
					IWYMzhwBdWgrSFFQcUXujXuluuO = GxphHAMqMhNBLjnlhXuBQmXaALiE.buttonMapCount;
					yOfhqtugJMCDOcTZgGtMDEjELzco = 0;
					goto IL_00e9;
				case 1:
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
						goto IL_00db;
					}
					IL_00db:
					yOfhqtugJMCDOcTZgGtMDEjELzco++;
					goto IL_00e9;
					IL_00e9:
					if (yOfhqtugJMCDOcTZgGtMDEjELzco >= IWYMzhwBdWgrSFFQcUXujXuluuO)
					{
						break;
					}
					spvjoYekEYpwfwUUzFZulddoZuJ = IJToBtEbFlQtomPxiXihTLcRBHZ[yOfhqtugJMCDOcTZgGtMDEjELzco];
					if (spvjoYekEYpwfwUUzFZulddoZuJ._actionId == aCGiPaCCkBbVoaUFLfEYHFYRMYCM && (!IftNYOsoyZKKlecDyJEriHNLMeG || spvjoYekEYpwfwUUzFZulddoZuJ.fnEBjitvkHhPtXTzRLmBYpIxFbt))
					{
						WCNlIsEdYuVTqbNYvICUPcTebLU = spvjoYekEYpwfwUUzFZulddoZuJ;
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
						return true;
					}
					goto IL_00db;
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
			public FCeXouPBLBfiMcrLbcHFKnNxaIF(int _003C_003E1__state)
			{
				SRJUeDWyyYFsEaMQQCwxNbjBZLJ = _003C_003E1__state;
				dFCUHNznYmJZjnnffQJUVAprSDy = Thread.CurrentThread.ManagedThreadId;
			}
		}

		private sealed class xDpgBiETmjXajxLNJHOifbfCfKjl : IDisposable, IEnumerator, IEnumerable, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
		{
			private ElementAssignmentConflictInfo WCNlIsEdYuVTqbNYvICUPcTebLU;

			private int SRJUeDWyyYFsEaMQQCwxNbjBZLJ;

			private int dFCUHNznYmJZjnnffQJUVAprSDy;

			public ControllerMap GxphHAMqMhNBLjnlhXuBQmXaALiE;

			public ControllerMap nuUgjEKzUuMYBIiHUtitJvzUOOl;

			public ControllerMap sNhfYAVoaqivqYEVUlVeZtnUREN;

			public bool IftNYOsoyZKKlecDyJEriHNLMeG;

			public bool TGDalxAGxtEWicADkzmraNyMfPny;

			public IList<ActionElementMap> mLybHWNsASQniNkyxRSKFbUgsVm;

			public int JfJdaEJDOcXpEOXywmBvpiNZdhEA;

			public int bmyGttYvaihaolQALcwaKtYppsS;

			public ActionElementMap WVBAullwjpgJaaXggVToeyToLcY;

			public int GlBoCIMpgFVJtTVQREoGiKBQQZL;

			public ActionElementMap UArgGuipYgyYiHwXDcovbOZogOGz;

			ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return WCNlIsEdYuVTqbNYvICUPcTebLU;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return WCNlIsEdYuVTqbNYvICUPcTebLU;
				}
			}

			[DebuggerHidden]
			IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
			{
				xDpgBiETmjXajxLNJHOifbfCfKjl xDpgBiETmjXajxLNJHOifbfCfKjl2;
				if (Thread.CurrentThread.ManagedThreadId == dFCUHNznYmJZjnnffQJUVAprSDy && SRJUeDWyyYFsEaMQQCwxNbjBZLJ == -2)
				{
					SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 0;
					xDpgBiETmjXajxLNJHOifbfCfKjl2 = this;
				}
				else
				{
					xDpgBiETmjXajxLNJHOifbfCfKjl2 = new xDpgBiETmjXajxLNJHOifbfCfKjl(0);
					xDpgBiETmjXajxLNJHOifbfCfKjl2.GxphHAMqMhNBLjnlhXuBQmXaALiE = GxphHAMqMhNBLjnlhXuBQmXaALiE;
				}
				xDpgBiETmjXajxLNJHOifbfCfKjl2.nuUgjEKzUuMYBIiHUtitJvzUOOl = sNhfYAVoaqivqYEVUlVeZtnUREN;
				xDpgBiETmjXajxLNJHOifbfCfKjl2.IftNYOsoyZKKlecDyJEriHNLMeG = TGDalxAGxtEWicADkzmraNyMfPny;
				return xDpgBiETmjXajxLNJHOifbfCfKjl2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
				{
				case 0:
					SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
					if (ReInput._id != GxphHAMqMhNBLjnlhXuBQmXaALiE.VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(GxphHAMqMhNBLjnlhXuBQmXaALiE.VumWnlylMgxSbyJcluXptXvaaZa);
						break;
					}
					if (nuUgjEKzUuMYBIiHUtitJvzUOOl == null || GxphHAMqMhNBLjnlhXuBQmXaALiE.YkTTJefdVTAYyECYQpCbYHQOWGx == null || (IftNYOsoyZKKlecDyJEriHNLMeG && (!GxphHAMqMhNBLjnlhXuBQmXaALiE._enabled || !nuUgjEKzUuMYBIiHUtitJvzUOOl._enabled)))
					{
						break;
					}
					mLybHWNsASQniNkyxRSKFbUgsVm = nuUgjEKzUuMYBIiHUtitJvzUOOl.ButtonMaps;
					if (mLybHWNsASQniNkyxRSKFbUgsVm == null)
					{
						break;
					}
					JfJdaEJDOcXpEOXywmBvpiNZdhEA = mLybHWNsASQniNkyxRSKFbUgsVm.Count;
					bmyGttYvaihaolQALcwaKtYppsS = 0;
					goto IL_0211;
				case 1:
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
						goto IL_01e4;
					}
					IL_01f2:
					if (GlBoCIMpgFVJtTVQREoGiKBQQZL < JfJdaEJDOcXpEOXywmBvpiNZdhEA)
					{
						UArgGuipYgyYiHwXDcovbOZogOGz = mLybHWNsASQniNkyxRSKFbUgsVm[GlBoCIMpgFVJtTVQREoGiKBQQZL];
						if ((!IftNYOsoyZKKlecDyJEriHNLMeG || UArgGuipYgyYiHwXDcovbOZogOGz.fnEBjitvkHhPtXTzRLmBYpIxFbt) && WVBAullwjpgJaaXggVToeyToLcY.CheckForAssignmentConflict(UArgGuipYgyYiHwXDcovbOZogOGz))
						{
							WCNlIsEdYuVTqbNYvICUPcTebLU = new ElementAssignmentConflictInfo(isConflict: true, ReInput.mapping.GetMapCategory(GxphHAMqMhNBLjnlhXuBQmXaALiE._categoryId).userAssignable, -1, GxphHAMqMhNBLjnlhXuBQmXaALiE._controllerType, GxphHAMqMhNBLjnlhXuBQmXaALiE._controllerId, GxphHAMqMhNBLjnlhXuBQmXaALiE._id, WVBAullwjpgJaaXggVToeyToLcY.JYRMuwETpVNRqJXmtBgBFhZdTeP, WVBAullwjpgJaaXggVToeyToLcY._actionId, WVBAullwjpgJaaXggVToeyToLcY._elementType, WVBAullwjpgJaaXggVToeyToLcY._elementIdentifierId, WVBAullwjpgJaaXggVToeyToLcY.keyCode, WVBAullwjpgJaaXggVToeyToLcY.modifierKeyFlags);
							SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
							return true;
						}
						goto IL_01e4;
					}
					goto IL_0203;
					IL_01e4:
					GlBoCIMpgFVJtTVQREoGiKBQQZL++;
					goto IL_01f2;
					IL_0211:
					if (bmyGttYvaihaolQALcwaKtYppsS >= GxphHAMqMhNBLjnlhXuBQmXaALiE.YkTTJefdVTAYyECYQpCbYHQOWGx.Count)
					{
						break;
					}
					WVBAullwjpgJaaXggVToeyToLcY = GxphHAMqMhNBLjnlhXuBQmXaALiE.YkTTJefdVTAYyECYQpCbYHQOWGx[bmyGttYvaihaolQALcwaKtYppsS];
					if (!IftNYOsoyZKKlecDyJEriHNLMeG || WVBAullwjpgJaaXggVToeyToLcY.fnEBjitvkHhPtXTzRLmBYpIxFbt)
					{
						GlBoCIMpgFVJtTVQREoGiKBQQZL = 0;
						goto IL_01f2;
					}
					goto IL_0203;
					IL_0203:
					bmyGttYvaihaolQALcwaKtYppsS++;
					goto IL_0211;
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
			public xDpgBiETmjXajxLNJHOifbfCfKjl(int _003C_003E1__state)
			{
				SRJUeDWyyYFsEaMQQCwxNbjBZLJ = _003C_003E1__state;
				dFCUHNznYmJZjnnffQJUVAprSDy = Thread.CurrentThread.ManagedThreadId;
			}
		}

		private sealed class MwvNNOMOtZMVYArBfWDZWGBucnGC : IDisposable, IEnumerator, IEnumerable, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
		{
			private ElementAssignmentConflictInfo WCNlIsEdYuVTqbNYvICUPcTebLU;

			private int SRJUeDWyyYFsEaMQQCwxNbjBZLJ;

			private int dFCUHNznYmJZjnnffQJUVAprSDy;

			public ControllerMap GxphHAMqMhNBLjnlhXuBQmXaALiE;

			public ActionElementMap PgtyCGUpZbAlPcnBMkOdtmXxupEd;

			public ActionElementMap mHXCJMfdawKqIiVysYybBSiVrhGm;

			public bool IftNYOsoyZKKlecDyJEriHNLMeG;

			public bool TGDalxAGxtEWicADkzmraNyMfPny;

			public int PscUdWeGHvezsCSdIcuJEchoCbXO;

			public ActionElementMap sNmYXRbnTJBJuPyfofGRtBMPete;

			ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return WCNlIsEdYuVTqbNYvICUPcTebLU;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return WCNlIsEdYuVTqbNYvICUPcTebLU;
				}
			}

			[DebuggerHidden]
			IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
			{
				MwvNNOMOtZMVYArBfWDZWGBucnGC mwvNNOMOtZMVYArBfWDZWGBucnGC;
				if (Thread.CurrentThread.ManagedThreadId == dFCUHNznYmJZjnnffQJUVAprSDy && SRJUeDWyyYFsEaMQQCwxNbjBZLJ == -2)
				{
					SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 0;
					mwvNNOMOtZMVYArBfWDZWGBucnGC = this;
				}
				else
				{
					mwvNNOMOtZMVYArBfWDZWGBucnGC = new MwvNNOMOtZMVYArBfWDZWGBucnGC(0);
					mwvNNOMOtZMVYArBfWDZWGBucnGC.GxphHAMqMhNBLjnlhXuBQmXaALiE = GxphHAMqMhNBLjnlhXuBQmXaALiE;
				}
				mwvNNOMOtZMVYArBfWDZWGBucnGC.PgtyCGUpZbAlPcnBMkOdtmXxupEd = mHXCJMfdawKqIiVysYybBSiVrhGm;
				mwvNNOMOtZMVYArBfWDZWGBucnGC.IftNYOsoyZKKlecDyJEriHNLMeG = TGDalxAGxtEWicADkzmraNyMfPny;
				return mwvNNOMOtZMVYArBfWDZWGBucnGC;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
				{
				case 0:
					SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
					if (ReInput._id != GxphHAMqMhNBLjnlhXuBQmXaALiE.VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(GxphHAMqMhNBLjnlhXuBQmXaALiE.VumWnlylMgxSbyJcluXptXvaaZa);
						break;
					}
					if (PgtyCGUpZbAlPcnBMkOdtmXxupEd == null || GxphHAMqMhNBLjnlhXuBQmXaALiE.YkTTJefdVTAYyECYQpCbYHQOWGx == null || (IftNYOsoyZKKlecDyJEriHNLMeG && (!GxphHAMqMhNBLjnlhXuBQmXaALiE._enabled || !PgtyCGUpZbAlPcnBMkOdtmXxupEd.fnEBjitvkHhPtXTzRLmBYpIxFbt)))
					{
						break;
					}
					PscUdWeGHvezsCSdIcuJEchoCbXO = 0;
					goto IL_018a;
				case 1:
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
						goto IL_017c;
					}
					IL_018a:
					if (PscUdWeGHvezsCSdIcuJEchoCbXO >= GxphHAMqMhNBLjnlhXuBQmXaALiE.YkTTJefdVTAYyECYQpCbYHQOWGx.Count)
					{
						break;
					}
					sNmYXRbnTJBJuPyfofGRtBMPete = GxphHAMqMhNBLjnlhXuBQmXaALiE.YkTTJefdVTAYyECYQpCbYHQOWGx[PscUdWeGHvezsCSdIcuJEchoCbXO];
					if ((!IftNYOsoyZKKlecDyJEriHNLMeG || sNmYXRbnTJBJuPyfofGRtBMPete.fnEBjitvkHhPtXTzRLmBYpIxFbt) && sNmYXRbnTJBJuPyfofGRtBMPete.CheckForAssignmentConflict(PgtyCGUpZbAlPcnBMkOdtmXxupEd))
					{
						WCNlIsEdYuVTqbNYvICUPcTebLU = new ElementAssignmentConflictInfo(isConflict: true, ReInput.mapping.GetMapCategory(GxphHAMqMhNBLjnlhXuBQmXaALiE._categoryId).userAssignable, -1, GxphHAMqMhNBLjnlhXuBQmXaALiE._controllerType, GxphHAMqMhNBLjnlhXuBQmXaALiE._controllerId, GxphHAMqMhNBLjnlhXuBQmXaALiE._id, sNmYXRbnTJBJuPyfofGRtBMPete.JYRMuwETpVNRqJXmtBgBFhZdTeP, sNmYXRbnTJBJuPyfofGRtBMPete._actionId, sNmYXRbnTJBJuPyfofGRtBMPete._elementType, sNmYXRbnTJBJuPyfofGRtBMPete._elementIdentifierId, sNmYXRbnTJBJuPyfofGRtBMPete.keyCode, sNmYXRbnTJBJuPyfofGRtBMPete.modifierKeyFlags);
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
						return true;
					}
					goto IL_017c;
					IL_017c:
					PscUdWeGHvezsCSdIcuJEchoCbXO++;
					goto IL_018a;
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
			public MwvNNOMOtZMVYArBfWDZWGBucnGC(int _003C_003E1__state)
			{
				SRJUeDWyyYFsEaMQQCwxNbjBZLJ = _003C_003E1__state;
				dFCUHNznYmJZjnnffQJUVAprSDy = Thread.CurrentThread.ManagedThreadId;
			}
		}

		private sealed class LEnGbFiDtcwRrWpWhQUfVLTRjxf : IDisposable, IEnumerator, IEnumerable, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
		{
			private ElementAssignmentConflictInfo WCNlIsEdYuVTqbNYvICUPcTebLU;

			private int SRJUeDWyyYFsEaMQQCwxNbjBZLJ;

			private int dFCUHNznYmJZjnnffQJUVAprSDy;

			public ControllerMap GxphHAMqMhNBLjnlhXuBQmXaALiE;

			public ElementAssignmentConflictCheck CNxRWxtJdpKgAXgEBkMvLnqPffs;

			public ElementAssignmentConflictCheck VliyeXpMEMSvNHleVqLftHsOCYq;

			public bool IftNYOsoyZKKlecDyJEriHNLMeG;

			public bool TGDalxAGxtEWicADkzmraNyMfPny;

			public ElementAssignment PTekgSTzIAtQWMXIQOFEFKnoAZqh;

			public int uKnDzxdcaNvJNbbckwiXpUEmrER;

			public ActionElementMap uAxunisBgKdOnPJsaBXtBtZcIoS;

			ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return WCNlIsEdYuVTqbNYvICUPcTebLU;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return WCNlIsEdYuVTqbNYvICUPcTebLU;
				}
			}

			[DebuggerHidden]
			IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
			{
				LEnGbFiDtcwRrWpWhQUfVLTRjxf lEnGbFiDtcwRrWpWhQUfVLTRjxf;
				if (Thread.CurrentThread.ManagedThreadId == dFCUHNznYmJZjnnffQJUVAprSDy && SRJUeDWyyYFsEaMQQCwxNbjBZLJ == -2)
				{
					SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 0;
					lEnGbFiDtcwRrWpWhQUfVLTRjxf = this;
				}
				else
				{
					lEnGbFiDtcwRrWpWhQUfVLTRjxf = new LEnGbFiDtcwRrWpWhQUfVLTRjxf(0);
					lEnGbFiDtcwRrWpWhQUfVLTRjxf.GxphHAMqMhNBLjnlhXuBQmXaALiE = GxphHAMqMhNBLjnlhXuBQmXaALiE;
				}
				lEnGbFiDtcwRrWpWhQUfVLTRjxf.CNxRWxtJdpKgAXgEBkMvLnqPffs = VliyeXpMEMSvNHleVqLftHsOCYq;
				lEnGbFiDtcwRrWpWhQUfVLTRjxf.IftNYOsoyZKKlecDyJEriHNLMeG = TGDalxAGxtEWicADkzmraNyMfPny;
				return lEnGbFiDtcwRrWpWhQUfVLTRjxf;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				switch (SRJUeDWyyYFsEaMQQCwxNbjBZLJ)
				{
				case 0:
					SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
					if (ReInput._id != GxphHAMqMhNBLjnlhXuBQmXaALiE.VumWnlylMgxSbyJcluXptXvaaZa)
					{
						ReInput.CheckInitialized(GxphHAMqMhNBLjnlhXuBQmXaALiE.VumWnlylMgxSbyJcluXptXvaaZa);
						break;
					}
					if ((IftNYOsoyZKKlecDyJEriHNLMeG && !GxphHAMqMhNBLjnlhXuBQmXaALiE._enabled) || GxphHAMqMhNBLjnlhXuBQmXaALiE.YkTTJefdVTAYyECYQpCbYHQOWGx == null)
					{
						break;
					}
					PTekgSTzIAtQWMXIQOFEFKnoAZqh = CNxRWxtJdpKgAXgEBkMvLnqPffs.ToElementAssignment();
					uKnDzxdcaNvJNbbckwiXpUEmrER = 0;
					goto IL_019b;
				case 1:
					{
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = -1;
						goto IL_018d;
					}
					IL_019b:
					if (uKnDzxdcaNvJNbbckwiXpUEmrER >= GxphHAMqMhNBLjnlhXuBQmXaALiE.YkTTJefdVTAYyECYQpCbYHQOWGx.Count)
					{
						break;
					}
					uAxunisBgKdOnPJsaBXtBtZcIoS = GxphHAMqMhNBLjnlhXuBQmXaALiE.YkTTJefdVTAYyECYQpCbYHQOWGx[uKnDzxdcaNvJNbbckwiXpUEmrER];
					if ((!IftNYOsoyZKKlecDyJEriHNLMeG || uAxunisBgKdOnPJsaBXtBtZcIoS.fnEBjitvkHhPtXTzRLmBYpIxFbt) && uAxunisBgKdOnPJsaBXtBtZcIoS.JYRMuwETpVNRqJXmtBgBFhZdTeP != CNxRWxtJdpKgAXgEBkMvLnqPffs.elementMapId && uAxunisBgKdOnPJsaBXtBtZcIoS.CheckForAssignmentConflict(PTekgSTzIAtQWMXIQOFEFKnoAZqh))
					{
						WCNlIsEdYuVTqbNYvICUPcTebLU = new ElementAssignmentConflictInfo(isConflict: true, ReInput.mapping.GetMapCategory(GxphHAMqMhNBLjnlhXuBQmXaALiE._categoryId).userAssignable, -1, GxphHAMqMhNBLjnlhXuBQmXaALiE._controllerType, GxphHAMqMhNBLjnlhXuBQmXaALiE._controllerId, GxphHAMqMhNBLjnlhXuBQmXaALiE._id, uAxunisBgKdOnPJsaBXtBtZcIoS.JYRMuwETpVNRqJXmtBgBFhZdTeP, uAxunisBgKdOnPJsaBXtBtZcIoS._actionId, uAxunisBgKdOnPJsaBXtBtZcIoS._elementType, uAxunisBgKdOnPJsaBXtBtZcIoS._elementIdentifierId, uAxunisBgKdOnPJsaBXtBtZcIoS.keyCode, uAxunisBgKdOnPJsaBXtBtZcIoS.modifierKeyFlags);
						SRJUeDWyyYFsEaMQQCwxNbjBZLJ = 1;
						return true;
					}
					goto IL_018d;
					IL_018d:
					uKnDzxdcaNvJNbbckwiXpUEmrER++;
					goto IL_019b;
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
			public LEnGbFiDtcwRrWpWhQUfVLTRjxf(int _003C_003E1__state)
			{
				SRJUeDWyyYFsEaMQQCwxNbjBZLJ = _003C_003E1__state;
				dFCUHNznYmJZjnnffQJUVAprSDy = Thread.CurrentThread.ManagedThreadId;
			}
		}

		protected int _id;

		protected int _sourceMapId;

		protected int _categoryId;

		protected int _layoutId;

		protected string _name;

		protected Guid _hardwareGuid;

		protected bool _enabled;

		internal readonly int VumWnlylMgxSbyJcluXptXvaaZa;

		private readonly AList<ActionElementMap> YkTTJefdVTAYyECYQpCbYHQOWGx;

		private readonly ReadOnlyCollection<ActionElementMap> OQsUHruEMHlLZGyAMwpYfYqhhlY;

		private readonly AList<ActionElementMap> bAHtrfdakdbHbbbKUCDCgljGflpo;

		private readonly ReadOnlyCollection<ActionElementMap> rhXeRPhYZmwZCIxlzjqHUJrRBoLO;

		protected int _playerId;

		protected int _controllerId;

		protected ControllerType _controllerType;

		private static int KBmRqZxgIwbneAzLHYuHBnNFpMhs;

		private static int nextUid
		{
			get
			{
				int kBmRqZxgIwbneAzLHYuHBnNFpMhs = KBmRqZxgIwbneAzLHYuHBnNFpMhs;
				if (KBmRqZxgIwbneAzLHYuHBnNFpMhs == int.MaxValue)
				{
					KBmRqZxgIwbneAzLHYuHBnNFpMhs = 0;
				}
				else
				{
					KBmRqZxgIwbneAzLHYuHBnNFpMhs++;
				}
				return kBmRqZxgIwbneAzLHYuHBnNFpMhs;
			}
		}

		public int id
		{
			get
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return -1;
				}
				return _id;
			}
		}

		public int sourceMapId
		{
			get
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return -1;
				}
				return _sourceMapId;
			}
			internal set
			{
				_sourceMapId = value;
			}
		}

		public int categoryId
		{
			get
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return -1;
				}
				return _categoryId;
			}
			internal set
			{
				_categoryId = value;
			}
		}

		public int layoutId
		{
			get
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return -1;
				}
				return _layoutId;
			}
			internal set
			{
				_layoutId = value;
			}
		}

		public string name
		{
			get
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return string.Empty;
				}
				return _name;
			}
			internal set
			{
				_name = value;
			}
		}

		public Guid hardwareGuid
		{
			get
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return Guid.Empty;
				}
				return _hardwareGuid;
			}
			internal set
			{
				_hardwareGuid = value;
			}
		}

		public bool enabled
		{
			get
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
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
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return -1;
				}
				return _playerId;
			}
			internal set
			{
				_playerId = value;
			}
		}

		public int controllerId
		{
			get
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return -1;
				}
				return _controllerId;
			}
			internal set
			{
				_controllerId = value;
			}
		}

		public Controller controller
		{
			get
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return null;
				}
				return ReInput.controllers.GetController(_controllerType, _controllerId);
			}
		}

		public ControllerType controllerType
		{
			get
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return ControllerType.Keyboard;
				}
				return _controllerType;
			}
			internal set
			{
				_controllerType = value;
			}
		}

		public Player player
		{
			get
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return null;
				}
				return ReInput.players.GetPlayer(_playerId);
			}
		}

		public int elementMapCount
		{
			get
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return 0;
				}
				return bAHtrfdakdbHbbbKUCDCgljGflpo.Count;
			}
		}

		public int buttonMapCount
		{
			get
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return 0;
				}
				return YkTTJefdVTAYyECYQpCbYHQOWGx.Count;
			}
		}

		public IList<ActionElementMap> AllMaps
		{
			get
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
				}
				return rhXeRPhYZmwZCIxlzjqHUJrRBoLO;
			}
		}

		public IList<ActionElementMap> ButtonMaps
		{
			get
			{
				if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
				{
					ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
					return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
				}
				return OQsUHruEMHlLZGyAMwpYfYqhhlY;
			}
		}

		internal AList<ActionElementMap> ButtonMaps_orig => YkTTJefdVTAYyECYQpCbYHQOWGx;

		public ControllerMap()
		{
			_id = nextUid;
			_sourceMapId = -1;
			YkTTJefdVTAYyECYQpCbYHQOWGx = new AList<ActionElementMap>();
			OQsUHruEMHlLZGyAMwpYfYqhhlY = new ReadOnlyCollection<ActionElementMap>(YkTTJefdVTAYyECYQpCbYHQOWGx);
			bAHtrfdakdbHbbbKUCDCgljGflpo = new AList<ActionElementMap>();
			rhXeRPhYZmwZCIxlzjqHUJrRBoLO = new ReadOnlyCollection<ActionElementMap>(bAHtrfdakdbHbbbKUCDCgljGflpo);
			VumWnlylMgxSbyJcluXptXvaaZa = ReInput.id;
		}

		public ControllerMap(ControllerMap source)
			: this()
		{
			_id = nextUid;
			_sourceMapId = source._sourceMapId;
			_categoryId = source._categoryId;
			_layoutId = source._layoutId;
			_name = source._name;
			_hardwareGuid = source._hardwareGuid;
			_enabled = source._enabled;
			_playerId = source._playerId;
			_controllerId = source._controllerId;
			_controllerType = source._controllerType;
			if (source.YkTTJefdVTAYyECYQpCbYHQOWGx != null)
			{
				int count = source.YkTTJefdVTAYyECYQpCbYHQOWGx.Count;
				for (int i = 0; i < count; i++)
				{
					DsowFbtcOyiDrdyfjcycNGirkoAa(new ActionElementMap(source.YkTTJefdVTAYyECYQpCbYHQOWGx[i]));
				}
			}
		}

		public bool ContainsAction(string actionName)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			InputAction inputAction = ReInput.XVroGTnTmiTwGITDVAhlDMsuaLiG.foeDsFJMSKPZnHiDHArgvpAmVTU(actionName, true);
			if (inputAction == null)
			{
				return false;
			}
			return ContainsAction(inputAction.id);
		}

		public virtual bool ContainsAction(int actionId)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			if (actionId < 0)
			{
				return false;
			}
			int num = buttonMapCount;
			for (int i = 0; i < num; i++)
			{
				if (YkTTJefdVTAYyECYQpCbYHQOWGx[i]._actionId == actionId)
				{
					return true;
				}
			}
			return false;
		}

		public bool ContainsElementIdentifier(int elementIdentifierId)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			AList<ActionElementMap> aList = bAHtrfdakdbHbbbKUCDCgljGflpo;
			for (int i = 0; i < aList.Count; i++)
			{
				if (bAHtrfdakdbHbbbKUCDCgljGflpo[i].elementIdentifierId == elementIdentifierId)
				{
					return true;
				}
			}
			return false;
		}

		public bool ContainsKeyboardKey(KeyCode keyCode, ModifierKeyFlags modifierKeys)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			AList<ActionElementMap> aList = bAHtrfdakdbHbbbKUCDCgljGflpo;
			for (int i = 0; i < aList.Count; i++)
			{
				if (bAHtrfdakdbHbbbKUCDCgljGflpo[i].keyCode == keyCode && bAHtrfdakdbHbbbKUCDCgljGflpo[i].modifierKeyFlags == modifierKeys)
				{
					return true;
				}
			}
			return false;
		}

		public bool ContainsElementMap(ActionElementMap elementMap)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			if (elementMap == null)
			{
				return false;
			}
			AList<ActionElementMap> aList = bAHtrfdakdbHbbbKUCDCgljGflpo;
			for (int i = 0; i < aList.Count; i++)
			{
				if (bAHtrfdakdbHbbbKUCDCgljGflpo[i].JYRMuwETpVNRqJXmtBgBFhZdTeP == elementMap.id)
				{
					return true;
				}
			}
			return false;
		}

		public bool ContainsElementMap(int elementMapId)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			AList<ActionElementMap> aList = bAHtrfdakdbHbbbKUCDCgljGflpo;
			for (int i = 0; i < aList.Count; i++)
			{
				if (bAHtrfdakdbHbbbKUCDCgljGflpo[i].JYRMuwETpVNRqJXmtBgBFhZdTeP == elementMapId)
				{
					return true;
				}
			}
			return false;
		}

		public bool ReplaceOrCreateElementMap(ElementAssignment elementAssignment)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			ActionElementMap result;
			return ReplaceOrCreateElementMap(elementAssignment, out result);
		}

		public bool ReplaceOrCreateElementMap(ElementAssignment elementAssignment, out ActionElementMap result)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				result = null;
				return false;
			}
			ActionElementMap elementMap = GetElementMap(elementAssignment.elementMapId);
			if (elementMap == null)
			{
				return CreateElementMap(elementAssignment, out result);
			}
			return ReplaceElementMap(elementAssignment, out result);
		}

		public bool CreateElementMap(ElementAssignment elementAssignment)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			ActionElementMap result;
			return CreateElementMap(elementAssignment, out result);
		}

		public bool CreateElementMap(ElementAssignment elementAssignment, out ActionElementMap result)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				result = null;
				return false;
			}
			if (_controllerType == ControllerType.Keyboard)
			{
				return CreateElementMap(elementAssignment.actionId, elementAssignment.axisContribution, elementAssignment.keyboardKey, elementAssignment.modifierKeyFlags, out result);
			}
			if (_controllerType == ControllerType.Joystick || _controllerType == ControllerType.Mouse || _controllerType == ControllerType.Custom)
			{
				return CreateElementMap(elementAssignment.actionId, elementAssignment.axisContribution, elementAssignment.elementIdentifierId, XqmnYoifzflCsKxcFaHDewlkEkh.oVgOuHppbsfQJuEfZwNSyeJURnL(elementAssignment.type), elementAssignment.axisRange, elementAssignment.invert, out result);
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
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				result = null;
				return false;
			}
			ActionElementMap actionElementMap = new ActionElementMap(actionId, ControllerElementType.Button, axisContribution, (KeyboardKeyCode)keyCode, modifierKey1, modifierKey2, modifierKey3);
			ReInput.controllers.Keyboard.IginakiartMCXcNztgFGkBgBmEe(this, actionElementMap);
			DsowFbtcOyiDrdyfjcycNGirkoAa(actionElementMap);
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
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				result = null;
				return false;
			}
			dNIkkpHmbenRXMbwvhZsDaEKwGD dNIkkpHmbenRXMbwvhZsDaEKwGD2 = dNIkkpHmbenRXMbwvhZsDaEKwGD.NyBUUOCvTkHIxpgoRNwhNoOJOKx(modifierKeyFlags);
			return CreateElementMap(actionId, axisContribution, keyCode, dNIkkpHmbenRXMbwvhZsDaEKwGD2.dzVdjlEVQwgzvzhVUKnnyxEfDccq, dNIkkpHmbenRXMbwvhZsDaEKwGD2.QevfNgMhRGjlsMgBpjDuDOAeljTh, dNIkkpHmbenRXMbwvhZsDaEKwGD2.yKFGycBpxalffjUWjPHPvRPQTWmG, out result);
		}

		public bool CreateElementMap(int actionId, Pole axisContribution, int elementIdentifierId, ControllerElementType elementType, AxisRange axisRange, bool invert)
		{
			ActionElementMap result;
			return CreateElementMap(actionId, axisContribution, elementIdentifierId, elementType, axisRange, invert, out result);
		}

		public virtual bool CreateElementMap(int actionId, Pole axisContribution, int elementIdentifierId, ControllerElementType elementType, AxisRange axisRange, bool invert, out ActionElementMap result)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				result = null;
				return false;
			}
			if (!bbEggoxgYPAkARDGnCkXZJCiEYGa(elementType))
			{
				result = null;
				return false;
			}
			ActionElementMap actionElementMap = new ActionElementMap(actionId, elementType, elementIdentifierId, axisContribution, axisRange);
			BakeElementMap(actionElementMap);
			DsowFbtcOyiDrdyfjcycNGirkoAa(actionElementMap);
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
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				result = null;
				return false;
			}
			if (_controllerType == ControllerType.Keyboard)
			{
				return ReplaceElementMap(elementAssignment.elementMapId, elementAssignment.actionId, elementAssignment.axisContribution, elementAssignment.keyboardKey, elementAssignment.modifierKeyFlags, out result);
			}
			if (_controllerType == ControllerType.Joystick || _controllerType == ControllerType.Mouse || _controllerType == ControllerType.Custom)
			{
				return ReplaceElementMap(elementAssignment.elementMapId, elementAssignment.actionId, elementAssignment.axisContribution, elementAssignment.elementIdentifierId, XqmnYoifzflCsKxcFaHDewlkEkh.oVgOuHppbsfQJuEfZwNSyeJURnL(elementAssignment.type), elementAssignment.axisRange, elementAssignment.invert, out result);
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
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				result = null;
				return false;
			}
			ActionElementMap elementMap = GetElementMap(elementMapId);
			if (elementMap == null)
			{
				result = null;
				return false;
			}
			int num = kMXCVlsFwJKKRzfwDXYvOGCsgtD(elementMapId);
			if (num < 0)
			{
				DeleteElementMap(elementMapId);
				elementMap._elementType = ControllerElementType.Button;
				DsowFbtcOyiDrdyfjcycNGirkoAa(elementMap);
			}
			num = kMXCVlsFwJKKRzfwDXYvOGCsgtD(elementMapId);
			if (num < 0)
			{
				result = null;
				return false;
			}
			elementMap.VcHhfbFqwxAmqhwBHKVJpDjlfufe();
			elementMap._actionId = actionId;
			elementMap._elementType = ControllerElementType.Button;
			elementMap._axisContribution = axisContribution;
			elementMap._keyboardKeyCode = (KeyboardKeyCode)keyCode;
			elementMap._modifierKey1 = modifierKey1;
			elementMap._modifierKey2 = modifierKey2;
			elementMap._modifierKey3 = modifierKey3;
			ReInput.controllers.Keyboard.IginakiartMCXcNztgFGkBgBmEe(this, elementMap);
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
			dNIkkpHmbenRXMbwvhZsDaEKwGD dNIkkpHmbenRXMbwvhZsDaEKwGD2 = dNIkkpHmbenRXMbwvhZsDaEKwGD.NyBUUOCvTkHIxpgoRNwhNoOJOKx(modifierKeyFlags);
			return ReplaceElementMap(elementMapId, actionId, axisContribution, keyCode, dNIkkpHmbenRXMbwvhZsDaEKwGD2.dzVdjlEVQwgzvzhVUKnnyxEfDccq, dNIkkpHmbenRXMbwvhZsDaEKwGD2.QevfNgMhRGjlsMgBpjDuDOAeljTh, dNIkkpHmbenRXMbwvhZsDaEKwGD2.yKFGycBpxalffjUWjPHPvRPQTWmG, out result);
		}

		public bool ReplaceElementMap(int elementMapId, int actionId, Pole axisContribution, int elementIdentifierId, ControllerElementType elementType, AxisRange axisRange, bool invert)
		{
			ActionElementMap result;
			return ReplaceElementMap(elementMapId, actionId, axisContribution, elementIdentifierId, elementType, axisRange, invert, out result);
		}

		public virtual bool ReplaceElementMap(int elementMapId, int actionId, Pole axisContribution, int elementIdentifierId, ControllerElementType elementType, AxisRange axisRange, bool invert, out ActionElementMap result)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				result = null;
				return false;
			}
			if (!bbEggoxgYPAkARDGnCkXZJCiEYGa(elementType))
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
			if (!bbEggoxgYPAkARDGnCkXZJCiEYGa(elementMap._elementType))
			{
				DeleteElementMap(elementMapId);
				elementMap._elementType = ControllerElementType.Button;
				DsowFbtcOyiDrdyfjcycNGirkoAa(elementMap);
			}
			int num = kMXCVlsFwJKKRzfwDXYvOGCsgtD(elementMapId);
			if (num < 0)
			{
				result = null;
				return false;
			}
			PnTxkUsNLsMLtRkowVxXNqXtKTz(elementMap, actionId, axisContribution, elementIdentifierId, elementType, axisRange, invert);
			BakeElementMap(elementMap);
			result = elementMap;
			return true;
		}

		public virtual bool DeleteElementMap(int elementMapId)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			int num = kMXCVlsFwJKKRzfwDXYvOGCsgtD(elementMapId);
			if (num < 0)
			{
				return false;
			}
			gjWevMAzYuoXipDOwMQpQWDxGssT(elementMapId, num);
			return true;
		}

		public virtual bool DeleteElementMapsWithAction(string actionName)
		{
			return DeleteElementMapsWithAction(ReInput.XVroGTnTmiTwGITDVAhlDMsuaLiG.eaEBFTCPQPNmMfDIsPQAWgiCaLm(actionName));
		}

		public virtual bool DeleteElementMapsWithAction(int actionId)
		{
			return DeleteButtonMapsWithAction(actionId);
		}

		public virtual ActionElementMap GetElementMap(int elementMapId)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return null;
			}
			if (elementMapId < 0)
			{
				return null;
			}
			int num = buttonMapCount;
			for (int i = 0; i < num; i++)
			{
				if (YkTTJefdVTAYyECYQpCbYHQOWGx[i].JYRMuwETpVNRqJXmtBgBFhZdTeP == elementMapId)
				{
					return YkTTJefdVTAYyECYQpCbYHQOWGx[i];
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
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
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
				if (!skipDisabledMaps || allMap.fnEBjitvkHhPtXTzRLmBYpIxFbt)
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
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return 0;
			}
			if (results == null)
			{
				throw new ArgumentNullException("results");
			}
			results.Clear();
			return VPLwlUlbVJcGxInkzAvGWInfZls(results, skipDisabledMaps);
		}

		public ActionElementMap[] GetElementMapsWithAction(string actionName)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return EmptyObjects<ActionElementMap>.array;
			}
			int actionId = ReInput.XVroGTnTmiTwGITDVAhlDMsuaLiG.eaEBFTCPQPNmMfDIsPQAWgiCaLm(actionName);
			return GetElementMapsWithAction(actionId);
		}

		public ActionElementMap[] GetElementMapsWithAction(int actionId)
		{
			return GetElementMapsWithAction(actionId, skipDisabledMaps: false);
		}

		public ActionElementMap[] GetElementMapsWithAction(string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return EmptyObjects<ActionElementMap>.array;
			}
			int actionId = ReInput.XVroGTnTmiTwGITDVAhlDMsuaLiG.eaEBFTCPQPNmMfDIsPQAWgiCaLm(actionName);
			return GetElementMapsWithAction(actionId, skipDisabledMaps);
		}

		public ActionElementMap[] GetElementMapsWithAction(int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
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
				if (allMap._actionId == actionId && (!skipDisabledMaps || allMap.fnEBjitvkHhPtXTzRLmBYpIxFbt))
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
				if (allMap2._actionId == actionId && (!skipDisabledMaps || allMap2.fnEBjitvkHhPtXTzRLmBYpIxFbt))
				{
					array[num2] = allMap2;
					num2++;
				}
			}
			return array;
		}

		public int GetElementMapsWithAction(string actionName, List<ActionElementMap> results)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return 0;
			}
			int actionId = ReInput.XVroGTnTmiTwGITDVAhlDMsuaLiG.eaEBFTCPQPNmMfDIsPQAWgiCaLm(actionName);
			return GetElementMapsWithAction(actionId, results);
		}

		public int GetElementMapsWithAction(int actionId, List<ActionElementMap> results)
		{
			return GetElementMapsWithAction(actionId, skipDisabledMaps: false, results);
		}

		public int GetElementMapsWithAction(string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return 0;
			}
			int actionId = ReInput.XVroGTnTmiTwGITDVAhlDMsuaLiG.eaEBFTCPQPNmMfDIsPQAWgiCaLm(actionName);
			return GetElementMapsWithAction(actionId, skipDisabledMaps, results);
		}

		public int GetElementMapsWithAction(int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			return paPqgnqavLYCqgponTssufOHcpc(actionId, skipDisabledMaps, results, false);
		}

		public IEnumerable<ActionElementMap> ElementMapsWithAction(string actionName)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			int actionId = ReInput.XVroGTnTmiTwGITDVAhlDMsuaLiG.eaEBFTCPQPNmMfDIsPQAWgiCaLm(actionName);
			return ElementMapsWithAction(actionId);
		}

		public IEnumerable<ActionElementMap> ElementMapsWithAction(int actionId)
		{
			return ElementMapsWithAction(actionId, skipDisabledMaps: false);
		}

		public IEnumerable<ActionElementMap> ElementMapsWithAction(string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			int actionId = ReInput.XVroGTnTmiTwGITDVAhlDMsuaLiG.eaEBFTCPQPNmMfDIsPQAWgiCaLm(actionName);
			return ElementMapsWithAction(actionId, skipDisabledMaps);
		}

		public IEnumerable<ActionElementMap> ElementMapsWithAction(int actionId, bool skipDisabledMaps)
		{
			NetMLoMnSlwOuClzkcybOaNnjEdh netMLoMnSlwOuClzkcybOaNnjEdh = new NetMLoMnSlwOuClzkcybOaNnjEdh(-2);
			netMLoMnSlwOuClzkcybOaNnjEdh.GxphHAMqMhNBLjnlhXuBQmXaALiE = this;
			netMLoMnSlwOuClzkcybOaNnjEdh.gmlZVSBTtPIWuYPylEQcoNUGUio = actionId;
			netMLoMnSlwOuClzkcybOaNnjEdh.TGDalxAGxtEWicADkzmraNyMfPny = skipDisabledMaps;
			return netMLoMnSlwOuClzkcybOaNnjEdh;
		}

		public virtual ActionElementMap GetFirstElementMapWithAction(int actionId)
		{
			return GetFirstElementMapWithAction(actionId, skipDisabledMaps: false);
		}

		public virtual ActionElementMap GetFirstElementMapWithAction(string actionName)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return null;
			}
			int actionId = ReInput.XVroGTnTmiTwGITDVAhlDMsuaLiG.eaEBFTCPQPNmMfDIsPQAWgiCaLm(actionName);
			return GetFirstElementMapWithAction(actionId);
		}

		public virtual ActionElementMap GetFirstElementMapWithAction(int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return null;
			}
			if (actionId < 0)
			{
				return null;
			}
			int num = buttonMapCount;
			for (int i = 0; i < num; i++)
			{
				if (YkTTJefdVTAYyECYQpCbYHQOWGx[i]._actionId == actionId && (!skipDisabledMaps || YkTTJefdVTAYyECYQpCbYHQOWGx[i].fnEBjitvkHhPtXTzRLmBYpIxFbt))
				{
					return YkTTJefdVTAYyECYQpCbYHQOWGx[i];
				}
			}
			return null;
		}

		public ActionElementMap GetFirstElementMapWithAction(string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return null;
			}
			int actionId = ReInput.XVroGTnTmiTwGITDVAhlDMsuaLiG.eaEBFTCPQPNmMfDIsPQAWgiCaLm(actionName);
			return GetFirstElementMapWithAction(actionId, skipDisabledMaps);
		}

		public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(ControllerElementTarget elementTarget, bool skipDisabledMaps)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			rRNhjRpfbeHXdDjgkCEeGsrflVcU rRNhjRpfbeHXdDjgkCEeGsrflVcU2 = rRNhjRpfbeHXdDjgkCEeGsrflVcU.MyFdjCFHrgeFWbyjPuCXTirWPhx(elementTarget);
			IEnumerable<ActionElementMap> result = ElementMapsWithElementTarget(rRNhjRpfbeHXdDjgkCEeGsrflVcU2, skipDisabledMaps);
			rRNhjRpfbeHXdDjgkCEeGsrflVcU.PwDnEpwWkKKCZSBeZgjNATJwzAK(rRNhjRpfbeHXdDjgkCEeGsrflVcU2);
			return result;
		}

		public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(IControllerElementTarget elementTarget, bool skipDisabledMaps)
		{
			HITDgpgebzfDlvRHRsvlZUKhvUU hITDgpgebzfDlvRHRsvlZUKhvUU = new HITDgpgebzfDlvRHRsvlZUKhvUU(-2);
			hITDgpgebzfDlvRHRsvlZUKhvUU.GxphHAMqMhNBLjnlhXuBQmXaALiE = this;
			hITDgpgebzfDlvRHRsvlZUKhvUU.JpiXZhoXgCfPNJtJyBDKpaqTCLOI = elementTarget;
			hITDgpgebzfDlvRHRsvlZUKhvUU.TGDalxAGxtEWicADkzmraNyMfPny = skipDisabledMaps;
			return hITDgpgebzfDlvRHRsvlZUKhvUU;
		}

		public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(ControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			rRNhjRpfbeHXdDjgkCEeGsrflVcU rRNhjRpfbeHXdDjgkCEeGsrflVcU2 = rRNhjRpfbeHXdDjgkCEeGsrflVcU.MyFdjCFHrgeFWbyjPuCXTirWPhx(elementTarget);
			IEnumerable<ActionElementMap> result = ElementMapsWithElementTarget(rRNhjRpfbeHXdDjgkCEeGsrflVcU2, actionId, skipDisabledMaps);
			rRNhjRpfbeHXdDjgkCEeGsrflVcU.PwDnEpwWkKKCZSBeZgjNATJwzAK(rRNhjRpfbeHXdDjgkCEeGsrflVcU2);
			return result;
		}

		public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(ControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			int actionId = ReInput.XVroGTnTmiTwGITDVAhlDMsuaLiG.eaEBFTCPQPNmMfDIsPQAWgiCaLm(actionName);
			return ElementMapsWithElementTarget(elementTarget, actionId, skipDisabledMaps);
		}

		public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(IControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps)
		{
			HGorjtFuunRZHUlEjWkzzCNVePY hGorjtFuunRZHUlEjWkzzCNVePY = new HGorjtFuunRZHUlEjWkzzCNVePY(-2);
			hGorjtFuunRZHUlEjWkzzCNVePY.GxphHAMqMhNBLjnlhXuBQmXaALiE = this;
			hGorjtFuunRZHUlEjWkzzCNVePY.JpiXZhoXgCfPNJtJyBDKpaqTCLOI = elementTarget;
			hGorjtFuunRZHUlEjWkzzCNVePY.gmlZVSBTtPIWuYPylEQcoNUGUio = actionId;
			hGorjtFuunRZHUlEjWkzzCNVePY.TGDalxAGxtEWicADkzmraNyMfPny = skipDisabledMaps;
			return hGorjtFuunRZHUlEjWkzzCNVePY;
		}

		public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(IControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			int actionId = ReInput.XVroGTnTmiTwGITDVAhlDMsuaLiG.eaEBFTCPQPNmMfDIsPQAWgiCaLm(actionName);
			return ElementMapsWithElementTarget(elementTarget, actionId, skipDisabledMaps);
		}

		public ActionElementMap GetFirstElementMapWithElementTarget(ControllerElementTarget elementTarget, bool skipDisabledMaps)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return null;
			}
			rRNhjRpfbeHXdDjgkCEeGsrflVcU rRNhjRpfbeHXdDjgkCEeGsrflVcU2 = rRNhjRpfbeHXdDjgkCEeGsrflVcU.MyFdjCFHrgeFWbyjPuCXTirWPhx(elementTarget);
			ActionElementMap firstElementMapWithElementTarget = GetFirstElementMapWithElementTarget(rRNhjRpfbeHXdDjgkCEeGsrflVcU2, skipDisabledMaps);
			rRNhjRpfbeHXdDjgkCEeGsrflVcU.PwDnEpwWkKKCZSBeZgjNATJwzAK(rRNhjRpfbeHXdDjgkCEeGsrflVcU2);
			return firstElementMapWithElementTarget;
		}

		public ActionElementMap GetFirstElementMapWithElementTarget(IControllerElementTarget elementTarget, bool skipDisabledMaps)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return null;
			}
			bool flag;
			return TythgSbwYmNijsQNDAZZfufNFdk(elementTarget, false, -1, skipDisabledMaps, out flag);
		}

		public ActionElementMap GetFirstElementMapWithElementTarget(ControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return null;
			}
			rRNhjRpfbeHXdDjgkCEeGsrflVcU rRNhjRpfbeHXdDjgkCEeGsrflVcU2 = rRNhjRpfbeHXdDjgkCEeGsrflVcU.MyFdjCFHrgeFWbyjPuCXTirWPhx(elementTarget);
			ActionElementMap firstElementMapWithElementTarget = GetFirstElementMapWithElementTarget(rRNhjRpfbeHXdDjgkCEeGsrflVcU2, actionId, skipDisabledMaps);
			rRNhjRpfbeHXdDjgkCEeGsrflVcU.PwDnEpwWkKKCZSBeZgjNATJwzAK(rRNhjRpfbeHXdDjgkCEeGsrflVcU2);
			return firstElementMapWithElementTarget;
		}

		public ActionElementMap GetFirstElementMapWithElementTarget(ControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return null;
			}
			int actionId = ReInput.XVroGTnTmiTwGITDVAhlDMsuaLiG.eaEBFTCPQPNmMfDIsPQAWgiCaLm(actionName);
			return GetFirstElementMapWithElementTarget(elementTarget, actionId, skipDisabledMaps);
		}

		public ActionElementMap GetFirstElementMapWithElementTarget(IControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return null;
			}
			bool flag;
			return TythgSbwYmNijsQNDAZZfufNFdk(elementTarget, true, actionId, skipDisabledMaps, out flag);
		}

		public ActionElementMap GetFirstElementMapWithElementTarget(IControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return null;
			}
			int actionId = ReInput.XVroGTnTmiTwGITDVAhlDMsuaLiG.eaEBFTCPQPNmMfDIsPQAWgiCaLm(actionName);
			return GetFirstElementMapWithElementTarget(elementTarget, actionId, skipDisabledMaps);
		}

		public int GetElementMapsWithElementTarget(ControllerElementTarget elementTarget, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return 0;
			}
			rRNhjRpfbeHXdDjgkCEeGsrflVcU rRNhjRpfbeHXdDjgkCEeGsrflVcU2 = rRNhjRpfbeHXdDjgkCEeGsrflVcU.MyFdjCFHrgeFWbyjPuCXTirWPhx(elementTarget);
			int elementMapsWithElementTarget = GetElementMapsWithElementTarget(rRNhjRpfbeHXdDjgkCEeGsrflVcU2, skipDisabledMaps, results);
			rRNhjRpfbeHXdDjgkCEeGsrflVcU.PwDnEpwWkKKCZSBeZgjNATJwzAK(rRNhjRpfbeHXdDjgkCEeGsrflVcU2);
			return elementMapsWithElementTarget;
		}

		public int GetElementMapsWithElementTarget(IControllerElementTarget elementTarget, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return 0;
			}
			bool flag;
			return VOIVoTgEPzUDZzgXkQydAIFJfLn(elementTarget, false, -1, skipDisabledMaps, results, false, out flag);
		}

		public int GetElementMapsWithElementTarget(ControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return 0;
			}
			rRNhjRpfbeHXdDjgkCEeGsrflVcU rRNhjRpfbeHXdDjgkCEeGsrflVcU2 = rRNhjRpfbeHXdDjgkCEeGsrflVcU.MyFdjCFHrgeFWbyjPuCXTirWPhx(elementTarget);
			int elementMapsWithElementTarget = GetElementMapsWithElementTarget(rRNhjRpfbeHXdDjgkCEeGsrflVcU2, actionId, skipDisabledMaps, results);
			rRNhjRpfbeHXdDjgkCEeGsrflVcU.PwDnEpwWkKKCZSBeZgjNATJwzAK(rRNhjRpfbeHXdDjgkCEeGsrflVcU2);
			return elementMapsWithElementTarget;
		}

		public int GetElementMapsWithElementTarget(ControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return 0;
			}
			int actionId = ReInput.XVroGTnTmiTwGITDVAhlDMsuaLiG.eaEBFTCPQPNmMfDIsPQAWgiCaLm(actionName);
			return GetElementMapsWithElementTarget(elementTarget, actionId, skipDisabledMaps, results);
		}

		public int GetElementMapsWithElementTarget(IControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return 0;
			}
			bool flag;
			return VOIVoTgEPzUDZzgXkQydAIFJfLn(elementTarget, true, actionId, skipDisabledMaps, results, false, out flag);
		}

		public int GetElementMapsWithElementTarget(IControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return 0;
			}
			int actionId = ReInput.XVroGTnTmiTwGITDVAhlDMsuaLiG.eaEBFTCPQPNmMfDIsPQAWgiCaLm(actionName);
			return GetElementMapsWithElementTarget(elementTarget, actionId, skipDisabledMaps, results);
		}

		public ActionElementMap GetFirstElementMapMatch(Predicate<ActionElementMap> predicate)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return null;
			}
			return LbHFzRhtKzMoxHHeraoJEMXHiGoC(predicate, false);
		}

		internal virtual ActionElementMap LbHFzRhtKzMoxHHeraoJEMXHiGoC(Predicate<ActionElementMap> P_0, bool P_1)
		{
			return SIFXSbWEJqAgzfJqzfkXKNekSBQq(P_0, P_1);
		}

		public int GetElementMapMatches(Predicate<ActionElementMap> predicate, List<ActionElementMap> results)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return 0;
			}
			return tMcZjSpjAIyKwgdHGinagsvLTzE(predicate, false, results, false);
		}

		internal virtual int tMcZjSpjAIyKwgdHGinagsvLTzE(Predicate<ActionElementMap> P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			return wsnaJfnNDmhaLksiZPDHMOviGQK(P_0, P_1, P_2, P_3);
		}

		public void ForEachElementMapMatch(Predicate<ActionElementMap> predicate, Action<ActionElementMap> actionToPerform)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
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
			int count = bAHtrfdakdbHbbbKUCDCgljGflpo.Count;
			try
			{
				for (int i = 0; i < count; i++)
				{
					ActionElementMap obj = bAHtrfdakdbHbbbKUCDCgljGflpo[i];
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
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return;
			}
			YkTTJefdVTAYyECYQpCbYHQOWGx.Clear();
			bAHtrfdakdbHbbbKUCDCgljGflpo.Clear();
		}

		public int SetAllElementMapsEnabled(bool state)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return 0;
			}
			int num = 0;
			int count = bAHtrfdakdbHbbbKUCDCgljGflpo.Count;
			for (int i = 0; i < count; i++)
			{
				ActionElementMap actionElementMap = bAHtrfdakdbHbbbKUCDCgljGflpo[i];
				if (actionElementMap.fnEBjitvkHhPtXTzRLmBYpIxFbt != state)
				{
					actionElementMap.fnEBjitvkHhPtXTzRLmBYpIxFbt = state;
					num++;
				}
			}
			return num;
		}

		public ActionElementMap GetButtonMap(int index)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return null;
			}
			if (YkTTJefdVTAYyECYQpCbYHQOWGx == null || index < 0 || index >= YkTTJefdVTAYyECYQpCbYHQOWGx.Count)
			{
				return null;
			}
			return YkTTJefdVTAYyECYQpCbYHQOWGx[index];
		}

		public ActionElementMap[] GetButtonMaps()
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return EmptyObjects<ActionElementMap>.array;
			}
			return ListTools.ToArray(YkTTJefdVTAYyECYQpCbYHQOWGx);
		}

		public ActionElementMap[] GetButtonMaps(bool skipDisabledMaps)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return EmptyObjects<ActionElementMap>.array;
			}
			int count = YkTTJefdVTAYyECYQpCbYHQOWGx.Count;
			List<ActionElementMap> list = new List<ActionElementMap>(count);
			for (int i = 0; i < count; i++)
			{
				ActionElementMap actionElementMap = YkTTJefdVTAYyECYQpCbYHQOWGx[i];
				if (!skipDisabledMaps || actionElementMap.fnEBjitvkHhPtXTzRLmBYpIxFbt)
				{
					list.Add(actionElementMap);
				}
			}
			return list.ToArray();
		}

		public int GetButtonMaps(bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return 0;
			}
			return MtFmSJLBtNGupVOURySmmQfDDld(skipDisabledMaps, results, false);
		}

		public ActionElementMap[] GetButtonMapsWithAction(string actionName)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return EmptyObjects<ActionElementMap>.array;
			}
			InputAction inputAction = ReInput.XVroGTnTmiTwGITDVAhlDMsuaLiG.foeDsFJMSKPZnHiDHArgvpAmVTU(actionName, true);
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
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return EmptyObjects<ActionElementMap>.array;
			}
			InputAction inputAction = ReInput.XVroGTnTmiTwGITDVAhlDMsuaLiG.foeDsFJMSKPZnHiDHArgvpAmVTU(actionName, true);
			if (inputAction == null)
			{
				return EmptyObjects<ActionElementMap>.array;
			}
			return GetButtonMapsWithAction(inputAction.id, skipDisabledMaps);
		}

		public ActionElementMap[] GetButtonMapsWithAction(int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
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
				ActionElementMap actionElementMap = YkTTJefdVTAYyECYQpCbYHQOWGx[i];
				if (actionElementMap._actionId == actionId && (!skipDisabledMaps || actionElementMap.fnEBjitvkHhPtXTzRLmBYpIxFbt))
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
				ActionElementMap actionElementMap2 = YkTTJefdVTAYyECYQpCbYHQOWGx[j];
				if (actionElementMap2._actionId == actionId && (!skipDisabledMaps || actionElementMap2.fnEBjitvkHhPtXTzRLmBYpIxFbt))
				{
					array[num3] = actionElementMap2;
					num3++;
				}
			}
			return array;
		}

		public int GetButtonMapsWithAction(string actionName, List<ActionElementMap> results)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return 0;
			}
			InputAction inputAction = ReInput.XVroGTnTmiTwGITDVAhlDMsuaLiG.foeDsFJMSKPZnHiDHArgvpAmVTU(actionName, true);
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
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return 0;
			}
			InputAction inputAction = ReInput.XVroGTnTmiTwGITDVAhlDMsuaLiG.foeDsFJMSKPZnHiDHArgvpAmVTU(actionName, true);
			if (inputAction == null)
			{
				ListTools.TryClear(results);
				return 0;
			}
			return GetButtonMapsWithAction(inputAction.id, skipDisabledMaps, results);
		}

		public int GetButtonMapsWithAction(int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return 0;
			}
			return EwxUCWIjgNvgwPkYWOoxwAiADEI(actionId, skipDisabledMaps, results, false);
		}

		public IEnumerable<ActionElementMap> ButtonMapsWithAction(int actionId)
		{
			return ButtonMapsWithAction(actionId, skipDisabledMaps: false);
		}

		public IEnumerable<ActionElementMap> ButtonMapsWithAction(string actionName)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			int actionId = ReInput.XVroGTnTmiTwGITDVAhlDMsuaLiG.eaEBFTCPQPNmMfDIsPQAWgiCaLm(actionName);
			return ButtonMapsWithAction(actionId);
		}

		public IEnumerable<ActionElementMap> ButtonMapsWithAction(int actionId, bool skipDisabledMaps)
		{
			FCeXouPBLBfiMcrLbcHFKnNxaIF fCeXouPBLBfiMcrLbcHFKnNxaIF = new FCeXouPBLBfiMcrLbcHFKnNxaIF(-2);
			fCeXouPBLBfiMcrLbcHFKnNxaIF.GxphHAMqMhNBLjnlhXuBQmXaALiE = this;
			fCeXouPBLBfiMcrLbcHFKnNxaIF.gmlZVSBTtPIWuYPylEQcoNUGUio = actionId;
			fCeXouPBLBfiMcrLbcHFKnNxaIF.TGDalxAGxtEWicADkzmraNyMfPny = skipDisabledMaps;
			return fCeXouPBLBfiMcrLbcHFKnNxaIF;
		}

		public IEnumerable<ActionElementMap> ButtonMapsWithAction(string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			int actionId = ReInput.XVroGTnTmiTwGITDVAhlDMsuaLiG.eaEBFTCPQPNmMfDIsPQAWgiCaLm(actionName);
			return ButtonMapsWithAction(actionId, skipDisabledMaps);
		}

		public ActionElementMap GetFirstButtonMapWithAction(int actionId)
		{
			return GetFirstButtonMapWithAction(actionId, skipDisabledMaps: false);
		}

		public ActionElementMap GetFirstButtonMapWithAction(string actionName)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return null;
			}
			int actionId = ReInput.XVroGTnTmiTwGITDVAhlDMsuaLiG.eaEBFTCPQPNmMfDIsPQAWgiCaLm(actionName);
			return GetFirstButtonMapWithAction(actionId);
		}

		public ActionElementMap GetFirstButtonMapWithAction(int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
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
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return null;
			}
			int actionId = ReInput.XVroGTnTmiTwGITDVAhlDMsuaLiG.eaEBFTCPQPNmMfDIsPQAWgiCaLm(actionName);
			return GetFirstButtonMapWithAction(actionId, skipDisabledMaps);
		}

		public ActionElementMap GetFirstButtonMapMatch(Predicate<ActionElementMap> predicate)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return null;
			}
			return SIFXSbWEJqAgzfJqzfkXKNekSBQq(predicate, false);
		}

		internal ActionElementMap SIFXSbWEJqAgzfJqzfkXKNekSBQq(Predicate<ActionElementMap> P_0, bool P_1)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
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
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return 0;
			}
			return wsnaJfnNDmhaLksiZPDHMOviGQK(predicate, false, results, false);
		}

		internal int wsnaJfnNDmhaLksiZPDHMOviGQK(Predicate<ActionElementMap> P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
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
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
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
			int count = YkTTJefdVTAYyECYQpCbYHQOWGx.Count;
			try
			{
				for (int i = 0; i < count; i++)
				{
					ActionElementMap obj = YkTTJefdVTAYyECYQpCbYHQOWGx[i];
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
			return DeleteButtonMapsWithAction(ReInput.XVroGTnTmiTwGITDVAhlDMsuaLiG.eaEBFTCPQPNmMfDIsPQAWgiCaLm(actionName));
		}

		public bool DeleteButtonMapsWithAction(int actionId)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
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
				ActionElementMap actionElementMap = YkTTJefdVTAYyECYQpCbYHQOWGx[num2];
				if (actionElementMap != null && actionElementMap._actionId == actionId)
				{
					gjWevMAzYuoXipDOwMQpQWDxGssT(actionElementMap.JYRMuwETpVNRqJXmtBgBFhZdTeP, num2);
					result = true;
				}
			}
			return result;
		}

		public int SetAllButtonMapsEnabled(bool state)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return 0;
			}
			int num = 0;
			int count = YkTTJefdVTAYyECYQpCbYHQOWGx.Count;
			for (int i = 0; i < count; i++)
			{
				ActionElementMap actionElementMap = YkTTJefdVTAYyECYQpCbYHQOWGx[i];
				if (actionElementMap.fnEBjitvkHhPtXTzRLmBYpIxFbt != state)
				{
					actionElementMap.fnEBjitvkHhPtXTzRLmBYpIxFbt = state;
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
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
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
			if (YkTTJefdVTAYyECYQpCbYHQOWGx == null)
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
				ActionElementMap actionElementMap = YkTTJefdVTAYyECYQpCbYHQOWGx[i];
				if (skipDisabledMaps && !actionElementMap.fnEBjitvkHhPtXTzRLmBYpIxFbt)
				{
					continue;
				}
				for (int j = 0; j < count; j++)
				{
					ActionElementMap actionElementMap2 = buttonMaps[j];
					if ((!skipDisabledMaps || actionElementMap2.fnEBjitvkHhPtXTzRLmBYpIxFbt) && actionElementMap != actionElementMap2 && actionElementMap.CheckForAssignmentConflict(actionElementMap2))
					{
						return true;
					}
				}
			}
			return false;
		}

		public virtual bool DoesElementAssignmentConflict(ActionElementMap actionElementMap, bool skipDisabledMaps)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			if (actionElementMap == null || YkTTJefdVTAYyECYQpCbYHQOWGx == null)
			{
				return false;
			}
			if (skipDisabledMaps && (!_enabled || !actionElementMap.fnEBjitvkHhPtXTzRLmBYpIxFbt))
			{
				return false;
			}
			for (int i = 0; i < YkTTJefdVTAYyECYQpCbYHQOWGx.Count; i++)
			{
				ActionElementMap actionElementMap2 = YkTTJefdVTAYyECYQpCbYHQOWGx[i];
				if ((!skipDisabledMaps || actionElementMap2.fnEBjitvkHhPtXTzRLmBYpIxFbt) && actionElementMap2 != actionElementMap && actionElementMap2.CheckForAssignmentConflict(actionElementMap))
				{
					return true;
				}
			}
			return false;
		}

		public virtual bool DoesElementAssignmentConflict(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return false;
			}
			if (YkTTJefdVTAYyECYQpCbYHQOWGx == null)
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
			for (int i = 0; i < YkTTJefdVTAYyECYQpCbYHQOWGx.Count; i++)
			{
				ActionElementMap actionElementMap = YkTTJefdVTAYyECYQpCbYHQOWGx[i];
				if ((!skipDisabledMaps || actionElementMap.fnEBjitvkHhPtXTzRLmBYpIxFbt) && actionElementMap.JYRMuwETpVNRqJXmtBgBFhZdTeP != conflictCheck.elementMapId && actionElementMap.CheckForAssignmentConflict(elementAssignment))
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

		public virtual IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ControllerMap controllerMap, bool skipDisabledMaps)
		{
			xDpgBiETmjXajxLNJHOifbfCfKjl xDpgBiETmjXajxLNJHOifbfCfKjl2 = new xDpgBiETmjXajxLNJHOifbfCfKjl(-2);
			xDpgBiETmjXajxLNJHOifbfCfKjl2.GxphHAMqMhNBLjnlhXuBQmXaALiE = this;
			xDpgBiETmjXajxLNJHOifbfCfKjl2.sNhfYAVoaqivqYEVUlVeZtnUREN = controllerMap;
			xDpgBiETmjXajxLNJHOifbfCfKjl2.TGDalxAGxtEWicADkzmraNyMfPny = skipDisabledMaps;
			return xDpgBiETmjXajxLNJHOifbfCfKjl2;
		}

		public virtual IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ActionElementMap actionElementMap, bool skipDisabledMaps)
		{
			MwvNNOMOtZMVYArBfWDZWGBucnGC mwvNNOMOtZMVYArBfWDZWGBucnGC = new MwvNNOMOtZMVYArBfWDZWGBucnGC(-2);
			mwvNNOMOtZMVYArBfWDZWGBucnGC.GxphHAMqMhNBLjnlhXuBQmXaALiE = this;
			mwvNNOMOtZMVYArBfWDZWGBucnGC.mHXCJMfdawKqIiVysYybBSiVrhGm = actionElementMap;
			mwvNNOMOtZMVYArBfWDZWGBucnGC.TGDalxAGxtEWicADkzmraNyMfPny = skipDisabledMaps;
			return mwvNNOMOtZMVYArBfWDZWGBucnGC;
		}

		public virtual IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
		{
			LEnGbFiDtcwRrWpWhQUfVLTRjxf lEnGbFiDtcwRrWpWhQUfVLTRjxf = new LEnGbFiDtcwRrWpWhQUfVLTRjxf(-2);
			lEnGbFiDtcwRrWpWhQUfVLTRjxf.GxphHAMqMhNBLjnlhXuBQmXaALiE = this;
			lEnGbFiDtcwRrWpWhQUfVLTRjxf.VliyeXpMEMSvNHleVqLftHsOCYq = conflictCheck;
			lEnGbFiDtcwRrWpWhQUfVLTRjxf.TGDalxAGxtEWicADkzmraNyMfPny = skipDisabledMaps;
			return lEnGbFiDtcwRrWpWhQUfVLTRjxf;
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
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
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
			if (YkTTJefdVTAYyECYQpCbYHQOWGx == null)
			{
				return num;
			}
			IList<ActionElementMap> ykTTJefdVTAYyECYQpCbYHQOWGx = controllerMap.YkTTJefdVTAYyECYQpCbYHQOWGx;
			if (ykTTJefdVTAYyECYQpCbYHQOWGx == null)
			{
				return num;
			}
			InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(_categoryId);
			if (mapCategory != null && !mapCategory.userAssignable)
			{
				return num;
			}
			_ = buttonMapCount;
			int count = ykTTJefdVTAYyECYQpCbYHQOWGx.Count;
			for (int num2 = YkTTJefdVTAYyECYQpCbYHQOWGx.Count - 1; num2 >= 0; num2--)
			{
				ActionElementMap actionElementMap = YkTTJefdVTAYyECYQpCbYHQOWGx[num2];
				if (!skipDisabledMaps || actionElementMap.fnEBjitvkHhPtXTzRLmBYpIxFbt)
				{
					for (int i = 0; i < count; i++)
					{
						if ((!skipDisabledMaps || ykTTJefdVTAYyECYQpCbYHQOWGx[i].fnEBjitvkHhPtXTzRLmBYpIxFbt) && actionElementMap.CheckForAssignmentConflict(ykTTJefdVTAYyECYQpCbYHQOWGx[i]))
						{
							gjWevMAzYuoXipDOwMQpQWDxGssT(actionElementMap.JYRMuwETpVNRqJXmtBgBFhZdTeP, num2);
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
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return 0;
			}
			if (actionElementMap == null)
			{
				return 0;
			}
			if (skipDisabledMaps && (!_enabled || !actionElementMap.fnEBjitvkHhPtXTzRLmBYpIxFbt))
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
			if (YkTTJefdVTAYyECYQpCbYHQOWGx == null)
			{
				return num;
			}
			for (int num2 = YkTTJefdVTAYyECYQpCbYHQOWGx.Count - 1; num2 >= 0; num2--)
			{
				ActionElementMap actionElementMap2 = YkTTJefdVTAYyECYQpCbYHQOWGx[num2];
				if ((!skipDisabledMaps || actionElementMap2.fnEBjitvkHhPtXTzRLmBYpIxFbt) && actionElementMap2.CheckForAssignmentConflict(actionElementMap))
				{
					gjWevMAzYuoXipDOwMQpQWDxGssT(actionElementMap2.JYRMuwETpVNRqJXmtBgBFhZdTeP, num2);
					num++;
				}
			}
			return num;
		}

		public virtual int RemoveElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return 0;
			}
			if (skipDisabledMaps && !_enabled)
			{
				return 0;
			}
			if (YkTTJefdVTAYyECYQpCbYHQOWGx == null)
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
			for (int num2 = YkTTJefdVTAYyECYQpCbYHQOWGx.Count - 1; num2 >= 0; num2--)
			{
				ActionElementMap actionElementMap = YkTTJefdVTAYyECYQpCbYHQOWGx[num2];
				if ((!skipDisabledMaps || actionElementMap.fnEBjitvkHhPtXTzRLmBYpIxFbt) && actionElementMap.JYRMuwETpVNRqJXmtBgBFhZdTeP != conflictCheck.elementMapId && actionElementMap.CheckForAssignmentConflict(elementAssignment))
				{
					gjWevMAzYuoXipDOwMQpQWDxGssT(actionElementMap.JYRMuwETpVNRqJXmtBgBFhZdTeP, num2);
					num++;
				}
			}
			return num;
		}

		public int DisableElementAssignmentConflicts(ControllerMap controllerMap)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return 0;
			}
			return uYwxIBEwgxONcHwzfXTGnIioFcq(controllerMap, false, null, false);
		}

		public int DisableElementAssignmentConflicts(ActionElementMap actionElementMap)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return 0;
			}
			return uYwxIBEwgxONcHwzfXTGnIioFcq(actionElementMap, false, null, false);
		}

		public int DisableElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return 0;
			}
			return uYwxIBEwgxONcHwzfXTGnIioFcq(conflictCheck, false, null, false);
		}

		public int DisableElementAssignmentConflicts(ControllerMap controllerMap, bool skipDisabledMaps)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return 0;
			}
			return uYwxIBEwgxONcHwzfXTGnIioFcq(controllerMap, skipDisabledMaps, null, false);
		}

		public int DisableElementAssignmentConflicts(ActionElementMap actionElementMap, bool skipDisabledMaps)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return 0;
			}
			return uYwxIBEwgxONcHwzfXTGnIioFcq(actionElementMap, skipDisabledMaps, null, false);
		}

		public int DisableElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return 0;
			}
			return uYwxIBEwgxONcHwzfXTGnIioFcq(conflictCheck, skipDisabledMaps, null, false);
		}

		internal virtual int uYwxIBEwgxONcHwzfXTGnIioFcq(ControllerMap P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
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
			if (YkTTJefdVTAYyECYQpCbYHQOWGx == null)
			{
				return num;
			}
			IList<ActionElementMap> ykTTJefdVTAYyECYQpCbYHQOWGx = P_0.YkTTJefdVTAYyECYQpCbYHQOWGx;
			if (ykTTJefdVTAYyECYQpCbYHQOWGx == null)
			{
				return num;
			}
			InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(_categoryId);
			if (mapCategory != null && !mapCategory.userAssignable)
			{
				return num;
			}
			int num2 = buttonMapCount;
			int count = ykTTJefdVTAYyECYQpCbYHQOWGx.Count;
			for (int i = 0; i < num2; i++)
			{
				ActionElementMap actionElementMap = YkTTJefdVTAYyECYQpCbYHQOWGx[i];
				if (!actionElementMap.fnEBjitvkHhPtXTzRLmBYpIxFbt)
				{
					continue;
				}
				for (int j = 0; j < count; j++)
				{
					ActionElementMap actionElementMap2 = ykTTJefdVTAYyECYQpCbYHQOWGx[j];
					if ((!P_1 || actionElementMap2.fnEBjitvkHhPtXTzRLmBYpIxFbt) && actionElementMap.CheckForAssignmentConflict(actionElementMap2))
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

		internal virtual int uYwxIBEwgxONcHwzfXTGnIioFcq(ActionElementMap P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			if (P_2 != null && !P_3)
			{
				P_2.Clear();
			}
			if (P_0 == null)
			{
				return 0;
			}
			if (P_1 && (!_enabled || !P_0.fnEBjitvkHhPtXTzRLmBYpIxFbt))
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
				ActionElementMap actionElementMap = YkTTJefdVTAYyECYQpCbYHQOWGx[i];
				if (actionElementMap.fnEBjitvkHhPtXTzRLmBYpIxFbt && P_0.CheckForAssignmentConflict(actionElementMap))
				{
					actionElementMap.enabled = false;
					P_2?.Add(actionElementMap);
					num++;
				}
			}
			return num;
		}

		internal virtual int uYwxIBEwgxONcHwzfXTGnIioFcq(ElementAssignmentConflictCheck P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			if (P_2 != null && !P_3)
			{
				P_2.Clear();
			}
			if (P_1 && !_enabled)
			{
				return 0;
			}
			if (YkTTJefdVTAYyECYQpCbYHQOWGx == null)
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
				ActionElementMap actionElementMap = YkTTJefdVTAYyECYQpCbYHQOWGx[i];
				if (actionElementMap.fnEBjitvkHhPtXTzRLmBYpIxFbt && actionElementMap.JYRMuwETpVNRqJXmtBgBFhZdTeP != P_0.elementMapId && actionElementMap.CheckForAssignmentConflict(elementAssignment))
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
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
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
			if (bAHtrfdakdbHbbbKUCDCgljGflpo == null)
			{
				return num;
			}
			IList<ActionElementMap> list = controllerMap.bAHtrfdakdbHbbbKUCDCgljGflpo;
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
			for (int num2 = bAHtrfdakdbHbbbKUCDCgljGflpo.Count - 1; num2 >= 0; num2--)
			{
				ActionElementMap actionElementMap = bAHtrfdakdbHbbbKUCDCgljGflpo[num2];
				if (!skipDisabledMaps || actionElementMap.fnEBjitvkHhPtXTzRLmBYpIxFbt)
				{
					for (int i = 0; i < count; i++)
					{
						if ((!skipDisabledMaps || list[i].fnEBjitvkHhPtXTzRLmBYpIxFbt) && actionElementMap.CheckForAssignmentConflict(list[i]))
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
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
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
			if (skipDisabledMaps && (!_enabled || !actionElementMap.fnEBjitvkHhPtXTzRLmBYpIxFbt))
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
			if (bAHtrfdakdbHbbbKUCDCgljGflpo == null)
			{
				return num;
			}
			for (int num2 = bAHtrfdakdbHbbbKUCDCgljGflpo.Count - 1; num2 >= 0; num2--)
			{
				ActionElementMap actionElementMap2 = bAHtrfdakdbHbbbKUCDCgljGflpo[num2];
				if ((!skipDisabledMaps || actionElementMap2.fnEBjitvkHhPtXTzRLmBYpIxFbt) && actionElementMap2.CheckForAssignmentConflict(actionElementMap))
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
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
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
			if (bAHtrfdakdbHbbbKUCDCgljGflpo == null)
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
			for (int num2 = bAHtrfdakdbHbbbKUCDCgljGflpo.Count - 1; num2 >= 0; num2--)
			{
				ActionElementMap actionElementMap = bAHtrfdakdbHbbbKUCDCgljGflpo[num2];
				if ((!skipDisabledMaps || actionElementMap.fnEBjitvkHhPtXTzRLmBYpIxFbt) && actionElementMap.JYRMuwETpVNRqJXmtBgBFhZdTeP != conflictCheck.elementMapId && actionElementMap.CheckForAssignmentConflict(elementAssignment))
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
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
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
				array[i] = YkTTJefdVTAYyECYQpCbYHQOWGx[i].elementIdentifierName;
			}
			return array;
		}

		public string ToXmlString()
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return string.Empty;
			}
			try
			{
				return MtzBZMSurJCTTdjsBqkSRhDyHCFi().ToXmlString(writeDocumentTag: true);
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error writing " + GetType().Name + " to XML. " + ex.Message);
				return string.Empty;
			}
		}

		public string ToJsonString()
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return string.Empty;
			}
			try
			{
				return MtzBZMSurJCTTdjsBqkSRhDyHCFi().ToJsonString();
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error writing " + GetType().Name + " to JSON. " + ex.Message);
				return string.Empty;
			}
		}

		public ControllerTemplateMap ToControllerTemplateMap(Guid templateTypeGuid)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
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
				HardwareJoystickTemplateMap hardwareJoystickTemplateMap = ReInput.cLdABFWHhJhGBDqNNUOhtHkebrR(templateTypeGuid);
				string text = ((hardwareJoystickTemplateMap != null) ? hardwareJoystickTemplateMap.ClassName : templateTypeGuid.ToString());
				Logger.LogError("The Controller does not implement " + text + ".", requiredThreadSafety: true);
				return null;
			}
			return ControllerTemplateMap.WdHmbeogxFpqCPrhnXEZqMrbhjd(controllerTemplate, this);
		}

		public ControllerTemplateMap ToControllerTemplateMap<T>() where T : class
		{
			return ToControllerTemplateMap(typeof(T));
		}

		public ControllerTemplateMap ToControllerTemplateMap(Type templateInterfaceType)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return null;
			}
			if ((object)templateInterfaceType == null)
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
			return ControllerTemplateMap.WdHmbeogxFpqCPrhnXEZqMrbhjd(controllerTemplate, this);
		}

		private ControllerTemplateMap aJzvccXmqmmnZEDsEgDhWqEexYq(IControllerTemplate P_0)
		{
			if (ReInput._id != VumWnlylMgxSbyJcluXptXvaaZa)
			{
				ReInput.CheckInitialized(VumWnlylMgxSbyJcluXptXvaaZa);
				return null;
			}
			if (P_0 == null)
			{
				throw new ArgumentNullException("controllerTemplate");
			}
			return ControllerTemplateMap.WdHmbeogxFpqCPrhnXEZqMrbhjd(P_0, this);
		}

		internal virtual bool iXVFNbKWeZKqDcDBYTqLDREGlmD(ActionElementMap P_0)
		{
			if (!bbEggoxgYPAkARDGnCkXZJCiEYGa(P_0._elementType))
			{
				return false;
			}
			DsowFbtcOyiDrdyfjcycNGirkoAa(P_0);
			return true;
		}

		internal virtual int VPLwlUlbVJcGxInkzAvGWInfZls(List<ActionElementMap> P_0, bool P_1)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("results");
			}
			int count = P_0.Count;
			int count2 = YkTTJefdVTAYyECYQpCbYHQOWGx.Count;
			for (int i = 0; i < count2; i++)
			{
				if (!P_1 || YkTTJefdVTAYyECYQpCbYHQOWGx[i].fnEBjitvkHhPtXTzRLmBYpIxFbt)
				{
					P_0.Add(YkTTJefdVTAYyECYQpCbYHQOWGx[i]);
				}
			}
			return P_0.Count - count;
		}

		internal virtual ActionElementMap abscXzkbpziyejRZVLMtgMvqAFy(int P_0, int P_1, ControllerElementType P_2)
		{
			if (!bbEggoxgYPAkARDGnCkXZJCiEYGa(P_2))
			{
				return null;
			}
			int num = kncrJkmpVAOgmtLIWIwSzrcRtQu(P_0, P_1, P_2);
			if (num < 0)
			{
				return null;
			}
			return YkTTJefdVTAYyECYQpCbYHQOWGx[num];
		}

		internal virtual int NKYfbOdBSBNhrFNHdTAMOylLEUac(int P_0, List<ActionElementMap> P_1, bool P_2)
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
			if (YkTTJefdVTAYyECYQpCbYHQOWGx == null)
			{
				return 0;
			}
			int num2 = buttonMapCount;
			for (int i = 0; i < num2; i++)
			{
				if (YkTTJefdVTAYyECYQpCbYHQOWGx[i]._elementIdentifierId == P_0)
				{
					P_1.Add(YkTTJefdVTAYyECYQpCbYHQOWGx[i]);
				}
			}
			return P_1.Count - num;
		}

		internal virtual bool VwahVJeKeHeJMeEBtlOFHnajoCLq(int P_0, int P_1, ControllerElementType P_2)
		{
			if (!bbEggoxgYPAkARDGnCkXZJCiEYGa(P_2))
			{
				return false;
			}
			int num = buttonMapCount;
			for (int i = 0; i < num; i++)
			{
				if (YkTTJefdVTAYyECYQpCbYHQOWGx[i]._elementIdentifierId == P_0 && YkTTJefdVTAYyECYQpCbYHQOWGx[i]._actionId == P_1)
				{
					return true;
				}
			}
			return false;
		}

		internal virtual int kncrJkmpVAOgmtLIWIwSzrcRtQu(int P_0, int P_1, ControllerElementType P_2)
		{
			if (!bbEggoxgYPAkARDGnCkXZJCiEYGa(P_2))
			{
				return -1;
			}
			if (YkTTJefdVTAYyECYQpCbYHQOWGx == null)
			{
				return -1;
			}
			int num = buttonMapCount;
			for (int i = 0; i < num; i++)
			{
				if (YkTTJefdVTAYyECYQpCbYHQOWGx[i]._elementIdentifierId == P_0 && YkTTJefdVTAYyECYQpCbYHQOWGx[i]._actionId == P_1)
				{
					return i;
				}
			}
			return -1;
		}

		internal int kMXCVlsFwJKKRzfwDXYvOGCsgtD(int P_0)
		{
			if (YkTTJefdVTAYyECYQpCbYHQOWGx == null)
			{
				return -1;
			}
			int num = buttonMapCount;
			for (int i = 0; i < num; i++)
			{
				if (YkTTJefdVTAYyECYQpCbYHQOWGx[i].JYRMuwETpVNRqJXmtBgBFhZdTeP == P_0)
				{
					return i;
				}
			}
			return -1;
		}

		internal int MtFmSJLBtNGupVOURySmmQfDDld(bool P_0, List<ActionElementMap> P_1, bool P_2)
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
				ActionElementMap actionElementMap = YkTTJefdVTAYyECYQpCbYHQOWGx[i];
				if (!P_0 || actionElementMap.fnEBjitvkHhPtXTzRLmBYpIxFbt)
				{
					P_1.Add(actionElementMap);
					num2++;
				}
			}
			return num2;
		}

		internal int EwxUCWIjgNvgwPkYWOoxwAiADEI(int P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
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
				ActionElementMap actionElementMap = YkTTJefdVTAYyECYQpCbYHQOWGx[i];
				if (actionElementMap._actionId == P_0 && (!P_1 || actionElementMap.fnEBjitvkHhPtXTzRLmBYpIxFbt))
				{
					P_2.Add(actionElementMap);
					num2++;
				}
			}
			return num2;
		}

		internal virtual int paPqgnqavLYCqgponTssufOHcpc(int P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
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
				ActionElementMap actionElementMap = YkTTJefdVTAYyECYQpCbYHQOWGx[i];
				if (actionElementMap._actionId == P_0 && (!P_1 || actionElementMap.fnEBjitvkHhPtXTzRLmBYpIxFbt))
				{
					P_2.Add(actionElementMap);
					num++;
				}
			}
			return num;
		}

		internal virtual ActionElementMap TythgSbwYmNijsQNDAZZfufNFdk(IControllerElementTarget P_0, bool P_1, int P_2, bool P_3, out bool P_4)
		{
			P_4 = false;
			if (P_1 && P_2 < 0)
			{
				P_4 = true;
				return null;
			}
			if (!fQFAqUdnfRQwWIHtbuuSiIrqGic(P_0))
			{
				P_4 = true;
				return null;
			}
			if (!bbEggoxgYPAkARDGnCkXZJCiEYGa(P_0.elementType))
			{
				return null;
			}
			int num = buttonMapCount;
			_ = P_0.elementIdentifierId;
			for (int i = 0; i < num; i++)
			{
				if ((!P_1 || YkTTJefdVTAYyECYQpCbYHQOWGx[i]._actionId == P_2) && (!P_3 || YkTTJefdVTAYyECYQpCbYHQOWGx[i].fnEBjitvkHhPtXTzRLmBYpIxFbt) && YkTTJefdVTAYyECYQpCbYHQOWGx[i].IsTarget(P_0))
				{
					return YkTTJefdVTAYyECYQpCbYHQOWGx[i];
				}
			}
			return null;
		}

		internal virtual int VOIVoTgEPzUDZzgXkQydAIFJfLn(IControllerElementTarget P_0, bool P_1, int P_2, bool P_3, List<ActionElementMap> P_4, bool P_5, out bool P_6)
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
			if (!fQFAqUdnfRQwWIHtbuuSiIrqGic(P_0))
			{
				P_6 = true;
				return num;
			}
			if (!bbEggoxgYPAkARDGnCkXZJCiEYGa(P_0.elementType))
			{
				return num;
			}
			int num2 = buttonMapCount;
			_ = P_0.elementIdentifierId;
			for (int i = 0; i < num2; i++)
			{
				if ((!P_1 || YkTTJefdVTAYyECYQpCbYHQOWGx[i]._actionId == P_2) && (!P_3 || YkTTJefdVTAYyECYQpCbYHQOWGx[i].fnEBjitvkHhPtXTzRLmBYpIxFbt) && YkTTJefdVTAYyECYQpCbYHQOWGx[i].IsTarget(P_0))
				{
					P_4.Add(YkTTJefdVTAYyECYQpCbYHQOWGx[i]);
					num++;
				}
			}
			return num;
		}

		internal void OxEMVbWTSfUOLcynBPcYYiHuOis(int P_0, ControllerElementType P_1)
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
				IatatAaUtWRxlkFXsRjmLeztlkR(elementMap);
			}
		}

		internal virtual bool IatatAaUtWRxlkFXsRjmLeztlkR(ActionElementMap P_0)
		{
			if (P_0 == null)
			{
				return false;
			}
			if (!bbEggoxgYPAkARDGnCkXZJCiEYGa(P_0._elementType))
			{
				return false;
			}
			YkTTJefdVTAYyECYQpCbYHQOWGx.Add(P_0);
			jLuFBQmqnmBfWMLqKnmNxPAKHds(P_0);
			return true;
		}

		internal bool fQFAqUdnfRQwWIHtbuuSiIrqGic(IControllerElementTarget P_0)
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

		internal bool WFAybvFElcFTYvXJKZXjWvsTlWu(string P_0)
		{
			try
			{
				tlMbXbDwaaKJTudkJIuTPdZmwuo(SerializedObject.FromXml(GetType(), P_0));
				return true;
			}
			catch (Exception ex)
			{
				Logger.LogError("Error creating  " + GetType().Name + "  from XML. " + ex.Message);
				return false;
			}
		}

		internal bool SDYWZqNutdNGtpNMJBdKBBzlYyCG(string P_0)
		{
			try
			{
				tlMbXbDwaaKJTudkJIuTPdZmwuo(SerializedObject.FromJson(GetType(), P_0));
				return true;
			}
			catch (Exception ex)
			{
				Logger.LogError("Error creating  " + GetType().Name + "  from JSON. " + ex.Message);
				return false;
			}
		}

		internal void jLuFBQmqnmBfWMLqKnmNxPAKHds(ActionElementMap P_0)
		{
			if (P_0 != null)
			{
				bAHtrfdakdbHbbbKUCDCgljGflpo.Add(P_0);
				bAHtrfdakdbHbbbKUCDCgljGflpo.Sort(xlzaAaXfkqDKcuAWRDLzIwiHrTkm.Default);
			}
		}

		internal void hgneUeifSUUGUGPrMpPNWRmXcVz(int P_0)
		{
			int num = vkSmfqxJRedHUWQSMyhdwuAzSFS(P_0);
			if (num >= 0)
			{
				bAHtrfdakdbHbbbKUCDCgljGflpo.RemoveAt(num);
			}
		}

		internal void yoQxGAHDlXiVoeZUaJPtQogDvOO(int P_0, ActionElementMap P_1)
		{
			if (P_1 != null)
			{
				int num = vkSmfqxJRedHUWQSMyhdwuAzSFS(P_0);
				if (num >= 0)
				{
					bAHtrfdakdbHbbbKUCDCgljGflpo[num] = P_1;
					bAHtrfdakdbHbbbKUCDCgljGflpo.Sort(xlzaAaXfkqDKcuAWRDLzIwiHrTkm.Default);
				}
			}
		}

		internal static void PnTxkUsNLsMLtRkowVxXNqXtKTz(ActionElementMap P_0, int P_1, Pole P_2, int P_3, ControllerElementType P_4, AxisRange P_5, bool P_6)
		{
			P_0.VcHhfbFqwxAmqhwBHKVJpDjlfufe();
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
				ReInput.controllers.GetController(_controllerType, _controllerId).IginakiartMCXcNztgFGkBgBmEe(this, map);
			}
		}

		internal virtual bool tlMbXbDwaaKJTudkJIuTPdZmwuo(SerializedObject P_0)
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
						actionElementMap.tlMbXbDwaaKJTudkJIuTPdZmwuo(value2);
						if (ActionElementMap.ZRWaEectppfsHBsWRgRqpGFYQNNI(actionElementMap))
						{
							DsowFbtcOyiDrdyfjcycNGirkoAa(actionElementMap);
						}
					}
				}
			}
			return flag;
		}

		internal virtual void jcgUSwYyXKIwVuYwxHnWUgkgsoK(SerializedObject P_0)
		{
			if (P_0.xmlInfo == null)
			{
				P_0.xmlInfo = new SerializedObject.XmlInfo();
			}
			P_0.Add("dataVersion", 2, SerializedObject.FieldOptions.ExculdeFromXml);
			P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.yOvafjSNTWBQXamMnEDaXllsdXm
			{
				NSIraOohUuxbwNWwnOfcoaPLKLA = "dataVersion",
				lvXCTCWOhrCtuFDbbEqyqyUVPhp = 2.ToString()
			});
			if (object.ReferenceEquals(GetType(), typeof(JoystickMap)))
			{
				Joystick joystick = ReInput.controllers.GetJoystick(_controllerId);
				Guid guid = joystick?.hardwareTypeGuid ?? Guid.Empty;
				string lvXCTCWOhrCtuFDbbEqyqyUVPhp = ((joystick != null) ? SerializationTools.CleanInvalidXmlChars(joystick.hardwareName) : "Unknown");
				P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.yOvafjSNTWBQXamMnEDaXllsdXm
				{
					NSIraOohUuxbwNWwnOfcoaPLKLA = "hardwareGuid",
					lvXCTCWOhrCtuFDbbEqyqyUVPhp = guid.ToString()
				});
				P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.yOvafjSNTWBQXamMnEDaXllsdXm
				{
					NSIraOohUuxbwNWwnOfcoaPLKLA = "hardwareName",
					lvXCTCWOhrCtuFDbbEqyqyUVPhp = lvXCTCWOhrCtuFDbbEqyqyUVPhp
				});
			}
			P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.yOvafjSNTWBQXamMnEDaXllsdXm
			{
				tpjeoHgHRUvvsMOVGUmfENOfWgb = "xmlns",
				NSIraOohUuxbwNWwnOfcoaPLKLA = "xsi",
				KyKFPbDbzyvJvQZYVoBMpXenzVYN = null,
				lvXCTCWOhrCtuFDbbEqyqyUVPhp = "http://www.w3.org/2001/XMLSchema-instance"
			});
			P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.yOvafjSNTWBQXamMnEDaXllsdXm
			{
				tpjeoHgHRUvvsMOVGUmfENOfWgb = "xsi",
				NSIraOohUuxbwNWwnOfcoaPLKLA = "schemaLocation",
				KyKFPbDbzyvJvQZYVoBMpXenzVYN = null,
				lvXCTCWOhrCtuFDbbEqyqyUVPhp = string.Format("{0} {1}{2}{3}{4}{5}", "http://guavaman.com/rewired", "http://guavaman.com/schemas/rewired/", "1.1", "/", GetType().Name, ".xsd")
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
				if (YkTTJefdVTAYyECYQpCbYHQOWGx[i] != null)
				{
					list.Add(YkTTJefdVTAYyECYQpCbYHQOWGx[i].MtzBZMSurJCTTdjsBqkSRhDyHCFi());
				}
			}
		}

		private bool bbEggoxgYPAkARDGnCkXZJCiEYGa(ControllerElementType P_0)
		{
			if (P_0 != ControllerElementType.Button)
			{
				return false;
			}
			return true;
		}

		private void gjWevMAzYuoXipDOwMQpQWDxGssT(int P_0, int P_1)
		{
			hgneUeifSUUGUGPrMpPNWRmXcVz(P_0);
			if (P_1 >= 0 && P_1 < buttonMapCount)
			{
				YkTTJefdVTAYyECYQpCbYHQOWGx.RemoveAt(P_1);
			}
		}

		private void DsowFbtcOyiDrdyfjcycNGirkoAa(ActionElementMap P_0)
		{
			if (P_0 != null)
			{
				YkTTJefdVTAYyECYQpCbYHQOWGx.Add(P_0);
				jLuFBQmqnmBfWMLqKnmNxPAKHds(P_0);
			}
		}

		private void VdWNbRHrjZxZoHwRBaGWsCxpiRi(ActionElementMap P_0, int P_1)
		{
			if (P_0 != null && P_1 >= 0 && P_1 < buttonMapCount)
			{
				yoQxGAHDlXiVoeZUaJPtQogDvOO(YkTTJefdVTAYyECYQpCbYHQOWGx[P_1].JYRMuwETpVNRqJXmtBgBFhZdTeP, P_0);
				YkTTJefdVTAYyECYQpCbYHQOWGx[P_1] = P_0;
			}
		}

		private int vkSmfqxJRedHUWQSMyhdwuAzSFS(int P_0)
		{
			if (bAHtrfdakdbHbbbKUCDCgljGflpo == null)
			{
				return -1;
			}
			int count = bAHtrfdakdbHbbbKUCDCgljGflpo.Count;
			for (int i = 0; i < count; i++)
			{
				if (bAHtrfdakdbHbbbKUCDCgljGflpo[i].JYRMuwETpVNRqJXmtBgBFhZdTeP == P_0)
				{
					return i;
				}
			}
			return -1;
		}

		private SerializedObject MtzBZMSurJCTTdjsBqkSRhDyHCFi()
		{
			SerializedObject serializedObject = new SerializedObject(GetType(), SerializedObject.ObjectType.Object);
			jcgUSwYyXKIwVuYwxHnWUgkgsoK(serializedObject);
			return serializedObject;
		}

		internal static ControllerMap ikoBGVHHLVNnLaVaWGffMETVhTJw(ControllerType P_0)
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

		internal static ControllerMap SYXlQmHOzCKJIifRKNsrYHodbMla(Controller P_0, int P_1, int P_2)
		{
			if (P_0 == null)
			{
				return null;
			}
			return P_0.type switch
			{
				ControllerType.Keyboard => KeyboardMap.SYXlQmHOzCKJIifRKNsrYHodbMla(P_0.hardwareTypeGuid, P_1, P_2), 
				ControllerType.Mouse => MouseMap.SYXlQmHOzCKJIifRKNsrYHodbMla(P_0.hardwareTypeGuid, P_1, P_2), 
				ControllerType.Joystick => JoystickMap.SYXlQmHOzCKJIifRKNsrYHodbMla(P_0.hardwareTypeGuid, P_1, P_2), 
				ControllerType.Custom => CustomControllerMap.SYXlQmHOzCKJIifRKNsrYHodbMla(P_0.hardwareTypeGuid, ((CustomController)P_0).sourceControllerId, P_1, P_2), 
				_ => throw new NotImplementedException(), 
			};
		}

		public static ControllerMap CreateFromXml(ControllerType controllerType, string xmlString)
		{
			if (string.IsNullOrEmpty(xmlString))
			{
				return null;
			}
			ControllerMap controllerMap = ikoBGVHHLVNnLaVaWGffMETVhTJw(controllerType);
			try
			{
				controllerMap.WFAybvFElcFTYvXJKZXjWvsTlWu(xmlString);
				return controllerMap;
			}
			catch
			{
				return null;
			}
		}
	}
}
