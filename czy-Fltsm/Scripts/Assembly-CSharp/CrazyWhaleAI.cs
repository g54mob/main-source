using System.Collections.Generic;
using UnityEngine;

public class CrazyWhaleAI : MonoBehaviour
{
	[SerializeField]
	[Tooltip("Speed of the whale.")]
	private float _whaleSpeed = 2f;

	[SerializeField]
	[Tooltip("Waypoints to guide the whale.")]
	private List<Transform> _waypoints = new List<Transform>();

	private int _targetWaypoint;

	private void Start()
	{
		base.transform.position = _waypoints[_targetWaypoint].position;
	}

	private void Update()
	{
		if (Vector3.Distance(base.transform.position, _waypoints[_targetWaypoint].position) < 5f)
		{
			_targetWaypoint++;
			if (_targetWaypoint >= _waypoints.Count)
			{
				_targetWaypoint = 0;
			}
		}
		Quaternion to = Quaternion.LookRotation(_waypoints[_targetWaypoint].position - base.transform.position);
		to = Quaternion.RotateTowards(base.transform.rotation, to, Time.deltaTime * 5f);
		base.transform.rotation = to;
		base.transform.Translate(Vector3.forward * Time.deltaTime * _whaleSpeed);
	}

	private void OnDrawGizmos()
	{
		for (int i = 0; i < _waypoints.Count; i++)
		{
			Gizmos.color = Color.magenta;
			int index = (int)Mathf.Repeat(i + 1, _waypoints.Count);
			Gizmos.DrawLine(_waypoints[i].position, _waypoints[index].position);
			Gizmos.DrawWireSphere(_waypoints[i].position, 5f);
		}
	}
}
