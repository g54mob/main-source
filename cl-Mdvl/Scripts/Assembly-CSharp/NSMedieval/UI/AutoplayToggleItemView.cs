using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NSEipix.Base;
using NSEipix.View.UI;
using NSMedieval.Sound;
using UnityEngine;
using UnityEngine.UI;

namespace NSMedieval.UI
{
	public class AutoplayToggleItemView : LayoutGroupItemView
	{
		public delegate void GroupUpdated();

		[SerializeField]
		private float indentOffset = 10f;

		[SerializeField]
		private float entryDefaultHeight = 24f;

		private readonly int textIndex;

		private readonly int expandImageIndex = 1;

		private readonly int toggleIndex = 2;

		private readonly int checkImageIndex = 3;

		private readonly int partialCheckIndex = 4;

		private readonly int expandButtonIndex = 6;

		private bool groupExpanded;

		private readonly List<GameObject> immediateGroupChildren = new List<GameObject>();

		private string labelText;

		public CustomToggle GroupSelectToggle => base.GroupItems[toggleIndex].GetComponent<CustomToggle>();

		public bool PartiallySelected => base.GroupItems[partialCheckIndex].activeSelf;

		public void SetExpanded(bool groupExpanded)
		{
			this.groupExpanded = groupExpanded;
		}

		public void SetupGroup(string name)
		{
			labelText = string.Empty;
			RotateToggleSprite();
			labelText = name;
			UpdateLabel();
			base.GroupItems[expandButtonIndex].GetComponent<SoundButton>().onClick.AddListener(delegate
			{
				string soundID = (groupExpanded ? "UI_Collapse" : "UI_Expand");
				MonoSingleton<AudioManager>.Instance.PlaySound(soundID);
				StartCoroutine(OnExpansionChange());
			});
			SetActive(active: true);
		}

		public void AddChild(GameObject child)
		{
			immediateGroupChildren.Add(child);
			if (immediateGroupChildren.Count == 1)
			{
				base.GroupItems[expandButtonIndex].SetActive(value: true);
				UpdateChildren();
			}
		}

		public void SetSelectedPartial()
		{
			base.GroupItems[partialCheckIndex].SetActive(value: true);
			base.GroupItems[checkImageIndex].SetActive(value: false);
			GroupSelectToggle.targetGraphic = base.GroupItems[partialCheckIndex].GetComponent<Image>();
			GroupSelectToggle.SetIsOnWithoutNotify(value: true);
		}

		public void SetSelectedFull()
		{
			base.GroupItems[partialCheckIndex].SetActive(value: false);
			base.GroupItems[checkImageIndex].SetActive(value: true);
			GroupSelectToggle.targetGraphic = base.GroupItems[checkImageIndex].GetComponent<Image>();
			GroupSelectToggle.SetIsOnWithoutNotify(value: true);
		}

		public void SetSelected(bool selected)
		{
			GroupSelectToggle.SetIsOnWithoutNotify(selected);
			base.GroupItems[checkImageIndex].SetActive(selected);
			base.GroupItems[partialCheckIndex].SetActive(value: false);
		}

		public void RotateToggleSprite()
		{
			base.GroupItems[expandImageIndex].transform.eulerAngles = new Vector3(0f, 0f, groupExpanded ? (-90f) : 0f);
		}

		public void UpdateChildren()
		{
			foreach (GameObject immediateGroupChild in immediateGroupChildren)
			{
				immediateGroupChild.gameObject.SetActive(groupExpanded);
			}
		}

		public void CheckSelection()
		{
			if (immediateGroupChildren.Count > 0)
			{
				int num = immediateGroupChildren.Count((GameObject go) => go.GetComponentInChildren<Toggle>().isOn);
				if (num == immediateGroupChildren.Count)
				{
					SetSelectedFull();
				}
				else if (num <= 0)
				{
					SetSelected(selected: false);
				}
				else
				{
					SetSelectedPartial();
				}
			}
		}

		public void OnValueChanged(bool value)
		{
			foreach (GameObject immediateGroupChild in immediateGroupChildren)
			{
				immediateGroupChild.GetComponentInChildren<Toggle>().isOn = value;
			}
			CheckSelection();
		}

		private void SetActive(bool active)
		{
			base.gameObject.SetActive(active);
			if (active)
			{
				UpdateLabel();
			}
		}

		private void UpdateLabel()
		{
			SetText(labelText);
		}

		private IEnumerator OnExpansionChange()
		{
			groupExpanded = !groupExpanded;
			RotateToggleSprite();
			foreach (GameObject group in immediateGroupChildren)
			{
				group.gameObject.SetActive(groupExpanded);
				yield return new WaitForSecondsRealtime(1E-07f);
				if (immediateGroupChildren.Count == 1)
				{
					group.gameObject.SetActive(!groupExpanded);
					group.gameObject.SetActive(groupExpanded);
				}
			}
			yield return new WaitForSecondsRealtime(0.1f);
		}
	}
}
