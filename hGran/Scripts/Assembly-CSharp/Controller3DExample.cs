using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Controller3DExample : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CRotateCoroutine_003Ed__12 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Vector3 direction;

		public Controller3DExample _003C_003E4__this;

		private Quaternion _003ClookRotation_003E5__2;

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
		public _003CRotateCoroutine_003Ed__12(int _003C_003E1__state)
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

	public const float ROTATE_SPEED = 15f;

	public float movementSpeed;

	public CNAbstractController MovementJoystick;

	private CharacterController _characterController;

	private Transform _mainCameraTransform;

	private Transform _transformCache;

	private Transform _playerTransform;

	private void Start()
	{
	}

	private void Update()
	{
	}

	private void MoveWithEvent(Vector3 inputMovement)
	{
	}

	private void CommonMovementMethod(Vector3 movement)
	{
	}

	public void FaceDirection(Vector3 direction)
	{
	}

	[IteratorStateMachine(typeof(_003CRotateCoroutine_003Ed__12))]
	private IEnumerator RotateCoroutine(Vector3 direction)
	{
		return null;
	}
}
