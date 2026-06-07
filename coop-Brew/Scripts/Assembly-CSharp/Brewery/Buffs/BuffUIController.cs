using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

namespace Brewery.Buffs
{
	[RequireComponent(typeof(UIDocument))]
	public class BuffUIController : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CDelayedInit_003Ed__15 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public BuffUIController _003C_003E4__this;

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
			public _003CDelayedInit_003Ed__15(int _003C_003E1__state)
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

		[Header("UI Templates")]
		[Tooltip("UXML template for individual buff icons.")]
		[SerializeField]
		private VisualTreeAsset buffIconTemplate;

		[Header("Animation")]
		[Tooltip("Duration of apply/expire animations in seconds.")]
		[SerializeField]
		private float animationDuration;

		[Tooltip("Time threshold (seconds) for 'low time' warning styling.")]
		[SerializeField]
		private float lowTimeThreshold;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		private UIDocument uiDocument;

		private VisualElement buffRoot;

		private Dictionary<string, VisualElement> buffIcons;

		private Dictionary<string, float> applyingBuffs;

		private Dictionary<string, float> expiringBuffs;

		private bool isInitialized;

		private bool isSubscribed;

		private void Awake()
		{
		}

		private void OnEnable()
		{
		}

		private void TrySubscribeToBuffManager()
		{
		}

		private void OnDisable()
		{
		}

		[IteratorStateMachine(typeof(_003CDelayedInit_003Ed__15))]
		private IEnumerator DelayedInit()
		{
			return null;
		}

		private void Update()
		{
		}

		private void HandleBuffApplied(ulong clientId, ActiveBuff buff)
		{
		}

		private void HandleBuffRefreshed(ulong clientId, ActiveBuff buff)
		{
		}

		private void HandleBuffExpired(ulong clientId, string catalystId)
		{
		}

		private void CreateBuffIcon(ActiveBuff buff)
		{
		}

		private void OnBuffIconMouseEnter(string catalystId, MouseEnterEvent evt)
		{
		}

		private void OnBuffIconMouseLeave()
		{
		}

		private void RemoveBuffIcon(string catalystId)
		{
		}

		private void UpdateBuffIconTime(VisualElement icon, ActiveBuff buff)
		{
		}

		private void UpdateBuffTimers()
		{
		}

		private void UpdateAnimations()
		{
		}

		private void RefreshAllBuffs()
		{
		}

		private bool IsLocalPlayer(ulong clientId)
		{
			return false;
		}

		private ulong GetLocalClientId()
		{
			return 0uL;
		}

		private string FormatTime(float seconds)
		{
			return null;
		}

		private string GetBuffTypeClass(BuffType type)
		{
			return null;
		}
	}
}
