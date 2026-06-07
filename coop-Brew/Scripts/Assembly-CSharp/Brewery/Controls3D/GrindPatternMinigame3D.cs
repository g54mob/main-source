using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Brewery.Minigames;
using Brewery.Stations;
using UnityEngine;

namespace Brewery.Controls3D
{
	public class GrindPatternMinigame3D : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CNextRoundAfterDelay_003Ed__45 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public GrindPatternMinigame3D _003C_003E4__this;

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
			public _003CNextRoundAfterDelay_003Ed__45(int _003C_003E1__state)
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

		[CompilerGenerated]
		private sealed class _003CResetAllColorsAfterDelay_003Ed__51 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public float delay;

			public GrindPatternMinigame3D _003C_003E4__this;

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
			public _003CResetAllColorsAfterDelay_003Ed__51(int _003C_003E1__state)
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

		[CompilerGenerated]
		private sealed class _003CResetColorAfterDelay_003Ed__50 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public float delay;

			public GrindPatternMinigame3D _003C_003E4__this;

			public int index;

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
			public _003CResetColorAfterDelay_003Ed__50(int _003C_003E1__state)
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

		[CompilerGenerated]
		private sealed class _003CShowSequenceCoroutine_003Ed__43 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public GrindPatternMinigame3D _003C_003E4__this;

			private int _003Ci_003E5__2;

			private int _003CbuttonIndex_003E5__3;

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
			public _003CShowSequenceCoroutine_003Ed__43(int _003C_003E1__state)
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

		[Header("Pattern Buttons")]
		[Tooltip("4 Button3D instances for the pattern grid")]
		[SerializeField]
		private Button3D[] patternButtons;

		[Tooltip("Renderers parallel with patternButtons, for color feedback")]
		[SerializeField]
		private Renderer[] patternRenderers;

		[Header("Colors")]
		[SerializeField]
		private Color idleColor;

		[SerializeField]
		private Color activeColor;

		[SerializeField]
		private Color correctColor;

		[SerializeField]
		private Color wrongColor;

		[Header("Rounds")]
		[Tooltip("Sequence length per difficulty tier (cycles after exhausted)")]
		[SerializeField]
		private int[] sequenceLengths;

		[Tooltip("How many rounds the player must WIN to complete the minigame.")]
		[SerializeField]
		private int targetRoundsWon;

		[Header("Timing")]
		[SerializeField]
		private float showDuration;

		[SerializeField]
		private float showGap;

		[SerializeField]
		private float correctFlashDuration;

		[SerializeField]
		private float wrongFlashDuration;

		[SerializeField]
		private float roundDelay;

		[Header("Rewards")]
		[Tooltip("Seconds added to processing timer per completed round.")]
		[SerializeField]
		private float patternTimeReward;

		private BaseBreweryStation activeStation;

		private bool isActive;

		private bool completed;

		private int currentRound;

		private int roundsWon;

		private GrindPatternSequence currentSequence;

		private bool inShowPhase;

		private bool inInputPhase;

		private Coroutine showCoroutine;

		private Coroutine flashCoroutine;

		private Coroutine roundCoroutine;

		private MaterialPropertyBlock[] propBlocks;

		public bool IsActive => false;

		public bool IsCompleted => false;

		public event Action<GrindPatternMinigame3D> OnMinigameCompleted
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<GrindPatternMinigame3D, int> OnRoundCompleted
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void Update()
		{
		}

		public void Bind(BaseBreweryStation station)
		{
		}

		public void Unbind()
		{
		}

		public void FullReset()
		{
		}

		private void StartRound(int roundIndex)
		{
		}

		[IteratorStateMachine(typeof(_003CShowSequenceCoroutine_003Ed__43))]
		private IEnumerator ShowSequenceCoroutine()
		{
			return null;
		}

		private void HandleButtonPressed(int buttonIndex)
		{
		}

		[IteratorStateMachine(typeof(_003CNextRoundAfterDelay_003Ed__45))]
		private IEnumerator NextRoundAfterDelay()
		{
			return null;
		}

		private void SetButtonColor(int index, Color color)
		{
		}

		private void SetAllButtonColors(Color color)
		{
		}

		private void FlashButton(int index, Color flashColor, float duration)
		{
		}

		private void FlashAllButtons(Color flashColor, float duration)
		{
		}

		[IteratorStateMachine(typeof(_003CResetColorAfterDelay_003Ed__50))]
		private IEnumerator ResetColorAfterDelay(int index, float delay)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CResetAllColorsAfterDelay_003Ed__51))]
		private IEnumerator ResetAllColorsAfterDelay(float delay)
		{
			return null;
		}

		private void StopAllMinigameCoroutines()
		{
		}

		private void OnDestroy()
		{
		}
	}
}
