using System.Collections.Generic;
using System.Runtime.InteropServices;
using Aggro.Core;
using Aggro.Core.Networking;
using Mirror;
using UnityEngine;

public class ActionOnStacked : NetworkEntityBehaviourBase
{
	public bool healOnStacked;

	public bool damageActivateOnStacked = true;

	[Space]
	[Min(0f)]
	public float durationBeforeAction = 1f;

	public bool preventActionWhenDamaged;

	public bool damageSelfWithAction;

	private static List<Entity> _entities = new List<Entity>();

	private Timer _timer;

	[SyncVar]
	private Entity _performingOn;

	public bool isPerformingAction => _performingOn.Exists();

	public Entity performingOn => _performingOn;

	public Entity Network_performingOn
	{
		get
		{
			return _performingOn;
		}
		[param: In]
		set
		{
			GeneratedSyncVarSetter(value, ref _performingOn, 1uL, null);
		}
	}

	protected override void OnEntityCreated()
	{
		_timer.SetTimer(durationBeforeAction);
	}

	protected override void OnUpdateSimulation()
	{
		if (!base.isServer)
		{
			return;
		}
		Grabbable obj2;
		if (preventActionWhenDamaged && base.entity.TryGetObject<BoxHealth>(out var obj) && obj.isDamaged)
		{
			Network_performingOn = Entity.invalid;
			_timer.SetTimer(durationBeforeAction);
		}
		else if (base.entity.TryGetObject<Grabbable>(out obj2))
		{
			if (obj2.isInStack && !obj2.isBase)
			{
				bool flag = false;
				int num = obj2.ServerGetStackIndex();
				_entities.Clear();
				obj2.GetStack(_entities);
				Entity network_performingOn = _entities[num - 1];
				if (healOnStacked && network_performingOn.TryGetObject<BoxHealth>(out obj) && obj.isDamaged)
				{
					flag = true;
				}
				if (damageActivateOnStacked && network_performingOn.TryGetObject<BoxHealth>(out obj) && !obj.isDamaged)
				{
					flag = true;
				}
				if (flag)
				{
					_timer.DecrementTimer();
					Network_performingOn = network_performingOn;
					if (!_timer.IsFinished())
					{
						return;
					}
					if (healOnStacked && network_performingOn.TryGetObject<BoxHealth>(out obj) && obj.isDamaged)
					{
						obj.ServerHeal();
					}
					if (damageActivateOnStacked)
					{
						if (network_performingOn.TryGetObject<BoxHealth>(out obj) && !obj.isDamaged)
						{
							obj.RequestTakeDamage(DamageType.Damaged);
						}
						if (network_performingOn.TryGetObject<BoxActivator>(out var obj3))
						{
							obj3.RequestActivate(new ActivationContext(ActivationContextType.Impact));
						}
					}
				}
				else
				{
					_timer.SetTimer(durationBeforeAction);
					Network_performingOn = Entity.invalid;
				}
			}
			else
			{
				Network_performingOn = Entity.invalid;
			}
		}
		else
		{
			Network_performingOn = Entity.invalid;
		}
	}

	public override bool Weaved()
	{
		return true;
	}

	public override void SerializeSyncVars(NetworkWriter writer, bool forceAll)
	{
		base.SerializeSyncVars(writer, forceAll);
		if (forceAll)
		{
			writer.WriteEntity(_performingOn);
			return;
		}
		writer.WriteVarULong(syncVarDirtyBits);
		if ((syncVarDirtyBits & 1L) != 0L)
		{
			writer.WriteEntity(_performingOn);
		}
	}

	public override void DeserializeSyncVars(NetworkReader reader, bool initialState)
	{
		base.DeserializeSyncVars(reader, initialState);
		if (initialState)
		{
			GeneratedSyncVarDeserialize(ref _performingOn, null, reader.ReadEntity());
			return;
		}
		long num = (long)reader.ReadVarULong();
		if ((num & 1L) != 0L)
		{
			GeneratedSyncVarDeserialize(ref _performingOn, null, reader.ReadEntity());
		}
	}
}
