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
	public class ControllerTemplateElementIdentifier : IControllerElementIdentifierCommon_Internal, IControllerTemplateElementIdentifier, LiukxMkkUUmGsEJaoRyGyuSBQfoS, LnhaMJXLiFbdSGpizhhMTtFDjtXy, ZhCqPBFhNKEpWHuMwXbLVCWahcjab, vfRBokPaPPEWJRenHDjJaOGZJkR, DEOLSCnqecUoFqpsMneIWaoyXVqt, WXuKXKglhBEpgRBwkNznjqCddGcA
	{
		[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
		internal class LIadBHJnYCXAqqyhQGpbapXEwsbeA
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

		internal sealed class cnLIjlXYzgcoFOQacCbLJhRmBWmj
		{
			[Serializable]
			private sealed class sokjTSWRnvjlfKgKPEwYApxmwrVv
			{
				public static readonly sokjTSWRnvjlfKgKPEwYApxmwrVv _003C_003E9 = new sokjTSWRnvjlfKgKPEwYApxmwrVv();

				public static Func<ControllerTemplateElementIdentifier, ControllerTemplateElementIdentifier, bool> _003C_003E9__4_0;

				internal bool CEmidyQHgqHWTPyJsOhvsifLmxgE(ControllerTemplateElementIdentifier P_0, ControllerTemplateElementIdentifier P_1)
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

			private static cnLIjlXYzgcoFOQacCbLJhRmBWmj pagbsBDrtdAdrewNHkgCchWdpHSJ;

			private readonly global::frkDecQuGtqloMwKYmMMIfIonbfk<ControllerTemplateElementIdentifier> PUafTRJFjbSQxhagTuBKwxqTPjVI;

			private static cnLIjlXYzgcoFOQacCbLJhRmBWmj opcpEjtetSYeeaXoSryPhvczRlHl
			{
				get
				{
					if (pagbsBDrtdAdrewNHkgCchWdpHSJ != null)
					{
						return pagbsBDrtdAdrewNHkgCchWdpHSJ;
					}
					pagbsBDrtdAdrewNHkgCchWdpHSJ = new cnLIjlXYzgcoFOQacCbLJhRmBWmj();
					pagbsBDrtdAdrewNHkgCchWdpHSJ.mlgWJZLctPqMuakTVvEddLUZfmmIA();
					return pagbsBDrtdAdrewNHkgCchWdpHSJ;
				}
			}

			private cnLIjlXYzgcoFOQacCbLJhRmBWmj()
			{
				PUafTRJFjbSQxhagTuBKwxqTPjVI = new global::frkDecQuGtqloMwKYmMMIfIonbfk<ControllerTemplateElementIdentifier>(sokjTSWRnvjlfKgKPEwYApxmwrVv._003C_003E9.CEmidyQHgqHWTPyJsOhvsifLmxgE);
			}

			private void mlgWJZLctPqMuakTVvEddLUZfmmIA()
			{
				ReInput.ShutDownEvent += pagbsBDrtdAdrewNHkgCchWdpHSJ.ayabQeQSdyFtoZUtaLojuYEDTXQ;
			}

			private void ayabQeQSdyFtoZUtaLojuYEDTXQ()
			{
				if (pagbsBDrtdAdrewNHkgCchWdpHSJ == this)
				{
					pagbsBDrtdAdrewNHkgCchWdpHSJ = null;
				}
				ReInput.ShutDownEvent -= ayabQeQSdyFtoZUtaLojuYEDTXQ;
			}

			public static ControllerTemplateElementIdentifier eegCxyJNoEIWSTRVvwxAOxHdIrwV(DeviceLocalizationInfo P_0, ControllerTemplateElementIdentifier P_1)
			{
				return opcpEjtetSYeeaXoSryPhvczRlHl.PUafTRJFjbSQxhagTuBKwxqTPjVI.WiXlndVHOhDtrdahVzEwBbrFiFlF(P_0.hash, P_1);
			}

			public static bool DmlAxAVVYyvyKAtVoACihaUZtUEh(DeviceLocalizationInfo P_0, ControllerTemplateElementIdentifier P_1, out ControllerTemplateElementIdentifier P_2)
			{
				return opcpEjtetSYeeaXoSryPhvczRlHl.PUafTRJFjbSQxhagTuBKwxqTPjVI.ygSxKCwLEisnUFvjzYlmWjzWgFws(P_0.hash, P_1, out P_2);
			}

			public static void YPRJvEhsTFFnfHyshaYqZEdHOCDN(DeviceLocalizationInfo P_0, ControllerTemplateElementIdentifier P_1)
			{
				opcpEjtetSYeeaXoSryPhvczRlHl.PUafTRJFjbSQxhagTuBKwxqTPjVI.BJUFZEhwGLMUmyBgFeUcAyOMNcmk(P_0.hash, P_1);
			}
		}

		private class cEbEIxrrIOczgFWfrVtpSfQyCireb
		{
			[SerializeField]
			private string GgYDgDIKpiCPaLnZgVGLLkMmMEFP;

			[SerializeField]
			private string hXjeiOmeXFCYJEYAFHexaokJmEvM;

			public string ORNCQLbiOUrihrrwafsmcvAlpyrk
			{
				get
				{
					return GgYDgDIKpiCPaLnZgVGLLkMmMEFP;
				}
				set
				{
					GgYDgDIKpiCPaLnZgVGLLkMmMEFP = ggYDgDIKpiCPaLnZgVGLLkMmMEFP;
				}
			}

			public string deBYHdZWzquNKMPJLvgcBYceMIyN
			{
				get
				{
					return hXjeiOmeXFCYJEYAFHexaokJmEvM;
				}
				set
				{
					hXjeiOmeXFCYJEYAFHexaokJmEvM = text;
				}
			}

			public cEbEIxrrIOczgFWfrVtpSfQyCireb()
			{
			}

			public cEbEIxrrIOczgFWfrVtpSfQyCireb(cEbEIxrrIOczgFWfrVtpSfQyCireb P_0)
			{
				GgYDgDIKpiCPaLnZgVGLLkMmMEFP = P_0.GgYDgDIKpiCPaLnZgVGLLkMmMEFP;
				hXjeiOmeXFCYJEYAFHexaokJmEvM = P_0.hXjeiOmeXFCYJEYAFHexaokJmEvM;
			}
		}

		private const string ONNeeccgTLIlZGqrmpDLrxfvkDFL = "controller/template";

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
		private FmsHxmaJbvwpZaWikICOnWlHsjYj qlveqyVQCOvoKqOokpdVBsSTcHSm;

		[NonSerialized]
		private kcVtlLkxxcCGEkDbOioGZBSsqBKy iApFDQIOnEqcauRIcxlFxLCQSmCR;

		[NonSerialized]
		private anLAKzLoHfdVthYCyIIfImKKsYrkA yWwfiAxhuIPFrQqxAEBLWLTHgYqj;

		[NonSerialized]
		private eIDqhOHBKXbluRZOZweLzCDOHOcz NGXnpxcalzKtECsDPrmlwMCMzpJD;

		[NonSerialized]
		private DeviceLocalizationInfo SyMNIrEVHkUxaGaRwOmQrmTgbliS;

		[NonSerialized]
		private int ZVgArizopfWJSCnPXDgDkEcQbgkrA;

		[NonSerialized]
		private List<cEbEIxrrIOczgFWfrVtpSfQyCireb> uDCSEmGGGVYprxaQmoIosgNmNNCr;

		int IControllerElementIdentifierCommon_Internal.id => _id;

		string IControllerElementIdentifierCommon_Internal.name
		{
			get
			{
				if (!ReInput.isReady || qlveqyVQCOvoKqOokpdVBsSTcHSm == null || !LocalizationManager.isEnabled)
				{
					return _name;
				}
				return qlveqyVQCOvoKqOokpdVBsSTcHSm.qJkqRAxrrocPcPhIKAOpCMJUoZxfA;
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
				if (!ReInput.isReady || qlveqyVQCOvoKqOokpdVBsSTcHSm == null || !LocalizationManager.isEnabled)
				{
					return _positiveName;
				}
				return qlveqyVQCOvoKqOokpdVBsSTcHSm.UDfFJNMhCyBCNIpQLiHPdXQolEJqA;
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
				if (!ReInput.isReady || qlveqyVQCOvoKqOokpdVBsSTcHSm == null || !LocalizationManager.isEnabled)
				{
					return _negativeName;
				}
				return qlveqyVQCOvoKqOokpdVBsSTcHSm.uHNCrEpNbRlmMRKTnwRRnCRKxuSl;
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
				if (!ReInput.isReady || yWwfiAxhuIPFrQqxAEBLWLTHgYqj == null || !GlyphManager.isEnabled)
				{
					return null;
				}
				return yWwfiAxhuIPFrQqxAEBLWLTHgYqj.jwZyctvWJoSKAGduMIqPWqlcniZh;
			}
		}

		public object positiveGlyph
		{
			get
			{
				if (!ReInput.isReady || yWwfiAxhuIPFrQqxAEBLWLTHgYqj == null || !GlyphManager.isEnabled)
				{
					return null;
				}
				return yWwfiAxhuIPFrQqxAEBLWLTHgYqj.EBxaYzPLdxoxLqFaNNMWpbWdpkgR;
			}
		}

		public object negativeGlyph
		{
			get
			{
				if (!ReInput.isReady || yWwfiAxhuIPFrQqxAEBLWLTHgYqj == null || !GlyphManager.isEnabled)
				{
					return null;
				}
				return yWwfiAxhuIPFrQqxAEBLWLTHgYqj.YeRcGxxxJJipYymqMgCYYEGVveXO;
			}
		}

		private string finalGlyphKey
		{
			get
			{
				if (!ReInput.isReady || yWwfiAxhuIPFrQqxAEBLWLTHgYqj == null || !GlyphManager.isEnabled)
				{
					return null;
				}
				return yWwfiAxhuIPFrQqxAEBLWLTHgYqj.wMJOQsCSAeFAdwAuPcLuBvPnqplR;
			}
		}

		private string finalPositiveGlyphKey
		{
			get
			{
				if (!ReInput.isReady || yWwfiAxhuIPFrQqxAEBLWLTHgYqj == null || !GlyphManager.isEnabled)
				{
					return null;
				}
				return yWwfiAxhuIPFrQqxAEBLWLTHgYqj.wYCljqJRutqoTlDqRfxkTLpvwHBU;
			}
		}

		private string finalNegativeGlyphKey
		{
			get
			{
				if (!ReInput.isReady || yWwfiAxhuIPFrQqxAEBLWLTHgYqj == null || !GlyphManager.isEnabled)
				{
					return null;
				}
				return yWwfiAxhuIPFrQqxAEBLWLTHgYqj.tEWSURZAlPhPJAgqSaWlcYfzQVGEb;
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
				if (ReInput.isReady && qlveqyVQCOvoKqOokpdVBsSTcHSm != null)
				{
					qlveqyVQCOvoKqOokpdVBsSTcHSm.wkNCiIKcomvvEiZxnJmXtmqxRPdW();
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
				if (ReInput.isReady && qlveqyVQCOvoKqOokpdVBsSTcHSm != null)
				{
					qlveqyVQCOvoKqOokpdVBsSTcHSm.BrqPcLzhJFhYTJVIHnKPgptmKoCR();
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
				if (ReInput.isReady && qlveqyVQCOvoKqOokpdVBsSTcHSm != null)
				{
					qlveqyVQCOvoKqOokpdVBsSTcHSm.oTvzCizjOSehqAUOHakMGgqsXjxJA();
				}
			}
		}

		public string key => _key;

		public string positiveKey => _positiveKey;

		public string negativeKey => _negativeKey;

		string IControllerElementIdentifierCommon_Internal.nonLocalizedName => nonLocalizedName;

		string IControllerElementIdentifierCommon_Internal.nonLocalizedPositiveName => nonLocalizedPositiveName;

		string IControllerElementIdentifierCommon_Internal.nonLocalizedNegativeName => nonLocalizedNegativeName;

		bool IControllerElementIdentifierCommon_Internal.isNonLocalizedPositiveNameAutoGenerated => (ZVgArizopfWJSCnPXDgDkEcQbgkrA & 2) != 0;

		bool IControllerElementIdentifierCommon_Internal.isNonLocalizedNegativeNameAutoGenerated => (ZVgArizopfWJSCnPXDgDkEcQbgkrA & 4) != 0;

		bool IControllerElementIdentifierCommon_Internal.isPositiveKeyAutoGenerated => (ZVgArizopfWJSCnPXDgDkEcQbgkrA & 8) != 0;

		bool IControllerElementIdentifierCommon_Internal.isNegativeKeyAutoGenerated => (ZVgArizopfWJSCnPXDgDkEcQbgkrA & 0x10) != 0;

		string IControllerElementIdentifierCommon_Internal.key => _key;

		string IControllerElementIdentifierCommon_Internal.positiveKey => _positiveKey;

		string IControllerElementIdentifierCommon_Internal.negativeKey => _negativeKey;

		DeviceLocalizationInfo IControllerElementIdentifierCommon_Internal.deviceLocalizationInfo => SyMNIrEVHkUxaGaRwOmQrmTgbliS;

		object IControllerElementIdentifierCommon_Internal.elementType => _elementType;

		bool IControllerElementIdentifierCommon_Internal.useEditorElementTypeOverride => useEditorElementTypeOverride;

		ControllerElementType IControllerElementIdentifierCommon_Internal.editorElementTypeOverride => editorElementTypeOverride;

		string LnhaMJXLiFbdSGpizhhMTtFDjtXy.keyCategory => "controller/template";

		string LnhaMJXLiFbdSGpizhhMTtFDjtXy.scriptingName => _name;

		string LnhaMJXLiFbdSGpizhhMTtFDjtXy.nonLocalizedDescriptiveName
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

		string LiukxMkkUUmGsEJaoRyGyuSBQfoS.nonLocalizedPositiveDescriptiveName
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

		string LiukxMkkUUmGsEJaoRyGyuSBQfoS.nonLocalizedNegativeDescriptiveName
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
				return ZVgArizopfWJSCnPXDgDkEcQbgkrA;
			}
			set
			{
				ZVgArizopfWJSCnPXDgDkEcQbgkrA = value;
			}
		}

		string vfRBokPaPPEWJRenHDjJaOGZJkR.keyCategory => "controller/template";

		string vfRBokPaPPEWJRenHDjJaOGZJkR.key => _key;

		int vfRBokPaPPEWJRenHDjJaOGZJkR.autoGeneratedValueFlags
		{
			get
			{
				return ZVgArizopfWJSCnPXDgDkEcQbgkrA;
			}
			set
			{
				ZVgArizopfWJSCnPXDgDkEcQbgkrA = value;
			}
		}

		string ZhCqPBFhNKEpWHuMwXbLVCWahcjab.positiveKey
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

		string ZhCqPBFhNKEpWHuMwXbLVCWahcjab.negativeKey
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
			if (!ReInput.isReady || !LocalizationManager.isEnabled || uDCSEmGGGVYprxaQmoIosgNmNNCr == null || iApFDQIOnEqcauRIcxlFxLCQSmCR == null)
			{
				return string.Empty;
			}
			return iApFDQIOnEqcauRIcxlFxLCQSmCR.cQwbtPkKbuvPqNcLgcikLIlJcUUG(index);
		}

		internal object GetCompoundElementSpecialGlyph(int index)
		{
			if (!ReInput.isReady || !GlyphManager.isEnabled || uDCSEmGGGVYprxaQmoIosgNmNNCr == null || NGXnpxcalzKtECsDPrmlwMCMzpJD == null)
			{
				return null;
			}
			return NGXnpxcalzKtECsDPrmlwMCMzpJD.zucaHsRbQvAxizbSaHWafpJbdPgD(index);
		}

		string IControllerElementIdentifierCommon_Internal.GetSpecialElementNonLocalizedName(int index)
		{
			if (uDCSEmGGGVYprxaQmoIosgNmNNCr == null || (uint)index >= (uint)uDCSEmGGGVYprxaQmoIosgNmNNCr.Count)
			{
				return null;
			}
			return uDCSEmGGGVYprxaQmoIosgNmNNCr[index].deBYHdZWzquNKMPJLvgcBYceMIyN;
		}

		string IControllerElementIdentifierCommon_Internal.GetSpecialElementKey(int index)
		{
			if (uDCSEmGGGVYprxaQmoIosgNmNNCr == null || (uint)index >= (uint)uDCSEmGGGVYprxaQmoIosgNmNNCr.Count)
			{
				return null;
			}
			return uDCSEmGGGVYprxaQmoIosgNmNNCr[index].ORNCQLbiOUrihrrwafsmcvAlpyrk;
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
			if (P_0.uDCSEmGGGVYprxaQmoIosgNmNNCr != null)
			{
				int count = P_0.uDCSEmGGGVYprxaQmoIosgNmNNCr.Count;
				uDCSEmGGGVYprxaQmoIosgNmNNCr = new List<cEbEIxrrIOczgFWfrVtpSfQyCireb>(count);
				for (int i = 0; i < count; i++)
				{
					if (P_0.uDCSEmGGGVYprxaQmoIosgNmNNCr[i] != null)
					{
						uDCSEmGGGVYprxaQmoIosgNmNNCr.Add(new cEbEIxrrIOczgFWfrVtpSfQyCireb(P_0.uDCSEmGGGVYprxaQmoIosgNmNNCr[i]));
					}
				}
			}
			ZVgArizopfWJSCnPXDgDkEcQbgkrA = P_0.ZVgArizopfWJSCnPXDgDkEcQbgkrA;
		}

		internal ControllerTemplateElementIdentifier(LIadBHJnYCXAqqyhQGpbapXEwsbeA P_0)
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
			ControllerElementIdentifier controllerElementIdentifier = new ControllerElementIdentifier(new ControllerElementIdentifier.JJdeZvdjnivmGnZMnwtOMfIBzcAP
			{
				id = _id,
				name = _name,
				positiveName = _positiveName,
				negativeName = _negativeName,
				key = _key,
				positiveKey = _positiveKey,
				negativeKey = _negativeKey,
				elementType = SVQbmGoCgjXlQooYDoNZCFflMVzP.ZqnjaZOfwlbSZqPnxxQssHwyaKuDA(_elementType),
				compoundElementType = CompoundControllerElementType.Axis2D
			});
			if (ReInput.isReady && SyMNIrEVHkUxaGaRwOmQrmTgbliS != null && hardwareControllerMap != null)
			{
				DeviceLocalizationInfo deviceLocalizationInfo = new DeviceLocalizationInfo(hardwareControllerMap.controllerType, false, hardwareControllerMap.typeGuid, new List<string> { hardwareControllerMap.typeKey }, null);
				deviceLocalizationInfo.FinishRuntimeSetup();
				controllerElementIdentifier.FinishRuntimeSetup(deviceLocalizationInfo, hardwareControllerMap.controllerType);
			}
			return controllerElementIdentifier;
		}

		internal void FinishRuntimeSetup(DeviceLocalizationInfo deviceLocalizationInfo)
		{
			NuQucwfvMZNhVMuiuMCcvvCGfUzy(_elementType, out var aqybaYFDSFEDwBRnsokwpBTdIblQ, out var veVjxECKraSLRuRJUJeBWprfCtQDb);
			int num = jjEiJGkdrKfqxJAsceTeoFkgoNMlA.zIFHYKIYFbwXaLMpuqkDbbnkpdiD(aqybaYFDSFEDwBRnsokwpBTdIblQ, veVjxECKraSLRuRJUJeBWprfCtQDb);
			if (num > 0)
			{
				uDCSEmGGGVYprxaQmoIosgNmNNCr = new List<cEbEIxrrIOczgFWfrVtpSfQyCireb>(num);
				for (int i = 0; i < num; i++)
				{
					uDCSEmGGGVYprxaQmoIosgNmNNCr.Add(new cEbEIxrrIOczgFWfrVtpSfQyCireb());
				}
			}
			SyMNIrEVHkUxaGaRwOmQrmTgbliS = deviceLocalizationInfo;
			if (qlveqyVQCOvoKqOokpdVBsSTcHSm == null)
			{
				qlveqyVQCOvoKqOokpdVBsSTcHSm = FmsHxmaJbvwpZaWikICOnWlHsjYj.SWANMvtGIoEVLQRCPyMGXqaKwTqc(this, ILKhcCJzrmtoMHIdzHgcKloPCkpIA.ControllerTemplate, aqybaYFDSFEDwBRnsokwpBTdIblQ, veVjxECKraSLRuRJUJeBWprfCtQDb, _id, deviceLocalizationInfo);
			}
			if (yWwfiAxhuIPFrQqxAEBLWLTHgYqj == null)
			{
				yWwfiAxhuIPFrQqxAEBLWLTHgYqj = anLAKzLoHfdVthYCyIIfImKKsYrkA.uGRHWLJHVPGVWXMjfOnZTJkHFOqGA(this, ILKhcCJzrmtoMHIdzHgcKloPCkpIA.ControllerTemplate, aqybaYFDSFEDwBRnsokwpBTdIblQ, veVjxECKraSLRuRJUJeBWprfCtQDb, _id, deviceLocalizationInfo);
			}
			if (aqybaYFDSFEDwBRnsokwpBTdIblQ == jjEiJGkdrKfqxJAsceTeoFkgoNMlA.AqybaYFDSFEDwBRnsokwpBTdIblQ.CompoundElement)
			{
				iApFDQIOnEqcauRIcxlFxLCQSmCR = kcVtlLkxxcCGEkDbOioGZBSsqBKy.BfmaPgSNOogkaBtkuIBFMEIqNWlEA(this, ILKhcCJzrmtoMHIdzHgcKloPCkpIA.ControllerTemplate, aqybaYFDSFEDwBRnsokwpBTdIblQ, veVjxECKraSLRuRJUJeBWprfCtQDb, _id, deviceLocalizationInfo);
				NGXnpxcalzKtECsDPrmlwMCMzpJD = eIDqhOHBKXbluRZOZweLzCDOHOcz.kbVlCoNvXwuhPbfMGBbkeFYMpwHGb(this, ILKhcCJzrmtoMHIdzHgcKloPCkpIA.ControllerTemplate, aqybaYFDSFEDwBRnsokwpBTdIblQ, veVjxECKraSLRuRJUJeBWprfCtQDb, _id, deviceLocalizationInfo);
			}
		}

		string DEOLSCnqecUoFqpsMneIWaoyXVqt.GetSpecialElementNonLocalizedDescriptiveName(int index)
		{
			if (uDCSEmGGGVYprxaQmoIosgNmNNCr == null || index >= uDCSEmGGGVYprxaQmoIosgNmNNCr.Count)
			{
				return null;
			}
			return uDCSEmGGGVYprxaQmoIosgNmNNCr[index].deBYHdZWzquNKMPJLvgcBYceMIyN;
		}

		void DEOLSCnqecUoFqpsMneIWaoyXVqt.SetSpecialElementNonLocalizedDescriptiveName(int index, string value)
		{
			if (uDCSEmGGGVYprxaQmoIosgNmNNCr != null && index < uDCSEmGGGVYprxaQmoIosgNmNNCr.Count)
			{
				uDCSEmGGGVYprxaQmoIosgNmNNCr[index].deBYHdZWzquNKMPJLvgcBYceMIyN = value;
			}
		}

		string DEOLSCnqecUoFqpsMneIWaoyXVqt.GetSpecialElementKey(int index)
		{
			if (uDCSEmGGGVYprxaQmoIosgNmNNCr == null || index >= uDCSEmGGGVYprxaQmoIosgNmNNCr.Count)
			{
				return null;
			}
			return uDCSEmGGGVYprxaQmoIosgNmNNCr[index].ORNCQLbiOUrihrrwafsmcvAlpyrk;
		}

		void DEOLSCnqecUoFqpsMneIWaoyXVqt.SetSpecialElementKey(int index, string value)
		{
			if (uDCSEmGGGVYprxaQmoIosgNmNNCr != null && index < uDCSEmGGGVYprxaQmoIosgNmNNCr.Count)
			{
				uDCSEmGGGVYprxaQmoIosgNmNNCr[index].ORNCQLbiOUrihrrwafsmcvAlpyrk = value;
			}
		}

		string WXuKXKglhBEpgRBwkNznjqCddGcA.GetSpecialElementKey(int index)
		{
			if (uDCSEmGGGVYprxaQmoIosgNmNNCr == null || index >= uDCSEmGGGVYprxaQmoIosgNmNNCr.Count)
			{
				return null;
			}
			return uDCSEmGGGVYprxaQmoIosgNmNNCr[index].ORNCQLbiOUrihrrwafsmcvAlpyrk;
		}

		void WXuKXKglhBEpgRBwkNznjqCddGcA.SetSpecialElementKey(int index, string value)
		{
			if (uDCSEmGGGVYprxaQmoIosgNmNNCr != null && index < uDCSEmGGGVYprxaQmoIosgNmNNCr.Count)
			{
				uDCSEmGGGVYprxaQmoIosgNmNNCr[index].ORNCQLbiOUrihrrwafsmcvAlpyrk = value;
			}
		}

		private static void NuQucwfvMZNhVMuiuMCcvvCGfUzy(ControllerTemplateElementType P_0, out jjEiJGkdrKfqxJAsceTeoFkgoNMlA.AqybaYFDSFEDwBRnsokwpBTdIblQ P_1, out jjEiJGkdrKfqxJAsceTeoFkgoNMlA.veVjxECKraSLRuRJUJeBWprfCtQDb P_2)
		{
			P_2 = jjEiJGkdrKfqxJAsceTeoFkgoNMlA.veVjxECKraSLRuRJUJeBWprfCtQDb.None;
			switch (P_0)
			{
			case ControllerTemplateElementType.Axis:
				P_1 = jjEiJGkdrKfqxJAsceTeoFkgoNMlA.AqybaYFDSFEDwBRnsokwpBTdIblQ.Axis;
				break;
			case ControllerTemplateElementType.Button:
				P_1 = jjEiJGkdrKfqxJAsceTeoFkgoNMlA.AqybaYFDSFEDwBRnsokwpBTdIblQ.Button;
				break;
			case ControllerTemplateElementType.Hat:
				P_1 = jjEiJGkdrKfqxJAsceTeoFkgoNMlA.AqybaYFDSFEDwBRnsokwpBTdIblQ.CompoundElement;
				P_2 = jjEiJGkdrKfqxJAsceTeoFkgoNMlA.veVjxECKraSLRuRJUJeBWprfCtQDb.Hat;
				break;
			case ControllerTemplateElementType.DPad:
				P_1 = jjEiJGkdrKfqxJAsceTeoFkgoNMlA.AqybaYFDSFEDwBRnsokwpBTdIblQ.CompoundElement;
				P_2 = jjEiJGkdrKfqxJAsceTeoFkgoNMlA.veVjxECKraSLRuRJUJeBWprfCtQDb.DPad;
				break;
			case ControllerTemplateElementType.ThumbStick:
				P_1 = jjEiJGkdrKfqxJAsceTeoFkgoNMlA.AqybaYFDSFEDwBRnsokwpBTdIblQ.CompoundElement;
				break;
			case ControllerTemplateElementType.Yoke:
				P_1 = jjEiJGkdrKfqxJAsceTeoFkgoNMlA.AqybaYFDSFEDwBRnsokwpBTdIblQ.Unknown;
				break;
			case ControllerTemplateElementType.Throttle:
				P_1 = jjEiJGkdrKfqxJAsceTeoFkgoNMlA.AqybaYFDSFEDwBRnsokwpBTdIblQ.Unknown;
				break;
			case ControllerTemplateElementType.Stick:
				P_1 = jjEiJGkdrKfqxJAsceTeoFkgoNMlA.AqybaYFDSFEDwBRnsokwpBTdIblQ.CompoundElement;
				P_2 = jjEiJGkdrKfqxJAsceTeoFkgoNMlA.veVjxECKraSLRuRJUJeBWprfCtQDb.Stick;
				break;
			case ControllerTemplateElementType.Stick6D:
				P_1 = jjEiJGkdrKfqxJAsceTeoFkgoNMlA.AqybaYFDSFEDwBRnsokwpBTdIblQ.CompoundElement;
				P_2 = jjEiJGkdrKfqxJAsceTeoFkgoNMlA.veVjxECKraSLRuRJUJeBWprfCtQDb.Stick6D;
				break;
			default:
				P_1 = jjEiJGkdrKfqxJAsceTeoFkgoNMlA.AqybaYFDSFEDwBRnsokwpBTdIblQ.Unknown;
				break;
			}
		}
	}
}
