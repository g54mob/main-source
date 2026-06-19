using Pug.Conversion;

namespace Pug.Automation
{
	public class PugHarvestableSeedConverter : SingleAuthoringComponentConverter<AutomatedPlantableSeedAuthoring>
	{
		protected override void Convert(AutomatedPlantableSeedAuthoring authoring)
		{
			EnsureHasComponent<AutomatedPlantableSeedCD>();
		}
	}
}
