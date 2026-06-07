using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using FractureField.QuarryForeman;
using FractureField.Rocks;
using FractureField.UI.Components;
using FractureField.Upgrades;
using Reactivity;
using Reactivity.Unity.Components;
using UnityEngine;
using UnityEngine.EventSystems;

namespace FractureField.UI.CommandConsole
{
	public class CommandConsoleUpgradeRow : RComponent, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		[CompilerGenerated]
		private sealed class _003CAnimateClick_003Ed__32 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public CommandConsoleUpgradeRow _003C_003E4__this;

			private float _003Cduration_003E5__2;

			private float _003CelapsedTime_003E5__3;

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
			public _003CAnimateClick_003Ed__32(int _003C_003E1__state)
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
		private sealed class _003CAnimateHover_003Ed__30 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public CommandConsoleUpgradeRow _003C_003E4__this;

			public bool isHovering;

			private float _003CelapsedTime_003E5__2;

			private Vector3 _003CstartScale_003E5__3;

			private Vector3 _003CtargetScale_003E5__4;

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
			public _003CAnimateHover_003Ed__30(int _003C_003E1__state)
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
		private sealed class _003CAnimateTooltip_003Ed__31 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public CommandConsoleUpgradeRow _003C_003E4__this;

			public bool fadeIn;

			private float _003CelapsedTime_003E5__2;

			private float _003CstartAlpha_003E5__3;

			private float _003CtargetAlpha_003E5__4;

			private float _003Cduration_003E5__5;

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
			public _003CAnimateTooltip_003Ed__31(int _003C_003E1__state)
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

		[Header("Variables")]
		public bool IsForemanRow;

		[Header("References")]
		[SerializeField]
		private RText _title;

		[SerializeField]
		private CurrencyCost _currencyCost;

		[SerializeField]
		private CanvasGroup _tooltipCanvasGroup;

		[SerializeField]
		private RText _tooltipText;

		[SerializeField]
		private RectTransform _rowRectTransform;

		[SerializeField]
		private GameObject _costAndEffectGO;

		[SerializeField]
		private RText _maxText;

		[SerializeField]
		private RText _effectText;

		[SerializeField]
		private QuarryForemanAutomationType _foremanType;

		[SerializeField]
		private ToggleWithLabel _foremanToggle;

		[Header("Hover Animation")]
		[SerializeField]
		private float _hoverScale;

		[SerializeField]
		private float _hoverAnimationDuration;

		[SerializeField]
		private AnimationCurve _hoverAnimationCurve;

		[Header("Tooltip Animation")]
		[SerializeField]
		private float _tooltipFadeInDuration;

		[SerializeField]
		private float _tooltipFadeOutDuration;

		[SerializeField]
		private AnimationCurve _tooltipFadeCurve;

		private Coroutine _hoverCoroutine;

		private Coroutine _tooltipCoroutine;

		private Vector3 _originalScale;

		private RockLayerType _rockLayerType;

		public Ref<Upgrade> Upgrade { get; }

		protected override void Awake()
		{
		}

		public void Setup(RockLayerType rockLayerType, Upgrade upgrade)
		{
		}

		public void Setup(Upgrade upgrade)
		{
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
		}

		public void OnPointerExit(PointerEventData eventData)
		{
		}

		public void ClickedPurchase()
		{
		}

		[IteratorStateMachine(typeof(_003CAnimateHover_003Ed__30))]
		private IEnumerator AnimateHover(bool isHovering)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CAnimateTooltip_003Ed__31))]
		private IEnumerator AnimateTooltip(bool fadeIn)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CAnimateClick_003Ed__32))]
		private IEnumerator AnimateClick()
		{
			return null;
		}

		protected override void OnDisable()
		{
		}
	}
}
