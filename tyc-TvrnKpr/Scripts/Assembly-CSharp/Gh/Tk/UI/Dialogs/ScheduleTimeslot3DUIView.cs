using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Gh.Tk.UI.Dialogs
{
	public class ScheduleTimeslot3DUIView : Button3DUIView
	{
		private static PrefabObjectPool _segmentPool;

		[SerializeField]
		private GameObject _slotSegmentPrefab;

		[SerializeField]
		private BoxCollider _segmentContainerCollider;

		[SerializeField]
		private Container3DUIView _segmentContainer;

		[SerializeField]
		private TMP_Text _timeText;

		[SerializeField]
		private Transform _timeSymbolSocket;

		private Dictionary<SlotOption, ScheduleTimeslotSegment3DUIView> _slotOptions;

		private ScheduleTimeSlot _timeslot;

		private List<Action> _deregisterActions;

		[SerializeField]
		private Material _spriteMaterial;

		private int _setForHour;

		private bool _isDirty;

		public IEnumerable<SlotOption> ActiveOptions => null;

		public void SetData(ScheduleDialog3DUIView dialog, ScheduleTimetable3DUIView scheduleTimetable, ScheduleTimeSlot timeSlot)
		{
		}

		protected override void OnDisable()
		{
		}

		private void DeregisterSegments()
		{
		}

		public override void CheckState()
		{
		}

		private void UpdateTime(int hour)
		{
		}

		public void UpdateLayout()
		{
		}

		public new void LateUpdate()
		{
		}

		private float CalculateChildSize()
		{
			return 0f;
		}

		public void SetMergedState(bool isMerged, bool isIconTextProvider, bool isEven, bool showBottomCap)
		{
		}
	}
}
