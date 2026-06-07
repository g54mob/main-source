using System;
using GameCreator.Runtime.Characters;
using UnityEngine;

namespace GameCreator.Runtime.Common
{
	[Serializable]
	public class CompareGameObjectOrAny
	{
		private enum Option
		{
			Any = 0,
			Specific = 1
		}

		[SerializeField]
		private Option m_Option;

		[SerializeField]
		private PropertyGetGameObject m_GameObject = GetGameObjectPlayer.Create();

		public bool Any => m_Option == Option.Any;

		public CompareGameObjectOrAny()
		{
		}

		public CompareGameObjectOrAny(PropertyGetGameObject gameObject)
			: this(defaultAny: false, gameObject)
		{
		}

		public CompareGameObjectOrAny(bool defaultAny, PropertyGetGameObject gameObject)
			: this()
		{
			m_Option = ((!defaultAny) ? Option.Specific : Option.Any);
			m_GameObject = gameObject;
		}

		public bool Match(GameObject compareTo, Args args)
		{
			if (Any)
			{
				return true;
			}
			return compareTo == Get(args);
		}

		public bool Match(GameObject compareTo, GameObject args)
		{
			if (Any)
			{
				return true;
			}
			return compareTo == Get(args);
		}

		public GameObject Get(Args args)
		{
			return m_GameObject.Get(args);
		}

		public GameObject Get(GameObject target)
		{
			return m_GameObject.Get(target);
		}

		public T Get<T>(Args args) where T : Component
		{
			return m_GameObject.Get<T>(args);
		}

		public T Get<T>(GameObject target) where T : Component
		{
			return m_GameObject.Get<T>(target);
		}

		public override string ToString()
		{
			return m_Option switch
			{
				Option.Any => "Any", 
				Option.Specific => m_GameObject.ToString(), 
				_ => throw new ArgumentOutOfRangeException(), 
			};
		}
	}
}
