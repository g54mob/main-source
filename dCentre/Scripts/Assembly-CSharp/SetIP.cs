using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class SetIP : MonoBehaviour
{
	[SerializeField]
	private TextMeshProUGUI ipTextField;

	private string ipAddress;

	[SerializeField]
	private GameObject canvas;

	[SerializeField]
	private GameObject hideableHint;

	private Server server;

	private string copiedIP;

	private bool isActive;

	[SerializeField]
	private TextMeshProUGUI hideableButtonText;

	private Action<InputAction.CallbackContext> escapePerformed;

	private void Awake()
	{
	}

	private void Update()
	{
	}

	public void ShowCanvas(Server _server)
	{
	}

	public void ClickNumber(string number)
	{
	}

	public void ClickButtonOK()
	{
	}

	public void ClickButtonDel()
	{
	}

	public void ClickButtonClear()
	{
	}

	public void ClickButtonCopy()
	{
	}

	public void ClickButtonPaste()
	{
	}

	public void ClickButtonCancel()
	{
	}

	private void CloseCanvas()
	{
	}

	private void CidrToSubnetMask(int cidr, out int m1, out int m2, out int m3, out int m4)
	{
		m1 = default(int);
		m2 = default(int);
		m3 = default(int);
		m4 = default(int);
	}

	private bool TryParseIpToOctets(string ipString, out int o1, out int o2, out int o3, out int o4)
	{
		o1 = default(int);
		o2 = default(int);
		o3 = default(int);
		o4 = default(int);
		return false;
	}

	private void IncrementOctets(ref int o1, ref int o2, ref int o3, ref int o4)
	{
	}

	public string GetMaskFromCidr(int cidr)
	{
		return null;
	}

	public string[] GetUsableIPsFromSubnet(string subnet)
	{
		return null;
	}

	public void ButtonHideShowHint()
	{
	}

	private void OnDestroy()
	{
	}
}
