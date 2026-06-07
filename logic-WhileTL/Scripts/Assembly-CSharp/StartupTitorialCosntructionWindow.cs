using UnityEngine;
using UnityEngine.UI;

public class StartupTitorialCosntructionWindow : ActiveComponent
{
	[SceneBind("Scheme")]
	private Image scheme;

	[SceneBind("Release")]
	private Image release;

	[SceneBind("Scheme/Ok")]
	private Button ok2;

	[SceneBind("Release/Ok")]
	private Button Ok;

	[SceneBind("TrainTest")]
	private Image TrainTest;

	[SceneBind("TrainTest/Ok")]
	private Button ok3;

	private void CloseScheme()
	{
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		scheme.gameObject.SetActive(value: false);
		release.gameObject.SetActive(value: true);
	}

	private void CloseRelease()
	{
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		release.gameObject.SetActive(value: false);
		TrainTest.gameObject.SetActive(value: true);
	}

	private void Close()
	{
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		ActiveComponent.Model.P.startupConstructionTutorial = 1;
		Logic.UpdateGameSaves();
		base.gameObject.SetActive(value: false);
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			if (scheme.gameObject.active)
			{
				CloseScheme();
			}
			else if (release.gameObject.active)
			{
				CloseRelease();
			}
			else
			{
				Close();
			}
		}
	}

	public void Redraw()
	{
		release.gameObject.SetActive(value: false);
		TrainTest.gameObject.SetActive(value: false);
		scheme.gameObject.SetActive(value: true);
	}

	protected override void OnInit()
	{
		base.OnInit();
		SceneBindContainer.BindObjects(this, base.transform);
		ok3.onClick.AddListener(Close);
		ok2.onClick.AddListener(CloseScheme);
		Ok.onClick.AddListener(CloseRelease);
		release.gameObject.SetActive(value: false);
		TrainTest.gameObject.SetActive(value: false);
	}
}
