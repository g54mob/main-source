using System.Collections.Generic;
using Pug.Conversion;
using UnityEngine;

public class SalvageExtractablePostConverter : Converter
{
	public override void Convert(GameObject authoring)
	{
		List<ObjectCategoryTag> tags;
		if (authoring.TryGetComponent<EntityMonoBehaviourData>(out var component))
		{
			tags = component.objectInfo.tags;
		}
		else
		{
			if (!authoring.TryGetComponent<ObjectAuthoring>(out var component2))
			{
				return;
			}
			tags = component2.tags;
		}
		if (tags.Contains(ObjectCategoryTag.CanBeSalvaged))
		{
			ExtractableData data = new ExtractableData
			{
				extractableType = ExtractableType.Salvageable
			};
			AddComponentData(new ExtractableCD
			{
				extractableData = CreateAndAddSimpleBlobAsset(data)
			});
		}
	}
}
