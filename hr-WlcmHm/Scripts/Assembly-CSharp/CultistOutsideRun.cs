using System.Collections;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;

public class CultistOutsideRun : MonoBehaviour
{
	[Header("Chasing Settings")]
	[SerializeField]
	private float runSpeed = 3.5f;

	[SerializeField]
	private float stoppingDistance = 1.5f;

	[SerializeField]
	private bool isRunning = true;

	[Header("Leader Cultist")]
	[SerializeField]
	private bool isLeader;

	[SerializeField]
	private float distanceBetween = 10f;

	[SerializeField]
	private Volume globalVolumeBase;

	private GameObject player;

	private PauseMenu pauseMenu;

	private PlayerController playerController;

	private FirstPersonController _firstPersonController;

	private NavMeshAgent navMeshAgent;

	public EventReference killSounds;

	private void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");
		playerController = player.GetComponent<PlayerController>();
		_firstPersonController = player.GetComponent<FirstPersonController>();
		pauseMenu = Object.FindAnyObjectByType<PauseMenu>();
		if (isRunning)
		{
			SetupNavMeshAgent();
		}
		RandomizeAnimation();
	}

	private void SetupNavMeshAgent()
	{
		navMeshAgent = GetComponent<NavMeshAgent>();
		navMeshAgent.speed = runSpeed;
		navMeshAgent.stoppingDistance = stoppingDistance;
	}

	private void Update()
	{
		if (!pauseMenu.isPaused && !playerController.DialogueBox.activeSelf && isLeader)
		{
			float sqrMagnitude = (base.transform.position - player.transform.position).sqrMagnitude;
			float num = distanceBetween * distanceBetween;
			float target = ((sqrMagnitude <= num) ? 0.5f : 1f);
			globalVolumeBase.weight = Mathf.MoveTowards(globalVolumeBase.weight, target, 0.1f * Time.deltaTime);
		}
	}

	private void FixedUpdate()
	{
		if (!pauseMenu.isPaused && !playerController.DialogueBox.activeSelf && isRunning)
		{
			navMeshAgent.SetDestination(player.transform.position);
		}
	}

	private void RandomizeAnimation()
	{
		Animation componentInChildren = GetComponentInChildren<Animation>();
		if (componentInChildren != null && componentInChildren.clip != null)
		{
			componentInChildren[componentInChildren.clip.name].time = Random.Range(0f, componentInChildren.clip.length);
			componentInChildren.Sample();
			componentInChildren.Play();
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			other.GetComponent<FirstPersonController>().DisableInput();
			StartCoroutine(StartGameOver());
			_firstPersonController.isWalking = false;
			_firstPersonController.DisableInput();
		}
	}

	private IEnumerator StartGameOver()
	{
		playerController.GetComponentInChildren<PauseMenu>().StartGameOver();
		yield return new WaitForSeconds(4f);
		playKillSound();
		yield return new WaitForSeconds(2f);
		yield return new WaitForSeconds(7f);
	}

	private void playKillSound()
	{
		EventInstance instance = RuntimeManager.CreateInstance(killSounds);
		RuntimeManager.AttachInstanceToGameObject(instance, base.transform);
		instance.start();
		instance.release();
	}
}
