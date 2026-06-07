using UnityEngine;
using UnityEngine.UI;

public class UI_PlayerHurtScreenFlash : MonoBehaviour
{
	[SerializeField]
	private float flashtime_In;

	[SerializeField]
	private float flashtime_Out;

	[SerializeField]
	private Image image_Flash;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void Start()
	{
	}

	private void OnMonsterDealDamageToPlayer(AMonsterBase monster, int damage, int hpDamage, int armorDamage)
	{
	}

	private void OnHideCommonIngameUI()
	{
	}
}
