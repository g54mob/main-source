using UnityEngine;

public class ChristmasBallBreak : MonoBehaviour
{
	[Header("Assign in Inspector")]
	public GameObject gameController;

	public GameObject particleEffectPrefab;

	public GameObject brokenBallPrefab;

	public AudioClip breakSound;

	[Header("Sound Settings")]
	public float soundVolume;

	private bool hasTriggered;

	public virtual void Start()
	{
	}

	private void OnCollisionEnter(Collision collision)
	{
	}
}
