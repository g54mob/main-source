using System;
using System.Collections.Generic;
using UnityEngine;

namespace Rewired.Utils
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal abstract class SafeDelegate : ICloneable
	{
		private static Action<Exception> EkzATjhNCoACzEkbhulqsTPmRgt;

		internal abstract int Count { get; }

		internal abstract Action<Exception> ExceptionHandler { get; set; }

		internal static Action<Exception> S_ExceptionHandler
		{
			get
			{
				return EkzATjhNCoACzEkbhulqsTPmRgt;
			}
			set
			{
				EkzATjhNCoACzEkbhulqsTPmRgt = value;
			}
		}

		internal abstract void RemoveDelegateOrAllDelegatesFromAnObject(object obj);

		internal abstract void Clear();

		public abstract object Clone();
	}
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal abstract class SafeDelegate<T> : SafeDelegate where T : class
	{
		private class sSPKqYRfWOlZBqsjDxejXsauGmD
		{
			public readonly T HzZFsJBNhBsTgfILUpiOFxjNBIZC;

			public readonly object vGQnsSUmFrTJHfYhJtHRHxFCImW;

			public readonly object bNBJcgsMQUEvkxbGaFMgZHxqKTL;

			public readonly bool kGDCjsKGzVOBDhkccJFGqTSZwSij;

			public sSPKqYRfWOlZBqsjDxejXsauGmD(T item)
			{
				HzZFsJBNhBsTgfILUpiOFxjNBIZC = item;
				vGQnsSUmFrTJHfYhJtHRHxFCImW = ((Delegate)(object)item).Target;
				try
				{
					bNBJcgsMQUEvkxbGaFMgZHxqKTL = ReflectionTools.GetMethodInfo((Delegate)(object)item);
				}
				catch
				{
					bNBJcgsMQUEvkxbGaFMgZHxqKTL = null;
				}
				kGDCjsKGzVOBDhkccJFGqTSZwSij = vGQnsSUmFrTJHfYhJtHRHxFCImW != null && vGQnsSUmFrTJHfYhJtHRHxFCImW is UnityEngine.Object;
			}

			public sSPKqYRfWOlZBqsjDxejXsauGmD(sSPKqYRfWOlZBqsjDxejXsauGmD source)
				: this(MiscTools.Clone((object)source.HzZFsJBNhBsTgfILUpiOFxjNBIZC) as T)
			{
			}

			public bool kLKODQEeDqDByfiILAyrtgwKTzO()
			{
				if (vGQnsSUmFrTJHfYhJtHRHxFCImW != null)
				{
					while (true)
					{
						int num = 1111283528;
						while (true)
						{
							switch (num ^ 0x423CD749)
							{
							case 2:
								break;
							case 1:
								if (vGQnsSUmFrTJHfYhJtHRHxFCImW is UnityEngine.Object)
								{
									goto IL_0033;
								}
								return false;
							default:
								return (UnityEngine.Object)vGQnsSUmFrTJHfYhJtHRHxFCImW == null;
							}
							break;
							IL_0033:
							num = 1111283529;
						}
					}
				}
				return true;
			}
		}

		private Action<Exception> vAXYanJvfudCukdMcbxeUiJHEEM;

		private readonly List<sSPKqYRfWOlZBqsjDxejXsauGmD> DmNvUHzWpUcFnEbIFBTLbniBTBe;

		private readonly List<sSPKqYRfWOlZBqsjDxejXsauGmD> UEEHovZRqdrZizdhnXRbFevSMtk;

		internal override int Count => DmNvUHzWpUcFnEbIFBTLbniBTBe.Count;

		internal override Action<Exception> ExceptionHandler
		{
			get
			{
				return vAXYanJvfudCukdMcbxeUiJHEEM;
			}
			set
			{
				vAXYanJvfudCukdMcbxeUiJHEEM = value;
			}
		}

		protected SafeDelegate()
		{
			if (!ReflectionTools.DoesTypeImplement(typeof(T), typeof(Delegate)))
			{
				throw new Exception(typeof(T).Name + " is not a delegate type! SafeDelegate only works with delegate types.");
			}
			DmNvUHzWpUcFnEbIFBTLbniBTBe = new List<sSPKqYRfWOlZBqsjDxejXsauGmD>();
			UEEHovZRqdrZizdhnXRbFevSMtk = new List<sSPKqYRfWOlZBqsjDxejXsauGmD>();
			if (vAXYanJvfudCukdMcbxeUiJHEEM == null)
			{
				vAXYanJvfudCukdMcbxeUiJHEEM = SafeDelegate.S_ExceptionHandler;
			}
		}

		protected SafeDelegate(Action<Exception> exceptionHandler)
			: this()
		{
			if (exceptionHandler == null)
			{
				throw new ArgumentNullException("exceptionHandler");
			}
			vAXYanJvfudCukdMcbxeUiJHEEM = exceptionHandler;
		}

		protected SafeDelegate(SafeDelegate<T> source)
			: this()
		{
			int num2 = default(int);
			while (true)
			{
				int num = -1111657451;
				while (true)
				{
					switch (num ^ -1111657452)
					{
					case 5:
						break;
					default:
						return;
					case 1:
						if (source == null)
						{
							throw new ArgumentNullException("source");
						}
						goto case 6;
					case 2:
					{
						int num3;
						if (num2 >= source.DmNvUHzWpUcFnEbIFBTLbniBTBe.Count)
						{
							num = -1111657456;
							num3 = num;
						}
						else
						{
							num = -1111657449;
							num3 = num;
						}
						continue;
					}
					case 6:
						if (source.vAXYanJvfudCukdMcbxeUiJHEEM != null)
						{
							vAXYanJvfudCukdMcbxeUiJHEEM = source.vAXYanJvfudCukdMcbxeUiJHEEM;
							num = -1111657452;
							continue;
						}
						goto case 0;
					case 0:
						num2 = 0;
						num = -1111657450;
						continue;
					case 3:
						DmNvUHzWpUcFnEbIFBTLbniBTBe.Add(new sSPKqYRfWOlZBqsjDxejXsauGmD(source.DmNvUHzWpUcFnEbIFBTLbniBTBe[num2]));
						num2++;
						num = -1111657450;
						continue;
					case 4:
						return;
					}
					break;
				}
			}
		}

		public void AddDelegate(T @delegate)
		{
			if (@delegate == null)
			{
				return;
			}
			int num2 = default(int);
			while (true)
			{
				List<Delegate> list = rBBEKEAvusvurYhixGfeXrutsHH((Delegate)(object)@delegate);
				int num = 1656256337;
				while (true)
				{
					switch (num ^ 0x62B87750)
					{
					case 7:
						num = 1656256341;
						continue;
					default:
						return;
					case 3:
						num2 = 0;
						num = 1656256342;
						continue;
					case 1:
						if (list != null)
						{
							int num4;
							if (list.Count == 0)
							{
								num = 1656256344;
								num4 = num;
							}
							else
							{
								num = 1656256339;
								num4 = num;
							}
							continue;
						}
						return;
					case 8:
						return;
					case 4:
					{
						T val = (T)(object)list[num2];
						if (!QUzJIwsyLBGiiDjdziRDeDUvrEq(val))
						{
							DmNvUHzWpUcFnEbIFBTLbniBTBe.Add(new sSPKqYRfWOlZBqsjDxejXsauGmD(val));
							num = 1656256336;
							continue;
						}
						goto case 0;
					}
					case 5:
						break;
					case 0:
						num2++;
						num = 1656256342;
						continue;
					case 6:
					{
						int num3;
						if (num2 >= list.Count)
						{
							num = 1656256338;
							num3 = num;
						}
						else
						{
							num = 1656256340;
							num3 = num;
						}
						continue;
					}
					case 2:
						return;
					}
					break;
				}
			}
		}

		public void RemoveDelegate(T @delegate)
		{
			if (@delegate == null)
			{
				return;
			}
			int num4 = default(int);
			int num3 = default(int);
			int count = default(int);
			while (true)
			{
				List<Delegate> list = rBBEKEAvusvurYhixGfeXrutsHH((Delegate)(object)@delegate);
				int num;
				int num2;
				if (list != null)
				{
					num = 1251070707;
					num2 = num;
				}
				else
				{
					num = 1251070708;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ 0x4A91D2F1)
					{
					case 8:
						num = 1251070710;
						continue;
					case 5:
						return;
					case 2:
					{
						int num6;
						if (list.Count != 0)
						{
							num = 1251070714;
							num6 = num;
						}
						else
						{
							num = 1251070708;
							num6 = num;
						}
						continue;
					}
					case 0:
						if (EqualityComparer<T>.Default.Equals(DmNvUHzWpUcFnEbIFBTLbniBTBe[num4].HzZFsJBNhBsTgfILUpiOFxjNBIZC, (T)(object)list[num3]))
						{
							DmNvUHzWpUcFnEbIFBTLbniBTBe.RemoveAt(num4);
							num = 1251070717;
							continue;
						}
						goto case 12;
					case 9:
						num4 = count - 1;
						num = 1251070709;
						continue;
					case 7:
						break;
					case 10:
					{
						int num5;
						if (num4 < 0)
						{
							num = 1251070704;
							num5 = num;
						}
						else
						{
							num = 1251070705;
							num5 = num;
						}
						continue;
					}
					case 1:
						num3++;
						num = 1251070706;
						continue;
					case 12:
						num4--;
						num = 1251070715;
						continue;
					case 4:
						num = 1251070715;
						continue;
					case 6:
						num3 = 0;
						num = 1251070706;
						continue;
					case 11:
						count = DmNvUHzWpUcFnEbIFBTLbniBTBe.Count;
						num = 1251070711;
						continue;
					default:
						if (num3 >= list.Count)
						{
							return;
						}
						goto case 9;
					}
					break;
				}
			}
		}

		internal override void RemoveDelegateOrAllDelegatesFromAnObject(object obj)
		{
			int count = DmNvUHzWpUcFnEbIFBTLbniBTBe.Count;
			int num = count - 1;
			Delegate obj2 = default(Delegate);
			while (true)
			{
				int num2 = 1329944088;
				while (true)
				{
					switch (num2 ^ 0x4F45561C)
					{
					case 5:
						break;
					case 0:
						DmNvUHzWpUcFnEbIFBTLbniBTBe[num] = new sSPKqYRfWOlZBqsjDxejXsauGmD((T)(object)obj2);
						num2 = 1329944093;
						continue;
					case 3:
						obj2 = vXRayMcqDHcxFljbtNJutZEvaGC(obj, (Delegate)(object)DmNvUHzWpUcFnEbIFBTLbniBTBe[num].HzZFsJBNhBsTgfILUpiOFxjNBIZC);
						if (xllbBwzsLqNfLOAfOXaIIhJsAet(obj2) == 0)
						{
							DmNvUHzWpUcFnEbIFBTLbniBTBe.RemoveAt(num);
							num2 = 1329944093;
							continue;
						}
						goto case 0;
					case 4:
						num2 = 1329944094;
						continue;
					case 1:
						num--;
						num2 = 1329944094;
						continue;
					default:
						if (num < 0)
						{
							return;
						}
						goto case 3;
					}
					break;
				}
			}
		}

		internal override void Clear()
		{
			DmNvUHzWpUcFnEbIFBTLbniBTBe.Clear();
		}

		protected void Invoke(Action<object, T> invokeCallback)
		{
			if (invokeCallback == null)
			{
				goto IL_0006;
			}
			goto IL_0124;
			IL_0006:
			int num = -283911759;
			goto IL_000b;
			IL_000b:
			List<int> list = default(List<int>);
			int num3 = default(int);
			int num2 = default(int);
			int count = default(int);
			int num5 = default(int);
			while (true)
			{
				int num4;
				switch (num ^ -283911749)
				{
				case 8:
					break;
				case 9:
					goto IL_004b;
				case 11:
					list.Add(num3);
					num = -283911750;
					continue;
				case 10:
					throw new ArgumentNullException("invokeCallback");
				case 5:
					UEEHovZRqdrZizdhnXRbFevSMtk.Clear();
					num2 = 0;
					num = -283911747;
					continue;
				case 6:
					if (num2 < count)
					{
						goto case 3;
					}
					list = null;
					num3 = 0;
					goto IL_0241;
				case 3:
					UEEHovZRqdrZizdhnXRbFevSMtk.Add(DmNvUHzWpUcFnEbIFBTLbniBTBe[num2]);
					num2++;
					num = -283911747;
					continue;
				case 2:
				{
					sSPKqYRfWOlZBqsjDxejXsauGmD sSPKqYRfWOlZBqsjDxejXsauGmD2 = UEEHovZRqdrZizdhnXRbFevSMtk[num3];
					if (sSPKqYRfWOlZBqsjDxejXsauGmD2.kGDCjsKGzVOBDhkccJFGqTSZwSij && sSPKqYRfWOlZBqsjDxejXsauGmD2.kLKODQEeDqDByfiILAyrtgwKTzO())
					{
						goto IL_00f2;
					}
					try
					{
						invokeCallback(this, sSPKqYRfWOlZBqsjDxejXsauGmD2.HzZFsJBNhBsTgfILUpiOFxjNBIZC);
					}
					catch (Exception ex)
					{
						if (vAXYanJvfudCukdMcbxeUiJHEEM == null)
						{
							goto IL_018a;
						}
						vAXYanJvfudCukdMcbxeUiJHEEM(ex);
						goto IL_01a7;
						IL_018a:
						int num6;
						if (ex.InnerException != null)
						{
							Logger.LogError(ex.InnerException, requiredThreadSafety: true);
							num6 = -283911751;
							goto IL_016d;
						}
						goto IL_01a7;
						IL_01a7:
						if (list == null)
						{
							list = TempListPool.Get<int>();
							num6 = -283911749;
							goto IL_016d;
						}
						goto IL_01b7;
						IL_01b7:
						list.Add(num3);
						goto end_IL_014f;
						IL_016d:
						while (true)
						{
							switch (num6 ^ -283911749)
							{
							case 3:
								num6 = -283911750;
								continue;
							case 1:
								break;
							case 2:
								goto IL_01a7;
							default:
								goto IL_01b7;
							}
							break;
						}
						goto IL_018a;
						end_IL_014f:;
					}
					goto default;
				}
				case 7:
					list = TempListPool.Get<int>();
					num = -283911760;
					continue;
				case 0:
					return;
				case 4:
					goto IL_0124;
				default:
					{
						num3++;
						goto IL_01c4;
					}
					IL_0219:
					if (count > 0)
					{
						UEEHovZRqdrZizdhnXRbFevSMtk.Clear();
						num4 = -283911747;
						goto IL_01c9;
					}
					return;
					IL_0241:
					if (num3 < count)
					{
						goto case 2;
					}
					if (list != null)
					{
						num5 = list.Count - 1;
						num4 = -283911745;
						goto IL_01c9;
					}
					goto IL_0219;
					IL_01c4:
					num4 = -283911751;
					goto IL_01c9;
					IL_01c9:
					while (true)
					{
						switch (num4 ^ -283911749)
						{
						case 5:
							break;
						default:
							return;
						case 3:
							num5--;
							num4 = -283911745;
							continue;
						case 1:
							DmNvUHzWpUcFnEbIFBTLbniBTBe.RemoveAt(list[num5]);
							num4 = -283911752;
							continue;
						case 0:
							goto IL_0219;
						case 4:
							if (num5 < 0)
							{
								TempListPool.Return(list);
								num4 = -283911749;
								continue;
							}
							goto case 1;
						case 2:
							goto IL_0241;
						case 6:
							return;
						}
						break;
					}
					goto IL_01c4;
				}
				break;
				IL_00f2:
				int num7;
				if (list == null)
				{
					num = -283911748;
					num7 = num;
				}
				else
				{
					num = -283911760;
					num7 = num;
				}
				continue;
				IL_004b:
				int num8;
				if (count == 0)
				{
					num = -283911749;
					num8 = num;
				}
				else
				{
					num = -283911746;
					num8 = num;
				}
			}
			goto IL_0006;
			IL_0124:
			count = DmNvUHzWpUcFnEbIFBTLbniBTBe.Count;
			num = -283911758;
			goto IL_000b;
		}

		protected T GetCombinedDelegate()
		{
			T result = default(T);
			if (DmNvUHzWpUcFnEbIFBTLbniBTBe == null)
			{
				result = null;
				goto IL_0010;
			}
			T val = null;
			int num = 0;
			int num2 = -1586176455;
			goto IL_0015;
			IL_0015:
			T hzZFsJBNhBsTgfILUpiOFxjNBIZC = default(T);
			while (true)
			{
				int num3;
				switch (num2 ^ -1586176454)
				{
				case 2:
					break;
				case 4:
					return result;
				case 0:
					goto IL_0049;
				default:
					if (val == null)
					{
						val = hzZFsJBNhBsTgfILUpiOFxjNBIZC;
					}
					else
					{
						try
						{
							val = (T)(object)Delegate.Combine((Delegate)(object)val, (Delegate)(object)hzZFsJBNhBsTgfILUpiOFxjNBIZC);
						}
						catch
						{
						}
					}
					num++;
					goto IL_00a1;
				case 3:
					goto IL_00bf;
					IL_00bf:
					if (num < DmNvUHzWpUcFnEbIFBTLbniBTBe.Count)
					{
						goto IL_0049;
					}
					num3 = -1586176454;
					goto IL_00a6;
					IL_00a6:
					switch (num3 ^ -1586176454)
					{
					case 2:
						break;
					case 1:
						goto IL_00bf;
					default:
						return val;
					}
					goto IL_00a1;
					IL_00a1:
					num3 = -1586176453;
					goto IL_00a6;
				}
				break;
				IL_0049:
				hzZFsJBNhBsTgfILUpiOFxjNBIZC = DmNvUHzWpUcFnEbIFBTLbniBTBe[num].HzZFsJBNhBsTgfILUpiOFxjNBIZC;
				num2 = -1586176453;
			}
			goto IL_0010;
			IL_0010:
			num2 = -1586176450;
			goto IL_0015;
		}

		private bool QUzJIwsyLBGiiDjdziRDeDUvrEq(T P_0)
		{
			return KhufsiHazfkStoHkXbcGhTzBsNFW(P_0) >= 0;
		}

		private int KhufsiHazfkStoHkXbcGhTzBsNFW(T P_0)
		{
			int count = DmNvUHzWpUcFnEbIFBTLbniBTBe.Count;
			int num2 = default(int);
			while (true)
			{
				int num = 1938529849;
				while (true)
				{
					switch (num ^ 0x738B9E3D)
					{
					case 2:
						break;
					case 4:
						num2 = 0;
						num = 1938529854;
						continue;
					case 1:
						return num2;
					case 0:
						if (!EqualityComparer<T>.Default.Equals(DmNvUHzWpUcFnEbIFBTLbniBTBe[num2].HzZFsJBNhBsTgfILUpiOFxjNBIZC, P_0))
						{
							num2++;
							num = 1938529848;
						}
						else
						{
							num = 1938529852;
						}
						continue;
					case 3:
						num = 1938529848;
						continue;
					default:
						if (num2 >= count)
						{
							return -1;
						}
						goto case 0;
					}
					break;
				}
			}
		}

		private static Delegate vXRayMcqDHcxFljbtNJutZEvaGC(object P_0, Delegate P_1)
		{
			if ((object)P_1 != null)
			{
				while (true)
				{
					int num = -1612379724;
					while (true)
					{
						switch (num ^ -1612379723)
						{
						case 0:
							break;
						case 1:
							goto IL_0021;
						default:
							goto end_IL_0003;
						}
						break;
						IL_0021:
						if (P_0 == null)
						{
							num = -1612379721;
							continue;
						}
						goto IL_002d;
					}
					continue;
					IL_002d:
					if (P_0 is Delegate)
					{
						return vXRayMcqDHcxFljbtNJutZEvaGC((Delegate)P_0, P_1);
					}
					try
					{
						Delegate[] invocationList = P_1.GetInvocationList();
						int num2 = 0;
						while (true)
						{
							IL_004b:
							int num3 = -1612379726;
							while (true)
							{
								switch (num3 ^ -1612379723)
								{
								case 4:
									break;
								default:
									goto end_IL_0050;
								case 7:
									num3 = -1612379722;
									continue;
								case 3:
								{
									int num5;
									if (num2 >= invocationList.Length)
									{
										num3 = -1612379721;
										num5 = num3;
									}
									else
									{
										num3 = -1612379725;
										num5 = num3;
									}
									continue;
								}
								case 0:
									num2++;
									num3 = -1612379722;
									continue;
								case 6:
									if (!object.ReferenceEquals(invocationList[num2].Target, P_0))
									{
										int num4;
										if (object.ReferenceEquals(ReflectionTools.GetMethodInfo(invocationList[num2]), P_0))
										{
											num3 = -1612379724;
											num4 = num3;
										}
										else
										{
											num3 = -1612379723;
											num4 = num3;
										}
										continue;
									}
									goto case 1;
								case 1:
									if ((object)P_1 == null)
									{
										return P_1;
									}
									goto case 5;
								case 5:
									P_1 = Delegate.RemoveAll(P_1, invocationList[num2]);
									num3 = -1612379723;
									continue;
								case 2:
									goto end_IL_0050;
								}
								goto IL_004b;
								continue;
								end_IL_0050:
								break;
							}
							break;
						}
					}
					catch (Exception ex)
					{
						Logger.LogError("Exception caught while removing delegates from list (1):\n" + ex);
					}
					return P_1;
					continue;
					end_IL_0003:
					break;
				}
			}
			return P_1;
		}

		private static Delegate vXRayMcqDHcxFljbtNJutZEvaGC(Delegate P_0, Delegate P_1)
		{
			if ((object)P_0 != null)
			{
				Delegate obj2 = default(Delegate);
				Delegate[] invocationList2 = default(Delegate[]);
				int num4 = default(int);
				object methodInfo = default(object);
				Delegate result = default(Delegate);
				int num3 = default(int);
				while (true)
				{
					int num = -643961334;
					while (true)
					{
						switch (num ^ -643961333)
						{
						case 2:
							break;
						case 1:
							goto IL_0021;
						default:
							goto end_IL_0003;
						}
						break;
						IL_0021:
						if ((object)P_1 == null)
						{
							num = -643961333;
							continue;
						}
						goto IL_002d;
					}
					continue;
					IL_002d:
					if (!object.ReferenceEquals(P_0.GetType(), P_0.GetType()))
					{
						return P_1;
					}
					try
					{
						Delegate[] invocationList = P_0.GetInvocationList();
						while (true)
						{
							IL_0049:
							int num2 = -643961329;
							while (true)
							{
								switch (num2 ^ -643961333)
								{
								case 2:
									break;
								case 7:
									obj2 = invocationList2[num4];
									num2 = -643961331;
									continue;
								case 6:
								{
									object methodInfo2 = ReflectionTools.GetMethodInfo(obj2);
									if (!object.ReferenceEquals(methodInfo, methodInfo2))
									{
										goto case 0;
									}
									if ((object)P_1 == null)
									{
										result = P_1;
										num2 = -643961343;
										continue;
									}
									goto case 9;
								}
								case 1:
									if (num4 >= invocationList2.Length)
									{
										num3++;
										num2 = -643961330;
										continue;
									}
									goto case 7;
								case 11:
									num2 = -643961334;
									continue;
								case 3:
									num3 = 0;
									num2 = -643961330;
									continue;
								case 4:
									invocationList2 = P_1.GetInvocationList();
									num2 = -643961336;
									continue;
								case 8:
								{
									Delegate obj = invocationList[num3];
									methodInfo = ReflectionTools.GetMethodInfo(obj);
									num4 = 0;
									num2 = -643961344;
									continue;
								}
								case 0:
									num4++;
									num2 = -643961334;
									continue;
								case 9:
									P_1 = Delegate.RemoveAll(P_1, obj2);
									num2 = -643961333;
									continue;
								default:
									if (num3 >= invocationList.Length)
									{
										goto end_IL_004e;
									}
									goto case 8;
								case 10:
									return result;
								}
								goto IL_0049;
								continue;
								end_IL_004e:
								break;
							}
							break;
						}
					}
					catch (Exception ex)
					{
						while (true)
						{
							IL_014b:
							int num5 = -643961335;
							while (true)
							{
								switch (num5 ^ -643961333)
								{
								case 0:
									break;
								default:
									goto end_IL_0150;
								case 2:
									goto IL_0169;
								case 1:
									goto end_IL_0150;
								}
								goto IL_014b;
								IL_0169:
								Logger.LogError("Exception caught while removing delegates from list (2):\n" + ex);
								num5 = -643961334;
								continue;
								end_IL_0150:
								break;
							}
							break;
						}
					}
					return P_1;
					continue;
					end_IL_0003:
					break;
				}
			}
			return P_1;
		}

		private static int xllbBwzsLqNfLOAfOXaIIhJsAet(Delegate P_0)
		{
			if ((object)P_0 == null)
			{
				return 0;
			}
			Delegate[] invocationList = P_0.GetInvocationList();
			if (invocationList == null)
			{
				return 0;
			}
			return invocationList.Length;
		}

		private static List<Delegate> rBBEKEAvusvurYhixGfeXrutsHH(Delegate P_0)
		{
			if ((object)P_0 == null)
			{
				return null;
			}
			Delegate obj = P_0;
			Delegate[] invocationList = default(Delegate[]);
			List<Delegate> list = default(List<Delegate>);
			int num2 = default(int);
			while (true)
			{
				int num = -1321498537;
				while (true)
				{
					switch (num ^ -1321498540)
					{
					case 0:
						break;
					case 3:
						invocationList = obj.GetInvocationList();
						if (invocationList == null)
						{
							num = -1321498539;
							continue;
						}
						list = new List<Delegate>(invocationList.Length);
						num2 = 0;
						num = -1321498544;
						continue;
					case 2:
						list.Add(invocationList[num2]);
						num2++;
						num = -1321498544;
						continue;
					case 1:
						return null;
					default:
						if (num2 >= invocationList.Length)
						{
							return list;
						}
						goto case 2;
					}
					break;
				}
			}
		}
	}
}
