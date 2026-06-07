using System;
using ManagementScripts;
using UnityEngine;
using UnityEngine.Events;

namespace UIScripts
{
	public class UIPanel : MonoBehaviour, IEscapable
	{
		[SerializeField]
		private bool escapable = true;

		[NonSerialized]
		public bool openedSinceFilled;

		[NonSerialized]
		protected bool hasInit;

		public UnityEvent onOpen = new UnityEvent();

		public UnityEvent onClose = new UnityEvent();

		protected virtual bool canBeEscapedFlag => true;

		public bool panelHasInit => hasInit;

		public bool CanBeEscaped()
		{
			if (escapable)
			{
				return canBeEscapedFlag;
			}
			return false;
		}

		private void Awake()
		{
			Initialize();
		}

		public void Initialize()
		{
			if (!hasInit)
			{
				InitPanel();
			}
			hasInit = true;
		}

		public virtual void InitPanel()
		{
		}

		public virtual void ResetState()
		{
		}

		public virtual void FillPanel()
		{
			if (!hasInit)
			{
				Initialize();
			}
			openedSinceFilled = false;
		}

		public virtual void OpenPanel()
		{
			if (!hasInit)
			{
				Initialize();
			}
			if (!base.isActiveAndEnabled)
			{
				base.gameObject.SetActive(value: true);
				onOpen.Invoke();
				if (escapable)
				{
					UINavigationManager.AddEscapableToStack(this);
				}
				UpdatePanel();
			}
		}

		public virtual void ClosePanel()
		{
			if (escapable)
			{
				UINavigationManager.RemoveEscapableFromStack(this);
			}
			if (base.isActiveAndEnabled)
			{
				base.gameObject.SetActive(value: false);
				onClose.Invoke();
			}
		}

		public void TogglePanel()
		{
			if (base.gameObject.activeSelf)
			{
				ClosePanel();
			}
			else
			{
				OpenPanel();
			}
		}

		public virtual void Escape()
		{
			OnPanelEscape();
			ClosePanel();
		}

		protected virtual void OnPanelEscape()
		{
		}

		private void Update()
		{
			if (base.isActiveAndEnabled)
			{
				UpdatePanel();
			}
		}

		protected virtual void UpdatePanel()
		{
		}
	}
}
