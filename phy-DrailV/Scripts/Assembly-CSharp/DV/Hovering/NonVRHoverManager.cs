using DV.Signs;
using DV.UI;
using DV.Utils;
using UnityEngine;

namespace DV.Hovering
{
	public class NonVRHoverManager : SingletonBehaviour<NonVRHoverManager>
	{
		public enum HoverType
		{
			None = 0,
			Train = 1,
			Turntable = 2,
			WarehouseMachine = 3,
			Sign = 4
		}

		public delegate void HoverChangedDelegate(HoverType type, object obj, bool hovered);

		private const float MAX_DISTANCE = 2000f;

		private static Layers.DVLayerMask TurntableLayerMask = Layers.DVLayerMask.Ignore_Raycast;

		private static Layers.DVLayerMask SignLayerMask = Layers.DVLayerMask.Train_Walkable | Layers.DVLayerMask.Laser_Pointer_Target;

		private static Layers.DVLayerMask WarehouseMachineLayerMask = Layers.DVLayerMask.Default;

		private static Layers.DVLayerMask TrainLayerMask = Layers.DVLayerMask.Train_Big_Collider;

		private static Layers.DVLayerMask AllLayers = TrainLayerMask | TurntableLayerMask | WarehouseMachineLayerMask | SignLayerMask | Layers.DVLayerMask.Grabbed_Item | Layers.DVLayerMask.World_Item | Layers.DVLayerMask.Interactable | Layers.DVLayerMask.Inventory;

		private GameParams gameParams;

		public (HoverType type, object obj) CurrentlyHovered { get; private set; }

		public event HoverChangedDelegate HoverChanged;

		public new static string AllowAutoCreate()
		{
			return "[NonVRHoverManager]";
		}

		private void Start()
		{
			if (VRManager.IsVREnabled())
			{
				Debug.LogError("NonVRHoverManager shouldn't be called in VR, something is wrong!");
			}
			gameParams = Globals.G.GameParams;
			SingletonBehaviour<ScreenspaceMouse>.Instance.ValueChanged += ScreenspaceChanged;
			base.enabled = SingletonBehaviour<ScreenspaceMouse>.Instance.on;
		}

		protected override void OnDestroy()
		{
			base.OnDestroy();
			if (!UnloadWatcher.isUnloading)
			{
				SingletonBehaviour<ScreenspaceMouse>.Instance.ValueChanged -= ScreenspaceChanged;
			}
		}

		private void ScreenspaceChanged(bool on)
		{
			base.enabled = on;
			if (CurrentlyHovered.type != HoverType.None)
			{
				(HoverType, object) currentlyHovered = CurrentlyHovered;
				CurrentlyHovered = (type: HoverType.None, obj: null);
				this.HoverChanged?.Invoke(currentlyHovered.Item1, currentlyHovered.Item2, hovered: false);
				this.HoverChanged?.Invoke(CurrentlyHovered.type, CurrentlyHovered.obj, hovered: true);
			}
		}

		private void Update()
		{
			Camera activeCamera = PlayerManager.ActiveCamera;
			if ((bool)activeCamera)
			{
				(HoverType, object) tuple = Scan(activeCamera.ScreenPointToRay(Input.mousePosition));
				if (tuple.Item2 != CurrentlyHovered.obj)
				{
					(HoverType, object) currentlyHovered = CurrentlyHovered;
					CurrentlyHovered = (type: tuple.Item1, obj: tuple.Item2);
					this.HoverChanged?.Invoke(currentlyHovered.Item1, currentlyHovered.Item2, hovered: false);
					this.HoverChanged?.Invoke(CurrentlyHovered.type, CurrentlyHovered.obj, hovered: true);
				}
			}
		}

		private (HoverType type, object obj) Scan(Ray ray)
		{
			if (!CursorManager.Visible)
			{
				return (type: HoverType.None, obj: null);
			}
			if ((bool)SingletonBehaviour<PlayerCameraSwitcher>.Instance && SingletonBehaviour<PlayerCameraSwitcher>.Instance.externalCamera.PhotoMode)
			{
				return (type: HoverType.None, obj: null);
			}
			PhysicsQueryBuilder.QueryResults queryResults = PhysicsQueryBuilder.Raycast(ray.origin, ray.direction, 2000f, AllLayers.ToLayerMask(), QueryTriggerInteraction.Collide);
			for (int i = 0; i < queryResults.Length; i++)
			{
				RaycastHitDV hit = queryResults[i];
				int layer = hit.collider.gameObject.layer;
				if (layer == Layers.DVLayer.Train_Walkable.ToInt())
				{
					if (!hit.collider.TryGetComponent<TeleportArcPassThrough>(out var component) || !component.ShouldIgnoreCollidersForHit(hit))
					{
						break;
					}
				}
				else if (layer != Layers.DVLayer.World_Item.ToInt() || !hit.collider.GetComponent<PlugSocket>())
				{
					if (layer == Layers.DVLayer.World_Item.ToInt() || layer == Layers.DVLayer.Grabbed_Item.ToInt())
					{
						return (type: HoverType.None, obj: null);
					}
					if (layer == Layers.DVLayer.Interactable.ToInt())
					{
						return (type: HoverType.None, obj: null);
					}
					if (layer != Layers.DVLayer.Inventory.ToInt())
					{
						break;
					}
					return (type: HoverType.None, obj: null);
				}
			}
			if ((bool)SingletonBehaviour<PlayerCameraSwitcher>.Instance && SingletonBehaviour<PlayerCameraSwitcher>.Instance.currentView == PlayerCameraSwitcher.CameraView.External)
			{
				for (int j = 0; j < queryResults.Length; j++)
				{
					RaycastHitDV raycastHitDV = queryResults[j];
					if (raycastHitDV.collider.gameObject.layer.IsLayerPartOfMask(TrainLayerMask))
					{
						TrainCar trainCar = TrainCar.Resolve(raycastHitDV.collider.gameObject);
						if ((bool)trainCar)
						{
							return (type: HoverType.Train, obj: trainCar);
						}
					}
				}
			}
			for (int k = 0; k < queryResults.Length; k++)
			{
				RaycastHitDV raycastHitDV2 = queryResults[k];
				if (raycastHitDV2.collider.gameObject.layer.IsLayerPartOfMask(WarehouseMachineLayerMask) && !raycastHitDV2.collider.isTrigger)
				{
					WarehouseMachineController componentInParent = raycastHitDV2.collider.transform.GetComponentInParent<WarehouseMachineController>();
					if ((bool)componentInParent)
					{
						return (type: HoverType.WarehouseMachine, obj: componentInParent);
					}
				}
			}
			if (gameParams.RemoteSignReadingAllowed)
			{
				for (int l = 0; l < queryResults.Length; l++)
				{
					RaycastHitDV hit2 = queryResults[l];
					if (!hit2.collider.gameObject.layer.IsLayerPartOfMask(SignLayerMask))
					{
						continue;
					}
					if (hit2.collider.gameObject.layer == Layers.DVLayer.Train_Walkable.ToInt())
					{
						if (!hit2.collider.TryGetComponent<TeleportArcPassThrough>(out var component2) || !component2.ShouldIgnoreCollidersForHit(hit2))
						{
							break;
						}
						continue;
					}
					SignHover component3 = hit2.collider.GetComponent<SignHover>();
					if ((bool)component3)
					{
						JunctionSwitchRemoteControllable component4 = component3.GetComponent<JunctionSwitchRemoteControllable>();
						Junction junction = ((component4 != null) ? component4.VisualSwitch.junction : null);
						bool flag = junction != null;
						if ((!flag && Vector3.Dot(component3.transform.forward, ray.direction) > 0f) || (flag && !SingletonBehaviour<JunctionSwitcherManager>.Instance.IsSwitchingAllowed(junction)))
						{
							break;
						}
						return (type: HoverType.Sign, obj: component3);
					}
				}
			}
			for (int m = 0; m < queryResults.Length; m++)
			{
				if (!gameParams.LocoHUDAllowed)
				{
					break;
				}
				RaycastHitDV raycastHitDV3 = queryResults[m];
				if (raycastHitDV3.collider.gameObject.layer.IsLayerPartOfMask(TurntableLayerMask) && raycastHitDV3.collider.isTrigger)
				{
					TurntableControlKeyboardInput componentInParent2 = raycastHitDV3.collider.transform.GetComponentInParent<TurntableControlKeyboardInput>();
					if ((bool)componentInParent2)
					{
						return (type: HoverType.Turntable, obj: componentInParent2);
					}
				}
			}
			queryResults = PhysicsQueryBuilder.OverlapSphere(ray.origin, 0.01f, TurntableLayerMask.ToLayerMask(), QueryTriggerInteraction.Collide);
			for (int n = 0; n < queryResults.Length; n++)
			{
				RaycastHitDV raycastHitDV4 = queryResults[n];
				if (raycastHitDV4.collider.isTrigger)
				{
					TurntableControlKeyboardInput componentInParent3 = raycastHitDV4.collider.transform.GetComponentInParent<TurntableControlKeyboardInput>();
					if ((bool)componentInParent3)
					{
						return (type: HoverType.Turntable, obj: componentInParent3);
					}
				}
			}
			return (type: HoverType.None, obj: null);
		}
	}
}
