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
				int num2 = -159332134;
				goto IL_000d;
				IL_000d:
				while (true)
				{
					switch (num2 ^ -159332135)
					{
					case 2:
						break;
					case 1:
						return -1;
					case 0:
						if (elementIdentifierMappings[num].templateId != templateElementId)
						{
							goto IL_005b;
						}
						return elementIdentifierMappings[num].joystickId;
					default:
						if (num >= elementIdentifierMappings.Count)
						{
							return -1;
						}
						goto case 0;
					}
					break;
					IL_005b:
					num++;
					num2 = -159332134;
				}
				goto IL_0008;
				IL_0008:
				num2 = -159332136;
				goto IL_000d;
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
						int num2 = -404711856;
						while (true)
						{
							switch (num2 ^ -404711855)
							{
							case 0:
								num2 = -404711853;
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
					return null;
				}
				int num = 0;
				while (num < elementIdentifierMappings.Count)
				{
					while (true)
					{
						if (elementIdentifierMappings[num].templateId == templateId)
						{
							return elementIdentifierMappings[num];
						}
						num++;
						int num2 = -242675741;
						while (true)
						{
							switch (num2 ^ -242675741)
							{
							case 2:
								num2 = -242675742;
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

			public void GetElementIdentifierMaps(int templateId, List<ElementIdentifierMap> results)
			{
				if (results == null)
				{
					return;
				}
				int num3 = default(int);
				while (true)
				{
					int num;
					int num2;
					if (elementIdentifierMappings != null)
					{
						num = -63050795;
						num2 = num;
					}
					else
					{
						num = -63050793;
						num2 = num;
					}
					while (true)
					{
						switch (num ^ -63050799)
						{
						case 3:
							num = -63050800;
							continue;
						case 1:
							break;
						case 6:
							return;
						case 5:
							num3++;
							num = -63050797;
							continue;
						case 0:
							if (elementIdentifierMappings[num3].templateId == templateId)
							{
								results.Add(elementIdentifierMappings[num3]);
								num = -63050796;
								continue;
							}
							goto case 5;
						case 4:
							num3 = 0;
							num = -63050797;
							continue;
						default:
							if (num3 >= elementIdentifierMappings.Count)
							{
								return;
							}
							goto case 0;
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

			private T phKPObbGGlCUOxuAiHnvLcEajQi<T>() where T : ControllerTemplateSpecialElementMapping
			{
				JsonParser.TryFromJson<T>(data, out var value);
				return value;
			}

			T IControllerTemplateMapSpecialElement_Internal.GetMapping<T>()
			{
				//ILSpy generated this explicit interface implementation from .override directive in phKPObbGGlCUOxuAiHnvLcEajQi
				return this.phKPObbGGlCUOxuAiHnvLcEajQi<T>();
			}
		}

		private sealed class HTEFVwYbcnaEtHNeQRdPAzDePxKH : IDisposable, IEnumerator, IEnumerable, IEnumerable<ControllerTemplateElementIdentifier>, IEnumerator<ControllerTemplateElementIdentifier>
		{
			private ControllerTemplateElementIdentifier ubyTdixGSFKGaFQFZdQnpwgWIvJ;

			private int isaqVUvqwfWYqOUtovbpbCbxgPc;

			private int TFdbdCIUKXTQPHFlNuiMVnWNXiVT;

			public HardwareJoystickTemplateMap syCPfFbHYMDOvEPjTnPLBqiOhsPv;

			public int PSmjXiTtTWKPkmLbUbHkvOzjvZk;

			ControllerTemplateElementIdentifier IEnumerator<ControllerTemplateElementIdentifier>.Current
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
			IEnumerator<ControllerTemplateElementIdentifier> IEnumerable<ControllerTemplateElementIdentifier>.GetEnumerator()
			{
				if (Thread.CurrentThread.ManagedThreadId == TFdbdCIUKXTQPHFlNuiMVnWNXiVT)
				{
					goto IL_0012;
				}
				goto IL_003c;
				IL_0012:
				int num = -2032474898;
				goto IL_0017;
				IL_0017:
				HTEFVwYbcnaEtHNeQRdPAzDePxKH hTEFVwYbcnaEtHNeQRdPAzDePxKH = default(HTEFVwYbcnaEtHNeQRdPAzDePxKH);
				while (true)
				{
					switch (num ^ -2032474900)
					{
					case 0:
						break;
					case 5:
						goto IL_003c;
					case 3:
						num = -2032474899;
						continue;
					case 4:
						hTEFVwYbcnaEtHNeQRdPAzDePxKH = this;
						num = -2032474897;
						continue;
					case 2:
						if (isaqVUvqwfWYqOUtovbpbCbxgPc == -2)
						{
							isaqVUvqwfWYqOUtovbpbCbxgPc = 0;
							num = -2032474904;
							continue;
						}
						goto IL_003c;
					default:
						return hTEFVwYbcnaEtHNeQRdPAzDePxKH;
					}
					break;
				}
				goto IL_0012;
				IL_003c:
				hTEFVwYbcnaEtHNeQRdPAzDePxKH = new HTEFVwYbcnaEtHNeQRdPAzDePxKH(0);
				hTEFVwYbcnaEtHNeQRdPAzDePxKH.syCPfFbHYMDOvEPjTnPLBqiOhsPv = syCPfFbHYMDOvEPjTnPLBqiOhsPv;
				num = -2032474899;
				goto IL_0017;
			}

			[DebuggerHidden]
			IEnumerator IEnumerable.GetEnumerator()
			{
				return ((IEnumerable<ControllerTemplateElementIdentifier>)this).GetEnumerator();
			}

			private bool MoveNext()
			{
				int num;
				switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
				{
				case 0:
				{
					isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
					int num2;
					if (syCPfFbHYMDOvEPjTnPLBqiOhsPv.elementIdentifiers == null)
					{
						num = 184770415;
						num2 = num;
					}
					else
					{
						num = 184770411;
						num2 = num;
					}
					goto IL_001f;
				}
				case 1:
					{
						isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
						PSmjXiTtTWKPkmLbUbHkvOzjvZk++;
						num = 184770410;
						goto IL_001f;
					}
					IL_001f:
					while (true)
					{
						switch (num ^ 0xB035F6D)
						{
						case 4:
							num = 184770414;
							continue;
						case 3:
							break;
						case 7:
							goto IL_0074;
						case 5:
							return true;
						case 6:
							PSmjXiTtTWKPkmLbUbHkvOzjvZk = 0;
							num = 184770412;
							continue;
						case 1:
							num = 184770410;
							continue;
						case 0:
							ubyTdixGSFKGaFQFZdQnpwgWIvJ = syCPfFbHYMDOvEPjTnPLBqiOhsPv.elementIdentifiers[PSmjXiTtTWKPkmLbUbHkvOzjvZk];
							isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
							num = 184770408;
							continue;
						default:
							goto end_IL_0008;
						}
						break;
						IL_0074:
						int num3;
						if (PSmjXiTtTWKPkmLbUbHkvOzjvZk >= syCPfFbHYMDOvEPjTnPLBqiOhsPv.elementIdentifiers.Length)
						{
							num = 184770415;
							num3 = num;
						}
						else
						{
							num = 184770413;
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
			public HTEFVwYbcnaEtHNeQRdPAzDePxKH(int _003C_003E1__state)
			{
				isaqVUvqwfWYqOUtovbpbCbxgPc = _003C_003E1__state;
				TFdbdCIUKXTQPHFlNuiMVnWNXiVT = Thread.CurrentThread.ManagedThreadId;
			}
		}

		private sealed class RYBDaQgSYkhSPmLqqPdIatyIlvPz : IDisposable, IEnumerator, IEnumerable, IEnumerable<IControllerElementIdentifierCommon_Internal>, IEnumerator<IControllerElementIdentifierCommon_Internal>
		{
			private IControllerElementIdentifierCommon_Internal ubyTdixGSFKGaFQFZdQnpwgWIvJ;

			private int isaqVUvqwfWYqOUtovbpbCbxgPc;

			private int TFdbdCIUKXTQPHFlNuiMVnWNXiVT;

			public HardwareJoystickTemplateMap syCPfFbHYMDOvEPjTnPLBqiOhsPv;

			public int ZuNkwfSRMbmzFVdbHjzFDuIxWOr;

			IControllerElementIdentifierCommon_Internal IEnumerator<IControllerElementIdentifierCommon_Internal>.Current
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
			IEnumerator<IControllerElementIdentifierCommon_Internal> IEnumerable<IControllerElementIdentifierCommon_Internal>.GetEnumerator()
			{
				if (Thread.CurrentThread.ManagedThreadId == TFdbdCIUKXTQPHFlNuiMVnWNXiVT && isaqVUvqwfWYqOUtovbpbCbxgPc == -2)
				{
					goto IL_001c;
				}
				goto IL_0050;
				IL_0050:
				RYBDaQgSYkhSPmLqqPdIatyIlvPz rYBDaQgSYkhSPmLqqPdIatyIlvPz = new RYBDaQgSYkhSPmLqqPdIatyIlvPz(0);
				rYBDaQgSYkhSPmLqqPdIatyIlvPz.syCPfFbHYMDOvEPjTnPLBqiOhsPv = syCPfFbHYMDOvEPjTnPLBqiOhsPv;
				int num = -256055510;
				goto IL_0021;
				IL_001c:
				num = -256055505;
				goto IL_0021;
				IL_0021:
				while (true)
				{
					switch (num ^ -256055509)
					{
					case 3:
						break;
					case 4:
						isaqVUvqwfWYqOUtovbpbCbxgPc = 0;
						num = -256055511;
						continue;
					case 0:
						goto IL_0050;
					case 2:
						rYBDaQgSYkhSPmLqqPdIatyIlvPz = this;
						num = -256055510;
						continue;
					default:
						return rYBDaQgSYkhSPmLqqPdIatyIlvPz;
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
				switch (isaqVUvqwfWYqOUtovbpbCbxgPc)
				{
				default:
					num = -1753703638;
					goto IL_001a;
				case 1:
					isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
					ZuNkwfSRMbmzFVdbHjzFDuIxWOr++;
					num = -1753703640;
					goto IL_001a;
				case 0:
					goto IL_0068;
					IL_001a:
					while (true)
					{
						switch (num ^ -1753703633)
						{
						case 3:
							break;
						case 1:
							return true;
						case 0:
							goto IL_0068;
						case 7:
							goto IL_008a;
						case 5:
							num = -1753703635;
							continue;
						case 6:
							isaqVUvqwfWYqOUtovbpbCbxgPc = 1;
							num = -1753703634;
							continue;
						case 4:
							ubyTdixGSFKGaFQFZdQnpwgWIvJ = syCPfFbHYMDOvEPjTnPLBqiOhsPv.elementIdentifiers[ZuNkwfSRMbmzFVdbHjzFDuIxWOr];
							num = -1753703639;
							continue;
						default:
							goto end_IL_0008;
						}
						break;
						IL_008a:
						int num2;
						if (ZuNkwfSRMbmzFVdbHjzFDuIxWOr < syCPfFbHYMDOvEPjTnPLBqiOhsPv.elementIdentifiers.Length)
						{
							num = -1753703637;
							num2 = num;
						}
						else
						{
							num = -1753703635;
							num2 = num;
						}
					}
					goto default;
					IL_0068:
					isaqVUvqwfWYqOUtovbpbCbxgPc = -1;
					if (syCPfFbHYMDOvEPjTnPLBqiOhsPv.elementIdentifiers == null)
					{
						break;
					}
					ZuNkwfSRMbmzFVdbHjzFDuIxWOr = 0;
					num = -1753703640;
					goto IL_001a;
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
			public RYBDaQgSYkhSPmLqqPdIatyIlvPz(int _003C_003E1__state)
			{
				isaqVUvqwfWYqOUtovbpbCbxgPc = _003C_003E1__state;
				TFdbdCIUKXTQPHFlNuiMVnWNXiVT = Thread.CurrentThread.ManagedThreadId;
			}
		}

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string controllerName;

		[SerializeField]
		[CustomObfuscation(rename = false)]
		private string description;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private string templateGuid;

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private string className;

		[CustomObfuscation(rename = false)]
		[SerializeField]
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

		[CustomObfuscation(rename = false)]
		[SerializeField]
		private int joystickIdCounter;

		public override Guid Guid => StringTools.ToGuid(templateGuid);

		public string ControllerName => controllerName;

		public string ClassName => className;

		public IEnumerable<ControllerTemplateElementIdentifier> ElementIdentifiers
		{
			get
			{
				HTEFVwYbcnaEtHNeQRdPAzDePxKH hTEFVwYbcnaEtHNeQRdPAzDePxKH = new HTEFVwYbcnaEtHNeQRdPAzDePxKH(-2);
				hTEFVwYbcnaEtHNeQRdPAzDePxKH.syCPfFbHYMDOvEPjTnPLBqiOhsPv = this;
				return hTEFVwYbcnaEtHNeQRdPAzDePxKH;
			}
		}

		IEnumerable<IControllerElementIdentifierCommon_Internal> IHardwareControllerMap_Internal.ElementIdentifiers
		{
			get
			{
				RYBDaQgSYkhSPmLqqPdIatyIlvPz rYBDaQgSYkhSPmLqqPdIatyIlvPz = new RYBDaQgSYkhSPmLqqPdIatyIlvPz(-2);
				rYBDaQgSYkhSPmLqqPdIatyIlvPz.syCPfFbHYMDOvEPjTnPLBqiOhsPv = this;
				return rYBDaQgSYkhSPmLqqPdIatyIlvPz;
			}
		}

		string IHardwareControllerTemplateMap_Internal.name => controllerName;

		Guid IHardwareControllerTemplateMap_Internal.typeGuid => Guid;

		[CustomObfuscation(rename = false)]
		public ControllerTemplateElementIdentifier GetElementIdentifier(int id)
		{
			int num = TxbXbAsmuyfokjQtDURvAErOFuNx(id);
			if (num < 0 || num >= elementIdentifiers.Length)
			{
				return null;
			}
			return elementIdentifiers[num];
		}

		[CustomObfuscation(rename = false)]
		public bool ContainsElementIdentifier(int id)
		{
			return TxbXbAsmuyfokjQtDURvAErOFuNx(id) >= 0;
		}

		[CustomObfuscation(rename = false)]
		public string[] GetElementIdentifierNames()
		{
			int num = ((elementIdentifiers != null) ? elementIdentifiers.Length : 0);
			string[] array = default(string[]);
			int num3 = default(int);
			while (true)
			{
				int num2 = -1382208086;
				while (true)
				{
					switch (num2 ^ -1382208085)
					{
					case 2:
						break;
					case 1:
						array = new string[num];
						num3 = 0;
						num2 = -1382208085;
						continue;
					case 0:
					{
						int num4;
						if (num3 >= num)
						{
							num2 = -1382208081;
							num4 = num2;
						}
						else
						{
							num2 = -1382208088;
							num4 = num2;
						}
						continue;
					}
					case 3:
						array[num3] = elementIdentifiers[num3].name;
						num3++;
						num2 = -1382208085;
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
			if (elementIdentifiers == null)
			{
				goto IL_0008;
			}
			int num = elementIdentifiers.Length;
			goto IL_0039;
			IL_0039:
			int num2 = num;
			int[] array = new int[num2];
			int num3 = 0;
			int num4 = 1081019488;
			goto IL_000d;
			IL_0008:
			num4 = 1081019490;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num4 ^ 0x406F0C60)
				{
				case 4:
					break;
				case 2:
					goto IL_002e;
				case 1:
					array[num3] = elementIdentifiers[num3].id;
					num4 = 1081019491;
					continue;
				case 3:
					num3++;
					num4 = 1081019488;
					continue;
				default:
					if (num3 >= num2)
					{
						return array;
					}
					goto case 1;
				}
				break;
			}
			goto IL_0008;
			IL_002e:
			num = 0;
			goto IL_0039;
		}

		[CustomObfuscation(rename = false)]
		internal string[] GetElementIdentifierScriptingNames(bool useAlternate)
		{
			int num = ((elementIdentifiers != null) ? elementIdentifiers.Length : 0);
			string[] array = new string[num];
			int num2 = 0;
			while (true)
			{
				int num3 = -1914170678;
				while (true)
				{
					switch (num3 ^ -1914170680)
					{
					case 3:
						break;
					case 2:
						num3 = -1914170680;
						continue;
					case 4:
						array[num2] = (useAlternate ? elementIdentifiers[num2].alternateScriptingName : elementIdentifiers[num2].scriptingName);
						num2++;
						num3 = -1914170680;
						continue;
					case 0:
					{
						int num4;
						if (num2 >= num)
						{
							num3 = -1914170679;
							num4 = num3;
						}
						else
						{
							num3 = -1914170676;
							num4 = num3;
						}
						continue;
					}
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
			ids = EmptyObjects<int>.array;
			int num = ((elementIdentifiers != null) ? elementIdentifiers.Length : 0);
			if (num == 0)
			{
				return 0;
			}
			List<ControllerTemplateElementIdentifier> list = new List<ControllerTemplateElementIdentifier>();
			int num2 = 0;
			int count = default(int);
			int num4 = default(int);
			while (true)
			{
				int num3 = 2065767649;
				while (true)
				{
					switch (num3 ^ 0x7B211CE4)
					{
					case 3:
						break;
					case 1:
						num3 = 2065767648;
						continue;
					case 2:
						if (num2 >= num)
						{
							count = list.Count;
							if (count == 0)
							{
								return 0;
							}
							names = new string[count];
							ids = new int[count];
							num4 = 0;
							num3 = 2065767653;
							continue;
						}
						goto case 8;
					case 8:
						if (elementIdentifiers[num2] != null && InputTools.IsMappableType(elementIdentifiers[num2].elementType))
						{
							list.Add(elementIdentifiers[num2]);
							num3 = 2065767650;
							continue;
						}
						goto case 6;
					case 6:
						num2++;
						num3 = 2065767654;
						continue;
					case 0:
						num4++;
						num3 = 2065767648;
						continue;
					case 7:
						names[num4] = list[num4].name;
						ids[num4] = list[num4].id;
						num3 = 2065767652;
						continue;
					case 5:
						num3 = 2065767654;
						continue;
					default:
						if (num4 >= count)
						{
							return count;
						}
						goto case 7;
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
				int num = 1734456815;
				while (true)
				{
					switch (num ^ 0x6761B5E7)
					{
					case 4:
						break;
					case 5:
						names[num2] = list[num2].name;
						ids[num2] = list[num2].id;
						num2++;
						num = 1734456804;
						continue;
					case 1:
						if (elementIdentifiers[num4] != null && !InputTools.IsMappableType(elementIdentifiers[num4].elementType))
						{
							list.Add(elementIdentifiers[num4]);
							num = 1734456805;
							continue;
						}
						goto case 2;
					case 7:
						return 0;
					case 0:
						if (num4 >= num3)
						{
							count = list.Count;
							if (count == 0)
							{
								num = 1734456801;
								continue;
							}
							names = new string[count];
							ids = new int[count];
							num2 = 0;
							num = 1734456804;
							continue;
						}
						goto case 1;
					case 6:
						return 0;
					case 8:
						num3 = ((elementIdentifiers != null) ? elementIdentifiers.Length : 0);
						if (num3 != 0)
						{
							list = new List<ControllerTemplateElementIdentifier>();
							num4 = 0;
							num = 1734456807;
						}
						else
						{
							num = 1734456800;
						}
						continue;
					case 2:
						num4++;
						num = 1734456807;
						continue;
					default:
						if (num2 >= count)
						{
							return count;
						}
						goto case 5;
					}
					break;
				}
			}
		}

		public string[] GetJoystickNames()
		{
			int num = ((joysticks != null) ? joysticks.Count : 0);
			string[] array = default(string[]);
			int num3 = default(int);
			while (true)
			{
				int num2 = 1231113894;
				while (true)
				{
					switch (num2 ^ 0x49614EA7)
					{
					case 0:
						break;
					case 1:
						array = new string[num];
						num3 = 0;
						num2 = 1231113892;
						continue;
					case 2:
						array[num3] = joysticks[num3].name;
						num3++;
						num2 = 1231113892;
						continue;
					default:
						if (num3 >= num)
						{
							return array;
						}
						goto case 2;
					}
					break;
				}
			}
		}

		public int[] GetJoystickIds()
		{
			int num = ((joysticks != null) ? joysticks.Count : 0);
			int num3 = default(int);
			int[] array = default(int[]);
			while (true)
			{
				int num2 = 1308577822;
				while (true)
				{
					switch (num2 ^ 0x4DFF501A)
					{
					case 0:
						break;
					case 6:
						num2 = 1308577817;
						continue;
					case 2:
						num3++;
						num2 = 1308577817;
						continue;
					case 4:
						array = new int[num];
						num2 = 1308577823;
						continue;
					case 5:
						num3 = 0;
						num2 = 1308577820;
						continue;
					case 1:
						array[num3] = joysticks[num3].id;
						num2 = 1308577816;
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
				int num2;
				int num3;
				if (num >= joysticks.Count)
				{
					num2 = -817481110;
					num3 = num2;
				}
				else
				{
					num2 = -817481111;
					num3 = num2;
				}
				while (true)
				{
					switch (num2 ^ -817481109)
					{
					case 0:
						num2 = -817481111;
						continue;
					case 2:
						if (joysticks[num].id == joystickId)
						{
							return StringTools.ToGuid(joysticks[num].joystickGuid);
						}
						num++;
						num2 = -817481112;
						continue;
					case 3:
						break;
					default:
						return Guid.Empty;
					}
					break;
				}
			}
		}

		public int GetJoystickId(Guid guid)
		{
			int num = 0;
			while (num < joysticks.Count)
			{
				while (true)
				{
					if (StringTools.ToGuid(joysticks[num].joystickGuid) == guid)
					{
						return joysticks[num].id;
					}
					num++;
					int num2 = 1827567609;
					while (true)
					{
						switch (num2 ^ 0x6CEE77F8)
						{
						case 0:
							num2 = 1827567610;
							continue;
						case 2:
							break;
						default:
							goto end_IL_0022;
						}
						break;
					}
					continue;
					end_IL_0022:
					break;
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
			int num = 0;
			while (num < joysticks.Count)
			{
				while (true)
				{
					int num2;
					if (joysticks[num].id == joystickId)
					{
						num2 = 803256467;
					}
					else
					{
						num++;
						num2 = 803256464;
					}
					while (true)
					{
						switch (num2 ^ 0x2FE0B890)
						{
						case 2:
							num2 = 803256465;
							continue;
						case 1:
							break;
						case 3:
							return joysticks[num].fileGuid;
						default:
							goto end_IL_0034;
						}
						break;
					}
					continue;
					end_IL_0034:
					break;
				}
			}
			return string.Empty;
		}

		internal bool eiQXXOJjgLNEdQEQbXcDIsgesQS(ControllerMap_Editor P_0, HardwareJoystickMap P_1, Guid P_2, out string P_3)
		{
			if (P_0 == null)
			{
				P_3 = "Template Map was null.";
				goto IL_000b;
			}
			P_0.hardwareGuidString = P_2.ToString();
			Entry entry = oYRbGXiqTHxwsnJemounTUxyuoYB(P_2);
			int num;
			if (entry == null)
			{
				P_3 = string.Concat("Hardware guid not found in ControllerDataFiles: ", P_2, "\nThis error should never happen. Please contact support.");
				num = 1122668387;
				goto IL_0010;
			}
			List<ActionElementMap> actionElementMaps = P_0.actionElementMaps;
			using (TempListPool.TList<ActionElementMap> tList = TempListPool.GetTList<ActionElementMap>())
			{
				List<ActionElementMap> list = tList.list;
				TempListPool.TList<ElementIdentifierMap> tList2 = TempListPool.GetTList<ElementIdentifierMap>();
				try
				{
					List<ElementIdentifierMap> list2 = tList2.list;
					int num2 = 0;
					ActionElementMap actionElementMap = default(ActionElementMap);
					ElementIdentifierMap elementIdentifierMap = default(ElementIdentifierMap);
					int num5 = default(int);
					ActionElementMap actionElementMap2 = default(ActionElementMap);
					ActionElementMap actionElementMap3 = default(ActionElementMap);
					bool flag = default(bool);
					int num6 = default(int);
					int elementIdentifierId = default(int);
					ControllerTemplateElementIdentifier_Editor controllerTemplateElementIdentifier_Editor = default(ControllerTemplateElementIdentifier_Editor);
					ControllerTemplateElementType effectiveElementType = default(ControllerTemplateElementType);
					ControllerElementIdentifier elementIdentifier = default(ControllerElementIdentifier);
					while (true)
					{
						IL_0091:
						int num3 = 1122668403;
						while (true)
						{
							switch (num3 ^ 0x42EA8F62)
							{
							case 7:
								break;
							case 18:
								actionElementMap._elementIdentifierId = elementIdentifierMap.joystickId;
								num3 = 1122668396;
								continue;
							case 19:
								num5++;
								num3 = 1122668393;
								continue;
							case 17:
								num3 = 1122668405;
								continue;
							case 21:
								if (elementIdentifierMap != null && elementIdentifierMap.joystickId >= 0)
								{
									actionElementMap = new ActionElementMap(actionElementMap2);
									actionElementMap3 = null;
									flag = false;
									num6 = TxbXbAsmuyfokjQtDURvAErOFuNx(elementIdentifierId);
									int num12;
									if (num6 < 0)
									{
										num3 = 1122668414;
										num12 = num3;
									}
									else
									{
										num3 = 1122668397;
										num12 = num3;
									}
									continue;
								}
								goto case 19;
							case 24:
								actionElementMap._axisContribution = Pole.Positive;
								actionElementMap3._axisContribution = Pole.Negative;
								num3 = 1122668388;
								continue;
							case 10:
								list2.Clear();
								num3 = 1122668394;
								continue;
							case 26:
								actionElementMap._elementIdentifierId = elementIdentifierMap.joystickId;
								num3 = 1122668395;
								continue;
							case 6:
								actionElementMap._elementType = ControllerElementType.Button;
								num3 = 1122668409;
								continue;
							case 14:
								flag = true;
								num3 = 1122668388;
								continue;
							case 25:
								elementIdentifierMap = list2[num5];
								num3 = 1122668407;
								continue;
							case 31:
								if (actionElementMap.axisType == AxisType.Split)
								{
									int num13;
									if (actionElementMap._axisRange != AxisRange.Positive)
									{
										num3 = 1122668384;
										num13 = num3;
									}
									else
									{
										num3 = 1122668400;
										num13 = num3;
									}
									continue;
								}
								goto case 6;
							case 28:
							{
								int num10;
								if (!flag)
								{
									num3 = 1122668408;
									num10 = num3;
								}
								else
								{
									num3 = 1122668395;
									num10 = num3;
								}
								continue;
							}
							case 20:
								actionElementMap._elementIdentifierId = elementIdentifierMap.joystickId2;
								num3 = 1122668396;
								continue;
							case 29:
								if (controllerTemplateElementIdentifier_Editor != null)
								{
									effectiveElementType = controllerTemplateElementIdentifier_Editor.effectiveElementType;
									if (!zRJHFfVYpYamSokTjXZVUKlCnAG.YfzaYuFFeAGpZYIlhOCKodCcBwd(effectiveElementType, elementIdentifier.elementType))
									{
										if (effectiveElementType == ControllerTemplateElementType.Axis && elementIdentifier.elementType == ControllerElementType.Button)
										{
											if (!elementIdentifierMap.splitAxis)
											{
												goto case 6;
											}
											if (actionElementMap.axisType == AxisType.Normal)
											{
												int num11;
												if (actionElementMap._axisRange != AxisRange.Full)
												{
													num3 = 1122668413;
													num11 = num3;
												}
												else
												{
													num3 = 1122668385;
													num11 = num3;
												}
												continue;
											}
											goto case 31;
										}
										goto case 1;
									}
								}
								goto case 28;
							case 4:
							{
								int num9;
								if (elementIdentifier == null)
								{
									num3 = 1122668414;
									num9 = num3;
								}
								else
								{
									num3 = 1122668415;
									num9 = num3;
								}
								continue;
							}
							case 3:
								actionElementMap3 = new ActionElementMap(actionElementMap);
								actionElementMap3._elementType = ControllerElementType.Button;
								actionElementMap3._elementIdentifierId = elementIdentifierMap.joystickId2;
								num3 = 1122668386;
								continue;
							case 30:
								controllerTemplateElementIdentifier_Editor = elementIdentifiers[num6];
								num3 = 1122668390;
								continue;
							case 9:
								list.Add(actionElementMap);
								if (actionElementMap3 != null)
								{
									list.Add(actionElementMap3);
									num3 = 1122668401;
									continue;
								}
								goto case 19;
							case 16:
								actionElementMap3._axisContribution = Pole.Positive;
								num3 = 1122668388;
								continue;
							case 12:
								actionElementMap._elementType = ControllerElementType.Axis;
								num3 = 1122668414;
								continue;
							case 27:
								num3 = 1122668414;
								continue;
							case 5:
								throw new NotImplementedException();
							case 11:
								if (num5 >= list2.Count)
								{
									num2++;
									num3 = 1122668405;
									continue;
								}
								goto case 25;
							case 8:
								actionElementMap2 = actionElementMaps[num2];
								elementIdentifierId = actionElementMap2._elementIdentifierId;
								entry.GetElementIdentifierMaps(elementIdentifierId, list2);
								num5 = 0;
								num3 = 1122668393;
								continue;
							case 0:
								if (actionElementMap._invert)
								{
									actionElementMap._axisContribution = Pole.Negative;
									num3 = 1122668402;
									continue;
								}
								goto case 24;
							case 13:
								actionElementMap._axisRange = AxisRange.Positive;
								num3 = 1122668398;
								continue;
							case 1:
							{
								int num8;
								if (effectiveElementType == ControllerTemplateElementType.Button)
								{
									num3 = 1122668404;
									num8 = num3;
								}
								else
								{
									num3 = 1122668391;
									num8 = num3;
								}
								continue;
							}
							case 22:
							{
								int num7;
								if (elementIdentifier.elementType == ControllerElementType.Axis)
								{
									num3 = 1122668399;
									num7 = num3;
								}
								else
								{
									num3 = 1122668391;
									num7 = num3;
								}
								continue;
							}
							case 15:
								if (num6 < elementIdentifiers.Length)
								{
									elementIdentifier = P_1.GetElementIdentifier(elementIdentifierMap.joystickId);
									num3 = 1122668412;
									continue;
								}
								goto case 28;
							case 2:
							{
								int num4;
								if (actionElementMap._axisRange == AxisRange.Negative)
								{
									num3 = 1122668406;
									num4 = num3;
								}
								else
								{
									num3 = 1122668396;
									num4 = num3;
								}
								continue;
							}
							default:
								if (num2 >= actionElementMaps.Count)
								{
									goto end_IL_0096;
								}
								goto case 10;
							}
							goto IL_0091;
							continue;
							end_IL_0096:
							break;
						}
						break;
					}
				}
				finally
				{
					if (tList2 != null)
					{
						while (true)
						{
							IL_048a:
							int num14 = 1122668387;
							while (true)
							{
								switch (num14 ^ 0x42EA8F62)
								{
								case 0:
									break;
								default:
									goto end_IL_048f;
								case 1:
									goto IL_04a8;
								case 2:
									goto end_IL_048f;
								}
								goto IL_048a;
								IL_04a8:
								((IDisposable)tList2).Dispose();
								num14 = 1122668384;
								continue;
								end_IL_048f:
								break;
							}
							break;
						}
					}
				}
				actionElementMaps.Clear();
				ListTools.CopyTo(list, actionElementMaps);
			}
			P_3 = null;
			return true;
			IL_0010:
			switch (num ^ 0x42EA8F62)
			{
			case 0:
				break;
			case 2:
				return false;
			default:
				return false;
			}
			goto IL_000b;
			IL_000b:
			num = 1122668384;
			goto IL_0010;
		}

		internal ControllerTemplateElementIdentifier kBoaUJDYOnIujWXVVCmGUvtnFDH(Guid P_0, int P_1)
		{
			int num = default(int);
			int num2 = default(int);
			int num3;
			if (!(P_0 == Guid.Empty))
			{
				if (P_1 < 0)
				{
					goto IL_0011;
				}
				if (joysticks == null)
				{
					return null;
				}
				num = -1;
				num2 = 0;
				num3 = -59668238;
				goto IL_0016;
			}
			goto IL_0042;
			IL_0011:
			num3 = -59668233;
			goto IL_0016;
			IL_0016:
			Entry entry;
			while (true)
			{
				switch (num3 ^ -59668239)
				{
				case 0:
					break;
				case 6:
					goto IL_0042;
				case 5:
					if (joysticks[num2] != null && joysticks[num2].JoystickGuid == P_0)
					{
						num = num2;
						num3 = -59668237;
						continue;
					}
					goto case 1;
				case 2:
					goto IL_0089;
				case 3:
					goto IL_00a9;
				case 1:
					num2++;
					num3 = -59668238;
					continue;
				default:
					return null;
				}
				break;
				IL_00a9:
				int num4;
				if (num2 >= joysticks.Count)
				{
					num3 = -59668237;
					num4 = num3;
				}
				else
				{
					num3 = -59668236;
					num4 = num3;
				}
				continue;
				IL_0089:
				if (num < 0)
				{
					return null;
				}
				entry = joysticks[num];
				if (entry == null)
				{
					num3 = -59668235;
					continue;
				}
				goto IL_00db;
			}
			goto IL_0011;
			IL_00db:
			int templateElementId = entry.GetTemplateElementId(P_1);
			if (templateElementId < 0)
			{
				return null;
			}
			return GetElementIdentifier(templateElementId);
			IL_0042:
			return null;
		}

		[CustomObfuscation(rename = false)]
		internal SpecialElementEntry[] GetSpecialElementsOrig()
		{
			return specialElements;
		}

		private Entry oYRbGXiqTHxwsnJemounTUxyuoYB(Guid P_0)
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
					int num2;
					if (joysticks[num].JoystickGuid == P_0)
					{
						num2 = 1461294231;
					}
					else
					{
						num++;
						num2 = 1461294229;
					}
					while (true)
					{
						switch (num2 ^ 0x57199494)
						{
						case 0:
							num2 = 1461294230;
							continue;
						case 2:
							break;
						case 3:
							return joysticks[num];
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
			return null;
		}

		private int TxbXbAsmuyfokjQtDURvAErOFuNx(int P_0)
		{
			if (elementIdentifiers == null)
			{
				goto IL_0008;
			}
			int num = 0;
			int num2 = -1049309947;
			goto IL_000d;
			IL_000d:
			while (true)
			{
				switch (num2 ^ -1049309947)
				{
				case 2:
					break;
				case 1:
					return -1;
				case 3:
					if (elementIdentifiers[num].id != P_0)
					{
						goto IL_0047;
					}
					return num;
				default:
					if (num >= elementIdentifiers.Length)
					{
						return -1;
					}
					goto case 3;
				}
				break;
				IL_0047:
				num++;
				num2 = -1049309947;
			}
			goto IL_0008;
			IL_0008:
			num2 = -1049309948;
			goto IL_000d;
		}

		private IControllerElementIdentifierCommon_Internal hDlEUleYtSxKvdYuNlNRqaBZjVOK(int P_0)
		{
			return GetElementIdentifier(P_0);
		}

		IControllerElementIdentifierCommon_Internal IHardwareControllerMap_Internal.GetElementIdentifier(int P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in hDlEUleYtSxKvdYuNlNRqaBZjVOK
			return this.hDlEUleYtSxKvdYuNlNRqaBZjVOK(P_0);
		}

		private int BvpJKoPaObVdfxtHxisYsiIOLOp()
		{
			if (elementIdentifiers == null)
			{
				return 0;
			}
			return elementIdentifiers.Length;
		}

		int IHardwareControllerTemplateMap_Internal.GetElementIdentifierCount()
		{
			//ILSpy generated this explicit interface implementation from .override directive in BvpJKoPaObVdfxtHxisYsiIOLOp
			return this.BvpJKoPaObVdfxtHxisYsiIOLOp();
		}

		private IControllerTemplateElementIdentifier AUVnAbpUityMogevgYPGBcfxfXf(int P_0)
		{
			if (elementIdentifiers == null)
			{
				return null;
			}
			return elementIdentifiers[P_0];
		}

		IControllerTemplateElementIdentifier IHardwareControllerTemplateMap_Internal.GetTemplateElementIdentifier(int P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in AUVnAbpUityMogevgYPGBcfxfXf
			return this.AUVnAbpUityMogevgYPGBcfxfXf(P_0);
		}

		private IControllerTemplateElementIdentifier zcnbnUjCAGCiYzzimpgUhiWvAxc(int P_0)
		{
			return GetElementIdentifier(P_0);
		}

		IControllerTemplateElementIdentifier IHardwareControllerTemplateMap_Internal.GetTemplateElementIdentifierById(int P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in zcnbnUjCAGCiYzzimpgUhiWvAxc
			return this.zcnbnUjCAGCiYzzimpgUhiWvAxc(P_0);
		}

		private IControllerTemplateMapSpecialElement_Internal EpAgnMkvRPDDwpOmpGqNaRalKRAo(int P_0)
		{
			if (specialElements == null)
			{
				return null;
			}
			int num = 0;
			while (num < specialElements.Length)
			{
				while (true)
				{
					int num2;
					if (specialElements[num] != null)
					{
						num2 = 1029570837;
						goto IL_0013;
					}
					goto IL_005a;
					IL_0041:
					if (specialElements[num].elementIdentifierId == P_0)
					{
						return specialElements[num];
					}
					goto IL_005a;
					IL_005a:
					num++;
					num2 = 1029570838;
					goto IL_0013;
					IL_0013:
					while (true)
					{
						switch (num2 ^ 0x3D5E0116)
						{
						case 2:
							num2 = 1029570839;
							continue;
						case 1:
							break;
						case 3:
							goto IL_0041;
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
			return null;
		}

		IControllerTemplateMapSpecialElement_Internal IHardwareControllerTemplateMap_Internal.GetSpecialTemplateElementByElementIdentifierId(int P_0)
		{
			//ILSpy generated this explicit interface implementation from .override directive in EpAgnMkvRPDDwpOmpGqNaRalKRAo
			return this.EpAgnMkvRPDDwpOmpGqNaRalKRAo(P_0);
		}

		private aZegFSKVtbYbsDQcYCKVgyHJAnPy gatwCQLEfYREcaFUsKfjzMeYsox(Controller P_0, int P_1)
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
				return null;
			}
			Entry entry = oYRbGXiqTHxwsnJemounTUxyuoYB(P_0.WhXaNimcOuXdrXZrlSbhrrJNttC);
			if (entry == null)
			{
				return null;
			}
			List<ElementIdentifierMap> elementIdentifierMappings = entry.elementIdentifierMappings;
			int count = default(int);
			ElementIdentifierMap elementIdentifierMap = default(ElementIdentifierMap);
			int num2 = default(int);
			while (true)
			{
				int num = -1384887039;
				while (true)
				{
					switch (num ^ -1384887035)
					{
					case 5:
						break;
					case 4:
						if (elementIdentifierMappings == null)
						{
							return null;
						}
						count = elementIdentifierMappings.Count;
						num = -1384887033;
						continue;
					case 1:
						elementIdentifierMap = elementIdentifierMappings[num2];
						if (elementIdentifierMap != null && elementIdentifierMap.templateId == P_1)
						{
							if (!elementIdentifierMap.splitAxis)
							{
								return new aZegFSKVtbYbsDQcYCKVgyHJAnPy(ControllerTemplateElementType.Axis, splitAxis: false, new TtePFCKBdNmQRluqYJdgMTWVuTZ(P_0, elementIdentifierMap.joystickId, AxisRange.Full), new TtePFCKBdNmQRluqYJdgMTWVuTZ(P_0, -1, AxisRange.Positive), new TtePFCKBdNmQRluqYJdgMTWVuTZ(P_0, -1, AxisRange.Positive));
							}
							num = -1384887034;
						}
						else
						{
							num2++;
							num = -1384887035;
						}
						continue;
					case 3:
						return new aZegFSKVtbYbsDQcYCKVgyHJAnPy(ControllerTemplateElementType.Axis, splitAxis: true, new TtePFCKBdNmQRluqYJdgMTWVuTZ(P_0, -1, AxisRange.Full), new TtePFCKBdNmQRluqYJdgMTWVuTZ(P_0, elementIdentifierMap.joystickId, AxisRange.Positive), new TtePFCKBdNmQRluqYJdgMTWVuTZ(P_0, elementIdentifierMap.joystickId2, AxisRange.Positive));
					case 2:
						num2 = 0;
						num = -1384887035;
						continue;
					default:
						if (num2 >= count)
						{
							return null;
						}
						goto case 1;
					}
					break;
				}
			}
		}

		aZegFSKVtbYbsDQcYCKVgyHJAnPy IHardwareControllerTemplateMap_Internal.GetAxisTarget(Controller P_0, int P_1)
		{
			//ILSpy generated this explicit interface implementation from .override directive in gatwCQLEfYREcaFUsKfjzMeYsox
			return this.gatwCQLEfYREcaFUsKfjzMeYsox(P_0, P_1);
		}

		private aZegFSKVtbYbsDQcYCKVgyHJAnPy JgnHqqcrksiCAsDqmsIkkFZeFAqD(Controller P_0, int P_1)
		{
			ControllerTemplateElementIdentifier elementIdentifier = GetElementIdentifier(P_1);
			if (elementIdentifier == null)
			{
				return null;
			}
			if (elementIdentifier.elementType != ControllerTemplateElementType.Button)
			{
				return null;
			}
			if (P_0 == null)
			{
				return null;
			}
			Entry entry = oYRbGXiqTHxwsnJemounTUxyuoYB(P_0.WhXaNimcOuXdrXZrlSbhrrJNttC);
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
			int num2 = default(int);
			ElementIdentifierMap elementIdentifierMap = default(ElementIdentifierMap);
			while (true)
			{
				int num = -493500491;
				while (true)
				{
					switch (num ^ -493500490)
					{
					case 0:
						break;
					case 3:
						num2 = 0;
						num = -493500489;
						continue;
					case 2:
						if (elementIdentifierMap.templateId == P_1)
						{
							return new aZegFSKVtbYbsDQcYCKVgyHJAnPy(ControllerTemplateElementType.Button, splitAxis: false, new TtePFCKBdNmQRluqYJdgMTWVuTZ(P_0, elementIdentifierMap.joystickId, AxisRange.Full), new TtePFCKBdNmQRluqYJdgMTWVuTZ(P_0, -1, AxisRange.Positive), new TtePFCKBdNmQRluqYJdgMTWVuTZ(P_0, -1, AxisRange.Positive));
						}
						goto IL_00a6;
					case 4:
						elementIdentifierMap = elementIdentifierMappings[num2];
						if (elementIdentifierMap != null)
						{
							num = -493500492;
							continue;
						}
						goto IL_00a6;
					case 1:
						num = -493500493;
						continue;
					default:
						{
							if (num2 >= count)
							{
								return null;
							}
							goto case 4;
						}
						IL_00a6:
						num2++;
						num = -493500493;
						continue;
					}
					break;
				}
			}
		}

		aZegFSKVtbYbsDQcYCKVgyHJAnPy IHardwareControllerTemplateMap_Internal.GetButtonTarget(Controller P_0, int P_1)
		{
			//ILSpy generated this explicit interface implementation from .override directive in JgnHqqcrksiCAsDqmsIkkFZeFAqD
			return this.JgnHqqcrksiCAsDqmsIkkFZeFAqD(P_0, P_1);
		}
	}
}
