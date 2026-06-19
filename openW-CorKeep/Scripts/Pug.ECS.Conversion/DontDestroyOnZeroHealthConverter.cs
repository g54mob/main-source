using Pug.Conversion;

public class DontDestroyOnZeroHealthConverter : SingleAuthoringComponentConverter<DontDestroyOnZeroHealthAuthoring>
{
	protected override void Convert(DontDestroyOnZeroHealthAuthoring authoring)
	{
		EnsureHasComponent<DontDestroyOnZeroHealthCD>();
		if (authoring.animate)
		{
			EnsureHasComponent<AnimateDontDestroyOnZeroHealthCD>();
		}
	}
}
