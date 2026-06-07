using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ProjectResultsView : ActiveComponent
{
	[SceneBind("CloseResultsButton")]
	private Button _button;

	[SceneBind("ProjectResultsText")]
	private Text _text;

	[SceneBind("ProjectResultsNumbersText")]
	private Text _numbersText;

	[SceneBind("GoodAlgos")]
	private Text GoodAlgos;

	private bool _isActive;

	public int money;

	protected override void OnInit()
	{
		base.OnInit();
		SceneBindContainer.BindObjects(this, base.transform);
		_button.onClick.AddListener(CloseClicked);
	}

	private void CloseClicked()
	{
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		ActiveComponent.Model.P.Money += money;
		_isActive = false;
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
