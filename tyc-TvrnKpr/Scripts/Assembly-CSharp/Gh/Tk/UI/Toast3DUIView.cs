using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Gh.Tk.UI
{
	public class Toast3DUIView : MonoBehaviour, UIController.IUIUpdateable
	{
		[SerializeField]
		private TavernEventEntryLog3DUIView _eventLogVisual;

		private bool _waitingForIntro;

		private bool _waitingForOutro;

		private float _minToastTime;

		public static float MaxToastTime;

		private List<BaseInteractable3DUIView> _childInteractables;

		private float _isPinnedCooldownRemaining;

		[SerializeField]
		private AnimationEventObserver _eventObserver;

		[SerializeField]
		private Animator _toastAnimator;

		private static readonly int AnimationKey_JiggleTrigger;

		private static readonly int AnimationKey_SlotInt;

		private static readonly int AnimationKey_ShowBool;

		public Toasts3DUIView.ToastUIData ToastData { get; private set; }

		public bool IsPinned => false;

		public bool IsHovered => false;

		public static event EventHandler ToastExpired
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

		public static event EventHandler ToastCleared
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

		private void OnAnimationEvent(object sender, AnimationEventArgs e)
		{
		}

		public void PlayToastIntro(int position)
		{
		}

		public void PlayToastOutro()
		{
		}

		public void SetData(Toasts3DUIView.ToastUIData toastData)
		{
		}

		private void UpdateChildInteractables()
		{
		}

		public void OnDuplicateAdded(TavernLog.TavernEventLogEntry entry)
		{
		}

		public void ClearToast()
		{
		}

		public void UpdateUI(float deltaTime)
		{
		}

		private void OnEnable()
		{
		}

		private void OnDisable()
		{
		}

		public void Jiggle()
		{
		}
	}
}
