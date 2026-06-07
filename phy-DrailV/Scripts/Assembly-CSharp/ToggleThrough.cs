using UnityEngine;

public class ToggleThrough : MonoBehaviour
{
	public KeyCode key;

	public GameObject[] gos;

	public TextMesh text;

	private int current;

	private void Start()
	{
		SetObjectActive(0);
	}

	private void SetObjectActive(int index)
	{
		for (int i = 0; i < gos.Length; i++)
		{
			current = index % gos.Length;
			gos[i].SetActive(i == current);
		}
		if ((bool)text)
		{
			text.text = gos[current].name;
		}
	}

	private void Update()
	{
		if (Input.GetKeyDown(key))
		{
			SetObjectActive(++current);
		}
	}
}
