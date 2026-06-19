using Pug.Sprite;
using UnityEngine;

public class AimUI : MonoBehaviour
{
	public SpriteObject icon;

	public PlayerController player;

	private void OnEnable()
	{
		HideAim();
	}

	public void UpdateAimPosition()
	{
		if (player != null)
		{
			icon.transform.localPosition = new Vector3(player.aimDirection.x, player.aimDirection.z, 0f) * 3f;
		}
	}

	public void ShowAim(Color color, float pointerFade)
	{
		color.a = pointerFade;
		icon.color = color;
		icon.transform.localScale = Manager.ui.CalcGameplayUITargetScaleMultiplier();
	}

	public void HideAim()
	{
		icon.transform.localScale = Vector3.zero;
	}
}
