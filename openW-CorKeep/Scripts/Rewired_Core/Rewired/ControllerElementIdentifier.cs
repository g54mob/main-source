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
	public sealed class ControllerElementIdentifier : IControllerElementIdentifierCommon_Internal, mQQEUnWrvIENJEQHDjPIUvhAyczkA, gDrCmzJNXwFvGTMAYKGQspUqeYD, sLizqcvxoCawnuvvDbUZJbhvIfejA, AIHwxHYiZBEVvZOJUhghGWlTpYhGA, wOcwbdLCJaOhasRXtoPQFUPfsCvq, jhzHtawhGfHVCurgBdqnjuHNyiNIA
	{
		[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
		internal class ojVewQJXCyYjrtbbWsMKJotWctHeA
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

		internal sealed class zStnLKifidbOXaBFoPmPwuIUUBLbA
		{
			[Serializable]
			private sealed class jBaVgYAyEsutsFoJrcRwnSKvhDbU
			{
				public static readonly jBaVgYAyEsutsFoJrcRwnSKvhDbU _003C_003E9 = new jBaVgYAyEsutsFoJrcRwnSKvhDbU();

				public static Func<ControllerElementIdentifier, ControllerElementIdentifier, bool> _003C_003E9__4_0;

				internal bool QiAozKRTwEUDlXnCNAyYlOaWhdwS(ControllerElementIdentifier P_0, ControllerElementIdentifier P_1)
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

			private static zStnLKifidbOXaBFoPmPwuIUUBLbA SWVXidAsaVjtRdCrLioKFXpOzteH;

			private readonly global::CWEsnVafmhdWXWfXjHVMLtdvyjyd<ControllerElementIdentifier> sYaLtIshcnnYqaDgQWKguANPwHTt;

			private static zStnLKifidbOXaBFoPmPwuIUUBLbA ZeVPmCRJpIPjLvNkTInnhxGEnJKNA
			{
				get
				{
					if (SWVXidAsaVjtRdCrLioKFXpOzteH != null)
					{
						return SWVXidAsaVjtRdCrLioKFXpOzteH;
					}
					SWVXidAsaVjtRdCrLioKFXpOzteH = new zStnLKifidbOXaBFoPmPwuIUUBLbA();
					SWVXidAsaVjtRdCrLioKFXpOzteH.lgBducCOMwrwQRwuHjNyfybuMXcD();
					return SWVXidAsaVjtRdCrLioKFXpOzteH;
				}
			}

			private zStnLKifidbOXaBFoPmPwuIUUBLbA()
			{
				sYaLtIshcnnYqaDgQWKguANPwHTt = new global::CWEsnVafmhdWXWfXjHVMLtdvyjyd<ControllerElementIdentifier>(jBaVgYAyEsutsFoJrcRwnSKvhDbU._003C_003E9.QiAozKRTwEUDlXnCNAyYlOaWhdwS);
			}

			private void lgBducCOMwrwQRwuHjNyfybuMXcD()
			{
				ReInput.ShutDownEvent += SWVXidAsaVjtRdCrLioKFXpOzteH.AOrEevihfAIFJErWhWnAVKRJTiBqB;
			}

			private void AOrEevihfAIFJErWhWnAVKRJTiBqB()
			{
				if (SWVXidAsaVjtRdCrLioKFXpOzteH == this)
				{
					SWVXidAsaVjtRdCrLioKFXpOzteH = null;
				}
				ReInput.ShutDownEvent -= AOrEevihfAIFJErWhWnAVKRJTiBqB;
			}

			public static ControllerElementIdentifier pvIxYlIEtOpRuamUmoQvvHrKGqpY(DeviceLocalizationInfo P_0, ControllerElementIdentifier P_1)
			{
				return ZeVPmCRJpIPjLvNkTInnhxGEnJKNA.sYaLtIshcnnYqaDgQWKguANPwHTt.zIxKqErNejIXOzgHuQwaUJUUfHkH(P_0.hash, P_1);
			}

			public static bool LcuqTFgbPMssslxAydOjKFtVGxBM(DeviceLocalizationInfo P_0, ControllerElementIdentifier P_1, out ControllerElementIdentifier P_2)
			{
				return ZeVPmCRJpIPjLvNkTInnhxGEnJKNA.sYaLtIshcnnYqaDgQWKguANPwHTt.XFaGTtCzTwdlJVAzMnkTTCEPSjPB(P_0.hash, P_1, out P_2);
			}

			public static void XgMTTRMFBNFBZCsCnSkVgKfKAFfEB(DeviceLocalizationInfo P_0, ControllerElementIdentifier P_1)
			{
				ZeVPmCRJpIPjLvNkTInnhxGEnJKNA.sYaLtIshcnnYqaDgQWKguANPwHTt.gjcCongZfDTPVoqTsiJgeVhLREbdb(P_0.hash, P_1);
			}
		}

		private class rvJuRxKRGspvDJLaFVuFXmpZDEKV
		{
			[SerializeField]
			private string NxmzpdhMttpfLKuQVswSnfYFqyUn;

			[SerializeField]
			private string XXwKPUChWXAzNrKBFzZVSquUcxVk;

			public string CHIYqHtFcGYNYkIczCRpEdDqudMb
			{
				get
				{
					return NxmzpdhMttpfLKuQVswSnfYFqyUn;
				}
				set
				{
					NxmzpdhMttpfLKuQVswSnfYFqyUn = nxmzpdhMttpfLKuQVswSnfYFqyUn;
				}
			}

			public string GrYewptxYcDkbUwoPPWCHakZgWZBA
			{
				get
				{
					return XXwKPUChWXAzNrKBFzZVSquUcxVk;
				}
				set
				{
					XXwKPUChWXAzNrKBFzZVSquUcxVk = xXwKPUChWXAzNrKBFzZVSquUcxVk;
				}
			}

			public rvJuRxKRGspvDJLaFVuFXmpZDEKV()
			{
			}

			public rvJuRxKRGspvDJLaFVuFXmpZDEKV(rvJuRxKRGspvDJLaFVuFXmpZDEKV P_0)
			{
				NxmzpdhMttpfLKuQVswSnfYFqyUn = P_0.NxmzpdhMttpfLKuQVswSnfYFqyUn;
				XXwKPUChWXAzNrKBFzZVSquUcxVk = P_0.XXwKPUChWXAzNrKBFzZVSquUcxVk;
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
		private bool XZyGJbYgDMryDBfsahBXbLSDFblib;

		[NonSerialized]
		private mbAaHTOiYxhnyoaJRfjMoaCGrCBj ZfgalFhoNnvjyedtxfGIoNZLOvaH;

		[NonSerialized]
		private BLzCsuUSxuHNlyOBbPCMSbrlIPBG XxShNWTFXznMXcCDzCLmsJHyKFWc;

		[NonSerialized]
		private XbxYllaEvMCIEbzNlnHzhuJNebc OFOrLKVDGKjsVieSShJCWeLhamir;

		[NonSerialized]
		private FDrDdMdvbLiGNNnJmNMDaukLRJtd fcZjIKITIgEpxBMhCYwUFMsFyEyf;

		[NonSerialized]
		private DeviceLocalizationInfo oGcUULQeKKhrlPdVEuSBQNPPghKW;

		[NonSerialized]
		private int ZTtgHYVAkQcqcLUqRuvvtAEqeaQd;

		[NonSerialized]
		private List<rvJuRxKRGspvDJLaFVuFXmpZDEKV> MQPlFjwEEmFXviAMpiBpArJasKfOB;

		[NonSerialized]
		private ControllerType tKlCwlmtCqEowepcjsfTeNqfhnuLc;

		private static ControllerElementIdentifier aXmjekAjBcAxvIZhaqkfsbyJdXit;

		int IControllerElementIdentifierCommon_Internal.id => _id;

		string IControllerElementIdentifierCommon_Internal.name
		{
			get
			{
				if (!ReInput.isReady || ZfgalFhoNnvjyedtxfGIoNZLOvaH == null || !LocalizationManager.isEnabled)
				{
					return _name;
				}
				return ZfgalFhoNnvjyedtxfGIoNZLOvaH.LoGZqdROKyuYHJXdnhuxPciDQjeL;
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
				if (!ReInput.isReady || ZfgalFhoNnvjyedtxfGIoNZLOvaH == null || !LocalizationManager.isEnabled)
				{
					return _positiveName;
				}
				return ZfgalFhoNnvjyedtxfGIoNZLOvaH.zPNcigbiryaPgXbjyaoZNShrqVUfb;
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
				if (!ReInput.isReady || ZfgalFhoNnvjyedtxfGIoNZLOvaH == null || !LocalizationManager.isEnabled)
				{
					return _negativeName;
				}
				return ZfgalFhoNnvjyedtxfGIoNZLOvaH.RLbUDlHGeFvGjHacKFOBoouLwnJJ;
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
				if (!ReInput.isReady || OFOrLKVDGKjsVieSShJCWeLhamir == null || !GlyphManager.isEnabled)
				{
					return null;
				}
				return OFOrLKVDGKjsVieSShJCWeLhamir.GVrZzAJiAcZtdOTSfvBJJUYlefGD;
			}
		}

		public object positiveGlyph
		{
			get
			{
				if (!ReInput.isReady || OFOrLKVDGKjsVieSShJCWeLhamir == null || !GlyphManager.isEnabled)
				{
					return null;
				}
				return OFOrLKVDGKjsVieSShJCWeLhamir.rDFxUatMbooeegVqsbQAmfdclvkb;
			}
		}

		public object negativeGlyph
		{
			get
			{
				if (!ReInput.isReady || OFOrLKVDGKjsVieSShJCWeLhamir == null || !GlyphManager.isEnabled)
				{
					return null;
				}
				return OFOrLKVDGKjsVieSShJCWeLhamir.virtdIFyIFsRliRxpxDCRdeEbxUd;
			}
		}

		private string finalGlyphKey
		{
			get
			{
				if (!ReInput.isReady || OFOrLKVDGKjsVieSShJCWeLhamir == null || !GlyphManager.isEnabled)
				{
					return null;
				}
				return OFOrLKVDGKjsVieSShJCWeLhamir.BffrlRgrmyGwIkHNgqwsEclmiqed;
			}
		}

		private string finalPositiveGlyphKey
		{
			get
			{
				if (!ReInput.isReady || OFOrLKVDGKjsVieSShJCWeLhamir == null || !GlyphManager.isEnabled)
				{
					return null;
				}
				return OFOrLKVDGKjsVieSShJCWeLhamir.NomOvFfGNzjocpHXgQVkYuGuWtOf;
			}
		}

		private string finalNegativeGlyphKey
		{
			get
			{
				if (!ReInput.isReady || OFOrLKVDGKjsVieSShJCWeLhamir == null || !GlyphManager.isEnabled)
				{
					return null;
				}
				return OFOrLKVDGKjsVieSShJCWeLhamir.KNuOvihbENmAquPLvjhhiXUexGHEA;
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
					kQkaEkBIZDevuVutudzWiVFYcmPP();
					if (ZfgalFhoNnvjyedtxfGIoNZLOvaH != null)
					{
						ZfgalFhoNnvjyedtxfGIoNZLOvaH.TebLFfuNscsSdmSSCRmDmNccAdoF();
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
					kQkaEkBIZDevuVutudzWiVFYcmPP();
					if (ZfgalFhoNnvjyedtxfGIoNZLOvaH != null)
					{
						ZfgalFhoNnvjyedtxfGIoNZLOvaH.gCQsiuHHoDBgyTofsxyDxbEzjwLF();
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
					kQkaEkBIZDevuVutudzWiVFYcmPP();
					if (ZfgalFhoNnvjyedtxfGIoNZLOvaH != null)
					{
						ZfgalFhoNnvjyedtxfGIoNZLOvaH.VfXqdBFmbAriTEKxazHGnZJzQear();
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

		bool IControllerElementIdentifierCommon_Internal.isNonLocalizedPositiveNameAutoGenerated => (ZTtgHYVAkQcqcLUqRuvvtAEqeaQd & 2) != 0;

		bool IControllerElementIdentifierCommon_Internal.isNonLocalizedNegativeNameAutoGenerated => (ZTtgHYVAkQcqcLUqRuvvtAEqeaQd & 4) != 0;

		bool IControllerElementIdentifierCommon_Internal.isPositiveKeyAutoGenerated => (ZTtgHYVAkQcqcLUqRuvvtAEqeaQd & 8) != 0;

		bool IControllerElementIdentifierCommon_Internal.isNegativeKeyAutoGenerated => (ZTtgHYVAkQcqcLUqRuvvtAEqeaQd & 0x10) != 0;

		string IControllerElementIdentifierCommon_Internal.key => _key;

		string IControllerElementIdentifierCommon_Internal.positiveKey => _positiveKey;

		string IControllerElementIdentifierCommon_Internal.negativeKey => _negativeKey;

		DeviceLocalizationInfo IControllerElementIdentifierCommon_Internal.deviceLocalizationInfo => oGcUULQeKKhrlPdVEuSBQNPPghKW;

		object IControllerElementIdentifierCommon_Internal.elementType => _elementType;

		bool IControllerElementIdentifierCommon_Internal.useEditorElementTypeOverride => false;

		ControllerElementType IControllerElementIdentifierCommon_Internal.editorElementTypeOverride => _elementType;

		internal static ControllerElementIdentifier BlankReadOnly
		{
			get
			{
				if (aXmjekAjBcAxvIZhaqkfsbyJdXit == null)
				{
					ControllerElementIdentifier result = new ControllerElementIdentifier
					{
						_id = -1,
						XZyGJbYgDMryDBfsahBXbLSDFblib = true
					};
					aXmjekAjBcAxvIZhaqkfsbyJdXit = result;
					return result;
				}
				return aXmjekAjBcAxvIZhaqkfsbyJdXit;
			}
		}

		string gDrCmzJNXwFvGTMAYKGQspUqeYD.keyCategory => "controller/template";

		string gDrCmzJNXwFvGTMAYKGQspUqeYD.scriptingName => _name;

		string gDrCmzJNXwFvGTMAYKGQspUqeYD.nonLocalizedDescriptiveName
		{
			get
			{
				return _name;
			}
			set
			{
				kQkaEkBIZDevuVutudzWiVFYcmPP();
				_name = value;
			}
		}

		string mQQEUnWrvIENJEQHDjPIUvhAyczkA.nonLocalizedPositiveDescriptiveName
		{
			get
			{
				return _positiveName;
			}
			set
			{
				kQkaEkBIZDevuVutudzWiVFYcmPP();
				_positiveName = value;
			}
		}

		string mQQEUnWrvIENJEQHDjPIUvhAyczkA.nonLocalizedNegativeDescriptiveName
		{
			get
			{
				return _negativeName;
			}
			set
			{
				kQkaEkBIZDevuVutudzWiVFYcmPP();
				_negativeName = value;
			}
		}

		string gDrCmzJNXwFvGTMAYKGQspUqeYD.key => _key;

		string mQQEUnWrvIENJEQHDjPIUvhAyczkA.positiveKey
		{
			get
			{
				return _positiveKey;
			}
			set
			{
				kQkaEkBIZDevuVutudzWiVFYcmPP();
				_positiveKey = value;
			}
		}

		string mQQEUnWrvIENJEQHDjPIUvhAyczkA.negativeKey
		{
			get
			{
				return _negativeKey;
			}
			set
			{
				kQkaEkBIZDevuVutudzWiVFYcmPP();
				_negativeKey = value;
			}
		}

		int gDrCmzJNXwFvGTMAYKGQspUqeYD.autoGeneratedValueFlags
		{
			get
			{
				return ZTtgHYVAkQcqcLUqRuvvtAEqeaQd;
			}
			set
			{
				ZTtgHYVAkQcqcLUqRuvvtAEqeaQd = value;
			}
		}

		string AIHwxHYiZBEVvZOJUhghGWlTpYhGA.keyCategory => iiskKgDbWxOwEGnzrXYHgovqbhjF.YDJKkZYOITbTDBfdpBFljPYENlXkc(tKlCwlmtCqEowepcjsfTeNqfhnuLc);

		string AIHwxHYiZBEVvZOJUhghGWlTpYhGA.key => _key;

		int AIHwxHYiZBEVvZOJUhghGWlTpYhGA.autoGeneratedValueFlags
		{
			get
			{
				return ZTtgHYVAkQcqcLUqRuvvtAEqeaQd;
			}
			set
			{
				ZTtgHYVAkQcqcLUqRuvvtAEqeaQd = value;
			}
		}

		string sLizqcvxoCawnuvvDbUZJbhvIfejA.positiveKey
		{
			get
			{
				return _positiveKey;
			}
			set
			{
				kQkaEkBIZDevuVutudzWiVFYcmPP();
				_positiveKey = value;
			}
		}

		string sLizqcvxoCawnuvvDbUZJbhvIfejA.negativeKey
		{
			get
			{
				return _negativeKey;
			}
			set
			{
				kQkaEkBIZDevuVutudzWiVFYcmPP();
				_negativeKey = value;
			}
		}

		internal string GetCompoundElementSpecialName(int index)
		{
			if (!ReInput.isReady || !LocalizationManager.isEnabled || MQPlFjwEEmFXviAMpiBpArJasKfOB == null || XxShNWTFXznMXcCDzCLmsJHyKFWc == null)
			{
				return string.Empty;
			}
			return XxShNWTFXznMXcCDzCLmsJHyKFWc.VxSCVyObxksuNRtHTByuEmCYzwLj(index);
		}

		internal object GetCompoundElementSpecialGlyph(int index)
		{
			if (!ReInput.isReady || !GlyphManager.isEnabled || MQPlFjwEEmFXviAMpiBpArJasKfOB == null || fcZjIKITIgEpxBMhCYwUFMsFyEyf == null)
			{
				return null;
			}
			return fcZjIKITIgEpxBMhCYwUFMsFyEyf.YzMDwLdFGfaLFbOWPBausmCwzitO(index);
		}

		internal string GetCompoundElementSpecialFinalGlyphKey(int index)
		{
			if (!ReInput.isReady || !GlyphManager.isEnabled || MQPlFjwEEmFXviAMpiBpArJasKfOB == null || fcZjIKITIgEpxBMhCYwUFMsFyEyf == null)
			{
				return null;
			}
			return fcZjIKITIgEpxBMhCYwUFMsFyEyf.UjxZMpLtwXsaPbdwNRBLmDRYFbcAA(index);
		}

		string IControllerElementIdentifierCommon_Internal.GetSpecialElementNonLocalizedName(int index)
		{
			if (MQPlFjwEEmFXviAMpiBpArJasKfOB == null || (uint)index >= (uint)MQPlFjwEEmFXviAMpiBpArJasKfOB.Count)
			{
				return null;
			}
			return MQPlFjwEEmFXviAMpiBpArJasKfOB[index].GrYewptxYcDkbUwoPPWCHakZgWZBA;
		}

		string IControllerElementIdentifierCommon_Internal.GetSpecialElementKey(int index)
		{
			if (MQPlFjwEEmFXviAMpiBpArJasKfOB == null || (uint)index >= (uint)MQPlFjwEEmFXviAMpiBpArJasKfOB.Count)
			{
				return null;
			}
			return MQPlFjwEEmFXviAMpiBpArJasKfOB[index].CHIYqHtFcGYNYkIczCRpEdDqudMb;
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
			if (P_0.MQPlFjwEEmFXviAMpiBpArJasKfOB != null)
			{
				int count = P_0.MQPlFjwEEmFXviAMpiBpArJasKfOB.Count;
				MQPlFjwEEmFXviAMpiBpArJasKfOB = new List<rvJuRxKRGspvDJLaFVuFXmpZDEKV>(count);
				for (int i = 0; i < count; i++)
				{
					if (P_0.MQPlFjwEEmFXviAMpiBpArJasKfOB[i] != null)
					{
						MQPlFjwEEmFXviAMpiBpArJasKfOB.Add(new rvJuRxKRGspvDJLaFVuFXmpZDEKV(P_0.MQPlFjwEEmFXviAMpiBpArJasKfOB[i]));
					}
				}
			}
			ZTtgHYVAkQcqcLUqRuvvtAEqeaQd = P_0.ZTtgHYVAkQcqcLUqRuvvtAEqeaQd;
			tKlCwlmtCqEowepcjsfTeNqfhnuLc = P_0.tKlCwlmtCqEowepcjsfTeNqfhnuLc;
		}

		internal ControllerElementIdentifier(ojVewQJXCyYjrtbbWsMKJotWctHeA P_0)
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

		private void kQkaEkBIZDevuVutudzWiVFYcmPP()
		{
			if (XZyGJbYgDMryDBfsahBXbLSDFblib)
			{
				throw new Exception("The object is marked readonly and you are trying to modify its values.");
			}
		}

		internal void FinishRuntimeSetup(DeviceLocalizationInfo deviceLocalizationInfo, ControllerType controllerType)
		{
			tKlCwlmtCqEowepcjsfTeNqfhnuLc = controllerType;
			ToElementNameLocalizerTypes(_elementType, _compoundElementType, out var resultElementType, out var resultCompoundElementType);
			int num = AomZkhATSIadYOOLVfcgOnNtMQBs.YJjoDvcTlhdCNHOpHXbTafYtikvO(resultElementType, resultCompoundElementType);
			if (num > 0)
			{
				MQPlFjwEEmFXviAMpiBpArJasKfOB = new List<rvJuRxKRGspvDJLaFVuFXmpZDEKV>(num);
				for (int i = 0; i < num; i++)
				{
					MQPlFjwEEmFXviAMpiBpArJasKfOB.Add(new rvJuRxKRGspvDJLaFVuFXmpZDEKV());
				}
			}
			oGcUULQeKKhrlPdVEuSBQNPPghKW = deviceLocalizationInfo;
			ZfgalFhoNnvjyedtxfGIoNZLOvaH = mbAaHTOiYxhnyoaJRfjMoaCGrCBj.xwgcpxXUdALuiIPonXTWOjFDjMSg(this, dmjDbQFcymNDumSFQtSdVxLzPZVm.RGmoyPWcqSjXoOejoZSFuNsUephS(controllerType), resultElementType, resultCompoundElementType, _id, deviceLocalizationInfo);
			OFOrLKVDGKjsVieSShJCWeLhamir = XbxYllaEvMCIEbzNlnHzhuJNebc.HbkcgzPoLzWzFyCSASXEhDGeXxbA(this, dmjDbQFcymNDumSFQtSdVxLzPZVm.RGmoyPWcqSjXoOejoZSFuNsUephS(controllerType), resultElementType, resultCompoundElementType, _id, deviceLocalizationInfo);
			if (_elementType == ControllerElementType.CompoundElement)
			{
				XxShNWTFXznMXcCDzCLmsJHyKFWc = BLzCsuUSxuHNlyOBbPCMSbrlIPBG.gIKoHCujqwzPDpPLMgDmBxpPValA(this, dmjDbQFcymNDumSFQtSdVxLzPZVm.RGmoyPWcqSjXoOejoZSFuNsUephS(controllerType), resultElementType, resultCompoundElementType, _id, deviceLocalizationInfo);
				fcZjIKITIgEpxBMhCYwUFMsFyEyf = FDrDdMdvbLiGNNnJmNMDaukLRJtd.NTxedJhSssXgsrkxdKksYDjHddOS(this, dmjDbQFcymNDumSFQtSdVxLzPZVm.RGmoyPWcqSjXoOejoZSFuNsUephS(controllerType), resultElementType, resultCompoundElementType, _id, deviceLocalizationInfo);
			}
		}

		internal static void ToElementNameLocalizerTypes(ControllerElementType type, CompoundControllerElementType compoundType, out AomZkhATSIadYOOLVfcgOnNtMQBs.fyQKArxdnRgBFXnCTGFifmqgwogRA resultElementType, out AomZkhATSIadYOOLVfcgOnNtMQBs.OUxgQpuZIuwKyJEylNPLslOwBwNAA resultCompoundElementType)
		{
			resultCompoundElementType = AomZkhATSIadYOOLVfcgOnNtMQBs.OUxgQpuZIuwKyJEylNPLslOwBwNAA.None;
			switch (type)
			{
			case ControllerElementType.Axis:
				resultElementType = AomZkhATSIadYOOLVfcgOnNtMQBs.fyQKArxdnRgBFXnCTGFifmqgwogRA.Axis;
				break;
			case ControllerElementType.Button:
				resultElementType = AomZkhATSIadYOOLVfcgOnNtMQBs.fyQKArxdnRgBFXnCTGFifmqgwogRA.Button;
				break;
			case ControllerElementType.CompoundElement:
				resultElementType = AomZkhATSIadYOOLVfcgOnNtMQBs.fyQKArxdnRgBFXnCTGFifmqgwogRA.CompoundElement;
				switch (compoundType)
				{
				case CompoundControllerElementType.Axis2D:
					resultCompoundElementType = AomZkhATSIadYOOLVfcgOnNtMQBs.OUxgQpuZIuwKyJEylNPLslOwBwNAA.Axis2D;
					break;
				case CompoundControllerElementType.Hat:
					resultCompoundElementType = AomZkhATSIadYOOLVfcgOnNtMQBs.OUxgQpuZIuwKyJEylNPLslOwBwNAA.Hat;
					break;
				case CompoundControllerElementType.DPad:
					resultCompoundElementType = AomZkhATSIadYOOLVfcgOnNtMQBs.OUxgQpuZIuwKyJEylNPLslOwBwNAA.DPad;
					break;
				default:
					resultElementType = AomZkhATSIadYOOLVfcgOnNtMQBs.fyQKArxdnRgBFXnCTGFifmqgwogRA.Unknown;
					break;
				}
				break;
			default:
				resultElementType = AomZkhATSIadYOOLVfcgOnNtMQBs.fyQKArxdnRgBFXnCTGFifmqgwogRA.Unknown;
				break;
			}
		}

		string wOcwbdLCJaOhasRXtoPQFUPfsCvq.GetSpecialElementNonLocalizedDescriptiveName(int index)
		{
			if (MQPlFjwEEmFXviAMpiBpArJasKfOB == null || index >= MQPlFjwEEmFXviAMpiBpArJasKfOB.Count)
			{
				return null;
			}
			return MQPlFjwEEmFXviAMpiBpArJasKfOB[index].GrYewptxYcDkbUwoPPWCHakZgWZBA;
		}

		void wOcwbdLCJaOhasRXtoPQFUPfsCvq.SetSpecialElementNonLocalizedDescriptiveName(int index, string value)
		{
			if (MQPlFjwEEmFXviAMpiBpArJasKfOB != null && index < MQPlFjwEEmFXviAMpiBpArJasKfOB.Count)
			{
				MQPlFjwEEmFXviAMpiBpArJasKfOB[index].GrYewptxYcDkbUwoPPWCHakZgWZBA = value;
			}
		}

		string wOcwbdLCJaOhasRXtoPQFUPfsCvq.GetSpecialElementKey(int index)
		{
			if (MQPlFjwEEmFXviAMpiBpArJasKfOB == null || index >= MQPlFjwEEmFXviAMpiBpArJasKfOB.Count)
			{
				return null;
			}
			return MQPlFjwEEmFXviAMpiBpArJasKfOB[index].CHIYqHtFcGYNYkIczCRpEdDqudMb;
		}

		void wOcwbdLCJaOhasRXtoPQFUPfsCvq.SetSpecialElementKey(int index, string value)
		{
			if (MQPlFjwEEmFXviAMpiBpArJasKfOB != null && index < MQPlFjwEEmFXviAMpiBpArJasKfOB.Count)
			{
				MQPlFjwEEmFXviAMpiBpArJasKfOB[index].CHIYqHtFcGYNYkIczCRpEdDqudMb = value;
			}
		}

		string jhzHtawhGfHVCurgBdqnjuHNyiNIA.GetSpecialElementKey(int index)
		{
			if (MQPlFjwEEmFXviAMpiBpArJasKfOB == null || index >= MQPlFjwEEmFXviAMpiBpArJasKfOB.Count)
			{
				return null;
			}
			return MQPlFjwEEmFXviAMpiBpArJasKfOB[index].CHIYqHtFcGYNYkIczCRpEdDqudMb;
		}

		void jhzHtawhGfHVCurgBdqnjuHNyiNIA.SetSpecialElementKey(int index, string value)
		{
			if (MQPlFjwEEmFXviAMpiBpArJasKfOB != null && index < MQPlFjwEEmFXviAMpiBpArJasKfOB.Count)
			{
				MQPlFjwEEmFXviAMpiBpArJasKfOB[index].CHIYqHtFcGYNYkIczCRpEdDqudMb = value;
			}
		}
	}
}
