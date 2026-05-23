using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Objectives : MonoBehaviour
{
	[CompilerGenerated]
	private sealed class _003CEffectOnDestroy_003Ed__25 : IEnumerator<object>, IEnumerator, IDisposable
	{
		private int _003C_003E1__state;

		private object _003C_003E2__current;

		public Objectives _003C_003E4__this;

		public int _objectiveUID;

		private GameObject _003CobjectiveGO_003E5__2;

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
		public _003CEffectOnDestroy_003Ed__25(int _003C_003E1__state)
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

	public static Objectives instance;

	private Dictionary<int, GameObject> instantiatedObjectives;

	private List<ObjectiveTimed> activeTimedObjectives;

	[SerializeField]
	private GameObject objectivePrefab;

	[SerializeField]
	private GameObject subObjectivePrefab;

	[SerializeField]
	private GameObject timedObjectivePrefab;

	[SerializeField]
	private Transform parentObjectForPrefabs;

	public int objectiveUID;

	public HashSet<int> activeObjectives;

	private int nextAppObjectiveUID;

	public int xPForObjectiveCompletion;

	public int reputationForObjectiveCompletion;

	[SerializeField]
	private GameObject objectivePosPrefab;

	private List<PositionIndicator> initiatedobjectivePosIndicators;

	[Header("Positions")]
	[SerializeField]
	private Transform computerShopPos;

	[SerializeField]
	private Transform firstRackMountPos;

	[SerializeField]
	private Transform firstCustomerPos;

	private void Awake()
	{
	}

	private void Start()
	{
	}

	public ObjectiveTimed GetTimedObjective(int objectiveUID)
	{
		return null;
	}

	public bool IsTutorialInProgress()
	{
		return false;
	}

	public void CreateNewObjective(int localisationUID, int _objectiveUID, Vector3 objectivePosition, int xpReward = 0, int reputationReward = 0, bool isSub = false)
	{
	}

	public int CreateAppObjective(int customerID, int appID, int time, int requiredIOPS)
	{
		return 0;
	}

	private string ObjectiveTimedText()
	{
		return null;
	}

	public void DestroyObjective(int _objectiveUID)
	{
	}

	[IteratorStateMachine(typeof(_003CEffectOnDestroy_003Ed__25))]
	private IEnumerator EffectOnDestroy(int _objectiveUID)
	{
		return null;
	}

	public void ClearObjectives()
	{
	}

	public void StartObjective(int _objectiveUID, Vector3 objectivePosition, bool _loadSave = false)
	{
	}

	public void StartObjective(int _objectiveUID, bool _loadSave = false)
	{
	}

	public void InstantiateObjectiveSign(int objectiveUID, Vector3 objectPos)
	{
	}

	public void RemoveObjectiveSign(int objectiveUID)
	{
	}

	public void LoadObjectives(HashSet<int> _activeObjectives)
	{
	}

	private void OnDestroy()
	{
	}

	private void OnLoad()
	{
	}
}
