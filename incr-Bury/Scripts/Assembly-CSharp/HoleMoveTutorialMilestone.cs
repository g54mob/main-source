using System;
using UnityEngine;

public class HoleMoveTutorialMilestone : MonoBehaviour
{
	private Rigidbody rb;

	private bool hasRbChangedToActive;

	private void Awake()
	{
		rb = GetComponentInParent<Rigidbody>();
	}

	private void Start()
	{
		GameManager singleton = GameManager.Singleton;
		singleton.OnRoundStart_Action = (Action)Delegate.Combine(singleton.OnRoundStart_Action, new Action(OnRoundStart));
	}

	private void OnDestroy()
	{
		GameManager singleton = GameManager.Singleton;
		singleton.OnRoundStart_Action = (Action)Delegate.Remove(singleton.OnRoundStart_Action, new Action(OnRoundStart));
	}

	private void Update()
	{
		if (!hasRbChangedToActive && !rb.isKinematic)
		{
			hasRbChangedToActive = true;
			GameManager singleton = GameManager.Singleton;
			singleton.OnRoundStart_Action = (Action)Delegate.Remove(singleton.OnRoundStart_Action, new Action(OnRoundStart));
			base.gameObject.SetActive(value: false);
		}
	}

	private void OnRoundStart()
	{
		if (!PlayerStats.Singleton.holeMove_IsUnlocked)
		{
			base.gameObject.SetActive(value: false);
		}
	}
}
