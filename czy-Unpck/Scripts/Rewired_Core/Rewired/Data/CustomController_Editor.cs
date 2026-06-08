using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Threading;
using Rewired.Data.Mapping;
using Rewired.Utils;
using UnityEngine;

namespace Rewired.Data
{
	[Serializable]
	[EditorBrowsable(EditorBrowsableState.Never)]
	[Browsable(false)]
	public sealed class CustomController_Editor
	{
		[Serializable]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public abstract class Element
		{
			public int elementIdentifierId;

			public string name;

			public Element()
			{
			}

			public Element(string name, int elementIdentifierId)
			{
				this.name = name;
				this.elementIdentifierId = elementIdentifierId;
			}

			public abstract Element Clone();
		}

		[Serializable]
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
		public sealed class Button : Element
		{
			public Button()
			{
			}

			public Button(string name)
				: base(name, -1)
			{
			}

			public Button(string name, int elementIdentifierId)
				: base(name, elementIdentifierId)
			{
			}

			public Button(Button source)
				: base(source.name, source.elementIdentifierId)
			{
			}

			public override Element Clone()
			{
				return new Button(this);
			}
		}

		[Serializable]
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public sealed class Axis : Element
		{
			public AxisRange range;

			public bool invert;

			public float deadZone;

			public float zero;

			public float min;

			public float max;

			public bool doNotCalibrateRange;

			public AxisSensitivityType sensitivityType;

			public float sensitivity = 1f;

			public AnimationCurve sensitivityCurve;

			public HardwareAxisInfo axisInfo = HardwareAxisInfo.Default;

			public Axis()
			{
			}

			public Axis(string name)
				: base(name, -1)
			{
				range = AxisRange.Full;
				invert = false;
				deadZone = 0f;
				zero = 0f;
				min = -1f;
				max = 1f;
				sensitivity = 1f;
				sensitivityType = AxisSensitivityType.Multiplier;
				sensitivityCurve = AnimationCurve.Linear(-1f, 1f, 1f, 1f);
				axisInfo = new HardwareAxisInfo(AxisCoordinateMode.Absolute, excludeFromPolling: false, -1f, SpecialAxisType.None);
			}

			[Obsolete("This constructor should not longer be used.", false)]
			public Axis(string name, string positiveName, string negativeName, int elementIdentifierId, AxisRange range, bool invert, float deadZone, float zero, float min, float max, bool doNotCalibrateRange, HardwareAxisInfo axisInfo)
				: base(name, elementIdentifierId)
			{
				while (true)
				{
					int num = 628831733;
					while (true)
					{
						switch (num ^ 0x257B35F1)
						{
						case 0:
							break;
						case 4:
							this.range = range;
							this.invert = invert;
							num = 628831731;
							continue;
						case 2:
							this.deadZone = deadZone;
							this.zero = zero;
							this.min = min;
							num = 628831732;
							continue;
						case 1:
							sensitivityType = AxisSensitivityType.Multiplier;
							num = 628831730;
							continue;
						case 5:
							this.max = max;
							this.doNotCalibrateRange = doNotCalibrateRange;
							this.axisInfo = MiscTools.DeepClone(axisInfo) ?? HardwareAxisInfo.Default;
							sensitivity = 1f;
							num = 628831728;
							continue;
						default:
							sensitivityCurve = AnimationCurve.Linear(-1f, 1f, 1f, 1f);
							return;
						}
						break;
					}
				}
			}

			public Axis(Axis source)
				: base(source.name, source.elementIdentifierId)
			{
				while (true)
				{
					int num = 74367054;
					while (true)
					{
						switch (num ^ 0x46EC04C)
						{
						case 3:
							break;
						case 2:
							range = source.range;
							invert = source.invert;
							deadZone = source.deadZone;
							zero = source.zero;
							min = source.min;
							max = source.max;
							doNotCalibrateRange = source.doNotCalibrateRange;
							num = 74367048;
							continue;
						case 4:
							sensitivity = source.sensitivity;
							num = 74367052;
							continue;
						case 0:
							sensitivityType = source.sensitivityType;
							sensitivityCurve = UnityTools.Copy(source.sensitivityCurve);
							num = 74367053;
							continue;
						default:
							axisInfo = MiscTools.DeepClone(source.axisInfo) ?? HardwareAxisInfo.Default;
							return;
						}
						break;
					}
				}
			}

			public override Element Clone()
			{
				return new Axis(this);
			}
		}

		private sealed class qQLdpXxAchXxmNeVKHluuVYrZWO : IDisposable, IEnumerable<ControllerElementIdentifier>, IEnumerator<ControllerElementIdentifier>, IEnumerator, IEnumerable
		{
			private ControllerElementIdentifier ubyTdixGSFKGaFQFZdQnpwgWIvJ;

			private int isaqVUvqwfWYqOUtovbpbCbxgPc;

			private int TFdbdCIUKXTQPHFlNuiMVnWNXiVT;

			public CustomController_Editor syCPfFbHYMDOvEPjTnPLBqiOhsPv;

			public int PSmjXiTtTWKPkmLbUbHkvOzjvZk;

			ControllerElementIdentifier IEnumerator<ControllerElementIdentifier>.Current
			{
				[DebuggerHidden]
				get
				{
					return ubyTdixGSFKGaFQFZdQnpwgWIvJ;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return ubyTdixGSFKGaFQFZdQnpwgWIvJ;
				}
			}

			[DebuggerHidden]
			IEnumerator<ControllerElementIdentifier> IEnumerable<ControllerElementIdentifier>.GetEnumerator()
			{
				if (Thread.CurrentThread.ManagedThreadId == TFdbdCIUKXTQPHFlNuiMVnWNXiVT && isaqVUvqwfWYqOUtovbpbCbxgPc == -2)
				{
					goto IL_001c;
				}
				goto IL_004e;
				IL_004e:
				qQLdpXxAchXxmNeVKHluuVYrZWO qQLdpXxAchXxmNeVKHluuVYrZWO2 = new qQLdpXxAchXxmNeVKHluuVYrZWO(0);
				qQLdpXxAchXxmNeVKHluuVYrZWO2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = syCPfFbHYMDOvEPjTnPLBqiOhsPv;
				int num = 318420187;
				goto IL_0021;
				IL_001c:
				num = 318420186;
				goto IL_0021;
				IL_0021:
				while (true)
				{
					switch (num ^ 0x12FAB4DB)
					{
					case 3:
						break;
					case 1:
						isaqVUvqwfWYqOUtovbpbCbxgPc = 0;
						qQLdpXxAchXxmNeVKHluuVYrZWO2 = this;
						num = 318420187;
						continue;
					case 2:
						goto IL_004e;
					default:
						return qQLdpXxAchXxmNeVKHluuVYrZWO2;
					}
					break;
				}
				goto IL_001c;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ControllerElementIdentifier>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				int num = isaqVUvqwfWYqOUtovbpbCbxgPc;
				while (true)
				{
					int num2 = -1419729936;
					while (true)
					{
						switch (num2 ^ -1419729931)
						{
						case 6:
							break;
						case 4:
						{
							int num4;
							if (PSmjXiTtTWKPkmLbUbHkvOzjvZk < syCPfFbHYMDOvEPjTnPLBqiOhsPv._elementIdentifiers.Count)
							{
								num2 = -1419729932;
								num4 = num2;
							}
							else
							{
								num2 = -1419729931;
								num4 = num2;
							}
							continue;
						}
						case 3:
							num2 = -1419729935;
							continue;
						case 5:
							switch (num)
							{
							default:
								num2 = -1419729931;
								continue;
							case 0:
								break;
							case 1:
								isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
								PSmjXiTtTWKPkmLbUbHkvOzjvZk++;
								num2 = -1419729935;
								continue;
							}
							goto case 7;
						case 7:
						{
							isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
							int num3;
							if (syCPfFbHYMDOvEPjTnPLBqiOhsPv._elementIdentifiers == null)
							{
								num2 = -1419729931;
								num3 = num2;
							}
							else
							{
								num2 = -1419729929;
								num3 = num2;
							}
							continue;
						}
						case 1:
							ubyTdixGSFKGaFQFZdQnpwgWIvJ = syCPfFbHYMDOvEPjTnPLBqiOhsPv._elementIdentifiers[PSmjXiTtTWKPkmLbUbHkvOzjvZk];
							isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
							return true;
						case 2:
							PSmjXiTtTWKPkmLbUbHkvOzjvZk = 0;
							num2 = -1419729930;
							continue;
						default:
							return false;
						}
						break;
					}
				}
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

			void IDisposable.Dispose()
			{
			}

			[DebuggerHidden]
			public qQLdpXxAchXxmNeVKHluuVYrZWO(int _003C_003E1__state)
			{
				while (true)
				{
					int num = 1879303177;
					while (true)
					{
						switch (num ^ 0x7003E40B)
						{
						case 0:
							break;
						default:
							return;
						case 2:
							goto IL_0024;
						case 1:
							return;
						}
						break;
						IL_0024:
						isaqVUvqwfWYqOUtovbpbCbxgPc = _003C_003E1__state;
						TFdbdCIUKXTQPHFlNuiMVnWNXiVT = Thread.CurrentThread.ManagedThreadId;
						num = 1879303178;
					}
				}
			}
		}

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private string _name;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private string _descriptiveName;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private int _id;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string _typeGuidString;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<ControllerElementIdentifier> _elementIdentifiers;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<Axis> _axes;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private List<Button> _buttons;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private int _elementIdentifierIdCounter;

		public string name
		{
			get
			{
				return _name;
			}
			internal set
			{
				_name = value;
			}
		}

		public string descriptiveName
		{
			get
			{
				return _descriptiveName;
			}
			internal set
			{
				_descriptiveName = value;
			}
		}

		public int id
		{
			get
			{
				return _id;
			}
			internal set
			{
				_id = value;
			}
		}

		public Guid typeGuid
		{
			get
			{
				return StringTools.ToGuid(_typeGuidString);
			}
			internal set
			{
				_typeGuidString = value.ToString();
			}
		}

		internal string typeGuidString
		{
			get
			{
				return _typeGuidString;
			}
			set
			{
				_typeGuidString = value;
			}
		}

		public List<ControllerElementIdentifier> elementIdentifiers
		{
			get
			{
				return _elementIdentifiers;
			}
			internal set
			{
				_elementIdentifiers = value;
			}
		}

		public List<Axis> axes => _axes;

		public List<Button> buttons => _buttons;

		public int buttonCount
		{
			get
			{
				if (buttons == null)
				{
					return 0;
				}
				return buttons.Count;
			}
		}

		public int axisCount
		{
			get
			{
				if (axes == null)
				{
					return 0;
				}
				return axes.Count;
			}
		}

		public IEnumerable<ControllerElementIdentifier> ElementIdentifiers
		{
			get
			{
				qQLdpXxAchXxmNeVKHluuVYrZWO qQLdpXxAchXxmNeVKHluuVYrZWO2 = new qQLdpXxAchXxmNeVKHluuVYrZWO(-2);
				qQLdpXxAchXxmNeVKHluuVYrZWO2.syCPfFbHYMDOvEPjTnPLBqiOhsPv = this;
				return qQLdpXxAchXxmNeVKHluuVYrZWO2;
			}
		}

		public CustomController_Editor()
		{
			while (true)
			{
				int num = -1342363992;
				while (true)
				{
					switch (num ^ -1342363991)
					{
					case 2:
						break;
					case 1:
						_axes = new List<Axis>();
						num = -1342363991;
						continue;
					case 0:
						_buttons = new List<Button>();
						num = -1342363990;
						continue;
					default:
						_elementIdentifiers = new List<ControllerElementIdentifier>();
						return;
					}
					break;
				}
			}
		}

		public CustomController_Editor(CustomController_Editor source)
		{
			_name = source._name;
			_descriptiveName = source._descriptiveName;
			_id = source._id;
			_typeGuidString = source._typeGuidString;
			if (source._elementIdentifiers != null)
			{
				_elementIdentifiers = new List<ControllerElementIdentifier>(source._elementIdentifiers.Count);
				for (int i = 0; i < source._elementIdentifiers.Count; i++)
				{
					_elementIdentifiers.Add(source._elementIdentifiers[i].Clone());
				}
			}
			if (source._axes != null)
			{
				_axes = new List<Axis>(source._axes.Count);
				for (int j = 0; j < source._axes.Count; j++)
				{
					_axes.Add((Axis)source._axes[j].Clone());
				}
			}
			if (source._buttons != null)
			{
				_buttons = new List<Button>(source._buttons.Count);
				for (int k = 0; k < source._buttons.Count; k++)
				{
					_buttons.Add((Button)source._buttons[k].Clone());
				}
			}
			_elementIdentifierIdCounter = source._elementIdentifierIdCounter;
		}

		public CustomController_Editor Clone()
		{
			return new CustomController_Editor(this);
		}

		public string[] GetElementIdentifierNames()
		{
			int num = ((_elementIdentifiers != null) ? _elementIdentifiers.Count : 0);
			int num3 = default(int);
			string[] array = default(string[]);
			while (true)
			{
				int num2 = -1746294915;
				while (true)
				{
					switch (num2 ^ -1746294916)
					{
					case 0:
						break;
					case 4:
					{
						int num4;
						if (num3 < num)
						{
							num2 = -1746294914;
							num4 = num2;
						}
						else
						{
							num2 = -1746294913;
							num4 = num2;
						}
						continue;
					}
					case 2:
						array[num3] = _elementIdentifiers[num3].name;
						num3++;
						num2 = -1746294920;
						continue;
					case 1:
						array = new string[num];
						num3 = 0;
						num2 = -1746294920;
						continue;
					default:
						return array;
					}
					break;
				}
			}
		}

		public int[] GetElementIdentifierIds()
		{
			int num = ((_elementIdentifiers != null) ? _elementIdentifiers.Count : 0);
			int[] array = new int[num];
			int num3 = default(int);
			while (true)
			{
				int num2 = 472188229;
				while (true)
				{
					switch (num2 ^ 0x1C250540)
					{
					case 4:
						break;
					case 5:
						num3 = 0;
						num2 = 472188227;
						continue;
					case 3:
						num2 = 472188226;
						continue;
					case 0:
						num3++;
						num2 = 472188226;
						continue;
					case 1:
						array[num3] = _elementIdentifiers[num3].id;
						num2 = 472188224;
						continue;
					default:
						if (num3 >= num)
						{
							return array;
						}
						goto case 1;
					}
					break;
				}
			}
		}

		public string[] GetElementIdentifierNamesTypeSorted()
		{
			List<string> list = new List<string>();
			List<string> list2 = new List<string>();
			int num = axisCount;
			int num2 = 0;
			int num5 = default(int);
			int num6 = default(int);
			int num4 = default(int);
			List<string> list3 = default(List<string>);
			while (true)
			{
				int num3 = -615070955;
				while (true)
				{
					switch (num3 ^ -615070958)
					{
					case 5:
						break;
					case 10:
						num5++;
						num3 = -615070958;
						continue;
					case 1:
						if (num6 >= 0)
						{
							list.Add(_elementIdentifiers[num6].name);
							num3 = -615070952;
							continue;
						}
						goto case 10;
					case 2:
						num2++;
						num3 = -615070954;
						continue;
					case 9:
					{
						int num8 = IndexOfElementIdentifier(axes[num2].elementIdentifierId);
						if (num8 >= 0)
						{
							list2.Add(_elementIdentifiers[num8].name);
							num3 = -615070960;
							continue;
						}
						goto case 2;
					}
					case 4:
					{
						int num7;
						if (num2 < num)
						{
							num3 = -615070949;
							num7 = num3;
						}
						else
						{
							num3 = -615070959;
							num7 = num3;
						}
						continue;
					}
					case 6:
						num6 = IndexOfElementIdentifier(buttons[num5].elementIdentifierId);
						num3 = -615070957;
						continue;
					case 0:
						if (num5 >= num4)
						{
							list3 = ListTools.Combine(list2, list);
							num3 = -615070950;
							continue;
						}
						goto case 6;
					case 7:
						num3 = -615070954;
						continue;
					case 3:
						num4 = buttonCount;
						num5 = 0;
						num3 = -615070958;
						continue;
					default:
						return list3.ToArray();
					}
					break;
				}
			}
		}

		public int[] GetElementIdentifierIdsTypeSorted()
		{
			List<int> list = new List<int>();
			List<int> list2 = new List<int>();
			int num = axisCount;
			int num3 = default(int);
			int num4 = default(int);
			int num5 = default(int);
			while (true)
			{
				int num2 = -1478269956;
				while (true)
				{
					switch (num2 ^ -1478269955)
					{
					case 3:
						break;
					case 6:
						num3 = 0;
						num2 = -1478269955;
						continue;
					case 0:
						num2 = -1478269958;
						continue;
					case 2:
						if (num4 >= num)
						{
							num5 = buttonCount;
							num2 = -1478269957;
							continue;
						}
						goto case 4;
					case 7:
					{
						int num6;
						if (num3 < num5)
						{
							num2 = -1478269960;
							num6 = num2;
						}
						else
						{
							num2 = -1478269963;
							num6 = num2;
						}
						continue;
					}
					case 4:
						list2.Add(axes[num4].elementIdentifierId);
						num4++;
						num2 = -1478269953;
						continue;
					case 1:
						num4 = 0;
						num2 = -1478269953;
						continue;
					case 5:
						list.Add(buttons[num3].elementIdentifierId);
						num3++;
						num2 = -1478269958;
						continue;
					default:
					{
						List<int> list3 = ListTools.Combine(list2, list);
						return list3.ToArray();
					}
					}
					break;
				}
			}
		}

		public ControllerElementIdentifier[] GetElementIdentifiersTypeSorted()
		{
			List<ControllerElementIdentifier> list = new List<ControllerElementIdentifier>();
			List<ControllerElementIdentifier> list2 = new List<ControllerElementIdentifier>();
			int num = axisCount;
			int num2 = 0;
			int num8 = default(int);
			int num6 = default(int);
			int num5 = default(int);
			while (true)
			{
				int num3;
				int num4;
				if (num2 < num)
				{
					num3 = 1526201859;
					num4 = num3;
				}
				else
				{
					num3 = 1526201858;
					num4 = num3;
				}
				while (true)
				{
					switch (num3 ^ 0x5AF7FE06)
					{
					case 9:
						num3 = 1526201859;
						continue;
					case 5:
					{
						int num9 = IndexOfElementIdentifier(axes[num2].elementIdentifierId);
						if (num9 >= 0)
						{
							list2.Add(_elementIdentifiers[num9]);
							num3 = 1526201870;
							continue;
						}
						goto case 8;
					}
					case 7:
						break;
					case 4:
						num8 = buttonCount;
						num6 = 0;
						num3 = 1526201861;
						continue;
					case 8:
						num2++;
						num3 = 1526201857;
						continue;
					case 1:
						num6++;
						num3 = 1526201861;
						continue;
					case 3:
					{
						int num10;
						if (num6 < num8)
						{
							num3 = 1526201856;
							num10 = num3;
						}
						else
						{
							num3 = 1526201862;
							num10 = num3;
						}
						continue;
					}
					case 6:
					{
						num5 = IndexOfElementIdentifier(buttons[num6].elementIdentifierId);
						int num7;
						if (num5 < 0)
						{
							num3 = 1526201863;
							num7 = num3;
						}
						else
						{
							num3 = 1526201860;
							num7 = num3;
						}
						continue;
					}
					case 2:
						list.Add(_elementIdentifiers[num5]);
						num3 = 1526201863;
						continue;
					default:
					{
						List<ControllerElementIdentifier> list3 = ListTools.Combine(list2, list);
						return list3.ToArray();
					}
					}
					break;
				}
			}
		}

		public bool ContainsElementIdentifier(int id)
		{
			int num = ((_elementIdentifiers != null) ? _elementIdentifiers.Count : 0);
			int num2 = 0;
			while (true)
			{
				int num3;
				int num4;
				if (num2 < num)
				{
					num3 = 1345806213;
					num4 = num3;
				}
				else
				{
					num3 = 1345806212;
					num4 = num3;
				}
				while (true)
				{
					switch (num3 ^ 0x50375F87)
					{
					case 0:
						num3 = 1345806213;
						continue;
					case 2:
						if (_elementIdentifiers[num2].id == id)
						{
							return true;
						}
						num2++;
						num3 = 1345806214;
						continue;
					case 1:
						break;
					default:
						return false;
					}
					break;
				}
			}
		}

		public int IndexOfElementIdentifier(int id)
		{
			int num = ((_elementIdentifiers != null) ? _elementIdentifiers.Count : 0);
			int num2 = 0;
			while (num2 < num)
			{
				while (true)
				{
					int num3;
					if (_elementIdentifiers[num2].id == id)
					{
						num3 = -35172017;
					}
					else
					{
						num2++;
						num3 = -35172019;
					}
					while (true)
					{
						switch (num3 ^ -35172019)
						{
						case 3:
							num3 = -35172020;
							continue;
						case 1:
							break;
						case 2:
							return num2;
						default:
							goto end_IL_003d;
						}
						break;
					}
					continue;
					end_IL_003d:
					break;
				}
			}
			return -1;
		}

		public ControllerElementIdentifier GetElementIdentifier(int id)
		{
			int num = IndexOfElementIdentifier(id);
			if (num < 0)
			{
				return null;
			}
			return _elementIdentifiers[num];
		}

		internal ControllerElementType loiHwkZMyULPlmMqMwZHkOrXnOI(int P_0)
		{
			ControllerElementIdentifier elementIdentifier = GetElementIdentifier(P_0);
			if (elementIdentifier == null)
			{
				goto IL_000b;
			}
			int num = 0;
			int num2 = -955307693;
			goto IL_0010;
			IL_0010:
			int num3 = default(int);
			while (true)
			{
				switch (num2 ^ -955307694)
				{
				case 0:
					break;
				case 2:
					return ControllerElementType.Axis;
				case 4:
					if (axes[num].elementIdentifierId == elementIdentifier.id)
					{
						return ControllerElementType.Axis;
					}
					num++;
					num2 = -955307693;
					continue;
				case 1:
					if (num >= axisCount)
					{
						num3 = 0;
						num2 = -955307692;
						continue;
					}
					goto case 4;
				case 3:
					if (buttons[num3].elementIdentifierId == elementIdentifier.id)
					{
						return ControllerElementType.Button;
					}
					num3++;
					num2 = -955307689;
					continue;
				case 6:
					num2 = -955307689;
					continue;
				default:
					if (num3 >= buttonCount)
					{
						return elementIdentifier.elementType;
					}
					goto case 3;
				}
				break;
			}
			goto IL_000b;
			IL_000b:
			num2 = -955307696;
			goto IL_0010;
		}

		internal bool tbkpOYXsyLsKGmqGKIoZzbeoYEK(int P_0, out AxisRange P_1)
		{
			ControllerElementIdentifier elementIdentifier = GetElementIdentifier(P_0);
			int num2 = default(int);
			while (true)
			{
				int num = -884402155;
				while (true)
				{
					switch (num ^ -884402153)
					{
					case 7:
						break;
					case 0:
						if (axes[num2].elementIdentifierId == elementIdentifier.id)
						{
							P_1 = axes[num2].range;
							int num3;
							if (axes[num2].invert)
							{
								num = -884402154;
								num3 = num;
							}
							else
							{
								num = -884402158;
								num3 = num;
							}
						}
						else
						{
							num2++;
							num = -884402156;
						}
						continue;
					case 3:
						if (num2 >= axisCount)
						{
							P_1 = AxisRange.Full;
							num = -884402159;
							continue;
						}
						goto case 0;
					case 1:
						P_1 = InputTools.InvertAxisRange(P_1);
						num = -884402158;
						continue;
					case 2:
						if (elementIdentifier == null)
						{
							num = -884402157;
							continue;
						}
						num2 = 0;
						num = -884402156;
						continue;
					case 5:
						return true;
					case 4:
						P_1 = AxisRange.Full;
						return false;
					default:
						return false;
					}
					break;
				}
			}
		}

		public string[] GetButtonNames()
		{
			if (_buttons == null)
			{
				goto IL_0008;
			}
			int num = _buttons.Count;
			goto IL_006f;
			IL_0061:
			num = 0;
			goto IL_006f;
			IL_0008:
			int num2 = 1931731736;
			goto IL_000d;
			IL_000d:
			int num3 = default(int);
			string[] array = default(string[]);
			int num4 = default(int);
			while (true)
			{
				switch (num2 ^ 0x7323E31C)
				{
				case 5:
					break;
				case 2:
					num3++;
					num2 = 1931731743;
					continue;
				case 1:
					num3 = 0;
					num2 = 1931731743;
					continue;
				case 0:
					array[num3] = _buttons[num3].name;
					num2 = 1931731742;
					continue;
				case 4:
					goto IL_0061;
				default:
					if (num3 >= num4)
					{
						return array;
					}
					goto case 0;
				}
				break;
			}
			goto IL_0008;
			IL_006f:
			num4 = num;
			array = new string[num4];
			num2 = 1931731741;
			goto IL_000d;
		}

		public int[] GetButtonElementIdentifierIds()
		{
			int num = ((_buttons != null) ? _buttons.Count : 0);
			int[] array = new int[num];
			int num3 = default(int);
			while (true)
			{
				int num2 = -32622726;
				while (true)
				{
					switch (num2 ^ -32622725)
					{
					case 2:
						break;
					case 1:
						num3 = 0;
						num2 = -32622725;
						continue;
					case 3:
						array[num3] = _buttons[num3].elementIdentifierId;
						num3++;
						num2 = -32622725;
						continue;
					default:
						if (num3 >= num)
						{
							return array;
						}
						goto case 3;
					}
					break;
				}
			}
		}

		public string[] GetAxisNames()
		{
			if (_axes == null)
			{
				goto IL_0008;
			}
			int num = _axes.Count;
			goto IL_0040;
			IL_0032:
			num = 0;
			goto IL_0040;
			IL_0008:
			int num2 = -776864215;
			goto IL_000d;
			IL_000d:
			int num3 = default(int);
			string[] array = default(string[]);
			int num4 = default(int);
			while (true)
			{
				switch (num2 ^ -776864216)
				{
				case 2:
					break;
				case 1:
					goto IL_0032;
				case 0:
					num3 = 0;
					num2 = -776864211;
					continue;
				case 3:
					array[num3] = _axes[num3].name;
					num3++;
					num2 = -776864212;
					continue;
				case 5:
					num2 = -776864212;
					continue;
				default:
					if (num3 >= num4)
					{
						return array;
					}
					goto case 3;
				}
				break;
			}
			goto IL_0008;
			IL_0040:
			num4 = num;
			array = new string[num4];
			num2 = -776864216;
			goto IL_000d;
		}

		public int[] GetAxisElementIdentifierIds()
		{
			int num = ((_axes != null) ? _axes.Count : 0);
			int[] array = new int[num];
			int num3 = default(int);
			while (true)
			{
				int num2 = 1413217096;
				while (true)
				{
					switch (num2 ^ 0x543BFB4B)
					{
					case 5:
						break;
					case 3:
						num3 = 0;
						num2 = 1413217099;
						continue;
					case 0:
					{
						int num4;
						if (num3 >= num)
						{
							num2 = 1413217097;
							num4 = num2;
						}
						else
						{
							num2 = 1413217103;
							num4 = num2;
						}
						continue;
					}
					case 1:
						num3++;
						num2 = 1413217099;
						continue;
					case 4:
						array[num3] = _axes[num3].elementIdentifierId;
						num2 = 1413217098;
						continue;
					default:
						return array;
					}
					break;
				}
			}
		}

		public string[] GetElementNames<T>() where T : Element
		{
			if (object.ReferenceEquals(typeof(T), typeof(Axis)))
			{
				return GetAxisNames();
			}
			if (object.ReferenceEquals(typeof(T), typeof(Button)))
			{
				return GetButtonNames();
			}
			throw new NotImplementedException();
		}

		public string[] GetElementNames(ControllerElementType type)
		{
			switch (type)
			{
			case ControllerElementType.Axis:
				return GetAxisNames();
			case ControllerElementType.Button:
				return GetButtonNames();
			default:
				throw new NotImplementedException();
			}
		}

		public int[] GetElementElementIdentifierIds(ControllerElementType type)
		{
			switch (type)
			{
			case ControllerElementType.Axis:
				return GetAxisElementIdentifierIds();
			case ControllerElementType.Button:
				return GetButtonElementIdentifierIds();
			default:
				throw new NotImplementedException();
			}
		}

		public T GetElement<T>(int index) where T : Element
		{
			T result = default(T);
			if (index < 0)
			{
				result = null;
				goto IL_000c;
			}
			if (object.ReferenceEquals(typeof(T), typeof(Axis)))
			{
				if (index >= axisCount)
				{
					return null;
				}
				return _axes[index] as T;
			}
			int num;
			if (object.ReferenceEquals(typeof(T), typeof(Button)))
			{
				if (index >= buttonCount)
				{
					num = -96729229;
					goto IL_0011;
				}
				return _buttons[index] as T;
			}
			throw new NotImplementedException();
			IL_0011:
			switch (num ^ -96729229)
			{
			case 2:
				break;
			case 1:
				return result;
			default:
				return null;
			}
			goto IL_000c;
			IL_000c:
			num = -96729230;
			goto IL_0011;
		}

		public void AddElement(ControllerElementType type)
		{
			if (type == ControllerElementType.Axis)
			{
				goto IL_0003;
			}
			goto IL_0033;
			IL_0003:
			int num = 765821237;
			goto IL_0008;
			IL_0008:
			switch (num ^ 0x2DA58134)
			{
			case 0:
				break;
			default:
				return;
			case 1:
				AddAxis();
				return;
			case 2:
				goto IL_0033;
			case 3:
				return;
			}
			goto IL_0003;
			IL_0033:
			AddButton();
			num = 765821239;
			goto IL_0008;
		}

		public void AddAxis()
		{
			axes.Add((Axis)FEgsqTAJHxuBwrWvbQKlJHwQxLA(ControllerElementType.Axis));
		}

		public void AddButton()
		{
			buttons.Add((Button)FEgsqTAJHxuBwrWvbQKlJHwQxLA(ControllerElementType.Button));
		}

		public void InsertElement(ControllerElementType type, int index)
		{
			if (type == ControllerElementType.Axis)
			{
				InsertAxis(index);
				while (true)
				{
					switch (0x1DCA03FC ^ 0x1DCA03FD)
					{
					case 0:
						continue;
					case 1:
						return;
					}
					break;
				}
			}
			InsertButton(index);
		}

		public void InsertAxis(int index)
		{
			if (index < 0)
			{
				goto IL_0034;
			}
			if (index >= axes.Count)
			{
				goto IL_0012;
			}
			goto IL_0046;
			IL_0034:
			throw new ArgumentOutOfRangeException("index");
			IL_0012:
			int num = -392479346;
			goto IL_0017;
			IL_0017:
			switch (num ^ -392479348)
			{
			case 0:
				break;
			default:
				return;
			case 2:
				goto IL_0034;
			case 1:
				goto IL_0046;
			case 3:
				return;
			}
			goto IL_0012;
			IL_0046:
			axes.Insert(index, (Axis)FEgsqTAJHxuBwrWvbQKlJHwQxLA(ControllerElementType.Axis));
			num = -392479345;
			goto IL_0017;
		}

		public void InsertButton(int index)
		{
			if (index < 0)
			{
				goto IL_0034;
			}
			if (index >= buttons.Count)
			{
				goto IL_0012;
			}
			goto IL_0046;
			IL_0034:
			throw new ArgumentOutOfRangeException("index");
			IL_0012:
			int num = 1709142484;
			goto IL_0017;
			IL_0017:
			switch (num ^ 0x65DF71D5)
			{
			case 2:
				break;
			default:
				return;
			case 1:
				goto IL_0034;
			case 0:
				goto IL_0046;
			case 3:
				return;
			}
			goto IL_0012;
			IL_0046:
			buttons.Insert(index, (Button)FEgsqTAJHxuBwrWvbQKlJHwQxLA(ControllerElementType.Button));
			num = 1709142486;
			goto IL_0017;
		}

		public void DeleteElement(ControllerElementType type, int index)
		{
			if (type == ControllerElementType.Axis)
			{
				DeleteElement<Axis>(index);
				return;
			}
			while (type == ControllerElementType.Button)
			{
				DeleteElement<Button>(index);
				int num = -1397612901;
				while (true)
				{
					switch (num ^ -1397612903)
					{
					case 3:
						num = -1397612904;
						continue;
					case 1:
						break;
					case 2:
						return;
					default:
						goto end_IL_002d;
					}
					break;
				}
				continue;
				end_IL_002d:
				break;
			}
			throw new NotImplementedException();
		}

		public void DeleteElement<T>(int index) where T : Element
		{
			if (index < 0)
			{
				goto IL_0007;
			}
			goto IL_0100;
			IL_0007:
			int num = 843006906;
			goto IL_000c;
			IL_000c:
			int num2 = default(int);
			T val = default(T);
			while (true)
			{
				switch (num ^ 0x323F43BB)
				{
				case 0:
					break;
				default:
					return;
				case 4:
					return;
				case 13:
					if (_elementIdentifiers[num2].id == val.elementIdentifierId)
					{
						_elementIdentifiers.RemoveAt(num2);
						num = 843006909;
						continue;
					}
					goto case 6;
				case 7:
					if (_elementIdentifiers != null)
					{
						num2 = _elementIdentifiers.Count - 1;
						num = 843006910;
						continue;
					}
					return;
				case 3:
					goto IL_00b7;
				case 12:
					val = _buttons[index] as T;
					num = 843006898;
					continue;
				case 6:
					num2--;
					num = 843006905;
					continue;
				case 5:
					num = 843006905;
					continue;
				case 11:
					goto IL_0100;
				case 1:
					return;
				case 9:
					_buttons.RemoveAt(index);
					num = 843006908;
					continue;
				case 10:
					goto IL_0150;
				case 14:
					goto IL_018b;
				case 2:
					goto IL_01b8;
				case 8:
					return;
				}
				break;
				IL_01b8:
				int num3;
				if (num2 >= 0)
				{
					num = 843006902;
					num3 = num;
				}
				else
				{
					num = 843006899;
					num3 = num;
				}
			}
			goto IL_0007;
			IL_0100:
			if (!object.ReferenceEquals(typeof(T), typeof(Axis)))
			{
				goto IL_0150;
			}
			if (index >= axisCount)
			{
				return;
			}
			goto IL_018b;
			IL_0150:
			if (object.ReferenceEquals(typeof(T), typeof(Button)))
			{
				int num4;
				if (index >= buttonCount)
				{
					num = 843006911;
					num4 = num;
				}
				else
				{
					num = 843006903;
					num4 = num;
				}
				goto IL_000c;
			}
			goto IL_00b7;
			IL_00b7:
			throw new NotImplementedException();
			IL_018b:
			val = _axes[index] as T;
			_axes.RemoveAt(index);
			num = 843006908;
			goto IL_000c;
		}

		public bool ReorderElement(ControllerElementType type, int index, bool offsetDown, bool offsetNow)
		{
			List<Axis> list = default(List<Axis>);
			if (type == ControllerElementType.Axis)
			{
				list = _axes;
				if (list != null)
				{
					goto IL_000d;
				}
				goto IL_0047;
			}
			List<Button> list2 = default(List<Button>);
			int num;
			if (type == ControllerElementType.Button)
			{
				list2 = _buttons;
				int num2;
				if (list2 == null)
				{
					num = -141625852;
					num2 = num;
				}
				else
				{
					num = -141625856;
					num2 = num;
				}
				goto IL_0012;
			}
			throw new NotImplementedException();
			IL_0012:
			while (true)
			{
				switch (num ^ -141625856)
				{
				case 3:
					break;
				case 1:
					goto IL_0033;
				case 2:
					goto IL_0047;
				case 0:
					if (index >= 0)
					{
						goto IL_0077;
					}
					goto default;
				default:
					return false;
				}
				break;
				IL_0077:
				if (index >= list2.Count)
				{
					num = -141625852;
					continue;
				}
				return ListTools.OffsetAtIndex(list2, index, offsetDown, offsetNow);
				IL_0033:
				if (index >= 0)
				{
					if (index >= list.Count)
					{
						num = -141625854;
						continue;
					}
					return ListTools.OffsetAtIndex(list, index, offsetDown, offsetNow);
				}
				goto IL_0047;
			}
			goto IL_000d;
			IL_000d:
			num = -141625855;
			goto IL_0012;
			IL_0047:
			return false;
		}

		public void DuplicateElement(ControllerElementType type, int index)
		{
			if (type == ControllerElementType.Axis)
			{
				goto IL_0003;
			}
			goto IL_0053;
			IL_0003:
			int num = 1874555792;
			goto IL_0008;
			IL_0008:
			switch (num ^ 0x6FBB7391)
			{
			case 0:
				break;
			case 1:
				EmnsGMlzbzMAkIydYylAjHkvBqM(index, axes);
				return;
			case 2:
				EmnsGMlzbzMAkIydYylAjHkvBqM(index, buttons);
				return;
			case 3:
				goto IL_0053;
			default:
				throw new NotImplementedException();
			}
			goto IL_0003;
			IL_0053:
			int num2;
			if (type != ControllerElementType.Button)
			{
				num = 1874555797;
				num2 = num;
			}
			else
			{
				num = 1874555795;
				num2 = num;
			}
			goto IL_0008;
		}

		private void EmnsGMlzbzMAkIydYylAjHkvBqM<T>(int P_0, List<T> P_1) where T : Element
		{
			if (P_1 != null && P_0 >= 0)
			{
				if (P_0 >= P_1.Count)
				{
					goto IL_0016;
				}
				goto IL_0057;
			}
			goto IL_0096;
			IL_0096:
			throw new ArgumentOutOfRangeException("index");
			IL_0057:
			T val = P_1[P_0];
			string text = StringTools.IterateName(val.name, -1, GetElementNames<T>());
			int num = 1928922798;
			goto IL_001b;
			IL_0016:
			num = 1928922787;
			goto IL_001b;
			IL_001b:
			T val2 = default(T);
			ControllerElementIdentifier controllerElementIdentifier = default(ControllerElementIdentifier);
			while (true)
			{
				switch (num ^ 0x72F906A6)
				{
				case 2:
					break;
				case 0:
					return;
				case 3:
					goto IL_0057;
				case 6:
					val2.elementIdentifierId = controllerElementIdentifier.id;
					num = 1928922791;
					continue;
				case 5:
					goto IL_0096;
				case 8:
					controllerElementIdentifier = JTfHNpYRWBtKLEJvOAvFGhCejhn(val.elementIdentifierId, text);
					if (controllerElementIdentifier == null)
					{
						Logger.LogError("Element identifier is missing! Element cannot be duplicated!");
						return;
					}
					goto case 4;
				case 4:
					val2 = (T)val.Clone();
					num = 1928922784;
					continue;
				case 1:
					val2.name = text;
					if (P_0 == P_1.Count - 1)
					{
						P_1.Add(val2);
						num = 1928922790;
						continue;
					}
					goto default;
				default:
					P_1.Insert(P_0 + 1, val2);
					return;
				}
				break;
			}
			goto IL_0016;
		}

		private ControllerElementIdentifier JTfHNpYRWBtKLEJvOAvFGhCejhn(int P_0, string P_1)
		{
			if (!ContainsElementIdentifier(P_0))
			{
				goto IL_000c;
			}
			int num = IndexOfElementIdentifier(P_0);
			int elementIdentifierIdCounter = _elementIdentifierIdCounter;
			int num2 = 562170759;
			goto IL_0011;
			IL_0011:
			ControllerElementIdentifier controllerElementIdentifier = default(ControllerElementIdentifier);
			while (true)
			{
				switch (num2 ^ 0x21820B87)
				{
				case 2:
					break;
				case 6:
					_elementIdentifiers.Insert(num + 1, controllerElementIdentifier);
					num2 = 562170758;
					continue;
				case 0:
					_elementIdentifierIdCounter++;
					num2 = 562170754;
					continue;
				case 5:
					controllerElementIdentifier = new ControllerElementIdentifier(elementIdentifierIdCounter, P_1, _elementIdentifiers[num].positiveName, _elementIdentifiers[num].negativeName, _elementIdentifiers[num].elementType, _elementIdentifiers[num].compoundElementType, _elementIdentifiers[num].isMappableOnPlatform);
					if (num == _elementIdentifiers.Count - 1)
					{
						_elementIdentifiers.Add(controllerElementIdentifier);
						num2 = 562170756;
						continue;
					}
					goto case 6;
				case 4:
					return null;
				case 3:
					num2 = 562170758;
					continue;
				default:
					return controllerElementIdentifier;
				}
				break;
			}
			goto IL_000c;
			IL_000c:
			num2 = 562170755;
			goto IL_0011;
		}

		private Element FEgsqTAJHxuBwrWvbQKlJHwQxLA(ControllerElementType P_0)
		{
			string text = default(string);
			if (P_0 == ControllerElementType.Axis)
			{
				text = StringTools.IterateName("Axis", -1, GetAxisNames());
				goto IL_0015;
			}
			string text2 = default(string);
			ControllerElementIdentifier controllerElementIdentifier = default(ControllerElementIdentifier);
			int num;
			if (P_0 == ControllerElementType.Button)
			{
				text2 = StringTools.IterateName("Button", -1, GetButtonNames());
				controllerElementIdentifier = ChqFUZceAVpHrHQCOFBqAfQdFiGC(P_0, text2, string.Empty, string.Empty);
				num = 287947293;
				goto IL_001a;
			}
			throw new NotImplementedException();
			IL_0015:
			num = 287947292;
			goto IL_001a;
			IL_001a:
			ControllerElementIdentifier controllerElementIdentifier2 = default(ControllerElementIdentifier);
			Axis axis = default(Axis);
			Button button = default(Button);
			while (true)
			{
				switch (num ^ 0x1129BA1D)
				{
				case 3:
					break;
				case 1:
					controllerElementIdentifier2 = ChqFUZceAVpHrHQCOFBqAfQdFiGC(P_0, text, string.Empty, string.Empty);
					axis = new Axis(text);
					num = 287947295;
					continue;
				case 0:
					button = new Button(text2);
					num = 287947288;
					continue;
				case 2:
					axis.elementIdentifierId = controllerElementIdentifier2.id;
					return axis;
				case 5:
					button.elementIdentifierId = controllerElementIdentifier.id;
					num = 287947289;
					continue;
				default:
					return button;
				}
				break;
			}
			goto IL_0015;
		}

		private ControllerElementIdentifier ChqFUZceAVpHrHQCOFBqAfQdFiGC(ControllerElementType P_0, string P_1, string P_2, string P_3)
		{
			int elementIdentifierIdCounter = _elementIdentifierIdCounter;
			_elementIdentifierIdCounter++;
			ControllerElementIdentifier controllerElementIdentifier = default(ControllerElementIdentifier);
			while (true)
			{
				int num = 1997205566;
				while (true)
				{
					switch (num ^ 0x770AF03F)
					{
					case 2:
						break;
					case 1:
						goto IL_0033;
					default:
						return controllerElementIdentifier;
					}
					break;
					IL_0033:
					controllerElementIdentifier = new ControllerElementIdentifier(elementIdentifierIdCounter, P_1, P_2, P_3, P_0, isMappableOnPlatform: true);
					_elementIdentifiers.Add(controllerElementIdentifier);
					num = 1997205567;
				}
			}
		}

		internal HardwareControllerMap_Game YucBUGhcNFqNsPLYijVdDVqvADJR()
		{
			int num = axisCount;
			int num2 = buttonCount;
			AxisCalibrationData[] array3 = default(AxisCalibrationData[]);
			int num4 = default(int);
			AxisRange[] array4 = default(AxisRange[]);
			int[] array = default(int[]);
			int num5 = default(int);
			HardwareButtonInfo[] array6 = default(HardwareButtonInfo[]);
			int[] array2 = default(int[]);
			HardwareAxisInfo[] array5 = default(HardwareAxisInfo[]);
			while (true)
			{
				int num3 = 191392627;
				while (true)
				{
					switch (num3 ^ 0xB686B77)
					{
					case 9:
						break;
					case 2:
					{
						ref AxisCalibrationData reference = ref array3[num4];
						reference = new AxisCalibrationData(enabled: true, _axes[num4].deadZone, _axes[num4].zero, _axes[num4].min, _axes[num4].max, _axes[num4].invert, !_axes[num4].doNotCalibrateRange, _axes[num4].sensitivityType, _axes[num4].sensitivity, UnityTools.Copy(_axes[num4].sensitivityCurve));
						array4[num4] = _axes[num4].range;
						num3 = 191392631;
						continue;
					}
					case 5:
						array[num5] = _buttons[num5].elementIdentifierId;
						array6[num5] = new HardwareButtonInfo();
						num5++;
						num3 = 191392630;
						continue;
					case 8:
						num3 = 191392625;
						continue;
					case 7:
						array2[num4] = _axes[num4].elementIdentifierId;
						num3 = 191392629;
						continue;
					case 3:
						num4++;
						num3 = 191392625;
						continue;
					case 1:
						if (num5 >= num2)
						{
							num4 = 0;
							num3 = 191392639;
							continue;
						}
						goto case 5;
					case 4:
						array = new int[num2];
						array2 = new int[num];
						array3 = new AxisCalibrationData[num];
						array4 = new AxisRange[num];
						array5 = new HardwareAxisInfo[num];
						array6 = new HardwareButtonInfo[num2];
						num5 = 0;
						num3 = 191392630;
						continue;
					case 0:
						array5[num4] = MiscTools.DeepClone(_axes[num4].axisInfo) ?? HardwareAxisInfo.Default;
						num3 = 191392628;
						continue;
					default:
						if (num4 >= num)
						{
							ControllerElementIdentifier[] elementIdentifiersTypeSorted = GetElementIdentifiersTypeSorted();
							return new HardwareControllerMap_Game(_name, _id, elementIdentifiersTypeSorted, array, array2, array3, array4, array5, array6, null);
						}
						goto case 7;
					}
					break;
				}
			}
		}
	}
}
