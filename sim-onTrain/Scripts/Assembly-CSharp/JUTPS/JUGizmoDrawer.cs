using UnityEngine;

namespace JUTPS
{
	[AddComponentMenu("JU TPS/Tools/JU Gizmo Drawer")]
	public class JUGizmoDrawer : MonoBehaviour
	{
		public enum DrawType
		{
			Solid = 0,
			Wireframe = 1,
			Both = 2
		}

		public enum DrawMesh
		{
			Hand = 0,
			ClosedHand = 1,
			ArmedHand = 2,
			Foot = 3,
			Steps = 4,
			Humanoid = 5,
			Point = 6
		}

		public bool Draw = true;

		public DrawMesh ModelToDraw = DrawMesh.Humanoid;

		public DrawType DrawMode = DrawType.Both;

		public Color GizmoColor = new Color(0.2f, 0.2f, 0.2f, 0.5f);

		public Color WireframeColor = new Color(1f, 1f, 1f, 0.1f);

		public bool MirrorX;

		private static Mesh Hand;

		private static Mesh ClosedHand;

		private static Mesh ArmedHand;

		private static Mesh Foot;

		private static Mesh Steps;

		private static Mesh Humanoid;

		private static void LoadMeshes()
		{
			Hand = GetEditorResourceModel("Hand Visualizer Model");
			ClosedHand = GetEditorResourceModel("Hand Closed Visualizer Model");
			ArmedHand = GetEditorResourceModel("Hand Armed Visualizer Model");
			Foot = GetEditorResourceModel("Foot Visualizer Model");
			Steps = GetEditorResourceModel("Step Visualizer Model");
			Humanoid = GetEditorResourceModel();
		}

		public static Mesh GetEditorResourceModel(string ModelName = "Humanoid Visualizer Model")
		{
			Debug.Log("Unable to load editor models without being in editor");
			return null;
		}

		public static Mesh GetJUGizmoDefaultMesh(DrawMesh mesh)
		{
			if (Humanoid == null)
			{
				LoadMeshes();
			}
			return mesh switch
			{
				DrawMesh.Hand => Hand, 
				DrawMesh.ClosedHand => ClosedHand, 
				DrawMesh.ArmedHand => ArmedHand, 
				DrawMesh.Foot => Foot, 
				DrawMesh.Steps => Steps, 
				DrawMesh.Humanoid => Humanoid, 
				DrawMesh.Point => null, 
				_ => null, 
			};
		}

		public static JUGizmoDrawer CreateNewJUGizmo(string Name = "JUGizmo", Vector3 Position = default(Vector3), Quaternion Rotation = default(Quaternion), DrawMesh ModelToDraw = DrawMesh.Humanoid, Color Color = default(Color), Color WireframeColor = default(Color), bool Mirror = false, DrawType DrawMode = DrawType.Both)
		{
			JUGizmoDrawer jUGizmoDrawer = new GameObject(Name).AddComponent<JUGizmoDrawer>();
			jUGizmoDrawer.transform.position = Position;
			jUGizmoDrawer.transform.rotation = Rotation;
			jUGizmoDrawer.ModelToDraw = ModelToDraw;
			jUGizmoDrawer.GizmoColor = Color;
			jUGizmoDrawer.WireframeColor = WireframeColor;
			jUGizmoDrawer.MirrorX = Mirror;
			jUGizmoDrawer.DrawMode = DrawMode;
			return jUGizmoDrawer;
		}

		public static GameObject CreateLeftHandGizmo(Vector3 Position = default(Vector3), Quaternion Rotation = default(Quaternion), bool Closed = false)
		{
			return CreateNewJUGizmo(Color: new Color(0.3f, 1f, 0.3f, 0.7f), WireframeColor: new Color(0.7f, 1f, 0.7f, 0.1f), Name: "Left Hand Point", Position: Position, Rotation: Rotation, ModelToDraw: Closed ? DrawMesh.ClosedHand : DrawMesh.Hand).gameObject;
		}

		public static GameObject CreateRightHandGizmo(Vector3 Position = default(Vector3), Quaternion Rotation = default(Quaternion), bool Closed = false)
		{
			return CreateNewJUGizmo(Color: new Color(0.3f, 0.5f, 1f, 0.7f), WireframeColor: new Color(0.5f, 0.8f, 1f, 0.1f), Name: "Right Hand Point", Position: Position, Rotation: Rotation, ModelToDraw: Closed ? DrawMesh.ClosedHand : DrawMesh.Hand, Mirror: true).gameObject;
		}

		public static GameObject CreateLeftFootGizmo(Vector3 Position = default(Vector3), Quaternion Rotation = default(Quaternion))
		{
			Color color = new Color(0.3f, 1f, 0.3f, 0.7f);
			Color wireframeColor = new Color(0.7f, 1f, 0.7f, 0.1f);
			return CreateNewJUGizmo("Left Foot Point", Position, Rotation, DrawMesh.Foot, color, wireframeColor).gameObject;
		}

		public static GameObject CreateRightFootGizmo(Vector3 Position = default(Vector3), Quaternion Rotation = default(Quaternion))
		{
			Color color = new Color(0.3f, 0.5f, 1f, 0.7f);
			Color wireframeColor = new Color(0.5f, 0.8f, 1f, 0.1f);
			return CreateNewJUGizmo("Right Foot Point", Position, Rotation, DrawMesh.Foot, color, wireframeColor, Mirror: true).gameObject;
		}

		public static GameObject CreateRedPointGizmo(Vector3 Position = default(Vector3), Quaternion Rotation = default(Quaternion))
		{
			Color color = new Color(1f, 0.2f, 0.2f, 0.5f);
			Color wireframeColor = new Color(1f, 0.7f, 0.7f, 0.7f);
			return CreateNewJUGizmo("Red Point", Position, Rotation, DrawMesh.Point, color, wireframeColor, Mirror: true).gameObject;
		}
	}
}
