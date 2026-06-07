namespace XGamingRuntime.Interop
{
	internal struct NativeBool
	{
		private byte value;

		internal bool Value => false;

		internal NativeBool(bool value)
		{
			this.value = 0;
		}
	}
}
