using System;
using System.IO;
using System.Net;
using System.Security.Authentication;

namespace Sentry
{
	internal static class SpanStatusConverter
	{
		public static SpanStatus FromException(Exception exception)
		{
			if (!(exception is TimeoutException))
			{
				if (!(exception is InvalidCredentialException))
				{
					if (!(exception is UnauthorizedAccessException))
					{
						if (!(exception is FileNotFoundException))
						{
							if (!(exception is DirectoryNotFoundException))
							{
								if (!(exception is DriveNotFoundException))
								{
									if (!(exception is ArgumentException))
									{
										if (!(exception is NotImplementedException))
										{
											if (exception is OperationCanceledException)
											{
												return SpanStatus.Cancelled;
											}
											return SpanStatus.InternalError;
										}
										return SpanStatus.Unimplemented;
									}
									return SpanStatus.InvalidArgument;
								}
								return SpanStatus.NotFound;
							}
							return SpanStatus.NotFound;
						}
						return SpanStatus.NotFound;
					}
					return SpanStatus.PermissionDenied;
				}
				return SpanStatus.PermissionDenied;
			}
			return SpanStatus.DeadlineExceeded;
		}

		public static SpanStatus FromHttpStatusCode(int code)
		{
			if (code < 500)
			{
				if (code >= 400)
				{
					return code switch
					{
						400 => SpanStatus.FailedPrecondition, 
						401 => SpanStatus.Unauthenticated, 
						403 => SpanStatus.PermissionDenied, 
						404 => SpanStatus.NotFound, 
						409 => SpanStatus.AlreadyExists, 
						429 => SpanStatus.ResourceExhausted, 
						499 => SpanStatus.Cancelled, 
						_ => SpanStatus.FailedPrecondition, 
					};
				}
				return SpanStatus.Ok;
			}
			if (code < 600)
			{
				return code switch
				{
					500 => SpanStatus.InternalError, 
					501 => SpanStatus.Unimplemented, 
					503 => SpanStatus.Unavailable, 
					504 => SpanStatus.DeadlineExceeded, 
					_ => SpanStatus.InternalError, 
				};
			}
			return SpanStatus.UnknownError;
		}

		public static SpanStatus FromHttpStatusCode(HttpStatusCode code)
		{
			return FromHttpStatusCode((int)code);
		}

		public static SpanStatus FromGrpcStatusCode(int code)
		{
			return code switch
			{
				1 => SpanStatus.Cancelled, 
				2 => SpanStatus.UnknownError, 
				3 => SpanStatus.InvalidArgument, 
				4 => SpanStatus.DeadlineExceeded, 
				5 => SpanStatus.NotFound, 
				6 => SpanStatus.AlreadyExists, 
				7 => SpanStatus.PermissionDenied, 
				8 => SpanStatus.ResourceExhausted, 
				9 => SpanStatus.FailedPrecondition, 
				10 => SpanStatus.Aborted, 
				11 => SpanStatus.OutOfRange, 
				12 => SpanStatus.Unimplemented, 
				13 => SpanStatus.InternalError, 
				14 => SpanStatus.Unavailable, 
				15 => SpanStatus.DataLoss, 
				16 => SpanStatus.Unauthenticated, 
				_ => SpanStatus.UnknownError, 
			};
		}
	}
}
