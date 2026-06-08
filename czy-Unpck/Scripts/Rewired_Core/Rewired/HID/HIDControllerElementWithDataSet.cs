using System;
using System.Collections.Generic;
using Rewired.Config;
using Rewired.Utils;

namespace Rewired.HID
{
	[CustomObfuscation(rename = false)]
	[CustomClassObfuscation(renamePrivateMembers = true, renamePubIntMembers = false)]
	internal abstract class HIDControllerElementWithDataSet : HIDControllerElement
	{
		internal abstract class THYotAuJqxRpkaiYpKZdRoaWmOB
		{
			private int KTqLwlllGIceKVYKGJbTKnTakUj;

			private int[] zFEnZxjygCrlikqPzBDIAJpbLBfQ;

			protected fGUslYDckUuYvbbXSoXhSBIBfBT[] ukQXiEKzTMzPimOeOTmWBVpgDWV;

			public fGUslYDckUuYvbbXSoXhSBIBfBT fSpdVoeWhOYoAilpUehbSxUxANDS;

			private int VXgPrLiRFgJCxmeSHMjaqdvOBgr;

			private int ZAXrLeSNctacqgyxupEGAzXGQYu = -1;

			private bool UUnypIIfQihusKKsRGbhsEYxCLL;

			protected int dataCount => KTqLwlllGIceKVYKGJbTKnTakUj;

			protected int[] updateLoopIndex => zFEnZxjygCrlikqPzBDIAJpbLBfQ;

			public UpdateLoopType updateLoop
			{
				set
				{
					if (ZAXrLeSNctacqgyxupEGAzXGQYu != (int)value)
					{
						ZAXrLeSNctacqgyxupEGAzXGQYu = (int)value;
						VXgPrLiRFgJCxmeSHMjaqdvOBgr = zFEnZxjygCrlikqPzBDIAJpbLBfQ[(int)value];
						fSpdVoeWhOYoAilpUehbSxUxANDS = ukQXiEKzTMzPimOeOTmWBVpgDWV[VXgPrLiRFgJCxmeSHMjaqdvOBgr];
					}
				}
			}

			public THYotAuJqxRpkaiYpKZdRoaWmOB()
			{
			}

			public void QrfyiMPYnSYoyuzKvpeNAZHZaMI(UpdateLoopSetting P_0, Func<UpdateLoopType, fGUslYDckUuYvbbXSoXhSBIBfBT> P_1)
			{
				if (UUnypIIfQihusKKsRGbhsEYxCLL)
				{
					Logger.LogError("Already initialized!");
					goto IL_0012;
				}
				goto IL_004d;
				IL_004d:
				zFEnZxjygCrlikqPzBDIAJpbLBfQ = new int[3];
				KTqLwlllGIceKVYKGJbTKnTakUj = 0;
				int num = 692338655;
				goto IL_0017;
				IL_0012:
				num = 692338648;
				goto IL_0017;
				IL_0017:
				List<fGUslYDckUuYvbbXSoXhSBIBfBT> list2 = default(List<fGUslYDckUuYvbbXSoXhSBIBfBT>);
				int num3 = default(int);
				while (true)
				{
					switch (num ^ 0x29443FDC)
					{
					case 0:
						break;
					case 4:
						return;
					case 3:
						list2 = new List<fGUslYDckUuYvbbXSoXhSBIBfBT>();
						num = 692338653;
						continue;
					case 2:
						goto IL_004d;
					default:
					{
						using (TempListPool.TList<UpdateLoopType> tList = TempListPool.GetTList<UpdateLoopType>(3))
						{
							List<UpdateLoopType> list = tList.list;
							EnumConverter.ToUpdateLoopTypes(P_0, list);
							while (true)
							{
								IL_007d:
								int num2 = 692338649;
								while (true)
								{
									switch (num2 ^ 0x29443FDC)
									{
									case 3:
										break;
									default:
										goto end_IL_0082;
									case 4:
										num3++;
										num2 = 692338653;
										continue;
									case 1:
									{
										int num4;
										if (num3 >= list.Count)
										{
											num2 = 692338652;
											num4 = num2;
										}
										else
										{
											num2 = 692338650;
											num4 = num2;
										}
										continue;
									}
									case 6:
										zFEnZxjygCrlikqPzBDIAJpbLBfQ[(int)list[num3]] = KTqLwlllGIceKVYKGJbTKnTakUj;
										num2 = 692338654;
										continue;
									case 5:
										num3 = 0;
										num2 = 692338653;
										continue;
									case 2:
										KTqLwlllGIceKVYKGJbTKnTakUj++;
										list2.Add(P_1(list[num3]));
										num2 = 692338648;
										continue;
									case 0:
										goto end_IL_0082;
									}
									goto IL_007d;
									continue;
									end_IL_0082:
									break;
								}
								break;
							}
						}
						ukQXiEKzTMzPimOeOTmWBVpgDWV = list2.ToArray();
						UUnypIIfQihusKKsRGbhsEYxCLL = true;
						return;
					}
					}
					break;
				}
				goto IL_0012;
			}

			private void xrBSEbLKJznfFFPNFtAjtplocEO(UpdateLoopType P_0, fGUslYDckUuYvbbXSoXhSBIBfBT P_1)
			{
				ukQXiEKzTMzPimOeOTmWBVpgDWV[zFEnZxjygCrlikqPzBDIAJpbLBfQ[(int)P_0]] = P_1;
			}

			public virtual void GzCliicOSMFLMvKajLgvnmGSSrh(UpdateLoopType P_0)
			{
				if (ZAXrLeSNctacqgyxupEGAzXGQYu == (int)P_0)
				{
					while (true)
					{
						switch (0x1F9F17D0 ^ 0x1F9F17D1)
						{
						case 2:
							continue;
						case 1:
							return;
						}
						break;
					}
				}
				updateLoop = P_0;
			}

			public void CHWDoIJFbUPiCCQqjvBLnPoSWjTy()
			{
				int num = 0;
				while (true)
				{
					int num2 = -2105310911;
					while (true)
					{
						switch (num2 ^ -2105310910)
						{
						case 2:
							break;
						case 3:
							num2 = -2105310909;
							continue;
						case 0:
							ukQXiEKzTMzPimOeOTmWBVpgDWV[num].CHWDoIJFbUPiCCQqjvBLnPoSWjTy();
							num++;
							num2 = -2105310909;
							continue;
						default:
							if (num >= KTqLwlllGIceKVYKGJbTKnTakUj)
							{
								return;
							}
							goto case 0;
						}
						break;
					}
				}
			}
		}

		internal abstract class fGUslYDckUuYvbbXSoXhSBIBfBT
		{
			public readonly UpdateLoopType cmiDdQAFcgEckBbjnNTFEbMKLqrn;

			public fGUslYDckUuYvbbXSoXhSBIBfBT(UpdateLoopType updateLoop)
			{
				cmiDdQAFcgEckBbjnNTFEbMKLqrn = updateLoop;
			}

			public abstract void CHWDoIJFbUPiCCQqjvBLnPoSWjTy();
		}

		internal THYotAuJqxRpkaiYpKZdRoaWmOB dataSet;

		public HIDControllerElementWithDataSet(THYotAuJqxRpkaiYpKZdRoaWmOB dataSet, byte reportId, HIDInfo hidInfo)
			: base(reportId, hidInfo)
		{
			while (true)
			{
				int num = 1579918744;
				while (true)
				{
					switch (num ^ 0x5E2BA599)
					{
					case 0:
						break;
					default:
						return;
					case 1:
						goto IL_0026;
					case 2:
						return;
					}
					break;
					IL_0026:
					this.dataSet = dataSet;
					num = 1579918747;
				}
			}
		}

		public virtual void Update(UpdateLoopType updateLoop)
		{
			if (dataSet == null)
			{
				return;
			}
			while (true)
			{
				dataSet.GzCliicOSMFLMvKajLgvnmGSSrh(updateLoop);
				int num = 1763646478;
				while (true)
				{
					switch (num ^ 0x691F1C0F)
					{
					case 0:
						goto IL_0009;
					default:
						return;
					case 2:
						break;
					case 1:
						return;
					}
					break;
					IL_0009:
					num = 1763646477;
				}
			}
		}
	}
}
