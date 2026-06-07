using System.Collections.Generic;
using System.IO;

namespace Spine
{
	public class SkeletonJson : SkeletonLoader
	{
		private class LinkedMesh
		{
			internal string parent;

			internal string skin;

			internal int slotIndex;

			internal MeshAttachment mesh;

			internal bool inheritTimelines;

			public LinkedMesh(MeshAttachment mesh, string skin, int slotIndex, string parent, bool inheritTimelines)
			{
			}
		}

		private readonly List<LinkedMesh> linkedMeshes;

		public SkeletonJson(AttachmentLoader attachmentLoader)
			: base((Atlas[])null)
		{
		}

		public SkeletonJson(params Atlas[] atlasArray)
			: base((Atlas[])null)
		{
		}

		public override SkeletonData ReadSkeletonData(string path)
		{
			return null;
		}

		public SkeletonData ReadSkeletonData(TextReader reader)
		{
			return null;
		}

		private Attachment ReadAttachment(Dictionary<string, object> map, Skin skin, int slotIndex, string name, SkeletonData skeletonData)
		{
			return null;
		}

		public static Sequence ReadSequence(object sequenceJson)
		{
			return null;
		}

		private void ReadVertices(Dictionary<string, object> map, VertexAttachment attachment, int verticesLength)
		{
		}

		private int FindSlotIndex(SkeletonData skeletonData, string slotName)
		{
			return 0;
		}

		private void ReadAnimation(Dictionary<string, object> map, string name, SkeletonData skeletonData)
		{
		}

		private static Timeline ReadTimeline(ref List<object>.Enumerator keyMapEnumerator, CurveTimeline1 timeline, float defaultValue, float scale)
		{
			return null;
		}

		private static Timeline ReadTimeline(ref List<object>.Enumerator keyMapEnumerator, CurveTimeline2 timeline, string name1, string name2, float defaultValue, float scale)
		{
			return null;
		}

		private static int ReadCurve(object curve, CurveTimeline timeline, int bezier, int frame, int value, float time1, float time2, float value1, float value2, float scale)
		{
			return 0;
		}

		private static void SetBezier(CurveTimeline timeline, int frame, int value, int bezier, float time1, float value1, float cx1, float cy1, float cx2, float cy2, float time2, float value2)
		{
		}

		private static float[] GetFloatArray(Dictionary<string, object> map, string name, float scale)
		{
			return null;
		}

		private static int[] GetIntArray(Dictionary<string, object> map, string name)
		{
			return null;
		}

		private static float GetFloat(Dictionary<string, object> map, string name, float defaultValue)
		{
			return 0f;
		}

		private static int GetInt(Dictionary<string, object> map, string name, int defaultValue)
		{
			return 0;
		}

		private static int GetInt(Dictionary<string, object> map, string name)
		{
			return 0;
		}

		private static bool GetBoolean(Dictionary<string, object> map, string name, bool defaultValue)
		{
			return false;
		}

		private static string GetString(Dictionary<string, object> map, string name, string defaultValue)
		{
			return null;
		}

		private static float ToColor(string hexString, int colorIndex, int expectedLength = 8)
		{
			return 0f;
		}
	}
}
