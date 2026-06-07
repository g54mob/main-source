using System.Collections.Generic;
using ModApi.Craft.Program;
using UnityEngine;

namespace Assets.Scripts.Vizzy.UI.Elements
{
	public class ExpressionElementScript : BlockElementScript
	{
		public ProgramExpression Expression { get; private set; }

		public ExpressionSlotElementScript ExpressionSlot => GetComponentInParent<ExpressionSlotElementScript>();

		public override void Destroy()
		{
			RemoveFromExpressionSlot();
			base.Destroy();
		}

		public override void Initialize(IVizzyUI vizzyUI, ProgramNode node, string style)
		{
			base.Initialize(vizzyUI, node, style);
			Expression = node as ProgramExpression;
			ConnectionPointType connectionPointType = (Expression.IsBoolean ? ConnectionPointType.BoolExpression : ConnectionPointType.TextExpression);
			base.ConnectionPoints.Add(new ConnectionPoint(this, connectionPointType, Vector2.zero));
			base.ConnectionPoints[0].CanSeek = true;
			base.ConnectionPoints[0].CanReceive = Expression.CanReplaceInUI;
			base.DragBehavior = DragBehaviorType.Move;
		}

		public override void OnUserConnected(ConnectionPoint thisConnection, ConnectionPoint targetConnection)
		{
			ExpressionSlotElementScript expressionSlot = (targetConnection.Block as ExpressionElementScript).ExpressionSlot;
			if (expressionSlot != null)
			{
				expressionSlot.ReplaceExpression(Expression);
				Destroy();
			}
		}

		public override void PreviewConnection(ConnectionPoint connectionPoint)
		{
			base.PreviewConnection(connectionPoint);
			if (connectionPoint != null)
			{
				base.VisualState = VisualStateType.Brighter3;
			}
			else
			{
				base.VisualState = VisualStateType.Normal;
			}
		}

		public void RemoveFromExpressionSlot()
		{
			ExpressionSlotElementScript componentInParent = GetComponentInParent<ExpressionSlotElementScript>();
			if (componentInParent != null)
			{
				componentInParent.Reset();
			}
		}

		protected override List<BlockElementScript> DragBegin()
		{
			RemoveFromExpressionSlot();
			return base.DragBegin();
		}
	}
}
