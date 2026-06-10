using System.Collections.Generic;
using UnityEngine;

public class BuyInterfaceController : MonoBehaviour
{
	[Header("Settings")]
	public bool sellMode;

	[Header("References")]
	public RectTransform pageRect;

	public WindowContentController wcc;

	public Company company;

	[Header("Prefabs")]
	public GameObject elementPrefab;

	private List<ShopSelectButtonController> spawned;

	public void Setup(WindowContentController newWcc)
	{
	}

	private void OnEnable()
	{
	}

	public void UpdateElements()
	{
	}

	public void UpdatePurchaseAbility()
	{
	}
}
