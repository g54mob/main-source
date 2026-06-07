using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

namespace Helios.GUI
{
	public class WheelMenuController : MonoBehaviour
	{
		[CompilerGenerated]
		private sealed class _003CShowReward_003Ed__16 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public WheelMenuController _003C_003E4__this;

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
			public _003CShowReward_003Ed__16(int _003C_003E1__state)
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
		private sealed class _003CSpinTheWheel_003Ed__19 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public WheelMenuController _003C_003E4__this;

			public float maxAngle;

			public float time;

			private float _003Ctimer_003E5__2;

			private float _003CstartAngle_003E5__3;

			private int _003CanimationCurveNumber_003E5__4;

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
			public _003CSpinTheWheel_003Ed__19(int _003C_003E1__state)
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

		private const int FULL_CIRCLE = 360;

		[SerializeField]
		[Header("References")]
		private Image[] _imgRewards;

		[SerializeField]
		private GameObject _goRewardPopup;

		[SerializeField]
		private Image _imgRewardIcon;

		[SerializeField]
		private Animator _animator;

		[SerializeField]
		private Image _imgFocusLine;

		[SerializeField]
		private Button _btnTapToClose;

		[SerializeField]
		private Button TurnButton;

		[SerializeField]
		private GameObject Circle;

		[SerializeField]
		[Header("Config params")]
		private int _nbSpinTime;

		[SerializeField]
		private int _nbAnimationTime;

		[SerializeField]
		private List<AnimationCurve> animationCurves;

		private bool spinning;

		private float anglePerItem;

		private int itemNumber;

		private void Awake()
		{
		}

		[IteratorStateMachine(typeof(_003CShowReward_003Ed__16))]
		private IEnumerator ShowReward(int index)
		{
			return null;
		}

		private void Start()
		{
		}

		private void TurnWheel()
		{
		}

		[IteratorStateMachine(typeof(_003CSpinTheWheel_003Ed__19))]
		private IEnumerator SpinTheWheel(float time, float maxAngle)
		{
			return null;
		}
	}
}
