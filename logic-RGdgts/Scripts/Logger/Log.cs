using System;

public static class Log
{
	public static void Info<ORIGIN>(string text) where ORIGIN : ILogOrigin
	{
	}

	public static void Warning<ORIGIN>(string text) where ORIGIN : ILogOrigin
	{
	}

	public static void Error<ORIGIN>(string text) where ORIGIN : ILogOrigin
	{
	}

	public static void Exception<ORIGIN>(string text, Exception exception) where ORIGIN : ILogOrigin
	{
	}
}
