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
	public class ControllerTemplateElementIdentifier : IControllerElementIdentifierCommon_Internal, IControllerTemplateElementIdentifier, jtAeQMwqfCHdCmeHvhaRCqwDmBxb, dEyHRFFHMmNkBjyccsmusjbnHemDB, jYOuwHQLkAMAsMhmCbimJoXgoSaP, LFxfRtFXyxgAjxbmpHDNQNxOPKov, rCWArSkiHiMJlBWAwpbfXxbyxlrS, yBPKsUhYrRiyCEpVcVcLwcBSjoGT
	{
		[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
		internal class nLaFzIMACsxsXEozUenVJiqGTrjCA
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

		internal sealed class GUPiwiwAUCDUasvYcoQfKeguqMgn
		{
			[Serializable]
			private sealed class AJmikZttcplUSEArDpDJCEADbtpc
			{
				public static readonly AJmikZttcplUSEArDpDJCEADbtpc _003C_003E9 = new AJmikZttcplUSEArDpDJCEADbtpc();

				public static Func<ControllerTemplateElementIdentifier, ControllerTemplateElementIdentifier, bool> _003C_003E9__4_0;

				internal bool HPScvmzpeFILbfrZHMdIvcQHrMWE(ControllerTemplateElementIdentifier P_0, ControllerTemplateElementIdentifier P_1)
				{
					if (P_0 == null || P_1 == null)
					{
						return false;
					}
					if (P_0 != null && P_1 != null && P_0.id == P_1.id && P_0.elementType == P_1.elementType)
					{
						return string.Equals(P_0.key, P_1.key, StringComparison.Ordinal);
					}
					return false;
				}
			}

			private static GUPiwiwAUCDUasvYcoQfKeguqMgn AAsUotzmeurdNsprWlhSRkCHGMyW;

			private readonly RJmfAjpdKLIIXgAAMaxkVDnckcjN<ControllerTemplateElementIdentifier> OMwBQfLhmVTNVZtCfEIYYJfZqvfF;

			private static GUPiwiwAUCDUasvYcoQfKeguqMgn kYNBFgnEJgclbFwpvHMfwUfnUCch
			{
				get
				{
					if (AAsUotzmeurdNsprWlhSRkCHGMyW != null)
					{
						return AAsUotzmeurdNsprWlhSRkCHGMyW;
					}
					AAsUotzmeurdNsprWlhSRkCHGMyW = new GUPiwiwAUCDUasvYcoQfKeguqMgn();
					AAsUotzmeurdNsprWlhSRkCHGMyW.eYVBLUcuQlHJrbHrStsdmfsWfTEHA();
					return AAsUotzmeurdNsprWlhSRkCHGMyW;
				}
			}

			private GUPiwiwAUCDUasvYcoQfKeguqMgn()
			{
				OMwBQfLhmVTNVZtCfEIYYJfZqvfF = new RJmfAjpdKLIIXgAAMaxkVDnckcjN<ControllerTemplateElementIdentifier>(AJmikZttcplUSEArDpDJCEADbtpc._003C_003E9.HPScvmzpeFILbfrZHMdIvcQHrMWE);
			}

			private void eYVBLUcuQlHJrbHrStsdmfsWfTEHA()
			{
				ReInput.ShutDownEvent += AAsUotzmeurdNsprWlhSRkCHGMyW.MfhcSYGsnnapnbFcgMQToNLucqsoA;
			}

			private void MfhcSYGsnnapnbFcgMQToNLucqsoA()
			{
				if (AAsUotzmeurdNsprWlhSRkCHGMyW == this)
				{
					AAsUotzmeurdNsprWlhSRkCHGMyW = null;
				}
				ReInput.ShutDownEvent -= MfhcSYGsnnapnbFcgMQToNLucqsoA;
			}

			public static ControllerTemplateElementIdentifier RGGJWIgQTGFjrbkplAhDgRPBiCkT(DeviceLocalizationInfo P_0, ControllerTemplateElementIdentifier P_1)
			{
				return kYNBFgnEJgclbFwpvHMfwUfnUCch.OMwBQfLhmVTNVZtCfEIYYJfZqvfF.RGGJWIgQTGFjrbkplAhDgRPBiCkT(P_0.hash, P_1);
			}

			public static bool XoWrPhuuoYdElFYmsPRgFLepADbg(DeviceLocalizationInfo P_0, ControllerTemplateElementIdentifier P_1, out ControllerTemplateElementIdentifier P_2)
			{
				return kYNBFgnEJgclbFwpvHMfwUfnUCch.OMwBQfLhmVTNVZtCfEIYYJfZqvfF.XoWrPhuuoYdElFYmsPRgFLepADbg(P_0.hash, P_1, out P_2);
			}

			public static void fyeqCafQbFyflbNbajUvornPxfgy(DeviceLocalizationInfo P_0, ControllerTemplateElementIdentifier P_1)
			{
				kYNBFgnEJgclbFwpvHMfwUfnUCch.OMwBQfLhmVTNVZtCfEIYYJfZqvfF.fyeqCafQbFyflbNbajUvornPxfgy(P_0.hash, P_1);
			}
		}

		private class QIzegiGsImBTHkaztpVTyYzsnlbI
		{
			[SerializeField]
			private string iznbkRlQcoGkZtBlmfunFSNsZtUK;

			[SerializeField]
			private string RlKaAhpsSUeErkCKDIWEsgnXFvlrA;

			public string EqHcpXWaGauOvKqzuxjiUENyiiKN
			{
				get
				{
					return iznbkRlQcoGkZtBlmfunFSNsZtUK;
				}
				set
				{
					iznbkRlQcoGkZtBlmfunFSNsZtUK = text;
				}
			}

			public string mNsOLThYGSOFZLagKTDbbifzFlKD
			{
				get
				{
					return RlKaAhpsSUeErkCKDIWEsgnXFvlrA;
				}
				set
				{
					RlKaAhpsSUeErkCKDIWEsgnXFvlrA = rlKaAhpsSUeErkCKDIWEsgnXFvlrA;
				}
			}

			public QIzegiGsImBTHkaztpVTyYzsnlbI()
			{
			}

			public QIzegiGsImBTHkaztpVTyYzsnlbI(QIzegiGsImBTHkaztpVTyYzsnlbI P_0)
			{
				iznbkRlQcoGkZtBlmfunFSNsZtUK = P_0.iznbkRlQcoGkZtBlmfunFSNsZtUK;
				RlKaAhpsSUeErkCKDIWEsgnXFvlrA = P_0.RlKaAhpsSUeErkCKDIWEsgnXFvlrA;
			}
		}

		private const string mzVPpYpnwixRejNdGdywXfXJhtkv = "controller/template";

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int _id;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string _name;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string _positiveName;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private string _negativeName;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		public string _key;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		public string _positiveKey;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		public string _negativeKey;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private ControllerTemplateElementType _elementType;

		[NonSerialized]
		private jEybDfZnTXMckOeqmWAqoWQFlwGi SLPfoLEFsScnNhJxiHwVjPkEzuFMe;

		[NonSerialized]
		private YhJXvGNrRKyGdInNEkJoIlMuKlEd zrpEYcFUWSBuEfCWAnwfBrLHsZprB;

		[NonSerialized]
		private CBBcwUwBZJdGbsAcSWRxdrIUNhtA jXTeuPQicAMCwWjmKHuCxXIPgDAU;

		[NonSerialized]
		private OAPILVqGWzRVwzMiPuzYuyOIDyhB fukAMpFlyRVJAYIUopivTNDNCrwIA;

		[NonSerialized]
		private DeviceLocalizationInfo epyWrMiKarPbsrBGIHCyAJPFVlJb;

		[NonSerialized]
		private int rDnRVTAZXyaVlJOBjDydLOTjrRpD;

		[NonSerialized]
		private List<QIzegiGsImBTHkaztpVTyYzsnlbI> OLOLEwAKWvVmPXetyNZCpPteStbQ;

		public int id => _id;

		public string name
		{
			get
			{
				if (!ReInput.isReady || SLPfoLEFsScnNhJxiHwVjPkEzuFMe == null || !LocalizationManager.isEnabled)
				{
					return _name;
				}
				return SLPfoLEFsScnNhJxiHwVjPkEzuFMe.jXwgbYbEpdqHGeBdCbXEcskUaWaFA;
			}
			internal set
			{
				nonLocalizedName = value;
			}
		}

		public string positiveName
		{
			get
			{
				if (!ReInput.isReady || SLPfoLEFsScnNhJxiHwVjPkEzuFMe == null || !LocalizationManager.isEnabled)
				{
					return _positiveName;
				}
				return SLPfoLEFsScnNhJxiHwVjPkEzuFMe.nkieIDGTvoQOzfhnwqrRbpIBgcrw;
			}
			internal set
			{
				nonLocalizedPositiveName = value;
			}
		}

		public string negativeName
		{
			get
			{
				if (!ReInput.isReady || SLPfoLEFsScnNhJxiHwVjPkEzuFMe == null || !LocalizationManager.isEnabled)
				{
					return _negativeName;
				}
				return SLPfoLEFsScnNhJxiHwVjPkEzuFMe.CWdJorNsJxtHBeABWaFvcIChQSiaA;
			}
			internal set
			{
				nonLocalizedNegativeName = value;
			}
		}

		public ControllerTemplateElementType elementType => _elementType;

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
				if (!ReInput.isReady || jXTeuPQicAMCwWjmKHuCxXIPgDAU == null || !GlyphManager.isEnabled)
				{
					return null;
				}
				return jXTeuPQicAMCwWjmKHuCxXIPgDAU.OVQhivfSVMBpQMWuxTSgKFUzmyCh;
			}
		}

		public object positiveGlyph
		{
			get
			{
				if (!ReInput.isReady || jXTeuPQicAMCwWjmKHuCxXIPgDAU == null || !GlyphManager.isEnabled)
				{
					return null;
				}
				return jXTeuPQicAMCwWjmKHuCxXIPgDAU.YyUsIUduGWeOfCtjIywoJfllsurQ;
			}
		}

		public object negativeGlyph
		{
			get
			{
				if (!ReInput.isReady || jXTeuPQicAMCwWjmKHuCxXIPgDAU == null || !GlyphManager.isEnabled)
				{
					return null;
				}
				return jXTeuPQicAMCwWjmKHuCxXIPgDAU.YSPUguRwsXdgRZEXPfEfiDKpzBmf;
			}
		}

		private string finalGlyphKey
		{
			get
			{
				if (!ReInput.isReady || jXTeuPQicAMCwWjmKHuCxXIPgDAU == null || !GlyphManager.isEnabled)
				{
					return null;
				}
				return jXTeuPQicAMCwWjmKHuCxXIPgDAU.BgDsdJaeWVGoMCQvooPYEudaIQDRB;
			}
		}

		private string finalPositiveGlyphKey
		{
			get
			{
				if (!ReInput.isReady || jXTeuPQicAMCwWjmKHuCxXIPgDAU == null || !GlyphManager.isEnabled)
				{
					return null;
				}
				return jXTeuPQicAMCwWjmKHuCxXIPgDAU.QRtdMqfdnInSEUzeWexXMKtDKsnyA;
			}
		}

		private string finalNegativeGlyphKey
		{
			get
			{
				if (!ReInput.isReady || jXTeuPQicAMCwWjmKHuCxXIPgDAU == null || !GlyphManager.isEnabled)
				{
					return null;
				}
				return jXTeuPQicAMCwWjmKHuCxXIPgDAU.pRGxScpVOokrwgzCeoGGDnJeZOJP;
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
				if (ReInput.isReady && SLPfoLEFsScnNhJxiHwVjPkEzuFMe != null)
				{
					SLPfoLEFsScnNhJxiHwVjPkEzuFMe.dsySnzlaDCdVTBdBHhqcOjWsSalGA();
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
				if (ReInput.isReady && SLPfoLEFsScnNhJxiHwVjPkEzuFMe != null)
				{
					SLPfoLEFsScnNhJxiHwVjPkEzuFMe.pjBoYQDQmYltEbIDwnlpAnwItxcv();
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
				if (ReInput.isReady && SLPfoLEFsScnNhJxiHwVjPkEzuFMe != null)
				{
					SLPfoLEFsScnNhJxiHwVjPkEzuFMe.uOrKQcLYTlGJqVnyiQqbMnhcLgPQ();
				}
			}
		}

		public string key => _key;

		public string positiveKey => _positiveKey;

		public string negativeKey => _negativeKey;

		string IControllerElementIdentifierCommon_Internal.nonLocalizedName => nonLocalizedName;

		string IControllerElementIdentifierCommon_Internal.nonLocalizedPositiveName => nonLocalizedPositiveName;

		string IControllerElementIdentifierCommon_Internal.nonLocalizedNegativeName => nonLocalizedNegativeName;

		bool IControllerElementIdentifierCommon_Internal.isNonLocalizedPositiveNameAutoGenerated => (rDnRVTAZXyaVlJOBjDydLOTjrRpD & 2) != 0;

		bool IControllerElementIdentifierCommon_Internal.isNonLocalizedNegativeNameAutoGenerated => (rDnRVTAZXyaVlJOBjDydLOTjrRpD & 4) != 0;

		bool IControllerElementIdentifierCommon_Internal.isPositiveKeyAutoGenerated => (rDnRVTAZXyaVlJOBjDydLOTjrRpD & 8) != 0;

		bool IControllerElementIdentifierCommon_Internal.isNegativeKeyAutoGenerated => (rDnRVTAZXyaVlJOBjDydLOTjrRpD & 0x10) != 0;

		string IControllerElementIdentifierCommon_Internal.key => _key;

		string IControllerElementIdentifierCommon_Internal.positiveKey => _positiveKey;

		string IControllerElementIdentifierCommon_Internal.negativeKey => _negativeKey;

		DeviceLocalizationInfo IControllerElementIdentifierCommon_Internal.deviceLocalizationInfo => epyWrMiKarPbsrBGIHCyAJPFVlJb;

		object IControllerElementIdentifierCommon_Internal.elementType => _elementType;

		bool IControllerElementIdentifierCommon_Internal.useEditorElementTypeOverride => useEditorElementTypeOverride;

		ControllerElementType IControllerElementIdentifierCommon_Internal.editorElementTypeOverride => editorElementTypeOverride;

		string jtAeQMwqfCHdCmeHvhaRCqwDmBxb.keyCategory => "controller/template";

		string jtAeQMwqfCHdCmeHvhaRCqwDmBxb.scriptingName => _name;

		string jtAeQMwqfCHdCmeHvhaRCqwDmBxb.nonLocalizedDescriptiveName
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

		string dEyHRFFHMmNkBjyccsmusjbnHemDB.nonLocalizedPositiveDescriptiveName
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

		string dEyHRFFHMmNkBjyccsmusjbnHemDB.nonLocalizedNegativeDescriptiveName
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

		string LFxfRtFXyxgAjxbmpHDNQNxOPKov.keyCategory => "controller/template";

		string LFxfRtFXyxgAjxbmpHDNQNxOPKov.key => _key;

		int LFxfRtFXyxgAjxbmpHDNQNxOPKov.autoGeneratedValueFlags
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

		string rCWArSkiHiMJlBWAwpbfXxbyxlrS.positiveKey
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

		string rCWArSkiHiMJlBWAwpbfXxbyxlrS.negativeKey
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
			if (!ReInput.isReady || !LocalizationManager.isEnabled || OLOLEwAKWvVmPXetyNZCpPteStbQ == null || zrpEYcFUWSBuEfCWAnwfBrLHsZprB == null)
			{
				return string.Empty;
			}
			return zrpEYcFUWSBuEfCWAnwfBrLHsZprB.jzbdtVDIZOFSEAfWzRXPFuJyPfqpA(index);
		}

		internal object GetCompoundElementSpecialGlyph(int index)
		{
			if (!ReInput.isReady || !GlyphManager.isEnabled || OLOLEwAKWvVmPXetyNZCpPteStbQ == null || fukAMpFlyRVJAYIUopivTNDNCrwIA == null)
			{
				return null;
			}
			return fukAMpFlyRVJAYIUopivTNDNCrwIA.RbwazNyPnwaYWhMAtptGmUWlMPlHb(index);
		}

		string IControllerElementIdentifierCommon_Internal.GetSpecialElementNonLocalizedName(int index)
		{
			if (OLOLEwAKWvVmPXetyNZCpPteStbQ == null || (uint)index >= (uint)OLOLEwAKWvVmPXetyNZCpPteStbQ.Count)
			{
				return null;
			}
			return OLOLEwAKWvVmPXetyNZCpPteStbQ[index].mNsOLThYGSOFZLagKTDbbifzFlKD;
		}

		string IControllerElementIdentifierCommon_Internal.GetSpecialElementKey(int index)
		{
			if (OLOLEwAKWvVmPXetyNZCpPteStbQ == null || (uint)index >= (uint)OLOLEwAKWvVmPXetyNZCpPteStbQ.Count)
			{
				return null;
			}
			return OLOLEwAKWvVmPXetyNZCpPteStbQ[index].EqHcpXWaGauOvKqzuxjiUENyiiKN;
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
			if (P_0.OLOLEwAKWvVmPXetyNZCpPteStbQ != null)
			{
				int count = P_0.OLOLEwAKWvVmPXetyNZCpPteStbQ.Count;
				OLOLEwAKWvVmPXetyNZCpPteStbQ = new List<QIzegiGsImBTHkaztpVTyYzsnlbI>(count);
				for (int i = 0; i < count; i++)
				{
					if (P_0.OLOLEwAKWvVmPXetyNZCpPteStbQ[i] != null)
					{
						OLOLEwAKWvVmPXetyNZCpPteStbQ.Add(new QIzegiGsImBTHkaztpVTyYzsnlbI(P_0.OLOLEwAKWvVmPXetyNZCpPteStbQ[i]));
					}
				}
			}
			rDnRVTAZXyaVlJOBjDydLOTjrRpD = P_0.rDnRVTAZXyaVlJOBjDydLOTjrRpD;
		}

		internal ControllerTemplateElementIdentifier(nLaFzIMACsxsXEozUenVJiqGTrjCA P_0)
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
			switch (_elementType)
			{
			case ControllerTemplateElementType.Axis:
				switch (axisRange)
				{
				case AxisRange.Full:
					return name;
				case AxisRange.Positive:
					return positiveName;
				case AxisRange.Negative:
					return negativeName;
				default:
					throw new NotImplementedException();
				}
			default:
				return name;
			}
		}

		public object GetGlyph(AxisRange axisRange)
		{
			switch (_elementType)
			{
			case ControllerTemplateElementType.Axis:
				switch (axisRange)
				{
				case AxisRange.Full:
					return glyph;
				case AxisRange.Positive:
					return positiveGlyph;
				case AxisRange.Negative:
					return negativeGlyph;
				default:
					throw new NotImplementedException();
				}
			default:
				return glyph;
			}
		}

		public string GetFinalGlyphKey(AxisRange axisRange)
		{
			switch (_elementType)
			{
			case ControllerTemplateElementType.Axis:
				switch (axisRange)
				{
				case AxisRange.Full:
					return finalGlyphKey;
				case AxisRange.Positive:
					return finalPositiveGlyphKey;
				case AxisRange.Negative:
					return finalNegativeGlyphKey;
				default:
					throw new NotImplementedException();
				}
			default:
				return finalGlyphKey;
			}
		}

		internal ControllerElementIdentifier ToControllerElementIdentifier(IHardwareControllerMap_Internal hardwareControllerMap)
		{
			ControllerElementIdentifier controllerElementIdentifier = new ControllerElementIdentifier(new ControllerElementIdentifier.tFlDtgfYnOzWvNSCbItkRRpZbpCKA
			{
				id = _id,
				name = _name,
				positiveName = _positiveName,
				negativeName = _negativeName,
				key = _key,
				positiveKey = _positiveKey,
				negativeKey = _negativeKey,
				elementType = uAOMfTHsnTLbvEUpHTchXYOhMgjh.emBXVZpTuXINfilcDcYgCfWhEPDJA(_elementType),
				compoundElementType = CompoundControllerElementType.Axis2D
			});
			if (ReInput.isReady && epyWrMiKarPbsrBGIHCyAJPFVlJb != null && hardwareControllerMap != null)
			{
				DeviceLocalizationInfo deviceLocalizationInfo = new DeviceLocalizationInfo(hardwareControllerMap.controllerType, false, hardwareControllerMap.typeGuid, new List<string> { hardwareControllerMap.typeKey }, null);
				deviceLocalizationInfo.FinishRuntimeSetup();
				controllerElementIdentifier.FinishRuntimeSetup(deviceLocalizationInfo, hardwareControllerMap.controllerType);
			}
			return controllerElementIdentifier;
		}

		internal void FinishRuntimeSetup(DeviceLocalizationInfo deviceLocalizationInfo)
		{
			mrryxSYKcgqtoCBOuxBTLMStvaRw(_elementType, out var vwAEfXIfCgCiohhuMMznDzgWRhLp, out var bETiEQbYCrQRqCLRvbSAcJMPkrdD);
			int num = JSWalVgNfayAAqqgkCDSfWJdaAMTB.hMtVUAEviNnyqkiTSEVFSjpeZUfm(vwAEfXIfCgCiohhuMMznDzgWRhLp, bETiEQbYCrQRqCLRvbSAcJMPkrdD);
			if (num > 0)
			{
				OLOLEwAKWvVmPXetyNZCpPteStbQ = new List<QIzegiGsImBTHkaztpVTyYzsnlbI>(num);
				for (int i = 0; i < num; i++)
				{
					OLOLEwAKWvVmPXetyNZCpPteStbQ.Add(new QIzegiGsImBTHkaztpVTyYzsnlbI());
				}
			}
			epyWrMiKarPbsrBGIHCyAJPFVlJb = deviceLocalizationInfo;
			if (SLPfoLEFsScnNhJxiHwVjPkEzuFMe == null)
			{
				SLPfoLEFsScnNhJxiHwVjPkEzuFMe = jEybDfZnTXMckOeqmWAqoWQFlwGi.VxSNvmooWfTkIVcICGUZnqoUJPDW(this, urAVZRefROHDbvendscKLBZHGrdo.ControllerTemplate, vwAEfXIfCgCiohhuMMznDzgWRhLp, bETiEQbYCrQRqCLRvbSAcJMPkrdD, _id, deviceLocalizationInfo);
			}
			if (jXTeuPQicAMCwWjmKHuCxXIPgDAU == null)
			{
				jXTeuPQicAMCwWjmKHuCxXIPgDAU = CBBcwUwBZJdGbsAcSWRxdrIUNhtA.VxSNvmooWfTkIVcICGUZnqoUJPDW(this, urAVZRefROHDbvendscKLBZHGrdo.ControllerTemplate, vwAEfXIfCgCiohhuMMznDzgWRhLp, bETiEQbYCrQRqCLRvbSAcJMPkrdD, _id, deviceLocalizationInfo);
			}
			if (vwAEfXIfCgCiohhuMMznDzgWRhLp == JSWalVgNfayAAqqgkCDSfWJdaAMTB.VwAEfXIfCgCiohhuMMznDzgWRhLp.CompoundElement)
			{
				zrpEYcFUWSBuEfCWAnwfBrLHsZprB = YhJXvGNrRKyGdInNEkJoIlMuKlEd.VxSNvmooWfTkIVcICGUZnqoUJPDW(this, urAVZRefROHDbvendscKLBZHGrdo.ControllerTemplate, vwAEfXIfCgCiohhuMMznDzgWRhLp, bETiEQbYCrQRqCLRvbSAcJMPkrdD, _id, deviceLocalizationInfo);
				fukAMpFlyRVJAYIUopivTNDNCrwIA = OAPILVqGWzRVwzMiPuzYuyOIDyhB.VxSNvmooWfTkIVcICGUZnqoUJPDW(this, urAVZRefROHDbvendscKLBZHGrdo.ControllerTemplate, vwAEfXIfCgCiohhuMMznDzgWRhLp, bETiEQbYCrQRqCLRvbSAcJMPkrdD, _id, deviceLocalizationInfo);
			}
		}

		string jYOuwHQLkAMAsMhmCbimJoXgoSaP.GetSpecialElementNonLocalizedDescriptiveName(int index)
		{
			if (OLOLEwAKWvVmPXetyNZCpPteStbQ == null || index >= OLOLEwAKWvVmPXetyNZCpPteStbQ.Count)
			{
				return null;
			}
			return OLOLEwAKWvVmPXetyNZCpPteStbQ[index].mNsOLThYGSOFZLagKTDbbifzFlKD;
		}

		void jYOuwHQLkAMAsMhmCbimJoXgoSaP.SetSpecialElementNonLocalizedDescriptiveName(int index, string value)
		{
			if (OLOLEwAKWvVmPXetyNZCpPteStbQ != null && index < OLOLEwAKWvVmPXetyNZCpPteStbQ.Count)
			{
				OLOLEwAKWvVmPXetyNZCpPteStbQ[index].mNsOLThYGSOFZLagKTDbbifzFlKD = value;
			}
		}

		string jYOuwHQLkAMAsMhmCbimJoXgoSaP.GetSpecialElementKey(int index)
		{
			if (OLOLEwAKWvVmPXetyNZCpPteStbQ == null || index >= OLOLEwAKWvVmPXetyNZCpPteStbQ.Count)
			{
				return null;
			}
			return OLOLEwAKWvVmPXetyNZCpPteStbQ[index].EqHcpXWaGauOvKqzuxjiUENyiiKN;
		}

		void jYOuwHQLkAMAsMhmCbimJoXgoSaP.SetSpecialElementKey(int index, string value)
		{
			if (OLOLEwAKWvVmPXetyNZCpPteStbQ != null && index < OLOLEwAKWvVmPXetyNZCpPteStbQ.Count)
			{
				OLOLEwAKWvVmPXetyNZCpPteStbQ[index].EqHcpXWaGauOvKqzuxjiUENyiiKN = value;
			}
		}

		string yBPKsUhYrRiyCEpVcVcLwcBSjoGT.GetSpecialElementKey(int index)
		{
			if (OLOLEwAKWvVmPXetyNZCpPteStbQ == null || index >= OLOLEwAKWvVmPXetyNZCpPteStbQ.Count)
			{
				return null;
			}
			return OLOLEwAKWvVmPXetyNZCpPteStbQ[index].EqHcpXWaGauOvKqzuxjiUENyiiKN;
		}

		void yBPKsUhYrRiyCEpVcVcLwcBSjoGT.SetSpecialElementKey(int index, string value)
		{
			if (OLOLEwAKWvVmPXetyNZCpPteStbQ != null && index < OLOLEwAKWvVmPXetyNZCpPteStbQ.Count)
			{
				OLOLEwAKWvVmPXetyNZCpPteStbQ[index].EqHcpXWaGauOvKqzuxjiUENyiiKN = value;
			}
		}

		private static void mrryxSYKcgqtoCBOuxBTLMStvaRw(ControllerTemplateElementType P_0, out JSWalVgNfayAAqqgkCDSfWJdaAMTB.VwAEfXIfCgCiohhuMMznDzgWRhLp P_1, out JSWalVgNfayAAqqgkCDSfWJdaAMTB.bETiEQbYCrQRqCLRvbSAcJMPkrdD P_2)
		{
			P_2 = JSWalVgNfayAAqqgkCDSfWJdaAMTB.bETiEQbYCrQRqCLRvbSAcJMPkrdD.None;
			switch (P_0)
			{
			case ControllerTemplateElementType.Axis:
				P_1 = JSWalVgNfayAAqqgkCDSfWJdaAMTB.VwAEfXIfCgCiohhuMMznDzgWRhLp.Axis;
				break;
			case ControllerTemplateElementType.Button:
				P_1 = JSWalVgNfayAAqqgkCDSfWJdaAMTB.VwAEfXIfCgCiohhuMMznDzgWRhLp.Button;
				break;
			case ControllerTemplateElementType.Hat:
				P_1 = JSWalVgNfayAAqqgkCDSfWJdaAMTB.VwAEfXIfCgCiohhuMMznDzgWRhLp.CompoundElement;
				P_2 = JSWalVgNfayAAqqgkCDSfWJdaAMTB.bETiEQbYCrQRqCLRvbSAcJMPkrdD.Hat;
				break;
			case ControllerTemplateElementType.DPad:
				P_1 = JSWalVgNfayAAqqgkCDSfWJdaAMTB.VwAEfXIfCgCiohhuMMznDzgWRhLp.CompoundElement;
				P_2 = JSWalVgNfayAAqqgkCDSfWJdaAMTB.bETiEQbYCrQRqCLRvbSAcJMPkrdD.DPad;
				break;
			case ControllerTemplateElementType.ThumbStick:
				P_1 = JSWalVgNfayAAqqgkCDSfWJdaAMTB.VwAEfXIfCgCiohhuMMznDzgWRhLp.CompoundElement;
				break;
			case ControllerTemplateElementType.Yoke:
				P_1 = JSWalVgNfayAAqqgkCDSfWJdaAMTB.VwAEfXIfCgCiohhuMMznDzgWRhLp.Unknown;
				break;
			case ControllerTemplateElementType.Throttle:
				P_1 = JSWalVgNfayAAqqgkCDSfWJdaAMTB.VwAEfXIfCgCiohhuMMznDzgWRhLp.Unknown;
				break;
			case ControllerTemplateElementType.Stick:
				P_1 = JSWalVgNfayAAqqgkCDSfWJdaAMTB.VwAEfXIfCgCiohhuMMznDzgWRhLp.CompoundElement;
				P_2 = JSWalVgNfayAAqqgkCDSfWJdaAMTB.bETiEQbYCrQRqCLRvbSAcJMPkrdD.Stick;
				break;
			case ControllerTemplateElementType.Stick6D:
				P_1 = JSWalVgNfayAAqqgkCDSfWJdaAMTB.VwAEfXIfCgCiohhuMMznDzgWRhLp.CompoundElement;
				P_2 = JSWalVgNfayAAqqgkCDSfWJdaAMTB.bETiEQbYCrQRqCLRvbSAcJMPkrdD.Stick6D;
				break;
			default:
				P_1 = JSWalVgNfayAAqqgkCDSfWJdaAMTB.VwAEfXIfCgCiohhuMMznDzgWRhLp.Unknown;
				break;
			}
		}
	}
}
