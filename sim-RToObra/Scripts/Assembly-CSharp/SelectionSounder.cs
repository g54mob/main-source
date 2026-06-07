using UnityEngine;
using UnityEngine.UI;

public class SelectionSounder : MonoBehaviour
{
	public AudioKit audioKit;

	private Selectable cur;

	private void Start()
	{
	}

	private void OnEnable()
	{
		cur = SelectionHelper.GetCurrentSelectable();
	}

	private void Update()
	{
		Selectable selectable = cur;
		cur = SelectionHelper.GetCurrentSelectable();
		if (cur != null && selectable != null && cur != selectable)
		{
			audioKit.Play("selchange");
		}
	}
}
