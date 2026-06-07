using System;
using System.Collections.Generic;
using Rewired;
using Rewired.Utils;
using UnityEngine;

internal static class huuGkElBkGQiMROGJhgcoZddnWS
{
	[CustomObfuscation(rename = false)]
	public delegate void EventFunction<T, TArgs>(T handler, TArgs value) where T : class;

	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	public class HierarchyEventHelper<THandler, TValue> where THandler : class
	{
		[Flags]
		public enum wPcQGnABBDWmEsveqaGChzHrVmQ
		{
			iOlZgcuFwLCPNAjSgaSDuxucio = 0,
			GPvHCRsebwtmlqWcYlcJOPzQqbD = 1,
			cxppFhEkwgwtrskqhRnMGJfRexp = 4,
			VRpgzqlIBHLRocOPvkslrtXpONZ = 8,
			WHgiwAateZJhAfHYKZXKGLlYYfD = -1
		}

		private readonly EventFunction<THandler, TValue> mzfgevYZELKNSVkxoHJeLcDGXFr;

		private readonly List<THandler> KGsDSujkVHKHjBUlNJyPixCPBTEd;

		private readonly wPcQGnABBDWmEsveqaGChzHrVmQ ShUcIRnFYqTMGxbkUWqYOhzxWmK;

		public HierarchyEventHelper(EventFunction<THandler, TValue> executeDelegate)
			: this(executeDelegate, wPcQGnABBDWmEsveqaGChzHrVmQ.GPvHCRsebwtmlqWcYlcJOPzQqbD | wPcQGnABBDWmEsveqaGChzHrVmQ.cxppFhEkwgwtrskqhRnMGJfRexp)
		{
		}

		public HierarchyEventHelper(EventFunction<THandler, TValue> executeDelegate, wPcQGnABBDWmEsveqaGChzHrVmQ executeOn)
		{
			while (true)
			{
				int num = -411004137;
				while (true)
				{
					switch (num ^ -411004138)
					{
					case 0:
						break;
					case 1:
						if (executeDelegate != null)
						{
							goto IL_003d;
						}
						throw new ArgumentNullException("delegate");
					case 2:
						goto IL_003d;
					default:
						ShUcIRnFYqTMGxbkUWqYOhzxWmK = executeOn;
						return;
					}
					break;
					IL_003d:
					mzfgevYZELKNSVkxoHJeLcDGXFr = executeDelegate;
					KGsDSujkVHKHjBUlNJyPixCPBTEd = new List<THandler>();
					num = -411004139;
				}
			}
		}

		public void ExecuteOnAll(TValue value)
		{
			RwqDHEOqVfdKakzJJDWdchisavV(KGsDSujkVHKHjBUlNJyPixCPBTEd, value, mzfgevYZELKNSVkxoHJeLcDGXFr, true);
		}

		public void GetHandlers(Transform transform)
		{
			if ((ShUcIRnFYqTMGxbkUWqYOhzxWmK & wPcQGnABBDWmEsveqaGChzHrVmQ.GPvHCRsebwtmlqWcYlcJOPzQqbD) != wPcQGnABBDWmEsveqaGChzHrVmQ.iOlZgcuFwLCPNAjSgaSDuxucio)
			{
				goto IL_000d;
			}
			goto IL_00f6;
			IL_000d:
			int num = -458885730;
			goto IL_0012;
			IL_0012:
			while (true)
			{
				switch (num ^ -458885733)
				{
				case 0:
					break;
				default:
					return;
				case 7:
					goto IL_0046;
				case 8:
					UnityTools.GetComponents(transform, KGsDSujkVHKHjBUlNJyPixCPBTEd, true);
					num = -458885732;
					continue;
				case 5:
					if ((ShUcIRnFYqTMGxbkUWqYOhzxWmK & wPcQGnABBDWmEsveqaGChzHrVmQ.cxppFhEkwgwtrskqhRnMGJfRexp) != wPcQGnABBDWmEsveqaGChzHrVmQ.iOlZgcuFwLCPNAjSgaSDuxucio && (ShUcIRnFYqTMGxbkUWqYOhzxWmK & wPcQGnABBDWmEsveqaGChzHrVmQ.VRpgzqlIBHLRocOPvkslrtXpONZ) != wPcQGnABBDWmEsveqaGChzHrVmQ.iOlZgcuFwLCPNAjSgaSDuxucio)
					{
						UnityTools.GetComponentsInSelfAndChildren(transform.root, KGsDSujkVHKHjBUlNJyPixCPBTEd, false);
						return;
					}
					goto IL_00f6;
				case 4:
					UnityTools.GetComponentsInSelfAndChildren(transform, KGsDSujkVHKHjBUlNJyPixCPBTEd, true);
					num = -458885732;
					continue;
				case 3:
					UnityTools.GetComponentsInParents(transform, KGsDSujkVHKHjBUlNJyPixCPBTEd, true);
					num = -458885731;
					continue;
				case 1:
					goto IL_00d8;
				case 2:
					goto IL_00f6;
				case 6:
					return;
				}
				break;
				IL_00d8:
				int num2;
				if ((ShUcIRnFYqTMGxbkUWqYOhzxWmK & wPcQGnABBDWmEsveqaGChzHrVmQ.GPvHCRsebwtmlqWcYlcJOPzQqbD) != wPcQGnABBDWmEsveqaGChzHrVmQ.iOlZgcuFwLCPNAjSgaSDuxucio)
				{
					num = -458885729;
					num2 = num;
				}
				else
				{
					num = -458885741;
					num2 = num;
				}
				continue;
				IL_0046:
				int num3;
				if ((ShUcIRnFYqTMGxbkUWqYOhzxWmK & wPcQGnABBDWmEsveqaGChzHrVmQ.VRpgzqlIBHLRocOPvkslrtXpONZ) == 0)
				{
					num = -458885731;
					num3 = num;
				}
				else
				{
					num = -458885736;
					num3 = num;
				}
			}
			goto IL_000d;
			IL_00f6:
			int num4;
			if ((ShUcIRnFYqTMGxbkUWqYOhzxWmK & wPcQGnABBDWmEsveqaGChzHrVmQ.cxppFhEkwgwtrskqhRnMGJfRexp) == 0)
			{
				num = -458885732;
				num4 = num;
			}
			else
			{
				num = -458885734;
				num4 = num;
			}
			goto IL_0012;
		}
	}

	public static void FvFZuahFGjphiUgPDMGvZIxjP<T, TArgs>(T P_0, TArgs P_1, EventFunction<T, TArgs> P_2) where T : class
	{
		if (P_2 == null)
		{
			throw new ArgumentNullException("executeDelegate");
		}
		if (P_0 == null)
		{
			throw new ArgumentNullException("handler");
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

	public static void FvFZuahFGjphiUgPDMGvZIxjP<T, TArgs>(IList<T> P_0, TArgs P_1, EventFunction<T, TArgs> P_2) where T : class
	{
		if (P_2 == null)
		{
			goto IL_0003;
		}
		goto IL_0040;
		IL_0003:
		int num = 1562982983;
		goto IL_0008;
		IL_0008:
		T val = default(T);
		int num2 = default(int);
		int count = default(int);
		while (true)
		{
			int num3;
			switch (num ^ 0x5D293A46)
			{
			case 2:
				break;
			case 6:
				val = P_0[num2];
				num = 1562982982;
				continue;
			case 4:
				goto IL_0040;
			case 3:
				throw new ArgumentNullException("handlers");
			case 5:
				count = P_0.Count;
				num2 = 0;
				goto IL_00d4;
			case 1:
				throw new ArgumentNullException("executeDelegate");
			default:
				{
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
					num2++;
					goto IL_00b6;
				}
				IL_00b6:
				num3 = 1562982980;
				goto IL_00bb;
				IL_00d4:
				if (num2 < count)
				{
					goto case 6;
				}
				num3 = 1562982983;
				goto IL_00bb;
				IL_00bb:
				switch (num3 ^ 0x5D293A46)
				{
				case 0:
					break;
				default:
					return;
				case 2:
					goto IL_00d4;
				case 1:
					return;
				}
				goto IL_00b6;
			}
			break;
		}
		goto IL_0003;
		IL_0040:
		int num4;
		if (P_0 != null)
		{
			num = 1562982979;
			num4 = num;
		}
		else
		{
			num = 1562982981;
			num4 = num;
		}
		goto IL_0008;
	}

	public static void RwqDHEOqVfdKakzJJDWdchisavV<T, TArgs>(IList<T> P_0, TArgs P_1, EventFunction<T, TArgs> P_2, bool P_3) where T : class
	{
		if (P_2 == null)
		{
			throw new ArgumentNullException("executeDelegate");
		}
		T val = default(T);
		int num3 = default(int);
		while (true)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("handlers");
			}
			while (true)
			{
				IL_007d:
				int num = P_0.Count;
				int num2 = 1082450963;
				while (true)
				{
					switch (num2 ^ 0x4084E413)
					{
					case 2:
						num2 = 1082450966;
						continue;
					case 5:
						break;
					case 4:
						if (val as Component == null)
						{
							if (P_3)
							{
								P_0.RemoveAt(num3);
								num3--;
								num--;
								num2 = 1082450965;
								continue;
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
								Rewired.Logger.LogError("Caught exception in event handler:\n" + ex);
							}
						}
						goto default;
					case 3:
						goto IL_007d;
					case 0:
						num3 = 0;
						goto IL_00ce;
					case 1:
						val = P_0[num3];
						num2 = 1082450967;
						continue;
					default:
						{
							num3++;
							goto IL_00ce;
						}
						IL_00ce:
						if (num3 >= num)
						{
							return;
						}
						goto case 1;
					}
					break;
				}
				break;
			}
		}
	}
}
