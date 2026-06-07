using MoonSharp.Interpreter;

[MoonSharpUserData]
public class ModPlayer
{
	public void MoveTo(int x, int y)
	{
		FarmerPlayer component = CollectionManager.Instance.GetPlayers()[0].GetComponent<FarmerPlayer>();
		if (new TileCoord(x, y).GetIsValid() && component.m_State == Farmer.State.None)
		{
			component.SendAction(new ActionInfo(ActionType.MoveTo, new TileCoord(x, y)));
		}
	}

	public bool IsMoving()
	{
		if (CollectionManager.Instance.GetPlayers()[0].GetComponent<FarmerPlayer>().m_State == Farmer.State.None)
		{
			return false;
		}
		return true;
	}

	public void SetStartLocation(int StartX, int StartY)
	{
		if (ModManager.Instance.m_GameOptionsRef != null)
		{
			if (StartX >= 0 && StartY >= 0 && StartX < ModManager.Instance.m_GameOptionsRef.m_MapWidth && StartY < ModManager.Instance.m_GameOptionsRef.m_MapHeight)
			{
				TileCoord playerPosition = new TileCoord(StartX, StartY);
				if ((bool)GameOptionsManager.Instance)
				{
					GameOptionsManager.Instance.m_Options.SetPlayerPosition(playerPosition);
				}
			}
		}
		else if (StartX >= 0 && StartY >= 0 && StartX < TileManager.Instance.m_TilesWide && StartY < TileManager.Instance.m_TilesHigh)
		{
			TileCoord playerPosition2 = new TileCoord(StartX, StartY);
			if ((bool)GameOptionsManager.Instance)
			{
				GameOptionsManager.Instance.m_Options.SetPlayerPosition(playerPosition2);
			}
		}
	}

	public void SetPlayerStartLocation(int StartX, int StartY)
	{
		SetStartLocation(StartX, StartY);
	}

	public Table GetLocation()
	{
		FarmerPlayer component = CollectionManager.Instance.GetPlayers()[0].GetComponent<FarmerPlayer>();
		TileCoord tileCoord = new TileCoord(component.transform.localPosition);
		return new Table(ModManager.Instance.GetLastCalledScript(), DynValue.NewNumber(tileCoord.x), DynValue.NewNumber(tileCoord.y));
	}

	public Table GetPlayerLocation()
	{
		return GetLocation();
	}

	public int GetHeldObjectUID()
	{
		return CollectionManager.Instance.GetPlayers()[0].GetComponent<FarmerPlayer>().m_FarmerCarry.GetTopObject().m_UniqueID;
	}

	public int GetPlayerHeldObjectUID()
	{
		return GetHeldObjectUID();
	}

	public int GetPlayerHeldObjectID()
	{
		return GetHeldObjectUID();
	}

	public Table GetAllHeldObjectsUIDs()
	{
		FarmerPlayer component = CollectionManager.Instance.GetPlayers()[0].GetComponent<FarmerPlayer>();
		Table table = new Table(ModManager.Instance.GetLastCalledScript());
		if (component.m_FarmerCarry.m_CarryObject.Count > 0)
		{
			foreach (Holdable item in component.m_FarmerCarry.m_CarryObject)
			{
				if ((bool)item)
				{
					table.Append(DynValue.NewNumber(item.m_UniqueID));
				}
			}
			return table;
		}
		return new Table(ModManager.Instance.GetLastCalledScript(), DynValue.NewNumber(-1.0));
	}

	public Table GetAllPlayerHeldObjectsUIDs()
	{
		return GetAllHeldObjectsUIDs();
	}

	public string GetHeldObjectType()
	{
		ObjectType typeIdentifier = CollectionManager.Instance.GetPlayers()[0].GetComponent<FarmerPlayer>().m_FarmerCarry.GetTopObject().m_TypeIdentifier;
		if (typeIdentifier >= ObjectType.Total)
		{
			return ModManager.Instance.m_ModStrings[typeIdentifier];
		}
		return typeIdentifier.ToString();
	}

	public string GetPlayerHeldObjectType()
	{
		return GetHeldObjectType();
	}

	public string GetState()
	{
		return CollectionManager.Instance.GetPlayers()[0].GetComponent<FarmerPlayer>().m_State.ToString();
	}

	public string GetPlayerState()
	{
		return GetState();
	}

	public int GetUID()
	{
		return CollectionManager.Instance.GetPlayers()[0].GetComponent<FarmerPlayer>().m_UniqueID;
	}
}
