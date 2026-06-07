using UnityEngine;
using UnityEngine.UI;

public class SlotMachine_Manager : MonoBehaviour
{
	public static SlotMachine_Manager Singleton;

	[SerializeField]
	private Image SlotImage_1;

	[SerializeField]
	private Image SlotImage_2;

	[SerializeField]
	private Image SlotImage_3;

	private void Awake()
	{
		if ((bool)Singleton)
		{
			Object.Destroy(base.gameObject);
		}
		else
		{
			Singleton = this;
		}
	}

	private void Start()
	{
	}

	private void Update()
	{
	}

	public void AttemptUse()
	{
	}

	public void UseSlotMachine()
	{
	}

	public void UpdateSlotImage(int _slotNum, Sprite _sprite)
	{
		switch (_slotNum)
		{
		case 1:
			SlotImage_1.sprite = _sprite;
			break;
		case 2:
			SlotImage_2.sprite = _sprite;
			break;
		case 3:
			SlotImage_3.sprite = _sprite;
			break;
		}
	}
}
