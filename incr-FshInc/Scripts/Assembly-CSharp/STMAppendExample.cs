using UnityEngine;

public class STMAppendExample : MonoBehaviour
{
	public SuperTextMesh text;

	public string appendThis = "Hello!";

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			text.Append(appendThis);
		}
	}
}
