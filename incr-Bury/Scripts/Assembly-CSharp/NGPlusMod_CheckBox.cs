using UnityEngine;

public class NGPlusMod_CheckBox : MonoBehaviour
{
	public bool isChecked;

	public NgPlusModType modType;

	[SerializeField]
	private GameObject checkMark;

	public void ToggleChecked()
	{
		isChecked = !isChecked;
		checkMark.SetActive(isChecked);
	}

	public void UncheckBox()
	{
		isChecked = false;
		checkMark.SetActive(value: false);
	}

	public void CheckBox()
	{
		isChecked = true;
		checkMark.SetActive(value: true);
	}
}
