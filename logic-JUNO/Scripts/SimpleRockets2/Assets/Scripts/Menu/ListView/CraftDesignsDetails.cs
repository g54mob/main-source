using Assets.Scripts.Ui.Sharing.Upload.Craft;
using ModApi.Craft;
using ModApi.Math;
using Web.Client.Models.SimpleRockets;

namespace Assets.Scripts.Menu.ListView
{
	public class CraftDesignsDetails
	{
		private DetailsPropertyScript _deltaV;

		private DetailsPropertyScript _depth;

		private DetailsPropertyScript _height;

		private DetailsPropertyScript _mass;

		private DetailsPropertyScript _numStages;

		private DetailsPropertyScript _price;

		private DetailsPropertyScript _thrust;

		private DetailsPropertyScript _wetDryRatio;

		private DetailsPropertyScript _width;

		public CraftDesignsDetails(ListViewDetailsScript listViewDetails)
		{
			_price = listViewDetails.Widgets.AddProperty("Price");
			_mass = listViewDetails.Widgets.AddProperty("Mass");
			_height = listViewDetails.Widgets.AddProperty("Height");
			_width = listViewDetails.Widgets.AddProperty("Width");
			_depth = listViewDetails.Widgets.AddProperty("Depth");
			listViewDetails.Widgets.AddSpacer();
			_numStages = listViewDetails.Widgets.AddProperty("Stages");
			_deltaV = listViewDetails.Widgets.AddProperty("Total Delta V");
			_thrust = listViewDetails.Widgets.AddProperty("Total Thrust");
			_wetDryRatio = listViewDetails.Widgets.AddProperty("Wet Mass / Dry Mass");
		}

		public void UpdateDetails(string id, ICraftScript craftScript)
		{
			if (craftScript != null)
			{
				_price.ValueText = Units.GetPriceString(craftScript.Data.Price);
				_mass.ValueText = Units.GetMassString(craftScript.Mass);
				_height.ValueText = Units.GetDistanceString(craftScript.Data.Size.y);
				_width.ValueText = Units.GetDistanceString(craftScript.Data.Size.x);
				_depth.ValueText = Units.GetDistanceString(craftScript.Data.Size.z);
				_numStages.ValueText = craftScript.PrimaryCommandPod.NumStages.ToString();
				CraftDetailsModel craftDetailsModel = CraftDetailsHelper.GenerateCraftDetails(craftScript);
				_deltaV.ValueText = $"{craftDetailsModel.DeltaV:n0}m/s";
				_thrust.ValueText = Units.GetForceString(craftDetailsModel.TotalThrust * 0.01f);
				_wetDryRatio.ValueText = $"{craftDetailsModel.WetMass / craftDetailsModel.DryMass:0.0}";
			}
		}
	}
}
