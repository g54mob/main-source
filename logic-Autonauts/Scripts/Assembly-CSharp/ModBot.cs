using System.Collections.Generic;
using MoonSharp.Interpreter;
using UnityEngine;

[MoonSharpUserData]
public class ModBot
{
	public int SpawnBot(string Name, int HeadLevel = 0, int FrameLevel = 0, int DriveLevel = 0, int HeadVariant = 0, int FrameVariant = 0, int DriveVariant = 0, int PositionX = 0, int PositionY = 0)
	{
		if (!GeneralUtils.m_InGame)
		{
			return -1;
		}
		TileCoord tileCoord = new TileCoord(PositionX, PositionY);
		if (!tileCoord.GetIsValid())
		{
			string descriptionOverride = "Error: ModBot.SpawnBot - Canot spawn bot outside of map limits! (" + PositionX + "," + PositionY + ")";
			ModManager.Instance.SetErrorLua(ModManager.ErrorState.Error_Misc, descriptionOverride);
			return -1;
		}
		Worker component = ObjectTypeList.Instance.CreateObjectFromIdentifier(ObjectType.Worker, tileCoord.ToWorldPositionTileCentered(), Quaternion.identity).GetComponent<Worker>();
		if (HeadLevel == 0)
		{
			component.SetHead(ObjectType.WorkerHeadMk0);
		}
		if (HeadLevel == 1)
		{
			switch (HeadVariant)
			{
			case 0:
				component.SetHead(ObjectType.WorkerHeadMk1);
				break;
			case 1:
				component.SetHead(ObjectType.WorkerHeadMk1Variant1);
				break;
			case 2:
				component.SetHead(ObjectType.WorkerHeadMk1Variant2);
				break;
			case 3:
				component.SetHead(ObjectType.WorkerHeadMk1Variant3);
				break;
			case 4:
				component.SetHead(ObjectType.WorkerHeadMk1Variant4);
				break;
			}
		}
		if (HeadLevel == 2)
		{
			switch (HeadVariant)
			{
			case 0:
				component.SetHead(ObjectType.WorkerHeadMk2);
				break;
			case 1:
				component.SetHead(ObjectType.WorkerHeadMk2Variant1);
				break;
			case 2:
				component.SetHead(ObjectType.WorkerHeadMk2Variant2);
				break;
			case 3:
				component.SetHead(ObjectType.WorkerHeadMk2Variant3);
				break;
			case 4:
				component.SetHead(ObjectType.WorkerHeadMk2Variant4);
				break;
			}
		}
		if (HeadLevel == 3)
		{
			switch (HeadVariant)
			{
			case 0:
				component.SetHead(ObjectType.WorkerHeadMk3);
				break;
			case 1:
				component.SetHead(ObjectType.WorkerHeadMk3Variant1);
				break;
			case 2:
				component.SetHead(ObjectType.WorkerHeadMk3Variant2);
				break;
			case 3:
				component.SetHead(ObjectType.WorkerHeadMk3Variant3);
				break;
			case 4:
				component.SetHead(ObjectType.WorkerHeadMk3Variant4);
				break;
			}
		}
		if (FrameLevel == 0)
		{
			component.SetFrame(ObjectType.WorkerFrameMk0);
		}
		if (FrameLevel == 1)
		{
			switch (FrameVariant)
			{
			case 0:
				component.SetFrame(ObjectType.WorkerFrameMk1);
				break;
			case 1:
				component.SetFrame(ObjectType.WorkerFrameMk1Variant1);
				break;
			case 2:
				component.SetFrame(ObjectType.WorkerFrameMk1Variant2);
				break;
			case 3:
				component.SetFrame(ObjectType.WorkerFrameMk1Variant3);
				break;
			case 4:
				component.SetFrame(ObjectType.WorkerFrameMk1Variant4);
				break;
			}
		}
		if (FrameLevel == 2)
		{
			switch (FrameVariant)
			{
			case 0:
				component.SetFrame(ObjectType.WorkerFrameMk2);
				break;
			case 1:
				component.SetFrame(ObjectType.WorkerFrameMk2Variant1);
				break;
			case 2:
				component.SetFrame(ObjectType.WorkerFrameMk2Variant2);
				break;
			case 3:
				component.SetFrame(ObjectType.WorkerFrameMk2Variant3);
				break;
			case 4:
				component.SetFrame(ObjectType.WorkerFrameMk2Variant4);
				break;
			}
		}
		if (FrameLevel == 3)
		{
			switch (FrameVariant)
			{
			case 0:
				component.SetFrame(ObjectType.WorkerFrameMk3);
				break;
			case 1:
				component.SetFrame(ObjectType.WorkerFrameMk3Variant1);
				break;
			case 2:
				component.SetFrame(ObjectType.WorkerFrameMk3Variant2);
				break;
			case 3:
				component.SetFrame(ObjectType.WorkerFrameMk3Variant3);
				break;
			case 4:
				component.SetFrame(ObjectType.WorkerFrameMk3Variant4);
				break;
			}
		}
		if (DriveLevel == 0)
		{
			component.SetDrive(ObjectType.WorkerDriveMk0);
		}
		if (DriveLevel == 1)
		{
			switch (DriveVariant)
			{
			case 0:
				component.SetDrive(ObjectType.WorkerDriveMk1);
				break;
			case 1:
				component.SetDrive(ObjectType.WorkerDriveMk1Variant1);
				break;
			case 2:
				component.SetDrive(ObjectType.WorkerDriveMk1Variant2);
				break;
			case 3:
				component.SetDrive(ObjectType.WorkerDriveMk1Variant3);
				break;
			case 4:
				component.SetDrive(ObjectType.WorkerDriveMk1Variant4);
				break;
			}
		}
		if (DriveLevel == 2)
		{
			switch (DriveVariant)
			{
			case 0:
				component.SetDrive(ObjectType.WorkerDriveMk2);
				break;
			case 1:
				component.SetDrive(ObjectType.WorkerDriveMk2Variant1);
				break;
			case 2:
				component.SetDrive(ObjectType.WorkerDriveMk2Variant2);
				break;
			case 3:
				component.SetDrive(ObjectType.WorkerDriveMk2Variant3);
				break;
			case 4:
				component.SetDrive(ObjectType.WorkerDriveMk2Variant4);
				break;
			}
		}
		if (DriveLevel == 3)
		{
			switch (DriveVariant)
			{
			case 0:
				component.SetDrive(ObjectType.WorkerDriveMk3);
				break;
			case 1:
				component.SetDrive(ObjectType.WorkerDriveMk3Variant1);
				break;
			case 2:
				component.SetDrive(ObjectType.WorkerDriveMk3Variant2);
				break;
			case 3:
				component.SetDrive(ObjectType.WorkerDriveMk3Variant3);
				break;
			case 4:
				component.SetDrive(ObjectType.WorkerDriveMk3Variant4);
				break;
			}
		}
		component.SetWorkerName(Name);
		component.UpdateModel();
		return component.m_UniqueID;
	}

	public List<string> GetBotGroupNames()
	{
		List<string> list = new List<string>();
		foreach (WorkerGroup group in WorkerGroupManager.Instance.m_Groups)
		{
			list.Add(group.m_Name);
		}
		return list;
	}

	public List<int> GetAllBotUIDs()
	{
		List<int> list = new List<int>();
		Dictionary<BaseClass, int> collection = CollectionManager.Instance.GetCollection("Worker");
		if (collection != null)
		{
			foreach (KeyValuePair<BaseClass, int> item in collection)
			{
				Worker component = item.Key.GetComponent<Worker>();
				list.Add(component.m_UniqueID);
			}
		}
		return list;
	}

	public List<int> GetAllBotIDs()
	{
		return GetAllBotUIDs();
	}

	public List<int> GetAllBotUIDsInGroup(string GroupName)
	{
		List<int> list = new List<int>();
		foreach (WorkerGroup group in WorkerGroupManager.Instance.m_Groups)
		{
			if (!(group.m_Name == GroupName))
			{
				continue;
			}
			foreach (int workerUID in group.m_WorkerUIDs)
			{
				list.Add(workerUID);
			}
		}
		return list;
	}

	public List<int> GetAllBotIDsInGroup(string GroupName)
	{
		return GetAllBotUIDsInGroup(GroupName);
	}

	public void MoveTo(int UID, int x, int y)
	{
		Worker worker = null;
		BaseClass objectFromUniqueID = ObjectTypeList.Instance.GetObjectFromUniqueID(UID);
		if (objectFromUniqueID != null)
		{
			worker = objectFromUniqueID.GetComponent<Worker>();
		}
		if (worker != null && new TileCoord(x, y).GetIsValid() && worker.m_State == Farmer.State.None)
		{
			worker.SendAction(new ActionInfo(ActionType.MoveTo, new TileCoord(x, y)));
		}
	}

	public void SetName(int UID, string NewName)
	{
		Worker worker = null;
		BaseClass objectFromUniqueID = ObjectTypeList.Instance.GetObjectFromUniqueID(UID);
		if (objectFromUniqueID != null)
		{
			worker = objectFromUniqueID.GetComponent<Worker>();
		}
		if (worker != null)
		{
			worker.SetWorkerName(NewName);
		}
	}

	public string GetName(int UID)
	{
		Worker worker = null;
		BaseClass objectFromUniqueID = ObjectTypeList.Instance.GetObjectFromUniqueID(UID);
		if (objectFromUniqueID != null)
		{
			worker = objectFromUniqueID.GetComponent<Worker>();
		}
		if (worker != null)
		{
			return worker.GetWorkerName();
		}
		return "";
	}

	public Table GetAllHeldObjectsUIDs(int UID)
	{
		Worker worker = null;
		BaseClass objectFromUniqueID = ObjectTypeList.Instance.GetObjectFromUniqueID(UID);
		Table table = new Table(ModManager.Instance.GetLastCalledScript());
		if (objectFromUniqueID != null)
		{
			worker = objectFromUniqueID.GetComponent<Worker>();
			if (worker != null)
			{
				foreach (Holdable item in worker.m_FarmerCarry.m_CarryObject)
				{
					if ((bool)item)
					{
						table.Append(DynValue.NewNumber(item.m_UniqueID));
					}
				}
				return table;
			}
		}
		return new Table(ModManager.Instance.GetLastCalledScript(), DynValue.NewNumber(-1.0));
	}

	public string GetState(int UID)
	{
		Worker worker = null;
		BaseClass objectFromUniqueID = ObjectTypeList.Instance.GetObjectFromUniqueID(UID);
		if (objectFromUniqueID != null)
		{
			worker = objectFromUniqueID.GetComponent<Worker>();
			if (worker != null)
			{
				return worker.m_State.ToString();
			}
		}
		return null;
	}

	public Table GetParts(int UID)
	{
		Table table = new Table(ModManager.Instance.GetLastCalledScript());
		Worker worker = null;
		BaseClass objectFromUniqueID = ObjectTypeList.Instance.GetObjectFromUniqueID(UID);
		new Table(ModManager.Instance.GetLastCalledScript());
		if (objectFromUniqueID != null)
		{
			worker = objectFromUniqueID.GetComponent<Worker>();
			if (worker != null)
			{
				table.Append(DynValue.NewString(worker.m_Head.ToString()));
				table.Append(DynValue.NewString(worker.m_Frame.ToString()));
				table.Append(DynValue.NewString(worker.m_Drive.ToString()));
				return table;
			}
		}
		return new Table(ModManager.Instance.GetLastCalledScript(), DynValue.NewNumber(-1.0));
	}
}
