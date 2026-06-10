using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ControlsDisplayController : MonoBehaviour
{
	public class CustomActionsDisplayed
	{
		public InteractablePreset.InteractionKey key;

		public string interactionName;

		public float displayTime;

		public float lastDisplayedAt;

		public Interactable.InteractableCurrentAction action;
	}

	[CompilerGenerated]
	private sealed class _003CDisplayControlIconAfter_003Ed__30 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public float afterSeconds;

		public ControlsDisplayController _003C_003E4__this;

		public InteractablePreset.InteractionKey key;

		public string interactionName;

		public float forTime;

		public bool overrideMinDisplayTime;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return null;
			}
		}

		[DebuggerHidden]
		public _003CDisplayControlIconAfter_003Ed__30(int _003C_003E1__state)
		{
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			return false;
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
		}
	}

	[Header("Components")]
	public RectTransform rect;

	public RectTransform anchor;

	public GameObject controlDisplayPrefab;

	[Header("Settings")]
	public Vector2 padding;

	public float animationSelectTime;

	public AnimationCurve controlSelectAnimation;

	public float controlSelectScaleLerp;

	public Color controlSelectColorLerp;

	public Color audioFullColor;

	public Color audioEmptyColor;

	private float posChangeProgress;

	private float desiredYPos;

	private float desiredHeight;

	private float desiredRectFromLeft;

	private float desiredRectFromRight;

	[Tooltip("Minimum display time in gametime")]
	public float minimumCustomControlDisplayTimeInterval;

	[Header("State")]
	public List<ControlDisplayController> spawned;

	public List<CustomActionsDisplayed> customActionsDisplayed;

	public List<InteractablePreset.InteractionKey> disableControlDisplay;

	private static ControlsDisplayController _instance;

	public static ControlsDisplayController Instance => null;

	private void Awake()
	{
	}

	private void OnDestroy()
	{
	}

	public void UpdateControlDisplay()
	{
	}

	private void Update()
	{
	}

	public void RestoreDefaultDisplayArea()
	{
	}

	public void SetControlDisplayArea(float yPos, float height, float rectFromLeft, float rectFromRight)
	{
	}

	public void DisplayControlIconAfterDelay(float afterSeconds, InteractablePreset.InteractionKey key, string interactionName, float forTime, bool overrideMinDisplayTime = false)
	{
	}

	[IteratorStateMachine(typeof(_003CDisplayControlIconAfter_003Ed__30))]
	private IEnumerator DisplayControlIconAfter(float afterSeconds, InteractablePreset.InteractionKey key, string interactionName, float forTime, bool overrideMinDisplayTime)
	{
		return null;
	}

	public void DisplayControlIcon(InteractablePreset.InteractionKey key, string interactionName, float forTime, bool overrideMinDisplayTime = false)
	{
	}

	public string GetControlIcon(InteractablePreset.InteractionKey key, out ControlDisplayController.ControlPositioning positioning, out bool foundControl)
	{
		positioning = default(ControlDisplayController.ControlPositioning);
		foundControl = default(bool);
		return null;
	}
}
