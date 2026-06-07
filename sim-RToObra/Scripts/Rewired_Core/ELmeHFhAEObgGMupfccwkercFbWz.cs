using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired;
using Rewired.Utils.Classes.Data;

internal class ELmeHFhAEObgGMupfccwkercFbWz
{
	private class fBnxGcgrIcOGJSNFGnpUaCDyEhA
	{
		public readonly InputAction LtBAfGkKNqHRqhMdRGTuxvLalcV;

		public readonly int fKtuodNzZLrsthNmhfemlCLUaYzG;

		public readonly int LeMumcZIhvowyxwsSoccRnQZCCji;

		public fBnxGcgrIcOGJSNFGnpUaCDyEhA(InputAction action, int arrayIndex)
		{
			while (true)
			{
				int num = 161343277;
				while (true)
				{
					switch (num ^ 0x99DE72F)
					{
					case 0:
						break;
					case 2:
						goto IL_0024;
					default:
						fKtuodNzZLrsthNmhfemlCLUaYzG = action.id;
						LeMumcZIhvowyxwsSoccRnQZCCji = arrayIndex;
						return;
					}
					break;
					IL_0024:
					LtBAfGkKNqHRqhMdRGTuxvLalcV = action;
					num = 161343278;
				}
			}
		}
	}

	private InputAction[] LjAdVBpNxoahGYKjuvgQjPMkhIId;

	private ADictionary<string, fBnxGcgrIcOGJSNFGnpUaCDyEhA> wCgqBVmNfLTyOLBOOKHwqnWcLGv;

	private fBnxGcgrIcOGJSNFGnpUaCDyEhA[] wLjFpNKUYbgEYUFvKUNZYWWdCLy;

	private ReadOnlyCollection<InputAction> uyKbGKeXbiGBmuAtOWrRRMHIWKK;

	private int GhwAXNtrjyPGKwZtLHLLSEdpGZi;

	private int euiNPRZOTgbmblxIObmtJbRcbAXc;

	private List<string> GHBdgBczeCChhgPZHMscwsegvOVN;

	private List<int> HVwGpPbuJJcgRCmyhjNgkeUXuYFj;

	public IList<InputAction> Actions
	{
		get
		{
			return uyKbGKeXbiGBmuAtOWrRRMHIWKK;
		}
	}

	public int actionCount
	{
		get
		{
			return GhwAXNtrjyPGKwZtLHLLSEdpGZi;
		}
	}

	public int maxActionId
	{
		get
		{
			return euiNPRZOTgbmblxIObmtJbRcbAXc;
		}
	}

	public ELmeHFhAEObgGMupfccwkercFbWz(List<InputAction> actions)
	{
		int num3 = default(int);
		int num4 = default(int);
		int num2 = default(int);
		int num5 = default(int);
		int id = default(int);
		while (true)
		{
			int num = 2137532201;
			while (true)
			{
				switch (num ^ 0x7F682722)
				{
				case 8:
					break;
				case 1:
					if (num3 >= GhwAXNtrjyPGKwZtLHLLSEdpGZi)
					{
						euiNPRZOTgbmblxIObmtJbRcbAXc = num4;
						wLjFpNKUYbgEYUFvKUNZYWWdCLy = new fBnxGcgrIcOGJSNFGnpUaCDyEhA[num4 + 1];
						num = 2137532192;
						continue;
					}
					goto case 9;
				case 13:
					num2 = 0;
					num = 2137532197;
					continue;
				case 3:
					num3++;
					num = 2137532195;
					continue;
				case 10:
				{
					InputAction inputAction2 = LjAdVBpNxoahGYKjuvgQjPMkhIId[num5];
					wLjFpNKUYbgEYUFvKUNZYWWdCLy[inputAction2.id] = new fBnxGcgrIcOGJSNFGnpUaCDyEhA(inputAction2, num5);
					num5++;
					num = 2137532194;
					continue;
				}
				case 11:
					GHBdgBczeCChhgPZHMscwsegvOVN = new List<string>();
					HVwGpPbuJJcgRCmyhjNgkeUXuYFj = new List<int>();
					LjAdVBpNxoahGYKjuvgQjPMkhIId = actions.ToArray();
					num = 2137532196;
					continue;
				case 12:
					if (id > num4)
					{
						num4 = id;
						num = 2137532193;
						continue;
					}
					goto case 3;
				case 5:
					num = 2137532194;
					continue;
				case 9:
					id = LjAdVBpNxoahGYKjuvgQjPMkhIId[num3].id;
					num = 2137532206;
					continue;
				case 0:
					if (num5 >= GhwAXNtrjyPGKwZtLHLLSEdpGZi)
					{
						wCgqBVmNfLTyOLBOOKHwqnWcLGv = new ADictionary<string, fBnxGcgrIcOGJSNFGnpUaCDyEhA>(GhwAXNtrjyPGKwZtLHLLSEdpGZi, StringComparer.OrdinalIgnoreCase);
						num = 2137532207;
						continue;
					}
					goto case 10;
				case 2:
					num5 = 0;
					num = 2137532199;
					continue;
				case 6:
					GhwAXNtrjyPGKwZtLHLLSEdpGZi = LjAdVBpNxoahGYKjuvgQjPMkhIId.Length;
					num4 = -1;
					num3 = 0;
					num = 2137532195;
					continue;
				default:
				{
					InputAction inputAction = LjAdVBpNxoahGYKjuvgQjPMkhIId[num2];
					try
					{
						wCgqBVmNfLTyOLBOOKHwqnWcLGv.Add(inputAction.name, wLjFpNKUYbgEYUFvKUNZYWWdCLy[inputAction.id]);
					}
					catch
					{
						Logger.LogError("Duplicate Action name \"" + inputAction.name + "\" found in Action list. Duplicate Action names are not allowed. If you have edited the data manually outside the Rewired Input Manager, remove any duplicate Actions.");
					}
					num2++;
					goto case 7;
				}
				case 7:
					if (num2 >= GhwAXNtrjyPGKwZtLHLLSEdpGZi)
					{
						uyKbGKeXbiGBmuAtOWrRRMHIWKK = new ReadOnlyCollection<InputAction>(LjAdVBpNxoahGYKjuvgQjPMkhIId);
						return;
					}
					goto default;
				}
				break;
			}
		}
	}

	public InputAction RrHFFOsApvcmnDwtShMjBoRBEqDs(string P_0, bool P_1 = false)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			return null;
		}
		fBnxGcgrIcOGJSNFGnpUaCDyEhA value;
		if (!wCgqBVmNfLTyOLBOOKHwqnWcLGv.TryGetValue(P_0, out value))
		{
			if (P_1)
			{
				JABosodacZJWTvGEtZYyueAHnoZ(P_0);
			}
			return null;
		}
		return value.LtBAfGkKNqHRqhMdRGTuxvLalcV;
	}

	public InputAction lklRvOtWMNouCgbGRftSXhlYipRk(int P_0)
	{
		if (P_0 < 0)
		{
			return null;
		}
		if (P_0 > euiNPRZOTgbmblxIObmtJbRcbAXc)
		{
			goto IL_000f;
		}
		int num;
		if (wLjFpNKUYbgEYUFvKUNZYWWdCLy[P_0] == null)
		{
			num = 963709073;
			goto IL_0014;
		}
		return wLjFpNKUYbgEYUFvKUNZYWWdCLy[P_0].LtBAfGkKNqHRqhMdRGTuxvLalcV;
		IL_0014:
		switch (num ^ 0x39710893)
		{
		case 0:
			break;
		case 1:
			return null;
		default:
			return null;
		}
		goto IL_000f;
		IL_000f:
		num = 963709074;
		goto IL_0014;
	}

	public InputAction JRzscIiudObMLiNBxkbGXjgrgWu(int P_0)
	{
		if (P_0 < 0 || P_0 >= GhwAXNtrjyPGKwZtLHLLSEdpGZi)
		{
			return null;
		}
		return LjAdVBpNxoahGYKjuvgQjPMkhIId[P_0];
	}

	public int EAgOMouOjbslHCCsyBDLoGVrHcd(string P_0, bool P_1 = false)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			return -1;
		}
		fBnxGcgrIcOGJSNFGnpUaCDyEhA value;
		if (!wCgqBVmNfLTyOLBOOKHwqnWcLGv.TryGetValue(P_0, out value))
		{
			if (P_1)
			{
				JABosodacZJWTvGEtZYyueAHnoZ(P_0);
			}
			return -1;
		}
		return value.LeMumcZIhvowyxwsSoccRnQZCCji;
	}

	public int EAgOMouOjbslHCCsyBDLoGVrHcd(int P_0, bool P_1 = false)
	{
		if (P_0 < 0)
		{
			goto IL_0063;
		}
		if (P_0 > euiNPRZOTgbmblxIObmtJbRcbAXc)
		{
			goto IL_000d;
		}
		fBnxGcgrIcOGJSNFGnpUaCDyEhA fBnxGcgrIcOGJSNFGnpUaCDyEhA2 = wLjFpNKUYbgEYUFvKUNZYWWdCLy[P_0];
		int num;
		if (fBnxGcgrIcOGJSNFGnpUaCDyEhA2 == null)
		{
			if (P_1)
			{
				JABosodacZJWTvGEtZYyueAHnoZ(P_0);
				num = -882447570;
				goto IL_0012;
			}
			goto IL_0078;
		}
		return fBnxGcgrIcOGJSNFGnpUaCDyEhA2.LeMumcZIhvowyxwsSoccRnQZCCji;
		IL_0078:
		return -1;
		IL_000d:
		num = -882447569;
		goto IL_0012;
		IL_0063:
		int num2;
		if (P_0 < 0)
		{
			num = -882447571;
			num2 = num;
		}
		else
		{
			num = -882447572;
			num2 = num;
		}
		goto IL_0012;
		IL_0012:
		while (true)
		{
			switch (num ^ -882447570)
			{
			case 4:
				break;
			case 3:
				return -1;
			case 2:
				if (P_1)
				{
					JABosodacZJWTvGEtZYyueAHnoZ(P_0);
					num = -882447571;
					continue;
				}
				goto case 3;
			case 1:
				goto IL_0063;
			default:
				goto IL_0078;
			}
			break;
		}
		goto IL_000d;
	}

	public bool WfhdeimYiTFGUIbHSjqOJaakYWS(string P_0, bool P_1 = false)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			return false;
		}
		if (!wCgqBVmNfLTyOLBOOKHwqnWcLGv.ContainsKey(P_0))
		{
			while (true)
			{
				int num = 734590281;
				while (true)
				{
					switch (num ^ 0x2BC8F54B)
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
					JABosodacZJWTvGEtZYyueAHnoZ(P_0);
					num = 734590282;
				}
			}
		}
		return true;
	}

	public bool WfhdeimYiTFGUIbHSjqOJaakYWS(int P_0)
	{
		if (P_0 < 0 || P_0 > euiNPRZOTgbmblxIObmtJbRcbAXc)
		{
			return false;
		}
		return wLjFpNKUYbgEYUFvKUNZYWWdCLy[P_0] != null;
	}

	public int OkVwBQxkkfcwcKXrVPmXPjftVOE(string P_0, bool P_1 = false)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			goto IL_0008;
		}
		fBnxGcgrIcOGJSNFGnpUaCDyEhA value;
		int num;
		if (!wCgqBVmNfLTyOLBOOKHwqnWcLGv.TryGetValue(P_0, out value))
		{
			if (P_1)
			{
				JABosodacZJWTvGEtZYyueAHnoZ(P_0);
				num = -1480331539;
				goto IL_000d;
			}
			goto IL_0049;
		}
		return value.fKtuodNzZLrsthNmhfemlCLUaYzG;
		IL_0049:
		return -1;
		IL_000d:
		switch (num ^ -1480331540)
		{
		case 0:
			break;
		case 2:
			return -1;
		default:
			goto IL_0049;
		}
		goto IL_0008;
		IL_0008:
		num = -1480331538;
		goto IL_000d;
	}

	private void JABosodacZJWTvGEtZYyueAHnoZ(string P_0)
	{
		if (GHBdgBczeCChhgPZHMscwsegvOVN.Contains(P_0))
		{
			return;
		}
		while (true)
		{
			GHBdgBczeCChhgPZHMscwsegvOVN.Add(P_0);
			int num = 507609502;
			while (true)
			{
				switch (num ^ 0x1E41819C)
				{
				case 0:
					goto IL_000f;
				case 1:
					break;
				default:
					Logger.LogWarning("The Action \"" + P_0 + "\" does not exist. You can create Actions in the editor.");
					return;
				}
				break;
				IL_000f:
				num = 507609501;
			}
		}
	}

	private void JABosodacZJWTvGEtZYyueAHnoZ(int P_0)
	{
		if (HVwGpPbuJJcgRCmyhjNgkeUXuYFj.Contains(P_0))
		{
			return;
		}
		while (true)
		{
			HVwGpPbuJJcgRCmyhjNgkeUXuYFj.Add(P_0);
			int num = -1489306171;
			while (true)
			{
				switch (num ^ -1489306171)
				{
				case 2:
					num = -1489306170;
					continue;
				default:
					return;
				case 3:
					break;
				case 0:
					Logger.LogWarning("No Action exists for Action Id " + P_0 + ". You can create Actions in the editor.");
					num = -1489306172;
					continue;
				case 1:
					return;
				}
				break;
			}
		}
	}
}
