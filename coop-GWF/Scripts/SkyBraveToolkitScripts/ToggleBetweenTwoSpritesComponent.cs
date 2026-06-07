using UnityEngine;
using UnityEngine.UI;

public class ToggleBetweenTwoSpritesComponent : MonoBehaviour
{
	public Image ImageComponent;

	public Sprite ImageA;

	public Sprite ImageB;

	public bool IsImageAActive = true;

	public void ToggleVisibility()
	{
		IsImageAActive = !IsImageAActive;
		ImageComponent.sprite = (IsImageAActive ? ImageA : ImageB);
	}
}
