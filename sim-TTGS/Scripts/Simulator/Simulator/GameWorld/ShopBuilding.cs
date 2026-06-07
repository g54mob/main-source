using System.Collections.Generic;
using Dhs5.Utility.Databases;
using Dhs5.Utility.Tags;
using UnityEngine;

namespace Simulator.GameWorld
{
	public class ShopBuilding : WorldManager
	{
		[Header("Furnitures")]
		[SerializeField]
		private Transform m_furnituresContainer;

		[Header("Player detection")]
		[SerializeField]
		private GameplayTagsList m_playerTag;

		[Header("Tutorial")]
		[SerializeField]
		private TutorialData m_orderTutorialData;

		private Dictionary<int, Furniture> m_furnitures = new Dictionary<int, Furniture>();

		private int m_lastFurnitureGameID;

		protected override void OnWorldEvent(EWorldEvent worldEvent)
		{
			base.OnWorldEvent(worldEvent);
			switch (worldEvent)
			{
			case EWorldEvent.LOADING_PHASE1:
				LoadFurnituresPhase1();
				break;
			case EWorldEvent.LOADING_PHASE2:
				LoadFurnituresPhase2();
				break;
			case EWorldEvent.INITIALISATION:
				InitPostLoadFurnitures();
				break;
			case EWorldEvent.SAVE:
				SaveFurnitures();
				break;
			case EWorldEvent.START:
			case EWorldEvent.PAUSE:
			case EWorldEvent.UNPAUSE:
				break;
			}
		}

		private void LoadFurnituresPhase1()
		{
			m_lastFurnitureGameID = 0;
			foreach (SaveClass_Furnitures.FurnitureState savedFurniture in SaveManager.CurrentSave.GetSavedFurnitures())
			{
				if (InstantiateFurniture(savedFurniture.modelUID, out var furniture))
				{
					m_furnitures.Add(savedFurniture.gameID, furniture);
					furniture.Load(1, savedFurniture);
				}
				if (savedFurniture.gameID > m_lastFurnitureGameID)
				{
					m_lastFurnitureGameID = savedFurniture.gameID;
				}
			}
		}

		private void LoadFurnituresPhase2()
		{
			foreach (SaveClass_Furnitures.FurnitureState savedFurniture in SaveManager.CurrentSave.GetSavedFurnitures())
			{
				if (m_furnitures.TryGetValue(savedFurniture.gameID, out var value))
				{
					value.Load(2, savedFurniture);
				}
			}
		}

		private void InitPostLoadFurnitures()
		{
			foreach (SaveClass_Furnitures.FurnitureState savedFurniture in SaveManager.CurrentSave.GetSavedFurnitures())
			{
				if (m_furnitures.TryGetValue(savedFurniture.gameID, out var value))
				{
					value.InitPostLoad(savedFurniture);
				}
			}
		}

		private void SaveFurnitures()
		{
			SaveManager.CurrentSave.StartFurnitureSaveProcess();
			foreach (var (_, furniture2) in m_furnitures)
			{
				SaveManager.CurrentSave.SaveFurniture(furniture2.Save());
			}
		}

		private bool InstantiateFurniture(int uid, out Furniture furniture)
		{
			if (Database.GetDataByUID<FurnitureDatabase, Furniture>(uid, out var data))
			{
				furniture = Object.Instantiate(data, m_furnituresContainer);
				return true;
			}
			furniture = null;
			return false;
		}

		public bool PrepareNewFurniture(int uid, out Furniture furniture)
		{
			if (InstantiateFurniture(uid, out furniture))
			{
				int uniqueFurnitureGameID = GetUniqueFurnitureGameID();
				m_furnitures.Add(uniqueFurnitureGameID, furniture);
				furniture.PreInit(uniqueFurnitureGameID);
				return true;
			}
			return false;
		}

		public int GetUniqueFurnitureGameID()
		{
			m_lastFurnitureGameID++;
			return m_lastFurnitureGameID;
		}

		public void DestroyFurniture(int gameID)
		{
			if (m_furnitures.TryGetValue(gameID, out var value))
			{
				value.PrepareDestruction();
				Object.Destroy(value.gameObject);
				m_furnitures.Remove(gameID);
			}
		}
	}
}
