using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DayResultsView : ActiveComponent
{
	[SceneBind("CloseResultsButton")]
	public Button _button;

	[SceneBind("DayResultsText")]
	private Text _text;

	[SceneBind("DayResultsNumbersText")]
	private Text _numbersText;

	private bool _isActive;

	protected override void OnInit()
	{
		base.OnInit();
		SceneBindContainer.BindObjects(this, base.transform);
		_button.onClick.AddListener(CloseClicked);
	}

	private void CloseClicked()
	{
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		_isActive = false;
	}

	public void Redraw()
	{
		_isActive = true;
		_text.text = ActiveComponent._staticData.DayOffTemplates.GetRandomItem().Value;
	}

	public IEnumerator WaitForUserAction()
	{
		while (_isActive)
		{
			yield return new WaitForEndOfFrame();
		}
	}

	public void Clear()
	{
		_isActive = false;
	}
}
