using UnityEngine;
using UnityEngine.UI;

public class ButtonToButton : MonoBehaviour
{
	public GameObject btn;

	private void Awake()
	{
		if (btn != null)
		{
			base.gameObject.GetComponent<Button>().onClick.AddListener(delegate
			{
				btn.GetComponent<Button>().onClick.Invoke();
			});
		}
	}
}
