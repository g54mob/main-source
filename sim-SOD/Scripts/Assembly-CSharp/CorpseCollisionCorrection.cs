using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using NaughtyAttributes;
using UnityEngine;

public class CorpseCollisionCorrection : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CCorrectCollisionOnDelay_003Ed__14 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public CorpseCollisionCorrection _003C_003E4__this;

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
		public _003CCorrectCollisionOnDelay_003Ed__14(int _003C_003E1__state)
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

	public Vector3 correctionDistance;

	public Transform target;

	public GameObject[] BodyParts;

	public float skeletonSizeModifier;

	public float correctionCooldown;

	private bool isOnCooldown;

	private void Start()
	{
	}

	[Button(null, EButtonEnableMode.Always)]
	private void ImplementSkeleton()
	{
	}

	private void SearchAndInstantiateBodyParts(Transform parent)
	{
	}

	private bool DoesNameContainPart(string childName, string bodyPartName)
	{
		return false;
	}

	private void InstantiateSkeletonPart(GameObject bodyPart, Transform child)
	{
	}

	private bool HasMatchingSkeletonPart(Transform child)
	{
		return false;
	}

	private string RemoveInvisibleCharacters(string input)
	{
		return null;
	}

	public void StartCollisionCorrection()
	{
	}

	[IteratorStateMachine(typeof(_003CCorrectCollisionOnDelay_003Ed__14))]
	private IEnumerator CorrectCollisionOnDelay()
	{
		return null;
	}
}
