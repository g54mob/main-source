using UnityEngine;
using UnityEngine.UI;
using __Project__.Scripts.PlayerAim;

public class AimSlot : MonoBehaviour
{
	[SerializeField]
	private GameObject tickImage;

	[SerializeField]
	private Image aimImage;

	private Button _button;

	private PlayerAimSettings _playerAimSettings;

	private int _id;

	public Image AimImage => null;

	public int Id => 0;

	public void Initialize(PlayerAimSettings playerAimSettings, int id, Sprite sprite)
	{
	}

	public void OnAimSlotClick()
	{
	}

	public void SetTick(bool value)
	{
	}

	public void SetSprite(Sprite aimIndex)
	{
	}
}
