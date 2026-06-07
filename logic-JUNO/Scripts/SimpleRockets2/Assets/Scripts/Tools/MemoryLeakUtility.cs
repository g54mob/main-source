using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Pool;

namespace Assets.Scripts.Tools
{
	public static class MemoryLeakUtility
	{
		private class TrackedRef
		{
			private string _typeName;

			public int Age { get; set; }

			public string Metadata { get; }

			public string TypeName => _typeName ?? (_typeName = WeakRef.Target?.GetType().FullName ?? "null");

			public WeakReference WeakRef { get; }

			public TrackedRef(object obj, string metadata = null)
			{
				WeakRef = new WeakReference(obj);
				Metadata = metadata;
				Age = 0;
			}
		}

		private const int MaxAge = 6;

		private const int MinAge = 2;

		private static List<TrackedRef> _refs = new List<TrackedRef>();

		public static void OnSceneUnloaded()
		{
			Dictionary<string, List<TrackedRef>> value;
			using (CollectionPool<Dictionary<string, List<TrackedRef>>, KeyValuePair<string, List<TrackedRef>>>.Get(out value))
			{
				for (int num = _refs.Count - 1; num >= 0; num--)
				{
					TrackedRef trackedRef = _refs[num];
					bool flag = true;
					if (trackedRef.WeakRef.IsAlive)
					{
						trackedRef.Age++;
						flag = trackedRef.Age >= 6;
						if (trackedRef.Age >= 2)
						{
							if (!value.TryGetValue(trackedRef.TypeName, out var value2))
							{
								value2 = CollectionPool<List<TrackedRef>, TrackedRef>.Get();
								value.Add(trackedRef.TypeName, value2);
							}
							value2.Add(trackedRef);
						}
					}
					if (flag)
					{
						_refs.RemoveAt(num);
					}
				}
				if (value.Count <= 0)
				{
					return;
				}
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.AppendLine("Potential memory leaks detected: ");
				foreach (KeyValuePair<string, List<TrackedRef>> item in value)
				{
					stringBuilder.AppendLine(string.Format("  {0} ({1} instance{2})", item.Key, item.Value.Count, (item.Value.Count > 1) ? "s" : string.Empty));
					foreach (TrackedRef item2 in item.Value)
					{
						string text = (string.IsNullOrEmpty(item2.Metadata) ? item2.TypeName : item2.Metadata);
						string text2 = $"(Age: {item2.Age})";
						if (item2.Age >= 6)
						{
							text2 += " - Leak assumed to be permanent and will no longer be tracked.";
						}
						stringBuilder.AppendLine("    " + text + " " + text2);
					}
					CollectionPool<List<TrackedRef>, TrackedRef>.Release(item.Value);
				}
				Debug.LogError(stringBuilder.ToString());
			}
		}

		public static void Track(object obj, string metadata = null)
		{
			if (obj == null)
			{
				throw new ArgumentNullException("obj");
			}
			_refs.Add(new TrackedRef(obj, metadata));
		}
	}
}
