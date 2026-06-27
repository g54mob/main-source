using System;
using PixelCrushers.DialogueSystem;
using Zenject;

namespace Restory.Gameplay.Internet
{
	public class InternetConnectionLuaWrapper : IInitializable, IDisposable
	{
		private static class LuaNames
		{
			public static readonly string SetUpInternetConnection = "Internet_FirstTimeSetup";
		}

		private InternetStatusService internetStatusService;

		public InternetConnectionLuaWrapper(InternetStatusService internetStatusService)
		{
			this.internetStatusService = internetStatusService;
		}

		public void Initialize()
		{
			Subscribe();
		}

		public void Dispose()
		{
			Unsubscribe();
		}

		private void Subscribe()
		{
			Lua.RegisterFunction(LuaNames.SetUpInternetConnection, this, SymbolExtensions.GetMethodInfo(() => SetUpInternetConnection(0f)));
		}

		private void Unsubscribe()
		{
			Lua.UnregisterFunction(LuaNames.SetUpInternetConnection);
		}

		private void SetUpInternetConnection(float connectionOptionIndex)
		{
			internetStatusService.IsInternetOn = true;
		}
	}
}
