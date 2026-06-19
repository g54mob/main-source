using Pug.Conversion;
using Unity.Entities;
using UnityEngine;

public class RandomConverter : Converter
{
	public override void Convert(GameObject authoring)
	{
		if (TryGetActiveComponent<EntityMonoBehaviourData>(authoring, out var _) || TryGetActiveComponent<ObjectAuthoring>(authoring, out var _) || TryGetActiveComponent<EntityPartAuthoring>(authoring, out var _))
		{
			EnsureHasComponent<RandomCD>();
			if (base.IsServer)
			{
				Entity entity = CreateAdditionalEntity();
				AddComponentData(entity, new InitializeRandomCD
				{
					EntityToInitialize = base.PrimaryEntity
				});
			}
		}
	}
}
