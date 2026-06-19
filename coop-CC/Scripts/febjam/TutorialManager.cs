using System.Collections;
using System.Collections.Generic;
using Aggro.Core;
using Aggro.Core.Networking;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;

public class TutorialManager : AggroManagerBase<TutorialManager>, IInputController
{
	[Min(0f)]
	public float delayAfterChecked = 1f;

	public Canvas canvas;

	public DialogueObject welcomeDialogue;

	public float basicControlsIntroDelay = 1f;

	[Header("Move Forward")]
	public DialogueObject basicControlsMoveForwardDialogue;

	public TutorialGoal basicControlsMoveForwardGoal;

	[Min(0f)]
	public float basicControlsMoveForwardDuration = 2f;

	[Range(0f, 1f)]
	public float basicControlsMoveForwardAccelerationThreshold = 0.2f;

	[Header("Reserve")]
	public DialogueObject basicControlsReverseDialogue;

	public TutorialGoal basicControlsReverseGoal;

	[Min(0f)]
	public float basicControlsReverseDuration = 2f;

	[Range(-1f, 0f)]
	public float basicControlsReverseAccelerationThreshold = -0.2f;

	[Header("Drift")]
	public DialogueObject basicControlsDriftDialogue;

	public DialogueObject basicControlsDriftChargingDialogue;

	public TutorialGoal basicControlsDriftGoal;

	[Min(0f)]
	public float basicControlsDriftDuration = 2f;

	[Header("Nitro")]
	public DialogueObject basicControlsNitroDialogue;

	public TutorialGoal basicControlsNitroGoal;

	[Header("Outro")]
	public DialogueObject basicControlsOutroDialogue;

	public TutorialGate basicControlGate;

	public DialogueObject stressCollisionPreDialogue;

	public TutorialGoal stressCollisionGoal;

	public Booststrip stressBooststrip;

	public TutorialGate stressMidGateA;

	public TutorialGate stressMidGateB;

	public DialogueObject stressCollisionPostDialogue;

	public DialogueObject stressBarExplainDialogue;

	public DialogueObject stressCrashOutPreDialogue;

	[Min(0f)]
	public float stressCrashOutDelayBeforeBombsEarly = 1f;

	[Min(0f)]
	public float stressCrashOutDelayBeforeBombsLate = 0.5f;

	[Min(0f)]
	public float stressCrashOutDelayBeforeDialogue = 8f;

	public DialogueObject stressCrashOutPostDialogue;

	public DialogueObject stressOutroDialogue;

	public TutorialGate stressGate;

	public GameObject[] boxStuffBoxes;

	public Transform boxCameraTransform;

	public DialogueObject boxStuffIntroDialogue;

	public DialogueObject boxStuffStackTwoDialogue;

	public TutorialGoal boxStuffStackTwoGoal;

	public DialogueObject boxStuffStackThreeDialogue;

	public TutorialGoal boxStuffStackThreeGoal;

	public DialogueObject boxStuffUnstackDialogue;

	public TutorialGoal boxStuffStackUnstackGoal;

	public DialogueObject boxStuffIncorrectUnstackingDialogue;

	public Transform[] boxStuffRespawnPositions;

	public DialogueObject boxStuffOutroDialogue;

	public TutorialGate boxStuffGate;

	public DialogueObject trucksIntroDialogue;

	public DialogueObject trucksIncomingDialogue;

	public DialogueObject trucksOutgoingDialogue;

	public TutorialGoal trucksGoal;

	public InboundBay trucksInboundBay;

	public OutboundBay trucksOutboundBay;

	public Transform trucksTimerCameraLoc;

	public Transform trucksInboundLoc;

	[Min(0f)]
	public float trucksCameraPanDuration = 1f;

	public DialogueObject trucksOutroDialogue;

	public List<ShiftOrderObject> trucksInboundOrders;

	public List<ShiftOrderObject> trucksOutboundOrders;

	public TutorialTimerHandler tutorialTimerHandler;

	private ObjectQuery<TutorialSpawn> _spawnQuery;

	private ObjectQuery<TutorialContainer> _containerQuery;

	private bool _trigger;

	protected override void OnEntityCreated()
	{
		_spawnQuery = base.entityManager.CreateObjectQuery<TutorialSpawn>();
		_containerQuery = base.entityManager.CreateObjectQuery<TutorialContainer>();
		canvas.worldCamera = GameUtil.uiCamera;
		canvas.renderMode = RenderMode.ScreenSpaceCamera;
	}

	public void StartTutorial()
	{
		StartCoroutine(RunTutorialCo());
	}

	private IEnumerator RunTutorialCo()
	{
		AggroInputManager.PushController(this);
		yield return new WaitForSeconds(basicControlsIntroDelay);
		yield return AggroManagerBase<DialogueManager>.instance.PlayDialogueCo(welcomeDialogue);
		yield return BasicControlsCo();
		yield return StressCo();
		yield return BoxStuffCo();
		yield return TruckCo();
	}

	private IEnumerator BasicControlsCo()
	{
		yield return AggroManagerBase<DialogueManager>.instance.PlayDialogueCo(basicControlsMoveForwardDialogue);
		yield return BasicControlsMoveForwardCo();
		yield return AggroManagerBase<DialogueManager>.instance.PlayDialogueCo(basicControlsReverseDialogue);
		yield return BasicControlsReverseCo();
		yield return AggroManagerBase<DialogueManager>.instance.PlayDialogueCo(basicControlsDriftDialogue);
		SendShow(TutorialContainer.ContainerType.Boost);
		yield return AggroManagerBase<DialogueManager>.instance.PlayDialogueCo(basicControlsDriftChargingDialogue);
		yield return BasicControlsDriftCo();
		yield return AggroManagerBase<DialogueManager>.instance.PlayDialogueCo(basicControlsNitroDialogue);
		yield return BasicControlsNitroCo();
		SendHide(TutorialContainer.ContainerType.Boost);
		yield return AggroManagerBase<DialogueManager>.instance.PlayDialogueCo(basicControlsOutroDialogue);
		stressMidGateA.Close();
		yield return basicControlGate.OpenCo(cameraPan: true);
		yield return WaitForTriggerCo();
		basicControlGate.Close();
	}

	private IEnumerator BasicControlsMoveForwardCo()
	{
		AggroInputManager.RemoveController(this);
		basicControlsMoveForwardGoal.Show();
		if (GameUtil.TryGetLocalPlayer(out var player))
		{
			VehicleController vc = player.GetObject<VehicleController>();
			float accum = 0f;
			while (accum < basicControlsMoveForwardDuration)
			{
				yield return null;
				accum = ((!(vc.input.acceleration >= basicControlsMoveForwardAccelerationThreshold)) ? 0f : (accum + Time.deltaTime));
				basicControlsMoveForwardGoal.SetTimer(accum / basicControlsMoveForwardDuration);
			}
		}
		basicControlsMoveForwardGoal.Checked();
		yield return new WaitForSeconds(delayAfterChecked);
		basicControlsMoveForwardGoal.Hide();
		AggroInputManager.PushController(this);
	}

	private IEnumerator BasicControlsReverseCo()
	{
		AggroInputManager.RemoveController(this);
		basicControlsReverseGoal.Show();
		if (GameUtil.TryGetLocalPlayer(out var player))
		{
			VehicleController vc = player.GetObject<VehicleController>();
			float accum = 0f;
			while (accum < basicControlsReverseDuration)
			{
				yield return null;
				accum = ((!(vc.input.acceleration <= basicControlsReverseAccelerationThreshold)) ? 0f : (accum + Time.deltaTime));
				basicControlsReverseGoal.SetTimer(accum / basicControlsReverseDuration);
			}
		}
		basicControlsReverseGoal.Checked();
		yield return new WaitForSeconds(delayAfterChecked);
		basicControlsReverseGoal.Hide();
		AggroInputManager.PushController(this);
	}

	private IEnumerator BasicControlsDriftCo()
	{
		AggroInputManager.RemoveController(this);
		basicControlsDriftGoal.Show();
		if (GameUtil.TryGetLocalPlayer(out var player))
		{
			VehicleController vc = player.GetObject<VehicleController>();
			float accum = 0f;
			while (accum < basicControlsDriftDuration)
			{
				yield return null;
				accum = ((!vc.drifting) ? 0f : (accum + Time.deltaTime));
				basicControlsDriftGoal.SetTimer(accum / basicControlsDriftDuration);
			}
		}
		basicControlsDriftGoal.Checked();
		yield return new WaitForSeconds(delayAfterChecked);
		basicControlsDriftGoal.Hide();
		AggroInputManager.PushController(this);
	}

	private IEnumerator BasicControlsNitroCo()
	{
		AggroInputManager.RemoveController(this);
		basicControlsNitroGoal.Show();
		if (GameUtil.TryGetLocalPlayer(out var player))
		{
			NitroController nitro = player.GetObject<NitroController>();
			while (!nitro.nitroActiveSync)
			{
				yield return null;
			}
		}
		basicControlsNitroGoal.Checked();
		yield return new WaitForSeconds(delayAfterChecked);
		basicControlsNitroGoal.Hide();
		AggroInputManager.PushController(this);
	}

	private IEnumerator StressCo()
	{
		stressMidGateB.Open();
		yield return AggroManagerBase<DialogueManager>.instance.PlayDialogueCo(stressCollisionPreDialogue);
		stressMidGateA.Open();
		yield return StressCollisionCo();
		stressMidGateA.Close();
		stressMidGateB.Close();
		yield return AggroManagerBase<DialogueManager>.instance.PlayDialogueCo(stressCollisionPostDialogue);
		SendShow(TutorialContainer.ContainerType.Stress);
		yield return AggroManagerBase<DialogueManager>.instance.PlayDialogueCo(stressBarExplainDialogue);
		SendHide(TutorialContainer.ContainerType.Stress);
		yield return AggroManagerBase<DialogueManager>.instance.PlayDialogueCo(stressCrashOutPreDialogue);
		GameUtil.GetLocalPlayer().GetObject<PlayerStress>().TutorialFinishedWithStress();
		AggroInputManager.RemoveController(this);
		yield return new WaitForSeconds(stressCrashOutDelayBeforeBombsEarly);
		SendSpawn(TutorialSpawn.SpawnType.BombsEarly);
		yield return new WaitForSeconds(stressCrashOutDelayBeforeBombsLate);
		SendSpawn(TutorialSpawn.SpawnType.BombsLate);
		yield return new WaitForSeconds(stressCrashOutDelayBeforeDialogue);
		yield return AggroManagerBase<DialogueManager>.instance.PlayDialogueCo(stressCrashOutPostDialogue);
		yield return AggroManagerBase<DialogueManager>.instance.PlayDialogueCo(stressOutroDialogue);
		AggroInputManager.PushController(this);
		yield return stressGate.OpenCo();
		yield return WaitForTriggerCo();
		stressGate.Close();
	}

	private IEnumerator StressCollisionCo()
	{
		AggroInputManager.RemoveController(this);
		stressCollisionGoal.Show();
		stressBooststrip.tutorialBoostStripUsed = false;
		while (!stressBooststrip.tutorialBoostStripUsed)
		{
			yield return null;
		}
		GameUtil.GetLocalPlayer().GetObject<PlayerStress>().TutorialPrepareForStress();
		stressCollisionGoal.Hide();
		AggroInputManager.PushController(this);
		yield return WaitForTriggerCo(releaseControl: false);
		stressCollisionGoal.Checked();
		yield return new WaitForSeconds(delayAfterChecked);
	}

	private IEnumerator BoxStuffCo()
	{
		yield return AggroManagerBase<CameraController>.instance.SetFocusPositionCo(boxCameraTransform.position, trucksCameraPanDuration);
		yield return AggroManagerBase<DialogueManager>.instance.PlayDialogueCo(boxStuffIntroDialogue);
		yield return AggroManagerBase<CameraController>.instance.SetFocusPositionCo(GameUtil.GetLocalPlayer().transform.position, trucksCameraPanDuration);
		AggroManagerBase<CameraController>.instance.FollowPlayer();
		yield return AggroManagerBase<DialogueManager>.instance.PlayDialogueCo(boxStuffStackTwoDialogue);
		yield return BoxStuffStackTwoCo();
		yield return AggroManagerBase<DialogueManager>.instance.PlayDialogueCo(boxStuffStackThreeDialogue);
		yield return BoxStuffStackThreeCo();
		yield return AggroManagerBase<DialogueManager>.instance.PlayDialogueCo(boxStuffUnstackDialogue);
		yield return BoxStuffUnstackCo();
		yield return AggroManagerBase<DialogueManager>.instance.PlayDialogueCo(boxStuffOutroDialogue);
		yield return boxStuffGate.OpenCo(cameraPan: true);
		yield return WaitForTriggerCo();
		boxStuffGate.Close();
	}

	private IEnumerator BoxStuffStackTwoCo()
	{
		AggroInputManager.RemoveController(this);
		boxStuffStackTwoGoal.Show();
		int stackCount = 1;
		while (stackCount < 2)
		{
			yield return null;
			for (int i = 0; i < boxStuffBoxes.Length; i++)
			{
				stackCount = Mathf.Max(boxStuffBoxes[i].GetEntity().GetObject<Grabbable>().GetStackCount(), stackCount);
			}
		}
		boxStuffStackTwoGoal.Checked();
		yield return new WaitForSeconds(delayAfterChecked);
		boxStuffStackTwoGoal.Hide();
		AggroInputManager.PushController(this);
	}

	private IEnumerator BoxStuffStackThreeCo()
	{
		AggroInputManager.RemoveController(this);
		boxStuffStackThreeGoal.Show();
		int stackCount = 1;
		while (stackCount < 3)
		{
			yield return null;
			for (int i = 0; i < boxStuffBoxes.Length; i++)
			{
				stackCount = Mathf.Max(boxStuffBoxes[i].GetEntity().GetObject<Grabbable>().GetStackCount(), stackCount);
			}
		}
		boxStuffStackThreeGoal.Checked();
		yield return new WaitForSeconds(delayAfterChecked);
		boxStuffStackThreeGoal.Hide();
		AggroInputManager.PushController(this);
	}

	private IEnumerator BoxStuffUnstackCo()
	{
		AggroInputManager.RemoveController(this);
		boxStuffStackUnstackGoal.Show();
		if (!BoxStuffAllInStack())
		{
			BoxStuffRestackBoxes();
		}
		BoxStuffSetTutorialCheck();
		bool isStacked = true;
		while (isStacked)
		{
			yield return null;
			if (BoxStuffWasStackBroken())
			{
				yield return AggroManagerBase<DialogueManager>.instance.PlayDialogueCo(boxStuffIncorrectUnstackingDialogue);
				BoxStuffRestackBoxes();
				BoxStuffSetTutorialCheck();
			}
			else if (BoxStuffAllOutOfStack())
			{
				isStacked = false;
			}
		}
		boxStuffStackUnstackGoal.Checked();
		yield return new WaitForSeconds(delayAfterChecked);
		boxStuffStackUnstackGoal.Hide();
		AggroInputManager.PushController(this);
	}

	private IEnumerator TruckCo()
	{
		NetworkAggroManagerBase<WarehouseManager>.instance.TutorialSetOrders(trucksOutboundOrders);
		yield return AggroManagerBase<DialogueManager>.instance.PlayDialogueCo(trucksIntroDialogue);
		yield return AggroManagerBase<CameraController>.instance.SetFocusPositionCo(trucksInboundLoc.position, trucksCameraPanDuration);
		trucksInboundBay.ServerBringInOrders(trucksInboundOrders, Hash.Calculate("AggroCrab"));
		yield return AggroManagerBase<DialogueManager>.instance.PlayDialogueCo(trucksIncomingDialogue);
		yield return AggroManagerBase<CameraController>.instance.SetFocusPositionCo(trucksTimerCameraLoc.position, trucksCameraPanDuration);
		trucksOutboundBay.ServerSetOutboundOrder(trucksOutboundOrders);
		yield return AggroManagerBase<DialogueManager>.instance.PlayDialogueCo(trucksOutgoingDialogue);
		yield return AggroManagerBase<CameraController>.instance.SetFocusPositionCo(GameUtil.GetLocalPlayer().transform.position, trucksCameraPanDuration);
		AggroManagerBase<CameraController>.instance.FollowPlayer();
		AggroInputManager.RemoveController(this);
		trucksGoal.Show();
		while (!trucksOutboundBay.tutorialOutboundSent)
		{
			yield return null;
		}
		trucksGoal.Checked();
		yield return new WaitForSeconds(delayAfterChecked);
		trucksGoal.Hide();
		AggroInputManager.PushController(this);
		yield return AggroManagerBase<CameraController>.instance.SetFocusPositionCo(trucksTimerCameraLoc.position, trucksCameraPanDuration);
		yield return tutorialTimerHandler.TutorialStartTimerDemoCo();
		yield return AggroManagerBase<DialogueManager>.instance.PlayDialogueCo(trucksOutroDialogue);
		GameManager.Next(GameNextType.QuitTitle);
	}

	private bool BoxStuffAllInStack()
	{
		for (int i = 0; i < boxStuffBoxes.Length; i++)
		{
			if (!boxStuffBoxes[i].GetEntity().GetObject<Grabbable>().isInStack)
			{
				return false;
			}
		}
		return true;
	}

	private bool BoxStuffAllOutOfStack()
	{
		for (int i = 0; i < boxStuffBoxes.Length; i++)
		{
			if (boxStuffBoxes[i].GetEntity().GetObject<Grabbable>().isInStack)
			{
				return false;
			}
		}
		return true;
	}

	private bool BoxStuffWasStackBroken()
	{
		for (int i = 0; i < boxStuffBoxes.Length; i++)
		{
			if (boxStuffBoxes[i].GetEntity().GetObject<Grabbable>().tutorialStackBroken)
			{
				return true;
			}
		}
		return false;
	}

	private void BoxStuffRestackBoxes()
	{
		Vector3 vector = Vector3.zero;
		float num = float.MinValue;
		Vector3 position = GameUtil.GetLocalPlayer().transform.position;
		for (int i = 0; i < boxStuffRespawnPositions.Length; i++)
		{
			Vector3 position2 = boxStuffRespawnPositions[i].position;
			float num2 = math.distancesq(position2, position);
			if (num2 > num)
			{
				vector = position2;
				num = num2;
			}
		}
		Grabbable grabbable = boxStuffBoxes[0].GetEntity().GetObject<Grabbable>();
		if (grabbable.isInStack)
		{
			grabbable.ServerBreakEntireStack();
		}
		for (int j = 1; j < boxStuffBoxes.Length; j++)
		{
			Grabbable grabbable2 = boxStuffBoxes[j].GetEntity().GetObject<Grabbable>();
			if (grabbable2.isInStack)
			{
				grabbable2.ServerBreakEntireStack();
			}
			grabbable.ServerAddToStack(grabbable2);
		}
		grabbable.ServerFixStack(new Vector3(vector.x, 0.5f, vector.z), Vector3.zero, Quaternion.identity);
	}

	private void BoxStuffSetTutorialCheck()
	{
		for (int i = 0; i < boxStuffBoxes.Length; i++)
		{
			boxStuffBoxes[i].GetEntity().GetObject<Grabbable>().tutorialStackBroken = false;
		}
	}

	private IEnumerator WaitForTriggerCo(bool releaseControl = true)
	{
		if (releaseControl)
		{
			AggroInputManager.RemoveController(this);
		}
		_trigger = false;
		while (!_trigger)
		{
			yield return null;
		}
		if (releaseControl)
		{
			AggroInputManager.PushController(this);
		}
	}

	public void TutorialTriggerEntered()
	{
		_trigger = true;
	}

	private void SendSpawn(TutorialSpawn.SpawnType type)
	{
		_spawnQuery.Run();
		for (int i = 0; i < _spawnQuery.count; i++)
		{
			_spawnQuery[i].CheckSpawn(type);
		}
	}

	private void SendShow(TutorialContainer.ContainerType type)
	{
		_containerQuery.Run();
		for (int i = 0; i < _containerQuery.count; i++)
		{
			_containerQuery[i].CheckShow(type);
		}
	}

	private void SendHide(TutorialContainer.ContainerType type)
	{
		_containerQuery.Run();
		for (int i = 0; i < _containerQuery.count; i++)
		{
			_containerQuery[i].CheckHide(type);
		}
	}

	public void OnInputControlGained()
	{
	}

	public void OnInputControlLost()
	{
		foreach (InputAction item in AggroInputManager.input.Game.Get())
		{
			item.Reset();
		}
	}
}
