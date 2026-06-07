using System.Runtime.CompilerServices;
using Rewired.UI;

internal static class WNotAAISpefDpKyNJdcLcBcbogIZ
{
	private static iqJrXCyBXfdczMYruDynMWmAkyE.EventFunction<IVisibilityChangedHandler, bool> IyNegaGarXbvroLMNgukJrxuvqQ;

	[CompilerGenerated]
	private static iqJrXCyBXfdczMYruDynMWmAkyE.EventFunction<IVisibilityChangedHandler, bool> rZGVFRgQMmptVpKQzBtcADhlKAsu;

	internal static iqJrXCyBXfdczMYruDynMWmAkyE.EventFunction<IVisibilityChangedHandler, bool> visibilityChangedHandlerDelegate
	{
		get
		{
			if (IyNegaGarXbvroLMNgukJrxuvqQ == null)
			{
				IyNegaGarXbvroLMNgukJrxuvqQ = delegate(IVisibilityChangedHandler P_0, bool P_1)
				{
					P_0.OnVisibilityChanged(P_1);
				};
			}
			return IyNegaGarXbvroLMNgukJrxuvqQ;
		}
	}

	[CompilerGenerated]
	private static void ctMgIawQYAlxznViArTHLIyUJxr(IVisibilityChangedHandler P_0, bool P_1)
	{
		P_0.OnVisibilityChanged(P_1);
	}
}
