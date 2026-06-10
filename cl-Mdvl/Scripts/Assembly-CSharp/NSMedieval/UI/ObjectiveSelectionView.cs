using System;
using System.Collections.Generic;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using NSEipix;
using NSEipix.Repository;
using NSMedieval.Objectives;
using NSMedieval.Repository;
using UnityEngine;

namespace NSMedieval.UI
{
	public class ObjectiveSelectionView : MonoBehaviour
	{
		[SerializeField]
		private LayoutGroupView objectiveGroupView;

		private readonly List<ObjectiveSelectLayoutItemView> objectiveSelectionViews = new List<ObjectiveSelectLayoutItemView>();

		private Action<string, bool> onAllowedObjectivesChange;

		public void Initialize(HashSet<string> allowedObjectives, Action<string, bool> onAllowedObjectivesChange)
		{
			this.onAllowedObjectivesChange = onAllowedObjectivesChange;
			objectiveSelectionViews.SetAllActive(active: false);
			int num = 0;
			foreach (Objective allItem in Repository<ObjectiveRepository, Objective>.Instance.GetAllItems())
			{
				if (!allItem.HideInScenario)
				{
					ObjectiveSelectLayoutItemView next = objectiveSelectionViews.GetNext(objectiveGroupView);
					next.SetData(allItem.GetID(), allItem.GetNameLocalized(), allItem.GetTooltipLocalized(), allowedObjectives.Contains(allItem.GetID()), OnObjectiveToggle);
					next.Background.enabled = allowedObjectives.Contains(allItem.GetID());
					num++;
				}
			}
		}

		private void OnObjectiveToggle(string id, bool isOn)
		{
			bool isEnabled;
			FVLogTraceInterpolationHandler messageBuilder = new FVLogTraceInterpolationHandler(20, 2, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\UI\\View\\ObjectiveSelectionView.cs");
			if (isEnabled)
			{
				messageBuilder.AppendLiteral("Objective ");
				messageBuilder.AppendFormatted(id);
				messageBuilder.AppendLiteral(" allowed: ");
				messageBuilder.AppendFormatted(isOn);
			}
			Log.Trace(messageBuilder);
			onAllowedObjectivesChange(id, isOn);
		}
	}
}
