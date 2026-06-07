using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using DG.Tweening;
using UnityEngine;

namespace Gh.Tk
{
	public class ShowHideAnimation3DUIView : MonoBehaviour
	{
		[SerializeField]
		protected List<Animator> _showHideAnimators;

		[SerializeField]
		protected List<ShowHideAnimation3DUIView> _subShowHideAnimationViews;

		[SerializeField]
		private List<Animator> _additionalAnimatorsWithSpeedSetting;

		private int _remainingClosedEvents;

		protected bool _isActive;

		private int _remainingOpenedEvents;

		[SerializeField]
		[DropDownChoice(typeof(SFX), "GetShowAnimationSoundOptions")]
		protected string onOpenSound;

		[SerializeField]
		[DropDownChoice(typeof(SFX), "GetHideAnimationSoundOptions")]
		protected string onCloseSound;

		private bool _isOpened;

		private bool _isClosed;

		private DateTime _lastClosingTime;

		private static TimeSpan _fastAnimThreshold;

		private TextSizeGroup[] _textSizeGroups;

		public static EventHandler<EventArgs> OnIsActiveInHierarchyChanged;

		private bool _isActiveInHierarchy;

		public List<Tween> HideTweens { get; set; }

		public bool IsClosing { get; protected set; }

		public bool IsOpening { get; protected set; }

		public bool IsOpenedOrOpening => false;

		[field: SerializeField]
		public bool IsControlledByParent { get; set; }

		[field: SerializeField]
		public bool ClearTransitionsBeforeOpenClose { get; set; }

		public bool IsOpened
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool IsClosed
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public ShowHideAnimationSpeed LastOpenSpeed { get; protected set; }

		public bool IsActiveInHierarchy
		{
			get
			{
				return false;
			}
			private set
			{
			}
		}

		public event EventHandler ClosedEvent
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

		public event EventHandler OpenedEvent
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

		protected virtual void Awake()
		{
		}

		protected void GatherAnimators(bool includeInactive = true)
		{
		}

		public void InitAnimators()
		{
		}

		private void OnSubViewClosed(object sender, EventArgs e)
		{
		}

		private void OnSubViewOpened(object sender, EventArgs e)
		{
		}

		public void OnAnimEvent(object sender, AnimationEventArgs e)
		{
		}

		protected virtual void OnAnimEventInternal(object sender, AnimationEventArgs e)
		{
		}

		private void OpenedEventCaught()
		{
		}

		private void ClosedEventCaught()
		{
		}

		protected virtual void Closed()
		{
		}

		protected virtual void Opened()
		{
		}

		protected virtual void SetInitialAnimatorValues()
		{
		}

		protected virtual bool CanOpen(ShowHideAnimationSpeed speed)
		{
			return false;
		}

		protected virtual void OpenInternal(ShowHideAnimationSpeed speed)
		{
		}

		public void Open()
		{
		}

		public virtual void Open(ShowHideAnimationSpeed speed)
		{
		}

		protected virtual bool CanClose(ShowHideAnimationSpeed speed, bool forceClose)
		{
			return false;
		}

		protected virtual void CloseInternal(ShowHideAnimationSpeed speed)
		{
		}

		public void Close(bool forceClose = false)
		{
		}

		public void Close(ShowHideAnimationSpeed speed, bool forceClose = false)
		{
		}

		public void ClearTransition()
		{
		}

		private void Update()
		{
		}

		protected virtual void PlayOnOpenSound(ShowHideAnimationSpeed speed)
		{
		}

		protected virtual void PlayOnCloseSound(ShowHideAnimationSpeed speed)
		{
		}

		protected virtual void OnEnable()
		{
		}

		protected virtual void OnDisable()
		{
		}
	}
}
