using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using Timberborn.BaseComponentSystem;
using Timberborn.TemplateAttachmentSystem;
using Timberborn.TimbermeshAnimations;

namespace Timberborn.WorkerOutfitSystem
{
	internal class WorkerOutfitAnimationAttachmentVisibility : BaseComponent, IAwakableComponent
	{
		private TemplateAttachments _templateAttachments;

		private WorkerOutfitAnimationAttachmentVisibilitySpec _workerOutfitAnimationAttachmentVisibilitySpec;

		private IAnimator _animator;

		private bool _initialized;

		private string _currentOutfit;

		private readonly List<WorkerOutfitAnimationAttachment> _animationAttachments = new List<WorkerOutfitAnimationAttachment>();

		public void Awake()
		{
			_templateAttachments = GetComponent<TemplateAttachments>();
			_workerOutfitAnimationAttachmentVisibilitySpec = GetComponent<WorkerOutfitAnimationAttachmentVisibilitySpec>();
			_animator = GetComponentInChildren<IAnimator>();
			_animator.AnimationChanged += OnAnimationChanged;
			GetComponent<WorkerOutfitChangeNotifier>().OutfitChanged += OnOutfitChanged;
			Initialize();
		}

		private void OnAnimationChanged(object sender, EventArgs e)
		{
			UpdateAttachments();
		}

		private void OnOutfitChanged(object sender, WorkerOutfitChangedEventArgs e)
		{
			_currentOutfit = e.WorkerOutfitSpec?.Id;
			UpdateAttachments();
		}

		private void Initialize()
		{
			ImmutableArray<WorkerOutfitAnimationAttachmentSpec>.Enumerator enumerator = _workerOutfitAnimationAttachmentVisibilitySpec.WorkerOutfitAnimationAttachments.GetEnumerator();
			while (enumerator.MoveNext())
			{
				WorkerOutfitAnimationAttachmentSpec current = enumerator.Current;
				_animationAttachments.Add(new WorkerOutfitAnimationAttachment(current, _templateAttachments));
			}
		}

		private void UpdateAttachments()
		{
			foreach (WorkerOutfitAnimationAttachment animationAttachment in _animationAttachments)
			{
				animationAttachment.UpdateState(_currentOutfit, _animator.AnimationName);
			}
		}
	}
}
