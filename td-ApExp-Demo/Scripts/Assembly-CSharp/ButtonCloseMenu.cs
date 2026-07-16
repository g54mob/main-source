using UnityEngine;
using UnityEngine.UI;

public class ButtonCloseMenu : MonoBehaviour
{
	private void Awake()
	{
		GetComponent<Button>().onClick.AddListener(delegate
		{
			MenuManager.Instance.CloseCurrentMenu();
		});
	}
}
