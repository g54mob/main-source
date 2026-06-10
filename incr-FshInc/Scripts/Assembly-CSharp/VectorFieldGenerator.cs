using System.IO;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Splines;

[RequireComponent(typeof(BoxCollider2D))]
public class VectorFieldGenerator : MonoBehaviour
{
	[Tooltip("The spline that defines the main direction of the flow.")]
	public SplineContainer spline;

	[Tooltip("A BoxCollider2D that defines the total area where the texture will be generated. The collider should be set as a trigger.")]
	public BoxCollider2D generationBounds;

	[Header("Flow Modifiers")]
	[Tooltip("A Collider2D (e.g., TilemapCollider2D) that defines the actual shape of the river. Flow will be zero outside this shape.")]
	public Collider2D riverShapeCollider;

	[Tooltip("The layer(s) that contain the obstacles. The flow will be zero inside these colliders.")]
	public LayerMask obstacleLayer;

	[Tooltip("An estimate of the river's average half-width. Flow is strongest at the spline and fades to zero at this distance.")]
	public float riverHalfWidth = 5f;

	[Tooltip("The distance (in world units) over which the flow speed decreases as it approaches an obstacle.")]
	[Range(0.1f, 10f)]
	public float flowFalloffDistance = 2f;

	[Header("Output Settings")]
	[Tooltip("The resolution of the generated texture (e.g., 256 for a 256x256 texture).")]
	public int textureSize = 256;

	[Tooltip("The path within the Assets folder to save the generated texture.")]
	public string savePath = "Assets/Generated/VectorField.png";

	[Header("Debug")]
	[Tooltip("If true, the generated texture will be a grayscale map of the flow speed multiplier instead of a vector field.")]
	public bool debugSpeedMap;

	public void Generate()
	{
		if (spline == null || generationBounds == null || riverShapeCollider == null)
		{
			Debug.LogError("Spline, Generation Bounds, or River Shape Collider are not assigned. Aborting generation.");
			return;
		}
		bool queriesStartInColliders = Physics2D.queriesStartInColliders;
		try
		{
			Physics2D.queriesStartInColliders = true;
			Debug.Log("Starting vector field generation with revised falloff logic...");
			Texture2D texture2D = new Texture2D(textureSize, textureSize, TextureFormat.RGB24, mipChain: false);
			Bounds bounds = generationBounds.bounds;
			for (int i = 0; i < textureSize; i++)
			{
				for (int j = 0; j < textureSize; j++)
				{
					float t = (float)j / (float)(textureSize - 1);
					float t2 = (float)i / (float)(textureSize - 1);
					Vector3 vector = new Vector3(Mathf.Lerp(bounds.min.x, bounds.max.x, t), Mathf.Lerp(bounds.min.y, bounds.max.y, t2), bounds.center.z);
					Vector2 vector2 = Vector2.zero;
					float num = 0f;
					if (riverShapeCollider.OverlapPoint(vector) && !Physics2D.OverlapPoint(vector, obstacleLayer))
					{
						SplineUtility.GetNearestPoint(spline.Spline, vector, out var nearest, out var t3);
						float3 float5 = spline.EvaluateTangent(t3);
						Vector2 normalized = new Vector2(float5.x, float5.y).normalized;
						float num2 = Vector2.Distance(vector, new Vector3(nearest.x, nearest.y));
						float a = Mathf.SmoothStep(1f, 0f, num2 / riverHalfWidth);
						Collider2D[] array = Physics2D.OverlapCircleAll(vector, flowFalloffDistance, obstacleLayer);
						float num3 = float.MaxValue;
						if (array.Length != 0)
						{
							Collider2D[] array2 = array;
							foreach (Collider2D collider in array2)
							{
								Vector2 b = Physics2D.ClosestPoint(vector, collider);
								float num4 = Vector2.Distance(vector, b);
								if (num4 < num3)
								{
									num3 = num4;
								}
							}
						}
						float b2 = Mathf.SmoothStep(0f, 1f, num3 / flowFalloffDistance);
						num = Mathf.Min(a, b2);
						vector2 = normalized * num;
					}
					Color color = ((!debugSpeedMap) ? new Color((vector2.x + 1f) * 0.5f, (0f - vector2.y + 1f) * 0.5f, 0f) : new Color(num, num, num));
					texture2D.SetPixel(j, i, color);
				}
			}
			texture2D.Apply();
			byte[] bytes = texture2D.EncodeToPNG();
			string directoryName = Path.GetDirectoryName(savePath);
			if (!Directory.Exists(directoryName))
			{
				Directory.CreateDirectory(directoryName);
			}
			File.WriteAllBytes(savePath, bytes);
			Debug.Log("Texture data saved. Re-importing and configuring asset...");
			Debug.Log("Vector field generation complete! Saved to " + savePath);
		}
		finally
		{
			Physics2D.queriesStartInColliders = queriesStartInColliders;
		}
	}
}
