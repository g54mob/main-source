using System;

namespace VampireSurvivors.App.Scripts.Framework.Platforms.Backend.Exceptions;

public class NotAuthenticatedException : Exception
{
	public NotAuthenticatedException()
		: base("Operation not permitted whilst not logged in.")
	{
	}
}
