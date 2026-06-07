using System;
using UnityEngine;

namespace Coherence
{
	[DefaultExecutionOrder(-100)]
	public abstract class PreloadedSingleton : ScriptableObject
	{
		public abstract bool IsActiveInstance { get; }
	}
	public abstract class PreloadedSingleton<T> : PreloadedSingleton where T : ScriptableObject
	{
		private static T _instance;

		[Obsolete("Use Instance instead.")]
		[Deprecated("03/2023", 1, 2, 0, Reason = "Use Instance instead.")]
		public static T instance => null;

		internal static T InstanceUnsafe => null;

		public static T Instance
		{
			get
			{
				return null;
			}
			private set
			{
			}
		}

		public override bool IsActiveInstance => false;

		protected virtual void OnEnable()
		{
		}

		protected virtual void OnDisable()
		{
		}
	}
}
