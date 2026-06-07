using System;
using UnityEngine;

namespace Assets.Scripts.GameLoop
{
	[Serializable]
	internal class UpdateGroupDebugData
	{
		public int ExecutionOrder;

		public MonoBehaviour[] Items;

		public bool MultipleThreads;

		public string Name;

		public string ExecutionOrderName;
	}
}
