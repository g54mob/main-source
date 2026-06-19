using System;
using UnityEngine;

namespace Aggro.Core
{
	internal abstract class EntityBehaviourSystemBase : EntitySystemBase
	{
		private Type _behaviourType;

		private ObjectQuery _query;

		public Type behaviourType => _behaviourType;

		public override Color systemColor => Color.green;

		internal void Initialize(Type behaviour)
		{
			_behaviourType = behaviour;
		}

		protected override void OnCreateSystem()
		{
			EntityQueryFlags entityQueryFlags = EntityQueryFlags.EnabledEntities;
			EntityTypeManager.TypeInfo info = EntityTypeManager.GetInfo(_behaviourType);
			entityQueryFlags |= EntityQueryFlags.AliveEntities;
			if ((info.flags & EntityTypeManager.TypeFlag.UpdateWhenDying) != 0)
			{
				entityQueryFlags |= EntityQueryFlags.DyingEntities;
			}
			_query = base.entityManager.CreateObjectQuery(_behaviourType, entityQueryFlags);
		}

		protected sealed override void OnUpdateSystem()
		{
			_query.Run();
			int count = _query.count;
			for (int i = 0; i < count; i++)
			{
				IEntityBehaviourBase behaviour = (IEntityBehaviourBase)_query[i];
				try
				{
					OnUpdateBehaviour(behaviour);
				}
				catch (Exception exception)
				{
					Debug.LogException(exception);
				}
			}
		}

		protected abstract void OnUpdateBehaviour(IEntityBehaviourBase behaviour);
	}
}
