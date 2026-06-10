using System;
using System.Collections.Generic;
using System.Linq;
using FoxyVoxel.Logging;
using FoxyVoxel.Logging.Core.LogMessageInterpolationHandlers;
using UnityEngine;

namespace NSMedieval.Dictionary
{
	[Serializable]
	public class SerializableDictionary<TK, TV> : ISerializationCallbackReceiver
	{
		[Serializable]
		private class DictionaryEntry
		{
			public TK key;

			public TV value;
		}

		[SerializeField]
		private TK[] keys;

		[SerializeField]
		private TV[] values;

		[SerializeField]
		private DictionaryEntry[] entries;

		private Dictionary<TK, TV> dictionary;

		public TK[] Keys
		{
			get
			{
				return keys;
			}
			set
			{
				keys = value;
			}
		}

		public TV[] Values
		{
			get
			{
				return values;
			}
			set
			{
				values = value;
			}
		}

		public Dictionary<TK, TV> Dictionary
		{
			get
			{
				return dictionary ?? (dictionary = new Dictionary<TK, TV>());
			}
			set
			{
				dictionary = value;
			}
		}

		public TV this[TK key]
		{
			get
			{
				return Dictionary[key];
			}
			set
			{
				Dictionary[key] = value;
			}
		}

		public static T CreateNew<T>() where T : SerializableDictionary<TK, TV>, new()
		{
			return new T
			{
				Dictionary = new Dictionary<TK, TV>()
			};
		}

		public void OnAfterDeserialize()
		{
			if (entries != null && entries.Length != 0)
			{
				DictionaryEntry[] array = entries;
				foreach (DictionaryEntry dictionaryEntry in array)
				{
					Dictionary.Add(dictionaryEntry.key, dictionaryEntry.value);
				}
				return;
			}
			if (keys == null)
			{
				values = null;
				if (dictionary != null)
				{
					dictionary.Clear();
				}
				return;
			}
			int num = keys.Length;
			dictionary = new Dictionary<TK, TV>(num);
			bool isEnabled;
			if (keys == null || values == null)
			{
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(10, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Base\\SerializableDictionary\\SerializableDictionary.cs");
				if (isEnabled)
				{
					messageBuilder.AppendFormatted(GetType().Name);
					messageBuilder.AppendLiteral(" ERROR: ");
					messageBuilder.AppendFormatted((keys == null) ? "keys == null" : "values == null");
					messageBuilder.AppendLiteral(".\n");
					messageBuilder.AppendFormatted(Environment.StackTrace);
				}
				Log.Error(messageBuilder);
			}
			else if (keys.Length != values.Length)
			{
				FVLogErrorInterpolationHandler messageBuilder = new FVLogErrorInterpolationHandler(63, 3, out isEnabled, "C:\\GIT\\dev\\Assets\\Scripts\\Base\\SerializableDictionary\\SerializableDictionary.cs");
				if (isEnabled)
				{
					messageBuilder.AppendFormatted(GetType().Name);
					messageBuilder.AppendLiteral(" ERROR: number of keys and values must be equal.\nFirst key: \"");
					messageBuilder.AppendFormatted(keys.First());
					messageBuilder.AppendLiteral("\"\n");
					messageBuilder.AppendFormatted(Environment.StackTrace);
				}
				Log.Error(messageBuilder);
			}
			for (int j = 0; j < num; j++)
			{
				dictionary[keys[j]] = Values[j];
			}
			keys = null;
			Values = null;
		}

		public void OnBeforeSerialize()
		{
			if (dictionary == null || dictionary.Count == 0)
			{
				keys = null;
				values = null;
				return;
			}
			int count = dictionary.Count;
			keys = new TK[count];
			values = new TV[count];
			int num = 0;
			foreach (KeyValuePair<TK, TV> item in dictionary)
			{
				keys[num] = item.Key;
				values[num] = item.Value;
				num++;
			}
		}
	}
}
