using UnityEngine;
using UnityEngine.UI;

public class RedrawVersion : MonoBehaviour
{
	private void Update()
	{
		if (Program.GetVersionString() != null)
		{
			GetComponent<Text>().text = Program.GetVersionString();
			Object.Destroy(this);
		}
	}
}
