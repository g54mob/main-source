using System;
using UnityEngine;

namespace Rhizomatic
{
	[Serializable]
	public class SceneReference : ISerializationCallbackReceiver, IEquatable<SceneReference>, IComparable<SceneReference>
	{
		[SerializeField]
		private string m_ScenePath;

		public string ScenePath
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public string SceneName => null;

		public bool IsEmpty => false;

		public int BuildIndex => 0;

		public override bool Equals(object obj)
		{
			return false;
		}

		public bool Equals(SceneReference other)
		{
			return false;
		}

		public bool Equals(string scenePath)
		{
			return false;
		}

		public override int GetHashCode()
		{
			return 0;
		}

		public int CompareTo(SceneReference other)
		{
			return 0;
		}

		public SceneReference()
		{
		}

		public SceneReference(string scenePath)
		{
		}

		public SceneReference(SceneReference other)
		{
		}

		public SceneReference Clone()
		{
			return null;
		}

		public override string ToString()
		{
			return null;
		}

		[Obsolete("Needed for the editor, don't use it in runtime code!", true)]
		public void OnBeforeSerialize()
		{
		}

		[Obsolete("Needed for the editor, don't use it in runtime code!", true)]
		public void OnAfterDeserialize()
		{
		}
	}
}
