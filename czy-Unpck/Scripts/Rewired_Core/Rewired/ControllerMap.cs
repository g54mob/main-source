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
		private class ZMKdYnmvaVrNKCmWlEgzdUJtqiVH : IComparer<ActionElementMap>
		{
			public static ZMKdYnmvaVrNKCmWlEgzdUJtqiVH BgVAlBbqHGOjWMKDVziUeWXeAbTf;

			public static ZMKdYnmvaVrNKCmWlEgzdUJtqiVH Default => BgVAlBbqHGOjWMKDVziUeWXeAbTf ?? (BgVAlBbqHGOjWMKDVziUeWXeAbTf = new ZMKdYnmvaVrNKCmWlEgzdUJtqiVH());

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
				int num;
				int num2;
				int num3 = default(int);
				ControllerElementType elementType = default(ControllerElementType);
				switch (x._elementType)
				{
				case ControllerElementType.Axis:
					num = 1;
					num2 = 170174613;
					goto IL_0059;
				case ControllerElementType.CompoundElement:
					goto IL_00ea;
				case ControllerElementType.Button:
					goto IL_0100;
				default:
					goto IL_010c;
					IL_0059:
					while (true)
					{
						switch (num2 ^ 0xA24A895)
						{
						case 14:
							num2 = 170174621;
							continue;
						case 5:
							num3 = 1;
							num2 = 170174622;
							continue;
						case 7:
							break;
						case 4:
							num2 = 170174622;
							continue;
						case 2:
							goto IL_00be;
						case 0:
							num2 = 170174620;
							continue;
						case 10:
							throw new NotImplementedException();
						case 12:
							goto IL_00de;
						case 3:
							goto IL_00ea;
						case 6:
							num2 = 170174620;
							continue;
						case 8:
							goto IL_0100;
						case 13:
							goto IL_010c;
						case 1:
							switch (elementType)
							{
							case ControllerElementType.Axis:
								break;
							case ControllerElementType.Button:
								goto IL_00be;
							case ControllerElementType.CompoundElement:
								goto IL_00de;
							default:
								goto IL_0131;
							}
							goto case 5;
						case 9:
							elementType = y._elementType;
							num2 = 170174612;
							continue;
						default:
							goto IL_014d;
							IL_0131:
							num2 = 170174623;
							continue;
							IL_00de:
							num3 = 2;
							num2 = 170174622;
							continue;
							IL_00be:
							num3 = 0;
							num2 = 170174609;
							continue;
						}
						break;
					}
					goto case ControllerElementType.Axis;
					IL_014d:
					if (num <= num3)
					{
						return -1;
					}
					return 1;
					IL_0100:
					num = 0;
					num2 = 170174620;
					goto IL_0059;
					IL_00ea:
					num = 2;
					num2 = 170174611;
					goto IL_0059;
					IL_010c:
					throw new NotImplementedException();
				}
			}
		}

		private sealed class neKfltxxMSIHUcgdWMFvukkDTtM : IDisposable, IEnumerator, IEnumerable, IEnumerable<ActionElementMap>, IEnumerator<ActionElementMap>
		{
			private ActionElementMap ubyTdixGSFKGaFQFZdQnpwgWIvJ;

			private int isaqVUvqwfWYqOUtovbpbCbxgPc;

			private int TFdbdCIUKXTQPHFlNuiMVnWNXiVT;

			public ControllerMap syCPfFbHYMDOvEPjTnPLBqiOhsPv;

			public int ACjpllpkcaGYOMYTzhdQxIrphnx;

			public int QLOttLyzbwmZEgbaVWtyYLtwEXF;

			public bool gDMrNwHmEkVTACgeEefdCmJdpir;

			public bool dGwSNihzjCwVEkHXFGPpgtHVneEu;

			public ActionElementMap mYDqBAmdZAtgTxiNpGYpOGdzVgE;

			public IEnumerator<ActionElementMap> OOJjmldUAEviXLJzsRtohrjrBvp;

			ActionElementMap IEnumerator<ActionElementMap>.Current
			{
				[DebuggerHidden]
				get
				{
					return ubyTdixGSFKGaFQFZdQnpwgWIvJ;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return ubyTdixGSFKGaFQFZdQnpwgWIvJ;
				}
			}

			[DebuggerHidden]
			IEnumerator<ActionElementMap> IEnumerable<ActionElementMap>.GetEnumerator()
			{
				neKfltxxMSIHUcgdWMFvukkDTtM neKfltxxMSIHUcgdWMFvukkDTtM2;
				if (Thread.CurrentThread.ManagedThreadId == TFdbdCIUKXTQPHFlNuiMVnWNXiVT && isaqVUvqwfWYqOUtovbpbCbxgPc == -2)
				{
					isaqVUvqwfWYqOUtovbpbCbxgPc = 0;
					neKfltxxMSIHUcgdWMFvukkDTtM2 = this;
				}
				else
				{
					while (true)
					{
						neKfltxxMSIHUcgdWMFvukkDTtM2 = new neKfltxxMSIHUcgdWMFvukkDTtM(0);
						neKfltxxMSIHUcgdWMFvukkDTtM2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = syCPfFbHYMDOvEPjTnPLBqiOhsPv;
						int num = -137612031;
						while (true)
						{
							switch (num ^ -137612029)
							{
							case 0:
								num = -137612030;
								continue;
							case 1:
								break;
							default:
								goto end_IL_0045;
							}
							break;
						}
						continue;
						end_IL_0045:
						break;
					}
				}
				neKfltxxMSIHUcgdWMFvukkDTtM2.ACjpllpkcaGYOMYTzhdQxIrphnx = QLOttLyzbwmZEgbaVWtyYLtwEXF;
				neKfltxxMSIHUcgdWMFvukkDTtM2.gDMrNwHmEkVTACgeEefdCmJdpir = dGwSNihzjCwVEkHXFGPpgtHVneEu;
				return neKfltxxMSIHUcgdWMFvukkDTtM2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				bool result = default(bool);
				try
				{
					int num;
					switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
					{
					case 2:
						goto IL_00a8;
					default:
						goto IL_00b9;
					case 0:
						goto IL_011f;
						IL_00a8:
						isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
						num = -596861773;
						goto IL_0023;
						IL_0023:
						while (true)
						{
							switch (num ^ -596861776)
							{
							case 6:
								num = -596861765;
								continue;
							case 3:
								goto IL_0063;
							case 7:
								goto IL_0081;
							case 10:
								goto IL_00a8;
							case 9:
								goto IL_00b9;
							case 0:
								mYDqBAmdZAtgTxiNpGYpOGdzVgE = OOJjmldUAEviXLJzsRtohrjrBvp.Current;
								num = -596861771;
								continue;
							case 5:
								if (mYDqBAmdZAtgTxiNpGYpOGdzVgE._actionId != ACjpllpkcaGYOMYTzhdQxIrphnx)
								{
									goto IL_0063;
								}
								if (gDMrNwHmEkVTACgeEefdCmJdpir)
								{
									goto IL_00fe;
								}
								goto case 1;
							case 11:
								goto IL_011f;
							case 2:
								AFsTPWKmOOgGqbFwsBqydWztAMx();
								num = -596861767;
								continue;
							case 1:
								ubyTdixGSFKGaFQFZdQnpwgWIvJ = mYDqBAmdZAtgTxiNpGYpOGdzVgE;
								isaqVUvqwfWYqOUtovbpbCbxgPc = 2;
								result = true;
								num = -596861768;
								continue;
							case 8:
								break;
							case 4:
								break;
							}
							break;
							IL_00fe:
							int num2;
							if (mYDqBAmdZAtgTxiNpGYpOGdzVgE.FnzJwrQpikWfZbmfjZhFwutJGAA)
							{
								num = -596861775;
								num2 = num;
							}
							else
							{
								num = -596861773;
								num2 = num;
							}
							continue;
							IL_0063:
							int num3;
							if (!OOJjmldUAEviXLJzsRtohrjrBvp.MoveNext())
							{
								num = -596861774;
								num3 = num;
							}
							else
							{
								num = -596861776;
								num3 = num;
							}
						}
						break;
						IL_011f:
						isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
						if (ReInput._id != syCPfFbHYMDOvEPjTnPLBqiOhsPv.vuPDNwATQFuTZgAqTRoviXUGAgFM)
						{
							ReInput.CheckInitialized(syCPfFbHYMDOvEPjTnPLBqiOhsPv.vuPDNwATQFuTZgAqTRoviXUGAgFM);
							num = -596861767;
							goto IL_0023;
						}
						goto IL_0081;
						IL_0081:
						OOJjmldUAEviXLJzsRtohrjrBvp = syCPfFbHYMDOvEPjTnPLBqiOhsPv.AllMaps.GetEnumerator();
						isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
						num = -596861773;
						goto IL_0023;
						IL_00b9:
						result = false;
						num = -596861772;
						goto IL_0023;
					}
				}
				catch
				{
					//try-fault
					((IDisposable)this).Dispose();
					throw;
				}
				return result;
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
				switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
				{
				case 1:
				case 2:
					try
					{
						break;
					}
					finally
					{
						AFsTPWKmOOgGqbFwsBqydWztAMx();
					}
				}
			}

			[DebuggerHidden]
			public neKfltxxMSIHUcgdWMFvukkDTtM(int _003C_003E1__state)
			{
				isaqVUvqwfWYqOUtovbpbCbxgPc = _003C_003E1__state;
				TFdbdCIUKXTQPHFlNuiMVnWNXiVT = Thread.CurrentThread.ManagedThreadId;
			}

			private void AFsTPWKmOOgGqbFwsBqydWztAMx()
			{
				isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
				if (OOJjmldUAEviXLJzsRtohrjrBvp != null)
				{
					OOJjmldUAEviXLJzsRtohrjrBvp.Dispose();
				}
			}
		}

		private sealed class riszywFvpYEaFLjVpWanrijJGjv : IDisposable, IEnumerator, IEnumerable, IEnumerable<ActionElementMap>, IEnumerator<ActionElementMap>
		{
			private ActionElementMap ubyTdixGSFKGaFQFZdQnpwgWIvJ;

			private int isaqVUvqwfWYqOUtovbpbCbxgPc;

			private int TFdbdCIUKXTQPHFlNuiMVnWNXiVT;

			public ControllerMap syCPfFbHYMDOvEPjTnPLBqiOhsPv;

			public IControllerElementTarget JwvABOamNgPzyaagWUxoUgxSCVcI;

			public IControllerElementTarget zpRfvkHXclZCdsnNMywWBjZbfwbc;

			public bool gDMrNwHmEkVTACgeEefdCmJdpir;

			public bool dGwSNihzjCwVEkHXFGPpgtHVneEu;

			public TempListPool.TList<ActionElementMap> oSvUPVwlaQKYSbVDvoJULOyffKn;

			public List<ActionElementMap> FcqtPVRJXqHWMgkWDHifuPNixvt;

			public bool YlPplDBJjUITmAwQWlMKenYkKfmG;

			public ActionElementMap SLfgVGCWiWPGxmlnvXPxrDmyDQv;

			public List<ActionElementMap>.Enumerator uWjZdRGNPWNadwziykGtJSjaiH;

			ActionElementMap IEnumerator<ActionElementMap>.Current
			{
				[DebuggerHidden]
				get
				{
					return ubyTdixGSFKGaFQFZdQnpwgWIvJ;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return ubyTdixGSFKGaFQFZdQnpwgWIvJ;
				}
			}

			[DebuggerHidden]
			IEnumerator<ActionElementMap> IEnumerable<ActionElementMap>.GetEnumerator()
			{
				if (Thread.CurrentThread.ManagedThreadId == TFdbdCIUKXTQPHFlNuiMVnWNXiVT && isaqVUvqwfWYqOUtovbpbCbxgPc == -2)
				{
					isaqVUvqwfWYqOUtovbpbCbxgPc = 0;
					goto IL_0023;
				}
				goto IL_0059;
				IL_0028:
				int num;
				riszywFvpYEaFLjVpWanrijJGjv riszywFvpYEaFLjVpWanrijJGjv2 = default(riszywFvpYEaFLjVpWanrijJGjv);
				while (true)
				{
					switch (num ^ 0x490BE0FC)
					{
					case 0:
						break;
					case 4:
						riszywFvpYEaFLjVpWanrijJGjv2 = this;
						num = 1225515263;
						continue;
					case 3:
						num = 1225515262;
						continue;
					case 1:
						goto IL_0059;
					default:
						riszywFvpYEaFLjVpWanrijJGjv2.JwvABOamNgPzyaagWUxoUgxSCVcI = zpRfvkHXclZCdsnNMywWBjZbfwbc;
						riszywFvpYEaFLjVpWanrijJGjv2.gDMrNwHmEkVTACgeEefdCmJdpir = dGwSNihzjCwVEkHXFGPpgtHVneEu;
						return riszywFvpYEaFLjVpWanrijJGjv2;
					}
					break;
				}
				goto IL_0023;
				IL_0059:
				riszywFvpYEaFLjVpWanrijJGjv2 = new riszywFvpYEaFLjVpWanrijJGjv(0);
				riszywFvpYEaFLjVpWanrijJGjv2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = syCPfFbHYMDOvEPjTnPLBqiOhsPv;
				num = 1225515262;
				goto IL_0028;
				IL_0023:
				num = 1225515256;
				goto IL_0028;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				bool result = default(bool);
				try
				{
					int num = isaqVUvqwfWYqOUtovbpbCbxgPc;
					if (num != 0)
					{
						goto IL_000e;
					}
					goto IL_00ee;
					IL_000e:
					int num2 = 1015177952;
					goto IL_0013;
					IL_0013:
					while (true)
					{
						switch (num2 ^ 0x3C8262E1)
						{
						case 12:
							break;
						default:
							goto end_IL_0000;
						case 7:
							SLfgVGCWiWPGxmlnvXPxrDmyDQv = uWjZdRGNPWNadwziykGtJSjaiH.Current;
							ubyTdixGSFKGaFQFZdQnpwgWIvJ = SLfgVGCWiWPGxmlnvXPxrDmyDQv;
							isaqVUvqwfWYqOUtovbpbCbxgPc = 3;
							num2 = 1015177963;
							continue;
						case 8:
							gGaHEpuHScZuagetywirTHfjRds();
							PcOeWFLIiQpVWSfeHQzfURzpbhy();
							num2 = 1015177957;
							continue;
						case 16:
							oSvUPVwlaQKYSbVDvoJULOyffKn = TempListPool.GetTList<ActionElementMap>();
							num2 = 1015177955;
							continue;
						case 3:
							goto end_IL_0000;
						case 9:
							uWjZdRGNPWNadwziykGtJSjaiH = FcqtPVRJXqHWMgkWDHifuPNixvt.GetEnumerator();
							isaqVUvqwfWYqOUtovbpbCbxgPc = 2;
							num2 = 1015177967;
							continue;
						case 0:
							goto IL_00ee;
						case 6:
							num2 = 1015177957;
							continue;
						case 13:
							ReInput.CheckInitialized(syCPfFbHYMDOvEPjTnPLBqiOhsPv.vuPDNwATQFuTZgAqTRoviXUGAgFM);
							num2 = 1015177959;
							continue;
						case 10:
							result = true;
							num2 = 1015177954;
							continue;
						case 11:
							goto IL_014c;
						case 4:
							result = false;
							num2 = 1015177966;
							continue;
						case 14:
							num2 = 1015177962;
							continue;
						case 5:
							isaqVUvqwfWYqOUtovbpbCbxgPc = 2;
							num2 = 1015177962;
							continue;
						case 2:
							isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
							FcqtPVRJXqHWMgkWDHifuPNixvt = oSvUPVwlaQKYSbVDvoJULOyffKn.list;
							syCPfFbHYMDOvEPjTnPLBqiOhsPv.hqlCMKjVRQhOxlLPEQXdCmkbvsYc(JwvABOamNgPzyaagWUxoUgxSCVcI, false, -1, gDMrNwHmEkVTACgeEefdCmJdpir, FcqtPVRJXqHWMgkWDHifuPNixvt, false, out YlPplDBJjUITmAwQWlMKenYkKfmG);
							num2 = 1015177960;
							continue;
						case 1:
							if (num != 3)
							{
								num2 = 1015177957;
								continue;
							}
							goto case 5;
						case 15:
							goto end_IL_0000;
						}
						break;
						IL_014c:
						int num3;
						if (!uWjZdRGNPWNadwziykGtJSjaiH.MoveNext())
						{
							num2 = 1015177961;
							num3 = num2;
						}
						else
						{
							num2 = 1015177958;
							num3 = num2;
						}
					}
					goto IL_000e;
					IL_00ee:
					isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
					int num4;
					if (ReInput._id != syCPfFbHYMDOvEPjTnPLBqiOhsPv.vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						num2 = 1015177964;
						num4 = num2;
					}
					else
					{
						num2 = 1015177969;
						num4 = num2;
					}
					goto IL_0013;
					end_IL_0000:;
				}
				catch
				{
					//try-fault
					((IDisposable)this).Dispose();
					throw;
				}
				return result;
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
				switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
				{
				case 1:
				case 2:
				case 3:
					try
					{
						switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
						{
						case 2:
						case 3:
							try
							{
								break;
							}
							finally
							{
								gGaHEpuHScZuagetywirTHfjRds();
							}
						}
						break;
					}
					finally
					{
						PcOeWFLIiQpVWSfeHQzfURzpbhy();
					}
				}
			}

			[DebuggerHidden]
			public riszywFvpYEaFLjVpWanrijJGjv(int _003C_003E1__state)
			{
				isaqVUvqwfWYqOUtovbpbCbxgPc = _003C_003E1__state;
				TFdbdCIUKXTQPHFlNuiMVnWNXiVT = Thread.CurrentThread.ManagedThreadId;
			}

			private void PcOeWFLIiQpVWSfeHQzfURzpbhy()
			{
				isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
				if (oSvUPVwlaQKYSbVDvoJULOyffKn != null)
				{
					((IDisposable)oSvUPVwlaQKYSbVDvoJULOyffKn).Dispose();
				}
			}

			private void gGaHEpuHScZuagetywirTHfjRds()
			{
				isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
				((IDisposable)uWjZdRGNPWNadwziykGtJSjaiH/*cast due to .constrained prefix*/).Dispose();
			}
		}

		private sealed class jiBJXkaByUMRtcYAJxDrTBudGcn : IDisposable, IEnumerator, IEnumerable, IEnumerable<ActionElementMap>, IEnumerator<ActionElementMap>
		{
			private ActionElementMap ubyTdixGSFKGaFQFZdQnpwgWIvJ;

			private int isaqVUvqwfWYqOUtovbpbCbxgPc;

			private int TFdbdCIUKXTQPHFlNuiMVnWNXiVT;

			public ControllerMap syCPfFbHYMDOvEPjTnPLBqiOhsPv;

			public IControllerElementTarget JwvABOamNgPzyaagWUxoUgxSCVcI;

			public IControllerElementTarget zpRfvkHXclZCdsnNMywWBjZbfwbc;

			public int ACjpllpkcaGYOMYTzhdQxIrphnx;

			public int QLOttLyzbwmZEgbaVWtyYLtwEXF;

			public bool gDMrNwHmEkVTACgeEefdCmJdpir;

			public bool dGwSNihzjCwVEkHXFGPpgtHVneEu;

			public TempListPool.TList<ActionElementMap> lnXsQXxkIFOTgwsJXrZUimdIfVi;

			public List<ActionElementMap> UOzykqTPvcyanTTPlUaOTlmVzJV;

			public bool ApzaPAKYrigaZoFcprbbdbzCGZUM;

			public ActionElementMap sQKBdjdOFSXGprnDGxGJBeoZxci;

			public List<ActionElementMap>.Enumerator tLgqCnDkxlWqzAcajFhLULDsQUS;

			ActionElementMap IEnumerator<ActionElementMap>.Current
			{
				[DebuggerHidden]
				get
				{
					return ubyTdixGSFKGaFQFZdQnpwgWIvJ;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return ubyTdixGSFKGaFQFZdQnpwgWIvJ;
				}
			}

			[DebuggerHidden]
			IEnumerator<ActionElementMap> IEnumerable<ActionElementMap>.GetEnumerator()
			{
				jiBJXkaByUMRtcYAJxDrTBudGcn jiBJXkaByUMRtcYAJxDrTBudGcn2;
				if (Thread.CurrentThread.ManagedThreadId == TFdbdCIUKXTQPHFlNuiMVnWNXiVT && isaqVUvqwfWYqOUtovbpbCbxgPc == -2)
				{
					isaqVUvqwfWYqOUtovbpbCbxgPc = 0;
					jiBJXkaByUMRtcYAJxDrTBudGcn2 = this;
				}
				else
				{
					while (true)
					{
						jiBJXkaByUMRtcYAJxDrTBudGcn2 = new jiBJXkaByUMRtcYAJxDrTBudGcn(0);
						int num = -1354755894;
						while (true)
						{
							switch (num ^ -1354755894)
							{
							case 2:
								num = -1354755895;
								continue;
							case 3:
								break;
							case 0:
								jiBJXkaByUMRtcYAJxDrTBudGcn2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = syCPfFbHYMDOvEPjTnPLBqiOhsPv;
								num = -1354755893;
								continue;
							default:
								goto end_IL_0049;
							}
							break;
						}
						continue;
						end_IL_0049:
						break;
					}
				}
				jiBJXkaByUMRtcYAJxDrTBudGcn2.JwvABOamNgPzyaagWUxoUgxSCVcI = zpRfvkHXclZCdsnNMywWBjZbfwbc;
				jiBJXkaByUMRtcYAJxDrTBudGcn2.ACjpllpkcaGYOMYTzhdQxIrphnx = QLOttLyzbwmZEgbaVWtyYLtwEXF;
				jiBJXkaByUMRtcYAJxDrTBudGcn2.gDMrNwHmEkVTACgeEefdCmJdpir = dGwSNihzjCwVEkHXFGPpgtHVneEu;
				return jiBJXkaByUMRtcYAJxDrTBudGcn2;
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
					int num = isaqVUvqwfWYqOUtovbpbCbxgPc;
					if (num == 0)
					{
						goto IL_00a5;
					}
					if (num == 3)
					{
						goto IL_007f;
					}
					goto IL_017a;
					IL_00a5:
					isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
					int num2;
					if (ReInput._id != syCPfFbHYMDOvEPjTnPLBqiOhsPv.vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						ReInput.CheckInitialized(syCPfFbHYMDOvEPjTnPLBqiOhsPv.vuPDNwATQFuTZgAqTRoviXUGAgFM);
						num2 = -939931290;
						goto IL_001c;
					}
					goto IL_00d9;
					IL_007f:
					isaqVUvqwfWYqOUtovbpbCbxgPc = 2;
					num2 = -939931291;
					goto IL_001c;
					IL_001c:
					while (true)
					{
						switch (num2 ^ -939931291)
						{
						case 6:
							num2 = -939931284;
							continue;
						case 2:
							sQKBdjdOFSXGprnDGxGJBeoZxci = tLgqCnDkxlWqzAcajFhLULDsQUS.Current;
							ubyTdixGSFKGaFQFZdQnpwgWIvJ = sQKBdjdOFSXGprnDGxGJBeoZxci;
							num2 = -939931283;
							continue;
						case 1:
							num2 = -939931291;
							continue;
						case 4:
							break;
						case 8:
							isaqVUvqwfWYqOUtovbpbCbxgPc = 3;
							return true;
						case 9:
							goto IL_00a5;
						case 5:
							goto IL_00d9;
						case 7:
							isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
							UOzykqTPvcyanTTPlUaOTlmVzJV = lnXsQXxkIFOTgwsJXrZUimdIfVi.list;
							syCPfFbHYMDOvEPjTnPLBqiOhsPv.hqlCMKjVRQhOxlLPEQXdCmkbvsYc(JwvABOamNgPzyaagWUxoUgxSCVcI, true, ACjpllpkcaGYOMYTzhdQxIrphnx, gDMrNwHmEkVTACgeEefdCmJdpir, UOzykqTPvcyanTTPlUaOTlmVzJV, false, out ApzaPAKYrigaZoFcprbbdbzCGZUM);
							tLgqCnDkxlWqzAcajFhLULDsQUS = UOzykqTPvcyanTTPlUaOTlmVzJV.GetEnumerator();
							isaqVUvqwfWYqOUtovbpbCbxgPc = 2;
							num2 = -939931292;
							continue;
						case 0:
							if (!tLgqCnDkxlWqzAcajFhLULDsQUS.MoveNext())
							{
								bSVYmdRHlTfdddtUGUNiJChmzFqj();
								AJLsPkHSRlSgjeUtAnZrVRuxRVm();
								num2 = -939931290;
								continue;
							}
							goto case 2;
						default:
							goto IL_017a;
						}
						break;
					}
					goto IL_007f;
					IL_017a:
					return false;
					IL_00d9:
					lnXsQXxkIFOTgwsJXrZUimdIfVi = TempListPool.GetTList<ActionElementMap>();
					num2 = -939931294;
					goto IL_001c;
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
				int num = isaqVUvqwfWYqOUtovbpbCbxgPc;
				while (true)
				{
					int num2 = -207880964;
					while (true)
					{
						switch (num2 ^ -207880962)
						{
						case 0:
							break;
						default:
							return;
						case 2:
							switch (num)
							{
							case 1:
							case 2:
							case 3:
								try
								{
									switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
									{
									case 2:
									case 3:
										try
										{
											break;
										}
										finally
										{
											bSVYmdRHlTfdddtUGUNiJChmzFqj();
										}
									}
									return;
								}
								finally
								{
									AJLsPkHSRlSgjeUtAnZrVRuxRVm();
								}
							}
							goto IL_0039;
						case 1:
							return;
						}
						break;
						IL_0039:
						num2 = -207880961;
					}
				}
			}

			[DebuggerHidden]
			public jiBJXkaByUMRtcYAJxDrTBudGcn(int _003C_003E1__state)
			{
				isaqVUvqwfWYqOUtovbpbCbxgPc = _003C_003E1__state;
				TFdbdCIUKXTQPHFlNuiMVnWNXiVT = Thread.CurrentThread.ManagedThreadId;
			}

			private void AJLsPkHSRlSgjeUtAnZrVRuxRVm()
			{
				isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
				if (lnXsQXxkIFOTgwsJXrZUimdIfVi != null)
				{
					((IDisposable)lnXsQXxkIFOTgwsJXrZUimdIfVi).Dispose();
				}
			}

			private void bSVYmdRHlTfdddtUGUNiJChmzFqj()
			{
				isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
				((IDisposable)tLgqCnDkxlWqzAcajFhLULDsQUS/*cast due to .constrained prefix*/).Dispose();
			}
		}

		private sealed class dbXzvveBBmgCaERcFJABqjqFBwy : IDisposable, IEnumerator, IEnumerable, IEnumerable<ActionElementMap>, IEnumerator<ActionElementMap>
		{
			private ActionElementMap ubyTdixGSFKGaFQFZdQnpwgWIvJ;

			private int isaqVUvqwfWYqOUtovbpbCbxgPc;

			private int TFdbdCIUKXTQPHFlNuiMVnWNXiVT;

			public ControllerMap syCPfFbHYMDOvEPjTnPLBqiOhsPv;

			public int ACjpllpkcaGYOMYTzhdQxIrphnx;

			public int QLOttLyzbwmZEgbaVWtyYLtwEXF;

			public bool gDMrNwHmEkVTACgeEefdCmJdpir;

			public bool dGwSNihzjCwVEkHXFGPpgtHVneEu;

			public IList<ActionElementMap> wiagzkbINCsaAEEzCYJzbCVlvqo;

			public int iWnfFgNKbvnuqbcWUYasvbDLaJdG;

			public int OpENMaVCDfrKehMRUBAOoaSfnWJ;

			public ActionElementMap GCrPVJJefgiCAGEhTwZJFEwEgLe;

			ActionElementMap IEnumerator<ActionElementMap>.Current
			{
				[DebuggerHidden]
				get
				{
					return ubyTdixGSFKGaFQFZdQnpwgWIvJ;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return ubyTdixGSFKGaFQFZdQnpwgWIvJ;
				}
			}

			[DebuggerHidden]
			IEnumerator<ActionElementMap> IEnumerable<ActionElementMap>.GetEnumerator()
			{
				if (Thread.CurrentThread.ManagedThreadId == TFdbdCIUKXTQPHFlNuiMVnWNXiVT && isaqVUvqwfWYqOUtovbpbCbxgPc == -2)
				{
					isaqVUvqwfWYqOUtovbpbCbxgPc = 0;
					goto IL_0023;
				}
				goto IL_0070;
				IL_0028:
				int num;
				dbXzvveBBmgCaERcFJABqjqFBwy dbXzvveBBmgCaERcFJABqjqFBwy2 = default(dbXzvveBBmgCaERcFJABqjqFBwy);
				while (true)
				{
					switch (num ^ 0x13A340C8)
					{
					case 3:
						break;
					case 1:
						dbXzvveBBmgCaERcFJABqjqFBwy2 = this;
						num = 329466060;
						continue;
					case 4:
						num = 329466058;
						continue;
					case 2:
						dbXzvveBBmgCaERcFJABqjqFBwy2.ACjpllpkcaGYOMYTzhdQxIrphnx = QLOttLyzbwmZEgbaVWtyYLtwEXF;
						num = 329466061;
						continue;
					case 0:
						goto IL_0070;
					default:
						dbXzvveBBmgCaERcFJABqjqFBwy2.gDMrNwHmEkVTACgeEefdCmJdpir = dGwSNihzjCwVEkHXFGPpgtHVneEu;
						return dbXzvveBBmgCaERcFJABqjqFBwy2;
					}
					break;
				}
				goto IL_0023;
				IL_0070:
				dbXzvveBBmgCaERcFJABqjqFBwy2 = new dbXzvveBBmgCaERcFJABqjqFBwy(0);
				dbXzvveBBmgCaERcFJABqjqFBwy2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = syCPfFbHYMDOvEPjTnPLBqiOhsPv;
				num = 329466058;
				goto IL_0028;
				IL_0023:
				num = 329466057;
				goto IL_0028;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				int num = isaqVUvqwfWYqOUtovbpbCbxgPc;
				while (true)
				{
					int num2 = 1948501703;
					while (true)
					{
						switch (num2 ^ 0x7423C6C1)
						{
						case 0:
							break;
						case 9:
						{
							int num5;
							if (GCrPVJJefgiCAGEhTwZJFEwEgLe._actionId == ACjpllpkcaGYOMYTzhdQxIrphnx)
							{
								num2 = 1948501705;
								num5 = num2;
							}
							else
							{
								num2 = 1948501707;
								num5 = num2;
							}
							continue;
						}
						case 13:
							num2 = 1948501701;
							continue;
						case 5:
							GCrPVJJefgiCAGEhTwZJFEwEgLe = wiagzkbINCsaAEEzCYJzbCVlvqo[OpENMaVCDfrKehMRUBAOoaSfnWJ];
							num2 = 1948501704;
							continue;
						case 3:
							num2 = 1948501702;
							continue;
						case 7:
						{
							int num3;
							if (OpENMaVCDfrKehMRUBAOoaSfnWJ >= iWnfFgNKbvnuqbcWUYasvbDLaJdG)
							{
								num2 = 1948501701;
								num3 = num2;
							}
							else
							{
								num2 = 1948501700;
								num3 = num2;
							}
							continue;
						}
						case 8:
							if (gDMrNwHmEkVTACgeEefdCmJdpir)
							{
								int num4;
								if (!GCrPVJJefgiCAGEhTwZJFEwEgLe.FnzJwrQpikWfZbmfjZhFwutJGAA)
								{
									num2 = 1948501707;
									num4 = num2;
								}
								else
								{
									num2 = 1948501696;
									num4 = num2;
								}
								continue;
							}
							goto case 1;
						case 6:
							switch (num)
							{
							default:
								num2 = 1948501708;
								continue;
							case 1:
								isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
								num2 = 1948501707;
								continue;
							case 0:
								break;
							}
							goto case 11;
						case 12:
							num2 = 1948501701;
							continue;
						case 14:
							OpENMaVCDfrKehMRUBAOoaSfnWJ = 0;
							num2 = 1948501698;
							continue;
						case 2:
							if (ACjpllpkcaGYOMYTzhdQxIrphnx >= 0)
							{
								wiagzkbINCsaAEEzCYJzbCVlvqo = syCPfFbHYMDOvEPjTnPLBqiOhsPv.ButtonMaps;
								iWnfFgNKbvnuqbcWUYasvbDLaJdG = syCPfFbHYMDOvEPjTnPLBqiOhsPv.buttonMapCount;
								num2 = 1948501711;
								continue;
							}
							goto default;
						case 10:
							OpENMaVCDfrKehMRUBAOoaSfnWJ++;
							num2 = 1948501702;
							continue;
						case 1:
							ubyTdixGSFKGaFQFZdQnpwgWIvJ = GCrPVJJefgiCAGEhTwZJFEwEgLe;
							isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
							return true;
						case 11:
							isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
							if (ReInput._id != syCPfFbHYMDOvEPjTnPLBqiOhsPv.vuPDNwATQFuTZgAqTRoviXUGAgFM)
							{
								ReInput.CheckInitialized(syCPfFbHYMDOvEPjTnPLBqiOhsPv.vuPDNwATQFuTZgAqTRoviXUGAgFM);
								num2 = 1948501709;
								continue;
							}
							goto case 2;
						default:
							return false;
						}
						break;
					}
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
			}

			[DebuggerHidden]
			public dbXzvveBBmgCaERcFJABqjqFBwy(int _003C_003E1__state)
			{
				while (true)
				{
					int num = -385122993;
					while (true)
					{
						switch (num ^ -385122994)
						{
						case 2:
							break;
						default:
							return;
						case 1:
							goto IL_0024;
						case 0:
							return;
						}
						break;
						IL_0024:
						isaqVUvqwfWYqOUtovbpbCbxgPc = _003C_003E1__state;
						TFdbdCIUKXTQPHFlNuiMVnWNXiVT = Thread.CurrentThread.ManagedThreadId;
						num = -385122994;
					}
				}
			}
		}

		private sealed class XDIzbraqsYelFFnVnyzwdPQTrhEw : IDisposable, IEnumerator, IEnumerable, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
		{
			private ElementAssignmentConflictInfo ubyTdixGSFKGaFQFZdQnpwgWIvJ;

			private int isaqVUvqwfWYqOUtovbpbCbxgPc;

			private int TFdbdCIUKXTQPHFlNuiMVnWNXiVT;

			public ControllerMap syCPfFbHYMDOvEPjTnPLBqiOhsPv;

			public ControllerMap PVhoJNjtQFhTjmwRsuJhvQWcbfU;

			public ControllerMap IoOMsTyRkHoaIqFFqOwszJSmHpc;

			public bool gDMrNwHmEkVTACgeEefdCmJdpir;

			public bool dGwSNihzjCwVEkHXFGPpgtHVneEu;

			public IList<ActionElementMap> YMRPVTiZQjJqMhEgNcuObCnEQJP;

			public int xDaUBHybCZJimulyOXczBlwdUSf;

			public int NnVnTirNiFBrQCNUtXBubulDwFxl;

			public ActionElementMap gVoSUwIqhCNEEdEmEQwcKPgSEPl;

			public int wlsOpNbGemAMNzlOddjGWIekWfu;

			public ActionElementMap iZQWitOMKPGVUhxDvBVhmHuMCfz;

			ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return ubyTdixGSFKGaFQFZdQnpwgWIvJ;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return ubyTdixGSFKGaFQFZdQnpwgWIvJ;
				}
			}

			[DebuggerHidden]
			IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
			{
				XDIzbraqsYelFFnVnyzwdPQTrhEw xDIzbraqsYelFFnVnyzwdPQTrhEw;
				if (Thread.CurrentThread.ManagedThreadId == TFdbdCIUKXTQPHFlNuiMVnWNXiVT && isaqVUvqwfWYqOUtovbpbCbxgPc == -2)
				{
					isaqVUvqwfWYqOUtovbpbCbxgPc = 0;
					xDIzbraqsYelFFnVnyzwdPQTrhEw = this;
					goto IL_0025;
				}
				goto IL_0062;
				IL_002a:
				int num;
				while (true)
				{
					switch (num ^ 0x17A048F8)
					{
					case 3:
						break;
					case 4:
						xDIzbraqsYelFFnVnyzwdPQTrhEw.syCPfFbHYMDOvEPjTnPLBqiOhsPv = syCPfFbHYMDOvEPjTnPLBqiOhsPv;
						num = 396380408;
						continue;
					case 5:
						goto IL_0062;
					case 1:
						num = 396380408;
						continue;
					case 0:
						xDIzbraqsYelFFnVnyzwdPQTrhEw.PVhoJNjtQFhTjmwRsuJhvQWcbfU = IoOMsTyRkHoaIqFFqOwszJSmHpc;
						xDIzbraqsYelFFnVnyzwdPQTrhEw.gDMrNwHmEkVTACgeEefdCmJdpir = dGwSNihzjCwVEkHXFGPpgtHVneEu;
						num = 396380410;
						continue;
					default:
						return xDIzbraqsYelFFnVnyzwdPQTrhEw;
					}
					break;
				}
				goto IL_0025;
				IL_0062:
				xDIzbraqsYelFFnVnyzwdPQTrhEw = new XDIzbraqsYelFFnVnyzwdPQTrhEw(0);
				num = 396380412;
				goto IL_002a;
				IL_0025:
				num = 396380409;
				goto IL_002a;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				int num;
				switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
				{
				case 0:
				{
					isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
					int num2;
					if (ReInput._id != syCPfFbHYMDOvEPjTnPLBqiOhsPv.vuPDNwATQFuTZgAqTRoviXUGAgFM)
					{
						num = 1522662360;
						num2 = num;
					}
					else
					{
						num = 1522662367;
						num2 = num;
					}
					goto IL_001f;
				}
				case 1:
					{
						isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
						num = 1522662357;
						goto IL_001f;
					}
					IL_001f:
					while (true)
					{
						switch (num ^ 0x5AC1FBD6)
						{
						case 18:
							num = 1522662354;
							continue;
						case 4:
							break;
						case 11:
							return true;
						case 0:
							goto IL_00bb;
						case 16:
							ubyTdixGSFKGaFQFZdQnpwgWIvJ = new ElementAssignmentConflictInfo(isConflict: true, ReInput.mapping.GetMapCategory(syCPfFbHYMDOvEPjTnPLBqiOhsPv._categoryId).userAssignable, -1, syCPfFbHYMDOvEPjTnPLBqiOhsPv._controllerType, syCPfFbHYMDOvEPjTnPLBqiOhsPv._controllerId, syCPfFbHYMDOvEPjTnPLBqiOhsPv._id, gVoSUwIqhCNEEdEmEQwcKPgSEPl.tqPurZpByiUWRrPJKwHxxaZZua, gVoSUwIqhCNEEdEmEQwcKPgSEPl._actionId, gVoSUwIqhCNEEdEmEQwcKPgSEPl._elementType, gVoSUwIqhCNEEdEmEQwcKPgSEPl._elementIdentifierId, gVoSUwIqhCNEEdEmEQwcKPgSEPl.keyCode, gVoSUwIqhCNEEdEmEQwcKPgSEPl.modifierKeyFlags);
							isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
							num = 1522662365;
							continue;
						case 2:
							gVoSUwIqhCNEEdEmEQwcKPgSEPl = syCPfFbHYMDOvEPjTnPLBqiOhsPv.wIadyhEVxiJaWeDEsznpytUcfFE[NnVnTirNiFBrQCNUtXBubulDwFxl];
							if (gDMrNwHmEkVTACgeEefdCmJdpir)
							{
								goto IL_01b0;
							}
							goto case 7;
						case 5:
							goto IL_01d1;
						case 6:
							goto IL_01f2;
						case 1:
							YMRPVTiZQjJqMhEgNcuObCnEQJP = PVhoJNjtQFhTjmwRsuJhvQWcbfU.ButtonMaps;
							if (YMRPVTiZQjJqMhEgNcuObCnEQJP != null)
							{
								xDaUBHybCZJimulyOXczBlwdUSf = YMRPVTiZQjJqMhEgNcuObCnEQJP.Count;
								NnVnTirNiFBrQCNUtXBubulDwFxl = 0;
								num = 1522662366;
								continue;
							}
							goto end_IL_0008;
						case 17:
							NnVnTirNiFBrQCNUtXBubulDwFxl++;
							num = 1522662366;
							continue;
						case 14:
							ReInput.CheckInitialized(syCPfFbHYMDOvEPjTnPLBqiOhsPv.vuPDNwATQFuTZgAqTRoviXUGAgFM);
							num = 1522662362;
							continue;
						case 15:
							goto IL_028a;
						case 8:
							goto IL_02ab;
						case 9:
							goto IL_02d7;
						case 7:
							wlsOpNbGemAMNzlOddjGWIekWfu = 0;
							num = 1522662364;
							continue;
						case 10:
							goto IL_031f;
						case 13:
							goto IL_0341;
						case 3:
							wlsOpNbGemAMNzlOddjGWIekWfu++;
							num = 1522662364;
							continue;
						default:
							goto end_IL_0008;
						}
						break;
						IL_0341:
						int num3;
						if (!syCPfFbHYMDOvEPjTnPLBqiOhsPv._enabled)
						{
							num = 1522662362;
							num3 = num;
						}
						else
						{
							num = 1522662361;
							num3 = num;
						}
						continue;
						IL_02ab:
						int num4;
						if (NnVnTirNiFBrQCNUtXBubulDwFxl < syCPfFbHYMDOvEPjTnPLBqiOhsPv.wIadyhEVxiJaWeDEsznpytUcfFE.Count)
						{
							num = 1522662356;
							num4 = num;
						}
						else
						{
							num = 1522662362;
							num4 = num;
						}
						continue;
						IL_01f2:
						int num5;
						if (gVoSUwIqhCNEEdEmEQwcKPgSEPl.CheckForAssignmentConflict(iZQWitOMKPGVUhxDvBVhmHuMCfz))
						{
							num = 1522662342;
							num5 = num;
						}
						else
						{
							num = 1522662357;
							num5 = num;
						}
						continue;
						IL_031f:
						int num6;
						if (wlsOpNbGemAMNzlOddjGWIekWfu < xDaUBHybCZJimulyOXczBlwdUSf)
						{
							num = 1522662358;
							num6 = num;
						}
						else
						{
							num = 1522662343;
							num6 = num;
						}
						continue;
						IL_01d1:
						int num7;
						if (!iZQWitOMKPGVUhxDvBVhmHuMCfz.FnzJwrQpikWfZbmfjZhFwutJGAA)
						{
							num = 1522662357;
							num7 = num;
						}
						else
						{
							num = 1522662352;
							num7 = num;
						}
						continue;
						IL_028a:
						int num8;
						if (!PVhoJNjtQFhTjmwRsuJhvQWcbfU._enabled)
						{
							num = 1522662362;
							num8 = num;
						}
						else
						{
							num = 1522662359;
							num8 = num;
						}
						continue;
						IL_02d7:
						if (PVhoJNjtQFhTjmwRsuJhvQWcbfU == null || syCPfFbHYMDOvEPjTnPLBqiOhsPv.wIadyhEVxiJaWeDEsznpytUcfFE == null)
						{
							goto end_IL_0008;
						}
						int num9;
						if (!gDMrNwHmEkVTACgeEefdCmJdpir)
						{
							num = 1522662359;
							num9 = num;
						}
						else
						{
							num = 1522662363;
							num9 = num;
						}
						continue;
						IL_01b0:
						int num10;
						if (gVoSUwIqhCNEEdEmEQwcKPgSEPl.FnzJwrQpikWfZbmfjZhFwutJGAA)
						{
							num = 1522662353;
							num10 = num;
						}
						else
						{
							num = 1522662343;
							num10 = num;
						}
						continue;
						IL_00bb:
						iZQWitOMKPGVUhxDvBVhmHuMCfz = YMRPVTiZQjJqMhEgNcuObCnEQJP[wlsOpNbGemAMNzlOddjGWIekWfu];
						int num11;
						if (gDMrNwHmEkVTACgeEefdCmJdpir)
						{
							num = 1522662355;
							num11 = num;
						}
						else
						{
							num = 1522662352;
							num11 = num;
						}
					}
					goto case 0;
					end_IL_0008:
					break;
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
			public XDIzbraqsYelFFnVnyzwdPQTrhEw(int _003C_003E1__state)
			{
				isaqVUvqwfWYqOUtovbpbCbxgPc = _003C_003E1__state;
				TFdbdCIUKXTQPHFlNuiMVnWNXiVT = Thread.CurrentThread.ManagedThreadId;
			}
		}

		private sealed class mwOGpRjlpahWeicVVcgBfcoGVUzu : IDisposable, IEnumerator, IEnumerable, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
		{
			private ElementAssignmentConflictInfo ubyTdixGSFKGaFQFZdQnpwgWIvJ;

			private int isaqVUvqwfWYqOUtovbpbCbxgPc;

			private int TFdbdCIUKXTQPHFlNuiMVnWNXiVT;

			public ControllerMap syCPfFbHYMDOvEPjTnPLBqiOhsPv;

			public ActionElementMap fGOEgVenBQpynjDLaZtrcIyVGYbg;

			public ActionElementMap MHovrJIJgVIzkhRuYJVtkcLlDWhe;

			public bool gDMrNwHmEkVTACgeEefdCmJdpir;

			public bool dGwSNihzjCwVEkHXFGPpgtHVneEu;

			public int rTDbHTELPCkoKaadDcPNwKORIEae;

			public ActionElementMap GMLaUhCrWcOrXzmNWMVbNcTdNTc;

			ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return ubyTdixGSFKGaFQFZdQnpwgWIvJ;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return ubyTdixGSFKGaFQFZdQnpwgWIvJ;
				}
			}

			[DebuggerHidden]
			IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
			{
				if (Thread.CurrentThread.ManagedThreadId == TFdbdCIUKXTQPHFlNuiMVnWNXiVT && isaqVUvqwfWYqOUtovbpbCbxgPc == -2)
				{
					isaqVUvqwfWYqOUtovbpbCbxgPc = 0;
					goto IL_0023;
				}
				goto IL_0061;
				IL_0028:
				int num;
				mwOGpRjlpahWeicVVcgBfcoGVUzu mwOGpRjlpahWeicVVcgBfcoGVUzu2 = default(mwOGpRjlpahWeicVVcgBfcoGVUzu);
				while (true)
				{
					switch (num ^ -875045279)
					{
					case 2:
						break;
					case 4:
						mwOGpRjlpahWeicVVcgBfcoGVUzu2 = this;
						num = -875045273;
						continue;
					case 6:
						num = -875045279;
						continue;
					case 1:
						goto IL_0061;
					case 0:
						mwOGpRjlpahWeicVVcgBfcoGVUzu2.fGOEgVenBQpynjDLaZtrcIyVGYbg = MHovrJIJgVIzkhRuYJVtkcLlDWhe;
						mwOGpRjlpahWeicVVcgBfcoGVUzu2.gDMrNwHmEkVTACgeEefdCmJdpir = dGwSNihzjCwVEkHXFGPpgtHVneEu;
						num = -875045276;
						continue;
					case 3:
						mwOGpRjlpahWeicVVcgBfcoGVUzu2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = syCPfFbHYMDOvEPjTnPLBqiOhsPv;
						num = -875045279;
						continue;
					default:
						return mwOGpRjlpahWeicVVcgBfcoGVUzu2;
					}
					break;
				}
				goto IL_0023;
				IL_0061:
				mwOGpRjlpahWeicVVcgBfcoGVUzu2 = new mwOGpRjlpahWeicVVcgBfcoGVUzu(0);
				num = -875045278;
				goto IL_0028;
				IL_0023:
				num = -875045275;
				goto IL_0028;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				int num;
				switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
				{
				case 0:
					isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
					num = -1589950026;
					goto IL_001f;
				case 1:
					{
						isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
						num = -1589950023;
						goto IL_001f;
					}
					IL_001f:
					while (true)
					{
						switch (num ^ -1589950017)
						{
						case 0:
							num = -1589950028;
							continue;
						case 11:
							break;
						case 8:
							goto IL_0075;
						case 4:
							num = -1589950029;
							continue;
						case 1:
							num = -1589950024;
							continue;
						case 7:
							goto IL_00a4;
						case 13:
							rTDbHTELPCkoKaadDcPNwKORIEae = 0;
							num = -1589950018;
							continue;
						case 2:
							ReInput.CheckInitialized(syCPfFbHYMDOvEPjTnPLBqiOhsPv.vuPDNwATQFuTZgAqTRoviXUGAgFM);
							num = -1589950021;
							continue;
						case 9:
							goto IL_00fc;
						case 6:
							rTDbHTELPCkoKaadDcPNwKORIEae++;
							num = -1589950024;
							continue;
						case 10:
							if (GMLaUhCrWcOrXzmNWMVbNcTdNTc.CheckForAssignmentConflict(fGOEgVenBQpynjDLaZtrcIyVGYbg))
							{
								ubyTdixGSFKGaFQFZdQnpwgWIvJ = new ElementAssignmentConflictInfo(isConflict: true, ReInput.mapping.GetMapCategory(syCPfFbHYMDOvEPjTnPLBqiOhsPv._categoryId).userAssignable, -1, syCPfFbHYMDOvEPjTnPLBqiOhsPv._controllerType, syCPfFbHYMDOvEPjTnPLBqiOhsPv._controllerId, syCPfFbHYMDOvEPjTnPLBqiOhsPv._id, GMLaUhCrWcOrXzmNWMVbNcTdNTc.tqPurZpByiUWRrPJKwHxxaZZua, GMLaUhCrWcOrXzmNWMVbNcTdNTc._actionId, GMLaUhCrWcOrXzmNWMVbNcTdNTc._elementType, GMLaUhCrWcOrXzmNWMVbNcTdNTc._elementIdentifierId, GMLaUhCrWcOrXzmNWMVbNcTdNTc.keyCode, GMLaUhCrWcOrXzmNWMVbNcTdNTc.modifierKeyFlags);
								isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
								return true;
							}
							goto case 6;
						case 3:
							if (fGOEgVenBQpynjDLaZtrcIyVGYbg == null || syCPfFbHYMDOvEPjTnPLBqiOhsPv.wIadyhEVxiJaWeDEsznpytUcfFE == null)
							{
								goto end_IL_0008;
							}
							if (!gDMrNwHmEkVTACgeEefdCmJdpir)
							{
								goto case 13;
							}
							goto IL_0211;
						case 5:
							goto IL_023f;
						default:
							goto end_IL_0008;
						}
						break;
						IL_023f:
						GMLaUhCrWcOrXzmNWMVbNcTdNTc = syCPfFbHYMDOvEPjTnPLBqiOhsPv.wIadyhEVxiJaWeDEsznpytUcfFE[rTDbHTELPCkoKaadDcPNwKORIEae];
						int num2;
						if (gDMrNwHmEkVTACgeEefdCmJdpir)
						{
							num = -1589950025;
							num2 = num;
						}
						else
						{
							num = -1589950027;
							num2 = num;
						}
						continue;
						IL_00a4:
						int num3;
						if (rTDbHTELPCkoKaadDcPNwKORIEae < syCPfFbHYMDOvEPjTnPLBqiOhsPv.wIadyhEVxiJaWeDEsznpytUcfFE.Count)
						{
							num = -1589950022;
							num3 = num;
						}
						else
						{
							num = -1589950029;
							num3 = num;
						}
						continue;
						IL_0075:
						int num4;
						if (!GMLaUhCrWcOrXzmNWMVbNcTdNTc.FnzJwrQpikWfZbmfjZhFwutJGAA)
						{
							num = -1589950023;
							num4 = num;
						}
						else
						{
							num = -1589950027;
							num4 = num;
						}
						continue;
						IL_0211:
						if (!syCPfFbHYMDOvEPjTnPLBqiOhsPv._enabled)
						{
							goto end_IL_0008;
						}
						int num5;
						if (!fGOEgVenBQpynjDLaZtrcIyVGYbg.FnzJwrQpikWfZbmfjZhFwutJGAA)
						{
							num = -1589950029;
							num5 = num;
						}
						else
						{
							num = -1589950030;
							num5 = num;
						}
						continue;
						IL_00fc:
						int num6;
						if (ReInput._id != syCPfFbHYMDOvEPjTnPLBqiOhsPv.vuPDNwATQFuTZgAqTRoviXUGAgFM)
						{
							num = -1589950019;
							num6 = num;
						}
						else
						{
							num = -1589950020;
							num6 = num;
						}
					}
					goto case 0;
					end_IL_0008:
					break;
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
			public mwOGpRjlpahWeicVVcgBfcoGVUzu(int _003C_003E1__state)
			{
				isaqVUvqwfWYqOUtovbpbCbxgPc = _003C_003E1__state;
				TFdbdCIUKXTQPHFlNuiMVnWNXiVT = Thread.CurrentThread.ManagedThreadId;
			}
		}

		private sealed class lEAmGyBdDVvVCyOCPzlMvcTjQOp : IDisposable, IEnumerator, IEnumerable, IEnumerable<ElementAssignmentConflictInfo>, IEnumerator<ElementAssignmentConflictInfo>
		{
			private ElementAssignmentConflictInfo ubyTdixGSFKGaFQFZdQnpwgWIvJ;

			private int isaqVUvqwfWYqOUtovbpbCbxgPc;

			private int TFdbdCIUKXTQPHFlNuiMVnWNXiVT;

			public ControllerMap syCPfFbHYMDOvEPjTnPLBqiOhsPv;

			public ElementAssignmentConflictCheck qmArylEXVEJqtrWPrThLlZZjSRU;

			public ElementAssignmentConflictCheck xMLCmAAGOtcBvnIylDFdJWNwMnF;

			public bool gDMrNwHmEkVTACgeEefdCmJdpir;

			public bool dGwSNihzjCwVEkHXFGPpgtHVneEu;

			public ElementAssignment fuRRCFoVGxdXuspQulgUhNGElmL;

			public int WmAmXmKVqomGdZswAeJDVPzWAvq;

			public ActionElementMap KbIFIjHtkxGHNnhiMmyvtfgUoZj;

			ElementAssignmentConflictInfo IEnumerator<ElementAssignmentConflictInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return ubyTdixGSFKGaFQFZdQnpwgWIvJ;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return ubyTdixGSFKGaFQFZdQnpwgWIvJ;
				}
			}

			[DebuggerHidden]
			IEnumerator<ElementAssignmentConflictInfo> IEnumerable<ElementAssignmentConflictInfo>.GetEnumerator()
			{
				lEAmGyBdDVvVCyOCPzlMvcTjQOp lEAmGyBdDVvVCyOCPzlMvcTjQOp2;
				if (Thread.CurrentThread.ManagedThreadId == TFdbdCIUKXTQPHFlNuiMVnWNXiVT && isaqVUvqwfWYqOUtovbpbCbxgPc == -2)
				{
					isaqVUvqwfWYqOUtovbpbCbxgPc = 0;
					lEAmGyBdDVvVCyOCPzlMvcTjQOp2 = this;
					goto IL_0025;
				}
				goto IL_004e;
				IL_002a:
				int num;
				while (true)
				{
					switch (num ^ 0x5A0AA814)
					{
					case 2:
						break;
					case 1:
						num = 1510647831;
						continue;
					case 0:
						goto IL_004e;
					default:
						lEAmGyBdDVvVCyOCPzlMvcTjQOp2.qmArylEXVEJqtrWPrThLlZZjSRU = xMLCmAAGOtcBvnIylDFdJWNwMnF;
						lEAmGyBdDVvVCyOCPzlMvcTjQOp2.gDMrNwHmEkVTACgeEefdCmJdpir = dGwSNihzjCwVEkHXFGPpgtHVneEu;
						return lEAmGyBdDVvVCyOCPzlMvcTjQOp2;
					}
					break;
				}
				goto IL_0025;
				IL_004e:
				lEAmGyBdDVvVCyOCPzlMvcTjQOp2 = new lEAmGyBdDVvVCyOCPzlMvcTjQOp(0);
				lEAmGyBdDVvVCyOCPzlMvcTjQOp2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = syCPfFbHYMDOvEPjTnPLBqiOhsPv;
				num = 1510647831;
				goto IL_002a;
				IL_0025:
				num = 1510647829;
				goto IL_002a;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ElementAssignmentConflictInfo>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				int num = isaqVUvqwfWYqOUtovbpbCbxgPc;
				while (true)
				{
					int num2 = -420507650;
					while (true)
					{
						switch (num2 ^ -420507660)
						{
						case 9:
							break;
						case 3:
							if (gDMrNwHmEkVTACgeEefdCmJdpir)
							{
								int num6;
								if (!syCPfFbHYMDOvEPjTnPLBqiOhsPv._enabled)
								{
									num2 = -420507658;
									num6 = num2;
								}
								else
								{
									num2 = -420507664;
									num6 = num2;
								}
								continue;
							}
							goto case 4;
						case 7:
							isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
							if (ReInput._id != syCPfFbHYMDOvEPjTnPLBqiOhsPv.vuPDNwATQFuTZgAqTRoviXUGAgFM)
							{
								ReInput.CheckInitialized(syCPfFbHYMDOvEPjTnPLBqiOhsPv.vuPDNwATQFuTZgAqTRoviXUGAgFM);
								num2 = -420507655;
								continue;
							}
							goto case 3;
						case 5:
						{
							KbIFIjHtkxGHNnhiMmyvtfgUoZj = syCPfFbHYMDOvEPjTnPLBqiOhsPv.wIadyhEVxiJaWeDEsznpytUcfFE[WmAmXmKVqomGdZswAeJDVPzWAvq];
							int num5;
							if (!gDMrNwHmEkVTACgeEefdCmJdpir)
							{
								num2 = -420507659;
								num5 = num2;
							}
							else
							{
								num2 = -420507660;
								num5 = num2;
							}
							continue;
						}
						case 8:
							WmAmXmKVqomGdZswAeJDVPzWAvq++;
							num2 = -420507656;
							continue;
						case 12:
						{
							int num7;
							if (WmAmXmKVqomGdZswAeJDVPzWAvq >= syCPfFbHYMDOvEPjTnPLBqiOhsPv.wIadyhEVxiJaWeDEsznpytUcfFE.Count)
							{
								num2 = -420507658;
								num7 = num2;
							}
							else
							{
								num2 = -420507663;
								num7 = num2;
							}
							continue;
						}
						case 1:
							if (KbIFIjHtkxGHNnhiMmyvtfgUoZj.tqPurZpByiUWRrPJKwHxxaZZua != qmArylEXVEJqtrWPrThLlZZjSRU.elementMapId)
							{
								int num4;
								if (KbIFIjHtkxGHNnhiMmyvtfgUoZj.CheckForAssignmentConflict(fuRRCFoVGxdXuspQulgUhNGElmL))
								{
									num2 = -420507662;
									num4 = num2;
								}
								else
								{
									num2 = -420507652;
									num4 = num2;
								}
								continue;
							}
							goto case 8;
						case 10:
							switch (num)
							{
							case 0:
								break;
							default:
								num2 = -420507658;
								continue;
							case 1:
								isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
								num2 = -420507652;
								continue;
							}
							goto case 7;
						case 11:
							isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
							return true;
						case 0:
						{
							int num3;
							if (KbIFIjHtkxGHNnhiMmyvtfgUoZj.FnzJwrQpikWfZbmfjZhFwutJGAA)
							{
								num2 = -420507659;
								num3 = num2;
							}
							else
							{
								num2 = -420507652;
								num3 = num2;
							}
							continue;
						}
						case 6:
							ubyTdixGSFKGaFQFZdQnpwgWIvJ = new ElementAssignmentConflictInfo(isConflict: true, ReInput.mapping.GetMapCategory(syCPfFbHYMDOvEPjTnPLBqiOhsPv._categoryId).userAssignable, -1, syCPfFbHYMDOvEPjTnPLBqiOhsPv._controllerType, syCPfFbHYMDOvEPjTnPLBqiOhsPv._controllerId, syCPfFbHYMDOvEPjTnPLBqiOhsPv._id, KbIFIjHtkxGHNnhiMmyvtfgUoZj.tqPurZpByiUWRrPJKwHxxaZZua, KbIFIjHtkxGHNnhiMmyvtfgUoZj._actionId, KbIFIjHtkxGHNnhiMmyvtfgUoZj._elementType, KbIFIjHtkxGHNnhiMmyvtfgUoZj._elementIdentifierId, KbIFIjHtkxGHNnhiMmyvtfgUoZj.keyCode, KbIFIjHtkxGHNnhiMmyvtfgUoZj.modifierKeyFlags);
							num2 = -420507649;
							continue;
						case 13:
							num2 = -420507658;
							continue;
						case 4:
							if (syCPfFbHYMDOvEPjTnPLBqiOhsPv.wIadyhEVxiJaWeDEsznpytUcfFE != null)
							{
								fuRRCFoVGxdXuspQulgUhNGElmL = qmArylEXVEJqtrWPrThLlZZjSRU.ToElementAssignment();
								WmAmXmKVqomGdZswAeJDVPzWAvq = 0;
								num2 = -420507656;
								continue;
							}
							goto default;
						default:
							return false;
						}
						break;
					}
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
			}

			[DebuggerHidden]
			public lEAmGyBdDVvVCyOCPzlMvcTjQOp(int _003C_003E1__state)
			{
				isaqVUvqwfWYqOUtovbpbCbxgPc = _003C_003E1__state;
				TFdbdCIUKXTQPHFlNuiMVnWNXiVT = Thread.CurrentThread.ManagedThreadId;
			}
		}

		protected int _id;

		protected int _sourceMapId;

		protected int _categoryId;

		protected int _layoutId;

		protected string _name;

		protected Guid _hardwareGuid;

		protected bool _enabled;

		internal readonly int vuPDNwATQFuTZgAqTRoviXUGAgFM;

		private readonly AList<ActionElementMap> wIadyhEVxiJaWeDEsznpytUcfFE;

		private readonly ReadOnlyCollection<ActionElementMap> oQZupiRGwwmcfeBykPGIBOrZUnd;

		private readonly AList<ActionElementMap> ZYwIXqAucYgKRZdCmuiIHmWLQlA;

		private readonly ReadOnlyCollection<ActionElementMap> PFewvWxvZFDMgJwjBBBRfKEvUDe;

		protected int _playerId;

		protected int _controllerId;

		protected ControllerType _controllerType;

		private static int yaBkMAQfYXPgUDRJlmRDPEwrgbOa;

		private static int nextUid
		{
			get
			{
				int result = yaBkMAQfYXPgUDRJlmRDPEwrgbOa;
				while (true)
				{
					int num = -2037412152;
					while (true)
					{
						switch (num ^ -2037412151)
						{
						case 0:
							break;
						case 1:
							if (yaBkMAQfYXPgUDRJlmRDPEwrgbOa == int.MaxValue)
							{
								yaBkMAQfYXPgUDRJlmRDPEwrgbOa = 0;
								num = -2037412147;
								continue;
							}
							goto case 3;
						case 3:
							yaBkMAQfYXPgUDRJlmRDPEwrgbOa++;
							num = -2037412149;
							continue;
						case 4:
							num = -2037412149;
							continue;
						default:
							return result;
						}
						break;
					}
				}
			}
		}

		public int id
		{
			get
			{
				if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
				{
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
					return -1;
				}
				return _id;
			}
		}

		public int sourceMapId
		{
			get
			{
				if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
				{
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
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
				if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
				{
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
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
				if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
				{
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
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
				if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
				{
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
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
				if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
				{
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
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
				if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
				{
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
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
				if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
				{
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
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
				if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
				{
					while (true)
					{
						int num = -1956301494;
						while (true)
						{
							switch (num ^ -1956301496)
							{
							case 0:
								break;
							case 2:
								goto IL_002b;
							default:
								return -1;
							}
							break;
							IL_002b:
							ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
							num = -1956301495;
						}
					}
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
				if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
				{
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
					return null;
				}
				return ReInput.controllers.GetController(_controllerType, _controllerId);
			}
		}

		public ControllerType controllerType
		{
			get
			{
				if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
				{
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
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
				if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
				{
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
					return null;
				}
				return ReInput.players.GetPlayer(_playerId);
			}
		}

		public int elementMapCount
		{
			get
			{
				if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
				{
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
					return 0;
				}
				return ZYwIXqAucYgKRZdCmuiIHmWLQlA.Count;
			}
		}

		public int buttonMapCount
		{
			get
			{
				if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
				{
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
					return 0;
				}
				return wIadyhEVxiJaWeDEsznpytUcfFE.Count;
			}
		}

		public IList<ActionElementMap> AllMaps
		{
			get
			{
				if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
				{
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
					return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
				}
				return PFewvWxvZFDMgJwjBBBRfKEvUDe;
			}
		}

		public IList<ActionElementMap> ButtonMaps
		{
			get
			{
				if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
				{
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
					return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
				}
				return oQZupiRGwwmcfeBykPGIBOrZUnd;
			}
		}

		internal AList<ActionElementMap> ButtonMaps_orig => wIadyhEVxiJaWeDEsznpytUcfFE;

		public ControllerMap()
		{
			_id = nextUid;
			_sourceMapId = -1;
			wIadyhEVxiJaWeDEsznpytUcfFE = new AList<ActionElementMap>();
			oQZupiRGwwmcfeBykPGIBOrZUnd = new ReadOnlyCollection<ActionElementMap>(wIadyhEVxiJaWeDEsznpytUcfFE);
			ZYwIXqAucYgKRZdCmuiIHmWLQlA = new AList<ActionElementMap>();
			PFewvWxvZFDMgJwjBBBRfKEvUDe = new ReadOnlyCollection<ActionElementMap>(ZYwIXqAucYgKRZdCmuiIHmWLQlA);
			vuPDNwATQFuTZgAqTRoviXUGAgFM = ReInput.id;
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
			if (source.wIadyhEVxiJaWeDEsznpytUcfFE != null)
			{
				int count = source.wIadyhEVxiJaWeDEsznpytUcfFE.Count;
				for (int i = 0; i < count; i++)
				{
					fTDEdaCTYLvKLWSpZIBomPPJaZdF(new ActionElementMap(source.wIadyhEVxiJaWeDEsznpytUcfFE[i]));
				}
			}
		}

		public bool ContainsAction(string actionName)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return false;
			}
			InputAction inputAction = ReInput.lUCgcEIquFfuykgBneGrfARQlcR.HPBabWgYCxuQFtaZlVdaNBbUOip(actionName, true);
			if (inputAction == null)
			{
				return false;
			}
			return ContainsAction(inputAction.id);
		}

		public virtual bool ContainsAction(int actionId)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return false;
			}
			if (actionId < 0)
			{
				return false;
			}
			int num = buttonMapCount;
			int num3 = default(int);
			while (true)
			{
				int num2 = 1565562647;
				while (true)
				{
					switch (num2 ^ 0x5D509714)
					{
					case 2:
						break;
					case 3:
						num3 = 0;
						num2 = 1565562645;
						continue;
					case 0:
						if (wIadyhEVxiJaWeDEsznpytUcfFE[num3]._actionId == actionId)
						{
							return true;
						}
						num3++;
						num2 = 1565562645;
						continue;
					default:
						if (num3 >= num)
						{
							return false;
						}
						goto case 0;
					}
					break;
				}
			}
		}

		public bool ContainsElementIdentifier(int elementIdentifierId)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return false;
			}
			AList<ActionElementMap> zYwIXqAucYgKRZdCmuiIHmWLQlA = ZYwIXqAucYgKRZdCmuiIHmWLQlA;
			int num = 0;
			while (num < zYwIXqAucYgKRZdCmuiIHmWLQlA.Count)
			{
				while (true)
				{
					if (ZYwIXqAucYgKRZdCmuiIHmWLQlA[num].elementIdentifierId == elementIdentifierId)
					{
						return true;
					}
					num++;
					int num2 = 561260718;
					while (true)
					{
						switch (num2 ^ 0x217428AC)
						{
						case 0:
							num2 = 561260717;
							continue;
						case 1:
							break;
						default:
							goto end_IL_0044;
						}
						break;
					}
					continue;
					end_IL_0044:
					break;
				}
			}
			return false;
		}

		public bool ContainsKeyboardKey(KeyCode keyCode, ModifierKeyFlags modifierKeys)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return false;
			}
			AList<ActionElementMap> zYwIXqAucYgKRZdCmuiIHmWLQlA = ZYwIXqAucYgKRZdCmuiIHmWLQlA;
			int num = 0;
			while (true)
			{
				int num2;
				int num3;
				if (num < zYwIXqAucYgKRZdCmuiIHmWLQlA.Count)
				{
					num2 = 1885755156;
					num3 = num2;
				}
				else
				{
					num2 = 1885755159;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ 0x70665715)
					{
					case 3:
						num2 = 1885755156;
						continue;
					case 1:
						if (ZYwIXqAucYgKRZdCmuiIHmWLQlA[num].keyCode == keyCode && ZYwIXqAucYgKRZdCmuiIHmWLQlA[num].modifierKeyFlags == modifierKeys)
						{
							return true;
						}
						num++;
						num2 = 1885755157;
						continue;
					case 0:
						break;
					default:
						return false;
					}
					break;
				}
			}
		}

		public bool ContainsElementMap(ActionElementMap elementMap)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return false;
			}
			if (elementMap == null)
			{
				return false;
			}
			AList<ActionElementMap> zYwIXqAucYgKRZdCmuiIHmWLQlA = ZYwIXqAucYgKRZdCmuiIHmWLQlA;
			int num = 0;
			while (num < zYwIXqAucYgKRZdCmuiIHmWLQlA.Count)
			{
				while (true)
				{
					if (ZYwIXqAucYgKRZdCmuiIHmWLQlA[num].tqPurZpByiUWRrPJKwHxxaZZua == elementMap.id)
					{
						return true;
					}
					num++;
					int num2 = -268921013;
					while (true)
					{
						switch (num2 ^ -268921015)
						{
						case 0:
							num2 = -268921016;
							continue;
						case 1:
							break;
						default:
							goto end_IL_0049;
						}
						break;
					}
					continue;
					end_IL_0049:
					break;
				}
			}
			return false;
		}

		public bool ContainsElementMap(int elementMapId)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return false;
			}
			AList<ActionElementMap> zYwIXqAucYgKRZdCmuiIHmWLQlA = ZYwIXqAucYgKRZdCmuiIHmWLQlA;
			int num = 0;
			while (true)
			{
				int num2 = 1921705028;
				while (true)
				{
					switch (num2 ^ 0x728AE446)
					{
					case 4:
						break;
					case 2:
						num2 = 1921705030;
						continue;
					case 3:
						if (ZYwIXqAucYgKRZdCmuiIHmWLQlA[num].tqPurZpByiUWRrPJKwHxxaZZua == elementMapId)
						{
							num2 = 1921705031;
							continue;
						}
						num++;
						num2 = 1921705030;
						continue;
					case 1:
						return true;
					default:
						if (num >= zYwIXqAucYgKRZdCmuiIHmWLQlA.Count)
						{
							return false;
						}
						goto case 3;
					}
					break;
				}
			}
		}

		public bool ReplaceOrCreateElementMap(ElementAssignment elementAssignment)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return false;
			}
			ActionElementMap result;
			return ReplaceOrCreateElementMap(elementAssignment, out result);
		}

		public bool ReplaceOrCreateElementMap(ElementAssignment elementAssignment, out ActionElementMap result)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				while (true)
				{
					int num = -695259629;
					while (true)
					{
						switch (num ^ -695259631)
						{
						case 0:
							break;
						case 2:
							goto IL_002b;
						default:
							result = null;
							return false;
						}
						break;
						IL_002b:
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						num = -695259632;
					}
				}
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
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return false;
			}
			ActionElementMap result;
			return CreateElementMap(elementAssignment, out result);
		}

		public bool CreateElementMap(ElementAssignment elementAssignment, out ActionElementMap result)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				result = null;
				return false;
			}
			if (_controllerType == ControllerType.Keyboard)
			{
				return CreateElementMap(elementAssignment.actionId, elementAssignment.axisContribution, elementAssignment.keyboardKey, elementAssignment.modifierKeyFlags, out result);
			}
			if (_controllerType != ControllerType.Joystick)
			{
				while (true)
				{
					int num = -2060732148;
					while (true)
					{
						switch (num ^ -2060732147)
						{
						case 2:
							break;
						case 1:
							goto IL_0071;
						default:
							goto end_IL_0053;
						}
						break;
						IL_0071:
						if (_controllerType == ControllerType.Mouse)
						{
							goto end_IL_0053;
						}
						if (_controllerType == ControllerType.Custom)
						{
							num = -2060732147;
							continue;
						}
						throw new NotImplementedException();
					}
					continue;
					end_IL_0053:
					break;
				}
			}
			return CreateElementMap(elementAssignment.actionId, elementAssignment.axisContribution, elementAssignment.elementIdentifierId, zRJHFfVYpYamSokTjXZVUKlCnAG.MuLiOAWIhTPZfOhvnDqSQEksgWmc(elementAssignment.type), elementAssignment.axisRange, elementAssignment.invert, out result);
		}

		public bool CreateElementMap(int actionId, Pole axisContribution, KeyCode keyCode, ModifierKey modifierKey1, ModifierKey modifierKey2, ModifierKey modifierKey3)
		{
			ActionElementMap result;
			return CreateElementMap(actionId, axisContribution, keyCode, modifierKey1, modifierKey2, modifierKey3, out result);
		}

		public bool CreateElementMap(int actionId, Pole axisContribution, KeyCode keyCode, ModifierKey modifierKey1, ModifierKey modifierKey2, ModifierKey modifierKey3, out ActionElementMap result)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				result = null;
				return false;
			}
			ActionElementMap actionElementMap = new ActionElementMap(actionId, ControllerElementType.Button, axisContribution, (KeyboardKeyCode)keyCode, modifierKey1, modifierKey2, modifierKey3);
			while (true)
			{
				int num = 1817289150;
				while (true)
				{
					switch (num ^ 0x6C51A1BD)
					{
					case 0:
						break;
					case 3:
						ReInput.controllers.Keyboard.kHBFOpXfsCHmoMIFXGRFYWyjgTV(this, actionElementMap);
						num = 1817289151;
						continue;
					case 2:
						fTDEdaCTYLvKLWSpZIBomPPJaZdF(actionElementMap);
						result = actionElementMap;
						num = 1817289148;
						continue;
					default:
						return true;
					}
					break;
				}
			}
		}

		public bool CreateElementMap(int actionId, Pole axisContribution, KeyCode keyCode, ModifierKeyFlags modifierKeyFlags)
		{
			ActionElementMap result;
			return CreateElementMap(actionId, axisContribution, keyCode, modifierKeyFlags, out result);
		}

		public bool CreateElementMap(int actionId, Pole axisContribution, KeyCode keyCode, ModifierKeyFlags modifierKeyFlags, out ActionElementMap result)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				result = null;
				return false;
			}
			DNrIuioFpNaTnwZgLwwkrsbcnGo dNrIuioFpNaTnwZgLwwkrsbcnGo = DNrIuioFpNaTnwZgLwwkrsbcnGo.nyieeJfdwFOPVNcNdshjrFlptsE(modifierKeyFlags);
			return CreateElementMap(actionId, axisContribution, keyCode, dNrIuioFpNaTnwZgLwwkrsbcnGo.DzyWReoVEVjkPPRTcIQrFppXvVZ, dNrIuioFpNaTnwZgLwwkrsbcnGo.oCOJeddqDlevYkDxZmzkezmKEfu, dNrIuioFpNaTnwZgLwwkrsbcnGo.MJsYUpMZfJSmNsxSZrkJzHcgopV, out result);
		}

		public bool CreateElementMap(int actionId, Pole axisContribution, int elementIdentifierId, ControllerElementType elementType, AxisRange axisRange, bool invert)
		{
			ActionElementMap result;
			return CreateElementMap(actionId, axisContribution, elementIdentifierId, elementType, axisRange, invert, out result);
		}

		public virtual bool CreateElementMap(int actionId, Pole axisContribution, int elementIdentifierId, ControllerElementType elementType, AxisRange axisRange, bool invert, out ActionElementMap result)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				result = null;
				goto IL_001d;
			}
			int num;
			ActionElementMap actionElementMap = default(ActionElementMap);
			if (!RbfCKlONOukDglmWLTrDfcpWjpr(elementType))
			{
				result = null;
				num = 194119673;
			}
			else
			{
				actionElementMap = new ActionElementMap(actionId, elementType, elementIdentifierId, axisContribution, axisRange);
				BakeElementMap(actionElementMap);
				fTDEdaCTYLvKLWSpZIBomPPJaZdF(actionElementMap);
				num = 194119674;
			}
			goto IL_0022;
			IL_001d:
			num = 194119675;
			goto IL_0022;
			IL_0022:
			switch (num ^ 0xB9207F8)
			{
			case 0:
				break;
			case 3:
				return false;
			case 1:
				return false;
			default:
				result = actionElementMap;
				return true;
			}
			goto IL_001d;
		}

		public bool ReplaceElementMap(ElementAssignment elementAssignment)
		{
			ActionElementMap result;
			return ReplaceElementMap(elementAssignment, out result);
		}

		public bool ReplaceElementMap(ElementAssignment elementAssignment, out ActionElementMap result)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				result = null;
				return false;
			}
			if (_controllerType == ControllerType.Keyboard)
			{
				return ReplaceElementMap(elementAssignment.elementMapId, elementAssignment.actionId, elementAssignment.axisContribution, elementAssignment.keyboardKey, elementAssignment.modifierKeyFlags, out result);
			}
			if (_controllerType != ControllerType.Joystick)
			{
				while (true)
				{
					int num = -734361455;
					while (true)
					{
						switch (num ^ -734361456)
						{
						case 0:
							break;
						case 1:
							goto IL_0078;
						default:
							goto end_IL_005a;
						}
						break;
						IL_0078:
						if (_controllerType == ControllerType.Mouse)
						{
							goto end_IL_005a;
						}
						if (_controllerType == ControllerType.Custom)
						{
							num = -734361454;
							continue;
						}
						throw new NotImplementedException();
					}
					continue;
					end_IL_005a:
					break;
				}
			}
			return ReplaceElementMap(elementAssignment.elementMapId, elementAssignment.actionId, elementAssignment.axisContribution, elementAssignment.elementIdentifierId, zRJHFfVYpYamSokTjXZVUKlCnAG.MuLiOAWIhTPZfOhvnDqSQEksgWmc(elementAssignment.type), elementAssignment.axisRange, elementAssignment.invert, out result);
		}

		public bool ReplaceElementMap(int elementMapId, int actionId, Pole axisContribution, KeyCode keyCode, ModifierKey modifierKey1, ModifierKey modifierKey2, ModifierKey modifierKey3)
		{
			ActionElementMap result;
			return ReplaceElementMap(elementMapId, actionId, axisContribution, keyCode, modifierKey1, modifierKey2, modifierKey3, out result);
		}

		public bool ReplaceElementMap(int elementMapId, int actionId, Pole axisContribution, KeyCode keyCode, ModifierKey modifierKey1, ModifierKey modifierKey2, ModifierKey modifierKey3, out ActionElementMap result)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				goto IL_001c;
			}
			ActionElementMap elementMap = GetElementMap(elementMapId);
			int num = default(int);
			int num2;
			if (elementMap != null)
			{
				num = IlopbsVZqaXKxFzedtchmLnQWik(elementMapId);
				num2 = 1786437673;
			}
			else
			{
				result = null;
				num2 = 1786437672;
			}
			goto IL_0021;
			IL_001c:
			num2 = 1786437675;
			goto IL_0021;
			IL_0021:
			while (true)
			{
				switch (num2 ^ 0x6A7AE028)
				{
				case 7:
					break;
				case 6:
					result = null;
					return false;
				case 0:
					return false;
				case 9:
					elementMap._modifierKey1 = modifierKey1;
					num2 = 1786437664;
					continue;
				case 4:
					if (num >= 0)
					{
						elementMap.tAgADqjTsMUxSqYXeDyJIdETYRAp();
						elementMap._actionId = actionId;
						elementMap._elementType = ControllerElementType.Button;
						elementMap._axisContribution = axisContribution;
						num2 = 1786437677;
					}
					else
					{
						num2 = 1786437678;
					}
					continue;
				case 3:
					result = null;
					return false;
				case 1:
					if (num < 0)
					{
						DeleteElementMap(elementMapId);
						elementMap._elementType = ControllerElementType.Button;
						fTDEdaCTYLvKLWSpZIBomPPJaZdF(elementMap);
						num2 = 1786437674;
						continue;
					}
					goto case 2;
				case 2:
					num = IlopbsVZqaXKxFzedtchmLnQWik(elementMapId);
					num2 = 1786437676;
					continue;
				case 5:
					elementMap._keyboardKeyCode = (KeyboardKeyCode)keyCode;
					num2 = 1786437665;
					continue;
				default:
					elementMap._modifierKey2 = modifierKey2;
					elementMap._modifierKey3 = modifierKey3;
					ReInput.controllers.Keyboard.kHBFOpXfsCHmoMIFXGRFYWyjgTV(this, elementMap);
					result = elementMap;
					return true;
				}
				break;
			}
			goto IL_001c;
		}

		public bool ReplaceElementMap(int elementMapId, int actionId, Pole axisContribution, KeyCode keyCode, ModifierKeyFlags modifierKeyFlags)
		{
			ActionElementMap result;
			return ReplaceElementMap(elementMapId, actionId, axisContribution, keyCode, modifierKeyFlags, out result);
		}

		public bool ReplaceElementMap(int elementMapId, int actionId, Pole axisContribution, KeyCode keyCode, ModifierKeyFlags modifierKeyFlags, out ActionElementMap result)
		{
			DNrIuioFpNaTnwZgLwwkrsbcnGo dNrIuioFpNaTnwZgLwwkrsbcnGo = DNrIuioFpNaTnwZgLwwkrsbcnGo.nyieeJfdwFOPVNcNdshjrFlptsE(modifierKeyFlags);
			return ReplaceElementMap(elementMapId, actionId, axisContribution, keyCode, dNrIuioFpNaTnwZgLwwkrsbcnGo.DzyWReoVEVjkPPRTcIQrFppXvVZ, dNrIuioFpNaTnwZgLwwkrsbcnGo.oCOJeddqDlevYkDxZmzkezmKEfu, dNrIuioFpNaTnwZgLwwkrsbcnGo.MJsYUpMZfJSmNsxSZrkJzHcgopV, out result);
		}

		public bool ReplaceElementMap(int elementMapId, int actionId, Pole axisContribution, int elementIdentifierId, ControllerElementType elementType, AxisRange axisRange, bool invert)
		{
			ActionElementMap result;
			return ReplaceElementMap(elementMapId, actionId, axisContribution, elementIdentifierId, elementType, axisRange, invert, out result);
		}

		public virtual bool ReplaceElementMap(int elementMapId, int actionId, Pole axisContribution, int elementIdentifierId, ControllerElementType elementType, AxisRange axisRange, bool invert, out ActionElementMap result)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				result = null;
				goto IL_001d;
			}
			if (!RbfCKlONOukDglmWLTrDfcpWjpr(elementType))
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
			int num;
			if (!RbfCKlONOukDglmWLTrDfcpWjpr(elementMap._elementType))
			{
				DeleteElementMap(elementMapId);
				elementMap._elementType = ControllerElementType.Button;
				fTDEdaCTYLvKLWSpZIBomPPJaZdF(elementMap);
				num = 1567906783;
				goto IL_0022;
			}
			goto IL_00d7;
			IL_001d:
			num = 1567906780;
			goto IL_0022;
			IL_00d7:
			int num2 = IlopbsVZqaXKxFzedtchmLnQWik(elementMapId);
			if (num2 >= 0)
			{
				rOgFOJVTTNFABJrcUCYRlvoNiwWG(elementMap, actionId, axisContribution, elementIdentifierId, elementType, axisRange, invert);
				num = 1567906781;
			}
			else
			{
				num = 1567906782;
			}
			goto IL_0022;
			IL_0022:
			while (true)
			{
				switch (num ^ 0x5D745BDE)
				{
				case 6:
					break;
				case 2:
					return false;
				case 4:
					return false;
				case 3:
					BakeElementMap(elementMap);
					num = 1567906779;
					continue;
				case 0:
					result = null;
					num = 1567906778;
					continue;
				case 1:
					goto IL_00d7;
				default:
					result = elementMap;
					return true;
				}
				break;
			}
			goto IL_001d;
		}

		public virtual bool DeleteElementMap(int elementMapId)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				goto IL_000d;
			}
			int num = IlopbsVZqaXKxFzedtchmLnQWik(elementMapId);
			int num2;
			if (num < 0)
			{
				num2 = 2103327748;
				goto IL_0012;
			}
			QIfwVXGJCVNYMvqEWdTbgGcJiJX(elementMapId, num);
			return true;
			IL_000d:
			num2 = 2103327751;
			goto IL_0012;
			IL_0012:
			switch (num2 ^ 0x7D5E3C06)
			{
			case 0:
				break;
			case 1:
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return false;
			default:
				return false;
			}
			goto IL_000d;
		}

		public virtual bool DeleteElementMapsWithAction(string actionName)
		{
			return DeleteElementMapsWithAction(ReInput.lUCgcEIquFfuykgBneGrfARQlcR.QRDvUGxTmzMESLVLwskMiVyiVse(actionName));
		}

		public virtual bool DeleteElementMapsWithAction(int actionId)
		{
			return DeleteButtonMapsWithAction(actionId);
		}

		public virtual ActionElementMap GetElementMap(int elementMapId)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return null;
			}
			if (elementMapId < 0)
			{
				goto IL_001f;
			}
			int num = buttonMapCount;
			int num2 = 185180702;
			goto IL_0024;
			IL_0024:
			int num3 = default(int);
			while (true)
			{
				switch (num2 ^ 0xB09A21B)
				{
				case 3:
					break;
				case 2:
					return wIadyhEVxiJaWeDEsznpytUcfFE[num3];
				case 5:
					num3 = 0;
					num2 = 185180703;
					continue;
				case 0:
					if (wIadyhEVxiJaWeDEsznpytUcfFE[num3].tqPurZpByiUWRrPJKwHxxaZZua != elementMapId)
					{
						num3++;
						num2 = 185180703;
					}
					else
					{
						num2 = 185180697;
					}
					continue;
				case 1:
					return null;
				default:
					if (num3 >= num)
					{
						return null;
					}
					goto case 0;
				}
				break;
			}
			goto IL_001f;
			IL_001f:
			num2 = 185180698;
			goto IL_0024;
		}

		public ActionElementMap[] GetElementMaps()
		{
			return GetElementMaps(skipDisabledMaps: false);
		}

		public ActionElementMap[] GetElementMaps(bool skipDisabledMaps)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				goto IL_000d;
			}
			int num = elementMapCount;
			int num2;
			if (num == 0)
			{
				num2 = 2117668711;
				goto IL_0012;
			}
			List<ActionElementMap> list = new List<ActionElementMap>(num);
			using (IEnumerator<ActionElementMap> enumerator = AllMaps.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					while (true)
					{
						ActionElementMap current = enumerator.Current;
						int num3 = 2117668710;
						while (true)
						{
							switch (num3 ^ 0x7E390F67)
							{
							case 0:
								num3 = 2117668707;
								continue;
							case 4:
								break;
							case 1:
								if (skipDisabledMaps)
								{
									goto IL_00a0;
								}
								goto case 3;
							case 3:
								list.Add(current);
								num3 = 2117668709;
								continue;
							default:
								goto end_IL_008f;
							}
							break;
							IL_00a0:
							int num4;
							if (!current.FnzJwrQpikWfZbmfjZhFwutJGAA)
							{
								num3 = 2117668709;
								num4 = num3;
							}
							else
							{
								num3 = 2117668708;
								num4 = num3;
							}
						}
						continue;
						end_IL_008f:
						break;
					}
				}
			}
			return list.ToArray();
			IL_0012:
			switch (num2 ^ 0x7E390F67)
			{
			case 2:
				break;
			case 1:
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return EmptyObjects<ActionElementMap>.array;
			default:
				return EmptyObjects<ActionElementMap>.array;
			}
			goto IL_000d;
			IL_000d:
			num2 = 2117668710;
			goto IL_0012;
		}

		public int GetElementMaps(List<ActionElementMap> results)
		{
			return GetElementMaps(skipDisabledMaps: false, results);
		}

		public int GetElementMaps(bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				goto IL_000d;
			}
			int num;
			int num2;
			if (results == null)
			{
				num = 1781592512;
				num2 = num;
			}
			else
			{
				num = 1781592513;
				num2 = num;
			}
			goto IL_0012;
			IL_000d:
			num = 1781592515;
			goto IL_0012;
			IL_0012:
			switch (num ^ 0x6A30F1C0)
			{
			case 2:
				break;
			case 3:
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return 0;
			case 0:
				throw new ArgumentNullException("results");
			default:
				results.Clear();
				return xryeFZUsHaBNPgZaFhYIDuYBGQBe(results, skipDisabledMaps);
			}
			goto IL_000d;
		}

		public ActionElementMap[] GetElementMapsWithAction(string actionName)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return EmptyObjects<ActionElementMap>.array;
			}
			int actionId = ReInput.lUCgcEIquFfuykgBneGrfARQlcR.QRDvUGxTmzMESLVLwskMiVyiVse(actionName);
			return GetElementMapsWithAction(actionId);
		}

		public ActionElementMap[] GetElementMapsWithAction(int actionId)
		{
			return GetElementMapsWithAction(actionId, skipDisabledMaps: false);
		}

		public ActionElementMap[] GetElementMapsWithAction(string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				goto IL_000d;
			}
			int actionId = ReInput.lUCgcEIquFfuykgBneGrfARQlcR.QRDvUGxTmzMESLVLwskMiVyiVse(actionName);
			int num = -1150288940;
			goto IL_0012;
			IL_0012:
			while (true)
			{
				switch (num ^ -1150288938)
				{
				case 0:
					break;
				case 1:
					goto IL_002f;
				case 3:
					return EmptyObjects<ActionElementMap>.array;
				default:
					return GetElementMapsWithAction(actionId, skipDisabledMaps);
				}
				break;
				IL_002f:
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				num = -1150288939;
			}
			goto IL_000d;
			IL_000d:
			num = -1150288937;
			goto IL_0012;
		}

		public ActionElementMap[] GetElementMapsWithAction(int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				goto IL_000d;
			}
			if (actionId < 0)
			{
				return EmptyObjects<ActionElementMap>.array;
			}
			int num;
			if (elementMapCount == 0)
			{
				num = -1638861939;
				goto IL_0012;
			}
			int num2 = 0;
			using (IEnumerator<ActionElementMap> enumerator = AllMaps.GetEnumerator())
			{
				ActionElementMap current = default(ActionElementMap);
				while (true)
				{
					IL_00d8:
					int num3;
					int num4;
					if (!enumerator.MoveNext())
					{
						num3 = -1638861937;
						num4 = num3;
					}
					else
					{
						num3 = -1638861943;
						num4 = num3;
					}
					while (true)
					{
						switch (num3 ^ -1638861939)
						{
						case 3:
							num3 = -1638861943;
							continue;
						default:
							goto end_IL_0074;
						case 0:
							num2++;
							num3 = -1638861944;
							continue;
						case 1:
							if (current._actionId != actionId)
							{
								break;
							}
							if (skipDisabledMaps)
							{
								int num5;
								if (!current.FnzJwrQpikWfZbmfjZhFwutJGAA)
								{
									num3 = -1638861944;
									num5 = num3;
								}
								else
								{
									num3 = -1638861939;
									num5 = num3;
								}
								continue;
							}
							goto case 0;
						case 4:
							current = enumerator.Current;
							num3 = -1638861940;
							continue;
						case 5:
							break;
						case 2:
							goto end_IL_0074;
						}
						goto IL_00d8;
						continue;
						end_IL_0074:
						break;
					}
					break;
				}
			}
			if (num2 == 0)
			{
				goto IL_0103;
			}
			ActionElementMap[] array = new ActionElementMap[num2];
			int num6 = 0;
			int num7 = -1638861939;
			goto IL_0108;
			IL_0103:
			num7 = -1638861940;
			goto IL_0108;
			IL_0108:
			switch (num7 ^ -1638861939)
			{
			case 2:
				break;
			case 1:
				return EmptyObjects<ActionElementMap>.array;
			default:
			{
				using (IEnumerator<ActionElementMap> enumerator2 = AllMaps.GetEnumerator())
				{
					while (enumerator2.MoveNext())
					{
						while (true)
						{
							ActionElementMap current2 = enumerator2.Current;
							int num8 = -1638861937;
							while (true)
							{
								switch (num8 ^ -1638861939)
								{
								case 6:
									num8 = -1638861938;
									continue;
								case 3:
									break;
								case 5:
									num6++;
									num8 = -1638861939;
									continue;
								case 1:
									array[num6] = current2;
									num8 = -1638861944;
									continue;
								case 2:
									goto IL_01a2;
								case 4:
									if (!skipDisabledMaps)
									{
										goto case 1;
									}
									goto IL_01c0;
								default:
									goto end_IL_0178;
								}
								break;
								IL_01c0:
								int num9;
								if (!current2.FnzJwrQpikWfZbmfjZhFwutJGAA)
								{
									num8 = -1638861939;
									num9 = num8;
								}
								else
								{
									num8 = -1638861940;
									num9 = num8;
								}
								continue;
								IL_01a2:
								int num10;
								if (current2._actionId != actionId)
								{
									num8 = -1638861939;
									num10 = num8;
								}
								else
								{
									num8 = -1638861943;
									num10 = num8;
								}
							}
							continue;
							end_IL_0178:
							break;
						}
					}
					return array;
				}
			}
			}
			goto IL_0103;
			IL_000d:
			num = -1638861940;
			goto IL_0012;
			IL_0012:
			switch (num ^ -1638861939)
			{
			case 2:
				break;
			case 1:
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return EmptyObjects<ActionElementMap>.array;
			default:
				return EmptyObjects<ActionElementMap>.array;
			}
			goto IL_000d;
		}

		public int GetElementMapsWithAction(string actionName, List<ActionElementMap> results)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return 0;
			}
			int actionId = ReInput.lUCgcEIquFfuykgBneGrfARQlcR.QRDvUGxTmzMESLVLwskMiVyiVse(actionName);
			return GetElementMapsWithAction(actionId, results);
		}

		public int GetElementMapsWithAction(int actionId, List<ActionElementMap> results)
		{
			return GetElementMapsWithAction(actionId, skipDisabledMaps: false, results);
		}

		public int GetElementMapsWithAction(string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return 0;
			}
			int actionId = ReInput.lUCgcEIquFfuykgBneGrfARQlcR.QRDvUGxTmzMESLVLwskMiVyiVse(actionName);
			return GetElementMapsWithAction(actionId, skipDisabledMaps, results);
		}

		public int GetElementMapsWithAction(int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			return RBgEhrXFkmZieEZpFoliEKAnVDW(actionId, skipDisabledMaps, results, false);
		}

		public IEnumerable<ActionElementMap> ElementMapsWithAction(string actionName)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			int actionId = ReInput.lUCgcEIquFfuykgBneGrfARQlcR.QRDvUGxTmzMESLVLwskMiVyiVse(actionName);
			return ElementMapsWithAction(actionId);
		}

		public IEnumerable<ActionElementMap> ElementMapsWithAction(int actionId)
		{
			return ElementMapsWithAction(actionId, skipDisabledMaps: false);
		}

		public IEnumerable<ActionElementMap> ElementMapsWithAction(string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			int actionId = ReInput.lUCgcEIquFfuykgBneGrfARQlcR.QRDvUGxTmzMESLVLwskMiVyiVse(actionName);
			return ElementMapsWithAction(actionId, skipDisabledMaps);
		}

		public IEnumerable<ActionElementMap> ElementMapsWithAction(int actionId, bool skipDisabledMaps)
		{
			neKfltxxMSIHUcgdWMFvukkDTtM neKfltxxMSIHUcgdWMFvukkDTtM2 = new neKfltxxMSIHUcgdWMFvukkDTtM(-2);
			while (true)
			{
				int num = 82327419;
				while (true)
				{
					switch (num ^ 0x4E83779)
					{
					case 0:
						break;
					case 2:
						goto IL_0026;
					default:
						neKfltxxMSIHUcgdWMFvukkDTtM2.QLOttLyzbwmZEgbaVWtyYLtwEXF = actionId;
						neKfltxxMSIHUcgdWMFvukkDTtM2.dGwSNihzjCwVEkHXFGPpgtHVneEu = skipDisabledMaps;
						return neKfltxxMSIHUcgdWMFvukkDTtM2;
					}
					break;
					IL_0026:
					neKfltxxMSIHUcgdWMFvukkDTtM2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = this;
					num = 82327416;
				}
			}
		}

		public virtual ActionElementMap GetFirstElementMapWithAction(int actionId)
		{
			return GetFirstElementMapWithAction(actionId, skipDisabledMaps: false);
		}

		public virtual ActionElementMap GetFirstElementMapWithAction(string actionName)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				while (true)
				{
					int num = 1299272146;
					while (true)
					{
						switch (num ^ 0x4D7151D3)
						{
						case 0:
							break;
						case 1:
							goto IL_002b;
						default:
							return null;
						}
						break;
						IL_002b:
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						num = 1299272145;
					}
				}
			}
			int actionId = ReInput.lUCgcEIquFfuykgBneGrfARQlcR.QRDvUGxTmzMESLVLwskMiVyiVse(actionName);
			return GetFirstElementMapWithAction(actionId);
		}

		public virtual ActionElementMap GetFirstElementMapWithAction(int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				goto IL_0019;
			}
			int num;
			int num2 = default(int);
			int num3 = default(int);
			if (actionId < 0)
			{
				num = -170680838;
			}
			else
			{
				num2 = buttonMapCount;
				num3 = 0;
				num = -170680834;
			}
			goto IL_001e;
			IL_0019:
			num = -170680836;
			goto IL_001e;
			IL_001e:
			while (true)
			{
				switch (num ^ -170680837)
				{
				case 0:
					break;
				case 7:
					return null;
				case 4:
					return wIadyhEVxiJaWeDEsznpytUcfFE[num3];
				case 2:
					if (wIadyhEVxiJaWeDEsznpytUcfFE[num3]._actionId == actionId)
					{
						num = -170680840;
						continue;
					}
					goto IL_0065;
				case 5:
					num = -170680835;
					continue;
				case 1:
					return null;
				case 3:
					if (!skipDisabledMaps)
					{
						goto case 4;
					}
					if (wIadyhEVxiJaWeDEsznpytUcfFE[num3].FnzJwrQpikWfZbmfjZhFwutJGAA)
					{
						num = -170680833;
						continue;
					}
					goto IL_0065;
				default:
					{
						if (num3 >= num2)
						{
							return null;
						}
						goto case 2;
					}
					IL_0065:
					num3++;
					num = -170680835;
					continue;
				}
				break;
			}
			goto IL_0019;
		}

		public ActionElementMap GetFirstElementMapWithAction(string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return null;
			}
			int actionId = ReInput.lUCgcEIquFfuykgBneGrfARQlcR.QRDvUGxTmzMESLVLwskMiVyiVse(actionName);
			return GetFirstElementMapWithAction(actionId, skipDisabledMaps);
		}

		public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(ControllerElementTarget elementTarget, bool skipDisabledMaps)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				goto IL_000d;
			}
			TtePFCKBdNmQRluqYJdgMTWVuTZ ttePFCKBdNmQRluqYJdgMTWVuTZ = TtePFCKBdNmQRluqYJdgMTWVuTZ.axyDWBaevBEdcNutlzYJvrYkUXO(elementTarget);
			IEnumerable<ActionElementMap> result = ElementMapsWithElementTarget(ttePFCKBdNmQRluqYJdgMTWVuTZ, skipDisabledMaps);
			TtePFCKBdNmQRluqYJdgMTWVuTZ.nUqfikRMgdyVbwPofFMThwkULhhr(ttePFCKBdNmQRluqYJdgMTWVuTZ);
			int num = 1192630509;
			goto IL_0012;
			IL_0012:
			while (true)
			{
				switch (num ^ 0x471618EC)
				{
				case 0:
					break;
				case 3:
					goto IL_002f;
				case 2:
					return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
				default:
					return result;
				}
				break;
				IL_002f:
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				num = 1192630510;
			}
			goto IL_000d;
			IL_000d:
			num = 1192630511;
			goto IL_0012;
		}

		public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(IControllerElementTarget elementTarget, bool skipDisabledMaps)
		{
			riszywFvpYEaFLjVpWanrijJGjv riszywFvpYEaFLjVpWanrijJGjv2 = new riszywFvpYEaFLjVpWanrijJGjv(-2);
			riszywFvpYEaFLjVpWanrijJGjv2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = this;
			riszywFvpYEaFLjVpWanrijJGjv2.zpRfvkHXclZCdsnNMywWBjZbfwbc = elementTarget;
			riszywFvpYEaFLjVpWanrijJGjv2.dGwSNihzjCwVEkHXFGPpgtHVneEu = skipDisabledMaps;
			return riszywFvpYEaFLjVpWanrijJGjv2;
		}

		public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(ControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			TtePFCKBdNmQRluqYJdgMTWVuTZ ttePFCKBdNmQRluqYJdgMTWVuTZ = TtePFCKBdNmQRluqYJdgMTWVuTZ.axyDWBaevBEdcNutlzYJvrYkUXO(elementTarget);
			IEnumerable<ActionElementMap> result = ElementMapsWithElementTarget(ttePFCKBdNmQRluqYJdgMTWVuTZ, actionId, skipDisabledMaps);
			while (true)
			{
				int num = -578194649;
				while (true)
				{
					switch (num ^ -578194650)
					{
					case 0:
						break;
					case 1:
						goto IL_004e;
					default:
						return result;
					}
					break;
					IL_004e:
					TtePFCKBdNmQRluqYJdgMTWVuTZ.nUqfikRMgdyVbwPofFMThwkULhhr(ttePFCKBdNmQRluqYJdgMTWVuTZ);
					num = -578194652;
				}
			}
		}

		public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(ControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			int actionId = ReInput.lUCgcEIquFfuykgBneGrfARQlcR.QRDvUGxTmzMESLVLwskMiVyiVse(actionName);
			return ElementMapsWithElementTarget(elementTarget, actionId, skipDisabledMaps);
		}

		public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(IControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps)
		{
			jiBJXkaByUMRtcYAJxDrTBudGcn jiBJXkaByUMRtcYAJxDrTBudGcn2 = new jiBJXkaByUMRtcYAJxDrTBudGcn(-2);
			jiBJXkaByUMRtcYAJxDrTBudGcn2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = this;
			jiBJXkaByUMRtcYAJxDrTBudGcn2.zpRfvkHXclZCdsnNMywWBjZbfwbc = elementTarget;
			jiBJXkaByUMRtcYAJxDrTBudGcn2.QLOttLyzbwmZEgbaVWtyYLtwEXF = actionId;
			jiBJXkaByUMRtcYAJxDrTBudGcn2.dGwSNihzjCwVEkHXFGPpgtHVneEu = skipDisabledMaps;
			return jiBJXkaByUMRtcYAJxDrTBudGcn2;
		}

		public IEnumerable<ActionElementMap> ElementMapsWithElementTarget(IControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				goto IL_0019;
			}
			int actionId = ReInput.lUCgcEIquFfuykgBneGrfARQlcR.QRDvUGxTmzMESLVLwskMiVyiVse(actionName);
			int num = -111330223;
			goto IL_001e;
			IL_001e:
			switch (num ^ -111330221)
			{
			case 0:
				break;
			case 1:
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			default:
				return ElementMapsWithElementTarget(elementTarget, actionId, skipDisabledMaps);
			}
			goto IL_0019;
			IL_0019:
			num = -111330222;
			goto IL_001e;
		}

		public ActionElementMap GetFirstElementMapWithElementTarget(ControllerElementTarget elementTarget, bool skipDisabledMaps)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return null;
			}
			TtePFCKBdNmQRluqYJdgMTWVuTZ ttePFCKBdNmQRluqYJdgMTWVuTZ = TtePFCKBdNmQRluqYJdgMTWVuTZ.axyDWBaevBEdcNutlzYJvrYkUXO(elementTarget);
			ActionElementMap firstElementMapWithElementTarget = GetFirstElementMapWithElementTarget(ttePFCKBdNmQRluqYJdgMTWVuTZ, skipDisabledMaps);
			TtePFCKBdNmQRluqYJdgMTWVuTZ.nUqfikRMgdyVbwPofFMThwkULhhr(ttePFCKBdNmQRluqYJdgMTWVuTZ);
			return firstElementMapWithElementTarget;
		}

		public ActionElementMap GetFirstElementMapWithElementTarget(IControllerElementTarget elementTarget, bool skipDisabledMaps)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return null;
			}
			bool flag;
			return fZGPCRASIBflRUbPxowPPeWbYQN(elementTarget, false, -1, skipDisabledMaps, out flag);
		}

		public ActionElementMap GetFirstElementMapWithElementTarget(ControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				goto IL_000d;
			}
			TtePFCKBdNmQRluqYJdgMTWVuTZ ttePFCKBdNmQRluqYJdgMTWVuTZ = TtePFCKBdNmQRluqYJdgMTWVuTZ.axyDWBaevBEdcNutlzYJvrYkUXO(elementTarget);
			int num = 612621353;
			goto IL_0012;
			IL_0012:
			ActionElementMap firstElementMapWithElementTarget = default(ActionElementMap);
			while (true)
			{
				switch (num ^ 0x2483DC2B)
				{
				case 0:
					break;
				case 4:
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
					num = 612621354;
					continue;
				case 2:
					firstElementMapWithElementTarget = GetFirstElementMapWithElementTarget(ttePFCKBdNmQRluqYJdgMTWVuTZ, actionId, skipDisabledMaps);
					num = 612621352;
					continue;
				case 1:
					return null;
				default:
					TtePFCKBdNmQRluqYJdgMTWVuTZ.nUqfikRMgdyVbwPofFMThwkULhhr(ttePFCKBdNmQRluqYJdgMTWVuTZ);
					return firstElementMapWithElementTarget;
				}
				break;
			}
			goto IL_000d;
			IL_000d:
			num = 612621359;
			goto IL_0012;
		}

		public ActionElementMap GetFirstElementMapWithElementTarget(ControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				goto IL_0019;
			}
			int actionId = ReInput.lUCgcEIquFfuykgBneGrfARQlcR.QRDvUGxTmzMESLVLwskMiVyiVse(actionName);
			int num = -1333194014;
			goto IL_001e;
			IL_001e:
			switch (num ^ -1333194014)
			{
			case 2:
				break;
			case 1:
				return null;
			default:
				return GetFirstElementMapWithElementTarget(elementTarget, actionId, skipDisabledMaps);
			}
			goto IL_0019;
			IL_0019:
			num = -1333194013;
			goto IL_001e;
		}

		public ActionElementMap GetFirstElementMapWithElementTarget(IControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return null;
			}
			bool flag;
			return fZGPCRASIBflRUbPxowPPeWbYQN(elementTarget, true, actionId, skipDisabledMaps, out flag);
		}

		public ActionElementMap GetFirstElementMapWithElementTarget(IControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return null;
			}
			int actionId = ReInput.lUCgcEIquFfuykgBneGrfARQlcR.QRDvUGxTmzMESLVLwskMiVyiVse(actionName);
			return GetFirstElementMapWithElementTarget(elementTarget, actionId, skipDisabledMaps);
		}

		public int GetElementMapsWithElementTarget(ControllerElementTarget elementTarget, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return 0;
			}
			TtePFCKBdNmQRluqYJdgMTWVuTZ ttePFCKBdNmQRluqYJdgMTWVuTZ = TtePFCKBdNmQRluqYJdgMTWVuTZ.axyDWBaevBEdcNutlzYJvrYkUXO(elementTarget);
			int elementMapsWithElementTarget = GetElementMapsWithElementTarget(ttePFCKBdNmQRluqYJdgMTWVuTZ, skipDisabledMaps, results);
			TtePFCKBdNmQRluqYJdgMTWVuTZ.nUqfikRMgdyVbwPofFMThwkULhhr(ttePFCKBdNmQRluqYJdgMTWVuTZ);
			return elementMapsWithElementTarget;
		}

		public int GetElementMapsWithElementTarget(IControllerElementTarget elementTarget, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return 0;
			}
			bool flag;
			return hqlCMKjVRQhOxlLPEQXdCmkbvsYc(elementTarget, false, -1, skipDisabledMaps, results, false, out flag);
		}

		public int GetElementMapsWithElementTarget(ControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				goto IL_0019;
			}
			TtePFCKBdNmQRluqYJdgMTWVuTZ ttePFCKBdNmQRluqYJdgMTWVuTZ = TtePFCKBdNmQRluqYJdgMTWVuTZ.axyDWBaevBEdcNutlzYJvrYkUXO(elementTarget);
			int elementMapsWithElementTarget = GetElementMapsWithElementTarget(ttePFCKBdNmQRluqYJdgMTWVuTZ, actionId, skipDisabledMaps, results);
			int num = 857932241;
			goto IL_001e;
			IL_001e:
			while (true)
			{
				switch (num ^ 0x332301D3)
				{
				case 3:
					break;
				case 1:
					return 0;
				case 2:
					goto IL_0057;
				default:
					return elementMapsWithElementTarget;
				}
				break;
				IL_0057:
				TtePFCKBdNmQRluqYJdgMTWVuTZ.nUqfikRMgdyVbwPofFMThwkULhhr(ttePFCKBdNmQRluqYJdgMTWVuTZ);
				num = 857932243;
			}
			goto IL_0019;
			IL_0019:
			num = 857932242;
			goto IL_001e;
		}

		public int GetElementMapsWithElementTarget(ControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return 0;
			}
			int actionId = ReInput.lUCgcEIquFfuykgBneGrfARQlcR.QRDvUGxTmzMESLVLwskMiVyiVse(actionName);
			return GetElementMapsWithElementTarget(elementTarget, actionId, skipDisabledMaps, results);
		}

		public int GetElementMapsWithElementTarget(IControllerElementTarget elementTarget, int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return 0;
			}
			bool flag;
			return hqlCMKjVRQhOxlLPEQXdCmkbvsYc(elementTarget, true, actionId, skipDisabledMaps, results, false, out flag);
		}

		public int GetElementMapsWithElementTarget(IControllerElementTarget elementTarget, string actionName, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return 0;
			}
			int actionId = ReInput.lUCgcEIquFfuykgBneGrfARQlcR.QRDvUGxTmzMESLVLwskMiVyiVse(actionName);
			return GetElementMapsWithElementTarget(elementTarget, actionId, skipDisabledMaps, results);
		}

		public ActionElementMap GetFirstElementMapMatch(Predicate<ActionElementMap> predicate)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return null;
			}
			return vAyRMQMdWAhfVfzsHnTFcSglbxB(predicate, false);
		}

		internal virtual ActionElementMap vAyRMQMdWAhfVfzsHnTFcSglbxB(Predicate<ActionElementMap> P_0, bool P_1)
		{
			return sImfscchTLCnHnpoXmHHevRaSgzu(P_0, P_1);
		}

		public int GetElementMapMatches(Predicate<ActionElementMap> predicate, List<ActionElementMap> results)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return 0;
			}
			return RlLhHLIMNbxYpYFGeSDoESsnOjz(predicate, false, results, false);
		}

		internal virtual int RlLhHLIMNbxYpYFGeSDoESsnOjz(Predicate<ActionElementMap> P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			return MSUYtyWEVFiinWmstXyZilUWTrt(P_0, P_1, P_2, P_3);
		}

		public void ForEachElementMapMatch(Predicate<ActionElementMap> predicate, Action<ActionElementMap> actionToPerform)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				while (true)
				{
					switch (-2057909631 ^ -2057909630)
					{
					case 2:
						break;
					case 4:
						goto end_IL_000d;
					case 0:
						goto IL_0048;
					case 3:
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						return;
					default:
						goto IL_0071;
					}
					continue;
					end_IL_000d:
					break;
				}
				goto IL_0033;
			}
			goto IL_0048;
			IL_0071:
			int count = ZYwIXqAucYgKRZdCmuiIHmWLQlA.Count;
			try
			{
				int num = 0;
				ActionElementMap obj = default(ActionElementMap);
				while (true)
				{
					int num2;
					int num3;
					if (num >= count)
					{
						num2 = -2057909625;
						num3 = num2;
					}
					else
					{
						num2 = -2057909631;
						num3 = num2;
					}
					while (true)
					{
						switch (num2 ^ -2057909630)
						{
						case 0:
							num2 = -2057909631;
							continue;
						default:
							return;
						case 1:
							num++;
							num2 = -2057909632;
							continue;
						case 4:
							if (predicate(obj))
							{
								actionToPerform(obj);
								num2 = -2057909629;
								continue;
							}
							goto case 1;
						case 3:
							obj = ZYwIXqAucYgKRZdCmuiIHmWLQlA[num];
							num2 = -2057909626;
							continue;
						case 2:
							break;
						case 5:
							return;
						}
						break;
					}
				}
			}
			catch (Exception exception)
			{
				ReInput.HandleCallbackException("ControllerMap.ForEachElementMapMatch", exception);
				return;
			}
			IL_0048:
			if (predicate == null)
			{
				throw new ArgumentNullException("predicate");
			}
			goto IL_0033;
			IL_0033:
			if (actionToPerform == null)
			{
				throw new ArgumentNullException("actionToPerform");
			}
			goto IL_0071;
		}

		public virtual void ClearElementMaps()
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return;
			}
			while (true)
			{
				wIadyhEVxiJaWeDEsznpytUcfFE.Clear();
				ZYwIXqAucYgKRZdCmuiIHmWLQlA.Clear();
				int num = -89534652;
				while (true)
				{
					switch (num ^ -89534651)
					{
					case 0:
						goto IL_001a;
					default:
						return;
					case 2:
						break;
					case 1:
						return;
					}
					break;
					IL_001a:
					num = -89534649;
				}
			}
		}

		public int SetAllElementMapsEnabled(bool state)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return 0;
			}
			int num = 0;
			int count = default(int);
			int num3 = default(int);
			while (true)
			{
				int num2 = 498665037;
				while (true)
				{
					switch (num2 ^ 0x1DB9064C)
					{
					case 0:
						break;
					case 1:
						count = ZYwIXqAucYgKRZdCmuiIHmWLQlA.Count;
						num3 = 0;
						num2 = 498665032;
						continue;
					case 4:
					{
						int num4;
						if (num3 >= count)
						{
							num2 = 498665039;
							num4 = num2;
						}
						else
						{
							num2 = 498665034;
							num4 = num2;
						}
						continue;
					}
					case 2:
						num++;
						num2 = 498665033;
						continue;
					case 6:
					{
						ActionElementMap actionElementMap = ZYwIXqAucYgKRZdCmuiIHmWLQlA[num3];
						if (actionElementMap.FnzJwrQpikWfZbmfjZhFwutJGAA != state)
						{
							actionElementMap.FnzJwrQpikWfZbmfjZhFwutJGAA = state;
							num2 = 498665038;
							continue;
						}
						goto case 5;
					}
					case 5:
						num3++;
						num2 = 498665032;
						continue;
					default:
						return num;
					}
					break;
				}
			}
		}

		public ActionElementMap GetButtonMap(int index)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				goto IL_0019;
			}
			int num;
			if (wIadyhEVxiJaWeDEsznpytUcfFE != null)
			{
				int num2;
				if (index < 0)
				{
					num = -1785733099;
					num2 = num;
				}
				else
				{
					num = -1785733100;
					num2 = num;
				}
				goto IL_001e;
			}
			goto IL_006f;
			IL_001e:
			while (true)
			{
				switch (num ^ -1785733099)
				{
				case 3:
					break;
				case 2:
					return null;
				case 1:
					goto IL_005a;
				default:
					goto IL_006f;
				}
				break;
				IL_005a:
				if (index >= wIadyhEVxiJaWeDEsznpytUcfFE.Count)
				{
					num = -1785733099;
					continue;
				}
				return wIadyhEVxiJaWeDEsznpytUcfFE[index];
			}
			goto IL_0019;
			IL_0019:
			num = -1785733097;
			goto IL_001e;
			IL_006f:
			return null;
		}

		public ActionElementMap[] GetButtonMaps()
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return EmptyObjects<ActionElementMap>.array;
			}
			return ListTools.ToArray(wIadyhEVxiJaWeDEsznpytUcfFE);
		}

		public ActionElementMap[] GetButtonMaps(bool skipDisabledMaps)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				goto IL_0010;
			}
			int count = wIadyhEVxiJaWeDEsznpytUcfFE.Count;
			List<ActionElementMap> list = new List<ActionElementMap>(count);
			int num = -1604084428;
			goto IL_0015;
			IL_0015:
			int num3 = default(int);
			ActionElementMap actionElementMap = default(ActionElementMap);
			while (true)
			{
				switch (num ^ -1604084428)
				{
				case 6:
					break;
				case 0:
					num3 = 0;
					num = -1604084425;
					continue;
				case 10:
					num3++;
					num = -1604084427;
					continue;
				case 1:
				{
					int num4;
					if (num3 >= count)
					{
						num = -1604084431;
						num4 = num;
					}
					else
					{
						num = -1604084432;
						num4 = num;
					}
					continue;
				}
				case 9:
					list.Add(actionElementMap);
					num = -1604084418;
					continue;
				case 4:
					actionElementMap = wIadyhEVxiJaWeDEsznpytUcfFE[num3];
					num = -1604084429;
					continue;
				case 11:
				{
					int num5;
					if (actionElementMap.FnzJwrQpikWfZbmfjZhFwutJGAA)
					{
						num = -1604084419;
						num5 = num;
					}
					else
					{
						num = -1604084418;
						num5 = num;
					}
					continue;
				}
				case 8:
					return EmptyObjects<ActionElementMap>.array;
				case 3:
					num = -1604084427;
					continue;
				case 7:
				{
					int num2;
					if (!skipDisabledMaps)
					{
						num = -1604084419;
						num2 = num;
					}
					else
					{
						num = -1604084417;
						num2 = num;
					}
					continue;
				}
				case 2:
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
					num = -1604084420;
					continue;
				default:
					return list.ToArray();
				}
				break;
			}
			goto IL_0010;
			IL_0010:
			num = -1604084426;
			goto IL_0015;
		}

		public int GetButtonMaps(bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				while (true)
				{
					int num = 560971646;
					while (true)
					{
						switch (num ^ 0x216FBF7C)
						{
						case 0:
							break;
						case 2:
							goto IL_002b;
						default:
							return 0;
						}
						break;
						IL_002b:
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						num = 560971645;
					}
				}
			}
			return mtcKICqphgVFBvDKrNbyYzWrilK(skipDisabledMaps, results, false);
		}

		public ActionElementMap[] GetButtonMapsWithAction(string actionName)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				goto IL_0019;
			}
			InputAction inputAction = ReInput.lUCgcEIquFfuykgBneGrfARQlcR.HPBabWgYCxuQFtaZlVdaNBbUOip(actionName, true);
			int num = -285578251;
			goto IL_001e;
			IL_001e:
			while (true)
			{
				switch (num ^ -285578251)
				{
				case 3:
					break;
				case 1:
					return EmptyObjects<ActionElementMap>.array;
				case 0:
					if (inputAction == null)
					{
						goto IL_0058;
					}
					return GetButtonMapsWithAction(inputAction.id);
				default:
					return EmptyObjects<ActionElementMap>.array;
				}
				break;
				IL_0058:
				num = -285578249;
			}
			goto IL_0019;
			IL_0019:
			num = -285578252;
			goto IL_001e;
		}

		public ActionElementMap[] GetButtonMapsWithAction(int actionId)
		{
			return GetButtonMapsWithAction(actionId, skipDisabledMaps: false);
		}

		public ActionElementMap[] GetButtonMapsWithAction(string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				goto IL_0019;
			}
			InputAction inputAction = ReInput.lUCgcEIquFfuykgBneGrfARQlcR.HPBabWgYCxuQFtaZlVdaNBbUOip(actionName, true);
			int num = 158175552;
			goto IL_001e;
			IL_001e:
			switch (num ^ 0x96D9141)
			{
			case 0:
				break;
			case 2:
				return EmptyObjects<ActionElementMap>.array;
			default:
				if (inputAction == null)
				{
					return EmptyObjects<ActionElementMap>.array;
				}
				return GetButtonMapsWithAction(inputAction.id, skipDisabledMaps);
			}
			goto IL_0019;
			IL_0019:
			num = 158175555;
			goto IL_001e;
		}

		public ActionElementMap[] GetButtonMapsWithAction(int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				goto IL_0010;
			}
			int num = buttonMapCount;
			if (num == 0)
			{
				return EmptyObjects<ActionElementMap>.array;
			}
			int num2 = 0;
			int num3 = 0;
			int num4 = 298629302;
			goto IL_0015;
			IL_0010:
			num4 = 298629308;
			goto IL_0015;
			IL_0015:
			int num5 = default(int);
			ActionElementMap actionElementMap2 = default(ActionElementMap);
			ActionElementMap[] array = default(ActionElementMap[]);
			int num6 = default(int);
			ActionElementMap actionElementMap = default(ActionElementMap);
			while (true)
			{
				switch (num4 ^ 0x11CCB8B2)
				{
				case 7:
					break;
				case 9:
					num5 = 0;
					num4 = 298629311;
					continue;
				case 3:
				{
					actionElementMap2 = wIadyhEVxiJaWeDEsznpytUcfFE[num3];
					int num11;
					if (actionElementMap2._actionId == actionId)
					{
						num4 = 298629306;
						num11 = num4;
					}
					else
					{
						num4 = 298629300;
						num11 = num4;
					}
					continue;
				}
				case 0:
					num2++;
					num4 = 298629300;
					continue;
				case 6:
					num3++;
					num4 = 298629296;
					continue;
				case 10:
					if (num2 == 0)
					{
						return EmptyObjects<ActionElementMap>.array;
					}
					array = new ActionElementMap[num2];
					num6 = 0;
					num4 = 298629307;
					continue;
				case 4:
					num4 = 298629296;
					continue;
				case 8:
				{
					int num8;
					if (!skipDisabledMaps)
					{
						num4 = 298629298;
						num8 = num4;
					}
					else
					{
						num4 = 298629299;
						num8 = num4;
					}
					continue;
				}
				case 12:
					actionElementMap = wIadyhEVxiJaWeDEsznpytUcfFE[num5];
					if (actionElementMap._actionId == actionId)
					{
						if (skipDisabledMaps)
						{
							int num10;
							if (actionElementMap.FnzJwrQpikWfZbmfjZhFwutJGAA)
							{
								num4 = 298629305;
								num10 = num4;
							}
							else
							{
								num4 = 298629303;
								num10 = num4;
							}
							continue;
						}
						goto case 11;
					}
					goto case 5;
				case 11:
					array[num6] = actionElementMap;
					num6++;
					num4 = 298629303;
					continue;
				case 5:
					num5++;
					num4 = 298629311;
					continue;
				case 14:
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
					return EmptyObjects<ActionElementMap>.array;
				case 1:
				{
					int num9;
					if (!actionElementMap2.FnzJwrQpikWfZbmfjZhFwutJGAA)
					{
						num4 = 298629300;
						num9 = num4;
					}
					else
					{
						num4 = 298629298;
						num9 = num4;
					}
					continue;
				}
				case 2:
				{
					int num7;
					if (num3 >= num)
					{
						num4 = 298629304;
						num7 = num4;
					}
					else
					{
						num4 = 298629297;
						num7 = num4;
					}
					continue;
				}
				default:
					if (num5 >= num)
					{
						return array;
					}
					goto case 12;
				}
				break;
			}
			goto IL_0010;
		}

		public int GetButtonMapsWithAction(string actionName, List<ActionElementMap> results)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return 0;
			}
			InputAction inputAction = ReInput.lUCgcEIquFfuykgBneGrfARQlcR.HPBabWgYCxuQFtaZlVdaNBbUOip(actionName, true);
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
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return 0;
			}
			InputAction inputAction = ReInput.lUCgcEIquFfuykgBneGrfARQlcR.HPBabWgYCxuQFtaZlVdaNBbUOip(actionName, true);
			if (inputAction == null)
			{
				while (true)
				{
					int num = 1063177053;
					while (true)
					{
						switch (num ^ 0x3F5ECB5C)
						{
						case 0:
							break;
						case 1:
							goto IL_0049;
						default:
							return 0;
						}
						break;
						IL_0049:
						ListTools.TryClear(results);
						num = 1063177054;
					}
				}
			}
			return GetButtonMapsWithAction(inputAction.id, skipDisabledMaps, results);
		}

		public int GetButtonMapsWithAction(int actionId, bool skipDisabledMaps, List<ActionElementMap> results)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				while (true)
				{
					int num = 1579708996;
					while (true)
					{
						switch (num ^ 0x5E287246)
						{
						case 0:
							break;
						case 2:
							goto IL_002b;
						default:
							return 0;
						}
						break;
						IL_002b:
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						num = 1579708999;
					}
				}
			}
			return gXOdyHibychfWorQwJzzDWLgsjhd(actionId, skipDisabledMaps, results, false);
		}

		public IEnumerable<ActionElementMap> ButtonMapsWithAction(int actionId)
		{
			return ButtonMapsWithAction(actionId, skipDisabledMaps: false);
		}

		public IEnumerable<ActionElementMap> ButtonMapsWithAction(string actionName)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				goto IL_000d;
			}
			int actionId = ReInput.lUCgcEIquFfuykgBneGrfARQlcR.QRDvUGxTmzMESLVLwskMiVyiVse(actionName);
			int num = 2141765612;
			goto IL_0012;
			IL_0012:
			while (true)
			{
				switch (num ^ 0x7FA8BFEE)
				{
				case 3:
					break;
				case 1:
					goto IL_002f;
				case 0:
					return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
				default:
					return ButtonMapsWithAction(actionId);
				}
				break;
				IL_002f:
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				num = 2141765614;
			}
			goto IL_000d;
			IL_000d:
			num = 2141765615;
			goto IL_0012;
		}

		public IEnumerable<ActionElementMap> ButtonMapsWithAction(int actionId, bool skipDisabledMaps)
		{
			dbXzvveBBmgCaERcFJABqjqFBwy dbXzvveBBmgCaERcFJABqjqFBwy2 = new dbXzvveBBmgCaERcFJABqjqFBwy(-2);
			dbXzvveBBmgCaERcFJABqjqFBwy2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = this;
			dbXzvveBBmgCaERcFJABqjqFBwy2.QLOttLyzbwmZEgbaVWtyYLtwEXF = actionId;
			dbXzvveBBmgCaERcFJABqjqFBwy2.dGwSNihzjCwVEkHXFGPpgtHVneEu = skipDisabledMaps;
			return dbXzvveBBmgCaERcFJABqjqFBwy2;
		}

		public IEnumerable<ActionElementMap> ButtonMapsWithAction(string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return EmptyObjects<ActionElementMap>.EmptyReadOnlyIListT;
			}
			int actionId = ReInput.lUCgcEIquFfuykgBneGrfARQlcR.QRDvUGxTmzMESLVLwskMiVyiVse(actionName);
			return ButtonMapsWithAction(actionId, skipDisabledMaps);
		}

		public ActionElementMap GetFirstButtonMapWithAction(int actionId)
		{
			return GetFirstButtonMapWithAction(actionId, skipDisabledMaps: false);
		}

		public ActionElementMap GetFirstButtonMapWithAction(string actionName)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return null;
			}
			int actionId = ReInput.lUCgcEIquFfuykgBneGrfARQlcR.QRDvUGxTmzMESLVLwskMiVyiVse(actionName);
			return GetFirstButtonMapWithAction(actionId);
		}

		public ActionElementMap GetFirstButtonMapWithAction(int actionId, bool skipDisabledMaps)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				goto IL_000d;
			}
			if (actionId < 0)
			{
				return null;
			}
			IList<ActionElementMap> buttonMaps = ButtonMaps;
			int num = buttonMapCount;
			int num2 = -942848058;
			goto IL_0012;
			IL_000d:
			num2 = -942848063;
			goto IL_0012;
			IL_0012:
			int num3 = default(int);
			ActionElementMap actionElementMap = default(ActionElementMap);
			while (true)
			{
				switch (num2 ^ -942848059)
				{
				case 6:
					break;
				case 4:
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
					num2 = -942848059;
					continue;
				case 3:
					num3 = 0;
					num2 = -942848064;
					continue;
				case 2:
					return actionElementMap;
				case 0:
					return null;
				case 1:
					actionElementMap = buttonMaps[num3];
					if (actionElementMap._actionId == actionId)
					{
						if (!skipDisabledMaps)
						{
							goto case 2;
						}
						if (actionElementMap.enabled)
						{
							num2 = -942848057;
							continue;
						}
					}
					num3++;
					num2 = -942848064;
					continue;
				default:
					if (num3 >= num)
					{
						return null;
					}
					goto case 1;
				}
				break;
			}
			goto IL_000d;
		}

		public ActionElementMap GetFirstButtonMapWithAction(string actionName, bool skipDisabledMaps)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return null;
			}
			int actionId = ReInput.lUCgcEIquFfuykgBneGrfARQlcR.QRDvUGxTmzMESLVLwskMiVyiVse(actionName);
			return GetFirstButtonMapWithAction(actionId, skipDisabledMaps);
		}

		public ActionElementMap GetFirstButtonMapMatch(Predicate<ActionElementMap> predicate)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return null;
			}
			return sImfscchTLCnHnpoXmHHevRaSgzu(predicate, false);
		}

		internal ActionElementMap sImfscchTLCnHnpoXmHHevRaSgzu(Predicate<ActionElementMap> P_0, bool P_1)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				while (true)
				{
					switch (0x56DAC9FF ^ 0x56DAC9FD)
					{
					case 0:
						continue;
					case 2:
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						return null;
					}
					break;
				}
			}
			else if (P_0 == null)
			{
				throw new ArgumentNullException("predicate");
			}
			IList<ActionElementMap> buttonMaps = ButtonMaps;
			int num = buttonMapCount;
			try
			{
				int num2 = 0;
				ActionElementMap actionElementMap = default(ActionElementMap);
				while (true)
				{
					IL_00ce:
					int num3;
					int num4;
					if (num2 >= num)
					{
						num3 = 1457179133;
						num4 = num3;
					}
					else
					{
						num3 = 1457179132;
						num4 = num3;
					}
					while (true)
					{
						switch (num3 ^ 0x56DAC9FD)
						{
						case 5:
							num3 = 1457179132;
							continue;
						default:
							goto end_IL_0065;
						case 1:
							actionElementMap = buttonMaps[num2];
							if (P_1)
							{
								int num5;
								if (actionElementMap.enabled)
								{
									num3 = 1457179135;
									num5 = num3;
								}
								else
								{
									num3 = 1457179134;
									num5 = num3;
								}
								continue;
							}
							goto case 2;
						case 3:
							num2++;
							num3 = 1457179129;
							continue;
						case 2:
							if (P_0(actionElementMap))
							{
								return actionElementMap;
							}
							goto case 3;
						case 4:
							break;
						case 0:
							goto end_IL_0065;
						}
						goto IL_00ce;
						continue;
						end_IL_0065:
						break;
					}
					break;
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
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return 0;
			}
			return MSUYtyWEVFiinWmstXyZilUWTrt(predicate, false, results, false);
		}

		internal int MSUYtyWEVFiinWmstXyZilUWTrt(Predicate<ActionElementMap> P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("predicate");
			}
			int num8 = default(int);
			while (true)
			{
				int num;
				int num2;
				if (P_2 == null)
				{
					num = 552129082;
					num2 = num;
				}
				else
				{
					num = 552129080;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ 0x20E8D238)
					{
					case 5:
						num = 552129086;
						continue;
					case 3:
						P_2.Clear();
						num = 552129084;
						continue;
					case 2:
						throw new ArgumentNullException("results");
					case 1:
					{
						int num9;
						if (P_3)
						{
							num = 552129087;
							num9 = num;
						}
						else
						{
							num = 552129083;
							num9 = num;
						}
						continue;
					}
					case 6:
						break;
					case 0:
						num8 = 0;
						num = 552129081;
						continue;
					case 7:
						num8 = P_2.Count;
						num = 552129084;
						continue;
					default:
					{
						IList<ActionElementMap> buttonMaps = ButtonMaps;
						int num3 = buttonMapCount;
						try
						{
							int num4 = 0;
							while (num4 < num3)
							{
								while (true)
								{
									ActionElementMap actionElementMap = buttonMaps[num4];
									int num5;
									int num6;
									if (P_1)
									{
										num5 = 552129083;
										num6 = num5;
									}
									else
									{
										num5 = 552129084;
										num6 = num5;
									}
									while (true)
									{
										switch (num5 ^ 0x20E8D238)
										{
										case 0:
											num5 = 552129081;
											continue;
										case 2:
											num4++;
											num5 = 552129085;
											continue;
										case 4:
											if (P_0(actionElementMap))
											{
												P_2.Add(actionElementMap);
												num5 = 552129082;
												continue;
											}
											goto case 2;
										case 3:
											break;
										case 1:
											goto end_IL_00bc;
										default:
											goto end_IL_011f;
										}
										int num7;
										if (actionElementMap.enabled)
										{
											num5 = 552129084;
											num7 = num5;
										}
										else
										{
											num5 = 552129082;
											num7 = num5;
										}
										continue;
										end_IL_00bc:
										break;
									}
									continue;
									end_IL_011f:
									break;
								}
							}
						}
						catch (Exception exception)
						{
							ReInput.HandleCallbackException("ControllerMap.GetButtonMapMatches", exception);
						}
						return P_2.Count - num8;
					}
					}
					break;
				}
			}
		}

		public void ForEachButtonMapMatch(Predicate<ActionElementMap> predicate, Action<ActionElementMap> actionToPerform)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				while (true)
				{
					switch (0x506AA338 ^ 0x506AA33C)
					{
					case 2:
						break;
					case 4:
						return;
					case 1:
						goto end_IL_0019;
					case 0:
						goto IL_005c;
					default:
						goto IL_0071;
					}
					continue;
					end_IL_0019:
					break;
				}
				goto IL_0047;
			}
			goto IL_005c;
			IL_0071:
			int count = wIadyhEVxiJaWeDEsznpytUcfFE.Count;
			try
			{
				int num = 0;
				ActionElementMap obj = default(ActionElementMap);
				while (true)
				{
					int num2 = 1349165886;
					while (true)
					{
						switch (num2 ^ 0x506AA33C)
						{
						case 0:
							break;
						case 3:
							num++;
							num2 = 1349165881;
							continue;
						case 4:
						{
							obj = wIadyhEVxiJaWeDEsznpytUcfFE[num];
							int num3;
							if (!predicate(obj))
							{
								num2 = 1349165887;
								num3 = num2;
							}
							else
							{
								num2 = 1349165885;
								num3 = num2;
							}
							continue;
						}
						case 1:
							actionToPerform(obj);
							num2 = 1349165887;
							continue;
						case 2:
							num2 = 1349165881;
							continue;
						default:
							if (num >= count)
							{
								return;
							}
							goto case 4;
						}
						break;
					}
				}
			}
			catch (Exception exception)
			{
				ReInput.HandleCallbackException("ControllerMap.GetButtonMapMatches", exception);
				return;
			}
			IL_0047:
			if (actionToPerform == null)
			{
				throw new ArgumentNullException("actionToPerform");
			}
			goto IL_0071;
			IL_005c:
			if (predicate == null)
			{
				throw new ArgumentNullException("predicate");
			}
			goto IL_0047;
		}

		public bool DeleteButtonMapsWithAction(string actionName)
		{
			return DeleteButtonMapsWithAction(ReInput.lUCgcEIquFfuykgBneGrfARQlcR.QRDvUGxTmzMESLVLwskMiVyiVse(actionName));
		}

		public bool DeleteButtonMapsWithAction(int actionId)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return false;
			}
			if (actionId < 0)
			{
				return false;
			}
			int num = buttonMapCount;
			if (num == 0)
			{
				goto IL_002e;
			}
			bool result = false;
			int num2 = 1663609798;
			goto IL_0033;
			IL_002e:
			num2 = 1663609805;
			goto IL_0033;
			IL_0033:
			ActionElementMap actionElementMap = default(ActionElementMap);
			int num3 = default(int);
			while (true)
			{
				switch (num2 ^ 0x6328ABC5)
				{
				case 4:
					break;
				case 2:
					if (actionElementMap != null)
					{
						int num5;
						if (actionElementMap._actionId != actionId)
						{
							num2 = 1663609794;
							num5 = num2;
						}
						else
						{
							num2 = 1663609792;
							num5 = num2;
						}
						continue;
					}
					goto case 7;
				case 5:
					QIfwVXGJCVNYMvqEWdTbgGcJiJX(actionElementMap.tqPurZpByiUWRrPJKwHxxaZZua, num3);
					result = true;
					num2 = 1663609794;
					continue;
				case 7:
					num3--;
					num2 = 1663609796;
					continue;
				case 0:
					actionElementMap = wIadyhEVxiJaWeDEsznpytUcfFE[num3];
					num2 = 1663609799;
					continue;
				case 1:
				{
					int num4;
					if (num3 < 0)
					{
						num2 = 1663609795;
						num4 = num2;
					}
					else
					{
						num2 = 1663609797;
						num4 = num2;
					}
					continue;
				}
				case 8:
					return false;
				case 3:
					num3 = num - 1;
					num2 = 1663609796;
					continue;
				default:
					return result;
				}
				break;
			}
			goto IL_002e;
		}

		public int SetAllButtonMapsEnabled(bool state)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return 0;
			}
			int num = 0;
			int count = wIadyhEVxiJaWeDEsznpytUcfFE.Count;
			int num3 = default(int);
			while (true)
			{
				int num2 = 57498629;
				while (true)
				{
					switch (num2 ^ 0x36D5C07)
					{
					case 5:
						break;
					case 2:
						num3 = 0;
						num2 = 57498631;
						continue;
					case 1:
						num++;
						num2 = 57498627;
						continue;
					case 4:
						num3++;
						num2 = 57498631;
						continue;
					case 3:
					{
						ActionElementMap actionElementMap = wIadyhEVxiJaWeDEsznpytUcfFE[num3];
						if (actionElementMap.FnzJwrQpikWfZbmfjZhFwutJGAA != state)
						{
							actionElementMap.FnzJwrQpikWfZbmfjZhFwutJGAA = state;
							num2 = 57498630;
							continue;
						}
						goto case 4;
					}
					default:
						if (num3 >= count)
						{
							return num;
						}
						goto case 3;
					}
					break;
				}
			}
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
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				goto IL_0010;
			}
			if (controllerMap == null)
			{
				return false;
			}
			int num;
			if (skipDisabledMaps)
			{
				if (!_enabled)
				{
					goto IL_008d;
				}
				if (!controllerMap._enabled)
				{
					num = -2001853583;
					goto IL_0015;
				}
			}
			if (wIadyhEVxiJaWeDEsznpytUcfFE == null)
			{
				return false;
			}
			IList<ActionElementMap> buttonMaps = controllerMap.ButtonMaps;
			if (buttonMaps == null)
			{
				return false;
			}
			int num2 = buttonMapCount;
			int count = buttonMaps.Count;
			num = -2001853569;
			goto IL_0015;
			IL_008d:
			return false;
			IL_0010:
			num = -2001853576;
			goto IL_0015;
			IL_0015:
			int num3 = default(int);
			int num4 = default(int);
			ActionElementMap actionElementMap = default(ActionElementMap);
			ActionElementMap actionElementMap2 = default(ActionElementMap);
			while (true)
			{
				switch (num ^ -2001853575)
				{
				case 13:
					break;
				case 9:
					goto IL_005d;
				case 5:
					goto IL_0077;
				case 8:
					goto IL_008d;
				case 12:
					num = -2001853572;
					continue;
				case 6:
					num3 = 0;
					num = -2001853573;
					continue;
				case 0:
					num4 = 0;
					num = -2001853579;
					continue;
				case 10:
					goto IL_00e0;
				case 3:
					goto IL_0103;
				case 1:
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
					return false;
				case 11:
					goto IL_0153;
				case 4:
					num3++;
					num = -2001853573;
					continue;
				case 7:
					actionElementMap = wIadyhEVxiJaWeDEsznpytUcfFE[num3];
					num = -2001853574;
					continue;
				default:
					if (num3 >= num2)
					{
						return false;
					}
					goto case 7;
				}
				break;
				IL_0153:
				actionElementMap2 = buttonMaps[num4];
				if (!skipDisabledMaps)
				{
					goto IL_00e0;
				}
				if (actionElementMap2.FnzJwrQpikWfZbmfjZhFwutJGAA)
				{
					num = -2001853581;
					continue;
				}
				goto IL_00f3;
				IL_00e0:
				if (actionElementMap != actionElementMap2 && actionElementMap.CheckForAssignmentConflict(actionElementMap2))
				{
					return true;
				}
				goto IL_00f3;
				IL_0077:
				int num5;
				if (num4 >= count)
				{
					num = -2001853571;
					num5 = num;
				}
				else
				{
					num = -2001853582;
					num5 = num;
				}
				continue;
				IL_0103:
				int num6;
				if (!skipDisabledMaps)
				{
					num = -2001853575;
					num6 = num;
				}
				else
				{
					num = -2001853584;
					num6 = num;
				}
				continue;
				IL_005d:
				int num7;
				if (!actionElementMap.FnzJwrQpikWfZbmfjZhFwutJGAA)
				{
					num = -2001853571;
					num7 = num;
				}
				else
				{
					num = -2001853575;
					num7 = num;
				}
				continue;
				IL_00f3:
				num4++;
				num = -2001853572;
			}
			goto IL_0010;
		}

		public virtual bool DoesElementAssignmentConflict(ActionElementMap actionElementMap, bool skipDisabledMaps)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return false;
			}
			int num;
			if (actionElementMap != null)
			{
				if (wIadyhEVxiJaWeDEsznpytUcfFE == null)
				{
					goto IL_0026;
				}
				if (skipDisabledMaps)
				{
					int num2;
					if (_enabled)
					{
						num = 2105185597;
						num2 = num;
					}
					else
					{
						num = 2105185586;
						num2 = num;
					}
					goto IL_002b;
				}
				goto IL_0065;
			}
			goto IL_0091;
			IL_0091:
			return false;
			IL_0026:
			num = 2105185584;
			goto IL_002b;
			IL_002b:
			int num3 = default(int);
			ActionElementMap actionElementMap2 = default(ActionElementMap);
			while (true)
			{
				switch (num ^ 0x7D7A9534)
				{
				case 5:
					break;
				case 6:
					return false;
				case 9:
					goto IL_006e;
				case 2:
					return true;
				case 1:
					num = 2105185591;
					continue;
				case 4:
					goto IL_0091;
				case 8:
					goto IL_00b2;
				case 7:
					goto IL_00d6;
				case 0:
					goto IL_00ed;
				default:
					if (num3 >= wIadyhEVxiJaWeDEsznpytUcfFE.Count)
					{
						return false;
					}
					goto IL_00b2;
				}
				break;
				IL_00ed:
				if (actionElementMap2.FnzJwrQpikWfZbmfjZhFwutJGAA)
				{
					num = 2105185587;
					continue;
				}
				goto IL_007f;
				IL_007f:
				num3++;
				num = 2105185591;
				continue;
				IL_00d6:
				if (actionElementMap2 != actionElementMap && actionElementMap2.CheckForAssignmentConflict(actionElementMap))
				{
					num = 2105185590;
					continue;
				}
				goto IL_007f;
				IL_00b2:
				actionElementMap2 = wIadyhEVxiJaWeDEsznpytUcfFE[num3];
				int num4;
				if (skipDisabledMaps)
				{
					num = 2105185588;
					num4 = num;
				}
				else
				{
					num = 2105185587;
					num4 = num;
				}
				continue;
				IL_006e:
				if (!actionElementMap.FnzJwrQpikWfZbmfjZhFwutJGAA)
				{
					num = 2105185586;
					continue;
				}
				goto IL_0065;
			}
			goto IL_0026;
			IL_0065:
			num3 = 0;
			num = 2105185589;
			goto IL_002b;
		}

		public virtual bool DoesElementAssignmentConflict(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				goto IL_0010;
			}
			if (wIadyhEVxiJaWeDEsznpytUcfFE == null)
			{
				return false;
			}
			if (skipDisabledMaps && !_enabled)
			{
				return false;
			}
			int num;
			ElementAssignment elementAssignment = default(ElementAssignment);
			int num2 = default(int);
			if (conflictCheck.elementAssignmentType != ElementAssignmentType.Button && conflictCheck.elementAssignmentType != ElementAssignmentType.KeyboardKey)
			{
				num = -255659982;
			}
			else
			{
				elementAssignment = conflictCheck.ToElementAssignment();
				num2 = 0;
				num = -255659978;
			}
			goto IL_0015;
			IL_0015:
			ActionElementMap actionElementMap = default(ActionElementMap);
			while (true)
			{
				switch (num ^ -255659977)
				{
				case 8:
					break;
				case 0:
					if (actionElementMap.tqPurZpByiUWRrPJKwHxxaZZua != conflictCheck.elementMapId && actionElementMap.CheckForAssignmentConflict(elementAssignment))
					{
						return true;
					}
					goto IL_0067;
				case 6:
				{
					actionElementMap = wIadyhEVxiJaWeDEsznpytUcfFE[num2];
					int num3;
					if (!skipDisabledMaps)
					{
						num = -255659977;
						num3 = num;
					}
					else
					{
						num = -255659970;
						num3 = num;
					}
					continue;
				}
				case 4:
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
					num = -255659980;
					continue;
				case 1:
					num = -255659984;
					continue;
				case 3:
					return false;
				case 7:
				{
					int num4;
					if (num2 >= wIadyhEVxiJaWeDEsznpytUcfFE.Count)
					{
						num = -255659979;
						num4 = num;
					}
					else
					{
						num = -255659983;
						num4 = num;
					}
					continue;
				}
				case 9:
					if (actionElementMap.FnzJwrQpikWfZbmfjZhFwutJGAA)
					{
						num = -255659977;
						continue;
					}
					goto IL_0067;
				case 5:
					return false;
				default:
					{
						return false;
					}
					IL_0067:
					num2++;
					num = -255659984;
					continue;
				}
				break;
			}
			goto IL_0010;
			IL_0010:
			num = -255659981;
			goto IL_0015;
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
			XDIzbraqsYelFFnVnyzwdPQTrhEw xDIzbraqsYelFFnVnyzwdPQTrhEw = new XDIzbraqsYelFFnVnyzwdPQTrhEw(-2);
			xDIzbraqsYelFFnVnyzwdPQTrhEw.syCPfFbHYMDOvEPjTnPLBqiOhsPv = this;
			xDIzbraqsYelFFnVnyzwdPQTrhEw.IoOMsTyRkHoaIqFFqOwszJSmHpc = controllerMap;
			xDIzbraqsYelFFnVnyzwdPQTrhEw.dGwSNihzjCwVEkHXFGPpgtHVneEu = skipDisabledMaps;
			return xDIzbraqsYelFFnVnyzwdPQTrhEw;
		}

		public virtual IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ActionElementMap actionElementMap, bool skipDisabledMaps)
		{
			mwOGpRjlpahWeicVVcgBfcoGVUzu mwOGpRjlpahWeicVVcgBfcoGVUzu2 = new mwOGpRjlpahWeicVVcgBfcoGVUzu(-2);
			mwOGpRjlpahWeicVVcgBfcoGVUzu2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = this;
			mwOGpRjlpahWeicVVcgBfcoGVUzu2.MHovrJIJgVIzkhRuYJVtkcLlDWhe = actionElementMap;
			mwOGpRjlpahWeicVVcgBfcoGVUzu2.dGwSNihzjCwVEkHXFGPpgtHVneEu = skipDisabledMaps;
			return mwOGpRjlpahWeicVVcgBfcoGVUzu2;
		}

		public virtual IEnumerable<ElementAssignmentConflictInfo> ElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
		{
			lEAmGyBdDVvVCyOCPzlMvcTjQOp lEAmGyBdDVvVCyOCPzlMvcTjQOp2 = new lEAmGyBdDVvVCyOCPzlMvcTjQOp(-2);
			while (true)
			{
				int num = 495360742;
				while (true)
				{
					switch (num ^ 0x1D869AE7)
					{
					case 2:
						break;
					case 1:
						goto IL_0026;
					default:
						lEAmGyBdDVvVCyOCPzlMvcTjQOp2.dGwSNihzjCwVEkHXFGPpgtHVneEu = skipDisabledMaps;
						return lEAmGyBdDVvVCyOCPzlMvcTjQOp2;
					}
					break;
					IL_0026:
					lEAmGyBdDVvVCyOCPzlMvcTjQOp2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = this;
					lEAmGyBdDVvVCyOCPzlMvcTjQOp2.xMLCmAAGOtcBvnIylDFdJWNwMnF = conflictCheck;
					num = 495360743;
				}
			}
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
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				goto IL_001c;
			}
			if (controllerMap == null)
			{
				return 0;
			}
			int num;
			if (skipDisabledMaps)
			{
				int num2;
				if (_enabled)
				{
					num = 1984788073;
					num2 = num;
				}
				else
				{
					num = 1984788077;
					num2 = num;
				}
				goto IL_0021;
			}
			goto IL_0187;
			IL_0021:
			ActionElementMap actionElementMap = default(ActionElementMap);
			int num4 = default(int);
			int num5 = default(int);
			int num3 = default(int);
			int count = default(int);
			IList<ActionElementMap> list = default(IList<ActionElementMap>);
			while (true)
			{
				switch (num ^ 0x764D7660)
				{
				case 5:
					break;
				case 17:
					goto IL_007d;
				case 8:
					actionElementMap = wIadyhEVxiJaWeDEsznpytUcfFE[num4];
					if (skipDisabledMaps)
					{
						goto IL_00a3;
					}
					goto case 1;
				case 12:
					num5++;
					num = 1984788071;
					continue;
				case 0:
					QIfwVXGJCVNYMvqEWdTbgGcJiJX(actionElementMap.tqPurZpByiUWRrPJKwHxxaZZua, num4);
					num3++;
					num = 1984788066;
					continue;
				case 3:
					goto IL_00ed;
				case 1:
					num5 = 0;
					num = 1984788071;
					continue;
				case 6:
					num = 1984788068;
					continue;
				case 9:
					goto IL_0127;
				case 14:
					return num3;
				case 2:
					num = 1984788082;
					continue;
				case 4:
					goto IL_016c;
				case 13:
					return 0;
				case 16:
					return num3;
				case 10:
					return 0;
				case 11:
					goto IL_01fb;
				case 7:
					goto IL_0220;
				case 18:
					num4--;
					num = 1984788068;
					continue;
				default:
					return num3;
				}
				break;
				IL_0220:
				int num6;
				if (num5 < count)
				{
					num = 1984788081;
					num6 = num;
				}
				else
				{
					num = 1984788082;
					num6 = num;
				}
				continue;
				IL_0127:
				if (!controllerMap._enabled)
				{
					num = 1984788077;
					continue;
				}
				goto IL_0187;
				IL_007d:
				int num7;
				if (skipDisabledMaps)
				{
					num = 1984788067;
					num7 = num;
				}
				else
				{
					num = 1984788075;
					num7 = num;
				}
				continue;
				IL_01fb:
				int num8;
				if (actionElementMap.CheckForAssignmentConflict(list[num5]))
				{
					num = 1984788064;
					num8 = num;
				}
				else
				{
					num = 1984788076;
					num8 = num;
				}
				continue;
				IL_00ed:
				int num9;
				if (list[num5].FnzJwrQpikWfZbmfjZhFwutJGAA)
				{
					num = 1984788075;
					num9 = num;
				}
				else
				{
					num = 1984788076;
					num9 = num;
				}
				continue;
				IL_00a3:
				int num10;
				if (actionElementMap.FnzJwrQpikWfZbmfjZhFwutJGAA)
				{
					num = 1984788065;
					num10 = num;
				}
				else
				{
					num = 1984788082;
					num10 = num;
				}
				continue;
				IL_016c:
				int num11;
				if (num4 >= 0)
				{
					num = 1984788072;
					num11 = num;
				}
				else
				{
					num = 1984788079;
					num11 = num;
				}
			}
			goto IL_001c;
			IL_0187:
			num3 = 0;
			if (wIadyhEVxiJaWeDEsznpytUcfFE == null)
			{
				return num3;
			}
			list = controllerMap.wIadyhEVxiJaWeDEsznpytUcfFE;
			if (list == null)
			{
				num = 1984788080;
			}
			else
			{
				InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(_categoryId);
				if (mapCategory == null || mapCategory.userAssignable)
				{
					_ = buttonMapCount;
					count = list.Count;
					num4 = wIadyhEVxiJaWeDEsznpytUcfFE.Count - 1;
					num = 1984788070;
				}
				else
				{
					num = 1984788078;
				}
			}
			goto IL_0021;
			IL_001c:
			num = 1984788074;
			goto IL_0021;
		}

		public virtual int RemoveElementAssignmentConflicts(ActionElementMap actionElementMap, bool skipDisabledMaps)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return 0;
			}
			if (actionElementMap == null)
			{
				return 0;
			}
			if (skipDisabledMaps)
			{
				if (!_enabled)
				{
					goto IL_00c1;
				}
				if (!actionElementMap.FnzJwrQpikWfZbmfjZhFwutJGAA)
				{
					goto IL_003c;
				}
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
			if (wIadyhEVxiJaWeDEsznpytUcfFE == null)
			{
				return num;
			}
			int num2 = wIadyhEVxiJaWeDEsznpytUcfFE.Count - 1;
			int num3 = 1557259890;
			goto IL_0041;
			IL_0041:
			ActionElementMap actionElementMap2 = default(ActionElementMap);
			while (true)
			{
				switch (num3 ^ 0x5CD1E677)
				{
				case 2:
					break;
				case 4:
					if (actionElementMap2.CheckForAssignmentConflict(actionElementMap))
					{
						QIfwVXGJCVNYMvqEWdTbgGcJiJX(actionElementMap2.tqPurZpByiUWRrPJKwHxxaZZua, num2);
						num++;
						num3 = 1557259889;
						continue;
					}
					goto case 6;
				case 5:
					num3 = 1557259892;
					continue;
				case 0:
					actionElementMap2 = wIadyhEVxiJaWeDEsznpytUcfFE[num2];
					if (!skipDisabledMaps)
					{
						goto case 4;
					}
					goto IL_00a8;
				case 1:
					goto IL_00c1;
				case 6:
					num2--;
					num3 = 1557259892;
					continue;
				default:
					if (num2 < 0)
					{
						return num;
					}
					goto case 0;
				}
				break;
				IL_00a8:
				int num4;
				if (actionElementMap2.FnzJwrQpikWfZbmfjZhFwutJGAA)
				{
					num3 = 1557259891;
					num4 = num3;
				}
				else
				{
					num3 = 1557259889;
					num4 = num3;
				}
			}
			goto IL_003c;
			IL_00c1:
			return 0;
			IL_003c:
			num3 = 1557259894;
			goto IL_0041;
		}

		public virtual int RemoveElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				goto IL_001c;
			}
			int num;
			if (!skipDisabledMaps || _enabled)
			{
				if (wIadyhEVxiJaWeDEsznpytUcfFE == null)
				{
					return 0;
				}
				if (conflictCheck.elementAssignmentType == ElementAssignmentType.Button)
				{
					goto IL_009e;
				}
				num = -1985447061;
			}
			else
			{
				num = -1985447064;
			}
			goto IL_0021;
			IL_0021:
			ActionElementMap actionElementMap = default(ActionElementMap);
			ElementAssignment elementAssignment = default(ElementAssignment);
			int num2 = default(int);
			int num3 = default(int);
			while (true)
			{
				switch (num ^ -1985447072)
				{
				case 6:
					break;
				case 9:
					num = -1985447072;
					continue;
				case 10:
					if (actionElementMap.CheckForAssignmentConflict(elementAssignment))
					{
						QIfwVXGJCVNYMvqEWdTbgGcJiJX(actionElementMap.tqPurZpByiUWRrPJKwHxxaZZua, num2);
						num3++;
						num = -1985447070;
						continue;
					}
					goto case 2;
				case 11:
					goto IL_0092;
				case 3:
					num3 = 0;
					num = -1985447060;
					continue;
				case 8:
					return 0;
				case 12:
					num2 = wIadyhEVxiJaWeDEsznpytUcfFE.Count - 1;
					num = -1985447063;
					continue;
				case 2:
					num2--;
					num = -1985447072;
					continue;
				case 1:
					goto IL_011b;
				case 5:
					goto IL_0149;
				case 4:
					return 0;
				case 7:
					return 0;
				default:
					if (num2 < 0)
					{
						return num3;
					}
					goto IL_011b;
				}
				break;
				IL_011b:
				actionElementMap = wIadyhEVxiJaWeDEsznpytUcfFE[num2];
				if (skipDisabledMaps)
				{
					int num4;
					if (!actionElementMap.FnzJwrQpikWfZbmfjZhFwutJGAA)
					{
						num = -1985447070;
						num4 = num;
					}
					else
					{
						num = -1985447067;
						num4 = num;
					}
					continue;
				}
				goto IL_0149;
				IL_0149:
				int num5;
				if (actionElementMap.tqPurZpByiUWRrPJKwHxxaZZua == conflictCheck.elementMapId)
				{
					num = -1985447070;
					num5 = num;
				}
				else
				{
					num = -1985447062;
					num5 = num;
				}
			}
			goto IL_001c;
			IL_0092:
			if (conflictCheck.elementAssignmentType != ElementAssignmentType.KeyboardKey)
			{
				return 0;
			}
			goto IL_009e;
			IL_001c:
			num = -1985447065;
			goto IL_0021;
			IL_009e:
			InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(_categoryId);
			if (mapCategory == null)
			{
				return 0;
			}
			if (!mapCategory.userAssignable)
			{
				num = -1985447068;
			}
			else
			{
				elementAssignment = conflictCheck.ToElementAssignment();
				num = -1985447069;
			}
			goto IL_0021;
		}

		public int DisableElementAssignmentConflicts(ControllerMap controllerMap)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return 0;
			}
			return WbvRWRvuCYHObvwPFuFTXzUWknL(controllerMap, false, null, false);
		}

		public int DisableElementAssignmentConflicts(ActionElementMap actionElementMap)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return 0;
			}
			return WbvRWRvuCYHObvwPFuFTXzUWknL(actionElementMap, false, null, false);
		}

		public int DisableElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return 0;
			}
			return WbvRWRvuCYHObvwPFuFTXzUWknL(conflictCheck, false, null, false);
		}

		public int DisableElementAssignmentConflicts(ControllerMap controllerMap, bool skipDisabledMaps)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return 0;
			}
			return WbvRWRvuCYHObvwPFuFTXzUWknL(controllerMap, skipDisabledMaps, null, false);
		}

		public int DisableElementAssignmentConflicts(ActionElementMap actionElementMap, bool skipDisabledMaps)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return 0;
			}
			return WbvRWRvuCYHObvwPFuFTXzUWknL(actionElementMap, skipDisabledMaps, null, false);
		}

		public int DisableElementAssignmentConflicts(ElementAssignmentConflictCheck conflictCheck, bool skipDisabledMaps)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return 0;
			}
			return WbvRWRvuCYHObvwPFuFTXzUWknL(conflictCheck, skipDisabledMaps, null, false);
		}

		internal virtual int WbvRWRvuCYHObvwPFuFTXzUWknL(ControllerMap P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			if (P_2 != null && !P_3)
			{
				goto IL_000d;
			}
			goto IL_0127;
			IL_0127:
			if (P_0 == null)
			{
				return 0;
			}
			int num;
			if (P_1)
			{
				if (!_enabled)
				{
					goto IL_00d3;
				}
				if (!P_0._enabled)
				{
					num = -107744097;
					goto IL_0012;
				}
			}
			int num2 = 0;
			if (wIadyhEVxiJaWeDEsznpytUcfFE == null)
			{
				return num2;
			}
			IList<ActionElementMap> list = P_0.wIadyhEVxiJaWeDEsznpytUcfFE;
			if (list == null)
			{
				return num2;
			}
			InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(_categoryId);
			if (mapCategory != null && !mapCategory.userAssignable)
			{
				return num2;
			}
			int num3 = buttonMapCount;
			int count = list.Count;
			int num4 = 0;
			num = -107744107;
			goto IL_0012;
			IL_000d:
			num = -107744112;
			goto IL_0012;
			IL_0012:
			int num5 = default(int);
			ActionElementMap actionElementMap = default(ActionElementMap);
			ActionElementMap actionElementMap2 = default(ActionElementMap);
			while (true)
			{
				switch (num ^ -107744111)
				{
				case 11:
					break;
				case 7:
					num5 = 0;
					num = -107744111;
					continue;
				case 13:
					goto IL_0070;
				case 2:
					num4++;
					num = -107744107;
					continue;
				case 0:
					goto IL_009a;
				case 15:
					goto IL_00b4;
				case 14:
					goto IL_00d3;
				case 3:
					goto IL_0127;
				case 4:
					goto IL_0149;
				case 10:
					P_2.Add(actionElementMap);
					num = -107744103;
					continue;
				case 6:
					num5++;
					num = -107744111;
					continue;
				case 8:
					num2++;
					num = -107744109;
					continue;
				case 12:
					goto IL_0192;
				case 5:
					goto IL_01b3;
				case 1:
					P_2.Clear();
					num = -107744110;
					continue;
				case 9:
					goto IL_01ef;
				default:
					return num2;
				}
				break;
				IL_01ef:
				actionElementMap.enabled = false;
				int num6;
				if (P_2 == null)
				{
					num = -107744103;
					num6 = num;
				}
				else
				{
					num = -107744101;
					num6 = num;
				}
				continue;
				IL_0070:
				int num7;
				if (actionElementMap2.FnzJwrQpikWfZbmfjZhFwutJGAA)
				{
					num = -107744098;
					num7 = num;
				}
				else
				{
					num = -107744105;
					num7 = num;
				}
				continue;
				IL_00b4:
				int num8;
				if (!actionElementMap.CheckForAssignmentConflict(actionElementMap2))
				{
					num = -107744105;
					num8 = num;
				}
				else
				{
					num = -107744104;
					num8 = num;
				}
				continue;
				IL_01b3:
				actionElementMap = wIadyhEVxiJaWeDEsznpytUcfFE[num4];
				int num9;
				if (!actionElementMap.FnzJwrQpikWfZbmfjZhFwutJGAA)
				{
					num = -107744109;
					num9 = num;
				}
				else
				{
					num = -107744106;
					num9 = num;
				}
				continue;
				IL_0149:
				int num10;
				if (num4 >= num3)
				{
					num = -107744127;
					num10 = num;
				}
				else
				{
					num = -107744108;
					num10 = num;
				}
				continue;
				IL_009a:
				int num11;
				if (num5 >= count)
				{
					num = -107744109;
					num11 = num;
				}
				else
				{
					num = -107744099;
					num11 = num;
				}
				continue;
				IL_0192:
				actionElementMap2 = list[num5];
				int num12;
				if (!P_1)
				{
					num = -107744098;
					num12 = num;
				}
				else
				{
					num = -107744100;
					num12 = num;
				}
			}
			goto IL_000d;
			IL_00d3:
			return 0;
		}

		internal virtual int WbvRWRvuCYHObvwPFuFTXzUWknL(ActionElementMap P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			if (P_2 != null && !P_3)
			{
				goto IL_000d;
			}
			goto IL_0138;
			IL_0138:
			int num;
			if (P_0 != null)
			{
				if (!P_1)
				{
					goto IL_0064;
				}
				num = -182742921;
			}
			else
			{
				num = -182742924;
			}
			goto IL_0012;
			IL_000d:
			num = -182742919;
			goto IL_0012;
			IL_0012:
			int num2 = default(int);
			ActionElementMap actionElementMap = default(ActionElementMap);
			int num3 = default(int);
			int num5 = default(int);
			InputMapCategory mapCategory = default(InputMapCategory);
			while (true)
			{
				switch (num ^ -182742916)
				{
				case 9:
					break;
				case 15:
					return 0;
				case 10:
					num2++;
					num = -182742917;
					continue;
				case 8:
					return 0;
				case 6:
					num = -182742920;
					continue;
				case 2:
					P_2.Add(actionElementMap);
					num = -182742922;
					continue;
				case 7:
					num3++;
					num = -182742920;
					continue;
				case 14:
					goto IL_00d0;
				case 12:
					goto IL_00fb;
				case 13:
					goto IL_0119;
				case 1:
					goto IL_0138;
				case 5:
					P_2.Clear();
					num = -182742915;
					continue;
				case 0:
					goto IL_0158;
				case 4:
					goto IL_017a;
				case 11:
					if (!_enabled)
					{
						goto case 15;
					}
					goto IL_019d;
				default:
					return num2;
				}
				break;
				IL_019d:
				if (!P_0.FnzJwrQpikWfZbmfjZhFwutJGAA)
				{
					num = -182742925;
					continue;
				}
				goto IL_0064;
				IL_00d0:
				actionElementMap = wIadyhEVxiJaWeDEsznpytUcfFE[num3];
				int num4;
				if (!actionElementMap.FnzJwrQpikWfZbmfjZhFwutJGAA)
				{
					num = -182742917;
					num4 = num;
				}
				else
				{
					num = -182742928;
					num4 = num;
				}
				continue;
				IL_017a:
				int num6;
				if (num3 >= num5)
				{
					num = -182742913;
					num6 = num;
				}
				else
				{
					num = -182742926;
					num6 = num;
				}
				continue;
				IL_0119:
				actionElementMap.enabled = false;
				int num7;
				if (P_2 == null)
				{
					num = -182742922;
					num7 = num;
				}
				else
				{
					num = -182742914;
					num7 = num;
				}
				continue;
				IL_00fb:
				int num8;
				if (!P_0.CheckForAssignmentConflict(actionElementMap))
				{
					num = -182742917;
					num8 = num;
				}
				else
				{
					num = -182742927;
					num8 = num;
				}
				continue;
				IL_0158:
				if (mapCategory == null)
				{
					return num2;
				}
				if (!mapCategory.userAssignable)
				{
					return num2;
				}
				num5 = buttonMapCount;
				num3 = 0;
				num = -182742918;
			}
			goto IL_000d;
			IL_0064:
			num2 = 0;
			if (P_0.elementIdentifierId < 0)
			{
				return num2;
			}
			mapCategory = ReInput.mapping.GetMapCategory(_categoryId);
			num = -182742916;
			goto IL_0012;
		}

		internal virtual int WbvRWRvuCYHObvwPFuFTXzUWknL(ElementAssignmentConflictCheck P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			if (P_2 != null && !P_3)
			{
				P_2.Clear();
				goto IL_0013;
			}
			goto IL_00d1;
			IL_0018:
			int num;
			ActionElementMap actionElementMap = default(ActionElementMap);
			int num2 = default(int);
			int num4 = default(int);
			int num3 = default(int);
			ElementAssignment elementAssignment = default(ElementAssignment);
			InputMapCategory mapCategory = default(InputMapCategory);
			while (true)
			{
				switch (num ^ -172364690)
				{
				case 2:
					break;
				case 10:
					actionElementMap = wIadyhEVxiJaWeDEsznpytUcfFE[num2];
					num = -172364694;
					continue;
				case 1:
					P_2.Add(actionElementMap);
					num = -172364702;
					continue;
				case 6:
					goto IL_0081;
				case 5:
					goto IL_00a4;
				case 12:
					num4++;
					num = -172364697;
					continue;
				case 7:
					goto IL_00d1;
				case 9:
					num2++;
					num = -172364691;
					continue;
				case 8:
					return 0;
				case 4:
					if (!actionElementMap.FnzJwrQpikWfZbmfjZhFwutJGAA || actionElementMap.tqPurZpByiUWRrPJKwHxxaZZua == P_0.elementMapId)
					{
						goto case 9;
					}
					goto IL_014c;
				case 11:
					num3 = buttonMapCount;
					num = -172364690;
					continue;
				case 0:
					num2 = 0;
					num = -172364691;
					continue;
				default:
					if (num2 >= num3)
					{
						return num4;
					}
					goto case 10;
				}
				break;
				IL_014c:
				int num5;
				if (actionElementMap.CheckForAssignmentConflict(elementAssignment))
				{
					num = -172364693;
					num5 = num;
				}
				else
				{
					num = -172364697;
					num5 = num;
				}
				continue;
				IL_00a4:
				actionElementMap.enabled = false;
				int num6;
				if (P_2 == null)
				{
					num = -172364702;
					num6 = num;
				}
				else
				{
					num = -172364689;
					num6 = num;
				}
				continue;
				IL_0081:
				if (mapCategory == null)
				{
					return 0;
				}
				if (!mapCategory.userAssignable)
				{
					return 0;
				}
				elementAssignment = P_0.ToElementAssignment();
				num4 = 0;
				num = -172364699;
			}
			goto IL_0013;
			IL_00d1:
			if (P_1 && !_enabled)
			{
				num = -172364698;
			}
			else
			{
				if (wIadyhEVxiJaWeDEsznpytUcfFE == null)
				{
					return 0;
				}
				if (P_0.elementAssignmentType != ElementAssignmentType.Button && P_0.elementAssignmentType != ElementAssignmentType.KeyboardKey)
				{
					return 0;
				}
				mapCategory = ReInput.mapping.GetMapCategory(_categoryId);
				num = -172364696;
			}
			goto IL_0018;
			IL_0013:
			num = -172364695;
			goto IL_0018;
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
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				goto IL_001c;
			}
			if (actionToPerform == null)
			{
				throw new ArgumentNullException("actionToPerform");
			}
			goto IL_0186;
			IL_0065:
			return 0;
			IL_0186:
			int num;
			int num2 = default(int);
			IList<ActionElementMap> zYwIXqAucYgKRZdCmuiIHmWLQlA = default(IList<ActionElementMap>);
			int count = default(int);
			if (controllerMap != null)
			{
				if (skipDisabledMaps)
				{
					if (!_enabled)
					{
						goto IL_0065;
					}
					if (!controllerMap._enabled)
					{
						num = 2117774782;
						goto IL_0021;
					}
				}
				num2 = 0;
				if (ZYwIXqAucYgKRZdCmuiIHmWLQlA == null)
				{
					return num2;
				}
				zYwIXqAucYgKRZdCmuiIHmWLQlA = controllerMap.ZYwIXqAucYgKRZdCmuiIHmWLQlA;
				if (zYwIXqAucYgKRZdCmuiIHmWLQlA == null)
				{
					return num2;
				}
				InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(_categoryId);
				if (mapCategory != null && !mapCategory.userAssignable)
				{
					num = 2117774775;
				}
				else
				{
					count = zYwIXqAucYgKRZdCmuiIHmWLQlA.Count;
					num = 2117774781;
				}
			}
			else
			{
				num = 2117774769;
			}
			goto IL_0021;
			IL_0021:
			int num3 = default(int);
			ActionElementMap actionElementMap = default(ActionElementMap);
			int num5 = default(int);
			while (true)
			{
				int num4;
				switch (num ^ 0x7E3AADB5)
				{
				case 10:
					break;
				case 11:
					goto IL_0065;
				case 6:
					if (zYwIXqAucYgKRZdCmuiIHmWLQlA[num3].FnzJwrQpikWfZbmfjZhFwutJGAA)
					{
						num = 2117774774;
						continue;
					}
					goto IL_01f4;
				case 4:
					return 0;
				case 2:
					return num2;
				case 9:
					num3 = 0;
					goto IL_021d;
				case 1:
					return 0;
				case 7:
					goto IL_011f;
				case 0:
					if (!skipDisabledMaps)
					{
						goto case 9;
					}
					if (actionElementMap.FnzJwrQpikWfZbmfjZhFwutJGAA)
					{
						num = 2117774780;
						continue;
					}
					goto IL_0210;
				case 8:
					num5 = ZYwIXqAucYgKRZdCmuiIHmWLQlA.Count - 1;
					goto IL_0201;
				case 5:
					actionElementMap = ZYwIXqAucYgKRZdCmuiIHmWLQlA[num5];
					num = 2117774773;
					continue;
				case 12:
					goto IL_0186;
				default:
					{
						if (!actionElementMap.CheckForAssignmentConflict(zYwIXqAucYgKRZdCmuiIHmWLQlA[num3]))
						{
							goto IL_01f4;
						}
						try
						{
							actionToPerform(actionElementMap);
						}
						catch (Exception exception)
						{
							ReInput.HandleCallbackException("ControllerMap.ForEachElementAssignmentConflict", exception);
							return num2;
						}
						num2++;
						goto IL_0210;
					}
					IL_01cf:
					while (true)
					{
						switch (num4 ^ 0x7E3AADB5)
						{
						case 0:
							num4 = 2117774768;
							continue;
						case 5:
							break;
						case 1:
							goto IL_0201;
						case 3:
							goto IL_0210;
						case 4:
							goto IL_021d;
						default:
							return num2;
						}
						break;
					}
					goto IL_01f4;
					IL_021d:
					if (num3 < count)
					{
						goto IL_011f;
					}
					num4 = 2117774774;
					goto IL_01cf;
					IL_0210:
					num5--;
					num4 = 2117774772;
					goto IL_01cf;
					IL_0201:
					if (num5 >= 0)
					{
						goto case 5;
					}
					num4 = 2117774775;
					goto IL_01cf;
					IL_01f4:
					num3++;
					num4 = 2117774769;
					goto IL_01cf;
				}
				break;
				IL_011f:
				int num6;
				if (!skipDisabledMaps)
				{
					num = 2117774774;
					num6 = num;
				}
				else
				{
					num = 2117774771;
					num6 = num;
				}
			}
			goto IL_001c;
			IL_001c:
			num = 2117774772;
			goto IL_0021;
		}

		public int ForEachElementAssignmentConflict(ActionElementMap actionElementMap, Action<ActionElementMap> actionToPerform, bool skipDisabledMaps)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				goto IL_0010;
			}
			int num;
			int num2;
			if (actionToPerform != null)
			{
				num = -1969198087;
				num2 = num;
			}
			else
			{
				num = -1969198095;
				num2 = num;
			}
			goto IL_0015;
			IL_0010:
			num = -1969198088;
			goto IL_0015;
			IL_0015:
			int num3 = default(int);
			ActionElementMap actionElementMap2 = default(ActionElementMap);
			int num6 = default(int);
			while (true)
			{
				int num4;
				InputMapCategory mapCategory;
				switch (num ^ -1969198087)
				{
				case 4:
					break;
				case 6:
					return num3;
				case 5:
					actionElementMap2 = ZYwIXqAucYgKRZdCmuiIHmWLQlA[num6];
					if (!skipDisabledMaps)
					{
						goto default;
					}
					if (actionElementMap2.FnzJwrQpikWfZbmfjZhFwutJGAA)
					{
						num = -1969198096;
						continue;
					}
					goto IL_018f;
				case 8:
					throw new ArgumentNullException("actionToPerform");
				case 3:
					if (!actionElementMap.FnzJwrQpikWfZbmfjZhFwutJGAA)
					{
						num = -1969198085;
						continue;
					}
					goto IL_00ea;
				case 7:
				{
					int num5;
					if (_enabled)
					{
						num = -1969198086;
						num5 = num;
					}
					else
					{
						num = -1969198085;
						num5 = num;
					}
					continue;
				}
				case 2:
					return 0;
				case 1:
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
					return 0;
				case 0:
					if (actionElementMap == null)
					{
						return 0;
					}
					if (skipDisabledMaps)
					{
						num = -1969198082;
						continue;
					}
					goto IL_00ea;
				default:
					{
						if (actionElementMap2.CheckForAssignmentConflict(actionElementMap))
						{
							try
							{
								actionToPerform(actionElementMap2);
							}
							catch (Exception exception)
							{
								ReInput.HandleCallbackException("ControllerMap.ForEachElementAssignmentConflict", exception);
								return num3;
							}
							num3++;
							goto IL_016d;
						}
						goto IL_018f;
					}
					IL_016d:
					num4 = -1969198086;
					goto IL_0172;
					IL_018f:
					num6--;
					num4 = -1969198088;
					goto IL_0172;
					IL_00ea:
					num3 = 0;
					mapCategory = ReInput.mapping.GetMapCategory(_categoryId);
					if (mapCategory != null)
					{
						if (!mapCategory.userAssignable)
						{
							return num3;
						}
						if (ZYwIXqAucYgKRZdCmuiIHmWLQlA == null)
						{
							return num3;
						}
						num6 = ZYwIXqAucYgKRZdCmuiIHmWLQlA.Count - 1;
						goto IL_019a;
					}
					num = -1969198081;
					continue;
					IL_0172:
					switch (num4 ^ -1969198087)
					{
					case 0:
						break;
					case 3:
						goto IL_018f;
					case 1:
						goto IL_019a;
					default:
						return num3;
					}
					goto IL_016d;
					IL_019a:
					if (num6 >= 0)
					{
						goto case 5;
					}
					num4 = -1969198085;
					goto IL_0172;
				}
				break;
			}
			goto IL_0010;
		}

		public int ForEachElementAssignmentConflict(ElementAssignmentConflictCheck conflictCheck, Action<ActionElementMap> actionToPerform, bool skipDisabledMaps)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return 0;
			}
			if (actionToPerform == null)
			{
				throw new ArgumentNullException("actionToPerform");
			}
			ElementAssignment elementAssignment = default(ElementAssignment);
			int num3 = default(int);
			int num2 = default(int);
			ActionElementMap actionElementMap = default(ActionElementMap);
			while (true)
			{
				int num;
				if (skipDisabledMaps && !_enabled)
				{
					num = 517384413;
				}
				else if (ZYwIXqAucYgKRZdCmuiIHmWLQlA != null)
				{
					if (conflictCheck.elementAssignmentType != ElementAssignmentType.Button && conflictCheck.elementAssignmentType != ElementAssignmentType.KeyboardKey)
					{
						return 0;
					}
					InputMapCategory mapCategory = ReInput.mapping.GetMapCategory(_categoryId);
					if (mapCategory == null)
					{
						num = 517384409;
					}
					else
					{
						if (!mapCategory.userAssignable)
						{
							break;
						}
						elementAssignment = conflictCheck.ToElementAssignment();
						num = 517384403;
					}
				}
				else
				{
					num = 517384415;
				}
				while (true)
				{
					int num5;
					switch (num ^ 0x1ED6A8DB)
					{
					case 0:
						num = 517384408;
						continue;
					case 3:
						break;
					case 4:
						return 0;
					case 8:
						num3 = 0;
						num2 = ZYwIXqAucYgKRZdCmuiIHmWLQlA.Count - 1;
						num = 517384412;
						continue;
					case 5:
						actionElementMap = ZYwIXqAucYgKRZdCmuiIHmWLQlA[num2];
						if (!skipDisabledMaps)
						{
							goto default;
						}
						if (actionElementMap.FnzJwrQpikWfZbmfjZhFwutJGAA)
						{
							num = 517384410;
							continue;
						}
						goto IL_01aa;
					case 6:
						return 0;
					case 2:
						return 0;
					default:
						if (actionElementMap.tqPurZpByiUWRrPJKwHxxaZZua != conflictCheck.elementMapId && actionElementMap.CheckForAssignmentConflict(elementAssignment))
						{
							try
							{
								actionToPerform(actionElementMap);
							}
							catch (Exception exception)
							{
								while (true)
								{
									int num4 = 517384409;
									while (true)
									{
										switch (num4 ^ 0x1ED6A8DB)
										{
										case 0:
											break;
										case 2:
											goto IL_0170;
										default:
											return num3;
										}
										break;
										IL_0170:
										ReInput.HandleCallbackException("ControllerMap.ForEachElementAssignmentConflict", exception);
										num4 = 517384410;
									}
								}
							}
							num3++;
							goto IL_018c;
						}
						goto IL_01aa;
					case 7:
						goto IL_01b5;
						IL_01b5:
						if (num2 < 0)
						{
							return num3;
						}
						goto case 5;
						IL_018c:
						num5 = 517384410;
						goto IL_0191;
						IL_01aa:
						num2--;
						num5 = 517384411;
						goto IL_0191;
						IL_0191:
						switch (num5 ^ 0x1ED6A8DB)
						{
						case 2:
							break;
						case 1:
							goto IL_01aa;
						default:
							goto IL_01b5;
						}
						goto IL_018c;
					}
					break;
				}
			}
			return 0;
		}

		public string[] GetButtonNames()
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return EmptyObjects<string>.array;
			}
			int num = buttonMapCount;
			if (num == 0)
			{
				return new string[0];
			}
			string[] array = new string[num];
			int num2 = 0;
			while (num2 < num)
			{
				while (true)
				{
					array[num2] = wIadyhEVxiJaWeDEsznpytUcfFE[num2].elementIdentifierName;
					int num3 = -945498262;
					while (true)
					{
						switch (num3 ^ -945498263)
						{
						case 0:
							num3 = -945498261;
							continue;
						case 2:
							break;
						case 3:
							num2++;
							num3 = -945498264;
							continue;
						default:
							goto end_IL_005d;
						}
						break;
					}
					continue;
					end_IL_005d:
					break;
				}
			}
			return array;
		}

		public string ToXmlString()
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return string.Empty;
			}
			try
			{
				return mtMtVVrohwWTxFPivXmGbDyGevo().ToXmlString(writeDocumentTag: true);
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error writing " + GetType().Name + " to XML. " + ex.Message);
				return string.Empty;
			}
		}

		public string ToJsonString()
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return string.Empty;
			}
			string result = default(string);
			try
			{
				result = mtMtVVrohwWTxFPivXmGbDyGevo().ToJsonString();
			}
			catch (Exception ex)
			{
				while (true)
				{
					IL_002e:
					int num = -383482845;
					while (true)
					{
						switch (num ^ -383482847)
						{
						case 0:
							break;
						default:
							goto end_IL_0033;
						case 2:
							goto IL_004c;
						case 1:
							goto end_IL_0033;
						}
						goto IL_002e;
						IL_004c:
						Logger.LogWarning("Error writing " + GetType().Name + " to JSON. " + ex.Message);
						result = string.Empty;
						num = -383482848;
						continue;
						end_IL_0033:
						break;
					}
					break;
				}
			}
			return result;
		}

		public ControllerTemplateMap ToControllerTemplateMap(Guid templateTypeGuid)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				goto IL_000d;
			}
			int num;
			if (controller == null)
			{
				num = 1022553749;
				goto IL_0012;
			}
			IControllerTemplate controllerTemplate = controller.GetTemplate(templateTypeGuid) ?? (controller.GetTemplate(templateTypeGuid) as ControllerTemplate);
			if (controllerTemplate == null)
			{
				HardwareJoystickTemplateMap hardwareJoystickTemplateMap = ReInput.AkUcEkvnHgqlWfVhjztPFZUUQuC(templateTypeGuid);
				string text = ((hardwareJoystickTemplateMap != null) ? hardwareJoystickTemplateMap.ClassName : templateTypeGuid.ToString());
				Logger.LogError("The Controller does not implement " + text + ".", requiredThreadSafety: true);
				return null;
			}
			return ControllerTemplateMap.FromControllerMap(controllerTemplate, this);
			IL_0012:
			while (true)
			{
				switch (num ^ 0x3CF2EE97)
				{
				case 0:
					break;
				case 3:
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
					return null;
				case 2:
					goto IL_004c;
				default:
					return null;
				}
				break;
				IL_004c:
				Logger.LogError("The Controller Map is not associated with a Controller. This method can only be used with a Controller Map that is associated with a Controller.", requiredThreadSafety: true);
				num = 1022553750;
			}
			goto IL_000d;
			IL_000d:
			num = 1022553748;
			goto IL_0012;
		}

		public ControllerTemplateMap ToControllerTemplateMap<T>() where T : class
		{
			return ToControllerTemplateMap(typeof(T));
		}

		public ControllerTemplateMap ToControllerTemplateMap(Type templateInterfaceType)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return null;
			}
			if ((object)templateInterfaceType == null)
			{
				goto IL_001e;
			}
			goto IL_0052;
			IL_0052:
			int num;
			if (controller == null)
			{
				Logger.LogError("The Controller Map is not associated with a Controller. This method can only be used with a Controller Map that is associated with a Controller.", requiredThreadSafety: true);
				num = 1917818060;
				goto IL_0023;
			}
			IControllerTemplate controllerTemplate = controller.GetTemplate(templateInterfaceType) ?? (controller.GetTemplate(templateInterfaceType) as ControllerTemplate);
			if (controllerTemplate == null)
			{
				Logger.LogError("The Controller does not implement " + templateInterfaceType.Name + ".", requiredThreadSafety: true);
				return null;
			}
			return ControllerTemplateMap.FromControllerMap(controllerTemplate, this);
			IL_001e:
			num = 1917818062;
			goto IL_0023;
			IL_0023:
			switch (num ^ 0x724F94CF)
			{
			case 2:
				break;
			case 1:
				throw new ArgumentNullException("templateInterfaceType");
			case 0:
				goto IL_0052;
			default:
				return null;
			}
			goto IL_001e;
		}

		private ControllerTemplateMap MKKPohgDyVlGheCiiHancGvCDlHE(IControllerTemplate P_0)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				while (true)
				{
					switch (-2027307561 ^ -2027307562)
					{
					case 2:
						continue;
					case 1:
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						return null;
					}
					break;
				}
			}
			else if (P_0 == null)
			{
				throw new ArgumentNullException("controllerTemplate");
			}
			return ControllerTemplateMap.FromControllerMap(P_0, this);
		}

		internal virtual bool IXqmncltgmkzpGDZegTRdilkcDa(ActionElementMap P_0)
		{
			if (!RbfCKlONOukDglmWLTrDfcpWjpr(P_0._elementType))
			{
				return false;
			}
			fTDEdaCTYLvKLWSpZIBomPPJaZdF(P_0);
			return true;
		}

		internal virtual int xryeFZUsHaBNPgZaFhYIDuYBGQBe(List<ActionElementMap> P_0, bool P_1)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("results");
			}
			int num2 = default(int);
			int count2 = default(int);
			while (true)
			{
				int count = P_0.Count;
				int num = -2056764571;
				while (true)
				{
					switch (num ^ -2056764573)
					{
					case 5:
						num = -2056764574;
						continue;
					case 3:
						if (P_1)
						{
							int num3;
							if (wIadyhEVxiJaWeDEsznpytUcfFE[num2].FnzJwrQpikWfZbmfjZhFwutJGAA)
							{
								num = -2056764569;
								num3 = num;
							}
							else
							{
								num = -2056764575;
								num3 = num;
							}
							continue;
						}
						goto case 4;
					case 2:
						num2++;
						num = -2056764573;
						continue;
					case 4:
						P_0.Add(wIadyhEVxiJaWeDEsznpytUcfFE[num2]);
						num = -2056764575;
						continue;
					case 1:
						break;
					case 6:
						count2 = wIadyhEVxiJaWeDEsznpytUcfFE.Count;
						num2 = 0;
						num = -2056764573;
						continue;
					default:
						if (num2 >= count2)
						{
							return P_0.Count - count;
						}
						goto case 3;
					}
					break;
				}
			}
		}

		internal virtual ActionElementMap AbXIQcNwbGrSKXjFhbfxKsEAyOL(int P_0, int P_1, ControllerElementType P_2)
		{
			if (!RbfCKlONOukDglmWLTrDfcpWjpr(P_2))
			{
				return null;
			}
			int num = ANPJtlBGRteXSZvUmijGPmJbDIF(P_0, P_1, P_2);
			if (num < 0)
			{
				return null;
			}
			return wIadyhEVxiJaWeDEsznpytUcfFE[num];
		}

		internal virtual int bJrXXRgKUiqqJbRLFDjOAIGjdfPI(int P_0, List<ActionElementMap> P_1, bool P_2)
		{
			if (P_1 == null)
			{
				throw new ArgumentNullException("results");
			}
			int num4 = default(int);
			int num5 = default(int);
			while (true)
			{
				int num = 0;
				int num2;
				int num3;
				if (!P_2)
				{
					num2 = 793097064;
					num3 = num2;
				}
				else
				{
					num2 = 793097062;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ 0x2F45B360)
					{
					case 0:
						num2 = 793097060;
						continue;
					case 1:
						return 0;
					case 2:
					{
						int num6;
						if (num4 >= num5)
						{
							num2 = 793097065;
							num6 = num2;
						}
						else
						{
							num2 = 793097066;
							num6 = num2;
						}
						continue;
					}
					case 5:
						num2 = 793097059;
						continue;
					case 8:
						P_1.Clear();
						num2 = 793097061;
						continue;
					case 6:
						num = P_1.Count;
						num2 = 793097059;
						continue;
					case 4:
						break;
					case 3:
						if (wIadyhEVxiJaWeDEsznpytUcfFE != null)
						{
							num5 = buttonMapCount;
							num4 = 0;
							num2 = 793097058;
						}
						else
						{
							num2 = 793097057;
						}
						continue;
					case 7:
						num4++;
						num2 = 793097058;
						continue;
					case 10:
						if (wIadyhEVxiJaWeDEsznpytUcfFE[num4]._elementIdentifierId == P_0)
						{
							P_1.Add(wIadyhEVxiJaWeDEsznpytUcfFE[num4]);
							num2 = 793097063;
							continue;
						}
						goto case 7;
					default:
						return P_1.Count - num;
					}
					break;
				}
			}
		}

		internal virtual bool lWBNrKBhyyoCgkkLVyrJTgFYqbi(int P_0, int P_1, ControllerElementType P_2)
		{
			if (!RbfCKlONOukDglmWLTrDfcpWjpr(P_2))
			{
				return false;
			}
			int num = buttonMapCount;
			int num3 = default(int);
			while (true)
			{
				int num2 = 810606470;
				while (true)
				{
					switch (num2 ^ 0x3050DF82)
					{
					case 0:
						break;
					case 1:
						if (wIadyhEVxiJaWeDEsznpytUcfFE[num3]._elementIdentifierId == P_0 && wIadyhEVxiJaWeDEsznpytUcfFE[num3]._actionId == P_1)
						{
							return true;
						}
						num3++;
						num2 = 810606465;
						continue;
					case 2:
						num2 = 810606465;
						continue;
					case 4:
						num3 = 0;
						num2 = 810606464;
						continue;
					default:
						if (num3 >= num)
						{
							return false;
						}
						goto case 1;
					}
					break;
				}
			}
		}

		internal virtual int ANPJtlBGRteXSZvUmijGPmJbDIF(int P_0, int P_1, ControllerElementType P_2)
		{
			if (!RbfCKlONOukDglmWLTrDfcpWjpr(P_2))
			{
				return -1;
			}
			if (wIadyhEVxiJaWeDEsznpytUcfFE == null)
			{
				return -1;
			}
			int num = buttonMapCount;
			int num3 = default(int);
			while (true)
			{
				int num2 = -777146267;
				while (true)
				{
					switch (num2 ^ -777146266)
					{
					case 0:
						break;
					case 3:
						num3 = 0;
						num2 = -777146265;
						continue;
					case 2:
						if (wIadyhEVxiJaWeDEsznpytUcfFE[num3]._elementIdentifierId == P_0 && wIadyhEVxiJaWeDEsznpytUcfFE[num3]._actionId == P_1)
						{
							return num3;
						}
						num3++;
						num2 = -777146265;
						continue;
					default:
						if (num3 >= num)
						{
							return -1;
						}
						goto case 2;
					}
					break;
				}
			}
		}

		internal int IlopbsVZqaXKxFzedtchmLnQWik(int P_0)
		{
			if (wIadyhEVxiJaWeDEsznpytUcfFE == null)
			{
				return -1;
			}
			int num = buttonMapCount;
			int num2 = 0;
			while (num2 < num)
			{
				while (true)
				{
					if (wIadyhEVxiJaWeDEsznpytUcfFE[num2].tqPurZpByiUWRrPJKwHxxaZZua == P_0)
					{
						return num2;
					}
					num2++;
					int num3 = 649802496;
					while (true)
					{
						switch (num3 ^ 0x26BB3302)
						{
						case 0:
							num3 = 649802499;
							continue;
						case 1:
							break;
						default:
							goto end_IL_0033;
						}
						break;
					}
					continue;
					end_IL_0033:
					break;
				}
			}
			return -1;
		}

		internal int mtcKICqphgVFBvDKrNbyYzWrilK(bool P_0, List<ActionElementMap> P_1, bool P_2)
		{
			if (P_1 == null)
			{
				throw new ArgumentNullException("results");
			}
			int num5 = default(int);
			ActionElementMap actionElementMap = default(ActionElementMap);
			int num3 = default(int);
			int num4 = default(int);
			while (true)
			{
				int num;
				int num2;
				if (!P_2)
				{
					num = -2057458330;
					num2 = num;
				}
				else
				{
					num = -2057458324;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -2057458332)
					{
					case 0:
						num = -2057458329;
						continue;
					case 4:
						num5 = 0;
						num = -2057458334;
						continue;
					case 2:
						P_1.Clear();
						num = -2057458324;
						continue;
					case 1:
						actionElementMap = wIadyhEVxiJaWeDEsznpytUcfFE[num3];
						if (P_0)
						{
							int num6;
							if (!actionElementMap.FnzJwrQpikWfZbmfjZhFwutJGAA)
							{
								num = -2057458323;
								num6 = num;
							}
							else
							{
								num = -2057458335;
								num6 = num;
							}
							continue;
						}
						goto case 5;
					case 8:
						num4 = buttonMapCount;
						num = -2057458336;
						continue;
					case 9:
						num3++;
						num = -2057458333;
						continue;
					case 5:
						P_1.Add(actionElementMap);
						num5++;
						num = -2057458323;
						continue;
					case 3:
						break;
					case 6:
						num3 = 0;
						num = -2057458333;
						continue;
					default:
						if (num3 >= num4)
						{
							return num5;
						}
						goto case 1;
					}
					break;
				}
			}
		}

		internal int gXOdyHibychfWorQwJzzDWLgsjhd(int P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			if (P_2 == null)
			{
				throw new ArgumentNullException("results");
			}
			int num3 = default(int);
			ActionElementMap actionElementMap = default(ActionElementMap);
			int num2 = default(int);
			int num7 = default(int);
			while (true)
			{
				IL_00a4:
				int num;
				if (!P_3)
				{
					P_2.Clear();
					num = 923529628;
					goto IL_0016;
				}
				goto IL_0078;
				IL_0016:
				while (true)
				{
					switch (num ^ 0x370BF19A)
					{
					case 4:
						num = 923529625;
						continue;
					case 8:
						num3++;
						num = 923529626;
						continue;
					case 10:
						break;
					case 1:
						num = 923529626;
						continue;
					case 6:
						goto end_IL_0016;
					case 9:
						P_2.Add(actionElementMap);
						num2++;
						num = 923529618;
						continue;
					case 3:
						goto IL_00a4;
					case 2:
						goto IL_00b8;
					case 0:
						goto IL_00e2;
					case 5:
						goto IL_00fa;
					default:
						return num2;
					}
					int num4;
					if (!P_1)
					{
						num = 923529619;
						num4 = num;
					}
					else
					{
						num = 923529631;
						num4 = num;
					}
					continue;
					IL_00fa:
					int num5;
					if (!actionElementMap.FnzJwrQpikWfZbmfjZhFwutJGAA)
					{
						num = 923529618;
						num5 = num;
					}
					else
					{
						num = 923529619;
						num5 = num;
					}
					continue;
					IL_00b8:
					actionElementMap = wIadyhEVxiJaWeDEsznpytUcfFE[num3];
					int num6;
					if (actionElementMap._actionId != P_0)
					{
						num = 923529618;
						num6 = num;
					}
					else
					{
						num = 923529616;
						num6 = num;
					}
					continue;
					IL_00e2:
					int num8;
					if (num3 < num7)
					{
						num = 923529624;
						num8 = num;
					}
					else
					{
						num = 923529629;
						num8 = num;
					}
					continue;
					end_IL_0016:
					break;
				}
				goto IL_0078;
				IL_0078:
				num7 = buttonMapCount;
				if (num7 == 0)
				{
					break;
				}
				num2 = 0;
				num3 = 0;
				num = 923529627;
				goto IL_0016;
			}
			return 0;
		}

		internal virtual int RBgEhrXFkmZieEZpFoliEKAnVDW(int P_0, bool P_1, List<ActionElementMap> P_2, bool P_3)
		{
			if (P_2 == null)
			{
				throw new ArgumentNullException("results");
			}
			ActionElementMap actionElementMap = default(ActionElementMap);
			int num2 = default(int);
			int num4 = default(int);
			int num3 = default(int);
			while (true)
			{
				int num;
				if (!P_3)
				{
					P_2.Clear();
					num = -736789957;
					goto IL_0013;
				}
				goto IL_00a6;
				IL_0013:
				while (true)
				{
					switch (num ^ -736789953)
					{
					case 0:
						num = -736789955;
						continue;
					case 2:
						break;
					case 8:
						actionElementMap = wIadyhEVxiJaWeDEsznpytUcfFE[num2];
						if (actionElementMap._actionId == P_0)
						{
							if (P_1)
							{
								goto IL_0071;
							}
							goto case 6;
						}
						goto case 1;
					case 5:
						num = -736789956;
						continue;
					case 6:
						P_2.Add(actionElementMap);
						num4++;
						num = -736789954;
						continue;
					case 4:
						goto IL_00a6;
					case 1:
						num2++;
						num = -736789956;
						continue;
					case 7:
						num3 = buttonMapCount;
						num2 = 0;
						num = -736789958;
						continue;
					default:
						if (num2 >= num3)
						{
							return num4;
						}
						goto case 8;
					}
					break;
					IL_0071:
					int num5;
					if (!actionElementMap.FnzJwrQpikWfZbmfjZhFwutJGAA)
					{
						num = -736789954;
						num5 = num;
					}
					else
					{
						num = -736789959;
						num5 = num;
					}
				}
				continue;
				IL_00a6:
				if (P_0 < 0)
				{
					break;
				}
				num4 = 0;
				num = -736789960;
				goto IL_0013;
			}
			return 0;
		}

		internal virtual ActionElementMap fZGPCRASIBflRUbPxowPPeWbYQN(IControllerElementTarget P_0, bool P_1, int P_2, bool P_3, out bool P_4)
		{
			P_4 = false;
			int num2 = default(int);
			int num3 = default(int);
			while (true)
			{
				int num = 1394888136;
				while (true)
				{
					switch (num ^ 0x53244DCB)
					{
					case 5:
						break;
					case 2:
						if (P_1)
						{
							if (wIadyhEVxiJaWeDEsznpytUcfFE[num2]._actionId == P_2)
							{
								num = 1394888139;
								continue;
							}
							goto IL_00da;
						}
						goto case 0;
					case 8:
						if (wIadyhEVxiJaWeDEsznpytUcfFE[num2].FnzJwrQpikWfZbmfjZhFwutJGAA)
						{
							num = 1394888143;
							continue;
						}
						goto IL_00da;
					case 6:
						P_4 = true;
						return null;
					case 3:
						if (P_1 && P_2 < 0)
						{
							P_4 = true;
							return null;
						}
						if (VQsqaxMtJcFCSgBrVZwsKhkWblZ(P_0))
						{
							if (!RbfCKlONOukDglmWLTrDfcpWjpr(P_0.elementType))
							{
								num = 1394888140;
								continue;
							}
							num3 = buttonMapCount;
							_ = P_0.elementIdentifierId;
							num2 = 0;
							num = 1394888138;
						}
						else
						{
							num = 1394888141;
						}
						continue;
					case 4:
						if (wIadyhEVxiJaWeDEsznpytUcfFE[num2].IsTarget(P_0))
						{
							return wIadyhEVxiJaWeDEsznpytUcfFE[num2];
						}
						goto IL_00da;
					case 0:
					{
						int num4;
						if (!P_3)
						{
							num = 1394888143;
							num4 = num;
						}
						else
						{
							num = 1394888131;
							num4 = num;
						}
						continue;
					}
					case 7:
						return null;
					default:
						{
							if (num2 >= num3)
							{
								return null;
							}
							goto case 2;
						}
						IL_00da:
						num2++;
						num = 1394888138;
						continue;
					}
					break;
				}
			}
		}

		internal virtual int hqlCMKjVRQhOxlLPEQXdCmkbvsYc(IControllerElementTarget P_0, bool P_1, int P_2, bool P_3, List<ActionElementMap> P_4, bool P_5, out bool P_6)
		{
			if (P_4 == null)
			{
				goto IL_0007;
			}
			goto IL_00ca;
			IL_0007:
			int num = -542825579;
			goto IL_000c;
			IL_000c:
			int num2 = default(int);
			int num4 = default(int);
			int num3 = default(int);
			while (true)
			{
				switch (num ^ -542825580)
				{
				case 6:
					break;
				case 2:
					num2++;
					num = -542825571;
					continue;
				case 0:
					if (P_3)
					{
						goto IL_005e;
					}
					goto case 3;
				case 4:
					goto IL_0082;
				case 10:
					num = -542825571;
					continue;
				case 7:
					goto IL_00a1;
				case 1:
					throw new ArgumentNullException("results");
				case 8:
					goto IL_00ca;
				case 3:
					if (wIadyhEVxiJaWeDEsznpytUcfFE[num2].IsTarget(P_0))
					{
						P_4.Add(wIadyhEVxiJaWeDEsznpytUcfFE[num2]);
						num4++;
						num = -542825578;
						continue;
					}
					goto case 2;
				case 5:
					if (!P_1)
					{
						goto case 0;
					}
					goto IL_011f;
				case 11:
					return num4;
				default:
					if (num2 >= num3)
					{
						return num4;
					}
					goto case 5;
				}
				break;
				IL_011f:
				int num5;
				if (wIadyhEVxiJaWeDEsznpytUcfFE[num2]._actionId == P_2)
				{
					num = -542825580;
					num5 = num;
				}
				else
				{
					num = -542825578;
					num5 = num;
				}
				continue;
				IL_005e:
				int num6;
				if (!wIadyhEVxiJaWeDEsznpytUcfFE[num2].FnzJwrQpikWfZbmfjZhFwutJGAA)
				{
					num = -542825578;
					num6 = num;
				}
				else
				{
					num = -542825577;
					num6 = num;
				}
				continue;
				IL_0082:
				if (P_2 < 0)
				{
					P_6 = true;
					num = -542825569;
					continue;
				}
				goto IL_0149;
			}
			goto IL_0007;
			IL_00a1:
			P_6 = false;
			if (P_1)
			{
				num = -542825584;
				goto IL_000c;
			}
			goto IL_0149;
			IL_00ca:
			num4 = 0;
			if (!P_5)
			{
				P_4.Clear();
				num = -542825581;
				goto IL_000c;
			}
			goto IL_00a1;
			IL_0149:
			if (!VQsqaxMtJcFCSgBrVZwsKhkWblZ(P_0))
			{
				P_6 = true;
				return num4;
			}
			if (!RbfCKlONOukDglmWLTrDfcpWjpr(P_0.elementType))
			{
				return num4;
			}
			num3 = buttonMapCount;
			_ = P_0.elementIdentifierId;
			num2 = 0;
			num = -542825570;
			goto IL_000c;
		}

		internal void oxrBoullAMNVxCxvjekQmHcGjxP(int P_0, ControllerElementType P_1)
		{
			ActionElementMap elementMap = GetElementMap(P_0);
			if (elementMap == null)
			{
				return;
			}
			while (elementMap._elementType != P_1)
			{
				while (true)
				{
					IL_003f:
					elementMap._elementType = P_1;
					if (P_1 == ControllerElementType.Button)
					{
						elementMap._axisRange = AxisRange.Full;
						elementMap._invert = false;
						int num = 96598040;
						while (true)
						{
							switch (num ^ 0x5C1F81A)
							{
							case 3:
								num = 96598043;
								continue;
							case 1:
								break;
							case 0:
								goto IL_003f;
							default:
								goto IL_005f;
							}
							break;
						}
						break;
					}
					goto IL_005f;
					IL_005f:
					DeleteElementMap(P_0);
					sZOJeHRsznuYXOHFOALspWGZHIu(elementMap);
					return;
				}
			}
		}

		internal virtual bool sZOJeHRsznuYXOHFOALspWGZHIu(ActionElementMap P_0)
		{
			if (P_0 == null)
			{
				goto IL_0003;
			}
			int num;
			if (!RbfCKlONOukDglmWLTrDfcpWjpr(P_0._elementType))
			{
				num = 1474445364;
			}
			else
			{
				wIadyhEVxiJaWeDEsznpytUcfFE.Add(P_0);
				JLRmbPRTzNsueyNkoBNDTxdoWOF(P_0);
				num = 1474445366;
			}
			goto IL_0008;
			IL_0003:
			num = 1474445365;
			goto IL_0008;
			IL_0008:
			switch (num ^ 0x57E24034)
			{
			case 3:
				break;
			case 1:
				return false;
			case 0:
				return false;
			default:
				return true;
			}
			goto IL_0003;
		}

		internal bool VQsqaxMtJcFCSgBrVZwsKhkWblZ(IControllerElementTarget P_0)
		{
			if (P_0 == null)
			{
				return false;
			}
			Controller controller = P_0.controller;
			while (true)
			{
				int num = 1162419642;
				while (true)
				{
					switch (num ^ 0x45491DB8)
					{
					case 0:
						break;
					case 2:
						if (controller != null && controller.type == _controllerType)
						{
							if (controller.id != _controllerId)
							{
								goto IL_0049;
							}
							return true;
						}
						goto default;
					default:
						return false;
					}
					break;
					IL_0049:
					num = 1162419641;
				}
			}
		}

		internal bool mgtdImcKjJwAoDnTouuboWHlqAT(string P_0)
		{
			try
			{
				FMjbXwujmHnZzQbodRBJzieOPHZ(SerializedObject.FromXml(GetType(), P_0));
				return true;
			}
			catch (Exception ex)
			{
				Logger.LogError("Error creating  " + GetType().Name + "  from XML. " + ex.Message);
				return false;
			}
		}

		internal bool ievddbfmfSnHHgTUbzYEEnUqJDzz(string P_0)
		{
			try
			{
				FMjbXwujmHnZzQbodRBJzieOPHZ(SerializedObject.FromJson(GetType(), P_0));
				return true;
			}
			catch (Exception ex)
			{
				Logger.LogError("Error creating  " + GetType().Name + "  from JSON. " + ex.Message);
				return false;
			}
		}

		internal void JLRmbPRTzNsueyNkoBNDTxdoWOF(ActionElementMap P_0)
		{
			if (P_0 != null)
			{
				ZYwIXqAucYgKRZdCmuiIHmWLQlA.Add(P_0);
				ZYwIXqAucYgKRZdCmuiIHmWLQlA.Sort(ZMKdYnmvaVrNKCmWlEgzdUJtqiVH.Default);
			}
		}

		internal void ThSlapBLKzwPogSleqWVuWHfcUG(int P_0)
		{
			int num = VkhEThEiPTuuuwjMwFSvUnDZnLv(P_0);
			if (num < 0)
			{
				return;
			}
			while (true)
			{
				ZYwIXqAucYgKRZdCmuiIHmWLQlA.RemoveAt(num);
				int num2 = 1764689463;
				while (true)
				{
					switch (num2 ^ 0x692F0635)
					{
					case 0:
						goto IL_000d;
					default:
						return;
					case 1:
						break;
					case 2:
						return;
					}
					break;
					IL_000d:
					num2 = 1764689460;
				}
			}
		}

		internal void YoxTzXcPyofAdEXXWqQBsJzfAvv(int P_0, ActionElementMap P_1)
		{
			if (P_1 == null)
			{
				return;
			}
			while (true)
			{
				int num = VkhEThEiPTuuuwjMwFSvUnDZnLv(P_0);
				if (num < 0)
				{
					break;
				}
				while (true)
				{
					IL_003a:
					ZYwIXqAucYgKRZdCmuiIHmWLQlA[num] = P_1;
					ZYwIXqAucYgKRZdCmuiIHmWLQlA.Sort(ZMKdYnmvaVrNKCmWlEgzdUJtqiVH.Default);
					int num2 = -2052033304;
					while (true)
					{
						switch (num2 ^ -2052033301)
						{
						case 0:
							num2 = -2052033303;
							continue;
						default:
							return;
						case 2:
							break;
						case 1:
							goto IL_003a;
						case 3:
							return;
						}
						break;
					}
					break;
				}
			}
		}

		internal static void rOgFOJVTTNFABJrcUCYRlvoNiwWG(ActionElementMap P_0, int P_1, Pole P_2, int P_3, ControllerElementType P_4, AxisRange P_5, bool P_6)
		{
			P_0.tAgADqjTsMUxSqYXeDyJIdETYRAp();
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
				ReInput.controllers.GetController(_controllerType, _controllerId).kHBFOpXfsCHmoMIFXGRFYWyjgTV(this, map);
			}
		}

		internal virtual bool FMjbXwujmHnZzQbodRBJzieOPHZ(SerializedObject P_0)
		{
			bool flag = false;
			int num2 = default(int);
			SerializedObject value = default(SerializedObject);
			SerializedObject value2 = default(SerializedObject);
			while (true)
			{
				int num = 2051210391;
				while (true)
				{
					switch (num ^ 0x7A42FC9F)
					{
					case 9:
						break;
					case 1:
						P_0.TryGetDeserializedValueByRef("hardwareGuid", ref _hardwareGuid);
						P_0.TryGetDeserializedValueByRef("enabled", ref _enabled);
						if (!flag)
						{
							ClearElementMaps();
							flag = true;
							num = 2051210396;
							continue;
						}
						goto case 3;
					case 4:
						_layoutId = -1;
						_name = string.Empty;
						_hardwareGuid = Guid.Empty;
						_enabled = true;
						P_0.TryGetDeserializedValueByRef("sourceMapId", ref _sourceMapId);
						num = 2051210389;
						continue;
					case 6:
					{
						int num4;
						if (num2 >= value.count)
						{
							num = 2051210392;
							num4 = num;
						}
						else
						{
							num = 2051210388;
							num4 = num;
						}
						continue;
					}
					case 10:
						P_0.TryGetDeserializedValueByRef("categoryId", ref _categoryId);
						P_0.TryGetDeserializedValueByRef("layoutId", ref _layoutId);
						P_0.TryGetDeserializedValueByRef("name", ref _name);
						num = 2051210398;
						continue;
					case 8:
						_sourceMapId = -1;
						_categoryId = -1;
						num = 2051210395;
						continue;
					case 3:
						value = null;
						num = 2051210397;
						continue;
					case 12:
						num2 = 0;
						num = 2051210393;
						continue;
					case 5:
						num2++;
						num = 2051210393;
						continue;
					case 2:
						if (P_0.TryGetDeserializedValueByRef("buttonMaps", ref value))
						{
							int num5;
							if (value != null)
							{
								num = 2051210387;
								num5 = num;
							}
							else
							{
								num = 2051210392;
								num5 = num;
							}
							continue;
						}
						goto default;
					case 11:
						if (!value.TryGetDeserializedValue<SerializedObject>(num2, out value2))
						{
							int num3;
							if (value2 != null)
							{
								num = 2051210394;
								num3 = num;
							}
							else
							{
								num = 2051210399;
								num3 = num;
							}
							continue;
						}
						goto case 0;
					case 0:
					{
						ActionElementMap actionElementMap = new ActionElementMap();
						actionElementMap.FMjbXwujmHnZzQbodRBJzieOPHZ(value2);
						if (ActionElementMap.nQrkQvPPbIngfQlYzgfwckugskm(actionElementMap))
						{
							fTDEdaCTYLvKLWSpZIBomPPJaZdF(actionElementMap);
							num = 2051210394;
							continue;
						}
						goto case 5;
					}
					default:
						return flag;
					}
					break;
				}
			}
		}

		internal virtual void JcTmuzzUPdkdhEZeDhOUstVShFv(SerializedObject P_0)
		{
			if (P_0.xmlInfo == null)
			{
				P_0.xmlInfo = new SerializedObject.XmlInfo();
				goto IL_0013;
			}
			goto IL_005c;
			IL_005c:
			P_0.Add("dataVersion", 2, SerializedObject.FieldOptions.ExculdeFromXml);
			int num = -839289897;
			goto IL_0018;
			IL_0013:
			num = -839289903;
			goto IL_0018;
			IL_0018:
			List<object> list = default(List<object>);
			int num2 = default(int);
			int num3 = default(int);
			while (true)
			{
				switch (num ^ -839289891)
				{
				case 11:
					break;
				default:
					return;
				case 12:
					goto IL_005c;
				case 9:
					list.Add(wIadyhEVxiJaWeDEsznpytUcfFE[num2].mtMtVVrohwWTxFPivXmGbDyGevo());
					num = -839289891;
					continue;
				case 8:
					P_0.Add("name", _name);
					P_0.Add("hardwareGuid", _hardwareGuid);
					num = -839289893;
					continue;
				case 3:
				{
					Joystick joystick = ReInput.controllers.GetJoystick(_controllerId);
					Guid guid = joystick?.hardwareTypeGuid ?? Guid.Empty;
					string value = ((joystick != null) ? SerializationTools.CleanInvalidXmlChars(joystick.hardwareName) : "Unknown");
					P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.XmlStringAttribute
					{
						localName = "hardwareGuid",
						value = guid.ToString()
					});
					P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.XmlStringAttribute
					{
						localName = "hardwareName",
						value = value
					});
					num = -839289894;
					continue;
				}
				case 4:
					P_0.Add("buttonMaps", list);
					num2 = 0;
					num = -839289889;
					continue;
				case 5:
					goto IL_017d;
				case 2:
					goto IL_01a0;
				case 6:
					P_0.Add("enabled", _enabled);
					num3 = buttonMapCount;
					list = new List<object>();
					num = -839289895;
					continue;
				case 7:
					P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.XmlStringAttribute
					{
						prefix = "xmlns",
						localName = "xsi",
						ns = null,
						value = "http://www.w3.org/2001/XMLSchema-instance"
					});
					P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.XmlStringAttribute
					{
						prefix = "xsi",
						localName = "schemaLocation",
						ns = null,
						value = string.Format("{0} {1}{2}{3}{4}{5}", "http://guavaman.com/rewired", "http://guavaman.com/schemas/rewired/", "1.1", "/", GetType().Name, ".xsd")
					});
					P_0.Add("sourceMapId", _sourceMapId);
					P_0.Add("categoryId", _categoryId);
					P_0.Add("layoutId", _layoutId);
					num = -839289899;
					continue;
				case 10:
					goto IL_02fa;
				case 0:
					num2++;
					num = -839289889;
					continue;
				case 1:
					return;
				}
				break;
				IL_02fa:
				P_0.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.XmlStringAttribute
				{
					localName = "dataVersion",
					value = 2.ToString()
				});
				int num4;
				if (object.ReferenceEquals(GetType(), typeof(JoystickMap)))
				{
					num = -839289890;
					num4 = num;
				}
				else
				{
					num = -839289894;
					num4 = num;
				}
				continue;
				IL_01a0:
				int num5;
				if (num2 >= num3)
				{
					num = -839289892;
					num5 = num;
				}
				else
				{
					num = -839289896;
					num5 = num;
				}
				continue;
				IL_017d:
				int num6;
				if (wIadyhEVxiJaWeDEsznpytUcfFE[num2] == null)
				{
					num = -839289891;
					num6 = num;
				}
				else
				{
					num = -839289900;
					num6 = num;
				}
			}
			goto IL_0013;
		}

		private bool RbfCKlONOukDglmWLTrDfcpWjpr(ControllerElementType P_0)
		{
			if (P_0 != ControllerElementType.Button)
			{
				return false;
			}
			return true;
		}

		private void QIfwVXGJCVNYMvqEWdTbgGcJiJX(int P_0, int P_1)
		{
			ThSlapBLKzwPogSleqWVuWHfcUG(P_0);
			while (true)
			{
				int num = -1796016998;
				while (true)
				{
					switch (num ^ -1796017000)
					{
					case 0:
						break;
					default:
						return;
					case 1:
						wIadyhEVxiJaWeDEsznpytUcfFE.RemoveAt(P_1);
						num = -1796016996;
						continue;
					case 3:
						return;
					case 2:
					{
						if (P_1 < 0)
						{
							return;
						}
						int num2;
						if (P_1 < buttonMapCount)
						{
							num = -1796016999;
							num2 = num;
						}
						else
						{
							num = -1796016997;
							num2 = num;
						}
						continue;
					}
					case 4:
						return;
					}
					break;
				}
			}
		}

		private void fTDEdaCTYLvKLWSpZIBomPPJaZdF(ActionElementMap P_0)
		{
			if (P_0 == null)
			{
				goto IL_0003;
			}
			goto IL_002d;
			IL_0003:
			int num = 554954803;
			goto IL_0008;
			IL_0008:
			switch (num ^ 0x2113F031)
			{
			case 0:
				break;
			default:
				return;
			case 2:
				return;
			case 3:
				goto IL_002d;
			case 1:
				return;
			}
			goto IL_0003;
			IL_002d:
			wIadyhEVxiJaWeDEsznpytUcfFE.Add(P_0);
			JLRmbPRTzNsueyNkoBNDTxdoWOF(P_0);
			num = 554954800;
			goto IL_0008;
		}

		private void lDffPSawfqquYbGPbDXUQPCRTMF(ActionElementMap P_0, int P_1)
		{
			if (P_0 == null)
			{
				return;
			}
			while (P_1 >= 0)
			{
				int num;
				int num2;
				if (P_1 < buttonMapCount)
				{
					num = 39938392;
					num2 = num;
				}
				else
				{
					num = 39938393;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ 0x2616958)
					{
					case 3:
						goto IL_0004;
					case 2:
						break;
					case 1:
						return;
					default:
						YoxTzXcPyofAdEXXWqQBsJzfAvv(wIadyhEVxiJaWeDEsznpytUcfFE[P_1].tqPurZpByiUWRrPJKwHxxaZZua, P_0);
						wIadyhEVxiJaWeDEsznpytUcfFE[P_1] = P_0;
						return;
					}
					break;
					IL_0004:
					num = 39938394;
				}
			}
		}

		private int VkhEThEiPTuuuwjMwFSvUnDZnLv(int P_0)
		{
			if (ZYwIXqAucYgKRZdCmuiIHmWLQlA == null)
			{
				return -1;
			}
			int count = ZYwIXqAucYgKRZdCmuiIHmWLQlA.Count;
			int num2 = default(int);
			while (true)
			{
				int num = -35936848;
				while (true)
				{
					switch (num ^ -35936844)
					{
					case 0:
						break;
					case 4:
						num2 = 0;
						num = -35936843;
						continue;
					case 3:
						if (ZYwIXqAucYgKRZdCmuiIHmWLQlA[num2].tqPurZpByiUWRrPJKwHxxaZZua == P_0)
						{
							return num2;
						}
						num2++;
						num = -35936843;
						continue;
					case 1:
					{
						int num3;
						if (num2 >= count)
						{
							num = -35936842;
							num3 = num;
						}
						else
						{
							num = -35936841;
							num3 = num;
						}
						continue;
					}
					default:
						return -1;
					}
					break;
				}
			}
		}

		private SerializedObject mtMtVVrohwWTxFPivXmGbDyGevo()
		{
			SerializedObject serializedObject = new SerializedObject(GetType(), SerializedObject.ObjectType.Object);
			JcTmuzzUPdkdhEZeDhOUstVShFv(serializedObject);
			return serializedObject;
		}

		internal static ControllerMap GIHuiEkmFihgdjpqkqIhwXanlmm(ControllerType P_0)
		{
			switch (P_0)
			{
			default:
				while (true)
				{
					switch (0x67AA1B7F ^ 0x67AA1B7E)
					{
					case 0:
						continue;
					case 1:
						throw new NotImplementedException();
					}
					break;
				}
				goto case ControllerType.Keyboard;
			case ControllerType.Keyboard:
				return new KeyboardMap();
			case ControllerType.Mouse:
				return new MouseMap();
			case ControllerType.Joystick:
				return new JoystickMap();
			case ControllerType.Custom:
				return new CustomControllerMap();
			}
		}

		internal static ControllerMap sYqesviIrxjGcYuLuXwjeePVAdU(Controller P_0, int P_1, int P_2)
		{
			if (P_0 == null)
			{
				return null;
			}
			ControllerType type = P_0.type;
			while (true)
			{
				int num = -1930996502;
				while (true)
				{
					switch (num ^ -1930996503)
					{
					case 2:
						break;
					case 3:
						switch (type)
						{
						default:
							goto IL_0045;
						case ControllerType.Keyboard:
							break;
						case ControllerType.Mouse:
							return MouseMap.Blank(P_1, P_2);
						case ControllerType.Joystick:
							return JoystickMap.Blank(((Joystick)P_0).hardwareTypeGuid, P_1, P_2);
						case ControllerType.Custom:
							return CustomControllerMap.Blank(((CustomController)P_0).sourceControllerId, P_1, P_2);
						}
						goto default;
					default:
						return KeyboardMap.Blank(P_1, P_2);
					case 0:
						throw new NotImplementedException();
					}
					break;
					IL_0045:
					num = -1930996503;
				}
			}
		}

		public static ControllerMap CreateFromXml(ControllerType controllerType, string xmlString)
		{
			if (string.IsNullOrEmpty(xmlString))
			{
				return null;
			}
			ControllerMap controllerMap = GIHuiEkmFihgdjpqkqIhwXanlmm(controllerType);
			try
			{
				controllerMap.mgtdImcKjJwAoDnTouuboWHlqAT(xmlString);
				return controllerMap;
			}
			catch
			{
				return null;
			}
		}
	}
}
