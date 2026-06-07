using System;
using System.Collections.Generic;
using System.Reflection;
using System.Xml.Linq;
using ModApi.Planet.Modifiers.Attributes;
using ModApi.Ui.Inspector;
using UnityEngine;

namespace ModApi.Planet.Modifiers.VertexData
{
	[PlanetModifierInfo("Basic Arithmetic", "A planet modifier used to perform basic math operations on one or two data input values.")]
	public class BasicArithmetic : VertexDataCommonPassPlanetModifier, ICustomObjectInspectorModel, IDataSlotConfiguration
	{
		[SerializeField]
		private BasicArithmeticType _arithmeticType = BasicArithmeticType.AbsoluteValue_A;

		[SerializeField]
		private float _constantValueC = 1f;

		[SerializeField]
		[Range(0f, 9f)]
		[DataSlot(DataSlotType.Input, "Input A", false, true, Tooltip = "The 'A' Input.")]
		private int _dataIndexInputA;

		[SerializeField]
		[Range(0f, 9f)]
		[DataSlot(DataSlotType.Input, "Input B", false, true, Tooltip = "The 'B' Input.")]
		private int _dataIndexInputB;

		[SerializeField]
		[Range(0f, 9f)]
		[DataSlot(DataSlotType.Output, "Output", false, true, Tooltip = "The output value.")]
		private int _dataIndexOutput;

		public bool CreateGroup => false;

		public override VertexDataType VertexDataType => VertexDataType.Both;

		public void CreateModel(GroupModel model, IObjectInspector objectInspector)
		{
			model.AddAndBuild(new EnumDropdownModel<BasicArithmeticType>("Operation", () => _arithmeticType, "The type of the operation to perform on the inputs.")).Build(delegate(EnumDropdownModel<BasicArithmeticType> x)
			{
				x.ValueChanged += delegate(BasicArithmeticType newValue, BasicArithmeticType oldValue)
				{
					_arithmeticType = newValue;
					objectInspector.ForceRebuildModel();
				};
			}).Build(delegate(EnumDropdownModel<BasicArithmeticType> x)
			{
				x.Tooltip = "The type of operation to perform.";
			});
			model.AddAndBuild(new FloatInputModel("Input C", () => _constantValueC, delegate(float x)
			{
				_constantValueC = x;
			})).Build(delegate(FloatInputModel x)
			{
				x.Tooltip = "The constant value 'C' input.";
			}).Build(delegate(FloatInputModel x)
			{
				x.DetermineVisibility = () => _arithmeticType == BasicArithmeticType.Add_A_PLUS_C || _arithmeticType == BasicArithmeticType.Subtract_A_MINUS_C || _arithmeticType == BasicArithmeticType.Subtract_C_MINUS_A || _arithmeticType == BasicArithmeticType.Multiply_A_TIMES_C || _arithmeticType == BasicArithmeticType.Divide_A_By_C || _arithmeticType == BasicArithmeticType.Divide_C_By_A || _arithmeticType == BasicArithmeticType.Exponent_A_POW_C || _arithmeticType == BasicArithmeticType.Exponent_C_POW_A || _arithmeticType == BasicArithmeticType.Min_AC || _arithmeticType == BasicArithmeticType.Max_AC;
			});
		}

		public void GetDataSlots(List<DataSlotField> dataSlots)
		{
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			switch (_arithmeticType)
			{
			case BasicArithmeticType.Add_A_PLUS_B:
			case BasicArithmeticType.Subtract_A_MINUS_B:
			case BasicArithmeticType.Multiply_A_TIMES_B:
			case BasicArithmeticType.Divide_A_By_B:
			case BasicArithmeticType.Exponent_A_POW_B:
			case BasicArithmeticType.Min_AB:
			case BasicArithmeticType.Max_AB:
				flag = true;
				flag2 = true;
				break;
			case BasicArithmeticType.Add_A_PLUS_C:
			case BasicArithmeticType.Subtract_A_MINUS_C:
			case BasicArithmeticType.Subtract_C_MINUS_A:
			case BasicArithmeticType.Multiply_A_TIMES_C:
			case BasicArithmeticType.Divide_A_By_C:
			case BasicArithmeticType.Divide_C_By_A:
			case BasicArithmeticType.Exponent_A_POW_C:
			case BasicArithmeticType.Exponent_C_POW_A:
			case BasicArithmeticType.Min_AC:
			case BasicArithmeticType.Max_AC:
				flag = true;
				flag3 = true;
				break;
			default:
				flag = true;
				break;
			}
			if (flag)
			{
				FieldInfo field = typeof(BasicArithmetic).GetField("_dataIndexInputA", BindingFlags.Instance | BindingFlags.NonPublic);
				dataSlots.Add(new DataSlotField(this, field.GetCustomAttribute<DataSlotAttribute>(), field));
			}
			if (flag2)
			{
				FieldInfo field2 = typeof(BasicArithmetic).GetField("_dataIndexInputB", BindingFlags.Instance | BindingFlags.NonPublic);
				dataSlots.Add(new DataSlotField(this, field2.GetCustomAttribute<DataSlotAttribute>(), field2));
			}
			FieldInfo field3 = typeof(BasicArithmetic).GetField("_dataIndexOutput", BindingFlags.Instance | BindingFlags.NonPublic);
			dataSlots.Add(new DataSlotField(this, field3.GetCustomAttribute<DataSlotAttribute>(), field3));
		}

		public override void GetVertexData(PlanetVertexDataInput input, PlanetVertexData data)
		{
			double num = data.Data[_dataIndexInputA];
			double num2 = data.Data[_dataIndexInputB];
			float constantValueC = _constantValueC;
			double num3 = 0.0;
			num3 = _arithmeticType switch
			{
				BasicArithmeticType.Add_A_PLUS_B => num + num2, 
				BasicArithmeticType.Add_A_PLUS_C => num + (double)constantValueC, 
				BasicArithmeticType.Subtract_A_MINUS_B => num - num2, 
				BasicArithmeticType.Subtract_A_MINUS_C => num - (double)constantValueC, 
				BasicArithmeticType.Subtract_C_MINUS_A => (double)constantValueC - num, 
				BasicArithmeticType.Multiply_A_TIMES_B => num * num2, 
				BasicArithmeticType.Multiply_A_TIMES_C => num * (double)constantValueC, 
				BasicArithmeticType.Divide_A_By_B => num / num2, 
				BasicArithmeticType.Divide_A_By_C => num / (double)constantValueC, 
				BasicArithmeticType.Divide_C_By_A => (double)constantValueC / num, 
				BasicArithmeticType.Exponent_A_POW_B => Mathd.Pow(num, num2), 
				BasicArithmeticType.Exponent_A_POW_C => Mathd.Pow(num, constantValueC), 
				BasicArithmeticType.Exponent_C_POW_A => Mathd.Pow(constantValueC, num), 
				BasicArithmeticType.AbsoluteValue_A => Mathd.Abs(num), 
				BasicArithmeticType.Min_AB => Mathd.Min(num, num2), 
				BasicArithmeticType.Min_AC => Mathd.Min(num, constantValueC), 
				BasicArithmeticType.Max_AB => Mathd.Max(num, num2), 
				BasicArithmeticType.Max_AC => Mathd.Max(num, constantValueC), 
				BasicArithmeticType.Sign_A => Mathd.Sign(num), 
				_ => throw new NotSupportedException(), 
			};
			data.Data[_dataIndexOutput] = num3;
		}

		public override void GetVertexData(PlanetVertexDataInput input, PlanetBiomeVertexData data)
		{
			double num = data.Data[_dataIndexInputA];
			double num2 = data.Data[_dataIndexInputB];
			float constantValueC = _constantValueC;
			double num3 = 0.0;
			num3 = _arithmeticType switch
			{
				BasicArithmeticType.Add_A_PLUS_B => num + num2, 
				BasicArithmeticType.Add_A_PLUS_C => num + (double)constantValueC, 
				BasicArithmeticType.Subtract_A_MINUS_B => num - num2, 
				BasicArithmeticType.Subtract_A_MINUS_C => num - (double)constantValueC, 
				BasicArithmeticType.Subtract_C_MINUS_A => (double)constantValueC - num, 
				BasicArithmeticType.Multiply_A_TIMES_B => num * num2, 
				BasicArithmeticType.Multiply_A_TIMES_C => num * (double)constantValueC, 
				BasicArithmeticType.Divide_A_By_B => num / num2, 
				BasicArithmeticType.Divide_A_By_C => num / (double)constantValueC, 
				BasicArithmeticType.Divide_C_By_A => (double)constantValueC / num, 
				BasicArithmeticType.Exponent_A_POW_B => Mathd.Pow(num, num2), 
				BasicArithmeticType.Exponent_A_POW_C => Mathd.Pow(num, constantValueC), 
				BasicArithmeticType.Exponent_C_POW_A => Mathd.Pow(constantValueC, num), 
				BasicArithmeticType.AbsoluteValue_A => Mathd.Abs(num), 
				BasicArithmeticType.Min_AB => Mathd.Min(num, num2), 
				BasicArithmeticType.Min_AC => Mathd.Min(num, constantValueC), 
				BasicArithmeticType.Max_AB => Mathd.Max(num, num2), 
				BasicArithmeticType.Max_AC => Mathd.Max(num, constantValueC), 
				BasicArithmeticType.Sign_A => Mathd.Sign(num), 
				_ => throw new NotSupportedException(), 
			};
			data.Data[_dataIndexOutput] = num3;
		}

		public override void SaveXml(XElement xml)
		{
			base.SaveXml(xml);
			xml.SetAttributeValue("dataIndexInputA", _dataIndexInputA);
			xml.SetAttributeValue("dataIndexInputB", _dataIndexInputB);
			xml.SetAttributeValue("constantValueInputC", _constantValueC);
			xml.SetAttributeValue("dataIndexOutput", _dataIndexOutput);
			xml.SetAttributeValue("arithmeticType", _arithmeticType);
		}

		protected override void RestoreXml(XElement xml)
		{
			base.RestoreXml(xml);
			_dataIndexInputA = (int)xml.Attribute("dataIndexInputA");
			_dataIndexInputB = (int)xml.Attribute("dataIndexInputB");
			_constantValueC = (float)xml.Attribute("constantValueInputC");
			_dataIndexOutput = (int)xml.Attribute("dataIndexOutput");
			_arithmeticType = (BasicArithmeticType)Enum.Parse(typeof(BasicArithmeticType), (string)xml.Attribute("arithmeticType"), ignoreCase: true);
		}
	}
}
