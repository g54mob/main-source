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
		private sealed class yNVmqLMGnrMnLgyIegZiYdufqmx : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
		{
			private ControllerPollingInfo ubyTdixGSFKGaFQFZdQnpwgWIvJ;

			private int isaqVUvqwfWYqOUtovbpbCbxgPc;

			private int TFdbdCIUKXTQPHFlNuiMVnWNXiVT;

			public ControllerWithAxes syCPfFbHYMDOvEPjTnPLBqiOhsPv;

			public ControllerPollingInfo qkXDGxkwaRvWnEwyckLJhhQXdKl;

			public ControllerPollingInfo cnQnHBERcTsZHOcHXoEFekDOhad;

			public IEnumerator<ControllerPollingInfo> KMgVEhuoYioXREaDfevsvSEgFVu;

			public IEnumerator<ControllerPollingInfo> zWRMgemAFaownhDmgzHZGoebjwBC;

			ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
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
			IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
			{
				if (Thread.CurrentThread.ManagedThreadId == TFdbdCIUKXTQPHFlNuiMVnWNXiVT)
				{
					goto IL_0012;
				}
				goto IL_003c;
				IL_0012:
				int num = 913666247;
				goto IL_0017;
				IL_0017:
				yNVmqLMGnrMnLgyIegZiYdufqmx yNVmqLMGnrMnLgyIegZiYdufqmx2 = default(yNVmqLMGnrMnLgyIegZiYdufqmx);
				while (true)
				{
					switch (num ^ 0x367570C2)
					{
					case 0:
						break;
					case 2:
						goto IL_003c;
					case 4:
						num = 913666243;
						continue;
					case 3:
						yNVmqLMGnrMnLgyIegZiYdufqmx2 = this;
						num = 913666246;
						continue;
					case 5:
						if (isaqVUvqwfWYqOUtovbpbCbxgPc == -2)
						{
							isaqVUvqwfWYqOUtovbpbCbxgPc = 0;
							num = 913666241;
							continue;
						}
						goto IL_003c;
					default:
						return yNVmqLMGnrMnLgyIegZiYdufqmx2;
					}
					break;
				}
				goto IL_0012;
				IL_003c:
				yNVmqLMGnrMnLgyIegZiYdufqmx2 = new yNVmqLMGnrMnLgyIegZiYdufqmx(0);
				yNVmqLMGnrMnLgyIegZiYdufqmx2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = syCPfFbHYMDOvEPjTnPLBqiOhsPv;
				num = 913666243;
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
					switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
					{
					case 4:
						isaqVUvqwfWYqOUtovbpbCbxgPc = 3;
						num = 642683543;
						goto IL_002b;
					case 2:
						goto IL_0144;
					case 0:
						goto IL_01a0;
						IL_002b:
						while (true)
						{
							switch (num ^ 0x264E929B)
							{
							case 0:
								num = 642683548;
								continue;
							case 11:
								cnQnHBERcTsZHOcHXoEFekDOhad = zWRMgemAFaownhDmgzHZGoebjwBC.Current;
								ubyTdixGSFKGaFQFZdQnpwgWIvJ = cnQnHBERcTsZHOcHXoEFekDOhad;
								isaqVUvqwfWYqOUtovbpbCbxgPc = 4;
								result = true;
								goto end_IL_0000;
							case 9:
								isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
								num = 642683542;
								continue;
							case 13:
								if (!KMgVEhuoYioXREaDfevsvSEgFVu.MoveNext())
								{
									WGmZBpthxKLXLScOLKGOOIsFBTjJ();
									num = 642683550;
									continue;
								}
								goto case 2;
							case 5:
								zWRMgemAFaownhDmgzHZGoebjwBC = syCPfFbHYMDOvEPjTnPLBqiOhsPv.PollForAllAxes().GetEnumerator();
								isaqVUvqwfWYqOUtovbpbCbxgPc = 3;
								num = 642683539;
								continue;
							case 15:
								break;
							case 4:
								result = true;
								num = 642683541;
								continue;
							case 1:
								IxKiSoonFRGakhRcstHNLhYxeQV();
								num = 642683544;
								continue;
							case 14:
								goto end_IL_0000;
							case 6:
								goto IL_0144;
							case 10:
								goto IL_0155;
							case 12:
								goto IL_0175;
							case 8:
								num = 642683543;
								continue;
							case 7:
								goto IL_01a0;
							case 2:
								qkXDGxkwaRvWnEwyckLJhhQXdKl = KMgVEhuoYioXREaDfevsvSEgFVu.Current;
								ubyTdixGSFKGaFQFZdQnpwgWIvJ = qkXDGxkwaRvWnEwyckLJhhQXdKl;
								isaqVUvqwfWYqOUtovbpbCbxgPc = 2;
								num = 642683551;
								continue;
							default:
								goto end_IL_0008;
							}
							break;
							IL_0175:
							int num2;
							if (zWRMgemAFaownhDmgzHZGoebjwBC.MoveNext())
							{
								num = 642683536;
								num2 = num;
							}
							else
							{
								num = 642683546;
								num2 = num;
							}
						}
						goto case 4;
						IL_01a0:
						isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
						if (ReInput._id != syCPfFbHYMDOvEPjTnPLBqiOhsPv.vuPDNwATQFuTZgAqTRoviXUGAgFM)
						{
							ReInput.CheckInitialized(syCPfFbHYMDOvEPjTnPLBqiOhsPv.vuPDNwATQFuTZgAqTRoviXUGAgFM);
							num = 642683544;
							goto IL_002b;
						}
						goto IL_0155;
						IL_0144:
						isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
						num = 642683542;
						goto IL_002b;
						IL_0155:
						KMgVEhuoYioXREaDfevsvSEgFVu = ((Controller)syCPfFbHYMDOvEPjTnPLBqiOhsPv).PollForAllElements().GetEnumerator();
						num = 642683538;
						goto IL_002b;
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
				switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
				{
				case 1:
				case 2:
					try
					{
					}
					finally
					{
						WGmZBpthxKLXLScOLKGOOIsFBTjJ();
					}
					break;
				}
				switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
				{
				case 3:
				case 4:
					try
					{
						break;
					}
					finally
					{
						IxKiSoonFRGakhRcstHNLhYxeQV();
					}
				}
			}

			[DebuggerHidden]
			public yNVmqLMGnrMnLgyIegZiYdufqmx(int _003C_003E1__state)
			{
				isaqVUvqwfWYqOUtovbpbCbxgPc = _003C_003E1__state;
				TFdbdCIUKXTQPHFlNuiMVnWNXiVT = Thread.CurrentThread.ManagedThreadId;
			}

			private void WGmZBpthxKLXLScOLKGOOIsFBTjJ()
			{
				isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
				if (KMgVEhuoYioXREaDfevsvSEgFVu != null)
				{
					KMgVEhuoYioXREaDfevsvSEgFVu.Dispose();
				}
			}

			private void IxKiSoonFRGakhRcstHNLhYxeQV()
			{
				isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
				if (zWRMgemAFaownhDmgzHZGoebjwBC != null)
				{
					zWRMgemAFaownhDmgzHZGoebjwBC.Dispose();
				}
			}
		}

		private sealed class LUiiBocRTfLOhAdEXHKaqUGrHsB : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
		{
			private ControllerPollingInfo ubyTdixGSFKGaFQFZdQnpwgWIvJ;

			private int isaqVUvqwfWYqOUtovbpbCbxgPc;

			private int TFdbdCIUKXTQPHFlNuiMVnWNXiVT;

			public ControllerWithAxes syCPfFbHYMDOvEPjTnPLBqiOhsPv;

			public ControllerPollingInfo KTDQsPfkgnarPeUpcYUShNYYzdXr;

			public ControllerPollingInfo vhFMNgphrnEswFAwqdgdbsXBhmSD;

			public IEnumerator<ControllerPollingInfo> pckbcPgEMMkCIvBfxSGyQYtxWAtt;

			public IEnumerator<ControllerPollingInfo> iYfGDAVihYhnsCEYMvIjwbipVuo;

			ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
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
			IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
			{
				if (Thread.CurrentThread.ManagedThreadId == TFdbdCIUKXTQPHFlNuiMVnWNXiVT)
				{
					goto IL_0012;
				}
				goto IL_004e;
				IL_0012:
				int num = 1153448224;
				goto IL_0017;
				IL_0017:
				LUiiBocRTfLOhAdEXHKaqUGrHsB lUiiBocRTfLOhAdEXHKaqUGrHsB = default(LUiiBocRTfLOhAdEXHKaqUGrHsB);
				while (true)
				{
					switch (num ^ 0x44C03922)
					{
					case 0:
						break;
					case 2:
						if (isaqVUvqwfWYqOUtovbpbCbxgPc == -2)
						{
							isaqVUvqwfWYqOUtovbpbCbxgPc = 0;
							lUiiBocRTfLOhAdEXHKaqUGrHsB = this;
							num = 1153448225;
							continue;
						}
						goto IL_004e;
					case 1:
						goto IL_004e;
					default:
						return lUiiBocRTfLOhAdEXHKaqUGrHsB;
					}
					break;
				}
				goto IL_0012;
				IL_004e:
				lUiiBocRTfLOhAdEXHKaqUGrHsB = new LUiiBocRTfLOhAdEXHKaqUGrHsB(0);
				lUiiBocRTfLOhAdEXHKaqUGrHsB.syCPfFbHYMDOvEPjTnPLBqiOhsPv = syCPfFbHYMDOvEPjTnPLBqiOhsPv;
				num = 1153448225;
				goto IL_0017;
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
					switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
					{
					case 2:
						isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
						num = 718935203;
						goto IL_002b;
					case 4:
						goto IL_00fc;
					case 0:
						goto IL_017c;
						IL_002b:
						while (true)
						{
							switch (num ^ 0x2ADA14A9)
							{
							case 9:
								num = 718935208;
								continue;
							case 7:
								vhFMNgphrnEswFAwqdgdbsXBhmSD = iYfGDAVihYhnsCEYMvIjwbipVuo.Current;
								ubyTdixGSFKGaFQFZdQnpwgWIvJ = vhFMNgphrnEswFAwqdgdbsXBhmSD;
								isaqVUvqwfWYqOUtovbpbCbxgPc = 4;
								num = 718935211;
								continue;
							case 5:
								if (!iYfGDAVihYhnsCEYMvIjwbipVuo.MoveNext())
								{
									XJNifonKudakRKPhBMciPYPIZujU();
									num = 718935201;
									continue;
								}
								goto case 7;
							case 13:
								if (ReInput._id != syCPfFbHYMDOvEPjTnPLBqiOhsPv.vuPDNwATQFuTZgAqTRoviXUGAgFM)
								{
									ReInput.CheckInitialized(syCPfFbHYMDOvEPjTnPLBqiOhsPv.vuPDNwATQFuTZgAqTRoviXUGAgFM);
									num = 718935201;
									continue;
								}
								goto case 4;
							case 11:
								break;
							case 6:
								goto IL_00fc;
							case 2:
								return true;
							case 10:
								if (!pckbcPgEMMkCIvBfxSGyQYtxWAtt.MoveNext())
								{
									fOLlAlOihpjkQitJFTfkBHlqHXL();
									iYfGDAVihYhnsCEYMvIjwbipVuo = syCPfFbHYMDOvEPjTnPLBqiOhsPv.PollForAllAxes().GetEnumerator();
									isaqVUvqwfWYqOUtovbpbCbxgPc = 3;
									num = 718935212;
									continue;
								}
								goto case 12;
							case 3:
								ubyTdixGSFKGaFQFZdQnpwgWIvJ = KTDQsPfkgnarPeUpcYUShNYYzdXr;
								isaqVUvqwfWYqOUtovbpbCbxgPc = 2;
								return true;
							case 1:
								goto IL_017c;
							case 4:
								pckbcPgEMMkCIvBfxSGyQYtxWAtt = ((Controller)syCPfFbHYMDOvEPjTnPLBqiOhsPv).PollForAllElementsDown().GetEnumerator();
								isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
								num = 718935209;
								continue;
							case 12:
								KTDQsPfkgnarPeUpcYUShNYYzdXr = pckbcPgEMMkCIvBfxSGyQYtxWAtt.Current;
								num = 718935210;
								continue;
							case 0:
								num = 718935203;
								continue;
							default:
								goto end_IL_0008;
							}
							break;
						}
						goto case 2;
						IL_017c:
						isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
						num = 718935204;
						goto IL_002b;
						IL_00fc:
						isaqVUvqwfWYqOUtovbpbCbxgPc = 3;
						num = 718935212;
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
				int num = isaqVUvqwfWYqOUtovbpbCbxgPc;
				while (true)
				{
					int num2 = 1775379053;
					while (true)
					{
						switch (num2 ^ 0x69D2226C)
						{
						case 0:
							break;
						case 1:
							switch (num)
							{
							default:
								goto IL_0035;
							case 1:
							case 2:
								break;
							}
							try
							{
							}
							finally
							{
								fOLlAlOihpjkQitJFTfkBHlqHXL();
							}
							goto default;
						default:
						{
							int num3 = isaqVUvqwfWYqOUtovbpbCbxgPc;
							while (true)
							{
								int num4 = 1775379054;
								while (true)
								{
									switch (num4 ^ 0x69D2226C)
									{
									case 0:
										break;
									default:
										return;
									case 2:
										switch (num3)
										{
										case 3:
										case 4:
											try
											{
												return;
											}
											finally
											{
												XJNifonKudakRKPhBMciPYPIZujU();
											}
										}
										goto IL_007c;
									case 1:
										return;
									}
									break;
									IL_007c:
									num4 = 1775379053;
								}
							}
						}
						}
						break;
						IL_0035:
						num2 = 1775379054;
					}
				}
			}

			[DebuggerHidden]
			public LUiiBocRTfLOhAdEXHKaqUGrHsB(int _003C_003E1__state)
			{
				isaqVUvqwfWYqOUtovbpbCbxgPc = _003C_003E1__state;
				TFdbdCIUKXTQPHFlNuiMVnWNXiVT = Thread.CurrentThread.ManagedThreadId;
			}

			private void fOLlAlOihpjkQitJFTfkBHlqHXL()
			{
				isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
				while (true)
				{
					int num = -1318774944;
					while (true)
					{
						switch (num ^ -1318774942)
						{
						case 0:
							break;
						default:
							return;
						case 2:
							if (pckbcPgEMMkCIvBfxSGyQYtxWAtt != null)
							{
								goto IL_002d;
							}
							return;
						case 1:
							return;
						}
						break;
						IL_002d:
						pckbcPgEMMkCIvBfxSGyQYtxWAtt.Dispose();
						num = -1318774941;
					}
				}
			}

			private void XJNifonKudakRKPhBMciPYPIZujU()
			{
				isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
				while (true)
				{
					int num = -2121021981;
					while (true)
					{
						switch (num ^ -2121021982)
						{
						case 2:
							break;
						default:
							return;
						case 1:
							if (iYfGDAVihYhnsCEYMvIjwbipVuo != null)
							{
								goto IL_002d;
							}
							return;
						case 0:
							return;
						}
						break;
						IL_002d:
						iYfGDAVihYhnsCEYMvIjwbipVuo.Dispose();
						num = -2121021982;
					}
				}
			}
		}

		private sealed class UlcKDZSUkwtIxMQlaxFnwboKQsN : IDisposable, IEnumerable<ControllerPollingInfo>, IEnumerator<ControllerPollingInfo>, IEnumerator, IEnumerable
		{
			private ControllerPollingInfo ubyTdixGSFKGaFQFZdQnpwgWIvJ;

			private int isaqVUvqwfWYqOUtovbpbCbxgPc;

			private int TFdbdCIUKXTQPHFlNuiMVnWNXiVT;

			public ControllerWithAxes syCPfFbHYMDOvEPjTnPLBqiOhsPv;

			public int GXvziLknNGVrIIBwDhbLbJqdCioF;

			public Pole DeZqoOGdRxnNfjWfgDzLbNLPuEM;

			public int ToLOKcjFyZbOQtHPCxUwfVVknfZ;

			ControllerPollingInfo IEnumerator<ControllerPollingInfo>.Current
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
			IEnumerator<ControllerPollingInfo> IEnumerable<ControllerPollingInfo>.GetEnumerator()
			{
				if (Thread.CurrentThread.ManagedThreadId == TFdbdCIUKXTQPHFlNuiMVnWNXiVT && isaqVUvqwfWYqOUtovbpbCbxgPc == -2)
				{
					isaqVUvqwfWYqOUtovbpbCbxgPc = 0;
					goto IL_0023;
				}
				goto IL_0065;
				IL_0028:
				int num;
				UlcKDZSUkwtIxMQlaxFnwboKQsN ulcKDZSUkwtIxMQlaxFnwboKQsN = default(UlcKDZSUkwtIxMQlaxFnwboKQsN);
				while (true)
				{
					switch (num ^ 0x405BBF5)
					{
					case 2:
						break;
					case 3:
						ulcKDZSUkwtIxMQlaxFnwboKQsN = this;
						num = 67484661;
						continue;
					case 1:
						ulcKDZSUkwtIxMQlaxFnwboKQsN.syCPfFbHYMDOvEPjTnPLBqiOhsPv = syCPfFbHYMDOvEPjTnPLBqiOhsPv;
						num = 67484661;
						continue;
					case 4:
						goto IL_0065;
					default:
						return ulcKDZSUkwtIxMQlaxFnwboKQsN;
					}
					break;
				}
				goto IL_0023;
				IL_0065:
				ulcKDZSUkwtIxMQlaxFnwboKQsN = new UlcKDZSUkwtIxMQlaxFnwboKQsN(0);
				num = 67484660;
				goto IL_0028;
				IL_0023:
				num = 67484662;
				goto IL_0028;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ControllerPollingInfo>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				int num;
				switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
				{
				case 0:
					isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
					num = 1691729040;
					goto IL_001f;
				case 1:
					{
						isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
						num = 1691729042;
						goto IL_001f;
					}
					IL_001f:
					while (true)
					{
						switch (num ^ 0x64D5BC92)
						{
						case 6:
							num = 1691729048;
							continue;
						case 10:
							break;
						case 5:
							if (syCPfFbHYMDOvEPjTnPLBqiOhsPv.IsPolledAxisActive(GXvziLknNGVrIIBwDhbLbJqdCioF, out DeZqoOGdRxnNfjWfgDzLbNLPuEM, out ToLOKcjFyZbOQtHPCxUwfVVknfZ))
							{
								ubyTdixGSFKGaFQFZdQnpwgWIvJ = new ControllerPollingInfo(success: true, -1, syCPfFbHYMDOvEPjTnPLBqiOhsPv.id, syCPfFbHYMDOvEPjTnPLBqiOhsPv._name, syCPfFbHYMDOvEPjTnPLBqiOhsPv._type, ControllerElementType.Axis, GXvziLknNGVrIIBwDhbLbJqdCioF, DeZqoOGdRxnNfjWfgDzLbNLPuEM, syCPfFbHYMDOvEPjTnPLBqiOhsPv.REZiFujnwfIcWniRKvMxDxhPHlx.GetElementIdentifierName(ToLOKcjFyZbOQtHPCxUwfVVknfZ), ToLOKcjFyZbOQtHPCxUwfVVknfZ, KeyCode.None);
								num = 1691729041;
								continue;
							}
							goto case 0;
						case 9:
							return true;
						case 2:
							if (ReInput._id != syCPfFbHYMDOvEPjTnPLBqiOhsPv.vuPDNwATQFuTZgAqTRoviXUGAgFM)
							{
								ReInput.CheckInitialized(syCPfFbHYMDOvEPjTnPLBqiOhsPv.vuPDNwATQFuTZgAqTRoviXUGAgFM);
								num = 1691729046;
								continue;
							}
							goto case 8;
						case 8:
							syCPfFbHYMDOvEPjTnPLBqiOhsPv.UpdatePollingFrameTracking();
							syCPfFbHYMDOvEPjTnPLBqiOhsPv.FQDgLVIHSLgsTraJoCazqawziLQN();
							num = 1691729043;
							continue;
						case 3:
							isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
							num = 1691729051;
							continue;
						case 7:
							goto IL_015e;
						case 0:
							GXvziLknNGVrIIBwDhbLbJqdCioF++;
							num = 1691729045;
							continue;
						case 1:
							GXvziLknNGVrIIBwDhbLbJqdCioF = 0;
							num = 1691729045;
							continue;
						default:
							goto end_IL_0008;
						}
						break;
						IL_015e:
						int num2;
						if (GXvziLknNGVrIIBwDhbLbJqdCioF >= syCPfFbHYMDOvEPjTnPLBqiOhsPv._axisCount)
						{
							num = 1691729046;
							num2 = num;
						}
						else
						{
							num = 1691729047;
							num2 = num;
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
			public UlcKDZSUkwtIxMQlaxFnwboKQsN(int _003C_003E1__state)
			{
				isaqVUvqwfWYqOUtovbpbCbxgPc = _003C_003E1__state;
				TFdbdCIUKXTQPHFlNuiMVnWNXiVT = Thread.CurrentThread.ManagedThreadId;
			}
		}

		protected readonly int _axisCount;

		protected readonly int _axis2DCount;

		protected readonly Axis[] axes;

		protected readonly ReadOnlyCollection<Axis> axes_readOnly;

		protected readonly Axis2D[] axes2D;

		protected readonly ReadOnlyCollection<Axis2D> axes2D_readOnly;

		protected CalibrationMap _calibrationMap;

		private float[] sQHvqLTgcbHvvuZxcyxMLCreDms;

		private uint NedELQwnCLRFGDIPnCZWlBeozKy = uint.MaxValue;

		private Func<int, int> CzobyhntzUPHVFIzhckaEWaHoDJm;

		public int axisCount
		{
			get
			{
				if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
				{
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
					return 0;
				}
				return _axisCount;
			}
		}

		public int axis2DCount
		{
			get
			{
				if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
				{
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
					return 0;
				}
				return _axis2DCount;
			}
		}

		public IList<Axis> Axes
		{
			get
			{
				if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
				{
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
					return EmptyObjects<Axis>.EmptyReadOnlyIListT;
				}
				return axes_readOnly;
			}
		}

		public IList<Axis2D> Axes2D
		{
			get
			{
				if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
				{
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
					return EmptyObjects<Axis2D>.EmptyReadOnlyIListT;
				}
				return axes2D_readOnly;
			}
		}

		public CalibrationMap calibrationMap
		{
			get
			{
				if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
				{
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
					return null;
				}
				return _calibrationMap;
			}
		}

		public IList<ControllerElementIdentifier> AxisElementIdentifiers
		{
			get
			{
				if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
				{
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
					return EmptyObjects<ControllerElementIdentifier>.EmptyReadOnlyIListT;
				}
				return REZiFujnwfIcWniRKvMxDxhPHlx.axisElementIdentifiers_readOnly;
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
				itKYLEidIwjerGGrDGqPNskdaYz(axes[i]);
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
			nBTvkuIMRIsljBSTPJWsUnWhXhu();
			CzobyhntzUPHVFIzhckaEWaHoDJm = hardwareMap.GetAxisIndex;
		}

		public override Element GetElementById(int elementIdentifierId)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				goto IL_0019;
			}
			int num;
			Element elementById = default(Element);
			if (REZiFujnwfIcWniRKvMxDxhPHlx == null)
			{
				num = 1768331536;
			}
			else
			{
				elementById = base.GetElementById(elementIdentifierId);
				num = 1768331538;
			}
			goto IL_001e;
			IL_0019:
			num = 1768331537;
			goto IL_001e;
			IL_001e:
			switch (num ^ 0x69669910)
			{
			case 3:
				break;
			case 1:
				return null;
			case 0:
				return null;
			default:
			{
				if (elementById != null)
				{
					return elementById;
				}
				int axisIndex = REZiFujnwfIcWniRKvMxDxhPHlx.GetAxisIndex(elementIdentifierId);
				if (axisIndex < 0)
				{
					return null;
				}
				return axes[axisIndex];
			}
			}
			goto IL_0019;
		}

		public int GetAxisIndexById(int elementIdentifierId)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return -1;
			}
			return REZiFujnwfIcWniRKvMxDxhPHlx.GetAxisIndex(elementIdentifierId);
		}

		public float GetAxis(int index)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return 0f;
			}
			if (index < 0 || index >= _axisCount)
			{
				return 0f;
			}
			return axes[index].value;
		}

		public float GetAxisPrev(int index)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return 0f;
			}
			if (index < 0 || index >= _axisCount)
			{
				return 0f;
			}
			return axes[index].valuePrev;
		}

		public float GetAxisRaw(int index)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return 0f;
			}
			if (index >= 0)
			{
				while (true)
				{
					int num = 1701576087;
					while (true)
					{
						switch (num ^ 0x656BFD96)
						{
						case 0:
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
							num = 1701576084;
							continue;
						}
						return axes[index].valueRaw;
					}
					continue;
					end_IL_0023:
					break;
				}
			}
			return 0f;
		}

		public float GetAxisRawPrev(int index)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return 0f;
			}
			if (index >= 0)
			{
				while (true)
				{
					int num = -63667597;
					while (true)
					{
						switch (num ^ -63667598)
						{
						case 0:
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
							num = -63667600;
							continue;
						}
						return axes[index].valueRawPrev;
					}
					continue;
					end_IL_0023:
					break;
				}
			}
			return 0f;
		}

		public double GetAxisTimeActive(int index)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				goto IL_0019;
			}
			int num;
			if (index >= 0)
			{
				if (index >= _axisCount)
				{
					num = -692242695;
					goto IL_001e;
				}
				return axes[index].timeActive;
			}
			goto IL_0055;
			IL_001e:
			switch (num ^ -692242696)
			{
			case 0:
				break;
			case 2:
				return 0.0;
			default:
				goto IL_0055;
			}
			goto IL_0019;
			IL_0019:
			num = -692242694;
			goto IL_001e;
			IL_0055:
			return 0.0;
		}

		public double GetAxisTimeInactive(int index)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				goto IL_0019;
			}
			int num;
			if (index >= 0)
			{
				if (index >= _axisCount)
				{
					num = 1878264458;
					goto IL_001e;
				}
				return axes[index].timeInactive;
			}
			goto IL_0055;
			IL_001e:
			switch (num ^ 0x6FF40A8A)
			{
			case 2:
				break;
			case 1:
				return 0.0;
			default:
				goto IL_0055;
			}
			goto IL_0019;
			IL_0019:
			num = 1878264459;
			goto IL_001e;
			IL_0055:
			return 0.0;
		}

		public double GetAxisLastTimeActive(int index)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return 0.0;
			}
			if (index < 0 || index >= _axisCount)
			{
				return 0.0;
			}
			return axes[index].lastTimeActive;
		}

		public double GetAxisLastTimeInactive(int index)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return 0.0;
			}
			if (index >= 0)
			{
				while (true)
				{
					int num = -1323183450;
					while (true)
					{
						switch (num ^ -1323183452)
						{
						case 0:
							break;
						case 2:
							goto IL_0045;
						default:
							goto end_IL_0027;
						}
						break;
						IL_0045:
						if (index >= _axisCount)
						{
							num = -1323183451;
							continue;
						}
						return axes[index].lastTimeInactive;
					}
					continue;
					end_IL_0027:
					break;
				}
			}
			return 0.0;
		}

		public double GetAxisRawTimeActive(int index)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				goto IL_0019;
			}
			int num;
			int num2;
			if (index < 0)
			{
				num = 975050238;
				num2 = num;
			}
			else
			{
				num = 975050237;
				num2 = num;
			}
			goto IL_001e;
			IL_0019:
			num = 975050239;
			goto IL_001e;
			IL_001e:
			while (true)
			{
				switch (num ^ 0x3A1E15FE)
				{
				case 2:
					break;
				case 1:
					return 0.0;
				case 3:
					if (index >= _axisCount)
					{
						goto IL_0063;
					}
					return axes[index].timeActiveRaw;
				default:
					return 0.0;
				}
				break;
				IL_0063:
				num = 975050238;
			}
			goto IL_0019;
		}

		public double GetAxisRawTimeInactive(int index)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return 0.0;
			}
			if (index >= 0)
			{
				while (true)
				{
					int num = -452624394;
					while (true)
					{
						switch (num ^ -452624396)
						{
						case 0:
							break;
						case 2:
							goto IL_0045;
						default:
							goto end_IL_0027;
						}
						break;
						IL_0045:
						if (index >= _axisCount)
						{
							num = -452624395;
							continue;
						}
						return axes[index].timeInactiveRaw;
					}
					continue;
					end_IL_0027:
					break;
				}
			}
			return 0.0;
		}

		public double GetAxisRawLastTimeActive(int index)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return 0.0;
			}
			if (index < 0 || index >= _axisCount)
			{
				return 0.0;
			}
			return axes[index].lastTimeActiveRaw;
		}

		public double GetAxisRawLastTimeInactive(int index)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return 0.0;
			}
			if (index < 0 || index >= _axisCount)
			{
				return 0.0;
			}
			return axes[index].lastTimeInactiveRaw;
		}

		public float GetAxisById(int elementIdentifierId)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return 0f;
			}
			int axisIndex = REZiFujnwfIcWniRKvMxDxhPHlx.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0f;
			}
			return axes[axisIndex].value;
		}

		public float GetAxisPrevById(int elementIdentifierId)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				goto IL_0019;
			}
			int axisIndex = REZiFujnwfIcWniRKvMxDxhPHlx.GetAxisIndex(elementIdentifierId);
			int num = -184690597;
			goto IL_001e;
			IL_001e:
			while (true)
			{
				switch (num ^ -184690598)
				{
				case 0:
					break;
				case 3:
					return 0f;
				case 1:
				{
					int num2;
					if (axisIndex >= 0)
					{
						num = -184690594;
						num2 = num;
					}
					else
					{
						num = -184690600;
						num2 = num;
					}
					continue;
				}
				case 4:
					if (axisIndex >= _axisCount)
					{
						num = -184690600;
						continue;
					}
					return axes[axisIndex].valuePrev;
				default:
					return 0f;
				}
				break;
			}
			goto IL_0019;
			IL_0019:
			num = -184690599;
			goto IL_001e;
		}

		public float GetAxisRawById(int elementIdentifierId)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return 0f;
			}
			int axisIndex = REZiFujnwfIcWniRKvMxDxhPHlx.GetAxisIndex(elementIdentifierId);
			if (axisIndex >= 0)
			{
				while (true)
				{
					int num = -2024840289;
					while (true)
					{
						switch (num ^ -2024840290)
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
							num = -2024840290;
							continue;
						}
						return axes[axisIndex].valueRaw;
					}
					continue;
					end_IL_0030:
					break;
				}
			}
			return 0f;
		}

		public float GetAxisRawPrevById(int elementIdentifierId)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return 0f;
			}
			int axisIndex = REZiFujnwfIcWniRKvMxDxhPHlx.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0f;
			}
			return axes[axisIndex].valueRawPrev;
		}

		public double GetAxisTimeActiveById(int elementIdentifierId)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return 0.0;
			}
			int axisIndex = REZiFujnwfIcWniRKvMxDxhPHlx.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0.0;
			}
			return axes[axisIndex].timeActive;
		}

		public double GetAxisTimeInactiveById(int elementIdentifierId)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				goto IL_000d;
			}
			int axisIndex = REZiFujnwfIcWniRKvMxDxhPHlx.GetAxisIndex(elementIdentifierId);
			int num;
			if (axisIndex >= 0)
			{
				if (axisIndex >= _axisCount)
				{
					num = -205759531;
					goto IL_0012;
				}
				return axes[axisIndex].timeInactive;
			}
			goto IL_0062;
			IL_0012:
			switch (num ^ -205759532)
			{
			case 0:
				break;
			case 2:
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return 0.0;
			default:
				goto IL_0062;
			}
			goto IL_000d;
			IL_000d:
			num = -205759530;
			goto IL_0012;
			IL_0062:
			return 0.0;
		}

		public double GetAxisLastTimeActiveById(int elementIdentifierId)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				goto IL_000d;
			}
			int axisIndex = REZiFujnwfIcWniRKvMxDxhPHlx.GetAxisIndex(elementIdentifierId);
			int num;
			int num2;
			if (axisIndex >= 0)
			{
				num = -1787489365;
				num2 = num;
			}
			else
			{
				num = -1787489366;
				num2 = num;
			}
			goto IL_0012;
			IL_000d:
			num = -1787489368;
			goto IL_0012;
			IL_0012:
			while (true)
			{
				switch (num ^ -1787489366)
				{
				case 3:
					break;
				case 2:
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
					return 0.0;
				case 1:
					if (axisIndex >= _axisCount)
					{
						goto IL_0070;
					}
					return axes[axisIndex].lastTimeActive;
				default:
					return 0.0;
				}
				break;
				IL_0070:
				num = -1787489366;
			}
			goto IL_000d;
		}

		public double GetAxisLastTimeInactiveById(int elementIdentifierId)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return 0.0;
			}
			int axisIndex = REZiFujnwfIcWniRKvMxDxhPHlx.GetAxisIndex(elementIdentifierId);
			while (true)
			{
				int num = -1138056906;
				while (true)
				{
					switch (num ^ -1138056908)
					{
					case 0:
						break;
					case 2:
						if (axisIndex >= 0)
						{
							if (axisIndex >= _axisCount)
							{
								goto IL_005b;
							}
							return axes[axisIndex].lastTimeInactive;
						}
						goto default;
					default:
						return 0.0;
					}
					break;
					IL_005b:
					num = -1138056907;
				}
			}
		}

		public double GetAxisRawTimeActiveById(int elementIdentifierId)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				goto IL_0019;
			}
			int axisIndex = REZiFujnwfIcWniRKvMxDxhPHlx.GetAxisIndex(elementIdentifierId);
			int num;
			if (axisIndex >= 0)
			{
				if (axisIndex >= _axisCount)
				{
					num = 470914840;
					goto IL_001e;
				}
				return axes[axisIndex].timeActiveRaw;
			}
			goto IL_0062;
			IL_001e:
			switch (num ^ 0x1C11971A)
			{
			case 0:
				break;
			case 1:
				return 0.0;
			default:
				goto IL_0062;
			}
			goto IL_0019;
			IL_0019:
			num = 470914843;
			goto IL_001e;
			IL_0062:
			return 0.0;
		}

		public double GetAxisRawTimeInactiveById(int elementIdentifierId)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				goto IL_000d;
			}
			int axisIndex = REZiFujnwfIcWniRKvMxDxhPHlx.GetAxisIndex(elementIdentifierId);
			int num;
			int num2;
			if (axisIndex >= 0)
			{
				num = 1007137;
				num2 = num;
			}
			else
			{
				num = 1007136;
				num2 = num;
			}
			goto IL_0012;
			IL_000d:
			num = 1007138;
			goto IL_0012;
			IL_0012:
			while (true)
			{
				switch (num ^ 0xF5E20)
				{
				case 3:
					break;
				case 2:
					ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
					return 0.0;
				case 1:
					if (axisIndex >= _axisCount)
					{
						goto IL_0070;
					}
					return axes[axisIndex].timeInactiveRaw;
				default:
					return 0.0;
				}
				break;
				IL_0070:
				num = 1007136;
			}
			goto IL_000d;
		}

		public double GetAxisRawLastTimeActiveById(int elementIdentifierId)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return 0.0;
			}
			int axisIndex = REZiFujnwfIcWniRKvMxDxhPHlx.GetAxisIndex(elementIdentifierId);
			if (axisIndex < 0 || axisIndex >= _axisCount)
			{
				return 0.0;
			}
			return axes[axisIndex].lastTimeActiveRaw;
		}

		public double GetAxisRawLastTimeInactiveById(int elementIdentifierId)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return 0.0;
			}
			int axisIndex = REZiFujnwfIcWniRKvMxDxhPHlx.GetAxisIndex(elementIdentifierId);
			while (true)
			{
				int num = -1150380521;
				while (true)
				{
					switch (num ^ -1150380523)
					{
					case 0:
						break;
					case 2:
						if (axisIndex >= 0)
						{
							if (axisIndex >= _axisCount)
							{
								goto IL_005b;
							}
							return axes[axisIndex].lastTimeInactiveRaw;
						}
						goto default;
					default:
						return 0.0;
					}
					break;
					IL_005b:
					num = -1150380524;
				}
			}
		}

		public Vector2 GetAxis2D(int index)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return Vector2.zero;
			}
			if (index < 0 || index >= _axis2DCount)
			{
				return default(Vector2);
			}
			return axes2D[index].value;
		}

		public Vector2 GetAxis2DPrev(int index)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				goto IL_0019;
			}
			int num;
			if (index >= 0)
			{
				if (index >= _axis2DCount)
				{
					num = -1372624634;
					goto IL_001e;
				}
				return axes2D[index].valuePrev;
			}
			goto IL_0051;
			IL_001e:
			switch (num ^ -1372624634)
			{
			case 2:
				break;
			case 1:
				return Vector2.zero;
			default:
				goto IL_0051;
			}
			goto IL_0019;
			IL_0019:
			num = -1372624633;
			goto IL_001e;
			IL_0051:
			return default(Vector2);
		}

		public Vector2 GetAxis2DRaw(int index)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return Vector2.zero;
			}
			if (index < 0 || index >= _axis2DCount)
			{
				return default(Vector2);
			}
			return axes2D[index].valueRaw;
		}

		public Vector2 GetAxis2DRawPrev(int index)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return Vector2.zero;
			}
			if (index >= 0)
			{
				while (true)
				{
					int num = 300600611;
					while (true)
					{
						switch (num ^ 0x11EACD22)
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
						if (index >= _axis2DCount)
						{
							num = 300600610;
							continue;
						}
						return axes2D[index].valueRawPrev;
					}
					continue;
					end_IL_0023:
					break;
				}
			}
			return default(Vector2);
		}

		public override double GetLastTimeActive()
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return 0.0;
			}
			return GetLastTimeActive(useRawValues: false);
		}

		public override double GetLastTimeActive(bool useRawValues)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return 0.0;
			}
			return MathTools.Max(base.GetLastTimeActive(useRawValues), GetLastTimeAnyAxisActive(useRawValues));
		}

		public override double GetLastTimeAnyElementChanged()
		{
			return GetLastTimeAnyElementChanged(useRawValues: false);
		}

		public override double GetLastTimeAnyElementChanged(bool useRawValues)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return 0.0;
			}
			return MathTools.Max(base.GetLastTimeAnyElementChanged(useRawValues), GetLastTimeAnyAxisChanged(useRawValues));
		}

		public double GetLastTimeAnyAxisActive()
		{
			return GetLastTimeAnyAxisActive(useRawValues: false);
		}

		public double GetLastTimeAnyAxisActive(bool useRawValues)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return 0.0;
			}
			if (axes == null)
			{
				return 0.0;
			}
			double num = 0.0;
			int num2 = 0;
			while (true)
			{
				int num3;
				int num4;
				if (num2 < axes.Length)
				{
					num3 = -2071116659;
					num4 = num3;
				}
				else
				{
					num3 = -2071116660;
					num4 = num3;
				}
				while (true)
				{
					double num5;
					double num6;
					switch (num3 ^ -2071116663)
					{
					case 0:
						num3 = -2071116659;
						continue;
					case 4:
						if (!useRawValues)
						{
							num3 = -2071116662;
							continue;
						}
						num5 = axes[num2].lastTimeActiveRaw;
						goto IL_00af;
					case 1:
						break;
					case 3:
						num5 = axes[num2].lastTimeActive;
						goto IL_00af;
					case 2:
						num2++;
						num3 = -2071116664;
						continue;
					default:
						{
							return num;
						}
						IL_00af:
						num6 = num5;
						if (num6 > num)
						{
							num = num6;
							num3 = -2071116661;
							continue;
						}
						goto case 2;
					}
					break;
				}
			}
		}

		public double GetLastTimeAnyAxisChanged()
		{
			return GetLastTimeAnyAxisChanged(useRawValues: false);
		}

		public double GetLastTimeAnyAxisChanged(bool useRawValues)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				goto IL_0019;
			}
			if (axes == null)
			{
				return 0.0;
			}
			double num = 0.0;
			int num2 = 0;
			int num3 = -757401538;
			goto IL_001e;
			IL_0019:
			num3 = -757401541;
			goto IL_001e;
			IL_001e:
			while (true)
			{
				switch (num3 ^ -757401537)
				{
				case 6:
					break;
				case 4:
					return 0.0;
				case 1:
					num3 = -757401539;
					continue;
				case 2:
				{
					int num5;
					if (num2 >= axes.Length)
					{
						num3 = -757401540;
						num5 = num3;
					}
					else
					{
						num3 = -757401537;
						num5 = num3;
					}
					continue;
				}
				case 0:
				{
					double num4 = (useRawValues ? axes[num2].lastTimeValueChangedRaw : axes[num2].lastTimeValueChanged);
					if (num4 > num)
					{
						num = num4;
						num3 = -757401542;
						continue;
					}
					goto case 5;
				}
				case 5:
					num2++;
					num3 = -757401539;
					continue;
				default:
					return num;
				}
				break;
			}
			goto IL_0019;
		}

		public override ControllerPollingInfo PollForFirstElement()
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				goto IL_000d;
			}
			ControllerPollingInfo result = base.PollForFirstElement();
			int num = 306442399;
			goto IL_0012;
			IL_0012:
			switch (num ^ 0x1243F09D)
			{
			case 0:
				break;
			case 1:
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return ControllerPollingInfo.czsDbiqQNWsvQguTJNJasHdCGwp();
			default:
				if (result.success)
				{
					return result;
				}
				return PollForFirstAxis();
			}
			goto IL_000d;
			IL_000d:
			num = 306442396;
			goto IL_0012;
		}

		public override ControllerPollingInfo PollForFirstElementDown()
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return ControllerPollingInfo.czsDbiqQNWsvQguTJNJasHdCGwp();
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
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return ControllerPollingInfo.czsDbiqQNWsvQguTJNJasHdCGwp();
			}
			UpdatePollingFrameTracking();
			FQDgLVIHSLgsTraJoCazqawziLQN();
			int num = 0;
			while (true)
			{
				int num2 = 1857444226;
				while (true)
				{
					switch (num2 ^ 0x6EB65983)
					{
					case 0:
						break;
					case 1:
						num2 = 1857444225;
						continue;
					case 3:
					{
						if (IsPolledAxisActive(num, out var pole, out var elementIdentifierId))
						{
							return new ControllerPollingInfo(success: true, -1, id, _name, _type, ControllerElementType.Axis, num, pole, REZiFujnwfIcWniRKvMxDxhPHlx.GetElementIdentifierName(elementIdentifierId), elementIdentifierId, KeyCode.None);
						}
						num++;
						num2 = 1857444225;
						continue;
					}
					default:
						if (num >= _axisCount)
						{
							return ControllerPollingInfo.czsDbiqQNWsvQguTJNJasHdCGwp();
						}
						goto case 3;
					}
					break;
				}
			}
		}

		public override IEnumerable<ControllerPollingInfo> PollForAllElements()
		{
			yNVmqLMGnrMnLgyIegZiYdufqmx yNVmqLMGnrMnLgyIegZiYdufqmx2 = new yNVmqLMGnrMnLgyIegZiYdufqmx(-2);
			yNVmqLMGnrMnLgyIegZiYdufqmx2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = this;
			return yNVmqLMGnrMnLgyIegZiYdufqmx2;
		}

		public override IEnumerable<ControllerPollingInfo> PollForAllElementsDown()
		{
			LUiiBocRTfLOhAdEXHKaqUGrHsB lUiiBocRTfLOhAdEXHKaqUGrHsB = new LUiiBocRTfLOhAdEXHKaqUGrHsB(-2);
			lUiiBocRTfLOhAdEXHKaqUGrHsB.syCPfFbHYMDOvEPjTnPLBqiOhsPv = this;
			return lUiiBocRTfLOhAdEXHKaqUGrHsB;
		}

		public IEnumerable<ControllerPollingInfo> PollForAllAxes()
		{
			UlcKDZSUkwtIxMQlaxFnwboKQsN ulcKDZSUkwtIxMQlaxFnwboKQsN = new UlcKDZSUkwtIxMQlaxFnwboKQsN(-2);
			ulcKDZSUkwtIxMQlaxFnwboKQsN.syCPfFbHYMDOvEPjTnPLBqiOhsPv = this;
			return ulcKDZSUkwtIxMQlaxFnwboKQsN;
		}

		private void FQDgLVIHSLgsTraJoCazqawziLQN()
		{
			if (sQHvqLTgcbHvvuZxcyxMLCreDms == null)
			{
				goto IL_000b;
			}
			goto IL_0090;
			IL_000b:
			int num = 340513902;
			goto IL_0010;
			IL_0010:
			UpdateLoopType currentUpdateLoop = default(UpdateLoopType);
			int num2 = default(int);
			while (true)
			{
				switch (num ^ 0x144BD46A)
				{
				case 0:
					break;
				default:
					return;
				case 2:
					currentUpdateLoop = ReInput.currentUpdateLoop;
					num2 = 0;
					num = 340513897;
					continue;
				case 1:
					sQHvqLTgcbHvvuZxcyxMLCreDms[num2] = axes[num2].WVXBFCcIKtgeJAdRinUDwYKKLEcN(currentUpdateLoop, _calibrationMap.GetAxis(num2));
					num2++;
					num = 340513897;
					continue;
				case 4:
					sQHvqLTgcbHvvuZxcyxMLCreDms = new float[_axisCount];
					num = 340513900;
					continue;
				case 6:
					goto IL_0090;
				case 3:
					goto IL_00b4;
				case 5:
					return;
				}
				break;
				IL_00b4:
				int num3;
				if (num2 >= _axisCount)
				{
					num = 340513903;
					num3 = num;
				}
				else
				{
					num = 340513899;
					num3 = num;
				}
			}
			goto IL_000b;
			IL_0090:
			if (LPRvVuBbNdwGHkLtadwNDWvlXBr != NedELQwnCLRFGDIPnCZWlBeozKy)
			{
				NedELQwnCLRFGDIPnCZWlBeozKy = LPRvVuBbNdwGHkLtadwNDWvlXBr;
				num = 340513896;
				goto IL_0010;
			}
		}

		protected virtual bool IsPolledAxisActive(int index, out Pole pole, out int elementIdentifierId)
		{
			pole = Pole.Positive;
			elementIdentifierId = -1;
			float num2 = default(float);
			while (true)
			{
				int num = -54171213;
				while (true)
				{
					switch (num ^ -54171216)
					{
					case 0:
						break;
					case 3:
						if (axes[index].fLnddiiYsQMexRarBgYYAedEaIXb != null)
						{
							if (axes[index].fLnddiiYsQMexRarBgYYAedEaIXb._excludeFromPolling)
							{
								return false;
							}
							if (axes[index].fLnddiiYsQMexRarBgYYAedEaIXb._dataFormat == AxisCoordinateMode.Relative)
							{
								return false;
							}
						}
						num2 = axes[index].WVXBFCcIKtgeJAdRinUDwYKKLEcN(ReInput.currentUpdateLoop, _calibrationMap.GetAxis(index));
						num = -54171215;
						continue;
					case 1:
					{
						float value = num2 - sQHvqLTgcbHvvuZxcyxMLCreDms[index];
						if (MathTools.Abs(value) <= axes[index].effectivePollingDeadZone)
						{
							num = -54171214;
							continue;
						}
						pole = ((!(MathTools.Sign(value) >= 0f)) ? Pole.Negative : Pole.Positive);
						elementIdentifierId = REZiFujnwfIcWniRKvMxDxhPHlx.axisElementIdentifierIds[index];
						if (elementIdentifierId < 0)
						{
							return false;
						}
						return true;
					}
					default:
						return false;
					}
					break;
				}
			}
		}

		public bool ImportCalibrationMapFromXmlString(string xmlString)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				while (true)
				{
					int num = -201380120;
					while (true)
					{
						switch (num ^ -201380119)
						{
						case 0:
							break;
						case 1:
							goto IL_002b;
						default:
							return false;
						}
						break;
						IL_002b:
						ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
						num = -201380117;
					}
				}
			}
			return calibrationMap.ImportXmlString(xmlString);
		}

		public bool ImportCalibrationMapFromJsonString(string jsonString)
		{
			if (ReInput._id != vuPDNwATQFuTZgAqTRoviXUGAgFM)
			{
				ReInput.CheckInitialized(vuPDNwATQFuTZgAqTRoviXUGAgFM);
				return false;
			}
			return calibrationMap.ImportJsonString(jsonString);
		}

		internal override void kckuoUXEwQcigNbCseRHnXueOkT(UpdateLoopType P_0)
		{
			base.kckuoUXEwQcigNbCseRHnXueOkT(P_0);
			bool flag = ReInput.IsInputAllowed(_type);
			int num3 = default(int);
			int num4 = default(int);
			bool flag3 = default(bool);
			int num2 = default(int);
			bool flag2 = default(bool);
			bool flag4 = default(bool);
			while (true)
			{
				int num = -1709133606;
				while (true)
				{
					switch (num ^ -1709133609)
					{
					case 9:
						break;
					case 8:
						axes[num3].UfmxyWnNJnWjGmoVLMrGjDpvidgd();
						num = -1709133625;
						continue;
					case 14:
						if (num3 >= _axisCount)
						{
							num4 = 0;
							num = -1709133613;
							continue;
						}
						goto case 12;
					case 2:
						flag3 = _type == ControllerType.Joystick && ReInput.checkNeverPressed;
						num = -1709133608;
						continue;
					case 4:
						if (num4 >= _axis2DCount)
						{
							num2 = 0;
							num = -1709133612;
							continue;
						}
						goto case 6;
					case 1:
						if (!flag || flag2)
						{
							goto case 11;
						}
						if (flag3)
						{
							int num5;
							if (cMcAtEwaThLpgGZfIIRmVCJQjDU.axisHasBeenPressedOSXLinux[num3])
							{
								num = -1709133603;
								num5 = num;
							}
							else
							{
								num = -1709133604;
								num5 = num;
							}
							continue;
						}
						goto case 10;
					case 13:
						flag4 = _type == ControllerType.Joystick || _type == ControllerType.Custom;
						num = -1709133611;
						continue;
					case 11:
						axes[num3].valueRaw = _calibrationMap.GetAxis(num3).calibratedZero;
						axes[num3].vxKJnbbUnljIHqACpEEDqVaTVVB();
						num = -1709133625;
						continue;
					case 5:
						axes[num2].hFLjdYLxLBBvCamKPTvTlraimvOj();
						num = -1709133609;
						continue;
					case 16:
						num3++;
						num = -1709133607;
						continue;
					case 7:
						num = -1709133607;
						continue;
					case 15:
						flag2 = _type == ControllerType.Joystick && !cMcAtEwaThLpgGZfIIRmVCJQjDU.hasReceivedInput;
						num3 = 0;
						num = -1709133616;
						continue;
					case 6:
						axes2D[num4].fEfTuMgIgNspmcJifDAbjyclSfZ();
						num4++;
						num = -1709133613;
						continue;
					case 0:
						num2++;
						num = -1709133612;
						continue;
					case 12:
						axes[num3].xDTKWglCBUFigMkMzCsklYfiJCd(P_0);
						num = -1709133610;
						continue;
					case 10:
						axes[num3].valueRaw = cMcAtEwaThLpgGZfIIRmVCJQjDU.axisValues[num3];
						if (flag4)
						{
							axes[num3].UfmxyWnNJnWjGmoVLMrGjDpvidgd(_calibrationMap.GetAxis(num3));
							num = -1709133625;
							continue;
						}
						goto case 8;
					default:
						if (num2 >= _axisCount)
						{
							return;
						}
						goto case 5;
					}
					break;
				}
			}
		}

		internal bool XQpXFDuyTYlEkjUyZFurRASNWpF(ActionElementMap P_0, int P_1, bool P_2, bool P_3, out float P_4)
		{
			P_4 = 0f;
			AxisRange axisRange = default(AxisRange);
			float num2 = default(float);
			ControllerElementType elementType = default(ControllerElementType);
			int ouusLSVThShOJXeTBDNomJoAhtU = default(int);
			bool flag = default(bool);
			while (true)
			{
				int num = -885202869;
				while (true)
				{
					float num5;
					int num3;
					switch (num ^ -885202856)
					{
					case 11:
						break;
					case 1:
						num = -885202871;
						continue;
					case 7:
					{
						int num7;
						if (axisRange == AxisRange.Full)
						{
							num = -885202858;
							num7 = num;
						}
						else
						{
							num = -885202851;
							num7 = num;
						}
						continue;
					}
					case 15:
						num2 = 0f;
						num = -885202850;
						continue;
					case 19:
						elementType = P_0._elementType;
						if (P_1 != P_0._actionId)
						{
							return false;
						}
						ouusLSVThShOJXeTBDNomJoAhtU = P_0.ouusLSVThShOJXeTBDNomJoAhtU;
						if (ouusLSVThShOJXeTBDNomJoAhtU < 0)
						{
							goto case 0;
						}
						if (ouusLSVThShOJXeTBDNomJoAhtU >= _axisCount)
						{
							num = -885202856;
							continue;
						}
						if (P_3)
						{
							if (P_2)
							{
								num5 = axes[ouusLSVThShOJXeTBDNomJoAhtU].valueRawPrev;
								goto IL_00ea;
							}
							num = -885202854;
							continue;
						}
						goto case 4;
					case 2:
						num5 = axes[ouusLSVThShOJXeTBDNomJoAhtU].valuePrev;
						goto IL_00ea;
					case 10:
						num = -885202850;
						continue;
					case 5:
						if (!(MathTools.Sign(num2) > 0f))
						{
							num = -885202872;
							continue;
						}
						num3 = 1;
						goto IL_01a2;
					case 17:
						if (MathTools.Approximately(num2, 0f))
						{
							num = -885202860;
							continue;
						}
						if (elementType == ControllerElementType.Axis)
						{
							axisRange = P_0._axisRange;
							num = -885202849;
							continue;
						}
						goto case 8;
					case 18:
						if (!flag)
						{
							int num6;
							if (P_0._axisRange == AxisRange.Negative)
							{
								num = -885202859;
								num6 = num;
							}
							else
							{
								num = -885202857;
								num6 = num;
							}
							continue;
						}
						goto case 15;
					case 13:
						num2 = ((num2 <= 0f) ? num2 : 0f);
						if (P_0._axisContribution == Pole.Positive)
						{
							num2 *= -1f;
							num = -885202850;
							continue;
						}
						goto default;
					case 0:
						return false;
					case 16:
						num3 = 0;
						goto IL_01a2;
					case 14:
					{
						int num4;
						if (P_0._invert)
						{
							num = -885202863;
							num4 = num;
						}
						else
						{
							num = -885202850;
							num4 = num;
						}
						continue;
					}
					case 9:
						num2 *= -1f;
						num = -885202862;
						continue;
					case 3:
						if (P_0._axisContribution == Pole.Negative)
						{
							num2 *= -1f;
							num = -885202850;
							continue;
						}
						goto default;
					case 8:
						if (elementType == ControllerElementType.Button && P_0._axisContribution == Pole.Negative)
						{
							num2 *= -1f;
							num = -885202850;
							continue;
						}
						goto default;
					case 4:
						num2 = (P_2 ? axes[ouusLSVThShOJXeTBDNomJoAhtU].valueRaw : axes[ouusLSVThShOJXeTBDNomJoAhtU].value);
						num = -885202871;
						continue;
					case 12:
						return true;
					default:
						{
							P_4 = num2;
							return true;
						}
						IL_01a2:
						flag = (byte)num3 != 0;
						if (flag && P_0._axisRange == AxisRange.Positive)
						{
							num2 = ((num2 >= 0f) ? num2 : 0f);
							num = -885202853;
							continue;
						}
						goto case 18;
						IL_00ea:
						num2 = num5;
						num = -885202855;
						continue;
					}
					break;
				}
			}
		}

		internal override void UdqTiJdOOubbIffCkHAnQYFKEiz(ControllerMap P_0)
		{
			if (P_0 == null)
			{
				return;
			}
			IList<ActionElementMap> axisMaps = default(IList<ActionElementMap>);
			int num2 = default(int);
			int num3 = default(int);
			while (true)
			{
				ControllerMapWithAxes controllerMapWithAxes = P_0 as ControllerMapWithAxes;
				int num = -1459165735;
				while (true)
				{
					switch (num ^ -1459165742)
					{
					case 8:
						num = -1459165730;
						continue;
					case 5:
					{
						int num5;
						if (axisMaps[num2].elementIndex >= 0)
						{
							num = -1459165743;
							num5 = num;
						}
						else
						{
							num = -1459165738;
							num5 = num;
						}
						continue;
					}
					case 1:
						axisMaps = controllerMapWithAxes.AxisMaps;
						num3 = 0;
						num = -1459165733;
						continue;
					case 6:
						kHBFOpXfsCHmoMIFXGRFYWyjgTV(P_0, axisMaps[num3]);
						num3++;
						num = -1459165733;
						continue;
					case 0:
						num2 = axisMaps.Count - 1;
						num = -1459165739;
						continue;
					case 4:
						P_0.DeleteElementMap(axisMaps[num2].tqPurZpByiUWRrPJKwHxxaZZua);
						num = -1459165743;
						continue;
					case 3:
						num2--;
						num = -1459165739;
						continue;
					case 2:
						base.UdqTiJdOOubbIffCkHAnQYFKEiz(P_0);
						num = -1459165741;
						continue;
					case 9:
					{
						int num4;
						if (num3 >= axisMaps.Count)
						{
							num = -1459165742;
							num4 = num;
						}
						else
						{
							num = -1459165740;
							num4 = num;
						}
						continue;
					}
					case 10:
						return;
					case 11:
						if (controllerMapWithAxes == null)
						{
							Logger.LogWarning("Map type must inherit from ControllerMapWithAxes!");
							num = -1459165736;
							continue;
						}
						goto case 2;
					case 12:
						break;
					default:
						if (num2 < 0)
						{
							return;
						}
						goto case 5;
					}
					break;
				}
			}
		}

		internal override void kHBFOpXfsCHmoMIFXGRFYWyjgTV(ControllerMap P_0, ActionElementMap P_1)
		{
			if (P_1 == null)
			{
				while (true)
				{
					switch (0x1AAB7F63 ^ 0x1AAB7F61)
					{
					case 3:
						break;
					case 2:
						return;
					case 1:
						goto end_IL_0003;
					default:
						goto IL_0045;
					}
					continue;
					end_IL_0003:
					break;
				}
			}
			base.kHBFOpXfsCHmoMIFXGRFYWyjgTV(P_0, P_1);
			if (P_1._elementType != ControllerElementType.Axis)
			{
				return;
			}
			goto IL_0045;
			IL_0045:
			P_1.ENoWuIxoJpbiEHGViijOxvkWIbli(P_0);
		}

		internal void nBTvkuIMRIsljBSTPJWsUnWhXhu()
		{
			int num = 0;
			while (num < axisCount)
			{
				while (true)
				{
					int num2;
					switch (axes[num].fLnddiiYsQMexRarBgYYAedEaIXb._specialAxisType)
					{
					default:
						num2 = 616361781;
						goto IL_000c;
					case SpecialAxisType.None:
						goto IL_0068;
					case SpecialAxisType.Throttle:
						goto IL_009e;
						IL_000c:
						while (true)
						{
							switch (num2 ^ 0x24BCEF30)
							{
							case 0:
								num2 = 616361777;
								continue;
							case 1:
								break;
							case 7:
								goto IL_0068;
							case 3:
								num++;
								num2 = 616361784;
								continue;
							case 5:
								num2 = 616361780;
								continue;
							case 6:
								goto IL_009e;
							case 2:
								num2 = 616361779;
								continue;
							case 4:
								throw new NotImplementedException();
							default:
								goto end_IL_0054;
							}
							break;
						}
						continue;
						IL_009e:
						_calibrationMap.Axes[num].calibrationMode = EnumConverter.ToAlternateAxisCalibrationType(ReInput.configVars.throttleCalibrationMode);
						num2 = 616361778;
						goto IL_000c;
						IL_0068:
						_calibrationMap.Axes[num].calibrationMode = AlternateAxisCalibrationType.Default;
						num2 = 616361779;
						goto IL_000c;
						end_IL_0054:
						break;
					}
					break;
				}
			}
		}

		internal override void tAgADqjTsMUxSqYXeDyJIdETYRAp()
		{
			base.tAgADqjTsMUxSqYXeDyJIdETYRAp();
			int num = 0;
			while (num < _axisCount)
			{
				while (true)
				{
					int num2;
					int num3;
					if (axes[num] == null)
					{
						num2 = 1604038842;
						num3 = num2;
					}
					else
					{
						num2 = 1604038840;
						num3 = num2;
					}
					while (true)
					{
						switch (num2 ^ 0x5F9BB0BA)
						{
						case 3:
							num2 = 1604038843;
							continue;
						case 1:
							break;
						case 2:
							axes[num].Reset();
							num2 = 1604038842;
							continue;
						case 0:
							num++;
							num2 = 1604038846;
							continue;
						default:
							goto end_IL_0030;
						}
						break;
					}
					continue;
					end_IL_0030:
					break;
				}
			}
		}

		[CompilerGenerated]
		private IEnumerable<ControllerPollingInfo> vuwHhlUCjPAGHfAsurVjpmbsoJT()
		{
			return base.PollForAllElements();
		}

		[CompilerGenerated]
		private IEnumerable<ControllerPollingInfo> sOGYgDQmDKhdUtkPizZAePLMMCB()
		{
			return base.PollForAllElementsDown();
		}
	}
}
