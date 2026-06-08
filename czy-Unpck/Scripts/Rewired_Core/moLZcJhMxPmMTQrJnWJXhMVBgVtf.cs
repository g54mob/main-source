using System.Runtime.CompilerServices;
using Rewired.UI;

internal static class moLZcJhMxPmMTQrJnWJXhMVBgVtf
{
	private static SPqVgBBxXOfLJqOnULlpqjJsHJf.EventFunction<IVisibilityChangedHandler, bool> sXaOzVtrqoeNjAYIzLEgtYXIIFp;

	[CompilerGenerated]
	private static SPqVgBBxXOfLJqOnULlpqjJsHJf.EventFunction<IVisibilityChangedHandler, bool> TblfxMGFSPowbRLCNkMeDtWBtrTm;

	internal static SPqVgBBxXOfLJqOnULlpqjJsHJf.EventFunction<IVisibilityChangedHandler, bool> visibilityChangedHandlerDelegate
	{
		get
		{
			if (sXaOzVtrqoeNjAYIzLEgtYXIIFp == null)
			{
				if (TblfxMGFSPowbRLCNkMeDtWBtrTm == null)
				{
					goto IL_000e;
				}
				goto IL_0048;
			}
			goto IL_0059;
			IL_0048:
			sXaOzVtrqoeNjAYIzLEgtYXIIFp = TblfxMGFSPowbRLCNkMeDtWBtrTm;
			int num = 239627658;
			goto IL_0013;
			IL_000e:
			num = 239627657;
			goto IL_0013;
			IL_0013:
			while (true)
			{
				switch (num ^ 0xE486D8B)
				{
				case 0:
					break;
				case 2:
					TblfxMGFSPowbRLCNkMeDtWBtrTm = delegate(IVisibilityChangedHandler P_0, bool P_1)
					{
						P_0.OnVisibilityChanged(P_1);
					};
					num = 239627656;
					continue;
				case 3:
					goto IL_0048;
				default:
					goto IL_0059;
				}
				break;
			}
			goto IL_000e;
			IL_0059:
			return sXaOzVtrqoeNjAYIzLEgtYXIIFp;
		}
	}

	[CompilerGenerated]
	private static void EUfOcfLiQtgsNEDiqHuHnrZaKGWu(IVisibilityChangedHandler P_0, bool P_1)
	{
		P_0.OnVisibilityChanged(P_1);
	}
}
