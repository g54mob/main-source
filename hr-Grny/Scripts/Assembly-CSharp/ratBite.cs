using UnityEngine;

public class ratBite : MonoBehaviour
{
	public GameObject playerAnim;

	public GameObject noiseobject;

	public Transform noiseDropPoint;

	public GameObject gameController;

	public GameObject ratController;

	public AudioClip ratNoise;

	public AudioClip ratNoise2;

	public virtual void Start()
	{
	}

	public virtual void OnTriggerEnter(Collider other)
	{
	}
}
