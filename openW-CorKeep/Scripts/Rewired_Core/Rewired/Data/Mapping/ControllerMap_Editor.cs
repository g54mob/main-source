using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Rewired.Interfaces;
using Rewired.Utils;

namespace Rewired.Data.Mapping
{
	[Serializable]
	public sealed class ControllerMap_Editor
	{
		private sealed class LwZEDCcgTeZYMvHXHeZECIhFmHcsA : IEnumerable<ActionElementMap>, IEnumerable, IEnumerator<ActionElementMap>, IEnumerator, IDisposable
		{
			private int jCRikwEYuWKIKLMCKOGRfYxHlyTeB;

			private ActionElementMap aCMMYqUPuCpnuJwEyszlXFntKfGR;

			private int yfDGhrifEYHnLmUTTIrwdQPJCclaA;

			public ControllerMap_Editor aWFdeadPbCDmkSFhCMMcdFewQMiFb;

			private int EWoxWKQWGQwEsBDmjnTrVgyQDttk;

			ActionElementMap IEnumerator<ActionElementMap>.Current
			{
				[DebuggerHidden]
				get
				{
					return aCMMYqUPuCpnuJwEyszlXFntKfGR;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return aCMMYqUPuCpnuJwEyszlXFntKfGR;
				}
			}

			[DebuggerHidden]
			public LwZEDCcgTeZYMvHXHeZECIhFmHcsA(int P_0)
			{
				jCRikwEYuWKIKLMCKOGRfYxHlyTeB = P_0;
				yfDGhrifEYHnLmUTTIrwdQPJCclaA = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
				jCRikwEYuWKIKLMCKOGRfYxHlyTeB = -2;
			}

			private bool MoveNext()
			{
				int num = jCRikwEYuWKIKLMCKOGRfYxHlyTeB;
				ControllerMap_Editor controllerMap_Editor = aWFdeadPbCDmkSFhCMMcdFewQMiFb;
				switch (num)
				{
				default:
					return false;
				case 0:
					jCRikwEYuWKIKLMCKOGRfYxHlyTeB = -1;
					if (controllerMap_Editor.actionElementMaps == null)
					{
						return false;
					}
					EWoxWKQWGQwEsBDmjnTrVgyQDttk = 0;
					break;
				case 1:
					jCRikwEYuWKIKLMCKOGRfYxHlyTeB = -1;
					EWoxWKQWGQwEsBDmjnTrVgyQDttk++;
					break;
				}
				if (EWoxWKQWGQwEsBDmjnTrVgyQDttk < controllerMap_Editor.actionElementMaps.Count)
				{
					aCMMYqUPuCpnuJwEyszlXFntKfGR = controllerMap_Editor.actionElementMaps[EWoxWKQWGQwEsBDmjnTrVgyQDttk];
					jCRikwEYuWKIKLMCKOGRfYxHlyTeB = 1;
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
			IEnumerator<ActionElementMap> IEnumerable<ActionElementMap>.GetEnumerator()
			{
				LwZEDCcgTeZYMvHXHeZECIhFmHcsA lwZEDCcgTeZYMvHXHeZECIhFmHcsA;
				if (jCRikwEYuWKIKLMCKOGRfYxHlyTeB == -2 && yfDGhrifEYHnLmUTTIrwdQPJCclaA == Environment.CurrentManagedThreadId)
				{
					jCRikwEYuWKIKLMCKOGRfYxHlyTeB = 0;
					lwZEDCcgTeZYMvHXHeZECIhFmHcsA = this;
				}
				else
				{
					lwZEDCcgTeZYMvHXHeZECIhFmHcsA = new LwZEDCcgTeZYMvHXHeZECIhFmHcsA(0);
					lwZEDCcgTeZYMvHXHeZECIhFmHcsA.aWFdeadPbCDmkSFhCMMcdFewQMiFb = aWFdeadPbCDmkSFhCMMcdFewQMiFb;
				}
				return lwZEDCcgTeZYMvHXHeZECIhFmHcsA;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ActionElementMap>)this).GetEnumerator();
			}
		}

		public int id;

		public int categoryId;

		public int layoutId;

		public string name;

		public string hardwareGuidString;

		public int customControllerUid;

		public List<ActionElementMap> actionElementMaps;

		public IEnumerable<ActionElementMap> ActionElementMaps
		{
			[IteratorStateMachine(typeof(LwZEDCcgTeZYMvHXHeZECIhFmHcsA))]
			get
			{
				return new LwZEDCcgTeZYMvHXHeZECIhFmHcsA(-2)
				{
					aWFdeadPbCDmkSFhCMMcdFewQMiFb = this
				};
			}
		}

		public Guid hardwareGuid => StringTools.ToGuid(hardwareGuidString);

		public ControllerMap_Editor()
		{
			actionElementMaps = new List<ActionElementMap>();
		}

		public ControllerMap_Editor Clone()
		{
			ControllerMap_Editor controllerMap_Editor = new ControllerMap_Editor();
			controllerMap_Editor.id = id;
			controllerMap_Editor.categoryId = categoryId;
			controllerMap_Editor.layoutId = layoutId;
			controllerMap_Editor.name = name;
			controllerMap_Editor.hardwareGuidString = hardwareGuidString;
			controllerMap_Editor.customControllerUid = customControllerUid;
			if (actionElementMaps != null)
			{
				controllerMap_Editor.actionElementMaps = new List<ActionElementMap>();
				for (int i = 0; i < actionElementMaps.Count; i++)
				{
					controllerMap_Editor.actionElementMaps.Add(new ActionElementMap(actionElementMaps[i]));
				}
			}
			return controllerMap_Editor;
		}

		public ActionElementMap GetActionElementMap(int index)
		{
			if (index < 0 || index >= actionElementMaps.Count)
			{
				return null;
			}
			return actionElementMaps[index];
		}

		internal JoystickMap QlQxGpqPGwcahumzquyUFHosjuMd(Func<int, bool> P_0, HardwareControllerMapIdentifier P_1, HardwareJoystickMap P_2, bool P_3)
		{
			JoystickMap joystickMap = new JoystickMap();
			myGqqnbERwJpAtwyczIVUGFpFxgE(P_0, joystickMap, P_1, P_2, P_3);
			return joystickMap;
		}

		internal KeyboardMap PsrktCybljmFnxvWynqvaoreCHOP(Func<int, bool> P_0)
		{
			KeyboardMap keyboardMap = new KeyboardMap();
			myGqqnbERwJpAtwyczIVUGFpFxgE(P_0, keyboardMap, default(HardwareControllerMapIdentifier), null, false);
			return keyboardMap;
		}

		internal MouseMap TGOeeBURFzzgmBJNVvllPdwqgpdt(Func<int, bool> P_0)
		{
			MouseMap mouseMap = new MouseMap();
			myGqqnbERwJpAtwyczIVUGFpFxgE(P_0, mouseMap, default(HardwareControllerMapIdentifier), null, false);
			return mouseMap;
		}

		internal CustomControllerMap FADDpRNvePMvlrhgpoFiyjozErHI(Func<int, bool> P_0, CustomController_Editor P_1)
		{
			CustomControllerMap customControllerMap = new CustomControllerMap();
			BVZqUQPUjPNKfskeBPuRFIIZKWUr(P_0, InputSource.Custom, customControllerMap, P_1);
			return customControllerMap;
		}

		internal ControllerTemplateMap AjykIxTdFiJlnZAlDlrRgYGFplWA()
		{
			if (ReInput.PsTKSHsnZqJcBurcmvqiUnasOQwi(hardwareGuid) == null)
			{
				return null;
			}
			ControllerTemplateMap controllerTemplateMap = new ControllerTemplateMap(hardwareGuid, categoryId, layoutId, id);
			int num = ((actionElementMaps != null) ? actionElementMaps.Count : 0);
			for (int i = 0; i < num; i++)
			{
				ActionElementMap actionElementMap = actionElementMaps[i];
				if (actionElementMap != null && InputTools.IsMappableType(actionElementMap._elementType))
				{
					ControllerTemplateActionElementMap controllerTemplateActionElementMap = ControllerTemplateActionElementMap.uAgYsMBZAISeyFOKLCMUFHKCoTswA(actionElementMap);
					if (controllerTemplateActionElementMap != null)
					{
						controllerTemplateMap.dtBNHMrjBaPTitUmoWkADvCrbNp(controllerTemplateActionElementMap);
					}
				}
			}
			return controllerTemplateMap;
		}

		private void myGqqnbERwJpAtwyczIVUGFpFxgE(Func<int, bool> P_0, ControllerMap P_1, HardwareControllerMapIdentifier P_2, HardwareJoystickMap P_3, bool P_4)
		{
			try
			{
				ControllerMap.QXFruTPDQsWAkpbQTcKsnAHJFyR();
				P_1.sourceMapId = id;
				P_1.categoryId = categoryId;
				P_1.name = name;
				P_1.hardwareGuid = StringTools.ToGuid(hardwareGuidString);
				if (actionElementMaps == null)
				{
					return;
				}
				for (int i = 0; i < actionElementMaps.Count; i++)
				{
					if (!P_0(actionElementMaps[i].actionId))
					{
						continue;
					}
					ActionElementMap actionElementMap = new ActionElementMap(actionElementMaps[i]);
					if (P_3 != null)
					{
						ControllerElementIdentifier elementIdentifier = P_3.GetElementIdentifier(actionElementMaps[i].elementIdentifierId);
						if (elementIdentifier != null)
						{
							ControllerElementType effectiveElementIdentifierType = P_3.GetEffectiveElementIdentifierType(P_2, actionElementMaps[i].elementIdentifierId, P_4);
							_ = elementIdentifier.elementType;
							if (effectiveElementIdentifierType != actionElementMaps[i].elementType)
							{
								actionElementMap._elementType = effectiveElementIdentifierType;
								switch (effectiveElementIdentifierType)
								{
								case ControllerElementType.Axis:
								{
									AxisRange axisRange;
									if (elementIdentifier.elementType == ControllerElementType.Button)
									{
										actionElementMap._axisRange = AxisRange.Positive;
									}
									else if (P_3.GetEffectiveAxisRange(P_2, actionElementMaps[i].elementIdentifierId, P_4, out axisRange))
									{
										actionElementMap._axisRange = axisRange;
									}
									else if (actionElementMap.axisContribution == Pole.Negative)
									{
										actionElementMap._axisRange = AxisRange.Negative;
									}
									else
									{
										actionElementMap._axisRange = AxisRange.Positive;
									}
									actionElementMap._invert = false;
									break;
								}
								case ControllerElementType.Button:
									if (actionElementMap._axisRange == AxisRange.Full)
									{
										actionElementMap._axisContribution = (actionElementMap._invert ? Pole.Negative : Pole.Positive);
									}
									actionElementMap._invert = false;
									actionElementMap._axisRange = AxisRange.Full;
									break;
								default:
									throw new NotImplementedException();
								}
							}
						}
					}
					P_1.ZsPqvQrjowcgLqmuMupUIUTcDTMs(actionElementMap);
				}
			}
			finally
			{
				ControllerMap.rzztgLcwyNrsBpkJvbDdCIBmMzrLA();
			}
		}

		private void BVZqUQPUjPNKfskeBPuRFIIZKWUr(Func<int, bool> P_0, InputSource P_1, CustomControllerMap P_2, CustomController_Editor P_3)
		{
			try
			{
				ControllerMap.QXFruTPDQsWAkpbQTcKsnAHJFyR();
				P_2.sourceMapId = id;
				P_2.categoryId = categoryId;
				P_2.name = name;
				P_2.sourceControllerId = customControllerUid;
				if (actionElementMaps == null)
				{
					return;
				}
				for (int i = 0; i < actionElementMaps.Count; i++)
				{
					if (!P_0(actionElementMaps[i].actionId))
					{
						continue;
					}
					ActionElementMap actionElementMap = new ActionElementMap(actionElementMaps[i]);
					if (P_3 != null)
					{
						ControllerElementIdentifier elementIdentifier = P_3.GetElementIdentifier(actionElementMaps[i].elementIdentifierId);
						if (elementIdentifier != null)
						{
							ControllerElementType effectiveElementIdentifierType = P_3.GetEffectiveElementIdentifierType(actionElementMaps[i].elementIdentifierId);
							_ = elementIdentifier.elementType;
							if (effectiveElementIdentifierType != actionElementMaps[i].elementType)
							{
								actionElementMap.elementType = effectiveElementIdentifierType;
								switch (effectiveElementIdentifierType)
								{
								case ControllerElementType.Axis:
								{
									AxisRange axisRange;
									if (elementIdentifier.elementType == ControllerElementType.Button)
									{
										actionElementMap.axisRange = AxisRange.Positive;
									}
									else if (P_3.GetEffectiveAxisRange(actionElementMaps[i].elementIdentifierId, out axisRange))
									{
										actionElementMap.axisRange = axisRange;
									}
									else if (actionElementMap.axisContribution == Pole.Negative)
									{
										actionElementMap.axisRange = AxisRange.Negative;
									}
									else
									{
										actionElementMap.axisRange = AxisRange.Positive;
									}
									actionElementMap.invert = false;
									break;
								}
								case ControllerElementType.Button:
									if (actionElementMap.axisRange == AxisRange.Full)
									{
										actionElementMap.axisContribution = (actionElementMap.invert ? Pole.Negative : Pole.Positive);
									}
									actionElementMap.invert = false;
									actionElementMap.axisRange = AxisRange.Full;
									break;
								default:
									throw new NotImplementedException();
								}
							}
						}
					}
					P_2.ZsPqvQrjowcgLqmuMupUIUTcDTMs(actionElementMap);
				}
			}
			finally
			{
				ControllerMap.rzztgLcwyNrsBpkJvbDdCIBmMzrLA();
			}
		}

		public void CreateElementsFromHardwareMap(IHardwareControllerMap hardwareJoystickMap)
		{
			if (hardwareJoystickMap == null)
			{
				return;
			}
			int num = 0;
			foreach (IControllerElementIdentifierCommon_Internal elementIdentifier in (hardwareJoystickMap as IHardwareControllerMap_Internal).ElementIdentifiers)
			{
				if (InputTools.IsMappableControllerElementType(elementIdentifier.elementType))
				{
					ActionElementMap item = new ActionElementMap(-1, nwsTruCLxjorysrNysDvPYrmMcrb.aWhHmSadwHJjvFlZOrkgzxRisrpu(elementIdentifier.elementType), elementIdentifier.id);
					actionElementMaps.Add(item);
					num++;
				}
			}
		}

		public void CreateElementsFromHardwareMap(CustomController_Editor customController)
		{
			if (customController == null)
			{
				return;
			}
			List<ActionElementMap> list = new List<ActionElementMap>();
			List<ActionElementMap> list2 = new List<ActionElementMap>();
			foreach (ControllerElementIdentifier elementIdentifier in customController.ElementIdentifiers)
			{
				ActionElementMap item = new ActionElementMap(-1, elementIdentifier.elementType, elementIdentifier.Rewired_002EInterfaces_002EIControllerElementIdentifierCommon_Internal_002Eid);
				if (elementIdentifier.elementType == ControllerElementType.Axis)
				{
					list2.Add(item);
					continue;
				}
				if (elementIdentifier.elementType == ControllerElementType.Button)
				{
					list.Add(item);
					continue;
				}
				throw new NotImplementedException();
			}
			for (int i = 0; i < list2.Count; i++)
			{
				actionElementMaps.Add(list2[i]);
			}
			for (int j = 0; j < list.Count; j++)
			{
				actionElementMaps.Add(list[j]);
			}
		}

		public void AddActionElementMap()
		{
			actionElementMaps.Add(pAaWZiXHkCJswzFJHIhPlTVAVRbA());
		}

		public void InsertActionElementMap(int index)
		{
			if (index < 0 || index >= actionElementMaps.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			actionElementMaps.Insert(index, pAaWZiXHkCJswzFJHIhPlTVAVRbA());
		}

		public void DeleteActionElementMap(int index)
		{
			if (actionElementMaps == null || index < 0 || index >= actionElementMaps.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			actionElementMaps.RemoveAt(index);
		}

		public bool ReorderActionElementMap(int index, bool offsetDown, bool offsetNow)
		{
			return ListTools.OffsetAtIndex(actionElementMaps, index, offsetDown, offsetNow);
		}

		public void DuplicateActionElementMap(int index)
		{
			if (actionElementMaps == null || index < 0 || index >= actionElementMaps.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			ActionElementMap item = new ActionElementMap(actionElementMaps[index]);
			if (index == actionElementMaps.Count - 1)
			{
				actionElementMaps.Add(item);
			}
			else
			{
				actionElementMaps.Insert(index + 1, item);
			}
		}

		private ActionElementMap pAaWZiXHkCJswzFJHIhPlTVAVRbA()
		{
			try
			{
				ControllerMap.QXFruTPDQsWAkpbQTcKsnAHJFyR();
				return new ActionElementMap
				{
					elementType = ControllerElementType.Button
				};
			}
			finally
			{
				ControllerMap.rzztgLcwyNrsBpkJvbDdCIBmMzrLA();
			}
		}
	}
}
