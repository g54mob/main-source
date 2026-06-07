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
			_categoryId = categoryId;
			_layoutId = layoutId;
			_sourceMapId = sourceMapId;
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
				while (true)
				{
					int num = -1180689048;
					while (true)
					{
						switch (num ^ -1180689047)
						{
						case 0:
							break;
						case 1:
							goto IL_004c;
						default:
							return string.Empty;
						}
						break;
						IL_004c:
						Logger.LogWarning("Error writing " + GetType().Name + " to JSON. " + ex.Message);
						num = -1180689045;
					}
				}
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
				throw new ArgumentNullException("controller");
			}
			int num4 = default(int);
			while (true)
			{
				IControllerTemplate template = controller.GetTemplate(_templateTypeGuid);
				if (template == null)
				{
					break;
				}
				ControllerMap controllerMap = ControllerMap.rHXUBQoqejbkONabpWgwEqatBJ(controller.type);
				controllerMap.categoryId = _categoryId;
				int num = 2129898003;
				while (true)
				{
					switch (num ^ 0x7EF3AA13)
					{
					case 5:
						num = 2129898002;
						continue;
					case 1:
						break;
					case 2:
						controllerMap.controllerId = controller.id;
						controllerMap.controllerType = controller.type;
						num = 2129898007;
						continue;
					case 4:
						controllerMap.enabled = _enabled;
						controllerMap.hardwareGuid = controller.hLHPojWAxuyakcKOieCsahbSjqfw;
						num = 2129898000;
						continue;
					case 0:
						controllerMap.layoutId = _layoutId;
						if (_sourceMapId >= 0)
						{
							controllerMap.sourceMapId = _sourceMapId;
							num = 2129898001;
							continue;
						}
						goto case 2;
					default:
					{
						using (TempListPool.TList<ActionElementMap> tList = TempListPool.GetTList<ActionElementMap>())
						{
							List<ActionElementMap> list = tList.list;
							int num2 = 0;
							while (true)
							{
								int num3 = 2129898000;
								while (true)
								{
									switch (num3 ^ 0x7EF3AA13)
									{
									case 0:
										break;
									case 1:
										num3 = 2129898005;
										continue;
									case 7:
										controllerMap.AddActionMapping_BeforeBake(list[num4]);
										num4++;
										num3 = 2129898005;
										continue;
									case 3:
										num3 = 2129898001;
										continue;
									case 4:
										num4 = 0;
										num3 = 2129898002;
										continue;
									case 5:
										_elementMaps[num2].RofGLuCvOlxXwczNPqjnCJgPbvhg(template, list, false);
										num3 = 2129898007;
										continue;
									case 6:
										if (num4 >= list.Count)
										{
											num2++;
											num3 = 2129898001;
											continue;
										}
										goto case 7;
									default:
										if (num2 >= _elementMaps.Count)
										{
											return controllerMap;
										}
										goto case 5;
									}
									break;
								}
							}
						}
					}
					}
					break;
				}
			}
			Logger.LogError("The Controller does not implement the expected Controller Template.");
			return null;
		}

		internal virtual void ExportDataToSerializedObject(SerializedObject serializedObject)
		{
			if (serializedObject.xmlInfo == null)
			{
				serializedObject.xmlInfo = new SerializedObject.XmlInfo();
				goto IL_0016;
			}
			goto IL_0107;
			IL_0107:
			serializedObject.Add("dataVersion", 1, SerializedObject.FieldOptions.ExculdeFromXml);
			serializedObject.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.XmlStringAttribute
			{
				localName = "dataVersion",
				value = 1.ToString()
			});
			int num = 101878489;
			goto IL_001b;
			IL_0016:
			num = 101878488;
			goto IL_001b;
			IL_001b:
			int num2 = default(int);
			int count = default(int);
			List<object> list = default(List<object>);
			while (true)
			{
				switch (num ^ 0x6128ADC)
				{
				case 2:
					break;
				case 8:
					num2++;
					num = 101878492;
					continue;
				case 6:
					serializedObject.Add("enabled", _enabled);
					serializedObject.Add("categoryId", _categoryId);
					serializedObject.Add("layoutId", _layoutId);
					serializedObject.Add("sourceMapId", _sourceMapId);
					count = _elementMaps.Count;
					list = new List<object>();
					num = 101878495;
					continue;
				case 3:
					serializedObject.Add("elementMaps", list);
					num = 101878491;
					continue;
				case 1:
					if (_elementMaps[num2] != null)
					{
						list.Add(_elementMaps[num2].LxAJUQVkKiSNqkaHsfsZAlQLTqTK());
						num = 101878484;
						continue;
					}
					goto case 8;
				case 4:
					goto IL_0107;
				case 5:
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
					num = 101878490;
					continue;
				case 7:
					num2 = 0;
					num = 101878492;
					continue;
				default:
					if (num2 >= count)
					{
						return;
					}
					goto case 1;
				}
				break;
			}
			goto IL_0016;
		}

		internal virtual void Import(SerializedObject serializedObject)
		{
			Clear();
			serializedObject.TryGetDeserializedValueByRef("enabled", ref _enabled);
			serializedObject.TryGetDeserializedValueByRef("categoryId", ref _categoryId);
			serializedObject.TryGetDeserializedValueByRef("layoutId", ref _layoutId);
			serializedObject.TryGetDeserializedValueByRef("sourceMapId", ref _sourceMapId);
			SerializedObject value = null;
			if (!serializedObject.TryGetDeserializedValueByRef("elementMaps", ref value) || value == null)
			{
				return;
			}
			ControllerTemplateActionElementMap controllerTemplateActionElementMap = default(ControllerTemplateActionElementMap);
			int num2 = default(int);
			SerializedObject value2 = default(SerializedObject);
			while (true)
			{
				int num = -1240534226;
				while (true)
				{
					switch (num ^ -1240534227)
					{
					case 7:
						break;
					default:
						return;
					case 5:
						if (controllerTemplateActionElementMap != null)
						{
							AddElementMap(controllerTemplateActionElementMap);
							num = -1240534228;
							continue;
						}
						goto case 1;
					case 1:
						num2++;
						num = -1240534229;
						continue;
					case 4:
						if (!value.TryGetDeserializedValue<SerializedObject>(num2, out value2))
						{
							int num4;
							if (value2 == null)
							{
								num = -1240534225;
								num4 = num;
							}
							else
							{
								num = -1240534228;
								num4 = num;
							}
							continue;
						}
						goto case 2;
					case 6:
					{
						int num3;
						if (num2 >= value.count)
						{
							num = -1240534227;
							num3 = num;
						}
						else
						{
							num = -1240534231;
							num3 = num;
						}
						continue;
					}
					case 2:
						controllerTemplateActionElementMap = ControllerTemplateActionElementMap.rHXUBQoqejbkONabpWgwEqatBJ(value2);
						num = -1240534232;
						continue;
					case 3:
						num2 = 0;
						num = -1240534229;
						continue;
					case 0:
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
			ControllerTemplateMap controllerTemplateMap = default(ControllerTemplateMap);
			ActionElementMap current = default(ActionElementMap);
			int num5 = default(int);
			while (true)
			{
				int num;
				int num2;
				if (controllerTemplate != null)
				{
					num = -1628326374;
					num2 = num;
				}
				else
				{
					num = -1628326382;
					num2 = num;
				}
				while (true)
				{
					switch (num ^ -1628326384)
					{
					case 6:
						num = -1628326381;
						continue;
					case 4:
						return null;
					case 5:
					{
						Controller controller = ReInput.controllers.GetController(controllerMap.controllerType, controllerMap.controllerId);
						if (controller != null)
						{
							if (!controller.ImplementsTemplate(controllerTemplate.typeGuid))
							{
								num = -1628326375;
								continue;
							}
							controllerTemplateMap = new ControllerTemplateMap(controllerTemplate.typeGuid);
							num = -1628326383;
						}
						else
						{
							num = -1628326384;
						}
						continue;
					}
					case 9:
						Logger.LogError("The Controller does not implement the Controller Template.", true);
						num = -1628326377;
						continue;
					case 2:
						throw new ArgumentNullException("controllerTemplate");
					case 3:
						break;
					case 1:
						controllerTemplateMap._enabled = controllerMap.enabled;
						controllerTemplateMap._categoryId = controllerMap.categoryId;
						controllerTemplateMap._layoutId = controllerMap.layoutId;
						controllerTemplateMap._sourceMapId = controllerMap.sourceMapId;
						num = -1628326376;
						continue;
					case 7:
						return null;
					case 10:
						if (!ReInput.isReady)
						{
							throw new Exception("Rewired is not initialized.");
						}
						goto case 5;
					case 0:
						Logger.LogError("The Controller Map is not associated with a Controller. This method can only be used with a Controller Map that is associated with a Controller.", true);
						num = -1628326380;
						continue;
					default:
					{
						TempListPool.TList<ControllerTemplateElementTarget> tList = TempListPool.GetTList<ControllerTemplateElementTarget>();
						try
						{
							List<ControllerTemplateElementTarget> list = tList.list;
							IEnumerator<ActionElementMap> enumerator = controllerMap.AllMaps.GetEnumerator();
							try
							{
								while (true)
								{
									IL_01e0:
									int num3;
									int num4;
									if (enumerator.MoveNext())
									{
										num3 = -1628326379;
										num4 = num3;
									}
									else
									{
										num3 = -1628326383;
										num4 = num3;
									}
									while (true)
									{
										switch (num3 ^ -1628326384)
										{
										case 0:
											num3 = -1628326379;
											continue;
										default:
											goto end_IL_0175;
										case 5:
											current = enumerator.Current;
											if (controllerTemplate.GetElementTargets(current, list) > 0)
											{
												num5 = 0;
												num3 = -1628326382;
												continue;
											}
											break;
										case 2:
										{
											int num6;
											if (num5 >= list.Count)
											{
												num3 = -1628326381;
												num6 = num3;
											}
											else
											{
												num3 = -1628326378;
												num6 = num3;
											}
											continue;
										}
										case 3:
											break;
										case 6:
											controllerTemplateMap.AddElementMap(ControllerTemplateActionElementMap.rHXUBQoqejbkONabpWgwEqatBJ(list[num5], current));
											num3 = -1628326380;
											continue;
										case 4:
											num5++;
											num3 = -1628326382;
											continue;
										case 1:
											goto end_IL_0175;
										}
										goto IL_01e0;
										continue;
										end_IL_0175:
										break;
									}
									break;
								}
							}
							finally
							{
								if (enumerator != null)
								{
									while (true)
									{
										IL_0232:
										int num7 = -1628326383;
										while (true)
										{
											switch (num7 ^ -1628326384)
											{
											case 2:
												break;
											default:
												goto end_IL_0237;
											case 1:
												goto IL_0250;
											case 0:
												goto end_IL_0237;
											}
											goto IL_0232;
											IL_0250:
											enumerator.Dispose();
											num7 = -1628326384;
											continue;
											end_IL_0237:
											break;
										}
										break;
									}
								}
							}
						}
						finally
						{
							if (tList != null)
							{
								while (true)
								{
									IL_0264:
									int num8 = -1628326383;
									while (true)
									{
										switch (num8 ^ -1628326384)
										{
										case 2:
											break;
										default:
											goto end_IL_0269;
										case 1:
											goto IL_0282;
										case 0:
											goto end_IL_0269;
										}
										goto IL_0264;
										IL_0282:
										((IDisposable)tList).Dispose();
										num8 = -1628326384;
										continue;
										end_IL_0269:
										break;
									}
									break;
								}
							}
						}
						return controllerTemplateMap;
					}
					}
					break;
				}
			}
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
				Logger.LogError("Error creating ControllerTemplateMap from JSON! " + ex.Message);
				return null;
			}
		}

		private static ControllerTemplateMap FromSerializedData(SerializedObject serializedObject)
		{
			Guid value;
			if (!serializedObject.TryGetDeserializedValue<Guid>("templateTypeGuid", out value))
			{
				throw new Exception();
			}
			ControllerTemplateMap controllerTemplateMap = new ControllerTemplateMap(value);
			controllerTemplateMap.Import(serializedObject);
			return controllerTemplateMap;
		}
	}
}
