using UnityEngine;

namespace NodeCanvas.Framework
{
	public interface ITaskSystem
	{
		Component agent { get; }

		IBlackboard blackboard { get; }

		Object contextObject { get; }

		float elapsedTime { get; }

		float deltaTime { get; }

		void UpdateTasksOwner();

		void SendEvent(string name, object value, object sender);

		void SendEvent<T>(string name, T value, object sender);
	}
}
