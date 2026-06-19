using Pug.Conversion;
using Pug.UnityExtensions;
using Unity.Mathematics;

public class SprinklerConverter : SingleAuthoringComponentConverter<SprinklerAuthoring>
{
	protected override void Convert(SprinklerAuthoring authoring)
	{
		Random rng = PugRandom.GetRng();
		AddComponentData(new SprinklerCD
		{
			timer = rng.NextFloat(0.5f, 1f)
		});
	}
}
