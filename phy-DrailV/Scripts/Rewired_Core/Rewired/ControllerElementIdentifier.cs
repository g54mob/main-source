using System;
using System.Collections.Generic;
using Rewired.Interfaces;
using Rewired.Internal.Glyphs;
using Rewired.Internal.Localization;
using UnityEngine;

namespace Rewired
{
	[Serializable]
	[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
	public sealed class ControllerElementIdentifier : IControllerElementIdentifierCommon_Internal, jtAeQMwqfCHdCmeHvhaRCqwDmBxb, dEyHRFFHMmNkBjyccsmusjbnHemDB, jYOuwHQLkAMAsMhmCbimJoXgoSaP, LFxfRtFXyxgAjxbmpHDNQNxOPKov, rCWArSkiHiMJlBWAwpbfXxbyxlrS, yBPKsUhYrRiyCEpVcVcLwcBSjoGT
	{
		[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
		internal class tFlDtgfYnOzWvNSCbItkRRpZbpCKA
		{
			public int id;

			public string name;

			public string positiveName;

			public string negativeName;

			public string key;

			public string positiveKey;

			public string negativeKey;

			public ControllerElementType elementType;

			public CompoundControllerElementType compoundElementType;
		}

		internal sealed class kFJMIubFNRLrPnUoPEZxqkAJZTEm
		{
			[Serializable]
			private sealed class qrQUfkVNpCgOopDuKIiIjgAkaRkHA
			{
				public static readonly qrQUfkVNpCgOopDuKIiIjgAkaRkHA _003C_003E9 = new qrQUfkVNpCgOopDuKIiIjgAkaRkHA();

				public static Func<ControllerElementIdentifier, ControllerElementIdentifier, bool> _003C_003E9__4_0;

				internal bool HPScvmzpeFILbfrZHMdIvcQHrMWE(ControllerElementIdentifier P_0, ControllerElementIdentifier P_1)
				{
					if (P_0 == null || P_1 == null)
					{
						return false;
					}
					if (P_0 != null && P_1 != null && P_0.id == P_1.id && P_0.elementType == P_1.elementType && P_0.compoundElementType == P_1.compoundElementType)
					{
						return string.Equals(P_0.key, P_1.key, StringComparison.Ordinal);
					}
					return false;
				}
			}

			private static kFJMIubFNRLrPnUoPEZxqkAJZTEm AAsUotzmeurdNsprWlhSRkCHGMyW;

			private readonly RJmfAjpdKLIIXgAAMaxkVDnckcjN<ControllerElementIdentifier> OMwBQfLhmVTNVZtCfEIYYJfZqvfF;

			private static kFJMIubFNRLrPnUoPEZxqkAJZTEm kYNBFgnEJgclbFwpvHMfwUfnUCch
			{
				get
				{
					if (AAsUotzmeurdNsprWlhSRkCHGMyW != null)
					{
						return AAsUotzmeurdNsprWlhSRkCHGMyW;
					}
					AAsUotzmeurdNsprWlhSRkCHGMyW = new kFJMIubFNRLrPnUoPEZxqkAJZTEm();
					AAsUotzmeurdNsprWlhSRkCHGMyW.eYVBLUcuQlHJrbHrStsdmfsWfTEHA();
					return AAsUotzmeurdNsprWlhSRkCHGMyW;
				}
			}

			private kFJMIubFNRLrPnUoPEZxqkAJZTEm()
			{
				OMwBQfLhmVTNVZtCfEIYYJfZqvfF = new RJmfAjpdKLIIXgAAMaxkVDnckcjN<ControllerElementIdentifier>(qrQUfkVNpCgOopDuKIiIjgAkaRkHA._003C_003E9.HPScvmzpeFILbfrZHMdIvcQHrMWE);
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

			public static ControllerElementIdentifier RGGJWIgQTGFjrbkplAhDgRPBiCkT(DeviceLocalizationInfo P_0, ControllerElementIdentifier P_1)
			{
				return kYNBFgnEJgclbFwpvHMfwUfnUCch.OMwBQfLhmVTNVZtCfEIYYJfZqvfF.RGGJWIgQTGFjrbkplAhDgRPBiCkT(P_0.hash, P_1);
			}

			public static bool XoWrPhuuoYdElFYmsPRgFLepADbg(DeviceLocalizationInfo P_0, ControllerElementIdentifier P_1, out ControllerElementIdentifier P_2)
			{
				return kYNBFgnEJgclbFwpvHMfwUfnUCch.OMwBQfLhmVTNVZtCfEIYYJfZqvfF.XoWrPhuuoYdElFYmsPRgFLepADbg(P_0.hash, P_1, out P_2);
			}

			public static void fyeqCafQbFyflbNbajUvornPxfgy(DeviceLocalizationInfo P_0, ControllerElementIdentifier P_1)
			{
				kYNBFgnEJgclbFwpvHMfwUfnUCch.OMwBQfLhmVTNVZtCfEIYYJfZqvfF.fyeqCafQbFyflbNbajUvornPxfgy(P_0.hash, P_1);
			}
		}

		private class cfhTUVTkbSbKVbPNgeLrJNtGZSBGA
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

			public cfhTUVTkbSbKVbPNgeLrJNtGZSBGA()
			{
			}

			public cfhTUVTkbSbKVbPNgeLrJNtGZSBGA(cfhTUVTkbSbKVbPNgeLrJNtGZSBGA P_0)
			{
				iznbkRlQcoGkZtBlmfunFSNsZtUK = P_0.iznbkRlQcoGkZtBlmfunFSNsZtUK;
				RlKaAhpsSUeErkCKDIWEsgnXFvlrA = P_0.RlKaAhpsSUeErkCKDIWEsgnXFvlrA;
			}
		}

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int _id;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private string _name;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private string _positiveName;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private string _negativeName;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string _key;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private string _positiveKey;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string _negativeKey;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private ControllerElementType _elementType;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private CompoundControllerElementType _compoundElementType;

		[NonSerialized]
		private bool rCxpMQVgnbHMXbPnzbIJKnLAsxtgA;

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
		private List<cfhTUVTkbSbKVbPNgeLrJNtGZSBGA> OLOLEwAKWvVmPXetyNZCpPteStbQ;

		[NonSerialized]
		private ControllerType ueTsfWyPNTdEyAOjfZNcYrBGNSmq;

		private static ControllerElementIdentifier njVIjTeJVkZCbAcKCmtVRuCNPplQ;

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

		public ControllerElementType elementType => _elementType;

		public CompoundControllerElementType compoundElementType => _compoundElementType;

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
				if (ReInput.isReady)
				{
					NceLTawNRCFtQIhgIwCphHItAgXv();
					if (SLPfoLEFsScnNhJxiHwVjPkEzuFMe != null)
					{
						SLPfoLEFsScnNhJxiHwVjPkEzuFMe.dsySnzlaDCdVTBdBHhqcOjWsSalGA();
					}
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
				if (ReInput.isReady)
				{
					NceLTawNRCFtQIhgIwCphHItAgXv();
					if (SLPfoLEFsScnNhJxiHwVjPkEzuFMe != null)
					{
						SLPfoLEFsScnNhJxiHwVjPkEzuFMe.pjBoYQDQmYltEbIDwnlpAnwItxcv();
					}
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
				if (ReInput.isReady)
				{
					NceLTawNRCFtQIhgIwCphHItAgXv();
					if (SLPfoLEFsScnNhJxiHwVjPkEzuFMe != null)
					{
						SLPfoLEFsScnNhJxiHwVjPkEzuFMe.uOrKQcLYTlGJqVnyiQqbMnhcLgPQ();
					}
				}
			}
		}

		public string key => _key;

		public string positiveKey => _positiveKey;

		public string negativeKey => _negativeKey;

		internal bool isCompoundElement => _elementType == ControllerElementType.CompoundElement;

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

		bool IControllerElementIdentifierCommon_Internal.useEditorElementTypeOverride => false;

		ControllerElementType IControllerElementIdentifierCommon_Internal.editorElementTypeOverride => _elementType;

		internal static ControllerElementIdentifier BlankReadOnly
		{
			get
			{
				if (njVIjTeJVkZCbAcKCmtVRuCNPplQ == null)
				{
					ControllerElementIdentifier result = new ControllerElementIdentifier
					{
						_id = -1,
						rCxpMQVgnbHMXbPnzbIJKnLAsxtgA = true
					};
					njVIjTeJVkZCbAcKCmtVRuCNPplQ = result;
					return result;
				}
				return njVIjTeJVkZCbAcKCmtVRuCNPplQ;
			}
		}

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
				NceLTawNRCFtQIhgIwCphHItAgXv();
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
				NceLTawNRCFtQIhgIwCphHItAgXv();
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
				NceLTawNRCFtQIhgIwCphHItAgXv();
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
				NceLTawNRCFtQIhgIwCphHItAgXv();
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
				NceLTawNRCFtQIhgIwCphHItAgXv();
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

		string LFxfRtFXyxgAjxbmpHDNQNxOPKov.keyCategory => bYUfoUKGpLnbYkcOYAkjmqgxLxsS.JCFGlogpCHkdrSooohIxKLMgQkvOA(ueTsfWyPNTdEyAOjfZNcYrBGNSmq);

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
				NceLTawNRCFtQIhgIwCphHItAgXv();
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
				NceLTawNRCFtQIhgIwCphHItAgXv();
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

		internal string GetCompoundElementSpecialFinalGlyphKey(int index)
		{
			if (!ReInput.isReady || !GlyphManager.isEnabled || OLOLEwAKWvVmPXetyNZCpPteStbQ == null || fukAMpFlyRVJAYIUopivTNDNCrwIA == null)
			{
				return null;
			}
			return fukAMpFlyRVJAYIUopivTNDNCrwIA.OKEtlQZtvOkFHmftvxtaSTbWLGsy(index);
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

		public ControllerElementIdentifier()
		{
		}

		public ControllerElementIdentifier(ControllerElementIdentifier P_0)
		{
			_id = P_0._id;
			_name = P_0._name;
			_positiveName = P_0._positiveName;
			_negativeName = P_0._negativeName;
			_key = P_0._key;
			_positiveKey = P_0._positiveKey;
			_negativeKey = P_0._negativeKey;
			_elementType = P_0._elementType;
			_compoundElementType = P_0._compoundElementType;
			if (P_0.OLOLEwAKWvVmPXetyNZCpPteStbQ != null)
			{
				int count = P_0.OLOLEwAKWvVmPXetyNZCpPteStbQ.Count;
				OLOLEwAKWvVmPXetyNZCpPteStbQ = new List<cfhTUVTkbSbKVbPNgeLrJNtGZSBGA>(count);
				for (int i = 0; i < count; i++)
				{
					if (P_0.OLOLEwAKWvVmPXetyNZCpPteStbQ[i] != null)
					{
						OLOLEwAKWvVmPXetyNZCpPteStbQ.Add(new cfhTUVTkbSbKVbPNgeLrJNtGZSBGA(P_0.OLOLEwAKWvVmPXetyNZCpPteStbQ[i]));
					}
				}
			}
			rDnRVTAZXyaVlJOBjDydLOTjrRpD = P_0.rDnRVTAZXyaVlJOBjDydLOTjrRpD;
			ueTsfWyPNTdEyAOjfZNcYrBGNSmq = P_0.ueTsfWyPNTdEyAOjfZNcYrBGNSmq;
		}

		internal ControllerElementIdentifier(tFlDtgfYnOzWvNSCbItkRRpZbpCKA P_0)
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
			_compoundElementType = P_0.compoundElementType;
		}

		[Obsolete("Used by plugins for mouse controllers. Left for plugin compatibility. Do not use.", false)]
		internal ControllerElementIdentifier(int P_0, string P_1, string P_2, string P_3, ControllerElementType P_4, CompoundControllerElementType P_5, bool P_6)
		{
			_id = P_0;
			_name = P_1;
			_positiveName = P_2;
			_negativeName = P_3;
			if (P_0 < Consts.commonMouseElementIdentifierInitOptions.Length && string.Equals(Consts.commonMouseElementIdentifierInitOptions[P_0].name, P_1, StringComparison.Ordinal))
			{
				_key = Consts.commonMouseElementIdentifierInitOptions[P_0].key;
				_positiveKey = Consts.commonMouseElementIdentifierInitOptions[P_0].key;
				_negativeKey = Consts.commonMouseElementIdentifierInitOptions[P_0].key;
			}
			_elementType = P_4;
			_compoundElementType = P_5;
		}

		[Obsolete("Used by UnifiedKeyboardSource. Left for plugin compatibility. Do not use.", false)]
		internal ControllerElementIdentifier(int P_0, string P_1, string P_2, string P_3, ControllerElementType P_4, bool P_5)
		{
			_id = P_0;
			_name = P_1;
			_positiveName = P_2;
			_negativeName = P_3;
			if (P_4 == ControllerElementType.Button && P_0 < Consts.keyboardKeyNames.Count && string.Equals(Consts.keyboardKeyNames[P_0], P_1, StringComparison.Ordinal))
			{
				_key = Consts.keyboardKeyKeys[P_0];
			}
			_elementType = P_4;
			_compoundElementType = CompoundControllerElementType.Axis2D;
		}

		internal ControllerElementIdentifier(ControllerElementIdentifier P_0, bool P_1, ControllerElementType P_2)
			: this(P_0)
		{
			_elementType = P_2;
		}

		public ControllerElementIdentifier Clone()
		{
			return new ControllerElementIdentifier(this);
		}

		public string GetDisplayName(ControllerElementType actualElementType, AxisRange axisRange)
		{
			switch (actualElementType)
			{
			case ControllerElementType.Axis:
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
			case ControllerElementType.Button:
				return name;
			case ControllerElementType.CompoundElement:
				return name;
			default:
				throw new NotImplementedException();
			}
		}

		public string GetDisplayName(AxisRange axisRange)
		{
			return GetDisplayName(_elementType, axisRange);
		}

		public object GetGlyph(ControllerElementType actualElementType, AxisRange axisRange)
		{
			switch (actualElementType)
			{
			case ControllerElementType.Axis:
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
			case ControllerElementType.Button:
				return glyph;
			case ControllerElementType.CompoundElement:
				return glyph;
			default:
				throw new NotImplementedException();
			}
		}

		public object GetGlyph(AxisRange axisRange)
		{
			return GetGlyph(_elementType, axisRange);
		}

		public string GetFinalGlyphKey(ControllerElementType actualElementType, AxisRange axisRange)
		{
			switch (actualElementType)
			{
			case ControllerElementType.Axis:
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
			case ControllerElementType.Button:
				return finalGlyphKey;
			case ControllerElementType.CompoundElement:
				return finalGlyphKey;
			default:
				throw new NotImplementedException();
			}
		}

		public string GetFinalGlyphKey(AxisRange axisRange)
		{
			return GetFinalGlyphKey(_elementType, axisRange);
		}

		private void NceLTawNRCFtQIhgIwCphHItAgXv()
		{
			if (rCxpMQVgnbHMXbPnzbIJKnLAsxtgA)
			{
				throw new Exception("The object is marked readonly and you are trying to modify its values.");
			}
		}

		internal void FinishRuntimeSetup(DeviceLocalizationInfo deviceLocalizationInfo, ControllerType controllerType)
		{
			ueTsfWyPNTdEyAOjfZNcYrBGNSmq = controllerType;
			ToElementNameLocalizerTypes(_elementType, _compoundElementType, out var resultElementType, out var resultCompoundElementType);
			int num = JSWalVgNfayAAqqgkCDSfWJdaAMTB.hMtVUAEviNnyqkiTSEVFSjpeZUfm(resultElementType, resultCompoundElementType);
			if (num > 0)
			{
				OLOLEwAKWvVmPXetyNZCpPteStbQ = new List<cfhTUVTkbSbKVbPNgeLrJNtGZSBGA>(num);
				for (int i = 0; i < num; i++)
				{
					OLOLEwAKWvVmPXetyNZCpPteStbQ.Add(new cfhTUVTkbSbKVbPNgeLrJNtGZSBGA());
				}
			}
			epyWrMiKarPbsrBGIHCyAJPFVlJb = deviceLocalizationInfo;
			SLPfoLEFsScnNhJxiHwVjPkEzuFMe = jEybDfZnTXMckOeqmWAqoWQFlwGi.VxSNvmooWfTkIVcICGUZnqoUJPDW(this, aqLewuKlVQKcoSnovjzXZJZqbNSdA.BoXAbDakqcmTyPLTCFwGADkAWHTfc(controllerType), resultElementType, resultCompoundElementType, _id, deviceLocalizationInfo);
			jXTeuPQicAMCwWjmKHuCxXIPgDAU = CBBcwUwBZJdGbsAcSWRxdrIUNhtA.VxSNvmooWfTkIVcICGUZnqoUJPDW(this, aqLewuKlVQKcoSnovjzXZJZqbNSdA.BoXAbDakqcmTyPLTCFwGADkAWHTfc(controllerType), resultElementType, resultCompoundElementType, _id, deviceLocalizationInfo);
			if (_elementType == ControllerElementType.CompoundElement)
			{
				zrpEYcFUWSBuEfCWAnwfBrLHsZprB = YhJXvGNrRKyGdInNEkJoIlMuKlEd.VxSNvmooWfTkIVcICGUZnqoUJPDW(this, aqLewuKlVQKcoSnovjzXZJZqbNSdA.BoXAbDakqcmTyPLTCFwGADkAWHTfc(controllerType), resultElementType, resultCompoundElementType, _id, deviceLocalizationInfo);
				fukAMpFlyRVJAYIUopivTNDNCrwIA = OAPILVqGWzRVwzMiPuzYuyOIDyhB.VxSNvmooWfTkIVcICGUZnqoUJPDW(this, aqLewuKlVQKcoSnovjzXZJZqbNSdA.BoXAbDakqcmTyPLTCFwGADkAWHTfc(controllerType), resultElementType, resultCompoundElementType, _id, deviceLocalizationInfo);
			}
		}

		internal static void ToElementNameLocalizerTypes(ControllerElementType type, CompoundControllerElementType compoundType, out JSWalVgNfayAAqqgkCDSfWJdaAMTB.VwAEfXIfCgCiohhuMMznDzgWRhLp resultElementType, out JSWalVgNfayAAqqgkCDSfWJdaAMTB.bETiEQbYCrQRqCLRvbSAcJMPkrdD resultCompoundElementType)
		{
			resultCompoundElementType = JSWalVgNfayAAqqgkCDSfWJdaAMTB.bETiEQbYCrQRqCLRvbSAcJMPkrdD.None;
			switch (type)
			{
			case ControllerElementType.Axis:
				resultElementType = JSWalVgNfayAAqqgkCDSfWJdaAMTB.VwAEfXIfCgCiohhuMMznDzgWRhLp.Axis;
				break;
			case ControllerElementType.Button:
				resultElementType = JSWalVgNfayAAqqgkCDSfWJdaAMTB.VwAEfXIfCgCiohhuMMznDzgWRhLp.Button;
				break;
			case ControllerElementType.CompoundElement:
				resultElementType = JSWalVgNfayAAqqgkCDSfWJdaAMTB.VwAEfXIfCgCiohhuMMznDzgWRhLp.CompoundElement;
				switch (compoundType)
				{
				case CompoundControllerElementType.Axis2D:
					resultCompoundElementType = JSWalVgNfayAAqqgkCDSfWJdaAMTB.bETiEQbYCrQRqCLRvbSAcJMPkrdD.Axis2D;
					break;
				case CompoundControllerElementType.Hat:
					resultCompoundElementType = JSWalVgNfayAAqqgkCDSfWJdaAMTB.bETiEQbYCrQRqCLRvbSAcJMPkrdD.Hat;
					break;
				case CompoundControllerElementType.DPad:
					resultCompoundElementType = JSWalVgNfayAAqqgkCDSfWJdaAMTB.bETiEQbYCrQRqCLRvbSAcJMPkrdD.DPad;
					break;
				default:
					resultElementType = JSWalVgNfayAAqqgkCDSfWJdaAMTB.VwAEfXIfCgCiohhuMMznDzgWRhLp.Unknown;
					break;
				}
				break;
			default:
				resultElementType = JSWalVgNfayAAqqgkCDSfWJdaAMTB.VwAEfXIfCgCiohhuMMznDzgWRhLp.Unknown;
				break;
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
	}
}
