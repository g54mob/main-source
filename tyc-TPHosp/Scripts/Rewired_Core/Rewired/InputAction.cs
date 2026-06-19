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

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string _negativeDescriptiveName;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private int _behaviorId;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private bool _userAssignable;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private int _categoryId;

		[NonSerialized]
		private string BGaOgcznYMzoqwTOrZEUpVrYAN;

		[NonSerialized]
		private string XgZKzNCZFOWpTDGDPAQIKoXkElqK;

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
				if (!Application.isPlaying || !string.IsNullOrEmpty(_positiveDescriptiveName))
				{
					return _positiveDescriptiveName;
				}
				if (string.IsNullOrEmpty(BGaOgcznYMzoqwTOrZEUpVrYAN))
				{
					BGaOgcznYMzoqwTOrZEUpVrYAN = _descriptiveName + " +";
				}
				return BGaOgcznYMzoqwTOrZEUpVrYAN;
			}
			internal set
			{
				_positiveDescriptiveName = value;
				BGaOgcznYMzoqwTOrZEUpVrYAN = string.Empty;
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
				if (string.IsNullOrEmpty(XgZKzNCZFOWpTDGDPAQIKoXkElqK))
				{
					XgZKzNCZFOWpTDGDPAQIKoXkElqK = _descriptiveName + " -";
				}
				return XgZKzNCZFOWpTDGDPAQIKoXkElqK;
			}
			internal set
			{
				_negativeDescriptiveName = value;
				XgZKzNCZFOWpTDGDPAQIKoXkElqK = string.Empty;
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
