public class ConsoleMessage
{
	public const ConsoleMessageType DEFAULT_TYPE = ConsoleMessageType.Info;

	public const ConsoleMessageFormat DEFAULT_FORMAT = ConsoleMessageFormat.Normal;

	public string Message { get; set; }

	public ConsoleMessageType Type { get; set; }

	public ConsoleMessageFormat Format { get; set; }

	public ConsoleMessage(string message, ConsoleMessageType type)
		: this(message, type, ConsoleMessageFormat.Normal)
	{
	}

	public ConsoleMessage(string message, ConsoleMessageType type, ConsoleMessageFormat format)
	{
		Message = message;
		Type = type;
		Format = format;
	}

	public ConsoleMessage(string message, string typeString, string formatString)
	{
		Message = message;
		Type = CommonMethods.GetEnumFromString(typeString, ConsoleMessageType.Info);
		Format = CommonMethods.GetEnumFromString(formatString, ConsoleMessageFormat.Normal);
	}
}
