using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ConfirmationView : ActiveComponent
{
	[SceneBind("ButtonYes")]
	private Button _yes;

	[SceneBind("ButtonNo")]
	private Button _no;

	[SceneBind("Loading")]
	private Image Loading;

	private void YesClick()
	{
		Loading.gameObject.SetActive(value: true);
		Logic.DeleteAllSaves();
		SceneManager.LoadSceneAsync(0);
	}

	public override void Init()
	{
		base.Init();
		SceneBindContainer.BindObjects(this, base.transform);
		_yes.onClick.AddListener(YesClick);
		_no.onClick.AddListener(delegate
		{
			base.gameObject.SetActive(value: false);
		});
		Loading.gameObject.SetActive(value: false);
	}
}
