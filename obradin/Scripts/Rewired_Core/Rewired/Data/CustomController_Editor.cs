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
				axisInfo = new HardwareAxisInfo(AxisCoordinateMode.Absolute, false, SpecialAxisType.None);
			}

			[Obsolete("This constructor should not longer be used.", false)]
			public Axis(string name, string positiveName, string negativeName, int elementIdentifierId, AxisRange range, bool invert, float deadZone, float zero, float min, float max, bool doNotCalibrateRange, HardwareAxisInfo axisInfo)
				: base(name, elementIdentifierId)
			{
				this.range = range;
				this.invert = invert;
				this.deadZone = deadZone;
				this.zero = zero;
				this.min = min;
				this.max = max;
				this.doNotCalibrateRange = doNotCalibrateRange;
				this.axisInfo = MiscTools.DeepClone(axisInfo) ?? HardwareAxisInfo.Default;
				sensitivity = 1f;
				sensitivityType = AxisSensitivityType.Multiplier;
				sensitivityCurve = AnimationCurve.Linear(-1f, 1f, 1f, 1f);
			}

			public Axis(Axis source)
				: base(source.name, source.elementIdentifierId)
			{
				range = source.range;
				invert = source.invert;
				deadZone = source.deadZone;
				zero = source.zero;
				min = source.min;
				max = source.max;
				doNotCalibrateRange = source.doNotCalibrateRange;
				sensitivity = source.sensitivity;
				sensitivityType = source.sensitivityType;
				sensitivityCurve = UnityTools.Copy(source.sensitivityCurve);
				axisInfo = MiscTools.DeepClone(source.axisInfo) ?? HardwareAxisInfo.Default;
			}

			public override Element Clone()
			{
				return new Axis(this);
			}
		}

		private sealed class uJDvDXlDnrztSUWGxeitTlnePRw : IDisposable, IEnumerable<ControllerElementIdentifier>, IEnumerator<ControllerElementIdentifier>, IEnumerator, IEnumerable
		{
			private ControllerElementIdentifier aimBzjfQfPyaeQqysAQJISCBhELB;

			private int oGuYQSzFTrBqEKPsNTGqdIaaAqGg;

			private int HbSVCfYbFQknCSDIuBJpKcqKonb;

			public CustomController_Editor iKQXbXnVtIaMZEJNeigQJWAHqUx;

			public int JgkqHoXbaGSqSpATxoAvQPPuCvQ;

			ControllerElementIdentifier IEnumerator<ControllerElementIdentifier>.Current
			{
				[DebuggerHidden]
				get
				{
					return aimBzjfQfPyaeQqysAQJISCBhELB;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return aimBzjfQfPyaeQqysAQJISCBhELB;
				}
			}

			[DebuggerHidden]
			IEnumerator<ControllerElementIdentifier> IEnumerable<ControllerElementIdentifier>.GetEnumerator()
			{
				if (Thread.CurrentThread.ManagedThreadId == HbSVCfYbFQknCSDIuBJpKcqKonb)
				{
					goto IL_0012;
				}
				goto IL_0065;
				IL_0012:
				int num = -919163118;
				goto IL_0017;
				IL_0017:
				uJDvDXlDnrztSUWGxeitTlnePRw uJDvDXlDnrztSUWGxeitTlnePRw2 = default(uJDvDXlDnrztSUWGxeitTlnePRw);
				while (true)
				{
					switch (num ^ -919163117)
					{
					case 3:
						break;
					case 1:
						if (oGuYQSzFTrBqEKPsNTGqdIaaAqGg == -2)
						{
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 0;
							uJDvDXlDnrztSUWGxeitTlnePRw2 = this;
							num = -919163113;
							continue;
						}
						goto IL_0065;
					case 2:
						uJDvDXlDnrztSUWGxeitTlnePRw2.iKQXbXnVtIaMZEJNeigQJWAHqUx = iKQXbXnVtIaMZEJNeigQJWAHqUx;
						num = -919163113;
						continue;
					case 0:
						goto IL_0065;
					default:
						return uJDvDXlDnrztSUWGxeitTlnePRw2;
					}
					break;
				}
				goto IL_0012;
				IL_0065:
				uJDvDXlDnrztSUWGxeitTlnePRw2 = new uJDvDXlDnrztSUWGxeitTlnePRw(0);
				num = -919163119;
				goto IL_0017;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ControllerElementIdentifier>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				int num = oGuYQSzFTrBqEKPsNTGqdIaaAqGg;
				while (true)
				{
					int num2 = -1705508373;
					while (true)
					{
						switch (num2 ^ -1705508369)
						{
						case 7:
							break;
						case 3:
							JgkqHoXbaGSqSpATxoAvQPPuCvQ++;
							num2 = -1705508375;
							continue;
						case 1:
							JgkqHoXbaGSqSpATxoAvQPPuCvQ = 0;
							num2 = -1705508378;
							continue;
						case 5:
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
							num2 = -1705508369;
							continue;
						case 0:
						{
							int num4;
							if (iKQXbXnVtIaMZEJNeigQJWAHqUx._elementIdentifiers != null)
							{
								num2 = -1705508370;
								num4 = num2;
							}
							else
							{
								num2 = -1705508377;
								num4 = num2;
							}
							continue;
						}
						case 9:
							num2 = -1705508375;
							continue;
						case 2:
							aimBzjfQfPyaeQqysAQJISCBhELB = iKQXbXnVtIaMZEJNeigQJWAHqUx._elementIdentifiers[JgkqHoXbaGSqSpATxoAvQPPuCvQ];
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
							return true;
						case 4:
							switch (num)
							{
							case 0:
								break;
							case 1:
								oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
								num2 = -1705508372;
								continue;
							default:
								num2 = -1705508377;
								continue;
							}
							goto case 5;
						case 6:
						{
							int num3;
							if (JgkqHoXbaGSqSpATxoAvQPPuCvQ < iKQXbXnVtIaMZEJNeigQJWAHqUx._elementIdentifiers.Count)
							{
								num2 = -1705508371;
								num3 = num2;
							}
							else
							{
								num2 = -1705508377;
								num3 = num2;
							}
							continue;
						}
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
			public uJDvDXlDnrztSUWGxeitTlnePRw(int _003C_003E1__state)
			{
				oGuYQSzFTrBqEKPsNTGqdIaaAqGg = _003C_003E1__state;
				HbSVCfYbFQknCSDIuBJpKcqKonb = Thread.CurrentThread.ManagedThreadId;
			}
		}

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private string _name;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private string _descriptiveName;

		[SerializeField]
		[CustomObfuscation(rename = false)]
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

		public List<Axis> axes
		{
			get
			{
				return _axes;
			}
		}

		public List<Button> buttons
		{
			get
			{
				return _buttons;
			}
		}

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
				uJDvDXlDnrztSUWGxeitTlnePRw uJDvDXlDnrztSUWGxeitTlnePRw2 = new uJDvDXlDnrztSUWGxeitTlnePRw(-2);
				uJDvDXlDnrztSUWGxeitTlnePRw2.iKQXbXnVtIaMZEJNeigQJWAHqUx = this;
				return uJDvDXlDnrztSUWGxeitTlnePRw2;
			}
		}

		public CustomController_Editor()
		{
			_axes = new List<Axis>();
			_buttons = new List<Button>();
			_elementIdentifiers = new List<ControllerElementIdentifier>();
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
			string[] array = new string[num];
			int num2 = 0;
			while (true)
			{
				int num3;
				int num4;
				if (num2 < num)
				{
					num3 = 248507470;
					num4 = num3;
				}
				else
				{
					num3 = 248507468;
					num4 = num3;
				}
				while (true)
				{
					switch (num3 ^ 0xECFEC4D)
					{
					case 2:
						num3 = 248507470;
						continue;
					case 3:
						array[num2] = _elementIdentifiers[num2].name;
						num2++;
						num3 = 248507469;
						continue;
					case 0:
						break;
					default:
						return array;
					}
					break;
				}
			}
		}

		public int[] GetElementIdentifierIds()
		{
			if (_elementIdentifiers == null)
			{
				goto IL_0008;
			}
			int num = _elementIdentifiers.Count;
			goto IL_007b;
			IL_007b:
			int num2 = num;
			int[] array = new int[num2];
			int num3 = 0;
			int num4 = 1897833134;
			goto IL_000d;
			IL_0008:
			num4 = 1897833128;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num4 ^ 0x711EA2AC)
				{
				case 0:
					break;
				case 2:
					goto IL_0032;
				case 1:
					array[num3] = _elementIdentifiers[num3].id;
					num4 = 1897833135;
					continue;
				case 3:
					num3++;
					num4 = 1897833134;
					continue;
				case 4:
					goto IL_006d;
				default:
					return array;
				}
				break;
				IL_0032:
				int num5;
				if (num3 >= num2)
				{
					num4 = 1897833129;
					num5 = num4;
				}
				else
				{
					num4 = 1897833133;
					num5 = num4;
				}
			}
			goto IL_0008;
			IL_006d:
			num = 0;
			goto IL_007b;
		}

		public string[] GetElementIdentifierNamesTypeSorted()
		{
			List<string> list = new List<string>();
			List<string> list2 = new List<string>();
			int num6 = default(int);
			int num5 = default(int);
			int num2 = default(int);
			int num3 = default(int);
			while (true)
			{
				int num = 1223091126;
				while (true)
				{
					switch (num ^ 0x48E6E3B2)
					{
					case 7:
						break;
					case 4:
						num6 = axisCount;
						num = 1223091123;
						continue;
					case 8:
					{
						int num4 = IndexOfElementIdentifier(axes[num5].elementIdentifierId);
						if (num4 >= 0)
						{
							list2.Add(_elementIdentifiers[num4].name);
							num = 1223091120;
							continue;
						}
						goto case 2;
					}
					case 5:
					{
						int num7 = IndexOfElementIdentifier(buttons[num2].elementIdentifierId);
						if (num7 >= 0)
						{
							list.Add(_elementIdentifiers[num7].name);
							num = 1223091121;
							continue;
						}
						goto case 3;
					}
					case 3:
						num2++;
						num = 1223091122;
						continue;
					case 9:
						num = 1223091122;
						continue;
					case 1:
						num5 = 0;
						num = 1223091124;
						continue;
					case 2:
						num5++;
						num = 1223091124;
						continue;
					case 6:
						if (num5 >= num6)
						{
							num3 = buttonCount;
							num2 = 0;
							num = 1223091131;
							continue;
						}
						goto case 8;
					default:
						if (num2 >= num3)
						{
							List<string> list3 = ListTools.Combine(list2, list);
							return list3.ToArray();
						}
						goto case 5;
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
			int num2 = 0;
			int num3 = default(int);
			int num4 = default(int);
			while (true)
			{
				int num5;
				if (num2 >= num)
				{
					num3 = buttonCount;
					num4 = 0;
					num5 = 373881023;
					goto IL_001c;
				}
				goto IL_007c;
				IL_001c:
				while (true)
				{
					switch (num5 ^ 0x1648F8BA)
					{
					case 2:
						num5 = 373881017;
						continue;
					case 1:
						break;
					case 4:
						list.Add(buttons[num4].elementIdentifierId);
						num4++;
						num5 = 373881023;
						continue;
					case 3:
						goto IL_007c;
					case 0:
						num2++;
						num5 = 373881019;
						continue;
					default:
						if (num4 >= num3)
						{
							List<int> list3 = ListTools.Combine(list2, list);
							return list3.ToArray();
						}
						goto case 4;
					}
					break;
				}
				continue;
				IL_007c:
				list2.Add(axes[num2].elementIdentifierId);
				num5 = 373881018;
				goto IL_001c;
			}
		}

		public ControllerElementIdentifier[] GetElementIdentifiersTypeSorted()
		{
			List<ControllerElementIdentifier> list = new List<ControllerElementIdentifier>();
			List<ControllerElementIdentifier> list2 = new List<ControllerElementIdentifier>();
			int num8 = default(int);
			int num3 = default(int);
			int num4 = default(int);
			int num2 = default(int);
			int num6 = default(int);
			int num7 = default(int);
			List<ControllerElementIdentifier> list3 = default(List<ControllerElementIdentifier>);
			while (true)
			{
				int num = 312879595;
				while (true)
				{
					switch (num ^ 0x12A629E1)
					{
					case 4:
						break;
					case 2:
					{
						num8 = IndexOfElementIdentifier(buttons[num3].elementIdentifierId);
						int num9;
						if (num8 < 0)
						{
							num = 312879594;
							num9 = num;
						}
						else
						{
							num = 312879592;
							num9 = num;
						}
						continue;
					}
					case 0:
					{
						int num5;
						if (num3 < num4)
						{
							num = 312879587;
							num5 = num;
						}
						else
						{
							num = 312879588;
							num5 = num;
						}
						continue;
					}
					case 1:
						num2 = IndexOfElementIdentifier(axes[num6].elementIdentifierId);
						num = 312879590;
						continue;
					case 6:
						if (num6 >= num7)
						{
							num4 = buttonCount;
							num3 = 0;
							num = 312879585;
							continue;
						}
						goto case 1;
					case 5:
						list3 = ListTools.Combine(list2, list);
						num = 312879593;
						continue;
					case 9:
						list.Add(_elementIdentifiers[num8]);
						num = 312879594;
						continue;
					case 11:
						num3++;
						num = 312879585;
						continue;
					case 10:
						num7 = axisCount;
						num6 = 0;
						num = 312879591;
						continue;
					case 7:
						if (num2 >= 0)
						{
							list2.Add(_elementIdentifiers[num2]);
							num = 312879586;
							continue;
						}
						goto case 3;
					case 3:
						num6++;
						num = 312879591;
						continue;
					default:
						return list3.ToArray();
					}
					break;
				}
			}
		}

		public bool ContainsElementIdentifier(int id)
		{
			int num = ((_elementIdentifiers != null) ? _elementIdentifiers.Count : 0);
			int num2 = 0;
			while (num2 < num)
			{
				while (true)
				{
					if (_elementIdentifiers[num2].id == id)
					{
						return true;
					}
					num2++;
					int num3 = -311291136;
					while (true)
					{
						switch (num3 ^ -311291134)
						{
						case 0:
							num3 = -311291133;
							continue;
						case 1:
							break;
						default:
							goto end_IL_0039;
						}
						break;
					}
					continue;
					end_IL_0039:
					break;
				}
			}
			return false;
		}

		public int IndexOfElementIdentifier(int id)
		{
			int num = ((_elementIdentifiers != null) ? _elementIdentifiers.Count : 0);
			int num2 = 0;
			while (true)
			{
				int num3;
				int num4;
				if (num2 < num)
				{
					num3 = -1169546419;
					num4 = num3;
				}
				else
				{
					num3 = -1169546418;
					num4 = num3;
				}
				while (true)
				{
					switch (num3 ^ -1169546420)
					{
					case 0:
						num3 = -1169546419;
						continue;
					case 1:
						if (_elementIdentifiers[num2].id == id)
						{
							num3 = -1169546424;
							continue;
						}
						num2++;
						num3 = -1169546417;
						continue;
					case 4:
						return num2;
					case 3:
						break;
					default:
						return -1;
					}
					break;
				}
			}
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

		internal ControllerElementType nPiClkKTjgGtnbhecTFAsHefaluP(int P_0)
		{
			ControllerElementIdentifier elementIdentifier = GetElementIdentifier(P_0);
			if (elementIdentifier == null)
			{
				goto IL_000b;
			}
			int num = 0;
			int num2 = 1678185410;
			goto IL_0010;
			IL_0010:
			int num3 = default(int);
			while (true)
			{
				switch (num2 ^ 0x640713C6)
				{
				case 0:
					break;
				case 5:
					return ControllerElementType.Axis;
				case 8:
					return ControllerElementType.Button;
				case 1:
				{
					int num4;
					if (num >= axisCount)
					{
						num2 = 1678185413;
						num4 = num2;
					}
					else
					{
						num2 = 1678185408;
						num4 = num2;
					}
					continue;
				}
				case 2:
					if (buttons[num3].elementIdentifierId != elementIdentifier.id)
					{
						num3++;
						num2 = 1678185423;
					}
					else
					{
						num2 = 1678185422;
					}
					continue;
				case 7:
					num2 = 1678185423;
					continue;
				case 4:
					num2 = 1678185415;
					continue;
				case 3:
					num3 = 0;
					num2 = 1678185409;
					continue;
				case 6:
					if (axes[num].elementIdentifierId == elementIdentifier.id)
					{
						return ControllerElementType.Axis;
					}
					num++;
					num2 = 1678185415;
					continue;
				default:
					if (num3 >= buttonCount)
					{
						return elementIdentifier.elementType;
					}
					goto case 2;
				}
				break;
			}
			goto IL_000b;
			IL_000b:
			num2 = 1678185411;
			goto IL_0010;
		}

		internal bool fEwMNGJEXLDKgbjybglSRKStSQuf(int P_0, out AxisRange P_1)
		{
			ControllerElementIdentifier elementIdentifier = GetElementIdentifier(P_0);
			if (elementIdentifier == null)
			{
				goto IL_000e;
			}
			int num = 0;
			int num2 = 1621765124;
			goto IL_0013;
			IL_0013:
			while (true)
			{
				switch (num2 ^ 0x60AA2C06)
				{
				case 3:
					break;
				case 8:
					return true;
				case 4:
				{
					int num4;
					if (num < axisCount)
					{
						num2 = 1621765123;
						num4 = num2;
					}
					else
					{
						num2 = 1621765121;
						num4 = num2;
					}
					continue;
				}
				case 5:
					if (axes[num].elementIdentifierId != elementIdentifier.id)
					{
						num++;
						num2 = 1621765122;
					}
					else
					{
						num2 = 1621765127;
					}
					continue;
				case 0:
					P_1 = InputTools.InvertAxisRange(P_1);
					num2 = 1621765134;
					continue;
				case 6:
					P_1 = AxisRange.Full;
					return false;
				case 1:
				{
					P_1 = axes[num].range;
					int num3;
					if (!axes[num].invert)
					{
						num2 = 1621765134;
						num3 = num2;
					}
					else
					{
						num2 = 1621765126;
						num3 = num2;
					}
					continue;
				}
				case 2:
					num2 = 1621765122;
					continue;
				default:
					P_1 = AxisRange.Full;
					return false;
				}
				break;
			}
			goto IL_000e;
			IL_000e:
			num2 = 1621765120;
			goto IL_0013;
		}

		public string[] GetButtonNames()
		{
			if (_buttons == null)
			{
				goto IL_0008;
			}
			int num = _buttons.Count;
			goto IL_0044;
			IL_0036:
			num = 0;
			goto IL_0044;
			IL_0008:
			int num2 = -1148598410;
			goto IL_000d;
			IL_000d:
			string[] array = default(string[]);
			int num3 = default(int);
			int num4 = default(int);
			while (true)
			{
				switch (num2 ^ -1148598409)
				{
				case 5:
					break;
				case 1:
					goto IL_0036;
				case 3:
					array[num3] = _buttons[num3].name;
					num2 = -1148598411;
					continue;
				case 0:
					array = new string[num4];
					num3 = 0;
					num2 = -1148598413;
					continue;
				case 2:
					num3++;
					num2 = -1148598415;
					continue;
				case 4:
					num2 = -1148598415;
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
			IL_0044:
			num4 = num;
			num2 = -1148598409;
			goto IL_000d;
		}

		public int[] GetButtonElementIdentifierIds()
		{
			int num = ((_buttons != null) ? _buttons.Count : 0);
			int[] array = new int[num];
			int num2 = 0;
			while (num2 < num)
			{
				while (true)
				{
					array[num2] = _buttons[num2].elementIdentifierId;
					num2++;
					int num3 = 427546594;
					while (true)
					{
						switch (num3 ^ 0x197BD7E0)
						{
						case 0:
							num3 = 427546593;
							continue;
						case 1:
							break;
						default:
							goto end_IL_0040;
						}
						break;
					}
					continue;
					end_IL_0040:
					break;
				}
			}
			return array;
		}

		public string[] GetAxisNames()
		{
			if (_axes == null)
			{
				goto IL_0008;
			}
			int num = _axes.Count;
			goto IL_003c;
			IL_002e:
			num = 0;
			goto IL_003c;
			IL_0008:
			int num2 = 253130465;
			goto IL_000d;
			IL_000d:
			string[] array = default(string[]);
			int num3 = default(int);
			int num4 = default(int);
			while (true)
			{
				switch (num2 ^ 0xF1676E5)
				{
				case 3:
					break;
				case 4:
					goto IL_002e;
				case 0:
					array[num3] = _axes[num3].name;
					num2 = 253130471;
					continue;
				case 2:
					num3++;
					num2 = 253130468;
					continue;
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
			IL_003c:
			num4 = num;
			array = new string[num4];
			num3 = 0;
			num2 = 253130468;
			goto IL_000d;
		}

		public int[] GetAxisElementIdentifierIds()
		{
			int num = ((_axes != null) ? _axes.Count : 0);
			int[] array = new int[num];
			int num2 = 0;
			while (num2 < num)
			{
				while (true)
				{
					array[num2] = _axes[num2].elementIdentifierId;
					int num3 = -329938317;
					while (true)
					{
						switch (num3 ^ -329938319)
						{
						case 0:
							num3 = -329938320;
							continue;
						case 1:
							break;
						case 2:
							num2++;
							num3 = -329938318;
							continue;
						default:
							goto end_IL_0044;
						}
						break;
					}
					continue;
					end_IL_0044:
					break;
				}
			}
			return array;
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
			if (index < 0)
			{
				return null;
			}
			if (object.ReferenceEquals(typeof(T), typeof(Axis)))
			{
				goto IL_0029;
			}
			int num;
			if (object.ReferenceEquals(typeof(T), typeof(Button)))
			{
				if (index >= buttonCount)
				{
					num = -1653955976;
					goto IL_002e;
				}
				return _buttons[index] as T;
			}
			throw new NotImplementedException();
			IL_002e:
			switch (num ^ -1653955975)
			{
			case 0:
				break;
			case 2:
				if (index >= axisCount)
				{
					return null;
				}
				return _axes[index] as T;
			default:
				return null;
			}
			goto IL_0029;
			IL_0029:
			num = -1653955973;
			goto IL_002e;
		}

		public void AddElement(ControllerElementType type)
		{
			if (type == ControllerElementType.Axis)
			{
				AddAxis();
			}
			else
			{
				AddButton();
			}
		}

		public void AddAxis()
		{
			axes.Add((Axis)PyaFEecUmjTIEnmuQEvwPyvNXli(ControllerElementType.Axis));
		}

		public void AddButton()
		{
			buttons.Add((Button)PyaFEecUmjTIEnmuQEvwPyvNXli(ControllerElementType.Button));
		}

		public void InsertElement(ControllerElementType type, int index)
		{
			if (type == ControllerElementType.Axis)
			{
				InsertAxis(index);
				goto IL_000a;
			}
			goto IL_0034;
			IL_0034:
			InsertButton(index);
			int num = -1110768918;
			goto IL_000f;
			IL_000a:
			num = -1110768920;
			goto IL_000f;
			IL_000f:
			switch (num ^ -1110768917)
			{
			case 2:
				break;
			default:
				return;
			case 3:
				return;
			case 0:
				goto IL_0034;
			case 1:
				return;
			}
			goto IL_000a;
		}

		public void InsertAxis(int index)
		{
			if (index >= 0)
			{
				while (true)
				{
					int num = 479294216;
					while (true)
					{
						switch (num ^ 0x1C917309)
						{
						case 0:
							break;
						case 1:
							goto IL_0026;
						case 2:
							goto end_IL_0004;
						default:
							axes.Insert(index, (Axis)PyaFEecUmjTIEnmuQEvwPyvNXli(ControllerElementType.Axis));
							return;
						}
						break;
						IL_0026:
						int num2;
						if (index < axes.Count)
						{
							num = 479294218;
							num2 = num;
						}
						else
						{
							num = 479294219;
							num2 = num;
						}
					}
					continue;
					end_IL_0004:
					break;
				}
			}
			throw new ArgumentOutOfRangeException("index");
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
			int num = 569226751;
			goto IL_0017;
			IL_0017:
			switch (num ^ 0x21EDB5FC)
			{
			case 0:
				break;
			default:
				return;
			case 3:
				goto IL_0034;
			case 1:
				goto IL_0046;
			case 2:
				return;
			}
			goto IL_0012;
			IL_0046:
			buttons.Insert(index, (Button)PyaFEecUmjTIEnmuQEvwPyvNXli(ControllerElementType.Button));
			num = 569226750;
			goto IL_0017;
		}

		public void DeleteElement(ControllerElementType type, int index)
		{
			if (type == ControllerElementType.Axis)
			{
				DeleteElement<Axis>(index);
				goto IL_000a;
			}
			goto IL_0038;
			IL_0052:
			throw new NotImplementedException();
			IL_000a:
			int num = 773009627;
			goto IL_000f;
			IL_000f:
			switch (num ^ 0x2E1330DA)
			{
			case 3:
				break;
			case 1:
				return;
			case 4:
				goto IL_0038;
			case 2:
				return;
			default:
				goto IL_0052;
			}
			goto IL_000a;
			IL_0038:
			if (type == ControllerElementType.Button)
			{
				DeleteElement<Button>(index);
				num = 773009624;
				goto IL_000f;
			}
			goto IL_0052;
		}

		public void DeleteElement<T>(int index) where T : Element
		{
			if (index < 0)
			{
				return;
			}
			int num2 = default(int);
			while (true)
			{
				IL_0106:
				if (object.ReferenceEquals(typeof(T), typeof(Axis)))
				{
					if (index >= axisCount)
					{
						break;
					}
					goto IL_0064;
				}
				goto IL_0082;
				IL_0064:
				T val = _axes[index] as T;
				int num = 173607274;
				goto IL_000d;
				IL_0082:
				if (object.ReferenceEquals(typeof(T), typeof(Button)))
				{
					if (index >= buttonCount)
					{
						break;
					}
					goto IL_00b1;
				}
				goto IL_00de;
				IL_00de:
				throw new NotImplementedException();
				IL_00b1:
				val = _buttons[index] as T;
				_buttons.RemoveAt(index);
				num = 173607265;
				goto IL_000d;
				IL_000d:
				while (true)
				{
					switch (num ^ 0xA590968)
					{
					case 6:
						num = 173607273;
						continue;
					default:
						return;
					case 2:
						_axes.RemoveAt(index);
						num = 173607265;
						continue;
					case 8:
						break;
					case 5:
						goto IL_0082;
					case 3:
						goto IL_00b1;
					case 7:
						goto IL_00de;
					case 4:
						goto IL_00ee;
					case 1:
						goto IL_0106;
					case 12:
						if (_elementIdentifiers[num2].id == val.elementIdentifierId)
						{
							_elementIdentifiers.RemoveAt(num2);
							num = 173607267;
							continue;
						}
						goto case 11;
					case 11:
						num2--;
						num = 173607276;
						continue;
					case 9:
						if (_elementIdentifiers != null)
						{
							num2 = _elementIdentifiers.Count - 1;
							num = 173607272;
							continue;
						}
						return;
					case 0:
						num = 173607276;
						continue;
					case 10:
						return;
					}
					break;
					IL_00ee:
					int num3;
					if (num2 < 0)
					{
						num = 173607266;
						num3 = num;
					}
					else
					{
						num = 173607268;
						num3 = num;
					}
				}
				goto IL_0064;
			}
		}

		public bool ReorderElement(ControllerElementType type, int index, bool offsetDown, bool offsetNow)
		{
			List<Axis> list = default(List<Axis>);
			if (type == ControllerElementType.Axis)
			{
				list = _axes;
				if (list != null && index >= 0)
				{
					goto IL_0011;
				}
				goto IL_005e;
			}
			List<Button> list2 = default(List<Button>);
			int num;
			if (type == ControllerElementType.Button)
			{
				list2 = _buttons;
				num = 1602958098;
				goto IL_0016;
			}
			throw new NotImplementedException();
			IL_0011:
			num = 1602958102;
			goto IL_0016;
			IL_005e:
			return false;
			IL_0016:
			while (true)
			{
				switch (num ^ 0x5F8B3312)
				{
				case 3:
					break;
				case 4:
					goto IL_0037;
				case 0:
					if (list2 != null && index >= 0)
					{
						goto IL_004e;
					}
					goto default;
				case 1:
					goto IL_005e;
				default:
					return false;
				}
				break;
				IL_004e:
				if (index >= list2.Count)
				{
					num = 1602958096;
					continue;
				}
				return ListTools.OffsetAtIndex(list2, index, offsetDown, offsetNow);
				IL_0037:
				if (index >= list.Count)
				{
					num = 1602958099;
					continue;
				}
				return ListTools.OffsetAtIndex(list, index, offsetDown, offsetNow);
			}
			goto IL_0011;
		}

		public void DuplicateElement(ControllerElementType type, int index)
		{
			if (type == ControllerElementType.Axis)
			{
				UspbKIGdYdnqORTUrgJVpMjonXaA(index, axes);
				goto IL_0010;
			}
			goto IL_0056;
			IL_0056:
			int num;
			int num2;
			if (type != ControllerElementType.Button)
			{
				num = 1871935097;
				num2 = num;
			}
			else
			{
				num = 1871935099;
				num2 = num;
			}
			goto IL_0015;
			IL_0010:
			num = 1871935098;
			goto IL_0015;
			IL_0015:
			while (true)
			{
				switch (num ^ 0x6F937678)
				{
				case 0:
					break;
				case 2:
					return;
				case 3:
					UspbKIGdYdnqORTUrgJVpMjonXaA(index, buttons);
					num = 1871935101;
					continue;
				case 4:
					goto IL_0056;
				case 5:
					return;
				default:
					throw new NotImplementedException();
				}
				break;
			}
			goto IL_0010;
		}

		private void UspbKIGdYdnqORTUrgJVpMjonXaA<T>(int P_0, List<T> P_1) where T : Element
		{
			if (P_1 != null)
			{
				ControllerElementIdentifier controllerElementIdentifier = default(ControllerElementIdentifier);
				T val2 = default(T);
				string text = default(string);
				T val = default(T);
				while (true)
				{
					int num = -733576590;
					while (true)
					{
						switch (num ^ -733576589)
						{
						case 3:
							break;
						case 1:
							goto IL_003f;
						case 4:
							goto IL_0060;
						case 8:
							controllerElementIdentifier = PlFDfPdEmECDuRPrAqpsShNdkjRs(val2.elementIdentifierId, text);
							if (controllerElementIdentifier == null)
							{
								Logger.LogError("Element identifier is missing! Element cannot be duplicated!");
								return;
							}
							goto IL_0060;
						case 2:
							P_1.Add(val);
							num = -733576588;
							continue;
						case 7:
							return;
						case 6:
							val2 = P_1[P_0];
							text = StringTools.IterateName(val2.name, -1, GetElementNames<T>());
							num = -733576581;
							continue;
						case 0:
							goto end_IL_0006;
						default:
							P_1.Insert(P_0 + 1, val);
							return;
						}
						break;
						IL_0060:
						val = (T)val2.Clone();
						val.elementIdentifierId = controllerElementIdentifier.id;
						val.name = text;
						int num2;
						if (P_0 != P_1.Count - 1)
						{
							num = -733576586;
							num2 = num;
						}
						else
						{
							num = -733576591;
							num2 = num;
						}
						continue;
						IL_003f:
						if (P_0 < 0)
						{
							goto end_IL_0006;
						}
						int num3;
						if (P_0 < P_1.Count)
						{
							num = -733576587;
							num3 = num;
						}
						else
						{
							num = -733576589;
							num3 = num;
						}
					}
					continue;
					end_IL_0006:
					break;
				}
			}
			throw new ArgumentOutOfRangeException("index");
		}

		private ControllerElementIdentifier PlFDfPdEmECDuRPrAqpsShNdkjRs(int P_0, string P_1)
		{
			if (!ContainsElementIdentifier(P_0))
			{
				goto IL_0009;
			}
			int num = IndexOfElementIdentifier(P_0);
			int elementIdentifierIdCounter = _elementIdentifierIdCounter;
			_elementIdentifierIdCounter++;
			ControllerElementIdentifier controllerElementIdentifier = new ControllerElementIdentifier(elementIdentifierIdCounter, P_1, _elementIdentifiers[num].positiveName, _elementIdentifiers[num].negativeName, _elementIdentifiers[num].elementType, _elementIdentifiers[num].compoundElementType, _elementIdentifiers[num].isMappableOnPlatform);
			int num2;
			if (num == _elementIdentifiers.Count - 1)
			{
				_elementIdentifiers.Add(controllerElementIdentifier);
				num2 = 76729661;
				goto IL_000e;
			}
			goto IL_00d0;
			IL_000e:
			switch (num2 ^ 0x492CD3C)
			{
			case 0:
				break;
			case 3:
				return null;
			case 2:
				goto IL_00d0;
			default:
				return controllerElementIdentifier;
			}
			goto IL_0009;
			IL_00d0:
			_elementIdentifiers.Insert(num + 1, controllerElementIdentifier);
			num2 = 76729661;
			goto IL_000e;
			IL_0009:
			num2 = 76729663;
			goto IL_000e;
		}

		private Element PyaFEecUmjTIEnmuQEvwPyvNXli(ControllerElementType P_0)
		{
			string text = default(string);
			if (P_0 == ControllerElementType.Axis)
			{
				text = StringTools.IterateName("Axis", -1, GetAxisNames());
				goto IL_0015;
			}
			int num;
			if (P_0 == ControllerElementType.Button)
			{
				num = -1499538768;
				goto IL_001a;
			}
			throw new NotImplementedException();
			IL_0015:
			num = -1499538765;
			goto IL_001a;
			IL_001a:
			string text2 = default(string);
			ControllerElementIdentifier controllerElementIdentifier = default(ControllerElementIdentifier);
			Button button = default(Button);
			while (true)
			{
				switch (num ^ -1499538767)
				{
				case 3:
					break;
				case 2:
				{
					ControllerElementIdentifier controllerElementIdentifier2 = MAuyLLchvZnsBLkdfkvvQgyMgpo(P_0, text, string.Empty, string.Empty);
					Axis axis = new Axis(text);
					axis.elementIdentifierId = controllerElementIdentifier2.id;
					return axis;
				}
				case 1:
					text2 = StringTools.IterateName("Button", -1, GetButtonNames());
					controllerElementIdentifier = MAuyLLchvZnsBLkdfkvvQgyMgpo(P_0, text2, string.Empty, string.Empty);
					num = -1499538763;
					continue;
				case 4:
					button = new Button(text2);
					num = -1499538767;
					continue;
				case 0:
					button.elementIdentifierId = controllerElementIdentifier.id;
					num = -1499538764;
					continue;
				default:
					return button;
				}
				break;
			}
			goto IL_0015;
		}

		private ControllerElementIdentifier MAuyLLchvZnsBLkdfkvvQgyMgpo(ControllerElementType P_0, string P_1, string P_2, string P_3)
		{
			int elementIdentifierIdCounter = _elementIdentifierIdCounter;
			_elementIdentifierIdCounter++;
			ControllerElementIdentifier controllerElementIdentifier = new ControllerElementIdentifier(elementIdentifierIdCounter, P_1, P_2, P_3, P_0, true);
			while (true)
			{
				int num = -1422247870;
				while (true)
				{
					switch (num ^ -1422247872)
					{
					case 0:
						break;
					case 2:
						goto IL_0040;
					default:
						return controllerElementIdentifier;
					}
					break;
					IL_0040:
					_elementIdentifiers.Add(controllerElementIdentifier);
					num = -1422247871;
				}
			}
		}

		internal HardwareControllerMap_Game KDogQqmgPVdWpEwZDagggKagBxV()
		{
			int num = axisCount;
			int num2 = buttonCount;
			int[] array = new int[num2];
			int[] array2 = new int[num];
			AxisCalibrationData[] array3 = new AxisCalibrationData[num];
			AxisRange[] array4 = new AxisRange[num];
			HardwareAxisInfo[] array5 = new HardwareAxisInfo[num];
			HardwareButtonInfo[] array6 = new HardwareButtonInfo[num2];
			int num3 = 0;
			int num4 = default(int);
			while (true)
			{
				int num5;
				if (num3 >= num2)
				{
					num4 = 0;
					num5 = -43200556;
					goto IL_0046;
				}
				goto IL_01bf;
				IL_0046:
				while (true)
				{
					switch (num5 ^ -43200555)
					{
					case 0:
						num5 = -43200560;
						continue;
					case 7:
						break;
					case 2:
						num3++;
						num5 = -43200558;
						continue;
					case 3:
						array2[num4] = _axes[num4].elementIdentifierId;
						array3[num4] = new AxisCalibrationData(true, _axes[num4].deadZone, _axes[num4].zero, _axes[num4].min, _axes[num4].max, _axes[num4].invert, !_axes[num4].doNotCalibrateRange, _axes[num4].sensitivityType, _axes[num4].sensitivity, UnityTools.Copy(_axes[num4].sensitivityCurve));
						array4[num4] = _axes[num4].range;
						num5 = -43200557;
						continue;
					case 6:
						array5[num4] = MiscTools.DeepClone(_axes[num4].axisInfo) ?? HardwareAxisInfo.Default;
						num4++;
						num5 = -43200556;
						continue;
					case 5:
						goto IL_01bf;
					case 1:
						goto IL_01e9;
					default:
					{
						ControllerElementIdentifier[] elementIdentifiersTypeSorted = GetElementIdentifiersTypeSorted();
						return new HardwareControllerMap_Game(_name, _id, elementIdentifiersTypeSorted, array, array2, array3, array4, array5, array6, null);
					}
					}
					break;
					IL_01e9:
					int num6;
					if (num4 >= num)
					{
						num5 = -43200559;
						num6 = num5;
					}
					else
					{
						num5 = -43200554;
						num6 = num5;
					}
				}
				continue;
				IL_01bf:
				array[num3] = _buttons[num3].elementIdentifierId;
				array6[num3] = new HardwareButtonInfo();
				num5 = -43200553;
				goto IL_0046;
			}
		}
	}
}
