using PajamaLlama.Math;
using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class EnergyGridConnection : MonoBehaviour
{
	[SerializeField]
	private MeshFilter _meshFilter;

	private EnergyGridConnector _parent;

	private EnergyGridConnector _other;

	private float _generatedLength;

	public void Initialize(EnergyGridConnector parent, EnergyGridConnector other)
	{
		_parent = parent;
		_other = other;
		base.transform.localPosition = Vector3.zero;
		_generatedLength = (_parent.ConnectionTransform.position - _other.ConnectionTransform.position).magnitude;
		_meshFilter.mesh = EnergyGridConnectionVisualizer.GenerateCable(_generatedLength);
	}

	private void Update()
	{
		base.transform.position = Vector3.Lerp(_parent.ConnectionTransform.position, _other.ConnectionTransform.position, 0.5f);
		base.transform.rotation = FlotsamGame.PointsToRotation(_parent.ConnectionTransform.position, _other.ConnectionTransform.position, level: false);
		float magnitude = (_parent.ConnectionTransform.position - _other.ConnectionTransform.position).magnitude;
		_meshFilter.transform.localScale = _meshFilter.transform.localScale.SetZ(magnitude / _generatedLength);
	}

	public bool HasConnection(EnergyGridConnector a, EnergyGridConnector b)
	{
		if (_parent == a && _other == b)
		{
			return true;
		}
		if (_other == a && _parent == b)
		{
			return true;
		}
		return false;
	}
}
