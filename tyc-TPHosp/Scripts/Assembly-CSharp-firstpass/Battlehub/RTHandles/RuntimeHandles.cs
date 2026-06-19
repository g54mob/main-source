using System;
using UnityEngine;

namespace Battlehub.RTHandles
{
	public static class RuntimeHandles
	{
		public static readonly Color32 XColor;

		public static readonly Color32 XColorTransparent;

		public static readonly Color32 YColor;

		public static readonly Color32 YColorTransparent;

		public static readonly Color32 ZColor;

		public static readonly Color32 ZColorTransparent;

		public static readonly Color32 AltColor;

		public static readonly Color32 SelectionColor;

		private static readonly Mesh Arrows;

		private static readonly Mesh SelectionArrowY;

		private static readonly Mesh SelectionArrowX;

		private static readonly Mesh SelectionArrowZ;

		private static readonly Mesh SelectionCube;

		private static readonly Mesh CubeX;

		private static readonly Mesh CubeY;

		private static readonly Mesh CubeZ;

		private static readonly Mesh CubeUniform;

		private static readonly Mesh SceneGizmoSelectedAxis;

		private static readonly Mesh SceneGizmoXAxis;

		private static readonly Mesh SceneGizmoYAxis;

		private static readonly Mesh SceneGizmoZAxis;

		private static readonly Mesh SceneGizmoCube;

		private static readonly Mesh SceneGizmoSelectedCube;

		private static readonly Mesh SceneGizmoQuad;

		private static readonly Material ShapesMaterialZTest;

		private static readonly Material ShapesMaterialZTest2;

		private static readonly Material ShapesMaterialZTest3;

		private static readonly Material ShapesMaterialZTest4;

		private static readonly Material ShapesMaterialZTestOffset;

		private static readonly Material ShapesMaterial;

		private static readonly Material LinesMaterial;

		private static readonly Material LinesClipMaterial;

		private static readonly Material LinesBillboardMaterial;

		private static readonly Material XMaterial;

		private static readonly Material YMaterial;

		private static readonly Material ZMaterial;

		private static readonly Material GridMaterial;

		static RuntimeHandles()
		{
			XColor = new Color32(187, 70, 45, byte.MaxValue);
			XColorTransparent = new Color32(187, 70, 45, 128);
			YColor = new Color32(139, 206, 74, byte.MaxValue);
			YColorTransparent = new Color32(139, 206, 74, 128);
			ZColor = new Color32(55, 115, 244, byte.MaxValue);
			ZColorTransparent = new Color32(55, 115, 244, 128);
			AltColor = new Color32(192, 192, 192, 224);
			SelectionColor = new Color32(239, 238, 64, byte.MaxValue);
			LinesMaterial = new Material(Shader.Find("Battlehub/RTHandles/VertexColor"));
			LinesMaterial.color = Color.white;
			LinesClipMaterial = new Material(Shader.Find("Battlehub/RTHandles/VertexColorClip"));
			LinesClipMaterial.color = Color.white;
			LinesBillboardMaterial = new Material(Shader.Find("Battlehub/RTHandles/VertexColorBillboard"));
			LinesBillboardMaterial.color = Color.white;
			ShapesMaterial = new Material(Shader.Find("Battlehub/RTHandles/Shape"));
			ShapesMaterial.color = Color.white;
			ShapesMaterialZTest = new Material(Shader.Find("Battlehub/RTHandles/Shape"));
			ShapesMaterialZTest.color = new Color(1f, 1f, 1f, 0f);
			ShapesMaterialZTest.SetFloat("_ZTest", 4f);
			ShapesMaterialZTest.SetFloat("_ZWrite", 1f);
			ShapesMaterialZTestOffset = new Material(Shader.Find("Battlehub/RTHandles/Shape"));
			ShapesMaterialZTestOffset.color = new Color(1f, 1f, 1f, 1f);
			ShapesMaterialZTestOffset.SetFloat("_ZTest", 4f);
			ShapesMaterialZTestOffset.SetFloat("_ZWrite", 1f);
			ShapesMaterialZTestOffset.SetFloat("_OFactors", -1f);
			ShapesMaterialZTestOffset.SetFloat("_OUnits", -1f);
			ShapesMaterialZTest2 = new Material(Shader.Find("Battlehub/RTHandles/Shape"));
			ShapesMaterialZTest2.color = new Color(1f, 1f, 1f, 0f);
			ShapesMaterialZTest2.SetFloat("_ZTest", 4f);
			ShapesMaterialZTest2.SetFloat("_ZWrite", 1f);
			ShapesMaterialZTest3 = new Material(Shader.Find("Battlehub/RTHandles/Shape"));
			ShapesMaterialZTest3.color = new Color(1f, 1f, 1f, 0f);
			ShapesMaterialZTest3.SetFloat("_ZTest", 4f);
			ShapesMaterialZTest3.SetFloat("_ZWrite", 1f);
			ShapesMaterialZTest4 = new Material(Shader.Find("Battlehub/RTHandles/Shape"));
			ShapesMaterialZTest4.color = new Color(1f, 1f, 1f, 0f);
			ShapesMaterialZTest4.SetFloat("_ZTest", 4f);
			ShapesMaterialZTest4.SetFloat("_ZWrite", 1f);
			XMaterial = new Material(Shader.Find("Battlehub/RTHandles/Billboard"));
			XMaterial.color = Color.white;
			XMaterial.mainTexture = Resources.Load<Texture>("Battlehub.RuntimeHandles.x");
			YMaterial = new Material(Shader.Find("Battlehub/RTHandles/Billboard"));
			YMaterial.color = Color.white;
			YMaterial.mainTexture = Resources.Load<Texture>("Battlehub.RuntimeHandles.y");
			ZMaterial = new Material(Shader.Find("Battlehub/RTHandles/Billboard"));
			ZMaterial.color = Color.white;
			ZMaterial.mainTexture = Resources.Load<Texture>("Battlehub.RuntimeHandles.z");
			GridMaterial = new Material(Shader.Find("Battlehub/RTHandles/Grid"));
			GridMaterial.color = Color.white;
			Mesh mesh = CreateConeMesh(SelectionColor);
			CombineInstance combineInstance = new CombineInstance
			{
				mesh = mesh,
				transform = Matrix4x4.TRS(Vector3.up, Quaternion.identity, Vector3.one)
			};
			SelectionArrowY = new Mesh();
			SelectionArrowY.CombineMeshes(new CombineInstance[1] { combineInstance }, mergeSubMeshes: true);
			SelectionArrowY.RecalculateNormals();
			CombineInstance combineInstance2 = new CombineInstance
			{
				mesh = mesh,
				transform = Matrix4x4.TRS(Vector3.right, Quaternion.AngleAxis(-90f, Vector3.forward), Vector3.one)
			};
			SelectionArrowX = new Mesh();
			SelectionArrowX.CombineMeshes(new CombineInstance[1] { combineInstance2 }, mergeSubMeshes: true);
			SelectionArrowX.RecalculateNormals();
			CombineInstance combineInstance3 = new CombineInstance
			{
				mesh = mesh,
				transform = Matrix4x4.TRS(Vector3.forward, Quaternion.AngleAxis(90f, Vector3.right), Vector3.one)
			};
			SelectionArrowZ = new Mesh();
			SelectionArrowZ.CombineMeshes(new CombineInstance[1] { combineInstance3 }, mergeSubMeshes: true);
			SelectionArrowZ.RecalculateNormals();
			combineInstance.mesh = CreateConeMesh(YColor);
			combineInstance2.mesh = CreateConeMesh(XColor);
			combineInstance3.mesh = CreateConeMesh(ZColor);
			Arrows = new Mesh();
			Arrows.CombineMeshes(new CombineInstance[3] { combineInstance, combineInstance2, combineInstance3 }, mergeSubMeshes: true);
			Arrows.RecalculateNormals();
			SelectionCube = CreateCubeMesh(SelectionColor, 0.1f, 0.1f, 0.1f);
			CubeX = CreateCubeMesh(XColor, 0.1f, 0.1f, 0.1f);
			CubeY = CreateCubeMesh(YColor, 0.1f, 0.1f, 0.1f);
			CubeZ = CreateCubeMesh(ZColor, 0.1f, 0.1f, 0.1f);
			CubeUniform = CreateCubeMesh(AltColor, 0.1f, 0.1f, 0.1f);
			SceneGizmoSelectedAxis = CreateSceneGizmoHalfAxis(SelectionColor, Quaternion.AngleAxis(90f, Vector3.right));
			SceneGizmoXAxis = CreateSceneGizmoAxis(XColor, AltColor, Quaternion.AngleAxis(-90f, Vector3.forward));
			SceneGizmoYAxis = CreateSceneGizmoAxis(YColor, AltColor, Quaternion.identity);
			SceneGizmoZAxis = CreateSceneGizmoAxis(ZColor, AltColor, Quaternion.AngleAxis(90f, Vector3.right));
			SceneGizmoCube = CreateCubeMesh(AltColor);
			SceneGizmoSelectedCube = CreateCubeMesh(SelectionColor);
			SceneGizmoQuad = CreateQuadMesh();
		}

		private static Mesh CreateQuadMesh(float quadWidth = 1f, float cubeHeight = 1f)
		{
			Vector3 vector = new Vector3((0f - quadWidth) * 0.5f, (0f - cubeHeight) * 0.5f, 0f);
			Vector3 vector2 = new Vector3(quadWidth * 0.5f, (0f - cubeHeight) * 0.5f, 0f);
			Vector3 vector3 = new Vector3((0f - quadWidth) * 0.5f, cubeHeight * 0.5f, 0f);
			Vector3 vector4 = new Vector3(quadWidth * 0.5f, cubeHeight * 0.5f, 0f);
			Vector3[] vertices = new Vector3[4] { vector3, vector4, vector2, vector };
			int[] triangles = new int[6] { 3, 1, 0, 3, 2, 1 };
			Vector2[] uv = new Vector2[4]
			{
				new Vector2(1f, 0f),
				new Vector2(0f, 0f),
				new Vector2(0f, 1f),
				new Vector2(1f, 1f)
			};
			Mesh mesh = new Mesh();
			mesh.name = "quad";
			mesh.vertices = vertices;
			mesh.triangles = triangles;
			mesh.uv = uv;
			mesh.RecalculateNormals();
			return mesh;
		}

		private static Mesh CreateCubeMesh(Color color, float cubeLength = 1f, float cubeWidth = 1f, float cubeHeight = 1f)
		{
			Vector3 vector = new Vector3((0f - cubeLength) * 0.5f, (0f - cubeWidth) * 0.5f, cubeHeight * 0.5f);
			Vector3 vector2 = new Vector3(cubeLength * 0.5f, (0f - cubeWidth) * 0.5f, cubeHeight * 0.5f);
			Vector3 vector3 = new Vector3(cubeLength * 0.5f, (0f - cubeWidth) * 0.5f, (0f - cubeHeight) * 0.5f);
			Vector3 vector4 = new Vector3((0f - cubeLength) * 0.5f, (0f - cubeWidth) * 0.5f, (0f - cubeHeight) * 0.5f);
			Vector3 vector5 = new Vector3((0f - cubeLength) * 0.5f, cubeWidth * 0.5f, cubeHeight * 0.5f);
			Vector3 vector6 = new Vector3(cubeLength * 0.5f, cubeWidth * 0.5f, cubeHeight * 0.5f);
			Vector3 vector7 = new Vector3(cubeLength * 0.5f, cubeWidth * 0.5f, (0f - cubeHeight) * 0.5f);
			Vector3 vector8 = new Vector3((0f - cubeLength) * 0.5f, cubeWidth * 0.5f, (0f - cubeHeight) * 0.5f);
			Vector3[] array = new Vector3[24]
			{
				vector, vector2, vector3, vector4, vector8, vector5, vector, vector4, vector5, vector6,
				vector2, vector, vector7, vector8, vector4, vector3, vector6, vector7, vector3, vector2,
				vector8, vector7, vector6, vector5
			};
			int[] triangles = new int[36]
			{
				3, 1, 0, 3, 2, 1, 7, 5, 4, 7,
				6, 5, 11, 9, 8, 11, 10, 9, 15, 13,
				12, 15, 14, 13, 19, 17, 16, 19, 18, 17,
				23, 21, 20, 23, 22, 21
			};
			Color[] array2 = new Color[array.Length];
			for (int i = 0; i < array2.Length; i++)
			{
				array2[i] = color;
			}
			Mesh mesh = new Mesh();
			mesh.name = "cube";
			mesh.vertices = array;
			mesh.triangles = triangles;
			mesh.colors = array2;
			mesh.RecalculateNormals();
			return mesh;
		}

		private static Mesh CreateConeMesh(Color color)
		{
			int num = 12;
			float num2 = 0.2f;
			Vector3[] array = new Vector3[num * 3 + 1];
			int[] array2 = new int[num * 6];
			Color[] array3 = new Color[array.Length];
			for (int i = 0; i < array3.Length; i++)
			{
				array3[i] = color;
			}
			float num3 = num2 / 2.6f;
			float num4 = num2;
			float num5 = (float)Math.PI * 2f / (float)num;
			float y = 0f - num4;
			array[array.Length - 1] = new Vector3(0f, 0f - num4, 0f);
			for (int j = 0; j < num; j++)
			{
				float f = (float)j * num5;
				float x = Mathf.Cos(f) * num3;
				float z = Mathf.Sin(f) * num3;
				array[j] = new Vector3(x, y, z);
				array[num + j] = new Vector3(0f, 0.01f, 0f);
				array[2 * num + j] = array[j];
			}
			for (int k = 0; k < num; k++)
			{
				array2[k * 6] = k;
				array2[k * 6 + 1] = num + k;
				array2[k * 6 + 2] = (k + 1) % num;
				array2[k * 6 + 3] = array.Length - 1;
				array2[k * 6 + 4] = 2 * num + k;
				array2[k * 6 + 5] = 2 * num + (k + 1) % num;
			}
			return new Mesh
			{
				name = "Cone",
				vertices = array,
				triangles = array2,
				colors = array3
			};
		}

		private static Mesh CreateSceneGizmoHalfAxis(Color color, Quaternion rotation)
		{
			Mesh mesh = CreateConeMesh(color);
			CombineInstance combineInstance = new CombineInstance
			{
				mesh = mesh,
				transform = Matrix4x4.TRS(Vector3.up * 0.1f, Quaternion.AngleAxis(180f, Vector3.right), Vector3.one)
			};
			Mesh mesh2 = new Mesh();
			mesh2.CombineMeshes(new CombineInstance[1] { combineInstance }, mergeSubMeshes: true);
			CombineInstance combineInstance2 = new CombineInstance
			{
				mesh = mesh2,
				transform = Matrix4x4.TRS(Vector3.zero, rotation, Vector3.one)
			};
			mesh2 = new Mesh();
			mesh2.CombineMeshes(new CombineInstance[1] { combineInstance2 }, mergeSubMeshes: true);
			mesh2.RecalculateNormals();
			return mesh2;
		}

		private static Mesh CreateSceneGizmoAxis(Color axisColor, Color altColor, Quaternion rotation)
		{
			Mesh mesh = CreateConeMesh(axisColor);
			Mesh mesh2 = CreateConeMesh(altColor);
			CombineInstance combineInstance = new CombineInstance
			{
				mesh = mesh,
				transform = Matrix4x4.TRS(Vector3.up * 0.1f, Quaternion.AngleAxis(180f, Vector3.right), Vector3.one)
			};
			CombineInstance combineInstance2 = new CombineInstance
			{
				mesh = mesh2,
				transform = Matrix4x4.TRS(Vector3.down * 0.1f, Quaternion.identity, Vector3.one)
			};
			Mesh mesh3 = new Mesh();
			mesh3.CombineMeshes(new CombineInstance[2] { combineInstance, combineInstance2 }, mergeSubMeshes: true);
			CombineInstance combineInstance3 = new CombineInstance
			{
				mesh = mesh3,
				transform = Matrix4x4.TRS(Vector3.zero, rotation, Vector3.one)
			};
			mesh3 = new Mesh();
			mesh3.CombineMeshes(new CombineInstance[1] { combineInstance3 }, mergeSubMeshes: true);
			mesh3.RecalculateNormals();
			return mesh3;
		}

		public static float GetScreenScale(Vector3 position, Camera camera)
		{
			float num = camera.pixelHeight;
			if (camera.orthographic)
			{
				return camera.orthographicSize * 2f / num * 90f;
			}
			Transform transform = camera.transform;
			float num2 = Vector3.Dot(position - transform.position, transform.forward);
			return 2f * num2 * Mathf.Tan(camera.fieldOfView * 0.5f * ((float)Math.PI / 180f)) / num * 90f;
		}

		private static void DoAxes(Vector3 position, Matrix4x4 transform, RuntimeHandleAxis selectedAxis)
		{
			Vector3 right = Vector3.right;
			Vector3 up = Vector3.up;
			Vector3 forward = Vector3.forward;
			right = transform.MultiplyVector(right);
			up = transform.MultiplyVector(up);
			forward = transform.MultiplyVector(forward);
			GL.Color((selectedAxis != RuntimeHandleAxis.X) ? XColor : SelectionColor);
			GL.Vertex(position);
			GL.Vertex(position + right);
			GL.Color((selectedAxis != RuntimeHandleAxis.Y) ? YColor : SelectionColor);
			GL.Vertex(position);
			GL.Vertex(position + up);
			GL.Color((selectedAxis != RuntimeHandleAxis.Z) ? ZColor : SelectionColor);
			GL.Vertex(position);
			GL.Vertex(position + forward);
		}

		public static void DoPositionHandle(Vector3 position, Quaternion rotation, RuntimeHandleAxis selectedAxis = RuntimeHandleAxis.None)
		{
			float screenScale = GetScreenScale(position, Camera.current);
			Matrix4x4 matrix4x = Matrix4x4.TRS(position, rotation, new Vector3(screenScale, screenScale, screenScale));
			LinesMaterial.SetPass(0);
			GL.Begin(1);
			DoAxes(position, matrix4x, selectedAxis);
			Vector3 vector = Vector3.right * 0.2f;
			Vector3 vector2 = Vector3.up * 0.2f;
			Vector3 vector3 = Vector3.forward * 0.2f;
			Vector3 lhs = Camera.current.transform.position - position;
			float num = Mathf.Sign(Vector3.Dot(lhs, vector));
			float num2 = Mathf.Sign(Vector3.Dot(lhs, vector2));
			float num3 = Mathf.Sign(Vector3.Dot(lhs, vector3));
			vector.x *= num;
			vector2.y *= num2;
			vector3.z *= num3;
			Vector3 point = vector + vector2;
			Vector3 point2 = vector + vector3;
			Vector3 point3 = vector2 + vector3;
			vector = matrix4x.MultiplyPoint(vector);
			vector2 = matrix4x.MultiplyPoint(vector2);
			vector3 = matrix4x.MultiplyPoint(vector3);
			point = matrix4x.MultiplyPoint(point);
			point2 = matrix4x.MultiplyPoint(point2);
			point3 = matrix4x.MultiplyPoint(point3);
			GL.Color((selectedAxis != RuntimeHandleAxis.XZ) ? YColor : SelectionColor);
			GL.Vertex(position);
			GL.Vertex(vector3);
			GL.Vertex(vector3);
			GL.Vertex(point2);
			GL.Vertex(point2);
			GL.Vertex(vector);
			GL.Vertex(vector);
			GL.Vertex(position);
			GL.Color((selectedAxis != RuntimeHandleAxis.XY) ? ZColor : SelectionColor);
			GL.Vertex(position);
			GL.Vertex(vector2);
			GL.Vertex(vector2);
			GL.Vertex(point);
			GL.Vertex(point);
			GL.Vertex(vector);
			GL.Vertex(vector);
			GL.Vertex(position);
			GL.Color((selectedAxis != RuntimeHandleAxis.YZ) ? XColor : SelectionColor);
			GL.Vertex(position);
			GL.Vertex(vector2);
			GL.Vertex(vector2);
			GL.Vertex(point3);
			GL.Vertex(point3);
			GL.Vertex(vector3);
			GL.Vertex(vector3);
			GL.Vertex(position);
			GL.End();
			GL.Begin(7);
			GL.Color(YColorTransparent);
			GL.Vertex(position);
			GL.Vertex(vector3);
			GL.Vertex(point2);
			GL.Vertex(vector);
			GL.Color(ZColorTransparent);
			GL.Vertex(position);
			GL.Vertex(vector2);
			GL.Vertex(point);
			GL.Vertex(vector);
			GL.Color(XColorTransparent);
			GL.Vertex(position);
			GL.Vertex(vector2);
			GL.Vertex(point3);
			GL.Vertex(vector3);
			GL.End();
			ShapesMaterial.SetPass(0);
			Graphics.DrawMeshNow(Arrows, matrix4x);
			switch (selectedAxis)
			{
			case RuntimeHandleAxis.X:
				Graphics.DrawMeshNow(SelectionArrowX, matrix4x);
				break;
			case RuntimeHandleAxis.Y:
				Graphics.DrawMeshNow(SelectionArrowY, matrix4x);
				break;
			case RuntimeHandleAxis.Z:
				Graphics.DrawMeshNow(SelectionArrowZ, matrix4x);
				break;
			}
		}

		public static void DoRotationHandle(Quaternion rotation, Vector3 position, RuntimeHandleAxis selectedAxis = RuntimeHandleAxis.None)
		{
			float screenScale = GetScreenScale(position, Camera.current);
			float num = 1f;
			Vector3 s = new Vector3(screenScale, screenScale, screenScale);
			Matrix4x4 transform = Matrix4x4.TRS(Vector3.zero, rotation * Quaternion.AngleAxis(-90f, Vector3.up), Vector3.one);
			Matrix4x4 transform2 = Matrix4x4.TRS(Vector3.zero, rotation * Quaternion.AngleAxis(-90f, Vector3.right), Vector3.one);
			Matrix4x4 transform3 = Matrix4x4.TRS(Vector3.zero, rotation, Vector3.one);
			Matrix4x4 m = Matrix4x4.TRS(position, Quaternion.identity, s);
			LinesClipMaterial.SetPass(0);
			GL.PushMatrix();
			GL.MultMatrix(m);
			GL.Begin(1);
			GL.Color((selectedAxis != RuntimeHandleAxis.X) ? XColor : SelectionColor);
			DrawCircle(transform, num);
			GL.Color((selectedAxis != RuntimeHandleAxis.Y) ? YColor : SelectionColor);
			DrawCircle(transform2, num);
			GL.Color((selectedAxis != RuntimeHandleAxis.Z) ? ZColor : SelectionColor);
			DrawCircle(transform3, num);
			GL.End();
			GL.PopMatrix();
			LinesBillboardMaterial.SetPass(0);
			GL.PushMatrix();
			GL.MultMatrix(m);
			GL.Begin(1);
			GL.Color((selectedAxis != RuntimeHandleAxis.Free) ? AltColor : SelectionColor);
			DrawCircle(Matrix4x4.identity, num);
			GL.Color((selectedAxis != RuntimeHandleAxis.Screen) ? AltColor : SelectionColor);
			DrawCircle(Matrix4x4.identity, num * 1.1f);
			GL.End();
			GL.PopMatrix();
		}

		private static void DrawCircle(Matrix4x4 transform, float radius)
		{
			float num = 0f;
			float z = 0f;
			Vector3 v = transform.MultiplyPoint(new Vector3(radius, 0f, z));
			for (int i = 0; i < 32; i++)
			{
				GL.Vertex(v);
				num += (float)Math.PI / 16f;
				float x = radius * Mathf.Cos(num);
				float y = radius * Mathf.Sin(num);
				Vector3 vector = transform.MultiplyPoint(new Vector3(x, y, z));
				GL.Vertex(vector);
				v = vector;
			}
		}

		public static void DoScaleHandle(Vector3 scale, Vector3 position, Quaternion rotation, RuntimeHandleAxis selectedAxis = RuntimeHandleAxis.None)
		{
			float screenScale = GetScreenScale(position, Camera.current);
			Matrix4x4 transform = Matrix4x4.TRS(position, rotation, scale * screenScale);
			LinesMaterial.SetPass(0);
			GL.Begin(1);
			DoAxes(position, transform, selectedAxis);
			GL.End();
			Matrix4x4 matrix4x = Matrix4x4.TRS(Vector3.zero, rotation, scale);
			ShapesMaterial.SetPass(0);
			Vector3 vector = new Vector3(screenScale, screenScale, screenScale);
			Vector3 vector2 = matrix4x.MultiplyVector(Vector3.right) * screenScale;
			Vector3 vector3 = matrix4x.MultiplyVector(Vector3.up) * screenScale;
			Vector3 vector4 = matrix4x.MultiplyVector(Vector3.forward) * screenScale;
			switch (selectedAxis)
			{
			case RuntimeHandleAxis.X:
				Graphics.DrawMeshNow(SelectionCube, Matrix4x4.TRS(position + vector2, rotation, vector));
				Graphics.DrawMeshNow(CubeY, Matrix4x4.TRS(position + vector3, rotation, vector));
				Graphics.DrawMeshNow(CubeZ, Matrix4x4.TRS(position + vector4, rotation, vector));
				Graphics.DrawMeshNow(CubeUniform, Matrix4x4.TRS(position, rotation, vector * 1.35f));
				break;
			case RuntimeHandleAxis.Y:
				Graphics.DrawMeshNow(CubeX, Matrix4x4.TRS(position + vector2, rotation, vector));
				Graphics.DrawMeshNow(SelectionCube, Matrix4x4.TRS(position + vector3, rotation, vector));
				Graphics.DrawMeshNow(CubeZ, Matrix4x4.TRS(position + vector4, rotation, vector));
				Graphics.DrawMeshNow(CubeUniform, Matrix4x4.TRS(position, rotation, vector * 1.35f));
				break;
			case RuntimeHandleAxis.Z:
				Graphics.DrawMeshNow(CubeX, Matrix4x4.TRS(position + vector2, rotation, vector));
				Graphics.DrawMeshNow(CubeY, Matrix4x4.TRS(position + vector3, rotation, vector));
				Graphics.DrawMeshNow(SelectionCube, Matrix4x4.TRS(position + vector4, rotation, vector));
				Graphics.DrawMeshNow(CubeUniform, Matrix4x4.TRS(position, rotation, vector * 1.35f));
				break;
			case RuntimeHandleAxis.Free:
				Graphics.DrawMeshNow(CubeX, Matrix4x4.TRS(position + vector2, rotation, vector));
				Graphics.DrawMeshNow(CubeY, Matrix4x4.TRS(position + vector3, rotation, vector));
				Graphics.DrawMeshNow(CubeZ, Matrix4x4.TRS(position + vector4, rotation, vector));
				Graphics.DrawMeshNow(SelectionCube, Matrix4x4.TRS(position, rotation, vector * 1.35f));
				break;
			default:
				Graphics.DrawMeshNow(CubeX, Matrix4x4.TRS(position + vector2, rotation, vector));
				Graphics.DrawMeshNow(CubeY, Matrix4x4.TRS(position + vector3, rotation, vector));
				Graphics.DrawMeshNow(CubeZ, Matrix4x4.TRS(position + vector4, rotation, vector));
				Graphics.DrawMeshNow(CubeUniform, Matrix4x4.TRS(position, rotation, vector * 1.35f));
				break;
			}
		}

		public static void DoSceneGizmo(Vector3 position, Quaternion rotation, Vector3 selection, float gizmoScale, float xAlpha = 1f, float yAlpha = 1f, float zAlpha = 1f)
		{
			float num = GetScreenScale(position, Camera.current) * gizmoScale;
			Vector3 vector = new Vector3(num, num, num);
			float billboardOffset = 0.4f;
			if (Camera.current.orthographic)
			{
				billboardOffset = 0.42f;
			}
			if (selection != Vector3.zero)
			{
				if (selection == Vector3.one)
				{
					ShapesMaterialZTestOffset.SetPass(0);
					Graphics.DrawMeshNow(SceneGizmoSelectedCube, Matrix4x4.TRS(position, rotation, vector * 0.15f));
				}
				else if ((xAlpha == 1f || xAlpha == 0f) && (yAlpha == 1f || yAlpha == 0f) && (zAlpha == 1f || zAlpha == 0f))
				{
					ShapesMaterialZTestOffset.SetPass(0);
					Graphics.DrawMeshNow(SceneGizmoSelectedAxis, Matrix4x4.TRS(position, rotation * Quaternion.LookRotation(selection, Vector3.up), vector));
				}
			}
			ShapesMaterialZTest.SetPass(0);
			ShapesMaterialZTest.color = Color.white;
			Graphics.DrawMeshNow(SceneGizmoCube, Matrix4x4.TRS(position, rotation, vector * 0.15f));
			if (xAlpha == 1f && yAlpha == 1f && zAlpha == 1f)
			{
				Graphics.DrawMeshNow(SceneGizmoXAxis, Matrix4x4.TRS(position, rotation, vector));
				Graphics.DrawMeshNow(SceneGizmoYAxis, Matrix4x4.TRS(position, rotation, vector));
				Graphics.DrawMeshNow(SceneGizmoZAxis, Matrix4x4.TRS(position, rotation, vector));
			}
			else if (xAlpha < 1f)
			{
				ShapesMaterialZTest3.SetPass(0);
				ShapesMaterialZTest3.color = new Color(1f, 1f, 1f, yAlpha);
				Graphics.DrawMeshNow(SceneGizmoYAxis, Matrix4x4.TRS(position, rotation, vector));
				ShapesMaterialZTest4.SetPass(0);
				ShapesMaterialZTest4.color = new Color(1f, 1f, 1f, zAlpha);
				Graphics.DrawMeshNow(SceneGizmoZAxis, Matrix4x4.TRS(position, rotation, vector));
				ShapesMaterialZTest2.SetPass(0);
				ShapesMaterialZTest2.color = new Color(1f, 1f, 1f, xAlpha);
				Graphics.DrawMeshNow(SceneGizmoXAxis, Matrix4x4.TRS(position, rotation, vector));
				XMaterial.SetPass(0);
			}
			else if (yAlpha < 1f)
			{
				ShapesMaterialZTest4.SetPass(0);
				ShapesMaterialZTest4.color = new Color(1f, 1f, 1f, zAlpha);
				Graphics.DrawMeshNow(SceneGizmoZAxis, Matrix4x4.TRS(position, rotation, vector));
				ShapesMaterialZTest2.SetPass(0);
				ShapesMaterialZTest2.color = new Color(1f, 1f, 1f, xAlpha);
				Graphics.DrawMeshNow(SceneGizmoXAxis, Matrix4x4.TRS(position, rotation, vector));
				ShapesMaterialZTest3.SetPass(0);
				ShapesMaterialZTest3.color = new Color(1f, 1f, 1f, yAlpha);
				Graphics.DrawMeshNow(SceneGizmoYAxis, Matrix4x4.TRS(position, rotation, vector));
			}
			else
			{
				ShapesMaterialZTest2.SetPass(0);
				ShapesMaterialZTest2.color = new Color(1f, 1f, 1f, xAlpha);
				Graphics.DrawMeshNow(SceneGizmoXAxis, Matrix4x4.TRS(position, rotation, vector));
				ShapesMaterialZTest3.SetPass(0);
				ShapesMaterialZTest3.color = new Color(1f, 1f, 1f, yAlpha);
				Graphics.DrawMeshNow(SceneGizmoYAxis, Matrix4x4.TRS(position, rotation, vector));
				ShapesMaterialZTest4.SetPass(0);
				ShapesMaterialZTest4.color = new Color(1f, 1f, 1f, zAlpha);
				Graphics.DrawMeshNow(SceneGizmoZAxis, Matrix4x4.TRS(position, rotation, vector));
			}
			XMaterial.SetPass(0);
			XMaterial.color = new Color(1f, 1f, 1f, xAlpha);
			DragSceneGizmoAxis(position, rotation, Vector3.right, gizmoScale, 0.125f, billboardOffset, num);
			YMaterial.SetPass(0);
			YMaterial.color = new Color(1f, 1f, 1f, yAlpha);
			DragSceneGizmoAxis(position, rotation, Vector3.up, gizmoScale, 0.125f, billboardOffset, num);
			ZMaterial.SetPass(0);
			ZMaterial.color = new Color(1f, 1f, 1f, zAlpha);
			DragSceneGizmoAxis(position, rotation, Vector3.forward, gizmoScale, 0.125f, billboardOffset, num);
		}

		private static void DragSceneGizmoAxis(Vector3 position, Quaternion rotation, Vector3 axis, float gizmoScale, float billboardScale, float billboardOffset, float sScale)
		{
			Vector3 vector = Vector3.Reflect(Camera.current.transform.forward, axis) * 0.1f;
			float num = Vector3.Dot(Camera.current.transform.forward, axis);
			if (num > 0f)
			{
				if (Camera.current.orthographic)
				{
					vector += axis * num * 0.4f;
				}
				else
				{
					vector = axis * num * 0.7f;
				}
			}
			else if (Camera.current.orthographic)
			{
				vector -= axis * num * 0.1f;
			}
			else
			{
				vector = Vector3.zero;
			}
			Vector3 vector2 = position + (axis + vector) * billboardOffset * sScale;
			float num2 = GetScreenScale(vector2, Camera.current) * gizmoScale;
			Graphics.DrawMeshNow(matrix: Matrix4x4.TRS(vector2, rotation, new Vector3(num2, num2, num2) * billboardScale), mesh: SceneGizmoQuad);
		}

		public static float GetGridFarPlane()
		{
			float num = CountOfDigits(Camera.current.transform.position.y);
			return Mathf.Pow(10f, num - 1f) * 150f;
		}

		public static void DrawGrid()
		{
			Vector3 position = Camera.current.transform.position;
			float y = position.y;
			y = Mathf.Abs(y);
			y = Mathf.Max(1f, y);
			float num = CountOfDigits(y);
			float num2 = Mathf.Pow(10f, num - 1f);
			float num3 = Mathf.Pow(10f, num);
			float num4 = Mathf.Pow(10f, num + 1f);
			float alpha = 1f - (y - num2) / (num3 - num2);
			float alpha2 = (y * 10f - num3) / (num4 - num3);
			DrawGrid(position, num2, alpha, y * 20f);
			DrawGrid(position, num3, alpha2, y * 20f);
		}

		private static void DrawGrid(Vector3 cameraPosition, float spacing, float alpha, float fadeDisance)
		{
			cameraPosition.y = 0f;
			GridMaterial.SetFloat("_FadeDistance", fadeDisance);
			GridMaterial.SetPass(0);
			GL.Begin(1);
			GL.Color(new Color(1f, 1f, 1f, 0.1f * alpha));
			cameraPosition.x = Mathf.Floor(cameraPosition.x / spacing) * spacing;
			cameraPosition.z = Mathf.Floor(cameraPosition.z / spacing) * spacing;
			for (int i = -150; i < 150; i++)
			{
				GL.Vertex(cameraPosition + new Vector3((float)i * spacing, 0f, -150f * spacing));
				GL.Vertex(cameraPosition + new Vector3((float)i * spacing, 0f, 150f * spacing));
				GL.Vertex(cameraPosition + new Vector3(-150f * spacing, 0f, (float)i * spacing));
				GL.Vertex(cameraPosition + new Vector3(150f * spacing, 0f, (float)i * spacing));
			}
			GL.End();
		}

		public static float CountOfDigits(float number)
		{
			if (number != 0f)
			{
				return Mathf.Ceil(Mathf.Log10(Mathf.Abs(number) + 0.5f));
			}
			return 1f;
		}
	}
}
