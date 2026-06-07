using FMODUnity;
using I2.Loc;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TechTreePanelInfo : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI _title;

	[SerializeField]
	private GameObject _unknownOverlay;

	[SerializeField]
	private ChildBehaviourCache<IconWithLabel> _requirementPrefab;

	[SerializeField]
	private ChildBehaviourCache<TechTreePanelInfoUnlockable> _unlockablePrefab;

	[SerializeField]
	private Button _button;

	[SerializeField]
	private TextMeshProUGUI _buttonText;

	[SerializeField]
	private LocalizedString _buttonTextResearch;

	[SerializeField]
	private LocalizedString _buttonTextCancel;

	[SerializeField]
	private GameObject _researchingGear_01;

	[SerializeField]
	private GameObject _researchingGear_02;

	[SerializeField]
	private GameObject _researchingGear_01_Disabled;

	[SerializeField]
	private GameObject _researchingGear_02_Disabled;

	[SerializeField]
	private EventReference _researchingGear_FMODEvent;

	private TechTreeNode _node;

	private TechTreePanelNode _panelNode;

	private CommunityResearch _communityResearch;

	private void OnEnable()
	{
		_button.onClick.AddListener(OnButtonClick);
		_communityResearch = Community.PlayerCommunity.Research;
		UpdateButton();
	}

	private void OnDisable()
	{
		_button.onClick.RemoveListener(OnButtonClick);
		if ((bool)_panelNode)
		{
			_panelNode.OnUpdated.RemoveListener(UpdateButton);
		}
		_panelNode = null;
		_node = null;
		FMODUIEventEmitter.StopEventReference(_researchingGear_FMODEvent);
	}

	public void SetNode(TechTreePanelNode panelNode)
	{
		if (_panelNode == panelNode)
		{
			return;
		}
		if ((bool)_panelNode)
		{
			_panelNode.OnUpdated.RemoveListener(UpdateButton);
		}
		_panelNode = panelNode;
		if ((bool)_panelNode && _panelNode.Node != null)
		{
			base.gameObject.SetActive(value: true);
			_panelNode.OnUpdated.AddListener(UpdateButton);
			_node = _panelNode.Node;
			_title.text = _node.GetNameUnknownified();
			_requirementPrefab.Reset();
			foreach (TechTreeRequirement requirement in _node.Requirements)
			{
				_requirementPrefab.Get(active: true).Initialize(requirement.GetIcon(), requirement.GetTooltip(null));
			}
			_requirementPrefab.Trim();
			_unlockablePrefab.Reset();
			foreach (ResearchUnlockable unlockable in _node.Unlockables)
			{
				_unlockablePrefab.Get(active: true).Initialize(unlockable);
			}
			_unlockablePrefab.Trim();
			UpdateButton();
		}
		else
		{
			_node = null;
			base.gameObject.SetActive(value: false);
		}
	}

	private void UpdateButton()
	{
		if (_node == null || _node.IsUnlocked() || _node.IsUnknown())
		{
			_button.gameObject.SetActive(value: false);
			_unknownOverlay.SetActive(_node != null && _node.IsUnknown());
			_researchingGear_01.SetActive(value: false);
			_researchingGear_02.SetActive(value: false);
			_researchingGear_01_Disabled.SetActive(value: false);
			_researchingGear_02_Disabled.SetActive(value: false);
			FMODUIEventEmitter.StopEventReference(_researchingGear_FMODEvent);
			return;
		}
		_button.gameObject.SetActive(value: true);
		_unknownOverlay.SetActive(value: false);
		if (_communityResearch.IsCurrentResearch(_node))
		{
			_buttonText.text = _buttonTextCancel;
			_button.interactable = true;
			_researchingGear_01.SetActive(value: true);
			_researchingGear_02.SetActive(value: true);
			_researchingGear_01_Disabled.SetActive(value: false);
			_researchingGear_02_Disabled.SetActive(value: false);
			FMODUIEventEmitter.PlayEventReferenceUnique(_researchingGear_FMODEvent);
		}
		else
		{
			_buttonText.text = _buttonTextResearch;
			_button.interactable = _node.IsResearchable() || BuildingDevTools.InstantUnlock;
			_researchingGear_01.SetActive(value: false);
			_researchingGear_02.SetActive(value: false);
			_researchingGear_01_Disabled.SetActive(value: true);
			_researchingGear_02_Disabled.SetActive(value: true);
			FMODUIEventEmitter.StopEventReference(_researchingGear_FMODEvent);
		}
	}

	private void OnButtonClick()
	{
		if (!(_node == null))
		{
			if (_communityResearch.IsCurrentResearch(_node))
			{
				_communityResearch.CancelResearch();
			}
			else if (BuildingDevTools.InstantUnlock)
			{
				_node.Unlock();
				GameEventDispatcher.Dispatch(GameEventType.ResearchFinished);
			}
			else if (_node.IsResearchable())
			{
				_communityResearch.StartResearch(_node);
			}
		}
	}
}
