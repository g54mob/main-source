using TMPro;
using UnityEngine;

public class SearchResultButton : MonoBehaviour
{
	public TextMeshProUGUI nameText;

	public TextMeshProUGUI statusText;

	public string dbName;

	public bool descriptionButton;

	public int descIndex;

	public void ClickButton()
	{
		if (descriptionButton)
		{
			Computer.Instance.CheckDesc(descIndex);
		}
		else
		{
			Computer.Instance.ClickResult(dbName);
		}
	}
}
