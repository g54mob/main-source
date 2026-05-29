using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	public class ChoiceRouteView : MonoBehaviour
	{
		private class RouteBranchView
		{
			public Image[] loadImages;

			public BranchIconImage branchIcon;

			public RouteNodeButton parent;

			public RouteNodeButton child;

			public ChoiceRouteCtrl.RouteBranch BranchData { get; private set; }

			public RouteBranchView(ChoiceRouteCtrl.RouteBranch branchData, RouteNodeButton parent, RouteNodeButton child)
			{
			}

			public void ChangeLoadColor(Color color)
			{
			}

			public void ChangeScaleIcon(float scale = 1f)
			{
			}

			public void ChangeEventIconColor(Color color)
			{
			}

			public void SetDesabledMaterial()
			{
			}

			public void SwitchIconOutline(bool on)
			{
			}

			public void UpdateIconSprite()
			{
			}
		}

		public RectTransform choiceNodeArea;

		public RouteNodeButton routeNodePrefab;

		public Image loadImage;

		public BranchIconImage eventIconPrefab;

		public Image bossMainImage;

		public DummyRouteBossImage dummyBossMain;

		public SimpleAnimation bossAnimation;

		public Image subImage;

		public SimpleAnimation subAnimation;

		[SerializeField]
		private float _loadPerDistance;

		[SerializeField]
		private int _ignoreLoadCount;

		[SerializeField]
		private Image _stageImage;

		[SerializeField]
		private GameObject _bossImageGroup;

		[SerializeField]
		private List<Sprite> _stageSprites;

		[SerializeField]
		private float _endlessDummyLoadGoal;

		private List<ChoiceRouteCtrl.RouteNode> _viewList;

		private List<ChoiceRouteCtrl.RouteNode> _selectedNode;

		private bool _referenceMode;

		private List<RouteNodeButton> _nodeButtons;

		private List<RouteBranchView> _branchViewList;

		private Vector2? _targetAnchoredPosition;

		private bool _isEndless;

		private bool _isActiveBossGroup;

		public List<RouteNodeButton> NodeButtons => null;

		public void InitInstance(List<ChoiceRouteCtrl.RouteNode> viewList, List<ChoiceRouteCtrl.RouteBranch> viewBranchList, bool referenceMode, bool isEndless = false, bool activeStageNum = true)
		{
		}

		public void ChangeRouteDivision(List<ChoiceRouteCtrl.RouteNode> viewList, List<ChoiceRouteCtrl.RouteBranch> viewBranchList, bool activeBossGroup = true)
		{
		}

		private void CreateNode()
		{
		}

		private List<RouteBranchView> CreateBranchView(List<ChoiceRouteCtrl.RouteBranch> branches)
		{
			return null;
		}

		private void CreateLine()
		{
		}

		private void UpLayerRouteNode()
		{
		}

		private void DisplayEventIcon()
		{
		}

		private void UpdateBossImage()
		{
		}

		private void UpdateStageImage()
		{
		}

		private void EmptyRoute()
		{
		}

		private List<ChoiceRouteCtrl.RouteNode> ConvertSelectedNode(List<string> selectedNodeIds)
		{
			return null;
		}

		public void UpdateRouteView(List<string> selectedNodeIds)
		{
		}

		public void UpdateBranchView(ChoiceRouteCtrl.RouteBranch branch)
		{
		}

		public void OnClickAction(ChoiceRouteCtrl.RouteNode node)
		{
		}

		public void OnPointerEnterAction(ChoiceRouteCtrl.RouteNode node)
		{
		}

		public void OnPointerExitAction(ChoiceRouteCtrl.RouteNode node)
		{
		}
	}
}
