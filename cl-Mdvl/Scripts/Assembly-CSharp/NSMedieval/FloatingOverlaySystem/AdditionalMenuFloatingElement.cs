using System;
using System.Collections.Generic;
using NSEipix.Base;
using NSEipix.View.UI;
using NSMedieval.Manager;
using TMPro;
using UnityEngine;

namespace NSMedieval.FloatingOverlaySystem
{
	public class AdditionalMenuFloatingElement : FloatingElementBase
	{
		private const float FadeoutMouseStartDistanceDivider = 10.1f;

		private const float CompleteFadeoutDistance = 200f;

		private readonly List<CustomUiButton> buttons = new List<CustomUiButton>();

		[SerializeField]
		private GameObject itemPrefab;

		[SerializeField]
		private GameObject titleObject;

		public override void Dispose()
		{
			base.Dispose();
			buttons.Clear();
		}

		public CustomUiButton AddButton(string text, Action callback)
		{
			GameObject obj = UnityEngine.Object.Instantiate(itemPrefab, base.transform);
			obj.GetComponentInChildren<TextMeshProUGUI>().SetText(text);
			CustomUiButton component = obj.GetComponent<CustomUiButton>();
			if (callback != null)
			{
				component.onClick.AddListener(delegate
				{
					OnClick(callback);
				});
			}
			obj.SetActive(value: true);
			buttons.Add(component);
			return component;
		}

		public void SetTitle(string title)
		{
			if (string.IsNullOrEmpty(title))
			{
				titleObject.SetActive(value: false);
				return;
			}
			titleObject.SetActive(value: true);
			titleObject.GetComponent<TextMeshProUGUI>().SetText(title);
		}

		private void OnClick(Action callback)
		{
			callback?.Invoke();
		}

		protected override void Update()
		{
			base.Update();
			Vector3 vector;
			if (base.Holder.HoldPosition)
			{
				Vector3 position = base.transform.position;
				vector = new Vector3(position.x, position.y, 0f);
			}
			else
			{
				vector = MonoSingleton<CameraManager>.Instance.GameplayCamera.WorldToScreenPoint(base.Holder.FollowingToTransform.position);
			}
			float num = Vector3.Distance(vector + base.LocalPosOverride, Input.mousePosition);
			float num2 = (float)Screen.width / 10.1f;
			if (num <= num2)
			{
				base.CanvasGroup.alpha = 1f;
				return;
			}
			float num3 = 1f - (num - num2) / 200f;
			base.CanvasGroup.alpha = Mathf.Clamp(num3, 0f, 1f);
			if (num3 <= -0.5f)
			{
				MonoSingleton<AdditionalMenuManager>.Instance.HideAll();
			}
		}
	}
}
