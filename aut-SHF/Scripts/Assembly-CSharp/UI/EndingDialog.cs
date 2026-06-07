using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using InputControl;
using Spine.Unity;
using UnityEngine;

namespace UI
{
	public class EndingDialog : BaseDialog
	{
		[Serializable]
		private class SideImageContentInfo
		{
			public eEndrollImagePos m_Pos;

			public Transform m_Transform;
		}

		[CompilerGenerated]
		private sealed class _003CCorAnimation_003Ed__30 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public EndingDialog _003C_003E4__this;

			private List<StaffrollItem>.Enumerator _003C_003E7__wrap1;

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
			public _003CCorAnimation_003Ed__30(int _003C_003E1__state)
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

			private void _003C_003Em__Finally1()
			{
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[CompilerGenerated]
		private sealed class _003CWaitWithSkip_003Ed__33 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public float _time;

			public EndingDialog _003C_003E4__this;

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
			public _003CWaitWithSkip_003Ed__33(int _003C_003E1__state)
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

		[SerializeField]
		private StaffrollItem m_OrgItem;

		[SerializeField]
		private GameObject m_Contents;

		[SerializeField]
		private EndrollSideImageItem m_ImageItem;

		[SerializeField]
		private List<SideImageContentInfo> m_SideContents;

		[SerializeField]
		private SkeletonGraphic m_FinishAnimation;

		[SerializeField]
		private PadInputConfigure m_PadInputConfigure;

		[SerializeField]
		private GameObject m_SkipTextObj;

		private const string FINISH_ANIMATION_NAME = "Endroll_Glow";

		private bool m_IsEnd;

		private bool m_IsSkip;

		private bool m_IsFadeBGM;

		private Coroutine m_Coroutine;

		private Action BackAction;

		private List<StaffrollItem> m_List;

		private bool enableSkip;

		private InputActionController _input;

		public void Awake()
		{
		}

		public void Update()
		{
		}

		private void SetActiveFinishAnimation(bool active)
		{
		}

		public override void Init<T>(T args)
		{
		}

		private void CreateDataList()
		{
		}

		private Transform GetSideImageParent(MstEndrollEntities endroll)
		{
			return null;
		}

		public override void Open<T>(T args)
		{
		}

		public void StartAnimation()
		{
		}

		private void InitItems()
		{
		}

		public void StopAnimation()
		{
		}

		public override void Back()
		{
		}

		public override void SetInFront()
		{
		}

		private void SetActiveSkipText(bool active)
		{
		}

		[IteratorStateMachine(typeof(_003CCorAnimation_003Ed__30))]
		private IEnumerator CorAnimation()
		{
			return null;
		}

		private void PlayFinishAnimation()
		{
		}

		public bool IsAnimationEnd()
		{
			return false;
		}

		[IteratorStateMachine(typeof(_003CWaitWithSkip_003Ed__33))]
		private IEnumerator WaitWithSkip(float _time)
		{
			return null;
		}

		private void StopItemAnimations()
		{
		}

		public void OnTapSkip()
		{
		}

		public void OnTapClose()
		{
		}

		public override void PlayOpenSound()
		{
		}

		public override void PlayCloseSound()
		{
		}

		public override void PushEscape()
		{
		}
	}
}
