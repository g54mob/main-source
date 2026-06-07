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
		private sealed class XoWKrvBsbpmANiEuxrMFumUqKLTL : IEnumerable<ActionElementMap>, IEnumerable, IEnumerator<ActionElementMap>, IEnumerator, IDisposable
		{
			private int ddWjjDdLaPwtJXbQigCOygYWpzcF;

			private ActionElementMap geRHWDpFBTPIpOIjEfPwljISpqxw;

			private int gCYTLEFLbHXFYbJspTJlVKuwKrGS;

			public ControllerMap_Editor goCviVcCCLCSxIDWeuCdxNTZDuPF;

			private int AMvFwfjxpNPSlUKFXBXafAVtDIMr;

			ActionElementMap IEnumerator<ActionElementMap>.Current
			{
				[DebuggerHidden]
				get
				{
					return geRHWDpFBTPIpOIjEfPwljISpqxw;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return geRHWDpFBTPIpOIjEfPwljISpqxw;
				}
			}

			[DebuggerHidden]
			public XoWKrvBsbpmANiEuxrMFumUqKLTL(int P_0)
			{
				ddWjjDdLaPwtJXbQigCOygYWpzcF = P_0;
				gCYTLEFLbHXFYbJspTJlVKuwKrGS = Environment.CurrentManagedThreadId;
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				int num = ddWjjDdLaPwtJXbQigCOygYWpzcF;
				ControllerMap_Editor controllerMap_Editor = goCviVcCCLCSxIDWeuCdxNTZDuPF;
				switch (num)
				{
				default:
					return false;
				case 0:
					ddWjjDdLaPwtJXbQigCOygYWpzcF = -1;
					if (controllerMap_Editor.actionElementMaps == null)
					{
						return false;
					}
					AMvFwfjxpNPSlUKFXBXafAVtDIMr = 0;
					break;
				case 1:
					ddWjjDdLaPwtJXbQigCOygYWpzcF = -1;
					AMvFwfjxpNPSlUKFXBXafAVtDIMr++;
					break;
				}
				if (AMvFwfjxpNPSlUKFXBXafAVtDIMr < controllerMap_Editor.actionElementMaps.Count)
				{
					geRHWDpFBTPIpOIjEfPwljISpqxw = controllerMap_Editor.actionElementMaps[AMvFwfjxpNPSlUKFXBXafAVtDIMr];
					ddWjjDdLaPwtJXbQigCOygYWpzcF = 1;
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
				XoWKrvBsbpmANiEuxrMFumUqKLTL xoWKrvBsbpmANiEuxrMFumUqKLTL;
				if (ddWjjDdLaPwtJXbQigCOygYWpzcF == -2 && gCYTLEFLbHXFYbJspTJlVKuwKrGS == Environment.CurrentManagedThreadId)
				{
					ddWjjDdLaPwtJXbQigCOygYWpzcF = 0;
					xoWKrvBsbpmANiEuxrMFumUqKLTL = this;
				}
				else
				{
					xoWKrvBsbpmANiEuxrMFumUqKLTL = new XoWKrvBsbpmANiEuxrMFumUqKLTL(0);
					xoWKrvBsbpmANiEuxrMFumUqKLTL.goCviVcCCLCSxIDWeuCdxNTZDuPF = goCviVcCCLCSxIDWeuCdxNTZDuPF;
				}
				return xoWKrvBsbpmANiEuxrMFumUqKLTL;
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
			[IteratorStateMachine(typeof(XoWKrvBsbpmANiEuxrMFumUqKLTL))]
			get
			{
				return new XoWKrvBsbpmANiEuxrMFumUqKLTL(-2)
				{
					goCviVcCCLCSxIDWeuCdxNTZDuPF = this
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

		internal JoystickMap OSThkEJgppwEqjnQYyOXrfqBhcdcA(Func<int, bool> P_0, HardwareControllerMapIdentifier P_1, HardwareJoystickMap P_2, bool P_3)
		{
			JoystickMap joystickMap = new JoystickMap();
			qmJEtSIEnxLvJTcRKjLCUahOaYXpA(P_0, joystickMap, P_1, P_2, P_3);
			return joystickMap;
		}

		internal KeyboardMap TowmxrVCxqdBoaEtCUEoOvUPENnK(Func<int, bool> P_0)
		{
			KeyboardMap keyboardMap = new KeyboardMap();
			qmJEtSIEnxLvJTcRKjLCUahOaYXpA(P_0, keyboardMap, default(HardwareControllerMapIdentifier), null, false);
			return keyboardMap;
		}

		internal MouseMap JcTUrqplioXFtAVanvZqpUBNDcGN(Func<int, bool> P_0)
		{
			MouseMap mouseMap = new MouseMap();
			qmJEtSIEnxLvJTcRKjLCUahOaYXpA(P_0, mouseMap, default(HardwareControllerMapIdentifier), null, false);
			return mouseMap;
		}

		internal CustomControllerMap BIIuUgkFOESqiyyOLEOfEKNSzPco(Func<int, bool> P_0, CustomController_Editor P_1)
		{
			CustomControllerMap customControllerMap = new CustomControllerMap();
			NHCLohsjKWkkcvNBldKSavbqcFfXA(P_0, InputSource.Custom, customControllerMap, P_1);
			return customControllerMap;
		}

		internal ControllerTemplateMap MJclTqidCJXjXgMbBehgUUoPankGA()
		{
			if (!(ReInput.LWvlwHivxWHAlXYJITKbLqAajNas(hardwareGuid) is IHardwareControllerTemplateMap_Internal))
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
					ControllerTemplateActionElementMap controllerTemplateActionElementMap = ControllerTemplateActionElementMap.kijvlholgRWdaOdzpmVGxzirWRyB(actionElementMap);
					if (controllerTemplateActionElementMap != null)
					{
						controllerTemplateMap.fwozYspuYYQbMtMlWBkfjsMzhgiEb(controllerTemplateActionElementMap);
					}
				}
			}
			return controllerTemplateMap;
		}

		private void qmJEtSIEnxLvJTcRKjLCUahOaYXpA(Func<int, bool> P_0, ControllerMap P_1, HardwareControllerMapIdentifier P_2, HardwareJoystickMap P_3, bool P_4)
		{
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
				P_1.HPOsNbYEHzjGQhSFgJFXiksNXGln(actionElementMap);
			}
		}

		private void NHCLohsjKWkkcvNBldKSavbqcFfXA(Func<int, bool> P_0, InputSource P_1, CustomControllerMap P_2, CustomController_Editor P_3)
		{
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
				P_2.HPOsNbYEHzjGQhSFgJFXiksNXGln(actionElementMap);
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
					ActionElementMap item = new ActionElementMap(-1, pMvvECjJycyKibKKCAXEnFbBPTVk.kfijJzRINKFZsOSueMIhVWyLcRAf(elementIdentifier.elementType), elementIdentifier.id);
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
			actionElementMaps.Add(xwXxFuXCkrHnbAfmtnwiPxmgRGuIA());
		}

		public void InsertActionElementMap(int index)
		{
			if (index < 0 || index >= actionElementMaps.Count)
			{
				throw new ArgumentOutOfRangeException("index");
			}
			actionElementMaps.Insert(index, xwXxFuXCkrHnbAfmtnwiPxmgRGuIA());
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

		private ActionElementMap xwXxFuXCkrHnbAfmtnwiPxmgRGuIA()
		{
			return new ActionElementMap
			{
				elementType = ControllerElementType.Button
			};
		}
	}
}
