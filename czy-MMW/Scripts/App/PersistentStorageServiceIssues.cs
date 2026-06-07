using System;

[Flags]
public enum PersistentStorageServiceIssues
{
	None = 0,
	NotAuthenticated = 2,
	NotAvailable = 4,
	RecentUnauthenticatedData = 8,
	AuthenticatedButOtherUsersiCloudData = 0x10,
	QuotaExceeded = 0x20
}
