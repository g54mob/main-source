using UnityEngine;

namespace Assets.Scripts.MapGeneration.ProceduralTiles;

public class FillTile : MonoBehaviour
{
	public MeshRenderer renderer;

	public EFillType fillType;

	public bool cross;

	public bool useEdge;

	public void SetFillType(EFillType type, StageData stageData, bool useEdgeTextures = false)
	{
		useEdge = useEdgeTextures;
		bool flag = cross;
		EFillType eFillType = EFillType.Top;
		if (!flag)
		{
			eFillType = type;
		}
		fillType = eFillType;
		Material sideMaterial = stageData.GetSideMaterial(eFillType, useEdgeTextures);
		((Renderer)renderer).SetMaterial(sideMaterial);
	}

	private void OnValidate()
	{
		GameObject gameObject = base.gameObject;
		MeshRenderer component = gameObject.GetComponent<MeshRenderer>();
		renderer = component;
	}
}
