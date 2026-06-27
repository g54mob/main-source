using System;
using System.Collections.Generic;
using Rewired.Data.Mapping;
using Rewired.Interfaces;
using Rewired.Internal.Glyphs;
using Rewired.Internal.Localization;
using UnityEngine;

namespace Rewired
{
	[Serializable]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	public class ControllerTemplateElementIdentifier : IControllerElementIdentifierCommon_Internal, IControllerTemplateElementIdentifier, bXtOivlsOYjkGZtzvdtdZjoKDUCF, leeNpeIpkRWAaDYnewmtyKpQcRpw, hWHawgOADYRYslwTpcXmtDidkGPQ, VXuSsTlJoBHbugAzwdYIdycaHtQaB, jmJlodmyeuTJffDdVhrvxnUdztWH, euWsBsFZlnKdNdwSzRGQMkIVzLgq
	{
		[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
		internal class nntsfwyhAKvCOfUsBarOOatDkWNt
		{
			public int id;

			public string name;

			public string positiveName;

			public string negativeName;

			public string key;

			public string positiveKey;

			public string negativeKey;

			public ControllerTemplateElementType elementType;
		}

		internal sealed class QAIAdMIUYcOJjVJFlWJmegzpnbOIA
		{
			[Serializable]
			private sealed class SxfiDdTCjrCMXZhJCDfrdHHtgXzu
			{
				public static readonly SxfiDdTCjrCMXZhJCDfrdHHtgXzu _003C_003E9 = new SxfiDdTCjrCMXZhJCDfrdHHtgXzu();

				public static Func<ControllerTemplateElementIdentifier, ControllerTemplateElementIdentifier, bool> _003C_003E9__4_0;

				internal bool gYvWLPNwRwDyvSfxzpPSVGCMwEQm(ControllerTemplateElementIdentifier P_0, ControllerTemplateElementIdentifier P_1)
				{
					if (P_0 == null || P_1 == null)
					{
						return false;
					}
					if (P_0 != null && P_1 != null && P_0.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid == P_1.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid && P_0.Rewired_002EInterfaces_002EIControllerTemplateElementIdentifier_002EelementType == P_1.Rewired_002EInterfaces_002EIControllerTemplateElementIdentifier_002EelementType)
					{
						return string.Equals(P_0.key, P_1.key, StringComparison.Ordinal);
					}
					return false;
				}
			}

			private static QAIAdMIUYcOJjVJFlWJmegzpnbOIA LmfhUsWqddVfTtuQMKvrVVimTXwQ;

			private readonly global::NijeqNRuOtTHOXfLLAdncronsTLUA<ControllerTemplateElementIdentifier> bpjFIeeUprnhDBarFOntgDICShJjD;

			private static QAIAdMIUYcOJjVJFlWJmegzpnbOIA KdjfKWDevAkjEUpfHRsmcIAcytvRb
			{
				get
				{
					if (LmfhUsWqddVfTtuQMKvrVVimTXwQ != null)
					{
						return LmfhUsWqddVfTtuQMKvrVVimTXwQ;
					}
					LmfhUsWqddVfTtuQMKvrVVimTXwQ = new QAIAdMIUYcOJjVJFlWJmegzpnbOIA();
					LmfhUsWqddVfTtuQMKvrVVimTXwQ.MbfysEItgTrUHjMfKFdGIwaCAJSh();
					return LmfhUsWqddVfTtuQMKvrVVimTXwQ;
				}
			}

			private QAIAdMIUYcOJjVJFlWJmegzpnbOIA()
			{
				bpjFIeeUprnhDBarFOntgDICShJjD = new global::NijeqNRuOtTHOXfLLAdncronsTLUA<ControllerTemplateElementIdentifier>(SxfiDdTCjrCMXZhJCDfrdHHtgXzu._003C_003E9.gYvWLPNwRwDyvSfxzpPSVGCMwEQm);
			}

			private void MbfysEItgTrUHjMfKFdGIwaCAJSh()
			{
				ReInput.ShutDownEvent += LmfhUsWqddVfTtuQMKvrVVimTXwQ.AubtEzzXMpEkXtkXobCVdAaHXlfbA;
			}

			private void AubtEzzXMpEkXtkXobCVdAaHXlfbA()
			{
				if (LmfhUsWqddVfTtuQMKvrVVimTXwQ == this)
				{
					LmfhUsWqddVfTtuQMKvrVVimTXwQ = null;
				}
				ReInput.ShutDownEvent -= AubtEzzXMpEkXtkXobCVdAaHXlfbA;
			}

			public static ControllerTemplateElementIdentifier SJhCgHUAeYtxkAJGcmehlxtaLfYh(DeviceLocalizationInfo P_0, ControllerTemplateElementIdentifier P_1)
			{
				return KdjfKWDevAkjEUpfHRsmcIAcytvRb.bpjFIeeUprnhDBarFOntgDICShJjD.wxUbEGFQBfjePUsdQYoNnyHInQFpA(P_0.hash, P_1);
			}

			public static bool vWgKztWlWwTAwDDozARTAQmOPPicb(DeviceLocalizationInfo P_0, ControllerTemplateElementIdentifier P_1, out ControllerTemplateElementIdentifier P_2)
			{
				return KdjfKWDevAkjEUpfHRsmcIAcytvRb.bpjFIeeUprnhDBarFOntgDICShJjD.SYZFKzfaOuaZyGqwgDHDIzPBmdSrA(P_0.hash, P_1, out P_2);
			}

			public static void eXMOTdqLTRYjZAgbeDoNcnVMqGpK(DeviceLocalizationInfo P_0, ControllerTemplateElementIdentifier P_1)
			{
				KdjfKWDevAkjEUpfHRsmcIAcytvRb.bpjFIeeUprnhDBarFOntgDICShJjD.tsZmAlwqEXvBYjcnUbtXfqwZjrMo(P_0.hash, P_1);
			}
		}

		private class QkcbDMcEYUArSXgRsaeOSHwlAEVh
		{
			[SerializeField]
			private string yOTDceHtjmekAMdIpBFesrutPkbQ;

			[SerializeField]
			private string DJkpNvxLZLGrrLBDQIfIeDOCpwPy;

			public string ycISxawYQCmPVswbfwvHJCmehCHAA
			{
				get
				{
					return yOTDceHtjmekAMdIpBFesrutPkbQ;
				}
				set
				{
					yOTDceHtjmekAMdIpBFesrutPkbQ = text;
				}
			}

			public string DpEsSLOfeVooXTQOmvPDuGHhcOkb
			{
				get
				{
					return DJkpNvxLZLGrrLBDQIfIeDOCpwPy;
				}
				set
				{
					DJkpNvxLZLGrrLBDQIfIeDOCpwPy = dJkpNvxLZLGrrLBDQIfIeDOCpwPy;
				}
			}

			public QkcbDMcEYUArSXgRsaeOSHwlAEVh()
			{
			}

			public QkcbDMcEYUArSXgRsaeOSHwlAEVh(QkcbDMcEYUArSXgRsaeOSHwlAEVh P_0)
			{
				yOTDceHtjmekAMdIpBFesrutPkbQ = P_0.yOTDceHtjmekAMdIpBFesrutPkbQ;
				DJkpNvxLZLGrrLBDQIfIeDOCpwPy = P_0.DJkpNvxLZLGrrLBDQIfIeDOCpwPy;
			}
		}

		private const string sHUcRFbrNNlrrePuhlmiGSNbqMdeB = "controller/template";

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int _id;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string _name;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string _positiveName;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string _negativeName;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		public string _key;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		public string _positiveKey;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		public string _negativeKey;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private ControllerTemplateElementType _elementType;

		[NonSerialized]
		private fdpfgJnMxjBVlnubvZxxSwBKSBwH WSoZdBCpSWDDwnonzaOqskSUbXiE;

		[NonSerialized]
		private CnQiCatlxaadkclyJFnfOigtKbyIA CtoQipFFrKzDUbhBdhoifGsHFIaeb;

		[NonSerialized]
		private AeIojEYKXjMwXFAZvRJEHSgNgyZw WsvFSfIkqOcuFdDqITFgMvjJEYEmc;

		[NonSerialized]
		private AUYmHhEeGVjKOWUHIgbqgMlToqEAA bUUBMCBfilnnaWPpWTwSfTqHzXrTA;

		[NonSerialized]
		private DeviceLocalizationInfo ggNCrCLuBcCvGVfMrahpIpbnkRSs;

		[NonSerialized]
		private int vHlQKVmlffckwPWYGHlyjhWBYQOs;

		[NonSerialized]
		private List<QkcbDMcEYUArSXgRsaeOSHwlAEVh> KtZcjRPCWBrUHimJxXDFXsdnwtuO;

		int IControllerElementIdentifierCommon_Internal.id => _id;

		string IControllerElementIdentifierCommon_Internal.name
		{
			get
			{
				if (!ReInput.isReady || WSoZdBCpSWDDwnonzaOqskSUbXiE == null || !LocalizationManager.isEnabled)
				{
					return _name;
				}
				return WSoZdBCpSWDDwnonzaOqskSUbXiE.YYpaixksduwqUQfFFmPUzWfHjhDu;
			}
			internal set
			{
				nonLocalizedName = value;
			}
		}

		string IControllerElementIdentifierCommon_Internal.positiveName
		{
			get
			{
				if (!ReInput.isReady || WSoZdBCpSWDDwnonzaOqskSUbXiE == null || !LocalizationManager.isEnabled)
				{
					return _positiveName;
				}
				return WSoZdBCpSWDDwnonzaOqskSUbXiE.iLiuzsLDQkvHfcjDCcGykVsvicft;
			}
			internal set
			{
				nonLocalizedPositiveName = value;
			}
		}

		string IControllerElementIdentifierCommon_Internal.negativeName
		{
			get
			{
				if (!ReInput.isReady || WSoZdBCpSWDDwnonzaOqskSUbXiE == null || !LocalizationManager.isEnabled)
				{
					return _negativeName;
				}
				return WSoZdBCpSWDDwnonzaOqskSUbXiE.CzMNKjcKhXiLoSCUyZnmWlpFrLws;
			}
			internal set
			{
				nonLocalizedNegativeName = value;
			}
		}

		ControllerTemplateElementType IControllerTemplateElementIdentifier.elementType => _elementType;

		internal virtual bool useEditorElementTypeOverride => false;

		internal virtual ControllerElementType editorElementTypeOverride
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		public object glyph
		{
			get
			{
				if (!ReInput.isReady || WsvFSfIkqOcuFdDqITFgMvjJEYEmc == null || !GlyphManager.isEnabled)
				{
					return null;
				}
				return WsvFSfIkqOcuFdDqITFgMvjJEYEmc.DOWjBOgoZsencABrFfHqopRtxZvy;
			}
		}

		public object positiveGlyph
		{
			get
			{
				if (!ReInput.isReady || WsvFSfIkqOcuFdDqITFgMvjJEYEmc == null || !GlyphManager.isEnabled)
				{
					return null;
				}
				return WsvFSfIkqOcuFdDqITFgMvjJEYEmc.wmuNdKUkrnkWpjuvYITjKzyigQIt;
			}
		}

		public object negativeGlyph
		{
			get
			{
				if (!ReInput.isReady || WsvFSfIkqOcuFdDqITFgMvjJEYEmc == null || !GlyphManager.isEnabled)
				{
					return null;
				}
				return WsvFSfIkqOcuFdDqITFgMvjJEYEmc.sWYnzYgdXPvOelpjXPXbjLkADKfr;
			}
		}

		private string finalGlyphKey
		{
			get
			{
				if (!ReInput.isReady || WsvFSfIkqOcuFdDqITFgMvjJEYEmc == null || !GlyphManager.isEnabled)
				{
					return null;
				}
				return WsvFSfIkqOcuFdDqITFgMvjJEYEmc.QfGGjPDMKogvJjFpIQxHufrcaNNt;
			}
		}

		private string finalPositiveGlyphKey
		{
			get
			{
				if (!ReInput.isReady || WsvFSfIkqOcuFdDqITFgMvjJEYEmc == null || !GlyphManager.isEnabled)
				{
					return null;
				}
				return WsvFSfIkqOcuFdDqITFgMvjJEYEmc.QrHHSNOiylXNliXvWTuJqpBeNbxv;
			}
		}

		private string finalNegativeGlyphKey
		{
			get
			{
				if (!ReInput.isReady || WsvFSfIkqOcuFdDqITFgMvjJEYEmc == null || !GlyphManager.isEnabled)
				{
					return null;
				}
				return WsvFSfIkqOcuFdDqITFgMvjJEYEmc.HHBrebMxBkmjqfbRGBIUbVgJzyuA;
			}
		}

		internal string nonLocalizedName
		{
			get
			{
				return _name;
			}
			set
			{
				_name = value;
				if (ReInput.isReady && WSoZdBCpSWDDwnonzaOqskSUbXiE != null)
				{
					WSoZdBCpSWDDwnonzaOqskSUbXiE.GvKqFlBIauBSccpqkijaDCUIwlHHB();
				}
			}
		}

		internal string nonLocalizedPositiveName
		{
			get
			{
				return _positiveName;
			}
			set
			{
				_positiveName = value;
				if (ReInput.isReady && WSoZdBCpSWDDwnonzaOqskSUbXiE != null)
				{
					WSoZdBCpSWDDwnonzaOqskSUbXiE.lBnLmeaxZDkhxYoPMPJqXmFtBMet();
				}
			}
		}

		internal string nonLocalizedNegativeName
		{
			get
			{
				return _negativeName;
			}
			set
			{
				_negativeName = value;
				if (ReInput.isReady && WSoZdBCpSWDDwnonzaOqskSUbXiE != null)
				{
					WSoZdBCpSWDDwnonzaOqskSUbXiE.QywrBRmSUSMMOTNxYjMpHKVxFPHD();
				}
			}
		}

		public string key => _key;

		public string positiveKey => _positiveKey;

		public string negativeKey => _negativeKey;

		string IControllerElementIdentifierCommon_Internal.nonLocalizedName => nonLocalizedName;

		string IControllerElementIdentifierCommon_Internal.nonLocalizedPositiveName => nonLocalizedPositiveName;

		string IControllerElementIdentifierCommon_Internal.nonLocalizedNegativeName => nonLocalizedNegativeName;

		bool IControllerElementIdentifierCommon_Internal.isNonLocalizedPositiveNameAutoGenerated => (vHlQKVmlffckwPWYGHlyjhWBYQOs & 2) != 0;

		bool IControllerElementIdentifierCommon_Internal.isNonLocalizedNegativeNameAutoGenerated => (vHlQKVmlffckwPWYGHlyjhWBYQOs & 4) != 0;

		bool IControllerElementIdentifierCommon_Internal.isPositiveKeyAutoGenerated => (vHlQKVmlffckwPWYGHlyjhWBYQOs & 8) != 0;

		bool IControllerElementIdentifierCommon_Internal.isNegativeKeyAutoGenerated => (vHlQKVmlffckwPWYGHlyjhWBYQOs & 0x10) != 0;

		string IControllerElementIdentifierCommon_Internal.key => _key;

		string IControllerElementIdentifierCommon_Internal.positiveKey => _positiveKey;

		string IControllerElementIdentifierCommon_Internal.negativeKey => _negativeKey;

		DeviceLocalizationInfo IControllerElementIdentifierCommon_Internal.deviceLocalizationInfo => ggNCrCLuBcCvGVfMrahpIpbnkRSs;

		object IControllerElementIdentifierCommon_Internal.elementType => _elementType;

		bool IControllerElementIdentifierCommon_Internal.useEditorElementTypeOverride => useEditorElementTypeOverride;

		ControllerElementType IControllerElementIdentifierCommon_Internal.editorElementTypeOverride => editorElementTypeOverride;

		string leeNpeIpkRWAaDYnewmtyKpQcRpw.keyCategory => "controller/template";

		string leeNpeIpkRWAaDYnewmtyKpQcRpw.scriptingName => _name;

		string leeNpeIpkRWAaDYnewmtyKpQcRpw.nonLocalizedDescriptiveName
		{
			get
			{
				return _name;
			}
			set
			{
				_name = value;
			}
		}

		string bXtOivlsOYjkGZtzvdtdZjoKDUCF.nonLocalizedPositiveDescriptiveName
		{
			get
			{
				return _positiveName;
			}
			set
			{
				_positiveName = value;
			}
		}

		string bXtOivlsOYjkGZtzvdtdZjoKDUCF.nonLocalizedNegativeDescriptiveName
		{
			get
			{
				return _negativeName;
			}
			set
			{
				_negativeName = value;
			}
		}

		string leeNpeIpkRWAaDYnewmtyKpQcRpw.key => _key;

		string bXtOivlsOYjkGZtzvdtdZjoKDUCF.positiveKey
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

		string bXtOivlsOYjkGZtzvdtdZjoKDUCF.negativeKey
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

		int leeNpeIpkRWAaDYnewmtyKpQcRpw.autoGeneratedValueFlags
		{
			get
			{
				return vHlQKVmlffckwPWYGHlyjhWBYQOs;
			}
			set
			{
				vHlQKVmlffckwPWYGHlyjhWBYQOs = value;
			}
		}

		string VXuSsTlJoBHbugAzwdYIdycaHtQaB.keyCategory => "controller/template";

		string VXuSsTlJoBHbugAzwdYIdycaHtQaB.key => _key;

		int VXuSsTlJoBHbugAzwdYIdycaHtQaB.autoGeneratedValueFlags
		{
			get
			{
				return vHlQKVmlffckwPWYGHlyjhWBYQOs;
			}
			set
			{
				vHlQKVmlffckwPWYGHlyjhWBYQOs = value;
			}
		}

		string hWHawgOADYRYslwTpcXmtDidkGPQ.positiveKey
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

		string hWHawgOADYRYslwTpcXmtDidkGPQ.negativeKey
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

		internal string GetCompoundElementSpecialName(int index)
		{
			if (!ReInput.isReady || !LocalizationManager.isEnabled || KtZcjRPCWBrUHimJxXDFXsdnwtuO == null || CtoQipFFrKzDUbhBdhoifGsHFIaeb == null)
			{
				return string.Empty;
			}
			return CtoQipFFrKzDUbhBdhoifGsHFIaeb.GKfACuKlEeaAGEWnfvjBJwNbGKcuC(index);
		}

		internal object GetCompoundElementSpecialGlyph(int index)
		{
			if (!ReInput.isReady || !GlyphManager.isEnabled || KtZcjRPCWBrUHimJxXDFXsdnwtuO == null || bUUBMCBfilnnaWPpWTwSfTqHzXrTA == null)
			{
				return null;
			}
			return bUUBMCBfilnnaWPpWTwSfTqHzXrTA.LOdXDFSNhfdfWiycbFWLGaBiZNGX(index);
		}

		string IControllerElementIdentifierCommon_Internal.GetSpecialElementNonLocalizedName(int index)
		{
			if (KtZcjRPCWBrUHimJxXDFXsdnwtuO == null || (uint)index >= (uint)KtZcjRPCWBrUHimJxXDFXsdnwtuO.Count)
			{
				return null;
			}
			return KtZcjRPCWBrUHimJxXDFXsdnwtuO[index].DpEsSLOfeVooXTQOmvPDuGHhcOkb;
		}

		string IControllerElementIdentifierCommon_Internal.GetSpecialElementKey(int index)
		{
			if (KtZcjRPCWBrUHimJxXDFXsdnwtuO == null || (uint)index >= (uint)KtZcjRPCWBrUHimJxXDFXsdnwtuO.Count)
			{
				return null;
			}
			return KtZcjRPCWBrUHimJxXDFXsdnwtuO[index].ycISxawYQCmPVswbfwvHJCmehCHAA;
		}

		public ControllerTemplateElementIdentifier()
		{
		}

		public ControllerTemplateElementIdentifier(ControllerTemplateElementIdentifier P_0)
		{
			_id = P_0._id;
			_name = P_0._name;
			_positiveName = P_0._positiveName;
			_negativeName = P_0._negativeName;
			_key = P_0._key;
			_positiveKey = P_0._positiveKey;
			_negativeKey = P_0._negativeKey;
			_elementType = P_0._elementType;
			if (P_0.KtZcjRPCWBrUHimJxXDFXsdnwtuO != null)
			{
				int count = P_0.KtZcjRPCWBrUHimJxXDFXsdnwtuO.Count;
				KtZcjRPCWBrUHimJxXDFXsdnwtuO = new List<QkcbDMcEYUArSXgRsaeOSHwlAEVh>(count);
				for (int i = 0; i < count; i++)
				{
					if (P_0.KtZcjRPCWBrUHimJxXDFXsdnwtuO[i] != null)
					{
						KtZcjRPCWBrUHimJxXDFXsdnwtuO.Add(new QkcbDMcEYUArSXgRsaeOSHwlAEVh(P_0.KtZcjRPCWBrUHimJxXDFXsdnwtuO[i]));
					}
				}
			}
			vHlQKVmlffckwPWYGHlyjhWBYQOs = P_0.vHlQKVmlffckwPWYGHlyjhWBYQOs;
		}

		internal ControllerTemplateElementIdentifier(nntsfwyhAKvCOfUsBarOOatDkWNt P_0)
		{
			if (P_0 == null)
			{
				throw new ArgumentNullException("initOptions");
			}
			_id = P_0.id;
			_name = P_0.name;
			_positiveName = P_0.positiveName;
			_negativeName = P_0.negativeName;
			_key = P_0.key;
			_positiveKey = P_0.positiveKey;
			_negativeKey = P_0.negativeKey;
			_elementType = P_0.elementType;
		}

		internal ControllerTemplateElementIdentifier(ControllerTemplateElementIdentifier P_0, ControllerTemplateElementType P_1, bool P_2)
			: this(P_0)
		{
			_elementType = P_1;
		}

		public virtual ControllerTemplateElementIdentifier Clone()
		{
			return new ControllerTemplateElementIdentifier(this);
		}

		public string GetDisplayName(AxisRange axisRange)
		{
			return _elementType switch
			{
				ControllerTemplateElementType.Axis => axisRange switch
				{
					AxisRange.Full => Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename, 
					AxisRange.Positive => Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002EpositiveName, 
					AxisRange.Negative => Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002EnegativeName, 
					_ => throw new NotImplementedException(), 
				}, 
				_ => Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename, 
			};
		}

		public object GetGlyph(AxisRange axisRange)
		{
			return _elementType switch
			{
				ControllerTemplateElementType.Axis => axisRange switch
				{
					AxisRange.Full => glyph, 
					AxisRange.Positive => positiveGlyph, 
					AxisRange.Negative => negativeGlyph, 
					_ => throw new NotImplementedException(), 
				}, 
				_ => glyph, 
			};
		}

		public string GetFinalGlyphKey(AxisRange axisRange)
		{
			return _elementType switch
			{
				ControllerTemplateElementType.Axis => axisRange switch
				{
					AxisRange.Full => finalGlyphKey, 
					AxisRange.Positive => finalPositiveGlyphKey, 
					AxisRange.Negative => finalNegativeGlyphKey, 
					_ => throw new NotImplementedException(), 
				}, 
				_ => finalGlyphKey, 
			};
		}

		internal ControllerElementIdentifier ToControllerElementIdentifier(IHardwareControllerMap_Internal hardwareControllerMap)
		{
			ControllerElementIdentifier controllerElementIdentifier = new ControllerElementIdentifier(new ControllerElementIdentifier.bSeqdIyVjkTFqqpLamBpjhuEDWyN
			{
				id = _id,
				name = _name,
				positiveName = _positiveName,
				negativeName = _negativeName,
				key = _key,
				positiveKey = _positiveKey,
				negativeKey = _negativeKey,
				elementType = moNrVnhMyxFSevnVWYTclYHmdtVI.dCqlSqVXwvunrbuwgbTXXLOvGmWfA(_elementType),
				compoundElementType = CompoundControllerElementType.Axis2D
			});
			if (ReInput.isReady && ggNCrCLuBcCvGVfMrahpIpbnkRSs != null && hardwareControllerMap != null)
			{
				DeviceLocalizationInfo deviceLocalizationInfo = new DeviceLocalizationInfo(hardwareControllerMap.controllerType, false, hardwareControllerMap.typeGuid, new List<string> { hardwareControllerMap.typeKey }, null);
				deviceLocalizationInfo.FinishRuntimeSetup();
				controllerElementIdentifier.FinishRuntimeSetup(deviceLocalizationInfo, hardwareControllerMap.controllerType);
			}
			return controllerElementIdentifier;
		}

		internal void FinishRuntimeSetup(DeviceLocalizationInfo deviceLocalizationInfo)
		{
			fZDTDaiGLKAzZQrldBDQluNgoRw(_elementType, out var wDdhIfgQYXRpSeEwrBrHOItkwVRlA, out var npYWoxDajscclIyARrpcWpXeFhgi);
			int num = RyDiYtnCdYRqXXpxvIjJeSOrrroG.LdCDypFhAhzHGQMVrcvuiORltJYJA(wDdhIfgQYXRpSeEwrBrHOItkwVRlA, npYWoxDajscclIyARrpcWpXeFhgi);
			if (num > 0)
			{
				KtZcjRPCWBrUHimJxXDFXsdnwtuO = new List<QkcbDMcEYUArSXgRsaeOSHwlAEVh>(num);
				for (int i = 0; i < num; i++)
				{
					KtZcjRPCWBrUHimJxXDFXsdnwtuO.Add(new QkcbDMcEYUArSXgRsaeOSHwlAEVh());
				}
			}
			ggNCrCLuBcCvGVfMrahpIpbnkRSs = deviceLocalizationInfo;
			if (WSoZdBCpSWDDwnonzaOqskSUbXiE == null)
			{
				WSoZdBCpSWDDwnonzaOqskSUbXiE = fdpfgJnMxjBVlnubvZxxSwBKSBwH.qLPTunycQAMpfHZWFrzhsvYPjGlw(this, eXRjOdORfaNOqMSguWnRpnOIZGBy.ControllerTemplate, wDdhIfgQYXRpSeEwrBrHOItkwVRlA, npYWoxDajscclIyARrpcWpXeFhgi, _id, deviceLocalizationInfo);
			}
			if (WsvFSfIkqOcuFdDqITFgMvjJEYEmc == null)
			{
				WsvFSfIkqOcuFdDqITFgMvjJEYEmc = AeIojEYKXjMwXFAZvRJEHSgNgyZw.UXOnicAJXZAaucMygiegJsYCouMHA(this, eXRjOdORfaNOqMSguWnRpnOIZGBy.ControllerTemplate, wDdhIfgQYXRpSeEwrBrHOItkwVRlA, npYWoxDajscclIyARrpcWpXeFhgi, _id, deviceLocalizationInfo);
			}
			if (wDdhIfgQYXRpSeEwrBrHOItkwVRlA == RyDiYtnCdYRqXXpxvIjJeSOrrroG.wDdhIfgQYXRpSeEwrBrHOItkwVRlA.CompoundElement)
			{
				CtoQipFFrKzDUbhBdhoifGsHFIaeb = CnQiCatlxaadkclyJFnfOigtKbyIA.xQlNwNLXCkETMspxfAWclkafhqBfA(this, eXRjOdORfaNOqMSguWnRpnOIZGBy.ControllerTemplate, wDdhIfgQYXRpSeEwrBrHOItkwVRlA, npYWoxDajscclIyARrpcWpXeFhgi, _id, deviceLocalizationInfo);
				bUUBMCBfilnnaWPpWTwSfTqHzXrTA = AUYmHhEeGVjKOWUHIgbqgMlToqEAA.GpYtZRWQZsEurckNVgsJmHiNOftH(this, eXRjOdORfaNOqMSguWnRpnOIZGBy.ControllerTemplate, wDdhIfgQYXRpSeEwrBrHOItkwVRlA, npYWoxDajscclIyARrpcWpXeFhgi, _id, deviceLocalizationInfo);
			}
		}

		string jmJlodmyeuTJffDdVhrvxnUdztWH.GetSpecialElementNonLocalizedDescriptiveName(int index)
		{
			if (KtZcjRPCWBrUHimJxXDFXsdnwtuO == null || index >= KtZcjRPCWBrUHimJxXDFXsdnwtuO.Count)
			{
				return null;
			}
			return KtZcjRPCWBrUHimJxXDFXsdnwtuO[index].DpEsSLOfeVooXTQOmvPDuGHhcOkb;
		}

		void jmJlodmyeuTJffDdVhrvxnUdztWH.SetSpecialElementNonLocalizedDescriptiveName(int index, string value)
		{
			if (KtZcjRPCWBrUHimJxXDFXsdnwtuO != null && index < KtZcjRPCWBrUHimJxXDFXsdnwtuO.Count)
			{
				KtZcjRPCWBrUHimJxXDFXsdnwtuO[index].DpEsSLOfeVooXTQOmvPDuGHhcOkb = value;
			}
		}

		string jmJlodmyeuTJffDdVhrvxnUdztWH.GetSpecialElementKey(int index)
		{
			if (KtZcjRPCWBrUHimJxXDFXsdnwtuO == null || index >= KtZcjRPCWBrUHimJxXDFXsdnwtuO.Count)
			{
				return null;
			}
			return KtZcjRPCWBrUHimJxXDFXsdnwtuO[index].ycISxawYQCmPVswbfwvHJCmehCHAA;
		}

		void jmJlodmyeuTJffDdVhrvxnUdztWH.SetSpecialElementKey(int index, string value)
		{
			if (KtZcjRPCWBrUHimJxXDFXsdnwtuO != null && index < KtZcjRPCWBrUHimJxXDFXsdnwtuO.Count)
			{
				KtZcjRPCWBrUHimJxXDFXsdnwtuO[index].ycISxawYQCmPVswbfwvHJCmehCHAA = value;
			}
		}

		string euWsBsFZlnKdNdwSzRGQMkIVzLgq.GetSpecialElementKey(int index)
		{
			if (KtZcjRPCWBrUHimJxXDFXsdnwtuO == null || index >= KtZcjRPCWBrUHimJxXDFXsdnwtuO.Count)
			{
				return null;
			}
			return KtZcjRPCWBrUHimJxXDFXsdnwtuO[index].ycISxawYQCmPVswbfwvHJCmehCHAA;
		}

		void euWsBsFZlnKdNdwSzRGQMkIVzLgq.SetSpecialElementKey(int index, string value)
		{
			if (KtZcjRPCWBrUHimJxXDFXsdnwtuO != null && index < KtZcjRPCWBrUHimJxXDFXsdnwtuO.Count)
			{
				KtZcjRPCWBrUHimJxXDFXsdnwtuO[index].ycISxawYQCmPVswbfwvHJCmehCHAA = value;
			}
		}

		private static void fZDTDaiGLKAzZQrldBDQluNgoRw(ControllerTemplateElementType P_0, out RyDiYtnCdYRqXXpxvIjJeSOrrroG.wDdhIfgQYXRpSeEwrBrHOItkwVRlA P_1, out RyDiYtnCdYRqXXpxvIjJeSOrrroG.NpYWoxDajscclIyARrpcWpXeFhgi P_2)
		{
			P_2 = RyDiYtnCdYRqXXpxvIjJeSOrrroG.NpYWoxDajscclIyARrpcWpXeFhgi.None;
			switch (P_0)
			{
			case ControllerTemplateElementType.Axis:
				P_1 = RyDiYtnCdYRqXXpxvIjJeSOrrroG.wDdhIfgQYXRpSeEwrBrHOItkwVRlA.Axis;
				break;
			case ControllerTemplateElementType.Button:
				P_1 = RyDiYtnCdYRqXXpxvIjJeSOrrroG.wDdhIfgQYXRpSeEwrBrHOItkwVRlA.Button;
				break;
			case ControllerTemplateElementType.Hat:
				P_1 = RyDiYtnCdYRqXXpxvIjJeSOrrroG.wDdhIfgQYXRpSeEwrBrHOItkwVRlA.CompoundElement;
				P_2 = RyDiYtnCdYRqXXpxvIjJeSOrrroG.NpYWoxDajscclIyARrpcWpXeFhgi.Hat;
				break;
			case ControllerTemplateElementType.DPad:
				P_1 = RyDiYtnCdYRqXXpxvIjJeSOrrroG.wDdhIfgQYXRpSeEwrBrHOItkwVRlA.CompoundElement;
				P_2 = RyDiYtnCdYRqXXpxvIjJeSOrrroG.NpYWoxDajscclIyARrpcWpXeFhgi.DPad;
				break;
			case ControllerTemplateElementType.ThumbStick:
				P_1 = RyDiYtnCdYRqXXpxvIjJeSOrrroG.wDdhIfgQYXRpSeEwrBrHOItkwVRlA.CompoundElement;
				break;
			case ControllerTemplateElementType.Yoke:
				P_1 = RyDiYtnCdYRqXXpxvIjJeSOrrroG.wDdhIfgQYXRpSeEwrBrHOItkwVRlA.Unknown;
				break;
			case ControllerTemplateElementType.Throttle:
				P_1 = RyDiYtnCdYRqXXpxvIjJeSOrrroG.wDdhIfgQYXRpSeEwrBrHOItkwVRlA.Unknown;
				break;
			case ControllerTemplateElementType.Stick:
				P_1 = RyDiYtnCdYRqXXpxvIjJeSOrrroG.wDdhIfgQYXRpSeEwrBrHOItkwVRlA.CompoundElement;
				P_2 = RyDiYtnCdYRqXXpxvIjJeSOrrroG.NpYWoxDajscclIyARrpcWpXeFhgi.Stick;
				break;
			case ControllerTemplateElementType.Stick6D:
				P_1 = RyDiYtnCdYRqXXpxvIjJeSOrrroG.wDdhIfgQYXRpSeEwrBrHOItkwVRlA.CompoundElement;
				P_2 = RyDiYtnCdYRqXXpxvIjJeSOrrroG.NpYWoxDajscclIyARrpcWpXeFhgi.Stick6D;
				break;
			default:
				P_1 = RyDiYtnCdYRqXXpxvIjJeSOrrroG.wDdhIfgQYXRpSeEwrBrHOItkwVRlA.Unknown;
				break;
			}
		}
	}
}
