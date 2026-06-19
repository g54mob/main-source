using System.Collections.Generic;
using FullInspector;
using JetBrains.Annotations;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.WithMembers)]
	public class SubGoalDefinitionCharacterUseItem : SubGoalDefinition
	{
		public SharedInstance<RoomItemDefinition> Item;

		public CharacterType CharacterType;

		public int ItemCount;

		[InspectorTooltip("Must include {[COUNT]} in the loc string, and then {[ITEM0]}, {[ITEM1]} etc for each item if using an ItemList (not required if not using a list of items)")]
		public LocalisedString GoalLocText;

		public List<SharedInstance<RoomItemDefinition>> ItemList = new List<SharedInstance<RoomItemDefinition>>();

		public override ObjectiveSubGoal CreateSubGoal(Objective owner)
		{
			return new SubGoalCharacterUseItem(owner, this);
		}

		public override string GoalText(Objective objective)
		{
			if (ItemList == null || ItemList.Count == 0)
			{
				if (GoalLocText.Term != null)
				{
					return GoalLocText.Translation.Replace("{[COUNT]}", StringUtils.FormatNumber(ItemCount));
				}
				return null;
			}
			string text = GoalLocText.Translation;
			LocalisationParams.Set("COUNT", ItemCount);
			int num = 0;
			foreach (SharedInstance<RoomItemDefinition> item in ItemList)
			{
				LocalisationParams.Set("ITEM" + num, item.Instance.GetLocalisedNamePlural(ItemCount));
				num++;
			}
			LocalisationParams.Localise(ref text);
			return text;
		}

		public override bool HasBeenAchieved(Level level)
		{
			return false;
		}
	}
}
