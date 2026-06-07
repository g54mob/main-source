using System;
using System.Collections.Generic;
using UnityEngine;

namespace Jundroo.Juicy.Widgets.Extra
{
	public class WidgetAnimationManager
	{
		private const string ShowAnimationKey = "_SHOW_";

		private Dictionary<string, IWidgetAnimation> _animations = new Dictionary<string, IWidgetAnimation>();

		private Vector3? _slideShownPosition;

		private Widget _widget;

		public AnimationData HideAnimation { get; set; }

		public bool IsInitialized { get; private set; }

		public bool IsShowAnimationRunning => _animations.ContainsKey("_SHOW_");

		public AnimationData ShowAnimation { get; set; }

		public event WidgetDelegate HideComplete;

		public event WidgetDelegate ShowComplete;

		public WidgetAnimationManager(Widget widget)
		{
			_widget = widget;
			widget.Destroyed += OnWidgetDestroyed;
		}

		public void OnHide(Action action, bool force = false, bool skipAnimation = false)
		{
			if (!(!IsShowAnimationRunning || force))
			{
				return;
			}
			if (HideAnimation != null && !skipAnimation)
			{
				float initialOpacity = _widget.Opacity;
				IWidgetAnimation widgetAnimation = ShowAnimations.CreateShowAnimation(_widget, HideAnimation, _slideShownPosition ?? ((Vector3)_widget.Rect.anchoredPosition));
				StartAnimation("_SHOW_", widgetAnimation);
				Vector2 position = _widget.Rect.anchoredPosition;
				widgetAnimation.Complete += delegate
				{
					_widget.Rect.anchoredPosition = position;
					_widget.Visible = false;
					if (_widget.TryGetComponent<CanvasGroup>(out var component))
					{
						component.alpha = initialOpacity;
					}
					action?.Invoke();
					this.HideComplete?.Invoke(_widget);
				};
				if (_widget.SoundHide != null)
				{
					_widget.Context.PlaySound(_widget.SoundHide);
				}
			}
			else
			{
				_widget.Visible = false;
				action?.Invoke();
				this.HideComplete?.Invoke(_widget);
			}
		}

		public void OnInitializeStyles()
		{
			IsInitialized = true;
		}

		public void OnShow(bool force = false, bool skipAnimation = false)
		{
			if (!(!_widget.Visible || force))
			{
				return;
			}
			if (ShowAnimation != null && !skipAnimation)
			{
				Vector2 vector = _widget.Rect.anchoredPosition;
				if (IsShowAnimationRunning)
				{
					vector = _slideShownPosition ?? ((Vector3)vector);
				}
				else
				{
					_slideShownPosition = vector;
				}
				IWidgetAnimation widgetAnimation = ShowAnimations.CreateShowAnimation(_widget, ShowAnimation, vector);
				widgetAnimation.Complete += delegate
				{
					this.ShowComplete?.Invoke(_widget);
				};
				StartAnimation("_SHOW_", widgetAnimation);
			}
			else
			{
				_widget.Visible = true;
				this.ShowComplete?.Invoke(_widget);
			}
		}

		public void SetVisibilityWithAnimation(bool visible, bool force = false)
		{
			if (visible && ShowAnimation != null)
			{
				OnShow(force);
			}
			else if (!visible && HideAnimation != null)
			{
				OnHide(null, force);
			}
			else
			{
				_widget.Visible = visible;
			}
		}

		public void StartAnimation(string name, IWidgetAnimation animation)
		{
			if (_animations.TryGetValue(name, out var value))
			{
				value.Stop(complete: true);
			}
			_animations[name] = animation;
			animation.Start();
			animation.Complete += delegate(IWidgetAnimation a)
			{
				RemoveAnimation(name, a);
			};
		}

		public void StopAnimation(string name)
		{
			if (_animations.Count > 0 && _animations.TryGetValue(name, out var value))
			{
				value.Stop(complete: false);
			}
		}

		private void OnWidgetDestroyed(Widget widget)
		{
			widget.Destroyed -= OnWidgetDestroyed;
			foreach (KeyValuePair<string, IWidgetAnimation> animation in _animations)
			{
				animation.Value.Stop(complete: false);
			}
			_animations.Clear();
		}

		private void RemoveAnimation(string name, IWidgetAnimation animation)
		{
			if (_animations.TryGetValue(name, out var value) && animation == value)
			{
				_animations.Remove(name);
			}
		}
	}
}
