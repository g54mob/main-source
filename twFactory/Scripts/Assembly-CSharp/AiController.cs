using UnityEngine;

[RequireComponent(typeof(FSMComponent))]
public class AiController : Controller
{
	private FSMComponent fsmComponent;

	protected override void Awake()
	{
		base.Awake();
		fsmComponent = GetComponent<FSMComponent>();
	}

	public void PauseAI(bool pause)
	{
		fsmComponent.Pause(pause);
	}
}
