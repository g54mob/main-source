using UnityEngine;
using UnityEngine.UI;

public class CustomTurorialWindow : ActiveComponent
{
	[SceneBind("Custom")]
	private Image custom;

	[SceneBind("Prev")]
	private Image prev;

	[SceneBind("Custom/Ok")]
	private Button ok2;

	[SceneBind("Prev/Ok")]
	private Button Ok;

	private void CloseCustomClick()
	{
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		custom.gameObject.SetActive(value: false);
		prev.gameObject.SetActive(value: true);
	}

	private void Close()
	{
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		base.gameObject.SetActive(value: false);
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (custom.gameObject.activeSelf)
			{
				CloseCustomClick();
			}
			else if (prev.gameObject.activeSelf)
			{
				Close();
			}
		}
	}

	public void Redraw()
	{
		custom.gameObject.SetActive(value: true);
		prev.gameObject.SetActive(value: false);
	}

	protected override void OnInit()
	{
		base.OnInit();
		SceneBindContainer.BindObjects(this, base.transform);
		ok2.onClick.AddListener(CloseCustomClick);
		Ok.onClick.AddListener(Close);
		prev.gameObject.SetActive(value: false);
	}
}
