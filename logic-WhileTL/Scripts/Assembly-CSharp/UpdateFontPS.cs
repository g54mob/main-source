using UnityEngine;
using UnityEngine.UI;

public class UpdateFontPS : ActiveComponent
{
	private Text _text;

	public bool forceSelfDestroy;

	private bool selfDestroy = true;

	private bool started;

	private void Start()
	{
		Object.Destroy(this);
	}
}
