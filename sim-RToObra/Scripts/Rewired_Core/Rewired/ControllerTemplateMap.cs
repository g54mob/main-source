using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Rewired.Utils;
using Rewired.Utils.Classes.Data;

namespace Rewired
{
	public class ControllerTemplateMap
	{
		private readonly int _reInputId;

		private readonly int _id;

		private readonly Guid _templateTypeGuid;

		private readonly List<ControllerTemplateActionElementMap> _elementMaps;

		private readonly ReadOnlyCollection<ControllerTemplateActionElementMap> _elementMaps_readOnly;

		private bool _enabled;

		private int _categoryId;

		private int _layoutId;

		private int _sourceMapId = -1;

		private static int __idCounter;

		public int id
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return -1;
				}
				return _id;
			}
		}

		public Guid templateTypeGuid
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return Guid.Empty;
				}
				return _templateTypeGuid;
			}
		}

		public bool enabled
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return false;
				}
				return _enabled;
			}
			set
			{
				_enabled = value;
			}
		}

		public int categoryId
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return -1;
				}
				return _categoryId;
			}
			internal set
			{
				_categoryId = value;
			}
		}

		public int layoutId
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return -1;
				}
				return _layoutId;
			}
			internal set
			{
				_layoutId = value;
			}
		}

		public IList<ControllerTemplateActionElementMap> ElementMaps
		{
			get
			{
				if (ReInput._id != _reInputId)
				{
					ReInput.CheckInitialized(_reInputId);
					return EmptyObjects<ControllerTemplateActionElementMap>.EmptyReadOnlyIListT;
				}
				return _elementMaps_readOnly;
			}
		}

		internal ControllerTemplateMap(Guid templateTypeGuid)
		{
			_id = __idCounter++;
			_reInputId = ReInput._id;
			_templateTypeGuid = templateTypeGuid;
			_elementMaps = new List<ControllerTemplateActionElementMap>();
			_elementMaps_readOnly = new ReadOnlyCollection<ControllerTemplateActionElementMap>(_elementMaps);
			_enabled = true;
		}

		internal ControllerTemplateMap(Guid templateTypeGuid, int categoryId, int layoutId, int sourceMapId)
			: this(templateTypeGuid)
		{
			while (true)
			{
				int num = -947603872;
				while (true)
				{
					switch (num ^ -947603869)
					{
					case 0:
						break;
					case 3:
						_categoryId = categoryId;
						num = -947603870;
						continue;
					case 1:
						_layoutId = layoutId;
						num = -947603871;
						continue;
					default:
						_sourceMapId = sourceMapId;
						return;
					}
					break;
				}
			}
		}

		public string ToXmlString()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return string.Empty;
			}
			try
			{
				return Export().ToXmlString(true);
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error writing " + GetType().Name + " to XML. " + ex.Message);
				return string.Empty;
			}
		}

		public string ToJsonString()
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return string.Empty;
			}
			try
			{
				return Export().ToJsonString();
			}
			catch (Exception ex)
			{
				Logger.LogWarning("Error writing " + GetType().Name + " to JSON. " + ex.Message);
				return string.Empty;
			}
		}

		public ControllerMap ToControllerMap(Controller controller)
		{
			if (ReInput._id != _reInputId)
			{
				ReInput.CheckInitialized(_reInputId);
				return null;
			}
			if (controller == null)
			{
				goto IL_001e;
			}
			goto IL_0052;
			IL_00b1:
			ControllerMap controllerMap = default(ControllerMap);
			controllerMap.controllerId = controller.id;
			controllerMap.controllerType = controller.type;
			controllerMap.enabled = _enabled;
			controllerMap.hardwareGuid = controller.OtVFjwsBdyyNFQHLWfYqCKpUyfa;
			IControllerTemplate template = default(IControllerTemplate);
			using (TempListPool.TList<ActionElementMap> tList = TempListPool.GetTList<ActionElementMap>())
			{
				List<ActionElementMap> list = tList.list;
				int num2 = default(int);
				int num3 = default(int);
				while (true)
				{
					int num = -3700294;
					while (true)
					{
						switch (num ^ -3700290)
						{
						case 5:
							break;
						case 2:
							num2++;
							num = -3700296;
							continue;
						case 0:
						{
							int num4;
							if (num3 >= list.Count)
							{
								num = -3700292;
								num4 = num;
							}
							else
							{
								num = -3700295;
								num4 = num;
							}
							continue;
						}
						case 3:
							_elementMaps[num2].qNnlMnyVUtsqBKOWnglpkzgZyyqn(template, list, false);
							num3 = 0;
							num = -3700289;
							continue;
						case 4:
							num2 = 0;
							num = -3700296;
							continue;
						case 1:
							num = -3700290;
							continue;
						case 7:
							controllerMap.AddActionMapping_BeforeBake(list[num3]);
							num3++;
							num = -3700290;
							continue;
						default:
							if (num2 >= _elementMaps.Count)
							{
								return controllerMap;
							}
							goto case 3;
						}
						break;
					}
				}
			}
			IL_001e:
			int num5 = -3700289;
			goto IL_0023;
			IL_0023:
			switch (num5 ^ -3700290)
			{
			case 2:
				break;
			case 1:
				throw new ArgumentNullException("controller");
			case 0:
				goto IL_0052;
			default:
				goto IL_00b1;
			}
			goto IL_001e;
			IL_0052:
			template = controller.GetTemplate(_templateTypeGuid);
			if (template == null)
			{
				Logger.LogError("The Controller does not implement the expected Controller Template.");
				return null;
			}
			controllerMap = ControllerMap.MdLShCgeucAqBomYFlMaHVWokJC(controller.type);
			controllerMap.categoryId = _categoryId;
			controllerMap.layoutId = _layoutId;
			if (_sourceMapId >= 0)
			{
				controllerMap.sourceMapId = _sourceMapId;
				num5 = -3700291;
				goto IL_0023;
			}
			goto IL_00b1;
		}

		internal virtual void ExportDataToSerializedObject(SerializedObject serializedObject)
		{
			if (serializedObject.xmlInfo == null)
			{
				serializedObject.xmlInfo = new SerializedObject.XmlInfo();
				goto IL_0016;
			}
			goto IL_0246;
			IL_0246:
			serializedObject.Add("dataVersion", 1, SerializedObject.FieldOptions.ExculdeFromXml);
			int num = -158118436;
			goto IL_001b;
			IL_0016:
			num = -158118437;
			goto IL_001b;
			IL_001b:
			int count = default(int);
			List<object> list = default(List<object>);
			int num2 = default(int);
			while (true)
			{
				switch (num ^ -158118438)
				{
				case 7:
					break;
				default:
					return;
				case 5:
					count = _elementMaps.Count;
					list = new List<object>();
					serializedObject.Add("elementMaps", list);
					num2 = 0;
					num = -158118434;
					continue;
				case 4:
					goto IL_007b;
				case 2:
					serializedObject.Add("categoryId", _categoryId);
					serializedObject.Add("layoutId", _layoutId);
					serializedObject.Add("sourceMapId", _sourceMapId);
					num = -158118433;
					continue;
				case 9:
					if (_elementMaps[num2] != null)
					{
						list.Add(_elementMaps[num2].wGWQXZtIQyRkZMrIKWqTSlWZlQY());
						num = -158118438;
						continue;
					}
					goto case 0;
				case 8:
					serializedObject.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.XmlStringAttribute
					{
						localName = "templateTypeGuid",
						value = _templateTypeGuid.ToString()
					});
					serializedObject.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.XmlStringAttribute
					{
						prefix = "xmlns",
						localName = "xsi",
						ns = null,
						value = "http://www.w3.org/2001/XMLSchema-instance"
					});
					serializedObject.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.XmlStringAttribute
					{
						prefix = "xsi",
						localName = "schemaLocation",
						ns = null,
						value = string.Format("{0} {1}{2}{3}{4}{5}", "http://guavaman.com/rewired", "http://guavaman.com/schemas/rewired/", "1.0", "/", GetType().Name, ".xsd")
					});
					serializedObject.Add("templateTypeGuid", _templateTypeGuid);
					serializedObject.Add("enabled", _enabled);
					num = -158118440;
					continue;
				case 1:
					goto IL_0246;
				case 0:
					num2++;
					num = -158118434;
					continue;
				case 6:
					serializedObject.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.XmlStringAttribute
					{
						localName = "dataVersion",
						value = 1.ToString()
					});
					num = -158118446;
					continue;
				case 3:
					return;
				}
				break;
				IL_007b:
				int num3;
				if (num2 < count)
				{
					num = -158118445;
					num3 = num;
				}
				else
				{
					num = -158118439;
					num3 = num;
				}
			}
			goto IL_0016;
		}

		internal virtual void Import(SerializedObject serializedObject)
		{
			Clear();
			serializedObject.TryGetDeserializedValueByRef("enabled", ref _enabled);
			SerializedObject value = default(SerializedObject);
			int num2 = default(int);
			SerializedObject value2 = default(SerializedObject);
			while (true)
			{
				int num = 1469181605;
				while (true)
				{
					switch (num ^ 0x5791EEA6)
					{
					case 0:
						break;
					default:
						return;
					case 3:
						serializedObject.TryGetDeserializedValueByRef("categoryId", ref _categoryId);
						num = 1469181600;
						continue;
					case 2:
						value = null;
						if (serializedObject.TryGetDeserializedValueByRef("elementMaps", ref value) && value != null)
						{
							num2 = 0;
							num = 1469181614;
							continue;
						}
						return;
					case 5:
						num2++;
						num = 1469181607;
						continue;
					case 6:
						serializedObject.TryGetDeserializedValueByRef("layoutId", ref _layoutId);
						serializedObject.TryGetDeserializedValueByRef("sourceMapId", ref _sourceMapId);
						num = 1469181604;
						continue;
					case 1:
					{
						int num4;
						if (num2 < value.count)
						{
							num = 1469181602;
							num4 = num;
						}
						else
						{
							num = 1469181601;
							num4 = num;
						}
						continue;
					}
					case 8:
						num = 1469181607;
						continue;
					case 4:
						if (!value.TryGetDeserializedValue<SerializedObject>(num2, out value2))
						{
							int num3;
							if (value2 == null)
							{
								num = 1469181615;
								num3 = num;
							}
							else
							{
								num = 1469181603;
								num3 = num;
							}
							continue;
						}
						goto case 9;
					case 9:
					{
						ControllerTemplateActionElementMap controllerTemplateActionElementMap = ControllerTemplateActionElementMap.MdLShCgeucAqBomYFlMaHVWokJC(value2);
						if (controllerTemplateActionElementMap != null)
						{
							AddElementMap(controllerTemplateActionElementMap);
							num = 1469181603;
							continue;
						}
						goto case 5;
					}
					case 7:
						return;
					}
					break;
				}
			}
		}

		private void Clear()
		{
			_enabled = true;
			_categoryId = -1;
			_layoutId = -1;
			_sourceMapId = -1;
			_elementMaps.Clear();
		}

		private SerializedObject Export()
		{
			SerializedObject serializedObject = new SerializedObject(GetType(), SerializedObject.ObjectType.Object);
			ExportDataToSerializedObject(serializedObject);
			return serializedObject;
		}

		internal void AddElementMap(ControllerTemplateActionElementMap elementMap)
		{
			if (elementMap != null)
			{
				_elementMaps.Add(elementMap);
			}
		}

		internal static ControllerTemplateMap FromControllerMap(IControllerTemplate controllerTemplate, ControllerMap controllerMap)
		{
			if (controllerMap == null)
			{
				throw new ArgumentNullException("controllerMap");
			}
			Controller controller = default(Controller);
			ControllerTemplateMap controllerTemplateMap = default(ControllerTemplateMap);
			while (controllerTemplate != null)
			{
				while (true)
				{
					int num;
					int num2;
					if (!ReInput.isReady)
					{
						num = -501373505;
						num2 = num;
					}
					else
					{
						num = -501373508;
						num2 = num;
					}
					while (true)
					{
						switch (num ^ -501373509)
						{
						case 2:
							num = -501373510;
							continue;
						case 4:
							throw new Exception("Rewired is not initialized.");
						case 6:
							break;
						case 7:
							controller = ReInput.controllers.GetController(controllerMap.controllerType, controllerMap.controllerId);
							num = -501373517;
							continue;
						case 5:
							Logger.LogError("The Controller Map is not associated with a Controller. This method can only be used with a Controller Map that is associated with a Controller.", true);
							return null;
						case 1:
							goto end_IL_005c;
						case 0:
							controllerTemplateMap._enabled = controllerMap.enabled;
							controllerTemplateMap._categoryId = controllerMap.categoryId;
							num = -501373512;
							continue;
						case 8:
							goto IL_010a;
						default:
						{
							controllerTemplateMap._layoutId = controllerMap.layoutId;
							controllerTemplateMap._sourceMapId = controllerMap.sourceMapId;
							using (TempListPool.TList<ControllerTemplateElementTarget> tList = TempListPool.GetTList<ControllerTemplateElementTarget>())
							{
								List<ControllerTemplateElementTarget> list = tList.list;
								using (IEnumerator<ActionElementMap> enumerator = controllerMap.AllMaps.GetEnumerator())
								{
									while (enumerator.MoveNext())
									{
										while (true)
										{
											ActionElementMap current = enumerator.Current;
											if (controllerTemplate.GetElementTargets(current, list) <= 0)
											{
												break;
											}
											int num3 = 0;
											int num4 = -501373510;
											while (true)
											{
												switch (num4 ^ -501373509)
												{
												case 0:
													num4 = -501373511;
													continue;
												case 1:
													break;
												case 4:
													controllerTemplateMap.AddElementMap(ControllerTemplateActionElementMap.MdLShCgeucAqBomYFlMaHVWokJC(list[num3], current));
													num3++;
													num4 = -501373510;
													continue;
												case 2:
													goto end_IL_0153;
												default:
													goto end_IL_01b1;
												}
												int num5;
												if (num3 >= list.Count)
												{
													num4 = -501373512;
													num5 = num4;
												}
												else
												{
													num4 = -501373505;
													num5 = num4;
												}
												continue;
												end_IL_0153:
												break;
											}
											continue;
											end_IL_01b1:
											break;
										}
									}
									return controllerTemplateMap;
								}
							}
						}
						}
						break;
						IL_010a:
						if (controller != null)
						{
							if (!controller.ImplementsTemplate(controllerTemplate.typeGuid))
							{
								Logger.LogError("The Controller does not implement the Controller Template.", true);
								return null;
							}
							controllerTemplateMap = new ControllerTemplateMap(controllerTemplate.typeGuid);
							num = -501373509;
						}
						else
						{
							num = -501373506;
						}
					}
					continue;
					end_IL_005c:
					break;
				}
			}
			throw new ArgumentNullException("controllerTemplate");
		}

		public static ControllerTemplateMap FromXml(string xmlString)
		{
			try
			{
				return FromSerializedData(SerializedObject.FromXml(typeof(ControllerTemplateMap), xmlString));
			}
			catch (Exception ex)
			{
				Logger.LogError("Error creating ControllerTemplateMap from XML! " + ex.Message);
				return null;
			}
		}

		public static ControllerTemplateMap FromJson(string jsonString)
		{
			try
			{
				return FromSerializedData(SerializedObject.FromJson(typeof(ControllerTemplateMap), jsonString));
			}
			catch (Exception ex)
			{
				while (true)
				{
					int num = 363809462;
					while (true)
					{
						switch (num ^ 0x15AF4AB4)
						{
						case 0:
							break;
						case 2:
							goto IL_0037;
						default:
							return null;
						}
						break;
						IL_0037:
						Logger.LogError("Error creating ControllerTemplateMap from JSON! " + ex.Message);
						num = 363809461;
					}
				}
			}
		}

		private static ControllerTemplateMap FromSerializedData(SerializedObject serializedObject)
		{
			Guid value;
			if (!serializedObject.TryGetDeserializedValue<Guid>("templateTypeGuid", out value))
			{
				goto IL_000f;
			}
			goto IL_003e;
			IL_000f:
			int num = 1567129695;
			goto IL_0014;
			IL_0014:
			ControllerTemplateMap controllerTemplateMap = default(ControllerTemplateMap);
			switch (num ^ 0x5D68805E)
			{
			case 2:
				break;
			case 1:
				throw new Exception();
			case 0:
				goto IL_003e;
			default:
				return controllerTemplateMap;
			}
			goto IL_000f;
			IL_003e:
			controllerTemplateMap = new ControllerTemplateMap(value);
			controllerTemplateMap.Import(serializedObject);
			num = 1567129693;
			goto IL_0014;
		}
	}
}
