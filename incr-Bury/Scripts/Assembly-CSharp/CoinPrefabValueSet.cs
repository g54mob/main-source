using UnityEngine;

public class CoinPrefabValueSet : MonoBehaviour
{
	public GameObject coinPrefab;

	public int coinValue;

	public CoinPrefabValueSet(GameObject _prefab, int _value)
	{
		coinPrefab = _prefab;
		coinValue = _value;
	}
}
