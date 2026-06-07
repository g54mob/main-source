using System.Runtime.CompilerServices;
using Rewired.UI;

internal static class oVmARCrYiJmfeJzWIcWzIboODXP
{
	private static GQyqfJDHwYrVtpSHvKcqDWlbnVJ.EventFunction<IVisibilityChangedHandler, bool> qcqjwvajOaSOlmLiYDahZEaZnQTI;

	[CompilerGenerated]
	private static GQyqfJDHwYrVtpSHvKcqDWlbnVJ.EventFunction<IVisibilityChangedHandler, bool> PkdHFYJlZLMiTCimwpAnCiFWpZz;

	internal static GQyqfJDHwYrVtpSHvKcqDWlbnVJ.EventFunction<IVisibilityChangedHandler, bool> visibilityChangedHandlerDelegate
	{
		get
		{
			if (qcqjwvajOaSOlmLiYDahZEaZnQTI == null)
			{
				while (true)
				{
					int num = 1976753475;
					while (true)
					{
						switch (num ^ 0x75D2DD47)
						{
						case 0:
							break;
						case 1:
							qcqjwvajOaSOlmLiYDahZEaZnQTI = PkdHFYJlZLMiTCimwpAnCiFWpZz;
							num = 1976753477;
							continue;
						case 3:
							PkdHFYJlZLMiTCimwpAnCiFWpZz = delegate(IVisibilityChangedHandler P_0, bool P_1)
							{
								P_0.OnVisibilityChanged(P_1);
							};
							num = 1976753478;
							continue;
						case 4:
							goto IL_0056;
						default:
							goto end_IL_0007;
						}
						break;
						IL_0056:
						int num2;
						if (PkdHFYJlZLMiTCimwpAnCiFWpZz == null)
						{
							num = 1976753476;
							num2 = num;
						}
						else
						{
							num = 1976753478;
							num2 = num;
						}
					}
					continue;
					end_IL_0007:
					break;
				}
			}
			return qcqjwvajOaSOlmLiYDahZEaZnQTI;
		}
	}

	[CompilerGenerated]
	private static void CrlYwzPkrnSlnEiMBkTGGazfUSw(IVisibilityChangedHandler P_0, bool P_1)
	{
		P_0.OnVisibilityChanged(P_1);
	}
}
