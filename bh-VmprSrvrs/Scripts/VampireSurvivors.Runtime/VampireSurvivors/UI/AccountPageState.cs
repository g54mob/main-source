using System.Collections.Generic;

namespace VampireSurvivors.UI
{
	public class AccountPageState
	{
		private LoginType loginState;

		private LinkedList<UIState> stateHistory;

		private Dictionary<string, bool> flags;

		public LoginType LoginState => default(LoginType);

		public void SetFlag(string key, bool value)
		{
		}

		public bool GetFlag(string key)
		{
			return false;
		}

		public UIState GetState()
		{
			return default(UIState);
		}

		public void ClearHistory()
		{
		}

		public void ChangeStateTo(UIState uiState)
		{
		}

		public bool CanGoBack()
		{
			return false;
		}

		public void GoBack()
		{
		}

		public void GoHome()
		{
		}

		public void SetLoginState(LoginType newState)
		{
		}

		private string StringifyHistory()
		{
			return null;
		}
	}
}
