using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Rewired.Interfaces;
using Rewired.Utils;
using Rewired.Utils.Attributes;
using Rewired.Utils.Libraries.TinyJson;
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

			public Guid JoystickGuid
			{
				get
				{
					try
					{
						return new Guid(joystickGuid);
					}
					catch
					{
						Logger.LogWarning("Error converting string to Guid due to invalid characters or bad Guid string format. Guid string = \"" + joystickGuid + "\"");
						return Guid.Empty;
					}
				}
			}

			[Preserve]
			public Entry()
			{
			}

			internal Entry(Entry P_0)
			{
				id = P_0.id;
				name = P_0.name;
				joystickGuid = P_0.joystickGuid;
				fileGuid = P_0.fileGuid;
				if (P_0.elementIdentifierMappings == null)
				{
					return;
				}
				elementIdentifierMappings = new List<ElementIdentifierMap>(P_0.elementIdentifierMappings.Count);
				for (int i = 0; i < P_0.elementIdentifierMappings.Count; i++)
				{
					if (P_0.elementIdentifierMappings[i] != null)
					{
						elementIdentifierMappings.Add(new ElementIdentifierMap(P_0.elementIdentifierMappings[i]));
					}
				}
			}

			public int GetJoystickElementId(int templateElementId)
			{
				if (elementIdentifierMappings == null)
				{
					return -1;
				}
				int count = elementIdentifierMappings.Count;
				for (int i = 0; i < count; i++)
				{
					if (elementIdentifierMappings[i].templateId == templateElementId)
					{
						return elementIdentifierMappings[i].joystickId;
					}
				}
				return -1;
			}

			public int GetTemplateElementId(int joystickElementId)
			{
				if (elementIdentifierMappings == null)
				{
					return -1;
				}
				int count = elementIdentifierMappings.Count;
				for (int i = 0; i < count; i++)
				{
					if (elementIdentifierMappings[i].joystickId == joystickElementId)
					{
						return elementIdentifierMappings[i].templateId;
					}
				}
				return -1;
			}

			public ElementIdentifierMap GetElementIdentifierMap(int templateId)
			{
				if (elementIdentifierMappings == null)
				{
					return null;
				}
				int count = elementIdentifierMappings.Count;
				for (int i = 0; i < count; i++)
				{
					if (elementIdentifierMappings[i].templateId == templateId)
					{
						return elementIdentifierMappings[i];
					}
				}
				return null;
			}

			public void GetElementIdentifierMaps(int templateId, List<ElementIdentifierMap> results)
			{
				if (results == null || elementIdentifierMappings == null)
				{
					return;
				}
				int count = elementIdentifierMappings.Count;
				for (int i = 0; i < count; i++)
				{
					if (elementIdentifierMappings[i].templateId == templateId)
					{
						results.Add(elementIdentifierMappings[i]);
					}
				}
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
				templateId = P_0.templateId;
				joystickId = P_0.joystickId;
				joystickId2 = P_0.joystickId2;
				splitAxis = P_0.splitAxis;
			}
		}

		[Serializable]
		public sealed class SpecialElementEntry : IControllerTemplateMapSpecialElement_Internal
		{
			public int elementIdentifierId = -1;

			public string data;

			[Preserve]
			public SpecialElementEntry()
			{
			}

			internal SpecialElementEntry(SpecialElementEntry P_0)
			{
				elementIdentifierId = P_0.elementIdentifierId;
				data = P_0.data;
			}

			T IControllerTemplateMapSpecialElement_Internal.GetMapping<T>()
			{
				JsonParser.TryFromJson<T>(data, out var value);
				return value;
			}
		}

		private sealed class pelcbnIUhPCxuajrfFYFPkniyKYvb : IEnumerable<IControllerElementIdentifierCommon_Internal>, IEnumerable, IEnumerator<IControllerElementIdentifierCommon_Internal>, IEnumerator, IDisposable
		{
			private int qoWvEUPsjiTCtFKgZbsxkUlhEGQp;

			private IControllerElementIdentifierCommon_Internal EkIdpoKIeWcYuReEJYgSujVAMVqoA;

			private int mPQFBaFcbnYPULtlcZMlRtWFGvNiA;

			public HardwareJoystickTemplateMap AshwzKpEpBJhIPvRwwRcYMCjDndJA;

			private int PzfWRoDjfWwXIVLnaiDTagGHPcgq;

			IControllerElementIdentifierCommon_Internal IEnumerator<IControllerElementIdentifierCommon_Internal>.Current
			{
				[DebuggerHidden]
				get
				{
					return EkIdpoKIeWcYuReEJYgSujVAMVqoA;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return EkIdpoKIeWcYuReEJYgSujVAMVqoA;
				}
			}

			[DebuggerHidden]
			public pelcbnIUhPCxuajrfFYFPkniyKYvb(int P_0)
			{
				qoWvEUPsjiTCtFKgZbsxkUlhEGQp = P_0;
				mPQFBaFcbnYPULtlcZMlRtWFGvNiA = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				qoWvEUPsjiTCtFKgZbsxkUlhEGQp = -2;
			}

			private bool MoveNext()
			{
				int num = qoWvEUPsjiTCtFKgZbsxkUlhEGQp;
				HardwareJoystickTemplateMap ashwzKpEpBJhIPvRwwRcYMCjDndJA = AshwzKpEpBJhIPvRwwRcYMCjDndJA;
				switch (num)
				{
				default:
					return false;
				case 0:
					qoWvEUPsjiTCtFKgZbsxkUlhEGQp = -1;
					if (ashwzKpEpBJhIPvRwwRcYMCjDndJA.elementIdentifiers == null)
					{
						return false;
					}
					PzfWRoDjfWwXIVLnaiDTagGHPcgq = 0;
					break;
				case 1:
					qoWvEUPsjiTCtFKgZbsxkUlhEGQp = -1;
					PzfWRoDjfWwXIVLnaiDTagGHPcgq++;
					break;
				}
				if (PzfWRoDjfWwXIVLnaiDTagGHPcgq < ashwzKpEpBJhIPvRwwRcYMCjDndJA.elementIdentifiers.Length)
				{
					EkIdpoKIeWcYuReEJYgSujVAMVqoA = ashwzKpEpBJhIPvRwwRcYMCjDndJA.elementIdentifiers[PzfWRoDjfWwXIVLnaiDTagGHPcgq];
					qoWvEUPsjiTCtFKgZbsxkUlhEGQp = 1;
					return true;
				}
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
				throw new NotSupportedException();
			}

			[DebuggerHidden]
			IEnumerator<IControllerElementIdentifierCommon_Internal> IEnumerable<IControllerElementIdentifierCommon_Internal>.GetEnumerator()
			{
				pelcbnIUhPCxuajrfFYFPkniyKYvb pelcbnIUhPCxuajrfFYFPkniyKYvb2;
				if (qoWvEUPsjiTCtFKgZbsxkUlhEGQp == -2 && mPQFBaFcbnYPULtlcZMlRtWFGvNiA == Environment.CurrentManagedThreadId)
				{
					qoWvEUPsjiTCtFKgZbsxkUlhEGQp = 0;
					pelcbnIUhPCxuajrfFYFPkniyKYvb2 = this;
				}
				else
				{
					pelcbnIUhPCxuajrfFYFPkniyKYvb2 = new pelcbnIUhPCxuajrfFYFPkniyKYvb(0);
					pelcbnIUhPCxuajrfFYFPkniyKYvb2.AshwzKpEpBJhIPvRwwRcYMCjDndJA = AshwzKpEpBJhIPvRwwRcYMCjDndJA;
				}
				return pelcbnIUhPCxuajrfFYFPkniyKYvb2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<IControllerElementIdentifierCommon_Internal>)this).GetEnumerator();
			}
		}

		private sealed class FvdCGpzfCcVcchlVAvbCyIfTaCHIA : IEnumerable<ControllerTemplateElementIdentifier>, IEnumerable, IEnumerator<ControllerTemplateElementIdentifier>, IEnumerator, IDisposable
		{
			private int MSepkAEuBMNfsqCLoiedEfFWSBxk;

			private ControllerTemplateElementIdentifier FjIoYxycYPvIKJAILRyiFOHOGMzx;

			private int QMBjdlHGbxoVjyLkGZLMAXBkFdIX;

			public HardwareJoystickTemplateMap HAmNvmlUTjOizNAJakNPgFmCDPN;

			private int ZCwIUSPThDoZcazRJPwWCDIBkvZg;

			ControllerTemplateElementIdentifier IEnumerator<ControllerTemplateElementIdentifier>.Current
			{
				[DebuggerHidden]
				get
				{
					return FjIoYxycYPvIKJAILRyiFOHOGMzx;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return FjIoYxycYPvIKJAILRyiFOHOGMzx;
				}
			}

			[DebuggerHidden]
			public FvdCGpzfCcVcchlVAvbCyIfTaCHIA(int P_0)
			{
				MSepkAEuBMNfsqCLoiedEfFWSBxk = P_0;
				QMBjdlHGbxoVjyLkGZLMAXBkFdIX = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				MSepkAEuBMNfsqCLoiedEfFWSBxk = -2;
			}

			private bool MoveNext()
			{
				int mSepkAEuBMNfsqCLoiedEfFWSBxk = MSepkAEuBMNfsqCLoiedEfFWSBxk;
				HardwareJoystickTemplateMap hAmNvmlUTjOizNAJakNPgFmCDPN = HAmNvmlUTjOizNAJakNPgFmCDPN;
				switch (mSepkAEuBMNfsqCLoiedEfFWSBxk)
				{
				default:
					return false;
				case 0:
					MSepkAEuBMNfsqCLoiedEfFWSBxk = -1;
					if (hAmNvmlUTjOizNAJakNPgFmCDPN.elementIdentifiers == null)
					{
						return false;
					}
					ZCwIUSPThDoZcazRJPwWCDIBkvZg = 0;
					break;
				case 1:
					MSepkAEuBMNfsqCLoiedEfFWSBxk = -1;
					ZCwIUSPThDoZcazRJPwWCDIBkvZg++;
					break;
				}
				if (ZCwIUSPThDoZcazRJPwWCDIBkvZg < hAmNvmlUTjOizNAJakNPgFmCDPN.elementIdentifiers.Length)
				{
					FjIoYxycYPvIKJAILRyiFOHOGMzx = hAmNvmlUTjOizNAJakNPgFmCDPN.elementIdentifiers[ZCwIUSPThDoZcazRJPwWCDIBkvZg];
					MSepkAEuBMNfsqCLoiedEfFWSBxk = 1;
					return true;
				}
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
				throw new NotSupportedException();
			}

			[DebuggerHidden]
			IEnumerator<ControllerTemplateElementIdentifier> IEnumerable<ControllerTemplateElementIdentifier>.GetEnumerator()
			{
				FvdCGpzfCcVcchlVAvbCyIfTaCHIA fvdCGpzfCcVcchlVAvbCyIfTaCHIA;
				if (MSepkAEuBMNfsqCLoiedEfFWSBxk == -2 && QMBjdlHGbxoVjyLkGZLMAXBkFdIX == Environment.CurrentManagedThreadId)
				{
					MSepkAEuBMNfsqCLoiedEfFWSBxk = 0;
					fvdCGpzfCcVcchlVAvbCyIfTaCHIA = this;
				}
				else
				{
					fvdCGpzfCcVcchlVAvbCyIfTaCHIA = new FvdCGpzfCcVcchlVAvbCyIfTaCHIA(0);
					fvdCGpzfCcVcchlVAvbCyIfTaCHIA.HAmNvmlUTjOizNAJakNPgFmCDPN = HAmNvmlUTjOizNAJakNPgFmCDPN;
				}
				return fvdCGpzfCcVcchlVAvbCyIfTaCHIA;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ControllerTemplateElementIdentifier>)this).GetEnumerator();
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
		private SpecialElementEntry[] specialElements = new SpecialElementEntry[0];

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int elementIdentifierIdCounter;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int joystickIdCounter;

		[NonSerialized]
		private Func<Guid, Entry> YZhDllNyRTynHijsPEtCyxisVkAR;

		Guid HardwareControllerTemplateMap.Guid => StringTools.ToGuid(templateGuid);

		string HardwareControllerTemplateMap.Key => templateKey;

		public string ControllerName => controllerName;

		public string ClassName => className;

		public IEnumerable<ControllerTemplateElementIdentifier> ElementIdentifiers
		{
			[IteratorStateMachine(typeof(FvdCGpzfCcVcchlVAvbCyIfTaCHIA))]
			get
			{
				return new FvdCGpzfCcVcchlVAvbCyIfTaCHIA(-2)
				{
					HAmNvmlUTjOizNAJakNPgFmCDPN = this
				};
			}
		}

		public int elementIdentifierCount
		{
			get
			{
				if (elementIdentifiers == null)
				{
					return 0;
				}
				return elementIdentifiers.Length;
			}
		}

		Guid IHardwareControllerMap_Internal.typeGuid => Guid;

		string IHardwareControllerMap_Internal.typeKey => templateKey;

		ControllerType IHardwareControllerMap_Internal.controllerType => ControllerType.Joystick;

		IEnumerable<IControllerElementIdentifierCommon_Internal> IHardwareControllerMap_Internal.ElementIdentifiers
		{
			[IteratorStateMachine(typeof(pelcbnIUhPCxuajrfFYFPkniyKYvb))]
			get
			{
				return new pelcbnIUhPCxuajrfFYFPkniyKYvb(-2)
				{
					AshwzKpEpBJhIPvRwwRcYMCjDndJA = this
				};
			}
		}

		string IHardwareControllerTemplateMap_Internal.name => controllerName;

		Guid IHardwareControllerTemplateMap_Internal.typeGuid => Guid;

		string IHardwareControllerTemplateMap_Internal.typeKey => templateKey;

		private Func<Guid, Entry> OiJbYMQRTLYcovdcxaDUSKtQwFqg => emMvlycmChCPAaWUsietPjWMjBRg;

		string IHardwareControllerMap_Internal.name => base.name;

		[CustomObfuscation(rename = false)]
		public override ControllerTemplateElementIdentifier GetElementIdentifier(int id)
		{
			ControllerTemplateElementIdentifier[] array = elementIdentifiers;
			return xfTgyRfIrjozjBGmauZVnIrMPIxfB(array, id);
		}

		[CustomObfuscation(rename = false)]
		public ControllerTemplateElementIdentifier GetElementIdentifierAtIndex(int index)
		{
			if (index < 0 || index >= elementIdentifiers.Length)
			{
				return null;
			}
			return elementIdentifiers[index];
		}

		[CustomObfuscation(rename = false)]
		public override bool ContainsElementIdentifier(int id)
		{
			ControllerTemplateElementIdentifier[] array = elementIdentifiers;
			return zVtZGYpCSnIQhXrcxcdumweGxBOc(array, id);
		}

		bool IHardwareControllerMap.ContainsElementIdentifier(int id)
		{
			//ILSpy generated this explicit interface implementation from .override directive in ContainsElementIdentifier
			return this.ContainsElementIdentifier(id);
		}

		[CustomObfuscation(rename = false)]
		public string[] GetElementIdentifierNames()
		{
			int num = ((elementIdentifiers != null) ? elementIdentifiers.Length : 0);
			string[] array = new string[num];
			for (int i = 0; i < num; i++)
			{
				array[i] = elementIdentifiers[i].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename;
			}
			return array;
		}

		string[] IHardwareControllerMap.GetElementIdentifierNames()
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetElementIdentifierNames
			return this.GetElementIdentifierNames();
		}

		[CustomObfuscation(rename = false)]
		public int[] GetElementIdentifierIds()
		{
			int num = ((elementIdentifiers != null) ? elementIdentifiers.Length : 0);
			int[] array = new int[num];
			for (int i = 0; i < num; i++)
			{
				array[i] = elementIdentifiers[i].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid;
			}
			return array;
		}

		int[] IHardwareControllerMap.GetElementIdentifierIds()
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetElementIdentifierIds
			return this.GetElementIdentifierIds();
		}

		[CustomObfuscation(rename = false)]
		internal string[] GetElementIdentifierScriptingNames(bool useAlternate)
		{
			int num = ((elementIdentifiers != null) ? elementIdentifiers.Length : 0);
			string[] array = new string[num];
			for (int i = 0; i < num; i++)
			{
				array[i] = (useAlternate ? elementIdentifiers[i].alternateScriptingName : elementIdentifiers[i].scriptingName);
			}
			return array;
		}

		public int GetMappableElementIdentifierInfo(out string[] names, out int[] ids)
		{
			names = EmptyObjects<string>.array;
			ids = EmptyObjects<int>.array;
			int num = ((elementIdentifiers != null) ? elementIdentifiers.Length : 0);
			if (num == 0)
			{
				return 0;
			}
			List<ControllerTemplateElementIdentifier> list = new List<ControllerTemplateElementIdentifier>();
			for (int i = 0; i < num; i++)
			{
				if (elementIdentifiers[i] != null && InputTools.IsMappableType(elementIdentifiers[i].Rewired_002EInterfaces_002EIControllerTemplateElementIdentifier_002EelementType))
				{
					list.Add(elementIdentifiers[i]);
				}
			}
			int count = list.Count;
			if (count == 0)
			{
				return 0;
			}
			names = new string[count];
			ids = new int[count];
			for (int j = 0; j < count; j++)
			{
				names[j] = list[j].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename;
				ids[j] = list[j].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid;
			}
			return count;
		}

		int IHardwareControllerMap.GetMappableElementIdentifierInfo(out string[] names, out int[] ids)
		{
			//ILSpy generated this explicit interface implementation from .override directive in GetMappableElementIdentifierInfo
			return this.GetMappableElementIdentifierInfo(out names, out ids);
		}

		public int GetNonMappableElementIdentifierInfo(out string[] names, out int[] ids)
		{
			names = EmptyObjects<string>.array;
			ids = EmptyObjects<int>.array;
			int num = ((elementIdentifiers != null) ? elementIdentifiers.Length : 0);
			if (num == 0)
			{
				return 0;
			}
			List<ControllerTemplateElementIdentifier> list = new List<ControllerTemplateElementIdentifier>();
			for (int i = 0; i < num; i++)
			{
				if (elementIdentifiers[i] != null && !InputTools.IsMappableType(elementIdentifiers[i].Rewired_002EInterfaces_002EIControllerTemplateElementIdentifier_002EelementType))
				{
					list.Add(elementIdentifiers[i]);
				}
			}
			int count = list.Count;
			if (count == 0)
			{
				return 0;
			}
			names = new string[count];
			ids = new int[count];
			for (int j = 0; j < count; j++)
			{
				names[j] = list[j].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Ename;
				ids[j] = list[j].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid;
			}
			return count;
		}

		public string[] GetJoystickNames()
		{
			int num = ((joysticks != null) ? joysticks.Count : 0);
			string[] array = new string[num];
			for (int i = 0; i < num; i++)
			{
				array[i] = joysticks[i].name;
			}
			return array;
		}

		public int[] GetJoystickIds()
		{
			int num = ((joysticks != null) ? joysticks.Count : 0);
			int[] array = new int[num];
			for (int i = 0; i < num; i++)
			{
				array[i] = joysticks[i].id;
			}
			return array;
		}

		public Guid GetJoystickGuid(int joystickId)
		{
			if (joysticks == null)
			{
				return Guid.Empty;
			}
			for (int i = 0; i < joysticks.Count; i++)
			{
				if (joysticks[i].id == joystickId)
				{
					return StringTools.ToGuid(joysticks[i].joystickGuid);
				}
			}
			return Guid.Empty;
		}

		public int GetJoystickId(Guid guid)
		{
			for (int i = 0; i < joysticks.Count; i++)
			{
				if (StringTools.ToGuid(joysticks[i].joystickGuid) == guid)
				{
					return joysticks[i].id;
				}
			}
			return -1;
		}

		public string GetJoystickFileGuidString(int joystickId)
		{
			if (joysticks == null)
			{
				return string.Empty;
			}
			for (int i = 0; i < joysticks.Count; i++)
			{
				if (joysticks[i].id == joystickId)
				{
					return joysticks[i].fileGuid;
				}
			}
			return string.Empty;
		}

		[CustomObfuscation(rename = false)]
		internal SpecialElementEntry[] GetSpecialElementsOrig()
		{
			return specialElements;
		}

		internal bool xbxZTwGmXmGgZIVrBuILoJxkDaCzA(ControllerMap_Editor P_0, HardwareJoystickMap P_1, Guid P_2, out string P_3)
		{
			if (P_0 == null)
			{
				P_3 = "Template Map was null.";
				return false;
			}
			P_0.hardwareGuidString = P_2.ToString();
			Entry entry = emMvlycmChCPAaWUsietPjWMjBRg(P_2);
			if (entry == null)
			{
				Guid guid = P_2;
				P_3 = "Hardware guid not found in ControllerDataFiles: " + guid.ToString() + "\nThis error should never happen. Please contact support.";
				return false;
			}
			List<ActionElementMap> actionElementMaps = P_0.actionElementMaps;
			using (TempListPool.TList<ActionElementMap> tList = TempListPool.GetTList<ActionElementMap>())
			{
				List<ActionElementMap> list = tList.list;
				using (TempListPool.TList<ElementIdentifierMap> tList2 = TempListPool.GetTList<ElementIdentifierMap>())
				{
					List<ElementIdentifierMap> list2 = tList2.list;
					for (int i = 0; i < actionElementMaps.Count; i++)
					{
						list2.Clear();
						ActionElementMap actionElementMap = actionElementMaps[i];
						int elementIdentifierId = actionElementMap._elementIdentifierId;
						entry.GetElementIdentifierMaps(elementIdentifierId, list2);
						for (int j = 0; j < list2.Count; j++)
						{
							ElementIdentifierMap elementIdentifierMap = list2[j];
							if (elementIdentifierMap == null || elementIdentifierMap.joystickId < 0)
							{
								continue;
							}
							ActionElementMap actionElementMap2 = new ActionElementMap(actionElementMap);
							ActionElementMap actionElementMap3 = null;
							bool flag = false;
							ControllerTemplateElementIdentifier[] array = elementIdentifiers;
							int num = MNyCpFcJfMGplMiuRCpvsUaqhBmIb(array, elementIdentifierId);
							if (num >= 0 && num < elementIdentifiers.Length)
							{
								ControllerElementIdentifier elementIdentifier = P_1.GetElementIdentifier(elementIdentifierMap.joystickId);
								ControllerTemplateElementIdentifier_Editor controllerTemplateElementIdentifier_Editor = elementIdentifiers[num];
								if (elementIdentifier != null && controllerTemplateElementIdentifier_Editor != null)
								{
									ControllerTemplateElementType effectiveElementType = controllerTemplateElementIdentifier_Editor.effectiveElementType;
									if (!bVcNkmaJvbHeBNQRpaleQvWHeXqv.LrIgjFjPWmoAlronxTteVcEmIKQR(effectiveElementType, elementIdentifier.elementType))
									{
										if (effectiveElementType == ControllerTemplateElementType.Axis && elementIdentifier.elementType == ControllerElementType.Button)
										{
											if (elementIdentifierMap.splitAxis)
											{
												if (actionElementMap2.axisType == AxisType.Normal && actionElementMap2._axisRange == AxisRange.Full)
												{
													actionElementMap3 = new ActionElementMap(actionElementMap2);
													actionElementMap3._elementType = ControllerElementType.Button;
													actionElementMap3._elementIdentifierId = elementIdentifierMap.joystickId2;
													if (actionElementMap2._invert)
													{
														actionElementMap2._axisContribution = Pole.Negative;
														actionElementMap3._axisContribution = Pole.Positive;
													}
													else
													{
														actionElementMap2._axisContribution = Pole.Positive;
														actionElementMap3._axisContribution = Pole.Negative;
													}
												}
												else if (actionElementMap2.axisType == AxisType.Split)
												{
													if (actionElementMap2._axisRange == AxisRange.Positive)
													{
														actionElementMap2._elementIdentifierId = elementIdentifierMap.joystickId;
													}
													else if (actionElementMap2._axisRange == AxisRange.Negative)
													{
														actionElementMap2._elementIdentifierId = elementIdentifierMap.joystickId2;
													}
													flag = true;
												}
											}
											actionElementMap2._elementType = ControllerElementType.Button;
										}
										else
										{
											if (effectiveElementType != ControllerTemplateElementType.Button || elementIdentifier.elementType != ControllerElementType.Axis)
											{
												throw new NotImplementedException();
											}
											actionElementMap2._axisRange = AxisRange.Positive;
											actionElementMap2._elementType = ControllerElementType.Axis;
										}
									}
								}
							}
							if (!flag)
							{
								actionElementMap2._elementIdentifierId = elementIdentifierMap.joystickId;
							}
							list.Add(actionElementMap2);
							if (actionElementMap3 != null)
							{
								list.Add(actionElementMap3);
							}
						}
					}
				}
				actionElementMaps.Clear();
				ListTools.CopyTo(list, actionElementMaps);
			}
			P_3 = null;
			return true;
		}

		internal LrxjGZteHmJMKhKqexjHMLnoIwmG NMmrAOacNfgWJdQLLunjkwwZzTWl()
		{
			int num = ((joysticks != null) ? joysticks.Count : 0);
			List<Entry> list = new List<Entry>(num);
			for (int i = 0; i < num; i++)
			{
				if (joysticks[i] != null)
				{
					list.Add(new Entry(joysticks[i]));
				}
			}
			ControllerTemplateElementIdentifier[] array = new ControllerTemplateElementIdentifier[(elementIdentifiers != null) ? elementIdentifiers.Length : 0];
			for (int j = 0; j < array.Length; j++)
			{
				if (elementIdentifiers[j] != null)
				{
					array[j] = new ControllerTemplateElementIdentifier(elementIdentifiers[j]);
				}
			}
			return new LrxjGZteHmJMKhKqexjHMLnoIwmG(this, list, array);
		}

		private Entry emMvlycmChCPAaWUsietPjWMjBRg(Guid P_0)
		{
			if (joysticks == null)
			{
				return null;
			}
			for (int i = 0; i < joysticks.Count; i++)
			{
				if (joysticks[i].JoystickGuid == P_0)
				{
					return joysticks[i];
				}
			}
			return null;
		}

		IControllerElementIdentifierCommon_Internal IHardwareControllerMap_Internal.GetElementIdentifier(int id)
		{
			return GetElementIdentifier(id);
		}

		int IHardwareControllerTemplateMap_Internal.GetElementIdentifierCount()
		{
			if (elementIdentifiers == null)
			{
				return 0;
			}
			return elementIdentifiers.Length;
		}

		IControllerTemplateElementIdentifier IHardwareControllerTemplateMap_Internal.GetTemplateElementIdentifier(int index)
		{
			if (elementIdentifiers == null)
			{
				return null;
			}
			return elementIdentifiers[index];
		}

		IControllerTemplateElementIdentifier IHardwareControllerTemplateMap_Internal.GetTemplateElementIdentifierById(int elementIdentifierId)
		{
			return GetElementIdentifier(elementIdentifierId);
		}

		IControllerTemplateMapSpecialElement_Internal IHardwareControllerTemplateMap_Internal.GetSpecialTemplateElementByElementIdentifierId(int id)
		{
			if (specialElements == null)
			{
				return null;
			}
			for (int i = 0; i < specialElements.Length; i++)
			{
				if (specialElements[i] != null && specialElements[i].elementIdentifierId == id)
				{
					return specialElements[i];
				}
			}
			return null;
		}

		wyBGNVjftIezdumZCvkmiqVKqZjAA IHardwareControllerTemplateMap_Internal.GetAxisTarget(Controller controller, int elementIdentifierId)
		{
			return KwxFoKDkNchmwPnsEbroLDWLfpieA(this, controller, elementIdentifierId, OiJbYMQRTLYcovdcxaDUSKtQwFqg);
		}

		wyBGNVjftIezdumZCvkmiqVKqZjAA IHardwareControllerTemplateMap_Internal.GetButtonTarget(Controller controller, int elementIdentifierId)
		{
			return hikcUQMOEgQOUVjCSSPkmxypOCqJ(this, controller, elementIdentifierId, OiJbYMQRTLYcovdcxaDUSKtQwFqg);
		}

		internal static wyBGNVjftIezdumZCvkmiqVKqZjAA KwxFoKDkNchmwPnsEbroLDWLfpieA(IHardwareControllerTemplateMap_Internal P_0, Controller P_1, int P_2, Func<Guid, Entry> P_3)
		{
			if (P_0 == null)
			{
				return null;
			}
			if (P_1 == null)
			{
				return null;
			}
			if (P_3 == null)
			{
				return null;
			}
			IControllerTemplateElementIdentifier templateElementIdentifierById = P_0.GetTemplateElementIdentifierById(P_2);
			if (templateElementIdentifierById == null)
			{
				return null;
			}
			if (templateElementIdentifierById.elementType != ControllerTemplateElementType.Axis)
			{
				return null;
			}
			if (P_1 == null)
			{
				return null;
			}
			Entry entry = P_3(P_1.qapLJarKYePKdgQROGMwYujqCcvB);
			if (entry == null)
			{
				return null;
			}
			List<ElementIdentifierMap> elementIdentifierMappings = entry.elementIdentifierMappings;
			if (elementIdentifierMappings == null)
			{
				return null;
			}
			int count = elementIdentifierMappings.Count;
			for (int i = 0; i < count; i++)
			{
				ElementIdentifierMap elementIdentifierMap = elementIdentifierMappings[i];
				if (elementIdentifierMap != null && elementIdentifierMap.templateId == P_2)
				{
					if (elementIdentifierMap.splitAxis)
					{
						return new wyBGNVjftIezdumZCvkmiqVKqZjAA(ControllerTemplateElementType.Axis, true, new XuJpBJvxrqVOEMAPQQDPCLYEUJbk(P_1, -1, AxisRange.Full), new XuJpBJvxrqVOEMAPQQDPCLYEUJbk(P_1, elementIdentifierMap.joystickId, AxisRange.Positive), new XuJpBJvxrqVOEMAPQQDPCLYEUJbk(P_1, elementIdentifierMap.joystickId2, AxisRange.Positive));
					}
					return new wyBGNVjftIezdumZCvkmiqVKqZjAA(ControllerTemplateElementType.Axis, false, new XuJpBJvxrqVOEMAPQQDPCLYEUJbk(P_1, elementIdentifierMap.joystickId, AxisRange.Full), new XuJpBJvxrqVOEMAPQQDPCLYEUJbk(P_1, -1, AxisRange.Positive), new XuJpBJvxrqVOEMAPQQDPCLYEUJbk(P_1, -1, AxisRange.Positive));
				}
			}
			return null;
		}

		internal static wyBGNVjftIezdumZCvkmiqVKqZjAA hikcUQMOEgQOUVjCSSPkmxypOCqJ(IHardwareControllerTemplateMap_Internal P_0, Controller P_1, int P_2, Func<Guid, Entry> P_3)
		{
			if (P_0 == null)
			{
				return null;
			}
			if (P_1 == null)
			{
				return null;
			}
			if (P_3 == null)
			{
				return null;
			}
			IControllerTemplateElementIdentifier templateElementIdentifierById = P_0.GetTemplateElementIdentifierById(P_2);
			if (templateElementIdentifierById == null)
			{
				return null;
			}
			if (templateElementIdentifierById.elementType != ControllerTemplateElementType.Button)
			{
				return null;
			}
			if (P_1 == null)
			{
				return null;
			}
			Entry entry = P_3(P_1.qapLJarKYePKdgQROGMwYujqCcvB);
			if (entry == null)
			{
				return null;
			}
			List<ElementIdentifierMap> elementIdentifierMappings = entry.elementIdentifierMappings;
			if (elementIdentifierMappings == null)
			{
				return null;
			}
			int count = elementIdentifierMappings.Count;
			for (int i = 0; i < count; i++)
			{
				ElementIdentifierMap elementIdentifierMap = elementIdentifierMappings[i];
				if (elementIdentifierMap != null && elementIdentifierMap.templateId == P_2)
				{
					return new wyBGNVjftIezdumZCvkmiqVKqZjAA(ControllerTemplateElementType.Button, false, new XuJpBJvxrqVOEMAPQQDPCLYEUJbk(P_1, elementIdentifierMap.joystickId, AxisRange.Full), new XuJpBJvxrqVOEMAPQQDPCLYEUJbk(P_1, -1, AxisRange.Positive), new XuJpBJvxrqVOEMAPQQDPCLYEUJbk(P_1, -1, AxisRange.Positive));
				}
			}
			return null;
		}

		internal static ControllerTemplateElementIdentifier xfTgyRfIrjozjBGmauZVnIrMPIxfB(ControllerTemplateElementIdentifier[] P_0, int P_1)
		{
			int num = MNyCpFcJfMGplMiuRCpvsUaqhBmIb(P_0, P_1);
			if (num < 0 || num >= P_0.Length)
			{
				return null;
			}
			return P_0[num];
		}

		internal static int MNyCpFcJfMGplMiuRCpvsUaqhBmIb(ControllerTemplateElementIdentifier[] P_0, int P_1)
		{
			if (P_0 == null)
			{
				return -1;
			}
			for (int i = 0; i < P_0.Length; i++)
			{
				if (P_0[i].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid == P_1)
				{
					return i;
				}
			}
			return -1;
		}

		internal static bool zVtZGYpCSnIQhXrcxcdumweGxBOc(ControllerTemplateElementIdentifier[] P_0, int P_1)
		{
			return MNyCpFcJfMGplMiuRCpvsUaqhBmIb(P_0, P_1) >= 0;
		}
	}
}
