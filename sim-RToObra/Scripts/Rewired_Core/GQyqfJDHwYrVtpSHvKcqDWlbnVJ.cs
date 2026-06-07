using System;
using System.Collections.Generic;
using Rewired;
using Rewired.Utils;
using UnityEngine;

internal static class GQyqfJDHwYrVtpSHvKcqDWlbnVJ
{
	[CustomObfuscation(rename = false)]
	public delegate void EventFunction<T, TArgs>(T handler, TArgs value) where T : class;

	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	public class HierarchyEventHelper<THandler, TValue> where THandler : class
	{
		[Flags]
		public enum etabyBPtLZGexHfniBlZwQjQzulJ
		{
			TCGihQKDgeeGtvEXifcuojmabzj = 0,
			zObnXUAQjuELSOKdkpgPxHrSqyO = 1,
			LNdKYuuukcmEUWWnVSjYrthVBue = 4,
			gJnvwjXDFJBcXQFEZiklAxTlVJE = 8,
			doFtcjAfrygYQXECsZOVnHNlHWm = -1
		}

		private readonly EventFunction<THandler, TValue> NYrjaeoFUBtElladMRkqaaiSfGs;

		private readonly List<THandler> hfyTPrEgDDYcWcMenreZUEIDhYBC;

		private readonly etabyBPtLZGexHfniBlZwQjQzulJ zsGZaANDMwjznPEzkQuGfNxxzfP;

		public HierarchyEventHelper(EventFunction<THandler, TValue> executeDelegate)
			: this(executeDelegate, etabyBPtLZGexHfniBlZwQjQzulJ.zObnXUAQjuELSOKdkpgPxHrSqyO | etabyBPtLZGexHfniBlZwQjQzulJ.LNdKYuuukcmEUWWnVSjYrthVBue)
		{
		}

		public HierarchyEventHelper(EventFunction<THandler, TValue> executeDelegate, etabyBPtLZGexHfniBlZwQjQzulJ executeOn)
		{
			if (executeDelegate == null)
			{
				throw new ArgumentNullException("delegate");
			}
			NYrjaeoFUBtElladMRkqaaiSfGs = executeDelegate;
			hfyTPrEgDDYcWcMenreZUEIDhYBC = new List<THandler>();
			zsGZaANDMwjznPEzkQuGfNxxzfP = executeOn;
		}

		public void ExecuteOnAll(TValue value)
		{
			qJunMJiTJzbfTYhGhPVzXyqqhTQ(hfyTPrEgDDYcWcMenreZUEIDhYBC, value, NYrjaeoFUBtElladMRkqaaiSfGs, true);
		}

		public void GetHandlers(Transform transform)
		{
			if ((zsGZaANDMwjznPEzkQuGfNxxzfP & etabyBPtLZGexHfniBlZwQjQzulJ.zObnXUAQjuELSOKdkpgPxHrSqyO) != etabyBPtLZGexHfniBlZwQjQzulJ.TCGihQKDgeeGtvEXifcuojmabzj)
			{
				goto IL_000d;
			}
			goto IL_00f9;
			IL_000d:
			int num = 371813947;
			goto IL_0012;
			IL_0012:
			while (true)
			{
				switch (num ^ 0x16296E3E)
				{
				case 4:
					break;
				default:
					return;
				case 1:
					UnityTools.GetComponentsInParents(transform, hfyTPrEgDDYcWcMenreZUEIDhYBC, true);
					num = 371813942;
					continue;
				case 2:
					goto IL_005f;
				case 6:
					if ((zsGZaANDMwjznPEzkQuGfNxxzfP & etabyBPtLZGexHfniBlZwQjQzulJ.zObnXUAQjuELSOKdkpgPxHrSqyO) != etabyBPtLZGexHfniBlZwQjQzulJ.TCGihQKDgeeGtvEXifcuojmabzj)
					{
						UnityTools.GetComponentsInSelfAndChildren(transform, hfyTPrEgDDYcWcMenreZUEIDhYBC, true);
						num = 371813948;
						continue;
					}
					goto case 3;
				case 0:
					goto IL_009f;
				case 9:
					UnityTools.GetComponentsInSelfAndChildren(transform.root, hfyTPrEgDDYcWcMenreZUEIDhYBC, false);
					return;
				case 5:
					goto IL_00db;
				case 7:
					goto IL_00f9;
				case 3:
					UnityTools.GetComponents(transform, hfyTPrEgDDYcWcMenreZUEIDhYBC, true);
					num = 371813948;
					continue;
				case 8:
					return;
				}
				break;
				IL_00db:
				int num2;
				if ((zsGZaANDMwjznPEzkQuGfNxxzfP & etabyBPtLZGexHfniBlZwQjQzulJ.LNdKYuuukcmEUWWnVSjYrthVBue) != etabyBPtLZGexHfniBlZwQjQzulJ.TCGihQKDgeeGtvEXifcuojmabzj)
				{
					num = 371813950;
					num2 = num;
				}
				else
				{
					num = 371813945;
					num2 = num;
				}
				continue;
				IL_009f:
				int num3;
				if ((zsGZaANDMwjznPEzkQuGfNxxzfP & etabyBPtLZGexHfniBlZwQjQzulJ.gJnvwjXDFJBcXQFEZiklAxTlVJE) == 0)
				{
					num = 371813945;
					num3 = num;
				}
				else
				{
					num = 371813943;
					num3 = num;
				}
				continue;
				IL_005f:
				int num4;
				if ((zsGZaANDMwjznPEzkQuGfNxxzfP & etabyBPtLZGexHfniBlZwQjQzulJ.gJnvwjXDFJBcXQFEZiklAxTlVJE) == 0)
				{
					num = 371813942;
					num4 = num;
				}
				else
				{
					num = 371813951;
					num4 = num;
				}
			}
			goto IL_000d;
			IL_00f9:
			int num5;
			if ((zsGZaANDMwjznPEzkQuGfNxxzfP & etabyBPtLZGexHfniBlZwQjQzulJ.LNdKYuuukcmEUWWnVSjYrthVBue) != etabyBPtLZGexHfniBlZwQjQzulJ.TCGihQKDgeeGtvEXifcuojmabzj)
			{
				num = 371813944;
				num5 = num;
			}
			else
			{
				num = 371813948;
				num5 = num;
			}
			goto IL_0012;
		}
	}

	public static void LcDkIYUhPNOfERbDQRyUpFTUuBS<T, TArgs>(T P_0, TArgs P_1, EventFunction<T, TArgs> P_2) where T : class
	{
		if (P_2 == null)
		{
			throw new ArgumentNullException("executeDelegate");
		}
		while (P_0 == null)
		{
			int num = -720291957;
			while (true)
			{
				switch (num ^ -720291959)
				{
				case 0:
					goto IL_000e;
				case 1:
					break;
				default:
					throw new ArgumentNullException("handler");
				}
				break;
				IL_000e:
				num = -720291960;
			}
		}
		try
		{
			P_2(P_0, P_1);
		}
		catch (Exception ex)
		{
			Rewired.Logger.LogError("Caught exception in event handler:\n" + ex);
		}
	}

	public static void LcDkIYUhPNOfERbDQRyUpFTUuBS<T, TArgs>(IList<T> P_0, TArgs P_1, EventFunction<T, TArgs> P_2) where T : class
	{
		if (P_2 == null)
		{
			throw new ArgumentNullException("executeDelegate");
		}
		int count = default(int);
		int num3 = default(int);
		while (true)
		{
			int num;
			int num2;
			if (P_0 == null)
			{
				num = -2121257628;
				num2 = num;
			}
			else
			{
				num = -2121257629;
				num2 = num;
			}
			while (true)
			{
				int num4;
				switch (num ^ -2121257625)
				{
				case 2:
					goto IL_000e;
				case 1:
					break;
				case 3:
					throw new ArgumentNullException("handlers");
				case 4:
					count = P_0.Count;
					num3 = 0;
					goto IL_00bb;
				default:
					{
						T val = P_0[num3];
						if (val != null)
						{
							try
							{
								P_2(val, P_1);
							}
							catch (Exception ex)
							{
								Rewired.Logger.LogError("Caught exception in event handler:\n" + ex);
							}
						}
						num3++;
						goto IL_009d;
					}
					IL_00bb:
					if (num3 < count)
					{
						goto default;
					}
					num4 = -2121257625;
					goto IL_00a2;
					IL_009d:
					num4 = -2121257626;
					goto IL_00a2;
					IL_00a2:
					switch (num4 ^ -2121257625)
					{
					case 2:
						break;
					default:
						return;
					case 1:
						goto IL_00bb;
					case 0:
						return;
					}
					goto IL_009d;
				}
				break;
				IL_000e:
				num = -2121257626;
			}
		}
	}

	public static void qJunMJiTJzbfTYhGhPVzXyqqhTQ<T, TArgs>(IList<T> P_0, TArgs P_1, EventFunction<T, TArgs> P_2, bool P_3) where T : class
	{
		if (P_2 == null)
		{
			throw new ArgumentNullException("executeDelegate");
		}
		while (P_0 != null)
		{
			while (true)
			{
				IL_005f:
				int num = P_0.Count;
				int num2 = 0;
				while (true)
				{
					if (num2 < num)
					{
						while (true)
						{
							IL_0074:
							T val = P_0[num2];
							if (val as Component == null)
							{
								if (P_3)
								{
									int num3 = 1979596837;
									while (true)
									{
										switch (num3 ^ 0x75FE4026)
										{
										case 0:
											num3 = 1979596836;
											continue;
										case 2:
											break;
										case 3:
											P_0.RemoveAt(num2);
											num2--;
											num3 = 1979596839;
											continue;
										case 4:
											goto IL_005f;
										case 5:
											goto IL_0074;
										default:
											goto IL_009c;
										}
										break;
									}
									break;
								}
							}
							else
							{
								try
								{
									P_2(val, P_1);
								}
								catch (Exception ex)
								{
									while (true)
									{
										IL_00ad:
										int num4 = 1979596839;
										while (true)
										{
											switch (num4 ^ 0x75FE4026)
											{
											case 2:
												break;
											default:
												goto end_IL_00b2;
											case 1:
												goto IL_00cb;
											case 0:
												goto end_IL_00b2;
											}
											goto IL_00ad;
											IL_00cb:
											Rewired.Logger.LogError("Caught exception in event handler:\n" + ex);
											num4 = 1979596838;
											continue;
											end_IL_00b2:
											break;
										}
										break;
									}
								}
							}
							goto IL_00e4;
							IL_00e4:
							num2++;
							goto IL_00e8;
							IL_009c:
							num--;
							goto IL_00e4;
						}
						break;
					}
					int num5 = 1979596838;
					goto IL_00ed;
					IL_00e8:
					num5 = 1979596839;
					goto IL_00ed;
					IL_00ed:
					switch (num5 ^ 0x75FE4026)
					{
					case 2:
						break;
					default:
						return;
					case 1:
						continue;
					case 0:
						return;
					}
					goto IL_00e8;
				}
				break;
			}
		}
		throw new ArgumentNullException("handlers");
	}
}
