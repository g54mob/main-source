using System.Collections.Generic;
using UnityEngine;

public class PlantController : MonoBehaviour
{
	public enum PlantStage
	{
		SEED = 0,
		MOUND = 1,
		SPROUT = 2,
		FINAL = 3
	}

	public GameObject seed;

	public GameObject mound;

	public List<GameObject> sproutStages = new List<GameObject>();

	public GameObject finalPlant;

	public GameObject finalPlantBoxHolder;

	public float startingLife = 2f;

	public float sproutStageLifeUpdates = 2f;

	public float finalLife = 25f;

	protected float life = 2f;

	public float maxLife = 2f;

	protected float bitePower = 1f;

	protected float recoverRate = 0.1f;

	public float finalPlantSize = 3f;

	public float currentGrowTimer;

	public float moundGrowthTimeLow = 5f;

	public float moundGrowthTimeHigh = 15f;

	public float sproutAmount = 0.1f;

	private PlantStage currentPlantStage;

	protected float debugTimeMultiplier = 100f;

	protected float maxSize;

	protected BoundingBoxComponent treeBox;

	protected BoundingBoxComponent sproutBox;

	private int currentSproutStage;

	private Segment currentEase;

	private Inchworm inchwormRef;

	private NavmeshHelper navmeshRef;

	private void Awake()
	{
		AwakeBehavior();
	}

	public void SavePlant(SaveablePlant plant)
	{
		OnSave();
		plant.maxLife = maxLife;
		plant.life = life;
		plant.currentGrowTimer = currentGrowTimer;
		plant.currentPlantStage = currentPlantStage;
		plant.currentSproutStage = currentSproutStage;
	}

	public void LoadPlant(SaveablePlant plant)
	{
		SetPlantStage(plant.currentPlantStage, fromLoad: true);
		if (currentPlantStage == PlantStage.SPROUT)
		{
			ActivateSproutStage(plant.currentSproutStage, fromLoad: true);
		}
		life = plant.life;
		maxLife = plant.maxLife;
		currentGrowTimer = plant.currentGrowTimer;
	}

	protected virtual void AwakeBehavior()
	{
		life = maxLife;
		inchwormRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<Inchworm>(GlobalObject.INCHWORM);
		SetPlantStage(PlantStage.SEED);
		treeBox = finalPlantBoxHolder.AddComponent<BoundingBoxComponent>();
		finalPlant.transform.localScale = new Vector3(1f, finalPlantSize, 1f);
		finalPlant.SetActive(value: true);
		maxSize = treeBox.GetBoxSize().y - mound.transform.localScale.y;
		finalPlant.SetActive(value: false);
		navmeshRef = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<NavmeshHelper>(GlobalObject.NAVMESH_HELPER);
	}

	public void UpdateMaxLife(float newVal)
	{
		float num = newVal - maxLife;
		maxLife = newVal;
		life += num;
	}

	private void Update()
	{
		Grow();
		Recover();
	}

	private void OnDestroy()
	{
		if (currentEase != null)
		{
			inchwormRef.CancelAndFinishEase(ref currentEase);
		}
		navmeshRef.Rebuild();
	}

	public virtual void OnSave()
	{
		if (currentEase != null)
		{
			inchwormRef.CancelAndFinishEase(ref currentEase);
			currentEase = null;
		}
	}

	public void AdvanceSproutStage()
	{
		ActivateSproutStage(currentSproutStage + 1);
	}

	public void SetPlantStage(PlantStage newStage, bool fromLoad = false)
	{
		switch (newStage)
		{
		case PlantStage.SEED:
			EnterSeedStage();
			break;
		case PlantStage.MOUND:
			EnterMoundStage(fromLoad);
			break;
		case PlantStage.SPROUT:
			EnterSproutStage(fromLoad);
			break;
		case PlantStage.FINAL:
			EnterFinalStage(fromLoad);
			break;
		}
	}

	private void Grow()
	{
		switch (currentPlantStage)
		{
		case PlantStage.MOUND:
			MoundGrow();
			break;
		case PlantStage.SPROUT:
			SproutGrow();
			break;
		case PlantStage.FINAL:
			FinalGrow();
			break;
		case PlantStage.SEED:
			break;
		}
	}

	private void MoundGrow()
	{
		currentGrowTimer -= Time.deltaTime * debugTimeMultiplier;
		if (currentGrowTimer <= 0f && currentPlantStage == PlantStage.MOUND)
		{
			SetPlantStage(PlantStage.SPROUT);
		}
	}

	private void SproutGrow()
	{
		currentGrowTimer -= Time.deltaTime * debugTimeMultiplier;
		if (!(currentGrowTimer <= 0f))
		{
			return;
		}
		float y = sproutBox.GetBoxSize().y;
		if (y >= maxSize)
		{
			SetPlantStage(PlantStage.FINAL);
			currentGrowTimer = Random.Range(moundGrowthTimeLow, moundGrowthTimeHigh);
			return;
		}
		currentGrowTimer = Random.Range(moundGrowthTimeLow, moundGrowthTimeHigh);
		Vector3 vector = new Vector3(0f, sproutAmount, 0f);
		sproutStages[currentSproutStage].transform.localScale += vector;
		sproutBox.ForceUpdateBoundingBox();
		if (DoesPlantIntersect(sproutBox, 0f))
		{
			sproutStages[currentSproutStage].transform.localScale -= vector;
			return;
		}
		sproutBox.ForceUpdateBoundingBox();
		y = sproutBox.GetBoxSize().y;
		if (currentSproutStage < sproutStages.Count - 1)
		{
			float num = maxSize / (float)sproutStages.Count;
			int num2 = Mathf.Clamp(Mathf.FloorToInt(y / num), 0, sproutStages.Count - 1);
			if (currentSproutStage != num2)
			{
				ActivateSproutStage(num2);
				return;
			}
		}
		ScaleBounceObj(sproutStages[currentSproutStage]);
	}

	protected virtual void FinalGrow()
	{
	}

	private void EnterSeedStage()
	{
		currentPlantStage = PlantStage.SEED;
		seed.SetActive(value: true);
		mound.SetActive(value: false);
		finalPlant.SetActive(value: false);
		for (int i = 0; i < sproutStages.Count; i++)
		{
			sproutStages[i].SetActive(value: false);
		}
	}

	private void EnterMoundStage(bool fromLoad = false)
	{
		currentPlantStage = PlantStage.MOUND;
		seed.SetActive(value: false);
		mound.SetActive(value: true);
		finalPlant.SetActive(value: false);
		for (int i = 0; i < sproutStages.Count; i++)
		{
			sproutStages[i].SetActive(value: false);
		}
		currentGrowTimer = Random.Range(moundGrowthTimeLow, moundGrowthTimeHigh);
		if (!fromLoad)
		{
			mound.transform.localPosition = seed.transform.localPosition - mound.transform.localScale.y * 0.35f * seed.transform.up;
			ScaleBounceObj(mound);
		}
		else
		{
			StageActivationCallback();
		}
	}

	private void EnterSproutStage(bool fromLoad = false)
	{
		currentPlantStage = PlantStage.SPROUT;
		seed.SetActive(value: false);
		mound.SetActive(value: true);
		finalPlant.SetActive(value: false);
		if (!fromLoad)
		{
			sproutStages[0].transform.localPosition = mound.transform.localPosition + mound.transform.localScale.y / 2.25f * mound.transform.up;
		}
		ActivateSproutStage(0);
	}

	protected bool DoesPlantIntersect(BoundingBoxComponent bbc, float checkMov = 0.5f)
	{
		Vector3 vector = mound.transform.up * checkMov;
		bbc.gameObject.transform.localPosition += vector;
		bool result = bbc.CheckGlobalIntersect(allowDogIntersection: true);
		bbc.gameObject.transform.localPosition -= vector;
		return result;
	}

	private void EnterFinalStage(bool fromLoad = false)
	{
		if (!fromLoad)
		{
			finalPlant.transform.localPosition = mound.transform.localPosition;
			if (DoesPlantIntersect(treeBox))
			{
				return;
			}
		}
		currentPlantStage = PlantStage.FINAL;
		UpdateMaxLife(finalLife);
		seed.SetActive(value: false);
		mound.SetActive(value: false);
		for (int i = 0; i < sproutStages.Count; i++)
		{
			sproutStages[i].SetActive(value: false);
		}
		finalPlant.SetActive(value: true);
		FinalStageConfirmation(fromLoad);
		if (!fromLoad)
		{
			ScaleBounceObj(finalPlant);
		}
		else
		{
			StageActivationCallback();
		}
		navmeshRef.Rebuild();
	}

	protected virtual void FinalStageConfirmation(bool fromLoad = false)
	{
	}

	private void ActivateSproutStage(int stageToActivate, bool fromLoad = false)
	{
		currentSproutStage = stageToActivate;
		for (int i = 0; i < sproutStages.Count; i++)
		{
			sproutStages[i].SetActive(i == currentSproutStage);
		}
		if (currentSproutStage > 0 && !fromLoad)
		{
			Vector3 localScale = sproutStages[currentSproutStage].transform.localScale;
			sproutStages[currentSproutStage].transform.localScale = new Vector3(localScale.x, sproutStages[currentSproutStage - 1].transform.localScale.y, localScale.z);
			sproutStages[currentSproutStage].transform.localPosition = sproutStages[currentSproutStage - 1].transform.localPosition;
		}
		UpdateMaxLife(startingLife + (float)currentSproutStage * sproutStageLifeUpdates);
		sproutBox = sproutStages[currentSproutStage].AddComponent<BoundingBoxComponent>();
		if (!fromLoad)
		{
			ScaleBounceObj(sproutStages[currentSproutStage]);
		}
		else
		{
			StageActivationCallback();
		}
		navmeshRef.Rebuild();
	}

	protected void ScaleBounceObj(GameObject obj)
	{
		if (currentEase != null)
		{
			inchwormRef.CancelAndFinishEase(ref currentEase);
			currentEase = null;
		}
		Vector3 localScale = obj.transform.localScale;
		obj.transform.localScale *= 0.5f;
		StagePreBounce();
		obj.transform.localScale = localScale;
		StageActivationCallback();
	}

	private void StagePreBounce()
	{
		if (currentPlantStage != PlantStage.FINAL)
		{
			return;
		}
		Rigidbody[] componentsInChildren = finalPlant.GetComponentsInChildren<Rigidbody>();
		foreach (Rigidbody rigidbody in componentsInChildren)
		{
			if (rigidbody.gameObject.activeSelf && !(rigidbody.GetComponent<PlantTree>() != null))
			{
				rigidbody.isKinematic = true;
			}
		}
	}

	private void StageActivationCallback()
	{
		currentEase = null;
		if (currentPlantStage > PlantStage.MOUND)
		{
			GetComponent<InteractableBase>().enabled = true;
		}
		if (currentPlantStage != PlantStage.FINAL)
		{
			return;
		}
		Rigidbody[] componentsInChildren = finalPlant.GetComponentsInChildren<Rigidbody>();
		foreach (Rigidbody rigidbody in componentsInChildren)
		{
			if (!(rigidbody.GetComponent<PlantTree>() != null))
			{
				rigidbody.isKinematic = false;
			}
		}
	}

	public virtual void OnBreak()
	{
	}

	public virtual void OnAttackedByDog()
	{
		life -= bitePower;
		if (life <= 0f)
		{
			Break();
		}
	}

	protected virtual void Recover()
	{
		if (life < maxLife)
		{
			life += recoverRate * Time.deltaTime;
			if (life > maxLife)
			{
				life = maxLife;
			}
		}
	}

	protected virtual void Break()
	{
		OnBreak();
		Collider[] componentsInChildren = GetComponentsInChildren<Collider>();
		foreach (Collider collider in componentsInChildren)
		{
			Collider[] componentsInChildren2 = GetComponentsInChildren<Collider>();
			foreach (Collider collider2 in componentsInChildren2)
			{
				if (collider != collider2)
				{
					Physics.IgnoreCollision(collider, collider2, ignore: false);
				}
			}
		}
		Rigidbody[] componentsInChildren3 = GetComponentsInChildren<Rigidbody>();
		foreach (Rigidbody rigidbody in componentsInChildren3)
		{
			rigidbody.isKinematic = false;
			Joint component = rigidbody.GetComponent<Joint>();
			if (component != null)
			{
				Object.Destroy(component);
			}
			if (rigidbody.gameObject.transform.localScale.x < 0.2f)
			{
				Object.Destroy(rigidbody.gameObject);
			}
			rigidbody.gameObject.transform.SetParent(null);
			rigidbody.gameObject.AddComponent<InteractableBase>();
			rigidbody.gameObject.tag = Tags.TOY;
			rigidbody.gameObject.layer = 0;
			rigidbody.AddForce(new Vector3(Random.Range(0f - rigidbody.mass, rigidbody.mass), Random.Range(0f - rigidbody.mass, rigidbody.mass), Random.Range(0f - rigidbody.mass, rigidbody.mass)));
			ObjectRegistration.GetRegistrationScript().AssignID(rigidbody.gameObject, null);
			RegisterTaggedObject registerTaggedObject = rigidbody.gameObject.AddComponent<RegisterTaggedObject>();
			registerTaggedObject.objectType = TagsEnum.TOY;
			registerTaggedObject.ManualRegister();
		}
		Object.Destroy(base.gameObject);
	}
}
