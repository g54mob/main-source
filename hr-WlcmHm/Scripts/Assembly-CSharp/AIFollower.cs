using System;
using System.Collections;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;
using UnityEngine.AI;

public class AIFollower : MonoBehaviour
{
	[Tooltip("How close does the follower need to get to trigger Game Over.")]
	[SerializeField]
	private float catchDistance;

	[Tooltip("Running speed after the player is revealed.")]
	[SerializeField]
	private float runningSpeed;

	[Space]
	[Header("Sacrificial circle variables")]
	[Tooltip("Index of starting waypoint in the list of all waypoints.")]
	[SerializeField]
	private int startingIndex;

	[SerializeField]
	private bool startingInner = true;

	private PathingManager pathingManager;

	private NavMeshAgent navMeshAgent;

	private GameObject playerGameObject;

	private PauseMenu pauseMenu;

	public NoiseManager noiseManager;

	private FirstPersonController playerMovementState;

	public EventReference killSounds;

	private bool foundPlayer;

	private EActivity activity;

	private int currPoint;

	private int currCircleCount;

	private bool innerCircle = true;

	private int changeAfter = -1;

	private float findNextPointDistance = 1f;

	private bool followingPlayer;

	public bool lookingForPlayer = true;

	public float personalNoiseLevel;

	public float personalNoiseStep;

	public float personalNoiseDecrement;

	public EActivity Activity => activity;

	private void Start()
	{
		pathingManager = GameObject.FindGameObjectWithTag("CirclePathingManager").GetComponent<PathingManager>();
		changeAfter = pathingManager.ChangeCirclesAfterPoints;
		playerGameObject = GameObject.FindGameObjectWithTag("Player");
		pauseMenu = playerGameObject.GetComponentInChildren<PauseMenu>();
		navMeshAgent = GetComponent<NavMeshAgent>();
		playerMovementState = playerGameObject.GetComponent<FirstPersonController>();
		currPoint = startingIndex;
		innerCircle = startingInner;
		if (!innerCircle)
		{
			changeAfter--;
		}
		noiseManager = GameObject.FindGameObjectWithTag("NoiseManager").GetComponent<NoiseManager>();
		NoiseManager obj = noiseManager;
		obj.OnAlertNPCs = (NoiseManager.AlertNPCs)Delegate.Combine(obj.OnAlertNPCs, new NoiseManager.AlertNPCs(RevealPlayer));
		GoToNextPoint();
		activity = EActivity.WALKING;
		RandomizeAnimation();
	}

	private void Update()
	{
		if (foundPlayer)
		{
			navMeshAgent.destination = playerGameObject.transform.position;
			navMeshAgent.isStopped = false;
		}
		else if (navMeshAgent.remainingDistance <= findNextPointDistance)
		{
			GoToNextPoint();
		}
		if (personalNoiseLevel >= 50f)
		{
			navMeshAgent.destination = playerGameObject.transform.position;
			navMeshAgent.isStopped = false;
			followingPlayer = true;
		}
		if (personalNoiseLevel >= 100f)
		{
			noiseManager.IncreaseGlobalNoise();
		}
		if (personalNoiseLevel <= 0f && navMeshAgent.remainingDistance <= findNextPointDistance)
		{
			GoToNextPoint();
		}
		if (personalNoiseLevel >= 0f)
		{
			personalNoiseLevel -= personalNoiseDecrement;
		}
		if (IsPlayerCloseEnough())
		{
			if (pauseMenu != null)
			{
				StartCoroutine(GameOverTransition());
				pauseMenu.StartGameOver();
			}
			MonoBehaviour.print("Game Over!");
			base.enabled = false;
		}
	}

	private bool IsPlayerCloseEnough()
	{
		return Vector3.Distance(base.transform.position, playerGameObject.transform.position) <= catchDistance;
	}

	private void RevealPlayer()
	{
		foundPlayer = true;
		navMeshAgent.speed = runningSpeed;
		activity = EActivity.RUNNING;
	}

	private void GoToNextPoint()
	{
		navMeshAgent.destination = pathingManager.GetPoint(currPoint++, innerCircle).position;
		if (++currCircleCount % changeAfter == 0)
		{
			currCircleCount = 0;
			innerCircle = !innerCircle;
			if (innerCircle)
			{
				changeAfter++;
			}
			else
			{
				changeAfter--;
			}
		}
		navMeshAgent.isStopped = false;
	}

	public void IncreaseLocalNoise(int overload)
	{
		personalNoiseLevel += overload;
	}

	private void RandomizeAnimation()
	{
		Animation componentInChildren = GetComponentInChildren<Animation>();
		if (componentInChildren != null && componentInChildren.clip != null)
		{
			componentInChildren[componentInChildren.clip.name].time = UnityEngine.Random.Range(0f, componentInChildren.clip.length);
			componentInChildren.Sample();
			componentInChildren.Play();
		}
	}

	public void PlayKillSound()
	{
		EventInstance instance = RuntimeManager.CreateInstance(killSounds);
		RuntimeManager.AttachInstanceToGameObject(instance, base.transform);
		instance.start();
		instance.release();
	}

	private IEnumerator GameOverTransition()
	{
		playerMovementState.isWalking = false;
		playerGameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
		playerMovementState.DisableInput();
		playerMovementState.GetComponentInChildren<PauseMenu>().StartGameOver();
		yield return new WaitForSeconds(4f);
		PlayKillSound();
		yield return new WaitForSeconds(2f);
	}
}
