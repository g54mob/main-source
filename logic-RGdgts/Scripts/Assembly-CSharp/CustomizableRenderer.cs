using System.Collections.Generic;
using Sirenix.OdinInspector;

public abstract class CustomizableRenderer : SerializedMonoBehaviour
{
	public int customizationProperty;

	private int _customizationId;

	public int customizationId => 0;

	public virtual void SetCustomization(int id)
	{
	}

	public abstract List<int> GetCustomizationKeys();

	public abstract SpriteRotationInfo GetPixelShapeRotationInfo(int customizationKey, int rotationI);
}
