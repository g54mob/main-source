using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Rewired.Interfaces;
using UnityEngine;

namespace Rewired.Data.Mapping
{
	public sealed class HardwareJoystickTemplateMap : HardwareControllerTemplateMap, IHardwareControllerMap, IHardwareControllerTemplateMap, IHardwareControllerMap_Internal, IHardwareControllerTemplateMap_Internal
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

			T IControllerTemplateMapSpecialElement_Internal.GetMapping<T>()
			{
				return null;
			}
		}

		private sealed class JBwrrtuQbYaoEJQddtVMlsrfSoSR : IDisposable, IEnumerable, IEnumerator, IEnumerable<IControllerElementIdentifierCommon_Internal>, IEnumerator<IControllerElementIdentifierCommon_Internal>
		{
			private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

			private IControllerElementIdentifierCommon_Internal USjDTWbJtWhEBdYYYfLUglTcnnGrA;

			private int nOonfdwpqEUEASbbWObCvjhlCTmP;

			public HardwareJoystickTemplateMap GZXxEqHwrHYIyUJtInpLwgTukJaY;

			private int aWiJmJHWwqZlYdpLUbqxiFaJSHeg;

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
			public JBwrrtuQbYaoEJQddtVMlsrfSoSR(int P_0)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
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
		}

		private sealed class CFZeqAKKWdmcWaoTAGjrgjEhoJCZD : IDisposable, IEnumerable, IEnumerator, IEnumerable<ControllerTemplateElementIdentifier>, IEnumerator<ControllerTemplateElementIdentifier>
		{
			private int GwbUsvLqBorYvZEWvPDttSzVhFNo;

			private ControllerTemplateElementIdentifier USjDTWbJtWhEBdYYYfLUglTcnnGrA;

			private int nOonfdwpqEUEASbbWObCvjhlCTmP;

			public HardwareJoystickTemplateMap GZXxEqHwrHYIyUJtInpLwgTukJaY;

			private int aWiJmJHWwqZlYdpLUbqxiFaJSHeg;

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
			public CFZeqAKKWdmcWaoTAGjrgjEhoJCZD(int P_0)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
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
		}

		[CustomObfuscation]
		[SerializeField]
		private string controllerName;

		[SerializeField]
		[CustomObfuscation]
		private string description;

		[CustomObfuscation]
		[SerializeField]
		private string templateGuid;

		[SerializeField]
		[CustomObfuscation]
		private string className;

		[CustomObfuscation]
		[SerializeField]
		private ControllerTemplateElementIdentifier_Editor[] elementIdentifiers;

		[SerializeField]
		[CustomObfuscation]
		private List<Entry> joysticks;

		[SerializeField]
		[CustomObfuscation]
		private SpecialElementEntry[] specialElements;

		[SerializeField]
		[CustomObfuscation]
		private int elementIdentifierIdCounter;

		[CustomObfuscation]
		[SerializeField]
		private int joystickIdCounter;

		public override Guid Guid => default(Guid);

		public string ControllerName => null;

		public string ClassName => null;

		public IEnumerable<ControllerTemplateElementIdentifier> ElementIdentifiers => null;

		IEnumerable<IControllerElementIdentifierCommon_Internal> IHardwareControllerMap_Internal.ElementIdentifiers => null;

		string IHardwareControllerTemplateMap_Internal.name => null;

		Guid IHardwareControllerTemplateMap_Internal.typeGuid => default(Guid);

		[CustomObfuscation]
		public ControllerTemplateElementIdentifier GetElementIdentifier(int id)
		{
			return null;
		}

		[CustomObfuscation]
		public bool ContainsElementIdentifier(int id)
		{
			return false;
		}

		[CustomObfuscation]
		public string[] GetElementIdentifierNames()
		{
			return null;
		}

		[CustomObfuscation]
		public int[] GetElementIdentifierIds()
		{
			return null;
		}

		[CustomObfuscation]
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

		internal bool SiLXRhvlGKjByHOMkjlXFMPAdHdyA(ControllerMap_Editor P_0, HardwareJoystickMap P_1, Guid P_2, out string P_3)
		{
			P_3 = null;
			return false;
		}

		internal ControllerTemplateElementIdentifier MOzOneanqiyzkVPGAQxKYGZLesqE(Guid P_0, int P_1)
		{
			return null;
		}

		[CustomObfuscation]
		internal SpecialElementEntry[] GetSpecialElementsOrig()
		{
			return null;
		}

		private Entry USCGiuQyHUkFhIyPnQnjKGLOTfzD(Guid P_0)
		{
			return null;
		}

		private int vtilMtCFdxmSvZzdKnxbIIpsBPqe(int P_0)
		{
			return 0;
		}

		IControllerElementIdentifierCommon_Internal IHardwareControllerMap_Internal.GetElementIdentifier(int id)
		{
			return null;
		}

		int IHardwareControllerTemplateMap_Internal.GetElementIdentifierCount()
		{
			return 0;
		}

		IControllerTemplateElementIdentifier IHardwareControllerTemplateMap_Internal.GetTemplateElementIdentifier(int index)
		{
			return null;
		}

		IControllerTemplateElementIdentifier IHardwareControllerTemplateMap_Internal.GetTemplateElementIdentifierById(int elementIdentifierId)
		{
			return null;
		}

		IControllerTemplateMapSpecialElement_Internal IHardwareControllerTemplateMap_Internal.GetSpecialTemplateElementByElementIdentifierId(int id)
		{
			return null;
		}

		KpZHreySesbtLKuRdoZrwgpLSyTA IHardwareControllerTemplateMap_Internal.GetAxisTarget(Controller controller, int elementIdentifierId)
		{
			return null;
		}

		KpZHreySesbtLKuRdoZrwgpLSyTA IHardwareControllerTemplateMap_Internal.GetButtonTarget(Controller controller, int elementIdentifierId)
		{
			return null;
		}
	}
}
