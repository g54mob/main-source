using Gh.Tk.UI.Dialogs;
using UnityEngine;

namespace Gh.Tk
{
	public class GroupRequestButton3DUIView : Button3DUIView
	{
		private PatronAttractionChart _chart;

		private PatronAttractionChartGroupEventView _groupEventView;

		private Collider _ourCollider;

		private int _startHour;

		private int _hourRange;

		[SerializeField]
		private GameObject _pendingHeader;

		[SerializeField]
		private GameObject _pendingMoveableHeader;

		[SerializeField]
		private GameObject _confirmedHeader;

		[SerializeField]
		private GameObject _groupHighlight;

		[SerializeField]
		private Renderer[] _alwaysFilledBackers;

		[SerializeField]
		private Renderer[] _alwaysFilledBackersBright;

		[SerializeField]
		private Renderer[] _stateFilledBackers;

		[SerializeField]
		private Material[] tierMaterials;

		[SerializeField]
		private Material[] brightTierMaterials;

		[SerializeField]
		private Material _fadedMaterial;

		private static string BonusTextKey;

		private static string PenaltyTextKey;

		private bool _isDragging;

		public bool _finishedDraggingLastFrame;

		private Vector3 _startMousePos;

		private Vector3 _lastMousePos;

		private Vector3 _lastPosition;

		private Transform _dragHelper;

		private float _helperWorldZPosition;

		private static float _squaredDistanceDragThreshold;

		private Transform _groupEventViewPreviousParent;

		[SerializeField]
		private GameObject _timeRangeVisualPrefab;

		private Transform _timeRangeVisual;

		private bool IsFlexible => false;

		public void SetData(PatronAttractionChart chart, PatronAttractionChartGroupEventView groupEventView)
		{
		}

		private void SetBackerState(bool isPending)
		{
		}

		private void SetBackerColours(bool isComing)
		{
		}

		protected override TooltipData GetTooltipDataInternal()
		{
			return null;
		}

		protected override void UpdateIsPressed()
		{
		}

		private void Update()
		{
		}

		private void OnDragBegin()
		{
		}

		private void OnDragEnd()
		{
		}

		protected override void OnHoveredChanged()
		{
		}

		private void UpdateTimeRangeVisual()
		{
		}

		protected override void OnDestroy()
		{
		}
	}
}
