using System;
using UnityEngine;

namespace Rewired
{
	[Serializable]
	public sealed class InputAction
	{
		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int _id;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private string _name;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private InputActionType _type;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string _descriptiveName;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string _positiveDescriptiveName;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private string _negativeDescriptiveName;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int _behaviorId;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _userAssignable;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private int _categoryId;

		[NonSerialized]
		private string rcSDCbeFpXWLdQEBfFsQZeHMOdsQ;

		[NonSerialized]
		private string rfLbNAmRTFewGftTwblGwADNKgZ;

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

		public InputActionType type
		{
			get
			{
				return default(InputActionType);
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

		public string positiveDescriptiveName
		{
			get
			{
				return null;
			}
			internal set
			{
			}
		}

		public string negativeDescriptiveName
		{
			get
			{
				return null;
			}
			internal set
			{
			}
		}

		public int behaviorId
		{
			get
			{
				return 0;
			}
			internal set
			{
			}
		}

		public int categoryId
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

		public InputAction()
		{
		}

		public InputAction(InputAction source)
		{
		}

		public InputAction Clone()
		{
			return null;
		}
	}
}
