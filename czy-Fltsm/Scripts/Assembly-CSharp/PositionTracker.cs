using PajamaLlama.Math;
using UnityEngine;

public class PositionTracker : SceneBehaviour
{
	[SerializeField]
	private Transform _targetTransform;

	private void Update()
	{
		if (_targetTransform != null)
		{
			base.transform.position = _targetTransform.position.SetY(base.transform.position.y);
		}
	}
}
