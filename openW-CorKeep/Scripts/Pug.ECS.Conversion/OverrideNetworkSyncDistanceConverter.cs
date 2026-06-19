using Pug.Conversion;
using Unity.Mathematics;

public class OverrideNetworkSyncDistanceConverter : SingleAuthoringComponentConverter<OverrideNetworkSyncDistanceAuthoring>
{
	protected override void Convert(OverrideNetworkSyncDistanceAuthoring authoring)
	{
		float2 rect;
		if (float.IsInfinity(authoring.distance))
		{
			rect = authoring.distance;
		}
		else
		{
			int2 int5 = new int2(16, 9);
			float distance = authoring.distance;
			int num = int5.x * int5.x + int5.y * int5.y;
			float num2 = distance / math.sqrt(num);
			rect = new float2((float)int5.x * num2, (float)int5.y * num2);
		}
		AddComponentData(new OverrideGhostRelevancyCD
		{
			rect = rect
		});
	}
}
