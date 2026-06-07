using UnityEngine;

[CreateAssetMenu(menuName = "DV/Rail track RailType asset")]
public class RailType : ScriptableObject
{
	[Header("Rail")]
	[Tooltip("Shape to be used on the rail")]
	public Shape railShape;

	[Tooltip("Material to be used on the rail")]
	public Material railMaterial;

	[Tooltip("Track gauge, standard: 1.435")]
	public float gauge = 1.435f;

	[Tooltip("Width between rail shape center and the edge of rail head. Therefore, rail center will be placed at gauge + edge offset")]
	public float railEdgeOffset = 0.0351f;

	[Header("Kink")]
	public float kinkFrequency = 0.07f;

	public float kinkScale = 0.07f;

	public float verticalKinkScale = 0.07f;

	public float rotationKinkScale = 1f;
}
