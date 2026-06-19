using System.Collections.Generic;
using System.Text;
using FullInspector;
using JetBrains.Annotations;
using UnityEngine;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class ResearchProjectDefinition
	{
		[InspectorTooltip("Name of the project")]
		public LocalisedString NameLocalised;

		[InspectorTooltip("Description of the project")]
		public LocalisedString DescriptionLocalised;

		[InspectorTooltip("Text displayed when completing this project")]
		public LocalisedString CompletionMessageLocalised;

		[InspectorTooltip("Icon for the project")]
		public Sprite Icon;

		[InspectorTooltip("Material override for the Research Pod when active")]
		public Material ResearchPodMaterial;

		[InspectorTooltip("Number of points that must be contributed to this project to complete it")]
		public float ResearchPoints;

		[InspectorTooltip("How much does it cost to activate this project in a Research room")]
		public int GreenlightCost;

		[InspectorTooltip("Is this project repeatable?")]
		public bool Repeatable;

		[InspectorTooltip("Anything required in order to research this project")]
		public ResearchPrerequisite[] Prerequisites;

		[InspectorTooltip("What does the player gain when this project is completed?")]
		public IReward[] Rewards;

		[InspectorTooltip("Add points when this room is used for diagnosis or treatment")]
		public SharedInstance<RoomDefinition>[] AddPointsForRoom;

		[InspectorTooltip("Add points when this illness is diagnosed, treated or captured")]
		public SharedInstance<IllnessDefinition>[] AddPointsForIllness;

		[InspectorTooltip("If the research project is completed, then here's a radio line injects to try")]
		public Dictionary<SharedInstance<RadioDJDefinition>, RadioDJQuote> LineInjectionsOnCompletion;

		[InspectorTooltip("The chance of a line injection (we may not want to inject a line for every project!)")]
		public float ChanceOfLineInjection = 1f;

		public bool CanAddPoints(IllnessDefinition illness, RoomDefinition room)
		{
			if (room != null && !AddPointsForRoom.IsEmpty())
			{
				SharedInstance<RoomDefinition>[] addPointsForRoom = AddPointsForRoom;
				for (int i = 0; i < addPointsForRoom.Length; i++)
				{
					if (addPointsForRoom[i].Instance == room)
					{
						return true;
					}
				}
			}
			if (illness != null && !AddPointsForIllness.IsEmpty())
			{
				SharedInstance<IllnessDefinition>[] addPointsForIllness = AddPointsForIllness;
				for (int i = 0; i < addPointsForIllness.Length; i++)
				{
					if (addPointsForIllness[i].Instance == illness)
					{
						return true;
					}
				}
			}
			return false;
		}

		public bool PrerequisitesMet(Level level)
		{
			if (Prerequisites != null)
			{
				ResearchPrerequisite[] prerequisites = Prerequisites;
				for (int i = 0; i < prerequisites.Length; i++)
				{
					if (!prerequisites[i].IsValid(level))
					{
						return false;
					}
				}
			}
			return true;
		}

		public bool IsExcluded(Level level)
		{
			IReward[] rewards = Rewards;
			foreach (IReward obj in rewards)
			{
				RewardRoom rewardRoom = obj as RewardRoom;
				RewardRoomItem rewardRoomItem = obj as RewardRoomItem;
				RewardRoomItemUpgrade rewardRoomItemUpgrade = obj as RewardRoomItemUpgrade;
				if (rewardRoom != null)
				{
					RoomDefinition instance = rewardRoom.Definition.Instance;
					if (level.Metagame.HasUnlocked(instance))
					{
						return true;
					}
					if (instance.DlcPackRequired.NotNull() && !DLCUtils.IsDLCInstalled(instance.DlcPackRequired.Instance))
					{
						return true;
					}
				}
				else if (rewardRoomItem != null)
				{
					RoomItemDefinition instance2 = rewardRoomItem.Definition.Instance;
					if (level.Metagame.HasUnlocked(instance2))
					{
						return true;
					}
					if (instance2.DlcPackRequired.NotNull() && !DLCUtils.IsDLCInstalled(instance2.DlcPackRequired.Instance))
					{
						return true;
					}
				}
				else if (rewardRoomItemUpgrade != null && level.Metagame.HasUnlocked(rewardRoomItemUpgrade.Definition.Instance))
				{
					return true;
				}
			}
			return false;
		}

		public string GetPrerequistesString(string delimiter = "\n")
		{
			if (Prerequisites == null || Prerequisites.Length == 0)
			{
				return string.Empty;
			}
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < Prerequisites.Length; i++)
			{
				string value = Prerequisites[i].Description();
				if (!string.IsNullOrEmpty(value))
				{
					stringBuilder.Append(value);
					if (i < Prerequisites.Length - 1)
					{
						stringBuilder.Append(delimiter);
					}
				}
			}
			return stringBuilder.ToString();
		}
	}
}
