using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StandingQuotaUI : MonoBehaviour
{
	[SerializeField]
	private QuotaItemStackUI _uiQuotaStackPrefab;

	[SerializeField]
	private Transform _uiQuotaStackParent;

	[SerializeField]
	private GridLayoutGroup _gridLayout;

	private List<QuotaItemStackUI> _uiStacks;

	private QuotaGroup _quota;

	public void Initiate(QuotaGroup quota)
	{
	}

	public void Clear()
	{
	}
}
