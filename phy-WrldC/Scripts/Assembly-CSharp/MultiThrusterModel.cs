using UnityEngine;

public class MultiThrusterModel : ComponentModel
{
	public const string ActivePXKey = "m_thruster_active_px";

	public const string ActivePYKey = "m_thruster_active_py";

	public const string ActivePZKey = "m_thruster_active_pz";

	public const string ActiveNXKey = "m_thruster_active_nx";

	public const string ActiveNYKey = "m_thruster_active_ny";

	public const string ActiveNZKey = "m_thruster_active_nz";

	public const string Fuel = "m_thruster_fuel";

	public MultiThrusterModel(ComponentSchematic componentSchematic)
		: base(componentSchematic)
	{
	}

	public override void Initialize()
	{
		base.Initialize();
		Vector3 propertyAsVector = base.ComponentSchematic.Properties.GetPropertyAsVector3("dirPos");
		Vector3 propertyAsVector2 = base.ComponentSchematic.Properties.GetPropertyAsVector3("dirNeg");
		if (propertyAsVector.x > 0f)
		{
			base.ParentBlockBodyModel.AddDefaultKeyIO(new DefaultKeyIO("m_thruster_active_px", KeyCode.Keypad4, DefaultKeyIOPlace.Component, isAxisSensitive: true));
		}
		if (propertyAsVector.y > 0f)
		{
			base.ParentBlockBodyModel.AddDefaultKeyIO(new DefaultKeyIO("m_thruster_active_py", KeyCode.Keypad8, DefaultKeyIOPlace.Component, isAxisSensitive: true));
		}
		if (propertyAsVector.z > 0f)
		{
			base.ParentBlockBodyModel.AddDefaultKeyIO(new DefaultKeyIO("m_thruster_active_pz", KeyCode.Keypad7, DefaultKeyIOPlace.Component, isAxisSensitive: true));
		}
		if (propertyAsVector2.x > 0f)
		{
			base.ParentBlockBodyModel.AddDefaultKeyIO(new DefaultKeyIO("m_thruster_active_nx", KeyCode.Keypad6, DefaultKeyIOPlace.Component, isAxisSensitive: true));
		}
		if (propertyAsVector2.y > 0f)
		{
			base.ParentBlockBodyModel.AddDefaultKeyIO(new DefaultKeyIO("m_thruster_active_ny", KeyCode.Keypad5, DefaultKeyIOPlace.Component, isAxisSensitive: true));
		}
		if (propertyAsVector2.z > 0f)
		{
			base.ParentBlockBodyModel.AddDefaultKeyIO(new DefaultKeyIO("m_thruster_active_nz", KeyCode.Keypad9, DefaultKeyIOPlace.Component, isAxisSensitive: true));
		}
		base.ParentBlockBodyModel.AddDefaultKeyIO(new DefaultKeyIO("m_thruster_fuel", KeyCode.None, DefaultKeyIOPlace.Component, isAxisSensitive: false, DefaultKeyIODirection.Output));
	}
}
