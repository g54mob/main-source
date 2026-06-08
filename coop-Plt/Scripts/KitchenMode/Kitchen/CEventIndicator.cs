using System;
using Unity.Entities;
using UnityEngine;

namespace Kitchen
{
	[Serializable]
	public struct CEventIndicator : IComponentData
	{
		public EventType Event;

		public static void Request(EntityContext ctx, Vector3 position, EventType type)
		{
			Entity entity = ctx.CreateEntity();
			ctx.Set(entity, new CPosition(position));
			ctx.Set(entity, new CEventIndicatorRequest
			{
				Event = type
			});
			ctx.Set(entity, new CLifetime(10f));
		}
	}
}
