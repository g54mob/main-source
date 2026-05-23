using System;
using System.Collections.Generic;
using UnityEngine;

namespace Rewired.Utils
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal abstract class SafeDelegate : ICloneable
	{
		private static Action<Exception> GVtfpblPxyirPHgZUfEtBovvWuZ;

		internal abstract int Count { get; }

		internal abstract Action<Exception> ExceptionHandler { get; set; }

		internal static Action<Exception> S_ExceptionHandler
		{
			get
			{
				return GVtfpblPxyirPHgZUfEtBovvWuZ;
			}
			set
			{
				GVtfpblPxyirPHgZUfEtBovvWuZ = value;
			}
		}

		internal abstract void RemoveDelegateOrAllDelegatesFromAnObject(object obj);

		internal abstract void Clear();

		public abstract object Clone();
	}
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	internal abstract class SafeDelegate<T> : SafeDelegate where T : class
	{
		private class qOEcssJXIAIFhlxIqAUhcaUfsYAe
		{
			public readonly T RERAhLRQKJhiOXbllLXxmBeUAhn;

			public readonly object nCWCOIOOofbnfixPcuUIeRfVqGi;

			public readonly object zRLFnyiijIzkBPmRPkoZQclvYCf;

			public readonly bool sNJocUkUBfBblcYcCaPoXifrWK;

			public qOEcssJXIAIFhlxIqAUhcaUfsYAe(T item)
			{
				RERAhLRQKJhiOXbllLXxmBeUAhn = item;
				nCWCOIOOofbnfixPcuUIeRfVqGi = ((Delegate)(object)item).Target;
				try
				{
					zRLFnyiijIzkBPmRPkoZQclvYCf = ReflectionTools.GetMethodInfo((Delegate)(object)item);
				}
				catch
				{
					zRLFnyiijIzkBPmRPkoZQclvYCf = null;
				}
				sNJocUkUBfBblcYcCaPoXifrWK = nCWCOIOOofbnfixPcuUIeRfVqGi != null && nCWCOIOOofbnfixPcuUIeRfVqGi is UnityEngine.Object;
			}

			public qOEcssJXIAIFhlxIqAUhcaUfsYAe(qOEcssJXIAIFhlxIqAUhcaUfsYAe source)
				: this(MiscTools.Clone((object)source.RERAhLRQKJhiOXbllLXxmBeUAhn) as T)
			{
			}

			public bool icEGeQAMBmnjWCoiemfkcEWTDJwh()
			{
				if (nCWCOIOOofbnfixPcuUIeRfVqGi != null)
				{
					if (nCWCOIOOofbnfixPcuUIeRfVqGi is UnityEngine.Object)
					{
						return (UnityEngine.Object)nCWCOIOOofbnfixPcuUIeRfVqGi == null;
					}
					return false;
				}
				return true;
			}
		}

		private Action<Exception> jFLXkjJoMycXArhmBXOzdIdMyQs;

		private readonly List<qOEcssJXIAIFhlxIqAUhcaUfsYAe> JOFWBLbtnIgSRNRcsEqIWNKQYRG;

		private readonly List<qOEcssJXIAIFhlxIqAUhcaUfsYAe> YFWUpnJGFpHjUaVLKkXmahBRGYA;

		internal override int Count
		{
			get
			{
				return JOFWBLbtnIgSRNRcsEqIWNKQYRG.Count;
			}
		}

		internal override Action<Exception> ExceptionHandler
		{
			get
			{
				return jFLXkjJoMycXArhmBXOzdIdMyQs;
			}
			set
			{
				jFLXkjJoMycXArhmBXOzdIdMyQs = value;
			}
		}

		protected SafeDelegate()
		{
			while (true)
			{
				int num = 1058064011;
				while (true)
				{
					switch (num ^ 0x3F10C688)
					{
					case 2:
						break;
					default:
						return;
					case 4:
						if (jFLXkjJoMycXArhmBXOzdIdMyQs == null)
						{
							jFLXkjJoMycXArhmBXOzdIdMyQs = SafeDelegate.S_ExceptionHandler;
							num = 1058064009;
							continue;
						}
						return;
					case 0:
						JOFWBLbtnIgSRNRcsEqIWNKQYRG = new List<qOEcssJXIAIFhlxIqAUhcaUfsYAe>();
						YFWUpnJGFpHjUaVLKkXmahBRGYA = new List<qOEcssJXIAIFhlxIqAUhcaUfsYAe>();
						num = 1058064012;
						continue;
					case 3:
						if (!ReflectionTools.DoesTypeImplement(typeof(T), typeof(Delegate)))
						{
							throw new Exception(typeof(T).Name + " is not a delegate type! SafeDelegate only works with delegate types.");
						}
						goto case 0;
					case 1:
						return;
					}
					break;
				}
			}
		}

		protected SafeDelegate(Action<Exception> exceptionHandler)
			: this()
		{
			if (exceptionHandler == null)
			{
				throw new ArgumentNullException("exceptionHandler");
			}
			jFLXkjJoMycXArhmBXOzdIdMyQs = exceptionHandler;
		}

		protected SafeDelegate(SafeDelegate<T> source)
			: this()
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (source.jFLXkjJoMycXArhmBXOzdIdMyQs != null)
			{
				jFLXkjJoMycXArhmBXOzdIdMyQs = source.jFLXkjJoMycXArhmBXOzdIdMyQs;
			}
			for (int i = 0; i < source.JOFWBLbtnIgSRNRcsEqIWNKQYRG.Count; i++)
			{
				JOFWBLbtnIgSRNRcsEqIWNKQYRG.Add(new qOEcssJXIAIFhlxIqAUhcaUfsYAe(source.JOFWBLbtnIgSRNRcsEqIWNKQYRG[i]));
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
				List<Delegate> list = rNMiAKLBydWDZBKESMbqQEsbPn((Delegate)(object)@delegate);
				if (list == null)
				{
					break;
				}
				int num;
				int num2;
				if (list.Count != 0)
				{
					num = 1982036309;
					num2 = num;
				}
				else
				{
					num = 1982036308;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ 0x76237955)
					{
					case 6:
						num = 1982036311;
						continue;
					case 3:
					{
						T val = (T)(object)list[num3];
						if (!WfhdeimYiTFGUIbHSjqOJaakYWS(val))
						{
							JOFWBLbtnIgSRNRcsEqIWNKQYRG.Add(new qOEcssJXIAIFhlxIqAUhcaUfsYAe(val));
							num = 1982036305;
							continue;
						}
						goto case 4;
					}
					case 0:
						num3 = 0;
						num = 1982036304;
						continue;
					case 1:
						return;
					case 4:
						num3++;
						num = 1982036304;
						continue;
					case 2:
						break;
					default:
						if (num3 >= list.Count)
						{
							return;
						}
						goto case 3;
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
			int num3 = default(int);
			int num4 = default(int);
			int count = default(int);
			while (true)
			{
				List<Delegate> list = rNMiAKLBydWDZBKESMbqQEsbPn((Delegate)(object)@delegate);
				if (list == null)
				{
					break;
				}
				int num;
				int num2;
				if (list.Count == 0)
				{
					num = -1280525276;
					num2 = num;
				}
				else
				{
					num = -1280525274;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -1280525274)
					{
					case 9:
						num = -1280525267;
						continue;
					case 5:
						num3 = 0;
						num = -1280525273;
						continue;
					case 6:
						num4 = count - 1;
						num = -1280525268;
						continue;
					case 1:
						num = -1280525278;
						continue;
					case 7:
						if (num4 < 0)
						{
							num3++;
							num = -1280525278;
							continue;
						}
						goto case 3;
					case 2:
						return;
					case 3:
						if (EqualityComparer<T>.Default.Equals(JOFWBLbtnIgSRNRcsEqIWNKQYRG[num4].RERAhLRQKJhiOXbllLXxmBeUAhn, (T)(object)list[num3]))
						{
							JOFWBLbtnIgSRNRcsEqIWNKQYRG.RemoveAt(num4);
							num = -1280525266;
							continue;
						}
						goto case 8;
					case 0:
						count = JOFWBLbtnIgSRNRcsEqIWNKQYRG.Count;
						num = -1280525277;
						continue;
					case 10:
						num = -1280525279;
						continue;
					case 11:
						break;
					case 8:
						num4--;
						num = -1280525279;
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

		internal override void RemoveDelegateOrAllDelegatesFromAnObject(object obj)
		{
			int count = JOFWBLbtnIgSRNRcsEqIWNKQYRG.Count;
			int num = count - 1;
			while (num >= 0)
			{
				while (true)
				{
					Delegate obj2 = vnTDYyyoVFZCZsaNYUeUYXhZrkq(obj, (Delegate)(object)JOFWBLbtnIgSRNRcsEqIWNKQYRG[num].RERAhLRQKJhiOXbllLXxmBeUAhn);
					int num2;
					if (bQzsLcvVPaldpLqZhFaDdMptFsX(obj2) == 0)
					{
						JOFWBLbtnIgSRNRcsEqIWNKQYRG.RemoveAt(num);
						num2 = -2012316744;
						goto IL_001a;
					}
					goto IL_0078;
					IL_001a:
					while (true)
					{
						switch (num2 ^ -2012316742)
						{
						case 0:
							num2 = -2012316738;
							continue;
						case 4:
							break;
						case 3:
							goto IL_0078;
						case 2:
							num--;
							num2 = -2012316741;
							continue;
						default:
							goto end_IL_003b;
						}
						break;
					}
					continue;
					IL_0078:
					JOFWBLbtnIgSRNRcsEqIWNKQYRG[num] = new qOEcssJXIAIFhlxIqAUhcaUfsYAe((T)(object)obj2);
					num2 = -2012316744;
					goto IL_001a;
					continue;
					end_IL_003b:
					break;
				}
			}
		}

		internal override void Clear()
		{
			JOFWBLbtnIgSRNRcsEqIWNKQYRG.Clear();
		}

		protected void Invoke(Action<object, T> invokeCallback)
		{
			if (invokeCallback == null)
			{
				throw new ArgumentNullException("invokeCallback");
			}
			List<int> list = default(List<int>);
			qOEcssJXIAIFhlxIqAUhcaUfsYAe qOEcssJXIAIFhlxIqAUhcaUfsYAe2 = default(qOEcssJXIAIFhlxIqAUhcaUfsYAe);
			int num3 = default(int);
			int num6 = default(int);
			while (true)
			{
				int count = JOFWBLbtnIgSRNRcsEqIWNKQYRG.Count;
				if (count == 0)
				{
					break;
				}
				while (true)
				{
					IL_00d5:
					YFWUpnJGFpHjUaVLKkXmahBRGYA.Clear();
					int num = 0;
					int num2 = -797750439;
					while (true)
					{
						int num5;
						switch (num2 ^ -797750446)
						{
						case 6:
							num2 = -797750447;
							continue;
						case 3:
							break;
						case 4:
							if (num >= count)
							{
								list = null;
								num2 = -797750441;
								continue;
							}
							goto case 8;
						case 2:
							qOEcssJXIAIFhlxIqAUhcaUfsYAe2 = YFWUpnJGFpHjUaVLKkXmahBRGYA[num3];
							if (qOEcssJXIAIFhlxIqAUhcaUfsYAe2.sNJocUkUBfBblcYcCaPoXifrWK)
							{
								num2 = -797750446;
								continue;
							}
							goto IL_012e;
						case 0:
							if (qOEcssJXIAIFhlxIqAUhcaUfsYAe2.icEGeQAMBmnjWCoiemfkcEWTDJwh())
							{
								num2 = -797750437;
								continue;
							}
							goto IL_012e;
						case 5:
							num3 = 0;
							goto IL_0213;
						case 9:
							if (list == null)
							{
								list = TempListPool.Get<int>();
								num2 = -797750445;
								continue;
							}
							goto case 1;
						case 10:
							goto IL_00d5;
						case 8:
							YFWUpnJGFpHjUaVLKkXmahBRGYA.Add(JOFWBLbtnIgSRNRcsEqIWNKQYRG[num]);
							num++;
							num2 = -797750442;
							continue;
						case 1:
							list.Add(num3);
							num2 = -797750443;
							continue;
						case 11:
							num2 = -797750442;
							continue;
						default:
							{
								num3++;
								goto IL_019b;
							}
							IL_012e:
							try
							{
								invokeCallback(this, qOEcssJXIAIFhlxIqAUhcaUfsYAe2.RERAhLRQKJhiOXbllLXxmBeUAhn);
							}
							catch (Exception obj)
							{
								if (jFLXkjJoMycXArhmBXOzdIdMyQs != null)
								{
									goto IL_0148;
								}
								goto IL_017e;
								IL_0148:
								int num4 = -797750448;
								goto IL_014d;
								IL_014d:
								while (true)
								{
									switch (num4 ^ -797750446)
									{
									case 0:
										break;
									case 2:
										jFLXkjJoMycXArhmBXOzdIdMyQs(obj);
										num4 = -797750445;
										continue;
									case 1:
										goto IL_017e;
									default:
										goto IL_018e;
									}
									break;
								}
								goto IL_0148;
								IL_017e:
								if (list == null)
								{
									list = TempListPool.Get<int>();
									num4 = -797750447;
									goto IL_014d;
								}
								goto IL_018e;
								IL_018e:
								list.Add(num3);
							}
							goto default;
							IL_019b:
							num5 = -797750442;
							goto IL_01a0;
							IL_01a0:
							while (true)
							{
								switch (num5 ^ -797750446)
								{
								case 0:
									break;
								default:
									return;
								case 1:
									if (count > 0)
									{
										YFWUpnJGFpHjUaVLKkXmahBRGYA.Clear();
										num5 = -797750448;
										continue;
									}
									return;
								case 3:
									if (list != null)
									{
										num6 = list.Count - 1;
										num5 = -797750441;
										continue;
									}
									goto case 1;
								case 6:
									JOFWBLbtnIgSRNRcsEqIWNKQYRG.RemoveAt(list[num6]);
									num6--;
									num5 = -797750441;
									continue;
								case 4:
									goto IL_0213;
								case 5:
									if (num6 < 0)
									{
										TempListPool.Return(list);
										num5 = -797750445;
										continue;
									}
									goto case 6;
								case 2:
									return;
								}
								break;
							}
							goto IL_019b;
							IL_0213:
							if (num3 < count)
							{
								goto case 2;
							}
							num5 = -797750447;
							goto IL_01a0;
						}
						break;
					}
					break;
				}
			}
		}

		protected T GetCombinedDelegate()
		{
			T result = default(T);
			if (JOFWBLbtnIgSRNRcsEqIWNKQYRG == null)
			{
				result = null;
				goto IL_0010;
			}
			T val = null;
			int num = 1697766192;
			goto IL_0015;
			IL_0015:
			T rERAhLRQKJhiOXbllLXxmBeUAhn = default(T);
			int num2 = default(int);
			while (true)
			{
				int num3;
				switch (num ^ 0x6531DB33)
				{
				case 6:
					break;
				case 1:
					return result;
				case 0:
					rERAhLRQKJhiOXbllLXxmBeUAhn = JOFWBLbtnIgSRNRcsEqIWNKQYRG[num2].RERAhLRQKJhiOXbllLXxmBeUAhn;
					num = 1697766193;
					continue;
				case 2:
					if (val == null)
					{
						num = 1697766199;
						continue;
					}
					try
					{
						val = (T)(object)Delegate.Combine((Delegate)(object)val, (Delegate)(object)rERAhLRQKJhiOXbllLXxmBeUAhn);
					}
					catch
					{
					}
					goto IL_00b3;
				case 3:
					num2 = 0;
					num = 1697766198;
					continue;
				default:
					val = rERAhLRQKJhiOXbllLXxmBeUAhn;
					goto IL_00b3;
				case 5:
					goto IL_00d5;
					IL_00b3:
					num2++;
					goto IL_00b7;
					IL_00b7:
					num3 = 1697766194;
					goto IL_00bc;
					IL_00bc:
					switch (num3 ^ 0x6531DB33)
					{
					case 0:
						break;
					case 1:
						goto IL_00d5;
					default:
						return val;
					}
					goto IL_00b7;
					IL_00d5:
					if (num2 < JOFWBLbtnIgSRNRcsEqIWNKQYRG.Count)
					{
						goto case 0;
					}
					num3 = 1697766193;
					goto IL_00bc;
				}
				break;
			}
			goto IL_0010;
			IL_0010:
			num = 1697766194;
			goto IL_0015;
		}

		private bool WfhdeimYiTFGUIbHSjqOJaakYWS(T P_0)
		{
			return EAgOMouOjbslHCCsyBDLoGVrHcd(P_0) >= 0;
		}

		private int EAgOMouOjbslHCCsyBDLoGVrHcd(T P_0)
		{
			int count = JOFWBLbtnIgSRNRcsEqIWNKQYRG.Count;
			int num = 0;
			while (true)
			{
				int num2 = -1079313705;
				while (true)
				{
					switch (num2 ^ -1079313708)
					{
					case 2:
						break;
					case 3:
						num2 = -1079313707;
						continue;
					case 0:
						if (EqualityComparer<T>.Default.Equals(JOFWBLbtnIgSRNRcsEqIWNKQYRG[num].RERAhLRQKJhiOXbllLXxmBeUAhn, P_0))
						{
							return num;
						}
						num++;
						num2 = -1079313707;
						continue;
					default:
						if (num >= count)
						{
							return -1;
						}
						goto case 0;
					}
					break;
				}
			}
		}

		private static Delegate vnTDYyyoVFZCZsaNYUeUYXhZrkq(object P_0, Delegate P_1)
		{
			if ((object)P_1 == null || P_0 == null)
			{
				return P_1;
			}
			if (P_0 is Delegate)
			{
				return vnTDYyyoVFZCZsaNYUeUYXhZrkq((Delegate)P_0, P_1);
			}
			try
			{
				Delegate[] invocationList = P_1.GetInvocationList();
				int num2 = default(int);
				while (true)
				{
					IL_0024:
					int num = 1194828645;
					while (true)
					{
						switch (num ^ 0x4737A366)
						{
						case 2:
							break;
						case 7:
							if ((object)P_1 == null)
							{
								return P_1;
							}
							goto case 6;
						case 5:
						{
							int num4;
							if (!object.ReferenceEquals(invocationList[num2].Target, P_0))
							{
								num = 1194828647;
								num4 = num;
							}
							else
							{
								num = 1194828641;
								num4 = num;
							}
							continue;
						}
						case 4:
							num2++;
							num = 1194828646;
							continue;
						case 6:
							P_1 = Delegate.RemoveAll(P_1, invocationList[num2]);
							num = 1194828642;
							continue;
						case 1:
						{
							int num3;
							if (!object.ReferenceEquals(ReflectionTools.GetMethodInfo(invocationList[num2]), P_0))
							{
								num = 1194828642;
								num3 = num;
							}
							else
							{
								num = 1194828641;
								num3 = num;
							}
							continue;
						}
						case 3:
							num2 = 0;
							num = 1194828646;
							continue;
						default:
							if (num2 >= invocationList.Length)
							{
								goto end_IL_0029;
							}
							goto case 5;
						}
						goto IL_0024;
						continue;
						end_IL_0029:
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
		}

		private static Delegate vnTDYyyoVFZCZsaNYUeUYXhZrkq(Delegate P_0, Delegate P_1)
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
				int num = 0;
				Delegate obj2 = default(Delegate);
				while (num < invocationList.Length)
				{
					while (true)
					{
						Delegate obj = invocationList[num];
						object methodInfo = ReflectionTools.GetMethodInfo(obj);
						int num2 = 0;
						int num3 = 431506809;
						while (true)
						{
							switch (num3 ^ 0x19B8457F)
							{
							case 0:
								num3 = 431506808;
								continue;
							case 3:
								P_1 = Delegate.RemoveAll(P_1, obj2);
								num3 = 431506814;
								continue;
							case 5:
								obj2 = invocationList2[num2];
								num3 = 431506811;
								continue;
							case 1:
								num2++;
								num3 = 431506809;
								continue;
							case 7:
								break;
							case 4:
							{
								object methodInfo2 = ReflectionTools.GetMethodInfo(obj2);
								if (object.ReferenceEquals(methodInfo, methodInfo2))
								{
									if ((object)P_1 == null)
									{
										return P_1;
									}
									goto case 3;
								}
								goto case 1;
							}
							case 6:
								if (num2 >= invocationList2.Length)
								{
									num++;
									num3 = 431506813;
									continue;
								}
								goto case 5;
							default:
								goto end_IL_008f;
							}
							break;
						}
						continue;
						end_IL_008f:
						break;
					}
				}
			}
			catch (Exception ex)
			{
				Logger.LogError("Exception caught while removing delegates from list (2):\n" + ex);
			}
			return P_1;
		}

		private static int bQzsLcvVPaldpLqZhFaDdMptFsX(Delegate P_0)
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

		private static List<Delegate> rNMiAKLBydWDZBKESMbqQEsbPn(Delegate P_0)
		{
			if ((object)P_0 == null)
			{
				goto IL_0003;
			}
			Delegate obj = P_0;
			Delegate[] invocationList = obj.GetInvocationList();
			if (invocationList == null)
			{
				return null;
			}
			List<Delegate> list = new List<Delegate>(invocationList.Length);
			int num = -225887383;
			goto IL_0008;
			IL_0003:
			num = -225887380;
			goto IL_0008;
			IL_0008:
			int num2 = default(int);
			while (true)
			{
				switch (num ^ -225887383)
				{
				case 2:
					break;
				case 1:
					num2++;
					num = -225887382;
					continue;
				case 4:
					list.Add(invocationList[num2]);
					num = -225887384;
					continue;
				case 0:
					num2 = 0;
					num = -225887382;
					continue;
				case 5:
					return null;
				default:
					if (num2 >= invocationList.Length)
					{
						return list;
					}
					goto case 4;
				}
				break;
			}
			goto IL_0003;
		}
	}
}
