using System;
using UnityEngine;
using Zenject;

namespace Restory.Gameplay.WorkshopStatus
{
	public abstract class WorkshopStatusEvaluatorBase : MonoBehaviour, IInitializable, IDisposable
	{
		public abstract void Initialize();

		public abstract void Dispose();
	}
}
