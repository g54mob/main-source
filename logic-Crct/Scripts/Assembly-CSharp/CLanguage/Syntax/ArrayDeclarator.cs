namespace CLanguage.Syntax
{
	public class ArrayDeclarator : Declarator
	{
		public Expression? LengthExpression { get; set; }

		public TypeQualifiers TypeQualifiers { get; set; }

		public bool LengthIsStatic { get; set; }

		public override string DeclaredIdentifier => null;

		public ArrayDeclarator(Declarator? innerDeclarator, Expression? length)
			: base(null)
		{
		}
	}
}
