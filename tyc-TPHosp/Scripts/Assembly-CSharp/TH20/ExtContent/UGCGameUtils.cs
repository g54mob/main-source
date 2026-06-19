using System.Collections.Generic;
using FullInspector.Generated.SharedInstance;
using UnityEngine;

namespace TH20.ExtContent
{
	public static class UGCGameUtils
	{
		public static RoomItemDefinition GetRoomItemDefinitionForTag(string tag)
		{
			RoomItemDefinition roomItemDefinition = null;
			SharedInstance_TH20TH20_RoomItemDefinition[] array = Resources.FindObjectsOfTypeAll<SharedInstance_TH20TH20_RoomItemDefinition>();
			foreach (SharedInstance_TH20TH20_RoomItemDefinition sharedInstance_TH20TH20_RoomItemDefinition in array)
			{
				if (sharedInstance_TH20TH20_RoomItemDefinition.Instance.DebugTag == tag)
				{
					roomItemDefinition = sharedInstance_TH20TH20_RoomItemDefinition.Instance;
					break;
				}
			}
			ExtContentMessages.LogDebug(string.Format("{0}: Searching for tag '{1}'. Found: {2}", "UGCGameUtils.GetRoomItemDefinitionForTag()", tag, (roomItemDefinition != null) ? "Y" : "N"));
			return roomItemDefinition;
		}

		public static GameObject CreateRoomItemRuntimePrefab(RoomItemDefinition roomItemDefinition, string contentID)
		{
			UGCRuntimePrefabManager uGCRuntimePrefabManager = ExtContentUtils.ExtContentManager.App.UGCRuntimePrefabManager;
			GameObject gameObject = Object.Instantiate(roomItemDefinition.GetPrefab(), uGCRuntimePrefabManager.RuntimePrefabRoot.transform);
			gameObject.name = roomItemDefinition.GetPrefab().name;
			gameObject.name += "(UGC Runtime Prefab)";
			uGCRuntimePrefabManager.AddOrReplaceRuntimePrefab(new UGCRuntimePrefabKey(contentID, 0), gameObject);
			ExtContentMessages.LogDebug(string.Format("{0}: Creating RT prefab for room iem defn '{1}' and contentID '{2}'. Created OK: {3}", "UGCGameUtils.CreateRoomItemRuntimePrefab()", roomItemDefinition.ToString(), contentID, (gameObject != null) ? "Y" : "N"));
			return gameObject;
		}

		public static bool SetRuntimePrefabRoomItemPictureBaseData(GameObject runtimePrefab, string contentID, Texture2D texture, Texture2D textureIcon, int itemPrice, int itemKudosh)
		{
			UGCRoomItemDefinitionDatabase uGCRoomItemDefinitionDatabase = ExtContentUtils.ExtContentManager.App.UGCRoomItemDefinitionDatabase;
			bool result = ReplaceGameObjectTextures(runtimePrefab, texture);
			if (textureIcon != null)
			{
				Sprite icon = Sprite.Create(textureIcon, new Rect(0f, 0f, textureIcon.width, textureIcon.height), new Vector2(0.5f, 0.5f));
				uGCRoomItemDefinitionDatabase.SetIcon(contentID, icon);
			}
			uGCRoomItemDefinitionDatabase.SetCost(contentID, itemPrice);
			uGCRoomItemDefinitionDatabase.SetSilverCost(contentID, itemKudosh);
			ExtContentMessages.LogDebug(string.Format("{0}: Setting data for RT prefab with contentID '{1}'", "UGCGameUtils.SetRuntimePrefabRoomItemPictureBaseData()", contentID));
			return result;
		}

		public static RoomItemDefinitionUGC CreateRoomItemPictureBase(string contentID, RoomItemDefinition roomItemDefinition)
		{
			App app = ExtContentUtils.ExtContentManager.App;
			UGCRuntimePrefabManager uGCRuntimePrefabManager = app.UGCRuntimePrefabManager;
			UGCRoomItemDefinitionDatabase uGCRoomItemDefinitionDatabase = app.UGCRoomItemDefinitionDatabase;
			RoomItemDefinitionUGC roomItemDefinitionUGC = app.Metagame.CurrentLevel.WorldState.AvailableRoomItems.Find(delegate(IRoomItemDefinition item)
			{
				bool result = false;
				if (item is RoomItemDefinitionUGC roomItemDefinitionUGC2 && roomItemDefinitionUGC2.ContentID == contentID)
				{
					result = true;
				}
				return result;
			}) as RoomItemDefinitionUGC;
			if (roomItemDefinitionUGC == null)
			{
				roomItemDefinitionUGC = app.Metagame.CurrentLevel.UGCDefinitionsFixUp.FindRoomItem(contentID);
				if (roomItemDefinitionUGC == null)
				{
					roomItemDefinitionUGC = new RoomItemDefinitionUGC(contentID, roomItemDefinition, uGCRuntimePrefabManager, uGCRoomItemDefinitionDatabase);
					app.Metagame.CurrentLevel.UGCDefinitionsFixUp.AddRoomItem(roomItemDefinitionUGC);
					ExtContentMessages.LogDebug(string.Format("{0}: Creating UGC room item defn for contentID '{1}'. ({2})", "UGCGameUtils.CreateRoomItemPictureBase()", contentID, roomItemDefinitionUGC.ToString()));
				}
				app.Metagame.CurrentLevel.WorldState.AvailableRoomItems.Add(roomItemDefinitionUGC);
			}
			else
			{
				ExtContentMessages.LogDebug(string.Format("{0}: UGC room item defn already exists for contentID '{1}'. ({2})", "UGCGameUtils.CreateRoomItemPictureBase()", contentID, roomItemDefinitionUGC.ToString()));
			}
			return roomItemDefinitionUGC;
		}

		public static void RemoveUGCRoomItemDefintionFromLists(RoomItemDefinitionUGC ugcRoomItemDefintion)
		{
			if (ugcRoomItemDefintion != null)
			{
				App app = ExtContentUtils.ExtContentManager.App;
				if (app.Metagame != null)
				{
					app.Metagame.CurrentLevel.WorldState.AvailableRoomItems.Remove(ugcRoomItemDefintion);
					ExtContentMessages.LogDebug(string.Format("{0}: Removed UGC root item defn from relevant lists. '{1}'", "UGCGameUtils.RemoveUGCRoomItemDefintionFromLists()", ugcRoomItemDefintion.ToString()));
				}
			}
		}

		public static bool ReplaceGameObjectTextures(GameObject runtimePrefab, string textureFileSpec)
		{
			return ReplaceGameObjectTextures(runtimePrefab, ExtContentTextureUtils.LoadTexture2D(textureFileSpec));
		}

		public static bool ReplaceGameObjectTextures(GameObject runtimePrefab, Texture2D texture2D)
		{
			bool result = false;
			if (texture2D != null)
			{
				UGCRendererOverrideComponent componentInChildren = runtimePrefab.GetComponentInChildren<UGCRendererOverrideComponent>();
				if (componentInChildren != null)
				{
					for (int i = 0; i < componentInChildren.OverrideDefinitions.Length; i++)
					{
						componentInChildren.OverrideDefinitions[i].Renderer.materials[componentInChildren.OverrideDefinitions[i].MaterialIndex].SetTexture("_MainTex", texture2D);
					}
				}
				else
				{
					Renderer[] componentsInChildren = runtimePrefab.GetComponentsInChildren<Renderer>();
					foreach (Renderer renderer in componentsInChildren)
					{
						Material[] materials = renderer.materials;
						for (int k = 0; k < materials.Length; k++)
						{
							materials[0].SetTexture("_MainTex", texture2D);
						}
						renderer.sharedMaterials = materials;
					}
				}
				result = true;
			}
			return result;
		}

		public static List<RoomItem> GetAllUGCRoomItemInstancesWithContentID(string contentID)
		{
			List<RoomItem> list = new List<RoomItem>();
			bool flag = !contentID.IsNullOrEmpty();
			App app = ExtContentUtils.ExtContentManager.App;
			if (app.Level != null && app.Level.WorldState != null)
			{
				foreach (Room allRoom in app.Level.WorldState.AllRooms)
				{
					foreach (RoomItem item in allRoom.FloorPlan.Items)
					{
						if (item.Definition is RoomItemDefinitionUGC roomItemDefinitionUGC)
						{
							bool flag2 = true;
							if (flag)
							{
								flag2 = roomItemDefinitionUGC.ContentID == contentID;
							}
							if (flag2)
							{
								list.Add(item);
							}
						}
					}
				}
			}
			return list;
		}

		public static WallVisualOverrideDefinitionUGC CreateWall(string contentID)
		{
			WallVisualOverrideDefinitionUGC wallVisualOverrideDefinitionUGC = null;
			App app = ExtContentUtils.ExtContentManager.App;
			Level currentLevel = app.Metagame.CurrentLevel;
			UGCWallVisualOverrideDefinitionDatabase uGCWallVisualOverrideDefinitionDatabase = app.UGCWallVisualOverrideDefinitionDatabase;
			wallVisualOverrideDefinitionUGC = currentLevel.WallVisualOverrideDefinitionUGCs.Find((WallVisualOverrideDefinitionUGC item) => item.ContentID == contentID);
			if (wallVisualOverrideDefinitionUGC == null)
			{
				wallVisualOverrideDefinitionUGC = app.Metagame.CurrentLevel.UGCDefinitionsFixUp.FindWallVisualOverride(contentID);
				if (wallVisualOverrideDefinitionUGC == null)
				{
					wallVisualOverrideDefinitionUGC = new WallVisualOverrideDefinitionUGC(contentID, uGCWallVisualOverrideDefinitionDatabase);
					app.Metagame.CurrentLevel.UGCDefinitionsFixUp.AddWallVisualOverride(wallVisualOverrideDefinitionUGC);
					ExtContentMessages.LogDebug(string.Format("{0}: Creating wall UGC defn for contentID '{1}'. ({2})", "UGCGameUtils.CreateWall()", contentID, wallVisualOverrideDefinitionUGC.ToString()));
				}
				app.Metagame.CurrentLevel.WallVisualOverrideDefinitionUGCs.Add(wallVisualOverrideDefinitionUGC);
			}
			else
			{
				ExtContentMessages.LogDebug(string.Format("{0}: Wall UGC defn already exits for contentID '{1}'. ({2})", "UGCGameUtils.CreateWall()", contentID, wallVisualOverrideDefinitionUGC.ToString()));
			}
			return wallVisualOverrideDefinitionUGC;
		}

		public static void RemoveWallVisualOverrideFromLists(WallVisualOverrideDefinitionUGC wallVisualOverrideDefinitionUGC)
		{
			if (wallVisualOverrideDefinitionUGC != null && ExtContentUtils.ExtContentManager.App.Metagame != null)
			{
				ExtContentUtils.ExtContentManager.App.Metagame.CurrentLevel.WallVisualOverrideDefinitionUGCs.Remove(wallVisualOverrideDefinitionUGC);
				ExtContentMessages.LogDebug(string.Format("{0}: Removed wall UGC defn from relevant lists '{1}'", "UGCGameUtils.RemoveWallVisualOverrideFromLists()", wallVisualOverrideDefinitionUGC.ToString()));
			}
		}

		public static bool PerformWallLevelFixups(WallVisualOverrideDefinitionUGC wallVisualOverrideDefinitionUGC)
		{
			bool result = false;
			if (wallVisualOverrideDefinitionUGC != null)
			{
				App app = ExtContentUtils.ExtContentManager.App;
				if (app.Metagame != null && app.Metagame.CurrentLevel != null)
				{
					app.Metagame.CurrentLevel.UGCDefinitionsFixUp.AddWallVisualOverride(wallVisualOverrideDefinitionUGC);
					result = true;
					ExtContentMessages.LogDebug(string.Format("{0}: Performed level fixups for wall UGC defn '{1}'", "UGCGameUtils.PerformWallLevelFixups()", wallVisualOverrideDefinitionUGC.ToString()));
				}
			}
			return result;
		}

		public static bool SetWallVisualOverrideData(string contentID, Texture2D texture, Texture2D textureIcon, int itemPrice, int itemKudosh)
		{
			ExtContentUtils.ExtContentManager.App.UGCWallVisualOverrideDefinitionDatabase.SetDiffuseTexture(contentID, texture);
			ExtContentMessages.LogDebug(string.Format("{0}: Set override data for wall with contentID '{1}'", "UGCGameUtils.SetWallVisualOverrideData()", contentID));
			return true;
		}

		public static FloorVisualOverrideDefinitionUGC CreateFloor(string contentID)
		{
			FloorVisualOverrideDefinitionUGC floorVisualOverrideDefinitionUGC = null;
			App app = ExtContentUtils.ExtContentManager.App;
			Level currentLevel = app.Metagame.CurrentLevel;
			UGCFloorVisualOverrideDefinitionDatabase uGCFloorVisualOverrideDefinitionDatabase = app.UGCFloorVisualOverrideDefinitionDatabase;
			floorVisualOverrideDefinitionUGC = currentLevel.FloorVisualOverrideDefinitionUGCs.Find((FloorVisualOverrideDefinitionUGC item) => item.ContentID == contentID);
			if (floorVisualOverrideDefinitionUGC == null)
			{
				floorVisualOverrideDefinitionUGC = ExtContentUtils.ExtContentManager.App.Metagame.CurrentLevel.UGCDefinitionsFixUp.FindFloorVisualOverride(contentID);
				if (floorVisualOverrideDefinitionUGC == null)
				{
					floorVisualOverrideDefinitionUGC = new FloorVisualOverrideDefinitionUGC(contentID, uGCFloorVisualOverrideDefinitionDatabase);
					ExtContentUtils.ExtContentManager.App.Metagame.CurrentLevel.UGCDefinitionsFixUp.AddFloorVisualOverride(floorVisualOverrideDefinitionUGC);
					ExtContentMessages.LogDebug(string.Format("{0}: Creating floor UGC defn for contentID '{1}'. ({2})", "UGCGameUtils.CreateFloor()", contentID, floorVisualOverrideDefinitionUGC.ToString()));
				}
				ExtContentUtils.ExtContentManager.App.Metagame.CurrentLevel.FloorVisualOverrideDefinitionUGCs.Add(floorVisualOverrideDefinitionUGC);
			}
			else
			{
				ExtContentMessages.LogDebug(string.Format("{0}: floor UGC defn already exits for contentID '{1}'. ({2})", "UGCGameUtils.CreateFloor()", contentID, floorVisualOverrideDefinitionUGC.ToString()));
			}
			return floorVisualOverrideDefinitionUGC;
		}

		public static void RemoveFloorVisualOverrideFromLists(FloorVisualOverrideDefinitionUGC floorVisualOverrideDefinitionUGC)
		{
			if (floorVisualOverrideDefinitionUGC != null && ExtContentUtils.ExtContentManager.App.Metagame != null)
			{
				ExtContentUtils.ExtContentManager.App.Metagame.CurrentLevel.FloorVisualOverrideDefinitionUGCs.Remove(floorVisualOverrideDefinitionUGC);
				ExtContentMessages.LogDebug(string.Format("{0}: Removed floor UGC defn from relevant lists '{1}'", "UGCGameUtils.RemoveFloorVisualOverrideFromLists()", floorVisualOverrideDefinitionUGC.ToString()));
			}
		}

		public static bool PerformFloorLevelFixups(FloorVisualOverrideDefinitionUGC floorVisualOverrideDefinitionUGC)
		{
			bool result = false;
			if (floorVisualOverrideDefinitionUGC != null)
			{
				App app = ExtContentUtils.ExtContentManager.App;
				if (app.Metagame != null && app.Metagame.CurrentLevel != null)
				{
					app.Metagame.CurrentLevel.UGCDefinitionsFixUp.AddFloorVisualOverride(floorVisualOverrideDefinitionUGC);
					result = true;
					ExtContentMessages.LogDebug(string.Format("{0}: Performed level fixups for floor UGC defn '{1}'", "UGCGameUtils.PerformFloorLevelFixups()", floorVisualOverrideDefinitionUGC.ToString()));
				}
			}
			return result;
		}

		public static bool SetFloorVisualOverrideData(string contentID, Texture2D texture, Texture2D textureIcon, int itemPrice, int itemKudosh)
		{
			ExtContentUtils.ExtContentManager.App.UGCFloorVisualOverrideDefinitionDatabase.SetDiffuseTexture(contentID, texture);
			ExtContentMessages.LogDebug(string.Format("{0}: Set override data for floor with contentID '{1}'", "UGCGameUtils.SetFloorVisualOverrideData()", contentID));
			return true;
		}
	}
}
