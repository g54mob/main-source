using UnityEngine;

public abstract class HUDMenu : MonoBehaviour
{
	[SerializeField]
	protected AudioData backButtonSound;

	private HUD hud;

	protected HUD Hud
	{
		get
		{
			if (!hud)
			{
				Hud = GameManager.instance.PlayerController.CurrentHUD;
			}
			return hud;
		}
		set
		{
			hud = value;
		}
	}

	protected virtual void Awake()
	{
	}

	protected virtual void Start()
	{
	}

	public virtual bool BackButtonPressed()
	{
		if (Hud.CurrentModalWindow != null)
		{
			return false;
		}
		if (backButtonSound != null)
		{
			AudioSystem.Instance.PlaySound2D(backButtonSound);
		}
		return true;
	}
}
