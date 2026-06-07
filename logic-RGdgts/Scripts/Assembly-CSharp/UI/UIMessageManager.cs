using UI.Utilities;

namespace UI
{
	public class UIMessageManager : MonoSingleton<UIMessageManager>, ILogOrigin
	{
		public UIErrorBar errorBar;

		private MiniTool minitool;

		public void Init()
		{
		}

		public void GiveErrorMessage(bool minitool, bool uiBar, ErrorMessageParameters minitoolPar = null, ErrorMessageParameters barPar = null)
		{
		}

		public void GiveMessageBar(ErrorMessageParameters par)
		{
		}

		public void GiveMessageMinitool(ErrorMessageParameters par)
		{
		}

		public void CleanMinitool()
		{
		}

		public void CleanBar()
		{
		}
	}
}
