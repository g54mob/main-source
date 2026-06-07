using System;
using System.Collections;
using System.Collections.Generic;

public class GameItemManager : Singleton<GameItemManager>
{
	private readonly Dictionary<Type, IList> _itemsByType;

	public void RegisterGameItem<T>(T gameItem) where T : class
	{
	}

	public void UnregisterGameItem<T>(T gameItem) where T : class
	{
	}

	public int GetGameItemCount<T>() where T : class
	{
		return 0;
	}

	public IReadOnlyList<T> GetAllGameItem<T>() where T : class
	{
		return null;
	}
}
