using System;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

namespace AwesomeTechnologies.Utility
{
	[Serializable]
	public class RaycastHitListPool
	{
		private readonly List<NativeList<RaycastHit>> _available = new List<NativeList<RaycastHit>>();

		public NativeList<RaycastHit> Get()
		{
			lock (_available)
			{
				if (_available.Count != 0)
				{
					NativeList<RaycastHit> result = _available[0];
					_available.RemoveAt(0);
					return result;
				}
				return new NativeList<RaycastHit>(0, Allocator.Persistent);
			}
		}

		public void Return(NativeList<RaycastHit> obj)
		{
			CleanUp(obj);
			lock (_available)
			{
				_available.Add(obj);
			}
		}

		private void CleanUp(NativeList<RaycastHit> obj)
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
