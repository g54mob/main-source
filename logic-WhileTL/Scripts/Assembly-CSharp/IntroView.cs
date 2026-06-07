using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class IntroView : ActiveComponent
{
	[SceneBind("CloseIntroButton")]
	private Button _button;

	[SceneBind("ScreenBlockImage")]
	private Image _screenBlock;

	[SceneBind("Tutorial")]
	private Transform _tutorial;

	[SceneBind("Intro")]
	private Transform _intro;

	private bool _isActive;

	protected override void OnInit()
	{
		base.OnInit();
		SceneBindContainer.BindObjects(this);
		_button.onClick.AddListener(CloseClicked);
	}

	public void Redraw()
	{
		_isActive = true;
	}

	public void Clear()
	{
		_isActive = false;
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.Return))
		{
			CloseClicked();
		}
	}

	private void CloseClicked()
	{
		if (!ActiveComponent._controller.nicknameController.gameObject.activeSelf)
		{
			ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
			_isActive = false;
			ActiveComponent.Model.globalSaves.Set(SaveFlags.SkipIntro);
			base.gameObject.SetActive(value: false);
			Logic.UpdateGlobalSaves();
		}
	}

	public IEnumerator WaitForUserAction()
	{
		while (_isActive)
		{
			yield return new WaitForEndOfFrame();
		}
	}
}
