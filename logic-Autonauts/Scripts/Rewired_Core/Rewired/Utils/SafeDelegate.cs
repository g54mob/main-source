using System;
using System.Collections.Generic;
using UnityEngine;

namespace Rewired.Utils
{
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal abstract class SafeDelegate : ICloneable
	{
		private static Action<Exception> zIxOuwVhlmAZirdOgjAtmjtrztU;

		internal abstract int Count { get; }

		internal abstract Action<Exception> ExceptionHandler { get; set; }

		internal static Action<Exception> S_ExceptionHandler
		{
			get
			{
				return zIxOuwVhlmAZirdOgjAtmjtrztU;
			}
			set
			{
				zIxOuwVhlmAZirdOgjAtmjtrztU = value;
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
		private class LAYWphfUAAJsKNkXYKpvBEIjJNJ
		{
			public readonly T msVVRWbCGXIWrzOwJDAXLVPEHPw;

			public readonly object GCQHnJkXanMbWWcIAkqAJMfPbnz;

			public readonly object GURVunUjfSZBmAoUnowBBRjxNVc;

			public readonly bool XzFGshkEzZAPAXPDIcMPRgbhFDB;

			public LAYWphfUAAJsKNkXYKpvBEIjJNJ(T item)
			{
				while (true)
				{
					int num = 1727318482;
					while (true)
					{
						switch (num ^ 0x66F4C9D3)
						{
						case 0:
							break;
						case 1:
							goto IL_0024;
						default:
							GCQHnJkXanMbWWcIAkqAJMfPbnz = ((Delegate)(object)item).Target;
							try
							{
								GURVunUjfSZBmAoUnowBBRjxNVc = ReflectionTools.GetMethodInfo((Delegate)(object)item);
							}
							catch
							{
								GURVunUjfSZBmAoUnowBBRjxNVc = null;
							}
							XzFGshkEzZAPAXPDIcMPRgbhFDB = GCQHnJkXanMbWWcIAkqAJMfPbnz != null && GCQHnJkXanMbWWcIAkqAJMfPbnz is UnityEngine.Object;
							return;
						}
						break;
						IL_0024:
						msVVRWbCGXIWrzOwJDAXLVPEHPw = item;
						num = 1727318481;
					}
				}
			}

			public LAYWphfUAAJsKNkXYKpvBEIjJNJ(LAYWphfUAAJsKNkXYKpvBEIjJNJ source)
				: this(MiscTools.Clone((object)source.msVVRWbCGXIWrzOwJDAXLVPEHPw) as T)
			{
			}

			public bool HoMznNkpBsGItAtfYMlenlSVqCx()
			{
				if (GCQHnJkXanMbWWcIAkqAJMfPbnz != null)
				{
					if (GCQHnJkXanMbWWcIAkqAJMfPbnz is UnityEngine.Object)
					{
						return (UnityEngine.Object)GCQHnJkXanMbWWcIAkqAJMfPbnz == null;
					}
					return false;
				}
				return true;
			}
		}

		private Action<Exception> OCBHhakbYybulyFtlKMdIGxbAXtm;

		private readonly List<LAYWphfUAAJsKNkXYKpvBEIjJNJ> atNbASaHjQpdqmjbEUqCVlAElYDi;

		private readonly List<LAYWphfUAAJsKNkXYKpvBEIjJNJ> xACTtgxtNtMjhWNIgwHyDIVBBMD;

		internal override int Count
		{
			get
			{
				return atNbASaHjQpdqmjbEUqCVlAElYDi.Count;
			}
		}

		internal override Action<Exception> ExceptionHandler
		{
			get
			{
				return OCBHhakbYybulyFtlKMdIGxbAXtm;
			}
			set
			{
				OCBHhakbYybulyFtlKMdIGxbAXtm = value;
			}
		}

		protected SafeDelegate()
		{
			if (!ReflectionTools.DoesTypeImplement(typeof(T), typeof(Delegate)))
			{
				throw new Exception(typeof(T).Name + " is not a delegate type! SafeDelegate only works with delegate types.");
			}
			atNbASaHjQpdqmjbEUqCVlAElYDi = new List<LAYWphfUAAJsKNkXYKpvBEIjJNJ>();
			xACTtgxtNtMjhWNIgwHyDIVBBMD = new List<LAYWphfUAAJsKNkXYKpvBEIjJNJ>();
			if (OCBHhakbYybulyFtlKMdIGxbAXtm == null)
			{
				OCBHhakbYybulyFtlKMdIGxbAXtm = SafeDelegate.S_ExceptionHandler;
			}
		}

		protected SafeDelegate(Action<Exception> exceptionHandler)
			: this()
		{
			if (exceptionHandler == null)
			{
				throw new ArgumentNullException("exceptionHandler");
			}
			OCBHhakbYybulyFtlKMdIGxbAXtm = exceptionHandler;
		}

		protected SafeDelegate(SafeDelegate<T> source)
			: this()
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (source.OCBHhakbYybulyFtlKMdIGxbAXtm != null)
			{
				OCBHhakbYybulyFtlKMdIGxbAXtm = source.OCBHhakbYybulyFtlKMdIGxbAXtm;
			}
			for (int i = 0; i < source.atNbASaHjQpdqmjbEUqCVlAElYDi.Count; i++)
			{
				atNbASaHjQpdqmjbEUqCVlAElYDi.Add(new LAYWphfUAAJsKNkXYKpvBEIjJNJ(source.atNbASaHjQpdqmjbEUqCVlAElYDi[i]));
			}
		}

		public void AddDelegate(T @delegate)
		{
			if (@delegate == null)
			{
				return;
			}
			int num3 = default(int);
			while (true)
			{
				List<Delegate> list = YuXfqXuDwwdglrVeuMDjNGtgEmq((Delegate)(object)@delegate);
				int num;
				int num2;
				if (list == null)
				{
					num = 654043192;
					num2 = num;
				}
				else
				{
					num = 654043195;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ 0x26FBE83A)
					{
					case 7:
						num = 654043193;
						continue;
					case 5:
						num3++;
						num = 654043198;
						continue;
					case 6:
					{
						T val = (T)(object)list[num3];
						if (!hVhfCpEYePxtliVMkmzCRpiiDkB(val))
						{
							atNbASaHjQpdqmjbEUqCVlAElYDi.Add(new LAYWphfUAAJsKNkXYKpvBEIjJNJ(val));
							num = 654043199;
							continue;
						}
						goto case 5;
					}
					case 2:
						return;
					case 3:
						break;
					case 1:
					{
						int num4;
						if (list.Count == 0)
						{
							num = 654043192;
							num4 = num;
						}
						else
						{
							num = 654043194;
							num4 = num;
						}
						continue;
					}
					case 0:
						num3 = 0;
						num = 654043198;
						continue;
					default:
						if (num3 >= list.Count)
						{
							return;
						}
						goto case 6;
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
			int num5 = default(int);
			int count = default(int);
			int num3 = default(int);
			while (true)
			{
				List<Delegate> list = YuXfqXuDwwdglrVeuMDjNGtgEmq((Delegate)(object)@delegate);
				if (list == null)
				{
					break;
				}
				int num;
				int num2;
				if (list.Count != 0)
				{
					num = -1037849650;
					num2 = num;
				}
				else
				{
					num = -1037849652;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -1037849654)
					{
					case 2:
						num = -1037849651;
						continue;
					default:
						return;
					case 0:
						num5--;
						num = -1037849662;
						continue;
					case 3:
						num5 = count - 1;
						num = -1037849662;
						continue;
					case 4:
						count = atNbASaHjQpdqmjbEUqCVlAElYDi.Count;
						num3 = 0;
						num = -1037849649;
						continue;
					case 8:
						if (num5 < 0)
						{
							num3++;
							num = -1037849649;
							continue;
						}
						goto case 1;
					case 5:
					{
						int num4;
						if (num3 < list.Count)
						{
							num = -1037849655;
							num4 = num;
						}
						else
						{
							num = -1037849661;
							num4 = num;
						}
						continue;
					}
					case 7:
						break;
					case 6:
						return;
					case 1:
						if (EqualityComparer<T>.Default.Equals(atNbASaHjQpdqmjbEUqCVlAElYDi[num5].msVVRWbCGXIWrzOwJDAXLVPEHPw, (T)(object)list[num3]))
						{
							atNbASaHjQpdqmjbEUqCVlAElYDi.RemoveAt(num5);
							num = -1037849654;
							continue;
						}
						goto case 0;
					case 9:
						return;
					}
					break;
				}
			}
		}

		internal override void RemoveDelegateOrAllDelegatesFromAnObject(object obj)
		{
			int count = atNbASaHjQpdqmjbEUqCVlAElYDi.Count;
			int num = count - 1;
			Delegate obj2 = default(Delegate);
			while (true)
			{
				int num2;
				int num3;
				if (num < 0)
				{
					num2 = -471940642;
					num3 = num2;
				}
				else
				{
					num2 = -471940646;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ -471940648)
					{
					case 5:
						num2 = -471940646;
						continue;
					default:
						return;
					case 2:
						obj2 = QVZTDdKPFNjQwKXAewAChghJHlb(obj, (Delegate)(object)atNbASaHjQpdqmjbEUqCVlAElYDi[num].msVVRWbCGXIWrzOwJDAXLVPEHPw);
						if (KSpcKrGZRujUKAnGFGaJmUblexSg(obj2) == 0)
						{
							atNbASaHjQpdqmjbEUqCVlAElYDi.RemoveAt(num);
							num2 = -471940647;
							continue;
						}
						goto case 0;
					case 0:
						atNbASaHjQpdqmjbEUqCVlAElYDi[num] = new LAYWphfUAAJsKNkXYKpvBEIjJNJ((T)(object)obj2);
						num2 = -471940645;
						continue;
					case 4:
						break;
					case 1:
						num2 = -471940645;
						continue;
					case 3:
						num--;
						num2 = -471940644;
						continue;
					case 6:
						return;
					}
					break;
				}
			}
		}

		internal override void Clear()
		{
			atNbASaHjQpdqmjbEUqCVlAElYDi.Clear();
		}

		protected void Invoke(Action<object, T> invokeCallback)
		{
			if (invokeCallback == null)
			{
				goto IL_0006;
			}
			goto IL_00e4;
			IL_0006:
			int num = 2142187496;
			goto IL_000b;
			IL_000b:
			int num3 = default(int);
			LAYWphfUAAJsKNkXYKpvBEIjJNJ lAYWphfUAAJsKNkXYKpvBEIjJNJ = default(LAYWphfUAAJsKNkXYKpvBEIjJNJ);
			List<int> list = default(List<int>);
			int num2 = default(int);
			int count = default(int);
			int num7 = default(int);
			while (true)
			{
				int num6;
				switch (num ^ 0x7FAF2FEB)
				{
				case 10:
					break;
				case 1:
					num3 = 0;
					num = 2142187499;
					continue;
				case 11:
					if (lAYWphfUAAJsKNkXYKpvBEIjJNJ.XzFGshkEzZAPAXPDIcMPRgbhFDB && lAYWphfUAAJsKNkXYKpvBEIjJNJ.HoMznNkpBsGItAtfYMlenlSVqCx())
					{
						if (list == null)
						{
							list = TempListPool.Get<int>();
							num = 2142187503;
							continue;
						}
						goto default;
					}
					try
					{
						invokeCallback(this, lAYWphfUAAJsKNkXYKpvBEIjJNJ.msVVRWbCGXIWrzOwJDAXLVPEHPw);
					}
					catch (Exception obj)
					{
						if (OCBHhakbYybulyFtlKMdIGxbAXtm != null)
						{
							OCBHhakbYybulyFtlKMdIGxbAXtm(obj);
							goto IL_0168;
						}
						goto IL_018a;
						IL_018a:
						int num4;
						int num5;
						if (list != null)
						{
							num4 = 2142187499;
							num5 = num4;
						}
						else
						{
							num4 = 2142187498;
							num5 = num4;
						}
						goto IL_016d;
						IL_0168:
						num4 = 2142187497;
						goto IL_016d;
						IL_016d:
						while (true)
						{
							switch (num4 ^ 0x7FAF2FEB)
							{
							case 3:
								break;
							case 2:
								goto IL_018a;
							case 1:
								list = TempListPool.Get<int>();
								num4 = 2142187499;
								continue;
							default:
								list.Add(num2);
								goto end_IL_0151;
							}
							break;
						}
						goto IL_0168;
						end_IL_0151:;
					}
					goto IL_01b4;
				case 7:
					xACTtgxtNtMjhWNIgwHyDIVBBMD.Clear();
					num = 2142187498;
					continue;
				case 8:
					xACTtgxtNtMjhWNIgwHyDIVBBMD.Add(atNbASaHjQpdqmjbEUqCVlAElYDi[num3]);
					num3++;
					num = 2142187499;
					continue;
				case 6:
					list = null;
					num2 = 0;
					goto IL_026e;
				case 0:
					goto IL_00cc;
				case 5:
					goto IL_00e4;
				case 3:
					throw new ArgumentNullException("invokeCallback");
				case 9:
					lAYWphfUAAJsKNkXYKpvBEIjJNJ = xACTtgxtNtMjhWNIgwHyDIVBBMD[num2];
					num = 2142187488;
					continue;
				case 2:
					if (count == 0)
					{
						return;
					}
					goto case 7;
				default:
					{
						list.Add(num2);
						goto IL_01b4;
					}
					IL_026e:
					if (num2 < count)
					{
						goto case 9;
					}
					num6 = 2142187491;
					goto IL_01bd;
					IL_01bd:
					while (true)
					{
						switch (num6 ^ 0x7FAF2FEB)
						{
						case 5:
							break;
						default:
							return;
						case 0:
							num7--;
							num6 = 2142187490;
							continue;
						case 8:
							if (list != null)
							{
								num7 = list.Count - 1;
								num6 = 2142187490;
								continue;
							}
							goto IL_0256;
						case 7:
							TempListPool.Return(list);
							num6 = 2142187496;
							continue;
						case 2:
							atNbASaHjQpdqmjbEUqCVlAElYDi.RemoveAt(list[num7]);
							num6 = 2142187499;
							continue;
						case 9:
							goto IL_023d;
						case 3:
							goto IL_0256;
						case 6:
							goto IL_026e;
						case 1:
							xACTtgxtNtMjhWNIgwHyDIVBBMD.Clear();
							num6 = 2142187503;
							continue;
						case 4:
							return;
						}
						break;
						IL_023d:
						int num8;
						if (num7 < 0)
						{
							num6 = 2142187500;
							num8 = num6;
						}
						else
						{
							num6 = 2142187497;
							num8 = num6;
						}
						continue;
						IL_0256:
						int num9;
						if (count > 0)
						{
							num6 = 2142187498;
							num9 = num6;
						}
						else
						{
							num6 = 2142187503;
							num9 = num6;
						}
					}
					goto IL_01b8;
					IL_01b4:
					num2++;
					goto IL_01b8;
					IL_01b8:
					num6 = 2142187501;
					goto IL_01bd;
				}
				break;
				IL_00cc:
				int num10;
				if (num3 >= count)
				{
					num = 2142187501;
					num10 = num;
				}
				else
				{
					num = 2142187491;
					num10 = num;
				}
			}
			goto IL_0006;
			IL_00e4:
			count = atNbASaHjQpdqmjbEUqCVlAElYDi.Count;
			num = 2142187497;
			goto IL_000b;
		}

		protected T GetCombinedDelegate()
		{
			if (atNbASaHjQpdqmjbEUqCVlAElYDi == null)
			{
				return null;
			}
			T val = null;
			for (int i = 0; i < atNbASaHjQpdqmjbEUqCVlAElYDi.Count; i++)
			{
				while (true)
				{
					T msVVRWbCGXIWrzOwJDAXLVPEHPw = atNbASaHjQpdqmjbEUqCVlAElYDi[i].msVVRWbCGXIWrzOwJDAXLVPEHPw;
					if (val == null)
					{
						int num = -2082571372;
						while (true)
						{
							switch (num ^ -2082571372)
							{
							case 2:
								num = -2082571371;
								continue;
							case 1:
								break;
							default:
								goto IL_005d;
							}
							break;
						}
						continue;
					}
					try
					{
						val = (T)(object)Delegate.Combine((Delegate)(object)val, (Delegate)(object)msVVRWbCGXIWrzOwJDAXLVPEHPw);
					}
					catch
					{
					}
					break;
					IL_005d:
					val = msVVRWbCGXIWrzOwJDAXLVPEHPw;
					break;
				}
			}
			return val;
		}

		private bool hVhfCpEYePxtliVMkmzCRpiiDkB(T P_0)
		{
			return tZuNWtSCplPhyqDRGNVBVrTnWqi(P_0) >= 0;
		}

		private int tZuNWtSCplPhyqDRGNVBVrTnWqi(T P_0)
		{
			int count = atNbASaHjQpdqmjbEUqCVlAElYDi.Count;
			int num2 = default(int);
			while (true)
			{
				int num = -130534524;
				while (true)
				{
					switch (num ^ -130534523)
					{
					case 2:
						break;
					case 1:
						num2 = 0;
						num = -130534523;
						continue;
					case 3:
						if (EqualityComparer<T>.Default.Equals(atNbASaHjQpdqmjbEUqCVlAElYDi[num2].msVVRWbCGXIWrzOwJDAXLVPEHPw, P_0))
						{
							return num2;
						}
						num2++;
						num = -130534523;
						continue;
					default:
						if (num2 >= count)
						{
							return -1;
						}
						goto case 3;
					}
					break;
				}
			}
		}

		private static Delegate QVZTDdKPFNjQwKXAewAChghJHlb(object P_0, Delegate P_1)
		{
			if ((object)P_1 != null)
			{
				int num3 = default(int);
				while (true)
				{
					int num = 661995532;
					while (true)
					{
						switch (num ^ 0x2775400D)
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
						if (P_0 == null)
						{
							num = 661995533;
							continue;
						}
						goto IL_002d;
					}
					continue;
					IL_002d:
					if (P_0 is Delegate)
					{
						return QVZTDdKPFNjQwKXAewAChghJHlb((Delegate)P_0, P_1);
					}
					try
					{
						Delegate[] invocationList = P_1.GetInvocationList();
						while (true)
						{
							IL_0049:
							int num2 = 661995529;
							while (true)
							{
								switch (num2 ^ 0x2775400D)
								{
								case 0:
									break;
								case 4:
									num3 = 0;
									num2 = 661995534;
									continue;
								case 1:
									return P_1;
								case 6:
									num3++;
									num2 = 661995534;
									continue;
								case 5:
									P_1 = Delegate.RemoveAll(P_1, invocationList[num3]);
									num2 = 661995531;
									continue;
								case 2:
									if (!object.ReferenceEquals(invocationList[num3].Target, P_0))
									{
										int num4;
										if (!object.ReferenceEquals(ReflectionTools.GetMethodInfo(invocationList[num3]), P_0))
										{
											num2 = 661995531;
											num4 = num2;
										}
										else
										{
											num2 = 661995530;
											num4 = num2;
										}
										continue;
									}
									goto case 7;
								case 7:
								{
									int num5;
									if ((object)P_1 != null)
									{
										num2 = 661995528;
										num5 = num2;
									}
									else
									{
										num2 = 661995532;
										num5 = num2;
									}
									continue;
								}
								default:
									if (num3 >= invocationList.Length)
									{
										goto end_IL_004e;
									}
									goto case 2;
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

		private static Delegate QVZTDdKPFNjQwKXAewAChghJHlb(Delegate P_0, Delegate P_1)
		{
			if ((object)P_0 == null || (object)P_1 == null)
			{
				return P_1;
			}
			if (!object.ReferenceEquals(P_0.GetType(), P_0.GetType()))
			{
				return P_1;
			}
			try
			{
				Delegate[] invocationList = P_0.GetInvocationList();
				Delegate[] invocationList2 = P_1.GetInvocationList();
				int num2 = default(int);
				Delegate obj = default(Delegate);
				int num3 = default(int);
				object methodInfo2 = default(object);
				while (true)
				{
					IL_002b:
					int num = -2093099930;
					while (true)
					{
						switch (num ^ -2093099922)
						{
						case 7:
							break;
						case 8:
							num2 = 0;
							num = -2093099929;
							continue;
						case 2:
						{
							obj = invocationList2[num3];
							object methodInfo = ReflectionTools.GetMethodInfo(obj);
							int num4;
							if (object.ReferenceEquals(methodInfo2, methodInfo))
							{
								num = -2093099922;
								num4 = num;
							}
							else
							{
								num = -2093099925;
								num4 = num;
							}
							continue;
						}
						case 5:
							num3++;
							num = -2093099926;
							continue;
						case 6:
						{
							Delegate obj2 = invocationList[num2];
							methodInfo2 = ReflectionTools.GetMethodInfo(obj2);
							num3 = 0;
							num = -2093099926;
							continue;
						}
						case 9:
							num = -2093099921;
							continue;
						case 0:
							if ((object)P_1 == null)
							{
								return P_1;
							}
							goto case 3;
						case 4:
							if (num3 >= invocationList2.Length)
							{
								num2++;
								num = -2093099921;
								continue;
							}
							goto case 2;
						case 3:
							P_1 = Delegate.RemoveAll(P_1, obj);
							num = -2093099925;
							continue;
						default:
							if (num2 >= invocationList.Length)
							{
								goto end_IL_0030;
							}
							goto case 6;
						}
						goto IL_002b;
						continue;
						end_IL_0030:
						break;
					}
					break;
				}
			}
			catch (Exception ex)
			{
				Logger.LogError("Exception caught while removing delegates from list (2):\n" + ex);
			}
			return P_1;
		}

		private static int KSpcKrGZRujUKAnGFGaJmUblexSg(Delegate P_0)
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

		private static List<Delegate> YuXfqXuDwwdglrVeuMDjNGtgEmq(Delegate P_0)
		{
			if ((object)P_0 == null)
			{
				return null;
			}
			Delegate obj = P_0;
			Delegate[] invocationList = obj.GetInvocationList();
			List<Delegate> list = default(List<Delegate>);
			int num2 = default(int);
			while (true)
			{
				int num = 617636139;
				while (true)
				{
					switch (num ^ 0x24D06129)
					{
					case 0:
						break;
					case 2:
						if (invocationList == null)
						{
							return null;
						}
						list = new List<Delegate>(invocationList.Length);
						num = 617636141;
						continue;
					case 4:
						num2 = 0;
						num = 617636138;
						continue;
					case 1:
						list.Add(invocationList[num2]);
						num2++;
						num = 617636138;
						continue;
					default:
						if (num2 >= invocationList.Length)
						{
							return list;
						}
						goto case 1;
					}
					break;
				}
			}
		}
	}
}
