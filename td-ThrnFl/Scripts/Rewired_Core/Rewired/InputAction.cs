using System;
using Rewired.Internal.Localization;
using UnityEngine;

namespace Rewired
{
	[Serializable]
	public sealed class InputAction : LiukxMkkUUmGsEJaoRyGyuSBQfoS, LnhaMJXLiFbdSGpizhhMTtFDjtXy
	{
		private const string keyCategory = "action";

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
		private string _key;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string _positiveKey;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string _negativeKey;

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
		private TNQxJyLFuiRxLtJnKaNXOsxGIasX drWdeuCJWXFpzQquWdasUwaWpHftA;

		[NonSerialized]
		private int cevikwHKjRgVbUPQsASPXGbXtQcL;

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
				if (ReInput.isReady && drWdeuCJWXFpzQquWdasUwaWpHftA != null)
				{
					drWdeuCJWXFpzQquWdasUwaWpHftA.AeqSUmtDwbcYLrhaTtXtwzoJTozq();
				}
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
				if (ReInput.isReady && drWdeuCJWXFpzQquWdasUwaWpHftA != null)
				{
					drWdeuCJWXFpzQquWdasUwaWpHftA.LJXAbEKxmDHBiYmUZFbAJTxfIUxj = QYbuCEXXuGKDTMdHPZkByLjgNqko(_type);
				}
			}
		}

		public string descriptiveName
		{
			get
			{
				if (!ReInput.isReady || !LocalizationManager.isEnabled || drWdeuCJWXFpzQquWdasUwaWpHftA == null)
				{
					return _descriptiveName;
				}
				return drWdeuCJWXFpzQquWdasUwaWpHftA.qJkqRAxrrocPcPhIKAOpCMJUoZxfA;
			}
			internal set
			{
				nonLocalizedDescriptiveName = text;
			}
		}

		public string positiveDescriptiveName
		{
			get
			{
				if (!ReInput.isReady || !LocalizationManager.isEnabled || drWdeuCJWXFpzQquWdasUwaWpHftA == null)
				{
					return _positiveDescriptiveName;
				}
				return drWdeuCJWXFpzQquWdasUwaWpHftA.UDfFJNMhCyBCNIpQLiHPdXQolEJqA;
			}
			internal set
			{
				nonLocalizedPositiveDescriptiveName = text;
			}
		}

		public string negativeDescriptiveName
		{
			get
			{
				if (!ReInput.isReady || !LocalizationManager.isEnabled || drWdeuCJWXFpzQquWdasUwaWpHftA == null)
				{
					return _negativeDescriptiveName;
				}
				return drWdeuCJWXFpzQquWdasUwaWpHftA.uHNCrEpNbRlmMRKTnwRRnCRKxuSl;
			}
			internal set
			{
				nonLocalizedNegativeDescriptiveName = text;
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

		[CustomObfuscation(rename = false)]
		internal string key
		{
			get
			{
				return _key;
			}
			set
			{
				_key = value;
				if (ReInput.isReady && drWdeuCJWXFpzQquWdasUwaWpHftA != null)
				{
					drWdeuCJWXFpzQquWdasUwaWpHftA.VFHulbCONdrHnQmgMqwKyHtRlYIr();
				}
			}
		}

		[CustomObfuscation(rename = false)]
		internal string positiveKey
		{
			get
			{
				return _positiveKey;
			}
			set
			{
				_positiveKey = value;
				if (ReInput.isReady && drWdeuCJWXFpzQquWdasUwaWpHftA != null)
				{
					drWdeuCJWXFpzQquWdasUwaWpHftA.VuVdZdXGdeIJzaBSwYHRlsLFNplKA();
				}
			}
		}

		[CustomObfuscation(rename = false)]
		internal string negativeKey
		{
			get
			{
				return _negativeKey;
			}
			set
			{
				_negativeKey = value;
				if (ReInput.isReady && drWdeuCJWXFpzQquWdasUwaWpHftA != null)
				{
					drWdeuCJWXFpzQquWdasUwaWpHftA.qlVAzkNPkdiObBjuNJQIapVdyFbBB();
				}
			}
		}

		[CustomObfuscation(rename = false)]
		internal string nonLocalizedDescriptiveName
		{
			get
			{
				return _descriptiveName;
			}
			set
			{
				_descriptiveName = value;
				if (ReInput.isReady && drWdeuCJWXFpzQquWdasUwaWpHftA != null)
				{
					drWdeuCJWXFpzQquWdasUwaWpHftA.wkNCiIKcomvvEiZxnJmXtmqxRPdW();
				}
			}
		}

		[CustomObfuscation(rename = false)]
		internal string nonLocalizedPositiveDescriptiveName
		{
			get
			{
				return _positiveDescriptiveName;
			}
			set
			{
				_positiveDescriptiveName = value;
				if (ReInput.isReady && drWdeuCJWXFpzQquWdasUwaWpHftA != null)
				{
					drWdeuCJWXFpzQquWdasUwaWpHftA.BrqPcLzhJFhYTJVIHnKPgptmKoCR();
				}
			}
		}

		[CustomObfuscation(rename = false)]
		internal string nonLocalizedNegativeDescriptiveName
		{
			get
			{
				return _negativeDescriptiveName;
			}
			set
			{
				_negativeDescriptiveName = value;
				if (ReInput.isReady && drWdeuCJWXFpzQquWdasUwaWpHftA != null)
				{
					drWdeuCJWXFpzQquWdasUwaWpHftA.oTvzCizjOSehqAUOHakMGgqsXjxJA();
				}
			}
		}

		string LnhaMJXLiFbdSGpizhhMTtFDjtXy.keyCategory => "action";

		string LnhaMJXLiFbdSGpizhhMTtFDjtXy.scriptingName => _name;

		string LnhaMJXLiFbdSGpizhhMTtFDjtXy.nonLocalizedDescriptiveName
		{
			get
			{
				return _descriptiveName;
			}
			set
			{
				_descriptiveName = value;
			}
		}

		string LiukxMkkUUmGsEJaoRyGyuSBQfoS.nonLocalizedPositiveDescriptiveName
		{
			get
			{
				return _positiveDescriptiveName;
			}
			set
			{
				_positiveDescriptiveName = value;
			}
		}

		string LiukxMkkUUmGsEJaoRyGyuSBQfoS.nonLocalizedNegativeDescriptiveName
		{
			get
			{
				return _negativeDescriptiveName;
			}
			set
			{
				_negativeDescriptiveName = value;
			}
		}

		string LnhaMJXLiFbdSGpizhhMTtFDjtXy.key => _key;

		string LiukxMkkUUmGsEJaoRyGyuSBQfoS.positiveKey
		{
			get
			{
				return _positiveKey;
			}
			set
			{
				_positiveKey = value;
			}
		}

		string LiukxMkkUUmGsEJaoRyGyuSBQfoS.negativeKey
		{
			get
			{
				return _negativeKey;
			}
			set
			{
				_negativeKey = value;
			}
		}

		int LnhaMJXLiFbdSGpizhhMTtFDjtXy.autoGeneratedValueFlags
		{
			get
			{
				return cevikwHKjRgVbUPQsASPXGbXtQcL;
			}
			set
			{
				cevikwHKjRgVbUPQsASPXGbXtQcL = value;
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
			_key = P_0._key;
			_positiveKey = P_0._positiveKey;
			_negativeKey = P_0._negativeKey;
			_behaviorId = P_0._behaviorId;
			_userAssignable = P_0._userAssignable;
			_categoryId = P_0.categoryId;
			cevikwHKjRgVbUPQsASPXGbXtQcL = P_0.cevikwHKjRgVbUPQsASPXGbXtQcL;
		}

		public InputAction Clone()
		{
			return new InputAction(this);
		}

		public string GetDisplayName(AxisRange axisRange)
		{
			return axisRange switch
			{
				AxisRange.Full => descriptiveName, 
				AxisRange.Positive => positiveDescriptiveName, 
				AxisRange.Negative => negativeDescriptiveName, 
				_ => throw new NotImplementedException(), 
			};
		}

		internal void aTbcAviiUnBATXVIbBJPfHPZpgpYA()
		{
			if (drWdeuCJWXFpzQquWdasUwaWpHftA == null)
			{
				drWdeuCJWXFpzQquWdasUwaWpHftA = TNQxJyLFuiRxLtJnKaNXOsxGIasX.vMrZQVFKhTIzVZesfusSdxndPUDG(this, QYbuCEXXuGKDTMdHPZkByLjgNqko(_type), jjEiJGkdrKfqxJAsceTeoFkgoNMlA.veVjxECKraSLRuRJUJeBWprfCtQDb.None);
			}
		}

		internal void PPfyWKkJPsWCIGoaVVtZksQcYwT()
		{
			if (drWdeuCJWXFpzQquWdasUwaWpHftA != null)
			{
				drWdeuCJWXFpzQquWdasUwaWpHftA = null;
			}
		}

		private static jjEiJGkdrKfqxJAsceTeoFkgoNMlA.AqybaYFDSFEDwBRnsokwpBTdIblQ QYbuCEXXuGKDTMdHPZkByLjgNqko(InputActionType P_0)
		{
			return P_0 switch
			{
				InputActionType.Axis => jjEiJGkdrKfqxJAsceTeoFkgoNMlA.AqybaYFDSFEDwBRnsokwpBTdIblQ.Axis, 
				InputActionType.Button => jjEiJGkdrKfqxJAsceTeoFkgoNMlA.AqybaYFDSFEDwBRnsokwpBTdIblQ.Button, 
				_ => throw new NotImplementedException(), 
			};
		}
	}
}
