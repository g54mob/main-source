using TMPro;
using UnityEngine;

public class ModuleIcon : MonoBehaviour
{
	[SerializeField]
	private RectTransform _shape;

	[SerializeField]
	private TextMeshProUGUI _amtText;

	public void SetShape(GameObject go)
	{
		go.transform.SetParent(_shape, worldPositionStays: false);
		go.transform.localPosition = Vector3.zero;
		go.transform.localScale = Vector3.one;
		_amtText.SetText("1");
	}

	public void SetAmt(int amt)
	{
		_amtText.SetText(amt.ToString());
	}
}
