using System;

internal interface DHWnNpDFmdbjWxSotOMmAjnxIWX : IDisposable
{
	IntPtr Handle { get; }

	bool IsOpen { get; }

	bool IsConnected { get; }

	string Description { get; }

	WRmWIdgRNTmJYmlFGkqlcOyQAuac Capabilities { get; }

	atMUBsjqMZcztvgByyqIWUONwcH Attributes { get; }

	string DevicePath { get; }

	bool MonitorDeviceEvents { get; set; }

	event CVZaCqDOTpbbCvnGjtgsWvbZvoz Inserted;

	event NGxEWsoDQchsffJtOvulqVzQfUzs Removed;

	void OpenDevice();

	void OpenDevice(rTzbEMDvKHZoPAqwvPfaoLyrXgi P_0, rTzbEMDvKHZoPAqwvPfaoLyrXgi P_1, utFNrkhqcRYjcoBIIPDdjrIEcTu P_2);

	void CloseDevice();

	VOwBPRSIcgMbwNNxsMOAWsKZwrz Read();

	void Read(ZsrhWscIBTTQvYkimImKbqahmXwy P_0);

	VOwBPRSIcgMbwNNxsMOAWsKZwrz Read(int P_0);

	void ReadReport(lhrcwhENCtysZszruincwhYnpPmg P_0);

	cIsqeClJDjClFdJDnHdnzuXgkan ReadReport(int P_0);

	cIsqeClJDjClFdJDnHdnzuXgkan ReadReport();

	bool ReadFeatureData(out byte[] P_0, byte P_1 = 0);

	string ReadProductName();

	bool ReadProductName(out byte[] P_0);

	string ReadManufacturer();

	bool ReadManufacturer(out byte[] P_0);

	string ReadSerialNumber();

	bool ReadSerialNumber(out byte[] P_0);

	string ReadPhysicalDescriptor();

	bool ReadPhysicalDescriptor(out byte[] P_0);

	void Write(byte[] P_0, GkgTxnlHJswlBwyCGeckGLbbQIG P_1);

	bool Write(byte[] P_0);

	bool Write(byte[] P_0, int P_1);

	void WriteReport(cIsqeClJDjClFdJDnHdnzuXgkan P_0, GkgTxnlHJswlBwyCGeckGLbbQIG P_1);

	bool WriteReport(cIsqeClJDjClFdJDnHdnzuXgkan P_0);

	bool WriteReport(cIsqeClJDjClFdJDnHdnzuXgkan P_0, int P_1);

	cIsqeClJDjClFdJDnHdnzuXgkan CreateReport();

	bool WriteFeatureData(byte[] P_0);
}
