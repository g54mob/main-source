using System;
using System.Collections.Generic;
using System.IO;
using AutoTiling;
using UnityEngine;

public class LevelController : BaseController<LevelView, LevelModel>
{
	public LevelController(LevelView levelView, LevelModel levelModel)
		: base(levelView, levelModel, false)
	{
	}

	protected override void SyncViewWithModel()
	{
		GameObject staticObjectsFolder = LevelManager.Instance.staticObjectsFolder;
		GameObject dynamicObjectsFolder = LevelManager.Instance.dynamicObjectsFolder;
		GameObject atackerZone = LevelManager.Instance.atackerZone;
		GameObject goalZone = LevelManager.Instance.goalZone;
		GameObject gameObject = LevelManager.Instance.failureZones.transform.GetChild(0).gameObject;
		if (staticObjectsFolder == null || dynamicObjectsFolder == null || atackerZone == null || goalZone == null)
		{
			return;
		}
		LevelObjectModel[] allLevelObjectModels = model.CustomLevelObjectsModel.GetAllLevelObjectModels();
		Dictionary<int, GameObject> dictionary = new Dictionary<int, GameObject>();
		foreach (LevelObjectModel levelObjectModel in allLevelObjectModels)
		{
			switch (levelObjectModel.LevelObjectType)
			{
			case LevelObjectType.StartZone:
			case LevelObjectType.EndZone:
			case LevelObjectType.FailureZone:
			{
				GameObject gameObject4 = atackerZone;
				if (levelObjectModel.LevelObjectType == LevelObjectType.StartZone)
				{
					gameObject4 = atackerZone;
				}
				else if (levelObjectModel.LevelObjectType == LevelObjectType.EndZone)
				{
					gameObject4 = goalZone;
				}
				else if (levelObjectModel.LevelObjectType == LevelObjectType.FailureZone)
				{
					gameObject4 = gameObject;
				}
				gameObject4.transform.position = levelObjectModel.Position;
				gameObject4.transform.rotation = levelObjectModel.Rotation;
				gameObject4.transform.localScale = levelObjectModel.Scale;
				break;
			}
			case LevelObjectType.Ground:
				UnityEngine.Object.Instantiate(Resources.Load<GameObject>("Level/Others/ground"), levelObjectModel.Position, levelObjectModel.Rotation, staticObjectsFolder.transform).name = levelObjectModel.Name;
				break;
			case LevelObjectType.Structure:
			case LevelObjectType.Dynamic:
			case LevelObjectType.Active:
			{
				GameObject gameObject2 = LevelEditorUtil.LoadLevelObjectPrefab(levelObjectModel, LevelEditorUtil.LevelObjectPrefabPlace.Real);
				if (gameObject2 == null)
				{
					break;
				}
				Transform transform = staticObjectsFolder.transform;
				if (levelObjectModel.IsAffectedByPhysics || levelObjectModel.LevelObjectType == LevelObjectType.Dynamic || levelObjectModel.LevelObjectType == LevelObjectType.Active)
				{
					transform = dynamicObjectsFolder.transform;
				}
				GameObject gameObject3 = UnityEngine.Object.Instantiate(gameObject2, levelObjectModel.Position, levelObjectModel.Rotation, transform);
				gameObject3.name = levelObjectModel.Name;
				if (levelObjectModel.LevelObjectType != LevelObjectType.Active)
				{
					gameObject3.transform.localScale = levelObjectModel.Scale;
				}
				else
				{
					Transform transform2 = gameObject3.transform.FindChildRecursively("pivot");
					if (transform2 != null)
					{
						transform2.localScale = levelObjectModel.Scale;
					}
				}
				if (levelObjectModel.LevelObjectType == LevelObjectType.Structure)
				{
					Rigidbody component = gameObject3.GetComponent<Rigidbody>();
					if (levelObjectModel.IsAffectedByPhysics || levelObjectModel.RotatorModel != null)
					{
						if (component != null)
						{
							component.mass = levelObjectModel.Mass;
						}
					}
					else if (component != null)
					{
						UnityEngine.Object.Destroy(component);
					}
				}
				if (levelObjectModel.LevelObjectType == LevelObjectType.Structure || levelObjectModel.LevelObjectType == LevelObjectType.Active)
				{
					Renderer[] componentsInChildren = gameObject3.GetComponentsInChildren<Renderer>();
					for (int j = 0; j < componentsInChildren.Length; j++)
					{
						if (!levelObjectModel.IsWithGrid)
						{
							componentsInChildren[j].material = GlobalMaterialManager.Instance.LevelObjectWithoutGridMat;
						}
						if (componentsInChildren[j].material.color != levelObjectModel.Color)
						{
							componentsInChildren[j].material.color = levelObjectModel.Color;
							if (componentsInChildren[j].material.color.a < 1f)
							{
								Util.ChangeStandardMaterialRenderMode(componentsInChildren[j].material, Util.BlendMode.Transparent);
							}
							else
							{
								Util.ChangeStandardMaterialRenderMode(componentsInChildren[j].material, Util.BlendMode.Opaque);
							}
						}
					}
					if (levelObjectModel.IsAltTexOffset)
					{
						DynamicTextureTiling[] componentsInChildren2 = gameObject3.GetComponentsInChildren<DynamicTextureTiling>(includeInactive: true);
						for (int k = 0; k < componentsInChildren2.Length; k++)
						{
							if (componentsInChildren2[k].unwrapMethod == UnwrapType.CubeProjection)
							{
								float x = ((componentsInChildren2[k].topOffset.x == 0f) ? 0.5f : 0f);
								float y = ((componentsInChildren2[k].topOffset.y == 0f) ? 0.5f : 0f);
								componentsInChildren2[k].topOffset = new Vector2(x, y);
							}
							else
							{
								float x2 = ((componentsInChildren2[k].faceUnwrapData[0].uvOffset.x == 0f) ? 0.5f : 0f);
								float y2 = ((componentsInChildren2[k].faceUnwrapData[0].uvOffset.y == 0f) ? 0.5f : 0f);
								componentsInChildren2[k].ApplyFaceOffset(0, new Vector2(x2, y2));
							}
						}
					}
				}
				if (levelObjectModel.LevelObjectType == LevelObjectType.Structure && levelObjectModel.RotatorModel != null)
				{
					gameObject3.AddComponent<LORotator>().SetConfigurations(levelObjectModel.RotatorModel.Speed, levelObjectModel.RotatorModel.IsLocalSpace);
				}
				dictionary.Add(levelObjectModel.Id, gameObject3);
				break;
			}
			}
		}
		foreach (LevelObjectModel levelObjectModel2 in allLevelObjectModels)
		{
			if (levelObjectModel2.LogicType != LevelObjectLogicType.Input || !dictionary.ContainsKey(levelObjectModel2.Id) || !dictionary.ContainsKey(levelObjectModel2.LevelObjectOutputId))
			{
				continue;
			}
			LevelButtonBase component2 = dictionary[levelObjectModel2.LevelObjectOutputId].GetComponent<LevelButtonBase>();
			if (!(component2 == null))
			{
				AnimatorTriggeredByButton component3 = dictionary[levelObjectModel2.Id].GetComponent<AnimatorTriggeredByButton>();
				if (component3 != null)
				{
					component3.SetButton(component2, levelObjectModel2.IsInvertedLogic, levelObjectModel2.IsPressOnce);
				}
			}
		}
	}

	protected override void ModelChangeHandler(string eventName, params object[] data)
	{
	}

	protected override void ViewChangeHandler(string eventName, params object[] data)
	{
		switch (eventName)
		{
		case "LevelView.LevelStartedEvent":
			model.LevelOverStatusEnum = LevelModel.LevelOverStatus.NotOver;
			break;
		case "LevelView.GoalCompletedEvent":
		case "LevelView.DefenderFailedEvent":
		case "LevelView.DefenderBrainDestroyedEvent":
			if (model.LevelOverStatusEnum != LevelModel.LevelOverStatus.NotOver)
			{
				break;
			}
			if (eventName == "LevelView.GoalCompletedEvent" || (GameManager.Instance.GameMode == GameManager.GameModeState.Attacker && LevelManager.Instance.IsBrainDestroyedGoal))
			{
				float num = (float)data[0];
				Debug.Log("Level completed in " + num + " seconds");
				bool flag = GameManager.Instance.OptionsModel.IsCheatsEnabled && GameManager.Instance.CheatModel.IsAnyCheatEnabled;
				bool flag2 = GameManager.Instance.LevelManager.IsUsingRestrictedBlocks(GameManager.Instance.MainCreationController.model);
				bool flag3 = CheckForContentModified();
				if (flag || flag2 || flag3)
				{
					if (flag || flag2)
					{
						model.LevelOverStatusEnum = LevelModel.LevelOverStatus.SuccessfulWithCheat;
					}
					if (flag3)
					{
						model.LevelOverStatusEnum = LevelModel.LevelOverStatus.SuccessfulWithMod;
					}
					model.CurrentTime = num;
				}
				else
				{
					model.LevelOverStatusEnum = LevelModel.LevelOverStatus.Successful;
					UpdateLevelStatusAndSave(num);
					CheckLevelAchievements();
				}
				LevelOverAndChangeState();
			}
			else if (GameManager.Instance.GameMode == GameManager.GameModeState.Defender)
			{
				model.LevelOverStatusEnum = LevelModel.LevelOverStatus.Failed;
				LevelOverAndChangeState();
			}
			break;
		case "LevelView.AttackerFailedEvent":
			if (model.LevelOverStatusEnum == LevelModel.LevelOverStatus.NotOver)
			{
				model.LevelOverStatusEnum = LevelModel.LevelOverStatus.Failed;
				LevelOverAndChangeState();
			}
			break;
		case "LevelView.AttackerBrainDestroyedEvent":
			if (model.LevelOverStatusEnum == LevelModel.LevelOverStatus.NotOver)
			{
				model.LevelOverStatusEnum = LevelModel.LevelOverStatus.BrainBlockDestroyed;
				LevelOverAndChangeState();
			}
			break;
		case "LevelView.CollectablesLoadedEvent":
		{
			int goldCollectableTotal = (int)data[0];
			int silverCollectableTotal = (int)data[1];
			if (model.IsThereCollectables)
			{
				model.GoldCollectableTotal = goldCollectableTotal;
				model.SilverCollectableTotal = silverCollectableTotal;
			}
			break;
		}
		case "LevelView.CollectablesRestoredEvent":
			model.GoldCollectableCounter = 0;
			model.SilverCollectableCounter = 0;
			break;
		case "LevelView.CollectablePickedUpEvent":
			switch ((LevelCollectable.CollectableType)data[0])
			{
			case LevelCollectable.CollectableType.Gold:
				model.GoldCollectableCounter++;
				break;
			case LevelCollectable.CollectableType.Silver:
				model.SilverCollectableCounter++;
				break;
			}
			break;
		}
	}

	private bool CheckForContentModified()
	{
		bool flag = GameManager.Instance.InvalidLevelModelHashes.HasProperty(model.Id);
		bool flag2 = false;
		foreach (BlockModel item in GameManager.Instance.MainCreationController.model.GetAllBlockModel())
		{
			if (GameManager.Instance.InvalidSchematicHashes.HasProperty(item.Schematic.Id))
			{
				flag2 = true;
				break;
			}
		}
		bool isInvalidSchOrMatPropertiesHashes = GameManager.Instance.IsInvalidSchOrMatPropertiesHashes;
		return flag || flag2 || isInvalidSchOrMatPropertiesHashes;
	}

	private void LevelOverAndChangeState()
	{
		GameManager.Instance.ChangeState(LevelCompletedState.Instance);
	}

	private void UpdateLevelStatusAndSave(float levelTime)
	{
		model.CurrentTime = levelTime;
		if (levelTime < model.BestTime)
		{
			model.BestTime = levelTime;
		}
		if (GameManager.Instance.LevelType == GameManager.LevelTypeState.Test)
		{
			return;
		}
		if (model.LevelStatus == null)
		{
			if (GameManager.Instance.LevelType == GameManager.LevelTypeState.Campaign)
			{
				GameManager.Instance.UserProfileModel.CampaignLevelStatusList.AddItem(new LevelStatus(model));
			}
			else if (GameManager.Instance.LevelType == GameManager.LevelTypeState.User)
			{
				GameManager.Instance.UserProfileModel.UserLevelStatusList.AddItem(new LevelStatus(model));
			}
			else if (GameManager.Instance.LevelType == GameManager.LevelTypeState.Workshop)
			{
				GameManager.Instance.UserProfileModel.WorkshopLevelStatusList.AddItem(new LevelStatus(model));
			}
			else if (GameManager.Instance.LevelType == GameManager.LevelTypeState.Sandbox && model.IsSandboxWithGoal)
			{
				GameManager.Instance.UserProfileModel.SandboxLevelStatusList.AddItem(new LevelStatus(model));
			}
			else if (GameManager.Instance.LevelType == GameManager.LevelTypeState.Tutorial)
			{
				GameManager.Instance.UserProfileModel.TutorialLevelStatusList.AddItem(new LevelStatus(model));
			}
			model.IsFirstTimeCompleted = true;
		}
		else
		{
			model.IsFirstTimeCompleted = false;
		}
		float currentValue = GameManager.Instance.MainCreationController.model.BlockModelCount;
		float currentValue2 = GameManager.Instance.MainCreationController.model.TotalCost();
		float currentValue3 = GameManager.Instance.MainCreationController.model.TotalWeight();
		CreationModel clonedCreationModel = CloneAndConfigCurrentCreationModel();
		int num = (int)(0u | (CheckRecords(model.LevelStatus.LowestTimeRecords, levelTime, null, clonedCreationModel) ? 1u : 0u) | (CheckRecords(model.LevelStatus.LowestBlocksRecords, currentValue, (CreationModel creationModel) => creationModel.BlockModelCount, clonedCreationModel) ? 1u : 0u) | (CheckRecords(model.LevelStatus.LowestCostRecords, currentValue2, (CreationModel creationModel) => creationModel.TotalCost(), clonedCreationModel) ? 1u : 0u)) | (CheckRecords(model.LevelStatus.LowestWeightRecords, currentValue3, (CreationModel creationModel) => creationModel.TotalWeight(), clonedCreationModel) ? 1 : 0);
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		if (!model.LevelStatus.AllBothCollectables)
		{
			flag = model.IsPickedUpAllGoldCollectables && model.IsPickedUpAllSilverCollectables;
			model.LevelStatus.AllBothCollectables = flag;
		}
		if (!model.LevelStatus.AllGoldCollectables)
		{
			flag2 = model.IsPickedUpAllGoldCollectables;
			model.LevelStatus.AllGoldCollectables = flag2;
		}
		if (!model.LevelStatus.AllSilverCollectables)
		{
			flag3 = model.IsPickedUpAllSilverCollectables;
			model.LevelStatus.AllSilverCollectables = flag3;
		}
		if (((uint)num | (flag ? 1u : 0u) | (flag2 ? 1u : 0u) | (flag3 ? 1u : 0u)) != 0)
		{
			model.NotifyNewLevelRecords();
			UserProfileModelBuilder.SaveXmlFile(GameManager.Instance.UserProfileModel, PathNames.UserProfileAES, isFileEncrypted: true);
		}
	}

	private bool CheckRecords(LevelStatus.RecordsValues recordsValues, float currentValue, Func<CreationModel, float> LastValueGetter, CreationModel clonedCreationModel)
	{
		bool isAnyNewRecord = false;
		bool flag = GameManager.Instance.LevelType == GameManager.LevelTypeState.Campaign || GameManager.Instance.LevelType == GameManager.LevelTypeState.Sandbox;
		string bothCreationId;
		if (model.IsThereCollectables)
		{
			bool isPickedUpAllGoldCollectables = model.IsPickedUpAllGoldCollectables;
			bool isPickedUpAllSilverCollectables = model.IsPickedUpAllSilverCollectables;
			if (isPickedUpAllGoldCollectables && isPickedUpAllSilverCollectables)
			{
				bothCreationId = recordsValues.BothCreationId;
				(recordsValues.BothStarValue, recordsValues.BothCreationId, recordsValues.IsBothStarValueNewRecord) = CheckRecord(recordsValues.BothStarValue, recordsValues.BothCreationId);
				if (isAnyNewRecord && flag)
				{
					SaveNewRecordCreationOnDisk(bothCreationId, clonedCreationModel);
				}
			}
			if (isPickedUpAllGoldCollectables)
			{
				bothCreationId = recordsValues.GoldCreationId;
				(recordsValues.GoldStarValue, recordsValues.GoldCreationId, recordsValues.IsGoldStarValueNewRecord) = CheckRecord(recordsValues.GoldStarValue, recordsValues.GoldCreationId);
				if (isAnyNewRecord && flag)
				{
					SaveNewRecordCreationOnDisk(bothCreationId, clonedCreationModel);
				}
			}
			if (isPickedUpAllSilverCollectables)
			{
				bothCreationId = recordsValues.SilverCreationId;
				(recordsValues.SilverStarValue, recordsValues.SilverCreationId, recordsValues.IsSilverStarValueNewRecord) = CheckRecord(recordsValues.SilverStarValue, recordsValues.SilverCreationId);
				if (isAnyNewRecord && flag)
				{
					SaveNewRecordCreationOnDisk(bothCreationId, clonedCreationModel);
				}
			}
		}
		bothCreationId = recordsValues.NoneCreationId;
		(recordsValues.NoneStarValue, recordsValues.NoneCreationId, recordsValues.IsNoneStarValueNewRecord) = CheckRecord(recordsValues.NoneStarValue, recordsValues.NoneCreationId);
		if (isAnyNewRecord && flag)
		{
			SaveNewRecordCreationOnDisk(bothCreationId, clonedCreationModel);
		}
		return isAnyNewRecord;
		(float value, string creationId, bool isNewValueRecord) CheckRecord(float lastValue, string oldCreationId)
		{
			float item = lastValue;
			string item2 = oldCreationId;
			bool item3 = false;
			if (!string.IsNullOrEmpty(oldCreationId) && LastValueGetter != null)
			{
				CreationModel creationModel = GameManager.Instance.CreationCollectionsManager.BestCreationModelCollection.GetCreationModel(oldCreationId);
				if (creationModel != null)
				{
					lastValue = LastValueGetter(creationModel);
				}
			}
			if (currentValue < lastValue)
			{
				item = currentValue;
				item2 = clonedCreationModel.Id;
				item3 = true;
				isAnyNewRecord = true;
			}
			return (value: item, creationId: item2, isNewValueRecord: item3);
		}
	}

	private string SaveNewRecordCreationOnDisk(string oldRecordCreationId, CreationModel clonedCreationModel)
	{
		if (!string.IsNullOrEmpty(oldRecordCreationId) && (model.LevelStatus == null || !model.LevelStatus.IsCreationIdBeingUsed(oldRecordCreationId)))
		{
			CreationModel creationModel = GameManager.Instance.CreationCollectionsManager.BestCreationModelCollection.GetCreationModel(oldRecordCreationId);
			if (creationModel != null)
			{
				GameManager.Instance.CreationCollectionsManager.BestCreationModelCollection.RemoveCreationModel(oldRecordCreationId);
				if (File.Exists(creationModel.FilePath))
				{
					File.Delete(creationModel.FilePath);
				}
			}
		}
		if (!GameManager.Instance.CreationCollectionsManager.BestCreationModelCollection.HasCreationModel(clonedCreationModel))
		{
			CreationModelBuilder.SaveXml(clonedCreationModel, clonedCreationModel.FilePath, isFileEncrypted: true);
			GameManager.Instance.CreationCollectionsManager.BestCreationModelCollection.AddCreationModel(clonedCreationModel);
		}
		return clonedCreationModel.Id;
	}

	private CreationModel CloneAndConfigCurrentCreationModel()
	{
		string text = PathNames.BestCreationsCampaign;
		if (GameManager.Instance.LevelType == GameManager.LevelTypeState.Campaign)
		{
			text = PathNames.BestCreationsCampaign;
		}
		else if (GameManager.Instance.LevelType == GameManager.LevelTypeState.Sandbox)
		{
			text = PathNames.BestCreationsSandbox;
		}
		CreationModel creationModel = CreationCloner.Clone(GameManager.Instance.MainCreationController.model);
		creationModel.Id = model.Id + "_" + Util.RandomString(6);
		creationModel.FilePath = text + creationModel.Id + ".sav";
		if (!Directory.Exists(text))
		{
			Directory.CreateDirectory(text);
		}
		return creationModel;
	}

	private void CheckLevelAchievements()
	{
		if (model.Id == "tutorial_4")
		{
			SteamAchievementsManager.Instance.UnlockAchievement(SteamAchievementsManager.Achievement.TUTORIAL_COMPLETED);
		}
		if (model.Id == "mountain")
		{
			SteamAchievementsManager.Instance.UnlockAchievement(SteamAchievementsManager.Achievement.MOUNTAIN_COMPLETED);
			if (model.IsPickedUpAllSilverCollectables)
			{
				SteamAchievementsManager.Instance.UnlockAchievement(SteamAchievementsManager.Achievement.MOUNTAIN_SILVER);
			}
			if (model.IsPickedUpAllGoldCollectables)
			{
				SteamAchievementsManager.Instance.UnlockAchievement(SteamAchievementsManager.Achievement.MOUNTAIN_GOLD);
			}
			if (model.IsPickedUpAllGoldCollectables && model.IsPickedUpAllSilverCollectables)
			{
				SteamAchievementsManager.Instance.UnlockAchievement(SteamAchievementsManager.Achievement.MOUNTAIN_TOTAL);
			}
		}
		bool isAllLevelsEnabled = GameManager.Instance.CheatModel.IsAllLevelsEnabled;
		if (model.Place != LevelModel.LevelPlace.Campaign || isAllLevelsEnabled)
		{
			return;
		}
		SteamAchievementsManager.Instance.UnlockAchievement(SteamAchievementsManager.Achievement.FIRST_LEVEL);
		var (num, flag, flag2, flag3, flag4) = GameManager.Instance.GroupCampaignModel.GetDifficultGroupInfos(model);
		switch (num)
		{
		case 0:
			if (flag)
			{
				SteamAchievementsManager.Instance.UnlockAchievement(SteamAchievementsManager.Achievement.GROUP_EASY_COMPLETED);
			}
			if (flag2)
			{
				SteamAchievementsManager.Instance.UnlockAchievement(SteamAchievementsManager.Achievement.GROUP_EASY_SILVER);
			}
			if (flag3)
			{
				SteamAchievementsManager.Instance.UnlockAchievement(SteamAchievementsManager.Achievement.GROUP_EASY_GOLD);
			}
			if (flag4)
			{
				SteamAchievementsManager.Instance.UnlockAchievement(SteamAchievementsManager.Achievement.GROUP_EASY_TOTAL);
			}
			break;
		case 1:
			if (flag)
			{
				SteamAchievementsManager.Instance.UnlockAchievement(SteamAchievementsManager.Achievement.GROUP_MEDIUM_COMPLETED);
			}
			if (flag2)
			{
				SteamAchievementsManager.Instance.UnlockAchievement(SteamAchievementsManager.Achievement.GROUP_MEDIUM_SILVER);
			}
			if (flag3)
			{
				SteamAchievementsManager.Instance.UnlockAchievement(SteamAchievementsManager.Achievement.GROUP_MEDIUM_GOLD);
			}
			if (flag4)
			{
				SteamAchievementsManager.Instance.UnlockAchievement(SteamAchievementsManager.Achievement.GROUP_MEDIUM_TOTAL);
			}
			break;
		case 2:
			if (flag)
			{
				SteamAchievementsManager.Instance.UnlockAchievement(SteamAchievementsManager.Achievement.GROUP_HARD_COMPLETED);
			}
			if (flag2)
			{
				SteamAchievementsManager.Instance.UnlockAchievement(SteamAchievementsManager.Achievement.GROUP_HARD_SILVER);
			}
			if (flag3)
			{
				SteamAchievementsManager.Instance.UnlockAchievement(SteamAchievementsManager.Achievement.GROUP_HARD_GOLD);
			}
			if (flag4)
			{
				SteamAchievementsManager.Instance.UnlockAchievement(SteamAchievementsManager.Achievement.GROUP_HARD_TOTAL);
			}
			break;
		case 3:
			if (flag)
			{
				SteamAchievementsManager.Instance.UnlockAchievement(SteamAchievementsManager.Achievement.GROUP_EXTREME_COMPLETED);
			}
			if (flag2)
			{
				SteamAchievementsManager.Instance.UnlockAchievement(SteamAchievementsManager.Achievement.GROUP_EXTREME_SILVER);
			}
			if (flag3)
			{
				SteamAchievementsManager.Instance.UnlockAchievement(SteamAchievementsManager.Achievement.GROUP_EXTREME_GOLD);
			}
			if (flag4)
			{
				SteamAchievementsManager.Instance.UnlockAchievement(SteamAchievementsManager.Achievement.GROUP_EXTREME_TOTAL);
			}
			break;
		default:
			Debug.LogError($"LevelController#CheckLevelAchievements: Difficult group index is wrong ({num})!");
			break;
		}
		var (flag5, flag6, flag7, flag8) = GameManager.Instance.GroupCampaignModel.GetCampaignCompletenessInfos();
		if (flag5)
		{
			SteamAchievementsManager.Instance.UnlockAchievement(SteamAchievementsManager.Achievement.MAIN_CAMPAIGN_COMPLETED);
		}
		if (flag6)
		{
			SteamAchievementsManager.Instance.UnlockAchievement(SteamAchievementsManager.Achievement.MAIN_CAMPAIGN_SILVER);
		}
		if (flag7)
		{
			SteamAchievementsManager.Instance.UnlockAchievement(SteamAchievementsManager.Achievement.MAIN_CAMPAIGN_GOLD);
		}
		if (flag8)
		{
			SteamAchievementsManager.Instance.UnlockAchievement(SteamAchievementsManager.Achievement.MAIN_CAMPAIGN_TOTAL);
		}
	}
}
