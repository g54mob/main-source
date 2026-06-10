using System;
using NSEipix.Base;
using NSMedieval.Controllers;
using NSMedieval.Model;
using NSMedieval.Tools;
using NSMedieval.UI.Utils;
using UnityEngine;

namespace NSMedieval.Objectives
{
	[Serializable]
	public class ObjectiveTask
	{
		[SerializeField]
		private string id;

		[SerializeField]
		private ObjectiveTaskRequirement[] requirements;

		[SerializeField]
		private LocKeys[] locKeys;

		[SerializeField]
		private string[] conditions;

		[SerializeField]
		private bool isButton;

		[SerializeField]
		private string startGameEventOnClick;

		[SerializeField]
		private bool hidden;

		[SerializeField]
		private string completedTooltip;

		[NonSerialized]
		private ObjectiveTaskRequirementType requirementTagsCache;

		[NonSerialized]
		private bool requirementTagsInit;

		public string Id => id;

		public ObjectiveTaskRequirement[] Requirements => requirements;

		public string[] Conditions => conditions;

		public bool IsButton => isButton;

		public string StartGameEventOnClick => startGameEventOnClick;

		public bool Hidden => hidden;

		public ObjectiveTaskRequirementType RequirementTags
		{
			get
			{
				if (!requirementTagsInit)
				{
					requirementTagsCache = ObjectiveTaskRequirementType.None;
					if (requirements != null)
					{
						ObjectiveTaskRequirement[] array = requirements;
						foreach (ObjectiveTaskRequirement objectiveTaskRequirement in array)
						{
							requirementTagsCache |= objectiveTaskRequirement.Type;
						}
					}
					requirementTagsInit = true;
				}
				return requirementTagsCache;
			}
		}

		public override string ToString()
		{
			return id;
		}

		public string GetNameTextWithCheckmark(bool checkmarkValue)
		{
			return TextFormatting.GetCheckmarkIcon(checkmarkValue) + " " + GetNameText();
		}

		public string GetNameText()
		{
			return LocKeyUtils.GetName(locKeys).ToLocalized();
		}

		public string GetTooltipText()
		{
			return LocKeyUtils.GetInfo(locKeys).ToLocalized();
		}

		public string GetCompletedTooltipText()
		{
			return MonoSingleton<LocalizationController>.Instance.GetText(completedTooltip);
		}
	}
}
