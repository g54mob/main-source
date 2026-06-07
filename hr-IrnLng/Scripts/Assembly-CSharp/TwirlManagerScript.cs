using UnityEngine;
using UnityStandardAssets.ImageEffects;

public class TwirlManagerScript : MonoBehaviour
{
	private Twirl MyTwirl;

	public float TwirlAmount;

	private void Start()
	{
		MyTwirl = GetComponent<Twirl>();
	}

	private void Update()
	{
	}

	private void FixedUpdate()
	{
		MyTwirl.angle = Random.Range(0f, TwirlAmount);
	}
}
