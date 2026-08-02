namespace GRP
{
	public class ProgressTaskNode : ProgressTask
	{
		public string info;

		public float progress;

		public ProgressTaskNode()
		{
		}

		public ProgressTaskNode(string info, float progress = 0f)
		{
		}

		public void Update(float progress)
		{
		}

		public void Update(string info)
		{
		}

		public void Update(float progress, string info)
		{
		}

		public override string GetInfo()
		{
			return null;
		}

		public override float GetProgress()
		{
			return 0f;
		}

		public override bool IsActive()
		{
			return false;
		}
	}
}
