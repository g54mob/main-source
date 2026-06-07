using System;
using System.Reflection;
using System.Xml.Linq;
using ModApi.Common.Extensions;
using ModApi.Craft;
using ModApi.Expressions;
using UnityEngine;

namespace Assets.Scripts.Career.Contracts.Requirements
{
	public class ExpressionRequirement : ContractRequirement
	{
		private Func<double> _compiledDisplayFunction;

		private Func<bool> _compiledFunction;

		private string _displayFormat;

		private string _displayValue;

		public string DisplayExpression { get; private set; }

		public override string DisplayValue => _displayValue;

		public double DisplayValueResult { get; private set; }

		public string Expression { get; private set; }

		public bool RequiresPlayerCraft { get; protected set; } = true;

		public ExpressionRequirement(XElement xml, Contract contract)
			: base(xml, contract)
		{
			Expression = CareerUtilities.GetExpressionString(xml, "expression");
			DisplayExpression = CareerUtilities.GetExpressionString(xml, "displayExpression");
			_displayFormat = xml.GetStringAttribute("displayFormat");
			DisplayValueResult = xml.GetDoubleAttribute("displayValue");
		}

		public override void OnFlightEnd()
		{
			base.OnFlightEnd();
			_compiledFunction = null;
			_compiledDisplayFunction = null;
		}

		public override void OnFlightStart(IFlightContext flight)
		{
			base.OnFlightStart(flight);
			CompileExpressions();
		}

		public override void OnTheFlyUpdateFromTargetRequirement(ContractRequirement target)
		{
			base.OnTheFlyUpdateFromTargetRequirement(target);
			if (target is ExpressionRequirement expressionRequirement)
			{
				Expression = expressionRequirement.Expression;
				DisplayExpression = expressionRequirement.DisplayExpression;
				_displayFormat = expressionRequirement._displayFormat;
				CompileExpressions();
			}
		}

		public override void SaveStatusToXml()
		{
			base.SaveStatusToXml();
			base.Xml.SetAttributeValue("displayValue", DisplayValueResult);
		}

		public override void Validate(ValidationResult result)
		{
			base.Validate(result);
		}

		protected override bool Evaluate(ICraftNode craftNode)
		{
			if (RequiresPlayerCraft && craftNode != base.FlightContext.CraftNode)
			{
				Debug.LogError("Contract '" + base.Contract.Id + "' is attempting to use an Expression requirement with a non-player craft.");
			}
			if (_compiledFunction != null)
			{
				if (_compiledDisplayFunction != null)
				{
					DisplayValueResult = _compiledDisplayFunction();
					_displayValue = StringProcessor.FormatDouble(DisplayValueResult, _displayFormat);
				}
				return _compiledFunction();
			}
			return false;
		}

		protected virtual Context GenerateContext(IFlightContext flight)
		{
			return new Context(true, (typeof(IFlightContext), flight, null, true));
		}

		protected override void ResetRequirementStatus()
		{
			base.ResetRequirementStatus();
			DisplayValueResult = 0.0;
		}

		private void CompileExpressions()
		{
			try
			{
				Context ctx = GenerateContext(base.FlightContext);
				CompileExpressions(ctx);
			}
			catch (Exception arg)
			{
				Debug.LogError($"Contract expression requirement error: {Expression}\n{arg}");
			}
		}

		private void CompileExpressions(Context ctx)
		{
			PropertyInfo property = GetType().GetProperty("DisplayValueResult");
			ctx.AddVariable("displayValue", property.GetGetMethod(), this);
			_compiledFunction = Parser.Process<bool>(Expression, ctx);
			if (!string.IsNullOrWhiteSpace(DisplayExpression))
			{
				_compiledDisplayFunction = Parser.Process<double>(DisplayExpression, ctx);
			}
		}
	}
}
