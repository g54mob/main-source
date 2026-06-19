using Pug.Conversion;

public class LeaveTrailConverter : SingleAuthoringComponentConverter<LeaveTrailAuthoring>
{
	protected override void Convert(LeaveTrailAuthoring authoring)
	{
		AddComponentData(new LeaveTrailCD
		{
			leaveTrail = authoring.leaveTrail,
			trails = authoring.trails,
			trailObjectID = authoring.trailObjectID
		});
	}
}
