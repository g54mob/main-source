using Pug.Conversion;

public class AreaLevelConverter : SingleAuthoringComponentConverter<AreaLevelAuthoring>
{
	protected override void Convert(AreaLevelAuthoring authoring)
	{
		AddComponentData(new LevelCD
		{
			level = authoring.level,
			areaLevel = authoring.areaLevel
		});
	}
}
