using System;

internal interface NnyryXwgsxSePquOWBGwHPnTRUR : IDisposable
{
	IntPtr Handle { get; }

	bool IsOpen { get; }

	bool IsConnected { get; }

	string Description { get; }

	EaCZIVHHHPGnTzzCxqofnwQuoci Capabilities { get; }

	uykYJAKUGVkseuhrDuBKJAPjaeH Attributes { get; }

	string DevicePath { get; }

	bool MonitorDeviceEvents { get; set; }

	event MzxMFUkwPjfyHuneOTaoDcbjtcl Inserted;

	event JRXLyYHnOwbKkKHFlsArAwtiYrr Removed;

	void OpenDevice();

	void OpenDevice(dzJSyaujfBAKrLjAEgXlxqFRAJs P_0, dzJSyaujfBAKrLjAEgXlxqFRAJs P_1, ubjwsWWWsVegtjdmbBZpanWemFc P_2);

	void CloseDevice();

	HgGLQtrCokhwjfGTXVIAhJMhlgpp Read();

	void Read(JaLFpUVPHDVVuPEQLelUrEqDjRk P_0);

	HgGLQtrCokhwjfGTXVIAhJMhlgpp Read(int P_0);

	void ReadReport(hsTrWHgGbnrXCqBpBvjsoIUTFdu P_0);

	ukYprmKfFngkKqebMFvpAgNClgzX ReadReport(int P_0);

	ukYprmKfFngkKqebMFvpAgNClgzX ReadReport();

	bool ReadFeatureData(out byte[] P_0, byte P_1 = 0);

	string ReadProductName();

	bool ReadProductName(out byte[] P_0);

	string ReadManufacturer();

	bool ReadManufacturer(out byte[] P_0);

	string ReadSerialNumber();

	bool ReadSerialNumber(out byte[] P_0);

	string ReadPhysicalDescriptor();

	bool ReadPhysicalDescriptor(out byte[] P_0);

	void Write(byte[] P_0, CdMxQBSNTkEhaphIlOukTkPXGEUi P_1);

	bool Write(byte[] P_0);

	bool Write(byte[] P_0, int P_1);

	void WriteReport(ukYprmKfFngkKqebMFvpAgNClgzX P_0, CdMxQBSNTkEhaphIlOukTkPXGEUi P_1);

	bool WriteReport(ukYprmKfFngkKqebMFvpAgNClgzX P_0);

	bool WriteReport(ukYprmKfFngkKqebMFvpAgNClgzX P_0, int P_1);

	ukYprmKfFngkKqebMFvpAgNClgzX CreateReport();

	bool WriteFeatureData(byte[] P_0);
}
