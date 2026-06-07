using System.Xml.Linq;
using ModApi.Common.Extensions;

namespace ModApi.Craft.Program
{
	public abstract class ProgramExpression : ProgramNode
	{
		public bool CanReplaceInUI { get; set; } = true;

		public abstract bool IsBoolean { get; }

		public ProgramExpression()
		{
		}

		public abstract ExpressionResult Evaluate(IThreadContext context);

		public override void OnDeserialized(XElement xml)
		{
			base.OnDeserialized(xml);
			CanReplaceInUI = xml.GetBoolAttribute("canReplace", defaultValue: true);
		}

		public override void OnSerialized(XElement xml)
		{
			base.OnSerialized(xml);
			if (!CanReplaceInUI)
			{
				xml.SetAttributeValue("canReplace", false);
			}
		}
	}
}
