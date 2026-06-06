using UnityEngine;

public class WorldMapCompassPoint : MonoBehaviour
{
	[SerializeField]
	private Quaternion _rotation = Quaternion.identity;

	[SerializeField]
	private Transform _rotationContainer;

	private void LateUpdate()
	{
		base.transform.rotation = _rotation;
	}

	public void UpdatePosition(float compassRadius)
	{
		_rotationContainer.transform.localPosition = new Vector3(0f, 0f, compassRadius);
	}
}
