using TMPro;
using UnityEngine;

[RequireComponent(typeof(TMP_Text))]
public class ResearchPointCounter : SceneBehaviour
{
	private const bool CLAMP_TO_TECHTREE_REMAINING_COST = true;

	[SerializeField]
	private TMP_Text _text;

	private int _points;

	protected override void Awake()
	{
		base.Awake();
		if (_text == null)
		{
			_text = GetComponent<TMP_Text>();
		}
	}

	private void OnEnable()
	{
		GameEventDispatcher.AddListener(GameEventType.ResearchPointsUpdated, OnPointUpdated);
		SetPointAmount(Community.PlayerCommunity.Research.ResearchPoints);
	}

	private void OnDisable()
	{
		GameEventDispatcher.RemoveListener(GameEventType.ResearchPointsUpdated, OnPointUpdated);
	}

	private void OnPointUpdated(GameEvent gameEvent)
	{
		int researchPoints = Community.PlayerCommunity.Research.ResearchPoints;
		researchPoints = Mathf.Clamp(researchPoints, 0, GameSettings.Instance.TechTree.GetRemainingCost());
		if (_points != researchPoints)
		{
			SetPointAmount(Community.PlayerCommunity.Research.ResearchPoints);
		}
	}

	private void SetPointAmount(int points)
	{
		_points = points;
		_text.text = points.ToString();
	}
}
