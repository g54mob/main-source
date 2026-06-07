using UnityEngine;

public class GlobalMaterialManager : MonoBehaviour
{
	public Material PlaceholderGreenMaterial;

	public Material PlaceholderRedMaterial;

	[SerializeField]
	private Material levelObjectWithGridMat;

	[SerializeField]
	private Material levelObjectWithoutGridMat;

	public static GlobalMaterialManager Instance => Singleton<GlobalMaterialManager>.Instance;

	public Material LevelObjectWithGridMat => levelObjectWithGridMat;

	public Material LevelObjectWithoutGridMat => levelObjectWithoutGridMat;
}
