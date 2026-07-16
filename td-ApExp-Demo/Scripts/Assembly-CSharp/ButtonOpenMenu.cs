using UnityEngine;
using UnityEngine.UI;

public class ButtonOpenMenu : MonoBehaviour
{
	[SerializeField]
	private MenuType menuType;

	private void Awake()
	{
		GetComponent<Button>().onClick.AddListener(delegate
		{
			MenuManager.Instance.OpenMenu(menuType);
		});
	}
}
