using System.Collections;
using App.Data;
using UnityEngine;
using UnityEngine.UI;

public class StartupResult : ActiveComponent
{
	[SceneBind("DeleteButton")]
	private Button deleteButton;

	[SceneBind("PayButton")]
	private Button payButton;

	[SceneBind("ProjectResultsText")]
	private Text _text;

	[SceneBind("ProjectResultsNumbersText")]
	private Text _numbersText;

	private bool _isActive;

	private int id;

	protected override void OnInit()
	{
		base.OnInit();
		SceneBindContainer.BindObjects(this, base.transform);
		deleteButton.onClick.AddListener(DeleteClicked);
		payButton.onClick.AddListener(PayClicked);
	}

	private void DeleteClicked()
	{
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		_isActive = false;
		Logic.DeleteStartup(id);
	}

	private void PayClicked()
	{
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		_isActive = false;
		Logic.StartupResult(id);
	}

	public void Redraw(Startup p, int i)
	{
		id = i;
		_isActive = true;
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
