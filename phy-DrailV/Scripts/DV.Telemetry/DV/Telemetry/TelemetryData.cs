using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using UnityEngine;

namespace DV.Telemetry
{
	public abstract class TelemetryData<OBJECT, DATA> : ITelemetryNode where DATA : new()
	{
		private struct FrameData
		{
			public float time;

			public float deltaTime;

			public int frameID;
		}

		public const int DefaultLength = 3600;

		private OBJECT obj;

		private DATA[] data;

		private FrameData[] frames;

		private int index;

		private int count;

		private ITelemetryNode parent;

		private List<ITelemetryNode> children = new List<ITelemetryNode>();

		private List<TelemetryDataField> fields;

		private static List<TelemetryDataField> FrameDataCache = null;

		private static Dictionary<Type, List<TelemetryDataField>> TypeCache = new Dictionary<Type, List<TelemetryDataField>>();

		private volatile bool suspended;

		private string cachedName = "";

		private int length;

		private bool lazyAllocation;

		private volatile bool delayedRelease;

		public int BufferLength => length;

		public ITelemetryNode Parent { get; set; }

		protected virtual string ObjectName => GetType().Name;

		public OBJECT TargetObject => obj;

		public int Count => count;

		public DATA this[int i]
		{
			get
			{
				int num = ((count >= data.Length) ? index : 0);
				return data[(num + i) % data.Length];
			}
		}

		public bool IsLazyAllocated => lazyAllocation;

		public bool IsBusy => suspended;

		public TelemetryData(OBJECT obj, bool lazyAllocation = false, int length = 3600)
		{
			this.obj = obj;
			cachedName = ObjectName;
			this.length = length;
			this.lazyAllocation = lazyAllocation;
			if (!lazyAllocation)
			{
				AllocateBuffers();
			}
			if (FrameDataCache == null)
			{
				FrameDataCache = IndexType(typeof(FrameData));
			}
			if (!TypeCache.TryGetValue(typeof(DATA), out fields))
			{
				fields = IndexType(typeof(DATA));
				TypeCache.Add(typeof(DATA), fields);
			}
		}

		public void AllocateBuffers()
		{
			if (frames == null || data == null)
			{
				frames = new FrameData[length];
				data = new DATA[length];
				for (int i = 0; i < length; i++)
				{
					data[i] = new DATA();
				}
			}
			foreach (ITelemetryNode child in children)
			{
				child.AllocateBuffers();
			}
		}

		public void ReleaseBuffers()
		{
			if (!lazyAllocation)
			{
				throw new InvalidOperationException("Can't do ReleaseBuffers on a recorder that doesn't have lazyAllocation set.");
			}
			if (suspended)
			{
				delayedRelease = true;
				return;
			}
			frames = null;
			data = null;
			count = (index = 0);
			foreach (ITelemetryNode child in children)
			{
				child.ReleaseBuffers();
			}
		}

		private static List<TelemetryDataField> IndexType(Type type)
		{
			List<TelemetryDataField> list = new List<TelemetryDataField>();
			FieldInfo[] array = type.GetFields();
			int num = 0;
			for (int i = 0; i < array.Length; i++)
			{
				TelemetryDataField telemetryDataField = new TelemetryDataField();
				telemetryDataField.field = array[i];
				telemetryDataField.handler = TelemetryFieldHandlers.GetFor(array[i].FieldType);
				telemetryDataField.startingColumn = num;
				telemetryDataField.columns = telemetryDataField.handler.ColumnCount;
				num += telemetryDataField.columns;
				list.Add(telemetryDataField);
			}
			return list;
		}

		public void RecordFrame()
		{
			if (!suspended)
			{
				if (lazyAllocation && (data == null || frames == null))
				{
					AllocateBuffers();
				}
				frames[index].time = Time.timeSinceLevelLoad;
				frames[index].deltaTime = Time.deltaTime;
				frames[index].frameID = Time.frameCount;
				RecordTo(obj, ref data[index]);
				count = Mathf.Min(count + 1, data.Length);
				index = (index + 1) % data.Length;
				for (int i = 0; i < children.Count; i++)
				{
					children[i].RecordFrame();
				}
			}
		}

		protected abstract void RecordTo(OBJECT obj, ref DATA data);

		public void CacheNames()
		{
			cachedName = ObjectName;
			for (int i = 0; i < children.Count; i++)
			{
				children[i].CacheNames();
			}
		}

		public void FillColumnData(string titleSuffix, List<string> columnTitle, List<TelemetryDataField> columnField, List<int> columnIndex, List<Array> sourceArray)
		{
			titleSuffix = "_" + cachedName + titleSuffix;
			for (int i = 0; i < fields.Count; i++)
			{
				TelemetryDataField telemetryDataField = fields[i];
				for (int j = 0; j < telemetryDataField.columns; j++)
				{
					if (!string.IsNullOrEmpty(telemetryDataField.handler.GetColumnName(j)))
					{
						columnTitle.Add(telemetryDataField.field.Name + "_" + telemetryDataField.handler.GetColumnName(j) + titleSuffix);
					}
					else
					{
						columnTitle.Add(telemetryDataField.field.Name + titleSuffix);
					}
					columnField.Add(telemetryDataField);
					columnIndex.Add(j);
					sourceArray.Add(data);
				}
			}
			for (int k = 0; k < children.Count; k++)
			{
				children[k].FillColumnData(titleSuffix, columnTitle, columnField, columnIndex, sourceArray);
			}
		}

		public void SaveCSV(string fileName)
		{
			if (!lazyAllocation || (data != null && frames != null))
			{
				if (suspended)
				{
					Debug.LogWarning("Telemetry already suspended for saving, ignoring the call");
					return;
				}
				SetSuspended(suspended: true);
				TelemetrySavingTracker.StartSaving();
				CacheNames();
				Thread thread = new Thread(SaveThread);
				thread.Priority = System.Threading.ThreadPriority.Lowest;
				thread.Start(fileName);
			}
		}

		public void SetSuspended(bool suspended)
		{
			this.suspended = suspended;
			for (int i = 0; i < children.Count; i++)
			{
				children[i].SetSuspended(suspended);
			}
		}

		internal void SaveThread(object fileNameObj)
		{
			try
			{
				string text = (string)fileNameObj;
				string directoryName = Path.GetDirectoryName(text);
				if (!Directory.Exists(directoryName))
				{
					Directory.CreateDirectory(directoryName);
				}
				List<string> list = new List<string>();
				List<TelemetryDataField> list2 = new List<TelemetryDataField>();
				List<int> list3 = new List<int>();
				List<Array> list4 = new List<Array>();
				for (int i = 0; i < FrameDataCache.Count; i++)
				{
					TelemetryDataField telemetryDataField = FrameDataCache[i];
					for (int j = 0; j < telemetryDataField.columns; j++)
					{
						if (!string.IsNullOrEmpty(telemetryDataField.handler.GetColumnName(j)))
						{
							list.Add(telemetryDataField.field.Name + "_" + telemetryDataField.handler.GetColumnName(j));
						}
						else
						{
							list.Add(telemetryDataField.field.Name);
						}
						list2.Add(telemetryDataField);
						list3.Add(j);
						list4.Add(frames);
					}
				}
				FillColumnData("", list, list2, list3, list4);
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.AppendLine("\"" + string.Join("\",\"", list) + "\"");
				int num = ((count >= data.Length) ? index : 0);
				for (int k = 0; k < count; k++)
				{
					int num2 = (num + k) % data.Length;
					for (int l = 0; l < list2.Count; l++)
					{
						if (l > 0)
						{
							stringBuilder.Append(',');
						}
						string text2 = list2[l].handler.GetColumnData(list2[l].field.GetValue(list4[l].GetValue(num2)), list3[l]);
						if (text2.Contains(',') || text2.Contains(' '))
						{
							text2 = "\"" + text2 + "\"";
						}
						stringBuilder.Append(text2);
					}
					if (k < count - 1)
					{
						stringBuilder.AppendLine();
					}
				}
				File.WriteAllText(text, stringBuilder.ToString());
				Debug.Log("Telemetry for " + cachedName + " written to '" + text + "'.");
			}
			catch (Exception exception)
			{
				Debug.LogException(exception);
			}
			finally
			{
				SetSuspended(suspended: false);
				TelemetrySavingTracker.FinishSaving();
				if (delayedRelease)
				{
					delayedRelease = false;
					ReleaseBuffers();
				}
			}
		}

		public void ResetPosition(int index, int count)
		{
			if (index < 0 || count < 0 || index >= BufferLength || count > BufferLength || index > count)
			{
				throw new InvalidOperationException($"Index ({index}) and/or count ({count}) are invalid for a buffer length of {BufferLength}.");
			}
			this.index = index;
			this.count = count;
		}

		public void RegisterChild(ITelemetryNode child)
		{
			if (child.BufferLength != BufferLength)
			{
				throw new InvalidOperationException($"Parent and child telemetry objects need to have the same buffer length, so they can be in sync on frames, but we got a mismatch here ({BufferLength} in parent, {child.BufferLength} in child)");
			}
			if (child.Parent != null)
			{
				if (child.Parent == this)
				{
					return;
				}
				child.Parent.UnregisterChild(child);
			}
			child.ResetPosition(index, count);
			children.Add(child);
			child.Parent = this;
		}

		public void UnregisterChild(ITelemetryNode child)
		{
			children.Remove(child);
			if (child.Parent == this)
			{
				child.Parent = null;
			}
		}

		public void ClearChildren()
		{
			for (int i = 0; i < children.Count; i++)
			{
				if (children[i].Parent == this)
				{
					children[i].Parent = null;
				}
			}
			children.Clear();
		}
	}
}
