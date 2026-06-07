using UnityEngine;

public class MaterialSchematic
{
	private Properties properties;

	private PhysicMaterial physicMaterial;

	public string Id => properties.GetProperty("Id");

	public float FixationRate => properties.GetPropertyAsFloat("FixationRate");

	public float Density => properties.GetPropertyAsFloat("Density");

	public PhysicMaterial PhysicMaterial
	{
		get
		{
			if (physicMaterial == null)
			{
				physicMaterial = new PhysicMaterial(Id)
				{
					dynamicFriction = properties.GetPropertyAsFloat("dFriction"),
					staticFriction = properties.GetPropertyAsFloat("sFriction"),
					bounciness = properties.GetPropertyAsFloat("Bounciness")
				};
			}
			return physicMaterial;
		}
	}

	public MaterialSchematic(Properties properties)
	{
		this.properties = properties;
	}
}
