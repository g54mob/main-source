using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
[DisallowMultipleComponent]
public class OverlayFX : MonoBehaviour
{
	public enum GradientAxis
	{
		X = 0,
		Y = 1,
		Z = 2
	}

	public enum UvDirection
	{
		X = 0,
		Y = 1,
		Z = 2
	}

	public static class ShaderKeywordController
	{
		private static readonly string[] GradientAxisKeywords;

		private static readonly string[] UvDirectionKeywords;

		public static void SetGradientAxis(Material mat, GradientAxis axis)
		{
		}

		public static void SetUvDirection(Material mat, UvDirection uv)
		{
		}
	}

	public Material overlayMaterial;

	public Renderer targetRenderer;

	public List<ParticleSystem> particleSystems;

	private float particleSizeMultiplier;

	public Vector3 rendererTrueForward;

	private void OnEnable()
	{
	}

	private void OnValidate()
	{
	}

	private void OnDrawGizmosSelected()
	{
	}

	private bool IsOverlayMatch(Material m)
	{
		return false;
	}

	private void EnsureRuntimeOverlay()
	{
	}

	private void StripRuntimeOverlay()
	{
	}

	private void SyncParticleSystems()
	{
	}

	private void UpdateBounds(Material mat, Renderer rend)
	{
	}
}
