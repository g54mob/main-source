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

			private T YMkadovOPaJJvuyauaRWnMpsUNM<T>() where T : ControllerTemplateSpecialElementMapping
			{
				return null;
			}

			T IControllerTemplateMapSpecialElement_Internal.GetMapping<T>()
			{
				//ILSpy generated this explicit interface implementation from .override directive in YMkadovOPaJJvuyauaRWnMpsUNM
				return this.YMkadovOPaJJvuyauaRWnMpsUNM<T>();
			}
		}

		private sealed class ihgGwvSHdcyPQSICUnGcHToFJtk : IDisposable, IEnumerator, IEnumerable, IEnumerable<ControllerTemplateElementIdentifier>, IEnumerator<ControllerTemplateElementIdentifier>
		{
			private ControllerTemplateElementIdentifier BkCCsqltFMRNvCZoZtUjDVFIQQJ;

			private int NnUDqRnSfwXnBFHmcGVSTSfluHA;

			private int gYRhIHIUBQGHqUGHDgJxiZzNxqt;

			public HardwareJoystickTemplateMap TiaUIShtPVkFOKyDFxywSfPUjyv;

			public int qmSYAdZCWBVZBfxBKWlRZEObgpC;

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
			public ihgGwvSHdcyPQSICUnGcHToFJtk(int _003C_003E1__state)
			{
			}
		}

		private sealed class mFtEBREqDlPJuMMOedGxHpPhKhx : IDisposable, IEnumerator, IEnumerable, IEnumerable<IControllerElementIdentifierCommon_Internal>, IEnumerator<IControllerElementIdentifierCommon_Internal>
		{
			private IControllerElementIdentifierCommon_Internal BkCCsqltFMRNvCZoZtUjDVFIQQJ;

			private int NnUDqRnSfwXnBFHmcGVSTSfluHA;

			private int gYRhIHIUBQGHqUGHDgJxiZzNxqt;

			public HardwareJoystickTemplateMap TiaUIShtPVkFOKyDFxywSfPUjyv;

			public int erzDLgBQXeYoqUVPNaQchbjvJKFM;

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
			public mFtEBREqDlPJuMMOedGxHpPhKhx(int _003C_003E1__state)
			{
			}
		}

		[CustomObfuscation]
		[SerializeField]
		private string controllerName;

		[CustomObfuscation]
		[SerializeField]
		private string description;

		[SerializeField]
		[CustomObfuscation]
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

		[CustomObfuscation]
		[SerializeField]
		private int elementIdentifierIdCounter;

		[SerializeField]
		[CustomObfuscation]
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

		internal bool HZkkVZFkyUYnKJqgfySaoHXaiwy(ControllerMap_Editor P_0, HardwareJoystickMap P_1, Guid P_2, out string P_3)
		{
			P_3 = null;
			return false;
		}

		internal ControllerTemplateElementIdentifier BmWNnGQhXkRjKTpjFNubqfExBsb(Guid P_0, int P_1)
		{
			return null;
		}

		[CustomObfuscation]
		internal SpecialElementEntry[] GetSpecialElementsOrig()
		{
			return null;
		}

		private Entry DBhkhOkGMEmnRIjWiXRYsWYcswq(Guid P_0)
		{
			return null;
		}

		private int uQHNMXoondezVRBDJEaIEwOKfyxQ(int P_0)
		{
			return 0;
		}

		private IControllerElementIdentifierCommon_Internal UuJDneEfqLPFSNgMVSaoMNyNGXoE(int P_0)
		{
			return null;
		}

		IControllerElementIdentifierCommon_Internal IHardwareControllerMap_Internal.GetElementIdentifier(int P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in UuJDneEfqLPFSNgMVSaoMNyNGXoE
			return this.UuJDneEfqLPFSNgMVSaoMNyNGXoE(P_0);
		}

		private int kMXAuvVrpsBAYwKLrBDdgSBKQDZy()
		{
			return 0;
		}

		int IHardwareControllerTemplateMap_Internal.GetElementIdentifierCount()
		{
			//ILSpy generated this explicit interface implementation from .override directive in kMXAuvVrpsBAYwKLrBDdgSBKQDZy
			return this.kMXAuvVrpsBAYwKLrBDdgSBKQDZy();
		}

		private IControllerTemplateElementIdentifier davAMonajobuBbfHyzCrbtYrdCJ(int P_0)
		{
			return null;
		}

		IControllerTemplateElementIdentifier IHardwareControllerTemplateMap_Internal.GetTemplateElementIdentifier(int P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in davAMonajobuBbfHyzCrbtYrdCJ
			return this.davAMonajobuBbfHyzCrbtYrdCJ(P_0);
		}

		private IControllerTemplateElementIdentifier QyDQiTvlRDFproKDeOtnDcdvKuE(int P_0)
		{
			return null;
		}

		IControllerTemplateElementIdentifier IHardwareControllerTemplateMap_Internal.GetTemplateElementIdentifierById(int P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in QyDQiTvlRDFproKDeOtnDcdvKuE
			return this.QyDQiTvlRDFproKDeOtnDcdvKuE(P_0);
		}

		private IControllerTemplateMapSpecialElement_Internal zwiEYDgiOCsSHIiSnKXiaxBatLig(int P_0)
		{
			return null;
		}

		IControllerTemplateMapSpecialElement_Internal IHardwareControllerTemplateMap_Internal.GetSpecialTemplateElementByElementIdentifierId(int P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in zwiEYDgiOCsSHIiSnKXiaxBatLig
			return this.zwiEYDgiOCsSHIiSnKXiaxBatLig(P_0);
		}

		private ZLAHcRAlswBmLISIGDdywYeRahfS RRHRjZXwFBUrNdEcmhnGLdVWgyR(Controller P_0, int P_1)
		{
			return null;
		}

		ZLAHcRAlswBmLISIGDdywYeRahfS IHardwareControllerTemplateMap_Internal.GetAxisTarget(Controller P_0, int P_1)
		{
			//ILSpy generated this explicit interface implementation from .override directive in RRHRjZXwFBUrNdEcmhnGLdVWgyR
			return this.RRHRjZXwFBUrNdEcmhnGLdVWgyR(P_0, P_1);
		}

		private ZLAHcRAlswBmLISIGDdywYeRahfS ioRgLtIcvrdFxXjEcijHgQuerGGi(Controller P_0, int P_1)
		{
			return null;
		}

		ZLAHcRAlswBmLISIGDdywYeRahfS IHardwareControllerTemplateMap_Internal.GetButtonTarget(Controller P_0, int P_1)
		{
			//ILSpy generated this explicit interface implementation from .override directive in ioRgLtIcvrdFxXjEcijHgQuerGGi
			return this.ioRgLtIcvrdFxXjEcijHgQuerGGi(P_0, P_1);
		}
	}
}
