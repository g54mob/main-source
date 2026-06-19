using UnityEngine;
using UnityEngine.UI;

public class CocoonTimer : WorldSpaceBillboard
{
	public Image timerGraphic;

	public GameObject timerHolder;

	public GameObject hatchButtonHolder;

	public GameObject mutationInjectionButtonHolder;

	public Image heartGraphic;

	public GameObject finalHeart;

	public GameObject heartHolder;

	public GameObject mutationText;

	public GameObject heartBurstParticles;

	public GameObject mutationInjectionGUIPrefab;

	public CoreButtonUnityGUI hatchButton;

	private string cocoonIconSound = "cocoon_hatch_icon";

	private string mutationUpIconSound = "cocoon_mutation_up_icon";

	private float bounceTime = 1f;

	private bool guiHidden;

	private bool timerRequested;

	private bool requireVisibleHeart;

	private bool hatchButtonRequested;

	private bool heartGraphicRequested;

	private Canvas canvasRef;

	private Cocoon cocoonRef;

	private Inchworm inchwormRef;

	private DogRegistration dogRegRef;

	private DogPettingController pettingRef;

	protected override void AwakeBehavior()
	{
		base.AwakeBehavior();
		HideHeart();
		UpdateHeart(0f);
		finalHeart.SetActive(value: false);
		mutationText.SetActive(value: false);
		HideHatchButton();
		mutationInjectionButtonHolder.SetActive(value: false);
		canvasRef = GetComponentInChildren<Canvas>();
		ObjectRegistration registrationScript = ObjectRegistration.GetRegistrationScript();
		inchwormRef = registrationScript.GetGlobalComponent<Inchworm>(GlobalObject.INCHWORM);
		dogRegRef = registrationScript.GetGlobalComponent<DogRegistration>(GlobalObject.DOG_REGISTRATION);
		pettingRef = registrationScript.GetGlobalComponent<DogPettingController>(GlobalObject.DOG_PETTING_CONTROLLER);
	}

	private void Update()
	{
		if (PauseController.IsUIEnabled())
		{
			if (!canvasRef.enabled)
			{
				canvasRef.enabled = true;
			}
			if (timerGraphic.fillAmount >= 1f && !dogRegRef.AnyDogHatching() && !pettingRef.InPettingMode())
			{
				hatchButton.gameObject.SetActive(value: true);
			}
			else
			{
				hatchButton.gameObject.SetActive(value: false);
			}
		}
		else
		{
			canvasRef.enabled = false;
		}
	}

	public void UpdateTimer(float percentage)
	{
		timerGraphic.fillAmount = percentage;
		if (percentage >= 1f)
		{
			DisplayHatchButton();
		}
		else
		{
			HideHatchButton();
		}
	}

	public void OnMutationInjectionButtonClicked()
	{
		SaveableDog saveableDogFromID = dogRegRef.GetSaveableDogFromID(cocoonRef.GetAssociatedDogID());
		Object.Instantiate(mutationInjectionGUIPrefab, Vector3.zero, Quaternion.identity).GetComponent<MutationInjectionGUIController>().SetAssociatedDog(saveableDogFromID);
	}

	public void RequestHeartBurst()
	{
		ShowFinalHeart();
		mutationText.SetActive(value: true);
		Object.Instantiate(heartBurstParticles, heartGraphic.transform.TransformPoint(heartGraphic.transform.localPosition), Quaternion.identity);
		requireVisibleHeart = true;
		heartHolder.transform.localScale = Vector3.zero;
		inchwormRef.RequestEaseToScale(heartHolder, Vector3.one, bounceTime, Inchworm.EaseStyle.ElasticOut, HeartBounceCallback);
		AudioController.Play(mutationUpIconSound, heartHolder.transform);
		GoalsController.ReportGoalEvent(GoalCondition.COCOON_MUTATION_UP);
	}

	public void ShowFinalHeart()
	{
		finalHeart.SetActive(value: true);
	}

	private void HeartBounceCallback()
	{
		requireVisibleHeart = false;
		if (timerRequested)
		{
			HideHeart();
		}
	}

	public void UpdateHeart(float percentage)
	{
		heartGraphic.fillAmount = percentage;
	}

	public void SetCocoonRef(Cocoon newRef)
	{
		cocoonRef = newRef;
	}

	public void DisplayHeart(float percentage)
	{
		if (requireVisibleHeart)
		{
			timerRequested = false;
		}
		heartGraphicRequested = true;
		heartHolder.SetActive(value: true);
		timerHolder.SetActive(value: false);
		hatchButtonHolder.SetActive(value: false);
		UpdateHeart(percentage);
		if (percentage >= 1f)
		{
			ShowFinalHeart();
			mutationText.SetActive(value: true);
		}
	}

	public void HideHeart()
	{
		if (requireVisibleHeart)
		{
			timerRequested = true;
			return;
		}
		heartGraphicRequested = false;
		heartHolder.SetActive(value: false);
		if (hatchButtonRequested)
		{
			hatchButtonHolder.SetActive(value: true);
		}
	}

	public void DisplayHatchButton()
	{
		if (!guiHidden)
		{
			hatchButtonRequested = true;
			if (!heartGraphicRequested)
			{
				hatchButtonHolder.SetActive(value: true);
			}
			timerHolder.SetActive(value: false);
			mutationInjectionButtonHolder.SetActive(value: false);
			AudioController.Play(cocoonIconSound, cocoonRef.GetFocusTransform().position);
		}
	}

	public void HideHatchButton()
	{
		if (!heartHolder.activeSelf)
		{
			hatchButtonRequested = false;
			timerHolder.SetActive(value: true);
			hatchButtonHolder.SetActive(value: false);
		}
	}

	public void HideAllGUI()
	{
		guiHidden = true;
		finalHeart.SetActive(value: false);
		heartHolder.SetActive(value: false);
		timerHolder.SetActive(value: false);
		hatchButtonHolder.SetActive(value: false);
		mutationInjectionButtonHolder.SetActive(value: false);
	}

	public void HatchCocoon()
	{
		cocoonRef.StartHatchRoutine();
	}
}
