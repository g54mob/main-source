using I2.Loc;
using UnityEngine;

namespace PajamaLlama.Flotsam.Morale
{
	[CreateAssetMenu(menuName = "Flotsam/Agent/Morale/Effects/Distance Travelled")]
	public class DistanceTravelledMoraleEffect : SecondsTimedMoraleEffect
	{
		[SerializeField]
		private float _travelRequirement = 1000f;

		[SerializeField]
		private int _modifier;

		[SerializeField]
		private LocalizedString _description = "";

		[SerializeField]
		private Sprite _icon;

		public float CurrentDistance { get; private set; }

		public override void Initialize(Agent agent, MoraleEffect properties)
		{
			base.Initialize(agent, properties);
			GameEventDispatcher.AddListener(GameEventType.TownheartMoved, OnTownheartMoved);
		}

		public override void Destroy()
		{
			GameEventDispatcher.RemoveListener(GameEventType.TownheartMoved, OnTownheartMoved);
		}

		private void OnTownheartMoved(GameEvent gameEvent)
		{
			if (gameEvent is MovementEvent movementEvent && _agent.Community.IsPlayerCommunity())
			{
				CurrentDistance += movementEvent.Distance;
				if (CurrentDistance > _travelRequirement)
				{
					Activate();
				}
			}
		}

		protected override void Activate()
		{
			CurrentDistance = 0f;
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
	}
}
