using Pug.Conversion;
using UnityEngine;

public class SpawnTickConverter : Converter
{
	public override void Convert(GameObject authoring)
	{
		if (TryGetActiveComponent<EntityMonoBehaviourData>(authoring, out var _) || TryGetActiveComponent<ObjectAuthoring>(authoring, out var _))
		{
			EnsureHasComponent<SpawnTickCD>();
		}
	}
}
