using System;
using System.Globalization;
using Rewired.Libraries.SharpDX;

internal class UZoVbIaOogHmZeqpNxyDpZtVVpuI : Exception
{
	private ResultDescriptor HZuDLhitVeIfWtEuOJlVphkjhqDf;

	public oAEDXrvvcKPxxNzmMhHOiHFnkWH ResultCode => HZuDLhitVeIfWtEuOJlVphkjhqDf.Result;

	public ResultDescriptor Descriptor => HZuDLhitVeIfWtEuOJlVphkjhqDf;

	public UZoVbIaOogHmZeqpNxyDpZtVVpuI()
		: base("A SharpDX exception occurred.")
	{
		HZuDLhitVeIfWtEuOJlVphkjhqDf = ResultDescriptor.Find(oAEDXrvvcKPxxNzmMhHOiHFnkWH.vWgFbujGWXDgBTeePBkfdYVhafYL);
		base.HResult = (int)oAEDXrvvcKPxxNzmMhHOiHFnkWH.vWgFbujGWXDgBTeePBkfdYVhafYL;
	}

	public UZoVbIaOogHmZeqpNxyDpZtVVpuI(oAEDXrvvcKPxxNzmMhHOiHFnkWH result)
		: this(ResultDescriptor.Find(result))
	{
		base.HResult = (int)result;
	}

	public UZoVbIaOogHmZeqpNxyDpZtVVpuI(ResultDescriptor descriptor)
		: base(descriptor.ToString())
	{
		HZuDLhitVeIfWtEuOJlVphkjhqDf = descriptor;
		base.HResult = (int)descriptor.Result;
	}

	public UZoVbIaOogHmZeqpNxyDpZtVVpuI(oAEDXrvvcKPxxNzmMhHOiHFnkWH result, string message)
		: base(message)
	{
		HZuDLhitVeIfWtEuOJlVphkjhqDf = ResultDescriptor.Find(result);
		base.HResult = (int)result;
	}

	public UZoVbIaOogHmZeqpNxyDpZtVVpuI(oAEDXrvvcKPxxNzmMhHOiHFnkWH result, string message, params object[] args)
		: base(string.Format(CultureInfo.InvariantCulture, message, args))
	{
		HZuDLhitVeIfWtEuOJlVphkjhqDf = ResultDescriptor.Find(result);
		base.HResult = (int)result;
	}

	public UZoVbIaOogHmZeqpNxyDpZtVVpuI(string message, params object[] args)
		: this(oAEDXrvvcKPxxNzmMhHOiHFnkWH.vWgFbujGWXDgBTeePBkfdYVhafYL, message, args)
	{
	}

	public UZoVbIaOogHmZeqpNxyDpZtVVpuI(string message, Exception innerException, params object[] args)
		: base(string.Format(CultureInfo.InvariantCulture, message, args), innerException)
	{
		HZuDLhitVeIfWtEuOJlVphkjhqDf = ResultDescriptor.Find(oAEDXrvvcKPxxNzmMhHOiHFnkWH.vWgFbujGWXDgBTeePBkfdYVhafYL);
		base.HResult = (int)oAEDXrvvcKPxxNzmMhHOiHFnkWH.vWgFbujGWXDgBTeePBkfdYVhafYL;
	}
}
