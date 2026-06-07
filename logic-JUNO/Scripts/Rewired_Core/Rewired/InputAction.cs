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

		[SerializeField]
		[CustomObfuscation(rename = false)]
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

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string _negativeDescriptiveName;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int _behaviorId;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private bool _userAssignable;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int _categoryId;

		[NonSerialized]
		private string UQGOasrgEUdWvSKlDeBKUDBfhQVB;

		[NonSerialized]
		private string ModHqwaUcoTlvAAlEJMgpZMvXtZA;

		public int id
		{
			get
			{
				return _id;
			}
			internal set
			{
				_id = num;
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
				_name = text;
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
				_type = inputActionType;
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
				_descriptiveName = text;
			}
		}

		public string positiveDescriptiveName
		{
			get
			{
				if (!Application.isPlaying || !string.IsNullOrEmpty(_positiveDescriptiveName))
				{
					return _positiveDescriptiveName;
				}
				if (string.IsNullOrEmpty(UQGOasrgEUdWvSKlDeBKUDBfhQVB))
				{
					UQGOasrgEUdWvSKlDeBKUDBfhQVB = _descriptiveName + " +";
				}
				return UQGOasrgEUdWvSKlDeBKUDBfhQVB;
			}
			internal set
			{
				_positiveDescriptiveName = text;
				UQGOasrgEUdWvSKlDeBKUDBfhQVB = string.Empty;
			}
		}

		public string negativeDescriptiveName
		{
			get
			{
				if (!Application.isPlaying || !string.IsNullOrEmpty(_negativeDescriptiveName))
				{
					return _negativeDescriptiveName;
				}
				if (string.IsNullOrEmpty(ModHqwaUcoTlvAAlEJMgpZMvXtZA))
				{
					ModHqwaUcoTlvAAlEJMgpZMvXtZA = _descriptiveName + " -";
				}
				return ModHqwaUcoTlvAAlEJMgpZMvXtZA;
			}
			internal set
			{
				_negativeDescriptiveName = text;
				ModHqwaUcoTlvAAlEJMgpZMvXtZA = string.Empty;
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
				_behaviorId = num;
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
				_categoryId = num;
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
				_userAssignable = flag;
			}
		}

		public InputAction()
		{
		}

		public InputAction(InputAction P_0)
		{
			_id = P_0._id;
			_name = P_0._name;
			_type = P_0._type;
			_descriptiveName = P_0._descriptiveName;
			_positiveDescriptiveName = P_0._positiveDescriptiveName;
			_negativeDescriptiveName = P_0._negativeDescriptiveName;
			_behaviorId = P_0._behaviorId;
			_userAssignable = P_0._userAssignable;
			_categoryId = P_0.categoryId;
		}

		public InputAction Clone()
		{
			return new InputAction(this);
		}
	}
}
