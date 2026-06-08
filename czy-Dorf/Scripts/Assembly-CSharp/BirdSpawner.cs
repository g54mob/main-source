using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class BirdSpawner : MonoBehaviour
{
	private sealed class _003CSpawnBirds_003Ed__8 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public BirdSpawner _003C_003E4__this;

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
		public _003CSpawnBirds_003Ed__8(int _003C_003E1__state)
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
			BirdSpawner birdSpawner = _003C_003E4__this;
			if (num != 0)
			{
				if (num != 1)
				{
					return false;
				}
				_003C_003E1__state = -1;
				BirdFormation formation = Randomizer.SelectWeightedRandom(birdSpawner.possibleBirdFormations).formation;
				Vector2 vector = MathUtility.RandomPointInRect(birdSpawner.worldBounds.Bounds);
				Vector2 normalized = UnityEngine.Random.insideUnitCircle.normalized;
				Vector3 vector2 = new Vector3(normalized.x, 0f, normalized.y);
				Vector3 position = new Vector3(vector.x, 0f, vector.y) - vector2 * birdSpawner.spawnDistance + Vector3.up * UnityEngine.Random.Range(birdSpawner.randomHeight.x, birdSpawner.randomHeight.y);
				bool flag = true;
				while (flag)
				{
					Vector3 vector3 = birdSpawner.mainCamera.WorldToViewportPoint(position);
					if (vector3.x > 0f && vector3.x < 1f && vector3.y > 0f && vector3.y < 1f)
					{
						position -= vector2 * birdSpawner.spawnDistance;
					}
					else
					{
						flag = false;
					}
				}
				UnityEngine.Object.Instantiate(formation, position, Quaternion.LookRotation(vector2, Vector3.up), birdSpawner.transform).Setup(birdSpawner.mainCamera);
			}
			else
			{
				_003C_003E1__state = -1;
			}
			_003C_003E2__current = new WaitForSeconds(birdSpawner.spawnInterval);
			_003C_003E1__state = 1;
			return true;
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
	private WorldBounds worldBounds;

	[SerializeField]
	private List<BirdFormationSetting> possibleBirdFormations;

	[SerializeField]
	private float spawnInterval = 5f;

	[SerializeField]
	private float spawnDistance = 5f;

	[SerializeField]
	private float viewPortDistance = 1.4f;

	[SerializeField]
	private Vector2 randomHeight = new Vector2(2.5f, 3f);

	private Camera mainCamera;

	private void Start()
	{
		mainCamera = OverwritingSingleton<IngameUi>.Instance.mainCamera;
		StartCoroutine(SpawnBirds());
	}

	private IEnumerator SpawnBirds()
	{
		return new _003CSpawnBirds_003Ed__8(0)
		{
			_003C_003E4__this = this
		};
	}
}
