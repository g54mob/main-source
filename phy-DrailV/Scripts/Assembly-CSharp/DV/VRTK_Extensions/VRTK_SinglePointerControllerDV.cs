using System;
using System.Collections.Generic;
using System.Linq;
using DV.UI;
using DV.Utils;
using UnityEngine;
using UnityEngine.EventSystems;
using VRTK;

namespace DV.VRTK_Extensions
{
	public class VRTK_SinglePointerControllerDV : SingletonBehaviour<VRTK_SinglePointerControllerDV>
	{
		private VRTK_SinglePointerDV activePointer;

		private readonly RequestSystem requestSystem = new RequestSystem(0f);

		private readonly RequestSystem onlyWhenHitSystem = new RequestSystem(0f);

		private readonly List<VRTK_SinglePointerDV> registeredPointers = new List<VRTK_SinglePointerDV>();

		private Vector3 invalidPointerPosition = new Vector3(-1f, -1f, 0f);

		public VRTK_SinglePointerDV ActivePointer
		{
			get
			{
				return activePointer;
			}
			set
			{
				if (!(activePointer == value))
				{
					activePointer = value;
					this.ActivePointerChanged?.Invoke();
				}
			}
		}

		public bool PointerRequested => requestSystem.Value > 0.5f;

		public bool OnlyShowWhenHit => onlyWhenHitSystem.Value > 0.5f;

		public SDK_BaseController.ControllerHand ActivePointerHand
		{
			get
			{
				if (!(ActivePointer == null))
				{
					return VRTK_DeviceFinder.GetControllerHand(ActivePointer.gameObject);
				}
				return SDK_BaseController.ControllerHand.None;
			}
		}

		public event Action ActivePointerChanged;

		public new static string AllowAutoCreate()
		{
			return "[VRTK_SinglePointerControllerDV]";
		}

		protected override void Awake()
		{
			base.Awake();
			SingletonBehaviour<CursorManager>.Instance.SetPointerPositionOverrideMethod(PointerPositionOverride);
			requestSystem.ValueChanged += delegate(float value)
			{
				bool flag = value > 0.5f;
				if (ActivePointer != null)
				{
					ActivePointer.TogglePointer(flag);
				}
				else if (flag && registeredPointers.Count > 0)
				{
					ActivePointer = registeredPointers[0];
					ActivePointer.TogglePointer(on: true);
				}
			};
		}

		private Vector3 PointerPositionOverride()
		{
			if (!PointerRequested || ActivePointer == null)
			{
				return invalidPointerPosition;
			}
			VRTK_UIPointer relatedPointer = activePointer.relatedPointer;
			if (relatedPointer == null)
			{
				Debug.LogWarning("VRTK_SinglePointerControllerDV: pointer is null, returning invalid position", base.gameObject);
				return invalidPointerPosition;
			}
			PointerEventData pointerEventData = relatedPointer.pointerEventData;
			if (pointerEventData == null)
			{
				Debug.LogWarning("VRTK_SinglePointerControllerDV: pointer event data is null, returning invalid position", base.gameObject);
				return invalidPointerPosition;
			}
			return pointerEventData.position;
		}

		public void Register(VRTK_SinglePointerDV pointer)
		{
			SanitizeList();
			if (!registeredPointers.Contains(pointer))
			{
				registeredPointers.Add(pointer);
				if (PointerRequested && registeredPointers.Count == 1)
				{
					ActivePointer = pointer;
					ActivePointer.TogglePointer(on: true);
				}
			}
		}

		public void Unregister(VRTK_SinglePointerDV pointer)
		{
			SanitizeList();
			if (registeredPointers.Remove(pointer) && pointer == ActivePointer)
			{
				ActivePointer.TogglePointer(on: false);
				if (registeredPointers.Count > 0)
				{
					ActivePointer = registeredPointers[0];
					ActivePointer.TogglePointer(PointerRequested);
				}
				else
				{
					ActivePointer = null;
				}
			}
		}

		private void SanitizeList()
		{
			int num = registeredPointers.Count((VRTK_SinglePointerDV x) => x == null);
			if (num > 0)
			{
				Debug.LogWarning(string.Format("{0}: {1} null pointers in list", "VRTK_SinglePointerControllerDV", num), base.gameObject);
			}
			registeredPointers.RemoveAll((VRTK_SinglePointerDV p) => p == null);
		}

		public void MakeActive(VRTK_SinglePointerDV pointer)
		{
			if (!(pointer == ActivePointer))
			{
				if (ActivePointer != null)
				{
					ActivePointer.TogglePointer(on: false);
				}
				ActivePointer = pointer;
				ActivePointer.TogglePointer(on: true);
				if (!registeredPointers.Contains(pointer))
				{
					Register(pointer);
				}
			}
		}

		public void RequestPointerState(object caller, bool state, bool onlyWhenHit = false)
		{
			if (state)
			{
				requestSystem.RequestValue(caller, 1f);
				if (onlyWhenHit)
				{
					onlyWhenHitSystem.RequestValue(caller, 1f);
				}
			}
			else
			{
				requestSystem.RemoveValue(caller);
				if (onlyWhenHit)
				{
					onlyWhenHitSystem.RemoveValue(caller);
				}
			}
		}

		public void RequestPointerState(object caller, SDK_BaseController.ControllerHand hand, bool enablePointer)
		{
			if (!enablePointer)
			{
				RequestPointerState(caller, state: false);
				return;
			}
			VRTK_SinglePointerDV vRTK_SinglePointerDV = registeredPointers.FirstOrDefault((VRTK_SinglePointerDV p) => VRTK_DeviceFinder.GetControllerHand(p.gameObject) == hand);
			if (vRTK_SinglePointerDV != null)
			{
				MakeActive(vRTK_SinglePointerDV);
			}
			else
			{
				Debug.LogError(string.Format("{0}: pointer requested for hand {1} but no pointers were registered for that hand", "VRTK_SinglePointerControllerDV", hand), base.gameObject);
			}
			RequestPointerState(caller, state: true);
		}
	}
}
