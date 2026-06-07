public interface IInGameDevToolEnumParameter
{
	InGameDevToolParameterType TypeOfParameter { get; }

	string ParameterName { get; }

	string ParameterSerializationValue { get; }

	string ParameterSerializationDefaultValue { get; }

	string ModelParameterFieldName { get; }

	string ParameterEditorDisplayName { get; }

	string ParameterEditorTooltip { get; }

	bool ShouldSetValueOnField { get; }

	void UpdateParameterValueFromModelField<ModelType>(ModelType modelInstance);

	void UpdateModelFieldFromParameterValue<ModelType>(ModelType modelInstance);
}
