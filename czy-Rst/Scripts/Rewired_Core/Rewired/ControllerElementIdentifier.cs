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
	public sealed class ControllerElementIdentifier : IControllerElementIdentifierCommon_Internal, bXtOivlsOYjkGZtzvdtdZjoKDUCF, leeNpeIpkRWAaDYnewmtyKpQcRpw, hWHawgOADYRYslwTpcXmtDidkGPQ, VXuSsTlJoBHbugAzwdYIdycaHtQaB, jmJlodmyeuTJffDdVhrvxnUdztWH, euWsBsFZlnKdNdwSzRGQMkIVzLgq
	{
		[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
		internal class bSeqdIyVjkTFqqpLamBpjhuEDWyN
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

		internal sealed class mFENOdNJhrkhIKlpUGskCPWIqryD
		{
			[Serializable]
			private sealed class klVkFCnzniPMbCflHbdHXhLhTyML
			{
				public static readonly klVkFCnzniPMbCflHbdHXhLhTyML _003C_003E9 = new klVkFCnzniPMbCflHbdHXhLhTyML();

				public static Func<ControllerElementIdentifier, ControllerElementIdentifier, bool> _003C_003E9__4_0;

				internal bool RzAjIwmHCqleCUwnuSvLVvADYRgA(ControllerElementIdentifier P_0, ControllerElementIdentifier P_1)
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

			private static mFENOdNJhrkhIKlpUGskCPWIqryD RroENtAfHLZHAHaZrqGdlveErATcA;

			private readonly global::NijeqNRuOtTHOXfLLAdncronsTLUA<ControllerElementIdentifier> hFcvOXyJtCwbpLOmjoTQAKDweuW;

			private static mFENOdNJhrkhIKlpUGskCPWIqryD SZksCIqAsYJRUwGVbJCEFRAEeZje
			{
				get
				{
					if (RroENtAfHLZHAHaZrqGdlveErATcA != null)
					{
						return RroENtAfHLZHAHaZrqGdlveErATcA;
					}
					RroENtAfHLZHAHaZrqGdlveErATcA = new mFENOdNJhrkhIKlpUGskCPWIqryD();
					RroENtAfHLZHAHaZrqGdlveErATcA.gzyFpwhIrcLTJKGAbjZDFszwErLFA();
					return RroENtAfHLZHAHaZrqGdlveErATcA;
				}
			}

			private mFENOdNJhrkhIKlpUGskCPWIqryD()
			{
				hFcvOXyJtCwbpLOmjoTQAKDweuW = new global::NijeqNRuOtTHOXfLLAdncronsTLUA<ControllerElementIdentifier>(klVkFCnzniPMbCflHbdHXhLhTyML._003C_003E9.RzAjIwmHCqleCUwnuSvLVvADYRgA);
			}

			private void gzyFpwhIrcLTJKGAbjZDFszwErLFA()
			{
				ReInput.ShutDownEvent += RroENtAfHLZHAHaZrqGdlveErATcA.DuScJvAoCIpuOoSoyPpnyWODHowI;
			}

			private void DuScJvAoCIpuOoSoyPpnyWODHowI()
			{
				if (RroENtAfHLZHAHaZrqGdlveErATcA == this)
				{
					RroENtAfHLZHAHaZrqGdlveErATcA = null;
				}
				ReInput.ShutDownEvent -= DuScJvAoCIpuOoSoyPpnyWODHowI;
			}

			public static ControllerElementIdentifier ksnCOhrYYYfXhfFcIFmGXkoYgPOEA(DeviceLocalizationInfo P_0, ControllerElementIdentifier P_1)
			{
				return SZksCIqAsYJRUwGVbJCEFRAEeZje.hFcvOXyJtCwbpLOmjoTQAKDweuW.wxUbEGFQBfjePUsdQYoNnyHInQFpA(P_0.hash, P_1);
			}

			public static bool OfTscTDqcAQMbmooMFVCagkLqQgrA(DeviceLocalizationInfo P_0, ControllerElementIdentifier P_1, out ControllerElementIdentifier P_2)
			{
				return SZksCIqAsYJRUwGVbJCEFRAEeZje.hFcvOXyJtCwbpLOmjoTQAKDweuW.SYZFKzfaOuaZyGqwgDHDIzPBmdSrA(P_0.hash, P_1, out P_2);
			}

			public static void GczaTXxxkTvxQbTgRjCcuNwWEiUY(DeviceLocalizationInfo P_0, ControllerElementIdentifier P_1)
			{
				SZksCIqAsYJRUwGVbJCEFRAEeZje.hFcvOXyJtCwbpLOmjoTQAKDweuW.tsZmAlwqEXvBYjcnUbtXfqwZjrMo(P_0.hash, P_1);
			}
		}

		private class wFcaJrdXdkmXGSAKhGWovViJCdnz
		{
			[SerializeField]
			private string CFTclfWCUbYPARouzFGtFDLLLNreb;

			[SerializeField]
			private string IPjXQjDpJzTYcBbfLviwqxGaBuq;

			public string BwdLUwOSwMyQGjIyPCwqkLwcjBOX
			{
				get
				{
					return CFTclfWCUbYPARouzFGtFDLLLNreb;
				}
				set
				{
					CFTclfWCUbYPARouzFGtFDLLLNreb = cFTclfWCUbYPARouzFGtFDLLLNreb;
				}
			}

			public string RMteydOvWeIPgNUhdkebjGtPrDqL
			{
				get
				{
					return IPjXQjDpJzTYcBbfLviwqxGaBuq;
				}
				set
				{
					IPjXQjDpJzTYcBbfLviwqxGaBuq = iPjXQjDpJzTYcBbfLviwqxGaBuq;
				}
			}

			public wFcaJrdXdkmXGSAKhGWovViJCdnz()
			{
			}

			public wFcaJrdXdkmXGSAKhGWovViJCdnz(wFcaJrdXdkmXGSAKhGWovViJCdnz P_0)
			{
				CFTclfWCUbYPARouzFGtFDLLLNreb = P_0.CFTclfWCUbYPARouzFGtFDLLLNreb;
				IPjXQjDpJzTYcBbfLviwqxGaBuq = P_0.IPjXQjDpJzTYcBbfLviwqxGaBuq;
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

		[NonSerialized]
		private bool CKPJKftFqUMsWWaWUpxafnHPGpGh;

		[NonSerialized]
		private fdpfgJnMxjBVlnubvZxxSwBKSBwH CENGyDCMLnfFtnZNNrHxGYYXgpJX;

		[NonSerialized]
		private CnQiCatlxaadkclyJFnfOigtKbyIA QMberKeoinNXWvCaTCqPYVYwjSom;

		[NonSerialized]
		private AeIojEYKXjMwXFAZvRJEHSgNgyZw LYxjzUothMODAzKcyjVxovEbYRJx;

		[NonSerialized]
		private AUYmHhEeGVjKOWUHIgbqgMlToqEAA ucuGtYxigisSwWcmyGenleBPgJJfA;

		[NonSerialized]
		private DeviceLocalizationInfo xUZtKBpIfOvZwExxowUqgpSNISbj;

		[NonSerialized]
		private int UKSruSuHvYRKlKewzTISJELmvDlQ;

		[NonSerialized]
		private List<wFcaJrdXdkmXGSAKhGWovViJCdnz> TncVxQDbxcfqbLmlLlSMNKaorOiB;

		[NonSerialized]
		private ControllerType uqQuyfLHncOltkcGRIXkpQllUYHl;

		private static ControllerElementIdentifier fETFvyGzekYouiDNAVWCcClPYyPLA;

		int IControllerElementIdentifierCommon_Internal.id => _id;

		string IControllerElementIdentifierCommon_Internal.name
		{
			get
			{
				if (!ReInput.isReady || CENGyDCMLnfFtnZNNrHxGYYXgpJX == null || !LocalizationManager.isEnabled)
				{
					return _name;
				}
				return CENGyDCMLnfFtnZNNrHxGYYXgpJX.YYpaixksduwqUQfFFmPUzWfHjhDu;
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
				if (!ReInput.isReady || CENGyDCMLnfFtnZNNrHxGYYXgpJX == null || !LocalizationManager.isEnabled)
				{
					return _positiveName;
				}
				return CENGyDCMLnfFtnZNNrHxGYYXgpJX.iLiuzsLDQkvHfcjDCcGykVsvicft;
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
				if (!ReInput.isReady || CENGyDCMLnfFtnZNNrHxGYYXgpJX == null || !LocalizationManager.isEnabled)
				{
					return _negativeName;
				}
				return CENGyDCMLnfFtnZNNrHxGYYXgpJX.CzMNKjcKhXiLoSCUyZnmWlpFrLws;
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
				if (!ReInput.isReady || LYxjzUothMODAzKcyjVxovEbYRJx == null || !GlyphManager.isEnabled)
				{
					return null;
				}
				return LYxjzUothMODAzKcyjVxovEbYRJx.DOWjBOgoZsencABrFfHqopRtxZvy;
			}
		}

		public object positiveGlyph
		{
			get
			{
				if (!ReInput.isReady || LYxjzUothMODAzKcyjVxovEbYRJx == null || !GlyphManager.isEnabled)
				{
					return null;
				}
				return LYxjzUothMODAzKcyjVxovEbYRJx.wmuNdKUkrnkWpjuvYITjKzyigQIt;
			}
		}

		public object negativeGlyph
		{
			get
			{
				if (!ReInput.isReady || LYxjzUothMODAzKcyjVxovEbYRJx == null || !GlyphManager.isEnabled)
				{
					return null;
				}
				return LYxjzUothMODAzKcyjVxovEbYRJx.sWYnzYgdXPvOelpjXPXbjLkADKfr;
			}
		}

		private string finalGlyphKey
		{
			get
			{
				if (!ReInput.isReady || LYxjzUothMODAzKcyjVxovEbYRJx == null || !GlyphManager.isEnabled)
				{
					return null;
				}
				return LYxjzUothMODAzKcyjVxovEbYRJx.QfGGjPDMKogvJjFpIQxHufrcaNNt;
			}
		}

		private string finalPositiveGlyphKey
		{
			get
			{
				if (!ReInput.isReady || LYxjzUothMODAzKcyjVxovEbYRJx == null || !GlyphManager.isEnabled)
				{
					return null;
				}
				return LYxjzUothMODAzKcyjVxovEbYRJx.QrHHSNOiylXNliXvWTuJqpBeNbxv;
			}
		}

		private string finalNegativeGlyphKey
		{
			get
			{
				if (!ReInput.isReady || LYxjzUothMODAzKcyjVxovEbYRJx == null || !GlyphManager.isEnabled)
				{
					return null;
				}
				return LYxjzUothMODAzKcyjVxovEbYRJx.HHBrebMxBkmjqfbRGBIUbVgJzyuA;
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
					pPDVsoaMsJJBnMEFYQDpSkAKORcY();
					if (CENGyDCMLnfFtnZNNrHxGYYXgpJX != null)
					{
						CENGyDCMLnfFtnZNNrHxGYYXgpJX.GvKqFlBIauBSccpqkijaDCUIwlHHB();
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
					pPDVsoaMsJJBnMEFYQDpSkAKORcY();
					if (CENGyDCMLnfFtnZNNrHxGYYXgpJX != null)
					{
						CENGyDCMLnfFtnZNNrHxGYYXgpJX.lBnLmeaxZDkhxYoPMPJqXmFtBMet();
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
					pPDVsoaMsJJBnMEFYQDpSkAKORcY();
					if (CENGyDCMLnfFtnZNNrHxGYYXgpJX != null)
					{
						CENGyDCMLnfFtnZNNrHxGYYXgpJX.QywrBRmSUSMMOTNxYjMpHKVxFPHD();
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

		bool IControllerElementIdentifierCommon_Internal.isNonLocalizedPositiveNameAutoGenerated => (UKSruSuHvYRKlKewzTISJELmvDlQ & 2) != 0;

		bool IControllerElementIdentifierCommon_Internal.isNonLocalizedNegativeNameAutoGenerated => (UKSruSuHvYRKlKewzTISJELmvDlQ & 4) != 0;

		bool IControllerElementIdentifierCommon_Internal.isPositiveKeyAutoGenerated => (UKSruSuHvYRKlKewzTISJELmvDlQ & 8) != 0;

		bool IControllerElementIdentifierCommon_Internal.isNegativeKeyAutoGenerated => (UKSruSuHvYRKlKewzTISJELmvDlQ & 0x10) != 0;

		string IControllerElementIdentifierCommon_Internal.key => _key;

		string IControllerElementIdentifierCommon_Internal.positiveKey => _positiveKey;

		string IControllerElementIdentifierCommon_Internal.negativeKey => _negativeKey;

		DeviceLocalizationInfo IControllerElementIdentifierCommon_Internal.deviceLocalizationInfo => xUZtKBpIfOvZwExxowUqgpSNISbj;

		object IControllerElementIdentifierCommon_Internal.elementType => _elementType;

		bool IControllerElementIdentifierCommon_Internal.useEditorElementTypeOverride => false;

		ControllerElementType IControllerElementIdentifierCommon_Internal.editorElementTypeOverride => _elementType;

		internal static ControllerElementIdentifier BlankReadOnly
		{
			get
			{
				if (fETFvyGzekYouiDNAVWCcClPYyPLA == null)
				{
					ControllerElementIdentifier result = new ControllerElementIdentifier
					{
						_id = -1,
						CKPJKftFqUMsWWaWUpxafnHPGpGh = true
					};
					fETFvyGzekYouiDNAVWCcClPYyPLA = result;
					return result;
				}
				return fETFvyGzekYouiDNAVWCcClPYyPLA;
			}
		}

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
				pPDVsoaMsJJBnMEFYQDpSkAKORcY();
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
				pPDVsoaMsJJBnMEFYQDpSkAKORcY();
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
				pPDVsoaMsJJBnMEFYQDpSkAKORcY();
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
				pPDVsoaMsJJBnMEFYQDpSkAKORcY();
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
				pPDVsoaMsJJBnMEFYQDpSkAKORcY();
				_negativeKey = value;
			}
		}

		int leeNpeIpkRWAaDYnewmtyKpQcRpw.autoGeneratedValueFlags
		{
			get
			{
				return UKSruSuHvYRKlKewzTISJELmvDlQ;
			}
			set
			{
				UKSruSuHvYRKlKewzTISJELmvDlQ = value;
			}
		}

		string VXuSsTlJoBHbugAzwdYIdycaHtQaB.keyCategory => dXDhgciBpvPiLRoZXBpiBCxofOAPA.VAyqCRnPdBxTMsjTXxMMdwTFWTiJ(uqQuyfLHncOltkcGRIXkpQllUYHl);

		string VXuSsTlJoBHbugAzwdYIdycaHtQaB.key => _key;

		int VXuSsTlJoBHbugAzwdYIdycaHtQaB.autoGeneratedValueFlags
		{
			get
			{
				return UKSruSuHvYRKlKewzTISJELmvDlQ;
			}
			set
			{
				UKSruSuHvYRKlKewzTISJELmvDlQ = value;
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
				pPDVsoaMsJJBnMEFYQDpSkAKORcY();
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
				pPDVsoaMsJJBnMEFYQDpSkAKORcY();
				_negativeKey = value;
			}
		}

		internal string GetCompoundElementSpecialName(int index)
		{
			if (!ReInput.isReady || !LocalizationManager.isEnabled || TncVxQDbxcfqbLmlLlSMNKaorOiB == null || QMberKeoinNXWvCaTCqPYVYwjSom == null)
			{
				return string.Empty;
			}
			return QMberKeoinNXWvCaTCqPYVYwjSom.GKfACuKlEeaAGEWnfvjBJwNbGKcuC(index);
		}

		internal object GetCompoundElementSpecialGlyph(int index)
		{
			if (!ReInput.isReady || !GlyphManager.isEnabled || TncVxQDbxcfqbLmlLlSMNKaorOiB == null || ucuGtYxigisSwWcmyGenleBPgJJfA == null)
			{
				return null;
			}
			return ucuGtYxigisSwWcmyGenleBPgJJfA.LOdXDFSNhfdfWiycbFWLGaBiZNGX(index);
		}

		internal string GetCompoundElementSpecialFinalGlyphKey(int index)
		{
			if (!ReInput.isReady || !GlyphManager.isEnabled || TncVxQDbxcfqbLmlLlSMNKaorOiB == null || ucuGtYxigisSwWcmyGenleBPgJJfA == null)
			{
				return null;
			}
			return ucuGtYxigisSwWcmyGenleBPgJJfA.DDYWjtyRPVEjOiNOrnwoMWUGCbLK(index);
		}

		string IControllerElementIdentifierCommon_Internal.GetSpecialElementNonLocalizedName(int index)
		{
			if (TncVxQDbxcfqbLmlLlSMNKaorOiB == null || (uint)index >= (uint)TncVxQDbxcfqbLmlLlSMNKaorOiB.Count)
			{
				return null;
			}
			return TncVxQDbxcfqbLmlLlSMNKaorOiB[index].RMteydOvWeIPgNUhdkebjGtPrDqL;
		}

		string IControllerElementIdentifierCommon_Internal.GetSpecialElementKey(int index)
		{
			if (TncVxQDbxcfqbLmlLlSMNKaorOiB == null || (uint)index >= (uint)TncVxQDbxcfqbLmlLlSMNKaorOiB.Count)
			{
				return null;
			}
			return TncVxQDbxcfqbLmlLlSMNKaorOiB[index].BwdLUwOSwMyQGjIyPCwqkLwcjBOX;
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
			if (P_0.TncVxQDbxcfqbLmlLlSMNKaorOiB != null)
			{
				int count = P_0.TncVxQDbxcfqbLmlLlSMNKaorOiB.Count;
				TncVxQDbxcfqbLmlLlSMNKaorOiB = new List<wFcaJrdXdkmXGSAKhGWovViJCdnz>(count);
				for (int i = 0; i < count; i++)
				{
					if (P_0.TncVxQDbxcfqbLmlLlSMNKaorOiB[i] != null)
					{
						TncVxQDbxcfqbLmlLlSMNKaorOiB.Add(new wFcaJrdXdkmXGSAKhGWovViJCdnz(P_0.TncVxQDbxcfqbLmlLlSMNKaorOiB[i]));
					}
				}
			}
			UKSruSuHvYRKlKewzTISJELmvDlQ = P_0.UKSruSuHvYRKlKewzTISJELmvDlQ;
			uqQuyfLHncOltkcGRIXkpQllUYHl = P_0.uqQuyfLHncOltkcGRIXkpQllUYHl;
		}

		internal ControllerElementIdentifier(bSeqdIyVjkTFqqpLamBpjhuEDWyN P_0)
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

		private void pPDVsoaMsJJBnMEFYQDpSkAKORcY()
		{
			if (CKPJKftFqUMsWWaWUpxafnHPGpGh)
			{
				throw new Exception("The object is marked readonly and you are trying to modify its values.");
			}
		}

		internal void FinishRuntimeSetup(DeviceLocalizationInfo deviceLocalizationInfo, ControllerType controllerType)
		{
			uqQuyfLHncOltkcGRIXkpQllUYHl = controllerType;
			ToElementNameLocalizerTypes(_elementType, _compoundElementType, out var resultElementType, out var resultCompoundElementType);
			int num = RyDiYtnCdYRqXXpxvIjJeSOrrroG.LdCDypFhAhzHGQMVrcvuiORltJYJA(resultElementType, resultCompoundElementType);
			if (num > 0)
			{
				TncVxQDbxcfqbLmlLlSMNKaorOiB = new List<wFcaJrdXdkmXGSAKhGWovViJCdnz>(num);
				for (int i = 0; i < num; i++)
				{
					TncVxQDbxcfqbLmlLlSMNKaorOiB.Add(new wFcaJrdXdkmXGSAKhGWovViJCdnz());
				}
			}
			xUZtKBpIfOvZwExxowUqgpSNISbj = deviceLocalizationInfo;
			CENGyDCMLnfFtnZNNrHxGYYXgpJX = fdpfgJnMxjBVlnubvZxxSwBKSBwH.qLPTunycQAMpfHZWFrzhsvYPjGlw(this, uXMxnWkZJybDbxtngkjAfeQxehsI.AXiHZzPnCjYlVPHOaegKxQAQNYc(controllerType), resultElementType, resultCompoundElementType, _id, deviceLocalizationInfo);
			LYxjzUothMODAzKcyjVxovEbYRJx = AeIojEYKXjMwXFAZvRJEHSgNgyZw.UXOnicAJXZAaucMygiegJsYCouMHA(this, uXMxnWkZJybDbxtngkjAfeQxehsI.AXiHZzPnCjYlVPHOaegKxQAQNYc(controllerType), resultElementType, resultCompoundElementType, _id, deviceLocalizationInfo);
			if (_elementType == ControllerElementType.CompoundElement)
			{
				QMberKeoinNXWvCaTCqPYVYwjSom = CnQiCatlxaadkclyJFnfOigtKbyIA.xQlNwNLXCkETMspxfAWclkafhqBfA(this, uXMxnWkZJybDbxtngkjAfeQxehsI.AXiHZzPnCjYlVPHOaegKxQAQNYc(controllerType), resultElementType, resultCompoundElementType, _id, deviceLocalizationInfo);
				ucuGtYxigisSwWcmyGenleBPgJJfA = AUYmHhEeGVjKOWUHIgbqgMlToqEAA.GpYtZRWQZsEurckNVgsJmHiNOftH(this, uXMxnWkZJybDbxtngkjAfeQxehsI.AXiHZzPnCjYlVPHOaegKxQAQNYc(controllerType), resultElementType, resultCompoundElementType, _id, deviceLocalizationInfo);
			}
		}

		internal static void ToElementNameLocalizerTypes(ControllerElementType type, CompoundControllerElementType compoundType, out RyDiYtnCdYRqXXpxvIjJeSOrrroG.wDdhIfgQYXRpSeEwrBrHOItkwVRlA resultElementType, out RyDiYtnCdYRqXXpxvIjJeSOrrroG.NpYWoxDajscclIyARrpcWpXeFhgi resultCompoundElementType)
		{
			resultCompoundElementType = RyDiYtnCdYRqXXpxvIjJeSOrrroG.NpYWoxDajscclIyARrpcWpXeFhgi.None;
			switch (type)
			{
			case ControllerElementType.Axis:
				resultElementType = RyDiYtnCdYRqXXpxvIjJeSOrrroG.wDdhIfgQYXRpSeEwrBrHOItkwVRlA.Axis;
				break;
			case ControllerElementType.Button:
				resultElementType = RyDiYtnCdYRqXXpxvIjJeSOrrroG.wDdhIfgQYXRpSeEwrBrHOItkwVRlA.Button;
				break;
			case ControllerElementType.CompoundElement:
				resultElementType = RyDiYtnCdYRqXXpxvIjJeSOrrroG.wDdhIfgQYXRpSeEwrBrHOItkwVRlA.CompoundElement;
				switch (compoundType)
				{
				case CompoundControllerElementType.Axis2D:
					resultCompoundElementType = RyDiYtnCdYRqXXpxvIjJeSOrrroG.NpYWoxDajscclIyARrpcWpXeFhgi.Axis2D;
					break;
				case CompoundControllerElementType.Hat:
					resultCompoundElementType = RyDiYtnCdYRqXXpxvIjJeSOrrroG.NpYWoxDajscclIyARrpcWpXeFhgi.Hat;
					break;
				case CompoundControllerElementType.DPad:
					resultCompoundElementType = RyDiYtnCdYRqXXpxvIjJeSOrrroG.NpYWoxDajscclIyARrpcWpXeFhgi.DPad;
					break;
				default:
					resultElementType = RyDiYtnCdYRqXXpxvIjJeSOrrroG.wDdhIfgQYXRpSeEwrBrHOItkwVRlA.Unknown;
					break;
				}
				break;
			default:
				resultElementType = RyDiYtnCdYRqXXpxvIjJeSOrrroG.wDdhIfgQYXRpSeEwrBrHOItkwVRlA.Unknown;
				break;
			}
		}

		string jmJlodmyeuTJffDdVhrvxnUdztWH.GetSpecialElementNonLocalizedDescriptiveName(int index)
		{
			if (TncVxQDbxcfqbLmlLlSMNKaorOiB == null || index >= TncVxQDbxcfqbLmlLlSMNKaorOiB.Count)
			{
				return null;
			}
			return TncVxQDbxcfqbLmlLlSMNKaorOiB[index].RMteydOvWeIPgNUhdkebjGtPrDqL;
		}

		void jmJlodmyeuTJffDdVhrvxnUdztWH.SetSpecialElementNonLocalizedDescriptiveName(int index, string value)
		{
			if (TncVxQDbxcfqbLmlLlSMNKaorOiB != null && index < TncVxQDbxcfqbLmlLlSMNKaorOiB.Count)
			{
				TncVxQDbxcfqbLmlLlSMNKaorOiB[index].RMteydOvWeIPgNUhdkebjGtPrDqL = value;
			}
		}

		string jmJlodmyeuTJffDdVhrvxnUdztWH.GetSpecialElementKey(int index)
		{
			if (TncVxQDbxcfqbLmlLlSMNKaorOiB == null || index >= TncVxQDbxcfqbLmlLlSMNKaorOiB.Count)
			{
				return null;
			}
			return TncVxQDbxcfqbLmlLlSMNKaorOiB[index].BwdLUwOSwMyQGjIyPCwqkLwcjBOX;
		}

		void jmJlodmyeuTJffDdVhrvxnUdztWH.SetSpecialElementKey(int index, string value)
		{
			if (TncVxQDbxcfqbLmlLlSMNKaorOiB != null && index < TncVxQDbxcfqbLmlLlSMNKaorOiB.Count)
			{
				TncVxQDbxcfqbLmlLlSMNKaorOiB[index].BwdLUwOSwMyQGjIyPCwqkLwcjBOX = value;
			}
		}

		string euWsBsFZlnKdNdwSzRGQMkIVzLgq.GetSpecialElementKey(int index)
		{
			if (TncVxQDbxcfqbLmlLlSMNKaorOiB == null || index >= TncVxQDbxcfqbLmlLlSMNKaorOiB.Count)
			{
				return null;
			}
			return TncVxQDbxcfqbLmlLlSMNKaorOiB[index].BwdLUwOSwMyQGjIyPCwqkLwcjBOX;
		}

		void euWsBsFZlnKdNdwSzRGQMkIVzLgq.SetSpecialElementKey(int index, string value)
		{
			if (TncVxQDbxcfqbLmlLlSMNKaorOiB != null && index < TncVxQDbxcfqbLmlLlSMNKaorOiB.Count)
			{
				TncVxQDbxcfqbLmlLlSMNKaorOiB[index].BwdLUwOSwMyQGjIyPCwqkLwcjBOX = value;
			}
		}
	}
}
