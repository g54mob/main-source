using System;
using System.Globalization;

internal class CgeVuknLwxYkzYPFwGhCkZZiVyf : Exception
{
	private bOkYhrAZvLuDrbKeuEpFihavppE FgydQLfiZbYvaUcChPoEihQIgtMV;

	public cTKAHZacuViBRtnMbZwDuEpUfDCh ResultCode => FgydQLfiZbYvaUcChPoEihQIgtMV.Result;

	public bOkYhrAZvLuDrbKeuEpFihavppE Descriptor => FgydQLfiZbYvaUcChPoEihQIgtMV;

	public CgeVuknLwxYkzYPFwGhCkZZiVyf()
		: base("A SharpDX exception occurred.")
	{
		FgydQLfiZbYvaUcChPoEihQIgtMV = bOkYhrAZvLuDrbKeuEpFihavppE.PYgQmrazoUqWjrASzZcCXOaxeza(cTKAHZacuViBRtnMbZwDuEpUfDCh.zPuMcYksSQmCrdOOqfHyQttEuaN);
		base.HResult = (int)cTKAHZacuViBRtnMbZwDuEpUfDCh.zPuMcYksSQmCrdOOqfHyQttEuaN;
	}

	public CgeVuknLwxYkzYPFwGhCkZZiVyf(cTKAHZacuViBRtnMbZwDuEpUfDCh result)
		: this(bOkYhrAZvLuDrbKeuEpFihavppE.PYgQmrazoUqWjrASzZcCXOaxeza(result))
	{
		base.HResult = (int)result;
	}

	public CgeVuknLwxYkzYPFwGhCkZZiVyf(bOkYhrAZvLuDrbKeuEpFihavppE descriptor)
		: base(descriptor.ToString())
	{
		FgydQLfiZbYvaUcChPoEihQIgtMV = descriptor;
		base.HResult = (int)descriptor.Result;
	}

	public CgeVuknLwxYkzYPFwGhCkZZiVyf(cTKAHZacuViBRtnMbZwDuEpUfDCh result, string message)
		: base(message)
	{
		FgydQLfiZbYvaUcChPoEihQIgtMV = bOkYhrAZvLuDrbKeuEpFihavppE.PYgQmrazoUqWjrASzZcCXOaxeza(result);
		base.HResult = (int)result;
	}

	public CgeVuknLwxYkzYPFwGhCkZZiVyf(cTKAHZacuViBRtnMbZwDuEpUfDCh result, string message, params object[] args)
		: base(string.Format(CultureInfo.InvariantCulture, message, args))
	{
		FgydQLfiZbYvaUcChPoEihQIgtMV = bOkYhrAZvLuDrbKeuEpFihavppE.PYgQmrazoUqWjrASzZcCXOaxeza(result);
		base.HResult = (int)result;
	}

	public CgeVuknLwxYkzYPFwGhCkZZiVyf(string message, params object[] args)
		: this(cTKAHZacuViBRtnMbZwDuEpUfDCh.zPuMcYksSQmCrdOOqfHyQttEuaN, message, args)
	{
	}

	public CgeVuknLwxYkzYPFwGhCkZZiVyf(string message, Exception innerException, params object[] args)
		: base(string.Format(CultureInfo.InvariantCulture, message, args), innerException)
	{
		FgydQLfiZbYvaUcChPoEihQIgtMV = bOkYhrAZvLuDrbKeuEpFihavppE.PYgQmrazoUqWjrASzZcCXOaxeza(cTKAHZacuViBRtnMbZwDuEpUfDCh.zPuMcYksSQmCrdOOqfHyQttEuaN);
		base.HResult = (int)cTKAHZacuViBRtnMbZwDuEpUfDCh.zPuMcYksSQmCrdOOqfHyQttEuaN;
	}
}
