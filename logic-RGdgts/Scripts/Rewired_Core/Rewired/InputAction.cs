using System;
using UnityEngine;

namespace Rewired
{
	[Serializable]
	public sealed class InputAction
	{
		[CustomObfuscation]
		[SerializeField]
		private int _id;

		[SerializeField]
		[CustomObfuscation]
		private string _name;

		[CustomObfuscation]
		[SerializeField]
		private InputActionType _type;

		[SerializeField]
		[CustomObfuscation]
		private string _descriptiveName;

		[CustomObfuscation]
		[SerializeField]
		private string _positiveDescriptiveName;

		[CustomObfuscation]
		[SerializeField]
		private string _negativeDescriptiveName;

		[SerializeField]
		[CustomObfuscation]
		private int _behaviorId;

		[SerializeField]
		[CustomObfuscation]
		private bool _userAssignable;

		[CustomObfuscation]
		[SerializeField]
		private int _categoryId;

		[NonSerialized]
		private string hMOIXiNBfhdXJKVdmdWBswwLEEnCA;

		[NonSerialized]
		private string vsVaIDwJZdkmqpFdxPbBkByKadMn;

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

		public InputAction(InputAction P_0)
		{
		}

		public InputAction Clone()
		{
			return null;
		}
	}
}
