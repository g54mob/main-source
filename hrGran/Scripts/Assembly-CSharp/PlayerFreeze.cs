using UnityEngine;
using UnityEngine.UI;

public class PlayerFreeze : MonoBehaviour
{
	public Image FreezeScreen;

	public GameObject FreezeScreenTexture;

	public bool freezeON;

	public bool freezeOFF;

	public GameObject Granny;

	public GameObject footstepScriptHolder;

	public GameObject player;

	public GameObject playerHead;

	public GameObject GrannyEye;

	public GameObject allBedButtons;

	public GameObject doorRay;

	public GameObject pickUpRay;

	public GameObject iceBreakSoundHolder;

	public bool playerStuckTimer;

	public float timerCount;

	private void Start()
	{
	}

	private void Update()
	{
	}

	public virtual void playerFreezeStuck()
	{
	}

	public virtual void playerFreezeFree()
	{
	}
}
