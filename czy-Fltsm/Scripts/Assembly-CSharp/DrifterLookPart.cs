using UnityEngine;

[CreateAssetMenu(menuName = "Flotsam/Agent/Looks/Part")]
public class DrifterLookPart : PersistentProperties
{
	public Mesh Mesh;

	public override Types Type => Types.DrifterLookPart;
}
