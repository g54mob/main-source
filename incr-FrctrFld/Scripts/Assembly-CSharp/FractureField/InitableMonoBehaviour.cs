using System;
using UnityEngine;

namespace FractureField
{
	[Serializable]
	public abstract class InitableMonoBehaviour : MonoBehaviour, IInitable
	{
		public virtual int InitPriority => 0;

		public virtual bool InitInStart => false;

		public bool InitCompleted { get; set; }

		protected abstract void InitHandler();

		protected virtual void Awake()
		{
		}

		protected virtual void Start()
		{
		}

		public void Init()
		{
		}
	}
}
