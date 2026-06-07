using System;
using Rewired.Internal.Localization;
using UnityEngine;

namespace Rewired
{
	[Serializable]
	public sealed class InputAction : qlShIqeuHSIRhnLpCXWfkIdpMdpx, sZLAxvZSvDRmVjMjTVRhHfujppQp
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
		private gkctgEZVhaNoAAgauCngIQIuPebEA YgygTUEHDPPguYVzszQTPaRetHkmA;

		[NonSerialized]
		private int TQRHVOLzsPOAoxzZKPqeZrGxrljU;

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
				if (ReInput.isReady && YgygTUEHDPPguYVzszQTPaRetHkmA != null)
				{
					YgygTUEHDPPguYVzszQTPaRetHkmA.jTMhRUfClbiJAQhjtilGfcBvyqwjA();
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
				if (ReInput.isReady && YgygTUEHDPPguYVzszQTPaRetHkmA != null)
				{
					YgygTUEHDPPguYVzszQTPaRetHkmA.wmxpDuCFjDeAdhOVfyzrBCCDpMkT = jzHxfoZMvEtSSdJApAUciYYQTovr(_type);
				}
			}
		}

		public string descriptiveName
		{
			get
			{
				if (!ReInput.isReady || !LocalizationManager.isEnabled || YgygTUEHDPPguYVzszQTPaRetHkmA == null)
				{
					return _descriptiveName;
				}
				return YgygTUEHDPPguYVzszQTPaRetHkmA.HKQoqutKkgeGtFcRmtcKMQqgsDoY;
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
				if (!ReInput.isReady || !LocalizationManager.isEnabled || YgygTUEHDPPguYVzszQTPaRetHkmA == null)
				{
					return _positiveDescriptiveName;
				}
				return YgygTUEHDPPguYVzszQTPaRetHkmA.vqTJyxMIVweNIWENvOzgHIrQkYCw;
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
				if (!ReInput.isReady || !LocalizationManager.isEnabled || YgygTUEHDPPguYVzszQTPaRetHkmA == null)
				{
					return _negativeDescriptiveName;
				}
				return YgygTUEHDPPguYVzszQTPaRetHkmA.FktASepfaNwtFksADsQexzwgRpBn;
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
				if (ReInput.isReady && YgygTUEHDPPguYVzszQTPaRetHkmA != null)
				{
					YgygTUEHDPPguYVzszQTPaRetHkmA.yrhZMBOdOtpQsbmxygSzAaWtnMDfb();
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
				if (ReInput.isReady && YgygTUEHDPPguYVzszQTPaRetHkmA != null)
				{
					YgygTUEHDPPguYVzszQTPaRetHkmA.gfdeyNgRmeIQeqwHEklubgsnrpiBA();
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
				if (ReInput.isReady && YgygTUEHDPPguYVzszQTPaRetHkmA != null)
				{
					YgygTUEHDPPguYVzszQTPaRetHkmA.LojfYKiBhvXZsiErjRqzlvwEANumA();
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
				if (ReInput.isReady && YgygTUEHDPPguYVzszQTPaRetHkmA != null)
				{
					YgygTUEHDPPguYVzszQTPaRetHkmA.XIvHPuMcrskwDDbqHcWqpyJRLTkr();
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
				if (ReInput.isReady && YgygTUEHDPPguYVzszQTPaRetHkmA != null)
				{
					YgygTUEHDPPguYVzszQTPaRetHkmA.mFMkdpduWHHeUgsHviuqmEEMyKNJ();
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
				if (ReInput.isReady && YgygTUEHDPPguYVzszQTPaRetHkmA != null)
				{
					YgygTUEHDPPguYVzszQTPaRetHkmA.BIVTdIpnFUBwhhnXrMOryHDWffqBA();
				}
			}
		}

		string sZLAxvZSvDRmVjMjTVRhHfujppQp.keyCategory => "action";

		string sZLAxvZSvDRmVjMjTVRhHfujppQp.scriptingName => _name;

		string sZLAxvZSvDRmVjMjTVRhHfujppQp.nonLocalizedDescriptiveName
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

		string qlShIqeuHSIRhnLpCXWfkIdpMdpx.nonLocalizedPositiveDescriptiveName
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

		string qlShIqeuHSIRhnLpCXWfkIdpMdpx.nonLocalizedNegativeDescriptiveName
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

		string sZLAxvZSvDRmVjMjTVRhHfujppQp.key => _key;

		string qlShIqeuHSIRhnLpCXWfkIdpMdpx.positiveKey
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

		string qlShIqeuHSIRhnLpCXWfkIdpMdpx.negativeKey
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

		int sZLAxvZSvDRmVjMjTVRhHfujppQp.autoGeneratedValueFlags
		{
			get
			{
				return TQRHVOLzsPOAoxzZKPqeZrGxrljU;
			}
			set
			{
				TQRHVOLzsPOAoxzZKPqeZrGxrljU = value;
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
			TQRHVOLzsPOAoxzZKPqeZrGxrljU = P_0.TQRHVOLzsPOAoxzZKPqeZrGxrljU;
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

		internal void XSBrGDocNzGNEumBNLvaXDirZiqU()
		{
			if (YgygTUEHDPPguYVzszQTPaRetHkmA == null)
			{
				YgygTUEHDPPguYVzszQTPaRetHkmA = gkctgEZVhaNoAAgauCngIQIuPebEA.CDLcarTXuFFRAkPbVQuzbKUPLlEI(this, jzHxfoZMvEtSSdJApAUciYYQTovr(_type), MJyJuisFiOmfspJhIRvXPkFSAPFT.GtxbKiHSwksUKuQYeAEqHnCDMtFmA.None);
			}
		}

		internal void sHnLjgWYIHHPZjxUAzGWJNoySllc()
		{
			if (YgygTUEHDPPguYVzszQTPaRetHkmA != null)
			{
				YgygTUEHDPPguYVzszQTPaRetHkmA = null;
			}
		}

		private static MJyJuisFiOmfspJhIRvXPkFSAPFT.jZSMnsLXoBDMhquJQKqHviQNprmC jzHxfoZMvEtSSdJApAUciYYQTovr(InputActionType P_0)
		{
			return P_0 switch
			{
				InputActionType.Axis => MJyJuisFiOmfspJhIRvXPkFSAPFT.jZSMnsLXoBDMhquJQKqHviQNprmC.Axis, 
				InputActionType.Button => MJyJuisFiOmfspJhIRvXPkFSAPFT.jZSMnsLXoBDMhquJQKqHviQNprmC.Button, 
				_ => throw new NotImplementedException(), 
			};
		}
	}
}
