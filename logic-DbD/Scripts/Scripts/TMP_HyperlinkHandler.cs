using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

[RequireComponent(typeof(TMP_Text))]
public sealed class TMP_HyperlinkHandler : MonoBehaviour, ISerializationCallbackReceiver, IPointerClickHandler, IEventSystemHandler, IPointerEnterHandler, IPointerExitHandler
{
	[SerializeField]
	private TMP_Text textComponent;

	private bool isEntered;

	public void OnBeforeSerialize()
	{
		if (textComponent == null)
		{
			textComponent = GetComponent<TMP_Text>();
		}
	}

	public void OnAfterDeserialize()
	{
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		Vector3 position = Camera.main.ScreenToWorldPoint(eventData.position);
		int num = TMP_TextUtilities.FindIntersectingLink(textComponent, position, null);
		if (num != -1)
		{
			TMP_LinkInfo tMP_LinkInfo = textComponent.textInfo.linkInfo[num];
			string linkText = tMP_LinkInfo.GetLinkText();
			CursorManager.SetCursorNormal();
			GetComponentInParent<Website>().LaunchInnerSite(linkText);
		}
	}

	private IEnumerator CheckCursor()
	{
		while (isEntered)
		{
			yield return new WaitForSeconds(0.01f);
			if (IsHoverLink(Mouse.current.position.ReadValue()))
			{
				CursorManager.SetCursorPointer();
			}
			else
			{
				CursorManager.SetCursorNormal();
			}
			yield return null;
		}
		CursorManager.SetCursorNormal();
	}

	private bool IsHoverLink(Vector3 mousePositionScreen)
	{
		Vector3 vector = Camera.main.ScreenToWorldPoint(mousePositionScreen);
		return TMP_TextUtilities.FindIntersectingLink(position: new Vector3(vector.x, vector.y, 0f), text: textComponent, camera: null) > -1;
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		isEntered = true;
		StartCoroutine(CheckCursor());
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		isEntered = false;
	}
}
