using UnityEngine;

public class CouplingHosePool : MonoBehaviour
{
	public interface IPoolItemComponent
	{
		void OnAboutToTakeFromPool();

		void OnAboutToReturnToPool();

		void OnTakenFromPool();

		void OnReturnedToPool();

		void SetLOD(CouplingHoseLODManager.LODLevel newLODLevel);
	}

	private const int ORDER_IN_HIERARCHY = 6;

	public int maxPooledItems = 50;

	private string prefabName;

	public static CouplingHosePool MakePool(string prefabName)
	{
		GameObject obj = new GameObject("[CouplingHosePool for '" + prefabName + "']");
		obj.SetActive(value: false);
		obj.transform.SetSiblingIndex(6);
		CouplingHosePool couplingHosePool = obj.AddComponent<CouplingHosePool>();
		couplingHosePool.prefabName = prefabName;
		return couplingHosePool;
	}

	public IPoolItemComponent GetFromPool(Transform reparentTo)
	{
		GameObject gameObject = ((base.transform.childCount <= 0) ? Object.Instantiate(Resources.Load(prefabName) as GameObject, base.transform) : base.transform.GetChild(0).gameObject);
		IPoolItemComponent component = gameObject.GetComponent<IPoolItemComponent>();
		_ = (MonoBehaviour)component;
		component.OnAboutToTakeFromPool();
		gameObject.transform.SetParent(reparentTo);
		component.OnTakenFromPool();
		return component;
	}

	public void ReturnToPool(IPoolItemComponent poolItem)
	{
		poolItem.OnAboutToReturnToPool();
		GameObject gameObject = ((MonoBehaviour)poolItem).gameObject;
		gameObject.transform.SetParent(base.transform);
		poolItem.OnReturnedToPool();
		if (base.transform.childCount >= maxPooledItems)
		{
			Object.Destroy(gameObject);
		}
	}
}
