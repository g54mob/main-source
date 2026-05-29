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
					return -1;
				}
				int num = 0;
				while (true)
				{
					int num2;
					int num3;
					if (num < elementIdentifierMappings.Count)
					{
						num2 = -959884817;
						num3 = num2;
					}
					else
					{
						num2 = -959884819;
						num3 = num2;
					}
					while (true)
					{
						switch (num2 ^ -959884818)
						{
						case 0:
							num2 = -959884817;
							continue;
						case 1:
							if (elementIdentifierMappings[num].templateId == templateElementId)
							{
								return elementIdentifierMappings[num].joystickId;
							}
							num++;
							num2 = -959884820;
							continue;
						case 2:
							break;
						default:
							return -1;
						}
						break;
					}
				}
			}

			public int GetTemplateElementId(int joystickElementId)
			{
				if (elementIdentifierMappings == null)
				{
					return -1;
				}
				int num = 0;
				while (num < elementIdentifierMappings.Count)
				{
					while (true)
					{
						if (elementIdentifierMappings[num].joystickId == joystickElementId)
						{
							return elementIdentifierMappings[num].templateId;
						}
						num++;
						int num2 = 2131258293;
						while (true)
						{
							switch (num2 ^ 0x7F086BB4)
							{
							case 0:
								num2 = 2131258294;
								continue;
							case 2:
								break;
							default:
								goto end_IL_002c;
							}
							break;
						}
						continue;
						end_IL_002c:
						break;
					}
				}
				return -1;
			}

			public ElementIdentifierMap GetElementIdentifierMap(int templateId)
			{
				if (elementIdentifierMappings == null)
				{
					goto IL_0008;
				}
				int num = 0;
				int num2 = -771850705;
				goto IL_000d;
				IL_000d:
				while (true)
				{
					switch (num2 ^ -771850709)
					{
					case 5:
						break;
					case 1:
						return elementIdentifierMappings[num];
					case 4:
						num2 = -771850712;
						continue;
					case 0:
						if (elementIdentifierMappings[num].templateId != templateId)
						{
							num++;
							num2 = -771850712;
						}
						else
						{
							num2 = -771850710;
						}
						continue;
					case 2:
						return null;
					default:
						if (num >= elementIdentifierMappings.Count)
						{
							return null;
						}
						goto case 0;
					}
					break;
				}
				goto IL_0008;
				IL_0008:
				num2 = -771850711;
				goto IL_000d;
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
						int num = 0;
						int num2 = 564059714;
						while (true)
						{
							switch (num2 ^ 0x219EDE43)
							{
							case 4:
								num2 = 564059717;
								continue;
							case 1:
								num2 = 564059713;
								continue;
							case 5:
								break;
							case 3:
								num++;
								num2 = 564059713;
								continue;
							case 0:
								if (elementIdentifierMappings[num].templateId == templateId)
								{
									results.Add(elementIdentifierMappings[num]);
									num2 = 564059712;
									continue;
								}
								goto case 3;
							case 6:
								goto end_IL_0039;
							default:
								if (num >= elementIdentifierMappings.Count)
								{
									return;
								}
								goto case 0;
							}
							break;
						}
						continue;
						end_IL_0039:
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

		private sealed class suAmCdcVRrBVycPKHCCWfhKWqzp : IDisposable, IEnumerator, IEnumerable, IEnumerable<ControllerTemplateElementIdentifier>, IEnumerator<ControllerTemplateElementIdentifier>
		{
			private ControllerTemplateElementIdentifier RDkWcsTpvDaNZojjIZONnoEBXPC;

			private int LzqgRXjFXvJPbHjfzyAmNfcqezXL;

			private int iDzUuTsbdXLkIyEGCPmJzsmGhcs;

			public HardwareJoystickTemplateMap ZzSaCQHlhEgTijsOQGwUlyKTOzqG;

			public int cxajIdvHgWRVzXfSJnEbjHXsCoJi;

			ControllerTemplateElementIdentifier IEnumerator<ControllerTemplateElementIdentifier>.Current
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
			IEnumerator<ControllerTemplateElementIdentifier> IEnumerable<ControllerTemplateElementIdentifier>.GetEnumerator()
			{
				if (Thread.CurrentThread.ManagedThreadId == iDzUuTsbdXLkIyEGCPmJzsmGhcs)
				{
					goto IL_0012;
				}
				goto IL_004e;
				IL_0012:
				int num = -930309693;
				goto IL_0017;
				IL_0017:
				suAmCdcVRrBVycPKHCCWfhKWqzp suAmCdcVRrBVycPKHCCWfhKWqzp2 = default(suAmCdcVRrBVycPKHCCWfhKWqzp);
				while (true)
				{
					switch (num ^ -930309694)
					{
					case 3:
						break;
					case 1:
						if (LzqgRXjFXvJPbHjfzyAmNfcqezXL == -2)
						{
							LzqgRXjFXvJPbHjfzyAmNfcqezXL = 0;
							suAmCdcVRrBVycPKHCCWfhKWqzp2 = this;
							num = -930309696;
							continue;
						}
						goto IL_004e;
					case 0:
						goto IL_004e;
					default:
						return suAmCdcVRrBVycPKHCCWfhKWqzp2;
					}
					break;
				}
				goto IL_0012;
				IL_004e:
				suAmCdcVRrBVycPKHCCWfhKWqzp2 = new suAmCdcVRrBVycPKHCCWfhKWqzp(0);
				suAmCdcVRrBVycPKHCCWfhKWqzp2.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = ZzSaCQHlhEgTijsOQGwUlyKTOzqG;
				num = -930309696;
				goto IL_0017;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ControllerTemplateElementIdentifier>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				int lzqgRXjFXvJPbHjfzyAmNfcqezXL = LzqgRXjFXvJPbHjfzyAmNfcqezXL;
				while (true)
				{
					int num = 1921399077;
					while (true)
					{
						switch (num ^ 0x72863924)
						{
						case 7:
							break;
						case 8:
							RDkWcsTpvDaNZojjIZONnoEBXPC = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elementIdentifiers[cxajIdvHgWRVzXfSJnEbjHXsCoJi];
							num = 1921399078;
							continue;
						case 6:
							LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
							num = 1921399073;
							continue;
						case 2:
							LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
							return true;
						case 3:
							cxajIdvHgWRVzXfSJnEbjHXsCoJi = 0;
							num = 1921399076;
							continue;
						case 1:
							switch (lzqgRXjFXvJPbHjfzyAmNfcqezXL)
							{
							case 0:
								break;
							case 1:
								LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
								cxajIdvHgWRVzXfSJnEbjHXsCoJi++;
								num = 1921399076;
								continue;
							default:
								num = 1921399072;
								continue;
							}
							goto case 6;
						case 0:
						{
							int num3;
							if (cxajIdvHgWRVzXfSJnEbjHXsCoJi >= ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elementIdentifiers.Length)
							{
								num = 1921399072;
								num3 = num;
							}
							else
							{
								num = 1921399084;
								num3 = num;
							}
							continue;
						}
						case 5:
						{
							int num2;
							if (ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elementIdentifiers != null)
							{
								num = 1921399079;
								num2 = num;
							}
							else
							{
								num = 1921399072;
								num2 = num;
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
			public suAmCdcVRrBVycPKHCCWfhKWqzp(int _003C_003E1__state)
			{
				LzqgRXjFXvJPbHjfzyAmNfcqezXL = _003C_003E1__state;
				iDzUuTsbdXLkIyEGCPmJzsmGhcs = Thread.CurrentThread.ManagedThreadId;
			}
		}

		private sealed class cWXJgDoDdsFpGwBPbQxBzNSskOq : IDisposable, IEnumerator, IEnumerable, IEnumerable<IControllerElementIdentifierCommon_Internal>, IEnumerator<IControllerElementIdentifierCommon_Internal>
		{
			private IControllerElementIdentifierCommon_Internal RDkWcsTpvDaNZojjIZONnoEBXPC;

			private int LzqgRXjFXvJPbHjfzyAmNfcqezXL;

			private int iDzUuTsbdXLkIyEGCPmJzsmGhcs;

			public HardwareJoystickTemplateMap ZzSaCQHlhEgTijsOQGwUlyKTOzqG;

			public int svZTdoqdxtiuAiaKSfUWXjcgcXUC;

			IControllerElementIdentifierCommon_Internal IEnumerator<IControllerElementIdentifierCommon_Internal>.Current
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
			IEnumerator<IControllerElementIdentifierCommon_Internal> IEnumerable<IControllerElementIdentifierCommon_Internal>.GetEnumerator()
			{
				if (Thread.CurrentThread.ManagedThreadId == iDzUuTsbdXLkIyEGCPmJzsmGhcs && LzqgRXjFXvJPbHjfzyAmNfcqezXL == -2)
				{
					goto IL_001c;
				}
				goto IL_004e;
				IL_004e:
				cWXJgDoDdsFpGwBPbQxBzNSskOq cWXJgDoDdsFpGwBPbQxBzNSskOq2 = new cWXJgDoDdsFpGwBPbQxBzNSskOq(0);
				cWXJgDoDdsFpGwBPbQxBzNSskOq2.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = ZzSaCQHlhEgTijsOQGwUlyKTOzqG;
				int num = 1415854676;
				goto IL_0021;
				IL_001c:
				num = 1415854677;
				goto IL_0021;
				IL_0021:
				while (true)
				{
					switch (num ^ 0x54643A54)
					{
					case 2:
						break;
					case 1:
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = 0;
						cWXJgDoDdsFpGwBPbQxBzNSskOq2 = this;
						num = 1415854676;
						continue;
					case 3:
						goto IL_004e;
					default:
						return cWXJgDoDdsFpGwBPbQxBzNSskOq2;
					}
					break;
				}
				goto IL_001c;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<IControllerElementIdentifierCommon_Internal>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				int num;
				switch (LzqgRXjFXvJPbHjfzyAmNfcqezXL)
				{
				case 1:
					LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
					svZTdoqdxtiuAiaKSfUWXjcgcXUC++;
					num = 1615738197;
					goto IL_001f;
				case 0:
					{
						LzqgRXjFXvJPbHjfzyAmNfcqezXL = -1;
						num = 1615738199;
						goto IL_001f;
					}
					IL_001f:
					while (true)
					{
						switch (num ^ 0x604E3555)
						{
						case 4:
							num = 1615738196;
							continue;
						case 5:
							num = 1615738197;
							continue;
						case 3:
							RDkWcsTpvDaNZojjIZONnoEBXPC = ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elementIdentifiers[svZTdoqdxtiuAiaKSfUWXjcgcXUC];
							LzqgRXjFXvJPbHjfzyAmNfcqezXL = 1;
							return true;
						case 1:
							break;
						case 2:
							if (ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elementIdentifiers != null)
							{
								svZTdoqdxtiuAiaKSfUWXjcgcXUC = 0;
								num = 1615738192;
								continue;
							}
							goto end_IL_0008;
						case 0:
							goto IL_00bb;
						default:
							goto end_IL_0008;
						}
						break;
						IL_00bb:
						int num2;
						if (svZTdoqdxtiuAiaKSfUWXjcgcXUC < ZzSaCQHlhEgTijsOQGwUlyKTOzqG.elementIdentifiers.Length)
						{
							num = 1615738198;
							num2 = num;
						}
						else
						{
							num = 1615738195;
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
			public cWXJgDoDdsFpGwBPbQxBzNSskOq(int _003C_003E1__state)
			{
				LzqgRXjFXvJPbHjfzyAmNfcqezXL = _003C_003E1__state;
				iDzUuTsbdXLkIyEGCPmJzsmGhcs = Thread.CurrentThread.ManagedThreadId;
			}
		}

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string controllerName;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private string description;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private string templateGuid;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string className;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private ControllerTemplateElementIdentifier_Editor[] elementIdentifiers;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private List<Entry> joysticks;

		[CustomObfuscation(rename = false)]
		[SerializeField]
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
				suAmCdcVRrBVycPKHCCWfhKWqzp suAmCdcVRrBVycPKHCCWfhKWqzp2 = new suAmCdcVRrBVycPKHCCWfhKWqzp(-2);
				suAmCdcVRrBVycPKHCCWfhKWqzp2.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = this;
				return suAmCdcVRrBVycPKHCCWfhKWqzp2;
			}
		}

		IEnumerable<IControllerElementIdentifierCommon_Internal> IHardwareControllerMap_Internal.ElementIdentifiers
		{
			get
			{
				cWXJgDoDdsFpGwBPbQxBzNSskOq cWXJgDoDdsFpGwBPbQxBzNSskOq2 = new cWXJgDoDdsFpGwBPbQxBzNSskOq(-2);
				cWXJgDoDdsFpGwBPbQxBzNSskOq2.ZzSaCQHlhEgTijsOQGwUlyKTOzqG = this;
				return cWXJgDoDdsFpGwBPbQxBzNSskOq2;
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
			int num = wUhEdDGDqqzAnpFOAybuGqLZlzq(id);
			if (num < 0 || num >= elementIdentifiers.Length)
			{
				return null;
			}
			return elementIdentifiers[num];
		}

		[CustomObfuscation(rename = false)]
		public bool ContainsElementIdentifier(int id)
		{
			return wUhEdDGDqqzAnpFOAybuGqLZlzq(id) >= 0;
		}

		[CustomObfuscation(rename = false)]
		public string[] GetElementIdentifierNames()
		{
			int num = ((elementIdentifiers != null) ? elementIdentifiers.Length : 0);
			string[] array = new string[num];
			int num2 = 0;
			while (true)
			{
				int num3;
				int num4;
				if (num2 < num)
				{
					num3 = 564742946;
					num4 = num3;
				}
				else
				{
					num3 = 564742944;
					num4 = num3;
				}
				while (true)
				{
					switch (num3 ^ 0x21A94B23)
					{
					case 0:
						num3 = 564742946;
						continue;
					case 1:
						array[num2] = elementIdentifiers[num2].name;
						num2++;
						num3 = 564742945;
						continue;
					case 2:
						break;
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
			int num3 = default(int);
			int[] array = default(int[]);
			while (true)
			{
				int num2 = -372662727;
				while (true)
				{
					switch (num2 ^ -372662723)
					{
					case 0:
						break;
					case 3:
						num3++;
						num2 = -372662721;
						continue;
					case 1:
						array[num3] = elementIdentifiers[num3].id;
						num2 = -372662722;
						continue;
					case 5:
						num3 = 0;
						num2 = -372662721;
						continue;
					case 4:
						array = new int[num];
						num2 = -372662728;
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

		[CustomObfuscation(rename = false)]
		internal string[] GetElementIdentifierScriptingNames(bool useAlternate)
		{
			int num = ((elementIdentifiers != null) ? elementIdentifiers.Length : 0);
			string[] array = new string[num];
			int num2 = 0;
			while (true)
			{
				int num3;
				int num4;
				if (num2 >= num)
				{
					num3 = -68916166;
					num4 = num3;
				}
				else
				{
					num3 = -68916167;
					num4 = num3;
				}
				while (true)
				{
					switch (num3 ^ -68916168)
					{
					case 0:
						num3 = -68916167;
						continue;
					case 1:
						array[num2] = (useAlternate ? elementIdentifiers[num2].alternateScriptingName : elementIdentifiers[num2].scriptingName);
						num2++;
						num3 = -68916165;
						continue;
					case 3:
						break;
					default:
						return array;
					}
					break;
				}
			}
		}

		public int GetMappableElementIdentifierInfo(out string[] names, out int[] ids)
		{
			names = EmptyObjects<string>.array;
			int num3 = default(int);
			int num4 = default(int);
			int count = default(int);
			List<ControllerTemplateElementIdentifier> list = default(List<ControllerTemplateElementIdentifier>);
			int num2 = default(int);
			while (true)
			{
				int num = 922125437;
				while (true)
				{
					switch (num ^ 0x36F6847C)
					{
					case 10:
						break;
					case 0:
						if (num3 >= num4)
						{
							count = list.Count;
							num = 922125435;
							continue;
						}
						goto case 6;
					case 8:
						num3++;
						num = 922125436;
						continue;
					case 4:
						list.Add(elementIdentifiers[num3]);
						num = 922125428;
						continue;
					case 1:
						ids = EmptyObjects<int>.array;
						num4 = ((elementIdentifiers != null) ? elementIdentifiers.Length : 0);
						if (num4 == 0)
						{
							num = 922125439;
							continue;
						}
						list = new List<ControllerTemplateElementIdentifier>();
						num3 = 0;
						num = 922125436;
						continue;
					case 3:
						return 0;
					case 2:
						names[num2] = list[num2].name;
						ids[num2] = list[num2].id;
						num2++;
						num = 922125433;
						continue;
					case 6:
						if (elementIdentifiers[num3] != null)
						{
							int num5;
							if (InputTools.IsMappableType(elementIdentifiers[num3].elementType))
							{
								num = 922125432;
								num5 = num;
							}
							else
							{
								num = 922125428;
								num5 = num;
							}
							continue;
						}
						goto case 8;
					case 9:
						ids = new int[count];
						num2 = 0;
						num = 922125433;
						continue;
					case 7:
						if (count == 0)
						{
							return 0;
						}
						names = new string[count];
						num = 922125429;
						continue;
					default:
						if (num2 >= count)
						{
							return count;
						}
						goto case 2;
					}
					break;
				}
			}
		}

		public int GetNonMappableElementIdentifierInfo(out string[] names, out int[] ids)
		{
			names = EmptyObjects<string>.array;
			ids = EmptyObjects<int>.array;
			int num2 = default(int);
			List<ControllerTemplateElementIdentifier> list = default(List<ControllerTemplateElementIdentifier>);
			int num4 = default(int);
			int num3 = default(int);
			int count = default(int);
			while (true)
			{
				int num = 129400905;
				while (true)
				{
					switch (num ^ 0x7B68048)
					{
					case 7:
						break;
					case 2:
						names[num2] = list[num2].name;
						ids[num2] = list[num2].id;
						num2++;
						num = 129400896;
						continue;
					case 4:
						if (num4 >= num3)
						{
							count = list.Count;
							num = 129400898;
							continue;
						}
						goto case 0;
					case 0:
						if (elementIdentifiers[num4] != null)
						{
							int num5;
							if (!InputTools.IsMappableType(elementIdentifiers[num4].elementType))
							{
								num = 129400907;
								num5 = num;
							}
							else
							{
								num = 129400909;
								num5 = num;
							}
							continue;
						}
						goto case 5;
					case 10:
						if (count == 0)
						{
							num = 129400910;
							continue;
						}
						names = new string[count];
						ids = new int[count];
						num2 = 0;
						num = 129400896;
						continue;
					case 6:
						return 0;
					case 5:
						num4++;
						num = 129400908;
						continue;
					case 9:
						if (num3 == 0)
						{
							return 0;
						}
						list = new List<ControllerTemplateElementIdentifier>();
						num4 = 0;
						num = 129400908;
						continue;
					case 3:
						list.Add(elementIdentifiers[num4]);
						num = 129400909;
						continue;
					case 1:
						num3 = ((elementIdentifiers != null) ? elementIdentifiers.Length : 0);
						num = 129400897;
						continue;
					default:
						if (num2 >= count)
						{
							return count;
						}
						goto case 2;
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
			while (num2 < num)
			{
				while (true)
				{
					array[num2] = joysticks[num2].name;
					num2++;
					int num3 = -1165455585;
					while (true)
					{
						switch (num3 ^ -1165455586)
						{
						case 0:
							num3 = -1165455588;
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

		public int[] GetJoystickIds()
		{
			int num = ((joysticks != null) ? joysticks.Count : 0);
			int[] array = default(int[]);
			int num3 = default(int);
			while (true)
			{
				int num2 = -1006831720;
				while (true)
				{
					switch (num2 ^ -1006831718)
					{
					case 0:
						break;
					case 2:
						array = new int[num];
						num2 = -1006831714;
						continue;
					case 5:
						num2 = -1006831719;
						continue;
					case 1:
						array[num3] = joysticks[num3].id;
						num3++;
						num2 = -1006831719;
						continue;
					case 4:
						num3 = 0;
						num2 = -1006831713;
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

		public Guid GetJoystickGuid(int joystickId)
		{
			if (joysticks == null)
			{
				return Guid.Empty;
			}
			int num = 0;
			while (true)
			{
				int num2 = -1420892729;
				while (true)
				{
					switch (num2 ^ -1420892730)
					{
					case 2:
						break;
					case 1:
						num2 = -1420892731;
						continue;
					case 4:
						return StringTools.ToGuid(joysticks[num].joystickGuid);
					case 0:
						if (joysticks[num].id != joystickId)
						{
							num++;
							num2 = -1420892731;
						}
						else
						{
							num2 = -1420892734;
						}
						continue;
					default:
						if (num >= joysticks.Count)
						{
							return Guid.Empty;
						}
						goto case 0;
					}
					break;
				}
			}
		}

		public int GetJoystickId(Guid guid)
		{
			int num = 0;
			while (true)
			{
				int num2 = 558241802;
				while (true)
				{
					switch (num2 ^ 0x2146180B)
					{
					case 2:
						break;
					case 1:
						num2 = 558241800;
						continue;
					case 0:
						if (StringTools.ToGuid(joysticks[num].joystickGuid) == guid)
						{
							return joysticks[num].id;
						}
						num++;
						num2 = 558241800;
						continue;
					default:
						if (num >= joysticks.Count)
						{
							return -1;
						}
						goto case 0;
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
			while (num < joysticks.Count)
			{
				while (true)
				{
					if (joysticks[num].id == joystickId)
					{
						return joysticks[num].fileGuid;
					}
					num++;
					int num2 = -1021289482;
					while (true)
					{
						switch (num2 ^ -1021289481)
						{
						case 0:
							num2 = -1021289483;
							continue;
						case 2:
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
			return string.Empty;
		}

		internal bool TkGdiJCpMZREcRztmiuEgWCvstzA(ControllerMap_Editor P_0, HardwareJoystickMap P_1, Guid P_2, out string P_3)
		{
			if (P_0 == null)
			{
				P_3 = "Template Map was null.";
				return false;
			}
			P_0.hardwareGuidString = P_2.ToString();
			Entry entry = ZRRbWEUyvPhLbmNfhDRiKXnvdbb(P_2);
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
					ActionElementMap actionElementMap = default(ActionElementMap);
					ActionElementMap actionElementMap3 = default(ActionElementMap);
					ControllerTemplateElementType effectiveElementType = default(ControllerTemplateElementType);
					ControllerElementIdentifier elementIdentifier = default(ControllerElementIdentifier);
					ControllerTemplateElementIdentifier_Editor controllerTemplateElementIdentifier_Editor = default(ControllerTemplateElementIdentifier_Editor);
					int num10 = default(int);
					ElementIdentifierMap elementIdentifierMap = default(ElementIdentifierMap);
					int num7 = default(int);
					int num2 = default(int);
					int elementIdentifierId = default(int);
					ActionElementMap actionElementMap2 = default(ActionElementMap);
					bool flag = default(bool);
					while (true)
					{
						IL_0069:
						int num = 456448798;
						while (true)
						{
							switch (num ^ 0x1B34DB0B)
							{
							case 13:
								break;
							default:
								goto end_IL_006e;
							case 19:
								actionElementMap = new ActionElementMap(actionElementMap3);
								num = 456448782;
								continue;
							case 33:
								if (!KVNLqybISELdZVRJeMgGCnyHIcv.texDHprRVSCDIhdEcHxFsscbHjUA(effectiveElementType, elementIdentifier.elementType))
								{
									int num12;
									if (effectiveElementType != ControllerTemplateElementType.Axis)
									{
										num = 456448783;
										num12 = num;
									}
									else
									{
										num = 456448771;
										num12 = num;
									}
									continue;
								}
								goto case 30;
							case 17:
								controllerTemplateElementIdentifier_Editor = elementIdentifiers[num10];
								num = 456448788;
								continue;
							case 8:
								if (elementIdentifier.elementType == ControllerElementType.Button)
								{
									if (elementIdentifierMap.splitAxis)
									{
										int num9;
										if (actionElementMap.axisType != AxisType.Normal)
										{
											num = 456448768;
											num9 = num;
										}
										else
										{
											num = 456448777;
											num9 = num;
										}
										continue;
									}
									goto case 27;
								}
								goto case 4;
							case 27:
								actionElementMap._elementType = ControllerElementType.Button;
								num = 456448789;
								continue;
							case 0:
								actionElementMap._axisContribution = Pole.Negative;
								num = 456448772;
								continue;
							case 28:
								elementIdentifierMap = list2[num7];
								num = 456448796;
								continue;
							case 6:
								actionElementMap._elementType = ControllerElementType.Axis;
								num = 456448789;
								continue;
							case 25:
								actionElementMap3 = actionElementMaps[num2];
								elementIdentifierId = actionElementMap3._elementIdentifierId;
								entry.GetElementIdentifierMaps(elementIdentifierId, list2);
								num7 = 0;
								num = 456448769;
								continue;
							case 11:
								if (actionElementMap.axisType == AxisType.Split)
								{
									int num4;
									if (actionElementMap._axisRange != AxisRange.Positive)
									{
										num = 456448799;
										num4 = num;
									}
									else
									{
										num = 456448793;
										num4 = num;
									}
									continue;
								}
								goto case 27;
							case 5:
								actionElementMap2 = null;
								flag = false;
								num10 = wUhEdDGDqqzAnpFOAybuGqLZlzq(elementIdentifierId);
								if (num10 >= 0 && num10 < elementIdentifiers.Length)
								{
									elementIdentifier = P_1.GetElementIdentifier(elementIdentifierMap.joystickId);
									num = 456448794;
									continue;
								}
								goto case 30;
							case 3:
								actionElementMap._axisContribution = Pole.Positive;
								actionElementMap2._axisContribution = Pole.Negative;
								num = 456448784;
								continue;
							case 16:
								throw new NotImplementedException();
							case 23:
								if (elementIdentifierMap != null)
								{
									int num11;
									if (elementIdentifierMap.joystickId < 0)
									{
										num = 456448790;
										num11 = num;
									}
									else
									{
										num = 456448792;
										num11 = num;
									}
									continue;
								}
								goto case 29;
							case 18:
								actionElementMap._elementIdentifierId = elementIdentifierMap.joystickId;
								num = 456448770;
								continue;
							case 31:
							{
								int num8;
								if (elementIdentifier == null)
								{
									num = 456448789;
									num8 = num;
								}
								else
								{
									num = 456448778;
									num8 = num;
								}
								continue;
							}
							case 26:
								list2.Clear();
								num = 456448786;
								continue;
							case 22:
								num = 456448784;
								continue;
							case 30:
								if (!flag)
								{
									actionElementMap._elementIdentifierId = elementIdentifierMap.joystickId;
									num = 456448780;
									continue;
								}
								goto case 7;
							case 20:
								if (actionElementMap._axisRange == AxisRange.Negative)
								{
									actionElementMap._elementIdentifierId = elementIdentifierMap.joystickId2;
									num = 456448770;
									continue;
								}
								goto case 9;
							case 9:
								flag = true;
								num = 456448784;
								continue;
							case 15:
								actionElementMap2._axisContribution = Pole.Positive;
								num = 456448797;
								continue;
							case 32:
								num = 456448773;
								continue;
							case 29:
								num7++;
								num = 456448769;
								continue;
							case 12:
								effectiveElementType = controllerTemplateElementIdentifier_Editor.effectiveElementType;
								num = 456448810;
								continue;
							case 7:
								list.Add(actionElementMap);
								if (actionElementMap2 != null)
								{
									list.Add(actionElementMap2);
									num = 456448790;
									continue;
								}
								goto case 29;
							case 10:
								if (num7 >= list2.Count)
								{
									num2++;
									num = 456448773;
									continue;
								}
								goto case 28;
							case 1:
							{
								int num6;
								if (controllerTemplateElementIdentifier_Editor == null)
								{
									num = 456448789;
									num6 = num;
								}
								else
								{
									num = 456448775;
									num6 = num;
								}
								continue;
							}
							case 2:
								if (actionElementMap._axisRange == AxisRange.Full)
								{
									actionElementMap2 = new ActionElementMap(actionElementMap);
									actionElementMap2._elementType = ControllerElementType.Button;
									actionElementMap2._elementIdentifierId = elementIdentifierMap.joystickId2;
									int num5;
									if (!actionElementMap._invert)
									{
										num = 456448776;
										num5 = num;
									}
									else
									{
										num = 456448779;
										num5 = num;
									}
									continue;
								}
								goto case 11;
							case 14:
							{
								int num3;
								if (num2 >= actionElementMaps.Count)
								{
									num = 456448787;
									num3 = num;
								}
								else
								{
									num = 456448785;
									num3 = num;
								}
								continue;
							}
							case 4:
								if (effectiveElementType == ControllerTemplateElementType.Button && elementIdentifier.elementType == ControllerElementType.Axis)
								{
									actionElementMap._axisRange = AxisRange.Positive;
									num = 456448781;
									continue;
								}
								goto case 16;
							case 21:
								num2 = 0;
								num = 456448811;
								continue;
							case 24:
								goto end_IL_006e;
							}
							goto IL_0069;
							continue;
							end_IL_006e:
							break;
						}
						break;
					}
				}
				actionElementMaps.Clear();
				while (true)
				{
					IL_0492:
					int num13 = 456448778;
					while (true)
					{
						switch (num13 ^ 0x1B34DB0B)
						{
						case 0:
							break;
						default:
							goto end_IL_0497;
						case 1:
							goto IL_04b0;
						case 2:
							goto end_IL_0497;
						}
						goto IL_0492;
						IL_04b0:
						ListTools.CopyTo(list, actionElementMaps);
						num13 = 456448777;
						continue;
						end_IL_0497:
						break;
					}
					break;
				}
			}
			P_3 = null;
			return true;
		}

		internal ControllerTemplateElementIdentifier RZwfCQeddpzqevuWGXSHMZWwIdo(Guid P_0, int P_1)
		{
			int num;
			int num2 = default(int);
			int num3 = default(int);
			if (!(P_0 == Guid.Empty))
			{
				if (P_1 < 0)
				{
					goto IL_0011;
				}
				if (joysticks == null)
				{
					num = -76327470;
				}
				else
				{
					num2 = -1;
					num3 = 0;
					num = -76327469;
				}
				goto IL_0016;
			}
			goto IL_0046;
			IL_0011:
			num = -76327465;
			goto IL_0016;
			IL_0016:
			while (true)
			{
				switch (num ^ -76327466)
				{
				case 7:
					break;
				case 1:
					goto IL_0046;
				case 5:
					num = -76327468;
					continue;
				case 4:
					return null;
				case 3:
					num3++;
					num = -76327468;
					continue;
				case 0:
					if (joysticks[num3] != null && joysticks[num3].JoystickGuid == P_0)
					{
						num2 = num3;
						num = -76327472;
						continue;
					}
					goto case 3;
				case 2:
					goto IL_00a9;
				default:
					goto IL_00cb;
				}
				break;
				IL_00a9:
				int num4;
				if (num3 >= joysticks.Count)
				{
					num = -76327472;
					num4 = num;
				}
				else
				{
					num = -76327466;
					num4 = num;
				}
			}
			goto IL_0011;
			IL_00cb:
			if (num2 < 0)
			{
				return null;
			}
			Entry entry = joysticks[num2];
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
			IL_0046:
			return null;
		}

		[CustomObfuscation(rename = false)]
		internal SpecialElementEntry[] GetSpecialElementsOrig()
		{
			return specialElements;
		}

		private Entry ZRRbWEUyvPhLbmNfhDRiKXnvdbb(Guid P_0)
		{
			if (joysticks == null)
			{
				return null;
			}
			int num = 0;
			while (num < joysticks.Count)
			{
				while (true)
				{
					if (joysticks[num].JoystickGuid == P_0)
					{
						return joysticks[num];
					}
					num++;
					int num2 = -1740086609;
					while (true)
					{
						switch (num2 ^ -1740086609)
						{
						case 2:
							num2 = -1740086610;
							continue;
						case 1:
							break;
						default:
							goto end_IL_002c;
						}
						break;
					}
					continue;
					end_IL_002c:
					break;
				}
			}
			return null;
		}

		private int wUhEdDGDqqzAnpFOAybuGqLZlzq(int P_0)
		{
			if (elementIdentifiers == null)
			{
				goto IL_0008;
			}
			int num = 0;
			int num2 = -1292320837;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num2 ^ -1292320840)
				{
				case 2:
					break;
				case 0:
					if (elementIdentifiers[num].id == P_0)
					{
						return num;
					}
					num++;
					num2 = -1292320836;
					continue;
				case 3:
					num2 = -1292320836;
					continue;
				case 1:
					return -1;
				default:
					if (num >= elementIdentifiers.Length)
					{
						return -1;
					}
					goto case 0;
				}
				break;
			}
			goto IL_0008;
			IL_0008:
			num2 = -1292320839;
			goto IL_000d;
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
			int num2 = -2008775765;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num2 ^ -2008775767)
				{
				case 0:
					break;
				case 1:
					return specialElements[num];
				case 4:
					if (specialElements[num] == null || specialElements[num].elementIdentifierId != P_0)
					{
						num++;
						num2 = -2008775765;
					}
					else
					{
						num2 = -2008775768;
					}
					continue;
				case 3:
					return null;
				default:
					if (num >= specialElements.Length)
					{
						return null;
					}
					goto case 4;
				}
				break;
			}
			goto IL_0008;
			IL_0008:
			num2 = -2008775766;
			goto IL_000d;
		}

		ZsogrZyhQfaSnqVtBlGOmbxOuQc IHardwareControllerTemplateMap_Internal.GetAxisTarget(Controller P_0, int P_1)
		{
			ControllerTemplateElementIdentifier elementIdentifier = GetElementIdentifier(P_1);
			if (elementIdentifier == null)
			{
				return null;
			}
			if (elementIdentifier.elementType != ControllerTemplateElementType.Axis)
			{
				goto IL_0015;
			}
			if (P_0 == null)
			{
				return null;
			}
			Entry entry = ZRRbWEUyvPhLbmNfhDRiKXnvdbb(P_0.hLHPojWAxuyakcKOieCsahbSjqfw);
			if (entry == null)
			{
				return null;
			}
			List<ElementIdentifierMap> elementIdentifierMappings = entry.elementIdentifierMappings;
			int num = 676082532;
			goto IL_001a;
			IL_0015:
			num = 676082528;
			goto IL_001a;
			IL_001a:
			ElementIdentifierMap elementIdentifierMap = default(ElementIdentifierMap);
			int num2 = default(int);
			int count = default(int);
			while (true)
			{
				switch (num ^ 0x284C3361)
				{
				case 3:
					break;
				case 1:
					return null;
				case 4:
					elementIdentifierMap = elementIdentifierMappings[num2];
					if (elementIdentifierMap != null)
					{
						num = 676082531;
						continue;
					}
					goto IL_0103;
				case 5:
					if (elementIdentifierMappings == null)
					{
						return null;
					}
					count = elementIdentifierMappings.Count;
					num2 = 0;
					num = 676082535;
					continue;
				case 2:
					if (elementIdentifierMap.templateId == P_1)
					{
						if (elementIdentifierMap.splitAxis)
						{
							return new ZsogrZyhQfaSnqVtBlGOmbxOuQc(ControllerTemplateElementType.Axis, true, new auqagPyfULkTIGtBZGYbYCoEQli(P_0, -1, AxisRange.Full), new auqagPyfULkTIGtBZGYbYCoEQli(P_0, elementIdentifierMap.joystickId, AxisRange.Positive), new auqagPyfULkTIGtBZGYbYCoEQli(P_0, elementIdentifierMap.joystickId2, AxisRange.Positive));
						}
						return new ZsogrZyhQfaSnqVtBlGOmbxOuQc(ControllerTemplateElementType.Axis, false, new auqagPyfULkTIGtBZGYbYCoEQli(P_0, elementIdentifierMap.joystickId, AxisRange.Full), new auqagPyfULkTIGtBZGYbYCoEQli(P_0, -1, AxisRange.Positive), new auqagPyfULkTIGtBZGYbYCoEQli(P_0, -1, AxisRange.Positive));
					}
					goto IL_0103;
				case 6:
				{
					int num3;
					if (num2 >= count)
					{
						num = 676082529;
						num3 = num;
					}
					else
					{
						num = 676082533;
						num3 = num;
					}
					continue;
				}
				default:
					{
						return null;
					}
					IL_0103:
					num2++;
					num = 676082535;
					continue;
				}
				break;
			}
			goto IL_0015;
		}

		ZsogrZyhQfaSnqVtBlGOmbxOuQc IHardwareControllerTemplateMap_Internal.GetButtonTarget(Controller P_0, int P_1)
		{
			ControllerTemplateElementIdentifier elementIdentifier = GetElementIdentifier(P_1);
			if (elementIdentifier == null)
			{
				return null;
			}
			if (elementIdentifier.elementType != ControllerTemplateElementType.Button)
			{
				goto IL_0016;
			}
			if (P_0 == null)
			{
				return null;
			}
			Entry entry = ZRRbWEUyvPhLbmNfhDRiKXnvdbb(P_0.hLHPojWAxuyakcKOieCsahbSjqfw);
			if (entry == null)
			{
				return null;
			}
			List<ElementIdentifierMap> elementIdentifierMappings = entry.elementIdentifierMappings;
			int count = default(int);
			int num;
			if (elementIdentifierMappings != null)
			{
				count = elementIdentifierMappings.Count;
				num = 665200948;
			}
			else
			{
				num = 665200946;
			}
			goto IL_001b;
			IL_0016:
			num = 665200947;
			goto IL_001b;
			IL_001b:
			ElementIdentifierMap elementIdentifierMap = default(ElementIdentifierMap);
			int num2 = default(int);
			while (true)
			{
				switch (num ^ 0x27A62935)
				{
				case 0:
					break;
				case 3:
					elementIdentifierMap = elementIdentifierMappings[num2];
					num = 665200945;
					continue;
				case 7:
					return null;
				case 6:
					return null;
				case 5:
					return new ZsogrZyhQfaSnqVtBlGOmbxOuQc(ControllerTemplateElementType.Button, false, new auqagPyfULkTIGtBZGYbYCoEQli(P_0, elementIdentifierMap.joystickId, AxisRange.Full), new auqagPyfULkTIGtBZGYbYCoEQli(P_0, -1, AxisRange.Positive), new auqagPyfULkTIGtBZGYbYCoEQli(P_0, -1, AxisRange.Positive));
				case 1:
					num2 = 0;
					num = 665200951;
					continue;
				case 4:
					if (elementIdentifierMap == null || elementIdentifierMap.templateId != P_1)
					{
						num2++;
						num = 665200951;
					}
					else
					{
						num = 665200944;
					}
					continue;
				default:
					if (num2 >= count)
					{
						return null;
					}
					goto case 3;
				}
				break;
			}
			goto IL_0016;
		}
	}
}
