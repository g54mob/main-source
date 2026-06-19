using System.Collections;
using UnityEngine;

public class TutorialTimerHandler : MonoBehaviour, IFloaterPopulator
{
	private TruckTimerFloaterUI _truckTimerFloaterUI;

	public void TestTimerDemo()
	{
		StopAllCoroutines();
		StartCoroutine(TutorialStartTimerDemoCo());
	}

	public IEnumerator TutorialStartTimerDemoCo()
	{
		yield return _truckTimerFloaterUI.StartCoroutine(_truckTimerFloaterUI.TutorialRunTimerDemoCo());
	}

	public void AddedFloater(FloaterUI floaterAdded)
	{
		if (floaterAdded.TryGetComponent<TruckTimerFloaterUI>(out var component))
		{
			_truckTimerFloaterUI = component;
		}
	}

	public void RemovedFloater()
	{
	}
}
