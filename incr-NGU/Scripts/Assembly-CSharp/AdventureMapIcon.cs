using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class AdventureMapIcon : MonoBehaviour, IPointerClickHandler, IEventSystemHandler, IPointerEnterHandler, IPointerExitHandler
{
	public Character character;

	public int id;

	public void OnPointerClick(PointerEventData eventData)
	{
		character.adventureController.zone = id;
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		throw new NotImplementedException();
	}

	public void OnPointerExit(PointerEventData eventData)
	{
		throw new NotImplementedException();
	}

	private void Start()
	{
	}

	private void Update()
	{
	}
}
