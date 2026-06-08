using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using Timberborn.EntitySystem;

namespace Timberborn.TickSystem
{
	public class TickableEntity
	{
		private readonly EntityComponent _entityComponent;

		private readonly ImmutableArray<MeteredTickableComponent> _tickableComponents;

		private readonly string _originalName;

		public Guid EntityId => _entityComponent.EntityId;

		public TickableEntity(EntityComponent entityComponent, IEnumerable<MeteredTickableComponent> tickableComponents, string originalName)
		{
			_entityComponent = entityComponent;
			_tickableComponents = tickableComponents.ToImmutableArray();
			_originalName = originalName;
		}

		public void Tick()
		{
			try
			{
				if (_entityComponent.GameObject.activeInHierarchy)
				{
					TickTickableComponents();
				}
			}
			catch (Exception innerException)
			{
				string text = $"Exception thrown while ticking entity {EntityId}";
				text = ((!_entityComponent) ? (text + " '" + _originalName + "' (destroyed)") : (text + " '" + _entityComponent.Name + "'"));
				throw new Exception(text, innerException);
			}
		}

		private void TickTickableComponents()
		{
			ImmutableArray<MeteredTickableComponent>.Enumerator enumerator = _tickableComponents.GetEnumerator();
			while (enumerator.MoveNext())
			{
				MeteredTickableComponent current = enumerator.Current;
				if (current.Enabled)
				{
					current.StartAndTick();
				}
			}
		}
	}
}
