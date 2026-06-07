using System.Collections.Generic;
using Assets.Scripts.Career;
using Assets.Scripts.Career.Contracts.Params;
using Assets.Scripts.Career.Exploration;
using Assets.Scripts.Career.Milestones;
using UnityEngine;

namespace Assets.Scripts.Menu.ListView.Career
{
	public class ExplorationDetails
	{
		private DetailsTextScript _description;

		private ListViewDetailsScript _details;

		private DetailsWidgetGroup _landmarksGroup;

		private DetailsWidgetGroup _milestonesGroup;

		public ExplorationDetails(ListViewDetailsScript listViewDetails)
		{
			_details = listViewDetails;
		}

		public void UpdateDetails(ExplorationNode node, MilestoneContext milestoneContext)
		{
			_landmarksGroup?.DestroyWidget();
			_landmarksGroup = null;
			_milestonesGroup?.DestroyWidget();
			_milestonesGroup = null;
			if (node.Landmarks.Count > 0)
			{
				_landmarksGroup = _details.Widgets.AddGroup();
				_landmarksGroup.AddHeader("LANDMARKS");
				foreach (ExplorationLandmark landmark in node.Landmarks)
				{
					DetailsStarScript detailsStarScript = _landmarksGroup.AddStar();
					detailsStarScript.Text = " •  " + landmark.Name;
					detailsStarScript.IsComplete = landmark.IsComplete;
					detailsStarScript.ResearchText = $"{landmark.Research}<size=80%>TP</size>";
					DetailsWidgetGroup toggleGroup = _landmarksGroup.AddGroup();
					if (!string.IsNullOrEmpty(landmark.Description))
					{
						toggleGroup.AddText(landmark.Description).Margin = new Vector4(20f, 0f, 0f, 0f);
						toggleGroup.Visible = false;
					}
					detailsStarScript.OnClick = delegate
					{
						toggleGroup.Visible = !toggleGroup.Visible;
					};
				}
				_landmarksGroup.AddSpacer();
			}
			List<Milestone> milestonesForPlanet = milestoneContext.GetMilestonesForPlanet(node.Name);
			if (milestonesForPlanet.Count <= 0)
			{
				return;
			}
			_milestonesGroup = _details.Widgets.AddGroup();
			_milestonesGroup.AddHeader("MILESTONES");
			foreach (Milestone milestone in milestonesForPlanet)
			{
				DetailsStarScript detailsStarScript2 = _milestonesGroup.AddStar();
				detailsStarScript2.Text = " •  " + milestone.Name;
				detailsStarScript2.SetProgressBar(milestone.TierPercentageComplete, milestone.ValueText, milestone.IsComplete);
				detailsStarScript2.IsComplete = milestone.IsComplete;
				if (milestone.CurrentTierIndex > 0)
				{
					detailsStarScript2.StarCountText = $"{milestone.CurrentTierIndex}";
				}
				DetailsWidgetGroup toggleGroup2 = _milestonesGroup.AddGroup();
				if (!string.IsNullOrEmpty(milestone.Description))
				{
					StringProcessor stringProcessor = new StringProcessor();
					if (milestone.Tier != null)
					{
						stringProcessor.SetParam("value", new ConstParam("value", milestone.Tier.Value.ToString()));
					}
					string text = milestone.Description;
					if (!string.IsNullOrEmpty(milestone.Tier?.Description))
					{
						text += "\n\n";
						text += milestone.Tier.Description;
					}
					toggleGroup2.AddText(stringProcessor.ProcessString(text)).Margin = new Vector4(20f, 0f, 0f, 0f);
					toggleGroup2.Visible = false;
				}
				DetailsMilestoneScript milestoneTiersWidget = null;
				detailsStarScript2.OnClick = delegate
				{
					toggleGroup2.Visible = !toggleGroup2.Visible;
					if (toggleGroup2.Visible)
					{
						milestoneTiersWidget = toggleGroup2.AddMilestone();
						milestoneTiersWidget.SetMilestone(milestone, indent: true);
					}
					else if (milestoneTiersWidget != null)
					{
						milestoneTiersWidget.DestroyWidget();
						milestoneTiersWidget = null;
					}
				};
			}
		}
	}
}
