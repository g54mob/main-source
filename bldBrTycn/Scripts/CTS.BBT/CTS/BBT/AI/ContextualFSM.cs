using CTS.Core;
using CTS.UI;
using NaughtyAttributes;
using UnityEngine;

namespace CTS.BBT.AI
{
	public sealed class ContextualFSM : FSM<Agent>
	{
		[Header("Normal Settings")]
		[SerializeField]
		[Label("Speed")]
		private float _speedNormal = 2f;

		[Header("Unconscious Settings")]
		[SerializeField]
		[Label("Duration")]
		private float _unconsciousDuration = 3f;

		[Header("Holding Settings")]
		[SerializeField]
		[Label("Minimum Speed")]
		private float _speedHolding = 0.5f;

		[SerializeField]
		private float _weightForMinimumSpeed = 50f;

		[Header("Panicking Settings")]
		[SerializeField]
		[Label("Speed")]
		private float _speedPanicking = 4f;

		[SerializeField]
		private Material _emoteBackgroundMaterial;

		private static readonly int _unityGUIZTestMode = Shader.PropertyToID("unity_GUIZTestMode");

		private Material _materialInstance;

		private State<Agent> initState { get; set; } = new ContextualStateNormal(2f);

		[field: SerializeField]
		[field: NavArea(true)]
		public int PanicMoveMask { get; private set; }

		[field: SerializeField]
		public Sprite EmoteAlertSprite { get; private set; }

		[field: SerializeField]
		public Sprite EmotePreAlertSprite { get; private set; }

		[field: SerializeField]
		public Sprite EmoteRunSprite { get; private set; }

		[field: SerializeField]
		public Sprite EmoteBackgroundSprite { get; private set; }

		[field: SerializeField]
		public PaletteData EmoteBackgroundColor { get; private set; }

		public Material EmoteBackgroundMaterial
		{
			get
			{
				if ((bool)_materialInstance)
				{
					return _materialInstance;
				}
				_materialInstance = new Material(_emoteBackgroundMaterial);
				_materialInstance.SetInt(_unityGUIZTestMode, 8);
				return _materialInstance;
			}
		}

		protected override State<Agent> GetInitState()
		{
			return initState;
		}

		protected override void OnEnabled()
		{
			base.OnEnabled();
			base.parent.Tags.RemoveTag(EAgentTag.IsUnconscious);
			if (base.CurrentState is ContextualStateUnconscious contextualStateUnconscious)
			{
				contextualStateUnconscious.ResetTimer();
			}
		}

		public void SetStateNormal()
		{
			if (!CurrentStateEquals<ContextualStateNormal>())
			{
				SetState(new ContextualStateNormal(_speedNormal));
			}
		}

		public void SetStateUnconscious(bool shouldPanic = false)
		{
			SetStateUnconscious(_unconsciousDuration, shouldPanic);
		}

		public void SetStateUnconscious(float p_duration, bool shouldPanic = false)
		{
			if (!CurrentStateEquals<ContextualStateDead>())
			{
				if (base.CurrentState is ContextualStateUnconscious contextualStateUnconscious)
				{
					contextualStateUnconscious.ResetTimer();
				}
				else
				{
					SetState(new ContextualStateUnconscious(p_duration, shouldPanic));
				}
			}
		}

		public void SetStateStuck()
		{
			if (!CurrentStateEquals<ContextualStateStuck>())
			{
				SetState<ContextualStateStuck>();
			}
		}

		public void SetStatePanicking()
		{
			if (!CurrentStateEquals<ContextualStatePanicking, ContextualStateDead>())
			{
				SetState(new ContextualStatePanicking(_speedPanicking));
			}
		}

		public void SetStateDying(float p_duration)
		{
			if (!CurrentStateEquals<ContextualStateDying, ContextualStateDead>())
			{
				SetState(new ContextualStateDying(p_duration));
			}
		}

		public void SetStateDead()
		{
			if (!CurrentStateEquals<ContextualStateDead>())
			{
				SetState(new ContextualStateDead());
			}
		}

		public bool CurrentStateEquals<TState>() where TState : ContextualState
		{
			return base.CurrentState is TState;
		}

		public bool CurrentStateEquals<TState1, TState2>() where TState1 : ContextualState where TState2 : ContextualState
		{
			State<Agent> currentState = base.CurrentState;
			return currentState is TState1 || currentState is TState2;
		}

		public bool CurrentStateEquals<TState1, TState2, TState3>() where TState1 : ContextualState where TState2 : ContextualState where TState3 : ContextualState
		{
			State<Agent> currentState = base.CurrentState;
			return currentState is TState1 || currentState is TState2 || currentState is TState3;
		}
	}
}
