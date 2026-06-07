using System;
using System.Collections;
using System.Collections.Generic;

namespace RLD
{
	public class GizmoBehaviourCollection : IEnumerable
	{
		private List<IGizmoBehaviour> _behaviours = new List<IGizmoBehaviour>(10);

		public int Count => _behaviours.Count;

		public bool Add(IGizmoBehaviour behaviour)
		{
			if (!Contains(behaviour))
			{
				_behaviours.Add(behaviour);
				return true;
			}
			return false;
		}

		public bool Remove(IGizmoBehaviour behaviour)
		{
			return _behaviours.Remove(behaviour);
		}

		public Type GetFirstBehaviourOfType<Type>() where Type : class, IGizmoBehaviour
		{
			List<Type> behavioursOfType = GetBehavioursOfType<Type>();
			if (behavioursOfType.Count != 0)
			{
				return behavioursOfType[0];
			}
			return null;
		}

		public IGizmoBehaviour GetFirstBehaviourOfType(Type behaviourType)
		{
			List<IGizmoBehaviour> behavioursOfType = GetBehavioursOfType(behaviourType);
			if (behavioursOfType.Count != 0)
			{
				return behavioursOfType[0];
			}
			return null;
		}

		public List<Type> GetBehavioursOfType<Type>() where Type : class, IGizmoBehaviour
		{
			if (Count == 0)
			{
				return new List<Type>();
			}
			List<Type> list = new List<Type>(Count);
			System.Type typeFromHandle = typeof(Type);
			foreach (IGizmoBehaviour behaviour in _behaviours)
			{
				System.Type type = behaviour.GetType();
				if (type == typeFromHandle || type.IsSubclassOf(typeFromHandle))
				{
					list.Add(behaviour as Type);
				}
			}
			return list;
		}

		public List<IGizmoBehaviour> GetBehavioursOfType(Type behaviourType)
		{
			if (Count == 0)
			{
				return new List<IGizmoBehaviour>();
			}
			List<IGizmoBehaviour> list = new List<IGizmoBehaviour>(Count);
			foreach (IGizmoBehaviour behaviour in _behaviours)
			{
				Type type = behaviour.GetType();
				if (type == behaviourType || type.IsSubclassOf(behaviourType))
				{
					list.Add(behaviour);
				}
			}
			return list;
		}

		public bool Contains(IGizmoBehaviour behaviour)
		{
			return _behaviours.Contains(behaviour);
		}

		public IEnumerator<IGizmoBehaviour> GetEnumerator()
		{
			return _behaviours.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
