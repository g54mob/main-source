using Pug.Conversion;

public class AttackableWIthMeleeConverter : SingleAuthoringComponentConverter<AttackableWithMeleeAuthoring>
{
	protected override void Convert(AttackableWithMeleeAuthoring authoring)
	{
		EnsureHasComponent<AttackableWithMeleeCD>();
	}
}
