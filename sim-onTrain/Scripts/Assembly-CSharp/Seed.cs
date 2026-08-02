using UnityEngine;

public class Seed : MonoBehaviour
{
	public GameObject Tier1Crop;

	public GameObject Tier2Crop;

	public GameObject Tier3Crop;

	public GameObject Tier4Crop;

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Field")
		{
			Field field = (Field)collision.gameObject.GetComponent(typeof(Field));
			if (field == null)
			{
				field = (Field)collision.gameObject.transform.parent.gameObject.GetComponent(typeof(Field));
			}
			field.Tier1Crop = Tier1Crop;
			field.Tier2Crop = Tier2Crop;
			field.Tier3Crop = Tier3Crop;
			field.Tier4Crop = Tier4Crop;
			field.Plant();
			Object.Destroy(base.gameObject);
		}
	}
}
