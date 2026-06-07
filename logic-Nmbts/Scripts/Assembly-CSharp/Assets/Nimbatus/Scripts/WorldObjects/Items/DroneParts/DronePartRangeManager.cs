using System.Collections;
using System.Collections.Generic;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.Workshop;
using Assets.Nimbatus.Scripts.WorldObjects.Items.Dragging;
using UnityEngine;
using Vectrosity;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts
{
	public class DronePartRangeManager : MonoBehaviour
	{
		public Material LineMaterial;

		public Material RadiusLineMaterial;

		public Color InRangeColor;

		public Color OutofRangeColor;

		private VectorLine _selectionVectorLine;

		private static DronePart _selectedItem;

		private static DronePartRangeManager _instance;

		private const int NumberOfLineSegments = 50;

		public static DronePartRangeManager Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = Object.FindObjectOfType<DronePartRangeManager>();
				}
				return _instance;
			}
			set
			{
				_instance = value;
			}
		}

		public static DronePart SelectedItem
		{
			get
			{
				return _selectedItem;
			}
			set
			{
				if (_selectedItem != value)
				{
					_selectedItem = value;
					Instance.UpdateLine();
				}
			}
		}

		public void Awake()
		{
			_instance = this;
		}

		public void Start()
		{
			Vector3[] linePoints = new Vector3[51];
			_selectionVectorLine = new VectorLine("Line", linePoints, LineMaterial, 6f, LineType.Continuous);
			StartCoroutine(CheckDroneOverlapping());
		}

		private IEnumerator CheckDroneOverlapping()
		{
			WaitForFixedUpdate waitForFixedUpdate = new WaitForFixedUpdate();
			while (true)
			{
				if (SerializableMonobehaviour<UiPreferences, UiPreferencesData>.Instance.OverlapDetectionEnabled && DronePartManager.Instance.ActiveNumberOfDroneParts <= 100)
				{
					List<DronePart> parts = DronePartManager.Instance.ActiveDrone.RootDronePart.GetAllChildParts<DronePart>();
					for (int i = 0; i < parts.Count; i++)
					{
						DronePart dronePart = parts[i];
						if (dronePart != null)
						{
							dronePart.CheckOverlap();
						}
						if (i % 10 == 0)
						{
							yield return new WaitForFixedUpdate();
						}
					}
				}
				else
				{
					List<DronePart> parts = DronePartManager.Instance.ActiveDrone.RootDronePart.GetAllChildParts<DronePart>();
					for (int i = 0; i < parts.Count; i++)
					{
						parts[i].HideOverlapDisplay();
						if (i % 10 == 0)
						{
							yield return new WaitForFixedUpdate();
						}
					}
				}
				yield return waitForFixedUpdate;
			}
		}

		public void Update()
		{
			if (SelectedItem != null && DragAndDropHelper.DraggedItem != null)
			{
				bool flag = Vector2.Distance(SelectedItem.transform.position, DragAndDropHelper.DraggedItem.transform.position) <= SelectedItem.MaxChildRange + 2E-05f;
				_selectionVectorLine.material.color = (flag ? InRangeColor : OutofRangeColor);
			}
		}

		private void UpdateLine()
		{
			if (_selectedItem != null)
			{
				float maxChildRange = _selectedItem.MaxChildRange;
				_selectionVectorLine.active = true;
				_selectionVectorLine.material.color = InRangeColor;
				_selectionVectorLine.MakeEllipse(_selectedItem.transform.position + new Vector3(0f, 0f, -50f), maxChildRange, maxChildRange, 50, 0);
				_selectionVectorLine.Draw3D();
			}
			else
			{
				_selectionVectorLine.active = false;
			}
		}

		public void OnDisable()
		{
			SelectedItem = null;
			_instance = null;
		}
	}
}
