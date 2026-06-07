using UnityEngine;

public class checkIronDoors : MonoBehaviour
{
	public GameObject ironDoorL;

	public GameObject ironDoorR;

	public GameObject escapeTrigger;

	public bool spinnLockOK;

	public bool padlockOK;

	public bool chainsOK;

	public virtual void checkIrondoors()
	{
	}

	public virtual void IrondoorsIsOpen()
	{
	}
}
