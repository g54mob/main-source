using System;

[AttributeUsage(AttributeTargets.Interface)]
internal class PXswZWAwFNIhJrjZJVhTagsuPZR : Attribute
{
	private Type AWcphbECLXSDuzkiuvAipbXrUPe;

	public Type Type => AWcphbECLXSDuzkiuvAipbXrUPe;

	public PXswZWAwFNIhJrjZJVhTagsuPZR(Type typeOfTheAssociatedShadow)
	{
		AWcphbECLXSDuzkiuvAipbXrUPe = typeOfTheAssociatedShadow;
	}

	public static PXswZWAwFNIhJrjZJVhTagsuPZR IzmYoCantdlEDbvheGAmRxNbwRb(Type P_0)
	{
		object[] customAttributes = P_0.GetCustomAttributes(typeof(PXswZWAwFNIhJrjZJVhTagsuPZR), inherit: false);
		if (customAttributes.Length == 0)
		{
			return null;
		}
		return (PXswZWAwFNIhJrjZJVhTagsuPZR)customAttributes[0];
	}
}
