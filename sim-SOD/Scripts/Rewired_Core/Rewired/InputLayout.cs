using System;
using UnityEngine;

namespace Rewired
{
	[Serializable]
	public sealed class InputLayout
	{
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private string _name;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string _descriptiveName;

		[CustomObfuscation(rename = false)]
		[SerializeField]
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
