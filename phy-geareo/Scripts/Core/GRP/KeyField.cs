using System;
using UnityEngine.InputSystem;

namespace GRP
{
	public class KeyField
	{
		public string name;

		public Key key;

		public Part part;

		public Action<Key> setter;
	}
}
