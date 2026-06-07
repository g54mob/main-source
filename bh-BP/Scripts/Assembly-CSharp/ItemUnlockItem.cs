using UnityEngine;
using UnityEngine.UI;

public class ItemUnlockItem : MonoBehaviour
{
	public Image ImgIcon;

	public CoolButton Btn;

	public UpgradeInfo TgtInf;

	private bool _isHidden;

	private void Awake()
	{
	}

	public void Init(UpgradeInfo inf)
	{
	}

	public void InitHidden(UpgradeInfo inf)
	{
	}

	private void OnHover()
	{
	}

	private void OnHoverExit()
	{
	}
}
