using System.Collections.Generic;
using Libs;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
	public class ChoiceRouteDialog : BaseDialog
	{
		public RectTransform choiceNodeArea;

		public GameObject displayGroup;

		public GameObject sameLevelNodeGroup;

		public BranchIconImage eventIconPrefab;

		public List<ChoiceRouteDataScriptableObject> choiceRouteDatas;

		public RouteNodeButton routeNodePrefab;

		public Image loadImage;

		public Vector2 randomAdjustment;

		public float paddingLeft;

		public float paddingRight;

		public float offsetX;

		public float spaceX;

		public float autoScrollX;

		public ScrollRect scrollRect;

		public RectTransform guidePallet;

		public GameObject closeButton;

		[SerializeField]
		[Tooltip("イベント交換の最大処理回数")]
		private int _maxAdjustmentCount;

		private static List<ChoiceRouteDataEntities> _routeData;

		private List<string> _selectedNodeIds;

		private const int maxBranchCount = 3;

		private static readonly Color selectableColor;

		private static readonly Color selectedColor;

		private static readonly Color dontSelectColor;

		private static readonly Color lightBlueColor;

		private Vector3 _initialGuidePosition;

		private SRandom routeRandom;

		private static int _divisionCount;

		private int _openDivision;
	}
}
