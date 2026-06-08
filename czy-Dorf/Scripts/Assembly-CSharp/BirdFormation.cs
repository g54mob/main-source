using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class BirdFormation : MonoBehaviour
{
	private sealed class _003CMove_003Ed__10 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public BirdFormation _003C_003E4__this;

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
		public _003CMove_003Ed__10(int _003C_003E1__state)
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
			BirdFormation birdFormation = _003C_003E4__this;
			switch (num)
			{
			default:
				return false;
			case 0:
				_003C_003E1__state = -1;
				break;
			case 1:
				_003C_003E1__state = -1;
				break;
			}
			if (birdFormation.alive)
			{
				birdFormation.transform.Translate(Vector3.forward * Time.deltaTime * birdFormation.speed);
				birdFormation.distance += Time.deltaTime * birdFormation.speed;
				if (birdFormation.distance > birdFormation.minDistanceBeforeDespawn)
				{
					Vector3 vector = birdFormation.mainCamera.WorldToViewportPoint(birdFormation.transform.position);
					if (vector.x < 0f - birdFormation.viewPortDespawnTreshold || vector.x > 1f + birdFormation.viewPortDespawnTreshold || vector.y < 0f - birdFormation.viewPortDespawnTreshold || vector.y > 1f + birdFormation.viewPortDespawnTreshold)
					{
						birdFormation.alive = false;
						UnityEngine.Object.Destroy(birdFormation.gameObject);
					}
				}
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
	private float speed = 1f;

	[SerializeField]
	private float minDistanceBeforeDespawn = 10f;

	[SerializeField]
	private float viewPortDespawnTreshold = 1.4f;

	private Bird[] birds;

	private Camera mainCamera;

	private float distance;

	private bool alive = true;

	private float colorValue;

	private void Awake()
	{
		birds = GetComponentsInChildren<Bird>();
	}

	public void Setup(Camera mainCamera)
	{
		this.mainCamera = mainCamera;
		colorValue = UnityEngine.Random.value;
		Bird[] array = birds;
		for (int i = 0; i < array.Length; i++)
		{
			array[i].Randomize(colorValue);
		}
		StartCoroutine(Move());
	}

	private IEnumerator Move()
	{
		return new _003CMove_003Ed__10(0)
		{
			_003C_003E4__this = this
		};
	}
}
