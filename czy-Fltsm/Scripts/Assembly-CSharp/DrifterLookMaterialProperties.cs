using UnityEngine;

[CreateAssetMenu(menuName = "Flotsam/Agent/Looks/Material")]
public class DrifterLookMaterialProperties : PersistentProperties
{
	public Material Material;

	public override Types Type => Types.DrifterLookMaterialProperties;
}
