using System;
using System.Collections;
using System.Collections.Generic;
using Pathfinding;
using UnityEngine;

public class MinimapRenderer : MonoBehaviour
{
	public static MinimapRenderer instance;

	public RenderTexture renderTexture;

	public int updateInterval = 10;

	public float playerCircleRadius = 10f;

	public float enemyCircleRadius = 10f;

	public float allyCircleRadius = 10f;

	[SerializeField]
	private Camera virtualCamera;

	[SerializeField]
	private Color backgroundColor;

	[SerializeField]
	private float minBuildingSize = 2f;

	[SerializeField]
	private Material matBackground;

	[SerializeField]
	private Material matEnemies;

	[SerializeField]
	private Material matPlayer;

	[SerializeField]
	private Material matTerrain;

	[SerializeField]
	private Material matAlliesUnits;

	[SerializeField]
	private Material matAlliesBuildings;

	[SerializeField]
	private Material matShadows;

	private Mesh navMesh;

	private Matrix4x4 worldToRenderTextureMatrix;

	[SerializeField]
	private RenderTexture backgroundRenderTexture;

	private readonly List<float> cosValues = new List<float>();

	private readonly List<float> sinValues = new List<float>();

	private List<TaggedObject> allies = new List<TaggedObject>();

	private void Awake()
	{
		instance = this;
	}

	public void Start()
	{
		playerCircleRadius *= (float)renderTexture.width / 512f;
		enemyCircleRadius *= (float)renderTexture.width / 512f;
		allyCircleRadius *= (float)renderTexture.width / 512f;
		matBackground.color = backgroundColor;
		worldToRenderTextureMatrix = GetScreenSpaceMatrix(virtualCamera.projectionMatrix * virtualCamera.worldToCameraMatrix, renderTexture.width, renderTexture.height);
		for (int i = 0; i < 360; i += 30)
		{
			cosValues.Add(Mathf.Cos((float)i * (MathF.PI / 180f)));
			sinValues.Add(Mathf.Sin((float)i * (MathF.PI / 180f)));
		}
		StartCoroutine(PeriodicallyUpdateMinimap());
	}

	private void DrawCircle(float centerX, float centerY, float radius)
	{
		for (int i = 0; i < cosValues.Count; i++)
		{
			int index = (i + 1) % cosValues.Count;
			float x = cosValues[i] * radius + centerX;
			float y = sinValues[i] * radius + centerY;
			float x2 = cosValues[index] * radius + centerX;
			float y2 = sinValues[index] * radius + centerY;
			GL.Vertex3(centerX, centerY, 0f);
			GL.Vertex3(x, y, 0f);
			GL.Vertex3(x2, y2, 0f);
		}
	}

	private void RenderBackground()
	{
		RenderTexture.active = backgroundRenderTexture;
		GL.Clear(clearDepth: true, clearColor: true, backgroundColor);
		RenderTexture.active = null;
		RenderTexture.active = renderTexture;
		GL.Clear(clearDepth: true, clearColor: true, backgroundColor);
		RenderTexture.active = null;
		RenderMesh(navMesh, matShadows, backgroundRenderTexture, (float)renderTexture.width * 0.01f, (float)renderTexture.width * 0.01f);
		RenderMesh(navMesh, matTerrain, backgroundRenderTexture);
	}

	private Mesh GenerateGroundMesh()
	{
		Mesh mesh = new Mesh();
		NavGraph obj = AstarPath.active.graphs[0];
		List<GraphNode> list = new List<GraphNode>();
		obj.GetNodes((Action<GraphNode>)list.Add);
		List<Vector3> list2 = new List<Vector3>();
		List<int> list3 = new List<int>();
		foreach (TriangleMeshNode item in list)
		{
			list2.Add((Vector3)item.GetVertex(0));
			list2.Add((Vector3)item.GetVertex(1));
			list2.Add((Vector3)item.GetVertex(2));
			int num = list2.Count - 3;
			list3.Add(num);
			list3.Add(num + 1);
			list3.Add(num + 2);
		}
		mesh.SetVertices(list2);
		mesh.SetTriangles(list3, 0);
		mesh.RecalculateNormals();
		return mesh;
	}

	private Matrix4x4 GetScreenSpaceMatrix(Matrix4x4 projMatrix, int screenWidth, int screenHeight)
	{
		Matrix4x4 identity = Matrix4x4.identity;
		identity.m00 = (float)screenWidth / 2f;
		identity.m11 = (float)(-screenHeight) / 2f;
		identity.m03 = (float)screenWidth / 2f;
		identity.m13 = (float)screenHeight / 2f;
		return identity * projMatrix;
	}

	private void DrawPlayer()
	{
		Vector3 position = PlayerMovement.instance.transform.position;
		Vector4 vector = worldToRenderTextureMatrix * new Vector4(position.x, position.y, position.z, 1f);
		StartTrianglesDrawCall(matPlayer);
		DrawCircle(vector.x, vector.y, playerCircleRadius);
		EndTrianglesDrawCall();
	}

	private void DrawEnemies()
	{
		List<TaggedObject> list = new List<TaggedObject>();
		TagManager.instance.FindAllTaggedObjectsWithTag(list, TagManager.ETag.EnemyOwned);
		StartTrianglesDrawCall(matEnemies);
		foreach (TaggedObject item in list)
		{
			Vector3 position = item.transform.position;
			Vector4 vector = worldToRenderTextureMatrix * new Vector4(position.x, position.y, position.z, 1f);
			DrawCircle(vector.x, vector.y, enemyCircleRadius);
		}
		EndTrianglesDrawCall();
	}

	private void RenderMesh(Mesh mesh, Material material, RenderTexture targetTexture, float xOffset = 0f, float yOffset = 0f)
	{
		Vector3[] vertices = mesh.vertices;
		int[] triangles = mesh.triangles;
		RenderTexture.active = targetTexture;
		GL.PushMatrix();
		GL.LoadPixelMatrix(0f, targetTexture.width, targetTexture.height, 0f);
		material.SetPass(0);
		GL.Begin(4);
		Vector4 vector = Vector4.zero;
		Vector2 zero = Vector2.zero;
		Vector2 zero2 = Vector2.zero;
		Vector2 zero3 = Vector2.zero;
		for (int i = 0; i < triangles.Length; i += 3)
		{
			Vector3 vector2 = vertices[triangles[i]];
			Vector3 vector3 = vertices[triangles[i + 1]];
			Vector3 vector4 = vertices[triangles[i + 2]];
			vector.Set(vector2.x, vector2.y, vector2.z, 1f);
			vector = worldToRenderTextureMatrix * vector;
			zero.Set(vector.x, vector.y);
			vector.Set(vector3.x, vector3.y, vector3.z, 1f);
			vector = worldToRenderTextureMatrix * vector;
			zero2.Set(vector.x, vector.y);
			vector.Set(vector4.x, vector4.y, vector4.z, 1f);
			vector = worldToRenderTextureMatrix * vector;
			zero3.Set(vector.x, vector.y);
			GL.Vertex3(zero.x + xOffset, zero.y + yOffset, 0f);
			GL.Vertex3(zero2.x + xOffset, zero2.y + yOffset, 0f);
			GL.Vertex3(zero3.x + xOffset, zero3.y + yOffset, 0f);
		}
		GL.End();
		GL.PopMatrix();
		RenderTexture.active = null;
	}

	private void RenderBotOfBox(Vector3 position, Vector3 size, Quaternion rotation)
	{
		Vector3[] array = new Vector3[4];
		Vector3 vector = size * 0.5f;
		array[0] = position + rotation * new Vector3(0f - vector.x, 0f - vector.y, 0f - vector.z);
		array[1] = position + rotation * new Vector3(vector.x, 0f - vector.y, 0f - vector.z);
		array[2] = position + rotation * new Vector3(vector.x, 0f - vector.y, vector.z);
		array[3] = position + rotation * new Vector3(0f - vector.x, 0f - vector.y, vector.z);
		Vector4 zero = Vector4.zero;
		Vector2 zero2 = Vector2.zero;
		Vector2 zero3 = Vector2.zero;
		Vector2 zero4 = Vector2.zero;
		Vector2 zero5 = Vector2.zero;
		zero.Set(array[0].x, array[0].y, array[0].z, 1f);
		zero = worldToRenderTextureMatrix * zero;
		zero2.Set(zero.x, zero.y);
		zero.Set(array[1].x, array[1].y, array[1].z, 1f);
		zero = worldToRenderTextureMatrix * zero;
		zero3.Set(zero.x, zero.y);
		zero.Set(array[2].x, array[2].y, array[2].z, 1f);
		zero = worldToRenderTextureMatrix * zero;
		zero4.Set(zero.x, zero.y);
		zero.Set(array[3].x, array[3].y, array[3].z, 1f);
		zero = worldToRenderTextureMatrix * zero;
		zero5.Set(zero.x, zero.y);
		GL.Vertex3(zero4.x, zero4.y, 0f);
		GL.Vertex3(zero3.x, zero3.y, 0f);
		GL.Vertex3(zero2.x, zero2.y, 0f);
		GL.Vertex3(zero5.x, zero5.y, 0f);
		GL.Vertex3(zero4.x, zero4.y, 0f);
		GL.Vertex3(zero2.x, zero2.y, 0f);
	}

	private void StartTrianglesDrawCall(Material mat)
	{
		RenderTexture.active = renderTexture;
		GL.PushMatrix();
		GL.LoadPixelMatrix(0f, renderTexture.width, renderTexture.height, 0f);
		mat.SetPass(0);
		GL.Begin(4);
	}

	private void EndTrianglesDrawCall()
	{
		GL.End();
		GL.PopMatrix();
		RenderTexture.active = null;
	}

	private void DrawAllies(TagManager.ETag tag, Material mat)
	{
		TagManager.instance.FindAllTaggedObjectsWithTag(allies, tag);
		if (allies.Count <= 0)
		{
			return;
		}
		StartTrianglesDrawCall(mat);
		foreach (TaggedObject ally in allies)
		{
			if (!ally.Tags.Contains(TagManager.ETag.AUTO_Alive))
			{
				continue;
			}
			if (ally.colliderForBigOjectsToMeasureDistance == null)
			{
				Vector3 position = ally.transform.position;
				Vector4 vector = worldToRenderTextureMatrix * new Vector4(position.x, position.y, position.z, 1f);
				DrawCircle(vector.x, vector.y, allyCircleRadius);
				continue;
			}
			Collider colliderForBigOjectsToMeasureDistance = ally.colliderForBigOjectsToMeasureDistance;
			if (colliderForBigOjectsToMeasureDistance.GetType() == typeof(BoxCollider))
			{
				BoxCollider boxCollider = (BoxCollider)colliderForBigOjectsToMeasureDistance;
				Vector3 position2 = colliderForBigOjectsToMeasureDistance.transform.localToWorldMatrix.MultiplyPoint(boxCollider.center);
				Vector3 size = boxCollider.size;
				size.Set(Mathf.Max(size.x, minBuildingSize), size.y, Mathf.Max(size.z, minBuildingSize));
				Quaternion rotation = colliderForBigOjectsToMeasureDistance.transform.rotation;
				RenderBotOfBox(position2, size, rotation);
			}
		}
		EndTrianglesDrawCall();
	}

	private Color Saturate(Color color, float strength)
	{
		float num = Mathf.Min(color.r, color.g, color.b);
		float num2 = Mathf.Max(color.r, color.g, color.b, num + 0.0001f);
		float r = (color.r - num) / (num2 - num) * num2;
		float g = (color.g - num) / (num2 - num) * num2;
		float b = (color.b - num) / (num2 - num) * num2;
		return Color.Lerp(color, new Color(r, g, b), strength);
	}

	public static Color EnsureColorIsDifferentFrom(Color colToChange, Color colToBeDifferentFrom, float requiredDistance)
	{
		float num = ColorDistance(colToChange, colToBeDifferentFrom);
		if (num >= requiredDistance)
		{
			return colToChange;
		}
		Vector3 vector = (new Vector3(colToChange.r, colToChange.g, colToChange.b) - new Vector3(colToBeDifferentFrom.r, colToBeDifferentFrom.g, colToBeDifferentFrom.b)).normalized;
		if (colToChange == colToBeDifferentFrom)
		{
			vector = Vector3.one;
		}
		int num2 = 100;
		while (num < requiredDistance)
		{
			colToChange.r += vector.x * 0.01f;
			colToChange.g += vector.y * 0.01f;
			colToChange.b += vector.z * 0.01f;
			colToChange.r = Mathf.Clamp01(colToChange.r);
			colToChange.g = Mathf.Clamp01(colToChange.g);
			colToChange.b = Mathf.Clamp01(colToChange.b);
			num = ColorDistance(colToChange, colToBeDifferentFrom);
			num2--;
			if (num2 <= 0)
			{
				break;
			}
		}
		return colToChange;
	}

	private static float ColorDistance(Color a, Color b)
	{
		return Mathf.Sqrt(Mathf.Pow(a.r - b.r, 2f) + Mathf.Pow(a.g - b.g, 2f) + Mathf.Pow(a.b - b.b, 2f));
	}

	private void GrabColorsFromCurrentColorScheme()
	{
		Colorscheme currentColorScheme = ColorAndLightManager.Instance.CurrentColorScheme;
		matShadows.color = Color.Lerp(currentColorScheme.globalShadowColor, Color.black, 0.5f);
		matEnemies.color = Saturate(Color.Lerp(currentColorScheme.enemyMidColor, currentColorScheme.enemyLightColor, 0.5f), 0.75f);
		matAlliesUnits.color = Saturate(Color.Lerp(currentColorScheme.allyMidColor, currentColorScheme.allyLightColor, 0.5f), 0.75f);
		matTerrain.color = currentColorScheme.groundColor * Color.Lerp(currentColorScheme.nightLightColor, Color.white, 0.1f);
		matAlliesBuildings.color = Color.Lerp(matAlliesUnits.color, matTerrain.color, 0.5f);
		matAlliesBuildings.color = EnsureColorIsDifferentFrom(matAlliesBuildings.color, matTerrain.color, 0.25f);
		matAlliesUnits.color = EnsureColorIsDifferentFrom(matAlliesUnits.color, matAlliesBuildings.color, 0.25f);
		matPlayer.color = Color.white;
	}

	private void ClearMinimap()
	{
		Graphics.Blit(backgroundRenderTexture, renderTexture);
	}

	private IEnumerator PeriodicallyUpdateMinimap()
	{
		yield return null;
		navMesh = GenerateGroundMesh();
		GrabColorsFromCurrentColorScheme();
		yield return null;
		RenderBackground();
		while (true)
		{
			ClearMinimap();
			DrawAllies(TagManager.ETag.Building, matAlliesBuildings);
			DrawAllies(TagManager.ETag.PlayerUnit, matAlliesUnits);
			DrawAllies(TagManager.ETag.AUTO_Commanded, matPlayer);
			DrawEnemies();
			DrawPlayer();
			yield return null;
			for (int i = 0; i < updateInterval; i++)
			{
				DrawPlayer();
				yield return null;
			}
		}
	}
}
