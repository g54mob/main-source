using System;
using UnityEngine;

namespace Rewired
{
	[Serializable]
	public sealed class InputAction
	{
		[CustomObfuscation(rename = false)]
		[SerializeField]
		private int _id;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string _name;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private InputActionType _type;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private string _descriptiveName;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private string _positiveDescriptiveName;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string _negativeDescriptiveName;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private int _behaviorId;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _userAssignable;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int _categoryId;

		[NonSerialized]
		private string kLDmcYRThsuYJsiGuRJUkphcUet;

		[NonSerialized]
		private string wKzTrjyLwulquNAvjKUDovBhRKX;

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

		public InputActionType type
		{
			get
			{
				return _type;
			}
			internal set
			{
				_type = value;
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

		public string positiveDescriptiveName
		{
			get
			{
				if (!Application.isPlaying)
				{
					goto IL_0032;
				}
				if (!string.IsNullOrEmpty(_positiveDescriptiveName))
				{
					goto IL_0014;
				}
				int num;
				if (string.IsNullOrEmpty(kLDmcYRThsuYJsiGuRJUkphcUet))
				{
					kLDmcYRThsuYJsiGuRJUkphcUet = _descriptiveName + " +";
					num = 1896850062;
					goto IL_0019;
				}
				goto IL_0063;
				IL_0019:
				switch (num ^ 0x710FA28F)
				{
				case 0:
					break;
				case 2:
					goto IL_0032;
				default:
					goto IL_0063;
				}
				goto IL_0014;
				IL_0032:
				return _positiveDescriptiveName;
				IL_0063:
				return kLDmcYRThsuYJsiGuRJUkphcUet;
				IL_0014:
				num = 1896850061;
				goto IL_0019;
			}
			internal set
			{
				_positiveDescriptiveName = value;
				kLDmcYRThsuYJsiGuRJUkphcUet = string.Empty;
			}
		}

		public string negativeDescriptiveName
		{
			get
			{
				if (!Application.isPlaying)
				{
					goto IL_0032;
				}
				if (!string.IsNullOrEmpty(_negativeDescriptiveName))
				{
					goto IL_0014;
				}
				int num;
				if (string.IsNullOrEmpty(wKzTrjyLwulquNAvjKUDovBhRKX))
				{
					wKzTrjyLwulquNAvjKUDovBhRKX = _descriptiveName + " -";
					num = -205267909;
					goto IL_0019;
				}
				goto IL_0063;
				IL_0019:
				switch (num ^ -205267910)
				{
				case 0:
					break;
				case 2:
					goto IL_0032;
				default:
					goto IL_0063;
				}
				goto IL_0014;
				IL_0032:
				return _negativeDescriptiveName;
				IL_0063:
				return wKzTrjyLwulquNAvjKUDovBhRKX;
				IL_0014:
				num = -205267912;
				goto IL_0019;
			}
			internal set
			{
				_negativeDescriptiveName = value;
				wKzTrjyLwulquNAvjKUDovBhRKX = string.Empty;
			}
		}

		public int behaviorId
		{
			get
			{
				return _behaviorId;
			}
			internal set
			{
				_behaviorId = value;
			}
		}

		public int categoryId
		{
			get
			{
				return _categoryId;
			}
			internal set
			{
				_categoryId = value;
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

		public InputAction()
		{
		}

		public InputAction(InputAction source)
		{
			_id = source._id;
			_name = source._name;
			_type = source._type;
			_descriptiveName = source._descriptiveName;
			_positiveDescriptiveName = source._positiveDescriptiveName;
			_negativeDescriptiveName = source._negativeDescriptiveName;
			_behaviorId = source._behaviorId;
			_userAssignable = source._userAssignable;
			_categoryId = source.categoryId;
		}

		public InputAction Clone()
		{
			return new InputAction(this);
		}
	}
}
