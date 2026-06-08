using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired;
using Rewired.Utils.Classes.Data;

internal class GzivFFngdYeSyLbVIOLpLzJrrzu
{
	private class hmnYtfizGJgSplcCMzNxZOiBEiH
	{
		public readonly InputAction XsRJBSsHkkEbAksXmqgdGffpEipF;

		public readonly int tvvERjRcrFQoLeSRWZgxEcxZOWL;

		public readonly int XdWOywJJEvSoWoTAzVhrumeCSnD;

		public hmnYtfizGJgSplcCMzNxZOiBEiH(InputAction action, int arrayIndex)
		{
			XsRJBSsHkkEbAksXmqgdGffpEipF = action;
			tvvERjRcrFQoLeSRWZgxEcxZOWL = action.id;
			XdWOywJJEvSoWoTAzVhrumeCSnD = arrayIndex;
		}
	}

	private InputAction[] FYKJrTvnCgBwwLFHDjPHOmwfNYa;

	private ADictionary<string, hmnYtfizGJgSplcCMzNxZOiBEiH> kZavXLuQODQleCwubsLzJvgdWxB;

	private hmnYtfizGJgSplcCMzNxZOiBEiH[] eqdndTIqvnyIgVxPfKrWhpysPQC;

	private ReadOnlyCollection<InputAction> gFWGBYcmymdeMDlZhftOAkliBYEi;

	private int CyoRyXlqCsJjuzDLwUsWblZgLNC;

	private int mqarxJFSqgYdVwRgpRacmmpfWLf;

	private List<string> IXAuFzdVABoFIYthPvbLUYmOIj;

	private List<int> JrmZXUcgxJGbqfYiUoDhDoIdIiv;

	public IList<InputAction> Actions => gFWGBYcmymdeMDlZhftOAkliBYEi;

	public int actionCount => CyoRyXlqCsJjuzDLwUsWblZgLNC;

	public int maxActionId => mqarxJFSqgYdVwRgpRacmmpfWLf;

	public GzivFFngdYeSyLbVIOLpLzJrrzu(List<InputAction> actions)
	{
		IXAuFzdVABoFIYthPvbLUYmOIj = new List<string>();
		JrmZXUcgxJGbqfYiUoDhDoIdIiv = new List<int>();
		FYKJrTvnCgBwwLFHDjPHOmwfNYa = actions.ToArray();
		CyoRyXlqCsJjuzDLwUsWblZgLNC = FYKJrTvnCgBwwLFHDjPHOmwfNYa.Length;
		int num = -1;
		for (int i = 0; i < CyoRyXlqCsJjuzDLwUsWblZgLNC; i++)
		{
			int id = FYKJrTvnCgBwwLFHDjPHOmwfNYa[i].id;
			if (id > num)
			{
				num = id;
			}
		}
		mqarxJFSqgYdVwRgpRacmmpfWLf = num;
		eqdndTIqvnyIgVxPfKrWhpysPQC = new hmnYtfizGJgSplcCMzNxZOiBEiH[num + 1];
		for (int j = 0; j < CyoRyXlqCsJjuzDLwUsWblZgLNC; j++)
		{
			InputAction inputAction = FYKJrTvnCgBwwLFHDjPHOmwfNYa[j];
			eqdndTIqvnyIgVxPfKrWhpysPQC[inputAction.id] = new hmnYtfizGJgSplcCMzNxZOiBEiH(inputAction, j);
		}
		kZavXLuQODQleCwubsLzJvgdWxB = new ADictionary<string, hmnYtfizGJgSplcCMzNxZOiBEiH>(CyoRyXlqCsJjuzDLwUsWblZgLNC, StringComparer.OrdinalIgnoreCase);
		for (int k = 0; k < CyoRyXlqCsJjuzDLwUsWblZgLNC; k++)
		{
			InputAction inputAction2 = FYKJrTvnCgBwwLFHDjPHOmwfNYa[k];
			try
			{
				kZavXLuQODQleCwubsLzJvgdWxB.Add(inputAction2.name, eqdndTIqvnyIgVxPfKrWhpysPQC[inputAction2.id]);
			}
			catch
			{
				Logger.LogError("Duplicate Action name \"" + inputAction2.name + "\" found in Action list. Duplicate Action names are not allowed. If you have edited the data manually outside the Rewired Input Manager, remove any duplicate Actions.");
			}
		}
		gFWGBYcmymdeMDlZhftOAkliBYEi = new ReadOnlyCollection<InputAction>(FYKJrTvnCgBwwLFHDjPHOmwfNYa);
	}

	public InputAction HPBabWgYCxuQFtaZlVdaNBbUOip(string P_0, bool P_1 = false)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			return null;
		}
		if (!kZavXLuQODQleCwubsLzJvgdWxB.TryGetValue(P_0, out var value))
		{
			if (P_1)
			{
				ZGLfOwJlDLIltdiybIupfDCOOzzY(P_0);
			}
			return null;
		}
		return value.XsRJBSsHkkEbAksXmqgdGffpEipF;
	}

	public InputAction lwbVaAtXlFYOutHegWQNuVVFpCl(int P_0)
	{
		if (P_0 < 0)
		{
			return null;
		}
		if (P_0 > mqarxJFSqgYdVwRgpRacmmpfWLf)
		{
			return null;
		}
		if (eqdndTIqvnyIgVxPfKrWhpysPQC[P_0] == null)
		{
			return null;
		}
		return eqdndTIqvnyIgVxPfKrWhpysPQC[P_0].XsRJBSsHkkEbAksXmqgdGffpEipF;
	}

	public InputAction VMlKZYsEyUgtddhSCWgBqIUwGOE(int P_0)
	{
		if (P_0 >= 0)
		{
			while (true)
			{
				int num = 155950135;
				while (true)
				{
					switch (num ^ 0x94B9C35)
					{
					case 0:
						break;
					case 2:
						goto IL_0022;
					default:
						goto end_IL_0004;
					}
					break;
					IL_0022:
					if (P_0 >= CyoRyXlqCsJjuzDLwUsWblZgLNC)
					{
						num = 155950132;
						continue;
					}
					return FYKJrTvnCgBwwLFHDjPHOmwfNYa[P_0];
				}
				continue;
				end_IL_0004:
				break;
			}
		}
		return null;
	}

	public int KhufsiHazfkStoHkXbcGhTzBsNFW(string P_0, bool P_1 = false)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			return -1;
		}
		if (!kZavXLuQODQleCwubsLzJvgdWxB.TryGetValue(P_0, out var value))
		{
			if (P_1)
			{
				ZGLfOwJlDLIltdiybIupfDCOOzzY(P_0);
			}
			return -1;
		}
		return value.XdWOywJJEvSoWoTAzVhrumeCSnD;
	}

	public int KhufsiHazfkStoHkXbcGhTzBsNFW(int P_0, bool P_1 = false)
	{
		if (P_0 >= 0)
		{
			goto IL_0004;
		}
		goto IL_003a;
		IL_0004:
		int num = 1910646605;
		goto IL_0009;
		IL_0009:
		while (true)
		{
			switch (num ^ 0x71E2274E)
			{
			case 0:
				break;
			case 3:
				goto IL_002a;
			case 4:
				goto IL_003a;
			case 2:
				goto IL_004f;
			default:
				goto IL_006e;
			}
			break;
			IL_002a:
			if (P_0 > mqarxJFSqgYdVwRgpRacmmpfWLf)
			{
				num = 1910646602;
				continue;
			}
			hmnYtfizGJgSplcCMzNxZOiBEiH hmnYtfizGJgSplcCMzNxZOiBEiH2 = eqdndTIqvnyIgVxPfKrWhpysPQC[P_0];
			if (hmnYtfizGJgSplcCMzNxZOiBEiH2 == null)
			{
				if (P_1)
				{
					ZGLfOwJlDLIltdiybIupfDCOOzzY(P_0);
					num = 1910646607;
					continue;
				}
				goto IL_006e;
			}
			return hmnYtfizGJgSplcCMzNxZOiBEiH2.XdWOywJJEvSoWoTAzVhrumeCSnD;
			IL_006e:
			return -1;
		}
		goto IL_0004;
		IL_003a:
		if (P_0 >= 0 && P_1)
		{
			ZGLfOwJlDLIltdiybIupfDCOOzzY(P_0);
			num = 1910646604;
			goto IL_0009;
		}
		goto IL_004f;
		IL_004f:
		return -1;
	}

	public bool QUzJIwsyLBGiiDjdziRDeDUvrEq(string P_0, bool P_1 = false)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			return false;
		}
		if (!kZavXLuQODQleCwubsLzJvgdWxB.ContainsKey(P_0))
		{
			if (P_1)
			{
				ZGLfOwJlDLIltdiybIupfDCOOzzY(P_0);
			}
			return false;
		}
		return true;
	}

	public bool QUzJIwsyLBGiiDjdziRDeDUvrEq(int P_0)
	{
		if (P_0 >= 0)
		{
			while (true)
			{
				int num = 1550592030;
				while (true)
				{
					switch (num ^ 0x5C6C281F)
					{
					case 2:
						break;
					case 1:
						goto IL_0022;
					default:
						goto end_IL_0004;
					}
					break;
					IL_0022:
					if (P_0 > mqarxJFSqgYdVwRgpRacmmpfWLf)
					{
						num = 1550592031;
						continue;
					}
					return eqdndTIqvnyIgVxPfKrWhpysPQC[P_0] != null;
				}
				continue;
				end_IL_0004:
				break;
			}
		}
		return false;
	}

	public int QRDvUGxTmzMESLVLwskMiVyiVse(string P_0, bool P_1 = false)
	{
		if (string.IsNullOrEmpty(P_0))
		{
			return -1;
		}
		if (!kZavXLuQODQleCwubsLzJvgdWxB.TryGetValue(P_0, out var value))
		{
			while (true)
			{
				int num = 988098711;
				while (true)
				{
					switch (num ^ 0x3AE53095)
					{
					case 0:
						break;
					case 2:
						if (P_1)
						{
							goto IL_003b;
						}
						goto default;
					default:
						return -1;
					}
					break;
					IL_003b:
					ZGLfOwJlDLIltdiybIupfDCOOzzY(P_0);
					num = 988098708;
				}
			}
		}
		return value.tvvERjRcrFQoLeSRWZgxEcxZOWL;
	}

	private void ZGLfOwJlDLIltdiybIupfDCOOzzY(string P_0)
	{
		if (IXAuFzdVABoFIYthPvbLUYmOIj.Contains(P_0))
		{
			while (true)
			{
				switch (-442938290 ^ -442938289)
				{
				case 2:
					continue;
				case 1:
					return;
				}
				break;
			}
		}
		IXAuFzdVABoFIYthPvbLUYmOIj.Add(P_0);
		Logger.LogWarning("The Action \"" + P_0 + "\" does not exist. You can create Actions in the editor.");
	}

	private void ZGLfOwJlDLIltdiybIupfDCOOzzY(int P_0)
	{
		if (JrmZXUcgxJGbqfYiUoDhDoIdIiv.Contains(P_0))
		{
			while (true)
			{
				switch (0x1A4A195D ^ 0x1A4A195F)
				{
				case 0:
					continue;
				case 2:
					return;
				}
				break;
			}
		}
		JrmZXUcgxJGbqfYiUoDhDoIdIiv.Add(P_0);
		Logger.LogWarning("No Action exists for Action Id " + P_0 + ". You can create Actions in the editor.");
	}
}
