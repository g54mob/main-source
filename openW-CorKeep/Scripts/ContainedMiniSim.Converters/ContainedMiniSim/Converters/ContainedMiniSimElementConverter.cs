using ContainedMiniSim.Authoring;
using ContainedMiniSim.Components;
using Pug.Conversion;

namespace ContainedMiniSim.Converters
{
	public class ContainedMiniSimElementConverter : SingleAuthoringComponentConverter<ContainedMiniSimElementAuthoring>
	{
		protected override void Convert(ContainedMiniSimElementAuthoring authoring)
		{
			EnsureHasComponent<ContainedMiniSimDimensionsCD>();
			EnsureHasComponent<ContainedMiniSimElementVisualCD>();
			EnsureHasComponent<RandomCD>();
		}
	}
}
