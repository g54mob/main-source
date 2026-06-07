using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired;
using Rewired.Utils.Classes.Data;

internal class vymLASJcQEATncxsXyaiNEjaYgR
{
	private class AkoflMjwbYgvajEZfcySUfeEWcT
	{
		public readonly InputAction ioPsBHOBTkemLHlszkXySyDclpE;

		public readonly int IcfehugnHVBDSlLvDDweqELIXNqm;

		public readonly int kCAKpbzMtpORRLEruzyeoXAFtRy;

		public AkoflMjwbYgvajEZfcySUfeEWcT(InputAction action, int arrayIndex)
		{
			ioPsBHOBTkemLHlszkXySyDclpE = action;
			IcfehugnHVBDSlLvDDweqELIXNqm = action.id;
			kCAKpbzMtpORRLEruzyeoXAFtRy = arrayIndex;
		}
	}

	private InputAction[] quMIcUZxngGMlyamEeeOOyUoRTR;

	private ADictionary<string, AkoflMjwbYgvajEZfcySUfeEWcT> JDwKUUWftTQBftwZiEDwTMYgjHe;

	private AkoflMjwbYgvajEZfcySUfeEWcT[] RQzSlCyfQxHTbmhcsgMBtoSdvPp;

	private ReadOnlyCollection<InputAction> TyWkCRYgVqboPOZsyWwDovZMDXV;

	private int xTeCXMZTviHabOyeniPPdGrzCYbC;

	private int HpyiUErUHaDZGRzJaaihgXLkOXS;

	private List<string> xfZShWZukIkKSvPSuRyuZrybBUQ;

	private List<int> wtcxoMQzHDKPmSStNtHgRpAmsDM;

	public IList<InputAction> Actions
	{
		get
		{
			return TyWkCRYgVqboPOZsyWwDovZMDXV;
		}
	}

	public int actionCount
	{
		get
		{
			return xTeCXMZTviHabOyeniPPdGrzCYbC;
		}
	}

	public int maxActionId
	{
		get
		{
			return HpyiUErUHaDZGRzJaaihgXLkOXS;
		}
	}

	public vymLASJcQEATncxsXyaiNEjaYgR(List<InputAction> actions)
	{
		int num2 = default(int);
		int num4 = default(int);
		int num5 = default(int);
		InputAction inputAction2 = default(InputAction);
		int num3 = default(int);
		while (true)
		{
			int num = 1050570657;
			while (true)
			{
				switch (num ^ 0x3E9E6FA7)
				{
				case 3:
					break;
				case 6:
					xfZShWZukIkKSvPSuRyuZrybBUQ = new List<string>();
					wtcxoMQzHDKPmSStNtHgRpAmsDM = new List<int>();
					num = 1050570671;
					continue;
				case 9:
					num2++;
					num = 1050570661;
					continue;
				case 0:
					if (num4 < xTeCXMZTviHabOyeniPPdGrzCYbC)
					{
						goto case 7;
					}
					JDwKUUWftTQBftwZiEDwTMYgjHe = new ADictionary<string, AkoflMjwbYgvajEZfcySUfeEWcT>(xTeCXMZTviHabOyeniPPdGrzCYbC, StringComparer.OrdinalIgnoreCase);
					num5 = 0;
					goto IL_019b;
				case 1:
					RQzSlCyfQxHTbmhcsgMBtoSdvPp[inputAction2.id] = new AkoflMjwbYgvajEZfcySUfeEWcT(inputAction2, num4);
					num4++;
					num = 1050570663;
					continue;
				case 8:
					quMIcUZxngGMlyamEeeOOyUoRTR = actions.ToArray();
					xTeCXMZTviHabOyeniPPdGrzCYbC = quMIcUZxngGMlyamEeeOOyUoRTR.Length;
					num3 = -1;
					num2 = 0;
					num = 1050570661;
					continue;
				case 2:
					if (num2 >= xTeCXMZTviHabOyeniPPdGrzCYbC)
					{
						HpyiUErUHaDZGRzJaaihgXLkOXS = num3;
						RQzSlCyfQxHTbmhcsgMBtoSdvPp = new AkoflMjwbYgvajEZfcySUfeEWcT[num3 + 1];
						num4 = 0;
						num = 1050570663;
						continue;
					}
					goto case 4;
				case 7:
					inputAction2 = quMIcUZxngGMlyamEeeOOyUoRTR[num4];
					num = 1050570662;
					continue;
				case 4:
				{
					int id = quMIcUZxngGMlyamEeeOOyUoRTR[num2].id;
					if (id > num3)
					{
						num3 = id;
						num = 1050570670;
						continue;
					}
					goto case 9;
				}
				default:
					{
						InputAction inputAction = quMIcUZxngGMlyamEeeOOyUoRTR[num5];
						try
						{
							JDwKUUWftTQBftwZiEDwTMYgjHe.Add(inputAction.name, RQzSlCyfQxHTbmhcsgMBtoSdvPp[inputAction.id]);
						}
						catch
						{
							Logger.LogError("Duplicate Action name \"" + inputAction.name + "\" found in Action list. Duplicate Action names are not allowed. If you have edited the data manually outside the Rewired Input Manager, remove any duplicate Actions.");
						}
						num5++;
						goto IL_019b;
					}
					IL_019b:
					if (num5 >= xTeCXMZTviHabOyeniPPdGrzCYbC)
					{
						TyWkCRYgVqboPOZsyWwDovZMDXV = new ReadOnlyCollection<InputAction>(quMIcUZxngGMlyamEeeOOyUoRTR);
						return;
					}
					goto default;
				}
				break;
			}
		}
	}

	public InputAction aOPpCNUcjpGHQGAwmiMbcBLiLlOK(string P_0, bool P_1 = false)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			return null;
		}
		AkoflMjwbYgvajEZfcySUfeEWcT value;
		if (!JDwKUUWftTQBftwZiEDwTMYgjHe.TryGetValue(P_0, out value))
		{
			while (true)
			{
				int num = -1612580096;
				while (true)
				{
					switch (num ^ -1612580095)
					{
					case 2:
						break;
					case 1:
					{
						int num2;
						if (P_1)
						{
							num = -1612580095;
							num2 = num;
						}
						else
						{
							num = -1612580094;
							num2 = num;
						}
						continue;
					}
					case 0:
						eaRrovXGaHgiiNUFXVOyHreTuiK(P_0);
						num = -1612580094;
						continue;
					default:
						return null;
					}
					break;
				}
			}
		}
		return value.ioPsBHOBTkemLHlszkXySyDclpE;
	}

	public InputAction YvfKaVFkYNkHtYuRlvvGuDrWhaQ(int P_0)
	{
		if (P_0 < 0)
		{
			return null;
		}
		if (P_0 > HpyiUErUHaDZGRzJaaihgXLkOXS)
		{
			return null;
		}
		if (RQzSlCyfQxHTbmhcsgMBtoSdvPp[P_0] == null)
		{
			return null;
		}
		return RQzSlCyfQxHTbmhcsgMBtoSdvPp[P_0].ioPsBHOBTkemLHlszkXySyDclpE;
	}

	public InputAction oOpczXCLtYBpuQrKTCdEkiyzKNlF(int P_0)
	{
		if (P_0 < 0 || P_0 >= xTeCXMZTviHabOyeniPPdGrzCYbC)
		{
			return null;
		}
		return quMIcUZxngGMlyamEeeOOyUoRTR[P_0];
	}

	public int tZuNWtSCplPhyqDRGNVBVrTnWqi(string P_0, bool P_1 = false)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			goto IL_0008;
		}
		AkoflMjwbYgvajEZfcySUfeEWcT value;
		int num;
		if (!JDwKUUWftTQBftwZiEDwTMYgjHe.TryGetValue(P_0, out value))
		{
			if (P_1)
			{
				eaRrovXGaHgiiNUFXVOyHreTuiK(P_0);
				num = 1022204717;
				goto IL_000d;
			}
			goto IL_0049;
		}
		return value.kCAKpbzMtpORRLEruzyeoXAFtRy;
		IL_0049:
		return -1;
		IL_000d:
		switch (num ^ 0x3CED9B2F)
		{
		case 0:
			break;
		case 1:
			return -1;
		default:
			goto IL_0049;
		}
		goto IL_0008;
		IL_0008:
		num = 1022204718;
		goto IL_000d;
	}

	public int tZuNWtSCplPhyqDRGNVBVrTnWqi(int P_0, bool P_1 = false)
	{
		if (P_0 >= 0)
		{
			goto IL_0004;
		}
		goto IL_0069;
		IL_0004:
		int num = -234966033;
		goto IL_0009;
		IL_0009:
		AkoflMjwbYgvajEZfcySUfeEWcT akoflMjwbYgvajEZfcySUfeEWcT = default(AkoflMjwbYgvajEZfcySUfeEWcT);
		while (true)
		{
			switch (num ^ -234966034)
			{
			case 3:
				break;
			case 2:
				eaRrovXGaHgiiNUFXVOyHreTuiK(P_0);
				num = -234966038;
				continue;
			case 6:
				goto IL_0040;
			case 5:
				goto IL_0052;
			case 0:
				goto IL_0069;
			case 1:
				goto IL_007e;
			default:
				return -1;
			}
			break;
			IL_007e:
			if (P_0 <= HpyiUErUHaDZGRzJaaihgXLkOXS)
			{
				akoflMjwbYgvajEZfcySUfeEWcT = RQzSlCyfQxHTbmhcsgMBtoSdvPp[P_0];
				num = -234966037;
			}
			else
			{
				num = -234966034;
			}
			continue;
			IL_0052:
			if (akoflMjwbYgvajEZfcySUfeEWcT == null)
			{
				int num2;
				if (!P_1)
				{
					num = -234966038;
					num2 = num;
				}
				else
				{
					num = -234966036;
					num2 = num;
				}
				continue;
			}
			return akoflMjwbYgvajEZfcySUfeEWcT.kCAKpbzMtpORRLEruzyeoXAFtRy;
		}
		goto IL_0004;
		IL_0069:
		if (P_0 >= 0 && P_1)
		{
			eaRrovXGaHgiiNUFXVOyHreTuiK(P_0);
			num = -234966040;
			goto IL_0009;
		}
		goto IL_0040;
		IL_0040:
		return -1;
	}

	public bool hVhfCpEYePxtliVMkmzCRpiiDkB(string P_0, bool P_1 = false)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			return false;
		}
		if (!JDwKUUWftTQBftwZiEDwTMYgjHe.ContainsKey(P_0))
		{
			while (true)
			{
				int num = 1444696399;
				while (true)
				{
					switch (num ^ 0x561C514D)
					{
					case 0:
						break;
					case 2:
						if (P_1)
						{
							goto IL_0039;
						}
						goto default;
					default:
						return false;
					}
					break;
					IL_0039:
					eaRrovXGaHgiiNUFXVOyHreTuiK(P_0);
					num = 1444696396;
				}
			}
		}
		return true;
	}

	public bool hVhfCpEYePxtliVMkmzCRpiiDkB(int P_0)
	{
		if (P_0 < 0 || P_0 > HpyiUErUHaDZGRzJaaihgXLkOXS)
		{
			return false;
		}
		return RQzSlCyfQxHTbmhcsgMBtoSdvPp[P_0] != null;
	}

	public int xYXbAPBVsnYFHcoavKDHwdxrYET(string P_0, bool P_1 = false)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			goto IL_0008;
		}
		AkoflMjwbYgvajEZfcySUfeEWcT value;
		int num;
		if (!JDwKUUWftTQBftwZiEDwTMYgjHe.TryGetValue(P_0, out value))
		{
			int num2;
			if (P_1)
			{
				num = 1416924748;
				num2 = num;
			}
			else
			{
				num = 1416924750;
				num2 = num;
			}
			goto IL_000d;
		}
		return value.IcfehugnHVBDSlLvDDweqELIXNqm;
		IL_000d:
		while (true)
		{
			switch (num ^ 0x54748E4E)
			{
			case 3:
				break;
			case 1:
				return -1;
			case 2:
				goto IL_0050;
			default:
				return -1;
			}
			break;
			IL_0050:
			eaRrovXGaHgiiNUFXVOyHreTuiK(P_0);
			num = 1416924750;
		}
		goto IL_0008;
		IL_0008:
		num = 1416924751;
		goto IL_000d;
	}

	private void eaRrovXGaHgiiNUFXVOyHreTuiK(string P_0)
	{
		if (xfZShWZukIkKSvPSuRyuZrybBUQ.Contains(P_0))
		{
			return;
		}
		while (true)
		{
			xfZShWZukIkKSvPSuRyuZrybBUQ.Add(P_0);
			int num = -958252500;
			while (true)
			{
				switch (num ^ -958252499)
				{
				case 0:
					goto IL_000f;
				case 2:
					break;
				default:
					Logger.LogWarning("The Action \"" + P_0 + "\" does not exist. You can create Actions in the editor.");
					return;
				}
				break;
				IL_000f:
				num = -958252497;
			}
		}
	}

	private void eaRrovXGaHgiiNUFXVOyHreTuiK(int P_0)
	{
		if (wtcxoMQzHDKPmSStNtHgRpAmsDM.Contains(P_0))
		{
			while (true)
			{
				switch (0x654EF1B8 ^ 0x654EF1B9)
				{
				case 0:
					continue;
				case 1:
					return;
				}
				break;
			}
		}
		wtcxoMQzHDKPmSStNtHgRpAmsDM.Add(P_0);
		Logger.LogWarning("No Action exists for Action Id " + P_0 + ". You can create Actions in the editor.");
	}
}
