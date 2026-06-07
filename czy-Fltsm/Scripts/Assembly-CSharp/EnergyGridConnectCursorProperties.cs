using System;
using System.Collections.Generic;
using FMODUnity;
using PajamaLlama.Generic;
using PajamaLlama.Math;
using UnityEngine;

[CreateAssetMenu(menuName = "Flotsam/Cursor Properties/Energy Connection")]
public class EnergyGridConnectCursorProperties : CursorProperties
{
	[SerializeField]
	private int _lowestPoint = 10;

	[Tooltip("Make sure both numbers are uneven so that the middle point is in the actual middle")]
	[SerializeField]
	[MinMaxRangeInt(1, 51)]
	private RangedInt _segmentSize = new RangedInt(11, 21);

	[SerializeField]
	private LineRenderer _lineRendererPrefab;

	[SerializeField]
	private Color _outOfRangeColor = Color.white;

	[SerializeField]
	private Color _inRangeColor = Color.white;

	[Header("FMOD Events")]
	[SerializeField]
	private EventReference _connectEvent;

	[NonSerialized]
	protected EnergyGridConnector _component;

	[NonSerialized]
	private uint _componentConnectIndex;

	[NonSerialized]
	private LineRenderer _lineRenderer;

	[NonSerialized]
	protected List<EnergyGridConnector> _componentsInRadius;

	[NonSerialized]
	private EnergyGridConnector _selectedComponent;

	[NonSerialized]
	private Camera _camera;

	[NonSerialized]
	private bool _connectWithIndex;

	public void Initialize(EnergyGridConnector component, uint index)
	{
		Initialize(component);
		_connectWithIndex = true;
		_componentConnectIndex = index;
	}

	public void Initialize(EnergyGridConnector component)
	{
		_component = component;
		_camera = CameraController.Instance.Camera;
		_componentsInRadius = new List<EnergyGridConnector>();
		if (_lineRenderer == null)
		{
			_lineRenderer = UnityEngine.Object.Instantiate(_lineRendererPrefab);
		}
		GameEventDispatcher.AddListener(GameEventType.EnergyGridsUpdated, OnEnergyGridsUpdated);
	}

	private void OnDisable()
	{
		GameEventDispatcher.RemoveListener(GameEventType.EnergyGridsUpdated, OnEnergyGridsUpdated);
	}

	public override void Activate()
	{
		if (!_lineRenderer.enabled)
		{
			UpdateLineRenderer(out var _);
			_lineRenderer.enabled = true;
		}
		DisableHighlights();
		UpdateComponentsInRange();
		HighlightComponentsInRange();
	}

	public override void UpdateCursor(CursorManager cursor)
	{
		UpdateLineRenderer(out var cableEndPos);
		if (IsHoverValid() && _component.IsInRange(cableEndPos))
		{
			_lineRenderer.material.SetColor("_BaseColor", _inRangeColor);
			if (GetInteract())
			{
				Connect(_selectedComponent, cursor);
			}
		}
		else
		{
			_lineRenderer.material.SetColor("_BaseColor", _outOfRangeColor);
		}
	}

	public override void DeactivateImmediately()
	{
		if (_lineRenderer != null)
		{
			_lineRenderer.enabled = false;
		}
		DisableHighlights();
		GameEventDispatcher.RemoveListener(GameEventType.EnergyGridsUpdated, OnEnergyGridsUpdated);
	}

	protected virtual void Connect(EnergyGridConnector other, CursorManager cursor)
	{
		if (!(other == null) && !(other == _component) && _componentsInRadius.Contains(other) && _component.CanConnect() && other.CanConnect() && !_component.IsConnected(other))
		{
			if (_connectWithIndex)
			{
				EnergyGrid.ConnectWithIndex(_component, _componentConnectIndex, other);
			}
			else
			{
				EnergyGrid.Connect(_component, other);
			}
			AudioManager.PlayOneShot(_connectEvent);
			DisableHighlights();
			if (other.CanConnect())
			{
				_component = other;
				Activate();
			}
			else
			{
				cursor.Deactivate();
			}
		}
	}

	private void OnEnergyGridsUpdated(GameEvent gameEvent)
	{
		DisableHighlights();
		UpdateComponentsInRange();
		HighlightComponentsInRange();
	}

	protected void DisableHighlights()
	{
		_component.OutlineRenderer.ResetHighlightOutline();
		foreach (EnergyGridConnector item in _componentsInRadius)
		{
			item.OutlineRenderer.ResetHighlightOutline();
		}
	}

	private void HighlightComponentsInRange()
	{
		foreach (EnergyGridConnector item in _componentsInRadius)
		{
			GameManager.HighlightManager.HighlightObject(item.OutlineRenderer);
		}
	}

	private void UpdateLineRenderer(out Vector3 cableEndPos)
	{
		Vector3 position = _component.ConnectionTransform.position;
		Vector3 mousePosition = FlotsamInputManager.MousePosition;
		float z = Vector3.Distance(_camera.transform.position, position);
		mousePosition.z = z;
		Vector3 targetPos = _camera.ScreenToWorldPoint(mousePosition);
		Vector3 endPos = ReturnTargetPosition(targetPos);
		UpdateLineSegments(position, endPos, out cableEndPos);
	}

	private void UpdateLineSegments(Vector3 startPos, Vector3 endPos, out Vector3 cableEndPos)
	{
		Vector3 vector = endPos - startPos;
		float f = startPos.y - Mathf.Max(0f, endPos.y);
		float cableLinkRange = GameManager.Settings.BuildableSettings.CableLinkRange;
		float num = Mathf.Min((endPos.Leveled() - startPos.Leveled()).magnitude, cableLinkRange);
		if (num >= cableLinkRange)
		{
			float num2 = Mathf.Sqrt(Mathf.Pow(f, 2f) + Mathf.Pow(cableLinkRange, 2f));
			vector = vector.normalized * num2;
		}
		cableEndPos = startPos + vector;
		float t = num / cableLinkRange;
		float num3 = Mathf.Lerp(_lowestPoint, 0f, t);
		Vector3 middlePoint = (startPos + cableEndPos) / 2f + Vector3.down * num3;
		int num4 = Mathf.Clamp(Mathf.RoundToInt(cableLinkRange - vector.magnitude), _segmentSize.Minimum, _segmentSize.Maximum);
		if (num4 % 2 == 0)
		{
			num4++;
		}
		_lineRenderer.positionCount = num4;
		Vector3[] array = new Vector3[num4];
		for (int i = 0; i < num4; i++)
		{
			float t2 = (float)i / (float)num4;
			array[i] = Bezier.CalculateQuadraticBezierPoint(t2, startPos, middlePoint, cableEndPos);
		}
		array[num4 - 1] = Bezier.CalculateQuadraticBezierPoint(1f, startPos, middlePoint, cableEndPos);
		_lineRenderer.SetPositions(array);
	}

	private void UpdateComponentsInRange()
	{
		_componentsInRadius.Clear();
		float cableLinkRange = GameManager.Settings.BuildableSettings.CableLinkRange;
		foreach (EnergyGrid grid in EnergyGridManager.Grids)
		{
			foreach (EnergyGridConnector link in grid.Links)
			{
				if (!(link == null) && !(link == _component) && Vector3.Distance(_component.ConnectionTransform.position.Leveled(), link.ConnectionTransform.position.Leveled()) < cableLinkRange && link.CanConnect() && !link.IsConnected(_component))
				{
					_componentsInRadius.Add(link);
				}
			}
		}
	}

	private Vector3 ReturnTargetPosition(Vector3 targetPos)
	{
		if (Physics.Raycast(_camera.ScreenPointToRay(FlotsamInputManager.MousePosition), out var hitInfo))
		{
			EnergyGridConnector componentInParent = hitInfo.transform.GetComponentInParent<EnergyGridConnector>();
			if (componentInParent != null && _componentsInRadius.Contains(componentInParent))
			{
				_selectedComponent = componentInParent;
				return componentInParent.ConnectionTransform.position;
			}
		}
		return targetPos;
	}

	private bool IsHoverValid()
	{
		if (Physics.Raycast(_camera.ScreenPointToRay(FlotsamInputManager.MousePosition), out var hitInfo))
		{
			EnergyGridConnector componentInParent = hitInfo.transform.GetComponentInParent<EnergyGridConnector>();
			if (componentInParent != null && _componentsInRadius.Contains(componentInParent))
			{
				_selectedComponent = componentInParent;
				return true;
			}
		}
		return false;
	}
}
