using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(TMP_Text))]
public class TextMeshProLinkHandler : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	public Color hoveredColor = Color.white;

	public Color unhoveredColor = Color.cyan;

	private TMP_Text tmPro;

	private Camera cam;

	private TMP_LinkInfo lastHoveredLinkInfo;

	private int lastHoveredLinkIndex = -1;

	public event Action<string> LinkClicked;

	public event Action<string> LinkHovered;

	private void Awake()
	{
		tmPro = base.gameObject.GetComponent<TMP_Text>();
		Canvas componentInParent = base.gameObject.GetComponentInParent<Canvas>();
		if (componentInParent.renderMode != RenderMode.ScreenSpaceOverlay)
		{
			cam = componentInParent.worldCamera;
		}
	}

	private void OnEnable()
	{
		TMPro_EventManager.TEXT_CHANGED_EVENT.Add(ColorizeAllLinks);
	}

	private void OnDisable()
	{
		TMPro_EventManager.TEXT_CHANGED_EVENT.Remove(ColorizeAllLinks);
	}

	private void ColorizeAllLinks(UnityEngine.Object obj)
	{
		if (obj == tmPro)
		{
			lastHoveredLinkIndex = -1;
			for (int i = 0; i < tmPro.textInfo.linkCount; i++)
			{
				TMP_LinkInfo linkInfo = tmPro.textInfo.linkInfo[i];
				ColorizeLink(linkInfo, unhoveredColor);
			}
		}
	}

	private void LateUpdate()
	{
		int num = TMP_TextUtilities.FindIntersectingLink(tmPro, Input.mousePosition, cam);
		if (num == lastHoveredLinkIndex)
		{
			return;
		}
		try
		{
			this.LinkHovered?.Invoke((num == -1) ? null : tmPro.textInfo.linkInfo[num].GetLinkID());
		}
		catch (Exception exception)
		{
			Debug.LogException(exception);
		}
		if (lastHoveredLinkIndex != -1)
		{
			try
			{
				ColorizeLink(lastHoveredLinkInfo, unhoveredColor);
			}
			catch (IndexOutOfRangeException exception2)
			{
				Debug.LogException(exception2);
			}
		}
		lastHoveredLinkIndex = num;
		if (num != -1)
		{
			lastHoveredLinkInfo = tmPro.textInfo.linkInfo[num];
			try
			{
				ColorizeLink(lastHoveredLinkInfo, hoveredColor);
			}
			catch (IndexOutOfRangeException exception3)
			{
				Debug.LogException(exception3);
			}
		}
	}

	void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
	{
		if (lastHoveredLinkIndex != -1)
		{
			TMP_LinkInfo tMP_LinkInfo = tmPro.textInfo.linkInfo[lastHoveredLinkIndex];
			string linkID = tMP_LinkInfo.GetLinkID();
			this.LinkClicked?.Invoke(linkID);
		}
	}

	private void ColorizeLink(TMP_LinkInfo linkInfo, Color color)
	{
		for (int i = linkInfo.linkTextfirstCharacterIndex; i < linkInfo.linkTextfirstCharacterIndex + linkInfo.linkTextLength; i++)
		{
			if (i >= tmPro.textInfo.characterInfo.Length)
			{
				Debug.LogError($"i: {i}, len: {tmPro.textInfo.characterInfo.Length}");
				return;
			}
			TMP_CharacterInfo tMP_CharacterInfo = tmPro.textInfo.characterInfo[i];
			if (!char.IsWhiteSpace(tMP_CharacterInfo.character))
			{
				int materialReferenceIndex = tMP_CharacterInfo.materialReferenceIndex;
				int vertexIndex = tMP_CharacterInfo.vertexIndex;
				Color32[] colors = tmPro.textInfo.meshInfo[materialReferenceIndex].colors32;
				colors[vertexIndex] = color;
				colors[vertexIndex + 1] = color;
				colors[vertexIndex + 2] = color;
				colors[vertexIndex + 3] = color;
			}
		}
		tmPro.UpdateVertexData(TMP_VertexDataUpdateFlags.All);
	}
}
