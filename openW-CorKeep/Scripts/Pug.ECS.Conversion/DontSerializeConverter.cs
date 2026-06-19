using Pug.Conversion;

public class DontSerializeConverter : SingleAuthoringComponentConverter<DontSerializeAuthoring>
{
	protected override void Convert(DontSerializeAuthoring authoring)
	{
		EnsureHasComponent<DontSerializeCD>();
	}
}
