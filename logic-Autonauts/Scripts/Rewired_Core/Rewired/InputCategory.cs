using System;
using UnityEngine;

namespace Rewired
{
	[Serializable]
	public class InputCategory
	{
		[SerializeField]
		[CustomObfuscation(rename = false)]
		protected string _name;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		protected string _descriptiveName;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		protected string _tag;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		protected int _id;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		protected bool _userAssignable;

		public string name
		{
			get
			{
				return _name;
			}
			internal set
			{
				_name = value;
			}
		}

		public string descriptiveName
		{
			get
			{
				return _descriptiveName;
			}
			internal set
			{
				_descriptiveName = value;
			}
		}

		public string tag
		{
			get
			{
				return _tag;
			}
			internal set
			{
				_tag = value;
			}
		}

		public int id
		{
			get
			{
				return _id;
			}
			internal set
			{
				_id = value;
			}
		}

		public bool userAssignable
		{
			get
			{
				return _userAssignable;
			}
			internal set
			{
				_userAssignable = value;
			}
		}

		public InputCategory()
		{
		}

		public InputCategory(InputCategory source)
		{
			while (true)
			{
				int num = -1542857536;
				while (true)
				{
					switch (num ^ -1542857535)
					{
					case 2:
						break;
					case 1:
						goto IL_0024;
					default:
						_id = source._id;
						_userAssignable = source._userAssignable;
						return;
					}
					break;
					IL_0024:
					_name = source._name;
					_descriptiveName = source._descriptiveName;
					_tag = source._tag;
					num = -1542857535;
				}
			}
		}
	}
}
