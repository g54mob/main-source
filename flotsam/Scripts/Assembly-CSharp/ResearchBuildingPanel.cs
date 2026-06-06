using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResearchBuildingPanel : MonoBehaviour, IBuildablePanelElement
{
	[SerializeField]
	private GameObject _researchParent;

	[SerializeField]
	private GameObject _noResearchParent;

	[SerializeField]
	private Image _researchImage;

	[SerializeField]
	private Animator _researchAnimator;

	[SerializeField]
	private TextMeshProUGUI _researchName;

	[SerializeField]
	private LocalizedString _defaultTitleText = null;

	[SerializeField]
	private Slider _progressSlider;

	private ResearchStation _researchStation;

	public BuildablePanelElementId Id => BuildablePanelElementId.Research;

	private void OnDestroy()
	{
		if (_researchStation != null)
		{
			_researchStation.OnStartResearching.RemoveListener(UpdateStationResearching);
			_researchStation.OnStopResearching.RemoveListener(UpdateStationResearching);
		}
		GameEventDispatcher.RemoveListener(GameEventType.ResearchStarted, UpdatePanel);
		GameEventDispatcher.RemoveListener(GameEventType.ResearchFinished, UpdatePanel);
		GameEventDispatcher.RemoveListener(GameEventType.ResearchCancelled, UpdatePanel);
	}

	public bool Activate(Buildable buildable, bool finished)
	{
		Deactivate();
		if (finished && buildable.TryReturnBuildableExtendable<ResearchStation>(out _researchStation))
		{
			base.gameObject.SetActive(value: true);
			_researchStation.OnStartResearching.AddListener(UpdateStationResearching);
			_researchStation.OnStopResearching.AddListener(UpdateStationResearching);
			_researchStation.OnResearch.AddListener(UpdateResearchProgress);
			UpdateStationResearching();
			UpdateResearchProgress();
			UpdatePanel();
			GameEventDispatcher.AddListener(GameEventType.ResearchStarted, UpdatePanel);
			GameEventDispatcher.AddListener(GameEventType.ResearchFinished, UpdatePanel);
			GameEventDispatcher.AddListener(GameEventType.ResearchCancelled, UpdatePanel);
			return true;
		}
		return false;
	}

	public void Deactivate()
	{
		base.gameObject.SetActive(value: false);
		if (_researchStation != null)
		{
			_researchStation.OnStartResearching.RemoveListener(UpdateStationResearching);
			_researchStation.OnStopResearching.RemoveListener(UpdateStationResearching);
			_researchStation.OnResearch.RemoveListener(UpdateResearchProgress);
		}
		GameEventDispatcher.RemoveListener(GameEventType.ResearchStarted, UpdatePanel);
		GameEventDispatcher.RemoveListener(GameEventType.ResearchFinished, UpdatePanel);
		GameEventDispatcher.RemoveListener(GameEventType.ResearchCancelled, UpdatePanel);
	}

	private void UpdateResearchProgress()
	{
		if (_progressSlider != null)
		{
			_progressSlider.value = _researchStation.NormalizedProgress;
		}
	}

	private void UpdateStationResearching()
	{
		_researchAnimator.SetBool("IsResearching", _researchStation.IsResearching);
	}

	private void UpdatePanel(GameEvent gameEvent = null)
	{
		CommunityResearch.Research currentResearch = Community.PlayerCommunity.Research.CurrentResearch;
		bool flag = currentResearch != null;
		_researchParent.SetActive(flag);
		_noResearchParent.SetActive(!flag);
		if (flag)
		{
			_researchImage.sprite = currentResearch.TechTreeNode.Icon;
			_researchName.text = currentResearch.TechTreeNode.Name;
		}
		else
		{
			_researchName.text = _defaultTitleText;
		}
	}

	public void ToggleResearchPanel()
	{
		GameManager.UIManager.DisplayPanel(PanelID.TechTreePanel);
	}

	public void SelectCurrentResearch()
	{
		GameManager.UIManager.SelectCurrentResearch();
	}
}
