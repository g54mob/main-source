using Assets.Scripts.Career;
using Assets.Scripts.Career.Contracts.Params;
using Assets.Scripts.Career.Milestones;

namespace Assets.Scripts.Menu.ListView.Career
{
	public class MilestonesDetails
	{
		private DetailsTextScript _description;

		private DetailsMilestoneScript _milestone;

		public MilestonesDetails(ListViewDetailsScript listViewDetails)
		{
			_description = listViewDetails.Widgets.AddText("Description");
			_milestone = listViewDetails.Widgets.AddMilestone();
		}

		public void UpdateDetails(Milestone milestone)
		{
			StringProcessor stringProcessor = new StringProcessor();
			if (milestone.Tier != null)
			{
				stringProcessor.SetParam("value", new ConstParam("value", milestone.Tier.Value.ToString()));
				string text = stringProcessor.ProcessString(milestone.Description);
				if (!string.IsNullOrWhiteSpace(milestone.Tier.Description))
				{
					text += "\n\n";
					text += stringProcessor.ProcessString(milestone.Tier.Description);
				}
				_description.Text = text;
			}
			else
			{
				_description.Text = "This milestone is complete. Congratulations!";
			}
			_milestone.SetMilestone(milestone, indent: false);
		}
	}
}
