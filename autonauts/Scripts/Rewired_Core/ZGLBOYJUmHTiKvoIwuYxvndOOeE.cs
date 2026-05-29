using System.Runtime.CompilerServices;
using Rewired.UI;

internal static class ZGLBOYJUmHTiKvoIwuYxvndOOeE
{
	private static huuGkElBkGQiMROGJhgcoZddnWS.EventFunction<IVisibilityChangedHandler, bool> LfeZbkVdKuMhKlRvuekrzLeDfDW;

	[CompilerGenerated]
	private static huuGkElBkGQiMROGJhgcoZddnWS.EventFunction<IVisibilityChangedHandler, bool> autMBJdbnRzwuaphYbdbvPoQqzm;

	internal static huuGkElBkGQiMROGJhgcoZddnWS.EventFunction<IVisibilityChangedHandler, bool> visibilityChangedHandlerDelegate
	{
		get
		{
			if (LfeZbkVdKuMhKlRvuekrzLeDfDW == null)
			{
				if (autMBJdbnRzwuaphYbdbvPoQqzm == null)
				{
					autMBJdbnRzwuaphYbdbvPoQqzm = delegate(IVisibilityChangedHandler P_0, bool P_1)
					{
						P_0.OnVisibilityChanged(P_1);
					};
					goto IL_001f;
				}
				goto IL_003d;
			}
			goto IL_004e;
			IL_003d:
			LfeZbkVdKuMhKlRvuekrzLeDfDW = autMBJdbnRzwuaphYbdbvPoQqzm;
			int num = 818056015;
			goto IL_0024;
			IL_004e:
			return LfeZbkVdKuMhKlRvuekrzLeDfDW;
			IL_001f:
			num = 818056014;
			goto IL_0024;
			IL_0024:
			switch (num ^ 0x30C28B4F)
			{
			case 2:
				break;
			case 1:
				goto IL_003d;
			default:
				goto IL_004e;
			}
			goto IL_001f;
		}
	}

	[CompilerGenerated]
	private static void rqbLvaxcdpJjWcnXbCNAClbxHRlp(IVisibilityChangedHandler P_0, bool P_1)
	{
		P_0.OnVisibilityChanged(P_1);
	}
}
