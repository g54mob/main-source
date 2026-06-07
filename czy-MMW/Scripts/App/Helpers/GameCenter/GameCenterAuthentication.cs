using System;
using System.Runtime.InteropServices;
using AOT;
using Factory;

namespace Helpers.GameCenter
{
	public class GameCenterAuthentication : IGameCenterAuthentication, IReleasedFromScopeHandler
	{
		private enum GameCenterAuthState
		{
			NotAuthenticated = 0,
			Authenticated = 1,
			RequiresRetry = 2
		}

		private static readonly Diagnostics.Log.Channel ObjectiveCLog = Diagnostics.Log.OpenChannel("Objective-C-GameCenter");

		[Dependency]
		private IScope _scope;

		private static IInputState InputState;

		private static bool _requiresRetry = false;

		public bool IsAuthenticated => GameCenterShared.GCIsAuthenticated();

		public bool RequiresRetry => _requiresRetry;

		public void Authenticate()
		{
			InputState = _scope.Get<IInputState>();
			IntPtr functionPointerForDelegate = Marshal.GetFunctionPointerForDelegate<GameCenterShared.LogDelegate>(OnLog);
			IntPtr functionPointerForDelegate2 = Marshal.GetFunctionPointerForDelegate<GameCenterShared.GameCenterFocusChangedDelegate>(OnGameCenterFocusChanged);
			IntPtr functionPointerForDelegate3 = Marshal.GetFunctionPointerForDelegate<GameCenterShared.GameCenterAuthAttemptedDelegate>(OnGameCenterAuthAttempted);
			GameCenterShared.GCStart(functionPointerForDelegate, functionPointerForDelegate2, functionPointerForDelegate3);
		}

		public void OnReleasedFromScope(IScope scope)
		{
			throw new NotImplementedException();
		}

		[MonoPInvokeCallback(typeof(GameCenterShared.LogDelegate))]
		private static void OnLog(string logMessage)
		{
			ObjectiveCLog.Info(logMessage);
		}

		[MonoPInvokeCallback(typeof(GameCenterShared.GameCenterFocusChangedDelegate))]
		private static void OnGameCenterFocusChanged(bool gameCenterHasFocus)
		{
			InputState?.OnInternalFocusChanged(!gameCenterHasFocus);
		}

		[MonoPInvokeCallback(typeof(GameCenterShared.GameCenterAuthAttemptedDelegate))]
		private static void OnGameCenterAuthAttempted(int result)
		{
			ObjectiveCLog.Info($"OnGameCenterAuthAttempted(result:{result})");
			if (result == 2)
			{
				_requiresRetry = true;
			}
		}
	}
}
