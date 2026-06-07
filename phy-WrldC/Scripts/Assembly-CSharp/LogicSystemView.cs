using UnityEngine;

public class LogicSystemView : MonoBehaviour
{
	private bool shouldStart = true;

	public LogicSystemModel LogicSystemModel { get; set; }

	private void Start()
	{
		StopAllCoroutines();
	}

	private void OnDisable()
	{
		StopAllCoroutines();
		shouldStart = true;
		Debug.Log("Disable Logic System View");
	}

	private void Update()
	{
		if (!shouldStart)
		{
			return;
		}
		Debug.Log("Start Logic System View");
		foreach (Logic allLogic in LogicSystemModel.GetAllLogics())
		{
			if (allLogic.Active)
			{
				StartCoroutine(allLogic.Run());
			}
		}
		shouldStart = false;
	}
}
