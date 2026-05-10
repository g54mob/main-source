using UnityEngine;

public class DoorVisualSelector : MonoBehaviour
{
	[SerializeField]
	private GameObject _interior;

	[SerializeField]
	private GameObject _exterior;

	public Transform CurrentDoor
	{
		get
		{
			if (!_interior.activeSelf)
			{
				return _exterior.transform;
			}
			return _interior.transform;
		}
	}

	public void ShowInterior()
	{
		_interior.SetActive(value: true);
		_exterior.SetActive(value: false);
	}

	public void ShowExterior()
	{
		_interior.SetActive(value: false);
		_exterior.SetActive(value: true);
	}
}
