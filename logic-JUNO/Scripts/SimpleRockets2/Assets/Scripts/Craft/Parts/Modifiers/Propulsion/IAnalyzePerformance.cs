using ModApi.Ui.Inspector;

namespace Assets.Scripts.Craft.Parts.Modifiers.Propulsion
{
	public interface IAnalyzePerformance
	{
		bool UsesMachNumber { get; }

		void OnGeneratePerformanceAnalysisModel(GroupModel groupModel);
	}
}
