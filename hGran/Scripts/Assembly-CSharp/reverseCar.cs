using System;
using UnityEngine;

[Serializable]
public class reverseCar : MonoBehaviour
{
	public GameObject carAnimation;

	public GameObject reverseButton;

	public GameObject outOffCarButton;

	public bool reverse1Played;

	public GameObject carReverseSound1;

	public GameObject engineOnSound;

	public GameObject frontCrashSound;

	public GameObject frontCrashSound2;

	public GameObject CarHitTriggers;

	public GameObject optionButton;

	public GameObject gameController;

	public virtual void Start()
	{
	}

	public virtual void Update()
	{
	}
}
