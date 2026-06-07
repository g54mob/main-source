using UnityEngine;

public class UseRemote : MonoBehaviour
{
	public GameObject player;

	public GameObject doorLock;

	public Renderer lamp;

	public GameObject doorLockCollider;

	public GameObject lockSound;

	public GameObject door;

	public GameObject doorLockOpen;

	public GameObject doorLockClosed;

	public GameObject soundHolder;

	public GameObject needToGetCloserText;

	public GameObject remoteTextHolder;

	public bool doorUnlocked;

	public bool textTimerOnOff;

	public float textTimer;

	public virtual void Start()
	{
	}

	public virtual void Update()
	{
	}
}
