using UnityEngine;

public class TileStairs : MonoBehaviour
{
	public Renderer renderer;

	public void Set(StageData stageData)
	{
		renderer.SetMaterial(stageData.m_stairs);
	}
}
