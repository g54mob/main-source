using I2.Loc;
using UnityEngine;

public class SeedPacket : MonoBehaviour
{
	public RoomCustomizationObject containedPlant;

	public GameObject worldMessagePrefab;

	public Color saleTextColor = Color.green;

	public GameObject actionParticles;

	private Vector3 messageOffset = new Vector3(0f, 1.5f, 0f);

	private string seedCollectSound = "egg_collect";

	private float currentTimer;

	private float autoCollectTimer = 10f;

	private float autoCollectionJiggle = 5f;

	private void Awake()
	{
		currentTimer = Random.Range(0f - autoCollectionJiggle, 0f);
	}

	public void Update()
	{
		if (GameSettings.IsPassiveModeEnabled() && GameSettings.PassiveModeAutoCollectSeeds())
		{
			currentTimer += Time.deltaTime;
			if (currentTimer >= autoCollectTimer)
			{
				Vector3 objCenter = ObjectUtil.GetObjCenter(base.gameObject);
				Object.Instantiate(actionParticles, objCenter, Quaternion.identity);
				CollectSeeds();
			}
		}
	}

	public void CollectSeeds()
	{
		Vector3 position = base.transform.GetComponentInChildren<Rigidbody>().position;
		GameObject obj = Object.Instantiate(worldMessagePrefab, position + messageOffset, Quaternion.identity);
		obj.transform.localScale = Vector3.one;
		WorldMessage component = obj.GetComponent<WorldMessage>();
		component.SetFadeTime(0.75f);
		component.SetDisplayColor(saleTextColor);
		component.SetDisplayMessage(ScriptLocalization.GUI.GUI_MESSAGE_SEEDSCOLLECT);
		AudioController.Play(seedCollectSound, position);
		Object.Destroy(base.gameObject);
	}
}
