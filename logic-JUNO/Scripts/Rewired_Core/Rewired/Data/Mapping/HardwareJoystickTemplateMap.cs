using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Rewired.Interfaces;
using Rewired.Utils;
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

			public int GetJoystickElementId(int templateElementId)
			{
				if (elementIdentifierMappings == null)
				{
					return -1;
				}
				for (int i = 0; i < elementIdentifierMappings.Count; i++)
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
				for (int i = 0; i < elementIdentifierMappings.Count; i++)
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
				for (int i = 0; i < elementIdentifierMappings.Count; i++)
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
				for (int i = 0; i < elementIdentifierMappings.Count; i++)
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
		}

		[Serializable]
		public sealed class SpecialElementEntry : IControllerTemplateMapSpecialElement_Internal
		{
			public int elementIdentifierId = -1;

			public string data;

			T IControllerTemplateMapSpecialElement_Internal.GetMapping<T>()
			{
				JsonParser.TryFromJson<T>(data, out var value);
				return value;
			}
		}

		private sealed class vuElfxdlCZNboHnUzeTGHyDLyNGPA : IEnumerable<IControllerElementIdentifierCommon_Internal>, IEnumerable, IEnumerator<IControllerElementIdentifierCommon_Internal>, IEnumerator, IDisposable
		{
			private int SwndEFPdiktPkkNDBEJwIcjriBiyA;

			private IControllerElementIdentifierCommon_Internal yUdMHDPOWpSZtBvRSTPdWDRolOXh;

			private int MymjTAPzxaCPeZBOPsghshkfjhFA;

			public HardwareJoystickTemplateMap AuLKcNEbXgdmZbEwyKjcCKupEGUEb;

			private int ZgGuupQdGjcjfgLyaxqShFctxYsf;

			IControllerElementIdentifierCommon_Internal IEnumerator<IControllerElementIdentifierCommon_Internal>.Current
			{
				[DebuggerHidden]
				get
				{
					return yUdMHDPOWpSZtBvRSTPdWDRolOXh;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return yUdMHDPOWpSZtBvRSTPdWDRolOXh;
				}
			}

			[DebuggerHidden]
			public vuElfxdlCZNboHnUzeTGHyDLyNGPA(int P_0)
			{
				SwndEFPdiktPkkNDBEJwIcjriBiyA = P_0;
				MymjTAPzxaCPeZBOPsghshkfjhFA = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int swndEFPdiktPkkNDBEJwIcjriBiyA = SwndEFPdiktPkkNDBEJwIcjriBiyA;
				HardwareJoystickTemplateMap auLKcNEbXgdmZbEwyKjcCKupEGUEb = AuLKcNEbXgdmZbEwyKjcCKupEGUEb;
				switch (swndEFPdiktPkkNDBEJwIcjriBiyA)
				{
				default:
					return false;
				case 0:
					SwndEFPdiktPkkNDBEJwIcjriBiyA = -1;
					if (auLKcNEbXgdmZbEwyKjcCKupEGUEb.elementIdentifiers == null)
					{
						return false;
					}
					ZgGuupQdGjcjfgLyaxqShFctxYsf = 0;
					break;
				case 1:
					SwndEFPdiktPkkNDBEJwIcjriBiyA = -1;
					ZgGuupQdGjcjfgLyaxqShFctxYsf++;
					break;
				}
				if (ZgGuupQdGjcjfgLyaxqShFctxYsf < auLKcNEbXgdmZbEwyKjcCKupEGUEb.elementIdentifiers.Length)
				{
					yUdMHDPOWpSZtBvRSTPdWDRolOXh = auLKcNEbXgdmZbEwyKjcCKupEGUEb.elementIdentifiers[ZgGuupQdGjcjfgLyaxqShFctxYsf];
					SwndEFPdiktPkkNDBEJwIcjriBiyA = 1;
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
				vuElfxdlCZNboHnUzeTGHyDLyNGPA vuElfxdlCZNboHnUzeTGHyDLyNGPA2;
				if (SwndEFPdiktPkkNDBEJwIcjriBiyA == -2 && MymjTAPzxaCPeZBOPsghshkfjhFA == Environment.CurrentManagedThreadId)
				{
					SwndEFPdiktPkkNDBEJwIcjriBiyA = 0;
					vuElfxdlCZNboHnUzeTGHyDLyNGPA2 = this;
				}
				else
				{
					vuElfxdlCZNboHnUzeTGHyDLyNGPA2 = new vuElfxdlCZNboHnUzeTGHyDLyNGPA(0);
					vuElfxdlCZNboHnUzeTGHyDLyNGPA2.AuLKcNEbXgdmZbEwyKjcCKupEGUEb = AuLKcNEbXgdmZbEwyKjcCKupEGUEb;
				}
				return vuElfxdlCZNboHnUzeTGHyDLyNGPA2;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<IControllerElementIdentifierCommon_Internal>)this).GetEnumerator();
			}
		}

		private sealed class qMpfcEgBhoHfolsuMCtzVykQqcDeA : IEnumerable<ControllerTemplateElementIdentifier>, IEnumerable, IEnumerator<ControllerTemplateElementIdentifier>, IEnumerator, IDisposable
		{
			private int WQClzghyCvLYWVdIJCxXRxzzWEgF;

			private ControllerTemplateElementIdentifier UjsJvmAWnRQEiZqlOFTpAppsLcyR;

			private int ZvKqcHJBKbOXfbwOXkUbmaFXPyzu;

			public HardwareJoystickTemplateMap QnvQBaobFaEVzaaziNVbyKLFnUUxA;

			private int iYzGlZKncOuJMEwgYWwhTYfOmbIb;

			ControllerTemplateElementIdentifier IEnumerator<ControllerTemplateElementIdentifier>.Current
			{
				[DebuggerHidden]
				get
				{
					return UjsJvmAWnRQEiZqlOFTpAppsLcyR;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return UjsJvmAWnRQEiZqlOFTpAppsLcyR;
				}
			}

			[DebuggerHidden]
			public qMpfcEgBhoHfolsuMCtzVykQqcDeA(int P_0)
			{
				WQClzghyCvLYWVdIJCxXRxzzWEgF = P_0;
				ZvKqcHJBKbOXfbwOXkUbmaFXPyzu = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int wQClzghyCvLYWVdIJCxXRxzzWEgF = WQClzghyCvLYWVdIJCxXRxzzWEgF;
				HardwareJoystickTemplateMap qnvQBaobFaEVzaaziNVbyKLFnUUxA = QnvQBaobFaEVzaaziNVbyKLFnUUxA;
				switch (wQClzghyCvLYWVdIJCxXRxzzWEgF)
				{
				default:
					return false;
				case 0:
					WQClzghyCvLYWVdIJCxXRxzzWEgF = -1;
					if (qnvQBaobFaEVzaaziNVbyKLFnUUxA.elementIdentifiers == null)
					{
						return false;
					}
					iYzGlZKncOuJMEwgYWwhTYfOmbIb = 0;
					break;
				case 1:
					WQClzghyCvLYWVdIJCxXRxzzWEgF = -1;
					iYzGlZKncOuJMEwgYWwhTYfOmbIb++;
					break;
				}
				if (iYzGlZKncOuJMEwgYWwhTYfOmbIb < qnvQBaobFaEVzaaziNVbyKLFnUUxA.elementIdentifiers.Length)
				{
					UjsJvmAWnRQEiZqlOFTpAppsLcyR = qnvQBaobFaEVzaaziNVbyKLFnUUxA.elementIdentifiers[iYzGlZKncOuJMEwgYWwhTYfOmbIb];
					WQClzghyCvLYWVdIJCxXRxzzWEgF = 1;
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
				qMpfcEgBhoHfolsuMCtzVykQqcDeA qMpfcEgBhoHfolsuMCtzVykQqcDeA2;
				if (WQClzghyCvLYWVdIJCxXRxzzWEgF == -2 && ZvKqcHJBKbOXfbwOXkUbmaFXPyzu == Environment.CurrentManagedThreadId)
				{
					WQClzghyCvLYWVdIJCxXRxzzWEgF = 0;
					qMpfcEgBhoHfolsuMCtzVykQqcDeA2 = this;
				}
				else
				{
					qMpfcEgBhoHfolsuMCtzVykQqcDeA2 = new qMpfcEgBhoHfolsuMCtzVykQqcDeA(0);
					qMpfcEgBhoHfolsuMCtzVykQqcDeA2.QnvQBaobFaEVzaaziNVbyKLFnUUxA = QnvQBaobFaEVzaaziNVbyKLFnUUxA;
				}
				return qMpfcEgBhoHfolsuMCtzVykQqcDeA2;
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

		Guid HardwareControllerTemplateMap.Guid => StringTools.ToGuid(templateGuid);

		public string ControllerName => controllerName;

		public string ClassName => className;

		public IEnumerable<ControllerTemplateElementIdentifier> ElementIdentifiers
		{
			[IteratorStateMachine(typeof(qMpfcEgBhoHfolsuMCtzVykQqcDeA))]
			get
			{
				return new qMpfcEgBhoHfolsuMCtzVykQqcDeA(-2)
				{
					QnvQBaobFaEVzaaziNVbyKLFnUUxA = this
				};
			}
		}

		IEnumerable<IControllerElementIdentifierCommon_Internal> IHardwareControllerMap_Internal.ElementIdentifiers
		{
			[IteratorStateMachine(typeof(vuElfxdlCZNboHnUzeTGHyDLyNGPA))]
			get
			{
				return new vuElfxdlCZNboHnUzeTGHyDLyNGPA(-2)
				{
					AuLKcNEbXgdmZbEwyKjcCKupEGUEb = this
				};
			}
		}

		string IHardwareControllerTemplateMap_Internal.name => controllerName;

		Guid IHardwareControllerTemplateMap_Internal.typeGuid => Guid;

		[CustomObfuscation(rename = false)]
		public ControllerTemplateElementIdentifier GetElementIdentifier(int id)
		{
			int num = TxijqFRvAdoJwAJRqdIzJdcqsubE(id);
			if (num < 0 || num >= elementIdentifiers.Length)
			{
				return null;
			}
			return elementIdentifiers[num];
		}

		[CustomObfuscation(rename = false)]
		public bool ContainsElementIdentifier(int id)
		{
			return TxijqFRvAdoJwAJRqdIzJdcqsubE(id) >= 0;
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

		internal bool rDhNTMGcTZvWndevGAdgCGizEYTn(ControllerMap_Editor P_0, HardwareJoystickMap P_1, Guid P_2, out string P_3)
		{
			if (P_0 == null)
			{
				P_3 = "Template Map was null.";
				return false;
			}
			P_0.hardwareGuidString = P_2.ToString();
			Entry entry = oUImrMcqMGqTuMNUdwsAIogRxLOW(P_2);
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
							int num = TxijqFRvAdoJwAJRqdIzJdcqsubE(elementIdentifierId);
							if (num >= 0 && num < elementIdentifiers.Length)
							{
								ControllerElementIdentifier elementIdentifier = P_1.GetElementIdentifier(elementIdentifierMap.joystickId);
								ControllerTemplateElementIdentifier_Editor controllerTemplateElementIdentifier_Editor = elementIdentifiers[num];
								if (elementIdentifier != null && controllerTemplateElementIdentifier_Editor != null)
								{
									ControllerTemplateElementType effectiveElementType = controllerTemplateElementIdentifier_Editor.effectiveElementType;
									if (!tqmHLUqTfYnnflPJaWxRPIPYjlrx.BKYdbhlvGNWRVJPfaVZTWMNnecZV(effectiveElementType, elementIdentifier.elementType))
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

		internal ControllerTemplateElementIdentifier UKvBePUAjQdONgBhBBVjDJzPYfGB(Guid P_0, int P_1)
		{
			if (P_0 == Guid.Empty || P_1 < 0)
			{
				return null;
			}
			if (joysticks == null)
			{
				return null;
			}
			int num = -1;
			for (int i = 0; i < joysticks.Count; i++)
			{
				if (joysticks[i] != null && joysticks[i].JoystickGuid == P_0)
				{
					num = i;
					break;
				}
			}
			if (num < 0)
			{
				return null;
			}
			Entry entry = joysticks[num];
			if (entry == null)
			{
				return null;
			}
			int templateElementId = entry.GetTemplateElementId(P_1);
			if (templateElementId < 0)
			{
				return null;
			}
			return GetElementIdentifier(templateElementId);
		}

		[CustomObfuscation(rename = false)]
		internal SpecialElementEntry[] GetSpecialElementsOrig()
		{
			return specialElements;
		}

		private Entry oUImrMcqMGqTuMNUdwsAIogRxLOW(Guid P_0)
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

		private int TxijqFRvAdoJwAJRqdIzJdcqsubE(int P_0)
		{
			if (elementIdentifiers == null)
			{
				return -1;
			}
			for (int i = 0; i < elementIdentifiers.Length; i++)
			{
				if (elementIdentifiers[i].Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid == P_0)
				{
					return i;
				}
			}
			return -1;
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

		wzVNvKxdfLgPZGLFDmLcrCdHxsec IHardwareControllerTemplateMap_Internal.GetAxisTarget(Controller controller, int elementIdentifierId)
		{
			ControllerTemplateElementIdentifier elementIdentifier = GetElementIdentifier(elementIdentifierId);
			if (elementIdentifier == null)
			{
				return null;
			}
			if (elementIdentifier.Rewired_002EInterfaces_002EIControllerTemplateElementIdentifier_002EelementType != ControllerTemplateElementType.Axis)
			{
				return null;
			}
			if (controller == null)
			{
				return null;
			}
			Entry entry = oUImrMcqMGqTuMNUdwsAIogRxLOW(controller.gLbADvCdALkEcLIQPhWpjDrhhunKA);
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
				if (elementIdentifierMap != null && elementIdentifierMap.templateId == elementIdentifierId)
				{
					if (elementIdentifierMap.splitAxis)
					{
						return new wzVNvKxdfLgPZGLFDmLcrCdHxsec(ControllerTemplateElementType.Axis, true, new LmZJVlxQhHHugoUPZHYcFkBNejmj(controller, -1, AxisRange.Full), new LmZJVlxQhHHugoUPZHYcFkBNejmj(controller, elementIdentifierMap.joystickId, AxisRange.Positive), new LmZJVlxQhHHugoUPZHYcFkBNejmj(controller, elementIdentifierMap.joystickId2, AxisRange.Positive));
					}
					return new wzVNvKxdfLgPZGLFDmLcrCdHxsec(ControllerTemplateElementType.Axis, false, new LmZJVlxQhHHugoUPZHYcFkBNejmj(controller, elementIdentifierMap.joystickId, AxisRange.Full), new LmZJVlxQhHHugoUPZHYcFkBNejmj(controller, -1, AxisRange.Positive), new LmZJVlxQhHHugoUPZHYcFkBNejmj(controller, -1, AxisRange.Positive));
				}
			}
			return null;
		}

		wzVNvKxdfLgPZGLFDmLcrCdHxsec IHardwareControllerTemplateMap_Internal.GetButtonTarget(Controller controller, int elementIdentifierId)
		{
			ControllerTemplateElementIdentifier elementIdentifier = GetElementIdentifier(elementIdentifierId);
			if (elementIdentifier == null)
			{
				return null;
			}
			if (elementIdentifier.Rewired_002EInterfaces_002EIControllerTemplateElementIdentifier_002EelementType != ControllerTemplateElementType.Button)
			{
				return null;
			}
			if (controller == null)
			{
				return null;
			}
			Entry entry = oUImrMcqMGqTuMNUdwsAIogRxLOW(controller.gLbADvCdALkEcLIQPhWpjDrhhunKA);
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
				if (elementIdentifierMap != null && elementIdentifierMap.templateId == elementIdentifierId)
				{
					return new wzVNvKxdfLgPZGLFDmLcrCdHxsec(ControllerTemplateElementType.Button, false, new LmZJVlxQhHHugoUPZHYcFkBNejmj(controller, elementIdentifierMap.joystickId, AxisRange.Full), new LmZJVlxQhHHugoUPZHYcFkBNejmj(controller, -1, AxisRange.Positive), new LmZJVlxQhHHugoUPZHYcFkBNejmj(controller, -1, AxisRange.Positive));
				}
			}
			return null;
		}
	}
}
