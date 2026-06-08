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
				while (true)
				{
					int num = 1659013797;
					while (true)
					{
						switch (num ^ 0x62E28AA4)
						{
						case 0:
							break;
						case 1:
							goto IL_002b;
						default:
							return string.Empty;
						}
						break;
						IL_002b:
						ReInput.CheckInitialized(_reInputId);
						num = 1659013798;
					}
				}
			}
			string result = default(string);
			try
			{
				result = Export().ToXmlString(writeDocumentTag: true);
			}
			catch (Exception ex)
			{
				while (true)
				{
					IL_0054:
					int num2 = 1659013797;
					while (true)
					{
						switch (num2 ^ 0x62E28AA4)
						{
						case 3:
							break;
						default:
							goto end_IL_0059;
						case 1:
							Logger.LogWarning("Error writing " + GetType().Name + " to XML. " + ex.Message);
							num2 = 1659013796;
							continue;
						case 0:
							result = string.Empty;
							num2 = 1659013798;
							continue;
						case 2:
							goto end_IL_0059;
						}
						goto IL_0054;
						continue;
						end_IL_0059:
						break;
					}
					break;
				}
			}
			return result;
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
				throw new ArgumentNullException("controller");
			}
			ControllerMap controllerMap = default(ControllerMap);
			int num5 = default(int);
			while (true)
			{
				IControllerTemplate template = controller.GetTemplate(_templateTypeGuid);
				int num;
				if (template == null)
				{
					Logger.LogError("The Controller does not implement the expected Controller Template.");
					num = 1355219891;
				}
				else
				{
					controllerMap = ControllerMap.GIHuiEkmFihgdjpqkqIhwXanlmm(controller.type);
					controllerMap.categoryId = _categoryId;
					controllerMap.layoutId = _layoutId;
					num = 1355219890;
				}
				while (true)
				{
					switch (num ^ 0x50C703B1)
					{
					case 0:
						num = 1355219893;
						continue;
					case 4:
						break;
					case 2:
						return null;
					case 3:
						if (_sourceMapId >= 0)
						{
							controllerMap.sourceMapId = _sourceMapId;
							num = 1355219888;
							continue;
						}
						goto default;
					default:
					{
						controllerMap.controllerId = controller.id;
						controllerMap.controllerType = controller.type;
						controllerMap.enabled = _enabled;
						controllerMap.hardwareGuid = controller.WhXaNimcOuXdrXZrlSbhrrJNttC;
						using (TempListPool.TList<ActionElementMap> tList = TempListPool.GetTList<ActionElementMap>())
						{
							List<ActionElementMap> list = tList.list;
							int num2 = 0;
							while (true)
							{
								IL_0156:
								int num3;
								int num4;
								if (num2 < _elementMaps.Count)
								{
									num3 = 1355219895;
									num4 = num3;
								}
								else
								{
									num3 = 1355219893;
									num4 = num3;
								}
								while (true)
								{
									switch (num3 ^ 0x50C703B1)
									{
									case 5:
										num3 = 1355219895;
										continue;
									default:
										goto end_IL_0103;
									case 6:
										_elementMaps[num2].eKnqmjiMlbYPbNAwCiMmSHMCWkS(template, list, false);
										num3 = 1355219891;
										continue;
									case 2:
										num5 = 0;
										num3 = 1355219890;
										continue;
									case 0:
										break;
									case 3:
										if (num5 >= list.Count)
										{
											num2++;
											num3 = 1355219889;
											continue;
										}
										goto case 1;
									case 1:
										controllerMap.IXqmncltgmkzpGDZegTRdilkcDa(list[num5]);
										num5++;
										num3 = 1355219890;
										continue;
									case 4:
										goto end_IL_0103;
									}
									goto IL_0156;
									continue;
									end_IL_0103:
									break;
								}
								break;
							}
						}
						return controllerMap;
					}
					}
					break;
				}
			}
		}

		internal virtual void ExportDataToSerializedObject(SerializedObject serializedObject)
		{
			if (serializedObject.xmlInfo == null)
			{
				goto IL_000b;
			}
			goto IL_0269;
			IL_000b:
			int num = 197458422;
			goto IL_0010;
			IL_0010:
			int num2 = default(int);
			List<object> list = default(List<object>);
			int count = default(int);
			while (true)
			{
				switch (num ^ 0xBC4F9FC)
				{
				case 6:
					break;
				default:
					return;
				case 1:
					if (_elementMaps[num2] != null)
					{
						list.Add(_elementMaps[num2].mtMtVVrohwWTxFPivXmGbDyGevo());
						num = 197458424;
						continue;
					}
					goto case 4;
				case 0:
					num2 = 0;
					num = 197458430;
					continue;
				case 2:
					goto IL_0081;
				case 5:
					serializedObject.Add("categoryId", _categoryId);
					num = 197458427;
					continue;
				case 10:
					serializedObject.xmlInfo = new SerializedObject.XmlInfo();
					num = 197458420;
					continue;
				case 4:
					num2++;
					num = 197458430;
					continue;
				case 7:
					serializedObject.Add("layoutId", _layoutId);
					serializedObject.Add("sourceMapId", _sourceMapId);
					count = _elementMaps.Count;
					list = new List<object>();
					serializedObject.Add("elementMaps", list);
					num = 197458428;
					continue;
				case 9:
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
					num = 197458425;
					continue;
				case 8:
					goto IL_0269;
				case 3:
					return;
				}
				break;
				IL_0081:
				int num3;
				if (num2 < count)
				{
					num = 197458429;
					num3 = num;
				}
				else
				{
					num = 197458431;
					num3 = num;
				}
			}
			goto IL_000b;
			IL_0269:
			serializedObject.Add("dataVersion", 1, SerializedObject.FieldOptions.ExculdeFromXml);
			serializedObject.xmlInfo.attributes.Add(new SerializedObject.XmlInfo.XmlStringAttribute
			{
				localName = "dataVersion",
				value = 1.ToString()
			});
			num = 197458421;
			goto IL_0010;
		}

		internal virtual void Import(SerializedObject serializedObject)
		{
			Clear();
			SerializedObject value2 = default(SerializedObject);
			int num2 = default(int);
			SerializedObject value = default(SerializedObject);
			while (true)
			{
				int num = 1239251422;
				while (true)
				{
					switch (num ^ 0x49DD79DB)
					{
					case 2:
						break;
					default:
						return;
					case 3:
					{
						int num5;
						if (value2 != null)
						{
							num = 1239251423;
							num5 = num;
						}
						else
						{
							num = 1239251418;
							num5 = num;
						}
						continue;
					}
					case 4:
						num2++;
						num = 1239251411;
						continue;
					case 5:
					{
						serializedObject.TryGetDeserializedValueByRef("enabled", ref _enabled);
						serializedObject.TryGetDeserializedValueByRef("categoryId", ref _categoryId);
						serializedObject.TryGetDeserializedValueByRef("layoutId", ref _layoutId);
						serializedObject.TryGetDeserializedValueByRef("sourceMapId", ref _sourceMapId);
						value = null;
						int num6;
						if (!serializedObject.TryGetDeserializedValueByRef("elementMaps", ref value))
						{
							num = 1239251420;
							num6 = num;
						}
						else
						{
							num = 1239251421;
							num6 = num;
						}
						continue;
					}
					case 8:
					{
						int num4;
						if (num2 >= value.count)
						{
							num = 1239251420;
							num4 = num;
						}
						else
						{
							num = 1239251419;
							num4 = num;
						}
						continue;
					}
					case 6:
						if (value != null)
						{
							num2 = 0;
							num = 1239251411;
							continue;
						}
						return;
					case 1:
					{
						ControllerTemplateActionElementMap controllerTemplateActionElementMap = ControllerTemplateActionElementMap.GIHuiEkmFihgdjpqkqIhwXanlmm(value2);
						if (controllerTemplateActionElementMap != null)
						{
							AddElementMap(controllerTemplateActionElementMap);
							num = 1239251423;
							continue;
						}
						goto case 4;
					}
					case 0:
					{
						int num3;
						if (value.TryGetDeserializedValue<SerializedObject>(num2, out value2))
						{
							num = 1239251418;
							num3 = num;
						}
						else
						{
							num = 1239251416;
							num3 = num;
						}
						continue;
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
				goto IL_0003;
			}
			goto IL_0066;
			IL_0003:
			int num = -508653576;
			goto IL_0008;
			IL_0008:
			ControllerTemplateMap controllerTemplateMap = default(ControllerTemplateMap);
			int num4 = default(int);
			ActionElementMap current = default(ActionElementMap);
			Controller controller = default(Controller);
			while (true)
			{
				switch (num ^ -508653575)
				{
				case 8:
					break;
				case 7:
					goto IL_0040;
				case 0:
					goto IL_004a;
				case 3:
					goto IL_0066;
				case 2:
					return null;
				case 4:
					Logger.LogError("The Controller Map is not associated with a Controller. This method can only be used with a Controller Map that is associated with a Controller.", requiredThreadSafety: true);
					return null;
				case 1:
					throw new ArgumentNullException("controllerMap");
				case 9:
					goto IL_00e4;
				case 6:
					controllerTemplateMap._categoryId = controllerMap.categoryId;
					controllerTemplateMap._layoutId = controllerMap.layoutId;
					controllerTemplateMap._sourceMapId = controllerMap.sourceMapId;
					num = -508653572;
					continue;
				default:
				{
					using (TempListPool.TList<ControllerTemplateElementTarget> tList = TempListPool.GetTList<ControllerTemplateElementTarget>())
					{
						List<ControllerTemplateElementTarget> list = tList.list;
						using (IEnumerator<ActionElementMap> enumerator = controllerMap.AllMaps.GetEnumerator())
						{
							while (true)
							{
								IL_01ee:
								int num2;
								int num3;
								if (!enumerator.MoveNext())
								{
									num2 = -508653573;
									num3 = num2;
								}
								else
								{
									num2 = -508653574;
									num3 = num2;
								}
								while (true)
								{
									switch (num2 ^ -508653575)
									{
									case 5:
										num2 = -508653574;
										continue;
									default:
										goto end_IL_0157;
									case 1:
										controllerTemplateMap.AddElementMap(ControllerTemplateActionElementMap.GIHuiEkmFihgdjpqkqIhwXanlmm(list[num4], current));
										num4++;
										num2 = -508653571;
										continue;
									case 6:
										if (controllerTemplate.GetElementTargets(current, list) > 0)
										{
											num4 = 0;
											num2 = -508653571;
											continue;
										}
										break;
									case 3:
										current = enumerator.Current;
										num2 = -508653569;
										continue;
									case 4:
									{
										int num5;
										if (num4 >= list.Count)
										{
											num2 = -508653575;
											num5 = num2;
										}
										else
										{
											num2 = -508653576;
											num5 = num2;
										}
										continue;
									}
									case 0:
										break;
									case 2:
										goto end_IL_0157;
									}
									goto IL_01ee;
									continue;
									end_IL_0157:
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
				IL_0040:
				if (controller == null)
				{
					num = -508653571;
				}
				else if (controller.ImplementsTemplate(controllerTemplate.typeGuid))
				{
					controllerTemplateMap = new ControllerTemplateMap(controllerTemplate.typeGuid);
					controllerTemplateMap._enabled = controllerMap.enabled;
					num = -508653569;
				}
				else
				{
					Logger.LogError("The Controller does not implement the Controller Template.", requiredThreadSafety: true);
					num = -508653573;
				}
			}
			goto IL_0003;
			IL_00e4:
			controller = ReInput.controllers.GetController(controllerMap.controllerType, controllerMap.controllerId);
			num = -508653570;
			goto IL_0008;
			IL_004a:
			if (!ReInput.isReady)
			{
				throw new Exception("Rewired is not initialized.");
			}
			goto IL_00e4;
			IL_0066:
			if (controllerTemplate == null)
			{
				throw new ArgumentNullException("controllerTemplate");
			}
			goto IL_004a;
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
			if (!serializedObject.TryGetDeserializedValue<Guid>("templateTypeGuid", out var value))
			{
				throw new Exception();
			}
			ControllerTemplateMap controllerTemplateMap = new ControllerTemplateMap(value);
			controllerTemplateMap.Import(serializedObject);
			return controllerTemplateMap;
		}
	}
}
