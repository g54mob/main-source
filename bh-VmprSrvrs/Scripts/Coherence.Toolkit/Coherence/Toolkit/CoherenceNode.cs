using Coherence.Log;
using Coherence.Toolkit.Bindings;
using UnityEngine;

namespace Coherence.Toolkit
{
	[DisallowMultipleComponent]
	[DefaultExecutionOrder(-950)]
	[RequireComponent(typeof(CoherenceSync))]
	public class CoherenceNode : MonoBehaviour
	{
		private static readonly char[] commaSeparator;

		[Sync]
		public string path;

		[Sync]
		public int pathDirtyCounter;

		private ValueBinding<string> pathBinding;

		private ValueBinding<int> pathDirtyCounterBinding;

		private int lastAppliedPathDirtyCounter;

		internal IConnectedEntityDriver sync { get; set; }

		internal Coherence.Log.Logger logger { get; set; }

		private ValueBinding<string> PathBinding => null;

		private ValueBinding<int> PathDirtyCounterBinding => null;

		private CoherenceNode()
		{
		}

		private void Awake()
		{
		}

		private void Start()
		{
		}

		private void OnDisable()
		{
		}

		private void OnDestroy()
		{
		}

		private void DidSendConnectedEntity(CoherenceSync newConnectedEntity)
		{
		}

		internal void UpdateHierarchy()
		{
		}

		private void PlaceInHierarchy(Transform start, string aPath)
		{
		}

		internal void ApplyBindings()
		{
		}

		internal void MakeBindingsReadyToSend()
		{
		}

		private static Transform ChildAtPath(Coherence.Log.Logger logger, Transform startingTransform, string path)
		{
			return null;
		}

		private static int[] IndexPathFromString(Coherence.Log.Logger logger, string path)
		{
			return null;
		}

		private static string CalculatePath(Transform fromParent, Transform toChild)
		{
			return null;
		}
	}
}
