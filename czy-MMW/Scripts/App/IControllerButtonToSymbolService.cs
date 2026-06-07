public interface IControllerButtonToSymbolService
{
	bool HasMappings { get; }

	string GetTextMeshProSymbolTextForControllerButton(ControllerButton buttonType);
}
