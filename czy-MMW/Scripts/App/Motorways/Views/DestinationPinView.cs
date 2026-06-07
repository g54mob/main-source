using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using Motorways.Themes;
using UnityEngine;

namespace Motorways.Views
{
	public class DestinationPinView : MonoBehaviour
	{
		[SerializeField]
		private SpriteRenderer _pinCenter;

		public const ThemeComponentGroupTarget BuildingComponentTargetColor = ThemeComponentGroupTarget.BuildingTop;

		private static readonly int VisibleParameterId = Animator.StringToHash("Visible");

		[SerializeField]
		private Animator _animator;

		private readonly List<SpriteRendererState> _spriteRendererStates = new List<SpriteRendererState>();

		private const float MaxAnimationClipDuration = 0.5f;

		private const int MaxTransitionsToReachIdleState = 3;

		public bool IsVisible => _animator.GetBool(VisibleParameterId);

		public Vector3 PinCenterPosition => _pinCenter.transform.position;

		public event Action<DestinationPinView> Hidden;

		private void Awake()
		{
			SpriteRenderer[] componentsInChildren = base.gameObject.GetComponentsInChildren<SpriteRenderer>();
			foreach (SpriteRenderer spriteRenderer in componentsInChildren)
			{
				SpriteRendererState spriteRendererState = new SpriteRendererState();
				spriteRendererState.spriteRenderer = spriteRenderer;
				spriteRendererState.color = spriteRenderer.color;
				Transform transform = spriteRenderer.transform;
				spriteRendererState.position = transform.localPosition;
				spriteRendererState.scale = transform.localScale;
				_spriteRendererStates.Add(spriteRendererState);
			}
			_animator.SetBool(VisibleParameterId, value: false);
			_animator.enabled = false;
			FlushAnimator();
			SetSpriteVisibility(spriteVisibility: false);
		}

		public void Show()
		{
			if (!IsVisible)
			{
				SetSpriteVisibility(spriteVisibility: true);
				_animator.enabled = true;
				_animator.SetBool(VisibleParameterId, value: true);
			}
		}

		public void Hide()
		{
			if (IsVisible)
			{
				_animator.enabled = true;
				_animator.SetBool(VisibleParameterId, value: false);
			}
		}

		public void SetPinColor(Color color)
		{
			_pinCenter.color = color;
		}

		public void FlushAnimator()
		{
			for (int i = 0; i < 3; i++)
			{
				_animator.Update(0.5f);
			}
		}

		public void Reset()
		{
			_animator.SetBool(VisibleParameterId, value: false);
			FlushAnimator();
			_animator.enabled = false;
			foreach (SpriteRendererState spriteRendererState in _spriteRendererStates)
			{
				SpriteRenderer spriteRenderer = spriteRendererState.spriteRenderer;
				spriteRenderer.color = spriteRendererState.color;
				Transform obj = spriteRenderer.transform;
				obj.localPosition = spriteRendererState.position;
				obj.localScale = spriteRendererState.scale;
			}
		}

		private void SetSpriteVisibility(bool spriteVisibility)
		{
			foreach (SpriteRendererState spriteRendererState in _spriteRendererStates)
			{
				spriteRendererState.spriteRenderer.gameObject.SetActive(spriteVisibility);
			}
		}

		[UsedImplicitly]
		private void OnPinHidden()
		{
			this.Hidden?.Invoke(this);
		}

		[UsedImplicitly]
		private void OnIdleShown()
		{
			if (IsVisible)
			{
				_animator.enabled = false;
			}
		}

		[UsedImplicitly]
		private void OnIdleHidden()
		{
			if (!IsVisible)
			{
				_animator.enabled = false;
				SetSpriteVisibility(spriteVisibility: false);
			}
		}
	}
}
