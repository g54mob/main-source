using Pug.Conversion;

public class MinionOrbitConverter : SingleAuthoringComponentConverter<MinionOrbitAuthoring>
{
	protected override void Convert(MinionOrbitAuthoring authoring)
	{
		AddComponentData(new MinionOrbitCD
		{
			radius = authoring.radius,
			orbitSpeed = authoring.orbitSpeed
		});
		AddComponentData(new MinionOrbitPosCD
		{
			index = 0
		});
	}
}
