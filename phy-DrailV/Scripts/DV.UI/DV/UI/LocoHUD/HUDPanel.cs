using System;
using DV.UIFramework;
using DV.Utils;
using UnityEngine;

namespace DV.UI.LocoHUD
{
	public class HUDPanel : MonoBehaviour, HUDUpdateManager.IUpdateSlave
	{
		public RectTransform mask;

		public ButtonDV openCloseButton;

		public float minimumSize;

		public float closedSize;

		public bool scaleX;

		public bool visible;

		public bool open;

		public Vector2 initialSize;

		private CanvasGroup group;

		private LocoHUDControlBase controlBase;

		public event Action<bool> OpenChanged;

		private void Awake()
		{
			group = GetComponentInChildren<CanvasGroup>();
			if ((bool)openCloseButton)
			{
				controlBase = openCloseButton.GetComponent<LocoHUDControlBase>();
			}
			initialSize = mask.sizeDelta;
			mask.sizeDelta = new Vector2(scaleX ? 0f : mask.sizeDelta.x, 0f);
			if (open || visible)
			{
				SingletonBehaviour<HUDUpdateManager>.Instance.AddSlave(this);
			}
			else
			{
				base.gameObject.SetActive(value: false);
			}
		}

		private void OnDestroy()
		{
			if (!UnloadWatcher.isUnloading)
			{
				SingletonBehaviour<HUDUpdateManager>.Instance.RemoveSlave(this);
			}
		}

		public void SetOpen(bool open)
		{
			if (this.open != open)
			{
				this.open = open;
				this.OpenChanged?.Invoke(open);
				if ((bool)controlBase)
				{
					controlBase.SetVisualLevel(open ? 1 : 0);
				}
				SingletonBehaviour<HUDUpdateManager>.Instance.AddSlave(this);
				if (!base.gameObject.activeSelf)
				{
					base.gameObject.SetActive(value: true);
				}
			}
		}

		public void SetVisible(bool visible)
		{
			if (this.visible != visible)
			{
				this.visible = visible;
				if ((bool)controlBase)
				{
					controlBase.SetVisualLevel(open ? 1 : 0);
				}
				SingletonBehaviour<HUDUpdateManager>.Instance.AddSlave(this);
				if (!base.gameObject.activeSelf)
				{
					base.gameObject.SetActive(value: true);
				}
			}
		}

		public void ToggleState()
		{
			open = !open;
			this.OpenChanged?.Invoke(open);
			if ((bool)controlBase)
			{
				controlBase.SetVisualLevel(open ? 1 : 0);
			}
			SingletonBehaviour<HUDUpdateManager>.Instance.AddSlave(this);
		}

		public void DoUpdate()
		{
			if (!base.isActiveAndEnabled)
			{
				return;
			}
			Vector2 sizeDelta = mask.sizeDelta;
			Vector2 vector = (open ? initialSize : (Vector2.one * (visible ? minimumSize : closedSize)));
			if (!scaleX)
			{
				vector.x = sizeDelta.x;
			}
			sizeDelta = Vector2.Lerp(sizeDelta, vector, Time.unscaledDeltaTime * 30f);
			mask.sizeDelta = sizeDelta;
			int num = (open ? 1 : 0);
			if ((bool)group)
			{
				group.alpha = Mathf.Lerp(group.alpha, num, Time.unscaledDeltaTime * 30f);
			}
			if (Vector2.SqrMagnitude(vector - sizeDelta) < 0.001f && (!group || Mathf.Approximately(group.alpha, num)))
			{
				SingletonBehaviour<HUDUpdateManager>.Instance.RemoveSlave(this);
				if (!open && !visible)
				{
					base.gameObject.SetActive(value: false);
				}
			}
		}
	}
}
