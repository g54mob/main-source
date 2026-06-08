using System.Collections.Generic;
using System.Collections.Immutable;
using Timberborn.TemplateAttachmentSystem;

namespace Timberborn.WorkerOutfitSystem
{
	internal class WorkerOutfitAnimationAttachment
	{
		private readonly WorkerOutfitAnimationAttachmentSpec _spec;

		private readonly TemplateAttachments _templateAttachments;

		private readonly Dictionary<string, TemplateAttachmentVisibilityToggle> _visibilityToggles = new Dictionary<string, TemplateAttachmentVisibilityToggle>();

		public WorkerOutfitAnimationAttachment(WorkerOutfitAnimationAttachmentSpec spec, TemplateAttachments templateAttachments)
		{
			_spec = spec;
			_templateAttachments = templateAttachments;
		}

		public void UpdateState(string workerOutfit, string animationName)
		{
			if (_spec.WorkerOutfit == workerOutfit || string.IsNullOrWhiteSpace(_spec.WorkerOutfit))
			{
				if (IsValidAnimation(animationName))
				{
					SetVisibilityToggles(_spec.ShowWhenActive, visible: true);
					SetVisibilityToggles(_spec.HideWhenActive, visible: false);
				}
				else
				{
					SetVisibilityToggles(_spec.ShowWhenActive, visible: false);
					SetVisibilityToggles(_spec.HideWhenActive, visible: true);
				}
			}
		}

		private bool IsValidAnimation(string animationName)
		{
			ImmutableArray<string>.Enumerator enumerator = _spec.AnimationNames.GetEnumerator();
			while (enumerator.MoveNext())
			{
				if (enumerator.Current == animationName)
				{
					return true;
				}
			}
			return false;
		}

		private void SetVisibilityToggles(IReadOnlyList<string> attachmentIds, bool visible)
		{
			foreach (string attachmentId in attachmentIds)
			{
				if (visible || _templateAttachments.HasAttachment(attachmentId))
				{
					TemplateAttachmentVisibilityToggle orCreateVisibilityToggle = GetOrCreateVisibilityToggle(attachmentId);
					if (visible)
					{
						orCreateVisibilityToggle.Show();
					}
					else
					{
						orCreateVisibilityToggle.Hide();
					}
				}
			}
		}

		private TemplateAttachmentVisibilityToggle GetOrCreateVisibilityToggle(string attachmentId)
		{
			if (!_visibilityToggles.TryGetValue(attachmentId, out var value))
			{
				value = _templateAttachments.GetOrCreateAttachment(attachmentId).GetVisibilityToggle();
				_visibilityToggles.Add(attachmentId, value);
			}
			return value;
		}
	}
}
