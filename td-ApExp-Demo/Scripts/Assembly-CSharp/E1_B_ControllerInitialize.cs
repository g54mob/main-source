using System.Collections.Generic;
using UnityEngine;

public class E1_B_ControllerInitialize : StateBase
{
	private CentipedeController controller;

	public override string Key => "Init";

	public E1_B_ControllerInitialize(StateMachine sm, CentipedeController controller)
		: base(sm)
	{
		transitionStates = new string[1] { "Behind" };
		this.controller = controller;
	}

	public E1_B_ControllerInitialize(StateMachine sm, string[] transitionStates, CentipedeController controller)
		: base(sm, transitionStates)
	{
		this.controller = controller;
	}

	public override bool CanEnter()
	{
		return true;
	}

	public override void EnterState()
	{
		controller.offScreen = true;
		controller.eyeAnim = controller.transform.Find("Part Head/Eye").GetComponent<Animator>();
		Dictionary<int, int> dictionary = new Dictionary<int, int>();
		dictionary.Add(0, 0);
		dictionary.Add(1, 0);
		dictionary.Add(2, 0);
		for (int i = 0; i < controller.PartCount; i++)
		{
			GameObject gameObject = Object.Instantiate(controller.bodyPrefab, controller.transform.position, Quaternion.identity, controller.transform);
			Transform transform = gameObject.transform;
			transform.SetSiblingIndex(1 + i);
			EnemyCentipede component = gameObject.GetComponent<EnemyCentipede>();
			component.controller = controller;
			int num = Random.Range(0, controller.armamentPrefabs.Length);
			dictionary[num]++;
			while (dictionary[num] > 3)
			{
				num = Random.Range(0, controller.armamentPrefabs.Length);
			}
			GameObject gameObject2 = Object.Instantiate(controller.armamentPrefabs[num], transform.position, Quaternion.identity, transform);
			component.arma = gameObject2.GetComponent<CentipedeArmament>();
			component.GetComponent<SimpleFlash>().AddSr(component.arma.GetComponent<SpriteRenderer>());
			component.arma.enemyCentipede = component;
			component.GetComponent<Outline>().outlineSr = component.arma.GetComponent<SpriteRenderer>();
			int num2 = Random.Range(0, controller.carapaceRustPrefabs.Length);
			GameObject gameObject3 = Object.Instantiate(controller.carapaceRustPrefabs[num2], transform.position, Quaternion.identity, transform.Find("Plate"));
			component.rustAnim = gameObject3.GetComponent<Animator>();
		}
		controller.segments = controller.GetComponentsInChildren<CentipedeSegment>();
		controller.enemies = controller.GetComponentsInChildren<EnemyCentipede>();
		controller.enemiesAlive = new List<EnemyCentipede>(controller.enemies);
		controller.enemiesActive = new List<EnemyCentipede>();
		controller.legs = controller.GetComponentsInChildren<CentipedeLegs>();
	}

	public void OnStart()
	{
		controller.trainFrontX = Train.Instance.GetFirstWagonRightPosX();
		for (int i = 0; i < controller.segments.Length; i++)
		{
			controller.segments[i].Initialize(controller, i);
			CentipedeSegment centipedeSegment = controller.segments[i];
			centipedeSegment.Initialize(controller, i);
			controller.segments[0].SetSortOrder(controller.segments.Length);
			if (i > 0 && i < controller.segments.Length - 3)
			{
				centipedeSegment.SetSortOrder(controller.segments.Length - i);
			}
		}
		for (int j = 0; j < controller.legs.Length; j++)
		{
			controller.legs[j].Initialize(controller, j);
		}
		controller.SetLegTimings();
		controller.Phase(1);
		controller.xOffset = controller.transform.position.x;
	}

	public override void UpdateState()
	{
	}

	public override void ExitState()
	{
	}

	public override bool CanExit()
	{
		return true;
	}
}
