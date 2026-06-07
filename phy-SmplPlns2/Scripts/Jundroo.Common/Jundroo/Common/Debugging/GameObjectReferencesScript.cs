using System;
using System.Collections.Generic;
using UnityEngine;

namespace Jundroo.Common.Debugging
{
	public class GameObjectReferencesScript : MonoBehaviour
	{
		[Serializable]
		public class GameObjectReference
		{
			[SerializeField]
			private string _name;

			[SerializeField]
			private GameObject _object;

			public string Name
			{
				get
				{
					return _name;
				}
				set
				{
					_name = value;
				}
			}

			public GameObject Object
			{
				get
				{
					return _object;
				}
				set
				{
					_object = value;
				}
			}

			public GameObjectReference(string name, GameObject obj)
			{
				Name = name;
				Object = obj;
			}
		}

		[SerializeField]
		private List<GameObjectReference> _references = new List<GameObjectReference>();

		public List<GameObjectReference> References
		{
			get
			{
				return _references;
			}
			set
			{
				_references = value;
			}
		}
	}
}
