using System;
using System.Collections.Generic;
using UnityEngine;

namespace Rhizomatic.MemberBinding
{
	public abstract class Member
	{
		public string[] names;

		public virtual void Register(GameObject obj)
		{
		}

		public virtual bool CanRegister(GameObject obj)
		{
			return false;
		}
	}
	public class Member<T> : Member
	{
		public List<T> comps;

		public T first => default(T);

		protected virtual T Cast(GameObject obj)
		{
			return default(T);
		}

		public void For(Action<T> action)
		{
		}

		public override void Register(GameObject obj)
		{
		}

		public override bool CanRegister(GameObject obj)
		{
			return false;
		}
	}
}
