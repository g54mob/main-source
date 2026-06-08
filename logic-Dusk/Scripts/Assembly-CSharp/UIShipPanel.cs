using UnityEngine;
using UnityEngine.UI;

public class UIShipPanel : MonoBehaviour
{
	public Text shipNameLabel;

	public UICommendeerSlotList slotList;

	public UIShipHold shipHold;

	public RawImage shipImage;

	public void Initialze()
	{
		slotList.Clear();
	}
}
