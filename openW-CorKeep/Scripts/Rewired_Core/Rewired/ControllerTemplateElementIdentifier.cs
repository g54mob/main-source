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
	public class ControllerTemplateElementIdentifier : IControllerElementIdentifierCommon_Internal, IControllerTemplateElementIdentifier, mQQEUnWrvIENJEQHDjPIUvhAyczkA, gDrCmzJNXwFvGTMAYKGQspUqeYD, sLizqcvxoCawnuvvDbUZJbhvIfejA, AIHwxHYiZBEVvZOJUhghGWlTpYhGA, wOcwbdLCJaOhasRXtoPQFUPfsCvq, jhzHtawhGfHVCurgBdqnjuHNyiNIA
	{
		[CustomClassObfuscation(renamePubIntMembers = false, renamePrivateMembers = true)]
		internal class qqQEcsLItAPNPwFEtVWbaMqPkdup
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

		internal sealed class NBdBhAlmfejjaHOpFWtPQKazPGnfA
		{
			[Serializable]
			private sealed class FKAgirFkQnGaIBCzJmXEgXIMdoIaB
			{
				public static readonly FKAgirFkQnGaIBCzJmXEgXIMdoIaB _003C_003E9 = new FKAgirFkQnGaIBCzJmXEgXIMdoIaB();

				public static Func<ControllerTemplateElementIdentifier, ControllerTemplateElementIdentifier, bool> _003C_003E9__4_0;

				internal bool zkUcDRuosmtWeXJBXetfpjFAwffv(ControllerTemplateElementIdentifier P_0, ControllerTemplateElementIdentifier P_1)
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

			private static NBdBhAlmfejjaHOpFWtPQKazPGnfA ULMCMklAHhJlUeeBsLBWfCpcmbXK;

			private readonly global::CWEsnVafmhdWXWfXjHVMLtdvyjyd<ControllerTemplateElementIdentifier> myOYJaltQrNoSdwPoVjOliVQAEWy;

			private static NBdBhAlmfejjaHOpFWtPQKazPGnfA RZMKYITuKGHQTiPShSiNoDuoQyQE
			{
				get
				{
					if (ULMCMklAHhJlUeeBsLBWfCpcmbXK != null)
					{
						return ULMCMklAHhJlUeeBsLBWfCpcmbXK;
					}
					ULMCMklAHhJlUeeBsLBWfCpcmbXK = new NBdBhAlmfejjaHOpFWtPQKazPGnfA();
					ULMCMklAHhJlUeeBsLBWfCpcmbXK.JnKlgyxjATDLTaiisarfTsnCnnxoA();
					return ULMCMklAHhJlUeeBsLBWfCpcmbXK;
				}
			}

			private NBdBhAlmfejjaHOpFWtPQKazPGnfA()
			{
				myOYJaltQrNoSdwPoVjOliVQAEWy = new global::CWEsnVafmhdWXWfXjHVMLtdvyjyd<ControllerTemplateElementIdentifier>(FKAgirFkQnGaIBCzJmXEgXIMdoIaB._003C_003E9.zkUcDRuosmtWeXJBXetfpjFAwffv);
			}

			private void JnKlgyxjATDLTaiisarfTsnCnnxoA()
			{
				ReInput.ShutDownEvent += ULMCMklAHhJlUeeBsLBWfCpcmbXK.FhUQRxQFzxHISkVxKNqskDjZmQCX;
			}

			private void FhUQRxQFzxHISkVxKNqskDjZmQCX()
			{
				if (ULMCMklAHhJlUeeBsLBWfCpcmbXK == this)
				{
					ULMCMklAHhJlUeeBsLBWfCpcmbXK = null;
				}
				ReInput.ShutDownEvent -= FhUQRxQFzxHISkVxKNqskDjZmQCX;
			}

			public static ControllerTemplateElementIdentifier JoQFEZjXJWKThXVmYNCEVRmcpynq(DeviceLocalizationInfo P_0, ControllerTemplateElementIdentifier P_1)
			{
				return RZMKYITuKGHQTiPShSiNoDuoQyQE.myOYJaltQrNoSdwPoVjOliVQAEWy.zIxKqErNejIXOzgHuQwaUJUUfHkH(P_0.hash, P_1);
			}

			public static bool iHDzshrKpuwRpELINjgmmUfSimNl(DeviceLocalizationInfo P_0, ControllerTemplateElementIdentifier P_1, out ControllerTemplateElementIdentifier P_2)
			{
				return RZMKYITuKGHQTiPShSiNoDuoQyQE.myOYJaltQrNoSdwPoVjOliVQAEWy.XFaGTtCzTwdlJVAzMnkTTCEPSjPB(P_0.hash, P_1, out P_2);
			}

			public static void jEvfKpEVoXJuScPDJCbeOYUiQTOQb(DeviceLocalizationInfo P_0, ControllerTemplateElementIdentifier P_1)
			{
				RZMKYITuKGHQTiPShSiNoDuoQyQE.myOYJaltQrNoSdwPoVjOliVQAEWy.gjcCongZfDTPVoqTsiJgeVhLREbdb(P_0.hash, P_1);
			}
		}

		private class HOXDjWXTvOOmDMHAEqCveqplBnaaA
		{
			[SerializeField]
			private string dsyeLqgqWmmSDWNaFMxHPKjhZHGvA;

			[SerializeField]
			private string EFyNpaQePATsQAlsTTfczTACBmGA;

			public string tBbtFsPbyYhnOlBkBXMgdjLetYed
			{
				get
				{
					return dsyeLqgqWmmSDWNaFMxHPKjhZHGvA;
				}
				set
				{
					dsyeLqgqWmmSDWNaFMxHPKjhZHGvA = text;
				}
			}

			public string UQlQaMpnYsKunKhgoHNwQYDvsPrV
			{
				get
				{
					return EFyNpaQePATsQAlsTTfczTACBmGA;
				}
				set
				{
					EFyNpaQePATsQAlsTTfczTACBmGA = eFyNpaQePATsQAlsTTfczTACBmGA;
				}
			}

			public HOXDjWXTvOOmDMHAEqCveqplBnaaA()
			{
			}

			public HOXDjWXTvOOmDMHAEqCveqplBnaaA(HOXDjWXTvOOmDMHAEqCveqplBnaaA P_0)
			{
				dsyeLqgqWmmSDWNaFMxHPKjhZHGvA = P_0.dsyeLqgqWmmSDWNaFMxHPKjhZHGvA;
				EFyNpaQePATsQAlsTTfczTACBmGA = P_0.EFyNpaQePATsQAlsTTfczTACBmGA;
			}
		}

		private const string pEbNzRQEcHXToUPYTOkRoVIwdKQG = "controller/template";

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
		private mbAaHTOiYxhnyoaJRfjMoaCGrCBj VnXdPHAfrKIflfgLVsIXKGxMrKHhA;

		[NonSerialized]
		private BLzCsuUSxuHNlyOBbPCMSbrlIPBG LrZuxsoIQWfBDkjkHIRogxUTjXIB;

		[NonSerialized]
		private XbxYllaEvMCIEbzNlnHzhuJNebc FQMUrvDqLKAnWMqAzbuRDIgGpPjj;

		[NonSerialized]
		private FDrDdMdvbLiGNNnJmNMDaukLRJtd ohxEoWURVtHwbUrNgKstbFdJetAH;

		[NonSerialized]
		private DeviceLocalizationInfo fWgZlYsomccuVKmyXlDAcRcbksbO;

		[NonSerialized]
		private int yQCYPsBYxpArKSyfuHFUNJFUnjZA;

		[NonSerialized]
		private List<HOXDjWXTvOOmDMHAEqCveqplBnaaA> DviWfLmjrNvcCrYzVMzufDebwSJX;

		int IControllerElementIdentifierCommon_Internal.id => _id;

		string IControllerElementIdentifierCommon_Internal.name
		{
			get
			{
				if (!ReInput.isReady || VnXdPHAfrKIflfgLVsIXKGxMrKHhA == null || !LocalizationManager.isEnabled)
				{
					return _name;
				}
				return VnXdPHAfrKIflfgLVsIXKGxMrKHhA.LoGZqdROKyuYHJXdnhuxPciDQjeL;
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
				if (!ReInput.isReady || VnXdPHAfrKIflfgLVsIXKGxMrKHhA == null || !LocalizationManager.isEnabled)
				{
					return _positiveName;
				}
				return VnXdPHAfrKIflfgLVsIXKGxMrKHhA.zPNcigbiryaPgXbjyaoZNShrqVUfb;
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
				if (!ReInput.isReady || VnXdPHAfrKIflfgLVsIXKGxMrKHhA == null || !LocalizationManager.isEnabled)
				{
					return _negativeName;
				}
				return VnXdPHAfrKIflfgLVsIXKGxMrKHhA.RLbUDlHGeFvGjHacKFOBoouLwnJJ;
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
				if (!ReInput.isReady || FQMUrvDqLKAnWMqAzbuRDIgGpPjj == null || !GlyphManager.isEnabled)
				{
					return null;
				}
				return FQMUrvDqLKAnWMqAzbuRDIgGpPjj.GVrZzAJiAcZtdOTSfvBJJUYlefGD;
			}
		}

		public object positiveGlyph
		{
			get
			{
				if (!ReInput.isReady || FQMUrvDqLKAnWMqAzbuRDIgGpPjj == null || !GlyphManager.isEnabled)
				{
					return null;
				}
				return FQMUrvDqLKAnWMqAzbuRDIgGpPjj.rDFxUatMbooeegVqsbQAmfdclvkb;
			}
		}

		public object negativeGlyph
		{
			get
			{
				if (!ReInput.isReady || FQMUrvDqLKAnWMqAzbuRDIgGpPjj == null || !GlyphManager.isEnabled)
				{
					return null;
				}
				return FQMUrvDqLKAnWMqAzbuRDIgGpPjj.virtdIFyIFsRliRxpxDCRdeEbxUd;
			}
		}

		private string finalGlyphKey
		{
			get
			{
				if (!ReInput.isReady || FQMUrvDqLKAnWMqAzbuRDIgGpPjj == null || !GlyphManager.isEnabled)
				{
					return null;
				}
				return FQMUrvDqLKAnWMqAzbuRDIgGpPjj.BffrlRgrmyGwIkHNgqwsEclmiqed;
			}
		}

		private string finalPositiveGlyphKey
		{
			get
			{
				if (!ReInput.isReady || FQMUrvDqLKAnWMqAzbuRDIgGpPjj == null || !GlyphManager.isEnabled)
				{
					return null;
				}
				return FQMUrvDqLKAnWMqAzbuRDIgGpPjj.NomOvFfGNzjocpHXgQVkYuGuWtOf;
			}
		}

		private string finalNegativeGlyphKey
		{
			get
			{
				if (!ReInput.isReady || FQMUrvDqLKAnWMqAzbuRDIgGpPjj == null || !GlyphManager.isEnabled)
				{
					return null;
				}
				return FQMUrvDqLKAnWMqAzbuRDIgGpPjj.KNuOvihbENmAquPLvjhhiXUexGHEA;
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
				if (ReInput.isReady && VnXdPHAfrKIflfgLVsIXKGxMrKHhA != null)
				{
					VnXdPHAfrKIflfgLVsIXKGxMrKHhA.TebLFfuNscsSdmSSCRmDmNccAdoF();
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
				if (ReInput.isReady && VnXdPHAfrKIflfgLVsIXKGxMrKHhA != null)
				{
					VnXdPHAfrKIflfgLVsIXKGxMrKHhA.gCQsiuHHoDBgyTofsxyDxbEzjwLF();
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
				if (ReInput.isReady && VnXdPHAfrKIflfgLVsIXKGxMrKHhA != null)
				{
					VnXdPHAfrKIflfgLVsIXKGxMrKHhA.VfXqdBFmbAriTEKxazHGnZJzQear();
				}
			}
		}

		public string key => _key;

		public string positiveKey => _positiveKey;

		public string negativeKey => _negativeKey;

		string IControllerElementIdentifierCommon_Internal.nonLocalizedName => nonLocalizedName;

		string IControllerElementIdentifierCommon_Internal.nonLocalizedPositiveName => nonLocalizedPositiveName;

		string IControllerElementIdentifierCommon_Internal.nonLocalizedNegativeName => nonLocalizedNegativeName;

		bool IControllerElementIdentifierCommon_Internal.isNonLocalizedPositiveNameAutoGenerated => (yQCYPsBYxpArKSyfuHFUNJFUnjZA & 2) != 0;

		bool IControllerElementIdentifierCommon_Internal.isNonLocalizedNegativeNameAutoGenerated => (yQCYPsBYxpArKSyfuHFUNJFUnjZA & 4) != 0;

		bool IControllerElementIdentifierCommon_Internal.isPositiveKeyAutoGenerated => (yQCYPsBYxpArKSyfuHFUNJFUnjZA & 8) != 0;

		bool IControllerElementIdentifierCommon_Internal.isNegativeKeyAutoGenerated => (yQCYPsBYxpArKSyfuHFUNJFUnjZA & 0x10) != 0;

		string IControllerElementIdentifierCommon_Internal.key => _key;

		string IControllerElementIdentifierCommon_Internal.positiveKey => _positiveKey;

		string IControllerElementIdentifierCommon_Internal.negativeKey => _negativeKey;

		DeviceLocalizationInfo IControllerElementIdentifierCommon_Internal.deviceLocalizationInfo => fWgZlYsomccuVKmyXlDAcRcbksbO;

		object IControllerElementIdentifierCommon_Internal.elementType => _elementType;

		bool IControllerElementIdentifierCommon_Internal.useEditorElementTypeOverride => useEditorElementTypeOverride;

		ControllerElementType IControllerElementIdentifierCommon_Internal.editorElementTypeOverride => editorElementTypeOverride;

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
				_negativeKey = value;
			}
		}

		int gDrCmzJNXwFvGTMAYKGQspUqeYD.autoGeneratedValueFlags
		{
			get
			{
				return yQCYPsBYxpArKSyfuHFUNJFUnjZA;
			}
			set
			{
				yQCYPsBYxpArKSyfuHFUNJFUnjZA = value;
			}
		}

		string AIHwxHYiZBEVvZOJUhghGWlTpYhGA.keyCategory => "controller/template";

		string AIHwxHYiZBEVvZOJUhghGWlTpYhGA.key => _key;

		int AIHwxHYiZBEVvZOJUhghGWlTpYhGA.autoGeneratedValueFlags
		{
			get
			{
				return yQCYPsBYxpArKSyfuHFUNJFUnjZA;
			}
			set
			{
				yQCYPsBYxpArKSyfuHFUNJFUnjZA = value;
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
				_negativeKey = value;
			}
		}

		internal string GetCompoundElementSpecialName(int index)
		{
			if (!ReInput.isReady || !LocalizationManager.isEnabled || DviWfLmjrNvcCrYzVMzufDebwSJX == null || LrZuxsoIQWfBDkjkHIRogxUTjXIB == null)
			{
				return string.Empty;
			}
			return LrZuxsoIQWfBDkjkHIRogxUTjXIB.VxSCVyObxksuNRtHTByuEmCYzwLj(index);
		}

		internal object GetCompoundElementSpecialGlyph(int index)
		{
			if (!ReInput.isReady || !GlyphManager.isEnabled || DviWfLmjrNvcCrYzVMzufDebwSJX == null || ohxEoWURVtHwbUrNgKstbFdJetAH == null)
			{
				return null;
			}
			return ohxEoWURVtHwbUrNgKstbFdJetAH.YzMDwLdFGfaLFbOWPBausmCwzitO(index);
		}

		string IControllerElementIdentifierCommon_Internal.GetSpecialElementNonLocalizedName(int index)
		{
			if (DviWfLmjrNvcCrYzVMzufDebwSJX == null || (uint)index >= (uint)DviWfLmjrNvcCrYzVMzufDebwSJX.Count)
			{
				return null;
			}
			return DviWfLmjrNvcCrYzVMzufDebwSJX[index].UQlQaMpnYsKunKhgoHNwQYDvsPrV;
		}

		string IControllerElementIdentifierCommon_Internal.GetSpecialElementKey(int index)
		{
			if (DviWfLmjrNvcCrYzVMzufDebwSJX == null || (uint)index >= (uint)DviWfLmjrNvcCrYzVMzufDebwSJX.Count)
			{
				return null;
			}
			return DviWfLmjrNvcCrYzVMzufDebwSJX[index].tBbtFsPbyYhnOlBkBXMgdjLetYed;
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
			if (P_0.DviWfLmjrNvcCrYzVMzufDebwSJX != null)
			{
				int count = P_0.DviWfLmjrNvcCrYzVMzufDebwSJX.Count;
				DviWfLmjrNvcCrYzVMzufDebwSJX = new List<HOXDjWXTvOOmDMHAEqCveqplBnaaA>(count);
				for (int i = 0; i < count; i++)
				{
					if (P_0.DviWfLmjrNvcCrYzVMzufDebwSJX[i] != null)
					{
						DviWfLmjrNvcCrYzVMzufDebwSJX.Add(new HOXDjWXTvOOmDMHAEqCveqplBnaaA(P_0.DviWfLmjrNvcCrYzVMzufDebwSJX[i]));
					}
				}
			}
			yQCYPsBYxpArKSyfuHFUNJFUnjZA = P_0.yQCYPsBYxpArKSyfuHFUNJFUnjZA;
		}

		internal ControllerTemplateElementIdentifier(qqQEcsLItAPNPwFEtVWbaMqPkdup P_0)
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
			ControllerElementIdentifier controllerElementIdentifier = new ControllerElementIdentifier(new ControllerElementIdentifier.ojVewQJXCyYjrtbbWsMKJotWctHeA
			{
				id = _id,
				name = _name,
				positiveName = _positiveName,
				negativeName = _negativeName,
				key = _key,
				positiveKey = _positiveKey,
				negativeKey = _negativeKey,
				elementType = nwsTruCLxjorysrNysDvPYrmMcrb.mcBSQgskPhJnocuEYpMobqXdNEjK(_elementType),
				compoundElementType = CompoundControllerElementType.Axis2D
			});
			if (ReInput.isReady && fWgZlYsomccuVKmyXlDAcRcbksbO != null && hardwareControllerMap != null)
			{
				DeviceLocalizationInfo deviceLocalizationInfo = new DeviceLocalizationInfo(hardwareControllerMap.controllerType, false, hardwareControllerMap.typeGuid, new List<string> { hardwareControllerMap.typeKey }, null);
				deviceLocalizationInfo.FinishRuntimeSetup();
				controllerElementIdentifier.FinishRuntimeSetup(deviceLocalizationInfo, hardwareControllerMap.controllerType);
			}
			return controllerElementIdentifier;
		}

		internal void FinishRuntimeSetup(DeviceLocalizationInfo deviceLocalizationInfo)
		{
			cZclFXTNlDHseIyDXBnomltBgPaq(_elementType, out var fyQKArxdnRgBFXnCTGFifmqgwogRA, out var oUxgQpuZIuwKyJEylNPLslOwBwNAA);
			int num = AomZkhATSIadYOOLVfcgOnNtMQBs.YJjoDvcTlhdCNHOpHXbTafYtikvO(fyQKArxdnRgBFXnCTGFifmqgwogRA, oUxgQpuZIuwKyJEylNPLslOwBwNAA);
			if (num > 0)
			{
				DviWfLmjrNvcCrYzVMzufDebwSJX = new List<HOXDjWXTvOOmDMHAEqCveqplBnaaA>(num);
				for (int i = 0; i < num; i++)
				{
					DviWfLmjrNvcCrYzVMzufDebwSJX.Add(new HOXDjWXTvOOmDMHAEqCveqplBnaaA());
				}
			}
			fWgZlYsomccuVKmyXlDAcRcbksbO = deviceLocalizationInfo;
			if (VnXdPHAfrKIflfgLVsIXKGxMrKHhA == null)
			{
				VnXdPHAfrKIflfgLVsIXKGxMrKHhA = mbAaHTOiYxhnyoaJRfjMoaCGrCBj.xwgcpxXUdALuiIPonXTWOjFDjMSg(this, hhwQItrOtauBvPHQAFLgRDRQAhcP.ControllerTemplate, fyQKArxdnRgBFXnCTGFifmqgwogRA, oUxgQpuZIuwKyJEylNPLslOwBwNAA, _id, deviceLocalizationInfo);
			}
			if (FQMUrvDqLKAnWMqAzbuRDIgGpPjj == null)
			{
				FQMUrvDqLKAnWMqAzbuRDIgGpPjj = XbxYllaEvMCIEbzNlnHzhuJNebc.HbkcgzPoLzWzFyCSASXEhDGeXxbA(this, hhwQItrOtauBvPHQAFLgRDRQAhcP.ControllerTemplate, fyQKArxdnRgBFXnCTGFifmqgwogRA, oUxgQpuZIuwKyJEylNPLslOwBwNAA, _id, deviceLocalizationInfo);
			}
			if (fyQKArxdnRgBFXnCTGFifmqgwogRA == AomZkhATSIadYOOLVfcgOnNtMQBs.fyQKArxdnRgBFXnCTGFifmqgwogRA.CompoundElement)
			{
				LrZuxsoIQWfBDkjkHIRogxUTjXIB = BLzCsuUSxuHNlyOBbPCMSbrlIPBG.gIKoHCujqwzPDpPLMgDmBxpPValA(this, hhwQItrOtauBvPHQAFLgRDRQAhcP.ControllerTemplate, fyQKArxdnRgBFXnCTGFifmqgwogRA, oUxgQpuZIuwKyJEylNPLslOwBwNAA, _id, deviceLocalizationInfo);
				ohxEoWURVtHwbUrNgKstbFdJetAH = FDrDdMdvbLiGNNnJmNMDaukLRJtd.NTxedJhSssXgsrkxdKksYDjHddOS(this, hhwQItrOtauBvPHQAFLgRDRQAhcP.ControllerTemplate, fyQKArxdnRgBFXnCTGFifmqgwogRA, oUxgQpuZIuwKyJEylNPLslOwBwNAA, _id, deviceLocalizationInfo);
			}
		}

		string wOcwbdLCJaOhasRXtoPQFUPfsCvq.GetSpecialElementNonLocalizedDescriptiveName(int index)
		{
			if (DviWfLmjrNvcCrYzVMzufDebwSJX == null || index >= DviWfLmjrNvcCrYzVMzufDebwSJX.Count)
			{
				return null;
			}
			return DviWfLmjrNvcCrYzVMzufDebwSJX[index].UQlQaMpnYsKunKhgoHNwQYDvsPrV;
		}

		void wOcwbdLCJaOhasRXtoPQFUPfsCvq.SetSpecialElementNonLocalizedDescriptiveName(int index, string value)
		{
			if (DviWfLmjrNvcCrYzVMzufDebwSJX != null && index < DviWfLmjrNvcCrYzVMzufDebwSJX.Count)
			{
				DviWfLmjrNvcCrYzVMzufDebwSJX[index].UQlQaMpnYsKunKhgoHNwQYDvsPrV = value;
			}
		}

		string wOcwbdLCJaOhasRXtoPQFUPfsCvq.GetSpecialElementKey(int index)
		{
			if (DviWfLmjrNvcCrYzVMzufDebwSJX == null || index >= DviWfLmjrNvcCrYzVMzufDebwSJX.Count)
			{
				return null;
			}
			return DviWfLmjrNvcCrYzVMzufDebwSJX[index].tBbtFsPbyYhnOlBkBXMgdjLetYed;
		}

		void wOcwbdLCJaOhasRXtoPQFUPfsCvq.SetSpecialElementKey(int index, string value)
		{
			if (DviWfLmjrNvcCrYzVMzufDebwSJX != null && index < DviWfLmjrNvcCrYzVMzufDebwSJX.Count)
			{
				DviWfLmjrNvcCrYzVMzufDebwSJX[index].tBbtFsPbyYhnOlBkBXMgdjLetYed = value;
			}
		}

		string jhzHtawhGfHVCurgBdqnjuHNyiNIA.GetSpecialElementKey(int index)
		{
			if (DviWfLmjrNvcCrYzVMzufDebwSJX == null || index >= DviWfLmjrNvcCrYzVMzufDebwSJX.Count)
			{
				return null;
			}
			return DviWfLmjrNvcCrYzVMzufDebwSJX[index].tBbtFsPbyYhnOlBkBXMgdjLetYed;
		}

		void jhzHtawhGfHVCurgBdqnjuHNyiNIA.SetSpecialElementKey(int index, string value)
		{
			if (DviWfLmjrNvcCrYzVMzufDebwSJX != null && index < DviWfLmjrNvcCrYzVMzufDebwSJX.Count)
			{
				DviWfLmjrNvcCrYzVMzufDebwSJX[index].tBbtFsPbyYhnOlBkBXMgdjLetYed = value;
			}
		}

		private static void cZclFXTNlDHseIyDXBnomltBgPaq(ControllerTemplateElementType P_0, out AomZkhATSIadYOOLVfcgOnNtMQBs.fyQKArxdnRgBFXnCTGFifmqgwogRA P_1, out AomZkhATSIadYOOLVfcgOnNtMQBs.OUxgQpuZIuwKyJEylNPLslOwBwNAA P_2)
		{
			P_2 = AomZkhATSIadYOOLVfcgOnNtMQBs.OUxgQpuZIuwKyJEylNPLslOwBwNAA.None;
			switch (P_0)
			{
			case ControllerTemplateElementType.Axis:
				P_1 = AomZkhATSIadYOOLVfcgOnNtMQBs.fyQKArxdnRgBFXnCTGFifmqgwogRA.Axis;
				break;
			case ControllerTemplateElementType.Button:
				P_1 = AomZkhATSIadYOOLVfcgOnNtMQBs.fyQKArxdnRgBFXnCTGFifmqgwogRA.Button;
				break;
			case ControllerTemplateElementType.Hat:
				P_1 = AomZkhATSIadYOOLVfcgOnNtMQBs.fyQKArxdnRgBFXnCTGFifmqgwogRA.CompoundElement;
				P_2 = AomZkhATSIadYOOLVfcgOnNtMQBs.OUxgQpuZIuwKyJEylNPLslOwBwNAA.Hat;
				break;
			case ControllerTemplateElementType.DPad:
				P_1 = AomZkhATSIadYOOLVfcgOnNtMQBs.fyQKArxdnRgBFXnCTGFifmqgwogRA.CompoundElement;
				P_2 = AomZkhATSIadYOOLVfcgOnNtMQBs.OUxgQpuZIuwKyJEylNPLslOwBwNAA.DPad;
				break;
			case ControllerTemplateElementType.ThumbStick:
				P_1 = AomZkhATSIadYOOLVfcgOnNtMQBs.fyQKArxdnRgBFXnCTGFifmqgwogRA.CompoundElement;
				break;
			case ControllerTemplateElementType.Yoke:
				P_1 = AomZkhATSIadYOOLVfcgOnNtMQBs.fyQKArxdnRgBFXnCTGFifmqgwogRA.Unknown;
				break;
			case ControllerTemplateElementType.Throttle:
				P_1 = AomZkhATSIadYOOLVfcgOnNtMQBs.fyQKArxdnRgBFXnCTGFifmqgwogRA.Unknown;
				break;
			case ControllerTemplateElementType.Stick:
				P_1 = AomZkhATSIadYOOLVfcgOnNtMQBs.fyQKArxdnRgBFXnCTGFifmqgwogRA.CompoundElement;
				P_2 = AomZkhATSIadYOOLVfcgOnNtMQBs.OUxgQpuZIuwKyJEylNPLslOwBwNAA.Stick;
				break;
			case ControllerTemplateElementType.Stick6D:
				P_1 = AomZkhATSIadYOOLVfcgOnNtMQBs.fyQKArxdnRgBFXnCTGFifmqgwogRA.CompoundElement;
				P_2 = AomZkhATSIadYOOLVfcgOnNtMQBs.OUxgQpuZIuwKyJEylNPLslOwBwNAA.Stick6D;
				break;
			default:
				P_1 = AomZkhATSIadYOOLVfcgOnNtMQBs.fyQKArxdnRgBFXnCTGFifmqgwogRA.Unknown;
				break;
			}
		}
	}
}
