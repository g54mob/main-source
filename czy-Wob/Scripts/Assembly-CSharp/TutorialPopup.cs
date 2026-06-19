using System.Collections;
using TMPro;
using UnityEngine;

public class TutorialPopup : MonoBehaviour
{
	public TextMeshProUGUI popupText;

	public GameObject dogFaceTop;

	public GameObject dogFaceLeft;

	private CoreButton.OnClickDelegate callback;

	private ulong? textScaleKey;

	private string openSound = "tutorial_popup_open";

	private string closeSound = "tutorial_popup_close";

	private bool destroyed;

	private PenFocus penFocusRef;

	private GUIManagerPens guiRef;

	private ObjectRegistration regRef;

	private void Awake()
	{
		penFocusRef = Camera.main.GetComponent<PenFocus>();
		regRef = ObjectRegistration.GetRegistrationScript();
		guiRef = regRef.GetGlobalComponent<GUIManagerPens>(GlobalObject.GUI);
		penFocusRef.SetInputAllowed(val: false, LockReason.TUTORIAL_POPUP);
		guiRef.SetGUIInteractiveStatus(status: false, LockReason.TUTORIAL_POPUP);
		PopInDoggies();
		AudioController.Play(openSound);
	}

	public void SetStomp(bool stompValue)
	{
		guiRef.RegisterNewPopup(LockReason.TUTORIAL_POPUP, stompValue);
	}

	public void RequestDestroy()
	{
		DestroyInternal();
		Object.Destroy(base.gameObject);
	}

	private void OnDestroy()
	{
		DestroyInternal();
	}

	private void DestroyInternal()
	{
		if (!destroyed)
		{
			destroyed = true;
			AudioController.Play(closeSound);
			guiRef.ClearPopupRegistration(LockReason.TUTORIAL_POPUP);
			penFocusRef.SetInputAllowed(val: true, LockReason.TUTORIAL_POPUP);
			guiRef.SetGUIInteractiveStatus(status: true, LockReason.TUTORIAL_POPUP);
		}
	}

	public void SetMessageText(string text)
	{
		if (textScaleKey.HasValue)
		{
			TextScaleInEffect.RequestEffectEnd(textScaleKey.Value, popupText);
		}
		popupText.text = text;
		textScaleKey = TextScaleInEffect.ScaleInText(popupText, null, TextFinishedCallback);
	}

	private void TextFinishedCallback(ulong key)
	{
		textScaleKey = null;
	}

	public void SetCallback(CoreButton.OnClickDelegate newCallback)
	{
		callback = newCallback;
	}

	public void OnOkayButtonPressed()
	{
		CoreButton.OnClickDelegate onClickDelegate = callback;
		callback = null;
		onClickDelegate?.Invoke();
	}

	private void PopInDoggies()
	{
		StartCoroutine(PopInRoutine());
	}

	private IEnumerator PopInRoutine()
	{
		Vector3 topMovLocal = new Vector3(0f, 150f, 0f);
		Vector3 leftMovLocal = new Vector3(-150f, 0f, 0f);
		dogFaceTop.transform.localPosition -= topMovLocal;
		dogFaceLeft.transform.localPosition -= leftMovLocal;
		yield return new WaitForEndOfFrame();
		Inchworm globalComponent = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<Inchworm>(GlobalObject.INCHWORM);
		globalComponent.RequestEase(easeVector: dogFaceTop.transform.TransformVector(topMovLocal), objectToEase: dogFaceTop, duration: 10f, adjustStartingPos: false, easeStyle: Inchworm.EaseStyle.Sin, easeType: Inchworm.EaseType.Position, callback: null, priority: Inchworm.EasePriority.Normal, keepSameParent: true);
		globalComponent.RequestEase(easeVector: dogFaceLeft.transform.TransformVector(leftMovLocal), objectToEase: dogFaceLeft, duration: 1f, adjustStartingPos: false, easeStyle: Inchworm.EaseStyle.EaseOutBounce, easeType: Inchworm.EaseType.Position, callback: null, priority: Inchworm.EasePriority.Normal, keepSameParent: true);
	}
}
