using System;

namespace SpaceGraphicsToolkit
{
	public abstract class SgtLinkedBehaviour<T> : SgtBehaviour where T : SgtLinkedBehaviour<T>
	{
		[NonSerialized]
		public static T FirstInstance;

		[NonSerialized]
		public static int InstanceCount;

		[NonSerialized]
		public T PrevInstance;

		[NonSerialized]
		public T NextInstance;

		protected virtual void OnEnable()
		{
		}

		protected virtual void OnDisable()
		{
		}
	}
}
