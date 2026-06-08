using System;
using System.Collections.Generic;
using Rhizomatic.Reactive;
using UnityEngine.InputSystem;

namespace GRP
{
	public class KeyBuilder
	{
		public List<KeyField> keyFields;

		public Part part;

		public void Add(Key key, string name, Action<Key> set)
		{
		}

		public void Add(State<Key> key, string name)
		{
		}
	}
}
