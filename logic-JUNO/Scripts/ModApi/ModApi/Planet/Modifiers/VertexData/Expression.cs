using System;
using System.Collections.Generic;
using System.Reflection;
using System.Xml.Linq;
using ModApi.Expressions;
using ModApi.Planet.Modifiers.Attributes;
using ModApi.Ui.Inspector;
using UnityEngine;

namespace ModApi.Planet.Modifiers.VertexData
{
	[PlanetModifierInfo("Expression", "A planet modifier used to evaluate an expression and store the result in a data output. Expressions can read one or more data inputs using the [] characters and specifing a value representing the number of the data input. Expressions can perform many basic mathematical operations such as addition, subtraction, mulitplication, division, etc. They can also be used to perform other sorts of operations such as min, max, absolute value, sin/cos/tan, etc. Expressions can be great at reducing the number of planet modifiers it takes to manipulate data values. \n\nExample expression to add inputs 0 and 1 and then get the max of the absolute values of that and input 3: max(abs([0] + [1]), abs([3]))")]
	public class Expression : VertexDataCommonPassPlanetModifier, IDataSlotConfiguration, ICustomObjectInspectorModel
	{
		[Serializable]
		private class ExpressionInput
		{
			[SerializeField]
			public int DataIndex;

			internal static FieldInfo _DataIndexFieldInfo = typeof(ExpressionInput).GetField("DataIndex", BindingFlags.Instance | BindingFlags.Public);
		}

		private static Context _context;

		private static FieldInfo _outputField = typeof(Expression).GetField("_dataIndexOutput", BindingFlags.Instance | BindingFlags.NonPublic);

		private Func<double[], double> _compiled;

		private string _compiledSource;

		private Exception _compileException;

		private string _compileStatus = string.Empty;

		private List<DataSlotField> _customDataSlotFields = new List<DataSlotField>();

		[SerializeField]
		[Range(0f, 9f)]
		[DataSlot(DataSlotType.Output, "Output", false, true, Tooltip = "The data output of the expression.")]
		private int _dataIndexOutput;

		[SerializeField]
		private string _expression = "0";

		private DataSlotField _outputDataSlotField;

		private List<int> _usedDataIndices = new List<int>();

		public bool CreateGroup => false;

		public override VertexDataType VertexDataType => VertexDataType.Both;

		public void CreateModel(GroupModel model, IObjectInspector objectInspector)
		{
			TextInputModel textInputModel = new TextInputModel("Expression", () => _expression);
			textInputModel.ValueSetter = delegate(string exp)
			{
				_expression = exp ?? string.Empty;
				CompileIfNecessary();
				(objectInspector as ITerrainModifierInspector)?.UpdateVisualization(GetDataSlots);
			};
			textInputModel.Tooltip = "The expression to be evaluated.";
			model.Add(textInputModel);
			model.Add(new TextModel("Status", () => _compileStatus));
		}

		public void GetDataSlots(List<DataSlotField> dataSlots)
		{
			CompileIfNecessary();
			dataSlots.Add(_outputDataSlotField);
			dataSlots.AddRange(_customDataSlotFields);
		}

		public override void GetVertexData(PlanetVertexDataInput input, PlanetVertexData data)
		{
			data.Data[_dataIndexOutput] = _compiled(data.Data);
		}

		public override void GetVertexData(PlanetVertexDataInput input, PlanetBiomeVertexData data)
		{
			data.Data[_dataIndexOutput] = _compiled(data.Data);
		}

		public override void Initialize(IPlanetData planetData)
		{
			CompileIfNecessary();
			if (_compileException != null)
			{
				throw _compileException;
			}
		}

		public override void SaveXml(XElement xml)
		{
			base.SaveXml(xml);
			xml.SetAttributeValue("expression", _expression);
			xml.SetAttributeValue("dataIndexOutput", _dataIndexOutput);
		}

		protected override void RestoreXml(XElement xml)
		{
			base.RestoreXml(xml);
			_expression = (string)xml.Attribute("expression");
			_dataIndexOutput = (int)xml.Attribute("dataIndexOutput");
		}

		private bool CompileIfNecessary()
		{
			if (_compiledSource != _expression && _expression != null)
			{
				_context = _context ?? new Context();
				_context.EnableMemory = false;
				_usedDataIndices.Clear();
				_customDataSlotFields.Clear();
				_compiledSource = _expression;
				_compileException = null;
				_compileStatus = "OK.";
				try
				{
					_compiled = Parser.Process<double>(_expression, _context, _usedDataIndices);
				}
				catch (Exception compileException)
				{
					_compileException = compileException;
					_compileStatus = _compileException.Message;
				}
				foreach (int usedDataIndex in _usedDataIndices)
				{
					_customDataSlotFields.Add(new DataSlotField(new ExpressionInput
					{
						DataIndex = usedDataIndex
					}, new DataSlotAttribute(DataSlotType.Input, $"[{usedDataIndex}]", optional: false, userEditable: false), ExpressionInput._DataIndexFieldInfo));
				}
				_outputDataSlotField = new DataSlotField(this, new DataSlotAttribute(DataSlotType.Output, "Output"), _outputField);
				return true;
			}
			return false;
		}
	}
}
