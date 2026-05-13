using UnityEngine;

public class PlayerManager : MonoBehaviour
{
	public static PlayerManager instance;

	[SerializeField]
	private PlayerMovement movement;

	[SerializeField]
	private PlayerInteract interact;

	[SerializeField]
	private Transform cam;

	private Item currentItem;

	[SerializeField]
	private Transform arrPos;

	[SerializeField]
	private Transform arrEye;

	[SerializeField]
	private Transform arrLookDir;

	public void ArrangePlayer()
	{
		Quaternion quaternion = Quaternion.LookRotation(arrLookDir.position - arrEye.position);
		movement.UpdatePosAndAngle(arrPos.position, quaternion.eulerAngles);
	}

	private void Awake()
	{
		instance = this;
	}

	public void LockAll()
	{
		movement.LockCam = true;
		movement.LockMovement = true;
		interact.Interactable = false;
	}

	public void LockMovement()
	{
		movement.LockCam = false;
		movement.LockMovement = true;
	}

	public void LockInteract()
	{
		interact.Interactable = false;
	}

	public void UnlockAll()
	{
		movement.LockCam = false;
		movement.LockMovement = false;
		interact.Interactable = true;
	}

	public void AddItem(string name)
	{
		if (currentItem != null)
		{
			Object.Destroy(currentItem.gameObject);
		}
		GameObject gameObject = Object.Instantiate(Resources.Load<GameObject>("Prefabs/" + name));
		gameObject.transform.SetParent(cam);
		gameObject.transform.localPosition = Vector3.zero;
		gameObject.transform.localRotation = Quaternion.Euler(Vector3.zero);
		currentItem = gameObject.GetComponent<Item>();
	}

	public void RemoveItem()
	{
		if (currentItem != null)
		{
			Object.Destroy(currentItem.gameObject);
		}
	}

	public bool CheckItem(string itemName)
	{
		if (currentItem != null)
		{
			return currentItem.itemName == itemName;
		}
		return false;
	}

	public Item GetItem()
	{
		return currentItem;
	}

	public void InteractDistance(float dis)
	{
		interact.distance = dis;
	}

	public void SetMovementSpeed(float speed, float sen)
	{
		movement.SetSpeed(speed, sen);
	}

	public void SetMouseSen(float sen)
	{
		movement.SetMouseSen(sen);
	}
}
