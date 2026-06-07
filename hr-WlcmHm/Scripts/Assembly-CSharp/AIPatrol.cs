using System;
using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;
using UnityEngine.AI;

public class AIPatrol : MonoBehaviour
{
	[Tooltip("How close does the follower need to get to trigger Game Over.")]
	[SerializeField]
	private float catchDistance = 1.5f;

	[Tooltip("Running speed after the player is revealed.")]
	[SerializeField]
	private float runningSpeed = 5f;

	[SerializeField]
	private List<Transform> walkingPoints;

	private NavMeshAgent agent;

	private GameObject playerGameObject;

	private bool foundPlayer;

	private NoiseManager noiseManager;

	private int currPoint;

	private float findNextPointDistance = 1f;

	private PauseMenu pauseMenu;

	public EventReference killSounds;

	private void Start()
	{
		agent = GetComponent<NavMeshAgent>();
		playerGameObject = GameObject.FindGameObjectWithTag("Player");
		pauseMenu = playerGameObject.GetComponentInChildren<PauseMenu>();
		noiseManager = GameObject.FindGameObjectWithTag("NoiseManager").GetComponent<NoiseManager>();
		NoiseManager obj = noiseManager;
		obj.OnAlertNPCs = (NoiseManager.AlertNPCs)Delegate.Combine(obj.OnAlertNPCs, new NoiseManager.AlertNPCs(RevealPlayer));
		WalkToNextPoint();
	}

	private void Update()
	{
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
		if (foundPlayer)
		{
			agent.destination = playerGameObject.transform.position;
			agent.isStopped = false;
			return;
		}
		if (agent.remainingDistance <= findNextPointDistance)
		{
			currPoint++;
		}
		WalkToNextPoint();
	}

	private IEnumerator GameOverTransition()
	{
		FirstPersonController component = playerGameObject.GetComponent<FirstPersonController>();
		component.isWalking = false;
		playerGameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
		component.DisableInput();
		component.GetComponentInChildren<PauseMenu>().StartGameOver();
		yield return new WaitForSeconds(4f);
		PlayKillSound();
		yield return new WaitForSeconds(2f);
	}

	public void PlayKillSound()
	{
		EventInstance instance = RuntimeManager.CreateInstance(killSounds);
		RuntimeManager.AttachInstanceToGameObject(instance, base.transform);
		instance.start();
		instance.release();
	}

	private void WalkToNextPoint()
	{
		agent.destination = walkingPoints[currPoint % walkingPoints.Count].position;
		agent.isStopped = false;
	}

	private void RevealPlayer()
	{
		foundPlayer = true;
		agent.speed = runningSpeed;
	}

	private bool IsPlayerCloseEnough()
	{
		return Vector3.Distance(base.transform.position, playerGameObject.transform.position) <= catchDistance;
	}
}
