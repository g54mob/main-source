using System.Xml.Serialization;

namespace Origin.Data
{
	public enum BroadcastStateT
	{
		[XmlEnum("DIALOG_OPEN")]
		DIALOG_OPEN = 0,
		[XmlEnum("DIALOG_CLOSED")]
		DIALOG_CLOSED = 1,
		[XmlEnum("ACCOUNTLINKDIALOG_OPEN")]
		ACCOUNTLINKDIALOG_OPEN = 2,
		[XmlEnum("ACCOUNT_DISCONNECTED")]
		ACCOUNT_DISCONNECTED = 3,
		[XmlEnum("STARTED")]
		STARTED = 4,
		[XmlEnum("STOPPED")]
		STOPPED = 5,
		[XmlEnum("BLOCKED")]
		BLOCKED = 6,
		[XmlEnum("START_PENDING")]
		START_PENDING = 7,
		[XmlEnum("ERROR")]
		ERROR = 8
	}
}
