using UnityEngine;

public abstract class TutorialEvent : MonoBehaviour
{
	protected TutorialManager tutorialManager;

	protected TutorialPhase tutorialPhase;

	public void Setup(TutorialManager tutorialManager, TutorialPhase tutorialPhase)
	{
		this.tutorialManager = tutorialManager;
		this.tutorialPhase = tutorialPhase;
	}

	public abstract void Begin();

	public abstract void Finish();

	public abstract void Skip();
}
