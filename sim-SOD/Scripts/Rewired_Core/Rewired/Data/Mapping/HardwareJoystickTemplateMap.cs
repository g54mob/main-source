using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Rewired.Interfaces;
using UnityEngine;

namespace Rewired.Data.Mapping
{
	public sealed class HardwareJoystickTemplateMap : HardwareControllerTemplateMap, IHardwareControllerMap, IHardwareControllerMap_Internal, IHardwareControllerTemplateMap, IHardwareControllerTemplateMap_Internal
	{
		[Serializable]
		public sealed class Entry
		{
			public int id;

			public string name;

			public string joystickGuid;

			public string fileGuid;

			public List<ElementIdentifierMap> elementIdentifierMappings;

			public Guid JoystickGuid => default(Guid);

			public int GetJoystickElementId(int templateElementId)
			{
				return 0;
			}

			public int GetTemplateElementId(int joystickElementId)
			{
				return 0;
			}

			public ElementIdentifierMap GetElementIdentifierMap(int templateId)
			{
				return null;
			}

			public void GetElementIdentifierMaps(int templateId, List<ElementIdentifierMap> results)
			{
			}
		}

		[Serializable]
		public sealed class ElementIdentifierMap
		{
			public int templateId;

			public int joystickId;

			public int joystickId2;

			public bool splitAxis;
		}

		[Serializable]
		public sealed class SpecialElementEntry : IControllerTemplateMapSpecialElement_Internal
		{
			public int elementIdentifierId;

			public string data;

			private T DWTPQPPPbOeYdcyeqEBiiZAcVAKd<T>() where T : ControllerTemplateSpecialElementMapping
			{
				return null;
			}

			T IControllerTemplateMapSpecialElement_Internal.GetMapping<T>()
			{
				//ILSpy generated this explicit interface implementation from .override directive in DWTPQPPPbOeYdcyeqEBiiZAcVAKd
				return this.DWTPQPPPbOeYdcyeqEBiiZAcVAKd<T>();
			}
		}

		private sealed class vHHCQXeFCYGOCAEjYfGAhFDalee : IDisposable, IEnumerator, IEnumerable, IEnumerable<ControllerTemplateElementIdentifier>, IEnumerator<ControllerTemplateElementIdentifier>
		{
			private ControllerTemplateElementIdentifier YDjDCBVmlkHQnKMyHwfXVborvEXS;

			private int KjzQtaNmLSFADNQocZpcbdUSqwW;

			private int heukQwubtgAAwETRDLwZfpUeIur;

			public HardwareJoystickTemplateMap OLVemnFdjzUkQSlFFFIOsrknazt;

			public int hkjZwEtRcbNEZzlBIpvzpzhYPxY;

			ControllerTemplateElementIdentifier IEnumerator<ControllerTemplateElementIdentifier>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			IEnumerator<ControllerTemplateElementIdentifier> IEnumerable<ControllerTemplateElementIdentifier>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}

			void IDisposable.Dispose()
			{
			}

			[DebuggerHidden]
			public vHHCQXeFCYGOCAEjYfGAhFDalee(int _003C_003E1__state)
			{
			}
		}

		private sealed class xLSbdemKtXtOkCyUcgdXjEgEUdb : IDisposable, IEnumerator, IEnumerable, IEnumerable<IControllerElementIdentifierCommon_Internal>, IEnumerator<IControllerElementIdentifierCommon_Internal>
		{
			private IControllerElementIdentifierCommon_Internal YDjDCBVmlkHQnKMyHwfXVborvEXS;

			private int KjzQtaNmLSFADNQocZpcbdUSqwW;

			private int heukQwubtgAAwETRDLwZfpUeIur;

			public HardwareJoystickTemplateMap OLVemnFdjzUkQSlFFFIOsrknazt;

			public int tfQtTUubcUbEoIRQLlKQHYRKYGD;

			IControllerElementIdentifierCommon_Internal IEnumerator<IControllerElementIdentifierCommon_Internal>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			IEnumerator<IControllerElementIdentifierCommon_Internal> IEnumerable<IControllerElementIdentifierCommon_Internal>.GetEnumerator()
			{
				return null;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return null;
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}

			void IDisposable.Dispose()
			{
			}

			[DebuggerHidden]
			public xLSbdemKtXtOkCyUcgdXjEgEUdb(int _003C_003E1__state)
			{
			}
		}

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string controllerName;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string description;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private string templateGuid;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private string className;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private ControllerTemplateElementIdentifier_Editor[] elementIdentifiers;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<Entry> joysticks;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private SpecialElementEntry[] specialElements;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private int elementIdentifierIdCounter;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int joystickIdCounter;

		public override Guid Guid => default(Guid);

		public string ControllerName => null;

		public string ClassName => null;

		public IEnumerable<ControllerTemplateElementIdentifier> ElementIdentifiers => null;

		IEnumerable<IControllerElementIdentifierCommon_Internal> IHardwareControllerMap_Internal.ElementIdentifiers => null;

		string IHardwareControllerTemplateMap_Internal.name => null;

		Guid IHardwareControllerTemplateMap_Internal.typeGuid => default(Guid);

		[CustomObfuscation(rename = false)]
		public ControllerTemplateElementIdentifier GetElementIdentifier(int id)
		{
			return null;
		}

		[CustomObfuscation(rename = false)]
		public bool ContainsElementIdentifier(int id)
		{
			return false;
		}

		[CustomObfuscation(rename = false)]
		public string[] GetElementIdentifierNames()
		{
			return null;
		}

		[CustomObfuscation(rename = false)]
		public int[] GetElementIdentifierIds()
		{
			return null;
		}

		[CustomObfuscation(rename = false)]
		internal string[] GetElementIdentifierScriptingNames(bool useAlternate)
		{
			return null;
		}

		public int GetMappableElementIdentifierInfo(out string[] names, out int[] ids)
		{
			names = null;
			ids = null;
			return 0;
		}

		public int GetNonMappableElementIdentifierInfo(out string[] names, out int[] ids)
		{
			names = null;
			ids = null;
			return 0;
		}

		public string[] GetJoystickNames()
		{
			return null;
		}

		public int[] GetJoystickIds()
		{
			return null;
		}

		public Guid GetJoystickGuid(int joystickId)
		{
			return default(Guid);
		}

		public int GetJoystickId(Guid guid)
		{
			return 0;
		}

		public string GetJoystickFileGuidString(int joystickId)
		{
			return null;
		}

		internal bool YUZmYcfOEqlZQDEanqDOInmPemaa(ControllerMap_Editor P_0, HardwareJoystickMap P_1, Guid P_2, out string P_3)
		{
			P_3 = null;
			return false;
		}

		internal ControllerTemplateElementIdentifier IDtHazkbrOuTQZGpNFoZKEjQNBh(Guid P_0, int P_1)
		{
			return null;
		}

		[CustomObfuscation(rename = false)]
		internal SpecialElementEntry[] GetSpecialElementsOrig()
		{
			return null;
		}

		private Entry ShIDuhCdewisJUzYcFcsCUpNqke(Guid P_0)
		{
			return null;
		}

		private int bicuzmSWZDagLPjRRRRaQCtfkRx(int P_0)
		{
			return 0;
		}

		private IControllerElementIdentifierCommon_Internal RAafLTkyIfJYEVnMRdTQkoTieBqK(int P_0)
		{
			return null;
		}

		IControllerElementIdentifierCommon_Internal IHardwareControllerMap_Internal.GetElementIdentifier(int P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in RAafLTkyIfJYEVnMRdTQkoTieBqK
			return this.RAafLTkyIfJYEVnMRdTQkoTieBqK(P_0);
		}

		private int phwjWIdmXCiVOoPTvsmZcIgtsNH()
		{
			return 0;
		}

		int IHardwareControllerTemplateMap_Internal.GetElementIdentifierCount()
		{
			//ILSpy generated this explicit interface implementation from .override directive in phwjWIdmXCiVOoPTvsmZcIgtsNH
			return this.phwjWIdmXCiVOoPTvsmZcIgtsNH();
		}

		private IControllerTemplateElementIdentifier ekYWsVZPPOhyPlXZiSYHRrtMjPJ(int P_0)
		{
			return null;
		}

		IControllerTemplateElementIdentifier IHardwareControllerTemplateMap_Internal.GetTemplateElementIdentifier(int P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in ekYWsVZPPOhyPlXZiSYHRrtMjPJ
			return this.ekYWsVZPPOhyPlXZiSYHRrtMjPJ(P_0);
		}

		private IControllerTemplateElementIdentifier VGgpeaZQfdgYxadXeEdXdgCQhYGD(int P_0)
		{
			return null;
		}

		IControllerTemplateElementIdentifier IHardwareControllerTemplateMap_Internal.GetTemplateElementIdentifierById(int P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in VGgpeaZQfdgYxadXeEdXdgCQhYGD
			return this.VGgpeaZQfdgYxadXeEdXdgCQhYGD(P_0);
		}

		private IControllerTemplateMapSpecialElement_Internal yJwuyMxckPPXkvGzvsWBAuEtNs(int P_0)
		{
			return null;
		}

		IControllerTemplateMapSpecialElement_Internal IHardwareControllerTemplateMap_Internal.GetSpecialTemplateElementByElementIdentifierId(int P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in yJwuyMxckPPXkvGzvsWBAuEtNs
			return this.yJwuyMxckPPXkvGzvsWBAuEtNs(P_0);
		}

		private WEjbSeiFAGihJGQWKjQAhkLgezjp KZoKjixPldeDPvrgyoMijDkzcsJA(Controller P_0, int P_1)
		{
			return null;
		}

		WEjbSeiFAGihJGQWKjQAhkLgezjp IHardwareControllerTemplateMap_Internal.GetAxisTarget(Controller P_0, int P_1)
		{
			//ILSpy generated this explicit interface implementation from .override directive in KZoKjixPldeDPvrgyoMijDkzcsJA
			return this.KZoKjixPldeDPvrgyoMijDkzcsJA(P_0, P_1);
		}

		private WEjbSeiFAGihJGQWKjQAhkLgezjp jmnnEEXaHEyjdONkYcbcBRXSYK(Controller P_0, int P_1)
		{
			return null;
		}

		WEjbSeiFAGihJGQWKjQAhkLgezjp IHardwareControllerTemplateMap_Internal.GetButtonTarget(Controller P_0, int P_1)
		{
			//ILSpy generated this explicit interface implementation from .override directive in jmnnEEXaHEyjdONkYcbcBRXSYK
			return this.jmnnEEXaHEyjdONkYcbcBRXSYK(P_0, P_1);
		}
	}
}
