using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class UiLinkOpener : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	[SerializeField]
	private TextMeshProUGUI targetLabel;

	[SerializeField]
	private bool highlightOnHover = true;

	[FormerlySerializedAs("OnClicked")]
	public UnityEvent<string> clicked;

	[FormerlySerializedAs("OnHoverStart")]
	public UnityEvent<string> hoverStart;

	[FormerlySerializedAs("OnHoverEnd")]
	public UnityEvent<string> hoverEnd;

	private int currentLinkIndex = -1;

	public void OnPointerClick(PointerEventData eventData)
	{
		int num = TMP_TextUtilities.FindIntersectingLink(targetLabel, eventData.position, eventData.enterEventCamera);
		if (num != -1)
		{
			Debug.Log($"click on link: {eventData.position}, {Input.mousePosition}, {eventData.enterEventCamera}", eventData.enterEventCamera);
			TMP_LinkInfo tMP_LinkInfo = targetLabel.textInfo.linkInfo[num];
			clicked?.Invoke(tMP_LinkInfo.GetLinkID());
		}
	}

	private void LateUpdate()
	{
		if (!OverwritingSingleton<IngameUi>.Instance || !highlightOnHover)
		{
			return;
		}
		int num = (TMP_TextUtilities.IsIntersectingRectTransform(targetLabel.rectTransform, Input.mousePosition, null) ? TMP_TextUtilities.FindIntersectingLink(targetLabel, Input.mousePosition, null) : (-1));
		if (currentLinkIndex != -1 && num != currentLinkIndex)
		{
			if (highlightOnHover)
			{
				SetLinkToColor(currentLinkIndex, Constants.UI.Colors.SelectedBlack);
			}
			currentLinkIndex = -1;
		}
		if (num != -1 && num != currentLinkIndex)
		{
			currentLinkIndex = num;
			if (highlightOnHover)
			{
				SetLinkToColor(num, Color.white);
			}
		}
	}

	private void SetLinkToColor(int linkIndex, Color32 color)
	{
		TMP_LinkInfo tMP_LinkInfo = targetLabel.textInfo.linkInfo[linkIndex];
		List<Color32[]> list = new List<Color32[]>();
		for (int i = 0; i < tMP_LinkInfo.linkTextLength; i++)
		{
			int num = tMP_LinkInfo.linkTextfirstCharacterIndex + i;
			TMP_CharacterInfo tMP_CharacterInfo = targetLabel.textInfo.characterInfo[num];
			int materialReferenceIndex = tMP_CharacterInfo.materialReferenceIndex;
			int vertexIndex = tMP_CharacterInfo.vertexIndex;
			Color32[] colors = targetLabel.textInfo.meshInfo[materialReferenceIndex].colors32;
			list.Add(Enumerable.ToArray(colors));
			if (tMP_CharacterInfo.isVisible)
			{
				colors[vertexIndex] = color;
				colors[vertexIndex + 1] = color;
				colors[vertexIndex + 2] = color;
				colors[vertexIndex + 3] = color;
			}
		}
		targetLabel.UpdateVertexData(TMP_VertexDataUpdateFlags.All);
	}
}
