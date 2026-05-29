using System;
using UnityEngine;

[Serializable]
public class grannyRestart : MonoBehaviour
{
	public GameObject Granny;

	public GameObject GrannyBody;

	public GameObject GrannyEyeLock;

	public Transform GrannyStartPos1;

	public Transform GrannyStartPos2;

	public Transform GrannyStartPos3;

	public Transform GrannyStartPos4;

	public float timerCount;

	public bool startTimer;

	public bool startTimer2;

	public float RandomNR;

	public bool playerFallDead;

	public bool playerDead;

	public bool playerFloor_1;

	public bool playerFloor_2;

	public bool playerFloor_Cellar;

	public bool playerFloor_SideHouse;

	public virtual void Start()
	{
	}

	public virtual void setTime()
	{
	}

	public virtual void setTime2()
	{
	}

	public virtual void Update()
	{
	}

	public virtual void noArrow()
	{
	}
}
