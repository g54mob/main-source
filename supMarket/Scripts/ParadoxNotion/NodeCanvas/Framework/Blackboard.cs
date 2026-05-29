using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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
		private BlackboardSource _blackboard;

		[NonSerialized]
		private bool haltForUndo;

		[NonSerialized]
		private string _identifier;

		string IBlackboard.identifier => null;

		Dictionary<string, Variable> IBlackboard.variables
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		Component IBlackboard.propertiesBindTarget => null;

		UnityEngine.Object IBlackboard.unityContextObject => null;

		IBlackboard IBlackboard.parent => null;

		string IBlackboard.independantVariablesFieldName => null;

		public event Action<Variable> onVariableAdded
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event Action<Variable> onVariableRemoved
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		void ISerializationCallbackReceiver.OnBeforeSerialize()
		{
		}

		void ISerializationCallbackReceiver.OnAfterDeserialize()
		{
		}

		public void SelfSerialize()
		{
		}

		public void SelfDeserialize()
		{
		}

		public string Serialize(List<UnityEngine.Object> references, bool pretyJson = false)
		{
			return null;
		}

		public bool Deserialize(string json, List<UnityEngine.Object> references, bool removeMissingVariables = true)
		{
			return false;
		}

		void IBlackboard.TryInvokeOnVariableAdded(Variable variable)
		{
		}

		void IBlackboard.TryInvokeOnVariableRemoved(Variable variable)
		{
		}

		protected virtual void Awake()
		{
		}

		public Variable AddVariable(string name, Type type)
		{
			return null;
		}

		public Variable AddVariable(string name, object value)
		{
			return null;
		}

		public Variable RemoveVariable(string name)
		{
			return null;
		}

		public Variable GetVariable(string name, Type ofType = null)
		{
			return null;
		}

		public Variable GetVariableByID(string ID)
		{
			return null;
		}

		public Variable<T> GetVariable<T>(string name)
		{
			return null;
		}

		public T GetVariableValue<T>(string name)
		{
			return default(T);
		}

		public Variable SetVariableValue(string name, object value)
		{
			return null;
		}

		[Obsolete("Use GetVariableValue")]
		public T GetValue<T>(string name)
		{
			return default(T);
		}

		[Obsolete("Use SetVariableValue")]
		public Variable SetValue(string name, object value)
		{
			return null;
		}

		[ContextMenu("Show Json")]
		private void ShowJson()
		{
		}

		public string Save()
		{
			return null;
		}

		public string Save(string saveKey)
		{
			return null;
		}

		public bool Load()
		{
			return false;
		}

		public bool Load(string saveKey)
		{
			return false;
		}

		protected virtual void OnValidate()
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
