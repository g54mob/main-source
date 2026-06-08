namespace HandlebarsDotNet.Compiler
{
	internal enum HandlebarsExpressionType
	{
		StaticExpression = 6000,
		StatementExpression = 6001,
		BlockExpression = 6002,
		HelperExpression = 6003,
		PathExpression = 6004,
		IteratorExpression = 6005,
		PartialExpression = 6007,
		BoolishExpression = 6008,
		SubExpression = 6009,
		HashParameterAssignmentExpression = 6010,
		HashParametersExpression = 6011,
		CommentExpression = 6012,
		BlockParamsExpression = 6013
	}
}
