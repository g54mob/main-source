using System;
using InControl;

[Serializable]
public class CommandMapping
{
	public ControlCommand command;

	public Key customKeyMapping;

	public Mouse customMouseMapping;

	public InputControlType customControllerMapping;

	public bool keyMappingCleared;

	public bool mouseMappingCleared;

	public bool controllerMappingCleared;
}
