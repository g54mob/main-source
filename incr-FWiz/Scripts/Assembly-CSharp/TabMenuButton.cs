using UnityEngine;
using UnityEngine.UI;

public class TabMenuButton : MonoBehaviour
{
	[SerializeField]
	private TabMenuPage _tabMenuPage;

	[SerializeField]
	private Button _button;

	protected void Start()
	{
	}

	protected void OnDestroy()
	{
	}

	private void SelectThis()
	{
	}

	protected virtual void OnTabSelected()
	{
	}

	protected virtual void OnEndTabSelected()
	{
	}
}
