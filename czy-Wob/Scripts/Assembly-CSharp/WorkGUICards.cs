using UnityEngine;

public class WorkGUICards : MonoBehaviour
{
	public GameObject workStartGUI;

	public GameObject workNearlyOverGUI;

	public GameObject workOverGUI;

	public AnimationClip clipRef;

	private string triggerName = "Flash";

	private Animator animatorRef;

	private void Awake()
	{
		animatorRef = GetComponent<Animator>();
		animatorRef.StopPlayback();
		workOverGUI.SetActive(value: false);
		workStartGUI.SetActive(value: false);
		workNearlyOverGUI.SetActive(value: false);
	}

	public void ShowWorkStartGUI()
	{
		workOverGUI.SetActive(value: false);
		workStartGUI.SetActive(value: true);
		workNearlyOverGUI.SetActive(value: false);
		animatorRef.SetTrigger(triggerName);
	}

	public void ShowWorkNearlyOverGUI()
	{
		workOverGUI.SetActive(value: false);
		workStartGUI.SetActive(value: false);
		workNearlyOverGUI.SetActive(value: true);
		animatorRef.SetTrigger(triggerName);
	}

	public void ShowWorkOverGUI()
	{
		workOverGUI.SetActive(value: true);
		workStartGUI.SetActive(value: false);
		workNearlyOverGUI.SetActive(value: false);
		animatorRef.SetTrigger(triggerName);
	}
}
