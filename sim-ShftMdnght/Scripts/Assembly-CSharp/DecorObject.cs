using UnityEngine;

public class DecorObject : MonoBehaviour
{
	public int decorPoints;

	public Transform decorParticlesPoint;

	public bool autoIncreaseParticles = true;

	public GameObject decorIncreaseParticles;

	public GameObject decorDecreaseParticles;

	private void OnEnable()
	{
		if (autoIncreaseParticles)
		{
			IncreaseParticles();
		}
	}

	public void IncreaseParticles()
	{
		Object.Instantiate(decorIncreaseParticles, decorParticlesPoint.position, Quaternion.identity);
		ReviewsManager.Instance.UpdateDecorPoints(decorPoints);
	}

	public void DecreaseParticles()
	{
		Object.Instantiate(decorDecreaseParticles, decorParticlesPoint.position, Quaternion.identity);
		ReviewsManager.Instance.UpdateDecorPoints(-decorPoints);
	}
}
