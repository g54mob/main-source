namespace XGamingRuntime.Interop
{
	internal struct NativeBool
	{
		private byte value;

		internal bool Value => value != 0;

		internal NativeBool(bool value)
		{
			this.value = (byte)(value ? 1u : 0u);
		}
	}
}
