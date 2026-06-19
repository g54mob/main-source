using Pug.Conversion;

public class IsHabitableIdolConverter : SingleAuthoringComponentConverter<IsHabitableIdolAuthoring>
{
	protected override void Convert(IsHabitableIdolAuthoring authoring)
	{
		EnsureHasComponent<IsHabitableIdolCD>();
	}
}
