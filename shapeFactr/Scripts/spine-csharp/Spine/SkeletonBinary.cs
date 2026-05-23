using System.Collections.Generic;
using System.IO;

namespace Spine
{
	public class SkeletonBinary : SkeletonLoader
	{
		internal class Vertices
		{
			public int length;

			public int[] bones;

			public float[] vertices;
		}

		internal class SkeletonInput
		{
			private byte[] chars;

			private byte[] bytesBigEndian;

			internal string[] strings;

			private Stream input;

			public SkeletonInput(Stream input)
			{
			}

			public int Read()
			{
				return 0;
			}

			public byte ReadUByte()
			{
				return 0;
			}

			public sbyte ReadSByte()
			{
				return 0;
			}

			public bool ReadBoolean()
			{
				return false;
			}

			public float ReadFloat()
			{
				return 0f;
			}

			public int ReadInt()
			{
				return 0;
			}

			public long ReadLong()
			{
				return 0L;
			}

			public int ReadInt(bool optimizePositive)
			{
				return 0;
			}

			public string ReadString()
			{
				return null;
			}

			public string ReadStringRef()
			{
				return null;
			}

			public void ReadFully(byte[] buffer, int offset, int length)
			{
			}

			public string GetVersionString()
			{
				return null;
			}

			public string GetVersionStringOld3X()
			{
				return null;
			}
		}

		private class LinkedMesh
		{
			internal string parent;

			internal int skinIndex;

			internal int slotIndex;

			internal MeshAttachment mesh;

			internal bool inheritTimelines;

			public LinkedMesh(MeshAttachment mesh, int skinIndex, int slotIndex, string parent, bool inheritTimelines)
			{
			}
		}

		public const int BONE_ROTATE = 0;

		public const int BONE_TRANSLATE = 1;

		public const int BONE_TRANSLATEX = 2;

		public const int BONE_TRANSLATEY = 3;

		public const int BONE_SCALE = 4;

		public const int BONE_SCALEX = 5;

		public const int BONE_SCALEY = 6;

		public const int BONE_SHEAR = 7;

		public const int BONE_SHEARX = 8;

		public const int BONE_SHEARY = 9;

		public const int BONE_INHERIT = 10;

		public const int SLOT_ATTACHMENT = 0;

		public const int SLOT_RGBA = 1;

		public const int SLOT_RGB = 2;

		public const int SLOT_RGBA2 = 3;

		public const int SLOT_RGB2 = 4;

		public const int SLOT_ALPHA = 5;

		public const int ATTACHMENT_DEFORM = 0;

		public const int ATTACHMENT_SEQUENCE = 1;

		public const int PATH_POSITION = 0;

		public const int PATH_SPACING = 1;

		public const int PATH_MIX = 2;

		public const int PHYSICS_INERTIA = 0;

		public const int PHYSICS_STRENGTH = 1;

		public const int PHYSICS_DAMPING = 2;

		public const int PHYSICS_MASS = 4;

		public const int PHYSICS_WIND = 5;

		public const int PHYSICS_GRAVITY = 6;

		public const int PHYSICS_MIX = 7;

		public const int PHYSICS_RESET = 8;

		public const int CURVE_LINEAR = 0;

		public const int CURVE_STEPPED = 1;

		public const int CURVE_BEZIER = 2;

		private readonly List<LinkedMesh> linkedMeshes;

		public SkeletonBinary(AttachmentLoader attachmentLoader)
			: base((Atlas[])null)
		{
		}

		public SkeletonBinary(params Atlas[] atlasArray)
			: base((Atlas[])null)
		{
		}

		public override SkeletonData ReadSkeletonData(string path)
		{
			return null;
		}

		public static string GetVersionString(Stream file)
		{
			return null;
		}

		public SkeletonData ReadSkeletonData(Stream file)
		{
			return null;
		}

		private Skin ReadSkin(SkeletonInput input, SkeletonData skeletonData, bool defaultSkin, bool nonessential)
		{
			return null;
		}

		private Attachment ReadAttachment(SkeletonInput input, SkeletonData skeletonData, Skin skin, int slotIndex, string attachmentName, bool nonessential)
		{
			return null;
		}

		private Sequence ReadSequence(SkeletonInput input)
		{
			return null;
		}

		private Vertices ReadVertices(SkeletonInput input, bool weighted)
		{
			return null;
		}

		private float[] ReadFloatArray(SkeletonInput input, int n, float scale)
		{
			return null;
		}

		private int[] ReadShortArray(SkeletonInput input, int n)
		{
			return null;
		}

		private Animation ReadAnimation(string name, SkeletonInput input, SkeletonData skeletonData)
		{
			return null;
		}

		private void ReadTimeline(SkeletonInput input, ExposedList<Timeline> timelines, CurveTimeline1 timeline, float scale)
		{
		}

		private void ReadTimeline(SkeletonInput input, ExposedList<Timeline> timelines, CurveTimeline2 timeline, float scale)
		{
		}

		private void SetBezier(SkeletonInput input, CurveTimeline timeline, int bezier, int frame, int value, float time1, float time2, float value1, float value2, float scale)
		{
		}
	}
}
