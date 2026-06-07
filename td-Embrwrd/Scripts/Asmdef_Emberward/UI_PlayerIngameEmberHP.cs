using TMPro;
using UnityEngine;

public class UI_PlayerIngameEmberHP : MonoBehaviour
{
	[SerializeField]
	private TMP_Text text_HP;

	[SerializeField]
	private GameObject node_Armor;

	[SerializeField]
	private TMP_Text text_Armor;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void OnRequestHidePlayerHPUI()
	{
	}

	private void Start()
	{
	}

	private void OnHPChanged(int value)
	{
	}

	private void OnArmorChanged(int value, int delta)
	{
	}
}
