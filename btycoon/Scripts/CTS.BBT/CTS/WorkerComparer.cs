using System.Collections.Generic;
using CTS.BBT.AI;
using UnityEngine;

namespace CTS
{
	public abstract class WorkerComparer : ScriptableObject
	{
		public abstract IComparer<Worker> GetComparer();
	}
}
