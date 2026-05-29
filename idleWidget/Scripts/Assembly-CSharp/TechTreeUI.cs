using Assets.Source.Player;
using UnityEngine;

public class TechTreeUI : FullScreenUI
{
	[SerializeField]
	private RectTransform _smelterTutorialArrow;

	private TechTreeRoot _worldRoot;

	public static TechTreeUI Instance { get; private set; }

	private void Awake()
	{
		Instance = this;
	}

	private void Update()
	{
		if (base.FullScreenActive && _smelterTutorialArrow.gameObject.activeSelf && (bool)_worldRoot.IronTutorialNode)
		{
			_smelterTutorialArrow.anchoredPosition = base.ActiveCamera.WorldToScreenPoint(_worldRoot.IronTutorialNode.transform.position);
			TechNode techNode = "t1u_iron_smelter_auto";
			if (GamePlayer.Current.HasTech(techNode) || GamePlayer.Current.GetTechConstruction(techNode) != null)
			{
				_smelterTutorialArrow.gameObject.SetActive(value: false);
			}
		}
	}

	public override void OnFullScreenActivate()
	{
		_worldRoot = base.WorldComponent.GetComponent<TechTreeRoot>();
		if (GameUI.Instance.HideTechTutorial())
		{
			_smelterTutorialArrow.gameObject.SetActive(value: true);
		}
	}

	public void UpdateNodes()
	{
		TechTreeNode[] componentsInChildren = base.WorldComponent.GetComponentsInChildren<TechTreeNode>();
		for (int i = 0; i < componentsInChildren.Length; i++)
		{
			componentsInChildren[i].UpdateStatus();
		}
	}
}
