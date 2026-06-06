using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace PajamaLlama.SurvivalGuide
{
	[AddComponentMenu("Survival Guide/Linker")]
	[RequireComponent(typeof(TextMeshProUGUI))]
	public class Linker : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler
	{
		private TextMeshProUGUI _text;

		private bool _isHoveringObject;

		private int _selectedLink = -1;

		private Color32 _linkColor;

		private Color32 _hoverColor;

		private void Awake()
		{
			_text = GetComponent<TextMeshProUGUI>();
		}

		private void LateUpdate()
		{
			if (_isHoveringObject)
			{
				if (_selectedLink != -1)
				{
					SetLinkColor(_text.textInfo.linkInfo[_selectedLink], _linkColor);
					_selectedLink = -1;
				}
				int num = TMP_TextUtilities.FindIntersectingLink(_text, FlotsamInputManager.MousePosition, null);
				if (num != -1)
				{
					_selectedLink = num;
					TMP_LinkInfo linkInfo = _text.textInfo.linkInfo[num];
					_linkColor = ReturnLinkColor(linkInfo);
					_hoverColor = _linkColor.Tint(0.75f);
					SetLinkColor(linkInfo, _hoverColor);
				}
			}
		}

		public void OnPointerClick(PointerEventData eventData)
		{
			int num = TMP_TextUtilities.FindIntersectingLink(_text, eventData.position, null);
			if (num != -1)
			{
				TMP_LinkInfo tMP_LinkInfo = _text.textInfo.linkInfo[num];
				new StringEvent(GameEventType.OpenSurvivalGuidePage, tMP_LinkInfo.GetLinkID()).Dispatch();
			}
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
			_isHoveringObject = true;
		}

		public void OnPointerExit(PointerEventData eventData)
		{
			_isHoveringObject = false;
			if (_selectedLink != -1)
			{
				SetLinkColor(_text.textInfo.linkInfo[_selectedLink], _linkColor);
			}
		}

		public void OnPointerDown(PointerEventData eventData)
		{
		}

		private void SetLinkColor(TMP_LinkInfo linkInfo, Color32 color)
		{
			for (int i = 0; i < linkInfo.linkTextLength; i++)
			{
				int num = linkInfo.linkTextfirstCharacterIndex + i;
				TMP_CharacterInfo tMP_CharacterInfo = linkInfo.textComponent.textInfo.characterInfo[num];
				if (tMP_CharacterInfo.character != ' ')
				{
					int materialReferenceIndex = tMP_CharacterInfo.materialReferenceIndex;
					int vertexIndex = tMP_CharacterInfo.vertexIndex;
					Color32[] colors = linkInfo.textComponent.textInfo.meshInfo[materialReferenceIndex].colors32;
					colors[vertexIndex] = color;
					colors[vertexIndex + 1] = color;
					colors[vertexIndex + 2] = color;
					colors[vertexIndex + 3] = color;
				}
			}
			linkInfo.textComponent.UpdateVertexData(TMP_VertexDataUpdateFlags.All);
		}

		private Color32 ReturnLinkColor(TMP_LinkInfo linkInfo)
		{
			if (0 < linkInfo.linkTextLength)
			{
				int linkTextfirstCharacterIndex = linkInfo.linkTextfirstCharacterIndex;
				int materialReferenceIndex = linkInfo.textComponent.textInfo.characterInfo[linkTextfirstCharacterIndex].materialReferenceIndex;
				int vertexIndex = linkInfo.textComponent.textInfo.characterInfo[linkTextfirstCharacterIndex].vertexIndex;
				return linkInfo.textComponent.textInfo.meshInfo[materialReferenceIndex].colors32[vertexIndex];
			}
			return default(Color32);
		}
	}
}
