using UnityEngine;

public class STMInputStringDemo : MonoBehaviour
{
	public SuperTextMesh rawstm;

	public SuperTextMesh stm;

	private void Update()
	{
		string inputString = Input.inputString;
		if (Input.GetKeyDown(KeyCode.Backspace))
		{
			rawstm.text = rawstm.text.Substring(0, rawstm.text.Length - 1);
			rawstm.Rebuild();
		}
		int i = 0;
		for (int length = inputString.Length; i < length; i++)
		{
			if (inputString[i] != '\b')
			{
				rawstm.text += inputString[i];
			}
		}
		if (inputString.Length > 0)
		{
			rawstm.Rebuild();
		}
	}

	public void UpdateBox()
	{
		stm.Text = rawstm.text;
	}
}
