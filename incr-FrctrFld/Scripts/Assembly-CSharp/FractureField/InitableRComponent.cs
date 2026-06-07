using System;
using Reactivity.Unity.Components;

namespace FractureField
{
	[Serializable]
	public abstract class InitableRComponent : RComponent, IInitable
	{
		public virtual int InitPriority => 0;

		public virtual bool InitInStart => false;

		public bool InitCompleted { get; set; }

		protected abstract void InitHandler();

		protected override void Awake()
		{
		}

		protected override void Start()
		{
		}

		public void Init()
		{
		}
	}
}
