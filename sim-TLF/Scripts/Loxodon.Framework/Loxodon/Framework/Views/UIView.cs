using System;
using Loxodon.Framework.Views.Animations;
using Loxodon.Log;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Loxodon.Framework.Views
{
	[RequireComponent(typeof(RectTransform), typeof(CanvasGroup))]
	public class UIView : UIBehaviour, IUIView, IView
	{
		private static readonly ILog log = LogManager.GetLogger(typeof(UIView));

		private IAnimation enterAnimation;

		private IAnimation exitAnimation;

		private RectTransform rectTransform;

		private CanvasGroup canvasGroup;

		private readonly object _lock = new object();

		private EventHandler onDisabled;

		private EventHandler onEnabled;

		[NonSerialized]
		private IAttributes attributes = new Attributes();

		public virtual string Name
		{
			get
			{
				if (IsDestroyed() || !(base.gameObject != null))
				{
					return null;
				}
				return base.gameObject.name;
			}
			set
			{
				if (!IsDestroyed() && !(base.gameObject == null))
				{
					base.gameObject.name = value;
				}
			}
		}

		public virtual Transform Parent
		{
			get
			{
				if (IsDestroyed() || !(base.transform != null))
				{
					return null;
				}
				return base.transform.parent;
			}
		}

		public virtual GameObject Owner
		{
			get
			{
				if (!IsDestroyed())
				{
					return base.gameObject;
				}
				return null;
			}
		}

		public virtual Transform Transform
		{
			get
			{
				if (!IsDestroyed())
				{
					return base.transform;
				}
				return null;
			}
		}

		public virtual RectTransform RectTransform
		{
			get
			{
				if (IsDestroyed())
				{
					return null;
				}
				return rectTransform ?? (rectTransform = GetComponent<RectTransform>());
			}
		}

		public virtual bool Visibility
		{
			get
			{
				if (IsDestroyed() || !(base.gameObject != null))
				{
					return false;
				}
				return base.gameObject.activeSelf;
			}
			set
			{
				if (!IsDestroyed() && !(base.gameObject == null) && base.gameObject.activeSelf != value)
				{
					base.gameObject.SetActive(value);
				}
			}
		}

		public virtual IAnimation EnterAnimation
		{
			get
			{
				return enterAnimation;
			}
			set
			{
				enterAnimation = value;
			}
		}

		public virtual IAnimation ExitAnimation
		{
			get
			{
				return exitAnimation;
			}
			set
			{
				exitAnimation = value;
			}
		}

		public virtual float Alpha
		{
			get
			{
				if (IsDestroyed() || !(base.gameObject != null))
				{
					return 0f;
				}
				return CanvasGroup.alpha;
			}
			set
			{
				if (!IsDestroyed() && base.gameObject != null)
				{
					CanvasGroup.alpha = value;
				}
			}
		}

		public virtual bool Interactable
		{
			get
			{
				if (IsDestroyed() || base.gameObject == null)
				{
					return false;
				}
				if (GlobalSetting.useBlocksRaycastsInsteadOfInteractable)
				{
					return CanvasGroup.blocksRaycasts;
				}
				return CanvasGroup.interactable;
			}
			set
			{
				if (!IsDestroyed() && !(base.gameObject == null))
				{
					if (GlobalSetting.useBlocksRaycastsInsteadOfInteractable)
					{
						CanvasGroup.blocksRaycasts = value;
					}
					else
					{
						CanvasGroup.interactable = value;
					}
				}
			}
		}

		public virtual CanvasGroup CanvasGroup
		{
			get
			{
				if (IsDestroyed())
				{
					return null;
				}
				return canvasGroup ?? (canvasGroup = GetComponent<CanvasGroup>());
			}
		}

		public virtual IAttributes ExtraAttributes => attributes;

		public event EventHandler OnDisabled
		{
			add
			{
				lock (_lock)
				{
					onDisabled = (EventHandler)Delegate.Combine(onDisabled, value);
				}
			}
			remove
			{
				lock (_lock)
				{
					onDisabled = (EventHandler)Delegate.Remove(onDisabled, value);
				}
			}
		}

		public event EventHandler OnEnabled
		{
			add
			{
				lock (_lock)
				{
					onEnabled = (EventHandler)Delegate.Combine(onEnabled, value);
				}
			}
			remove
			{
				lock (_lock)
				{
					onEnabled = (EventHandler)Delegate.Remove(onEnabled, value);
				}
			}
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			OnVisibilityChanged();
			RaiseOnEnabled();
		}

		protected override void OnDisable()
		{
			OnVisibilityChanged();
			base.OnDisable();
			RaiseOnDisabled();
		}

		protected void RaiseOnEnabled()
		{
			try
			{
				if (onEnabled != null)
				{
					onEnabled(this, EventArgs.Empty);
				}
			}
			catch (Exception ex)
			{
				if (log.IsWarnEnabled)
				{
					log.WarnFormat("{0}", ex);
				}
			}
		}

		protected void RaiseOnDisabled()
		{
			try
			{
				if (onDisabled != null)
				{
					onDisabled(this, EventArgs.Empty);
				}
			}
			catch (Exception ex)
			{
				if (log.IsWarnEnabled)
				{
					log.WarnFormat("{0}", ex);
				}
			}
		}

		protected virtual void OnVisibilityChanged()
		{
		}
	}
}
