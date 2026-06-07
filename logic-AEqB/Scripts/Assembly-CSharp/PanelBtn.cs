using UnityEngine;
using UnityEngine.UI;

public class PanelBtn : MonoBehaviour
{
	private Manager m;

	private Image i;

	public int mypanel;

	public GameObject shade;

	private void Start()
	{
		i = GetComponent<Image>();
		m = Object.FindObjectOfType<Manager>();
	}

	private void Update()
	{
		shade.SetActive(m.currentPanel == mypanel);
	}
}
