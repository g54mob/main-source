using ModApi.Craft.Program;
using ModApi.Craft.Program.Expressions;

namespace Assets.Scripts.Vizzy.UI.Elements
{
	public class CustomExpressionElementScript : ExpressionElementScript
	{
		public override void Initialize(IVizzyUI vizzyUI, ProgramNode node, string style)
		{
			base.Initialize(vizzyUI, node, style);
			base.ConnectionPoints[0].CanSeek = false;
			base.ConnectionPoints[0].CanReceive = false;
			base.DragBehavior = DragBehaviorType.Move;
			CustomExpression customExpression = node as CustomExpression;
			base.Format = customExpression.Format;
		}
	}
}
