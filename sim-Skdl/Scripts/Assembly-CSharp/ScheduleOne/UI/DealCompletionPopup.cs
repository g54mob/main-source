using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using ScheduleOne.Audio;
using ScheduleOne.DevUtilities;
using ScheduleOne.Economy;
using ScheduleOne.Quests;
using ScheduleOne.UI.Relations;
using TMPro;
using UnityEngine;

namespace ScheduleOne.UI
{
	public class DealCompletionPopup : Singleton<DealCompletionPopup>
	{
		[CompilerGenerated]
		private sealed class _003CPlayPopupRoutine_003Ed__21 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public DealCompletionPopup _003C_003E4__this;

			public Customer customer;

			public List<Contract.BonusPayment> bonuses;

			public float originalRelationshipDelta;

			public float basePayment;

			public float satisfaction;

			private float _003CpaymentLerpTime_003E5__2;

			private float _003CsatisfactionLerpTime_003E5__3;

			private float _003CendDelta_003E5__4;

			private float _003ClerpTime_003E5__5;

			private float _003Ci_003E5__6;

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
			public _003CPlayPopupRoutine_003Ed__21(int _003C_003E1__state)
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

		[Header("References")]
		public Canvas Canvas;

		public RectTransform Container;

		public CanvasGroup Group;

		public Animation Anim;

		public TextMeshProUGUI Title;

		public TextMeshProUGUI PaymentLabel;

		public TextMeshProUGUI SatisfactionValueLabel;

		public RelationCircle RelationCircle;

		public TextMeshProUGUI RelationshipLabel;

		public Gradient SatisfactionGradient;

		public AudioSourceController SoundEffect;

		public TextMeshProUGUI[] BonusLabels;

		[Header("Animations")]
		[SerializeField]
		private Animation _animation;

		private Coroutine routine;

		private AnimationState _animationState;

		public bool IsPlaying { get; protected set; }

		protected override void Awake()
		{
		}

		public void PlayPopup(Customer customer, float satisfaction, float originalRelationshipDelta, float basePayment, List<Contract.BonusPayment> bonuses)
		{
		}

		[IteratorStateMachine(typeof(_003CPlayPopupRoutine_003Ed__21))]
		private IEnumerator PlayPopupRoutine(Customer customer, float satisfaction, float originalRelationshipDelta, float basePayment, List<Contract.BonusPayment> bonuses)
		{
			return null;
		}

		private void SetRelationshipLabel(float delta)
		{
		}
	}
}
