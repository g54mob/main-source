using System;
using System.ComponentModel;
using Cysharp.Threading.Tasks;

public static class Database
{
	public static DatabaseState State;

	public static DatabaseModifiers Modifiers;

	public static DatabaseRewards Rewards;

	public static DatabaseDerived Derived;

	public static DatabaseCommands Commands;

	public static DatabaseVariables Variables;

	public static bool Disposed = true;

	public static int Profile { get; private set; }

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static void Save()
	{
		SaveSystem.SaveProfileAsync(Profile, DatabaseSaveDtoMapper.SaveMetaState(), DatabaseSaveDtoMapper.SaveGameState(), DatabaseSaveDtoMapper.SaveGlobalState()).Forget();
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static void SaveGlobal()
	{
		SaveSystem.SaveGlobalAsync(Profile, DatabaseSaveDtoMapper.SaveGlobalState()).Forget();
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static void Load(int profile)
	{
		try
		{
			Profile = profile;
			StateFileDto data = SaveSystem.LoadState(profile);
			GlobalFileDto global = (SaveSystem.HasGlobal() ? SaveSystem.LoadGlobal() : null);
			SetRuntimeState(DatabaseLoadDtoMapper.LoadGameState(data, global));
			ApplicationController.LoadGame();
		}
		catch (Exception e)
		{
			ApplicationController.CorruptedProfile(e);
		}
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public static void Load(int profile, string studio, bool tutorial)
	{
		try
		{
			Profile = profile;
			GlobalFileDto global = (SaveSystem.HasGlobal() ? SaveSystem.LoadGlobal() : null);
			SetRuntimeState(DatabaseLoadDtoMapper.LoadGameState(null, global));
			State.Studio.Name.Value = studio;
			State.Studio.Tutorial.Value = tutorial;
			ApplicationController.LoadGame();
		}
		catch (Exception e)
		{
			ApplicationController.CorruptedProfile(e);
		}
	}

	private static void SetRuntimeState(DatabaseState state)
	{
		State = state;
		Modifiers = new DatabaseModifiers();
		Rewards = new DatabaseRewards();
		Derived = new DatabaseDerived(State, Modifiers);
		Variables = new DatabaseVariables(State, Derived, Modifiers);
		Commands = new DatabaseCommands(State);
		Disposed = false;
	}

	public static void Dispose()
	{
		State?.Dispose();
		State = null;
		Modifiers?.Dispose();
		Modifiers = null;
		Rewards?.Dispose();
		Rewards = null;
		Derived?.Dispose();
		Derived = null;
		Variables?.Dispose();
		Variables = null;
		Commands?.Dispose();
		Commands = null;
		Disposed = true;
	}
}
