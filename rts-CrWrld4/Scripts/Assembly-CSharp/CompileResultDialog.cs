using UnityEngine;
using UnityEngine.UI;

public class CompileResultDialog : MonoBehaviour
{
	public delegate void CompileResultCallback();

	public Text resultText;

	private CompileResultCallback callback;

	public void Show(string text, CompileResultCallback callback)
	{
	}

	public void OnDismiss()
	{
	}
}
