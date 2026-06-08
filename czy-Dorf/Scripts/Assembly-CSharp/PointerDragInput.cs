using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Dorfromantik;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class PointerDragInput : MonoBehaviour
{
	private sealed class _003CPointerUpdate_003Ed__18 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public PointerDragInput _003C_003E4__this;

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
		public _003CPointerUpdate_003Ed__18(int _003C_003E1__state)
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
			PointerDragInput pointerDragInput = _003C_003E4__this;
			switch (num)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				pointerDragInput.currentFramePointerPos = Pointer.current.position.ReadValue();
				pointerDragInput.lastFramePointerPos = pointerDragInput.currentFramePointerPos;
				break;
			case 1:
				_003C_003E1__state = -1;
				pointerDragInput.lastFramePointerPos = pointerDragInput.currentFramePointerPos;
				break;
			}
			if (pointerDragInput.enabled)
			{
				pointerDragInput.currentFramePointerPos = Pointer.current.position.ReadValue();
				Vector2 vector = pointerDragInput.currentFramePointerPos - pointerDragInput.lastFramePointerPos;
				if (pointerDragInput.useWorldPos)
				{
					vector = pointerDragInput.DetermineWorldSpaceDelta();
				}
				pointerDragInput.onPointerDrag?.Invoke(vector * pointerDragInput.multiplier);
				_003C_003E2__current = null;
				_003C_003E1__state = 1;
				return true;
			}
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
			throw new NotSupportedException();
		}
	}

	[SerializeField]
	private InputActionReference clickAction;

	[FormerlySerializedAs("dontStartInputOverUi")]
	[SerializeField]
	private bool dontTriggerInputOverUi;

	[SerializeField]
	private Vector2Event onPointerDown;

	[SerializeField]
	private Vector2Event onPointerDrag;

	[SerializeField]
	private UnityEvent onPointerUp;

	[SerializeField]
	private float multiplier = 1f;

	[SerializeField]
	private bool useWorldPos;

	[SerializeField]
	private SceneLoader sceneLoader;

	private MouseController mouseController;

	private bool pointerDown;

	private Camera mainCamera;

	private Plane groundPlane = new Plane(Vector3.up, Vector3.zero);

	private Vector2 currentFramePointerPos;

	private Vector2 lastFramePointerPos;

	private Coroutine pointerCoroutine;

	private void Start()
	{
		if ((bool)OverwritingSingleton<IngameUi>.Instance)
		{
			UpdateInputCameraReference(default(Scene));
		}
		sceneLoader.OnSceneLoaded += UpdateInputCameraReference;
		clickAction.action.started += ClickStarted;
		clickAction.action.canceled += ClickStopped;
	}

	private void UpdateInputCameraReference(Scene obj)
	{
		if ((bool)OverwritingSingleton<IngameUi>.Instance)
		{
			mainCamera = OverwritingSingleton<IngameUi>.Instance.mainCamera;
		}
	}

	private void ClickStarted(InputAction.CallbackContext callbackContext)
	{
		if (!dontTriggerInputOverUi || !CameraUtility.PointerGameObject(5))
		{
			pointerDown = true;
			onPointerDown?.Invoke(currentFramePointerPos);
			pointerCoroutine = StartCoroutine(PointerUpdate());
		}
	}

	private IEnumerator PointerUpdate()
	{
		return new _003CPointerUpdate_003Ed__18(0)
		{
			_003C_003E4__this = this
		};
	}

	private void ClickStopped(InputAction.CallbackContext callbackContext)
	{
		pointerDown = false;
		if (pointerCoroutine != null)
		{
			StopCoroutine(pointerCoroutine);
		}
		onPointerUp?.Invoke();
	}

	private Vector2 DetermineWorldSpaceDelta()
	{
		if (!mainCamera)
		{
			return Vector2.zero;
		}
		Ray ray = mainCamera.ScreenPointToRay(currentFramePointerPos);
		Ray ray2 = mainCamera.ScreenPointToRay(lastFramePointerPos);
		groundPlane.Raycast(ray, out var enter);
		groundPlane.Raycast(ray2, out var enter2);
		Vector3 point = ray.GetPoint(enter);
		Vector3 vector = ray2.GetPoint(enter2) - point;
		return new Vector2(vector.x, vector.z);
	}

	private void OnDestroy()
	{
		clickAction.action.started -= ClickStarted;
		clickAction.action.canceled -= ClickStopped;
		sceneLoader.OnSceneLoaded -= UpdateInputCameraReference;
	}
}
