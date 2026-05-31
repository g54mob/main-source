using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using NodeCanvas.Framework.Internal;
using UnityEngine;

namespace NodeCanvas.Framework
{
	[CreateAssetMenu(menuName = "ParadoxNotion/CanvasCore/Blackboard Asset")]
	public class AssetBlackboard : ScriptableObject, ISerializationCallbackReceiver, IGlobalBlackboard, IBlackboard
	{
		[SerializeField]
		private string _serializedBlackboard;

		[SerializeField]
		private List<UnityEngine.Object> _objectReferences;

		[SerializeField]
		private string _UID;

		[NonSerialized]
		private string _identifier;

		[NonSerialized]
		private BlackboardSource _blackboard;

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

		UnityEngine.Object IBlackboard.unityContextObject => null;

		IBlackboard IBlackboard.parent => null;

		Component IBlackboard.propertiesBindTarget => null;

		string IBlackboard.independantVariablesFieldName => null;

		public string identifier => null;

		public string UID => null;

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

		private void SelfSerialize()
		{
		}

		private void SelfDeserialize()
		{
		}

		void IBlackboard.TryInvokeOnVariableAdded(Variable variable)
		{
		}

		void IBlackboard.TryInvokeOnVariableRemoved(Variable variable)
		{
		}

		[ContextMenu("Show Json")]
		private void ShowJson()
		{
		}

		public override string ToString()
		{
			return null;
		}

		private void OnValidate()
		{
		}

		private void OnEnable()
		{
		}
	}
}
