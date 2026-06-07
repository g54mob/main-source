using UnityEngine;

public class ObjectPool : MonoBehaviour
{
	[SerializeField]
	private ObjectPoolObj _prefab;

	[SerializeField]
	private int _count = 10;

	protected void Awake()
	{
		CreateObjs();
	}

	private void CreateObjs()
	{
		for (int i = 0; i < _count; i++)
		{
			ObjectPoolObj objectPoolObj = Object.Instantiate(_prefab, base.transform);
			objectPoolObj.Init(base.transform);
			objectPoolObj.gameObject.SetActive(value: false);
		}
	}

	public GameObject GetObj()
	{
		if (base.transform.childCount <= 0)
		{
			CreateObjs();
		}
		int num = 0;
		GameObject gameObject = base.transform.GetChild(num).gameObject;
		while (gameObject.activeInHierarchy)
		{
			num++;
			if (num >= base.transform.childCount)
			{
				CreateObjs();
			}
			gameObject = base.transform.GetChild(num).gameObject;
		}
		gameObject.GetComponent<ObjectPoolObj>().Spawn();
		return gameObject;
	}
}
