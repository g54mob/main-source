using System.Collections.Generic;
using DV.UIFramework;
using UnityEngine;
using UnityEngine.UI;

namespace DV.UI
{
	public class TooltipIconsHandler : MonoBehaviour
	{
		[SerializeField]
		private int totalNumberOfIcons = 24;

		[SerializeField]
		private Vector2 iconSize = new Vector2(32f, 32f);

		[SerializeField]
		private Transform iconsParent;

		private List<Image> icons = new List<Image>();

		private void Awake()
		{
			if (totalNumberOfIcons <= 0)
			{
				Debug.LogError("Total number of icons must be greater than 0. 'TooltipIconsHandler' can't work properly.", base.gameObject);
				return;
			}
			if (iconSize.x <= 0f || iconSize.y <= 0f)
			{
				Debug.LogError("Icon size must be greater than 0. 'TooltipIconsHandler' can't work properly.", base.gameObject);
				return;
			}
			if (iconsParent == null)
			{
				iconsParent = base.transform;
			}
			for (int i = 0; i < totalNumberOfIcons; i++)
			{
				Image component = new GameObject($"Icon{i}", typeof(RectTransform), typeof(Image)).GetComponent<Image>();
				component.transform.SetParent(iconsParent);
				component.rectTransform.sizeDelta = iconSize;
				component.rectTransform.localScale = Vector3.one;
				component.gameObject.SetActive(value: false);
				icons.Add(component);
			}
		}

		public void SetIcons(ITooltipIcons tooltipIcons)
		{
			if (tooltipIcons == null)
			{
				ClearIcons();
				return;
			}
			List<Sprite> list = tooltipIcons.GetIcons();
			int count = list.Count;
			if (count > totalNumberOfIcons)
			{
				count = totalNumberOfIcons;
			}
			for (int i = 0; i < totalNumberOfIcons; i++)
			{
				Sprite sprite = ((i < count) ? list[i] : null);
				if (sprite != null)
				{
					icons[i].sprite = sprite;
					icons[i].gameObject.SetActive(value: true);
				}
				else
				{
					icons[i].gameObject.SetActive(value: false);
				}
			}
		}

		public void ClearIcons()
		{
			foreach (Image icon in icons)
			{
				icon.gameObject.SetActive(value: false);
			}
		}
	}
}
