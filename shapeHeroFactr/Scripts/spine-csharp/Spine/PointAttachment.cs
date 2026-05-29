namespace Spine
{
	public class PointAttachment : Attachment
	{
		internal float x;

		internal float y;

		internal float rotation;

		public float X
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float Y
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public float Rotation
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public PointAttachment(string name)
			: base((string)null)
		{
		}

		protected PointAttachment(PointAttachment other)
			: base((string)null)
		{
		}

		public void ComputeWorldPosition(Bone bone, out float ox, out float oy)
		{
			ox = default(float);
			oy = default(float);
		}

		public float ComputeWorldRotation(Bone bone)
		{
			return 0f;
		}

		public override Attachment Copy()
		{
			return null;
		}
	}
}
