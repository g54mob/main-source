using System;

[AttributeUsage(AttributeTargets.Interface)]
internal class gPvceyazwGaQXlOwoYjjMXWIbJRKA : Attribute
{
	private Type tonAlHhbXWnPmKdRFrwQZilNSJcR;

	public Type fIOegccOCicVLevenXOIwaeUcNZY => tonAlHhbXWnPmKdRFrwQZilNSJcR;

	public gPvceyazwGaQXlOwoYjjMXWIbJRKA(Type P_0)
	{
		tonAlHhbXWnPmKdRFrwQZilNSJcR = P_0;
	}

	public static gPvceyazwGaQXlOwoYjjMXWIbJRKA jBeadTndiITwAWHVgGNrnfDNGje(Type P_0)
	{
		object[] customAttributes = P_0.GetCustomAttributes(typeof(gPvceyazwGaQXlOwoYjjMXWIbJRKA), inherit: false);
		if (customAttributes.Length == 0)
		{
			return null;
		}
		return (gPvceyazwGaQXlOwoYjjMXWIbJRKA)customAttributes[0];
	}
}
