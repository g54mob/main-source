using UnityEngine;
using UnityEngine.UI;

public class BackEscape : MonoBehaviour
{
	public new bool enabled = true;

	private void Update()
	{
		bool flag = KeyListener.Instance.IsListening();
		if (!flag && enabled != flag && MyInputManager.GetButtonDown(MyInputManager.UICancel))
		{
			Button component = GetComponent<Button>();
			if (component.enabled && ((Selectable)component).m_Interactable)
			{
				component.m_OnClick.Invoke();
			}
		}
	}
}
