using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CommandBaseButtonMgmt : MonoBehaviour
{
	public Button buildCommandBaseButton;

	public GameObject rematMessageBox;

	public TextMeshProUGUI rematTime;

	public Text unitsSelectedText;

	private int lastSelectedUnitsCount;

	public void LateUpdate()
	{
	}
}
