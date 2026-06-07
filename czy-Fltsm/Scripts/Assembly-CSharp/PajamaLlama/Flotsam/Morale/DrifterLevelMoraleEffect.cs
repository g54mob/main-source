using I2.Loc;
using UnityEngine;

namespace PajamaLlama.Flotsam.Morale
{
	[CreateAssetMenu(menuName = "Flotsam/Agent/Morale/Effects/Drifter Level")]
	public class DrifterLevelMoraleEffect : MoraleEffect
	{
		[SerializeField]
		private LocalizedString _description;

		[SerializeField]
		private Sprite _icon;

		[SerializeField]
		private int _drifterLevels = 10;

		[SerializeField]
		private float _maximumModifier = 50f;

		private int _modifier;

		public override void Initialize(Agent agent, MoraleEffect properties)
		{
			base.Initialize(agent, properties);
			agent.Attributes.LevelIncreasedEvent.AddListener(OnDrifterLevelIncreased);
			OnDrifterLevelIncreased();
		}

		public override void Destroy()
		{
			_agent?.Attributes.LevelIncreasedEvent.RemoveListener(OnDrifterLevelIncreased);
		}

		private void OnDrifterLevelIncreased()
		{
			_modifier = Mathf.RoundToInt(Mathf.Max(0f, _maximumModifier - _maximumModifier / (float)_drifterLevels * (float)_agent.Attributes.Level));
			base.UpdatedEvent.Invoke();
		}

		public override bool IsActive()
		{
			return 0 < _modifier;
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

		public override BasePersistentData ReturnPersistentData()
		{
			return null;
		}

		public override void Restore(BasePersistentData persistentData)
		{
		}
	}
}
