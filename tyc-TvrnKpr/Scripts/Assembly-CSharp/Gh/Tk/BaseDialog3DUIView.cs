using System;
using System.Collections.Generic;
using UnityEngine;

namespace Gh.Tk
{
	public class BaseDialog3DUIView : ShowHideAnimation3DUIView, IDevCommentaryParent
	{
		[SerializeField]
		protected List<Button3DUIView> _defaultCloseButtons;

		public DevCommentaryMarkerMonoBehaviour devCommentaryTransform;

		public bool ShowGameOverlay;

		public string Id { get; protected set; }

		public DevCommentaryMarkerMonoBehaviour DevCommentaryMarker => null;

		public bool IsSingletonDialog { get; protected set; }

		public bool IsOpen => false;

		[field: SerializeField]
		public bool HideUI { get; set; }

		[field: SerializeField]
		public bool RequireStatusBar { get; set; }

		[field: SerializeField]
		public bool RequireStaticTime { get; protected set; }

		protected override void Awake()
		{
		}

		protected void HideAllDevCommentaryNodes()
		{
		}

		protected void ShowAllDevCommentaryNodes()
		{
		}

		protected override void Closed()
		{
		}

		public void AddCallbackOnClosed(Action action)
		{
		}

		protected override void Opened()
		{
		}

		protected override void OpenInternal(ShowHideAnimationSpeed speed)
		{
		}

		protected override void CloseInternal(ShowHideAnimationSpeed speed)
		{
		}

		public virtual void BackOrClose()
		{
		}

		public virtual bool IsBackable()
		{
			return false;
		}

		public virtual void Back()
		{
		}
	}
}
