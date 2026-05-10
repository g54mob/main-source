using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace CTS.DevConsole.Variables
{
	[Serializable]
	internal abstract class CVarDictionary<TKey, TKeyValuePair> : ConsoleVarCollection where TKeyValuePair : IKeyValue<TKey>
	{
		[SerializeField]
		protected List<TKeyValuePair> _list = new List<TKeyValuePair>();

		private Dictionary<TKey, int> _indexByKey = new Dictionary<TKey, int>();

		protected Dictionary<TKey, ConsoleVarValue> Dictionary = new Dictionary<TKey, ConsoleVarValue>();

		[SerializeReference]
		internal ConsoleVarValue _exampleValue;

		[SerializeField]
		[HideInInspector]
		private bool keyCollision;

		public ConsoleVarValue this[TKey key]
		{
			get
			{
				return Dictionary[key];
			}
			set
			{
				Dictionary[key] = value;
				if (_indexByKey.ContainsKey(key))
				{
					int index = _indexByKey[key];
					_list[index] = CreateNewPair(key, value);
				}
				else
				{
					_list.Add(CreateNewPair(key, value));
					_indexByKey.Add(key, _list.Count - 1);
				}
			}
		}

		public int Count => Dictionary.Count;

		public bool IsReadOnly { get; set; }

		public static implicit operator Dictionary<TKey, ConsoleVarValue>(CVarDictionary<TKey, TKeyValuePair> p_cVarDictionary)
		{
			return p_cVarDictionary.Dictionary;
		}

		protected abstract TKeyValuePair CreateNewPair(TKey key, ConsoleVarValue value);

		public override void Execute(string[] args)
		{
			if (args.Length == 0)
			{
				DeveloperConsole.LogError(base.ConsoleKey + " invalid number of arguments");
				return;
			}
			string text = args[0];
			TKey outKey;
			if (text == "default" || text == "reset")
			{
				SetDefaultValues();
			}
			else if (args.Length == 1)
			{
				DeveloperConsole.LogError(base.ConsoleKey + " invalid number of arguments");
			}
			else if (TryParseKey(text, out outKey))
			{
				if (Dictionary.ContainsKey(outKey))
				{
					Dictionary[outKey].Execute(args.Skip(1).ToArray());
				}
				else
				{
					DeveloperConsole.LogError("Invalid key");
				}
			}
			else
			{
				DeveloperConsole.LogError("Invalid key");
			}
		}

		public override void SetDefaultValues()
		{
			foreach (ConsoleVarValue value in Dictionary.Values)
			{
				value.SetDefaultValues();
			}
		}

		public virtual Dictionary<TKey, ConsoleVarValue> GetCurrentValue()
		{
			return Dictionary;
		}

		protected abstract bool TryParseKey(string arg, out TKey outKey);

		public bool ContainsKey(TKey key)
		{
			return Dictionary.ContainsKey(key);
		}

		public bool TryGetValue(TKey key, out ConsoleVarValue value)
		{
			return Dictionary.TryGetValue(key, out value);
		}

		public void Clear()
		{
			Dictionary.Clear();
			_list.Clear();
			_indexByKey.Clear();
		}

		public override void OnBeforeSerialize()
		{
			base.OnBeforeSerialize();
			for (int i = 0; i < _list.Count; i++)
			{
				_list[i].Value.CopyFrom(_exampleValue);
			}
		}

		public override void OnAfterDeserialize()
		{
			Dictionary.Clear();
			_indexByKey.Clear();
			keyCollision = false;
			for (int i = 0; i < _list.Count; i++)
			{
				TKey key = _list[i].Key;
				if (key != null && !ContainsKey(key))
				{
					Dictionary.Add(key, _list[i].Value);
					_indexByKey.Add(key, i);
				}
				else
				{
					keyCollision = true;
				}
			}
			base.OnAfterDeserialize();
		}
	}
}
