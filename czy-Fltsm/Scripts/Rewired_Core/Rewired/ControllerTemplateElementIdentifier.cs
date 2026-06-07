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
	public class ControllerTemplateElementIdentifier : IControllerElementIdentifierCommon_Internal, IControllerTemplateElementIdentifier, qlShIqeuHSIRhnLpCXWfkIdpMdpx, sZLAxvZSvDRmVjMjTVRhHfujppQp, ciioobTlGUakXNuXSZWsSBbYJisy, IkNokIafnDXAZobQNzBQDEduXYfJ, orgqfgrCrmobGJnxqbGdAMXEeZnY, ljpLhlKaijVdgLAKEnJGvqHultLG
	{
		[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
		internal class mVWcarxtJAcRlKTuiPXSObkcrwgnA
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

		internal sealed class LbpTNHNkqlWCnLIWmRiRivKZtjC
		{
			[Serializable]
			private sealed class ZlGDssAQinzaejWVxFIjGGGGqbKs
			{
				public static readonly ZlGDssAQinzaejWVxFIjGGGGqbKs _003C_003E9 = new ZlGDssAQinzaejWVxFIjGGGGqbKs();

				public static Func<ControllerTemplateElementIdentifier, ControllerTemplateElementIdentifier, bool> _003C_003E9__4_0;

				internal bool vDGVMISYFkAGAwzQOoOtsHAbsvZB(ControllerTemplateElementIdentifier P_0, ControllerTemplateElementIdentifier P_1)
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

			private static LbpTNHNkqlWCnLIWmRiRivKZtjC WQCCRdDPqnHjmJlGtIFhaGnLftNV;

			private readonly global::QTCiASUCDvHtbdUBoOAdSPzWjRqL<ControllerTemplateElementIdentifier> aTWMRbRswtXtmOjGxAVvmFJrFiId;

			private static LbpTNHNkqlWCnLIWmRiRivKZtjC BbKWIHxHsUZPpThjcPNithLLbFAs
			{
				get
				{
					if (WQCCRdDPqnHjmJlGtIFhaGnLftNV != null)
					{
						return WQCCRdDPqnHjmJlGtIFhaGnLftNV;
					}
					WQCCRdDPqnHjmJlGtIFhaGnLftNV = new LbpTNHNkqlWCnLIWmRiRivKZtjC();
					WQCCRdDPqnHjmJlGtIFhaGnLftNV.NKAYwzLKeVOVhJaMbpuCdMpbPslQ();
					return WQCCRdDPqnHjmJlGtIFhaGnLftNV;
				}
			}

			private LbpTNHNkqlWCnLIWmRiRivKZtjC()
			{
				aTWMRbRswtXtmOjGxAVvmFJrFiId = new global::QTCiASUCDvHtbdUBoOAdSPzWjRqL<ControllerTemplateElementIdentifier>(ZlGDssAQinzaejWVxFIjGGGGqbKs._003C_003E9.vDGVMISYFkAGAwzQOoOtsHAbsvZB);
			}

			private void NKAYwzLKeVOVhJaMbpuCdMpbPslQ()
			{
				ReInput.ShutDownEvent += WQCCRdDPqnHjmJlGtIFhaGnLftNV.HjKEDygHzfMWePBtPxnDrvmiTFYC;
			}

			private void HjKEDygHzfMWePBtPxnDrvmiTFYC()
			{
				if (WQCCRdDPqnHjmJlGtIFhaGnLftNV == this)
				{
					WQCCRdDPqnHjmJlGtIFhaGnLftNV = null;
				}
				ReInput.ShutDownEvent -= HjKEDygHzfMWePBtPxnDrvmiTFYC;
			}

			public static ControllerTemplateElementIdentifier RUOdWShNlOwLTHgKHMTpOsuDbzjBA(DeviceLocalizationInfo P_0, ControllerTemplateElementIdentifier P_1)
			{
				return BbKWIHxHsUZPpThjcPNithLLbFAs.aTWMRbRswtXtmOjGxAVvmFJrFiId.jmbCpDDBCpCHqKMftVWBFAAjqwiI(P_0.hash, P_1);
			}

			public static bool kKLxXkLKNigdNfGeMEaVphhjwzRM(DeviceLocalizationInfo P_0, ControllerTemplateElementIdentifier P_1, out ControllerTemplateElementIdentifier P_2)
			{
				return BbKWIHxHsUZPpThjcPNithLLbFAs.aTWMRbRswtXtmOjGxAVvmFJrFiId.XeiOWkonFmtJDikoHyyLMWSuTCbj(P_0.hash, P_1, out P_2);
			}

			public static void rezfUyvlAJAcsKitNLkDnRKfPYIQA(DeviceLocalizationInfo P_0, ControllerTemplateElementIdentifier P_1)
			{
				BbKWIHxHsUZPpThjcPNithLLbFAs.aTWMRbRswtXtmOjGxAVvmFJrFiId.oKikmsntPJTPfJPjjdAXQftayNjT(P_0.hash, P_1);
			}
		}

		private class ZUTDtJgbBClonxtsPzLEetdWMmwlA
		{
			[SerializeField]
			private string lTyjRfKWkcqIdmKKEpwsRLfCGMUx;

			[SerializeField]
			private string MVLVwwqCKXgJWfKPrHASCqVrAWesA;

			public string bGvzprjFDMbxkUmpUtQLkirTSguV
			{
				get
				{
					return lTyjRfKWkcqIdmKKEpwsRLfCGMUx;
				}
				set
				{
					lTyjRfKWkcqIdmKKEpwsRLfCGMUx = text;
				}
			}

			public string GNhWiNFmyujCBrKIvHIXPiRCCKjhA
			{
				get
				{
					return MVLVwwqCKXgJWfKPrHASCqVrAWesA;
				}
				set
				{
					MVLVwwqCKXgJWfKPrHASCqVrAWesA = mVLVwwqCKXgJWfKPrHASCqVrAWesA;
				}
			}

			public ZUTDtJgbBClonxtsPzLEetdWMmwlA()
			{
			}

			public ZUTDtJgbBClonxtsPzLEetdWMmwlA(ZUTDtJgbBClonxtsPzLEetdWMmwlA P_0)
			{
				lTyjRfKWkcqIdmKKEpwsRLfCGMUx = P_0.lTyjRfKWkcqIdmKKEpwsRLfCGMUx;
				MVLVwwqCKXgJWfKPrHASCqVrAWesA = P_0.MVLVwwqCKXgJWfKPrHASCqVrAWesA;
			}
		}

		private const string bAtJrUafERZEElrwQVjqvlONcnSF = "controller/template";

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
		private qYSmXMgUajfmYTghAqPnrKCzyqDf VNNITSVdTKmbXVJzYVhsRfjziPLV;

		[NonSerialized]
		private BprIJnmtmyBKPDBukEEhRCfQaHNr LQRmnoKCqKCvfLkFIEToGjdiwoPnA;

		[NonSerialized]
		private DafCbHLEKvpEelZNWgaMmtlmrCuT BnEIpurvhEIOkrsbuiNsEmMhmInC;

		[NonSerialized]
		private JkhcLwFHFFDyhsxVbdEcKlqoaKnsA cJlKJDwHtjNlRdCjzaDQkibqBdIfA;

		[NonSerialized]
		private DeviceLocalizationInfo fysLvTCASeokfhmUWXOldYiKJvxM;

		[NonSerialized]
		private int oWEEMWpcqnGRTzZWzGwcYtFgsrpF;

		[NonSerialized]
		private List<ZUTDtJgbBClonxtsPzLEetdWMmwlA> JrqLfSEKVPgcuWmVWYyXoiwCHVLW;

		int IControllerElementIdentifierCommon_Internal.id => _id;

		string IControllerElementIdentifierCommon_Internal.name
		{
			get
			{
				if (!ReInput.isReady || VNNITSVdTKmbXVJzYVhsRfjziPLV == null || !LocalizationManager.isEnabled)
				{
					return _name;
				}
				return VNNITSVdTKmbXVJzYVhsRfjziPLV.HKQoqutKkgeGtFcRmtcKMQqgsDoY;
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
				if (!ReInput.isReady || VNNITSVdTKmbXVJzYVhsRfjziPLV == null || !LocalizationManager.isEnabled)
				{
					return _positiveName;
				}
				return VNNITSVdTKmbXVJzYVhsRfjziPLV.vqTJyxMIVweNIWENvOzgHIrQkYCw;
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
				if (!ReInput.isReady || VNNITSVdTKmbXVJzYVhsRfjziPLV == null || !LocalizationManager.isEnabled)
				{
					return _negativeName;
				}
				return VNNITSVdTKmbXVJzYVhsRfjziPLV.FktASepfaNwtFksADsQexzwgRpBn;
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
				if (!ReInput.isReady || BnEIpurvhEIOkrsbuiNsEmMhmInC == null || !GlyphManager.isEnabled)
				{
					return null;
				}
				return BnEIpurvhEIOkrsbuiNsEmMhmInC.ITvJcTdLSwZWFxvxmcUsUPCUdqCh;
			}
		}

		public object positiveGlyph
		{
			get
			{
				if (!ReInput.isReady || BnEIpurvhEIOkrsbuiNsEmMhmInC == null || !GlyphManager.isEnabled)
				{
					return null;
				}
				return BnEIpurvhEIOkrsbuiNsEmMhmInC.jrBblZZCqzRkAPiflzkvfOhTIunO;
			}
		}

		public object negativeGlyph
		{
			get
			{
				if (!ReInput.isReady || BnEIpurvhEIOkrsbuiNsEmMhmInC == null || !GlyphManager.isEnabled)
				{
					return null;
				}
				return BnEIpurvhEIOkrsbuiNsEmMhmInC.zHbAvTjlSJogNXAtyecrFQjbMiIWA;
			}
		}

		private string finalGlyphKey
		{
			get
			{
				if (!ReInput.isReady || BnEIpurvhEIOkrsbuiNsEmMhmInC == null || !GlyphManager.isEnabled)
				{
					return null;
				}
				return BnEIpurvhEIOkrsbuiNsEmMhmInC.BDdjaOSiBsDOcTLxjYvPPGeVYraO;
			}
		}

		private string finalPositiveGlyphKey
		{
			get
			{
				if (!ReInput.isReady || BnEIpurvhEIOkrsbuiNsEmMhmInC == null || !GlyphManager.isEnabled)
				{
					return null;
				}
				return BnEIpurvhEIOkrsbuiNsEmMhmInC.ZLkWmYJqvhbNECBvzZwXJpCJJiGI;
			}
		}

		private string finalNegativeGlyphKey
		{
			get
			{
				if (!ReInput.isReady || BnEIpurvhEIOkrsbuiNsEmMhmInC == null || !GlyphManager.isEnabled)
				{
					return null;
				}
				return BnEIpurvhEIOkrsbuiNsEmMhmInC.ASoxlpBpoLaEQFSlgwmOUEYNbFFFA;
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
				if (ReInput.isReady && VNNITSVdTKmbXVJzYVhsRfjziPLV != null)
				{
					VNNITSVdTKmbXVJzYVhsRfjziPLV.XIvHPuMcrskwDDbqHcWqpyJRLTkr();
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
				if (ReInput.isReady && VNNITSVdTKmbXVJzYVhsRfjziPLV != null)
				{
					VNNITSVdTKmbXVJzYVhsRfjziPLV.mFMkdpduWHHeUgsHviuqmEEMyKNJ();
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
				if (ReInput.isReady && VNNITSVdTKmbXVJzYVhsRfjziPLV != null)
				{
					VNNITSVdTKmbXVJzYVhsRfjziPLV.BIVTdIpnFUBwhhnXrMOryHDWffqBA();
				}
			}
		}

		public string key => _key;

		public string positiveKey => _positiveKey;

		public string negativeKey => _negativeKey;

		string IControllerElementIdentifierCommon_Internal.nonLocalizedName => nonLocalizedName;

		string IControllerElementIdentifierCommon_Internal.nonLocalizedPositiveName => nonLocalizedPositiveName;

		string IControllerElementIdentifierCommon_Internal.nonLocalizedNegativeName => nonLocalizedNegativeName;

		bool IControllerElementIdentifierCommon_Internal.isNonLocalizedPositiveNameAutoGenerated => (oWEEMWpcqnGRTzZWzGwcYtFgsrpF & 2) != 0;

		bool IControllerElementIdentifierCommon_Internal.isNonLocalizedNegativeNameAutoGenerated => (oWEEMWpcqnGRTzZWzGwcYtFgsrpF & 4) != 0;

		bool IControllerElementIdentifierCommon_Internal.isPositiveKeyAutoGenerated => (oWEEMWpcqnGRTzZWzGwcYtFgsrpF & 8) != 0;

		bool IControllerElementIdentifierCommon_Internal.isNegativeKeyAutoGenerated => (oWEEMWpcqnGRTzZWzGwcYtFgsrpF & 0x10) != 0;

		string IControllerElementIdentifierCommon_Internal.key => _key;

		string IControllerElementIdentifierCommon_Internal.positiveKey => _positiveKey;

		string IControllerElementIdentifierCommon_Internal.negativeKey => _negativeKey;

		DeviceLocalizationInfo IControllerElementIdentifierCommon_Internal.deviceLocalizationInfo => fysLvTCASeokfhmUWXOldYiKJvxM;

		object IControllerElementIdentifierCommon_Internal.elementType => _elementType;

		bool IControllerElementIdentifierCommon_Internal.useEditorElementTypeOverride => useEditorElementTypeOverride;

		ControllerElementType IControllerElementIdentifierCommon_Internal.editorElementTypeOverride => editorElementTypeOverride;

		string sZLAxvZSvDRmVjMjTVRhHfujppQp.keyCategory => "controller/template";

		string sZLAxvZSvDRmVjMjTVRhHfujppQp.scriptingName => _name;

		string sZLAxvZSvDRmVjMjTVRhHfujppQp.nonLocalizedDescriptiveName
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

		string qlShIqeuHSIRhnLpCXWfkIdpMdpx.nonLocalizedPositiveDescriptiveName
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

		string qlShIqeuHSIRhnLpCXWfkIdpMdpx.nonLocalizedNegativeDescriptiveName
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
				return oWEEMWpcqnGRTzZWzGwcYtFgsrpF;
			}
			set
			{
				oWEEMWpcqnGRTzZWzGwcYtFgsrpF = value;
			}
		}

		string IkNokIafnDXAZobQNzBQDEduXYfJ.keyCategory => "controller/template";

		string IkNokIafnDXAZobQNzBQDEduXYfJ.key => _key;

		int IkNokIafnDXAZobQNzBQDEduXYfJ.autoGeneratedValueFlags
		{
			get
			{
				return oWEEMWpcqnGRTzZWzGwcYtFgsrpF;
			}
			set
			{
				oWEEMWpcqnGRTzZWzGwcYtFgsrpF = value;
			}
		}

		string ciioobTlGUakXNuXSZWsSBbYJisy.positiveKey
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

		string ciioobTlGUakXNuXSZWsSBbYJisy.negativeKey
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
			if (!ReInput.isReady || !LocalizationManager.isEnabled || JrqLfSEKVPgcuWmVWYyXoiwCHVLW == null || LQRmnoKCqKCvfLkFIEToGjdiwoPnA == null)
			{
				return string.Empty;
			}
			return LQRmnoKCqKCvfLkFIEToGjdiwoPnA.XtKWPvibVeeipuzfMWsFFvSriMHH(index);
		}

		internal object GetCompoundElementSpecialGlyph(int index)
		{
			if (!ReInput.isReady || !GlyphManager.isEnabled || JrqLfSEKVPgcuWmVWYyXoiwCHVLW == null || cJlKJDwHtjNlRdCjzaDQkibqBdIfA == null)
			{
				return null;
			}
			return cJlKJDwHtjNlRdCjzaDQkibqBdIfA.USpHQpJevJTvoQoGllRQnGXljnCA(index);
		}

		string IControllerElementIdentifierCommon_Internal.GetSpecialElementNonLocalizedName(int index)
		{
			if (JrqLfSEKVPgcuWmVWYyXoiwCHVLW == null || (uint)index >= (uint)JrqLfSEKVPgcuWmVWYyXoiwCHVLW.Count)
			{
				return null;
			}
			return JrqLfSEKVPgcuWmVWYyXoiwCHVLW[index].GNhWiNFmyujCBrKIvHIXPiRCCKjhA;
		}

		string IControllerElementIdentifierCommon_Internal.GetSpecialElementKey(int index)
		{
			if (JrqLfSEKVPgcuWmVWYyXoiwCHVLW == null || (uint)index >= (uint)JrqLfSEKVPgcuWmVWYyXoiwCHVLW.Count)
			{
				return null;
			}
			return JrqLfSEKVPgcuWmVWYyXoiwCHVLW[index].bGvzprjFDMbxkUmpUtQLkirTSguV;
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
			if (P_0.JrqLfSEKVPgcuWmVWYyXoiwCHVLW != null)
			{
				int count = P_0.JrqLfSEKVPgcuWmVWYyXoiwCHVLW.Count;
				JrqLfSEKVPgcuWmVWYyXoiwCHVLW = new List<ZUTDtJgbBClonxtsPzLEetdWMmwlA>(count);
				for (int i = 0; i < count; i++)
				{
					if (P_0.JrqLfSEKVPgcuWmVWYyXoiwCHVLW[i] != null)
					{
						JrqLfSEKVPgcuWmVWYyXoiwCHVLW.Add(new ZUTDtJgbBClonxtsPzLEetdWMmwlA(P_0.JrqLfSEKVPgcuWmVWYyXoiwCHVLW[i]));
					}
				}
			}
			oWEEMWpcqnGRTzZWzGwcYtFgsrpF = P_0.oWEEMWpcqnGRTzZWzGwcYtFgsrpF;
		}

		internal ControllerTemplateElementIdentifier(mVWcarxtJAcRlKTuiPXSObkcrwgnA P_0)
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
			ControllerElementIdentifier controllerElementIdentifier = new ControllerElementIdentifier(new ControllerElementIdentifier.mlDJkVjamumzDMNFFhJnSSbvSsLS
			{
				id = _id,
				name = _name,
				positiveName = _positiveName,
				negativeName = _negativeName,
				key = _key,
				positiveKey = _positiveKey,
				negativeKey = _negativeKey,
				elementType = bVcNkmaJvbHeBNQRpaleQvWHeXqv.ogZYejSWnbZCMRXcJqTBeoTKCOjm(_elementType),
				compoundElementType = CompoundControllerElementType.Axis2D
			});
			if (ReInput.isReady && fysLvTCASeokfhmUWXOldYiKJvxM != null && hardwareControllerMap != null)
			{
				DeviceLocalizationInfo deviceLocalizationInfo = new DeviceLocalizationInfo(hardwareControllerMap.controllerType, false, hardwareControllerMap.typeGuid, new List<string> { hardwareControllerMap.typeKey }, null);
				deviceLocalizationInfo.FinishRuntimeSetup();
				controllerElementIdentifier.FinishRuntimeSetup(deviceLocalizationInfo, hardwareControllerMap.controllerType);
			}
			return controllerElementIdentifier;
		}

		internal void FinishRuntimeSetup(DeviceLocalizationInfo deviceLocalizationInfo)
		{
			qWiYFWnMLLroOfsfWbeXzfrevMgp(_elementType, out var jZSMnsLXoBDMhquJQKqHviQNprmC, out var gtxbKiHSwksUKuQYeAEqHnCDMtFmA);
			int num = MJyJuisFiOmfspJhIRvXPkFSAPFT.WFlgMaYJJpzOhusNWIdstVGKtOzl(jZSMnsLXoBDMhquJQKqHviQNprmC, gtxbKiHSwksUKuQYeAEqHnCDMtFmA);
			if (num > 0)
			{
				JrqLfSEKVPgcuWmVWYyXoiwCHVLW = new List<ZUTDtJgbBClonxtsPzLEetdWMmwlA>(num);
				for (int i = 0; i < num; i++)
				{
					JrqLfSEKVPgcuWmVWYyXoiwCHVLW.Add(new ZUTDtJgbBClonxtsPzLEetdWMmwlA());
				}
			}
			fysLvTCASeokfhmUWXOldYiKJvxM = deviceLocalizationInfo;
			if (VNNITSVdTKmbXVJzYVhsRfjziPLV == null)
			{
				VNNITSVdTKmbXVJzYVhsRfjziPLV = qYSmXMgUajfmYTghAqPnrKCzyqDf.fsmwbyzVvQJKbrYbeYEbPTEuqaUf(this, flkMCmNLqqynNeuvLSYPGZFpwSqE.ControllerTemplate, jZSMnsLXoBDMhquJQKqHviQNprmC, gtxbKiHSwksUKuQYeAEqHnCDMtFmA, _id, deviceLocalizationInfo);
			}
			if (BnEIpurvhEIOkrsbuiNsEmMhmInC == null)
			{
				BnEIpurvhEIOkrsbuiNsEmMhmInC = DafCbHLEKvpEelZNWgaMmtlmrCuT.JghBafVdGVzKVupaDaDwFyFjPAzs(this, flkMCmNLqqynNeuvLSYPGZFpwSqE.ControllerTemplate, jZSMnsLXoBDMhquJQKqHviQNprmC, gtxbKiHSwksUKuQYeAEqHnCDMtFmA, _id, deviceLocalizationInfo);
			}
			if (jZSMnsLXoBDMhquJQKqHviQNprmC == MJyJuisFiOmfspJhIRvXPkFSAPFT.jZSMnsLXoBDMhquJQKqHviQNprmC.CompoundElement)
			{
				LQRmnoKCqKCvfLkFIEToGjdiwoPnA = BprIJnmtmyBKPDBukEEhRCfQaHNr.otUAoWIPJunSlEhxIChsObvSSWyN(this, flkMCmNLqqynNeuvLSYPGZFpwSqE.ControllerTemplate, jZSMnsLXoBDMhquJQKqHviQNprmC, gtxbKiHSwksUKuQYeAEqHnCDMtFmA, _id, deviceLocalizationInfo);
				cJlKJDwHtjNlRdCjzaDQkibqBdIfA = JkhcLwFHFFDyhsxVbdEcKlqoaKnsA.VnjEfSJHWaJaOGRXoIBBBAdkseOr(this, flkMCmNLqqynNeuvLSYPGZFpwSqE.ControllerTemplate, jZSMnsLXoBDMhquJQKqHviQNprmC, gtxbKiHSwksUKuQYeAEqHnCDMtFmA, _id, deviceLocalizationInfo);
			}
		}

		string orgqfgrCrmobGJnxqbGdAMXEeZnY.GetSpecialElementNonLocalizedDescriptiveName(int index)
		{
			if (JrqLfSEKVPgcuWmVWYyXoiwCHVLW == null || index >= JrqLfSEKVPgcuWmVWYyXoiwCHVLW.Count)
			{
				return null;
			}
			return JrqLfSEKVPgcuWmVWYyXoiwCHVLW[index].GNhWiNFmyujCBrKIvHIXPiRCCKjhA;
		}

		void orgqfgrCrmobGJnxqbGdAMXEeZnY.SetSpecialElementNonLocalizedDescriptiveName(int index, string value)
		{
			if (JrqLfSEKVPgcuWmVWYyXoiwCHVLW != null && index < JrqLfSEKVPgcuWmVWYyXoiwCHVLW.Count)
			{
				JrqLfSEKVPgcuWmVWYyXoiwCHVLW[index].GNhWiNFmyujCBrKIvHIXPiRCCKjhA = value;
			}
		}

		string orgqfgrCrmobGJnxqbGdAMXEeZnY.GetSpecialElementKey(int index)
		{
			if (JrqLfSEKVPgcuWmVWYyXoiwCHVLW == null || index >= JrqLfSEKVPgcuWmVWYyXoiwCHVLW.Count)
			{
				return null;
			}
			return JrqLfSEKVPgcuWmVWYyXoiwCHVLW[index].bGvzprjFDMbxkUmpUtQLkirTSguV;
		}

		void orgqfgrCrmobGJnxqbGdAMXEeZnY.SetSpecialElementKey(int index, string value)
		{
			if (JrqLfSEKVPgcuWmVWYyXoiwCHVLW != null && index < JrqLfSEKVPgcuWmVWYyXoiwCHVLW.Count)
			{
				JrqLfSEKVPgcuWmVWYyXoiwCHVLW[index].bGvzprjFDMbxkUmpUtQLkirTSguV = value;
			}
		}

		string ljpLhlKaijVdgLAKEnJGvqHultLG.GetSpecialElementKey(int index)
		{
			if (JrqLfSEKVPgcuWmVWYyXoiwCHVLW == null || index >= JrqLfSEKVPgcuWmVWYyXoiwCHVLW.Count)
			{
				return null;
			}
			return JrqLfSEKVPgcuWmVWYyXoiwCHVLW[index].bGvzprjFDMbxkUmpUtQLkirTSguV;
		}

		void ljpLhlKaijVdgLAKEnJGvqHultLG.SetSpecialElementKey(int index, string value)
		{
			if (JrqLfSEKVPgcuWmVWYyXoiwCHVLW != null && index < JrqLfSEKVPgcuWmVWYyXoiwCHVLW.Count)
			{
				JrqLfSEKVPgcuWmVWYyXoiwCHVLW[index].bGvzprjFDMbxkUmpUtQLkirTSguV = value;
			}
		}

		private static void qWiYFWnMLLroOfsfWbeXzfrevMgp(ControllerTemplateElementType P_0, out MJyJuisFiOmfspJhIRvXPkFSAPFT.jZSMnsLXoBDMhquJQKqHviQNprmC P_1, out MJyJuisFiOmfspJhIRvXPkFSAPFT.GtxbKiHSwksUKuQYeAEqHnCDMtFmA P_2)
		{
			P_2 = MJyJuisFiOmfspJhIRvXPkFSAPFT.GtxbKiHSwksUKuQYeAEqHnCDMtFmA.None;
			switch (P_0)
			{
			case ControllerTemplateElementType.Axis:
				P_1 = MJyJuisFiOmfspJhIRvXPkFSAPFT.jZSMnsLXoBDMhquJQKqHviQNprmC.Axis;
				break;
			case ControllerTemplateElementType.Button:
				P_1 = MJyJuisFiOmfspJhIRvXPkFSAPFT.jZSMnsLXoBDMhquJQKqHviQNprmC.Button;
				break;
			case ControllerTemplateElementType.Hat:
				P_1 = MJyJuisFiOmfspJhIRvXPkFSAPFT.jZSMnsLXoBDMhquJQKqHviQNprmC.CompoundElement;
				P_2 = MJyJuisFiOmfspJhIRvXPkFSAPFT.GtxbKiHSwksUKuQYeAEqHnCDMtFmA.Hat;
				break;
			case ControllerTemplateElementType.DPad:
				P_1 = MJyJuisFiOmfspJhIRvXPkFSAPFT.jZSMnsLXoBDMhquJQKqHviQNprmC.CompoundElement;
				P_2 = MJyJuisFiOmfspJhIRvXPkFSAPFT.GtxbKiHSwksUKuQYeAEqHnCDMtFmA.DPad;
				break;
			case ControllerTemplateElementType.ThumbStick:
				P_1 = MJyJuisFiOmfspJhIRvXPkFSAPFT.jZSMnsLXoBDMhquJQKqHviQNprmC.CompoundElement;
				break;
			case ControllerTemplateElementType.Yoke:
				P_1 = MJyJuisFiOmfspJhIRvXPkFSAPFT.jZSMnsLXoBDMhquJQKqHviQNprmC.Unknown;
				break;
			case ControllerTemplateElementType.Throttle:
				P_1 = MJyJuisFiOmfspJhIRvXPkFSAPFT.jZSMnsLXoBDMhquJQKqHviQNprmC.Unknown;
				break;
			case ControllerTemplateElementType.Stick:
				P_1 = MJyJuisFiOmfspJhIRvXPkFSAPFT.jZSMnsLXoBDMhquJQKqHviQNprmC.CompoundElement;
				P_2 = MJyJuisFiOmfspJhIRvXPkFSAPFT.GtxbKiHSwksUKuQYeAEqHnCDMtFmA.Stick;
				break;
			case ControllerTemplateElementType.Stick6D:
				P_1 = MJyJuisFiOmfspJhIRvXPkFSAPFT.jZSMnsLXoBDMhquJQKqHviQNprmC.CompoundElement;
				P_2 = MJyJuisFiOmfspJhIRvXPkFSAPFT.GtxbKiHSwksUKuQYeAEqHnCDMtFmA.Stick6D;
				break;
			default:
				P_1 = MJyJuisFiOmfspJhIRvXPkFSAPFT.jZSMnsLXoBDMhquJQKqHviQNprmC.Unknown;
				break;
			}
		}
	}
}
