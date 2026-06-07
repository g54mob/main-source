using System;
using UnityEngine;

namespace Gh.Tk.UI.Dialogs.Notification
{
	public class IFPage3DUIView : BaseBlock3DUIView, IInteractableUI
	{
		[SerializeField]
		private Transform _contentContainer;

		public Action skipTextAnimationAction;

		public Transform ContentContainer => null;

		public bool IsInteractionSuspended { get; set; }

		public bool IsHovered { get; set; }

		public bool IsPressed { get; set; }

		protected void Awake()
		{
		}

		public void Clear()
		{
		}

		public void AddBlock()
		{
		}

		public void OnHovering()
		{
		}

		public void OnClicked()
		{
		}
	}
}
