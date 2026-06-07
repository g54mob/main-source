using System;
using System.Globalization;
using Rewired.Libraries.SharpDX;

internal class PQfDifZXOUFRqvqrEtvLLzUnIdC : Exception
{
	private ResultDescriptor MObnQMCKxOAKjHeoJjkJIxRTTyx;

	public jYVOPQCYHiqgKMeoByaWkMeLSnl ResultCode
	{
		get
		{
			return MObnQMCKxOAKjHeoJjkJIxRTTyx.Result;
		}
	}

	public ResultDescriptor Descriptor
	{
		get
		{
			return MObnQMCKxOAKjHeoJjkJIxRTTyx;
		}
	}

	public PQfDifZXOUFRqvqrEtvLLzUnIdC()
		: base("A SharpDX exception occurred.")
	{
		MObnQMCKxOAKjHeoJjkJIxRTTyx = ResultDescriptor.Find(jYVOPQCYHiqgKMeoByaWkMeLSnl.ectEHhOaZjPumSaECnijEeuBhis);
		base.HResult = (int)jYVOPQCYHiqgKMeoByaWkMeLSnl.ectEHhOaZjPumSaECnijEeuBhis;
	}

	public PQfDifZXOUFRqvqrEtvLLzUnIdC(jYVOPQCYHiqgKMeoByaWkMeLSnl result)
		: this(ResultDescriptor.Find(result))
	{
		base.HResult = (int)result;
	}

	public PQfDifZXOUFRqvqrEtvLLzUnIdC(ResultDescriptor descriptor)
		: base(descriptor.ToString())
	{
		MObnQMCKxOAKjHeoJjkJIxRTTyx = descriptor;
		base.HResult = (int)descriptor.Result;
	}

	public PQfDifZXOUFRqvqrEtvLLzUnIdC(jYVOPQCYHiqgKMeoByaWkMeLSnl result, string message)
		: base(message)
	{
		MObnQMCKxOAKjHeoJjkJIxRTTyx = ResultDescriptor.Find(result);
		base.HResult = (int)result;
	}

	public PQfDifZXOUFRqvqrEtvLLzUnIdC(jYVOPQCYHiqgKMeoByaWkMeLSnl result, string message, params object[] args)
		: base(string.Format(CultureInfo.InvariantCulture, message, args))
	{
		MObnQMCKxOAKjHeoJjkJIxRTTyx = ResultDescriptor.Find(result);
		base.HResult = (int)result;
	}

	public PQfDifZXOUFRqvqrEtvLLzUnIdC(string message, params object[] args)
		: this(jYVOPQCYHiqgKMeoByaWkMeLSnl.ectEHhOaZjPumSaECnijEeuBhis, message, args)
	{
	}

	public PQfDifZXOUFRqvqrEtvLLzUnIdC(string message, Exception innerException, params object[] args)
		: base(string.Format(CultureInfo.InvariantCulture, message, args), innerException)
	{
		MObnQMCKxOAKjHeoJjkJIxRTTyx = ResultDescriptor.Find(jYVOPQCYHiqgKMeoByaWkMeLSnl.ectEHhOaZjPumSaECnijEeuBhis);
		base.HResult = (int)jYVOPQCYHiqgKMeoByaWkMeLSnl.ectEHhOaZjPumSaECnijEeuBhis;
	}
}
