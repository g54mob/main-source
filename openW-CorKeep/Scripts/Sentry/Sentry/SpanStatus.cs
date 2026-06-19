namespace Sentry
{
	public enum SpanStatus
	{
		Ok = 0,
		DeadlineExceeded = 1,
		Unauthenticated = 2,
		PermissionDenied = 3,
		NotFound = 4,
		ResourceExhausted = 5,
		InvalidArgument = 6,
		Unimplemented = 7,
		Unavailable = 8,
		InternalError = 9,
		UnknownError = 10,
		Cancelled = 11,
		AlreadyExists = 12,
		FailedPrecondition = 13,
		Aborted = 14,
		OutOfRange = 15,
		DataLoss = 16
	}
}
