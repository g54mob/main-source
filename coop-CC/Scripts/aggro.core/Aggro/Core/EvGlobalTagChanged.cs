using UnityEngine;

namespace Aggro.Core
{
	[HideInInspector]
	public struct EvGlobalTagChanged : IEntityEvent, IEntityTyped
	{
		public Entity entity;
	}
}
