using System.Collections.Generic;
using UnityEngine;

public class RandomModelEnabler : MonoBehaviour
{
	[SerializeField]
	private List<GameObject> _models = new List<GameObject>();

	[SerializeField]
	private bool _randomYRotation;

	private void Awake()
	{
		int index = Random.Range(0, _models.Count);
		_models[index].SetActive(value: true);
		if (_randomYRotation)
		{
			_models[index].transform.rotation = Quaternion.Euler(0f, (float)Random.Range(0, 4) * 90f, 0f);
		}
	}
}
