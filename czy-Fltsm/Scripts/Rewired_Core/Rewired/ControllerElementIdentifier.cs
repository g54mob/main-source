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
	public sealed class ControllerElementIdentifier : IControllerElementIdentifierCommon_Internal, qlShIqeuHSIRhnLpCXWfkIdpMdpx, sZLAxvZSvDRmVjMjTVRhHfujppQp, ciioobTlGUakXNuXSZWsSBbYJisy, IkNokIafnDXAZobQNzBQDEduXYfJ, orgqfgrCrmobGJnxqbGdAMXEeZnY, ljpLhlKaijVdgLAKEnJGvqHultLG
	{
		[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
		internal class mlDJkVjamumzDMNFFhJnSSbvSsLS
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

			public string role;
		}

		internal sealed class bynVTTSgSxOQdaApptfwfVMhuAVq
		{
			[Serializable]
			private sealed class rxuRaBmMecEnQcmzoyEJDiAUnUzeb
			{
				public static readonly rxuRaBmMecEnQcmzoyEJDiAUnUzeb _003C_003E9 = new rxuRaBmMecEnQcmzoyEJDiAUnUzeb();

				public static Func<ControllerElementIdentifier, ControllerElementIdentifier, bool> _003C_003E9__4_0;

				internal bool KmQzfPdTEGWFXsnyAkzzwYqpfewr(ControllerElementIdentifier P_0, ControllerElementIdentifier P_1)
				{
					if (P_0 == null || P_1 == null)
					{
						return false;
					}
					if (P_0 != null && P_1 != null && P_0.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid == P_1.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid && P_0.elementType == P_1.elementType && P_0.compoundElementType == P_1.compoundElementType)
					{
						return string.Equals(P_0.key, P_1.key, StringComparison.Ordinal);
					}
					return false;
				}
			}

			private static bynVTTSgSxOQdaApptfwfVMhuAVq CtBNVciASNlwjSRuAltrSdKnmYie;

			private readonly global::QTCiASUCDvHtbdUBoOAdSPzWjRqL<ControllerElementIdentifier> iXqYrHEvMnAISZKKFkHLrMPqHIVs;

			private static bynVTTSgSxOQdaApptfwfVMhuAVq FHRTuDziVCBvpeACUTcCVqOlZKIOA
			{
				get
				{
					if (CtBNVciASNlwjSRuAltrSdKnmYie != null)
					{
						return CtBNVciASNlwjSRuAltrSdKnmYie;
					}
					CtBNVciASNlwjSRuAltrSdKnmYie = new bynVTTSgSxOQdaApptfwfVMhuAVq();
					CtBNVciASNlwjSRuAltrSdKnmYie.hEJxwviTegzXsuWXQsXZouGJFgvc();
					return CtBNVciASNlwjSRuAltrSdKnmYie;
				}
			}

			private bynVTTSgSxOQdaApptfwfVMhuAVq()
			{
				iXqYrHEvMnAISZKKFkHLrMPqHIVs = new global::QTCiASUCDvHtbdUBoOAdSPzWjRqL<ControllerElementIdentifier>(rxuRaBmMecEnQcmzoyEJDiAUnUzeb._003C_003E9.KmQzfPdTEGWFXsnyAkzzwYqpfewr);
			}

			private void hEJxwviTegzXsuWXQsXZouGJFgvc()
			{
				ReInput.ShutDownEvent += CtBNVciASNlwjSRuAltrSdKnmYie.SHthayFQHKYVxECmVCyjDLZebrDgb;
			}

			private void SHthayFQHKYVxECmVCyjDLZebrDgb()
			{
				if (CtBNVciASNlwjSRuAltrSdKnmYie == this)
				{
					CtBNVciASNlwjSRuAltrSdKnmYie = null;
				}
				ReInput.ShutDownEvent -= SHthayFQHKYVxECmVCyjDLZebrDgb;
			}

			public static ControllerElementIdentifier jqSLGimsNQdPEXLudaDAHulpVttaA(DeviceLocalizationInfo P_0, ControllerElementIdentifier P_1)
			{
				return FHRTuDziVCBvpeACUTcCVqOlZKIOA.iXqYrHEvMnAISZKKFkHLrMPqHIVs.jmbCpDDBCpCHqKMftVWBFAAjqwiI(P_0.hash, P_1);
			}

			public static bool TXsaGGEzAKsMMOmllodYZbvsmJDL(DeviceLocalizationInfo P_0, ControllerElementIdentifier P_1, out ControllerElementIdentifier P_2)
			{
				return FHRTuDziVCBvpeACUTcCVqOlZKIOA.iXqYrHEvMnAISZKKFkHLrMPqHIVs.XeiOWkonFmtJDikoHyyLMWSuTCbj(P_0.hash, P_1, out P_2);
			}

			public static void RdYPLYahvLQFjXWsakzmTmhbvMfu(DeviceLocalizationInfo P_0, ControllerElementIdentifier P_1)
			{
				FHRTuDziVCBvpeACUTcCVqOlZKIOA.iXqYrHEvMnAISZKKFkHLrMPqHIVs.oKikmsntPJTPfJPjjdAXQftayNjT(P_0.hash, P_1);
			}
		}

		private class jXNoRweQcqejnkiMCOxwACrfeZEPb
		{
			[SerializeField]
			private string NZgLpcLlJtBzpibkIQxbloGgNtYMA;

			[SerializeField]
			private string NWkYPViiaDphnANfMMYuRZynjnTl;

			public string KoWcYxDxpEcYlLGcmeFyDJtPxfnS
			{
				get
				{
					return NZgLpcLlJtBzpibkIQxbloGgNtYMA;
				}
				set
				{
					NZgLpcLlJtBzpibkIQxbloGgNtYMA = nZgLpcLlJtBzpibkIQxbloGgNtYMA;
				}
			}

			public string UxCEkkRumeCsZHfGEZRxeIicVZZdA
			{
				get
				{
					return NWkYPViiaDphnANfMMYuRZynjnTl;
				}
				set
				{
					NWkYPViiaDphnANfMMYuRZynjnTl = nWkYPViiaDphnANfMMYuRZynjnTl;
				}
			}

			public jXNoRweQcqejnkiMCOxwACrfeZEPb()
			{
			}

			public jXNoRweQcqejnkiMCOxwACrfeZEPb(jXNoRweQcqejnkiMCOxwACrfeZEPb P_0)
			{
				NZgLpcLlJtBzpibkIQxbloGgNtYMA = P_0.NZgLpcLlJtBzpibkIQxbloGgNtYMA;
				NWkYPViiaDphnANfMMYuRZynjnTl = P_0.NWkYPViiaDphnANfMMYuRZynjnTl;
			}
		}

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
		private string _key;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string _positiveKey;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string _negativeKey;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private ControllerElementType _elementType;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private CompoundControllerElementType _compoundElementType;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string _role;

		[NonSerialized]
		private bool ZXgcVoAkzIXengqMhdOccGQgautDc;

		[NonSerialized]
		private qYSmXMgUajfmYTghAqPnrKCzyqDf DdwayWFTKlbPEBdTcEyfndHiINuq;

		[NonSerialized]
		private BprIJnmtmyBKPDBukEEhRCfQaHNr TVGnfNfFdlDrbTZmcLNPrRBTNRPL;

		[NonSerialized]
		private DafCbHLEKvpEelZNWgaMmtlmrCuT GkUlcNvqoCrVdZfuJwfbTgRWapiP;

		[NonSerialized]
		private JkhcLwFHFFDyhsxVbdEcKlqoaKnsA vAFxaJgCfyeWBqawJDLvICKqAjmYA;

		[NonSerialized]
		private DeviceLocalizationInfo eHiUHMiqtInNRibQRHhwXVRygnYD;

		[NonSerialized]
		private int ZzxoIPbdmMkyYydsGtfGwlOFgzIT;

		[NonSerialized]
		private List<jXNoRweQcqejnkiMCOxwACrfeZEPb> YvFWDoUSikQHVvSwenKScPTNfZpR;

		[NonSerialized]
		private ControllerType jLbkkoYVieeoSSMOkjcyIYcMbusDb;

		private static ControllerElementIdentifier maebbtaKbaAAXxtJblhSbEoydYos;

		int IControllerElementIdentifierCommon_Internal.id => _id;

		string IControllerElementIdentifierCommon_Internal.name
		{
			get
			{
				if (!ReInput.isReady || DdwayWFTKlbPEBdTcEyfndHiINuq == null || !LocalizationManager.isEnabled)
				{
					return _name;
				}
				return DdwayWFTKlbPEBdTcEyfndHiINuq.HKQoqutKkgeGtFcRmtcKMQqgsDoY;
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
				if (!ReInput.isReady || DdwayWFTKlbPEBdTcEyfndHiINuq == null || !LocalizationManager.isEnabled)
				{
					return _positiveName;
				}
				return DdwayWFTKlbPEBdTcEyfndHiINuq.vqTJyxMIVweNIWENvOzgHIrQkYCw;
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
				if (!ReInput.isReady || DdwayWFTKlbPEBdTcEyfndHiINuq == null || !LocalizationManager.isEnabled)
				{
					return _negativeName;
				}
				return DdwayWFTKlbPEBdTcEyfndHiINuq.FktASepfaNwtFksADsQexzwgRpBn;
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
				if (!ReInput.isReady || GkUlcNvqoCrVdZfuJwfbTgRWapiP == null || !GlyphManager.isEnabled)
				{
					return null;
				}
				return GkUlcNvqoCrVdZfuJwfbTgRWapiP.ITvJcTdLSwZWFxvxmcUsUPCUdqCh;
			}
		}

		public object positiveGlyph
		{
			get
			{
				if (!ReInput.isReady || GkUlcNvqoCrVdZfuJwfbTgRWapiP == null || !GlyphManager.isEnabled)
				{
					return null;
				}
				return GkUlcNvqoCrVdZfuJwfbTgRWapiP.jrBblZZCqzRkAPiflzkvfOhTIunO;
			}
		}

		public object negativeGlyph
		{
			get
			{
				if (!ReInput.isReady || GkUlcNvqoCrVdZfuJwfbTgRWapiP == null || !GlyphManager.isEnabled)
				{
					return null;
				}
				return GkUlcNvqoCrVdZfuJwfbTgRWapiP.zHbAvTjlSJogNXAtyecrFQjbMiIWA;
			}
		}

		private string finalGlyphKey
		{
			get
			{
				if (!ReInput.isReady || GkUlcNvqoCrVdZfuJwfbTgRWapiP == null || !GlyphManager.isEnabled)
				{
					return null;
				}
				return GkUlcNvqoCrVdZfuJwfbTgRWapiP.BDdjaOSiBsDOcTLxjYvPPGeVYraO;
			}
		}

		private string finalPositiveGlyphKey
		{
			get
			{
				if (!ReInput.isReady || GkUlcNvqoCrVdZfuJwfbTgRWapiP == null || !GlyphManager.isEnabled)
				{
					return null;
				}
				return GkUlcNvqoCrVdZfuJwfbTgRWapiP.ZLkWmYJqvhbNECBvzZwXJpCJJiGI;
			}
		}

		private string finalNegativeGlyphKey
		{
			get
			{
				if (!ReInput.isReady || GkUlcNvqoCrVdZfuJwfbTgRWapiP == null || !GlyphManager.isEnabled)
				{
					return null;
				}
				return GkUlcNvqoCrVdZfuJwfbTgRWapiP.ASoxlpBpoLaEQFSlgwmOUEYNbFFFA;
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
					kryodnlnrLfKLeXjrmbkhVtjbVYB();
					if (DdwayWFTKlbPEBdTcEyfndHiINuq != null)
					{
						DdwayWFTKlbPEBdTcEyfndHiINuq.XIvHPuMcrskwDDbqHcWqpyJRLTkr();
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
					kryodnlnrLfKLeXjrmbkhVtjbVYB();
					if (DdwayWFTKlbPEBdTcEyfndHiINuq != null)
					{
						DdwayWFTKlbPEBdTcEyfndHiINuq.mFMkdpduWHHeUgsHviuqmEEMyKNJ();
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
					kryodnlnrLfKLeXjrmbkhVtjbVYB();
					if (DdwayWFTKlbPEBdTcEyfndHiINuq != null)
					{
						DdwayWFTKlbPEBdTcEyfndHiINuq.BIVTdIpnFUBwhhnXrMOryHDWffqBA();
					}
				}
			}
		}

		public string key => _key;

		public string positiveKey => _positiveKey;

		public string negativeKey => _negativeKey;

		public string role => _role;

		internal bool isCompoundElement => _elementType == ControllerElementType.CompoundElement;

		string IControllerElementIdentifierCommon_Internal.nonLocalizedName => nonLocalizedName;

		string IControllerElementIdentifierCommon_Internal.nonLocalizedPositiveName => nonLocalizedPositiveName;

		string IControllerElementIdentifierCommon_Internal.nonLocalizedNegativeName => nonLocalizedNegativeName;

		bool IControllerElementIdentifierCommon_Internal.isNonLocalizedPositiveNameAutoGenerated => (ZzxoIPbdmMkyYydsGtfGwlOFgzIT & 2) != 0;

		bool IControllerElementIdentifierCommon_Internal.isNonLocalizedNegativeNameAutoGenerated => (ZzxoIPbdmMkyYydsGtfGwlOFgzIT & 4) != 0;

		bool IControllerElementIdentifierCommon_Internal.isPositiveKeyAutoGenerated => (ZzxoIPbdmMkyYydsGtfGwlOFgzIT & 8) != 0;

		bool IControllerElementIdentifierCommon_Internal.isNegativeKeyAutoGenerated => (ZzxoIPbdmMkyYydsGtfGwlOFgzIT & 0x10) != 0;

		string IControllerElementIdentifierCommon_Internal.key => _key;

		string IControllerElementIdentifierCommon_Internal.positiveKey => _positiveKey;

		string IControllerElementIdentifierCommon_Internal.negativeKey => _negativeKey;

		DeviceLocalizationInfo IControllerElementIdentifierCommon_Internal.deviceLocalizationInfo => eHiUHMiqtInNRibQRHhwXVRygnYD;

		object IControllerElementIdentifierCommon_Internal.elementType => _elementType;

		bool IControllerElementIdentifierCommon_Internal.useEditorElementTypeOverride => false;

		ControllerElementType IControllerElementIdentifierCommon_Internal.editorElementTypeOverride => _elementType;

		internal static ControllerElementIdentifier BlankReadOnly
		{
			get
			{
				if (maebbtaKbaAAXxtJblhSbEoydYos == null)
				{
					ControllerElementIdentifier result = new ControllerElementIdentifier
					{
						_id = -1,
						ZXgcVoAkzIXengqMhdOccGQgautDc = true
					};
					maebbtaKbaAAXxtJblhSbEoydYos = result;
					return result;
				}
				return maebbtaKbaAAXxtJblhSbEoydYos;
			}
		}

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
				kryodnlnrLfKLeXjrmbkhVtjbVYB();
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
				kryodnlnrLfKLeXjrmbkhVtjbVYB();
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
				kryodnlnrLfKLeXjrmbkhVtjbVYB();
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
				kryodnlnrLfKLeXjrmbkhVtjbVYB();
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
				kryodnlnrLfKLeXjrmbkhVtjbVYB();
				_negativeKey = value;
			}
		}

		int sZLAxvZSvDRmVjMjTVRhHfujppQp.autoGeneratedValueFlags
		{
			get
			{
				return ZzxoIPbdmMkyYydsGtfGwlOFgzIT;
			}
			set
			{
				ZzxoIPbdmMkyYydsGtfGwlOFgzIT = value;
			}
		}

		string IkNokIafnDXAZobQNzBQDEduXYfJ.keyCategory => kgoenjfnufElmhiZmbMkzRwPiuvy.MiVAqWFimDZLnAOHmPIGgAKiNsPBb(jLbkkoYVieeoSSMOkjcyIYcMbusDb);

		string IkNokIafnDXAZobQNzBQDEduXYfJ.key => _key;

		int IkNokIafnDXAZobQNzBQDEduXYfJ.autoGeneratedValueFlags
		{
			get
			{
				return ZzxoIPbdmMkyYydsGtfGwlOFgzIT;
			}
			set
			{
				ZzxoIPbdmMkyYydsGtfGwlOFgzIT = value;
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
				kryodnlnrLfKLeXjrmbkhVtjbVYB();
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
				kryodnlnrLfKLeXjrmbkhVtjbVYB();
				_negativeKey = value;
			}
		}

		internal string GetCompoundElementSpecialName(int index)
		{
			if (!ReInput.isReady || !LocalizationManager.isEnabled || YvFWDoUSikQHVvSwenKScPTNfZpR == null || TVGnfNfFdlDrbTZmcLNPrRBTNRPL == null)
			{
				return string.Empty;
			}
			return TVGnfNfFdlDrbTZmcLNPrRBTNRPL.XtKWPvibVeeipuzfMWsFFvSriMHH(index);
		}

		internal object GetCompoundElementSpecialGlyph(int index)
		{
			if (!ReInput.isReady || !GlyphManager.isEnabled || YvFWDoUSikQHVvSwenKScPTNfZpR == null || vAFxaJgCfyeWBqawJDLvICKqAjmYA == null)
			{
				return null;
			}
			return vAFxaJgCfyeWBqawJDLvICKqAjmYA.USpHQpJevJTvoQoGllRQnGXljnCA(index);
		}

		internal string GetCompoundElementSpecialFinalGlyphKey(int index)
		{
			if (!ReInput.isReady || !GlyphManager.isEnabled || YvFWDoUSikQHVvSwenKScPTNfZpR == null || vAFxaJgCfyeWBqawJDLvICKqAjmYA == null)
			{
				return null;
			}
			return vAFxaJgCfyeWBqawJDLvICKqAjmYA.GflJQkxSEFvgtMzAOHUirFNnIciZ(index);
		}

		string IControllerElementIdentifierCommon_Internal.GetSpecialElementNonLocalizedName(int index)
		{
			if (YvFWDoUSikQHVvSwenKScPTNfZpR == null || (uint)index >= (uint)YvFWDoUSikQHVvSwenKScPTNfZpR.Count)
			{
				return null;
			}
			return YvFWDoUSikQHVvSwenKScPTNfZpR[index].UxCEkkRumeCsZHfGEZRxeIicVZZdA;
		}

		string IControllerElementIdentifierCommon_Internal.GetSpecialElementKey(int index)
		{
			if (YvFWDoUSikQHVvSwenKScPTNfZpR == null || (uint)index >= (uint)YvFWDoUSikQHVvSwenKScPTNfZpR.Count)
			{
				return null;
			}
			return YvFWDoUSikQHVvSwenKScPTNfZpR[index].KoWcYxDxpEcYlLGcmeFyDJtPxfnS;
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
			_role = P_0._role;
			if (P_0.YvFWDoUSikQHVvSwenKScPTNfZpR != null)
			{
				int count = P_0.YvFWDoUSikQHVvSwenKScPTNfZpR.Count;
				YvFWDoUSikQHVvSwenKScPTNfZpR = new List<jXNoRweQcqejnkiMCOxwACrfeZEPb>(count);
				for (int i = 0; i < count; i++)
				{
					if (P_0.YvFWDoUSikQHVvSwenKScPTNfZpR[i] != null)
					{
						YvFWDoUSikQHVvSwenKScPTNfZpR.Add(new jXNoRweQcqejnkiMCOxwACrfeZEPb(P_0.YvFWDoUSikQHVvSwenKScPTNfZpR[i]));
					}
				}
			}
			ZzxoIPbdmMkyYydsGtfGwlOFgzIT = P_0.ZzxoIPbdmMkyYydsGtfGwlOFgzIT;
			jLbkkoYVieeoSSMOkjcyIYcMbusDb = P_0.jLbkkoYVieeoSSMOkjcyIYcMbusDb;
		}

		internal ControllerElementIdentifier(mlDJkVjamumzDMNFFhJnSSbvSsLS P_0)
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
			_role = P_0.role;
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
			return actualElementType switch
			{
				ControllerElementType.Axis => axisRange switch
				{
					AxisRange.Full => ((IControllerElementIdentifierCommon_Internal)this).name, 
					AxisRange.Positive => ((IControllerElementIdentifierCommon_Internal)this).positiveName, 
					AxisRange.Negative => ((IControllerElementIdentifierCommon_Internal)this).negativeName, 
					_ => throw new NotImplementedException(), 
				}, 
				ControllerElementType.Button => ((IControllerElementIdentifierCommon_Internal)this).name, 
				ControllerElementType.CompoundElement => ((IControllerElementIdentifierCommon_Internal)this).name, 
				_ => throw new NotImplementedException(), 
			};
		}

		public string GetDisplayName(AxisRange axisRange)
		{
			return GetDisplayName(_elementType, axisRange);
		}

		public object GetGlyph(ControllerElementType actualElementType, AxisRange axisRange)
		{
			return actualElementType switch
			{
				ControllerElementType.Axis => axisRange switch
				{
					AxisRange.Full => glyph, 
					AxisRange.Positive => positiveGlyph, 
					AxisRange.Negative => negativeGlyph, 
					_ => throw new NotImplementedException(), 
				}, 
				ControllerElementType.Button => glyph, 
				ControllerElementType.CompoundElement => glyph, 
				_ => throw new NotImplementedException(), 
			};
		}

		public object GetGlyph(AxisRange axisRange)
		{
			return GetGlyph(_elementType, axisRange);
		}

		public string GetFinalGlyphKey(ControllerElementType actualElementType, AxisRange axisRange)
		{
			return actualElementType switch
			{
				ControllerElementType.Axis => axisRange switch
				{
					AxisRange.Full => finalGlyphKey, 
					AxisRange.Positive => finalPositiveGlyphKey, 
					AxisRange.Negative => finalNegativeGlyphKey, 
					_ => throw new NotImplementedException(), 
				}, 
				ControllerElementType.Button => finalGlyphKey, 
				ControllerElementType.CompoundElement => finalGlyphKey, 
				_ => throw new NotImplementedException(), 
			};
		}

		public string GetFinalGlyphKey(AxisRange axisRange)
		{
			return GetFinalGlyphKey(_elementType, axisRange);
		}

		private void kryodnlnrLfKLeXjrmbkhVtjbVYB()
		{
			if (ZXgcVoAkzIXengqMhdOccGQgautDc)
			{
				throw new Exception("The object is marked readonly and you are trying to modify its values.");
			}
		}

		internal void FinishRuntimeSetup(DeviceLocalizationInfo deviceLocalizationInfo, ControllerType controllerType)
		{
			jLbkkoYVieeoSSMOkjcyIYcMbusDb = controllerType;
			ToElementNameLocalizerTypes(_elementType, _compoundElementType, out var resultElementType, out var resultCompoundElementType);
			int num = MJyJuisFiOmfspJhIRvXPkFSAPFT.WFlgMaYJJpzOhusNWIdstVGKtOzl(resultElementType, resultCompoundElementType);
			if (num > 0)
			{
				YvFWDoUSikQHVvSwenKScPTNfZpR = new List<jXNoRweQcqejnkiMCOxwACrfeZEPb>(num);
				for (int i = 0; i < num; i++)
				{
					YvFWDoUSikQHVvSwenKScPTNfZpR.Add(new jXNoRweQcqejnkiMCOxwACrfeZEPb());
				}
			}
			eHiUHMiqtInNRibQRHhwXVRygnYD = deviceLocalizationInfo;
			DdwayWFTKlbPEBdTcEyfndHiINuq = qYSmXMgUajfmYTghAqPnrKCzyqDf.fsmwbyzVvQJKbrYbeYEbPTEuqaUf(this, rmdgdLCvSmiZKUTxFZTIrYFIDSFMA.RecBeCfyOKFHAGfBnLBerzonomtqA(controllerType), resultElementType, resultCompoundElementType, _id, deviceLocalizationInfo);
			GkUlcNvqoCrVdZfuJwfbTgRWapiP = DafCbHLEKvpEelZNWgaMmtlmrCuT.JghBafVdGVzKVupaDaDwFyFjPAzs(this, rmdgdLCvSmiZKUTxFZTIrYFIDSFMA.RecBeCfyOKFHAGfBnLBerzonomtqA(controllerType), resultElementType, resultCompoundElementType, _id, deviceLocalizationInfo);
			if (_elementType == ControllerElementType.CompoundElement)
			{
				TVGnfNfFdlDrbTZmcLNPrRBTNRPL = BprIJnmtmyBKPDBukEEhRCfQaHNr.otUAoWIPJunSlEhxIChsObvSSWyN(this, rmdgdLCvSmiZKUTxFZTIrYFIDSFMA.RecBeCfyOKFHAGfBnLBerzonomtqA(controllerType), resultElementType, resultCompoundElementType, _id, deviceLocalizationInfo);
				vAFxaJgCfyeWBqawJDLvICKqAjmYA = JkhcLwFHFFDyhsxVbdEcKlqoaKnsA.VnjEfSJHWaJaOGRXoIBBBAdkseOr(this, rmdgdLCvSmiZKUTxFZTIrYFIDSFMA.RecBeCfyOKFHAGfBnLBerzonomtqA(controllerType), resultElementType, resultCompoundElementType, _id, deviceLocalizationInfo);
			}
		}

		internal static void ToElementNameLocalizerTypes(ControllerElementType type, CompoundControllerElementType compoundType, out MJyJuisFiOmfspJhIRvXPkFSAPFT.jZSMnsLXoBDMhquJQKqHviQNprmC resultElementType, out MJyJuisFiOmfspJhIRvXPkFSAPFT.GtxbKiHSwksUKuQYeAEqHnCDMtFmA resultCompoundElementType)
		{
			resultCompoundElementType = MJyJuisFiOmfspJhIRvXPkFSAPFT.GtxbKiHSwksUKuQYeAEqHnCDMtFmA.None;
			switch (type)
			{
			case ControllerElementType.Axis:
				resultElementType = MJyJuisFiOmfspJhIRvXPkFSAPFT.jZSMnsLXoBDMhquJQKqHviQNprmC.Axis;
				break;
			case ControllerElementType.Button:
				resultElementType = MJyJuisFiOmfspJhIRvXPkFSAPFT.jZSMnsLXoBDMhquJQKqHviQNprmC.Button;
				break;
			case ControllerElementType.CompoundElement:
				resultElementType = MJyJuisFiOmfspJhIRvXPkFSAPFT.jZSMnsLXoBDMhquJQKqHviQNprmC.CompoundElement;
				switch (compoundType)
				{
				case CompoundControllerElementType.Axis2D:
					resultCompoundElementType = MJyJuisFiOmfspJhIRvXPkFSAPFT.GtxbKiHSwksUKuQYeAEqHnCDMtFmA.Axis2D;
					break;
				case CompoundControllerElementType.Hat:
					resultCompoundElementType = MJyJuisFiOmfspJhIRvXPkFSAPFT.GtxbKiHSwksUKuQYeAEqHnCDMtFmA.Hat;
					break;
				case CompoundControllerElementType.DPad:
					resultCompoundElementType = MJyJuisFiOmfspJhIRvXPkFSAPFT.GtxbKiHSwksUKuQYeAEqHnCDMtFmA.DPad;
					break;
				default:
					resultElementType = MJyJuisFiOmfspJhIRvXPkFSAPFT.jZSMnsLXoBDMhquJQKqHviQNprmC.Unknown;
					break;
				}
				break;
			default:
				resultElementType = MJyJuisFiOmfspJhIRvXPkFSAPFT.jZSMnsLXoBDMhquJQKqHviQNprmC.Unknown;
				break;
			}
		}

		string orgqfgrCrmobGJnxqbGdAMXEeZnY.GetSpecialElementNonLocalizedDescriptiveName(int index)
		{
			if (YvFWDoUSikQHVvSwenKScPTNfZpR == null || index >= YvFWDoUSikQHVvSwenKScPTNfZpR.Count)
			{
				return null;
			}
			return YvFWDoUSikQHVvSwenKScPTNfZpR[index].UxCEkkRumeCsZHfGEZRxeIicVZZdA;
		}

		void orgqfgrCrmobGJnxqbGdAMXEeZnY.SetSpecialElementNonLocalizedDescriptiveName(int index, string value)
		{
			if (YvFWDoUSikQHVvSwenKScPTNfZpR != null && index < YvFWDoUSikQHVvSwenKScPTNfZpR.Count)
			{
				YvFWDoUSikQHVvSwenKScPTNfZpR[index].UxCEkkRumeCsZHfGEZRxeIicVZZdA = value;
			}
		}

		string orgqfgrCrmobGJnxqbGdAMXEeZnY.GetSpecialElementKey(int index)
		{
			if (YvFWDoUSikQHVvSwenKScPTNfZpR == null || index >= YvFWDoUSikQHVvSwenKScPTNfZpR.Count)
			{
				return null;
			}
			return YvFWDoUSikQHVvSwenKScPTNfZpR[index].KoWcYxDxpEcYlLGcmeFyDJtPxfnS;
		}

		void orgqfgrCrmobGJnxqbGdAMXEeZnY.SetSpecialElementKey(int index, string value)
		{
			if (YvFWDoUSikQHVvSwenKScPTNfZpR != null && index < YvFWDoUSikQHVvSwenKScPTNfZpR.Count)
			{
				YvFWDoUSikQHVvSwenKScPTNfZpR[index].KoWcYxDxpEcYlLGcmeFyDJtPxfnS = value;
			}
		}

		string ljpLhlKaijVdgLAKEnJGvqHultLG.GetSpecialElementKey(int index)
		{
			if (YvFWDoUSikQHVvSwenKScPTNfZpR == null || index >= YvFWDoUSikQHVvSwenKScPTNfZpR.Count)
			{
				return null;
			}
			return YvFWDoUSikQHVvSwenKScPTNfZpR[index].KoWcYxDxpEcYlLGcmeFyDJtPxfnS;
		}

		void ljpLhlKaijVdgLAKEnJGvqHultLG.SetSpecialElementKey(int index, string value)
		{
			if (YvFWDoUSikQHVvSwenKScPTNfZpR != null && index < YvFWDoUSikQHVvSwenKScPTNfZpR.Count)
			{
				YvFWDoUSikQHVvSwenKScPTNfZpR[index].KoWcYxDxpEcYlLGcmeFyDJtPxfnS = value;
			}
		}
	}
}
