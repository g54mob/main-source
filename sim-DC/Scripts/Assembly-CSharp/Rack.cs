using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Rack : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CUnmountRack_003Ed__18 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Rack _003C_003E4__this;

		private UsableObject _003CboxedRackUO_003E5__2;

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
		public _003CUnmountRack_003Ed__18(int _003C_003E1__state)
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

	public RackPosition[] positions;

	public int[] isPositionUsed;

	public RackMount rackMount;

	public AudioSource audioSource;

	public AudioSource effectAudioSource;

	private bool arePositionTurnedOff;

	[SerializeField]
	private Renderer buttonRackPositionsRendererer;

	[HideInInspector]
	public float targetVolume;

	public void Awake()
	{
	}

	private void Start()
	{
	}

	public bool IsPositionAvailable(int index, int sizeInU)
	{
		return false;
	}

	public void MarkPositionAsUsed(int index, int sizeInU)
	{
	}

	public void MarkPositionAsUnused(int index, int sizeInU)
	{
	}

	private void UpdateAudioVolume()
	{
	}

	public void InitializeLoadedRack(int[] loadedPositions)
	{
	}

	public void ButtonDisablePositionsInRack()
	{
	}

	private void SetDisablePositionsButtonMaterial(Material material)
	{
	}

	public void ButtonUnmountRack()
	{
	}

	[IteratorStateMachine(typeof(_003CUnmountRack_003Ed__18))]
	private IEnumerator UnmountRack()
	{
		return null;
	}

	private void OnLoad()
	{
	}

	private void OnDestroy()
	{
	}
}
