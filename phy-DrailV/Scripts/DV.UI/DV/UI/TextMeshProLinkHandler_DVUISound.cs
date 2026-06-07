using System;
using DV.UIFramework;
using UnityEngine;

namespace DV.UI
{
	[RequireComponent(typeof(TextMeshProLinkHandler_DV))]
	public class TextMeshProLinkHandler_DVUISound : MonoBehaviour, IClickable, IHoverable
	{
		public bool playHoverSounds = true;

		public bool playClickSounds = true;

		private TextMeshProLinkHandler_DV handler;

		private bool hovered;

		public bool IsInteractable => true;

		public bool IsHovered => hovered;

		public bool IsMouseOvered => hovered;

		public bool IsPressed => false;

		public event InteractabilityChangedDelegate InteractabilityChanged;

		public event HoverChangedDelegate HoverChanged;

		public event HoverChangedDelegate MouseOverChanged;

		public event ClickDelegate Clicked;

		public event PressChangedDelegate PressChanged;

		private void Awake()
		{
			handler = GetComponent<TextMeshProLinkHandler_DV>();
			handler.LinkClicked += OnClicked;
			handler.LinkHovered += OnHovered;
		}

		private void OnClicked(string linkID)
		{
			if (playClickSounds)
			{
				this.Clicked?.Invoke(this);
			}
		}

		private void OnHovered(string linkID)
		{
			hovered = !string.IsNullOrWhiteSpace(linkID);
			if (playHoverSounds)
			{
				this.HoverChanged?.Invoke(this);
			}
		}

		public GameObject GetGameObject()
		{
			return base.gameObject;
		}

		public void ToggleInteractable(bool newInteractable)
		{
			throw new NotImplementedException();
		}

		public void Hover()
		{
			throw new NotImplementedException();
		}

		public void Unhover()
		{
			throw new NotImplementedException();
		}

		public void Click()
		{
			throw new NotImplementedException();
		}

		public void Press()
		{
			throw new NotImplementedException();
		}

		public void Release()
		{
			throw new NotImplementedException();
		}
	}
}
