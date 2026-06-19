using Pug.Conversion;

namespace Pug.Automation
{
	public class CritterCatcherCatchableConverter : SingleAuthoringComponentConverter<CritterCatcherCatchableAuthoring>
	{
		protected override void Convert(CritterCatcherCatchableAuthoring authoring)
		{
			EnsureHasComponent<CritterCatcherCatchableCD>();
		}
	}
}
