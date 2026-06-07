using System;
using UnityEngine;

namespace Rewired
{
	[Serializable]
	public sealed class InputLayout
	{
		[SerializeField]
		[CustomObfuscation]
		private string _name;

		[CustomObfuscation]
		[SerializeField]
		private string _descriptiveName;

		[SerializeField]
		[CustomObfuscation]
		private int _id;

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

		public InputLayout()
		{
		}

		public InputLayout(InputLayout source)
		{
		}

		public InputLayout Clone()
		{
			return null;
		}
	}
}
