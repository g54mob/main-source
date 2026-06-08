using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class SessionQuestScreen : MonoBehaviour
{
	[SerializeField]
	private SessionQuestManager sessionQuestManager;

	[SerializeField]
	[FormerlySerializedAs("sessionQuestDisplayPrefab")]
	private SessionQuestMenuCard sessionQuestMenuCardPrefab;

	[SerializeField]
	private Transform sessionQuestDisplayContainer;

	[SerializeField]
	private RewardTileViewerManager rewardTileViewerManager;

	private List<SessionQuestMenuCard> allDisplays;

	public Dictionary<SessionQuest, SessionQuestMenuCard> displayBySessionQuest;

	private void Awake()
	{
		allDisplays = new List<SessionQuestMenuCard>();
		displayBySessionQuest = new Dictionary<SessionQuest, SessionQuestMenuCard>();
	}

	private void Start()
	{
		Setup();
	}

	private void Setup()
	{
		foreach (SessionQuest sessionQuest in sessionQuestManager.sessionQuests)
		{
			if (!sessionQuest.compositeParentQuest)
			{
				CreateSessionQuestCard(sessionQuest);
			}
		}
		sessionQuestManager.OnOrderUpdated += UpdateOrder;
	}

	private void UpdateOrder()
	{
		for (int i = 0; i < sessionQuestManager.sessionQuests.Count; i++)
		{
			SessionQuest sessionQuest = sessionQuestManager.sessionQuests[i];
			if (!sessionQuest.compositeParentQuest)
			{
				displayBySessionQuest[sessionQuest].transform.SetSiblingIndex(i);
			}
		}
	}

	private void CreateSessionQuestCard(SessionQuest sessionQuest)
	{
		if (displayBySessionQuest.ContainsKey(sessionQuest))
		{
			Debug.LogError($"duplicate session quest in sessionQuestLibrary: {sessionQuest}");
			return;
		}
		SessionQuestMenuCard sessionQuestMenuCard = Object.Instantiate(sessionQuestMenuCardPrefab, sessionQuestDisplayContainer);
		sessionQuestMenuCard.Setup(this, sessionQuest, rewardTileViewerManager.GetTileViewer(sessionQuest), hasShadow: true);
		displayBySessionQuest.Add(sessionQuest, sessionQuestMenuCard);
		allDisplays.Add(sessionQuestMenuCard);
	}

	private void OnDestroy()
	{
		sessionQuestManager.OnOrderUpdated -= UpdateOrder;
	}

	public void SetGridSize(Vector2 cellSize)
	{
		sessionQuestDisplayContainer.GetComponentInChildren<GridLayoutGroup>().cellSize = cellSize;
	}
}
