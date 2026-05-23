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
	public sealed class ControllerElementIdentifier : IControllerElementIdentifierCommon_Internal, LiukxMkkUUmGsEJaoRyGyuSBQfoS, LnhaMJXLiFbdSGpizhhMTtFDjtXy, ZhCqPBFhNKEpWHuMwXbLVCWahcjab, vfRBokPaPPEWJRenHDjJaOGZJkR, DEOLSCnqecUoFqpsMneIWaoyXVqt, WXuKXKglhBEpgRBwkNznjqCddGcA
	{
		[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
		internal class JJdeZvdjnivmGnZMnwtOMfIBzcAP
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

		internal sealed class YZHSetWXJjgByTksBDFHjlzVwSMEA
		{
			[Serializable]
			private sealed class GxQmBhmtloBcBFlaWxwskjziUGkk
			{
				public static readonly GxQmBhmtloBcBFlaWxwskjziUGkk _003C_003E9 = new GxQmBhmtloBcBFlaWxwskjziUGkk();

				public static Func<ControllerElementIdentifier, ControllerElementIdentifier, bool> _003C_003E9__4_0;

				internal bool pLqTGpnIVAmSIFKhuaNMkWFLXcby(ControllerElementIdentifier P_0, ControllerElementIdentifier P_1)
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

			private static YZHSetWXJjgByTksBDFHjlzVwSMEA tVpkqCacJRahsxACgGJMCuWRimrK;

			private readonly global::frkDecQuGtqloMwKYmMMIfIonbfk<ControllerElementIdentifier> VtYuQbEOJhiVLFaDdRpuBbwKIUYTA;

			private static YZHSetWXJjgByTksBDFHjlzVwSMEA qvrzVdzJMEhimvQDwgEdqzrBMSXW
			{
				get
				{
					if (tVpkqCacJRahsxACgGJMCuWRimrK != null)
					{
						return tVpkqCacJRahsxACgGJMCuWRimrK;
					}
					tVpkqCacJRahsxACgGJMCuWRimrK = new YZHSetWXJjgByTksBDFHjlzVwSMEA();
					tVpkqCacJRahsxACgGJMCuWRimrK.UGtUKDwUtisNnZUBoWBwexXpPcvh();
					return tVpkqCacJRahsxACgGJMCuWRimrK;
				}
			}

			private YZHSetWXJjgByTksBDFHjlzVwSMEA()
			{
				VtYuQbEOJhiVLFaDdRpuBbwKIUYTA = new global::frkDecQuGtqloMwKYmMMIfIonbfk<ControllerElementIdentifier>(GxQmBhmtloBcBFlaWxwskjziUGkk._003C_003E9.pLqTGpnIVAmSIFKhuaNMkWFLXcby);
			}

			private void UGtUKDwUtisNnZUBoWBwexXpPcvh()
			{
				ReInput.ShutDownEvent += tVpkqCacJRahsxACgGJMCuWRimrK.hgVkBITRUUgGmzXtfHKKJFqMXvUp;
			}

			private void hgVkBITRUUgGmzXtfHKKJFqMXvUp()
			{
				if (tVpkqCacJRahsxACgGJMCuWRimrK == this)
				{
					tVpkqCacJRahsxACgGJMCuWRimrK = null;
				}
				ReInput.ShutDownEvent -= hgVkBITRUUgGmzXtfHKKJFqMXvUp;
			}

			public static ControllerElementIdentifier OeiSrAaEGAdGPeonHkdlwiULnjyeA(DeviceLocalizationInfo P_0, ControllerElementIdentifier P_1)
			{
				return qvrzVdzJMEhimvQDwgEdqzrBMSXW.VtYuQbEOJhiVLFaDdRpuBbwKIUYTA.WiXlndVHOhDtrdahVzEwBbrFiFlF(P_0.hash, P_1);
			}

			public static bool yGwJoWjmAgfFBjzLkWlyHWUouAEA(DeviceLocalizationInfo P_0, ControllerElementIdentifier P_1, out ControllerElementIdentifier P_2)
			{
				return qvrzVdzJMEhimvQDwgEdqzrBMSXW.VtYuQbEOJhiVLFaDdRpuBbwKIUYTA.ygSxKCwLEisnUFvjzYlmWjzWgFws(P_0.hash, P_1, out P_2);
			}

			public static void qMeomicwiRdWaygxSCZXGRIHmEsnA(DeviceLocalizationInfo P_0, ControllerElementIdentifier P_1)
			{
				qvrzVdzJMEhimvQDwgEdqzrBMSXW.VtYuQbEOJhiVLFaDdRpuBbwKIUYTA.BJUFZEhwGLMUmyBgFeUcAyOMNcmk(P_0.hash, P_1);
			}
		}

		private class IyllqWsRfoGwkXzJufBFABSMmZVl
		{
			[SerializeField]
			private string kWANOSPMKreqoOytcfDMuhhMMzNr;

			[SerializeField]
			private string wUWuqvqZrRDqqfIeaAmRHxLZcxQz;

			public string fkexPZTBmGFRyugrYmvZTKKdTdsW
			{
				get
				{
					return kWANOSPMKreqoOytcfDMuhhMMzNr;
				}
				set
				{
					kWANOSPMKreqoOytcfDMuhhMMzNr = text;
				}
			}

			public string dhyDVGgNxclfObYLctzGtUBWpPWgA
			{
				get
				{
					return wUWuqvqZrRDqqfIeaAmRHxLZcxQz;
				}
				set
				{
					wUWuqvqZrRDqqfIeaAmRHxLZcxQz = text;
				}
			}

			public IyllqWsRfoGwkXzJufBFABSMmZVl()
			{
			}

			public IyllqWsRfoGwkXzJufBFABSMmZVl(IyllqWsRfoGwkXzJufBFABSMmZVl P_0)
			{
				kWANOSPMKreqoOytcfDMuhhMMzNr = P_0.kWANOSPMKreqoOytcfDMuhhMMzNr;
				wUWuqvqZrRDqqfIeaAmRHxLZcxQz = P_0.wUWuqvqZrRDqqfIeaAmRHxLZcxQz;
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
		private bool cZUgeYkyiAZloMNHRBoTnOtWnewnA;

		[NonSerialized]
		private FmsHxmaJbvwpZaWikICOnWlHsjYj unGFreBvBnqyPadWWGXKdQaGBPfI;

		[NonSerialized]
		private kcVtlLkxxcCGEkDbOioGZBSsqBKy eUcWEnjxcngagmbhIfpilegtrDWw;

		[NonSerialized]
		private anLAKzLoHfdVthYCyIIfImKKsYrkA hMyACjlgnQjcuwNzfsCSHcwuqtzx;

		[NonSerialized]
		private eIDqhOHBKXbluRZOZweLzCDOHOcz AkpSrjyTekZcGBctfJdCYVfElrxR;

		[NonSerialized]
		private DeviceLocalizationInfo JOKjcsRpMdeGFEkfCbZcFsAlcVab;

		[NonSerialized]
		private int qYRHQxdenKrSXDYvcLqpsnjhnbPH;

		[NonSerialized]
		private List<IyllqWsRfoGwkXzJufBFABSMmZVl> xhjxeOAklgPOOUStIbmvybixlXeO;

		[NonSerialized]
		private ControllerType GINFZOEhjkOjNtMZSqURUkXgjepn;

		private static ControllerElementIdentifier XpWGVXukWqPVEAKvVZGvlDREQqne;

		int IControllerElementIdentifierCommon_Internal.id => _id;

		string IControllerElementIdentifierCommon_Internal.name
		{
			get
			{
				if (!ReInput.isReady || unGFreBvBnqyPadWWGXKdQaGBPfI == null || !LocalizationManager.isEnabled)
				{
					return _name;
				}
				return unGFreBvBnqyPadWWGXKdQaGBPfI.qJkqRAxrrocPcPhIKAOpCMJUoZxfA;
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
				if (!ReInput.isReady || unGFreBvBnqyPadWWGXKdQaGBPfI == null || !LocalizationManager.isEnabled)
				{
					return _positiveName;
				}
				return unGFreBvBnqyPadWWGXKdQaGBPfI.UDfFJNMhCyBCNIpQLiHPdXQolEJqA;
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
				if (!ReInput.isReady || unGFreBvBnqyPadWWGXKdQaGBPfI == null || !LocalizationManager.isEnabled)
				{
					return _negativeName;
				}
				return unGFreBvBnqyPadWWGXKdQaGBPfI.uHNCrEpNbRlmMRKTnwRRnCRKxuSl;
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
				if (!ReInput.isReady || hMyACjlgnQjcuwNzfsCSHcwuqtzx == null || !GlyphManager.isEnabled)
				{
					return null;
				}
				return hMyACjlgnQjcuwNzfsCSHcwuqtzx.jwZyctvWJoSKAGduMIqPWqlcniZh;
			}
		}

		public object positiveGlyph
		{
			get
			{
				if (!ReInput.isReady || hMyACjlgnQjcuwNzfsCSHcwuqtzx == null || !GlyphManager.isEnabled)
				{
					return null;
				}
				return hMyACjlgnQjcuwNzfsCSHcwuqtzx.EBxaYzPLdxoxLqFaNNMWpbWdpkgR;
			}
		}

		public object negativeGlyph
		{
			get
			{
				if (!ReInput.isReady || hMyACjlgnQjcuwNzfsCSHcwuqtzx == null || !GlyphManager.isEnabled)
				{
					return null;
				}
				return hMyACjlgnQjcuwNzfsCSHcwuqtzx.YeRcGxxxJJipYymqMgCYYEGVveXO;
			}
		}

		private string finalGlyphKey
		{
			get
			{
				if (!ReInput.isReady || hMyACjlgnQjcuwNzfsCSHcwuqtzx == null || !GlyphManager.isEnabled)
				{
					return null;
				}
				return hMyACjlgnQjcuwNzfsCSHcwuqtzx.wMJOQsCSAeFAdwAuPcLuBvPnqplR;
			}
		}

		private string finalPositiveGlyphKey
		{
			get
			{
				if (!ReInput.isReady || hMyACjlgnQjcuwNzfsCSHcwuqtzx == null || !GlyphManager.isEnabled)
				{
					return null;
				}
				return hMyACjlgnQjcuwNzfsCSHcwuqtzx.wYCljqJRutqoTlDqRfxkTLpvwHBU;
			}
		}

		private string finalNegativeGlyphKey
		{
			get
			{
				if (!ReInput.isReady || hMyACjlgnQjcuwNzfsCSHcwuqtzx == null || !GlyphManager.isEnabled)
				{
					return null;
				}
				return hMyACjlgnQjcuwNzfsCSHcwuqtzx.tEWSURZAlPhPJAgqSaWlcYfzQVGEb;
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
					TBCZJNdsXFeXZZYNXYManmsZlGTb();
					if (unGFreBvBnqyPadWWGXKdQaGBPfI != null)
					{
						unGFreBvBnqyPadWWGXKdQaGBPfI.wkNCiIKcomvvEiZxnJmXtmqxRPdW();
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
					TBCZJNdsXFeXZZYNXYManmsZlGTb();
					if (unGFreBvBnqyPadWWGXKdQaGBPfI != null)
					{
						unGFreBvBnqyPadWWGXKdQaGBPfI.BrqPcLzhJFhYTJVIHnKPgptmKoCR();
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
					TBCZJNdsXFeXZZYNXYManmsZlGTb();
					if (unGFreBvBnqyPadWWGXKdQaGBPfI != null)
					{
						unGFreBvBnqyPadWWGXKdQaGBPfI.oTvzCizjOSehqAUOHakMGgqsXjxJA();
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

		bool IControllerElementIdentifierCommon_Internal.isNonLocalizedPositiveNameAutoGenerated => (qYRHQxdenKrSXDYvcLqpsnjhnbPH & 2) != 0;

		bool IControllerElementIdentifierCommon_Internal.isNonLocalizedNegativeNameAutoGenerated => (qYRHQxdenKrSXDYvcLqpsnjhnbPH & 4) != 0;

		bool IControllerElementIdentifierCommon_Internal.isPositiveKeyAutoGenerated => (qYRHQxdenKrSXDYvcLqpsnjhnbPH & 8) != 0;

		bool IControllerElementIdentifierCommon_Internal.isNegativeKeyAutoGenerated => (qYRHQxdenKrSXDYvcLqpsnjhnbPH & 0x10) != 0;

		string IControllerElementIdentifierCommon_Internal.key => _key;

		string IControllerElementIdentifierCommon_Internal.positiveKey => _positiveKey;

		string IControllerElementIdentifierCommon_Internal.negativeKey => _negativeKey;

		DeviceLocalizationInfo IControllerElementIdentifierCommon_Internal.deviceLocalizationInfo => JOKjcsRpMdeGFEkfCbZcFsAlcVab;

		object IControllerElementIdentifierCommon_Internal.elementType => _elementType;

		bool IControllerElementIdentifierCommon_Internal.useEditorElementTypeOverride => false;

		ControllerElementType IControllerElementIdentifierCommon_Internal.editorElementTypeOverride => _elementType;

		internal static ControllerElementIdentifier BlankReadOnly
		{
			get
			{
				if (XpWGVXukWqPVEAKvVZGvlDREQqne == null)
				{
					ControllerElementIdentifier obj = new ControllerElementIdentifier
					{
						_id = -1,
						cZUgeYkyiAZloMNHRBoTnOtWnewnA = true
					};
					XpWGVXukWqPVEAKvVZGvlDREQqne = obj;
					return obj;
				}
				return XpWGVXukWqPVEAKvVZGvlDREQqne;
			}
		}

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
				TBCZJNdsXFeXZZYNXYManmsZlGTb();
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
				TBCZJNdsXFeXZZYNXYManmsZlGTb();
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
				TBCZJNdsXFeXZZYNXYManmsZlGTb();
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
				TBCZJNdsXFeXZZYNXYManmsZlGTb();
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
				TBCZJNdsXFeXZZYNXYManmsZlGTb();
				_negativeKey = value;
			}
		}

		int LnhaMJXLiFbdSGpizhhMTtFDjtXy.autoGeneratedValueFlags
		{
			get
			{
				return qYRHQxdenKrSXDYvcLqpsnjhnbPH;
			}
			set
			{
				qYRHQxdenKrSXDYvcLqpsnjhnbPH = value;
			}
		}

		string vfRBokPaPPEWJRenHDjJaOGZJkR.keyCategory => RfUTDPxyvrJRnCbYKkuVrGRpezaF.lwjfDadavJmMkchAiAidsIjvIiSdB(GINFZOEhjkOjNtMZSqURUkXgjepn);

		string vfRBokPaPPEWJRenHDjJaOGZJkR.key => _key;

		int vfRBokPaPPEWJRenHDjJaOGZJkR.autoGeneratedValueFlags
		{
			get
			{
				return qYRHQxdenKrSXDYvcLqpsnjhnbPH;
			}
			set
			{
				qYRHQxdenKrSXDYvcLqpsnjhnbPH = value;
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
				TBCZJNdsXFeXZZYNXYManmsZlGTb();
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
				TBCZJNdsXFeXZZYNXYManmsZlGTb();
				_negativeKey = value;
			}
		}

		internal string GetCompoundElementSpecialName(int index)
		{
			if (!ReInput.isReady || !LocalizationManager.isEnabled || xhjxeOAklgPOOUStIbmvybixlXeO == null || eUcWEnjxcngagmbhIfpilegtrDWw == null)
			{
				return string.Empty;
			}
			return eUcWEnjxcngagmbhIfpilegtrDWw.cQwbtPkKbuvPqNcLgcikLIlJcUUG(index);
		}

		internal object GetCompoundElementSpecialGlyph(int index)
		{
			if (!ReInput.isReady || !GlyphManager.isEnabled || xhjxeOAklgPOOUStIbmvybixlXeO == null || AkpSrjyTekZcGBctfJdCYVfElrxR == null)
			{
				return null;
			}
			return AkpSrjyTekZcGBctfJdCYVfElrxR.zucaHsRbQvAxizbSaHWafpJbdPgD(index);
		}

		internal string GetCompoundElementSpecialFinalGlyphKey(int index)
		{
			if (!ReInput.isReady || !GlyphManager.isEnabled || xhjxeOAklgPOOUStIbmvybixlXeO == null || AkpSrjyTekZcGBctfJdCYVfElrxR == null)
			{
				return null;
			}
			return AkpSrjyTekZcGBctfJdCYVfElrxR.voVHhOzLXBavqlBPsHiFgdoRxwhRA(index);
		}

		string IControllerElementIdentifierCommon_Internal.GetSpecialElementNonLocalizedName(int index)
		{
			if (xhjxeOAklgPOOUStIbmvybixlXeO == null || (uint)index >= (uint)xhjxeOAklgPOOUStIbmvybixlXeO.Count)
			{
				return null;
			}
			return xhjxeOAklgPOOUStIbmvybixlXeO[index].dhyDVGgNxclfObYLctzGtUBWpPWgA;
		}

		string IControllerElementIdentifierCommon_Internal.GetSpecialElementKey(int index)
		{
			if (xhjxeOAklgPOOUStIbmvybixlXeO == null || (uint)index >= (uint)xhjxeOAklgPOOUStIbmvybixlXeO.Count)
			{
				return null;
			}
			return xhjxeOAklgPOOUStIbmvybixlXeO[index].fkexPZTBmGFRyugrYmvZTKKdTdsW;
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
			if (P_0.xhjxeOAklgPOOUStIbmvybixlXeO != null)
			{
				int count = P_0.xhjxeOAklgPOOUStIbmvybixlXeO.Count;
				xhjxeOAklgPOOUStIbmvybixlXeO = new List<IyllqWsRfoGwkXzJufBFABSMmZVl>(count);
				for (int i = 0; i < count; i++)
				{
					if (P_0.xhjxeOAklgPOOUStIbmvybixlXeO[i] != null)
					{
						xhjxeOAklgPOOUStIbmvybixlXeO.Add(new IyllqWsRfoGwkXzJufBFABSMmZVl(P_0.xhjxeOAklgPOOUStIbmvybixlXeO[i]));
					}
				}
			}
			qYRHQxdenKrSXDYvcLqpsnjhnbPH = P_0.qYRHQxdenKrSXDYvcLqpsnjhnbPH;
			GINFZOEhjkOjNtMZSqURUkXgjepn = P_0.GINFZOEhjkOjNtMZSqURUkXgjepn;
		}

		internal ControllerElementIdentifier(JJdeZvdjnivmGnZMnwtOMfIBzcAP P_0)
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

		private void TBCZJNdsXFeXZZYNXYManmsZlGTb()
		{
			if (cZUgeYkyiAZloMNHRBoTnOtWnewnA)
			{
				throw new Exception("The object is marked readonly and you are trying to modify its values.");
			}
		}

		internal void FinishRuntimeSetup(DeviceLocalizationInfo deviceLocalizationInfo, ControllerType controllerType)
		{
			GINFZOEhjkOjNtMZSqURUkXgjepn = controllerType;
			ToElementNameLocalizerTypes(_elementType, _compoundElementType, out var resultElementType, out var resultCompoundElementType);
			int num = jjEiJGkdrKfqxJAsceTeoFkgoNMlA.zIFHYKIYFbwXaLMpuqkDbbnkpdiD(resultElementType, resultCompoundElementType);
			if (num > 0)
			{
				xhjxeOAklgPOOUStIbmvybixlXeO = new List<IyllqWsRfoGwkXzJufBFABSMmZVl>(num);
				for (int i = 0; i < num; i++)
				{
					xhjxeOAklgPOOUStIbmvybixlXeO.Add(new IyllqWsRfoGwkXzJufBFABSMmZVl());
				}
			}
			JOKjcsRpMdeGFEkfCbZcFsAlcVab = deviceLocalizationInfo;
			unGFreBvBnqyPadWWGXKdQaGBPfI = FmsHxmaJbvwpZaWikICOnWlHsjYj.SWANMvtGIoEVLQRCPyMGXqaKwTqc(this, QLJeQbfdLmqMVbochivdTMoyxWKEA.iRETFsuAFEzCDUHYZJdFtcPTnoyo(controllerType), resultElementType, resultCompoundElementType, _id, deviceLocalizationInfo);
			hMyACjlgnQjcuwNzfsCSHcwuqtzx = anLAKzLoHfdVthYCyIIfImKKsYrkA.uGRHWLJHVPGVWXMjfOnZTJkHFOqGA(this, QLJeQbfdLmqMVbochivdTMoyxWKEA.iRETFsuAFEzCDUHYZJdFtcPTnoyo(controllerType), resultElementType, resultCompoundElementType, _id, deviceLocalizationInfo);
			if (_elementType == ControllerElementType.CompoundElement)
			{
				eUcWEnjxcngagmbhIfpilegtrDWw = kcVtlLkxxcCGEkDbOioGZBSsqBKy.BfmaPgSNOogkaBtkuIBFMEIqNWlEA(this, QLJeQbfdLmqMVbochivdTMoyxWKEA.iRETFsuAFEzCDUHYZJdFtcPTnoyo(controllerType), resultElementType, resultCompoundElementType, _id, deviceLocalizationInfo);
				AkpSrjyTekZcGBctfJdCYVfElrxR = eIDqhOHBKXbluRZOZweLzCDOHOcz.kbVlCoNvXwuhPbfMGBbkeFYMpwHGb(this, QLJeQbfdLmqMVbochivdTMoyxWKEA.iRETFsuAFEzCDUHYZJdFtcPTnoyo(controllerType), resultElementType, resultCompoundElementType, _id, deviceLocalizationInfo);
			}
		}

		internal static void ToElementNameLocalizerTypes(ControllerElementType type, CompoundControllerElementType compoundType, out jjEiJGkdrKfqxJAsceTeoFkgoNMlA.AqybaYFDSFEDwBRnsokwpBTdIblQ resultElementType, out jjEiJGkdrKfqxJAsceTeoFkgoNMlA.veVjxECKraSLRuRJUJeBWprfCtQDb resultCompoundElementType)
		{
			resultCompoundElementType = jjEiJGkdrKfqxJAsceTeoFkgoNMlA.veVjxECKraSLRuRJUJeBWprfCtQDb.None;
			switch (type)
			{
			case ControllerElementType.Axis:
				resultElementType = jjEiJGkdrKfqxJAsceTeoFkgoNMlA.AqybaYFDSFEDwBRnsokwpBTdIblQ.Axis;
				break;
			case ControllerElementType.Button:
				resultElementType = jjEiJGkdrKfqxJAsceTeoFkgoNMlA.AqybaYFDSFEDwBRnsokwpBTdIblQ.Button;
				break;
			case ControllerElementType.CompoundElement:
				resultElementType = jjEiJGkdrKfqxJAsceTeoFkgoNMlA.AqybaYFDSFEDwBRnsokwpBTdIblQ.CompoundElement;
				switch (compoundType)
				{
				case CompoundControllerElementType.Axis2D:
					resultCompoundElementType = jjEiJGkdrKfqxJAsceTeoFkgoNMlA.veVjxECKraSLRuRJUJeBWprfCtQDb.Axis2D;
					break;
				case CompoundControllerElementType.Hat:
					resultCompoundElementType = jjEiJGkdrKfqxJAsceTeoFkgoNMlA.veVjxECKraSLRuRJUJeBWprfCtQDb.Hat;
					break;
				case CompoundControllerElementType.DPad:
					resultCompoundElementType = jjEiJGkdrKfqxJAsceTeoFkgoNMlA.veVjxECKraSLRuRJUJeBWprfCtQDb.DPad;
					break;
				default:
					resultElementType = jjEiJGkdrKfqxJAsceTeoFkgoNMlA.AqybaYFDSFEDwBRnsokwpBTdIblQ.Unknown;
					break;
				}
				break;
			default:
				resultElementType = jjEiJGkdrKfqxJAsceTeoFkgoNMlA.AqybaYFDSFEDwBRnsokwpBTdIblQ.Unknown;
				break;
			}
		}

		string DEOLSCnqecUoFqpsMneIWaoyXVqt.GetSpecialElementNonLocalizedDescriptiveName(int index)
		{
			if (xhjxeOAklgPOOUStIbmvybixlXeO == null || index >= xhjxeOAklgPOOUStIbmvybixlXeO.Count)
			{
				return null;
			}
			return xhjxeOAklgPOOUStIbmvybixlXeO[index].dhyDVGgNxclfObYLctzGtUBWpPWgA;
		}

		void DEOLSCnqecUoFqpsMneIWaoyXVqt.SetSpecialElementNonLocalizedDescriptiveName(int index, string value)
		{
			if (xhjxeOAklgPOOUStIbmvybixlXeO != null && index < xhjxeOAklgPOOUStIbmvybixlXeO.Count)
			{
				xhjxeOAklgPOOUStIbmvybixlXeO[index].dhyDVGgNxclfObYLctzGtUBWpPWgA = value;
			}
		}

		string DEOLSCnqecUoFqpsMneIWaoyXVqt.GetSpecialElementKey(int index)
		{
			if (xhjxeOAklgPOOUStIbmvybixlXeO == null || index >= xhjxeOAklgPOOUStIbmvybixlXeO.Count)
			{
				return null;
			}
			return xhjxeOAklgPOOUStIbmvybixlXeO[index].fkexPZTBmGFRyugrYmvZTKKdTdsW;
		}

		void DEOLSCnqecUoFqpsMneIWaoyXVqt.SetSpecialElementKey(int index, string value)
		{
			if (xhjxeOAklgPOOUStIbmvybixlXeO != null && index < xhjxeOAklgPOOUStIbmvybixlXeO.Count)
			{
				xhjxeOAklgPOOUStIbmvybixlXeO[index].fkexPZTBmGFRyugrYmvZTKKdTdsW = value;
			}
		}

		string WXuKXKglhBEpgRBwkNznjqCddGcA.GetSpecialElementKey(int index)
		{
			if (xhjxeOAklgPOOUStIbmvybixlXeO == null || index >= xhjxeOAklgPOOUStIbmvybixlXeO.Count)
			{
				return null;
			}
			return xhjxeOAklgPOOUStIbmvybixlXeO[index].fkexPZTBmGFRyugrYmvZTKKdTdsW;
		}

		void WXuKXKglhBEpgRBwkNznjqCddGcA.SetSpecialElementKey(int index, string value)
		{
			if (xhjxeOAklgPOOUStIbmvybixlXeO != null && index < xhjxeOAklgPOOUStIbmvybixlXeO.Count)
			{
				xhjxeOAklgPOOUStIbmvybixlXeO[index].fkexPZTBmGFRyugrYmvZTKKdTdsW = value;
			}
		}
	}
}
