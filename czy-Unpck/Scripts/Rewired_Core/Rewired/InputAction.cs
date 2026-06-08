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

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private string _descriptiveName;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string _positiveDescriptiveName;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private string _negativeDescriptiveName;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private int _behaviorId;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private bool _userAssignable;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int _categoryId;

		[NonSerialized]
		private string JHZTFDlaAmiNUNPzdfkNAmZxjzEE;

		[NonSerialized]
		private string RWUssoIfaezwvuSxkKnDgPJwHKbk;

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
				if (Application.isPlaying)
				{
					while (true)
					{
						int num = 1725035371;
						while (true)
						{
							switch (num ^ 0x66D1F369)
							{
							case 3:
								break;
							case 2:
								goto IL_002d;
							case 4:
								JHZTFDlaAmiNUNPzdfkNAmZxjzEE = _descriptiveName + " +";
								num = 1725035369;
								continue;
							case 1:
								goto end_IL_0007;
							default:
								return JHZTFDlaAmiNUNPzdfkNAmZxjzEE;
							}
							break;
							IL_002d:
							int num2;
							if (!string.IsNullOrEmpty(_positiveDescriptiveName))
							{
								num = 1725035368;
							}
							else if (!string.IsNullOrEmpty(JHZTFDlaAmiNUNPzdfkNAmZxjzEE))
							{
								num = 1725035369;
								num2 = num;
							}
							else
							{
								num = 1725035373;
								num2 = num;
							}
						}
						continue;
						end_IL_0007:
						break;
					}
				}
				return _positiveDescriptiveName;
			}
			internal set
			{
				_positiveDescriptiveName = value;
				JHZTFDlaAmiNUNPzdfkNAmZxjzEE = string.Empty;
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
				if (string.IsNullOrEmpty(RWUssoIfaezwvuSxkKnDgPJwHKbk))
				{
					RWUssoIfaezwvuSxkKnDgPJwHKbk = _descriptiveName + " -";
					num = -1362842466;
					goto IL_0019;
				}
				goto IL_0063;
				IL_0019:
				switch (num ^ -1362842468)
				{
				case 0:
					break;
				case 1:
					goto IL_0032;
				default:
					goto IL_0063;
				}
				goto IL_0014;
				IL_0032:
				return _negativeDescriptiveName;
				IL_0063:
				return RWUssoIfaezwvuSxkKnDgPJwHKbk;
				IL_0014:
				num = -1362842467;
				goto IL_0019;
			}
			internal set
			{
				_negativeDescriptiveName = value;
				RWUssoIfaezwvuSxkKnDgPJwHKbk = string.Empty;
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
