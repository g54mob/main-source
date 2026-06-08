using UnityEngine;
using UnityEngine.UI;

public class NotepadButton : MonoBehaviour
{
	[SerializeField]
	private int page;

	private Notepad notepad;

	public void Start()
	{
		GetComponent<Button>().onClick.AddListener(SwitchPage);
	}

	public void SwitchPage()
	{
		Debug.Log($"Switching page {page}");
		if (notepad == null)
		{
			notepad = GetComponentInParent<Notepad>();
		}
		notepad.SetCurrentPage(page - 1);
	}
}
