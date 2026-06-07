using System;
using System.Runtime.Serialization;
using I2.Loc;
using UnityEngine;

namespace PajamaLlama.Flotsam.Morale
{
	[CreateAssetMenu(menuName = "Flotsam/Agent/Morale/Effects/Slept On Floor")]
	public class SleptOnFloorMoraleEffect : MoraleEffect
	{
		[Serializable]
		public class SleptOnFloorPersistentData : BasePersistentData
		{
			[OptionalField(VersionAdded = 2)]
			public int DaysOnFloor;

			public bool SleptOnGround;

			public SleptOnFloorPersistentData(SleptOnFloorMoraleEffect moraleEffect)
				: base(moraleEffect)
			{
				DaysOnFloor = moraleEffect.DaysOnFloor;
			}
		}

		[SerializeField]
		private int _modifier;

		[SerializeField]
		private LocalizedString _description = "";

		[SerializeField]
		private Sprite _icon;

		[SerializeField]
		private DrifterAttributesEffect[] _effects;

		public int DaysOnFloor { get; private set; }

		public DrifterAttributesEffect CurrentEffect { get; private set; }

		public override void Initialize(Agent agent, MoraleEffect properties)
		{
			base.Initialize(agent, properties);
			DaysOnFloor = 0;
			GameEventDispatcher.AddListener(GameEventType.AgentSleptOnGround, OnSleptOnFloor);
			GameEventDispatcher.AddListener(GameEventType.AgentSleptInHouse, OnSleptInHouse);
		}

		public override void Destroy()
		{
			GameEventDispatcher.RemoveListener(GameEventType.AgentSleptOnGround, OnSleptOnFloor);
			GameEventDispatcher.RemoveListener(GameEventType.AgentSleptInHouse, OnSleptInHouse);
		}

		private void OnSleptInHouse(GameEvent gameEvent)
		{
			if (gameEvent is AgentEvent agentEvent && agentEvent.Agent == _agent)
			{
				SetDaysOnFloor(--DaysOnFloor);
				Deactivate();
			}
		}

		private void OnSleptOnFloor(GameEvent gameEvent)
		{
			if (gameEvent is AgentEvent agentEvent && agentEvent.Agent == _agent)
			{
				SetDaysOnFloor(++DaysOnFloor);
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

		private void SetDaysOnFloor(int daysOnFloor)
		{
			DaysOnFloor = Mathf.Max(0, daysOnFloor);
			ClearCurrentEffect();
			SetCurrentEffect();
		}

		private void SetCurrentEffect()
		{
			if (MoraleEffect.TryReturnAttributeEffect(_effects, DaysOnFloor, out var currentStack, out var effect))
			{
				CurrentEffect = effect;
				DaysOnFloor = currentStack;
				_agent.Attributes.AddEffect(CurrentEffect);
			}
		}

		private void ClearCurrentEffect()
		{
			if (CurrentEffect != null)
			{
				_agent.Attributes.RemoveEffect(CurrentEffect);
				CurrentEffect = null;
			}
		}

		public override bool IsActive()
		{
			return DaysOnFloor > 0;
		}

		public override int ReturnModifier()
		{
			return _modifier;
		}

		public override string ReturnDescription()
		{
			return MoraleEffect.ReturnStackedDescription(_description, DaysOnFloor);
		}

		public override Sprite ReturnSprite()
		{
			return _icon;
		}

		public override bool TryReturnAttributeEffect(out DrifterAttributesEffect effect)
		{
			effect = CurrentEffect;
			return effect != null;
		}

		public override void Restore(BasePersistentData persistentData)
		{
			if (persistentData.TryReturnCast<SleptOnFloorPersistentData>(out var persistentData2))
			{
				DaysOnFloor = persistentData2.DaysOnFloor;
				SetCurrentEffect();
				return;
			}
			throw new NotImplementedException();
		}

		public override BasePersistentData ReturnPersistentData()
		{
			return new SleptOnFloorPersistentData(this);
		}
	}
}
