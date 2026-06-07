using Unity.Netcode;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerAudioMixerHandler : NetworkBehaviour
{
	[SerializeField]
	private AudioMixer mixer;

	[SerializeField]
	private AudioMixerSnapshot defaultSnapshot;

	[SerializeField]
	private AudioMixerSnapshot interiorSnapShot;

	public override void OnNetworkSpawn()
	{
	}

	private void Start()
	{
	}

	private void Update()
	{
	}

	public void SetSnapshot_Interior()
	{
		if (base.IsOwner)
		{
			interiorSnapShot.TransitionTo(1f);
			Debug.Log("Interior Snapshot Enabled");
		}
	}

	public void SetSnapshot_Default()
	{
		if (base.IsOwner)
		{
			defaultSnapshot.TransitionTo(1f);
			Debug.Log("Default Snapshot Enabled");
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("ReverbZone"))
		{
			SetSnapshot_Interior();
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("ReverbZone"))
		{
			SetSnapshot_Default();
		}
	}

	protected override void __initializeVariables()
	{
		base.__initializeVariables();
	}

	protected override void __initializeRpcs()
	{
		base.__initializeRpcs();
	}

	protected internal override string __getTypeName()
	{
		return "PlayerAudioMixerHandler";
	}
}
