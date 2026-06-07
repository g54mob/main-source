using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Brewery.Calendar;
using Brewery.Core;
using UnityEngine;
using UnityEngine.UIElements;

namespace Brewery.UI.Calendar
{
	[RequireComponent(typeof(UIDocument))]
	public class CalendarDayBannerController : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CAnimateIn_003Ed__39 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public CalendarDayBannerController _003C_003E4__this;

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
			public _003CAnimateIn_003Ed__39(int _003C_003E1__state)
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
		private sealed class _003CDelayedInit_003Ed__27 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public CalendarDayBannerController _003C_003E4__this;

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
			public _003CDelayedInit_003Ed__27(int _003C_003E1__state)
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

		[Header("Timing")]
		[Tooltip("Seconds the banner stays fully visible before leaving.")]
		[SerializeField]
		private float m_HoldSeconds;

		[Header("Toggles")]
		[Tooltip("When false, a day change won't trigger the banner.")]
		[SerializeField]
		private bool m_BannerEnabled;

		[Header("NPC Portrait Pools")]
		[Tooltip("Populated automatically by One-Click Setup. Icons from this list are picked deterministically by day index, so the same day shows the same face in MP.")]
		[SerializeField]
		private Texture2D[] m_BikerIcons;

		[SerializeField]
		private Texture2D[] m_WorkingClassIcons;

		[SerializeField]
		private Texture2D[] m_CorporateEliteIcons;

		[SerializeField]
		private Texture2D[] m_PriestsIcons;

		[SerializeField]
		private Texture2D[] m_PartySceneIcons;

		[SerializeField]
		private Texture2D m_FallbackIcon;

		private UIDocument _doc;

		private VisualElement _container;

		private VisualElement _iconElement;

		private Label _morningLbl;

		private Label _dayNameLbl;

		private Label _eventLbl;

		private Label _hintLbl;

		private Coroutine _showCoro;

		private bool _subscribed;

		private int _lastShownDayIndex;

		private static readonly string[] DayNames;

		public static CalendarDayBannerController Instance { get; private set; }

		private void Awake()
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		private void OnDestroy()
		{
		}

		[IteratorStateMachine(typeof(_003CDelayedInit_003Ed__27))]
		private IEnumerator DelayedInit()
		{
			return null;
		}

		private void BindUI()
		{
		}

		private void Update()
		{
		}

		private void TrySubscribe()
		{
		}

		private void Unsubscribe()
		{
		}

		private void HandleDayChanged(DayModifierSet today)
		{
		}

		public void ShowBanner(DayModifierSet today)
		{
		}

		private void ApplyContent(DayModifierSet today)
		{
		}

		private static FactionType? ResolveVisibleFaction(DayModifierSet today)
		{
			return null;
		}

		private Texture2D[] PoolForFaction(FactionType? f)
		{
			return null;
		}

		private static string PickTagline(string eventId, int dayIndex)
		{
			return null;
		}

		private static string FriendlyEventName(string id)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CAnimateIn_003Ed__39))]
		private IEnumerator AnimateIn()
		{
			return null;
		}
	}
}
