using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using Rewired.Interfaces;
using Rewired.Utils;
using Rewired.Utils.Libraries.TinyJson;
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
					goto IL_0008;
				}
				int num = 0;
				int num2 = -1946481653;
				goto IL_000d;
				IL_000d:
				while (true)
				{
					switch (num2 ^ -1946481655)
					{
					case 0:
						break;
					case 1:
						return -1;
					case 4:
						if (elementIdentifierMappings[num].templateId == templateElementId)
						{
							return elementIdentifierMappings[num].joystickId;
						}
						num++;
						num2 = -1946481654;
						continue;
					case 2:
						num2 = -1946481654;
						continue;
					default:
						if (num >= elementIdentifierMappings.Count)
						{
							return -1;
						}
						goto case 4;
					}
					break;
				}
				goto IL_0008;
				IL_0008:
				num2 = -1946481656;
				goto IL_000d;
			}

			public int GetTemplateElementId(int joystickElementId)
			{
				if (elementIdentifierMappings == null)
				{
					goto IL_0008;
				}
				int num = 0;
				int num2 = -1150038404;
				goto IL_000d;
				IL_000d:
				while (true)
				{
					switch (num2 ^ -1150038404)
					{
					case 3:
						break;
					case 0:
					{
						int num3;
						if (num < elementIdentifierMappings.Count)
						{
							num2 = -1150038408;
							num3 = num2;
						}
						else
						{
							num2 = -1150038403;
							num3 = num2;
						}
						continue;
					}
					case 4:
						if (elementIdentifierMappings[num].joystickId == joystickElementId)
						{
							return elementIdentifierMappings[num].templateId;
						}
						num++;
						num2 = -1150038404;
						continue;
					case 2:
						return -1;
					default:
						return -1;
					}
					break;
				}
				goto IL_0008;
				IL_0008:
				num2 = -1150038402;
				goto IL_000d;
			}

			public ElementIdentifierMap GetElementIdentifierMap(int templateId)
			{
				if (elementIdentifierMappings == null)
				{
					return null;
				}
				int num = 0;
				while (true)
				{
					int num2 = 277367404;
					while (true)
					{
						switch (num2 ^ 0x10884A6D)
						{
						case 0:
							break;
						case 1:
							num2 = 277367407;
							continue;
						case 3:
							if (elementIdentifierMappings[num].templateId == templateId)
							{
								return elementIdentifierMappings[num];
							}
							num++;
							num2 = 277367407;
							continue;
						default:
							if (num >= elementIdentifierMappings.Count)
							{
								return null;
							}
							goto case 3;
						}
						break;
					}
				}
			}

			public void GetElementIdentifierMaps(int templateId, List<ElementIdentifierMap> results)
			{
				if (results == null)
				{
					return;
				}
				while (elementIdentifierMappings != null)
				{
					while (true)
					{
						IL_003e:
						int num = 0;
						int num2 = 990367169;
						while (true)
						{
							switch (num2 ^ 0x3B07CDC1)
							{
							case 5:
								num2 = 990367168;
								continue;
							case 1:
								break;
							case 2:
								goto IL_003e;
							case 3:
								num++;
								num2 = 990367169;
								continue;
							case 4:
								if (elementIdentifierMappings[num].templateId == templateId)
								{
									results.Add(elementIdentifierMappings[num]);
									num2 = 990367170;
									continue;
								}
								goto case 3;
							default:
								if (num >= elementIdentifierMappings.Count)
								{
									return;
								}
								goto case 4;
							}
							break;
						}
						break;
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
				T value;
				JsonParser.TryFromJson<T>(data, out value);
				return value;
			}
		}

		private sealed class JhGareKBXhcgHjMCreIKzSpGNpyM : IDisposable, IEnumerator, IEnumerable, IEnumerable<ControllerTemplateElementIdentifier>, IEnumerator<ControllerTemplateElementIdentifier>
		{
			private ControllerTemplateElementIdentifier aimBzjfQfPyaeQqysAQJISCBhELB;

			private int oGuYQSzFTrBqEKPsNTGqdIaaAqGg;

			private int HbSVCfYbFQknCSDIuBJpKcqKonb;

			public HardwareJoystickTemplateMap iKQXbXnVtIaMZEJNeigQJWAHqUx;

			public int JgkqHoXbaGSqSpATxoAvQPPuCvQ;

			ControllerTemplateElementIdentifier IEnumerator<ControllerTemplateElementIdentifier>.Current
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
			IEnumerator<ControllerTemplateElementIdentifier> IEnumerable<ControllerTemplateElementIdentifier>.GetEnumerator()
			{
				JhGareKBXhcgHjMCreIKzSpGNpyM jhGareKBXhcgHjMCreIKzSpGNpyM;
				if (Thread.CurrentThread.ManagedThreadId == HbSVCfYbFQknCSDIuBJpKcqKonb && oGuYQSzFTrBqEKPsNTGqdIaaAqGg == -2)
				{
					oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 0;
					jhGareKBXhcgHjMCreIKzSpGNpyM = this;
				}
				else
				{
					while (true)
					{
						jhGareKBXhcgHjMCreIKzSpGNpyM = new JhGareKBXhcgHjMCreIKzSpGNpyM(0);
						jhGareKBXhcgHjMCreIKzSpGNpyM.iKQXbXnVtIaMZEJNeigQJWAHqUx = iKQXbXnVtIaMZEJNeigQJWAHqUx;
						int num = -1212526536;
						while (true)
						{
							switch (num ^ -1212526536)
							{
							case 2:
								num = -1212526535;
								continue;
							case 1:
								break;
							default:
								goto end_IL_0045;
							}
							break;
						}
						continue;
						end_IL_0045:
						break;
					}
				}
				return jhGareKBXhcgHjMCreIKzSpGNpyM;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ControllerTemplateElementIdentifier>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				int num;
				switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
				{
				case 0:
					oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
					num = 2060505912;
					goto IL_001f;
				case 1:
					{
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
						JgkqHoXbaGSqSpATxoAvQPPuCvQ++;
						num = 2060505919;
						goto IL_001f;
					}
					IL_001f:
					while (true)
					{
						switch (num ^ 0x7AD0D33C)
						{
						case 6:
							num = 2060505917;
							continue;
						case 1:
							break;
						case 2:
							aimBzjfQfPyaeQqysAQJISCBhELB = iKQXbXnVtIaMZEJNeigQJWAHqUx.elementIdentifiers[JgkqHoXbaGSqSpATxoAvQPPuCvQ];
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
							return true;
						case 3:
							goto IL_0096;
						case 0:
							JgkqHoXbaGSqSpATxoAvQPPuCvQ = 0;
							num = 2060505919;
							continue;
						case 4:
							goto IL_00d0;
						default:
							goto end_IL_0008;
						}
						break;
						IL_00d0:
						int num2;
						if (iKQXbXnVtIaMZEJNeigQJWAHqUx.elementIdentifiers != null)
						{
							num = 2060505916;
							num2 = num;
						}
						else
						{
							num = 2060505913;
							num2 = num;
						}
						continue;
						IL_0096:
						int num3;
						if (JgkqHoXbaGSqSpATxoAvQPPuCvQ >= iKQXbXnVtIaMZEJNeigQJWAHqUx.elementIdentifiers.Length)
						{
							num = 2060505913;
							num3 = num;
						}
						else
						{
							num = 2060505918;
							num3 = num;
						}
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
			public JhGareKBXhcgHjMCreIKzSpGNpyM(int _003C_003E1__state)
			{
				oGuYQSzFTrBqEKPsNTGqdIaaAqGg = _003C_003E1__state;
				HbSVCfYbFQknCSDIuBJpKcqKonb = Thread.CurrentThread.ManagedThreadId;
			}
		}

		private sealed class NHRIHAEnromcdGItXQgRKErcjtv : IDisposable, IEnumerator, IEnumerable, IEnumerable<IControllerElementIdentifierCommon_Internal>, IEnumerator<IControllerElementIdentifierCommon_Internal>
		{
			private IControllerElementIdentifierCommon_Internal aimBzjfQfPyaeQqysAQJISCBhELB;

			private int oGuYQSzFTrBqEKPsNTGqdIaaAqGg;

			private int HbSVCfYbFQknCSDIuBJpKcqKonb;

			public HardwareJoystickTemplateMap iKQXbXnVtIaMZEJNeigQJWAHqUx;

			public int ZeVdSxGRjjMJrWvXcGQSyIacEUNe;

			IControllerElementIdentifierCommon_Internal IEnumerator<IControllerElementIdentifierCommon_Internal>.Current
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
			IEnumerator<IControllerElementIdentifierCommon_Internal> IEnumerable<IControllerElementIdentifierCommon_Internal>.GetEnumerator()
			{
				NHRIHAEnromcdGItXQgRKErcjtv nHRIHAEnromcdGItXQgRKErcjtv;
				if (Thread.CurrentThread.ManagedThreadId == HbSVCfYbFQknCSDIuBJpKcqKonb && oGuYQSzFTrBqEKPsNTGqdIaaAqGg == -2)
				{
					oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 0;
					nHRIHAEnromcdGItXQgRKErcjtv = this;
				}
				else
				{
					while (true)
					{
						nHRIHAEnromcdGItXQgRKErcjtv = new NHRIHAEnromcdGItXQgRKErcjtv(0);
						int num = 1715111244;
						while (true)
						{
							switch (num ^ 0x663A854C)
							{
							case 2:
								num = 1715111245;
								continue;
							case 1:
								break;
							case 0:
								nHRIHAEnromcdGItXQgRKErcjtv.iKQXbXnVtIaMZEJNeigQJWAHqUx = iKQXbXnVtIaMZEJNeigQJWAHqUx;
								num = 1715111247;
								continue;
							default:
								goto end_IL_0049;
							}
							break;
						}
						continue;
						end_IL_0049:
						break;
					}
				}
				return nHRIHAEnromcdGItXQgRKErcjtv;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<IControllerElementIdentifierCommon_Internal>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				int num;
				switch (oGuYQSzFTrBqEKPsNTGqdIaaAqGg)
				{
				case 0:
					oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
					num = -894292246;
					goto IL_001f;
				case 1:
					{
						oGuYQSzFTrBqEKPsNTGqdIaaAqGg = -1;
						num = -894292241;
						goto IL_001f;
					}
					IL_001f:
					while (true)
					{
						switch (num ^ -894292242)
						{
						case 3:
							num = -894292244;
							continue;
						case 2:
							break;
						case 8:
							aimBzjfQfPyaeQqysAQJISCBhELB = iKQXbXnVtIaMZEJNeigQJWAHqUx.elementIdentifiers[ZeVdSxGRjjMJrWvXcGQSyIacEUNe];
							num = -894292248;
							continue;
						case 4:
							if (iKQXbXnVtIaMZEJNeigQJWAHqUx.elementIdentifiers != null)
							{
								ZeVdSxGRjjMJrWvXcGQSyIacEUNe = 0;
								num = -894292242;
								continue;
							}
							goto end_IL_0008;
						case 1:
							ZeVdSxGRjjMJrWvXcGQSyIacEUNe++;
							num = -894292242;
							continue;
						case 5:
							return true;
						case 6:
							oGuYQSzFTrBqEKPsNTGqdIaaAqGg = 1;
							num = -894292245;
							continue;
						case 0:
							goto IL_00d7;
						default:
							goto end_IL_0008;
						}
						break;
						IL_00d7:
						int num2;
						if (ZeVdSxGRjjMJrWvXcGQSyIacEUNe >= iKQXbXnVtIaMZEJNeigQJWAHqUx.elementIdentifiers.Length)
						{
							num = -894292247;
							num2 = num;
						}
						else
						{
							num = -894292250;
							num2 = num;
						}
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
			public NHRIHAEnromcdGItXQgRKErcjtv(int _003C_003E1__state)
			{
				oGuYQSzFTrBqEKPsNTGqdIaaAqGg = _003C_003E1__state;
				HbSVCfYbFQknCSDIuBJpKcqKonb = Thread.CurrentThread.ManagedThreadId;
			}
		}

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private string controllerName;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private string description;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string templateGuid;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private string className;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private ControllerTemplateElementIdentifier_Editor[] elementIdentifiers;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private List<Entry> joysticks;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private SpecialElementEntry[] specialElements = new SpecialElementEntry[0];

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private int elementIdentifierIdCounter;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private int joystickIdCounter;

		public override Guid Guid
		{
			get
			{
				return StringTools.ToGuid(templateGuid);
			}
		}

		public string ControllerName
		{
			get
			{
				return controllerName;
			}
		}

		public string ClassName
		{
			get
			{
				return className;
			}
		}

		public IEnumerable<ControllerTemplateElementIdentifier> ElementIdentifiers
		{
			get
			{
				JhGareKBXhcgHjMCreIKzSpGNpyM jhGareKBXhcgHjMCreIKzSpGNpyM = new JhGareKBXhcgHjMCreIKzSpGNpyM(-2);
				jhGareKBXhcgHjMCreIKzSpGNpyM.iKQXbXnVtIaMZEJNeigQJWAHqUx = this;
				return jhGareKBXhcgHjMCreIKzSpGNpyM;
			}
		}

		IEnumerable<IControllerElementIdentifierCommon_Internal> IHardwareControllerMap_Internal.ElementIdentifiers
		{
			get
			{
				NHRIHAEnromcdGItXQgRKErcjtv nHRIHAEnromcdGItXQgRKErcjtv = new NHRIHAEnromcdGItXQgRKErcjtv(-2);
				nHRIHAEnromcdGItXQgRKErcjtv.iKQXbXnVtIaMZEJNeigQJWAHqUx = this;
				return nHRIHAEnromcdGItXQgRKErcjtv;
			}
		}

		string IHardwareControllerTemplateMap_Internal.name
		{
			get
			{
				return controllerName;
			}
		}

		Guid IHardwareControllerTemplateMap_Internal.typeGuid
		{
			get
			{
				return Guid;
			}
		}

		[CustomObfuscation(rename = false)]
		public ControllerTemplateElementIdentifier GetElementIdentifier(int id)
		{
			int num = PehHoCchNiANONEXkwEgzBLPEmn(id);
			if (num >= 0)
			{
				while (true)
				{
					int num2 = -813188587;
					while (true)
					{
						switch (num2 ^ -813188588)
						{
						case 0:
							break;
						case 1:
							goto IL_002a;
						default:
							goto end_IL_000c;
						}
						break;
						IL_002a:
						if (num >= elementIdentifiers.Length)
						{
							num2 = -813188586;
							continue;
						}
						return elementIdentifiers[num];
					}
					continue;
					end_IL_000c:
					break;
				}
			}
			return null;
		}

		[CustomObfuscation(rename = false)]
		public bool ContainsElementIdentifier(int id)
		{
			return PehHoCchNiANONEXkwEgzBLPEmn(id) >= 0;
		}

		[CustomObfuscation(rename = false)]
		public string[] GetElementIdentifierNames()
		{
			int num = ((elementIdentifiers != null) ? elementIdentifiers.Length : 0);
			string[] array = default(string[]);
			int num3 = default(int);
			while (true)
			{
				int num2 = 299361708;
				while (true)
				{
					switch (num2 ^ 0x11D7E5AF)
					{
					case 4:
						break;
					case 3:
						array = new string[num];
						num3 = 0;
						num2 = 299361709;
						continue;
					case 2:
					{
						int num4;
						if (num3 < num)
						{
							num2 = 299361710;
							num4 = num2;
						}
						else
						{
							num2 = 299361711;
							num4 = num2;
						}
						continue;
					}
					case 1:
						array[num3] = elementIdentifiers[num3].name;
						num3++;
						num2 = 299361709;
						continue;
					default:
						return array;
					}
					break;
				}
			}
		}

		[CustomObfuscation(rename = false)]
		public int[] GetElementIdentifierIds()
		{
			int num = ((elementIdentifiers != null) ? elementIdentifiers.Length : 0);
			int[] array = new int[num];
			int num3 = default(int);
			while (true)
			{
				int num2 = 564136528;
				while (true)
				{
					switch (num2 ^ 0x21A00A51)
					{
					case 0:
						break;
					case 1:
						num3 = 0;
						num2 = 564136531;
						continue;
					case 3:
						array[num3] = elementIdentifiers[num3].id;
						num3++;
						num2 = 564136531;
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

		[CustomObfuscation(rename = false)]
		internal string[] GetElementIdentifierScriptingNames(bool useAlternate)
		{
			int num = ((elementIdentifiers != null) ? elementIdentifiers.Length : 0);
			string[] array = new string[num];
			int num2 = 0;
			while (num2 < num)
			{
				while (true)
				{
					array[num2] = (useAlternate ? elementIdentifiers[num2].alternateScriptingName : elementIdentifiers[num2].scriptingName);
					num2++;
					int num3 = -2001635883;
					while (true)
					{
						switch (num3 ^ -2001635881)
						{
						case 0:
							num3 = -2001635882;
							continue;
						case 1:
							break;
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
			return array;
		}

		public int GetMappableElementIdentifierInfo(out string[] names, out int[] ids)
		{
			names = EmptyObjects<string>.array;
			List<ControllerTemplateElementIdentifier> list = default(List<ControllerTemplateElementIdentifier>);
			int num3 = default(int);
			int num4 = default(int);
			int num2 = default(int);
			int count = default(int);
			while (true)
			{
				int num = 943201855;
				while (true)
				{
					switch (num ^ 0x38381E36)
					{
					case 0:
						break;
					case 11:
						list.Add(elementIdentifiers[num3]);
						num = 943201841;
						continue;
					case 2:
						num4 = ((elementIdentifiers != null) ? elementIdentifiers.Length : 0);
						if (num4 == 0)
						{
							return 0;
						}
						list = new List<ControllerTemplateElementIdentifier>();
						num3 = 0;
						num = 943201852;
						continue;
					case 10:
						num = 943201843;
						continue;
					case 8:
						names[num2] = list[num2].name;
						ids[num2] = list[num2].id;
						num2++;
						num = 943201842;
						continue;
					case 1:
						num = 943201842;
						continue;
					case 6:
						if (elementIdentifiers[num3] != null)
						{
							int num5;
							if (InputTools.IsMappableType(elementIdentifiers[num3].elementType))
							{
								num = 943201853;
								num5 = num;
							}
							else
							{
								num = 943201841;
								num5 = num;
							}
							continue;
						}
						goto case 7;
					case 9:
						ids = EmptyObjects<int>.array;
						num = 943201844;
						continue;
					case 5:
						if (num3 >= num4)
						{
							count = list.Count;
							num = 943201845;
							continue;
						}
						goto case 6;
					case 7:
						num3++;
						num = 943201843;
						continue;
					case 3:
						if (count == 0)
						{
							return 0;
						}
						names = new string[count];
						ids = new int[count];
						num2 = 0;
						num = 943201847;
						continue;
					default:
						if (num2 >= count)
						{
							return count;
						}
						goto case 8;
					}
					break;
				}
			}
		}

		public int GetNonMappableElementIdentifierInfo(out string[] names, out int[] ids)
		{
			names = EmptyObjects<string>.array;
			int num3 = default(int);
			int num4 = default(int);
			List<ControllerTemplateElementIdentifier> list = default(List<ControllerTemplateElementIdentifier>);
			int num2 = default(int);
			int count = default(int);
			while (true)
			{
				int num = -244907572;
				while (true)
				{
					switch (num ^ -244907580)
					{
					case 10:
						break;
					case 4:
						num3++;
						num = -244907578;
						continue;
					case 9:
						num = -244907578;
						continue;
					case 1:
						num4 = ((elementIdentifiers != null) ? elementIdentifiers.Length : 0);
						if (num4 == 0)
						{
							num = -244907577;
							continue;
						}
						list = new List<ControllerTemplateElementIdentifier>();
						num3 = 0;
						num = -244907571;
						continue;
					case 7:
						ids[num2] = list[num2].id;
						num2++;
						num = -244907582;
						continue;
					case 11:
						names[num2] = list[num2].name;
						num = -244907581;
						continue;
					case 2:
						if (num3 >= num4)
						{
							count = list.Count;
							if (count == 0)
							{
								return 0;
							}
							names = new string[count];
							ids = new int[count];
							num2 = 0;
							num = -244907582;
							continue;
						}
						goto case 0;
					case 5:
						list.Add(elementIdentifiers[num3]);
						num = -244907584;
						continue;
					case 8:
						ids = EmptyObjects<int>.array;
						num = -244907579;
						continue;
					case 0:
						if (elementIdentifiers[num3] != null)
						{
							int num5;
							if (InputTools.IsMappableType(elementIdentifiers[num3].elementType))
							{
								num = -244907584;
								num5 = num;
							}
							else
							{
								num = -244907583;
								num5 = num;
							}
							continue;
						}
						goto case 4;
					case 3:
						return 0;
					default:
						if (num2 >= count)
						{
							return count;
						}
						goto case 11;
					}
					break;
				}
			}
		}

		public string[] GetJoystickNames()
		{
			int num = ((joysticks != null) ? joysticks.Count : 0);
			string[] array = new string[num];
			int num2 = 0;
			while (true)
			{
				int num3;
				int num4;
				if (num2 >= num)
				{
					num3 = -2099874507;
					num4 = num3;
				}
				else
				{
					num3 = -2099874505;
					num4 = num3;
				}
				while (true)
				{
					switch (num3 ^ -2099874508)
					{
					case 2:
						num3 = -2099874505;
						continue;
					case 3:
						array[num2] = joysticks[num2].name;
						num2++;
						num3 = -2099874508;
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

		public int[] GetJoystickIds()
		{
			if (joysticks == null)
			{
				goto IL_0008;
			}
			int num = joysticks.Count;
			goto IL_0040;
			IL_0040:
			int num2 = num;
			int[] array = new int[num2];
			int num3 = 0;
			int num4 = -1357981951;
			goto IL_000d;
			IL_0008:
			num4 = -1357981952;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num4 ^ -1357981948)
				{
				case 0:
					break;
				case 4:
					goto IL_0032;
				case 5:
					num4 = -1357981946;
					continue;
				case 3:
					array[num3] = joysticks[num3].id;
					num3++;
					num4 = -1357981946;
					continue;
				case 2:
					goto IL_0077;
				default:
					return array;
				}
				break;
				IL_0077:
				int num5;
				if (num3 >= num2)
				{
					num4 = -1357981947;
					num5 = num4;
				}
				else
				{
					num4 = -1357981945;
					num5 = num4;
				}
			}
			goto IL_0008;
			IL_0032:
			num = 0;
			goto IL_0040;
		}

		public Guid GetJoystickGuid(int joystickId)
		{
			if (joysticks == null)
			{
				return Guid.Empty;
			}
			int num = 0;
			while (num < joysticks.Count)
			{
				while (true)
				{
					if (joysticks[num].id == joystickId)
					{
						return StringTools.ToGuid(joysticks[num].joystickGuid);
					}
					num++;
					int num2 = 1085276181;
					while (true)
					{
						switch (num2 ^ 0x40B00015)
						{
						case 2:
							num2 = 1085276180;
							continue;
						case 1:
							break;
						default:
							goto end_IL_0030;
						}
						break;
					}
					continue;
					end_IL_0030:
					break;
				}
			}
			return Guid.Empty;
		}

		public int GetJoystickId(Guid guid)
		{
			int num = 0;
			while (true)
			{
				int num2 = 1092591542;
				while (true)
				{
					switch (num2 ^ 0x411F9FB4)
					{
					case 0:
						break;
					case 2:
						num2 = 1092591541;
						continue;
					case 3:
						if (StringTools.ToGuid(joysticks[num].joystickGuid) == guid)
						{
							return joysticks[num].id;
						}
						num++;
						num2 = 1092591541;
						continue;
					default:
						if (num >= joysticks.Count)
						{
							return -1;
						}
						goto case 3;
					}
					break;
				}
			}
		}

		public string GetJoystickFileGuidString(int joystickId)
		{
			if (joysticks == null)
			{
				return string.Empty;
			}
			int num = 0;
			while (true)
			{
				int num2;
				int num3;
				if (num < joysticks.Count)
				{
					num2 = -369910848;
					num3 = num2;
				}
				else
				{
					num2 = -369910846;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ -369910846)
					{
					case 3:
						num2 = -369910848;
						continue;
					case 2:
						if (joysticks[num].id == joystickId)
						{
							return joysticks[num].fileGuid;
						}
						num++;
						num2 = -369910845;
						continue;
					case 1:
						break;
					default:
						return string.Empty;
					}
					break;
				}
			}
		}

		internal bool gXYtfQHDORUhFLHiQPsElDGjDcyi(ControllerMap_Editor P_0, HardwareJoystickMap P_1, Guid P_2, out string P_3)
		{
			if (P_0 == null)
			{
				goto IL_0003;
			}
			P_0.hardwareGuidString = P_2.ToString();
			Entry entry = aiHwPNekHXEhGGWjXNksfPnxocu(P_2);
			int num = -361797434;
			goto IL_0008;
			IL_0008:
			switch (num ^ -361797433)
			{
			case 0:
				break;
			case 2:
				P_3 = "Template Map was null.";
				return false;
			default:
			{
				if (entry == null)
				{
					P_3 = string.Concat("Hardware guid not found in ControllerDataFiles: ", P_2, "\nThis error should never happen. Please contact support.");
					return false;
				}
				List<ActionElementMap> actionElementMaps = P_0.actionElementMaps;
				using (TempListPool.TList<ActionElementMap> tList = TempListPool.GetTList<ActionElementMap>())
				{
					List<ActionElementMap> list = tList.list;
					using (TempListPool.TList<ElementIdentifierMap> tList2 = TempListPool.GetTList<ElementIdentifierMap>())
					{
						List<ElementIdentifierMap> list2 = tList2.list;
						ElementIdentifierMap elementIdentifierMap = default(ElementIdentifierMap);
						int num5 = default(int);
						ActionElementMap actionElementMap = default(ActionElementMap);
						ActionElementMap actionElementMap3 = default(ActionElementMap);
						ActionElementMap actionElementMap2 = default(ActionElementMap);
						bool flag = default(bool);
						int num3 = default(int);
						ControllerTemplateElementType effectiveElementType = default(ControllerTemplateElementType);
						ControllerElementIdentifier elementIdentifier = default(ControllerElementIdentifier);
						ControllerTemplateElementIdentifier_Editor controllerTemplateElementIdentifier_Editor = default(ControllerTemplateElementIdentifier_Editor);
						int elementIdentifierId = default(int);
						while (true)
						{
							IL_008e:
							int num2 = -361797421;
							while (true)
							{
								switch (num2 ^ -361797433)
								{
								case 25:
									break;
								case 21:
									elementIdentifierMap = list2[num5];
									if (elementIdentifierMap != null && elementIdentifierMap.joystickId >= 0)
									{
										actionElementMap = new ActionElementMap(actionElementMap3);
										actionElementMap2 = null;
										flag = false;
										num2 = -361797437;
										continue;
									}
									goto case 17;
								case 27:
									actionElementMap._axisRange = AxisRange.Positive;
									actionElementMap._elementType = ControllerElementType.Axis;
									num2 = -361797427;
									continue;
								case 26:
									actionElementMap._axisContribution = Pole.Negative;
									num2 = -361797417;
									continue;
								case 2:
								{
									int num10;
									if (actionElementMap.axisType == AxisType.Normal)
									{
										num2 = -361797433;
										num10 = num2;
									}
									else
									{
										num2 = -361797423;
										num10 = num2;
									}
									continue;
								}
								case 11:
									if (num5 >= list2.Count)
									{
										num3++;
										num2 = -361797440;
										continue;
									}
									goto case 21;
								case 28:
									if (jHLGlrXjGMMIuxAEONcGlnwHltw.CGvNMgTtJKByfBoLCudPLkyvgkV(effectiveElementType, elementIdentifier.elementType))
									{
										goto case 10;
									}
									if (effectiveElementType == ControllerTemplateElementType.Axis)
									{
										int num4;
										if (elementIdentifier.elementType != ControllerElementType.Button)
										{
											num2 = -361797439;
											num4 = num2;
										}
										else
										{
											num2 = -361797424;
											num4 = num2;
										}
										continue;
									}
									goto case 6;
								case 1:
								{
									actionElementMap2._elementIdentifierId = elementIdentifierMap.joystickId2;
									int num11;
									if (!actionElementMap._invert)
									{
										num2 = -361797426;
										num11 = num2;
									}
									else
									{
										num2 = -361797411;
										num11 = num2;
									}
									continue;
								}
								case 3:
									effectiveElementType = controllerTemplateElementIdentifier_Editor.effectiveElementType;
									num2 = -361797413;
									continue;
								case 15:
									actionElementMap._elementType = ControllerElementType.Button;
									num2 = -361797427;
									continue;
								case 5:
									list2.Clear();
									actionElementMap3 = actionElementMaps[num3];
									elementIdentifierId = actionElementMap3._elementIdentifierId;
									entry.GetElementIdentifierMaps(elementIdentifierId, list2);
									num2 = -361797420;
									continue;
								case 4:
								{
									int num7 = PehHoCchNiANONEXkwEgzBLPEmn(elementIdentifierId);
									if (num7 >= 0 && num7 < elementIdentifiers.Length)
									{
										elementIdentifier = P_1.GetElementIdentifier(elementIdentifierMap.joystickId);
										controllerTemplateElementIdentifier_Editor = elementIdentifiers[num7];
										if (elementIdentifier != null)
										{
											int num8;
											if (controllerTemplateElementIdentifier_Editor == null)
											{
												num2 = -361797427;
												num8 = num2;
											}
											else
											{
												num2 = -361797436;
												num8 = num2;
											}
											continue;
										}
									}
									goto case 10;
								}
								case 8:
									list.Add(actionElementMap);
									if (actionElementMap2 != null)
									{
										list.Add(actionElementMap2);
										num2 = -361797418;
										continue;
									}
									goto case 17;
								case 10:
									if (!flag)
									{
										actionElementMap._elementIdentifierId = elementIdentifierMap.joystickId;
										num2 = -361797425;
										continue;
									}
									goto case 8;
								case 24:
									num2 = -361797430;
									continue;
								case 14:
									actionElementMap2._axisContribution = Pole.Negative;
									num2 = -361797432;
									continue;
								case 12:
									throw new NotImplementedException();
								case 6:
									if (effectiveElementType == ControllerTemplateElementType.Button)
									{
										int num9;
										if (elementIdentifier.elementType == ControllerElementType.Axis)
										{
											num2 = -361797412;
											num9 = num2;
										}
										else
										{
											num2 = -361797429;
											num9 = num2;
										}
										continue;
									}
									goto case 12;
								case 13:
									flag = true;
									num2 = -361797432;
									continue;
								case 9:
									actionElementMap._axisContribution = Pole.Positive;
									num2 = -361797431;
									continue;
								case 19:
									num5 = 0;
									num2 = -361797428;
									continue;
								case 17:
									num5++;
									num2 = -361797428;
									continue;
								case 23:
								{
									int num6;
									if (elementIdentifierMap.splitAxis)
									{
										num2 = -361797435;
										num6 = num2;
									}
									else
									{
										num2 = -361797432;
										num6 = num2;
									}
									continue;
								}
								case 22:
									if (actionElementMap.axisType != AxisType.Split)
									{
										goto case 15;
									}
									if (actionElementMap._axisRange == AxisRange.Positive)
									{
										actionElementMap._elementIdentifierId = elementIdentifierMap.joystickId;
										num2 = -361797409;
										continue;
									}
									goto case 18;
								case 16:
									actionElementMap2._axisContribution = Pole.Positive;
									num2 = -361797432;
									continue;
								case 20:
									num3 = 0;
									num2 = -361797440;
									continue;
								case 18:
									if (actionElementMap._axisRange == AxisRange.Negative)
									{
										actionElementMap._elementIdentifierId = elementIdentifierMap.joystickId2;
										num2 = -361797430;
										continue;
									}
									goto case 13;
								case 0:
									if (actionElementMap._axisRange == AxisRange.Full)
									{
										actionElementMap2 = new ActionElementMap(actionElementMap);
										actionElementMap2._elementType = ControllerElementType.Button;
										num2 = -361797434;
										continue;
									}
									goto case 22;
								default:
									if (num3 >= actionElementMaps.Count)
									{
										goto end_IL_0093;
									}
									goto case 5;
								}
								goto IL_008e;
								continue;
								end_IL_0093:
								break;
							}
							break;
						}
					}
					actionElementMaps.Clear();
					ListTools.CopyTo(list, actionElementMaps);
				}
				P_3 = null;
				return true;
			}
			}
			goto IL_0003;
			IL_0003:
			num = -361797435;
			goto IL_0008;
		}

		internal ControllerTemplateElementIdentifier kZyebRAzUtSAJHkfiJvLlRHqLYz(Guid P_0, int P_1)
		{
			int num = default(int);
			int num2 = default(int);
			int num3;
			if (!(P_0 == Guid.Empty))
			{
				if (P_1 < 0)
				{
					goto IL_0017;
				}
				if (joysticks == null)
				{
					return null;
				}
				num = -1;
				num2 = 0;
				num3 = 166210289;
				goto IL_001c;
			}
			goto IL_0096;
			IL_0017:
			num3 = 166210294;
			goto IL_001c;
			IL_001c:
			Entry entry;
			while (true)
			{
				switch (num3 ^ 0x9E82AF0)
				{
				case 4:
					break;
				case 7:
					num2++;
					num3 = 166210289;
					continue;
				case 3:
					goto IL_0057;
				case 2:
					goto IL_0077;
				case 6:
					goto IL_0096;
				case 1:
					goto IL_00b0;
				case 5:
					if (joysticks[num2].JoystickGuid == P_0)
					{
						num = num2;
						num3 = 166210291;
						continue;
					}
					goto case 7;
				default:
					return null;
				}
				break;
				IL_00b0:
				int num4;
				if (num2 < joysticks.Count)
				{
					num3 = 166210290;
					num4 = num3;
				}
				else
				{
					num3 = 166210291;
					num4 = num3;
				}
				continue;
				IL_0077:
				int num5;
				if (joysticks[num2] != null)
				{
					num3 = 166210293;
					num5 = num3;
				}
				else
				{
					num3 = 166210295;
					num5 = num3;
				}
				continue;
				IL_0057:
				if (num < 0)
				{
					return null;
				}
				entry = joysticks[num];
				if (entry == null)
				{
					num3 = 166210288;
					continue;
				}
				goto IL_00fc;
			}
			goto IL_0017;
			IL_00fc:
			int templateElementId = entry.GetTemplateElementId(P_1);
			if (templateElementId < 0)
			{
				return null;
			}
			return GetElementIdentifier(templateElementId);
			IL_0096:
			return null;
		}

		[CustomObfuscation(rename = false)]
		internal SpecialElementEntry[] GetSpecialElementsOrig()
		{
			return specialElements;
		}

		private Entry aiHwPNekHXEhGGWjXNksfPnxocu(Guid P_0)
		{
			if (joysticks == null)
			{
				return null;
			}
			int num = 0;
			while (true)
			{
				int num2 = -1176982353;
				while (true)
				{
					switch (num2 ^ -1176982354)
					{
					case 0:
						break;
					case 3:
						return joysticks[num];
					case 4:
						if (!(joysticks[num].JoystickGuid == P_0))
						{
							num++;
							num2 = -1176982356;
						}
						else
						{
							num2 = -1176982355;
						}
						continue;
					case 1:
						num2 = -1176982356;
						continue;
					default:
						if (num >= joysticks.Count)
						{
							return null;
						}
						goto case 4;
					}
					break;
				}
			}
		}

		private int PehHoCchNiANONEXkwEgzBLPEmn(int P_0)
		{
			if (elementIdentifiers == null)
			{
				return -1;
			}
			int num = 0;
			while (true)
			{
				int num2;
				int num3;
				if (num >= elementIdentifiers.Length)
				{
					num2 = 390623700;
					num3 = num2;
				}
				else
				{
					num2 = 390623703;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ 0x174871D5)
					{
					case 0:
						num2 = 390623703;
						continue;
					case 2:
						if (elementIdentifiers[num].id == P_0)
						{
							return num;
						}
						num++;
						num2 = 390623702;
						continue;
					case 3:
						break;
					default:
						return -1;
					}
					break;
				}
			}
		}

		IControllerElementIdentifierCommon_Internal IHardwareControllerMap_Internal.GetElementIdentifier(int P_0)
		{
			return GetElementIdentifier(P_0);
		}

		int IHardwareControllerTemplateMap_Internal.GetElementIdentifierCount()
		{
			if (elementIdentifiers == null)
			{
				return 0;
			}
			return elementIdentifiers.Length;
		}

		IControllerTemplateElementIdentifier IHardwareControllerTemplateMap_Internal.GetTemplateElementIdentifier(int P_0)
		{
			if (elementIdentifiers == null)
			{
				return null;
			}
			return elementIdentifiers[P_0];
		}

		IControllerTemplateElementIdentifier IHardwareControllerTemplateMap_Internal.GetTemplateElementIdentifierById(int P_0)
		{
			return GetElementIdentifier(P_0);
		}

		IControllerTemplateMapSpecialElement_Internal IHardwareControllerTemplateMap_Internal.GetSpecialTemplateElementByElementIdentifierId(int P_0)
		{
			if (specialElements == null)
			{
				goto IL_0008;
			}
			int num = 0;
			int num2 = -1467453448;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num2 ^ -1467453447)
				{
				case 0:
					break;
				case 3:
					return null;
				case 4:
					if (specialElements[num].elementIdentifierId == P_0)
					{
						return specialElements[num];
					}
					goto IL_0052;
				case 2:
					if (specialElements[num] != null)
					{
						num2 = -1467453443;
						continue;
					}
					goto IL_0052;
				default:
					{
						if (num >= specialElements.Length)
						{
							return null;
						}
						goto case 2;
					}
					IL_0052:
					num++;
					num2 = -1467453448;
					continue;
				}
				break;
			}
			goto IL_0008;
			IL_0008:
			num2 = -1467453446;
			goto IL_000d;
		}

		qFwngCMEUbVOUWUBpxMUVdPUzPt IHardwareControllerTemplateMap_Internal.GetAxisTarget(Controller P_0, int P_1)
		{
			ControllerTemplateElementIdentifier elementIdentifier = GetElementIdentifier(P_1);
			if (elementIdentifier == null)
			{
				return null;
			}
			if (elementIdentifier.elementType != ControllerTemplateElementType.Axis)
			{
				return null;
			}
			if (P_0 == null)
			{
				goto IL_001a;
			}
			Entry entry = aiHwPNekHXEhGGWjXNksfPnxocu(P_0.OtVFjwsBdyyNFQHLWfYqCKpUyfa);
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
			int num = -384240211;
			goto IL_001f;
			IL_001f:
			int num2 = default(int);
			while (true)
			{
				switch (num ^ -384240212)
				{
				case 3:
					break;
				case 4:
					return null;
				case 0:
				{
					ElementIdentifierMap elementIdentifierMap = elementIdentifierMappings[num2];
					if (elementIdentifierMap != null && elementIdentifierMap.templateId == P_1)
					{
						if (elementIdentifierMap.splitAxis)
						{
							return new qFwngCMEUbVOUWUBpxMUVdPUzPt(ControllerTemplateElementType.Axis, true, new RPsfaUSCQTmtficMhKUbbYyMecr(P_0, -1, AxisRange.Full), new RPsfaUSCQTmtficMhKUbbYyMecr(P_0, elementIdentifierMap.joystickId, AxisRange.Positive), new RPsfaUSCQTmtficMhKUbbYyMecr(P_0, elementIdentifierMap.joystickId2, AxisRange.Positive));
						}
						return new qFwngCMEUbVOUWUBpxMUVdPUzPt(ControllerTemplateElementType.Axis, false, new RPsfaUSCQTmtficMhKUbbYyMecr(P_0, elementIdentifierMap.joystickId, AxisRange.Full), new RPsfaUSCQTmtficMhKUbbYyMecr(P_0, -1, AxisRange.Positive), new RPsfaUSCQTmtficMhKUbbYyMecr(P_0, -1, AxisRange.Positive));
					}
					num2++;
					num = -384240210;
					continue;
				}
				case 1:
					num2 = 0;
					num = -384240210;
					continue;
				default:
					if (num2 >= count)
					{
						return null;
					}
					goto case 0;
				}
				break;
			}
			goto IL_001a;
			IL_001a:
			num = -384240216;
			goto IL_001f;
		}

		qFwngCMEUbVOUWUBpxMUVdPUzPt IHardwareControllerTemplateMap_Internal.GetButtonTarget(Controller P_0, int P_1)
		{
			ControllerTemplateElementIdentifier elementIdentifier = GetElementIdentifier(P_1);
			if (elementIdentifier == null)
			{
				goto IL_000b;
			}
			if (elementIdentifier.elementType != ControllerTemplateElementType.Button)
			{
				return null;
			}
			if (P_0 == null)
			{
				return null;
			}
			Entry entry = aiHwPNekHXEhGGWjXNksfPnxocu(P_0.OtVFjwsBdyyNFQHLWfYqCKpUyfa);
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
			int num = 0;
			int num2 = -157001733;
			goto IL_0010;
			IL_000b:
			num2 = -157001735;
			goto IL_0010;
			IL_0010:
			ElementIdentifierMap elementIdentifierMap = default(ElementIdentifierMap);
			while (true)
			{
				switch (num2 ^ -157001733)
				{
				case 4:
					break;
				case 2:
					return null;
				case 5:
					if (elementIdentifierMap != null && elementIdentifierMap.templateId == P_1)
					{
						num2 = -157001731;
						continue;
					}
					num++;
					num2 = -157001733;
					continue;
				case 0:
				{
					int num3;
					if (num >= count)
					{
						num2 = -157001736;
						num3 = num2;
					}
					else
					{
						num2 = -157001734;
						num3 = num2;
					}
					continue;
				}
				case 1:
					elementIdentifierMap = elementIdentifierMappings[num];
					num2 = -157001730;
					continue;
				case 6:
					return new qFwngCMEUbVOUWUBpxMUVdPUzPt(ControllerTemplateElementType.Button, false, new RPsfaUSCQTmtficMhKUbbYyMecr(P_0, elementIdentifierMap.joystickId, AxisRange.Full), new RPsfaUSCQTmtficMhKUbbYyMecr(P_0, -1, AxisRange.Positive), new RPsfaUSCQTmtficMhKUbbYyMecr(P_0, -1, AxisRange.Positive));
				default:
					return null;
				}
				break;
			}
			goto IL_000b;
		}
	}
}
