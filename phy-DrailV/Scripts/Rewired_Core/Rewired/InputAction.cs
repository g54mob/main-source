using System;
using Rewired.Internal.Localization;
using UnityEngine;

namespace Rewired
{
	[Serializable]
	public sealed class InputAction : jtAeQMwqfCHdCmeHvhaRCqwDmBxb, dEyHRFFHMmNkBjyccsmusjbnHemDB
	{
		private const string keyCategory = "action";

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int _id;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string _name;

		[CustomObfuscation(rename = false)]
		[SerializeField]
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

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private bool _userAssignable;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private int _categoryId;

		[NonSerialized]
		private fSUOfhaSaMnPmZbrSYBbJiCCNniM SLPfoLEFsScnNhJxiHwVjPkEzuFMe;

		[NonSerialized]
		private int rDnRVTAZXyaVlJOBjDydLOTjrRpD;

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
				if (ReInput.isReady && SLPfoLEFsScnNhJxiHwVjPkEzuFMe != null)
				{
					SLPfoLEFsScnNhJxiHwVjPkEzuFMe.ijtdeCdNfQFeopbwLHgQcRDjMsVz();
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
				if (ReInput.isReady && SLPfoLEFsScnNhJxiHwVjPkEzuFMe != null)
				{
					SLPfoLEFsScnNhJxiHwVjPkEzuFMe.ugEcvEUjcYzrLriOHSDCiapaTNEm = OerfPdrzmyJxMEBpmWfYrbvPuUmM(_type);
				}
			}
		}

		public string descriptiveName
		{
			get
			{
				if (!ReInput.isReady || !LocalizationManager.isEnabled || SLPfoLEFsScnNhJxiHwVjPkEzuFMe == null)
				{
					return _descriptiveName;
				}
				return SLPfoLEFsScnNhJxiHwVjPkEzuFMe.jXwgbYbEpdqHGeBdCbXEcskUaWaFA;
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
				if (!ReInput.isReady || !LocalizationManager.isEnabled || SLPfoLEFsScnNhJxiHwVjPkEzuFMe == null)
				{
					return _positiveDescriptiveName;
				}
				return SLPfoLEFsScnNhJxiHwVjPkEzuFMe.nkieIDGTvoQOzfhnwqrRbpIBgcrw;
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
				if (!ReInput.isReady || !LocalizationManager.isEnabled || SLPfoLEFsScnNhJxiHwVjPkEzuFMe == null)
				{
					return _negativeDescriptiveName;
				}
				return SLPfoLEFsScnNhJxiHwVjPkEzuFMe.CWdJorNsJxtHBeABWaFvcIChQSiaA;
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
				if (ReInput.isReady && SLPfoLEFsScnNhJxiHwVjPkEzuFMe != null)
				{
					SLPfoLEFsScnNhJxiHwVjPkEzuFMe.OXcBXtPnTqYHpiucqKbwxkVzPkjf();
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
				if (ReInput.isReady && SLPfoLEFsScnNhJxiHwVjPkEzuFMe != null)
				{
					SLPfoLEFsScnNhJxiHwVjPkEzuFMe.iaqfIKjbRMPDFoCBbwPBerMeneZuA();
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
				if (ReInput.isReady && SLPfoLEFsScnNhJxiHwVjPkEzuFMe != null)
				{
					SLPfoLEFsScnNhJxiHwVjPkEzuFMe.lpXMARXdoqDjiJdhmRDgUetHrdBA();
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
				if (ReInput.isReady && SLPfoLEFsScnNhJxiHwVjPkEzuFMe != null)
				{
					SLPfoLEFsScnNhJxiHwVjPkEzuFMe.dsySnzlaDCdVTBdBHhqcOjWsSalGA();
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
				if (ReInput.isReady && SLPfoLEFsScnNhJxiHwVjPkEzuFMe != null)
				{
					SLPfoLEFsScnNhJxiHwVjPkEzuFMe.pjBoYQDQmYltEbIDwnlpAnwItxcv();
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
				if (ReInput.isReady && SLPfoLEFsScnNhJxiHwVjPkEzuFMe != null)
				{
					SLPfoLEFsScnNhJxiHwVjPkEzuFMe.uOrKQcLYTlGJqVnyiQqbMnhcLgPQ();
				}
			}
		}

		string jtAeQMwqfCHdCmeHvhaRCqwDmBxb.keyCategory => "action";

		string jtAeQMwqfCHdCmeHvhaRCqwDmBxb.scriptingName => _name;

		string jtAeQMwqfCHdCmeHvhaRCqwDmBxb.nonLocalizedDescriptiveName
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

		string dEyHRFFHMmNkBjyccsmusjbnHemDB.nonLocalizedPositiveDescriptiveName
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

		string dEyHRFFHMmNkBjyccsmusjbnHemDB.nonLocalizedNegativeDescriptiveName
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

		string jtAeQMwqfCHdCmeHvhaRCqwDmBxb.key => _key;

		string dEyHRFFHMmNkBjyccsmusjbnHemDB.positiveKey
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

		string dEyHRFFHMmNkBjyccsmusjbnHemDB.negativeKey
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

		int jtAeQMwqfCHdCmeHvhaRCqwDmBxb.autoGeneratedValueFlags
		{
			get
			{
				return rDnRVTAZXyaVlJOBjDydLOTjrRpD;
			}
			set
			{
				rDnRVTAZXyaVlJOBjDydLOTjrRpD = value;
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
			rDnRVTAZXyaVlJOBjDydLOTjrRpD = P_0.rDnRVTAZXyaVlJOBjDydLOTjrRpD;
		}

		public InputAction Clone()
		{
			return new InputAction(this);
		}

		public string GetDisplayName(AxisRange axisRange)
		{
			switch (axisRange)
			{
			case AxisRange.Full:
				return descriptiveName;
			case AxisRange.Positive:
				return positiveDescriptiveName;
			case AxisRange.Negative:
				return negativeDescriptiveName;
			default:
				throw new NotImplementedException();
			}
		}

		internal void zweOkwOYzJmmdPKMUZyDxJxHpxON()
		{
			if (SLPfoLEFsScnNhJxiHwVjPkEzuFMe == null)
			{
				SLPfoLEFsScnNhJxiHwVjPkEzuFMe = fSUOfhaSaMnPmZbrSYBbJiCCNniM.VxSNvmooWfTkIVcICGUZnqoUJPDW(this, OerfPdrzmyJxMEBpmWfYrbvPuUmM(_type), JSWalVgNfayAAqqgkCDSfWJdaAMTB.bETiEQbYCrQRqCLRvbSAcJMPkrdD.None);
			}
		}

		internal void vjLugohvsLblZuxYcbzfaOVaQPnA()
		{
			if (SLPfoLEFsScnNhJxiHwVjPkEzuFMe != null)
			{
				SLPfoLEFsScnNhJxiHwVjPkEzuFMe = null;
			}
		}

		private static JSWalVgNfayAAqqgkCDSfWJdaAMTB.VwAEfXIfCgCiohhuMMznDzgWRhLp OerfPdrzmyJxMEBpmWfYrbvPuUmM(InputActionType P_0)
		{
			switch (P_0)
			{
			case InputActionType.Axis:
				return JSWalVgNfayAAqqgkCDSfWJdaAMTB.VwAEfXIfCgCiohhuMMznDzgWRhLp.Axis;
			case InputActionType.Button:
				return JSWalVgNfayAAqqgkCDSfWJdaAMTB.VwAEfXIfCgCiohhuMMznDzgWRhLp.Button;
			default:
				throw new NotImplementedException();
			}
		}
	}
}
