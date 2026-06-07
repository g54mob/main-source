using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class EnterOnlyEndEdit : MonoBehaviour
{
	[SerializeField]
	private TMP_InputField input;

	public UnityEvent pressEnterEvent;

	private void Awake()
	{
		input.onEndEdit.AddListener(OnEndEdit);
	}

	private void OnDestroy()
	{
		input.onEndEdit.RemoveListener(OnEndEdit);
	}

	private void OnEndEdit(string text)
	{
		if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
		{
			pressEnterEvent.Invoke();
		}
	}
}
