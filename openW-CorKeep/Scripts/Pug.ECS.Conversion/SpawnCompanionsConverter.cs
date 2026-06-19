using Pug.Conversion;
using UnityEngine;

public class SpawnCompanionsConverter : SingleAuthoringComponentConverter<SpawnCompanionsAuthoring>
{
	protected override void Convert(SpawnCompanionsAuthoring authoring)
	{
		EnsureHasBuffer<CompanionEntityBuffer>();
		foreach (GameObject companion in authoring.companions)
		{
			AddToBuffer(new CompanionEntityBuffer
			{
				Value = GetPrefabDependency(companion),
				SpawnOffset = authoring.spawnOffset
			});
		}
		if (authoring.follow)
		{
			EnsureHasComponent<UpdateCompanionTranslationCD>();
		}
	}
}
