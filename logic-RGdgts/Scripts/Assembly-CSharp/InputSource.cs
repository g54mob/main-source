public struct InputSource
{
	public ModuleId moduleId;

	public InputBinding binding;

	public static InputSource None;

	public InputSource(ModuleId moduleId, string name, InputBinding.Direction direction)
	{
		this.moduleId = default(ModuleId);
		binding = default(InputBinding);
	}

	public IInputChip GetInputChip(Gadget gadget)
	{
		return null;
	}

	public static bool operator ==(InputSource lhs, InputSource rhs)
	{
		return false;
	}

	public static bool operator !=(InputSource lhs, InputSource rhs)
	{
		return false;
	}

	public override bool Equals(object obj)
	{
		return false;
	}
}
