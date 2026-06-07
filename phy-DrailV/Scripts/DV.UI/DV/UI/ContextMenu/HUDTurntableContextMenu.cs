using System.Collections;
using DV.UI.LocoHUD;
using DV.UIFramework;
using UnityEngine;

namespace DV.UI.ContextMenu
{
	public class HUDTurntableContextMenu : MonoBehaviour
	{
		public HUDPanel leftButton;

		public HUDPanel rightButton;

		private AHUDTurntableProvider provider;

		private RectTransform rectTransform;

		private void Awake()
		{
			rectTransform = GetComponent<RectTransform>();
			InitializeButton(leftButton, right: false);
			InitializeButton(rightButton, right: true);
			void InitializeButton(HUDPanel panel, bool right)
			{
				ButtonDV btn = panel.GetComponentInChildren<ButtonDV>();
				btn.PressChanged += delegate(IClickable clickable)
				{
					if (clickable.IsPressed)
					{
						StartCoroutine(HoldButtonDown(btn, right));
					}
				};
				panel.SetOpen(open: true);
				panel.SetVisible(visible: true);
			}
		}

		private IEnumerator HoldButtonDown(ButtonDV btn, bool right)
		{
			while (btn.IsPressed)
			{
				provider.Move(right);
				yield return WaitFor.FixedUpdate;
			}
		}

		public void SetProvider(AHUDTurntableProvider provider)
		{
			this.provider = provider;
		}

		public void SetActive(bool on)
		{
			base.gameObject.SetActive(on);
		}

		private void LateUpdate()
		{
			UpdatePosition();
		}

		public void UpdatePosition()
		{
			Vector2 screenCoords = provider.GetScreenCoords();
			Vector2 size = ((RectTransform)rectTransform.parent).rect.size;
			rectTransform.anchoredPosition = new Vector2(Mathf.LerpUnclamped(0f, size.x, screenCoords.x) - size.x * 0.5f, Mathf.LerpUnclamped(0f, size.y, screenCoords.y));
		}
	}
}
