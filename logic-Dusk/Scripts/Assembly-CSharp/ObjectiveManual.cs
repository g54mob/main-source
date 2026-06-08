using System.Collections.Generic;
using UnityEngine;

public static class ObjectiveManual
{
	public enum StepStateEnum
	{
		Unknown = 0,
		AddedNew = 1,
		AddedExisting = 2,
		CompletedNew = 3,
		CompletedExisting = 4
	}

	private class ObjectiveStatus
	{
		public string KeyObjective { get; private set; }

		public string KeyStep { get; private set; }

		public ObjectiveStatus(string keyObjective, string keyStep)
		{
			KeyObjective = keyObjective;
			KeyStep = keyStep;
		}
	}

	private static HelpManualMenu rootMenu;

	private static Dictionary<string, HelpManualMenu> objectiveDict;

	private static List<ObjectiveStatus> addedStates;

	private static List<ObjectiveStatus> completedStates;

	public static bool IsVisible
	{
		get
		{
			return ObjectivesUI.Instance.IsShowing;
		}
		set
		{
			ObjectivesUI.Instance.SetVisibility();
		}
	}

	public static bool IsInitalized { get; private set; }

	public static bool IsIgnoringChanges { get; set; }

	public static void Reset()
	{
		if (ObjectivesUI.Instance != null)
		{
			ObjectivesUI.Instance.Reset(EntryTypeEnum.Objective, false);
		}
		IsInitalized = false;
	}

	public static void AddObjective(string keyObjective, string text)
	{
		if (ObjectivesUI.Instance.AddCategory(keyObjective, text, EntryTypeEnum.Objective))
		{
			if (!IsIgnoringChanges)
			{
				ObjectivesUI.Instance.SetCategoryChanged(keyObjective, true);
			}
			GalaxyProcessor.ObjectiveProgressFile.SaveValue(keyObjective, "VIEWED", true);
		}
		else
		{
			Debug.LogWarning(string.Format("Objective Dict already has a top-level menu for {0} - {1}", keyObjective, text));
		}
	}

	public static void AddSeparator(string keyObjective)
	{
		AddSeparator(keyObjective, false);
	}

	public static void AddSeparator(string keyObjective, bool isHidden)
	{
		ObjectivesUI.Instance.AddSeparator(keyObjective, isHidden);
	}

	public static void AddStep(string keyObjective, string keyStep, string text, string description)
	{
		AddStep(keyObjective, keyStep, text, description, false);
	}

	public static void AddStep(string keyObjective, string keyStep, string text, string description, bool isHidden)
	{
		if (string.IsNullOrEmpty(text))
		{
			return;
		}
		if (ObjectivesUI.Instance.AddEntryListing(keyObjective, keyStep, text, description, isHidden))
		{
			if (!isHidden && !GalaxyProcessor.ObjectiveProgressFile.DoesValueExist(keyObjective, keyStep))
			{
				GalaxyProcessor.ObjectiveProgressFile.SaveValue(keyObjective, keyStep, false);
			}
			if (!IsIgnoringChanges)
			{
				ObjectivesUI.Instance.SetCategoryChanged(keyObjective, true);
				ObjectivesUI.Instance.SetEntryChanged(keyObjective, keyStep, true);
			}
		}
		else
		{
			Debug.LogWarning(string.Format("Objective Dict doesn't have a key for: {0}.  Unable to add this step: {1} - {2}", keyObjective, keyStep, text));
		}
	}

	public static void DelayAddStep(string keyObjective, string keyStep)
	{
		if (addedStates == null)
		{
			addedStates = new List<ObjectiveStatus>();
		}
		addedStates.Add(new ObjectiveStatus(keyObjective, keyStep));
	}

	public static void MarkCompleted(string keyObjective, string keyStep)
	{
		if (completedStates == null)
		{
			completedStates = new List<ObjectiveStatus>();
		}
		completedStates.Add(new ObjectiveStatus(keyObjective, keyStep));
	}

	public static void SetVisibility(string keyObjective, string keyStep, bool isVisible)
	{
		ObjectivesUI.EntryItem entryObject = ObjectivesUI.Instance.GetEntryObject(keyObjective, keyStep);
		bool flag = false;
		if (entryObject != null)
		{
			flag = entryObject.EntryUIItem.CanBeShown;
		}
		if (ObjectivesUI.Instance.SetVisibility(keyObjective, keyStep, isVisible))
		{
			bool flag2 = false;
			if (completedStates != null)
			{
				int count = completedStates.Count;
				for (int num = count - 1; num >= 0; num--)
				{
					if (completedStates[num].KeyObjective == keyObjective && completedStates[num].KeyStep == keyStep)
					{
						flag2 = true;
						if (completedStates.Count == 0)
						{
							completedStates = null;
						}
						break;
					}
				}
			}
			if ((!IsIgnoringChanges || flag2) && flag != isVisible)
			{
				ObjectivesUI.Instance.SetCategoryChanged(keyObjective, true);
				ObjectivesUI.Instance.SetEntryChanged(keyObjective, keyStep, true);
			}
			if (isVisible && !GalaxyProcessor.ObjectiveProgressFile.DoesValueExist(keyObjective, keyStep))
			{
				GalaxyProcessor.ObjectiveProgressFile.SaveValue(keyObjective, keyStep, false);
			}
		}
		else
		{
			Debug.LogWarning(string.Format("Objective Dict doesn't have a key for: {0}.  Unable to change step's visibility: {1}", keyObjective, keyStep));
		}
	}

	public static void SetObjectiveComplete(string keyObjective)
	{
		if (ObjectivesUI.Instance.SetCategoryDim(keyObjective, true))
		{
			if (!IsIgnoringChanges)
			{
				ObjectivesUI.Instance.SetCategoryChanged(keyObjective, true);
			}
		}
		else
		{
			Debug.LogWarning(string.Format("Objective not found: {0}.  Unable to mark as complete.", keyObjective));
		}
	}

	public static void SetObjectiveStepComplete(string keyObjective, string keyStep)
	{
		if (ObjectivesUI.Instance.SetEntryDim(keyObjective, keyStep, true))
		{
			GalaxyProcessor.ObjectiveProgressFile.SaveValue(keyObjective, keyStep, true);
			if (!IsIgnoringChanges)
			{
				ObjectivesUI.Instance.SetCategoryChanged(keyObjective, true);
				ObjectivesUI.Instance.SetEntryChanged(keyObjective, keyStep, true);
			}
		}
		else
		{
			Debug.LogWarning(string.Format("Objective not found: {0}.  Unable to mark as complete.", keyObjective));
		}
	}

	public static bool DoesObjectiveExist(string keyObjective)
	{
		return ObjectivesUI.Instance.CategoryExists(keyObjective);
	}

	public static bool IsObjectiveActive(string keyObjective)
	{
		if (GameSaveFile.Get("GAME_VER", 0f) > 0.292f)
		{
			List<string> groupsByName = LogManager.LogDataFile.GetGroupsByName(keyObjective);
			if (groupsByName != null && groupsByName.Count > 0 && !LogManager.LogDataFile.GetValue(keyObjective, "COMPLETED", false))
			{
				return true;
			}
		}
		else
		{
			ObjectivesUI.CategoryItem categoryObject = ObjectivesUI.Instance.GetCategoryObject(keyObjective);
			if (categoryObject != null)
			{
				return !categoryObject.CatUIItem.IsDimmed;
			}
		}
		return false;
	}

	public static bool IsObjectiveStepActive(string keyObjective, string keyStep)
	{
		if (GameSaveFile.Get("GAME_VER", 0f) > 0.292f)
		{
			StepStateEnum value = (StepStateEnum)LogManager.LogDataFile.GetValue(keyObjective, keyStep, 0);
			if (value != StepStateEnum.Unknown && value < StepStateEnum.CompletedNew)
			{
				return true;
			}
		}
		else if (ObjectivesUI.Instance != null)
		{
			ObjectivesUI.EntryItem entryObject = ObjectivesUI.Instance.GetEntryObject(keyObjective, keyStep);
			if (entryObject != null)
			{
				if (entryObject.Parent.CatUIItem.IsDimmed)
				{
					return false;
				}
				return entryObject.EntryUIItem.CanBeShown && !entryObject.EntryUIItem.IsDimmed;
			}
		}
		return false;
	}

	public static bool AnyChangedItems()
	{
		return ObjectivesUI.Instance.AnyChangedEntries();
	}

	public static void MarkChangedItemViewed(string keyObjective, string keyStep)
	{
		if (completedStates == null || completedStates.Count <= 0)
		{
			return;
		}
		int count = completedStates.Count;
		for (int num = count - 1; num >= 0; num--)
		{
			if (completedStates[num].KeyObjective == keyObjective && completedStates[num].KeyStep == keyStep)
			{
				completedStates.RemoveAt(num);
				break;
			}
		}
	}
}
