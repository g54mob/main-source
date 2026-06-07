using PajamaLlama.Debugs;
using UnityEngine;

[AddComponentMenu("Flotsam/Visuals/Rope Helper")]
public class RopeHelper : MonoBehaviour
{
	private enum Pivot
	{
		Center = 0,
		RopeEnd = 1
	}

	[Tooltip("First point to orientate rope with.")]
	[SerializeField]
	private Transform _firstPoint;

	[Tooltip("Second point to orientate rope with.")]
	[SerializeField]
	private Transform _secondPoint;

	[Tooltip("Pivot setting for this rope object.")]
	[SerializeField]
	private Pivot _pivot;

	[Tooltip("Length in units of this rope.")]
	[SerializeField]
	private float _ropeLength = 2f;

	[Tooltip("When enabled the rope orientation is constantly updated.")]
	public bool UpdateRope = true;

	private void Start()
	{
	}

	private void Update()
	{
		if (UpdateRope)
		{
			if (_firstPoint == null)
			{
				Debugger.Warning("No transform set for the first point for this helper.", this);
			}
			else if (_secondPoint == null)
			{
				Debugger.Warning("No transform set for the second point for this helper.", this);
			}
			else
			{
				AlignRope();
			}
		}
	}

	private void AlignRope()
	{
		Vector3 position = ((_pivot == Pivot.Center) ? ((_firstPoint.position + _secondPoint.position) / 2f) : _firstPoint.position);
		base.transform.position = position;
		base.transform.localScale = new Vector3(1f, 1f, Vector3.Distance(_firstPoint.position, _secondPoint.position) / _ropeLength);
		base.transform.rotation = Quaternion.LookRotation(_secondPoint.position - _firstPoint.position);
	}
}
