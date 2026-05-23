using System.Collections.Generic;
using Data.FactoryFloor;
using Data.Operator;
using Data.Variables;
using UnityEngine;

namespace Presentation.FactoryFloor.FactoryObjectViews.Arrows
{
	public class FactoryObjectInputOutputArrows : MonoBehaviour
	{
		[SerializeField]
		private FactoryLayer _factoryLayer;

		[SerializeField]
		private FactoryObjectView _objectView;

		[SerializeField]
		private FactoryObjectData _objectData;

		[SerializeField]
		private InputOutputArrow _inputArrowPrefab;

		[SerializeField]
		private InputOutputArrow _outputArrowPrefab;

		[SerializeField]
		private Vector3 _offset = new Vector3(0f, -0.15f, 0f);

		[SerializeField]
		private List<InputOutputArrow> _arrows = new List<InputOutputArrow>();

		[SerializeField]
		private bool _autoUpdateArrows = true;

		[SerializeField]
		private BoolVariableSO _uiVisibility;

		public FactoryObjectData ObjectData => _objectData;

		private void Awake()
		{
			if (Application.isPlaying)
			{
				HideAll();
				_objectView.ObjectSelected += OnObjectSelected;
				_objectView.ObjectDeSelected += HideAll;
				if (_uiVisibility != null)
				{
					_uiVisibility.ValueChanged += HandleUIVisibilityChanged;
				}
			}
		}

		private void OnDestroy()
		{
			if (Application.isPlaying)
			{
				_objectView.ObjectSelected -= OnObjectSelected;
				_objectView.ObjectDeSelected -= HideAll;
				if (_uiVisibility != null)
				{
					_uiVisibility.ValueChanged -= HandleUIVisibilityChanged;
				}
			}
		}

		private void HandleUIVisibilityChanged(bool isVisible)
		{
			if (!isVisible)
			{
				HideAll();
			}
		}

		private void OnObjectSelected()
		{
			ShowAll();
		}

		public void ShowAll()
		{
			if (_uiVisibility != null && !_uiVisibility.Value)
			{
				return;
			}
			foreach (InputOutputArrow arrow in _arrows)
			{
				arrow.gameObject.SetActive(value: true);
			}
		}

		public void HideAll()
		{
			foreach (InputOutputArrow arrow in _arrows)
			{
				arrow.gameObject.SetActive(value: false);
			}
		}

		public void ShowEmptyInputs()
		{
			if (_objectView.FactoryObject == null)
			{
				return;
			}
			List<Vector3Int> list = new List<Vector3Int>();
			foreach (FactoryObjectData.InputData dataInputPosition in _objectView.FactoryObject.DataInputPositions)
			{
				if (_factoryLayer.TryGetObjectAt(_objectView.FactoryObject.DataPosToWorldPos(dataInputPosition.Position - dataInputPosition.Direction), out var _))
				{
					list.Add(dataInputPosition.Position);
				}
			}
			foreach (InputOutputArrow arrow in _arrows)
			{
				if (arrow.ArrowType == InputOutputArrow.EArrowType.Input && !list.Contains(arrow.RelativePosition))
				{
					arrow.gameObject.SetActive(value: true);
				}
			}
		}

		public void ShowEmptyOutputs()
		{
			if (_objectView.FactoryObject == null)
			{
				return;
			}
			List<Vector3Int> list = new List<Vector3Int>();
			FactoryObject.OutputFactoryObject[] outputFactoryObjects = _objectView.FactoryObject.OutputFactoryObjects;
			foreach (FactoryObject.OutputFactoryObject outputFactoryObject in outputFactoryObjects)
			{
				if (outputFactoryObject != null)
				{
					list.Add(outputFactoryObject.OutputData.Position);
				}
			}
			foreach (InputOutputArrow arrow in _arrows)
			{
				if (arrow.ArrowType == InputOutputArrow.EArrowType.Output && !list.Contains(arrow.RelativePosition))
				{
					arrow.gameObject.SetActive(value: true);
				}
			}
		}

		private void ValidPositionChanged(bool valid)
		{
			if (valid)
			{
				ShowAll();
			}
			else
			{
				HideAll();
			}
		}
	}
}
