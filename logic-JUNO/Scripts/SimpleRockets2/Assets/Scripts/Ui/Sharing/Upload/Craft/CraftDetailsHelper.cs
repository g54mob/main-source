using Assets.Scripts.Design.Staging;
using ModApi.Craft;
using ModApi.Craft.Parts;
using ModApi.Craft.Parts.Modifiers.Propulsion;
using Web.Client.Models.SimpleRockets;

namespace Assets.Scripts.Ui.Sharing.Upload.Craft
{
	public class CraftDetailsHelper
	{
		public static CraftDetailsModel GenerateCraftDetails(ICraftScript craftScript)
		{
			CraftDetailsModel craftDetailsModel = new CraftDetailsModel();
			GenerateStagingDetailsXml(craftScript, craftDetailsModel);
			foreach (PartData part in craftScript.Data.Assembly.Parts)
			{
				PartMass partMass = part.PartMass;
				craftDetailsModel.WetMass += partMass.Wet;
				craftDetailsModel.DryMass += partMass.Dry;
				IReactionEngine modifierWithInterface = part.PartScript.GetModifierWithInterface<IReactionEngine>();
				if (modifierWithInterface != null)
				{
					craftDetailsModel.TotalThrust += modifierWithInterface.MaximumThrust * 100f;
					craftDetailsModel.NumEngines++;
				}
			}
			craftDetailsModel.WetMass += craftDetailsModel.DryMass;
			craftDetailsModel.WetMass *= 100f;
			craftDetailsModel.DryMass *= 100f;
			craftDetailsModel.Price = craftScript.Data.Price;
			craftDetailsModel.SizeX = craftScript.Data.Size.x;
			craftDetailsModel.SizeY = craftScript.Data.Size.y;
			craftDetailsModel.SizeZ = craftScript.Data.Size.z;
			return craftDetailsModel;
		}

		private static void GenerateStagingDetailsXml(ICraftScript craftScript, CraftDetailsModel craftDetails)
		{
			StagingData stages = new StageCalculator(craftScript.PrimaryCommandPod).GetStages();
			foreach (StageAnalysis.Stage stage in StageAnalyzer.Analyze(craftScript, stages, 9.80665f).Stages)
			{
				CraftDetailsModel.StageDetailsModel item = new CraftDetailsModel.StageDetailsModel
				{
					BurnTime = stage.BurnTime,
					DeltaV = stage.DeltaV,
					EndingMass = stage.EndingMass,
					NumEngines = stage.NumEngines,
					NumParts = stage.NumParts,
					StageNumber = stage.StageNumber,
					StartingMass = stage.StartingMass,
					TotalThrust = stage.TotalThrust
				};
				craftDetails.Stages.Add(item);
				craftDetails.DeltaV += stage.DeltaV;
			}
		}
	}
}
