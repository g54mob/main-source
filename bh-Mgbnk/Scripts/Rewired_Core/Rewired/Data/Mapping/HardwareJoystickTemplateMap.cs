using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Rewired.Interfaces;
using Rewired.Utils.Attributes;
using UnityEngine;

namespace Rewired.Data.Mapping
{
	public sealed class HardwareJoystickTemplateMap : HardwareControllerTemplateMap, IHardwareControllerTemplateMap, IHardwareControllerTemplateMap_Internal, IHardwareControllerMap, IHardwareControllerMap_Internal
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

			[Preserve]
			public Entry()
			{
			}

			internal Entry(Entry P_0)
			{
			}

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

			[Preserve]
			public ElementIdentifierMap()
			{
			}

			internal ElementIdentifierMap(ElementIdentifierMap P_0)
			{
			}
		}

		[Serializable]
		public sealed class SpecialElementEntry : IControllerTemplateMapSpecialElement_Internal
		{
			public int elementIdentifierId;

			public string data;

			[Preserve]
			public SpecialElementEntry()
			{
			}

			internal SpecialElementEntry(SpecialElementEntry P_0)
			{
			}

			T IControllerTemplateMapSpecialElement_Internal.GetMapping<T>()
			{
				return null;
			}
		}

		private sealed class uwWmBRwUPUvcvNsQdetkTuFUwufx : IEnumerable<IControllerElementIdentifierCommon_Internal>, IEnumerable, IEnumerator<IControllerElementIdentifierCommon_Internal>, IEnumerator, IDisposable
		{
			private int jKjFyujWLbRDsdoRdNZOVNNRFebq;

			private IControllerElementIdentifierCommon_Internal FInnRUoOIJTFrQizdbDbkWxsMzJdA;

			private int xCdsdKSpVeCMHBGEIpjYiWypGVyu;

			public HardwareJoystickTemplateMap VXIIHmRpPCtaLfMuCgwNFvoXWNKWA;

			private int QcOlrGrKVZFGRCvEWNeuyBspjWXlA;

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
			public uwWmBRwUPUvcvNsQdetkTuFUwufx(int P_0)
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

		private sealed class WrSsvRVkHzxOxJociCztVVbzuuee : IEnumerable<ControllerTemplateElementIdentifier>, IEnumerable, IEnumerator<ControllerTemplateElementIdentifier>, IEnumerator, IDisposable
		{
			private int HBHVIUsgYHHUlAyzYTNKpuzyQaEN;

			private ControllerTemplateElementIdentifier KihBcNHMoIUTNnvrfoNFccvCwwQcc;

			private int FdoYHRncZgoMsUFBoMqzlLhMEFbW;

			public HardwareJoystickTemplateMap ShbMIVYpcAaBlHftnjBywCfSNfgM;

			private int WMTYiwfvFQQGbOOydNgbxggfmMwT;

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
			public WrSsvRVkHzxOxJociCztVVbzuuee(int P_0)
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

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string controllerName;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string description;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string templateGuid;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string templateKey;

		[SerializeField]
		[CustomObfuscation(rename = false)]
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

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int elementIdentifierIdCounter;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int joystickIdCounter;

		[NonSerialized]
		private Func<Guid, Entry> LKQjWHhzOOlRIMTrjYTvXIoKMJde;

		public override Guid Guid => default(Guid);

		public override string Key => null;

		public string ControllerName => null;

		public string ClassName => null;

		public IEnumerable<ControllerTemplateElementIdentifier> ElementIdentifiers
		{
			[IteratorStateMachine(typeof(WrSsvRVkHzxOxJociCztVVbzuuee))]
			get
			{
				return null;
			}
		}

		public int elementIdentifierCount => 0;

		Guid IHardwareControllerMap_Internal.typeGuid => default(Guid);

		string IHardwareControllerMap_Internal.typeKey => null;

		ControllerType IHardwareControllerMap_Internal.controllerType => default(ControllerType);

		IEnumerable<IControllerElementIdentifierCommon_Internal> IHardwareControllerMap_Internal.ElementIdentifiers
		{
			[IteratorStateMachine(typeof(uwWmBRwUPUvcvNsQdetkTuFUwufx))]
			get
			{
				return null;
			}
		}

		string IHardwareControllerTemplateMap_Internal.name => null;

		Guid IHardwareControllerTemplateMap_Internal.typeGuid => default(Guid);

		string IHardwareControllerTemplateMap_Internal.typeKey => null;

		private Func<Guid, Entry> VcwHoykxnUNotVACPZCdvnygCbRf => null;

		string IHardwareControllerMap_Internal.name => null;

		[CustomObfuscation(rename = false)]
		public override ControllerTemplateElementIdentifier GetElementIdentifier(int id)
		{
			return null;
		}

		[CustomObfuscation(rename = false)]
		public ControllerTemplateElementIdentifier GetElementIdentifierAtIndex(int index)
		{
			return null;
		}

		[CustomObfuscation(rename = false)]
		public override bool ContainsElementIdentifier(int id)
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

		[CustomObfuscation(rename = false)]
		internal SpecialElementEntry[] GetSpecialElementsOrig()
		{
			return null;
		}

		internal bool iaKJlWeRhlxzQxOMjnbeoyHSjItm(ControllerMap_Editor P_0, HardwareJoystickMap P_1, Guid P_2, out string P_3)
		{
			P_3 = null;
			return false;
		}

		internal SUKBHhZFjtXCZDAZGqMkzjNQboJY OXBDogYrJsZORTaCvKIHTMarTGnC()
		{
			return null;
		}

		private Entry hlPTMSnymaDPOOjCkNCwxDkRVeu(Guid P_0)
		{
			return null;
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

		vuooprXJHVvacQvysmZLVazcCbGcA IHardwareControllerTemplateMap_Internal.GetAxisTarget(Controller controller, int elementIdentifierId)
		{
			return null;
		}

		vuooprXJHVvacQvysmZLVazcCbGcA IHardwareControllerTemplateMap_Internal.GetButtonTarget(Controller controller, int elementIdentifierId)
		{
			return null;
		}

		internal static vuooprXJHVvacQvysmZLVazcCbGcA BeKVQupanfQxzfEFwNETmAujgNXFA(IHardwareControllerTemplateMap_Internal P_0, Controller P_1, int P_2, Func<Guid, Entry> P_3)
		{
			return null;
		}

		internal static vuooprXJHVvacQvysmZLVazcCbGcA sMFEhcuyYhZHTnxMatWNBOzXkROc(IHardwareControllerTemplateMap_Internal P_0, Controller P_1, int P_2, Func<Guid, Entry> P_3)
		{
			return null;
		}

		internal static ControllerTemplateElementIdentifier gMoqCtwoTwEcaqVFQDcojnLjfmKtA(ControllerTemplateElementIdentifier[] P_0, int P_1)
		{
			return null;
		}

		internal static int PEVMPrnlPNGmiYwJrFGUhYOAMjTw(ControllerTemplateElementIdentifier[] P_0, int P_1)
		{
			return 0;
		}

		internal static bool mUcpDsVsaDLAJfdCFgLKDkIeOLiX(ControllerTemplateElementIdentifier[] P_0, int P_1)
		{
			return false;
		}
	}
}
