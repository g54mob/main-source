using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting;

namespace Gh.Tk
{
	[PersistenceOptIn]
	[PersistenceIgnoreParent]
	[InitializeOnGameStarted]
	public class UIDecorationController : SingletonMonoBehaviour<UIDecorationController>, IPersistable
	{
		public List<UIDecorationSet> decorSets;

		public float animMinTime;

		public float animMaxTime;

		private readonly Dictionary<GameObject, Vector3> _originalObjectScales;

		[PersistenceOptIn]
		[PersistenceDefaultValue(/*Could not decode attribute arguments.*/)]
		public string ActiveDecorationSet { get; private set; }

		[Preserve]
		private static void OnGameStarted()
		{
		}

		private void Reset()
		{
		}

		private string GetRealDateTheme()
		{
			return null;
		}

		public void ActivateDecorationSet(string targetSet, bool immediate = false)
		{
		}

		public void DeactivateDecorationSets(bool immediate = false)
		{
		}

		private void ActivateSet(UIDecorationSet set, bool immediate = false)
		{
		}

		private void DeactivateSet(UIDecorationSet set, bool immediate = false)
		{
		}
	}
}
