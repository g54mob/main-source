using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class EmitterSecondaryRowEditor : MonoBehaviour, IPointerClickHandler, IEventSystemHandler
{
	public Text nameText;

	public Text countText;

	public Text payloadText;

	public Text costText;

	public Text delayText;

	public Text targetText;

	[NonSerialized]
	public EmitterSecondaryEditor editor;

	[NonSerialized]
	public Emitter.SecondaryEnemyRow row;

	public void OnPointerClick(PointerEventData eventData)
	{
	}

	public void SetData(Emitter.SecondaryEnemyRow row)
	{
	}

	public static string GetPayloadString(int payload)
	{
		return null;
	}

	public static string GetTargetBehaviorString(Emitter.SecondaryEnemyRow.TARGET_BEHAVIOR tb)
	{
		return null;
	}

	public void OnMoveUp()
	{
	}

	public void OnMoveDown()
	{
	}

	public void OnRemove()
	{
	}
}
