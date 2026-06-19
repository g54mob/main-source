using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UniversalInventorySystem
{
	public class Tooltip : MonoBehaviour
	{
		[HideInInspector]
		public Canvas canvas;

		[HideInInspector]
		public InventoryUI invUI;

		[HideInInspector]
		public int slotNum;

		private GameObject toolTip;

		private RectTransform tooltipRect;

		private void Update()
		{
			if (RectTransformUtility.RectangleContainsScreenPoint(base.transform as RectTransform, Camera.main.ScreenToWorldPoint(Input.mousePosition)))
			{
				Item item = invUI.GetInventory().slots[slotNum].item;
				if (item == null || item.tooltip == null || !item.tooltip.useTooltip)
				{
					return;
				}
				if (!toolTip)
				{
					if (!item.tooltip.usePrefab)
					{
						toolTip = new GameObject();
						toolTip.transform.SetParent(canvas.transform);
						toolTip.name = $"Tooltip {invUI.name} {base.name} {Random.Range(int.MinValue, int.MaxValue)}";
						Image image = toolTip.AddComponent<Image>();
						image.raycastTarget = false;
						image.sprite = item.tooltip.sprite;
						image.color = item.tooltip.backgroudColor;
						Vector2 vector = new Vector2(item.tooltip.padding.x * 10f, item.tooltip.padding.y * 10f);
						float num = 0f;
						float num2 = 0f;
						List<GameObject> list = new List<GameObject>();
						for (int i = 0; i < item.tooltip.texts.Count; i++)
						{
							GameObject gameObject = new GameObject();
							gameObject.name = $"text {i}";
							gameObject.transform.SetParent(toolTip.transform);
							TextMeshProUGUI textMeshProUGUI = gameObject.AddComponent<TextMeshProUGUI>();
							textMeshProUGUI.font = item.tooltip.texts[i].font;
							textMeshProUGUI.text = item.tooltip.texts[i].text;
							textMeshProUGUI.color = item.tooltip.texts[i].color;
							textMeshProUGUI.fontSize = item.tooltip.texts[i].fontSize;
							textMeshProUGUI.raycastTarget = false;
							textMeshProUGUI.fontStyle = item.tooltip.texts[i].fontStyles;
							textMeshProUGUI.alignment = item.tooltip.texts[i].alignOptions;
							(textMeshProUGUI.transform as RectTransform).sizeDelta = new Vector2((textMeshProUGUI.preferredWidth <= item.tooltip.maxWidth - Mathf.Abs(vector.x)) ? textMeshProUGUI.preferredWidth : (item.tooltip.maxWidth - Mathf.Abs(vector.x)), textMeshProUGUI.preferredHeight);
							list.Add(gameObject);
							num += textMeshProUGUI.preferredHeight;
							num2 = ((num2 <= textMeshProUGUI.preferredWidth) ? textMeshProUGUI.preferredWidth : num2);
						}
						float num3 = 0f;
						for (int j = 0; j < list.Count; j++)
						{
							GameObject gameObject2 = list[j];
							float y = 0f - (num3 - num / 2f + gameObject2.GetComponent<TextMeshProUGUI>().preferredHeight / 2f);
							switch (item.tooltip.texts[j].aligmentOption)
							{
							case AligmentOption.percentage:
								(gameObject2.transform as RectTransform).anchorMin = new Vector2(item.tooltip.texts[j].pixelOrPercentage / 100f, (gameObject2.transform as RectTransform).anchorMin.y);
								(gameObject2.transform as RectTransform).anchorMax = new Vector2(item.tooltip.texts[j].pixelOrPercentage / 100f, (gameObject2.transform as RectTransform).anchorMax.y);
								switch (item.tooltip.texts[j].pivot)
								{
								case XAligment.center:
									(gameObject2.transform as RectTransform).localPosition += new Vector3(0f, y, 0f);
									break;
								case XAligment.left:
									(gameObject2.transform as RectTransform).localPosition += new Vector3((gameObject2.transform as RectTransform).sizeDelta.x / 2f + item.tooltip.margin.x, y, 0f);
									break;
								case XAligment.right:
									(gameObject2.transform as RectTransform).localPosition += new Vector3(0f - (gameObject2.transform as RectTransform).sizeDelta.x / 2f - item.tooltip.margin.x, y, 0f);
									break;
								}
								break;
							case AligmentOption.pixel:
								switch (item.tooltip.texts[j].pivot)
								{
								case XAligment.center:
									(gameObject2.transform as RectTransform).localPosition += new Vector3(item.tooltip.texts[j].pixelOrPercentage, y, 0f);
									break;
								case XAligment.right:
									(gameObject2.transform as RectTransform).localPosition += new Vector3((gameObject2.transform as RectTransform).sizeDelta.x / 2f + item.tooltip.margin.x + item.tooltip.texts[j].pixelOrPercentage, y, 0f);
									break;
								case XAligment.left:
									(gameObject2.transform as RectTransform).localPosition += new Vector3(0f - (gameObject2.transform as RectTransform).sizeDelta.x / 2f - item.tooltip.margin.x + item.tooltip.texts[j].pixelOrPercentage, y, 0f);
									break;
								}
								break;
							case AligmentOption.preDefined:
								switch (item.tooltip.texts[j].pivot)
								{
								case XAligment.center:
									(gameObject2.transform as RectTransform).localPosition += new Vector3(0f, y, 0f);
									break;
								case XAligment.left:
									(gameObject2.transform as RectTransform).anchorMin = new Vector2(0f, (gameObject2.transform as RectTransform).anchorMin.y);
									(gameObject2.transform as RectTransform).anchorMax = new Vector2(0f, (gameObject2.transform as RectTransform).anchorMax.y);
									(gameObject2.transform as RectTransform).localPosition += new Vector3((gameObject2.transform as RectTransform).sizeDelta.x / 2f + item.tooltip.margin.x, y, 0f);
									break;
								case XAligment.right:
									(gameObject2.transform as RectTransform).anchorMin = new Vector2(1f, (gameObject2.transform as RectTransform).anchorMin.y);
									(gameObject2.transform as RectTransform).anchorMax = new Vector2(1f, (gameObject2.transform as RectTransform).anchorMax.y);
									(gameObject2.transform as RectTransform).localPosition += new Vector3(0f - (gameObject2.transform as RectTransform).sizeDelta.x / 2f - item.tooltip.margin.x, y, 0f);
									break;
								}
								break;
							}
							num3 += gameObject2.GetComponent<TextMeshProUGUI>().preferredHeight;
						}
						num += vector.x;
						num2 += vector.y;
						num2 = ((num2 <= item.tooltip.maxWidth) ? num2 : item.tooltip.maxWidth);
						RectTransform obj = toolTip.transform as RectTransform;
						obj.localScale = new Vector3(item.tooltip.size.x / 2f, item.tooltip.size.y / 2f, 1f);
						obj.sizeDelta = new Vector2(num2, num);
					}
					else
					{
						toolTip = Object.Instantiate(item.tooltip.tooltipPrefab, canvas.transform);
						toolTip.name = $"Tooltip {invUI.name} {base.name} {Random.Range(int.MinValue, int.MaxValue)}";
					}
				}
				Vector3 position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0f);
				toolTip.transform.position = position;
				switch (item.tooltip.xAligmentOption)
				{
				case AligmentOption.percentage:
					switch (item.tooltip.xAlign)
					{
					case XAligment.right:
						(toolTip.transform as RectTransform).localPosition += new Vector3((toolTip.transform as RectTransform).rect.width / 2f * toolTip.transform.localScale.x, 0f, 0f);
						(toolTip.transform as RectTransform).localPosition -= new Vector3(item.tooltip.xPixelOrPercentage / 100f * (toolTip.transform as RectTransform).rect.width, 0f, 0f);
						(toolTip.transform as RectTransform).localPosition += new Vector3(item.tooltip.margin.x, 0f, 0f);
						break;
					case XAligment.center:
						(toolTip.transform as RectTransform).localPosition -= new Vector3((toolTip.transform as RectTransform).rect.width / toolTip.transform.localScale.x, 0f, 0f);
						(toolTip.transform as RectTransform).localPosition += new Vector3(item.tooltip.xPixelOrPercentage / 100f * (toolTip.transform as RectTransform).rect.width, 0f, 0f);
						(toolTip.transform as RectTransform).localPosition += new Vector3(item.tooltip.margin.x, 0f, 0f);
						break;
					case XAligment.left:
						(toolTip.transform as RectTransform).localPosition -= new Vector3((toolTip.transform as RectTransform).rect.width / 2f * toolTip.transform.localScale.x, 0f, 0f);
						(toolTip.transform as RectTransform).localPosition += new Vector3(item.tooltip.xPixelOrPercentage / 100f * (toolTip.transform as RectTransform).rect.width, 0f, 0f);
						(toolTip.transform as RectTransform).localPosition += new Vector3(item.tooltip.margin.x, 0f, 0f);
						break;
					}
					break;
				case AligmentOption.preDefined:
					switch (item.tooltip.xAlign)
					{
					case XAligment.right:
						(toolTip.transform as RectTransform).localPosition += new Vector3((toolTip.transform as RectTransform).rect.width / 2f * toolTip.transform.localScale.x, 0f, 0f);
						goto case XAligment.center;
					case XAligment.center:
						(toolTip.transform as RectTransform).localPosition += new Vector3(item.tooltip.margin.x, 0f, 0f);
						break;
					case XAligment.left:
						(toolTip.transform as RectTransform).localPosition -= new Vector3((toolTip.transform as RectTransform).rect.width / 2f * toolTip.transform.localScale.x, 0f, 0f);
						goto case XAligment.center;
					}
					break;
				case AligmentOption.pixel:
					switch (item.tooltip.xAlign)
					{
					case XAligment.right:
						(toolTip.transform as RectTransform).localPosition += new Vector3((toolTip.transform as RectTransform).rect.width / 2f * toolTip.transform.localScale.x, 0f, 0f);
						(toolTip.transform as RectTransform).localPosition -= new Vector3(item.tooltip.xPixelOrPercentage, 0f, 0f);
						(toolTip.transform as RectTransform).localPosition += new Vector3(item.tooltip.margin.x, 0f, 0f);
						break;
					case XAligment.center:
						(toolTip.transform as RectTransform).localPosition -= new Vector3((toolTip.transform as RectTransform).rect.width / toolTip.transform.localScale.x, 0f, 0f);
						(toolTip.transform as RectTransform).localPosition += new Vector3(item.tooltip.xPixelOrPercentage, 0f, 0f);
						(toolTip.transform as RectTransform).localPosition += new Vector3(item.tooltip.margin.x, 0f, 0f);
						break;
					case XAligment.left:
						(toolTip.transform as RectTransform).localPosition -= new Vector3((toolTip.transform as RectTransform).rect.width / 2f * toolTip.transform.localScale.x, 0f, 0f);
						(toolTip.transform as RectTransform).localPosition += new Vector3(item.tooltip.xPixelOrPercentage, 0f, 0f);
						(toolTip.transform as RectTransform).localPosition += new Vector3(item.tooltip.margin.x, 0f, 0f);
						break;
					}
					break;
				}
				switch (item.tooltip.yAligmentOption)
				{
				case AligmentOption.percentage:
					switch (item.tooltip.yAlign)
					{
					case YAligment.up:
						(toolTip.transform as RectTransform).localPosition += new Vector3(0f, (toolTip.transform as RectTransform).rect.height / 2f * toolTip.transform.localScale.y, 0f);
						(toolTip.transform as RectTransform).localPosition -= new Vector3(0f, item.tooltip.yPixelOrPercentage / 100f * (toolTip.transform as RectTransform).rect.height, 0f);
						(toolTip.transform as RectTransform).localPosition += new Vector3(0f, item.tooltip.margin.y, 0f);
						break;
					case YAligment.center:
						(toolTip.transform as RectTransform).localPosition -= new Vector3(0f, (toolTip.transform as RectTransform).rect.height / toolTip.transform.localScale.y, 0f);
						(toolTip.transform as RectTransform).localPosition += new Vector3(0f, item.tooltip.yPixelOrPercentage / 100f * (toolTip.transform as RectTransform).rect.height, 0f);
						(toolTip.transform as RectTransform).localPosition += new Vector3(0f, item.tooltip.margin.y, 0f);
						break;
					case YAligment.down:
						(toolTip.transform as RectTransform).localPosition -= new Vector3(0f, (toolTip.transform as RectTransform).rect.height / 2f * toolTip.transform.localScale.y, 0f);
						(toolTip.transform as RectTransform).localPosition += new Vector3(0f, item.tooltip.yPixelOrPercentage / 100f * (toolTip.transform as RectTransform).rect.height, 0f);
						(toolTip.transform as RectTransform).localPosition += new Vector3(0f, item.tooltip.margin.y, 0f);
						break;
					}
					break;
				case AligmentOption.preDefined:
					switch (item.tooltip.yAlign)
					{
					case YAligment.up:
						(toolTip.transform as RectTransform).localPosition += new Vector3(0f, (toolTip.transform as RectTransform).rect.height / 2f * toolTip.transform.localScale.y, 0f);
						goto case YAligment.center;
					case YAligment.center:
						(toolTip.transform as RectTransform).localPosition += new Vector3(0f, item.tooltip.margin.y, 0f);
						break;
					case YAligment.down:
						(toolTip.transform as RectTransform).localPosition -= new Vector3(0f, (toolTip.transform as RectTransform).rect.height / 2f * toolTip.transform.localScale.y, 0f);
						goto case YAligment.center;
					}
					break;
				case AligmentOption.pixel:
					switch (item.tooltip.yAlign)
					{
					case YAligment.up:
						(toolTip.transform as RectTransform).localPosition += new Vector3(0f, (toolTip.transform as RectTransform).rect.height / 2f * toolTip.transform.localScale.y, 0f);
						(toolTip.transform as RectTransform).localPosition -= new Vector3(0f, item.tooltip.yPixelOrPercentage, 0f);
						(toolTip.transform as RectTransform).localPosition += new Vector3(0f, item.tooltip.margin.y, 0f);
						break;
					case YAligment.center:
						(toolTip.transform as RectTransform).localPosition -= new Vector3(0f, (toolTip.transform as RectTransform).rect.height / toolTip.transform.localScale.y, 0f);
						(toolTip.transform as RectTransform).localPosition += new Vector3(0f, item.tooltip.yPixelOrPercentage, 0f);
						(toolTip.transform as RectTransform).localPosition += new Vector3(0f, item.tooltip.margin.y, 0f);
						break;
					case YAligment.down:
						(toolTip.transform as RectTransform).localPosition -= new Vector3(0f, (toolTip.transform as RectTransform).rect.height / 2f * toolTip.transform.localScale.y, 0f);
						(toolTip.transform as RectTransform).localPosition += new Vector3(0f, item.tooltip.yPixelOrPercentage, 0f);
						(toolTip.transform as RectTransform).localPosition += new Vector3(0f, item.tooltip.margin.y, 0f);
						break;
					}
					break;
				}
				if (!item.tooltip.autoReAlign)
				{
					return;
				}
				tooltipRect = toolTip.transform as RectTransform;
				Vector3[] array = new Vector3[4];
				tooltipRect.GetWorldCorners(array);
				bool flag = Camera.main.WorldToViewportPoint(array[2]).x > 1f - item.tooltip.snapMargin.x && Camera.main.WorldToViewportPoint(array[3]).x > 1f - item.tooltip.snapMargin.x;
				bool flag2 = Camera.main.WorldToViewportPoint(array[0]).x < 0f + item.tooltip.snapMargin.x && Camera.main.WorldToViewportPoint(array[1]).x < 0f + item.tooltip.snapMargin.x;
				bool flag3 = Camera.main.WorldToViewportPoint(array[1]).y > 1f - item.tooltip.snapMargin.y && Camera.main.WorldToViewportPoint(array[2]).y > 1f - item.tooltip.snapMargin.y;
				bool flag4 = Camera.main.WorldToViewportPoint(array[3]).y < 0f + item.tooltip.snapMargin.y && Camera.main.WorldToViewportPoint(array[0]).y < 0f + item.tooltip.snapMargin.y;
				if (item.tooltip.autoRealignOptions == AutoRealignOptions.snapToSide)
				{
					if (flag)
					{
						toolTip.transform.position = new Vector3(Camera.main.ViewportToWorldPoint(new Vector3(1f - item.tooltip.snapTo.x, 0f, 0f), Camera.main.stereoActiveEye).x, toolTip.transform.position.y, toolTip.transform.position.z);
						(toolTip.transform as RectTransform).localPosition -= new Vector3((toolTip.transform as RectTransform).rect.width / 2f * toolTip.transform.localScale.x, 0f, 0f);
					}
					if (flag2)
					{
						toolTip.transform.position = new Vector3(Camera.main.ViewportToWorldPoint(new Vector3(item.tooltip.snapTo.x, 0f, 0f), Camera.main.stereoActiveEye).x, toolTip.transform.position.y, toolTip.transform.position.z);
						(toolTip.transform as RectTransform).localPosition += new Vector3((toolTip.transform as RectTransform).rect.width / 2f * toolTip.transform.localScale.x, 0f, 0f);
					}
					if (flag3)
					{
						toolTip.transform.position = new Vector3(toolTip.transform.position.x, Camera.main.ViewportToWorldPoint(new Vector3(0f, 1f - item.tooltip.snapTo.y, 0f)).y, toolTip.transform.position.z);
						(toolTip.transform as RectTransform).localPosition -= new Vector3(0f, (toolTip.transform as RectTransform).rect.height / 2f * toolTip.transform.localScale.y, 0f);
					}
					if (flag4)
					{
						toolTip.transform.position = new Vector3(toolTip.transform.position.x, Camera.main.ViewportToWorldPoint(new Vector3(0f, item.tooltip.snapTo.y, 0f)).y, toolTip.transform.position.z);
						(toolTip.transform as RectTransform).localPosition += new Vector3(0f, (toolTip.transform as RectTransform).rect.height / 2f * toolTip.transform.localScale.y, 0f);
					}
				}
				else
				{
					if (item.tooltip.autoRealignOptions != AutoRealignOptions.switchSide)
					{
						return;
					}
					Debug.Log("Switch");
					if (flag)
					{
						Debug.Log("outRight");
						int num4 = 4;
						if (item.tooltip.xAlign == XAligment.right)
						{
							num4 = 2;
						}
						(toolTip.transform as RectTransform).localPosition -= new Vector3((toolTip.transform as RectTransform).rect.width / (float)num4, 0f, 0f);
						(toolTip.transform as RectTransform).localPosition += new Vector3((num4 == 2) ? (-2f) : (-1f * item.tooltip.margin.x), 0f, 0f);
					}
					if (flag2)
					{
						Debug.Log("outLeft");
						int num5 = 4;
						if (item.tooltip.xAlign == XAligment.left)
						{
							num5 = 2;
						}
						(toolTip.transform as RectTransform).localPosition += new Vector3((toolTip.transform as RectTransform).rect.width / (float)num5, 0f, 0f);
						(toolTip.transform as RectTransform).localPosition += new Vector3((num5 == 2) ? (-2f) : (-1f * item.tooltip.margin.x), 0f, 0f);
					}
					if (flag3)
					{
						Debug.Log("outUp");
						int num6 = 4;
						if (item.tooltip.yAlign == YAligment.up)
						{
							num6 = 2;
						}
						(toolTip.transform as RectTransform).localPosition -= new Vector3(0f, (toolTip.transform as RectTransform).rect.height / (float)num6, 0f);
						(toolTip.transform as RectTransform).localPosition += new Vector3(0f, (num6 == 2) ? (-2f) : (-1f * item.tooltip.margin.y), 0f);
					}
					if (flag4)
					{
						int num7 = 4;
						if (item.tooltip.yAlign == YAligment.down)
						{
							num7 = 2;
						}
						(toolTip.transform as RectTransform).localPosition += new Vector3(0f, (toolTip.transform as RectTransform).rect.height / (float)num7, 0f);
						(toolTip.transform as RectTransform).localPosition += new Vector3(0f, (num7 == 2) ? (-2f) : (-1f * item.tooltip.margin.y), 0f);
						Debug.Log("outDown");
					}
				}
			}
			else
			{
				Object.Destroy(toolTip, 1E-07f);
				toolTip = null;
			}
		}

		private void OnDrawGizmos()
		{
			if (!toolTip)
			{
				return;
			}
			Item item = invUI.GetInventory().slots[slotNum].item;
			if (item == null || item.tooltip == null)
			{
				return;
			}
			Vector3[] array = new Vector3[4];
			tooltipRect.GetWorldCorners(array);
			for (int i = 0; i < array.Length; i++)
			{
				if (Camera.main.WorldToViewportPoint(array[i]).x > 1f || Camera.main.WorldToViewportPoint(array[i]).x < 0f || Camera.main.WorldToViewportPoint(array[i]).y > 1f || Camera.main.WorldToViewportPoint(array[i]).y < 0f)
				{
					Gizmos.color = Color.red;
				}
				else if (Camera.main.WorldToViewportPoint(array[i]).x == 1f || Camera.main.WorldToViewportPoint(array[i]).x == 0f || Camera.main.WorldToViewportPoint(array[i]).y == 1f || Camera.main.WorldToViewportPoint(array[i]).y == 0f)
				{
					Gizmos.color = Color.blue;
				}
				else if (Camera.main.WorldToViewportPoint(array[i]).x > 1f - item.tooltip.snapMargin.x || Camera.main.WorldToViewportPoint(array[i]).x < 0f + item.tooltip.snapMargin.x || Camera.main.WorldToViewportPoint(array[i]).y > 1f - item.tooltip.snapMargin.y || Camera.main.WorldToViewportPoint(array[i]).y < 0f + item.tooltip.snapMargin.y)
				{
					Gizmos.color = Color.yellow;
				}
				else
				{
					Gizmos.color = Color.green;
				}
				Gizmos.DrawSphere(array[i], 0.25f);
			}
		}
	}
}
