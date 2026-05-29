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
		[EditorBrowsable(EditorBrowsableState.Never)]
		[Browsable(false)]
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

		private sealed class FyLZEIRatfvWzgZRLAebsrvcPWx : IDisposable, IEnumerable<ControllerElementIdentifier>, IEnumerator<ControllerElementIdentifier>, IEnumerator, IEnumerable
		{
			private ControllerElementIdentifier RDkWcsTpvDaNZojjIZONnoEBXPC;

			private int LzqgRXjFXvJPbHjfzyAmNfcqezXL;

			private int iDzUuTsbdXLkIyEGCPmJzsmGhcs;

			public CustomController_Editor ZzSaCQHlhEgTijsOQGwUlyKTOzqG;

			public int cxajIdvHgWRVzXfSJnEbjHXsCoJi;

			ControllerElementIdentifier IEnumerator<ControllerElementIdentifier>.Current
			{
				[DebuggerHidden]
				get
				{
					return RDkWcsTpvDaNZojjIZONnoEBXPC;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return RDkWcsTpvDaNZojjIZONnoEBXPC;
				}
			}

			[DebuggerHidden]
			IEnumerator<ControllerElementIdentifier> IEnumerable<ControllerElementIdentifier>.GetEnumerator()
			{
				FyLZEIRatfvWzgZRLAebsrvcPWx fyLZEIRatfvWzgZRLAebsrvcPWx;
				if (Thread.CurrentThread.ManagedThreadId == iDzUuTsbdXLkIyEGCPmJzsmGhcs && LzqgRXjFXvJPbHjfzyAmNfcqezXL == -2)
				{
					LzqgRXjFXvJPbHjfzyAmNfcqezXL = 0;
					fyLZEIRatfvWzgZRLAebsrvcPWx = this;
					goto IL_0025;
				}
				goto IL_004e;
				IL_002a:
				int num;
				while (true)
				{
					switch (num ^ -1912155080)
					{
					case 2:
						break;
					case 1:
						num = -1912155077;
						continue;
					case 0:
						goto IL_004e;
					default:
						return fyLZEIRatfvWzgZRLAebsrvcPWx;
					}
					break;
				}
				goto IL_0025;
				IL_004e:
				fyLZEIRatfvWzgZRLAebsrvcPWx = new FyLZEIRatfvWzgZRLAebsrvcPWx(0);
				fyLZEIRatfvWzgZRLAebsrvcPWx.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = ZzSaCQHlhEgTijsOQGwUlyKTOzqG;
				num = -1912155077;
				goto IL_002a;
				IL_0025:
				num = -1912155079;
				goto IL_002a;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ControllerElementIdentifier>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				int num;
				switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
				{
				case 0:
					LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
					if (ZzSaCQHlhEgTijsOQGwUlyKTOzqG._elementIdentifiers == null)
					{
						break;
					}
					cxajIdvHgWRVzXfSJnEbjHXsCoJi = 0;
					num = -418636555;
					goto IL_001f;
				case 1:
					{
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
						cxajIdvHgWRVzXfSJnEbjHXsCoJi++;
						num = -418636555;
						goto IL_001f;
					}
					IL_001f:
					while (true)
					{
						switch (num ^ -418636554)
						{
						case 0:
							num = -418636558;
							continue;
						case 3:
							break;
						case 5:
							RDkWcsTpvDaNZojjIZONnoEBXPC = ZzSaCQHlhEgTijsOQGwUlyKTOzqG._elementIdentifiers[cxajIdvHgWRVzXfSJnEbjHXsCoJi];
							num = -418636556;
							continue;
						case 4:
							goto end_IL_001f;
						case 2:
							LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
							return true;
						default:
							goto end_IL_0008;
						}
						int num2;
						if (cxajIdvHgWRVzXfSJnEbjHXsCoJi < ZzSaCQHlhEgTijsOQGwUlyKTOzqG._elementIdentifiers.Count)
						{
							num = -418636557;
							num2 = num;
						}
						else
						{
							num = -418636553;
							num2 = num;
						}
						continue;
						end_IL_001f:
						break;
					}
					goto case 0;
					end_IL_0008:
					break;
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

			void IDisposable.Dispose()
			{
			}

			[DebuggerHidden]
			public FyLZEIRatfvWzgZRLAebsrvcPWx(int _003C_003E1__state)
			{
				LzqgRXjFXvJPbHjfzyAmNfcqezXL = _003C_003E1__state;
				iDzUuTsbdXLkIyEGCPmJzsmGhcs = Thread.CurrentThread.ManagedThreadId;
			}
		}

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string _name;

		[SerializeField]
		[CustomObfuscation(rename = false)]
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

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private List<Axis> _axes;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private List<Button> _buttons;

		[CustomObfuscation(rename = false)]
		[SerializeField]
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
				FyLZEIRatfvWzgZRLAebsrvcPWx fyLZEIRatfvWzgZRLAebsrvcPWx = new FyLZEIRatfvWzgZRLAebsrvcPWx(-2);
				fyLZEIRatfvWzgZRLAebsrvcPWx.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = this;
				return fyLZEIRatfvWzgZRLAebsrvcPWx;
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
			int num4 = default(int);
			int num2 = default(int);
			int num6 = default(int);
			while (true)
			{
				int num = -700253206;
				while (true)
				{
					switch (num ^ -700253203)
					{
					case 11:
						break;
					case 5:
						num4++;
						num = -700253207;
						continue;
					case 9:
						if (source._axes != null)
						{
							_axes = new List<Axis>(source._axes.Count);
							num2 = 0;
							num = -700253202;
							continue;
						}
						goto case 10;
					case 13:
						num4 = 0;
						num = -700253207;
						continue;
					case 12:
						_axes.Add((Axis)source._axes[num2].Clone());
						num2++;
						num = -700253202;
						continue;
					case 14:
						_descriptiveName = source._descriptiveName;
						_id = source._id;
						_typeGuidString = source._typeGuidString;
						if (source._elementIdentifiers != null)
						{
							_elementIdentifiers = new List<ControllerElementIdentifier>(source._elementIdentifiers.Count);
							num6 = 0;
							num = -700253201;
							continue;
						}
						goto case 9;
					case 0:
						_elementIdentifiers.Add(source._elementIdentifiers[num6].Clone());
						num6++;
						num = -700253204;
						continue;
					case 10:
						if (source._buttons != null)
						{
							_buttons = new List<Button>(source._buttons.Count);
							num = -700253216;
							continue;
						}
						goto default;
					case 1:
					{
						int num7;
						if (num6 >= source._elementIdentifiers.Count)
						{
							num = -700253212;
							num7 = num;
						}
						else
						{
							num = -700253203;
							num7 = num;
						}
						continue;
					}
					case 8:
						_buttons.Add((Button)source._buttons[num4].Clone());
						num = -700253208;
						continue;
					case 4:
					{
						int num5;
						if (num4 >= source._buttons.Count)
						{
							num = -700253205;
							num5 = num;
						}
						else
						{
							num = -700253211;
							num5 = num;
						}
						continue;
					}
					case 3:
					{
						int num3;
						if (num2 < source._axes.Count)
						{
							num = -700253215;
							num3 = num;
						}
						else
						{
							num = -700253209;
							num3 = num;
						}
						continue;
					}
					case 7:
						_name = source._name;
						num = -700253213;
						continue;
					case 2:
						num = -700253204;
						continue;
					default:
						_elementIdentifierIdCounter = source._elementIdentifierIdCounter;
						return;
					}
					break;
				}
			}
		}

		public CustomController_Editor Clone()
		{
			return new CustomController_Editor(this);
		}

		public string[] GetElementIdentifierNames()
		{
			if (_elementIdentifiers == null)
			{
				goto IL_0008;
			}
			int num = _elementIdentifiers.Count;
			goto IL_0084;
			IL_0084:
			int num2 = num;
			int num3 = 1185060585;
			goto IL_000d;
			IL_0008:
			num3 = 1185060586;
			goto IL_000d;
			IL_000d:
			string[] array = default(string[]);
			int num4 = default(int);
			while (true)
			{
				switch (num3 ^ 0x46A296EB)
				{
				case 0:
					break;
				case 6:
					array[num4] = _elementIdentifiers[num4].name;
					num3 = 1185060584;
					continue;
				case 2:
					array = new string[num2];
					num4 = 0;
					num3 = 1185060591;
					continue;
				case 4:
					goto IL_0061;
				case 1:
					goto IL_0076;
				case 3:
					num4++;
					num3 = 1185060591;
					continue;
				default:
					return array;
				}
				break;
				IL_0061:
				int num5;
				if (num4 >= num2)
				{
					num3 = 1185060590;
					num5 = num3;
				}
				else
				{
					num3 = 1185060589;
					num5 = num3;
				}
			}
			goto IL_0008;
			IL_0076:
			num = 0;
			goto IL_0084;
		}

		public int[] GetElementIdentifierIds()
		{
			int num = ((_elementIdentifiers != null) ? _elementIdentifiers.Count : 0);
			int[] array = new int[num];
			int num2 = 0;
			while (num2 < num)
			{
				while (true)
				{
					array[num2] = _elementIdentifiers[num2].id;
					num2++;
					int num3 = -1890348817;
					while (true)
					{
						switch (num3 ^ -1890348819)
						{
						case 0:
							num3 = -1890348820;
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

		public string[] GetElementIdentifierNamesTypeSorted()
		{
			List<string> list = new List<string>();
			List<string> list2 = new List<string>();
			int num = axisCount;
			int num2 = 0;
			int num6 = default(int);
			List<string> list3 = default(List<string>);
			int num5 = default(int);
			int num4 = default(int);
			while (true)
			{
				int num3 = 1418991405;
				while (true)
				{
					switch (num3 ^ 0x54941724)
					{
					case 5:
						break;
					case 7:
						num6++;
						num3 = 1418991398;
						continue;
					case 10:
						list3 = ListTools.Combine(list2, list);
						num3 = 1418991392;
						continue;
					case 6:
						if (num2 >= num)
						{
							num5 = buttonCount;
							num6 = 0;
							num3 = 1418991398;
							continue;
						}
						goto case 0;
					case 0:
						num4 = IndexOfElementIdentifier(axes[num2].elementIdentifierId);
						num3 = 1418991404;
						continue;
					case 3:
					{
						int num8 = IndexOfElementIdentifier(buttons[num6].elementIdentifierId);
						if (num8 >= 0)
						{
							list.Add(_elementIdentifiers[num8].name);
							num3 = 1418991395;
							continue;
						}
						goto case 7;
					}
					case 1:
						num2++;
						num3 = 1418991394;
						continue;
					case 2:
					{
						int num7;
						if (num6 >= num5)
						{
							num3 = 1418991406;
							num7 = num3;
						}
						else
						{
							num3 = 1418991399;
							num7 = num3;
						}
						continue;
					}
					case 9:
						num3 = 1418991394;
						continue;
					case 8:
						if (num4 >= 0)
						{
							list2.Add(_elementIdentifiers[num4].name);
							num3 = 1418991397;
							continue;
						}
						goto case 1;
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
			List<int> list3 = default(List<int>);
			int num4 = default(int);
			int num5 = default(int);
			int num3 = default(int);
			int num2 = default(int);
			while (true)
			{
				int num = 999077946;
				while (true)
				{
					switch (num ^ 0x3B8CB83C)
					{
					case 7:
						break;
					case 2:
						list3.Add(axes[num4].elementIdentifierId);
						num = 999077949;
						continue;
					case 3:
						if (num4 >= num5)
						{
							num3 = buttonCount;
							num2 = 0;
							num = 999077948;
							continue;
						}
						goto case 2;
					case 6:
						list3 = new List<int>();
						num5 = axisCount;
						num4 = 0;
						num = 999077944;
						continue;
					case 4:
						num = 999077951;
						continue;
					case 1:
						num4++;
						num = 999077951;
						continue;
					case 5:
						list.Add(buttons[num2].elementIdentifierId);
						num2++;
						num = 999077948;
						continue;
					default:
						if (num2 >= num3)
						{
							List<int> list2 = ListTools.Combine(list3, list);
							return list2.ToArray();
						}
						goto case 5;
					}
					break;
				}
			}
		}

		public ControllerElementIdentifier[] GetElementIdentifiersTypeSorted()
		{
			List<ControllerElementIdentifier> list = new List<ControllerElementIdentifier>();
			List<ControllerElementIdentifier> list2 = new List<ControllerElementIdentifier>();
			int num2 = default(int);
			int num3 = default(int);
			int num5 = default(int);
			int num6 = default(int);
			while (true)
			{
				int num = 1349042291;
				while (true)
				{
					switch (num ^ 0x5068C07A)
					{
					case 3:
						break;
					case 8:
					{
						int num8 = IndexOfElementIdentifier(buttons[num2].elementIdentifierId);
						if (num8 >= 0)
						{
							list.Add(_elementIdentifiers[num8]);
							num = 1349042298;
							continue;
						}
						goto case 0;
					}
					case 0:
						num2++;
						num = 1349042302;
						continue;
					case 5:
						num3 = buttonCount;
						num2 = 0;
						num = 1349042302;
						continue;
					case 7:
					{
						int num7;
						if (num5 >= num6)
						{
							num = 1349042303;
							num7 = num;
						}
						else
						{
							num = 1349042296;
							num7 = num;
						}
						continue;
					}
					case 6:
						num = 1349042301;
						continue;
					case 1:
						num5++;
						num = 1349042301;
						continue;
					case 9:
						num6 = axisCount;
						num5 = 0;
						num = 1349042300;
						continue;
					case 2:
					{
						int num4 = IndexOfElementIdentifier(axes[num5].elementIdentifierId);
						if (num4 >= 0)
						{
							list2.Add(_elementIdentifiers[num4]);
							num = 1349042299;
							continue;
						}
						goto case 1;
					}
					default:
						if (num2 >= num3)
						{
							List<ControllerElementIdentifier> list3 = ListTools.Combine(list2, list);
							return list3.ToArray();
						}
						goto case 8;
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
				int num3 = 112311823;
				while (true)
				{
					switch (num3 ^ 0x6B1BE0E)
					{
					case 0:
						break;
					case 1:
						num3 = 112311820;
						continue;
					case 4:
						return true;
					case 3:
						if (_elementIdentifiers[num2].id != id)
						{
							num2++;
							num3 = 112311820;
						}
						else
						{
							num3 = 112311818;
						}
						continue;
					default:
						if (num2 >= num)
						{
							return false;
						}
						goto case 3;
					}
					break;
				}
			}
		}

		public int IndexOfElementIdentifier(int id)
		{
			if (_elementIdentifiers == null)
			{
				goto IL_0008;
			}
			int num = _elementIdentifiers.Count;
			goto IL_003c;
			IL_002e:
			num = 0;
			goto IL_003c;
			IL_0008:
			int num2 = -785178742;
			goto IL_000d;
			IL_000d:
			int num3 = default(int);
			int num4 = default(int);
			while (true)
			{
				switch (num2 ^ -785178738)
				{
				case 3:
					break;
				case 4:
					goto IL_002e;
				case 2:
					num2 = -785178737;
					continue;
				case 0:
					goto IL_004d;
				default:
					if (num3 >= num4)
					{
						return -1;
					}
					goto IL_004d;
				}
				break;
				IL_004d:
				if (_elementIdentifiers[num3].id == id)
				{
					return num3;
				}
				num3++;
				num2 = -785178737;
			}
			goto IL_0008;
			IL_003c:
			num4 = num;
			num3 = 0;
			num2 = -785178740;
			goto IL_000d;
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

		internal ControllerElementType ItkSghdMnqxMWVEzfMJAkdmieon(int P_0)
		{
			ControllerElementIdentifier elementIdentifier = GetElementIdentifier(P_0);
			if (elementIdentifier == null)
			{
				return ControllerElementType.Axis;
			}
			int num = 0;
			int num4 = default(int);
			while (true)
			{
				int num2;
				int num3;
				if (num < axisCount)
				{
					num2 = 663331034;
					num3 = num2;
				}
				else
				{
					num2 = 663331033;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ 0x2789A0D8)
					{
					case 4:
						num2 = 663331034;
						continue;
					case 2:
						if (axes[num].elementIdentifierId == elementIdentifier.id)
						{
							return ControllerElementType.Axis;
						}
						num++;
						num2 = 663331037;
						continue;
					case 5:
						break;
					case 1:
						num4 = 0;
						num2 = 663331035;
						continue;
					case 0:
						if (buttons[num4].elementIdentifierId == elementIdentifier.id)
						{
							return ControllerElementType.Button;
						}
						num4++;
						num2 = 663331035;
						continue;
					default:
						if (num4 >= buttonCount)
						{
							return elementIdentifier.elementType;
						}
						goto case 0;
					}
					break;
				}
			}
		}

		internal bool EfyHKDjALBdxNBXzNJhGqlShqPla(int P_0, out AxisRange P_1)
		{
			ControllerElementIdentifier elementIdentifier = GetElementIdentifier(P_0);
			int num2 = default(int);
			while (true)
			{
				int num = -1013238657;
				while (true)
				{
					switch (num ^ -1013238659)
					{
					case 3:
						break;
					case 2:
						if (elementIdentifier == null)
						{
							P_1 = AxisRange.Full;
							return false;
						}
						num2 = 0;
						num = -1013238659;
						continue;
					case 5:
						return true;
					case 4:
						P_1 = InputTools.InvertAxisRange(P_1);
						num = -1013238664;
						continue;
					case 6:
					{
						P_1 = axes[num2].range;
						int num3;
						if (axes[num2].invert)
						{
							num = -1013238663;
							num3 = num;
						}
						else
						{
							num = -1013238664;
							num3 = num;
						}
						continue;
					}
					case 1:
						if (axes[num2].elementIdentifierId != elementIdentifier.id)
						{
							num2++;
							num = -1013238659;
						}
						else
						{
							num = -1013238661;
						}
						continue;
					default:
						if (num2 >= axisCount)
						{
							P_1 = AxisRange.Full;
							return false;
						}
						goto case 1;
					}
					break;
				}
			}
		}

		public string[] GetButtonNames()
		{
			int num = ((_buttons != null) ? _buttons.Count : 0);
			string[] array = new string[num];
			int num2 = 0;
			while (num2 < num)
			{
				while (true)
				{
					array[num2] = _buttons[num2].name;
					num2++;
					int num3 = -1515398965;
					while (true)
					{
						switch (num3 ^ -1515398966)
						{
						case 0:
							num3 = -1515398968;
							continue;
						case 2:
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

		public int[] GetButtonElementIdentifierIds()
		{
			int num = ((_buttons != null) ? _buttons.Count : 0);
			int[] array = new int[num];
			int num2 = 0;
			while (true)
			{
				int num3;
				int num4;
				if (num2 < num)
				{
					num3 = 449047412;
					num4 = num3;
				}
				else
				{
					num3 = 449047414;
					num4 = num3;
				}
				while (true)
				{
					switch (num3 ^ 0x1AC3EB77)
					{
					case 2:
						num3 = 449047412;
						continue;
					case 3:
						array[num2] = _buttons[num2].elementIdentifierId;
						num2++;
						num3 = 449047415;
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

		public string[] GetAxisNames()
		{
			int num = ((_axes != null) ? _axes.Count : 0);
			string[] array = new string[num];
			int num3 = default(int);
			while (true)
			{
				int num2 = 1442845368;
				while (true)
				{
					switch (num2 ^ 0x560012B9)
					{
					case 2:
						break;
					case 0:
						array[num3] = _axes[num3].name;
						num3++;
						num2 = 1442845373;
						continue;
					case 3:
						num2 = 1442845373;
						continue;
					case 1:
						num3 = 0;
						num2 = 1442845370;
						continue;
					default:
						if (num3 >= num)
						{
							return array;
						}
						goto case 0;
					}
					break;
				}
			}
		}

		public int[] GetAxisElementIdentifierIds()
		{
			int num = ((_axes != null) ? _axes.Count : 0);
			int[] array = default(int[]);
			int num3 = default(int);
			while (true)
			{
				int num2 = -2098862468;
				while (true)
				{
					switch (num2 ^ -2098862467)
					{
					case 2:
						break;
					case 1:
						array = new int[num];
						num3 = 0;
						num2 = -2098862467;
						continue;
					case 3:
						array[num3] = _axes[num3].elementIdentifierId;
						num3++;
						num2 = -2098862467;
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
			if (type == ControllerElementType.Axis)
			{
				goto IL_0003;
			}
			int num;
			if (type == ControllerElementType.Button)
			{
				num = -1265530117;
				goto IL_0008;
			}
			throw new NotImplementedException();
			IL_0003:
			num = -1265530120;
			goto IL_0008;
			IL_0008:
			switch (num ^ -1265530118)
			{
			case 0:
				break;
			case 2:
				return GetAxisNames();
			default:
				return GetButtonNames();
			}
			goto IL_0003;
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
				if (index >= axisCount)
				{
					return null;
				}
				return _axes[index] as T;
			}
			if (object.ReferenceEquals(typeof(T), typeof(Button)))
			{
				if (index >= buttonCount)
				{
					return null;
				}
				return _buttons[index] as T;
			}
			throw new NotImplementedException();
		}

		public void AddElement(ControllerElementType type)
		{
			if (type == ControllerElementType.Axis)
			{
				AddAxis();
				while (true)
				{
					switch (-488892187 ^ -488892185)
					{
					case 0:
						continue;
					case 2:
						return;
					}
					break;
				}
			}
			AddButton();
		}

		public void AddAxis()
		{
			axes.Add((Axis)ulsXJbsWsxxtvUDnsDvgTRzXIoj(ControllerElementType.Axis));
		}

		public void AddButton()
		{
			buttons.Add((Button)ulsXJbsWsxxtvUDnsDvgTRzXIoj(ControllerElementType.Button));
		}

		public void InsertElement(ControllerElementType type, int index)
		{
			if (type == ControllerElementType.Axis)
			{
				InsertAxis(index);
				return;
			}
			while (true)
			{
				InsertButton(index);
				int num = -1240852837;
				while (true)
				{
					switch (num ^ -1240852837)
					{
					case 2:
						goto IL_000b;
					default:
						return;
					case 1:
						break;
					case 0:
						return;
					}
					break;
					IL_000b:
					num = -1240852838;
				}
			}
		}

		public void InsertAxis(int index)
		{
			if (index >= 0)
			{
				if (index < axes.Count)
				{
					goto IL_0042;
				}
				while (true)
				{
					switch (-156769929 ^ -156769930)
					{
					case 2:
						break;
					case 1:
						goto end_IL_0012;
					default:
						goto IL_0042;
					}
					continue;
					end_IL_0012:
					break;
				}
			}
			throw new ArgumentOutOfRangeException("index");
			IL_0042:
			axes.Insert(index, (Axis)ulsXJbsWsxxtvUDnsDvgTRzXIoj(ControllerElementType.Axis));
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
			IL_0046:
			buttons.Insert(index, (Button)ulsXJbsWsxxtvUDnsDvgTRzXIoj(ControllerElementType.Button));
			int num = 356739447;
			goto IL_0017;
			IL_0012:
			num = 356739444;
			goto IL_0017;
			IL_0017:
			switch (num ^ 0x15436975)
			{
			case 0:
				break;
			default:
				return;
			case 1:
				goto IL_0034;
			case 3:
				goto IL_0046;
			case 2:
				return;
			}
			goto IL_0012;
			IL_0034:
			throw new ArgumentOutOfRangeException("index");
		}

		public void DeleteElement(ControllerElementType type, int index)
		{
			if (type == ControllerElementType.Axis)
			{
				DeleteElement<Axis>(index);
				goto IL_000a;
			}
			goto IL_0047;
			IL_0047:
			int num;
			int num2;
			if (type == ControllerElementType.Button)
			{
				num = 1717663215;
				num2 = num;
			}
			else
			{
				num = 1717663213;
				num2 = num;
			}
			goto IL_000f;
			IL_000a:
			num = 1717663214;
			goto IL_000f;
			IL_000f:
			switch (num ^ 0x666175EF)
			{
			case 4:
				break;
			case 1:
				return;
			case 0:
				DeleteElement<Button>(index);
				return;
			case 3:
				goto IL_0047;
			default:
				throw new NotImplementedException();
			}
			goto IL_000a;
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
				if (object.ReferenceEquals(typeof(T), typeof(Axis)))
				{
					if (index >= axisCount)
					{
						break;
					}
					goto IL_00f1;
				}
				goto IL_011e;
				IL_00f1:
				T val = _axes[index] as T;
				_axes.RemoveAt(index);
				int num = -994067319;
				goto IL_000a;
				IL_011e:
				if (object.ReferenceEquals(typeof(T), typeof(Button)))
				{
					if (index >= buttonCount)
					{
						break;
					}
					goto IL_009e;
				}
				goto IL_0150;
				IL_0150:
				throw new NotImplementedException();
				IL_009e:
				val = _buttons[index] as T;
				num = -994067315;
				goto IL_000a;
				IL_000a:
				while (true)
				{
					switch (num ^ -994067313)
					{
					case 7:
						num = -994067316;
						continue;
					default:
						return;
					case 3:
						break;
					case 11:
						num2--;
						num = -994067314;
						continue;
					case 2:
						_buttons.RemoveAt(index);
						num = -994067319;
						continue;
					case 4:
						goto IL_009e;
					case 0:
						goto IL_00bf;
					case 8:
						goto IL_00f1;
					case 10:
						goto IL_011e;
					case 5:
						goto IL_0150;
					case 6:
						if (_elementIdentifiers != null)
						{
							num2 = _elementIdentifiers.Count - 1;
							num = -994067314;
							continue;
						}
						return;
					case 12:
						_elementIdentifiers.RemoveAt(num2);
						num = -994067324;
						continue;
					case 1:
						goto IL_0196;
					case 9:
						return;
					}
					break;
					IL_0196:
					int num3;
					if (num2 >= 0)
					{
						num = -994067313;
						num3 = num;
					}
					else
					{
						num = -994067322;
						num3 = num;
					}
					continue;
					IL_00bf:
					int num4;
					if (_elementIdentifiers[num2].id != val.elementIdentifierId)
					{
						num = -994067324;
						num4 = num;
					}
					else
					{
						num = -994067325;
						num4 = num;
					}
				}
			}
		}

		public bool ReorderElement(ControllerElementType type, int index, bool offsetDown, bool offsetNow)
		{
			if (type == ControllerElementType.Axis)
			{
				List<Axis> list = _axes;
				if (list != null && index >= 0)
				{
					if (index < list.Count)
					{
						return ListTools.OffsetAtIndex(list, index, offsetDown, offsetNow);
					}
					goto IL_001a;
				}
				goto IL_003c;
			}
			int num;
			if (type == ControllerElementType.Button)
			{
				num = -521543095;
				goto IL_001f;
			}
			throw new NotImplementedException();
			IL_001a:
			num = -521543096;
			goto IL_001f;
			IL_003c:
			return false;
			IL_001f:
			while (true)
			{
				List<Button> list2;
				switch (num ^ -521543093)
				{
				case 0:
					break;
				case 3:
					goto IL_003c;
				case 2:
					list2 = _buttons;
					if (list2 != null && index >= 0)
					{
						goto IL_0062;
					}
					goto default;
				default:
					return false;
				}
				break;
				IL_0062:
				if (index >= list2.Count)
				{
					num = -521543094;
					continue;
				}
				return ListTools.OffsetAtIndex(list2, index, offsetDown, offsetNow);
			}
			goto IL_001a;
		}

		public void DuplicateElement(ControllerElementType type, int index)
		{
			if (type == ControllerElementType.Axis)
			{
				dodWLLZwAtsHbbABFBPTbnjykMff(index, axes);
				goto IL_0010;
			}
			goto IL_0053;
			IL_0053:
			int num;
			int num2;
			if (type != ControllerElementType.Button)
			{
				num = -787571794;
				num2 = num;
			}
			else
			{
				num = -787571800;
				num2 = num;
			}
			goto IL_0015;
			IL_0010:
			num = -787571795;
			goto IL_0015;
			IL_0015:
			switch (num ^ -787571796)
			{
			case 3:
				break;
			case 1:
				return;
			case 4:
				dodWLLZwAtsHbbABFBPTbnjykMff(index, buttons);
				return;
			case 0:
				goto IL_0053;
			default:
				throw new NotImplementedException();
			}
			goto IL_0010;
		}

		private void dodWLLZwAtsHbbABFBPTbnjykMff<T>(int P_0, List<T> P_1) where T : Element
		{
			if (P_1 != null && P_0 >= 0)
			{
				if (P_0 >= P_1.Count)
				{
					goto IL_0019;
				}
				goto IL_00c5;
			}
			goto IL_010c;
			IL_00c5:
			T val = P_1[P_0];
			string text = StringTools.IterateName(val.name, -1, GetElementNames<T>());
			int num = -1669235992;
			goto IL_001e;
			IL_010c:
			throw new ArgumentOutOfRangeException("index");
			IL_0019:
			num = -1669235985;
			goto IL_001e;
			IL_001e:
			T val2 = default(T);
			ControllerElementIdentifier controllerElementIdentifier = default(ControllerElementIdentifier);
			while (true)
			{
				switch (num ^ -1669235988)
				{
				case 6:
					break;
				case 8:
					return;
				case 5:
					if (P_0 == P_1.Count - 1)
					{
						P_1.Add(val2);
						num = -1669235996;
						continue;
					}
					goto default;
				case 7:
					if (controllerElementIdentifier == null)
					{
						Logger.LogError("Element identifier is missing! Element cannot be duplicated!");
						return;
					}
					goto case 2;
				case 2:
					val2 = (T)val.Clone();
					val2.elementIdentifierId = controllerElementIdentifier.id;
					val2.name = text;
					num = -1669235991;
					continue;
				case 0:
					goto IL_00c5;
				case 4:
					controllerElementIdentifier = wXHTiKwCeYSeLrBmeRxcGFVhWiG(val.elementIdentifierId, text);
					num = -1669235989;
					continue;
				case 3:
					goto IL_010c;
				default:
					P_1.Insert(P_0 + 1, val2);
					return;
				}
				break;
			}
			goto IL_0019;
		}

		private ControllerElementIdentifier wXHTiKwCeYSeLrBmeRxcGFVhWiG(int P_0, string P_1)
		{
			if (!ContainsElementIdentifier(P_0))
			{
				return null;
			}
			int num = IndexOfElementIdentifier(P_0);
			int elementIdentifierIdCounter = default(int);
			ControllerElementIdentifier controllerElementIdentifier = default(ControllerElementIdentifier);
			while (true)
			{
				int num2 = -282995801;
				while (true)
				{
					switch (num2 ^ -282995805)
					{
					case 0:
						break;
					case 4:
						elementIdentifierIdCounter = _elementIdentifierIdCounter;
						num2 = -282995807;
						continue;
					case 2:
						_elementIdentifierIdCounter++;
						controllerElementIdentifier = new ControllerElementIdentifier(elementIdentifierIdCounter, P_1, _elementIdentifiers[num].positiveName, _elementIdentifiers[num].negativeName, _elementIdentifiers[num].elementType, _elementIdentifiers[num].compoundElementType, _elementIdentifiers[num].isMappableOnPlatform);
						if (num == _elementIdentifiers.Count - 1)
						{
							_elementIdentifiers.Add(controllerElementIdentifier);
							num2 = -282995808;
							continue;
						}
						goto case 1;
					case 1:
						_elementIdentifiers.Insert(num + 1, controllerElementIdentifier);
						num2 = -282995808;
						continue;
					default:
						return controllerElementIdentifier;
					}
					break;
				}
			}
		}

		private Element ulsXJbsWsxxtvUDnsDvgTRzXIoj(ControllerElementType P_0)
		{
			if (P_0 == ControllerElementType.Axis)
			{
				goto IL_0003;
			}
			int num;
			if (P_0 == ControllerElementType.Button)
			{
				num = -1890715861;
				goto IL_0008;
			}
			throw new NotImplementedException();
			IL_0003:
			num = -1890715864;
			goto IL_0008;
			IL_0008:
			Button button = default(Button);
			string text = default(string);
			ControllerElementIdentifier controllerElementIdentifier = default(ControllerElementIdentifier);
			while (true)
			{
				switch (num ^ -1890715862)
				{
				case 3:
					break;
				case 2:
				{
					string text2 = StringTools.IterateName("Axis", -1, GetAxisNames());
					ControllerElementIdentifier controllerElementIdentifier2 = bakzkQOhbHYmcxQfHoxxnJkIzYz(P_0, text2, string.Empty, string.Empty);
					Axis axis = new Axis(text2);
					axis.elementIdentifierId = controllerElementIdentifier2.id;
					return axis;
				}
				case 4:
					button = new Button(text);
					button.elementIdentifierId = controllerElementIdentifier.id;
					num = -1890715862;
					continue;
				case 1:
					text = StringTools.IterateName("Button", -1, GetButtonNames());
					controllerElementIdentifier = bakzkQOhbHYmcxQfHoxxnJkIzYz(P_0, text, string.Empty, string.Empty);
					num = -1890715858;
					continue;
				default:
					return button;
				}
				break;
			}
			goto IL_0003;
		}

		private ControllerElementIdentifier bakzkQOhbHYmcxQfHoxxnJkIzYz(ControllerElementType P_0, string P_1, string P_2, string P_3)
		{
			int elementIdentifierIdCounter = _elementIdentifierIdCounter;
			_elementIdentifierIdCounter++;
			ControllerElementIdentifier controllerElementIdentifier = new ControllerElementIdentifier(elementIdentifierIdCounter, P_1, P_2, P_3, P_0, true);
			_elementIdentifiers.Add(controllerElementIdentifier);
			return controllerElementIdentifier;
		}

		internal HardwareControllerMap_Game fSqpRPKmvZEbSyvCnabcPGncEMe()
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
				IL_00d8:
				int num5;
				if (num3 >= num2)
				{
					num4 = 0;
					num5 = -2100136559;
					goto IL_0049;
				}
				goto IL_0075;
				IL_0049:
				while (true)
				{
					switch (num5 ^ -2100136560)
					{
					case 6:
						num5 = -2100136555;
						continue;
					case 5:
						break;
					case 1:
						goto IL_00a2;
					case 2:
						array2[num4] = _axes[num4].elementIdentifierId;
						num5 = -2100136557;
						continue;
					case 0:
						goto IL_00d8;
					case 3:
						array3[num4] = new AxisCalibrationData(true, _axes[num4].deadZone, _axes[num4].zero, _axes[num4].min, _axes[num4].max, _axes[num4].invert, !_axes[num4].doNotCalibrateRange, _axes[num4].sensitivityType, _axes[num4].sensitivity, UnityTools.Copy(_axes[num4].sensitivityCurve));
						array4[num4] = _axes[num4].range;
						array5[num4] = MiscTools.DeepClone(_axes[num4].axisInfo) ?? HardwareAxisInfo.Default;
						num4++;
						num5 = -2100136559;
						continue;
					default:
					{
						ControllerElementIdentifier[] elementIdentifiersTypeSorted = GetElementIdentifiersTypeSorted();
						return new HardwareControllerMap_Game(_name, _id, elementIdentifiersTypeSorted, array, array2, array3, array4, array5, array6, null);
					}
					}
					break;
					IL_00a2:
					int num6;
					if (num4 >= num)
					{
						num5 = -2100136556;
						num6 = num5;
					}
					else
					{
						num5 = -2100136558;
						num6 = num5;
					}
				}
				goto IL_0075;
				IL_0075:
				array[num3] = _buttons[num3].elementIdentifierId;
				array6[num3] = new HardwareButtonInfo();
				num3++;
				num5 = -2100136560;
				goto IL_0049;
			}
		}
	}
}
