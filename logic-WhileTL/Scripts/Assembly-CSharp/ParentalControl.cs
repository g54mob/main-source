using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ParentalControl : ActiveComponent
{
	[SceneBind("Ok")]
	public Button Ok;

	protected override void OnInit()
	{
		SceneBindContainer.BindObjects(this, base.transform);
	}

	public void OpenURL(List<string> urls)
	{
		Ok.onClick.RemoveAllListeners();
		Ok.onClick.AddListener(delegate
		{
			ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
			foreach (string url in urls)
			{
				Debug.Log("Open url " + url);
				Application.OpenURL(url);
			}
			base.gameObject.SetActive(value: true);
		});
	}

	private void Update()
	{
	}
}
