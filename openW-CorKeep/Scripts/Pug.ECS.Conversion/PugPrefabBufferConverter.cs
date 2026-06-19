using Pug.Conversion;
using UnityEngine;

public class PugPrefabBufferConverter : SingleAuthoringComponentConverter<PugPrefabBufferAuthoring>
{
	protected override void Convert(PugPrefabBufferAuthoring authoring)
	{
		EnsureHasBuffer<PugPrefabBuffer>();
		foreach (GameObject prefab in authoring.prefabs)
		{
			AddToBuffer(new PugPrefabBuffer
			{
				Value = GetPrefabDependency(prefab)
			});
		}
	}
}
