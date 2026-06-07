using TMPro;
using UnityEngine;

public class UI_MapScene_PlayerHP : MonoBehaviour
{
	[SerializeField]
	private TMP_Text text_HPValue;

	[SerializeField]
	private Transform node_Particle;

	[SerializeField]
	private UI_PlayerEmber ui_PlayerEmber;

	[SerializeField]
	private Vector2 particleSizeRange;

	[SerializeField]
	private Vector2 particleSizeFromHPRange;

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	private void Start()
	{
	}

	private void OnMaxHPChanged(int curHP, int maxHP)
	{
	}

	private void OnPlayerHPChanged(int value)
	{
	}

	private void SetValue(int value)
	{
	}
}
