using System;
using System.Collections.Generic;
using Simulator.GameWorld;

namespace Simulator
{
	[Serializable]
	public class Save
	{
		public bool newSave = true;

		public ESaveType saveType;

		public SaveClass_GlobalState globalState = new SaveClass_GlobalState();

		public SaveClass_Shop shop = new SaveClass_Shop();

		public SaveClass_DayScore dayScore = new SaveClass_DayScore();

		public SaveClass_Player player = new SaveClass_Player();

		public SaveClass_Clients clients = new SaveClass_Clients();

		public SaveClass_Furnitures furnitures = new SaveClass_Furnitures();

		public SaveClass_Products products = new SaveClass_Products();

		public SaveClass_Bills bills = new SaveClass_Bills();

		public SaveClass_Tutorial tutorial = new SaveClass_Tutorial();

		public SaveClass_Dirt dirt = new SaveClass_Dirt();

		public SaveClass_GameScore gameScore = new SaveClass_GameScore();

		public virtual void StartFurnitureSaveProcess()
		{
			furnitures.StartSaveProcess();
		}

		public virtual void SaveFurniture(SaveClass_Furnitures.FurnitureState furnitureState)
		{
			if (!(furnitureState is SaveClass_Furnitures.ShelfState state))
			{
				if (!(furnitureState is SaveClass_Furnitures.ReserveShelfState state2))
				{
					if (furnitureState is SaveClass_Furnitures.CashRegisterState state3)
					{
						furnitures.SaveFurniture(state3);
					}
					else
					{
						furnitures.SaveFurniture(furnitureState);
					}
				}
				else
				{
					furnitures.SaveFurniture(state2);
				}
			}
			else
			{
				furnitures.SaveFurniture(state);
			}
		}

		public virtual IEnumerable<SaveClass_Furnitures.FurnitureState> GetSavedFurnitures()
		{
			return furnitures.GetSavedFurnitures();
		}

		public virtual void StartClientSaveProcess()
		{
			clients.StartSaveProcess();
		}

		public virtual void SaveClient(AIClientBehaviour client, ClientCharacter character)
		{
			clients.SaveClient(client, character);
		}

		public virtual IEnumerable<SaveClass_Clients.ClientState> GetClientStates()
		{
			return clients.clients;
		}
	}
}
