using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using UnityEngine;

namespace WeavUtils
{
	public class LogWindow : DebugGUIWindow
	{
		private struct TransientLog
		{
			public string text;

			public float expiryTime;

			public TransientLog(string text, float expiryTime)
			{
				this.text = text;
				this.expiryTime = expiryTime;
			}
		}

		public class PersistentLogAttributeKey
		{
			public MemberInfo memberInfo;

			public PersistentLogAttributeKey(MemberInfo memberInfo)
			{
				this.memberInfo = memberInfo;
			}
		}

		private List<TransientLog> transientLogs = new List<TransientLog>();

		private List<MonoBehaviour> attributeContainers = new List<MonoBehaviour>();

		private Dictionary<MonoBehaviour, Type> typeCache = new Dictionary<MonoBehaviour, Type>();

		private Dictionary<Type, int> typeInstanceCounts = new Dictionary<Type, int>();

		private Dictionary<object, string> persistentLogs = new Dictionary<object, string>();

		private Dictionary<MonoBehaviour, List<PersistentLogAttributeKey>> attributeKeys = new Dictionary<MonoBehaviour, List<PersistentLogAttributeKey>>();

		private Dictionary<Type, HashSet<FieldInfo>> debugGUIPrintFields = new Dictionary<Type, HashSet<FieldInfo>>();

		private Dictionary<Type, HashSet<PropertyInfo>> debugGUIPrintProperties = new Dictionary<Type, HashSet<PropertyInfo>>();

		private StringBuilder persistentLogStringBuilder = new StringBuilder();

		private GUIStyle textStyle;

		public override void Init()
		{
			base.Init();
			RegisterAttributes();
			textStyle = new GUIStyle();
			textStyle.normal.textColor = Color.white;
		}

		private void LateUpdate()
		{
			int num = 0;
			for (int i = 0; i < transientLogs.Count; i++)
			{
				if (transientLogs[i].expiryTime <= Time.time)
				{
					num++;
				}
			}
			transientLogs.RemoveRange(0, num);
			CleanUpDeletedAttributes();
		}

		protected override void OnGUI()
		{
			base.OnGUI();
			if (Event.current.type != EventType.Repaint || persistentLogs.Count + transientLogs.Count == 0)
			{
				return;
			}
			GUI.color = Color.white;
			GUI.backgroundColor = DebugGUI.Settings.backgroundColor;
			float y = GetMultilineStringSize(textStyle, in string.Empty).y;
			persistentLogStringBuilder.Clear();
			foreach (MonoBehaviour attributeContainer in attributeContainers)
			{
				Type key = typeCache[attributeContainer];
				if (debugGUIPrintFields.ContainsKey(key))
				{
					foreach (FieldInfo item in debugGUIPrintFields[key])
					{
						persistentLogStringBuilder.AppendLine($"{attributeContainer.name} {item.Name}: {item.GetValue(attributeContainer)}");
					}
				}
				if (!debugGUIPrintProperties.ContainsKey(key))
				{
					continue;
				}
				foreach (PropertyInfo item2 in debugGUIPrintProperties[key])
				{
					persistentLogStringBuilder.AppendLine($"{attributeContainer.name} {item2.Name}: {item2.GetValue(attributeContainer, null)}");
				}
			}
			foreach (string value in persistentLogs.Values)
			{
				persistentLogStringBuilder.AppendLine(value);
			}
			string str = persistentLogStringBuilder.ToString();
			Vector2 size = GetMultilineStringSize(textStyle, in str);
			size.x = Mathf.Max(100f, size.x);
			base.rect.size = size;
			size.y += y;
			float num = size.y;
			for (int i = 0; i < transientLogs.Count; i++)
			{
				TransientLog transientLog = transientLogs[i];
				Vector2 multilineStringSize = GetMultilineStringSize(textStyle, in transientLog.text);
				size = new Vector2(Mathf.Max(multilineStringSize.x, size.x), size.y + multilineStringSize.y);
			}
			Rect rect = new Rect(default(Vector2), new Vector2(size.x, size.y));
			DrawRect(rect, DebugGUI.Settings.backgroundColor, Padding);
			DrawRect(new Rect(0f, 0f, base.rect.width, base.rect.height), new Color(1f, 1f, 1f, 0.05f), Padding);
			DrawLabel(new Rect(default(Vector2), size), str, Padding, textStyle);
			for (int num2 = transientLogs.Count - 1; num2 >= 0; num2--)
			{
				if (num > (float)Screen.height)
				{
					transientLogs.RemoveRange(0, num2 + 1);
					break;
				}
				TransientLog transientLog2 = transientLogs[num2];
				DrawLabel(Vector2.up * num, transientLog2.text, Padding, textStyle);
				num += y;
			}
		}

		public void Log(string str)
		{
			transientLogs.Add(new TransientLog(str, Time.time + DebugGUI.Settings.temporaryLogLifetime));
		}

		public void LogPersistent(object key, string message)
		{
			if (persistentLogs.ContainsKey(key))
			{
				persistentLogs[key] = message;
			}
			else
			{
				persistentLogs.Add(key, message);
			}
		}

		public void RemovePersistent(object key)
		{
			if (persistentLogs.ContainsKey(key))
			{
				persistentLogs.Remove(key);
			}
		}

		public void ClearPersistent()
		{
			persistentLogs.Clear();
		}

		public void ReinitializeAttributes()
		{
			List<object> list = new List<object>();
			foreach (object key in persistentLogs.Keys)
			{
				if (key is PersistentLogAttributeKey)
				{
					list.Add(key);
				}
			}
			foreach (object item in list)
			{
				persistentLogs.Remove(item);
			}
			attributeContainers = new List<MonoBehaviour>();
			debugGUIPrintFields = new Dictionary<Type, HashSet<FieldInfo>>();
			debugGUIPrintProperties = new Dictionary<Type, HashSet<PropertyInfo>>();
			typeInstanceCounts = new Dictionary<Type, int>();
			attributeKeys = new Dictionary<MonoBehaviour, List<PersistentLogAttributeKey>>();
		}

		private void RegisterAttributes()
		{
			MonoBehaviour[] array = UnityEngine.Object.FindObjectsOfType<MonoBehaviour>();
			foreach (MonoBehaviour monoBehaviour in array)
			{
				Type type = monoBehaviour.GetType();
				HashSet<MonoBehaviour> hashSet = new HashSet<MonoBehaviour>();
				FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
				for (int j = 0; j < fields.Length; j++)
				{
					if (Attribute.GetCustomAttribute(fields[j], typeof(DebugGUIPrintAttribute)) is DebugGUIPrintAttribute)
					{
						hashSet.Add(monoBehaviour);
						typeCache[monoBehaviour] = monoBehaviour.GetType();
						if (!debugGUIPrintFields.ContainsKey(type))
						{
							debugGUIPrintFields.Add(type, new HashSet<FieldInfo>());
						}
						debugGUIPrintFields[type].Add(fields[j]);
					}
				}
				PropertyInfo[] properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
				for (int k = 0; k < properties.Length; k++)
				{
					if (Attribute.GetCustomAttribute(properties[k], typeof(DebugGUIPrintAttribute)) is DebugGUIPrintAttribute)
					{
						hashSet.Add(monoBehaviour);
						typeCache[monoBehaviour] = monoBehaviour.GetType();
						if (!debugGUIPrintProperties.ContainsKey(type))
						{
							debugGUIPrintProperties.Add(type, new HashSet<PropertyInfo>());
						}
						debugGUIPrintProperties[type].Add(properties[k]);
					}
				}
				foreach (MonoBehaviour item in hashSet)
				{
					attributeContainers.Add(item);
					Type type2 = item.GetType();
					if (!typeInstanceCounts.ContainsKey(type2))
					{
						typeInstanceCounts.Add(type2, 0);
					}
					typeInstanceCounts[type2]++;
				}
			}
		}

		private void CleanUpDeletedAttributes()
		{
			for (int i = 0; i < attributeContainers.Count; i++)
			{
				MonoBehaviour monoBehaviour = attributeContainers[i];
				if (!(attributeContainers[i] == null))
				{
					continue;
				}
				attributeKeys.Remove(monoBehaviour);
				typeCache.Remove(monoBehaviour);
				Type type = monoBehaviour.GetType();
				typeInstanceCounts[type]--;
				if (typeInstanceCounts[type] == 0)
				{
					if (debugGUIPrintFields.ContainsKey(type))
					{
						debugGUIPrintFields.Remove(type);
					}
					if (debugGUIPrintProperties.ContainsKey(type))
					{
						debugGUIPrintProperties.Remove(type);
					}
				}
				attributeContainers.RemoveAt(i);
				i--;
			}
		}
	}
}
