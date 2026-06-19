using System.Collections;
using UnityEngine;

public class BreedingPenGUI : MonoBehaviour
{
	public GameObject tinyLitterText;

	public GameObject massiveLitterText;

	public GameObject confettiBurst;

	private Coroutine currentLitterTextRoutine;

	private string tinyLitterSound = "breedingCenter_TinyLitter";

	private string massiveLitterSound = "breedingCenter_MassiveLitter";

	private BreedingGUI breedingGUIRef;

	private void Awake()
	{
		tinyLitterText.SetActive(value: false);
		massiveLitterText.SetActive(value: false);
	}

	private void Start()
	{
		breedingGUIRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<SceneManagerBreeding>(GlobalObject.SCENE_MANAGER).GetBreedingGUIRef();
	}

	public void SetGeneration(int num)
	{
		if (breedingGUIRef == null)
		{
			breedingGUIRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<SceneManagerBreeding>(GlobalObject.SCENE_MANAGER).GetBreedingGUIRef();
		}
		if (breedingGUIRef != null)
		{
			breedingGUIRef.SetGeneration(num);
		}
	}

	public void HideBreedingObjects()
	{
		if (breedingGUIRef != null)
		{
			breedingGUIRef.HideBreedingObjects();
		}
	}

	public void ShowBreedingObjects()
	{
		if (breedingGUIRef != null)
		{
			breedingGUIRef.ShowBreedingObjects();
		}
	}

	public void OnDogSelected()
	{
		ObjectRegistration.GetRegistrationScript().GetGlobalComponent<SceneManagerBreeding>(GlobalObject.SCENE_MANAGER).ShowPeekCutscene();
	}

	public void OnMassiveLitter()
	{
		StopLitterRoutine();
		currentLitterTextRoutine = StartCoroutine(MassiveLitterTextRoutine());
		GoalsController.ReportGoalEvent(GoalCondition.MASSIVE_LITTER);
	}

	public void OnTinyLitter()
	{
		StopLitterRoutine();
		currentLitterTextRoutine = StartCoroutine(TinyLitterTextRoutine());
		GoalsController.ReportGoalEvent(GoalCondition.TINY_LITTER);
	}

	private void StopLitterRoutine()
	{
		if (currentLitterTextRoutine != null)
		{
			StopCoroutine(currentLitterTextRoutine);
			currentLitterTextRoutine = null;
			tinyLitterText.SetActive(value: false);
			massiveLitterText.SetActive(value: false);
		}
	}

	private IEnumerator MassiveLitterTextRoutine()
	{
		massiveLitterText.SetActive(value: true);
		massiveLitterText.GetComponent<TextScaleInOnLoad>().RequestScaleIn();
		AudioController.Play(massiveLitterSound);
		yield return new WaitForSeconds(0.5f);
		RoomBase roomRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<ConstructionManager>(GlobalObject.CONSTRUCTION_MANAGER).GetAllRooms()[0].GetComponent<RoomBase>();
		Object.Instantiate(confettiBurst, roomRef.GetRoomCenter(), Quaternion.identity);
		yield return new WaitForSeconds(0.25f);
		Object.Instantiate(confettiBurst, roomRef.GetRoomCenter() + Vector3.left * 5f, Quaternion.identity);
		yield return new WaitForSeconds(0.25f);
		Object.Instantiate(confettiBurst, roomRef.GetRoomCenter() + Vector3.right * 5f, Quaternion.identity);
		yield return new WaitForSeconds(0.5f);
		massiveLitterText.GetComponent<TextScaleInOnLoad>().RequestScaleOut();
		yield return new WaitForSeconds(2f);
		breedingGUIRef.ShowBreedingObjects();
		currentLitterTextRoutine = null;
	}

	private IEnumerator TinyLitterTextRoutine()
	{
		tinyLitterText.SetActive(value: true);
		tinyLitterText.GetComponent<TextScaleInOnLoad>().RequestScaleIn();
		AudioController.Play(tinyLitterSound);
		yield return new WaitForSeconds(1.5f);
		tinyLitterText.GetComponent<TextScaleInOnLoad>().RequestScaleOut();
		yield return new WaitForSeconds(2f);
		breedingGUIRef.ShowBreedingObjects();
		currentLitterTextRoutine = null;
	}
}
