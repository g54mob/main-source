using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

[Serializable]
public class DetectionManager
{
	[CompilerGenerated]
	private sealed class _003CClearInteraction_003Ed__19 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public DetectionManager _003C_003E4__this;

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
		public _003CClearInteraction_003Ed__19(int _003C_003E1__state)
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

	public gameManager gameManager;

	public PlayerManager playerManager;

	public DetectionMode playerDetection;

	public DetectionMode crosshairDetection;

	public DetectionMode blockedDetection;

	public bool playerCrouch;

	public bool onlyArea;

	public bool onlyCrosshair;

	public float maxDistance;

	public DetectionAdapter[] detectionAdapters;

	public GameObject detectionObject;

	private InteractionManager.InteractionVariants interactionVariants;

	public Action CreateInteraction;

	public DetectionManager(gameManager gameManager, GameObject detectionObject)
	{
	}

	public void start()
	{
	}

	public void loop()
	{
	}

	private void PlayerDetection()
	{
	}

	public void SetupInteraction(string description, string keyName, bool visible, KeyCode[] key, Action<KeyCode, object[]> action)
	{
	}

	public void SetupInteraction(string description, string keyName, bool visible, KeyCode[] key, object[] param, Action<KeyCode, object[]> action)
	{
	}

	[IteratorStateMachine(typeof(_003CClearInteraction_003Ed__19))]
	public IEnumerator ClearInteraction()
	{
		return null;
	}

	public void ClearInteractionIfExists()
	{
	}

	public bool isNone()
	{
		return false;
	}

	public void DetectionAct(DetectionMode mode, bool crosshair)
	{
	}

	public static void CrosshairView(bool active)
	{
	}

	public static bool GetCrosshairView()
	{
		return false;
	}
}
