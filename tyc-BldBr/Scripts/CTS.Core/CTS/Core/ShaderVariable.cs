using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace CTS.Core
{
	[Serializable]
	public struct ShaderVariable : ISerializationCallbackReceiver, IEquatable<ShaderVariable>, IEquatable<int>
	{
		internal const string FieldName = "_name";

		[FormerlySerializedAs("Name")]
		[SerializeField]
		private string _name;

		private int _id;

		public string Name
		{
			get
			{
				return _name;
			}
			set
			{
				if (!(_name == value))
				{
					_name = value;
					_id = Shader.PropertyToID(_name);
				}
			}
		}

		public ShaderVariable(string name)
		{
			_name = name;
			_id = Shader.PropertyToID(_name);
		}

		public void OnBeforeSerialize()
		{
		}

		public static implicit operator ShaderVariable(string name)
		{
			return new ShaderVariable(name);
		}

		public static implicit operator string(ShaderVariable variable)
		{
			return variable.Name;
		}

		public static implicit operator int(ShaderVariable variable)
		{
			return variable._id;
		}

		public bool Equals(ShaderVariable other)
		{
			return Equals(other._id);
		}

		public bool Equals(int other)
		{
			return _id == other;
		}

		public override int GetHashCode()
		{
			return _id.GetHashCode();
		}

		public override string ToString()
		{
			return _name;
		}

		public void OnAfterDeserialize()
		{
			_id = Shader.PropertyToID(Name);
		}
	}
}
