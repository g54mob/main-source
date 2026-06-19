using System;
using System.Collections.Generic;
using I2.Loc;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	[UsedImplicitly(ImplicitUseKindFlags.Assign | ImplicitUseKindFlags.InstantiatedNoFixedConstructorSignature, ImplicitUseTargetFlags.Members)]
	public class InspectorSubItemCharacterLog : InspectorSubItem
	{
		[SerializeField]
		private ScrollRect _scroller;

		[SerializeField]
		private GameObject _rowPrefab;

		[SerializeField]
		private Color _rowBackingColor1;

		[SerializeField]
		private Color _rowBackingColor2;

		[SerializeField]
		private Color _dateTextColor;

		private Character _character;

		private bool _eventsChanged;

		private List<HospitalEvent> _hospitalEvents;

		private List<HospitalEvent> _newHospitalEvents;

		private readonly List<InspectorCharacterLogRow> _rows = new List<InspectorCharacterLogRow>();

		public void Setup(Character character)
		{
			_character = character;
			_hospitalEvents = new List<HospitalEvent>();
			_newHospitalEvents = new List<HospitalEvent>();
			_scroller.normalizedPosition = new Vector2(0f, 0f);
			if (_character != null)
			{
				HospitalEventLog hospitalEventLog = _character.Level.HospitalEventLog;
				hospitalEventLog.OnEventAdded = (Action)Delegate.Remove(hospitalEventLog.OnEventAdded, new Action(RefreshList));
				HospitalEventLog hospitalEventLog2 = _character.Level.HospitalEventLog;
				hospitalEventLog2.OnEventAdded = (Action)Delegate.Combine(hospitalEventLog2.OnEventAdded, new Action(RefreshList));
			}
			LocalizationManager.OnLocalizeEvent += OnLocalize;
			RefreshList();
		}

		private void OnDestroy()
		{
			HospitalEventLog hospitalEventLog = _character.Level.HospitalEventLog;
			hospitalEventLog.OnEventAdded = (Action)Delegate.Remove(hospitalEventLog.OnEventAdded, new Action(RefreshList));
			LocalizationManager.OnLocalizeEvent -= OnLocalize;
		}

		private void RefreshList()
		{
			if (_character == null)
			{
				return;
			}
			_newHospitalEvents.Clear();
			Staff staff = _character as Staff;
			if (staff != null)
			{
				_character.Level.HospitalEventLog.GetEvents(ref _newHospitalEvents, (HospitalEvent he) => he is IHospitalEventStaff hospitalEventStaff && hospitalEventStaff.GetStaffName() == staff.CharacterName);
			}
			Patient patient = _character as Patient;
			if (patient != null)
			{
				_character.Level.HospitalEventLog.GetEvents(ref _newHospitalEvents, (HospitalEvent he) => he is IHospitalEventPatient hospitalEventPatient && hospitalEventPatient.GetPatientName() == patient.CharacterName);
			}
			for (int num = _hospitalEvents.Count - 1; num >= 0; num--)
			{
				HospitalEvent item = _hospitalEvents[num];
				if (!_newHospitalEvents.Contains(item))
				{
					_eventsChanged = true;
					_hospitalEvents.RemoveAt(num);
				}
			}
			foreach (HospitalEvent newHospitalEvent in _newHospitalEvents)
			{
				if (!_hospitalEvents.Contains(newHospitalEvent))
				{
					_eventsChanged = true;
					_hospitalEvents.Add(newHospitalEvent);
				}
			}
			_hospitalEvents.Sort((HospitalEvent event1, HospitalEvent event2) => event2.Date.CompareTo(event1.Date));
		}

		private void Update()
		{
			if (_character != null && _eventsChanged)
			{
				int count = _hospitalEvents.Count;
				for (int i = count; i < _rows.Count; i++)
				{
					GameObjectUtils.SetActive(_rows[i].gameObject, isActive: false);
				}
				while (count > _rows.Count)
				{
					InspectorCharacterLogRow component = UnityEngine.Object.Instantiate(_rowPrefab, _scroller.content).GetComponent<InspectorCharacterLogRow>();
					_rows.Add(component);
				}
				for (int j = 0; j < count; j++)
				{
					GameObjectUtils.SetActive(_rows[j].gameObject, isActive: true);
					_rows[j].Setup(_hospitalEvents[j], ((j & 1) == 0) ? _rowBackingColor1 : _rowBackingColor2, _dateTextColor);
				}
				_eventsChanged = false;
			}
		}

		private void OnLocalize()
		{
			_hospitalEvents.Clear();
			RefreshList();
		}
	}
}
