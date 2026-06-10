using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ColumnCounterUI : MonoBehaviour
{
	private GridLayoutGroup glg;

	private RectTransform paneltest;

	private float pivot_position = 0.8f;

	public GameObject button;

	private void CompareNumbers()
	{
		paneltest = GetComponent<RectTransform>();
		paneltest.position = new Vector2(button.transform.position.x, paneltest.position.y);
		int num = base.transform.childCount - 1;
		glg = base.gameObject.GetComponent<GridLayoutGroup>();
		if (num > 12)
		{
			glg.constraintCount = 12;
		}
		else
		{
			glg.constraintCount = num;
		}
	}

	private void Start()
	{
		CompareNumbers();
		StartCoroutine(CompareWidth());
	}

	private IEnumerator CompareWidth()
	{
		yield return 0;
		if (glg.constraintCount > 3)
		{
			paneltest.pivot = new Vector2(pivot_position, 0f);
		}
		if (paneltest.rect.width * pivot_position > button.transform.position.x)
		{
			paneltest.pivot = new Vector2(0f, 0f);
			paneltest.position = new Vector2(0f, paneltest.position.y);
		}
	}
}
