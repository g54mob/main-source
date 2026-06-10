using System;
using System.Collections.Generic;
using System.Linq;
using NodeCanvas.Framework.Internal;
using ParadoxNotion.Design;
using ParadoxNotion.Serialization;
using UnityEngine;

namespace NodeCanvas.Framework
{
	[SpoofAOT]
	public class Blackboard : MonoBehaviour, ISerializationCallbackReceiver, IBlackboard
	{
		[Tooltip("An optional Parent Blackboard Asset to 'inherit' variables from.")]
		[SerializeField]
		private AssetBlackboard _parentBlackboard;

		[SerializeField]
		private string _serializedBlackboard;

		[SerializeField]
		private List<UnityEngine.Object> _objectReferences;

		[SerializeField]
		private SerializationPair[] _serializedVariables;

		[NonSerialized]
		private BlackboardSource _blackboard = new BlackboardSource();

		[NonSerialized]
		private bool haltForUndo;

		[NonSerialized]
		private string _identifier;

		string IBlackboard.identifier => _identifier;

		Dictionary<string, Variable> IBlackboard.variables
		{
			get
			{
				return _blackboard.variables;
			}
			set
			{
				_blackboard.variables = value;
			}
		}

		Component IBlackboard.propertiesBindTarget => this;

		UnityEngine.Object IBlackboard.unityContextObject => this;

		IBlackboard IBlackboard.parent => _parentBlackboard;

		string IBlackboard.independantVariablesFieldName => "_serializedVariables";

		public event Action<Variable> onVariableAdded;

		public event Action<Variable> onVariableRemoved;

		void ISerializationCallbackReceiver.OnBeforeSerialize()
		{
			SelfSerialize();
		}

		void ISerializationCallbackReceiver.OnAfterDeserialize()
		{
			SelfDeserialize();
		}

		public void SelfSerialize()
		{
			if (haltForUndo)
			{
				return;
			}
			List<UnityEngine.Object> list = new List<UnityEngine.Object>();
			string text = JSONSerializer.Serialize(typeof(BlackboardSource), _blackboard, list);
			if (text != _serializedBlackboard || !list.SequenceEqual(_objectReferences) || _serializedVariables == null || _serializedVariables.Length != _blackboard.variables.Count)
			{
				haltForUndo = true;
				haltForUndo = false;
				_serializedVariables = new SerializationPair[_blackboard.variables.Count];
				for (int i = 0; i < _blackboard.variables.Count; i++)
				{
					SerializationPair serializationPair = new SerializationPair();
					serializationPair._json = JSONSerializer.Serialize(typeof(Variable), _blackboard.variables.ElementAt(i).Value, serializationPair._references);
					_serializedVariables[i] = serializationPair;
				}
				_serializedBlackboard = text;
				_objectReferences = list;
			}
		}

		public void SelfDeserialize()
		{
			_blackboard = new BlackboardSource();
			if (!string.IsNullOrEmpty(_serializedBlackboard))
			{
				JSONSerializer.TryDeserializeOverwrite(_blackboard, _serializedBlackboard, _objectReferences);
			}
			if (_serializedVariables != null && _serializedVariables.Length != 0)
			{
				_blackboard.variables.Clear();
				for (int i = 0; i < _serializedVariables.Length; i++)
				{
					Variable variable = JSONSerializer.Deserialize<Variable>(_serializedVariables[i]._json, _serializedVariables[i]._references);
					_blackboard.variables[variable.name] = variable;
				}
			}
		}

		public string Serialize(List<UnityEngine.Object> references, bool pretyJson = false)
		{
			return JSONSerializer.Serialize(typeof(BlackboardSource), _blackboard, references, pretyJson);
		}

		public bool Deserialize(string json, List<UnityEngine.Object> references, bool removeMissingVariables = true)
		{
			BlackboardSource blackboardSource = JSONSerializer.Deserialize<BlackboardSource>(json, references);
			if (blackboardSource == null)
			{
				return false;
			}
			this.OverwriteFrom(blackboardSource, removeMissingVariables);
			this.InitializePropertiesBinding(((IBlackboard)this).propertiesBindTarget, callSetter: true);
			return true;
		}

		void IBlackboard.TryInvokeOnVariableAdded(Variable variable)
		{
			if (this.onVariableAdded != null)
			{
				this.onVariableAdded(variable);
			}
		}

		void IBlackboard.TryInvokeOnVariableRemoved(Variable variable)
		{
			if (this.onVariableRemoved != null)
			{
				this.onVariableRemoved(variable);
			}
		}

		protected virtual void Awake()
		{
			_identifier = base.gameObject.name;
			this.InitializePropertiesBinding(((IBlackboard)this).propertiesBindTarget, callSetter: false);
		}

		public Variable AddVariable(string name, Type type)
		{
			return IBlackboardExtensions.AddVariable(this, name, type);
		}

		public Variable AddVariable(string name, object value)
		{
			return IBlackboardExtensions.AddVariable(this, name, value);
		}

		public Variable RemoveVariable(string name)
		{
			return IBlackboardExtensions.RemoveVariable(this, name);
		}

		public Variable GetVariable(string name, Type ofType = null)
		{
			return IBlackboardExtensions.GetVariable(this, name, ofType);
		}

		public Variable GetVariableByID(string ID)
		{
			return IBlackboardExtensions.GetVariableByID(this, ID);
		}

		public Variable<T> GetVariable<T>(string name)
		{
			return IBlackboardExtensions.GetVariable<T>(this, name);
		}

		public T GetVariableValue<T>(string name)
		{
			return IBlackboardExtensions.GetVariableValue<T>(this, name);
		}

		public Variable SetVariableValue(string name, object value)
		{
			return IBlackboardExtensions.SetVariableValue(this, name, value);
		}

		[Obsolete("Use GetVariableValue")]
		public T GetValue<T>(string name)
		{
			return GetVariableValue<T>(name);
		}

		[Obsolete("Use SetVariableValue")]
		public Variable SetValue(string name, object value)
		{
			return SetVariableValue(name, value);
		}

		[ContextMenu("Show Json")]
		private void ShowJson()
		{
			JSONSerializer.ShowData(_serializedBlackboard, base.name);
		}

		public string Save()
		{
			return Save(base.name);
		}

		public string Save(string saveKey)
		{
			string text = Serialize(null);
			PlayerPrefs.SetString(saveKey, text);
			return text;
		}

		public bool Load()
		{
			return Load(base.name);
		}

		public bool Load(string saveKey)
		{
			string text = PlayerPrefs.GetString(saveKey);
			if (string.IsNullOrEmpty(text))
			{
				Debug.Log("No data to load blackboard variables from key " + saveKey);
				return false;
			}
			return Deserialize(text, null);
		}

		protected virtual void OnValidate()
		{
			_identifier = base.gameObject.name;
		}

		public override string ToString()
		{
			return _identifier;
		}
	}
}
