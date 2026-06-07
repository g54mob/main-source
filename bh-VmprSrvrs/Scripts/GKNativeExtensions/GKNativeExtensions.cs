using System;
using AOT;

public class GKNativeExtensions
{
	private static bool isInited;

	private static bool isRunningFetchGames;

	private static bool isRunningDeleteGame;

	private static bool isRunningSaveGame;

	private static bool isRunningLoadGame;

	private static bool isRunningResolveConflicts;

	private static Action<SavedGameDataGameCenter[]> fetchGamesCallback;

	private static Action<SavedGameDataGameCenter[]> conflictCallback;

	private static Action<SavedGameDataGameCenter> saveCallback;

	private static Action<SavedGameDataGameCenter> modifiedCallback;

	private static Action<bool> deleteCallback;

	private static Action<bool> resolveConflictCallback;

	private static Action<byte[]> loadCallback;

	[MonoPInvokeCallback(typeof(savedGamesCallbackDelegate))]
	private static void fetchSavesCompleteCalled(IntPtr games, uint length)
	{
	}

	[MonoPInvokeCallback(typeof(savedGamesCallbackDelegate))]
	private static void conflictCallbackCalled(IntPtr games, uint length)
	{
	}

	[MonoPInvokeCallback(typeof(boolCallbackDelegate))]
	private static void resolveConflictCallbackCalled(bool success)
	{
	}

	[MonoPInvokeCallback(typeof(savedGameCallbackDelegate))]
	private static void modifiedCallbackCalled(IntPtr savePtr)
	{
	}

	[MonoPInvokeCallback(typeof(savedGameCallbackDelegate))]
	private static void saveCompleteCalled(IntPtr savePtr)
	{
	}

	[MonoPInvokeCallback(typeof(boolCallbackDelegate))]
	private static void deleteCompleteCalled(bool success)
	{
	}

	[MonoPInvokeCallback(typeof(byteArrayPtrCallbackDelegate))]
	private static void loadCompleteCalled(IntPtr dataPtr, int length)
	{
	}

	public static void GKInit(Action<SavedGameDataGameCenter[]> conflictCallback, Action<SavedGameDataGameCenter> modifiedCallback)
	{
	}

	public static void GKFetchSavedGames(Action<SavedGameDataGameCenter[]> callback)
	{
	}

	public static void GKResolveConflicts(SavedGameDataGameCenter[] sgData, byte[] saveArray, Action<bool> callback)
	{
	}

	public static void GKDeleteGame(string savedGame, Action<bool> callback)
	{
	}

	public static void GKSaveGame(byte[] data, string savedGameName, Action<SavedGameDataGameCenter> callback)
	{
	}

	public static void GKLoadGame(SavedGameDataGameCenter savedGame, Action<byte[]> savedDataCallback)
	{
	}
}
