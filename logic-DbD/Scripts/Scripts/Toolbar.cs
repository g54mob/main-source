using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

public class Toolbar : MonoBehaviour, IDragHandler, IEventSystemHandler
{
	private Canvas canvas;

	private RectTransform window;

	private GameObject panel;

	private ClosePanelAudio audioPlayer;

	private void Start()
	{
		audioPlayer = SoundEffectUtils.GetOpenClosePanelPlayer();
		window = base.transform.parent.GetComponent<RectTransform>();
		panel = base.transform.parent.gameObject;
	}

	public Transform GetMinimize()
	{
		return base.transform.Find("Minimize");
	}

	public void OnDrag(PointerEventData eventData)
	{
		if (eventData.button == PointerEventData.InputButton.Left)
		{
			if (canvas == null)
			{
				canvas = UIUtils.FindCanvasFromChild(base.transform);
			}
			window.anchoredPosition += eventData.delta / canvas.scaleFactor;
			float distanceFromCenterTop = window.rect.height / 2f;
			float screenFixedRatio = UIUtils.GetScreenFixedRatio();
			float x = AddDimension(window.localPosition.x, 0f, 0f, (float)Screen.width * screenFixedRatio / 2f, "X");
			float y = AddDimension(window.localPosition.y, distanceFromCenterTop, 0f, (float)Screen.height * screenFixedRatio / 2f, "Y");
			window.localPosition = new Vector2(x, y);
			panel.GetComponent<Panel>().SetCurrentPosition();
		}
	}

	public void Close()
	{
		audioPlayer.PlayClose();
		panel.GetComponent<Panel>().ClosePanel();
	}

	public void Minimize()
	{
		panel.GetComponent<Panel>().MinimizePanel();
	}

	public void AddCloseFunction(UnityAction additionalCloseFunction)
	{
		Button componentInChildren = base.transform.GetComponentInChildren<Button>();
		if (componentInChildren != null)
		{
			componentInChildren.onClick.AddListener(additionalCloseFunction);
		}
	}

	private float AddDimension(float localPos, float distanceFromCenterTop, float distanceFromCenterBottom, float max, string cord)
	{
		if (localPos + distanceFromCenterTop > max)
		{
			return max - distanceFromCenterTop;
		}
		if (localPos - distanceFromCenterBottom < 0f - max)
		{
			return 0f - max + distanceFromCenterBottom;
		}
		return localPos;
	}
}
