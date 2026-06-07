using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(AssignmentTooltip))]
public class AssignmentIcon : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
{
	[Header("General")]
	[SerializeField]
	private Image _backgroundImage;

	[SerializeField]
	private Image _assignmentImage;

	[SerializeField]
	private GUIAudio _GUIAudio;

	[SerializeField]
	private AssignmentTooltip _tooltip;

	[Header("Settings")]
	[SerializeField]
	private Color _normalColor = Color.white;

	[SerializeField]
	private Color _highlightedColor = new Color32(220, 220, 220, byte.MaxValue);

	[SerializeField]
	private Color _pressedColor = new Color32(180, 180, 180, byte.MaxValue);

	private AssignmentType _assignment;

	private AssignmentPanel _assignmentPanel;

	public void Initialize(AssignmentPanel panel, AssignmentSetting settings)
	{
		_assignmentPanel = panel;
		_assignment = settings.Type;
		_assignmentImage.sprite = settings.Sprite;
		_tooltip.Initialize(settings);
	}

	public void OnPointerDown(PointerEventData eventData)
	{
	}

	public void OnPointerClick(PointerEventData eventData)
	{
		StartCoroutine(TemporaryColourCoroutine(_pressedColor));
		if (eventData.button == PointerEventData.InputButton.Middle)
		{
			return;
		}
		_GUIAudio.OnButtonClick();
		if (!(_assignmentPanel == null))
		{
			switch (eventData.button)
			{
			case PointerEventData.InputButton.Left:
				_assignmentPanel.UpdatePriorityForAllEntries(increase: true, _assignment);
				break;
			case PointerEventData.InputButton.Right:
				_assignmentPanel.UpdatePriorityForAllEntries(increase: false, _assignment);
				break;
			}
		}
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		_backgroundImage.color = _highlightedColor;
		AgentEvent.Dispatch(null, _assignment);
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		_backgroundImage.color = _normalColor;
	}

	private IEnumerator TemporaryColourCoroutine(Color color, float time = 0.1f)
	{
		Color saveColor = _backgroundImage.color;
		_backgroundImage.color = color;
		yield return new WaitForSeconds(time);
		_backgroundImage.color = saveColor;
	}
}
