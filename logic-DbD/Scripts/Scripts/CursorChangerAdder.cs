using UnityEngine;
using UnityEngine.UI;

public class CursorChangerAdder : MonoBehaviour
{
	[SerializeField]
	private int startIndex = 1;

	private void Start()
	{
		AddCursorChanger();
	}

	private void AddCursorChanger()
	{
		for (int i = startIndex; i < base.transform.childCount; i++)
		{
			GameObject gameObject = base.transform.GetChild(i).gameObject;
			if (gameObject.GetComponent<Button>() != null && gameObject.GetComponent<CursorChanger>() == null)
			{
				gameObject.AddComponent<CursorChangerExit>();
			}
		}
	}
}
