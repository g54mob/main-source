using System;
using System.Collections.Generic;
using DV.CabControls.NonVR;
using DV.CabControls.Spec;
using DV.CabControls.VRTK;
using UnityEngine;

namespace DV.CabControls
{
	public class ControlsInstantiator : ControlsInstantiatorBase
	{
		private struct Impl
		{
			public Type vr;

			public Type pc;
		}

		private static readonly Dictionary<Type, Impl> TypeMap = new Dictionary<Type, Impl>
		{
			{
				typeof(Lever),
				new Impl
				{
					vr = typeof(LeverVRTK),
					pc = typeof(LeverNonVR)
				}
			},
			{
				typeof(Rotary),
				new Impl
				{
					vr = typeof(RotaryVRTK),
					pc = typeof(RotaryNonVR)
				}
			},
			{
				typeof(Button),
				new Impl
				{
					vr = typeof(ButtonVRTK),
					pc = typeof(ButtonNonVR)
				}
			},
			{
				typeof(Item),
				new Impl
				{
					vr = typeof(ItemVRTK),
					pc = typeof(ItemNonVR)
				}
			},
			{
				typeof(ToggleSwitch),
				new Impl
				{
					vr = typeof(ToggleSwitchVRTK),
					pc = typeof(ToggleSwitchNonVR)
				}
			},
			{
				typeof(Wheel),
				new Impl
				{
					vr = typeof(WheelVRTK),
					pc = typeof(WheelNonVR)
				}
			},
			{
				typeof(Puller),
				new Impl
				{
					vr = typeof(PullerVRTK),
					pc = typeof(PullerNonVR)
				}
			},
			{
				typeof(Gizmo),
				new Impl
				{
					vr = typeof(GizmoVRTK),
					pc = typeof(GizmoNonVR)
				}
			},
			{
				typeof(Touchscreen),
				new Impl
				{
					vr = typeof(TouchscreenVRTK),
					pc = typeof(TouchscreenNonVR)
				}
			},
			{
				typeof(BeltAdjuster),
				new Impl
				{
					vr = typeof(BeltSnapPointAdjuster),
					pc = typeof(BeltSnapPointAdjuster)
				}
			}
		};

		public static void InstantiateCabItems(Transform interiorRoot)
		{
		}

		public override void Spawn(ControlSpec spec)
		{
			try
			{
				Type type = ((!VRManager.IsVREnabled()) ? TypeMap[spec.GetType()].pc : TypeMap[spec.GetType()].vr);
				if (type == null)
				{
					Debug.LogError(string.Concat("ControlsInstantiator couldn't find a corresponding type for '", spec, "'"), spec);
				}
				else
				{
					spec.gameObject.AddComponent(type);
				}
			}
			catch (Exception message)
			{
				Debug.LogError("ControlsInstantiator caught the following exception while spawning a control", spec);
				Debug.LogError(message);
			}
		}

		public static void InstantiateFromPrefab(Transform interiorRoot, Vector3 localPosition, Quaternion localRotation, string prefabName)
		{
		}

		public static void InstantiateFromPrefab(Transform interiorRoot, string anchorName, string prefabName)
		{
			Transform transform = interiorRoot.Find(anchorName);
			if ((bool)transform)
			{
				InstantiateFromPrefab(interiorRoot, transform.localPosition, transform.localRotation, prefabName);
				UnityEngine.Object.Destroy(transform.gameObject);
			}
		}
	}
}
