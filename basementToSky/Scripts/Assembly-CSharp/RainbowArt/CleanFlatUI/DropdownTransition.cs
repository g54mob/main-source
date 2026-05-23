using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace RainbowArt.CleanFlatUI
{
	public class DropdownTransition : TMP_Dropdown
	{
		private Animator animatorList;

		private Toggle[] toggleList;

		private IEnumerator diableCoroutine;

		private float disableTime = 0.4f;

		public new void Show()
		{
			if (base.transform.Find("Dropdown List") != null)
			{
				return;
			}
			base.Show();
			Transform transform = base.transform.Find("Dropdown List/Viewport/Content");
			toggleList = transform.GetComponentsInChildren<Toggle>(includeInactive: false);
			for (int i = 0; i < toggleList.Length; i++)
			{
				Toggle item = toggleList[i];
				item.onValueChanged.RemoveAllListeners();
				item.onValueChanged.AddListener(delegate
				{
					OnSelectItemCustom(item);
				});
			}
			if (animatorList == null)
			{
				Transform transform2 = base.transform.Find("Dropdown List");
				animatorList = transform2.gameObject.GetComponent<Animator>();
			}
			PlayAnimation(bShow: true);
		}

		private void OnSelectItemCustom(Toggle toggle)
		{
			if (!toggle.isOn)
			{
				toggle.isOn = true;
			}
			int num = -1;
			Transform transform = toggle.transform;
			Transform parent = transform.parent;
			for (int i = 0; i < parent.childCount; i++)
			{
				if (parent.GetChild(i) == transform)
				{
					num = i - 1;
					break;
				}
			}
			if (num >= 0)
			{
				base.value = num;
				Hide();
			}
		}

		public new void Hide()
		{
			if (animatorList == null)
			{
				Transform transform = base.transform.Find("Dropdown List");
				animatorList = transform.gameObject.GetComponent<Animator>();
			}
			PlayAnimation(bShow: false);
			HideDropdown();
		}

		public void HideDropdown()
		{
			if (diableCoroutine != null)
			{
				StopCoroutine(diableCoroutine);
				diableCoroutine = null;
			}
			diableCoroutine = DisableTransition();
			StartCoroutine(diableCoroutine);
		}

		private IEnumerator DisableTransition()
		{
			yield return new WaitForSeconds(disableTime);
			base.Hide();
		}

		private void PlayAnimation(bool bShow)
		{
			if (animatorList != null)
			{
				if (!animatorList.enabled)
				{
					animatorList.enabled = true;
				}
				if (bShow)
				{
					animatorList.Play("In", 0, 0f);
				}
				else
				{
					animatorList.Play("Out", 0, 0f);
				}
			}
		}

		public override void OnPointerClick(PointerEventData eventData)
		{
			Show();
		}

		public override void OnSubmit(BaseEventData eventData)
		{
			Show();
		}

		public override void OnCancel(BaseEventData eventData)
		{
			Hide();
		}
	}
}
