using System.Collections.Generic;
using MalbersAnimations.Scriptables;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace MalbersAnimations.UI
{
	[DefaultExecutionOrder(501)]
	public class MFloatingNumbers : MonoBehaviour
	{
		public class MDamageableUI
		{
			public MDamageable damageable;

			public Transform followTransform;

			public UnityAction<float> OnValueChange = delegate
			{
			};
		}

		[Tooltip("Runtime Set that store all the DamageNumber you want to monitor")]
		[RequiredField]
		public RuntimeDamageableSet Set;

		[Tooltip("Damage Number Prefab to show the damage float value")]
		[RequiredField]
		public UIFollowTransform DamageNumber;

		[Tooltip("Damage Number Prefab to show the Critical damage float value")]
		[RequiredField]
		public UIFollowTransform CriticalNumber;

		[Tooltip("Reference for the Camera")]
		public TransformReference Camera;

		[Tooltip("Find a bone inside the Hierarchy of the Stat Manager")]
		public string FollowTransform = "Head";

		[Tooltip("if the damage was zero do not show the floating number")]
		public bool ignoreZero = true;

		private List<MDamageableUI> TrackedStats;

		[Tooltip("Change the Scale of the UI if the hit is critical")]
		public Vector3 CriticalScale = Vector3.one;

		private Camera MainCamera;

		private void Awake()
		{
			TrackedStats = new List<MDamageableUI>();
			Set.Clear();
			if (Camera.Value != null)
			{
				MainCamera = Camera.Value.GetComponent<Camera>();
				return;
			}
			MainCamera = MTools.FindMainCamera();
			Camera.Value = MainCamera.transform;
		}

		private void OnEnable()
		{
			Set.OnItemAdded.AddListener(OnAddedMDamageable);
			Set.OnItemRemoved.AddListener(OnRemovedStat);
		}

		private void OnDisable()
		{
			Set.OnItemAdded.RemoveListener(OnAddedMDamageable);
			Set.OnItemRemoved.RemoveListener(OnRemovedStat);
		}

		private void OnAddedMDamageable(MDamageable dam)
		{
			MDamageableUI item = new MDamageableUI
			{
				damageable = dam
			};
			Transform transform = dam.transform.FindGrandChild(FollowTransform);
			item.followTransform = ((transform != null) ? transform : dam.transform);
			item.OnValueChange = delegate(float floatValue)
			{
				if (!ignoreZero || !(floatValue < 0.1f))
				{
					UIFollowTransform uIFollowTransform = (item.damageable.LastDamage.WasCritical ? CriticalNumber : DamageNumber);
					if (uIFollowTransform != null)
					{
						UIFollowTransform uIFollowTransform2 = Object.Instantiate(uIFollowTransform);
						uIFollowTransform2.SetTransform(item.followTransform);
						uIFollowTransform2.transform.SetParent(base.transform);
						uIFollowTransform2.name = uIFollowTransform2.name.Replace("(Clone)", "");
						uIFollowTransform2.name = uIFollowTransform2.name + ": " + floatValue.ToString("F0");
						Text componentInChildren = uIFollowTransform2.GetComponentInChildren<Text>();
						if ((bool)componentInChildren)
						{
							componentInChildren.text = floatValue.ToString("F0");
							if (item.damageable.LastDamage.Element.element != null)
							{
								componentInChildren.color = item.damageable.LastDamage.Element.element.color;
							}
						}
					}
				}
			};
			item.damageable.events.OnReceivingDamage.AddListener(item.OnValueChange);
			TrackedStats.Add(item);
		}

		private void OnRemovedStat(MDamageable stats)
		{
			MDamageableUI mDamageableUI = TrackedStats.Find((MDamageableUI x) => x.damageable == stats);
			if (mDamageableUI != null)
			{
				RemoveFromGroup(mDamageableUI);
			}
		}

		private void RemoveFromGroup(MDamageableUI item)
		{
			item.damageable.events.OnReceivingDamage.RemoveListener(item.OnValueChange);
			item.OnValueChange = null;
			TrackedStats.Remove(item);
			Set.Item_Remove(item.damageable);
		}

		private void Reset()
		{
			Set = MTools.GetInstance<RuntimeDamageableSet>("Enemy Damageable");
		}
	}
}
