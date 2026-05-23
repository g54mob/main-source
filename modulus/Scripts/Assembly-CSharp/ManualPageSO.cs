using System.Collections.Generic;
using Data.Variables;
using UnityEngine;

[CreateAssetMenu(fileName = "ManualPage", menuName = "Manual/Manual Page")]
public class ManualPageSO : ScriptableObject
{
	[SerializeField]
	[LocaKey]
	private string _pageNameLoca;

	[SerializeField]
	private List<PageElementSO> _pageElements = new List<PageElementSO>();

	[SerializeField]
	private BoolVariableSO _requiredUnlockCondition;

	public string PageNameLoca => _pageNameLoca;

	public List<PageElementSO> PageElements => _pageElements;

	public BoolVariableSO RequiredUnlockCondition => _requiredUnlockCondition;
}
