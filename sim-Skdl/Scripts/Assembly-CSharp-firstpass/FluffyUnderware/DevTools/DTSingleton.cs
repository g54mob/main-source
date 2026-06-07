using JetBrains.Annotations;
using UnityEngine;

namespace FluffyUnderware.DevTools
{
	public class DTSingleton<T> : MonoBehaviour, IDTSingleton where T : MonoBehaviour, IDTSingleton
	{
		private static T _instance;

		private static readonly object _lock;

		public static bool HasInstance => false;

		[CanBeNull]
		public static T Instance => null;

		protected static void InitializeStaticFields()
		{
		}

		public virtual void Awake()
		{
		}

		public virtual void MergeDoubleLoaded(IDTSingleton newInstance)
		{
		}
	}
}
