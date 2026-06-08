using System;
using System.Collections.Generic;
using UnityEngine;

namespace Rhizomatic.Utility
{
	public abstract class UnitySingleton : MonoBehaviour
	{
		public static Dictionary<Type, UnitySingleton> instances;

		protected virtual bool dontDestroyOnLoad => false;

		public T GetSingletonInstance<T>() where T : UnitySingleton
		{
			return null;
		}

		private void Awake()
		{
		}

		protected abstract void SetupSingleton();
	}
}
