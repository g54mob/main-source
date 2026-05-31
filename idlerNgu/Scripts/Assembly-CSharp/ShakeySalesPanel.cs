using UnityEngine;
using UnityEngine.UI;

public class ShakeySalesPanel : MonoBehaviour
{
	public Character character;

	public GameObject salesPanel;

	public GameObject itemPanel;

	public Color curColor;

	public bool moveaway = true;

	private float itemx;

	private float itemy;

	private void Start()
	{
		curColor = salesPanel.GetComponentInChildren<Text>().color;
		if (itemPanel != null)
		{
			itemx = itemPanel.transform.position.x;
			itemy = itemPanel.transform.position.y;
		}
		else
		{
			itemx = -2000f;
			itemy = -2000f;
		}
	}

	private void Update()
	{
		if (itemPanel == null)
		{
			return;
		}
		if (character.menuID == 19 || character.menuID == 25 || character.menuID == 28 || character.menuID == 29 || character.menuID == 31 || character.menuID == 42 || character.menuID == 50 || character.menuID == 56)
		{
			itemx = itemPanel.transform.position.x;
			itemy = itemPanel.transform.position.y;
			float num = Mathf.Min(Mathf.Abs(Input.mousePosition.x - itemx) / 400f + Mathf.Abs(Input.mousePosition.y - itemy) / 400f, 1f);
			if (num < 0.1f)
			{
				num = 0f;
			}
			Color color = (salesPanel.GetComponentInChildren<Text>().color = new Color(curColor.r, curColor.g, curColor.b, num));
			curColor = color;
			moveaway = true;
			if (character.settings.shakeySales)
			{
				float num2 = Random.Range(-1f, 1f);
				float num3 = Random.Range(-1f, 1f);
				Vector3 position = itemPanel.transform.position;
				salesPanel.transform.position = new Vector3(position.x + num2, position.y + num3, position.z);
			}
			else
			{
				Vector3 position2 = itemPanel.transform.position;
				salesPanel.transform.position = new Vector3(position2.x, position2.y, position2.z);
			}
		}
		else if (moveaway)
		{
			moveaway = false;
			if (character.settings.shakeySales)
			{
				float num4 = Random.Range(-1f, 1f);
				float num5 = Random.Range(-1f, 1f);
				Vector3 position3 = itemPanel.transform.position;
				salesPanel.transform.position = new Vector3(position3.x + num4, position3.y + num5, position3.z);
			}
			else
			{
				Vector3 position4 = itemPanel.transform.position;
				salesPanel.transform.position = new Vector3(position4.x, position4.y, position4.z);
			}
		}
	}
}
