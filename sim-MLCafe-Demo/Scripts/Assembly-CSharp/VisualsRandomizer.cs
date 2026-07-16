using UnityEngine;

public class VisualsRandomizer : MonoBehaviour
{
	public enum RandomMode
	{
		RandomizePrefabs = 0,
		RandomizeAngle = 1
	}

	[SerializeField]
	private RandomMode mode;

	[SerializeField]
	private Transform content;

	[SerializeField]
	private GameObject[] prefabs;

	[SerializeField]
	private float angleStep = 90f;

	private void Start()
	{
		switch (mode)
		{
		case RandomMode.RandomizePrefabs:
		{
			int num2 = Random.Range(0, prefabs.Length);
			Object.Instantiate(prefabs[num2], content);
			break;
		}
		case RandomMode.RandomizeAngle:
		{
			int num = Random.Range(0, (int)(360f / angleStep));
			base.transform.rotation = Quaternion.Euler(base.transform.eulerAngles.x, base.transform.eulerAngles.y + (float)num * angleStep, base.transform.eulerAngles.z);
			break;
		}
		}
	}
}
