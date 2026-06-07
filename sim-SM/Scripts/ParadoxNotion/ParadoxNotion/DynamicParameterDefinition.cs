using System;
using UnityEngine;

namespace ParadoxNotion
{
	[Serializable]
	public sealed class DynamicParameterDefinition : ISerializationCallbackReceiver
	{
		[SerializeField]
		private string _ID;

		[SerializeField]
		private string _name;

		[SerializeField]
		private string _type;

		public string ID
		{
			get
			{
				return null;
			}
			private set
			{
			}
		}

		public string name
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public Type type { get; set; }

		void ISerializationCallbackReceiver.OnBeforeSerialize()
		{
		}

		void ISerializationCallbackReceiver.OnAfterDeserialize()
		{
		}

		public DynamicParameterDefinition()
		{
		}

		public DynamicParameterDefinition(string name, Type type)
		{
		}
	}
}
