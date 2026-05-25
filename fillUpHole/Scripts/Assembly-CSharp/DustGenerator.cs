using UnityEngine;

public class DustGenerator : MonoBehaviour
{
	private void Start()
	{
	}

	private void Update()
	{
	}

	public void Generate(bool generateBig)
	{
		GetComponent<ParticleSystem>().Play();
		if (generateBig)
		{
			GameController.Instance.CloudGenerat.CreateSmallCloud(base.gameObject.transform.position);
		}
	}
}
