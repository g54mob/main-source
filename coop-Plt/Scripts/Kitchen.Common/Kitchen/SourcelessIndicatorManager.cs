using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	public abstract class SourcelessIndicatorManager<T> : IndicatorManager where T : struct, IComponentData
	{
		protected override void Initialise()
		{
		}

		protected override EntityQuery GetCandidateQuery()
		{
			return default(EntityQuery);
		}

		protected override void OnUpdate()
		{
			if (TryGetSingletonEntity<T>(out var value))
			{
				if (ShouldLoseIndicator(default(Entity)))
				{
					DestroyIndicator(value, default(Entity));
				}
				return;
			}
			value = CreateIndicator(default(Entity));
			if (value != default(Entity))
			{
				base.EntityManager.AddComponentData(value, new CHasIndicator
				{
					Indicator = value
				});
			}
			else
			{
				Debug.LogWarning($"Failed to create indicator ({this})");
			}
		}

		protected override Entity CreateIndicator(Entity source)
		{
			Entity entity = base.CreateIndicator(default(Entity));
			base.EntityManager.AddComponent<T>(entity);
			return entity;
		}

		protected internal override void OnCreateForCompiler()
		{
			base.OnCreateForCompiler();
		}
	}
}
