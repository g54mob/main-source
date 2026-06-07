using System;
using UnityEngine;

namespace DV.Utils
{
	public abstract class __SingletonBehaviourBase : MonoBehaviour
	{
		private bool initializeDone;

		public static string AllowAutoCreate()
		{
			throw new NotImplementedException();
		}

		public void CheckInitialization()
		{
			if (!initializeDone)
			{
				initializeDone = true;
				Initialize();
			}
		}

		protected virtual void Initialize()
		{
		}

		public abstract void CheckInstance();
	}
}
