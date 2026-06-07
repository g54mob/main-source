using System.Collections.Generic;
using Assets.Nimbatus.Scripts.Controls.Keybinds;
using Assets.Nimbatus.Scripts.Persistence;
using Assets.Nimbatus.Scripts.WorldObjects.Items.DataModel;
using Assets.Nimbatus.Scripts.WorldObjects.Items.Selection;

namespace Assets.Nimbatus.Scripts.WorldObjects.Items.DroneParts
{
	public class UndoManager : BaseSingleton<UndoManager>
	{
		public enum EStoreReason
		{
			None = 0,
			Place = 1,
			Delete = 2,
			Rotate = 3,
			KeyBind = 4,
			DistanceSensor = 5,
			DistanceSensorRange = 6,
			SpeedSensor = 7,
			ImpulseGiverPauseTime = 8,
			ImpulseGiverActiveTime = 9,
			GravitySensorTolerance = 10,
			GravitySensorTarget = 11,
			LedColor = 12,
			FlipVertical = 13,
			FlipHorizontal = 14,
			MagnetRadius = 15,
			MagnetStrength = 16,
			SpringStrength = 17,
			AddStringBinding = 18,
			WeaponRotation = 19,
			BufferPartTime = 20,
			TemperatureSensorTolerance = 21,
			DroneComponentCoating = 22,
			TemperatureRegulatorStrength = 23,
			AltimeterTolerance = 24,
			AltimeterHeight = 25,
			TemperatureRegulatorRadius = 26,
			DroneSkin = 27,
			DynamicThrusterForceChange = 28,
			DynamicThrusterStartForce = 29,
			TriggerImpulsePartDelay = 30,
			TriggerImpulsePartActiveTime = 31,
			FactoryPartStartState = 32,
			MotorizedHingeSpeed = 33,
			DelayPartTime = 34,
			ProximitySensorRange = 35,
			ProximitySensorAngle = 36,
			RngGateProbability = 37,
			VtolThrusterTarget = 38,
			VtolThrusterSpeed = 39,
			VtolRotationMode = 40,
			ExplosionRadius = 41,
			ReplaceItem = 42,
			DroneSkinRotation = 43,
			PistonDistance = 44,
			PistonSpeed = 45,
			RotatingMeleeWeaponMode = 46,
			FlipperAngle = 47,
			FlipperSpeed = 48,
			TemperatureProbeRange = 49,
			TemperatureProbeDetection = 50,
			TemperatureProbeMin = 51,
			TemperatureProbeMax = 52,
			GravitySensorTargetFallback = 53,
			VtolThrusterTargetFallback = 54,
			FlipSkinX = 55,
			FlipSkinY = 56,
			SkinPivotX = 57,
			SkinPivotY = 58,
			AudioPartSound = 59,
			AudioPartVolume = 60,
			AudioPartPitch = 61,
			AudioPartLoopMode = 62,
			AudioPartSpatial = 63,
			HideSensor = 64,
			SkinZOrder = 65,
			WheelSpeed = 66,
			WheelRadius = 67,
			WheelTyre = 68,
			HookStrength = 69,
			BallastTankWeight = 70,
			SpringLock = 71,
			HookTarget = 72
		}

		private class UndoItem
		{
			public NimbatusItemData DroneData;

			public EStoreReason Reason;

			public DronePart DronePart;

			public List<string> SelectedParts;
		}

		private static readonly LinkedList<UndoItem> UndoStack = new LinkedList<UndoItem>();

		private static readonly LinkedList<UndoItem> RedoStack = new LinkedList<UndoItem>();

		public void Update()
		{
			if (!(DronePartManager.Instance == null) && !(DronePartManager.Instance.ActiveDrone == null))
			{
				if (BaseSingleton<KeybindManager>.Instance.GetKeyDown(EKeybinding.Redo))
				{
					Redo();
				}
				if (BaseSingleton<KeybindManager>.Instance.GetKeyDown(EKeybinding.Undo))
				{
					Undo();
				}
			}
		}

		public void Reset()
		{
			UndoStack.Clear();
			RedoStack.Clear();
		}

		public void Store(EStoreReason reason = EStoreReason.None, DronePart part = null)
		{
			if (DronePartManager.Instance == null || DronePartManager.Instance.ActiveDrone == null)
			{
				return;
			}
			NimbatusItemData droneData = DronePartManager.Instance.ActiveDrone.RootDronePart.GenerateData();
			List<string> list = new List<string>();
			foreach (DronePart selectedItem in ItemSelector.SelectedItems)
			{
				list.Add(selectedItem.PersistentId);
			}
			UndoItem value = new UndoItem
			{
				DroneData = droneData,
				Reason = reason,
				DronePart = part,
				SelectedParts = list
			};
			bool flag = true;
			if (UndoStack.Count > 0 && reason != EStoreReason.None && UndoStack.Last.Value.Reason == reason && part != null && UndoStack.Last.Value.DronePart == part)
			{
				UndoStack.Last.Value = value;
				flag = false;
			}
			if (flag)
			{
				UndoStack.AddLast(value);
			}
			RedoStack.Clear();
			if (UndoStack.Count > 100)
			{
				UndoStack.RemoveFirst();
			}
		}

		public void Undo()
		{
			if (!(DronePartManager.Instance == null) && !(DronePartManager.Instance.ActiveDrone == null) && UndoStack.Count > 1)
			{
				LinkedListNode<UndoItem> previous = UndoStack.Last.Previous;
				if (previous != null && previous.Value != null)
				{
					LinkedListNode<UndoItem> last = UndoStack.Last;
					UndoStack.RemoveLast();
					Restore(previous.Value);
					RedoStack.AddLast(last.Value);
				}
			}
		}

		public void Redo()
		{
			if (!(DronePartManager.Instance == null) && !(DronePartManager.Instance.ActiveDrone == null) && RedoStack.Count > 0)
			{
				LinkedListNode<UndoItem> last = RedoStack.Last;
				if (last != null && last.Value != null)
				{
					RedoStack.RemoveLast();
					Restore(last.Value);
					UndoStack.AddLast(last.Value);
				}
			}
		}

		private void Restore(UndoItem item)
		{
			DronePartManager.Instance.ActiveDrone.InitRootDronePart(item.DroneData);
			if (item.SelectedParts.Count <= 0)
			{
				return;
			}
			ItemSelector.Reset();
			foreach (string selectedPart in item.SelectedParts)
			{
				DronePart part = null;
				DronePartManager.Instance.ActiveDrone.RootDronePart.FindDronePartWithId(out part, selectedPart);
				if (part != null)
				{
					ItemSelector.Select(part);
				}
			}
		}
	}
}
