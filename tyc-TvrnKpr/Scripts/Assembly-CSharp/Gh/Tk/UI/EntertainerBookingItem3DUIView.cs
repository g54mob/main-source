using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using DG.Tweening;
using Gh.Tk.UI.Dialogs;
using TMPro;
using UnityEngine;

namespace Gh.Tk.UI
{
	public class EntertainerBookingItem3DUIView : Button3DUIView, IContextMenuProvider
	{
		private BookedEntertainerEvent _ourEvent;

		[Header("Stars")]
		[SerializeField]
		private Container3DUIView _starsContainer;

		[SerializeField]
		private List<GameObject> _stars;

		[Header("Side Panels")]
		[SerializeField]
		private TMP_Text _costText;

		[SerializeField]
		private TMP_Text _cantAffordCostText;

		[SerializeField]
		private Transform _cantAffordCostTag;

		[SerializeField]
		private Transform _costTag;

		[SerializeField]
		private Transform _costPanel;

		[SerializeField]
		private Vector3 _costPanelHiddenOffset;

		[Header("Dragging")]
		private EntertainerTimeline3DUIView _timeline;

		[SerializeField]
		private Transform _draggingAnchor;

		private Vector3 _dragStartLocation;

		private bool _isDragging;

		[SerializeField]
		private float _unsnappedDragZDistance;

		private bool isSnapped;

		private RaycastHit[] _hits;

		private bool _hasPaid;

		private Tween _positionTween;

		private Vector3 _draggableAnchorOffset;

		private bool _useDraggableAnchorOffset;

		private Quaternion _startingRotation;

		private float _currentTweenProgress;

		private Vector3 _targetPosition;

		[SerializeField]
		private float _tweenDuration;

		public DissolveArea3DUIView dissolveArea;

		public DraggableAttractionBoard draggableBoard;

		public EntertainerProfile Profile { get; private set; }

		public bool IsBooked => false;

		public new bool IsLocked => false;

		public override bool IsPressed
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public static event EventHandler BookingChanged
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		protected override void Start()
		{
		}

		private void OnMoneyChanged(object sender, EventArgs<int> e)
		{
		}

		private bool CanAfford()
		{
			return false;
		}

		private void UpdateCostText()
		{
		}

		public void SetData(EntertainerProfile profile, EntertainerTimeline3DUIView timeline, BookedEntertainerEvent bookedEvent)
		{
		}

		private void ShowCostPanel()
		{
		}

		private void HideCostPanel()
		{
		}

		private void OnDragStart()
		{
		}

		private void OnDragging()
		{
		}

		private Vector2 GetSnappingPointOffset()
		{
			return default(Vector2);
		}

		private void UpdateBookingState()
		{
		}

		private void SnapToBookedPosition(TimelineSnappingData snapData, bool animate = true)
		{
		}

		private void RemoveBooking()
		{
		}

		private void UpdateBookingHour(int bookingHour)
		{
		}

		private void Pay()
		{
		}

		private void Refund()
		{
		}

		private void OnDragEnd()
		{
		}

		protected override void OnHoveredChanged()
		{
		}

		public void MoveToTargetPosition(Vector3 targetPosition, bool useDraggableAnchorOffset, bool animate = true)
		{
		}

		private void Update()
		{
		}

		protected override void OnEnable()
		{
		}

		public void UpdateMaterials()
		{
		}

		protected override void OnDestroy()
		{
		}

		protected override void OnDisable()
		{
		}

		public override TooltipData GetTooltipData()
		{
			return null;
		}

		public IEnumerable<ContextMenuItem> GetContextMenuItems()
		{
			return null;
		}
	}
}
