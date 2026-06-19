using System.Collections.Generic;
using FullInspector;
using I2.Loc;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.WithMembers)]
	public class SubGoalDefinitionBuildItem : SubGoalDefinition
	{
		public SharedInstance<RoomItemDefinition> Item;

		public int ItemCount;

		public bool IncludeExisting = true;

		public List<SharedInstance<RoomItemDefinition>> ItemList = new List<SharedInstance<RoomItemDefinition>>();

		[InspectorTooltip("Must include {[COUNT]} in the loc string, and then {[ITEM0]}, {[ITEM1]} etc for each item in ItemList")]
		public LocalisedString ItemListLocString;

		public override ObjectiveSubGoal CreateSubGoal(Objective owner)
		{
			return new SubGoalBuildItem(owner, this);
		}

		public override string GoalText(Objective objective)
		{
			if (ItemList == null || ItemList.Count == 0)
			{
				string text = ScriptLocalization.Challenges_SubGoals.BuildItem_Goal_CS;
				LocalisationParams.Set("COUNT", ItemCount);
				LocalisationParams.Set("ITEM", Item.Instance.GetLocalisedNamePlural(ItemCount));
				LocalisationParams.Localise(ref text);
				return text;
			}
			string text2 = ItemListLocString.Translation;
			LocalisationParams.Set("COUNT", ItemCount);
			int num = 0;
			foreach (SharedInstance<RoomItemDefinition> item in ItemList)
			{
				LocalisationParams.Set("ITEM" + num, item.Instance.GetLocalisedNamePlural(ItemCount));
				num++;
			}
			LocalisationParams.Localise(ref text2);
			return text2;
		}

		public override bool HasBeenAchieved(Level level)
		{
			if (ItemList == null || ItemList.Count == 0)
			{
				if (IncludeExisting)
				{
					return level.WorldState.GetRoomItemsOfType(Item.Instance).Count >= ItemCount;
				}
				return false;
			}
			int num = 0;
			foreach (SharedInstance<RoomItemDefinition> item in ItemList)
			{
				num += level.WorldState.GetRoomItemsOfType(item.Instance).Count;
			}
			if (IncludeExisting)
			{
				return num >= ItemCount;
			}
			return false;
		}
	}
}
