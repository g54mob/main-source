using UnityEngine;

public class Ivy : MonoBehaviour
{
	public GameObject seed;

	public GameObject stage_01;

	public GameObject stage_02;

	public InventoryItem ivyRef;

	private bool planted;

	private int spreadTryCount = 4;

	private float spreadTimer = 0.1f;

	private float spreadJiggle = 25f;

	private RaycastHit[] resultsList = new RaycastHit[100];

	private void Awake()
	{
		seed.SetActive(value: true);
		stage_01.SetActive(value: false);
		stage_02.SetActive(value: false);
	}

	private void Update()
	{
		TickSpread();
	}

	public void OnSeedPlanted()
	{
		planted = true;
		seed.SetActive(value: false);
		stage_01.SetActive(value: true);
		Transform parent = stage_01.transform.parent;
		parent.localPosition = seed.transform.localPosition - (seed.GetComponent<SphereCollider>().radius / 2f - parent.localScale.y / 2f) * seed.transform.up;
	}

	private void TickSpread()
	{
		if (!(spreadTimer <= 0f) && planted)
		{
			spreadTimer -= Time.deltaTime;
			if (spreadTimer <= 0f)
			{
				Spread();
			}
		}
	}

	private void Spread()
	{
		DogHome globalComponent = ObjectRegistration.GetRegistrationScript().GetGlobalComponent<DogHome>(GlobalObject.DOG_HOME);
		Vector3 position = stage_01.transform.parent.position;
		Vector3 endingPos = position;
		endingPos += base.transform.root.right * (stage_01.GetComponent<BoxCollider>().size.x + seed.GetComponent<SphereCollider>().radius);
		if (CanSpread(position, ref endingPos, spreadTryCount))
		{
			float num = Random.Range(0f - spreadJiggle, spreadJiggle);
			GameObject gameObject = globalComponent.TrySpawnItem(ivyRef, endingPos, null, moveToGoodLocation: false, null, Quaternion.Euler(0f, seed.transform.rotation.eulerAngles.y + num, 0f));
			if (!(gameObject == null))
			{
				gameObject.GetComponent<Ivy>().seed.GetComponent<Renderer>().enabled = false;
			}
		}
	}

	private bool CanSpread(Vector3 startingPos, ref Vector3 endingPos, int triesLeft)
	{
		Vector3 vector = base.transform.root.up * 0.1f;
		Vector3 vector2 = endingPos + vector;
		Vector3 vector3 = startingPos + vector;
		Vector3 vector4 = Vector3.Normalize(vector2 - vector3);
		float num = Vector3.Distance(vector3, vector2);
		int num2 = RaycastUtil.GoodRaycastAllNonAlloc(vector3, vector4, num, resultsList);
		for (int i = 0; i < num2; i++)
		{
			if (resultsList[i].transform != null && resultsList[i].transform.root != base.transform.root)
			{
				if (triesLeft <= 0)
				{
					return false;
				}
				triesLeft--;
				endingPos = startingPos + vector4 * (num / 2f);
				return CanSpread(startingPos, ref endingPos, triesLeft);
			}
		}
		return true;
	}
}
