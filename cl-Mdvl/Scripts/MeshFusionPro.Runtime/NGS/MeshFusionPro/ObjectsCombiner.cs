using System;
using System.Collections.Generic;
using UnityEngine;

namespace NGS.MeshFusionPro
{
	public abstract class ObjectsCombiner<TCombinedObject, TCombineSource> where TCombinedObject : ICombinedObject where TCombineSource : ICombineSource
	{
		private List<TCombinedObject> _combinedObjects;

		private List<TCombineSource> _sources;

		private List<TCombineSource> _sourcesForCombine;

		public IReadOnlyList<TCombinedObject> CombinedObjects => _combinedObjects;

		public bool ContainSources => _sources.Count > 0;

		public event Action<TCombinedObject> onCombinedObjectCreated;

		protected ObjectsCombiner()
		{
			_sources = new List<TCombineSource>();
			_combinedObjects = new List<TCombinedObject>();
			_sourcesForCombine = new List<TCombineSource>();
		}

		public virtual void AddSource(TCombineSource source)
		{
			_sources.Add(source);
		}

		public void AddSources(IEnumerable<TCombineSource> sources)
		{
			foreach (TCombineSource source in sources)
			{
				AddSource(source);
			}
		}

		public void RemoveSource(TCombineSource source)
		{
			_sources.Remove(source);
		}

		public void Combine()
		{
			if (_sources.Count != 0)
			{
				CleanEmptyData();
				CombineInternal();
				_sources.Clear();
			}
		}

		private void CleanEmptyData()
		{
			int num = 0;
			while (num < _combinedObjects.Count)
			{
				if (_combinedObjects[num] == null)
				{
					_combinedObjects.RemoveAt(num);
				}
				else
				{
					num++;
				}
			}
			num = 0;
			while (num < _sources.Count)
			{
				if (_sources[num] == null)
				{
					_sources.RemoveAt(num);
				}
				else
				{
					num++;
				}
			}
		}

		private void CombineInternal()
		{
			_sourcesForCombine.Clear();
			int num = 0;
			while (num <= _combinedObjects.Count && _sources.Count != 0)
			{
				bool flag = false;
				TCombinedObject val;
				if (num == _combinedObjects.Count)
				{
					try
					{
						val = CreateCombinedObject(_sources[0]);
						_combinedObjects.Add(val);
						flag = true;
					}
					catch (Exception ex)
					{
						Debug.Log("Unable to create CombinedObject : " + ex.Message + ex.StackTrace);
						_sources.RemoveAt(0);
						continue;
					}
				}
				else
				{
					val = _combinedObjects[num];
				}
				CombinedObjectMatcher<TCombinedObject, TCombineSource> matcher = GetMatcher();
				matcher.StartMatching(val);
				int num2 = 0;
				while (num2 < _sources.Count)
				{
					TCombineSource val2 = _sources[num2];
					if (matcher.CanAddSource(val2))
					{
						_sourcesForCombine.Add(val2);
						matcher.SourceAdded(val2);
						_sources.RemoveAt(num2);
					}
					else
					{
						num2++;
					}
				}
				if (_sourcesForCombine.Count > 0)
				{
					try
					{
						CombineSources(val, _sourcesForCombine);
						_sourcesForCombine.Clear();
					}
					catch (Exception ex2)
					{
						Debug.Log("Unable to combine sources in ObjectsCombiner : " + ex2.Message + ex2.StackTrace);
						_sourcesForCombine.Clear();
						continue;
					}
				}
				if (flag)
				{
					this.onCombinedObjectCreated?.Invoke(val);
				}
				num++;
			}
		}

		protected abstract CombinedObjectMatcher<TCombinedObject, TCombineSource> GetMatcher();

		protected abstract TCombinedObject CreateCombinedObject(TCombineSource source);

		protected abstract void CombineSources(TCombinedObject root, IList<TCombineSource> sources);
	}
}
