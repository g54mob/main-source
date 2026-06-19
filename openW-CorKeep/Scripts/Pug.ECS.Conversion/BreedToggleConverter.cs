using Pug.Conversion;
using UnityEngine.Scripting;

[Preserve]
public class BreedToggleConverter : SingleAuthoringComponentConverter<BreedToggleAuthoring>
{
	protected override void Convert(BreedToggleAuthoring authoring)
	{
		EnsureHasComponent<BreedToggleCD>();
	}
}
