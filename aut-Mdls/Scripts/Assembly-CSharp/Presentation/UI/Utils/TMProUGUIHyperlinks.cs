using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Presentation.UI.Utils
{
	[DisallowMultipleComponent]
	[RequireComponent(typeof(TextMeshProUGUI))]
	public class TMProUGUIHyperlinks : MonoBehaviour, IPointerDownHandler, IEventSystemHandler, IPointerUpHandler
	{
		[SerializeField]
		private Color32 hoveredColor = new Color32(0, 89, byte.MaxValue, byte.MaxValue);

		[SerializeField]
		private Color32 pressedColor = new Color32(0, 0, 183, byte.MaxValue);

		[SerializeField]
		private Color32 usedColor = new Color32(byte.MaxValue, 0, byte.MaxValue, byte.MaxValue);

		[SerializeField]
		private Color32 usedHoveredColor = new Color32(253, 94, 253, byte.MaxValue);

		[SerializeField]
		private Color32 usedPressedColor = new Color32(207, 0, 207, byte.MaxValue);

		private List<Color32[]> startColors = new List<Color32[]>();

		private TextMeshProUGUI textMeshPro;

		private Dictionary<int, bool> usedLinks = new Dictionary<int, bool>();

		private int hoveredLinkIndex = -1;

		private int pressedLinkIndex = -1;

		private Camera mainCamera;

		private void Awake()
		{
			textMeshPro = GetComponent<TextMeshProUGUI>();
			mainCamera = Camera.main;
			if (textMeshPro.canvas.renderMode == RenderMode.ScreenSpaceOverlay)
			{
				mainCamera = null;
			}
			else if (textMeshPro.canvas.worldCamera != null)
			{
				mainCamera = textMeshPro.canvas.worldCamera;
			}
		}

		public void OnPointerDown(PointerEventData eventData)
		{
			int linkIndex = GetLinkIndex();
			if (linkIndex != -1)
			{
				pressedLinkIndex = linkIndex;
				if (usedLinks.TryGetValue(linkIndex, out var value) && value)
				{
					if (pressedLinkIndex != hoveredLinkIndex)
					{
						startColors = SetLinkColor(linkIndex, usedPressedColor);
					}
					else
					{
						SetLinkColor(linkIndex, usedPressedColor);
					}
				}
				else if (pressedLinkIndex != hoveredLinkIndex)
				{
					startColors = SetLinkColor(linkIndex, pressedColor);
				}
				else
				{
					SetLinkColor(linkIndex, pressedColor);
				}
				hoveredLinkIndex = pressedLinkIndex;
			}
			else
			{
				pressedLinkIndex = -1;
			}
		}

		public void OnPointerUp(PointerEventData eventData)
		{
			int linkIndex = GetLinkIndex();
			if (linkIndex != -1 && linkIndex == pressedLinkIndex)
			{
				TMP_LinkInfo tMP_LinkInfo = textMeshPro.textInfo.linkInfo[linkIndex];
				SetLinkColor(linkIndex, usedHoveredColor);
				startColors.ForEach(delegate(Color32[] c)
				{
					c[0] = (c[1] = (c[2] = (c[3] = usedColor)));
				});
				usedLinks[linkIndex] = true;
				Application.OpenURL(tMP_LinkInfo.GetLinkID());
			}
			pressedLinkIndex = -1;
		}

		private void LateUpdate()
		{
			int linkIndex = GetLinkIndex();
			if (linkIndex != -1)
			{
				if (linkIndex == hoveredLinkIndex)
				{
					return;
				}
				if (hoveredLinkIndex != -1)
				{
					ResetLinkColor(hoveredLinkIndex, startColors);
				}
				hoveredLinkIndex = linkIndex;
				if (usedLinks.TryGetValue(linkIndex, out var value) && value)
				{
					if (pressedLinkIndex == linkIndex)
					{
						startColors = SetLinkColor(hoveredLinkIndex, usedPressedColor);
					}
					else
					{
						startColors = SetLinkColor(hoveredLinkIndex, usedHoveredColor);
					}
				}
				else if (pressedLinkIndex == linkIndex)
				{
					startColors = SetLinkColor(hoveredLinkIndex, pressedColor);
				}
				else
				{
					startColors = SetLinkColor(hoveredLinkIndex, hoveredColor);
				}
			}
			else if (hoveredLinkIndex != -1)
			{
				ResetLinkColor(hoveredLinkIndex, startColors);
				hoveredLinkIndex = -1;
			}
		}

		private int GetLinkIndex()
		{
			return TMP_TextUtilities.FindIntersectingLink(textMeshPro, Input.mousePosition, mainCamera);
		}

		private List<Color32[]> SetLinkColor(int linkIndex, Color32 color)
		{
			TMP_LinkInfo tMP_LinkInfo = textMeshPro.textInfo.linkInfo[linkIndex];
			List<Color32[]> list = new List<Color32[]>();
			int num = -1;
			for (int i = 0; i < tMP_LinkInfo.linkTextLength; i++)
			{
				int num2 = tMP_LinkInfo.linkTextfirstCharacterIndex + i;
				TMP_CharacterInfo tMP_CharacterInfo = textMeshPro.textInfo.characterInfo[num2];
				int materialReferenceIndex = tMP_CharacterInfo.materialReferenceIndex;
				int vertexIndex = tMP_CharacterInfo.vertexIndex;
				Color32[] colors = textMeshPro.textInfo.meshInfo[materialReferenceIndex].colors32;
				list.Add(new Color32[4]
				{
					colors[vertexIndex],
					colors[vertexIndex + 1],
					colors[vertexIndex + 2],
					colors[vertexIndex + 3]
				});
				if (tMP_CharacterInfo.isVisible)
				{
					colors[vertexIndex] = color;
					colors[vertexIndex + 1] = color;
					colors[vertexIndex + 2] = color;
					colors[vertexIndex + 3] = color;
				}
				if (tMP_CharacterInfo.isVisible && tMP_CharacterInfo.underlineVertexIndex > 0 && tMP_CharacterInfo.underlineVertexIndex != num && tMP_CharacterInfo.underlineVertexIndex < colors.Length)
				{
					num = tMP_CharacterInfo.underlineVertexIndex;
					for (int j = 0; j < 12; j++)
					{
						colors[num + j] = color;
					}
				}
			}
			textMeshPro.UpdateVertexData(TMP_VertexDataUpdateFlags.All);
			return list;
		}

		private void ResetLinkColor(int linkIndex, List<Color32[]> startColors)
		{
			TMP_LinkInfo tMP_LinkInfo = textMeshPro.textInfo.linkInfo[linkIndex];
			int num = -1;
			for (int i = 0; i < tMP_LinkInfo.linkTextLength; i++)
			{
				int num2 = tMP_LinkInfo.linkTextfirstCharacterIndex + i;
				TMP_CharacterInfo tMP_CharacterInfo = textMeshPro.textInfo.characterInfo[num2];
				int materialReferenceIndex = tMP_CharacterInfo.materialReferenceIndex;
				int vertexIndex = tMP_CharacterInfo.vertexIndex;
				Color32[] colors = textMeshPro.textInfo.meshInfo[materialReferenceIndex].colors32;
				if (tMP_CharacterInfo.isVisible)
				{
					colors[vertexIndex] = startColors[i][0];
					colors[vertexIndex + 1] = startColors[i][1];
					colors[vertexIndex + 2] = startColors[i][2];
					colors[vertexIndex + 3] = startColors[i][3];
				}
				if (tMP_CharacterInfo.isVisible && tMP_CharacterInfo.underlineVertexIndex > 0 && tMP_CharacterInfo.underlineVertexIndex != num && tMP_CharacterInfo.underlineVertexIndex < colors.Length)
				{
					num = tMP_CharacterInfo.underlineVertexIndex;
					for (int j = 0; j < 12; j++)
					{
						colors[num + j] = startColors[i][0];
					}
				}
			}
			textMeshPro.UpdateVertexData(TMP_VertexDataUpdateFlags.All);
		}
	}
}
