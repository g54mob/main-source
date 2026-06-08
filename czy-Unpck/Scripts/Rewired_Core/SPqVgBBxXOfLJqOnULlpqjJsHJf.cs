using System;
using System.Collections.Generic;
using Rewired;
using Rewired.Utils;
using UnityEngine;

internal static class SPqVgBBxXOfLJqOnULlpqjJsHJf
{
	[CustomObfuscation(rename = false)]
	public delegate void EventFunction<T, TArgs>(T handler, TArgs value) where T : class;

	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	[CustomObfuscation(rename = false)]
	public class HierarchyEventHelper<THandler, TValue> where THandler : class
	{
		[Flags]
		public enum cSsWAfHobbUgqikorzwJLKRNFpB
		{
			XHUTYEIfTgeCBgXrVRVbPfGzuhN = 0,
			nLhhNGOsMuvwkXvLHVdIUuZPaze = 1,
			LXbacgoIFwYgcXrPmfGXeURECcQg = 4,
			ewheNxJceNsSlBpccxFkjrrarBe = 8,
			rSNuNvIqSsCYyOvwPcpWYAraGFK = -1
		}

		private readonly EventFunction<THandler, TValue> JBhaZgguwJdLDCoJpoerzHAHlQOB;

		private readonly List<THandler> xzejxzKuOJGBsjQMGRIWjDsAEux;

		private readonly cSsWAfHobbUgqikorzwJLKRNFpB zgYRhGZLrsTPBSoFTgVFAKBmUnj;

		public HierarchyEventHelper(EventFunction<THandler, TValue> executeDelegate)
			: this(executeDelegate, cSsWAfHobbUgqikorzwJLKRNFpB.nLhhNGOsMuvwkXvLHVdIUuZPaze | cSsWAfHobbUgqikorzwJLKRNFpB.LXbacgoIFwYgcXrPmfGXeURECcQg)
		{
		}

		public HierarchyEventHelper(EventFunction<THandler, TValue> executeDelegate, cSsWAfHobbUgqikorzwJLKRNFpB executeOn)
		{
			if (executeDelegate == null)
			{
				throw new ArgumentNullException("delegate");
			}
			JBhaZgguwJdLDCoJpoerzHAHlQOB = executeDelegate;
			xzejxzKuOJGBsjQMGRIWjDsAEux = new List<THandler>();
			zgYRhGZLrsTPBSoFTgVFAKBmUnj = executeOn;
		}

		public void ExecuteOnAll(TValue value)
		{
			osycwXaGebFSlHsgKsAmuSOznUm(xzejxzKuOJGBsjQMGRIWjDsAEux, value, JBhaZgguwJdLDCoJpoerzHAHlQOB, true);
		}

		public void GetHandlers(Transform transform)
		{
			if ((zgYRhGZLrsTPBSoFTgVFAKBmUnj & cSsWAfHobbUgqikorzwJLKRNFpB.nLhhNGOsMuvwkXvLHVdIUuZPaze) != cSsWAfHobbUgqikorzwJLKRNFpB.XHUTYEIfTgeCBgXrVRVbPfGzuhN)
			{
				goto IL_000a;
			}
			goto IL_0069;
			IL_000a:
			int num = 297760823;
			goto IL_000f;
			IL_000f:
			while (true)
			{
				switch (num ^ 0x11BF7830)
				{
				case 0:
					break;
				default:
					return;
				case 9:
					num = 297760818;
					continue;
				case 5:
					goto IL_004e;
				case 4:
					goto IL_0069;
				case 3:
					UnityTools.GetComponentsInSelfAndChildren(transform.root, xzejxzKuOJGBsjQMGRIWjDsAEux, append: false);
					return;
				case 7:
					goto IL_00a2;
				case 2:
					if ((zgYRhGZLrsTPBSoFTgVFAKBmUnj & cSsWAfHobbUgqikorzwJLKRNFpB.ewheNxJceNsSlBpccxFkjrrarBe) != cSsWAfHobbUgqikorzwJLKRNFpB.XHUTYEIfTgeCBgXrVRVbPfGzuhN)
					{
						UnityTools.GetComponentsInParents(transform, xzejxzKuOJGBsjQMGRIWjDsAEux, append: true);
						num = 297760824;
						continue;
					}
					return;
				case 6:
					if ((zgYRhGZLrsTPBSoFTgVFAKBmUnj & cSsWAfHobbUgqikorzwJLKRNFpB.nLhhNGOsMuvwkXvLHVdIUuZPaze) != cSsWAfHobbUgqikorzwJLKRNFpB.XHUTYEIfTgeCBgXrVRVbPfGzuhN)
					{
						UnityTools.GetComponentsInSelfAndChildren(transform, xzejxzKuOJGBsjQMGRIWjDsAEux, append: true);
						num = 297760825;
						continue;
					}
					goto case 1;
				case 1:
					UnityTools.GetComponents(transform, xzejxzKuOJGBsjQMGRIWjDsAEux, append: true);
					num = 297760818;
					continue;
				case 8:
					return;
				}
				break;
				IL_00a2:
				int num2;
				if ((zgYRhGZLrsTPBSoFTgVFAKBmUnj & cSsWAfHobbUgqikorzwJLKRNFpB.LXbacgoIFwYgcXrPmfGXeURECcQg) == 0)
				{
					num = 297760820;
					num2 = num;
				}
				else
				{
					num = 297760821;
					num2 = num;
				}
				continue;
				IL_004e:
				int num3;
				if ((zgYRhGZLrsTPBSoFTgVFAKBmUnj & cSsWAfHobbUgqikorzwJLKRNFpB.ewheNxJceNsSlBpccxFkjrrarBe) != cSsWAfHobbUgqikorzwJLKRNFpB.XHUTYEIfTgeCBgXrVRVbPfGzuhN)
				{
					num = 297760819;
					num3 = num;
				}
				else
				{
					num = 297760820;
					num3 = num;
				}
			}
			goto IL_000a;
			IL_0069:
			int num4;
			if ((zgYRhGZLrsTPBSoFTgVFAKBmUnj & cSsWAfHobbUgqikorzwJLKRNFpB.LXbacgoIFwYgcXrPmfGXeURECcQg) != cSsWAfHobbUgqikorzwJLKRNFpB.XHUTYEIfTgeCBgXrVRVbPfGzuhN)
			{
				num = 297760822;
				num4 = num;
			}
			else
			{
				num = 297760818;
				num4 = num;
			}
			goto IL_000f;
		}
	}

	public static void PhZTAAQwWTPeiIRxpgRLOdzJEqc<T, TArgs>(T P_0, TArgs P_1, EventFunction<T, TArgs> P_2) where T : class
	{
		if (P_2 == null)
		{
			while (true)
			{
				switch (0x3F7373D3 ^ 0x3F7373D1)
				{
				case 0:
					continue;
				case 2:
					throw new ArgumentNullException("executeDelegate");
				}
				break;
			}
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

	public static void PhZTAAQwWTPeiIRxpgRLOdzJEqc<T, TArgs>(IList<T> P_0, TArgs P_1, EventFunction<T, TArgs> P_2) where T : class
	{
		if (P_2 == null)
		{
			throw new ArgumentNullException("executeDelegate");
		}
		T val = default(T);
		while (true)
		{
			if (P_0 != null)
			{
				while (true)
				{
					int count = P_0.Count;
					int num = 0;
					int num2 = -1748907675;
					while (true)
					{
						switch (num2 ^ -1748907675)
						{
						case 3:
							num2 = -1748907679;
							continue;
						case 5:
							val = P_0[num];
							num2 = -1748907673;
							continue;
						case 1:
							break;
						case 4:
							goto end_IL_0050;
						default:
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
							num++;
							goto case 0;
						case 0:
							if (num >= count)
							{
								return;
							}
							goto case 5;
						}
						break;
					}
					continue;
					end_IL_0050:
					break;
				}
				continue;
			}
			throw new ArgumentNullException("handlers");
		}
	}

	public static void osycwXaGebFSlHsgKsAmuSOznUm<T, TArgs>(IList<T> P_0, TArgs P_1, EventFunction<T, TArgs> P_2, bool P_3) where T : class
	{
		if (P_2 == null)
		{
			throw new ArgumentNullException("executeDelegate");
		}
		int num3 = default(int);
		while (true)
		{
			if (P_0 != null)
			{
				while (true)
				{
					int num = P_0.Count;
					int num2 = -1447622535;
					while (true)
					{
						switch (num2 ^ -1447622536)
						{
						case 5:
							num2 = -1447622533;
							continue;
						case 0:
							num--;
							num2 = -1447622530;
							continue;
						case 2:
							break;
						case 1:
							num3 = 0;
							goto IL_00ce;
						case 4:
						{
							T val = P_0[num3];
							if (val as Component == null)
							{
								if (P_3)
								{
									P_0.RemoveAt(num3);
									num3--;
									num2 = -1447622536;
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
						}
						case 3:
							goto end_IL_004a;
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
							goto case 4;
						}
						break;
					}
					continue;
					end_IL_004a:
					break;
				}
				continue;
			}
			throw new ArgumentNullException("handlers");
		}
	}
}
