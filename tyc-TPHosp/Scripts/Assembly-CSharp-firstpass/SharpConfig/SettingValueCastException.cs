using System;

namespace SharpConfig
{
	[Serializable]
	public sealed class SettingValueCastException : Exception
	{
		private SettingValueCastException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		internal static SettingValueCastException Create(string stringValue, Type dstType, Exception innerException)
		{
			return new SettingValueCastException($"Failed to convert value '{stringValue}' to type {dstType.FullName}.", innerException);
		}

		internal static SettingValueCastException CreateBecauseConverterMissing(string stringValue, Type dstType)
		{
			string message = $"Failed to convert value '{stringValue}' to type {dstType.FullName}; no converter for this type is registered.";
			NotImplementedException innerException = new NotImplementedException("no converter for this type is registered.");
			return new SettingValueCastException(message, innerException);
		}
	}
}
