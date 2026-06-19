using System;
using System.Collections.Generic;
using TH20.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace TH20
{
	[Serializable]
	[DontSave]
	public class PatientsMenu2 : AnimatedMenuBase
	{
		public class PatientRowProvider : ITableRowProvider
		{
			private GameObject _rowPrefab;

			private Level _level;

			private Patient _currentSelectedPatient;

			private Table _table;

			private List<Patient> _patients = new List<Patient>();

			private List<PatientsMenu2Row> _rowsPool = new List<PatientsMenu2Row>();

			private Dictionary<int, PatientsMenu2Row> _rowsInUse = new Dictionary<int, PatientsMenu2Row>();

			private List<Graphic> _cachedGraphicsList = new List<Graphic>(8);

			public int NumOfRows => _patients.Count;

			public PatientRowProvider(Level level, GameObject rowPrefab)
			{
				_level = level;
				_rowPrefab = rowPrefab;
				_patients.AddRange(_level.CharacterManager.Patients);
				CharacterEvents characterEvents = _level.CharacterEvents;
				characterEvents.OnPatientSpawned = (Action<Patient>)Delegate.Combine(characterEvents.OnPatientSpawned, new Action<Patient>(OnPatientSpawned));
				CharacterEvents characterEvents2 = _level.CharacterEvents;
				characterEvents2.OnPatientDestroyed = (Action<Patient>)Delegate.Combine(characterEvents2.OnPatientDestroyed, new Action<Patient>(OnPatientDestroyed));
			}

			public void AssignTable(Table table)
			{
				_table = table;
			}

			public void ReleaseRow(int i)
			{
				if (_rowsInUse.TryGetValue(i, out var value))
				{
					value.Setup(null);
					_rowsPool.Add(value);
					_rowsInUse.Remove(i);
					CanvasRenderer[] componentsInChildren = value.GetComponentsInChildren<CanvasRenderer>();
					for (int j = 0; j < componentsInChildren.Length; j++)
					{
						componentsInChildren[j].cull = true;
					}
				}
			}

			public RectTransform GetRow(int i)
			{
				if (_rowsInUse.TryGetValue(i, out var row))
				{
					return row.GetComponent<RectTransform>();
				}
				_table.SetDirty();
				if (_rowsPool.Count == 0)
				{
					row = UnityEngine.Object.Instantiate(_rowPrefab).GetComponent<PatientsMenu2Row>();
					row.transform.SetParent(_table.Rows.transform, worldPositionStays: false);
				}
				else
				{
					row = _rowsPool[_rowsPool.Count - 1];
					_rowsPool.RemoveAt(_rowsPool.Count - 1);
					CanvasRenderer[] componentsInChildren = row.GetComponentsInChildren<CanvasRenderer>();
					foreach (CanvasRenderer obj in componentsInChildren)
					{
						obj.cull = false;
						_cachedGraphicsList.Clear();
						obj.GetComponents(_cachedGraphicsList);
						for (int k = 0; k < _cachedGraphicsList.Count; k++)
						{
							_cachedGraphicsList[k].SetVerticesDirty();
						}
						_cachedGraphicsList.Clear();
					}
				}
				row.Button.onPrimaryDown.AddListener(delegate
				{
					foreach (PatientsMenu2Row value in _rowsInUse.Values)
					{
						value.ButtonAnimator.CurrentState = ButtonAnimator.State.Selectable;
					}
					row.ButtonAnimator.CurrentState = ButtonAnimator.State.Selected;
					_currentSelectedPatient = _patients[i];
				});
				row.Setup(_patients[i]);
				row.SetRowBackground(i);
				if (_currentSelectedPatient == _patients[i])
				{
					row.ButtonAnimator.CurrentState = ButtonAnimator.State.Selected;
				}
				else
				{
					row.ButtonAnimator.CurrentState = ButtonAnimator.State.Selectable;
				}
				_rowsInUse.Add(i, row);
				return row.GetComponent<RectTransform>();
			}

			public void SortColumn(int columnIndex, Table.SortDirection sortDirection)
			{
				int order = ((sortDirection == Table.SortDirection.Ascending) ? 1 : (-1));
				switch (columnIndex)
				{
				case 2:
					_patients.Sort(delegate(Patient a, Patient b)
					{
						float num = ((a.IsGoingForTreatment() || a.TreatmentOutcome != Treatment.Outcome.Unknown) ? 101f : a.DiagnosisCertainty);
						float value = ((b.IsGoingForTreatment() || b.TreatmentOutcome != Treatment.Outcome.Unknown) ? 101f : b.DiagnosisCertainty);
						int num2 = num.CompareTo(value);
						if (num2 == 0)
						{
							num2 = a.ID.CompareTo(b.ID);
						}
						return order * num2;
					});
					break;
				case 3:
					_patients.Sort(delegate(Patient a, Patient b)
					{
						float num = ((a.Happiness != null) ? a.Happiness.Value() : 0f);
						float value = ((b.Happiness != null) ? b.Happiness.Value() : 0f);
						int num2 = num.CompareTo(value);
						if (num2 == 0)
						{
							num2 = a.ID.CompareTo(b.ID);
						}
						return order * num2;
					});
					break;
				case 4:
					_patients.Sort(delegate(Patient a, Patient b)
					{
						int num = a.Health.Value().CompareTo(b.Health.Value());
						if (num == 0)
						{
							num = a.ID.CompareTo(b.ID);
						}
						return order * num;
					});
					break;
				}
				RefreshRowAssignment();
			}

			public void SetRowsToOrginalOrder()
			{
				_patients.Clear();
				_patients.AddRange(_level.CharacterManager.Patients);
				RefreshRowAssignment();
			}

			private void RefreshRowAssignment()
			{
				int[] array = new int[_rowsInUse.Count];
				_rowsInUse.Keys.CopyTo(array, 0);
				int[] array2 = array;
				foreach (int num in array2)
				{
					if (num >= NumOfRows)
					{
						ReleaseRow(num);
						continue;
					}
					_rowsInUse[num].Setup(_patients[num]);
					_rowsInUse[num].SetRowBackground(num);
					if (_patients[num] == _currentSelectedPatient)
					{
						_rowsInUse[num].ButtonAnimator.CurrentState = ButtonAnimator.State.Selected;
					}
					else
					{
						_rowsInUse[num].ButtonAnimator.CurrentState = ButtonAnimator.State.Selectable;
					}
				}
			}

			public void OnPatientSpawned(Patient patient)
			{
				_patients.Add(patient);
				_table.SetDirty();
			}

			private void OnPatientDestroyed(Patient patient)
			{
				_patients.Remove(patient);
				_table.SetDirty();
				if (_currentSelectedPatient == patient)
				{
					_currentSelectedPatient = null;
				}
				RefreshRowAssignment();
			}

			public void Destroy()
			{
				CharacterEvents characterEvents = _level.CharacterEvents;
				characterEvents.OnPatientSpawned = (Action<Patient>)Delegate.Remove(characterEvents.OnPatientSpawned, new Action<Patient>(OnPatientSpawned));
				CharacterEvents characterEvents2 = _level.CharacterEvents;
				characterEvents2.OnPatientDestroyed = (Action<Patient>)Delegate.Remove(characterEvents2.OnPatientDestroyed, new Action<Patient>(OnPatientDestroyed));
			}
		}

		[Serializable]
		public class PatientsMenu2Settings
		{
			[Header("General")]
			[SerializeField]
			public GameObject RowPrefab;

			[SerializeField]
			public RectTransform ColumnHeadersParent;

			[SerializeField]
			public Table DataTable;

			[SerializeField]
			public bool ShowViewFinder;

			[SerializeField]
			public Vector2 PanelSizeDelta;

			[SerializeField]
			public TMP_Text PatientCountLabel;

			[NonSerialized]
			[HideInInspector]
			public int AnimHash;

			[NonSerialized]
			[HideInInspector]
			public int TriggerHash;

			[SerializeField]
			public float ViewFinderBorder;

			[SerializeField]
			public DynamicButton CloseButton;

			[SerializeField]
			public RectTransform BarRectTransform;

			[SerializeField]
			public RectTransform PanelRectTransform;

			[SerializeField]
			public RectTransform TabSelectionRectTransform;

			[SerializeField]
			public RectTransform TitleRectTransform;

			[SerializeField]
			public RectTransform ViewFinderRectTransform;
		}

		[SerializeField]
		private PatientsMenu2Data _data;

		[SerializeField]
		private GraphicRaycaster _graphicRaycaster;

		private PatientsMenu2Settings _patientsMenu2Settings;

		private bool _showViewFinder;

		private bool _bShowingViewFinder;

		private Level _level;

		private Patient _inspectedPatient;

		private Table _table;

		private Dictionary<Patient, PatientsMenu2Row> _rows = new Dictionary<Patient, PatientsMenu2Row>();

		public void Initialise(Level level)
		{
			_level = level;
			_level.InputManager.AddGraphicRayCaster(_graphicRaycaster);
			_patientsMenu2Settings = _data.PatientsMenu2Settings;
			HUDEvents hUDEvents = _level.HUDEvents;
			hUDEvents.OnInspectorOpen = (Action<InspectorMenu, Character>)Delegate.Combine(hUDEvents.OnInspectorOpen, new Action<InspectorMenu, Character>(OnInspectorOpen));
			HUDEvents hUDEvents2 = _level.HUDEvents;
			hUDEvents2.OnInspectorClose = (Action)Delegate.Combine(hUDEvents2.OnInspectorClose, new Action(OnInspectorClose));
			CameraEvents cameraEvents = _level.CameraEvents;
			cameraEvents.OnCameraPan = (Action<float>)Delegate.Combine(cameraEvents.OnCameraPan, new Action<float>(OnCameraPan));
			PanelItem[] componentsInChildren = GetComponentsInChildren<PanelItem>(includeInactive: true);
			for (int i = 0; i < componentsInChildren.Length; i++)
			{
				componentsInChildren[i].Setup();
			}
			if ((bool)_patientsMenu2Settings.CloseButton)
			{
				_patientsMenu2Settings.CloseButton.onPrimaryDown.AddListener(CloseMenu);
			}
			if ((bool)_patientsMenu2Settings.ColumnHeadersParent)
			{
				_patientsMenu2Settings.ColumnHeadersParent.gameObject.SetActive(value: false);
			}
			_table = _patientsMenu2Settings.DataTable;
			if ((bool)_table)
			{
				_table.gameObject.SetActive(value: true);
				_table.ColumnHeaders = _patientsMenu2Settings.ColumnHeadersParent;
				if ((bool)_table.ColumnHeaders)
				{
					_table.ColumnHeaders.gameObject.SetActive(value: true);
				}
			}
			_table.RowProvider = new PatientRowProvider(_level, _patientsMenu2Settings.RowPrefab);
		}

		public void Setup()
		{
			_showViewFinder = _patientsMenu2Settings.ShowViewFinder;
			ShowViewFinder(state: false);
			if (_inspectedPatient != null)
			{
				ShowViewFinder(state: true);
			}
		}

		protected void UpdateRowBackgrounds()
		{
			int num = 0;
			foreach (KeyValuePair<Patient, PatientsMenu2Row> row in _rows)
			{
				row.Value.SetRowBackground(num++);
			}
		}

		public override void Destroy()
		{
			_level.InputManager.RemoveGraphicRayCaster(_graphicRaycaster);
			HUDEvents hUDEvents = _level.HUDEvents;
			hUDEvents.OnInspectorOpen = (Action<InspectorMenu, Character>)Delegate.Remove(hUDEvents.OnInspectorOpen, new Action<InspectorMenu, Character>(OnInspectorOpen));
			HUDEvents hUDEvents2 = _level.HUDEvents;
			hUDEvents2.OnInspectorClose = (Action)Delegate.Remove(hUDEvents2.OnInspectorClose, new Action(OnInspectorClose));
			CameraEvents cameraEvents = _level.CameraEvents;
			cameraEvents.OnCameraPan = (Action<float>)Delegate.Remove(cameraEvents.OnCameraPan, new Action<float>(OnCameraPan));
			((PatientRowProvider)_table.RowProvider).Destroy();
			if (_patientsMenu2Settings != null && _patientsMenu2Settings.CloseButton != null)
			{
				_patientsMenu2Settings.CloseButton.onPrimaryDown.RemoveListener(CloseMenu);
			}
		}

		public override void CloseMenu()
		{
			_level.CameraLogic.SetTrackedObjectFrame(null);
			_inspectedPatient = null;
			ShowViewFinder(state: false);
			base.CloseMenu();
		}

		protected override void Update()
		{
			base.Update();
			_patientsMenu2Settings.PatientCountLabel.text = string.Format(LocalisedString.GetTranslationPlural("Menu/Patients/PatientCount_CS", _level.CharacterManager.Patients.Count), _level.CharacterManager.Patients.Count);
		}

		private void ShowViewFinder(bool state)
		{
			_bShowingViewFinder = false;
			if ((bool)_patientsMenu2Settings.ViewFinderRectTransform)
			{
				bool flag = state & _showViewFinder;
				if (flag)
				{
					_bShowingViewFinder = true;
					Vector2 sizeDelta = _patientsMenu2Settings.PanelRectTransform.sizeDelta;
					float y = sizeDelta.y;
					float x = _patientsMenu2Settings.ViewFinderRectTransform.anchoredPosition.x - _patientsMenu2Settings.PanelRectTransform.anchoredPosition.x - sizeDelta.x - _patientsMenu2Settings.ViewFinderBorder;
					_patientsMenu2Settings.ViewFinderRectTransform.sizeDelta = new Vector2(x, y);
					_level.CameraLogic.SetTrackedObjectFrame(_patientsMenu2Settings.ViewFinderRectTransform.GetScreenSpaceRect());
				}
				else
				{
					_level.CameraLogic.SetTrackedObjectFrame(null);
				}
				_patientsMenu2Settings.ViewFinderRectTransform.gameObject.SetActive(flag);
			}
		}

		private void OnInspectorOpen(InspectorMenu menuRef, Character character)
		{
			if (character is Patient && !IsClosed() && !IsClosing())
			{
				_inspectedPatient = (Patient)character;
				ShowViewFinder(state: true);
			}
		}

		private void OnInspectorClose()
		{
			StopViewFinderTracking();
		}

		private void OnCameraPan(float distance)
		{
			StopViewFinderTracking();
		}

		private void StopViewFinderTracking()
		{
			if (_bShowingViewFinder && !IsClosed() && !IsClosing())
			{
				_level.CameraLogic.TrackObject(null);
				_level.CameraLogic.SetFocalPoint(_level.CameraLogic.GetTargetFocalPoint(), snap: true);
				_inspectedPatient = null;
				ShowViewFinder(state: false);
			}
		}
	}
}
