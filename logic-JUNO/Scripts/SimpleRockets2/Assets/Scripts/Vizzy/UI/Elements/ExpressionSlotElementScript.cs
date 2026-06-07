using ModApi.Craft.Program;
using ModApi.Craft.Program.Expressions;
using UnityEngine;

namespace Assets.Scripts.Vizzy.UI.Elements
{
	public class ExpressionSlotElementScript : BlockElementScript
	{
		private string _lastText = string.Empty;

		private NodeBuilderScript _nodeBuilder;

		public BlockElementScript ExpressionElement { get; private set; }

		public NodeFormat.Token Token { get; private set; }

		public void InitializeExpression(NodeFormat.Token token, NodeBuilderScript nodeBuilderScript)
		{
			Token = token;
			_nodeBuilder = nodeBuilderScript;
			ProgramExpression expression = base.Node.GetExpression(Token.ExpressionIndex);
			BuildExpression(expression);
		}

		public void ReplaceExpression(ProgramExpression expression)
		{
			BlockElementScript expressionElement = ExpressionElement;
			BlockElementScript root = base.Root;
			if (root != null)
			{
				Vector2 screenPoint = RectTransformUtility.WorldToScreenPoint(base.VizzyUI.Camera, root.RectTransform.position);
				RectTransformUtility.ScreenPointToLocalPointInRectangle(expressionElement.RectTransform, screenPoint, base.VizzyUI.Camera, out var localPoint);
				localPoint.x -= base.Size.x + 10f;
				localPoint.y = base.RectTransform.localPosition.y;
				base.RectTransform.localPosition = localPoint;
			}
			if (expressionElement?.Node is ConstantExpression { IsBoolean: false } constantExpression)
			{
				_lastText = constantExpression.ExpressionResult.TextValue;
			}
			else
			{
				_lastText = string.Empty;
			}
			RemoveChild(expressionElement);
			if (expressionElement.DragBehavior == DragBehaviorType.Disabled)
			{
				expressionElement.Destroy();
			}
			base.Node.SetExpression(Token.ExpressionIndex, expression);
			if (base.Parent.Style.HasDynamicExpressionsSlots)
			{
				_nodeBuilder.RebuildChildren(base.Parent);
				return;
			}
			BuildExpression(expression);
			OnChildSizeChanged();
		}

		public void Reset()
		{
			RemoveChild(ExpressionElement);
			ProgramExpression programExpression = null;
			programExpression = ((Token.TokenType != NodeFormat.TokenType.Boolean) ? new ConstantExpression(_lastText) : new ConstantExpression(value: false));
			base.Node.SetExpression(Token.ExpressionIndex, programExpression);
			if (base.Parent.Style.HasDynamicExpressionsSlots)
			{
				_nodeBuilder.RebuildChildren(base.Parent);
				return;
			}
			BuildExpression(programExpression);
			OnChildSizeChanged();
		}

		private void BuildExpression(ProgramExpression expression)
		{
			ExpressionElementScript expressionElementScript = _nodeBuilder.BuildExpressionElement(expression, Token);
			AddChild(expressionElementScript);
			ExpressionElement = expressionElementScript;
		}
	}
}
