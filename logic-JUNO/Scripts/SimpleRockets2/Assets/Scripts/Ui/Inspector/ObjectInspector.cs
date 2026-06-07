using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Assets.Scripts.PlanetStudio;
using Assets.Scripts.Ui.Sharing.PhotoLibrary;
using ModApi;
using ModApi.CelestialData;
using ModApi.Common;
using ModApi.Planet.Modifiers.Attributes;
using ModApi.Planet.Modifiers.VertexData;
using ModApi.Ui.Inspector;
using UnityEngine;

namespace Assets.Scripts.Ui.Inspector
{
	public class ObjectInspector : IObjectInspector
	{
		private class MemberWrapper
		{
			private Array _array;

			private FieldInfo _field;

			private int _index;

			private PropertyInfo _property;

			private object _target;

			public int? ArrayIndex
			{
				get
				{
					if (_array != null)
					{
						return _index;
					}
					return null;
				}
			}

			public FieldInfo Field => _field;

			public MemberInfo Member => (MemberInfo)(((object)_field) ?? ((object)_property));

			public PropertyInfo Property => _property;

			public object Target => _target;

			public Type Type { get; }

			public MemberWrapper(Type type, Array array, int index)
			{
				Type = type;
				_array = array;
				_index = index;
			}

			public MemberWrapper(Type type, FieldInfo field, object target)
			{
				Type = type;
				_field = field;
				_target = target;
			}

			public MemberWrapper(Type type, PropertyInfo property, object target)
			{
				Type = type;
				_property = property;
				_target = target;
			}

			public T GetInspectorAttribute<T>() where T : Attribute
			{
				FieldInfo field = _field;
				if ((object)field == null)
				{
					return null;
				}
				return field.GetCustomAttribute<T>();
			}

			public object GetValue()
			{
				if (_array != null)
				{
					return _array.GetValue(_index);
				}
				if (_field != null)
				{
					return _field.GetValue(_target);
				}
				return _property.GetValue(_target);
			}

			public void SetNumericValue(double value)
			{
				if (Type == typeof(int))
				{
					SetValue(Convert.ToInt32(value));
				}
				else if (Type == typeof(float))
				{
					SetValue(Convert.ToSingle(value));
				}
				else if (Type == typeof(double))
				{
					SetValue(Convert.ToDouble(value));
				}
			}

			public void SetValue(object value)
			{
				if (_array != null)
				{
					_array.SetValue(value, _index);
				}
				else if (_field != null)
				{
					_field.SetValue(_target, value);
				}
				else
				{
					_property.SetValue(_target, value);
				}
			}
		}

		private class ObjectInspectorTextureSelector : ITextureSelector
		{
			public void SelectTexture(TextureModel model, Action<string> onComplete)
			{
				PlanetStudioScript instance = PlanetStudioScript.Instance;
				PlanetStudioUIScript planetStudioUIScript = (PlanetStudioUIScript)instance.PlanetStudioUI;
				TexturePickerLibrary texturePickerLibrary = new TexturePickerLibrary(instance.CelestialBodyDesigner.CurrentCelestialBody?.FileData, model.TextureFilter);
				planetStudioUIScript.CreateTexturePicker(texturePickerLibrary, delegate(SupportFileData s, string p)
				{
					model.Label = s.FriendlyName;
					onComplete(p);
				});
			}
		}

		private static Dictionary<Type, List<ObjectInspectorFieldInfo>> _fieldsCache = new Dictionary<Type, List<ObjectInspectorFieldInfo>>();

		private ObjectInspectorTextureSelector _textureSelector;

		public string Name { get; set; }

		public Func<object, FieldInfo, bool> PreprocessField { get; set; } = (object o, FieldInfo f) => true;

		public Action RebuildModel { get; set; }

		public object Target { get; }

		protected ITextureSelector TextureSelector => _textureSelector ?? (_textureSelector = new ObjectInspectorTextureSelector());

		public ObjectInspector(string name, object target)
		{
			Name = name;
			Target = target;
		}

		public InspectorModel BuildModel(InspectorModel model)
		{
			GroupModel orCreateGroup = model.GetOrCreateGroup(null);
			BuildModelsForObject(Target, orCreateGroup, null);
			return model;
		}

		public void BuildModelForField(FieldInfo field, GroupModel group, object target, string name = null)
		{
			if (string.IsNullOrEmpty(name))
			{
				name = Utilities.FormatCodeToDisplayName(field.Name);
			}
			MemberWrapper wrapper = new MemberWrapper(field.FieldType, field, target);
			BuildModelForMember(group, name, wrapper);
		}

		public void BuildModelForProperty(PropertyInfo property, GroupModel group, object target, string name = null)
		{
			if (string.IsNullOrEmpty(name))
			{
				name = Utilities.FormatCodeToDisplayName(property.Name);
			}
			MemberWrapper wrapper = new MemberWrapper(property.PropertyType, property, target);
			BuildModelForMember(group, name, wrapper);
		}

		public void ForceRebuildModel()
		{
			RebuildModel?.Invoke();
		}

		IReadOnlyList<ObjectInspectorFieldInfo> IObjectInspector.GetInspectorFields(Type type)
		{
			return GetInspectorFields(type);
		}

		private static object CreateInstanceRecursive(Type type, object obj)
		{
			if (obj == null)
			{
				obj = (type.IsArray ? Array.CreateInstance(type.GetElementType(), 0) : ((!(type == typeof(string))) ? Activator.CreateInstance(type) : string.Empty));
			}
			foreach (ObjectInspectorFieldInfo inspectorField in GetInspectorFields(type))
			{
				FieldInfo field = inspectorField.Field;
				Type fieldType = field.FieldType;
				if (fieldType.IsClass)
				{
					object value = field.GetValue(obj);
					object value2 = CreateInstanceRecursive(fieldType, value);
					field.SetValue(obj, value2);
				}
			}
			return obj;
		}

		private static IReadOnlyList<ObjectInspectorFieldInfo> GetInspectorFields(Type type)
		{
			if (!_fieldsCache.TryGetValue(type, out var value))
			{
				value = new List<ObjectInspectorFieldInfo>();
				int num = 0;
				FieldInfo[] fields = type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
				foreach (FieldInfo fieldInfo in fields)
				{
					if (fieldInfo.GetCustomAttribute<NonSerializedAttribute>() == null && (!fieldInfo.IsPrivate || fieldInfo.GetCustomAttribute<SerializeField>() != null))
					{
						InspectorPropertyAttribute customAttribute = fieldInfo.GetCustomAttribute<InspectorPropertyAttribute>();
						InspectorGroupAttribute customAttribute2 = fieldInfo.GetCustomAttribute<InspectorGroupAttribute>();
						string text = customAttribute?.Label;
						if (string.IsNullOrWhiteSpace(text))
						{
							text = Utilities.FormatCodeToDisplayName(fieldInfo.Name);
						}
						int order = customAttribute?.Order ?? num++;
						string groupName = customAttribute2?.GroupName;
						value.Add(new ObjectInspectorFieldInfo(fieldInfo, text, order, groupName));
					}
				}
				value = (_fieldsCache[type] = (from x in value
					orderby x.Order, x.Label
					select x).ToList());
			}
			return value;
		}

		private void BuildModelForMember(GroupModel group, string name, MemberWrapper wrapper)
		{
			if (wrapper.Type.IsArray)
			{
				Array array = (Array)wrapper.GetValue();
				Type elementType = wrapper.Type.GetElementType();
				InspectorPropertyAttribute obj = wrapper.Field?.GetCustomAttribute<InspectorPropertyAttribute>();
				bool flag = obj?.ShowArrayGroup ?? true;
				bool flag2 = obj?.AllowArrayReorder ?? true;
				bool num = obj?.AllowArrayAddRemove ?? true;
				GroupModel groupModel = group;
				if (flag)
				{
					groupModel = new GroupModel(name + $" List ({array?.Length ?? 0} items)", name);
					group.Add(groupModel);
				}
				if (num)
				{
					TableRowModel tableRowModel = new TableRowModel();
					groupModel.Add(tableRowModel);
					tableRowModel.Add(new TextButtonModel("Add", delegate(TextButtonModel m)
					{
						Array array2 = Array.CreateInstance(elementType, (array?.Length ?? 0) + 1);
						if (array != null)
						{
							for (int i = 0; i < array.Length; i++)
							{
								array2.SetValue(array.GetValue(i), i);
							}
						}
						object value2 = CreateInstanceRecursive(elementType, null);
						array2.SetValue(value2, array2.Length - 1);
						wrapper.SetValue(array2);
						m.RaiseValueChangedByUserInput("Added " + name);
						ForceRebuildModel();
					}));
					tableRowModel.Add(new TextButtonModel("Remove", delegate(TextButtonModel m)
					{
						Array array2 = array;
						if (array2 != null && array2.Length > 0)
						{
							Array array3 = Array.CreateInstance(elementType, array.Length - 1);
							for (int i = 0; i < array3.Length; i++)
							{
								array3.SetValue(array.GetValue(i), i);
							}
							wrapper.SetValue(array3);
							m.RaiseValueChangedByUserInput("Removed " + name);
							ForceRebuildModel();
						}
					}));
				}
				if (array == null)
				{
					return;
				}
				TextButtonModel hiddenButton = groupModel.Add(new TextButtonModel("Value Changed Event", null));
				hiddenButton.Visible = false;
				groupModel.Add(hiddenButton);
				ICustomObjectInspectorModelFields customObjectInspectorModelFields = wrapper.Target as ICustomObjectInspectorModelFields;
				for (int num2 = 0; num2 < array.Length; num2++)
				{
					if (customObjectInspectorModelFields == null || !customObjectInspectorModelFields.CreateFieldModel(groupModel, this, wrapper.Member, num2))
					{
						MemberWrapper wrapper2 = new MemberWrapper(elementType, array, num2);
						BuildModelForMember(groupModel, name + $" {num2 + 1}", wrapper2);
					}
					if (!(groupModel.Items.LastOrDefault() is GroupModel groupModel2))
					{
						continue;
					}
					int index = num2;
					if (flag2)
					{
						groupModel2.OnMoveItem = delegate(int direction)
						{
							int num3 = index + direction;
							if (num3 >= 0 && num3 < array.Length)
							{
								object value2 = array.GetValue(num3);
								array.SetValue(array.GetValue(index), num3);
								array.SetValue(value2, index);
								hiddenButton.RaiseValueChangedByUserInput("Rearranged items in " + name);
								ForceRebuildModel();
							}
						};
					}
					groupModel2.OnDeleteItem = delegate
					{
						Array array2 = array;
						if (array2 != null && array2.Length > 0)
						{
							Array array3 = Array.CreateInstance(elementType, array.Length - 1);
							for (int i = 0; i < array3.Length; i++)
							{
								int index2 = ((i < index) ? i : (i + 1));
								array3.SetValue(array.GetValue(index2), i);
							}
							wrapper.SetValue(array3);
							hiddenButton.RaiseValueChangedByUserInput("Deleted item in " + name);
							ForceRebuildModel();
						}
					};
				}
				return;
			}
			ICustomObjectInspectorModelFields obj2 = wrapper.Target as ICustomObjectInspectorModelFields;
			if (obj2 != null && obj2.CreateFieldModel(group, this, wrapper.Member, null))
			{
				return;
			}
			ItemModel itemModel = BuildModelForPrimitive(name, group, wrapper);
			if (itemModel != null)
			{
				InspectorPropertyAttribute inspectorAttribute = wrapper.GetInspectorAttribute<InspectorPropertyAttribute>();
				if (inspectorAttribute == null)
				{
					return;
				}
				itemModel.Tooltip = inspectorAttribute.Tooltip;
				if (!inspectorAttribute.ForceRefresh || !(itemModel is IValueChanged valueChanged))
				{
					return;
				}
				valueChanged.ValueChangedByUserInput += delegate(ItemModel m, string n, bool finished)
				{
					if (finished)
					{
						ForceRebuildModel();
					}
				};
			}
			else
			{
				object value = wrapper.GetValue();
				if (value != null)
				{
					InspectorGroupAttribute inspectorAttribute2 = wrapper.GetInspectorAttribute<InspectorGroupAttribute>();
					string groupName = ((inspectorAttribute2 != null) ? inspectorAttribute2.GroupName : name);
					BuildModelsForObject(value, group, groupName);
				}
			}
		}

		private ItemModel BuildModelForPrimitive(string name, GroupModel group, MemberWrapper wrapper)
		{
			if (wrapper.Type.IsEnum)
			{
				DropdownModel dropdownModel = group.Add(new DropdownModel(name, () => wrapper.GetValue().ToString(), delegate(string x)
				{
					wrapper.SetValue(Enum.Parse(wrapper.Type, x));
				}));
				dropdownModel.Alignment = ElementAlignment.Right;
				{
					foreach (object value in Utilities.Enums.GetValues(wrapper.Type))
					{
						string displayName = Utilities.FormatCodeToDisplayName(Utilities.Enums.GetDisplayName(wrapper.Type, value));
						dropdownModel.Options.Add(new DropdownModel.DropdownOption(displayName, value.ToString()));
					}
					return dropdownModel;
				}
			}
			if (wrapper.Type == typeof(bool))
			{
				return group.Add(new ToggleModel(name, () => (bool)wrapper.GetValue(), delegate(bool x)
				{
					wrapper.SetValue(x);
				}));
			}
			if (wrapper.Type == typeof(float) || wrapper.Type == typeof(double) || wrapper.Type == typeof(int))
			{
				RangeAttribute inspectorAttribute = wrapper.GetInspectorAttribute<RangeAttribute>();
				if (inspectorAttribute == null)
				{
					NumericRangeAttribute inspectorAttribute2 = wrapper.GetInspectorAttribute<NumericRangeAttribute>();
					if (wrapper.Type == typeof(float))
					{
						return group.Add(new FloatInputModel(name, () => (float)wrapper.GetValue(), delegate(float x)
						{
							wrapper.SetValue(x);
						}, (float?)inspectorAttribute2?.Min, (float?)inspectorAttribute2?.Max));
					}
					return group.Add(new NumericInputModel(name, () => Convert.ToDouble(wrapper.GetValue()), delegate(double x)
					{
						wrapper.SetNumericValue(x);
					}, inspectorAttribute2?.Min, inspectorAttribute2?.Max));
				}
				bool wholeNumbers = wrapper.Type == typeof(int);
				SliderModel sliderModel = group.Add(new SliderModel(name, () => Convert.ToSingle(wrapper.GetValue()), delegate(float x)
				{
					wrapper.SetNumericValue(x);
				}, inspectorAttribute.min, inspectorAttribute.max, wholeNumbers));
				sliderModel.ValueFormatter = (float x) => x.ToString();
				return sliderModel;
			}
			if (wrapper.Type == typeof(string))
			{
				SupportFileReferenceAttribute inspectorAttribute3 = wrapper.GetInspectorAttribute<SupportFileReferenceAttribute>();
				if (inspectorAttribute3 != null)
				{
					if (inspectorAttribute3.Type == SupportFileType.Texture)
					{
						TextureFileReferenceFilterType filterType = TextureFileReferenceFilterType.Default;
						if (inspectorAttribute3 is TextureFileReferenceAttribute textureFileReferenceAttribute)
						{
							filterType = textureFileReferenceAttribute.FilterType;
						}
						return BuildModelForTextureReference(group, wrapper, filterType);
					}
					Debug.LogError($"Support file reference type '{inspectorAttribute3.Type}' is not yet supported.");
					return null;
				}
				return group.Add(new TextInputModel(name, () => Convert.ToString(wrapper.GetValue()), delegate(string x)
				{
					wrapper.SetValue(x);
				}, ElementAlignment.Right));
			}
			if (wrapper.Type == typeof(Vector3))
			{
				return group.Add(new Vector3InputModel(name, () => (Vector3)wrapper.GetValue(), delegate(Vector3 v)
				{
					wrapper.SetValue(v);
				}));
			}
			if (wrapper.Type == typeof(Vector3d))
			{
				return group.Add(new Vector3dInputModel(name, () => (Vector3d)wrapper.GetValue(), delegate(Vector3d v)
				{
					wrapper.SetValue(v);
				}));
			}
			if (wrapper.Type == typeof(Vector2))
			{
				return group.Add(new Vector2InputModel(name, () => (Vector2)wrapper.GetValue(), delegate(Vector2 v)
				{
					wrapper.SetValue(v);
				}));
			}
			if (wrapper.Type == typeof(Vector2d))
			{
				return group.Add(new Vector2dInputModel(name, () => (Vector2d)wrapper.GetValue(), delegate(Vector2d v)
				{
					wrapper.SetValue(v);
				}));
			}
			if (wrapper.Type == typeof(Vector2i))
			{
				return group.Add(new Vector2IntInputModel(name, () => (Vector2i)wrapper.GetValue(), delegate(Vector2i v)
				{
					wrapper.SetValue(v);
				}));
			}
			if (wrapper.Type == typeof(MinMaxValue))
			{
				return group.Add(new MinMaxValueInputModel(name, () => (MinMaxValue)wrapper.GetValue(), delegate(MinMaxValue v)
				{
					wrapper.SetValue(v);
				}));
			}
			if (wrapper.Type == typeof(AnimationCurve))
			{
				return group.Add(new CurveModel(name, () => ((AnimationCurve)wrapper.GetValue()) ?? new AnimationCurve(new Keyframe(0f, 0f), new Keyframe(1f, 0f)), delegate(AnimationCurve v)
				{
					wrapper.SetValue(v);
				}));
			}
			if (wrapper.Type == typeof(Color))
			{
				bool allowTransparency = false;
				bool allowHDR = false;
				ColorUsageAttribute inspectorAttribute4 = wrapper.GetInspectorAttribute<ColorUsageAttribute>();
				if (inspectorAttribute4 != null)
				{
					allowHDR = inspectorAttribute4.hdr;
					allowTransparency = inspectorAttribute4.showAlpha;
				}
				return group.Add(new ColorModel(name, () => (Color)wrapper.GetValue(), delegate(Color v)
				{
					wrapper.SetValue(v);
				}, allowTransparency, callbackOnPreviewColorChange: false, allowHDR));
			}
			if (wrapper.Type == typeof(Color32))
			{
				return group.Add(new ColorModel(name, () => (Color32)wrapper.GetValue(), delegate(Color v)
				{
					wrapper.SetValue((Color32)v);
				}));
			}
			if (wrapper.Type == typeof(Gradient))
			{
				bool hasAlpha = true;
				bool allowHDR2 = false;
				ColorUsageAttribute inspectorAttribute5 = wrapper.GetInspectorAttribute<ColorUsageAttribute>();
				if (inspectorAttribute5 != null)
				{
					hasAlpha = inspectorAttribute5.showAlpha;
					allowHDR2 = inspectorAttribute5.hdr;
				}
				return group.Add(new GradientModel(name, () => (Gradient)wrapper.GetValue(), delegate(Gradient v)
				{
					wrapper.SetValue(v);
				}, hasAlpha, allowHDR2));
			}
			return null;
		}

		private TextureModel BuildModelForTextureReference(GroupModel group, MemberWrapper wrapper, TextureFileReferenceFilterType filterType)
		{
			string text = (string)wrapper.GetValue();
			if (string.IsNullOrWhiteSpace(text))
			{
				text = "Select Texture";
			}
			Func<SupportFileData, bool> filter = null;
			if (filterType == TextureFileReferenceFilterType.Cubemap)
			{
				filter = TexturePickerLibrary.FilterCubemap;
			}
			TextureModel item = new TextureModel(text, TextureSelector, delegate
			{
				string localId = (string)wrapper.GetValue();
				return PlanetStudioScript.Instance.CelestialBodyDesigner.GetSupportFile(localId)?.Path.FullPath;
			}, delegate(string x)
			{
				string orCreateSupportFileReference = PlanetStudioScript.Instance.CelestialBodyDesigner.GetOrCreateSupportFileReference(x);
				wrapper.SetValue(orCreateSupportFileReference);
			}, filter);
			return group.AddAndBuild(item).Model;
		}

		private void BuildModelsForObject(object target, GroupModel group, string groupName)
		{
			Type type = target.GetType();
			GroupModel groupModel = group;
			if (target is ICustomObjectInspectorModel customObjectInspectorModel)
			{
				if (!string.IsNullOrWhiteSpace(groupName) && customObjectInspectorModel.CreateGroup)
				{
					groupModel = group.Add(new GroupModel(groupName));
				}
				customObjectInspectorModel.CreateModel(groupModel, this);
				return;
			}
			if (!string.IsNullOrWhiteSpace(groupName))
			{
				groupModel = group.Add(new GroupModel(groupName));
			}
			if (target is ICustomInspectorFields customInspectorFields)
			{
				GroupModel groupModel2 = groupModel;
				{
					foreach (FieldInfo inspectorField in customInspectorFields.GetInspectorFields())
					{
						if (!PreprocessField(target, inspectorField))
						{
							continue;
						}
						InspectorPropertyAttribute customAttribute = inspectorField.GetCustomAttribute<InspectorPropertyAttribute>();
						InspectorGroupAttribute customAttribute2 = inspectorField.GetCustomAttribute<InspectorGroupAttribute>();
						string text = customAttribute?.Label;
						if (string.IsNullOrWhiteSpace(text))
						{
							text = Utilities.FormatCodeToDisplayName(inspectorField.Name);
						}
						if (customAttribute2 != null)
						{
							if (customAttribute2.Reset)
							{
								groupModel2 = groupModel;
							}
							else if (!string.IsNullOrWhiteSpace(customAttribute2.GroupName))
							{
								groupModel2 = groupModel.Add(new GroupModel(customAttribute2.GroupName));
							}
						}
						BuildModelForField(inspectorField, groupModel2, target, text);
					}
					return;
				}
			}
			GroupModel groupModel3 = groupModel;
			foreach (ObjectInspectorFieldInfo inspectorField2 in GetInspectorFields(type))
			{
				if (PreprocessField(target, inspectorField2.Field))
				{
					if (!string.IsNullOrWhiteSpace(inspectorField2.GroupName))
					{
						groupModel3 = groupModel.Add(new GroupModel(inspectorField2.GroupName));
					}
					BuildModelForField(inspectorField2.Field, groupModel3, target, inspectorField2.Label);
				}
			}
		}
	}
}
