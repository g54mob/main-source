using Interaction;
using Outlines.Components;
using Pug.Conversion;
using Unity.Entities;
using UnityEngine;

namespace Outlines.Converters
{
	public class OutlinePostConverter : PostConverter
	{
		public override void PostConvert(GameObject authoring)
		{
			Entity entity = GetEntity(authoring);
			if (base.EntityManager.HasComponent<InteractableCD>(entity) || base.EntityManager.HasComponent<IsCloneCD>(entity) || base.EntityManager.HasComponent<HealthCD>(entity))
			{
				base.EntityManager.AddComponentData(entity, default(VisualOutlineCD));
			}
		}
	}
}
