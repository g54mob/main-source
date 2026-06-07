using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;

public class VirtualMouseDebugger : MonoBehaviour
{
	private TMP_Text msg;

	private VirtualMouseInput vmi;

	private Mouse systemMouse;

	private Mouse virtualMouse;

	private StringBuilder sb;

	private void OnEnable()
	{
	}

	private void Update()
	{
	}
}
