using Pug.Conversion;

public class DisplayConditionAsBarWhenEquippedConverter : SingleAuthoringComponentConverter<DisplayConditionAsBarWhenEquippedAuthoring>
{
	protected override void Convert(DisplayConditionAsBarWhenEquippedAuthoring authoring)
	{
		AddComponentData(new DisplayConditionAsBarWhenEquippedCD
		{
			conditionID = authoring.conditionID
		});
	}
}
