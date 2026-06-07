using R3;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class GnormanToggle : MonoBehaviour
{
	[SerializeField]
	private GameObject shown;

	[SerializeField]
	private GameObject hidden;

	private void Awake()
	{
		GetComponent<Button>().onClick.AddListener(delegate
		{
			Database.Commands.Gnorman.ToggleVisibility();
		});
		Database.State.Gnorman.Visible.SubscribeToSetToggle(shown, hidden).AddTo(this);
	}
}
