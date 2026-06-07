using System;
using System.Collections.Generic;
using Simulator;
using Simulator.GameWorld;
using Tabletop.GameWorld;

namespace Tabletop
{
	[Serializable]
	public class TabletopSave : Save
	{
		public SaveClass_Collection collection = new SaveClass_Collection();

		public SaveClass_TabletopDayScore tabletopDayScore = new SaveClass_TabletopDayScore();

		public SaveClass_TabletopFurnitures tabletopFurnitures = new SaveClass_TabletopFurnitures();

		public SaveClass_TabletopClients tabletopClients = new SaveClass_TabletopClients();

		public SaveClass_MiniatureProducts miniatureProducts = new SaveClass_MiniatureProducts();

		public SaveClass_TabletopGameScore tabletopGameScore = new SaveClass_TabletopGameScore();

		public override void StartFurnitureSaveProcess()
		{
			base.StartFurnitureSaveProcess();
			tabletopFurnitures.StartSaveProcess();
		}

		public override void SaveFurniture(SaveClass_Furnitures.FurnitureState furnitureState)
		{
			if (furnitureState is SaveClass_TabletopFurnitures.StallState state)
			{
				tabletopFurnitures.SaveFurniture(state);
			}
			else
			{
				base.SaveFurniture(furnitureState);
			}
		}

		public override IEnumerable<SaveClass_Furnitures.FurnitureState> GetSavedFurnitures()
		{
			foreach (SaveClass_Furnitures.FurnitureState savedFurniture in base.GetSavedFurnitures())
			{
				yield return savedFurniture;
			}
			foreach (SaveClass_Furnitures.FurnitureState savedFurniture2 in tabletopFurnitures.GetSavedFurnitures())
			{
				yield return savedFurniture2;
			}
		}

		public override void StartClientSaveProcess()
		{
			tabletopClients.StartSaveProcess();
		}

		public override void SaveClient(AIClientBehaviour client, ClientCharacter character)
		{
			tabletopClients.SaveClient(client as TabletopClientBehaviour, character);
		}

		public override IEnumerable<SaveClass_Clients.ClientState> GetClientStates()
		{
			return tabletopClients.clients;
		}
	}
}
