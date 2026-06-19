using UnityEngine;
using UnityEngine.UI;

public class ContractUnlockedBoxUI : MonoBehaviour
{
	public Image icon;

	public void Sync(ShiftOrderObject order)
	{
		icon.sprite = order.UIImage;
	}
}
