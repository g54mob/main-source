using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using BrewGame.SaveSystem.Integration;
using Unity.Netcode;
using UnityEngine;

namespace PlacementSystem
{
	public class PlacedObjectRegistry : MonoBehaviour, ISaveable
	{
		[CompilerGenerated]
		private sealed class _003CRestoreComponentStatesDeferred_003Ed__32 : IEnumerator<object>, IEnumerator, IDisposable
		{
			private int _003C_003E1__state;

			private object _003C_003E2__current;

			public GameObject go;

			public string itemId;

			public PlacedObjectRegistry _003C_003E4__this;

			public List<Dictionary<string, object>> statesList;

			private NetworkObject _003CnetworkObject_003E5__2;

			private int _003CwaitFrames_003E5__3;

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
			public _003CRestoreComponentStatesDeferred_003Ed__32(int _003C_003E1__state)
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

		private readonly Dictionary<ulong, PlacedObject> placedObjects;

		private readonly HashSet<string> removedSceneObjects;

		[Header("Debug")]
		[SerializeField]
		private bool showDebugLogs;

		private Dictionary<string, object> _pendingRestoreState;

		private bool _hasAttemptedRestore;

		public static PlacedObjectRegistry Instance { get; private set; }

		public string SaveableId => null;

		public int SavePriority => 0;

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void Update()
		{
		}

		private void OnDestroy()
		{
		}

		public void RegisterPlacedObject(PlacedObject obj)
		{
		}

		public void UnregisterPlacedObject(PlacedObject obj)
		{
		}

		public PlacedObject GetPlacedObject(ulong netId)
		{
			return null;
		}

		public IEnumerable<PlacedObject> GetAllPlacedObjects()
		{
			return null;
		}

		public int GetPlacedObjectCount()
		{
			return 0;
		}

		public void TrackSceneObjectRemoved(string sceneObjectId)
		{
		}

		public bool WasSceneObjectRemoved(string sceneObjectId)
		{
			return false;
		}

		public Dictionary<string, object> CaptureState()
		{
			return null;
		}

		public void RestoreState(Dictionary<string, object> state)
		{
		}

		private void RestoreStateInternal(Dictionary<string, object> state)
		{
		}

		public List<Dictionary<string, object>> GetPlacedObjectsData()
		{
			return null;
		}

		private void DestroyAllPlacedObjects()
		{
		}

		private void DespawnRemovedSceneObjects()
		{
		}

		private List<Dictionary<string, object>> CaptureComponentStates(GameObject go)
		{
			return null;
		}

		private void RestoreComponentStates(GameObject go, List<Dictionary<string, object>> statesList)
		{
		}

		[IteratorStateMachine(typeof(_003CRestoreComponentStatesDeferred_003Ed__32))]
		private IEnumerator RestoreComponentStatesDeferred(GameObject go, List<Dictionary<string, object>> statesList, string itemId)
		{
			return null;
		}

		private Dictionary<string, object> ConvertToDictionary(object obj)
		{
			return null;
		}

		private List<Dictionary<string, object>> ConvertToListOfDictionaries(object obj)
		{
			return null;
		}
	}
}
