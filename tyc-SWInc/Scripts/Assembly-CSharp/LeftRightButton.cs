using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class LeftRightButton : Button
{
	[FormerlySerializedAs("onLeftClick")]
	[SerializeField]
	private ButtonClickedEvent m_OnLeftClick = new ButtonClickedEvent();

	[FormerlySerializedAs("onRightClick")]
	[SerializeField]
	private ButtonClickedEvent m_OnRightClick = new ButtonClickedEvent();

	public ButtonClickedEvent onLeftClick
	{
		get
		{
			return m_OnLeftClick;
		}
		set
		{
			m_OnLeftClick = value;
		}
	}

	public ButtonClickedEvent onRightClick
	{
		get
		{
			return m_OnRightClick;
		}
		set
		{
			m_OnRightClick = value;
		}
	}

	public override void OnSubmit(BaseEventData eventData)
	{
		if (IsActive() && IsInteractable())
		{
			m_OnLeftClick.Invoke();
		}
		if (IsActive() && IsInteractable())
		{
			DoStateTransition(SelectionState.Pressed, false);
			StartCoroutine(OnFinishSubmit());
		}
	}

	private IEnumerator OnFinishSubmit()
	{
		float fadeTime = base.colors.fadeDuration;
		float elapsedTime = 0f;
		while (elapsedTime < fadeTime)
		{
			elapsedTime += Time.unscaledDeltaTime;
			yield return null;
		}
		DoStateTransition(base.currentSelectionState, false);
	}

	public override void OnPointerClick(PointerEventData eventData)
	{
		if (IsActive() && IsInteractable())
		{
			if (eventData.button == PointerEventData.InputButton.Left)
			{
				m_OnLeftClick.Invoke();
			}
			if (eventData.button == PointerEventData.InputButton.Right)
			{
				m_OnRightClick.Invoke();
			}
		}
	}
}
