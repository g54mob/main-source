using Pug.Conversion;

public class HasSpawnPointConverter : SingleAuthoringComponentConverter<HasSpawnPointAuthoring>
{
	protected override void Convert(HasSpawnPointAuthoring authoring)
	{
		EnsureHasComponent<HasSpawnPointCD>();
	}
}
