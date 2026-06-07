using System;
using UnityEngine;

namespace Rewired
{
	[Serializable]
	public class InputCategory
	{
		[SerializeField]
		[CustomObfuscation]
		protected string _name;

		[CustomObfuscation]
		[SerializeField]
		protected string _descriptiveName;

		[SerializeField]
		[CustomObfuscation]
		protected string _tag;

		[CustomObfuscation]
		[SerializeField]
		protected int _id;

		[SerializeField]
		[CustomObfuscation]
		protected bool _userAssignable;

		public string name
		{
			get
			{
				return null;
			}
			internal set
			{
			}
		}

		public string descriptiveName
		{
			get
			{
				return null;
			}
			internal set
			{
			}
		}

		public string tag
		{
			get
			{
				return null;
			}
			internal set
			{
			}
		}

		public int id
		{
			get
			{
				return 0;
			}
			internal set
			{
			}
		}

		public bool userAssignable
		{
			get
			{
				return false;
			}
			internal set
			{
			}
		}

		public InputCategory()
		{
		}

		public InputCategory(InputCategory P_0)
		{
		}
	}
}
