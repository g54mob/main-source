using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Gh.Tk
{
	public class AtmosphereMenu3DUIView : ShowHideAnimation3DUIView, IInteractableUI
	{
		public static Dictionary<string, Transform> menuItemChildren;

		public GameObject magnifyingGlass;

		public GameObject menu;

		private Vector3 _defaultMagnifyingGlassPosition;

		public float secondsTillButtonTimeout;

		private bool _isButtonHovered;

		private float _timeSinceButtonLastHovered;

		private string _currentDefaultOverlayId;

		private Tweener _magnifyingGlassTween;

		private bool _isHovered;

		public string CurrentOverlayId { get; private set; }

		public bool IsOpen => false;

		public bool IsHovered
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool IsInteractionSuspended { get; set; }

		public bool IsPressed { get; set; }

		protected void Start()
		{
		}

		private void UIController_AtmosphereOverlayChanged(object sender, EventArgs e)
		{
		}

		protected void Update()
		{
		}

		private void ResetMagnifyingGlassState()
		{
		}

		protected override void CloseInternal(ShowHideAnimationSpeed speed)
		{
		}

		private void OnResetUI(object sender, EventArgs e)
		{
		}

		protected override void OnDisable()
		{
		}

		private void OnMenuItemClicked(object sender, EventArgs e)
		{
		}

		private void OnMenuItemHovered(object sender, EventArgs e)
		{
		}

		private void SetMagnifyingGlassDefaultPosition(Vector3 localPosition)
		{
		}

		private void SetMagnifyingGlassHoverPosition(Vector3 localPosition)
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
