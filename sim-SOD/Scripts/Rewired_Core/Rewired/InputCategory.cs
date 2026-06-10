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

		[SerializeField]
		[CustomObfuscation(rename = false)]
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

		public InputCategory(InputCategory source)
		{
		}
	}
}
