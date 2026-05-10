using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class InstancedRenderer : MonoBehaviour
{
	private Dictionary<int, SubRenderer> m_Subrenderers;

	public static InstancedRenderer Instance { get; private set; }

	[RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
	private static void Load()
	{
	}

	private void OnEnable()
	{
	}

	private void OnDisable()
	{
	}

	public SubRenderer CreateSubRenderer(int id, Material material)
	{
		return null;
	}

	public SubRenderer CreateSubRenderer(int id, Material material, uint capacity)
	{
		return null;
	}

	public SubRenderer CreateSubRenderer(int id, Material material, uint capacity, uint instanceCapacity)
	{
		return null;
	}

	public SubRenderer GetSubRendererById(int id)
	{
		return null;
	}

	private void Render(ScriptableRenderContext scriptableRenderContext, Camera camera)
	{
	}

	public void ClearSubrenderers()
	{
	}
}
