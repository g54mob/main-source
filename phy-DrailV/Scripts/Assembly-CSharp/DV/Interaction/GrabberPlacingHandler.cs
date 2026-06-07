using System.Collections;
using DV.Interaction.Inputs;
using DV.InventorySystem;
using DV.Player;
using DV.UI;
using DV.UI.Inventory;
using DV.Utils;
using UnityEngine;

namespace DV.Interaction
{
	public class GrabberPlacingHandler : MonoBehaviour, ItemPositionController.IPositionProvider
	{
		private const float HIDE_DISTANCE = 0.5f;

		private const float PLACING_LERP_SPEED = 0.1f;

		public ItemPositionController itemPositionController;

		private IItemPlacerHandler placerHandler;

		private bool isPlacing;

		private float placingLerpValue;

		private GrabberInteractionHandlerDV interactionHandler;

		private Grabber grabber;

		private IPlayerRig playerRig;

		public int Priority => 1;

		private void Awake()
		{
			grabber = GetComponent<Grabber>();
			interactionHandler = GetComponent<GrabberInteractionHandlerDV>();
			placerHandler = GetComponentInChildren<IItemPlacerHandler>();
		}

		private IEnumerator Start()
		{
			while (SingletonBehaviour<HotbarController>.Instance == null || !SingletonBehaviour<HotbarController>.Instance.LoadingFinished)
			{
				yield return null;
			}
			playerRig = PlayerManager.PlayerTransform.GetComponentInChildren<IPlayerRig>();
			SetupListeners(on: true);
		}

		private void OnDestroy()
		{
			if (!UnloadWatcher.isUnloading)
			{
				itemPositionController.Remove(this);
				SetupListeners(on: false);
			}
		}

		private void SetupListeners(bool on)
		{
			if (on)
			{
				grabber.GrabStopped += OnGrabStopped;
				SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.ElementToggled += CancelPlacing;
				SingletonBehaviour<HotbarController>.Instance.OpenChanged += CancelPlacing;
				SingletonBehaviour<AppUtil>.Instance.FocusChanged += CancelPlacing;
			}
			else
			{
				SingletonBehaviour<ACanvasController<CanvasController.ElementType>>.Instance.ElementToggled -= CancelPlacing;
				SingletonBehaviour<HotbarController>.Instance.OpenChanged -= CancelPlacing;
				SingletonBehaviour<AppUtil>.Instance.FocusChanged -= CancelPlacing;
			}
		}

		private void Update()
		{
			if (InputManager.NewPlayer.GetButtonDown(InputManager.Actions.Place) && (bool)grabber.CurrentItemHeld && !interactionHandler.IsHoldingLocked)
			{
				isPlacing = true;
				itemPositionController.Add(this);
				placingLerpValue = 0f;
				interactionHandler.LockHolding();
				placerHandler.InitializePlacement();
			}
			if (isPlacing && InputManager.NewPlayer.GetButton(InputManager.Actions.Place))
			{
				placingLerpValue = Mathf.MoveTowards(placingLerpValue, 1f, Time.deltaTime / 0.1f);
				placerHandler.UpdatePlacement();
			}
			if (isPlacing && InputManager.NewPlayer.GetButtonUp(InputManager.Actions.Place))
			{
				StopPlacing(finished: true);
			}
			if (placingLerpValue != 0f && !InputManager.NewPlayer.GetButton(InputManager.Actions.Place))
			{
				placingLerpValue = Mathf.MoveTowards(placingLerpValue, 0f, Time.deltaTime / 0.1f);
				if (placingLerpValue == 0f)
				{
					itemPositionController.Remove(this);
				}
			}
		}

		private void CancelPlacing()
		{
			StopPlacing();
		}

		private void CancelPlacing(bool _)
		{
			StopPlacing();
		}

		private void CancelPlacing(ACanvasController<CanvasController.ElementType>.Element obj)
		{
			if (obj.Type == CanvasController.ElementType.Blockers)
			{
				StopPlacing();
			}
		}

		private void OnGrabStopped(AGrabHandler grabHandler)
		{
			if (grabHandler.IsItem && isPlacing)
			{
				StopPlacing();
				grabHandler.transform.position = playerRig.GetAttachPoint().position;
			}
		}

		private void StopPlacing(bool finished = false)
		{
			if (!isPlacing)
			{
				return;
			}
			isPlacing = false;
			interactionHandler.UnlockHolding();
			if (finished)
			{
				(bool, GameObject, GameObject) tuple = placerHandler.FinalizePlacement();
				if (tuple.Item1)
				{
					interactionHandler.RequestDrop();
					AItemContainer aItemContainer = ((tuple.Item3 != null) ? tuple.Item3.GetComponent<AItemContainer>() : null);
					if (aItemContainer != null)
					{
						aItemContainer.AddItem(tuple.Item2, aItemContainer.GetFirstFreeSlot());
					}
				}
			}
			else
			{
				placerHandler.CancelPlacement();
			}
		}

		public (Vector3 pos, Quaternion rot, float overridePreviousPerc) GetPose(Vector3 pos, Quaternion rot)
		{
			return (pos: pos + rot * (Vector3.down * (placingLerpValue * 0.5f)), rot: rot, overridePreviousPerc: 1f);
		}
	}
}
