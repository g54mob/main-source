using System;
using System.Collections;
using MalbersAnimations.Events;
using MalbersAnimations.Scriptables;
using UnityEngine;

namespace MalbersAnimations.UI
{
	[AddComponentMenu("Malbers/UI/UI Follow Transform")]
	public class UIFollowTransform : MonoBehaviour
	{
		[Tooltip("Reference for the Main Camera on the Scene")]
		public Camera MainCamera;

		[Tooltip("Which Transform to Follow and Convert to Screen Position")]
		public TransformReference WorldTransform = new TransformReference();

		[Tooltip("Use a child of the World Transform instead")]
		public StringReference UseChild = new StringReference();

		private Transform followT;

		[Tooltip("Use FixedUpdate cycle for rendering UI, false to use LateUpdate")]
		[SerializeField]
		private UpdateType cycle = UpdateType.LateUpdate;

		[Tooltip("If the Object is Off-Screen, disable it")]
		public Behaviour HideOffScreen;

		[Tooltip("Reset the World Transform to Null when this component is Disable")]
		public bool ResetOnDisable;

		[Tooltip("If the World transform is Null, hide the Behaviour [HideOffScreen]")]
		public bool HideOnNull;

		[Tooltip("Offset position for the tracked gameobject")]
		public Vector3Reference Offset = new Vector3Reference(Vector3.zero);

		[Tooltip("Scale of the Instantiated prefab")]
		public Vector3Reference Scale = new Vector3Reference(Vector3.one);

		public BoolEvent OnTarget = new BoolEvent();

		public Vector3 ScreenCenter { get; set; }

		public Vector3 DefaultScreenCenter { get; set; }

		public Transform FollowT
		{
			get
			{
				return followT;
			}
			set
			{
				followT = value;
			}
		}

		private void Awake()
		{
			MainCamera = MTools.FindMainCamera();
			ScreenCenter = base.transform.position;
			DefaultScreenCenter = base.transform.position;
			if (WorldTransform == null)
			{
				WorldTransform = new TransformReference();
			}
			if (!WorldTransform.UseConstant && WorldTransform.Variable != null)
			{
				TransformVar variable = WorldTransform.Variable;
				variable.OnValueChanged = (Action<Transform>)Delegate.Combine(variable.OnValueChanged, new Action<Transform>(ListenTransform));
			}
		}

		private void OnDestroy()
		{
			if (!WorldTransform.UseConstant && WorldTransform.Variable != null)
			{
				TransformVar variable = WorldTransform.Variable;
				variable.OnValueChanged = (Action<Transform>)Delegate.Remove(variable.OnValueChanged, new Action<Transform>(ListenTransform));
			}
		}

		private void OnEnable()
		{
			MainCamera = MTools.FindMainCamera();
			StopAllCoroutines();
			if ((bool)HideOffScreen)
			{
				HideOffScreen.transform.localScale = Scale;
			}
			if ((bool)WorldTransform.Value)
			{
				Align();
			}
			SetTransform(WorldTransform);
			YieldInstruction waitTime = ((cycle == UpdateType.FixedUpdate) ? ((YieldInstruction)new WaitForFixedUpdate()) : ((YieldInstruction)new WaitForEndOfFrame()));
			StartCoroutine(UpdateCycle(waitTime));
		}

		private IEnumerator UpdateCycle(YieldInstruction waitTime)
		{
			while (true)
			{
				Align();
				yield return waitTime;
			}
		}

		private void OnDisable()
		{
			if (ResetOnDisable)
			{
				Clear();
			}
			StopAllCoroutines();
		}

		public virtual void Clear()
		{
			WorldTransform.Value = null;
			base.transform.position = ScreenCenter;
			if ((bool)HideOffScreen)
			{
				HideOffScreen.enabled = !HideOnNull;
			}
		}

		public void ListenTransform(Transform newTarget)
		{
			base.enabled = newTarget != null;
			SetTransform(newTarget);
			Align();
		}

		public void SetTransform(Transform newTarget)
		{
			WorldTransform.Value = newTarget;
			FindFollow(newTarget);
			if (FollowT == null)
			{
				if ((bool)HideOffScreen)
				{
					HideOffScreen.enabled = false;
				}
			}
			else
			{
				Align();
				base.enabled = newTarget != null;
			}
			OnTarget.Invoke(FollowT != null);
		}

		private void FindFollow(Transform newTarget)
		{
			if (newTarget != null && !string.IsNullOrEmpty(UseChild.Value))
			{
				FollowT = newTarget.FindGrandChild(UseChild);
				if (FollowT == null)
				{
					FollowT = newTarget;
				}
			}
			else
			{
				FollowT = newTarget;
			}
		}

		public void SetScreenCenter(Vector3 newScreenCenter)
		{
			ScreenCenter = newScreenCenter;
			base.enabled = true;
		}

		public void Align()
		{
			if (MainCamera == null || FollowT == null)
			{
				return;
			}
			Vector3 position = MainCamera.WorldToScreenPoint(FollowT.position + Offset);
			base.transform.position = position;
			if ((bool)HideOffScreen)
			{
				HideOffScreen.enabled = DoHideOffScreen(position);
				return;
			}
			if (position.z < 0f)
			{
				position.y = ((!(position.y > (float)(Screen.height / 2))) ? Screen.height : 0);
			}
			base.transform.position = new Vector3(Mathf.Clamp(position.x, 0f, Screen.width), Mathf.Clamp(position.y, 0f, Screen.height), 0f);
		}

		private bool DoHideOffScreen(Vector3 position)
		{
			if (position.x < 0f || position.x > (float)Screen.width)
			{
				return false;
			}
			if (position.y < 0f || position.y > (float)Screen.height)
			{
				return false;
			}
			if (position.z < 0f)
			{
				return false;
			}
			return true;
		}
	}
}
