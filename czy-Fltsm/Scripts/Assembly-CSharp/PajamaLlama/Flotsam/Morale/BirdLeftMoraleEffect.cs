using System;
using I2.Loc;
using UnityEngine;

namespace PajamaLlama.Flotsam.Morale
{
	[CreateAssetMenu(menuName = "Flotsam/Agent/Morale/Effects/Bird Left")]
	public class BirdLeftMoraleEffect : SecondsTimedMoraleEffect
	{
		[Serializable]
		public class BirdLeftPersistentData : SecondsTimedPersistentData
		{
			public BirdLeftPersistentData(BirdLeftMoraleEffect moraleEffect)
				: base(moraleEffect)
			{
			}
		}

		[SerializeField]
		private int _modifier;

		[SerializeField]
		private LocalizedString _description = "";

		[SerializeField]
		private Sprite _icon;

		public override void Initialize(Agent agent, MoraleEffect properties)
		{
			base.Initialize(agent, properties);
			GameEventDispatcher.AddListener(GameEventType.BirdRemovedFromCommunity, OnLeave);
		}

		public override void Destroy()
		{
			GameEventDispatcher.RemoveListener(GameEventType.BirdRemovedFromCommunity, OnLeave);
		}

		private void OnLeave(GameEvent gameEvent)
		{
			if (_agent.Community.IsPlayerCommunity() && gameEvent is BirdEvent birdEvent && birdEvent.Bird.Community.IsPlayerCommunity())
			{
				Activate();
			}
		}

		protected override void Activate()
		{
			base.Activate();
		}

		protected override void Deactivate()
		{
			base.Deactivate();
		}

		public override bool IsActive()
		{
			return base.IsActive();
		}

		public override int ReturnModifier()
		{
			return _modifier;
		}

		public override string ReturnDescription()
		{
			return _description;
		}

		public override Sprite ReturnSprite()
		{
			return _icon;
		}

		public override bool TryReturnAttributeEffect(out DrifterAttributesEffect effect)
		{
			effect = null;
			return false;
		}

		public override void Restore(BasePersistentData persistentData)
		{
			base.Restore(persistentData);
			if (!persistentData.TryReturnCast<BirdLeftPersistentData>(out var _))
			{
				throw new NotImplementedException();
			}
		}

		public override BasePersistentData ReturnPersistentData()
		{
			return new BirdLeftPersistentData(this);
		}
	}
}
