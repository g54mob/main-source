using UnityEngine;

public class MoneyPrinter : MonoBehaviour
{
	[SerializeField]
	protected Transform spawnMoneyAnchor;

	protected virtual void Awake()
	{
		if (spawnMoneyAnchor == null)
		{
			Debug.LogError("spawnMoneyAnchor not set! Using this.transform");
			spawnMoneyAnchor = base.transform;
		}
	}

	public virtual GameObject PrintMoney(double cashAmount)
	{
		GameObject obj = (GameObject)Object.Instantiate(Resources.Load("Banknotes", typeof(GameObject)), spawnMoneyAnchor.position, spawnMoneyAnchor.rotation, WorldMover.OriginShiftParent);
		obj.GetComponent<IMoney>().Amount = cashAmount;
		return obj;
	}
}
