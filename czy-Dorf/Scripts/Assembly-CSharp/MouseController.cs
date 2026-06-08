using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class MouseController : MonoBehaviour
{
	private sealed class _003CResetMovedDistanceAtEndOfFrame_003Ed__24 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public MouseController _003C_003E4__this;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		[DebuggerHidden]
		public _003CResetMovedDistanceAtEndOfFrame_003Ed__24(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			int num = _003C_003E1__state;
			MouseController mouseController = _003C_003E4__this;
			switch (num)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003C_003E2__current = new WaitForEndOfFrame();
				_003C_003E1__state = 1;
				return true;
			case 1:
				_003C_003E1__state = -1;
				mouseController.movedDistance = 0f;
				return false;
			}
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}
	}

	private sealed class _003CResetRotatedDistanceAtEndOfFrame_003Ed__28 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public MouseController _003C_003E4__this;

		object IEnumerator<object>.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		object IEnumerator.Current
		{
			[DebuggerHidden]
			get
			{
				return _003C_003E2__current;
			}
		}

		[DebuggerHidden]
		public _003CResetRotatedDistanceAtEndOfFrame_003Ed__28(int _003C_003E1__state)
		{
			this._003C_003E1__state = _003C_003E1__state;
		}

		[DebuggerHidden]
		void IDisposable.Dispose()
		{
		}

		private bool MoveNext()
		{
			int num = _003C_003E1__state;
			MouseController mouseController = _003C_003E4__this;
			switch (num)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				_003C_003E2__current = new WaitForEndOfFrame();
				_003C_003E1__state = 1;
				return true;
			case 1:
				_003C_003E1__state = -1;
				mouseController.rotatedDistance = 0f;
				return false;
			}
		}

		bool IEnumerator.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			return this.MoveNext();
		}

		[DebuggerHidden]
		void IEnumerator.Reset()
		{
			throw new NotSupportedException();
		}
	}

	internal Vector2 currentFrameMousePos;

	internal Vector2 lastFrameMousePos;

	private Vector2 lastPlayerInputMousePos;

	internal TileSlot currentTileSlot;

	internal TileSlot lastTileSlot;

	private Tile currentTile;

	private Tile lastFrameTile;

	private Camera mainCamera;

	private float mouseMoveThreshold = 0.1f;

	private float mouseRotationTreshold = 3f;

	private float movedDistance;

	private float rotatedDistance;

	private bool hasPlayerInput;

	public bool HasPlayerInput
	{
		get
		{
			return hasPlayerInput;
		}
		set
		{
			hasPlayerInput = value;
			if (value)
			{
				lastPlayerInputMousePos = currentFrameMousePos;
			}
		}
	}

	public bool TilePlacementAllowed => movedDistance <= mouseMoveThreshold;

	public bool TileRotationAllowed => rotatedDistance <= mouseRotationTreshold;

	private void Start()
	{
		currentFrameMousePos = Input.mousePosition;
		lastFrameMousePos = currentFrameMousePos;
		mainCamera = OverwritingSingleton<IngameUi>.Instance.mainCamera;
	}

	private void Update()
	{
		lastFrameMousePos = currentFrameMousePos;
		lastTileSlot = currentTileSlot;
		lastFrameTile = currentTile;
		currentFrameMousePos = Input.mousePosition;
		if (Input.GetMouseButtonDown(0))
		{
			lastFrameMousePos = currentFrameMousePos;
		}
		if (TilePlacementAllowed)
		{
			DetermineCurrentTileSlot();
		}
		else
		{
			currentTileSlot = null;
		}
	}

	private void DetermineCurrentTileSlot()
	{
		Ray ray = mainCamera.ScreenPointToRay(currentFrameMousePos);
		Physics.Raycast(ray, out var hitInfo, 1000f, LayerMask.GetMask("TileSlot"));
		currentTileSlot = (hitInfo.collider ? hitInfo.collider.GetComponent<TileSlot>() : null);
		if (currentTileSlot != null && !currentTileSlot.IsValid)
		{
			currentTileSlot = null;
		}
		Physics.Raycast(ray, out var hitInfo2, 1000f, LayerMask.GetMask("Tile"));
		currentTile = (hitInfo2.collider ? hitInfo2.collider.GetComponentInParent<Tile>() : null);
	}

	public void ResetMovedDistance()
	{
	}

	private IEnumerator ResetMovedDistanceAtEndOfFrame()
	{
		return new _003CResetMovedDistanceAtEndOfFrame_003Ed__24(0)
		{
			_003C_003E4__this = this
		};
	}

	public void AddMovedDistance(Vector2 delta)
	{
		movedDistance += delta.magnitude;
	}

	public void AddRotatedDistance(Vector2 delta)
	{
		rotatedDistance += Mathf.Abs(delta.x);
	}

	public void ResetRotatedDistance()
	{
		StartCoroutine(ResetRotatedDistanceAtEndOfFrame());
	}

	private IEnumerator ResetRotatedDistanceAtEndOfFrame()
	{
		return new _003CResetRotatedDistanceAtEndOfFrame_003Ed__28(0)
		{
			_003C_003E4__this = this
		};
	}
}
