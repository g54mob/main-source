using UnityEngine;
using UnityEngine.UI;

public class BaseSidebarBtn : MonoBehaviour
{
	public CoolButton Btn;

	public Image Icon;

	public string Label;

	public bool IsEnabled;

	public bool IsActiveMode;

	public Sprite SprIcon;

	public Sprite SprIconHover;

	public Sprite SprHighlighted;

	private void Awake()
	{
	}

	public void SetEnabled(bool isEnabled)
	{
	}

	public void SetIsActiveMode(bool isActive)
	{
	}

	public void Select()
	{
	}

	private void OnHover()
	{
	}

	private void OnHoverExit()
	{
	}

	private void OnStateChanged()
	{
	}
}
