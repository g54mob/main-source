using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading;
using Rewired.Data.Mapping;
using Rewired.Utils;
using UnityEngine;

namespace Rewired
{
	public abstract class ControllerWithAxes : ControllerWithMap
	{
		private sealed class HOHDpYseWbboCPujpKcdAtYijRO : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
		{
			private ControllerPollingInfo RDkWcsTpvDaNZojjIZONnoEBXPC;

			private int LzqgRXjFXvJPbHjfzyAmNfcqezXL;

			private int iDzUuTsbdXLkIyEGCPmJzsmGhcs;

			public ControllerWithAxes ZzSaCQHlhEgTijsOQGwUlyKTOzqG;

			public ControllerPollingInfo JJHLmcAJDRFoaebPzaHMRleOvqCn;

			public ControllerPollingInfo ZPfuMQmaeslnOluBAoNNyLWKakHB;

			public IEnumerator<ControllerPollingInfo> rQyEewIudcqnYncmejNxavozNQHZ;

			public IEnumerator<ControllerPollingInfo> ItDRmtUVqyhacAlFrujSUSKqdfm;

			ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return RDkWcsTpvDaNZojjIZONnoEBXPC;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return RDkWcsTpvDaNZojjIZONnoEBXPC;
				}
			}

			[DebuggerHidden]
			IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
			{
				if (Thread.CurrentThread.ManagedThreadId == iDzUuTsbdXLkIyEGCPmJzsmGhcs)
				{
					goto IL_0012;
				}
				goto IL_0040;
				IL_0012:
				int num = -1120233347;
				goto IL_0017;
				IL_0017:
				HOHDpYseWbboCPujpKcdAtYijRO hOHDpYseWbboCPujpKcdAtYijRO = default(HOHDpYseWbboCPujpKcdAtYijRO);
				while (true)
				{
					switch (num ^ -1120233348)
					{
					case 2:
						break;
					case 3:
						goto IL_0040;
					case 5:
						hOHDpYseWbboCPujpKcdAtYijRO.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = ZzSaCQHlhEgTijsOQGwUlyKTOzqG;
						num = -1120233350;
						continue;
					case 1:
						if (LzqgRXjFXvJPbHjfzyAmNfcqezXL == -2)
						{
							LzqgRXjFXvJPbHjfzyAmNfcqezXL = 0;
							num = -1120233352;
							continue;
						}
						goto IL_0040;
					case 0:
						num = -1120233350;
						continue;
					case 4:
						hOHDpYseWbboCPujpKcdAtYijRO = this;
						num = -1120233348;
						continue;
					default:
						return hOHDpYseWbboCPujpKcdAtYijRO;
					}
					break;
				}
				goto IL_0012;
				IL_0040:
				hOHDpYseWbboCPujpKcdAtYijRO = new HOHDpYseWbboCPujpKcdAtYijRO(0);
				num = -1120233351;
				goto IL_0017;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				bool result = default(bool);
				try
				{
					int num;
					switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
					{
					default:
						num = 1443477509;
						goto IL_0026;
					case 0:
						goto IL_009c;
					case 4:
						goto IL_0153;
					case 2:
						goto IL_01d4;
					case 1:
					case 3:
						break;
						IL_0026:
						while (true)
						{
							switch (num ^ 0x5609B80E)
							{
							case 9:
								break;
							case 2:
								goto IL_007e;
							case 15:
								goto IL_009c;
							case 3:
								zFkJcwVPOSYuCpbdIglLQiSUuSE();
								num = 1443477535;
								continue;
							case 13:
								num = 1443477516;
								continue;
							case 4:
								goto end_IL_0000;
							case 17:
								ItDRmtUVqyhacAlFrujSUSKqdfm = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.PollForAllAxes().GetEnumerator();
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = 3;
								num = 1443477512;
								continue;
							case 7:
								ZPfuMQmaeslnOluBAoNNyLWKakHB = ItDRmtUVqyhacAlFrujSUSKqdfm.Current;
								RDkWcsTpvDaNZojjIZONnoEBXPC = ZPfuMQmaeslnOluBAoNNyLWKakHB;
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = 4;
								result = true;
								num = 1443477508;
								continue;
							case 0:
								goto IL_0153;
							case 1:
								num = 1443477510;
								continue;
							case 6:
								if (!ItDRmtUVqyhacAlFrujSUSKqdfm.MoveNext())
								{
									twOjFzAZkTBXxCUJdRGGXqyoHHq();
									num = 1443477510;
									continue;
								}
								goto case 7;
							case 11:
								num = 1443477510;
								continue;
							case 10:
								goto end_IL_0000;
							case 12:
								JJHLmcAJDRFoaebPzaHMRleOvqCn = rQyEewIudcqnYncmejNxavozNQHZ.Current;
								RDkWcsTpvDaNZojjIZONnoEBXPC = JJHLmcAJDRFoaebPzaHMRleOvqCn;
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = 2;
								result = true;
								num = 1443477514;
								continue;
							case 16:
								goto IL_01d4;
							case 5:
								goto IL_01e5;
							case 14:
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
								num = 1443477507;
								continue;
							default:
								goto end_IL_0008;
							}
							break;
							IL_007e:
							int num2;
							if (rQyEewIudcqnYncmejNxavozNQHZ.MoveNext())
							{
								num = 1443477506;
								num2 = num;
							}
							else
							{
								num = 1443477517;
								num2 = num;
							}
						}
						goto default;
						IL_01d4:
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
						num = 1443477516;
						goto IL_0026;
						IL_0153:
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = 3;
						num = 1443477512;
						goto IL_0026;
						IL_009c:
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
						if (ReInput._id != ZzSaCQHlhEgTijsOQGwUlyKTOzqG.SsPwhbdijXONOlkRKHOkXryZrDq)
						{
							ReInput.CheckInitialized(ZzSaCQHlhEgTijsOQGwUlyKTOzqG.SsPwhbdijXONOlkRKHOkXryZrDq);
							num = 1443477519;
							goto IL_0026;
						}
						goto IL_01e5;
						IL_01e5:
						rQyEewIudcqnYncmejNxavozNQHZ = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.OtyKouqSANAZQSpRtGqqtfDniWwe().GetEnumerator();
						num = 1443477504;
						goto IL_0026;
						end_IL_0008:
						break;
					}
					result = false;
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
				switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
				{
				case 1:
				case 2:
					try
					{
					}
					finally
					{
						zFkJcwVPOSYuCpbdIglLQiSUuSE();
					}
					break;
				}
				switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
				{
				case 3:
				case 4:
					try
					{
						break;
					}
					finally
					{
						twOjFzAZkTBXxCUJdRGGXqyoHHq();
					}
				}
			}

			[DebuggerHidden]
			public HOHDpYseWbboCPujpKcdAtYijRO(int _003C_003E1__state)
			{
				LzqgRXjFXvJPbHjfzyAmNfcqezXL = _003C_003E1__state;
				iDzUuTsbdXLkIyEGCPmJzsmGhcs = Thread.CurrentThread.ManagedThreadId;
			}

			private void zFkJcwVPOSYuCpbdIglLQiSUuSE()
			{
				LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
				if (rQyEewIudcqnYncmejNxavozNQHZ != null)
				{
					rQyEewIudcqnYncmejNxavozNQHZ.Dispose();
				}
			}

			private void twOjFzAZkTBXxCUJdRGGXqyoHHq()
			{
				LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
				if (ItDRmtUVqyhacAlFrujSUSKqdfm != null)
				{
					ItDRmtUVqyhacAlFrujSUSKqdfm.Dispose();
				}
			}
		}

		private sealed class qTCtPYIuwXCiTvgABBwZeJqeKMN : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
		{
			private ControllerPollingInfo RDkWcsTpvDaNZojjIZONnoEBXPC;

			private int LzqgRXjFXvJPbHjfzyAmNfcqezXL;

			private int iDzUuTsbdXLkIyEGCPmJzsmGhcs;

			public ControllerWithAxes ZzSaCQHlhEgTijsOQGwUlyKTOzqG;

			public ControllerPollingInfo jPTbVYRgZpxgYnlSvzhHZfgXxge;

			public ControllerPollingInfo SlPMzzVAEpCjfhwFdFZcbyzAAzdL;

			public IEnumerator<ControllerPollingInfo> SZsJHIkdgEJwNoOPqrezQXggXyE;

			public IEnumerator<ControllerPollingInfo> TCrmpXvzWWrynjrjRptyksGkclH;

			ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return RDkWcsTpvDaNZojjIZONnoEBXPC;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return RDkWcsTpvDaNZojjIZONnoEBXPC;
				}
			}

			[DebuggerHidden]
			IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
			{
				if (Thread.CurrentThread.ManagedThreadId == iDzUuTsbdXLkIyEGCPmJzsmGhcs && LzqgRXjFXvJPbHjfzyAmNfcqezXL == -2)
				{
					LzqgRXjFXvJPbHjfzyAmNfcqezXL = 0;
					goto IL_0023;
				}
				goto IL_004e;
				IL_0028:
				int num;
				qTCtPYIuwXCiTvgABBwZeJqeKMN qTCtPYIuwXCiTvgABBwZeJqeKMN2 = default(qTCtPYIuwXCiTvgABBwZeJqeKMN);
				while (true)
				{
					switch (num ^ 0x5FD2ED33)
					{
					case 3:
						break;
					case 1:
						qTCtPYIuwXCiTvgABBwZeJqeKMN2 = this;
						num = 1607658801;
						continue;
					case 0:
						goto IL_004e;
					default:
						return qTCtPYIuwXCiTvgABBwZeJqeKMN2;
					}
					break;
				}
				goto IL_0023;
				IL_004e:
				qTCtPYIuwXCiTvgABBwZeJqeKMN2 = new qTCtPYIuwXCiTvgABBwZeJqeKMN(0);
				qTCtPYIuwXCiTvgABBwZeJqeKMN2.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = ZzSaCQHlhEgTijsOQGwUlyKTOzqG;
				num = 1607658801;
				goto IL_0028;
				IL_0023:
				num = 1607658802;
				goto IL_0028;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				try
				{
					int num;
					switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
					{
					case 0:
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
						if (ReInput._id != ZzSaCQHlhEgTijsOQGwUlyKTOzqG.SsPwhbdijXONOlkRKHOkXryZrDq)
						{
							ReInput.CheckInitialized(ZzSaCQHlhEgTijsOQGwUlyKTOzqG.SsPwhbdijXONOlkRKHOkXryZrDq);
							num = -1152890700;
							goto IL_002b;
						}
						goto IL_0148;
					case 2:
						goto IL_012d;
					case 4:
						goto IL_0196;
						IL_012d:
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
						num = -1152890690;
						goto IL_002b;
						IL_0148:
						SZsJHIkdgEJwNoOPqrezQXggXyE = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.VHQLgKwmqCkCHIqetsnVehdVNDg().GetEnumerator();
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
						num = -1152890690;
						goto IL_002b;
						IL_002b:
						while (true)
						{
							switch (num ^ -1152890702)
							{
							case 10:
								num = -1152890703;
								continue;
							case 3:
								break;
							case 5:
								goto IL_00a7;
							case 8:
								SlPMzzVAEpCjfhwFdFZcbyzAAzdL = TCrmpXvzWWrynjrjRptyksGkclH.Current;
								RDkWcsTpvDaNZojjIZONnoEBXPC = SlPMzzVAEpCjfhwFdFZcbyzAAzdL;
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = 4;
								return true;
							case 12:
								if (!SZsJHIkdgEJwNoOPqrezQXggXyE.MoveNext())
								{
									GSVkQowpMpVtHPDcOiMlGRBvlCiV();
									num = -1152890698;
									continue;
								}
								goto case 13;
							case 9:
								mFDGRlHlJzlhSylYWFXzUlFVbIU();
								num = -1152890700;
								continue;
							case 0:
								goto IL_012d;
							case 2:
								num = -1152890697;
								continue;
							case 1:
								goto IL_0148;
							case 4:
								TCrmpXvzWWrynjrjRptyksGkclH = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.PollForAllAxes().GetEnumerator();
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = 3;
								num = -1152890704;
								continue;
							case 7:
								goto IL_0196;
							case 11:
								RDkWcsTpvDaNZojjIZONnoEBXPC = jPTbVYRgZpxgYnlSvzhHZfgXxge;
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = 2;
								return true;
							case 13:
								jPTbVYRgZpxgYnlSvzhHZfgXxge = SZsJHIkdgEJwNoOPqrezQXggXyE.Current;
								num = -1152890695;
								continue;
							default:
								goto end_IL_0008;
							}
							break;
							IL_00a7:
							int num2;
							if (TCrmpXvzWWrynjrjRptyksGkclH.MoveNext())
							{
								num = -1152890694;
								num2 = num;
							}
							else
							{
								num = -1152890693;
								num2 = num;
							}
						}
						goto case 0;
						IL_0196:
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = 3;
						num = -1152890697;
						goto IL_002b;
						end_IL_0008:
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
				switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
				{
				case 1:
				case 2:
					try
					{
					}
					finally
					{
						GSVkQowpMpVtHPDcOiMlGRBvlCiV();
					}
					break;
				}
				switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
				{
				case 3:
				case 4:
					try
					{
						break;
					}
					finally
					{
						mFDGRlHlJzlhSylYWFXzUlFVbIU();
					}
				}
			}

			[DebuggerHidden]
			public qTCtPYIuwXCiTvgABBwZeJqeKMN(int _003C_003E1__state)
			{
				LzqgRXjFXvJPbHjfzyAmNfcqezXL = _003C_003E1__state;
				iDzUuTsbdXLkIyEGCPmJzsmGhcs = Thread.CurrentThread.ManagedThreadId;
			}

			private void GSVkQowpMpVtHPDcOiMlGRBvlCiV()
			{
				LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
				if (SZsJHIkdgEJwNoOPqrezQXggXyE == null)
				{
					return;
				}
				while (true)
				{
					int num = -1914518449;
					while (true)
					{
						switch (num ^ -1914518450)
						{
						case 2:
							break;
						default:
							return;
						case 1:
							goto IL_002d;
						case 0:
							return;
						}
						break;
						IL_002d:
						SZsJHIkdgEJwNoOPqrezQXggXyE.Dispose();
						num = -1914518450;
					}
				}
			}

			private void mFDGRlHlJzlhSylYWFXzUlFVbIU()
			{
				LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
				if (TCrmpXvzWWrynjrjRptyksGkclH != null)
				{
					TCrmpXvzWWrynjrjRptyksGkclH.Dispose();
				}
			}
		}

		private sealed class fMcwAUqwHuFUkvMGtqsgcwYZlJi : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
		{
			private ControllerPollingInfo RDkWcsTpvDaNZojjIZONnoEBXPC;

			private int LzqgRXjFXvJPbHjfzyAmNfcqezXL;

			private int iDzUuTsbdXLkIyEGCPmJzsmGhcs;

			public ControllerWithAxes ZzSaCQHlhEgTijsOQGwUlyKTOzqG;

			public int pvjJhWYgzSepTjFZYCWkXSAmfcL;

			public Pole alDfPFIsohcumlEEztkISxxQDblD;

			public int cSZldvDeDTcRXkMsZAbvSlflBwkF;

			ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
			{
				[DebuggerHidden]
				get
				{
					return RDkWcsTpvDaNZojjIZONnoEBXPC;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return RDkWcsTpvDaNZojjIZONnoEBXPC;
				}
			}

			[DebuggerHidden]
			IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
			{
				fMcwAUqwHuFUkvMGtqsgcwYZlJi fMcwAUqwHuFUkvMGtqsgcwYZlJi2;
				if (Thread.CurrentThread.ManagedThreadId == iDzUuTsbdXLkIyEGCPmJzsmGhcs && LzqgRXjFXvJPbHjfzyAmNfcqezXL == -2)
				{
					LzqgRXjFXvJPbHjfzyAmNfcqezXL = 0;
					fMcwAUqwHuFUkvMGtqsgcwYZlJi2 = this;
				}
				else
				{
					while (true)
					{
						fMcwAUqwHuFUkvMGtqsgcwYZlJi2 = new fMcwAUqwHuFUkvMGtqsgcwYZlJi(0);
						fMcwAUqwHuFUkvMGtqsgcwYZlJi2.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = ZzSaCQHlhEgTijsOQGwUlyKTOzqG;
						int num = 2099411112;
						while (true)
						{
							switch (num ^ 0x7D2278A8)
							{
							case 2:
								num = 2099411113;
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
				return fMcwAUqwHuFUkvMGtqsgcwYZlJi2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				int num;
				int num3;
				switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
				{
				default:
					num = 522254410;
					goto IL_001a;
				case 1:
					LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
					num = 522254409;
					goto IL_001a;
				case 0:
					goto IL_00fe;
					IL_001a:
					while (true)
					{
						switch (num ^ 0x1F20F84C)
						{
						case 0:
							break;
						case 5:
							pvjJhWYgzSepTjFZYCWkXSAmfcL++;
							num = 522254404;
							continue;
						case 7:
							if (ZzSaCQHlhEgTijsOQGwUlyKTOzqG.IsPolledAxisActive(pvjJhWYgzSepTjFZYCWkXSAmfcL, out alDfPFIsohcumlEEztkISxxQDblD, out cSZldvDeDTcRXkMsZAbvSlflBwkF))
							{
								RDkWcsTpvDaNZojjIZONnoEBXPC = new ControllerPollingInfo(true, -1, ZzSaCQHlhEgTijsOQGwUlyKTOzqG.id, ZzSaCQHlhEgTijsOQGwUlyKTOzqG._name, ZzSaCQHlhEgTijsOQGwUlyKTOzqG._type, ControllerElementType.Axis, pvjJhWYgzSepTjFZYCWkXSAmfcL, alDfPFIsohcumlEEztkISxxQDblD, ZzSaCQHlhEgTijsOQGwUlyKTOzqG.kABaypBwJpdJPQfaNrcsDzJUopW.GetElementIdentifierName(cSZldvDeDTcRXkMsZAbvSlflBwkF), cSZldvDeDTcRXkMsZAbvSlflBwkF, KeyCode.None);
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
								return true;
							}
							goto case 5;
						case 6:
							num = 522254415;
							continue;
						case 4:
							goto IL_00fe;
						case 8:
							goto IL_012b;
						case 2:
							ReInput.CheckInitialized(ZzSaCQHlhEgTijsOQGwUlyKTOzqG.SsPwhbdijXONOlkRKHOkXryZrDq);
							num = 522254415;
							continue;
						case 1:
							ZzSaCQHlhEgTijsOQGwUlyKTOzqG.UpdatePollingFrameTracking();
							ZzSaCQHlhEgTijsOQGwUlyKTOzqG.cJJitEtFnVrjOVcwfJUseMMmAif();
							pvjJhWYgzSepTjFZYCWkXSAmfcL = 0;
							num = 522254404;
							continue;
						default:
							return false;
						}
						break;
						IL_012b:
						int num2;
						if (pvjJhWYgzSepTjFZYCWkXSAmfcL >= ZzSaCQHlhEgTijsOQGwUlyKTOzqG._axisCount)
						{
							num = 522254415;
							num2 = num;
						}
						else
						{
							num = 522254411;
							num2 = num;
						}
					}
					goto default;
					IL_00fe:
					LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
					if (ReInput._id == ZzSaCQHlhEgTijsOQGwUlyKTOzqG.SsPwhbdijXONOlkRKHOkXryZrDq)
					{
						num = 522254413;
						num3 = num;
					}
					else
					{
						num = 522254414;
						num3 = num;
					}
					goto IL_001a;
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
			public fMcwAUqwHuFUkvMGtqsgcwYZlJi(int _003C_003E1__state)
			{
				LzqgRXjFXvJPbHjfzyAmNfcqezXL = _003C_003E1__state;
				iDzUuTsbdXLkIyEGCPmJzsmGhcs = Thread.CurrentThread.ManagedThreadId;
			}
		}

		protected readonly int _axisCount;

		protected readonly int _axis2DCount;

		protected readonly Axis[] axes;

		protected readonly ReadOnlyCollection<Axis> axes_readOnly;

		protected readonly Axis2D[] axes2D;

		protected readonly ReadOnlyCollection<Axis2D> axes2D_readOnly;

		protected CalibrationMap _calibrationMap;

		private float[] DqVmMEpmHxxCqZAUxzVDZvHfQYL;

		private uint wdbgvPKxtDGMDihueViFrcIdGVJE = uint.MaxValue;

		private Func<int, int> pCwSXuJnGSSSCknOyKJtIfIQySs;

		public int axisCount
		{
			get
			{
				if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
				{
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					return 0;
				}
				return _axisCount;
			}
		}

		public int axis2DCount
		{
			get
			{
				if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
				{
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					return 0;
				}
				return _axis2DCount;
			}
		}

		public IList<Axis> Axes
		{
			get
			{
				if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
				{
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					return EmptyObjects<Axis>.EmptyReadOnlyIListT;
				}
				return axes_readOnly;
			}
		}

		public IList<Axis2D> Axes2D
		{
			get
			{
				if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
				{
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					return EmptyObjects<Axis2D>.EmptyReadOnlyIListT;
				}
				return axes2D_readOnly;
			}
		}

		public CalibrationMap calibrationMap
		{
			get
			{
				if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
				{
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					return null;
				}
				return _calibrationMap;
			}
		}

		public IList<ControllerElementIdentifier> AxisElementIdentifiers
		{
			get
			{
				if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
				{
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					return EmptyObjects<ControllerElementIdentifier>.EmptyReadOnlyIListT;
				}
				return kABaypBwJpdJPQfaNrcsDzJUopW.axisElementIdentifiers_readOnly;
			}
		}

		internal ControllerWithAxes(int controllerId, InputSource inputSource, string name, string hardwareName, string hardwareIdentifier, ControllerType type, Guid hardwareTypeGuid, int axisCount, int buttonCount, bool[] isButtonPressureSensitive, HardwareControllerMap_Game hardwareMap, Extension extension, ControllerDataUpdater dataUpdater)
			: base(controllerId, inputSource, name, hardwareName, hardwareIdentifier, type, hardwareTypeGuid, buttonCount, isButtonPressureSensitive, hardwareMap, extension, dataUpdater)
		{
			_axisCount = axisCount;
			axes = new Axis[axisCount];
			for (int i = 0; i < axisCount; i++)
			{
				axes[i] = new Axis(this, hardwareMap.axisElementIdentifierIds[i], "Axis " + i, hardwareMap.hwAxisRanges[i], hardwareMap.hwAxisInfo[i]);
				DaOirHIMrqCgwPvMGCDKpJCcEFCO(axes[i]);
			}
			axes_readOnly = new ReadOnlyCollection<Axis>(axes);
			_calibrationMap = new CalibrationMap(hardwareMap.hwAxisCalibrationData);
			_axis2DCount = hardwareMap.axis2DCount;
			axes2D = new Axis2D[_axis2DCount];
			for (int j = 0; j < _axis2DCount; j++)
			{
				try
				{
					HardwareJoystickMap.CompoundElement axis2DData = hardwareMap.GetAxis2DData(j);
					if (axis2DData == null)
					{
						Logger.LogError("Error creating Axis2D from hardware map! CompoundElement is null!");
						axes2D[j] = new Axis2D(this, axis2DData.elementIdentifier, "Axis 2D " + j, null, null, 0, 0, null);
						continue;
					}
					int axisIndex = hardwareMap.GetAxisIndex(axis2DData.componentElementIdentifiers[0]);
					int axisIndex2 = hardwareMap.GetAxisIndex(axis2DData.componentElementIdentifiers[1]);
					if (axisIndex < 0 || axisIndex >= _axisCount || axisIndex2 < 0 || axisIndex2 >= _axisCount)
					{
						axes2D[j] = new Axis2D(this, axis2DData.elementIdentifier, "Axis 2D " + j, null, null, 0, 0, null);
					}
					else
					{
						axes2D[j] = new Axis2D(this, axis2DData.elementIdentifier, "Axis 2D " + j, axes[axisIndex], axes[axisIndex2], axisIndex, axisIndex2, _calibrationMap);
					}
				}
				catch
				{
					Logger.LogError("Error creating Axis2D from hardware map! An exception was thrown.");
					axes2D[j] = new Axis2D(this, -1, "Axis 2D " + j, null, null, 0, 0, null);
				}
			}
			axes2D_readOnly = new ReadOnlyCollection<Axis2D>(axes2D);
			ODTYWdyclUhredorWasTpSLgYSGu();
			pCwSXuJnGSSSCknOyKJtIfIQySs = hardwareMap.GetAxisIndex;
		}

		public override Element GetElementById(int elementIdentifierId)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				goto IL_0019;
			}
			if (kABaypBwJpdJPQfaNrcsDzJUopW == null)
			{
				return null;
			}
			Element elementById = base.GetElementById(elementIdentifierId);
			if (elementById != null)
			{
				return elementById;
			}
			int axisIndex = kABaypBwJpdJPQfaNrcsDzJUopW.GetAxisIndex(elementIdentifierId);
			int num = -1028169195;
			goto IL_001e;
			IL_0019:
			num = -1028169194;
			goto IL_001e;
			IL_001e:
			switch (num ^ -1028169196)
			{
			case 0:
				break;
			case 2:
				return null;
			default:
				if (axisIndex < 0)
				{
					return null;
				}
				return axes[axisIndex];
			}
			goto IL_0019;
		}

		public int GetAxisIndexById(int elementIdentifierId)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return -1;
			}
			return kABaypBwJpdJPQfaNrcsDzJUopW.GetAxisIndex(elementIdentifierId);
		}

		public float GetAxis(int index)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				goto IL_0019;
			}
			int num;
			if (index >= 0)
			{
				if (index >= _axisCount)
				{
					num = 1976797411;
					goto IL_001e;
				}
				return axes[index].value;
			}
			goto IL_0051;
			IL_001e:
			switch (num ^ 0x75D388E1)
			{
			case 0:
				break;
			case 1:
				return 0f;
			default:
				goto IL_0051;
			}
			goto IL_0019;
			IL_0019:
			num = 1976797408;
			goto IL_001e;
			IL_0051:
			return 0f;
		}

		public float GetAxisPrev(int index)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return 0f;
			}
			if (index >= 0)
			{
				while (true)
				{
					int num = -888446688;
					while (true)
					{
						switch (num ^ -888446687)
						{
						case 2:
							break;
						case 1:
							goto IL_0041;
						default:
							goto end_IL_0023;
						}
						break;
						IL_0041:
						if (index >= _axisCount)
						{
							num = -888446687;
							continue;
						}
						return axes[index].valuePrev;
					}
					continue;
					end_IL_0023:
					break;
				}
			}
			return 0f;
		}

		public float GetAxisRaw(int index)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				goto IL_000d;
			}
			int num;
			if (index >= 0)
			{
				if (index >= _axisCount)
				{
					num = -2055270865;
					goto IL_0012;
				}
				return axes[index].valueRaw;
			}
			goto IL_0051;
			IL_0012:
			switch (num ^ -2055270866)
			{
			case 0:
				break;
			case 2:
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return 0f;
			default:
				goto IL_0051;
			}
			goto IL_000d;
			IL_000d:
			num = -2055270868;
			goto IL_0012;
			IL_0051:
			return 0f;
		}

		public float GetAxisRawPrev(int index)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				goto IL_0019;
			}
			int num;
			int num2;
			if (index >= 0)
			{
				num = 2050846590;
				num2 = num;
			}
			else
			{
				num = 2050846591;
				num2 = num;
			}
			goto IL_001e;
			IL_0019:
			num = 2050846589;
			goto IL_001e;
			IL_001e:
			while (true)
			{
				switch (num ^ 0x7A3D6F7E)
				{
				case 2:
					break;
				case 3:
					return 0f;
				case 0:
					if (index >= _axisCount)
					{
						goto IL_005f;
					}
					return axes[index].valueRawPrev;
				default:
					return 0f;
				}
				break;
				IL_005f:
				num = 2050846591;
			}
			goto IL_0019;
		}

		public float GetAxisTimeActive(int index)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				goto IL_000d;
			}
			int num;
			int num2;
			if (index >= 0)
			{
				num = 1311423585;
				num2 = num;
			}
			else
			{
				num = 1311423584;
				num2 = num;
			}
			goto IL_0012;
			IL_000d:
			num = 1311423586;
			goto IL_0012;
			IL_0012:
			while (true)
			{
				switch (num ^ 0x4E2ABC63)
				{
				case 0:
					break;
				case 1:
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					return 0f;
				case 2:
					if (index >= _axisCount)
					{
						goto IL_005f;
					}
					return axes[index].timeActive;
				default:
					return 0f;
				}
				break;
				IL_005f:
				num = 1311423584;
			}
			goto IL_000d;
		}

		public float GetAxisTimeInactive(int index)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				goto IL_000d;
			}
			int num;
			int num2;
			if (index >= 0)
			{
				num = -601350688;
				num2 = num;
			}
			else
			{
				num = -601350685;
				num2 = num;
			}
			goto IL_0012;
			IL_000d:
			num = -601350686;
			goto IL_0012;
			IL_0012:
			while (true)
			{
				switch (num ^ -601350685)
				{
				case 2:
					break;
				case 1:
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					return 0f;
				case 3:
					if (index >= _axisCount)
					{
						goto IL_005f;
					}
					return axes[index].timeInactive;
				default:
					return 0f;
				}
				break;
				IL_005f:
				num = -601350685;
			}
			goto IL_000d;
		}

		public float GetAxisLastTimeActive(int index)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return 0f;
			}
			if (index < 0 || index >= _axisCount)
			{
				return 0f;
			}
			return axes[index].lastTimeActive;
		}

		public float GetAxisLastTimeInactive(int index)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				goto IL_0019;
			}
			int num;
			int num2;
			if (index >= 0)
			{
				num = 452440129;
				num2 = num;
			}
			else
			{
				num = 452440131;
				num2 = num;
			}
			goto IL_001e;
			IL_0019:
			num = 452440128;
			goto IL_001e;
			IL_001e:
			while (true)
			{
				switch (num ^ 0x1AF7B041)
				{
				case 3:
					break;
				case 1:
					return 0f;
				case 0:
					if (index >= _axisCount)
					{
						goto IL_005f;
					}
					return axes[index].lastTimeInactive;
				default:
					return 0f;
				}
				break;
				IL_005f:
				num = 452440131;
			}
			goto IL_0019;
		}

		public float GetAxisRawTimeActive(int index)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				goto IL_0019;
			}
			int num;
			if (index >= 0)
			{
				if (index >= _axisCount)
				{
					num = 288278335;
					goto IL_001e;
				}
				return axes[index].timeActiveRaw;
			}
			goto IL_0051;
			IL_001e:
			switch (num ^ 0x112EC73D)
			{
			case 0:
				break;
			case 1:
				return 0f;
			default:
				goto IL_0051;
			}
			goto IL_0019;
			IL_0019:
			num = 288278332;
			goto IL_001e;
			IL_0051:
			return 0f;
		}

		public float GetAxisRawTimeInactive(int index)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				goto IL_000d;
			}
			int num;
			if (index >= 0)
			{
				if (index >= _axisCount)
				{
					num = 610496783;
					goto IL_0012;
				}
				return axes[index].timeInactiveRaw;
			}
			goto IL_005c;
			IL_0012:
			while (true)
			{
				switch (num ^ 0x2463710C)
				{
				case 0:
					break;
				case 2:
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					num = 610496781;
					continue;
				case 1:
					return 0f;
				default:
					goto IL_005c;
				}
				break;
			}
			goto IL_000d;
			IL_000d:
			num = 610496782;
			goto IL_0012;
			IL_005c:
			return 0f;
		}

		public float GetAxisRawLastTimeActive(int index)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				goto IL_000d;
			}
			int num;
			int num2;
			if (index < 0)
			{
				num = -1386986465;
				num2 = num;
			}
			else
			{
				num = -1386986467;
				num2 = num;
			}
			goto IL_0012;
			IL_000d:
			num = -1386986468;
			goto IL_0012;
			IL_0012:
			while (true)
			{
				switch (num ^ -1386986467)
				{
				case 3:
					break;
				case 1:
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					return 0f;
				case 0:
					if (index >= _axisCount)
					{
						goto IL_005f;
					}
					return axes[index].lastTimeActiveRaw;
				default:
					return 0f;
				}
				break;
				IL_005f:
				num = -1386986465;
			}
			goto IL_000d;
		}

		public float GetAxisRawLastTimeInactive(int index)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				goto IL_000d;
			}
			int num;
			int num2;
			if (index < 0)
			{
				num = 989659206;
				num2 = num;
			}
			else
			{
				num = 989659207;
				num2 = num;
			}
			goto IL_0012;
			IL_000d:
			num = 989659204;
			goto IL_0012;
			IL_0012:
			while (true)
			{
				switch (num ^ 0x3AFD0045)
				{
				case 0:
					break;
				case 1:
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					return 0f;
				case 2:
					if (index >= _axisCount)
					{
						goto IL_005f;
					}
					return axes[index].lastTimeInactiveRaw;
				default:
					return 0f;
				}
				break;
				IL_005f:
				num = 989659206;
			}
			goto IL_000d;
		}

		public float GetAxisById(int elementIdentifierId)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				goto IL_0019;
			}
			int axisIndex = kABaypBwJpdJPQfaNrcsDzJUopW.GetAxisIndex(elementIdentifierId);
			int num;
			int num2;
			if (axisIndex < 0)
			{
				num = -759617369;
				num2 = num;
			}
			else
			{
				num = -759617371;
				num2 = num;
			}
			goto IL_001e;
			IL_0019:
			num = -759617370;
			goto IL_001e;
			IL_001e:
			while (true)
			{
				switch (num ^ -759617372)
				{
				case 0:
					break;
				case 2:
					return 0f;
				case 1:
					if (axisIndex >= _axisCount)
					{
						goto IL_006c;
					}
					return axes[axisIndex].value;
				default:
					return 0f;
				}
				break;
				IL_006c:
				num = -759617369;
			}
			goto IL_0019;
		}

		public float GetAxisPrevById(int elementIdentifierId)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return 0f;
			}
			int axisIndex = kABaypBwJpdJPQfaNrcsDzJUopW.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0f;
			}
			return axes[axisIndex].valuePrev;
		}

		public float GetAxisRawById(int elementIdentifierId)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				goto IL_000d;
			}
			int axisIndex = kABaypBwJpdJPQfaNrcsDzJUopW.GetAxisIndex(elementIdentifierId);
			int num = -1354281882;
			goto IL_0012;
			IL_0012:
			while (true)
			{
				switch (num ^ -1354281883)
				{
				case 0:
					break;
				case 2:
					if (axisIndex >= _axisCount)
					{
						num = -1354281884;
						continue;
					}
					return axes[axisIndex].valueRaw;
				case 3:
				{
					int num2;
					if (axisIndex >= 0)
					{
						num = -1354281881;
						num2 = num;
					}
					else
					{
						num = -1354281884;
						num2 = num;
					}
					continue;
				}
				case 4:
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					return 0f;
				default:
					return 0f;
				}
				break;
			}
			goto IL_000d;
			IL_000d:
			num = -1354281887;
			goto IL_0012;
		}

		public float GetAxisRawPrevById(int elementIdentifierId)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				goto IL_000d;
			}
			int axisIndex = kABaypBwJpdJPQfaNrcsDzJUopW.GetAxisIndex(elementIdentifierId);
			int num;
			if (axisIndex >= 0)
			{
				if (axisIndex >= _axisCount)
				{
					num = -1416660026;
					goto IL_0012;
				}
				return axes[axisIndex].valueRawPrev;
			}
			goto IL_005e;
			IL_0012:
			switch (num ^ -1416660028)
			{
			case 0:
				break;
			case 1:
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return 0f;
			default:
				goto IL_005e;
			}
			goto IL_000d;
			IL_000d:
			num = -1416660027;
			goto IL_0012;
			IL_005e:
			return 0f;
		}

		public float GetAxisTimeActiveById(int elementIdentifierId)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				goto IL_000d;
			}
			int axisIndex = kABaypBwJpdJPQfaNrcsDzJUopW.GetAxisIndex(elementIdentifierId);
			int num;
			if (axisIndex >= 0)
			{
				if (axisIndex >= _axisCount)
				{
					num = -203371331;
					goto IL_0012;
				}
				return axes[axisIndex].timeActive;
			}
			goto IL_0069;
			IL_0012:
			while (true)
			{
				switch (num ^ -203371332)
				{
				case 0:
					break;
				case 2:
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					num = -203371329;
					continue;
				case 3:
					return 0f;
				default:
					goto IL_0069;
				}
				break;
			}
			goto IL_000d;
			IL_000d:
			num = -203371330;
			goto IL_0012;
			IL_0069:
			return 0f;
		}

		public float GetAxisTimeInactiveById(int elementIdentifierId)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				goto IL_0019;
			}
			int axisIndex = kABaypBwJpdJPQfaNrcsDzJUopW.GetAxisIndex(elementIdentifierId);
			int num;
			if (axisIndex >= 0)
			{
				if (axisIndex >= _axisCount)
				{
					num = 1659580967;
					goto IL_001e;
				}
				return axes[axisIndex].timeInactive;
			}
			goto IL_005e;
			IL_001e:
			switch (num ^ 0x62EB3225)
			{
			case 0:
				break;
			case 1:
				return 0f;
			default:
				goto IL_005e;
			}
			goto IL_0019;
			IL_0019:
			num = 1659580964;
			goto IL_001e;
			IL_005e:
			return 0f;
		}

		public float GetAxisLastTimeActiveById(int elementIdentifierId)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				goto IL_000d;
			}
			int axisIndex = kABaypBwJpdJPQfaNrcsDzJUopW.GetAxisIndex(elementIdentifierId);
			int num;
			int num2;
			if (axisIndex < 0)
			{
				num = -1303749804;
				num2 = num;
			}
			else
			{
				num = -1303749801;
				num2 = num;
			}
			goto IL_0012;
			IL_000d:
			num = -1303749802;
			goto IL_0012;
			IL_0012:
			while (true)
			{
				switch (num ^ -1303749803)
				{
				case 0:
					break;
				case 3:
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					return 0f;
				case 2:
					if (axisIndex >= _axisCount)
					{
						goto IL_006c;
					}
					return axes[axisIndex].lastTimeActive;
				default:
					return 0f;
				}
				break;
				IL_006c:
				num = -1303749804;
			}
			goto IL_000d;
		}

		public float GetAxisLastTimeInactiveById(int elementIdentifierId)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				goto IL_0019;
			}
			int axisIndex = kABaypBwJpdJPQfaNrcsDzJUopW.GetAxisIndex(elementIdentifierId);
			int num;
			if (axisIndex >= 0)
			{
				if (axisIndex >= _axisCount)
				{
					num = 1454552929;
					goto IL_001e;
				}
				return axes[axisIndex].lastTimeInactive;
			}
			goto IL_005e;
			IL_001e:
			switch (num ^ 0x56B2B763)
			{
			case 0:
				break;
			case 1:
				return 0f;
			default:
				goto IL_005e;
			}
			goto IL_0019;
			IL_0019:
			num = 1454552930;
			goto IL_001e;
			IL_005e:
			return 0f;
		}

		public float GetAxisRawTimeActiveById(int elementIdentifierId)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return 0f;
			}
			int axisIndex = kABaypBwJpdJPQfaNrcsDzJUopW.GetAxisIndex(elementIdentifierId);
			if (axisIndex >= 0)
			{
				while (true)
				{
					int num = 782437437;
					while (true)
					{
						switch (num ^ 0x2EA30C3C)
						{
						case 2:
							break;
						case 1:
							goto IL_004e;
						default:
							goto end_IL_0030;
						}
						break;
						IL_004e:
						if (axisIndex >= _axisCount)
						{
							num = 782437436;
							continue;
						}
						return axes[axisIndex].timeActiveRaw;
					}
					continue;
					end_IL_0030:
					break;
				}
			}
			return 0f;
		}

		public float GetAxisRawTimeInactiveById(int elementIdentifierId)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return 0f;
			}
			int axisIndex = kABaypBwJpdJPQfaNrcsDzJUopW.GetAxisIndex(elementIdentifierId);
			while (true)
			{
				int num = 478274202;
				while (true)
				{
					switch (num ^ 0x1C81E29B)
					{
					case 2:
						break;
					case 1:
						if (axisIndex >= 0)
						{
							if (axisIndex >= _axisCount)
							{
								goto IL_0057;
							}
							return axes[axisIndex].timeInactiveRaw;
						}
						goto default;
					default:
						return 0f;
					}
					break;
					IL_0057:
					num = 478274203;
				}
			}
		}

		public float GetAxisRawLastTimeActiveById(int elementIdentifierId)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				goto IL_000d;
			}
			int axisIndex = kABaypBwJpdJPQfaNrcsDzJUopW.GetAxisIndex(elementIdentifierId);
			int num = -625070772;
			goto IL_0012;
			IL_0012:
			while (true)
			{
				switch (num ^ -625070769)
				{
				case 2:
					break;
				case 1:
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					return 0f;
				case 3:
					if (axisIndex >= 0)
					{
						if (axisIndex >= _axisCount)
						{
							goto IL_0062;
						}
						return axes[axisIndex].lastTimeActiveRaw;
					}
					goto default;
				default:
					return 0f;
				}
				break;
				IL_0062:
				num = -625070769;
			}
			goto IL_000d;
			IL_000d:
			num = -625070770;
			goto IL_0012;
		}

		public float GetAxisRawLastTimeInactiveById(int elementIdentifierId)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return 0f;
			}
			int axisIndex = kABaypBwJpdJPQfaNrcsDzJUopW.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0f;
			}
			return axes[axisIndex].lastTimeInactiveRaw;
		}

		public Vector2 GetAxis2D(int index)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return Vector2.zero;
			}
			if (index >= 0)
			{
				if (index < _axis2DCount)
				{
					return axes2D[index].value;
				}
				goto IL_002c;
			}
			goto IL_004a;
			IL_0031:
			int num;
			Vector2 result = default(Vector2);
			switch (num ^ -330818780)
			{
			case 2:
				break;
			case 1:
				goto IL_004a;
			default:
				return result;
			}
			goto IL_002c;
			IL_004a:
			result = default(Vector2);
			num = -330818780;
			goto IL_0031;
			IL_002c:
			num = -330818779;
			goto IL_0031;
		}

		public Vector2 GetAxis2DPrev(int index)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return Vector2.zero;
			}
			if (index < 0 || index >= _axis2DCount)
			{
				return default(Vector2);
			}
			return axes2D[index].valuePrev;
		}

		public Vector2 GetAxis2DRaw(int index)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				goto IL_0019;
			}
			int num;
			int num2;
			if (index >= 0)
			{
				num = -1221530296;
				num2 = num;
			}
			else
			{
				num = -1221530295;
				num2 = num;
			}
			goto IL_001e;
			IL_0019:
			num = -1221530294;
			goto IL_001e;
			IL_001e:
			while (true)
			{
				switch (num ^ -1221530293)
				{
				case 0:
					break;
				case 1:
					return Vector2.zero;
				case 3:
					if (index >= _axis2DCount)
					{
						goto IL_005f;
					}
					return axes2D[index].valueRaw;
				default:
					return default(Vector2);
				}
				break;
				IL_005f:
				num = -1221530295;
			}
			goto IL_0019;
		}

		public Vector2 GetAxis2DRawPrev(int index)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				goto IL_000d;
			}
			int num;
			int num2;
			if (index >= 0)
			{
				num = 886030243;
				num2 = num;
			}
			else
			{
				num = 886030242;
				num2 = num;
			}
			goto IL_0012;
			IL_000d:
			num = 886030240;
			goto IL_0012;
			IL_0012:
			while (true)
			{
				switch (num ^ 0x34CFBFA3)
				{
				case 2:
					break;
				case 3:
					ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
					return Vector2.zero;
				case 0:
					if (index >= _axis2DCount)
					{
						goto IL_005f;
					}
					return axes2D[index].valueRawPrev;
				default:
					return default(Vector2);
				}
				break;
				IL_005f:
				num = 886030242;
			}
			goto IL_000d;
		}

		public override float GetLastTimeActive()
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				while (true)
				{
					int num = 618370474;
					while (true)
					{
						switch (num ^ 0x24DB95A8)
						{
						case 0:
							break;
						case 2:
							goto IL_002b;
						default:
							return 0f;
						}
						break;
						IL_002b:
						ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
						num = 618370473;
					}
				}
			}
			return GetLastTimeActive(false);
		}

		public override float GetLastTimeActive(bool useRawValues)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return 0f;
			}
			return MathTools.Max(base.GetLastTimeActive(useRawValues), GetLastTimeAnyAxisActive(useRawValues));
		}

		public override float GetLastTimeAnyElementChanged()
		{
			return GetLastTimeAnyElementChanged(false);
		}

		public override float GetLastTimeAnyElementChanged(bool useRawValues)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return 0f;
			}
			return MathTools.Max(base.GetLastTimeAnyElementChanged(useRawValues), GetLastTimeAnyAxisChanged(useRawValues));
		}

		public float GetLastTimeAnyAxisActive()
		{
			return GetLastTimeAnyAxisActive(false);
		}

		public float GetLastTimeAnyAxisActive(bool useRawValues)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return 0f;
			}
			if (axes == null)
			{
				return 0f;
			}
			float num = 0f;
			int num2 = 0;
			while (num2 < axes.Length)
			{
				while (true)
				{
					float num3 = (useRawValues ? axes[num2].lastTimeActiveRaw : axes[num2].lastTimeActive);
					int num4;
					int num5;
					if (num3 > num)
					{
						num4 = 1297522570;
						num5 = num4;
					}
					else
					{
						num4 = 1297522568;
						num5 = num4;
					}
					while (true)
					{
						switch (num4 ^ 0x4D569F8A)
						{
						case 3:
							num4 = 1297522574;
							continue;
						case 4:
							break;
						case 0:
							num = num3;
							num4 = 1297522568;
							continue;
						case 2:
							num2++;
							num4 = 1297522571;
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
			return num;
		}

		public float GetLastTimeAnyAxisChanged()
		{
			return GetLastTimeAnyAxisChanged(false);
		}

		public float GetLastTimeAnyAxisChanged(bool useRawValues)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return 0f;
			}
			if (axes == null)
			{
				return 0f;
			}
			float num = 0f;
			int num2 = 0;
			float num5 = default(float);
			while (num2 < axes.Length)
			{
				while (true)
				{
					IL_009d:
					float num3;
					if (useRawValues)
					{
						num3 = axes[num2].lastTimeValueChangedRaw;
						goto IL_0088;
					}
					int num4 = 792780580;
					goto IL_003c;
					IL_0088:
					num5 = num3;
					num4 = 792780581;
					goto IL_003c;
					IL_003c:
					while (true)
					{
						switch (num4 ^ 0x2F40DF26)
						{
						case 5:
							num4 = 792780583;
							continue;
						case 4:
							num2++;
							num4 = 792780582;
							continue;
						case 2:
							break;
						case 3:
							if (num5 > num)
							{
								num = num5;
								num4 = 792780578;
								continue;
							}
							goto case 4;
						case 1:
							goto IL_009d;
						default:
							goto end_IL_009d;
						}
						break;
					}
					num3 = axes[num2].lastTimeValueChanged;
					goto IL_0088;
					continue;
					end_IL_009d:
					break;
				}
			}
			return num;
		}

		public override ControllerPollingInfo PollForFirstElement()
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return ControllerPollingInfo.BasGLvYPyImwRTtaYaElepJTftA();
			}
			ControllerPollingInfo result = base.PollForFirstElement();
			if (result.success)
			{
				return result;
			}
			return PollForFirstAxis();
		}

		public override ControllerPollingInfo PollForFirstElementDown()
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return ControllerPollingInfo.BasGLvYPyImwRTtaYaElepJTftA();
			}
			ControllerPollingInfo result = base.PollForFirstElementDown();
			if (result.success)
			{
				return result;
			}
			return PollForFirstAxis();
		}

		public ControllerPollingInfo PollForFirstAxis()
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return ControllerPollingInfo.BasGLvYPyImwRTtaYaElepJTftA();
			}
			UpdatePollingFrameTracking();
			int num2 = default(int);
			Pole pole = default(Pole);
			int elementIdentifierId = default(int);
			while (true)
			{
				int num = 1680532606;
				while (true)
				{
					switch (num ^ 0x642AE47D)
					{
					case 0:
						break;
					case 3:
						cJJitEtFnVrjOVcwfJUseMMmAif();
						num = 1680532600;
						continue;
					case 2:
						return new ControllerPollingInfo(true, -1, id, _name, _type, ControllerElementType.Axis, num2, pole, kABaypBwJpdJPQfaNrcsDzJUopW.GetElementIdentifierName(elementIdentifierId), elementIdentifierId, KeyCode.None);
					case 5:
						num2 = 0;
						num = 1680532601;
						continue;
					case 1:
						if (!IsPolledAxisActive(num2, out pole, out elementIdentifierId))
						{
							num2++;
							num = 1680532601;
						}
						else
						{
							num = 1680532607;
						}
						continue;
					default:
						if (num2 >= _axisCount)
						{
							return ControllerPollingInfo.BasGLvYPyImwRTtaYaElepJTftA();
						}
						goto case 1;
					}
					break;
				}
			}
		}

		public override IEnumerable<ControllerPollingInfo> PollForAllElements()
		{
			HOHDpYseWbboCPujpKcdAtYijRO hOHDpYseWbboCPujpKcdAtYijRO = new HOHDpYseWbboCPujpKcdAtYijRO(-2);
			hOHDpYseWbboCPujpKcdAtYijRO.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = this;
			return hOHDpYseWbboCPujpKcdAtYijRO;
		}

		public override IEnumerable<ControllerPollingInfo> PollForAllElementsDown()
		{
			qTCtPYIuwXCiTvgABBwZeJqeKMN qTCtPYIuwXCiTvgABBwZeJqeKMN2 = new qTCtPYIuwXCiTvgABBwZeJqeKMN(-2);
			qTCtPYIuwXCiTvgABBwZeJqeKMN2.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = this;
			return qTCtPYIuwXCiTvgABBwZeJqeKMN2;
		}

		public IEnumerable<ControllerPollingInfo> PollForAllAxes()
		{
			fMcwAUqwHuFUkvMGtqsgcwYZlJi fMcwAUqwHuFUkvMGtqsgcwYZlJi2 = new fMcwAUqwHuFUkvMGtqsgcwYZlJi(-2);
			fMcwAUqwHuFUkvMGtqsgcwYZlJi2.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = this;
			return fMcwAUqwHuFUkvMGtqsgcwYZlJi2;
		}

		private void cJJitEtFnVrjOVcwfJUseMMmAif()
		{
			if (DqVmMEpmHxxCqZAUxzVDZvHfQYL == null)
			{
				DqVmMEpmHxxCqZAUxzVDZvHfQYL = new float[_axisCount];
				goto IL_0019;
			}
			goto IL_003f;
			IL_003f:
			UpdateLoopType currentUpdateLoop = default(UpdateLoopType);
			int num = default(int);
			int num2;
			if (mWRbAlErCrAbMyJarUEQVTumMOEf != wdbgvPKxtDGMDihueViFrcIdGVJE)
			{
				wdbgvPKxtDGMDihueViFrcIdGVJE = mWRbAlErCrAbMyJarUEQVTumMOEf;
				currentUpdateLoop = ReInput.currentUpdateLoop;
				num = 0;
				num2 = 1339740391;
				goto IL_001e;
			}
			return;
			IL_0019:
			num2 = 1339740390;
			goto IL_001e;
			IL_001e:
			while (true)
			{
				switch (num2 ^ 0x4FDAD0E7)
				{
				case 3:
					break;
				default:
					return;
				case 1:
					goto IL_003f;
				case 4:
					DqVmMEpmHxxCqZAUxzVDZvHfQYL[num] = axes[num].rUZPcTKJtxFtMbYehGtMPSgPeVXQ(currentUpdateLoop, _calibrationMap.GetAxis(num));
					num++;
					num2 = 1339740391;
					continue;
				case 0:
					goto IL_0095;
				case 2:
					return;
				}
				break;
				IL_0095:
				int num3;
				if (num >= _axisCount)
				{
					num2 = 1339740389;
					num3 = num2;
				}
				else
				{
					num2 = 1339740387;
					num3 = num2;
				}
			}
			goto IL_0019;
		}

		protected virtual bool IsPolledAxisActive(int index, out Pole pole, out int elementIdentifierId)
		{
			pole = Pole.Positive;
			elementIdentifierId = -1;
			float num2 = default(float);
			float value = default(float);
			while (true)
			{
				int num = -1248251435;
				while (true)
				{
					switch (num ^ -1248251439)
					{
					case 0:
						break;
					case 4:
						if (axes[index].UelUYluZSYxsmPMMGpbRwJNlVXq != null && axes[index].UelUYluZSYxsmPMMGpbRwJNlVXq._excludeFromPolling)
						{
							return false;
						}
						num2 = axes[index].rUZPcTKJtxFtMbYehGtMPSgPeVXQ(ReInput.currentUpdateLoop, _calibrationMap.GetAxis(index));
						num = -1248251438;
						continue;
					case 2:
						if (MathTools.Abs(value) <= 0.7f)
						{
							return false;
						}
						pole = ((!(MathTools.Sign(value) >= 0f)) ? Pole.Negative : Pole.Positive);
						elementIdentifierId = kABaypBwJpdJPQfaNrcsDzJUopW.axisElementIdentifierIds[index];
						num = -1248251440;
						continue;
					case 3:
						value = num2 - DqVmMEpmHxxCqZAUxzVDZvHfQYL[index];
						num = -1248251437;
						continue;
					default:
						if (elementIdentifierId < 0)
						{
							return false;
						}
						return true;
					}
					break;
				}
			}
		}

		public bool ImportCalibrationMapFromXmlString(string xmlString)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return false;
			}
			return calibrationMap.ImportXmlString(xmlString);
		}

		public bool ImportCalibrationMapFromJsonString(string jsonString)
		{
			if (ReInput._id != SsPwhbdijXONOlkRKHOkXryZrDq)
			{
				ReInput.CheckInitialized(SsPwhbdijXONOlkRKHOkXryZrDq);
				return false;
			}
			return calibrationMap.ImportJsonString(jsonString);
		}

		internal override void UpdateData(UpdateLoopType P_0)
		{
			base.UpdateData(P_0);
			bool flag = ReInput.IsInputAllowed(_type);
			int num6 = default(int);
			int num2 = default(int);
			bool flag2 = default(bool);
			bool flag4 = default(bool);
			int num5 = default(int);
			bool flag3 = default(bool);
			while (true)
			{
				int num = -923518059;
				while (true)
				{
					int num4;
					int num3;
					switch (num ^ -923518061)
					{
					case 4:
						break;
					case 16:
						if (num6 >= _axis2DCount)
						{
							num2 = 0;
							num = -923518056;
							continue;
						}
						goto case 1;
					case 10:
						num4 = ((_type == ControllerType.Custom) ? 1 : 0);
						goto IL_0094;
					case 15:
						num = -923518077;
						continue;
					case 0:
						if (flag2)
						{
							goto case 8;
						}
						if (flag4)
						{
							int num8;
							if (ROoGdHjYclVKlAjCTYtzRRhBjqvj.axisHasBeenPressedOSXLinux[num5])
							{
								num = -923518078;
								num8 = num;
							}
							else
							{
								num = -923518053;
								num8 = num;
							}
							continue;
						}
						goto case 17;
					case 14:
						num5++;
						num = -923518064;
						continue;
					case 9:
						axes[num5].pyoNZCTmUpoHfPgFCGCNvPXqorL();
						num = -923518051;
						continue;
					case 2:
						if (flag3)
						{
							axes[num5].pyoNZCTmUpoHfPgFCGCNvPXqorL(_calibrationMap.GetAxis(num5));
							num = -923518051;
							continue;
						}
						goto case 9;
					case 8:
						axes[num5].valueRaw = _calibrationMap.GetAxis(num5).calibratedZero;
						axes[num5].OOluiwLxtzwxTTaxHfhTuqhQzWo();
						num = -923518050;
						continue;
					case 3:
						if (num5 >= _axisCount)
						{
							num6 = 0;
							num = -923518052;
							continue;
						}
						goto case 7;
					case 6:
						if (_type == ControllerType.Joystick)
						{
							num4 = 1;
							goto IL_0094;
						}
						num = -923518055;
						continue;
					case 1:
						axes2D[num6].KLhVytWTxZfEwTEmoGmNtOGgDXib();
						num6++;
						num = -923518077;
						continue;
					case 17:
						axes[num5].valueRaw = ROoGdHjYclVKlAjCTYtzRRhBjqvj.axisValues[num5];
						num = -923518063;
						continue;
					case 12:
						axes[num2].IYHCOBrIiBubJZntUIWQrBQzmNt();
						num2++;
						num = -923518056;
						continue;
					case 7:
					{
						axes[num5].QCXpjnNrqQpxzhFzcjDxhVFbcDO(P_0);
						int num7;
						if (!flag)
						{
							num = -923518053;
							num7 = num;
						}
						else
						{
							num = -923518061;
							num7 = num;
						}
						continue;
					}
					case 13:
						num = -923518051;
						continue;
					case 5:
						num3 = ((!ROoGdHjYclVKlAjCTYtzRRhBjqvj.hasReceivedInput) ? 1 : 0);
						goto IL_024f;
					default:
						{
							if (num2 >= _axisCount)
							{
								return;
							}
							goto case 12;
						}
						IL_024f:
						flag2 = (byte)num3 != 0;
						num5 = 0;
						num = -923518064;
						continue;
						IL_0094:
						flag3 = (byte)num4 != 0;
						flag4 = _type == ControllerType.Joystick && ReInput.checkNeverPressed;
						if (_type == ControllerType.Joystick)
						{
							num = -923518058;
							continue;
						}
						num3 = 0;
						goto IL_024f;
					}
					break;
				}
			}
		}

		internal bool cpzmCEYuhYTrJSJZAXcQNiCYwcX(ActionElementMap P_0, int P_1, bool P_2, bool P_3, out float P_4)
		{
			P_4 = 0f;
			ControllerElementType elementType = P_0._elementType;
			if (P_1 != P_0._actionId)
			{
				return false;
			}
			int zwgAVZCxcUqkUVeFEgwfcqhdLwxy = P_0.ZwgAVZCxcUqkUVeFEgwfcqhdLwxy;
			if (zwgAVZCxcUqkUVeFEgwfcqhdLwxy >= 0)
			{
				bool flag = default(bool);
				float num2 = default(float);
				AxisRange axisRange = default(AxisRange);
				while (true)
				{
					int num = -769337319;
					while (true)
					{
						float num4;
						float num3;
						switch (num ^ -769337314)
						{
						case 17:
							break;
						case 7:
							goto IL_0091;
						case 5:
							goto IL_00a1;
						case 1:
							return true;
						case 19:
							goto end_IL_0028;
						case 8:
							goto IL_00e7;
						case 18:
							if (!flag || P_0._axisRange != AxisRange.Positive)
							{
								goto case 10;
							}
							if (!(num2 >= 0f))
							{
								num = -769337327;
								continue;
							}
							num4 = num2;
							goto IL_0214;
						case 10:
							if (!flag && P_0._axisRange == AxisRange.Negative)
							{
								if (!(num2 <= 0f))
								{
									num = -769337334;
									continue;
								}
								num3 = num2;
								goto IL_0164;
							}
							goto case 2;
						case 13:
							if (P_0._axisContribution == Pole.Negative)
							{
								num2 *= -1f;
								num = -769337318;
								continue;
							}
							goto IL_027d;
						case 20:
							num3 = 0f;
							goto IL_0164;
						case 14:
							num = -769337318;
							continue;
						case 12:
							goto IL_0179;
						case 11:
							if (P_0._invert)
							{
								num2 *= -1f;
								num = -769337318;
								continue;
							}
							goto IL_027d;
						case 2:
							num2 = 0f;
							num = -769337318;
							continue;
						case 3:
							goto IL_01cd;
						case 0:
							goto IL_01e7;
						case 15:
							num4 = 0f;
							goto IL_0214;
						case 16:
							goto IL_021f;
						case 9:
							if (P_0._axisContribution == Pole.Positive)
							{
								num2 *= -1f;
								num = -769337328;
								continue;
							}
							goto IL_027d;
						case 6:
							flag = ((MathTools.Sign(num2) > 0f) ? true : false);
							num = -769337332;
							continue;
						default:
							goto IL_027d;
							IL_0164:
							num2 = num3;
							num = -769337321;
							continue;
							IL_0214:
							num2 = num4;
							num = -769337325;
							continue;
						}
						break;
						IL_021f:
						float num5 = axes[zwgAVZCxcUqkUVeFEgwfcqhdLwxy].valuePrev;
						goto IL_023b;
						IL_01cd:
						if (!MathTools.Approximately(num2, 0f))
						{
							if (elementType == ControllerElementType.Axis)
							{
								axisRange = P_0._axisRange;
								num = -769337317;
								continue;
							}
							goto IL_01e7;
						}
						num = -769337313;
						continue;
						IL_00a1:
						int num6;
						if (axisRange != AxisRange.Full)
						{
							num = -769337320;
							num6 = num;
						}
						else
						{
							num = -769337323;
							num6 = num;
						}
						continue;
						IL_0195:
						float num7;
						num2 = num7;
						num = -769337315;
						continue;
						IL_023b:
						num2 = num5;
						num = -769337315;
						continue;
						IL_01e7:
						if (elementType == ControllerElementType.Button && P_0._axisContribution == Pole.Negative)
						{
							num2 *= -1f;
							num = -769337318;
							continue;
						}
						goto IL_027d;
						IL_0091:
						if (zwgAVZCxcUqkUVeFEgwfcqhdLwxy >= _axisCount)
						{
							num = -769337331;
							continue;
						}
						if (!P_3)
						{
							goto IL_00e7;
						}
						if (!P_2)
						{
							num = -769337330;
							continue;
						}
						num5 = axes[zwgAVZCxcUqkUVeFEgwfcqhdLwxy].valueRawPrev;
						goto IL_023b;
						IL_00e7:
						if (!P_2)
						{
							num = -769337326;
							continue;
						}
						num7 = axes[zwgAVZCxcUqkUVeFEgwfcqhdLwxy].valueRaw;
						goto IL_0195;
						IL_0179:
						num7 = axes[zwgAVZCxcUqkUVeFEgwfcqhdLwxy].value;
						goto IL_0195;
						IL_027d:
						P_4 = num2;
						return true;
					}
					continue;
					end_IL_0028:
					break;
				}
			}
			return false;
		}

		internal override void BakeMap(ControllerMap P_0)
		{
			if (P_0 == null)
			{
				goto IL_0003;
			}
			goto IL_0067;
			IL_0003:
			int num = -322927559;
			goto IL_0008;
			IL_0008:
			IList<ActionElementMap> axisMaps = default(IList<ActionElementMap>);
			int num2 = default(int);
			while (true)
			{
				switch (num ^ -322927553)
				{
				case 3:
					break;
				case 6:
					return;
				case 2:
					goto IL_0039;
				case 5:
					BakeActionElementMap(P_0, axisMaps[num2]);
					num2++;
					num = -322927554;
					continue;
				case 4:
					goto IL_0067;
				case 0:
					num2 = 0;
					num = -322927554;
					continue;
				default:
					if (num2 >= axisMaps.Count)
					{
						return;
					}
					goto case 5;
				}
				break;
			}
			goto IL_0003;
			IL_0039:
			base.BakeMap(P_0);
			ControllerMapWithAxes controllerMapWithAxes = default(ControllerMapWithAxes);
			axisMaps = controllerMapWithAxes.AxisMaps;
			num = -322927553;
			goto IL_0008;
			IL_0067:
			controllerMapWithAxes = P_0 as ControllerMapWithAxes;
			if (controllerMapWithAxes == null)
			{
				Logger.LogWarning("Map type must inherit from ControllerMapWithAxes!");
				return;
			}
			goto IL_0039;
		}

		internal override void BakeActionElementMap(ControllerMap P_0, ActionElementMap P_1)
		{
			if (P_1 == null)
			{
				return;
			}
			while (true)
			{
				base.BakeActionElementMap(P_0, P_1);
				int num = -1591451244;
				while (true)
				{
					switch (num ^ -1591451248)
					{
					case 2:
						num = -1591451247;
						continue;
					case 1:
						break;
					case 4:
					{
						int num2;
						if (P_1._elementType != ControllerElementType.Axis)
						{
							num = -1591451248;
							num2 = num;
						}
						else
						{
							num = -1591451245;
							num2 = num;
						}
						continue;
					}
					case 0:
						return;
					default:
						P_1.rlmHPtRaQxhZqxiQpUHlvKLFmAK(P_0);
						return;
					}
					break;
				}
			}
		}

		internal void ODTYWdyclUhredorWasTpSLgYSGu()
		{
			int num = 0;
			while (true)
			{
				int num2;
				int num3;
				if (num >= axisCount)
				{
					num2 = -1224582116;
					num3 = num2;
				}
				else
				{
					num2 = -1224582113;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ -1224582119)
					{
					case 0:
						num2 = -1224582113;
						continue;
					default:
						return;
					case 4:
						_calibrationMap.Axes[num].calibrationMode = AlternateAxisCalibrationType.Default;
						num2 = -1224582127;
						continue;
					case 7:
						throw new NotImplementedException();
					case 8:
						num++;
						num2 = -1224582120;
						continue;
					case 2:
						goto IL_0076;
					case 3:
						num2 = -1224582114;
						continue;
					case 1:
						break;
					case 6:
						switch (axes[num].UelUYluZSYxsmPMMGpbRwJNlVXq._specialAxisType)
						{
						case SpecialAxisType.None:
							break;
						case SpecialAxisType.Throttle:
							goto IL_0076;
						default:
							goto IL_00ed;
						}
						goto case 4;
					case 5:
						return;
						IL_00ed:
						num2 = -1224582118;
						continue;
						IL_0076:
						_calibrationMap.Axes[num].calibrationMode = EnumConverter.ToAlternateAxisCalibrationType(ReInput.configVars.throttleCalibrationMode);
						num2 = -1224582127;
						continue;
					}
					break;
				}
			}
		}

		internal override void Clear()
		{
			base.Clear();
			int num2 = default(int);
			while (true)
			{
				int num = 1073321558;
				while (true)
				{
					switch (num ^ 0x3FF99657)
					{
					case 2:
						break;
					case 4:
						num2++;
						num = 1073321556;
						continue;
					case 0:
						if (axes[num2] != null)
						{
							axes[num2].Reset();
							num = 1073321555;
							continue;
						}
						goto case 4;
					case 1:
						num2 = 0;
						num = 1073321556;
						continue;
					default:
						if (num2 >= _axisCount)
						{
							return;
						}
						goto case 0;
					}
					break;
				}
			}
		}

		[CompilerGenerated]
		private IEnumerable<ControllerPollingInfo> OtyKouqSANAZQSpRtGqqtfDniWwe()
		{
			return base.PollForAllElements();
		}

		[CompilerGenerated]
		private IEnumerable<ControllerPollingInfo> VHQLgKwmqCkCHIqetsnVehdVNDg()
		{
			return base.PollForAllElementsDown();
		}
	}
}
