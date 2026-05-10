using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
	[SerializeField]
	private UnityEvent m_OnClick;

	private Button m_Button;

	private void Start()
	{
	}

	private void OnDestroy()
	{
	}
}
