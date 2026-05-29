using System.Collections.Generic;
using UnityEngine;

public class SetRandomCard : MonoBehaviour
{
	public List<Card3dUIGroup> m_CardList;

	private void Start()
	{
		EvaluateCard();
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.B))
		{
			EvaluateCard();
		}
	}

	private void EvaluateCard()
	{
		List<EMonsterType> shownMonsterList = InventoryBase.GetShownMonsterList(ECardExpansionType.Tetramon);
		for (int i = 0; i < m_CardList.Count; i++)
		{
			CardData cardData = new CardData();
			ECardBorderType borderType = ECardBorderType.Base;
			cardData.monsterType = shownMonsterList[Random.Range(0, shownMonsterList.Count)];
			cardData.borderType = borderType;
			cardData.expansionType = ECardExpansionType.Tetramon;
			cardData.isNew = false;
			m_CardList[i].m_CardUI.SetCardUI(cardData);
		}
	}
}
