using Pug.Conversion;
using Unity.Entities;

public class BiomesTableConverter : SingleAuthoringComponentConverter<BiomesTableAuthoring>
{
	protected override void Convert(BiomesTableAuthoring authoring)
	{
		uint num = 1u;
		foreach (BiomesTable.BiomeLayers biomeLayer in authoring.biomesTable.biomeLayers)
		{
			foreach (BiomesTable.BiomeParameters biomeParameter in biomeLayer.biomeParameters)
			{
				Entity entity = CreateAdditionalEntity();
				AddComponentData(entity, new BiomeParametersCD
				{
					Value = biomeParameter,
					ringLayerIndex = num
				});
			}
			num++;
		}
	}
}
