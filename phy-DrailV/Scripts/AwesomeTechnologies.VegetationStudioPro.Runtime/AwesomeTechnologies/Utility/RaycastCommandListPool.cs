using System;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

namespace AwesomeTechnologies.Utility
{
	[Serializable]
	public class RaycastCommandListPool
	{
		private readonly List<NativeList<RaycastCommand>> _available = new List<NativeList<RaycastCommand>>();

		public NativeList<RaycastCommand> Get()
		{
			lock (_available)
			{
				if (_available.Count != 0)
				{
					NativeList<RaycastCommand> result = _available[0];
					_available.RemoveAt(0);
					return result;
				}
				return new NativeList<RaycastCommand>(0, Allocator.Persistent);
			}
		}

		public void Return(NativeList<RaycastCommand> obj)
		{
			CleanUp(obj);
			lock (_available)
			{
				_available.Add(obj);
			}
		}

		private void CleanUp(NativeList<RaycastCommand> obj)
		{
			obj.Clear();
		}

		public void Dispose()
		{
			for (int i = 0; i <= _available.Count - 1; i++)
			{
				if (_available[i].IsCreated)
				{
					_available[i].Dispose();
				}
			}
			lock (_available)
			{
				_available.Clear();
			}
		}
	}
}
