using Mandragora.Utils;
using Restory.Data.Elements;
using Restory.Data.Equipment;
using Restory.SimpleTweeners;
using UnityEngine;
using UnityEngine.Events;

namespace Restory.Gameplay.Elements
{
	public class ThreadedElement : ElementBase
	{
		[SerializeField]
		[BoolButton(25, 0, Red = false)]
		private bool isSelfScrewingWithoutTool;

		[SerializeField]
		private float selfUnscrewingSpeed = 1f;

		[Header("Tweening settings")]
		[SerializeField]
		private InfinityRotationTweener rotationTweener;

		private bool shouldBeInstalled;

		private bool isCurrentlyBeingHeld;

		public UnityEvent<ThreadedElement, ToolInfo> OnStartedHolding { get; } = new UnityEvent<ThreadedElement, ToolInfo>();

		public UnityEvent OnStoppedHolding { get; } = new UnityEvent();

		public UnityEvent<ThreadedElement, ToolInfo> OnImmediateShortInteraction { get; } = new UnityEvent<ThreadedElement, ToolInfo>();

		protected override Vector3 AttachmentPosition => tweener.ReverseStartLocalPosition;

		public float HoldElementProgress
		{
			get
			{
				base.Progress = tweener.Progress;
				if (!base.IsInstalling)
				{
					return base.Progress;
				}
				return 1f - base.Progress;
			}
			set
			{
				tweener.Progress = value;
				base.Progress = value;
			}
		}

		public bool IsSelfScrewingWithoutTool => isSelfScrewingWithoutTool;

		public override void Init()
		{
			base.IsInstalling = shouldBeInstalled;
			base.Init();
		}

		public override bool CanInteraction(ToolInfo toolInfo)
		{
			if (!isSelfScrewingWithoutTool)
			{
				return toolInfo is UnscrewingToolInfo;
			}
			return true;
		}

		public override void InitInteraction(ToolInfo toolInfo)
		{
			if (!(toolInfo is UnscrewingToolInfo unscrewingToolInfo))
			{
				Debug.LogError("Trying to use a non-unscrewing tool on a threaded element.");
				return;
			}
			if (!isSelfScrewingWithoutTool && unscrewingToolInfo.AutoUnscrewing)
			{
				if (!base.IsInstalling)
				{
					tweener.PlayImmediately();
					if ((bool)rotationTweener)
					{
						rotationTweener.PlayImmediately();
					}
				}
				else
				{
					tweener.PlayBackwardsImmediately();
					if ((bool)rotationTweener)
					{
						rotationTweener.PlayBackwardsImmediately();
					}
				}
				OnImmediateShortInteraction?.Invoke(this, toolInfo);
				CompleteInteraction();
				return;
			}
			base.InitInteraction(toolInfo);
			float timeScale = (isSelfScrewingWithoutTool ? selfUnscrewingSpeed : unscrewingToolInfo.UnscrewingSpeed);
			if (!base.IsInstalling)
			{
				tweener.Play();
				tweener.TimeScale = timeScale;
				if ((bool)rotationTweener)
				{
					rotationTweener.Play();
					rotationTweener.TimeScale = timeScale;
				}
			}
			else
			{
				tweener.PlayBackwards();
				tweener.TimeScale = timeScale;
				if ((bool)rotationTweener)
				{
					rotationTweener.PlayBackwards();
					rotationTweener.TimeScale = timeScale;
				}
			}
			isCurrentlyBeingHeld = true;
			OnStartedHolding.Invoke(this, toolInfo);
		}

		public override void CancelInteraction()
		{
			base.CancelInteraction();
			tweener.Stop();
			if ((bool)rotationTweener)
			{
				rotationTweener.Stop();
			}
			if (isCurrentlyBeingHeld)
			{
				isCurrentlyBeingHeld = false;
				base.IsSelected = false;
				OnStoppedHolding.Invoke();
				base.OnInteractionCanceled.Invoke();
			}
		}

		public override void AttachToDevice()
		{
			if (base.Info.Category == ElementCategory.Small)
			{
				base.IsSelected = false;
				base.IsDragging = false;
				base.transform.localPosition = AttachmentPosition;
				base.transform.localRotation = Quaternion.identity;
				base.OnInstalled.Invoke();
				base.IsInstalling = true;
				shouldBeInstalled = true;
			}
			else
			{
				base.AttachToDevice();
				tweener.AppendTighteningToSequence(AttachmentPosition);
			}
		}

		public override void Reset()
		{
			if (tweener.IsPlaying)
			{
				CancelInteraction();
			}
			base.Reset();
		}

		protected override void CompleteInteraction()
		{
			tweener.Stop();
			if ((bool)rotationTweener)
			{
				rotationTweener.Stop();
			}
			if (base.IsInstalling)
			{
				base.Progress = 0f;
				shouldBeInstalled = false;
			}
			else
			{
				base.Progress = 1f;
			}
			isCurrentlyBeingHeld = false;
			base.CompleteInteraction();
		}
	}
}
