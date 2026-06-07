using I2.Loc;
using UnityEngine;

namespace PajamaLlama.Flotsam.Morale
{
	[CreateAssetMenu(menuName = "Flotsam/Agent/Morale/Effects/Researched")]
	public class ResearchMoraleEffect : SecondsTimedMoraleEffect
	{
		[SerializeField]
		private int _modifier;

		[SerializeField]
		private LocalizedString _description = "";

		[SerializeField]
		private Sprite _icon;

		public override void Initialize(Agent agent, MoraleEffect properties)
		{
			base.Initialize(agent, properties);
			GameEventDispatcher.AddListener(GameEventType.ResearchFinished, OnResearchCompleted);
		}

		public override void Destroy()
		{
			GameEventDispatcher.RemoveListener(GameEventType.ResearchFinished, OnResearchCompleted);
		}

		private void OnResearchCompleted(GameEvent gameEvent)
		{
			if (_agent.Community.IsPlayerCommunity())
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
	}
}
