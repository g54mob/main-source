using UnityEngine;

public class Spot : MonoBehaviour
{
	[SerializeField]
	private GameObject _inCircleGO;

	private AnimalPrefab _currentAnimalPrefab;

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.layer == LayerMask.NameToLayer("Animal") && !(_currentAnimalPrefab != null))
		{
			AnimalPrefab component = other.GetComponent<AnimalPrefab>();
			component.SetIsInCamp(isInCamp: true);
			_currentAnimalPrefab = component;
			_inCircleGO.SetActive(value: true);
		}
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.gameObject.layer == LayerMask.NameToLayer("Animal") && !(_currentAnimalPrefab == null) && _currentAnimalPrefab.Animal.AnimalData.ID == other.GetComponent<AnimalPrefab>().Animal.AnimalData.ID)
		{
			other.GetComponent<AnimalPrefab>().SetIsInCamp(isInCamp: false);
			_currentAnimalPrefab = null;
			_inCircleGO.SetActive(value: false);
		}
	}

	public AnimalPrefab GetCurrentAnimalPrefab()
	{
		return _currentAnimalPrefab;
	}
}
