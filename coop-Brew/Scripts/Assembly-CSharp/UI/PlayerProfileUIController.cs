using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Brewery.CombatSystem;
using Brewery.Pee;
using Brewery.Player;
using Brewery.Skills;
using Player;
using Synty.AnimationBaseLocomotion.Samples.InputSystem;
using UnityEngine;
using UnityEngine.UIElements;

namespace UI
{
	[RequireComponent(typeof(UIDocument))]
	public class PlayerProfileUIController : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CTryResolveMaxWidths_003Ed__76 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public PlayerProfileUIController _003C_003E4__this;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CTryResolveMaxWidths_003Ed__76(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		private const string NonBlockingCursorSourceId = "PlayerProfileUI";

		[Header("UI Document")]
		[SerializeField]
		private UIDocument uiDocument;

		[Header("Animation Settings")]
		[Tooltip("Speed of health bar lerp (pixels/second)")]
		[SerializeField]
		private float healthBarSpeed;

		[Tooltip("Delay before trail bar starts following (seconds)")]
		[SerializeField]
		private float trailDelay;

		[Tooltip("Speed of trail bar lerp (pixels/second)")]
		[SerializeField]
		private float trailBarSpeed;

		[Header("Warning Thresholds")]
		[Tooltip("Health percentage to trigger low health warning (0-1)")]
		[Range(0f, 1f)]
		[SerializeField]
		private float lowHealthThreshold;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		private VisualElement profileRoot;

		private Label moneyAmountLabel;

		private VisualElement moneySection;

		private VisualElement healthSection;

		private VisualElement healthBarCurrent;

		private VisualElement healthBarTrail;

		private VisualElement healthBarRegen;

		private Label healthTextLabel;

		private VisualElement staminaSection;

		private VisualElement staminaBarCurrent;

		private VisualElement staminaBarTrail;

		private Label staminaTextLabel;

		private VisualElement peeSection;

		private VisualElement peeBarCurrent;

		private VisualElement peeBarTrail;

		private Label peeTextLabel;

		private VisualElement peeBarContainer;

		private VisualElement skillProgressSection;

		private VisualElement skillProgressBarCurrent;

		private VisualElement skillProgressBarTrail;

		private VisualElement skillProgressBarContainer;

		private Label skillProgressTextLabel;

		private Label skillPointsValueLabel;

		private Label skillPointsHintLabel;

		private PlayerCurrency playerCurrency;

		private PlayerHealthController playerHealth;

		private SimpleCombatController combatController;

		private PlayerSkillData localPlayerSkillData;

		private PeeController peeController;

		private float currentHealthWidth;

		private float targetHealthWidth;

		private float trailHealthWidth;

		private float targetTrailHealthWidth;

		private float regenHealthWidth;

		private float targetRegenHealthWidth;

		private float trailDelayTimer;

		private bool isRegenerating;

		private float currentStaminaWidth;

		private float targetStaminaWidth;

		private float trailStaminaWidth;

		private float targetTrailStaminaWidth;

		private float staminaTrailDelayTimer;

		private float currentPeeWidth;

		private float targetPeeWidth;

		private float trailPeeWidth;

		private float peeTrailDelayTimer;

		private bool peeUrgentActive;

		private float peeUrgentShakeTimer;

		private float currentSkillProgressWidth;

		private float targetSkillProgressWidth;

		private float trailSkillProgressWidth;

		private float skillProgressTrailDelayTimer;

		private float healthBarMaxWidth;

		private float staminaBarMaxWidth;

		private float peeBarMaxWidth;

		private float skillProgressBarMaxWidth;

		private bool maxWidthsResolved;

		private VisualElement healthBarContainer;

		private VisualElement staminaBarContainer;

		private float previousMoney;

		private float lastComponentSearchTime;

		private const float COMPONENT_SEARCH_INTERVAL = 1f;

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void OnLocalPlayerReady(InputReader reader)
		{
		}

		public void Show()
		{
		}

		public void Hide()
		{
		}

		private void Update()
		{
		}

		private void SetupUI()
		{
		}

		[IteratorStateMachine(typeof(_003CTryResolveMaxWidths_003Ed__76))]
		private IEnumerator TryResolveMaxWidths()
		{
			return null;
		}

		private void ResolveMaxWidthsFromLayout()
		{
		}

		private void FindPlayerComponents()
		{
		}

		private void OnClientConnected(ulong clientId)
		{
		}

		private void OnDestroy()
		{
		}

		private void OnMoneyChanged(float newAmount)
		{
		}

		private void UpdateMoneyDisplay(float amount)
		{
		}

		private void AnimateMoneyChange(bool isGain)
		{
		}

		private void OnHealthChanged(float currentHealth, float maxHealth)
		{
		}

		private void OnHealthDamaged(float oldHealth, float newHealth, float damageTaken)
		{
		}

		private void SetHealthBar(float currentHealth, float maxHealth)
		{
		}

		private void StartRegeneration(float targetPercent)
		{
		}

		private void UpdateHealthBarAnimations()
		{
		}

		private void UpdateStaminaBarAnimations()
		{
		}

		private void UpdatePeeBarAnimations()
		{
		}

		private void OnSkillPointsChanged(int newPoints)
		{
		}

		private void OnSkillProgressChanged(float currentProgress, int progressPerLevel)
		{
		}

		private void UpdateSkillPointsDisplay(int points)
		{
		}

		private void UpdateSkillProgressDisplay(float currentProgress, int progressPerLevel)
		{
		}

		private void UpdateSkillProgressBarAnimations()
		{
		}
	}
}
