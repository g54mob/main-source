using UnityEngine;
using UnityEngine.UI;

public class EEPROMDataRow : MonoBehaviour
{
	[Header("Components")]
	public Text addressText;

	public InputField[] dataFields;

	private byte[] _data;

	private ICMobileTool _tool;

	public int _adr;

	private void Awake()
	{
	}

	public void SetRow(byte[] data, int startAdr, int length, ICMobileTool tool)
	{
	}

	private void UpdateData(InputField field, int adr)
	{
	}

	private void CheckScreenPosition(int id)
	{
	}
}
