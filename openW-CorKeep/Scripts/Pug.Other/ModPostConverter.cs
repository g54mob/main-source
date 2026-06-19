using Pug.Conversion;
using Unity.Entities;
using UnityEngine;

public class ModPostConverter : PostConverter
{
	public override bool CanRunInStagingWorld => false;

	public override void PostConvert(GameObject authoring)
	{
		if (Application.isPlaying)
		{
			Entity entity = GetEntity(authoring);
			Manager.mod.Authoring.ObjectTypeAdded(entity, authoring, base.EntityManager);
		}
	}
}
