using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Obj_DPSMeter_Bar : MonoBehaviour
{
	[SerializeField]
	private Image image_Bar;

	[SerializeField]
	private Image image_Icon;

	[SerializeField]
	private TMP_Text text_TowerName;

	[SerializeField]
	private TMP_Text text_Damage;

	[SerializeField]
	private GameObject node_Content;

	[SerializeField]
	private Sprite sprite_FireSourceIcon;

	private eItemType towerType;

	private int currentDamage;

	public eItemType TowerType => default(eItemType);

	public bool isInitialized { get; private set; }

	public void Setup(eItemType towerType, bool showOnInitialize)
	{
	}

	public void SetupAsFireSource(eDamageType damageType)
	{
	}

	public void UpdateDamage(int damage, int maxDamage)
	{
	}

	private string FormatNumber(int num)
	{
		return null;
	}
}
