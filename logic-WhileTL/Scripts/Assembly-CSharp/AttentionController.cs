using System.Collections;
using App.Data;
using UnityEngine;
using UnityEngine.UI;

public class AttentionController : ActiveComponent
{
	[SceneBind("Accept")]
	public Button Accept;

	[SceneBind("Cancel")]
	private Button Cancel;

	[SceneBind("Hide")]
	public Toggle DontShowAgain;

	[SceneBind("BodyText")]
	public Text BodyText;

	public BasicState wait;

	private bool transitionScreen;

	public IEnumerator WaitForUserAction()
	{
		while (wait == BasicState.Undefined)
		{
			yield return new WaitForEndOfFrame();
		}
	}

	private void OkClick()
	{
		if (transitionScreen && !ActiveComponent._controller.Transition.gameObject.activeSelf)
		{
			ActiveComponent._controller.Transition.gameObject.SetActive(value: true);
			ActiveComponent._controller.Transition.ActiveOnFade(OkClick);
		}
		else
		{
			ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
			wait = BasicState.Accept;
		}
	}

	private void CancelClick()
	{
		ActiveComponent.Sound.Play("Monokanal/WhileTrueLearn_MouseClick");
		wait = BasicState.Denied;
	}

	public void Redraw()
	{
		wait = BasicState.Undefined;
	}

	public void Redraw(bool hideState, bool transitionScreen = false)
	{
		if (DontShowAgain != null)
		{
			DontShowAgain.isOn = hideState;
		}
		this.transitionScreen = transitionScreen;
	}

	protected override void OnInit()
	{
		SceneBindContainer.BindObjects(this, base.transform);
		Accept.onClick.AddListener(OkClick);
		Cancel.onClick.AddListener(CancelClick);
	}
}
