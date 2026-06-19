using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using FMODUnity;
using UnityEngine;

public class Blueprint : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CEnableAfterPhysicsFrame_003Ed__33 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Blueprint _003C_003E4__this;

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
		public _003CEnableAfterPhysicsFrame_003Ed__33(int _003C_003E1__state)
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

	private Building _blueprintBuilding;

	private int _overlaps;

	private bool _physicsInitiated;

	public const float BoundriesBuffer = 0.4f;

	[SerializeField]
	private SpriteRenderer _areaSpriteRenderer;

	public Material InvalidFormMat;

	public Material ValidFormMat;

	public Material InvalidOutlineMat;

	public Material ValidOutlineMat;

	public Action AnnouncePlace;

	[SerializeField]
	private EventReference _placeBlueprintSound;

	[SerializeField]
	private EventReference _placeBlueprintRejectedSound;

	private List<Collider2D> _ignoredColliders;

	private Vector2Int _lastPosition;

	public BuildingAsset BuildingAsset { get; private set; }

	public bool Valid { get; private set; }

	private void Start()
	{
	}

	private void OnDestroy()
	{
	}

	public void Set(BuildingAsset buildingAsset)
	{
	}

	public void SetIgnoreCollision(List<Collider2D> colliders = null)
	{
	}

	public void SetInitialValid(bool valid)
	{
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
	}

	public void EvaluateValid()
	{
	}

	public bool Position(Vector2Int position)
	{
		return false;
	}

	public bool CanPlace()
	{
		return false;
	}

	public void OnPlace()
	{
	}

	[IteratorStateMachine(typeof(_003CEnableAfterPhysicsFrame_003Ed__33))]
	private IEnumerator EnableAfterPhysicsFrame()
	{
		return null;
	}

	private void Update()
	{
	}
}
